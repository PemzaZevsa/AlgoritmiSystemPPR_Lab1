using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class AssignmentProblem
    {
        private double[,] noChangescostMatrix;//costMatrix without changes
        public double[,] costMatrix; 
        public bool[,] activeMatrix; //matrix for crossing out purpose
        public bool[,] crossElementsMatrix; //elements that were crossed doulbe times
        public bool[,] assignmentMatrix; //assigment workers
        public double ProblemCost //total cost (calculating solution) 
        {
            get
            {
                double cost = 0;
                for (int i = 0; i < costMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < costMatrix.GetLength(1); j++)
                    {
                        if (assignmentMatrix[i,j])
                        {
                            cost += noChangescostMatrix[i, j];
                        }
                    }
                }

                return cost;
            }
        }

        public AssignmentProblem(double[,] costMatrix)
        {
            this.costMatrix = costMatrix;
            this.noChangescostMatrix = new double[costMatrix.GetLength(0), costMatrix.GetLength(1)]; ;

            for (int i = 0; i < costMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < costMatrix.GetLength(1); j++)
                {
                    this.noChangescostMatrix[i, j] = costMatrix[i, j];
                }
            }

            this.activeMatrix = new bool[costMatrix.GetLength(0), costMatrix.GetLength(1)];

            for (int i = 0;i < costMatrix.GetLength(0); i++)
            {
                for(int j = 0;j < costMatrix.GetLength(1); j++)
                {
                    this.activeMatrix[i, j] = true;
                }
            }

            this.crossElementsMatrix = new bool[costMatrix.GetLength(0), costMatrix.GetLength(1)];

            for (int i = 0; i < costMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < costMatrix.GetLength(1); j++)
                {
                    this.crossElementsMatrix[i, j] = false;
                }
            }

            this.assignmentMatrix = new bool[costMatrix.GetLength(0), costMatrix.GetLength(1)];

            for (int i = 0; i < costMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < costMatrix.GetLength(1); j++)
                {
                    this.assignmentMatrix[i, j] = false;
                }
            }
        }

        public void AssignmentProblemReset()
        {
            for (int i = 0; i < this.activeMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.activeMatrix.GetLength(1); j++)
                {
                    this.activeMatrix[i, j] = true;
                }
            }

            for (int i = 0; i < costMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < costMatrix.GetLength(1); j++)
                {
                    this.crossElementsMatrix[i, j] = false;
                }
            }
        }
    }
}
