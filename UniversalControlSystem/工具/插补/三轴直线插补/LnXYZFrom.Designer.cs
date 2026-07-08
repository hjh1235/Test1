namespace UniversalControlSystem
{
    partial class LnXYZFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LnXYZFrom));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TOOLName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._轴1Name = new System.Windows.Forms.ComboBox();
            this.坐标系维度 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.label10 = new System.Windows.Forms.Label();
            this._轴2Name = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this._轴3Name = new System.Windows.Forms.ComboBox();
            this.卡号textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.终点坐标获取 = new System.Windows.Forms.Button();
            this.EndY = new System.Windows.Forms.TextBox();
            this.EndX = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.速度获取 = new System.Windows.Forms.Button();
            this.EndSpeed = new System.Windows.Forms.TextBox();
            this.StartSpeed = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.EndZ = new System.Windows.Forms.TextBox();
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
            this.menuStrip1.Size = new System.Drawing.Size(644, 28);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 379;
            this.label1.Text = "坐标系维度:";
            // 
            // _轴1Name
            // 
            this._轴1Name.FormattingEnabled = true;
            this._轴1Name.Location = new System.Drawing.Point(108, 122);
            this._轴1Name.Name = "_轴1Name";
            this._轴1Name.Size = new System.Drawing.Size(200, 23);
            this._轴1Name.TabIndex = 380;
            this._轴1Name.Text = "A";
            this._轴1Name.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // 坐标系维度
            // 
            this.坐标系维度.Location = new System.Drawing.Point(108, 90);
            this.坐标系维度.Name = "坐标系维度";
            this.坐标系维度.Size = new System.Drawing.Size(200, 25);
            this.坐标系维度.TabIndex = 382;
            this.坐标系维度.Text = "0";
            this.坐标系维度.TextChanged += new System.EventHandler(this.坐标系维度_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 383;
            this.label2.Text = "轴1:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 43);
            this.button1.TabIndex = 385;
            this.button1.Text = "插入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 步骤名字
            // 
            this.步骤名字.Location = new System.Drawing.Point(401, 38);
            this.步骤名字.Name = "步骤名字";
            this.步骤名字.ReadOnly = true;
            this.步骤名字.Size = new System.Drawing.Size(200, 25);
            this.步骤名字.TabIndex = 386;
            this.步骤名字.Text = "A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 387;
            this.label4.Text = "步骤名字:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 389;
            this.label5.Text = "步骤号:";
            // 
            // 步骤号
            // 
            this.步骤号.Location = new System.Drawing.Point(401, 69);
            this.步骤号.Name = "步骤号";
            this.步骤号.ReadOnly = true;
            this.步骤号.Size = new System.Drawing.Size(200, 25);
            this.步骤号.TabIndex = 388;
            this.步骤号.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(320, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 391;
            this.label6.Text = "步骤类型:";
            // 
            // 步骤类型
            // 
            this.步骤类型.Location = new System.Drawing.Point(401, 98);
            this.步骤类型.Name = "步骤类型";
            this.步骤类型.ReadOnly = true;
            this.步骤类型.Size = new System.Drawing.Size(200, 25);
            this.步骤类型.TabIndex = 390;
            this.步骤类型.Text = "A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 393;
            this.label7.Text = "步骤用时:";
            // 
            // 步骤用时
            // 
            this.步骤用时.Location = new System.Drawing.Point(401, 129);
            this.步骤用时.Name = "步骤用时";
            this.步骤用时.ReadOnly = true;
            this.步骤用时.Size = new System.Drawing.Size(200, 25);
            this.步骤用时.TabIndex = 392;
            this.步骤用时.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(320, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 395;
            this.label8.Text = "步骤结果:";
            // 
            // 步骤结果
            // 
            this.步骤结果.Location = new System.Drawing.Point(401, 160);
            this.步骤结果.Name = "步骤结果";
            this.步骤结果.ReadOnly = true;
            this.步骤结果.Size = new System.Drawing.Size(200, 25);
            this.步骤结果.TabIndex = 394;
            this.步骤结果.Text = "OK";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 397;
            this.label9.Text = "步骤跳转:";
            // 
            // 步骤跳转
            // 
            this.步骤跳转.Location = new System.Drawing.Point(401, 191);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(65, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 15);
            this.label10.TabIndex = 400;
            this.label10.Text = "轴2:";
            // 
            // _轴2Name
            // 
            this._轴2Name.FormattingEnabled = true;
            this._轴2Name.Location = new System.Drawing.Point(108, 152);
            this._轴2Name.Name = "_轴2Name";
            this._轴2Name.Size = new System.Drawing.Size(200, 23);
            this._轴2Name.TabIndex = 399;
            this._轴2Name.Text = "A";
            this._轴2Name.SelectedIndexChanged += new System.EventHandler(this._轴2Name_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(65, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 15);
            this.label11.TabIndex = 402;
            this.label11.Text = "轴3:";
            // 
            // _轴3Name
            // 
            this._轴3Name.FormattingEnabled = true;
            this._轴3Name.Location = new System.Drawing.Point(108, 182);
            this._轴3Name.Name = "_轴3Name";
            this._轴3Name.Size = new System.Drawing.Size(200, 23);
            this._轴3Name.TabIndex = 401;
            this._轴3Name.Text = "A";
            this._轴3Name.SelectedIndexChanged += new System.EventHandler(this._轴3Name_SelectedIndexChanged);
            // 
            // 卡号textBox1
            // 
            this.卡号textBox1.Location = new System.Drawing.Point(108, 59);
            this.卡号textBox1.Name = "卡号textBox1";
            this.卡号textBox1.Size = new System.Drawing.Size(200, 25);
            this.卡号textBox1.TabIndex = 406;
            this.卡号textBox1.Text = "0";
            this.卡号textBox1.TextChanged += new System.EventHandler(this.卡号textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 405;
            this.label3.Text = "卡号:";
            // 
            // 终点坐标获取
            // 
            this.终点坐标获取.Location = new System.Drawing.Point(333, 245);
            this.终点坐标获取.Name = "终点坐标获取";
            this.终点坐标获取.Size = new System.Drawing.Size(47, 29);
            this.终点坐标获取.TabIndex = 433;
            this.终点坐标获取.Text = "Get";
            this.终点坐标获取.UseVisualStyleBackColor = true;
            this.终点坐标获取.Click += new System.EventHandler(this.终点坐标获取_Click);
            // 
            // EndY
            // 
            this.EndY.Location = new System.Drawing.Point(190, 245);
            this.EndY.Name = "EndY";
            this.EndY.Size = new System.Drawing.Size(65, 25);
            this.EndY.TabIndex = 432;
            this.EndY.Text = "0";
            this.EndY.TextChanged += new System.EventHandler(this.EndY_TextChanged);
            // 
            // EndX
            // 
            this.EndX.Location = new System.Drawing.Point(103, 245);
            this.EndX.Name = "EndX";
            this.EndX.Size = new System.Drawing.Size(76, 25);
            this.EndX.TabIndex = 431;
            this.EndX.Text = "0";
            this.EndX.TextChanged += new System.EventHandler(this.EndX_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 248);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 15);
            this.label14.TabIndex = 430;
            this.label14.Text = "终点坐标XYZ:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(417, 259);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 15);
            this.label16.TabIndex = 438;
            this.label16.Text = "终点速度:";
            // 
            // 速度获取
            // 
            this.速度获取.Location = new System.Drawing.Point(585, 241);
            this.速度获取.Name = "速度获取";
            this.速度获取.Size = new System.Drawing.Size(47, 29);
            this.速度获取.TabIndex = 437;
            this.速度获取.Text = "Get";
            this.速度获取.UseVisualStyleBackColor = true;
            this.速度获取.Click += new System.EventHandler(this.速度获取_Click);
            // 
            // EndSpeed
            // 
            this.EndSpeed.Location = new System.Drawing.Point(498, 256);
            this.EndSpeed.Name = "EndSpeed";
            this.EndSpeed.Size = new System.Drawing.Size(76, 25);
            this.EndSpeed.TabIndex = 436;
            this.EndSpeed.Text = "0";
            this.EndSpeed.TextChanged += new System.EventHandler(this.EndSpeed_TextChanged);
            // 
            // StartSpeed
            // 
            this.StartSpeed.Location = new System.Drawing.Point(498, 225);
            this.StartSpeed.Name = "StartSpeed";
            this.StartSpeed.Size = new System.Drawing.Size(76, 25);
            this.StartSpeed.TabIndex = 435;
            this.StartSpeed.Text = "0";
            this.StartSpeed.TextChanged += new System.EventHandler(this.StartSpeed_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(417, 231);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 15);
            this.label15.TabIndex = 434;
            this.label15.Text = "起始速度:";
            // 
            // EndZ
            // 
            this.EndZ.Location = new System.Drawing.Point(261, 245);
            this.EndZ.Name = "EndZ";
            this.EndZ.Size = new System.Drawing.Size(65, 25);
            this.EndZ.TabIndex = 439;
            this.EndZ.Text = "0";
            this.EndZ.TextChanged += new System.EventHandler(this.EndZ_TextChanged);
            // 
            // LnXYZFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 344);
            this.Controls.Add(this.EndZ);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.速度获取);
            this.Controls.Add(this.EndSpeed);
            this.Controls.Add(this.StartSpeed);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.终点坐标获取);
            this.Controls.Add(this.EndY);
            this.Controls.Add(this.EndX);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.卡号textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this._轴3Name);
            this.Controls.Add(this.label10);
            this.Controls.Add(this._轴2Name);
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
            this.Controls.Add(this.label2);
            this.Controls.Add(this.坐标系维度);
            this.Controls.Add(this._轴1Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TOOLName);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LnXYZFrom";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _轴1Name;
        private System.Windows.Forms.TextBox 坐标系维度;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox _轴2Name;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox _轴3Name;
        private System.Windows.Forms.TextBox 卡号textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button 终点坐标获取;
        private System.Windows.Forms.TextBox EndY;
        private System.Windows.Forms.TextBox EndX;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button 速度获取;
        private System.Windows.Forms.TextBox EndSpeed;
        private System.Windows.Forms.TextBox StartSpeed;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox EndZ;
    }
}