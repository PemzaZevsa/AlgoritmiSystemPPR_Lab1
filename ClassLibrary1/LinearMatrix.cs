using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class LinearMatrix
    {
        public int[] rowsHeading; //left headings
        public int[] colsHeading; //top headings
        public double[,] matrix;
        public int variablesCount;

        public LinearMatrix(double[,] vmatrix, int variables)
        {
            matrix = vmatrix;
            rowsHeading = new int[matrix.GetLength(0) - 1];
            colsHeading = new int[matrix.GetLength(1) - 1];

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

            this.variablesCount = variables;
        }

        public LinearMatrix(double[,] vmatrix, int[] vrowsHeading, int variables)
        {
            matrix = vmatrix;
            rowsHeading = vrowsHeading;
            colsHeading = new int[matrix.GetLength(1) - 1];

            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                colsHeading[i] = 1 + i * 1;
            }

            this.variablesCount = variables;
        }
    }
}
