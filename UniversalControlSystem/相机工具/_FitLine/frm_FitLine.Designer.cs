namespace UniversalControlSystem
{
    partial class frm_FitLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_FitLine));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbntAll = new System.Windows.Forms.RadioButton();
            this.rbntNegative = new System.Windows.Forms.RadioButton();
            this.rbntPostive = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDrawRoi = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cebxFitLine = new System.Windows.Forms.CheckBox();
            this.cebxFitPoint = new System.Windows.Forms.CheckBox();
            this.cebxRule = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.nudScale = new System.Windows.Forms.NumericUpDown();
            this.nudHmeasure = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.cebxMeasure = new System.Windows.Forms.CheckBox();
            this.nudLmeasure = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_sure = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblRuleWidth = new System.Windows.Forms.Label();
            this.lblRuleHigh = new System.Windows.Forms.Label();
            this.lblRulenums = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cebxFixture = new System.Windows.Forms.CheckBox();
            this.cbxFixture = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxToolName = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxImage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudThreshold = new System.Windows.Forms.NumericUpDown();
            this.nudSigma = new System.Windows.Forms.NumericUpDown();
            this.takBarRuleWidth = new System.Windows.Forms.TrackBar();
            this.takBarRuleHigh = new System.Windows.Forms.TrackBar();
            this.takBarRulenums = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbntSelectAll = new System.Windows.Forms.RadioButton();
            this.rbntSelectLast = new System.Windows.Forms.RadioButton();
            this.rbntSelectFirst = new System.Windows.Forms.RadioButton();
            this.lblResult = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHmeasure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLmeasure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.takBarRuleWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.takBarRuleHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.takBarRulenums)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbntAll);
            this.groupBox1.Controls.Add(this.rbntNegative);
            this.groupBox1.Controls.Add(this.rbntPostive);
            this.groupBox1.Location = new System.Drawing.Point(225, 228);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(119, 109);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "极性设定";
            // 
            // rbntAll
            // 
            this.rbntAll.AutoSize = true;
            this.rbntAll.Checked = true;
            this.rbntAll.Location = new System.Drawing.Point(13, 80);
            this.rbntAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbntAll.Name = "rbntAll";
            this.rbntAll.Size = new System.Drawing.Size(58, 19);
            this.rbntAll.TabIndex = 23;
            this.rbntAll.TabStop = true;
            this.rbntAll.Text = "所有";
            this.rbntAll.UseVisualStyleBackColor = true;
            this.rbntAll.CheckedChanged += new System.EventHandler(this.rbntAll_CheckedChanged);
            // 
            // rbntNegative
            // 
            this.rbntNegative.AutoSize = true;
            this.rbntNegative.Location = new System.Drawing.Point(13, 52);
            this.rbntNegative.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbntNegative.Name = "rbntNegative";
            this.rbntNegative.Size = new System.Drawing.Size(73, 19);
            this.rbntNegative.TabIndex = 22;
            this.rbntNegative.Text = "白到黑";
            this.rbntNegative.UseVisualStyleBackColor = true;
            this.rbntNegative.CheckedChanged += new System.EventHandler(this.rbntNegative_CheckedChanged);
            // 
            // rbntPostive
            // 
            this.rbntPostive.AutoSize = true;
            this.rbntPostive.Location = new System.Drawing.Point(13, 25);
            this.rbntPostive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbntPostive.Name = "rbntPostive";
            this.rbntPostive.Size = new System.Drawing.Size(73, 19);
            this.rbntPostive.TabIndex = 21;
            this.rbntPostive.Text = "黑到白";
            this.rbntPostive.UseVisualStyleBackColor = true;
            this.rbntPostive.CheckedChanged += new System.EventHandler(this.rbntPostive_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 255);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "平滑值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 319);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "阈值：";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage2.Controls.Add(this.btnDrawRoi);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(504, 730);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "区域";
            // 
            // btnDrawRoi
            // 
            this.btnDrawRoi.Location = new System.Drawing.Point(299, 96);
            this.btnDrawRoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDrawRoi.Name = "btnDrawRoi";
            this.btnDrawRoi.Size = new System.Drawing.Size(100, 29);
            this.btnDrawRoi.TabIndex = 18;
            this.btnDrawRoi.Text = "画roi";
            this.btnDrawRoi.UseVisualStyleBackColor = true;
            this.btnDrawRoi.Click += new System.EventHandler(this.btnDrawRoi_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage3.Controls.Add(this.cebxFitLine);
            this.tabPage3.Controls.Add(this.cebxFitPoint);
            this.tabPage3.Controls.Add(this.cebxRule);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(504, 730);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "图形";
            // 
            // cebxFitLine
            // 
            this.cebxFitLine.AutoSize = true;
            this.cebxFitLine.Location = new System.Drawing.Point(65, 140);
            this.cebxFitLine.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cebxFitLine.Name = "cebxFitLine";
            this.cebxFitLine.Size = new System.Drawing.Size(104, 19);
            this.cebxFitLine.TabIndex = 40;
            this.cebxFitLine.Text = "拟合线图形";
            this.cebxFitLine.UseVisualStyleBackColor = true;
            this.cebxFitLine.CheckedChanged += new System.EventHandler(this.cebxFitLine_CheckedChanged);
            // 
            // cebxFitPoint
            // 
            this.cebxFitPoint.AutoSize = true;
            this.cebxFitPoint.Location = new System.Drawing.Point(65, 86);
            this.cebxFitPoint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cebxFitPoint.Name = "cebxFitPoint";
            this.cebxFitPoint.Size = new System.Drawing.Size(104, 19);
            this.cebxFitPoint.TabIndex = 39;
            this.cebxFitPoint.Text = "拟合点图形";
            this.cebxFitPoint.UseVisualStyleBackColor = true;
            this.cebxFitPoint.CheckedChanged += new System.EventHandler(this.cebxFitPoint_CheckedChanged);
            // 
            // cebxRule
            // 
            this.cebxRule.AutoSize = true;
            this.cebxRule.Location = new System.Drawing.Point(65, 35);
            this.cebxRule.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cebxRule.Name = "cebxRule";
            this.cebxRule.Size = new System.Drawing.Size(89, 19);
            this.cebxRule.TabIndex = 38;
            this.cebxRule.Text = "卡尺图形";
            this.cebxRule.UseVisualStyleBackColor = true;
            this.cebxRule.CheckedChanged += new System.EventHandler(this.cebxRule_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.nudScale);
            this.tabPage4.Controls.Add(this.nudHmeasure);
            this.tabPage4.Controls.Add(this.label27);
            this.tabPage4.Controls.Add(this.label28);
            this.tabPage4.Controls.Add(this.label29);
            this.tabPage4.Controls.Add(this.cebxMeasure);
            this.tabPage4.Controls.Add(this.nudLmeasure);
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(504, 730);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "结果";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 626);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 70;
            this.label6.Text = "比例：";
            // 
            // nudScale
            // 
            this.nudScale.DecimalPlaces = 3;
            this.nudScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudScale.Location = new System.Drawing.Point(123, 615);
            this.nudScale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudScale.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudScale.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.nudScale.Name = "nudScale";
            this.nudScale.Size = new System.Drawing.Size(101, 25);
            this.nudScale.TabIndex = 69;
            this.nudScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudHmeasure
            // 
            this.nudHmeasure.DecimalPlaces = 2;
            this.nudHmeasure.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudHmeasure.Location = new System.Drawing.Point(248, 684);
            this.nudHmeasure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudHmeasure.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudHmeasure.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHmeasure.Name = "nudHmeasure";
            this.nudHmeasure.Size = new System.Drawing.Size(101, 25);
            this.nudHmeasure.TabIndex = 67;
            this.nudHmeasure.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudHmeasure.ValueChanged += new System.EventHandler(this.nudHmeasure_ValueChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(245, 665);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 15);
            this.label27.TabIndex = 66;
            this.label27.Text = "上限：";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(123, 665);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(52, 15);
            this.label28.TabIndex = 65;
            this.label28.Text = "下限：";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(60, 691);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(52, 15);
            this.label29.TabIndex = 64;
            this.label29.Text = "半径：";
            // 
            // cebxMeasure
            // 
            this.cebxMeasure.AutoSize = true;
            this.cebxMeasure.Location = new System.Drawing.Point(357, 690);
            this.cebxMeasure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cebxMeasure.Name = "cebxMeasure";
            this.cebxMeasure.Size = new System.Drawing.Size(59, 19);
            this.cebxMeasure.TabIndex = 63;
            this.cebxMeasure.Text = "使用";
            this.cebxMeasure.UseVisualStyleBackColor = true;
            this.cebxMeasure.CheckedChanged += new System.EventHandler(this.cebxMeasure_CheckedChanged);
            // 
            // nudLmeasure
            // 
            this.nudLmeasure.DecimalPlaces = 1;
            this.nudLmeasure.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudLmeasure.Location = new System.Drawing.Point(123, 684);
            this.nudLmeasure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudLmeasure.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudLmeasure.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLmeasure.Name = "nudLmeasure";
            this.nudLmeasure.Size = new System.Drawing.Size(101, 25);
            this.nudLmeasure.TabIndex = 62;
            this.nudLmeasure.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 4);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(493, 588);
            this.dataGridView1.TabIndex = 1;
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTimer.Location = new System.Drawing.Point(120, 795);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(65, 18);
            this.lblTimer.TabIndex = 22;
            this.lblTimer.Text = "耗时：";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(419, 779);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 36);
            this.btn_cancel.TabIndex = 21;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_sure
            // 
            this.btn_sure.Location = new System.Drawing.Point(311, 779);
            this.btn_sure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_sure.Name = "btn_sure";
            this.btn_sure.Size = new System.Drawing.Size(100, 36);
            this.btn_sure.TabIndex = 20;
            this.btn_sure.Text = "确定";
            this.btn_sure.UseVisualStyleBackColor = true;
            this.btn_sure.Click += new System.EventHandler(this.btn_sure_Click);
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(12, 779);
            this.btn_run.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(100, 36);
            this.btn_run.TabIndex = 19;
            this.btn_run.Text = "运行";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(7, 12);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(512, 759);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage1.Controls.Add(this.lblRuleWidth);
            this.tabPage1.Controls.Add(this.lblRuleHigh);
            this.tabPage1.Controls.Add(this.lblRulenums);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.tbxToolName);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.nudThreshold);
            this.tabPage1.Controls.Add(this.nudSigma);
            this.tabPage1.Controls.Add(this.takBarRuleWidth);
            this.tabPage1.Controls.Add(this.takBarRuleHigh);
            this.tabPage1.Controls.Add(this.takBarRulenums);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(504, 730);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设置";
            // 
            // lblRuleWidth
            // 
            this.lblRuleWidth.AutoSize = true;
            this.lblRuleWidth.Location = new System.Drawing.Point(448, 556);
            this.lblRuleWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRuleWidth.Name = "lblRuleWidth";
            this.lblRuleWidth.Size = new System.Drawing.Size(15, 15);
            this.lblRuleWidth.TabIndex = 66;
            this.lblRuleWidth.Text = "0";
            // 
            // lblRuleHigh
            // 
            this.lblRuleHigh.AutoSize = true;
            this.lblRuleHigh.Location = new System.Drawing.Point(448, 479);
            this.lblRuleHigh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRuleHigh.Name = "lblRuleHigh";
            this.lblRuleHigh.Size = new System.Drawing.Size(15, 15);
            this.lblRuleHigh.TabIndex = 65;
            this.lblRuleHigh.Text = "0";
            // 
            // lblRulenums
            // 
            this.lblRulenums.AutoSize = true;
            this.lblRulenums.Location = new System.Drawing.Point(448, 400);
            this.lblRulenums.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRulenums.Name = "lblRulenums";
            this.lblRulenums.Size = new System.Drawing.Size(15, 15);
            this.lblRulenums.TabIndex = 64;
            this.lblRulenums.Text = "0";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.cebxFixture);
            this.groupBox4.Controls.Add(this.cbxFixture);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(4, 132);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(493, 72);
            this.groupBox4.TabIndex = 60;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "位置定位设置";
            // 
            // cebxFixture
            // 
            this.cebxFixture.AutoSize = true;
            this.cebxFixture.Location = new System.Drawing.Point(403, 28);
            this.cebxFixture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cebxFixture.Name = "cebxFixture";
            this.cebxFixture.Size = new System.Drawing.Size(59, 19);
            this.cebxFixture.TabIndex = 51;
            this.cebxFixture.Text = "使用";
            this.cebxFixture.UseVisualStyleBackColor = true;
            this.cebxFixture.CheckedChanged += new System.EventHandler(this.cebxFixture_CheckedChanged);
            // 
            // cbxFixture
            // 
            this.cbxFixture.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxFixture.FormattingEnabled = true;
            this.cbxFixture.Location = new System.Drawing.Point(129, 20);
            this.cbxFixture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxFixture.Name = "cbxFixture";
            this.cbxFixture.Size = new System.Drawing.Size(264, 25);
            this.cbxFixture.TabIndex = 0;
            this.cbxFixture.SelectedIndexChanged += new System.EventHandler(this.cbxFixture_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "输入定位位置：";
            // 
            // tbxToolName
            // 
            this.tbxToolName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxToolName.Location = new System.Drawing.Point(135, 20);
            this.tbxToolName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxToolName.Name = "tbxToolName";
            this.tbxToolName.Size = new System.Drawing.Size(304, 30);
            this.tbxToolName.TabIndex = 59;
            this.tbxToolName.TextChanged += new System.EventHandler(this.tbxToolName_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.cbxImage);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(5, 60);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(493, 65);
            this.groupBox3.TabIndex = 57;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "图像设置";
            // 
            // cbxImage
            // 
            this.cbxImage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxImage.FormattingEnabled = true;
            this.cbxImage.Location = new System.Drawing.Point(129, 20);
            this.cbxImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxImage.Name = "cbxImage";
            this.cbxImage.Size = new System.Drawing.Size(304, 25);
            this.cbxImage.TabIndex = 0;
            this.cbxImage.SelectedIndexChanged += new System.EventHandler(this.cbxImage_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入图像：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 58;
            this.label4.Text = "找线工具名：";
            // 
            // nudThreshold
            // 
            this.nudThreshold.Location = new System.Drawing.Point(101, 308);
            this.nudThreshold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreshold.Name = "nudThreshold";
            this.nudThreshold.Size = new System.Drawing.Size(99, 25);
            this.nudThreshold.TabIndex = 56;
            this.nudThreshold.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudThreshold.ValueChanged += new System.EventHandler(this.nudThreshold_ValueChanged);
            // 
            // nudSigma
            // 
            this.nudSigma.DecimalPlaces = 1;
            this.nudSigma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSigma.Location = new System.Drawing.Point(101, 241);
            this.nudSigma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudSigma.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSigma.Name = "nudSigma";
            this.nudSigma.Size = new System.Drawing.Size(99, 25);
            this.nudSigma.TabIndex = 55;
            this.nudSigma.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSigma.ValueChanged += new System.EventHandler(this.nudSigma_ValueChanged);
            // 
            // takBarRuleWidth
            // 
            this.takBarRuleWidth.BackColor = System.Drawing.Color.DimGray;
            this.takBarRuleWidth.Location = new System.Drawing.Point(99, 530);
            this.takBarRuleWidth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.takBarRuleWidth.Maximum = 100;
            this.takBarRuleWidth.Minimum = 5;
            this.takBarRuleWidth.Name = "takBarRuleWidth";
            this.takBarRuleWidth.Size = new System.Drawing.Size(341, 56);
            this.takBarRuleWidth.TabIndex = 42;
            this.takBarRuleWidth.Value = 20;
            this.takBarRuleWidth.Scroll += new System.EventHandler(this.takBarRuleWidth_Scroll);
            // 
            // takBarRuleHigh
            // 
            this.takBarRuleHigh.BackColor = System.Drawing.Color.DimGray;
            this.takBarRuleHigh.Location = new System.Drawing.Point(99, 452);
            this.takBarRuleHigh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.takBarRuleHigh.Maximum = 200;
            this.takBarRuleHigh.Minimum = 5;
            this.takBarRuleHigh.Name = "takBarRuleHigh";
            this.takBarRuleHigh.Size = new System.Drawing.Size(341, 56);
            this.takBarRuleHigh.TabIndex = 41;
            this.takBarRuleHigh.Value = 50;
            this.takBarRuleHigh.Scroll += new System.EventHandler(this.takBarRuleHigh_Scroll);
            // 
            // takBarRulenums
            // 
            this.takBarRulenums.BackColor = System.Drawing.Color.DimGray;
            this.takBarRulenums.Location = new System.Drawing.Point(99, 374);
            this.takBarRulenums.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.takBarRulenums.Maximum = 200;
            this.takBarRulenums.Minimum = 2;
            this.takBarRulenums.Name = "takBarRulenums";
            this.takBarRulenums.Size = new System.Drawing.Size(341, 56);
            this.takBarRulenums.TabIndex = 40;
            this.takBarRulenums.Value = 20;
            this.takBarRulenums.Scroll += new System.EventHandler(this.takBarRulenums_Scroll);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 571);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 15);
            this.label9.TabIndex = 39;
            this.label9.Text = "卡尺宽度：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 494);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 38;
            this.label8.Text = "卡尺高度：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 415);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 37;
            this.label7.Text = "卡尺数量：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbntSelectAll);
            this.groupBox2.Controls.Add(this.rbntSelectLast);
            this.groupBox2.Controls.Add(this.rbntSelectFirst);
            this.groupBox2.Location = new System.Drawing.Point(373, 228);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(119, 109);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "边设定";
            // 
            // rbntSelectAll
            // 
            this.rbntSelectAll.AutoSize = true;
            this.rbntSelectAll.Checked = true;
            this.rbntSelectAll.Location = new System.Drawing.Point(16, 80);
            this.rbntSelectAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbntSelectAll.Name = "rbntSelectAll";
            this.rbntSelectAll.Size = new System.Drawing.Size(58, 19);
            this.rbntSelectAll.TabIndex = 23;
            this.rbntSelectAll.TabStop = true;
            this.rbntSelectAll.Text = "所有";
            this.rbntSelectAll.UseVisualStyleBackColor = true;
            this.rbntSelectAll.CheckedChanged += new System.EventHandler(this.rbntSelectAll_CheckedChanged);
            // 
            // rbntSelectLast
            // 
            this.rbntSelectLast.AutoSize = true;
            this.rbntSelectLast.Location = new System.Drawing.Point(16, 52);
            this.rbntSelectLast.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbntSelectLast.Name = "rbntSelectLast";
            this.rbntSelectLast.Size = new System.Drawing.Size(81, 19);
            this.rbntSelectLast.TabIndex = 22;
            this.rbntSelectLast.Text = "最后1条";
            this.rbntSelectLast.UseVisualStyleBackColor = true;
            this.rbntSelectLast.CheckedChanged += new System.EventHandler(this.rbntSelectLast_CheckedChanged);
            // 
            // rbntSelectFirst
            // 
            this.rbntSelectFirst.AutoSize = true;
            this.rbntSelectFirst.Location = new System.Drawing.Point(16, 25);
            this.rbntSelectFirst.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbntSelectFirst.Name = "rbntSelectFirst";
            this.rbntSelectFirst.Size = new System.Drawing.Size(66, 19);
            this.rbntSelectFirst.TabIndex = 21;
            this.rbntSelectFirst.Text = "第1条";
            this.rbntSelectFirst.UseVisualStyleBackColor = true;
            this.rbntSelectFirst.CheckedChanged += new System.EventHandler(this.rbntSelectFirst_CheckedChanged);
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Red;
            this.lblResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResult.Location = new System.Drawing.Point(253, 795);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(48, 18);
            this.lblResult.TabIndex = 25;
            this.lblResult.Text = "FAIL";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hWindowControl1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Location = new System.Drawing.Point(522, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 655);
            this.panel1.TabIndex = 101;
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(1, 39);
            this.hWindowControl1.Margin = new System.Windows.Forms.Padding(4);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(629, 472);
            this.hWindowControl1.TabIndex = 10;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(629, 472);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 30);
            this.panel2.TabIndex = 9;
            this.panel2.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(4, 6);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "图像：";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(67, 4);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(323, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLabel1,
            this.toolLabel2,
            this.toolLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 625);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(634, 30);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolLabel1
            // 
            this.toolLabel1.BackColor = System.Drawing.Color.Blue;
            this.toolLabel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolLabel1.ForeColor = System.Drawing.Color.White;
            this.toolLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.toolLabel1.Name = "toolLabel1";
            this.toolLabel1.RightToLeftAutoMirrorImage = true;
            this.toolLabel1.Size = new System.Drawing.Size(457, 25);
            this.toolLabel1.Text = "Size:0000*0000 X:0000.00 Y:0000.00 VAL:000,000,000";
            // 
            // toolLabel2
            // 
            this.toolLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolLabel2.ForeColor = System.Drawing.Color.Red;
            this.toolLabel2.Name = "toolLabel2";
            this.toolLabel2.Size = new System.Drawing.Size(52, 25);
            this.toolLabel2.Text = "FAIL";
            // 
            // toolLabel3
            // 
            this.toolLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolLabel3.ForeColor = System.Drawing.Color.White;
            this.toolLabel3.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolLabel3.Name = "toolLabel3";
            this.toolLabel3.Size = new System.Drawing.Size(74, 25);
            this.toolLabel3.Text = "耗时:0:00";
            // 
            // frm_FitLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1432, 828);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_sure);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_FitLine";
            this.Text = "找线";
            this.Load += new System.EventHandler(this.frm_FitLine_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHmeasure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLmeasure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.takBarRuleWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.takBarRuleHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.takBarRulenums)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbntAll;
        private System.Windows.Forms.RadioButton rbntNegative;
        private System.Windows.Forms.RadioButton rbntPostive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnDrawRoi;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox cebxFitLine;
        private System.Windows.Forms.CheckBox cebxFitPoint;
        private System.Windows.Forms.CheckBox cebxRule;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.NumericUpDown nudHmeasure;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox cebxMeasure;
        private System.Windows.Forms.NumericUpDown nudLmeasure;
        private System.Windows.Forms.DataGridView dataGridView1;
 
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_sure;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbxFixture;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxToolName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbxImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudThreshold;
        private System.Windows.Forms.NumericUpDown nudSigma;
        private System.Windows.Forms.TrackBar takBarRuleWidth;
        private System.Windows.Forms.TrackBar takBarRuleHigh;
        private System.Windows.Forms.TrackBar takBarRulenums;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbntSelectAll;
        private System.Windows.Forms.RadioButton rbntSelectLast;
        private System.Windows.Forms.RadioButton rbntSelectFirst;
        private System.Windows.Forms.CheckBox cebxFixture;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.NumericUpDown nudScale;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblRuleWidth;
        private System.Windows.Forms.Label lblRuleHigh;
        private System.Windows.Forms.Label lblRulenums;
        private System.Windows.Forms.Panel panel1;
        public HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolLabel3;
    }
}