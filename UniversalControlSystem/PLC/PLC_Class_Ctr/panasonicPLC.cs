using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Concurrent;
namespace UniversalControlSystem
{

    public partial class panasonicPLC
    {    /// <summary>
         /// 松下，通讯协议
         ///
         /// </summary>
        private ConcurrentQueue<string> mSendQueue = new ConcurrentQueue<string>();
        public SerialPort COMM = new SerialPort();
        ArrayList list = new ArrayList();
        string readData;
        public double[] DTValue = null;
        public bool flag = false;
        Thread sendToPlc = null;
        public panasonicPLC()
        {
            openstarte();
        }
        public void openstarte()
        {
            Open("COM10");
            sendToPlc = new Thread(thend);
            sendToPlc.IsBackground = true;
            sendToPlc.Start();

        }
        //单例     
        private static panasonicPLC controller;
        public static panasonicPLC Instance()
        {
            if (controller == null)
            {
                controller = new panasonicPLC();
            }
            return controller;
        }
        
        public void thend()
        {
            string read = "";
            string sAddr = "";
            string outStr = "";
            //while (true)
            //{
            //    //read = "";
            //    //sAddr = "";
            //    //outStr = "";
            //    //sAddr = "8R3080R3081R3082R3083R3084R3085R3086R3087";              
            //    //outStr = "%01#RCP" + sAddr;
            //    //outStr = outStr + bcc(outStr) + "\r";
            //    //if (COMM.IsOpen == false)
            //    //{
            //    //    break;
            //    //}
            //    //COMM.Write(outStr);
            //    //Thread.Sleep(100);              
            //    //read = DataReceived();
            //    //if (read != "")
            //    //{
            //    //    string str6001 = read.Replace("\r", "").Replace("%01$RC", "");
            //    //    string str6011 = str6001.Substring(0, str6001.Length - 2);
            //    //    for (int i = 0; i < str6011.Length / 1; i++)
            //    //    {
            //    //        try
            //    //        {
            //    //            CurrentTestSta[i] = str6011.Substring(i * 1, 1);
            //    //        }
            //    //        catch
            //    //        {
            //    //        }
            //    //    }
            //    //}
            //    Accesss();
            //}
           
        }
        public bool[] mInputStsXTow5455 = new bool[64];//两字保存
        public bool[] mInputStsXTow5051 = new bool[64];//两字保存
        public bool[] mInputStsXTow5253 = new bool[64];//两字保存
        public bool[] mInputStsXFour = new bool[64];//四字保存
        
        public bool[] mInputStsYTow = new bool[64];//四字保存
        public bool[] originStaSTEP1 = new bool[32];//两字保存
        public bool[] originStaSTEP2 = new bool[32];//两字保存
        public bool[] originStaSTEP3 = new bool[32];//两字保存
        public bool[] ThepositiveNegativeLimitSTEP1 = new bool[32];//两字保存
        public bool[] ThepositiveNegativeLimitSTEP2 = new bool[32];//两字保存
        public bool[] ThepositiveNegativeLimitSTEP3 = new bool[32];//两字保存
        string[] CurrentPosition = new string[20];
        public string[] CurrentTestSta = new string[10];
        public void Accesss()
        {
           
            string read = "";
            string sAddr = "";
            string outStr = "";
            int ioSts = 0;
            int step = 10;
            string en = "";
            string sendd = "";
            //for (int j = 0; j < step; j++)
            //{
            //    //判断PLC是否运动
            //    sendd = Dequeue(en);
            //    if (sendd != "")
            //    {
            //        if (COMM.IsOpen == false)
            //        {
            //            break;
            //        }
            //        COMM.Write(sendd);
            //        Thread.Sleep(100);
            //        read = DataReceived();
            //        break;
            //    }
            //}

            for (int j = 0; j < step; j++)
            {

                sAddr = "8R3080R3081R3082R3083R3084R3085R3086R3087";
                outStr = "";
                outStr = "%01#RCP" + sAddr;
                outStr = outStr + bcc(outStr) + "\r";
                if (COMM.IsOpen == false)
                {
                    Open("COM10");
                    break;
                }
                COMM.Write(outStr);
                Thread.Sleep(100);
                read = "";
                read = DataReceived();
                if (read != "")
                {
                    try
                    {
                        string str6001 = read.Replace("\r", "").Replace("%01$RC", "");
                        string str6011 = str6001.Substring(0, str6001.Length - 2);

                        for (int i = 0; i < str6011.Length / 1; i++)
                        {
                            CurrentTestSta[i] = str6011.Substring(i * 1, 1);
                        }

                    }
                    catch { }
                 
                }

            }
         

            //    switch (1)
            //    {             
            //    case 1:
            //        sAddr = "8R3080R3081R3082R3083R3084R3085R3086R3087";
            //        outStr = "";
            //        outStr = "%01#RCP" + sAddr;
            //        outStr = outStr + bcc(outStr) + "\r";
            //        if (COMM.IsOpen == false)
            //        {
            //            break;
            //        }
            //        COMM.Write(outStr);
            //        Thread.Sleep(100);
            //        read = "";
            //        read = DataReceived();
            //        if (read != "")
            //        {
            //            string str6001 = read.Replace("\r", "").Replace("%01$RC", "");
            //            string str6011 = str6001.Substring(0, str6001.Length - 2);

            //            for (int i = 0; i < str6011.Length / 1; i++)
            //            {
            //                try
            //                {
            //                    CurrentTestSta[i] = str6011.Substring(i * 1, 1);
            //                }
            //                catch { }

            //            }
            //        }

            //        break;
            //    case 2:
            //        outStr = "";
            //        outStr = "%01#RCCX00540055**\r";//读取2字  X
            //            try
            //            {
            //                if (COMM.IsOpen == false)
            //                {
            //                    break;
            //                }
            //                COMM.Write(outStr);
            //                read = "";
            //                Thread.Sleep(10);

            //                read = DataReceived();
            //                ioSts = 0;
            //                if (read != "")
            //                {
            //                    string str100 = read.Replace("\r", "").Replace("%01$RC", ""); ;
            //                    string str101 = str100.Substring(0, 4);
            //                    str100 = str100.Replace("\r", "").Replace("%01$RC", "");
            //                    str100 = str100.Substring(0, str100.Length - 2);
            //                    str101 = str100.Substring(0, 4);
            //                    str101 = change4bit(str101);
            //                    string str102 = str100.Substring(4, 4);
            //                    str102 = change4bit(str102);
            //                    string str103 = str102 + str101;
            //                    //  string str4 = str3[1].ToString() + str3[0].ToString() + str3[3].ToString() + str3[2].ToString();
            //                    ioSts = Convert.ToInt32(str103, 16);
            //                    for (int i = 0; i < mInputStsXTow5455.Length; i++)
            //                    {
            //                        mInputStsXTow5455[i] = (ioSts & (int)Math.Pow(2, i)) > 0;
            //                    }
            //                }

            //            }
            //            catch { }

            //            break;
            //        case 3:
            //            outStr = "";
            //            outStr = "%01#RCCX00500051**\r";//读取2字  X
            //            try
            //            {
            //                if (COMM.IsOpen == false)
            //                {
            //                    break;
            //                }
            //                COMM.Write(outStr);
            //                Thread.Sleep(10);
            //                read = "";
            //                read = DataReceived();
            //                ioSts = 0;
            //                if (read != "")
            //                {
            //                    string str100 = read.Replace("\r", "").Replace("%01$RC", ""); ;
            //                    string str101 = str100.Substring(0, 4);
            //                    str100 = str100.Replace("\r", "").Replace("%01$RC", "");
            //                    str100 = str100.Substring(0, str100.Length - 2);
            //                    str101 = str100.Substring(0, 4);
            //                    str101 = change4bit(str101);
            //                    string str102 = str100.Substring(4, 4);
            //                    str102 = change4bit(str102);
            //                    string str103 = str102 + str101;
            //                    //  string str4 = str3[1].ToString() + str3[0].ToString() + str3[3].ToString() + str3[2].ToString();
            //                    ioSts = Convert.ToInt32(str103, 16);
            //                    for (int i = 0; i < mInputStsXTow5051.Length; i++)
            //                    {
            //                        mInputStsXTow5051[i] = (ioSts & (int)Math.Pow(2, i)) > 0;
            //                    }
            //                }

            //            }
            //            catch { }
            //            //outStr = "";
            //            //outStr = "%01#RCCY00160018**\r";//读取3字
            //            //    COMM.Write(outStr);
            //            //Thread.Sleep(100);
            //            //read = DataReceived();
            //            //ioSts = 0;
            //            //if (read != "")
            //            //{
            //            //    string str1 = read.Replace("\r", "").Replace("%01$RC", ""); ;
            //            //    string str3 = str1.Substring(0, 4);
            //            //    str1 = str1.Replace("\r", "").Replace("%01$RC", "");
            //            //    str1 = str1.Substring(0, str1.Length - 2);
            //            //    str3 = str1.Substring(0, 4);
            //            //    string str6 = str1.Substring(4, 4);
            //            //    string str8 = str1.Substring(8, 4);
            //            //    string str7 = str8 + str6 + str3;
            //            //    //  string str4 = str3[1].ToString() + str3[0].ToString() + str3[3].ToString() + str3[2].ToString();
            //            //    ioSts = Convert.ToInt32(str7, 16);
            //            //    for (int i = 0; i < mInputStsI.Length; i++)
            //            //    {
            //            //        mInputStsI[i] = (ioSts & (int)Math.Pow(2, i)) > 0;
            //            //    }
            //            //}

            //            break;
            //    case 4:
            //            outStr = "";
            //            outStr = "%01#RCCX00520053**\r";//读取2字  X
            //            try
            //            {
            //                if (COMM.IsOpen == false)
            //                {
            //                    break;
            //                }
            //                COMM.Write(outStr);
            //                read = "";
            //                Thread.Sleep(10);
            //                read = DataReceived();
            //                ioSts = 0;
            //                if (read != "")
            //                {
            //                    string str100 = read.Replace("\r", "").Replace("%01$RC", ""); ;
            //                    string str101 = str100.Substring(0, 4);
            //                    str100 = str100.Replace("\r", "").Replace("%01$RC", "");
            //                    str100 = str100.Substring(0, str100.Length - 2);
            //                    str101 = str100.Substring(0, 4);
            //                    str101 = change4bit(str101);
            //                    string str102 = str100.Substring(4, 4);
            //                    str102 = change4bit(str102);
            //                    string str103 = str102 + str101;
            //                    //  string str4 = str3[1].ToString() + str3[0].ToString() + str3[3].ToString() + str3[2].ToString();
            //                    ioSts = Convert.ToInt32(str103, 16);
            //                    for (int i = 0; i < mInputStsXTow5253.Length; i++)
            //                    {
            //                        mInputStsXTow5253[i] = (ioSts & (int)Math.Pow(2, i)) > 0;
            //                    }
            //                }

            //            }
            //            catch { }
            //            //try
            //            //{
            //            //    outStr = "";
            //            //    outStr = "%01#RCCX00500053**\r";//读取4字  X
            //            //    if (COMM.IsOpen == false)
            //            //    {
            //            //        break;
            //            //    }
            //            //    COMM.Write(outStr);
            //            //    Thread.Sleep(100);
            //            //    read = DataReceived();
            //            //    ioSts = 0;
            //            //    if (read != "")
            //            //    {
            //            //      //  str2.ToString().PadLeft(4, '0');//df.ToString().PadLeft(4, '0');
            //            //        string str400 = read.Replace("\r", "").Replace("%01$RC", ""); ;
            //            //        string str401 = str400.Substring(0, 4);
            //            //        //  str400 = str400.Replace("\r", "").Replace("%01$RC", "");
            //            //        str400 = str400.Substring(0, str400.Length - 2);
            //            //        str401 = str400.Substring(0, 4);
            //            //        str401 = change4bit(str401);
            //            //        string str402 = str400.Substring(4, 4);
            //            //        str402 = change4bit(str402);
            //            //        string str403 = str400.Substring(8, 4);
            //            //        str403 = change4bit(str403);
            //            //        string str404 = str400.Substring(12, 4);
            //            //        str404 = change4bit(str404);
            //            //        string str405 = str404 + str403 + str402 + str401;
            //            //        //  string str4 = str3[1].ToString() + str3[0].ToString() + str3[3].ToString() + str3[2].ToString();
            //            //        ioSts = Convert.ToInt32(str405, 16);
            //            //        for (int i = 0; i < mInputStsXFour.Length; i++)
            //            //        {
            //            //            mInputStsXFour[i] = (ioSts & (int)Math.Pow(2, i)) > 0;
            //            //        }
            //            //    }

            //            //}
            //            //catch { }


            //        break;

            //        case 5:
            //            try
            //            {
            //                outStr = "";
            //                outStr = "%01#RCCY00160017**\r";//读取2字  Y
            //                if (COMM.IsOpen == false)
            //                {
            //                    break;
            //                }
            //                COMM.Write(outStr);
            //                read = "";
            //                Thread.Sleep(10);
            //                read = DataReceived();
            //                ioSts = 0;
            //                if (read != "")
            //                {
            //                    string str500 = read.Replace("\r", "").Replace("%01$RC", ""); ;
            //                    string str501 = str500.Substring(0, 4);
            //                    str500 = str500.Replace("\r", "").Replace("%01$RC", "");
            //                    str500 = str500.Substring(0, str500.Length - 2);
            //                    str501 = str500.Substring(0, 4);
            //                    str501 = change4bit(str501);
            //                    string str6 = str500.Substring(4, 4);
            //                    str6 = change4bit(str6);
            //                    string str7 = str6 + str501;
            //                    //  string str4 = str3[1].ToString() + str3[0].ToString() + str3[3].ToString() + str3[2].ToString();
            //                    ioSts = Convert.ToInt32(str7, 16);
            //                    for (int i = 0; i < mInputStsYTow.Length; i++)
            //                    {
            //                        mInputStsYTow[i] = (ioSts & (int)Math.Pow(2, i)) > 0;
            //                    }
            //                }

            //            }
            //            catch { }

            //            break;
            //        case 6://d读取当前位置读取一个寄存器
            //            try
            //            {
            //                sAddr = "D3001830018";
            //                outStr = "";
            //                outStr = "%01#RD" + sAddr;
            //                outStr = outStr + bcc(outStr) + "\r";
            //                if (COMM.IsOpen==false)
            //                {
            //                    break;
            //                }
            //                COMM.Write(outStr);
            //                Thread.Sleep(10);
            //                read = DataReceived();
            //                //  "%01#RD"
            //                if (read != "" && read.Contains("%01#RD"))
            //                {
            //                    string str600 = read.Replace("\r", "").Replace("%01$RD", "");
            //                    string str601 = str600.Substring(0, str600.Length - 2);
            //                    string[] CurrentPositionAA = new string[20];
            //                    for (int i = 0; i < str601.Length / 4; i++)
            //                    {
            //                        CurrentPositionAA[i] = change4bit(str601.Substring(i * 4, 4));
            //                        //Console.WriteLine(b[i]);
            //                    }
            //                    int keys = 0;
            //                    foreach (var key in CurrentPositionAA)
            //                    {
            //                        if (key != "")
            //                        {
            //                            CurrentPositionAA[keys] = HToTen(key);//10进制字符串
            //                            keys++;
            //                        }

            //                    }

            //                }

            //            }
            //            catch { }

            //            break;

            //        case 7://读取原点 
            //            try
            //            {
            //                sAddr = "Y00160016**\r";//读取1字原点
            //                outStr = "%01#RCC" + sAddr;
            //                if (COMM.IsOpen == false)
            //                {
            //                    break;
            //                }
            //                COMM.Write(outStr);
            //                Thread.Sleep(10);
            //                read = DataReceived();
            //                ioSts = 0;
            //                if (read != "")
            //                {
            //                    string str700 = read.Replace("\r", "").Replace("%01$RC", "");
            //                    string str701 = str700.Substring(0, 4);
            //                    str701 = change4bit(str701);
            //                    //  string str4 = str3[1].ToString() + str3[0].ToString() + str3[3].ToString() + str3[2].ToString();
            //                    ioSts = Convert.ToInt32(str701, 16);
            //                    for (int i = 0; i < originStaSTEP1.Length; i++)
            //                    {
            //                        originStaSTEP1[i] = (ioSts & (int)Math.Pow(2, i)) > 0;
            //                    }
            //                }
            //                sAddr = "Y00160016**\r";//读取1字原点
            //                outStr = "%01#RCC" + sAddr;
            //                COMM.Write(outStr);
            //                Thread.Sleep(10);
            //                read = DataReceived();
            //                ioSts = 0;
            //                if (read != "")
            //                {
            //                    string str710 = read.Replace("\r", "").Replace("%01$RC", "");
            //                    string str711 = str710.Substring(0, 4);
            //                    str711 = change4bit(str711);
            //                    //  string str4 = str3[1].ToString() + str3[0].ToString() + str3[3].ToString() + str3[2].ToString();
            //                    ioSts = Convert.ToInt32(str711, 16);
            //                    for (int i = 0; i < originStaSTEP2.Length; i++)
            //                    {
            //                        originStaSTEP2[i] = (ioSts & (int)Math.Pow(2, i)) > 0;
            //                    }
            //                }
            //                sAddr = "Y00160016**\r";//读取1字原点
            //                outStr = "%01#RCC" + sAddr;
            //                COMM.Write(outStr);
            //                Thread.Sleep(100);
            //                read = DataReceived();
            //                ioSts = 0;
            //                if (read != "")
            //                {
            //                    string str720 = read.Replace("\r", "").Replace("%01$RC", "");
            //                    string str721 = str720.Substring(0, 4);
            //                    str721 = change4bit(str721);
            //                    //  string str4 = str3[1].ToString() + str3[0].ToString() + str3[3].ToString() + str3[2].ToString();
            //                    ioSts = Convert.ToInt32(str721, 16);
            //                    for (int i = 0; i < originStaSTEP3.Length; i++)
            //                    {
            //                        originStaSTEP3[i] = (ioSts & (int)Math.Pow(2, i)) > 0;
            //                    }
            //                }

            //            }
            //            catch { }

            //            break;

            //        case 8://正负限位
            //            try
            //            {
            //                sAddr = "Y00160016**\r";//读取1字正负位
            //                outStr = "%01#RCC" + sAddr;
            //                if (COMM.IsOpen == false)
            //                {
            //                    break;
            //                }
            //                COMM.Write(outStr);
            //                Thread.Sleep(100);
            //                read = DataReceived();
            //                ioSts = 0;
            //                if (read != "")
            //                {
            //                    string str730 = read.Replace("\r", "").Replace("%01$RC", "");
            //                    string str731 = str730.Substring(0, 4);
            //                    str731 = change4bit(str731);
            //                    //  string str4 = str3[1].ToString() + str3[0].ToString() + str3[3].ToString() + str3[2].ToString();
            //                    ioSts = Convert.ToInt32(str731, 16);
            //                    for (int i = 0; i < ThepositiveNegativeLimitSTEP1.Length; i++)
            //                    {
            //                        ThepositiveNegativeLimitSTEP1[i] = (ioSts & (int)Math.Pow(2, i)) > 0;
            //                    }
            //                }
            //                sAddr = "Y00160016**\r";//读取1字正负位
            //                outStr = "%01#RCC" + sAddr;
            //                COMM.Write(outStr);
            //                Thread.Sleep(10);
            //                read = DataReceived();
            //                ioSts = 0;
            //                if (read != "")
            //                {
            //                    string str740 = read.Replace("\r", "").Replace("%01$RC", "");
            //                    string str741 = str740.Substring(0, 4);
            //                    str741 = change4bit(str741);
            //                    //  string str4 = str3[1].ToString() + str3[0].ToString() + str3[3].ToString() + str3[2].ToString();
            //                    ioSts = Convert.ToInt32(str741, 16);
            //                    for (int i = 0; i < ThepositiveNegativeLimitSTEP2.Length; i++)
            //                    {
            //                        ThepositiveNegativeLimitSTEP2[i] = (ioSts & (int)Math.Pow(2, i)) > 0;
            //                    }
            //                }
            //                sAddr = "Y00160016**\r";//读取1字正负位
            //                outStr = "%01#RCC" + sAddr;
            //                COMM.Write(outStr);
            //                Thread.Sleep(100);
            //                read = DataReceived();
            //                ioSts = 0;
            //                if (read != "")
            //                {
            //                    string str750 = read.Replace("\r", "").Replace("%01$RC", "");
            //                    string str751 = str750.Substring(0, 4);
            //                    //  string str4 = str3[1].ToString() + str3[0].ToString() + str3[3].ToString() + str3[2].ToString();
            //                    ioSts = Convert.ToInt32(str751, 16);
            //                    for (int i = 0; i < ThepositiveNegativeLimitSTEP3.Length; i++)
            //                    {
            //                        ThepositiveNegativeLimitSTEP3[i] = (ioSts & (int)Math.Pow(2, i)) > 0;
            //                    }
            //                }
            //            }
            //            catch { }

            //            break;
            //        default:

            //        //

            //        break;
            //}


        }
        private string HToTen(string str)
        {
            string str1 = "";
            string str2 = "";
            string s = "";
            if (str.Length == 4)
            {
               // str1 = str.Substring(0, 2);
               // str2 = str.Substring(2, 2);
             //   str = str2 + str1;
                double b1 = Int32.Parse(str, System.Globalization.NumberStyles.HexNumber);
               s = (b1/100) .ToString();
            }
            return s;
        }
        private string change4bit(string str)
        {
            string str1 = "";
            string str2 = "";
            string s = "";
            if (str.Length == 4)
            {
                str1 = str.Substring(0, 2);
                str2 = str.Substring(2, 2);
                s = str2 + str1;
                //  double b1 = Int32.Parse(str, System.Globalization.NumberStyles.HexNumber);
                //  s = (b1 / 100).ToString();
            }
            else if (str.Length == 3)
            {
                str1 = str.Substring(0, 1);
                str2 = str.Substring(1, 2);
                s = str2 + str1;

            }
            else if (str.Length == 2 || str.Length == 1)
            {

                s = str;

            }
            return s;
        }
        //    #region ---- 串口的操作--------------------------------------
        public bool Open(string com)
        {
           // list = a;

            try
            {
                if (COMM.IsOpen)
                {
                    COMM.Close();
                }
                COMM.ReadBufferSize = 1024;
                COMM.PortName = com;
                COMM.BaudRate = 9600;
                COMM.Parity = Parity.Odd;
                COMM.DataBits = 8;
                COMM.StopBits = StopBits.One;
            //    COMM.DataReceived += COMM_DataReceived;
            //    COMM.ReceivedBytesThreshold = 1;
                COMM.Open();
                flag = true;
                return flag;
            }
            catch (Exception)
            {
                MessageBox.Show("请确认连接端口是COM1或已连接");
                flag = false;
                return flag;
            }
        }
        //----------关闭串口--------------------------------
        public void CloseEd()
        {
            if (COMM.IsOpen)
            {
                COMM.Close();
            }
        }

        public string setY = "%01#WCS";
        public void Enqueue(string sendStr)//添加数据到队列
        {   //R00501
            sendStr = sendStr + bcc(sendStr);
            mSendQueue.Enqueue(sendStr+"\r");
        }
        public string Dequeue(string def)//出队列
        {
            string sendStr = "";
            if (mSendQueue.TryDequeue(out sendStr))
            {
                return sendStr;
            }
            else
            {
                return def;
            }
        }
        public string bcc(string chkString)
        {
            int chkSum = 0;
            string chkSums = "";
            int k;
            for (k = 0; k < chkString.Length; k++)
            {
                chkSum = chkSum ^ Asc(chkString.Substring(k, 1));
            }
            chkSums = Convert.ToString(chkSum, 16);
            return chkSums.Substring(chkSums.Length - 2, 2).ToUpper();

        }
        public int Asc(string character)
        {
            if (character.Length == 1)
            {
                ASCIIEncoding asciiEncoding = new ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
                return (intAsciiCode);
            }
            else
            {
                throw new Exception("character is not valid.");
            }
        }
        public void senddate(string str, string sendDate)
        {
            if (str == "%01#RCP")
            {
                try
                {
                    // string sAddr = "3R0050R0051R0052";批量读取操作
                    string sAddr = sendDate;
                    string outStr = "";
                    outStr = "%01#RCP" + sAddr;
                    outStr = outStr + "\r";
                    Enqueue(outStr);
                  //  COMM.Write(outStr);
                    return;
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);

                }
            }
            else if (str == "%01#RCS")//读取单个状态
            {
                //string sAddr = "X0000";
                string sAddr = sendDate;
                string outStr = "";
                outStr = "%01#RCS" + sAddr;
                outStr = outStr + "\r";
                Enqueue(outStr);
               // COMM.Write(outStr);
                return;
            }
            else if (str == "%01#RD")//读取DT值
            {
               // string sAddr = "D3001830020";
                string sAddr = sendDate;
                string outStr = "";
                outStr = "%01#RD" + sAddr;
                outStr = outStr  + "\r";
                Enqueue(outStr);
               // COMM.Write(outStr);
                return;
            }
            else if (str == "%01#RCC")//按字读取状态
            {
                // string sAddr = "Y00160017**\r";
                string sAddr = sendDate +"**\r";
                string outStr = "";
                outStr = "%01#RCC" + sAddr;
                //  outStr = outStr + bcc(outStr) + "\r";
                // sp.Write(outStr);
                Enqueue(outStr);
               // COMM.Write(outStr);
                return;
            }
            else if (str == "%01#WCS")//按字读取状态
            {
                // string sAddr = "Y00160017**\r";
                string sAddr = sendDate;
                string outStr = "";
                outStr = "%01#WCS" + sAddr;
                outStr = outStr  + "\r";
                Enqueue(outStr);
             //   COMM.Write(outStr);
                return;
            }
        }
        long received_count = 0;

        public string DataReceived()
        {
            string str = "";
            try
            {
              
                if (COMM.IsOpen && COMM.BytesToRead > 0)
                {
                    int n = COMM.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致   ；
                    byte[] buf = new byte[n];//声明一个临时字节数组存储当前来的串口数据   
                    received_count += n;//增加接收计数   
                    COMM.Read(buf, 0, n);//读取缓冲数据 
                    for (int i = 0; i < buf.Length; i++)
                    {
                        str = System.Text.Encoding.Default.GetString(buf);
                    }
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            return str;
        }
        public void COMM_DataReceived(object sender, SerialDataReceivedEventArgs e)//接受的返回值
        {

            Thread.Sleep(100);
            try
            {
                string str = "";
                if (COMM.IsOpen && COMM.BytesToRead > 0)
                {
                    int n = COMM.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致   ；
                    byte[] buf = new byte[n];//声明一个临时字节数组存储当前来的串口数据   
                    received_count += n;//增加接收计数   
                    COMM.Read(buf, 0, n);//读取缓冲数据 
                    for (int i = 0; i < buf.Length; i++)
                    {
                        str = System.Text.Encoding.Default.GetString(buf);
                    }
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

    }
}
