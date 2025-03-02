using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class LinearMath
    {
        public int[] rowsHeading;
        public int[] colsHeading;
        public double[,] matrix;

        public LinearMath(int rows,int cols) 
        {
            matrix = new double[rows,cols];

            //тобто, я придумав таку систему: позитивні числа серед rowsHeading та rowsHeading - це икси,
            //негативні - ігрики
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                rowsHeading[i] = 1 + i * -1;
            }

            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                colsHeading[i] = 1 + i * 1;
            }
        }
    }
}
