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
    public partial class Lab4Element : UserControl
    {
        public event Action calculateOptimalPlan;
        public event Action example;

        public Lab4Element()
        {
            InitializeComponent();
        }

        private void calculateOptimalPlanButton_Click(object sender, EventArgs e)
        {
            calculateOptimalPlan?.Invoke();
        }

        private void exampleButton_Click(object sender, EventArgs e)
        {
            example?.Invoke();
        }
    }
}
