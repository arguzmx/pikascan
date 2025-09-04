using GdPicture;
using Ninject.Planning;
using PikaScan.Modelo;
using PikaScan.Servicios;
using PikaScan.Servicios.pikaapi;
using PikaScan.Servicios.pikascan;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikaScan.Controles
{
    public partial class TWAINCapture : UserControl
    {

        public bool AllowAquire { get; set; }
        public event EventHandler ImportEnded;
   
        protected virtual void OnImportEnded(EventArgs e)
        {
            EventHandler handler = ImportEnded;
            handler?.Invoke(this, e);
        }


        private IntPtr h = IntPtr.Zero;
        public const string GDILIC = "411897669724499821116142492193218";
        private GdPicture.GdPictureImaging g;
        private string currentSource = "";
        private bool InSession = false;
        private bool LoadingScanners = false;
        private TWAINController controller = null;
        private bool capturando = false;
        public string DocumentId { get; set; }
        public JobExplorer jobExplorer { get; set; }

        public DocumentViewer documentViewer { get; set; }

        public TWAINCapture()
        {
            InitializeComponent();
            AllowAquire = true;
        }

        private void TWAINCapture_Load(object sender, EventArgs e)
        {
            AppSettings aset =new AppSettings();
            IDocumentService ds = new PikaScanDocumentService();
            IPageService pageService = new ServicioPaginas("1");
            controller = new TWAINController(ds, pageService, aset);
        }

        public void ReleaseModule()
        {
            if (InSession)
            {
                g.TwainCloseSource();
                InSession = false;
            }
        }

        public void AjustaBotonera()
        {
            pbSend.Visible = false;
            btnCameraAquire.Visible = !capturando;
            pbStop.Visible = capturando;

            if(!capturando && Form1.documento.Paginas.Count > 0)
            {
                pbSend.Visible = true;
            } 
            
        }

        public void StartModule()
        {
            if (g == null)
            {
                g = new GdPicture.GdPictureImaging();
                g.SetLicenseNumber(GDILIC);

            }
            LoadScanners();
        }

        private void LoadScanners()
        {
            try
            {
                LoadingScanners = true;
                h = ((Form1)Program.GetMainForm()).Handle;
                int count = g.TwainGetSourceCount(h);
                List<ParCombo> l = new List<ParCombo>();
                if (count > 0)
                {
                    for (int i = 1; i <= count; i++)
                    {
                        ParCombo p = new ParCombo() { Display = g.TwainGetSourceName(h, i), Value = i.ToString() };
                        l.Add(p);
                    }
                } 

                this.cmbScanners.DataSource = null;
                this.cmbScanners.Items.Clear();
                this.cmbScanners.ValueMember = "Value";
                this.cmbScanners.DisplayMember = "Display";
                this.cmbScanners.DataSource = l;

                if (this.cmbScanners.Items.Count > 0)
                {
                    currentSource = (this.cmbScanners.Items[0] as ParCombo).Display;
                    GetSourceConfig(currentSource);
                }
            }
            catch (Exception ex)
            {

                UIHelper.ShowNotification("Error al obtener la lista de scanners: " + ex.Message, ToolTipIcon.Error);
            }
            LoadingScanners = false;

        }

        private void GetCompressions()
        {
            List<ParCombo> lcom = new List<ParCombo>();

            this.cmbCompres.Items.Clear();
            this.cmbCompres.ValueMember = "Value";
            this.cmbCompres.DisplayMember = "Display";

            if (g.TwainGetAvailableCompressionCount() > 0)
            {
                for (int i = 1; i <= g.TwainGetAvailableCompressionCount(); i++)
                {
                    TwainCompression comp = g.TwainGetAvailableCompressionNo(i);
                    string compLabel = "";
                    switch (comp)
                    {
                        case TwainCompression.TWCP_BITFIELDS:
                            compLabel = "Bitfields";
                            break;

                        case TwainCompression.TWCP_GROUP31D:
                            compLabel = "Grupo 31D";
                            break;

                        case TwainCompression.TWCP_GROUP31DEOL:
                            compLabel = "Grupo 31D eol";
                            break;

                        case TwainCompression.TWCP_GROUP32D:
                            compLabel = "Grupo 32D eol";
                            break;

                        case TwainCompression.TWCP_GROUP4:
                            compLabel = "Grupo 4";
                            break;

                        case TwainCompression.TWCP_JBIG:
                            compLabel = "JBIG";
                            break;

                        case TwainCompression.TWCP_JPEG:
                            compLabel = "JPEG";
                            break;

                        case TwainCompression.TWCP_LZW:
                            compLabel = "LZW";
                            break;

                        case TwainCompression.TWCP_NONE:
                            compLabel = "Sin compresión";
                            break;

                        case TwainCompression.TWCP_PACKBITS:
                            compLabel = "Packbits";
                            break;

                        case TwainCompression.TWCP_PNG:
                            compLabel = "PNG";
                            break;

                        case TwainCompression.TWCP_RLE4:
                            compLabel = "RLE 4";
                            break;

                        case TwainCompression.TWCP_RLE8:
                            compLabel = "RLE 8";
                            break;

                        case TwainCompression.TWCP_UNSUPPORTED:
                            compLabel = "No soportada";
                            break;
                    }

                    if (compLabel != "")
                    {
                        ParCombo p = new ParCombo() { Display = $"{compLabel}", Value = comp.GetHashCode().ToString() };
                        lcom.Add(p);
                    }

                }
            }



            this.cmbCompres.DataSource = lcom;
        }

        private void GetResolutions()
        {
            List<ParCombo> lres = new List<ParCombo>();

            this.cmbRes.Items.Clear();
            this.cmbRes.ValueMember = "Value";
            this.cmbRes.DisplayMember = "Display";

            if (g.TwainGetAvailableXResolutionCount() > 0)
            {
                for (int i = 1; i <= g.TwainGetAvailableXResolutionCount(); i++)
                {
                    string res = g.TwainGetAvailableXResolutionNo(i).ToString();
                    ParCombo p = new ParCombo() { Display = $"{res} dpi", Value = res };
                    lres.Add(p);
                }
            }

            if (lres.Count > 0)
            {
                SetResolution(int.Parse(lres[0].Value));
            }

            this.cmbRes.DataSource = lres;
        }


        private void GetAutoOrientation()
        {
            chkOrientar.Visible = false;
            chkOrientar.Checked = false;
            if (g.TwainIsAutomaticRotationAvailable())
            {
                chkOrientar.Visible = true;
                chkOrientar.Checked = false;
            }
        }

        private void GetDuplexing()
        {

            ChkDuplex.Visible = false;
            ChkDuplex.Checked = false;

            switch (g.TwainGetDuplexMode())
            {
                case 0:
                    break;

                case 1:
                    ChkDuplex.Visible = true;
                    ChkDuplex.Text = "Duplex";
                    ChkDuplex.Checked = false;
                    break;

                case 2:
                    ChkDuplex.Visible = true;
                    ChkDuplex.Text = "Duplex 2 pasadas";
                    ChkDuplex.Checked = false;
                    break;

            }

        }


        private void SetResolution(int res)
        {
            cmbPixelType.DataSource = null;
            cmbPixelType.Items.Clear();

            cmbFormat.DataSource = null;
            cmbFormat.Items.Clear();


            if (g.TwainSetResolution(res))
            {
                this.GetPixelTypes();
            }
        }

        private void SetFileFormat(TwainImageFileFormats format)
        {


            cmbCompres.DataSource = null;
            cmbCompres.Items.Clear();


            if (g.TwainSetImageFileFormat(format))
            {
                this.GetCompressions();
            }
        }

        private void SetPixelType(TwainPixelType pt)
        {
            cmbFormat.DataSource = null;
            cmbFormat.Items.Clear();
            if (g.TwainSetPixelType(pt))
            {

                this.GetImageFormats();
            }
        }

        private void GetPixelTypes()
        {



            this.cmbPixelType.Items.Clear();
            this.cmbPixelType.ValueMember = "Value";
            this.cmbPixelType.DisplayMember = "Display";

            List<ParCombo> lpix = new List<ParCombo>();
            if (g.TwainGetAvailablePixelTypeCount() > 0)
            {
                for (int i = 1; i <= g.TwainGetAvailablePixelTypeCount(); i++)
                {
                    TwainPixelType pix = g.TwainGetAvailablePixelTypeNo(i);
                    string pixlabel = "";
                    switch (pix)
                    {
                        case TwainPixelType.TWPT_BW:
                            pixlabel = "Bitonal";
                            break;

                        case TwainPixelType.TWPT_GRAY:
                            pixlabel = "Grises";
                            break;


                        default:
                            pixlabel = "Color";
                            break;
                    }


                    ParCombo p = new ParCombo() { Display = $"{pixlabel}", Value = pix.GetHashCode().ToString() };
                    lpix.Add(p);
                }
            }

            if (lpix.Count > 0)
            {
                TwainPixelType pt = (TwainPixelType)int.Parse((lpix[0] as ParCombo).Value);
                this.SetPixelType(pt);
            }

            this.cmbPixelType.DataSource = lpix;
        }


        private void GetImageFormats()
        {

            this.cmbFormat.Items.Clear();
            this.cmbFormat.ValueMember = "Value";
            this.cmbFormat.DisplayMember = "Display";
            List<ParCombo> lformat = new List<ParCombo>();

            if (g.TwainGetAvailableImageFileFormatCount() > 0)
            {
                for (int i = 1; i <= g.TwainGetAvailableImageFileFormatCount(); i++)
                {
                    TwainImageFileFormats format = g.TwainGetAvailableImageFileFormatNo(i);
                    string formatlabel = "";

                    switch (format)
                    {
                        case TwainImageFileFormats.TWFF_BMP:
                            formatlabel = "BMP";
                            break;

                        case TwainImageFileFormats.TWFF_PNG:
                            formatlabel = "PNG";
                            break;

                        case TwainImageFileFormats.TWFF_TIFF:
                            formatlabel = "TIFF";
                            break;

                        case TwainImageFileFormats.TWFF_JFIF:
                            formatlabel = "JPEG";
                            break;
                    }

                    if (formatlabel != "")
                    {
                        ParCombo p = new ParCombo() { Display = $"{formatlabel}", Value = format.GetHashCode().ToString() };
                        lformat.Add(p);
                    }

                }
            }

            if (lformat.Count > 0)
            {
                TwainImageFileFormats format = (TwainImageFileFormats)int.Parse((lformat[0] as ParCombo).Value);
                SetFileFormat(format);
            }

            this.cmbFormat.DataSource = lformat;
        }

        private void GetSourceConfig(string id)
        {
            try
            {
                ClearConfig();

                if (InSession)
                {
                    g.TwainCloseSource();
                    InSession = false;
                }


                if (g.TwainOpenSource(h, id))
                {
                    this.GetAutoOrientation();
                    this.GetResolutions();
                    this.GetDuplexing();
                    InSession = true;
                    UIHelper.ShowNotification($"Conectado al scanner {id}", ToolTipIcon.Info);
                }
                else
                {

                    UIHelper.ShowNotification($"No se pudo conectar al scanner {id}", ToolTipIcon.Warning);
                }


            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
                UIHelper.ShowNotification($"No se pudo conectar al scanner {id}: {ex.Message}", ToolTipIcon.Warning);
            }


        }


        private void ClearConfig()
        {
            cmbCompres.DataSource = null;
            cmbFormat.DataSource = null;
            cmbPixelType.DataSource = null;
            cmbRes.DataSource = null;

            ChkDuplex.Checked = false;
            ChkDuplex.Visible = false;

            cmbCompres.Items.Clear();
            cmbFormat.Items.Clear();
            cmbPixelType.Items.Clear();
            cmbRes.Items.Clear();
        }

        private void cmbScanners_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!LoadingScanners)
            {
                if (cmbScanners.SelectedIndex >= 0)
                {
                    ParCombo p = cmbScanners.SelectedItem as ParCombo;
                    GetSourceConfig(p.Display);
                }
            }

        }

        private void cmbRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRes.SelectedIndex >= 0)
            {
                ParCombo p = cmbRes.SelectedItem as ParCombo;
                SetResolution(int.Parse(p.Value));
            }

        }

        private void cmbPixelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPixelType.SelectedIndex >= 0)
            {
                ParCombo p = cmbPixelType.SelectedItem as ParCombo;
                TwainPixelType pt = (TwainPixelType)int.Parse(p.Value);
                SetPixelType(pt);
            }
        }

        private void cmbFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormat.SelectedIndex >= 0)
            {
                ParCombo p = cmbFormat.SelectedItem as ParCombo;
                TwainImageFileFormats format = (TwainImageFileFormats)int.Parse(p.Value);
                SetFileFormat(format);
            }
        }

        private void btnCameraAquire_Click(object sender, EventArgs e)
        {
            AllowAquire = this.cmbScanners.Items.Count > 0;
            if (AllowAquire)
            {
                Aquire();
            }
            else
            {
                UIHelper.ShowNotification("Debe tener un lote en estado abierto", ToolTipIcon.Warning);
            }

        }

        private void DisplayCaptureError(ImportResult r)
        {
            string err = "";
            foreach (string e1 in r.Errors)
            {
                err += e1 + "\r\n";
                Debug.Print($"Err ---------> {e1}");
            }

            if (err != "")
            {
                err = err.TrimEnd('\n');
                err = err.TrimEnd('\r');
            }

            UIHelper.ShowNotification($"Ocurrió un error al realizar la captura: {err}", ToolTipIcon.Error);
        }

        private void C_PageAdded(object sender, Events.PageAddedEventArgs e)
        {
            if (!e.DemoMode && jobExplorer!=null)
            {
               jobExplorer.AppendPage(e.PagePath);
            }
            else
            {

                this.documentViewer.ShowImage(e.PagePath, (e.DeviceIndex + 1));

            }
        }

        private void Aquire()
        {
            UIHelper.ShowNotification("Iniciando captura", ToolTipIcon.Info);
            capturando = true;
            AjustaBotonera();
            if (InSession)
            {
                g.TwainCloseSource();
            }

            var config = GetConfigFrom();
            if (config == null)
            {
                UIHelper.ShowNotification("La configuración no es válida", ToolTipIcon.Warning);
                return;
            }

            
            //controller = CompositionRoot.Resolve<TWAINController>();
            controller.handle = this.h;
            controller.config = config;

            controller.PageAdded += C_PageAdded; ;
            controller.DoEvents += Controller_DoEvents;
            //UIHelper.Wait(false);

            var r = controller.Import(false, DocumentId);
            if (!r.DoneOK) DisplayCaptureError(r);


            //UIHelper.WaitCancel();
            controller.PageAdded -= C_PageAdded;
            controller.DoEvents -= Controller_DoEvents;

            //controller = null;

            // this.BringToFront();

            if(Form1.Instance.CheckPageInsert())
            {

            }

            OnImportEnded(new EventArgs());
            UIHelper.ShowNotification("Captura finalizada", ToolTipIcon.Info);
            capturando = false;
            AjustaBotonera();
        }

        private void Controller_DoEvents(object sender, EventArgs e)
        {
            Application.DoEvents();
        }

        private TWAINConfig GetConfigFrom()
        {
            TWAINConfig c = new TWAINConfig();
            ParCombo pc;

            if (cmbScanners.SelectedIndex < 0)
            {
                return null;
            }


            if (cmbRes.SelectedIndex < 0)
            {
                return null;
            }

            if (cmbFormat.SelectedIndex < 0)
            {
                return null;
            }

            if (cmbCompres.SelectedIndex < 0)
            {
                return null;
            }


            if (cmbPixelType.SelectedIndex < 0)
            {
                return null;
            }

            pc = cmbFormat.SelectedItem as ParCombo;
            c.ImageFormat = (TwainImageFileFormats)(int.Parse(pc.Value));

            pc = cmbCompres.SelectedItem as ParCombo;
            c.Compression = (TwainCompression)(int.Parse(pc.Value));

            pc = cmbPixelType.SelectedItem as ParCombo;
            c.PixelType = (TwainPixelType)(int.Parse(pc.Value));

            c.Duplex = false;
            if (ChkDuplex.Visible && ChkDuplex.Checked)
            {
                c.Duplex = true;
            }


            c.AutoOrientation = chkOrientar.Checked;

            pc = cmbScanners.SelectedItem as ParCombo;
            c.Source = pc.Display;

            pc = cmbRes.SelectedItem as ParCombo;
            c.Resolution = int.Parse(pc.Value);

            return c;
        }



        private void pbStop_Click(object sender, EventArgs e)
        {
            if (controller != null)
            {
                controller.CancelImport();
            }
            pbStop.Visible = false;
        }

        private async void pbSend_Click(object sender, EventArgs e)
        {
            try
            {
                var servicio = new UploadApi();

                var paginas = new List<PaginaPika>();
                foreach (var p in Form1.documento.Paginas)
                {
                    paginas.Add(new PaginaPika()
                    {
                        Ruta = Path.Combine(Form1.documento.Path, p.Name),
                    });
                }

                await servicio.EnviarPaginas(paginas, Form1.scanner);

            }
            catch (Exception)
            {
                
            }
        }
    }
}
