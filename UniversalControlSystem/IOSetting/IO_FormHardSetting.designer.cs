namespace UniversalControlSystem
{
    partial class IO_FormHardSetting
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
            this.Function = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Save_IO_Date = new System.Windows.Forms.Button();
            this.ChangeIOName = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(238, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "IO硬件设定窗口";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(217, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 432);
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
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(217, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(632, 28);
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
            this.Function});
            this.listViewNFHardWare.FullRowSelect = true;
            this.listViewNFHardWare.GridLines = true;
            this.listViewNFHardWare.Location = new System.Drawing.Point(2, 3);
            this.listViewNFHardWare.Margin = new System.Windows.Forms.Padding(2);
            this.listViewNFHardWare.Name = "listViewNFHardWare";
            this.listViewNFHardWare.Size = new System.Drawing.Size(210, 395);
            this.listViewNFHardWare.TabIndex = 8;
            this.listViewNFHardWare.UseCompatibleStateImageBehavior = false;
            this.listViewNFHardWare.View = System.Windows.Forms.View.Details;
            this.listViewNFHardWare.SelectedIndexChanged += new System.EventHandler(this.listViewNFHardWare_SelectedIndexChanged);
            // 
            // IOModuleName
            // 
            this.IOModuleName.Text = "IO名称";
            this.IOModuleName.Width = 105;
            // 
            // Function
            // 
            this.Function.Text = "功能";
            this.Function.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Function.Width = 100;
            // 
            // Save_IO_Date
            // 
            this.Save_IO_Date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Save_IO_Date.Location = new System.Drawing.Point(147, 412);
            this.Save_IO_Date.Margin = new System.Windows.Forms.Padding(2);
            this.Save_IO_Date.Name = "Save_IO_Date";
            this.Save_IO_Date.Size = new System.Drawing.Size(42, 27);
            this.Save_IO_Date.TabIndex = 11;
            this.Save_IO_Date.Text = "保存";
            this.Save_IO_Date.UseVisualStyleBackColor = true;
            this.Save_IO_Date.Visible = false;
            this.Save_IO_Date.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangeIOName
            // 
            this.ChangeIOName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChangeIOName.Location = new System.Drawing.Point(62, 412);
            this.ChangeIOName.Margin = new System.Windows.Forms.Padding(2);
            this.ChangeIOName.Name = "ChangeIOName";
            this.ChangeIOName.Size = new System.Drawing.Size(81, 46);
            this.ChangeIOName.TabIndex = 12;
            this.ChangeIOName.Text = "改名";
            this.ChangeIOName.UseVisualStyleBackColor = true;
            this.ChangeIOName.Click += new System.EventHandler(this.ChangeIOName_Click);
            // 
            // IO_FormHardSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(853, 482);
            this.Controls.Add(this.ChangeIOName);
            this.Controls.Add(this.Save_IO_Date);
            this.Controls.Add(this.listViewNFHardWare);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IO_FormHardSetting";
            this.Text = "FormHardSetting";
            this.Activated += new System.EventHandler(this.IO_FormHardSetting_Activated);
            this.Load += new System.EventHandler(this.FormHardSetting_Load);
            this.Validated += new System.EventHandler(this.IO_FormHardSetting_Validated);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.ColumnHeader Function;
        private System.Windows.Forms.Button Save_IO_Date;
        private System.Windows.Forms.Button ChangeIOName;
    }
}