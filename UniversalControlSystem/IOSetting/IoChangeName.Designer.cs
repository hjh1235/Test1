namespace UniversalControlSystem
{
    partial class IoChangeName
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
            this.dataGridViewOutput = new System.Windows.Forms.DataGridView();
            this.dataGridViewInput = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOutput
            // 
            this.dataGridViewOutput.AllowUserToAddRows = false;
            this.dataGridViewOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutput.Location = new System.Drawing.Point(624, 38);
            this.dataGridViewOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewOutput.Name = "dataGridViewOutput";
            this.dataGridViewOutput.RowHeadersWidth = 10;
            this.dataGridViewOutput.RowTemplate.Height = 23;
            this.dataGridViewOutput.Size = new System.Drawing.Size(667, 764);
            this.dataGridViewOutput.TabIndex = 23;
            this.dataGridViewOutput.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewOutput_CellBeginEdit);
            this.dataGridViewOutput.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOutput_CellEndEdit);
            this.dataGridViewOutput.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOutput_CellValidated);
            // 
            // dataGridViewInput
            // 
            this.dataGridViewInput.AllowUserToAddRows = false;
            this.dataGridViewInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInput.Location = new System.Drawing.Point(11, 38);
            this.dataGridViewInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewInput.Name = "dataGridViewInput";
            this.dataGridViewInput.RowHeadersWidth = 10;
            this.dataGridViewInput.RowTemplate.Height = 23;
            this.dataGridViewInput.Size = new System.Drawing.Size(605, 764);
            this.dataGridViewInput.TabIndex = 22;
            this.dataGridViewInput.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewInput_CellBeginEdit);
            this.dataGridViewInput.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInput_CellContentDoubleClick);
            this.dataGridViewInput.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInput_CellValidated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "输入改名展示";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(876, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "输出改名展示";
            // 
            // IoChangeName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 815);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewOutput);
            this.Controls.Add(this.dataGridViewInput);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "IoChangeName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改IO名";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IoChangeName_FormClosed);
            this.Load += new System.EventHandler(this.IoChangeName_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOutput;
        private System.Windows.Forms.DataGridView dataGridViewInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}