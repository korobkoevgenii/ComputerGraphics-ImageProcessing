using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace lab1cg
{
    class Erosion:Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(sourceColor.R,
                sourceColor.G, sourceColor.B);
            return resultColor;
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            int[,] mask = Filters.mask;
            int MW = mask.GetLength(0);
            int MH = mask.GetLength(1);
            for (int i = MH / 2; i < sourceImage.Height - MW / 2; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Height * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = MW / 2; j < sourceImage.Width - MH / 2; j++)
                {
                    Color min = Color.FromArgb(255, 255, 255);
                    for (int k = -MH / 2; k <= MH / 2; k++)
                        for (int l = -MW / 2; l <= MW / 2; l++)
                        {
                            Color sourceColor = sourceImage.GetPixel(l + j, k + i);
                            float Intensity = 0.299f * sourceColor.R + 0.587f * sourceColor.G + 0.114f * sourceColor.B;
                            float MinIntensity = 0.299f * min.R + 0.587f * min.G + 0.114f * min.B;
                            if ((mask[l + MW / 2, k + MH / 2] == 1) && (Intensity < MinIntensity))
                                min = sourceColor;
                        }
                    resultImage.SetPixel(j, i, min);
                }
            }

            return resultImage;
        }
    }
}
