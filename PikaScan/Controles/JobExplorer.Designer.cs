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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsLevel = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ImLvThumbs = new Manina.Windows.Forms.ImageListView();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.bntInsertMode = new System.Windows.Forms.ToolStripButton();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExplorer)).BeginInit();
            this.splitContainerExplorer.Panel1.SuspendLayout();
            this.splitContainerExplorer.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tsLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerExplorer
            // 
            this.splitContainerExplorer.Location = new System.Drawing.Point(84, 167);
            this.splitContainerExplorer.Name = "splitContainerExplorer";
            // 
            // splitContainerExplorer.Panel1
            // 
            this.splitContainerExplorer.Panel1.Controls.Add(this.TvDocuments);
            this.splitContainerExplorer.Panel1MinSize = 100;
            this.splitContainerExplorer.Panel2MinSize = 100;
            this.splitContainerExplorer.Size = new System.Drawing.Size(416, 433);
            this.splitContainerExplorer.SplitterDistance = 208;
            this.splitContainerExplorer.TabIndex = 0;
            this.splitContainerExplorer.Visible = false;
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
            this.TvDocuments.Size = new System.Drawing.Size(208, 433);
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
            this.panelInfo.Location = new System.Drawing.Point(139, 37);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(500, 60);
            this.panelInfo.TabIndex = 1;
            this.panelInfo.Visible = false;
            // 
            // lblJobName
            // 
            this.lblJobName.BackColor = System.Drawing.SystemColors.Control;
            this.lblJobName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblJobName.Location = new System.Drawing.Point(287, 0);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(213, 60);
            this.lblJobName.TabIndex = 1;
            this.lblJobName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tsLevel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 42);
            this.panel1.TabIndex = 5;
            // 
            // tsLevel
            // 
            this.tsLevel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsLevel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsLevel.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsLevel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDel,
            this.toolStripSeparator1,
            this.bntInsertMode});
            this.tsLevel.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsLevel.Location = new System.Drawing.Point(0, 0);
            this.tsLevel.Name = "tsLevel";
            this.tsLevel.Size = new System.Drawing.Size(111, 42);
            this.tsLevel.TabIndex = 5;
            this.tsLevel.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsLevel_ItemClicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // ImLvThumbs
            // 
            this.ImLvThumbs.CacheLimit = "0";
            this.ImLvThumbs.CacheMode = Manina.Windows.Forms.CacheMode.Continuous;
            this.ImLvThumbs.DefaultImage = global::PikaScan.Properties.Resources.box_open_48;
            this.ImLvThumbs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImLvThumbs.Location = new System.Drawing.Point(0, 42);
            this.ImLvThumbs.Name = "ImLvThumbs";
            this.ImLvThumbs.PersistentCacheDirectory = "";
            this.ImLvThumbs.PersistentCacheSize = ((long)(0));
            this.ImLvThumbs.ShowCheckBoxes = true;
            this.ImLvThumbs.Size = new System.Drawing.Size(500, 558);
            this.ImLvThumbs.TabIndex = 0;
            this.ImLvThumbs.UseWIC = true;
            this.ImLvThumbs.ItemClick += new Manina.Windows.Forms.ItemClickEventHandler(this.ImLvThumbs_ItemClick);
            this.ImLvThumbs.ItemCheckBoxClick += new Manina.Windows.Forms.ItemCheckBoxClickEventHandler(this.ImLvThumbs_ItemCheckBoxClick);
            this.ImLvThumbs.SelectionChanged += new System.EventHandler(this.ImLvThumbs_SelectionChanged);
            // 
            // btnDel
            // 
            this.btnDel.Image = global::PikaScan.Properties.Resources.minus_24;
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(54, 39);
            this.btnDel.Text = "Eliminar";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDel.ToolTipText = "Elimina las páginas marcadas.";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // bntInsertMode
            // 
            this.bntInsertMode.CheckOnClick = true;
            this.bntInsertMode.Image = global::PikaScan.Properties.Resources.chevron_double_down_icon;
            this.bntInsertMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bntInsertMode.Name = "bntInsertMode";
            this.bntInsertMode.Size = new System.Drawing.Size(50, 39);
            this.bntInsertMode.Text = "Insertar";
            this.bntInsertMode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bntInsertMode.ToolTipText = "Insertar las páginas en la posición en vez del al final.";
            this.bntInsertMode.Click += new System.EventHandler(this.bntInsertMode_Click);
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
            this.Controls.Add(this.ImLvThumbs);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainerExplorer);
            this.Controls.Add(this.panelInfo);
            this.Name = "JobExplorer";
            this.Size = new System.Drawing.Size(500, 600);
            this.Load += new System.EventHandler(this.JobExplorer_Load);
            this.splitContainerExplorer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerExplorer)).EndInit();
            this.splitContainerExplorer.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsLevel.ResumeLayout(false);
            this.tsLevel.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip tsLevel;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStripButton bntInsertMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
