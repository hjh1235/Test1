using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using UniversalControlSystem;

namespace UniversalControlSystem
{
    public enum HomeStep : byte
    {
        Idle = 0,
        HomeStart = 1,//2  0
        HomeDone = 2,//4  1
        HomeReset = 3,
        HomeOthers = 4,
        HomeCheck = 5,
    }
    public enum Init
    {
        等待初始化信号,
        回原点,
        初始化
    }
    public partial class FormStart : Form
    {
        #region 声明变量
        public static string sSelectTask = "";
        MainForm mainForm;
        OperateDirectionsForm m_operateDirectionsForm = new OperateDirectionsForm();
        LaserContorlForm m_LaserContorlForm = new LaserContorlForm();
        MESSettingForm m_MESSettingForm = new MESSettingForm();
        PointSetting_Form _PointSetting_Form = new PointSetting_Form();
        CheckData CheckD = null;
        数据库 _数据库 = new 数据库();
        private bool bAxisStateFormHide = false;
        private bool bAxisControlFromHide = false;
        private bool bLaserContorlFormHide = false;
        private bool bLaserPowerViewFormHide = false;
        public static bool bPointSettingHide = false;
        private bool bMESSetFormHide = false;
        public static bool startHoming = false;
        public static bool bAllAxisHomed = false;
        public static bool bAutoInit = false;
        public string stfPath = System.Environment.CurrentDirectory + "\\xml";
        public static int[] iStep;
        public static int[] iRightStep;
        //public static FormAlarm m_FormAlarm;
        private HiPerfTimer hiPerfTimer;
        IODebugForm m_IODebugForm = new IODebugForm();
        //RunClass runClass = new RunClass();
        HomeStep homeStep = new HomeStep();
        /// <summary>
        /// 初始化信号互锁变量
        /// </summary>
        private bool boolInit = false;
        private Init strInit = new Init();
        public static Dictionary<string, Weld_Log> LOG_ShowFrom = new Dictionary<string, Weld_Log>();
        Parameter Parameter = new Parameter();
        private bool bParameterFormHide = false;
        DemarcateForm DemarcateForm = new DemarcateForm();
        private bool bDemarcateFormHide = false;
        private HiPerfTimer resetTimer;
        public static HiPerfTimer leftTimer = new HiPerfTimer();
        public static HiPerfTimer rightTimer = new HiPerfTimer();
        public static bool ifFirstWeld = false;//是否首件
        public static string firstWeldPosition = "";//首件位置
        public static object ccdLock = new object();
        public static EzdKernel.E3_ID idMarker = new EzdKernel.E3_ID(1);
        public static bool bExamineFormHide = false;
        ExamineForm Examine = new ExamineForm();
        #endregion
        /// <summary>
        /// 自定义多流程集合
        /// </summary>
        public static List<TaskGroup> _TaskGroupList = new List<TaskGroup>();
        #region 构造函数
        public FormStart()
        {
            InitializeComponent();
        }
        public FormStart(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
            hiPerfTimer = new HiPerfTimer();
        }
        #endregion

        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormStart_Load(object sender, EventArgs e)
        {
            //Thread Card = new Thread(card.card0);
            //Card.IsBackground = true;
            //Card.Start();


            buttonStart.BackColor = Color.Aqua;
            InfoTask();
            Thread GoHomeThread = new Thread(HomeThread);
            GoHomeThread.IsBackground = true;
            GoHomeThread.Start();
            ManageContral.SetOutBit("三色灯绿", false);
            ManageContral.SetOutBit("三色灯黄", true);
            ManageContral.SetOutBit("三色灯红", false);
            ManageContral.SetOutBit("光栅屏蔽信号", false);
            //注册监听
            Weld_Log _SystemWeld_Log = new Weld_Log("系统LOG");
            _SystemWeld_Log.Level_Log_CallBack += Level_Log_CallBack;
            LOG_ShowFrom.Add("系统LOG", _SystemWeld_Log);
            //LoadData._ImageToolRun = LoadData.ReadData(Properties.Settings.Default.FlowRunPath);
            resetTimer = new HiPerfTimer();
            Properties.Settings.Default.chooseAisx = true;
            Properties.Settings.Default.回原选择 = true;
            checkBox_Shoujian.Checked = false;
            Properties.Settings.Default.首件 = false;
            Properties.Settings.Default.Save();


           //日志按钮
           tab_LogShow();
            SystemSettings.showLog += (p1, p2) =>
            {
                this.Invoke(new Action(() =>
                {
                    if (p1 == 1)
                    {
                        tab_LogShow();
                    }
                }));
            };
        }
        /// <summary>
        /// 日志监听方法
        /// </summary>
        /// <param name="callBackStr"></param>
        private void Level_Log_CallBack(string callBackStr, string name)
        {
            switch (name)
            {
                case "系统LOG":
                    try
                    {
                        var rb1 = tab_logTab.Controls.Find("richTxtLog", true);
                        RichTextBox rtb1 = (RichTextBox)rb1[0];
                        rtb1.Invoke(new MethodInvoker(delegate
                        {
                            rtb1.AppendText(callBackStr + "\r\n");
                            rtb1.ScrollToCaret();
                            if (rtb1.Text.Length > rtb1.MaxLength)
                            {
                                rtb1.Text = "";
                            }
                        }));
                        foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary)
                        {
                            try
                            {
                                if (item.Value.配方是否为默认 == "默认")
                                {
                                    foreach (var item1 in item.Value.ListFlowData)
                                    {
                                        if (callBackStr.Contains(item1.RunFlowData_ControlDataName))
                                        {
                                            var rb = tab_logTab.Controls.Find($"log_richTextBox{item1.RunFlowData_ControlDataName}", true);
                                            RichTextBox rtb = (RichTextBox)rb[0];
                                            rtb.Invoke(new MethodInvoker(delegate
                                            {
                                                rtb.AppendText(callBackStr + "\r\n");
                                                rtb.ScrollToCaret();
                                                if (rtb.Lines.Length > 2000)
                                                {
                                                    rtb.Text = "";
                                                }
                                            }));
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Weld_Log.Instance().Enqueue(ex.ToString());
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("日志显示异常，请检查默认流程！" + e.ToString());
                    }
                    break;

                case "上料工位":
                    //try
                    //{
                    //    料仓位TextBox.Invoke(new MethodInvoker(delegate
                    //    {
                    //        料仓位TextBox.Text = 料仓位TextBox.Text + callBackStr + "\r\n";
                    //        料仓位TextBox.Focus();
                    //        料仓位TextBox.Select(料仓位TextBox.TextLength, 0);
                    //        料仓位TextBox.ScrollToCaret();
                    //        if (料仓位TextBox.Lines.Length > 1000)
                    //        {
                    //            料仓位TextBox.Text = "";
                    //        }
                    //    }));
                    //}
                    //catch (Exception e)
                    //{
                    //    MessageBox.Show("ATSLOG  " + e.ToString());
                    //}
                    break;
                case "上纸工位":
                    //try
                    //{
                    //    上纸位richTextBox.Invoke(new MethodInvoker(delegate
                    //    {
                    //        上纸位richTextBox.Text = 上纸位richTextBox.Text + callBackStr + "\r\n";
                    //        上纸位richTextBox.Focus();
                    //        上纸位richTextBox.Select(上纸位richTextBox.TextLength, 0);
                    //        上纸位richTextBox.ScrollToCaret();
                    //        if (上纸位richTextBox.Lines.Length > 1000)
                    //        {
                    //            上纸位richTextBox.Text = "";
                    //        }
                    //    }));
                    //}
                    //catch (Exception e)
                    //{
                    //    MessageBox.Show("ATSLOG  " + e.ToString());
                    //}
                    break;

                case "取料工位步骤":
                    //try
                    //{
                    //    上料工位richTextBox.Invoke(new MethodInvoker(delegate
                    //    {
                    //        上料工位richTextBox.Text = 上料工位richTextBox.Text + callBackStr + "\r\n";
                    //        上料工位richTextBox.Focus();
                    //        上料工位richTextBox.Select(上料工位richTextBox.TextLength, 0);
                    //        上料工位richTextBox.ScrollToCaret();
                    //        if (上料工位richTextBox.Lines.Length > 1000)
                    //        {
                    //            上料工位richTextBox.Text = "";
                    //        }
                    //    }));
                    //}
                    //catch (Exception e)
                    //{
                    //    MessageBox.Show("ATSLOG  " + e.ToString());
                    //}
                    break;
                case "CCDTaska_左":
                    //try
                    //{
                    //    CCD_ArichTextBox.Invoke(new MethodInvoker(delegate
                    //    {
                    //        CCD_ArichTextBox.Text = CCD_ArichTextBox.Text + callBackStr + "\r\n";
                    //        CCD_ArichTextBox.Focus();
                    //        CCD_ArichTextBox.Select(CCD_ArichTextBox.TextLength, 0);
                    //        CCD_ArichTextBox.ScrollToCaret();
                    //        if (CCD_ArichTextBox.Lines.Length > 1000)
                    //        {
                    //            CCD_ArichTextBox.Text = "";
                    //        }
                    //    }));
                    //}
                    //catch (Exception e)
                    //{
                    //    MessageBox.Show("ATSLOG  " + e.ToString());
                    //}
                    break;
                case "CCDTaska_右":
                    //try
                    //{
                    //    CCD_BrichTextBox.Invoke(new MethodInvoker(delegate
                    //    {
                    //        CCD_BrichTextBox.Text = CCD_BrichTextBox.Text + callBackStr + "\r\n";
                    //        CCD_BrichTextBox.Focus();
                    //        CCD_BrichTextBox.Select(CCD_BrichTextBox.TextLength, 0);
                    //        CCD_BrichTextBox.ScrollToCaret();
                    //        if (CCD_BrichTextBox.Lines.Length > 1000)
                    //        {
                    //            CCD_BrichTextBox.Text = "";
                    //        }
                    //    }));
                    //}
                    //catch (Exception e)
                    //{
                    //    MessageBox.Show("ATSLOG  " + e.ToString());
                    //}
                    break;

                case "下料中转搬运":
                    //try
                    //{

                    //    右底部中转工位richTextBox.Invoke(new MethodInvoker(delegate
                    //    {
                    //        右底部中转工位richTextBox.Text = 右底部中转工位richTextBox.Text + callBackStr + "\r\n";
                    //        右底部中转工位richTextBox.Focus();
                    //        右底部中转工位richTextBox.Select(右底部中转工位richTextBox.TextLength, 0);
                    //        右底部中转工位richTextBox.ScrollToCaret();
                    //        if (右底部中转工位richTextBox.Lines.Length > 1000)
                    //        {
                    //            右底部中转工位richTextBox.Text = "";
                    //        }
                    //    }));
                    //}
                    //catch (Exception e)
                    //{
                    //    MessageBox.Show("ATSLOG  " + e.ToString());
                    //}
                    break;
                case "下料"://下料工位
                    //try
                    //{
                    //    下料工位richTextBox.Invoke(new MethodInvoker(delegate
                    //    {
                    //        下料工位richTextBox.Text = 下料工位richTextBox.Text + callBackStr + "\r\n";
                    //        下料工位richTextBox.Focus();
                    //        下料工位richTextBox.Select(下料工位richTextBox.TextLength, 0);
                    //        下料工位richTextBox.ScrollToCaret();
                    //        if (下料工位richTextBox.Lines.Length > 1000)
                    //        {
                    //            下料工位richTextBox.Text = "";
                    //        }
                    //    }));
                    //}
                    //catch (Exception e)
                    //{
                    //    MessageBox.Show("ATSLOG  " + e.ToString());
                    //}
                    break;
                case "分堆XYZ及皮带"://分堆XYzZ
                    //try
                    //{
                    //    分堆XYZrichTextBox1.Invoke(new MethodInvoker(delegate
                    //    {
                    //        分堆XYZrichTextBox1.Text = 分堆XYZrichTextBox1.Text + callBackStr + "\r\n";
                    //        分堆XYZrichTextBox1.Focus();
                    //        分堆XYZrichTextBox1.Select(分堆XYZrichTextBox1.TextLength, 0);
                    //        分堆XYZrichTextBox1.ScrollToCaret();
                    //        if (分堆XYZrichTextBox1.Lines.Length > 1000)
                    //        {
                    //            分堆XYZrichTextBox1.Text = "";
                    //        }
                    //    }));
                    //}
                    //catch (Exception e)
                    //{
                    //    MessageBox.Show("ATSLOG  " + e.ToString());
                    //}
                    break;
                default:
                    break;
            }

        }
        #region 流程配置
        /// <summary>
        /// 所有流程文件加载
        /// </summary>
        public void InfoTask()
        {

        }

        #endregion
        /// <summary>
        /// 主界面左菜单栏鼠标移走事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statusStrip2_MouseLeave(object sender, EventArgs e)
        {
            statusStrip2.Hide();
            timer1.Enabled = true;
        }
        bool asa = false;
        bool setOk = false;
        int Asix_Num = 0;
        //int i = 0;
        /// <summary>
        /// 计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region 工位流程步骤显示
            if (Program.bAuto)
            {
                lb_LeftStation.BackColor = Color.Green;
                lb_LeftStation.Text = "自动中";
            }
            else
            {
                lb_LeftStation.BackColor = Color.Yellow;
                lb_LeftStation.Text = "空闲中";
            }
            #endregion
            #region 按钮变化和三色灯变化
            if (Program.bStop)
            {
                buttonStop.BackColor = Color.Red;
                buttonStart.BackColor = Color.Aqua;
            }
            else
            {
                buttonStop.BackColor = Color.Yellow;
            }
            if (Program.bEStop)
            {
                buttonStop.BackColor = Color.Red;
                buttonStart.BackColor = Color.Aqua;
                btnInit.BackColor = Color.Aqua;
                btn_GoHome.BackColor = Color.Aqua;
            }
            else
            {
            }
            #endregion
            #region Start
            try
            {
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["Start"].bBitInputStatus == false)
                {
                    asa = true;
                }
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["Start"].bBitInputStatus && asa == true)
                {
                    if (Program.bManul == false)
                    {
                    }
                    else
                    {
                        return;
                    }
                    if (Program.bAuto == true)
                    {
                        return;
                    }
                    else
                    {
                        if (Properties.Settings.Default.流程更改标志 == true)
                        {
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue("流程已更改，请初始化。");
                            MainForm.m_formAlarm.InsertAlarmMessage("流程已更改，请初始化。");
                            return;
                        }
                        if (TaskRun.Instance().m_TaskGroup.OneRunSta == true)
                        {
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue("单动流程未停止");
                            MainForm.m_formAlarm.InsertAlarmMessage("单动流程未停止");
                            return;
                        }

                        if (!bAllAxisHomed)
                        {
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue(ERecvResult.设备未回原点.ToString());
                            MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.设备未回原点.ToString());
                            return;
                        }
                        if (!bAutoInit)
                        {
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue(ERecvResult.设备未初始化.ToString());
                            MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.设备未初始化.ToString());
                            return;
                        }
                        asa = false;
                        AutoStart();
                        FormStart.LOG_ShowFrom["系统LOG"].Enqueue("程序开始自动运行");
                        Weld_Log.Instance().Enqueue("程序开始自动运行");
                    }

                }
            }
            catch (Exception ex)
            {

            }
            #endregion
            #region Stop
            try
            {
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["Stop"].bBitInputStatus == true)
                {
                    AutoStop();
                }
            }
            catch (Exception)
            {
            }
            #endregion

            #region Reset
            try
            {
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["Reset"].bBitInputStatus)
                {
                    buttonReset_Click(sender, e);
                }
            }
            catch (Exception)
            { }
            #endregion

            #region EStop
            try
            {
                if (!Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["EStop"].bBitInputStatus)
                {
                    ManageContral.SetOutBit("三色灯绿", false);
                    ManageContral.SetOutBit("三色灯黄", false);
                    ManageContral.SetOutBit("三色灯红", true);
                    Program.bEStop = true;
                    Program.bStop = true;
                    Program.bAuto = false;
                    Program.bESTOPAlarm = true;
                    Program.bAlarm = true;
                    FlowCharCtron.alm();//报警
                    FormStart.startHoming = false;
                    FormStart.bAllAxisHomed = false;
                    FormStart.bAutoInit = false;
                    foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                    {
                        ManageContral.StopAxis(item.Key);
                        item.Value.AisxCurrentPosition = 0;
                        item.Value.bFlagServoOn = false;
                        gts.mc.GT_AxisOff((short)item.Value.m_CardNo, (short)(item.Value.m_AxisNo + 1));
                    }
                    try
                    {
                        foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
                        {
                            if (item.Value.Group_ControlDataTpye == "BOOL")
                            {
                                item.Value.Date = false;
                            }
                            else if (item.Value.Group_ControlDataTpye == "STRING")
                            {
                                item.Value.Date = "";
                            }
                            else if (item.Value.Group_ControlDataTpye == "DOUBLE")
                            {
                                item.Value.Date = 0.0;
                            }
                            else if (item.Value.Group_ControlDataTpye == "SHORT")
                            {
                                item.Value.Date = 0;
                            }
                            else if (item.Value.Group_ControlDataTpye == "LONG")
                            {
                                item.Value.Date = 0;
                            }
                        }
                    }
                    catch
                    {
                    }
                    Program.bInt = true;
                    try
                    {
                        TaskRun.Instance().m_TaskGroup.OneRunSta = false;
                    }
                    catch (Exception ex)
                    {
                    }
                    for (int i = 0; i < _TaskGroupList.Count; i++)
                    {
                        _TaskGroupList[i].RunSta = false;
                        _TaskGroupList[i]._ClearStep();
                        _TaskGroupList[i] = null;
                    }
                    _TaskGroupList.Clear();
                    Properties.Settings.Default.流程更改标志 = false;
                    MainForm.m_formAlarm.SetEstopAlarm();
                    EzdKernel.E3_MarkerStop(EzdKernelForm.ezdForm.m_idMarkerList[0]);//关闭卡1激光
                    EzdKernel.E3_MarkerStop(EzdKernelForm.ezdForm.m_idMarkerList[1]);//关闭卡2激光
                }
                else
                {
                    if (Program.bESTOPAlarm == true)
                    {
                        Program.bEStop = false;
                        Program.bESTOPAlarm = false;
                        MainForm.m_formAlarm.RstEstopAlarm();
                        foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                        {
                            gts.mc.GT_AxisOn((short)item.Value.m_CardNo, (short)(item.Value.m_AxisNo + 1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FormStart.LOG_ShowFrom["系统LOG"].Enqueue(ex.ToString());
            }
            #endregion
            #region DoorOpen
            //门禁
            try
            {
                //if (!Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["门禁"].bBitInputStatus && Program.bAuto && !Properties.Settings.Default.bDoorOpenEStopDeal)
                //{
                //    //Program.bAuto = false;
                //    //Program.bStop = false;
                //    //Program.bAlarm = true;
                //    //FlowCharCtron.alm();
                //    //DoorShow.Text = "开门";
                //    //MainForm.m_formAlarm.InsertAlarmMessage("门已被打开！！");
                //    //DoorShow.BackColor = Color.Red;
                //}
                //else
                //{
                //    //DoorShow.Text = "关门";
                //    //DoorShow.BackColor = Color.Yellow;
                //}
                if(!ManageContral.GetInOn("安全门气缸"))
                {
                    Program.bAuto = false;
                    Program.bStop = true;
                    Program.bAlarm = true;
                    FlowCharCtron.alm();
                    MainForm.m_formAlarm.InsertAlarmMessage("门已被打开！！");
                }

            }
            catch (Exception)
            {
            }
            #endregion
            if (ManageContral.GetInOn("解除光栅屏蔽"))
            {
               
                ManageContral.SetOutBit("光栅屏蔽信号", false);
                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["光栅屏蔽"].Date = false;
                FormStart.LOG_ShowFrom["系统LOG"].Equals("收到光栅屏蔽解除信号,解除光栅屏蔽");
            }
            //光栅
            #region Grating
            try
            {
                if(!(bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["光栅屏蔽"].Date)
                {
                    if (!ManageContral.GetInOn("光栅2") && !Properties.Settings.Default.bGratingEStopDeal && Program.bAuto)
                    {
                        Program.bAuto = false;
                        Program.bStop = true;
                        Program.bAlarm = true;
                        FlowCharCtron.alm();
                        MainForm.m_formAlarm.InsertAlarmMessage("光栅触发！！");
                        FormStart.LOG_ShowFrom["系统LOG"].Enqueue("光栅触发");
                    }
                }
            }
            catch (Exception)
            {
            }
            #endregion

            #region LaserOn
            //激光启动按钮
            try
            {
                //if ((Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["激光启动"].bBitInputStatus == true || Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["激光启动"].bBitInputStatus == true) && Program.bAuto == false)
                //{
                //    if (ManageContral.GetInOn("激光器启动") == true)
                //    { }
                //    else
                //    {
                //        ManageContral.SetOutBit("远程钥匙开关", true);
                //        Thread.Sleep(1000);
                //        ManageContral.SetOutBit("远程启动", true);
                //        Thread.Sleep(500);
                //        ManageContral.SetOutBit("远程启动", false);
                //    }
                //}
            }
            catch (Exception)
            {
            }
            #endregion
            #region 极限报警
            if (bAllAxisHomed)
            {
                foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                {
                    if (bAllAxisHomed == false)
                    {
                        break;
                    }
                    if (item.Value.bCWL)
                    {
                        if (!item.Value.bCWLAlarm)
                        {
                            //Program.bEStop = true;
                            Program.bStop = true;
                            Program.bAuto = false;
                            Program.bAlarm = true;
                            FlowCharCtron.alm();//报警
                            item.Value.bCWLAlarm = true;
                            MainForm.bAlarm = true;
                            MainForm.m_formAlarm.SetMotorCWLAlarm(item.Value.Axis_hardwareName);

                        }

                    }
                    else
                    {
                        if (item.Value.bCWLAlarm)
                        {
                            Program.bStop = false;
                            item.Value.bCWLAlarm = false;
                            MainForm.bAlarm = false;
                            MainForm.m_formAlarm.RstMotorCWLAlarm(item.Value.Axis_hardwareName);
                        }
                    }
                    if (item.Value.bCCWL)
                    {
                        if (!item.Value.bCCWLAlarm)
                        {
                            //  Program.bEStop = true;
                            Program.bStop = true;
                            Program.bAuto = false;
                            item.Value.bCCWLAlarm = true;
                            MainForm.bAlarm = true;
                            MainForm.m_formAlarm.SetMotorCCWLAlarm(item.Value.Axis_hardwareName);
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        if (item.Value.bCCWLAlarm)
                        {
                            item.Value.bCCWLAlarm = false;
                            MainForm.bAlarm = false;
                            MainForm.m_formAlarm.RstMotorCCWLAlarm(item.Value.Axis_hardwareName);
                        }
                    }
                }
            }
            #endregion
            #region 伺服报警
            try
            {
                foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                {
                    if (item.Value.bAlarm)
                    {
                        ManageContral.SetOutBit("三色灯绿", false);
                        ManageContral.SetOutBit("三色灯黄", false);
                        ManageContral.SetOutBit("三色灯红", true);
                        Program.bEStop = true;
                        Program.bStop = true;
                        Program.bAuto = false;
                        Program.bESTOPAlarm = true;
                        Program.bAlarm = true;
                        FlowCharCtron.alm();//报警
                        FormStart.startHoming = false;
                        FormStart.bAllAxisHomed = false;
                        FormStart.bAutoInit = false;

                        foreach (var item1 in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                        {
                            ManageContral.StopAxis(item1.Key);
                        }
                        try
                        {
                        }
                        catch
                        {
                        }
                        Program.bInt = true;
                        try
                        {
                            TaskRun.Instance().m_TaskGroup.OneRunSta = false;
                        }
                        catch (Exception ex)
                        {
                        }
                        for (int i = 0; i < _TaskGroupList.Count; i++)
                        {
                            _TaskGroupList[i].RunSta = false;
                            _TaskGroupList[i]._ClearStep();
                            _TaskGroupList[i] = null;
                        }
                        _TaskGroupList.Clear();
                        Properties.Settings.Default.流程更改标志 = false;
                        MainForm.m_formAlarm.SetMotorAlarm(item.Value.Axis_hardwareName);
                        EzdKernel.E3_MarkerStop(EzdKernelForm.ezdForm.m_idMarkerList[0]);//关闭卡1激光
                        EzdKernel.E3_MarkerStop(EzdKernelForm.ezdForm.m_idMarkerList[1]);//关闭卡2激光
                    }
                }
            }
            catch (Exception ex)
            {

            }

            #endregion
            //#region 左边菜单栏显示与隐藏
            if (MousePosition.X < statusStrip2.Width && MousePosition.Y < statusStrip2.Height && MousePosition.Y > 30)
            {
                statusStrip2.Show();
            }
            else
            {
                statusStrip2.Hide();
            }
        }
        /// <summary>
        /// 打开IO界面按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripSplitbtn_IOForm_Click(object sender, EventArgs e)
        {
            this.toolStripSplitbtn_IOForm.BorderStyle = Border3DStyle.Raised;
            if (Properties.Settings.Default.Ckdebug == false)
            {
                ToolStripLabel button = (ToolStripLabel)sender;
                string bntName = button.Text;
                bool result = SQLiteConnect.getResult(bntName);
                if (result == false)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.系统权限不足.ToString());
                    return;
                }
            }

            if (bAxisControlFromHide)
            {
                m_IODebugForm.Hide();
                bAxisControlFromHide = false;
            }
            else
            {

                m_IODebugForm.Show();
                bAxisControlFromHide = true;
            }
        }
        /// <summary>
        /// 打开或隐藏轴状态界面按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripDropDownAxisState_Click(object sender, EventArgs e)
        {
            if (bAxisStateFormHide)
            {
                mainForm.m_AxisStateViewForm = new AxisStateViewForm();
                mainForm.m_AxisStateViewForm.Show();
                mainForm.m_AxisStateViewForm.ShowForm();
                bAxisStateFormHide = false;
            }
            else
            {
                mainForm.m_AxisStateViewForm.Hide();
                bAxisStateFormHide = true;
            }
        }
        /// <summary>
        /// 打开或隐藏轴控制界面按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AxisControl_ButtonClick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Ckdebug == false)
            {
                ToolStripLabel button = (ToolStripLabel)sender;
                string bntName = button.Text;
                bool result = SQLiteConnect.getResult(bntName);
                if (result == false)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.系统权限不足.ToString());
                    return;
                }
            }
            if (bAxisControlFromHide)
            {
                mainForm.debugForm.Hide();
                bAxisControlFromHide = false;
            }
            else
            {
                mainForm.debugForm.Show(this);
                bAxisControlFromHide = true;
            }
        }
        /// <summary>
        /// 停止按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            AutoStop();
            FormStart.LOG_ShowFrom["系统LOG"].Enqueue("程序停止自动运行");
            //Weld_Log.Instance().Enqueue( "程序停止自动运行");
        }
        public void AutoStop()
        {
            buttonStop.BackColor = Color.Red;
            Program.bAuto = false;
            Program.bStop = true;
            ManageContral.SetOutBit("停止指示灯", true);
            ManageContral.SetOutBit("启动指示灯", false);
            try
            {
                if (ManageContral.GetOutOn("三色灯绿") == true && ManageContral.GetOutOn("三色灯黄") == false)
                {
                    ManageContral.SetOutBit("三色灯绿", false);
                    ManageContral.SetOutBit("三色灯黄", true);
                }
                startHoming = false;
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 开始按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /// <summary>
        /// 开始按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show( $"当前流程-{label_FlowChar.Text},请确认是否启用当前流程?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.ToString().ToUpper() != "YES")
                {
                    return;
                }
                if (EzdKernelForm.ezdForm.m_idMarkerList.Length < 2)
                {
                    MessageBox.Show("左右激光器未初始化完成，请检查左右控制卡！");
                    return;
                }
                if (EzdKernelForm.ezdForm.m_idLayerList.Length < 2)
                {
                    MessageBox.Show("图档未打开！");
                    return;
                }
                if (Program.bManul == false)
                {

                }
                else
                {
                    MessageBox.Show("请停止手动", "提示");
                    return;
                }
                if (Program.bAuto == true)
                {
                    // MessageBox.Show("自动流程已启动，请勿重复启动", "提示", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    if (Properties.Settings.Default.流程更改标志 == true)
                    {
                        FormStart.LOG_ShowFrom["系统LOG"].Enqueue("流程已更改，请初始化。");
                        MainForm.m_formAlarm.InsertAlarmMessage("流程已更改，请初始化。");
                        return;
                    }
                    if (TaskRun.Instance().m_TaskGroup.OneRunSta == true)
                    {
                        FormStart.LOG_ShowFrom["系统LOG"].Enqueue("单动流程未停止");
                        MainForm.m_formAlarm.InsertAlarmMessage("单动流程未停止");
                        return;
                    }

                    if (!bAllAxisHomed)
                    {
                        FormStart.LOG_ShowFrom["系统LOG"].Enqueue(ERecvResult.设备未回原点.ToString());
                        MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.设备未回原点.ToString());
                        return;
                    }
                    if (!bAutoInit)
                    {
                        FormStart.LOG_ShowFrom["系统LOG"].Enqueue(ERecvResult.设备未初始化.ToString());
                        MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.设备未初始化.ToString());
                        return;
                    }

                    AutoStart();
                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue("程序开始自动运行");
                    Weld_Log.Instance().Enqueue("程序开始自动运行");
                }
            }
            catch(Exception ex)
            {
                MainForm.m_formAlarm.InsertAlarmMessage("激光未初始化！！！请在左边激光控制中初始化打开图档。");
            }
        }
        private void AutoStart()
        {
            try
            {
                //倍速链启动
                ManageContral.SetOutBit("停止指示灯", false);
                ManageContral.SetOutBit("启动指示灯", true);
                ManageContral.SetOutBit("三色灯绿", true);
                ManageContral.SetOutBit("三色灯黄", false);
                ManageContral.SetOutBit("三色灯红", false);
                //运行多个流程
                if (_TaskGroupList.Count == 0)
                {
                    string Path = "";
                    foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary)
                    {
                        if (item.Value.配方是否为默认 == "默认")
                        {
                            Path = item.Value.sPath;
                            LoadData.ReadData(Path);
                        }
                    }
                    int count = 0;
                    Program.bInt = false;
                    foreach (var item in LoadData._ImageToolRun)
                    {
                        FlowCharCtron _FlowCharCtron_ = new FlowCharCtron(item.Key, TaskGroup.Instance());
                        TaskGroup _TaskGroup = new TaskGroup();
                        _TaskGroup.AddTaskUnit(_FlowCharCtron_);
                        _TaskGroup.RunSta = true;
                        _TaskGroupList.Add(_TaskGroup);
                        _TaskGroupList[count].RunSta = true;
                        _TaskGroupList[count].StartThread();
                        count++;
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
            }
            Program.bAuto = true;
            Program.bStop = false;
            buttonStart.BackColor = Color.Green;
            buttonStop.BackColor = Color.Yellow;
        }

        /// <summary>
        /// 复位按钮按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_MouseDown(object sender, MouseEventArgs e)
        {
            MainForm.m_formAlarm.RstOtherAlarm();
        }
        /// <summary>
        /// 复位按钮放开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_MouseUp(object sender, MouseEventArgs e)
        {
        }
        /// <summary>
        /// 回原按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GoHome_Click(object sender, EventArgs e)
        {
            if (Program.bAuto)
            {
                MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.自动运行中.ToString());
                return;
            }
            if (startHoming)
            {
                MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.回原点中.ToString());
                return;
            }
            Program.bStop = false;
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                item.Value.Go_HomeFinishi = false;
                item.Value.Go_Homing = false;
            }
            btn_GoHome.BackColor = Color.Aqua;
            buttonStart.BackColor = Color.Aqua;
            buttonStop.BackColor = Color.Aqua;
            btn_GoHome.BackColor = Color.Yellow;
            startHoming = true;
            homeStep = HomeStep.Idle;
            try
            {
                ManageContral.SetOutBit("三色灯绿", false);
                ManageContral.SetOutBit("三色灯黄", true);
                ManageContral.SetOutBit("三色灯红", false);
            }
            catch (Exception ex)
            {

            }
        }
        object Object = new object();
        private void HomeThread()
        {
            while (true)
            {
                //如果设备停止即停止回原
                while (true)
                {
                    Thread.Sleep(50);
                    if (Program.bEStop || Program.bStop)
                    {
                        startHoming = false;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                lock (Object)
                {
                    Thread.Sleep(50);
                    if (startHoming)
                    {
                        switch (homeStep)
                        {
                            //初始回原动作
                            case HomeStep.Idle:
                                bAllAxisHomed = false;
                                homeStep = HomeStep.HomeStart;
                                break;
                            //回原开始
                            case HomeStep.HomeStart:
                                hiPerfTimer.Start();
                                homeStep = HomeStep.HomeOthers;
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue("回原开始...");
                                break;
                            case HomeStep.HomeOthers:
                                if (hiPerfTimer.TimeUp(60))
                                {
                                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.Z轴回原超时.ToString());
                                    startHoming = false;
                                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue("Z轴回原超时");
                                    homeStep = HomeStep.HomeReset;
                                    break;
                                }
                                if (Properties.Settings.Default.回原选择 == true)
                                {
                                    HomeFlow.Instance().RunClass_IsFinish = false;
                                    HomeFlow.Instance().runTask();
                                    homeStep = HomeStep.HomeCheck;
                                }
                                else
                                {
                                    //Z轴回原完成后再对其它轴进行回原
                                    foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                                    {
                                        ManageContral.GO_Home(item.Value.Axis_hardwareName);
                                    }
                                    homeStep = HomeStep.HomeDone;
                                }
                                break;
                            case HomeStep.HomeCheck:
                                if (HomeFlow.Instance().RunClass_IsFinish == true)
                                {
                                    homeStep = HomeStep.HomeReset;
                                    count = 0;
                                    timerHome.Enabled = false;
                                    startHoming = false;
                                    btn_GoHome.BackColor = Color.Green;
                                    bAllAxisHomed = true;
                                    //DataManage.SetData("计数", "左计数", (object)0);
                                    //DataManage.SetData("计数", "右计数", (object)0);
                                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue("回原完成");
                                }
                                break;
                            case HomeStep.HomeDone:
                                if (hiPerfTimer.TimeUp(60))
                                {
                                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.回原点超时回原失败.ToString());
                                    startHoming = false;
                                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue("回原点超时回原失败");
                                    homeStep = HomeStep.HomeReset;
                                    break;
                                }
                                count = 0;
                                foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                                {
                                    if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Go_Homing == false &&
                                            Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].是否屏蔽 == false)
                                    {
                                        Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Go_Homing = true;
                                    }
                                    if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Go_HomeFinishi == true &&
                                            Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].是否屏蔽 == false)
                                    {
                                        count++;
                                    }
                                }
                                int GohomeAxisCount = 0;
                                foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                                {
                                    if (!item.Value.是否屏蔽)
                                        GohomeAxisCount++;
                                }
                                if (count == GohomeAxisCount)
                                {
                                    count = 0;
                                    timerHome.Enabled = false;
                                    startHoming = false;
                                    btn_GoHome.BackColor = Color.Green;
                                    bAllAxisHomed = true;
                                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue("回原完成");
                                    break;
                                }
                                break;
                            case HomeStep.HomeReset:
                                count = 0;
                                btn_GoHome.BackColor = Color.Aqua;
                                btnInit.BackColor = Color.Aqua;
                                buttonStart.BackColor = Color.Aqua;
                                buttonStop.BackColor = Color.Aqua;
                                startHoming = false;
                                bAllAxisHomed = false;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 初始化按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInit_Click(object sender, EventArgs e)
        {
            try
            {
                //流程点位导入
                if (!PointSetting_Form.LoadObj("左工位") & !PointSetting_Form.LoadObj("右工位"))
                {
                    MainForm.m_formAlarm.InsertAlarmMessage("点位未配置！！");
                    return;
                }

                if (!bAllAxisHomed || Program.bAuto)
                {
                    if (!bAllAxisHomed)
                    {
                        MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.未回原完成.ToString());
                        return;
                    }
                    if (Program.bAuto)
                    {
                        MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.自动运行中.ToString());
                        return;
                    }
                }

                //复位流程以及自动运行前的一些气缸等硬件初始化
                bAutoInit = true;
                btnInit.BackColor = Color.Green;
                Program.colunmIndexLeft = 1;
                Program.CurrentPoint_L = 0;
                Program.colunmIndexRight = 1;
                Program.CurrentPoint_R = 0;
            }
            catch
            {

            }
        }

        /// <summary>
        /// 打开软件说明界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSoftIntroduction_Click(object sender, EventArgs e)
        {
            m_operateDirectionsForm.Show();
            m_operateDirectionsForm.Activate();
        }
        /// <summary>
        /// 复位的单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {

                if (Program.bAuto == true)
                {
                }
                else
                {
                    Program.bStop = false;
                    Program.bReset = true;
                    MainForm.m_formAlarm.RstOtherAlarm();
                    startHoming = false;
                    homeStep = HomeStep.Idle;
                    ManageContral.SetOutBit("三色灯黄", true);
                    ManageContral.SetOutBit("三色灯红", false);
                    ManageContral.SetOutBit("三色灯绿", false);
                    ManageContral.SetOutBit("BIZZ", false);

                    //复位门
                    Program.boolDoorOpen = false;
                    Program.bAlarm = false;
                    Program.bAlarm = false;
                    Program.bInt = false;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 回原计时器,已摒弃
        /// </summary>
        int count = 0;
        private void timerHome_Tick(object sender, EventArgs e)
        {
            switch (strInit)
            {
                case Init.等待初始化信号:
                    if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["初始化复位"].bBitInputStatus)
                    {
                        strInit = Init.回原点;
                    }
                    break;
                case Init.回原点:
                    btn_GoHome_Click(null, null);
                    strInit = Init.初始化;
                    break;
                case Init.初始化:
                    if (FormStart.bAllAxisHomed)
                    {
                        btnInit_Click(null, null);
                        strInit = Init.等待初始化信号;
                    }
                    break;
            }

            //状态检测
            if (Program.bEStop || Program.bStop)
            {
            }
            else
            {
            }
        }

        private void btn_LaserControl_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Ckdebug == false)
            {
                ToolStripLabel button = (ToolStripLabel)sender;
                string bntName = button.Text;
                bool result = SQLiteConnect.getResult(bntName);
                if (result == false)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.系统权限不足.ToString());
                    return;
                }
            }
            try
            {
                if (bLaserContorlFormHide)
                {
                    m_LaserContorlForm.Hide();
                    bLaserContorlFormHide = false;
                }
                else
                {
                    m_LaserContorlForm.Show();
                    bLaserContorlFormHide = true;
                }
            }
            catch (Exception)
            {
                m_LaserContorlForm = new LaserContorlForm();
                bLaserContorlFormHide = false;
                btn_LaserControl_Click(sender, e);
            }
        }
        private void btn_MESSetting_Click(object sender, EventArgs e)
        {
            try
            {
                if (bMESSetFormHide)
                {
                    m_MESSettingForm.Hide();
                    bMESSetFormHide = false;
                }
                else
                {
                    m_MESSettingForm.Show();
                    bMESSetFormHide = true;
                }
            }
            catch (Exception)
            {
                m_MESSettingForm = new MESSettingForm();
                bMESSetFormHide = false;
                btn_MESSetting_Click(sender, e);
            }
        }
        private void btn_LaserPowerView_Click(object sender, EventArgs e)
        {
            if (bLaserPowerViewFormHide)
            {
                mainForm.m_PowerViewForm.Show();
                bLaserPowerViewFormHide = false;
            }
            else
            {
                mainForm.m_PowerViewForm.Hide();
                bLaserPowerViewFormHide = true;
            }
        }

        private void btn_SaveParam_Click(object sender, EventArgs e)
        {
            mainForm.m_formSystemSetting.SaveData();//调用参数设置界面保存方法
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            Task.Run(() =>
            {
                stopwatch.Start();
                while (true)
                {
                    Thread.Sleep(100);
                    if (stopwatch.ElapsedMilliseconds > 4000)
                        break;
                }
            }
            );
        }
        private void CheckData_Click(object sender, EventArgs e)
        {
            CheckD = new UniversalControlSystem.CheckData();
            CheckD.Show();
        }
        private void 参数_Click(object sender, EventArgs e)
        {
            if (bDemarcateFormHide == false)
            {
                DemarcateForm DemarcateForm = new DemarcateForm();
                DemarcateForm.Show();
                bDemarcateFormHide = true;
            }
            else
            {
                DemarcateForm.Hide();
                bDemarcateFormHide = false;
            }
        }
        private void 参数_Click_1(object sender, EventArgs e)
        {
            if (bParameterFormHide == false)
            {
                bParameterFormHide = true;
                Parameter = new UniversalControlSystem.Parameter();
                Parameter.Show();
            }
            else
            {
                bParameterFormHide = false;
                Parameter = new UniversalControlSystem.Parameter();
                Parameter.Hide();
            }
        }

        private void btnInit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnInit_MouseDown(object sender, MouseEventArgs e)
        {
            resetTimer.Start();
        }

        private void btnInit_MouseUp(object sender, MouseEventArgs e)
        {
            if (resetTimer.TimeUp(2))
            {
                if (!bAllAxisHomed)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.未回原完成.ToString());
                    return;
                }
                if (Program.bAuto)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.自动运行中.ToString());
                    return;
                }
                //初始化信号
                Program.colunmIndexLeft = 1;
                Program.colunmIndexRight = 1;
                try
                {
                    foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
                    {
                        if (item.Value.Group_ControlDataTpye == "BOOL")
                        {
                            item.Value.Date = false;
                        }
                        else if (item.Value.Group_ControlDataTpye == "STRING")
                        {
                            item.Value.Date = "";
                        }
                        else if (item.Value.Group_ControlDataTpye == "DOUBLE")
                        {
                            item.Value.Date = 0.0;
                        }
                        else if (item.Value.Group_ControlDataTpye == "SHORT")
                        {
                            item.Value.Date = 0;
                        }
                        else if (item.Value.Group_ControlDataTpye == "LONG")
                        {
                            item.Value.Date = 0;
                        }
                    }
                }
                catch
                {
                }
                Program.bInt = true;
                try
                {
                    TaskRun.Instance().m_TaskGroup.OneRunSta = false;
                }
                catch (Exception ex)
                { }

                for (int i = 0; i < _TaskGroupList.Count; i++)
                {
                    _TaskGroupList[i].RunSta = false;
                    _TaskGroupList[i]._ClearStep();
                    _TaskGroupList[i] = null;
                }
                _TaskGroupList.Clear();

                Properties.Settings.Default.流程更改标志 = false;
                MessageBox.Show("初始化完成");
                FormStart.LOG_ShowFrom["系统LOG"].Enqueue("初始化完成");
                //TaskRun.Instance().m_TaskGroup._ClearStep();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default._Totalcount = 0;

        }

        private void GroupInformation_Enter(object sender, EventArgs e)
        {

        }

        private void richTxtLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTxtLog_DoubleClick(object sender, EventArgs e)
        {
            this.richTxtLog.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.OKTotal = 0;
            Properties.Settings.Default.Save();
        }

        private void btn_PointSetting_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripLabel button = (ToolStripLabel)sender;
                string bntName = button.Text;
                bool result = SQLiteConnect.getResult(bntName);
                if (result == false)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.系统权限不足.ToString());
                    return;
                }
                if (bPointSettingHide == false)
                {
                    _PointSetting_Form.Show();
                    bPointSettingHide = true;
                }
                else
                {
                    _PointSetting_Form.Hide();
                    bPointSettingHide = false;
                }
            }
            catch (Exception)
            {
                _PointSetting_Form = new PointSetting_Form();

            }
        }

        private void 数据库_Click(object sender, EventArgs e)
        {
            if (bDemarcateFormHide == false)
            {
                _数据库 = new 数据库();
                _数据库.Show();
                bDemarcateFormHide = true;
            }
            else
            {
                _数据库.Hide();
                bDemarcateFormHide = false;
            }
        }

        private void txt_firstWeldPosition_TextChanged(object sender, EventArgs e)
        {
            //firstWeldPosition = txt_firstWeldPosition.Text;
        }

        private void btn_clearQRCode_Click(object sender, EventArgs e)
        {
            //    label_ProductQRCode.Text = "....................";
            //    DataManage.m_Doc.m_dataDictionary["扫码"].m_dataDictionary["扫码数据"].objValue = "";
        }

        public void tab_LogShow()
        {
            tab_logTab.Controls.Clear();
            TabPage tabPageAll = new TabPage();
            tabPageAll.Name = "全部流程";
            tabPageAll.Text = "全部流程";
            RichTextBox rbAll = new RichTextBox();
            rbAll.Name = "richTxtLog";
            rbAll.Dock = System.Windows.Forms.DockStyle.Fill;
            tab_logTab.Controls.Add(tabPageAll);
            tabPageAll.Controls.Add(rbAll);
            //日志按钮
            foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary)
            {
                if (item.Value.配方是否为默认 == "默认")
                {
                    foreach (var item1 in item.Value.ListFlowData)
                    {
                        TabPage tabPage = new TabPage();
                        tabPage.Name = item1.RunFlowData_ControlDataName;
                        tabPage.Text = item1.RunFlowData_ControlDataName;
                        RichTextBox rb = new RichTextBox();
                        rb.Name = $"log_richTextBox{item1.RunFlowData_ControlDataName}";
                        rb.Dock = System.Windows.Forms.DockStyle.Fill;
                        tab_logTab.Controls.Add(tabPage);
                        tabPage.Controls.Add(rb);
                    }
                }
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            try
            {
                
                label_totalocount.Text = Properties.Settings.Default.OKTotal.ToString();
                label_CT.Text = Program.运行时间;
                //出光锁光按钮控制
                //if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["锁光/出光"].bBitInputStatus == true)
                //{
                //    锁光.Text = "可出光";
                //    锁光.BackColor = Color.Green;
                //    ManageContral.SetOutBit("出光使能", true);
                //}
                //else
                //{
                //    锁光.Text = "已锁光";
                //    锁光.BackColor = Color.Red;
                //    ManageContral.SetOutBit("出光使能", false);
                //}
                //手轮控制
                if (Properties.Settings.Default.Agv工位 == "")
                {
                    label3.Text = "当前工位为无料状态";
                }
                else
                {
                    label3.Text = $"当前工位状态为+{Properties.Settings.Default.Agv工位},状态不对请清除工位记忆";
                }
                if (Properties.Settings.Default.chooseAisx == false)
                {
                    if (startHoming || Program.bAuto || Program.bEStop)
                    {
                    }
                    else if (ManageContral.GetInOn("手轮X") == true || ManageContral.GetInOn("手轮Y") == true || ManageContral.GetInOn("手轮Z") == true || ManageContral.GetInOn("手轮U") == true)
                    {
                        if (ManageContral.GetInOn("手轮X") == true && setOk == false)
                        {
                            if (ManageContral.GetInOn("手轮1") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(0, 1);
                            }
                            else if (ManageContral.GetInOn("手轮10") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(0, 10);

                            }
                            else if (ManageContral.GetInOn("手轮100") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(0, 50);

                            }
                        }
                        if (ManageContral.GetInOn("手轮Y") == true && setOk == false)
                        {
                            if (ManageContral.GetInOn("手轮1") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(1, 1);

                            }
                            else if (ManageContral.GetInOn("手轮10") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(1, 10);

                            }
                            else if (ManageContral.GetInOn("手轮100") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(1, 50);

                            }
                        }
                        if (ManageContral.GetInOn("手轮Z") == true && setOk == false)
                        {
                            if (ManageContral.GetInOn("手轮1") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(2, 1);

                            }
                            else if (ManageContral.GetInOn("手轮10") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(2, 10);

                            }
                            else if (ManageContral.GetInOn("手轮100") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(2, 50);

                            }
                        }

                        if (ManageContral.GetInOn("手轮U") == true && setOk == false)
                        {
                            if (ManageContral.GetInOn("手轮1") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(3, 1);

                            }
                            else if (ManageContral.GetInOn("手轮10") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(3, 10);

                            }
                            else if (ManageContral.GetInOn("手轮100") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(3, 50);

                            }
                        }
                    }
                    else if (ManageContral.GetInOn("手轮X") == false && ManageContral.GetInOn("手轮Y") == false && ManageContral.GetInOn("手轮Z") == false && ManageContral.GetInOn("手轮U") == false && setOk == true)
                    {
                        setOk = false;
                        ManageContral.StopManualPulser(0);
                        ManageContral.StopManualPulser(1);
                        ManageContral.StopManualPulser(2);
                        ManageContral.StopManualPulser(3);
                        ManageContral.StopManualPulser(4);
                        ManageContral.StopManualPulser(5);
                        ManageContral.StopManualPulser(6);
                        ManageContral.StopManualPulser(7);

                    }
                }
                else if (Properties.Settings.Default.chooseAisx == true)
                {

                    if (startHoming || Program.bAuto)
                    {
                    }
                    else if (ManageContral.GetInOn("手轮X") == true || ManageContral.GetInOn("手轮Y") == true || ManageContral.GetInOn("手轮Z") == true || ManageContral.GetInOn("手轮U") == true || ManageContral.GetInOn("手轮5") == true || ManageContral.GetInOn("手轮6") == true || ManageContral.GetInOn("手轮7") == true || ManageContral.GetInOn("手轮8") == true)
                    {
                        if (ManageContral.GetInOn("手轮X") == true && setOk == false)
                        {
                            if (ManageContral.GetInOn("手轮1") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(0, 1);
                            }
                            else if (ManageContral.GetInOn("手轮10") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(0, 10);

                            }
                            else if (ManageContral.GetInOn("手轮100") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(0, 50);

                            }
                        }
                        if (ManageContral.GetInOn("手轮Y") == true && setOk == false)
                        {
                            if (ManageContral.GetInOn("手轮1") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(1, 1);

                            }
                            else if (ManageContral.GetInOn("手轮10") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(1, 10);

                            }
                            else if (ManageContral.GetInOn("手轮100") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(1, 50);

                            }
                        }
                        if (ManageContral.GetInOn("手轮Z") == true && setOk == false)
                        {
                            if (ManageContral.GetInOn("手轮1") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(2, 1);

                            }
                            else if (ManageContral.GetInOn("手轮10") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(2, 10);

                            }
                            else if (ManageContral.GetInOn("手轮100") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(2, 50);

                            }
                        }

                        if (ManageContral.GetInOn("手轮U") == true && setOk == false)
                        {
                            if (ManageContral.GetInOn("手轮1") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(3, 1);

                            }
                            else if (ManageContral.GetInOn("手轮10") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(3, 10);

                            }
                            else if (ManageContral.GetInOn("手轮100") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(3, 50);

                            }
                        }
                        if (ManageContral.GetInOn("手轮5") == true && setOk == false)
                        {
                            if (ManageContral.GetInOn("手轮1") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(4, 1);

                            }
                            else if (ManageContral.GetInOn("手轮10") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(4, 10);

                            }
                            else if (ManageContral.GetInOn("手轮100") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(4, 50);

                            }
                        }
                        if (ManageContral.GetInOn("手轮6") == true && setOk == false)
                        {
                            if (ManageContral.GetInOn("手轮1") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(5, 1);

                            }
                            else if (ManageContral.GetInOn("手轮10") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(5, 10);

                            }
                            else if (ManageContral.GetInOn("手轮100") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(5, 50);

                            }
                        }
                        if (ManageContral.GetInOn("手轮7") == true && setOk == false)
                        {
                            if (ManageContral.GetInOn("手轮1") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(6, 1);

                            }
                            else if (ManageContral.GetInOn("手轮10") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(6, 10);

                            }
                            else if (ManageContral.GetInOn("手轮100") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(6, 50);

                            }
                        }
                        if (ManageContral.GetInOn("手轮8") == true && setOk == false)
                        {
                            if (ManageContral.GetInOn("手轮1") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(7, 1);

                            }
                            else if (ManageContral.GetInOn("手轮10") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(7, 10);

                            }
                            else if (ManageContral.GetInOn("手轮100") == true)
                            {
                                setOk = true;
                                ManageContral.StartManualPulser(7, 50);

                            }
                        }
                    }
                    else if (ManageContral.GetInOn("手轮X") == false && ManageContral.GetInOn("手轮Y") == false && ManageContral.GetInOn("手轮Z") == false && ManageContral.GetInOn("手轮U") == false && ManageContral.GetInOn("手轮5") == false && ManageContral.GetInOn("手轮6") == false && ManageContral.GetInOn("手轮7") == false && ManageContral.GetInOn("手轮8") == false && setOk == true)
                    {
                        setOk = false;
                        ManageContral.StopManualPulser(0);
                        ManageContral.StopManualPulser(1);
                        ManageContral.StopManualPulser(2);
                        ManageContral.StopManualPulser(3);
                        ManageContral.StopManualPulser(4);
                        ManageContral.StopManualPulser(5);
                        ManageContral.StopManualPulser(6);
                        ManageContral.StopManualPulser(7);
                    }
                }
            }
            catch
            { }
        }

        //主页激光控制
        private void btn_laserContral_Click(object sender, EventArgs e)
        {
            EzdKernelForm ezForm = new EzdKernelForm();
            ezForm.Show();
        }

        private void timer_showMessage_Tick(object sender, EventArgs e)
        {
            try
            {
                //label_工装板码.Text = DataManage.StrValue("扫码", "扫码数据");
                label_功率.Text = DataManage.StrValue("清洗", "功率")+"W";
                label_频率.Text = DataManage.StrValue("清洗", "频率")+"KHZ";
                label_速度.Text = DataManage.StrValue("清洗", "速度")+"mm/s";
                label_线间距.Text= DataManage.StrValue("清洗", "线间距") + "mm";
                foreach(var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary)
                {
                    try
                    {
                        if(item.Value.配方是否为默认=="默认")
                        {
                            label_FlowChar.Text = item.Value.FlowChar_ControlDataName;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 手动排料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.bAuto == false && Program.bStop == true)
            {
                ManageContral.SetOutBit("清洗完成", true);
                Check_INPUT checkInput = new Check_INPUT();
                checkInput.IO_Name = "可以清洗信号";
                checkInput.Delay = 3000;
                checkInput.CheckIO_Sta = "false";
                ManageContral.SetOutBit("清洗完成", true);
                FormStart.LOG_ShowFrom["系统LOG"].Enqueue("已经发送排料信号！正在排料...");
                Task.Run(() =>
                {
                    if (checkInput.WaitINPut_CheckNoAuto(checkInput.IO_Name, checkInput.CheckIO_Sta, checkInput.Delay))
                    {
                        ManageContral.SetOutBit("清洗完成", false);
                        FormStart.LOG_ShowFrom["系统LOG"].Enqueue("排料成功！");
                    }
                    else
                    {
                        ManageContral.SetOutBit("清洗完成", false);
                        FormStart.LOG_ShowFrom["系统LOG"].Enqueue("排料超时！已关闭排料信号");
                    }
                });
            }
            else
                FormStart.LOG_ShowFrom["系统LOG"].Enqueue("在程序停止下运行！");
            Thread.Sleep(400);
            ManageContral.SetOutBit("清洗完成", false);
            Properties.Settings.Default.流程更改标志 = true;
        }

        /// <summary>
        /// 清空二维码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clearQRCode_Click_1(object sender, EventArgs e)
        {
            label_工装板码.Text = "....................";
            DataManage.m_Doc.m_dataDictionary["扫码"].m_dataDictionary["扫码数据"].objValue = "";
            DataManage.SetData("扫码", "扫码数据", "");
            DataManage.SetData("扫码", "模组码1", "");
            DataManage.SetData("扫码", "模组码2", "");
        }
        /// <summary>
        /// 清空产量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_3(object sender, EventArgs e)
        {
            Properties.Settings.Default.OKTotal = 0;
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["模拟进料"].Date = true;
            DialogResult result = MessageBox.Show("是否消除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.ToString().ToUpper() == "YES")
            {
                Properties.Settings.Default.Agv工位 = "";
                Properties.Settings.Default.Save();
            }
        }

        private void timer_leftWeldTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                //判断是否出光
                if (Program.ifWeldLeft)
                {
                    DateTime startTime = DateTime.Now;//开始出光时间
                    DateTime endTime;//结束时间
                    TimeSpan totalTime;//总时间
                    while (true)
                    {
                        Thread.Sleep(10);
                        endTime = DateTime.Now;
                        totalTime = endTime - startTime;
                        if (totalTime.TotalMilliseconds > 3000)
                        {
                            EzdKernel.E3_MarkerStop(EzdKernelForm.ezdForm.m_idMarkerList[0]);//关闭卡1激光
                            EzdKernel.E3_MarkerStop(EzdKernelForm.ezdForm.m_idMarkerList[1]);//关闭卡2激光
                            Program.bStop = true;//停止
                            Program.bAuto = false;
                            Program.ifWeldLeft = false;
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue("左激光出光超时！现已经停止出光。");
                            Program.bAlarm = true;
                            FlowCharCtron.alm();
                            break;
                        }
                        else if (Program.ifWeldLeft == false)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void timer_rightWeldTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                //判断是否出光
                if (Program.ifWeldRight)
                {
                    DateTime startTime = DateTime.Now;//开始出光时间
                    DateTime endTime;//结束时间
                    TimeSpan totalTime;//总时间
                    while (true)
                    {
                        Thread.Sleep(10);
                        endTime = DateTime.Now;
                        totalTime = endTime - startTime;
                        if (totalTime.TotalMilliseconds > 3000)
                        {
                            EzdKernel.E3_MarkerStop(EzdKernelForm.ezdForm.m_idMarkerList[0]);//关闭卡1激光
                            EzdKernel.E3_MarkerStop(EzdKernelForm.ezdForm.m_idMarkerList[1]);//关闭卡2激光
                            Program.bStop = true;//停止
                            Program.bAuto = false;
                            Program.ifWeldRight = false;
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue("右激光出光超时！现已经停止出光。");
                            Program.bAlarm = true;
                            FlowCharCtron.alm();
                            break;
                        }
                        else if (Program.ifWeldRight == false)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void checkBox_Shoujian_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Shoujian.Checked)
            {
                DialogResult result = MessageBox.Show("机台进入首件模式", "提示");
                foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary)
                {
                    try
                    {
                        if (item.Value.FlowChar_ControlDataName == "首件")
                        {
                            Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary["首件"].配方是否为默认 = "默认";
                        }
                        else
                        {
                            Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[item.Value.FlowChar_ControlDataName].配方是否为默认 = "不默认";
                        }
                    }
                    catch (Exception ex)
                    {
                        checkBox_Shoujian.Checked = false;
                        MessageBox.Show("切换配方失败" + ex);
                        return;
                    }

                }
                //label4.Text = "当前设备点检模式!!!!";
                Properties.Settings.Default.流程更改标志 = true;
                btnInit.BackColor = Color.Aqua;
                Properties.Settings.Default.首件 = checkBox_Shoujian.Checked;
                Properties.Settings.Default.Save();
            }

            else if (!checkBox_Shoujian.Checked)
            {
                DialogResult result = MessageBox.Show("机台退出首件模式");
                foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary)
                {
                    try
                    {
                        if (item.Value.FlowChar_ControlDataName == "F01B极柱清洗机")
                        {
                            Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary["F01B极柱清洗机"].配方是否为默认 = "默认";
                        }
                        else
                        {
                            Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[item.Value.FlowChar_ControlDataName].配方是否为默认 = "不默认";
                        }
                        //Hard_Ward_Contral._FlowChar_ControlParameter.SaveDoc();
                    }
                    catch (Exception ex)
                    {
                        checkBox_Shoujian.Checked = true;
                        MessageBox.Show("切换配方失败" + ex);
                        return;
                    }

                }
                //label4.Text = "";
                Properties.Settings.Default.流程更改标志 = true;
                Properties.Settings.Default.首件 = checkBox_Shoujian.Checked;
                Properties.Settings.Default.Save();
                btnInit.BackColor = Color.Aqua;
            }

        }
        public Stopwatch DoorWatch1 = new Stopwatch();
        public int DoorStep1 = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {

            if (ManageContral.GetInOn("门禁"))
            {
                DoorWatch1.Reset();
                DoorWatch1.Start();
                DoorStep1 = 1;
            }
            if (!ManageContral.GetInOn("安全门气缸"))
            {
                DoorStep1 = 2;
            }
            if (DoorWatch1.ElapsedMilliseconds > 3000 && ManageContral.GetInOn("安全门气缸"))
            {
                DoorStep1 = 3;
            }
            switch (DoorStep1)
            {
                case 1:
                    ManageContral.SetOutBit("门禁", true);
                    break;
                case 2:
                    ManageContral.SetOutBit("门禁", false);
                    DoorStep1 = 0;
                    break;
                case 3:
                    ManageContral.SetOutBit("门禁", false);
                    DoorStep1 = 0;
                    break;
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            if(checkBox_Shoujian.Checked==false)
            {
                MessageBox.Show("未勾选首件模式!");
                return;
            }
            try
            {
                ToolStripLabel button = (ToolStripLabel)sender;
                string bntName = button.Text;
                bool result = SQLiteConnect.getResult(bntName);
                //if (result == false)
                //{
                //    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.系统权限不足.ToString());
                //    return;
                //}
                if (bExamineFormHide == false)
                {
                    Examine.Show();
                    bExamineFormHide = true;
                }
                else
                {
                    Examine.Hide();
                    bExamineFormHide = false;
                }
            }
            catch (Exception)
            {
                Examine = new ExamineForm();

            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if(Program.bAuto)
            {
                checkBox_Shoujian.Visible = false;
            }
            else
            {
                checkBox_Shoujian.Visible = true;
            }
        }
    }
}
