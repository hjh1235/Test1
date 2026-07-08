namespace UniversalControlSystem
{
    partial class Aixs_more_CtronFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Aixs_more_CtronFrom));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TOOLName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._StepControlName = new System.Windows.Forms.ComboBox();
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.位置textBox1 = new System.Windows.Forms.TextBox();
            this.速度textBox2 = new System.Windows.Forms.TextBox();
            this.加速度textBox3 = new System.Windows.Forms.TextBox();
            this.减速度textBox4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this._AxisName = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dgv_deviceList = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceList)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 379;
            this.label1.Text = "Aixs名字:";
            // 
            // _StepControlName
            // 
            this._StepControlName.FormattingEnabled = true;
            this._StepControlName.Location = new System.Drawing.Point(73, 67);
            this._StepControlName.Name = "_StepControlName";
            this._StepControlName.Size = new System.Drawing.Size(125, 23);
            this._StepControlName.TabIndex = 380;
            this._StepControlName.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 43);
            this.button1.TabIndex = 385;
            this.button1.Text = "运行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 步骤名字
            // 
            this.步骤名字.Location = new System.Drawing.Point(432, 41);
            this.步骤名字.Name = "步骤名字";
            this.步骤名字.ReadOnly = true;
            this.步骤名字.Size = new System.Drawing.Size(200, 25);
            this.步骤名字.TabIndex = 386;
            this.步骤名字.Text = "A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 387;
            this.label4.Text = "步骤名字:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 389;
            this.label5.Text = "步骤号:";
            // 
            // 步骤号
            // 
            this.步骤号.Location = new System.Drawing.Point(432, 72);
            this.步骤号.Name = "步骤号";
            this.步骤号.ReadOnly = true;
            this.步骤号.Size = new System.Drawing.Size(200, 25);
            this.步骤号.TabIndex = 388;
            this.步骤号.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 391;
            this.label6.Text = "步骤类型:";
            // 
            // 步骤类型
            // 
            this.步骤类型.Location = new System.Drawing.Point(432, 101);
            this.步骤类型.Name = "步骤类型";
            this.步骤类型.ReadOnly = true;
            this.步骤类型.Size = new System.Drawing.Size(200, 25);
            this.步骤类型.TabIndex = 390;
            this.步骤类型.Text = "A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(351, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 393;
            this.label7.Text = "步骤用时:";
            // 
            // 步骤用时
            // 
            this.步骤用时.Location = new System.Drawing.Point(432, 132);
            this.步骤用时.Name = "步骤用时";
            this.步骤用时.ReadOnly = true;
            this.步骤用时.Size = new System.Drawing.Size(200, 25);
            this.步骤用时.TabIndex = 392;
            this.步骤用时.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(351, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 395;
            this.label8.Text = "步骤结果:";
            // 
            // 步骤结果
            // 
            this.步骤结果.Location = new System.Drawing.Point(432, 163);
            this.步骤结果.Name = "步骤结果";
            this.步骤结果.ReadOnly = true;
            this.步骤结果.Size = new System.Drawing.Size(200, 25);
            this.步骤结果.TabIndex = 394;
            this.步骤结果.Text = "OK";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 397;
            this.label9.Text = "步骤跳转:";
            // 
            // 步骤跳转
            // 
            this.步骤跳转.Location = new System.Drawing.Point(432, 194);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 399;
            this.label2.Text = "速度:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 400;
            this.label3.Text = "加速度:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 15);
            this.label10.TabIndex = 401;
            this.label10.Text = "位置:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 202);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 402;
            this.label11.Text = "减速度:";
            // 
            // 位置textBox1
            // 
            this.位置textBox1.Location = new System.Drawing.Point(73, 100);
            this.位置textBox1.Name = "位置textBox1";
            this.位置textBox1.Size = new System.Drawing.Size(76, 25);
            this.位置textBox1.TabIndex = 403;
            this.位置textBox1.TextChanged += new System.EventHandler(this.位置textBox1_TextChanged);
            // 
            // 速度textBox2
            // 
            this.速度textBox2.Location = new System.Drawing.Point(73, 133);
            this.速度textBox2.Name = "速度textBox2";
            this.速度textBox2.Size = new System.Drawing.Size(125, 25);
            this.速度textBox2.TabIndex = 404;
            this.速度textBox2.TextChanged += new System.EventHandler(this.速度textBox2_TextChanged);
            // 
            // 加速度textBox3
            // 
            this.加速度textBox3.Location = new System.Drawing.Point(73, 164);
            this.加速度textBox3.Name = "加速度textBox3";
            this.加速度textBox3.Size = new System.Drawing.Size(125, 25);
            this.加速度textBox3.TabIndex = 405;
            this.加速度textBox3.TextChanged += new System.EventHandler(this.加速度textBox3_TextChanged);
            // 
            // 减速度textBox4
            // 
            this.减速度textBox4.Location = new System.Drawing.Point(73, 194);
            this.减速度textBox4.Name = "减速度textBox4";
            this.减速度textBox4.Size = new System.Drawing.Size(125, 25);
            this.减速度textBox4.TabIndex = 406;
            this.减速度textBox4.TextChanged += new System.EventHandler(this.减速度textBox4_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(155, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 29);
            this.button2.TabIndex = 407;
            this.button2.Text = "Get";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // _AxisName
            // 
            this._AxisName.FormattingEnabled = true;
            this._AxisName.Location = new System.Drawing.Point(137, 225);
            this._AxisName.Name = "_AxisName";
            this._AxisName.Size = new System.Drawing.Size(125, 23);
            this._AxisName.TabIndex = 410;
            this._AxisName.SelectedIndexChanged += new System.EventHandler(this._AxisName_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(70, 228);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 15);
            this.label12.TabIndex = 409;
            this.label12.Text = "Aixs名字:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(137, 255);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 33);
            this.button3.TabIndex = 411;
            this.button3.Text = "添加";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dgv_deviceList
            // 
            this.dgv_deviceList.AllowUserToAddRows = false;
            this.dgv_deviceList.AllowUserToDeleteRows = false;
            this.dgv_deviceList.AllowUserToResizeColumns = false;
            this.dgv_deviceList.AllowUserToResizeRows = false;
            this.dgv_deviceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_deviceList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_deviceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_deviceList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_deviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_deviceList.ColumnHeadersVisible = false;
            this.dgv_deviceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column1});
            this.dgv_deviceList.Location = new System.Drawing.Point(285, 228);
            this.dgv_deviceList.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_deviceList.MultiSelect = false;
            this.dgv_deviceList.Name = "dgv_deviceList";
            this.dgv_deviceList.ReadOnly = true;
            this.dgv_deviceList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_deviceList.RowHeadersVisible = false;
            this.dgv_deviceList.RowTemplate.Height = 23;
            this.dgv_deviceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_deviceList.Size = new System.Drawing.Size(347, 196);
            this.dgv_deviceList.TabIndex = 412;
            this.dgv_deviceList.TabStop = false;
            this.dgv_deviceList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_deviceList_CellClick);
            this.dgv_deviceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_deviceList_CellContentClick);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.MinimumWidth = 111;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 111;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(137, 294);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 33);
            this.button4.TabIndex = 413;
            this.button4.Text = "移除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Aixs_more_CtronFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 428);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dgv_deviceList);
            this.Controls.Add(this.button3);
            this.Controls.Add(this._AxisName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.减速度textBox4);
            this.Controls.Add(this.加速度textBox3);
            this.Controls.Add(this.速度textBox2);
            this.Controls.Add(this.位置textBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
            this.Controls.Add(this._StepControlName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TOOLName);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Aixs_more_CtronFrom";
            this.Text = "OutPut_Pulse";
            this.Load += new System.EventHandler(this.OutPut_Pulse_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutPut_PulseFrom_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OutPut_PulseFrom_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OutPut_PulseFrom_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.Label TOOLName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _StepControlName;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox 位置textBox1;
        private System.Windows.Forms.TextBox 速度textBox2;
        private System.Windows.Forms.TextBox 加速度textBox3;
        private System.Windows.Forms.TextBox 减速度textBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox _AxisName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.DataGridView dgv_deviceList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button button4;
    }
}