using GdPicture;

namespace PikaScan.Servicios
{
    public class TWAINConfig
    {
        public string Source { get; set; }
        public bool Duplex { get; set; }
        public TwainCompression Compression { get; set; }
        public int Resolution { get; set; }
        public TwainPixelType PixelType { get; set; }
        public TwainImageFileFormats ImageFormat { get; set; }
        public bool AutoOrientation { get; set; }
        public bool MostrarUI { get; set; }

    }
}
