namespace UniversalControlSystem
{
    partial  class frm_9PointCalib

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
            this.cbxModelName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCalib = new System.Windows.Forms.Label();
            this.btndrawRoi = new System.Windows.Forms.Button();
            this.btnPLC = new System.Windows.Forms.Button();
            this.btnGetImageCoord = new System.Windows.Forms.Button();
            this.tbxWorldY = new System.Windows.Forms.TextBox();
            this.tbxImageY = new System.Windows.Forms.TextBox();
            this.tbxWorldX = new System.Windows.Forms.TextBox();
            this.tbxImageX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxToolName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxImage = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.btnCalib = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnAddImageCoord = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chItems = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chImageX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chImageY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWorldX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chWorldY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxSetdraw = new System.Windows.Forms.ComboBox();
            this.cebxIsRectangle = new System.Windows.Forms.CheckBox();
            this.cebxIsSelectedRegions = new System.Windows.Forms.CheckBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_sure = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 21);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(493, 599);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage1.Controls.Add(this.cbxModelName);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.tbxToolName);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.btnCalib);
            this.tabPage1.Controls.Add(this.btnDeleteAll);
            this.tabPage1.Controls.Add(this.btnAddImageCoord);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(485, 570);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设定";
            // 
            // cbxModelName
            // 
            this.cbxModelName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxModelName.FormattingEnabled = true;
            this.cbxModelName.Location = new System.Drawing.Point(119, 116);
            this.cbxModelName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxModelName.Name = "cbxModelName";
            this.cbxModelName.Size = new System.Drawing.Size(349, 25);
            this.cbxModelName.TabIndex = 31;
            this.cbxModelName.SelectedIndexChanged += new System.EventHandler(this.cbxModelName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "模板定位选择：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCalib);
            this.groupBox3.Controls.Add(this.btndrawRoi);
            this.groupBox3.Controls.Add(this.btnPLC);
            this.groupBox3.Controls.Add(this.btnGetImageCoord);
            this.groupBox3.Controls.Add(this.tbxWorldY);
            this.groupBox3.Controls.Add(this.tbxImageY);
            this.groupBox3.Controls.Add(this.tbxWorldX);
            this.groupBox3.Controls.Add(this.tbxImageX);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(4, 159);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(473, 151);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "标定操作";
            // 
            // lblCalib
            // 
            this.lblCalib.AutoSize = true;
            this.lblCalib.Location = new System.Drawing.Point(368, 125);
            this.lblCalib.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalib.Name = "lblCalib";
            this.lblCalib.Size = new System.Drawing.Size(52, 15);
            this.lblCalib.TabIndex = 12;
            this.lblCalib.Text = "未标定";
            // 
            // btndrawRoi
            // 
            this.btndrawRoi.Location = new System.Drawing.Point(365, 49);
            this.btndrawRoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btndrawRoi.Name = "btndrawRoi";
            this.btndrawRoi.Size = new System.Drawing.Size(100, 29);
            this.btndrawRoi.TabIndex = 11;
            this.btndrawRoi.Text = "创建点区域";
            this.btndrawRoi.UseVisualStyleBackColor = true;
            this.btndrawRoi.Click += new System.EventHandler(this.btndrawRoi_Click);
            // 
            // btnPLC
            // 
            this.btnPLC.Location = new System.Drawing.Point(52, 119);
            this.btnPLC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPLC.Name = "btnPLC";
            this.btnPLC.Size = new System.Drawing.Size(100, 29);
            this.btnPLC.TabIndex = 10;
            this.btnPLC.Text = "机械手控制";
            this.btnPLC.UseVisualStyleBackColor = true;
            this.btnPLC.Click += new System.EventHandler(this.btnPLC_Click);
            // 
            // btnGetImageCoord
            // 
            this.btnGetImageCoord.Location = new System.Drawing.Point(160, 119);
            this.btnGetImageCoord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGetImageCoord.Name = "btnGetImageCoord";
            this.btnGetImageCoord.Size = new System.Drawing.Size(100, 29);
            this.btnGetImageCoord.TabIndex = 9;
            this.btnGetImageCoord.Text = "获取坐标";
            this.btnGetImageCoord.UseVisualStyleBackColor = true;
            this.btnGetImageCoord.Click += new System.EventHandler(this.btnGetImageCoord_Click);
            // 
            // tbxWorldY
            // 
            this.tbxWorldY.Location = new System.Drawing.Point(180, 85);
            this.tbxWorldY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxWorldY.Name = "tbxWorldY";
            this.tbxWorldY.Size = new System.Drawing.Size(79, 25);
            this.tbxWorldY.TabIndex = 8;
            this.tbxWorldY.TextChanged += new System.EventHandler(this.tbxWorldY_TextChanged);
            // 
            // tbxImageY
            // 
            this.tbxImageY.Location = new System.Drawing.Point(180, 51);
            this.tbxImageY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxImageY.Name = "tbxImageY";
            this.tbxImageY.ReadOnly = true;
            this.tbxImageY.Size = new System.Drawing.Size(79, 25);
            this.tbxImageY.TabIndex = 7;
            // 
            // tbxWorldX
            // 
            this.tbxWorldX.Location = new System.Drawing.Point(73, 85);
            this.tbxWorldX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxWorldX.Name = "tbxWorldX";
            this.tbxWorldX.Size = new System.Drawing.Size(79, 25);
            this.tbxWorldX.TabIndex = 6;
            this.tbxWorldX.TextChanged += new System.EventHandler(this.tbxWorldX_TextChanged);
            // 
            // tbxImageX
            // 
            this.tbxImageX.Location = new System.Drawing.Point(73, 51);
            this.tbxImageX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxImageX.Name = "tbxImageX";
            this.tbxImageX.ReadOnly = true;
            this.tbxImageX.Size = new System.Drawing.Size(79, 25);
            this.tbxImageX.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Y坐标";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "X坐标";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "PLC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "图像";
            // 
            // tbxToolName
            // 
            this.tbxToolName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxToolName.Location = new System.Drawing.Point(119, 14);
            this.tbxToolName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxToolName.Name = "tbxToolName";
            this.tbxToolName.Size = new System.Drawing.Size(357, 30);
            this.tbxToolName.TabIndex = 17;
            this.tbxToolName.TextChanged += new System.EventHandler(this.tbxToolName_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbxImage);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Location = new System.Drawing.Point(8, 54);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(469, 56);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像设置";
            // 
            // cbxImage
            // 
            this.cbxImage.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxImage.FormattingEnabled = true;
            this.cbxImage.Location = new System.Drawing.Point(111, 20);
            this.cbxImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxImage.Name = "cbxImage";
            this.cbxImage.Size = new System.Drawing.Size(349, 25);
            this.cbxImage.TabIndex = 0;
            this.cbxImage.SelectedIndexChanged += new System.EventHandler(this.cbxImage_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(16, 26);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(82, 15);
            this.label30.TabIndex = 1;
            this.label30.Text = "输入图像：";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(40, 24);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(67, 15);
            this.label31.TabIndex = 16;
            this.label31.Text = "工具名：";
            // 
            // btnCalib
            // 
            this.btnCalib.Location = new System.Drawing.Point(119, 530);
            this.btnCalib.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCalib.Name = "btnCalib";
            this.btnCalib.Size = new System.Drawing.Size(100, 29);
            this.btnCalib.TabIndex = 14;
            this.btnCalib.Text = "标定";
            this.btnCalib.UseVisualStyleBackColor = true;
            this.btnCalib.Click += new System.EventHandler(this.btnCalib_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(375, 530);
            this.btnDeleteAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(100, 29);
            this.btnDeleteAll.TabIndex = 13;
            this.btnDeleteAll.Text = "全部删除";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnAddImageCoord
            // 
            this.btnAddImageCoord.Location = new System.Drawing.Point(11, 530);
            this.btnAddImageCoord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddImageCoord.Name = "btnAddImageCoord";
            this.btnAddImageCoord.Size = new System.Drawing.Size(100, 29);
            this.btnAddImageCoord.TabIndex = 12;
            this.btnAddImageCoord.Text = "添加坐标";
            this.btnAddImageCoord.UseVisualStyleBackColor = true;
            this.btnAddImageCoord.Click += new System.EventHandler(this.btnAddImageCoord_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(267, 530);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 29);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chItems,
            this.chImageX,
            this.chImageY,
            this.chWorldX,
            this.chWorldY});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(4, 318);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(469, 199);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // chItems
            // 
            this.chItems.Text = "  序号";
            this.chItems.Width = 70;
            // 
            // chImageX
            // 
            this.chImageX.Text = "ImageX";
            this.chImageX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chImageX.Width = 70;
            // 
            // chImageY
            // 
            this.chImageY.Text = "ImageY";
            this.chImageY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chImageY.Width = 70;
            // 
            // chWorldX
            // 
            this.chWorldX.Text = "WorldX";
            this.chWorldX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chWorldX.Width = 70;
            // 
            // chWorldY
            // 
            this.chWorldY.Text = "WorldY";
            this.chWorldY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chWorldY.Width = 70;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cbxSetdraw);
            this.tabPage2.Controls.Add(this.cebxIsRectangle);
            this.tabPage2.Controls.Add(this.cebxIsSelectedRegions);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(485, 570);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "图形";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 165);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "显示：";
            // 
            // cbxSetdraw
            // 
            this.cbxSetdraw.FormattingEnabled = true;
            this.cbxSetdraw.Items.AddRange(new object[] {
            "fill",
            "margin"});
            this.cbxSetdraw.Location = new System.Drawing.Point(127, 155);
            this.cbxSetdraw.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxSetdraw.Name = "cbxSetdraw";
            this.cbxSetdraw.Size = new System.Drawing.Size(160, 23);
            this.cbxSetdraw.TabIndex = 7;
            this.cbxSetdraw.Text = "fill";
            this.cbxSetdraw.SelectedIndexChanged += new System.EventHandler(this.cbxSetdraw_SelectedIndexChanged);
            // 
            // cebxIsRectangle
            // 
            this.cebxIsRectangle.AutoSize = true;
            this.cebxIsRectangle.BackColor = System.Drawing.Color.Silver;
            this.cebxIsRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cebxIsRectangle.Location = new System.Drawing.Point(127, 64);
            this.cebxIsRectangle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cebxIsRectangle.Name = "cebxIsRectangle";
            this.cebxIsRectangle.Size = new System.Drawing.Size(86, 19);
            this.cebxIsRectangle.TabIndex = 6;
            this.cebxIsRectangle.Text = "显示矩形";
            this.cebxIsRectangle.UseVisualStyleBackColor = false;
            this.cebxIsRectangle.CheckedChanged += new System.EventHandler(this.cebxIsRectangle_CheckedChanged);
            // 
            // cebxIsSelectedRegions
            // 
            this.cebxIsSelectedRegions.AutoSize = true;
            this.cebxIsSelectedRegions.BackColor = System.Drawing.Color.Silver;
            this.cebxIsSelectedRegions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cebxIsSelectedRegions.Location = new System.Drawing.Point(127, 21);
            this.cebxIsSelectedRegions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cebxIsSelectedRegions.Name = "cebxIsSelectedRegions";
            this.cebxIsSelectedRegions.Size = new System.Drawing.Size(116, 19);
            this.cebxIsSelectedRegions.TabIndex = 5;
            this.cebxIsSelectedRegions.Text = "显示面积区域";
            this.cebxIsSelectedRegions.UseVisualStyleBackColor = false;
            this.cebxIsSelectedRegions.CheckedChanged += new System.EventHandler(this.cebxIsSelectedRegions_CheckedChanged);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(404, 628);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 36);
            this.btn_cancel.TabIndex = 36;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_sure
            // 
            this.btn_sure.Location = new System.Drawing.Point(301, 628);
            this.btn_sure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_sure.Name = "btn_sure";
            this.btn_sure.Size = new System.Drawing.Size(100, 36);
            this.btn_sure.TabIndex = 35;
            this.btn_sure.Text = "确定";
            this.btn_sure.UseVisualStyleBackColor = true;
            this.btn_sure.Click += new System.EventHandler(this.btn_sure_Click);
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(21, 628);
            this.btn_run.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(100, 36);
            this.btn_run.TabIndex = 34;
            this.btn_run.Text = "运行";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hWindowControl1);
            this.panel1.Location = new System.Drawing.Point(512, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 655);
            this.panel1.TabIndex = 37;
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(5, 9);
            this.hWindowControl1.Margin = new System.Windows.Forms.Padding(4);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(736, 472);
            this.hWindowControl1.TabIndex = 8;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(736, 472);
            // 
            // frm_9PointCalib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1316, 679);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_sure);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_9PointCalib";
            this.Text = "9点标定";
            this.Load += new System.EventHandler(this.frm_9PointCalib_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

       // private ViewControl.HalconView halconView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnCalib;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Button btnAddImageCoord;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader chItems;
        private System.Windows.Forms.ColumnHeader chImageX;
        private System.Windows.Forms.ColumnHeader chImageY;
        private System.Windows.Forms.ColumnHeader chWorldX;
        private System.Windows.Forms.ColumnHeader chWorldY;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_sure;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.TextBox tbxToolName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxImage;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btndrawRoi;
        private System.Windows.Forms.Button btnPLC;
        private System.Windows.Forms.Button btnGetImageCoord;
        private System.Windows.Forms.TextBox tbxWorldY;
        private System.Windows.Forms.TextBox tbxImageY;
        private System.Windows.Forms.TextBox tbxWorldX;
        private System.Windows.Forms.TextBox tbxImageX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxModelName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxSetdraw;
        private System.Windows.Forms.CheckBox cebxIsRectangle;
        private System.Windows.Forms.CheckBox cebxIsSelectedRegions;
        private System.Windows.Forms.Label lblCalib;
        private System.Windows.Forms.Panel panel1;
        public HalconDotNet.HWindowControl hWindowControl1;
    }
}