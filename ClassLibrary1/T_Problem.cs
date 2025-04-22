using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class T_Problem
    {
        public int[] po; //cols headings
        public int[] pn; //rows headings
        public double[,] costMatrix;
        public double[,] solutionMatrix;

        public T_Problem(int[] po, int[] pn, double[,] costMatrix)
        {
            this.po = po;
            this.pn = pn;
            this.costMatrix = costMatrix;

            this.solutionMatrix = new double[costMatrix.GetLength(0), costMatrix.GetLength(1)];
        }

        public void CloseProblem()
        {
            if (IsCloseProblem())
            {
                return;
            }

            int difference = SumPO() - SumPN();

            if (difference < 0)
            {
                //po + 
                int[] newPO = new int[this.po.Length + 1];
                for (int i = 0; i < this.po.Length; i++)
                {
                    newPO[i] = this.po[i];
                }

                newPO[this.po.Length] = Math.Abs(difference);
                this.po = newPO;

                //cost matrix
                double[,] newCostMatrix = new double[this.costMatrix.GetLength(0) + 1, this.costMatrix.GetLength(1)];
                for (int i = 0; i < this.costMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < this.costMatrix.GetLength(1); j++)
                    {
                        newCostMatrix[i,j] = this.costMatrix[i,j];
                    }
                }

                for (int j = 0; j < this.costMatrix.GetLength(1); j++)
                {
                    newCostMatrix[this.costMatrix.GetLength(0), j] = 0;
                }

                this.costMatrix = newCostMatrix;

                //matrix
                this.solutionMatrix = new double[costMatrix.GetLength(0), costMatrix.GetLength(1)];
            }
            else
            {
                //pn +
                int[] newPN = new int[this.pn.Length + 1];
                for (int i = 0; i < this.pn.Length; i++)
                {
                    newPN[i] = this.pn[i];
                }

                newPN[this.pn.Length] = Math.Abs(difference);
                this.pn = newPN;

                //cost matrix
                double[,] newCostMatrix = new double[this.costMatrix.GetLength(0), this.costMatrix.GetLength(1) + 1];
                for (int i = 0; i < this.costMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < this.costMatrix.GetLength(1); j++)
                    {
                        newCostMatrix[i, j] = this.costMatrix[i, j];
                    }
                }

                for (int i = 0; i < this.costMatrix.GetLength(0); i++)
                {
                    newCostMatrix[i, this.costMatrix.GetLength(1)] = 0;
                }

                this.costMatrix = newCostMatrix;

                //matrix
                this.solutionMatrix = new double[costMatrix.GetLength(0), costMatrix.GetLength(1)];
            }
        }

        public bool IsCloseProblem()
        {
            return SumPO() == SumPN();
        }

        public int SumPO()
        {
            int sum = 0;
            for (int i = 0; i < po.Length; i++)
            {
                sum += po[i];
            }

            return sum;
        }

        public int SumPN()
        {
            int sum = 0;
            for (int i = 0; i < pn.Length; i++)
            {
                sum += pn[i];
            }

            return sum;
        }
    }
}
