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

        //private void CalculateOptimalSolution()
        //{
        //    double[,] matrix = LinearMatrixBuilder.CreateMatrix((int)variablesNumericUpDown.Value, zTextBox.Text, restrictionsRichTextBox.Text);
        //    StringBuilder stringBuilder = new StringBuilder();

        //    if (maxRadioButton.Checked)
        //    {
        //        FancyPrintMatrixOnRichTextBox(matrix, protocolRichTextBox);
        //        MaxSolutionScript(matrix, stringBuilder);
        //    }

        //    if (minRadioButton.Checked)
        //    {
        //        //приведення до Z'
        //        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        //        {
        //            matrix[matrix.GetLength(0) - 1, j] *= -1;
        //        }

        //        FancyPrintMatrixOnRichTextBox(matrix, protocolRichTextBox);
        //        MinSolutionScript(matrix, stringBuilder);
        //    }

        //    //protocol
        //    protocolRichTextBox.Text += stringBuilder.ToString();
        //}

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

        //private void CalculateOptimalSolution2()
        //{
        //    LinearMatrix linearMatrix = LinearMatrixBuilder.CreateLinearMatrix((int)variablesNumericUpDown2.Value, zTextBox2.Text, restrictionsRichTextBox2.Text);
        //    double[,] matrix = linearMatrix.matrix;
        //    StringBuilder stringBuilder = new StringBuilder();
        //    StringBuilder xResult = new StringBuilder();
        //    StringBuilder zResult = new StringBuilder();

        //    if (maxRadioButton2.Checked)
        //    {
        //        FormStaff.FancyMatrixPrint(linearMatrix, stringBuilder);

        //        try
        //        {
        //            MathCalculation.ZerosElimanating(linearMatrix, stringBuilder);
        //            MaxSolutionScript(linearMatrix, xResult, zResult, stringBuilder);
        //        }
        //        catch (Exception ex)
        //        {
        //            stringBuilder.AppendLine(ex.Message);
        //        }
        //    }

        //    if (minRadioButton2.Checked)
        //    {
        //        //приведення Z до Z'
        //        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        //        {
        //            matrix[matrix.GetLength(0) - 1, j] *= -1;
        //        }

        //        FormStaff.FancyMatrixPrint(linearMatrix, stringBuilder);

        //        try
        //        {
        //            MathCalculation.ZerosElimanating(linearMatrix, stringBuilder);
        //            MinSolutionScript(linearMatrix, xResult, zResult, stringBuilder);
        //        }
        //        catch (Exception ex)
        //        {
        //            stringBuilder.AppendLine(ex.Message);
        //        }
        //    }

        //    xResultTextBox2.Text = xResult.ToString();
        //    zResultTextBox2.Text = zResult.ToString();
        //    protocolRichTextBox.Text += stringBuilder.ToString();
        //}

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

        //private void CalculateOptimalSolution3()
        //{
        //    LinearMatrix linearMatrix = LinearMatrixBuilder.CreateLinearMatrix((int)variablesNumericUpDown3.Value, zTextBox3.Text, restrictionsRichTextBox3.Text, integerVariablesTextBox3.Text);
        //    StringBuilder stringBuilder = new StringBuilder();
        //    StringBuilder xResult = new StringBuilder();
        //    StringBuilder zResult = new StringBuilder();

        //    if (maxRadioButton3.Checked)
        //    {
        //        FormStaff.FancyMatrixPrint(linearMatrix, stringBuilder);

        //        try
        //        {
        //            MaxSolutionScriptWithIntegers(linearMatrix, xResult, zResult, stringBuilder);
        //        }
        //        catch (Exception ex)
        //        {
        //            stringBuilder.AppendLine(ex.Message);
        //        }
        //    }

        //    if (minRadioButton3.Checked)
        //    {
        //        //приведення Z до Z'
        //        for (int j = 0; j < linearMatrix.matrix.GetLength(1) - 1; j++)
        //        {
        //            linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, j] *= -1;
        //        }

        //        FormStaff.FancyMatrixPrint(linearMatrix, stringBuilder);

        //        try
        //        {
        //            MinSolutionScriptWithIntegers(linearMatrix, xResult, zResult, stringBuilder);
        //        }
        //        catch (Exception ex)
        //        {
        //            stringBuilder.AppendLine(ex.Message);
        //        }
        //    }

        //    xResultTextBox3.Text = xResult.ToString();
        //    zResultTextBox3.Text = zResult.ToString();
        //    protocolRichTextBox.Text += stringBuilder.ToString();
        //}

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

        //private void CalculateOptimalSolutionLab2()
        //{
        //    LinearMatrix linearMatrix =  LinearMatrixBuilder.CreateDoubleLinearMatrix((int)variablesLab2NumericUpDown.Value, zLab2TextBox.Text, restrictionsLab2RichTextBox.Text);
        //    StringBuilder protocolBuilder = new StringBuilder();
        //    StringBuilder solutionsResult = new StringBuilder();

        //    if (maxLab2RadioButton.Checked)
        //    {
        //        FormStaff.FancyDoubleMatrixPrint(linearMatrix, protocolBuilder);

        //        try
        //        {
        //            MaxSolutionScriptDoubleMatrix(linearMatrix, solutionsResult, solutionsResult, protocolBuilder);
        //        }
        //        catch (Exception ex)
        //        {
        //            protocolBuilder.AppendLine(ex.Message);
        //        }
        //    }

        //    if (minLab2RadioButton.Checked)
        //    {
        //        //приведення Z до Z'
        //        for (int j = 0; j < linearMatrix.matrix.GetLength(1) - 1; j++)
        //        {
        //            linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, j] *= -1;
        //        }

        //        FormStaff.FancyDoubleMatrixPrint(linearMatrix, protocolBuilder);

        //        try
        //        {
        //            MinSolutionScriptDoubleMatrix(linearMatrix, solutionsResult, solutionsResult, protocolBuilder);
        //        }
        //        catch (Exception ex)
        //        {
        //            protocolBuilder.AppendLine(ex.Message);
        //        }
        //    }

        //    solutionsLab2richTextBox.Text = solutionsResult.ToString();
        //    protocolRichTextBox.Text += protocolBuilder.ToString();
        //}

        //Lab 3.1

        private void exampleLab3_1Button_Click(object sender, EventArgs e)
        {

        }

        private void calculateOptimalSolutionLab3_1Button_Click(object sender, EventArgs e)
        {

        }

        private void modelGameLab3_1Button_Click(object sender, EventArgs e)
        {

        }
    }
}
