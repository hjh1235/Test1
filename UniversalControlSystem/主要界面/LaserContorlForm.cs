using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public partial class LaserContorlForm : Form
    {
        public LaserContorlForm()
        {
            InitializeComponent();
        }

        private void Choose_Laser_CheckedChanged(object sender, EventArgs e)
        {
           // if (Choose_Laser.Checked == true)
            //{
            //    Hard_Ward_Contral._LaserControlParameter._LaserControlData_Dictionary["LaserControlData"].IS_Choose_Laser = true;
            //    Hard_Ward_Contral._LaserControlParameter.SaveDoc();
            //}
            //else
            //{
            //    Hard_Ward_Contral._LaserControlParameter._LaserControlData_Dictionary["LaserControlData"].IS_Choose_Laser = false;
            //    Hard_Ward_Contral._LaserControlParameter.SaveDoc();
            //}
        }

        private void SetTheInterpolationAngle_CheckedChanged(object sender, EventArgs e)
        {
            if (SetOperatingAngle.Text == "")
            {
                MessageBox.Show("请选择角度");
              
            }
            else
            {
                Hard_Ward_Contral._LaserControlParameter._LaserControlData_Dictionary["LaserControlData"].InterpolationOperationAngle =Convert.ToDouble(SetOperatingAngle.Text);
                Hard_Ward_Contral._LaserControlParameter.SaveDoc();
            }
        }

        private void LaserContorlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
        }
        private void LaserContorlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
