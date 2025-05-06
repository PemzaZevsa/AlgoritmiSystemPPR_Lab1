using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class T_Problem
    {
        public int[] po; //rows headings, supplies
        public int[] pn; //cols headings, requests
        public double[,] costMatrix;
        public double[,] solutionMatrix;

        //public bool[,] SolutionsUsageMatrix 
        //{
        //    get 
        //    {
        //        bool[,] biasMatrix = new bool[costMatrix.GetLength(0), costMatrix.GetLength(1)];
        //        this.solutionsUsageMatrix = biasMatrix;

        //        return biasMatrix;
        //    }
        //} //filled cells, bias sells

        public bool[,] solutionsUsageMatrix; //filled cells, bias sells
        public double ProblemCost //total cost (calculating solution) 
        {
            get 
            {
                double cost = 0;
                for (int i = 0; i < solutionMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < solutionMatrix.GetLength(1); j++)
                    {
                        cost += solutionMatrix[i, j] * costMatrix[i,j];
                    }
                } 

                return cost;
            }
        }
        public int BasedCells //amount of filled cells
        {
            get
            {
                int count = 0;
                for (int i = 0; i < solutionsUsageMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < solutionsUsageMatrix.GetLength(1); j++)
                    {
                        if (solutionsUsageMatrix[i,j])
                        {
                            count++;
                        }
                    }
                }

                return count;
            }
        }

        public T_Problem(int[] po, int[] pn, double[,] costMatrix)
        {
            this.po = po;
            this.pn = pn;
            this.costMatrix = costMatrix;

            this.solutionMatrix = new double[costMatrix.GetLength(0), costMatrix.GetLength(1)];
            this.solutionsUsageMatrix = new bool[costMatrix.GetLength(0), costMatrix.GetLength(1)];
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

                //matrixes
                this.solutionMatrix = new double[costMatrix.GetLength(0), costMatrix.GetLength(1)];
                this.solutionsUsageMatrix = new bool[costMatrix.GetLength(0), costMatrix.GetLength(1)];
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

                //matrixes
                this.solutionMatrix = new double[costMatrix.GetLength(0), costMatrix.GetLength(1)];
                this.solutionsUsageMatrix = new bool[costMatrix.GetLength(0), costMatrix.GetLength(1)];
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
