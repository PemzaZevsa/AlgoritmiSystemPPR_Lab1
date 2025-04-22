using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ClassLibrary1
{
    public static class MatrixBuilder
    {
        //Lab 1.2

        public static double[,] CreateMatrix(int variblesAmount, string zText, string restrictionsText)
        {
            string zString = zText.Trim().ToLower();
            string[] restrictions = restrictionsText.Trim().Split('\n');

            int[] variables = VariablesRead(variblesAmount, zString);
            double[,] matrix = MatrixFill(variables, restrictions);
            return matrix;
        }

        public static int[] VariablesRead(int varAmount, string zString)
        {
            int[] variables = new int[varAmount];
            int tempVariable = 1;

            while (zString.Length > 0)
            {
                tempVariable = 1;

                //x value
                if (zString[0] == '-')
                {
                    tempVariable *= -1;
                    zString = zString.Substring(1);
                }

                if (zString[0] == '+')
                {
                    zString = zString.Substring(1);
                }

                string coeff = String.Empty;
                while (zString[0] != 'x')
                {
                    coeff += zString.Substring(0, 1);
                    zString = zString.Substring(1);
                }

                if (coeff != String.Empty)
                {
                    tempVariable *= int.Parse(coeff);
                }

                //remowe 'x'
                zString = zString.Substring(1);

                //x index
                string xIndex = string.Empty;
                while (zString.Length > 0 && zString[0] != '-' && zString[0] != '+')
                {
                    xIndex += zString.Substring(0, 1);
                    zString = zString.Substring(1);
                }

                try
                {
                    variables[int.Parse(xIndex) - 1] = tempVariable;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"При парсингу індексу 'x' виникла помилка:х{xIndex} не існує", ex);
                }
            }

            return variables;
        }

        public static double[,] MatrixFill(int[] variables, string[] rows)
        {
            double[,] matrix = new double[rows.Length + 1, variables.Length + 1];// rows.Length + 1 => zRow, variables.Length + 1 => right part

            for (int i = 0; i < rows.Length; i++)
            {
                int indexMoreOrEqual = rows[i].IndexOf(">=");
                int indexLessOrEqual = rows[i].IndexOf("<=");

                if (indexMoreOrEqual != -1)
                {
                    string[] rowParts = rows[i].Split(">=");
                    int[] vars = VariablesRead(variables.Length, rowParts[0]);

                    for (int j = 0; j < variables.Length; j++)
                    {
                        matrix[i, j] = vars[j] * -1;// *-1
                    }

                    matrix[i, variables.Length] = int.Parse(rowParts[1]) * -1;
                }

                if (indexLessOrEqual != -1)
                {
                    string[] rowParts = rows[i].Split("<=");
                    int[] vars = VariablesRead(variables.Length, rowParts[0]);

                    for (int j = 0; j < variables.Length; j++)
                    {
                        matrix[i, j] = vars[j]; //*-1
                    }

                    matrix[i, variables.Length] = int.Parse(rowParts[1]);
                }

            }

            for (int j = 0; j < variables.Length; j++)
            {
                matrix[rows.Length, j] = variables[j] * -1;
            }

            return matrix;
        }

        //Lab 1.3

        public static (double[,], string[]) MatrixAndHeadingsFill(int[] variables, string[] rows)
        {
            double[,] matrix = new double[rows.Length + 1, variables.Length + 1];// rows.Length + 1 => restictions + zRow, variables.Length + 1 => varables + ones column
            string[] rowHeadings = new string[rows.Length];

            //Основна матриця
            for (int i = 0, x = 1; i < rows.Length; i++)
            {
                int indexMoreOrEqual = rows[i].IndexOf(">=");
                int indexLessOrEqual = rows[i].IndexOf("<=");

                if (indexMoreOrEqual != -1)
                {
                    string[] rowParts = rows[i].Split(">=");
                    int[] vars = VariablesRead(variables.Length, rowParts[0]);

                    for (int j = 0; j < variables.Length; j++)
                    {
                        matrix[i, j] = vars[j] * -1;
                    }

                    matrix[i, variables.Length] = int.Parse(rowParts[1]) * -1;
                    rowHeadings[i] = $"y{x++}";
                }
                else if (indexLessOrEqual != -1)
                {
                    string[] rowParts = rows[i].Split("<=");
                    int[] vars = VariablesRead(variables.Length, rowParts[0]);

                    for (int j = 0; j < variables.Length; j++)
                    {
                        matrix[i, j] = vars[j];
                    }

                    matrix[i, variables.Length] = int.Parse(rowParts[1]);
                    rowHeadings[i] = $"y{x++}";
                }
                else
                {
                    string[] rowParts = rows[i].Split("=");
                    int[] vars = VariablesRead(variables.Length, rowParts[0]);

                    for (int j = 0; j < variables.Length; j++)
                    {
                        matrix[i, j] = vars[j];
                    }

                    matrix[i, variables.Length] = int.Parse(rowParts[1]);
                    rowHeadings[i] = "0";
                }
            }

            //Z-рядок
            for (int j = 0; j < variables.Length; j++)
            {
                matrix[rows.Length, j] = variables[j] * -1;
            }

            return (matrix, rowHeadings);
        }

        public static LinearMatrix CreateLinearMatrix(int variblesAmount, string zText, string restrictionsText)
        {
            string zString = zText.Trim().ToLower();
            string[] restrictions = restrictionsText.Trim().Split('\n');
            int[] variables = VariablesRead(variblesAmount, zString);
            (double[,] matrix, string[] rowsHeadings) = MatrixAndHeadingsFill(variables, restrictions);

            return new LinearMatrix(matrix, rowsHeadings, variables.Length);
        }

        //Lab 1.4

        public static LinearMatrix CreateLinearMatrix(int variblesAmount, string zText, string restrictionsText, string integerVariablesText)
        {
            string zString = zText.Trim().ToLower();
            string[] restrictions = restrictionsText.Trim().Split('\n');
            string[] integerVariables = integerVariablesText.Trim().Split(' ');
            int[] variables = VariablesRead(variblesAmount, zString);
            (double[,] matrix, string[] rowsHeadings) = MatrixAndHeadingsFill(variables, restrictions);

            return new LinearMatrix(matrix, rowsHeadings, variables.Length, integerVariables);
        }

        //Lab 2

        public static LinearMatrix CreateDoubleLinearMatrix(int variblesAmount, string zText, string restrictionsText)
        {
            string zString = zText.Trim().ToLower();
            string[] restrictions = restrictionsText.Trim().Split('\n');
            int[] variables = VariablesRead(variblesAmount, zString);
            (double[,] matrix, string[] rowsHeadings) = MatrixAndHeadingsFill(variables, restrictions);

            string[] rowsHeadings2 = new string[rowsHeadings.Length];
            for (int i = 0; i < rowsHeadings2.Length; i++)
            {
                rowsHeadings2[i] = $"u{i + 1}";
            }

            return new LinearMatrix(matrix, rowsHeadings, rowsHeadings2, variables.Length);
        }

        //Lab 3.1

        public static LinearMatrix CreateDoubleLinearMatrixLab3_1(string matrixText)
        {
            (double[,] matrix, string[] rowsHeadings, double k) = CreateMatrixLab3_1(matrixText);

            string[] rowsHeadings2 = new string[rowsHeadings.Length];
            for (int i = 0; i < rowsHeadings2.Length; i++)
            {
                rowsHeadings2[i] = $"u{i + 1}";
            }

            return new LinearMatrix(matrix, rowsHeadings, rowsHeadings2, matrix.GetLength(1) - 1, k);
        }

        public static (double[,], string[], double) CreateMatrixLab3_1(string matrixText)
        {
            string[] lines = matrixText.Trim().Split('\n');
            string[] rowHeadings = new string[lines.Length];
            int rowCount = lines.Length;
            
            int columnCount = lines[0].Split(' ').Length;
            double[,] matrix = new double[rowCount + 1, columnCount + 1];
            for (int i = 0; i < rowCount; i++)
            {
                string[] columns = lines[i].Trim().Split(' '); 
                for (int j = 0; j < columnCount; j++)
                {
                    matrix[i, j] = int.Parse(columns[j]);
                }
            }

            //calculating k
            double minimal = double.MaxValue;
            int matrixHeight = matrix.GetLength(0);
            int matrixWidth = matrix.GetLength(1);
            for (int i = 0; i < matrixHeight; i++)
            {
                for (int j = 0; j < matrixWidth; j++)
                {
                    if (matrix[i,j] < minimal)
                    {
                        minimal = matrix[i, j];
                    }
                }
            }

            if (minimal < 0) 
            {
                for (int i = 0; i < matrixHeight - 1; i++)
                {
                    for (int j = 0; j < matrixWidth - 1; j++)
                    {
                        matrix[i, j] += Math.Abs(minimal);
                    }
                }
            }

            //row headings 1
            for (int i = 0; i < rowCount; i++)
            {
                matrix[i, columnCount] = 1;
                rowHeadings[i] = $"y{i+1}";
            }

            //row headings 2
            for (int j = 0; j < columnCount; j++)
            {
                matrix[rowCount, j] = -1;
            }

            return (matrix, rowHeadings, Math.Abs(minimal));
        }

        //Lab 3.2

        public static double[,] CreateMatrixLab3_2(string matrixText)
        {
            string[] lines = matrixText.Trim().Split('\n');
            int rowCount = lines.Length;

            int columnCount = lines[0].Split(' ').Length;
            double[,] matrix = new double[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                string[] columns = lines[i].Trim().Split(' ');
                for (int j = 0; j < columnCount; j++)
                {
                    matrix[i, j] = int.Parse(columns[j]);
                }
            }

            return matrix;
        }

        public static double[] CreateArrayLab3_2(string arrayText)
        {
            int elementsCount = arrayText.Split(' ').Length;
            string[] elements = arrayText.Trim().Split(' ');

            double[] array = new double[elements.Length];
            for (int i = 0; i < elementsCount; i++)
            {
                array[i] = double.Parse(elements[i]);
            }

            return array;
        }

        //RR

        public static (string, int) ObjectFunctionForm(string functionText)
        {
            int flag = -1;
            if (functionText.Contains("max") || functionText.Contains("min"))
            {
                if (functionText.Contains("max"))
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                }
            }

            string zString = functionText.Trim().Substring(0,functionText.Length - 3);

            return (zString, flag);
        }

        public static LinearMatrix CreateDoubleLinearMatrixRR(double[,] inputMatrix)
        {
            (double[,] matrix, string[] rowsHeadings, double k) = CreateMatrixRR(inputMatrix);

            string[] rowsHeadings2 = new string[rowsHeadings.Length];
            for (int i = 0; i < rowsHeadings2.Length; i++)
            {
                rowsHeadings2[i] = $"u{i + 1}";
            }

            return new LinearMatrix(matrix, rowsHeadings, rowsHeadings2, matrix.GetLength(1) - 1, k);
        }

        private static (double[,] matrix, string[] rowsHeadings, double k) CreateMatrixRR(double[,] inputMatrix)
        {
            int rowCount = inputMatrix.GetLength(0);
            int columnCount = inputMatrix.GetLength(1);
            string[] rowHeadings = new string[rowCount];
            double[,] matrix = new double[rowCount + 1, columnCount + 1];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    matrix[i, j] = inputMatrix[i,j] * -1;
                }
            }

            //calculating k
            double minimal = double.MaxValue;
            int matrixHeight = matrix.GetLength(0);
            int matrixWidth = matrix.GetLength(1);
            for (int i = 0; i < matrixHeight; i++)
            {
                for (int j = 0; j < matrixWidth; j++)
                {
                    if (matrix[i, j] < minimal)
                    {
                        minimal = matrix[i, j];
                    }
                }
            }

            if (minimal < 0)
            {
                for (int i = 0; i < matrixHeight - 1; i++)
                {
                    for (int j = 0; j < matrixWidth - 1; j++)
                    {
                        matrix[i, j] += Math.Abs(minimal);
                    }
                }
            }

            //row headings 1 and matrix last column
            for (int i = 0; i < rowCount; i++)
            {
                matrix[i, columnCount] = 1;
                rowHeadings[i] = $"y{i + 1}";
            }

            //matrix last row
            for (int j = 0; j < columnCount; j++)
            {
                matrix[rowCount, j] = -1;
            }

            return (matrix, rowHeadings, Math.Abs(minimal));
        }

        //Lab 4

        public static T_Problem CreateT_Problem(string costText, string suppliesText, string applicationsText)
        {
            double[,] matrix = CreateMatrixLab3_2(costText);
            int[] po = CreateArrayLab3_2(suppliesText).Select(d => (int)d).ToArray();
            int[] pn = CreateArrayLab3_2(applicationsText).Select(d => (int)d).ToArray();

            return new T_Problem(po, pn, matrix);
        }
    }
}
