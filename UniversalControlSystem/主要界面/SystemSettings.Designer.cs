namespace UniversalControlSystem
{
    partial class SystemSettings
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("卡硬件设定");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("轴硬件设定");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("运动控制卡设置", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("IO硬件设定窗口");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("IO卡设置", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("模拟量波形设置");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("其他设置");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("参数配置设置");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("其他设置", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("通讯设置界面");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("通讯设置", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("PLC");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("PLC设置", new System.Windows.Forms.TreeNode[] {
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("数据组");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("数据组设置", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("DataManage");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("数据包", new System.Windows.Forms.TreeNode[] {
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("流程编辑");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("流程", new System.Windows.Forms.TreeNode[] {
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("点位增加调试");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("点位设置", new System.Windows.Forms.TreeNode[] {
            treeNode20});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemSettings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_InitCard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_SaveParamDoc = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_InitCard);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_SaveParamDoc);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1379, 700);
            this.panel1.TabIndex = 1;
            // 
            // btn_InitCard
            // 
            this.btn_InitCard.Location = new System.Drawing.Point(61, 644);
            this.btn_InitCard.Margin = new System.Windows.Forms.Padding(4);
            this.btn_InitCard.Name = "btn_InitCard";
            this.btn_InitCard.Size = new System.Drawing.Size(168, 41);
            this.btn_InitCard.TabIndex = 9;
            this.btn_InitCard.Text = "初始化卡硬件";
            this.btn_InitCard.UseVisualStyleBackColor = true;
            this.btn_InitCard.Click += new System.EventHandler(this.btn_InitCard_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(279, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 700);
            this.panel2.TabIndex = 8;
            // 
            // btn_SaveParamDoc
            // 
            this.btn_SaveParamDoc.Location = new System.Drawing.Point(61, 595);
            this.btn_SaveParamDoc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SaveParamDoc.Name = "btn_SaveParamDoc";
            this.btn_SaveParamDoc.Size = new System.Drawing.Size(168, 41);
            this.btn_SaveParamDoc.TabIndex = 7;
            this.btn_SaveParamDoc.Text = "保存参数";
            this.btn_SaveParamDoc.UseVisualStyleBackColor = true;
            this.btn_SaveParamDoc.Click += new System.EventHandler(this.btn_SaveParamDoc_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点2";
            treeNode1.Text = "卡硬件设定";
            treeNode2.Name = "轴设置";
            treeNode2.Text = "轴硬件设定";
            treeNode3.Name = "节点0";
            treeNode3.Text = "运动控制卡设置";
            treeNode4.Name = "节点4";
            treeNode4.Text = "IO硬件设定窗口";
            treeNode5.Name = "节点1";
            treeNode5.Text = "IO卡设置";
            treeNode6.Name = "模拟量波形设置";
            treeNode6.Text = "模拟量波形设置";
            treeNode7.Name = "其他设置";
            treeNode7.Text = "其他设置";
            treeNode8.Name = "节点0";
            treeNode8.Text = "参数配置设置";
            treeNode9.Name = "其他设置";
            treeNode9.Text = "其他设置";
            treeNode10.Name = "通讯设置界面";
            treeNode10.Text = "通讯设置界面";
            treeNode11.Name = "通讯设置";
            treeNode11.Text = "通讯设置";
            treeNode12.Name = "PLC";
            treeNode12.Text = "PLC";
            treeNode13.Name = "PLC设置";
            treeNode13.Text = "PLC设置";
            treeNode14.Name = "DateGroup";
            treeNode14.Text = "数据组";
            treeNode15.Name = "DateGroup";
            treeNode15.Text = "数据组设置";
            treeNode16.Name = "_DataManage";
            treeNode16.Text = "DataManage";
            treeNode17.Name = "节点0";
            treeNode17.Text = "数据包";
            treeNode18.Name = "节点1";
            treeNode18.Text = "流程编辑";
            treeNode19.Name = "节点0";
            treeNode19.Text = "流程";
            treeNode20.Name = "节点1";
            treeNode20.Text = "点位增加调试";
            treeNode21.Name = "节点0";
            treeNode21.Text = "点位设置";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5,
            treeNode9,
            treeNode11,
            treeNode13,
            treeNode15,
            treeNode17,
            treeNode19,
            treeNode21});
            this.treeView1.PathSeparator = "";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(279, 700);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "接收区.png");
            // 
            // SystemSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 700);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SystemSettings";
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.SystemSettings_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_SaveParamDoc;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_InitCard;
        private System.Windows.Forms.ImageList imageList1;
    }
}