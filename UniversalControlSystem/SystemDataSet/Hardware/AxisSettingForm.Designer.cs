namespace UniversalControlSystem
{
    partial class AxisSettingForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxPlusToMM = new System.Windows.Forms.ComboBox();
            this.textBoxOrgSpd = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxDec = new System.Windows.Forms.TextBox();
            this.textBoxAcc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_Alias = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBoxCardName = new System.Windows.Forms.ComboBox();
            this.comboBoxAxisNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 412);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(456, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(303, 29);
            this.label3.TabIndex = 30;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.comboBoxPlusToMM);
            this.groupBox2.Controls.Add(this.textBoxOrgSpd);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.textBoxSpeed);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textBoxDec);
            this.groupBox2.Controls.Add(this.textBoxAcc);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(50, 274);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1185, 125);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Jog运动";
            // 
            // comboBoxPlusToMM
            // 
            this.comboBoxPlusToMM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxPlusToMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlusToMM.FormattingEnabled = true;
            this.comboBoxPlusToMM.Items.AddRange(new object[] {
            "0.0001",
            "0.001",
            "0.005",
            "0.0045",
            "0.0025",
            "0.002",
            "0.0016",
            "0.0015",
            "0.01",
            "0.05",
            "0.1",
            "0.5",
            "1"});
            this.comboBoxPlusToMM.Location = new System.Drawing.Point(731, 81);
            this.comboBoxPlusToMM.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPlusToMM.Name = "comboBoxPlusToMM";
            this.comboBoxPlusToMM.Size = new System.Drawing.Size(140, 23);
            this.comboBoxPlusToMM.TabIndex = 20;
            this.comboBoxPlusToMM.SelectionChangeCommitted += new System.EventHandler(this.comboBoxAxisNo_SelectionChangeCommitted);
            // 
            // textBoxOrgSpd
            // 
            this.textBoxOrgSpd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxOrgSpd.Location = new System.Drawing.Point(533, 81);
            this.textBoxOrgSpd.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxOrgSpd.Name = "textBoxOrgSpd";
            this.textBoxOrgSpd.Size = new System.Drawing.Size(143, 25);
            this.textBoxOrgSpd.TabIndex = 48;
            this.textBoxOrgSpd.TextChanged += new System.EventHandler(this.textBoxAcc_Validated);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(721, 45);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 25);
            this.label10.TabIndex = 29;
            this.label10.Text = "脉冲当量(mm/1000)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Location = new System.Drawing.Point(25, 44);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(121, 25);
            this.label17.TabIndex = 41;
            this.label17.Text = "加速度(mm/s2)";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(321, 46);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(168, 25);
            this.label15.TabIndex = 39;
            this.label15.Text = "手动运行速度(mm/s)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxSpeed.Location = new System.Drawing.Point(332, 81);
            this.textBoxSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.Size = new System.Drawing.Size(131, 25);
            this.textBoxSpeed.TabIndex = 44;
            this.textBoxSpeed.TextChanged += new System.EventHandler(this.textBoxAcc_Validated);
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(171, 44);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 25);
            this.label14.TabIndex = 38;
            this.label14.Text = "减速度(mm/S2)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDec
            // 
            this.textBoxDec.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxDec.Location = new System.Drawing.Point(169, 79);
            this.textBoxDec.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDec.Name = "textBoxDec";
            this.textBoxDec.Size = new System.Drawing.Size(123, 25);
            this.textBoxDec.TabIndex = 43;
            this.textBoxDec.TextChanged += new System.EventHandler(this.textBoxAcc_Validated);
            // 
            // textBoxAcc
            // 
            this.textBoxAcc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxAcc.Location = new System.Drawing.Point(25, 78);
            this.textBoxAcc.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAcc.Name = "textBoxAcc";
            this.textBoxAcc.Size = new System.Drawing.Size(120, 25);
            this.textBoxAcc.TabIndex = 42;
            this.textBoxAcc.Validated += new System.EventHandler(this.textBoxAcc_Validated);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(533, 44);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 25);
            this.label11.TabIndex = 35;
            this.label11.Text = "搜原点速度(mm/s)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txt_Alias);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.comboBoxCardName);
            this.groupBox1.Controls.Add(this.comboBoxAxisNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(50, 140);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1185, 100);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "轴信息";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(376, 46);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 15);
            this.label22.TabIndex = 63;
            this.label22.Text = "轴别名：";
            // 
            // txt_Alias
            // 
            this.txt_Alias.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Alias.Location = new System.Drawing.Point(445, 39);
            this.txt_Alias.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Alias.Name = "txt_Alias";
            this.txt_Alias.Size = new System.Drawing.Size(128, 25);
            this.txt_Alias.TabIndex = 54;
            this.txt_Alias.Validated += new System.EventHandler(this.textBoxAcc_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 59;
            this.label2.Text = "轴号：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 45);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 15);
            this.label21.TabIndex = 58;
            this.label21.Text = "卡号：";
            // 
            // comboBoxCardName
            // 
            this.comboBoxCardName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxCardName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCardName.FormattingEnabled = true;
            this.comboBoxCardName.Items.AddRange(new object[] {
            "0"});
            this.comboBoxCardName.Location = new System.Drawing.Point(67, 40);
            this.comboBoxCardName.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCardName.Name = "comboBoxCardName";
            this.comboBoxCardName.Size = new System.Drawing.Size(97, 23);
            this.comboBoxCardName.TabIndex = 53;
            this.comboBoxCardName.SelectionChangeCommitted += new System.EventHandler(this.comboBoxAxisNo_SelectionChangeCommitted);
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
            "7"});
            this.comboBoxAxisNo.Location = new System.Drawing.Point(245, 41);
            this.comboBoxAxisNo.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAxisNo.Name = "comboBoxAxisNo";
            this.comboBoxAxisNo.Size = new System.Drawing.Size(97, 23);
            this.comboBoxAxisNo.TabIndex = 57;
            this.comboBoxAxisNo.SelectionChangeCommitted += new System.EventHandler(this.comboBoxAxisNo_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 52;
            // 
            // AxisSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 412);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AxisSettingForm";
            this.Text = "轴设置";
            this.Load += new System.EventHandler(this.AxisSettingForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxPlusToMM;
        private System.Windows.Forms.TextBox textBoxOrgSpd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxDec;
        private System.Windows.Forms.TextBox textBoxAcc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_Alias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBoxCardName;
        private System.Windows.Forms.ComboBox comboBoxAxisNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}