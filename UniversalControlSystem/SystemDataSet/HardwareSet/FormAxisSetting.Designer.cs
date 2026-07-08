namespace UniversalControlSystem
{
    partial class FormAxisSetting
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
            this.comboBoxCardNo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxAxisNo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Acc = new System.Windows.Forms.TextBox();
            this.txt_Dec = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Speed = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_GoHomeSpeed = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxPlusFeed = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxCardNo
            // 
            this.comboBoxCardNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCardNo.FormattingEnabled = true;
            this.comboBoxCardNo.Items.AddRange(new object[] {
            "0"});
            this.comboBoxCardNo.Location = new System.Drawing.Point(365, 123);
            this.comboBoxCardNo.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCardNo.Name = "comboBoxCardNo";
            this.comboBoxCardNo.Size = new System.Drawing.Size(181, 23);
            this.comboBoxCardNo.TabIndex = 30;
            this.comboBoxCardNo.SelectedIndexChanged += new System.EventHandler(this.comboBoxCardNo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "运动控制卡号";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(251, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 29);
            this.label1.TabIndex = 27;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(311, 171);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 38;
            this.label6.Text = "轴号";
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
            "7",
            "8"});
            this.comboBoxAxisNo.Location = new System.Drawing.Point(365, 163);
            this.comboBoxAxisNo.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAxisNo.Name = "comboBoxAxisNo";
            this.comboBoxAxisNo.Size = new System.Drawing.Size(181, 23);
            this.comboBoxAxisNo.TabIndex = 39;
            this.comboBoxAxisNo.SelectedIndexChanged += new System.EventHandler(this.comboBoxAxisNo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 207);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 15);
            this.label7.TabIndex = 40;
            this.label7.Text = "加速度(mm/s2)";
            // 
            // txt_Acc
            // 
            this.txt_Acc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Acc.Location = new System.Drawing.Point(366, 204);
            this.txt_Acc.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Acc.Name = "txt_Acc";
            this.txt_Acc.Size = new System.Drawing.Size(181, 25);
            this.txt_Acc.TabIndex = 41;
            this.txt_Acc.TextChanged += new System.EventHandler(this.txt_Acc_TextChanged);
            this.txt_Acc.Validated += new System.EventHandler(this.txt_Acc_Validated);
            // 
            // txt_Dec
            // 
            this.txt_Dec.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Dec.Location = new System.Drawing.Point(365, 246);
            this.txt_Dec.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Dec.Name = "txt_Dec";
            this.txt_Dec.Size = new System.Drawing.Size(181, 25);
            this.txt_Dec.TabIndex = 43;
            this.txt_Dec.TextChanged += new System.EventHandler(this.txt_Dec_TextChanged);
            this.txt_Dec.Validated += new System.EventHandler(this.txt_Dec_Validated);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(260, 249);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 15);
            this.label8.TabIndex = 42;
            this.label8.Text = "减速度(mm/s2)";
            // 
            // txt_Speed
            // 
            this.txt_Speed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_Speed.Location = new System.Drawing.Point(365, 291);
            this.txt_Speed.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Speed.Name = "txt_Speed";
            this.txt_Speed.Size = new System.Drawing.Size(181, 25);
            this.txt_Speed.TabIndex = 45;
            this.txt_Speed.TextChanged += new System.EventHandler(this.txt_Speed_TextChanged);
            this.txt_Speed.Validated += new System.EventHandler(this.txt_Speed_Validated);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 294);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 15);
            this.label9.TabIndex = 44;
            this.label9.Text = "手动速度(mm/s)";
            // 
            // txt_GoHomeSpeed
            // 
            this.txt_GoHomeSpeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_GoHomeSpeed.Location = new System.Drawing.Point(365, 333);
            this.txt_GoHomeSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.txt_GoHomeSpeed.Name = "txt_GoHomeSpeed";
            this.txt_GoHomeSpeed.Size = new System.Drawing.Size(181, 25);
            this.txt_GoHomeSpeed.TabIndex = 47;
            this.txt_GoHomeSpeed.TextChanged += new System.EventHandler(this.txt_GoHomeSpeed_TextChanged);
            this.txt_GoHomeSpeed.Validated += new System.EventHandler(this.txt_GoHomeSpeed_Validated);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(227, 336);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 15);
            this.label10.TabIndex = 46;
            this.label10.Text = "搜原点速度(mm/s)";
            // 
            // comboBoxPlusFeed
            // 
            this.comboBoxPlusFeed.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxPlusFeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlusFeed.FormattingEnabled = true;
            this.comboBoxPlusFeed.Items.AddRange(new object[] {
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
            this.comboBoxPlusFeed.Location = new System.Drawing.Point(366, 381);
            this.comboBoxPlusFeed.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPlusFeed.Name = "comboBoxPlusFeed";
            this.comboBoxPlusFeed.Size = new System.Drawing.Size(181, 23);
            this.comboBoxPlusFeed.TabIndex = 49;
            this.comboBoxPlusFeed.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlusFeed_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 385);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 48;
            this.label2.Text = "脉冲当量";
            // 
            // FormAxisSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 553);
            this.Controls.Add(this.comboBoxPlusFeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_GoHomeSpeed);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_Speed);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_Dec);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_Acc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxAxisNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxCardNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAxisSetting";
            this.Text = "FormAxisSetting";
            this.Load += new System.EventHandler(this.FormAxisSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxCardNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxAxisNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Acc;
        private System.Windows.Forms.TextBox txt_Dec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Speed;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_GoHomeSpeed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxPlusFeed;
        private System.Windows.Forms.Label label2;
    }
}