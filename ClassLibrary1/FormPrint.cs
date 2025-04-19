using System;
using System.Text;

namespace ClassLibrary1
{
    public static class FormPrint
    {
        //Lab 1.1

        public static double[,] ReadMatrixFromRichTextBox(string inputRichTextBox, StringBuilder protocolText)
        {
            //string[] rows = inputRichTextBox.Text.Trim().Split('\n');
            string[] rows = inputRichTextBox.Trim().Split('\n');
            string[] firstRowElements = rows[0].Trim().Split(' ');

            int rowCount = rows.Length;
            int colCount = firstRowElements.Length;
            double[,] matrix = new double[rowCount, colCount];

            try
            {
                for (int i = 0; i < rowCount; i++)
                {
                    string[] elements = rows[i].Trim().Split(' ');

                    for (int j = 0; j < colCount; j++)
                    {
                        matrix[i, j] = double.Parse(elements[j]);
                    }
                }

            }
            catch (Exception ex)
            {
                protocolText.AppendLine($"{ex.Message}");
            }

            return matrix;
        }

        public static double[] ReadMatrixBFromRichTextBox(string inputRichTextBox, StringBuilder protocolText)
        {
            //string[] elements = inputRichTextBox.Text.Trim().Split('\n');
            string[] elements = inputRichTextBox.Trim().Split('\n');
            double[] array = new double[elements.Length];

            try
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    array[i] = double.Parse(elements[i]);
                }
            }
            catch (Exception ex)
            {
                protocolText.AppendLine($"{ex.Message}");
            }

            return array;
        }

        public static void MatrixPrint(double[,] incertMatrix, StringBuilder protocolText)
        {
            //protocolText.Clear();

            for (int i = 0; i < incertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < incertMatrix.GetLength(1); j++)
                {
                    protocolText.Append(Math.Round(incertMatrix[i, j], 3));
                    protocolText.Append(" ");
                }

                protocolText.AppendLine();
            }
        }

        public static void ProtocolMatrixPrint(double[,] incertMatrix, StringBuilder protocolText)
        {
            for (int i = 0; i < incertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < incertMatrix.GetLength(1); j++)
                {
                    protocolText.Append(Math.Round(incertMatrix[i, j], 3));
                    protocolText.Append("\t");
                }

                protocolText.AppendLine();
            }
        }

        public static void ArrayPrint(double[] incertMatrix, StringBuilder protocolText)
        {
            for (int i = 0; i < incertMatrix.GetLength(0); i++)
            {
                protocolText.Append(Math.Round(incertMatrix[i], 3));
                protocolText.AppendLine();
            }
        }

        public static void FancyPrintMatrixOnRichTextBox(double[,] incertMatrix, StringBuilder protocolText)
        {
            for (int i = 0; i < incertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < incertMatrix.GetLength(1); j++)
                {
                    protocolText.Append(Math.Round(incertMatrix[i, j], 3));
                    protocolText.Append("\t");
                }
                protocolText.AppendLine();
            }
        }

        //Lab 1.2

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

        //Lab 1.3

        public static void FancyMatrixPrint(LinearMatrix linearMatrix, StringBuilder protocolBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            protocolBuilder.AppendLine("Вивід матриці:");

            protocolBuilder.Append($"\t");
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                protocolBuilder.Append($"-{linearMatrix.colsHeading[j]}\t");
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
                    protocolBuilder.Append($"{linearMatrix.rowsHeading[i]} = \t");
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

        public static void FancyMatrixPrint(LinearMatrix linearMatrix, int step, int itaya, int jitaya, double solvingElement, StringBuilder protocolBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            //double solvingElement = matrix[itaya, jitaya];

            protocolBuilder.AppendLine($"Крок №{step + 1}");
            protocolBuilder.AppendLine($"Розв'язувальний елемент: A[{itaya},{jitaya}] = {Math.Round(solvingElement, 3)}");

            protocolBuilder.Append($"\t");
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                protocolBuilder.Append($"-{linearMatrix.colsHeading[j]}\t");
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
                    protocolBuilder.Append($"{linearMatrix.rowsHeading[i]} = \t");
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

        //Lab 1.4

        public static void FancyDoubleMatrixPrint(LinearMatrix linearMatrix, StringBuilder protocolBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            protocolBuilder.AppendLine("Вивід матриці:");

            protocolBuilder.Append($"\t\t");
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                protocolBuilder.Append($"{linearMatrix.colsHeading2[j]}\t");
            }
            protocolBuilder.AppendLine($"W");

            protocolBuilder.Append($"\t\t");
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                protocolBuilder.Append($"-{linearMatrix.colsHeading[j]}\t");
            }
            protocolBuilder.AppendLine($"1");

            for (int i = 0; i < matrix.GetLength(1) + 2; i++)
            {
                protocolBuilder.Append($"---------\t");
            }
            protocolBuilder.AppendLine($"");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i < matrix.GetLength(0) - 1)
                {
                    protocolBuilder.Append($"{linearMatrix.rowsHeading2[i]}\t {linearMatrix.rowsHeading[i]} = \t");
                }
                else
                {
                    protocolBuilder.Append($"1\tZ = \t");
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    protocolBuilder.Append($"{Math.Round(matrix[i, j], 3)}");
                    protocolBuilder.Append("\t");
                }

                protocolBuilder.AppendLine();
            }
        }

        public static void FancyDoubleMatrixPrint(LinearMatrix linearMatrix, int step, int itaya, int jitaya, double solvingElement, StringBuilder protocolBuilder)
        {
            double[,] matrix = linearMatrix.matrix;

            protocolBuilder.AppendLine($"Крок №{step + 1}");
            protocolBuilder.AppendLine($"Розв'язувальний елемент: A[{itaya},{jitaya}] = {Math.Round(solvingElement, 3)}");

            protocolBuilder.Append($"\t\t");
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                protocolBuilder.Append($"{linearMatrix.colsHeading2[j]}\t");
            }
            protocolBuilder.AppendLine($"W");

            protocolBuilder.Append($"\t\t");
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                protocolBuilder.Append($"-{linearMatrix.colsHeading[j]}\t");
            }
            protocolBuilder.AppendLine($"1");

            for (int i = 0; i < matrix.GetLength(1) + 2; i++)
            {
                protocolBuilder.Append($"---------\t");
            }
            protocolBuilder.AppendLine($"");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i < matrix.GetLength(0) - 1)
                {
                    protocolBuilder.Append($"{linearMatrix.rowsHeading2[i]}\t {linearMatrix.rowsHeading[i]} = \t");
                }
                else
                {
                    protocolBuilder.Append($"1\tZ = \t");
                }

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    protocolBuilder.Append($"{Math.Round(matrix[i, j], 3)}");
                    protocolBuilder.Append("\t");
                }

                protocolBuilder.AppendLine();
            }
        }

        //RR

        public static void FancyMatrixPrint(double[,] matrix, string rowsChar, string colsChar, StringBuilder protocolBuilder)
        {
            string[] colsHeading = new string[matrix.GetLength(1)];
            for (int i = 0; i < colsHeading.Length; i++)
            {
                colsHeading[i] = colsChar + $"{ i + 1}";
            }

            string[] rowsHeading = new string[matrix.GetLength(0)];
            for (int i = 0; i < rowsHeading.Length; i++)
            {
                rowsHeading[i] = rowsChar + $"{i + 1}";
            }

            protocolBuilder.AppendLine("Вивід матриці:");
            protocolBuilder.Append($"\t");
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                protocolBuilder.Append($"{colsHeading[j]}\t");
            }
            protocolBuilder.AppendLine($"");

            for (int i = 0; i < matrix.GetLength(1) + 1; i++)
            {
                protocolBuilder.Append($"---------\t");
            }
            protocolBuilder.AppendLine($"");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                protocolBuilder.Append($"{rowsHeading[i]} = \t");
                

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
