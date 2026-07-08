namespace UniversalControlSystem
{
    partial class Frm_Job
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Job));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_createJob = new System.Windows.Forms.ToolStripButton();
            this.tsb_expandJob = new System.Windows.Forms.ToolStripButton();
            this.tsb_foldJob = new System.Windows.Forms.ToolStripButton();
            this.tsb_deleteJob = new System.Windows.Forms.ToolStripButton();
            this.tsb_jobInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.清除工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbc_jobs = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.tsb_jobInfo,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 645);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStrip1.Size = new System.Drawing.Size(386, 37);
            this.toolStrip1.TabIndex = 4;
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
            this.tsb_createJob.Click += new System.EventHandler(this.tsb_createJob_Click);
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
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::UniversalControlSystem.Properties.Resources.上_移1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 34);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::UniversalControlSystem.Properties.Resources.下_移;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 34);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.清除工具ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 100);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 24);
            this.toolStripMenuItem1.Text = "上移工具";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(138, 24);
            this.toolStripMenuItem2.Text = "下移工具";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(138, 24);
            this.toolStripMenuItem3.Text = "删除工具";
            // 
            // 清除工具ToolStripMenuItem
            // 
            this.清除工具ToolStripMenuItem.Name = "清除工具ToolStripMenuItem";
            this.清除工具ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.清除工具ToolStripMenuItem.Text = "清除工具";
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
            this.tbc_jobs.Size = new System.Drawing.Size(386, 645);
            this.tbc_jobs.TabIndex = 5;
            this.tbc_jobs.TabStop = false;
            // 
            // Frm_Job
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 682);
            this.Controls.Add(this.tbc_jobs);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Job";
            this.Text = "Frm_Job";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem 清除工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        internal System.Windows.Forms.TabControl tbc_jobs;
    }
}