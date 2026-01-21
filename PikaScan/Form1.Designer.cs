namespace PikaScan
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.twainCapture1 = new PikaScan.Controles.TWAINCapture();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsbLogs = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsLabelInsert = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLAbel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressSend = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.jobExplorer1 = new PikaScan.Controles.JobExplorer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.documentViewer1 = new PikaScan.Controles.DocumentViewer();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.twainCapture1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1144, 106);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // twainCapture1
            // 
            this.twainCapture1.AllowAquire = false;
            this.twainCapture1.DocumentId = null;
            this.twainCapture1.documentViewer = null;
            this.twainCapture1.jobExplorer = null;
            this.twainCapture1.Location = new System.Drawing.Point(6, 11);
            this.twainCapture1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.twainCapture1.Name = "twainCapture1";
            this.twainCapture1.Size = new System.Drawing.Size(800, 90);
            this.twainCapture1.TabIndex = 1;
            this.twainCapture1.Load += new System.EventHandler(this.twainCapture1_Load);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLogs,
            this.tsLabelInsert,
            this.tsLAbel,
            this.tsProgressSend});
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1144, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsbLogs
            // 
            this.tsbLogs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLogs.Image = global::PikaScan.Properties.Resources.Info_321;
            this.tsbLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLogs.Name = "tsbLogs";
            this.tsbLogs.Size = new System.Drawing.Size(33, 24);
            this.tsbLogs.Text = "toolStripDropDownButton1";
            this.tsbLogs.Click += new System.EventHandler(this.tsbLogs_Click);
            // 
            // tsLabelInsert
            // 
            this.tsLabelInsert.Image = global::PikaScan.Properties.Resources.chevron_double_down_icon;
            this.tsLabelInsert.Name = "tsLabelInsert";
            this.tsLabelInsert.Size = new System.Drawing.Size(101, 21);
            this.tsLabelInsert.Text = "Modo Insertar";
            this.tsLabelInsert.Visible = false;
            // 
            // tsLAbel
            // 
            this.tsLAbel.Name = "tsLAbel";
            this.tsLAbel.Size = new System.Drawing.Size(71, 21);
            this.tsLAbel.Text = "Pikascan 1.2";
            // 
            // tsProgressSend
            // 
            this.tsProgressSend.Name = "tsProgressSend";
            this.tsProgressSend.Size = new System.Drawing.Size(100, 20);
            this.tsProgressSend.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 106);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.jobExplorer1);
            this.splitContainer1.Panel1MinSize = 125;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1144, 467);
            this.splitContainer1.SplitterDistance = 125;
            this.splitContainer1.TabIndex = 6;
            // 
            // jobExplorer1
            // 
            this.jobExplorer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jobExplorer1.documentViewer = null;
            this.jobExplorer1.Location = new System.Drawing.Point(0, 0);
            this.jobExplorer1.mainMenu = null;
            this.jobExplorer1.Name = "jobExplorer1";
            this.jobExplorer1.Size = new System.Drawing.Size(125, 467);
            this.jobExplorer1.TabIndex = 5;
            this.jobExplorer1.Load += new System.EventHandler(this.jobExplorer1_Load);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.documentViewer1);
            this.panel1.Controls.Add(this.txtLogs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 467);
            this.panel1.TabIndex = 1;
            // 
            // documentViewer1
            // 
            this.documentViewer1.BgColor = System.Drawing.Color.Black;
            this.documentViewer1.DisplayCount = 1;
            this.documentViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentViewer1.documento = null;
            this.documentViewer1.Location = new System.Drawing.Point(0, 0);
            this.documentViewer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.documentViewer1.Name = "documentViewer1";
            this.documentViewer1.Size = new System.Drawing.Size(1015, 319);
            this.documentViewer1.TabIndex = 0;
            this.documentViewer1.Load += new System.EventHandler(this.documentViewer1_Load);
            // 
            // txtLogs
            // 
            this.txtLogs.BackColor = System.Drawing.SystemColors.Window;
            this.txtLogs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLogs.Location = new System.Drawing.Point(0, 319);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogs.Size = new System.Drawing.Size(1015, 148);
            this.txtLogs.TabIndex = 1;
            this.txtLogs.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1144, 599);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PikaScan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controles.TWAINCapture twainCapture1;
        private Controles.DocumentViewer documentViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Controles.JobExplorer jobExplorer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripStatusLabel tsLabelInsert;
        public System.Windows.Forms.ToolStripStatusLabel tsLAbel;
        public System.Windows.Forms.ToolStripProgressBar tsProgressSend;
        private System.Windows.Forms.ToolStripDropDownButton tsbLogs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtLogs;
    }
}

