using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
   public  class CCDTaska_Left
    {
        private HiPerfTimer ctTimer = new HiPerfTimer();
        private object lockObj = new object();
        int Result;
        //RunClass RunCls = new RunClass();
        public AutoRunStep MiddleAutoRunStepA = new AutoRunStep();
        //public AutoRunStep MiddleAutoRunStepB = new AutoRunStep();
        Stopwatch stopwatch = new Stopwatch();
        /// <summary>
        /// 排胶计时器
        /// </summary>
        HiperTimer HipMiddleTaskRunOutGlue = new HiperTimer();
        FormStart m_formStart = new FormStart();
        string CCDTaska_A_AixsName = "喷码载盘左";
        string LoadPaperAixsName = "取料轴Y";
        string LaserAixsName = "激光Y轴";
        string Ari_Brush_AixsName = "拍照补偿轴";
        string 下料AixsName = "下料X轴";
        public bool LoadMaterialA = false;
        public int CCDA_Count = 0;
        public string CCD_POSITION_RES= "";//拍照位置返回结果
      
        /// <summary>
        /// CCDA 拍照结果
        /// </summary>
        public string CCD_左B_RUN_REL = "";
        public string CCD_左A_RUN_REL = "";
        public string CCD_左B_Laser_REL = "";
        public string CCD_左A_Laser_REL = "";
        public string CCD_左B_Print_REL = "";
        public string CCD_左A_Print_REL = "";
        public string CCD_左B_Check_REL = "";
        public string CCD_左A_Check_REL = "";
        public bool CCD_左RUN_REL = false;
        int CamerCountNG = 0;
        string CamerStrRun = "线扫";
        int Pruduct = 0;//产品序号
        string A_OR_B_Str = "";
        string Date_ = "";
        string ChooseA = "下料";
        public void ProcessA()
        {
  
            bool sta = false;
            //Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["线扫相机"].Date = "线扫相机";
            
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位取料位安全标志位"].Date = true;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位取料位安全标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光清洗位安全标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台激光清洗位安全标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台激光喷码位安全标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台下料位安全标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台下料位安全标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台_待机位安全标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台_待机位安全标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCDTaska_A运行标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位激光位安全标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位激光位安全标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料运动标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCDTaska_B运行标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = false;
            try
            {
                while (true)
                {
                    Thread.Sleep(50);
                    lock (lockObj)
                    {
                        if (!Program.bAuto || Program.bStop || Program.bEStop|| LoadMaterialA==true)
                        {
                        }
                        else
                        {
                            switch (MiddleAutoRunStepA)
                            {
                                case AutoRunStep.Idle:
                                    //流程的预准备
                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台下料位安全标志位"].Date = false;
                                    MiddleAutoRunStepA = AutoRunStep.CCDTaska_上料轴待机位;
                                    break;
                                case AutoRunStep.CCDTaska_上料轴待机位:                                
                                    ctTimer.Start();
                                    MiddleAutoRunStepA = AutoRunStep.RunStart;                               
                                    break;
                                case AutoRunStep.RunStart:
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位取料位安全标志位"].Date == false
                                    && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料运动标志位"].Date == true)
                                    {
                                        ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台_待机位);
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位取料位安全标志位"].Date = true;            
                                        MiddleAutoRunStepA = AutoRunStep.CCDTaska_左气缸上升检测;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCDTaska_左气缸上升检测:
                                    if ( ManageContral.DetectingAxis(CCDTaska_A_AixsName) == 0)
                                    {
                                        ManageContral.SetOutBit("移栽平台2气缸", true);
                                        MiddleAutoRunStepA = AutoRunStep.CCD_左_面判断是否放料;
                                        ctTimer.Start();
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        //FormStart.LOG_ShowFrom["CCDTaska_左"].Enqueue("移栽1气缸上信号超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("移栽1气缸上信号超时报警");
                                        //LoadMaterialA = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCD_左_面判断是否放料:
                                    //选择走双面还是走单面
                                    sta = ManageContral.GetInOn("移栽2气缸上");
                                    if (true)
                                    {
                                        ////判断
                                        if (CCD_左A_RUN_REL == "" /*&& CCD_B_RUN_REL == ""*/)
                                        {
                                            if (sta == true && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料运动标志位"].Date == true)
                                            {
                                                //Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料运动标志位"].Date = false;
                                                sta = ManageContral.GetInOn("移栽2气缸上");
                                                if (sta == true)
                                                {
                                                    ManageContral.AxisPMoveAbsoluteToStop(LoadPaperAixsName, DateSave.Instance().Production.上料轴放料位);
                                                    MiddleAutoRunStepA = AutoRunStep.CCDTaska_上料轴放料位;
                                                    ctTimer.Start();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MiddleAutoRunStepA = AutoRunStep.CCD_左_面线扫开始拍照位;
                                        }
                                    }
                                    else
                                    {
                                    }
                                    break;
                                case AutoRunStep.CCDTaska_上料轴放料位:
                                    if (ManageContral.DetectingAxis(LoadPaperAixsName) == 0)
                                    {
                                        ctTimer.Start();
                                        ManageContral.SetOutBit("上料吸板气缸", true);
                                        MiddleAutoRunStepA = AutoRunStep.CCD_左_面开始检测是否下料;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        //FormStart.LOG_ShowFrom["CCDTaska_左"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                        //LoadMaterialA = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCD_左_面开始检测是否下料:
                                    sta = ManageContral.GetInOn("上料吸板气缸下");
                                    if (sta == true)
                                    {
                                        //ManageContral.SetOutBit("上料吸板真空", false);
                                        ctTimer.Start();
                                        MiddleAutoRunStepA = AutoRunStep.CCDTaska_左破真空;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        FormStart.LOG_ShowFrom["CCDTaska_左"].Enqueue("CCDTaska_左_上料吸板气缸下感应器超时报警");
                                        MainForm.m_formAlarm.InsertAlarmMessage("CCDTaska_A_上料吸板气缸下超时报警");
                                        LoadMaterialA = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCDTaska_左破真空:
                                    //if (ManageContral.GetInOn("上料真空压力") == false)
                                    //{       
                                        Thread.Sleep(300);
                                        ManageContral.SetOutBit("上料吸板气缸", false);
                                        ManageContral.SetOutBit("左移栽定位气缸1", true);
                                        ManageContral.SetOutBit("左移栽定位气缸2", true);
                                        MiddleAutoRunStepA = AutoRunStep.CCDTaska_左气缸上升检测到位;
                                        ctTimer.Start();
                                    //}
                                    //else if (ctTimer.TimeUp(6))
                                    //{
                                    //    FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料吸板气缸上超时报警");
                                    //    MainForm.m_formAlarm.InsertAlarmMessage("上料吸板气缸上超时报警");
                                    //    LoadMaterialA = true;
                                    //    ctTimer.Start();
                                    //}
                           
                                    break;
                                case AutoRunStep.CCDTaska_左气缸上升检测到位:
                                    sta = ManageContral.GetInOn("上料吸板气缸上");
                                    if (sta == true)
                                    {
                                        ctTimer.Start();
                                        //继续取料
                                       // FormStart.LoadPaperStep.MiddleAutoRunStepA = AutoRunStep.Idle;
                                        MiddleAutoRunStepA = AutoRunStep.CCDTaska_左气缸夹料;
                                    }
                                    else if (ctTimer.TimeUp(3))
                                    {
                                        ctTimer.Start();
                                        //FormStart.LOG_ShowFrom["CCDTaska_左"].Enqueue("CCDTaska_左_上料吸板气缸上感应器超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("CCDTaska_左_上料吸板气缸上感应器超时报警");
                                        //LoadMaterialA = true;
                                    }
                                    break;
                                case AutoRunStep.CCDTaska_左气缸夹料:
                                    ctTimer.Start();
                                    ManageContral.SetOutBit("移栽平台2气缸", true);
                                    ManageContral.AxisPMoveAbsoluteToStop(LoadPaperAixsName, DateSave.Instance().Production.上料轴中转位);
                                    MiddleAutoRunStepA = AutoRunStep.CCDTaska_左气缸夹料到位检测;
                                    break;
                                case AutoRunStep.CCDTaska_左气缸夹料到位检测:
                                    sta = ManageContral.GetInOn("移栽2有料");
                                    //sta = ManageContral.GetInOn("上料吸板气缸上");
                                    if (sta == false)
                                    {
                                        ctTimer.Start();
                                        MiddleAutoRunStepA = AutoRunStep.CCD_左_上料轴待机位;
                                    }
                                    else if (ctTimer.TimeUp(3))
                                    {
                                        //ctTimer.Start();
                                        //FormStart.LOG_ShowFrom["CCDTaska_左"].Enqueue("CCDTaska_CCD_左_上料轴待机位超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("CCDTaska_左_CCD_左_上料轴待机位超时报警");
                                        //LoadMaterialA = true;
                                    }
                                    break;
                                case AutoRunStep.CCD_左_上料轴待机位:
                                    if (ManageContral.DetectingAxis(LoadPaperAixsName) == 0)
                                    {
                                      //  FormStart.LoadPaperStep.MiddleAutoRunStepA = AutoRunStep.Idle;
                                        ctTimer.Start();
                                        MiddleAutoRunStepA = AutoRunStep.CCD_左_上料轴待机位到位检测;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                   {
                                        //FormStart.LOG_ShowFrom["CCDTaska_左"].Enqueue("CCD_左_上料轴待机位到位检测超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("CCD_左_上料轴待机位到位检测超时报警");
                                        //LoadMaterialA = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCD_左_上料轴待机位到位检测:
                                    sta = ManageContral.GetInOn("移栽1在激光位");
                                    if (ManageContral.DetectingAxis(LoadPaperAixsName) == 0 && sta == false)
                                    {
                                        ctTimer.Start();
                                        MiddleAutoRunStepA = AutoRunStep.CCD_左_面线扫开始拍照位;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        //FormStart.LOG_ShowFrom["CCDTaska_左"].Enqueue("CCD_左_面线扫开始拍照位超时报警或移栽1在激光位感应器false异常");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("CCD_左_面线扫开始拍照位超时报警或移栽1在激光位感应器false异常");
                                        //LoadMaterialA = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCD_左_面线扫开始拍照位:
                                    //拍照开始           
                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位激光位安全标志位"].Date == false)
                                        {
                                            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台_线扫完成位);
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位激光位安全标志位"].Date = true;
                                            MiddleAutoRunStepA = AutoRunStep.CCD_左_面线扫到位检测;
                                        }
                                        break;
                                    }               
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位激光位安全标志位"].Date == false)
                                    {
                                        string date = "";
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位激光位安全标志位"].Date = true;
                                        if (CCD_左A_RUN_REL == "")
                                        {
                                            CCD_左RUN_REL = false;
                                            date = "A,Left,Scan," + Pruduct.ToString();
                                            //Weld_Log.Instance().Enqueue("[发送]:"+ CCD_A_RUN_REL);
                                       
                                            CommunicationFun.ClearBuff(CamerStrRun, "Platform");
                                            CommunicationFun.SendDate(CamerStrRun, date, out Date_);
                                            Weld_Log.Instance().Enqueue("[发送]:" + date);
                                            ctTimer.Start();
                                            MiddleAutoRunStepA = AutoRunStep.CCD_左_面线扫到位检测;
                                            //向线扫发送开始命令
                                            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台_线扫完成位);
                                        }
                                        else if(CCD_左A_RUN_REL != ""&& CCD_左B_RUN_REL == "")
                                        {
                                            CCD_左RUN_REL = false;
                                            date = "B,Left,Scan," + Pruduct.ToString();
                                            CommunicationFun.ClearBuff(CamerStrRun, "Platform");
                                            CommunicationFun.SendDate(CamerStrRun, date, out Date_);
                                            Weld_Log.Instance().Enqueue("[发送]:" + date);
                                            ctTimer.Start();
                                            MiddleAutoRunStepA = AutoRunStep.CCD_左_面线扫到位检测;
                                            //向线扫发送开始命令
                                            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台_线扫完成位);
                                        }
                         
                                    }
                                    break;
                                case AutoRunStep.CCD_左_面线扫到位检测:

                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        if (ManageContral.DetectingAxis(CCDTaska_A_AixsName) == 0)
                                        {
                                            ctTimer.Start();
                                            MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_CCD线扫完成;
                                        }
                                        break;
                                    }
                                    if (ManageContral.DetectingAxis(CCDTaska_A_AixsName) == 0)
                                    {
                                        ctTimer.Start();
                                        MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_CCD线扫完成;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        //FormStart.LOG_ShowFrom["CCDTaska_左"].Enqueue("CCD_左载台_线扫完成位超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("CCD_左载台_线扫完成位超时报警");
                                        //LoadMaterialA = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCDTaska_A_CCD线扫完成:
                                    //获取返回结果
                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        if (ManageContral.DetectingAxis(CCDTaska_A_AixsName) == 0)
                                        {
                                            ctTimer.Start();
                                            MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_激光位到位检测;
                                            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台激光清洗位);
                                        }
                                        break;
                                    }
                                    Thread.Sleep(100);
                                    if (CCD_左A_RUN_REL == "")
                                        {
                                        CCD_左A_RUN_REL = CommunicationFun._GetRec(CamerStrRun, "Platform");
                          
                                        if (CCD_左A_RUN_REL != "")
                                        {
                                            Weld_Log.Instance().Enqueue("[接受]:" + CCD_左A_RUN_REL);
                                            string[] _CCD_A_RUN_REL = CCD_左A_RUN_REL.Split('#');
                                            if (_CCD_A_RUN_REL[3].Contains("0"))
                                            {
                                                ctTimer.Start();
                                                FormStart.LOG_ShowFrom["CCDTaska_左"].Enqueue(CCD_左A_RUN_REL);
                                                //NG
                                                //CCD_RUN_REL = true;
                                            }
                                            else
                                            {//OK
                                                CCD_左RUN_REL = true;
                                                FormStart.LOG_ShowFrom["CCDTaska_左"].Enqueue(CCD_左A_RUN_REL);
                                                ctTimer.Start();
                                                //CCD_A_RUN_REL = "";
                                                MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_激光位到位检测;
                                                ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台激光清洗位);
                                            }
                                        }
                                            
                                        }
                                         else if(CCD_左A_RUN_REL != ""&& CCD_左B_RUN_REL == "")
                                    {

                                        CCD_左B_RUN_REL = CommunicationFun._GetRec(CamerStrRun, "Platform");
                                        if (CCD_左B_RUN_REL != "")
                                        {
                                            Weld_Log.Instance().Enqueue("[接受]:" + CCD_左B_RUN_REL);
                                            string[] _CCD_A_RUN_REL = CCD_左B_RUN_REL.Split('#');
                                            if (_CCD_A_RUN_REL[3].Contains("0"))
                                            {
                                                FormStart.LOG_ShowFrom["CCDTaska_左"].Enqueue(CCD_左B_RUN_REL);
                                                //NG
                                                //CCD_B_RUN_REL = "";
                                                //CCD_RUN_REL = true;
                                                MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_激光位到位检测;
                                                ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激光拍照位);
                                                ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台激光清洗位);
                                            }
                                            else
                                            {
                                                CCD_左RUN_REL = true;
                                                FormStart.LOG_ShowFrom["CCDTaska_左"].Enqueue(CCD_左B_RUN_REL);
                                                //OK
                                                ctTimer.Start();
                                                MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_激光位到位检测;
                                                ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激光拍照位);
                                                ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台激光清洗位);
                                            }
                                        }
                                       
                                        }
                                        else if (ctTimer.TimeUp(6))
                                        {
                                        //FormStart.LOG_ShowFrom["CCDTaska_左"].Enqueue("线扫数据接收超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("线扫数据接收超时报警");
                                        //LoadMaterialA = true;
                                        ctTimer.Start();
                                        }
                                  
                                    //数据传入到CCDB工位
                                    break;
                                case AutoRunStep.CCDTaska_A_激光位到位检测:
                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        if (ManageContral.DetectingAxis(CCDTaska_A_AixsName) == 0 && ManageContral.DetectingAxis(LaserAixsName) == 0)
                                        {
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位取料位安全标志位"].Date = false;
                                            MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_打激光拍照;
                                            ctTimer.Start();
                                        }
                                        break;
                                    }
                                    if (ManageContral.DetectingAxis(CCDTaska_A_AixsName) == 0&& ManageContral.DetectingAxis(LaserAixsName) == 0)
                                    {
                                        string date = "";
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位取料位安全标志位"].Date = false;
                                        if (CCD_左A_Laser_REL == "")
                                        {
                                            date = "A,Left,Laser," + Pruduct.ToString();
                                            CommunicationFun.ClearBuff(CamerStrRun, "Laser");
                                            CommunicationFun.SendDate(CamerStrRun, date, out Date_);
                                            Weld_Log.Instance().Enqueue("[发送]:" + date);
                                            ctTimer.Start();
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位取料位安全标志位"].Date = false;
                                            MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_打激光拍照;
                                        }
                                        else if(CCD_左A_Laser_REL != ""&& CCD_左B_Laser_REL == "")
                                        {
                                            date = "B,Left,Laser," + Pruduct.ToString();
                                            CommunicationFun.ClearBuff(CamerStrRun, "Laser");
                                            CommunicationFun.SendDate(CamerStrRun, date, out Date_);
                                            Weld_Log.Instance().Enqueue("[发送]:" + date);
                                            ctTimer.Start();
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位取料位安全标志位"].Date = false;
                                            MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_打激光拍照;
                                        }
                                
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                        //LoadMaterialA = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCDTaska_A_打激光拍照:

                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_打激光开始拍照;
                                        break;
                                    }
                                    Thread.Sleep(100);
                                    if (CCD_左A_Laser_REL == "")
                                    {
                                        CCD_左A_Laser_REL = CommunicationFun._GetRec(CamerStrRun, "Laser");
                                   
                                        if (CCD_左A_Laser_REL != "")
                                        {
                                            Weld_Log.Instance().Enqueue("[接受]:" + CCD_左A_Laser_REL);
                                            string[] _CCD_A_Laser_REL = CCD_左A_Laser_REL.Split(',');
                                            if (_CCD_A_Laser_REL[4] == "NG")
                                            {
                                                //NG
                                            }
                                            else
                                            {
                                                MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_打激光开始拍照;
                                                //OK;

                                            }
                                        }
                                     

                                    }
                                    else if (CCD_左A_Laser_REL != "" && CCD_左B_Laser_REL == "")
                                    {
                                        CCD_左B_Laser_REL = CommunicationFun._GetRec(CamerStrRun, "Laser");
                                        if (CCD_左B_Laser_REL != "")
                                        {
                                            Weld_Log.Instance().Enqueue("[接受]:" + CCD_左B_Laser_REL);

                                            string[] _CCD_B_Laser_REL = CCD_左B_Laser_REL.Split(',');
                                        if (_CCD_B_Laser_REL[4] == "NG")
                                        {
                                            //NG
                                        }
                                        else
                                        {
                                            MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_打激光开始拍照;
                                            //OK;

                                        }
                                        }
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                        //LoadMaterialA = true;
                                        ctTimer.Start();
                                    }
                          
                                    break;
                                case AutoRunStep.CCDTaska_A_打激光开始拍照:

                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        if (/*CCD_左RUN_REL == true &&*/ ManageContral.DetectingAxis(LaserAixsName) == 0)
                                        {
                                            MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_开始打激光;
                                        }                                    
                                        break;
                                    }
                                    if (CCD_左RUN_REL == true&& ManageContral.DetectingAxis(LaserAixsName) == 0)
                                    {
                                        //线扫失败                      
                                        MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_开始打激光;
                                    }
                                    else
                                    {
                                        ctTimer.Start();
                                        //拍照   ctTimer.Start();
                                        MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_开始打激光;
                                        //获取拍照结果
                                        CCD_POSITION_RES = "";

                                    }
                                    break;
                                case AutoRunStep.CCDTaska_A_开始打激光:
                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_打激光完成;
                                        break;
                                    }
                                    if (CCD_左RUN_REL == true)
                                    {
                                        //线扫失败                      
                                        MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_打激光完成;
                                    }
                                   else
                                    {
                                        MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_打激光完成;
                                        //打激光

                                    }
                                
                                    break;
                                    //CCD_右载台激光喷码位安全标志位
                                case AutoRunStep.CCDTaska_A_打激光完成:

                                    //if (Properties.Settings.Default.空跑 == true)
                                    //{
                                    //    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台激光喷码位安全标志位"].Date == false)
                                    //    {
                                    //        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date = true;


                                    //        MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_到喷码位;
                                    //        ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左到喷码位);
                                    //        ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.喷码拍照位);
                                    //    }
                                    //    break;
                                    //}
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台激光喷码位安全标志位"].Date == false)
                                    {
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date = true;

                            
                                        MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_到喷码位;
                                        ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左到喷码位);
                                        ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.喷码拍照位);
                                    }
                                    break;

                                case AutoRunStep.CCDTaska_A_到喷码位:

                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        if (ManageContral.DetectingAxis(CCDTaska_A_AixsName) == 0 && ManageContral.DetectingAxis(LaserAixsName) == 0)
                                        {         
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位激光位安全标志位"].Date = false;
                                            MiddleAutoRunStepA = AutoRunStep.CCD_喷码拍照;
                                        }
                                        break;
                                    }
                                    if (ManageContral.DetectingAxis(CCDTaska_A_AixsName) == 0 && ManageContral.DetectingAxis(LaserAixsName) == 0)
                                    {
                                        string date = "";
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位激光位安全标志位"].Date = false;
                                        if (CCD_左RUN_REL == true)
                                        {
                                            if (CCD_左A_Print_REL == "")
                                            {
                                                date = "A,Left,Print," + Pruduct.ToString();
                                                CommunicationFun.ClearBuff(CamerStrRun, "Print");
                                                CommunicationFun.SendDate(CamerStrRun, date, out Date_);
                                                Weld_Log.Instance().Enqueue("[发送]:" + date);
                                                ctTimer.Start();
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位激光位安全标志位"].Date = false;
                                                MiddleAutoRunStepA = AutoRunStep.CCD_喷码拍照;
                                            }
                                            else if (CCD_左A_Print_REL != "" && CCD_左B_Print_REL == "")
                                            {
                                                date = "B,Left,Print," + Pruduct.ToString();
                                                CommunicationFun.ClearBuff(CamerStrRun, "Print");
                                                CommunicationFun.SendDate(CamerStrRun, date, out Date_);
                                                Weld_Log.Instance().Enqueue("[发送]:" + date);
                                                ctTimer.Start();
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位激光位安全标志位"].Date = false;
                                                MiddleAutoRunStepA = AutoRunStep.CCD_喷码拍照;
                                            }
                                            //Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位激光位安全标志位"].Date = false;
                                            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位激光位安全标志位"].Date = false;
                                            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台下料位安全标志位"].Date = true;
                                            //ctTimer.Start();
                                            ////向相机发送喷码位拍照启动信号
                                            //MiddleAutoRunStepA = AutoRunStep.CCD_喷码拍照;
                                        }
                                        else if (ctTimer.TimeUp(6))
                                        {
                                            //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                            //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                            //LoadMaterialA = true;
                                            ctTimer.Start();
                                        }
                                    }
                                    else
                                    {
                                      //  MiddleAutoRunStepA = AutoRunStep.CCD_喷码完成;
                                    }
                                    break;
                                case AutoRunStep.CCD_喷码拍照:
                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        MiddleAutoRunStepA = AutoRunStep.CCD_喷码完成;
                                        break;
                                    }
                                    Thread.Sleep(100);
                                    if (CCD_左A_Print_REL == "")
                                    {
                                        CCD_左A_Print_REL = CommunicationFun._GetRec(CamerStrRun, "Print");
                                        if (CCD_左A_Print_REL != "")
                                        {
                                            Weld_Log.Instance().Enqueue("[接受]:" + CCD_左A_Print_REL);
                                            string[] _CCD_A_Laser_REL = CCD_左A_Print_REL.Split(',');
                                            if (_CCD_A_Laser_REL[4] == "NG")
                                            {
                                                //NG
                                            }
                                            else
                                            {
                                                MiddleAutoRunStepA = AutoRunStep.CCD_喷码完成;
                                                //OK;

                                            }
                                        }
                                        

                                    }
                                    else if (CCD_左A_Print_REL != "" && CCD_左B_Print_REL == "")
                                    {
                                        CCD_左B_Print_REL = CommunicationFun._GetRec(CamerStrRun, "Print");
                                        if (CCD_左B_Print_REL != "")
                                        {
                                            Weld_Log.Instance().Enqueue("[接受]:" + CCD_左B_Print_REL);
                                            string[] _CCD_B_Print_REL = CCD_左B_Print_REL.Split(',');
                                            if (_CCD_B_Print_REL[4] == "NG")
                                            {
                                                //NG
                                            }
                                            else
                                            {
                                                MiddleAutoRunStepA = AutoRunStep.CCD_喷码完成;
                                                //OK;

                                            }

                                        }
                                     
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        ctTimer.Start();
                                        MiddleAutoRunStepA = AutoRunStep.CCD_喷码开始;
                                        CCD_POSITION_RES = "";
                                    }

                                    ////获取拍照结果      
                                    //if (CCD_RUN_REL == true)
                                    //{
                                    //    //线扫失败                      
                                    //    MiddleAutoRunStepA = AutoRunStep.CCD_喷码完成;
                                    //}
                                    //else
                                    //{
                                    //    //打激光
                                    //    ctTimer.Start();
                                    //    MiddleAutoRunStepA = AutoRunStep.CCD_喷码开始;
                                    //    CCD_POSITION_RES = "";
                                    //}                                            
                                    break;
                                case AutoRunStep.CCD_喷码开始:                           
                                    MiddleAutoRunStepA = AutoRunStep.CCD_喷码完成;                       
                                    break;
                                case AutoRunStep.CCD_喷码完成:
                                    sta = ManageContral.GetInOn("移栽1在喷码位");
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台下料位安全标志位"].Date == false&& sta== false)
                                    {
                                  
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台下料位安全标志位"].Date = true;
                                           ctTimer.Start();
                                        ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台下料位);
                                        MiddleAutoRunStepA = AutoRunStep.CCD_到下料位;
                                    }
                                    break;
                                case AutoRunStep.CCD_到下料位:
                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        if (ManageContral.DetectingAxis(CCDTaska_A_AixsName) == 0)
                                        {
                                            if (ChooseA == "翻转")
                                            {
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date = false;
                                                if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date == false && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date == false)
                                                {

                                                    ctTimer.Start();
                                                    MiddleAutoRunStepA = AutoRunStep.CCD_翻转B面;
                                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = true;
                                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = false;

                                                }

                                            }
                                            else 
                                            {
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date = false;
                                                if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date == false && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date == false )
                                                {

                                                    ctTimer.Start();
                                                    MiddleAutoRunStepA = AutoRunStep.CCD_开始下料;
                                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = true;
                                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = false;

                                                }
                                            }
                                        }
                                        break;
                                    }
                                    if (ManageContral.DetectingAxis(CCDTaska_A_AixsName) == 0)
                                    {
                                        if (CCD_左RUN_REL == false)
                                        {
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date = false;
                                            //NG直接排料
                                            if (CCD_左A_RUN_REL != "" && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date == false && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date == false)
                                            {
                                                ctTimer.Start();
                                                MiddleAutoRunStepA = AutoRunStep.CCD_开始下料;
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = false;
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = false;
                                            }
                                        }
                                        else
                                        { 
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date = false;
                                        if (CCD_左A_RUN_REL == ""&& (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date == false && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date == false)
                                        {
                                            ctTimer.Start();
                                            MiddleAutoRunStepA = AutoRunStep.CCD_翻转B面;
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = false;
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = false;
                                        }
                                        else if(CCD_左A_RUN_REL != "" && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date == false && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date == false)
                                        {
                                            ctTimer.Start();
                                            MiddleAutoRunStepA = AutoRunStep.CCD_开始下料;
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = false;
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = false;
                                        }
                                        }
                                    }
                                    break;
                                case AutoRunStep.CCD_翻转B面:
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date == false)
                                    {
                                        MiddleAutoRunStepA = AutoRunStep.CCDB_到下料位;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCD_开始下料:
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date == false)
                                    {

                                        MiddleAutoRunStepA = AutoRunStep.CCD_开始下料检测;
                                        //MiddleAutoRunStepA = AutoRunStep.CCD_A放回载盘完成;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCD_开始下料检测:                            
                                        MiddleAutoRunStepA = AutoRunStep.CCDB_到下料位;
                                        ctTimer.Start();
                                    break;
     
                                case AutoRunStep.CCDB_到下料位:
                                    sta = ManageContral.GetInOn("移栽1在喷码位");
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台下料位安全标志位"].Date == false && sta == false)
                                    {
                                        ctTimer.Start();
                                        MiddleAutoRunStepA = AutoRunStep.CheckData;
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date = false;
                                    }
                                    break;
                                case AutoRunStep.CheckData:                      
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = false;
                                        ManageContral.SetOutBit("移栽平台2气缸", false);
                                        MiddleAutoRunStepA = AutoRunStep.CheckIO;
                                    break;
                                case AutoRunStep.CheckIO:
                                    sta = ManageContral.GetInOn("移栽2气缸下");
                                    if (sta == true )
                                    {
                                        if (CCD_左A_RUN_REL != "" && CCD_左B_RUN_REL != "")
                                        {
                                            CCD_左A_RUN_REL = "";
                                            CCD_左B_RUN_REL = "";
                                        }
                                        if (CCD_左A_Laser_REL != "" && CCD_左B_Laser_REL != "")
                                        {
                                            CCD_左A_Laser_REL = "";
                                            CCD_左B_Laser_REL = "";

                                        }
                                        if (CCD_左A_Print_REL != "" && CCD_左B_Print_REL != "")
                                        {
                                            CCD_左A_Print_REL = "";
                                            CCD_左B_Print_REL = "";

                                        }
                                        MiddleAutoRunStepA = AutoRunStep.Idle;
                                        Pruduct++;
                                        ctTimer.Start();
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {                                 
                                        ctTimer.Start();
                                    }              
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               // Program.MiddleTaskRunC = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">要转换的坐标x值</param>
        /// <param name="y">要转换的坐标y值</param>
        /// <param name="mappingX"></param>
        /// <param name="mappingY"></param>
        private void MappingPos1(double x, double y, ref double mappingX, ref double mappingY)
        {
            double x1 = DateSave.Instance().Production.右激光位置到喷码位置矩阵A * x
                + DateSave.Instance().Production.右激光位置到喷码位置矩阵B * y
                + DateSave.Instance().Production.右激光位置到喷码位置矩阵TX;
            mappingX = x1;
            double y1 = DateSave.Instance().Production.右激光位置到喷码位置矩阵C * x
                + DateSave.Instance().Production.右激光位置到喷码位置矩阵D * y
                + DateSave.Instance().Production.右激光位置到喷码位置矩阵TY;
            mappingY = y1;

          
        }
    }

}

