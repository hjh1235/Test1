using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    /// <summary>
    ///下料中转搬运
    /// </summary>
    public class TransitShipment
    {
        private HiPerfTimer ctTimer = new HiPerfTimer();
        //public int iStep = 0;
        private object lockObj = new object();
        int Result;
        //RunClass RunCls = new RunClass();
        public AutoRunStep rightAutoRunStepA = new AutoRunStep();
        public AutoRunStep rightAutoRunStepB = new AutoRunStep();
        public AutoRunStep rightAutoRunStepC = new AutoRunStep();
        //FormStart m_formStart = new FormStart();
        string TransitShipment_AixsName = "底部中转Y轴";
        public bool _CCDTaska_B = false;
        /// <summary>
        /// CCDA 拍照结果
        /// </summary>
        public string CCD_A_RUN_REL = "";
        /// <summary>
        /// CCDB拍照结果
        /// </summary>
        public string CCD_B_RUN_REL = "";
        public bool TransitShipmentA = false;
        public void ProcessA()
        {
            //if (!Properties.Settings.Default.bRightIsUsed)
            //    return;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["底部中转Y轴运行标志位"].Date = false;

            try
            {
                while (true)
                {
                    Thread.Sleep(30);
                    lock (lockObj)
                    {
                        if (!Program.bAuto || Program.bStop || Program.bEStop || TransitShipmentA == true)
                        {
                        }
                        else
                        {
                            switch (rightAutoRunStepA)
                            {
                                case AutoRunStep.Idle:
                                    ManageContral.AxisPMoveAbsoluteToStop(TransitShipment_AixsName, DateSave.Instance().Production.分堆底部接料轴待机位);        
                                    rightAutoRunStepA = AutoRunStep.RunDone;
                                    ctTimer.Start();
                                    break;
                                case AutoRunStep.RunDone:
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["底部中转Y轴运行标志位"].Date == true&& ManageContral.DetectingAxis(TransitShipment_AixsName)==0)
                                    {
                                        ManageContral.AxisPMoveAbsoluteToStop(TransitShipment_AixsName, DateSave.Instance().Production.分堆底部接料轴放料位);
                                        rightAutoRunStepA = AutoRunStep.Reset;
                                    }                      
                                    break;
                                case AutoRunStep.Reset:
                                    if (ManageContral.DetectingAxis(TransitShipment_AixsName) == 0)
                                    {
                                        if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["分堆XYZ运行标志位"].Date==false)
                                        {
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["分堆XYZ运行标志位"].Date = true;
                                        }
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
                Program.RightTaskRunFeedingA = false;
            }
        }

    }
    /// <summary>
    /// 下料
    /// </summary>
    public class Laying_off
    {
        private HiPerfTimer ctTimer = new HiPerfTimer();

        //public int iStep = 0;
        private object lockObj = new object();
        private object _lockO = new object();
        int Result;
        //RunClass RunCls = new RunClass();
        public AutoRunStep rightAutoRunStepA = new AutoRunStep();
        public AutoRunStep rightAutoRunStepB = new AutoRunStep();
        public AutoRunStep rightAutoRunStepC = new AutoRunStep();
        public AutoRunStep MiddleAutoRunStepA = new AutoRunStep();
        FormStart m_formStart = new FormStart();
        //string Laying_off_AixsName_X = "下料X轴";
        //string Laying_off_AixsName_Z1 = "下料Z1";
        //string Laying_off_AixsName_Z2 = "下料Z2";
        public bool _CCDTaska_B = false;
        string 下料AixsName = "下料X轴";
        public bool Laying_offA = false;


        /// <summary>
        /// CCDA 拍照结果
        /// </summary>
        public string CCD_A_RUN_REL = "";
        /// <summary>
        /// CCDB拍照结果
        /// </summary>
        public string CCD_B_RUN_REL = "";

        bool sta = false;
        Thread _OverTurn = null;   /// 翻转方法线程
        
             Thread _Laying_off = null;   /// 下料方法线程
        /// <summary>
        /// 翻转方法线程
        /// </summary>
        public void OverTurnFun()
        {
            //_OverTurn = new Thread(OverTurn);
            //_OverTurn.IsBackground = true;
            //_OverTurn.Start();
        }
        /// <summary>
        /// 下料方法线程
        /// </summary>
        public void _Laying_offFun()
        {
            //_Laying_off = new Thread(_Laying_Fun);
            //_Laying_off.IsBackground = true;
            //_Laying_off.Start();
        }
        /// <summary>
        /// 翻转方法
        /// </summary>
        public void OverTurn()
        {
            while (true)
            {
                Thread.Sleep(50);
                lock (lockObj)
                {
                    if (/*!Program.bAuto || Program.bStop || Program.bEStop ||*/ _CCDTaska_B == true)
                    {
                        // FormStart.m_CCDTaskTaskA.MiddleAutoRunStepA = 0;
                    }
                    else
                    {

                        switch (MiddleAutoRunStepA)
                        {
                            case AutoRunStep.Idle:
                                if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date==true)
                                {
                                    ManageContral.AxisPMoveAbsoluteToStop(下料AixsName, DateSave.Instance().Production.下料轴取料位);
                                    ManageContral.DetectingAxis(下料AixsName);
                                    MiddleAutoRunStepA = AutoRunStep.CCD_A下料气缸下降;
                                }
                                break;
                            case AutoRunStep.CCD_A下料气缸下降:
                                ctTimer.Start();
                                ManageContral.SetOutBit("下料上下气缸1", true);
                                ManageContral.SetOutBit("下料旋转气缸2", true);
                                ManageContral.SetOutBit("左移栽定位气缸1", false);
                                ManageContral.SetOutBit("左移栽定位气缸2", false);
                                MiddleAutoRunStepA = AutoRunStep.CCD_A下料气缸下降检测;
                                ctTimer.Start();

                                break;
                            case AutoRunStep.CCD_A下料气缸下降检测:
                                sta = ManageContral.GetInOn("下料上下气缸1下");
                                if (sta == true)
                                {
                                    ctTimer.Start();
                                    ManageContral.SetOutBit("下料真空1", true);
                                    MiddleAutoRunStepA = AutoRunStep.CCD_A下料气缸上升;
                                }
                                else if (ctTimer.TimeUp(6))
                                {
                                    //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                    //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                    //LoadMaterialB = true;
                                    ctTimer.Start();
                                }
                                break;
                            case AutoRunStep.CCD_A下料气缸上升:
                                //sta = ManageContral.GetInOn("下料真空压力1");
                                //if (sta == true)
                                //{
                                ctTimer.Start();
                                ManageContral.SetOutBit("下料上下气缸1", false);
                                MiddleAutoRunStepA = AutoRunStep.CCD_A下料气缸上升检测;
                                //}
                                //else if (ctTimer.TimeUp(6))
                                //{
                                //    //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                //    //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                //    //LoadMaterialB = true;
                                //    ctTimer.Start();
                                //}

                                break;
                            case AutoRunStep.CCD_A下料气缸上升检测:
                                sta = ManageContral.GetInOn("下料上下气缸1上");
                                if (sta == true)
                                {
                                    ctTimer.Start();
                                    MiddleAutoRunStepA = AutoRunStep.CCD_A下料旋转1气缸;
                                }
                                else if (ctTimer.TimeUp(6))
                                {
                                    //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                    //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                    //LoadMaterialB = true;
                                    ctTimer.Start();
                                }

                                break;
                            case AutoRunStep.CCD_A下料旋转1气缸:
                                ctTimer.Start();
                                ManageContral.SetOutBit("下料旋转气缸1", true);
                                MiddleAutoRunStepA = AutoRunStep.CCD_A下料旋转1气缸检测;
                                break;
                            case AutoRunStep.CCD_A下料旋转1气缸检测:
                                sta = ManageContral.GetInOn("下料旋转气缸1转");
                                if (sta == true)
                                {
                                    ctTimer.Start();

                                    ManageContral.AxisPMoveAbsoluteToStop(下料AixsName, DateSave.Instance().Production.翻放位);
                                    ManageContral.SetOutBit("下料左右气缸1", true);
                                    ManageContral.SetOutBit("下料左右气缸2", true);
                                    MiddleAutoRunStepA = AutoRunStep.CCD_A下料伸出1气缸;
                                }
                                else if (ctTimer.TimeUp(6))
                                {
                                    //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                    //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                    //LoadMaterialB = true;
                                    ctTimer.Start();
                                }

                                break;
                            case AutoRunStep.CCD_A下料伸出1气缸:
                                if (ManageContral.DetectingAxis(下料AixsName) == 0)
                                {
                                    ctTimer.Start();
                              
                                    MiddleAutoRunStepA = AutoRunStep.CCD_A下料伸出1气缸检测;
                                }
                                else if (ctTimer.TimeUp(6))
                                {
                                    //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                    //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                    //LoadMaterialB = true;
                                    ctTimer.Start();
                                }

                                break;
                            case AutoRunStep.CCD_A下料伸出1气缸检测:
                                sta = ManageContral.GetInOn("下料左右气缸1后");
                                if (sta == true && ManageContral.GetInOn("下料左右气缸2后"))
                                {
                                    ctTimer.Start();
                                    ManageContral.SetOutBit("下料真空气缸2", true);
                                    MiddleAutoRunStepA = AutoRunStep.CCD_A下料1破2吸;
                                }
                                else if (ctTimer.TimeUp(6))
                                {
                                    //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                    //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                    //LoadMaterialB = true;
                                    ctTimer.Start();
                                }
                                break;
                            case AutoRunStep.CCD_A下料1破2吸:
                                //if (ManageContral.GetInOn("下料真空压力2"))
                                //{
                                ctTimer.Start();
                                ManageContral.SetOutBit("下料真空1", false);
                                MiddleAutoRunStepA = AutoRunStep.CCD_A下料1破2吸检测真空;
                                //}
                                //else if (ctTimer.TimeUp(6))
                                //{
                                //    //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                //    //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                //    //LoadMaterialB = true;
                                //    ctTimer.Start();
                                //}
                                break;
                            case AutoRunStep.CCD_A下料1破2吸检测真空:
                                //if (ManageContral.GetInOn("下料真空压力1") == false && ManageContral.GetInOn("下料真空压力2") == true)
                                //{
                                ctTimer.Start();
                                //ManageContral.SetOutBit("下料真空1", false);
                                MiddleAutoRunStepA = AutoRunStep.CCD_A下料左右回位;
                                //}
                                //else if (ctTimer.TimeUp(6))
                                //{
                                //    //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                //    //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                //    //LoadMaterialB = true;
                                //    ctTimer.Start();
                                //}
                                break;
                            case AutoRunStep.CCD_A下料左右回位:
                                MiddleAutoRunStepA = AutoRunStep.CCD_A下料左右回位到位检测;
                                ctTimer.Start();
                                ManageContral.SetOutBit("下料左右气缸1", false);
                                ManageContral.SetOutBit("下料左右气缸2", false);
                                break;
                            case AutoRunStep.CCD_A下料左右回位到位检测:
                                if (ManageContral.GetInOn("下料左右气缸1前") == false && ManageContral.GetInOn("下料左右气缸2前") == true)
                                {
                                    ctTimer.Start();

                                    MiddleAutoRunStepA = AutoRunStep.CCD_A下旋转1与2回位;
                                }
                                else if (ctTimer.TimeUp(6))
                                {
                                    //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                    //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                    //LoadMaterialB = true;
                                    ctTimer.Start();
                                }
                                break;
                            case AutoRunStep.CCD_A下旋转1与2回位:
                                ctTimer.Start();
                                MiddleAutoRunStepA = AutoRunStep.CCD_A下旋转1与2回位到位检测;
                                ManageContral.SetOutBit("下料旋转气缸1", false);
                                ManageContral.SetOutBit("下料旋转气缸2", false);
                                break;
                            case AutoRunStep.CCD_A下旋转1与2回位到位检测:
                                if (ManageContral.GetInOn("下料旋转气缸1正") == true && ManageContral.GetInOn("下料旋转气缸2正") == true)
                                {

                                    MiddleAutoRunStepA = AutoRunStep.CCD_A放回载盘;
                                }
                                else if (ctTimer.TimeUp(6))
                                {
                                    ctTimer.Start();
                                    //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                    //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                    //LoadMaterialB = true;
                                    ctTimer.Start();
                                }
                                break;
                            case AutoRunStep.CCD_A放回载盘:
                                //到B面放料位
                                ctTimer.Start();
                                ManageContral.AxisPMoveAbsoluteToStop(下料AixsName, DateSave.Instance().Production.翻放位);
                                while (true)
                                {
                                    if (ManageContral.DetectingAxis(下料AixsName) == 0)
                                    {
                                        MiddleAutoRunStepA = AutoRunStep.CCD_A下料上下气缸2下降;
                                        ctTimer.Start();
                                        break;
                                    }
                                }

                                break;
                            case AutoRunStep.CCD_A下料上下气缸2下降:
                                ctTimer.Start();
                                ManageContral.SetOutBit("下料上下气缸2", true);
                                MiddleAutoRunStepA = AutoRunStep.CCD_A下料上下气缸2下降到位检测;
                                break;
                            case AutoRunStep.CCD_A下料上下气缸2下降到位检测:
                                if (ManageContral.GetInOn("下料上下气缸2下") == true)
                                {
                                    ctTimer.Start();
                                    MiddleAutoRunStepA = AutoRunStep.CCD_A下料上下气缸2破真空;
                                }
                                else if (ctTimer.TimeUp(6))
                                {
                                    //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                    //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                    //LoadMaterialB = true;
                                    ctTimer.Start();
                                }
                                break;
                            case AutoRunStep.CCD_A下料上下气缸2破真空:
                                ctTimer.Start();
                                ManageContral.SetOutBit("下料真空气缸2", false);
                                ManageContral.SetOutBit("左移栽定位气缸1", true);
                                ManageContral.SetOutBit("左移栽定位气缸2", true);
                                MiddleAutoRunStepA = AutoRunStep.CCD_A下料上下气缸2破真空检测;
                                break;
                            case AutoRunStep.CCD_A下料上下气缸2破真空检测:
                                if (ManageContral.GetInOn("下料真空压力2") == false)
                                {
                                    ctTimer.Start();

                                    MiddleAutoRunStepA = AutoRunStep.CCD_A下料上下气缸2上升;
                                }
                                else if (ctTimer.TimeUp(6))
                                {
                                    //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                    //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                    //LoadMaterialB = true;
                                    ctTimer.Start();
                                }

                                break;
                            case AutoRunStep.CCD_A下料上下气缸2上升:
                                ctTimer.Start();
                                MiddleAutoRunStepA = AutoRunStep.CCD_A下料上下气缸2上升到位检测;
                                ManageContral.SetOutBit("下料上下气缸2", false);
                                break;
                            case AutoRunStep.CCD_A下料上下气缸2上升到位检测:
                                if (ManageContral.GetInOn("下料上下气缸2上") == true)
                                {
                                    ctTimer.Start();
                                    MiddleAutoRunStepA = AutoRunStep.CCD_A放回载盘完成;

                                }
                                else if (ctTimer.TimeUp(6))
                                {
                                    ctTimer.Start();
                                }
                                break;
                            case AutoRunStep.CCD_A放回载盘完成:
                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["翻转运行完成标志位"].Date = false;
                                MiddleAutoRunStepA = AutoRunStep.Idle;
                                break;                              
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 下料方法
        /// </summary>
        public void _Laying_Fun()
        {

            while (true)
            {
               
                Thread.Sleep(50);
                lock (_lockO)
                {
                    if (/*!Program.bAuto || Program.bStop || Program.bEStop ||*/ _CCDTaska_B == true)
                    {
                      
                    }
                    else
                    {

                        switch (rightAutoRunStepB)
                        {
                            case AutoRunStep.Idle:
                                sta = ManageContral.GetInOn("下料上下气缸2上");
                                if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date ==true&& sta==true)
                                {
                                    ManageContral.AxisPMoveAbsoluteToStop(下料AixsName, DateSave.Instance().Production.翻放位);
                                    ManageContral.DetectingAxis(下料AixsName);
                                    rightAutoRunStepB = AutoRunStep.CCD_A下料气缸下降;
                                }
                                break;
                            case AutoRunStep.CCD_A下料气缸下降:
                                if (ManageContral.DetectingAxis(下料AixsName) == 0)
                                {
                                    ctTimer.Start();
                                    ManageContral.SetOutBit("下料真空气缸2", true);
                                    ManageContral.SetOutBit("下料上下气缸2", true);
                                    //ManageContral.SetOutBit("下料旋转气缸2", true);
                                    //ManageContral.SetOutBit("左移栽定位气缸1", false);
                                    //ManageContral.SetOutBit("左移栽定位气缸2", false);
                                    rightAutoRunStepB = AutoRunStep.CCD_A下料气缸下降检测;
                                    ctTimer.Start();
                                }
                                break;
                            case AutoRunStep.CCD_A下料气缸下降检测:
                                sta = ManageContral.GetInOn("下料上下气缸2下");
                                if (sta == true)
                                {
                                    ctTimer.Start();
                                
                                    rightAutoRunStepB = AutoRunStep.CCD_A下料气缸上升;
                                }
                                else if (ctTimer.TimeUp(6))
                                {
                                
                                    ctTimer.Start();
                                }
                                break;
                            case AutoRunStep.CCD_A下料气缸上升:
                              
                                ctTimer.Start();
                                ManageContral.SetOutBit("下料上下气缸2", false);
                                rightAutoRunStepB = AutoRunStep.CCD_A下料气缸上升检测;                             
                                break;
                            case AutoRunStep.CCD_A下料气缸上升检测:
                                sta = ManageContral.GetInOn("下料上下气缸2上");
                                if (sta == true)
                                {
                                    ctTimer.Start();
                                  
                                     rightAutoRunStepB = AutoRunStep.CCD_A下料旋转1气缸;
                                }
                                else if (ctTimer.TimeUp(6))
                                {
                                    ctTimer.Start();
                                }

                                break;
                            case AutoRunStep.CCD_A下料旋转1气缸:
                                ctTimer.Start();
                                //ManageContral.SetOutBit("下料旋转气缸1", true);
                                rightAutoRunStepB = AutoRunStep.CCD_A下料旋转1气缸检测;
                                break;
                            case AutoRunStep.CCD_A下料旋转1气缸检测:
                                //sta = ManageContral.GetInOn("下料旋转气缸1转");
                                //if (sta == true)
                                //{
                                    ctTimer.Start();
                                //OK
                                    ManageContral.AxisPMoveAbsoluteToStop(下料AixsName, DateSave.Instance().Production.下料轴B面放料位);
                                    rightAutoRunStepB = AutoRunStep.CCD_A下料伸出1气缸;
                                //ng


                                //}
                                //else if (ctTimer.TimeUp(6))
                                //{
                                //    ctTimer.Start();
                                //}

                                break;
                            case AutoRunStep.CCD_A下料伸出1气缸:
                                if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["底部中转Y轴运行标志位"].Date == false)
                                {
                                   
                                if (ManageContral.DetectingAxis(下料AixsName) == 0)
                                {
                                    ManageContral.SetOutBit("下料上下气缸2", true);
                                    ctTimer.Start();
                                  
                                    rightAutoRunStepB = AutoRunStep.CCD_A下料伸出1气缸检测;
                                }
                                else if (ctTimer.TimeUp(6))
                                {
                                
                                    ctTimer.Start();
                                }
                                }
                                break;
                            case AutoRunStep.CCD_A下料伸出1气缸检测:
                                sta = ManageContral.GetInOn("下料上下气缸2下");
                                if (sta == true)
                                {
                                    ctTimer.Start();
                                    ManageContral.SetOutBit("下料真空气缸2", false);
                                    ManageContral.SetOutBit("下料上下气缸2", false);
                                    rightAutoRunStepB = AutoRunStep.CCD_A下料1破2吸;
                                }
                                else if (ctTimer.TimeUp(6))
                                {
                   
                                    ctTimer.Start();
                                }
                                break;
                            case AutoRunStep.CCD_A下料1破2吸:
                                sta = ManageContral.GetInOn("下料上下气缸2上");
                                if (sta == true)
                                {
                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["底部中转Y轴运行标志位"].Date = true;
                                    ctTimer.Start();
                              
                                    rightAutoRunStepB = AutoRunStep.CCD_A放回载盘完成;
                                }
                                else if (ctTimer.TimeUp(6))
                                {

                                    ctTimer.Start();
                                }
                                break;
                            case AutoRunStep.CCD_A放回载盘完成:
                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["下料运行完成标志位"].Date = false;
                                rightAutoRunStepB = AutoRunStep.Idle ;
                               // _OverTurn.Abort();
                                break;
                        }
                    }
                }
            }
        }

    }
}

