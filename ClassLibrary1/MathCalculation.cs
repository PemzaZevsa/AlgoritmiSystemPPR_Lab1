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
            double[,] tempMatrix = CopyArray(insertMatrix);

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
            double[,] rankMatrix = CopyArray(insertMatrix);

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

        public static double[,] InverseMatrix(double[,] insertMatrix, StringBuilder stringBuilder)
        {
            double[,] inverseMatrix = CopyArray(insertMatrix);

            //calculate
            for (int i = 0; i < 3; i++)
            {
                inverseMatrix = DifficultMathStaff(inverseMatrix, i);
                FormStaff.PrintProtocol(inverseMatrix, stringBuilder, i);
            }

            return inverseMatrix;
        }

        public static double[] SLAU(double[] insertArray, double[,] incertMatrix, StringBuilder stringBuilder)
        {
            double[] xMatrix = new double[insertArray.GetLength(0)];
            stringBuilder.AppendLine($"Обчислення розв'язків:");
            for (int i = 0; i < insertArray.GetLength(0); i++)
            {
                stringBuilder.Append($"X[{i}] = ");

                double sum = 0;
                for (int j = 0; j < incertMatrix.GetLength(1); j++)
                {
                    sum += incertMatrix[i, j] * insertArray[j];
                    stringBuilder.Append($"{Math.Round(incertMatrix[i, j],2)} * {Math.Round(insertArray[j],2)} ");

                    if (j < incertMatrix.GetLength(1)-1)
                    {
                        stringBuilder.Append($"+ ");
                    }
                }

                xMatrix[i] = sum;
                stringBuilder.AppendLine($"= {sum}");
            }

            stringBuilder.AppendLine($"\n");
            return xMatrix;
        }

        public static double[,] GenerateMatrix(int rows, int cols)
        {
            double[,] newMatrix = new double[rows, cols];

            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[i, j] = random.Next(1, 10); // [1-9]
                }
            }

            return newMatrix;
        }
    }
}
