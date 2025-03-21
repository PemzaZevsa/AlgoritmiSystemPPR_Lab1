using ClassLibrary1;
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

        public Form1()
        {
            InitializeComponent();
            aMatrix = null;
            bMatrix = null;
            inverseMatrix = null;
        }

        //lab 1.1
        private void PrintMatrixOnRichTextBox(double[,] incertMatrix, RichTextBox richTextBox)
        {
            richTextBox.Clear();

            for (int i = 0; i < incertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < incertMatrix.GetLength(1); j++)
                {
                    richTextBox.Text += Math.Round(incertMatrix[i, j], 3);
                    richTextBox.Text += " ";
                }
                richTextBox.Text += "\n";
            }
        }

        private void FancyPrintMatrixOnRichTextBox(double[,] incertMatrix, RichTextBox richTextBox)
        {
            //richTextBox.Clear();

            for (int i = 0; i < incertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < incertMatrix.GetLength(1); j++)
                {
                    richTextBox.Text += Math.Round(incertMatrix[i, j], 3);
                    richTextBox.Text += "\t";
                }
                richTextBox.Text += "\n";
            }
        }

        private void PrintArrayOnRichTextBox(double[] incertMatrix, RichTextBox richTextBox)
        {
            //richTextBox.Clear();

            for (int i = 0; i < incertMatrix.GetLength(0); i++)
            {
                richTextBox.Text += Math.Round(incertMatrix[i], 3);
                richTextBox.Text += "\n";
            }
        }

        private void GenerateMatrixButton_Click(object sender, EventArgs e)
        {
            aMatrix = MathCalculation.GenerateMatrix(((int)matrixRows.Value), ((int)matrixCols.Value), 1, 5);
            bMatrix = MathCalculation.GenerateArray(((int)matrixRows.Value), 1, 5);

            PrintMatrixOnRichTextBox(aMatrix, matrixrRichTextBox);
            PrintArrayOnRichTextBox(bMatrix, matrixBRichTextBox);
        }

        private void CalculateInverseMatrixButton_Click(object sender, EventArgs e)
        {
            aMatrix = ReadMatrixFromRichTextBox(matrixrRichTextBox);

            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                inverseMatrix = MathCalculation.InverseMatrix(aMatrix, stringBuilder);
                FancyPrintMatrixOnRichTextBox(inverseMatrix, inverseMatrixRichTextBox);
            }
            catch (Exception ex)
            {
                protocolRichTextBox.Text += stringBuilder.ToString();
                protocolRichTextBox.Text += ex.Message;
            }

            //protocolRichTextBox.Clear();
            protocolRichTextBox.Text += stringBuilder.ToString();
        }

        private void matrixRankButton_Click(object sender, EventArgs e)
        {
            aMatrix = ReadMatrixFromRichTextBox(matrixrRichTextBox);

            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                int rank = MathCalculation.MatrixRank(aMatrix, stringBuilder);
                matrixRankTextBox.Clear();
                matrixRankTextBox.Text = $"{rank}";

                //protocol
                //protocolRichTextBox.Clear();
                protocolRichTextBox.Text += stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                //protocolRichTextBox.Clear();
                protocolRichTextBox.Text += stringBuilder.ToString();
                protocolRichTextBox.Text += ex.Message;
            }
        }

        private void SLAUCalculateButton_Click(object sender, EventArgs e)
        {
            //reading
            aMatrix = ReadMatrixFromRichTextBox(matrixrRichTextBox);
            bMatrix = ReadMatrixBFromRichTextBox(matrixBRichTextBox);

            //preparations
            StringBuilder stringBuilder = new StringBuilder();
            inverseMatrix = MathCalculation.InverseMatrix(aMatrix, stringBuilder);
            FancyPrintMatrixOnRichTextBox(inverseMatrix, inverseMatrixRichTextBox);

            //calculation
            double[] xMatrix = MathCalculation.SLAU(bMatrix, inverseMatrix, stringBuilder);
            PrintArrayOnRichTextBox(xMatrix, matrixXRichTextBox);

            //protocol
            //protocolRichTextBox.Clear();
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

            PrintMatrixOnRichTextBox(aMatrix, matrixrRichTextBox);
            PrintArrayOnRichTextBox(bMatrix, matrixBRichTextBox);
        }

        private double[,] ReadMatrixFromRichTextBox(RichTextBox inputRichTextBox)
        {
            string[] rows = inputRichTextBox.Text.Trim().Split('\n');
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
                protocolRichTextBox.Text += $"{ex.Message}\n";
            }

            return matrix;
        }

        private double[] ReadMatrixBFromRichTextBox(RichTextBox inputRichTextBox)
        {
            string[] elements = inputRichTextBox.Text.Trim().Split('\n');
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
                protocolRichTextBox.Text += $"{ex.Message}\n";
            }

            return array;
        }

        //protocol
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
            CalculateOptimalSolution();
        }

        private void CalculateOptimalSolution()
        {
            double[,] matrix = MatrixFill();

            if (maxRadioButton.Checked)
            {
                FancyPrintMatrixOnRichTextBox(matrix, protocolRichTextBox);
                MaxSolutionScript(matrix);
            }

            if (minRadioButton.Checked)
            {
                //���������� �� Z'
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    matrix[matrix.GetLength(0) - 1, j] *= -1;
                }

                FancyPrintMatrixOnRichTextBox(matrix, protocolRichTextBox);
                MinSolutionScript(matrix);
            }
        }

        private void MaxSolutionScript(double[,] matrix)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("����������� �������� ������:");
            int[] rowsHeading = null;
            int[] colsHeading = null;
            try
            {
                double[] result = MathCalculation.SupportSolution(ref matrix, stringBuilder, out rowsHeading, out colsHeading);
                stringBuilder.AppendLine("������� ����'���� ��������:");

                string str = string.Join(", ", result);
                stringBuilder.AppendLine($"X:({str})\n");
            }
            catch (Exception ex)
            {
                protocolRichTextBox.Text += ex.Message;
            }

            stringBuilder.AppendLine("����������� ������������ ������:");
            try
            {
                double[] result = MathCalculation.OptimalSolution(ref matrix, stringBuilder, rowsHeading, colsHeading);
                stringBuilder.AppendLine("����������� ����'���� ��������:");

                string str = string.Join(", ", result);
                stringBuilder.AppendLine($"X:({str})\n");
                xResultTextBox.Text = str;

                double zRes = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
                zResultTextBox.Text = $"{zRes}";
            }
            catch (Exception ex)
            {
                protocolRichTextBox.Text += ex.Message;
            }

            //protocol
            protocolRichTextBox.Text += stringBuilder.ToString();
        }

        private double[,] MatrixFill()
        {
            int variblesAmount = ((int)variablesNumericUpDown.Value);
            string zString = zTextBox.Text.Trim().ToLower();
            string[] restrictions = restrictionsRichTextBox.Text.Trim().Split('\n');

            int[] variables = MathCalculation.VariablesRead(variblesAmount, zString);
            double[,] matrix = MathCalculation.MatrixFill(variables, restrictions);
            return matrix;
        }

        private void MinSolutionScript(double[,] matrix)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("����������� �������� ������:");
            int[] rowsHeading = null;
            int[] colsHeading = null;
            try
            {
                double[] result = MathCalculation.SupportSolution(ref matrix, stringBuilder, out rowsHeading, out colsHeading);
                stringBuilder.AppendLine("������� ����'���� ��������:");

                string str = string.Join(", ", result);
                stringBuilder.AppendLine($"X:({str})\n");
            }
            catch (Exception ex)
            {
                protocolRichTextBox.Text += ex.Message;
            }

            stringBuilder.AppendLine("����������� ������������ ������:");
            try
            {
                double[] result = MathCalculation.OptimalSolution(ref matrix, stringBuilder, rowsHeading, colsHeading);
                stringBuilder.AppendLine("����������� ����'���� ��������:");

                string str = string.Join(", ", result);
                stringBuilder.AppendLine($"X:({str})\n");
                xResultTextBox.Text = str;

                //min Z = -(max Z')
                double zRes = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1] * -1;
                zResultTextBox.Text = $"{zRes}";
            }
            catch (Exception ex)
            {
                protocolRichTextBox.Text += ex.Message;
            }

            //protocol
            protocolRichTextBox.Text += stringBuilder.ToString();
        }

        private void exampleButton_Click(object sender, EventArgs e)
        {
            StringBuilder limitations = new();
            limitations.AppendLine("x1+x2-x3-2x4<=6");
            limitations.AppendLine("x1+x2+x3-x4>=5");
            limitations.AppendLine("2x1-x2+3x3+4x4<=10");
            restrictionsRichTextBox.Text = limitations.ToString();

            maxRadioButton.Checked = true;
            variablesNumericUpDown.Value = 4;
            zTextBox.Text = "x1+2x2-x3-x4";

            //StringBuilder limitations = new();
            //limitations.AppendLine("x1+x2-x3-2x4<=6");
            //limitations.AppendLine("x1+x2+x3-x4<=5");
            //limitations.AppendLine("2x1-x2+3x3+4x4<=10");
            //restrictionsRichTextBox.Text = limitations.ToString();

            //minRadioButton.Checked = true;
            //variablesNumericUpDown.Value = 4;
            //zTextBox.Text = "x1-x3+x4";
        }

        //lab 1.3

        private void exampleButton2_Click(object sender, EventArgs e)
        {
            ////�������
            //StringBuilder limitations = new();
            //limitations.AppendLine("-2x1+x2+x3+3x4=2");
            //limitations.AppendLine("-3x1+2x2-3x3=7");
            //limitations.AppendLine("-3x1+x2+4x3+x4<=1");
            //limitations.AppendLine("-3x1+2x2-2x3+2x4>=9");
            //restrictionsRichTextBox2.Text = limitations.ToString();

            //maxRadioButton2.Checked = true;
            //variablesNumericUpDown2.Value = 4;
            //zTextBox2.Text = "10x1-x2-42x3-52x4";

            //������
            StringBuilder limitations = new();
            limitations.AppendLine("x1+x2-x3-2x4<=6");
            limitations.AppendLine("x1+x2+x3-x4=5");
            limitations.AppendLine("2x1-x2+3x3+4x4<=10");
            restrictionsRichTextBox2.Text = limitations.ToString();

            minRadioButton2.Checked = true;
            variablesNumericUpDown2.Value = 4;
            zTextBox2.Text = "x1-x3+x4";

            ////������� � ������� �������
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
            CalculateOptimalSolution2();
        }

        private void CalculateOptimalSolution2()
        {
            LinearMatrix linearMatrix = MatrixFillSkript();
            double[,] matrix = linearMatrix.matrix;
            StringBuilder stringBuilder = new StringBuilder();

            if (maxRadioButton2.Checked)
            {
                FormStaff.FancyMatrixPrint(linearMatrix, stringBuilder);

                try
                {
                    MathCalculation.ZerosElimanating(linearMatrix, stringBuilder);
                    MaxSolutionScript(linearMatrix, stringBuilder);
                }
                catch (Exception ex)
                {
                    stringBuilder.AppendLine(ex.Message);
                }
            }

            if (minRadioButton2.Checked)
            {
                //���������� Z �� Z'
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    matrix[matrix.GetLength(0) - 1, j] *= -1;
                }

                FormStaff.FancyMatrixPrint(linearMatrix, stringBuilder);

                try
                {
                    MathCalculation.ZerosElimanating(linearMatrix, stringBuilder);
                    MinSolutionScript(linearMatrix, stringBuilder);
                }
                catch (Exception ex)
                {
                    stringBuilder.AppendLine(ex.Message);
                }
            }

            protocolRichTextBox.Text += stringBuilder.ToString();
        }

        private LinearMatrix MatrixFillSkript()
        {
            int variblesAmount = ((int)variablesNumericUpDown2.Value);
            string zString = zTextBox2.Text.Trim().ToLower();
            string[] restrictions = restrictionsRichTextBox2.Text.Trim().Split('\n');

            int[] variables = MathCalculation.VariablesRead(variblesAmount, zString);

            return MathCalculation.MatrixFill2(variables, restrictions);
        }

        private void MaxSolutionScript(LinearMatrix linearMatrix, StringBuilder protocolBuilder)
        {
            protocolBuilder.AppendLine("����������� �������� ������:");

            try
            {
                double[] result = MathCalculation.SupportSolution(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("������� ����'���� ��������:");
                string str = string.Join(", ", result);
                protocolBuilder.AppendLine($"X:({str})\n");
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
            }

            protocolBuilder.AppendLine("����������� ������������ ������:");
            try
            {
                double[] result = MathCalculation.OptimalSolution(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("����������� ����'���� ��������:");
                string str = string.Join(", ", result);
                protocolBuilder.AppendLine($"X:({str})\n");
                xResultTextBox2.Text = str;

                double zRes = linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, linearMatrix.matrix.GetLength(1) - 1];
                zResultTextBox2.Text = $"{zRes}";
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
            }
        }

        private void MinSolutionScript(LinearMatrix linearMatrix, StringBuilder protocolBuilder )
        {
            protocolBuilder.AppendLine("����������� �������� ������:");

            try
            {
                double[] result = MathCalculation.SupportSolution(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("������� ����'���� ��������:");

                string str = string.Join(", ", result);
                protocolBuilder.AppendLine($"X:({str})\n");
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
            }

            protocolBuilder.AppendLine("����������� ������������ ������:");
            try
            {
                double[] result = MathCalculation.OptimalSolution(linearMatrix, protocolBuilder);
                protocolBuilder.AppendLine("����������� ����'���� ��������:");

                string str = string.Join(", ", result);
                protocolBuilder.AppendLine($"X:({str})\n");
                xResultTextBox2.Text = str;

                //min Z = -(max Z')
                double zRes = linearMatrix.matrix[linearMatrix.matrix.GetLength(0) - 1, linearMatrix.matrix.GetLength(1) - 1] * -1;
                zResultTextBox2.Text = $"{zRes}";
            }
            catch (Exception ex)
            {
                protocolBuilder.AppendLine(ex.Message);
            }
        }

    }
}
