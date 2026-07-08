using Controls;
namespace VMPro
{
    partial class Frm_AcqImageTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_AcqImageTool));
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.hWindow_Final1 = new ChoiceTech.Halcon.Control.HWindow_Final();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.适应图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.相机实时ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全屏ESC退出全屏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ckb_updateImage = new Controls.CCheckBox();
            this.nud_rotateAngle = new Controls.CNumericUpDown();
            this.ckb_hardTrig = new Controls.CCheckBox();
            this.ckb_rotateImage = new Controls.CCheckBox();
            this.ckb_RGBToGray = new Controls.CCheckBox();
            this.ckb_allImageRegion = new Controls.CCheckBox();
            this.ckb_autoSwitch = new Controls.CCheckBox();
            this.ckb_absPath = new Controls.CCheckBox();
            this.lbl_deg = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pic_fromDirectory = new System.Windows.Forms.PictureBox();
            this.rdo_fromDirectory = new System.Windows.Forms.RadioButton();
            this.pic_fromFile = new System.Windows.Forms.PictureBox();
            this.pic_fromDevice = new System.Windows.Forms.PictureBox();
            this.rdo_fromFile = new System.Windows.Forms.RadioButton();
            this.rdo_fromDevice = new System.Windows.Forms.RadioButton();
            this.pnl_formPanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_close = new Sunny.UI.UIButton();
            this.btn_runJob = new Sunny.UI.UIButton();
            this.btn_runTool = new Sunny.UI.UIButton();
            this.lbl_runTime = new System.Windows.Forms.Label();
            this.lbl_toolTip = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_livePlay = new System.Windows.Forms.ToolStripButton();
            this.tsb_saveImage = new System.Windows.Forms.ToolStripButton();
            this.tsb_SDKInfo = new System.Windows.Forms.ToolStripButton();
            this.tsb_resetTool = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_fromDirectory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_fromFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_fromDevice)).BeginInit();
            this.panel6.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 5);
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            // 
            // btn_topLevel
            // 
            this.btn_topLevel.FlatAppearance.BorderSize = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Location = new System.Drawing.Point(2, 26);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(903, 564);
            this.panel3.TabIndex = 117;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(903, 564);
            this.tableLayoutPanel1.TabIndex = 115;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 278F));
            this.tableLayoutPanel2.Controls.Add(this.hWindow_Final1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 468F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(897, 468);
            this.tableLayoutPanel2.TabIndex = 89;
            // 
            // hWindow_Final1
            // 
            this.hWindow_Final1.BackColor = System.Drawing.Color.Transparent;
            this.hWindow_Final1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hWindow_Final1.ContextMenuStrip = this.contextMenuStrip1;
            this.hWindow_Final1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hWindow_Final1.DrawModel = false;
            this.hWindow_Final1.EditModel = true;
            this.hWindow_Final1.Image = null;
            this.hWindow_Final1.Location = new System.Drawing.Point(3, 4);
            this.hWindow_Final1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hWindow_Final1.Name = "hWindow_Final1";
            this.hWindow_Final1.Size = new System.Drawing.Size(613, 460);
            this.hWindow_Final1.TabIndex = 90;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.适应图像ToolStripMenuItem,
            this.相机实时ToolStripMenuItem,
            this.图像信息ToolStripMenuItem,
            this.全屏ESC退出全屏ToolStripMenuItem,
            this.保存图像ToolStripMenuItem});
            this.contextMenuStrip1.Name = "cnt_rightClickMenu";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 114);
            // 
            // 适应图像ToolStripMenuItem
            // 
            this.适应图像ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.适应图像ToolStripMenuItem.Name = "适应图像ToolStripMenuItem";
            this.适应图像ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.适应图像ToolStripMenuItem.Text = "适应窗口";
            this.适应图像ToolStripMenuItem.Click += new System.EventHandler(this.适应图像ToolStripMenuItem_Click);
            // 
            // 相机实时ToolStripMenuItem
            // 
            this.相机实时ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.相机实时ToolStripMenuItem.CheckOnClick = true;
            this.相机实时ToolStripMenuItem.Name = "相机实时ToolStripMenuItem";
            this.相机实时ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.相机实时ToolStripMenuItem.Text = "相机实时";
            this.相机实时ToolStripMenuItem.Click += new System.EventHandler(this.相机实时ToolStripMenuItem_Click);
            // 
            // 图像信息ToolStripMenuItem
            // 
            this.图像信息ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.图像信息ToolStripMenuItem.CheckOnClick = true;
            this.图像信息ToolStripMenuItem.Name = "图像信息ToolStripMenuItem";
            this.图像信息ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.图像信息ToolStripMenuItem.Text = "图像信息";
            this.图像信息ToolStripMenuItem.Click += new System.EventHandler(this.图像信息ToolStripMenuItem_Click);
            // 
            // 全屏ESC退出全屏ToolStripMenuItem
            // 
            this.全屏ESC退出全屏ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.全屏ESC退出全屏ToolStripMenuItem.CheckOnClick = true;
            this.全屏ESC退出全屏ToolStripMenuItem.Name = "全屏ESC退出全屏ToolStripMenuItem";
            this.全屏ESC退出全屏ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.全屏ESC退出全屏ToolStripMenuItem.Text = "全屏（ESC退出全屏）";
            this.全屏ESC退出全屏ToolStripMenuItem.Click += new System.EventHandler(this.全屏ESC退出全屏ToolStripMenuItem_Click);
            // 
            // 保存图像ToolStripMenuItem
            // 
            this.保存图像ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.保存图像ToolStripMenuItem.Name = "保存图像ToolStripMenuItem";
            this.保存图像ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.保存图像ToolStripMenuItem.Text = "保存图像";
            this.保存图像ToolStripMenuItem.Click += new System.EventHandler(this.保存图像ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckb_updateImage);
            this.panel2.Controls.Add(this.nud_rotateAngle);
            this.panel2.Controls.Add(this.ckb_hardTrig);
            this.panel2.Controls.Add(this.ckb_rotateImage);
            this.panel2.Controls.Add(this.ckb_RGBToGray);
            this.panel2.Controls.Add(this.ckb_allImageRegion);
            this.panel2.Controls.Add(this.ckb_autoSwitch);
            this.panel2.Controls.Add(this.ckb_absPath);
            this.panel2.Controls.Add(this.lbl_deg);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.pic_fromDirectory);
            this.panel2.Controls.Add(this.rdo_fromDirectory);
            this.panel2.Controls.Add(this.pic_fromFile);
            this.panel2.Controls.Add(this.pic_fromDevice);
            this.panel2.Controls.Add(this.rdo_fromFile);
            this.panel2.Controls.Add(this.rdo_fromDevice);
            this.panel2.Controls.Add(this.pnl_formPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(621, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 462);
            this.panel2.TabIndex = 89;
            // 
            // ckb_updateImage
            // 
            this.ckb_updateImage.BackColor = System.Drawing.Color.White;
            this.ckb_updateImage.Checked = true;
            this.ckb_updateImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_updateImage.Location = new System.Drawing.Point(4, 412);
            this.ckb_updateImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_updateImage.Name = "ckb_updateImage";
            this.ckb_updateImage.Size = new System.Drawing.Size(139, 20);
            this.ckb_updateImage.TabIndex = 128;
            this.ckb_updateImage.TextStr = "刷新图像";
            this.ckb_updateImage.CheckChanged += new Controls.DCheckChanged(this.ckb_updateImage_CheckChanged);
            // 
            // nud_rotateAngle
            // 
            this.nud_rotateAngle.BackColor = System.Drawing.Color.White;
            this.nud_rotateAngle.DecimalPlaces = 0;
            this.nud_rotateAngle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_rotateAngle.Incremeent = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nud_rotateAngle.Location = new System.Drawing.Point(87, 435);
            this.nud_rotateAngle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_rotateAngle.MaximumSize = new System.Drawing.Size(300, 28);
            this.nud_rotateAngle.MaxValue = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nud_rotateAngle.MinimumSize = new System.Drawing.Size(100, 28);
            this.nud_rotateAngle.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_rotateAngle.Name = "nud_rotateAngle";
            this.nud_rotateAngle.Size = new System.Drawing.Size(100, 28);
            this.nud_rotateAngle.TabIndex = 0;
            this.nud_rotateAngle.Value = 0D;
            this.nud_rotateAngle.Visible = false;
            this.nud_rotateAngle.ValueChanged += new Controls.DValueChanged(this.nud_rotateAngle_ValueChanged);
            // 
            // ckb_hardTrig
            // 
            this.ckb_hardTrig.BackColor = System.Drawing.Color.White;
            this.ckb_hardTrig.Checked = true;
            this.ckb_hardTrig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_hardTrig.Location = new System.Drawing.Point(4, 292);
            this.ckb_hardTrig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_hardTrig.Name = "ckb_hardTrig";
            this.ckb_hardTrig.Size = new System.Drawing.Size(212, 20);
            this.ckb_hardTrig.TabIndex = 125;
            this.ckb_hardTrig.TextStr = "勾选：硬触发 | 不勾选：软触发";
            this.ckb_hardTrig.CheckChanged += new Controls.DCheckChanged(this.ckb_hardTrig_CheckChanged);
            // 
            // ckb_rotateImage
            // 
            this.ckb_rotateImage.BackColor = System.Drawing.Color.White;
            this.ckb_rotateImage.Checked = false;
            this.ckb_rotateImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_rotateImage.Location = new System.Drawing.Point(4, 436);
            this.ckb_rotateImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_rotateImage.Name = "ckb_rotateImage";
            this.ckb_rotateImage.Size = new System.Drawing.Size(90, 20);
            this.ckb_rotateImage.TabIndex = 127;
            this.ckb_rotateImage.TextStr = "旋转图像";
            this.ckb_rotateImage.CheckChanged += new Controls.DCheckChanged(this.ckb_rotateImage_CheckChanged);
            // 
            // ckb_RGBToGray
            // 
            this.ckb_RGBToGray.BackColor = System.Drawing.Color.White;
            this.ckb_RGBToGray.Checked = true;
            this.ckb_RGBToGray.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_RGBToGray.Location = new System.Drawing.Point(4, 364);
            this.ckb_RGBToGray.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_RGBToGray.Name = "ckb_RGBToGray";
            this.ckb_RGBToGray.Size = new System.Drawing.Size(111, 20);
            this.ckb_RGBToGray.TabIndex = 126;
            this.ckb_RGBToGray.TextStr = "彩图转灰度图";
            this.ckb_RGBToGray.CheckChanged += new Controls.DCheckChanged(this.ckb_RGBToGray_CheckChanged);
            // 
            // ckb_allImageRegion
            // 
            this.ckb_allImageRegion.BackColor = System.Drawing.Color.White;
            this.ckb_allImageRegion.Checked = true;
            this.ckb_allImageRegion.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_allImageRegion.Location = new System.Drawing.Point(4, 388);
            this.ckb_allImageRegion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_allImageRegion.Name = "ckb_allImageRegion";
            this.ckb_allImageRegion.Size = new System.Drawing.Size(139, 20);
            this.ckb_allImageRegion.TabIndex = 125;
            this.ckb_allImageRegion.TextStr = "显示整幅图像";
            this.ckb_allImageRegion.CheckChanged += new Controls.DCheckChanged(this.ckb_allImageRegion_CheckChanged);
            // 
            // ckb_autoSwitch
            // 
            this.ckb_autoSwitch.BackColor = System.Drawing.Color.White;
            this.ckb_autoSwitch.Checked = true;
            this.ckb_autoSwitch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_autoSwitch.Location = new System.Drawing.Point(4, 316);
            this.ckb_autoSwitch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_autoSwitch.Name = "ckb_autoSwitch";
            this.ckb_autoSwitch.Size = new System.Drawing.Size(111, 20);
            this.ckb_autoSwitch.TabIndex = 124;
            this.ckb_autoSwitch.TextStr = "自动切换";
            this.ckb_autoSwitch.CheckChanged += new Controls.DCheckChanged(this.ckb_autoSwitch_CheckChanged);
            // 
            // ckb_absPath
            // 
            this.ckb_absPath.BackColor = System.Drawing.Color.White;
            this.ckb_absPath.Checked = true;
            this.ckb_absPath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_absPath.Location = new System.Drawing.Point(4, 340);
            this.ckb_absPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_absPath.Name = "ckb_absPath";
            this.ckb_absPath.Size = new System.Drawing.Size(241, 20);
            this.ckb_absPath.TabIndex = 123;
            this.ckb_absPath.TextStr = "勾选：绝对路径 | 不勾选：相对路径";
            this.ckb_absPath.CheckChanged += new Controls.DCheckChanged(this.ckb_absPath_CheckChanged);
            // 
            // lbl_deg
            // 
            this.lbl_deg.AutoSize = true;
            this.lbl_deg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_deg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_deg.Location = new System.Drawing.Point(187, 439);
            this.lbl_deg.Name = "lbl_deg";
            this.lbl_deg.Size = new System.Drawing.Size(31, 17);
            this.lbl_deg.TabIndex = 122;
            this.lbl_deg.Text = "deg";
            this.lbl_deg.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.panel4.Location = new System.Drawing.Point(7, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(260, 2);
            this.panel4.TabIndex = 106;
            // 
            // pic_fromDirectory
            // 
            this.pic_fromDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_fromDirectory.Image = ((System.Drawing.Image)(resources.GetObject("pic_fromDirectory.Image")));
            this.pic_fromDirectory.Location = new System.Drawing.Point(180, 4);
            this.pic_fromDirectory.Name = "pic_fromDirectory";
            this.pic_fromDirectory.Size = new System.Drawing.Size(20, 20);
            this.pic_fromDirectory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_fromDirectory.TabIndex = 97;
            this.pic_fromDirectory.TabStop = false;
            this.pic_fromDirectory.Click += new System.EventHandler(this.pic_fromDirectory_Click);
            // 
            // rdo_fromDirectory
            // 
            this.rdo_fromDirectory.AutoSize = true;
            this.rdo_fromDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_fromDirectory.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_fromDirectory.Location = new System.Drawing.Point(182, 2);
            this.rdo_fromDirectory.Name = "rdo_fromDirectory";
            this.rdo_fromDirectory.Size = new System.Drawing.Size(55, 24);
            this.rdo_fromDirectory.TabIndex = 96;
            this.rdo_fromDirectory.TabStop = true;
            this.rdo_fromDirectory.Text = "目录";
            this.rdo_fromDirectory.UseVisualStyleBackColor = true;
            this.rdo_fromDirectory.CheckedChanged += new System.EventHandler(this.rdo_fromDirectory_CheckedChanged);
            // 
            // pic_fromFile
            // 
            this.pic_fromFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_fromFile.Image = ((System.Drawing.Image)(resources.GetObject("pic_fromFile.Image")));
            this.pic_fromFile.Location = new System.Drawing.Point(112, 4);
            this.pic_fromFile.Name = "pic_fromFile";
            this.pic_fromFile.Size = new System.Drawing.Size(20, 20);
            this.pic_fromFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_fromFile.TabIndex = 95;
            this.pic_fromFile.TabStop = false;
            this.pic_fromFile.Click += new System.EventHandler(this.pic_fromFile_Click);
            // 
            // pic_fromDevice
            // 
            this.pic_fromDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_fromDevice.Image = ((System.Drawing.Image)(resources.GetObject("pic_fromDevice.Image")));
            this.pic_fromDevice.Location = new System.Drawing.Point(41, 4);
            this.pic_fromDevice.Name = "pic_fromDevice";
            this.pic_fromDevice.Size = new System.Drawing.Size(20, 20);
            this.pic_fromDevice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_fromDevice.TabIndex = 94;
            this.pic_fromDevice.TabStop = false;
            this.pic_fromDevice.Click += new System.EventHandler(this.pic_fromDevice_Click);
            // 
            // rdo_fromFile
            // 
            this.rdo_fromFile.AutoSize = true;
            this.rdo_fromFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_fromFile.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_fromFile.Location = new System.Drawing.Point(115, 2);
            this.rdo_fromFile.Name = "rdo_fromFile";
            this.rdo_fromFile.Size = new System.Drawing.Size(55, 24);
            this.rdo_fromFile.TabIndex = 93;
            this.rdo_fromFile.TabStop = true;
            this.rdo_fromFile.Text = "文件";
            this.rdo_fromFile.UseVisualStyleBackColor = true;
            this.rdo_fromFile.CheckedChanged += new System.EventHandler(this.rdo_fromFile_CheckedChanged);
            // 
            // rdo_fromDevice
            // 
            this.rdo_fromDevice.AutoSize = true;
            this.rdo_fromDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdo_fromDevice.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_fromDevice.Location = new System.Drawing.Point(45, 2);
            this.rdo_fromDevice.Name = "rdo_fromDevice";
            this.rdo_fromDevice.Size = new System.Drawing.Size(55, 24);
            this.rdo_fromDevice.TabIndex = 92;
            this.rdo_fromDevice.TabStop = true;
            this.rdo_fromDevice.Text = "相机";
            this.rdo_fromDevice.UseVisualStyleBackColor = true;
            this.rdo_fromDevice.CheckedChanged += new System.EventHandler(this.rdo_fromDevice_CheckedChanged);
            // 
            // pnl_formPanel
            // 
            this.pnl_formPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_formPanel.BackColor = System.Drawing.Color.White;
            this.pnl_formPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnl_formPanel.Location = new System.Drawing.Point(2, 30);
            this.pnl_formPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnl_formPanel.Name = "pnl_formPanel";
            this.pnl_formPanel.Size = new System.Drawing.Size(270, 255);
            this.pnl_formPanel.TabIndex = 88;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_close);
            this.panel6.Controls.Add(this.btn_runJob);
            this.panel6.Controls.Add(this.btn_runTool);
            this.panel6.Controls.Add(this.lbl_runTime);
            this.panel6.Controls.Add(this.lbl_toolTip);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 502);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(897, 59);
            this.panel6.TabIndex = 90;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.Location = new System.Drawing.Point(821, 18);
            this.btn_close.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(65, 30);
            this.btn_close.Style = Sunny.UI.UIStyle.Custom;
            this.btn_close.TabIndex = 119;
            this.btn_close.Text = "关闭";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_runJob
            // 
            this.btn_runJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_runJob.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runJob.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runJob.Location = new System.Drawing.Point(716, 18);
            this.btn_runJob.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_runJob.Name = "btn_runJob";
            this.btn_runJob.Size = new System.Drawing.Size(65, 30);
            this.btn_runJob.Style = Sunny.UI.UIStyle.Custom;
            this.btn_runJob.TabIndex = 118;
            this.btn_runJob.Text = "运行流程";
            this.btn_runJob.Click += new System.EventHandler(this.btn_runJob_Click);
            // 
            // btn_runTool
            // 
            this.btn_runTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_runTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runTool.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runTool.Location = new System.Drawing.Point(648, 18);
            this.btn_runTool.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_runTool.Name = "btn_runTool";
            this.btn_runTool.Size = new System.Drawing.Size(65, 30);
            this.btn_runTool.Style = Sunny.UI.UIStyle.Custom;
            this.btn_runTool.TabIndex = 117;
            this.btn_runTool.Text = "运行工具";
            this.btn_runTool.Click += new System.EventHandler(this.btn_runTool_Click);
            // 
            // lbl_runTime
            // 
            this.lbl_runTime.AutoSize = true;
            this.lbl_runTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_runTime.Location = new System.Drawing.Point(6, 14);
            this.lbl_runTime.Name = "lbl_runTime";
            this.lbl_runTime.Size = new System.Drawing.Size(68, 17);
            this.lbl_runTime.TabIndex = 115;
            this.lbl_runTime.Text = "耗时：0 ms";
            // 
            // lbl_toolTip
            // 
            this.lbl_toolTip.AutoSize = true;
            this.lbl_toolTip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_toolTip.Location = new System.Drawing.Point(6, 33);
            this.lbl_toolTip.Name = "lbl_toolTip";
            this.lbl_toolTip.Size = new System.Drawing.Size(92, 17);
            this.lbl_toolTip.TabIndex = 114;
            this.lbl_toolTip.Text = "提示：暂无提示";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.panel5.Location = new System.Drawing.Point(4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(888, 2);
            this.panel5.TabIndex = 112;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 17);
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_livePlay,
            this.tsb_saveImage,
            this.tsb_SDKInfo,
            this.tsb_resetTool});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(2, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(901, 25);
            this.toolStrip1.TabIndex = 92;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_livePlay
            // 
            this.tsb_livePlay.AutoSize = false;
            this.tsb_livePlay.CheckOnClick = true;
            this.tsb_livePlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_livePlay.Image = ((System.Drawing.Image)(resources.GetObject("tsb_livePlay.Image")));
            this.tsb_livePlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_livePlay.Name = "tsb_livePlay";
            this.tsb_livePlay.RightToLeftAutoMirrorImage = true;
            this.tsb_livePlay.Size = new System.Drawing.Size(25, 22);
            this.tsb_livePlay.Text = "toolStripButton6";
            this.tsb_livePlay.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsb_livePlay.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsb_livePlay.ToolTipText = "相机实时";
            this.tsb_livePlay.Click += new System.EventHandler(this.tsb_livePlay_Click);
            // 
            // tsb_saveImage
            // 
            this.tsb_saveImage.AutoSize = false;
            this.tsb_saveImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_saveImage.Image = ((System.Drawing.Image)(resources.GetObject("tsb_saveImage.Image")));
            this.tsb_saveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_saveImage.Name = "tsb_saveImage";
            this.tsb_saveImage.RightToLeftAutoMirrorImage = true;
            this.tsb_saveImage.Size = new System.Drawing.Size(25, 22);
            this.tsb_saveImage.Text = "toolStripButton2";
            this.tsb_saveImage.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsb_saveImage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsb_saveImage.ToolTipText = "保存图像";
            this.tsb_saveImage.Click += new System.EventHandler(this.tsb_saveImage_Click);
            // 
            // tsb_SDKInfo
            // 
            this.tsb_SDKInfo.AutoSize = false;
            this.tsb_SDKInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_SDKInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsb_SDKInfo.Image")));
            this.tsb_SDKInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_SDKInfo.Name = "tsb_SDKInfo";
            this.tsb_SDKInfo.RightToLeftAutoMirrorImage = true;
            this.tsb_SDKInfo.Size = new System.Drawing.Size(25, 22);
            this.tsb_SDKInfo.Text = "toolStripButton4";
            this.tsb_SDKInfo.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsb_SDKInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsb_SDKInfo.ToolTipText = "相机SDK信息";
            this.tsb_SDKInfo.Click += new System.EventHandler(this.tsb_SDKInfo_Click);
            // 
            // tsb_resetTool
            // 
            this.tsb_resetTool.AutoSize = false;
            this.tsb_resetTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_resetTool.Image = ((System.Drawing.Image)(resources.GetObject("tsb_resetTool.Image")));
            this.tsb_resetTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_resetTool.Name = "tsb_resetTool";
            this.tsb_resetTool.RightToLeftAutoMirrorImage = true;
            this.tsb_resetTool.Size = new System.Drawing.Size(25, 22);
            this.tsb_resetTool.Text = "toolStripButton4";
            this.tsb_resetTool.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsb_resetTool.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsb_resetTool.ToolTipText = "重置";
            this.tsb_resetTool.Click += new System.EventHandler(this.tsb_resetTool_Click);
            // 
            // Frm_AcqImageTool
            // 
            this.AcceptButton = this.btn_runTool;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(907, 592);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(380, 120);
            this.Name = "Frm_AcqImageTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "采集图像";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_AcqImageTool_FormClosing);
            this.Controls.SetChildIndex(this.btn_topLevel, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_fromDirectory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_fromFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_fromDevice)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public ChoiceTech.Halcon.Control.HWindow_Final hWindow_Final1;
        public System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.PictureBox pic_fromDirectory;
        public System.Windows.Forms.RadioButton rdo_fromDirectory;
        public System.Windows.Forms.PictureBox pic_fromFile;
        public System.Windows.Forms.PictureBox pic_fromDevice;
        public System.Windows.Forms.RadioButton rdo_fromFile;
        public System.Windows.Forms.RadioButton rdo_fromDevice;
        public System.Windows.Forms.Panel pnl_formPanel;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Label lbl_toolTip;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 适应图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全屏ESC退出全屏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存图像ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 相机实时ToolStripMenuItem;
        public System.Windows.Forms.Label lbl_runTime;
        private System.Windows.Forms.Label lbl_deg;
        public CNumericUpDown nud_rotateAngle;
        public CCheckBox ckb_absPath;
        public CCheckBox ckb_autoSwitch;
        public CCheckBox ckb_RGBToGray;
        public CCheckBox ckb_allImageRegion;
        public CCheckBox ckb_rotateImage;
        public CCheckBox ckb_hardTrig;
        internal Sunny.UI.UIButton btn_close;
        internal Sunny.UI.UIButton btn_runJob;
        internal Sunny.UI.UIButton btn_runTool;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton tsb_livePlay;
        private System.Windows.Forms.ToolStripButton tsb_saveImage;
        private System.Windows.Forms.ToolStripButton tsb_SDKInfo;
        private System.Windows.Forms.ToolStripButton tsb_resetTool;
        public CCheckBox ckb_updateImage;
    }
}