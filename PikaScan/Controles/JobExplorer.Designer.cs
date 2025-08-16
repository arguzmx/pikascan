namespace PikaScan.Controles
{
    partial class JobExplorer
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobExplorer));
            this.splitContainerExplorer = new System.Windows.Forms.SplitContainer();
            this.TvDocuments = new System.Windows.Forms.TreeView();
            this.ImlTvDocs = new System.Windows.Forms.ImageList(this.components);
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblJobName = new System.Windows.Forms.Label();
            this.ImLvThumbs = new Manina.Windows.Forms.ImageListView();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExplorer)).BeginInit();
            this.splitContainerExplorer.Panel1.SuspendLayout();
            this.splitContainerExplorer.Panel2.SuspendLayout();
            this.splitContainerExplorer.SuspendLayout();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerExplorer
            // 
            this.splitContainerExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerExplorer.Location = new System.Drawing.Point(0, 60);
            this.splitContainerExplorer.Name = "splitContainerExplorer";
            // 
            // splitContainerExplorer.Panel1
            // 
            this.splitContainerExplorer.Panel1.Controls.Add(this.TvDocuments);
            this.splitContainerExplorer.Panel1MinSize = 100;
            // 
            // splitContainerExplorer.Panel2
            // 
            this.splitContainerExplorer.Panel2.Controls.Add(this.ImLvThumbs);
            this.splitContainerExplorer.Panel2MinSize = 100;
            this.splitContainerExplorer.Size = new System.Drawing.Size(500, 540);
            this.splitContainerExplorer.SplitterDistance = 250;
            this.splitContainerExplorer.TabIndex = 0;
            // 
            // TvDocuments
            // 
            this.TvDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TvDocuments.FullRowSelect = true;
            this.TvDocuments.HideSelection = false;
            this.TvDocuments.ImageIndex = 0;
            this.TvDocuments.ImageList = this.ImlTvDocs;
            this.TvDocuments.ItemHeight = 32;
            this.TvDocuments.Location = new System.Drawing.Point(0, 0);
            this.TvDocuments.Name = "TvDocuments";
            this.TvDocuments.SelectedImageIndex = 0;
            this.TvDocuments.Size = new System.Drawing.Size(250, 540);
            this.TvDocuments.TabIndex = 0;
            this.TvDocuments.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvDocuments_AfterSelect);
            this.TvDocuments.DoubleClick += new System.EventHandler(this.TvDocuments_DoubleClick);
            // 
            // ImlTvDocs
            // 
            this.ImlTvDocs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImlTvDocs.ImageStream")));
            this.ImlTvDocs.TransparentColor = System.Drawing.Color.Transparent;
            this.ImlTvDocs.Images.SetKeyName(0, "book-icon.png");
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.lblJobName);
            this.panelInfo.Controls.Add(this.pbInfo);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(500, 60);
            this.panelInfo.TabIndex = 1;
            // 
            // lblJobName
            // 
            this.lblJobName.BackColor = System.Drawing.SystemColors.Control;
            this.lblJobName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJobName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblJobName.Location = new System.Drawing.Point(60, 0);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(440, 60);
            this.lblJobName.TabIndex = 1;
            this.lblJobName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImLvThumbs
            // 
            this.ImLvThumbs.CacheLimit = "500MB";
            this.ImLvThumbs.DefaultImage = global::PikaScan.Properties.Resources.box_open_48;
            this.ImLvThumbs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImLvThumbs.Location = new System.Drawing.Point(0, 0);
            this.ImLvThumbs.Name = "ImLvThumbs";
            this.ImLvThumbs.PersistentCacheDirectory = "";
            this.ImLvThumbs.PersistentCacheSize = ((long)(100));
            this.ImLvThumbs.ShowCheckBoxes = true;
            this.ImLvThumbs.Size = new System.Drawing.Size(246, 540);
            this.ImLvThumbs.TabIndex = 0;
            this.ImLvThumbs.UseWIC = true;
            this.ImLvThumbs.ItemClick += new Manina.Windows.Forms.ItemClickEventHandler(this.ImLvThumbs_ItemClick);
            // 
            // pbInfo
            // 
            this.pbInfo.BackColor = System.Drawing.SystemColors.Control;
            this.pbInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbInfo.Image = global::PikaScan.Properties.Resources.box_empty_48;
            this.pbInfo.Location = new System.Drawing.Point(0, 0);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pbInfo.Size = new System.Drawing.Size(60, 60);
            this.pbInfo.TabIndex = 0;
            this.pbInfo.TabStop = false;
            // 
            // JobExplorer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainerExplorer);
            this.Controls.Add(this.panelInfo);
            this.Name = "JobExplorer";
            this.Size = new System.Drawing.Size(500, 600);
            this.Load += new System.EventHandler(this.JobExplorer_Load);
            this.splitContainerExplorer.Panel1.ResumeLayout(false);
            this.splitContainerExplorer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExplorer)).EndInit();
            this.splitContainerExplorer.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerExplorer;
        private System.Windows.Forms.TreeView TvDocuments;
        private Manina.Windows.Forms.ImageListView ImLvThumbs;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.PictureBox pbInfo;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.ImageList ImlTvDocs;
    }
}
