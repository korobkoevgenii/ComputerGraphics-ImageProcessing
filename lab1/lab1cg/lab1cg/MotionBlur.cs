using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1cg
{
    class MotionBlur:matrixFilter
    {
        public MotionBlur()
        {
            kernel = new float[,] { { 0.2f, 0, 0 ,0,0}, { 0, 0.2f, 0,0,0 }, { 0, 0, 0.2f,0,0 },{ 0,0,0,0.2f,0},{ 0,0,0,0,0.2f} };
        }
    }
}
