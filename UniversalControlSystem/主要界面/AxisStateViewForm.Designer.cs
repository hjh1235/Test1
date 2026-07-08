namespace UniversalControlSystem
{
    partial class AxisStateViewForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AxisStateViewForm));
            this.dataGridViewAxisStatus = new System.Windows.Forms.DataGridView();
            this.timerScan = new System.Windows.Forms.Timer(this.components);
            this.tabAxisView = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAxisStatus)).BeginInit();
            this.tabAxisView.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewAxisStatus
            // 
            this.dataGridViewAxisStatus.AllowUserToAddRows = false;
            this.dataGridViewAxisStatus.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAxisStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAxisStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAxisStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAxisStatus.Location = new System.Drawing.Point(4, 4);
            this.dataGridViewAxisStatus.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewAxisStatus.MultiSelect = false;
            this.dataGridViewAxisStatus.Name = "dataGridViewAxisStatus";
            this.dataGridViewAxisStatus.ReadOnly = true;
            this.dataGridViewAxisStatus.RowHeadersVisible = false;
            this.dataGridViewAxisStatus.RowHeadersWidth = 20;
            this.dataGridViewAxisStatus.RowTemplate.Height = 23;
            this.dataGridViewAxisStatus.Size = new System.Drawing.Size(876, 387);
            this.dataGridViewAxisStatus.TabIndex = 126;
            this.dataGridViewAxisStatus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewAxisStatus_MouseDown);
            this.dataGridViewAxisStatus.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridViewAxisStatus_MouseMove);
            // 
            // timerScan
            // 
            this.timerScan.Enabled = true;
            this.timerScan.Interval = 1;
            this.timerScan.Tick += new System.EventHandler(this.timerScan_Tick);
            // 
            // tabAxisView
            // 
            this.tabAxisView.Controls.Add(this.tabPage1);
            this.tabAxisView.Location = new System.Drawing.Point(0, 0);
            this.tabAxisView.Margin = new System.Windows.Forms.Padding(4);
            this.tabAxisView.Multiline = true;
            this.tabAxisView.Name = "tabAxisView";
            this.tabAxisView.SelectedIndex = 0;
            this.tabAxisView.Size = new System.Drawing.Size(892, 424);
            this.tabAxisView.TabIndex = 127;
            this.tabAxisView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabAxisView_MouseDown);
            this.tabAxisView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tabAxisView_MouseMove);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewAxisStatus);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(884, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "卡1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // AxisStateViewForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(892, 428);
            this.Controls.Add(this.tabAxisView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AxisStateViewForm";
            this.Text = "轴状态显示";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AxisStateViewForm_FormClosing);
            this.Load += new System.EventHandler(this.AxisStateViewForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AxisStateViewForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AxisStateViewForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAxisStatus)).EndInit();
            this.tabAxisView.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAxisStatus;
        private System.Windows.Forms.Timer timerScan;
        private System.Windows.Forms.TabControl tabAxisView;
        private System.Windows.Forms.TabPage tabPage1;
    }
}