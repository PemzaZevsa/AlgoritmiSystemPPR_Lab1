using System;
using System.Text;

namespace ClassLibrary1
{
    public static class MathCalculation
    {
        public static double[,] GenerateMatrix(int rows, int cols, int min, int max)
        {
            double[,] newMatrix = new double[rows, cols];

            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[i, j] = random.Next(min, max+1);
                }
            }

            return newMatrix;
        }

        public static double[] GenerateArray(int rows, int min, int max)
        {
            double[] newArray = new double[rows];

            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                newArray[i] = random.Next(min, max + 1);              
            }

            return newArray;
        }
        public static double[,] DifficultMathStaff(double[,] insertMatrix, int k)
        {
            double[,] tempMatrix = CopyMatrix(insertMatrix);

            if (tempMatrix[k, k] == 0)
            {
                int swapRow = -1;
                for (int i = k + 1; i < insertMatrix.GetLength(0); i++)
                {
                    if (tempMatrix[i, k] != 0)
                    {
                        swapRow = i;
                        break;
                    }
                }

                if (swapRow == -1)
                {
                    throw new InvalidOperationException("У столбці тільки нулі");
                }

                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    double temp = insertMatrix[k, j];
                    insertMatrix[k, j] = insertMatrix[swapRow, j];
                    insertMatrix[swapRow, j] = temp;
                }

                tempMatrix = CopyMatrix(insertMatrix); 
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
                    insertMatrix[i, j] /= ars;
                }
            }

            return insertMatrix;
        }
        public static double[,] DifficultMathStaffOLD(double[,] insertMatrix, int k)
        {
            double[,] tempMatrix = CopyMatrix(insertMatrix);

            //double ars = tempMatrix[k, k];
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

        public static double[,] CopyMatrix(double[,] source)
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

        public static double[] CopyArray(double[] source)
        {
            int rows = source.GetLength(0);
            double[] destination = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                destination[i] = source[i];
            }

            return destination;
        }

        public static int MatrixRank(double[,] insertMatrix)
        {
            int n = insertMatrix.GetLength(0);
            int m = insertMatrix.GetLength(1);
            double[,] rankMatrix = CopyMatrix(insertMatrix);

            int rank = 0;
            for (int i = 0; i < Math.Min(n, m); i++)
            {
                if (rankMatrix[i, i] != 0)
                {
                    rankMatrix = DifficultMathStaff(rankMatrix, i);
                    rank++;
                }
            }

            return rank;
        }

        public static double[,] InverseMatrix(double[,] insertMatrix, StringBuilder stringBuilder)
        {
            double[,] inverseMatrix = CopyMatrix(insertMatrix);

            for (int i = 0; i < inverseMatrix.GetLength(0); i++)
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
                    try
                    {
                        sum += incertMatrix[i, j] * insertArray[j];
                        stringBuilder.Append($"{Math.Round(incertMatrix[i, j], 2)} * {Math.Round(insertArray[j], 2)} ");

                        if (j < incertMatrix.GetLength(1) - 1)
                        {
                            stringBuilder.Append($"+ ");
                        }
                    }
                    catch (Exception ex)
                    {
                        stringBuilder.AppendLine(ex.Message);
                    }
                }

                xMatrix[i] = sum;
                stringBuilder.AppendLine($"= {Math.Round(sum,2)}");
            }

            stringBuilder.AppendLine($"\n");
            return xMatrix;
        }

    }
}
