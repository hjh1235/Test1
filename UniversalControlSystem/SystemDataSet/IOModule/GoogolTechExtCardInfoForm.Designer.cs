namespace UniversalControlSystem
{
    partial class GoogolTechExtCardInfoForm
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
            this.btn_SelectDLLFile = new System.Windows.Forms.Button();
            this.btn_SelectParamFile = new System.Windows.Forms.Button();
            this.cmb_ExtCardNumber = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_DllName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxConfigName = new System.Windows.Forms.TextBox();
            this.comboBoxCardNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_SelectDLLFile
            // 
            this.btn_SelectDLLFile.Location = new System.Drawing.Point(508, 280);
            this.btn_SelectDLLFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SelectDLLFile.Name = "btn_SelectDLLFile";
            this.btn_SelectDLLFile.Size = new System.Drawing.Size(100, 29);
            this.btn_SelectDLLFile.TabIndex = 39;
            this.btn_SelectDLLFile.Text = "选择文件";
            this.btn_SelectDLLFile.UseVisualStyleBackColor = true;
            this.btn_SelectDLLFile.Click += new System.EventHandler(this.btn_SelectDLLFile_Click);
            // 
            // btn_SelectParamFile
            // 
            this.btn_SelectParamFile.Location = new System.Drawing.Point(508, 244);
            this.btn_SelectParamFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SelectParamFile.Name = "btn_SelectParamFile";
            this.btn_SelectParamFile.Size = new System.Drawing.Size(100, 29);
            this.btn_SelectParamFile.TabIndex = 38;
            this.btn_SelectParamFile.Text = "选择文件";
            this.btn_SelectParamFile.UseVisualStyleBackColor = true;
            this.btn_SelectParamFile.Click += new System.EventHandler(this.btn_SelectParamFile_Click);
            // 
            // cmb_ExtCardNumber
            // 
            this.cmb_ExtCardNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ExtCardNumber.FormattingEnabled = true;
            this.cmb_ExtCardNumber.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.cmb_ExtCardNumber.Location = new System.Drawing.Point(317, 207);
            this.cmb_ExtCardNumber.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ExtCardNumber.Name = "cmb_ExtCardNumber";
            this.cmb_ExtCardNumber.Size = new System.Drawing.Size(181, 23);
            this.cmb_ExtCardNumber.TabIndex = 37;
            this.cmb_ExtCardNumber.SelectedIndexChanged += new System.EventHandler(this.cmb_ExtCardNumber_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 211);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 36;
            this.label6.Text = "拓展卡号";
            // 
            // txt_DllName
            // 
            this.txt_DllName.Enabled = false;
            this.txt_DllName.Location = new System.Drawing.Point(317, 280);
            this.txt_DllName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DllName.Name = "txt_DllName";
            this.txt_DllName.Size = new System.Drawing.Size(181, 25);
            this.txt_DllName.TabIndex = 35;
            this.txt_DllName.TextChanged += new System.EventHandler(this.txt_DllName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 284);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 34;
            this.label5.Text = "DLL文件名";
            // 
            // textBoxConfigName
            // 
            this.textBoxConfigName.Enabled = false;
            this.textBoxConfigName.Location = new System.Drawing.Point(317, 246);
            this.textBoxConfigName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxConfigName.Name = "textBoxConfigName";
            this.textBoxConfigName.Size = new System.Drawing.Size(181, 25);
            this.textBoxConfigName.TabIndex = 33;
            this.textBoxConfigName.TextChanged += new System.EventHandler(this.textBoxConfigName_TextChanged);
            // 
            // comboBoxCardNo
            // 
            this.comboBoxCardNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCardNo.FormattingEnabled = true;
            this.comboBoxCardNo.Items.AddRange(new object[] {
            "0"});
            this.comboBoxCardNo.Location = new System.Drawing.Point(317, 175);
            this.comboBoxCardNo.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCardNo.Name = "comboBoxCardNo";
            this.comboBoxCardNo.Size = new System.Drawing.Size(181, 23);
            this.comboBoxCardNo.TabIndex = 32;
            this.comboBoxCardNo.SelectedIndexChanged += new System.EventHandler(this.comboBoxCardNo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 250);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "配置文件名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 178);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "控制卡号";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(293, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 29);
            this.label1.TabIndex = 29;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GoogolTechExtCardInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 653);
            this.Controls.Add(this.btn_SelectDLLFile);
            this.Controls.Add(this.btn_SelectParamFile);
            this.Controls.Add(this.cmb_ExtCardNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_DllName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxConfigName);
            this.Controls.Add(this.comboBoxCardNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GoogolTechExtCardInfoForm";
            this.Text = "GoogolTechExtCardInfoForm";
            this.Load += new System.EventHandler(this.GoogolTechExtCardInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SelectDLLFile;
        private System.Windows.Forms.Button btn_SelectParamFile;
        private System.Windows.Forms.ComboBox cmb_ExtCardNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_DllName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxConfigName;
        private System.Windows.Forms.ComboBox comboBoxCardNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}