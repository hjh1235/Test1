using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    /// <summary>
    /// 台达，ModBus_ASCII通讯协议
    ///
    /// </summary>
    public class TAIDA : CommunicationMoudBus,interfaceCommunication
    {
        public StringBuilder SendData = new StringBuilder();
        public StringBuilder Message = new StringBuilder();
        public StringBuilder DataReceived = new StringBuilder();
       // SerialPort serialPort = null;
        //LResult rec = new LResult();
        public TAIDA():base()
        {
           
            //sSrialPort.DataReceived += serialPort1_DataReceived;
        }
        public TAIDA(string ip,int  port) : base(ip, port)
        {
            ReciveDataEvent += ReciveDataEvent_handle;
            //sSrialPort.DataReceived += serialPort1_DataReceived;
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
           
        }
        private void ReciveDataEvent_handle(byte[] data)
        {
            ReciveData = "";
            string rcvStr = Encoding.UTF8.GetString(data);
            if (!string.IsNullOrEmpty(rcvStr))
            {
                ReciveData = rcvStr;
            }
        }
        /// <summary>
        /// 读PLC数据
        /// </summary>
        /// <param name="equipmentInfo">设备信息</param>
        /// <param name="equipmentCollectItem">设备采集项信息</param>
        /// <returns></returns>
        public string  DoWork(string strParameter, string _address)
        {
            //LResult rec1 = new LResult();
            //初始化参数并连接PLC
            InitWork(strParameter);
            string PreChar = _address.Substring(0, 1).ToUpper();
            int address = Convert.ToInt32(_address.Substring(1));
            switch (PreChar)
            {
                case "M":
                    #region 读取M值
                    try
                    {
                        short ReceiveData = 0;
                        bool result = ReadMValue(ref address, out ReceiveData);
                        if (result)
                        {
                            //rec1.Result = true;
                            //rec1.ExtMessage = "读取成功";
                            //rec1.obj = ReceiveData;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        Close();
                    }
                    #endregion
                    break;
                case "D":
                    #region 读取D值
                    try
                    {
                        int ReceiveData = 0;
                        bool result = ReadDValueF(ref address, out ReceiveData);
                        if (result)
                        {
                            //rec1.Result = true;
                            //rec1.ExtMessage = "读取成功";
                            //rec1.obj = ReceiveData;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        Close();
                    }
                    #endregion
                    break;
            }
            return "";
        }

        /// <summary>
        /// 写PLC数据
        /// </summary>
        /// <param name="equipmentInfo">设备信息</param>
        /// <param name="equipmentCollectItem">设备采集项信息</param>
        /// <param name="writeValue">写入值</param>
        /// <returns></returns>
        public string  DoWork(string strParameter, string _address, object writeValue)
        {
            //LResult rec1 = new LResult();
            //初始化参数并连接PLC
            InitWork(strParameter);
            string PreChar = _address.Substring(0, 1).ToUpper();
            int address = Convert.ToInt32(_address.Substring(1));
            int value = Convert.ToInt16(writeValue);
            switch (PreChar)
            {
                case "M":
                    #region 写入M值
                    try
                    {
                        bool result = WriteMValue(ref address, ref value);
                        if (result)
                        {
                            //rec1.Result = true;
                            //rec1.ExtMessage = "写入成功";
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        Close();
                    }
                    #endregion
                    break;
                case "D":
                    #region 写入D值
                    try
                    {
                        double dValue = Convert.ToDouble(value);
                        bool result = WriteDValue(ref address, ref dValue);
                        if (result)
                        {
                            //rec.Result = true;
                            //rec.ExtMessage = "写入成功";
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        Close();
                    }
                    #endregion
                    break;
            }
            return "";
        }

        /// <summary>
        /// 初始化参数并连接PLC
        /// </summary>
        /// <param name="equipmentInfo">设备信息</param>
        /// <param name="equipmentCollectItem">设备采集项信息</param>
        public void InitWork(string strParameters)
        {
            //serialPort = new SerialPort();
            //参数拼接规则：英文字符“,”隔开，最后一个参数后面没有逗号,强制规范，必须遵守
            //参数1：串口号；参数2：波特率；参数3：校验位；参数4：停止位；参数5：数据位；
            //string[] arrParameters = strParameters.Split(',');
            //serialPort.PortName = arrParameters[0].ToString().Trim();//串口
            //serialPort.BaudRate = Convert.ToInt32(arrParameters[1].ToString().Trim());//波特率
            //serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), arrParameters[2].ToString().Trim());//校验位
            //serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), arrParameters[3].ToString().Trim());//停止位
            //serialPort.DataBits = Convert.ToInt32(arrParameters[4].ToString().Trim());//数据位
            Init();
        }
        /// <summary>
        /// 读取台达PLC M地址值 
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="result">结果</param>
        /// <returns></returns>
        public bool ReadMValue(ref int address, out short ReceiveData)
        {
            bool result = false;
           // serialPort.DiscardInBuffer();
            ReceiveData = 0;
            string send = MAddressConvertRead(ref address);
            //serialPort.Write(send);
           // string strRecieve = serialPort.ReadTo("\r\n");
           // string res = strRecieve.Substring(7, 2);
           // short recInt = Convert.ToInt16(res, 16);
            //if (recInt % 2 == 0)
            //{
            //    result = false;
            //}
            //else
            //{
            //    result = true;
            //    ReceiveData = recInt;
            //}
            return result;
        }
        /// <summary>
        /// 读取台达PLC D地址值 
        /// </summary>
        /// <param name="address">地址</param>
        /// <returns></returns>
        public bool ReadDValueF(ref int address, out int ReceiveData)
        {
            bool result = false;
            ReceiveData = 0;
            try
            {
                string send = DAddressConvertRead(address);
              //  serialPort.Write(send);
              //  string strRecieve = serialPort.ReadTo("\r\n");
              //  ReceiveData = Convert.ToInt32(strRecieve.Substring(7, 4), 16);

                result = true;
            }
            catch (Exception e)
            {
                return result;
            }
            return result;
        }
        /// <summary>
        /// 写入M值
        /// </summary>
        /// <param name="addr">地址</param>
        /// <param name="value">需写入的值</param>
        /// <returns></returns>
        public bool WriteMValue(ref int addr, ref int value)
        {
            bool result = false;
            try
            {
                //serialPort.DiscardInBuffer();
                //string address = MAddressConvertWrite(ref addr, ref value);
                //serialPort.Write(address);
                //string strRead = serialPort.ReadTo("\r\n");
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// 写入D值
        /// </summary>
        /// <param name="addr">地址</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool WriteDValue(ref int addr, ref double value)
        {
            bool result = false;
            try
            {
                //serialPort.DiscardInBuffer();
                //string address = DAddressConvertWrite(addr, value);
                //serialPort.Write(address);
                //string strRead = serialPort.ReadTo("\r\n");
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// D地址转换 读取
        /// </summary>
        /// <param name="addr">地址</param>
        /// <returns></returns>
        public string DAddressConvertRead(int addr)
        {
            int address = 4096 + addr;
            string addressStr = address.ToString("X2").PadLeft(4, '0');
            string str = "";
            byte[] commd = new byte[6];
            commd[0] = 0x01;
            str = ":0103";
            commd[1] = 0x03;
            commd[4] = 0x00;//高8位
            commd[5] = 0x01;//低8位
            byte[] data = BitConverter.GetBytes((int)address);
            //commd[4] = (byte)((int)tValue>>8);//高8位
            //commd[5] = (byte)((int)tValue%0x100);//低8位
            commd[2] = data[1];//高8位
            commd[3] = data[0];//低8位
            int num = commd[0] + commd[1] + commd[2] + commd[3] + commd[4] + commd[5];
            num = ~num;
            num = num + 1;
            string str1 = commd[4].ToString("X2");
            string str2 = commd[5].ToString("X2");
            string str3 = num.ToString("X2");
            string LRC = str3.Substring(str3.Length - 2, 2);
            str = str + addressStr + str1 + str2 + LRC + "\r\n";
            return str;
        }
        /// <summary>
        /// D地址转换  写入
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string DAddressConvertWrite(int addr, double value)
        {
            int address = 4096 + addr;
            string addressStr = address.ToString("X2").PadLeft(4, '0');
            string str = "";
            byte[] commd = new byte[8];
            commd[0] = 0x01;
            str = ":0106";
            commd[1] = 0x06;
            byte[] data = BitConverter.GetBytes((int)address);   
            commd[2] = data[1];//高8位
            commd[3] = data[0];//低8位
            byte[] valueData = BitConverter.GetBytes(value);
            commd[4] = valueData[1];
            commd[5] = valueData[0];            
            int num = commd[0] + commd[1] + commd[2] + commd[3] + commd[4] + commd[5];
            num = ~num;
            num = num + 1;
            string str1 = commd[4].ToString("X2");
            string str2 = commd[5].ToString("X2");
            string str3 = num.ToString("X2");
            string LRC = str3.Substring(str3.Length - 2, 2);
            str = str + addressStr + str1 + str2 + LRC + "\r\n";
            return str;
        }
        /// <summary>
        /// M地址转换 读取
        /// </summary>
        /// <param name="addr">地址</param>
        /// <returns></returns>
        public string MAddressConvertRead(ref int addr)
        {
            int address = addr + 2048;
            string addressStr = address.ToString("X2").PadLeft(4, '0');
            string str = "";
            byte[] commd = new byte[6];
            commd[0] = 0x01;
            str = ":0102";
            commd[1] = 0x02;
            commd[4] = 0x00;//高8位
            commd[5] = 0x01;//低8位
            byte[] data = BitConverter.GetBytes((int)address);          
            commd[2] = data[1];//高8位
            commd[3] = data[0];//低8位           
            int num = commd[0] + commd[1] + commd[2] + commd[3] + commd[4] + commd[5];
            num = ~num;
            num = num + 1;
            string str1 = commd[4].ToString("X2");
            string str2 = commd[5].ToString("X2");
            string str3 = num.ToString("X2");
            string LRC = str3.Substring(str3.Length - 2, 2);
            str = str + addressStr + str1 + str2 + LRC + "\r\n";
            return str;
        }
        /// <summary>
        /// M地址转换  写入
        /// </summary>
        /// <param name="addr">地址</param>
        /// <param name="value">0:复位  1：置位</param>
        /// <returns></returns>
        public string MAddressConvertWrite(ref int addr, ref int value)
        {
            int address = addr + 2048;
            string addressStr = address.ToString("X2").PadLeft(4, '0');
            string str = "";
            byte[] commd = new byte[6];
            commd[0] = 0x01;
            str = ":0105";
            commd[1] = 0x05;
            if (value == 0)
            {
                commd[4] = 0x00;//高8位
                commd[5] = 0x00;//低8位
            }
            else
            {
                commd[4] = 0xFF;//高8位
                commd[5] = 0x00;//低8位
            }
            byte[] data = BitConverter.GetBytes((int)address);
            commd[2] = data[1];//高8位
            commd[3] = data[0];//低8位           
            int num = commd[0] + commd[1] + commd[2] + commd[3] + commd[4] + commd[5];
            num = ~num;
            num = num + 1;
            string str1 = commd[4].ToString("X2");
            string str2 = commd[5].ToString("X2");
            string str3 = num.ToString("X2");
            string LRC = str3.Substring(str3.Length - 2, 2);
            str = str + addressStr + str1 + str2 + LRC + "\r\n";
            return str;
        }
        /// <summary>
        /// 打开连接
        /// </summary>
        public void Init()
        {         
            try
            {
                if (IsConnected()==false)
                    ConnectOutTime(5000);
                if (IsConnected() == true )
                {           
                }
                else
                {             
                }
            }
            catch (Exception)
            {           
            }
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            if (IsConnected() == true)
                Close();
        }
        public int SendStr(string Str, out string Received)
        {
            throw new NotImplementedException();
        }

        public string GetDataReceived()
        {
            throw new NotImplementedException();
        }
    }
}
