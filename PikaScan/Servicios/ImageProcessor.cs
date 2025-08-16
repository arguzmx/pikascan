using PikaScan.Modelo;
using System;
using System.IO;

namespace PikaScan.Servicios
{

    public enum OutPutFormats { 
        JPEG=0, TIF=1, PNG=2
    }

    [Flags]
    public enum PixelFormat { 
        Color24=1, Grayscale=2, BW=4, BWBitonal=8   
    }

    public enum TIFCompression
    {
        None=0, LZW=1, CCITT4 = 2
    }

    

    public class ImageProcessorService
    {
        public const string GDILIC = "411897669724499821116142492193218";
        private GdPicture.GdPictureImaging g;
        public ImageProcessorService() {
            g = new GdPicture.GdPictureImaging();
            g.SetLicenseNumber(GDILIC);
        }


        public int SplitMultiTiff(string TifPath, string TempPath) {
            int count = 0;
            int id = g.CreateGdPictureImageFromFile(TifPath);
            if (id != 0)
            {
                if (!Directory.Exists(TempPath)) {
                    Directory.CreateDirectory(TempPath);
                }
                FileInfo fi = new FileInfo(TifPath);

                for (int i = 1; i <= g.TiffGetPageCount(id); i++) {

                    string name = fi.Name.Replace(fi.Extension,"") + i.ToString().PadLeft(4, '0') + fi.Extension;
                    name = Path.Combine(TempPath, name);
                    g.TiffSelectPage(id, i);

                    g.SaveAsTIFF(id, name, GdPicture.TiffCompression.TiffCompressionAUTO);
                    count++;
                }
                g.ReleaseGdPictureImage(id);

            }
            return count;
        }

        public void Rotate(string path, int angle) {
            FileInfo fi = new FileInfo(path);

            bool isJpg = path.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase) ||
                path.EndsWith(".jpeg", StringComparison.InvariantCultureIgnoreCase);


            if (isJpg)
            {

                switch (angle) {
                    case 90:
                        g.JPEGLosslessRotate90(path, path);
                        break;

                    case 270:
                        g.JPEGLosslessRotate270(path, path);
                        break;
                }

            }
            else {
                int i = g.CreateGdPictureImageFromFile(path);
                if (i != 0) {
                    g.RotateAngle(i, angle);
                    switch (fi.Extension.ToLower().TrimStart('.')) {
                        case "tiff":
                        case "tif":
                            g.SaveAsTIFF(i, path, GdPicture.TiffCompression.TiffCompressionAUTO);
                            break;

                        case "png":
                            g.SaveAsPNG(i, path);
                            break;

                        case "bmp":
                            g.SaveAsBMP(i, path);
                            break;

                        case "gif":
                            g.SaveAsGIF(i, path);
                            break;
                    }
                    
                    g.ReleaseGdPictureImage(i);
                }
            }
        }

        public ImageInfo GetImageInfo(string path) {
            ImageInfo info = null;
            int id = g.CreateGdPictureImageFromFile(path);
            
            if (id != 0)
            {
                FileInfo fi = new FileInfo(path);
                info = new ImageInfo();
                info.ColorDepth = g.GetBitDepth(id);
                info.Height = g.GetHeight(id);
                info.HRes = (int)g.GetHorizontalResolution(id);
                info.VRes = (int)g.GetVerticalResolution(id);
                info.Width = g.GetWidth(id);
                info.Extension = fi.Extension.ToLower();

                if (fi.Extension.EndsWith(".tif", StringComparison.InvariantCultureIgnoreCase) ||
                    fi.Extension.EndsWith(".tiff", StringComparison.InvariantCultureIgnoreCase)) {
                    info.IsMultiPage = g.TiffIsMultiPage(id);
                    if (info.IsMultiPage) {
                        info.PageCount = g.TiffGetPageCount(id);
                    }
                }
                g.ReleaseGdPictureImage(id);

            }

            return info;
        }


    }
}
