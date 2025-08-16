namespace PikaScan.Comandos
{
    public class CommandBrightContrast: Command
    {

        public int Brightness { get; set; }
        public int Contrast { get; set; }
        public int Gamma { get; set; }
        public int Saturation { get; set; }


        public CommandBrightContrast(int b, int c, int s, int g):base() {
            this.Brightness = b;
            this.Contrast = c;
            this.Saturation = s;
            this.Gamma = g;
            base.Type = CommandType.BrightContrast;
        }

    }
}
