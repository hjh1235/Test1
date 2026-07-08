using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using Microsoft.VisualBasic;
using System.Threading;
namespace UniversalControlSystem
{
   public class MitsubishiFxModbus: CommunicationMoudBus, interfaceCommunication
    {  
        /// <summary>
        /// 三菱，ModBus_ASCII通讯协议
        /// </summary>
        public StringBuilder SendData=new StringBuilder();
        public StringBuilder Message=new StringBuilder();
        public StringBuilder DataReceived=new StringBuilder();
        
        public MitsubishiFxModbus():base()
        {
           // sSrialPort.DataReceived += serialPort1_DataReceived;
           
        }

        public MitsubishiFxModbus(string IP, int port) :base(IP, port)
        {
            ReciveDataEvent += ReciveDataEvent_handle;
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
        /// 向PLC置ON
        /// </summary>
        /// <param name="AddressType">地址类型S,X,Y,T,M,C,MSpecial</param>
        /// <param name="AddressNum">地址Number</param>
        /// <returns>reuslt</returns>
        public bool  AddressON(string  AddressType, int AddressNum)
        {
            Message.Clear();
            SendData.Clear();
            if (IsConnected() == false)
            {
                Message.AppendLine("串口未打开");
                return false;
            }
            string AddressOnOff = null;

            string Num = "0000" + AddressNum;
            int intNum = int.Parse(Strings.Left(Num, Num.Length - 1)) * 8 + int.Parse(Strings.Right(Num, 1));

            switch (AddressType)
            {
                case "S":
                    AddressOnOff = (AddressNum + 0).ToString("X4");//S0   置位、复位的起始地址为0000
                    break;
                case "X":

                    AddressOnOff = (intNum + 1024).ToString("X4");//X0   置位、复位的起始地址为0400   X序号需转化，其编号为0~7，10~17，20~27
                    break;
                case "Y":
                    AddressOnOff = (intNum + 1280).ToString("X4");//Y0   置位、复位的起始地址为0500   Y序号需转化，其编号为0~7，10~17，20~27
                    break;
                case "T":
                    AddressOnOff = (AddressNum + 1536).ToString("X4");//T0   置位、复位的起始地址为0600
                    break;
                case "M":
                    AddressOnOff = (AddressNum + 2048).ToString("X4");//M0   置位、复位的起始地址为0400
                    break;
                case "C":
                    AddressOnOff = (AddressNum + 3584).ToString("X4");//C0   置位、复位的起始地址为0E00
                    break;
                case "MSpecial":
                    AddressOnOff = (AddressNum + 3840).ToString("X4");//M0   置位、复位的起始地址为0400
                    break;
            }
            AddressOnOff = Strings.Right(AddressOnOff, 2) + Strings.Left(AddressOnOff, 2);  //高低位交换
            string AddressAsc = ASC(AddressOnOff);

            string sendString = "02 " + "37" + " " + AddressAsc + "03";
            string C = SumCheck(sendString);
            
            string sendAddress = sendString + " " + C;
            SendData.AppendLine(sendAddress);
            return SendString(sendAddress);
        }
        /// <summary>
        /// 向PLC置OFF
        /// </summary>
        /// <param name="AddressType">地址类型S,X,Y,T,M,C,MSpecial</param>
        /// <param name="AddressNum">地址Number</param>
        /// <returns>reuslt</returns>
        public bool AddressOFF(string AddressType, int AddressNum)
        {
            Message.Clear();
            SendData.Clear();
            if (IsConnected()  == false)
            {
                Message.AppendLine("串口未打开");
                return false;
            }
            string AddressOnOff = null;

            string Num = "0000" + AddressNum;
            int intNum = int.Parse(Strings.Left(Num, Num.Length - 1)) * 8 + int.Parse(Strings.Right(Num, 1));

            switch (AddressType)
            {
                case "S":
                    AddressOnOff = (AddressNum + 0).ToString("X4");//S0   置位、复位的起始地址为0000
                    break;
                case "X":

                    AddressOnOff = (intNum + 1024).ToString("X4");//X0   置位、复位的起始地址为0400   X序号需转化，其编号为0~7，10~17，20~27
                    break;
                case "Y":
                    AddressOnOff = (intNum + 1280).ToString("X4");//Y0   置位、复位的起始地址为0500   Y序号需转化，其编号为0~7，10~17，20~27
                    break;
                case "T":
                    AddressOnOff = (AddressNum + 1536).ToString("X4");//T0   置位、复位的起始地址为0600
                    break;
                case "M":
                    AddressOnOff = (AddressNum + 2048).ToString("X4");//M0   置位、复位的起始地址为0400
                    break;
                case "C":
                    AddressOnOff = (AddressNum + 3584).ToString("X4");//C0   置位、复位的起始地址为0E00
                    break;
                case "MSpecial":
                    AddressOnOff = (AddressNum + 3840).ToString("X4");//M0   置位、复位的起始地址为0400
                    break;
            }
            AddressOnOff = Strings.Right(AddressOnOff, 2) + Strings.Left(AddressOnOff, 2);  //高低位交换
            string AddressAsc = ASC(AddressOnOff);

            string sendString = "02 " + "38" + " " + AddressAsc + "03";
            string C = SumCheck(sendString);

            string sendAddress = sendString + " " + C;
            SendData.AppendLine(sendAddress);
            return SendString(sendAddress);
        }
        /// <summary>
        /// 转化为ASSCII码
        /// </summary>
        /// <param name="Ad"></param>
        /// <returns></returns>
        private string ASC(string Ad)
        {
            
            char[] addLetter = Ad.ToCharArray();
            string addAsc = null;
            foreach (var item in addLetter)
            {
                addAsc = addAsc + string.Format("{0:X}", Convert.ToInt32(item)) + " ";
            }

            return addAsc;
        }
        //效验
        private string SumCheck(string sendString)
        {

            //和校验
            string sendStringSum = sendString.Substring(3);
            string[] sSS = sendStringSum.Split(' ');//和校验SumCheck
            int sumCheck = 0;
            foreach (var item in sSS)
            {
                sumCheck = sumCheck + Convert.ToInt32(item, 16);
            }

            string SumCheck = sumCheck.ToString("X");
            int l = SumCheck.Length;
            string SumCheck1 = SumCheck.Substring(l - 2, 1);
            string SumCheck2 = SumCheck.Substring(l - 1, 1);
            string a = ((int)Convert.ToChar(SumCheck1)).ToString("X2");
            string b = ((int)Convert.ToChar(SumCheck2)).ToString("X2");
            string C = a + " " + b;
            return C;
        }
        static object ObjLock = new object();
        //向PLC写入数据
        private bool SendString(string sendString )
        {
            byte[] SendBytes = null;
            string SendDataStr = sendString;
            //16进制发送
            try
            {
                //剔除所有空格
                SendDataStr = SendDataStr.Replace(" ", "");
                //if (SendData.Length % 2 == 1)
                //{//奇数个字符
                //    SendData = SendData.Remove(SendData.Length - 1, 1);//去除末位字符
                //}
                List<string> SendDataList = new List<string>();
                for (int i = 0; i < SendDataStr.Length; i = i + 2)
                {
                    SendDataList.Add(SendDataStr.Substring(i, 2));
                }
                SendBytes = new byte[SendDataList.Count];
                for (int j = 0; j < SendBytes.Length; j++)
                {
                    SendBytes[j] = (byte)(Convert.ToInt32(SendDataList[j], 16));

                }
            }
            catch
            {
                Message.AppendLine( "请输入正确的16进制数据！");
                return false;
            }
            lock (ObjLock)
            {
                SendData(Encoding.ASCII.GetBytes(SendDataStr));
              //  sSrialPort.Write(SendBytes, 0, SendBytes.Length);//发送数据
            }
            
            Message.AppendLine("操作成功");
            return true;
        }

        /// <summary>
        /// 读取PLC寄存器地址
        /// </summary>
        /// <param name="AddressType">地址类型C,D,M,S,T,X,Y</param>
        /// <param name="AddressNum">地址Number</param>
        /// <returns></returns>
        public int? ReadAddress (string AddressType,   int AddressNum)
        {
          
            string Ad = null;//这种方式取得地址相对更简单  Ad=address
            switch (AddressType)
            {
                case "C":
                    if (AddressNum > 255)
                    {
                        Message.AppendLine("不可填入大于255的值，请重新填写！");
                        return null;
                    }
                    Ad = (AddressNum * 2 + 2560).ToString("X4");//16位计数器  1~199  
                    if (AddressNum > 200 && AddressNum <= 255)
                    {
                        Ad = (AddressNum * 4 + 3072).ToString("X4");//32位计数器  200~255  
                    }
                    break;
                case "D":
                    if (AddressNum > 8255)
                    {
                        Message.AppendLine("不可填入大于8255的值，请重新填写！");
                        return null;
                    }
                    Ad = (AddressNum * 2 + 4096).ToString("X4");//普通数据寄存器
                    if (AddressNum > 8000)//特殊数据寄存器   且需要 <8255
                    {
                        Ad = (AddressNum * 2 + 3584).ToString("X4");
                    }
                    break;
                case "M"://0~1023
                    Ad = (AddressNum * 2 + 256).ToString("X4");//接点、线圈
                    break;
                case "S":
                    Ad = (AddressNum * 2 + 0).ToString("X4");
                    break;
                case "T"://仅0~255个
                    Ad = (AddressNum * 2 + 2048).ToString("X4");//现在值
                    break;
                case "X":
                    Ad = (AddressNum * 2 + 128).ToString("X4");//接点
                    break;
                case "Y":
                    Ad = (AddressNum * 2 + 160).ToString("X4");//接点、线圈      不含脉冲
                    break;
            }
            string addAscR = ASC(Ad);
            string sendString = "02 30 " + addAscR + "30 32 03";

            string C = SumCheck(sendString);
            sendString = sendString + " " + C;
            SendData.AppendLine(sendString);
            SendString(sendString);
            DateTime StartTims = DateTime.Now;
            DateTime EndtTims;
            int Times=0;
            while (string.IsNullOrEmpty(DataReceived.ToString())&& Times<1000)
            {
                EndtTims = DateTime.Now;
                Times = (EndtTims - StartTims).Milliseconds;
            }
            int? Rst = string.IsNullOrEmpty(DataReceived.ToString()) ? null :(int?)int.Parse(DataReceived.ToString());
            Message.AppendLine("操作成功");
           return Rst;
        }

        /// <summary>
        /// 写入PLC寄存器地址
        /// </summary>
        /// <param name="AddressType">地址类型C,D,M,S,T,X,Y</param>
        /// <param name="AddressNum">地址Number</param>
        /// <param name="Data">写入的数据</param> 
        /// <returns></returns>
        public bool WriteAddress(string AddressType, int AddressNum,int Data)
        {

            string Ad = null;//这种方式取得地址相对更简单  Ad=address

            switch (AddressType)
            {
                case "C":
                    if (AddressNum > 255)
                    {
                        Message.AppendLine("不可填入大于255的值，请重新填写！");
                        return false;
                    }
                    Ad = (AddressNum * 2 + 2560).ToString("X4");//16位计数器  1~199  
                    if (AddressNum > 200 && AddressNum <= 255)
                    {
                        Ad = (AddressNum * 4 + 3072).ToString("X4");//32位计数器  200~255  
                    }
                    break;
                case "D":
                    if (AddressNum > 8255)
                    {
                        Message.AppendLine("不可填入大于8255的值，请重新填写！");
                        return false;
                    }
                    Ad = (AddressNum * 2 + 4096).ToString("X4");//普通数据寄存器
                    if (AddressNum > 8000)//特殊数据寄存器   且需要 <8255
                    {
                        Ad = (AddressNum * 2 + 3584).ToString("X4");
                    }
                    break;
                case "M"://0~1023
                    Ad = (AddressNum * 2 + 256).ToString("X4");//接点、线圈
                    break;
                case "S":
                    Ad = (AddressNum * 2 + 0).ToString("X4");
                    break;
                case "T"://仅0~255个
                    Ad = (AddressNum * 2 + 2048).ToString("X4");//现在值
                    break;
                case "X":
                    Ad = (AddressNum * 2 + 128).ToString("X4");//接点
                    break;
                case "Y":
                    Ad = (AddressNum * 2 + 160).ToString("X4");//接点、线圈      不含脉冲
                    break;
            }
            string addAscW = ASC(Ad);
            string WriteNum = ASC(Data.ToString("X4"));
            WriteNum = Strings.Right(WriteNum, 6) + Strings.Left(WriteNum, 6);

            string sendString = "02 31 " + addAscW + "30 32 " + WriteNum + "03";

            string C = SumCheck(sendString);
            sendString = sendString + " " + C;
            SendData.AppendLine(sendString);
            SendString(sendString);
            Message.AppendLine("操作成功");
            return true;
        }
        public event Action<string> UpData;
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            Thread.Sleep(100);
            byte[] ReDatas = Encoding.ASCII.GetBytes(ReciveData);
          //  byte[] ReDatas = new byte[sSrialPort.BytesToRead];//返回命令包
          //  sSrialPort.Read(ReDatas, 0, ReDatas.Length);//读取数据

            //StringBuilder sb = new StringBuilder();

            string S;

            if (ReDatas.Length > 4)//只处理正常接收到数据    若只返回06、15或其他均在else中处理
            {
                DataReceived.Clear();
                string S1 = ((char)ReDatas[1]).ToString();
                string S2 = ((char)ReDatas[2]).ToString();
                string S3 = ((char)ReDatas[3]).ToString();
                string S4 = ((char)ReDatas[4]).ToString();
                S = S3 + S4 + S1 + S2;
            }
            else
            {
                
                return;
            }
            DataReceived.AppendLine(S);
            if (UpData!=null)
            {
                UpData(S);
            }

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
