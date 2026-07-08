namespace UniversalControlSystem
{
    partial class FlowMain
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
            this.dgv_deviceList = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.轴名称 = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.POS_ADD = new System.Windows.Forms.Button();
            this.POS_DEL = new System.Windows.Forms.Button();
            this.POS_dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POS_NAME = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewOutput = new System.Windows.Forms.DataGridView();
            this.名字 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.点位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Get = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Go = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.POS_dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).BeginInit();
            this.SuspendLayout();
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
            this.dgv_deviceList.Location = new System.Drawing.Point(4, 4);
            this.dgv_deviceList.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_deviceList.MultiSelect = false;
            this.dgv_deviceList.Name = "dgv_deviceList";
            this.dgv_deviceList.ReadOnly = true;
            this.dgv_deviceList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_deviceList.RowHeadersVisible = false;
            this.dgv_deviceList.RowTemplate.Height = 23;
            this.dgv_deviceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_deviceList.Size = new System.Drawing.Size(275, 437);
            this.dgv_deviceList.TabIndex = 147;
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
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 451);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 151;
            this.label3.Text = "轴名称:";
            // 
            // 轴名称
            // 
            this.轴名称.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.轴名称.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.轴名称.FormattingEnabled = true;
            this.轴名称.Location = new System.Drawing.Point(62, 448);
            this.轴名称.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.轴名称.Name = "轴名称";
            this.轴名称.Size = new System.Drawing.Size(217, 23);
            this.轴名称.TabIndex = 150;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(0, 481);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(125, 36);
            this.buttonAdd.TabIndex = 148;
            this.buttonAdd.Text = "添加硬件";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemove.Location = new System.Drawing.Point(137, 481);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(125, 38);
            this.buttonRemove.TabIndex = 149;
            this.buttonRemove.Text = "删除硬件";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 449);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 156;
            this.label1.Text = "点名称:";
            // 
            // POS_ADD
            // 
            this.POS_ADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.POS_ADD.Location = new System.Drawing.Point(4, 479);
            this.POS_ADD.Margin = new System.Windows.Forms.Padding(4);
            this.POS_ADD.Name = "POS_ADD";
            this.POS_ADD.Size = new System.Drawing.Size(125, 36);
            this.POS_ADD.TabIndex = 153;
            this.POS_ADD.Text = "添加硬件";
            this.POS_ADD.UseVisualStyleBackColor = true;
            this.POS_ADD.Click += new System.EventHandler(this.POS_ADD_Click);
            // 
            // POS_DEL
            // 
            this.POS_DEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.POS_DEL.Location = new System.Drawing.Point(137, 478);
            this.POS_DEL.Margin = new System.Windows.Forms.Padding(4);
            this.POS_DEL.Name = "POS_DEL";
            this.POS_DEL.Size = new System.Drawing.Size(125, 38);
            this.POS_DEL.TabIndex = 154;
            this.POS_DEL.Text = "删除硬件";
            this.POS_DEL.UseVisualStyleBackColor = true;
            // 
            // POS_dataGridView1
            // 
            this.POS_dataGridView1.AllowUserToAddRows = false;
            this.POS_dataGridView1.AllowUserToDeleteRows = false;
            this.POS_dataGridView1.AllowUserToResizeColumns = false;
            this.POS_dataGridView1.AllowUserToResizeRows = false;
            this.POS_dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.POS_dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.POS_dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.POS_dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.POS_dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.POS_dataGridView1.ColumnHeadersVisible = false;
            this.POS_dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.POS_dataGridView1.Location = new System.Drawing.Point(4, 5);
            this.POS_dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.POS_dataGridView1.MultiSelect = false;
            this.POS_dataGridView1.Name = "POS_dataGridView1";
            this.POS_dataGridView1.ReadOnly = true;
            this.POS_dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.POS_dataGridView1.RowHeadersVisible = false;
            this.POS_dataGridView1.RowTemplate.Height = 23;
            this.POS_dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.POS_dataGridView1.Size = new System.Drawing.Size(253, 430);
            this.POS_dataGridView1.TabIndex = 157;
            this.POS_dataGridView1.TabStop = false;
            this.POS_dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.POS_dataGridView1_CellClick);
            this.POS_dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.POS_dataGridView1_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 111;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 111;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // POS_NAME
            // 
            this.POS_NAME.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.POS_NAME.Location = new System.Drawing.Point(68, 442);
            this.POS_NAME.Name = "POS_NAME";
            this.POS_NAME.Size = new System.Drawing.Size(189, 25);
            this.POS_NAME.TabIndex = 157;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.buttonRemove);
            this.panel1.Controls.Add(this.buttonAdd);
            this.panel1.Controls.Add(this.轴名称);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dgv_deviceList);
            this.panel1.Location = new System.Drawing.Point(285, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 523);
            this.panel1.TabIndex = 158;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.POS_dataGridView1);
            this.panel2.Controls.Add(this.POS_NAME);
            this.panel2.Controls.Add(this.POS_DEL);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.POS_ADD);
            this.panel2.Location = new System.Drawing.Point(12, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 523);
            this.panel2.TabIndex = 159;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.dataGridViewOutput);
            this.panel3.Location = new System.Drawing.Point(577, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(447, 532);
            this.panel3.TabIndex = 160;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(80, 461);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 25);
            this.textBox1.TabIndex = 161;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(144, 490);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 38);
            this.button1.TabIndex = 159;
            this.button1.Text = "删除硬件";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 464);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 160;
            this.label2.Text = "点名称:";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(16, 490);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 36);
            this.button2.TabIndex = 158;
            this.button2.Text = "添加硬件";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewOutput
            // 
            this.dataGridViewOutput.AllowUserToAddRows = false;
            this.dataGridViewOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOutput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.名字,
            this.点位,
            this.Get,
            this.Go});
            this.dataGridViewOutput.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewOutput.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewOutput.Name = "dataGridViewOutput";
            this.dataGridViewOutput.RowHeadersWidth = 10;
            this.dataGridViewOutput.RowTemplate.Height = 23;
            this.dataGridViewOutput.Size = new System.Drawing.Size(439, 448);
            this.dataGridViewOutput.TabIndex = 23;
            // 
            // 名字
            // 
            this.名字.HeaderText = "Name";
            this.名字.Name = "名字";
            // 
            // 点位
            // 
            this.点位.HeaderText = "Pos";
            this.点位.Name = "点位";
            // 
            // Get
            // 
            this.Get.HeaderText = "Get";
            this.Get.Name = "Get";
            // 
            // Go
            // 
            this.Go.HeaderText = "Go";
            this.Go.Name = "Go";
            // 
            // FlowMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1036, 543);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FlowMain";
            this.Text = "FlowMain";
            this.Load += new System.EventHandler(this.FlowMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_deviceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.POS_dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_deviceList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox 轴名称;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        public System.Windows.Forms.DataGridView POS_dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button POS_ADD;
        private System.Windows.Forms.Button POS_DEL;
        private System.Windows.Forms.TextBox POS_NAME;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridViewOutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名字;
        private System.Windows.Forms.DataGridViewTextBoxColumn 点位;
        private System.Windows.Forms.DataGridViewButtonColumn Get;
        private System.Windows.Forms.DataGridViewButtonColumn Go;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}