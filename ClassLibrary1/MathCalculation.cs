using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class MathCalculation
    {
        public static double[,] DifficultMathStaff(double[,] insertMatrix, int k)
        {
            double[,] tempMatrix = new double[insertMatrix.GetLength(0), insertMatrix.GetLength(1)];

            //copy
            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    tempMatrix[i, j] = insertMatrix[i, j];
                }
            }

            double ars = tempMatrix[k, k];
            insertMatrix[k, k] = 1;

            //main row
            for (int i = 0; i < insertMatrix.GetLength(1); i++)
            {
                if (k != i)
                {
                    insertMatrix[k, i] = -tempMatrix[k, i];
                }
            }

            //other rows
            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                if (i == k) continue;

                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    if (j == k) continue;
                    insertMatrix[i, j] = tempMatrix[i, j] * tempMatrix[k, k] - tempMatrix[k, j] * tempMatrix[i, k];
                }
            }

            //division
            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    insertMatrix[i, j] /= tempMatrix[k, k];
                }
            }

            return insertMatrix;
        }

        public static double[,] CopyArray(double[,] source)
        {
            int rows = source.GetLength(0);
            int cols = source.GetLength(1);
            double[,] destination = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    destination[i, j] = source[i, j];
                }
            }

            return destination;
        }

        public static int MatrixRank(double[,] insertMatrix)
        {
            double[,] rankMatrix = new double[insertMatrix.GetLength(0), insertMatrix.GetLength(1)];

            //copy
            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    rankMatrix[i, j] = insertMatrix[i, j];
                }
            }

            //calculate
            int rank = 0;
            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                if (rankMatrix[i, i] == 0)
                {
                    continue;
                }

                rankMatrix = DifficultMathStaff(rankMatrix, i);
                rank++;
            }

            return rank;
        }

        public static double[,] InverseMatrix(double[,] insertMatrix, out string protocol)
        {
            double[,] inverseMatrix = new double[insertMatrix.GetLength(0), insertMatrix.GetLength(1)];

            //copy
            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    inverseMatrix[i, j] = insertMatrix[i, j];
                }
            }

            //calculate
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                inverseMatrix = DifficultMathStaff(inverseMatrix, i);
                FormStaff.PrintProtocol(inverseMatrix, stringBuilder, i);
            }

            protocol = stringBuilder.ToString();
            return inverseMatrix;
        }

        public static double[] SLAU(double[] insertArray, double[,] incertMatrix)
        {
            double[] xMatrix = new double[insertArray.GetLength(0)];
            for (int i = 0; i < insertArray.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < incertMatrix.GetLength(1); j++)
                {
                    sum += incertMatrix[i, j] * insertArray[j];
                }

                xMatrix[i] = sum;
            }

            return xMatrix;
        }
    }
}
