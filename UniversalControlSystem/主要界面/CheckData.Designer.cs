namespace UniversalControlSystem
{
    partial class CheckData
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewCheckData = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheckData)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dataGridViewCheckData
            // 
            this.dataGridViewCheckData.AllowUserToAddRows = false;
            this.dataGridViewCheckData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewCheckData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCheckData.Location = new System.Drawing.Point(4, 13);
            this.dataGridViewCheckData.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewCheckData.Name = "dataGridViewCheckData";
            this.dataGridViewCheckData.RowHeadersWidth = 10;
            this.dataGridViewCheckData.RowTemplate.Height = 23;
            this.dataGridViewCheckData.Size = new System.Drawing.Size(553, 528);
            this.dataGridViewCheckData.TabIndex = 22;
            // 
            // CheckData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 543);
            this.Controls.Add(this.dataGridViewCheckData);
            this.Name = "CheckData";
            this.Text = "CheckData";
            this.Load += new System.EventHandler(this.CheckData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheckData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridViewCheckData;
    }
}