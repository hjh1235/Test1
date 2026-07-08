namespace UniversalControlSystem
{
    partial class networkSer
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSendPort1 = new System.Windows.Forms.TextBox();
            this.txt_IPSet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRecPort1 = new System.Windows.Forms.TextBox();
            this.SendDateTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSPopen = new System.Windows.Forms.Button();
            this.lblPortInd = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.更新 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.连接列表 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(116, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 29);
            this.label1.TabIndex = 29;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSendPort1
            // 
            this.txtSendPort1.Location = new System.Drawing.Point(76, 188);
            this.txtSendPort1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSendPort1.Multiline = true;
            this.txtSendPort1.Name = "txtSendPort1";
            this.txtSendPort1.Size = new System.Drawing.Size(136, 24);
            this.txtSendPort1.TabIndex = 30;
            this.txtSendPort1.TextChanged += new System.EventHandler(this.txtSendPort1_TextChanged);
            // 
            // txt_IPSet
            // 
            this.txt_IPSet.Location = new System.Drawing.Point(76, 154);
            this.txt_IPSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_IPSet.Multiline = true;
            this.txt_IPSet.Name = "txt_IPSet";
            this.txt_IPSet.Size = new System.Drawing.Size(136, 24);
            this.txt_IPSet.TabIndex = 31;
            this.txt_IPSet.TextChanged += new System.EventHandler(this.txt_IPSet_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 32;
            this.label2.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 33;
            this.label3.Text = "Port:";
            // 
            // txtRecPort1
            // 
            this.txtRecPort1.Location = new System.Drawing.Point(9, 319);
            this.txtRecPort1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRecPort1.Multiline = true;
            this.txtRecPort1.Name = "txtRecPort1";
            this.txtRecPort1.Size = new System.Drawing.Size(203, 104);
            this.txtRecPort1.TabIndex = 38;
            // 
            // SendDateTxt
            // 
            this.SendDateTxt.Location = new System.Drawing.Point(76, 222);
            this.SendDateTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendDateTxt.Multiline = true;
            this.SendDateTxt.Name = "SendDateTxt";
            this.SendDateTxt.Size = new System.Drawing.Size(136, 24);
            this.SendDateTxt.TabIndex = 39;
            this.SendDateTxt.TextChanged += new System.EventHandler(this.SendDateTxt_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 36;
            this.label7.Text = "发送:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(7, 252);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(205, 40);
            this.btnSend.TabIndex = 37;
            this.btnSend.Text = "send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSPopen
            // 
            this.btnSPopen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSPopen.Location = new System.Drawing.Point(251, 154);
            this.btnSPopen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSPopen.Name = "btnSPopen";
            this.btnSPopen.Size = new System.Drawing.Size(205, 90);
            this.btnSPopen.TabIndex = 34;
            this.btnSPopen.Text = "建立";
            this.btnSPopen.UseVisualStyleBackColor = true;
            this.btnSPopen.Click += new System.EventHandler(this.btnSPopen_Click);
            // 
            // lblPortInd
            // 
            this.lblPortInd.BackColor = System.Drawing.Color.Maroon;
            this.lblPortInd.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPortInd.Location = new System.Drawing.Point(462, 154);
            this.lblPortInd.Name = "lblPortInd";
            this.lblPortInd.Size = new System.Drawing.Size(85, 89);
            this.lblPortInd.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 40;
            this.label4.Text = "接收：";
            // 
            // 更新
            // 
            this.更新.Location = new System.Drawing.Point(251, 318);
            this.更新.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.更新.Name = "更新";
            this.更新.Size = new System.Drawing.Size(91, 42);
            this.更新.TabIndex = 41;
            this.更新.Text = "更新";
            this.更新.UseVisualStyleBackColor = true;
            this.更新.Visible = false;
            this.更新.Click += new System.EventHandler(this.更新_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.连接列表);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.更新);
            this.groupBox1.Controls.Add(this.txtSendPort1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_IPSet);
            this.groupBox1.Controls.Add(this.txtRecPort1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SendDateTxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblPortInd);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.btnSPopen);
            this.groupBox1.Location = new System.Drawing.Point(117, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(762, 541);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网络参数设置服务端";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // 连接列表
            // 
            this.连接列表.Location = new System.Drawing.Point(414, 295);
            this.连接列表.Multiline = true;
            this.连接列表.Name = "连接列表";
            this.连接列表.Size = new System.Drawing.Size(342, 194);
            this.连接列表.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(426, 263);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 29);
            this.label5.TabIndex = 43;
            this.label5.Text = "连接列表";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // networkSer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 652);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "networkSer";
            this.Text = "SerialPort";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSendPort1;
        private System.Windows.Forms.TextBox txt_IPSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRecPort1;
        private System.Windows.Forms.TextBox SendDateTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSPopen;
        public  System.Windows.Forms.Label lblPortInd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button 更新;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox 连接列表;
    }
}