namespace LabElements
{
    partial class Lab6Element
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            workAmountNumericUpDown = new NumericUpDown();
            label2 = new Label();
            criricalPathTextBox = new TextBox();
            durationTextBox = new TextBox();
            label3 = new Label();
            findCriticalPathButton = new Button();
            example1Button = new Button();
            example2Button = new Button();
            example3Button = new Button();
            graphButton = new Button();
            workItemsDataGridView = new DataGridView();
            previousWork = new DataGridViewTextBoxColumn();
            workingTime = new DataGridViewTextBoxColumn();
            manAmount = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)workAmountNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)workItemsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 15);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 0;
            label1.Text = "Кількість робіт:";
            // 
            // workAmountNumericUpDown
            // 
            workAmountNumericUpDown.Location = new Point(131, 13);
            workAmountNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            workAmountNumericUpDown.Name = "workAmountNumericUpDown";
            workAmountNumericUpDown.Size = new Size(114, 27);
            workAmountNumericUpDown.TabIndex = 1;
            workAmountNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            workAmountNumericUpDown.ValueChanged += workAmountNumericUpDown_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(465, 15);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 2;
            label2.Text = "Критичний шлях:";
            // 
            // criricalPathTextBox
            // 
            criricalPathTextBox.Location = new Point(465, 47);
            criricalPathTextBox.Name = "criricalPathTextBox";
            criricalPathTextBox.Size = new Size(203, 27);
            criricalPathTextBox.TabIndex = 3;
            // 
            // durationTextBox
            // 
            durationTextBox.Location = new Point(568, 80);
            durationTextBox.Name = "durationTextBox";
            durationTextBox.Size = new Size(100, 27);
            durationTextBox.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(465, 80);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 5;
            label3.Text = "Тривалість:";
            // 
            // findCriticalPathButton
            // 
            findCriticalPathButton.Location = new Point(465, 113);
            findCriticalPathButton.Name = "findCriticalPathButton";
            findCriticalPathButton.Size = new Size(203, 60);
            findCriticalPathButton.TabIndex = 6;
            findCriticalPathButton.Text = "Знайти критичний шлях та тривалість";
            findCriticalPathButton.UseVisualStyleBackColor = true;
            findCriticalPathButton.Click += findCriticalPathButton_Click;
            // 
            // example1Button
            // 
            example1Button.Location = new Point(465, 179);
            example1Button.Name = "example1Button";
            example1Button.Size = new Size(203, 40);
            example1Button.TabIndex = 7;
            example1Button.Text = "Приклад 1";
            example1Button.UseVisualStyleBackColor = true;
            example1Button.Click += example1Button_Click;
            // 
            // example2Button
            // 
            example2Button.Location = new Point(465, 225);
            example2Button.Name = "example2Button";
            example2Button.Size = new Size(203, 40);
            example2Button.TabIndex = 8;
            example2Button.Text = "Приклад 2";
            example2Button.UseVisualStyleBackColor = true;
            example2Button.Click += example2Button_Click;
            // 
            // example3Button
            // 
            example3Button.Location = new Point(465, 271);
            example3Button.Name = "example3Button";
            example3Button.Size = new Size(203, 40);
            example3Button.TabIndex = 9;
            example3Button.Text = "Варіант №17";
            example3Button.UseVisualStyleBackColor = true;
            example3Button.Click += example3Button_Click;
            // 
            // graphButton
            // 
            graphButton.Location = new Point(465, 317);
            graphButton.Name = "graphButton";
            graphButton.Size = new Size(203, 40);
            graphButton.TabIndex = 11;
            graphButton.Text = "Графіки";
            graphButton.UseVisualStyleBackColor = true;
            graphButton.Click += graphButton_Click;
            // 
            // workItemsDataGridView
            // 
            workItemsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            workItemsDataGridView.Columns.AddRange(new DataGridViewColumn[] { previousWork, workingTime, manAmount });
            workItemsDataGridView.Location = new Point(3, 46);
            workItemsDataGridView.Name = "workItemsDataGridView";
            workItemsDataGridView.RowHeadersWidth = 51;
            workItemsDataGridView.Size = new Size(456, 311);
            workItemsDataGridView.TabIndex = 12;
            // 
            // previousWork
            // 
            previousWork.HeaderText = "Попередня робота";
            previousWork.MinimumWidth = 6;
            previousWork.Name = "previousWork";
            previousWork.Width = 125;
            // 
            // workingTime
            // 
            workingTime.HeaderText = "Тривалість роботи";
            workingTime.MinimumWidth = 6;
            workingTime.Name = "workingTime";
            workingTime.Width = 125;
            // 
            // manAmount
            // 
            manAmount.HeaderText = "Кількість людей";
            manAmount.MinimumWidth = 6;
            manAmount.Name = "manAmount";
            manAmount.Width = 125;
            // 
            // Lab6Element
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(workItemsDataGridView);
            Controls.Add(graphButton);
            Controls.Add(example3Button);
            Controls.Add(example2Button);
            Controls.Add(example1Button);
            Controls.Add(findCriticalPathButton);
            Controls.Add(label3);
            Controls.Add(durationTextBox);
            Controls.Add(criricalPathTextBox);
            Controls.Add(label2);
            Controls.Add(workAmountNumericUpDown);
            Controls.Add(label1);
            Name = "Lab6Element";
            Size = new Size(676, 362);
            ((System.ComponentModel.ISupportInitialize)workAmountNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)workItemsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button findCriticalPathButton;
        private Button example1Button;
        private Button example2Button;
        private Button example3Button;
        private Button graphButton;
        private DataGridViewTextBoxColumn previousWork;
        private DataGridViewTextBoxColumn workingTime;
        private DataGridViewTextBoxColumn manAmount;
        public TextBox criricalPathTextBox;
        public TextBox durationTextBox;
        public DataGridView workItemsDataGridView;
        public NumericUpDown workAmountNumericUpDown;
    }
}
