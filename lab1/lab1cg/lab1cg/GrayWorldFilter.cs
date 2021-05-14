using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace lab1cg
{
    class GrayWorldFilter:Filters
    {
        private float averageR = 0;
        private float averageG = 0;
        private float averageB = 0;
        public Color AverageBrightness(Bitmap sourceImage)
        {
			for (int i = 0; i < sourceImage.Width; i++)
				for (int j = 0; j < sourceImage.Height; j++)
				{
					Color sourceColor = sourceImage.GetPixel(i, j);
					averageR += sourceColor.R;
					averageG += sourceColor.G;
					averageB += sourceColor.B;
				}
			averageR /= (sourceImage.Width * sourceImage.Height);
			averageG /= (sourceImage.Width * sourceImage.Height);
			averageB /= (sourceImage.Width * sourceImage.Height);
            Math.Round(averageR, 1);
            Math.Round(averageG, 1);
            Math.Round(averageB, 1);
            Color resultColor = Color.FromArgb((int)averageR,
												(int)averageG,
												(int)averageB);
			return resultColor;
		}
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
			float Avg = (averageR + averageG + averageB) / 3;
            Math.Round(Avg, 1);
			Color sourceColor = sourceImage.GetPixel(x, y);
            float tempR = Avg / averageR;
            float tempG = Avg / averageG;
            float tempB = Avg / averageB;
            Math.Round(tempR, 1);
            Math.Round(tempG, 1);
            Math.Round(tempB, 1);
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R * (int)(tempR), 0, 255),
				Clamp(sourceColor.G * (int)(tempG), 0, 255),
				Clamp(sourceColor.B * (int)(tempB), 0, 255));
			return resultColor;
		}
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            AverageBrightness(sourceImage);
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
