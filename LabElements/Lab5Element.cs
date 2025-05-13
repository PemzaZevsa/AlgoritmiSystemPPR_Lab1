using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabElements
{
    public partial class Lab5Element : UserControl
    {
        public event Action calculateSolution;
        public event Action example;
        public bool IsSimplex {get; set;}

        public Lab5Element()
        {
            InitializeComponent(); 
            IsSimplex = false;
        }

        private void findSolutionButton_Click(object sender, EventArgs e)
        {
            calculateSolution?.Invoke();
        }

        private void simplexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IsSimplex = !IsSimplex;
        }

        private void exampleButton_Click(object sender, EventArgs e)
        {
            example?.Invoke();
        }
    }
}
