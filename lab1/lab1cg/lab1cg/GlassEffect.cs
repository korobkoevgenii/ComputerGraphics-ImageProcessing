using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1cg
{
    class GlassEffect : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int k, int l)
        {
            Random rand = new Random();
            int rand1 = rand.Next(3);
            int rand2 = rand.Next(2);
            int newX = Clamp(k + (int)(rand1 - 0.5) * 10, 0, sourceImage.Width - 1);
            int newY = Clamp(l + (int)(rand2 - 0.5) * 10, 0, sourceImage.Height - 1);
            Color sourceColor = sourceImage.GetPixel(newX, newY);
            Color resultColor = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
            return resultColor;
        }
    }
}
