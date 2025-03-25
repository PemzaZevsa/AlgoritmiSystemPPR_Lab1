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
            zResultTextBox = new TextBox();
            xResultTextBox = new TextBox();
            zLabel2 = new Label();
            xLabel = new Label();
            calculateOptimalSolutionButton = new Button();
            variablesNumericUpDown = new NumericUpDown();
            variablesLabel = new Label();
            restrictionsRichTextBox = new RichTextBox();
            exampleButton = new Button();
            zTextBox = new TextBox();
            zLabel1 = new Label();
            tabPage3 = new TabPage();
            panel4 = new Panel();
            minRadioButton2 = new RadioButton();
            maxRadioButton2 = new RadioButton();
            label6 = new Label();
            zResultTextBox2 = new TextBox();
            xResultTextBox2 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            calculateOptimalSolutionButton2 = new Button();
            variablesNumericUpDown2 = new NumericUpDown();
            label10 = new Label();
            restrictionsRichTextBox2 = new RichTextBox();
            exampleButton2 = new Button();
            zTextBox2 = new TextBox();
            label11 = new Label();
            freeVariablesTextBox2 = new TextBox();
            label9 = new Label();
            tabPage4 = new TabPage();
            integerVariablesTextBox3 = new TextBox();
            label18 = new Label();
            panel5 = new Panel();
            minRadioButton3 = new RadioButton();
            maxRadioButton3 = new RadioButton();
            label12 = new Label();
            zResultTextBox3 = new TextBox();
            xResultTextBox3 = new TextBox();
            label13 = new Label();
            label14 = new Label();
            calculateOptimalSolutionButton3 = new Button();
            variablesNumericUpDown3 = new NumericUpDown();
            label15 = new Label();
            restrictionsRichTextBox3 = new RichTextBox();
            exampleButton3 = new Button();
            zTextBox3 = new TextBox();
            label16 = new Label();
            freeVariablesTextBox3 = new TextBox();
            label17 = new Label();
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
            tabPage3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)variablesNumericUpDown2).BeginInit();
            tabPage4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)variablesNumericUpDown3).BeginInit();
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
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
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
            tabPage1.Text = "Лаб 1.1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel3);
            tabPage2.Controls.Add(restrictionsLabel);
            tabPage2.Controls.Add(zResultTextBox);
            tabPage2.Controls.Add(xResultTextBox);
            tabPage2.Controls.Add(zLabel2);
            tabPage2.Controls.Add(xLabel);
            tabPage2.Controls.Add(calculateOptimalSolutionButton);
            tabPage2.Controls.Add(variablesNumericUpDown);
            tabPage2.Controls.Add(variablesLabel);
            tabPage2.Controls.Add(restrictionsRichTextBox);
            tabPage2.Controls.Add(exampleButton);
            tabPage2.Controls.Add(zTextBox);
            tabPage2.Controls.Add(zLabel1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(677, 421);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Лаб 1.2";
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
            minRadioButton.Checked = true;
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
            maxRadioButton.Text = "MAX";
            maxRadioButton.UseVisualStyleBackColor = true;
            // 
            // restrictionsLabel
            // 
            restrictionsLabel.AutoSize = true;
            restrictionsLabel.Location = new Point(14, 80);
            restrictionsLabel.Name = "restrictionsLabel";
            restrictionsLabel.Size = new Size(93, 20);
            restrictionsLabel.TabIndex = 13;
            restrictionsLabel.Text = "Обмеження";
            // 
            // zResultTextBox
            // 
            zResultTextBox.Location = new Point(423, 292);
            zResultTextBox.Name = "zResultTextBox";
            zResultTextBox.Size = new Size(230, 27);
            zResultTextBox.TabIndex = 12;
            // 
            // xResultTextBox
            // 
            xResultTextBox.Location = new Point(424, 251);
            xResultTextBox.Name = "xResultTextBox";
            xResultTextBox.Size = new Size(229, 27);
            xResultTextBox.TabIndex = 11;
            // 
            // zLabel2
            // 
            zLabel2.AutoSize = true;
            zLabel2.Location = new Point(386, 295);
            zLabel2.Name = "zLabel2";
            zLabel2.Size = new Size(32, 20);
            zLabel2.TabIndex = 10;
            zLabel2.Text = "Z =";
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
            restrictionsRichTextBox.Location = new Point(14, 103);
            restrictionsRichTextBox.Name = "restrictionsRichTextBox";
            restrictionsRichTextBox.Size = new Size(353, 246);
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
            // zLabel1
            // 
            zLabel1.AutoSize = true;
            zLabel1.Location = new Point(14, 35);
            zLabel1.Name = "zLabel1";
            zLabel1.Size = new Size(32, 20);
            zLabel1.TabIndex = 0;
            zLabel1.Text = "Z =";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel4);
            tabPage3.Controls.Add(label6);
            tabPage3.Controls.Add(zResultTextBox2);
            tabPage3.Controls.Add(xResultTextBox2);
            tabPage3.Controls.Add(label7);
            tabPage3.Controls.Add(label8);
            tabPage3.Controls.Add(calculateOptimalSolutionButton2);
            tabPage3.Controls.Add(variablesNumericUpDown2);
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(restrictionsRichTextBox2);
            tabPage3.Controls.Add(exampleButton2);
            tabPage3.Controls.Add(zTextBox2);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(freeVariablesTextBox2);
            tabPage3.Controls.Add(label9);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(677, 421);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Лаб 1.3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(minRadioButton2);
            panel4.Controls.Add(maxRadioButton2);
            panel4.Location = new Point(386, 16);
            panel4.Name = "panel4";
            panel4.Size = new Size(148, 58);
            panel4.TabIndex = 27;
            // 
            // minRadioButton2
            // 
            minRadioButton2.AutoSize = true;
            minRadioButton2.Checked = true;
            minRadioButton2.Location = new Point(3, 15);
            minRadioButton2.Name = "minRadioButton2";
            minRadioButton2.Size = new Size(58, 24);
            minRadioButton2.TabIndex = 2;
            minRadioButton2.TabStop = true;
            minRadioButton2.Text = "MIN";
            minRadioButton2.UseVisualStyleBackColor = true;
            // 
            // maxRadioButton2
            // 
            maxRadioButton2.AutoSize = true;
            maxRadioButton2.Location = new Point(65, 15);
            maxRadioButton2.Name = "maxRadioButton2";
            maxRadioButton2.Size = new Size(62, 24);
            maxRadioButton2.TabIndex = 3;
            maxRadioButton2.Text = "MAX";
            maxRadioButton2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 80);
            label6.Name = "label6";
            label6.Size = new Size(93, 20);
            label6.TabIndex = 26;
            label6.Text = "Обмеження";
            // 
            // zResultTextBox2
            // 
            zResultTextBox2.Location = new Point(423, 292);
            zResultTextBox2.Name = "zResultTextBox2";
            zResultTextBox2.Size = new Size(230, 27);
            zResultTextBox2.TabIndex = 25;
            // 
            // xResultTextBox2
            // 
            xResultTextBox2.Location = new Point(424, 251);
            xResultTextBox2.Name = "xResultTextBox2";
            xResultTextBox2.Size = new Size(229, 27);
            xResultTextBox2.TabIndex = 24;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(386, 295);
            label7.Name = "label7";
            label7.Size = new Size(32, 20);
            label7.TabIndex = 23;
            label7.Text = "Z =";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(386, 254);
            label8.Name = "label8";
            label8.Size = new Size(32, 20);
            label8.TabIndex = 22;
            label8.Text = "X =";
            // 
            // calculateOptimalSolutionButton2
            // 
            calculateOptimalSolutionButton2.Location = new Point(386, 170);
            calculateOptimalSolutionButton2.Name = "calculateOptimalSolutionButton2";
            calculateOptimalSolutionButton2.Size = new Size(267, 51);
            calculateOptimalSolutionButton2.TabIndex = 21;
            calculateOptimalSolutionButton2.Text = "Знайти оптимальний розв'язок";
            calculateOptimalSolutionButton2.UseVisualStyleBackColor = true;
            calculateOptimalSolutionButton2.Click += calculateOptimalSolutionButton2_Click;
            // 
            // variablesNumericUpDown2
            // 
            variablesNumericUpDown2.Location = new Point(551, 118);
            variablesNumericUpDown2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            variablesNumericUpDown2.Name = "variablesNumericUpDown2";
            variablesNumericUpDown2.Size = new Size(102, 27);
            variablesNumericUpDown2.TabIndex = 20;
            variablesNumericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(386, 120);
            label10.Name = "label10";
            label10.Size = new Size(130, 20);
            label10.TabIndex = 19;
            label10.Text = "Кількість змінних";
            // 
            // restrictionsRichTextBox2
            // 
            restrictionsRichTextBox2.Location = new Point(14, 103);
            restrictionsRichTextBox2.Name = "restrictionsRichTextBox2";
            restrictionsRichTextBox2.Size = new Size(353, 246);
            restrictionsRichTextBox2.TabIndex = 18;
            restrictionsRichTextBox2.Text = "";
            // 
            // exampleButton2
            // 
            exampleButton2.Location = new Point(540, 16);
            exampleButton2.Name = "exampleButton2";
            exampleButton2.Size = new Size(113, 58);
            exampleButton2.TabIndex = 17;
            exampleButton2.Text = "Приклад";
            exampleButton2.UseVisualStyleBackColor = true;
            exampleButton2.Click += exampleButton2_Click;
            // 
            // zTextBox2
            // 
            zTextBox2.Location = new Point(52, 32);
            zTextBox2.Name = "zTextBox2";
            zTextBox2.Size = new Size(315, 27);
            zTextBox2.TabIndex = 16;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(14, 35);
            label11.Name = "label11";
            label11.Size = new Size(32, 20);
            label11.TabIndex = 15;
            label11.Text = "Z =";
            // 
            // freeVariablesTextBox2
            // 
            freeVariablesTextBox2.Location = new Point(119, 366);
            freeVariablesTextBox2.Name = "freeVariablesTextBox2";
            freeVariablesTextBox2.Size = new Size(248, 27);
            freeVariablesTextBox2.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(14, 369);
            label9.Name = "label9";
            label9.Size = new Size(99, 20);
            label9.TabIndex = 8;
            label9.Text = "Вільні змінні";
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(integerVariablesTextBox3);
            tabPage4.Controls.Add(label18);
            tabPage4.Controls.Add(panel5);
            tabPage4.Controls.Add(label12);
            tabPage4.Controls.Add(zResultTextBox3);
            tabPage4.Controls.Add(xResultTextBox3);
            tabPage4.Controls.Add(label13);
            tabPage4.Controls.Add(label14);
            tabPage4.Controls.Add(calculateOptimalSolutionButton3);
            tabPage4.Controls.Add(variablesNumericUpDown3);
            tabPage4.Controls.Add(label15);
            tabPage4.Controls.Add(restrictionsRichTextBox3);
            tabPage4.Controls.Add(exampleButton3);
            tabPage4.Controls.Add(zTextBox3);
            tabPage4.Controls.Add(label16);
            tabPage4.Controls.Add(freeVariablesTextBox3);
            tabPage4.Controls.Add(label17);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(677, 421);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Лаб 1.4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // integerVariablesTextBox3
            // 
            integerVariablesTextBox3.Location = new Point(472, 366);
            integerVariablesTextBox3.Name = "integerVariablesTextBox3";
            integerVariablesTextBox3.Size = new Size(181, 27);
            integerVariablesTextBox3.TabIndex = 44;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(386, 369);
            label18.Name = "label18";
            label18.Size = new Size(80, 20);
            label18.TabIndex = 43;
            label18.Text = "Цілі числа";
            // 
            // panel5
            // 
            panel5.Controls.Add(minRadioButton3);
            panel5.Controls.Add(maxRadioButton3);
            panel5.Location = new Point(386, 16);
            panel5.Name = "panel5";
            panel5.Size = new Size(148, 58);
            panel5.TabIndex = 42;
            // 
            // minRadioButton3
            // 
            minRadioButton3.AutoSize = true;
            minRadioButton3.Checked = true;
            minRadioButton3.Location = new Point(3, 15);
            minRadioButton3.Name = "minRadioButton3";
            minRadioButton3.Size = new Size(58, 24);
            minRadioButton3.TabIndex = 2;
            minRadioButton3.TabStop = true;
            minRadioButton3.Text = "MIN";
            minRadioButton3.UseVisualStyleBackColor = true;
            // 
            // maxRadioButton3
            // 
            maxRadioButton3.AutoSize = true;
            maxRadioButton3.Location = new Point(65, 15);
            maxRadioButton3.Name = "maxRadioButton3";
            maxRadioButton3.Size = new Size(62, 24);
            maxRadioButton3.TabIndex = 3;
            maxRadioButton3.Text = "MAX";
            maxRadioButton3.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(14, 80);
            label12.Name = "label12";
            label12.Size = new Size(93, 20);
            label12.TabIndex = 41;
            label12.Text = "Обмеження";
            // 
            // zResultTextBox3
            // 
            zResultTextBox3.Location = new Point(423, 292);
            zResultTextBox3.Name = "zResultTextBox3";
            zResultTextBox3.Size = new Size(230, 27);
            zResultTextBox3.TabIndex = 40;
            // 
            // xResultTextBox3
            // 
            xResultTextBox3.Location = new Point(424, 251);
            xResultTextBox3.Name = "xResultTextBox3";
            xResultTextBox3.Size = new Size(229, 27);
            xResultTextBox3.TabIndex = 39;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(386, 295);
            label13.Name = "label13";
            label13.Size = new Size(32, 20);
            label13.TabIndex = 38;
            label13.Text = "Z =";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(386, 254);
            label14.Name = "label14";
            label14.Size = new Size(32, 20);
            label14.TabIndex = 37;
            label14.Text = "X =";
            // 
            // calculateOptimalSolutionButton3
            // 
            calculateOptimalSolutionButton3.Location = new Point(386, 170);
            calculateOptimalSolutionButton3.Name = "calculateOptimalSolutionButton3";
            calculateOptimalSolutionButton3.Size = new Size(267, 51);
            calculateOptimalSolutionButton3.TabIndex = 36;
            calculateOptimalSolutionButton3.Text = "Знайти оптимальний розв'язок";
            calculateOptimalSolutionButton3.UseVisualStyleBackColor = true;
            calculateOptimalSolutionButton3.Click += calculateOptimalSolutionButton3_Click;
            // 
            // variablesNumericUpDown3
            // 
            variablesNumericUpDown3.Location = new Point(551, 118);
            variablesNumericUpDown3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            variablesNumericUpDown3.Name = "variablesNumericUpDown3";
            variablesNumericUpDown3.Size = new Size(102, 27);
            variablesNumericUpDown3.TabIndex = 35;
            variablesNumericUpDown3.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(386, 120);
            label15.Name = "label15";
            label15.Size = new Size(130, 20);
            label15.TabIndex = 34;
            label15.Text = "Кількість змінних";
            // 
            // restrictionsRichTextBox3
            // 
            restrictionsRichTextBox3.Location = new Point(14, 103);
            restrictionsRichTextBox3.Name = "restrictionsRichTextBox3";
            restrictionsRichTextBox3.Size = new Size(353, 246);
            restrictionsRichTextBox3.TabIndex = 33;
            restrictionsRichTextBox3.Text = "";
            // 
            // exampleButton3
            // 
            exampleButton3.Location = new Point(540, 16);
            exampleButton3.Name = "exampleButton3";
            exampleButton3.Size = new Size(113, 58);
            exampleButton3.TabIndex = 32;
            exampleButton3.Text = "Приклад";
            exampleButton3.UseVisualStyleBackColor = true;
            exampleButton3.Click += exampleButton3_Click;
            // 
            // zTextBox3
            // 
            zTextBox3.Location = new Point(52, 32);
            zTextBox3.Name = "zTextBox3";
            zTextBox3.Size = new Size(315, 27);
            zTextBox3.TabIndex = 31;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(14, 35);
            label16.Name = "label16";
            label16.Size = new Size(32, 20);
            label16.TabIndex = 30;
            label16.Text = "Z =";
            // 
            // freeVariablesTextBox3
            // 
            freeVariablesTextBox3.Location = new Point(119, 366);
            freeVariablesTextBox3.Name = "freeVariablesTextBox3";
            freeVariablesTextBox3.Size = new Size(248, 27);
            freeVariablesTextBox3.TabIndex = 29;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(14, 369);
            label17.Name = "label17";
            label17.Size = new Size(99, 20);
            label17.TabIndex = 28;
            label17.Text = "Вільні змінні";
            // 
            // clearProtocolButton
            // 
            clearProtocolButton.BackColor = Color.LightCoral;
            clearProtocolButton.Location = new Point(693, 417);
            clearProtocolButton.Name = "clearProtocolButton";
            clearProtocolButton.Size = new Size(137, 36);
            clearProtocolButton.TabIndex = 23;
            clearProtocolButton.Text = "Очистити";
            clearProtocolButton.UseVisualStyleBackColor = false;
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
            Text = "Хвостовець АСППР Лаб1.1, 1.2, 1.3, 1.4";
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
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)variablesNumericUpDown2).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)variablesNumericUpDown3).EndInit();
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
        private Label zLabel1;
        private Label variablesLabel;
        private RichTextBox restrictionsRichTextBox;
        private TextBox zResultTextBox;
        private TextBox xResultTextBox;
        private Label zLabel2;
        private Label xLabel;
        private Button calculateOptimalSolutionButton;
        private NumericUpDown variablesNumericUpDown;
        private Label restrictionsLabel;
        private Panel panel3;
        private TabPage tabPage3;
        private TextBox freeVariablesTextBox2;
        private Label label9;
        private Panel panel4;
        private RadioButton minRadioButton2;
        private RadioButton maxRadioButton2;
        private Label label6;
        private TextBox zResultTextBox2;
        private TextBox xResultTextBox2;
        private Label label7;
        private Label label8;
        private Button calculateOptimalSolutionButton2;
        private NumericUpDown variablesNumericUpDown2;
        private Label label10;
        private RichTextBox restrictionsRichTextBox2;
        private Button exampleButton2;
        private TextBox zTextBox2;
        private Label label11;
        private TabPage tabPage4;
        private Panel panel5;
        private RadioButton minRadioButton3;
        private RadioButton maxRadioButton3;
        private Label label12;
        private TextBox zResultTextBox3;
        private TextBox xResultTextBox3;
        private Label label13;
        private Label label14;
        private Button calculateOptimalSolutionButton3;
        private NumericUpDown variablesNumericUpDown3;
        private Label label15;
        private RichTextBox restrictionsRichTextBox3;
        private Button exampleButton3;
        private TextBox zTextBox3;
        private Label label16;
        private TextBox freeVariablesTextBox3;
        private Label label17;
        private TextBox integerVariablesTextBox3;
        private Label label18;
    }
}
