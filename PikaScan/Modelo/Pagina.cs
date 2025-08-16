namespace PikaScan.Modelo
{

    public enum InputType
    {
        Batch = 0, Document = 1
    }

    public enum ColorDepth
    {
        Color = 1, BN = 2, Grayscale = 3
    }

    public enum SourceType
    {
        FileSystem = 0, Comera = 1, Scanner = 2
    }


    public class Pagina
    {

        public Pagina()
        {
            Index = 1;
            Width = 0;
            Height = 0;
            Name = "";
            this.DocId = "";
            ColorDepth = 0;
            HRes = 0;
            VRes = 0;
            Size = 0;
        }

        public Pagina(string DocId)
        {
            Index = 1;
            Width = 0;
            Height = 0;
            Name = "";
            this.DocId = DocId;
            ColorDepth = 0;
            HRes = 0;
            VRes = 0;
            Size = 0;
        }

        public string DocId { get; set; }

        public int Index { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Name { get; set; }

        public int ColorDepth { get; set; }

        public int HRes { get; set; }

        public int VRes { get; set; }

        public string Extension { get; set; }

        public int Size { get; set; }

        public SourceType Source { get; set; }

        public string GetNameFromIndex()
        {
            return Index.ToString().PadLeft(8, '0') + "." + Extension.TrimStart('.');
        }

    }
}