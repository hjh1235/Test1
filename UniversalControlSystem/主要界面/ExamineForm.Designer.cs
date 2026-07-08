namespace UniversalControlSystem
{
    partial class ExamineForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_Weld = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_CCDDJ = new System.Windows.Forms.Button();
            this.btn_测高DJ = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lab_清洗点检 = new System.Windows.Forms.Label();
            this.lab_清洗点检时间 = new System.Windows.Forms.Label();
            this.lab_左CCD点检 = new System.Windows.Forms.Label();
            this.lab_左CCD点检时间 = new System.Windows.Forms.Label();
            this.lab_左测高点检 = new System.Windows.Forms.Label();
            this.lab_左测高点检时间 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lab_右测高点检 = new System.Windows.Forms.Label();
            this.lab_右测高点检时间 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lab_右CCD点检 = new System.Windows.Forms.Label();
            this.lab_右CCD点检时间 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(704, 511);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(727, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "右工位清洗点:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(727, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "左工位清洗点:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(848, 28);
            this.textBox1.Margin = new System.Windows.Forms.Padding(1);
            this.textBox1.MaxLength = 3;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(848, 88);
            this.textBox2.Margin = new System.Windows.Forms.Padding(1);
            this.textBox2.MaxLength = 3;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(129, 21);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btn_Weld
            // 
            this.btn_Weld.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Weld.Location = new System.Drawing.Point(4, 18);
            this.btn_Weld.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Weld.Name = "btn_Weld";
            this.btn_Weld.Size = new System.Drawing.Size(134, 41);
            this.btn_Weld.TabIndex = 5;
            this.btn_Weld.Text = "<首件工装清洗";
            this.btn_Weld.UseVisualStyleBackColor = true;
            this.btn_Weld.Click += new System.EventHandler(this.btn_NextStep_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_CCDDJ
            // 
            this.btn_CCDDJ.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CCDDJ.Location = new System.Drawing.Point(2, 18);
            this.btn_CCDDJ.Margin = new System.Windows.Forms.Padding(1);
            this.btn_CCDDJ.Name = "btn_CCDDJ";
            this.btn_CCDDJ.Size = new System.Drawing.Size(134, 41);
            this.btn_CCDDJ.TabIndex = 5;
            this.btn_CCDDJ.Text = "<CCD防松点检";
            this.btn_CCDDJ.UseVisualStyleBackColor = true;
            this.btn_CCDDJ.Click += new System.EventHandler(this.btn_CCDDJ_Click);
            // 
            // btn_测高DJ
            // 
            this.btn_测高DJ.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_测高DJ.Location = new System.Drawing.Point(4, 18);
            this.btn_测高DJ.Margin = new System.Windows.Forms.Padding(1);
            this.btn_测高DJ.Name = "btn_测高DJ";
            this.btn_测高DJ.Size = new System.Drawing.Size(134, 41);
            this.btn_测高DJ.TabIndex = 5;
            this.btn_测高DJ.Text = "<测高点检";
            this.btn_测高DJ.UseVisualStyleBackColor = true;
            this.btn_测高DJ.Click += new System.EventHandler(this.btn_测高DJ_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(2, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "点检状态:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(2, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "点检时间:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(0, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "左工位点检状态:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(0, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "左工位点检时间:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(2, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "左工位点检状态:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(2, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "左工位点检时间:";
            // 
            // lab_清洗点检
            // 
            this.lab_清洗点检.AutoSize = true;
            this.lab_清洗点检.Location = new System.Drawing.Point(67, 70);
            this.lab_清洗点检.Name = "lab_清洗点检";
            this.lab_清洗点检.Size = new System.Drawing.Size(41, 12);
            this.lab_清洗点检.TabIndex = 7;
            this.lab_清洗点检.Text = "未完成";
            // 
            // lab_清洗点检时间
            // 
            this.lab_清洗点检时间.AutoSize = true;
            this.lab_清洗点检时间.Location = new System.Drawing.Point(71, 98);
            this.lab_清洗点检时间.Name = "lab_清洗点检时间";
            this.lab_清洗点检时间.Size = new System.Drawing.Size(17, 12);
            this.lab_清洗点检时间.TabIndex = 7;
            this.lab_清洗点检时间.Text = "无";
            // 
            // lab_左CCD点检
            // 
            this.lab_左CCD点检.AutoSize = true;
            this.lab_左CCD点检.Location = new System.Drawing.Point(95, 72);
            this.lab_左CCD点检.Name = "lab_左CCD点检";
            this.lab_左CCD点检.Size = new System.Drawing.Size(41, 12);
            this.lab_左CCD点检.TabIndex = 7;
            this.lab_左CCD点检.Text = "未完成";
            // 
            // lab_左CCD点检时间
            // 
            this.lab_左CCD点检时间.AutoSize = true;
            this.lab_左CCD点检时间.Location = new System.Drawing.Point(101, 97);
            this.lab_左CCD点检时间.Name = "lab_左CCD点检时间";
            this.lab_左CCD点检时间.Size = new System.Drawing.Size(17, 12);
            this.lab_左CCD点检时间.TabIndex = 7;
            this.lab_左CCD点检时间.Text = "无";
            // 
            // lab_左测高点检
            // 
            this.lab_左测高点检.AutoSize = true;
            this.lab_左测高点检.Location = new System.Drawing.Point(97, 77);
            this.lab_左测高点检.Name = "lab_左测高点检";
            this.lab_左测高点检.Size = new System.Drawing.Size(41, 12);
            this.lab_左测高点检.TabIndex = 7;
            this.lab_左测高点检.Text = "未完成";
            // 
            // lab_左测高点检时间
            // 
            this.lab_左测高点检时间.AutoSize = true;
            this.lab_左测高点检时间.Location = new System.Drawing.Point(103, 110);
            this.lab_左测高点检时间.Name = "lab_左测高点检时间";
            this.lab_左测高点检时间.Size = new System.Drawing.Size(17, 12);
            this.lab_左测高点检时间.TabIndex = 7;
            this.lab_左测高点检时间.Text = "无";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(265, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "右工位点检状态:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(265, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "右工位点检时间:";
            // 
            // lab_右测高点检
            // 
            this.lab_右测高点检.AutoSize = true;
            this.lab_右测高点检.Location = new System.Drawing.Point(360, 77);
            this.lab_右测高点检.Name = "lab_右测高点检";
            this.lab_右测高点检.Size = new System.Drawing.Size(41, 12);
            this.lab_右测高点检.TabIndex = 7;
            this.lab_右测高点检.Text = "未完成";
            // 
            // lab_右测高点检时间
            // 
            this.lab_右测高点检时间.AutoSize = true;
            this.lab_右测高点检时间.Location = new System.Drawing.Point(366, 110);
            this.lab_右测高点检时间.Name = "lab_右测高点检时间";
            this.lab_右测高点检时间.Size = new System.Drawing.Size(17, 12);
            this.lab_右测高点检时间.TabIndex = 7;
            this.lab_右测高点检时间.Text = "无";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(267, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 12);
            this.label13.TabIndex = 6;
            this.label13.Text = "右工位点检状态:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(267, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 12);
            this.label14.TabIndex = 6;
            this.label14.Text = "右工位点检时间:";
            // 
            // lab_右CCD点检
            // 
            this.lab_右CCD点检.AutoSize = true;
            this.lab_右CCD点检.Location = new System.Drawing.Point(362, 72);
            this.lab_右CCD点检.Name = "lab_右CCD点检";
            this.lab_右CCD点检.Size = new System.Drawing.Size(41, 12);
            this.lab_右CCD点检.TabIndex = 7;
            this.lab_右CCD点检.Text = "未完成";
            // 
            // lab_右CCD点检时间
            // 
            this.lab_右CCD点检时间.AutoSize = true;
            this.lab_右CCD点检时间.Location = new System.Drawing.Point(368, 97);
            this.lab_右CCD点检时间.Name = "lab_右CCD点检时间";
            this.lab_右CCD点检时间.Size = new System.Drawing.Size(17, 12);
            this.lab_右CCD点检时间.TabIndex = 7;
            this.lab_右CCD点检时间.Text = "无";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lab_清洗点检时间);
            this.groupBox1.Controls.Add(this.lab_清洗点检);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btn_Weld);
            this.groupBox1.Location = new System.Drawing.Point(714, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 124);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "首件工装清洗:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lab_右CCD点检时间);
            this.groupBox2.Controls.Add(this.lab_左CCD点检时间);
            this.groupBox2.Controls.Add(this.lab_右CCD点检);
            this.groupBox2.Controls.Add(this.lab_左CCD点检);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btn_CCDDJ);
            this.groupBox2.Location = new System.Drawing.Point(716, 252);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 131);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CCD点检";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lab_右测高点检时间);
            this.groupBox3.Controls.Add(this.lab_左测高点检时间);
            this.groupBox3.Controls.Add(this.lab_右测高点检);
            this.groupBox3.Controls.Add(this.lab_左测高点检);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btn_测高DJ);
            this.groupBox3.Location = new System.Drawing.Point(718, 390);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(506, 131);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测高点检";
            // 
            // ExamineForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1229, 545);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExamineForm";
            this.Text = "首件点检";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExamineForm_FormClosing);
            this.Load += new System.EventHandler(this.ExamineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_Weld;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_CCDDJ;
        private System.Windows.Forms.Button btn_测高DJ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lab_清洗点检;
        private System.Windows.Forms.Label lab_清洗点检时间;
        private System.Windows.Forms.Label lab_左CCD点检;
        private System.Windows.Forms.Label lab_左CCD点检时间;
        private System.Windows.Forms.Label lab_左测高点检;
        private System.Windows.Forms.Label lab_左测高点检时间;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lab_右测高点检;
        private System.Windows.Forms.Label lab_右测高点检时间;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lab_右CCD点检;
        private System.Windows.Forms.Label lab_右CCD点检时间;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}