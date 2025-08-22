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
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.twainCapture1 = new PikaScan.Controles.TWAINCapture();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Margin = new System.Windows.Forms.Padding(2);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbVisible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(600, 76);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Text = "ribbon";
            // 
            // twainCapture1
            // 
            this.twainCapture1.AllowAquire = false;
            this.twainCapture1.DocumentId = null;
            this.twainCapture1.documentViewer = null;
            this.twainCapture1.jobExplorer = null;
            this.twainCapture1.Location = new System.Drawing.Point(82, 136);
            this.twainCapture1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.twainCapture1.Name = "twainCapture1";
            this.twainCapture1.Size = new System.Drawing.Size(410, 93);
            this.twainCapture1.TabIndex = 1;
            this.twainCapture1.Load += new System.EventHandler(this.twainCapture1_Load);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Prueba";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 487);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.twainCapture1);
            this.Controls.Add(this.ribbon1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "PikaScan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private Controles.TWAINCapture twainCapture1;
        private System.Windows.Forms.Button button1;
    }
}

