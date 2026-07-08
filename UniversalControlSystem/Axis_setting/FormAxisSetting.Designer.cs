namespace UniversalControlSystem
{
    partial class FormAxisSetting
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
            this.comboBoxCardNo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxAxisNo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Acc = new System.Windows.Forms.TextBox();
            this.txt_Dec = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Speed = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_GoHomeSpeed = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxPlusFeed = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Auto_Speed = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_BuildCorNum = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.是否做测距轴 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.是否做插补轴 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.MainCardShow = new System.Windows.Forms.Label();
            this.搜索限位速度 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.回原方式 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.是否屏蔽 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBox_salveAxis = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBox_ifDoubleAxis = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxCardNo
            // 
            this.comboBoxCardNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCardNo.FormattingEnabled = true;
            this.comboBoxCardNo.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.comboBoxCardNo.Location = new System.Drawing.Point(179, 104);
            this.comboBoxCardNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxCardNo.Name = "comboBoxCardNo";
            this.comboBoxCardNo.Size = new System.Drawing.Size(181, 23);
            this.comboBoxCardNo.TabIndex = 30;
            this.comboBoxCardNo.SelectedIndexChanged += new System.EventHandler(this.comboBoxCardNo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "运动控制卡号";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(107, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 29);
            this.label1.TabIndex = 27;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 38;
            this.label6.Text = "轴号";
            // 
            // comboBoxAxisNo
            // 
            this.comboBoxAxisNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxAxisNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAxisNo.FormattingEnabled = true;
            this.comboBoxAxisNo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.comboBoxAxisNo.Location = new System.Drawing.Point(179, 139);
            this.comboBoxAxisNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxAxisNo.Name = "comboBoxAxisNo";
            this.comboBoxAxisNo.Size = new System.Drawing.Size(181, 23);
            this.comboBoxAxisNo.TabIndex = 39;
            this.comboBoxAxisNo.SelectedIndexChanged += new System.EventHandler(this.comboBoxAxisNo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 180);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 15);
            this.label7.TabIndex = 40;
            this.label7.Text = "加速度(mm/s2)";
            // 
            // txt_Acc
            // 
            this.txt_Acc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Acc.Location = new System.Drawing.Point(179, 174);
            this.txt_Acc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Acc.Name = "txt_Acc";
            this.txt_Acc.Size = new System.Drawing.Size(181, 25);
            this.txt_Acc.TabIndex = 41;
            this.txt_Acc.Text = "1";
            this.txt_Acc.TextChanged += new System.EventHandler(this.txt_Acc_TextChanged);
            this.txt_Acc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Acc_KeyPress);
            // 
            // txt_Dec
            // 
            this.txt_Dec.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Dec.Location = new System.Drawing.Point(179, 211);
            this.txt_Dec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Dec.Name = "txt_Dec";
            this.txt_Dec.Size = new System.Drawing.Size(181, 25);
            this.txt_Dec.TabIndex = 43;
            this.txt_Dec.Text = "1";
            this.txt_Dec.TextChanged += new System.EventHandler(this.txt_Dec_TextChanged);
            this.txt_Dec.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Dec_KeyPress);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 216);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 15);
            this.label8.TabIndex = 42;
            this.label8.Text = "减速度(mm/s2)";
            // 
            // txt_Speed
            // 
            this.txt_Speed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Speed.Location = new System.Drawing.Point(179, 248);
            this.txt_Speed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Speed.Name = "txt_Speed";
            this.txt_Speed.Size = new System.Drawing.Size(181, 25);
            this.txt_Speed.TabIndex = 45;
            this.txt_Speed.Text = "1";
            this.txt_Speed.TextChanged += new System.EventHandler(this.txt_Speed_TextChanged);
            this.txt_Speed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Speed_KeyPress);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 252);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 15);
            this.label9.TabIndex = 44;
            this.label9.Text = "手动速度(mm/s)";
            // 
            // txt_GoHomeSpeed
            // 
            this.txt_GoHomeSpeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_GoHomeSpeed.Location = new System.Drawing.Point(179, 285);
            this.txt_GoHomeSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_GoHomeSpeed.Name = "txt_GoHomeSpeed";
            this.txt_GoHomeSpeed.Size = new System.Drawing.Size(181, 25);
            this.txt_GoHomeSpeed.TabIndex = 47;
            this.txt_GoHomeSpeed.Text = "1";
            this.txt_GoHomeSpeed.TextChanged += new System.EventHandler(this.txt_GoHomeSpeed_TextChanged);
            this.txt_GoHomeSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_GoHomeSpeed_KeyPress);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(35, 288);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 15);
            this.label10.TabIndex = 46;
            this.label10.Text = "搜原点速度(mm/s)";
            // 
            // comboBoxPlusFeed
            // 
            this.comboBoxPlusFeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxPlusFeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlusFeed.FormattingEnabled = true;
            this.comboBoxPlusFeed.Items.AddRange(new object[] {
            "10000",
            "1000",
            "5000",
            "4500",
            "2500",
            "2000",
            "1600",
            "1500",
            "100",
            "500",
            "10",
            "50",
            "1"});
            this.comboBoxPlusFeed.Location = new System.Drawing.Point(179, 386);
            this.comboBoxPlusFeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxPlusFeed.Name = "comboBoxPlusFeed";
            this.comboBoxPlusFeed.Size = new System.Drawing.Size(181, 23);
            this.comboBoxPlusFeed.TabIndex = 49;
            this.comboBoxPlusFeed.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlusFeed_SelectedIndexChanged);
            this.comboBoxPlusFeed.TextChanged += new System.EventHandler(this.comboBoxPlusFeed_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 386);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 15);
            this.label2.TabIndex = 48;
            this.label2.Text = "脉冲当量(Puls/mm)\r\n";
            // 
            // txt_Auto_Speed
            // 
            this.txt_Auto_Speed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Auto_Speed.Location = new System.Drawing.Point(179, 352);
            this.txt_Auto_Speed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Auto_Speed.Name = "txt_Auto_Speed";
            this.txt_Auto_Speed.Size = new System.Drawing.Size(181, 25);
            this.txt_Auto_Speed.TabIndex = 51;
            this.txt_Auto_Speed.Text = "1";
            this.txt_Auto_Speed.TextChanged += new System.EventHandler(this.txt_Auto_Speed_TextChanged);
            this.txt_Auto_Speed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Auto_Speed_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 354);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 50;
            this.label4.Text = "自动速度(mm/s)";
            // 
            // comboBox_BuildCorNum
            // 
            this.comboBox_BuildCorNum.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_BuildCorNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BuildCorNum.FormattingEnabled = true;
            this.comboBox_BuildCorNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_BuildCorNum.Location = new System.Drawing.Point(179, 456);
            this.comboBox_BuildCorNum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_BuildCorNum.Name = "comboBox_BuildCorNum";
            this.comboBox_BuildCorNum.Size = new System.Drawing.Size(181, 23);
            this.comboBox_BuildCorNum.TabIndex = 53;
            this.comboBox_BuildCorNum.SelectedIndexChanged += new System.EventHandler(this.comboBox_BuildCorNum_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 459);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 52;
            this.label5.Text = "坐标系编号";
            // 
            // 是否做测距轴
            // 
            this.是否做测距轴.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.是否做测距轴.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.是否做测距轴.FormattingEnabled = true;
            this.是否做测距轴.Items.AddRange(new object[] {
            "0",
            "1"});
            this.是否做测距轴.Location = new System.Drawing.Point(179, 491);
            this.是否做测距轴.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.是否做测距轴.Name = "是否做测距轴";
            this.是否做测距轴.Size = new System.Drawing.Size(181, 23);
            this.是否做测距轴.TabIndex = 55;
            this.是否做测距轴.SelectedIndexChanged += new System.EventHandler(this.是否做测距轴_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(69, 495);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 15);
            this.label11.TabIndex = 54;
            this.label11.Text = "是否做测距轴";
            // 
            // 是否做插补轴
            // 
            this.是否做插补轴.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.是否做插补轴.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.是否做插补轴.FormattingEnabled = true;
            this.是否做插补轴.Items.AddRange(new object[] {
            "0",
            "1"});
            this.是否做插补轴.Location = new System.Drawing.Point(179, 526);
            this.是否做插补轴.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.是否做插补轴.Name = "是否做插补轴";
            this.是否做插补轴.Size = new System.Drawing.Size(181, 23);
            this.是否做插补轴.TabIndex = 57;
            this.是否做插补轴.SelectedIndexChanged += new System.EventHandler(this.是否做插补轴_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(69, 530);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 15);
            this.label12.TabIndex = 56;
            this.label12.Text = "是否做插补轴";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.comboBox_salveAxis);
            this.groupBox1.Controls.Add(this.MainCardShow);
            this.groupBox1.Controls.Add(this.搜索限位速度);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.回原方式);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_ifDoubleAxis);
            this.groupBox1.Controls.Add(this.是否屏蔽);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.是否做插补轴);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.comboBoxCardNo);
            this.groupBox1.Controls.Add(this.是否做测距轴);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboBoxAxisNo);
            this.groupBox1.Controls.Add(this.comboBox_BuildCorNum);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_Acc);
            this.groupBox1.Controls.Add(this.txt_Auto_Speed);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_Dec);
            this.groupBox1.Controls.Add(this.comboBoxPlusFeed);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_Speed);
            this.groupBox1.Controls.Add(this.txt_GoHomeSpeed);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(199, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(499, 654);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "轴硬件设定";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(367, 104);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(107, 28);
            this.label16.TabIndex = 65;
            this.label16.Text = "GTN是核数";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainCardShow
            // 
            this.MainCardShow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MainCardShow.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainCardShow.Location = new System.Drawing.Point(95, 49);
            this.MainCardShow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MainCardShow.Name = "MainCardShow";
            this.MainCardShow.Size = new System.Drawing.Size(303, 29);
            this.MainCardShow.TabIndex = 64;
            this.MainCardShow.Text = "label16";
            this.MainCardShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 搜索限位速度
            // 
            this.搜索限位速度.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.搜索限位速度.Location = new System.Drawing.Point(179, 319);
            this.搜索限位速度.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.搜索限位速度.Name = "搜索限位速度";
            this.搜索限位速度.Size = new System.Drawing.Size(181, 25);
            this.搜索限位速度.TabIndex = 63;
            this.搜索限位速度.Text = "1";
            this.搜索限位速度.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.搜索限位速度.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.搜索限位速度_KeyPress);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(35, 321);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 15);
            this.label15.TabIndex = 62;
            this.label15.Text = "搜限位速度(mm/s)";
            // 
            // 回原方式
            // 
            this.回原方式.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.回原方式.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.回原方式.FormattingEnabled = true;
            this.回原方式.Items.AddRange(new object[] {
            "负限位回原",
            "正限位回原",
            "原点回原",
            "负限位回原走定距"});
            this.回原方式.Location = new System.Drawing.Point(179, 425);
            this.回原方式.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.回原方式.Name = "回原方式";
            this.回原方式.Size = new System.Drawing.Size(181, 23);
            this.回原方式.TabIndex = 61;
            this.回原方式.SelectedIndexChanged += new System.EventHandler(this.回原方式_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(98, 430);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 15);
            this.label14.TabIndex = 60;
            this.label14.Text = "回原方式";
            // 
            // 是否屏蔽
            // 
            this.是否屏蔽.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.是否屏蔽.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.是否屏蔽.FormattingEnabled = true;
            this.是否屏蔽.Items.AddRange(new object[] {
            "True",
            "False"});
            this.是否屏蔽.Location = new System.Drawing.Point(179, 559);
            this.是否屏蔽.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.是否屏蔽.Name = "是否屏蔽";
            this.是否屏蔽.Size = new System.Drawing.Size(181, 23);
            this.是否屏蔽.TabIndex = 57;
            this.是否屏蔽.SelectedIndexChanged += new System.EventHandler(this.是否屏蔽_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(99, 562);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 15);
            this.label13.TabIndex = 56;
            this.label13.Text = "是否屏蔽";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(128, 634);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 15);
            this.label18.TabIndex = 56;
            this.label18.Text = "从轴";
            // 
            // comboBox_salveAxis
            // 
            this.comboBox_salveAxis.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_salveAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_salveAxis.FormattingEnabled = true;
            this.comboBox_salveAxis.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox_salveAxis.Location = new System.Drawing.Point(179, 626);
            this.comboBox_salveAxis.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_salveAxis.Name = "comboBox_salveAxis";
            this.comboBox_salveAxis.Size = new System.Drawing.Size(181, 23);
            this.comboBox_salveAxis.TabIndex = 57;
            this.comboBox_salveAxis.SelectedIndexChanged += new System.EventHandler(this.comboBox_salveAxis_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(99, 597);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 15);
            this.label17.TabIndex = 56;
            this.label17.Text = "是否双驱";
            // 
            // comboBox_ifDoubleAxis
            // 
            this.comboBox_ifDoubleAxis.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox_ifDoubleAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ifDoubleAxis.FormattingEnabled = true;
            this.comboBox_ifDoubleAxis.Items.AddRange(new object[] {
            "True",
            "False"});
            this.comboBox_ifDoubleAxis.Location = new System.Drawing.Point(179, 594);
            this.comboBox_ifDoubleAxis.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_ifDoubleAxis.Name = "comboBox_ifDoubleAxis";
            this.comboBox_ifDoubleAxis.Size = new System.Drawing.Size(181, 23);
            this.comboBox_ifDoubleAxis.TabIndex = 57;
            this.comboBox_ifDoubleAxis.SelectedIndexChanged += new System.EventHandler(this.comboBox_ifDoubleAxis_SelectedIndexChanged);
            // 
            // FormAxisSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 674);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAxisSetting";
            this.Text = "是";
            this.Load += new System.EventHandler(this.FormAxisSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxCardNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxAxisNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Acc;
        private System.Windows.Forms.TextBox txt_Dec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Speed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_GoHomeSpeed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxPlusFeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Auto_Speed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_BuildCorNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox 是否做测距轴;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox 是否做插补轴;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox 是否屏蔽;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox 回原方式;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox 搜索限位速度;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label MainCardShow;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBox_salveAxis;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboBox_ifDoubleAxis;
        private System.Windows.Forms.Label label17;
    }
}