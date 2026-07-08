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
    public partial class FormAxisSetting : Form
    {
        public static GoogolCardInfo hardInfo;
        public FormAxisSetting(GoogolCardInfo Info)
        {
            InitializeComponent();
            hardInfo = Info;
        }

        private void FormAxisSetting_Load(object sender, EventArgs e)
        {
            label1.Text = hardInfo.hardwareName.ToString();
            comboBoxCardNo.SelectedIndex = hardInfo.iCardNo;
            comboBoxAxisNo.SelectedIndex = hardInfo.iAxisNo;
            txt_Acc.Text = hardInfo.dAcc.ToString();
            txt_Dec.Text = hardInfo.dDec.ToString();
            txt_Speed.Text = hardInfo.dSpeed.ToString();
            txt_GoHomeSpeed.Text = hardInfo.dGoHomeSpeed.ToString();
            comboBoxPlusFeed.Text = hardInfo.dPlusFeed.ToString();
        }

        private void comboBoxCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            hardInfo.iCardNo = Convert.ToInt16(comboBoxCardNo.Text);
        }

        private void comboBoxAxisNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            hardInfo.iAxisNo = Convert.ToInt16(comboBoxAxisNo.Text);
        }

        private void txt_Acc_Validated(object sender, EventArgs e)
        {
            hardInfo.dAcc = Convert.ToDouble(txt_Acc.Text);
        }

        private void txt_Dec_Validated(object sender, EventArgs e)
        {
            hardInfo.dDec = Convert.ToDouble(txt_Dec.Text);
        }

        private void txt_Speed_Validated(object sender, EventArgs e)
        {
            hardInfo.dSpeed = Convert.ToDouble(txt_Speed.Text);
        }

        private void txt_GoHomeSpeed_Validated(object sender, EventArgs e)
        {
            hardInfo.dGoHomeSpeed = Convert.ToDouble(txt_GoHomeSpeed.Text);
        }
        
        private void comboBoxPlusFeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            hardInfo.dPlusFeed = Convert.ToDouble(comboBoxPlusFeed.Text);
        }
        private void txt_Acc_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_Dec_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Speed_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_GoHomeSpeed_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
