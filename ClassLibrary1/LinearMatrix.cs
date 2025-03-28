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
        public string[] rowsHeading2; //left headings2 - the most left one - anti task
        public string[] colsHeading; //top headings
        public string[] colsHeading2; //top headings2 - the most top one - anti task
        public double[,] matrix;
        public int variablesCount;
        public double[] res;      //calculated x`s
        public string[] integerVariables;

        public LinearMatrix(double[,] matrix, string[] rowsHeading, int variablesCount)
        {
            ArgumentNullException.ThrowIfNull(matrix);
            ArgumentNullException.ThrowIfNull(rowsHeading);
            ArgumentNullException.ThrowIfNull(variablesCount);

            this.matrix = matrix;
            this.rowsHeading = rowsHeading;
            this.colsHeading = new string[this.matrix.GetLength(1) - 1];

            for (int i = 0; i < this.matrix.GetLength(1) - 1; i++)
            {
                this.colsHeading[i] = $"x{1 + i * 1}";
            }

            this.variablesCount = variablesCount;
            this.res = new double[this.variablesCount];
        }

        public LinearMatrix(double[,] matrix, string[] rowsHeading, int variables, string[] integerVariables) : this(matrix, rowsHeading, variables)
        {
            ArgumentNullException.ThrowIfNull(integerVariables);
            this.integerVariables = integerVariables;
        }

        public LinearMatrix(double[,] matrix, string[] rowsHeading, string[] rowsHeading2, int variables) : this(matrix, rowsHeading, variables)
        {
            ArgumentNullException.ThrowIfNull(rowsHeading2);

            this.rowsHeading2 = rowsHeading2;
            this.colsHeading2 = new string[this.matrix.GetLength(1) - 1];
            for (int i = 0; i < this.matrix.GetLength(1) - 1; i++)
            {
                this.colsHeading2[i] = $"v{1 + i}";
            }
        }
    }
}
