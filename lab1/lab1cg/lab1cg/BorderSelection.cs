using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab1cg
{
    class BorderSelection:matrixFilter
    {
        protected float[,] kernelx = null;
        protected float[,] kernely = null;
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernelx.GetLength(0) / 2;
            int radiusY = kernely.GetLength(1) / 2;
            float resultXR = 0;
            float resultXG = 0;
            float resultXB = 0;
            float resultYR = 0;
            float resultYG = 0;
            float resultYB = 0;
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultXR += neighborColor.R * kernelx[k + radiusX, l + radiusY];
                    resultXG += neighborColor.G * kernelx[k + radiusX, l + radiusY];
                    resultXB += neighborColor.B * kernelx[k + radiusX, l + radiusY];
                }
            }
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultYR += neighborColor.R * kernely[k + radiusX, l + radiusY];
                    resultYG += neighborColor.G * kernely[k + radiusX, l + radiusY];
                    resultYB += neighborColor.B * kernely[k + radiusX, l + radiusY];
                }
            }

            return Color.FromArgb(Clamp((int)(Math.Sqrt(Math.Pow(resultXR, 2) + Math.Pow(resultYR, 2))), 0, 255), Clamp((int)(Math.Sqrt(Math.Pow(resultXG, 2) + Math.Pow(resultYG, 2))), 0, 255),
                Clamp((int)(Math.Sqrt(Math.Pow(resultXB, 2) + Math.Pow(resultYB, 2))), 0, 255));
        }
        public BorderSelection()
        {
            kernelx = new float[,] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
            kernely = new float[,] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
        }
    }
}

