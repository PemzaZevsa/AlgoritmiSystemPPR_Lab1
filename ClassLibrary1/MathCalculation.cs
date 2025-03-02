using Microsoft.VisualBasic;
using System;
using System.Text;

namespace ClassLibrary1
{
    public static class MathCalculation
    {
        //lab 1.1
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

        public static double[,] DifficultMathStaff(double[,] insertMatrix, int r, int s)
        {
            double[,] tempMatrix = CopyMatrix(insertMatrix);

           
                if (tempMatrix[r, s] == 0)
                {
                    int swapRow = -1;
                    for (int i = r + 1; i < insertMatrix.GetLength(0); i++)
                    {
                        if (tempMatrix[i, r] != 0)
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
                        double temp = insertMatrix[r, j];
                        insertMatrix[r, j] = insertMatrix[swapRow, j];
                        insertMatrix[swapRow, j] = temp;
                    }

                    tempMatrix = CopyMatrix(insertMatrix);
                }
            

            double ars = tempMatrix[r, s];

            insertMatrix[r, s] = 1;

            //main row
            for (int i = 0; i < insertMatrix.GetLength(1); i++)
            {
                if (r != i)
                {
                    insertMatrix[r, i] = -tempMatrix[r, i];
                }
            }
            //other rows
            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                if (i == r) continue;

                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    if (j == r) continue;
                    insertMatrix[i, j] = tempMatrix[i, j] * tempMatrix[r, s] - tempMatrix[r, j] * tempMatrix[i, s];
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

        public static int MatrixRank(double[,] insertMatrix, StringBuilder stringBuilder)
        {
            int n = insertMatrix.GetLength(0);
            int m = insertMatrix.GetLength(1);
            double[,] rankMatrix = CopyMatrix(insertMatrix);

            int rank = 0;
            for (int i = 0; i < Math.Max(n, m); i++)
            {
                int itaya = i < n - 1? i : n - 1;
                int jitaya = i < m - 1? i : m - 1;

                if (rankMatrix[itaya, jitaya] != 0)
                {
                    try
                    {
                        rankMatrix = DifficultMathStaff(rankMatrix, itaya, jitaya);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    FormStaff.PrintProtocol(rankMatrix, stringBuilder, i, itaya, jitaya);
                    rank++;
                }
            }

            return rank;

            //int n = insertMatrix.GetLength(0);
            //int m = insertMatrix.GetLength(1);
            //double[,] rankMatrix = CopyMatrix(insertMatrix);

            //int rank = 0;
            //for (int i = 0; i < Math.Min(n, m); i++)
            //{
            //    if (rankMatrix[i, i] != 0)
            //    {
            //        rankMatrix = DifficultMathStaff(rankMatrix, i);
            //        FormStaff.PrintProtocol(rankMatrix, stringBuilder, i);
            //        rank++;
            //    }
            //}

            //return rank;
        }

        public static double[,] InverseMatrix(double[,] insertMatrix, StringBuilder stringBuilder)
        {
            double[,] inverseMatrix = CopyMatrix(insertMatrix);

            for (int i = 0; i < inverseMatrix.GetLength(0); i++)
            {
                try
                {
                    inverseMatrix = DifficultMathStaff(inverseMatrix, i, i);

                }
                catch (Exception)
                {
                    throw;
                }
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

        //lab 1.2
        public static double[,] ModifiedZhordansExeptions(double[,] insertMatrix, int row, int col)
        {
            double[,] tempMatrix = CopyMatrix(insertMatrix);

            if (tempMatrix[row, col] == 0)
            {
                int swapRow = -1;
                for (int i = row + 1; i < insertMatrix.GetLength(0); i++)
                {
                    if (tempMatrix[i, row] != 0)
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
                    double temp = insertMatrix[row, j];
                    insertMatrix[row, j] = insertMatrix[swapRow, j];
                    insertMatrix[swapRow, j] = temp;
                }

                tempMatrix = CopyMatrix(insertMatrix);
            }

            double ars = tempMatrix[row, col];

            //main col
            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                insertMatrix[i, col] = -tempMatrix[i, col];
            }
            insertMatrix[row, col] = 1;

            //other cols
            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                if (i == row) continue;

                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    if (j == col) continue;
                    insertMatrix[i, j] = tempMatrix[i, j] * tempMatrix[row, col] - tempMatrix[row, j] * tempMatrix[i, col];
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
                    //stringBuilder.AppendLine(ex.Message);
                    //stringBuilder.AppendLine($"х{xIndex} не існує");
                }
            }

            return variables;
        }

        public static double[] SupportSolution(ref double[,] matrix, StringBuilder stringBuilder, out int[] rowsHeading, out int[] colsHeading)
        {
            double[] res = new double[matrix.GetLength(1) - 1];
            rowsHeading = new int[matrix.GetLength(0) - 1];
            colsHeading = new int[matrix.GetLength(1) - 1];

            //rowsHeading and colsHeading filling
            //тобто, я придумав таку систему: позитивні числа серед rowsHeading та rowsHeading - це икси,
            //негативні - ігрики
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                rowsHeading[i] = 1 + i * -1;
            }

            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                colsHeading[i] = 1 + i * 1;
            }

            //negative numer search
            double firstNegativeNumber = 0;
            int pickedRow = -1;
            for (int i = 0; i < matrix.GetLength(0) - 1; i++) //GetLength(0) - 1 => until rigth-bottom zero  
            {
                if (matrix[i, matrix.GetLength(1) - 1] < 0)
                {
                    firstNegativeNumber = matrix[i, matrix.GetLength(1) - 1];
                    pickedRow = i;
                    break;
                }
            }

            //if no negative values in одиничному стовпці
            if (firstNegativeNumber == 0)
            {
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    if (rowsHeading[i] > 0)
                    {
                        res[rowsHeading[i] - 1] = matrix[i, matrix.GetLength(1) - 1];
                    }
                }

                return res;
            }

            int iteration = 0;
            do
            {
                //negative number search in picked row
                double rowNegativeNumber = 0;
                int pickedCol = -1;

                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[pickedRow, j] < 0)
                    {
                        rowNegativeNumber = matrix[pickedRow, j];
                        pickedCol = j;
                        MatrixElementsSwap(ref rowsHeading, pickedRow, ref colsHeading, j);
                        break;
                    }
                }

                if (rowNegativeNumber == 0)
                {
                    //вообще вписывать исключения в логику кода это плохо
                    throw new ArgumentException("Система обмежень є суперечливою");
                }

                //redo
                //minimal non-negative number search
                double minimalNonNegative = double.MaxValue;
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    if (matrix[i, matrix.GetLength(1) - 1] / matrix[i, pickedCol] >= 0)
                    {
                        if ((matrix[i, matrix.GetLength(1) - 1] < minimalNonNegative))
                        {
                            minimalNonNegative = matrix[i, matrix.GetLength(1) - 1] / matrix[i, pickedCol];//
                            pickedRow = i;
                        }
                    }
                }

                matrix = ModifiedZhordansExeptions(matrix, pickedRow, pickedCol);
                FormStaff.PrintProtocol(matrix, stringBuilder, iteration, pickedRow, pickedCol);

                //negative numer search
                firstNegativeNumber = 0;
                pickedRow = -1;
                for (int i = 0; i < matrix.GetLength(0) - 1; i++) //GetLength(0) - 1 => until rigth-bottom zero  
                {
                    if (matrix[i, matrix.GetLength(1) - 1] < 0)
                    {
                        firstNegativeNumber = matrix[i, matrix.GetLength(1) - 1];
                        pickedRow = i;
                        break;
                    }
                }

                iteration++;
            } while (firstNegativeNumber != 0);

            //if no negative values in одиничному стовпці
            //если rowsHeading есть позитивные (тоесть иксы), то мы умножаем там чёто
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                if (rowsHeading[i] > 0)
                {
                    res[rowsHeading[i] - 1] = matrix[i, matrix.GetLength(1) - 1];
                }
            }

            return res;
        }

        public static double OptimalSolutionOLD(double[,] matrix, StringBuilder stringBuilder)
        {
            //negative number search
            int pickedCol = -1;   
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[matrix.GetLength(0) - 1, j] < 0)
                {
                    pickedCol = j; 
                    break;
                }
            }

            int iteration = 0;
            while (pickedCol != -1 && iteration < 10)
            {
                //minimal non-negative number search
                int pickedRow = -1;
                double minimalNonNegative = double.MaxValue;
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    if (matrix[i, matrix.GetLength(1) - 1] / matrix[i, pickedCol] >= 0)
                    {
                        if ((matrix[i, matrix.GetLength(1) - 1] < minimalNonNegative))
                        {
                            minimalNonNegative = matrix[i, matrix.GetLength(1) - 1] / matrix[i, pickedCol];//
                            pickedRow = i;
                        }
                    }
                }

                if (pickedRow == -1)
                {
                    throw new ArgumentException("Функція мети не обмежена зверху");
                }

                matrix = ModifiedZhordansExeptions(matrix, pickedRow, pickedCol);
                FormStaff.PrintProtocol(matrix, stringBuilder, iteration, pickedRow, pickedCol);
                iteration++;

                //negative number search
                pickedCol = -1;
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[matrix.GetLength(0) - 1, j] < 0)
                    {
                        pickedCol = j;
                        break;
                    }
                }
            }

            return matrix[matrix.GetLength(0)-1,matrix.GetLength(1)-1];
        }

        public static double[] OptimalSolution(ref double[,] matrix, StringBuilder stringBuilder, int[] rowsHeading, int[] colsHeading)
        {
            double[] res = new double[matrix.GetLength(1) - 1];
            
            // Поиск отрицательного числа в последней строке
            int pickedCol = -1;
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                if (matrix[matrix.GetLength(0) - 1, j] < 0)
                {
                    pickedCol = j;
                    break;
                }
            }

            int iteration = 0;
            while (pickedCol != -1 && iteration < 10)
            {
                // Поиск минимального положительного отношения
                int pickedRow = -1;
                double minimalNonNegative = double.MaxValue;

                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    if (matrix[i, pickedCol] > 0) // Исключаем деление на ноль и отрицательные значения
                    {
                        double ratio = matrix[i, matrix.GetLength(1) - 1] / matrix[i, pickedCol];
                        if (ratio >= 0 && ratio < minimalNonNegative)
                        {
                            minimalNonNegative = ratio;
                            pickedRow = i;
                        }
                    }
                }

                if (pickedRow == -1)
                {
                    throw new ArgumentException("Функція мети не обмежена зверху");
                }

                // Применение метода Жордана
                matrix = ModifiedZhordansExeptions(matrix, pickedRow, pickedCol);
                MatrixElementsSwap(ref rowsHeading, pickedRow, ref colsHeading, pickedCol);
                FormStaff.PrintProtocol(matrix, stringBuilder, iteration, pickedRow, pickedCol);
                iteration++;

                // Поиск следующего отрицательного числа
                pickedCol = -1;
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    if (matrix[matrix.GetLength(0) - 1, j] < 0)
                    {
                        pickedCol = j;
                        break;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                if (rowsHeading[i] > 0)
                {
                    res[rowsHeading[i] - 1] = matrix[i, matrix.GetLength(1) - 1];
                }
            }

            return res;
        }

        public static void MatrixElementsSwap(ref int[] array1, int index1, ref int[] array2, int index2)
        {
            int temp = array1[index1];
            array1[index1] = array2[index2];
            array2[index2] = temp;
        }
    }
}
