namespace UniversalControlSystem
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.com_区域选择 = new System.Windows.Forms.ComboBox();
            this.图片上传 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_MachineOrder = new CCWin.SkinControl.SkinTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_网址 = new CCWin.SkinControl.SkinTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.cb_SaveNamePassword = new System.Windows.Forms.CheckBox();
            this.cb_IgnoreMes = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_MachineNO = new CCWin.SkinControl.SkinTextBox();
            this.txt_Pos = new CCWin.SkinControl.SkinTextBox();
            this.btn_Login = new CCWin.SkinControl.SkinButton();
            this.txt_Password = new CCWin.SkinControl.SkinTextBox();
            this.txt_User = new CCWin.SkinControl.SkinTextBox();
            this.btn_Exit = new CCWin.SkinControl.SkinButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.skinPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.txt_MachineNO.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.skinPanel1.Controls.Add(this.com_区域选择);
            this.skinPanel1.Controls.Add(this.图片上传);
            this.skinPanel1.Controls.Add(this.label6);
            this.skinPanel1.Controls.Add(this.txt_MachineOrder);
            this.skinPanel1.Controls.Add(this.label2);
            this.skinPanel1.Controls.Add(this.label5);
            this.skinPanel1.Controls.Add(this.label4);
            this.skinPanel1.Controls.Add(this.txt_网址);
            this.skinPanel1.Controls.Add(this.label3);
            this.skinPanel1.Controls.Add(this.label1);
            this.skinPanel1.Controls.Add(this.skinLine1);
            this.skinPanel1.Controls.Add(this.cb_SaveNamePassword);
            this.skinPanel1.Controls.Add(this.cb_IgnoreMes);
            this.skinPanel1.Controls.Add(this.pictureBox1);
            this.skinPanel1.Controls.Add(this.txt_MachineNO);
            this.skinPanel1.Controls.Add(this.btn_Login);
            this.skinPanel1.Controls.Add(this.txt_Password);
            this.skinPanel1.Controls.Add(this.txt_User);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(84, 29);
            this.skinPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Radius = 40;
            this.skinPanel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinPanel1.Size = new System.Drawing.Size(519, 481);
            this.skinPanel1.TabIndex = 0;
            // 
            // com_区域选择
            // 
            this.com_区域选择.Font = new System.Drawing.Font("宋体", 11F);
            this.com_区域选择.FormattingEnabled = true;
            this.com_区域选择.Items.AddRange(new object[] {
            "南京一期",
            "南京二期",
            "惠州博罗",
            "惠州正豪",
            "南昌一期",
            "南昌二期",
            "深圳光明"});
            this.com_区域选择.Location = new System.Drawing.Point(129, 337);
            this.com_区域选择.Name = "com_区域选择";
            this.com_区域选择.Size = new System.Drawing.Size(247, 26);
            this.com_区域选择.TabIndex = 31;
            this.com_区域选择.SelectedIndexChanged += new System.EventHandler(this.com_区域选择_SelectedIndexChanged);
            // 
            // 图片上传
            // 
            this.图片上传.AutoSize = true;
            this.图片上传.Location = new System.Drawing.Point(345, 394);
            this.图片上传.Margin = new System.Windows.Forms.Padding(4);
            this.图片上传.Name = "图片上传";
            this.图片上传.Size = new System.Drawing.Size(89, 19);
            this.图片上传.TabIndex = 29;
            this.图片上传.Text = "图片上传";
            this.图片上传.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 251);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "生产制令单：";
            // 
            // txt_MachineOrder
            // 
            this.txt_MachineOrder.BackColor = System.Drawing.Color.Transparent;
            this.txt_MachineOrder.DownBack = null;
            this.txt_MachineOrder.Icon = null;
            this.txt_MachineOrder.IconIsButton = false;
            this.txt_MachineOrder.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_MachineOrder.IsPasswordChat = '\0';
            this.txt_MachineOrder.IsSystemPasswordChar = false;
            this.txt_MachineOrder.Lines = new string[0];
            this.txt_MachineOrder.Location = new System.Drawing.Point(129, 241);
            this.txt_MachineOrder.Margin = new System.Windows.Forms.Padding(0);
            this.txt_MachineOrder.MaxLength = 32767;
            this.txt_MachineOrder.MinimumSize = new System.Drawing.Size(37, 35);
            this.txt_MachineOrder.MouseBack = null;
            this.txt_MachineOrder.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_MachineOrder.Multiline = true;
            this.txt_MachineOrder.Name = "txt_MachineOrder";
            this.txt_MachineOrder.NormlBack = null;
            this.txt_MachineOrder.Padding = new System.Windows.Forms.Padding(7, 6, 68, 6);
            this.txt_MachineOrder.ReadOnly = false;
            this.txt_MachineOrder.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_MachineOrder.Size = new System.Drawing.Size(247, 35);
            // 
            // 
            // 
            this.txt_MachineOrder.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_MachineOrder.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_MachineOrder.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txt_MachineOrder.SkinTxt.Location = new System.Drawing.Point(7, 6);
            this.txt_MachineOrder.SkinTxt.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MachineOrder.SkinTxt.Multiline = true;
            this.txt_MachineOrder.SkinTxt.Name = "BaseText";
            this.txt_MachineOrder.SkinTxt.Size = new System.Drawing.Size(172, 23);
            this.txt_MachineOrder.SkinTxt.TabIndex = 0;
            this.txt_MachineOrder.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_MachineOrder.SkinTxt.WaterText = "生产制令单";
            this.txt_MachineOrder.TabIndex = 11;
            this.txt_MachineOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_MachineOrder.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_MachineOrder.WaterText = "生产制令单";
            this.txt_MachineOrder.WordWrap = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 342);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "区域：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 296);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "网址：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "密码：";
            // 
            // txt_网址
            // 
            this.txt_网址.BackColor = System.Drawing.Color.Transparent;
            this.txt_网址.DownBack = null;
            this.txt_网址.Icon = null;
            this.txt_网址.IconIsButton = false;
            this.txt_网址.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_网址.IsPasswordChat = '\0';
            this.txt_网址.IsSystemPasswordChar = false;
            this.txt_网址.Lines = new string[0];
            this.txt_网址.Location = new System.Drawing.Point(129, 286);
            this.txt_网址.Margin = new System.Windows.Forms.Padding(0);
            this.txt_网址.MaxLength = 32767;
            this.txt_网址.MinimumSize = new System.Drawing.Size(37, 35);
            this.txt_网址.MouseBack = null;
            this.txt_网址.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_网址.Multiline = true;
            this.txt_网址.Name = "txt_网址";
            this.txt_网址.NormlBack = null;
            this.txt_网址.Padding = new System.Windows.Forms.Padding(7, 6, 68, 6);
            this.txt_网址.ReadOnly = false;
            this.txt_网址.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_网址.Size = new System.Drawing.Size(247, 35);
            // 
            // 
            // 
            this.txt_网址.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_网址.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_网址.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txt_网址.SkinTxt.Location = new System.Drawing.Point(7, 6);
            this.txt_网址.SkinTxt.Margin = new System.Windows.Forms.Padding(4);
            this.txt_网址.SkinTxt.Multiline = true;
            this.txt_网址.SkinTxt.Name = "BaseText";
            this.txt_网址.SkinTxt.Size = new System.Drawing.Size(172, 23);
            this.txt_网址.SkinTxt.TabIndex = 0;
            this.txt_网址.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_网址.SkinTxt.WaterText = "网址";
            this.txt_网址.TabIndex = 10;
            this.txt_网址.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_网址.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_网址.WaterText = "网址";
            this.txt_网址.WordWrap = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "用户名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 208);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "设备编号：";
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.Black;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(129, 370);
            this.skinLine1.Margin = new System.Windows.Forms.Padding(4);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(247, 18);
            this.skinLine1.TabIndex = 14;
            this.skinLine1.Text = "skinLine1";
            // 
            // cb_SaveNamePassword
            // 
            this.cb_SaveNamePassword.AutoSize = true;
            this.cb_SaveNamePassword.Location = new System.Drawing.Point(81, 396);
            this.cb_SaveNamePassword.Margin = new System.Windows.Forms.Padding(4);
            this.cb_SaveNamePassword.Name = "cb_SaveNamePassword";
            this.cb_SaveNamePassword.Size = new System.Drawing.Size(134, 19);
            this.cb_SaveNamePassword.TabIndex = 12;
            this.cb_SaveNamePassword.Text = "记住用户名密码";
            this.cb_SaveNamePassword.UseVisualStyleBackColor = true;
            this.cb_SaveNamePassword.CheckedChanged += new System.EventHandler(this.cb_SaveNamePassword_CheckedChanged);
            // 
            // cb_IgnoreMes
            // 
            this.cb_IgnoreMes.AutoSize = true;
            this.cb_IgnoreMes.Location = new System.Drawing.Point(233, 394);
            this.cb_IgnoreMes.Margin = new System.Windows.Forms.Padding(4);
            this.cb_IgnoreMes.Name = "cb_IgnoreMes";
            this.cb_IgnoreMes.Size = new System.Drawing.Size(98, 19);
            this.cb_IgnoreMes.TabIndex = 11;
            this.cb_IgnoreMes.Text = "不连接MES";
            this.cb_IgnoreMes.UseVisualStyleBackColor = true;
            this.cb_IgnoreMes.CheckedChanged += new System.EventHandler(this.cb_IgnoreMes_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::UniversalControlSystem.Properties.Resources._12获;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::UniversalControlSystem.Properties.Resources.superstar;
            this.pictureBox1.Location = new System.Drawing.Point(129, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // txt_MachineNO
            // 
            this.txt_MachineNO.BackColor = System.Drawing.Color.Transparent;
            this.txt_MachineNO.Controls.Add(this.txt_Pos);
            this.txt_MachineNO.DownBack = null;
            this.txt_MachineNO.Icon = null;
            this.txt_MachineNO.IconIsButton = false;
            this.txt_MachineNO.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_MachineNO.IsPasswordChat = '\0';
            this.txt_MachineNO.IsSystemPasswordChar = false;
            this.txt_MachineNO.Lines = new string[0];
            this.txt_MachineNO.Location = new System.Drawing.Point(129, 196);
            this.txt_MachineNO.Margin = new System.Windows.Forms.Padding(0);
            this.txt_MachineNO.MaxLength = 32767;
            this.txt_MachineNO.MinimumSize = new System.Drawing.Size(37, 35);
            this.txt_MachineNO.MouseBack = null;
            this.txt_MachineNO.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_MachineNO.Multiline = true;
            this.txt_MachineNO.Name = "txt_MachineNO";
            this.txt_MachineNO.NormlBack = null;
            this.txt_MachineNO.Padding = new System.Windows.Forms.Padding(7, 6, 68, 6);
            this.txt_MachineNO.ReadOnly = false;
            this.txt_MachineNO.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_MachineNO.Size = new System.Drawing.Size(247, 35);
            // 
            // 
            // 
            this.txt_MachineNO.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_MachineNO.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_MachineNO.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txt_MachineNO.SkinTxt.Location = new System.Drawing.Point(7, 6);
            this.txt_MachineNO.SkinTxt.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MachineNO.SkinTxt.Multiline = true;
            this.txt_MachineNO.SkinTxt.Name = "BaseText";
            this.txt_MachineNO.SkinTxt.Size = new System.Drawing.Size(172, 23);
            this.txt_MachineNO.SkinTxt.TabIndex = 0;
            this.txt_MachineNO.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_MachineNO.SkinTxt.WaterText = "设备编号";
            this.txt_MachineNO.TabIndex = 9;
            this.txt_MachineNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_MachineNO.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_MachineNO.WaterText = "设备编号";
            this.txt_MachineNO.WordWrap = true;
            // 
            // txt_Pos
            // 
            this.txt_Pos.BackColor = System.Drawing.Color.Transparent;
            this.txt_Pos.DownBack = null;
            this.txt_Pos.Icon = null;
            this.txt_Pos.IconIsButton = false;
            this.txt_Pos.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_Pos.IsPasswordChat = '\0';
            this.txt_Pos.IsSystemPasswordChar = false;
            this.txt_Pos.Lines = new string[0];
            this.txt_Pos.Location = new System.Drawing.Point(191, 35);
            this.txt_Pos.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Pos.MaxLength = 32767;
            this.txt_Pos.MinimumSize = new System.Drawing.Size(37, 35);
            this.txt_Pos.MouseBack = null;
            this.txt_Pos.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_Pos.Multiline = true;
            this.txt_Pos.Name = "txt_Pos";
            this.txt_Pos.NormlBack = null;
            this.txt_Pos.Padding = new System.Windows.Forms.Padding(7, 6, 68, 6);
            this.txt_Pos.ReadOnly = false;
            this.txt_Pos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Pos.Size = new System.Drawing.Size(247, 35);
            // 
            // 
            // 
            this.txt_Pos.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Pos.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Pos.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txt_Pos.SkinTxt.Location = new System.Drawing.Point(7, 6);
            this.txt_Pos.SkinTxt.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Pos.SkinTxt.Multiline = true;
            this.txt_Pos.SkinTxt.Name = "BaseText";
            this.txt_Pos.SkinTxt.Size = new System.Drawing.Size(172, 23);
            this.txt_Pos.SkinTxt.TabIndex = 0;
            this.txt_Pos.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_Pos.SkinTxt.WaterText = "网址";
            this.txt_Pos.TabIndex = 10;
            this.txt_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Pos.Visible = false;
            this.txt_Pos.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_Pos.WaterText = "网址";
            this.txt_Pos.WordWrap = true;
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.Transparent;
            this.btn_Login.BaseColor = System.Drawing.Color.DodgerBlue;
            this.btn_Login.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Login.DownBack = null;
            this.btn_Login.FadeGlow = false;
            this.btn_Login.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(129, 423);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Login.MouseBack = null;
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.NormlBack = null;
            this.btn_Login.Radius = 20;
            this.btn_Login.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btn_Login.Size = new System.Drawing.Size(247, 45);
            this.btn_Login.TabIndex = 10;
            this.btn_Login.Text = "登录";
            this.btn_Login.UseCompatibleTextRendering = true;
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.Color.Transparent;
            this.txt_Password.DownBack = null;
            this.txt_Password.Icon = null;
            this.txt_Password.IconIsButton = false;
            this.txt_Password.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_Password.IsPasswordChat = '\0';
            this.txt_Password.IsSystemPasswordChar = true;
            this.txt_Password.Lines = new string[0];
            this.txt_Password.Location = new System.Drawing.Point(129, 152);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Password.MaxLength = 32767;
            this.txt_Password.MinimumSize = new System.Drawing.Size(37, 35);
            this.txt_Password.MouseBack = null;
            this.txt_Password.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_Password.Multiline = true;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.NormlBack = null;
            this.txt_Password.Padding = new System.Windows.Forms.Padding(7, 6, 68, 6);
            this.txt_Password.ReadOnly = false;
            this.txt_Password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_Password.Size = new System.Drawing.Size(247, 35);
            // 
            // 
            // 
            this.txt_Password.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Password.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Password.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txt_Password.SkinTxt.Location = new System.Drawing.Point(7, 6);
            this.txt_Password.SkinTxt.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Password.SkinTxt.Multiline = true;
            this.txt_Password.SkinTxt.Name = "BaseText";
            this.txt_Password.SkinTxt.Size = new System.Drawing.Size(172, 23);
            this.txt_Password.SkinTxt.TabIndex = 0;
            this.txt_Password.SkinTxt.UseSystemPasswordChar = true;
            this.txt_Password.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_Password.SkinTxt.WaterText = "密码";
            this.txt_Password.TabIndex = 8;
            this.txt_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_Password.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_Password.WaterText = "密码";
            this.txt_Password.WordWrap = true;
            // 
            // txt_User
            // 
            this.txt_User.BackColor = System.Drawing.Color.Transparent;
            this.txt_User.DownBack = null;
            this.txt_User.Icon = null;
            this.txt_User.IconIsButton = false;
            this.txt_User.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_User.IsPasswordChat = '\0';
            this.txt_User.IsSystemPasswordChar = false;
            this.txt_User.Lines = new string[0];
            this.txt_User.Location = new System.Drawing.Point(129, 106);
            this.txt_User.Margin = new System.Windows.Forms.Padding(0);
            this.txt_User.MaxLength = 32767;
            this.txt_User.MinimumSize = new System.Drawing.Size(37, 35);
            this.txt_User.MouseBack = null;
            this.txt_User.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txt_User.Multiline = true;
            this.txt_User.Name = "txt_User";
            this.txt_User.NormlBack = null;
            this.txt_User.Padding = new System.Windows.Forms.Padding(7, 6, 68, 6);
            this.txt_User.ReadOnly = false;
            this.txt_User.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txt_User.Size = new System.Drawing.Size(247, 35);
            // 
            // 
            // 
            this.txt_User.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_User.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_User.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txt_User.SkinTxt.Location = new System.Drawing.Point(7, 6);
            this.txt_User.SkinTxt.Margin = new System.Windows.Forms.Padding(4);
            this.txt_User.SkinTxt.Multiline = true;
            this.txt_User.SkinTxt.Name = "BaseText";
            this.txt_User.SkinTxt.Size = new System.Drawing.Size(172, 23);
            this.txt_User.SkinTxt.TabIndex = 0;
            this.txt_User.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_User.SkinTxt.WaterText = "用户名";
            this.txt_User.TabIndex = 7;
            this.txt_User.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_User.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txt_User.WaterText = "用户名";
            this.txt_User.WordWrap = true;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Exit.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Exit.BorderColor = System.Drawing.Color.Transparent;
            this.btn_Exit.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Exit.DownBack = null;
            this.btn_Exit.FadeGlow = false;
            this.btn_Exit.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Exit.ForeColor = System.Drawing.Color.White;
            this.btn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.Image")));
            this.btn_Exit.Location = new System.Drawing.Point(611, 15);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Exit.MouseBack = null;
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.NormlBack = null;
            this.btn_Exit.Radius = 20;
            this.btn_Exit.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btn_Exit.Size = new System.Drawing.Size(41, 35);
            this.btn_Exit.TabIndex = 11;
            this.btn_Exit.UseCompatibleTextRendering = true;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkTurquoise;
            this.ClientSize = new System.Drawing.Size(677, 541);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.skinPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.txt_MachineNO.ResumeLayout(false);
            this.txt_MachineNO.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinTextBox txt_MachineNO;
        private CCWin.SkinControl.SkinButton btn_Login;
        private CCWin.SkinControl.SkinTextBox txt_Password;
        private CCWin.SkinControl.SkinButton btn_Exit;
        private CCWin.SkinControl.SkinTextBox txt_网址;
        private System.Windows.Forms.CheckBox cb_IgnoreMes;
        private System.Windows.Forms.CheckBox cb_SaveNamePassword;
        private CCWin.SkinControl.SkinTextBox txt_User;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinLine skinLine1;
        private CCWin.SkinControl.SkinTextBox txt_MachineOrder;
        private CCWin.SkinControl.SkinTextBox txt_Pos;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox 图片上传;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox com_区域选择;
    }
}