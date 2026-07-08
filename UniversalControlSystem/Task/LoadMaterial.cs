using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    public enum AutoRunStep : byte
    {
        Idle = 0,
        RunStart = 1,//2  0
        RunDone =2,//4  1
        Reset = 3,
        Check,
        ZeroP,
        ZeroP1, 
        LOOP,
        ZeroP2,
        ZeroP3 ,
        ZeroP4 ,
        ZeroP5 ,
        ZeroP6 ,

        ZeroP7 ,
        ZeroP8 ,
        ZeroP9 ,
        ZeroP10 ,
        CheckIO,
        CheckData,
 
        放纸位,
        放纸位到位,
        放纸气缸下降,
        放纸气缸下降检测,
        放纸气缸破真空,
        放纸气缸上升,
        放纸气缸上升检测,

        放料位,
        放料位到位,
        检测是否可放料,
        放料位气缸下降,
        放料位气缸下降检测,
        放料位气缸破真空,
        放料位气缸上升,
        放料位气缸上升_放料,
        放料位气缸上升检测,
        放料位辅助位,
        放料位完成,


        CCDTaska_左气缸上升检测,
        CCDTaska_上料轴待机位,
        CCDTaska_上料轴待机位检测,
        CCDTaska_上料轴放料位,
        CCDTaska_上料轴放料位检测,
        CCDTaska_左气缸下降检测,
        CCDTaska_左真空检测检测,
        CCDTaska_左CCD启动,
        CCD_左_上料轴待机位,
        CCD_左_上料轴待机位到位检测,
        CCD_左_面线扫开始拍照位,
        CCD_左_面开始拍照位,
        CCD_左_面线扫到位检测,
        CCD_左_面开始检测是否下料,
        CCDTaska_左破真空,
        CCD_左_面判断是否放料,
        CCDTaska_左气缸上升检测到位,
        CCDTaska_左气缸夹料,
        CCDTaska_左气缸夹料到位检测,


        CCDTaska_A真空检测,
        CCDTaska_A有料检测,
        CCDTaska_ACCD启动,
        CCD_A_面开始拍位,
        CCDTaska_A_开始拍位到位检测,
        CCD_A_面结束拍位,
        CCDTaska_A_结束拍位到位检测,
        CCD_A_面激光位,
        CCDTaska_A_激光位到位检测,
        CCDTaska_A_打激光,
        CCDTaska_A_打激光拍照,
        CCDTaska_A_打激光拍照位检测,
        CCDTaska_A_打激光开始拍照,
        CCDTaska_A_开始打激光,
        CCDTaska_A_到喷码位,
        CCD_左到喷码位检测,
        CCD_喷码拍照,
        CCD_喷码视觉数据获取,
        CCD_喷码开始,
        CCD_喷码完成,
        CCD_到下料位,
        CCD_翻转B面,
        CCD_开始下料,
        CCD_开始下料检测,
        CCD_A下料气缸下降,
        CCD_A下料气缸下降检测,
        CCD_A下料气缸上升,
        CCD_A下料气缸上升检测,
        CCD_A下料旋转1气缸,
        CCD_A下料旋转1气缸检测,
        CCD_A下料伸出1气缸,
        CCD_A下料伸出1气缸检测,
        CCD_A下料1破2吸,
        CCD_A下料1破2吸检测真空,
        CCD_A下料左右回位,
        CCD_A下料左右回位到位检测,
        CCD_A下旋转1与2回位,
        CCD_A下旋转1与2回位到位检测,
        CCD_A下料上下气缸2下降,
        CCD_A下料上下气缸2下降到位检测,
        CCD_A下料上下气缸2破真空,
        CCD_A下料上下气缸2破真空检测,
        CCD_A下料上下气缸2上升,
        CCD_A下料上下气缸2上升到位检测,
        CCD_A放回载盘,
        CCD_A放回载盘完成,
        CCD_A下料移栽平台下降,
        CCD_A下料移栽平台下降到位检测,
        CCD_A检测上上料位安全,
        CCD_B检测上上料位安全,
        CCD_A检测激光位安全,
        CCD_B检测激光位安全,
        CCD_A检测喷码位安全,
        CCD_B检测喷码位安全,

        CCD_B放料位,
        CCD_B放料位到位检测,
        CCD_B下料移栽平台上升,
        CCD_B下料移栽平台上升到位检测,
        CCDB_左_面线扫开始拍照位,
        CCDB_左_面线扫到位检测,
        CCDTaska_B_CCD线扫完成,
        CCDTaska_B_打激光完成,
        CCDB_喷码拍照,
        CCDB_喷码开始,
        CCDB_喷码完成,
        CCDB_到下料位,
        //CCD_B检测激光位安全,

        CCDTaska_BCCD启动,
        CCD_B_面开始拍位,
        CCDTaska_B_开始拍位到位检测,
        CCD_B_面结束拍位,
        CCDTaska_B_结束拍位到位检测,
        CCD_B_面激光位,
        CCDTaska_B_激光位到位检测,
        CCDTaska_B_打激光,
        CCDTaska_B_打激光拍照,
        CCDTaska_B_打激光拍照位检测,
        CCDTaska_B_打激光开始拍照,
        CCDTaska_B_开始打激光,
        CCDTaska_B_到喷码位,
        CCD_B左到喷码位检测,
        CCD_B喷码拍照,
        CCD_B喷码视觉数据获取,
        CCD_B喷码开始,
        CCD_B喷码完成,
        CCD_B到下料位,

        CCDTaska_A_打激光完成,
        CCDTaska_A_CCD位,
        CCDTaska_A_CCD到位检测,
        CCDTaska_A_CCD待机位,
        CCDTaska_A_CCD待机位检测,
        CCDTaska_A_CCD放料位,
        CCDTaska_A_CCD放料位检测,
        CCDTaska_A_CCD辅助位,
        CCDTaska_A_CCD完成,
        CCDTaska_A_CCD线扫完成,

        CCDTaska_B真空检测,
        CCDTaska_B有料检测,

        CCDTaska_B_CCD气缸下降,
        CCDTaska_B_CCD气缸下降检测,
        CCDTaska_B_CCD气缸破真空,
        CCDTaska_B_CCD气缸破真空检测,
        CCDTaska_B_CCD气缸上升,
        CCDTaska_B_CCD气缸上升检测,

        CCDTaska_B_CCD启动,
     //   CCD_B_面开始拍位,
        CCD_B_面开始到位检测,
      //  CCD_B_面结束拍位,
        CCD_B_面结束到位检测,
        CCDTaska_B_CCD位,
        CCDTaska_B_CCD到位检测,
        CCDTaska_B_CCD待机位,
        CCDTaska_B_CCD待机位检测,
        CCDTaska_B_CCD放料位,
        CCDTaska_B_CCD放料位检测,
        CCDTaska_B_CCD辅助位,
        CCDTaska_B_CCD完成,

        底部中转Y轴启动,
        底部中转Y轴气缸下降,
        底部中转Y轴气缸下降检测,
        底部中转Y轴气缸上升,
        底部中转Y轴气缸上升检测,
        底部中转Y轴下料位,
        底部中转Y轴下料到位检测,
        底部中转Y轴待机位,
        底部中转Y轴待机位检测,
        底部中转Y轴放料位,
        底部中转Y轴放料位检测,
        底部中转Y轴辅助,
        底部中转Y轴完成,

        下料启动,
        下料启动到位检测,
        下料气缸下降,
        下料气缸下降检测,
        下料气缸上升,
        下料气缸上升检测,
        下料旋转1气缸,
        下料旋转1气缸检测,
        下料伸出1气缸,
        下料伸出1气缸检测,
        下料1破2吸,
        下料1破2吸检测真空,
        下料左右回位,
        下料左右回位到位检测,
        下旋转1与2回位,
        下旋转1与2回位到位检测,
        判断,
        下料轴到OK位,
        下料轴到OK位检测,
        下料轴到NG位,
        下料上下气缸2下降,
        下料上下气缸2下降到位检测,
        下料上下气缸2破真空,
        下料上下气缸2破真空检测,
        下料上下气缸2上升,
        下料上下气缸2上升到位检测,
        
        下料Z1轴取料位,
        下料Z2轴取料位,
        下料Z1Z2轴取料位到位,
        下料真空吸,
        下料Z1轴真空检测,
        下料Z2轴真空检测,
        下料Z1轴放料位,
        走间隔,
        下料Z2轴放料位,
        下料Z1Z2轴放料位到位,
        下料Z1Z2轴待机位,
        下料Z1Z2轴待机位到位,
        下料X轴待机位,
        下料X轴待机位到位,
        下料X轴放料位,
        下料X轴放料位到位,
        下料完成,

        分堆中转取料位,
        分堆中转取料位检测,
        开始检测是否可到放料位,
        分堆中转放料位,
        分堆中转放料位检测,

        分堆XY取料位,
        分堆XY取料位检测,
        分堆Z取料位,
        分堆Z取料位检测,
        分堆Z取料真空,
        分堆Z取料真空检测,
        分堆Z待机位,
        测高,
        分堆XY放料位,
        分堆Z放料位,      
    }
    /// <summary>
    /// 上料类
    /// </summary>
    public class LoadMaterial
    {
        private HiPerfTimer ctTimer = new HiPerfTimer();
        public AutoRunStep leftAutoRunStepA = new AutoRunStep();
        public AutoRunStep leftAutoRunStepB = new AutoRunStep();
        private object lockObj = new object();
        public int Result;
        //RunClass RunClaLeft = new RunClass();
        //RunClass RunClaRight = new RunClass();
        FormStart m_formStart = new FormStart();
        string LoadMaterial_AixsName = "上料轴";
        /// <summary>
        /// s上料Z轴 
        /// </summary>
        public bool LoadMaterialA = false;
        public void ProcessA()
        {
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料Z轴运动标志位"].Date = false;
            bool sta = false;
            try
            {
                int pValue = 0;
                short sRtn = 0;
                bool bBitInputStatus = false;
                bool bBitInputStatusL = false;
                while (true)
                {
                    Thread.Sleep(50);
                    //lock (lockObj)
                    //{
                    if (!Program.bAuto || Program.bStop || Program.bEStop|| LoadMaterialA)
                    {
                    }
                    else
                    {
                        switch (leftAutoRunStepA)
                        {
                            //流程的预准备
                            case AutoRunStep.Idle:
                                if (LoadMaterialA == false)
                                {
                                    FormStart.LOG_ShowFrom["上料工位"].Enqueue("上料定位1气缸false");
                                    FormStart.LOG_ShowFrom["上料工位"].Enqueue("上料定位2气缸false");
                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料Z轴运动标志位"].Date = false;
                                    sRtn = GTN.mc.GTN_GetDi(1, GTN.mc.MC_GPI, out pValue);
                                    bBitInputStatus = ((pValue & 0x4) == 0) ? true : false;
                                    if (bBitInputStatus == true)
                                    {
                                        ctTimer.Start();
                                        sta = false;
                                        leftAutoRunStepA = AutoRunStep.RunStart;
                                    }
                                    else
                                    {
                                        ctTimer.Start();
                                        leftAutoRunStepA = AutoRunStep.Reset;
                                    }
                                }
                                else
                                {
                                }
                                break;
                            case AutoRunStep.RunStart:
                                ManageContral.AxisPrfJog(LoadMaterial_AixsName,true);
                                while (true)
                                {
                                    if (!Program.bAuto)
                                    {
                                        break;
                                    }                               
                                    //ManageContral.AxisPrfTrapRel(LoadMaterial_AixsName, 1);
                                      pValue = 0;
                                  //读取产品到位状态
                                     sRtn = GTN.mc.GTN_GetDi(1, GTN.mc.MC_GPI, out pValue);
                                     bBitInputStatus = ((pValue & 0x8) == 0) ? true : false;
                                    if (bBitInputStatus == true)
                                    {
                                        sta = true;
                                    }
                                    else
                                    {
                                        sta = false;
                                    }                         
                                    if (sta == true)
                                    {
                                        ManageContral.StopAxis(LoadMaterial_AixsName);
                                        FormStart.LOG_ShowFrom["上料工位"].Enqueue("上料平台上到位");
                                        ManageContral.SetOutBit("上料夹板气缸", true);
                                        FormStart.LOG_ShowFrom["上料工位"].Enqueue("上料夹板气缸夹紧");
                                        break;
                                    }
                                }
                                ctTimer.Start();
                                while (true)
                                {
                                    if (!Program.bAuto)
                                    {
                                        break;
                                    }
                                    if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["上料夹板前气缸"].bBitInputStatus == true && Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["上料夹板后气缸"].bBitInputStatus == false )
                                    {
                                        ManageContral.SetOutBit("上料夹板气缸", true);
                                        break;
                                    }
                                    else if (ctTimer.TimeUp(3))
                                    {
                                        FormStart.LOG_ShowFrom["上料工位"].Enqueue("上料夹板前气缸伸出");
                                        MainForm.m_formAlarm.InsertAlarmMessage("上料夹板前气缸伸出");
                                        LoadMaterialA = true;
                                        break;
                                    }
                                }
                                ctTimer.Start();
                                while (true)
                                {
                                    if (!Program.bAuto)
                                    {
                                        break;
                                    }
                                    if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["上料夹板前气缸"].bBitInputStatus == true && Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["上料夹板后气缸"].bBitInputStatus == false)
                                    {                            
                                        break;
                                    }
                                    else if (ctTimer.TimeUp(3))
                                    {
                                        FormStart.LOG_ShowFrom["上料工位"].Enqueue("上料夹板前气缸伸出");
                                        MainForm.m_formAlarm.InsertAlarmMessage("上料夹板前气缸伸出");
                                        LoadMaterialA = true;
                                        break;
                                    }
                                }
                                //上料定位1气缸电磁阀
                                FormStart.LOG_ShowFrom["上料工位"].Enqueue("上料夹板后气缸到位");                 
                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料Z轴运动标志位"].Date = true;
                                ctTimer.Start();
                                leftAutoRunStepA = AutoRunStep.LOOP;
                                break;
                            case AutoRunStep.LOOP:
                                sRtn = GTN.mc.GTN_GetDi(1, GTN.mc.MC_GPI, out pValue);
                                bBitInputStatus = ((pValue & 0x4) == 0) ? true : false;
                                if (bBitInputStatus == true)
                                {
                                    ctTimer.Start();
                                    //sta = false;
                                    //leftAutoRunStepA = AutoRunStep.RunStart;
                                }
                                else
                                {
                                    ctTimer.Start();
                                    leftAutoRunStepA = AutoRunStep.Reset;
                                }
                                break;
                            case AutoRunStep.RunDone:
                                 pValue = 0;
                                 sRtn = GTN.mc.GTN_GetDi(1, GTN.mc.MC_GPI, out pValue);
                                //  bool   bBitInputStatus = ((pValue & 0x4) == 0) ? true : false;
                                bBitInputStatusL = ((pValue & 0x4) == 0) ? true : false;//有无检测
                                sRtn = GTN.mc.GTN_GetDi(1, GTN.mc.MC_GPI, out pValue);
                                //  bool   bBitInputStatus = ((pValue & 0x4) == 0) ? true : false;
                                bBitInputStatus = ((pValue & 0x8) == 0) ? true : false;//有无到位检测
                                if (bBitInputStatus == false && bBitInputStatusL == true)
                                {
                                    leftAutoRunStepA = AutoRunStep.Idle;
                                    ctTimer.Start();
                                }
                                else if (bBitInputStatusL == false)
                                {
                                    leftAutoRunStepA = AutoRunStep.Reset;
                                }
                                break;
                            case AutoRunStep.Reset:
                                if (ManageContral.AxisPMoveAbsoluteToStop(LoadMaterial_AixsName,0) == 0)
                                {
                              
                                    leftAutoRunStepA = AutoRunStep.Check;
                                }
                                else if (ctTimer.TimeUp(10))
                                {
                                    FormStart.LOG_ShowFrom["上料工位"].Enqueue("上料工位步骤_到O位");
                                    MainForm.m_formAlarm.InsertAlarmMessage("上料工位步骤_上料工位步骤_到O位检测超时报警");
                                    LoadMaterialA = true;
                                }
                                break;
                     
                            case AutoRunStep.Check:

                                sRtn = GTN.mc.GTN_GetDi(1, GTN.mc.MC_GPI, out pValue);
                                bBitInputStatus = ((pValue & 0x4) == 0) ? true : false;
                                if (bBitInputStatus == true)
                                {
                                    ctTimer.Start();
                                    leftAutoRunStepA = AutoRunStep.Idle;
                                    break;
                                    //sta = false;
                                    //leftAutoRunStepA = AutoRunStep.RunStart;
                                }
                                else
                                {
                                    ctTimer.Start();
                              
                                }
                                //leftAutoRunStepA = AutoRunStep.Idle;
                                LoadMaterialA = true;
                                FormStart.LOG_ShowFrom["上料工位"].Enqueue("上料工位步骤_到O位");
                                MainForm.m_formAlarm.InsertAlarmMessage("上料工位步骤_上料工位步骤_到O位检测超时报警");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Program.LeftTaskRunA = false;
            }
        }   
    }
    /// <summary>
    /// 上料步骤
    /// </summary>
    public class LoadPaperStep
    {
        private HiPerfTimer ctTimer = new HiPerfTimer();
        private object lockObj = new object();
        int Result;
        //RunClass RunCls = new RunClass();
        public AutoRunStep MiddleAutoRunStepA = new AutoRunStep();
        public AutoRunStep MiddleAutoRunStepB = new AutoRunStep();
        Stopwatch stopwatch = new Stopwatch();
        /// <summary>
        /// 排胶计时器
        /// </summary>
        HiperTimer HipMiddleTaskRunOutGlue = new HiperTimer();
        FormStart m_formStart = new FormStart();
        string LoadPaperAixsName = "取料轴Y";
        public bool LoadMaterialA = false;
        public void ProcessA()
        {          
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料Z轴运动标志位"].Date = false;
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料Z轴运动标志位"].Date = false;
            //流程的预准备
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料运动标志位"].Date = false;
            try
            {
                while (true)
                {
                    Thread.Sleep(10);
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
                                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料运动标志位"].Date = false;
                                    MiddleAutoRunStepA = AutoRunStep.RunStart;
                                    ctTimer.Start();
                                    break;
                                case AutoRunStep.RunStart:
                                    ManageContral.AxisPMoveAbsoluteToStop(LoadPaperAixsName, DateSave.Instance().Production.上料轴待机位);
                                    MiddleAutoRunStepA = AutoRunStep.RunDone;
                                    ctTimer.Start();
                                    break;
                                case AutoRunStep.RunDone:                                   
                                    if (ManageContral.DetectingAxis(LoadPaperAixsName) == 0)
                                    {
                                        ctTimer.Start();
                                        MiddleAutoRunStepA = AutoRunStep.Reset;
                                    }                           
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        FormStart.LOG_ShowFrom["取料工位步骤"].Enqueue("上料X轴定位上料轴待机位超时报警");
                                        MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位定位超时报警");
                                        LoadMaterialA = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.Reset:
                                    ctTimer.Start();
                                    MiddleAutoRunStepA = AutoRunStep.CheckData;
                                    break;
                                case AutoRunStep.CheckData:
                                    if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料Z轴运动标志位"].Date == true)
                                    {                                  
                                        ctTimer.Start();
                                        ManageContral.AxisPMoveAbsoluteToStop(LoadPaperAixsName, DateSave.Instance().Production.上料轴取料位);
                                        ManageContral.DetectingAxis(LoadPaperAixsName);
                                        ManageContral.SetOutBit("上料吸板气缸", true);
                                        MiddleAutoRunStepA = AutoRunStep.ZeroP;
                                    }
                                    break;
                                case AutoRunStep.ZeroP:
                                    if (ManageContral.GetInOn("上料吸板气缸下") == true && ManageContral.GetInOn("上料吸板气缸上") == false)
                                    {
                                        ctTimer.Start();
                                        MiddleAutoRunStepA = AutoRunStep.ZeroP1;

                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        FormStart.LOG_ShowFrom["取料工位步骤"].Enqueue("上料吸板气缸下超时报警");
                                        MainForm.m_formAlarm.InsertAlarmMessage("上料吸板气缸下超时报警");
                                        LoadMaterialA = true;
                                        ctTimer.Start();
                                    }                           
                                    break;
                                case AutoRunStep.ZeroP1:
                                    //吸真空
                                    ctTimer.Start();
                                    ManageContral.SetOutBit("上料吸板真空", true);
                                    MiddleAutoRunStepA = AutoRunStep.CheckIO; 
                                                         
                                    break;
                                case AutoRunStep.CheckIO:
                                    if (ManageContral.GetInOn("上料真空压力") == true)
                                    {
                                        ctTimer.Start();
                                        MiddleAutoRunStepA = AutoRunStep.ZeroP2;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        FormStart.LOG_ShowFrom["取料工位步骤"].Enqueue("上料吸板气缸上超时报警");
                                        MainForm.m_formAlarm.InsertAlarmMessage("上料吸板气缸上超时报警");
                                        LoadMaterialA = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.ZeroP2:
                                    ctTimer.Start();
                                    ManageContral.SetOutBit("上料吸板气缸", false);
                                    MiddleAutoRunStepA = AutoRunStep.ZeroP3;
                                    break;
                                case AutoRunStep.ZeroP3:
                                    if (ManageContral.GetInOn("上料吸板气缸下") == false && ManageContral.GetInOn("上料吸板气缸上") == true)
                                    {
                                        
                                     //   FormStart.m_LoadMaterialTask.leftAutoRunStepA= AutoRunStep.RunDone;
                                        MiddleAutoRunStepA = AutoRunStep.ZeroP4;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        FormStart.LOG_ShowFrom["取料工位步骤"].Enqueue("上料吸板气缸上超时报警");
                                        MainForm.m_formAlarm.InsertAlarmMessage("上料吸板气缸上超时报警");
                                        LoadMaterialA = true;
                                        ctTimer.Start();
                                    }
                                    break;
                                case AutoRunStep.ZeroP4:
                                    ctTimer.Start();
                                    ManageContral.AxisPMoveAbsoluteToStop(LoadPaperAixsName, DateSave.Instance().Production.上料轴中转位);
                                    MiddleAutoRunStepA = AutoRunStep.ZeroP5;
                                    break;
                                case AutoRunStep.ZeroP5:
                                    if (ManageContral.DetectingAxis(LoadPaperAixsName) == 0)
                                    {
                                        ctTimer.Start();
                                        MiddleAutoRunStepA = AutoRunStep.LOOP;
                                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["上料运动标志位"].Date = true;
                                    }
                                    else if (ctTimer.TimeUp(6))
                                    {
                                        FormStart.LOG_ShowFrom["取料工位步骤"].Enqueue("上料X轴定位上料轴待机位超时报警");
                                        MainForm.m_formAlarm.InsertAlarmMessage("上料X轴上料轴待机位定位超时报警");
                                        LoadMaterialA = true;
                                        ctTimer.Start();
                                    }                              
                                    break;
                                case AutoRunStep.LOOP:
              
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
    }
}
