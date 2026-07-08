namespace VMPro
{
    partial class Frm_FromDirectory
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
            this.tbx_imageDirectoryPath = new System.Windows.Forms.TextBox();
            this.btn_removeCurrent = new Sunny.UI.UIButton();
            this.btn_browseImage = new Sunny.UI.UIButton();
            this.btn_selectDirectory = new Sunny.UI.UIButton();
            this.btn_lastOne = new Sunny.UI.UIButton();
            this.btn_nextOne = new Sunny.UI.UIButton();
            this.btn_retureToFirst = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // tbx_imageDirectoryPath
            // 
            this.tbx_imageDirectoryPath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_imageDirectoryPath.Location = new System.Drawing.Point(6, 18);
            this.tbx_imageDirectoryPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_imageDirectoryPath.Multiline = true;
            this.tbx_imageDirectoryPath.Name = "tbx_imageDirectoryPath";
            this.tbx_imageDirectoryPath.Size = new System.Drawing.Size(258, 88);
            this.tbx_imageDirectoryPath.TabIndex = 5;
            this.tbx_imageDirectoryPath.TabStop = false;
            this.tbx_imageDirectoryPath.TextChanged += new System.EventHandler(this.tbx_imageDirectoryPath_TextChanged);
            this.tbx_imageDirectoryPath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbx_imageDirectoryPath_KeyUp);
            // 
            // btn_removeCurrent
            // 
            this.btn_removeCurrent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_removeCurrent.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_removeCurrent.Location = new System.Drawing.Point(7, 180);
            this.btn_removeCurrent.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_removeCurrent.Name = "btn_removeCurrent";
            this.btn_removeCurrent.Size = new System.Drawing.Size(67, 28);
            this.btn_removeCurrent.Style = Sunny.UI.UIStyle.Custom;
            this.btn_removeCurrent.TabIndex = 121;
            this.btn_removeCurrent.Text = "移除当前";
            this.btn_removeCurrent.Click += new System.EventHandler(this.btn_removeCurrent_Click);
            // 
            // btn_browseImage
            // 
            this.btn_browseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_browseImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_browseImage.Location = new System.Drawing.Point(7, 213);
            this.btn_browseImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_browseImage.Name = "btn_browseImage";
            this.btn_browseImage.Size = new System.Drawing.Size(67, 28);
            this.btn_browseImage.Style = Sunny.UI.UIStyle.Custom;
            this.btn_browseImage.TabIndex = 120;
            this.btn_browseImage.Text = "查看图像";
            this.btn_browseImage.Click += new System.EventHandler(this.btn_browseImage_Click);
            // 
            // btn_selectDirectory
            // 
            this.btn_selectDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selectDirectory.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_selectDirectory.Location = new System.Drawing.Point(196, 114);
            this.btn_selectDirectory.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_selectDirectory.Name = "btn_selectDirectory";
            this.btn_selectDirectory.Size = new System.Drawing.Size(67, 28);
            this.btn_selectDirectory.Style = Sunny.UI.UIStyle.Custom;
            this.btn_selectDirectory.TabIndex = 119;
            this.btn_selectDirectory.Text = "指定路径";
            this.btn_selectDirectory.Click += new System.EventHandler(this.btn_selectDirectory_Click);
            // 
            // btn_lastOne
            // 
            this.btn_lastOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_lastOne.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_lastOne.Location = new System.Drawing.Point(7, 114);
            this.btn_lastOne.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_lastOne.Name = "btn_lastOne";
            this.btn_lastOne.Size = new System.Drawing.Size(67, 28);
            this.btn_lastOne.Style = Sunny.UI.UIStyle.Custom;
            this.btn_lastOne.TabIndex = 122;
            this.btn_lastOne.Text = "上一张";
            this.btn_lastOne.Click += new System.EventHandler(this.btn_lastOne_Click);
            // 
            // btn_nextOne
            // 
            this.btn_nextOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_nextOne.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_nextOne.Location = new System.Drawing.Point(80, 114);
            this.btn_nextOne.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_nextOne.Name = "btn_nextOne";
            this.btn_nextOne.Size = new System.Drawing.Size(67, 28);
            this.btn_nextOne.Style = Sunny.UI.UIStyle.Custom;
            this.btn_nextOne.TabIndex = 123;
            this.btn_nextOne.Text = "下一张";
            this.btn_nextOne.Click += new System.EventHandler(this.btn_nextOne_Click);
            // 
            // btn_retureToFirst
            // 
            this.btn_retureToFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_retureToFirst.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_retureToFirst.Location = new System.Drawing.Point(7, 147);
            this.btn_retureToFirst.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_retureToFirst.Name = "btn_retureToFirst";
            this.btn_retureToFirst.Size = new System.Drawing.Size(67, 28);
            this.btn_retureToFirst.Style = Sunny.UI.UIStyle.Custom;
            this.btn_retureToFirst.TabIndex = 124;
            this.btn_retureToFirst.Text = "回到首张";
            this.btn_retureToFirst.Click += new System.EventHandler(this.btn_retureToFirst_Click);
            // 
            // Frm_FromDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(270, 255);
            this.Controls.Add(this.btn_retureToFirst);
            this.Controls.Add(this.btn_nextOne);
            this.Controls.Add(this.btn_lastOne);
            this.Controls.Add(this.btn_removeCurrent);
            this.Controls.Add(this.btn_browseImage);
            this.Controls.Add(this.tbx_imageDirectoryPath);
            this.Controls.Add(this.btn_selectDirectory);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_FromDirectory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox tbx_imageDirectoryPath;
        internal Sunny.UI.UIButton btn_selectDirectory;
        internal Sunny.UI.UIButton btn_removeCurrent;
        internal Sunny.UI.UIButton btn_browseImage;
        internal Sunny.UI.UIButton btn_lastOne;
        internal Sunny.UI.UIButton btn_nextOne;
        internal Sunny.UI.UIButton btn_retureToFirst;

    }
}