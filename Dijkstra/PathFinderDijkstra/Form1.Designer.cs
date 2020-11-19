namespace PathFinderDijkstra
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainGrid = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.runAlgoButton = new System.Windows.Forms.Button();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.loadDataBtn = new System.Windows.Forms.Button();
            this.saveDataBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.startRadioBtn = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.wallRadioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.logsTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.exportLog = new System.Windows.Forms.Button();
            this.clearLog = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numHeightSel = new System.Windows.Forms.NumericUpDown();
            this.numWidthSel = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mazeDimChange = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.clearSolBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeightSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidthSel)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainGrid
            // 
            this.mainGrid.Location = new System.Drawing.Point(13, 17);
            this.mainGrid.Name = "mainGrid";
            this.mainGrid.Size = new System.Drawing.Size(800, 402);
            this.mainGrid.TabIndex = 0;
            this.mainGrid.TabStop = false;
            this.mainGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mainGrid_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Reset grid";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // runAlgoButton
            // 
            this.runAlgoButton.Location = new System.Drawing.Point(12, 53);
            this.runAlgoButton.Name = "runAlgoButton";
            this.runAlgoButton.Size = new System.Drawing.Size(147, 26);
            this.runAlgoButton.TabIndex = 3;
            this.runAlgoButton.Text = "Run Algorithm";
            this.runAlgoButton.UseVisualStyleBackColor = true;
            this.runAlgoButton.Click += new System.EventHandler(this.runAlgoButton_Click);
            // 
            // languageComboBox
            // 
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Items.AddRange(new object[] {
            "Assembly",
            "C++"});
            this.languageComboBox.Location = new System.Drawing.Point(13, 26);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(145, 21);
            this.languageComboBox.TabIndex = 4;
            // 
            // loadDataBtn
            // 
            this.loadDataBtn.Location = new System.Drawing.Point(11, 19);
            this.loadDataBtn.Name = "loadDataBtn";
            this.loadDataBtn.Size = new System.Drawing.Size(71, 26);
            this.loadDataBtn.TabIndex = 5;
            this.loadDataBtn.Text = "Load data";
            this.loadDataBtn.UseVisualStyleBackColor = true;
            this.loadDataBtn.Click += new System.EventHandler(this.loadDataBtn_Click);
            // 
            // saveDataBtn
            // 
            this.saveDataBtn.Location = new System.Drawing.Point(89, 19);
            this.saveDataBtn.Name = "saveDataBtn";
            this.saveDataBtn.Size = new System.Drawing.Size(68, 26);
            this.saveDataBtn.TabIndex = 6;
            this.saveDataBtn.Text = "Save data";
            this.saveDataBtn.UseVisualStyleBackColor = true;
            this.saveDataBtn.Click += new System.EventHandler(this.saveDataBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.startRadioBtn);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.wallRadioBtn);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(823, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 124);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Draw";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(89, 58);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(56, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Target";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // startRadioBtn
            // 
            this.startRadioBtn.AutoSize = true;
            this.startRadioBtn.Location = new System.Drawing.Point(14, 58);
            this.startRadioBtn.Name = "startRadioBtn";
            this.startRadioBtn.Size = new System.Drawing.Size(47, 17);
            this.startRadioBtn.TabIndex = 5;
            this.startRadioBtn.TabStop = true;
            this.startRadioBtn.Text = "Start";
            this.startRadioBtn.UseVisualStyleBackColor = true;
            this.startRadioBtn.CheckedChanged += new System.EventHandler(this.startRadioBtn_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(89, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "Route";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // wallRadioBtn
            // 
            this.wallRadioBtn.AutoSize = true;
            this.wallRadioBtn.Checked = true;
            this.wallRadioBtn.Location = new System.Drawing.Point(14, 26);
            this.wallRadioBtn.Name = "wallRadioBtn";
            this.wallRadioBtn.Size = new System.Drawing.Size(46, 17);
            this.wallRadioBtn.TabIndex = 3;
            this.wallRadioBtn.TabStop = true;
            this.wallRadioBtn.Text = "Wall";
            this.wallRadioBtn.UseVisualStyleBackColor = true;
            this.wallRadioBtn.CheckedChanged += new System.EventHandler(this.wallRadioBtn_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.saveDataBtn);
            this.groupBox2.Controls.Add(this.loadDataBtn);
            this.groupBox2.Location = new System.Drawing.Point(823, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 57);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "External";
            // 
            // logsTextBox
            // 
            this.logsTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.logsTextBox.Location = new System.Drawing.Point(15, 26);
            this.logsTextBox.Name = "logsTextBox";
            this.logsTextBox.Size = new System.Drawing.Size(689, 175);
            this.logsTextBox.TabIndex = 11;
            this.logsTextBox.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.exportLog);
            this.groupBox3.Controls.Add(this.clearLog);
            this.groupBox3.Controls.Add(this.logsTextBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 423);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(801, 219);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logs";
            // 
            // exportLog
            // 
            this.exportLog.Location = new System.Drawing.Point(719, 74);
            this.exportLog.Name = "exportLog";
            this.exportLog.Size = new System.Drawing.Size(64, 37);
            this.exportLog.TabIndex = 14;
            this.exportLog.Text = "Export";
            this.exportLog.UseVisualStyleBackColor = true;
            this.exportLog.Click += new System.EventHandler(this.exportLog_Click);
            // 
            // clearLog
            // 
            this.clearLog.Location = new System.Drawing.Point(719, 26);
            this.clearLog.Name = "clearLog";
            this.clearLog.Size = new System.Drawing.Size(64, 37);
            this.clearLog.TabIndex = 13;
            this.clearLog.Text = "Clear";
            this.clearLog.UseVisualStyleBackColor = true;
            this.clearLog.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numHeightSel);
            this.groupBox4.Controls.Add(this.numWidthSel);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.mazeDimChange);
            this.groupBox4.Location = new System.Drawing.Point(823, 233);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(171, 132);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dimensions";
            // 
            // numHeightSel
            // 
            this.numHeightSel.Location = new System.Drawing.Point(82, 59);
            this.numHeightSel.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numHeightSel.Name = "numHeightSel";
            this.numHeightSel.Size = new System.Drawing.Size(75, 20);
            this.numHeightSel.TabIndex = 10;
            this.numHeightSel.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numWidthSel
            // 
            this.numWidthSel.Location = new System.Drawing.Point(82, 26);
            this.numWidthSel.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numWidthSel.Name = "numWidthSel";
            this.numWidthSel.Size = new System.Drawing.Size(75, 20);
            this.numWidthSel.TabIndex = 9;
            this.numWidthSel.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Heigth";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Width";
            // 
            // mazeDimChange
            // 
            this.mazeDimChange.Location = new System.Drawing.Point(82, 91);
            this.mazeDimChange.Name = "mazeDimChange";
            this.mazeDimChange.Size = new System.Drawing.Size(75, 26);
            this.mazeDimChange.TabIndex = 6;
            this.mazeDimChange.Text = "Apply";
            this.mazeDimChange.UseVisualStyleBackColor = true;
            this.mazeDimChange.Click += new System.EventHandler(this.mazeDimChange_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.clearSolBtn);
            this.groupBox5.Controls.Add(this.languageComboBox);
            this.groupBox5.Controls.Add(this.runAlgoButton);
            this.groupBox5.Location = new System.Drawing.Point(823, 423);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(171, 126);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Compute dijkstra";
            // 
            // clearSolBtn
            // 
            this.clearSolBtn.Location = new System.Drawing.Point(12, 85);
            this.clearSolBtn.Name = "clearSolBtn";
            this.clearSolBtn.Size = new System.Drawing.Size(148, 26);
            this.clearSolBtn.TabIndex = 5;
            this.clearSolBtn.Text = "Clear Solution";
            this.clearSolBtn.UseVisualStyleBackColor = true;
            this.clearSolBtn.Click += new System.EventHandler(this.clearSolBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(890, 592);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Amadeusz Drożdż";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(870, 611);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Informatics, 3.11.2020";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1009, 654);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainGrid);
            this.Name = "Form1";
            this.Text = "Dijkstra Path Finder";
            ((System.ComponentModel.ISupportInitialize)(this.mainGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeightSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidthSel)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button runAlgoButton;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Button loadDataBtn;
        private System.Windows.Forms.Button saveDataBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox logsTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mazeDimChange;
        private System.Windows.Forms.NumericUpDown numHeightSel;
        private System.Windows.Forms.NumericUpDown numWidthSel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button clearSolBtn;
        private System.Windows.Forms.RadioButton wallRadioBtn;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton startRadioBtn;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button exportLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button clearLog;
    }
}

