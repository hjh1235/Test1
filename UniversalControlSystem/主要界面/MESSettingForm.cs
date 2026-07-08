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
    public partial class MESSettingForm : Form
    {
        public MESSettingForm()
        {
            InitializeComponent();
        }

        private void MESSettingForm_Load(object sender, EventArgs e)
        {
            txt_User.Text = Properties.Settings.Default.UserName;
            txt_Password.Text = Properties.Settings.Default.Password;
            txt_MachineNO.Text = Properties.Settings.Default.MachineNo;
            txt_MO.Text = Properties.Settings.Default.MakeOrder;
            txt_MachineNoRight.Text = Properties.Settings.Default.MachineNoRight;
            txt_Pos.Text = Properties.Settings.Default.MachinePosition;
        }

        private void btn_Login_Click_1(object sender, EventArgs e)
        {
            string result = mes.Instance().Login(Properties.Settings.Default.UserName, Properties.Settings.Default.Password, Properties.Settings.Default.MachineNo, Properties.Settings.Default.MakeOrder);
            if (result.ToUpper() == "OK")
            {
                mes.Instance().userCode = txt_User.Text;
                mes.Instance().deviceCode = txt_MachineNO.Text;

                DialogResult = DialogResult.OK;
                this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败！" + result);
                return;
            }
        }
    }
}
