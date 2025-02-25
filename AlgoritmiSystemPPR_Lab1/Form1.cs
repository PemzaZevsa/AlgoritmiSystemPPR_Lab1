using ClassLibrary1;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AlgoritmiSystemPPR_Lab1
{
    public partial class Form1 : Form
    {
        private double[,] matrix;

        private double[] bMatrix;

        private double[,] inverseMatrix;

        public Form1()
        {
            InitializeComponent();
            matrix = null;
            bMatrix = null;
            inverseMatrix = null;
        }

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
            richTextBox.Clear();

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
            richTextBox.Clear();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                richTextBox.Text += Math.Round(incertMatrix[i], 3);
                richTextBox.Text += "\n";
            }
        }

        private void GenerateMatrixButton_Click(object sender, EventArgs e)
        {
            matrix = MathCalculation.GenerateMatrix(((int)matrixRows.Value), ((int)matrixCols.Value), 1, 5);
            bMatrix = MathCalculation.GenerateArray(((int)matrixRows.Value), 1, 5);

            PrintMatrixOnRichTextBox(matrix, matrixrRichTextBox);
            PrintArrayOnRichTextBox(bMatrix, matrixBRichTextBox);
        }

        private void CalculateInverseMatrixButton_Click(object sender, EventArgs e)
        {
            matrix = ReadMatrixFromRichTextBox(matrixrRichTextBox);

            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                inverseMatrix = MathCalculation.InverseMatrix(matrix, stringBuilder);
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
            matrix = ReadMatrixFromRichTextBox(matrixrRichTextBox);

            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                int rank = MathCalculation.MatrixRank(matrix, stringBuilder);
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
            matrix = ReadMatrixFromRichTextBox(matrixrRichTextBox);
            bMatrix = ReadMatrixBFromRichTextBox(matrixBRichTextBox);

            //preparations
            StringBuilder stringBuilder = new StringBuilder();
            inverseMatrix = MathCalculation.InverseMatrix(matrix, stringBuilder);
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

            matrix = MathCalculation.CopyMatrix(tempMatrix);
            bMatrix = MathCalculation.CopyArray(tempBMatrix);

            PrintMatrixOnRichTextBox(matrix, matrixrRichTextBox);
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

        private void calculateOptimalSolutionButton_Click(object sender, EventArgs e)
        {
            int varAmount = ((int)variablesNumericUpDown.Value);
            int[] variables = new int[varAmount];
            string zString = zTextBox.Text.Trim().ToLower();
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
                    coeff += zString.Substring(0,1);
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
                    variables[int.Parse(xIndex)-1] = tempVariable;
                }
                catch (Exception ex)
                {
                    //stringBuilder.AppendLine(ex.Message);
                    //stringBuilder.AppendLine($"υ{xIndex} νε ³ρνσΊ");
                }
            }

            for (int i = 0; i < varAmount; i++)
            {
                protocolRichTextBox.Text += $"x{i+1}: {variables[i]}\t";
            }
        }

        private void exampleButton_Click(object sender, EventArgs e)
        {
            StringBuilder limitations = new();
            limitations.AppendLine("x1+x2-x3-2x4=6");
            limitations.AppendLine("x1+x2+x3-x4<=5");
            limitations.AppendLine("2x1-x2+3x3-4x4<=10");
            restrictionsRichTextBox.Text = limitations.ToString();

            minRadioButton.Checked = true;
            variablesNumericUpDown.Value = 4;
            zTextBox.Text = "x1-x3+x4";
        }
    }
}
