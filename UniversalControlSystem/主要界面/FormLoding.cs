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
    public partial class FormLoding : Form
    {
        public static string CompensationPath = Application.StartupPath + "\\SettingBug.ini";
        public static string path;      
        public const string Compensation = "user";
        public FormLoding()
        {
            InitializeComponent();
        }

        private void FormLoding_Load(object sender, EventArgs e)
        {
            System.Text.StringBuilder get1 = new System.Text.StringBuilder(1000);
            ConfINI.GetPrivateProfileString(Compensation, " UserName", "", get1, 1000, CompensationPath);
            txtUserName.Text = get1.ToString();
            ConfINI.GetPrivateProfileString(Compensation, " PassWord", "", get1, 1000, CompensationPath);
            txtPassword.Text = get1.ToString();
            ConfINI.GetPrivateProfileString(Compensation, " MachineNO_num", "", get1, 1000, CompensationPath);
            txtMachineNO.Text = get1.ToString();
            ConfINI.GetPrivateProfileString(Compensation, " ServerIP", "", get1, 1000, CompensationPath);
            ServerIP.Text = get1.ToString();
            mes.Instance().ServerIP = ServerIP.Text;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {           
           
            if (txtUserName.Text=="")
            {
                MessageBox.Show("请输入用户名","提示");
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("请输入密码", "提示");
                return;
            }
            if (txtMachineNO.Text == "")
            {
                MessageBox.Show("请输入账号", "提示");
                return;
            }
            if (ServerIP.Text == "")
            {
                MessageBox.Show("请输入网址", "提示");
                return;
            }
            if (ckNoMes.Checked == true)
            {
                if (txtPassword.Text == "123")
                {
                    this.Hide();
                    MainForm formMain = new MainForm();
                    formMain.ShowDialog();
                    return;
                }
            }

            string offset = ServerIP.Text;
            ConfINI.writeINI(Compensation, "ServerIP", offset, CompensationPath);
            mes.Instance().Load();

            string result = mes.Instance().Login(txtUserName.Text, txtPassword.Text, txtMachineNO.Text);
            if (result.ToUpper() == "OK")
            {
                offset = txtUserName.Text;
                ConfINI.writeINI(Compensation, "UserName", offset, CompensationPath);
                offset = txtPassword.Text;
                ConfINI.writeINI(Compensation, "PassWord", offset, CompensationPath);
                offset = txtMachineNO.Text;
                ConfINI.writeINI(Compensation, "MachineNO_num", offset, CompensationPath);

                offset = ServerIP.Text;
                ConfINI.writeINI(Compensation, "ServerIP", offset, CompensationPath);


                mes.Instance().userCode = txtUserName.Text;
                mes.Instance().deviceCode = txtMachineNO.Text;              

                DialogResult = DialogResult.OK;
                this.Hide();
                MainForm formMain = new MainForm();
                formMain.ShowDialog();


            }
            else
            {
                MessageBox.Show("登录失败！" + result);              
                return;
            }
        }

        private void ckNoMes_CheckedChanged(object sender, EventArgs e)
        {

        }     
    }
}
