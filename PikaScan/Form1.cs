using PikaScan.Modelo;
using PikaScan.Servicios.pikaapi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PikaScan
{
    public partial class Form1 : Form
    {
        public static DTOTokenScanner scanner;
        public static Documento documento;
        public static Form1 Instance { get; private set; }


        public Form1(string deeplink)
        {
            InitializeComponent();
            Instance = this;
//#if DEBUG
//            deeplink = "%7B%22Id%22%3A57%2C%22Token%22%3A%2274b1f0b0484740d9af6e6e87d980908e%22%2C%22ElementoId%22%3A%226ad15df2-bc4a-421a-918d-4fd07c4b04b8%22%2C%22VersionId%22%3A%226ad15df2-bc4a-421a-918d-4fd07c4b04b8%22%2C%22Caducidad%22%3A%222025-09-04T10%3A06%3A09.7600739-06%3A00%22%2C%22PuntoMontajeId%22%3A%22721ce723-e78b-466a-830b-2201ac050fff%22%2C%22VolumenId%22%3A%227525081c-6713-43d1-966a-87d68b722bfb%22%2C%22NombreDocumento%22%3A%22Elemento2%22%2C%22UrlBase%22%3A%22http%3A%2F%2Flocalhost%3A5000%2Fapi%2Fv1.0%2Fupload%22%7D";
//#endif


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

                    string scanPAth = Path.Combine(Application.StartupPath, "scan", scanner.ElementoId);
                    string docPath = Path.Combine(Application.StartupPath, "scan", scanner.ElementoId, "doc.json");
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
    }
}
