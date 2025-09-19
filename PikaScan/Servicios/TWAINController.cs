using GdPicture;
using PikaScan.Modelo;
using System;
using System.IO;
using System.Windows.Forms;

namespace PikaScan.Servicios
{
    public class TWAINController: IOController
    {


        public const string GDILIC = "411897669724499821116142492193218";
        private GdPicture.GdPictureImaging g;
        public TWAINController(
              IDocumentService documentService,
              IPageService pageService,
              IAppSettings appSettings) : base(documentService, pageService, appSettings)
        {
            g = new GdPicture.GdPictureImaging();
            g.SetLicenseNumber(GDILIC);
        }

        public TWAINConfig config { get; set; }

        public IntPtr handle { get; set; }


        public override void CancelImport() {
            switch (g.TwainGetState())
            {
                case TwainStatus.TWAIN_TRANSFERRING:
                case TwainStatus.TWAIN_TRANSFER_READY:
                    g.TwainEndAllXfers();
                    g.TwainCloseSource();
                    break;
            }
        }


        public override ImportResult Import(bool isDemoMode, string DocumentId)
        {
            ImportResult r = new ImportResult();

            Documento d = Form1.documento;

            #region Validacion


            if (d == null)
            {
                r.DoneOK = false;
                r.Errors.Add("Documento no válido");
                return r;
            }

            g.TwainLogStart(Path.Combine( appSettings.AppPath, "twainlog.txt"));


            
            if (!g.TwainOpenSource(handle, config.Source))
            {
                r.DoneOK = false;
                r.Errors.Add($"No pudo conetarse con {config.Source}");
                return r;
            }

            g.TwainSetPixelType(config.PixelType);
            g.TwainSetResolution(config.Resolution);
            if(config.Duplex) {
                g.TwainEnableDuplex(true);
            }
            else
            {
                g.TwainEnableDuplex(false);
            };

            g.TwainSetCompression(config.Compression);
            g.TwainSetImageFileFormat(config.ImageFormat);

            if (config.AutoOrientation)
            {
                g.TwainSetAutomaticRotation(true);
            } else
            {
                g.TwainSetAutomaticRotation(false);
            }


                //if (!g.TwainSetResolution(config.Resolution))
                //{
                //    r.DoneOK = false;
                //    r.Errors.Add($"No pudo establcerse la resolución {config.Resolution}");
                //    return r;
                //}

                //if (!g.TwainSetPixelType(config.PixelType))
                //{
                //    r.DoneOK = false;
                //    r.Errors.Add($"No pudo establcerse el modo de color {config.PixelType}");
                //    return r;
                //}

                //if (!g.TwainSetImageFileFormat(config.ImageFormat))
                //{
                //    r.DoneOK = false;
                //    r.Errors.Add($"No pudo establcerse el formato {config.ImageFormat}");
                //    return r;
                //}

                //if (!g.TwainSetCompression(config.Compression))
                //{
                //    r.DoneOK = false;
                //    r.Errors.Add($"No pudo establcerse la compresión {config.Compression}");
                //    return r;
                //}

                //if (config.Duplex)
                //{
                //    if (!g.TwainEnableDuplex(true))
                //    {
                //        r.DoneOK = false;
                //        r.Errors.Add($"No pudo establcerse el modo duplex");
                //        return r;
                //    }
                //}


                #endregion

                g.TwainSetHideUI(true);

         

            string Extesion = ".RAW";
            switch (config.ImageFormat)
            {
                case TwainImageFileFormats.TWFF_BMP:
                    Extesion = ".JPG";
                    break;

                case TwainImageFileFormats.TWFF_JFIF:
                    Extesion = ".JPG";
                    break;

                case TwainImageFileFormats.TWFF_PNG:
                    Extesion = ".PNG";
                    break;

                case TwainImageFileFormats.TWFF_TIFF:
                    Extesion = ".TIF";
                    break;
            }
      

            do
            {
                int index = 1;
                string FileName = Path.Combine(appSettings.AppPath, $"TMP-{index.ToString().PadLeft(8, '0')}") + Extesion;
                if (File.Exists(FileName)) {
                    File.Delete(FileName);
                }
                int ImageID = g.TwainAcquireToGdPictureImage(handle);

                if (ImageID > 0)
                {
                    switch (Extesion)
                    {
                        case ".BMP":
                            g.SaveAsJPEG(ImageID, FileName);
                            break;

                        case ".JPG":
                            g.SaveAsJPEG(ImageID, FileName);
                            break;

                        case ".PNG":
                            g.SaveAsPNG(ImageID, FileName);
                            break;

                        case ".TIF":
                            g.SaveAsTIFF(ImageID, FileName, TiffCompression.TiffCompressionAUTO);
                            break;
                    }
                    g.ReleaseGdPictureImage(ImageID);

                    base.AddPage(new FileInfo(FileName), d, SourceType.Scanner, 0, this.isDemoMode, 0);
                    //if (File.Exists(FileName))
                    //{
                    //    File.Delete(FileName);
                    //}
                }

                OnDoEvents();
            

            } while (g.TwainGetState() > TwainStatus.TWAIN_SOURCE_ENABLED);

            g.TwainDisableSource();
            g.TwainCloseSource();
            
            return r;
        }

    }
}
