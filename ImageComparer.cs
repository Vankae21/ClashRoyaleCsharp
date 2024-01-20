using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;

namespace Vankae
{
    internal class ImageComparer
    {
        public bool IsSuitable { get; private set; }
        public double Percentage { get; private set; }
        public Point Location { get; private set; }
        private string _templatePath;
        public ImageComparer(string templatePath)
        {
            _templatePath = templatePath;
        }
        public void Compare()
        {
                        // Load the template image
            Image<Bgr, byte> templateImage = new Image<Bgr, byte>(_templatePath);
            Bitmap captureBitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(0, 0, 0, 0, captureBitmap.Size);

            
            var desktopImage = captureBitmap.ToImage<Bgr, byte>();

            // Create a template matching object
            Image<Gray, float> matchResult = desktopImage.MatchTemplate(templateImage, TemplateMatchingType.CcoeffNormed);
                // Get the location of the best match
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                matchResult.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // Draw a rectangle around the best match
                Rectangle bestMatchRect = new Rectangle(maxLocations[0], templateImage.Size);
                desktopImage.Draw(bestMatchRect, new Bgr(Color.Red), 2);
                // Console.WriteLine(maxValues[0]);
                captureBitmap.Dispose();
                captureGraphics.Dispose();
                desktopImage.Dispose();
                matchResult.Dispose();
                
                IsSuitable = maxValues[0] > 0.67 ? true : false;
                Location = maxLocations[0];
                Percentage = maxValues[0];
            // Display the result
            // CvInvoke.Imshow("Desktop with template match", desktopImage);
            // CvInvoke.WaitKey(0);
        }
    }
}