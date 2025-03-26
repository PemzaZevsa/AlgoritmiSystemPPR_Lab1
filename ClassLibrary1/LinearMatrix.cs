using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class LinearMatrix
    {
        public string[] rowsHeading; //left headings
        public string[] colsHeading; //top headings
        public double[,] matrix;
        public int variablesCount;
        public double[] res;      //calculated x`s
        public string[] integerVariables;

        public LinearMatrix(double[,] vmatrix, string[] vrowsHeading, int variables)
        {
            this.matrix = vmatrix;
            this.rowsHeading = vrowsHeading;
            this.colsHeading = new string[matrix.GetLength(1) - 1];

            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                this.colsHeading[i] = $"x{1 + i * 1}";
            }

            this.variablesCount = variables;
            this.res = null;
            this.integerVariables = null;
        }
    }
}
