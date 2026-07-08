using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{ 
    //分堆XYZ及皮带
    public class LayOffFascicule
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
        string FasciculeX_AixsName = "分堆X轴";
        string FasciculeY_AixsName = "分堆Y轴";
        string FasciculeZ_AixsName = "分堆Z轴";
        public bool _CCDTaska_B = false;
        /// <summary>
        /// CCDA 拍照结果
        /// </summary>
        public string CCD_A_RUN_REL = "";
        /// <summary>
        /// CCDB拍照结果
        /// </summary>
        public string CCD_B_RUN_REL = "";
        public bool FasciculeAlm = false;
        bool sta = false;
        public void ProcessA()
        {
            //if (!Properties.Settings.Default.bRightIsUsed)
            //    return;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["分堆XYZ运行标志位"].Date = false;

            try
            {
                while (true)
                {
                    Thread.Sleep(30);
                    lock (lockObj)
                    {
                        if (!Program.bAuto || Program.bStop || Program.bEStop || FasciculeAlm == true)
                        {
                        }
                        else
                        {
                            switch (rightAutoRunStepA)
                            {
                                case AutoRunStep.Idle:
                                    //流程的预准备
                                    ManageContral.AxisPMoveAbsoluteToStop(FasciculeX_AixsName, DateSave.Instance().Production.分堆X轴待机位);
                                    ManageContral.AxisPMoveAbsoluteToStop(FasciculeY_AixsName, DateSave.Instance().Production.分堆Y轴待机位);
                                    ManageContral.AxisPMoveAbsoluteToStop(FasciculeZ_AixsName, DateSave.Instance().Production.分堆Z轴待机位);
                                    ManageContral.SetOutBit("下料旋转气缸原点", true );
                                    ManageContral.SetOutBit("下料旋转气缸终点", false);
                                    rightAutoRunStepA = AutoRunStep.RunDone;
                                    ctTimer.Start();
                                    break;
                                case AutoRunStep.RunDone:
                                    if (ManageContral.DetectingAxis(FasciculeX_AixsName) == 0&& ManageContral.DetectingAxis(FasciculeY_AixsName) == 0 && ManageContral.DetectingAxis(FasciculeZ_AixsName) == 0)
                                    {
                                        ctTimer.Start();
                                        rightAutoRunStepA = AutoRunStep.Check;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {

                                        FasciculeAlm = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.Check:
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["分堆XYZ运行标志位"].Date == true)
                                    {
                                        rightAutoRunStepA = AutoRunStep.分堆中转放料位;

                                    }
                                    break;
                                case AutoRunStep.分堆中转放料位:
                                    ManageContral.AxisPMoveAbsoluteToStop(FasciculeX_AixsName, DateSave.Instance().Production.下料X轴取料位);
                                    ManageContral.AxisPMoveAbsoluteToStop(FasciculeY_AixsName, DateSave.Instance().Production.分堆Y轴取料位);
                                    rightAutoRunStepA = AutoRunStep.分堆中转取料位检测;
                                    //ManageContral.AxisPMoveAbsoluteToStop(Fascicule_AixsName, DateSave.Instance().Production.分堆底部接料轴取料位);
                                    break;
                                case AutoRunStep.分堆中转取料位检测:
                                    if (ManageContral.DetectingAxis(FasciculeX_AixsName) == 0&& ManageContral.DetectingAxis(FasciculeY_AixsName) == 0)
                                    {
                                        ctTimer.Start();
                                        rightAutoRunStepA = AutoRunStep.分堆Z取料位;
                                        ManageContral.AxisPMoveAbsoluteToStop(FasciculeZ_AixsName, DateSave.Instance().Production.分堆Z轴取料位);
                                    }
                                    break;
                                case AutoRunStep.分堆Z取料位:
                                    if (ManageContral.DetectingAxis(FasciculeZ_AixsName) == 0 )
                                    {
                                        ManageContral.SetOutBit("下料真空吸", true);
                                        ctTimer.Start();
                                        rightAutoRunStepA = AutoRunStep.CheckIO;
                                        ManageContral.AxisPMoveAbsoluteToStop(FasciculeZ_AixsName, DateSave.Instance().Production.分堆Z轴待机位);

                                    }
                                    break;
                                case AutoRunStep.CheckIO:
                                    sta = ManageContral.GetInOn("下料真空负压信号");
                                    if (sta == false)
                                    {
                                        //回位
                                        ManageContral.AxisPMoveAbsoluteToStop(FasciculeZ_AixsName,0);
                                        while (true)
                                        {
                                            if ( ManageContral.DetectingAxis(FasciculeZ_AixsName) == 0)
                                            {
                                                break;

                                            }
                                        }
                                   
                                        ManageContral.SetOutBit("下料旋转气缸原点", true );
                                        ManageContral.SetOutBit("下料旋转气缸终点", false);
                                        //分堆底部接料X轴 回位
                                      //  FormStart.m_Fascicule_Task.rightAutoRunStepA = AutoRunStep.LOOP;

                                        ctTimer.Start();
                                        ManageContral.AxisPMoveAbsoluteToStop(FasciculeX_AixsName, DateSave.Instance().Production.测高位X);
                                        ManageContral.AxisPMoveAbsoluteToStop(FasciculeY_AixsName, DateSave.Instance().Production.测高位);
                                        ManageContral.AxisPMoveAbsoluteToStop(FasciculeZ_AixsName, DateSave.Instance().Production.下料Z轴侧高位);
                                        while (true)
                                        {
                                            if (ManageContral.DetectingAxis(FasciculeX_AixsName) == 0 && ManageContral.DetectingAxis(FasciculeY_AixsName) == 0 && ManageContral.DetectingAxis(FasciculeZ_AixsName) == 0)
                                            {
                                                rightAutoRunStepA = AutoRunStep.测高;
                                                break;
                                            }
                                        }
                                    
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        //FormStart.LOG_ShowFrom["上料工位步骤"].Enqueue("上料X轴定位上料轴上料轴放料位超时报警");
                                        //MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位上料轴放料位超时报警");
                                        //LoadMaterialB = true;
                                        ctTimer.Start();
                                    }
                                    break;

                                case AutoRunStep.测高:
                                    sta = ManageContral.GetInOn("下料旋转气缸原点");
                                    if (sta==true)
                                    {
                                        ManageContral.SetOutBit("下料旋转气缸原点", false);
                                        ManageContral.SetOutBit("下料旋转气缸终点", true);
                                        while (true)
                                        {
                                            sta = ManageContral.GetInOn("下料旋转气缸终点");
                                            if (sta == true)
                                            {
                                                break;
                                            }

                                         }
                                        调高();

                                        while (true)
                                        {
                                            if (ManageContral.DetectingAxis(FasciculeZ_AixsName) == 0)
                                            {
                                                rightAutoRunStepA = AutoRunStep.分堆Z放料位;
                                                break;
                                            }
                                        }
                                                               
                                    
                                    }
                         
                                    break;
                                case AutoRunStep.分堆Z放料位:
                                    ManageContral.SetOutBit("下料真空吸", false);
                                    while (true)
                                    {
                                        sta = ManageContral.GetInOn("下料真空负压信号");
                                        if (sta==false)
                                        {
                                            ManageContral.AxisPMoveAbsoluteToStop(FasciculeZ_AixsName, DateSave.Instance().Production.分堆Z轴待机位);
                                            while (true)
                                            {
                                                if (ManageContral.DetectingAxis(FasciculeZ_AixsName) == 0)
                                                {
                                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["分堆XYZ运行标志位"].Date = false;
                                                    rightAutoRunStepA = AutoRunStep.Idle;
                                                    break;
                                                }
                                            }
                                       
                                    
                                            break;
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
        public double 调高()
        {
            double Rels = 0.0;
            uint clk;
            double date = 0.0;
            double ad = DateSave.Instance().Production.BaselineSimulation;//获取基准模拟量
            Thread.Sleep(100);
            GTN.mc.GTN_GetAuAdc(2, 1, out date, 1, out clk);
            double ad12 = DateSave.Instance().Production.Z_AxialDatum;//获取Z基准坐标
            double sf = ad - date;
            if (sf > 0)
            {
                double s = Math.Abs(sf);
                double z = s / DateSave.Instance().Production.High_Date;
                double CurrentZA = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[FasciculeZ_AixsName].AisxCurrentPosition;

                Rels = z;
                double NeedCurrentZA = CurrentZA + z;
                ManageContral.AxisPMoveAbsoluteToStop(FasciculeZ_AixsName, NeedCurrentZA);
                //double NeedCurrentZA = CurrentZA - z;
            }
            else
            {
                double s = Math.Abs(sf);
                double z = s / DateSave.Instance().Production.High_Date;
                double CurrentZA = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[FasciculeZ_AixsName].AisxCurrentPosition;
                Rels = z;
                double NeedCurrentZA = CurrentZA - z;
                ManageContral.AxisPMoveAbsoluteToStop(FasciculeZ_AixsName, NeedCurrentZA);

            }
            return Rels;
        }
    }
}
