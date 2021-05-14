using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab1cg
{
    class Rotation:Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color resultColor;
            double angle = (3.14-.57);
            int width = sourceImage.Width;
            int height = sourceImage.Height;
            int x0 =(int) (width / 2);
            int y0 = (int)(height / 2);
            int newx =Clamp((int)((x - x0) * Math.Cos(angle) - (y - y0) * Math.Sin(angle) + x0),0,width-1);
            int newy = Clamp((int)((x - x0) * Math.Sin(angle) - (y - y0) * Math.Cos(angle) + x0), 0, width - 1);


            if ((newx == width) || (newx == 0) || (newy == height) || (newy == 0))
                resultColor = Color.Black;
            else
                resultColor = sourceImage.GetPixel(newx, newy);




            return resultColor;
        }
    }
}
