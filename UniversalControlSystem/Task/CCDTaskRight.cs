using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{ 
    public class CCDTaska_Right
    {
        private HiPerfTimer ctTimer = new HiPerfTimer();
        private object lockObj = new object();
        int Result;
        //RunClass RunCls = new RunClass();
        //public AutoRunStep MiddleAutoRunStepA = new AutoRunStep();
        public AutoRunStep MiddleAutoRunStepB = new AutoRunStep();
        Stopwatch stopwatch = new Stopwatch();
        HiperTimer HipMiddleTaskRunOutGlue = new HiperTimer();
        FormStart m_formStart = new FormStart();
        string CCDTaska_B_AixsName = "喷码载盘右";
        string LoadPaperAixsName = "取料轴Y";
        string LaserAixsName = "激光Y轴";
        string Ari_Brush_AixsName = "拍照补偿轴";
        string 下料AixsName = "下料X轴";
        public bool _CCDTaska_B = false;
        public bool LoadMaterialB = false;
        public string CCD_POSITION_RES = "";//拍照位置返回结果
        /// <summary>
        /// CCDB拍照结果
        /// </summary>
        public string CCD_右B_RUN_REL = "";
        public string CCD_右A_RUN_REL = "";
        public string CCD_右B_Laser_REL = "";
        public string CCD_右A_Laser_REL = "";
        public string CCD_右B_Print_REL = "";
        public string CCD_右A_Print_REL = "";
        public string CCD_右B_Check_REL = "";
        public string CCD_右A_Check_REL = "";
        public int CCDB_Count = 0;
        public bool CCD_RUN_REL = false;
        int CamerCountNG = 0;
        string CamerStrRun = "线扫";
        int Pruduct = 0;//产品序号
        string A_OR_B_Str = "";
        string _Date = "";
        string ChooseB = "下料";
        public void ProcessA()
        {
            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位取料位安全标志位"].Date = true;
            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位取料位安全标志位"].Date = false;
            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光清洗位安全标志位"].Date = false;
            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台激光清洗位安全标志位"].Date = false;
            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date = false;
            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台激光喷码位安全标志位"].Date = false;
            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台下料位安全标志位"].Date = false;
            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台下料位安全标志位"].Date = false;
            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台_待机位安全标志位"].Date = false;
            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台_待机位安全标志位"].Date = false;
            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCDTaska_A运行标志位"].Date = false;

            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位激光位安全标志位"].Date = false;
            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位激光位安全标志位"].Date = false;



            ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料运动标志位"].Date = true;





      
            bool sta = false;
            try
            {
                while (true)
                {
                    Thread.Sleep(50);
                    lock (lockObj)
                    {
                        if (!Program.bAuto || Program.bStop || Program.bEStop || _CCDTaska_B == true)
                        {
                            // FormStart.m_CCDTaskTaskA.MiddleAutoRunStepA = 0;
                        }
                        else
                        {

                            switch (MiddleAutoRunStepB)
                            {
                                case AutoRunStep.Idle:
                                    //流程的预准备
                                    //ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, 0);
                                    MiddleAutoRunStepB = AutoRunStep.CCDTaska_上料轴待机位;
                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台下料位安全标志位"].Date = false;
                                    break;
                                case AutoRunStep.CCDTaska_上料轴待机位:
                                    //if (ManageContral.DetectingAxis(CCDTaska_B_AixsName) == 0)
                                    //{
                                        ctTimer.Start();
                                    MiddleAutoRunStepB = AutoRunStep.RunStart;
                                    FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("CCD_右载台_开始运行");
                                    //}
                                    //else if (ctTimer.TimeUp(6))
                                    //{
                                    //    //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴待机位超时报警");
                                    //    //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴待机位超时报警");
                                    //    //LoadMaterialB = true;
                                    //    ctTimer.Start();
                                    //}
                                    break;
                                case AutoRunStep.RunStart:
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位取料位安全标志位"].Date == false && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料运动标志位"].Date == true)
                                    {
                                        ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台_待机位);
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位取料位安全标志位"].Date = true;
                                        FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("CCD_右载台_待机位");
                                        MiddleAutoRunStepB = AutoRunStep.CCDTaska_左气缸上升检测;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCDTaska_左气缸上升检测:
                                   
                                    if ( ManageContral.DetectingAxis(CCDTaska_B_AixsName) == 0)
                                    {
                                        FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("CCD_右载台_待机位完成");
                                        ManageContral.SetOutBit("移栽平台1气缸", true);
                                        FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("移栽平台1气缸——true");
                                        MiddleAutoRunStepB = AutoRunStep.CCD_左_面判断是否放料;
                                        ctTimer.Start();
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        //FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("移栽1气缸上信号超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("移栽1气缸上信号超时报警");
                                        //LoadMaterialB = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCD_左_面判断是否放料:
                                    //选择走双面还是走单面
                                    sta = ManageContral.GetInOn("移栽1气缸上");
                                    if (true)
                                    {
                                        ////判断
                                        if (CCD_右A_RUN_REL == "" /*&& CCD_B_RUN_REL == ""*/)
                                        {
                                            if (sta == true && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料运动标志位"].Date == true)
                                            {
                                                FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("上料运动标志位——true");
                                                //Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料运动标志位"].Date = false;
                                                sta = ManageContral.GetInOn("移栽2气缸上");
                                                if (sta == true)
                                                {
                                                    FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("移栽2气缸上——true");
                                                    ManageContral.AxisPMoveAbsoluteToStop(LoadPaperAixsName, DateSave.Instance().Production.上料轴放料位);
                                                    ManageContral.SetOutBit("移栽平台1气缸", true);
                                                    MiddleAutoRunStepB = AutoRunStep.CCDTaska_上料轴放料位;
                                                    ctTimer.Start();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("CCD_左_面线扫开始拍照位");
                                            MiddleAutoRunStepB = AutoRunStep.CCD_左_面线扫开始拍照位;
                                        }
                                        //////判断
                                        ////if (CCD_A_RUN_REL == "" /*&& CCD_B_RUN_REL == ""*/)
                                        ////{
                                        //if (sta == true && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料运动标志位"].Date == true)
                                        //{
                                        ////   Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料运动标志位"].Date = false;

                                        //    //sta = ManageContral.GetInOn("移栽1气缸上");
                                        //    //if (sta == true)
                                        //    //{
                                        //    ManageContral.AxisPMoveAbsoluteToStop(LoadPaperAixsName, DateSave.Instance().Production.上料轴放料位);
                                        //    ManageContral.SetOutBit("移栽平台1气缸", true);
                                        //    MiddleAutoRunStepA = AutoRunStep.CCDTaska_上料轴放料位;
                                        //    ctTimer.Start();
                                        //    //}
                                        //}
                                   
                                    }
                                    else
                                    {
                                    }
                                    break;
                                case AutoRunStep.CCDTaska_上料轴放料位:
                                    sta = ManageContral.GetInOn("移栽1气缸上");
                                    if (ManageContral.DetectingAxis(LoadPaperAixsName) == 0&& sta==true)
                                    {
                                        FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("上料吸板气缸——true");
                                        ctTimer.Start();
                                        ManageContral.SetOutBit("上料吸板气缸", true);
                                        MiddleAutoRunStepB = AutoRunStep.CCD_左_面开始检测是否下料;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        //FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                        //LoadMaterialB = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCD_左_面开始检测是否下料:
                                    sta = ManageContral.GetInOn("上料吸板气缸下");
                                    if (sta == true)
                                    {
                                        FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("上料吸板气缸下——true");
                                        ctTimer.Start();
                                        MiddleAutoRunStepB = AutoRunStep.CCDTaska_左破真空;
                                    }
                                    else if (ctTimer.TimeUp(3))
                                    {
                                        ctTimer.Start();
                                        //FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("CCDTaska_A_上料吸板气缸下超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("CCDTaska_A_上料吸板气缸下超时报警");
                                        //LoadMaterialB = true;
                                    }
                                    break;
                                case AutoRunStep.CCDTaska_左破真空:
                                    Thread.Sleep(300);
                                    FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("上料吸板气缸——false");
                                    ManageContral.SetOutBit("上料吸板气缸", false);
                                    FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("右移栽定位气缸1——true");
                                    ManageContral.SetOutBit("右移栽定位气缸1", true);
                                    FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("右移栽定位气缸2——true");
                                    ManageContral.SetOutBit("右移栽定位气缸2", true);

                                    MiddleAutoRunStepB = AutoRunStep.CCDTaska_左气缸上升检测到位;
                                    ctTimer.Start();
                                    break;
                                case AutoRunStep.CCDTaska_左气缸上升检测到位:
                                    sta = ManageContral.GetInOn("上料吸板气缸上");
                                    if (sta == true)
                                    {
                                        FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("上料吸板气缸上——true");
                                        //继续取料
                                      //  FormStart.LoadPaperStep.MiddleAutoRunStepA = AutoRunStep.Idle;
                                        FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("上料轴继续取料");
                                        ctTimer.Start();
                                        MiddleAutoRunStepB = AutoRunStep.CCDTaska_左气缸夹料;
                                        FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("CCDTaska_左气缸夹料");
                                    }
                                    else if (ctTimer.TimeUp(3))
                                    {
                                        ctTimer.Start();
                                        //ctTimer.Start();
                                        //FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("CCDTaska_A_上料吸板气缸下超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("CCDTaska_A_上料吸板气缸下超时报警");
                                        //LoadMaterialB = true;
                                    }
                                    break;
                                case AutoRunStep.CCDTaska_左气缸夹料:
                                    ctTimer.Start();
                                    FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("移栽平台1气缸——true");
                                    ManageContral.SetOutBit("移栽平台1气缸", true);
                                    ManageContral.AxisPMoveAbsoluteToStop(LoadPaperAixsName, DateSave.Instance().Production.上料轴中转位);
                                    MiddleAutoRunStepB = AutoRunStep.CCDTaska_左气缸夹料到位检测;
                                    break;
                                case AutoRunStep.CCDTaska_左气缸夹料到位检测:
                                    sta = ManageContral.GetInOn("移栽1有料");

                                    //sta = ManageContral.GetInOn("上料吸板气缸上");
                                    if (sta != true)
                                    {
                                        ctTimer.Start();

                                        MiddleAutoRunStepB = AutoRunStep.CCD_左_上料轴待机位;
                                    }
                                    else if (ctTimer.TimeUp(3))
                                    {
                                        ctTimer.Start();
                                        FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("CCDTaska_A_移栽1有料感应器超时报警");
                                        MainForm.m_formAlarm.InsertAlarmMessage("CCDTaska_A_移栽1有料感应器超时报警");
                                        LoadMaterialB = true;
                                    }
                                    break;
                                case AutoRunStep.CCD_左_上料轴待机位:

                                    if (ManageContral.DetectingAxis(LoadPaperAixsName) == 0)
                                    {
                                        ctTimer.Start();
                                        //ManageContral.SetOutBit("上料吸板气缸", true);
                                        MiddleAutoRunStepB = AutoRunStep.CCD_左_上料轴待机位到位检测;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("上料轴中转位超时报警");
                                        MainForm.m_formAlarm.InsertAlarmMessage("上料轴中转位超时报警");
                                        LoadMaterialB = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCD_左_上料轴待机位到位检测:
                                    if (ManageContral.DetectingAxis(LoadPaperAixsName) == 0)
                                    {
                                        ctTimer.Start();
                                        //ManageContral.SetOutBit("上料吸板气缸", true);
                                        MiddleAutoRunStepB = AutoRunStep.CCD_左_面线扫开始拍照位;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        //FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("CCD_左_上料轴待机位到位检测超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("CCD_左_上料轴待机位到位检测超时报警");
                                        //LoadMaterialB = true;
                                        ctTimer.Start();
                                    }
                                    break;


                                case AutoRunStep.CCD_左_面线扫开始拍照位:
                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位激光位安全标志位"].Date == false && sta == false)
                                        {
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位激光位安全标志位"].Date = true;         
                                            MiddleAutoRunStepB = AutoRunStep.CCD_左_面线扫到位检测;
                                        }
                                        break;
                                    }
                                    //拍照开始
                                    sta = ManageContral.GetInOn("移栽1在激光位");
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位激光位安全标志位"].Date == false && sta == false)
                                    {
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位激光位安全标志位"].Date = true;
                                        string date = "";
                                        if (CCD_右A_RUN_REL == "")
                                        {
                                            CCD_RUN_REL = false;
                                            date = "A,Right,Scan," + Pruduct.ToString();
                                            CommunicationFun.ClearBuff(CamerStrRun, "Platform");
                                            CommunicationFun.SendDate(CamerStrRun, date, out date);
                                            Weld_Log.Instance().jp_writeLogWithLevel( LOG_LEVEL.LEVEL_1, "发送：" + date);
                                            ctTimer.Start();
                                            MiddleAutoRunStepB = AutoRunStep.CCD_左_面线扫到位检测;
                                            //向线扫发送开始命令
                                            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台_线扫完成位);
                                        }
                                        else if (CCD_右A_RUN_REL != ""&& CCD_右B_RUN_REL == "")
                                        {
                                            CCD_RUN_REL = false;
                                            date = "B,Right,Scan," + Pruduct.ToString();
                                            CommunicationFun.ClearBuff(CamerStrRun, "Platform");
                                            CommunicationFun.SendDate(CamerStrRun, date, out date);
                                            Weld_Log.Instance().jp_writeLogWithLevel(LOG_LEVEL.LEVEL_1, "发送：" + date);
                                            ctTimer.Start();
                                            MiddleAutoRunStepB = AutoRunStep.CCD_左_面线扫到位检测;
                                            //向线扫发送开始命令
                                            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台_线扫完成位);
                                        }

                                        //ctTimer.Start();
                                        ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料左工位激光位安全标志位"].Date = true;
                                        //MiddleAutoRunStepA = AutoRunStep.CCD_左_面线扫到位检测;
                                        ////向线扫发送开始命令

                                        //ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台_线扫完成位);
                                    }

                                    break;
                                case AutoRunStep.CCD_左_面线扫到位检测:
                                    if (ManageContral.DetectingAxis(CCDTaska_B_AixsName) == 0)
                                    {

                                        MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_CCD线扫完成;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        //FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("CCD_右载台_线扫完成位超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("CCD_右载台_线扫完成位超时报警");
                                        //LoadMaterialB = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCDTaska_A_CCD线扫完成:
                                    //获取返回结果
                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                            MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_激光位到位检测;
                                            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台激光清洗位);
                               
                                        break;
                                    }
                                    Thread.Sleep(100);
                                    if (CCD_右A_RUN_REL == "")
                                    {
                                        CCD_右A_RUN_REL = CommunicationFun._GetRec(CamerStrRun, "Platform");
                                        if (CCD_右A_RUN_REL != "")
                                        {
                                            Weld_Log.Instance().jp_writeLogWithLevel(LOG_LEVEL.LEVEL_1, "接受：" + CCD_右A_RUN_REL);
                                            string[] _CCD_A_RUN_REL = CCD_右A_RUN_REL.Split('#');
                                            if (_CCD_A_RUN_REL[3].Contains("0"))
                                            {
                                                ctTimer.Start();
                                                FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue(CCD_右A_RUN_REL);
                                                //NG
                                                //CCD_RUN_REL = true;
                                            }
                                            else
                                            {//OK
                                                CCD_RUN_REL = true;
                                                FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue(CCD_右A_RUN_REL);
                                                ctTimer.Start();
                                                //CCD_A_RUN_REL = "";
                                                MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_激光位到位检测;
                                                ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台激光清洗位);
                                            }

                                        }
                                      
                                    }
                                    else if (CCD_右A_RUN_REL != "" && CCD_右B_RUN_REL == "")
                                    {
                                        CCD_右B_RUN_REL = CommunicationFun._GetRec(CamerStrRun, "Platform");
                                        if (CCD_右B_RUN_REL != "")
                                        {
                                            Weld_Log.Instance().jp_writeLogWithLevel(LOG_LEVEL.LEVEL_1, "接受：" + CCD_右B_RUN_REL);
                                            string[] _CCD_A_RUN_REL = CCD_右B_RUN_REL.Split('#');
                                            if (_CCD_A_RUN_REL[3].Contains("0"))
                                            {
                                                FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue(CCD_右B_RUN_REL);
                                                //NG
                                                //CCD_B_RUN_REL = "";
                                                //CCD_RUN_REL = true;
                                                MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_激光位到位检测;
                                                ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激光拍照位);
                                                ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台激光清洗位);
                                            }
                                            else
                                            {
                                                CCD_RUN_REL = true;
                                                FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue(CCD_右B_RUN_REL);
                                                //OK
                                                ctTimer.Start();
                                                MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_激光位到位检测;
                                                ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激光拍照位);
                                                ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台激光清洗位);
                                            }

                                        }
                                   
                                    }
                                    else if (ctTimer.TimeUp(10))
                                    {
                                        //FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("线扫数据接收超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("线扫数据接收超时报警");
                                        //LoadMaterialB = true;
                                        ctTimer.Start();
                                    }





                                    //if (CCD_A_RUN_REL == "")
                                    //{
                                    //    CCD_A_RUN_REL = CommunicationFun._GetRec(CamerStrRun, "Platform");
                                    //    string[] _CCD_A_RUN_REL = CCD_A_RUN_REL.Split('#');
                                    //    if (_CCD_A_RUN_REL[3].Contains("0"))
                                    //    {
                                    //        //NG
                                    //        CCD_RUN_REL = true;
                                    //        FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("CCD_右载台_线扫A面数据NG");
                                    //        MainForm.m_formAlarm.InsertAlarmMessage("CCD_右载台_线扫失败A面数据NG");
                                    //        LoadMaterialB = true;
                                    //        ctTimer.Start();
                                    //    }
                                    //    else
                                    //    {//OK
                                    //        ctTimer.Start();
                                    //        //CCD_A_RUN_REL = "";
                                    //        MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_激光位到位检测;
                                    //        ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台激光清洗位);
                                    //    }
                                    //}
                                    //else
                                    //{
                                    //    CCD_B_RUN_REL = CommunicationFun._GetRec(CamerStrRun, "Platform");
                                    //    string[] _CCD_A_RUN_REL = CCD_B_RUN_REL.Split('#');
                                    //    if (_CCD_A_RUN_REL[3].Contains("0"))
                                    //    {
                                    //        FormStart.LOG_ShowFrom["CCDTaska_右"].Enqueue("CCD_右载台_线扫B面数据NG");
                                    //        MainForm.m_formAlarm.InsertAlarmMessage("CCD_右载台_线扫失败B面数据NG");
                                    //        LoadMaterialB = true;
                                    //        //NG
                                    //        CCD_B_RUN_REL = "";
                                    //        CCD_RUN_REL = true;
                                    //        MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_激光位到位检测;
                                    //        ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台激光清洗位);
                                    //    }
                                    //    else
                                    //    {
                                    //        //OK
                                    //        ctTimer.Start();
                                    //        MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_激光位到位检测;
                                    //        ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台激光清洗位);
                                    //    }
                                    //}
                                    //数据传入到CCDB工位
                                    break;
                                case AutoRunStep.CCDTaska_A_激光位到位检测:
                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        if (ManageContral.DetectingAxis(CCDTaska_B_AixsName) == 0 && ManageContral.DetectingAxis(LaserAixsName) == 0)
                                        {
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位取料位安全标志位"].Date = false;
                                            MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_打激光拍照;
                                        }                                     
                                        break;
                                    }

                                    if (ManageContral.DetectingAxis(CCDTaska_B_AixsName) == 0&& ManageContral.DetectingAxis(LaserAixsName) == 0)
                                    {
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位取料位安全标志位"].Date = false;
                                        string date = "";
                                        if (CCD_右A_Laser_REL == "")
                                        {
                                            date = "A,Right,Laser," + Pruduct.ToString();
                                            CommunicationFun.ClearBuff(CamerStrRun, "Laser");
                                            CommunicationFun.SendDate(CamerStrRun, date, out _Date);
                                            Weld_Log.Instance().jp_writeLogWithLevel(LOG_LEVEL.LEVEL_1, "发送：" + date);
                                            ctTimer.Start();
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位取料位安全标志位"].Date = false;
                                            MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_打激光拍照;
                                        }
                                        else if (CCD_右A_Laser_REL != "" && CCD_右B_Laser_REL == "")
                                        {
                                            date = "B,Right,Laser," + Pruduct.ToString();
                                            CommunicationFun.ClearBuff(CamerStrRun, "Laser");
                                            CommunicationFun.SendDate(CamerStrRun, date, out _Date);
                                            Weld_Log.Instance().jp_writeLogWithLevel(LOG_LEVEL.LEVEL_1, "发送：" + date);
                                            ctTimer.Start();
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位取料位安全标志位"].Date = false;
                                            MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_打激光拍照;
                                        }
                                        //Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位取料位安全标志位"].Date = false;
                                        //ctTimer.Start();
                                        //MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_打激光拍照;
                                      
                                      
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCDTaska_A_打激光拍照:
                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_打激光开始拍照;
                                        break;
                                    }
                                    Thread.Sleep(100);
                                    if (CCD_右A_Laser_REL == "")
                                    {
                                        CCD_右A_Laser_REL = CommunicationFun._GetRec(CamerStrRun, "Laser");
                                        if (CCD_右A_Laser_REL != "")
                                        {
                                            Weld_Log.Instance().jp_writeLogWithLevel(LOG_LEVEL.LEVEL_1, "接受：" + CCD_右A_Laser_REL);
                                            string[] _CCD_A_Laser_REL = CCD_右A_Laser_REL.Split(',');
                                            if (_CCD_A_Laser_REL[4] == "NG")
                                            {
                                                //NG
                                            }
                                            else
                                            {

                                                MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_打激光开始拍照;
                                                //OK;
                                            }
                                        }
                                    
                                    }
                                    else if (CCD_右A_Laser_REL != "" && CCD_右B_Laser_REL == "")
                                    {
                                        CCD_右B_Laser_REL = CommunicationFun._GetRec(CamerStrRun, "Laser");
                                        if(CCD_右B_Laser_REL != "")
                                        {
                                            string[] _CCD_B_Laser_REL = CCD_右B_Laser_REL.Split(',');
                                            Weld_Log.Instance().jp_writeLogWithLevel(LOG_LEVEL.LEVEL_1, "接受：" + CCD_右A_Laser_REL);
                                            if (_CCD_B_Laser_REL[4] == "NG")
                                            {
                                                //NG
                                            }
                                            else
                                            {

                                                MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_打激光开始拍照;
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

                                    if (ManageContral.DetectingAxis(LaserAixsName) == 0)
                                    {

                                        ctTimer.Start();
                                        //拍照   ctTimer.Start();
                                        MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_开始打激光;
                                        //获取拍照结果
                                        CCD_POSITION_RES = "";
                                    }

                                    break;
                                case AutoRunStep.CCDTaska_A_开始打激光:
                                    if (CCD_RUN_REL == true)
                                    {
                                        //线扫失败                      
                                        MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_打激光完成;
                                    }
                                    else
                                    {
                                        MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_打激光完成;
                                        //打激光

                                    }
                                    break;
                        
                             
                                case AutoRunStep.CCDTaska_A_打激光完成:
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date == false)
                                    {
                                      
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台激光喷码位安全标志位"].Date = true;


                                        MiddleAutoRunStepB = AutoRunStep.CCDTaska_A_到喷码位;
                                        ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右到喷码位);
                                        ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.喷码拍照位);
                                    }


                                    //if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date == false)
                                    //    {
                                    //        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台激光喷码位安全标志位"].Date = true;
                                    //        MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_到喷码位;
                                    //        ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右到喷码位);
                                    //        ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.喷码拍照位);
                                    //    }
                                    break;

                                case AutoRunStep.CCDTaska_A_到喷码位:
                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        if (ManageContral.DetectingAxis(CCDTaska_B_AixsName) == 0 && ManageContral.DetectingAxis(LaserAixsName) == 0)
                                        {
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位激光位安全标志位"].Date = false;
                                            MiddleAutoRunStepB = AutoRunStep.CCD_喷码拍照;
                                        }                                      
                                        break;
                                    }
                                    if (ManageContral.DetectingAxis(CCDTaska_B_AixsName) == 0 && ManageContral.DetectingAxis(LaserAixsName) == 0)
                                    {
                                        string date = "";
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位激光位安全标志位"].Date = false;
                                        if (CCD_RUN_REL == true)
                                        {
                                     
                                            if (CCD_右A_Print_REL == "")
                                            {
                                                date = "A,Right,Print," + Pruduct.ToString();
                                                CommunicationFun.ClearBuff(CamerStrRun, "Print");
                                                Weld_Log.Instance().jp_writeLogWithLevel(LOG_LEVEL.LEVEL_1, "发送：" + date);
                                                for (int i = 0; i < 3; i++)
                                                {
                                                    if (date != "")
                                                    {
                                                        CommunicationFun.SendDate(CamerStrRun, date, out _Date);
                                                        break;
                                                    }
                                                }
                                  
                             
                                                ctTimer.Start();
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位激光位安全标志位"].Date = false;
                                                MiddleAutoRunStepB = AutoRunStep.CCD_喷码拍照;
                                            }
                                            else if (CCD_右A_Print_REL != "" && CCD_右B_Print_REL == "")
                                            {

                                                date = "B,Right,Print," + Pruduct.ToString();
                                                CommunicationFun.ClearBuff(CamerStrRun, "Print");
                                                Weld_Log.Instance().jp_writeLogWithLevel(LOG_LEVEL.LEVEL_1, "发送：" + date);
                                                for (int i = 0; i < 3; i++)
                                                {
                                                    if (date!="")
                                                    {
                                                        CommunicationFun.SendDate(CamerStrRun, date, out _Date);
                                                        break;
                                                    }
                                                }
                                                ctTimer.Start();
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位激光位安全标志位"].Date = false;
                                                MiddleAutoRunStepB = AutoRunStep.CCD_喷码拍照;
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


                                       
                                        ////Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料右工位激光位安全标志位"].Date = false;
                                        //ctTimer.Start();
                                        ////向相机发送喷码位拍照启动信号

                                        //MiddleAutoRunStepA = AutoRunStep.CCD_喷码拍照;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                        //LoadMaterialB = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCD_喷码拍照:
                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        MiddleAutoRunStepB = AutoRunStep.CCD_喷码完成;
                                        break;
                                    }
                                    Thread.Sleep(100);
                                    if (CCD_右A_Print_REL == "")
                                    {
                                        CCD_右A_Print_REL = CommunicationFun._GetRec(CamerStrRun, "Print");
                                        if (CCD_右A_Print_REL != "")
                                        {
                                            Weld_Log.Instance().jp_writeLogWithLevel(LOG_LEVEL.LEVEL_1, "接受：" + CCD_右A_Print_REL);
                                            string[] _CCD_A_Laser_REL = CCD_右A_Print_REL.Split(',');
                                            if (_CCD_A_Laser_REL[4] == "NG")
                                            {
                                                //NG
                                            }
                                            else
                                            {
                                                MiddleAutoRunStepB = AutoRunStep.CCD_喷码完成;
                                                //OK;

                                            }

                                        }
                                      

                                    }
                                    else if (CCD_右A_Print_REL != "" && CCD_右B_Print_REL == "")
                                    {
                                        CCD_右B_Print_REL = CommunicationFun._GetRec(CamerStrRun, "Print");
                                        if (CCD_右B_Print_REL != "")
                                        {
                                            Weld_Log.Instance().jp_writeLogWithLevel(LOG_LEVEL.LEVEL_1, "接受：" + CCD_右B_Print_REL);
                                            string[] _CCD_B_Print_REL = CCD_右B_Print_REL.Split(',');
                                            if (_CCD_B_Print_REL[4] == "NG")
                                            {
                                                //NG
                                            }
                                            else
                                            {
                                                MiddleAutoRunStepB = AutoRunStep.CCD_喷码完成;
                                                //OK;

                                            }
                                        }
                                      
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        ctTimer.Start();
                                        MiddleAutoRunStepB = AutoRunStep.CCD_喷码开始;
                                        CCD_POSITION_RES = "";
                                    }
                                    //获取拍照结果                                
                            
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
                                    MiddleAutoRunStepB = AutoRunStep.CCD_喷码完成;
                                    break;
                                case AutoRunStep.CCD_喷码完成:
                                    sta = ManageContral.GetInOn("移栽1在喷码位");
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台下料位安全标志位"].Date == false/* && sta == true*/)
                                    {

                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台下料位安全标志位"].Date = true;
                                        ctTimer.Start();
                                        ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台下料位);
                                        MiddleAutoRunStepB = AutoRunStep.CCD_到下料位;
                                    }



                                    //ctTimer.Start();
                                    //    ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台下料位);
                                    //    MiddleAutoRunStepA = AutoRunStep.CCD_到下料位;
                                    break;
                                case AutoRunStep.CCD_到下料位:
                                    if (Properties.Settings.Default.屏蔽小车 == true)
                                    {
                                        if (ManageContral.DetectingAxis(CCDTaska_B_AixsName) == 0)
                                        {
                                            if (ChooseB == "翻转")
                                            {
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台激光喷码位安全标志位"].Date = false;
                                                if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date == false && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date == false)
                                                {
                                                    ctTimer.Start();
                                                    MiddleAutoRunStepB = AutoRunStep.CCD_翻转B面;
                                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = true;
                                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = false;
                                                }

                                            }
                                            else
                                            {
                                              if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date == false && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date == false)
                                                {
                                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台激光喷码位安全标志位"].Date = false;
                                                    ctTimer.Start();
                                                    MiddleAutoRunStepB = AutoRunStep.CCD_开始下料;
                                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = true;
                                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = false;
                                                }

                                            }
                                             
                                            
                                        }
                                          
                                        break;
                                    }
                                    if (ManageContral.DetectingAxis(CCDTaska_B_AixsName) == 0)
                                    {
                                        if (CCD_RUN_REL == true)
                                        {
                                            //NG直接排料
                                            if (CCD_右A_RUN_REL != "" && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date == false && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date == false)
                                            {
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date = false;
                                                ctTimer.Start();
                                                MiddleAutoRunStepB = AutoRunStep.CCD_开始下料;
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = false;
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = false;
                                            }
                                        }
                                        else
                                        {
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date = false;
                                            if (CCD_右A_RUN_REL == "" && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date == false && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date == false)
                                            {
                                                ctTimer.Start();
                                                MiddleAutoRunStepB = AutoRunStep.CCD_翻转B面;
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = false;
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = false;
                                            }
                                            else if (CCD_右A_RUN_REL != "" && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date == false && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date == false)
                                            {
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台激光喷码位安全标志位"].Date = false;
                                                ctTimer.Start();
                                                MiddleAutoRunStepB = AutoRunStep.CCD_开始下料;
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = false;
                                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = false;
                                            }
                                        }

                                        //Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台激光喷码位安全标志位"].Date = false;

                                        ////调用翻转方法
                                        //Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = false;
                                        ////FormStart.m_Laying_offTask.OverTurnFun();
                                        //ctTimer.Start();
                                  
                                        //MiddleAutoRunStepA = AutoRunStep.CCD_翻转B面;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                        //LoadMaterialB = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCD_翻转B面:
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date == false)
                                    {
                                        MiddleAutoRunStepB = AutoRunStep.CCDB_到下料位;
                                        ctTimer.Start();
                                    }

                                    break;
                                case AutoRunStep.CCD_开始下料:
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date == false)
                                    {

                                        MiddleAutoRunStepB = AutoRunStep.CCD_开始下料检测;
                                        //MiddleAutoRunStepA = AutoRunStep.CCD_A放回载盘完成;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.CCD_开始下料检测:
                                    MiddleAutoRunStepB = AutoRunStep.CCDB_到下料位;
                                    ctTimer.Start();
                                    break;
                
                                case AutoRunStep.CCDB_到下料位:
                                    sta = ManageContral.GetInOn("移栽1在喷码位");
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_左载台下料位安全标志位"].Date == false && sta == false)
                                    {
                                        ctTimer.Start();
                                        MiddleAutoRunStepB = AutoRunStep.CheckData;
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD_右载台激光喷码位安全标志位"].Date = false;
                                    }
                                    break;
                                case AutoRunStep.CheckData:
                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = false;
                                    ManageContral.SetOutBit("移栽平台1气缸", false);
                                    MiddleAutoRunStepB = AutoRunStep.CheckIO;
                                    //if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date == true)
                                    //{
                                    //Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = false;
                                    //ManageContral.SetOutBit("移栽平台1气缸", false);
                                    //MiddleAutoRunStepA = AutoRunStep.CheckIO;
                                    //     }

                                    break;
                                case AutoRunStep.CheckIO:
                                    sta = ManageContral.GetInOn("移栽1气缸下");
                                    if (sta == true)
                                    {
                                        if (CCD_右A_RUN_REL != "" && CCD_右B_RUN_REL != "")
                                        {
                                            CCD_右A_RUN_REL = "";
                                            CCD_右B_RUN_REL = "";
                                        }
                                        if (CCD_右A_Laser_REL != "" && CCD_右B_Laser_REL != "")
                                        {
                                            CCD_右A_Laser_REL = "";
                                            CCD_右B_Laser_REL = "";

                                        }
                                        if (CCD_右A_Print_REL != "" && CCD_右B_Print_REL != "")
                                        {
                                            CCD_右A_Print_REL = "";
                                            CCD_右B_Print_REL = "";

                                        }
                                        MiddleAutoRunStepB = AutoRunStep.Idle;
                                        Pruduct++;
                                        ctTimer.Start();
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.LOOP:
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD左右继续运行标志位"].Date == true)
                                    {
                                        MiddleAutoRunStepB = AutoRunStep.Reset;

                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD左右继续运行标志位"].Date = false;
                                    }
                                    break;
                                case AutoRunStep.Reset:
                                    MiddleAutoRunStepB = AutoRunStep.Idle;
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
                Program.MiddleTaskRunC = false;
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