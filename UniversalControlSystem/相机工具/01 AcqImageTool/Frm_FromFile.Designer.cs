namespace VMPro
{
    partial class Frm_FromFile
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
            this.tbx_imagePath = new System.Windows.Forms.TextBox();
            this.btn_selectImage = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // tbx_imagePath
            // 
            this.tbx_imagePath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_imagePath.Location = new System.Drawing.Point(6, 18);
            this.tbx_imagePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_imagePath.Multiline = true;
            this.tbx_imagePath.Name = "tbx_imagePath";
            this.tbx_imagePath.Size = new System.Drawing.Size(258, 88);
            this.tbx_imagePath.TabIndex = 1;
            this.tbx_imagePath.TextChanged += new System.EventHandler(this.tbx_imagePath_TextChanged);
            this.tbx_imagePath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbx_imagePath_KeyUp);
            // 
            // btn_selectImage
            // 
            this.btn_selectImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_selectImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_selectImage.Location = new System.Drawing.Point(196, 114);
            this.btn_selectImage.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_selectImage.Name = "btn_selectImage";
            this.btn_selectImage.Size = new System.Drawing.Size(67, 28);
            this.btn_selectImage.Style = Sunny.UI.UIStyle.Custom;
            this.btn_selectImage.TabIndex = 120;
            this.btn_selectImage.Text = "指定路径";
            this.btn_selectImage.Click += new System.EventHandler(this.btn_selectImage_Click);
            // 
            // Frm_FromFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(270, 255);
            this.Controls.Add(this.btn_selectImage);
            this.Controls.Add(this.tbx_imagePath);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_FromFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox tbx_imagePath;
        internal Sunny.UI.UIButton btn_selectImage;

    }
}