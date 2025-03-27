﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class LinearMatrixBuilder
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
                rowsHeadings2[i] = $"u{i}";
            }

            return new LinearMatrix(matrix, rowsHeadings, rowsHeadings2, variables.Length);
        }

    }
}
