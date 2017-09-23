using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BaseLibrary.Util
{
    public class ScreenShot
    {
        public static void Shot(string filename)
        {
            var screenshot = new Bitmap(SystemInformation.VirtualScreen.Width,
                SystemInformation.VirtualScreen.Height,
                PixelFormat.Format32bppArgb);

            var screenGraph = Graphics.FromImage(screenshot);
            screenGraph.CopyFromScreen(SystemInformation.VirtualScreen.X,
                SystemInformation.VirtualScreen.Y,
                0,
                0,
                SystemInformation.VirtualScreen.Size,
                CopyPixelOperation.SourceCopy);


            var dir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            screenshot.Save($@"{dir}\{filename}.png", ImageFormat.Png);
        }
    }
}