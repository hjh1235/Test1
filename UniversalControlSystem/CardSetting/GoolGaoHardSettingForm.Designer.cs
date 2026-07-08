namespace UniversalControlSystem
{
    partial class GoolGaoHardSettingForm
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
            this.txt_DllName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxConfigName = new System.Windows.Forms.TextBox();
            this.comboBoxCardNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_CardPath = new System.Windows.Forms.TextBox();
            this.btn_SelectParamFile = new System.Windows.Forms.Button();
            this.btn_SelectDLLFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxModel = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_MaxAcc = new System.Windows.Forms.TextBox();
            this.txt_MaxSpeed = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_DllName
            // 
            this.txt_DllName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_DllName.Enabled = false;
            this.txt_DllName.Location = new System.Drawing.Point(140, 192);
            this.txt_DllName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DllName.Name = "txt_DllName";
            this.txt_DllName.ReadOnly = true;
            this.txt_DllName.Size = new System.Drawing.Size(181, 25);
            this.txt_DllName.TabIndex = 22;
            this.txt_DllName.TextChanged += new System.EventHandler(this.txt_DllName_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 196);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "DLL文件路径";
            // 
            // textBoxConfigName
            // 
            this.textBoxConfigName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxConfigName.Enabled = false;
            this.textBoxConfigName.Location = new System.Drawing.Point(140, 158);
            this.textBoxConfigName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxConfigName.Name = "textBoxConfigName";
            this.textBoxConfigName.ReadOnly = true;
            this.textBoxConfigName.Size = new System.Drawing.Size(181, 25);
            this.textBoxConfigName.TabIndex = 20;
            this.textBoxConfigName.TextChanged += new System.EventHandler(this.textBoxConfigName_TextChanged);
            // 
            // comboBoxCardNo
            // 
            this.comboBoxCardNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCardNo.FormattingEnabled = true;
            this.comboBoxCardNo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBoxCardNo.Location = new System.Drawing.Point(140, 126);
            this.comboBoxCardNo.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCardNo.Name = "comboBoxCardNo";
            this.comboBoxCardNo.Size = new System.Drawing.Size(181, 23);
            this.comboBoxCardNo.TabIndex = 19;
            this.comboBoxCardNo.SelectedIndexChanged += new System.EventHandler(this.comboBoxCardNo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 163);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "配置文件路径";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "运动控制卡号";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(74, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 168);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "运动控制卡名";
            this.label2.Visible = false;
            // 
            // txt_CardPath
            // 
            this.txt_CardPath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_CardPath.Location = new System.Drawing.Point(139, 315);
            this.txt_CardPath.Margin = new System.Windows.Forms.Padding(4);
            this.txt_CardPath.Name = "txt_CardPath";
            this.txt_CardPath.ReadOnly = true;
            this.txt_CardPath.Size = new System.Drawing.Size(181, 25);
            this.txt_CardPath.TabIndex = 24;
            this.txt_CardPath.Visible = false;
            this.txt_CardPath.TextChanged += new System.EventHandler(this.txt_CardPath_TextChanged);
            // 
            // btn_SelectParamFile
            // 
            this.btn_SelectParamFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_SelectParamFile.Location = new System.Drawing.Point(329, 158);
            this.btn_SelectParamFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SelectParamFile.Name = "btn_SelectParamFile";
            this.btn_SelectParamFile.Size = new System.Drawing.Size(100, 29);
            this.btn_SelectParamFile.TabIndex = 25;
            this.btn_SelectParamFile.Text = "选择文件";
            this.btn_SelectParamFile.UseVisualStyleBackColor = true;
            this.btn_SelectParamFile.Click += new System.EventHandler(this.btn_SelectParamFile_Click);
            // 
            // btn_SelectDLLFile
            // 
            this.btn_SelectDLLFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_SelectDLLFile.Location = new System.Drawing.Point(329, 196);
            this.btn_SelectDLLFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SelectDLLFile.Name = "btn_SelectDLLFile";
            this.btn_SelectDLLFile.Size = new System.Drawing.Size(100, 29);
            this.btn_SelectDLLFile.TabIndex = 26;
            this.btn_SelectDLLFile.Text = "选择文件";
            this.btn_SelectDLLFile.UseVisualStyleBackColor = true;
            this.btn_SelectDLLFile.Click += new System.EventHandler(this.btn_SelectDLLFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.comboBoxModel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_MaxAcc);
            this.groupBox1.Controls.Add(this.txt_MaxSpeed);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_SelectDLLFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_SelectParamFile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_CardPath);
            this.groupBox1.Controls.Add(this.comboBoxCardNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxConfigName);
            this.groupBox1.Controls.Add(this.txt_DllName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(181, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(515, 428);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "卡模块设置";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(74, 49);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(303, 29);
            this.label11.TabIndex = 44;
            this.label11.Text = "label11";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(59, 98);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 42;
            this.label10.Text = "控制型号";
            this.label10.Visible = false;
            // 
            // comboBoxModel
            // 
            this.comboBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModel.FormattingEnabled = true;
            this.comboBoxModel.Items.AddRange(new object[] {
            "GTS",
            "GTN"});
            this.comboBoxModel.Location = new System.Drawing.Point(139, 95);
            this.comboBoxModel.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxModel.Name = "comboBoxModel";
            this.comboBoxModel.Size = new System.Drawing.Size(181, 23);
            this.comboBoxModel.TabIndex = 43;
            this.comboBoxModel.Visible = false;
            this.comboBoxModel.SelectedIndexChanged += new System.EventHandler(this.comboBoxModel_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(329, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 37;
            this.label9.Text = "pulse/ms";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 36;
            this.label8.Text = "pulse/ms^2";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-1, 262);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 15);
            this.label7.TabIndex = 35;
            this.label7.Text = "坐标系最大加速度";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 229);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 34;
            this.label6.Text = "坐标系最大速度";
            // 
            // txt_MaxAcc
            // 
            this.txt_MaxAcc.Location = new System.Drawing.Point(140, 259);
            this.txt_MaxAcc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_MaxAcc.Multiline = true;
            this.txt_MaxAcc.Name = "txt_MaxAcc";
            this.txt_MaxAcc.Size = new System.Drawing.Size(180, 24);
            this.txt_MaxAcc.TabIndex = 33;
            this.txt_MaxAcc.TextChanged += new System.EventHandler(this.txt_MaxAcc_TextChanged);
            this.txt_MaxAcc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MaxAcc_KeyPress);
            // 
            // txt_MaxSpeed
            // 
            this.txt_MaxSpeed.Location = new System.Drawing.Point(140, 226);
            this.txt_MaxSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_MaxSpeed.Multiline = true;
            this.txt_MaxSpeed.Name = "txt_MaxSpeed";
            this.txt_MaxSpeed.Size = new System.Drawing.Size(180, 24);
            this.txt_MaxSpeed.TabIndex = 32;
            this.txt_MaxSpeed.TextChanged += new System.EventHandler(this.txt_MaxSpeed_TextChanged);
            this.txt_MaxSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_MaxSpeed_KeyPress);
            // 
            // GoolGaoHardSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 652);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GoolGaoHardSettingForm";
            this.Text = "FormContorlHardSetting";
            this.Load += new System.EventHandler(this.FormContorlHardSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txt_DllName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxConfigName;
        private System.Windows.Forms.ComboBox comboBoxCardNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_CardPath;
        private System.Windows.Forms.Button btn_SelectParamFile;
        private System.Windows.Forms.Button btn_SelectDLLFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_MaxAcc;
        private System.Windows.Forms.TextBox txt_MaxSpeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxModel;
        private System.Windows.Forms.Label label11;
    }
}