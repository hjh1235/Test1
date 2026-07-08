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
            this.txt_CardName = new System.Windows.Forms.TextBox();
            this.btn_SelectParamFile = new System.Windows.Forms.Button();
            this.btn_SelectDLLFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_DllName
            // 
            this.txt_DllName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_DllName.Enabled = false;
            this.txt_DllName.Location = new System.Drawing.Point(231, 176);
            this.txt_DllName.Name = "txt_DllName";
            this.txt_DllName.Size = new System.Drawing.Size(137, 21);
            this.txt_DllName.TabIndex = 22;
            this.txt_DllName.TextChanged += new System.EventHandler(this.txt_DllName_TextChanged);
            this.txt_DllName.Validated += new System.EventHandler(this.txt_DllName_Validated);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "DLL文件路径";
            // 
            // textBoxConfigName
            // 
            this.textBoxConfigName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxConfigName.Enabled = false;
            this.textBoxConfigName.Location = new System.Drawing.Point(230, 147);
            this.textBoxConfigName.Name = "textBoxConfigName";
            this.textBoxConfigName.Size = new System.Drawing.Size(137, 21);
            this.textBoxConfigName.TabIndex = 20;
            this.textBoxConfigName.TextChanged += new System.EventHandler(this.textBoxConfigName_TextChanged);
            this.textBoxConfigName.Validated += new System.EventHandler(this.textBoxConfigName_Validated);
            // 
            // comboBoxCardNo
            // 
            this.comboBoxCardNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCardNo.FormattingEnabled = true;
            this.comboBoxCardNo.Items.AddRange(new object[] {
            "0"});
            this.comboBoxCardNo.Location = new System.Drawing.Point(230, 90);
            this.comboBoxCardNo.Name = "comboBoxCardNo";
            this.comboBoxCardNo.Size = new System.Drawing.Size(137, 20);
            this.comboBoxCardNo.TabIndex = 19;
            this.comboBoxCardNo.SelectedIndexChanged += new System.EventHandler(this.comboBoxCardNo_SelectedIndexChanged);
            this.comboBoxCardNo.Validated += new System.EventHandler(this.comboBoxCardNo_Validated);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "配置文件路径";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "运动控制卡号";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(145, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "运动控制卡名";
            // 
            // txt_CardName
            // 
            this.txt_CardName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_CardName.Location = new System.Drawing.Point(230, 120);
            this.txt_CardName.Name = "txt_CardName";
            this.txt_CardName.Size = new System.Drawing.Size(137, 21);
            this.txt_CardName.TabIndex = 24;
            this.txt_CardName.TextChanged += new System.EventHandler(this.txt_CardName_TextChanged);
            this.txt_CardName.Validated += new System.EventHandler(this.txt_CardName_Validated);
            // 
            // btn_SelectParamFile
            // 
            this.btn_SelectParamFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_SelectParamFile.Location = new System.Drawing.Point(373, 145);
            this.btn_SelectParamFile.Name = "btn_SelectParamFile";
            this.btn_SelectParamFile.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectParamFile.TabIndex = 25;
            this.btn_SelectParamFile.Text = "选择文件";
            this.btn_SelectParamFile.UseVisualStyleBackColor = true;
            this.btn_SelectParamFile.Click += new System.EventHandler(this.btn_SelectParamFile_Click);
            // 
            // btn_SelectDLLFile
            // 
            this.btn_SelectDLLFile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_SelectDLLFile.Location = new System.Drawing.Point(373, 176);
            this.btn_SelectDLLFile.Name = "btn_SelectDLLFile";
            this.btn_SelectDLLFile.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectDLLFile.TabIndex = 26;
            this.btn_SelectDLLFile.Text = "选择文件";
            this.btn_SelectDLLFile.UseVisualStyleBackColor = true;
            this.btn_SelectDLLFile.Click += new System.EventHandler(this.btn_SelectDLLFile_Click);
            // 
            // GoolGaoHardSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 361);
            this.Controls.Add(this.btn_SelectDLLFile);
            this.Controls.Add(this.btn_SelectParamFile);
            this.Controls.Add(this.txt_CardName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_DllName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxConfigName);
            this.Controls.Add(this.comboBoxCardNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GoolGaoHardSettingForm";
            this.Text = "FormContorlHardSetting";
            this.Load += new System.EventHandler(this.FormContorlHardSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox txt_CardName;
        private System.Windows.Forms.Button btn_SelectParamFile;
        private System.Windows.Forms.Button btn_SelectDLLFile;
    }
}