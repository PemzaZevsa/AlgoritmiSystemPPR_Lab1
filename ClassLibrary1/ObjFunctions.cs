using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ObjFunctions(double[,] matrix, bool[] extremes)
    {
        public double[,] matrix = matrix;
        public bool[] extremes = extremes; //0 - min, 1 - max
    }
}
