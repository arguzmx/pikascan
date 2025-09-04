using PikaScan.Modelo;
using PikaScan.Servicios.pikaapi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PikaScan
{
    public partial class Form1 : Form
    {
        public static DTOTokenScanner scanner;
        public static Documento documento;
        public static string InsertAfter = string.Empty;
        public static string LastPageItem = string.Empty;
        public static Form1 Instance { get; private set; }
        private string scanPAth;
        private string docPath;

        public Form1(string deeplink)
        {
            InitializeComponent();
            Instance = this;
#if DEBUG
            deeplink = "%7B%22Id%22%3A8%2C%22Token%22%3A%2206e5ac7a63ae4766af771c656ea2a765%22%2C%22ElementoId%22%3A%22daaec56f-9925-41f1-b4ea-9199d18121ef%22%2C%22VersionId%22%3A%22daaec56f-9925-41f1-b4ea-9199d18121ef%22%2C%22Caducidad%22%3A%222025-09-02T16%3A07%3A18.3393968-06%3A00%22%2C%22PuntoMontajeId%22%3A%229ca3c559-9060-40a7-89c0-0dee976f1444%22%2C%22VolumenId%22%3A%22cd80cd33-33ea-40be-b997-c152d6ea1aad%22%2C%22NombreDocumento%22%3A%22CCC%22%2C%22UrlBase%22%3A%22http%3A%2F%2Flocalhost%3A5000%2Fapi%2Fv1.0%2Fupload%22%7D";
#endif
            if (deeplink != null) {
                scanner = ObtenerDatosDeeplink(deeplink);
                if (scanner == null)
                {
                    MessageBox.Show("El enlace no es valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                } else
                {
                    this.Text = $"PikaScan - {scanner.NombreDocumento}";
                    this.twainCapture1.jobExplorer = this.jobExplorer1;
                    this.jobExplorer1.documentViewer = this.documentViewer1;

                    scanPAth = Path.Combine(Application.StartupPath, "scan", scanner.ElementoId);
                    docPath = Path.Combine(Application.StartupPath, "scan", scanner.ElementoId, "doc.json");
                    if (Directory.Exists(scanPAth) && File.Exists(docPath) )
                    {
                        documento = Newtonsoft.Json.JsonConvert.DeserializeObject<Documento>(File.ReadAllText(docPath));    
                    }
                    else
                    {
                        documento = new Documento()
                        {
                            Id = scanner.ElementoId,
                            Nombre = scanner.NombreDocumento,
                            FechaCreacion = DateTime.Now,
                            EstadoTrabajo = EstadoTrabajo.Abierto,
                            CantidadPaginas = 0,
                            FechaModificacion = DateTime.Now,
                            IdLote = "",
                            Indice = 0,
                            Paginas = new List<Pagina>(),
                            Path = Path.Combine(Application.StartupPath, "scan", scanner.ElementoId),
                            RemoteId = "",
                            TipoTrabajo = TipoTrabajo.Local,
                            UserId = ""
                        };

                    }

                    this.twainCapture1.AjustaBotonera();

                    this.jobExplorer1.Showdocument(documento);
                }
            }
            else
            {
                MessageBox.Show("El programa debe ejecutarse desde Pika-GD");
                this.Close();
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.twainCapture1.StartModule();
        }

        private DTOTokenScanner ObtenerDatosDeeplink(string deeplink = null)
        {
            try
            {

               string data = Uri.UnescapeDataString(deeplink);

                DTOTokenScanner token = Newtonsoft.Json.JsonConvert.DeserializeObject<DTOTokenScanner>(data);
 

                return token;
            }
            catch (Exception)
            {

                return null;
            }

        }

        private void twainCapture1_Load(object sender, EventArgs e)
        {

        }

        public void ShowNotification(string text, ToolTipIcon type)
        {
            tsLAbel.Text = text;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Desde el front llamar click al icono del escaner para crear el tokenscanner y darle click al boton prueba.
            //Remplazar la ruta con archivos para la prueba

            var paginas = new List<PaginaPika>
            {
                new PaginaPika { Ruta = @"C:\Users\desarrollo\Pictures\IMG\dino.jpg" },
                new PaginaPika { Ruta = @"C:\Users\desarrollo\Pictures\IMG\cars.jpg" },
            };


        }

        private void documentViewer1_Load(object sender, EventArgs e)
        {

        }

        public void UpdateProgress(int value, int max)
        {
            if (Instance != null)
            {
                Application.DoEvents();
                if (value >= max)
                {
                    Instance.tsProgressSend.Visible = false;
                    Instance.tsProgressSend.Value = 0;
                    Instance.tsLAbel.Text = "Enviío finalizado";
                }
                else
                {
                    Instance.tsProgressSend.Visible = true;
                    Instance.tsProgressSend.Minimum = 0;
                    Instance.tsProgressSend.Maximum = max;
                    Instance.tsProgressSend.Value = value;
                    Instance.tsLAbel.Text = $"Enviando página {value} de {max}";
                }
                Application.DoEvents();
            }
        } 
        
        public void RemovePages(List<string> paths )
        {
            this.documentViewer1.ClearPorts();
            var temp = Newtonsoft.Json.JsonConvert.DeserializeObject<Documento>(File.ReadAllText(docPath));
            foreach (string path in paths) { 
                    FileInfo fi = new FileInfo(path);

                var p = temp.Paginas.FirstOrDefault(x => x.Name.Equals(fi.Name, StringComparison.InvariantCultureIgnoreCase));
                if(p != null)
                {
                    try
                    {
                        File.Delete(path);
                    }
                    catch (Exception ex)
                    {
                    }
                    temp.Paginas.Remove(p);
                }
            }
            documento = ResavePages(temp);
            File.Delete(docPath);
            File.WriteAllText(docPath, Newtonsoft.Json.JsonConvert.SerializeObject(documento));
        }


        private Documento ResavePages(Documento documento)
        {
            foreach(var p in documento.Paginas.OrderBy(x=>x.Index))
            {
                string source = Path.Combine(documento.Path, p.Name);
                string dest = Path.Combine(documento.Path, "temp-" + p.Name);
                File.Move(source, dest);
            }

            int index = 1;
            foreach (var p in documento.Paginas.OrderBy(x => x.Index))
            {
                string source = Path.Combine(documento.Path, "temp-" + p.Name);
                p.Index = index;
                p.Name = p.GetNameFromIndex();
                string dest = Path.Combine(documento.Path, p.GetNameFromIndex());
                File.Move(source, dest);
                index++;
            }

            return documento;   
        }

        public void FlipTsLabelInsert(bool visible)
        {
            tsLabelInsert.Visible = visible;
        }

        public void SetInsertAfter(string name, string lastItem)
        {
            LastPageItem = lastItem;
            InsertAfter = name;
        }

        public bool CheckPageInsert()
        {
            if (!string.IsNullOrEmpty(InsertAfter))
            {
                this.documentViewer1.ClearPorts();
                
                Pagina last = documento.Paginas.FirstOrDefault(p => p.Name == LastPageItem);
                List<Pagina> adicionales = new List<Pagina>();

                foreach (var p in documento.Paginas)
                {
                    string source = Path.Combine(documento.Path, p.Name);
                    string dest = Path.Combine(documento.Path, "temp-" + p.Name);
                    File.Move (source, dest);    
                }

                bool latch = false;
                foreach(var p in documento.Paginas) 
                {
                    if (latch)
                    {
                        adicionales.Add(p);
                    }

                    if (p.Name == LastPageItem) { 
                        latch = true;
                    }

                }

                List<Pagina> tempP = new List<Pagina>();
                latch = false;
                foreach (var p in documento.Paginas)
                {
                    tempP.Add(p);
                    if (p.Name == InsertAfter)
                    {
                        tempP.AddRange(adicionales);
                    }
                    if (p.Name == LastPageItem)
                    {
                        break;
                    }
                }

                int index = 1;
                foreach (var p in tempP)
                {
                    string source = Path.Combine(documento.Path, "temp-" + p.Name);
                    p.Index = index;
                    p.Name = p.GetNameFromIndex();
                    string dest = Path.Combine(documento.Path, p.GetNameFromIndex());
                    File.Move(source, dest);
                    index++;
                }

                documento.Paginas = tempP;
                File.Delete(docPath);
                File.WriteAllText(docPath, Newtonsoft.Json.JsonConvert.SerializeObject(documento));
                this.jobExplorer1.PopulateListView(documento);  
                return true;
            }

            return false;
        }

        private void jobExplorer1_Load(object sender, EventArgs e)
        {

        }
    }
}
