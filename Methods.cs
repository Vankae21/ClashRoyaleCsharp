using System.Drawing;
using System.Drawing.Imaging;

namespace Vankae
{
    public class Methods
    {
        public Color GetPixelColor(int x, int y)
        {
            Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(0, 0, 0, 0, captureBitmap.Size);
            //Console.WriteLine(captureBitmap.GetPixel(x, y));
            Color colour = captureBitmap.GetPixel(x, y);
            captureBitmap.Dispose();
            captureGraphics.Dispose();
            return colour;
        }
    }
}