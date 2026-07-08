namespace UniversalControlSystem
{
    partial class LaserContorlForm
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
            this.Choose_Laser = new System.Windows.Forms.CheckBox();
            this.SetTheInterpolationAngle = new System.Windows.Forms.CheckBox();
            this.SetOperatingAngle = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Choose_Laser
            // 
            this.Choose_Laser.Appearance = System.Windows.Forms.Appearance.Button;
            this.Choose_Laser.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Choose_Laser.Location = new System.Drawing.Point(107, 57);
            this.Choose_Laser.Name = "Choose_Laser";
            this.Choose_Laser.Size = new System.Drawing.Size(155, 71);
            this.Choose_Laser.TabIndex = 0;
            this.Choose_Laser.Text = "是否出光";
            this.Choose_Laser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Choose_Laser.UseVisualStyleBackColor = true;
            this.Choose_Laser.CheckedChanged += new System.EventHandler(this.Choose_Laser_CheckedChanged);
            // 
            // SetTheInterpolationAngle
            // 
            this.SetTheInterpolationAngle.Appearance = System.Windows.Forms.Appearance.Button;
            this.SetTheInterpolationAngle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SetTheInterpolationAngle.Location = new System.Drawing.Point(107, 191);
            this.SetTheInterpolationAngle.Name = "SetTheInterpolationAngle";
            this.SetTheInterpolationAngle.Size = new System.Drawing.Size(155, 71);
            this.SetTheInterpolationAngle.TabIndex = 1;
            this.SetTheInterpolationAngle.Text = "设置插补角度";
            this.SetTheInterpolationAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SetTheInterpolationAngle.UseVisualStyleBackColor = true;
            this.SetTheInterpolationAngle.CheckedChanged += new System.EventHandler(this.SetTheInterpolationAngle_CheckedChanged);
            // 
            // SetOperatingAngle
            // 
            this.SetOperatingAngle.FormattingEnabled = true;
            this.SetOperatingAngle.Items.AddRange(new object[] {
            "0度",
            "90度",
            "180度",
            "270度"});
            this.SetOperatingAngle.Location = new System.Drawing.Point(107, 165);
            this.SetOperatingAngle.Name = "SetOperatingAngle";
            this.SetOperatingAngle.Size = new System.Drawing.Size(155, 20);
            this.SetOperatingAngle.TabIndex = 2;
            // 
            // LaserContorlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 362);
            this.Controls.Add(this.SetOperatingAngle);
            this.Controls.Add(this.SetTheInterpolationAngle);
            this.Controls.Add(this.Choose_Laser);
            this.Name = "LaserContorlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "激光设置界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LaserContorlForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LaserContorlForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox Choose_Laser;
        private System.Windows.Forms.CheckBox SetTheInterpolationAngle;
        private System.Windows.Forms.ComboBox SetOperatingAngle;
    }
}