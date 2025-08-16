using System;
using System.Windows.Forms;

namespace PikaScan
{
    internal static class Program
    {
        private static Form1 _mainForm; 
        public static Form1 GetMainForm()
        {
            return _mainForm;
        }

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string deeplink = args.Length > 0 ? args[0] : null;
            _mainForm = new Form1(deeplink);
            Application.Run(_mainForm);
        }
    }
}
