using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1cg
{
    class Shift:Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int k = x+50;
            Color resultColor;
            if (sourceImage.Width > k)
            {
                Color sourceColor = sourceImage.GetPixel( k, y);
                 resultColor = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
            }
            else
            {
                resultColor = Color.Black;
            }
                
           
            return resultColor;
        }
    }
}
