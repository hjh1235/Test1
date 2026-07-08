using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class DigitalMea_Height : ImageTool
    {
        public string _功能 { set; get; }
        public string 串口号 { set; get; }
        public string 轴名字 { set; get; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroup { set; get; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        /// 
        public string DataGroupName { set; get; }
        public double 离焦量 { set; get; }
        public double 正偏差 { set; get; }

        public double 负偏差 { set; get; }
        public string 偏距数据组 { set; get; }

        public string 视觉数据组 { set; get; }

        public string 视觉数据名 { set; get; }



        /// <summary>
        /// Aixs1名字
        /// </summary>
        /// <returns></returns>
        /// 
        public string Aixs1名字 { set; get; }

        public double Aixs1速度 { set; get; }
        public double Aixs1位置 { set; get; }
        public double Aixs1加速度 { set; get; }
        public double Aixs1减速度 { set; get; }
        /// <summary>
        /// Aixs2名字
        /// </summary>
        /// <returns></returns>
        /// 
        public string Aixs2名字 { set; get; }
        public double Aixs2速度 { set; get; }
        public double Aixs2位置 { set; get; }
        public double Aixs2加速度 { set; get; }
        public double Aixs2减速度 { set; get; }

        public string 模式 { set; get; }

        public int DigitalMea_Height_Fun(DigitalMea_Height _DigitalMea_Height, out double _data)
        {
            _data = 0;
            int res = -1;
            for (int i = 0; i < 3; i++)
            {
                if (_DigitalMea_Height.GetData(ref _data, _DigitalMea_Height.串口号) == true)
                {
                    if (_DigitalMea_Height.正偏差 > _data && _DigitalMea_Height.负偏差 < _data)
                    {
                        res = 0;
                        return res;
                    }
                    else
                    {
                        res = -1;
                    }
                }
                if (i == 2)
                {
                    res = -1;
                }
            }
            return res;
        }

        public int DigitalMea_Height_Fun(DigitalMea_Height _DigitalMea_Height)
        {
            int res = -1;
            if (_DigitalMea_Height._功能 == "测距")
            {
                if (_DigitalMea_Height.模式 == "位置模式")
                {
                    for (int i = 0; i < 3; i++)
                    {
                        DataManage.SetData(_DigitalMea_Height.DataGroup, _DigitalMea_Height.DataGroupName, (object)"0");
                        double data = 0;
                        double data1 = 0;
                        Thread.Sleep(100);
                        if (_DigitalMea_Height.GetData(ref data, _DigitalMea_Height.串口号) == true && _DigitalMea_Height.GetData(ref data1, _DigitalMea_Height.串口号) == true)
                        {
                            _DigitalMea_Height.DisConnect();
                            if (_DigitalMea_Height.正偏差 > data && _DigitalMea_Height.负偏差 < data && _DigitalMea_Height.正偏差 > data1 && _DigitalMea_Height.负偏差 < data1)
                            {
                                data = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_DigitalMea_Height.轴名字].AisxCurrentPosition + data;
                                DataManage.SetData(_DigitalMea_Height.DataGroup, _DigitalMea_Height.DataGroupName, (object)data);
                                data1 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_DigitalMea_Height.轴名字].AisxCurrentPosition + data1;
                                DataManage.SetData(_DigitalMea_Height.DataGroup, _DigitalMea_Height.DataGroupName, (object)data1);
                                res = 0;
                                break;
                            }
                            else
                            {
                                res = -1;
                            }
                        }


                        //else
                        //{
                        //    res = -1;
                        //}
                        if (i == 2)
                        {
                            res = -1;
                        }

                        _DigitalMea_Height.DisConnect();
                    }

                }
                else if (_DigitalMea_Height.模式 == "视觉定位模式")
                {
                    string data = DataManage.StrValue(_DigitalMea_Height.视觉数据组, _DigitalMea_Height.视觉数据名);
                    string[] _DataS = data.Split('/');
                    string[] _DataSA = _DataS[0].Split(';');
                    double _DataX = 0, _DataY = 0;
                    try
                    {
                        //获取数据X 圆心中心
                        _DataX = Convert.ToDouble(_DataSA[0]) + Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[_DigitalMea_Height.偏距数据组].X偏距测高;
                        //获取数据y 圆心中心
                        _DataY = Convert.ToDouble(_DataSA[1]) + Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[_DigitalMea_Height.偏距数据组].Y偏距测高;
                        //补偿
                        ManageContral.AxisPMoveAbsoluteToStop(_DigitalMea_Height.Aixs1名字, _DataX, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_DigitalMea_Height.Aixs1名字].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_DigitalMea_Height.Aixs1名字].Dec, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_DigitalMea_Height.Aixs1名字].Auto_Speed);
                        ManageContral.AxisPMoveAbsoluteToStop(_DigitalMea_Height.Aixs2名字, _DataY, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_DigitalMea_Height.Aixs2名字].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_DigitalMea_Height.Aixs2名字].Dec, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_DigitalMea_Height.Aixs2名字].Auto_Speed);

                        while (true)
                        {
                            Thread.Sleep(50);
                            if (ManageContral.DetectingAxis(_DigitalMea_Height.Aixs2名字) == 0 && ManageContral.DetectingAxis(_DigitalMea_Height.Aixs1名字) == 0)
                            {
                                res = 0;
                                break;
                            }
                        }

                        DataManage.SetData(_DigitalMea_Height.DataGroup, _DigitalMea_Height.DataGroupName, (object)"0");
                        double dataS = 0;
                        if (_DigitalMea_Height.GetData(ref dataS, _DigitalMea_Height.串口号) == true)
                        {
                            _DigitalMea_Height.DisConnect();
                            if (_DigitalMea_Height.正偏差 > dataS && _DigitalMea_Height.负偏差 < dataS)
                            {
                                DataManage.SetData(_DigitalMea_Height.DataGroup, _DigitalMea_Height.DataGroupName, (object)dataS);
                                res = 0;
                            }
                            else
                            {
                                res = -1;
                            }
                        }
                    }
                    catch
                    {
                        res = -1;
                    }


                }
            }
            else if (_DigitalMea_Height._功能 == "测距校正")
            {
                AxisPDigitalMea_Height(_DigitalMea_Height);
                res = 0;
            }
            return res;
        }


        public void AxisPDigitalMea_Height(DigitalMea_Height _DigitalMea_Height)
        {
            string data = DataManage.StrValue(_DigitalMea_Height.DataGroup, _DigitalMea_Height.DataGroupName);
            try
            {
                //补偿
                double _data = Convert.ToDouble(data);

                _data = _data - _DigitalMea_Height.离焦量;
                //double High = _data + Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_DigitalMea_Height.轴名字].AisxCurrentPosition;
                double High = _data /*+ Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[_DigitalMea_Height.偏距数据组].基准Z坐标*/;
                ManageContral.AxisPMoveAbsoluteToStop(_DigitalMea_Height.轴名字, High, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_DigitalMea_Height.轴名字].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_DigitalMea_Height.轴名字].Dec, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_DigitalMea_Height.轴名字].Speed);
            }
            catch
            {
            }
            while (true)
            {
                if (ManageContral.DetectingAxis(_DigitalMea_Height.轴名字) == 0)
                {
                    break;
                }
            }
        }
        [NonSerialized]
        System.IO.Ports.SerialPort serialPort = new System.IO.Ports.SerialPort();
        [NonSerialized]
        public string m_hight = "";
        [NonSerialized]
        public bool bInitOK = false;
        [NonSerialized]
        HiPerfTimer timeM;
        [NonSerialized]
        public object lockObj = new object();
        [NonSerialized]
        public bool bValueReady = false;
        [NonSerialized]
        private string strRemaid = "";
        [NonSerialized]
        private byte[] m_SendByte = new byte[6];
        public DigitalMea_Height()
        {
            bInitOK = false;


        }
        public bool Init(DigitalMea_Height _DigitalMea_Height)
        {
            try
            {

                serialPort = new System.IO.Ports.SerialPort();
                serialPort.PortName = _DigitalMea_Height.串口号;
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
                bInitOK = true;
            }
            catch
            {
                bInitOK = false;
            }
            return bInitOK;
        }

        //获取测高头数据（基恩士）
        public bool GetData(ref double data, string com)
        {
            try
            {
                serialPort = new System.IO.Ports.SerialPort();
                char[] charArray = new char[1];
                byte[] buffer = new byte[12];
                charArray[0] = ',';
                if (serialPort.IsOpen == true)
                {
                }
                else
                {
                    serialPort.PortName = com;
                    serialPort.BaudRate = 9600;
                    serialPort.DataBits = 8;
                    serialPort.StopBits = StopBits.One;
                    serialPort.Parity = Parity.None;
                    serialPort.Open();
                }
                serialPort.ReadTimeout = 1000;
                serialPort.WriteLine("M0\r");
                Thread.Sleep(50);
                string sValue = serialPort.ReadExisting();
                sValue = sValue.Substring(sValue.IndexOf(",") + 1);
                sValue = sValue.Substring(0, sValue.Length - 3);
                data = Convert.ToDouble(sValue);
                //FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"测距高度：{data}");
                Weld_Log.Instance().Enqueue($"测距高度：{data}");
                serialPort.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //测高数据常用
        //public bool GetData(ref double data)
        //{
        //    serialPort = new System.IO.Ports.SerialPort();
        //    serialPort.PortName = 串口号;
        //    serialPort.BaudRate = 9600;
        //    serialPort.DataBits = 8;
        //    serialPort.StopBits = StopBits.One;
        //    serialPort.Parity = Parity.None;
        //    serialPort.Close();
        //    if (serialPort.IsOpen == true)
        //    {
        //    }
        //    else
        //    {
        //        serialPort.Open();
        //    }
        //    char[] charArray = new char[1];
        //    byte[] buffer = new byte[6];
        //    charArray[0] = ',';
        //    try
        //    {
        //        byte[] m_SendByte = new byte[6];
        //        m_SendByte[0] = 0x02;
        //        m_SendByte[1] = 0x43;
        //        m_SendByte[2] = 0xB0;
        //        m_SendByte[3] = 0x01;
        //        m_SendByte[4] = 0x03;
        //        m_SendByte[5] = 0xF2;
        //        serialPort.ReadTimeout = 3000;
        //        serialPort.ReadExisting();
        //        serialPort.Write(m_SendByte, 0, m_SendByte.Length);
        //        Thread.Sleep(200);
        //        serialPort.Read(buffer, 0, buffer.Length);
        //        string sValue = Convert.ToString(buffer[2], 16).PadLeft(2, '0') + Convert.ToString(buffer[3], 16).PadLeft(2, '0');
        //        if (buffer[2] >= 225)
        //            data = -(65536 - Convert.ToInt32(sValue, 16)) * 0.01;
        //        else
        //            data = (Convert.ToInt32(sValue, 16)) * 0.01;
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        FormStart.LOG_ShowFrom["系统LOG"].Enqueue("测距COM未连接,请检查COM");
        //        return false;
        //    }
        //}
        public void DisConnect()
        {
            serialPort.Close();
            serialPort.Dispose();
        }

    }
}
