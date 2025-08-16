using System;

namespace PikaScan.Controles
{
    partial class DocumentViewer
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
            this.ImEditor01 = new ImageEditor();
            this.ImEditor02 = new ImageEditor();
            this.ImEditor03 = new ImageEditor();
            this.ImEditor04 = new ImageEditor();
            this.ImEditor08 = new ImageEditor();
            this.ImEditor07 = new ImageEditor();
            this.ImEditor06 = new ImageEditor();
            this.ImEditor05 = new ImageEditor();
            this.SuspendLayout();
            // 
            // ImEditor01
            // 
            this.ImEditor01.ImageIndex = 0;
            this.ImEditor01.Location = new System.Drawing.Point(34, 31);
            this.ImEditor01.Name = "ImEditor01";
            this.ImEditor01.ShowCalibrationRectangle = false;
            this.ImEditor01.Size = new System.Drawing.Size(159, 168);
            this.ImEditor01.TabIndex = 0;
            this.ImEditor01.Tag = "1";
            // 
            // ImEditor02
            // 
            this.ImEditor02.ImageIndex = 0;
            this.ImEditor02.Location = new System.Drawing.Point(199, 31);
            this.ImEditor02.Name = "ImEditor02";
            this.ImEditor02.ShowCalibrationRectangle = false;
            this.ImEditor02.Size = new System.Drawing.Size(159, 168);
            this.ImEditor02.TabIndex = 1;
            this.ImEditor02.Tag = "2";
            // 
            // ImEditor03
            // 
            this.ImEditor03.ImageIndex = 0;
            this.ImEditor03.Location = new System.Drawing.Point(364, 31);
            this.ImEditor03.Name = "ImEditor03";
            this.ImEditor03.ShowCalibrationRectangle = false;
            this.ImEditor03.Size = new System.Drawing.Size(159, 168);
            this.ImEditor03.TabIndex = 2;
            this.ImEditor03.Tag = "3";
            // 
            // ImEditor04
            // 
            this.ImEditor04.ImageIndex = 0;
            this.ImEditor04.Location = new System.Drawing.Point(529, 31);
            this.ImEditor04.Name = "ImEditor04";
            this.ImEditor04.ShowCalibrationRectangle = false;
            this.ImEditor04.Size = new System.Drawing.Size(159, 168);
            this.ImEditor04.TabIndex = 3;
            this.ImEditor04.Tag = "4";
            // 
            // ImEditor08
            // 
            this.ImEditor08.ImageIndex = 0;
            this.ImEditor08.Location = new System.Drawing.Point(529, 219);
            this.ImEditor08.Name = "ImEditor08";
            this.ImEditor08.ShowCalibrationRectangle = false;
            this.ImEditor08.Size = new System.Drawing.Size(159, 168);
            this.ImEditor08.TabIndex = 7;
            this.ImEditor08.Tag = "8";
            // 
            // ImEditor07
            // 
            this.ImEditor07.ImageIndex = 0;
            this.ImEditor07.Location = new System.Drawing.Point(364, 219);
            this.ImEditor07.Name = "ImEditor07";
            this.ImEditor07.ShowCalibrationRectangle = false;
            this.ImEditor07.Size = new System.Drawing.Size(159, 168);
            this.ImEditor07.TabIndex = 6;
            this.ImEditor07.Tag = "7";
            // 
            // ImEditor06
            // 
            this.ImEditor06.ImageIndex = 0;
            this.ImEditor06.Location = new System.Drawing.Point(199, 219);
            this.ImEditor06.Name = "ImEditor06";
            this.ImEditor06.ShowCalibrationRectangle = false;
            this.ImEditor06.Size = new System.Drawing.Size(159, 168);
            this.ImEditor06.TabIndex = 5;
            this.ImEditor06.Tag = "6";
            // 
            // ImEditor05
            // 
            this.ImEditor05.ImageIndex = 0;
            this.ImEditor05.Location = new System.Drawing.Point(34, 219);
            this.ImEditor05.Name = "ImEditor05";
            this.ImEditor05.ShowCalibrationRectangle = false;
            this.ImEditor05.Size = new System.Drawing.Size(159, 168);
            this.ImEditor05.TabIndex = 4;
            this.ImEditor05.Tag = "5";
            // 
            // DocumentViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ImEditor08);
            this.Controls.Add(this.ImEditor07);
            this.Controls.Add(this.ImEditor06);
            this.Controls.Add(this.ImEditor05);
            this.Controls.Add(this.ImEditor04);
            this.Controls.Add(this.ImEditor03);
            this.Controls.Add(this.ImEditor02);
            this.Controls.Add(this.ImEditor01);
            this.Name = "DocumentViewer";
            this.Size = new System.Drawing.Size(753, 453);
            this.Load += new System.EventHandler(this.DocumentViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ImageEditor ImEditor01;
        private ImageEditor ImEditor02;
        private ImageEditor ImEditor03;
        private ImageEditor ImEditor04;
        private ImageEditor ImEditor08;
        private ImageEditor ImEditor07;
        private ImageEditor ImEditor06;
        private ImageEditor ImEditor05;
    }
}
