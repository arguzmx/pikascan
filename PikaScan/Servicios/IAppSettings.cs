namespace PikaScan.Servicios
{
    public interface IAppSettings
    {

        string AppPath { get; }
        string APIUrl { get; set; }
        string JobPath { get; set; }
        string LastCameraId { get; set; }
        int DataPAgeSize { get; set; }
        string ViewerBackColor { get; set; }

        string User { get; set; }
        string Password { get; set; }

        string Token { get; set; }

        string IdEmpleado { get; set; }

        string PluginId { get; set; }

        string HostName { get; set; }

    }
}
