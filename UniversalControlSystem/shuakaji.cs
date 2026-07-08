using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace UniversalControlSystem
{
    [Serializable]
    class card : SerialPortFrom
    {

        public static void card0()
        {

            System.IO.Ports.SerialPort serialPort;


            serialPort = new System.IO.Ports.SerialPort();
            serialPort.PortName = "COM5";
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Parity = Parity.None;
            if (serialPort.IsOpen == true)
            {
            }
            else
            {

                serialPort.Open();
            }




            while (true)
            {
                string id="";

                try
                {
                    int count = serialPort.BytesToRead;
                    byte[] buff = new byte[count];
                    serialPort.Read(buff, 0, count);
                    string id2 = Encoding.UTF8.GetString(buff);
                    //"\u00021234909395\r\n\u0003"
                    if (id2 != "")
                    {
                        id = id2.Replace("\u0002", "").Replace("\r\n\u0003", "");
                    }



                    // string str = "select UserPassword,UserPermissions,PermissionsLevel,UserName from UserManage where UserID='" + txtUserID.Text + "'";
                    string str = "select UserPassword,UserPermissions,PermissionsLevel,UserName from UserManage where UserPassword='" + id + "'";
                    string username = SQLiteConnect.getQuery(str, "UserName");
                    if (username != "")

                    {
                        FormUserLogoin.userpermissions = SQLiteConnect.getQuery(str, "UserPermissions").Trim();


                        FormUserLogoin.userLevel = Convert.ToInt32(SQLiteConnect.getQuery(str, "PermissionsLevel").Trim());


                        FormUserLogoin.userName = SQLiteConnect.getQuery(str, "UserName").Trim();

                        FormStart.LOG_ShowFrom["系统LOG"].Enqueue("当前登录者：" + FormUserLogoin.userName + ":" + FormUserLogoin.userpermissions);

                    }




                }

                catch (Exception error)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.查询数据异常.ToString() + "\r\n" + error);
                    return;
                }
                Thread.Sleep(100);
            }
        }
    }
}
