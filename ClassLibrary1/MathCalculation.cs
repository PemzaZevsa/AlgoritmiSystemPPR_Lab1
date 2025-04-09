using Microsoft.VisualBasic;
using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                    FormPrint.PrintProtocol(rankMatrix, stringBuilder, i, itaya, jitaya);
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
                FormPrint.PrintProtocol(inverseMatrix, stringBuilder, i);
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

            //round
            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    insertMatrix[i, j] = Math.Round(insertMatrix[i, j], 10);
                }
            }

            return insertMatrix;
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
                rowsHeading[i] = (1 + i) * -1;
            }

            for (int i = 0; i < matrix.GetLength(1) - 1; i++)
            {
                colsHeading[i] = 1 + i * 1;
            }

            //пошук першого негативного числа у одиничному стовпцю
            int pickedRow = IndexOfFirstNegativeNumberInOnesColumn(matrix);

            int iteration = 0;
            while(pickedRow != -1 && iteration < 20)
            {
                //пошук першого негативного числа у рядку
                int pickedCol = IndexOfFirstNegativeNumberInPicedRow(matrix, pickedRow);

                if (pickedCol == -1)
                {
                    //вообще вписывать исключения в логику кода это плохо
                    throw new ArgumentException("Система обмежень є суперечливою");
                }

                //мінімальне позитивне число в одиничному стовпці
                pickedRow = IndexOfMinimalPositiveNumberInOnesColumn(matrix, pickedCol);

                matrix = ModifiedZhordansExeptions(matrix, pickedRow, pickedCol);
                MatrixElementsSwapOLD(ref rowsHeading, pickedRow, ref colsHeading, pickedCol);
                FormPrint.PrintProtocol(matrix, rowsHeading, colsHeading, stringBuilder, iteration, pickedRow, pickedCol);

                //пошук першого негативного числа у одиничному стовпцю
                pickedRow = IndexOfFirstNegativeNumberInOnesColumn(matrix);

                iteration++;
            }

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
                FormPrint.PrintProtocol(matrix, stringBuilder, iteration, pickedRow, pickedCol);
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
            int pickedCol = IndexOfFirstNegativeColumnInZRow(matrix);

            int iteration = 0;
            while (pickedCol != -1 && iteration < 20)
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
                MatrixElementsSwapOLD(ref rowsHeading, pickedRow, ref colsHeading, pickedCol);
                FormPrint.PrintProtocol(matrix, rowsHeading, colsHeading, stringBuilder, iteration, pickedRow, pickedCol);
                iteration++;

                // Поиск следующего отрицательного числа
                pickedCol = IndexOfFirstNegativeColumnInZRow(matrix);
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

        public static void MatrixElementsSwapOLD(ref int[] array1, int index1, ref int[] array2, int index2)
        {
            int temp = array1[index1];
            array1[index1] = array2[index2];
            array2[index2] = temp;
        }

        //lab 1.3

        public static void MatrixElementsSwap(ref string[] array1, int index1, ref string[] array2, int index2)
        {
            string temp = array1[index1];
            array1[index1] = array2[index2];
            array2[index2] = temp;
        }

        public static bool ZerosElimanating(LinearMatrix linearMatrix, StringBuilder stringBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            string[] rowsHeading = linearMatrix.rowsHeading;
            int matrixHeight = matrix.GetLength(0);
            int matrixWidth = matrix.GetLength(1);

            //пошук нульової строки
            int zeroRow = -1;
            for (int i = 0; i < matrixHeight - 1; i++)
            {
                if (rowsHeading[i] == "0")
                {
                    zeroRow = i;
                    break;
                }
            }

            int iteration = 0;
            while (zeroRow != -1) 
            {
                //пошук додатного елемента
                int pickedCol = -1;
                for (int j = 0; j < matrixWidth -1; j++)
                {
                    if (matrix[zeroRow,j] > 0)
                    {
                        pickedCol = j;
                        break;
                    }
                }

                if (pickedCol == -1)
                {
                    stringBuilder.AppendLine("Система обмежень є суперечливою");
                    return false;
                }

                //Пошук мінімального невід'ємного у одиничному стовпці
                int pickedRow = IndexOfMinimalPositiveNumberInOnesColumn(matrix, pickedCol);

                double solvingElement = matrix[pickedRow, pickedCol];
                matrix = ModifiedZhordansExeptions(linearMatrix.matrix, pickedRow, pickedCol);
                MatrixElementsSwap(ref linearMatrix.rowsHeading, pickedRow, ref linearMatrix.colsHeading, pickedCol);
                //викреслення нульового стовпця
                ZeroColumnElimination(linearMatrix);
                //Оновлення посилання на нову матрицю
                matrix = linearMatrix.matrix;
                rowsHeading = linearMatrix.rowsHeading;
                matrixHeight = matrix.GetLength(0);
                matrixWidth = matrix.GetLength(1);

                FormPrint.FancyMatrixPrint(linearMatrix, iteration, zeroRow, pickedCol, solvingElement, stringBuilder);

                //пошук нульової строки
                zeroRow = -1;
                for (int i = 0; i < matrixHeight - 1; i++)
                {
                    if (rowsHeading[i] == "0")
                    {
                        zeroRow = i;
                        break;
                    }
                }

                iteration++;
            }

            return true;
        }

        private static void ZeroColumnElimination(LinearMatrix linearMatrix)
        {
            double[,] matrix = linearMatrix.matrix;
            int matrixHeight = matrix.GetLength(0);
            int matrixWidth = matrix.GetLength(1);
            double[,] newMatrix = new double[matrixHeight, matrixWidth - 1];
            string[] newHeaders = new string[matrixWidth - 2];

            int zeroColumn = -1;
            for (int i = 0; i < matrixWidth - 1; i++)
            {
                if (linearMatrix.colsHeading[i] == "0")
                {
                    zeroColumn = i; 
                    break;
                }
            }

            if (zeroColumn != -1)
            {
                for (int i = 0; i < matrixHeight; i++)
                {
                    int newCol = 0;
                    for (int j = 0; j < matrixWidth; j++)
                    {
                        if (j == zeroColumn) continue;

                        if (newCol < matrixWidth - 2)
                        {
                            newHeaders[newCol] = linearMatrix.colsHeading[j];
                        }

                        newMatrix[i, newCol] = matrix[i, j];
                        newCol++;
                    }
                }

                linearMatrix.matrix = newMatrix;
                linearMatrix.colsHeading = newHeaders;
            }
        }

        public static double[] SupportSolution(LinearMatrix linearMatrix, StringBuilder stringBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            double[] res = new double[linearMatrix.variablesCount];

            //пошук першого негативного числа у одиничному стовпцю
            int pickedRow = IndexOfFirstNegativeNumberInOnesColumn(matrix);

            int iteration = 0;
            while (pickedRow != -1)
            {
                //пошук першого негативного числа у рядку
                int pickedCol = IndexOfFirstNegativeNumberInPicedRow(matrix, pickedRow);

                if (pickedCol == -1)
                {
                    //вообще вписывать исключения в логику кода это плохо
                    throw new ArgumentException("Система обмежень є суперечливою");
                }

                //мінімальне позитивне число в одиничному стовпці
                pickedRow = IndexOfMinimalPositiveNumberInOnesColumn(matrix, pickedCol);

                //МЖВ
                double solvingElement = matrix[pickedRow, pickedCol];
                matrix = ModifiedZhordansExeptions(matrix, pickedRow, pickedCol);
                MatrixElementsSwap(ref linearMatrix.rowsHeading, pickedRow, ref linearMatrix.colsHeading, pickedCol);
                FormPrint.FancyMatrixPrint(linearMatrix , iteration, pickedRow, pickedCol, solvingElement, stringBuilder);

                //пошук першого негативного числа у одиничному стовпцю
                pickedRow = IndexOfFirstNegativeNumberInOnesColumn(matrix);

                iteration++;
            }

            //Отримання результатів
            res = GetResult(linearMatrix);
            linearMatrix.res = res;
            return res;
        }

        public static double[] OptimalSolution(LinearMatrix linearMatrix, StringBuilder stringBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            double[] res = new double[linearMatrix.variablesCount];

            //Пошук негативного числа у z-рядку
            int pickedCol = IndexOfFirstNegativeColumnInZRow(matrix);

            //Основний цикл
            int iteration = 0;
            while (pickedCol != -1 && iteration < 10)
            {
                //Мінімальне невід'ємне
                int pickedRow = IndexOfMinimalPositiveNumberInOnesColumn(matrix, pickedCol);
                
                if (pickedRow == -1)
                {
                    throw new ArgumentException("Функція мети не обмежена зверху");
                }

                //МЖВ
                double solvingElement = matrix[pickedRow, pickedCol];
                matrix = ModifiedZhordansExeptions(matrix, pickedRow, pickedCol);
                MatrixElementsSwap(ref linearMatrix.rowsHeading, pickedRow, ref linearMatrix.colsHeading, pickedCol);
                FormPrint.FancyMatrixPrint(linearMatrix, iteration, pickedRow, pickedCol, solvingElement, stringBuilder);
                iteration++;

                //Пошук наступного негативного числа
                pickedCol = IndexOfFirstNegativeColumnInZRow(matrix);
            }

            //Отримання результатів
            res = GetResult(linearMatrix);
            linearMatrix.res = res;
            return res;
        }

        //lab 1.4

        public static bool AreXsInteger(LinearMatrix linearMatrix, StringBuilder stringBuilder)
        {
            double[] res = linearMatrix.res;

            for (int i = 0; i < res.Length; i++)
            {
                if (linearMatrix.integerVariables.Contains($"x{i + 1}"))//redo
                {
                    if (res[i] % 1 != 0)
                    {
                        stringBuilder.AppendLine("Знайдено розв’язок, у якому змінні мають дробову частину");
                        return false;
                    }
                }
            }

            stringBuilder.AppendLine("Знайдено розв’язок, у якому змінні є цілими");
            return true; 
        }
        
        public static (string,int) MaxFractionVariable(LinearMatrix linearMatrix)
        {
            double[] res = linearMatrix.res;
            double maxFraction = -1;
            int variableId = -1;

            //пошук ікса
            for (int i = 0; i < res.Length; i++)
            {
                if (linearMatrix.integerVariables.Contains($"x{i+1}"))//redo
                {
                    double fractionalPart = res[i] - Math.Floor(res[i]);

                    if (fractionalPart > maxFraction)
                    {
                        maxFraction = fractionalPart;
                        variableId = i;
                    }
                }
            }

            //пошук індекса матриці
            int headingIndexOfVariable = -1;
            for (int i = 0; i < linearMatrix.rowsHeading.Length; i++)
            {
                if (linearMatrix.rowsHeading[i] == $"x{variableId+1}")
                {
                    headingIndexOfVariable = i ;
                }
            }

            return ($"x{variableId+1}", headingIndexOfVariable);
        }

        public static bool CheckFractionals(LinearMatrix linearMatrix, int rowIndex, StringBuilder stringBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            int matrixWidth = matrix.GetLength(1);
            double[] restrictions = new double[matrixWidth];

            for (int i = 0; i < matrixWidth; i++)
            {
                double fractionalPart = matrix[rowIndex, i] - Math.Floor(matrix[rowIndex, i]);
                restrictions[i] = fractionalPart;
            }

            //перевірка значень рядку
            double sum = 0;
            for (int i = 0; i < matrixWidth - 1; i++)
            {
                sum += restrictions[i];
            }

            if (sum == 0)
            {
                return false;
            }

            return true;
        }

        public static double[] GetRestrictions(LinearMatrix linearMatrix, int rowIndex, StringBuilder stringBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            int matrixWidth = matrix.GetLength(1);
            double[] restrictions = new double[matrixWidth];

            for (int i = 0; i < matrixWidth; i++)
            {
                double fractionalPart = matrix[rowIndex, i] - Math.Floor(matrix[rowIndex, i]);
                restrictions[i] = fractionalPart;
            }

            return restrictions;
        }

        public static void AddRestriction(LinearMatrix linearMatrix, int xName, double[] restrictions, StringBuilder stringBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            int matrixWidth = matrix.GetLength(1);

            for (int i = 0; i < matrixWidth; i++)
            {
                restrictions[i] = -restrictions[i];
            }

            linearMatrix.matrix = IncertRestrictionInMatrix(matrix, restrictions);
            linearMatrix.rowsHeading = IncertRestrictionInArray(linearMatrix.rowsHeading, $"s{xName}");

            FormPrint.FancyMatrixPrint(linearMatrix, stringBuilder);
        }

        public static double[,] IncertRestrictionInMatrix(double[,] matrix, double[] restrictions)
        {
            int oldRows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] newMatrix = new double[oldRows + 1, cols];

            for (int j = 0; j < cols; j++)
            {
                newMatrix[0, j] = restrictions[j];
            }

            for (int i = 0; i < oldRows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[i + 1, j] = matrix[i, j];
                }
            }

            return newMatrix;
        }

        public static string[] IncertRestrictionInArray(string[] array, string restriction)
        {
            string[] newArray = new string[array.Length + 1];

            newArray[0] = restriction;

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i + 1] = array[i];
            }

            return newArray;
        }

        //Lab 2

        public static double[] SupportSolutionDoubleMatrix(LinearMatrix linearMatrix, StringBuilder stringBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            double[] res = new double[linearMatrix.variablesCount];

            //пошук першого негативного числа у одиничному стовпцю
            int pickedRow = IndexOfFirstNegativeNumberInOnesColumn(matrix);

            int iteration = 0;
            while (pickedRow != -1)
            {
                //пошук першого негативного числа у рядку
                int pickedCol = IndexOfFirstNegativeNumberInPicedRow(matrix, pickedRow);

                if (pickedCol == -1)// (pickedCol != -1) мб проблема будет
                {
                    //вообще вписывать исключения в логику кода это плохо
                    throw new ArgumentException("Система обмежень є суперечливою");
                }

                //мінімальне позитивне число в одиничному стовпці
                pickedRow = IndexOfMinimalPositiveNumberInOnesColumn(matrix, pickedCol);

                //МЖВ
                double solvingElement = matrix[pickedRow, pickedCol];
                matrix = ModifiedZhordansExeptions(matrix, pickedRow, pickedCol);
                MatrixElementsSwap(ref linearMatrix.rowsHeading, pickedRow, ref linearMatrix.colsHeading, pickedCol);
                MatrixElementsSwap(ref linearMatrix.rowsHeading2, pickedRow, ref linearMatrix.colsHeading2, pickedCol);
                FormPrint.FancyDoubleMatrixPrint(linearMatrix, iteration, pickedRow, pickedCol, solvingElement, stringBuilder);

                //пошук першого негативного числа у одиничному стовпцю
                pickedRow = IndexOfFirstNegativeNumberInOnesColumn(matrix);

                iteration++;
            }

            //Отримання результатів
            res = GetResult(linearMatrix);
            linearMatrix.res = res;
            return res;
        }
        
        public static double[] OptimalSolutionDoubleMatrix(LinearMatrix linearMatrix, StringBuilder stringBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            double[] res = new double[linearMatrix.variablesCount];

            //Пошук негативного числа у z-рядку
            int pickedCol = IndexOfFirstNegativeColumnInZRow(matrix);

            //Основний цикл
            int iteration = 0;
            while (pickedCol != -1 && iteration < 10)
            {
                //Мінімальне невід'ємне
                int pickedRow = IndexOfMinimalPositiveNumberInOnesColumn(matrix, pickedCol);

                if (pickedRow == -1)
                {
                    throw new ArgumentException("Функція мети не обмежена зверху");
                }

                //МЖВ
                double solvingElement = matrix[pickedRow, pickedCol];
                matrix = ModifiedZhordansExeptions(matrix, pickedRow, pickedCol);
                MatrixElementsSwap(ref linearMatrix.rowsHeading, pickedRow, ref linearMatrix.colsHeading, pickedCol);
                MatrixElementsSwap(ref linearMatrix.rowsHeading2, pickedRow, ref linearMatrix.colsHeading2, pickedCol);
                FormPrint.FancyDoubleMatrixPrint(linearMatrix, iteration, pickedRow, pickedCol, solvingElement, stringBuilder);
                iteration++;

                //Пошук наступного негативного числа
                pickedCol = IndexOfFirstNegativeColumnInZRow(matrix);
            }

            //Отримання результатів
            res = GetResult(linearMatrix);
            linearMatrix.res = res;
            return res;
        }

        public static double[] DoubleLinearTask(LinearMatrix linearMatrix, StringBuilder protocolBuilder)
        {
            double[,] matrix = linearMatrix.matrix;
            int matrixHeight = matrix.GetLength(0);
            int matrixWidth = matrix.GetLength(1);
            double[] res = new double[matrixHeight - 1];//мб сдесь проблема будет

            //Отримання результатів
            for (int j = 0; j < matrixWidth - 1; j++)
            {
                if (linearMatrix.colsHeading2[j].Contains('u'))
                {
                    string temp = linearMatrix.colsHeading2[j].Substring(1);
                    res[int.Parse(temp) - 1] = matrix[matrixHeight - 1, j];//res = U(u1,u2,...)
                }
            }

            return res;
        }

        private static int IndexOfFirstNegativeNumberInOnesColumn(double[,] matrix)
        {
            int matrixHeight = matrix.GetLength(0);
            int matrixWidth = matrix.GetLength(1);

            //пошук першого негативного числа у одиничному стовпцю
            int pickedRow = -1;
            for (int i = 0; i < matrixHeight - 1; i++) //matrixHeight - 1 => until rigth-bottom zero  
            {
                if (matrix[i, matrixWidth - 1] < 0)
                {
                    pickedRow = i;
                    break;
                }
            }

            return pickedRow;
        }

        private static int IndexOfMinimalPositiveNumberInOnesColumn(double[,] matrix, int pickedCol)
        {
            int matrixHeight = matrix.GetLength(0);
            int matrixWidth = matrix.GetLength(1);
            int pickedRow = -1;

            //мінімальне позитивне число в одиничному стовпці
            double minimalNonNegative = double.MaxValue;
            for (int i = 0; i < matrixHeight - 1; i++)
            {
                double dividedElement = matrix[i, matrixWidth - 1] / matrix[i, pickedCol];

                if (dividedElement > 0)
                {
                    if (dividedElement < minimalNonNegative)
                    {
                        minimalNonNegative = dividedElement;
                        pickedRow = i;
                    }
                }
            }

            return pickedRow;
        }

        private static int IndexOfFirstNegativeNumberInPicedRow(double[,] matrix, int pickedRow)
        {
            int matrixWidth = matrix.GetLength(1);
            int pickedCol = -1;

            //пошук першого негативного числа у рядку
            for (int j = 0; j < matrixWidth - 1; j++)
            {
                if (matrix[pickedRow, j] < 0)
                {
                    pickedCol = j;
                    break;
                }
            }

            return pickedCol;
        }

        private static double[] GetResult(LinearMatrix linearMatrix)
        {
            double[] res = new double[linearMatrix.variablesCount];
            int matrixHeight = linearMatrix.matrix.GetLength(0);
            int matrixWidth = linearMatrix.matrix.GetLength(1);

            //Отримання результатів
            for (int i = 0; i < matrixHeight - 1; i++)
            {
                if (linearMatrix.rowsHeading[i].Contains('x'))
                {
                    string temp = linearMatrix.rowsHeading[i].Substring(1);
                    res[int.Parse(temp) - 1] = linearMatrix.matrix[i, matrixWidth - 1];//res = X(x1,x2,...)
                }
            }

            return res;
        }

        private static int IndexOfFirstNegativeColumnInZRow(double[,] matrix)
        {
            int matrixHeight = matrix.GetLength(0);
            int matrixWidth = matrix.GetLength(1);
            int pickedCol = -1;

            //Пошук негативного числа у z-рядку
            for (int j = 0; j < matrixWidth - 1; j++)
            {
                if (matrix[matrixHeight - 1, j] < 0)
                {
                    pickedCol = j;
                    break;
                }
            }

            return pickedCol;
        }

        //Lab 3.1

        public static void GameSimulation(double[,] matrix, double[] firstStrategies, double[] secondStrategies, int gamesAmount, double k, StringBuilder protocolBuilder)
        {
            protocolBuilder.Append("№\t");
            protocolBuilder.Append("Rand 1\t");
            protocolBuilder.Append("Strat 1\t");
            protocolBuilder.Append("Rand 2\t");
            protocolBuilder.Append("Strat 2\t");
            protocolBuilder.Append("Reward\t");
            protocolBuilder.Append("Sum\t");
            protocolBuilder.AppendLine("Avarage\t");

            Random random = new Random();
            int[] firstPlayerStrats = new int[matrix.GetLength(0)];
            int[] secondPlayerStrats = new int[matrix.GetLength(1)];
            double sumOfRewards = 0;
            for (int i = 0; i < gamesAmount; i++)
            {
                double[] session = GameSession(matrix, firstStrategies, secondStrategies, sumOfRewards, i,k);
                sumOfRewards = session[6];
                protocolBuilder.AppendLine(string.Join("\t", session));
                
                for (int j = 0; j < firstPlayerStrats.Length; j++)
                {
                    if (session[2] == j)
                    {
                        firstPlayerStrats[j]++;
                    }
                }

                for (int j = 0; j < secondPlayerStrats.Length; j++)
                {
                    if (session[4] == j)
                    {
                        secondPlayerStrats[j]++;
                    }
                }
            }

            protocolBuilder.AppendLine();
            protocolBuilder.AppendLine($"Експерементальна ціна гри = {sumOfRewards / gamesAmount}");

            double[] firstPlayerStratsPercentage = new double[matrix.GetLength(0)];
            double[] secondPlayerStratsPercentage = new double[matrix.GetLength(1)];

            for (int i = 0; i < firstPlayerStrats.Length; i++)
            {
                firstPlayerStratsPercentage[i] = (double)firstPlayerStrats[i] / gamesAmount;
            }

            protocolBuilder.AppendLine("Стратегії першого гравця: "+string.Join("; ", firstPlayerStratsPercentage));

            for (int i = 0; i < secondPlayerStrats.Length; i++)
            {
                secondPlayerStratsPercentage[i] = (double)secondPlayerStrats[i] / gamesAmount;
            }

            protocolBuilder.AppendLine("Стратегії другого гравця: "+string.Join("; ", secondPlayerStratsPercentage));
        }

        private static double[] GameSession(double[,] matrix, double[] firstStrategies, double[] secondStrategies, double sumOfRewards, int iteration, double k)
        {
            Random random = new Random();
            double randomA = random.NextDouble();
            double sumA = 0;
            int chosenStratA = firstStrategies.Length - 1;
            for (int j = 0; j < firstStrategies.Length; j++)
            {
                sumA += firstStrategies[j];
                if (randomA < sumA)
                {
                    chosenStratA = j;
                    break;
                }
            }

            double randomB = random.NextDouble();
            double sumB = 0;
            int chosenStratB = secondStrategies.Length-1;
            for (int j = 0; j < secondStrategies.Length; j++)
            {
                sumB += secondStrategies[j];
                if (randomB < sumB)
                {
                    chosenStratB = j;
                    break;
                }
            }

            double revard = matrix[chosenStratA, chosenStratB] - k;
            sumOfRewards += revard;
            double avarage = sumOfRewards / (iteration + 1);

            return new double[] { iteration + 1, Math.Round(randomA, 2), chosenStratA, Math.Round(randomB, 2), chosenStratB, Math.Round(revard, 2), Math.Round(sumOfRewards, 2), Math.Round(avarage, 2) };
        }

        //Lab 3.2

        public static void NatureSimulation(double[,] matrix, double coeff, double[] percentage, StringBuilder valdBuilder, 
            StringBuilder gurvitsBuilder, StringBuilder maxiMaxBuilder, StringBuilder baesBuilder, StringBuilder savageBuilder, 
            StringBuilder laplaceBuilder, StringBuilder theMostCommonBuilder, StringBuilder protocolBuilder)
        {
            int[] stratsPopularity = new int[matrix.GetLength(0)];

            //обчислення критеріїв
            CalculationTypeCalculation(matrix, stratsPopularity, ValdSimulation, valdBuilder, protocolBuilder);
            CalculationTypeCalculation(matrix, stratsPopularity, MaxiMaxSimulation, maxiMaxBuilder, protocolBuilder);
            CalculationTypeCalculation(matrix, stratsPopularity, coeff, GurvitsSimulation, gurvitsBuilder, protocolBuilder);
            CalculationTypeCalculation(matrix, stratsPopularity, SavageSimulation, savageBuilder, protocolBuilder);
            CalculationTypeCalculation(matrix, stratsPopularity, percentage, BaesSimulation, baesBuilder, protocolBuilder);
            CalculationTypeCalculation(matrix, stratsPopularity, LaplaceSimulation, laplaceBuilder, protocolBuilder);

            //обчислення найпопулярніших стратегій
            int mostPopular = 0; 
            for (int i = 0; i < stratsPopularity.Length; i++)
            {
                if (stratsPopularity[i] > mostPopular)
                {
                    mostPopular = stratsPopularity[i];
                }
            }

            for (int i = 0; i < stratsPopularity.Length; i++)
            {
                if (stratsPopularity[i] == mostPopular)
                {
                    theMostCommonBuilder.Append($"А{i+1} ");
                }
            }
        }
        private static void CalculationTypeCalculation(double[,] matrix, int[] stratsPopularity, Func<double[,], StringBuilder, int[]> calcFunction, StringBuilder calcTypeBuilder, StringBuilder protocolBuilder)
        {
            try
            {
                int[] strategies = calcFunction(matrix, protocolBuilder);

                for (int i = 0; i < strategies.Length; i++)
                {
                    if (strategies[i] == 1)
                    {
                        calcTypeBuilder.Append($"A{i + 1} ");
                    }
                }
                
                StratsPopularitySum(strategies, stratsPopularity);
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine($"Помилка у критерії {nameof(calcTypeBuilder)}");
                protocolBuilder.AppendLine(ex.Message);
            }
        }

        private static void CalculationTypeCalculation(double[,] matrix, int[] stratsPopularity, double[] percentage, Func<double[,], double[], StringBuilder, int[]> calcFunction, StringBuilder calcTypeBuilder, StringBuilder protocolBuilder)
        {
            try
            {
                int[] strategies = calcFunction(matrix, percentage, protocolBuilder);

                for (int i = 0; i < strategies.Length; i++)
                {
                    if (strategies[i] == 1)
                    {
                        calcTypeBuilder.Append($"A{i + 1} ");
                    }
                }

                StratsPopularitySum(strategies, stratsPopularity);
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine($"Помилка у критерії {nameof(calcTypeBuilder)}");
                protocolBuilder.AppendLine(ex.Message);
            }
        }

        private static void CalculationTypeCalculation(double[,] matrix, int[] stratsPopularity, double coeff, Func<double[,], double, StringBuilder, int[]> calcFunction, StringBuilder calcTypeBuilder, StringBuilder protocolBuilder)
        {
            try
            {
                int[] strategies = calcFunction(matrix, coeff, protocolBuilder);
                for (int i = 0; i < strategies.Length; i++)
                {
                    if (strategies[i] == 1)
                    {
                        calcTypeBuilder.Append($"A{i + 1} ");
                    }
                }

                StratsPopularitySum(strategies, stratsPopularity);
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine($"Помилка у критерії {nameof(calcTypeBuilder)}");
                protocolBuilder.AppendLine(ex.Message);
            }
        }

        private static void StratsPopularitySum(int[] strategies, int[] stratsPopularity)
        {
            for (int i = 0; i < stratsPopularity.Length; i++)
            {
                if (strategies[i] == 1) //мб ошибка будет
                {
                    stratsPopularity[i]++;
                }
            }
        }

        private static int[] ValdSimulation(double[,] matrix, StringBuilder protocolBuilder)
        {
            protocolBuilder.AppendLine();
            protocolBuilder.AppendLine($"Критерій Вальда");

            double[] mins = new double[matrix.GetLength(0)];

            //мінімуми
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double minimal = double.MaxValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] < minimal)
                    {
                        minimal = matrix[i, j];
                    }
                }

                mins[i] = minimal;
            }

            for (int i = 0; i < mins.Length; i++)
            {
                protocolBuilder.AppendLine($"Мінімум в рядку {i+1} = {mins[i]}");
            }

            //максимум мінімумів
            double max = double.MinValue;
            for (int i = 0; i < mins.Length; i++)
            {
                if (mins[i] > max)
                {
                    max = mins[i];
                }
            }

            protocolBuilder.AppendLine($"Максимальний елемент = {max}");
            StringBuilder optimalStrategies = new StringBuilder();
            int[] strategies = new int[matrix.GetLength(0)];
            for (int i = 0; i < mins.Length; i++)
            {
                if (mins[i] == max)
                {
                    strategies[i] = 1;
                    optimalStrategies.Append($"А{i + 1} ");
                }
            }

            protocolBuilder.AppendLine($"Оптимальні стратегії : {optimalStrategies.ToString().Trim()}");

            return strategies;
        }

        private static int[] MaxiMaxSimulation(double[,] matrix, StringBuilder protocolBuilder)
        {
            protocolBuilder.AppendLine();
            protocolBuilder.AppendLine($"Критерій Максимакса");

            double[] maxes = new double[matrix.GetLength(0)];

            //максимуми
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double maxV = double.MinValue;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxV)
                    {
                        maxV = matrix[i, j];
                    }
                }

                maxes[i] = maxV;
            }

            for (int i = 0; i < maxes.Length; i++)
            {
                protocolBuilder.AppendLine($"Максимум в рядку {i + 1} = {maxes[i]}");
            }

            //максимум максимумів
            double max = double.MinValue;
            for (int i = 0; i < maxes.Length; i++)
            {
                if (maxes[i] > max)
                {
                    max = maxes[i];
                }
            }

            protocolBuilder.AppendLine($"Максимальний елемент = {max}");
            StringBuilder optimalStrategies = new StringBuilder();
            int[] strategies = new int[matrix.GetLength(0)];
            for (int i = 0; i < maxes.Length; i++)
            {
                if (maxes[i] == max)
                {
                    strategies[i] = 1;
                    optimalStrategies.Append($"А{i + 1} ");
                }
            }

            protocolBuilder.AppendLine($"Оптимальні стратегії : {optimalStrategies.ToString().Trim()}");

            return strategies;
        }

        private static int[] GurvitsSimulation(double[,] matrix, double y, StringBuilder protocolBuilder)
        {
            protocolBuilder.AppendLine();
            protocolBuilder.AppendLine($"Критерій Гурвіца");
            protocolBuilder.AppendLine($"Коефіцієнт = {y}");

            //1
            double[] mins = new double[matrix.GetLength(0)];

                //мінімуми
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    double minimal = double.MaxValue;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] < minimal)
                        {
                            minimal = matrix[i, j];
                        }
                    }

                    mins[i] = minimal;
                }

                for (int i = 0; i < mins.Length; i++)
                {
                    protocolBuilder.AppendLine($"Мінімум в рядку {i + 1} = {mins[i]}");
                }

                //максимум мінімумів
                double max = double.MinValue;
                for (int i = 0; i < mins.Length; i++)
                {
                    if (mins[i] > max)
                    {
                        max = mins[i];
                    }
                }

            //2
                double[] maxes = new double[matrix.GetLength(0)];

                //максимуми 
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    double maxV = double.MinValue;
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > maxV)
                        {
                            maxV = matrix[i, j];
                        }
                    }

                    maxes[i] = maxV;
                }

                for (int i = 0; i < maxes.Length; i++)
                {
                    protocolBuilder.AppendLine($"Максимум в рядку {i + 1} = {maxes[i]}");
                }

                //мінімум максимумів
                double min = double.MaxValue;
                for (int i = 0; i < maxes.Length; i++)
                {
                    if (maxes[i] < min)
                    {
                        min = maxes[i];
                    }
                }

            //обрахунок коеф. гурвіца
            double[] gurvitsCoeffs = new double[matrix.GetLength(0)];
            for (int i = 0; i < gurvitsCoeffs.Length; i++)
            {
                gurvitsCoeffs[i] = Math.Round(y * mins[i] + (1-y) * maxes[i],2);
                protocolBuilder.AppendLine($"S{i + 1} ={y} * {mins[i]} + ( 1 - {y} ) * {maxes[i]} = {gurvitsCoeffs[i]}");
            }

            //макс коеф. гурвіца
            double maxCoeff = double.MinValue;
            for (int i = 0; i < gurvitsCoeffs.Length; i++)
            {
                if (maxCoeff < gurvitsCoeffs[i])
                {
                    maxCoeff = gurvitsCoeffs[i];
                }
            }

            StringBuilder optimalStrategies = new StringBuilder();
            int[] strategies = new int[matrix.GetLength(0)];
            for (int i = 0; i < gurvitsCoeffs.Length; i++)
            {
                if (gurvitsCoeffs[i] == maxCoeff)
                {
                    strategies[i] = 1;
                    optimalStrategies.Append($"А{i + 1} ");
                }
            }

            protocolBuilder.AppendLine($"Максимальний елемент = {string.Concat(", ", maxCoeff)}");
            protocolBuilder.AppendLine($"Оптимальні стратегії : {optimalStrategies.ToString().Trim()}");

            return strategies;
        }

        private static int[] SavageSimulation(double[,] matrix, StringBuilder protocolBuilder)
        {
            protocolBuilder.AppendLine();
            protocolBuilder.AppendLine($"Критерій Севіджа");

            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);
            double[,] loseMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];

            //обчислення матриці ризиків
            for (int j = 0; j < numCols; j++)
            {
                double maxPayoffInColumn = double.MinValue;
                for (int i = 0; i < numRows; i++)
                {
                    if (matrix[i, j] > maxPayoffInColumn)
                        maxPayoffInColumn = matrix[i, j];
                }

                for (int i = 0; i < numRows; i++)
                {
                    loseMatrix[i, j] = maxPayoffInColumn - matrix[i, j];
                }
            }

            //максимальні втрати по рядках
            double[] maxLosses = new double[numRows];
            for (int i = 0; i < numRows; i++)
            {
                double maxLoss = double.MinValue;
                for (int j = 0; j < numCols; j++)
                {
                    if (loseMatrix[i, j] > maxLoss)
                        maxLoss = loseMatrix[i, j];
                }

                maxLosses[i] = maxLoss;
            }

            protocolBuilder.AppendLine("Матриця ризиків:");
            for (int i = 0; i < loseMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < loseMatrix.GetLength(1); j++)
                {
                    protocolBuilder.Append($"{loseMatrix[i, j]}\t");
                }

                protocolBuilder.AppendLine();
            }

            double minLoss = double.MaxValue;
            for (int i = 0; i < maxLosses.Length; i++)
            {
                protocolBuilder.AppendLine($"max в рядку {i+1} = {maxLosses[i]}");
                if (maxLosses[i] < minLoss)
                {
                    minLoss = maxLosses[i];
                }
            }

            StringBuilder optimalStrategies = new StringBuilder();
            int[] strategies = new int[matrix.GetLength(0)];
            for (int i = 0; i < maxLosses.Length; i++)
            {
                if (maxLosses[i] == minLoss)
                {
                    strategies[i] = 1;
                    optimalStrategies.Append($"А{i+1} ");
                }
            }
            
            protocolBuilder.AppendLine($"Мінімальний елемент = {minLoss}");
            protocolBuilder.AppendLine($"Оптимальні стратегії: {optimalStrategies.ToString().Trim()}");
            return strategies;
        }

        private static int[] BaesSimulation(double[,] matrix, double[] percentage, StringBuilder protocolBuilder)
        {
            protocolBuilder.AppendLine();
            protocolBuilder.AppendLine("Критерій Баэса");
            protocolBuilder.AppendLine("Ймовірності застосування природою своїх стратегій: " + string.Join(", ", percentage.Select(p => p.ToString()).ToArray()));

            double[] avarageWins = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j] * percentage[j];
                }

                avarageWins[i] = Math.Round(sum,2); 
            }

            double max = double.MinValue;
            for (int i = 0; i < avarageWins.Length; i++)
            {
                protocolBuilder.AppendLine($"S{i + 1} = {avarageWins[i]}");
                if (max < avarageWins[i])
                {
                    max = avarageWins[i];
                }
            }

            StringBuilder optimalStrategies = new StringBuilder();
            int[] strategies = new int[matrix.GetLength(0)];
            for (int i = 0; i < avarageWins.Length; i++)
            {
                if (avarageWins[i] == max)
                {
                    strategies[i] = 1;
                    optimalStrategies.Append($"А{i + 1} ");
                }
            }

            protocolBuilder.AppendLine($"Максимальний елемент = {max}");
            protocolBuilder.AppendLine($"Оптимальні стратегії : {optimalStrategies.ToString().Trim()}");
            return strategies;
        }

        private static int[] LaplaceSimulation(double[,] matrix, StringBuilder protocolBuilder)
        {
            protocolBuilder.AppendLine();
            protocolBuilder.AppendLine("Критерій Лапласа");

            //обрахунок процентів
            double[] percentage = new double[matrix.GetLength(1)];
            double avarageValue = (1.00 / percentage.Length);
            for (int i = 0; i < percentage.Length; i++)
            {
                percentage[i] = avarageValue;
            }

            protocolBuilder.AppendLine("Ймовірності застосування природою своїх стратегій: " + string.Join(", ", percentage.Select(p => p.ToString()).ToArray()));
            double[] avarageWins = new double[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j] * percentage[j];
                }

                avarageWins[i] = sum;
            }

            double max = double.MinValue;
            for (int i = 0; i < avarageWins.Length; i++)
            {
                protocolBuilder.AppendLine($"max в рядку {i + 1} = {avarageWins[i]}");
                if (max < avarageWins[i])
                {
                    max = avarageWins[i];
                }
            }

            StringBuilder optimalStrategies = new StringBuilder();
            int[] strategies = new int[matrix.GetLength(0)];
            for (int i = 0; i < avarageWins.Length; i++)
            {
                if (avarageWins[i] == max)
                {
                    strategies[i] = 1;
                    optimalStrategies.Append($"А{i + 1} ");
                }
            }

            protocolBuilder.AppendLine($"Максимальний елемент = {max}");
            protocolBuilder.AppendLine($"Оптимальні стратегії : {optimalStrategies.ToString().Trim()}");
            return strategies;
        }
        
    }
}
