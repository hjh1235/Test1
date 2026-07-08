using Controls;
namespace VMPro
{
    partial class Frm_FromCamera
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
            this.label147 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_focusCamera = new Sunny.UI.UIButton();
            this.btn_livePlay = new Sunny.UI.UIButton();
            this.btn_saveImage = new Sunny.UI.UIButton();
            this.nud_gain = new Controls.CNumericUpDown();
            this.cbx_cameraList = new Controls.CComboBox();
            this.nud_exposureTime = new Controls.CNumericUpDown();
            this.btn_moreSetting = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label147.Location = new System.Drawing.Point(2, 81);
            this.label147.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(68, 17);
            this.label147.TabIndex = 94;
            this.label147.Text = "曝光时间：";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label123.Location = new System.Drawing.Point(2, 18);
            this.label123.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(68, 17);
            this.label123.TabIndex = 98;
            this.label123.Text = "相机列表：";
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label148.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label148.Location = new System.Drawing.Point(183, 81);
            this.label148.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(29, 17);
            this.label148.TabIndex = 97;
            this.label148.Text = " ms";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 108;
            this.label1.Text = "增      益：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(187, 115);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 111;
            this.label2.Text = "db";
            // 
            // btn_focusCamera
            // 
            this.btn_focusCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_focusCamera.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_focusCamera.Location = new System.Drawing.Point(78, 157);
            this.btn_focusCamera.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_focusCamera.Name = "btn_focusCamera";
            this.btn_focusCamera.Size = new System.Drawing.Size(67, 28);
            this.btn_focusCamera.Style = Sunny.UI.UIStyle.Custom;
            this.btn_focusCamera.TabIndex = 112;
            this.btn_focusCamera.TabStop = false;
            this.btn_focusCamera.Text = "相机对焦";
            this.btn_focusCamera.Click += new System.EventHandler(this.btn_focusCamera_Click);
            // 
            // btn_livePlay
            // 
            this.btn_livePlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_livePlay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_livePlay.Location = new System.Drawing.Point(5, 157);
            this.btn_livePlay.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_livePlay.Name = "btn_livePlay";
            this.btn_livePlay.Size = new System.Drawing.Size(67, 28);
            this.btn_livePlay.Style = Sunny.UI.UIStyle.Custom;
            this.btn_livePlay.TabIndex = 113;
            this.btn_livePlay.TabStop = false;
            this.btn_livePlay.Text = "相机实时";
            this.btn_livePlay.Click += new System.EventHandler(this.btn_livePlay_Click);
            // 
            // btn_saveImage
            // 
            this.btn_saveImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_saveImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_saveImage.Location = new System.Drawing.Point(5, 188);
            this.btn_saveImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_saveImage.Name = "btn_saveImage";
            this.btn_saveImage.Size = new System.Drawing.Size(67, 28);
            this.btn_saveImage.Style = Sunny.UI.UIStyle.Custom;
            this.btn_saveImage.TabIndex = 114;
            this.btn_saveImage.TabStop = false;
            this.btn_saveImage.Text = "保存图像";
            this.btn_saveImage.Click += new System.EventHandler(this.btn_saveImage_Click);
            // 
            // nud_gain
            // 
            this.nud_gain.BackColor = System.Drawing.Color.White;
            this.nud_gain.DecimalPlaces = 0;
            this.nud_gain.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_gain.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_gain.Location = new System.Drawing.Point(65, 111);
            this.nud_gain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_gain.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_gain.MaxValue = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nud_gain.MinimumSize = new System.Drawing.Size(50, 26);
            this.nud_gain.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nud_gain.Name = "nud_gain";
            this.nud_gain.Size = new System.Drawing.Size(120, 26);
            this.nud_gain.TabIndex = 104;
            this.nud_gain.Value = 0D;
            this.nud_gain.ValueChanged += new Controls.DValueChanged(this.nud_gain_ValueChanged);
            // 
            // cbx_cameraList
            // 
            this.cbx_cameraList.BackColor = System.Drawing.Color.White;
            this.cbx_cameraList.CanEdit = false;
            this.cbx_cameraList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_cameraList.Items = new string[0];
            this.cbx_cameraList.Location = new System.Drawing.Point(2, 41);
            this.cbx_cameraList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx_cameraList.Name = "cbx_cameraList";
            this.cbx_cameraList.SelectedIndex = -1;
            this.cbx_cameraList.Size = new System.Drawing.Size(265, 26);
            this.cbx_cameraList.TabIndex = 102;
            this.cbx_cameraList.TabStop = false;
            this.cbx_cameraList.TextStr = "";
            this.cbx_cameraList.SelectedIndexChanged += new Controls.DSelectedIndexChanged(this.cbx_cameraList_SelectedIndexChanged);
            // 
            // nud_exposureTime
            // 
            this.nud_exposureTime.BackColor = System.Drawing.Color.White;
            this.nud_exposureTime.DecimalPlaces = 3;
            this.nud_exposureTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_exposureTime.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_exposureTime.Location = new System.Drawing.Point(65, 77);
            this.nud_exposureTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_exposureTime.MaximumSize = new System.Drawing.Size(300, 26);
            this.nud_exposureTime.MaxValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nud_exposureTime.MinimumSize = new System.Drawing.Size(50, 26);
            this.nud_exposureTime.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nud_exposureTime.Name = "nud_exposureTime";
            this.nud_exposureTime.Size = new System.Drawing.Size(120, 26);
            this.nud_exposureTime.TabIndex = 103;
            this.nud_exposureTime.Value = 30D;
            this.nud_exposureTime.ValueChanged += new Controls.DValueChanged(this.nud_exposureTime_ValueChanged);
            // 
            // btn_moreSetting
            // 
            this.btn_moreSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_moreSetting.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_moreSetting.Location = new System.Drawing.Point(5, 219);
            this.btn_moreSetting.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_moreSetting.Name = "btn_moreSetting";
            this.btn_moreSetting.Size = new System.Drawing.Size(67, 28);
            this.btn_moreSetting.Style = Sunny.UI.UIStyle.Custom;
            this.btn_moreSetting.TabIndex = 115;
            this.btn_moreSetting.TabStop = false;
            this.btn_moreSetting.Text = "更多设置";
            this.btn_moreSetting.Click += new System.EventHandler(this.btn_moreSetting_Click);
            // 
            // Frm_FromCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(270, 255);
            this.Controls.Add(this.btn_moreSetting);
            this.Controls.Add(this.btn_saveImage);
            this.Controls.Add(this.btn_livePlay);
            this.Controls.Add(this.btn_focusCamera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nud_gain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_cameraList);
            this.Controls.Add(this.nud_exposureTime);
            this.Controls.Add(this.label148);
            this.Controls.Add(this.label147);
            this.Controls.Add(this.label123);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_FromCamera";
            this.Text = "Frm_AcquistionFromDevice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label147;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Label label148;
        internal CNumericUpDown nud_exposureTime;
        internal CComboBox cbx_cameraList;
        internal CNumericUpDown nud_gain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal Sunny.UI.UIButton btn_focusCamera;
        internal Sunny.UI.UIButton btn_livePlay;
        internal Sunny.UI.UIButton btn_saveImage;
        internal Sunny.UI.UIButton btn_moreSetting;
    }
}