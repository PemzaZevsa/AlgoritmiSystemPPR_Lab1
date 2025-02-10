using System.Drawing.Drawing2D;
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

        private void GenerateMatrixButton_Click(object sender, EventArgs e)
        {
            //matrix = GenerateMatrix(((int)matrixRows.Value), ((int)matrixCols.Value));

            PrintMatrixOnRichTextBox(matrix, matrixrRichTextBox);
            PrintArrayOnRichTextBox(bMatrix, matrixBRichTextBox);
        }

        public double[,] GenerateMatrix(int rows, int cols)
        {
            double[,] newMatrix = new double[rows, cols];

            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[i, j] = random.Next(1, 10); // [1-9]
                }
            }

            return newMatrix;
        }

        private void PrintMatrixOnRichTextBox(double[,] incertMatrix, RichTextBox richTextBox)
        {
            richTextBox.Clear();

            for (int i = 0; i < incertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < incertMatrix.GetLength(1); j++)
                {
                    richTextBox.Text += Math.Round(incertMatrix[i, j],3);
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

        private void CalculateinverseMatrixButton_Click(object sender, EventArgs e)
        {
            inverseMatrix = InverseMatrix(matrix);
            PrintMatrixOnRichTextBox(inverseMatrix, inverseMatrixRichTextBox);
        }

        private double[,] InverseMatrix(double[,] insertMatrix)
        {
            double[,] inverceMatrix = CopyArray(insertMatrix);

            //calculate
            protocolRichTextBox.Clear();
            for (int i = 0; i < 3; i++)
            {
                inverceMatrix = DifficultMathStaff(inverceMatrix, i);
                PrintProtocol(inverceMatrix, i);
            }

            return inverceMatrix;
        }

        private void PrintProtocol(double[,] insertMatrix, int step)
        {
            double solvingElement = insertMatrix[step, step];
            protocolRichTextBox.Text += $"Step ¹{step+1}\n";
            protocolRichTextBox.Text += $"Solving element: A[{step},{step}] = {Math.Round(solvingElement,3)}\n";

            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    protocolRichTextBox.Text += Math.Round(insertMatrix[i, j], 3);
                    protocolRichTextBox.Text += " ";
                }

                protocolRichTextBox.Text += "\n";
            }

            protocolRichTextBox.Text += "\n\n";
        }

        private double[,] DifficultMathStaff(double[,] insertMatrix, int k)
        {
            double[,] tempMatrix = CopyArray(insertMatrix);

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

        private void matrixRankButton_Click(object sender, EventArgs e)
        {
            int rank = MatrixRank(matrix);

            matrixRankTextBox.Clear();
            matrixRankTextBox.Text = $"{rank}";
        }

        public int MatrixRank(double[,] insertMatrix)
        {
            double[,] rankMatrix = CopyArray(insertMatrix);

            //calculate
            int rank = 0;
            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                if (rankMatrix[i, i] == 0)
                {
                    continue;
                }

                rankMatrix = DifficultMathStaff(rankMatrix, i);
                rank++;
            }

            return rank;
        }

        private double[,] CopyArray(double[,] source)
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

        private void SLAUCalculateButton_Click(object sender, EventArgs e)
        {
            inverseMatrix = InverseMatrix(matrix);
            PrintMatrixOnRichTextBox(inverseMatrix, inverseMatrixRichTextBox);

            double[] xMatrix = SLAU(bMatrix, inverseMatrix);
            PrintArrayOnRichTextBox(xMatrix, matrixXRichTextBox);
        }

        private double[] SLAU(double[] incertArray, double[,] incertMatrix)
        {
            double[] xMatrix = new double[incertArray.GetLength(0)];
            for (int i = 0; i < incertArray.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < incertMatrix.GetLength(1); j++)
                {
                    sum += incertMatrix[i, j] * incertArray[j];
                }

                xMatrix[i] = sum;
            }

            return xMatrix;
        }
    }
}
