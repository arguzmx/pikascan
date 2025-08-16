namespace PikaScan.Controles
{
    partial class TWAINCapture
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
            this.btnCameraAquire = new System.Windows.Forms.PictureBox();
            this.cmbScanners = new System.Windows.Forms.ComboBox();
            this.cmbRes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPixelType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.cmbCompres = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ChkDuplex = new System.Windows.Forms.CheckBox();
            this.pbStop = new System.Windows.Forms.PictureBox();
            this.chkOrientar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnCameraAquire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCameraAquire
            // 
            this.btnCameraAquire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCameraAquire.Image = global::PikaScan.Properties.Resources.source_play_disabled_64;
            this.btnCameraAquire.Location = new System.Drawing.Point(396, 28);
            this.btnCameraAquire.Name = "btnCameraAquire";
            this.btnCameraAquire.Size = new System.Drawing.Size(70, 70);
            this.btnCameraAquire.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCameraAquire.TabIndex = 15;
            this.btnCameraAquire.TabStop = false;
            this.btnCameraAquire.Click += new System.EventHandler(this.btnCameraAquire_Click);
            // 
            // cmbScanners
            // 
            this.cmbScanners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScanners.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbScanners.FormattingEnabled = true;
            this.cmbScanners.Location = new System.Drawing.Point(19, 18);
            this.cmbScanners.Name = "cmbScanners";
            this.cmbScanners.Size = new System.Drawing.Size(176, 24);
            this.cmbScanners.TabIndex = 14;
            this.cmbScanners.SelectedIndexChanged += new System.EventHandler(this.cmbScanners_SelectedIndexChanged);
            // 
            // cmbRes
            // 
            this.cmbRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbRes.FormattingEnabled = true;
            this.cmbRes.Location = new System.Drawing.Point(114, 49);
            this.cmbRes.Name = "cmbRes";
            this.cmbRes.Size = new System.Drawing.Size(80, 24);
            this.cmbRes.TabIndex = 16;
            this.cmbRes.SelectedIndexChanged += new System.EventHandler(this.cmbRes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Resolución";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Color";
            // 
            // cmbPixelType
            // 
            this.cmbPixelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPixelType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPixelType.FormattingEnabled = true;
            this.cmbPixelType.Location = new System.Drawing.Point(114, 79);
            this.cmbPixelType.Name = "cmbPixelType";
            this.cmbPixelType.Size = new System.Drawing.Size(80, 24);
            this.cmbPixelType.TabIndex = 18;
            this.cmbPixelType.SelectedIndexChanged += new System.EventHandler(this.cmbPixelType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Formato";
            // 
            // cmbFormat
            // 
            this.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Location = new System.Drawing.Point(294, 18);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(75, 24);
            this.cmbFormat.TabIndex = 20;
            this.cmbFormat.SelectedIndexChanged += new System.EventHandler(this.cmbFormat_SelectedIndexChanged);
            // 
            // cmbCompres
            // 
            this.cmbCompres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompres.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCompres.FormattingEnabled = true;
            this.cmbCompres.Location = new System.Drawing.Point(294, 49);
            this.cmbCompres.Name = "cmbCompres";
            this.cmbCompres.Size = new System.Drawing.Size(75, 24);
            this.cmbCompres.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Compresión";
            // 
            // ChkDuplex
            // 
            this.ChkDuplex.AutoSize = true;
            this.ChkDuplex.Location = new System.Drawing.Point(294, 82);
            this.ChkDuplex.Name = "ChkDuplex";
            this.ChkDuplex.Size = new System.Drawing.Size(71, 20);
            this.ChkDuplex.TabIndex = 22;
            this.ChkDuplex.Text = "Duplex";
            this.ChkDuplex.UseVisualStyleBackColor = true;
            // 
            // pbStop
            // 
            this.pbStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStop.Image = global::PikaScan.Properties.Resources.Stop_Pressed_Blue_64;
            this.pbStop.Location = new System.Drawing.Point(396, 6);
            this.pbStop.Name = "pbStop";
            this.pbStop.Size = new System.Drawing.Size(70, 70);
            this.pbStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStop.TabIndex = 23;
            this.pbStop.TabStop = false;
            this.pbStop.Click += new System.EventHandler(this.pbStop_Click);
            // 
            // chkOrientar
            // 
            this.chkOrientar.AutoSize = true;
            this.chkOrientar.Location = new System.Drawing.Point(202, 82);
            this.chkOrientar.Name = "chkOrientar";
            this.chkOrientar.Size = new System.Drawing.Size(76, 20);
            this.chkOrientar.TabIndex = 24;
            this.chkOrientar.Text = "Orientar";
            this.chkOrientar.UseVisualStyleBackColor = true;
            this.chkOrientar.Visible = false;
            // 
            // TWAINCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkOrientar);
            this.Controls.Add(this.btnCameraAquire);
            this.Controls.Add(this.pbStop);
            this.Controls.Add(this.ChkDuplex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCompres);
            this.Controls.Add(this.cmbFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPixelType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRes);
            this.Controls.Add(this.cmbScanners);
            this.Name = "TWAINCapture";
            this.Size = new System.Drawing.Size(547, 114);
            this.Load += new System.EventHandler(this.TWAINCapture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnCameraAquire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnCameraAquire;
        private System.Windows.Forms.ComboBox cmbScanners;
        private System.Windows.Forms.ComboBox cmbRes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPixelType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.ComboBox cmbCompres;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ChkDuplex;
        private System.Windows.Forms.PictureBox pbStop;
        private System.Windows.Forms.CheckBox chkOrientar;
    }
}
