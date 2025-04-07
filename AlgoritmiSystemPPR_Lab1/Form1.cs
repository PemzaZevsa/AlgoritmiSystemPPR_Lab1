using ClassLibrary1;
using System;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AlgoritmiSystemPPR_Lab1
{
    public partial class Form1 : Form
    {
        private double[,] aMatrix;

        private double[] bMatrix;

        private double[,] inverseMatrix;

        //lab 1.1

        public Form1()
        {
            InitializeComponent();
            aMatrix = null;
            bMatrix = null;
            inverseMatrix = null;
        }

        private void GenerateMatrixButton_Click(object sender, EventArgs e)
        {
            aMatrix = MathCalculation.GenerateMatrix(((int)matrixRows.Value), ((int)matrixCols.Value), 1, 5);
            bMatrix = MathCalculation.GenerateArray(((int)matrixRows.Value), 1, 5);

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
            aMatrix = FormPrint.ReadMatrixFromRichTextBox(matrixrRichTextBox.Text, stringBuilder);

            try
            {
                inverseMatrix = MathCalculation.InverseMatrix(aMatrix, stringBuilder);
                StringBuilder inverseBuilder = new StringBuilder();
                FormPrint.ProtocolMatrixPrint(inverseMatrix, inverseBuilder);
                inverseMatrixRichTextBox.Text = inverseBuilder.ToString();
            }
            catch (Exception ex)
            {
                protocolRichTextBox.Text += stringBuilder.ToString();
                protocolRichTextBox.Text += ex.Message;
            }

            protocolRichTextBox.Text += stringBuilder.ToString();
        }

        private void matrixRankButton_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            aMatrix = FormPrint.ReadMatrixFromRichTextBox(matrixrRichTextBox.Text, stringBuilder);

            try
            {
                int rank = MathCalculation.MatrixRank(aMatrix, stringBuilder);
                matrixRankTextBox.Clear();
                matrixRankTextBox.Text = $"{rank}";
                protocolRichTextBox.Text += stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                protocolRichTextBox.Text += stringBuilder.ToString();
                protocolRichTextBox.Text += ex.Message;
            }
        }

        private void SLAUCalculateButton_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            //reading
            aMatrix = FormPrint.ReadMatrixFromRichTextBox(matrixrRichTextBox.Text, stringBuilder);
            bMatrix = FormPrint.ReadMatrixBFromRichTextBox(matrixBRichTextBox.Text, stringBuilder);

            //preparations
            inverseMatrix = MathCalculation.InverseMatrix(aMatrix, stringBuilder);
            StringBuilder inverseBuilder = new StringBuilder();
            FormPrint.ProtocolMatrixPrint(inverseMatrix, inverseBuilder);
            inverseMatrixRichTextBox.Text = inverseBuilder.ToString();

            //calculation
            double[] xMatrix = MathCalculation.SLAU(bMatrix, inverseMatrix, stringBuilder);
            StringBuilder xBuilder = new StringBuilder();
            FormPrint.ArrayPrint(xMatrix, xBuilder);
            matrixXRichTextBox.Text = xBuilder.ToString();

            //protocol
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

            aMatrix = MathCalculation.CopyMatrix(tempMatrix);
            bMatrix = MathCalculation.CopyArray(tempBMatrix);

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
            //Приклад 1
            StringBuilder limitations = new();
            limitations.AppendLine("5 2 7");
            limitations.AppendLine("1 4 3");
            limitations.AppendLine("6 1 5");
            gameMatrixLab3_1RichTextBox.Text = limitations.ToString();

            gamesAmountNumericUpDown.Value = 10;

            ////Приклад 2
            //StringBuilder limitations = new();
            //limitations.AppendLine("2 -1 3 3");
            //limitations.AppendLine("-1 2 2 7");
            //limitations.AppendLine("1 1 1 2");
            //gameMatrixLab3_1RichTextBox.Text = limitations.ToString();

            //gamesAmountNumericUpDown.Value = 10;

            ////Варіант 1
            //StringBuilder limitations = new();
            //limitations.AppendLine("1 1 2");
            //limitations.AppendLine("-1 -1 5");
            //limitations.AppendLine("2 3 -3");
            //gameMatrixLab3_1RichTextBox.Text = limitations.ToString();

            //gamesAmountNumericUpDown.Value = 100;

            ////Варіант 2
            //StringBuilder limitations = new();
            //limitations.AppendLine("13 17");
            //limitations.AppendLine("15 7");
            //gameMatrixLab3_1RichTextBox.Text = limitations.ToString();

            //gamesAmountNumericUpDown.Value = 100;

            ////Варіант 3
            //StringBuilder limitations = new();
            //limitations.AppendLine("4 5 7 10");
            //limitations.AppendLine("6 9 1 5");
            //gameMatrixLab3_1RichTextBox.Text = limitations.ToString();

            //gamesAmountNumericUpDown.Value = 100;
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
    }
}
