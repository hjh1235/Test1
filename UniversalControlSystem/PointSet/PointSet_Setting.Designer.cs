namespace UniversalControlSystem
{
    partial class PointSet_Setting
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.dgv_deviceList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this._AxisName = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.移除点位 = new System.Windows.Forms.Button();
            this.添加点位 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.选中 = new System.Windows.Forms.Label();
            this.数据更新 = new System.Windows.Forms.Button();
            this.数据展示 = new System.Windows.Forms.RichTextBox();
            this.更新数据 = new System.Windows.Forms.Button();
            this.@__点位名称 = new System.Windows.Forms.TextBox();
            this.点位名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.点位数据 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.点位名称,
            this.点位数据,
            this.Column1,
            this.Column2});
            this.dataGridView.Location = new System.Drawing.Point(1, 34);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 10;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(833, 589);
            this.dataGridView.TabIndex = 22;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "输入展示";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1122, 26);
            this.panel1.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(1, 624);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1122, 29);
            this.panel2.TabIndex = 29;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(1036, 439);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 33);
            this.button4.TabIndex = 418;
            this.button4.Text = "移除轴";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgv_deviceList
            // 
            this.dgv_deviceList.AllowUserToAddRows = false;
            this.dgv_deviceList.AllowUserToDeleteRows = false;
            this.dgv_deviceList.AllowUserToResizeColumns = false;
            this.dgv_deviceList.AllowUserToResizeRows = false;
            this.dgv_deviceList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_deviceList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_deviceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_deviceList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_deviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_deviceList.ColumnHeadersVisible = false;
            this.dgv_deviceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column3,
            this.dataGridViewTextBoxColumn2});
            this.dgv_deviceList.Location = new System.Drawing.Point(860, 197);
            this.dgv_deviceList.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_deviceList.MultiSelect = false;
            this.dgv_deviceList.Name = "dgv_deviceList";
            this.dgv_deviceList.ReadOnly = true;
            this.dgv_deviceList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_deviceList.RowHeadersVisible = false;
            this.dgv_deviceList.RowTemplate.Height = 23;
            this.dgv_deviceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_deviceList.Size = new System.Drawing.Size(263, 195);
            this.dgv_deviceList.TabIndex = 417;
            this.dgv_deviceList.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 111;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 111;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(945, 439);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 33);
            this.button3.TabIndex = 416;
            this.button3.Text = "添加轴";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // _AxisName
            // 
            this._AxisName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._AxisName.FormattingEnabled = true;
            this._AxisName.Location = new System.Drawing.Point(986, 399);
            this._AxisName.Name = "_AxisName";
            this._AxisName.Size = new System.Drawing.Size(125, 23);
            this._AxisName.TabIndex = 415;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(919, 402);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 15);
            this.label12.TabIndex = 414;
            this.label12.Text = "Aixs名字:";
            // 
            // 移除点位
            // 
            this.移除点位.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.移除点位.Location = new System.Drawing.Point(1036, 527);
            this.移除点位.Name = "移除点位";
            this.移除点位.Size = new System.Drawing.Size(75, 33);
            this.移除点位.TabIndex = 422;
            this.移除点位.Text = "移除";
            this.移除点位.UseVisualStyleBackColor = true;
            this.移除点位.Click += new System.EventHandler(this.移除点位_Click);
            // 
            // 添加点位
            // 
            this.添加点位.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.添加点位.Location = new System.Drawing.Point(945, 527);
            this.添加点位.Name = "添加点位";
            this.添加点位.Size = new System.Drawing.Size(75, 33);
            this.添加点位.TabIndex = 421;
            this.添加点位.Text = "添加";
            this.添加点位.UseVisualStyleBackColor = true;
            this.添加点位.Click += new System.EventHandler(this.添加点位_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(903, 490);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 419;
            this.label2.Text = "点位名称:";
            // 
            // 选中
            // 
            this.选中.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.选中.AutoSize = true;
            this.选中.Location = new System.Drawing.Point(859, 34);
            this.选中.Name = "选中";
            this.选中.Size = new System.Drawing.Size(37, 15);
            this.选中.TabIndex = 423;
            this.选中.Text = "选中";
            // 
            // 数据更新
            // 
            this.数据更新.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.数据更新.Location = new System.Drawing.Point(932, 579);
            this.数据更新.Name = "数据更新";
            this.数据更新.Size = new System.Drawing.Size(179, 39);
            this.数据更新.TabIndex = 424;
            this.数据更新.Text = "数据更新";
            this.数据更新.UseVisualStyleBackColor = true;
            this.数据更新.Visible = false;
            this.数据更新.Click += new System.EventHandler(this.数据更新_Click);
            // 
            // 数据展示
            // 
            this.数据展示.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.数据展示.Location = new System.Drawing.Point(859, 52);
            this.数据展示.Name = "数据展示";
            this.数据展示.Size = new System.Drawing.Size(252, 71);
            this.数据展示.TabIndex = 425;
            this.数据展示.Text = "";
            // 
            // 更新数据
            // 
            this.更新数据.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.更新数据.Location = new System.Drawing.Point(932, 129);
            this.更新数据.Name = "更新数据";
            this.更新数据.Size = new System.Drawing.Size(179, 39);
            this.更新数据.TabIndex = 426;
            this.更新数据.Text = "更新";
            this.更新数据.UseVisualStyleBackColor = true;
            this.更新数据.Click += new System.EventHandler(this.更新数据_Click);
            // 
            // __点位名称
            // 
            this.@__点位名称.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.@__点位名称.Location = new System.Drawing.Point(984, 487);
            this.@__点位名称.Name = "__点位名称";
            this.@__点位名称.Size = new System.Drawing.Size(127, 25);
            this.@__点位名称.TabIndex = 427;
            // 
            // 点位名称
            // 
            this.点位名称.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.点位名称.HeaderText = "点位名称";
            this.点位名称.Name = "点位名称";
            this.点位名称.ReadOnly = true;
            this.点位名称.Width = 96;
            // 
            // 点位数据
            // 
            this.点位数据.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.点位数据.HeaderText = "点位数据";
            this.点位数据.Name = "点位数据";
            this.点位数据.ReadOnly = true;
            this.点位数据.Width = 96;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.HeaderText = "  Get  ";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 62;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column2.HeaderText = "  Go   ";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 62;
            // 
            // PointSet_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 652);
            this.Controls.Add(this.@__点位名称);
            this.Controls.Add(this.更新数据);
            this.Controls.Add(this.数据展示);
            this.Controls.Add(this.数据更新);
            this.Controls.Add(this.选中);
            this.Controls.Add(this.移除点位);
            this.Controls.Add(this.添加点位);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dgv_deviceList);
            this.Controls.Add(this.button3);
            this.Controls.Add(this._AxisName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PointSet_Setting";
            this.Text = "FormAxisSetting";
            this.Load += new System.EventHandler(this.FormAxisSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.DataGridView dgv_deviceList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox _AxisName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button 移除点位;
        private System.Windows.Forms.Button 添加点位;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label 选中;
        private System.Windows.Forms.Button 数据更新;
        private System.Windows.Forms.RichTextBox 数据展示;
        private System.Windows.Forms.Button 更新数据;
        private System.Windows.Forms.TextBox __点位名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 点位名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 点位数据;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
    }
}