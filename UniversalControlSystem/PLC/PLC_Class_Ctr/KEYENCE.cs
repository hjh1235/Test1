using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem.PLC.PLC_Class_Ctr
{
    class KEYENCE
    {

        TcpClient tcp = new TcpClient(); //定义连接
        static object lock1 = new object();
        /// <summary>
        /// 初始化连接PLC
        /// </summary>
        /// <param name="_IP">IP地址</param>
        /// <param name="_Port">端口</param>
        /// <returns></returns>
        public bool Init(string _IP, string _Port)
        {
            tcp.Connect(_IP,int.Parse(_Port)); //设置IP与Port 
            if (tcp.Connected)
                return true;
            else
                return false; 
        }
        public bool Close()
        {
            try
            {
                tcp.Close();
                return true;
            }catch
            {
                return false;
            }
            
        }
        public bool Read(string _Address,PLCDataType _Type,out string _data)
        {
            try
            {
                string RD = null, SendW = null;
                _data = null;
                if (_Address.Substring(0, 1) == "R")
                {
                    RD = "RD " + _Address + "\r";
                    if (SendMessage(RD) == ("0\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0\0"))//如果该R值为0则发送置为指令
                    {
                        SendW = "ST " + _Address + "\r";
                    }
                    if (SendMessage(RD) == ("1\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0\0"))//如果该R值为1则发送复位指令
                    {
                        SendW = "RS " + _Address + "\r";
                    }
                    if (SendMessage(SendW) == ("OK\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0"))
                    {
                        _data = SendMessage(RD).Substring(0, 1);
                    }
                }
                switch (_Type)
                {
                    case PLCDataType.Int:
                        RD = "RD " + _Address + ".L\r";
                        _data = SendMessage(RD);
                        break;
                    case PLCDataType.Bool:
                        RD = "RD " + _Address + "\r";
                        _data = SendMessage(RD);
                        break;
                }
                return true;
            }
            catch
            {
                _data = null;
                return false;
            }
            
        }
        public bool Write(string _Address,PLCDataType _Type, string _data)
        {
            string WR = null,str;
            try
            {
                switch (_Type)
                {
                    case PLCDataType.Int:
                        WR = "WR " + _Address + ".L " + _data + "\r";
                        str = SendMessage(WR);
                        break;
                    case PLCDataType.Bool:
                        WR = "WR " + _Address  +" "+ _data + "\r";
                        str = SendMessage(WR);
                        break;
                }
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 发送数据，返回结果
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public string SendMessage(string mes)
        {
            try
            {
                lock (lock1)
                {
                    NetworkStream DataSend = tcp.GetStream();//定义网络流
                    string SendW = mes;
                    var ByteSendW = Encoding.ASCII.GetBytes(SendW);//把发送数据转换为ASCII数组          
                    DataSend.Write(ByteSendW, 0, ByteSendW.Length); //发送通讯数据
                    byte[] data = new byte[16];//设定接收数据为16位数组，接收数据不足用0填充
                    DataSend.Read(data, 0, data.Length);       //读取返回数据
                    var ByteRD = "未返回数据";
                    ByteRD = Encoding.ASCII.GetString(data);//接收数据从ASCII数组转换为字符串
                    return ByteRD;
                }
            }
            catch
            {
                return "";
            }
            
            
        }
        public void scanReadData(string _name)
        {
            string RD = null;
            string SendW = null;
            while (true)
            {
                //PLC读取
                try
                {
                    #region PLC读取
                    Thread.Sleep(0);
                    //判断连接状态
                    if (Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_name].State)
                    {
                        //判断是否有读取得值
                        if (Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_name].dicPlcReadData.Count != 0)
                        {
                            foreach (var item in Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_name].dicPlcReadData)
                            {
                                if (item.Value.Address.Substring(0, 1) == "R")
                                {
                                    RD = "RD " + item.Value.Address + "\r";
                                    string str = SendMessage(RD);
                                    if (SendMessage(RD) == ("0\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0\0"))//如果该R值为0则发送置为指令
                                    {
                                        SendW = "ST " + item.Value.Address + "\r";
                                    }
                                    if (SendMessage(RD) == ("1\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0\0"))//如果该R值为1则发送复位指令
                                    {
                                        SendW = "RS " + item.Value.Address + "\r";
                                    }
                                    str = SendMessage(SendW);
                                    if (str == ("OK\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0"))
                                    {
                                        item.Value.data = SendMessage(RD).Substring(0, 1);
                                    }
                                }
                                else if(item.Value.type == PLCDataType.Int)
                                {
                                    RD = "RD " + item.Value.Address + "\r";
                                    string str = SendMessage(RD).Split(new string[] { "\r\n" },StringSplitOptions.None)[0];
                                    double data =Convert.ToDouble( str.Substring(1))/100;
                                    item.Value.data = data.ToString();
                                }else if(item.Value.type == PLCDataType.Bool)
                                {
                                    RD = "RD " + item.Value.Address + "\r";
                                    string str = SendMessage(RD);
                                    item.Value.data = str;
                                }



                            }

                        }
                    }
                    #endregion
                }
                catch
                {
                }
                //PLC写入
                try
                {
                    #region PLC写入
                    string WR = null;
                    string address = null;
                    string laserAddress = null;
                    if (Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_name].State)
                    {
                        if (Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_name].dicWritePlcData.Count != 0)
                        {
                            foreach (var item in Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_name].dicWritePlcData)
                            {
                                if (item.Value.type == PLCDataType.Byte)
                                {
                                    address = item.Value.Address.Split('.')[0];
                                    if (address == laserAddress)
                                        break;
                                    else
                                    {
                                        string data = null;
                                        WriteByte(Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_name].dicWritePlcData, ref data);
                                        WR = "WR " + address + ".L " + data + "\r";
                                        SendMessage(WR);
                                        laserAddress = address;
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
                catch
                {

                }
            }
        }
        /// <summary>
        /// 输出心跳信号
        /// </summary>
        public void scanWriteHeartbeat()
        {
            string RD = null,WR = null;
            string SendW = null,str;
            string data = "0";
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    //RD = "RD " + "R2006" + "\r";
                    // str = SendMessage(RD);
                    //if (SendMessage(RD) == ("0\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0\0"))//如果该R值为0则发送置为指令
                    //{
                    //    SendW = "ST " + "R2006" + "\r";
                    //}
                    //if (SendMessage(RD) == ("1\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0\0"))//如果该R值为1则发送复位指令
                    //{
                    //    SendW = "RS " + "R2006" + "\r";
                    //}
                    //str = SendMessage(SendW);
                    //if (str == ("OK\r\n" + "\0\0\0\0\0\0\0\0\0\0\0\0"))
                    //{
                    //    str = SendMessage(RD);
                    //}
                    data = (data == "1") ? "0" : "1";
                    WR = "WR " + "MR1300" + " " + data + "\r";
                    str = SendMessage(WR);
                }
                catch { }
            }
            
            
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_dicWriteData"></param>
        /// <param name="_data"></param>
        private void WriteByte(Dictionary<string, PLCData> _dicWriteData, ref string _data)
        {
            List<string> dicRepeat = new List<string>();
            List<byte> listByte = new List<byte>();
            string str = null;
            foreach (var item in _dicWriteData)
            {
                if (item.Value.type == PLCDataType.Byte)
                {
                    dicRepeat.Add(item.Value.Address.Split('.')[0]);
                }
            }
            var duplicateValues = dicRepeat.GroupBy(x => x).Where(g => g.Count() > 1).Select(y => y.Key).ToList();
            foreach (var item in duplicateValues)
            {
                listByte.Clear();
                foreach (var item1 in _dicWriteData)
                {
                    if (item == item1.Value.Address.Split('.')[0])
                    {
                        listByte.Add(Convert.ToByte(item1.Value.data));
                    }
                }
                listByte.Reverse();
                str = string.Join("", listByte);
                if (listByte.Count < 4)
                {
                    str = str.PadRight(4, '0');

                }
                _data = Convert.ToInt32(str, 2).ToString();

            }
        }

    }
}
