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
                        13 ,
                        13,
                        12,
                     };

        double[,] inverceMatrix = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void GenerateMatrix_Click(object sender, EventArgs e)
        {
            //matrix = new double[((int)matrixRows.Value), ((int)matrixCols.Value)];
            //double[,] matrix = {
            //            { 1, 2, 3, 4},
            //            { 5, 6, 7, 8},
            //            { 9, 10, 11, 12}
            //         };

            //Random random = new Random();

            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        matrix[i, j] = random.Next(1, 10); // [1-9]
            //    }
            //}

            matrixrRichTextBox.Clear();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixrRichTextBox.Text += matrix[i, j];
                    matrixrRichTextBox.Text += " ";
                }
                matrixrRichTextBox.Text += "\n";
            }
        }

        private void CalculateinverseMatrixButton_Click(object sender, EventArgs e)
        {
            //TODO
            if (matrix == null) { return; }

            inverceMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];

            //copy
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    inverceMatrix[i, j] = matrix[i, j];
                }
            }

            //calculate
            protocolRichTextBox.Clear();
            for (int i = 0; i < 3; i++)
            {
                inverceMatrix = DifficultMathStaff(inverceMatrix, i);
                PrintProtocol(inverceMatrix,i);
            }

            //print
            inverseMatrixRichTextBox.Clear();

            for (int i = 0; i < inverceMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < inverceMatrix.GetLength(1); j++)
                {
                    inverseMatrixRichTextBox.Text += Math.Round(inverceMatrix[i, j], 3);
                    inverseMatrixRichTextBox.Text += " ";
                }
                inverseMatrixRichTextBox.Text += "\n";
            }
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
            double[,] tempMatrix = new double[insertMatrix.GetLength(0), insertMatrix.GetLength(1)];

            //copy
            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    tempMatrix[i, j] = insertMatrix[i, j];
                }
            }

            double ars = tempMatrix[k, k];
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
            double[,] rankMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];

            //copy
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    rankMatrix[i, j] = matrix[i, j];
                }
            }
            int r = 0;
            //calculate
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (rankMatrix[i, i] == 0)
                {
                    continue;
                }

                rankMatrix = DifficultMathStaff(rankMatrix, i);
                r++;
            }

            matrixRankTextBox.Clear();
            matrixRankTextBox.Text = $"{r}";
        }

        private void SLAUCalculateButton_Click(object sender, EventArgs e)
        {
            //if (matrix == null) { return; }

            //inverceMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];

            ////copy
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        inverceMatrix[i, j] = matrix[i, j];
            //    }
            //}

            ////calculate
            //for (int i = 0; i < 3; i++)
            //{
            //    inverceMatrix = DifficultMathStaff(inverceMatrix, i);
            //}

            CalculateinverseMatrixButton_Click(sender, e);

            double[] xMatrix = new double[bMatrix.GetLength(0)];
            for (int i = 0; i < bMatrix.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < inverceMatrix.GetLength(1); j++)
                {
                    sum += inverceMatrix[i, j] * bMatrix[j];
                }

                xMatrix[i] = sum;
            }




            matrixXRichTextBox.Clear();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrixXRichTextBox.Text += Math.Round(xMatrix[i], 3);
                matrixXRichTextBox.Text += "\n";
            }
        }

        //private void CalculateinverseMatrixButton_Click(object sender, EventArgs e)
        //{
        //    //TODO
        //    if (matrix == null) { return; }

        //    double[,] inverceMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];

        //    //rewrite
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            inverceMatrix[i, j] = matrix[i, j];
        //        }
        //    }

        //    double[,] tempMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
        //    double ars = 0;

        //    //calculate
        //    for (int k = 0; k < 3; k++)
        //    {

        //        //rewrite
        //        for (int i = 0; i < inverceMatrix.GetLength(0); i++)
        //        {
        //            for (int j = 0; j < inverceMatrix.GetLength(1); j++)
        //            {
        //                tempMatrix[i, j] = inverceMatrix[i, j];
        //            }
        //        }

        //        inverceMatrix = ZvichainiZhordanoviVikluchennya(tempMatrix, k);


        //        //ars = tempMatrix[k, k];
        //        //inverceMatrix[k, k] = 1;

        //        ////main row
        //        //for (int i = 0; i < inverceMatrix.GetLength(1); i++)
        //        //{
        //        //    if (k != i)
        //        //    {
        //        //        inverceMatrix[k, i] = -tempMatrix[k, i];
        //        //    }
        //        //}

        //        ////other rows
        //        //for (int i = 0; i < inverceMatrix.GetLength(0); i++)
        //        //{
        //        //    if (i == k) continue;

        //        //    for (int j = 0; j < inverceMatrix.GetLength(1); j++)
        //        //    {
        //        //        if (j == k) continue;
        //        //        inverceMatrix[i, j] = tempMatrix[i, j] * tempMatrix[k, k] - tempMatrix[k, j] * tempMatrix[i, k];
        //        //    }
        //        //}

        //        ////division
        //        //for (int i = 0; i < inverceMatrix.GetLength(0); i++)
        //        //{
        //        //    for (int j = 0; j < inverceMatrix.GetLength(1); j++)
        //        //    {
        //        //        inverceMatrix[i, j] /= ars;
        //        //    }
        //        //}
        //    }

        //    //print
        //    inverseMatrixRichTextBox.Clear();

        //    for (int i = 0; i < inverceMatrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < inverceMatrix.GetLength(1); j++)
        //        {
        //            inverseMatrixRichTextBox.Text += Math.Round(inverceMatrix[i, j], 3);
        //            inverseMatrixRichTextBox.Text += " ";
        //        }
        //        inverseMatrixRichTextBox.Text += "\n";
        //    }
        //}
    }
}
