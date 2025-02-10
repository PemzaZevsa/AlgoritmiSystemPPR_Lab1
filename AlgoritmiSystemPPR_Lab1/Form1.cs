using ClassLibrary1;
using System.Drawing.Drawing2D;
using System.Text;
using System.Xml.Linq;

namespace AlgoritmiSystemPPR_Lab1
{
    public partial class Form1 : Form
    {
        public double[,] matrix = {
                        { 5, -3, 7},
                        {-1, 4, 3},
                        {6, -2, 5},
                     };

        public double[] bMatrix = {
                        13,
                        13,
                        12,
                     };

        double[,] inverseMatrix = null;

        public Form1()
        {
            InitializeComponent();
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
            //matrix = GenerateMatrix(((int)matrixRows.Value), ((int)matrixCols.Value));

            PrintMatrixOnRichTextBox(matrix, matrixrRichTextBox);
            PrintArrayOnRichTextBox(bMatrix, matrixBRichTextBox);
        }

        private void CalculateinverseMatrixButton_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            inverseMatrix = MathCalculation.InverseMatrix(matrix, stringBuilder);
            PrintMatrixOnRichTextBox(inverseMatrix, inverseMatrixRichTextBox);

            protocolRichTextBox.Clear();
            protocolRichTextBox.Text = stringBuilder.ToString();            
        }

        private void matrixRankButton_Click(object sender, EventArgs e)
        {
            int rank = MathCalculation.MatrixRank(matrix);

            matrixRankTextBox.Clear();
            matrixRankTextBox.Text = $"{rank}";
        }

        private void SLAUCalculateButton_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            inverseMatrix = MathCalculation.InverseMatrix(matrix, stringBuilder);
            PrintMatrixOnRichTextBox(inverseMatrix, inverseMatrixRichTextBox);

            double[] xMatrix = MathCalculation.SLAU(bMatrix, inverseMatrix, stringBuilder);
            PrintArrayOnRichTextBox(xMatrix, matrixXRichTextBox);

            protocolRichTextBox.Clear();
            protocolRichTextBox.Text = stringBuilder.ToString();
        }
    }
}
