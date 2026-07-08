namespace UniversalControlSystem
{
    partial class frm_AcqFifo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AcqFifo));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbxToolName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpenCamera = new System.Windows.Forms.Button();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.cebxGrab = new System.Windows.Forms.CheckBox();
            this.nudExposureTime = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxImgPath = new System.Windows.Forms.TextBox();
            this.btnSelectdir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetCamera = new System.Windows.Forms.Button();
            this.cebxUseImg = new System.Windows.Forms.CheckBox();
            this.cbxDevice = new System.Windows.Forms.ComboBox();
            this.cebkUseLoopImg = new System.Windows.Forms.CheckBox();
            this.cbxInterface = new System.Windows.Forms.ComboBox();
            this.btnSnapImage = new System.Windows.Forms.Button();
            this.btnGrapImage = new System.Windows.Forms.Button();
            this.lbxDevInfo = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRegisterImg = new System.Windows.Forms.Button();
            this.lbx_Image = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSure = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.步骤 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.步骤跳转 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.步骤结果 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.步骤用时 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.步骤类型 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.步骤号 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.步骤名字 = new System.Windows.Forms.TextBox();
            this.TOOLName = new System.Windows.Forms.Label();
            this.存入数据组 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.存入数据名 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExposureTime)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 13);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(520, 591);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage1.Controls.Add(this.tbxToolName);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.lbxDevInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(512, 562);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设置";
            // 
            // tbxToolName
            // 
            this.tbxToolName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxToolName.Location = new System.Drawing.Point(140, 10);
            this.tbxToolName.Margin = new System.Windows.Forms.Padding(4);
            this.tbxToolName.Name = "tbxToolName";
            this.tbxToolName.Size = new System.Drawing.Size(347, 30);
            this.tbxToolName.TabIndex = 26;
            this.tbxToolName.TextChanged += new System.EventHandler(this.tbx_toolName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "相机工具名：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpenCamera);
            this.groupBox1.Controls.Add(this.btnOpenImage);
            this.groupBox1.Controls.Add(this.cebxGrab);
            this.groupBox1.Controls.Add(this.nudExposureTime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbxImgPath);
            this.groupBox1.Controls.Add(this.btnSelectdir);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnGetCamera);
            this.groupBox1.Controls.Add(this.cebxUseImg);
            this.groupBox1.Controls.Add(this.cbxDevice);
            this.groupBox1.Controls.Add(this.cebkUseLoopImg);
            this.groupBox1.Controls.Add(this.cbxInterface);
            this.groupBox1.Controls.Add(this.btnSnapImage);
            this.groupBox1.Controls.Add(this.btnGrapImage);
            this.groupBox1.Location = new System.Drawing.Point(4, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(493, 271);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "相机设置";
            // 
            // btnOpenCamera
            // 
            this.btnOpenCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOpenCamera.Location = new System.Drawing.Point(29, 26);
            this.btnOpenCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenCamera.Name = "btnOpenCamera";
            this.btnOpenCamera.Size = new System.Drawing.Size(100, 40);
            this.btnOpenCamera.TabIndex = 33;
            this.btnOpenCamera.Text = "打开相机";
            this.btnOpenCamera.UseVisualStyleBackColor = false;
            this.btnOpenCamera.Click += new System.EventHandler(this.btnOpenCamera_Click);
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOpenImage.Location = new System.Drawing.Point(251, 162);
            this.btnOpenImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(232, 40);
            this.btnOpenImage.TabIndex = 32;
            this.btnOpenImage.Text = "打开图片";
            this.btnOpenImage.UseVisualStyleBackColor = false;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // cebxGrab
            // 
            this.cebxGrab.AutoSize = true;
            this.cebxGrab.Location = new System.Drawing.Point(359, 135);
            this.cebxGrab.Margin = new System.Windows.Forms.Padding(4);
            this.cebxGrab.Name = "cebxGrab";
            this.cebxGrab.Size = new System.Drawing.Size(89, 19);
            this.cebxGrab.TabIndex = 31;
            this.cebxGrab.Text = "同步采集";
            this.cebxGrab.UseVisualStyleBackColor = true;
            this.cebxGrab.CheckedChanged += new System.EventHandler(this.ceboxGrab_CheckedChanged);
            // 
            // nudExposureTime
            // 
            this.nudExposureTime.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudExposureTime.Location = new System.Drawing.Point(70, 243);
            this.nudExposureTime.Margin = new System.Windows.Forms.Padding(4);
            this.nudExposureTime.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudExposureTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudExposureTime.Name = "nudExposureTime";
            this.nudExposureTime.Size = new System.Drawing.Size(128, 25);
            this.nudExposureTime.TabIndex = 30;
            this.nudExposureTime.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.nudExposureTime.ValueChanged += new System.EventHandler(this.nudExposureTime_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 245);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "曝光：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "相机端口：";
            // 
            // tbxImgPath
            // 
            this.tbxImgPath.Location = new System.Drawing.Point(7, 210);
            this.tbxImgPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbxImgPath.Name = "tbxImgPath";
            this.tbxImgPath.Size = new System.Drawing.Size(476, 25);
            this.tbxImgPath.TabIndex = 20;
            // 
            // btnSelectdir
            // 
            this.btnSelectdir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSelectdir.Location = new System.Drawing.Point(7, 162);
            this.btnSelectdir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectdir.Name = "btnSelectdir";
            this.btnSelectdir.Size = new System.Drawing.Size(232, 40);
            this.btnSelectdir.TabIndex = 17;
            this.btnSelectdir.Text = "浏览文件夹";
            this.btnSelectdir.UseVisualStyleBackColor = false;
            this.btnSelectdir.Click += new System.EventHandler(this.btn_selectdir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "相机设备：";
            // 
            // btnGetCamera
            // 
            this.btnGetCamera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGetCamera.Location = new System.Drawing.Point(393, 87);
            this.btnGetCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetCamera.Name = "btnGetCamera";
            this.btnGetCamera.Size = new System.Drawing.Size(100, 40);
            this.btnGetCamera.TabIndex = 22;
            this.btnGetCamera.Text = "获取相机";
            this.btnGetCamera.UseVisualStyleBackColor = false;
            this.btnGetCamera.Click += new System.EventHandler(this.btn_getCamera_Click);
            // 
            // cebxUseImg
            // 
            this.cebxUseImg.AutoSize = true;
            this.cebxUseImg.Location = new System.Drawing.Point(10, 135);
            this.cebxUseImg.Margin = new System.Windows.Forms.Padding(4);
            this.cebxUseImg.Name = "cebxUseImg";
            this.cebxUseImg.Size = new System.Drawing.Size(119, 19);
            this.cebxUseImg.TabIndex = 19;
            this.cebxUseImg.Text = "使用本地图片";
            this.cebxUseImg.UseVisualStyleBackColor = true;
            this.cebxUseImg.CheckedChanged += new System.EventHandler(this.cek_boxUseImg_CheckedChanged);
            // 
            // cbxDevice
            // 
            this.cbxDevice.BackColor = System.Drawing.SystemColors.Info;
            this.cbxDevice.FormattingEnabled = true;
            this.cbxDevice.Location = new System.Drawing.Point(106, 99);
            this.cbxDevice.Margin = new System.Windows.Forms.Padding(4);
            this.cbxDevice.Name = "cbxDevice";
            this.cbxDevice.Size = new System.Drawing.Size(271, 23);
            this.cbxDevice.TabIndex = 18;
            this.cbxDevice.SelectedIndexChanged += new System.EventHandler(this.cbx_device_SelectedIndexChanged);
            // 
            // cebkUseLoopImg
            // 
            this.cebkUseLoopImg.AutoSize = true;
            this.cebkUseLoopImg.Location = new System.Drawing.Point(185, 135);
            this.cebkUseLoopImg.Margin = new System.Windows.Forms.Padding(4);
            this.cebkUseLoopImg.Name = "cebkUseLoopImg";
            this.cebkUseLoopImg.Size = new System.Drawing.Size(119, 19);
            this.cebkUseLoopImg.TabIndex = 21;
            this.cebkUseLoopImg.Text = "运行循环图片";
            this.cebkUseLoopImg.UseVisualStyleBackColor = true;
            this.cebkUseLoopImg.CheckedChanged += new System.EventHandler(this.cek_useLoopImg_CheckedChanged);
            // 
            // cbxInterface
            // 
            this.cbxInterface.BackColor = System.Drawing.SystemColors.Info;
            this.cbxInterface.FormattingEnabled = true;
            this.cbxInterface.Items.AddRange(new object[] {
            "",
            "GigEVision",
            "DahengCAM",
            "DirectShow",
            "pylon",
            "TWAIN",
            "1394IIDC",
            "ABS",
            "Andor",
            "Argos3D-P1xx",
            "BitFlow",
            "Crevis",
            "DirectFile",
            "Ensenso-NxLib",
            "File",
            "GenICamTL",
            "Ginga++",
            "GingaDG",
            "LinX",
            "LPS36",
            "LuCam",
            "MatrixVisionAcquire",
            "MILLite",
            "MultiCam",
            "Opteon",
            "PixeLINK",
            "SaperaLT",
            "Sentech",
            "ShapeDrive",
            "SICK-3DCamera",
            "SICK-ScanningRuler",
            "SiliconSoftware",
            "SwissRanger",
            "uEye",
            "USB3Vision",
            "VRmUsbCam"});
            this.cbxInterface.Location = new System.Drawing.Point(106, 73);
            this.cbxInterface.Margin = new System.Windows.Forms.Padding(4);
            this.cbxInterface.Name = "cbxInterface";
            this.cbxInterface.Size = new System.Drawing.Size(271, 23);
            this.cbxInterface.TabIndex = 15;
            this.cbxInterface.SelectedIndexChanged += new System.EventHandler(this.cbx_interface_SelectedIndexChanged);
            // 
            // btnSnapImage
            // 
            this.btnSnapImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSnapImage.Location = new System.Drawing.Point(277, 25);
            this.btnSnapImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSnapImage.Name = "btnSnapImage";
            this.btnSnapImage.Size = new System.Drawing.Size(100, 40);
            this.btnSnapImage.TabIndex = 13;
            this.btnSnapImage.Text = "采集一次";
            this.btnSnapImage.UseVisualStyleBackColor = false;
            this.btnSnapImage.Click += new System.EventHandler(this.btn_SnapImage_Click);
            // 
            // btnGrapImage
            // 
            this.btnGrapImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGrapImage.Location = new System.Drawing.Point(144, 25);
            this.btnGrapImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnGrapImage.Name = "btnGrapImage";
            this.btnGrapImage.Size = new System.Drawing.Size(100, 40);
            this.btnGrapImage.TabIndex = 14;
            this.btnGrapImage.Text = "连续采集";
            this.btnGrapImage.UseVisualStyleBackColor = false;
            this.btnGrapImage.Click += new System.EventHandler(this.btn_GrapImage_Click);
            // 
            // lbxDevInfo
            // 
            this.lbxDevInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxDevInfo.FormattingEnabled = true;
            this.lbxDevInfo.ItemHeight = 15;
            this.lbxDevInfo.Location = new System.Drawing.Point(4, 316);
            this.lbxDevInfo.Margin = new System.Windows.Forms.Padding(4);
            this.lbxDevInfo.Name = "lbxDevInfo";
            this.lbxDevInfo.Size = new System.Drawing.Size(500, 229);
            this.lbxDevInfo.TabIndex = 23;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage2.Controls.Add(this.btnRegisterImg);
            this.tabPage2.Controls.Add(this.lbx_Image);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(512, 562);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "本地图片";
            // 
            // btnRegisterImg
            // 
            this.btnRegisterImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRegisterImg.Location = new System.Drawing.Point(8, 654);
            this.btnRegisterImg.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegisterImg.Name = "btnRegisterImg";
            this.btnRegisterImg.Size = new System.Drawing.Size(124, 40);
            this.btnRegisterImg.TabIndex = 23;
            this.btnRegisterImg.Text = "注册当前图像";
            this.btnRegisterImg.UseVisualStyleBackColor = false;
            this.btnRegisterImg.Click += new System.EventHandler(this.btnRegisterImg_Click);
            // 
            // lbx_Image
            // 
            this.lbx_Image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbx_Image.BackColor = System.Drawing.Color.White;
            this.lbx_Image.FormattingEnabled = true;
            this.lbx_Image.ItemHeight = 15;
            this.lbx_Image.Location = new System.Drawing.Point(4, 8);
            this.lbx_Image.Margin = new System.Windows.Forms.Padding(4);
            this.lbx_Image.Name = "lbx_Image";
            this.lbx_Image.Size = new System.Drawing.Size(496, 514);
            this.lbx_Image.TabIndex = 0;
            this.lbx_Image.SelectedIndexChanged += new System.EventHandler(this.lbx_Image_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(432, 612);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSure.Location = new System.Drawing.Point(319, 612);
            this.btnSure.Margin = new System.Windows.Forms.Padding(4);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(100, 36);
            this.btnSure.TabIndex = 9;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btn_sure_Click);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRun.Location = new System.Drawing.Point(16, 612);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 36);
            this.btnRun.TabIndex = 8;
            this.btnRun.Text = "运行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTimer.Location = new System.Drawing.Point(127, 627);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(65, 18);
            this.lblTimer.TabIndex = 11;
            this.lblTimer.Text = "耗时：";
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Red;
            this.lblResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResult.Location = new System.Drawing.Point(259, 627);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(48, 18);
            this.lblResult.TabIndex = 25;
            this.lblResult.Text = "FAIL";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.hWindowControl1);
            this.panel1.Location = new System.Drawing.Point(539, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(556, 632);
            this.panel1.TabIndex = 27;
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(4, 1);
            this.hWindowControl1.Margin = new System.Windows.Forms.Padding(4);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(548, 627);
            this.hWindowControl1.TabIndex = 9;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(548, 627);
            // 
            // 步骤
            // 
            this.步骤.AutoSize = true;
            this.步骤.Location = new System.Drawing.Point(121, 17);
            this.步骤.Name = "步骤";
            this.步骤.Size = new System.Drawing.Size(37, 15);
            this.步骤.TabIndex = 412;
            this.步骤.Text = "步骤";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(218, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 411;
            this.label9.Text = "步骤跳转:";
            // 
            // 步骤跳转
            // 
            this.步骤跳转.Location = new System.Drawing.Point(299, 176);
            this.步骤跳转.Name = "步骤跳转";
            this.步骤跳转.Size = new System.Drawing.Size(200, 25);
            this.步骤跳转.TabIndex = 410;
            this.步骤跳转.Text = "-1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(218, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 409;
            this.label8.Text = "步骤结果:";
            // 
            // 步骤结果
            // 
            this.步骤结果.Location = new System.Drawing.Point(299, 145);
            this.步骤结果.Name = "步骤结果";
            this.步骤结果.ReadOnly = true;
            this.步骤结果.Size = new System.Drawing.Size(200, 25);
            this.步骤结果.TabIndex = 408;
            this.步骤结果.Text = "OK";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(218, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 407;
            this.label7.Text = "步骤用时:";
            // 
            // 步骤用时
            // 
            this.步骤用时.Location = new System.Drawing.Point(299, 114);
            this.步骤用时.Name = "步骤用时";
            this.步骤用时.ReadOnly = true;
            this.步骤用时.Size = new System.Drawing.Size(200, 25);
            this.步骤用时.TabIndex = 406;
            this.步骤用时.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 405;
            this.label3.Text = "步骤类型:";
            // 
            // 步骤类型
            // 
            this.步骤类型.Location = new System.Drawing.Point(299, 83);
            this.步骤类型.Name = "步骤类型";
            this.步骤类型.ReadOnly = true;
            this.步骤类型.Size = new System.Drawing.Size(200, 25);
            this.步骤类型.TabIndex = 404;
            this.步骤类型.Text = "A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 403;
            this.label5.Text = "步骤号:";
            // 
            // 步骤号
            // 
            this.步骤号.Location = new System.Drawing.Point(299, 54);
            this.步骤号.Name = "步骤号";
            this.步骤号.ReadOnly = true;
            this.步骤号.Size = new System.Drawing.Size(200, 25);
            this.步骤号.TabIndex = 402;
            this.步骤号.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(218, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 15);
            this.label10.TabIndex = 401;
            this.label10.Text = "步骤名字:";
            // 
            // 步骤名字
            // 
            this.步骤名字.Location = new System.Drawing.Point(299, 23);
            this.步骤名字.Name = "步骤名字";
            this.步骤名字.ReadOnly = true;
            this.步骤名字.Size = new System.Drawing.Size(200, 25);
            this.步骤名字.TabIndex = 400;
            this.步骤名字.Text = "A";
            // 
            // TOOLName
            // 
            this.TOOLName.AutoSize = true;
            this.TOOLName.Location = new System.Drawing.Point(19, 17);
            this.TOOLName.Name = "TOOLName";
            this.TOOLName.Size = new System.Drawing.Size(71, 15);
            this.TOOLName.TabIndex = 399;
            this.TOOLName.Text = "TOOLName";
            // 
            // 存入数据组
            // 
            this.存入数据组.FormattingEnabled = true;
            this.存入数据组.Location = new System.Drawing.Point(10, 78);
            this.存入数据组.Name = "存入数据组";
            this.存入数据组.Size = new System.Drawing.Size(202, 23);
            this.存入数据组.TabIndex = 429;
            this.存入数据组.SelectedIndexChanged += new System.EventHandler(this.存入数据组_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 15);
            this.label12.TabIndex = 428;
            this.label12.Text = "存入数据名:";
            // 
            // 存入数据名
            // 
            this.存入数据名.FormattingEnabled = true;
            this.存入数据名.Items.AddRange(new object[] {
            "接受",
            "清除缓存区"});
            this.存入数据名.Location = new System.Drawing.Point(10, 140);
            this.存入数据名.Name = "存入数据名";
            this.存入数据名.Size = new System.Drawing.Size(202, 23);
            this.存入数据名.TabIndex = 427;
            this.存入数据名.SelectedIndexChanged += new System.EventHandler(this.存入数据名_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 15);
            this.label11.TabIndex = 426;
            this.label11.Text = "存入数据组:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage3.Controls.Add(this.存入数据组);
            this.tabPage3.Controls.Add(this.步骤);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.TOOLName);
            this.tabPage3.Controls.Add(this.存入数据名);
            this.tabPage3.Controls.Add(this.步骤名字);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.步骤号);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.步骤跳转);
            this.tabPage3.Controls.Add(this.步骤类型);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.步骤结果);
            this.tabPage3.Controls.Add(this.步骤用时);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(512, 562);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "通用参数";
            // 
            // frm_AcqFifo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 656);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_AcqFifo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "采集图像";
            this.Load += new System.EventHandler(this.frm_AcqFifo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExposureTime)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lbx_Image;
        private System.Windows.Forms.ComboBox cbxDevice;
        private System.Windows.Forms.Button btnSelectdir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxInterface;
        private System.Windows.Forms.Button btnGrapImage;
        private System.Windows.Forms.Button btnSnapImage;
        private System.Windows.Forms.CheckBox cebkUseLoopImg;
        private System.Windows.Forms.TextBox tbxImgPath;
        private System.Windows.Forms.CheckBox cebxUseImg;
        private System.Windows.Forms.Button btnGetCamera;
        private System.Windows.Forms.ListBox lbxDevInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSure;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxToolName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTimer;
       // private ViewControl.HalconView halconView1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudExposureTime;
        private System.Windows.Forms.CheckBox cebxGrab;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.Button btnRegisterImg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label 步骤;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox 步骤跳转;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox 步骤结果;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox 步骤用时;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox 步骤类型;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox 步骤号;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox 步骤名字;
        private System.Windows.Forms.Label TOOLName;
        private System.Windows.Forms.ComboBox 存入数据组;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox 存入数据名;
        private System.Windows.Forms.Label label11;
        public HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.Button btnOpenCamera;
        private System.Windows.Forms.TabPage tabPage3;
    }
}