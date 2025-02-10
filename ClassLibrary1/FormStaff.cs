using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class FormStaff
    {
        public static void PrintProtocol(double[,] insertMatrix, StringBuilder protocolText, int step)
        {
            double solvingElement = insertMatrix[step, step];
            protocolText.AppendLine($"Крок №{step + 1}");
            protocolText.AppendLine($"Розв'язувальний елемент: A[{step},{step}] = {Math.Round(solvingElement, 3)}");

            for (int i = 0; i < insertMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < insertMatrix.GetLength(1); j++)
                {
                    protocolText.Append(Math.Round(insertMatrix[i, j], 3) + " ");
                }
                protocolText.AppendLine();
            }

            protocolText.AppendLine("\n");
        }
    }
}
