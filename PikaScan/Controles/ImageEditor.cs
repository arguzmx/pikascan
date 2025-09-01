using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using PikaScan.Events;
using PikaScan.Servicios;
using ImageProcessor.Imaging.Formats;
using ImageProcessor;
using PikaScan.Comandos;


namespace PikaScan.Controles
{
    public partial class ImageEditor : UserControl
    {
        public delegate void ImageUpdatedEventHandler(object sender, ImageUpdatedEventArgs e);

        public event ImageUpdatedEventHandler ImageUpdated;

        private bool isJPG;

        private bool latchBar;

        private ImageOp currentOp;

        private enum ImageOp
        {
            none, bright, contrast
        }



        protected virtual void OnImageUpdated()
        {
            ImageUpdatedEventArgs e = new ImageUpdatedEventArgs()
            {
                Index = this.ImageIndex,
                Source = this.Source
            };
            ImageUpdatedEventHandler handler = ImageUpdated;
            handler?.Invoke(this, e);
        }

        public event EventHandler OnActive;

        protected virtual void OnGotFocusEventHandler(EventArgs e)
        {
            this.tsTools.Visible = true;
            EventHandler handler = OnActive;
            handler?.Invoke(this, e);
        }


        public void Unselect()
        {
            this.PanelIndicator.Visible = false;
        }


        public int ImageIndex { get; set; }
        private ImageProcessorService p;
        private GdPicture.GdPictureImaging gdp;
        private string Source;
        private string BackupSource;

        public ImageEditor()
        {


            InitializeComponent();

            ImageIndex = 0;
            Source = "";
            gdp = new GdPicture.GdPictureImaging();
            gdp.SetLicenseNumber(ImageProcessorService.GDILIC);

            p = new ImageProcessorService();
            this.gdViewer1.SetLicenseNumber(ImageProcessorService.GDILIC);
            gdViewer1.GotFocus += This_GotFocus;

            gdViewer1.LostFocus += ImageEditor_LostFocus;
            ShowCalibrationRectangle = false;
            gdViewer1.MouseClick += GdViewer1_MouseClick;

            tsTools.Visible = false;
            latchBar = false;

            currentOp = ImageOp.none;

        }



        public Color BgColor
        {
            get { return this.gdViewer1.BackColor; }
            set
            {
                this.gdViewer1.BackColor = value;
            }
        }

        private void showLevelDialog()
        {



            trackBrillo.Value = 0;
            trackContraste.Value = 0;
            trackGamma.Value = 0;
            trackSaturacion.Value = 0;

            lblBrilloVal.Text = trackBrillo.Value.ToString();
            lblContVal.Text = trackContraste.Value.ToString();
            lblGammaVal.Text = trackGamma.Value.ToString();
            lblSatVal.Text = trackSaturacion.Value.ToString();


            panelAdjust.Top = tsTools.Height + 5;
            panelAdjust.Left = 5;
            panelAdjust.Visible = true;
        }

        private void ImageEditor_LostFocus(object sender, EventArgs e)
        {
            if (!this.latchBar)
            {
                this.tsTools.Visible = false;
            }

        }

        private bool _ShowCalibrationRectangle;

        public bool ShowCalibrationRectangle
        {
            get { return _ShowCalibrationRectangle; }
            set
            {
                _ShowCalibrationRectangle = value;
                if (value == false)
                {
                    if (calibrationid != 0)
                    {
                        gdp.ReleaseGdPictureImage(calibrationid);
                    }
                }
            }
        }





        private int calibrationid;
        private void GdViewer1_MouseClick(object sender, MouseEventArgs e)
        {

            if (ShowCalibrationRectangle)
            {


                Debug.Print($"[ ] {e.X},{e.Y}");
                int Xdoc = 0, YDoc = 0;

                gdViewer1.CoordViewerToDocument(e.X, e.Y, ref Xdoc, ref YDoc);
                Debug.Print($"[X] {Xdoc},{YDoc}");

                if (calibrationid != 0)
                {
                    gdp.ReleaseGdPictureImage(calibrationid);
                }

                calibrationid = gdp.CreateGdPictureImageFromFile(this.Source);
                if (calibrationid != 0)
                {
                    gdp.DrawRectangle(calibrationid, Xdoc, YDoc, 100, 100, 5, Color.Red, false);
                    gdp.DrawRectangle(calibrationid, Xdoc, YDoc, 200, 200, 5, Color.Red, false);
                    gdp.DrawRectangle(calibrationid, Xdoc, YDoc, 300, 300, 5, Color.Red, false);
                    gdViewer1.DisplayFromGdPictureImage(calibrationid);

                }

            }


        }

        private void This_GotFocus(object sender, EventArgs e)
        {
            OnGotFocusEventHandler(null);
        }

        private void ImageEditor_Load(object sender, EventArgs e)
        {
            this.gdViewer1.Dock = DockStyle.Fill;
        }


        public void ClearImage()
        {
            ReleaseTemp();
            this.gdViewer1.Clear();
            this.Source = "";
            this.ImageIndex = 0;
        }

        public void SetImage(string ImagePath, int Index)
        {
            try
            {
                if (ImagePath.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) ||
                    ImagePath.EndsWith(".jpeg", StringComparison.InvariantCultureIgnoreCase))
                {
                    this.isJPG = true;
                }
                else
                {
                    this.isJPG = false;
                }

                Source = ImagePath;
                //BackupSource = "";

                this.ImageIndex = Index;

                this.gdViewer1.ZoomMode = GdPicture.ViewerZoomMode.ZoomModeFitToViewer;
                this.gdViewer1.DisplayFromFile(ImagePath);

            }
            catch (Exception ex)
            {

            }

        }


        public void Restore()
        {
            if (BackupSource != "")
            {
                File.Copy(BackupSource, this.Source, true);
                SetImage(this.Source, this.ImageIndex);
            }
        }


        public void SetZoom(GdPicture.ViewerZoomMode mode)
        {
            this.gdViewer1.ZoomMode = mode;
        }


        public void ZoomOut()
        {
            this.gdViewer1.ZoomMode = GdPicture.ViewerZoomMode.ZoomModeCustom;
            this.gdViewer1.ZoomOUT();
        }

        public void ZoomIn()
        {
            this.gdViewer1.ZoomMode = GdPicture.ViewerZoomMode.ZoomModeCustom;
            this.gdViewer1.ZoomIN();
        }

        public void SetMouseModeSelection(GdPicture.ViewerMouseMode mode)
        {
            this.gdViewer1.MouseMode = mode;
        }


        public void ClearSelection()
        {
            this.gdViewer1.ClearRect();
        }

        public bool HasSelection()
        {
            return this.gdViewer1.IsRect();
        }


        private void CreateBackup()
        {
            this.BackupSource = Path.Combine(Application.StartupPath, "temp.bak");

            if (File.Exists(this.BackupSource))
            {
                File.Delete(this.BackupSource);
            }
            File.Copy(this.Source, this.BackupSource);
        }

        public void Crop()
        {


            if (File.Exists(this.Source))
            {
                CreateBackup();

                FileInfo fi = new FileInfo(this.Source);
                int l = 0, t = 0, w = 0, h = 0;
                gdViewer1.GetRectCoordinatesOnDocument(ref l, ref t, ref w, ref h);
                if (w > 0 && h > 0)
                {
                    if (!isJPG)
                    {
                        int id = gdp.CreateGdPictureImageFromFile(this.Source);
                        gdp.Crop(id, l, t, w, h);
                        SaveFile(id, Source);
                        gdp.ReleaseGdPictureImage(id);

                    }
                    else
                    {
                        byte[] photoBytes = File.ReadAllBytes(this.Source);
                        ISupportedImageFormat format = new JpegFormat { Quality = 100 };
                        using (MemoryStream inStream = new MemoryStream(photoBytes))
                        {
                            using (MemoryStream outStream = new MemoryStream())
                            {
                                using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                                {
                                    imageFactory.Load(inStream)
                                                .Crop(new Rectangle(l, t, w, h))
                                                .Format(format)
                                                .Save(this.Source);
                                }

                            }
                        }

                    }

                    OnImageUpdated();
                    this.SetImage(this.Source, this.ImageIndex);


                }

            }
        }


        /// <summary>
        /// ID de la imagen temporal
        /// </summary>
        private int TempImgId;

        public void PreviewBCSG(CommandBrightContrast c)
        {
            try
            {
                if (Source != "")
                {
                    if (BackupSource == "")
                    {
                        CreateBackup();
                    }


                }
                

                if (!isJPG)
                {
                    if (TempImgId == 0)
                    {
                        TempImgId = gdp.CreateGdPictureImageFromFile(BackupSource);
                    }

                    if (TempImgId != 0)
                    {

                        gdp.CopyToClipboard(TempImgId);

                        int id = gdp.CreateGdPictureImageFromClipboard();
                        if (id != 0)
                        {
                            gdp.SetBCSG(id, c.Brightness, c.Contrast, c.Saturation, 0);
                            gdp.CopyToClipboard(id);
                            this.gdViewer1.DisplayFromClipboard();
                            gdp.ReleaseGdPictureImage(id);
                        }

                    }
                }
                else
                {
                    byte[] photoBytes = File.ReadAllBytes(this.BackupSource);
                    ISupportedImageFormat format = new JpegFormat { Quality = 100 };
                    using (MemoryStream inStream = new MemoryStream(photoBytes))
                    {
                        using (MemoryStream outStream = new MemoryStream())
                        {
                            using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                            {

                                imageFactory.Load(inStream)
                                            .Brightness(c.Brightness)
                                            .Contrast(c.Contrast)
                                            .Saturation(c.Saturation)
                                            .Format(format)
                                            .Save(outStream);
                            }
                            this.gdViewer1.DisplayFromStream(outStream);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }


        public void SetBrightnessContrast(int b, int c)
        {

            if (b != 0 || c != 0)
            {

                if (Source != "")
                {
                    if (BackupSource == "")
                    {
                        CreateBackup();
                    }


                    if (!isJPG)
                    {

                        if (TempImgId == 0)
                        {
                            TempImgId = gdp.CreateGdPictureImageFromFile(BackupSource);
                        }


                        if (TempImgId != 0)
                        {

                            gdp.CopyToClipboard(TempImgId);

                            int id = gdp.CreateGdPictureImageFromClipboard();
                            if (id != 0)
                            {
                                if (b != 0) gdp.SetBrightness(id, b);
                                if (c != 0) gdp.SetContrast(id, c);
                                gdp.CopyToClipboard(id);
                                this.gdViewer1.DisplayFromClipboard();
                                gdp.ReleaseGdPictureImage(id);
                            }

                        }
                    }
                    else
                    {
                        byte[] photoBytes = File.ReadAllBytes(this.BackupSource);
                        ISupportedImageFormat format = new JpegFormat { Quality = 100 };
                        using (MemoryStream inStream = new MemoryStream(photoBytes))
                        {
                            using (MemoryStream outStream = new MemoryStream())
                            {
                                using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                                {
                                    if (b != 0 && c != 0)
                                    {
                                        imageFactory.Load(inStream)
                                                .Brightness(b)
                                                .Contrast(c)
                                                .Format(format)
                                                .Save(outStream);
                                    }
                                    else
                                    {
                                        if (b != 0)
                                        {
                                            imageFactory.Load(inStream)
                                                .Brightness(b)
                                                .Format(format)
                                                .Save(outStream);
                                        }

                                        if (c != 0)
                                        {
                                            imageFactory.Load(inStream)
                                                    .Contrast(c)
                                                    .Format(format)
                                                    .Save(outStream);
                                        }
                                    }


                                }
                                this.gdViewer1.DisplayFromStream(outStream);
                            }
                        }
                    }


                }
            }


        }





        public void Undo()
        {

            if (BackupSource != "")
            {
                File.Copy(BackupSource, Source, true);
            }

            ReleaseTemp();

            this.SetImage(this.Source, this.ImageIndex);
            OnImageUpdated();

        }


        private void SaveFile(int id, string filepath)
        {
            this.gdViewer1.CloseDocument();

            FileInfo fi = new FileInfo(filepath);
            if (File.Exists(this.Source))
            {
                File.Delete(this.Source);   
            }

            switch (fi.Extension.ToLower())
            {
                case ".bmp":
                    gdp.SaveAsBMP(id, this.Source);
                    break;

                case ".png":
                    gdp.SaveAsPNG(id, this.Source);
                    break;

                case ".tif":
                    gdp.SaveAsTIFF(id, this.Source, GdPicture.TiffCompression.TiffCompressionAUTO);
                    break;

                case ".gif":
                    gdp.SaveAsGIF(id, this.Source);
                    break;
            }
            this.gdViewer1.DisplayFromFile(this.Source);
        }




        private void ReleaseTemp()
        {
            if (TempImgId != 0)
            {
                gdp.ReleaseGdPictureImage(TempImgId);
            }
            if (!string.IsNullOrEmpty(BackupSource))
            {
                try
                {
                    File.Delete(BackupSource);
                }
                catch (Exception)
                {
                }
            }

            BackupSource = "";
            TempImgId = 0;
        }

        public void SaveChanges(Command command)
        {

            switch (command.Type)
            {
                case Command.CommandType.BrightContrast:
                    CommandBrightContrast c = (CommandBrightContrast)command;
                    if (!isJPG)
                    {
                        int id = gdp.CreateGdPictureImageFromFile(BackupSource);
                        if (id != 0)
                        {
                            gdp.SetBCSG(id, c.Brightness, c.Contrast, c.Saturation, c.Gamma);
                            SaveFile(id, Source);
                            gdp.ReleaseGdPictureImage(id);
                        }
                    }
                    else
                    {
                        BrightContrastJPG(c);
                    }

                    this.SetImage(this.Source, this.ImageIndex);
                    ReleaseTemp();

                    OnImageUpdated();
                    break;

            }
        }


        public void Rotate(RotateFlipType rotation)
        {
            int id = gdp.CreateGdPictureImageFromFile(this.Source);
            if (id != 0)
            {

                if (!isJPG)
                {
                    switch (rotation)
                    {
                        case RotateFlipType.Rotate180FlipNone:
                            gdp.RotateAngle(id, 180);
                            break;

                        case RotateFlipType.Rotate90FlipNone:
                            gdp.RotateAngle(id, 90);
                            break;

                        case RotateFlipType.Rotate270FlipNone:
                            gdp.RotateAngle(id, 270);
                            break;

                        case RotateFlipType.RotateNoneFlipX:
                            gdp.Rotate(id, RotateFlipType.RotateNoneFlipX );
                            break;

                        case RotateFlipType.RotateNoneFlipY:
                            gdp.Rotate(id, RotateFlipType.RotateNoneFlipY);
                            break;
                    }
                    SaveFile(id, this.Source);
                    gdp.ReleaseGdPictureImage(id);

                }
                else
                {
                    switch (rotation)
                    {
                        case RotateFlipType.Rotate180FlipNone:
                            RotateJPG(180);
                            break;

                        case RotateFlipType.Rotate90FlipNone:
                            RotateJPG(90);
                            break;

                        case RotateFlipType.Rotate270FlipNone:
                            RotateJPG(270);
                            break;

                        case RotateFlipType.RotateNoneFlipX:
                            FlipJPG(false);
                            break;

                        case RotateFlipType.RotateNoneFlipY:
                            FlipJPG(true);
                            break;
                    }

                }

                this.gdViewer1.DisplayFromFile(this.Source);
                OnImageUpdated();

            }
        }


        private void RotateJPG(float degrees)
        {

            byte[] photoBytes = File.ReadAllBytes(this.Source);
            ISupportedImageFormat format = new JpegFormat { Quality = 100 };
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Rotate(degrees)
                                    .Format(format)
                                    .Save(this.Source);
                    }

                }
            }
        }


        private void BrightContrastJPG(CommandBrightContrast c)
        {

            byte[] photoBytes = File.ReadAllBytes(this.Source);
            ISupportedImageFormat format = new JpegFormat { Quality = 100 };
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                            .Contrast(c.Contrast)
                            .Brightness(c.Brightness)
                            .Saturation(c.Saturation)
                            .Gamma(c.Gamma)
                                    .Format(format)
                                    .Save(this.Source);
                    }

                }
            }
        }



        private void FlipJPG(bool vertical)
        {

            byte[] photoBytes = File.ReadAllBytes(this.Source);
            ISupportedImageFormat format = new JpegFormat { Quality = 100 };
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(inStream)
                                    .Flip(vertical)
                                    .Format(format)
                                    .Save(this.Source);
                    }

                }
            }
        }

        private void btnBright_Click(object sender, EventArgs e)
        {

            showLevelDialog();
        }

        private void btnContrast_Click(object sender, EventArgs e)
        {
            showLevelDialog();
        }

        private void btnApplyLevel_Click(object sender, EventArgs e)
        {

        }



        private void btnLevelOK_Click(object sender, EventArgs e)
        {
            this.SaveChanges(GetCommandBrightContrast());
            latchBar = false;
            currentOp = ImageOp.none;
            panelAdjust.Visible = false;
        }


        private CommandBrightContrast GetCommandBrightContrast()
        {
            return new CommandBrightContrast(this.trackBrillo.Value, this.trackContraste.Value,
                this.trackSaturacion.Value, this.trackGamma.Value);
        }


        private void btnLevelCancel_Click(object sender, EventArgs e)
        {
            Undo();
            latchBar = false;
            currentOp = ImageOp.none;
            panelAdjust.Visible = false;
        }

        private void btnlevelreset_Click(object sender, EventArgs e)
        {

            trackBrillo.Value = 0;
            trackContraste.Value = 0;
            trackGamma.Value = 0;
            trackSaturacion.Value = 0;


        }

        private void btnZoomFit_Click(object sender, EventArgs e)
        {
            this.SetZoom(GdPicture.ViewerZoomMode.ZoomModeFitToViewer);
        }

        private void btnZommW_Click(object sender, EventArgs e)
        {
            this.SetZoom(GdPicture.ViewerZoomMode.ZoomModeWidthViewer);
        }

        private void btnZoomH_Click(object sender, EventArgs e)
        {
            this.SetZoom(GdPicture.ViewerZoomMode.ZoomModeHeightViewer);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.SetZoom(GdPicture.ViewerZoomMode.ZoomMode100);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            this.ZoomIn();
        }

        private void btnZommOut_Click(object sender, EventArgs e)
        {
            this.ZoomOut();
        }

        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            this.Rotate(RotateFlipType.Rotate270FlipNone);
        }

        private void btnRotateL_Click(object sender, EventArgs e)
        {
            this.Rotate(RotateFlipType.Rotate90FlipNone);
        }

        private void btnRotate180_Click(object sender, EventArgs e)
        {
            this.Rotate(RotateFlipType.Rotate180FlipNone);
        }

        private void btnFlipVert_Click(object sender, EventArgs e)
        {
            this.Rotate(RotateFlipType.RotateNoneFlipY);
        }

        private void btnFlipHor_Click(object sender, EventArgs e)
        {
            this.Rotate(RotateFlipType.RotateNoneFlipX);
        }



        private void trackBarLevel_ValueChanged(object sender, EventArgs e)
        {
            ShowTrackValues();
        }

        private void ShowTrackValues()
        {
            lblBrilloVal.Text = trackBrillo.Value.ToString();
            lblContVal.Text = trackContraste.Value.ToString();
            lblGammaVal.Text = trackGamma.Value.ToString();
            lblSatVal.Text = trackSaturacion.Value.ToString();

            if ((trackBrillo.Value + trackContraste.Value +
                trackGamma.Value + trackSaturacion.Value) != 0)
            {
                PreviewBCSG(this.GetCommandBrightContrast());
            }

        }

        private void btnPan_Click(object sender, EventArgs e)
        {
            SetMouseModeSelection(GdPicture.ViewerMouseMode.MouseModePan);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SetMouseModeSelection(GdPicture.ViewerMouseMode.MouseModeAreaSelection);
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            DoCrop();
        }

        private void DoCrop()
        {


            if (!HasSelection())
            {
                UIHelper.ShowNotification("Debe crear un rectángulo de selección", ToolTipIcon.Warning);
                return;
            }

            this.Crop();
            UIHelper.ShowNotification("La imagen ha sido actualizada", ToolTipIcon.Info);

        }
    }
}

