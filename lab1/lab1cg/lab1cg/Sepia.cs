using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1cg
{
    class Sepia:Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            float Intensity = 0.299f * sourceColor.R + 0.587f * sourceColor.G + 0.114f * sourceColor.B;
            int k = 30;
            double R = Intensity + 2 * k;
            double G = Intensity + (0.5 * k);
            double B = Intensity -1 * k;
            int clampR = Clamp((int)R, 0, 255);
            int clampG = Clamp((int)G, 0, 255);
            int clampB = Clamp((int)B, 0, 255);

            Color resultColor = Color.FromArgb(clampR, clampG, clampB);
            return resultColor;
        }
    }
}
