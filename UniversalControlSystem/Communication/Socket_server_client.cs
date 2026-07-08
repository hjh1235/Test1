using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    //
    //客户端
    //
    [Serializable]
    public class _Client : Communication_DateTool, Commu_Interface
    {
      
        public string ip = "";
        public int Port = 0;
        public string str = "";
        public string ConnStr = "";
        public int ReConnectionTime = 0;
        public string SendStr = "";
        // NetWorkHelper.TCP.ITcpClient
        [NonSerialized]
        private static _Client _Client_;
        [NonSerialized]
        public   NetWorkHelper.TCP.ITcpClient ITcpClient = new NetWorkHelper.TCP.ITcpClient();
        public static _Client Instance()
        {
            if (_Client_ == null)
            {
                _Client_ = new _Client();
            }
            return _Client_;
        }
   
        public void conn(string ip, int Port, int ReConnectionTime)
        {
            ITcpClient.ServerIp = ip;
            ITcpClient.ServerPort = Port;
            ITcpClient.ReConnectionTime = ReConnectionTime;
            ITcpClient.IsReconnection = true;
            ITcpClient.StartConnect();
            ITcpClient.OnRecevice += 客户端_OnRecevice;
            ITcpClient.OnStateInfo += 客户端_OnStateInfo;

        }
        public bool ConnOK = false;

        public bool Open()
        {
            ITcpClient.ServerIp = ip;
            ITcpClient.ServerPort = Port;
            ITcpClient.ReConnectionTime = ReConnectionTime;
            ITcpClient.IsReconnection = true;
            ITcpClient.StartConnect();
            ITcpClient.OnRecevice += 客户端_OnRecevice;
            ITcpClient.OnStateInfo += 客户端_OnStateInfo;
            return true;
        }
        private void 客户端_OnStateInfo(object sender, NetWorkHelper.ICommond.TcpClientStateEventArgs e)
        {
            try
            {
                ConnStr = e.StateInfo;
            }
            catch (Exception ex)
            {
                Weld_Log.Instance().Enqueue(ex.ToString());
            }
        }
        private void 客户端_OnRecevice(object sender, NetWorkHelper.ICommond.TcpClientReceviceEventArgs e)
        {
            try
            {
                str = System.Text.Encoding.ASCII.GetString(e.Data);
            }
            catch (Exception ex)
            {
                Weld_Log.Instance().Enqueue(ex.ToString());
            }
            // textBox1.AppendText(str);
        }
        public bool Open(string objName)
        {
            throw new NotImplementedException();
        }
        public bool Send(string  SendStr)
        {
            int SEND = -1;
            if (ConnStr == "已连接服务器")
            {
                try
                {
                    ITcpClient.SendData(System.Text.Encoding.ASCII.GetBytes(SendStr));
                    ConnOK = true;
                    SEND = 0;
                }
                catch (Exception ex)
                {
                    SEND = -1;
                    ConnOK = false;
                }
            }
            else
            {
                SEND = -1;
                ConnOK = false;

            }
            return ConnOK;
        }
        public new void RecvResult(out string Data)
        {
            Data = "";
            Data = str;
        }
        public void Close()
        {
      
        }
        public void ClearData()
        {
            str = "";
        }
    }
    //
    //服务端
    //


    [Serializable]
    public class _Server: Communication_DateTool, Commu_Interface
    {
        public string ip = "";
        public int Port = 0;
        public string SendStr = "";
        [NonSerialized]
        public NetWorkHelper.TCP.ITcpServer ser = new NetWorkHelper.TCP.ITcpServer();
        [NonSerialized]
        public List<NetWorkHelper.IModels.IClient> IClientList = new List<NetWorkHelper.IModels.IClient>();
        [NonSerialized]
        public static _Server _Server_;
        public static _Server Instance()
        {
            if (_Server_ == null)
            {
                _Server_ = new _Server();
            }
            return _Server_;
        }

        public bool Open()
        {
            ser.ServerIp = ip;
            ser.ServerPort = Port;
            ser.OnRecevice += 服务端_OnRecevice;
            ser.OnOnlineClient += 服务端_OnOnlineClient;
            ser.OnOfflineClient += 服务端_OnOfflineClient;
            ser.Start();
            return true;
        }

        //public void open()
        //{
        //    ser.ServerIp = ip;
        //    ser.ServerPort = Port;
        //    ser.OnRecevice += 服务端_OnRecevice;
        //    ser.OnOnlineClient += 服务端_OnOnlineClient;
        //    ser.OnOfflineClient += 服务端_OnOfflineClient;
        //    ser.Start();

        //}
        private void 服务端_OnOfflineClient(object sender, NetWorkHelper.ICommond.TcpServerClientEventArgs e)
        {
            IClientList.Remove(e.IClient);
        }


        private void 服务端_OnOnlineClient(object sender, NetWorkHelper.ICommond.TcpServerClientEventArgs e)
        {
            IClientList.Add(e.IClient);
        }
        public bool Send(string SendStr)
        {
            for (int i = 0; i < IClientList.Count; i++)
            {
                ser.SendData(IClientList[i], System.Text.Encoding.ASCII.GetBytes(SendStr));
            }
            return true;
        }

        public string str;
        private void 服务端_OnRecevice(object sender, NetWorkHelper.ICommond.TcpServerReceviceaEventArgs e)
        {
            NetWorkHelper.IModels.IClient IClient = e.IClient;

            str = System.Text.Encoding.ASCII.GetString(e.Data);
        }
        public bool Open(string objName)
        {
            throw new NotImplementedException();
        }
        public new void RecvResult(out string Data)
        {
            Data = "";
            Data = str;
        }

        public void ClearData()
        {
            str = "";
        }
        public void Close()
        {

        }
    }
}
