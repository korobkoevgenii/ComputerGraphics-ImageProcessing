using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace lab1cg
{
   
        abstract class Filters
        {
            public static Stack<Bitmap> MyStack = new Stack<Bitmap>();
            public static int[,] mask = { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            static public void ChangeMask(int[,] arr)
        {
            mask = arr;

        }
            protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);
            public int Clamp(int value,int min,int max)
            {
                if (value < min)
                    return min;
                if (value > max)
                    return max;
                return value;
            }
            virtual public Bitmap processImage(Bitmap sourceImage,BackgroundWorker worker)
            {
                Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
                for(int i = 0; i < sourceImage.Width; i++)
                {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                    for(int j=0; j < sourceImage.Height; j++)
                    {
                        resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                    }
                }

                return resultImage;
            }
            public int Intensity(Color sourceColor)
        {
            float Intensity = 0.299f * sourceColor.R + 0.587f * sourceColor.G + 0.114f * sourceColor.B;
            Color resultColor = Color.FromArgb((int)Intensity, (int)Intensity, (int)Intensity);
            return resultColor.R;
        }
        
        }
  
}
