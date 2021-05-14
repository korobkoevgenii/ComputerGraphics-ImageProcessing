using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1cg
{
    class Waves:Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int k, int l)
        {
            int newX = Clamp((k + (int)(20 * Math.Sin(2 * Math.PI * l / 60))), 0, sourceImage.Width-1);
            Color sourceColor = sourceImage.GetPixel(newX, l);
            Color resultColor = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
            return resultColor;
        }
    }
}
