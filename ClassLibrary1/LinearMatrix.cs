﻿using System;
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
        //Lab 3_1
        public double k; //absolute value of minimal number in matrix
        public double[] firstP;
        public double[] secondP;
        public double[,] startMatrix;

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

        public LinearMatrix(double[,] matrix, string[] rowsHeading, string[] rowsHeading2, int variables, double k): this(matrix, rowsHeading, rowsHeading2, variables)
        {
            this.k = k;
            this.startMatrix = CloneMatrix(matrix);
        }

        private double[,] CloneMatrix(double[,] original)
        {
            int rows = original.GetLength(0);
            int cols = original.GetLength(1);
            double[,] clone = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    clone[i, j] = original[i, j];
                }
            }

            return clone;
        }
    }
}
