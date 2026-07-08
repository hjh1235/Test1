
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Concurrent;
namespace UniversalControlSystem
{
    [Serializable]
    public partial class SerialPortCom : Communication_DateTool, Commu_Interface
    {
        public string DataReceivedstr = "";
        public string DataReceivedstr_STR = "";
        public string SerialPort_BaudRate = "";
        public string cmbDataBits = "";
        public string PortName = "";
        public string _Parity = "";
        public string cmbStopBits = "";
        public string SerialPort_txtSendPort = "";
        public static Action<int, string> updateInfo = (p1, p2) => { };//更新数据
        [NonSerialized]
        public SerialPort COMM = new SerialPort();
        //定义一个委托
        //[NonSerialized]
        //public delegate void delegateRun();
        ////定义一个事件
        //[NonSerialized]
        //public event delegateRun eventRun;
        public bool flag = false;
        int received_count = 0;
        static object NM = new object();
        static object lock1 = new object(), lock2 = new object();
        /// <summary>
        /// 检测串口是否打开
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            lock (lock2)
            {
                try
                {
                    if (COMM.IsOpen == true)
                    {
                        flag = true;
                        return flag;
                    }
                    else
                    {
                    }
                    COMM.PortName = PortName;                //设置串口名
                    COMM.BaudRate = int.Parse(SerialPort_BaudRate);  //设置串口波特率
                    float f = 1;     //设置停止位
                    if (cmbStopBits == "1")
                    {
                        COMM.StopBits = StopBits.One;
                    }
                    else if (cmbStopBits == "1.5")
                    {
                        COMM.StopBits = StopBits.OnePointFive;
                    }
                    else if (cmbStopBits == "2")
                    {
                        COMM.StopBits = StopBits.Two;
                    }
                    else if (cmbStopBits == "")
                    {
                        COMM.StopBits = StopBits.None;
                    }

                    if (cmbDataBits == "5")
                    {
                        COMM.DataBits = 5; //设置数据位

                    }
                    else if (cmbDataBits == "6")
                    {
                        COMM.DataBits = 6; //设置数据
                    }
                    else if (cmbDataBits == "7")
                    {
                        COMM.DataBits = 7; //设置数据
                    }
                    else if (cmbDataBits == "8")
                    {
                        COMM.DataBits = 8; //设置数据
                    }

                    if (_Parity == "None")
                    {
                        COMM.Parity = Parity.None;

                    }
                    else if (_Parity == "Odd")
                    {
                        COMM.Parity = Parity.Odd;
                    }
                    else if (_Parity == "Even")
                    {
                        COMM.Parity = Parity.Even;
                    }
                    else if (_Parity == "Mark")
                    {
                        COMM.Parity = Parity.Mark;
                    }
                    else if (_Parity == "Space")
                    {
                        COMM.Parity = Parity.Space;
                    }
                    COMM.DataReceived += new SerialDataReceivedEventHandler(DataReceived);

                    COMM.Open();
                    if (COMM.IsOpen == true)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }


                }
                catch (Exception)
                {
                    flag = false;
                    return flag;
                }
            }
            return flag;
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            if (COMM.IsOpen)
            {
                COMM.Close();
            }
        }
        /// <summary>
        /// 串口数据接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            lock (NM)
            {
                try
                {
                    Thread.Sleep(100);
                    if (COMM.IsOpen && COMM.BytesToRead > 0)
                    {
                        int n = COMM.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致   ；
                        byte[] buf = new byte[n];//声明一个临时字节数组存储当前来的串口数据   
                        received_count += n;//增加接收计数                         
                        COMM.Read(buf, 0, n);//读取缓冲数据 
                        for (int i = 0; i < buf.Length; i++)
                        {
                            DataReceivedstr_STR = System.Text.Encoding.Default.GetString(buf);
                            DataReceivedstr = System.Text.Encoding.Default.GetString(buf);
                            //eventRun();//被引发的事件
                        }
                        //if (COMM.PortName.Equals(DataManage.m_Doc.m_dataDictionary["扫码"].m_dataDictionary["扫码串口"].objValue))
                        //{
                        //    DataManage.m_Doc.m_dataDictionary["扫码"].m_dataDictionary["扫码数据"].objValue = DataReceivedstr_STR;
                        //    updateInfo(3, DataReceivedstr_STR);
                        //}
                    }
                }
                catch (Exception ex)
                {
                }
                string dd = DataReceivedstr;
            }
        }
        /// <summary>
        /// 获取串口接收数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetRec(string str)
        {
            string DataReceived = "";
            DataReceived = DataReceivedstr;
            return DataReceived;
        }
        /// <summary>
        /// 数据发送测试
        /// </summary>
        /// <param name="str"></param>
        /// <param name="CodeBar"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int SendData(string str)
        {
            //CodeBar = "";
            lock (lock1)
            {
                int date = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (COMM.IsOpen)
                    {
                        try
                        {
                            COMM.Write(str + "\r\n");
                            Thread.Sleep(100);
                            break;
                        }
                        catch (Exception)
                        {
                            date = (int)ERecvResult.串口发送数据失败;
                            break;
                        }
                    }
                    else
                    {
                        if (Open() == false)
                        {
                            date = (int)ERecvResult.串口发送数据失败;
                        }
                    }
                }
                return date;
            }
        }


        public bool Send(string SendStr)
        {
            bool SendFinish = false; ;
            if (SendData(SendStr) == 0)
            {
                SendFinish = true;
            }
            else
            {
                SendFinish = false;
            }
            return SendFinish;
        }
        public new void RecvResult(out string Data)
        {
            Data = DataReceivedstr;
        }

        public void ClearData()
        {
            DataReceivedstr_STR = "";
            DataReceivedstr = "";
            COMM.DiscardInBuffer();
            // throw new NotImplementedException();
        }

        //获取热熔温度
        public int SendDataHEX(out double data)
        {
            data = 0;
            try
            {
                byte[] m_SendByte = new byte[8];
                m_SendByte[0] = 0x01;
                m_SendByte[1] = 0x03;
                m_SendByte[2] = 0x20;
                m_SendByte[3] = 0x00;
                m_SendByte[4] = 0x00;
                m_SendByte[5] = 0x01;
                m_SendByte[6] = 0x8F;
                m_SendByte[7] = 0xCA;
                COMM.Write(m_SendByte, 0, m_SendByte.Length);
                Thread.Sleep(100);
                int lengh = COMM.Read(m_SendByte, 0, m_SendByte.Length);
                string sValue = Convert.ToString(m_SendByte[3], 16).PadLeft(2, '0') + Convert.ToString(m_SendByte[4], 16).PadLeft(2, '0');
                if (m_SendByte[2] >= 225)
                    data = -(65536 - Convert.ToInt32(sValue, 16)) * 0.1;
                else
                    data = (Convert.ToInt32(sValue, 16));
                return 0;
            }
            catch (Exception ex)
            {
                MainForm.m_formAlarm.InsertAlarmMessage("获取热熔温度失败！");
                return -1;
            }
        }
        public static void getTemplature()
        {
            while (true)
            {
                try
                {
                    //Thread.Sleep(1000);
                    //double data1 = 0;
                    //double data2 = 0;
                    //SerialPortCom serialPortLeft = (SerialPortCom)Communication_DateLoadData._Communication_DateTool["左热熔"];
                    //serialPortLeft.SendDataHEX(out data1);
                    //Properties.Settings.Default.左温度 = data1;
                    //Properties.Settings.Default.Save();
                    //Weld_Log.Instance().Enqueue($"左温度:{data1}");
                    //Thread.Sleep(1000);
                    //SerialPortCom serialPortRight = (SerialPortCom)Communication_DateLoadData._Communication_DateTool["右热熔"];
                    //serialPortRight.SendDataHEX(out data2);
                    //Properties.Settings.Default.右温度 = data2;
                    //Properties.Settings.Default.Save();
                    //Weld_Log.Instance().Enqueue($"右温度:{data2}");
                }
                catch (Exception ex)
                {
                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue(ex.ToString());
                }

            }
        }
    }
}
