namespace PikaScan.Modelo
{
    public class ImageInfo
    {

        public ImageInfo() {
            IsMultiPage = false;
            PageCount = 1;
        }


        public int PageCount { get; set; }

        public bool IsMultiPage { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }

        public int ColorDepth { get; set; }

        public int HRes { get; set; }

        public int VRes { get; set; }

        public string Extension { get; set; }
    }
}
