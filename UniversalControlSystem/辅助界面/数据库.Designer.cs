namespace UniversalControlSystem
{
    partial class 数据库
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.str_ = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.获取 = new System.Windows.Forms.Button();
            this.dataGridViewSN = new System.Windows.Forms.DataGridView();
            this.sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.手动添加SN = new System.Windows.Forms.TextBox();
            this.手动过站 = new System.Windows.Forms.Button();
            this.删除 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSN)).BeginInit();
            this.SuspendLayout();
            // 
            // str_
            // 
            this.str_.FormattingEnabled = true;
            this.str_.Items.AddRange(new object[] {
            "L_Clear_Data",
            "R_Clear_Data"});
            this.str_.Location = new System.Drawing.Point(64, 35);
            this.str_.Name = "str_";
            this.str_.Size = new System.Drawing.Size(266, 23);
            this.str_.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "表名:";
            // 
            // 获取
            // 
            this.获取.Location = new System.Drawing.Point(438, 91);
            this.获取.Name = "获取";
            this.获取.Size = new System.Drawing.Size(116, 86);
            this.获取.TabIndex = 2;
            this.获取.Text = "获取";
            this.获取.UseVisualStyleBackColor = true;
            this.获取.Click += new System.EventHandler(this.获取_Click);
            // 
            // dataGridViewSN
            // 
            this.dataGridViewSN.AllowUserToAddRows = false;
            this.dataGridViewSN.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSN.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sn});
            this.dataGridViewSN.Location = new System.Drawing.Point(64, 91);
            this.dataGridViewSN.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewSN.Name = "dataGridViewSN";
            this.dataGridViewSN.RowHeadersWidth = 10;
            this.dataGridViewSN.RowTemplate.Height = 23;
            this.dataGridViewSN.Size = new System.Drawing.Size(350, 279);
            this.dataGridViewSN.TabIndex = 240;
            this.dataGridViewSN.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSN_CellClick);
            this.dataGridViewSN.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSN_CellContentClick);
            // 
            // sn
            // 
            this.sn.FillWeight = 500F;
            this.sn.HeaderText = "sn";
            this.sn.Name = "sn";
            this.sn.Width = 300;
            // 
            // 手动添加SN
            // 
            this.手动添加SN.Location = new System.Drawing.Point(64, 440);
            this.手动添加SN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.手动添加SN.Name = "手动添加SN";
            this.手动添加SN.Size = new System.Drawing.Size(292, 25);
            this.手动添加SN.TabIndex = 242;
            // 
            // 手动过站
            // 
            this.手动过站.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.手动过站.Location = new System.Drawing.Point(64, 378);
            this.手动过站.Margin = new System.Windows.Forms.Padding(4);
            this.手动过站.Name = "手动过站";
            this.手动过站.Size = new System.Drawing.Size(91, 40);
            this.手动过站.TabIndex = 241;
            this.手动过站.Text = "手动过站";
            this.手动过站.UseVisualStyleBackColor = false;
            this.手动过站.Click += new System.EventHandler(this.手动过站_Click);
            // 
            // 删除
            // 
            this.删除.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.删除.Location = new System.Drawing.Point(438, 208);
            this.删除.Margin = new System.Windows.Forms.Padding(4);
            this.删除.Name = "删除";
            this.删除.Size = new System.Drawing.Size(116, 82);
            this.删除.TabIndex = 243;
            this.删除.Text = "删除";
            this.删除.UseVisualStyleBackColor = false;
            this.删除.Click += new System.EventHandler(this.删除_Click);
            // 
            // 数据库
            // 
            this.ClientSize = new System.Drawing.Size(933, 610);
            this.Controls.Add(this.删除);
            this.Controls.Add(this.手动添加SN);
            this.Controls.Add(this.手动过站);
            this.Controls.Add(this.dataGridViewSN);
            this.Controls.Add(this.获取);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.str_);
            this.Name = "数据库";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox str_;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button 获取;
        private System.Windows.Forms.DataGridView dataGridViewSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn sn;
        private System.Windows.Forms.TextBox 手动添加SN;
        private System.Windows.Forms.Button 手动过站;
        private System.Windows.Forms.Button 删除;
    }
}