using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    [Serializable]
    public class CallSubroutine : ImageTool
    {
        //流程路径及名称
        public string _CallSubroutine { set; get; }
        public string _CallSub_Sta { set; get; }
        public bool _CallSub_RunSta { set; get; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroup { set; get; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroupName { set; get; }

    
        public bool RunFun(CallSubroutine CallSubroutine)
        {

            bool sta = false;         
            CallSubroutine.runTask(CallSubroutine._CallSubroutine);
            if (CallSubroutine._CallSub_Sta== "同步运行"&& CallSubroutine._CallSub_RunSta == false)
            {
                Thread.Sleep(100);
                sta = true;
                return sta;
            
                //while (true)
                //{
                //    if (Program.bInt == true)
                //    {
                //        return true;

                //    }
                //    if (CallSubroutine._CallSub_RunSta == true)
                //    {
                //        sta = true;
                //        break;
                //    }
                //}
            }
            if (CallSubroutine._CallSub_Sta == "等待运行完成" && CallSubroutine._CallSub_RunSta == false)
            {
                Thread.Sleep(100);
                while (true)
                {
                    if (Program.bInt == true)
                    {
                        return true;

                    }
                    if (CallSubroutine._CallSub_RunSta == true)
                    {
                        sta = true;
                        break;
                    }
                }
            }
            return sta;
        }
        private static HomeFlow _HomeFlow;
        public static HomeFlow Instance()
        {
            if (_HomeFlow == null)
            {
                _HomeFlow = new HomeFlow();
            }
            return _HomeFlow;
        }
        public string ReadstfPath = System.Environment.CurrentDirectory + "\\HomeFlow\\HomeFlow.csv";
        public List<KeyValuePair<string, KeyValuePair<string, string>>> RunItem_List = new List<KeyValuePair<string, KeyValuePair<string, string>>>();
        KeyValuePair<string, string> StepName = new KeyValuePair<string, string>();
        public bool RunClass_IsFinish = false;
        public Thread Run_OneCase = null;
        public int RunMark = 0;
        public void ReadCode(string path)// Read  code
        {
            List<string> ReadListStr = new List<string>();
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                ReadListStr.Add(line);
            }
            for (int i = 1; i < ReadListStr.Count; i++)
            {
                string[] Code = ReadListStr[i].Split(',');
                if (Code[0].Contains("轴运动"))
                {
                    RunItem_List.Add(new KeyValuePair<string, KeyValuePair<string, string>>(Code[0], new KeyValuePair<string, string>(Code[1], Code[2])));
                }
                else
                {
                    RunItem_List.Add(new KeyValuePair<string, KeyValuePair<string, string>>(Code[0], new KeyValuePair<string, string>(Code[1], Code[2])));
                }
            }
        }

        public void runTask(string path)
        {
            RunClass_IsFinish = false;
            // bool runFinish = false;
            RunItem_List.Clear();
            ReadCode(path);// Read  code

            Run_OneCase = new Thread(Run);
            Run_OneCase.IsBackground = true;
            Run_OneCase.Start();
          
        }

        public bool parse = false;//暂停标志位
        public bool GoOnRun = false;//继续运行标志位
        public bool StartRun = false;
        public void Run()
        {
            //波形展示.Instance().curveGraph1.Clean();
            StartRun = true;
            GoOnRun = false;//继续运行标志位     
            RunClass_IsFinish = false;
            RunClass_IsFinish = false;
            _CallSub_RunSta = false;
            for (int i = 0; i < RunItem_List.Count; i++)
            {
                RunMark = i;
                while (true)
                {
                    if (Program.bStop == true)
                    {
                        i = 2000;
                        GoOnRun = false;
                        parse = false;//运动超时报警
                        break;
                    }
                    if (Program.bEStop == true)
                    {
                        i = 2000;
                        GoOnRun = false;
                        parse = false;//运动超时报警
                        break;
                    }
                    if (parse == true)//暂停标志位
                    {
                        if (GoOnRun == true)//继续运行标志位
                        {
                            parse = false;
                            GoOnRun = false;//继续运行标志位
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
               if (Program.bInt == true)
               {
                    break;
                }
                if (Program.bEStop == false && Program.bStop == false)
                {
                    string RunStep = RunItem_List[i].Key;
                    StepName = RunItem_List[i].Value;
                    if (Program.bStop == true)
                    {
                        GoOnRun = false;
                        parse = false;//运动超时报警
                        break;
                    }
                    if (Program.bEStop == true)
                    {
                        GoOnRun = false;
                        parse = false;//运动超时报警

                        break;
                    }
                    bool currentRunStatus = Run_Switch(RunStep, StepName.Key, StepName.Value);
                    if (currentRunStatus == false)
                    {
                        parse = true;//运动超时报警
                        BIZZ(RunStep, StepName.Key, StepName.Value);
                        i = i - 1;
                    }
                    else
                    {
                        //   break;
                    }

                }
            }
            RunClass_IsFinish = true;
            StartRun = false;
            _CallSub_RunSta = true;
            Run_OneCase = null;
            Run_OneCase.Abort();
        }
        public void BIZZ(string NAME, string ERR, string value)
        {
            DialogResult DResult = MessageBox.Show("步骤报警", NAME + ":" + ERR + ":" + value, MessageBoxButtons.YesNo);
            if (DResult == DialogResult.No)
            {
                GoOnRun = true;
            }
            else
            {
                GoOnRun = true;
            }
        }
        public bool Run_Switch(string str, string str1, string CheckSta)
        {
            DateTime starttime = DateTime.Now;
            DateTime endtime = DateTime.Now;
            bool currentRunStatus = false;
            int delayCheckTime = 0;
            switch (str)
            {
                case "延时":
                    try
                    {
                        int Time = int.Parse(CheckSta.Replace(" ", ""));
                        currentRunStatus = Delay(Time);
                    }
                    catch
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "IO检测":
                    delayCheckTime = 6000;
                    currentRunStatus = WaitINPut_Check(str1, CheckSta, delayCheckTime);//检测一个输入               
                    break;
                case "IO检测等待":
                    delayCheckTime = 60000000;
                    currentRunStatus = WaitINPut_Check(str1, CheckSta, delayCheckTime);//检测一个输入               
                    break;
                case "IO输出":
                    currentRunStatus = OutPut_One_Run(str1, CheckSta);//一个输出
                    break;
                case "单轴运动":
                    delayCheckTime = 20000;
                    currentRunStatus = Asix_one_Run(str1, CheckSta, delayCheckTime);
                    break;
                case "轴回原":
                    currentRunStatus = GoHOME(str1, CheckSta);
                    break;
                case "检测原点状态":
                    delayCheckTime = 6000;
                    currentRunStatus = CheckHOME(str1);
                    break;
                case "发送偏距":
                    currentRunStatus = true;
                    string[] OFFSET = CheckSta.Split(';');
                    string XX = OFFSET[0];
                    string YY = OFFSET[1];
                    string SendDate = "Offset;" + XX + ";" + YY + ";" + "0;";
                    //
                    break;

                case "光闸校验":
                    delayCheckTime = 6000;
                    Weld_Log.Instance().Enqueue( "[光闸校验]");
                    break;
                case "扫码":
                    string value = "T";
                    int Res = -1;
                    SerialPortCom SerialPort = null;
                    string[] Str = CheckSta.Split(';');
                    string name = Str[0];
                    string sendStr = Str[1];
                    string Rec_ERROR = Str[2];
                    SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[name];
                    //string ResData = "";
                    if (SerialPort.Open() == true)
                    {
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    bool sendF = SerialPort.Send(sendStr);
                    if (sendF == true)
                    {
                        Res = 0;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    DateTime starttime扫码 = DateTime.Now;
                    while (true)
                    {
                        if (Program.bInt == true)
                        {
                            return true;
                        }
                        DateTime endtime扫码 = DateTime.Now;
                        TimeSpan spantime = endtime - starttime;   
                        if (value != "" && !value.Contains(Rec_ERROR))
                        {
                            Weld_Log.Instance().Enqueue("[扫码]:" + value);
                            currentRunStatus = true;
                            mes.Instance().DataReceivedstrSN = value;
                            break;
                        }
                        else
                        {
                            Weld_Log.Instance().Enqueue("[扫码]:扫码失败");
                            currentRunStatus = false;
                        }
                        if (spantime.TotalMilliseconds > 3000)
                        {
                            currentRunStatus = true;
                            break;
                        }
                        if (Program.bEStop == true)
                        {
                            currentRunStatus = true;
                            break;
                        }
                        if (Program.bStop == true)
                        {
                            currentRunStatus = true;
                            break;
                        }
                    }
                    break;
                case "插入数据库":
                    if (str1=="左工位")
                    {
                        string str2 = "SELECT * FROM L_Clear_Data";
                        List<string> pword = SQLiteConnect._getQuery(str2, "SN");
                    }
                    else if (str1 == "右工位")
                    {
                        string str2 = "SELECT * FROM R_Clear_Data";
                        List<string> pword = SQLiteConnect._getQuery(str2, "SN");
                    }
                    break;
                case "删除数据库记录":
                    if (str1 == "左工位")
                    {

                    }
                    else if (str1 == "右工位")
                    {

                    }
                    break;
                case "取数据库SN":
                    if (str1 == "左工位")
                    {

                    }
                    else if (str1 == "右工位")
                    {

                    }
                    break;
                case "MES过站验证":
                    //string ds1 = mes.Instance().DataReceivedstrSN;
                    //string res1 = mesIsOk(ds1);
                    //if (res1 == "OK")
                    //{
                    //    Weld_Log.Instance().Enqueue( "[扫码]:验证成功:" + ds1);
                    //    currentRunStatus = true;
                    //}
                    //else
                    //{
                    //    Weld_Log.Instance().Enqueue("[扫码]:验证失败:" + ds1 + res1);
                    //    currentRunStatus = false;
                    //}
                    break;
                case "MES获取SN":
                    //string ds = mes.Instance().DataReceivedstrSN;
                    //mes.Instance().DataReceivedstrSN = GetSN(mes.Instance().DataReceivedstrSN.Replace("\r\n", ""));
                    //string ds12 = mes.Instance().DataReceivedstrSN;
                    //bool rt = DateSave.Instance().Production.GetSNLength.Contains(ds12.Length.ToString());
                    //if (ds12 != "" && !ds12.Contains("FAIL") && rt)
                    //{
                    //    Weld_Log.Instance().Enqueue( "[MES获取SN]:MES获取SN成功:" + ds12);
                    //    currentRunStatus = true;
                    //}
                    //else
                    //{
                    //    Weld_Log.Instance().Enqueue( "[MES获取SN]:MES获取SN失败:" + ds12);
                    //    currentRunStatus = false;
                    //}
                    break;
                case "MES条码获取":
                  //  mes.Instance().DataReceivedstrSN = Program.stratForm.form.手动过MES_Sn.Text;
                    if (mes.Instance().DataReceivedstrSN != "")
                    {
                        Weld_Log.Instance().Enqueue( "[MES条码获取]:MES条码获取成功");
                        currentRunStatus = true;
                    }
                    else
                    {
                        Weld_Log.Instance().Enqueue( "[MES条码获取]:MES条码获取失败,结果：" + mes.Instance().DataReceivedstrSN);
                        currentRunStatus = false;
                    }
                    break;
                case "MES上传":
                    //string result = "";
                    //string ds2 = mes.Instance().DataReceivedstrSN;
                    //CreatDir();

                    //result = OfflineUploadData(ds2, 9);
                    //if (result.ToUpper() == "OK")
                    //{
                    //    Weld_Log.Instance().Enqueue(LOG_LEVEL.LEVEL_3, "[MES上传]:MES上传成功");
                    //    currentRunStatus = true;
                    //}
                    //else
                    //{
                    //    Weld_Log.Instance().Enqueue(LOG_LEVEL.LEVEL_3, "[MES上传]:MES上传失败,结果：" + result);
                    //    currentRunStatus = false;
                    //}
                    break;


            }
            return currentRunStatus;
        }


        public bool Delay(int stime)    //
        {
            bool sta = false;
            DateTime starttime = DateTime.Now;
            while (true)
            {
                DateTime endtime = DateTime.Now;
                TimeSpan spantime = endtime - starttime;
                if (spantime.TotalMilliseconds > stime)
                {
                    sta = true;
                    break;
                }
                if (Program.bEStop == true)
                {
                    sta = true;
                    break;
                }
                if (Program.bStop == true)
                {
                    sta = true;
                    break;
                }
            }
            return sta;
        }
        public bool WaitINPut_Check(string IONum, string CheckSta, int stime)    //一个检测
        {
            bool sta = false;
            DateTime starttime = DateTime.Now;
            while (true)
            {
                DateTime endtime = DateTime.Now;
                TimeSpan spantime = endtime - starttime;
                if (ManageContral.GetInOn("移栽2气缸上") == true && CheckSta.ToLower() == "true")
                {
                    sta = true;
                    break;
                }
                if (ManageContral.GetInOn("移栽2气缸上") == false && CheckSta.ToLower() == "false")
                {
                    sta = true;
                    break;
                }
                if (spantime.TotalMilliseconds > stime)
                {
                    sta = false;
                    break;
                }
                if (Program.bEStop == true)
                {
                    sta = true;
                    break;
                }
                if (Program.bStop == true)
                {
                    sta = true;
                    break;
                }
            }
            return sta;
        }
        public bool OutPut_One_Run(string str, string sta)//一个输出
        {
            if (sta.ToLower() == "true")
            {
                ManageContral.SetOutBit(str, true);
            }
            else
            {
                ManageContral.SetOutBit(str, true);
            }
            return true;
        }
        public bool Asix_one_Run(string AsixName, string Position, int stime)
        {
            bool sta = false;
            DateTime starttime = DateTime.Now;
            int _Position = int.Parse(Position);
            ManageContral.AxisPMoveAbsoluteToStop(AsixName, _Position);
            while (true)
            {
                DateTime endtime = DateTime.Now;
                TimeSpan spantime = endtime - starttime;
                if (ManageContral.DetectingAxis(AsixName) == 0)
                {
                    sta = true;
                    break;
                }
                if (spantime.TotalMilliseconds > stime)
                {
                    sta = false;
                    break;
                }
                if (Program.bEStop == true)
                {
                    sta = true;
                    break;
                }
                if (Program.bStop == true)
                {
                    sta = true;
                    break;
                }
            }
            return sta;
        }
        public bool GoHOME(string AxisName, string checkSta)
        {
            DateTime starttime = DateTime.Now;
            bool sta = false;
            ManageContral.GO_Home(AxisName);
            int stime = 1000000;
            if (checkSta == "检测")
            {
                while (true)
                {
                    DateTime endtime = DateTime.Now;
                    TimeSpan spantime = endtime - starttime;
                    if (ManageContral.DetectingAxis(AxisName) == 0)
                    {
                        sta = true;
                        break;
                    }
                    if (spantime.TotalMilliseconds > stime)
                    {
                        sta = false;
                        break;
                    }
                    if (Program.bEStop == true)
                    {
                        sta = true;
                        break;
                    }
                    if (Program.bStop == true)
                    {
                        sta = true;
                        break;
                    }
                }
            }
            else
            {
                sta = true;
            }
            return sta;
        }
        public bool CheckHOME(string AxisName)
        {
            DateTime starttime = DateTime.Now;
            bool sta = false;
            int stime = 1000000;
            while (true)
            {
                int lGpiValueHome;
                int m_CardNo = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[AxisName].m_CardNo;
                int m_AxisNo = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[AxisName].m_AxisNo;
                short sRtn = gts.mc.GT_GetDi((short)m_CardNo, gts.mc.MC_HOME, out lGpiValueHome);//
                bool HOMEsta = Get_Org_Sta(m_AxisNo, lGpiValueHome);
                DateTime endtime = DateTime.Now;
                TimeSpan spantime = endtime - starttime;
                if (HOMEsta == true)
                {
                    sta = true;
                    break;
                }
                if (spantime.TotalMilliseconds > stime)
                {
                    sta = false;
                    break;
                }
                if (Program.bEStop == true)
                {
                    sta = true;
                    break;
                }
                if (Program.bStop == true)
                {
                    sta = true;
                    break;
                }
            }
            return sta;
        }
        public bool Get_Org_Sta(int m_AxisNo, int lGpiValueHome)
        {
            bool bOrg = false;
            if (m_AxisNo == 0)
            {
                if ((lGpiValueHome & 0x1) != 0)
                {
                    bOrg = true;
                }
                else
                {
                    bOrg = false;
                }
            }

            if (m_AxisNo == 1)
            {
                if ((lGpiValueHome & 0x2) != 0)
                {
                    bOrg = true;
                }
                else
                {
                    bOrg = false;
                }
            }
            if (m_AxisNo == 2)
            {
                if ((lGpiValueHome & 0x4) != 0)
                {
                    bOrg = true;
                }
                else
                {
                    bOrg = false;
                }
            }
            if (m_AxisNo == 3)
            {
                if ((lGpiValueHome & 0x8) != 0)
                {
                    bOrg = true;
                }
                else
                {
                    bOrg = false;
                }
            }
            if (m_AxisNo == 4)
            {
                if ((lGpiValueHome & 0x10) != 0)
                {
                    bOrg = true;
                }
                else
                {
                    bOrg = false;
                }
            }
            if (m_AxisNo == 5)
            {
                if ((lGpiValueHome & 0x20) != 0)
                {
                    bOrg = true;
                }
                else
                {
                    bOrg = false;
                }
            }
            if (m_AxisNo == 6)
            {
                if ((lGpiValueHome & 0x40) != 0)
                {
                    bOrg = true;
                }
                else
                {
                    bOrg = false;
                }
            }
            if (m_AxisNo == 7)
            {
                if ((lGpiValueHome & 0x80) != 0)
                {
                    bOrg = true;
                }
                else
                {
                    bOrg = false;
                }
            }

            if (m_AxisNo == 8)
            {
                if ((lGpiValueHome & 0x1) != 0)
                {
                    bOrg = true;
                }
                else
                {
                    bOrg = false;
                }
            }
            return bOrg;
        }

    }
}
