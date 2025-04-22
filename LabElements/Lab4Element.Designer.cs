namespace LabElements
{
    partial class Lab4Element
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
            calculateOptimalPlanButton = new Button();
            simplexCheckBox = new CheckBox();
            label53 = new Label();
            costRichTextBox = new RichTextBox();
            label52 = new Label();
            optimalCostTextBox = new TextBox();
            label51 = new Label();
            supportingCostTextBox = new TextBox();
            label50 = new Label();
            applicationsTextBox = new TextBox();
            label49 = new Label();
            suppliesTextBox = new TextBox();
            label47 = new Label();
            optimalSolutionRichTextBox = new RichTextBox();
            label48 = new Label();
            supportingSolutionRichTextBox = new RichTextBox();
            exampleButton = new Button();
            SuspendLayout();
            // 
            // calculateOptimalPlanButton
            // 
            calculateOptimalPlanButton.Location = new Point(362, 109);
            calculateOptimalPlanButton.Name = "calculateOptimalPlanButton";
            calculateOptimalPlanButton.Size = new Size(306, 43);
            calculateOptimalPlanButton.TabIndex = 149;
            calculateOptimalPlanButton.Text = "Знайти оптимальний план";
            calculateOptimalPlanButton.UseVisualStyleBackColor = true;
            calculateOptimalPlanButton.Click += calculateOptimalPlanButton_Click;
            // 
            // simplexCheckBox
            // 
            simplexCheckBox.AutoSize = true;
            simplexCheckBox.Location = new Point(362, 206);
            simplexCheckBox.Name = "simplexCheckBox";
            simplexCheckBox.Size = new Size(269, 24);
            simplexCheckBox.TabIndex = 148;
            simplexCheckBox.Text = "Використовувати симплекс-метод";
            simplexCheckBox.UseVisualStyleBackColor = true;
            // 
            // label53
            // 
            label53.AutoSize = true;
            label53.Location = new Point(3, 0);
            label53.Name = "label53";
            label53.Size = new Size(136, 20);
            label53.TabIndex = 147;
            label53.Text = "Вартості доставок:";
            // 
            // costRichTextBox
            // 
            costRichTextBox.Location = new Point(3, 23);
            costRichTextBox.Name = "costRichTextBox";
            costRichTextBox.Size = new Size(353, 207);
            costRichTextBox.TabIndex = 146;
            costRichTextBox.Text = "";
            // 
            // label52
            // 
            label52.AutoSize = true;
            label52.Location = new Point(332, 389);
            label52.Name = "label52";
            label52.Size = new Size(69, 20);
            label52.TabIndex = 145;
            label52.Text = "Вартість:";
            // 
            // optimalCostTextBox
            // 
            optimalCostTextBox.Location = new Point(407, 382);
            optimalCostTextBox.Name = "optimalCostTextBox";
            optimalCostTextBox.Size = new Size(250, 27);
            optimalCostTextBox.TabIndex = 144;
            // 
            // label51
            // 
            label51.AutoSize = true;
            label51.Location = new Point(1, 389);
            label51.Name = "label51";
            label51.Size = new Size(69, 20);
            label51.TabIndex = 143;
            label51.Text = "Вартість:";
            // 
            // supportingCostTextBox
            // 
            supportingCostTextBox.Location = new Point(78, 382);
            supportingCostTextBox.Name = "supportingCostTextBox";
            supportingCostTextBox.Size = new Size(250, 27);
            supportingCostTextBox.TabIndex = 142;
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Location = new Point(362, 53);
            label50.Name = "label50";
            label50.Size = new Size(211, 20);
            label50.TabIndex = 141;
            label50.Text = "Заявки пунктів відправлення";
            // 
            // applicationsTextBox
            // 
            applicationsTextBox.Location = new Point(362, 76);
            applicationsTextBox.Name = "applicationsTextBox";
            applicationsTextBox.Size = new Size(306, 27);
            applicationsTextBox.TabIndex = 140;
            // 
            // label49
            // 
            label49.AutoSize = true;
            label49.Location = new Point(362, 0);
            label49.Name = "label49";
            label49.Size = new Size(227, 20);
            label49.TabIndex = 139;
            label49.Text = "Запаси в пунктах відправлення";
            // 
            // suppliesTextBox
            // 
            suppliesTextBox.Location = new Point(362, 23);
            suppliesTextBox.Name = "suppliesTextBox";
            suppliesTextBox.Size = new Size(306, 27);
            suppliesTextBox.TabIndex = 138;
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Location = new Point(332, 233);
            label47.Name = "label47";
            label47.Size = new Size(233, 20);
            label47.TabIndex = 137;
            label47.Text = "Оптимальний план перевезень:";
            // 
            // optimalSolutionRichTextBox
            // 
            optimalSolutionRichTextBox.Location = new Point(332, 256);
            optimalSolutionRichTextBox.Name = "optimalSolutionRichTextBox";
            optimalSolutionRichTextBox.Size = new Size(325, 120);
            optimalSolutionRichTextBox.TabIndex = 136;
            optimalSolutionRichTextBox.Text = "";
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Location = new Point(3, 233);
            label48.Name = "label48";
            label48.Size = new Size(201, 20);
            label48.TabIndex = 135;
            label48.Text = "Опорний план перевезень:";
            // 
            // supportingSolutionRichTextBox
            // 
            supportingSolutionRichTextBox.Location = new Point(3, 256);
            supportingSolutionRichTextBox.Name = "supportingSolutionRichTextBox";
            supportingSolutionRichTextBox.Size = new Size(325, 120);
            supportingSolutionRichTextBox.TabIndex = 134;
            supportingSolutionRichTextBox.Text = "";
            // 
            // exampleButton
            // 
            exampleButton.Location = new Point(362, 157);
            exampleButton.Name = "exampleButton";
            exampleButton.Size = new Size(306, 43);
            exampleButton.TabIndex = 150;
            exampleButton.Text = "Приклад";
            exampleButton.UseVisualStyleBackColor = true;
            exampleButton.Click += exampleButton_Click;
            // 
            // Lab4Element
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(exampleButton);
            Controls.Add(calculateOptimalPlanButton);
            Controls.Add(simplexCheckBox);
            Controls.Add(label53);
            Controls.Add(costRichTextBox);
            Controls.Add(label52);
            Controls.Add(optimalCostTextBox);
            Controls.Add(label51);
            Controls.Add(supportingCostTextBox);
            Controls.Add(label50);
            Controls.Add(applicationsTextBox);
            Controls.Add(label49);
            Controls.Add(suppliesTextBox);
            Controls.Add(label47);
            Controls.Add(optimalSolutionRichTextBox);
            Controls.Add(label48);
            Controls.Add(supportingSolutionRichTextBox);
            Name = "Lab4Element";
            Size = new Size(677, 420);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button calculateOptimalPlanButton;
        private Label label53;
        private Label label52;
        private Label label51;
        private Label label50;
        private Label label49;
        private Label label47;
        private Label label48;
        private Button exampleButton;
        public RichTextBox costRichTextBox;
        public TextBox optimalCostTextBox;
        public TextBox supportingCostTextBox;
        public TextBox applicationsTextBox;
        public TextBox suppliesTextBox;
        public RichTextBox optimalSolutionRichTextBox;
        public RichTextBox supportingSolutionRichTextBox;
        public CheckBox simplexCheckBox;
    }
}
