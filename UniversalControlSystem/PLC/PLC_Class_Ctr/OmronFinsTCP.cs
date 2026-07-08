using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Timers;

namespace UniversalControlSystem
{
    public class EtherNetPLC
    {

        public short[] AR;
        public bool bPLCConnect;
        public short[] CIO;
        public short[] DM;
        public short[] HR;
        public short[] WR;
        //=============================================
        private static int CheckUpDateLock = 0;
        private static System.Timers.Timer CheckUpdatetimer = new System.Timers.Timer();
        private static object LockObject = new Object();
        /// <summary>
        /// 自定义计时器
        /// </summary>
        public void GetTimerStart()
        {
            // 循环间隔时间(10分钟)
            CheckUpdatetimer.Interval = 100;
            // 允许Timer执行
            CheckUpdatetimer.Enabled = true;
            // 定义回调
            CheckUpdatetimer.Elapsed += new ElapsedEventHandler(CheckUpdatetimer_Elapsed);
            // 定义多次循环
            CheckUpdatetimer.AutoReset = true;
            CheckUpdatetimer.Start();
            //   CheckUpdatetimer.Stop();
        }
        public void CheckUpdatetimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // 加锁检查更新锁
            lock (LockObject)
            {
                if (CheckUpDateLock == 0)
                    CheckUpDateLock = 1;
                else
                    return;
            }
            //具体实现功能的方法
            Check();
            // 解锁更新检查锁
            lock (LockObject)
            {
                CheckUpDateLock = 0;
            }
        }
        /// <summary>
        /// 计时器刷新的内容
        /// </summary>
        public void Check()
        {
            if (BasicClass.Client.Connected == true)
            {   //刷新DM
                //short[] rdDM;
                //ReadWords(PlcMemory.DM, 0, 2500, out rdDM);
                //DM = rdDM;
                ////刷新CIO
                //short[] rdCIO;
                //ReadWords(PlcMemory.CIO, 0, 250, out rdCIO);
                //CIO = rdCIO;
             
                ////刷新W
                //short[] rdW;
                //ReadWords(PlcMemory.WR, 0, 2500, out rdW);
                //WR = rdW;
                ////刷新A
                //short[] rdA;
                //ReadWords(PlcMemory.AR, 0, 2500, out rdA);
                //AR = rdA;
                ////刷新H
                //short[] rdH;
                //ReadWords(PlcMemory.HR, 0, 2500, out rdH);
                //HR = rdH;
            }
        }
        /// <summary>
        /// 读取输入输出与继电器位的转态
        /// </summary>
        /// <param name="type"></param>
        /// <param name="Word"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public bool Get_Bit(PlcMemory type, int Word,int bit)
        {
            bool Sta = false;
            if (type== PlcMemory.CIO)
            {
            string _Bit  =  Convert.ToString(CIO[Word], 2);
                if (_Bit[bit] == 1)
                {
                    Sta = true;
                }
                else
                {
                    Sta = false;
                }
            }
            else
            {
                string _Bit = Convert.ToString(WR[Word], 2);
                if (_Bit[bit] == 1)
                {
                    Sta = true;
                }
                else
                {
                    Sta = false;
                }
            }
            return Sta;
        }
        /// <summary>
        /// 写多个字
        /// </summary>
        /// <param name="mr">类型</param>
        /// <param name="ch">起始位</param>
        /// <param name="cnt">数量</param>
        /// <param name="inData">状态或数据数组</param>
        /// <param name="op"></param>
        public bool Write_More_Words(PlcMemory mr, short ch, short cnt, short[] inData, MemoryType Type)
        {
            int re = 0;
            bool res = false;
            if (mr== PlcMemory.CIO)
            {
                re = WriteWords(mr, ch, cnt, inData, Type);
                if (re != 0)
                {
                    //写入数据出错
                     res =false;
                }
                else
                {
                    res =  true;
                    //txtUseTimeW.Text += ",写入数据成功！";
                }
            }
            else if (mr == PlcMemory.DM)
            {
                re = WriteWords(mr, ch, cnt, inData, MemoryType.Word);
                if (re != 0)
                {
                    //写入数据出错
                    res = false;
                }
                else
                {
                    res = true;
                    //txtUseTimeW.Text += ",写入数据成功！";
                }
            }
            else if (mr == PlcMemory.AR)
            {
                re = WriteWords(mr, ch, cnt, inData, Type);
                if (re != 0)
                {
                    //写入数据出错
                    res = false;
                }
                else
                {
                    res = true;
                    //txtUseTimeW.Text += ",写入数据成功！";
                }
            }
            else if (mr == PlcMemory.HR)
            {
                re = WriteWords(mr, ch, cnt, inData, Type);
                if (re != 0)
                {
                    //写入数据出错
                    res = false;
                }
                else
                {
                    res = true;
                    //txtUseTimeW.Text += ",写入数据成功！";
                }
            }
            else if (mr == PlcMemory.WR)
            {
                re = WriteWords(mr, ch, cnt, inData, Type);
                if (re != 0)
                {
                    //写入数据出错
                    res = false;
                }
                else
                {
                    res = true;
                    //txtUseTimeW.Text += ",写入数据成功！";
                }
            }
            return res;
        }
   
        /// <summary>
        /// PLC节点号，调试方法，一般不需要使用
        /// </summary>
        public string PLCNode
        {
            get { return BasicClass.plcNode.ToString(); }
        }

        /// <summary>
        /// PC节点号，调试方法，一般不需要使用
        /// </summary>
        public string PCNode
        {
            get { return BasicClass.pcNode.ToString(); }
        }

        /// <summary>
        /// 实例化PLC操作对象
        /// </summary>
        public EtherNetPLC()
        {
         
            BasicClass.Client = new TcpClient();
          //  GetTimerStart();
        }

        /// <summary>
        /// 与PLC建立TCP连接
        /// </summary>
        /// <param name="rIP">PLC的IP地址</param>
        /// <param name="rPort">端口号，默认9600</param>
        /// <param name="timeOut">超时时间，默认3000毫秒</param>
        /// <returns></returns>
        public short Link(string rIP, short rPort, short timeOut = 3000)
        {
            if(BasicClass.PingCheck(rIP,timeOut))
            {
                BasicClass.Client.Connect(rIP, (int)rPort);
                BasicClass.Stream = BasicClass.Client.GetStream();
                Thread.Sleep(10);

                if (BasicClass.SendData(FinsClass.HandShake()) != 0)
                {
                    return -1;
                }
                else
                {
                    //开始读取返回信号
                    byte[] buffer = new byte[24];
                    if (BasicClass.ReceiveData(buffer) != 0)
                    {
                        return -1;
                    }
                    else
                    {
                        if (buffer[15] != 0)//TODO:这里的15号是不是ERR信息暂时不能完全肯定
                            return -1;
                        else
                        {
                            BasicClass.pcNode = buffer[19];
                            BasicClass.plcNode = buffer[23];
                            return 0;
                        }
                    }
                }
            }
            else
            {
                //连接超时
                return -1;
            }
        }

        /// <summary>
        /// 关闭PLC操作对象的TCP连接
        /// </summary>
        /// <returns></returns>
        public short Close()
        {
            try
            {
                BasicClass.Stream.Close();
                BasicClass.Client.Close();
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 读值方法（多个连续值）
        /// </summary>
        /// <param name="mr">地址类型枚举</param>
        /// <param name="ch">起始地址</param>
        /// <param name="cnt">地址个数</param>
        /// <param name="reData">返回值</param>
        /// <returns></returns>
        public short ReadWords(PlcMemory mr, short ch, short cnt, out short[] reData)
        {
            reData = new short[(int)(cnt)];//储存读取到的数据
            int num = (int)(30 + cnt * 2);//接收数据(Text)的长度,字节数
            byte[] buffer = new byte[num];//用于接收数据的缓存区大小
            byte[] array = FinsClass.FinsCmd(RorW.Read, mr, MemoryType.Word, ch, 00, cnt);
            if (BasicClass.SendData(array) == 0)
            {
                if (BasicClass.ReceiveData(buffer) == 0)
                {
                    //命令返回成功，继续查询是否有错误码，然后在读取数据
                    bool succeed = true;
                    if (buffer[11] == 3)
                        succeed = ErrorCode.CheckHeadError(buffer[15]);
                    if (succeed)//no header error
                    {
                        //endcode为fins指令的返回错误码
                        if (ErrorCode.CheckEndCode(buffer[28], buffer[29]))
                        {
                            //完全正确的返回，开始读取返回的具体数值
                            for (int i = 0; i < cnt; i++)
                            {
                                //返回的数据从第30字节开始储存的,
                                //PLC每个字占用两个字节，且是高位在前，这和微软的默认低位在前不同
                                //因此无法直接使用，reData[i] = BitConverter.ToInt16(buffer, 30 + i * 2);
                                //先交换了高低位的位置，然后再使用BitConverter.ToInt16转换
                                byte[] temp = new byte[] { buffer[30 + i * 2 + 1], buffer[30 + i * 2] };
                                reData[i] = BitConverter.ToInt16(temp, 0);
                            }
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 读单个字方法
        /// </summary>
        /// <param name="mr"></param>
        /// <param name="ch"></param>
        /// <param name="reData"></param>
        /// <returns></returns>
        public short ReadWord(PlcMemory mr, short ch, out short reData)
        {
            short[] temp;
            reData = new short();
            short re = ReadWords(mr, ch, (short)1, out temp);
            if (re != 0)
                return -1;
            else
            {
                reData = temp[0];
                return 0;
            }
        }

        /// <summary>
        /// 写值方法（多个连续值）
        /// </summary>
        /// <param name="mr">地址类型枚举</param>
        /// <param name="ch">起始地址</param>
        /// <param name="cnt">地址个数</param>
        /// <param name="inData">写入值</param>
        /// <returns></returns>
        public short WriteWords(PlcMemory mr, short ch, short cnt, short[] inData, MemoryType Type)
        {            
            byte[] buffer = new byte[30];
            byte[] arrayhead = FinsClass.FinsCmd(RorW.Write, mr, Type, ch, 00, cnt);//前34字节和读指令基本一直，还需要拼接下面的输入数据数组
            byte[] wdata = new byte[(int)(cnt * 2)];
            //转换写入值到wdata数组
            for (int i = 0; i < cnt; i++)
            {
                byte[] temp = BitConverter.GetBytes(inData[i]);
                wdata[i * 2] = temp[1];//转换为PLC的高位在前储存方式
                wdata[i * 2 + 1] = temp[0];
            }
            //拼接写入数组
            byte[] array = new byte[(int)(cnt * 2 + 34)];
            arrayhead.CopyTo(array, 0);
            wdata.CopyTo(array, 34);
            if (BasicClass.SendData(array) == 0)
            {
                if (BasicClass.ReceiveData(buffer) == 0)
                {
                    //命令返回成功，继续查询是否有错误码，然后在读取数据
                    bool succeed = true;
                    if (buffer[11] == 3)
                        succeed = ErrorCode.CheckHeadError(buffer[15]);
                    if (succeed)//no header error
                    {
                        //endcode为fins指令的返回错误码
                        if (ErrorCode.CheckEndCode(buffer[28], buffer[29]))
                        {
                            //完全正确的返回0
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

      

        /// <summary>
        /// 读值方法-按位bit（单个）
        /// </summary>
        /// <param name="mr">地址类型枚举</param>
        /// <param name="ch">地址000.00</param>
        /// <param name="bs">返回开关状态枚举EtherNetPLC.BitState，0/1</param>
        /// <returns></returns>
        public short GetBitState(PlcMemory mr, string ch, out short bs)
        {
            bs = new short();
            byte[] buffer = new byte[31];//用于接收数据的缓存区大小
            short cnInt = short.Parse(ch.Split('.')[0]);
            short cnBit = short.Parse(ch.Split('.')[1]);
            byte[] array = FinsClass.FinsCmd(RorW.Read, mr, MemoryType.Bit, cnInt, cnBit, 1);
            if (BasicClass.SendData(array) == 0)
            {
                if (BasicClass.ReceiveData(buffer) == 0)
                {
                    //命令返回成功，继续查询是否有错误码，然后在读取数据
                    bool succeed = true;
                    if (buffer[11] == 3)
                        succeed = ErrorCode.CheckHeadError(buffer[15]);
                    if (succeed)//no header error
                    {
                        //endcode为fins指令的返回错误码
                        if (ErrorCode.CheckEndCode(buffer[28], buffer[29]))
                        {
                            //完全正确的返回，开始读取返回的具体数值
                            bs = (short)buffer[30];
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 写值方法-按位bit（单个）
        /// </summary>
        /// <param name="mr">地址类型枚举</param>
        /// <param name="ch">地址000.00</param>
        /// <param name="bs">开关状态枚举EtherNetPLC.BitState，0/1</param>
        /// <returns></returns>
        public short SetBitState(PlcMemory mr, string ch, BitState bs)
        {
            byte[] buffer = new byte[30];
            short cnInt = short.Parse(ch.Split('.')[0]);
            short cnBit = short.Parse(ch.Split('.')[1]);
            byte[] arrayhead = FinsClass.FinsCmd(RorW.Write, mr, MemoryType.Bit, cnInt, cnBit, 1);
            byte[] array = new byte[35];
            arrayhead.CopyTo(array, 0);
            array[34] = (byte)bs;
            if (BasicClass.SendData(array) == 0)
            {
                if (BasicClass.ReceiveData(buffer) == 0)
                {
                    //命令返回成功，继续查询是否有错误码，然后在读取数据
                    bool succeed = true;
                    if (buffer[11] == 3)
                        succeed = ErrorCode.CheckHeadError(buffer[15]);
                    if (succeed)//no header error
                    {
                        //endcode为fins指令的返回错误码
                        if (ErrorCode.CheckEndCode(buffer[28], buffer[29]))
                        {
                            //完全正确的返回0
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 读一个浮点数的方法，单精度，在PLC中占两个字
        /// </summary>
        /// <param name="mr">地址类型枚举</param>
        /// <param name="ch">起始地址，会读取两个连续的地址，因为单精度在PLC中占两个字</param>
        /// <param name="reData">返回一个float型</param>
        /// <returns></returns>
        public short ReadReal(PlcMemory mr, short ch,out float reData)
        {
            reData = new float();
            int num = (int)(30 + 2 * 2);//接收数据(Text)的长度,字节数
            byte[] buffer = new byte[num];//用于接收数据的缓存区大小
            byte[] array = FinsClass.FinsCmd(RorW.Read, mr, MemoryType.Word, ch, 00, 2);
            if (BasicClass.SendData(array) == 0)
            {
                if (BasicClass.ReceiveData(buffer) == 0)
                {
                    //命令返回成功，继续查询是否有错误码，然后在读取数据
                    bool succeed = true;
                    if (buffer[11] == 3)
                        succeed = ErrorCode.CheckHeadError(buffer[15]);
                    if (succeed)//no header error
                    {
                        //endcode为fins指令的返回错误码
                        if (ErrorCode.CheckEndCode(buffer[28], buffer[29]))
                        {
                            //完全正确的返回，开始读取返回的具体数值
                            byte[] temp = new byte[] { buffer[30 + 1], buffer[30], buffer[30 + 3], buffer[30 + 2] };
                            reData = BitConverter.ToSingle(temp, 0);
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
    }


    class FinsClass
    {
        /// <summary>
        /// 获取内存区码
        /// </summary>
        /// <param name="mr">寄存器类型</param>
        /// <param name="mt">地址类型</param>
        /// <returns></returns>
        private static byte GetMemoryCode(PlcMemory mr, MemoryType mt)
        {
            if (mt == MemoryType.Bit)
            {
                switch (mr)
                {
                    case PlcMemory.CIO:
                        return 0x30;
                    case PlcMemory.WR:
                        return 0x31;
                    case PlcMemory.HR:
                        return 0x32;
                    case PlcMemory.AR:
                        return 0x33;
                    case PlcMemory.DM:
                        return 0x02;
                    default:
                        return 0x00;
                }
            }
            else
            {
                switch (mr)
                {
                    case PlcMemory.CIO:
                        return 0xB0;
                    case PlcMemory.WR:
                        return 0xB1;
                    case PlcMemory.HR:
                        return 0xB2;
                    case PlcMemory.AR:
                        return 0xB3;
                    case PlcMemory.DM:
                        return 0x82;
                    default:
                        return 0x00;
                }
            }
        }

        /// <summary>
        /// PC请求连接的握手信号，第一次连接会分配PC节点号
        /// </summary>
        /// <returns></returns>
        internal static byte[] HandShake()
        {
            #region fins command
            byte[] array = new byte[20];
            array[0] = 0x46;
            array[1] = 0x49;
            array[2] = 0x4E;
            array[3] = 0x53;

            array[4] = 0;
            array[5] = 0;
            array[6] = 0;
            array[7] = 0x0C;

            array[8] = 0;
            array[9] = 0;
            array[10] = 0;
            array[11] = 0;

            array[12] = 0;
            array[13] = 0;
            array[14] = 0;
            array[15] = 0;//ERR？

            array[16] = 0;
            array[17] = 0;
            array[18] = 0;
            array[19] = 0;//TODO:ask for client and server node number, the client node will allocated automatically
            //array[19] = this.GetIPNode(lIP);//本机IP地址的末位
            #endregion fins command
            return array;
        }

        /// <summary>
        /// Fins读写指令生成
        /// </summary>
        /// <param name="rw">读写类型</param>
        /// <param name="mr">寄存器类型</param>
        /// <param name="mt">地址类型</param>
        /// <param name="ch">起始地址</param>
        /// <param name="offset">位地址：00-15,字地址则为00</param>
        /// <param name="cnt">地址个数,按位读写只能是1</param>
        /// <returns></returns>
        internal static byte[] FinsCmd(RorW rw, PlcMemory mr, MemoryType mt, short ch, short offset, short cnt)
        {
            //byte[] array;
            //if (rw == RorW.Read)
            //    array = new byte[34];
            //else
            //    array = new byte[(int)(cnt * 2 + 33 + 1)];//长度是如何确定的在fins协议174页
            byte[] array = new byte[34];//写指令还有后面的写入数组需要拼接在一起！
            //TCP FINS header
            array[0] = 0x46;//F
            array[1] = 0x49;//I
            array[2] = 0x4E;//N
            array[3] = 0x53;//S

            array[4] = 0;//cmd length
            array[5] = 0;
            //指令长度从下面字节开始计算array[8]
            if (rw == RorW.Read)
            {
                array[6] = 0;
                array[7] = 0x1A;//26
            }
            else
            {
                //写数据的时候一个字占两个字节，而一个位只占一个字节
                if (mt == MemoryType.Word)
                {
                    array[6] = (byte)((cnt * 2 + 26) / 256);
                    array[7] = (byte)((cnt * 2 + 26) % 256);
                }
                else
                {
                    array[6] = 0;
                    array[7] = 0x1B;
                }
            }

            array[8] = 0;//frame command
            array[9] = 0;
            array[10] = 0;
            array[11] = 0x02;

            array[12] = 0;//err
            array[13] = 0;
            array[14] = 0;
            array[15] = 0;
            //command frame header
            array[16] = 0x80;//ICF
            array[17] = 0x00;//RSV
            array[18] = 0x02;//GCT, less than 8 network layers
            array[19] = 0x00;//DNA, local network

            array[20] = BasicClass.plcNode;//DA1
            array[21] = 0x00;//DA2, CPU unit
            array[22] = 0x00;//SNA, local network
            array[23] = BasicClass.pcNode;//SA1

            array[24] = 0x00;//SA2, CPU unit
            array[25] = 0xFF;
            //TODO：array[25] = Convert.ToByte(21);//SID//?????----------------------------------00-FF任意值

            //指令码
            if (rw == RorW.Read)
            {
                array[26] = 0x01;//cmdCode--0101
                array[27] = 0x01;
            }
            else
            {
                array[26] = 0x01;//write---0102
                array[27] = 0x02;
            }
            //地址
            //array[28] = (byte)mr;
            array[28] = GetMemoryCode(mr, mt);
            array[29] = (byte)(ch / 256);
            array[30] = (byte)(ch % 256);
            array[31] = (byte)offset;

            array[32] = (byte)(cnt / 256);
            array[33] = (byte)(cnt % 256);

            return array;
        }
    }
    /// <summary>
    /// 寄存器类型,十六进制表示形式
    /// </summary>
    public enum PlcMemory
    {
        //CIO_Word = 0xB0,
        //CIO_Bit = 0x30,
        //WR_Word = 0xB1,
        //WR_Bit = 0x31,
        //HR_Word =0xB2,
        //HR_Bit = 0x32,
        //AR_Word =0xB3,
        //AR_Bit = 0x33,
        //DM_Word = 0x82,
        //DM_Bit = 0x02
        CIO,
        WR,
        HR,
        AR,
        DM
    }

    /// <summary>
    /// 地址类型
    /// </summary>
    public enum MemoryType
    {
        Bit,
        Word
    }

    /// <summary>
    /// 数据类型,PLC字为16位数，最高位为符号位，负数表现形式为“取反加一”
    /// </summary>
    public enum DataType
    {
        BIT,
        INT16,
        REAL
    }

    /// <summary>
    /// bit位开关状态，on=1，off=0
    /// </summary>
    public enum BitState
    {
        ON = 1,
        OFF = 0
    }

    /// <summary>
    /// 区分指令的读写类型
    /// </summary>
    public enum RorW
    {
        Read,
        Write
    }

        class BasicClass
    {
        internal static TcpClient Client;
        internal static NetworkStream Stream;
        internal static byte pcNode, plcNode;

        //检查PLC链接状况
        internal static bool PingCheck(string ip,int timeOut)
        {
            Ping ping = new Ping();
            PingReply pr = ping.Send(ip, timeOut);
            if (pr.Status == IPStatus.Success)
                return true;
            else
                return false;
        }

        //内部方法，发送数据
        internal static short SendData(byte[] sd)
        {
            try
            {
             
                Stream.Write(sd, 0, sd.Length);
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        //内部方法，接收数据
        internal static short ReceiveData(byte[] rd)
        {
            try
            {
                //等待可读数据到底指定的长度，自己想的方法，下面的另一写法参考网络。
                //突然发现，此方法在数据量达不到指定长度时会死循环！
                //while (true)
                //{
                //    Thread.Sleep(1);
                //    if (Client.Available >= rd.Length && Stream.DataAvailable)
                //        break;
                //}
                //this.Stream.Read(rd, 0, rd.Length);
                //另一写法:
                int index = 0;
                do
                {
                    int len = Stream.Read(rd, index, rd.Length - index);
                    if (len == 0)
                        return -1;//这里控制读取不到数据时就跳出,网络异常断开，数据读取不完整。
                    else
                        index += len;
                } while (index < rd.Length);
                return 0;
            }
            catch
            {
                return -1;
            }
        }
    }
    class ErrorCode
    {
        /// <summary>
        /// （若返回的头指令为3）检查命令头中的错误代码
        /// </summary>
        /// <param name="Code">错误代码</param>
        /// <returns>指示程序是否可以继续进行</returns>
        internal static bool CheckHeadError(byte Code)
        {
            switch (Code)
            {
                case 0x00: return true;
                case 0x01: return false;//RaiseException("the head is not 'FINS'");
                case 0x02: return false;//RaiseException("the data length is too long");
                case 0x03: return false;//RaiseException("the command is not supported");
            }
            //no hit
            return false;//RaiseException("unknown exception");
        }

        /// <summary>
        /// 检查命令帧中的EndCode
        /// </summary>
        /// <param name="Main">主码</param>
        /// <param name="Sub">副码</param>
        /// <returns>指示程序是否可以继续进行</returns>
        internal static bool CheckEndCode(byte Main, byte Sub)
        {
            switch (Main)
            {
                case 0x00:
                    switch (Sub)
                    {
                        case 0x00: return true;//the only situation of success
                        case 0x01: return false;//RaiseException("service canceled");
                    }
                    break;

                case 0x01:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("local node not in network");
                        case 0x02: return false;//RaiseException("token timeout");
                        case 0x03: return false;//RaiseException("retries failed");
                        case 0x04: return false;//RaiseException("too many send frames");
                        case 0x05: return false;//RaiseException("node address range error");
                        case 0x06: return false;//RaiseException("node address duplication");
                    }
                    break;

                case 0x02:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("destination node not in network");
                        case 0x02: return false;//RaiseException("unit missing");
                        case 0x03: return false;//RaiseException("third node missing");
                        case 0x04: return false;//RaiseException("destination node busy");
                        case 0x05: return false;//RaiseException("response timeout");
                    }
                    break;

                case 0x03:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("communications controller error");
                        case 0x02: return false;//RaiseException("CPU unit error");
                        case 0x03: return false;//RaiseException("controller error");
                        case 0x04: return false;//RaiseException("unit number error");
                    }
                    break;

                case 0x04:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("undefined command");
                        case 0x02: return false;//RaiseException("not supported by model/version");
                    }
                    break;

                case 0x05:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("destination address setting error");
                        case 0x02: return false;//RaiseException("no routing tables");
                        case 0x03: return false;//RaiseException("routing table error");
                        case 0x04: return false;//RaiseException("too many relays");
                    }
                    break;

                case 0x10:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("command too long");
                        case 0x02: return false;//RaiseException("command too short");
                        case 0x03: return false;//RaiseException("elements/data don't match");
                        case 0x04: return false;//RaiseException("command format error");
                        case 0x05: return false;//RaiseException("header error");
                    }
                    break;

                case 0x11:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("area classification missing");
                        case 0x02: return false;//RaiseException("access size error");
                        case 0x03: return false;//RaiseException("address range error");
                        case 0x04: return false;//RaiseException("address range exceeded");
                        case 0x06: return false;//RaiseException("program missing");
                        case 0x09: return false;//RaiseException("relational error");
                        case 0x0a: return false;//RaiseException("duplicate data access");
                        case 0x0b: return false;//RaiseException("response too long");
                        case 0x0c: return false;//RaiseException("parameter error");
                    }
                    break;

                case 0x20:
                    switch (Sub)
                    {
                        case 0x02: return false;//RaiseException("protected");
                        case 0x03: return false;//RaiseException("table missing");
                        case 0x04: return false;//RaiseException("data missing");
                        case 0x05: return false;//RaiseException("program missing");
                        case 0x06: return false;//RaiseException("file missing");
                        case 0x07: return false;//RaiseException("data mismatch");
                    }
                    break;

                case 0x21:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("read-only");
                        case 0x02: return false;//RaiseException("protected , cannot write data link table");
                        case 0x03: return false;//RaiseException("cannot register");
                        case 0x05: return false;//RaiseException("program missing");
                        case 0x06: return false;//RaiseException("file missing");
                        case 0x07: return false;//RaiseException("file name already exists");
                        case 0x08: return false;//RaiseException("cannot change");
                    }
                    break;

                case 0x22:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("not possible during execution");
                        case 0x02: return false;//RaiseException("not possible while running");
                        case 0x03: return false;//RaiseException("wrong PLC mode");
                        case 0x04: return false;//RaiseException("wrong PLC mode");
                        case 0x05: return false;//RaiseException("wrong PLC mode");
                        case 0x06: return false;//RaiseException("wrong PLC mode");
                        case 0x07: return false;//RaiseException("specified node not polling node");
                        case 0x08: return false;//RaiseException("step cannot be executed");
                    }
                    break;

                case 0x23:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("file device missing");
                        case 0x02: return false;//RaiseException("memory missing");
                        case 0x03: return false;//RaiseException("clock missing");
                    }
                    break;

                case 0x24:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("table missing");
                    }
                    break;

                case 0x25:
                    switch (Sub)
                    {
                        case 0x02: return false;//RaiseException("memory error");
                        case 0x03: return false;//RaiseException("I/O setting error");
                        case 0x04: return false;//RaiseException("too many I/O points");
                        case 0x05: return false;//RaiseException("CPU bus error");
                        case 0x06: return false;//RaiseException("I/O duplication");
                        case 0x07: return false;//RaiseException("CPU bus error");
                        case 0x09: return false;//RaiseException("SYSMAC BUS/2 error");
                        case 0x0a: return false;//RaiseException("CPU bus unit error");
                        case 0x0d: return false;//RaiseException("SYSMAC BUS No. duplication");
                        case 0x0f: return false;//RaiseException("memory error");
                        case 0x10: return false;//RaiseException("SYSMAC BUS terminator missing");
                    }
                    break;

                case 0x26:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("no protection");
                        case 0x02: return false;//RaiseException("incorrect password");
                        case 0x04: return false;//RaiseException("protected");
                        case 0x05: return false;//RaiseException("service already executing");
                        case 0x06: return false;//RaiseException("service stopped");
                        case 0x07: return false;//RaiseException("no execution right");
                        case 0x08: return false;//RaiseException("settings required before execution");
                        case 0x09: return false;//RaiseException("necessary items not set");
                        case 0x0a: return false;//RaiseException("number already defined");
                        case 0x0b: return false;//RaiseException("error will not clear");
                    }
                    break;

                case 0x30:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("no access right");
                    }
                    break;

                case 0x40:
                    switch (Sub)
                    {
                        case 0x01: return false;//RaiseException("service aborted");
                    }
                    break;
            }
            //no hit
            return false;//RaiseException("unknown exception");
        }
    }
}