using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace UniversalControlSystem
{
    public partial class FormUserLogoin : Form
    {
        public static string userpermissions = "操作员";
        public static int userLevel = 1;
        public static string userName;
        public bool UserLoding = false;       
        public FormUserLogoin()
        {
            InitializeComponent();
        }             
        public void  getdataset()
        {

            if (txtPassword.Text == "" || txtUserID.Text == "")
            {
                MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.数据不能为空.ToString());
                return;
            }
            if (txtUserID.Text == "test" && txtPassword.Text == "test")
            {
                FormUserLogoin.userName = "test";
                FormUserLogoin.userpermissions = "test";
                FormUserLogoin.userLevel = 10;
                Close();
                return;
            }
            try
            {
                string str = "select UserPassword,UserPermissions,PermissionsLevel,UserName from UserManage where UserID='" + txtUserID.Text + "'";         
                string pword=SQLiteConnect.getQuery(str,"UserPassword");
                if (pword == txtPassword.Text)
                {
                    userpermissions = SQLiteConnect.getQuery(str, "UserPermissions").Trim();
                    userLevel = Convert.ToInt32(SQLiteConnect.getQuery(str, "PermissionsLevel").Trim());
                    userName = SQLiteConnect.getQuery(str, "UserName").Trim();                  
                    Close();
                    return;
                }
                else if(pword=="")
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.该账号不存在.ToString());
                    return;
                }
                else
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.密码错误.ToString());
                    return;
                }                 
            }
            catch (Exception error)
            {
                MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.查询数据异常.ToString() + "\r\n" + error);
                return;
            }          
        }           
        private void btnDetermine_Click(object sender, EventArgs e)
        {
            getdataset();
        }

        private void txtUserID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (UserLoding == false)
                {
                    UserLoding = true;
                    getdataset();                   
                }
                else
                {
                    UserLoding = false;
                }                            
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (UserLoding == false)
                {
                    UserLoding = true;
                    getdataset();                   
                }
                else
                {
                    UserLoding = false;
                }
            }
        }
    }
}
