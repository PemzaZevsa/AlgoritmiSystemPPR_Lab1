using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class CalculationScenarios
    {
        //Lab 1.1

        //public static void SLAUCalculateButton_Click(object sender, EventArgs e)
        //{
        //    StringBuilder stringBuilder = new StringBuilder();

        //    //reading
        //    aMatrix = FormPrint.ReadMatrixFromRichTextBox(matrixrRichTextBox.Text, stringBuilder);
        //    bMatrix = FormPrint.ReadMatrixBFromRichTextBox(matrixBRichTextBox.Text, stringBuilder);

        //    //preparations
        //    inverseMatrix = MathCalculation.InverseMatrix(aMatrix, stringBuilder);
        //    StringBuilder inverseBuilder = new StringBuilder();
        //    FormPrint.ProtocolMatrixPrint(inverseMatrix, inverseBuilder);
        //    inverseMatrixRichTextBox.Text = inverseBuilder.ToString();

        //    //calculation
        //    double[] xMatrix = MathCalculation.SLAU(bMatrix, inverseMatrix, stringBuilder);
        //    StringBuilder xBuilder = new StringBuilder();
        //    FormPrint.ArrayPrint(xMatrix, xBuilder);
        //    matrixXRichTextBox.Text = xBuilder.ToString();

        //    //protocol
        //    protocolRichTextBox.Text += stringBuilder.ToString();
        //}

        //Lab 1.2

        public static void CalculateOptimalSolutionLab1_2(int variablesAmount, string zFunction, string restrictions, bool maxSolution, bool minSolution, StringBuilder xResult, StringBuilder zResult, StringBuilder protocolBuilder)
        {
            double[,] matrix = LinearMatrixBuilder.CreateMatrix(variablesAmount, zFunction, restrictions);
            //StringBuilder protocolBuilder = new StringBuilder();

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

            //protocol
            //protocolRichTextBox.Text += stringBuilder.ToString();
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

                //xResultTextBox.Text = str;
                double zRes = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
                zResult.AppendLine($"{zRes}");

                //zResultTextBox.Text = $"{zRes}";
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
                //xResultTextBox.Text = str;

                //min Z = -(max Z')
                double zRes = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1] * -1;
                zResult.AppendLine($"{zRes}");
                //zResultTextBox.Text = $"{zRes}";
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
            //StringBuilder protocolBuilder = new StringBuilder();
            //StringBuilder xResult = new StringBuilder();
            //StringBuilder zResult = new StringBuilder();

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

            //xResultTextBox2.Text = xResult.ToString();
            //zResultTextBox2.Text = zResult.ToString();
            //protocolRichTextBox.Text += protocolBuilder.ToString();
        }

        private static void MaxSolutionScript(LinearMatrix linearMatrix, StringBuilder xResult, StringBuilder zResult, StringBuilder protocolBuilder)
        {
            try
            {
                //Support solution
                protocolBuilder.AppendLine("Знаходження опорного рішення:");
                double[] result = MathCalculation.SupportSolution(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("Опорний розв'язок знайдено:");
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                string str = string.Join(", ", result);
                protocolBuilder.AppendLine($"X:({str})\n");

                //Optimal solution
                protocolBuilder.AppendLine("Знаходження оптимального рішення:");
                result = MathCalculation.OptimalSolution(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("Оптимальний розв'язок знайдено:");
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                str = string.Join(", ", result);
                protocolBuilder.AppendLine($"X:({str})\n");
                xResult.Clear();
                xResult.AppendLine($"{str}");

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
                protocolBuilder.AppendLine("Знаходження опорного рішення:");
                double[] result = MathCalculation.SupportSolution(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("Опорний розв'язок знайдено:");
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                string str = string.Join(", ", result);
                protocolBuilder.AppendLine($"X:({str})\n");

                //Optimal solution
                protocolBuilder.AppendLine("Знаходження оптимального рішення:");
                result = MathCalculation.OptimalSolution(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("Оптимальний розв'язок знайдено:");
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                str = string.Join(", ", result);
                protocolBuilder.AppendLine($"X:({str})\n");
                xResult.Clear();
                xResult.AppendLine($"{str}");

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
            //StringBuilder stringBuilder = new StringBuilder();
            //StringBuilder xResult = new StringBuilder();
            //StringBuilder zResult = new StringBuilder();

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

            //xResultTextBox3.Text = xResult.ToString();
            //zResultTextBox3.Text = zResult.ToString();
            //protocolRichTextBox.Text += protocolBuilder.ToString();
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
            //StringBuilder protocolBuilder = new StringBuilder();
            //StringBuilder solutionsResult = new StringBuilder();

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

            //solutionsLab2richTextBox.Text = solutionsResult.ToString();
            //protocolRichTextBox.Text += protocolBuilder.ToString();
        }

        private static void MaxSolutionScriptDoubleMatrix(LinearMatrix linearMatrix, StringBuilder xResult, StringBuilder zResult, 
            StringBuilder protocolBuilder)
        {
            try
            {
                //Support solution
                protocolBuilder.AppendLine("Знаходження опорного рішення:");
                double[] result = MathCalculation.SupportSolutionDoubleMatrix(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("Опорний розв'язок знайдено:");
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                string str = string.Join("; ", result);
                protocolBuilder.AppendLine($"X:({str})\n");

                //Optimal solution
                protocolBuilder.AppendLine("Знаходження оптимального рішення:");
                result = MathCalculation.OptimalSolutionDoubleMatrix(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("Оптимальний розв'язок знайдено:");
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                str = string.Join("; ", result);
                protocolBuilder.AppendLine($"X:({str})\n");
                xResult.AppendLine($"Розв'язки прямої задачі:");
                xResult.AppendLine($"X = ({str})");

                result = MathCalculation.DoubleLinearTask(linearMatrix, protocolBuilder);
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                str = string.Join("; ", result);
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
                protocolBuilder.AppendLine("Знаходження опорного рішення:");
                double[] result = MathCalculation.SupportSolutionDoubleMatrix(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("Опорний розв'язок знайдено:");
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                string str = string.Join("; ", result);
                protocolBuilder.AppendLine($"X:({str})\n");

                //Optimal solution
                protocolBuilder.AppendLine("Знаходження оптимального рішення:");
                result = MathCalculation.OptimalSolutionDoubleMatrix(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("Оптимальний розв'язок знайдено:");
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                str = string.Join("; ", result);
                protocolBuilder.AppendLine($"X:({str})\n");
                xResult.AppendLine($"Розв'язки прямої задачі:");
                xResult.AppendLine($"X = ({str})");

                result = MathCalculation.DoubleLinearTask(linearMatrix, protocolBuilder);
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                str = string.Join("; ", result);
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
                    //double[,] matrix, double[] firstStrategies, double[] secondStrategies, int gamesAmount, StringBuilder protocolBuilder
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
                protocolBuilder.AppendLine("Знаходження опорного рішення:");
                double[] result = MathCalculation.SupportSolutionDoubleMatrix(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("Опорний розв'язок знайдено:");
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                string str = string.Join("; ", result);
                protocolBuilder.AppendLine($"X:({str})\n");

                //Optimal solution
                protocolBuilder.AppendLine("Знаходження оптимального рішення:");
                result = MathCalculation.OptimalSolutionDoubleMatrix(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("Оптимальний розв'язок знайдено:");
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Math.Round(result[i], 2);
                }
                str = string.Join("; ", result);
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

    }
}
