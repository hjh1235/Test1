namespace UniversalControlSystem
{
    partial class HW
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
            this.hWindowControl1 = new HalconDotNet.HWindowControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxImage = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fitImagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.适应窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中心ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hWindowControl1
            // 
            this.hWindowControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hWindowControl1.BackColor = System.Drawing.Color.Black;
            this.hWindowControl1.BorderColor = System.Drawing.Color.Black;
            this.hWindowControl1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindowControl1.Location = new System.Drawing.Point(1, 38);
            this.hWindowControl1.Margin = new System.Windows.Forms.Padding(4);
            this.hWindowControl1.Name = "hWindowControl1";
            this.hWindowControl1.Size = new System.Drawing.Size(901, 472);
            this.hWindowControl1.TabIndex = 7;
            this.hWindowControl1.WindowSize = new System.Drawing.Size(901, 472);
            this.hWindowControl1.HMouseMove += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseMove_1);
            this.hWindowControl1.HMouseDown += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseDown_1);
            this.hWindowControl1.HMouseUp += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseUp_1);
            this.hWindowControl1.HMouseWheel += new HalconDotNet.HMouseEventHandler(this.hWindowControl1_HMouseWheel_1);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbxImage);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 30);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "图像：";
            // 
            // cbxImage
            // 
            this.cbxImage.FormattingEnabled = true;
            this.cbxImage.Location = new System.Drawing.Point(67, 4);
            this.cbxImage.Margin = new System.Windows.Forms.Padding(4);
            this.cbxImage.Name = "cbxImage";
            this.cbxImage.Size = new System.Drawing.Size(323, 23);
            this.cbxImage.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLabel1,
            this.toolLabel2,
            this.toolLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 514);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(902, 30);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolLabel1
            // 
            this.toolLabel1.BackColor = System.Drawing.Color.Blue;
            this.toolLabel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolLabel1.ForeColor = System.Drawing.Color.White;
            this.toolLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.toolLabel1.Name = "toolLabel1";
            this.toolLabel1.RightToLeftAutoMirrorImage = true;
            this.toolLabel1.Size = new System.Drawing.Size(457, 25);
            this.toolLabel1.Text = "Size:0000*0000 X:0000.00 Y:0000.00 VAL:000,000,000";
            // 
            // toolLabel2
            // 
            this.toolLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolLabel2.ForeColor = System.Drawing.Color.Red;
            this.toolLabel2.Name = "toolLabel2";
            this.toolLabel2.Size = new System.Drawing.Size(52, 25);
            this.toolLabel2.Text = "FAIL";
            // 
            // toolLabel3
            // 
            this.toolLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolLabel3.ForeColor = System.Drawing.Color.White;
            this.toolLabel3.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.toolLabel3.Name = "toolLabel3";
            this.toolLabel3.Size = new System.Drawing.Size(74, 25);
            this.toolLabel3.Text = "耗时:0:00";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fitImagerToolStripMenuItem,
            this.适应窗口ToolStripMenuItem,
            this.saveImagerToolStripMenuItem,
            this.SaveWindowToolStripMenuItem,
            this.中心ToolStripMenuItem,
            this.图像选择ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 176);
            // 
            // fitImagerToolStripMenuItem
            // 
            this.fitImagerToolStripMenuItem.Name = "fitImagerToolStripMenuItem";
            this.fitImagerToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.fitImagerToolStripMenuItem.Tag = "0";
            this.fitImagerToolStripMenuItem.Text = "适应图片";
            this.fitImagerToolStripMenuItem.Click += new System.EventHandler(this.fitImagerToolStripMenuItem_Click_1);
            // 
            // 适应窗口ToolStripMenuItem
            // 
            this.适应窗口ToolStripMenuItem.Name = "适应窗口ToolStripMenuItem";
            this.适应窗口ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.适应窗口ToolStripMenuItem.Tag = "1";
            this.适应窗口ToolStripMenuItem.Text = "适应窗口";
            this.适应窗口ToolStripMenuItem.Click += new System.EventHandler(this.适应窗口ToolStripMenuItem_Click_1);
            // 
            // saveImagerToolStripMenuItem
            // 
            this.saveImagerToolStripMenuItem.Name = "saveImagerToolStripMenuItem";
            this.saveImagerToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.saveImagerToolStripMenuItem.Tag = "2";
            this.saveImagerToolStripMenuItem.Text = "保存图片";
            this.saveImagerToolStripMenuItem.Click += new System.EventHandler(this.saveImagerToolStripMenuItem_Click);
            // 
            // SaveWindowToolStripMenuItem
            // 
            this.SaveWindowToolStripMenuItem.Name = "SaveWindowToolStripMenuItem";
            this.SaveWindowToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.SaveWindowToolStripMenuItem.Tag = "3";
            this.SaveWindowToolStripMenuItem.Text = "保存窗口";
            this.SaveWindowToolStripMenuItem.Click += new System.EventHandler(this.SaveWindowToolStripMenuItem_Click_1);
            // 
            // 中心ToolStripMenuItem
            // 
            this.中心ToolStripMenuItem.Name = "中心ToolStripMenuItem";
            this.中心ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.中心ToolStripMenuItem.Text = "中心十字";
            this.中心ToolStripMenuItem.Click += new System.EventHandler(this.中心ToolStripMenuItem_Click);
            // 
            // 图像选择ToolStripMenuItem
            // 
            this.图像选择ToolStripMenuItem.Name = "图像选择ToolStripMenuItem";
            this.图像选择ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.图像选择ToolStripMenuItem.Text = "图像选择";
            this.图像选择ToolStripMenuItem.Click += new System.EventHandler(this.图像选择ToolStripMenuItem_Click_1);
            // 
            // HW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 544);
            this.Controls.Add(this.hWindowControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HW";
            this.Text = "HW";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public  HalconDotNet.HWindowControl hWindowControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxImage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolLabel3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fitImagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 适应窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中心ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像选择ToolStripMenuItem;
    }
}