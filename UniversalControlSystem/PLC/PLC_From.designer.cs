namespace UniversalControlSystem
{
    partial class PLC_From
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewNFHardWare = new System.Windows.Forms.ListView();
            this.IOModuleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Save_Other_Date = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.textBoxHardWareName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_Hd = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PLCName = new System.Windows.Forms.ComboBox();
            this.dgv_deviceList = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceList)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(106)))), ((int)(((byte)(175)))));
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(419, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "PLC硬件设定窗口";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(297, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 624);
            this.panel1.TabIndex = 2;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 104;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Vender";
            this.columnHeader2.Width = 81;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 105;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(106)))), ((int)(((byte)(175)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(297, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1046, 35);
            this.panel2.TabIndex = 7;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "卡名";
            this.columnHeader4.Width = 104;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "功能";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "型号";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 88;
            // 
            // listViewNFHardWare
            // 
            this.listViewNFHardWare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewNFHardWare.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IOModuleName,
            this.Type});
            this.listViewNFHardWare.FullRowSelect = true;
            this.listViewNFHardWare.GridLines = true;
            this.listViewNFHardWare.Location = new System.Drawing.Point(1, 58);
            this.listViewNFHardWare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewNFHardWare.Name = "listViewNFHardWare";
            this.listViewNFHardWare.Size = new System.Drawing.Size(287, 466);
            this.listViewNFHardWare.TabIndex = 8;
            this.listViewNFHardWare.UseCompatibleStateImageBehavior = false;
            this.listViewNFHardWare.View = System.Windows.Forms.View.Details;
            this.listViewNFHardWare.Visible = false;
            this.listViewNFHardWare.SelectedIndexChanged += new System.EventHandler(this.listViewNFHardWare_SelectedIndexChanged);
            // 
            // IOModuleName
            // 
            this.IOModuleName.Text = "PLC名称";
            this.IOModuleName.Width = 100;
            // 
            // Type
            // 
            this.Type.Text = "型号";
            this.Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Type.Width = 110;
            // 
            // Save_Other_Date
            // 
            this.Save_Other_Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Save_Other_Date.Location = new System.Drawing.Point(227, 616);
            this.Save_Other_Date.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Save_Other_Date.Name = "Save_Other_Date";
            this.Save_Other_Date.Size = new System.Drawing.Size(61, 32);
            this.Save_Other_Date.TabIndex = 11;
            this.Save_Other_Date.Text = "保存";
            this.Save_Other_Date.UseVisualStyleBackColor = true;
            this.Save_Other_Date.Visible = false;
            this.Save_Other_Date.Click += new System.EventHandler(this.Save_Other_Date_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(73, 600);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(125, 36);
            this.buttonAdd.TabIndex = 13;
            this.buttonAdd.Text = "添加硬件";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemove.Location = new System.Drawing.Point(73, 642);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(125, 38);
            this.buttonRemove.TabIndex = 14;
            this.buttonRemove.Text = "删除硬件";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // textBoxHardWareName
            // 
            this.textBoxHardWareName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxHardWareName.Location = new System.Drawing.Point(115, 534);
            this.textBoxHardWareName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHardWareName.Name = "textBoxHardWareName";
            this.textBoxHardWareName.Size = new System.Drawing.Size(125, 25);
            this.textBoxHardWareName.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 569);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "模式";
            this.label3.Visible = false;
            // 
            // combo_Hd
            // 
            this.combo_Hd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.combo_Hd.FormattingEnabled = true;
            this.combo_Hd.Items.AddRange(new object[] {
            "模拟量读取",
            "模拟量输出"});
            this.combo_Hd.Location = new System.Drawing.Point(217, 652);
            this.combo_Hd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combo_Hd.Name = "combo_Hd";
            this.combo_Hd.Size = new System.Drawing.Size(69, 23);
            this.combo_Hd.TabIndex = 16;
            this.combo_Hd.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 539);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "硬件名";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 573);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "型号";
            // 
            // PLCName
            // 
            this.PLCName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PLCName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PLCName.FormattingEnabled = true;
            this.PLCName.Location = new System.Drawing.Point(115, 569);
            this.PLCName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PLCName.Name = "PLCName";
            this.PLCName.Size = new System.Drawing.Size(125, 23);
            this.PLCName.TabIndex = 19;
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
            this.dgv_deviceList.Location = new System.Drawing.Point(1, 58);
            this.dgv_deviceList.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_deviceList.MultiSelect = false;
            this.dgv_deviceList.Name = "dgv_deviceList";
            this.dgv_deviceList.ReadOnly = true;
            this.dgv_deviceList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_deviceList.RowHeadersVisible = false;
            this.dgv_deviceList.RowTemplate.Height = 23;
            this.dgv_deviceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_deviceList.Size = new System.Drawing.Size(285, 466);
            this.dgv_deviceList.TabIndex = 20;
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(106)))), ((int)(((byte)(175)))));
            this.panel3.Controls.Add(this.label5);
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Location = new System.Drawing.Point(6, 8);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 44);
            this.panel3.TabIndex = 145;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 1);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = " 通讯及设备列表";
            // 
            // PLC_From
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1348, 686);
            this.Controls.Add(this.dgv_deviceList);
            this.Controls.Add(this.listViewNFHardWare);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.PLCName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_Hd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.textBoxHardWareName);
            this.Controls.Add(this.Save_Other_Date);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PLC_From";
            this.Text = "FormHardSetting";
            this.Load += new System.EventHandler(this.FormHardSetting_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
//        private WorldGeneralLib.ListViewNF listViewNFHardWare;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        //private WorldGeneralLib.ListViewNF listViewIOCard;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView listViewNFHardWare;
        private System.Windows.Forms.ColumnHeader IOModuleName;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.Button Save_Other_Date;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.TextBox textBoxHardWareName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_Hd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox PLCName;
        public System.Windows.Forms.DataGridView dgv_deviceList;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}