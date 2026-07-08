namespace UniversalControlSystem
{
    partial class frm_SurfaceStains
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxFeature = new System.Windows.Forms.ComboBox();
            this.nudSigma1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudSigma2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMaxStains = new System.Windows.Forms.NumericUpDown();
            this.nudMinStains = new System.Windows.Forms.NumericUpDown();
            this.cebxIsSelectConn = new System.Windows.Forms.CheckBox();
            this.lbl_higt = new System.Windows.Forms.Label();
            this.lbl_areaMax = new System.Windows.Forms.Label();
            this.lbl_low = new System.Windows.Forms.Label();
            this.lbl_areaMin = new System.Windows.Forms.Label();
            this.takBarHigThreshold = new System.Windows.Forms.TrackBar();
            this.takBarLowThreshold = new System.Windows.Forms.TrackBar();
            this.tbxToolName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxImage = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cebxFixture = new System.Windows.Forms.CheckBox();
            this.cbxFixture = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDrawRoi = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxRoi = new System.Windows.Forms.ComboBox();
            this.ceboxIsRoi = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbxSetdraw = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cebxIsRectangle = new System.Windows.Forms.CheckBox();
            this.cebxIsSurfaceStani = new System.Windows.Forms.CheckBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_sure = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label39 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSigma1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSigma2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxStains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinStains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.takBarHigThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.takBarLowThreshold)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(459, 618);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.tbxToolName);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(451, 589);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设置";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.cbxFeature);
            this.groupBox2.Controls.Add(this.nudSigma1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nudSigma2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.nudMaxStains);
            this.groupBox2.Controls.Add(this.nudMinStains);
            this.groupBox2.Controls.Add(this.cebxIsSelectConn);
            this.groupBox2.Controls.Add(this.lbl_higt);
            this.groupBox2.Controls.Add(this.lbl_areaMax);
            this.groupBox2.Controls.Add(this.lbl_low);
            this.groupBox2.Controls.Add(this.lbl_areaMin);
            this.groupBox2.Controls.Add(this.takBarHigThreshold);
            this.groupBox2.Controls.Add(this.takBarLowThreshold);
            this.groupBox2.Location = new System.Drawing.Point(8, 184);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(436, 394);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "分割设置";
            // 
            // cbxFeature
            // 
            this.cbxFeature.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxFeature.FormattingEnabled = true;
            this.cbxFeature.Items.AddRange(new object[] {
            "covers",
            "distance_center",
            "distance_contour",
            "distance_dilate",
            "fits",
            "overlaps_abs",
            "overlaps_rel"});
            this.cbxFeature.Location = new System.Drawing.Point(120, 269);
            this.cbxFeature.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxFeature.Name = "cbxFeature";
            this.cbxFeature.Size = new System.Drawing.Size(303, 25);
            this.cbxFeature.TabIndex = 51;
            this.cbxFeature.SelectedIndexChanged += new System.EventHandler(this.cbxFeature_SelectedIndexChanged);
            // 
            // nudSigma1
            // 
            this.nudSigma1.DecimalPlaces = 1;
            this.nudSigma1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSigma1.Location = new System.Drawing.Point(119, 66);
            this.nudSigma1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudSigma1.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudSigma1.Name = "nudSigma1";
            this.nudSigma1.Size = new System.Drawing.Size(311, 25);
            this.nudSigma1.TabIndex = 19;
            this.nudSigma1.ValueChanged += new System.EventHandler(this.nudSigma1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 281);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 52;
            this.label3.Text = "特征选择：";
            // 
            // nudSigma2
            // 
            this.nudSigma2.DecimalPlaces = 1;
            this.nudSigma2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudSigma2.Location = new System.Drawing.Point(119, 21);
            this.nudSigma2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudSigma2.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudSigma2.Name = "nudSigma2";
            this.nudSigma2.Size = new System.Drawing.Size(309, 25);
            this.nudSigma2.TabIndex = 18;
            this.nudSigma2.ValueChanged += new System.EventHandler(this.nudSigma2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "高斯滤波高值：";
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "高斯滤波低值：";
            // 
            // nudMaxStains
            // 
            this.nudMaxStains.Location = new System.Drawing.Point(119, 346);
            this.nudMaxStains.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudMaxStains.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudMaxStains.Name = "nudMaxStains";
            this.nudMaxStains.Size = new System.Drawing.Size(311, 25);
            this.nudMaxStains.TabIndex = 13;
            this.nudMaxStains.ValueChanged += new System.EventHandler(this.nudMaxStains_ValueChanged);
            // 
            // nudMinStains
            // 
            this.nudMinStains.Location = new System.Drawing.Point(120, 306);
            this.nudMinStains.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudMinStains.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudMinStains.Name = "nudMinStains";
            this.nudMinStains.Size = new System.Drawing.Size(309, 25);
            this.nudMinStains.TabIndex = 12;
            this.nudMinStains.ValueChanged += new System.EventHandler(this.nudMinStains_ValueChanged);
            // 
            // cebxIsSelectConn
            // 
            this.cebxIsSelectConn.AutoSize = true;
            this.cebxIsSelectConn.BackColor = System.Drawing.Color.Silver;
            this.cebxIsSelectConn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cebxIsSelectConn.Location = new System.Drawing.Point(389, 409);
            this.cebxIsSelectConn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cebxIsSelectConn.Name = "cebxIsSelectConn";
            this.cebxIsSelectConn.Size = new System.Drawing.Size(86, 19);
            this.cebxIsSelectConn.TabIndex = 11;
            this.cebxIsSelectConn.Text = "连通区域";
            this.cebxIsSelectConn.UseVisualStyleBackColor = false;
            // 
            // lbl_higt
            // 
            this.lbl_higt.AutoSize = true;
            this.lbl_higt.Location = new System.Drawing.Point(5, 186);
            this.lbl_higt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_higt.Name = "lbl_higt";
            this.lbl_higt.Size = new System.Drawing.Size(67, 15);
            this.lbl_higt.TabIndex = 3;
            this.lbl_higt.Text = "高阀值：";
            // 
            // lbl_areaMax
            // 
            this.lbl_areaMax.AutoSize = true;
            this.lbl_areaMax.Location = new System.Drawing.Point(9, 358);
            this.lbl_areaMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_areaMax.Name = "lbl_areaMax";
            this.lbl_areaMax.Size = new System.Drawing.Size(112, 15);
            this.lbl_areaMax.TabIndex = 8;
            this.lbl_areaMax.Text = "特征最大限定：";
            // 
            // lbl_low
            // 
            this.lbl_low.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.lbl_low.AutoSize = true;
            this.lbl_low.Location = new System.Drawing.Point(5, 105);
            this.lbl_low.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_low.Name = "lbl_low";
            this.lbl_low.Size = new System.Drawing.Size(67, 15);
            this.lbl_low.TabIndex = 2;
            this.lbl_low.Text = "低阀值：";
            // 
            // lbl_areaMin
            // 
            this.lbl_areaMin.AutoSize = true;
            this.lbl_areaMin.Location = new System.Drawing.Point(9, 318);
            this.lbl_areaMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_areaMin.Name = "lbl_areaMin";
            this.lbl_areaMin.Size = new System.Drawing.Size(112, 15);
            this.lbl_areaMin.TabIndex = 7;
            this.lbl_areaMin.Text = "特征最小限定：";
            // 
            // takBarHigThreshold
            // 
            this.takBarHigThreshold.BackColor = System.Drawing.SystemColors.WindowText;
            this.takBarHigThreshold.Location = new System.Drawing.Point(5, 205);
            this.takBarHigThreshold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.takBarHigThreshold.Maximum = 255;
            this.takBarHigThreshold.Name = "takBarHigThreshold";
            this.takBarHigThreshold.Size = new System.Drawing.Size(423, 56);
            this.takBarHigThreshold.TabIndex = 1;
            this.takBarHigThreshold.Value = 130;
            this.takBarHigThreshold.Scroll += new System.EventHandler(this.takBarHigThreshold_Scroll);
            // 
            // takBarLowThreshold
            // 
            this.takBarLowThreshold.BackColor = System.Drawing.SystemColors.WindowText;
            this.takBarLowThreshold.Location = new System.Drawing.Point(5, 124);
            this.takBarLowThreshold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.takBarLowThreshold.Maximum = 255;
            this.takBarLowThreshold.Name = "takBarLowThreshold";
            this.takBarLowThreshold.Size = new System.Drawing.Size(423, 56);
            this.takBarLowThreshold.TabIndex = 0;
            this.takBarLowThreshold.Scroll += new System.EventHandler(this.takBarLowThreshold_Scroll);
            // 
            // tbxToolName
            // 
            this.tbxToolName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxToolName.Location = new System.Drawing.Point(105, 6);
            this.tbxToolName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxToolName.Name = "tbxToolName";
            this.tbxToolName.Size = new System.Drawing.Size(316, 30);
            this.tbxToolName.TabIndex = 65;
            this.tbxToolName.TextChanged += new System.EventHandler(this.tbxToolName_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbxImage);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Location = new System.Drawing.Point(3, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(441, 56);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像设置";
            // 
            // cbxImage
            // 
            this.cbxImage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxImage.FormattingEnabled = true;
            this.cbxImage.Location = new System.Drawing.Point(103, 20);
            this.cbxImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxImage.Name = "cbxImage";
            this.cbxImage.Size = new System.Drawing.Size(317, 25);
            this.cbxImage.TabIndex = 0;
            this.cbxImage.SelectedIndexChanged += new System.EventHandler(this.cbxImage_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(8, 26);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(82, 15);
            this.label30.TabIndex = 1;
            this.label30.Text = "输入图像：";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(27, 24);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(67, 15);
            this.label31.TabIndex = 64;
            this.label31.Text = "工具名：";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.cebxFixture);
            this.groupBox4.Controls.Add(this.cbxFixture);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(3, 118);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(441, 59);
            this.groupBox4.TabIndex = 66;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "位置定位设置";
            // 
            // cebxFixture
            // 
            this.cebxFixture.AutoSize = true;
            this.cebxFixture.Location = new System.Drawing.Point(365, 25);
            this.cebxFixture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cebxFixture.Name = "cebxFixture";
            this.cebxFixture.Size = new System.Drawing.Size(59, 19);
            this.cebxFixture.TabIndex = 50;
            this.cebxFixture.Text = "使用";
            this.cebxFixture.UseVisualStyleBackColor = true;
            this.cebxFixture.CheckedChanged += new System.EventHandler(this.cebxFixture_CheckedChanged);
            // 
            // cbxFixture
            // 
            this.cbxFixture.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxFixture.FormattingEnabled = true;
            this.cbxFixture.Location = new System.Drawing.Point(111, 20);
            this.cbxFixture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxFixture.Name = "cbxFixture";
            this.cbxFixture.Size = new System.Drawing.Size(245, 25);
            this.cbxFixture.TabIndex = 0;
            this.cbxFixture.SelectedIndexChanged += new System.EventHandler(this.cbxFixture_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 32);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "输入定位位置：";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage2.Controls.Add(this.btnDrawRoi);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cbxRoi);
            this.tabPage2.Controls.Add(this.ceboxIsRoi);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(451, 589);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "区域";
            // 
            // btnDrawRoi
            // 
            this.btnDrawRoi.Location = new System.Drawing.Point(299, 30);
            this.btnDrawRoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDrawRoi.Name = "btnDrawRoi";
            this.btnDrawRoi.Size = new System.Drawing.Size(124, 29);
            this.btnDrawRoi.TabIndex = 66;
            this.btnDrawRoi.Text = "创建ROI区域";
            this.btnDrawRoi.UseVisualStyleBackColor = true;
            this.btnDrawRoi.Click += new System.EventHandler(this.btnDrawRoi_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 15);
            this.label7.TabIndex = 65;
            this.label7.Text = "ROI：";
            // 
            // cbxRoi
            // 
            this.cbxRoi.FormattingEnabled = true;
            this.cbxRoi.Location = new System.Drawing.Point(67, 34);
            this.cbxRoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxRoi.Name = "cbxRoi";
            this.cbxRoi.Size = new System.Drawing.Size(223, 23);
            this.cbxRoi.TabIndex = 64;
            this.cbxRoi.SelectedIndexChanged += new System.EventHandler(this.cbxRoi_SelectedIndexChanged);
            // 
            // ceboxIsRoi
            // 
            this.ceboxIsRoi.AutoSize = true;
            this.ceboxIsRoi.Location = new System.Drawing.Point(299, 88);
            this.ceboxIsRoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ceboxIsRoi.Name = "ceboxIsRoi";
            this.ceboxIsRoi.Size = new System.Drawing.Size(119, 19);
            this.ceboxIsRoi.TabIndex = 63;
            this.ceboxIsRoi.Text = "使用限定区域";
            this.ceboxIsRoi.UseVisualStyleBackColor = true;
            this.ceboxIsRoi.CheckedChanged += new System.EventHandler(this.ceboxIsRoi_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage3.Controls.Add(this.cbxSetdraw);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.cebxIsRectangle);
            this.tabPage3.Controls.Add(this.cebxIsSurfaceStani);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(451, 589);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "图形";
            // 
            // cbxSetdraw
            // 
            this.cbxSetdraw.FormattingEnabled = true;
            this.cbxSetdraw.Items.AddRange(new object[] {
            "fill",
            "margin"});
            this.cbxSetdraw.Location = new System.Drawing.Point(69, 146);
            this.cbxSetdraw.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxSetdraw.Name = "cbxSetdraw";
            this.cbxSetdraw.Size = new System.Drawing.Size(160, 23);
            this.cbxSetdraw.TabIndex = 71;
            this.cbxSetdraw.Text = "fill";
            this.cbxSetdraw.SelectedIndexChanged += new System.EventHandler(this.cbxSetdraw_SelectedIndexChanged_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 156);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 70;
            this.label8.Text = "显示：";
            // 
            // cebxIsRectangle
            // 
            this.cebxIsRectangle.AutoSize = true;
            this.cebxIsRectangle.BackColor = System.Drawing.Color.Silver;
            this.cebxIsRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cebxIsRectangle.Location = new System.Drawing.Point(69, 95);
            this.cebxIsRectangle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cebxIsRectangle.Name = "cebxIsRectangle";
            this.cebxIsRectangle.Size = new System.Drawing.Size(116, 19);
            this.cebxIsRectangle.TabIndex = 68;
            this.cebxIsRectangle.Text = "显示最小矩形";
            this.cebxIsRectangle.UseVisualStyleBackColor = false;
            this.cebxIsRectangle.CheckedChanged += new System.EventHandler(this.cebxIsRectangle_CheckedChanged);
            // 
            // cebxIsSurfaceStani
            // 
            this.cebxIsSurfaceStani.AutoSize = true;
            this.cebxIsSurfaceStani.BackColor = System.Drawing.Color.Silver;
            this.cebxIsSurfaceStani.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cebxIsSurfaceStani.Location = new System.Drawing.Point(69, 42);
            this.cebxIsSurfaceStani.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cebxIsSurfaceStani.Name = "cebxIsSurfaceStani";
            this.cebxIsSurfaceStani.Size = new System.Drawing.Size(116, 19);
            this.cebxIsSurfaceStani.TabIndex = 67;
            this.cebxIsSurfaceStani.Text = "显示脏污区域";
            this.cebxIsSurfaceStani.UseVisualStyleBackColor = false;
            this.cebxIsSurfaceStani.CheckedChanged += new System.EventHandler(this.cebxIsSurfaceStani_CheckedChanged);
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTimer.Location = new System.Drawing.Point(116, 659);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(65, 18);
            this.lblTimer.TabIndex = 55;
            this.lblTimer.Text = "耗时：";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(356, 640);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 36);
            this.btn_cancel.TabIndex = 54;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_sure
            // 
            this.btn_sure.Location = new System.Drawing.Point(248, 640);
            this.btn_sure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_sure.Name = "btn_sure";
            this.btn_sure.Size = new System.Drawing.Size(100, 36);
            this.btn_sure.TabIndex = 53;
            this.btn_sure.Text = "确定";
            this.btn_sure.UseVisualStyleBackColor = true;
            this.btn_sure.Click += new System.EventHandler(this.btn_sure_Click);
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(3, 640);
            this.btn_run.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(100, 36);
            this.btn_run.TabIndex = 52;
            this.btn_run.Text = "运行";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hWindowControl1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Location = new System.Drawing.Point(482, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 655);
            this.panel1.TabIndex = 112;
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
            this.panel2.Controls.Add(this.label39);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(4, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(626, 30);
            this.panel2.TabIndex = 9;
            this.panel2.Visible = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(4, 6);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(52, 15);
            this.label39.TabIndex = 3;
            this.label39.Text = "图像：";
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
            // frm_SurfaceStains
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 691);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_sure);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_SurfaceStains";
            this.Text = "脏污提取";
            this.Load += new System.EventHandler(this.frm_SurfaceStains_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSigma1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSigma2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxStains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinStains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.takBarHigThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.takBarLowThreshold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;

        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_sure;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbxToolName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxImage;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cebxFixture;
        private System.Windows.Forms.ComboBox cbxFixture;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cebxIsSelectConn;
        private System.Windows.Forms.Label lbl_higt;
        private System.Windows.Forms.Label lbl_areaMax;
        private System.Windows.Forms.Label lbl_low;
        private System.Windows.Forms.Label lbl_areaMin;
        private System.Windows.Forms.TrackBar takBarHigThreshold;
        private System.Windows.Forms.TrackBar takBarLowThreshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMaxStains;
        private System.Windows.Forms.NumericUpDown nudMinStains;
        private System.Windows.Forms.NumericUpDown nudSigma1;
        private System.Windows.Forms.NumericUpDown nudSigma2;
        private System.Windows.Forms.CheckBox ceboxIsRoi;
        private System.Windows.Forms.Button btnDrawRoi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxRoi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cebxIsRectangle;
        private System.Windows.Forms.CheckBox cebxIsSurfaceStani;
        private System.Windows.Forms.ComboBox cbxSetdraw;
        private System.Windows.Forms.ComboBox cbxFeature;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        public HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolLabel3;
    }
}