namespace AlgoritmiSystemPPR_Lab1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            matrixLabel = new Label();
            inverseMatrixLabel = new Label();
            GenerateMatrixButton = new Button();
            matrixCols = new NumericUpDown();
            matrixRows = new NumericUpDown();
            calculateinverseMatrixButton = new Button();
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            matrixrRichTextBox = new RichTextBox();
            inverseMatrixRichTextBox = new RichTextBox();
            protocolRichTextBox = new RichTextBox();
            matrixRankLabel = new Label();
            matrixRankTextBox = new TextBox();
            panel2 = new Panel();
            matrixRankButton = new Button();
            matrixBRichTextBox = new RichTextBox();
            matrixXRichTextBox = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            SLAUCalculateButton = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)matrixCols).BeginInit();
            ((System.ComponentModel.ISupportInitialize)matrixRows).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // matrixLabel
            // 
            matrixLabel.AutoSize = true;
            matrixLabel.Location = new Point(22, 25);
            matrixLabel.Name = "matrixLabel";
            matrixLabel.Size = new Size(85, 20);
            matrixLabel.TabIndex = 1;
            matrixLabel.Text = "Матриця А";
            // 
            // inverseMatrixLabel
            // 
            inverseMatrixLabel.AutoSize = true;
            inverseMatrixLabel.Location = new Point(358, 25);
            inverseMatrixLabel.Name = "inverseMatrixLabel";
            inverseMatrixLabel.Size = new Size(144, 20);
            inverseMatrixLabel.TabIndex = 2;
            inverseMatrixLabel.Text = "Обернена матриця";
            // 
            // GenerateMatrixButton
            // 
            GenerateMatrixButton.Location = new Point(9, 20);
            GenerateMatrixButton.Name = "GenerateMatrixButton";
            GenerateMatrixButton.Size = new Size(119, 63);
            GenerateMatrixButton.TabIndex = 3;
            GenerateMatrixButton.Text = "Згенерувати";
            GenerateMatrixButton.UseVisualStyleBackColor = true;
            GenerateMatrixButton.Click += GenerateMatrixButton_Click;
            // 
            // matrixCols
            // 
            matrixCols.Location = new Point(206, 20);
            matrixCols.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            matrixCols.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            matrixCols.Name = "matrixCols";
            matrixCols.Size = new Size(61, 27);
            matrixCols.TabIndex = 5;
            matrixCols.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // matrixRows
            // 
            matrixRows.Location = new Point(206, 56);
            matrixRows.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            matrixRows.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            matrixRows.Name = "matrixRows";
            matrixRows.Size = new Size(61, 27);
            matrixRows.TabIndex = 6;
            matrixRows.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // calculateinverseMatrixButton
            // 
            calculateinverseMatrixButton.Location = new Point(358, 268);
            calculateinverseMatrixButton.Name = "calculateinverseMatrixButton";
            calculateinverseMatrixButton.Size = new Size(256, 50);
            calculateinverseMatrixButton.TabIndex = 7;
            calculateinverseMatrixButton.Text = "Знайти обернену матрицю";
            calculateinverseMatrixButton.UseVisualStyleBackColor = true;
            calculateinverseMatrixButton.Click += CalculateinverseMatrixButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(GenerateMatrixButton);
            panel1.Controls.Add(matrixCols);
            panel1.Controls.Add(matrixRows);
            panel1.Location = new Point(22, 268);
            panel1.Name = "panel1";
            panel1.Size = new Size(288, 94);
            panel1.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(138, 63);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 8;
            label4.Text = "Рядки";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(138, 27);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 7;
            label3.Text = "Стовпці";
            // 
            // matrixrRichTextBox
            // 
            matrixrRichTextBox.Location = new Point(22, 62);
            matrixrRichTextBox.Name = "matrixrRichTextBox";
            matrixrRichTextBox.Size = new Size(200, 200);
            matrixrRichTextBox.TabIndex = 9;
            matrixrRichTextBox.Text = "";
            // 
            // inverseMatrixRichTextBox
            // 
            inverseMatrixRichTextBox.Location = new Point(358, 62);
            inverseMatrixRichTextBox.Name = "inverseMatrixRichTextBox";
            inverseMatrixRichTextBox.Size = new Size(200, 200);
            inverseMatrixRichTextBox.TabIndex = 10;
            inverseMatrixRichTextBox.Text = "";
            // 
            // protocolRichTextBox
            // 
            protocolRichTextBox.Location = new Point(657, 62);
            protocolRichTextBox.Name = "protocolRichTextBox";
            protocolRichTextBox.Size = new Size(272, 368);
            protocolRichTextBox.TabIndex = 11;
            protocolRichTextBox.Text = "";
            // 
            // matrixRankLabel
            // 
            matrixRankLabel.AutoSize = true;
            matrixRankLabel.Location = new Point(9, 23);
            matrixRankLabel.Name = "matrixRankLabel";
            matrixRankLabel.Size = new Size(101, 20);
            matrixRankLabel.TabIndex = 12;
            matrixRankLabel.Text = "Ранк матриці";
            // 
            // matrixRankTextBox
            // 
            matrixRankTextBox.Location = new Point(143, 16);
            matrixRankTextBox.Name = "matrixRankTextBox";
            matrixRankTextBox.Size = new Size(124, 27);
            matrixRankTextBox.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Controls.Add(matrixRankTextBox);
            panel2.Controls.Add(matrixRankLabel);
            panel2.Location = new Point(22, 375);
            panel2.Name = "panel2";
            panel2.Size = new Size(290, 55);
            panel2.TabIndex = 14;
            // 
            // matrixRankButton
            // 
            matrixRankButton.Location = new Point(358, 324);
            matrixRankButton.Name = "matrixRankButton";
            matrixRankButton.Size = new Size(256, 50);
            matrixRankButton.TabIndex = 15;
            matrixRankButton.Text = "Знайти ранг матриці";
            matrixRankButton.UseVisualStyleBackColor = true;
            matrixRankButton.Click += matrixRankButton_Click;
            // 
            // matrixBRichTextBox
            // 
            matrixBRichTextBox.Location = new Point(228, 62);
            matrixBRichTextBox.Name = "matrixBRichTextBox";
            matrixBRichTextBox.Size = new Size(50, 200);
            matrixBRichTextBox.TabIndex = 16;
            matrixBRichTextBox.Text = "";
            // 
            // matrixXRichTextBox
            // 
            matrixXRichTextBox.Location = new Point(564, 62);
            matrixXRichTextBox.Name = "matrixXRichTextBox";
            matrixXRichTextBox.Size = new Size(50, 200);
            matrixXRichTextBox.TabIndex = 17;
            matrixXRichTextBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(228, 25);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 18;
            label1.Text = "Матриця В";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(564, 25);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 19;
            label2.Text = "Матриця Х";
            // 
            // SLAUCalculateButton
            // 
            SLAUCalculateButton.Location = new Point(358, 380);
            SLAUCalculateButton.Name = "SLAUCalculateButton";
            SLAUCalculateButton.Size = new Size(256, 50);
            SLAUCalculateButton.TabIndex = 20;
            SLAUCalculateButton.Text = "Обчислити СЛАУ";
            SLAUCalculateButton.UseVisualStyleBackColor = true;
            SLAUCalculateButton.Click += SLAUCalculateButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(657, 25);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 21;
            label5.Text = "Протокол";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 469);
            Controls.Add(label5);
            Controls.Add(SLAUCalculateButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(matrixXRichTextBox);
            Controls.Add(matrixBRichTextBox);
            Controls.Add(matrixRankButton);
            Controls.Add(panel2);
            Controls.Add(protocolRichTextBox);
            Controls.Add(inverseMatrixRichTextBox);
            Controls.Add(matrixrRichTextBox);
            Controls.Add(panel1);
            Controls.Add(calculateinverseMatrixButton);
            Controls.Add(inverseMatrixLabel);
            Controls.Add(matrixLabel);
            Name = "Form1";
            Text = "Хвостовець АЛГОРИТМИ СИСТЕМ ПІДТРИМКИ ПРИЙНЯТТЯ РІШЕНЬ Лаб1";
            ((System.ComponentModel.ISupportInitialize)matrixCols).EndInit();
            ((System.ComponentModel.ISupportInitialize)matrixRows).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label matrixLabel;
        private Label inverseMatrixLabel;
        private Button GenerateMatrixButton;
        private NumericUpDown matrixCols;
        private NumericUpDown matrixRows;
        private Button calculateinverseMatrixButton;
        private Panel panel1;
        private Label label4;
        private Label label3;
        private RichTextBox matrixrRichTextBox;
        private RichTextBox inverseMatrixRichTextBox;
        private RichTextBox protocolRichTextBox;
        private Label matrixRankLabel;
        private TextBox matrixRankTextBox;
        private Panel panel2;
        private Button matrixRankButton;
        private RichTextBox matrixBRichTextBox;
        private RichTextBox matrixXRichTextBox;
        private Label label1;
        private Label label2;
        private Button SLAUCalculateButton;
        private Label label5;
    }
}
