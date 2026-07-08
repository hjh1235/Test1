namespace UniversalControlSystem
{
    partial class DateGroup_Setting
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DateType = new System.Windows.Forms.TextBox();
            this.DateTypeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_date = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DateType);
            this.groupBox1.Controls.Add(this.DateTypeName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_date);
            this.groupBox1.Location = new System.Drawing.Point(214, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 362);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据设定";
            // 
            // DateType
            // 
            this.DateType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DateType.Location = new System.Drawing.Point(218, 104);
            this.DateType.Margin = new System.Windows.Forms.Padding(4);
            this.DateType.Name = "DateType";
            this.DateType.ReadOnly = true;
            this.DateType.Size = new System.Drawing.Size(181, 25);
            this.DateType.TabIndex = 43;
            this.DateType.Text = "INT";
            // 
            // DateTypeName
            // 
            this.DateTypeName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DateTypeName.Location = new System.Drawing.Point(218, 141);
            this.DateTypeName.Margin = new System.Windows.Forms.Padding(4);
            this.DateTypeName.Name = "DateTypeName";
            this.DateTypeName.ReadOnly = true;
            this.DateTypeName.Size = new System.Drawing.Size(181, 25);
            this.DateTypeName.TabIndex = 42;
            this.DateTypeName.Text = "NAME";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(603, 29);
            this.label1.TabIndex = 27;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "数据类型";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(142, 147);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 38;
            this.label6.Text = "数据名";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(127, 184);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 40;
            this.label7.Text = "默认数据";
            // 
            // txt_date
            // 
            this.txt_date.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_date.Location = new System.Drawing.Point(218, 181);
            this.txt_date.Margin = new System.Windows.Forms.Padding(4);
            this.txt_date.Name = "txt_date";
            this.txt_date.Size = new System.Drawing.Size(181, 25);
            this.txt_date.TabIndex = 41;
            this.txt_date.Text = "0";
            this.txt_date.TextChanged += new System.EventHandler(this.txt_date_TextChanged);
            this.txt_date.Leave += new System.EventHandler(this.txt_date_Leave);
            // 
            // DateGroup_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 652);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DateGroup_Setting";
            this.Text = "FormAxisSetting";
            this.Load += new System.EventHandler(this.FormAxisSetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_date;
        private System.Windows.Forms.TextBox DateType;
        private System.Windows.Forms.TextBox DateTypeName;
    }
}