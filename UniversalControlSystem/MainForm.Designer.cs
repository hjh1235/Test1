namespace UniversalControlSystem
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerInit = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssUserPermissions = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel24 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssAssemblyFileVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel26 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssMemory = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel29 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssCPU = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Mes = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel21 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel20 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel13 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel19 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel18 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel17 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel16 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel15 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel14 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel12 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnStartForm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDefinedFlowForm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCCDForm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReportForm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSystemForm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnManageForm = new System.Windows.Forms.ToolStripSplitButton();
            this.登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tmrFoolProof = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.mesInterface1 = new UniversalControlSystem.WebReference.MESInterface();
            this.mesInterface2 = new UniversalControlSystem.WebReference.MESInterface();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerInit
            // 
            this.timerInit.Interval = 10;
            this.timerInit.Tick += new System.EventHandler(this.timerInit_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel7,
            this.tssUserPermissions,
            this.toolStripStatusLabel9,
            this.tssTime,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel24,
            this.tssAssemblyFileVersion,
            this.toolStripStatusLabel26,
            this.tssMemory,
            this.toolStripStatusLabel29,
            this.tssCPU,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel_Mes,
            this.toolStripStatusLabel21,
            this.toolStripStatusLabel20,
            this.toolStripStatusLabel13,
            this.toolStripStatusLabel19,
            this.toolStripStatusLabel18,
            this.toolStripStatusLabel17,
            this.toolStripStatusLabel16,
            this.toolStripStatusLabel15,
            this.toolStripStatusLabel8,
            this.toolStripStatusLabel14,
            this.toolStripStatusLabel12});
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1203, 32);
            this.statusStrip1.TabIndex = 520;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(35, 27);
            this.toolStripStatusLabel7.Text = "用户:";
            // 
            // tssUserPermissions
            // 
            this.tssUserPermissions.Name = "tssUserPermissions";
            this.tssUserPermissions.Size = new System.Drawing.Size(79, 27);
            this.tssUserPermissions.Text = "Aministrator";
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(28, 27);
            this.toolStripStatusLabel9.Text = "     ";
            // 
            // tssTime
            // 
            this.tssTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssTime.Name = "tssTime";
            this.tssTime.Size = new System.Drawing.Size(60, 27);
            this.tssTime.Text = "12:12:12";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 27);
            // 
            // toolStripStatusLabel24
            // 
            this.toolStripStatusLabel24.Name = "toolStripStatusLabel24";
            this.toolStripStatusLabel24.Size = new System.Drawing.Size(56, 27);
            this.toolStripStatusLabel24.Text = "版本号：";
            // 
            // tssAssemblyFileVersion
            // 
            this.tssAssemblyFileVersion.Name = "tssAssemblyFileVersion";
            this.tssAssemblyFileVersion.Size = new System.Drawing.Size(40, 27);
            this.tssAssemblyFileVersion.Text = "        ";
            // 
            // toolStripStatusLabel26
            // 
            this.toolStripStatusLabel26.Name = "toolStripStatusLabel26";
            this.toolStripStatusLabel26.Size = new System.Drawing.Size(35, 27);
            this.toolStripStatusLabel26.Text = "内存:";
            this.toolStripStatusLabel26.Visible = false;
            // 
            // tssMemory
            // 
            this.tssMemory.Name = "tssMemory";
            this.tssMemory.Size = new System.Drawing.Size(51, 27);
            this.tssMemory.Text = "1G1M  ";
            this.tssMemory.Visible = false;
            // 
            // toolStripStatusLabel29
            // 
            this.toolStripStatusLabel29.Name = "toolStripStatusLabel29";
            this.toolStripStatusLabel29.Size = new System.Drawing.Size(35, 27);
            this.toolStripStatusLabel29.Text = "CPU:";
            this.toolStripStatusLabel29.Visible = false;
            // 
            // tssCPU
            // 
            this.tssCPU.Name = "tssCPU";
            this.tssCPU.Size = new System.Drawing.Size(60, 27);
            this.tssCPU.Text = "100%     ";
            this.tssCPU.Visible = false;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.Green;
            this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 27);
            this.toolStripStatusLabel3.Text = "    门禁    ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.Color.Green;
            this.toolStripStatusLabel4.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(68, 27);
            this.toolStripStatusLabel4.Text = "    急停    ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Green;
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(68, 27);
            this.toolStripStatusLabel2.Text = "    光栅    ";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.BackColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel5.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(76, 27);
            this.toolStripStatusLabel5.Text = "  原点状态  ";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.BackColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel6.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(84, 27);
            this.toolStripStatusLabel6.Text = "激光器准备好";
            // 
            // toolStripStatusLabel_Mes
            // 
            this.toolStripStatusLabel_Mes.BackColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel_Mes.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel_Mes.Name = "toolStripStatusLabel_Mes";
            this.toolStripStatusLabel_Mes.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripStatusLabel_Mes.Size = new System.Drawing.Size(80, 27);
            this.toolStripStatusLabel_Mes.Text = "MES未连接";
            // 
            // toolStripStatusLabel21
            // 
            this.toolStripStatusLabel21.Name = "toolStripStatusLabel21";
            this.toolStripStatusLabel21.Size = new System.Drawing.Size(40, 27);
            this.toolStripStatusLabel21.Text = "        ";
            // 
            // toolStripStatusLabel20
            // 
            this.toolStripStatusLabel20.Name = "toolStripStatusLabel20";
            this.toolStripStatusLabel20.Size = new System.Drawing.Size(40, 27);
            this.toolStripStatusLabel20.Text = "        ";
            // 
            // toolStripStatusLabel13
            // 
            this.toolStripStatusLabel13.Name = "toolStripStatusLabel13";
            this.toolStripStatusLabel13.Size = new System.Drawing.Size(40, 27);
            this.toolStripStatusLabel13.Text = "        ";
            // 
            // toolStripStatusLabel19
            // 
            this.toolStripStatusLabel19.Name = "toolStripStatusLabel19";
            this.toolStripStatusLabel19.Size = new System.Drawing.Size(40, 27);
            this.toolStripStatusLabel19.Text = "        ";
            // 
            // toolStripStatusLabel18
            // 
            this.toolStripStatusLabel18.Name = "toolStripStatusLabel18";
            this.toolStripStatusLabel18.Size = new System.Drawing.Size(40, 27);
            this.toolStripStatusLabel18.Text = "        ";
            // 
            // toolStripStatusLabel17
            // 
            this.toolStripStatusLabel17.Name = "toolStripStatusLabel17";
            this.toolStripStatusLabel17.Size = new System.Drawing.Size(40, 27);
            this.toolStripStatusLabel17.Text = "        ";
            // 
            // toolStripStatusLabel16
            // 
            this.toolStripStatusLabel16.Name = "toolStripStatusLabel16";
            this.toolStripStatusLabel16.Size = new System.Drawing.Size(40, 27);
            this.toolStripStatusLabel16.Text = "        ";
            // 
            // toolStripStatusLabel15
            // 
            this.toolStripStatusLabel15.Name = "toolStripStatusLabel15";
            this.toolStripStatusLabel15.Size = new System.Drawing.Size(40, 27);
            this.toolStripStatusLabel15.Text = "        ";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(40, 27);
            this.toolStripStatusLabel8.Text = "        ";
            // 
            // toolStripStatusLabel14
            // 
            this.toolStripStatusLabel14.Name = "toolStripStatusLabel14";
            this.toolStripStatusLabel14.Size = new System.Drawing.Size(40, 27);
            this.toolStripStatusLabel14.Text = "        ";
            // 
            // toolStripStatusLabel12
            // 
            this.toolStripStatusLabel12.Name = "toolStripStatusLabel12";
            this.toolStripStatusLabel12.Size = new System.Drawing.Size(40, 27);
            this.toolStripStatusLabel12.Text = "        ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartForm,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.btnDefinedFlowForm,
            this.toolStripSeparator3,
            this.btnCCDForm,
            this.toolStripSeparator6,
            this.btnReportForm,
            this.toolStripSeparator8,
            this.btnSystemForm,
            this.toolStripSeparator5,
            this.btnManageForm,
            this.toolStripSeparator9,
            this.toolStripLabel2,
            this.toolStripSeparator10,
            this.btnExit,
            this.toolStripSeparator7,
            this.toolStripButton4,
            this.toolStripSeparator11,
            this.toolStripLabel3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1203, 60);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 519;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // btnStartForm
            // 
            this.btnStartForm.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnStartForm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStartForm.Image = ((System.Drawing.Image)(resources.GetObject("btnStartForm.Image")));
            this.btnStartForm.ImageTransparentColor = System.Drawing.Color.LightGray;
            this.btnStartForm.Name = "btnStartForm";
            this.btnStartForm.Size = new System.Drawing.Size(92, 57);
            this.btnStartForm.Text = "主界面";
            this.btnStartForm.Click += new System.EventHandler(this.btnStartForm_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 60);
            this.toolStripSeparator1.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::UniversalControlSystem.Properties.Resources.Product;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(78, 57);
            this.toolStripButton1.Text = "点位";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 60);
            this.toolStripSeparator2.Visible = false;
            // 
            // btnDefinedFlowForm
            // 
            this.btnDefinedFlowForm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDefinedFlowForm.Image = ((System.Drawing.Image)(resources.GetObject("btnDefinedFlowForm.Image")));
            this.btnDefinedFlowForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDefinedFlowForm.Name = "btnDefinedFlowForm";
            this.btnDefinedFlowForm.Size = new System.Drawing.Size(124, 57);
            this.btnDefinedFlowForm.Text = "自定义流程";
            this.btnDefinedFlowForm.Visible = false;
            this.btnDefinedFlowForm.Click += new System.EventHandler(this.btnDefinedFlowForm_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 60);
            this.toolStripSeparator3.Visible = false;
            // 
            // btnCCDForm
            // 
            this.btnCCDForm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCCDForm.Image = ((System.Drawing.Image)(resources.GetObject("btnCCDForm.Image")));
            this.btnCCDForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCCDForm.Name = "btnCCDForm";
            this.btnCCDForm.Size = new System.Drawing.Size(108, 57);
            this.btnCCDForm.Text = "视觉界面";
            this.btnCCDForm.Visible = false;
            this.btnCCDForm.Click += new System.EventHandler(this.btnCCDForm_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 60);
            // 
            // btnReportForm
            // 
            this.btnReportForm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReportForm.Image = ((System.Drawing.Image)(resources.GetObject("btnReportForm.Image")));
            this.btnReportForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportForm.Name = "btnReportForm";
            this.btnReportForm.Size = new System.Drawing.Size(108, 57);
            this.btnReportForm.Text = "数据追溯";
            this.btnReportForm.Visible = false;
            this.btnReportForm.Click += new System.EventHandler(this.btnReportForm_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 60);
            this.toolStripSeparator8.Visible = false;
            // 
            // btnSystemForm
            // 
            this.btnSystemForm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSystemForm.Image = ((System.Drawing.Image)(resources.GetObject("btnSystemForm.Image")));
            this.btnSystemForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSystemForm.Name = "btnSystemForm";
            this.btnSystemForm.Size = new System.Drawing.Size(108, 57);
            this.btnSystemForm.Text = "系统设置";
            this.btnSystemForm.Click += new System.EventHandler(this.btnSystemForm_ButtonClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 60);
            // 
            // btnManageForm
            // 
            this.btnManageForm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录ToolStripMenuItem,
            this.用户ToolStripMenuItem,
            this.注销ToolStripMenuItem});
            this.btnManageForm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnManageForm.Image = ((System.Drawing.Image)(resources.GetObject("btnManageForm.Image")));
            this.btnManageForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManageForm.Name = "btnManageForm";
            this.btnManageForm.Size = new System.Drawing.Size(120, 57);
            this.btnManageForm.Text = "用户管理";
            this.btnManageForm.ButtonClick += new System.EventHandler(this.btnManageForm_ButtonClick);
            // 
            // 登录ToolStripMenuItem
            // 
            this.登录ToolStripMenuItem.Name = "登录ToolStripMenuItem";
            this.登录ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.登录ToolStripMenuItem.Text = "登录";
            this.登录ToolStripMenuItem.Click += new System.EventHandler(this.登录ToolStripMenuItem_Click);
            // 
            // 用户ToolStripMenuItem
            // 
            this.用户ToolStripMenuItem.Name = "用户ToolStripMenuItem";
            this.用户ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.用户ToolStripMenuItem.Text = "用户";
            // 
            // 注销ToolStripMenuItem
            // 
            this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
            this.注销ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.注销ToolStripMenuItem.Text = "注销";
            this.注销ToolStripMenuItem.Click += new System.EventHandler(this.注销ToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 60);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.Blue;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(146, 57);
            this.toolStripLabel2.Text = "焊前极柱清洗F01B";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 60);
            // 
            // btnExit
            // 
            this.btnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(36, 57);
            this.btnExit.Text = "退出";
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 60);
            this.toolStripSeparator7.Visible = false;
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(33, 57);
            this.toolStripButton4.Text = "_";
            this.toolStripButton4.ToolTipText = "最小化";
            this.toolStripButton4.Visible = false;
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 60);
            this.toolStripSeparator11.Visible = false;
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(0, 57);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Gray;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1203, 600);
            this.panelMain.TabIndex = 521;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // tmrFoolProof
            // 
            this.tmrFoolProof.Interval = 1;
            this.tmrFoolProof.Tick += new System.EventHandler(this.tmrFoolProof_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // mesInterface1
            // 
            this.mesInterface1.Credentials = null;
            this.mesInterface1.Url = "http://10.160.88.101:8087/MESInterface.asmx";
            this.mesInterface1.UseDefaultCredentials = false;
            // 
            // mesInterface2
            // 
            this.mesInterface2.Credentials = null;
            this.mesInterface2.Url = "http://10.160.88.101:8087/MESInterface.asmx";
            this.mesInterface2.UseDefaultCredentials = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UniversalControlSystem.Properties.Resources.superstar;
            this.pictureBox1.Location = new System.Drawing.Point(1049, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 522;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 692);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主界面";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerInit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel tssUserPermissions;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.ToolStripStatusLabel tssTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel29;
        private System.Windows.Forms.ToolStripStatusLabel tssCPU;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel26;
        private System.Windows.Forms.ToolStripStatusLabel tssMemory;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel24;
        private System.Windows.Forms.ToolStripStatusLabel tssAssemblyFileVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel21;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel20;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel19;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel18;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel17;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel16;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel15;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel14;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel13;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel12;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Mes;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton btnStartForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCCDForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnReportForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnDefinedFlowForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSplitButton btnManageForm;
        private System.Windows.Forms.ToolStripMenuItem 登录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ToolStripButton btnSystemForm;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer tmrFoolProof;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private WebReference.MESInterface mesInterface1;
        private WebReference.MESInterface mesInterface2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
    }
}