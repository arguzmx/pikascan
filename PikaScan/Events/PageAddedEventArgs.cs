using PikaScan.Modelo;

namespace PikaScan.Events
{
    public class PageAddedEventArgs
    {
        public Pagina pagina { get; set; }

        public string  PagePath { get; set; }

        public bool DemoMode { get; set; }

        public int DeviceIndex { get; set; }
    }
}
