using System;
using System.IO;
using System.Reflection;

namespace PikaScan.Servicios
{
    internal class AppSettings : IAppSettings
    {
        private string assemblyPath;
        public AppSettings()
        {
            assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public string AppPath { get => assemblyPath; }
        public string APIUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string JobPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastCameraId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DataPAgeSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ViewerBackColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Token { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string IdEmpleado { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PluginId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string HostName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
