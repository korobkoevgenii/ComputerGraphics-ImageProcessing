using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1cg
{
    class IncreaseBrightness:Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int k = 15;
            int clampR = Clamp(sourceColor.R + k, 0, 255);
            int clampG = Clamp(sourceColor.G + k, 0, 255);
            int clampB = Clamp(sourceColor.B + k, 0, 255);
            Color resultColor = Color.FromArgb(clampR, clampG,clampB);
            return resultColor;
        }
    }
}
