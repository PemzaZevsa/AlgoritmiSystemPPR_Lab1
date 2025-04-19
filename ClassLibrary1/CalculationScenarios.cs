using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary1
{
    public static class CalculationScenarios
    {
        //Lab 1.1

        public static void CalculateInverseMatrix(string matrixrText, StringBuilder inverseBuilder, StringBuilder stringBuilder)
        {
            double[,] aMatrix = FormPrint.ReadMatrixFromRichTextBox(matrixrText, stringBuilder);

            try
            {
                double[,] inverseMatrix = MathCalculation.InverseMatrix(aMatrix, stringBuilder);
                FormPrint.ProtocolMatrixPrint(inverseMatrix, inverseBuilder);
            }
            catch (Exception ex)
            {
                stringBuilder.AppendLine(ex.Message);
            }
        }

        public static void matrixRank(string matrixrText, StringBuilder rankBuilder, StringBuilder stringBuilder)
        {
            double[,] aMatrix = FormPrint.ReadMatrixFromRichTextBox(matrixrText, stringBuilder);

            try
            {
                int rank = MathCalculation.MatrixRank(aMatrix, stringBuilder);
                rankBuilder.AppendLine($"{rank}");
            }
            catch (Exception ex)
            {
                stringBuilder.AppendLine(ex.Message);
            }
        }

        public static void SLAUCalculate(string matrixrText, string matrixBText, StringBuilder inverseBuilder, StringBuilder xBuilder, StringBuilder stringBuilder)
        {
            //reading
            double[,] aMatrix = FormPrint.ReadMatrixFromRichTextBox(matrixrText, stringBuilder);
            double[] bMatrix = FormPrint.ReadMatrixBFromRichTextBox(matrixBText, stringBuilder);

            //preparations
            double[,] inverseMatrix = MathCalculation.InverseMatrix(aMatrix, stringBuilder);
            FormPrint.ProtocolMatrixPrint(inverseMatrix, inverseBuilder);

            //calculation
            double[] xMatrix = MathCalculation.SLAU(bMatrix, inverseMatrix, stringBuilder);
            FormPrint.ArrayPrint(xMatrix, xBuilder);
        }

        //Lab 1.2

        public static void CalculateOptimalSolutionLab1_2(int variablesAmount, string zFunction, string restrictions, bool maxSolution, bool minSolution, StringBuilder xResult, StringBuilder zResult, StringBuilder protocolBuilder)
        {
            double[,] matrix = LinearMatrixBuilder.CreateMatrix(variablesAmount, zFunction, restrictions);

            if (maxSolution)
            {
                FormPrint.FancyPrintMatrixOnRichTextBox(matrix, protocolBuilder);
                MaxSolutionScript(matrix, xResult, zResult, protocolBuilder);
            }

            if (minSolution)
            {
                //приведення до Z'
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    matrix[matrix.GetLength(0) - 1, j] *= -1;
                }

                FormPrint.FancyPrintMatrixOnRichTextBox(matrix, protocolBuilder);
                MinSolutionScript(matrix, xResult, zResult, protocolBuilder);
            }
        }

        private static void MaxSolutionScript(double[,] matrix, StringBuilder xResult, StringBuilder zResult, StringBuilder protocolBuilder)
        {
            int[] rowsHeading = null;
            int[] colsHeading = null;
            try
            {
                protocolBuilder.AppendLine("Знаходження опорного рішення:");
                double[] result = MathCalculation.SupportSolution(ref matrix, protocolBuilder, out rowsHeading, out colsHeading);
                protocolBuilder.AppendLine("Опорний розв'язок знайдено:");
                string str = string.Join(", ", result);
                protocolBuilder.AppendLine($"X:({str})\n");
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
            }

            try
            {
                protocolBuilder.AppendLine("Знаходження оптимального рішення:");
                double[] result = MathCalculation.OptimalSolution(ref matrix, protocolBuilder, rowsHeading, colsHeading);
                protocolBuilder.AppendLine("Оптимальний розв'язок знайдено:");
                string str = string.Join(", ", result);
                protocolBuilder.AppendLine($"X:({str})\n");
                xResult.AppendLine(str);

                double zRes = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
                zResult.AppendLine($"{zRes}");
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
            }
        }

        private static void MinSolutionScript(double[,] matrix, StringBuilder xResult, StringBuilder zResult, StringBuilder protocolBuilder)
        {
            int[] rowsHeading = null;
            int[] colsHeading = null;
            try
            {
                protocolBuilder.AppendLine("Знаходження опорного рішення:");
                double[] result = MathCalculation.SupportSolution(ref matrix, protocolBuilder, out rowsHeading, out colsHeading);
                protocolBuilder.AppendLine("Опорний розв'язок знайдено:");
                string str = string.Join(", ", result);
                protocolBuilder.AppendLine($"X:({str})\n");
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
            }

            try
            {
                protocolBuilder.AppendLine("Знаходження оптимального рішення:");
                double[] result = MathCalculation.OptimalSolution(ref matrix, protocolBuilder, rowsHeading, colsHeading);
                protocolBuilder.AppendLine("Оптимальний розв'язок знайдено:");
                string str = string.Join(", ", result);
                protocolBuilder.AppendLine($"X:({str})\n");
                xResult.AppendLine(str);

                //min Z = -(max Z')
                double zRes = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1] * -1;
                zResult.AppendLine($"{zRes}");
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
            }
        }

        //Lab 1.3

        public static void CalculateOptimalSolutionLab1_3(int variablesAmount, string zFunction, string restrictions, bool maxSolution, bool minSolution, StringBuilder xResult, StringBuilder zResult, StringBuilder protocolBuilder)
        {
            LinearMatrix linearMatrix = LinearMatrixBuilder.CreateLinearMatrix(variablesAmount, zFunction, restrictions);
            double[,] matrix = linearMatrix.matrix;

            if (maxSolution)
            {
                FormPrint.FancyMatrixPrint(linearMatrix, protocolBuilder);

                try
                {
                    MathCalculation.ZerosElimanating(linearMatrix, protocolBuilder);
                    MaxSolutionScript(linearMatrix, xResult, zResult, protocolBuilder);
                }
                catch (Exception ex)
                {
                    protocolBuilder.AppendLine(ex.Message);
                }
            }

            if (minSolution)
            {
                //приведення Z до Z'
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    matrix[matrix.GetLength(0) - 1, j] *= -1;
                }

                FormPrint.FancyMatrixPrint(linearMatrix, protocolBuilder);

                try
                {
                    MathCalculation.ZerosElimanating(linearMatrix, protocolBuilder);
                    MinSolutionScript(linearMatrix, xResult, zResult, protocolBuilder);
                }
                catch (Exception ex)
                {
                    protocolBuilder.AppendLine(ex.Message);
                }
            }
        }

        private static void MaxSolutionScript(LinearMatrix linearMatrix, StringBuilder xResult, StringBuilder zResult, StringBuilder protocolBuilder)
        {
            try
            {
                //Support solution
                SupportSolution(linearMatrix, protocolBuilder);

                //Optimal solution
                OptimalSolution(linearMatrix, xResult, protocolBuilder);

                double zRes = Math.Round(linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, linearMatrix.matrix.GetLength(1) - 1], 2);
                zResult.Clear();
                zResult.AppendLine($"{zRes}");
                protocolBuilder.AppendLine($"Z:{zRes}\n");

            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
                throw new ArgumentException("При пошуку максимального значення функції Z відбулася помилка", ex);
            }
        }

        private static void MinSolutionScript(LinearMatrix linearMatrix, StringBuilder xResult, StringBuilder zResult, StringBuilder protocolBuilder)
        {
            try
            {
                //Support solution
                SupportSolution(linearMatrix, protocolBuilder);

                //Optimal solution
                OptimalSolution(linearMatrix, xResult, protocolBuilder);

                //min Z = -(max Z')
                double zRes = Math.Round(linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, linearMatrix.matrix.GetLength(1) - 1] * -1, 2);
                zResult.Clear();
                zResult.AppendLine($"{zRes}");
                protocolBuilder.AppendLine($"Z:{zRes}\n");

            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
                throw new ArgumentException("При пошуку мінімального значення функції Z відбулася помилка", ex);
            }
        }

        //Lab 1.4

        public static void CalculateOptimalSolutionLab1_4(int variablesAmount, string zFunction, string restrictions, string integerVariables, bool maxSolution, bool minSolution, StringBuilder xResult, StringBuilder zResult, StringBuilder protocolBuilder)
        {
            LinearMatrix linearMatrix = LinearMatrixBuilder.CreateLinearMatrix(variablesAmount, zFunction, restrictions, integerVariables);

            if (maxSolution)
            {
                FormPrint.FancyMatrixPrint(linearMatrix, protocolBuilder);

                try
                {
                    MaxSolutionScriptWithIntegers(linearMatrix, xResult, zResult, protocolBuilder);
                }
                catch (Exception ex)
                {
                    protocolBuilder.AppendLine(ex.Message);
                }
            }

            if (minSolution)
            {
                //приведення Z до Z'
                for (int j = 0; j < linearMatrix.matrix.GetLength(1) - 1; j++)
                {
                    linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, j] *= -1;
                }

                FormPrint.FancyMatrixPrint(linearMatrix, protocolBuilder);

                try
                {
                    MinSolutionScriptWithIntegers(linearMatrix, xResult, zResult, protocolBuilder);
                }
                catch (Exception ex)
                {
                    protocolBuilder.AppendLine(ex.Message);
                }
            }
        }

        private static void MaxSolutionScriptWithIntegers(LinearMatrix linearMatrix, StringBuilder xResult, StringBuilder zResult, StringBuilder protocolBuilder)
        {
            try
            {
                MaxSolutionScript(linearMatrix, xResult, zResult, protocolBuilder);

                for (int iterations = 0; iterations < 10; iterations++)
                {
                    if (!MathCalculation.AreXsInteger(linearMatrix, protocolBuilder))
                    {
                        (string maxFractionVariable, int index) = MathCalculation.MaxFractionVariable(linearMatrix);
                        protocolBuilder.AppendLine($"Обрана змінна {maxFractionVariable}");
                        protocolBuilder.AppendLine($"Обраний індекс {index}");

                        if (!MathCalculation.CheckFractionals(linearMatrix, index, protocolBuilder))
                        {
                            protocolBuilder.AppendLine("Задача не має цілочислового рішення");
                            return;
                        }

                        double[] restrictions = MathCalculation.GetRestrictions(linearMatrix, index, protocolBuilder);
                        int xName = int.Parse(maxFractionVariable.Substring(1));
                        MathCalculation.AddRestriction(linearMatrix, xName, restrictions, protocolBuilder);

                        MaxSolutionScript(linearMatrix, xResult, zResult, protocolBuilder);
                    }
                    else
                    {
                        FormPrint.FancyMatrixPrint(linearMatrix, protocolBuilder);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void MinSolutionScriptWithIntegers(LinearMatrix linearMatrix, StringBuilder xResult, StringBuilder zResult, StringBuilder protocolBuilder)
        {
            try
            {
                MinSolutionScript(linearMatrix, xResult, zResult, protocolBuilder);

                for (int iterations = 0; iterations < 10; iterations++)
                {
                    if (!MathCalculation.AreXsInteger(linearMatrix, protocolBuilder))
                    {
                        (string maxFractionVariable, int index) = MathCalculation.MaxFractionVariable(linearMatrix);
                        protocolBuilder.AppendLine($"Обрана змінна {maxFractionVariable}");
                        protocolBuilder.AppendLine($"Обраний індекс {index}");

                        if (!MathCalculation.CheckFractionals(linearMatrix, index, protocolBuilder))
                        {
                            protocolBuilder.AppendLine("Задача не має цілочислового рішення");
                            return;
                        }

                        double[] restrictions = MathCalculation.GetRestrictions(linearMatrix, index, protocolBuilder);
                        int xName = int.Parse(maxFractionVariable.Substring(1));
                        MathCalculation.AddRestriction(linearMatrix, xName, restrictions, protocolBuilder);
                        for (int j = 0; j < linearMatrix.matrix.GetLength(1) - 1; j++)
                        {
                            linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, j] *= -1;
                        }
                        MinSolutionScript(linearMatrix, xResult, zResult, protocolBuilder);
                    }
                    else
                    {
                        FormPrint.FancyMatrixPrint(linearMatrix, protocolBuilder);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Lab 2

        public static void CalculateOptimalSolutionLab2(int variablesAmount, string zFunction, string restrictions, bool maxSolution, 
            bool minSolution, StringBuilder solutionsResult, StringBuilder protocolBuilder)
        {
            LinearMatrix linearMatrix = LinearMatrixBuilder.CreateDoubleLinearMatrix(variablesAmount, zFunction, restrictions);

            if (maxSolution)
            {
                FormPrint.FancyDoubleMatrixPrint(linearMatrix, protocolBuilder);

                try
                {
                    MaxSolutionScriptDoubleMatrix(linearMatrix, solutionsResult, solutionsResult, protocolBuilder);
                }
                catch (Exception ex)
                {
                    protocolBuilder.AppendLine(ex.Message);
                }
            }

            if (minSolution)
            {
                //приведення Z до Z'
                for (int j = 0; j < linearMatrix.matrix.GetLength(1) - 1; j++)
                {
                    linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, j] *= -1;
                }

                FormPrint.FancyDoubleMatrixPrint(linearMatrix, protocolBuilder);

                try
                {
                    MinSolutionScriptDoubleMatrix(linearMatrix, solutionsResult, solutionsResult, protocolBuilder);
                }
                catch (Exception ex)
                {
                    protocolBuilder.AppendLine(ex.Message);
                }
            }
        }

        private static void MaxSolutionScriptDoubleMatrix(LinearMatrix linearMatrix, StringBuilder xResult, StringBuilder zResult, 
            StringBuilder protocolBuilder)
        {
            try
            {
                //Support solution
                SupportSolutionDoubleMatrix(linearMatrix, protocolBuilder);

                //Optimal solution
                OptimalSolutionDoubleMatrix(linearMatrix, xResult, protocolBuilder);

                double[] result = MathCalculation.DoubleLinearTask(linearMatrix, protocolBuilder);
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                string str = string.Join("; ", result);
                protocolBuilder.AppendLine($"U:({str})\n");
                xResult.AppendLine($"Розв'язки двоічної задачі:");
                xResult.AppendLine($"U = ({str})");

                double zRes = Math.Round(linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, linearMatrix.matrix.GetLength(1) - 1], 2);
                zResult.AppendLine($"MAX (Z) = {zRes}");
                zResult.AppendLine($"MIN (W) = {zRes}");
                protocolBuilder.AppendLine($"Z:{zRes}\n");
                protocolBuilder.AppendLine($"W:{zRes}\n");
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
                throw new ArgumentException("При пошуку максимального значення функції Z відбулася помилка", ex);
            }
        }

        private static void MinSolutionScriptDoubleMatrix(LinearMatrix linearMatrix, StringBuilder xResult, StringBuilder zResult, 
            StringBuilder protocolBuilder)
        {
            try
            {
                //Support solution
                SupportSolutionDoubleMatrix(linearMatrix, protocolBuilder);

                //Optimal solution
                OptimalSolutionDoubleMatrix(linearMatrix, xResult, protocolBuilder);

                double[] result = MathCalculation.DoubleLinearTask(linearMatrix, protocolBuilder);
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                string str = string.Join("; ", result);
                protocolBuilder.AppendLine($"U:({str})\n");
                xResult.AppendLine($"Розв'язки двоічної задачі:");
                xResult.AppendLine($"U = ({str})");

                //min Z = -(max Z')
                double zRes = Math.Round(linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, linearMatrix.matrix.GetLength(1) - 1] * -1, 2);
                zResult.AppendLine($"{zRes}");
                zResult.AppendLine($"MAX (Z) = {zRes}");
                zResult.AppendLine($"MIN (W) = {zRes}");
                protocolBuilder.AppendLine($"Z:{zRes}\n");
                protocolBuilder.AppendLine($"W:{zRes}\n");

            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
                throw new ArgumentException("При пошуку мінімального значення функції Z відбулася помилка", ex);
            }
        }

        //Lab 3.1

        public static void CalculateOptimalSolutionLab3_1(string matrix, StringBuilder firstPlayer, StringBuilder secondPlayer, 
            StringBuilder gamePrice, StringBuilder protocolBuilder, int gamesAmount = 0)
        {
            LinearMatrix linearMatrix = LinearMatrixBuilder.CreateDoubleLinearMatrixLab3_1(matrix);
            FormPrint.FancyDoubleMatrixPrint(linearMatrix, protocolBuilder);
            try
            {
                MaxSolutionScriptDoubleMatrixLab3_1(linearMatrix, firstPlayer, secondPlayer, gamePrice, protocolBuilder);

                if (gamesAmount > 0)
                {
                    MathCalculation.GameSimulation(linearMatrix.startMatrix, linearMatrix.firstP, linearMatrix.secondP, gamesAmount, linearMatrix.k, protocolBuilder);
                }
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
            }
        }

        private static void MaxSolutionScriptDoubleMatrixLab3_1(LinearMatrix linearMatrix, StringBuilder firstPlayer, 
            StringBuilder secondPlayer, StringBuilder gamePrice, StringBuilder protocolBuilder)
        {
            try
            {
                //Support solution
                SupportSolutionDoubleMatrix(linearMatrix, protocolBuilder);

                //Optimal solution
                protocolBuilder.AppendLine("Знаходження оптимального рішення:");
                double[] result = MathCalculation.OptimalSolutionDoubleMatrix(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("Оптимальний розв'язок знайдено:");
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                string str = string.Join("; ", result);
                protocolBuilder.AppendLine($"X:({str})\n");

                //second player
                double v = linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, linearMatrix.matrix.GetLength(1) - 1];
                double[] secondP = new double[result.Length];
                for (int i = 0; i < secondP.Length; i++)
                {
                    secondP[i] = Math.Round(result[i] / v, 2);
                }
                linearMatrix.secondP = secondP;
                str = string.Join("; ", secondP);
                secondPlayer.AppendLine(str);
                protocolBuilder.AppendLine("Стратегії другого гравця: " + str + "\n");

                result = MathCalculation.DoubleLinearTask(linearMatrix, protocolBuilder);
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                str = string.Join("; ", result);
                protocolBuilder.AppendLine($"U:({str})\n");

                //first player
                double[] firstP = new double[result.Length];
                for (int i = 0; i < firstP.Length; i++)
                {
                    firstP[i] = Math.Round(result[i] / v, 2);
                }
                linearMatrix.firstP = firstP;
                str = string.Join("; ", firstP);
                firstPlayer.AppendLine(str);
                protocolBuilder.AppendLine("Стратегії першого гравця: " + str + "\n");

                //gamep price
                v = (1 / v) - linearMatrix.k;
                gamePrice.AppendLine($"{Math.Round(v, 2)}");
                protocolBuilder.AppendLine("Ціна гри: "+$"{Math.Round(v, 2)}");

                double zRes = Math.Round(linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, linearMatrix.matrix.GetLength(1) - 1], 2);
                protocolBuilder.AppendLine($"Z:{zRes}\n");
                protocolBuilder.AppendLine($"W:{zRes}\n");
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
                throw new ArgumentException("При пошуку максимального значення функції Z відбулася помилка", ex);
            }
        }

        //Lab 3.2

        public static void CalculateOptimalSolutionLab3_2(string matrixText, double coeff, string percentageText, StringBuilder valdBuilder, 
            StringBuilder gurvitsBuilder, StringBuilder maxiMaxBuilder, StringBuilder baesBuilder, StringBuilder savageBuilder, 
            StringBuilder laplaceBuilder, StringBuilder theMostCommonBuilder, StringBuilder protocolBuilder)
        {
            double[,] matrix = LinearMatrixBuilder.CreateMatrixLab3_2(matrixText);
            double[] percentage = LinearMatrixBuilder.CreateArrayLab3_2(percentageText);
            protocolBuilder.AppendLine("Початкова матриця: ");
            FormPrint.ProtocolMatrixPrint(matrix, protocolBuilder);
            try
            {
                MathCalculation.NatureSimulation(
                    matrix: matrix,
                    coeff: coeff,
                    percentage: percentage,
                    valdBuilder: valdBuilder,
                    gurvitsBuilder: gurvitsBuilder,
                    maxiMaxBuilder: maxiMaxBuilder,
                    baesBuilder: baesBuilder,
                    savageBuilder: savageBuilder,
                    laplaceBuilder: laplaceBuilder,
                    theMostCommonBuilder: theMostCommonBuilder,
                    protocolBuilder: protocolBuilder
                    );
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
            }
        }

        //RR

        private static void SupportSolution(LinearMatrix linearMatrix, StringBuilder protocolBuilder)
        {
            protocolBuilder.AppendLine("Знаходження опорного рішення:");
            double[] result = MathCalculation.SupportSolution(linearMatrix, protocolBuilder);
            protocolBuilder.AppendLine("Опорний розв'язок знайдено:");
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(result[i], 2);
            }
            string str = string.Join(", ", result);
            protocolBuilder.AppendLine($"X:({str})\n");
        }

        private static void OptimalSolution(LinearMatrix linearMatrix, StringBuilder xResult, StringBuilder protocolBuilder)
        {
            protocolBuilder.AppendLine("Знаходження оптимального рішення:");
            double[] result = MathCalculation.OptimalSolution(linearMatrix, protocolBuilder);
            protocolBuilder.AppendLine("Оптимальний розв'язок знайдено:");
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(result[i], 2);
            }
            string str = string.Join(", ", result);
            protocolBuilder.AppendLine($"X:({str})\n");
            xResult.Clear();
            xResult.AppendLine($"{str}");
        }

        private static void SupportSolutionDoubleMatrix(LinearMatrix linearMatrix, StringBuilder protocolBuilder)
        {
            protocolBuilder.AppendLine("Знаходження опорного рішення:");
            double[] result = MathCalculation.SupportSolutionDoubleMatrix(linearMatrix, protocolBuilder);
            protocolBuilder.AppendLine("Опорний розв'язок знайдено:");
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(result[i], 2);
            }
            string str = string.Join("; ", result);
            protocolBuilder.AppendLine($"X:({str})\n");
        }

        private static void OptimalSolutionDoubleMatrix(LinearMatrix linearMatrix, StringBuilder xResult, StringBuilder protocolBuilder)
        {
            protocolBuilder.AppendLine("Знаходження оптимального рішення:");
            double[] result = MathCalculation.OptimalSolutionDoubleMatrix(linearMatrix, protocolBuilder);
            protocolBuilder.AppendLine("Оптимальний розв'язок знайдено:");
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(result[i], 2);
            }
            string str = string.Join("; ", result);
            protocolBuilder.AppendLine($"X:({str})\n");
            xResult.AppendLine($"Розв'язки прямої задачі:");
            xResult.AppendLine($"X = ({str})");
        }

        public static void CalculateOptimalSolutionRR(string objFunctionsText, string restrictionsText, int variablesAmount,
            StringBuilder objFunctionCoefficients, StringBuilder optimalVectorsBuilder, StringBuilder nonOptimalSolutionsBuilder, 
            StringBuilder matrixGame, StringBuilder coefficients, StringBuilder compromiseSolutionBuilder, StringBuilder protocolBuilder)
        {
            string[] objFunctionsLines = objFunctionsText.Trim().Split("\n");
            double[,] objFunctionsMatrix = new double[objFunctionsLines.Length, variablesAmount];
            double[,] optimalVectors = new double[objFunctionsLines.Length, variablesAmount];

            try
            {
                protocolBuilder.AppendLine("Пошук оптимальних вектрорів:");

                //оптимальні розв'яки
                for (int i = 0; i < objFunctionsLines.Length; i++)
                {
                    protocolBuilder.AppendLine($"Розв'язок {i+1}");
                    protocolBuilder.AppendLine();

                    (string zFunction, int keyWords) = LinearMatrixBuilder.ObjectFunctionForm(objFunctionsLines[i]);



                    int[] variables = LinearMatrixBuilder.VariablesRead(variablesAmount, zFunction);
                    for (int j = 0; j < optimalVectors.GetLength(1); j++)
                    {
                        objFunctionsMatrix[i,j] = variables[j];
                    }



                    if (keyWords == -1)
                    {
                        protocolBuilder.AppendLine("Не знайдено ключового слова max/min");
                        break;
                    }

                    bool maxSolution = keyWords == 1;
                    double[] res = CalculateOptimalSolution(variablesAmount, zFunction, restrictionsText, maxSolution, protocolBuilder);

                    for (int j = 0; j < optimalVectors.GetLength(1); j++)
                    {
                        optimalVectors[i,j] = res[j];
                    }
                }

                //вивід objFunctionCoefficients
                for (int i = 0; i < objFunctionsMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < objFunctionsMatrix.GetLength(1); j++)
                    {
                        objFunctionCoefficients.Append(Math.Round(objFunctionsMatrix[i, j],2) + "\t");
                    }

                    objFunctionCoefficients.AppendLine();
                }

                //вивід оптимальних векторів
                for (int i = 0; i < optimalVectors.GetLength(0); i++)
                {
                    for (int j = 0; j < optimalVectors.GetLength(1); j++)
                    {
                        optimalVectorsBuilder.Append(Math.Round(optimalVectors[i, j],2) + "\t");
                    }

                    optimalVectorsBuilder.AppendLine();
                }

                //вивід оптимальних у протокол
                protocolBuilder.AppendLine();
                protocolBuilder.AppendLine("Оптимальні вектори:");
                FormPrint.FancyMatrixPrint(optimalVectors, "X*", "x", protocolBuilder);

                //вивід objFunctionsMatrix у протокол
                protocolBuilder.AppendLine();
                protocolBuilder.AppendLine("Матриця коефіцієнтів функцій мети:");
                FormPrint.FancyMatrixPrint(objFunctionsMatrix, "C", "x", protocolBuilder);

                //розрахунок неоптимальної матриці
                double[,] nonOptimalSolutions = new double[objFunctionsLines.Length, objFunctionsLines.Length];
                for (int i = 0; i < nonOptimalSolutions.GetLength(0); i++)
                {
                    for (int j = 0; j < nonOptimalSolutions.GetLength(1); j++)
                    {
                        nonOptimalSolutions[i, j] = nonOptimalSolutionsCalculation(i, j, optimalVectors, objFunctionsMatrix);
                    }
                }

                //вивід nonOptimalSolutions
                for (int i = 0; i < nonOptimalSolutions.GetLength(0); i++)
                {
                    for (int j = 0; j < nonOptimalSolutions.GetLength(1); j++)
                    {
                        nonOptimalSolutionsBuilder.Append(Math.Round(nonOptimalSolutions[i, j],2) + "\t");
                    }

                    nonOptimalSolutionsBuilder.AppendLine();
                }

                //вивід nonOptimalSolutions у протокол
                protocolBuilder.AppendLine();
                protocolBuilder.AppendLine("Міри неоптимальності:");
                FormPrint.FancyMatrixPrint(nonOptimalSolutions, "X", "Z", protocolBuilder);

                //Розв'язання матричної гри
                LinearMatrix linearMatrix = LinearMatrixBuilder.CreateDoubleLinearMatrixRR(nonOptimalSolutions);
                protocolBuilder.AppendLine("Створена ігрова матриця:");
                FormPrint.FancyDoubleMatrixPrint(linearMatrix, protocolBuilder);

                //вивід matrixGame
                for (int i = 0; i < linearMatrix.matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < linearMatrix.matrix.GetLength(1); j++)
                    {
                        matrixGame.Append(Math.Round(linearMatrix.matrix[i, j], 2) + "\t");
                    }

                    matrixGame.AppendLine();
                }

                StringBuilder firstPlayer = coefficients; 
                StringBuilder secondPlayer = new StringBuilder();
                StringBuilder gamePrice = new StringBuilder();

                MaxSolutionScriptDoubleMatrixLab3_1(linearMatrix, firstPlayer, secondPlayer, gamePrice, protocolBuilder);

                double[] compromiseSolution = new double[optimalVectors.GetLength(1)];
                for (int j = 0; j < optimalVectors.GetLength(1); j++)
                {
                    for (int i = 0; i < optimalVectors.GetLength(0); i++)
                    {
                        compromiseSolution[j] += Math.Round(optimalVectors[i, j] * linearMatrix.firstP[i], 2);
                    }
                }

                compromiseSolutionBuilder.AppendLine(string.Join("; ", compromiseSolution));

                //вивід compromiseSolution у протокол
                protocolBuilder.AppendLine();
                protocolBuilder.AppendLine("Компромісний розв'язок:");
                protocolBuilder.AppendLine("X*(компр): " + string.Join("; ", compromiseSolution));

            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
            }            
        }

        private static double nonOptimalSolutionsCalculation(int itaya , int jtaya, double[,] optimalVectors, double[,] objFunctionsMatrix)
        {
            if (itaya == jtaya)
            {
                return 0;
            }

            double CjXi = 0;
            double CjXj = 0;
            double[] Cj = new double[objFunctionsMatrix.GetLength(1)];

            for (int j = 0; j < Cj.Length; j++)   
            {
                CjXi += optimalVectors[itaya,j] * objFunctionsMatrix[jtaya,j];
            }

            for (int j = 0; j < Cj.Length; j++)
            {
                CjXj += optimalVectors[jtaya, j] * objFunctionsMatrix[jtaya, j];
            }

            return Math.Abs((CjXi - CjXj) / CjXj);
        }

        public static double[] CalculateOptimalSolution(int variablesAmount, string zFunction, string restrictions, bool maxSolution, StringBuilder protocolBuilder)
        {
            LinearMatrix linearMatrix = LinearMatrixBuilder.CreateLinearMatrix(variablesAmount, zFunction, restrictions);
            StringBuilder xResult = new StringBuilder();// not usable
            StringBuilder zResult = new StringBuilder();// not usable

            if (maxSolution)
            {
                FormPrint.FancyMatrixPrint(linearMatrix, protocolBuilder);

                try
                {
                    MathCalculation.ZerosElimanating(linearMatrix, protocolBuilder);
                    MaxSolutionScript(linearMatrix, xResult, zResult, protocolBuilder);
                }
                catch (Exception ex)
                {
                    protocolBuilder.AppendLine(ex.Message);
                }
            }
            else
            {
                //приведення Z до Z'
                for (int j = 0; j < linearMatrix.matrix.GetLength(1) - 1; j++)
                {
                    linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, j] *= -1;
                }

                FormPrint.FancyMatrixPrint(linearMatrix, protocolBuilder);

                try
                {
                    MathCalculation.ZerosElimanating(linearMatrix, protocolBuilder);
                    MinSolutionScript(linearMatrix, xResult, zResult, protocolBuilder);
                }
                catch (Exception ex)
                {
                    protocolBuilder.AppendLine(ex.Message);
                }
            }

            //protocolBuilder.AppendLine(xResult.ToString());
            //protocolBuilder.AppendLine(zResult.ToString());

            return linearMatrix.res;
        }

    }
}
