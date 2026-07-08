namespace UniversalControlSystem
{
    partial class Point_Form
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
            this.lb_TaskName = new System.Windows.Forms.Label();
            this.btnAddLeft = new System.Windows.Forms.Button();
            this.btnDelet = new System.Windows.Forms.Button();
            this.txtPointName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_Station = new System.Windows.Forms.Label();
            this.btn_Loading = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnWelding = new System.Windows.Forms.Button();
            this.dgvPointView = new System.Windows.Forms.DataGridView();
            this.名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类型 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Go焊接位 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPointView)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_TaskName
            // 
            this.lb_TaskName.AutoSize = true;
            this.lb_TaskName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_TaskName.Location = new System.Drawing.Point(120, 12);
            this.lb_TaskName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_TaskName.Name = "lb_TaskName";
            this.lb_TaskName.Size = new System.Drawing.Size(89, 20);
            this.lb_TaskName.TabIndex = 0;
            this.lb_TaskName.Text = "流程名称";
            // 
            // btnAddLeft
            // 
            this.btnAddLeft.Location = new System.Drawing.Point(1011, 225);
            this.btnAddLeft.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddLeft.Name = "btnAddLeft";
            this.btnAddLeft.Size = new System.Drawing.Size(100, 66);
            this.btnAddLeft.TabIndex = 2;
            this.btnAddLeft.Text = "添加点位";
            this.btnAddLeft.UseVisualStyleBackColor = true;
            this.btnAddLeft.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelet
            // 
            this.btnDelet.Location = new System.Drawing.Point(1119, 225);
            this.btnDelet.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelet.Name = "btnDelet";
            this.btnDelet.Size = new System.Drawing.Size(100, 66);
            this.btnDelet.TabIndex = 3;
            this.btnDelet.Text = "删除点位";
            this.btnDelet.UseVisualStyleBackColor = true;
            this.btnDelet.Click += new System.EventHandler(this.btnDelet_Click);
            // 
            // txtPointName
            // 
            this.txtPointName.Location = new System.Drawing.Point(1052, 168);
            this.txtPointName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPointName.Multiline = true;
            this.txtPointName.Name = "txtPointName";
            this.txtPointName.Size = new System.Drawing.Size(165, 36);
            this.txtPointName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(975, 178);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "名称：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1011, 310);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 64);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "流程名称:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(301, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "工位:";
            // 
            // lb_Station
            // 
            this.lb_Station.AutoSize = true;
            this.lb_Station.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Station.Location = new System.Drawing.Point(365, 14);
            this.lb_Station.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Station.Name = "lb_Station";
            this.lb_Station.Size = new System.Drawing.Size(89, 20);
            this.lb_Station.TabIndex = 9;
            this.lb_Station.Text = "流程名称";
            // 
            // btn_Loading
            // 
            this.btn_Loading.Location = new System.Drawing.Point(1119, 310);
            this.btn_Loading.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Loading.Name = "btn_Loading";
            this.btn_Loading.Size = new System.Drawing.Size(100, 64);
            this.btn_Loading.TabIndex = 11;
            this.btn_Loading.Text = "加载";
            this.btn_Loading.UseVisualStyleBackColor = true;
            this.btn_Loading.Click += new System.EventHandler(this.btn_Loading_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(1011, 395);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(100, 66);
            this.btnMoveUp.TabIndex = 12;
            this.btnMoveUp.Text = "上移";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(1119, 395);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(100, 66);
            this.btnMoveDown.TabIndex = 13;
            this.btnMoveDown.Text = "下移";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(1011, 468);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 66);
            this.btnInsert.TabIndex = 14;
            this.btnInsert.Text = "插入";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnWelding
            // 
            this.btnWelding.Location = new System.Drawing.Point(1119, 468);
            this.btnWelding.Margin = new System.Windows.Forms.Padding(4);
            this.btnWelding.Name = "btnWelding";
            this.btnWelding.Size = new System.Drawing.Size(100, 66);
            this.btnWelding.TabIndex = 15;
            this.btnWelding.Text = "补焊";
            this.btnWelding.UseVisualStyleBackColor = true;
            this.btnWelding.Visible = false;
            this.btnWelding.Click += new System.EventHandler(this.btnWelding_Click);
            // 
            // dgvPointView
            // 
            this.dgvPointView.AllowUserToAddRows = false;
            this.dgvPointView.AllowUserToResizeColumns = false;
            this.dgvPointView.AllowUserToResizeRows = false;
            this.dgvPointView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPointView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPointView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPointView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPointView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.名称,
            this.类型,
            this.Column1,
            this.Y,
            this.Z,
            this.Column9,
            this.Go焊接位});
            this.dgvPointView.Location = new System.Drawing.Point(20, 38);
            this.dgvPointView.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPointView.Name = "dgvPointView";
            this.dgvPointView.RowTemplate.Height = 23;
            this.dgvPointView.Size = new System.Drawing.Size(949, 495);
            this.dgvPointView.TabIndex = 1;
            this.dgvPointView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPointView_CellClick);
            this.dgvPointView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPointView_RowPostPaint);
            // 
            // 名称
            // 
            this.名称.HeaderText = "名称";
            this.名称.Name = "名称";
            // 
            // 类型
            // 
            this.类型.HeaderText = "类型";
            this.类型.Items.AddRange(new object[] {
            "拍照",
            "测高",
            "热熔"});
            this.类型.Name = "类型";
            this.类型.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "X";
            this.Column1.Name = "Column1";
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // Z
            // 
            this.Z.HeaderText = "Z";
            this.Z.Name = "Z";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "获取";
            this.Column9.Name = "Column9";
            // 
            // Go焊接位
            // 
            this.Go焊接位.HeaderText = "运动";
            this.Go焊接位.Name = "Go焊接位";
            this.Go焊接位.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Go焊接位.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Point_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1241, 575);
            this.Controls.Add(this.btnWelding);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btn_Loading);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_Station);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPointName);
            this.Controls.Add(this.btnDelet);
            this.Controls.Add(this.btnAddLeft);
            this.Controls.Add(this.dgvPointView);
            this.Controls.Add(this.lb_TaskName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Point_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "点位设置";
            this.Load += new System.EventHandler(this.Point_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPointView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_TaskName;
        private System.Windows.Forms.Button btnAddLeft;
        private System.Windows.Forms.Button btnDelet;
        private System.Windows.Forms.TextBox txtPointName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_Station;
        private System.Windows.Forms.Button btn_Loading;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnWelding;
        private System.Windows.Forms.DataGridView dgvPointView;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名称;
        private System.Windows.Forms.DataGridViewComboBoxColumn 类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Z;
        private System.Windows.Forms.DataGridViewButtonColumn Column9;
        private System.Windows.Forms.DataGridViewButtonColumn Go焊接位;
    }
}