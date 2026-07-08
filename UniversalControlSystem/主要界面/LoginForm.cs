using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin.SkinControl;
using CCWin;
using UniversalControlSystem.MES;

namespace UniversalControlSystem
{
    public partial class LoginForm : Form
    {
        public static bool landingFinish = false;
        public static bool landingOk = false;
        bool bSaveNamePassword;
        public static bool bIgnoreMes;
        //WebReference.MESInterface mes1 = new WebReference.MESInterface();
        MainForm mainForm = new MainForm();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (图片上传.Checked == true)
                {
                    if (string.IsNullOrEmpty(txt_User.Text) && string.IsNullOrEmpty(txt_Password.Text) && string.IsNullOrEmpty(txt_MachineNO.Text) && string.IsNullOrEmpty(txt_MachineOrder.Text) && string.IsNullOrEmpty(txt_网址.Text))
                    {
                        MessageBox.Show("请填写信息");
                        return;
                    }
                }
                else
                {
                    mes.Instance().Load(txt_网址.Text);//加载网址
                    if (string.IsNullOrEmpty(txt_User.Text))
                    {
                        MessageBox.Show("请输入用户名！");
                        return;
                    }
                    if (string.IsNullOrEmpty(txt_Password.Text))
                    {
                        MessageBox.Show("请输入密码！");
                        return;
                    }
                    if (string.IsNullOrEmpty(txt_MachineNO.Text))
                    {
                        MessageBox.Show("请输入设备编号！");
                        return;
                    }
                    if (string.IsNullOrEmpty(txt_MachineOrder.Text))
                    {
                        MessageBox.Show("请输入指令单号！");
                        return;
                    }
                    if (string.IsNullOrEmpty(txt_网址.Text))
                    {
                        MessageBox.Show("请输入txt_网址！");
                        return;
                    }
                    if (string.IsNullOrEmpty(com_区域选择.Text))
                    {
                        MessageBox.Show("请选择区域！");
                        return;
                    }
                }
                if (bSaveNamePassword)
                {
                    Properties.Settings.Default.UserName = txt_User.Text;
                    Properties.Settings.Default.Password = txt_Password.Text;
                    Properties.Settings.Default.MachineNo = txt_MachineNO.Text;
                    Properties.Settings.Default.MakeOrder = txt_MachineOrder.Text;
                    Properties.Settings.Default.txt_网址 = txt_网址.Text;
                    Properties.Settings.Default.MesPlace = com_区域选择.Text;
                    Properties.Settings.Default.Save();
                }
                if (bIgnoreMes)
                {
                    if (txt_Password.Text == "123456")
                    {
                        landingOk = true;
                        landingFinish = true;
                        DialogResult = DialogResult.OK;
                        this.Hide();
                    }
                    else
                    {
                        landingFinish = false;
                        MessageBox.Show("密码错误！");
                        return;
                    }
                }
                else
                {
                    string result = mes.Instance().Login(Properties.Settings.Default.UserName, Properties.Settings.Default.Password, Properties.Settings.Default.MachineNo, Properties.Settings.Default.MakeOrder);
                    if (result.ToUpper() == "TRUE")
                    {
                        mes.Instance().userCode = txt_User.Text;
                        mes.Instance().deviceCode = txt_MachineNO.Text;
                        landingOk = true;
                        landingFinish = true;
                        DialogResult = DialogResult.OK;
                        this.Hide();
                    }
                    else
                    {
                        landingFinish = false;
                        MessageBox.Show("登录失败！" + result);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txt_User.Text = Properties.Settings.Default.UserName;
            txt_Password.Text = Properties.Settings.Default.Password;
            txt_MachineNO.Text = Properties.Settings.Default.MachineNo;
            txt_MachineOrder.Text = Properties.Settings.Default.MakeOrder;
            txt_网址.Text = Properties.Settings.Default.txt_网址;
            com_区域选择.Text = Properties.Settings.Default.MesPlace;

            //mes区域类加载
            if (com_区域选择.Text == "南京一期")
            {
                mes.mesDate = new NJOneMes();
            }
            if (com_区域选择.Text == "南京二期")
            {
                mes.mesDate = new NJTwoMes();
            }
            if (com_区域选择.Text == "南昌一期")
            {
                mes.mesDate = new NCOneMes();
            }
            if (com_区域选择.Text == "南昌二期")
            {
                mes.mesDate = new NCTwoMes();
            }
        }
        private void cb_SaveNamePassword_CheckedChanged(object sender, EventArgs e)
        {
            bSaveNamePassword = cb_SaveNamePassword.Checked;
        }

        private void cb_IgnoreMes_CheckedChanged(object sender, EventArgs e)
        {
            bIgnoreMes = cb_IgnoreMes.Checked;
        }
        private void cb_DoubleStation_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.DoubleStation)
            {
                skinLine1.Location = new Point() { X = skinLine1.Location.X, Y = skinLine1.Location.Y + 38 };
                txt_MachineOrder.Location = new Point() { X = txt_MachineOrder.Location.X, Y = txt_MachineOrder.Location.Y + 38 };
                cb_IgnoreMes.Location = new Point() { X = cb_IgnoreMes.Location.X, Y = cb_IgnoreMes.Location.Y + 38 };
                cb_SaveNamePassword.Location = new Point() { X = cb_SaveNamePassword.Location.X, Y = cb_SaveNamePassword.Location.Y + 38 };
                btn_Login.Location = new Point() { X = btn_Login.Location.X, Y = btn_Login.Location.Y + 38 };
                label1.Visible = true;
                label2.Visible = true;
                txt_MachineOrder.Visible = true;
            }
            else
            {
                skinLine1.Location = new Point() { X = skinLine1.Location.X, Y = skinLine1.Location.Y - 38 };
                txt_MachineOrder.Location = new Point() { X = txt_MachineOrder.Location.X, Y = txt_MachineOrder.Location.Y - 38 };
                cb_IgnoreMes.Location = new Point() { X = cb_IgnoreMes.Location.X, Y = cb_IgnoreMes.Location.Y - 38 };
                cb_SaveNamePassword.Location = new Point() { X = cb_SaveNamePassword.Location.X, Y = cb_SaveNamePassword.Location.Y - 38 };
                btn_Login.Location = new Point() { X = btn_Login.Location.X, Y = btn_Login.Location.Y - 38 };
                txt_MachineOrder.Text = txt_MachineNO.Text;
                label1.Visible = false;
                label2.Visible = false;
                txt_MachineOrder.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            skinPanel1.SetBounds(this.Width / 2 - skinPanel1.Width / 2, this.Height / 2 - skinPanel1.Height / 2, skinPanel1.Width, skinPanel1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.Top = 0;
            //this.Left = 0;
            //this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            //this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            //skinPanel1.SetBounds(this.Width / 2 - skinPanel1.Width / 2, this.Height / 2 - skinPanel1.Height / 2, skinPanel1.Width, skinPanel1.Height);
            ////if (this.Width / 2 - skinPanel1.Width / 2== skinPanel1.Top)
            ////{
            //timer1.Stop();
        }

        private void com_区域选择_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_区域选择.Text == "南京一期")
            {
                mes.mesDate = new NJOneMes();
            }
            if (com_区域选择.Text == "南京二期")
            {
                mes.mesDate = new NJTwoMes();
            }
            if (com_区域选择.Text == "南昌一期")
            {
                mes.mesDate = new NCOneMes();
            }
            if (com_区域选择.Text == "南昌二期")
            {
                mes.mesDate = new NCTwoMes();
            }
        }
    }
}
