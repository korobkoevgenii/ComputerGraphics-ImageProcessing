using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace lab1cg
{
    class LinearTension:Filters
    {
        private float Rmin=255;
        private float Rmax=0;
        private float Gmin = 255;
        private float Gmax = 0;
        private float Bmin = 255;
        private float Bmax = 0;
        public void MaxMin(Bitmap sourceImage)
        {
            Color sourceColor1 = sourceImage.GetPixel(0, 0);
            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    if (sourceColor.R > Rmax)
                        Rmax = sourceColor.R;
                    if (sourceColor.R < Rmin)
                        Rmin = sourceColor.R;

                    if (sourceColor.G > Gmax)
                        Gmax = sourceColor.G;
                    if (sourceColor.G < Gmin)
                        Gmin = sourceColor.G;

                    if (sourceColor.B > Bmax)
                        Bmax = sourceColor.B;
                    if (sourceColor.B < Bmin)
                        Bmin = sourceColor.B;



                }
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            //LinearCorrection(sourceImage);
            Color sourceColor = sourceImage.GetPixel(x, y);
            float tempR =  (sourceColor.R - Rmin) * 255/(Rmax - Rmin) ;
            float tempG =  (sourceColor.G - Gmin) * 255/(Gmax - Gmin);
            float tempB =  (sourceColor.B - Bmin) * 255/(Bmax - Bmin) ;
            Color resultColor = Color.FromArgb(Clamp((int)tempR, 0, 255),
                Clamp((int)tempG, 0, 255),
                Clamp((int)tempB, 0, 255));
            return resultColor;
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            MaxMin(sourceImage);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }
    }
}
