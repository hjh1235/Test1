using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    //上料左工位取料位安全标志位     上料右工位取料位安全标志位
    //上料左工位激光位安全标志位   上料右工位激光位安全标志位


    //CCD_左载台激光喷码位安全标志位    CCD_右载台激光喷码位安全标志位
    //CCD_左载台下料位安全标志位         CCD_右载台下料位安全标志位
    //分堆底部接料工位
    public class Fascicule
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
        string Fascicule_AixsName = "分堆底部接料X轴";
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
                        if (!Program.bAuto || Program.bStop || Program.bEStop || FasciculeAlm == true)
                        {
                        }
                        else
                        {
                            switch (rightAutoRunStepA)
                            {
                                case AutoRunStep.Idle:
                                    //流程的预准备
                                    ManageContral.AxisPMoveAbsoluteToStop(Fascicule_AixsName, DateSave.Instance().Production.分堆底部接料轴待机位);
                                    rightAutoRunStepA = AutoRunStep.RunDone;
                                    ctTimer.Start();
                                    break;
                                case AutoRunStep.RunDone:
                                    if (ManageContral.DetectingAxis(Fascicule_AixsName) == 0)
                                    {
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["底部中转Y轴运行标志位"].Date = false;
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
                                    if (ManageContral.DetectingAxis(Fascicule_AixsName) == 0)
                                    {
                                        ctTimer.Start();
                                        rightAutoRunStepA = AutoRunStep.分堆中转取料位;                                                       
                                    }
                                    break;
                                case AutoRunStep.分堆中转取料位:
                                    rightAutoRunStepA = AutoRunStep.分堆中转取料位检测;
                                    ManageContral.AxisPMoveAbsoluteToStop(Fascicule_AixsName, DateSave.Instance().Production.分堆底部接料轴取料位);
                                    break;
                                case AutoRunStep.分堆中转取料位检测:
                                    if (ManageContral.DetectingAxis(Fascicule_AixsName) == 0)
                                    {
                                        ctTimer.Start();
                                        rightAutoRunStepA = AutoRunStep.开始检测是否可到放料位;
                                    }
                                    break;
                                case AutoRunStep.开始检测是否可到放料位:
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["底部中转Y轴运行标志位"].Date == true)
                                    {
                                        rightAutoRunStepA = AutoRunStep.分堆中转放料位;

                                    }
                                    break;
                                case AutoRunStep.分堆中转放料位:
                                    rightAutoRunStepA = AutoRunStep.分堆中转放料位检测;
                                    ManageContral.AxisPMoveAbsoluteToStop(Fascicule_AixsName, DateSave.Instance().Production.分堆底部接料轴放料位);
                                    break;
                                case AutoRunStep.分堆中转放料位检测:
                                    if (ManageContral.DetectingAxis(Fascicule_AixsName) == 0)
                                    {
                                   
                                        if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["分堆XYZ运行标志位"].Date == false)
                                        {
                                            rightAutoRunStepA = AutoRunStep.CheckData;
                                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["分堆XYZ运行标志位"].Date = true;
                                            ctTimer.Start();
                                        }
                                 
                                        //rightAutoRunStepA = AutoRunStep.LOOP;
                                    }
                                    break;
                                case AutoRunStep.CheckData:
                                 
                                    break;
                                    
                                case AutoRunStep.LOOP:
                
                                    rightAutoRunStepA = AutoRunStep.Idle;
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
}
