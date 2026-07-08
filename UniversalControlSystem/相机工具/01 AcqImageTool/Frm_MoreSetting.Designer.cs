namespace VMPro
{
    partial class Frm_MoreSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MoreSetting));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_exit = new Sunny.UI.UIButton();
            this.tbx_imageW = new Controls.CNumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tbx_iamgeH = new Controls.CNumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.uiLine1 = new Sunny.UI.UILine();
            this.tbx_offsetH = new Controls.CNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_offsetV = new Controls.CNumericUpDown();
            this.label147 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.Location = new System.Drawing.Point(6, 6);
            this.lbl_title.Text = "更多设置";
            // 
            // btn_topLevel
            // 
            this.btn_topLevel.FlatAppearance.BorderSize = 0;
            this.btn_topLevel.Location = new System.Drawing.Point(480, 0);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btn_exit);
            this.panel2.Controls.Add(this.tbx_imageW);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbx_iamgeH);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.uiLine1);
            this.panel2.Controls.Add(this.tbx_offsetH);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbx_offsetV);
            this.panel2.Controls.Add(this.label147);
            this.panel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(2, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 393);
            this.panel2.TabIndex = 1;
            // 
            // btn_exit
            // 
            this.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_exit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_exit.Location = new System.Drawing.Point(503, 355);
            this.btn_exit.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(67, 28);
            this.btn_exit.Style = Sunny.UI.UIStyle.Custom;
            this.btn_exit.TabIndex = 231;
            this.btn_exit.TabStop = false;
            this.btn_exit.Text = "退出";
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // tbx_imageW
            // 
            this.tbx_imageW.BackColor = System.Drawing.Color.White;
            this.tbx_imageW.DecimalPlaces = 0;
            this.tbx_imageW.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_imageW.Incremeent = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tbx_imageW.Location = new System.Drawing.Point(90, 153);
            this.tbx_imageW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_imageW.MaximumSize = new System.Drawing.Size(300, 26);
            this.tbx_imageW.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tbx_imageW.MinimumSize = new System.Drawing.Size(50, 26);
            this.tbx_imageW.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbx_imageW.Name = "tbx_imageW";
            this.tbx_imageW.Size = new System.Drawing.Size(120, 26);
            this.tbx_imageW.TabIndex = 229;
            this.tbx_imageW.Value = 2594D;
            this.tbx_imageW.ValueChanged += new Controls.DValueChanged(this.tbx_imageW_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(27, 157);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 230;
            this.label4.Text = "宽：";
            // 
            // tbx_iamgeH
            // 
            this.tbx_iamgeH.BackColor = System.Drawing.Color.White;
            this.tbx_iamgeH.DecimalPlaces = 0;
            this.tbx_iamgeH.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_iamgeH.Incremeent = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tbx_iamgeH.Location = new System.Drawing.Point(90, 119);
            this.tbx_iamgeH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_iamgeH.MaximumSize = new System.Drawing.Size(300, 26);
            this.tbx_iamgeH.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tbx_iamgeH.MinimumSize = new System.Drawing.Size(50, 26);
            this.tbx_iamgeH.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbx_iamgeH.Name = "tbx_iamgeH";
            this.tbx_iamgeH.Size = new System.Drawing.Size(120, 26);
            this.tbx_iamgeH.TabIndex = 228;
            this.tbx_iamgeH.Value = 1944D;
            this.tbx_iamgeH.ValueChanged += new Controls.DValueChanged(this.tbx_iamgeH_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(27, 123);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.TabIndex = 226;
            this.label6.Text = "高：";
            // 
            // uiLine1
            // 
            this.uiLine1.FillColor = System.Drawing.Color.White;
            this.uiLine1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLine1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uiLine1.Location = new System.Drawing.Point(16, 17);
            this.uiLine1.MinimumSize = new System.Drawing.Size(2, 2);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(259, 29);
            this.uiLine1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLine1.TabIndex = 225;
            this.uiLine1.Text = "采集区域";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbx_offsetH
            // 
            this.tbx_offsetH.BackColor = System.Drawing.Color.White;
            this.tbx_offsetH.DecimalPlaces = 0;
            this.tbx_offsetH.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_offsetH.Incremeent = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tbx_offsetH.Location = new System.Drawing.Point(90, 85);
            this.tbx_offsetH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_offsetH.MaximumSize = new System.Drawing.Size(300, 26);
            this.tbx_offsetH.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tbx_offsetH.MinimumSize = new System.Drawing.Size(50, 26);
            this.tbx_offsetH.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbx_offsetH.Name = "tbx_offsetH";
            this.tbx_offsetH.Size = new System.Drawing.Size(120, 26);
            this.tbx_offsetH.TabIndex = 115;
            this.tbx_offsetH.Value = 0D;
            this.tbx_offsetH.ValueChanged += new Controls.DValueChanged(this.tbx_offsetH_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(27, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 116;
            this.label1.Text = "水平偏移：";
            // 
            // tbx_offsetV
            // 
            this.tbx_offsetV.BackColor = System.Drawing.Color.White;
            this.tbx_offsetV.DecimalPlaces = 0;
            this.tbx_offsetV.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_offsetV.Incremeent = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tbx_offsetV.Location = new System.Drawing.Point(90, 51);
            this.tbx_offsetV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_offsetV.MaximumSize = new System.Drawing.Size(300, 26);
            this.tbx_offsetV.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tbx_offsetV.MinimumSize = new System.Drawing.Size(50, 26);
            this.tbx_offsetV.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbx_offsetV.Name = "tbx_offsetV";
            this.tbx_offsetV.Size = new System.Drawing.Size(120, 26);
            this.tbx_offsetV.TabIndex = 114;
            this.tbx_offsetV.Value = 0D;
            this.tbx_offsetV.ValueChanged += new Controls.DValueChanged(this.tbx_offsetV_ValueChanged);
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label147.Location = new System.Drawing.Point(27, 55);
            this.label147.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(68, 17);
            this.label147.TabIndex = 112;
            this.label147.Text = "垂直偏移：";
            // 
            // Frm_MoreSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(584, 421);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(584, 421);
            this.MinimumSize = new System.Drawing.Size(532, 378);
            this.Name = "Frm_MoreSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "相机SDK信息";
            this.Controls.SetChildIndex(this.btn_topLevel, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        internal Controls.CNumericUpDown tbx_offsetH;
        private System.Windows.Forms.Label label1;
        internal Controls.CNumericUpDown tbx_offsetV;
        private System.Windows.Forms.Label label147;
        internal Controls.CNumericUpDown tbx_imageW;
        private System.Windows.Forms.Label label4;
        internal Controls.CNumericUpDown tbx_iamgeH;
        private System.Windows.Forms.Label label6;
        private Sunny.UI.UILine uiLine1;
        internal Sunny.UI.UIButton btn_exit;
    }
}