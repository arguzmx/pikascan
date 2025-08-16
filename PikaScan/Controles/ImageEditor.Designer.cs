namespace PikaScan.Controles
{
    partial class ImageEditor
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
            this.gdViewer1 = new GdPicture.GdViewer();
            this.PanelIndicator = new System.Windows.Forms.Panel();
            this.tsTools = new System.Windows.Forms.ToolStrip();
            this.btnZoomFit = new System.Windows.Forms.ToolStripButton();
            this.btnZommW = new System.Windows.Forms.ToolStripButton();
            this.btnZoomH = new System.Windows.Forms.ToolStripButton();
            this.btnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.btnZommOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRotateLeft = new System.Windows.Forms.ToolStripButton();
            this.btnRotateL = new System.Windows.Forms.ToolStripButton();
            this.btnRotate180 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFlipVert = new System.Windows.Forms.ToolStripButton();
            this.btnFlipHor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPan = new System.Windows.Forms.ToolStripButton();
            this.btnSelect = new System.Windows.Forms.ToolStripButton();
            this.btnCrop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnContrast = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.panelAdjust = new System.Windows.Forms.Panel();
            this.trackSaturacion = new System.Windows.Forms.TrackBar();
            this.lblContVal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsLevel = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnlevelreset = new System.Windows.Forms.ToolStripButton();
            this.btnLevelCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLevelOK = new System.Windows.Forms.ToolStripButton();
            this.lblSatVal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBrilloVal = new System.Windows.Forms.Label();
            this.lblBrillo = new System.Windows.Forms.Label();
            this.trackContraste = new System.Windows.Forms.TrackBar();
            this.trackBrillo = new System.Windows.Forms.TrackBar();
            this.trackGamma = new System.Windows.Forms.TrackBar();
            this.lblGammaVal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tsTools.SuspendLayout();
            this.panelAdjust.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSaturacion)).BeginInit();
            this.panel1.SuspendLayout();
            this.tsLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackContraste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBrillo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGamma)).BeginInit();
            this.SuspendLayout();
            // 
            // gdViewer1
            // 
            this.gdViewer1.AnimateGIF = false;
            this.gdViewer1.BackColor = System.Drawing.Color.Black;
            this.gdViewer1.BackgroundImage = null;
            this.gdViewer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gdViewer1.ContinuousViewMode = true;
            this.gdViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gdViewer1.DisplayQuality = GdPicture.DisplayQuality.DisplayQualityBicubicHQ;
            this.gdViewer1.DisplayQualityAuto = false;
            this.gdViewer1.DocumentAlignment = GdPicture.ViewerDocumentAlignment.DocumentAlignmentMiddleCenter;
            this.gdViewer1.DocumentPosition = GdPicture.ViewerDocumentPosition.DocumentPositionMiddleCenter;
            this.gdViewer1.EnabledProgressBar = true;
            this.gdViewer1.EnableMenu = false;
            this.gdViewer1.EnableMouseWheel = true;
            this.gdViewer1.ForceScrollBars = false;
            this.gdViewer1.ForceTemporaryModeForImage = false;
            this.gdViewer1.ForceTemporaryModeForPDF = true;
            this.gdViewer1.ForeColor = System.Drawing.Color.Black;
            this.gdViewer1.Gamma = 1F;
            this.gdViewer1.HQAnnotationRendering = true;
            this.gdViewer1.IgnoreDocumentResolution = false;
            this.gdViewer1.KeepDocumentPosition = false;
            this.gdViewer1.Location = new System.Drawing.Point(167, 128);
            this.gdViewer1.LockViewer = false;
            this.gdViewer1.MagnifierHeight = 90;
            this.gdViewer1.MagnifierWidth = 160;
            this.gdViewer1.MagnifierZoomX = 2F;
            this.gdViewer1.MagnifierZoomY = 2F;
            this.gdViewer1.MouseButtonForMouseMode = GdPicture.MouseButton.MouseButtonLeft;
            this.gdViewer1.MouseMode = GdPicture.ViewerMouseMode.MouseModePan;
            this.gdViewer1.MouseWheelMode = GdPicture.ViewerMouseWheelMode.MouseWheelModeZoom;
            this.gdViewer1.Name = "gdViewer1";
            this.gdViewer1.OptimizeDrawingSpeed = false;
            this.gdViewer1.PdfDisplayFormField = true;
            this.gdViewer1.PdfEnableLinks = true;
            this.gdViewer1.PDFShowDialogForPassword = true;
            this.gdViewer1.RectBorderColor = System.Drawing.SystemColors.HotTrack;
            this.gdViewer1.RectBorderSize = 1;
            this.gdViewer1.RectIsEditable = true;
            this.gdViewer1.RegionsAreEditable = true;
            this.gdViewer1.ScrollBars = true;
            this.gdViewer1.ScrollLargeChange = ((short)(50));
            this.gdViewer1.ScrollSmallChange = ((short)(1));
            this.gdViewer1.SilentMode = true;
            this.gdViewer1.Size = new System.Drawing.Size(75, 357);
            this.gdViewer1.TabIndex = 0;
            this.gdViewer1.Zoom = 1D;
            this.gdViewer1.ZoomCenterAtMousePosition = false;
            this.gdViewer1.ZoomMode = GdPicture.ViewerZoomMode.ZoomMode100;
            this.gdViewer1.ZoomStep = 25;
            // 
            // PanelIndicator
            // 
            this.PanelIndicator.BackColor = System.Drawing.Color.Red;
            this.PanelIndicator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelIndicator.Location = new System.Drawing.Point(0, 599);
            this.PanelIndicator.Name = "PanelIndicator";
            this.PanelIndicator.Size = new System.Drawing.Size(673, 5);
            this.PanelIndicator.TabIndex = 1;
            this.PanelIndicator.Visible = false;
            // 
            // tsTools
            // 
            this.tsTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTools.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnZoomFit,
            this.btnZommW,
            this.btnZoomH,
            this.btnZoomIn,
            this.toolStripButton5,
            this.btnZommOut,
            this.toolStripSeparator3,
            this.btnRotateLeft,
            this.btnRotateL,
            this.btnRotate180,
            this.toolStripSeparator1,
            this.btnFlipVert,
            this.btnFlipHor,
            this.toolStripSeparator2,
            this.btnPan,
            this.btnSelect,
            this.btnCrop,
            this.toolStripSeparator4,
            this.btnContrast,
            this.toolStripSeparator5,
            this.btnUndo});
            this.tsTools.Location = new System.Drawing.Point(0, 0);
            this.tsTools.Name = "tsTools";
            this.tsTools.Size = new System.Drawing.Size(673, 27);
            this.tsTools.TabIndex = 2;
            this.tsTools.Text = "aaaa";
            // 
            // btnZoomFit
            // 
            this.btnZoomFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomFit.Image = global::PikaScan.Properties.Resources.zoom_fit_24;
            this.btnZoomFit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomFit.Name = "btnZoomFit";
            this.btnZoomFit.Size = new System.Drawing.Size(29, 24);
            this.btnZoomFit.Text = "Zoom ajustado";
            this.btnZoomFit.Click += new System.EventHandler(this.btnZoomFit_Click);
            // 
            // btnZommW
            // 
            this.btnZommW.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZommW.Image = global::PikaScan.Properties.Resources.zoom_fit_h_24;
            this.btnZommW.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZommW.Name = "btnZommW";
            this.btnZommW.Size = new System.Drawing.Size(29, 24);
            this.btnZommW.Text = "Zoom horizontal";
            this.btnZommW.Click += new System.EventHandler(this.btnZommW_Click);
            // 
            // btnZoomH
            // 
            this.btnZoomH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomH.Image = global::PikaScan.Properties.Resources.zoom_fit_v_24;
            this.btnZoomH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomH.Name = "btnZoomH";
            this.btnZoomH.Size = new System.Drawing.Size(29, 24);
            this.btnZoomH.Tag = "Zoom vertical";
            this.btnZoomH.Text = "Zoom horizontal";
            this.btnZoomH.Click += new System.EventHandler(this.btnZoomH_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomIn.Image = global::PikaScan.Properties.Resources.zoom_plus_24;
            this.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(29, 24);
            this.btnZoomIn.Text = "Acercar";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AccessibleDescription = "btnZommEq";
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::PikaScan.Properties.Resources.zoom_eq_24;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton5.Text = "Escala original";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // btnZommOut
            // 
            this.btnZommOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZommOut.Image = global::PikaScan.Properties.Resources.zoom_minus_24;
            this.btnZommOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZommOut.Name = "btnZommOut";
            this.btnZommOut.Size = new System.Drawing.Size(29, 24);
            this.btnZommOut.Text = "Alejar";
            this.btnZommOut.Click += new System.EventHandler(this.btnZommOut_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRotateLeft.Image = global::PikaScan.Properties.Resources.rotate_left_24;
            this.btnRotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(29, 24);
            this.btnRotateLeft.Text = "Rotar izquierda";
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // btnRotateL
            // 
            this.btnRotateL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRotateL.Image = global::PikaScan.Properties.Resources.rotate_right_24;
            this.btnRotateL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRotateL.Name = "btnRotateL";
            this.btnRotateL.Size = new System.Drawing.Size(29, 24);
            this.btnRotateL.Text = "Rrotar derecha";
            this.btnRotateL.Click += new System.EventHandler(this.btnRotateL_Click);
            // 
            // btnRotate180
            // 
            this.btnRotate180.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRotate180.Image = global::PikaScan.Properties.Resources.transform_rotate_180_24;
            this.btnRotate180.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRotate180.Name = "btnRotate180";
            this.btnRotate180.Size = new System.Drawing.Size(29, 24);
            this.btnRotate180.Text = "Rotar 180";
            this.btnRotate180.Click += new System.EventHandler(this.btnRotate180_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnFlipVert
            // 
            this.btnFlipVert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFlipVert.Image = global::PikaScan.Properties.Resources.flip_vert_24;
            this.btnFlipVert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFlipVert.Name = "btnFlipVert";
            this.btnFlipVert.Size = new System.Drawing.Size(29, 24);
            this.btnFlipVert.Text = "Volterar vertical";
            this.btnFlipVert.Click += new System.EventHandler(this.btnFlipVert_Click);
            // 
            // btnFlipHor
            // 
            this.btnFlipHor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFlipHor.Image = global::PikaScan.Properties.Resources.flip_hor_24;
            this.btnFlipHor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFlipHor.Name = "btnFlipHor";
            this.btnFlipHor.Size = new System.Drawing.Size(29, 24);
            this.btnFlipHor.Text = "Voltear horizontal";
            this.btnFlipHor.Click += new System.EventHandler(this.btnFlipHor_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnPan
            // 
            this.btnPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPan.Image = global::PikaScan.Properties.Resources.move_24;
            this.btnPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPan.Name = "btnPan";
            this.btnPan.Size = new System.Drawing.Size(29, 24);
            this.btnPan.Text = "Desplazar";
            this.btnPan.Click += new System.EventHandler(this.btnPan_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSelect.Image = global::PikaScan.Properties.Resources.region_24;
            this.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(29, 24);
            this.btnSelect.Text = "Seleccionar";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCrop
            // 
            this.btnCrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCrop.Image = global::PikaScan.Properties.Resources.crop_24;
            this.btnCrop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(29, 24);
            this.btnCrop.Text = "Recortar";
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // btnContrast
            // 
            this.btnContrast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnContrast.Image = global::PikaScan.Properties.Resources.contrast_24;
            this.btnContrast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnContrast.Name = "btnContrast";
            this.btnContrast.Size = new System.Drawing.Size(29, 24);
            this.btnContrast.Text = "Contraste";
            this.btnContrast.Click += new System.EventHandler(this.btnContrast_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Image = global::PikaScan.Properties.Resources.Actions_undo_24;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(29, 24);
            this.btnUndo.Text = "Deshacer";
            // 
            // panelAdjust
            // 
            this.panelAdjust.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAdjust.Controls.Add(this.trackSaturacion);
            this.panelAdjust.Controls.Add(this.lblContVal);
            this.panelAdjust.Controls.Add(this.panel1);
            this.panelAdjust.Controls.Add(this.lblSatVal);
            this.panelAdjust.Controls.Add(this.label1);
            this.panelAdjust.Controls.Add(this.label3);
            this.panelAdjust.Controls.Add(this.lblBrilloVal);
            this.panelAdjust.Controls.Add(this.lblBrillo);
            this.panelAdjust.Controls.Add(this.trackContraste);
            this.panelAdjust.Controls.Add(this.trackBrillo);
            this.panelAdjust.Controls.Add(this.trackGamma);
            this.panelAdjust.Controls.Add(this.lblGammaVal);
            this.panelAdjust.Controls.Add(this.label5);
            this.panelAdjust.Location = new System.Drawing.Point(87, 30);
            this.panelAdjust.Name = "panelAdjust";
            this.panelAdjust.Size = new System.Drawing.Size(389, 163);
            this.panelAdjust.TabIndex = 3;
            this.panelAdjust.Visible = false;
            // 
            // trackSaturacion
            // 
            this.trackSaturacion.Location = new System.Drawing.Point(88, 79);
            this.trackSaturacion.Maximum = 100;
            this.trackSaturacion.Minimum = -100;
            this.trackSaturacion.Name = "trackSaturacion";
            this.trackSaturacion.Size = new System.Drawing.Size(200, 56);
            this.trackSaturacion.TabIndex = 0;
            this.trackSaturacion.TickFrequency = 50;
            this.trackSaturacion.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackSaturacion.ValueChanged += new System.EventHandler(this.trackBarLevel_ValueChanged);
            // 
            // lblContVal
            // 
            this.lblContVal.Location = new System.Drawing.Point(285, 52);
            this.lblContVal.Name = "lblContVal";
            this.lblContVal.Size = new System.Drawing.Size(90, 24);
            this.lblContVal.TabIndex = 3;
            this.lblContVal.Text = "0";
            this.lblContVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tsLevel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 28);
            this.panel1.TabIndex = 4;
            // 
            // tsLevel
            // 
            this.tsLevel.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsLevel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsLevel.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsLevel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.btnlevelreset,
            this.btnLevelCancel,
            this.toolStripSeparator10,
            this.btnLevelOK});
            this.tsLevel.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tsLevel.Location = new System.Drawing.Point(287, 0);
            this.tsLevel.Name = "tsLevel";
            this.tsLevel.Size = new System.Drawing.Size(100, 28);
            this.tsLevel.TabIndex = 3;
            this.tsLevel.Text = "aaaa";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // btnlevelreset
            // 
            this.btnlevelreset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnlevelreset.Image = global::PikaScan.Properties.Resources.Actions_undo_24;
            this.btnlevelreset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnlevelreset.Name = "btnlevelreset";
            this.btnlevelreset.Size = new System.Drawing.Size(29, 24);
            this.btnlevelreset.Text = "Deshacer";
            this.btnlevelreset.Click += new System.EventHandler(this.btnlevelreset_Click);
            // 
            // btnLevelCancel
            // 
            this.btnLevelCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLevelCancel.Image = global::PikaScan.Properties.Resources.asterisk_yellow_icon_24;
            this.btnLevelCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLevelCancel.Name = "btnLevelCancel";
            this.btnLevelCancel.Size = new System.Drawing.Size(29, 24);
            this.btnLevelCancel.Text = "Cerrar";
            this.btnLevelCancel.Click += new System.EventHandler(this.btnLevelCancel_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 23);
            // 
            // btnLevelOK
            // 
            this.btnLevelOK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLevelOK.Image = global::PikaScan.Properties.Resources.tick_icon_24;
            this.btnLevelOK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLevelOK.Name = "btnLevelOK";
            this.btnLevelOK.Size = new System.Drawing.Size(29, 24);
            this.btnLevelOK.Text = "Aceptar";
            this.btnLevelOK.Click += new System.EventHandler(this.btnLevelOK_Click);
            // 
            // lblSatVal
            // 
            this.lblSatVal.Location = new System.Drawing.Point(285, 90);
            this.lblSatVal.Name = "lblSatVal";
            this.lblSatVal.Size = new System.Drawing.Size(92, 24);
            this.lblSatVal.TabIndex = 3;
            this.lblSatVal.Text = "0";
            this.lblSatVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Contraste";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "Saturación";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBrilloVal
            // 
            this.lblBrilloVal.Location = new System.Drawing.Point(285, 12);
            this.lblBrilloVal.Name = "lblBrilloVal";
            this.lblBrilloVal.Size = new System.Drawing.Size(90, 24);
            this.lblBrilloVal.TabIndex = 3;
            this.lblBrilloVal.Text = "0";
            this.lblBrilloVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrillo
            // 
            this.lblBrillo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrillo.Location = new System.Drawing.Point(3, 6);
            this.lblBrillo.Name = "lblBrillo";
            this.lblBrillo.Size = new System.Drawing.Size(90, 30);
            this.lblBrillo.TabIndex = 1;
            this.lblBrillo.Text = "Brillo";
            this.lblBrillo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trackContraste
            // 
            this.trackContraste.Location = new System.Drawing.Point(88, 39);
            this.trackContraste.Maximum = 100;
            this.trackContraste.Minimum = -100;
            this.trackContraste.Name = "trackContraste";
            this.trackContraste.Size = new System.Drawing.Size(200, 56);
            this.trackContraste.TabIndex = 0;
            this.trackContraste.TickFrequency = 50;
            this.trackContraste.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackContraste.ValueChanged += new System.EventHandler(this.trackBarLevel_ValueChanged);
            // 
            // trackBrillo
            // 
            this.trackBrillo.Location = new System.Drawing.Point(88, 3);
            this.trackBrillo.Maximum = 100;
            this.trackBrillo.Minimum = -100;
            this.trackBrillo.Name = "trackBrillo";
            this.trackBrillo.Size = new System.Drawing.Size(200, 56);
            this.trackBrillo.TabIndex = 0;
            this.trackBrillo.TickFrequency = 50;
            this.trackBrillo.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBrillo.ValueChanged += new System.EventHandler(this.trackBarLevel_ValueChanged);
            // 
            // trackGamma
            // 
            this.trackGamma.Location = new System.Drawing.Point(88, 123);
            this.trackGamma.Maximum = 100;
            this.trackGamma.Minimum = -100;
            this.trackGamma.Name = "trackGamma";
            this.trackGamma.Size = new System.Drawing.Size(200, 56);
            this.trackGamma.TabIndex = 0;
            this.trackGamma.TickFrequency = 50;
            this.trackGamma.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackGamma.Visible = false;
            this.trackGamma.ValueChanged += new System.EventHandler(this.trackBarLevel_ValueChanged);
            // 
            // lblGammaVal
            // 
            this.lblGammaVal.Location = new System.Drawing.Point(285, 132);
            this.lblGammaVal.Name = "lblGammaVal";
            this.lblGammaVal.Size = new System.Drawing.Size(92, 24);
            this.lblGammaVal.TabIndex = 3;
            this.lblGammaVal.Text = "0";
            this.lblGammaVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGammaVal.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "Gamma";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Visible = false;
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelAdjust);
            this.Controls.Add(this.tsTools);
            this.Controls.Add(this.PanelIndicator);
            this.Controls.Add(this.gdViewer1);
            this.Name = "ImageEditor";
            this.Size = new System.Drawing.Size(673, 604);
            this.Load += new System.EventHandler(this.ImageEditor_Load);
            this.tsTools.ResumeLayout(false);
            this.tsTools.PerformLayout();
            this.panelAdjust.ResumeLayout(false);
            this.panelAdjust.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSaturacion)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tsLevel.ResumeLayout(false);
            this.tsLevel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackContraste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBrillo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackGamma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GdPicture.GdViewer gdViewer1;
        private System.Windows.Forms.Panel PanelIndicator;
        private System.Windows.Forms.ToolStrip tsTools;
        private System.Windows.Forms.ToolStripButton btnRotateLeft;
        private System.Windows.Forms.ToolStripButton btnRotateL;
        private System.Windows.Forms.ToolStripButton btnRotate180;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFlipVert;
        private System.Windows.Forms.ToolStripButton btnFlipHor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnZoomFit;
        private System.Windows.Forms.ToolStripButton btnZommW;
        private System.Windows.Forms.ToolStripButton btnZoomH;
        private System.Windows.Forms.ToolStripButton btnZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton btnZommOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnPan;
        private System.Windows.Forms.ToolStripButton btnSelect;
        private System.Windows.Forms.ToolStripButton btnCrop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnContrast;
        private System.Windows.Forms.Panel panelAdjust;
        private System.Windows.Forms.Label lblBrillo;
        private System.Windows.Forms.TrackBar trackBrillo;
        private System.Windows.Forms.Label lblBrilloVal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip tsLevel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnLevelOK;
        private System.Windows.Forms.ToolStripButton btnLevelCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnlevelreset;
        private System.Windows.Forms.TrackBar trackContraste;
        private System.Windows.Forms.Label lblContVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackGamma;
        private System.Windows.Forms.TrackBar trackSaturacion;
        private System.Windows.Forms.Label lblGammaVal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSatVal;
        private System.Windows.Forms.Label label3;
    }
}
