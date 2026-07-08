namespace UniversalControlSystem
{
    partial class DebugForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnAllGoHome = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbo_SelectHardware = new System.Windows.Forms.ComboBox();
            this.btnALLAxisGoHome = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAxisGoHome = new System.Windows.Forms.Button();
            this.btn_MoveToCW = new System.Windows.Forms.Button();
            this.BtnMoveToCCW = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMoveMode = new System.Windows.Forms.ComboBox();
            this.comboBoxMoveDis = new System.Windows.Forms.ComboBox();
            this.dataGridViewAxisStatus = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.rbtnDisableMPG = new System.Windows.Forms.RadioButton();
            this.rbtnEnableMPG = new System.Windows.Forms.RadioButton();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblMotionDistance_1 = new System.Windows.Forms.Label();
            this.lblAxisEnable_1 = new System.Windows.Forms.Label();
            this.lblPosition_1 = new System.Windows.Forms.Label();
            this.lblMotion_1 = new System.Windows.Forms.Label();
            this.lblPositvieAlarm_1 = new System.Windows.Forms.Label();
            this.lblNegativeAlarm_1 = new System.Windows.Forms.Label();
            this.lblSpeed_1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AsixName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAllGoHome.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAxisStatus)).BeginInit();
            this.groupBox19.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnAllGoHome
            // 
            this.btnAllGoHome.Controls.Add(this.panel4);
            this.btnAllGoHome.Controls.Add(this.dataGridViewAxisStatus);
            this.btnAllGoHome.Controls.Add(this.groupBox19);
            this.btnAllGoHome.Controls.Add(this.groupBox14);
            this.btnAllGoHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAllGoHome.Location = new System.Drawing.Point(0, 0);
            this.btnAllGoHome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAllGoHome.Name = "btnAllGoHome";
            this.btnAllGoHome.Size = new System.Drawing.Size(1581, 424);
            this.btnAllGoHome.TabIndex = 123;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.comboBoxMoveMode);
            this.panel4.Controls.Add(this.comboBoxMoveDis);
            this.panel4.Location = new System.Drawing.Point(0, 1);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(459, 448);
            this.panel4.TabIndex = 126;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseDown);
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseMove);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.AsixName);
            this.panel5.Controls.Add(this.cbo_SelectHardware);
            this.panel5.Controls.Add(this.btnALLAxisGoHome);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.btnAxisGoHome);
            this.panel5.Controls.Add(this.btn_MoveToCW);
            this.panel5.Controls.Add(this.BtnMoveToCCW);
            this.panel5.Location = new System.Drawing.Point(5, 71);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(451, 351);
            this.panel5.TabIndex = 66;
            this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel5_MouseDown);
            this.panel5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel5_MouseMove);
            // 
            // cbo_SelectHardware
            // 
            this.cbo_SelectHardware.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_SelectHardware.FormattingEnabled = true;
            this.cbo_SelectHardware.Location = new System.Drawing.Point(107, 4);
            this.cbo_SelectHardware.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbo_SelectHardware.Name = "cbo_SelectHardware";
            this.cbo_SelectHardware.Size = new System.Drawing.Size(284, 23);
            this.cbo_SelectHardware.TabIndex = 61;
            // 
            // btnALLAxisGoHome
            // 
            this.btnALLAxisGoHome.BackColor = System.Drawing.Color.Aqua;
            this.btnALLAxisGoHome.Location = new System.Drawing.Point(180, 270);
            this.btnALLAxisGoHome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnALLAxisGoHome.Name = "btnALLAxisGoHome";
            this.btnALLAxisGoHome.Size = new System.Drawing.Size(125, 49);
            this.btnALLAxisGoHome.TabIndex = 18;
            this.btnALLAxisGoHome.Text = "整体回原点";
            this.btnALLAxisGoHome.UseVisualStyleBackColor = false;
            this.btnALLAxisGoHome.Click += new System.EventHandler(this.btnALLAxisGoHome_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.BackColor = System.Drawing.Color.Aqua;
            this.label4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(107, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(284, 29);
            this.label4.TabIndex = 17;
            this.label4.Text = "轴别名";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAxisGoHome
            // 
            this.btnAxisGoHome.BackColor = System.Drawing.Color.Aqua;
            this.btnAxisGoHome.Location = new System.Drawing.Point(180, 210);
            this.btnAxisGoHome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAxisGoHome.Name = "btnAxisGoHome";
            this.btnAxisGoHome.Size = new System.Drawing.Size(125, 49);
            this.btnAxisGoHome.TabIndex = 8;
            this.btnAxisGoHome.Text = "当前轴回原点";
            this.btnAxisGoHome.UseVisualStyleBackColor = false;
            this.btnAxisGoHome.Click += new System.EventHandler(this.btnAxisGoHome_Click);
            // 
            // btn_MoveToCW
            // 
            this.btn_MoveToCW.BackColor = System.Drawing.Color.Aqua;
            this.btn_MoveToCW.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_MoveToCW.Image = ((System.Drawing.Image)(resources.GetObject("btn_MoveToCW.Image")));
            this.btn_MoveToCW.Location = new System.Drawing.Point(258, 132);
            this.btn_MoveToCW.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_MoveToCW.Name = "btn_MoveToCW";
            this.btn_MoveToCW.Size = new System.Drawing.Size(68, 52);
            this.btn_MoveToCW.TabIndex = 3;
            this.btn_MoveToCW.Text = "+";
            this.btn_MoveToCW.UseVisualStyleBackColor = false;
            this.btn_MoveToCW.Click += new System.EventHandler(this.btn_MoveToCW_Click);
            this.btn_MoveToCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_MoveToCW_MouseDown);
            this.btn_MoveToCW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_MoveToCW_MouseUp);
            // 
            // BtnMoveToCCW
            // 
            this.BtnMoveToCCW.BackColor = System.Drawing.Color.Aqua;
            this.BtnMoveToCCW.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnMoveToCCW.Image = ((System.Drawing.Image)(resources.GetObject("BtnMoveToCCW.Image")));
            this.BtnMoveToCCW.Location = new System.Drawing.Point(159, 132);
            this.BtnMoveToCCW.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnMoveToCCW.Name = "BtnMoveToCCW";
            this.BtnMoveToCCW.Size = new System.Drawing.Size(68, 52);
            this.BtnMoveToCCW.TabIndex = 2;
            this.BtnMoveToCCW.Text = "-";
            this.BtnMoveToCCW.UseVisualStyleBackColor = false;
            this.BtnMoveToCCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMoveToCCW_MouseDown);
            this.BtnMoveToCCW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMoveToCCW_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 63;
            this.label3.Text = "移动速度";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 64;
            this.label2.Text = "移动距离";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 65;
            this.label1.Text = "移动方式";
            // 
            // comboBoxMoveMode
            // 
            this.comboBoxMoveMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMoveMode.FormattingEnabled = true;
            this.comboBoxMoveMode.Items.AddRange(new object[] {
            "点位运动",
            "连续运动"});
            this.comboBoxMoveMode.Location = new System.Drawing.Point(71, 34);
            this.comboBoxMoveMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxMoveMode.Name = "comboBoxMoveMode";
            this.comboBoxMoveMode.Size = new System.Drawing.Size(145, 23);
            this.comboBoxMoveMode.TabIndex = 60;
            this.comboBoxMoveMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxMoveMode_SelectedIndexChanged);
            // 
            // comboBoxMoveDis
            // 
            this.comboBoxMoveDis.FormattingEnabled = true;
            this.comboBoxMoveDis.Items.AddRange(new object[] {
            "1.00",
            "0.50",
            "0.10",
            "0.05",
            "0.01"});
            this.comboBoxMoveDis.Location = new System.Drawing.Point(229, 32);
            this.comboBoxMoveDis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxMoveDis.Name = "comboBoxMoveDis";
            this.comboBoxMoveDis.Size = new System.Drawing.Size(145, 23);
            this.comboBoxMoveDis.TabIndex = 62;
            this.comboBoxMoveDis.Text = "0.10";
            this.comboBoxMoveDis.SelectedIndexChanged += new System.EventHandler(this.comboBoxMoveDis_SelectedIndexChanged);
            // 
            // dataGridViewAxisStatus
            // 
            this.dataGridViewAxisStatus.AllowUserToAddRows = false;
            this.dataGridViewAxisStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAxisStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewAxisStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAxisStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
            this.dataGridViewAxisStatus.Location = new System.Drawing.Point(551, 4);
            this.dataGridViewAxisStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewAxisStatus.MultiSelect = false;
            this.dataGridViewAxisStatus.Name = "dataGridViewAxisStatus";
            this.dataGridViewAxisStatus.RowHeadersWidth = 20;
            this.dataGridViewAxisStatus.RowTemplate.Height = 23;
            this.dataGridViewAxisStatus.Size = new System.Drawing.Size(288, 410);
            this.dataGridViewAxisStatus.TabIndex = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn9.HeaderText = "轴信息";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "X";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 40;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Y";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 40;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Z";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 40;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "U";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 40;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.rbtnDisableMPG);
            this.groupBox19.Controls.Add(this.rbtnEnableMPG);
            this.groupBox19.Location = new System.Drawing.Point(1372, 320);
            this.groupBox19.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox19.Size = new System.Drawing.Size(205, 98);
            this.groupBox19.TabIndex = 123;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "电子手轮";
            // 
            // rbtnDisableMPG
            // 
            this.rbtnDisableMPG.AutoSize = true;
            this.rbtnDisableMPG.Checked = true;
            this.rbtnDisableMPG.Location = new System.Drawing.Point(25, 61);
            this.rbtnDisableMPG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnDisableMPG.Name = "rbtnDisableMPG";
            this.rbtnDisableMPG.Size = new System.Drawing.Size(88, 19);
            this.rbtnDisableMPG.TabIndex = 1;
            this.rbtnDisableMPG.TabStop = true;
            this.rbtnDisableMPG.Text = "禁用手轮";
            this.rbtnDisableMPG.UseVisualStyleBackColor = true;
            // 
            // rbtnEnableMPG
            // 
            this.rbtnEnableMPG.AutoSize = true;
            this.rbtnEnableMPG.Location = new System.Drawing.Point(25, 29);
            this.rbtnEnableMPG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnEnableMPG.Name = "rbtnEnableMPG";
            this.rbtnEnableMPG.Size = new System.Drawing.Size(88, 19);
            this.rbtnEnableMPG.TabIndex = 0;
            this.rbtnEnableMPG.TabStop = true;
            this.rbtnEnableMPG.Text = "启用手轮";
            this.rbtnEnableMPG.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.groupBox3);
            this.groupBox14.Location = new System.Drawing.Point(1372, 9);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox14.Size = new System.Drawing.Size(205, 294);
            this.groupBox14.TabIndex = 124;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "运控状态";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.lblMotionDistance_1);
            this.groupBox3.Controls.Add(this.lblAxisEnable_1);
            this.groupBox3.Controls.Add(this.lblPosition_1);
            this.groupBox3.Controls.Add(this.lblMotion_1);
            this.groupBox3.Controls.Add(this.lblPositvieAlarm_1);
            this.groupBox3.Controls.Add(this.lblNegativeAlarm_1);
            this.groupBox3.Controls.Add(this.lblSpeed_1);
            this.groupBox3.Location = new System.Drawing.Point(7, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(191, 290);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "轴";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBox1.Location = new System.Drawing.Point(13, 20);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 23);
            this.comboBox1.TabIndex = 25;
            this.comboBox1.Text = "请选择轴号";
            // 
            // lblMotionDistance_1
            // 
            this.lblMotionDistance_1.AutoSize = true;
            this.lblMotionDistance_1.ForeColor = System.Drawing.Color.Blue;
            this.lblMotionDistance_1.Location = new System.Drawing.Point(75, 91);
            this.lblMotionDistance_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMotionDistance_1.Name = "lblMotionDistance_1";
            this.lblMotionDistance_1.Size = new System.Drawing.Size(37, 15);
            this.lblMotionDistance_1.TabIndex = 24;
            this.lblMotionDistance_1.Text = "累计";
            // 
            // lblAxisEnable_1
            // 
            this.lblAxisEnable_1.AutoSize = true;
            this.lblAxisEnable_1.Location = new System.Drawing.Point(11, 69);
            this.lblAxisEnable_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAxisEnable_1.Name = "lblAxisEnable_1";
            this.lblAxisEnable_1.Size = new System.Drawing.Size(37, 15);
            this.lblAxisEnable_1.TabIndex = 3;
            this.lblAxisEnable_1.Text = "使能";
            // 
            // lblPosition_1
            // 
            this.lblPosition_1.AutoSize = true;
            this.lblPosition_1.Location = new System.Drawing.Point(83, 69);
            this.lblPosition_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosition_1.Name = "lblPosition_1";
            this.lblPosition_1.Size = new System.Drawing.Size(37, 15);
            this.lblPosition_1.TabIndex = 4;
            this.lblPosition_1.Text = "位置";
            // 
            // lblMotion_1
            // 
            this.lblMotion_1.AutoSize = true;
            this.lblMotion_1.Location = new System.Drawing.Point(139, 88);
            this.lblMotion_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMotion_1.Name = "lblMotion_1";
            this.lblMotion_1.Size = new System.Drawing.Size(37, 15);
            this.lblMotion_1.TabIndex = 5;
            this.lblMotion_1.Text = "状态";
            // 
            // lblPositvieAlarm_1
            // 
            this.lblPositvieAlarm_1.AutoSize = true;
            this.lblPositvieAlarm_1.Location = new System.Drawing.Point(11, 112);
            this.lblPositvieAlarm_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPositvieAlarm_1.Name = "lblPositvieAlarm_1";
            this.lblPositvieAlarm_1.Size = new System.Drawing.Size(52, 15);
            this.lblPositvieAlarm_1.TabIndex = 6;
            this.lblPositvieAlarm_1.Text = "正限位";
            // 
            // lblNegativeAlarm_1
            // 
            this.lblNegativeAlarm_1.AutoSize = true;
            this.lblNegativeAlarm_1.Location = new System.Drawing.Point(96, 112);
            this.lblNegativeAlarm_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNegativeAlarm_1.Name = "lblNegativeAlarm_1";
            this.lblNegativeAlarm_1.Size = new System.Drawing.Size(52, 15);
            this.lblNegativeAlarm_1.TabIndex = 7;
            this.lblNegativeAlarm_1.Text = "负限位";
            // 
            // lblSpeed_1
            // 
            this.lblSpeed_1.AutoSize = true;
            this.lblSpeed_1.Location = new System.Drawing.Point(11, 91);
            this.lblSpeed_1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeed_1.Name = "lblSpeed_1";
            this.lblSpeed_1.Size = new System.Drawing.Size(37, 15);
            this.lblSpeed_1.TabIndex = 8;
            this.lblSpeed_1.Text = "速度";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAllGoHome);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1581, 421);
            this.panel3.TabIndex = 124;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(459, 28);
            this.menuStrip1.TabIndex = 377;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            this.menuStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseMove);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.关闭ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.关闭ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("关闭ToolStripMenuItem.Image")));
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(32, 24);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // AsixName
            // 
            this.AsixName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AsixName.FormattingEnabled = true;
            this.AsixName.Location = new System.Drawing.Point(107, 43);
            this.AsixName.Margin = new System.Windows.Forms.Padding(4);
            this.AsixName.Name = "AsixName";
            this.AsixName.Size = new System.Drawing.Size(284, 23);
            this.AsixName.TabIndex = 62;
            this.AsixName.SelectedIndexChanged += new System.EventHandler(this.AsixName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 63;
            this.label5.Text = "绑定:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 64;
            this.label6.Text = "轴名称:";
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 420);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DebugForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "伺服控制（手动/自动）";
            this.Load += new System.EventHandler(this.DebugForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DebugForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DebugForm_MouseMove);
            this.btnAllGoHome.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAxisStatus)).EndInit();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel btnAllGoHome;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAxisGoHome;
        private System.Windows.Forms.Button btn_MoveToCW;
        private System.Windows.Forms.Button BtnMoveToCCW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMoveMode;
        private System.Windows.Forms.ComboBox comboBoxMoveDis;
        private System.Windows.Forms.DataGridView dataGridViewAxisStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.RadioButton rbtnDisableMPG;
        private System.Windows.Forms.RadioButton rbtnEnableMPG;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblMotionDistance_1;
        private System.Windows.Forms.Label lblAxisEnable_1;
        private System.Windows.Forms.Label lblPosition_1;
        private System.Windows.Forms.Label lblMotion_1;
        private System.Windows.Forms.Label lblPositvieAlarm_1;
        private System.Windows.Forms.Label lblNegativeAlarm_1;
        private System.Windows.Forms.Label lblSpeed_1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnALLAxisGoHome;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbo_SelectHardware;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox AsixName;
    }
}