using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UniversalControlSystem
{
    public class FlowCharCtron : TaskUnit
    {
        public static log4net.ILog logger;
        public List<ImageTool> tools /*= new List<ImageTool>()*/;
        public static Thread BIZZThread = null;
        private HiPerfTimer ctTimer;
        public string names = "";
        public int Step = 0;
        //private HiPerfTimer resetTimer;
        public FlowCharCtron(string name, TaskGroup taskGroup) : base(name, taskGroup)
        {
            ctTimer = new HiPerfTimer();
            names = name;
            tools = LoadData._ImageToolRun[names];


            var logCfg = new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + "Log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
            logger = log4net.LogManager.GetLogger("版本：" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());//获取一个日志记录器 
            logger.Info("---------------------------------");

        }
        public FlowCharCtron()
        {

        }
        bool currentRunStatus = false;

        DataGroup _DataGroup = null;
        public override void Process()
        {
            string Tepy = "";
            //流程开始
            if (!Program.bAuto || Program.bStop || Program.bEStop)
            { }
            else
            {
                try
                {
                    if (Step >= tools.Count)
                    {
                        Step = 0;//流程步骤号
                    }
                    else
                    {
                        currentRunStatus = false;
                        DateTime starttime = DateTime.Now;
                        //屏蔽光栅
                        if (tools[Step].GetType().Name == "Check_INPUT" && tools[Step].FlowChar_StepControlName == "光栅"
                            && Properties.Settings.Default.bGratingEStopDeal)
                        {
                            Step++;//屏蔽光栅跳转
                            return;
                        }
                        //屏蔽门禁
                        if (tools[Step].GetType().Name == "Check_INPUT" && tools[Step].FlowChar_StepControlName == "门禁"
                            && Properties.Settings.Default.bDoorOpenEStopDeal)
                        {
                            Step++;//屏蔽门禁跳转
                            return;
                        }
                        currentRunStatus = RunStep(Step, tools);//运行结果
                        Tepy = tools[Step].GetType().Name;
                        string StepControlName = tools[Step].FlowChar_StepControlName;//步骤名称
                        if (Tepy == "LogicalJump" && currentRunStatus == true)
                        {
                            LogicalJump LogicalJump = (LogicalJump)tools[Step];
                            Step = LogicalJump.FlowChar_StepControlLoop;
                            return;
                        }
                        else if (Tepy == "LogicalJump" && currentRunStatus == false)
                        {
                            Step++;
                            return;
                        }
                        #region              
                        if (Program.bAuto == true || Tepy == "DefintionFun")
                        {
                            if(Program.bAuto == false || Tepy == "DefintionFun")
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue("停止:" + names + "_Step:" + Tepy + "_" + Step.ToString() + "_" + StepControlName);
                            if (currentRunStatus == true)
                            {
                                Tepy = tools[Step].GetType().Name;
                                if (Tepy == "DataGroup")
                                {
                                    DateTime endtime = DateTime.Now;
                                    TimeSpan spantime = endtime - starttime;
                                    _DataGroup = (DataGroup)tools[Step];
                                    try
                                    {
                                        _DataGroup.FlowChar_StepControlTIME = Convert.ToDouble(spantime.TotalMilliseconds);
                                    }
                                    catch
                                    {
                                    }
                                }
                                if (Tepy == "LogicalJump")
                                {
                                    LogicalJump LogicalJump = (LogicalJump)tools[Step];
                                    Step = LogicalJump.FlowChar_StepControlLoop;
                                    Step++;
                                }

                                if (Tepy == "DefintionFun")
                                {
                                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue(names + "_Step:" + Tepy + "_" + Step.ToString() + "_" + StepControlName);
                                    Step++;
                                }
                                else
                                {
                                    DateTime endtime = DateTime.Now;
                                    TimeSpan spantime = endtime - starttime;
                                    try
                                    {
                                        tools[Step].FlowChar_StepControlTIME = Convert.ToDouble(spantime.TotalMilliseconds);
                                    }
                                    catch
                                    { }
                                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue(names + "_Step:" + Tepy + "_" + Step.ToString() + "_" + StepControlName + "_" + spantime.TotalMilliseconds.ToString());
                                    Step++;
                                }
                            }
                            else//运行返回结果不为0
                            {
                                DateTime endtime = DateTime.Now;
                                TimeSpan spantime = endtime - starttime;
                                Tepy = tools[Step].GetType().Name;

                                //计时
                                try
                                {
                                    tools[Step].FlowChar_StepControlTIME = Convert.ToDouble(spantime.TotalMilliseconds);
                                }
                                catch
                                { }

                                MainForm.m_formAlarm.InsertAlarmMessage(names + "_" + tools[Step].FlowChar_StepControlName + ":步骤报警;" + "步骤号:" + Step.ToString());
                                Weld_Log.Instance().Enqueue(names + "_" + tools[Step].FlowChar_StepControlName + ":步骤报警;" + "步骤号:" + Step.ToString());
                                Program.bStop = true;
                                Program.bAlarm = true;
                                Program.bAuto = false;
                                alm();
                            }
                        }
                        else
                        {
                            DateTime endtime = DateTime.Now;
                            TimeSpan spantime = endtime - starttime;
                            Tepy = tools[Step].GetType().Name;
                            Weld_Log.Instance().Enqueue("停止:" + names + "_" + Tepy + ":步骤报警;" + "步骤号:" + Step.ToString() + "_" + StepControlName + "_" + spantime.TotalMilliseconds.ToString());
                        }
                        #endregion                     
                    }
                }
                catch (Exception ex)
                {
                    Weld_Log.Instance().Enqueue(names + ":" + tools[Step].FlowChar_StepControlName.ToString() + ex.ToString());
                    Program.bAuto = false;
                    Program.bStop = true;
                    Program.bAlarm = true;
                    alm();
                }
            }
        }
        public override void OneProcess()
        {
            if (Program.bManul == false || Program.bAlarm || /*Program.bStop || Program.bEStop||*/ Program.boolDoorOpen || Program.Grating)
            {
            }
            else
            {
                try
                {
                    if (Step >= tools.Count)
                    {
                        // TaskRun.Instance().m_TaskGroup.OneRunSta = false;
                        Program.bManul = false;
                        Step = 0;
                    }
                    else
                    {
                        currentRunStatus = false;
                        currentRunStatus = RunStep(Step, tools);
                        if (tools[Step].FlowChar_StepControlLoop != -1 && currentRunStatus == false)
                        {
                            //  Step = tools[Step].FlowChar_StepControlLoop;
                        }
                        if (Program.bManul == true)
                        {
                            if (currentRunStatus == true)
                            {

                                string Tepy = tools[Step].GetType().Name;
                                if (Tepy == "DefintionFun")
                                {
                                    Step++;
                                }
                                else
                                {
                                    Weld_Log.Instance().Enqueue(names + "_Step:" + Tepy + "_" + Step.ToString());
                                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue(names + "_Step:" + Tepy + "_" + Step.ToString());
                                    Step++;
                                }

                            }
                            else
                            {
                                string Tepy = tools[Step].GetType().Name;
                                MainForm.m_formAlarm.InsertAlarmMessage(names + "_" + Tepy + ":步骤报警;" + "步骤号:" + Step.ToString());
                                Weld_Log.Instance().Enqueue(names + "_" + Tepy + ":步骤报警;" + "步骤号:" + Step.ToString());
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue(names + "_" + Tepy + ":步骤报警;" + "步骤号:" + Step.ToString());
                                //  Program.bManul = false;
                                Program.bStop = true;
                                Program.bAlarm = true;
                                alm();

                            }
                        }
                        else
                        {
                            Weld_Log.Instance().Enqueue("停止:" + Step.ToString());

                        }
                    }
                }
                catch
                {

                }
            }
        }
        //报警鸣叫
        public static void alm()
        {
            ManageContral.SetOutBit("三色灯黄", false);
            ManageContral.SetOutBit("三色灯红", true);
            ManageContral.SetOutBit("三色灯绿", false);
            if (BIZZThread == null)
            {
                BIZZThread = new Thread(BIZZRun);
                BIZZThread.Start();
                BIZZThread.IsBackground = true;
            }
        }

        //报警鸣叫
        public static void BIZZRun()
        {
            while (true)
            {
                if (Program.bAlarm && !Program.noBizz)
                {
                    ManageContral.SetOutBit("BIZZ", true);
                    Thread.Sleep(500);
                    ManageContral.SetOutBit("BIZZ", false);
                    Thread.Sleep(500);
                }
                else
                {
                    ManageContral.SetOutBit("BIZZ", false);
                    BIZZThread = null;
                    break;
                }
            }
            return;
        }

        public override void ClearStep()
        {
            Step = 0;
        }
        public bool CallSubroutineFun(CallSubroutine CallSubroutine)
        {
            bool currentRunSta = false;
            return true;
        }
        public bool RunStep(int Step, List<ImageTool> tools)
        {
            string Tepy = tools[Step].GetType().Name;
            //string ads=  Tepy.Name;
            //string Tepys = Tepy.;
            switch (Tepy)
            {
                case "OutPut":
                    OutPut _OutPut_Puse;
                    _OutPut_Puse = (OutPut)tools[Step];
                    if (_OutPut_Puse.OutSta == "true")
                    {
                        ManageContral.SetOutBit(_OutPut_Puse.IO_Name, true);
                    }
                    else
                    {
                        ManageContral.SetOutBit(_OutPut_Puse.IO_Name, false);
                    }
                    currentRunStatus = true;
                    break;
                case "OutPut_Puse":
                    currentRunStatus = true;
                    break;
                case "Check_INPUT":
                    Check_INPUT _Check_INPUT;
                    _Check_INPUT = (Check_INPUT)tools[Step];
                    if (_Check_INPUT.WaitINPut_Check(_Check_INPUT.IO_Name, _Check_INPUT.CheckIO_Sta, _Check_INPUT.Delay) == true)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    //_Check_INPUT.
                    break;
                case "DataGroup":
                    ///用于工位互锁及检测流程状态
                    DataGroup _DataGroup;
                    _DataGroup = (DataGroup)tools[Step];
                    while (true)
                    {
                        if (Program.bInt == true)
                        {
                            currentRunStatus = true;
                            break;

                        }
                        Thread.Sleep(50);
                        if (_DataGroup.
                            DataGroupFun(_DataGroup._DataGroup, _DataGroup.Data, _DataGroup.Choose) == true)
                        {
                            currentRunStatus = true;
                            break;
                        }
                        if (Program.bStop || Program.bEStop)
                        {
                            currentRunStatus = true;
                            break;
                        }
                    }
                    break;
                case "CodeEditTool":
                    CodeEditTool _CodeEditTool;
                    _CodeEditTool = (CodeEditTool)tools[Step];
                    break;
                case "BuildCor":
                    //BuildCor _BuildCor;
                    //_BuildCor = (BuildCor)tools[Step];
                    break;
                case "Aixs_one_Ctron":
                    Aixs_one_Ctron _Aixs_one_Ctron;
                    _Aixs_one_Ctron = (Aixs_one_Ctron)tools[Step];
                    _Aixs_one_Ctron.AxisPMoveAbsoluteToStop(_Aixs_one_Ctron.AixsName, _Aixs_one_Ctron.Pos, _Aixs_one_Ctron.Acc, _Aixs_one_Ctron.Dec, _Aixs_one_Ctron.Speed);
                    currentRunStatus = true;
                    break;
                case "CheckAixsRunFinish":
                    CheckAixsRunFinish _CheckAixsRunFinish;
                    _CheckAixsRunFinish = (CheckAixsRunFinish)tools[Step];
                    while (true)
                    {
                        if (Program.bInt == true)
                        {
                            currentRunStatus = true;
                            break;

                        }
                        Thread.Sleep(50);
                        if (_CheckAixsRunFinish.DetectingAxis(_CheckAixsRunFinish.AixsName) == 0)
                        {
                            currentRunStatus = true;
                            break;
                        }
                        if (Program.bStop || Program.bEStop)
                        {
                            currentRunStatus = true;
                            break;
                        }
                    }
                    break;
                case "Aixs_more_Ctron":
                    Aixs_more_Ctron _Aixs_more_Ctron;
                    _Aixs_more_Ctron = (Aixs_more_Ctron)tools[Step];
                    for (int i = 0; i < _Aixs_more_Ctron.Data.Count; i++)
                    {
                        _Aixs_more_Ctron.AxisPMoveAbsoluteToStop(_Aixs_more_Ctron.Data[i].AixsName, _Aixs_more_Ctron.Data[i].Pos, _Aixs_more_Ctron.Data[i].Acc, _Aixs_more_Ctron.Data[i].Dec, _Aixs_more_Ctron.Data[i].Speed);
                    }
                    currentRunStatus = true;
                    break;
                case "CamerCompensation_Center":
                    CamerCompensation_Center _CamerCompensation_Center;
                    _CamerCompensation_Center = (CamerCompensation_Center)tools[Step];
                    if (_CamerCompensation_Center.AxisPCamerCompensation(_CamerCompensation_Center) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "CamerGetR_Center":
                    CamerGetR_Center CamerGetR_Center;
                    CamerGetR_Center = (CamerGetR_Center)tools[Step];
                    if (CamerGetR_Center.GetR_C(CamerGetR_Center) != "")
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "DigitalMea_Height":
                    DigitalMea_Height DigitalMea_Height;
                    DigitalMea_Height = (DigitalMea_Height)tools[Step];
                    if (DigitalMea_Height.DigitalMea_Height_Fun(DigitalMea_Height) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }

                    break;
                case "AddOtherBuff":
                    AddOtherBuff AddOtherBuff;
                    AddOtherBuff = (AddOtherBuff)tools[Step];
                    if (AddOtherBuff.AddOtherBuffFun(AddOtherBuff) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;

                case "ArcXYC":
                    ArcXYC ArcXYC;
                    ArcXYC = (ArcXYC)tools[Step];
                    if (ArcXYC.GT_ArcXYC(ArcXYC) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "LnXY":
                    LnXY LnXY;
                    LnXY = (LnXY)tools[Step];
                    if (LnXY.GT_LnXY(LnXY) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "LnXYZ":
                    LnXYZ LnXYZ;
                    LnXYZ = (LnXYZ)tools[Step];
                    if (LnXYZ.GT_LnXYZ(LnXYZ) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "LnXYZA":
                    LnXYZA LnXYZA;
                    LnXYZA = (LnXYZA)tools[Step];
                    if (LnXYZA.GT_LnXYZA(LnXYZA) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "BufferArea":
                    BufferArea BufferArea;
                    BufferArea = (BufferArea)tools[Step];
                    if (BufferArea.RunFun(BufferArea) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "PYTool":
                    PYTool PYTool;
                    PYTool = (PYTool)tools[Step];
                    PYTool.RunPy(PYTool);
                    currentRunStatus = true;
                    break;
                case "CallSubroutine":
                    //CallSubroutine CallSubroutine;
                    //CallSubroutine = (CallSubroutine)tools[Step];
                    //if (CallSubroutine.RunFun(BufferArea) == 0)
                    //{
                    //    currentRunStatus = true;
                    //}
                    //else
                    //{
                    //    currentRunStatus = false;
                    //}
                    break;
                case "SerialPortSendData":
                    SerialPortSendData SerialPortSendData;
                    SerialPortSendData = (SerialPortSendData)tools[Step];
                    if (SerialPortSendData.SendData(SerialPortSendData) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "SerialPortResData":
                    SerialPortResData SerialPortResData;
                    SerialPortResData = (SerialPortResData)tools[Step];
                    if (SerialPortResData.ResData(SerialPortResData) != "")
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "_ser_clSendData":
                    _ser_clSendData _ser_clSendData;
                    _ser_clSendData = (_ser_clSendData)tools[Step];
                    if (_ser_clSendData.SendData(_ser_clSendData) == true)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "_ser_clResData":
                    _ser_clResData _ser_clResData;
                    _ser_clResData = (_ser_clResData)tools[Step];
                    if (_ser_clResData.ResData(_ser_clResData) != "")
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;

                case "DelayData":
                    DelayData DelayData;
                    DelayData = (DelayData)tools[Step];
                    if (DelayData.DelayFun(DelayData.Delay))
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "Cir":
                    Cir Cir;
                    Cir = (Cir)tools[Step];
                    if (Cir.CirRun(Cir) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "Dimetric":
                    Dimetric DimetricCir;
                    DimetricCir = (Dimetric)tools[Step];
                    if (DimetricCir.MoveRec(DimetricCir) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "Aixs_more_CtronRunFinish":
                    Aixs_more_CtronRunFinish Aixs_more_CtronRunFinish;
                    Aixs_more_CtronRunFinish = (Aixs_more_CtronRunFinish)tools[Step];
                    if (Aixs_more_CtronRunFinish.CheckFinish(Aixs_more_CtronRunFinish) == true)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "LogicalJump":
                    LogicalJump LogicalJump;
                    LogicalJump = (LogicalJump)tools[Step];
                    if (LogicalJump.LogicalJumpFun(LogicalJump) == true)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;

                case "Or":
                    Or Or;
                    Or = (Or)tools[Step];
                    if (Or.OrFun(Or) == true)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "Neg":
                    Neg Neg;
                    Neg = (Neg)tools[Step];
                    if (Neg.NegFun(Neg) == true)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "XOr":
                    XOr XOr;
                    XOr = (XOr)tools[Step];
                    if (XOr.XOrFun(XOr) == true)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "And":
                    And And;
                    And = (And)tools[Step];
                    if (And.AndFun(And) == true)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "DefintionFun":
                    DefintionFun DefintionFun;
                    DefintionFun = (DefintionFun)tools[Step];
                    if (DefintionFun.RunFun(DefintionFun) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "DefintionFun2":
                    DefintionFun2 DefintionFun2;
                    DefintionFun2 = (DefintionFun2)tools[Step];
                    if (DefintionFun2.RunFun(DefintionFun2) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "DefintionFun3":
                    DefintionFun3 DefintionFun3;
                    DefintionFun3 = (DefintionFun3)tools[Step];
                    if (DefintionFun3.RunFun(DefintionFun3) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
                case "DefintionFun4":
                    DefintionFun4 DefintionFun4;
                    DefintionFun4 = (DefintionFun4)tools[Step];
                    if (DefintionFun4.RunFun(DefintionFun4) == 0)
                    {
                        currentRunStatus = true;
                    }
                    else
                    {
                        currentRunStatus = false;
                    }
                    break;
            }
            return currentRunStatus;
        }
    }
    /// <summary>
    /// 数据
    /// </summary>
    public partial class FlowCharCtronDate
    {
        public List<_CtronDate> __CtronDate_List;
        [XmlIgnore]
        public Dictionary<string, _CtronDate> __CtronDate_Dictionary;
        public FlowCharCtronDate()
        {
            __CtronDate_List = new List<_CtronDate>();
            __CtronDate_Dictionary = new Dictionary<string, _CtronDate>();
        }
        public static FlowCharCtronDate LoadObj()
        {
            FlowCharCtronDate pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(FlowCharCtronDate));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//FlowChar/CtronDate" + ".xml");
                pDoc = (FlowCharCtronDate)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();
                //Properties.Settings.Default.iAxisCount = pDoc.mAisx_Hard_Date_List.Count;
                //Properties.Settings.Default.Save();
            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new FlowCharCtronDate();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//FlowChar/"))
            {
                Directory.CreateDirectory(@".//FlowChar/");
            }
            FileStream fsWriter = new FileStream(@".//FlowChar/CtronDate" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(FlowCharCtronDate));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();

            return true;
        }
    }
    public partial class _CtronDate
    {
        public string Group_ControlDataName { get; set; }
        public string Group_ControlDataTpye { get; set; }
        public string Group_ControlDataVender { get; set; }
        public object Date { get; set; }
    }

    public class TaskGroup
    {
        string strPath = "D:\\LogFile\\";
        public TasInfo m_tskFresh;
        public List<TaskUnit> listTask;
        public List<bool> bPreOnGoingList;
        private int m_iPeriod;
        private object lockObj = new object();
        private static TaskGroup _TaskGroup;
        public static TaskGroup Instance()
        {
            if (_TaskGroup == null)
            {
                _TaskGroup = new TaskGroup();
            }
            return _TaskGroup;
        }
        public TaskGroup()
        {
            m_tskFresh = new TasInfo();
            listTask = new List<TaskUnit>();
            bPreOnGoingList = new List<bool>();
        }

        public void ClearTaskUnit()
        {
            //if (SupplyThread!=null)
            //{
            //    SupplyThread.Abort();
            //}
            listTask.Clear();
            bPreOnGoingList.Clear();
        }
        public void AddTaskUnit(TaskUnit task)
        {
            listTask.Add(task);
            bPreOnGoingList.Add(false);
        }
        //public void InsertTaskUnit(int index,TaskUnit task)
        //{
        //    listTask.InsertRange(index, task);
        //    listTask.Add(task);
        //    bPreOnGoingList.Add(false);
        //}
        public Thread SupplyThread = null;
        public void StartThread()
        {
            //if (SupplyThread != null && SupplyThread.IsAlive == false)
            //{
            SupplyThread = new Thread(threadFunction);
            SupplyThread.Priority = ThreadPriority.Highest;
            SupplyThread.IsBackground = true;
            SupplyThread.Start();
            //}
            //else if (SupplyThread==null)
            //{
            //    SupplyThread = new Thread(threadFunction);
            //    SupplyThread.Priority = ThreadPriority.Highest;
            //    SupplyThread.IsBackground = true;
            //    SupplyThread.Start();
            //}
        }
        public void OneStartThread()
        {
            //if (SupplyThread != null && SupplyThread.IsAlive == false)
            //{
            SupplyThread = new Thread(OnethreadFunction);
            SupplyThread.Priority = ThreadPriority.Highest;
            SupplyThread.IsBackground = true;
            SupplyThread.Start();
            //}
            //else if (SupplyThread==null)
            //{
            //    SupplyThread = new Thread(threadFunction);
            //    SupplyThread.Priority = ThreadPriority.Highest;
            //    SupplyThread.IsBackground = true;
            //    SupplyThread.Start();
            //}
        }
        public void KillTherd()
        {
            //if (SupplyThread != null && SupplyThread.IsAlive == true)
            //{
            //    SupplyThread.Abort();
            //}
            //else if (SupplyThread != null && SupplyThread.IsAlive == false)
            //{
            //    SupplyThread.Abort();
            //}
        }
        public void StartThreadAlwayScan()
        {
            Thread SupplyThread = new Thread(threadFunctionAlwayScan);
            SupplyThread.IsBackground = true;
            SupplyThread.Start();
        }
        public void StartThread(int period)
        {
            m_iPeriod = period;
            Thread SupplyThread = new Thread(threadFunction);
            SupplyThread.IsBackground = true;
            SupplyThread.Start();
        }
        public void StartThreadAlwayScan(int period)
        {
            m_iPeriod = period;
            Thread SupplyThread = new Thread(threadFunctionAlwayScan);
            SupplyThread.IsBackground = true;
            SupplyThread.Start();
        }
        public bool RunSta = false;
        public bool OneRunSta = false;
        public bool ThendStop = false;
        private void OnethreadFunction()
        {
            Thread.Sleep(1000);
            //BarcodeDataManage.scannerDic["扫码枪"].RecieveMessageAction += RecieveMessage;
            try
            {
                int runCount = 0;
                while (OneRunSta)
                {
                    //if (Program.bInt == true)
                    //{
                    //    break;
                    //}
                    //ThendStop = true;
                    Thread.Sleep(1);
                    if (Program.bManul == false || Program.bStop || Program.bEStop || Program.boolDoorOpen || Program.Grating/*false*/|| Program.bAlarm)
                    {
                        //RunSta = false;
                        continue;
                    }
                    foreach (TaskUnit taskItem in listTask)
                    {
                        runCount++;
                        taskItem.OneProcess();
                        FlowCharCtron FlowCharCtron = (FlowCharCtron)listTask[0];
                        if (runCount >= FlowCharCtron.tools.Count)
                        {
                            Program.bManul = false;
                            OneRunSta = false;
                            break;
                        }
                        //for (int i = 0; i < FlowCharCtron.tools.Count; i++)
                        //{

                        //}
                    }
                }
                OneRunSta = false;
            }
            catch (Exception e)
            {
                OneRunSta = false;
                MessageBox.Show(e.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void threadFunction()
        {
            Thread.Sleep(1);
            try
            {
                while (RunSta)
                {
                    ThendStop = true;
                    Thread.Sleep(3);
                    if (!Program.bAuto || Program.bStop || Program.bEStop || Program.boolDoorOpen || Program.Grating/*false*/)
                    {
                        //RunSta = false;
                        continue;
                    }
                    foreach (TaskUnit taskItem in listTask)
                    {
                        taskItem.Process();
                    }
                }
                ThendStop = false;
            }
            catch (Exception e)
            {
                ThendStop = false;
                MessageBox.Show(e.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void _ClearStep()
        {
            foreach (TaskUnit taskItem in listTask)
            {
                taskItem.ClearStep();
            }
        }
        public void AddlistTask()
        {
            foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary)
            {
                try
                {
                    if (item.Value.配方是否为默认 == "默认")
                    {
                        TaskRun.Instance().m_TaskGroup.KillTherd();
                        TaskRun.Instance().m_TaskGroup.ClearTaskUnit();
                        LoadData.ReadData(Properties.Settings.Default.FlowRunPath);
                        foreach (var items in LoadData._ImageToolRun)
                        {
                            FlowCharCtron _FlowCharCtron = new FlowCharCtron(items.Key, TaskGroup.Instance()/* m_TaskGroup*/);
                            TaskRun.Instance().m_TaskGroup.AddTaskUnit(_FlowCharCtron);
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            }


        }
        private void threadFunctionAlwayScan()
        {
            Thread.Sleep(1000);

            while (true)
            {
                if (Program.bInt == true)
                {
                    break;
                }
                System.Threading.Thread.Sleep(m_iPeriod);
                foreach (TaskUnit taskItem in listTask)
                {
                    taskItem.Process();
                }

            }

        }
    }
    public class TasInfo
    {
        public int iTaskStep;
        public int iTaskAlarmStep;
        public string strTaskMes;
        public bool bTaskOnGoing;
        public bool bTaskAlarm;
        public bool bTaskFinish;
        public bool bStepOnGoing;
        public bool bNextStepAction;
        public HiPerfTimer htTimer;
        private TextBox m_txtBox;
        private string strPath = "";
        public string FilePath
        {
            get
            {
                return strPath;
            }
            set
            {
                try
                {
                    if (!Directory.Exists(value))
                    {
                        Directory.CreateDirectory(value);
                    }
                    strPath = value;
                }
                catch
                {
                    strPath = "";
                }

            }
        }
        public TasInfo()
        {
            iTaskStep = 0;
            iTaskAlarmStep = 0;
            strTaskMes = "";
            bTaskOnGoing = false;
            bTaskAlarm = false;
            bTaskFinish = false;
            htTimer = new HiPerfTimer();
        }
        public TasInfo(TextBox txtBox)
        {
            iTaskStep = 0;
            iTaskAlarmStep = 0;
            strTaskMes = "";
            bTaskOnGoing = false;
            bTaskAlarm = false;
            bTaskFinish = false;
            htTimer = new HiPerfTimer();
            m_txtBox = txtBox;
        }
    }



    public class TaskUnit
    {
        public TaskGroup m_taskGroup;
        public string strName;
        public TasInfo taskInfo;
        public HiPerfTimer m_taskTime;
        public bool m_manualStart = false;
        public TaskUnit(string name, TaskGroup taskGroup)
        {
            strName = name;
            m_taskGroup = taskGroup;
            taskInfo = new TasInfo();
            m_taskTime = new HiPerfTimer();
        }

        public TaskUnit()
        {
        }
        virtual public void Process()
        {
            //bool bAutoTrag = false;
            //bool bManualTrag = false;
            //bool bTragCondition = false;
            //bTragCondition = true;
            if (taskInfo.bTaskAlarm)
            {
                //if (Program.bResetPress)
                //{
                //    taskInfo.bTaskAlarm = false;
                //    m_taskTime.Start();
                //}
                return;
            }
            bool bAutoTrag = Program.bAuto;
            int count = 0;
            int idx = 0;
            RunFlowData _RunFlowData = null;
        }
        virtual public void OneProcess()
        {

            if (taskInfo.bTaskAlarm)
            {
                return;
            }

        }
        virtual public void ClearStep()
        { }
    }
}
