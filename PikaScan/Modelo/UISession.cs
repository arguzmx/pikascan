
namespace PikaScan.Modelo
{

    public enum ImageSource
    {
        Camera = 0, FileSystem = 1, TWAINScanner = 2
    }

    public enum ActionSource
    {
        Camera = 0, FileSystem = 1, TWAINScanner = 2, OutputProcessor = 10
    }

    public static class UISession
    {
        public static void ClearSession()
        {

            UISession.Session = new Session() { Avatar = "", Disconnected = true, DisplayName = "Usuario", Password = "", Token = "", UserId = "", UserName = "" };
        }

        public static void ClearConfig()
        {
            UISession.SelectedCameraId = "";
            UISession.availableDisplays = 1;
            UISession.showThumbnails = true;
            UISession.AvailableCameras = 0;
            UISession.IdDoc = "";
            UISession.IdLote = "";
        }

        public static ActionSource SourceType { get; set; }


        public static int availableDisplays { get; set; }

        public static bool showThumbnails { get; set; }


        public static string IdLote { get; set; }

        public static string IdDoc { get; set; }


        public static string SelectedCameraId { get; set; }
        public static int AvailableCameras { get; set; }


        public static Session Session { get; set; }

    }
}
