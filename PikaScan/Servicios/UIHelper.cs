using System;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;

namespace PikaScan
{
  
    public static class UIHelper
    {
        //private static WaitModal wm;

        public const string Version = "1.0.0";

        public static  void ShowNotification(string text, ToolTipIcon type) {

            //NotifyIcon nicon = ((MainDoc)Program.MainForm).MainNotifyIcon;

            //nicon.BalloonTipTitle = "";

            //switch (type) {
            //    case ToolTipIcon.Info:
            //        nicon.BalloonTipTitle = "Información";
            //        break;

            //    case ToolTipIcon.Warning:
            //        nicon.BalloonTipTitle = "Advertencia";
            //        break;

            //    case ToolTipIcon.Error:
            //        nicon.BalloonTipTitle = "Error";
            //        break;

            //    case ToolTipIcon.None:
            //        nicon.BalloonTipTitle = "";
            //        break;

             
            //}

            //nicon.BalloonTipIcon = type;
            //nicon.BalloonTipText = text;
            
            //nicon.ShowBalloonTip(1000);

        }

        static public Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }
        public static DialogResult Confirm(string info)
        {
            //ConfirmYesNo DialogYesNo = new ConfirmYesNo(info);
            //DialogResult r = DialogYesNo.ShowDialog();
            //DialogYesNo.Dispose();

            //return r;
            return DialogResult.Yes;
        }


        public static void Wait(bool ShowProgress)
        {

            //Program.MainForm.Enabled = false;
            //if (wm == null) { 
            //    wm=new WaitModal(ShowProgress);
            //}
            //wm.StartPosition = FormStartPosition.CenterScreen;
            //wm.TopMost = true;
            //wm.Show();

        }

        public static void SetWaitProgress(int min, int max, int current)
        {
            //if (wm != null)
            //{
            //    wm.SetProgress(min, max, current);
            //}

        }

        public static void WaitCancel()
        {
            //if (wm != null)
            //{
            //    wm.Close();
            //    wm.Dispose();
            //    wm = null;
            //}
       
            //Program.MainForm.Enabled = true;
            //Program.MainForm.TopMost = true;
            //Program.MainForm.BringToFront();
            //Program.MainForm.TopMost = false;
            //Program.MainForm.setDynHeights();
        }


        //public static CameraSettings GetCameraSetting(string Id) {

        //    return CameraSettings.AvailableCameras().Where(x => x.Id == Id).SingleOrDefault();
        //}

    }
}
