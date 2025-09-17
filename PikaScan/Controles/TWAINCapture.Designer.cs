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
            this.chkOrientar = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pbSend = new System.Windows.Forms.PictureBox();
            this.btnCameraAquire = new System.Windows.Forms.PictureBox();
            this.pbStop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCameraAquire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStop)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbScanners
            // 
            this.cmbScanners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScanners.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbScanners.FormattingEnabled = true;
            this.cmbScanners.Location = new System.Drawing.Point(102, 3);
            this.cmbScanners.Margin = new System.Windows.Forms.Padding(2);
            this.cmbScanners.Name = "cmbScanners";
            this.cmbScanners.Size = new System.Drawing.Size(359, 21);
            this.cmbScanners.TabIndex = 14;
            this.cmbScanners.SelectedIndexChanged += new System.EventHandler(this.cmbScanners_SelectedIndexChanged);
            // 
            // cmbRes
            // 
            this.cmbRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbRes.FormattingEnabled = true;
            this.cmbRes.Location = new System.Drawing.Point(179, 28);
            this.cmbRes.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRes.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbRes.Name = "cmbRes";
            this.cmbRes.Size = new System.Drawing.Size(100, 21);
            this.cmbRes.TabIndex = 16;
            this.cmbRes.SelectedIndexChanged += new System.EventHandler(this.cmbRes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(99, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.MinimumSize = new System.Drawing.Size(70, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Resolución";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(99, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.MinimumSize = new System.Drawing.Size(70, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Color";
            // 
            // cmbPixelType
            // 
            this.cmbPixelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPixelType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPixelType.FormattingEnabled = true;
            this.cmbPixelType.Location = new System.Drawing.Point(179, 54);
            this.cmbPixelType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbPixelType.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbPixelType.Name = "cmbPixelType";
            this.cmbPixelType.Size = new System.Drawing.Size(100, 21);
            this.cmbPixelType.TabIndex = 18;
            this.cmbPixelType.SelectedIndexChanged += new System.EventHandler(this.cmbPixelType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(283, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.MinimumSize = new System.Drawing.Size(70, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Formato";
            // 
            // cmbFormat
            // 
            this.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.Location = new System.Drawing.Point(361, 28);
            this.cmbFormat.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFormat.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(100, 21);
            this.cmbFormat.TabIndex = 20;
            this.cmbFormat.SelectedIndexChanged += new System.EventHandler(this.cmbFormat_SelectedIndexChanged);
            // 
            // cmbCompres
            // 
            this.cmbCompres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompres.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCompres.FormattingEnabled = true;
            this.cmbCompres.Location = new System.Drawing.Point(361, 54);
            this.cmbCompres.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCompres.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbCompres.Name = "cmbCompres";
            this.cmbCompres.Size = new System.Drawing.Size(100, 21);
            this.cmbCompres.TabIndex = 20;
            this.cmbCompres.SelectedIndexChanged += new System.EventHandler(this.cmbCompres_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(283, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.MinimumSize = new System.Drawing.Size(70, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Compresión";
            // 
            // ChkDuplex
            // 
            this.ChkDuplex.AutoSize = true;
            this.ChkDuplex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChkDuplex.Location = new System.Drawing.Point(16, 55);
            this.ChkDuplex.Margin = new System.Windows.Forms.Padding(2);
            this.ChkDuplex.Name = "ChkDuplex";
            this.ChkDuplex.Size = new System.Drawing.Size(56, 17);
            this.ChkDuplex.TabIndex = 22;
            this.ChkDuplex.Text = "Duplex";
            this.ChkDuplex.UseVisualStyleBackColor = true;
            // 
            // chkOrientar
            // 
            this.chkOrientar.AutoSize = true;
            this.chkOrientar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkOrientar.Location = new System.Drawing.Point(16, 30);
            this.chkOrientar.Margin = new System.Windows.Forms.Padding(2);
            this.chkOrientar.Name = "chkOrientar";
            this.chkOrientar.Size = new System.Drawing.Size(60, 17);
            this.chkOrientar.TabIndex = 24;
            this.chkOrientar.Text = "Orientar";
            this.chkOrientar.UseVisualStyleBackColor = true;
            this.chkOrientar.Visible = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "Scanner";
            // 
            // pbSend
            // 
            this.pbSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSend.Image = global::PikaScan.Properties.Resources.bx_check_circle_icon;
            this.pbSend.Location = new System.Drawing.Point(541, 3);
            this.pbSend.Margin = new System.Windows.Forms.Padding(2);
            this.pbSend.Name = "pbSend";
            this.pbSend.Size = new System.Drawing.Size(72, 72);
            this.pbSend.TabIndex = 15;
            this.pbSend.TabStop = false;
            this.pbSend.Click += new System.EventHandler(this.pbSend_Click);
            // 
            // btnCameraAquire
            // 
            this.btnCameraAquire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCameraAquire.Image = global::PikaScan.Properties.Resources.bx_play_circle_icon;
            this.btnCameraAquire.Location = new System.Drawing.Point(465, 3);
            this.btnCameraAquire.Margin = new System.Windows.Forms.Padding(2);
            this.btnCameraAquire.Name = "btnCameraAquire";
            this.btnCameraAquire.Size = new System.Drawing.Size(72, 72);
            this.btnCameraAquire.TabIndex = 15;
            this.btnCameraAquire.TabStop = false;
            this.btnCameraAquire.Click += new System.EventHandler(this.btnCameraAquire_Click);
            // 
            // pbStop
            // 
            this.pbStop.BackColor = System.Drawing.SystemColors.Control;
            this.pbStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStop.Image = global::PikaScan.Properties.Resources.bx_stop_circle_icon;
            this.pbStop.Location = new System.Drawing.Point(465, 3);
            this.pbStop.Margin = new System.Windows.Forms.Padding(2);
            this.pbStop.Name = "pbStop";
            this.pbStop.Size = new System.Drawing.Size(72, 72);
            this.pbStop.TabIndex = 23;
            this.pbStop.TabStop = false;
            this.pbStop.Click += new System.EventHandler(this.pbStop_Click);
            // 
            // TWAINCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkOrientar);
            this.Controls.Add(this.pbSend);
            this.Controls.Add(this.btnCameraAquire);
            this.Controls.Add(this.pbStop);
            this.Controls.Add(this.ChkDuplex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCompres);
            this.Controls.Add(this.cmbFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPixelType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRes);
            this.Controls.Add(this.cmbScanners);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TWAINCapture";
            this.Size = new System.Drawing.Size(965, 97);
            this.Load += new System.EventHandler(this.TWAINCapture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSend)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbSend;
    }
}
