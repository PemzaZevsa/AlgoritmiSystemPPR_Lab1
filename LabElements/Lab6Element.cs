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
    public partial class Lab6Element : UserControl
    {
        public event Action findCriticalPath;
        public event Action example1;
        public event Action example2;
        public event Action example3;
        public event Action graphBuilder;
        public Lab6Element()
        {
            InitializeComponent();
        }

        private void findCriticalPathButton_Click(object sender, EventArgs e)
        {
            findCriticalPath?.Invoke();
        }

        private void example1Button_Click(object sender, EventArgs e)
        {
            example1?.Invoke();
        }

        private void example2Button_Click(object sender, EventArgs e)
        {
            example2?.Invoke();
        }

        private void example3Button_Click(object sender, EventArgs e)
        {
            example3?.Invoke();
        }

        private void graphButton_Click(object sender, EventArgs e)
        {
            graphBuilder?.Invoke();
        }

        private void workAmountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            //int newRowCount = (int)workAmountNumericUpDown.Value;

            //while (workItemsDataGridView.Rows.Count > newRowCount)
            //{
            //    workItemsDataGridView.Rows.RemoveAt(workItemsDataGridView.Rows.Count - 1);
            //}

            //while (workItemsDataGridView.Rows.Count < newRowCount)
            //{
            //    workItemsDataGridView.Rows.Add();
            //}
        }
    }
}
