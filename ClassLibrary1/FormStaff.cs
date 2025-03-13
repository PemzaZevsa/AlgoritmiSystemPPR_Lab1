using System;
using System.Text;

namespace ClassLibrary1
{
    public static class FormStaff
    {
        public static void PrintProtocol(double[,] insertMatrix, StringBuilder protocolText, int step)
        {
            double solvingElement = insertMatrix[step, step];
            protocolText.AppendLine($"Крок №{step + 1}");
            protocolText.AppendLine($"Розв'язувальний елемент: A[{step},{step}] = {Math.Round(solvingElement, 3)}");

            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    if (insertMatrix[i, j] >= 0)
                    {
                        protocolText.Append(" ");
                    }

                    protocolText.Append(Math.Round(insertMatrix[i, j], 3) + "\t");
                }
                protocolText.AppendLine();
            }

            protocolText.AppendLine("\n");
        }

        public static void PrintProtocol(double[,] insertMatrix, StringBuilder protocolText, int step, int itaya, int jitaya)
        {
            double solvingElement = insertMatrix[itaya, jitaya];
            protocolText.AppendLine($"Крок №{step + 1}");
            protocolText.AppendLine($"Розв'язувальний елемент: A[{itaya},{jitaya}] = {Math.Round(solvingElement, 3)}");

            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    if (insertMatrix[i, j] >= 0)
                    {
                        protocolText.Append(" ");
                    }

                    protocolText.Append(Math.Round(insertMatrix[i, j], 3) + "\t");
                }
                protocolText.AppendLine();
            }

            protocolText.AppendLine("\n");
        }

        public static void PrintProtocol(double[,] matrix, int[] rowsHeading, int[] colsHeading, StringBuilder protocolText, int step, int itaya, int jitaya)
        {
            double solvingElement = matrix[itaya, jitaya];
            protocolText.AppendLine($"Крок №{step + 1}");
            protocolText.AppendLine($"Розв'язувальний елемент: A[{itaya},{jitaya}] = {Math.Round(solvingElement, 3)}");

            protocolText.Append($"\t");
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                string varible = colsHeading[j] > 0 ? "x" : colsHeading[j] < 0 ? "y" : "";
                protocolText.Append($"{varible}{Math.Abs(colsHeading[j])}\t");
            }
            protocolText.AppendLine($"1");

            for (int i = 0; i < matrix.GetLength(1) + 1; i++)
            {
                protocolText.Append($"---------\t");
            }
            protocolText.AppendLine($"");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i < matrix.GetLength(0) - 1)
                {
                    string varible = rowsHeading[i] > 0 ? "x" : rowsHeading[i] < 0 ? "y" : "";
                    protocolText.Append($"{varible}{Math.Abs(rowsHeading[i])} = \t");
                }
                else
                {
                    protocolText.Append($"Z = \t");
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    protocolText.Append($"{Math.Round(matrix[i, j], 3)}");
                    protocolText.Append("\t");
                }

                protocolText.AppendLine();
            }

            protocolText.AppendLine("\n");
        }

        public static void FancyMatrixPrint(LinearMatrix linearMatrix, StringBuilder protocolBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            protocolBuilder.AppendLine("Вивід матриці:");

            protocolBuilder.Append($"\t");
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                string varible = linearMatrix.colsHeading[j] > 0 ? "x" : linearMatrix.colsHeading[j] < 0 ? "y" : "";
                protocolBuilder.Append($"{varible}{Math.Abs(linearMatrix.colsHeading[j])}\t");
            }
            protocolBuilder.AppendLine($"1");

            for (int i = 0; i < matrix.GetLength(1) + 1; i++)
            {
                protocolBuilder.Append($"---------\t");
            }
            protocolBuilder.AppendLine($"");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i < matrix.GetLength(0) - 1)
                {
                    string varible = linearMatrix.rowsHeading[i] > 0 ? "x" : linearMatrix.rowsHeading[i] < 0 ? "y" : "";
                    protocolBuilder.Append($"{varible}{Math.Abs(linearMatrix.rowsHeading[i])} = \t");
                }
                else
                {
                    protocolBuilder.Append($"Z = \t");
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    protocolBuilder.Append($"{Math.Round(matrix[i, j], 3)}");
                    protocolBuilder.Append("\t");
                }

                protocolBuilder.AppendLine();
            }
        }

        public static void FancyMatrixPrint(LinearMatrix linearMatrix, int step, int itaya, int jitaya, StringBuilder protocolBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            double solvingElement = matrix[itaya, jitaya];

            protocolBuilder.AppendLine($"Крок №{step + 1}");
            protocolBuilder.AppendLine($"Розв'язувальний елемент: A[{itaya},{jitaya}] = {Math.Round(solvingElement, 3)}");

            protocolBuilder.Append($"\t");
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                string varible = linearMatrix.colsHeading[j] > 0 ? "x" : linearMatrix.colsHeading[j] < 0 ? "y" : "";
                protocolBuilder.Append($"{varible}{Math.Abs(linearMatrix.colsHeading[j])}\t");
            }
            protocolBuilder.AppendLine($"1");

            for (int i = 0; i < matrix.GetLength(1) + 1; i++)
            {
                protocolBuilder.Append($"---------\t");
            }
            protocolBuilder.AppendLine($"");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i < matrix.GetLength(0) - 1)
                {
                    string varible = linearMatrix.rowsHeading[i] > 0 ? "x" : linearMatrix.rowsHeading[i] < 0 ? "y" : "";
                    protocolBuilder.Append($"{varible}{Math.Abs(linearMatrix.rowsHeading[i])} = \t");
                }
                else
                {
                    protocolBuilder.Append($"Z = \t");
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    protocolBuilder.Append($"{Math.Round(matrix[i, j], 3)}");
                    protocolBuilder.Append("\t");
                }

                protocolBuilder.AppendLine();
            }
        }


    }
}
