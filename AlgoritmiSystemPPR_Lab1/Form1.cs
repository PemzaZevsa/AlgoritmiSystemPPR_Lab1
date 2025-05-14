using ClassLibrary1;
using LabElements;
using System;
using System.Text;

namespace AlgoritmiSystemPPR_Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Lab 4
            lab4Element1.example += exampleLab4Button_Click;
            lab4Element1.calculateOptimalPlan += findOptimalStrategiesLab4Button_Click;

            //Lab 5
            lab5Element1.example += exampleLab5Button_Click;
            lab5Element1.calculateSolution += findOptimalStrategiesLab5Button_Click;
        }

        //lab 1.1

        private void GenerateMatrixButton_Click(object sender, EventArgs e)
        {
            double[,] aMatrix = MathCalculation.GenerateMatrix(((int)matrixRows.Value), ((int)matrixCols.Value), 1, 5);
            double[] bMatrix = MathCalculation.GenerateArray(((int)matrixRows.Value), 1, 5);

            StringBuilder rBuilder = new StringBuilder();
            StringBuilder bBuilder = new StringBuilder();

            FormPrint.MatrixPrint(aMatrix, rBuilder);
            FormPrint.ArrayPrint(bMatrix, bBuilder);

            matrixrRichTextBox.Text = rBuilder.ToString();
            matrixBRichTextBox.Text = bBuilder.ToString();
        }

        private void CalculateInverseMatrixButton_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder inverseBuilder = new StringBuilder();

            CalculationScenarios.CalculateInverseMatrix(matrixrRichTextBox.Text, inverseBuilder, stringBuilder);

            //protocol
            inverseMatrixRichTextBox.Text = inverseBuilder.ToString();
            protocolRichTextBox.Text += stringBuilder.ToString();
        }

        private void matrixRankButton_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder rankBuilder = new StringBuilder();

            CalculationScenarios.matrixRank(matrixrRichTextBox.Text, rankBuilder, stringBuilder);

            //protocol
            matrixRankTextBox.Text = rankBuilder.ToString();
            protocolRichTextBox.Text += stringBuilder.ToString();
        }

        private void SLAUCalculateButton_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder inverseBuilder = new StringBuilder();
            StringBuilder xBuilder = new StringBuilder();

            CalculationScenarios.SLAUCalculate(matrixrRichTextBox.Text, matrixBRichTextBox.Text, inverseBuilder, xBuilder, stringBuilder);

            //protocol
            inverseMatrixRichTextBox.Text = inverseBuilder.ToString();
            matrixXRichTextBox.Text = xBuilder.ToString();
            protocolRichTextBox.Text += stringBuilder.ToString();
        }

        private void loadMatrixButton_Click(object sender, EventArgs e)
        {
            double[,] tempMatrix = {
                        {1, 1, 2},
                        {-1, -1, 5},
                        {2, 3, -3},
                     };

            double[] tempBMatrix = {
                        5,
                        2,
                        4,
                     };

            double[,] aMatrix = MathCalculation.CopyMatrix(tempMatrix);
            double[] bMatrix = MathCalculation.CopyArray(tempBMatrix);

            StringBuilder rBuilder = new StringBuilder();
            StringBuilder bBuilder = new StringBuilder();

            FormPrint.MatrixPrint(aMatrix, rBuilder);
            FormPrint.ArrayPrint(bMatrix, bBuilder);

            matrixrRichTextBox.Text = rBuilder.ToString();
            matrixBRichTextBox.Text = bBuilder.ToString();
        }

        //protocol stuff

        private void protocolTextIncreaseButton_Click(object sender, EventArgs e)
        {
            protocolRichTextBox.Font = new Font(protocolRichTextBox.SelectionFont.FontFamily, protocolRichTextBox.SelectionFont.Size + 1);
        }

        private void protocolTextDecreaseButton_Click(object sender, EventArgs e)
        {
            try
            {
                protocolRichTextBox.Font = new Font(protocolRichTextBox.SelectionFont.FontFamily, protocolRichTextBox.SelectionFont.Size - 1);
            }
            catch (Exception ex)
            {
                protocolRichTextBox.Text += ex.Message;
            }
        }

        private void clearProtocolButton_Click(object sender, EventArgs e)
        {
            protocolRichTextBox.Clear();
        }

        //lab 1.2

        private void calculateOptimalSolutionButton_Click(object sender, EventArgs e)
        {
            StringBuilder protocol = new StringBuilder();
            StringBuilder xResult = new StringBuilder();
            StringBuilder zResult = new StringBuilder();

            CalculationScenarios.CalculateOptimalSolutionLab1_2(
                    variablesAmount: (int)variablesNumericUpDown.Value,
                    zFunction: zTextBox.Text,
                    restrictions: restrictionsRichTextBox.Text,
                    maxSolution: maxRadioButton.Checked,
                    minSolution: minRadioButton.Checked,
                    xResult: xResult,
                    zResult: zResult,
                    protocolBuilder: protocol
                );

            xResultTextBox.Text = xResult.ToString();
            zResultTextBox.Text = zResult.ToString();
            protocolRichTextBox.Text += protocol.ToString();
        }

        private void exampleButton_Click(object sender, EventArgs e)
        {
            //Приклад
            //StringBuilder limitations = new();
            //limitations.AppendLine("x1+x2-x3-2x4<=6");
            //limitations.AppendLine("x1+x2+x3-x4>=5");
            //limitations.AppendLine("2x1-x2+3x3+4x4<=10");
            //restrictionsRichTextBox.Text = limitations.ToString();

            //maxRadioButton.Checked = true;
            //variablesNumericUpDown.Value = 4;
            //zTextBox.Text = "x1+2x2-x3-x4";

            //Варіант
            StringBuilder limitations = new();
            limitations.AppendLine("x1+x2-x3-2x4<=6");
            limitations.AppendLine("x1+x2+x3-x4<=5");
            limitations.AppendLine("2x1-x2+3x3+4x4<=10");
            restrictionsRichTextBox.Text = limitations.ToString();

            minRadioButton.Checked = true;
            variablesNumericUpDown.Value = 4;
            zTextBox.Text = "x1-x3+x4";
        }

        //lab 1.3

        private void exampleButton2_Click(object sender, EventArgs e)
        {
            ////Приклад
            //StringBuilder limitations = new();
            //limitations.AppendLine("-2x1+x2+x3+3x4=2");
            //limitations.AppendLine("-3x1+2x2-3x3=7");
            //limitations.AppendLine("-3x1+x2+4x3+x4<=1");
            //limitations.AppendLine("-3x1+2x2-2x3+2x4>=9");
            //restrictionsRichTextBox2.Text = limitations.ToString();

            //maxRadioButton2.Checked = true;
            //variablesNumericUpDown2.Value = 4;
            //zTextBox2.Text = "10x1-x2-42x3-52x4";

            //Варіант
            StringBuilder limitations = new();
            limitations.AppendLine("x1+x2-x3-2x4<=6");
            limitations.AppendLine("x1+x2+x3-x4=5");
            limitations.AppendLine("2x1-x2+3x3+4x4<=10");
            restrictionsRichTextBox2.Text = limitations.ToString();

            minRadioButton2.Checked = true;
            variablesNumericUpDown2.Value = 4;
            zTextBox2.Text = "x1-x3+x4";

            ////Приклад з вільними змінними
            //StringBuilder limitations = new();
            //limitations.AppendLine("x1+2x2+1>=0");
            //limitations.AppendLine("2x1+x2-4>=0");
            //limitations.AppendLine("x1-x2+1>=0");
            //limitations.AppendLine("x1-4x2+13>=0");
            //limitations.AppendLine("-4x1+x2+23>=0");

            //restrictionsRichTextBox2.Text = limitations.ToString();

            //maxRadioButton2.Checked = true;
            //variablesNumericUpDown2.Value = 2;
            //zTextBox2.Text = "-3x1+6x2";
            //freeVariablesTextBox.Text = "x1 x2";
        }

        private void calculateOptimalSolutionButton2_Click(object sender, EventArgs e)
        {
            StringBuilder protocol = new StringBuilder();
            StringBuilder xResult = new StringBuilder();
            StringBuilder zResult = new StringBuilder();

            CalculationScenarios.CalculateOptimalSolutionLab1_3(
                    variablesAmount: (int)variablesNumericUpDown2.Value,
                    zFunction: zTextBox2.Text,
                    restrictions: restrictionsRichTextBox2.Text,
                    maxSolution: maxRadioButton2.Checked,
                    minSolution: minRadioButton2.Checked,
                    xResult: xResult,
                    zResult: zResult,
                    protocolBuilder: protocol
                );

            xResultTextBox2.Text = xResult.ToString();
            zResultTextBox2.Text = zResult.ToString();
            protocolRichTextBox.Text += protocol.ToString();
        }


        //lab 1.4

        private void exampleButton3_Click(object sender, EventArgs e)
        {
            ////Приклад
            //StringBuilder limitations = new();
            //limitations.AppendLine("3x1+2x2<=10");
            //limitations.AppendLine("x1+4x2<=11");
            //limitations.AppendLine("3x1+3x2+x3<=13");
            //restrictionsRichTextBox3.Text = limitations.ToString();

            //maxRadioButton3.Checked = true;
            //variablesNumericUpDown3.Value = 3;
            //zTextBox3.Text = "4x1+5x2+x3";

            //integerVariablesTextBox3.Text = "x1 x2 x3";

            //Варіант
            StringBuilder limitations = new();
            limitations.AppendLine("x1+x2-x3-2x4<=6");
            limitations.AppendLine("x1+x2+x3-x4<=5");
            limitations.AppendLine("2x1-x2+3x3+4x4>=10");
            restrictionsRichTextBox3.Text = limitations.ToString();

            minRadioButton3.Checked = true;
            variablesNumericUpDown3.Value = 4;
            zTextBox3.Text = "x1-x3+x4";

            integerVariablesTextBox3.Text = "x1 x2 x3 x4";
        }

        private void calculateOptimalSolutionButton3_Click(object sender, EventArgs e)
        {
            StringBuilder protocol = new StringBuilder();
            StringBuilder xResult = new StringBuilder();
            StringBuilder zResult = new StringBuilder();

            CalculationScenarios.CalculateOptimalSolutionLab1_4(
                    variablesAmount: (int)variablesNumericUpDown3.Value,
                    zFunction: zTextBox3.Text,
                    restrictions: restrictionsRichTextBox3.Text,
                    integerVariables: integerVariablesTextBox3.Text,
                    maxSolution: maxRadioButton3.Checked,
                    minSolution: minRadioButton3.Checked,
                    xResult: xResult,
                    zResult: zResult,
                    protocolBuilder: protocol
                );

            xResultTextBox3.Text = xResult.ToString();
            zResultTextBox3.Text = zResult.ToString();
            protocolRichTextBox.Text += protocol.ToString();
        }

        //Lab 2

        private void exampleLab2Button_Click(object sender, EventArgs e)
        {
            //Приклад 1
            StringBuilder limitations = new();
            limitations.AppendLine("x1+x2-x3-2x4<=6");
            limitations.AppendLine("x1+x2+x3-x4>=5");
            limitations.AppendLine("2x1-x2+3x3+4x4<=10");
            restrictionsLab2RichTextBox.Text = limitations.ToString();

            maxLab2RadioButton.Checked = true;
            variablesLab2NumericUpDown.Value = 4;
            zLab2TextBox.Text = "x1+2x2-x3-x4";

            ////Приклад 2
            //StringBuilder limitations = new();
            //limitations.AppendLine("-3x1+x2+4x3+x4<=1");
            //limitations.AppendLine("3x1-2x2+2x3-2x4<=-9");
            //limitations.AppendLine("-2x1+x2+x3+3x4=2");
            //limitations.AppendLine("-3x1+2x2-3x3=7");
            //restrictionsLab2RichTextBox.Text = limitations.ToString();

            //maxLab2RadioButton.Checked = true;
            //variablesLab2NumericUpDown.Value = 4;
            //zLab2TextBox.Text = "10x1-x2-42x3-52x4";

            ////Приклад 3
            //StringBuilder limitations = new();
            //limitations.AppendLine("-2x1+3x2<=14");
            //limitations.AppendLine("x1+x2<=8");
            //restrictionsLab2RichTextBox.Text = limitations.ToString();

            //maxLab2RadioButton.Checked = true;
            //variablesLab2NumericUpDown.Value = 2;
            //zLab2TextBox.Text = "2x1+7x2";

            ////Варіант
            //StringBuilder limitations = new();
            //limitations.AppendLine("x1+x2-x3-2x4<=6");
            //limitations.AppendLine("x1+x2+x3-x4<=5");
            //limitations.AppendLine("2x1-x2+3x3+4x4<=10");
            //restrictionsLab2RichTextBox.Text = limitations.ToString();

            //minLab2RadioButton.Checked = true;
            //variablesLab2NumericUpDown.Value = 4;
            //zLab2TextBox.Text = "x1-x3+x4";
        }

        private void calculateOptimalSolutionLab2Button_Click(object sender, EventArgs e)
        {
            StringBuilder protocol = new StringBuilder();
            StringBuilder solutions = new StringBuilder();

            CalculationScenarios.CalculateOptimalSolutionLab2(
                variablesAmount: (int)variablesLab2NumericUpDown.Value,
                zFunction: zLab2TextBox.Text,
                restrictions: restrictionsLab2RichTextBox.Text,
                maxSolution: maxLab2RadioButton.Checked,
                minSolution: minLab2RadioButton.Checked,
                solutionsResult: solutions,
                protocolBuilder: protocol
                );

            solutionsLab2richTextBox.Text = solutions.ToString();
            protocolRichTextBox.Text += protocol.ToString();
        }

        //Lab 3.1

        private void exampleLab3_1Button_Click(object sender, EventArgs e)
        {
            ////Приклад 1
            //StringBuilder limitations = new();
            //limitations.AppendLine("5 2 7");
            //limitations.AppendLine("1 4 3");
            //limitations.AppendLine("6 1 5");

            ////Приклад 2
            //StringBuilder limitations = new();
            //limitations.AppendLine("2 -1 3 3");
            //limitations.AppendLine("-1 2 2 7");
            //limitations.AppendLine("1 1 1 2");

            ////Варіант 1
            //StringBuilder limitations = new();
            //limitations.AppendLine("1 1 2");
            //limitations.AppendLine("-1 -1 5");
            //limitations.AppendLine("2 3 -3");

            ////Варіант 2
            //StringBuilder limitations = new();
            //limitations.AppendLine("13 17");
            //limitations.AppendLine("15 7");

            //Варіант 3
            StringBuilder limitations = new();
            limitations.AppendLine("4 5 7 10");
            limitations.AppendLine("6 9 1 5");

            gameMatrixLab3_1RichTextBox.Text = limitations.ToString();
            gamesAmountNumericUpDown.Value = 100;
        }

        private void calculateOptimalSolutionLab3_1Button_Click(object sender, EventArgs e)
        {
            StringBuilder firstPlayerBuilder = new StringBuilder();
            StringBuilder secondPlayerBuilder = new StringBuilder();
            StringBuilder gamePriceBuilder = new StringBuilder();
            StringBuilder protocolBuilder = new StringBuilder();

            CalculationScenarios.CalculateOptimalSolutionLab3_1(
                matrix: gameMatrixLab3_1RichTextBox.Text,
                firstPlayer: firstPlayerBuilder,
                secondPlayer: secondPlayerBuilder,
                gamePrice: gamePriceBuilder,
                protocolBuilder: protocolBuilder
                );//gamesAmount = 0

            player1StrategiesLab3_1TextBox.Text = firstPlayerBuilder.ToString();
            player2StrategiesLab3_1TextBox.Text = secondPlayerBuilder.ToString();
            gamePriceLab3_1TextBox.Text = gamePriceBuilder.ToString();
            protocolRichTextBox.Text += protocolBuilder.ToString();
        }

        private void modelGameLab3_1Button_Click(object sender, EventArgs e)
        {
            StringBuilder firstPlayerBuilder = new StringBuilder();
            StringBuilder secondPlayerBuilder = new StringBuilder();
            StringBuilder gamePriceBuilder = new StringBuilder();
            StringBuilder protocolBuilder = new StringBuilder();

            CalculationScenarios.CalculateOptimalSolutionLab3_1(
                matrix: gameMatrixLab3_1RichTextBox.Text,
                firstPlayer: firstPlayerBuilder,
                secondPlayer: secondPlayerBuilder,
                gamePrice: gamePriceBuilder,
                protocolBuilder: protocolBuilder,
                gamesAmount: (int)gamesAmountNumericUpDown.Value
                );

            player1StrategiesLab3_1TextBox.Text = firstPlayerBuilder.ToString();
            player2StrategiesLab3_1TextBox.Text = secondPlayerBuilder.ToString();
            gamePriceLab3_1TextBox.Text = gamePriceBuilder.ToString();
            protocolRichTextBox.Text += protocolBuilder.ToString();
        }

        //Lab 3.2

        private void exampleLab3_2Button_Click(object sender, EventArgs e)
        {
            ////Приклад 1
            //StringBuilder limitations = new();
            //limitations.AppendLine("-1 1 1 4");
            //limitations.AppendLine("-1 -2 2 3");
            //limitations.AppendLine("3 -1 3 2");
            //gameMatrixLab3_2RichTextBox.Text = limitations.ToString();
            //yCoefficientNumericUpDown.Value = 0.3m;
            //natureStrategiesLab3_2TextBox.Text = "0,2 0,4 0,1 0,3";

            //Варіант 1
            StringBuilder limitations = new();
            limitations.AppendLine("5 3 -6 4");
            limitations.AppendLine("3 5 -1 3");
            limitations.AppendLine("-1 -2 -3 2");
            gameMatrixLab3_2RichTextBox.Text = limitations.ToString();
            yCoefficientNumericUpDown.Value = 0.3m;
            natureStrategiesLab3_2TextBox.Text = "0,2 0,4 0,1 0,3";
        }

        private void findOptimalStrategiesLab3_2Button_Click(object sender, EventArgs e)
        {
            StringBuilder valdBuilder = new StringBuilder();
            StringBuilder gurvitsBuilder = new StringBuilder();
            StringBuilder maxiMaxBuilder = new StringBuilder();
            StringBuilder baesBuilder = new StringBuilder();
            StringBuilder savageBuilder = new StringBuilder();
            StringBuilder laplaceBuilder = new StringBuilder();
            StringBuilder theMostCommonBuilder = new StringBuilder();
            StringBuilder protocolBuilder = new StringBuilder();

            CalculationScenarios.CalculateOptimalSolutionLab3_2(
                matrixText: gameMatrixLab3_2RichTextBox.Text,
                coeff: (double)yCoefficientNumericUpDown.Value,
                percentageText: natureStrategiesLab3_2TextBox.Text,
                valdBuilder: valdBuilder,
                gurvitsBuilder: gurvitsBuilder,
                maxiMaxBuilder: maxiMaxBuilder,
                baesBuilder: baesBuilder,
                savageBuilder: savageBuilder,
                laplaceBuilder: laplaceBuilder,
                theMostCommonBuilder: theMostCommonBuilder,
                protocolBuilder: protocolBuilder
                );

            valdLab3_2TextBox.Text = valdBuilder.ToString();
            gurvitsLab3_2TextBox.Text = gurvitsBuilder.ToString();
            maxiMaxLab3_2TextBox.Text = maxiMaxBuilder.ToString();
            baesLab3_2TextBox.Text = baesBuilder.ToString();
            savageLab3_2TextBox.Text = savageBuilder.ToString();
            laplaceLab3_2TextBox.Text = laplaceBuilder.ToString();
            theMostCommonStrategyLab3_2TextBox.Text = theMostCommonBuilder.ToString();
            protocolRichTextBox.Text += protocolBuilder.ToString();
        }

        //RR

        private void exampleRRButton_Click(object sender, EventArgs e)
        {
            //Варіант 1
            StringBuilder limitations = new();
            limitations.AppendLine("x2+x3+2x4+x5<=6");
            limitations.AppendLine("x1+x2+x3+3x4+2x5<=9");
            limitations.AppendLine("x1+x2+2x4+x5<=5");
            restrictionsRRRichTextBox.Text = limitations.ToString();
            StringBuilder objFunctions = new();
            objFunctions.AppendLine("-4x4-x5 min");
            objFunctions.AppendLine("-x1-3x2+5x3+x4 min");
            objFunctions.AppendLine("3x1+x2+x3+x4+x5 max");
            objFunctionsRRRichTextBox.Text = objFunctions.ToString();
            variablesRRNumericUpDown.Value = 5;

            ////Приклад 1
            //StringBuilder limitations = new();
            //limitations.AppendLine("x1+4x2+3x3+2x4+x5=9");
            //limitations.AppendLine("-x1+2x2-x3+2x4+x5=6");
            //limitations.AppendLine("x1+2x2+2x4-x5=2");
            //restrictionsRRRichTextBox.Text = limitations.ToString();
            //StringBuilder objFunctions = new();
            //objFunctions.AppendLine("2x1+2x2+x3+x4+x5 max");
            //objFunctions.AppendLine("x1-3x2+5x3-x4-2x5 min");
            //objFunctions.AppendLine("x1-4x2+5x3+9x4-2x5 max");
            //objFunctionsRRRichTextBox.Text = objFunctions.ToString();
            //variablesRRNumericUpDown.Value = 5;

            ////Приклад 2
            //StringBuilder limitations = new();
            //limitations.AppendLine("x1-x2+x3+x4<=2");
            //limitations.AppendLine("x1+x2+x3-x4<=2");
            //limitations.AppendLine("-x1+x2+x3+x4<=2");
            //limitations.AppendLine("x1+x2-x3+x4<=2");
            //restrictionsRRRichTextBox.Text = limitations.ToString();
            //StringBuilder objFunctions = new();
            //objFunctions.AppendLine("x1-8x2+x3+4x4 max");
            //objFunctions.AppendLine("-x1+3x2+5x3+x4 min");
            //objFunctions.AppendLine("3x1+x2+x3-x4 max");
            //objFunctionsRRRichTextBox.Text = objFunctions.ToString();
            //variablesRRNumericUpDown.Value = 4;
        }

        private void findOptimalStrategiesRRButton_Click(object sender, EventArgs e)
        {
            StringBuilder objFunctionCoefficients = new StringBuilder();
            StringBuilder optimalVectors = new StringBuilder();
            StringBuilder nonOptimalSolutions = new StringBuilder();
            StringBuilder matrixGame = new StringBuilder();
            StringBuilder coefficients = new StringBuilder();
            StringBuilder compromiseSolution = new StringBuilder();
            StringBuilder protocolBuilder = new StringBuilder();

            CalculationScenarios.CalculateOptimalSolutionRR(
                objFunctionsText: objFunctionsRRRichTextBox.Text,
                restrictionsText: restrictionsRRRichTextBox.Text,
                variablesAmount: (int)variablesRRNumericUpDown.Value,
                objFunctionCoefficients: objFunctionCoefficients,
                optimalVectorsBuilder: optimalVectors,
                nonOptimalSolutionsBuilder: nonOptimalSolutions,
                matrixGame: matrixGame,
                coefficients: coefficients,
                compromiseSolutionBuilder: compromiseSolution,
                protocolBuilder: protocolBuilder
                );

            objFunctionCoefficientsRRRichTextBox.Text = objFunctionCoefficients.ToString();
            optimalVectorsRRRichTextBox.Text = optimalVectors.ToString();
            nonOptimalSolutionsRRichTextBox.Text = nonOptimalSolutions.ToString();
            matrixGameRRRichTextBox.Text = matrixGame.ToString();
            coefficientsRRTextBox.Text = coefficients.ToString();
            compromiseSolutionRRTextBox.Text = compromiseSolution.ToString();
            protocolRichTextBox.Text += protocolBuilder.ToString();
        }

        //Lab 4

        private void exampleLab4Button_Click()
        {
            //Варіант 1
            StringBuilder limitations = new();
            limitations.AppendLine("9 3 8 2");
            limitations.AppendLine("6 2 4 10");
            limitations.AppendLine("4 3 4 5");
            lab4Element1.costRichTextBox.Text = limitations.ToString();
            lab4Element1.suppliesTextBox.Text = "60 85 35";
            lab4Element1.applicationsTextBox.Text = "50 40 60 30";

            ////Приклад 1
            //StringBuilder limitations = new();
            //limitations.AppendLine("6 3 2");
            //limitations.AppendLine("2 1 5");
            //limitations.AppendLine("3 4 1");
            //lab4Element1.costRichTextBox.Text = limitations.ToString();
            //lab4Element1.suppliesTextBox.Text = "30 20 50";
            //lab4Element1.applicationsTextBox.Text = "10 65 25";
        }

        private void findOptimalStrategiesLab4Button_Click()
        {
            StringBuilder supportBuilder = new StringBuilder();
            StringBuilder supportCostBuilder = new StringBuilder();
            StringBuilder optimalBuilder = new StringBuilder();
            StringBuilder optimalCostBuilder = new StringBuilder();
            StringBuilder protocolBuilder = new StringBuilder();

            CalculationScenarios.CalculateOptimalSolutionLab4(
                costText: lab4Element1.costRichTextBox.Text,
                suppliesText: lab4Element1.suppliesTextBox.Text,
                applicationsText: lab4Element1.applicationsTextBox.Text,
                simplex: lab4Element1.simplexCheckBox.Checked,
                supportBuilder: supportBuilder,
                supportCostBuilder: supportCostBuilder,
                optimalBuilder: optimalBuilder,
                optimalCostBuilder: optimalCostBuilder,
                protocolBuilder: protocolBuilder
                );

            lab4Element1.supportingSolutionRichTextBox.Text = supportBuilder.ToString();
            lab4Element1.supportingCostTextBox.Text = supportCostBuilder.ToString();
            lab4Element1.optimalSolutionRichTextBox.Text = optimalBuilder.ToString();
            lab4Element1.optimalCostTextBox.Text = optimalCostBuilder.ToString();
            protocolRichTextBox.Text += protocolBuilder.ToString();
        }

        //Lab 5

        private void exampleLab5Button_Click()
        {
            //Варіант 
            StringBuilder limitations = new();
            limitations.AppendLine("6 7 2 8");
            limitations.AppendLine("8 6 9 4");
            limitations.AppendLine("5 4 7 6");
            limitations.AppendLine("7 5 3 5");
            lab5Element1.costMatrixRichTextBox.Text = limitations.ToString();

            ////Приклад 1
            //StringBuilder limitations = new();
            //limitations.AppendLine("2 10 9 7");
            //limitations.AppendLine("15 4 14 8");
            //limitations.AppendLine("13 14 16 11");
            //limitations.AppendLine("4 15 13 19");
            //lab5Element1.costMatrixRichTextBox.Text = limitations.ToString();

            ////Приклад 2
            //StringBuilder limitations = new();
            //limitations.AppendLine("2 4 1 3 3");
            //limitations.AppendLine("1 5 4 1 2");
            //limitations.AppendLine("3 5 2 2 4");
            //limitations.AppendLine("1 4 3 1 4");
            //limitations.AppendLine("3 2 5 3 5");
            //lab5Element1.costMatrixRichTextBox.Text = limitations.ToString();
        }

        private void findOptimalStrategiesLab5Button_Click()
        {
            StringBuilder assimentMatrixBuilder = new StringBuilder();
            StringBuilder costBuilder = new StringBuilder();
            StringBuilder protocolBuilder = new StringBuilder();

            CalculationScenarios.CalculateOptimalSolutionLab5(
                costText: lab5Element1.costMatrixRichTextBox.Text,
                simplex: lab5Element1.IsSimplex,
                assimentMatrixBuilder: assimentMatrixBuilder,
                costBuilder: costBuilder,
                protocolBuilder: protocolBuilder
                );

            lab5Element1.costTextBox.Text = costBuilder.ToString();
            lab5Element1.assignmentMatrixRichTextBox.Text = assimentMatrixBuilder.ToString();
            protocolRichTextBox.Text += protocolBuilder.ToString();
        }
    }
}
