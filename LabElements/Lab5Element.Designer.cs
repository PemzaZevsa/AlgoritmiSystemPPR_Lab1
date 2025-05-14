namespace LabElements
{
    partial class Lab5Element
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
            label51 = new Label();
            costTextBox = new TextBox();
            label48 = new Label();
            costMatrixRichTextBox = new RichTextBox();
            label1 = new Label();
            assignmentMatrixRichTextBox = new RichTextBox();
            findSolutionButton = new Button();
            simplexCheckBox = new CheckBox();
            exampleButton = new Button();
            SuspendLayout();
            // 
            // label51
            // 
            label51.AutoSize = true;
            label51.Location = new Point(297, 225);
            label51.Name = "label51";
            label51.Size = new Size(69, 20);
            label51.TabIndex = 147;
            label51.Text = "Вартість:";
            // 
            // costTextBox
            // 
            costTextBox.Location = new Point(372, 222);
            costTextBox.Name = "costTextBox";
            costTextBox.Size = new Size(174, 27);
            costTextBox.TabIndex = 146;
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Location = new Point(3, 0);
            label48.Name = "label48";
            label48.Size = new Size(148, 20);
            label48.TabIndex = 145;
            label48.Text = "Матриця вартостей:";
            // 
            // costMatrixRichTextBox
            // 
            costMatrixRichTextBox.Location = new Point(3, 23);
            costMatrixRichTextBox.Name = "costMatrixRichTextBox";
            costMatrixRichTextBox.Size = new Size(288, 185);
            costMatrixRichTextBox.TabIndex = 144;
            costMatrixRichTextBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(258, 0);
            label1.Name = "label1";
            label1.Size = new Size(162, 20);
            label1.TabIndex = 149;
            label1.Text = "Матриця призначень:";
            // 
            // assignmentMatrixRichTextBox
            // 
            assignmentMatrixRichTextBox.Location = new Point(297, 23);
            assignmentMatrixRichTextBox.Name = "assignmentMatrixRichTextBox";
            assignmentMatrixRichTextBox.Size = new Size(288, 185);
            assignmentMatrixRichTextBox.TabIndex = 148;
            assignmentMatrixRichTextBox.Text = "";
            // 
            // findSolutionButton
            // 
            findSolutionButton.Location = new Point(3, 214);
            findSolutionButton.Name = "findSolutionButton";
            findSolutionButton.Size = new Size(288, 43);
            findSolutionButton.TabIndex = 151;
            findSolutionButton.Text = "Знайти матрицю призначень";
            findSolutionButton.UseVisualStyleBackColor = true;
            findSolutionButton.Click += findSolutionButton_Click;
            // 
            // simplexCheckBox
            // 
            simplexCheckBox.AutoSize = true;
            simplexCheckBox.Location = new Point(3, 312);
            simplexCheckBox.Name = "simplexCheckBox";
            simplexCheckBox.Size = new Size(267, 24);
            simplexCheckBox.TabIndex = 152;
            simplexCheckBox.Text = "Використовувати симплекс метод";
            simplexCheckBox.UseVisualStyleBackColor = true;
            simplexCheckBox.CheckedChanged += simplexCheckBox_CheckedChanged;
            // 
            // exampleButton
            // 
            exampleButton.Location = new Point(3, 263);
            exampleButton.Name = "exampleButton";
            exampleButton.Size = new Size(288, 43);
            exampleButton.TabIndex = 153;
            exampleButton.Text = "Приклад";
            exampleButton.UseVisualStyleBackColor = true;
            exampleButton.Click += exampleButton_Click;
            // 
            // Lab5Element
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(exampleButton);
            Controls.Add(simplexCheckBox);
            Controls.Add(findSolutionButton);
            Controls.Add(label1);
            Controls.Add(assignmentMatrixRichTextBox);
            Controls.Add(label51);
            Controls.Add(costTextBox);
            Controls.Add(label48);
            Controls.Add(costMatrixRichTextBox);
            Name = "Lab5Element";
            Size = new Size(589, 368);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label51;
        public TextBox costTextBox;
        private Label label48;
        public RichTextBox costMatrixRichTextBox;
        private Label label1;
        public RichTextBox assignmentMatrixRichTextBox;
        private Button findSolutionButton;
        private CheckBox simplexCheckBox;
        private Button exampleButton;
    }
}
