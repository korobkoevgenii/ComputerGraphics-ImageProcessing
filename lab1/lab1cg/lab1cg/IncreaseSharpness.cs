using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab1cg
{
    class IncreaseSharpness:matrixFilter
    {
        public IncreaseSharpness()
        {
            kernel = new float[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
        }
       
    }
}
