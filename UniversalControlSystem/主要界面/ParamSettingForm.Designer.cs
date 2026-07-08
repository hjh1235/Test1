namespace UniversalControlSystem
{
    partial class ParamSettingForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_DoorOpenStop = new System.Windows.Forms.RadioButton();
            this.rbtn_DoorOpenEStop = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtn_GratingStop = new System.Windows.Forms.RadioButton();
            this.rbtn_GratingEStop = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbo_GetSNWay = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_MESLoad = new System.Windows.Forms.Button();
            this.cbo_MESSetting = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chooseAisx = new System.Windows.Forms.CheckBox();
            this.checkBox_回原选择 = new System.Windows.Forms.CheckBox();
            this.checkBox_锁光 = new System.Windows.Forms.CheckBox();
            this.cb_IgnoreScanner = new System.Windows.Forms.CheckBox();
            this.checkBox_屏蔽AGV = new System.Windows.Forms.CheckBox();
            this.cb_IgnoreMES = new System.Windows.Forms.CheckBox();
            this.checkBox_BIZZ = new System.Windows.Forms.CheckBox();
            this.checkB_Door = new System.Windows.Forms.CheckBox();
            this.cb_CloseLaser = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.COM_flow2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.com_singleTaskList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.com_flow1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.com_pointListLeft = new System.Windows.Forms.ComboBox();
            this.com_pointListRight = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtn_DoorOpenStop);
            this.groupBox1.Controls.Add(this.rbtn_DoorOpenEStop);
            this.groupBox1.Location = new System.Drawing.Point(135, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "门禁";
            // 
            // rbtn_DoorOpenStop
            // 
            this.rbtn_DoorOpenStop.AutoSize = true;
            this.rbtn_DoorOpenStop.Location = new System.Drawing.Point(26, 55);
            this.rbtn_DoorOpenStop.Name = "rbtn_DoorOpenStop";
            this.rbtn_DoorOpenStop.Size = new System.Drawing.Size(71, 16);
            this.rbtn_DoorOpenStop.TabIndex = 1;
            this.rbtn_DoorOpenStop.TabStop = true;
            this.rbtn_DoorOpenStop.Text = "暂停模式";
            this.rbtn_DoorOpenStop.UseVisualStyleBackColor = true;
            this.rbtn_DoorOpenStop.CheckedChanged += new System.EventHandler(this.rbtn_DoorOpenStop_CheckedChanged);
            // 
            // rbtn_DoorOpenEStop
            // 
            this.rbtn_DoorOpenEStop.AutoSize = true;
            this.rbtn_DoorOpenEStop.Location = new System.Drawing.Point(26, 20);
            this.rbtn_DoorOpenEStop.Name = "rbtn_DoorOpenEStop";
            this.rbtn_DoorOpenEStop.Size = new System.Drawing.Size(71, 16);
            this.rbtn_DoorOpenEStop.TabIndex = 0;
            this.rbtn_DoorOpenEStop.TabStop = true;
            this.rbtn_DoorOpenEStop.Text = "急停模式";
            this.rbtn_DoorOpenEStop.UseVisualStyleBackColor = true;
            this.rbtn_DoorOpenEStop.CheckedChanged += new System.EventHandler(this.rbtn_DoorOpenEStop_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtn_GratingStop);
            this.groupBox2.Controls.Add(this.rbtn_GratingEStop);
            this.groupBox2.Location = new System.Drawing.Point(287, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(106, 76);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "光栅";
            // 
            // rbtn_GratingStop
            // 
            this.rbtn_GratingStop.AutoSize = true;
            this.rbtn_GratingStop.Location = new System.Drawing.Point(23, 54);
            this.rbtn_GratingStop.Name = "rbtn_GratingStop";
            this.rbtn_GratingStop.Size = new System.Drawing.Size(71, 16);
            this.rbtn_GratingStop.TabIndex = 3;
            this.rbtn_GratingStop.TabStop = true;
            this.rbtn_GratingStop.Text = "暂停模式";
            this.rbtn_GratingStop.UseVisualStyleBackColor = true;
            this.rbtn_GratingStop.CheckedChanged += new System.EventHandler(this.rbtn_GratingStop_CheckedChanged);
            // 
            // rbtn_GratingEStop
            // 
            this.rbtn_GratingEStop.AutoSize = true;
            this.rbtn_GratingEStop.Location = new System.Drawing.Point(23, 20);
            this.rbtn_GratingEStop.Name = "rbtn_GratingEStop";
            this.rbtn_GratingEStop.Size = new System.Drawing.Size(71, 16);
            this.rbtn_GratingEStop.TabIndex = 2;
            this.rbtn_GratingEStop.TabStop = true;
            this.rbtn_GratingEStop.Text = "急停模式";
            this.rbtn_GratingEStop.UseVisualStyleBackColor = true;
            this.rbtn_GratingEStop.CheckedChanged += new System.EventHandler(this.rbtn_GratingEStop_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbo_GetSNWay);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 73);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "获取条码方式";
            // 
            // cbo_GetSNWay
            // 
            this.cbo_GetSNWay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_GetSNWay.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_GetSNWay.FormattingEnabled = true;
            this.cbo_GetSNWay.Items.AddRange(new object[] {
            "物料条码",
            "工装条码"});
            this.cbo_GetSNWay.Location = new System.Drawing.Point(190, 31);
            this.cbo_GetSNWay.Name = "cbo_GetSNWay";
            this.cbo_GetSNWay.Size = new System.Drawing.Size(120, 24);
            this.cbo_GetSNWay.TabIndex = 556;
            this.cbo_GetSNWay.SelectedIndexChanged += new System.EventHandler(this.cbo_GetSNWay_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_MESLoad);
            this.groupBox4.Controls.Add(this.cbo_MESSetting);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(528, 62);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MES配置";
            // 
            // btn_MESLoad
            // 
            this.btn_MESLoad.Location = new System.Drawing.Point(268, 21);
            this.btn_MESLoad.Name = "btn_MESLoad";
            this.btn_MESLoad.Size = new System.Drawing.Size(120, 28);
            this.btn_MESLoad.TabIndex = 557;
            this.btn_MESLoad.Text = "登录MES";
            this.btn_MESLoad.UseVisualStyleBackColor = true;
            this.btn_MESLoad.Click += new System.EventHandler(this.btn_MESLoad_Click);
            // 
            // cbo_MESSetting
            // 
            this.cbo_MESSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_MESSetting.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_MESSetting.FormattingEnabled = true;
            this.cbo_MESSetting.Items.AddRange(new object[] {
            "惠州博罗",
            "金叶",
            "光明厂区"});
            this.cbo_MESSetting.Location = new System.Drawing.Point(119, 21);
            this.cbo_MESSetting.Name = "cbo_MESSetting";
            this.cbo_MESSetting.Size = new System.Drawing.Size(120, 24);
            this.cbo_MESSetting.TabIndex = 556;
            this.cbo_MESSetting.SelectedIndexChanged += new System.EventHandler(this.cbo_MESSetting_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chooseAisx);
            this.groupBox5.Controls.Add(this.checkBox_回原选择);
            this.groupBox5.Controls.Add(this.checkBox_锁光);
            this.groupBox5.Controls.Add(this.cb_IgnoreScanner);
            this.groupBox5.Controls.Add(this.checkBox_屏蔽AGV);
            this.groupBox5.Controls.Add(this.cb_IgnoreMES);
            this.groupBox5.Controls.Add(this.checkBox_BIZZ);
            this.groupBox5.Controls.Add(this.checkB_Door);
            this.groupBox5.Controls.Add(this.cb_CloseLaser);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(528, 73);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "屏蔽选项";
            // 
            // chooseAisx
            // 
            this.chooseAisx.AutoSize = true;
            this.chooseAisx.Location = new System.Drawing.Point(166, 42);
            this.chooseAisx.Name = "chooseAisx";
            this.chooseAisx.Size = new System.Drawing.Size(78, 16);
            this.chooseAisx.TabIndex = 2;
            this.chooseAisx.Text = "选择4/8轴";
            this.chooseAisx.UseVisualStyleBackColor = true;
            this.chooseAisx.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_2);
            // 
            // checkBox_回原选择
            // 
            this.checkBox_回原选择.AutoSize = true;
            this.checkBox_回原选择.Location = new System.Drawing.Point(77, 42);
            this.checkBox_回原选择.Name = "checkBox_回原选择";
            this.checkBox_回原选择.Size = new System.Drawing.Size(72, 16);
            this.checkBox_回原选择.TabIndex = 2;
            this.checkBox_回原选择.Text = "回原选择";
            this.checkBox_回原选择.UseVisualStyleBackColor = true;
            this.checkBox_回原选择.CheckedChanged += new System.EventHandler(this.checkBox_回原选择_CheckedChanged);
            // 
            // checkBox_锁光
            // 
            this.checkBox_锁光.AutoSize = true;
            this.checkBox_锁光.Location = new System.Drawing.Point(12, 42);
            this.checkBox_锁光.Name = "checkBox_锁光";
            this.checkBox_锁光.Size = new System.Drawing.Size(48, 16);
            this.checkBox_锁光.TabIndex = 2;
            this.checkBox_锁光.Text = "锁光";
            this.checkBox_锁光.UseVisualStyleBackColor = true;
            this.checkBox_锁光.CheckedChanged += new System.EventHandler(this.checkBox_锁光_CheckedChanged);
            // 
            // cb_IgnoreScanner
            // 
            this.cb_IgnoreScanner.AutoSize = true;
            this.cb_IgnoreScanner.Location = new System.Drawing.Point(420, 19);
            this.cb_IgnoreScanner.Name = "cb_IgnoreScanner";
            this.cb_IgnoreScanner.Size = new System.Drawing.Size(72, 16);
            this.cb_IgnoreScanner.TabIndex = 2;
            this.cb_IgnoreScanner.Text = "屏蔽扫码";
            this.cb_IgnoreScanner.UseVisualStyleBackColor = true;
            this.cb_IgnoreScanner.CheckedChanged += new System.EventHandler(this.cb_IgnoreScanner_CheckedChanged);
            // 
            // checkBox_屏蔽AGV
            // 
            this.checkBox_屏蔽AGV.AutoSize = true;
            this.checkBox_屏蔽AGV.Location = new System.Drawing.Point(342, 18);
            this.checkBox_屏蔽AGV.Name = "checkBox_屏蔽AGV";
            this.checkBox_屏蔽AGV.Size = new System.Drawing.Size(66, 16);
            this.checkBox_屏蔽AGV.TabIndex = 2;
            this.checkBox_屏蔽AGV.Text = "屏蔽AGV";
            this.checkBox_屏蔽AGV.UseVisualStyleBackColor = true;
            this.checkBox_屏蔽AGV.CheckedChanged += new System.EventHandler(this.checkBox_屏蔽AGV_CheckedChanged);
            // 
            // cb_IgnoreMES
            // 
            this.cb_IgnoreMES.AutoSize = true;
            this.cb_IgnoreMES.Location = new System.Drawing.Point(264, 19);
            this.cb_IgnoreMES.Name = "cb_IgnoreMES";
            this.cb_IgnoreMES.Size = new System.Drawing.Size(66, 16);
            this.cb_IgnoreMES.TabIndex = 1;
            this.cb_IgnoreMES.Text = "屏蔽MES";
            this.cb_IgnoreMES.UseVisualStyleBackColor = true;
            this.cb_IgnoreMES.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // checkBox_BIZZ
            // 
            this.checkBox_BIZZ.AutoSize = true;
            this.checkBox_BIZZ.Location = new System.Drawing.Point(168, 20);
            this.checkBox_BIZZ.Name = "checkBox_BIZZ";
            this.checkBox_BIZZ.Size = new System.Drawing.Size(84, 16);
            this.checkBox_BIZZ.TabIndex = 0;
            this.checkBox_BIZZ.Text = "屏蔽蜂鸣器";
            this.checkBox_BIZZ.UseVisualStyleBackColor = true;
            this.checkBox_BIZZ.CheckedChanged += new System.EventHandler(this.checkBox_BIZZ_CheckedChanged);
            // 
            // checkB_Door
            // 
            this.checkB_Door.AutoSize = true;
            this.checkB_Door.Location = new System.Drawing.Point(96, 20);
            this.checkB_Door.Name = "checkB_Door";
            this.checkB_Door.Size = new System.Drawing.Size(60, 16);
            this.checkB_Door.TabIndex = 0;
            this.checkB_Door.Text = "屏蔽门";
            this.checkB_Door.UseVisualStyleBackColor = true;
            this.checkB_Door.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cb_CloseLaser
            // 
            this.cb_CloseLaser.AutoSize = true;
            this.cb_CloseLaser.Location = new System.Drawing.Point(12, 20);
            this.cb_CloseLaser.Name = "cb_CloseLaser";
            this.cb_CloseLaser.Size = new System.Drawing.Size(72, 16);
            this.cb_CloseLaser.TabIndex = 0;
            this.cb_CloseLaser.Text = "屏蔽光栅";
            this.cb_CloseLaser.UseVisualStyleBackColor = true;
            this.cb_CloseLaser.CheckedChanged += new System.EventHandler(this.chk_RightUsed_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 736);
            this.panel1.TabIndex = 5;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox12);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 323);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(528, 413);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "坐标系参数设置";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.groupBox8);
            this.groupBox12.Controls.Add(this.groupBox7);
            this.groupBox12.Location = new System.Drawing.Point(0, 0);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(528, 162);
            this.groupBox12.TabIndex = 4;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "流程点位设置";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.COM_flow2);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this.com_singleTaskList);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Location = new System.Drawing.Point(268, 20);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(242, 127);
            this.groupBox8.TabIndex = 558;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "单工位点位配置";
            // 
            // COM_flow2
            // 
            this.COM_flow2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COM_flow2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.COM_flow2.FormattingEnabled = true;
            this.COM_flow2.Location = new System.Drawing.Point(82, 31);
            this.COM_flow2.Name = "COM_flow2";
            this.COM_flow2.Size = new System.Drawing.Size(147, 24);
            this.COM_flow2.TabIndex = 556;
            this.COM_flow2.SelectedIndexChanged += new System.EventHandler(this.COM_flow2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "流程";
            // 
            // com_singleTaskList
            // 
            this.com_singleTaskList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_singleTaskList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.com_singleTaskList.FormattingEnabled = true;
            this.com_singleTaskList.Location = new System.Drawing.Point(82, 71);
            this.com_singleTaskList.Name = "com_singleTaskList";
            this.com_singleTaskList.Size = new System.Drawing.Size(147, 24);
            this.com_singleTaskList.TabIndex = 556;
            this.com_singleTaskList.SelectedIndexChanged += new System.EventHandler(this.com_singleTaskList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "单工位点位";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.com_flow1);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.com_pointListLeft);
            this.groupBox7.Controls.Add(this.com_pointListRight);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Location = new System.Drawing.Point(9, 20);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(249, 127);
            this.groupBox7.TabIndex = 557;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "双工位点位配置";
            // 
            // com_flow1
            // 
            this.com_flow1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_flow1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.com_flow1.FormattingEnabled = true;
            this.com_flow1.Location = new System.Drawing.Point(83, 20);
            this.com_flow1.Name = "com_flow1";
            this.com_flow1.Size = new System.Drawing.Size(147, 24);
            this.com_flow1.TabIndex = 556;
            this.com_flow1.SelectedIndexChanged += new System.EventHandler(this.com_flow1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "右工位点位";
            // 
            // com_pointListLeft
            // 
            this.com_pointListLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_pointListLeft.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.com_pointListLeft.FormattingEnabled = true;
            this.com_pointListLeft.Location = new System.Drawing.Point(83, 56);
            this.com_pointListLeft.Name = "com_pointListLeft";
            this.com_pointListLeft.Size = new System.Drawing.Size(147, 24);
            this.com_pointListLeft.TabIndex = 556;
            this.com_pointListLeft.SelectedIndexChanged += new System.EventHandler(this.com_pointListLeft_SelectedIndexChanged);
            // 
            // com_pointListRight
            // 
            this.com_pointListRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_pointListRight.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.com_pointListRight.FormattingEnabled = true;
            this.com_pointListRight.Location = new System.Drawing.Point(83, 93);
            this.com_pointListRight.Name = "com_pointListRight";
            this.com_pointListRight.Size = new System.Drawing.Size(147, 24);
            this.com_pointListRight.TabIndex = 556;
            this.com_pointListRight.SelectedIndexChanged += new System.EventHandler(this.com_pointListRight_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 63);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 12);
            this.label20.TabIndex = 1;
            this.label20.Text = "左工位点位";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(40, 27);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "流程";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 250);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(528, 73);
            this.panel5.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 188);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(528, 62);
            this.panel4.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 115);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(528, 73);
            this.panel3.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 115);
            this.panel2.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(528, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(240, 736);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // txtMsg
            // 
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.txtMsg.ForeColor = System.Drawing.Color.Red;
            this.txtMsg.Location = new System.Drawing.Point(528, 0);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(240, 736);
            this.txtMsg.TabIndex = 12;
            this.txtMsg.Text = "提示:\r\n    光栅、门禁：急停模式即轴断使能解除报警后恢复使能，需重新回原点。暂停则是待设备将当前流程运行完毕后再停止，不断使能，重新启动即可。";
            this.txtMsg.TextChanged += new System.EventHandler(this.txtMsg_TextChanged);
            // 
            // ParamSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 736);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ParamSettingForm";
            this.Text = "参数配置界面";
            this.Load += new System.EventHandler(this.ParamSettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtn_DoorOpenStop;
        private System.Windows.Forms.RadioButton rbtn_DoorOpenEStop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtn_GratingStop;
        private System.Windows.Forms.RadioButton rbtn_GratingEStop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.ComboBox cbo_MESSetting;
        private System.Windows.Forms.Button btn_MESLoad;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cb_CloseLaser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        internal System.Windows.Forms.ComboBox cbo_GetSNWay;
        private System.Windows.Forms.CheckBox checkB_Door;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label label20;
        internal System.Windows.Forms.ComboBox com_pointListLeft;
        internal System.Windows.Forms.ComboBox com_flow1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox com_pointListRight;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        internal System.Windows.Forms.ComboBox COM_flow2;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox com_singleTaskList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_BIZZ;
        private System.Windows.Forms.CheckBox cb_IgnoreMES;
        private System.Windows.Forms.CheckBox checkBox_屏蔽AGV;
        private System.Windows.Forms.CheckBox cb_IgnoreScanner;
        private System.Windows.Forms.CheckBox checkBox_锁光;
        private System.Windows.Forms.CheckBox checkBox_回原选择;
        private System.Windows.Forms.CheckBox chooseAisx;
    }
}