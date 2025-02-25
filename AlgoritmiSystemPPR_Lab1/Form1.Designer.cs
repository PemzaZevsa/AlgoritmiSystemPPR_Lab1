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
            loadMatrixButton = new Button();
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            panel3 = new Panel();
            minRadioButton = new RadioButton();
            maxRadioButton = new RadioButton();
            restrictionsLabel = new Label();
            yTextBox = new TextBox();
            xTextBox = new TextBox();
            yLabel = new Label();
            xLabel = new Label();
            calculateOptimalSolutionButton = new Button();
            variablesNumericUpDown = new NumericUpDown();
            variablesLabel = new Label();
            restrictionsRichTextBox = new RichTextBox();
            exampleButton = new Button();
            zTextBox = new TextBox();
            zLabel = new Label();
            clearProtocolButton = new Button();
            protocolTextIncreaseButton = new Button();
            protocolTextDecreaseButton = new Button();
            ((System.ComponentModel.ISupportInitialize)matrixCols).BeginInit();
            ((System.ComponentModel.ISupportInitialize)matrixRows).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)variablesNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // matrixLabel
            // 
            matrixLabel.AutoSize = true;
            matrixLabel.Location = new Point(6, 3);
            matrixLabel.Name = "matrixLabel";
            matrixLabel.Size = new Size(85, 20);
            matrixLabel.TabIndex = 1;
            matrixLabel.Text = "Матриця А";
            // 
            // inverseMatrixLabel
            // 
            inverseMatrixLabel.AutoSize = true;
            inverseMatrixLabel.Location = new Point(268, 3);
            inverseMatrixLabel.Name = "inverseMatrixLabel";
            inverseMatrixLabel.Size = new Size(144, 20);
            inverseMatrixLabel.TabIndex = 2;
            inverseMatrixLabel.Text = "Обернена матриця";
            // 
            // GenerateMatrixButton
            // 
            GenerateMatrixButton.Location = new Point(0, 6);
            GenerateMatrixButton.Name = "GenerateMatrixButton";
            GenerateMatrixButton.Size = new Size(119, 60);
            GenerateMatrixButton.TabIndex = 3;
            GenerateMatrixButton.Text = "Згенерувати";
            GenerateMatrixButton.UseVisualStyleBackColor = true;
            GenerateMatrixButton.Click += GenerateMatrixButton_Click;
            // 
            // matrixCols
            // 
            matrixCols.Location = new Point(195, 6);
            matrixCols.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            matrixCols.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            matrixCols.Name = "matrixCols";
            matrixCols.Size = new Size(61, 27);
            matrixCols.TabIndex = 5;
            matrixCols.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // matrixRows
            // 
            matrixRows.Location = new Point(195, 39);
            matrixRows.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            matrixRows.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            matrixRows.Name = "matrixRows";
            matrixRows.Size = new Size(61, 27);
            matrixRows.TabIndex = 6;
            matrixRows.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // calculateinverseMatrixButton
            // 
            calculateinverseMatrixButton.Location = new Point(268, 246);
            calculateinverseMatrixButton.Name = "calculateinverseMatrixButton";
            calculateinverseMatrixButton.Size = new Size(356, 50);
            calculateinverseMatrixButton.TabIndex = 7;
            calculateinverseMatrixButton.Text = "Знайти обернену матрицю";
            calculateinverseMatrixButton.UseVisualStyleBackColor = true;
            calculateinverseMatrixButton.Click += CalculateInverseMatrixButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(GenerateMatrixButton);
            panel1.Controls.Add(matrixCols);
            panel1.Controls.Add(matrixRows);
            panel1.Location = new Point(6, 246);
            panel1.Name = "panel1";
            panel1.Size = new Size(256, 73);
            panel1.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(125, 41);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 8;
            label4.Text = "Рядки";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(125, 8);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 7;
            label3.Text = "Стовпці";
            // 
            // loadMatrixButton
            // 
            loadMatrixButton.Location = new Point(6, 325);
            loadMatrixButton.Name = "loadMatrixButton";
            loadMatrixButton.Size = new Size(256, 41);
            loadMatrixButton.TabIndex = 9;
            loadMatrixButton.Text = "Використати готові матриці";
            loadMatrixButton.UseVisualStyleBackColor = true;
            loadMatrixButton.Click += loadMatrixButton_Click;
            // 
            // matrixrRichTextBox
            // 
            matrixrRichTextBox.Location = new Point(6, 40);
            matrixrRichTextBox.Name = "matrixrRichTextBox";
            matrixrRichTextBox.Size = new Size(200, 200);
            matrixrRichTextBox.TabIndex = 9;
            matrixrRichTextBox.Text = "";
            // 
            // inverseMatrixRichTextBox
            // 
            inverseMatrixRichTextBox.Location = new Point(268, 40);
            inverseMatrixRichTextBox.Name = "inverseMatrixRichTextBox";
            inverseMatrixRichTextBox.Size = new Size(300, 200);
            inverseMatrixRichTextBox.TabIndex = 10;
            inverseMatrixRichTextBox.Text = "";
            // 
            // protocolRichTextBox
            // 
            protocolRichTextBox.Location = new Point(689, 32);
            protocolRichTextBox.Name = "protocolRichTextBox";
            protocolRichTextBox.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            protocolRichTextBox.Size = new Size(400, 372);
            protocolRichTextBox.TabIndex = 11;
            protocolRichTextBox.Text = "";
            // 
            // matrixRankLabel
            // 
            matrixRankLabel.AutoSize = true;
            matrixRankLabel.Location = new Point(3, 7);
            matrixRankLabel.Name = "matrixRankLabel";
            matrixRankLabel.Size = new Size(100, 20);
            matrixRankLabel.TabIndex = 12;
            matrixRankLabel.Text = "Ранг матриці";
            // 
            // matrixRankTextBox
            // 
            matrixRankTextBox.Location = new Point(143, 4);
            matrixRankTextBox.Name = "matrixRankTextBox";
            matrixRankTextBox.Size = new Size(113, 27);
            matrixRankTextBox.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Controls.Add(matrixRankTextBox);
            panel2.Controls.Add(matrixRankLabel);
            panel2.Location = new Point(6, 372);
            panel2.Name = "panel2";
            panel2.Size = new Size(256, 36);
            panel2.TabIndex = 14;
            // 
            // matrixRankButton
            // 
            matrixRankButton.Location = new Point(268, 302);
            matrixRankButton.Name = "matrixRankButton";
            matrixRankButton.Size = new Size(356, 50);
            matrixRankButton.TabIndex = 15;
            matrixRankButton.Text = "Знайти ранг матриці";
            matrixRankButton.UseVisualStyleBackColor = true;
            matrixRankButton.Click += matrixRankButton_Click;
            // 
            // matrixBRichTextBox
            // 
            matrixBRichTextBox.Location = new Point(212, 40);
            matrixBRichTextBox.Name = "matrixBRichTextBox";
            matrixBRichTextBox.Size = new Size(50, 200);
            matrixBRichTextBox.TabIndex = 16;
            matrixBRichTextBox.Text = "";
            // 
            // matrixXRichTextBox
            // 
            matrixXRichTextBox.Location = new Point(574, 40);
            matrixXRichTextBox.Name = "matrixXRichTextBox";
            matrixXRichTextBox.Size = new Size(50, 200);
            matrixXRichTextBox.TabIndex = 17;
            matrixXRichTextBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(178, 3);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 18;
            label1.Text = "Матриця В";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(540, 3);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 19;
            label2.Text = "Матриця Х";
            // 
            // SLAUCalculateButton
            // 
            SLAUCalculateButton.Location = new Point(268, 358);
            SLAUCalculateButton.Name = "SLAUCalculateButton";
            SLAUCalculateButton.Size = new Size(356, 50);
            SLAUCalculateButton.TabIndex = 20;
            SLAUCalculateButton.Text = "Обчислити СЛАУ";
            SLAUCalculateButton.UseVisualStyleBackColor = true;
            SLAUCalculateButton.Click += SLAUCalculateButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(689, 9);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 21;
            label5.Text = "Протокол";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(2, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(685, 454);
            tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(matrixLabel);
            tabPage1.Controls.Add(loadMatrixButton);
            tabPage1.Controls.Add(inverseMatrixLabel);
            tabPage1.Controls.Add(calculateinverseMatrixButton);
            tabPage1.Controls.Add(SLAUCalculateButton);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(matrixrRichTextBox);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(inverseMatrixRichTextBox);
            tabPage1.Controls.Add(matrixXRichTextBox);
            tabPage1.Controls.Add(matrixBRichTextBox);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(matrixRankButton);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(677, 421);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Лаб1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel3);
            tabPage2.Controls.Add(restrictionsLabel);
            tabPage2.Controls.Add(yTextBox);
            tabPage2.Controls.Add(xTextBox);
            tabPage2.Controls.Add(yLabel);
            tabPage2.Controls.Add(xLabel);
            tabPage2.Controls.Add(calculateOptimalSolutionButton);
            tabPage2.Controls.Add(variablesNumericUpDown);
            tabPage2.Controls.Add(variablesLabel);
            tabPage2.Controls.Add(restrictionsRichTextBox);
            tabPage2.Controls.Add(exampleButton);
            tabPage2.Controls.Add(zTextBox);
            tabPage2.Controls.Add(zLabel);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(677, 421);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Лаб2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(minRadioButton);
            panel3.Controls.Add(maxRadioButton);
            panel3.Location = new Point(386, 16);
            panel3.Name = "panel3";
            panel3.Size = new Size(148, 58);
            panel3.TabIndex = 14;
            // 
            // minRadioButton
            // 
            minRadioButton.AutoSize = true;
            minRadioButton.Location = new Point(3, 15);
            minRadioButton.Name = "minRadioButton";
            minRadioButton.Size = new Size(58, 24);
            minRadioButton.TabIndex = 2;
            minRadioButton.TabStop = true;
            minRadioButton.Text = "MIN";
            minRadioButton.UseVisualStyleBackColor = true;
            // 
            // maxRadioButton
            // 
            maxRadioButton.AutoSize = true;
            maxRadioButton.Location = new Point(65, 15);
            maxRadioButton.Name = "maxRadioButton";
            maxRadioButton.Size = new Size(62, 24);
            maxRadioButton.TabIndex = 3;
            maxRadioButton.TabStop = true;
            maxRadioButton.Text = "MAX";
            maxRadioButton.UseVisualStyleBackColor = true;
            // 
            // restrictionsLabel
            // 
            restrictionsLabel.AutoSize = true;
            restrictionsLabel.Location = new Point(52, 80);
            restrictionsLabel.Name = "restrictionsLabel";
            restrictionsLabel.Size = new Size(93, 20);
            restrictionsLabel.TabIndex = 13;
            restrictionsLabel.Text = "Обмеження";
            // 
            // yTextBox
            // 
            yTextBox.Location = new Point(423, 292);
            yTextBox.Name = "yTextBox";
            yTextBox.Size = new Size(230, 27);
            yTextBox.TabIndex = 12;
            // 
            // xTextBox
            // 
            xTextBox.Location = new Point(424, 251);
            xTextBox.Name = "xTextBox";
            xTextBox.Size = new Size(229, 27);
            xTextBox.TabIndex = 11;
            // 
            // yLabel
            // 
            yLabel.AutoSize = true;
            yLabel.Location = new Point(386, 299);
            yLabel.Name = "yLabel";
            yLabel.Size = new Size(31, 20);
            yLabel.TabIndex = 10;
            yLabel.Text = "Y =";
            // 
            // xLabel
            // 
            xLabel.AutoSize = true;
            xLabel.Location = new Point(386, 254);
            xLabel.Name = "xLabel";
            xLabel.Size = new Size(32, 20);
            xLabel.TabIndex = 9;
            xLabel.Text = "X =";
            // 
            // calculateOptimalSolutionButton
            // 
            calculateOptimalSolutionButton.Location = new Point(386, 170);
            calculateOptimalSolutionButton.Name = "calculateOptimalSolutionButton";
            calculateOptimalSolutionButton.Size = new Size(267, 51);
            calculateOptimalSolutionButton.TabIndex = 8;
            calculateOptimalSolutionButton.Text = "Знайти оптимальний розв'язок";
            calculateOptimalSolutionButton.UseVisualStyleBackColor = true;
            calculateOptimalSolutionButton.Click += calculateOptimalSolutionButton_Click;
            // 
            // variablesNumericUpDown
            // 
            variablesNumericUpDown.Location = new Point(551, 118);
            variablesNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            variablesNumericUpDown.Name = "variablesNumericUpDown";
            variablesNumericUpDown.Size = new Size(102, 27);
            variablesNumericUpDown.TabIndex = 7;
            variablesNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // variablesLabel
            // 
            variablesLabel.AutoSize = true;
            variablesLabel.Location = new Point(386, 120);
            variablesLabel.Name = "variablesLabel";
            variablesLabel.Size = new Size(130, 20);
            variablesLabel.TabIndex = 6;
            variablesLabel.Text = "Кількість змінних";
            // 
            // restrictionsRichTextBox
            // 
            restrictionsRichTextBox.Location = new Point(52, 103);
            restrictionsRichTextBox.Name = "restrictionsRichTextBox";
            restrictionsRichTextBox.Size = new Size(315, 246);
            restrictionsRichTextBox.TabIndex = 5;
            restrictionsRichTextBox.Text = "";
            // 
            // exampleButton
            // 
            exampleButton.Location = new Point(540, 16);
            exampleButton.Name = "exampleButton";
            exampleButton.Size = new Size(113, 58);
            exampleButton.TabIndex = 4;
            exampleButton.Text = "Приклад";
            exampleButton.UseVisualStyleBackColor = true;
            exampleButton.Click += exampleButton_Click;
            // 
            // zTextBox
            // 
            zTextBox.Location = new Point(52, 32);
            zTextBox.Name = "zTextBox";
            zTextBox.Size = new Size(315, 27);
            zTextBox.TabIndex = 1;
            // 
            // zLabel
            // 
            zLabel.AutoSize = true;
            zLabel.Location = new Point(14, 35);
            zLabel.Name = "zLabel";
            zLabel.Size = new Size(32, 20);
            zLabel.TabIndex = 0;
            zLabel.Text = "Z =";
            // 
            // clearProtocolButton
            // 
            clearProtocolButton.Location = new Point(693, 417);
            clearProtocolButton.Name = "clearProtocolButton";
            clearProtocolButton.Size = new Size(137, 36);
            clearProtocolButton.TabIndex = 23;
            clearProtocolButton.Text = "Очистити";
            clearProtocolButton.UseVisualStyleBackColor = true;
            clearProtocolButton.Click += clearProtocolButton_Click;
            // 
            // protocolTextIncreaseButton
            // 
            protocolTextIncreaseButton.Location = new Point(836, 417);
            protocolTextIncreaseButton.Name = "protocolTextIncreaseButton";
            protocolTextIncreaseButton.Size = new Size(130, 36);
            protocolTextIncreaseButton.TabIndex = 24;
            protocolTextIncreaseButton.Text = "Збільшити";
            protocolTextIncreaseButton.UseVisualStyleBackColor = true;
            protocolTextIncreaseButton.Click += protocolTextIncreaseButton_Click;
            // 
            // protocolTextDecreaseButton
            // 
            protocolTextDecreaseButton.Location = new Point(972, 417);
            protocolTextDecreaseButton.Name = "protocolTextDecreaseButton";
            protocolTextDecreaseButton.Size = new Size(117, 36);
            protocolTextDecreaseButton.TabIndex = 25;
            protocolTextDecreaseButton.Text = "Зменшити";
            protocolTextDecreaseButton.UseVisualStyleBackColor = true;
            protocolTextDecreaseButton.Click += protocolTextDecreaseButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1105, 469);
            Controls.Add(protocolTextDecreaseButton);
            Controls.Add(protocolTextIncreaseButton);
            Controls.Add(clearProtocolButton);
            Controls.Add(tabControl1);
            Controls.Add(protocolRichTextBox);
            Controls.Add(label5);
            Name = "Form1";
            Text = "Хвостовець АСППР Лаб1,2";
            ((System.ComponentModel.ISupportInitialize)matrixCols).EndInit();
            ((System.ComponentModel.ISupportInitialize)matrixRows).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)variablesNumericUpDown).EndInit();
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
        private Button loadMatrixButton;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button clearProtocolButton;
        private Button protocolTextIncreaseButton;
        private Button protocolTextDecreaseButton;
        private Button exampleButton;
        private RadioButton maxRadioButton;
        private RadioButton minRadioButton;
        private TextBox zTextBox;
        private Label zLabel;
        private Label variablesLabel;
        private RichTextBox restrictionsRichTextBox;
        private TextBox yTextBox;
        private TextBox xTextBox;
        private Label yLabel;
        private Label xLabel;
        private Button calculateOptimalSolutionButton;
        private NumericUpDown variablesNumericUpDown;
        private Label restrictionsLabel;
        private Panel panel3;
    }
}
