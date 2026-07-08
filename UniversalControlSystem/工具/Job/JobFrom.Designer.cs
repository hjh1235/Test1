namespace UniversalControlSystem.工具.Job
{
    partial class JobFrom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobFrom));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_createJob = new System.Windows.Forms.ToolStripButton();
            this.tsb_expandJob = new System.Windows.Forms.ToolStripButton();
            this.tsb_foldJob = new System.Windows.Forms.ToolStripButton();
            this.tsb_deleteJob = new System.Windows.Forms.ToolStripButton();
            this.tsb_jobInfo = new System.Windows.Forms.ToolStripButton();
            this.btn_runOnce = new System.Windows.Forms.Button();
            this.btn_runLoop = new System.Windows.Forms.Button();
            this.tbc_jobs = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_createJob,
            this.tsb_expandJob,
            this.tsb_foldJob,
            this.tsb_deleteJob,
            this.tsb_jobInfo});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 582);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStrip1.Size = new System.Drawing.Size(384, 37);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_createJob
            // 
            this.tsb_createJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_createJob.Image = ((System.Drawing.Image)(resources.GetObject("tsb_createJob.Image")));
            this.tsb_createJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_createJob.Name = "tsb_createJob";
            this.tsb_createJob.Size = new System.Drawing.Size(24, 34);
            this.tsb_createJob.Text = "新建流程";
            // 
            // tsb_expandJob
            // 
            this.tsb_expandJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_expandJob.Image = ((System.Drawing.Image)(resources.GetObject("tsb_expandJob.Image")));
            this.tsb_expandJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_expandJob.Name = "tsb_expandJob";
            this.tsb_expandJob.Size = new System.Drawing.Size(24, 34);
            this.tsb_expandJob.Text = "展开流程";
            // 
            // tsb_foldJob
            // 
            this.tsb_foldJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_foldJob.Image = ((System.Drawing.Image)(resources.GetObject("tsb_foldJob.Image")));
            this.tsb_foldJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_foldJob.Name = "tsb_foldJob";
            this.tsb_foldJob.Size = new System.Drawing.Size(24, 34);
            this.tsb_foldJob.Text = "折叠流程";
            // 
            // tsb_deleteJob
            // 
            this.tsb_deleteJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_deleteJob.Image = ((System.Drawing.Image)(resources.GetObject("tsb_deleteJob.Image")));
            this.tsb_deleteJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_deleteJob.Name = "tsb_deleteJob";
            this.tsb_deleteJob.Size = new System.Drawing.Size(24, 34);
            this.tsb_deleteJob.Text = "删除流程";
            // 
            // tsb_jobInfo
            // 
            this.tsb_jobInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_jobInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsb_jobInfo.Image")));
            this.tsb_jobInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_jobInfo.Name = "tsb_jobInfo";
            this.tsb_jobInfo.Size = new System.Drawing.Size(24, 34);
            this.tsb_jobInfo.Text = "流程属性";
            // 
            // btn_runOnce
            // 
            this.btn_runOnce.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_runOnce.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_runOnce.BackgroundImage")));
            this.btn_runOnce.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_runOnce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runOnce.FlatAppearance.BorderSize = 0;
            this.btn_runOnce.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_runOnce.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_runOnce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_runOnce.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runOnce.ForeColor = System.Drawing.Color.White;
            this.btn_runOnce.Location = new System.Drawing.Point(260, 580);
            this.btn_runOnce.Margin = new System.Windows.Forms.Padding(5);
            this.btn_runOnce.Name = "btn_runOnce";
            this.btn_runOnce.Size = new System.Drawing.Size(110, 41);
            this.btn_runOnce.TabIndex = 56;
            this.btn_runOnce.Text = "单次运行";
            this.btn_runOnce.UseVisualStyleBackColor = true;
            // 
            // btn_runLoop
            // 
            this.btn_runLoop.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_runLoop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_runLoop.BackgroundImage")));
            this.btn_runLoop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_runLoop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_runLoop.FlatAppearance.BorderSize = 0;
            this.btn_runLoop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_runLoop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_runLoop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_runLoop.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runLoop.ForeColor = System.Drawing.Color.White;
            this.btn_runLoop.Location = new System.Drawing.Point(140, 579);
            this.btn_runLoop.Margin = new System.Windows.Forms.Padding(5);
            this.btn_runLoop.Name = "btn_runLoop";
            this.btn_runLoop.Size = new System.Drawing.Size(110, 41);
            this.btn_runLoop.TabIndex = 57;
            this.btn_runLoop.TabStop = false;
            this.btn_runLoop.Text = "连续运行";
            this.btn_runLoop.UseVisualStyleBackColor = true;
            // 
            // tbc_jobs
            // 
            this.tbc_jobs.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbc_jobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc_jobs.ItemSize = new System.Drawing.Size(0, 20);
            this.tbc_jobs.Location = new System.Drawing.Point(0, 0);
            this.tbc_jobs.Margin = new System.Windows.Forms.Padding(0);
            this.tbc_jobs.Name = "tbc_jobs";
            this.tbc_jobs.SelectedIndex = 0;
            this.tbc_jobs.Size = new System.Drawing.Size(384, 582);
            this.tbc_jobs.TabIndex = 58;
            this.tbc_jobs.TabStop = false;
            // 
            // JobFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 619);
            this.Controls.Add(this.tbc_jobs);
            this.Controls.Add(this.btn_runOnce);
            this.Controls.Add(this.btn_runLoop);
            this.Controls.Add(this.toolStrip1);
            this.Name = "JobFrom";
            this.Text = "JobFrom";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_createJob;
        private System.Windows.Forms.ToolStripButton tsb_expandJob;
        private System.Windows.Forms.ToolStripButton tsb_foldJob;
        internal System.Windows.Forms.ToolStripButton tsb_deleteJob;
        private System.Windows.Forms.ToolStripButton tsb_jobInfo;
        public System.Windows.Forms.Button btn_runOnce;
        internal System.Windows.Forms.Button btn_runLoop;
        internal System.Windows.Forms.TabControl tbc_jobs;
    }
}