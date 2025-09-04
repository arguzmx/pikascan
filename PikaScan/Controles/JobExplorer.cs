using PikaScan.Events;
using PikaScan.Modelo;
using PikaScan.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using System.Reflection;

namespace PikaScan.Controles
{
    public partial class JobExplorer : UserControl
    {

        public delegate void SelectedDocumentEventHandler(object sender, DocumentSelectedEventArgs e);

        public event SelectedDocumentEventHandler SelectedDocumentEvent;

        protected virtual void OnSelectedDocument(Documento d)
        {
            DocumentSelectedEventArgs e = new DocumentSelectedEventArgs()
            {
                document = d
            };
            SelectedDocumentEventHandler handler = SelectedDocumentEvent;
            handler?.Invoke(this, e);
        }


        public delegate void SelectedBatchEventHandler(object sender, BatchSelectedEventArgs e);

        public event SelectedBatchEventHandler SelectedBatchEvent;

        protected virtual void OnSelectedBatch(Lote l)
        {
            BatchSelectedEventArgs e = new BatchSelectedEventArgs()
            {
                batch = l
            };
            SelectedBatchEventHandler handler = SelectedBatchEvent;
            handler?.Invoke(this, e);
        }


        private ILotesService lotesService;
        private IAppSettings appSettings;
        private IDocumentService documentService;
        private Lote lote;
        private Documento documento;

        public DocumentViewer documentViewer { get; set; }
        public MainMenu mainMenu { get; set; }

        public JobExplorer()
        {
            InitializeComponent();
            try
            {
                this.lotesService = CompositionRoot.Resolve<ILotesService>();
                this.documentService = CompositionRoot.Resolve<IDocumentService>();
                appSettings = CompositionRoot.Resolve<IAppSettings>();
            }
            catch (Exception ex)
            {
            }
        }


        public void ShowTailPages()
        {


            if (ImLvThumbs.Items != null && ImLvThumbs.Items.Count > 0)
            {
                int k = ImLvThumbs.Items.Count - this.documentViewer.DisplayCount;
                if (k < 0)
                {
                    k = 0;
                }

                ImLvThumbs.ClearSelection();
                ImLvThumbs.Items[k].Selected = true;
                ImLvThumbs.EnsureVisible(k);
                ImLvThumbs.Focus();
            }

            this.DisplayImages();


        }

        public void DetallesLote()
        {

            //if (lote != null)
            //{

            //    LoteEdit l = new LoteEdit(lote.Id, CompositionRoot.Resolve<ILotesService>());
            //    if (l.ShowDialog() == DialogResult.OK)
            //    {
            //        if (l.Modified)
            //        {

            //            this.lblJobName.Text = l.lote.Nombre;
            //        }

            //        l.Dispose();
            //    }

            //}
            //else
            //{

            //    UIHelper.ShowNotification("Debe tener un lote abierto", ToolTipIcon.Warning);

            //}

        }




        public void ClearJob()
        {
            lblJobName.Text = "";
            TvDocuments.Nodes.Clear();
            ImLvThumbs.Items.Clear();
            documento = null;
            lote = null;
            OnSelectedBatch(null);
            OnSelectedDocument(null);
            this.documentViewer.ClearPorts();
            this.pbInfo.Image = global::PikaScan.Properties.Resources.box_empty_48;
            //mainMenu.EditEnabled = false;
            //Program.MainForm.SetAquireStatus(false);
        }

        public void AppendPage(string path)
        {
            Manina.Windows.Forms.ImageListViewItem item = new Manina.Windows.Forms.ImageListViewItem(path);
            FileInfo fi = new FileInfo(path);
            Pagina p = new Pagina() { Name = fi.Name };
            item.Tag = p;
            ImLvThumbs.Items.Add(item);
        }

        public void AddDocument()
        {

            //if (lote == null)
            //{
            //    UIHelper.ShowNotification($"No hay un lote seleccionado", ToolTipIcon.Warning);
            //    return;
            //}

            //IDocumentService dsercv = CompositionRoot.Resolve<IDocumentService>();
            //ILotesService lserv = CompositionRoot.Resolve<ILotesService>();
            //AddDoc addDoc = new AddDoc(lote.Id, dsercv, lserv);


            //if (addDoc.ShowDialog() == DialogResult.OK)
            //{
            //    AddDocNode(addDoc.nuevoDocumento, true);
            //    Showdocument(addDoc.nuevoDocumento);
            //    OnSelectedDocument(addDoc.nuevoDocumento);
            //}

            //addDoc.Dispose();
        }


        public void ShowDocInfo()
        {
            //if (documento != null)
            //{
            //    DocInfo di = new DocInfo(documento.Id,
            //        CompositionRoot.Resolve<IDocumentService>(),
            //        CompositionRoot.Resolve<IPageService>());

            //    if (di.ShowDialog() == DialogResult.OK)
            //    {
            //        TvDocuments.SelectedNode.Text = di.d.Nombre;
            //    }

            //    di.Dispose();
            //    di = null;
            //}
        }


        public void DelDoc()
        {
            if (documento != null)
            {

                if (UIHelper.Confirm($"¿Desea eliminar el documento {GetDocSelected().Nombre} \r\n de manera permanente?") == DialogResult.No)
                    return;

                IDocumentService dsercv = CompositionRoot.Resolve<IDocumentService>();
                try
                {
                    dsercv.Delete(documento.Id);
                    TvDocuments.Nodes.Remove(TvDocuments.SelectedNode);
                    this.ImLvThumbs.Items.Clear();
                    documento = null;
                    OnSelectedDocument(null);
                    UIHelper.ShowNotification("El documento ha sido eliminado", ToolTipIcon.Info);
                }
                catch (Exception ex)
                {

                    UIHelper.ShowNotification($"Error al eliminar documento: {ex.Message}", ToolTipIcon.Error);
                }
            }
            else
            {
                UIHelper.ShowNotification("Debe seleccionar un documento", ToolTipIcon.Warning);
            }
        }

        public void Showdocument(Documento d)
        {
            this.documentViewer.ClearPorts();
            documento = d;

            if (d == null)
            {
                return;
            }

            try
            {
                this.ImLvThumbs.Items.Clear();
                if (!Directory.Exists(d.Path))
                {
                    Directory.CreateDirectory(d.Path);
                }


                string cachedir = Path.Combine(d.Path, "cache");
                if (!Directory.Exists(cachedir))
                {
                    Directory.CreateDirectory(cachedir);
                }

                ImLvThumbs.PersistentCacheDirectory = cachedir;

                PopulateListView(d);


            }
            catch (Exception ex)
            {
                UIHelper.ShowNotification($"Error al abrir documento {ex.Message}", ToolTipIcon.Error);
            }
        }

        public void PopulateListView(Documento doc)
        {


            // this.imageEditor = Imeditor01;

            ImLvThumbs.ClearThumbnailCache();
            ImLvThumbs.Items.Clear();
            ImLvThumbs.SuspendLayout();



            foreach (Pagina p in doc.Paginas)
            {
                if (p.Name.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) ||
                    p.Name.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    p.Name.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                    p.Name.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                    p.Name.EndsWith(".ico", StringComparison.OrdinalIgnoreCase) ||
                    p.Name.EndsWith(".cur", StringComparison.OrdinalIgnoreCase) ||
                    p.Name.EndsWith(".emf", StringComparison.OrdinalIgnoreCase) ||
                    p.Name.EndsWith(".wmf", StringComparison.OrdinalIgnoreCase) ||
                    p.Name.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) ||
                    p.Name.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase) ||
                    p.Name.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                {

                    string path = Path.Combine(doc.Path, p.Name);
                    Manina.Windows.Forms.ImageListViewItem item = new Manina.Windows.Forms.ImageListViewItem(path);
                    item.Tag = p;
                    ImLvThumbs.Items.Add(item);
                }
            }
            ImLvThumbs.ResumeLayout();
        }


        public bool ShowJob(string Id)
        {
            ClearJob();
            //try
            //{

            //    lote = lotesService.Get(Id);
            //    if (lote == null)
            //    {
            //        UIHelper.ShowNotification($"El lote solicitado no existe", ToolTipIcon.Warning);
            //        return false;
            //    }

            //    this.lblJobName.Text = lote.Nombre;
            //    this.TvDocuments.Nodes.Clear();
            //    ImLvThumbs.Items.Clear();

            //    if (lote.EstadoTrabajo == EstadoTrabajo.Abierto)
            //    {
            //        Program.MainForm.SetAquireStatus(true);
            //        mainMenu.EditEnabled = true;
            //        this.pbInfo.Image = global::ACanon.Properties.Resources.box_open_48;
            //    }
            //    else
            //    {

            //        Program.MainForm.SetAquireStatus(false);
            //        mainMenu.EditEnabled = false;
            //        this.pbInfo.Image = global::ACanon.Properties.Resources.box_closed_48;
            //    }

            //    if (!Directory.Exists(lote.Path))
            //    {
            //        Directory.CreateDirectory(lote.Path);
            //    }

            //    List<Documento> Documentos = documentService.Get(x => x.IdLote == Id, y => (y.OrderBy(z => z.Indice))).ToList();

            //    foreach (var doc in Documentos)
            //    {
            //        AddDocNode(doc);
            //    }
            //    OnSelectedBatch(lote);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    UIHelper.ShowNotification($"El lote solicitado no pudo ser mostrado: {ex.Message}", ToolTipIcon.Error);
            //    return false;
            //}
            return true;

        }

        private void AddDocNode(Documento d, bool select = false)
        {
            TreeNode tn = new TreeNode($"{d.Nombre}");
            tn.Tag = d;
            TvDocuments.Nodes.Add(tn);

            if (select)
            {
                TvDocuments.SelectedNode = tn;
            }
        }

        public Documento GetDocSelected()
        {
            if (TvDocuments.SelectedNode != null)
            {
                return (Documento)TvDocuments.SelectedNode.Tag;
            }
            else
            {
                return null;
            }
        }

        private void TvDocuments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OnSelectedDocument(GetDocSelected());
            Showdocument(GetDocSelected());
        }

        private void TvDocuments_DoubleClick(object sender, EventArgs e)
        {
            ShowDocInfo();
        }


        private void JobExplorer_Load(object sender, EventArgs e)
        {

        }

        private void ImLvThumbs_ItemClick(object sender, Manina.Windows.Forms.ItemClickEventArgs e)
        {
            //SetImages(ImLvThumbs.SelectedItems[0].Index);
            DisplayImages();
        }

        private void RaiseLastSelectedItem()
        {
            if (bntInsertMode.Checked)
            {
                if (ImLvThumbs.CheckedItems.Count > 0)
                {
                    Pagina pag = ImLvThumbs.CheckedItems[ImLvThumbs.CheckedItems.Count -1 ].Tag as Pagina;
                    string last = string.Empty;
                    if (Form1.documento.Paginas.Count > 0)
                    {
                        last = Form1.documento.Paginas.Last().Name;
                    }
                    Form1.Instance.SetInsertAfter(pag.Name, last);
                }
                else
                {
                    Form1.Instance.SetInsertAfter(string.Empty, string.Empty);
                }

            }
            else
            {
                Form1.Instance.SetInsertAfter(string.Empty, string.Empty);
            }
        }

        public void UncheckAllPAges()
        {

            this.ImLvThumbs.UncheckAll();

        }
        public void CheckAllPAges()
        {

            this.ImLvThumbs.CheckAll();

        }

        public void InvertCheckPAges()
        {

            this.ImLvThumbs.InvertCheckState();

        }



        public void DelLote()
        {
            if (this.lote != null)
            {

                ILotesService repo = CompositionRoot.Resolve<ILotesService>();

                if (UIHelper.Confirm($"¿Desea eliminar de manera permanente el lote actual?") == DialogResult.Yes)
                {
                    try
                    {
                        repo.Delete(lote.Id);
                        ClearJob();
                        UIHelper.ShowNotification("El lote ha sido eliminado", ToolTipIcon.Info);
                    }
                    catch (Exception ex)
                    {

                        UIHelper.ShowNotification($"Error al eliminar lote {ex.Message}", ToolTipIcon.Error);
                    }

                }
            }
            else
            {
                UIHelper.ShowNotification("Debe abrir el lote para eliminar", ToolTipIcon.Warning);
            }
        }

        public void DelPaginas()
        {
            List<Pagina> Paginas = new List<Pagina>();
            foreach (var item in ImLvThumbs.CheckedItems)
            {
                Paginas.Add((Pagina)(item.Tag));
            }

            if (UIHelper.Confirm($"¿Desea eliminar de manera permanente las páginas seleccionadas?") == DialogResult.Yes)
            {
                IPageService psvc = CompositionRoot.Resolve<IPageService>();
                try
                {
                    psvc.Delete(documento.Id, Paginas.Select(x => x.Name).ToList());
                    Showdocument(GetDocSelected());
                    UIHelper.ShowNotification($"Las páginas han sido eliminadas", ToolTipIcon.Info);
                }
                catch (Exception ex)
                {

                    UIHelper.ShowNotification($"Error al eliminar páginas: {ex.Message}", ToolTipIcon.Error);
                }

            }

        }
        public void DisplayImages()
        {

            if (ImLvThumbs.SelectedItems.Count == 0)
            {
                return;
            }

            int Index = ImLvThumbs.SelectedItems[0].Index;

            List<string> rutas = new List<string>();

            for (int i = 1; i <= this.documentViewer.DisplayCount; i++)
            {
                if (ImLvThumbs.Items.Count > Index)
                {
                    Pagina pag = ImLvThumbs.Items[Index].Tag as Pagina;
                    rutas.Add(Path.Combine(documento.Path, pag.Name));

                }
                else
                {
                    break;
                }
                Index++;
            }

            if (rutas.Count > 0)
            {
                this.documentViewer.ShowPages(rutas);
            }

        }

        public void CloseBatch()
        {
            if (lote == null)
            {
                UIHelper.ShowNotification("Debe tener un lote abierto", ToolTipIcon.Info);
                return;
            }

            try
            {
                if (UIHelper.Confirm($"Finalizar el proceso para {lote.Nombre}") != DialogResult.Yes)
                {

                    return;
                }

                //if (lote.TipoTrabajo == TipoTrabajo.Red)
                //{
                //    API.Pika.Client cli = CompositionRoot.Resolve<API.Pika.Client>();
                //    IAppSettings appSettings = CompositionRoot.Resolve<IAppSettings>();
                //    cli.Token = UISession.Session.Token;
                //    List<API.Pika.WSClient.ActualizacionExpediente> l = new List<API.Pika.WSClient.ActualizacionExpediente>();

                //    int index = 1;
                //    foreach (var item in documentService.Get(x => x.IdLote == lote.Id)
                //        .OrderBy(x => x.Indice).ToList())
                //    {

                //        if (string.IsNullOrEmpty(item.RemoteId))
                //        {
                //            item.RemoteId = "0";
                //        }

                //        l.Add(new API.Pika.WSClient.ActualizacionExpediente()
                //        {
                //            Codigo = item.Nombre,
                //            filecount = item.CantidadPaginas,
                //            IdExpediente = int.Parse(item.RemoteId),
                //            Indice = index,
                //            Localizacion = $"Arguz Aquire: {item.Nombre}/{lote.Nombre} @ {appSettings.HostName}",
                //            Path = ""
                //        });

                //        index++;
                //    }



                //    cli.ActualizaContenidoCaja(int.Parse(lote.RemoteId), l);
                //    cli.FinalizarProceso(int.Parse(lote.RemoteId), appSettings.IdEmpleado, lote.RemoteState, true, appSettings.PluginId);


                //}

                //this.pbInfo.Image = global::ACanon.Properties.Resources.box_closed_48;
                //lotesService.UpdateStatus(lote.Id, EstadoTrabajo.Cerrado);
                //mainMenu.EditEnabled = false;
                //Program.MainForm.SetAquireStatus(false);
                UIHelper.ShowNotification("El traajo ha sido cerrado", ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                if (UIHelper.Confirm($"Ocurrió un error al cerrar: {ex.Message}") != DialogResult.OK)
                {

                    return;
                }

            }

        }

        public void BatchOutput()
        {

            //if (lote == null)
            //{
            //    UIHelper.ShowNotification("Debe tener un lote abierto", ToolTipIcon.Info);
            //    return;
            //}

            //IPluginDefaultService pluginDefaultService = CompositionRoot.Resolve<IPluginDefaultService>();
            //IOutputProcessService outputProcessService = CompositionRoot.Resolve<IOutputProcessService>();
            //ILotesService lotesService = CompositionRoot.Resolve<ILotesService>();

            //BatchOutput bo = new BatchOutput(lote.Id, pluginDefaultService, outputProcessService, lotesService);

            //if (bo.ShowDialog() == DialogResult.OK)
            //{
            //    UIHelper.ShowNotification("El lote ha sido añadido a la cola de proceso", ToolTipIcon.Info);
            //}
            //bo.Dispose();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.ImLvThumbs.CheckedItems.Count > 0)
            {
                var yes = MessageBox.Show("¿Desea eliminar los elemento seleccioandos de manera permanente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (yes == DialogResult.No)
                {
                    return;
                }

                Form1.Instance.RemovePages(ImLvThumbs.CheckedItems.Select(x => x.FileName).ToList());
                PopulateListView(Form1.documento);
            } else
            {

            }
        }

        private void tsLevel_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void bntInsertMode_Click(object sender, EventArgs e)
        {
            Form1.Instance.FlipTsLabelInsert(bntInsertMode.Checked);
            RaiseLastSelectedItem();

        }

        private void ImLvThumbs_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void ImLvThumbs_ItemCheckBoxClick(object sender, Manina.Windows.Forms.ItemEventArgs e)
        {
            RaiseLastSelectedItem();
        }
    }
}
