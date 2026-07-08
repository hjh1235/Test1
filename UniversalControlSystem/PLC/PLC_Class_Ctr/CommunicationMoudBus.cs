using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;

namespace UniversalControlSystem
{
    public class CommunicationMoudBus
    {
        //
        //客户端
        //
     
            public string name = "";
            //private static PLC_Client PLC_Clients;
            //public static PLC_Client Instance()
            //{
            //    if (PLC_Clients == null)
            //    {
            //        PLC_Clients = new PLC_Client();
            //    }
            //    return PLC_Clients;
            //}

            /// <summary>
            ///  plc地址IP
            /// </summary>
            public string PLC_IP { get; set; }
            /// <summary>
            ///  plc端口号
            /// </summary>
            public int PLC_Port { get; set; }
            public CommunicationMoudBus()
        {
     
        }
            public CommunicationMoudBus(string IP, int Port)
            {
                PLC_IP= IP;
                PLC_Port= Port;
            }
            public const int NET_OK = 0;
            public const int NET_PING_ERROR = 2001;
            public const int NET_CONNECT_TIMEOUT = 2002;
            public const int NET_CONNECT_ERROR = 2003;
            public const int NET_SEND_ERROR = 2004;
            public const int NET_RCEIVE_ERROR = 2004;
            private Socket mClientSocket;
            private bool mConnectSts;
            byte[] rcvBuf = new byte[1024 * 2014 * 3];
            public delegate void RceiveDataDelegate(byte[] data);
            public event RceiveDataDelegate ReciveDataEvent;
            public string ReciveData = "";
            /// <summary>
            /// 连接超时
            /// </summary>
            /// <param name="ipAddress"></param>
            /// <param name="port"></param>
            /// <param name="outTime"></param>
            /// <returns></returns>
            public int ConnectOutTime( int outTime)
            {
                int nRet = -1;
                Ping p = new Ping();
                try
                {
                    PingReply replay = p.Send(PLC_IP);
                    if (replay.Status != IPStatus.Success)
                    {
                        return NET_PING_ERROR;
                    }
                }
                catch (Exception e)
                {
                    return NET_PING_ERROR;
                }
                if (mClientSocket != null && mClientSocket.Connected)
                {
                    mClientSocket.Close();
                    mClientSocket = null;
                }
                try
                {
                    mClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IAsyncResult a = mClientSocket.BeginConnect(IPAddress.Parse(PLC_IP), PLC_Port, new AsyncCallback(ConnectCallback), mClientSocket);
                    DateTime startTime = DateTime.Now;
                    while (!mConnectSts)
                    {
                        DateTime endTime = DateTime.Now;
                        TimeSpan span = endTime - startTime;
                        if (span.TotalMilliseconds > outTime)
                        {
                            mClientSocket.Close();
                            mConnectSts = false;
                            nRet = NET_CONNECT_TIMEOUT;
                            return nRet;
                        }
                    }
                    ReciveDataEvent += ReciveDataEvent_handle;
                    nRet = NET_OK;
                    return nRet;
                }
                catch (Exception e)
                {
                    nRet = NET_CONNECT_ERROR;
                    return nRet;
                }
            }

            /// <summary>
            /// 接受的数据转换
            /// </summary>
            /// <param name="data"></param>
            private void ReciveDataEvent_handle(byte[] data)
            {
                ReciveData = "";
                string rcvStr = Encoding.UTF8.GetString(data);
                if (!string.IsNullOrEmpty(rcvStr))
                {
                    ReciveData = rcvStr;
                }
            }
            private void ConnectCallback(IAsyncResult ia)
            {
                mClientSocket = ia.AsyncState as Socket;
                if (mClientSocket.Connected)
                {
                    mConnectSts = true;
                }
                else
                {
                    mConnectSts = false;
                }
            }
            /// <summary>
            /// 发送数据
            /// </summary>
            /// <param name="sendData"></param>
            /// <param name="Name"></param>
            /// <returns></returns>
            public int SendData(byte[] sendData)//send data 
            {
                int RetRes = 0;
                lock (this)
                {
                    try
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (mClientSocket.Connected)
                            {
                                mClientSocket.Send(sendData, sendData.Length, SocketFlags.None);
                                RetRes = NET_OK;
                                break;
                            }
                            else
                            {
                                RetRes = ConnectOutTime(60);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        return NET_SEND_ERROR;
                    }
                }
                return RetRes;
            }
            /// <summary>
            /// 接收数据超时
            /// </summary>
            /// <param name="outTime"></param>
            /// <param name="data"></param>
            /// <returns></returns>
            public int RceiveOutTime(int outTime, ref byte[] data)  //
            {
                try
                {
                    mClientSocket.Receive(data, SocketFlags.None);
                    return NET_OK;
                }
                catch (Exception e)
                {
                    return NET_RCEIVE_ERROR;
                }
            }
            /// <summary>
            /// 接收数据
            /// </summary>
            public void RceiveAsny()
            {
                try
                {
                    mClientSocket.BeginReceive(rcvBuf, 0, rcvBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveAsynCallback), mClientSocket);
                }
                catch (Exception e)
                {
                }
            }
            private void ReceiveAsynCallback(IAsyncResult ia)
            {
                try
                {
                    mClientSocket = ia.AsyncState as Socket;
                    int count = mClientSocket.EndReceive(ia);
                    mClientSocket.BeginReceive(rcvBuf, 0, rcvBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveAsynCallback), mClientSocket);
                    byte[] buf = rcvBuf.Skip(0).Take(count).ToArray();
                    if (ReciveDataEvent != null)
                    {
                        ReciveDataEvent(buf);
                    }
                }
                catch (Exception e)
                {
                }
            }
            /// <summary>
            /// 关闭函数
            /// </summary>
            public void Close()//close 
            {
                if (mClientSocket != null && mClientSocket.Connected)
                {
                    mClientSocket.Disconnect(true);
                }
            }
            /// <summary>
            /// 检测是否已连接
            /// </summary>
            /// <returns></returns>
            public bool IsConnected()
            {
                if (mClientSocket != null)
                {
                    return mClientSocket.Connected;
                }
                else
                {
                    return false;
                }
            }
        
    }
}
