namespace UniversalControlSystem
{
    partial class PYToolFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PYToolFrom));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TOOLName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.步骤名字 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.步骤号 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.步骤类型 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.步骤用时 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.步骤结果 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.步骤跳转 = new System.Windows.Forms.TextBox();
            this.步骤 = new System.Windows.Forms.Label();
            this.Py_Path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Py_Run_Res = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Py_Fun = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DataTx = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.DataTy = new System.Windows.Forms.ComboBox();
            this.btn_SelectParamFile = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Aqua;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(711, 28);
            this.menuStrip1.TabIndex = 377;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            this.menuStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseMove);
            this.menuStrip1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseUp);
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
            // TOOLName
            // 
            this.TOOLName.AutoSize = true;
            this.TOOLName.Location = new System.Drawing.Point(58, 38);
            this.TOOLName.Name = "TOOLName";
            this.TOOLName.Size = new System.Drawing.Size(71, 15);
            this.TOOLName.TabIndex = 378;
            this.TOOLName.Text = "TOOLName";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 43);
            this.button1.TabIndex = 385;
            this.button1.Text = "运行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 步骤名字
            // 
            this.步骤名字.Location = new System.Drawing.Point(499, 38);
            this.步骤名字.Name = "步骤名字";
            this.步骤名字.ReadOnly = true;
            this.步骤名字.Size = new System.Drawing.Size(200, 25);
            this.步骤名字.TabIndex = 386;
            this.步骤名字.Text = "A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(418, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 387;
            this.label4.Text = "步骤名字:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(418, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 389;
            this.label5.Text = "步骤号:";
            // 
            // 步骤号
            // 
            this.步骤号.Location = new System.Drawing.Point(499, 69);
            this.步骤号.Name = "步骤号";
            this.步骤号.ReadOnly = true;
            this.步骤号.Size = new System.Drawing.Size(200, 25);
            this.步骤号.TabIndex = 388;
            this.步骤号.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(418, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 391;
            this.label6.Text = "步骤类型:";
            // 
            // 步骤类型
            // 
            this.步骤类型.Location = new System.Drawing.Point(499, 98);
            this.步骤类型.Name = "步骤类型";
            this.步骤类型.ReadOnly = true;
            this.步骤类型.Size = new System.Drawing.Size(200, 25);
            this.步骤类型.TabIndex = 390;
            this.步骤类型.Text = "A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(418, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 393;
            this.label7.Text = "步骤用时:";
            // 
            // 步骤用时
            // 
            this.步骤用时.Location = new System.Drawing.Point(499, 129);
            this.步骤用时.Name = "步骤用时";
            this.步骤用时.ReadOnly = true;
            this.步骤用时.Size = new System.Drawing.Size(200, 25);
            this.步骤用时.TabIndex = 392;
            this.步骤用时.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(418, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 395;
            this.label8.Text = "步骤结果:";
            // 
            // 步骤结果
            // 
            this.步骤结果.Location = new System.Drawing.Point(499, 160);
            this.步骤结果.Name = "步骤结果";
            this.步骤结果.ReadOnly = true;
            this.步骤结果.Size = new System.Drawing.Size(200, 25);
            this.步骤结果.TabIndex = 394;
            this.步骤结果.Text = "OK";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(418, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 397;
            this.label9.Text = "步骤跳转:";
            // 
            // 步骤跳转
            // 
            this.步骤跳转.Location = new System.Drawing.Point(499, 191);
            this.步骤跳转.Name = "步骤跳转";
            this.步骤跳转.Size = new System.Drawing.Size(200, 25);
            this.步骤跳转.TabIndex = 396;
            this.步骤跳转.Text = "-1";
            this.步骤跳转.TextChanged += new System.EventHandler(this.步骤跳转_TextChanged);
            // 
            // 步骤
            // 
            this.步骤.AutoSize = true;
            this.步骤.Location = new System.Drawing.Point(175, 41);
            this.步骤.Name = "步骤";
            this.步骤.Size = new System.Drawing.Size(37, 15);
            this.步骤.TabIndex = 398;
            this.步骤.Text = "步骤";
            // 
            // Py_Path
            // 
            this.Py_Path.Location = new System.Drawing.Point(108, 59);
            this.Py_Path.Name = "Py_Path";
            this.Py_Path.Size = new System.Drawing.Size(209, 25);
            this.Py_Path.TabIndex = 406;
            this.Py_Path.TextChanged += new System.EventHandler(this.卡号textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 405;
            this.label3.Text = "路径:";
            // 
            // Py_Run_Res
            // 
            this.Py_Run_Res.Location = new System.Drawing.Point(109, 217);
            this.Py_Run_Res.Name = "Py_Run_Res";
            this.Py_Run_Res.Size = new System.Drawing.Size(208, 25);
            this.Py_Run_Res.TabIndex = 408;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 407;
            this.label1.Text = "结果:";
            // 
            // Py_Fun
            // 
            this.Py_Fun.Location = new System.Drawing.Point(109, 90);
            this.Py_Fun.Name = "Py_Fun";
            this.Py_Fun.Size = new System.Drawing.Size(208, 25);
            this.Py_Fun.TabIndex = 410;
            this.Py_Fun.TextChanged += new System.EventHandler(this.Py_Fun_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 409;
            this.label2.Text = "运行方法:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 15);
            this.label10.TabIndex = 412;
            this.label10.Text = "存入数据组:";
            // 
            // DataTx
            // 
            this.DataTx.FormattingEnabled = true;
            this.DataTx.Location = new System.Drawing.Point(108, 124);
            this.DataTx.Name = "DataTx";
            this.DataTx.Size = new System.Drawing.Size(209, 23);
            this.DataTx.TabIndex = 411;
            this.DataTx.SelectedIndexChanged += new System.EventHandler(this.DataTx_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 15);
            this.label11.TabIndex = 414;
            this.label11.Text = "存入数据名:";
            // 
            // DataTy
            // 
            this.DataTy.FormattingEnabled = true;
            this.DataTy.Location = new System.Drawing.Point(108, 155);
            this.DataTy.Name = "DataTy";
            this.DataTy.Size = new System.Drawing.Size(209, 23);
            this.DataTy.TabIndex = 413;
            this.DataTy.SelectedIndexChanged += new System.EventHandler(this.DataTy_SelectedIndexChanged);
            // 
            // btn_SelectParamFile
            // 
            this.btn_SelectParamFile.Location = new System.Drawing.Point(324, 48);
            this.btn_SelectParamFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SelectParamFile.Name = "btn_SelectParamFile";
            this.btn_SelectParamFile.Size = new System.Drawing.Size(87, 29);
            this.btn_SelectParamFile.TabIndex = 415;
            this.btn_SelectParamFile.Text = "选择文件";
            this.btn_SelectParamFile.UseVisualStyleBackColor = true;
            this.btn_SelectParamFile.Click += new System.EventHandler(this.btn_SelectParamFile_Click);
            // 
            // PYToolFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 347);
            this.Controls.Add(this.btn_SelectParamFile);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DataTy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DataTx);
            this.Controls.Add(this.Py_Fun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Py_Run_Res);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Py_Path);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.步骤);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.步骤跳转);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.步骤结果);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.步骤用时);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.步骤类型);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.步骤号);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.步骤名字);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TOOLName);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PYToolFrom";
            this.Text = "OutPut_Pulse";
            this.Load += new System.EventHandler(this.OutPut_Pulse_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutPut_PulseFrom_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OutPut_PulseFrom_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OutPut_PulseFrom_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.Label TOOLName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox 步骤名字;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox 步骤号;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox 步骤类型;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox 步骤用时;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox 步骤结果;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox 步骤跳转;
        private System.Windows.Forms.Label 步骤;
        private System.Windows.Forms.TextBox Py_Path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Py_Run_Res;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Py_Fun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox DataTx;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox DataTy;
        private System.Windows.Forms.Button btn_SelectParamFile;
    }
}