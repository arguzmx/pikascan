using PikaScan.Events;
using PikaScan.Modelo;
using System;
using System.IO;
using System.Windows.Forms;

namespace PikaScan.Servicios
{
    public class IOController: IDisposable
    {

        public event EventHandler DoEvents;

        protected virtual void OnDoEvents()
        {
            EventHandler handler = DoEvents;
            handler?.Invoke(this, new EventArgs());
        }


        public delegate void EndImportEventHandler(object sender, bool e);

        public event EndImportEventHandler EndImport;

        protected virtual void OnEndImport()
        {
            EndImportEventHandler handler = EndImport;
            handler?.Invoke(this, true);
        }

        public delegate void PageAddedEventHandler(object sender, PageAddedEventArgs e);

        public event PageAddedEventHandler PageAdded;

        protected virtual void OnPageAdded(Pagina pagina, string path, int DeviceIndex, bool demoMode)
        {
            PageAddedEventArgs e = new PageAddedEventArgs() { pagina= pagina, PagePath= path, 
                 DemoMode = demoMode, DeviceIndex= DeviceIndex };
            PageAddedEventHandler handler = PageAdded;
            handler?.Invoke(this, e);
        }


        protected readonly IDocumentService documentService;
        protected readonly IPageService pageService;
        protected readonly IAppSettings appSettings;
        protected ImageProcessorService ip;
        protected bool isDemoMode = false;

        public IOController(IDocumentService documentService, 
            IPageService pageService, 
            IAppSettings appSettings)
        {

            this.pageService = pageService;
            this.appSettings = appSettings;
            this.documentService = documentService;
            ip = new ImageProcessorService();
        }

        public virtual void Dispose()
        {
            
        }

        public virtual ImportResult Import(bool isDemoMode, string DocumentId) {
            return null;
        }

        public virtual void CancelImport()
        {
            
        }

        protected void AddPage(FileInfo fi, Documento d, SourceType sType, int DevIndex, bool demoMode, int Rotation)
        {

               bool retry = true;
                int count = 0;
                while (retry)
                {
                    if (File.Exists(fi.FullName))
                    {
                        retry = false;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(250);
                        count++;
                        if (count > 5)
                        {
                            retry = false;
                        }
                    }
                }


            if (isDemoMode)
            {
                string newname = fi.FullName.Replace("TEST-CAM", "TCAM-");
                File.Copy(fi.FullName, newname, true);
                OnPageAdded(null, newname, DevIndex, demoMode);
            }
            else {
                ImageInfo info = ip.GetImageInfo(fi.FullName);
                if (info != null)
                {
                    int nextPage = pageService.GetNextPageIndex(d.Id);

                    Pagina pag = new Pagina(d.Id);
                    pag.Extension = fi.Extension;
                    pag.Index = nextPage;
                    pag.Size = (int)fi.Length;
                    
                    string FileName = Path.Combine(d.Path, pag.GetNameFromIndex());

                    File.Copy(fi.FullName, FileName, true);
                    if (Rotation != 0) {
                        ip.Rotate(FileName, Rotation);
                    }
                    pag.ColorDepth = info.ColorDepth;
                    pag.Extension = info.Extension;
                    pag.Height = info.Height;
                    pag.HRes = info.HRes;
                    pag.Name = pag.GetNameFromIndex();
                    pag.VRes = info.VRes;
                    pag.Width = info.Width;
                    pag.Source = sType;

                    pag = pageService.Add(pag);

                    OnPageAdded(pag, FileName, DevIndex, demoMode);
                }
                else
                {

                    throw new Exception("Formato de imagen no reconocido");
                }
            }
            


            


        }

    }
}
