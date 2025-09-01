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
            this.tsLAbel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsProgressSend = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.jobExplorer1 = new PikaScan.Controles.JobExplorer();
            this.documentViewer1 = new PikaScan.Controles.DocumentViewer();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLAbel,
            this.tsProgressSend});
            this.statusStrip1.Location = new System.Drawing.Point(0, 577);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1144, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsLAbel
            // 
            this.tsLAbel.Name = "tsLAbel";
            this.tsLAbel.Size = new System.Drawing.Size(71, 17);
            this.tsLAbel.Text = "Pikascan 1.0";
            // 
            // tsProgressSend
            // 
            this.tsProgressSend.Name = "tsProgressSend";
            this.tsProgressSend.Size = new System.Drawing.Size(100, 16);
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
            this.splitContainer1.Panel2.Controls.Add(this.documentViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(1144, 471);
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
            this.jobExplorer1.Size = new System.Drawing.Size(125, 471);
            this.jobExplorer1.TabIndex = 5;
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
            this.documentViewer1.Size = new System.Drawing.Size(1015, 471);
            this.documentViewer1.TabIndex = 0;
            this.documentViewer1.Load += new System.EventHandler(this.documentViewer1_Load);
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
            this.Text = "PikaScan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controles.TWAINCapture twainCapture1;
        private Controles.DocumentViewer documentViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsLAbel;
        private System.Windows.Forms.ToolStripProgressBar tsProgressSend;
        private Controles.JobExplorer jobExplorer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

