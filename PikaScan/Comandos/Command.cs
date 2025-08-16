namespace PikaScan.Comandos
{
    public abstract class Command
    {
        public enum CommandType {
            BrightContrast
        }

        public CommandType Type { get; set; }

    }
}
