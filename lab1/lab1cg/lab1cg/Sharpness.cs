using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1cg
{
    class Sharpness: matrixFilter
    {
        public Sharpness()
        {
            kernel = new float[,] { { -1,-1,-1},{ -1, 9, -1 },{ -1,-1,-1} };
        }
    }
}
