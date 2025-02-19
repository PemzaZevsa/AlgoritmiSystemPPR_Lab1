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
            inverseMatrix = MathCalculation.InverseMatrix(matrix, stringBuilder);
            FancyPrintMatrixOnRichTextBox(inverseMatrix, inverseMatrixRichTextBox);

            protocolRichTextBox.Clear();
            protocolRichTextBox.Text = stringBuilder.ToString();
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
                protocolRichTextBox.Clear();
                protocolRichTextBox.Text = stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                protocolRichTextBox.Clear();
                protocolRichTextBox.Text = stringBuilder.ToString();

                protocolRichTextBox.Text += $"{ex.Message}";
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
            protocolRichTextBox.Clear();
            protocolRichTextBox.Text = stringBuilder.ToString();
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


    }
}
