using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace UniversalControlSystem
{
    public class CommunicationFun
    {

        ///// <summary>
        ///// 已摒弃
        ///// </summary>
        ///// <param name="String"></param>
        //public static void DisplayLogOnWindow(string String)
        //{
        //    _CallBack?.Invoke(String);
        //}
        ///// <summary>
        ///// 通讯参数数据初始化
        ///// </summary>
        public static  void Init()
        {
            foreach (var item in Communication_DateLoadData._Communication_DateTool)
            {
                if (item.Value.Communication_DateName== "串口")
                {

                }
                else if (item.Value.Communication_DateName == "网络客户端")
                {
                }
                else if (item.Value.Communication_DateName == "网络服务端")
                {
                }
            }

        }
        public static bool Open(string objName)
        {
            bool sta = false;
            Commu_Interface IFC = (Commu_Interface)Communication_DateLoadData._Communication_DateTool[objName];
            if (IFC.Open()==true)
            {
                sta = true;
            }
            else
            {
                sta = false;
            }
            return sta;
        }
        static object LOC = new object();
        public static bool Send(string objName,string sendStr)
        {
            lock (LOC)
            {

            
            bool sta = false;
            Commu_Interface IFC = (Commu_Interface)Communication_DateLoadData._Communication_DateTool[objName];
            if (IFC.Send(sendStr) == true)
            {
                sta = true;
            }
            else
            {
                sta = false;
            }
            return sta;
           }
        }
        public static  void  RecvResult(string objName,out string Data)
        {
            lock (LOC)
            {
            Data = "";
            Commu_Interface IFC = (Commu_Interface)Communication_DateLoadData._Communication_DateTool[objName];
            IFC.RecvResult(out Data);
            if (Data == "")
            {
            }
            else
            {
                Communication_DateLoadData._Communication_DateTool[objName].RecvResult = Data;
            }
          }
        }
        public static void ClearData(string objName)
        {
            Commu_Interface IFC = (Commu_Interface)Communication_DateLoadData._Communication_DateTool[objName];
            IFC.ClearData();

        }
        public static void Communication_Init()
        {
            foreach (var item in Communication_DateLoadData._Communication_DateTool)
            {
                if (item.Value.Communication_DateType == "串口")
                {
                    SerialPortCom _SerialPortCom = new SerialPortCom();
                    _SerialPortCom.Communication_DateName = item.Value.Communication_DateName;
                    _SerialPortCom.Communication_DateType = item.Value.Communication_DateType;
                    _SerialPortCom.Communication_DateVender = item.Value.Communication_DateType;
                    _SerialPortCom.Communication_DatePath = item.Value.Communication_DatePath;
                    _SerialPortCom = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[item.Value.Communication_DateName];
                    _SerialPortCom.COMM = new SerialPort();
                    Commu_Interface IFC = (Commu_Interface)Communication_DateLoadData._Communication_DateTool[item.Value.Communication_DateName];
                    IFC.Open();
                }
                else if (item.Value.Communication_DateType == "网络客户端")
                {
                    _Client Client = new _Client();
                    Client.Communication_DateName = item.Value.Communication_DateName;
                    Client.Communication_DateType = item.Value.Communication_DateType;
                    Client.Communication_DateVender = item.Value.Communication_DateType;
                    Client.Communication_DatePath = item.Value.Communication_DatePath;
                    Client = (_Client)Communication_DateLoadData._Communication_DateTool[item.Value.Communication_DateName];
                    Client.ITcpClient = new NetWorkHelper.TCP.ITcpClient();
                    Commu_Interface IFC = (Commu_Interface)Communication_DateLoadData._Communication_DateTool[item.Value.Communication_DateName];
                    IFC.Open();

                }
                else if (item.Value.Communication_DateType == "网络服务端")
                {
                    _Server Server = new _Server();
                    Server.Communication_DateName = item.Value.Communication_DateName;
                    Server.Communication_DateType = item.Value.Communication_DateType;
                    Server.Communication_DateVender = item.Value.Communication_DateType;
                    Server.Communication_DatePath = item.Value.Communication_DatePath;
                    Server = (_Server)Communication_DateLoadData._Communication_DateTool[item.Value.Communication_DateName];
                    Server.ser = new NetWorkHelper.TCP.ITcpServer();
                    Server.IClientList = new List<NetWorkHelper.IModels.IClient>();

                    Commu_Interface IFC = (Commu_Interface)Communication_DateLoadData._Communication_DateTool[item.Value.Communication_DateName];
                    IFC.Open();
                }
            }
        }
        ///// <summary>
        ///// 通讯连接
        ///// </summary>
        ///// <param name="Name"></param>
        ///// <returns></returns>
        public static int Conn(string Name)
        {
            bool Conn = false;
            int res = 0;
            if (Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].m_strHardWare_Modle == "串口")
            {
            }
            if (Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].m_strHardWare_Modle == "网络客户端")
            {
            }
            return res;
        }
        ///// <summary>
        ///// 数据发送
        ///// </summary>
        ///// <param name="Name"></param>
        ///// <param name="code"></param>
        ///// <returns></returns>
        public static int SendDate(string Name, string Data, out string code)
        {
            code = "";
            bool Send_Finish = false;
            //if (Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].m_strHardWare_Modle == "串口")
            //{

            //    //int  Send_= SerialPortDate[Name].senddatetotest(Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].SerialPort_txtSendPort,out code, Name);
            //    int Send_ = SerialPortDate[Name].senddatetotest(Data, out code, Name);
            //    if (Send_ == 0)
            //    {
            //        Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].SerialPort_RecPort = code;
            //        Send_Finish = true;
            //    }
            //    else
            //    {
            //        Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].SerialPort_RecPort = "";
            //        Send_Finish = false;
            //    }
            //}
            //else if (Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].m_strHardWare_Modle == "网络客户端")
            //{
            //    //int Send_ = Socket_clientDate[Name].SendData(Encoding.ASCII.GetBytes(Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].Socket_client_txtSend + "\r\n"), Name);
            //    int Send_ = Socket_clientDate[Name].SendData(Encoding.ASCII.GetBytes(Data + "\r\n"), Name);
            //    if (Send_ == 0)
            //    {
            //        Send_Finish = true;
            //    }
            //    else
            //    {
            //        Send_Finish = false;
            //    }
            //}
            //else if (Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].m_strHardWare_Modle == "网络服务端")
            //{
            //    //Socket_serverDate[Name].sendDataTo_(Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].Socket_client_txtSend);
            //    Socket_serverDate[Name].sendDataTo_(Data);
            //    Send_Finish = true;
            //}
            //if (Send_Finish == true)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return 30;
            //}
                return 30;
        }
        public static void ClearBuff(string Name, string date)
        {
            if (Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].m_strHardWare_Modle == "网络客户端")
            {
               // Socket_clientDate[Name].ClearReciveData(date);
            }
        }
        public static string _GetRec(string Name, string date)
        {
            //string[] _ReciveData = new string[10];
            string _GetRec = "";
            if (Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].m_strHardWare_Modle == "网络客户端")
            {
                switch (date)
                {
                    case "Platform":
                    //    _GetRec = Socket_clientDate[Name].PlatformReciveData;

                        break;
                    case "Laser":
                        //_GetRec = Socket_clientDate[Name].LaserReciveData;

                        break;
                    case "Print":
                     //   _GetRec = Socket_clientDate[Name].PrintReciveData;

                        break;
                    case "Check":
                     //   _GetRec = Socket_clientDate[Name].CheckReciveData;

                        break;

                }

            }
            return _GetRec;
        }
        ///// <summary>
        ///// 数据接收
        ///// </summary>
        ///// <param name="Name"></param>
        ///// <returns></returns>
        public static string GetRec(string Name)
        {
            string _GetRec = "";
            //    if (Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].m_strHardWare_Modle == "串口")
            //    {
            //        _GetRec = SerialPortDate[Name].GetRec(Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].SerialPort_txtSendPort);
            //        if (_GetRec != "")
            //        {                 
            //            return _GetRec;
            //        }
            //        else
            //        {                    
            //            return _GetRec;

            //        }
            //    }
            //    else if (Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].m_strHardWare_Modle == "网络客户端")
            //    {
            //        string Send_ = Socket_clientDate[Name].ReciveData;
            //        if (Send_ != "")
            //        {
            //            _GetRec = Send_;
            //            return Send_;
            //        }
            //        else
            //        {
            //            _GetRec = Send_;
            //            return Send_;
            //        }
            //    }
            //    else if (Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[Name].m_strHardWare_Modle == "网络服务端")
            //    {
            //        string Send_ = Socket_serverDate[Name].recvDate;        
            //    if (Send_ != "")
            //    {
            //            _GetRec = Send_;
            //        return Send_;
            //    }
            //    else
            //        {
            //            _GetRec = Send_;
            //            return Send_;
            //    }
            //}
            return _GetRec;
    }

    }
}
