namespace UniversalControlSystem
{
    partial class frm_Fixture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Fixture));
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxToolName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxModelName = new System.Windows.Forms.ComboBox();
            this.lblOrgRow = new System.Windows.Forms.Label();
            this.lblOrgCol = new System.Windows.Forms.Label();
            this.lblOrgAngle = new System.Windows.Forms.Label();
            this.lblNowAngle = new System.Windows.Forms.Label();
            this.lblNowCol = new System.Windows.Forms.Label();
            this.lblNowRow = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_sure = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.btnGetPosion = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(285, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "Angle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "Col_X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "Row_Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "原点坐标：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "当前坐标：";
            // 
            // tbxToolName
            // 
            this.tbxToolName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxToolName.Location = new System.Drawing.Point(105, 12);
            this.tbxToolName.Name = "tbxToolName";
            this.tbxToolName.Size = new System.Drawing.Size(245, 26);
            this.tbxToolName.TabIndex = 27;
            this.tbxToolName.TextChanged += new System.EventHandler(this.tbxToolName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "坐标定位工具名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "模板定位选择：";
            // 
            // cbxModelName
            // 
            this.cbxModelName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxModelName.FormattingEnabled = true;
            this.cbxModelName.Location = new System.Drawing.Point(105, 51);
            this.cbxModelName.Name = "cbxModelName";
            this.cbxModelName.Size = new System.Drawing.Size(245, 22);
            this.cbxModelName.TabIndex = 29;
            this.cbxModelName.SelectedIndexChanged += new System.EventHandler(this.cbxPosition_SelectedIndexChanged);
            // 
            // lblOrgRow
            // 
            this.lblOrgRow.AutoSize = true;
            this.lblOrgRow.Location = new System.Drawing.Point(102, 135);
            this.lblOrgRow.Name = "lblOrgRow";
            this.lblOrgRow.Size = new System.Drawing.Size(11, 12);
            this.lblOrgRow.TabIndex = 30;
            this.lblOrgRow.Text = "0";
            // 
            // lblOrgCol
            // 
            this.lblOrgCol.AutoSize = true;
            this.lblOrgCol.Location = new System.Drawing.Point(196, 135);
            this.lblOrgCol.Name = "lblOrgCol";
            this.lblOrgCol.Size = new System.Drawing.Size(11, 12);
            this.lblOrgCol.TabIndex = 31;
            this.lblOrgCol.Text = "0";
            // 
            // lblOrgAngle
            // 
            this.lblOrgAngle.AutoSize = true;
            this.lblOrgAngle.Location = new System.Drawing.Point(285, 135);
            this.lblOrgAngle.Name = "lblOrgAngle";
            this.lblOrgAngle.Size = new System.Drawing.Size(11, 12);
            this.lblOrgAngle.TabIndex = 32;
            this.lblOrgAngle.Text = "0";
            // 
            // lblNowAngle
            // 
            this.lblNowAngle.AutoSize = true;
            this.lblNowAngle.Location = new System.Drawing.Point(285, 169);
            this.lblNowAngle.Name = "lblNowAngle";
            this.lblNowAngle.Size = new System.Drawing.Size(11, 12);
            this.lblNowAngle.TabIndex = 35;
            this.lblNowAngle.Text = "0";
            // 
            // lblNowCol
            // 
            this.lblNowCol.AutoSize = true;
            this.lblNowCol.Location = new System.Drawing.Point(196, 169);
            this.lblNowCol.Name = "lblNowCol";
            this.lblNowCol.Size = new System.Drawing.Size(11, 12);
            this.lblNowCol.TabIndex = 34;
            this.lblNowCol.Text = "0";
            // 
            // lblNowRow
            // 
            this.lblNowRow.AutoSize = true;
            this.lblNowRow.Location = new System.Drawing.Point(102, 169);
            this.lblNowRow.Name = "lblNowRow";
            this.lblNowRow.Size = new System.Drawing.Size(11, 12);
            this.lblNowRow.TabIndex = 33;
            this.lblNowRow.Text = "0";
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTimer.Location = new System.Drawing.Point(90, 261);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(52, 14);
            this.lblTimer.TabIndex = 39;
            this.lblTimer.Text = "耗时：";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(279, 246);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 29);
            this.btn_cancel.TabIndex = 38;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_sure
            // 
            this.btn_sure.Location = new System.Drawing.Point(198, 246);
            this.btn_sure.Name = "btn_sure";
            this.btn_sure.Size = new System.Drawing.Size(75, 29);
            this.btn_sure.TabIndex = 37;
            this.btn_sure.Text = "确定";
            this.btn_sure.UseVisualStyleBackColor = true;
            this.btn_sure.Click += new System.EventHandler(this.btn_sure_Click);
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(9, 246);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 29);
            this.btn_run.TabIndex = 36;
            this.btn_run.Text = "运行";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btnGetPosion
            // 
            this.btnGetPosion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetPosion.Location = new System.Drawing.Point(10, 196);
            this.btnGetPosion.Name = "btnGetPosion";
            this.btnGetPosion.Size = new System.Drawing.Size(154, 23);
            this.btnGetPosion.TabIndex = 40;
            this.btnGetPosion.Text = "当前坐标设定为参考原点坐标";
            this.btnGetPosion.UseVisualStyleBackColor = true;
            this.btnGetPosion.Click += new System.EventHandler(this.btnGetPosion_Click);
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.Color.Red;
            this.lblResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResult.Location = new System.Drawing.Point(12, 229);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(39, 14);
            this.lblResult.TabIndex = 80;
            this.lblResult.Text = "FAIL";
            // 
            // frm_Fixture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(361, 284);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnGetPosion);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_sure);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.lblNowAngle);
            this.Controls.Add(this.lblNowCol);
            this.Controls.Add(this.lblNowRow);
            this.Controls.Add(this.lblOrgAngle);
            this.Controls.Add(this.lblOrgCol);
            this.Controls.Add(this.lblOrgRow);
            this.Controls.Add(this.cbxModelName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxToolName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_Fixture";
            this.Text = "位置定位";
            this.Load += new System.EventHandler(this.frm_Fixture_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxToolName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxModelName;
        private System.Windows.Forms.Label lblOrgRow;
        private System.Windows.Forms.Label lblOrgCol;
        private System.Windows.Forms.Label lblOrgAngle;
        private System.Windows.Forms.Label lblNowAngle;
        private System.Windows.Forms.Label lblNowCol;
        private System.Windows.Forms.Label lblNowRow;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_sure;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btnGetPosion;
        private System.Windows.Forms.Label lblResult;


    }
}