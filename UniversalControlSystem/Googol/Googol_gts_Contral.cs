using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gts;
using TReturn = System.Int16;
using System.Windows.Forms;
using System.Threading;
using TSpeed = System.Double;
using System.Timers;
using System.ComponentModel;
using System.Runtime.InteropServices;
using log4net.Config;
using log4net.Layout;
using System.IO;
using UniversalControlSystem.PLC;
using System.Drawing;

namespace UniversalControlSystem
{
    //GTS 控制类
    public partial class Googol_Contral : HardWareBase, ContraInterface
    {
        public static log4net.ILog logger;
        public Googol_Contral()
        {
            var logCfg = new FileInfo(System.AppDomain.CurrentDomain.BaseDirectory + "Log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
            logger = log4net.LogManager.GetLogger("版本：" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());//获取一个日志记录器 
            logger.Info("---------------------------------");


            timer = new MillisecondTimer();
            timer.Tick += sysTimer_Tick; //基于回调
            timer.Interval = 1; //当定时器启动时修改该值无效，需要先关掉定时器然后修改再重启
        }
        /// <summary>
        /// 初始化硬件
        /// </summary>
        /// <param name="hardDoc"></param>
        /// <returns></returns>
        public bool Init(CardDate_Save hardDoc)
        {
            bool InitFinish = false;
            foreach (var item in hardDoc.m_HardWareDictionary)
            {
                if (item.Value.m_strHardWare_Modle == "卡硬件")
                {
                    short sRtn = 0;
                    sRtn = gts.mc.GT_Open((short)item.Value.iCardNo, 0, 0);
                    if (sRtn != 0)
                    {
                        //  FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:开卡失败");
                        //Weld_Log.Instance().Enqueue("[卡初始化]:开卡失败");
                        InitFinish = false;
                        break;
                    }
                    else
                    {
                        //FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:开卡成功");
                        //Weld_Log.Instance().Enqueue("[卡初始化]:开卡成功");
                        InitFinish = true;
                    }
                    sRtn = gts.mc.GT_Reset((short)item.Value.iCardNo);
                    if (sRtn != 0)
                    {
                        //   FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:复位卡失败");
                        //Weld_Log.Instance().Enqueue("[卡初始化]:复位卡失败");
                        InitFinish = false; break;
                    }
                    else
                    {
                        //  FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:复位卡成功");
                        //Weld_Log.Instance().Enqueue("[卡初始化]:复位卡成功");
                        InitFinish = true;
                    }
                    string fileNameExt = item.Value.m_strConfigPath;
                    fileNameExt = fileNameExt.Substring(fileNameExt.LastIndexOf("\\") + 1); //获取文件名，不带路径
                    sRtn = gts.mc.GT_LoadConfig((short)item.Value.iCardNo, fileNameExt);
                    if (sRtn != 0)
                    {
                        //   FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:加载配置文件失败");
                        //Weld_Log.Instance().Enqueue("[卡初始化]:加载配置文件失败");
                        InitFinish = false; break;
                    }
                    else
                    {
                        //   FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:加载配置文件成功");
                        // Weld_Log.Instance().Enqueue("[卡初始化]:加载配置文件成功");
                        InitFinish = true;
                    }
                    sRtn = gts.mc.GT_ClrSts((short)item.Value.iCardNo, 1, 8);//清除轴报警和限位
                    if (sRtn != 0)
                    {
                        //  FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:清除报警失败");
                        //Weld_Log.Instance().Enqueue("[卡初始化]:清除报警失败");
                        InitFinish = false; break;
                    }
                    else
                    {
                        // FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:清除报警成功");
                        //Weld_Log.Instance().Enqueue("[卡初始化]:清除报警成功");
                        InitFinish = true;
                    }
                }
                else if (item.Value.m_strHardWare_Modle == "IO硬件")
                {
                    short sRtn = 0;
                    sRtn = gts.mc.GT_OpenExtMdl((short)item.Value.iCardNo, item.Value.m_strExtDllName);
                    if (sRtn != 0)
                    {
                        //   FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:打开扩展IO卡失败");
                        //Weld_Log.Instance().Enqueue("[卡初始化]:打开扩展IO卡失败");
                        InitFinish = false; break;
                    }
                    else
                    {
                        // FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:打开扩展IO卡成功");
                        //Weld_Log.Instance().Enqueue("[卡初始化]:打开扩展IO卡成功");
                        InitFinish = true;
                    }
                    sRtn = gts.mc.GT_ResetExtMdl((short)item.Value.iCardNo);
                    if (sRtn != 0)
                    {
                        //   FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:复位扩展IO卡失败");
                        //Weld_Log.Instance().Enqueue("[卡初始化]:复位扩展IO卡失败");
                        InitFinish = false; break;
                    }
                    else
                    {
                        //      FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:复位扩展IO卡成功");
                        //Weld_Log.Instance().Enqueue("[卡初始化]:复位扩展IO卡成功");
                        InitFinish = true;
                    }
                    string fileNameExt = item.Value.m_strExtPath;
                    fileNameExt = fileNameExt.Substring(fileNameExt.LastIndexOf("\\") + 1); //获取
                    sRtn = gts.mc.GT_LoadExtConfig((short)item.Value.iCardNo, fileNameExt);
                    if (sRtn != 0)
                    {
                        //  FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:加载配置未件失败");
                        //Weld_Log.Instance().Enqueue("[卡初始化]:加载配置未件失败");
                        InitFinish = false; break;
                    }
                    else
                    {
                        // FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[卡初始化]:加载配置件完成");
                        //Weld_Log.Instance().Enqueue("[卡初始化]:加载配置件完成");
                        InitFinish = true;
                    }
                }
            }
            if (InitFinish == true)
            {
                GetTimerStart();
                //Program.logger.Info("初始化卡硬件成功");
            }
            else
            {
                Program.logger.Info("初始化卡硬件失败");
            }
            return InitFinish;
        }
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
            CheckUpdatetimer.Interval = 10;
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
            GetAllMotionStatus();//轴状态
            GetAllIOStatus();//IO状态
        }
        /// <summary>
        /// 线程刷轴和IO的状态,已摒弃
        /// </summary>
        private void ScanThreadFunction()
        {
            while (true)
            {
                GetAllMotionStatus();
                GetAllIOStatus();
            }
        }
        /// <summary>
        /// IOz状态刷新
        /// </summary>
        protected static object lockObj = new object();
        public void GetAllIOStatus()
        {
            lock (lockObj)
            {
                bool[] bBitInputStatus = new bool[64];
                bool[] bBitOutputStatus = new bool[64];
                ushort uiInput = 0;
                ushort uiOutput = 0;
                int uiInputCard = 0;
                int uiOutputCard = 0;
                short sRtn;
                try
                {
                    //运动控制卡IO输入状态
                    foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                    {
                        if (item.Value.m_strHardWare_Modle == "卡硬件")
                        {
                            sRtn = gts.mc.GT_GetDi((short)item.Value.iCardNo, gts.mc.MC_GPI, out uiInputCard);
                            sRtn = gts.mc.GT_GetDo((short)item.Value.iCardNo, gts.mc.MC_GPO, out uiOutputCard);

                            bBitInputStatus[0] = ((uiInputCard & 0x1) == 0) ? true : false;
                            bBitInputStatus[1] = ((uiInputCard & 0x2) == 0) ? true : false;
                            bBitInputStatus[2] = ((uiInputCard & 0x4) == 0) ? true : false;
                            bBitInputStatus[3] = ((uiInputCard & 0x8) == 0) ? true : false;
                            bBitInputStatus[4] = ((uiInputCard & 0x10) == 0) ? true : false;
                            bBitInputStatus[5] = ((uiInputCard & 0x20) == 0) ? true : false;
                            bBitInputStatus[6] = ((uiInputCard & 0x40) == 0) ? true : false;
                            bBitInputStatus[7] = ((uiInputCard & 0x80) == 0) ? true : false;
                            bBitInputStatus[8] = ((uiInputCard & 0x100) == 0) ? true : false;
                            bBitInputStatus[9] = ((uiInputCard & 0x200) == 0) ? true : false;
                            bBitInputStatus[10] = ((uiInputCard & 0x400) == 0) ? true : false;
                            bBitInputStatus[11] = ((uiInputCard & 0x800) == 0) ? true : false;
                            bBitInputStatus[12] = ((uiInputCard & 0x1000) == 0) ? true : false;
                            bBitInputStatus[13] = ((uiInputCard & 0x2000) == 0) ? true : false;
                            bBitInputStatus[14] = ((uiInputCard & 0x4000) == 0) ? true : false;
                            bBitInputStatus[15] = ((uiInputCard & 0x8000) == 0) ? true : false;
                            //运动控制卡IO输出状态
                            bBitOutputStatus[0] = ((uiOutputCard & 0x1) == 0) ? true : false;
                            bBitOutputStatus[1] = ((uiOutputCard & 0x2) == 0) ? true : false;
                            bBitOutputStatus[2] = ((uiOutputCard & 0x4) == 0) ? true : false;
                            bBitOutputStatus[3] = ((uiOutputCard & 0x8) == 0) ? true : false;
                            bBitOutputStatus[4] = ((uiOutputCard & 0x10) == 0) ? true : false;
                            bBitOutputStatus[5] = ((uiOutputCard & 0x20) == 0) ? true : false;
                            bBitOutputStatus[6] = ((uiOutputCard & 0x40) == 0) ? true : false;
                            bBitOutputStatus[7] = ((uiOutputCard & 0x80) == 0) ? true : false;
                            bBitOutputStatus[8] = ((uiOutputCard & 0x100) == 0) ? true : false;
                            bBitOutputStatus[9] = ((uiOutputCard & 0x200) == 0) ? true : false;
                            bBitOutputStatus[10] = ((uiOutputCard & 0x400) == 0) ? true : false;
                            bBitOutputStatus[11] = ((uiOutputCard & 0x800) == 0) ? true : false;
                            bBitOutputStatus[12] = ((uiOutputCard & 0x1000) == 0) ? true : false;
                            bBitOutputStatus[13] = ((uiOutputCard & 0x2000) == 0) ? true : false;
                            bBitOutputStatus[14] = ((uiOutputCard & 0x4000) == 0) ? true : false;
                            bBitOutputStatus[15] = ((uiOutputCard & 0x8000) == 0) ? true : false;
                            int count = 0;
                            try
                            {
                                foreach (var IO_InPut_item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
                                {
                                    if (item.Value.iCardNo == IO_InPut_item.Value.iCardNo
                                        && IO_InPut_item.Value.iExtNo == -1)
                                    {
                                        if (IO_InPut_item.Value.bignore == false)
                                        {
                                            IO_InPut_item.Value.bBitInputStatus = bBitInputStatus[count];
                                            count++;
                                        }
                                        else
                                        {
                                            IO_InPut_item.Value.bBitInputStatus = false;
                                            count++;
                                        }
                                    }
                                }
                            }
                            catch
                            {
                            }
                            count = 0;
                            try
                            {
                                foreach (var IO_OutPut_item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                                {
                                    if (item.Value.iCardNo == IO_OutPut_item.Value.iCardNo
                                        && item.Value.iExtNo == IO_OutPut_item.Value.iExtNo)
                                    {
                                        if (IO_OutPut_item.Value.bignore == false)
                                        {
                                            IO_OutPut_item.Value.bBitOutputStatus = bBitOutputStatus[count];
                                            count++;
                                        }
                                        else
                                        {
                                            IO_OutPut_item.Value.bBitOutputStatus = false;
                                            count++;
                                        }
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                        else if (item.Value.m_strHardWare_Modle == "IO硬件")
                        {
                            sRtn = gts.mc.GT_GetExtIoValue((short)item.Value.iCardNo, (short)item.Value.iExtNo, out uiInput);
                            sRtn = gts.mc.GT_GetExtDoValue((short)item.Value.iCardNo, (short)item.Value.iExtNo, out uiOutput);
                            //扩展IO输入状态
                            bBitInputStatus[0] = ((uiInput & 0x1) == 0) ? true : false;
                            bBitInputStatus[1] = ((uiInput & 0x2) == 0) ? true : false;
                            bBitInputStatus[2] = ((uiInput & 0x4) == 0) ? true : false;
                            bBitInputStatus[3] = ((uiInput & 0x8) == 0) ? true : false;
                            bBitInputStatus[4] = ((uiInput & 0x10) == 0) ? true : false;
                            bBitInputStatus[5] = ((uiInput & 0x20) == 0) ? true : false;
                            bBitInputStatus[6] = ((uiInput & 0x40) == 0) ? true : false;
                            bBitInputStatus[7] = ((uiInput & 0x80) == 0) ? true : false;
                            bBitInputStatus[8] = ((uiInput & 0x100) == 0) ? true : false;
                            bBitInputStatus[9] = ((uiInput & 0x200) == 0) ? true : false;
                            bBitInputStatus[10] = ((uiInput & 0x400) == 0) ? true : false;
                            bBitInputStatus[11] = ((uiInput & 0x800) == 0) ? true : false;
                            bBitInputStatus[12] = ((uiInput & 0x1000) == 0) ? true : false;
                            bBitInputStatus[13] = ((uiInput & 0x2000) == 0) ? true : false;
                            bBitInputStatus[14] = ((uiInput & 0x4000) == 0) ? true : false;
                            bBitInputStatus[15] = ((uiInput & 0x8000) == 0) ? true : false;
                            //扩展IO输出状态
                            bBitOutputStatus[0] = ((uiOutput & 0x1) == 0) ? true : false;
                            bBitOutputStatus[1] = ((uiOutput & 0x2) == 0) ? true : false;
                            bBitOutputStatus[2] = ((uiOutput & 0x4) == 0) ? true : false;
                            bBitOutputStatus[3] = ((uiOutput & 0x8) == 0) ? true : false;
                            bBitOutputStatus[4] = ((uiOutput & 0x10) == 0) ? true : false;
                            bBitOutputStatus[5] = ((uiOutput & 0x20) == 0) ? true : false;
                            bBitOutputStatus[6] = ((uiOutput & 0x40) == 0) ? true : false;
                            bBitOutputStatus[7] = ((uiOutput & 0x80) == 0) ? true : false;
                            bBitOutputStatus[8] = ((uiOutput & 0x100) == 0) ? true : false;
                            bBitOutputStatus[9] = ((uiOutput & 0x200) == 0) ? true : false;
                            bBitOutputStatus[10] = ((uiOutput & 0x400) == 0) ? true : false;
                            bBitOutputStatus[11] = ((uiOutput & 0x800) == 0) ? true : false;
                            bBitOutputStatus[12] = ((uiOutput & 0x1000) == 0) ? true : false;
                            bBitOutputStatus[13] = ((uiOutput & 0x2000) == 0) ? true : false;
                            bBitOutputStatus[14] = ((uiOutput & 0x4000) == 0) ? true : false;
                            bBitOutputStatus[15] = ((uiOutput & 0x8000) == 0) ? true : false;
                            int count = 0;
                            try
                            {
                                foreach (var IO_InPut_item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
                                {
                                    if (item.Value.iCardNo == IO_InPut_item.Value.iCardNo && IO_InPut_item.Value.iExtNo == item.Value.iExtNo)
                                    {
                                        if (IO_InPut_item.Value.bignore == false)
                                        {
                                            IO_InPut_item.Value.bBitInputStatus = bBitInputStatus[count];
                                            count++;
                                        }
                                        else
                                        {
                                            IO_InPut_item.Value.bBitInputStatus = false;
                                            count++;
                                        }

                                    }
                                }
                            }
                            catch
                            {
                            }
                            count = 0;
                            try
                            {
                                foreach (var IO_OutPut_item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                                {
                                    if (item.Value.iCardNo == IO_OutPut_item.Value.iCardNo && item.Value.iExtNo == IO_OutPut_item.Value.iExtNo)
                                    {
                                        if (IO_OutPut_item.Value.bignore == false)
                                        {
                                            IO_OutPut_item.Value.bBitOutputStatus = bBitOutputStatus[count];
                                            count++;
                                        }
                                        else
                                        {
                                            IO_OutPut_item.Value.bBitOutputStatus = false;
                                            count++;
                                        }

                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                catch
                {
                }
                //#endregion
            }
        }
        ////////////////////////////////////////////////////////////////////刷新轴状态///////////////////////////////////////////////
        /// <summary>
        /// 刷新轴状态
        /// </summary>
        /// 
        private bool[] bHome = new bool[8];
        public void GetAllMotionStatus()
        {
            double dValue = 0.0;
            int lAxisStatus = 0;
            uint uIntClock;
            short sRtn = 0;
            try
            {
                foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                {
                    //轴当前位置
                    sRtn = gts.mc.GT_GetPrfPos((short)item.Value.m_CardNo, (short)(item.Value.m_AxisNo + 1), out dValue, 1, out uIntClock);
                    item.Value.AisxCurrentPosition = Math.Round(dValue / item.Value.PlusFeed, 3);
                    //轴当前状态
                    sRtn = gts.mc.GT_GetSts((short)item.Value.m_CardNo, (short)(item.Value.m_AxisNo + 1), out lAxisStatus, 1, out uIntClock);
                    if ((lAxisStatus & 0x1F2) != 0)
                    {
                        sRtn = gts.mc.GT_ClrSts((short)item.Value.m_CardNo, (short)(item.Value.m_AxisNo + 1), 1);
                    }
                    // 轴运动状态
                    if ((lAxisStatus & 0x400) != 0)
                    {
                        item.Value.bMovSta = true;
                    }
                    else
                    {
                        item.Value.bMovSta = false;
                    }
                    // 轴是否报警
                    if ((lAxisStatus & 0x2) != 0)
                    {
                        item.Value.bAlarm = true;
                        //MainForm.m_formAlarm.SetMotorAlarm(item.Value.Axis_hardwareName);
                    }
                    else
                    {
                        item.Value.bAlarm = false;
                        //MainForm.m_formAlarm.SetMotorAlarm(item.Value.Axis_hardwareName);
                    }
                    // 轴正限位状态
                    if ((lAxisStatus & 0x20) != 0)
                    {
                        item.Value.bCWL = true;
                    }
                    else
                    {
                        item.Value.bCWL = false;
                    }
                    // 轴负限位状态
                    if ((lAxisStatus & 0x40) != 0)
                    {
                        item.Value.bCCWL = true;
                    }
                    else
                    {
                        item.Value.bCCWL = false;
                    }
                    // 使能标志
                    if ((lAxisStatus & 0x200) != 0)
                    {
                        item.Value.bFlagServoOn = true;
                    }
                    else
                    {
                        item.Value.bFlagServoOn = false;
                    }
                    // 平滑停止
                    if ((lAxisStatus & 0x80) != 0)
                    {
                        item.Value.bFlagSmoothStop = true;
                    }
                    else
                    {
                        item.Value.bFlagSmoothStop = false;
                    }
                    // 跟随误差越限标志
                    if ((lAxisStatus & 0x10) != 0)
                    {
                        item.Value.bFlagMError = true;
                    }
                    else
                    {
                        item.Value.bFlagMError = false;
                    }
                    int lGpiValueHome;
                    sRtn = gts.mc.GT_GetDi((short)item.Value.m_CardNo, gts.mc.MC_HOME, out lGpiValueHome);//
                    item.Value.bOrg = Get_Org_Sta(item.Value.m_AxisNo, lGpiValueHome);
                }
            }
            catch
            {
            }

        }
        /// <summary>
        /// 获取原点状态
        /// </summary>
        /// <param name="m_AxisNo"></param>
        /// <param name="lGpiValueHome"></param>
        /// <returns></returns>
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
        /////////////////////////////////////////////////////////////////获取状态方法///////////////////////////////////////

        /// <summary>
        /// IO输出
        /// </summary>
        /// <param name="IO_Name"></param>
        /// <returns></returns>
        public int SetOutBit(string _IO_Name, bool bOn)
        {
            try
            {
                short sRtn;
                lock (lockObj)
                {
                    if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_IO_Name].iExtNo == -1)//板载IO输出
                    {
                        if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_IO_Name].bignore == false)
                        {
                            int val = int.MaxValue;
                            short uValue = bOn ? (short)0 : (short)1;
                            sRtn = gts.mc.GT_SetDoBit((short)Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_IO_Name].iCardNo, gts.mc.MC_GPO, (short)(Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_IO_Name].iBitNo + 1), uValue);
                            gts.mc.GT_GetDo((short)Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_IO_Name].iCardNo, gts.mc.MC_GPO, out val);
                        }
                        else
                        {
                            string str = "输出已被屏蔽";
                        }
                    }
                    else//扩展IO输出
                    {
                        if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_IO_Name].bignore == false)
                        {
                            ushort uiOutput = bOn == true ? (ushort)0 : (ushort)1;
                            sRtn = gts.mc.GT_SetExtIoBit((short)Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_IO_Name].iCardNo, (short)Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_IO_Name].iExtNo, (short)Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_IO_Name].iBitNo, uiOutput);
                        }
                        else
                        {
                            string str = "输出已被屏蔽";
                        }

                    }
                }
            }
            catch (Exception)
            {
            }
            return 0;
        }

        public bool GetInOn(string _IO_Name)
        {
            bool sRtn = false;
            try
            {


                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[_IO_Name].bignore == false)
                {
                    if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[_IO_Name].bBitInputStatus)
                    {
                        sRtn = true;

                    }
                    else
                    {
                        sRtn = false;
                    }
                }
                else
                {
                    sRtn = false;
                }

            }
            catch (Exception)
            {
                sRtn = false;
            }
            return sRtn;
        }
        public bool GetOutOn(string _IO_Name)
        {
            bool sRtn = false;
            try
            {
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_IO_Name].bignore == false)
                {

                    if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_IO_Name].bBitOutputStatus)
                    {
                        sRtn = true;

                    }
                    else
                    {
                        sRtn = false;
                    }

                }
                else
                {
                    sRtn = false;
                }
            }
            catch (Exception)
            {
                sRtn = false;
            }
            return sRtn;
        }
        /////////////////////////////////////////////////////////////////轴定位方法///////////////////////////////////////
        //判断命令执行结果
        public bool CommandResult(string command, short srtn)
        {
            if (srtn == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 单轴相对运动
        /// </summary>
        /// <param name="Aisx_Name">轴名称</param>
        /// <param name="postion">相对运动位置</param>
        /// <returns></returns>
        public int AxisPrfTrapRel(string Aisx_Name, double postion)
        {
            postion = postion * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].PlusFeed;
            mc.TTrapPrm tprm;
            short sResult;
            int ipos;
            //设置为点位模试
            sResult = mc.GT_PrfTrap((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1));
            if (!CommandResult("GT_PrfTrap", sResult))
            {
                return 0;
            }
            //读取点位运动参数           
            sResult = mc.GT_GetTrapPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), out tprm);
            if (!CommandResult("GT_GetTrapPrm", sResult))
            {
                return 0;
            }

            double Acc = (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Acc * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].PlusFeed) / (1000 * 1000);
            double Dec = (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Dec * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].PlusFeed) / (1000 * 1000);
            tprm.acc = Acc;
            tprm.dec = Dec;
            tprm.smoothTime = 30;
            //设置点位运动参数
            sResult = mc.GT_SetTrapPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), ref tprm);
            if (!CommandResult("GT_SetTrapPrm", sResult))
            {
                return 0;
            }
            sResult = mc.GT_ClrSts((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), 1);
            if (!CommandResult("GT_ClrSts", sResult))
            {
                return 0;
            }
            sResult = mc.GT_GetPos((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), out ipos);
            if (!CommandResult("GT_SetPos", sResult))
            {
                return 0;
            }
            //设置目标位置
            ipos = ipos + (int)postion;
            sResult = mc.GT_SetPos((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), ipos);
            if (!CommandResult("GT_SetPos", sResult))
            {
                return 0;
            }
            //设置轴运动速度
            sResult = mc.GT_SetVel((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Speed);
            if (!CommandResult("GT_SetVel", sResult))
            {
                return 0;
            }
            //启动轴运动
            sResult = mc.GT_Update((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, 1 << (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo));
            if (!CommandResult("GT_Update", sResult))
            {
                return 0;
            }
            return 0;
        }
        /// <summary>
        /// Jog模试运动  
        /// </summary>
        /// <param name="Aisx_Name">轴名</param>
        /// <param name="bAir">方向</param>
        /// <returns></returns>
        public int AxisPrfJogHome(string Aisx_Name, bool bAir)
        {
            mc.TJogPrm jog;
            short sResult;
            //设置为Jog运动模式
            sResult = mc.GT_PrfJog((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1));
            if (!CommandResult("GT_PrfJog", sResult))
            {
                return 0;
            }
            //读取Jog运动参数  
            sResult = mc.GT_GetJogPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), out jog);
            if (!CommandResult("GT_GetJogPrm", sResult))
            {
                return 0;
            }
            double dAcc = (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Acc * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].PlusFeed) / (1000 * 1000);
            double dDec = (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Dec * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].PlusFeed) / (1000 * 1000);
            jog.acc = dAcc;
            jog.dec = dDec;
            //设置Jog运动参数
            sResult = mc.GT_SetJogPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), ref jog);
            if (!CommandResult("GT_SetJogPrm", sResult))
            {
                return 0;
            }
            //设置Jog运动速度
            double Speed = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].搜索限位速度;
            if (bAir == true)
            {
            }
            else
            {
                Speed = -Speed;
            }
            //设置目标位置
            sResult = mc.GT_SetVel((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), Speed);
            if (!CommandResult("GT_SetVel", sResult))
            {
                return 0;
            }
            //启动轴
            sResult = mc.GT_Update((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, 1 << (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo);
            if (!CommandResult("GT_Update", sResult))
            {
                return 0;
            }
            return 0;
        }
        /// <summary>
        /// Jog模试运动  
        /// </summary>
        /// <param name="Aisx_Name">轴名</param>
        /// <param name="bAir">方向</param>
        /// <returns></returns>
        public int AxisPrfJog(string Aisx_Name, bool bAir)
        {
            mc.TJogPrm jog;
            short sResult;
            //设置为Jog运动模式
            sResult = mc.GT_PrfJog((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1));
            if (!CommandResult("GT_PrfJog", sResult))
            {
                return 0;
            }
            //读取Jog运动参数  
            sResult = mc.GT_GetJogPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), out jog);
            if (!CommandResult("GT_GetJogPrm", sResult))
            {
                return 0;
            }
            double dAcc = (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Acc * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].PlusFeed) / (1000 * 1000);
            double dDec = (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Dec * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].PlusFeed) / (1000 * 1000);
            jog.acc = dAcc;
            jog.dec = dDec;
            //设置Jog运动参数
            sResult = mc.GT_SetJogPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), ref jog);
            if (!CommandResult("GT_SetJogPrm", sResult))
            {
                return 0;
            }
            //设置Jog运动速度
            double Speed = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Speed;
            if (bAir == true)
            {
            }
            else
            {
                Speed = -Speed;
            }
            //设置目标位置
            sResult = mc.GT_SetVel((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), Speed);
            if (!CommandResult("GT_SetVel", sResult))
            {
                return 0;
            }
            //启动轴
            sResult = mc.GT_Update((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, 1 << (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo);
            if (!CommandResult("GT_Update", sResult))
            {
                return 0;
            }
            return 0;
        }
        /// <summary>
        /// 指定轴停止运动
        /// </summary>
        /// <param name="Aisx_Name">轴硬件配置名字</param>
        /// <param name="option">停止方式</param>
        /// <returns></returns>
        public TReturn StopAxis(string Aisx_Name, int option = 0)
        {
            StopAxisgts(Aisx_Name, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo, 0);
            return 0;
            //功能：指定轴停止运动
            //制动方式，0：减速停止，1：紧急停止
        }
        public int StopAxisgts(string Aisx_Name, int mask, int option)
        {
            // success return 0
            int iResult;
            if (mask < 8 && mask > -1)
            {
                iResult = gts.mc.GT_Stop((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, 1 << ((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo), 0);
                iResult = gts.mc.GT_PrfTrap((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1));
            }
            return 0;
        }

        /// <summary>
        /// 单多轴运动
        /// </summary>
        /// <param name="CardDateDictionary"> 自定义流程控制数据</param>
        /// <returns></returns>
        public int AxisPMoveAbsoluteToStop(Moves moves)
        {
            int iResult;
            int Ref = -1;
            string Aisx_Name = "";
            foreach (var item in moves.ListAxis)
            {
                if (item.AxisName != "")
                {
                    Aisx_Name = item.AxisName;
                }
                else
                {
                    Ref = (int)ERecvResult.单多轴运动失败;
                    return Ref;
                }
                if (AxisPMoveAbsoluteToStop(Aisx_Name, item.AxisPosition, item.AxisSpeed, item.AxisAcc, item.AxisDec) == 1)
                {
                    Ref = 0;
                }
                else
                {
                }
            }
            DateTime axisStartTime = DateTime.Now;
            int TimeOut = 10000;
            int NumCount = 0;
            while (true)
            {
                Thread.Sleep(0);
                NumCount = 0;
                foreach (var item in moves.ListAxis)
                {
                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.AxisName].Move_Done = false;
                    Thread.Sleep(1);
                    iResult = DetectingAxis(item.AxisName);
                    if (iResult == 1)
                    {
                        Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.AxisName].Move_Done = true;
                    }
                }
                foreach (var item in moves.ListAxis)
                {
                    if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.AxisName].Move_Done == true)
                    {
                        NumCount++;
                        if (NumCount >= moves.ListAxis.Count)
                        {
                            Ref = 0;
                            return Ref;
                        }
                    }
                }
                if ((DateTime.Now - axisStartTime).TotalSeconds > TimeOut)
                {
                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Move_Done = false;
                    Ref = (int)ERecvResult.单多轴运动失败;
                    return Ref;
                }
                if (Program.bEStop)
                {
                    Ref = (int)ERecvResult.急停;
                    return Ref;
                }

                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("激光器报警") && Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["激光器报警"].bBitInputStatus)
                {
                    Ref = (int)ERecvResult.激光器报警;
                    return Ref;
                }
            }
        }
        /// <summary>
        /// 单多轴回原点
        /// </summary>
        /// <param name="CardDateDictionary"> 自定义流程控制数据</param>
        /// <returns></returns>
        public int Go_home(string[] Asix_Name)
        {
            int Ref = -1;
            string Aisx_Name = "";
            for (int i = 0; i < Asix_Name.Length; i++)
            {
                Home_Start(Asix_Name[i]);
            }
            DateTime axisStartTime = DateTime.Now;
            int TimeOut = 10000;
            int NumCount = 0;
            while (true)
            {
                NumCount = 0;
                for (int i = 0; i < Asix_Name.Length; i++)
                {
                    if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name[i]].Go_HomeFinishi == true)
                    {
                        NumCount++;
                    }
                }
                if (NumCount >= Asix_Name.Length)
                {
                    Ref = 0;
                    return Ref;
                }
                if ((DateTime.Now - axisStartTime).TotalSeconds > TimeOut)
                {
                    Ref = (int)ERecvResult.回原点超时回原失败;
                    return Ref;
                }
                if (Program.bEStop)
                {
                    Ref = (int)ERecvResult.急停;
                    return Ref;
                }
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("激光器报警") && Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["激光器报警"].bBitInputStatus)
                {
                    Ref = (int)ERecvResult.激光器报警;
                    return Ref;
                }
            }
        }
        /// <summary>
        /// 绝对定位
        /// </summary>
        /// <param name="Aisx_Name">轴的硬件配置名   </param>
        /// <param name="postion">轴运动的位置</param>
        /// <param name="Speed">轴运动的速度</param>
        /// <param name="TimeOut">轴运动的超时时间</param>
        /// <returns></returns>
        public int AxisPMoveAbsoluteToStop(string Aisx_Name, double postion, double Speed, double Acc, double Dec, double TimeOut = 10000)
        {
            //success return 1
            //超时 return -1
            int iResult;
            int nPosition = (int)(postion * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].PlusFeed);
            // vel = Convert.ToDouble(runingVelRYtxt.Text.ToString());

            Acc = (Acc * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].PlusFeed) / (1000 * 1000);
            Dec = (Dec * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].PlusFeed) / (1000 * 1000);
            iResult = AxisPrfTrap((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo, nPosition, Speed, Acc, Dec);
            if (iResult != 0)
            {
                return 0;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 等待轴运行停止 
        /// </summary>
        /// <param name="car">卡号</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        public int DetectingAxis(string Aisx_Name)
        {//轴停止 return 1
            ////return 0/2暂认为异常
            int axisStatus;
            uint sClock;
            short sResult = 0;
            mc.GT_GetSts((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), out axisStatus, 1, out sClock);
            if ((axisStatus & 0x400) < 1)
            {
                sResult = 1;
            }
            return sResult;
        }
        /// <summary>
        /// 点位模试
        /// </summary>
        /// <param name="card"></param>
        /// <param name="axis"></param>
        /// <param name="postion"></param>
        /// <param name="vel"></param>
        /// <returns></returns>
        public TReturn AxisPrfTrap(short card, short axis, double postion, double vel, double acc, double dec)
        {

            mc.TTrapPrm trap;
            // return 1 success, 0 fail
            short sResult;
            //设置为点位模试
            sResult = mc.GT_PrfTrap(card, (short)(axis + 1));
            if (!CommandResult("GT_PrfTrap", sResult))
            {
                return 0;
            }
            //轴跟随功能
            // 读取点位模式运动参数
            sResult = gts.mc.GT_GetTrapPrm(card, (short)(axis + 1), out trap);
            //设置目标位置
            int postionP = (int)postion;
            sResult = mc.GT_SetPos(card, (short)(axis + 1), postionP);
            if (!CommandResult("GT_SetPos", sResult))
            {
                return 0;
            }
            trap.acc = acc;
            trap.dec = dec;
            sResult = mc.GT_SetTrapPrm(card, (short)(axis + 1), ref trap);
            if (!CommandResult("GT_SetTrapPrm", sResult))
            {
                return 0;
            }
            //设置轴运动速度
            sResult = mc.GT_SetVel(card, (short)(axis + 1), vel);
            if (!CommandResult("GT_SetVel", sResult))
            {
                return 0;
            }
            //清除状态
            sResult = mc.GT_ClrSts(card, (short)(axis + 1), 1);
            if (!CommandResult("GT_ClrSts", sResult))
            {
                return 0;
            }
            //启动轴运动
            sResult = mc.GT_Update(card, 1 << axis);
            if (!CommandResult("GT_Update", sResult))
            {
                return 0;
            }
            return 0;
        }
        /// <summary>
        /// 建立坐标系及插入圆弧数据
        /// </summary>
        /// <param name="Axis_One_Name">轴1名称</param>
        /// <param name="Axis_Two_Name">轴2名称</param>
        /// <param name="dAcc">加速度</param>
        /// <param name="dDec">减速度</param>
        /// <param name="dSpeed">速度</param>
        /// <param name="endSpeed">终点速度</param>
        /// <param name="posX">终点坐标：X</param>
        /// <param name="posY">终点坐标Y</param>
        /// <param name="centerX">相对于起点的坐标的偏移量X</param>
        /// <param name="centerY">相对于起点的坐标的偏移量Y</param>
        /// <param name="iCCW">方向：0顺时针，1逆时针</param>/
        /// ///
        /// <returns></returns>
        public int BuildCor_InsertArc(string Axis_One_Name, string Axis_Two_Name, double dAcc, double dDec, double dSpeed, double endSpeed, double posX, double posY, double centerX, double centerY, short iCCW, UniversalControlSystem.CoordinateType coordinateType)
        {
            int addFinish = 0;
            gts.mc.TCrdPrm crdPrm;
            bool BuildCorFinish = false;
            short sRtn = gts.mc.GT_GetCrdPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_One_Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_One_Name].BuildCorNum, out crdPrm);
            if (crdPrm.dimension == 0)
            {
                addFinish = BuildCor(Axis_One_Name, coordinateType);//建立坐标系
                if (addFinish == 0)
                {
                }
                else
                {
                    return addFinish;
                }
            }
            posX = posX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_One_Name].PlusFeed;
            posY = posY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Two_Name].PlusFeed;
            centerX = centerX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_One_Name].PlusFeed;
            centerY = centerY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_One_Name].PlusFeed;
            addFinish = InsertArc(Axis_One_Name, Axis_Two_Name, posX, posY, centerX, centerY, dSpeed, iCCW, dAcc, endSpeed);
            // addFinish = InsertArc(Axis_Two_Name, posX + dR, posY + dR, dR, dSpeed, iCCW, dAcc, 0);
            return addFinish;
        }
        /// <summary>
        /// XY圆弧插补运动
        /// </summary>
        /// <param name="Axis_One_Name"></param>
        /// <param name="Axis_Two_Name"></param>
        /// <param name="dAcc"></param>
        /// <param name="dDec"></param>
        /// <param name="dSpeed"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="dR"></param>
        /// <param name="iCCW"></param>
        /// <returns></returns>
        public int ArcXYMove(string Axis_One_Name, string Axis_Two_Name, double dAcc, double dDec, double dSpeed, double endSpeed, double posX, double posY, double dR, double CenterX, double CenterY, short iCCW)
        {
            gts.mc.TCrdPrm crdPrm;
            int Res = 0;
            short sRtn = gts.mc.GT_GetCrdPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Two_Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Two_Name].BuildCorNum, out crdPrm);
            if (crdPrm.dimension == 0)
            {
                Res = BuildCor(Axis_Two_Name, CoordinateType.XY);//建立坐标系
                if (Res == 0)
                {
                }
                else
                {
                    return Res;
                }
            }
            posX = posX / Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_One_Name].PlusFeed;
            posY = posY / Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Two_Name].PlusFeed;
            CenterX = CenterX / Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_One_Name].PlusFeed;
            CenterY = CenterY / Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Two_Name].PlusFeed;
            dR = dR / Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Two_Name].PlusFeed;
            int addFinish = InsertArc(Axis_One_Name, Axis_Two_Name, posX, posY, CenterX, CenterY, dSpeed, iCCW, dAcc, endSpeed);
            if (addFinish == 0)
            {
                Res = StartCure(0, 1);
                if (Res == 0)
                {
                }
                else
                {
                    return Res;
                }
            }
            int stime = 30000;
            DateTime starttime = DateTime.Now;
            while (true)
            {
                //Res = CureMoveDone(Axis_One_Name, out Res);
                Res = CureMoveDone(out Res);
                if (Res == 1)
                {
                }
                else if (Res == 0)
                {
                    //插补运行完成
                    break;
                }
                DateTime endtime = DateTime.Now;
                TimeSpan spantime = endtime - starttime;
                if (spantime.TotalMilliseconds > stime)
                {
                    Res = 0;
                    break;
                }
                if (Program.bEStop)
                {
                    Res = -33;
                    break;
                }
            }
            return Res;
        }
        /// <summary>
        /// 插补运行完成
        /// </summary>
        /// <param name="Axis_Name"></param>
        /// <param name="iStep"></param>
        /// <returns></returns>
        public int CureMoveDone(out int iStep)
        {
            short sRtn;
            short run;
            int segment;
            lock (lockObj)
            {
                sRtn = gts.mc.GT_CrdStatus(0, 1, out run, out segment, 0);
                iStep = run;
            }
            //run  0：该坐标系的该 FIFO 没有在运动；1：该坐标系的该 FIFO 正在进行插补运动。

            if (run == 1)
            {
                return 1;
            }
            else
            {
                gts.mc.GT_CrdClear(0, 1, 0);
                return 0;
            }
        }
        /// <summary>
        /// 向缓存区增加数据——圆 
        /// </summary>
        /// <param name="Axis_Name"></param>
        /// <param name="dPosX"></param>
        /// <param name="dPosY"></param>
        /// <param name="dR"></param>
        /// <param name="dSpeed"></param>
        /// <param name="iCCW"></param>
        /// <param name="dAcc"></param>
        /// <param name="dEndSpeed"></param>
        /// <returns></returns>
        public int InsertArc(string Axis_One_Name, string Axis_Two_Name, double dPosX, double dPosY, double CenterX, double CenterY, double dSpeed, short iCCW, double dAcc, double dEndSpeed)
        {
            short sRtn;
            lock (lockObj)
            {
                gts.mc.TCrdPrm crdPrm;
                sRtn = gts.mc.GT_GetCrdPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_One_Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_One_Name].BuildCorNum, out crdPrm);
                int iTargetPosX = (int)(dPosX);
                int iTargetPosY = (int)(dPosY);
                int iR = (int)(iTargetPosX - CenterX);
                int iR1 = (int)(iTargetPosY - CenterY);
                sRtn = gts.mc.GT_ArcXYC((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_One_Name].m_CardNo,
                        (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_One_Name].BuildCorNum,
                        iTargetPosX, iTargetPosY,
                        iR, iR1,
                        iCCW,
                        dSpeed,
                        dAcc,
                        dEndSpeed,
                        0);
            }
            if (sRtn != 0)
            {

                return -15;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 插补开始运行
        /// </summary>
        /// <param name="num"></param>
        /// <param name="bPreWelding"></param>
        /// <returns></returns>
        public int StartCure(short CardNum, short BuildCor)
        {
            short sRtn;
            lock (lockObj)
            {
                sRtn = gts.mc.GT_CrdStart(CardNum, BuildCor, 0);
                if (sRtn == 0)
                {
                    return 0;
                }
                else
                {
                    return -5;
                }

            }
        }
        /// <summary>
        /// 插补开始运行及检测停止
        /// </summary>
        /// <param name="Axis_One_Name"></param>
        /// <param name="Axis_Two_Name"></param>
        /// <returns></returns>
        public int StartCureToStop()
        {
            int Res = StartCure(0, 1);
            int stime = 20000;
            DateTime starttime = DateTime.Now;
            while (true)
            {
                Res = CureMoveDone(out Res);
                if (Res == 1)
                {
                    //插补运行中
                    //break;
                }
                else if (Res == 0)
                {
                    StaCor3D = false;
                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue("[插补开始运行]:插补运行停止");
                    // Weld_Log.Instance().Enqueue("[插补开始运行]:插补运行停止");
                    Res = 0;
                    //插补运行完成
                    break;
                }
                DateTime endtime = DateTime.Now;
                TimeSpan spantime = endtime - starttime;
                if (spantime.TotalMilliseconds > stime)
                {
                    Res = -6;
                    break;
                }
                if (Program.bEStop)
                {
                    Res = -33;
                    break;
                }
            }
            return Res;
        }

        static bool StaCor3D = false;
        /// <summary>
        /// 建立坐标系及插入直线数据
        /// </summary>
        /// <param name="Axis_One_Name"></param>
        /// <param name="Axis_Two_Name"></param>
        /// <param name="dAcc"></param>
        /// <param name="dDec"></param>
        /// <param name="dSpeed"></param>
        /// <param name="EndSpeed"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="coordinateType"></param>
        /// <returns></returns>
        public int BuildCor_InsertLine(Dictionary<string, double> Axis_Name, double dAcc, double dDec, double dSpeed, double EndSpeed)
        {
            gts.mc.TCrdPrm crdPrm;
            int Res = 0;
            string _Axis_Name = "";
            foreach (var item in Axis_Name)
            {
                if (_Axis_Name == "")
                {
                    _Axis_Name = item.Key;

                }
                //获取插补轴的位置
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].InterpolationPosition = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed * item.Value;
            }
            foreach (var item in Axis_Name)
            {
                //清除轴所在的坐标系

            }
            if (StaCor3D == false)
            { //建立坐标系
                Res = BuildCor3D(Axis_Name);
                StaCor3D = true;
            }


            //posX = posX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_One_Name].PlusFeed;
            //posY = posY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Two_Name].PlusFeed;
            short sRtn = gts.mc.GT_GetCrdPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].BuildCorNum, out crdPrm);
            if (crdPrm.dimension == 0)
            {
                Res = BuildCor3D(Axis_Name);
                if (Res == 0)
                {
                }
                else
                {
                    return Res;
                }
            }

            Res = InsertLine3D(Axis_Name, dSpeed, dAcc, EndSpeed);
            return Res;
        }
        /// <summary>
        /// 直线插补
        /// </summary>
        /// <param name="Axis_One_Name"> 1#轴名称</param>
        /// <param name="Axis_Two_Name"> 2#轴名称</param>
        /// <param name="dAcc">  轴加速度 </param>
        /// <param name="dDec">轴减速度</param>
        /// <param name="dSpeed">速度</param>
        /// <param name="posX">1#轴位置</param>
        /// <param name="posY">2#轴位置</param>
        /// <returns></returns>
        public int LineXYMove(Dictionary<string, double> Axis_Name, double dAcc, double dDec, double dSpeed, double EndSpeed)
        {
            gts.mc.TCrdPrm crdPrm;
            int Res = 0;
            string _Axis_Name = "";
            foreach (var item in Axis_Name)
            {
                if (_Axis_Name == "")
                {
                    _Axis_Name = item.Key;

                }
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].InterpolationPosition = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed * item.Value;
            }
            //posX = posX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_One_Name].PlusFeed;
            //posY = posY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Two_Name].PlusFeed;
            short sRtn = gts.mc.GT_GetCrdPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].BuildCorNum, out crdPrm);
            if (crdPrm.dimension == 0)
            {
                Res = 1;
            }
            //Dictionary<string, double> Axis_Name = new Dictionary<string, double> ();
            Res = BuildCor(Axis_Name);
            if (Res == 0)
            {
            }
            else
            {
                return Res;
            }

            Res = InsertLine(Axis_Name, dSpeed, dAcc, 0);
            if (Res == 0)
            {
                Res = StartCure(0, 1);
            }
            else
            {
                return Res;
            }
            DateTime starttime = DateTime.Now;
            int stime = 10000;
            while (true)
            {
                Res = CureMoveDone(out Res);
                // Res= CureMoveDone(Axis_One_Name, out Res);
                if (Res == 1)
                {
                    //插补运行中
                }
                else if (Res == 0)
                {
                    // Res = 1;
                    //清除缓冲区数据
                    gts.mc.GT_CrdClear((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].BuildCorNum, 0);
                    //插补运行完成
                    break;
                }
                DateTime endtime = DateTime.Now;
                TimeSpan spantime = endtime - starttime;
                if (spantime.TotalMilliseconds > stime)
                {
                    Res = 0;
                    break;
                }
                if (Program.bEStop)
                {
                    Res = -33;
                    break;
                }
            }
            return Res;
        }
        /// <summary>
        /// 向缓存区存入直线插补数据
        /// </summary>
        /// <param name="Axis_Name"></param>
        /// <param name="dPosX"></param>
        /// <param name="dPosY"></param>
        /// <param name="dSpeed"></param>
        /// <param name="dAcc"></param>
        /// <param name="dEndSpeed"></param>
        /// <returns></returns>
        public int InsertLine(Dictionary<string, double> Axis_Name, double dSpeed, double dAcc, double dEndSpeed)
        {
            short sRtn = 0;
            lock (lockObj)
            {
                int iTargetPosX = 0;
                int iTargetPosY = 0;
                int iTargetPosZ = 0;
                int iTargetPosU = 0;
                string _Axis_Name = "";
                int count = 0;
                foreach (var item in Axis_Name)
                {
                    if (_Axis_Name == "")
                    {
                        _Axis_Name = item.Key;
                    }
                    if (count == 0)
                    {
                        iTargetPosX = (int)(item.Value * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed);
                    }
                    else if (count == 1)
                    {
                        iTargetPosY = (int)(item.Value * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed);
                    }
                    else if (count == 2)
                    {
                        iTargetPosZ = (int)(item.Value * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed);
                    }
                    else if (count == 3)
                    {
                        iTargetPosU = (int)(item.Value * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed);
                    }
                    count++;
                }
                dAcc = (dAcc * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].PlusFeed) / (1000 * 1000);
                int BulidCordnum = Axis_Name.Count;
                switch (BulidCordnum)
                {
                    case 2:
                        sRtn = gts.mc.GT_LnXY(
                            (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].m_CardNo,   // 该插补段的坐标系是坐标系卡号
                            (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].BuildCorNum,  // 该插补段的坐标系是坐标系1
                            iTargetPosX, iTargetPosY, // 该插补段的终点坐标(X, Y)
                            dSpeed,         // 该插补段的目标速度：dSpeed pulse/ms
                            dAcc,                    // 插补段的加速度：dAcc pulse/ms^2
                            dEndSpeed,      // 终点速度
                            0);                      // 向坐标系1的FIFO0缓存区传递该直线插补数据
                        break;
                    case 3:
                        sRtn = gts.mc.GT_LnXYZ(
          (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].m_CardNo,   // 该插补段的坐标系是坐标系卡号
          (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].BuildCorNum,  // 该插补段的坐标系是坐标系1
          iTargetPosX, iTargetPosY, iTargetPosZ, // 该插补段的终点坐标(X, Y,Z)
          dSpeed,         // 该插补段的目标速度：dSpeed pulse/ms
          dAcc,                    // 插补段的加速度：dAcc pulse/ms^2
          dEndSpeed,      // 终点速度
          0);                      // 向坐标系1的FIFO0缓存区传递该直线插补数据
                        break;
                    case 4:
                        sRtn = gts.mc.GT_LnXYZA(
              (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].m_CardNo,   // 该插补段的坐标系是坐标系卡号
              (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].BuildCorNum,  // 该插补段的坐标系是坐标系1
              iTargetPosX, iTargetPosY, iTargetPosZ, iTargetPosU,  // 该插补段的终点坐标(X, Y,Z,U)
              dSpeed,         // 该插补段的目标速度：dSpeed pulse/ms
              dAcc,                    // 插补段的加速度：dAcc pulse/ms^2
              dEndSpeed,      // 终点速度
              0);                      // 向坐标系1的FIFO0缓存区传递该直线插补数据
                        break;
                }
            }
            if (sRtn == 0)
            {
                return 0;
            }
            else
            {
                return -15;
            }
        }
        //public enum CoordinateType
        //{
        //    XY,
        //    XZ,
        //    YZ,
        //    XYZ,
        //    XYZU,
        //    X1Y1,
        //    X1Z1,
        //    Y1Z1,
        //    X1Y1Z1,
        //    X1Y1Z1U1
        //}
        /// <summary>
        /// 建立坐标系
        /// </summary>
        /// <param name="num"></param>
        /// <param name="coordinateType"></param>
        /// <returns></returns>
        public int BuildCor(string Axis_Name, CoordinateType coordinateType)
        {
            short sRtn;
            gts.mc.TCrdPrm crdPrm;

            lock (lockObj)
            {
                sRtn = gts.mc.GT_GetCrdPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Name].BuildCorNum, out crdPrm);
                switch (coordinateType)
                {
                    case CoordinateType.XY:
                        crdPrm.dimension = 2;                        // 建立二维的坐标系
                        crdPrm.profile1 = 1;                       // 规划器1对应到X轴                       
                        crdPrm.profile2 = 2;                       // 规划器2对应到Y轴
                        crdPrm.profile3 = 0;                       // 规划器3对应到Z轴
                        break;
                    case CoordinateType.XZ:
                        crdPrm.dimension = 2;                        // 建立二维的坐标系
                        crdPrm.profile1 = 1;                       // 规划器1对应到X轴                       
                        crdPrm.profile2 = 0;                       // 规划器2对应到Y轴
                        crdPrm.profile3 = 3;                       // 规划器3对应到Z轴
                        break;
                    case CoordinateType.YZ:
                        crdPrm.dimension = 2;                        // 建立二维的坐标系
                        crdPrm.profile1 = 0;                       // 规划器1对应到X轴                       
                        crdPrm.profile2 = 2;                       // 规划器2对应到Y轴
                        crdPrm.profile3 = 3;                       // 规划器3对应到Z轴
                        break;
                    case CoordinateType.XYZ:
                        crdPrm.dimension = 3;                        // 建立三维的坐标系
                        crdPrm.profile1 = 1;                       // 规划器1对应到X轴                       
                        crdPrm.profile2 = 2;                       // 规划器2对应到Y轴
                        crdPrm.profile3 = 3;                       // 规划器3对应到Z轴
                        break;
                    default:
                        break;
                }
                crdPrm.synVelMax = 500;                      // 坐标系的最大合成速度是: 500 pulse/ms
                crdPrm.synAccMax = 2;                        // 坐标系的最大合成加速度是: 2 pulse/ms^2
                crdPrm.evenTime = 0;                         // 坐标系的最小匀速时间为0
                crdPrm.profile4 = 0;
                crdPrm.profile5 = 0;
                crdPrm.profile6 = 0;
                crdPrm.profile7 = 0;
                crdPrm.profile8 = 0;
                crdPrm.setOriginFlag = 1;                    // 需要设置加工坐标系原点位置
                crdPrm.originPos1 = 0;                       // 加工坐标系原点位置在(0,0,0)，即与机床坐标系原点重合
                crdPrm.originPos2 = 0;
                crdPrm.originPos3 = 0;
                crdPrm.originPos4 = 0;
                crdPrm.originPos5 = 0;
                crdPrm.originPos6 = 0;
                crdPrm.originPos7 = 0;
                crdPrm.originPos8 = 0;
                // 建立1号坐标系，设置坐标系参数
                sRtn = gts.mc.GT_SetCrdPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Name].BuildCorNum, ref crdPrm);
                if (sRtn == 0)
                {

                    return 0;
                }
                else
                {
                    return -16;
                }
            }
        }
        /// <summary>
        /// 建立坐标系
        /// </summary>
        /// <param name="num"></param>
        /// <param name="coordinateType"></param>
        /// <returns></returns>
        public int BuildCor(Dictionary<string, double> Axis_Name)
        {
            short sRtn;
            gts.mc.TCrdPrm crdPrm;

            lock (lockObj)
            {
                //不在一个坐标系处理
                string _Axis_Name = "";
                foreach (var item in Axis_Name)
                {
                    if (_Axis_Name == "")
                    {
                        _Axis_Name = item.Key;
                    }
                    gts.mc.GT_CrdClear((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].BuildCorNum, 0);
                }
                sRtn = gts.mc.GT_GetCrdPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].BuildCorNum, out crdPrm);
                crdPrm.profile1 = 0;
                crdPrm.profile2 = 0;
                crdPrm.profile3 = 0;
                crdPrm.profile4 = 0;
                crdPrm.profile5 = 0;
                crdPrm.profile6 = 0;
                crdPrm.profile7 = 0;
                crdPrm.profile8 = 0;
                crdPrm.dimension = (short)Axis_Name.Count;
                short count = 1;
                foreach (var item in Axis_Name)
                {
                    if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 0)
                    {
                        crdPrm.profile1 = count;
                    }
                    else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 1)
                    {
                        crdPrm.profile2 = count;

                    }
                    else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 2)
                    {
                        crdPrm.profile3 = count;

                    }
                    else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 3)
                    {
                        crdPrm.profile4 = count;
                    }
                    else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 4)
                    {
                        crdPrm.profile5 = count;
                    }
                    else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 5)
                    {
                        crdPrm.profile6 = count;

                    }
                    else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 6)
                    {
                        crdPrm.profile7 = count;
                    }
                    else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 7)
                    {
                        crdPrm.profile8 = count;
                    }
                    count++;
                }
                foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                {
                    if (item.Value.iCardNo == Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].m_CardNo)
                    {
                        if (item.Value.txt_MaxSpeed > 0 && item.Value.txt_MaxAcc > 0)
                        {
                            crdPrm.synVelMax = item.Value.txt_MaxSpeed;
                            crdPrm.synAccMax = item.Value.txt_MaxAcc;
                            break;
                        }

                    }
                }
                //crdPrm.synVelMax = 500;                      // 坐标系的最大合成速度是: 500 pulse/ms
                //crdPrm.synAccMax = 2;                        // 坐标系的最大合成加速度是: 2 pulse/ms^2
                crdPrm.evenTime = 0;                         // 坐标系的最小匀速时间为0

                crdPrm.setOriginFlag = 1;                    // 需要设置加工坐标系原点位置
                crdPrm.originPos1 = 0;                       // 加工坐标系原点位置在(0,0,0)，即与机床坐标系原点重合
                crdPrm.originPos2 = 0;
                crdPrm.originPos3 = 0;
                crdPrm.originPos4 = 0;
                crdPrm.originPos5 = 0;
                crdPrm.originPos6 = 0;
                crdPrm.originPos7 = 0;
                crdPrm.originPos8 = 0;
                // 建立坐标系，设置坐标系参数
                sRtn = gts.mc.GT_SetCrdPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].BuildCorNum, ref crdPrm);
                if (sRtn == 0)
                {
                    return 0;
                }
                else
                {
                    return -16;
                }
            }
        }
        /// <summary>
        /// 建立坐标系用于插入数据不运行
        /// </summary>
        /// <param name="num"></param>
        /// <param name="coordinateType"></param>
        /// <returns></returns>
        public int BuildCor3D(Dictionary<string, double> Axis_Name)
        {
            short sRtn;
            gts.mc.TCrdPrm crdPrm;

            lock (lockObj)
            {
                //不在一个坐标系处理
                string _Axis_Name = "";
                foreach (var item in Axis_Name)
                {
                    if (_Axis_Name == "")
                    {
                        _Axis_Name = item.Key;
                    }
                    gts.mc.GT_CrdClear((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].BuildCorNum, 0);
                }
                sRtn = gts.mc.GT_GetCrdPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].BuildCorNum, out crdPrm);
                crdPrm.profile1 = 0;
                crdPrm.profile2 = 0;
                crdPrm.profile3 = 0;
                crdPrm.profile4 = 0;
                crdPrm.profile5 = 0;
                crdPrm.profile6 = 0;
                crdPrm.profile7 = 0;
                crdPrm.profile8 = 0;
                crdPrm.dimension = (short)3;
                List<int> AsixdNo = new List<int>();
                foreach (var item in Axis_Name)
                {
                    AsixdNo.Add(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo);
                }
                if (AsixdNo.Max() < 4)
                {
                    crdPrm.profile1 = 1;
                    crdPrm.profile2 = 2;
                    crdPrm.profile3 = 3;
                    crdPrm.profile4 = 0;
                }
                else
                {
                    crdPrm.profile5 = 5;
                    crdPrm.profile6 = 6;
                    crdPrm.profile7 = 7;
                    crdPrm.profile8 = 0;
                }
                foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                {
                    if (item.Value.iCardNo == Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].m_CardNo)
                    {
                        if (item.Value.txt_MaxSpeed > 0 && item.Value.txt_MaxAcc > 0)
                        {
                            crdPrm.synVelMax = item.Value.txt_MaxSpeed;
                            crdPrm.synAccMax = item.Value.txt_MaxAcc;
                            break;
                        }

                    }
                }
                //crdPrm.synVelMax = 500;                      // 坐标系的最大合成速度是: 500 pulse/ms
                //crdPrm.synAccMax = 2;                        // 坐标系的最大合成加速度是: 2 pulse/ms^2
                crdPrm.evenTime = 0;                         // 坐标系的最小匀速时间为0

                crdPrm.setOriginFlag = 1;                    // 需要设置加工坐标系原点位置
                crdPrm.originPos1 = 0;                       // 加工坐标系原点位置在(0,0,0)，即与机床坐标系原点重合
                crdPrm.originPos2 = 0;
                crdPrm.originPos3 = 0;
                crdPrm.originPos4 = 0;
                crdPrm.originPos5 = 0;
                crdPrm.originPos6 = 0;
                crdPrm.originPos7 = 0;
                crdPrm.originPos8 = 0;
                // 建立坐标系，设置坐标系参数
                sRtn = gts.mc.GT_SetCrdPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].BuildCorNum, ref crdPrm);

                if (sRtn == 0)
                {
                    return 0;
                }
                else
                {
                    return -16;
                }
            }
        }
        /// <summary>
        /// 向缓存区存入直线插补数据
        /// </summary>
        /// <param name="Axis_Name"></param>
        /// <param name="dPosX"></param>
        /// <param name="dPosY"></param>
        /// <param name="dSpeed"></param>
        /// <param name="dAcc"></param>
        /// <param name="dEndSpeed"></param>
        /// <returns></returns>
        public int InsertLine3D(Dictionary<string, double> Axis_Name, double dSpeed, double dAcc, double dEndSpeed)
        {
            short sRtn = 0;
            lock (lockObj)
            {
                int iTargetPosX = 0;
                int iTargetPosY = 0;
                int iTargetPosZ = 0;
                int iTargetPosU = 0;
                string _Axis_Name = "";
                int count = 0;
                List<int> Cor = new List<int>();
                int[] Asix = new int[8];
                foreach (var item in Axis_Name)
                {
                    Asix[Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo] = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo;
                    Cor.Add(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo);
                    if (_Axis_Name == "")
                    {
                        _Axis_Name = item.Key;
                    }
                    if (count == 0)
                    {
                        iTargetPosX = (int)(item.Value * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed);
                        if (iTargetPosX == 0)
                        {
                            iTargetPosX = (int)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].AisxCurrentPosition * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed);
                        }
                    }
                    else if (count == 1)
                    {
                        iTargetPosY = (int)(item.Value * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed);
                        if (iTargetPosY == 0)
                        {
                            iTargetPosY = (int)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].AisxCurrentPosition * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed);
                        }
                    }
                    else if (count == 2)
                    {
                        iTargetPosZ = (int)(item.Value * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed);
                        if (iTargetPosZ == 0)
                        {
                            iTargetPosZ = (int)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].AisxCurrentPosition * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed);
                        }
                    }
                    count++;
                }
                if (Asix.Max() <= 3)
                {
                    Asix[0] = 0;
                    Asix[1] = 1;
                    Asix[2] = 2;
                    Asix[3] = 3;

                    Asix[4] = 10;
                    Asix[5] = 11;
                    Asix[6] = 12;
                    Asix[7] = 13;
                }
                else
                {
                    Asix[0] = 10;
                    Asix[1] = 11;
                    Asix[2] = 12;
                    Asix[3] = 13;
                    Asix[4] = 4;
                    Asix[5] = 5;
                    Asix[6] = 6;
                    Asix[7] = 7;
                }
                string[] AsixNmame = new string[8];
                foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                {
                    for (int i = 0; i < Asix.Length; i++)
                    {
                        if (item.Value.m_AxisNo == Asix[i])
                        {
                            AsixNmame[i] = item.Value.Axis_hardwareName;
                        }
                    }
                }
                int[] Pos = new int[8];

                foreach (var item in Axis_Name)
                {
                    for (int i = 0; i < AsixNmame.Length; i++)
                    {
                        if (item.Key == AsixNmame[i])
                        {
                            Pos[i] = (int)(item.Value * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed);
                        }
                        //else
                        //{
                        //    Pos[i] = (int)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].PlusFeed * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].AisxCurrentPosition);
                        //}
                    }

                }
                for (int i = 0; i < Pos.Length; i++)
                {
                    if (Pos[i] == 0)
                    {
                        if (AsixNmame[i] != null)
                        {
                            Pos[i] = (int)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[AsixNmame[i]].PlusFeed * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[AsixNmame[i]].AisxCurrentPosition);
                        }

                    }
                    else
                    {

                    }
                }
                dAcc = (dAcc * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].PlusFeed) / (1000 * 1000);
                int BulidCordnum = Axis_Name.Count;
                sRtn = gts.mc.GT_LnXYZ(
                    (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].m_CardNo,   // 该插补段的坐标系是坐标系卡号
                    (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Axis_Name].BuildCorNum,  // 该插补段的坐标系是坐标系1
                      Pos[0], Pos[1], Pos[2], // 该插补段的终点坐标(X, Y,Z)
                    dSpeed,         // 该插补段的目标速度：dSpeed pulse/ms
                    dAcc,                    // 插补段的加速度：dAcc pulse/ms^2
                    dEndSpeed,      // 终点速度
                    0);                      // 向坐标系1的FIFO0缓存区传递该直线插补数据
            }
            if (sRtn == 0)
            {
                return 0;
            }
            else
            {
                return -15;
            }
        }
        /////////////////////////////////回原点//////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Asix_Name"></param>
        public void GO_Home(string Asix_Name)
        {
            Home_Start(Asix_Name);
            //   ParameterizedThreadStart paramLoopFunc1 = new ParameterizedThreadStart(Home_Start);
            //System.Threading.Thread threadList = new Thread(paramLoopFunc1);
            //threadList.IsBackground = true;
            //threadList.Start(Asix_Name);        
        }

        public void Home_Start(object _Asix_name)
        {
            string Asix_Name = _Asix_name.ToString();
            Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Go_HomeFinishi = false;
            StartSearchLimit(Asix_Name);

            StartSearchHome(Asix_Name, true);
            Thread.Sleep(100);
            int RES = ZeroAxisPos(Asix_Name);
            if (RES == 1)
            {
                if (Program.bEStop || Program.bStop)
                {
                    StopAxis(Asix_Name);//停止轴运动
                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].AisxCurrentPosition = 0;
                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Go_HomeFinishi = false;
                }
                else
                {

                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].AisxCurrentPosition = 0;
                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Go_HomeFinishi = true;
                }
            }
            else
            {
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Go_HomeFinishi = false;
            }

        }
        /// <summary>
        /// 回原点异步方法
        /// </summary>
        /// <param name="_Asix_name"></param>
        public async void Home_Start(string _Asix_name)
        {
            await Task.Run(() =>
            {
                string Asix_Name = _Asix_name.ToString();
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Go_HomeFinishi = false;


                StartSearchLimit(Asix_Name);
                Thread.Sleep(500);
                StartSearchHome(Asix_Name, true);
                Thread.Sleep(500);
                int RES = ZeroAxisPos(Asix_Name);
                if (RES == 1)
                {
                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].AisxCurrentPosition = 0;
                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Go_HomeFinishi = true;
                }
                else
                {
                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Go_HomeFinishi = false;
                }
            });

        }
        private int StartSearchLimit(string Asix_Name)
        {
            int sRtn = 0;
            if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].bCCWL == true &&
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].回原方式 == "负限位回原")
            {

                return 0;
            }
            else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].bCCWL == false &&
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].回原方式 == "负限位回原")
            {
                sRtn = AxisPrfJogHome(Asix_Name, false);
                DateTime starttime = DateTime.Now;
                int stime = 50000;
                while (true)
                {
                    Thread.Sleep(20);
                    DateTime endtime = DateTime.Now;
                    TimeSpan spantime = endtime - starttime;
                    if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].bCCWL == true)
                    {
                        gts.mc.GT_Stop((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_CardNo, 1 << ((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_AxisNo), 0);
                        gts.mc.GT_PrfTrap((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_CardNo, (short)((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_AxisNo + 1));
                        // Googol_Contral.StopAxis(Asix_Name);
                        break;
                    }
                    if (spantime.TotalMilliseconds > stime)
                    {
                        break;
                    }
                    if (Program.bEStop)
                    {
                        StopAxis(Asix_Name);//停止轴运动
                        break;
                    }
                    if (Program.bStop)
                    {
                        StopAxis(Asix_Name);//停止轴运动
                        break;
                    }
                }

            }

            if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].bCWL == true &&
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].回原方式 == "正限位回原")
            {
                return 0;
            }
            else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].bCWL == false &&
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].回原方式 == "正限位回原")
            {
                sRtn = AxisPrfJog(Asix_Name, true);
                DateTime starttime = DateTime.Now;
                int stime = 30000;
                while (true)
                {
                    Thread.Sleep(20);
                    DateTime endtime = DateTime.Now;
                    TimeSpan spantime = endtime - starttime;
                    if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].bCWL == true)
                    {
                        gts.mc.GT_Stop((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_CardNo, 1 << ((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_AxisNo), 0);
                        gts.mc.GT_PrfTrap((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_CardNo, (short)((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_AxisNo + 1));
                        // Googol_Contral.StopAxis(Asix_Name);
                        break;
                    }
                    if (spantime.TotalMilliseconds > stime)
                    {
                        break;
                    }
                    if (Program.bEStop)
                    {
                        StopAxis(Asix_Name);//停止轴运动
                        break;
                    }
                    if (Program.bStop)
                    {
                        StopAxis(Asix_Name);//停止轴运动
                        break;
                    }
                }


            }
            return sRtn;
        }

        private int StartSearchHome(string Aisx_Name, bool bAir)
        {
            short sResult;
            short sRtn;
            gts.mc.TTrapPrm trapPrm;

            sRtn = gts.mc.GT_SetCaptureMode((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo,
                (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), gts.mc.CAPTURE_HOME);

            // 切换到点位运动模式
            sRtn = gts.mc.GT_PrfTrap((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo,
                (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1));

            // 读取点位模式运动参数
            sRtn = gts.mc.GT_GetTrapPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo,
                (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), out trapPrm);
            double dAcc = (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Acc * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].PlusFeed) / (1000 * 1000);
            double dDec = (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].Dec * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].PlusFeed) / (1000 * 1000);
            trapPrm.acc = dAcc;
            trapPrm.dec = dDec;
            //trapPrm.acc = 0.25;
            //    trapPrm.dec = 0.25;
            // 设置点位模式运动参数
            sRtn = gts.mc.GT_SetTrapPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), ref trapPrm);
            // 设置点位模式目标速度，即回原点速度
            double Speed = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].GoHomeSpeed;
            sRtn = gts.mc.GT_SetVel((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), Math.Abs(Speed));
            // 设置点位模式目标位置，即原点搜索距离
            int dSearchDis = 0;

            dSearchDis = 999999999;

            sRtn = gts.mc.GT_SetPos((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), dSearchDis);
            // 启动运动
            sRtn = gts.mc.GT_Update((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, 1 << (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo));
            while (true)
            {
                //short sRtn;
                short capture;
                uint clk;
                int pos = 0;
                // 读取捕获状态
                sRtn = gts.mc.GT_GetCaptureStatus((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo + 1), out capture, out pos, 1, out clk);
                if (capture == 1)
                {
                    gts.mc.GT_Stop((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo, 1 << ((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo), 0);
                    break;
                }
                else
                {

                }
                if (Program.bEStop)
                {
                    StopAxis(Aisx_Name);//停止轴运动
                    break;
                }
                if (Program.bStop)
                {
                    StopAxis(Aisx_Name);//停止轴运动
                    break;
                }

            }
            return 1;
        }

        private int ZeroAxisPos(string Asix_Name)
        {
            short sRtn;
            int Res = 0;
            if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_AxisNo < 8 && Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_AxisNo > -1)
            {
                lock (lockObj)
                {
                    Thread.Sleep(200);
                    sRtn = gts.mc.GT_ZeroPos((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_AxisNo + 1), 1);
                    if (sRtn == 0)
                        Res = 1;
                    else
                        Res = 0;

                }
            }
            else
            {

            }
            return Res;
        }
        //////////////////////手轮/////////////////////////
        public bool StartManualPulserOperation(string Asix_Name, int MultiplyingPower)
        {
            bool blFlag = false;        //内部状态
            try
            {
                short re = gts.mc.GT_EndHandwheel(0, ((short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_AxisNo + 1)));
                short ret = -1;
                ret = gts.mc.GT_HandwheelInit(0);
                ret += gts.mc.GT_SetHandwheelStopDec(0, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_AxisNo + 1), 0.5, 0.5);
                ret += gts.mc.GT_StartHandwheel(0, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_AxisNo + 1), 11, 1, (short)MultiplyingPower, 1, 0.5, 0.5, 100, 200);

                if (ret != 0)
                {
                    blFlag = false;
                    ret = gts.mc.GT_EndHandwheel(0, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_AxisNo + 1));
                    if (ret != 0)
                    {

                    }
                }
                else
                {
                    blFlag = true;
                }

            }
            catch (Exception)
            {
                blFlag = false;
                gts.mc.GT_EndHandwheel(0, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_AxisNo + 1));
            }
            return blFlag;
        }

        public bool StopManualPulserOperation(string Asix_Name)
        {
            short ret = -1;
            bool blFlag = false;

            ret = gts.mc.GT_EndHandwheel(0, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].m_AxisNo + 1));
            if (ret != 0)
            {
                blFlag = false;
            }
            else
            {
                blFlag = true;
            }
            return blFlag;
        }
        ////////////////////////模拟量获取与设置/////////////////
        public static int GT_GetAdc(short Cardnum, short adcout, out double dbRet)
        {
            uint clk;
            //double dbRet = 0.0;
            short rtn = gts.mc.GT_GetAdc(0/*usCardNo*/, adcout, out dbRet, 1, out clk);
            if (rtn == 0)
            {
                return 0;
            }
            else
            {
                return -21;
            }

        }
        public int GT_SetAdc()
        {
            short ret = 0;
            ret = gts.mc.GT_LaserPowerMode(0, 2, 10, 0, 1, 0);     //设置为模拟量模式
            ret = gts.mc.GT_LaserPrfCmd(0, 9, 1);       //设置输出电压为5V	
            ret = gts.mc.GT_SetHSIOOpt(0, 1, 1);               //打开激光


            ////short ret = 0;
            ////ret = gts.mc.GT_LaserPowerMode(0, 2, 5, 0, 1, 0);     //设置为模拟量模式
            ////ret = gts.mc.GT_LaserPrfCmd(0, 5, 1);       //设置输出电压为5V	
            ////ret = gts.mc.GT_SetHSIOOpt(0, 1, 1);               //打开激光
            //uint clk;
            ////double dbRet = 0.0;
            ////卡号  
            //// 激光能量输出模式//0：占空比输出模式 1； 1：频率输出模式；      2：模拟量输出模式；
            ////占空比、频率或模拟量输出的最大值
            ////占空比、频率或模拟量输出的最小值
            ////激光通道号：0 或 1
            ////0: 不使用激光开关延时功能，并将激光开关关联到位置比较输出,1：使用激光开关延时功能
            //short rtn = gts.mc.GT_LaserPowerMode(0,2, 5, 0, 1, 0);
            ////卡号  
            ////当能量输出模式为模拟量输出时，该值为电压值，单位为：V
            ////激光通道号：0 或 1
            //rtn = gts.mc.GT_LaserPrfCmd(0,5, 1);  // 设置输出电压为 2.5V     
            ////卡号 
            //// 0：关闭激光；（HSIO + 由低电平变化为高电平）1：打开激光；（HSIO + 由复位高电平变化为低电平）
            ////激光通道号：0 或 1
            //rtn = gts.mc.GT_SetHSIOOpt(0,1, 1); // 打开激光开关
            return 0;
        }
        /// <summary>
        /// 数字量获取
        /// </summary>
        /// <param name="High_Str">串口</param>
        /// <param name="Higt_Date"></param>
        ///  /// <param name="_High_Str">资源</param>
        /// <returns></returns>
        public int Get_I_High_Data(string High_Str, string _High_Str, out double Higt_Date)
        {
            Higt_Date = 0.0;
            double CurrentZA = 0;
            string date = "";
            int Err = -1;
            CommunicationFun.SendDate(High_Str, "SR,00,037", out date);
            // date= CommunicationFun.GetRec(High_Str);
            string Asix_Name = "";
            double NeedHigh = 0;
            //string RecData =  CommunicationFun.GetRec(High_Str);
            if (!date.Contains("ER") && date != "")
            {
                string[] _RecData = date.Split(',');
                _RecData[3] = _RecData[3].Replace("+", "").Replace("-", "").Replace("\r\n", "");
                string _getDataHigh = _RecData[3];
                foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                {
                    if (item.Value.是否做测距轴 == 1)
                    {
                        Asix_Name = item.Value.Axis_hardwareName;
                        CurrentZA = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition;
                    }
                }
                NeedHigh = Convert.ToDouble(_getDataHigh);
                Higt_Date = CurrentZA + NeedHigh;

            }
            else
            {
                return -29;

            }
            if (28 > NeedHigh && NeedHigh > -28)
            {

            }
            else
            {
                return -29;

            }
            bool SaveHigh = false;
            bool _SaveHigh = false;
            if (Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[_High_Str].Z轴安全高度最高 > Higt_Date && Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[_High_Str].Z轴安全高度最低 < Higt_Date)
            {
                SaveHigh = true;
            }
            else
            {
                SaveHigh = false;
            }


            double high = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[_High_Str].调高最高;
            double low = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[_High_Str].调高最低;
            if (high > NeedHigh && -low < NeedHigh)
            {
                _SaveHigh = true;
            }
            else
            {
                _SaveHigh = false;
            }

            if (_SaveHigh == true && SaveHigh == true)
            {
                Err = 0;
            }
            else if (_SaveHigh == false || SaveHigh == false)
            {
                Err = -29;
            }
            return Err;
        }
        public int Get_High_Date(string High_Str, out double Higt_Date)
        {
            Higt_Date = 0.0;
            double ReferenceAnalog = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[High_Str].基准点模拟量;//、、 获取基准模拟量   
            Thread.Sleep(800);
            double date = 0.0;
            //卡号
            //通道号
            //数据
            GT_GetAdc((short)Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[High_Str]._Card_Num, (short)Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[High_Str]._Channel_Number, out date);// 当前模拟量
            double GetReferenceCoordinates = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[High_Str].基准Z坐标;
            double AnalogDifference = ReferenceAnalog - date;//模拟量差值
            double AssociatedData = 0; //关联数据
            AssociatedData = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[High_Str].关联后所对应;
            double CurrentZA = 0;
            string Asix_Name = "";
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (item.Value.是否做测距轴 == 1)
                {
                    Asix_Name = item.Value.Axis_hardwareName;
                    CurrentZA = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition;
                }
            }
            if (AnalogDifference > 0)
            {
                double s = Math.Abs(AnalogDifference);
                double z = s / AssociatedData;
                Higt_Date = CurrentZA - z;
                //Higt_Date = z;
            }
            else
            {
                double s = Math.Abs(AnalogDifference);
                double z = s / AssociatedData;
                Higt_Date = CurrentZA + z;
                //  Higt_Date = z;
            }
            bool SaveHigh = false;

            if (Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[High_Str].Z轴安全高度最高 > Higt_Date && Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[High_Str].Z轴安全高度最低 < Higt_Date)
            {
                SaveHigh = true;
            }
            else
            {
                SaveHigh = false;
            }
            double high = GetReferenceCoordinates + Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[High_Str].调高最高;
            double low = GetReferenceCoordinates - Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[High_Str].调高最低;
            if (high > Higt_Date && low < Higt_Date)
            {
                SaveHigh = true;
            }
            else
            {
                SaveHigh = false;
            }
            if (SaveHigh == true)
            {
                return 0;
            }
            else
            {
                return -29;
            }
        }
        public void 调高_方法(string Name)
        {
            // double ReferenceAnalog =Convert.ToDouble( 基准点模拟量.Text);//、、 获取基准模拟量
            string Str = "";
            //foreach (var item in Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary)
            //{
            //    if (item.Value.默认参数==true)
            //    {
            //        Str = item.Value.Get_High_hardwareName;
            //    //}              
            //}   

            double ReferenceAnalog = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[Name].基准点模拟量;//、、 获取基准模拟量   
            Thread.Sleep(100);
            double date = 0.0;
            //卡号
            //通道号
            //数据
            Googol_Contral.GT_GetAdc(0, 1, out date);// 当前模拟量
                                                     // double GetReferenceCoordinates = Convert.ToDouble(基准Z坐标.Text);//获取Z基准坐标
            double GetReferenceCoordinates = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[Name].基准Z坐标;
            double AnalogDifference = ReferenceAnalog - date;//模拟量差值
            double AssociatedData = 0; //关联数据
            AssociatedData = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[Name].关联后所对应;
            //  AssociatedData = Convert.ToDouble(关联后所对应.Text); //关联数据
            double CurrentZA = 0;
            string Asix_Name = "";
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (item.Value.是否做测距轴 == 1)
                {
                    Asix_Name = item.Value.Axis_hardwareName;
                    CurrentZA = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition;
                }
            }
            if (AnalogDifference > 0)
            {
                double s = Math.Abs(AnalogDifference);
                double z = s / AssociatedData;
                double NeedCurrentZA = CurrentZA - z;
                if (Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[Name].Z轴安全高度最高 > NeedCurrentZA && Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[Name].Z轴安全高度最低 < NeedCurrentZA)
                {
                    double high = GetReferenceCoordinates + Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[Name].调高最高;
                    double low = GetReferenceCoordinates - Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[Name].调高最低;
                    if (high > NeedCurrentZA && low < NeedCurrentZA)
                    {

                        //   Googol_Contral.AxisPMoveAbsoluteToStop(Asix_Name, NeedCurrentZA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Dec);

                    }
                }


            }
            else
            {
                double s = Math.Abs(AnalogDifference);
                double z = s / AssociatedData;
                double NeedCurrentZA = CurrentZA + z;
                if (Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[Name].Z轴安全高度最高 > NeedCurrentZA && Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[Name].Z轴安全高度最低 < NeedCurrentZA)
                {
                    double high = GetReferenceCoordinates + Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[Name].调高最高;
                    double low = GetReferenceCoordinates - Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[Name].调高最低;
                    if (high > NeedCurrentZA && low < NeedCurrentZA)
                    {

                        //   Googol_Contral.AxisPMoveAbsoluteToStop(Asix_Name, NeedCurrentZA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Dec);

                    }
                }

            }
        }
        /// <summary>
        /// 高速IO输出
        /// </summary>
        /// <param name="num"></param>
        public async Task<int> LaserControl_async_Fun(string Name, int num)
        {
            int res = await Task.Run(() =>
        {
            KeyValuePair<string, bool> Out4 = new KeyValuePair<string, bool>();
            KeyValuePair<string, bool> Out1 = new KeyValuePair<string, bool>();
            KeyValuePair<string, bool> Out2 = new KeyValuePair<string, bool>();
            KeyValuePair<string, bool> Out3 = new KeyValuePair<string, bool>();
            List<KeyValuePair<string, bool>> Out_List = new List<KeyValuePair<string, bool>>();

            string IONum = Convert.ToString(num, 2);
            string 高速IO激光口1 = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name + "_" + "第1段波形"].高速IO激光口1;
            string 高速IO激光口2 = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name + "_" + "第1段波形"].高速IO激光口2;
            string 高速IO激光口3 = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name + "_" + "第1段波形"].高速IO激光口3;
            string 高速IO激光口4 = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name + "_" + "第1段波形"].高速IO激光口4;
            string 高速IO口激光完成 = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name + "_" + "第1段波形"].高速IO口激光完成;
            string 高速IO输出口 = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name + "_" + "第1段波形"].高速IO输出口;
            IONum = IONum.PadRight(4, '0');
            if (IONum[0] == 1)
            {
                Out1 = new KeyValuePair<string, bool>(高速IO激光口1, true);
            }
            else
            {
                Out1 = new KeyValuePair<string, bool>(高速IO激光口1, false);
            }
            if (IONum[1] == 1)
            {
                Out2 = new KeyValuePair<string, bool>(高速IO激光口2, true);
            }
            else
            {
                Out2 = new KeyValuePair<string, bool>(高速IO激光口2, false);
            }
            if (IONum[2] == 1)
            {
                Out3 = new KeyValuePair<string, bool>(高速IO激光口3, true);
            }
            else
            {
                Out3 = new KeyValuePair<string, bool>(高速IO激光口3, false);
            }
            if (IONum[3] == 1)
            {
                Out4 = new KeyValuePair<string, bool>(高速IO激光口4, true);
            }
            else
            {
                Out4 = new KeyValuePair<string, bool>(高速IO激光口4, false);
            }
            Out_List.Add(Out1);
            Out_List.Add(Out2);
            Out_List.Add(Out3);
            Out_List.Add(Out4);
            for (int i = 0; i < Out_List.Count; i++)
            {
                SetOutBit(Out_List[i].Key, Out_List[i].Value);
            }
            SetOutBit(高速IO输出口, true);
            while (true)
            {
                Thread.Sleep(20);
                if (GetInOn(高速IO口激光完成) == true)
                {
                }
                else
                {
                    break;
                }
            }
            for (int i = 0; i < Out_List.Count; i++)
            {
                SetOutBit(Out_List[i].Key, false);
            }
            SetOutBit(高速IO输出口, false);
            return 0;
        });
            return res;
        }
        static List<double> date = new List<double>();
        /// <summary>
        /// 模拟量排序
        /// </summary>
        /// <param name="Name"></param>
        /// <summary>
        /// 
        public static async void sort(string Name)
        {
            date.Clear();
            double lastVoltages = 0;
            double lastTimes = 0;
            double StartTimes = 0;
            foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
            {

                if (item.Value.Wave_hardwareName.Contains(Name))
                {
                    double K = 0;
                    if (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Times != 0)
                    {
                        K = (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Voltages - lastVoltages) / (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Times - lastTimes);
                    }
                    else
                    {
                        K = 0;
                    }
                    int count = 0;
                    while (true)
                    {
                        if (count <= Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Times)
                        {
                            double current_Date_V = ((Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Times - count) * K) - Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Voltages;
                            date.Add(current_Date_V);
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                lastVoltages = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Voltages;
            }
        }


        static MillisecondTimer timer;//最小定时时间1ms，新开一个线程执行任务
        //定义委托
        public delegate void SetControlValue(object value);
        /// 模拟量输出
        /// </summary>
        /// <param name="Name"></param>
        public static void LaserControl_async_(string Name)
        {
            sort(Name);
            timer.Start();
        }
        static int count = 0;
        private void sysTimer_Tick(object sender, EventArgs e)
        {
            count++;
            try
            {
                //await Task.Run(() =>
                //{
                outV(count);

                //  });

            }
            catch
            {
            }
            if (count > date.Count)
            {
                count = 0;
                timer.Stop();
            }
        }
        object LOCK = new object();
        public void outV(int v)
        {
            lock (LOCK)
            {
                double Vnum = date[v];
                Vnum = Math.Abs(Vnum);
                //控制卡号
                //激光能量输出模式0：占空比输出模式 1；     1：频率输出模式；     2：模拟量输出模式；
                //最大电压设置
                //最小电压设置
                //输出电压通道号  激光输出通道号是1
                //0: 不使用激光开关延时功能，并将激光开关关联到位置比较输出         1：使用激光开关延时功能
                gts.mc.GT_LaserPowerMode(0, 2, 10, 0, 1, 0);
                //设置为模拟量模式   //设置为模拟量模式  //控制卡号 //设置输出电压  // 激光输出通道号是1                                                                                                                                                                                               
                // gts.mc.GT_LaserPrfCmd((short)item.Value.Wave_channel_Card_num, item.Value.Voltages, (short)item.Value.Wave_channel_num);       //设置输出电压为5V // 控制卡号  //   输出电压1是启动    0是停止 // 激光输出通道号是1
                gts.mc.GT_LaserPrfCmd(0, Vnum, 1);
                //设置输出电压为0V	
                //设置输出电压为5V // 控制卡号  //   输出电压1是启动    0是停止 // 激光输出通道号是1
                gts.mc.GT_SetHSIOOpt(0, 1, 1);               //打开激光
                                                             //  logger.Info("-" + v + "-" + Vnum);
            }
        }
        /// 模拟量输出
        /// </summary>
        /// <param name="Name"></param>
        public static async void LaserControl_async_Fun(string Name)
        {
            await Task.Run(() =>
            {
                double lastVoltages = 0;
                double lastTimes = 0;
                double StartTimes = 0;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(Name))
                    {
                        lastTimes = 0;
                        double K = 0;
                        if (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Times != 0)
                        {
                            K = (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Voltages - lastVoltages) / (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Times - lastTimes);
                        }
                        else
                        {
                            K = 0;
                        }
                        //计算斜率                    
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Laser_Run_Finish = false;
                        DateTime starttime = DateTime.Now;
                        var pt1 = new HiperTimer();
                        pt1.Start();
                        while (true)
                        {
                            pt1.Stop();
                            if (pt1.EliminatedMilliSecond > item.Value.Times)
                            {
                                break;
                            }
                            if (pt1.EliminatedMilliSecond > 0.01)
                            {
                                double current_Date_V = ((Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Times - pt1.EliminatedMilliSecond) * K) - Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Voltages;
                                Hard_Ward_Contral.currentV = Math.Abs(current_Date_V);
                                //控制卡号
                                //激光能量输出模式0：占空比输出模式 1；     1：频率输出模式；     2：模拟量输出模式；
                                //最大电压设置
                                //最小电压设置
                                //输出电压通道号  激光输出通道号是1
                                //0: 不使用激光开关延时功能，并将激光开关关联到位置比较输出         1：使用激光开关延时功能
                                gts.mc.GT_LaserPowerMode((short)item.Value.Wave_channel_Card_num, (short)item.Value.laserPowerMode, (short)item.Value.High_Voltage, 0, (short)item.Value.Wave_channel_num, 0);     //设置为模拟量模式  //控制卡号 //设置输出电压  // 激光输出通道号是1                                                                                                                                                                                               
                                                                                                                                                                                                                   // gts.mc.GT_LaserPrfCmd((short)item.Value.Wave_channel_Card_num, item.Value.Voltages, (short)item.Value.Wave_channel_num);       //设置输出电压为5V // 控制卡号  //   输出电压1是启动    0是停止 // 激光输出通道号是1
                                gts.mc.GT_LaserPrfCmd((short)item.Value.Wave_channel_Card_num, Hard_Ward_Contral.currentV, (short)item.Value.Wave_channel_num);       //设置输出电压为5V // 控制卡号  //   输出电压1是启动    0是停止 // 激光输出通道号是1
                                gts.mc.GT_SetHSIOOpt((short)item.Value.Wave_channel_Card_num, 1, (short)item.Value.Wave_channel_num);               //打开激光 
                                                                                                                                                    //var pt = new HiperTimer();
                                UsDelay(1);
                                //Weld_Log.Instance().Enqueue("时间:" + pt1.EliminatedMilliSecond + "——");
                                logger.Info("时间:" + pt1.EliminatedMilliSecond + "——" /*+ "电压:" + Hard_Ward_Contral.currentV.ToString()*/);
                                //Delay(1);

                                // Thread.Sleep(1);
                                // lastTimes = lastTimes + 1;
                            }
                        }
                        lastVoltages = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Voltages;
                    }
                }

                gts.mc.GT_LaserPowerMode(0, 2, 10, 0, 1, 0);     //设置为模拟量模式
                gts.mc.GT_LaserPrfCmd(0, 0, 1);       //设置输出电压为0V	
                gts.mc.GT_SetHSIOOpt(0, 0, 1);               //打开激光
                //gts.mc.GT_LaserPowerMode((short)Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name].Wave_channel_Card_num, (short)Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name].laserPowerMode, (short)Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name].High_Voltage , 0, (short)Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name].Wave_channel_num, 0);     //设置为模拟量模式
                //                                                                                                                                                                                                                                                                                                                                                                                   gts.mc.GT_LaserPrfCmd((short)Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name].Wave_channel_Card_num, 0, (short)Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name].Wave_channel_num);       //设置输出电压为0V	
                //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                gts.mc.GT_SetHSIOOpt((short)Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name].Wave_channel_Card_num, 0, (short)Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[Name].Wave_channel_num);               //关闭激光

            });
            foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
            {
                if (item.Value.Wave_hardwareName.Contains(Name))
                {
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Laser_Run_Finish = true;
                }
            }

        }
        /// <summary>
        /// 涂胶时间控制
        /// </summary>
        /// <param name="Name"></param>
        public static async void GlueControl_async_Fun(string Name)
        {
            await Task.Run(() =>
            {
                double lastVoltages = 0;
                double lastTimes = 0;
                double StartTimes = 0;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(Name))
                    {
                        lastTimes = 0;
                        //double K = 0;
                        if (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Powers == 1)
                        {
                            PLCCommunicationFun.Write("UV点胶机", "MR1300", PLCDataType.Int, "30");
                        }

                        var pt1 = new HiperTimer();
                        pt1.Start();
                        while (true)
                        {
                            pt1.Stop();
                            if (pt1.EliminatedMilliSecond > item.Value.Times)
                            {
                                break;
                            }
                        }
                        if (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Powers == 0)
                        {
                            PLCCommunicationFun.Write("UV点胶机", "MR1300", PLCDataType.Int, "0");
                        }
                    }
                }
            });
            foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
            {
                if (item.Value.Wave_hardwareName.Contains(Name))
                {
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Laser_Run_Finish = true;
                }
            }

        }

        [DllImport("kernel32.dll")]
        public static extern int CreateWaitableTimer(int lpTimerAttributes, bool bManualReset, int lpTimerName);


        [DllImport("kernel32.dll")]
        public static extern bool SetWaitableTimer(int hTimer, ref long pDueTime,
          int lPeriod, int pfnCompletionRoutine, // TimerCompleteDelegate
                int lpArgToCompletionRoutine, bool fResume);


        [DllImport("user32.dll")]
        public static extern bool MsgWaitForMultipleObjects(uint nCount, ref int pHandles,
          bool bWaitAll, int dwMilliseconds, uint dwWakeMask);


        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(int hObject);


        public const int NULL = 0;
        public const int QS_TIMER = 0x10;

        public static void UsDelay(int us)
        {
            long duetime = -10 * us;
            int hWaitTimer = CreateWaitableTimer(NULL, true, NULL);
            SetWaitableTimer(hWaitTimer, ref duetime, 0, NULL, NULL, false);
            while (MsgWaitForMultipleObjects(1, ref hWaitTimer, false, Timeout.Infinite, QS_TIMER)) ;
            CloseHandle(hWaitTimer);
        }
        public static bool Delay(double _time)
        {
            if (_time > 200)
                return false;
            var pt = new HiperTimer();
            pt.Start();
            while (true)
            {
                Thread.Sleep(0);
                pt.Stop();
                if (pt.EliminatedMilliSecond > _time)
                    return true;
            }
        }
        //public static async void LaserControl_async_Fun(string Name)
        //{
        //    await Task.Run(() =>
        //    {
        //        double lastPower = 0;
        //        foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
        //        {
        //            if (item.Value.Wave_hardwareName.Contains(Name))
        //            {
        //                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Laser_Run_Finish = false;
        //                DateTime starttime = DateTime.Now;
        //                while (true)
        //                {
        //                    DateTime endtime = DateTime.Now;
        //                    TimeSpan spantime = endtime - starttime;
        //                    if (spantime.TotalMilliseconds > item.Value.Times)
        //                    {
        //                        break;
        //                    }
        //                    //控制卡号
        //                    //激光能量输出模式0：占空比输出模式 1；     1：频率输出模式；     2：模拟量输出模式；
        //                    //最大电压设置
        //                    //最小电压设置
        //                    //输出电压通道号  激光输出通道号是1
        //                    //0: 不使用激光开关延时功能，并将激光开关关联到位置比较输出         1：使用激光开关延时功能
        //                    gts.mc.GT_LaserPowerMode((short)item.Value.Wave_channel_Card_num, (short)item.Value.laserPowerMode, (short)item.Value.High_Voltage, 0, (short)item.Value.Wave_channel_num, 0);     //设置为模拟量模式  //控制卡号 //设置输出电压  // 激光输出通道号是1
        //                    gts.mc.GT_LaserPrfCmd((short)item.Value.Wave_channel_Card_num, item.Value.Voltages, (short)item.Value.Wave_channel_num);       //设置输出电压为5V // 控制卡号  //   输出电压1是启动    0是停止 // 激光输出通道号是1
        //                    gts.mc.GT_SetHSIOOpt((short)item.Value.Wave_channel_Card_num, 1, (short)item.Value.Wave_channel_num);               //打开激光
        //                }
        //            }
        //            lastPower = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Powers;
        //        }
        //        gts.mc.GT_LaserPowerMode(0, 2, 10, 0, 1, 0);     //设置为模拟量模式
        //        gts.mc.GT_LaserPrfCmd(0, 0, 1);       //设置输出电压为0V	
        //        gts.mc.GT_SetHSIOOpt(0, 0, 1);               //打开激光

        //    });
        //    foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
        //    {
        //        if (item.Value.Wave_hardwareName.Contains(Name))
        //        {
        //            Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[item.Value.Wave_hardwareName].Laser_Run_Finish = true;
        //        }
        //    }
        //}
        public void LaserControl_Fun(string Name)
        {
            foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
            {
                if (item.Value.Wave_hardwareName.Contains(Name))
                {

                    //item.Value.Time
                    DateTime starttime = DateTime.Now;
                    while (true)
                    {
                        DateTime endtime = DateTime.Now;
                        TimeSpan spantime = endtime - starttime;
                        if (spantime.TotalMilliseconds > item.Value.Times)
                        {
                            break;
                        }
                        //控制卡号
                        //激光能量输出模式0：占空比输出模式 1；     1：频率输出模式；     2：模拟量输出模式；
                        //最大电压设置
                        //最小电压设置
                        //输出电压通道号  激光输出通道号是1
                        //0: 不使用激光开关延时功能，并将激光开关关联到位置比较输出         1：使用激光开关延时功能
                        gts.mc.GT_LaserPowerMode((short)item.Value.Wave_channel_Card_num, (short)item.Value.laserPowerMode, (short)item.Value.High_Voltage, 0, (short)item.Value.Wave_channel_num, 0);     //设置为模拟量模式
                                                                                                                                                                                                           //     //控制卡号
                                                                                                                                                                                                           //    //设置输出电压  
                                                                                                                                                                                                           // 激光输出通道号是1
                        gts.mc.GT_LaserPrfCmd((short)item.Value.Wave_channel_Card_num, item.Value.Voltages, (short)item.Value.Wave_channel_num);       //设置输出电压为5V	
                                                                                                                                                       // 控制卡号
                                                                                                                                                       //   输出电压1是启动    0是停止
                                                                                                                                                       // 激光输出通道号是1
                        gts.mc.GT_SetHSIOOpt((short)item.Value.Wave_channel_Card_num, 1, (short)item.Value.Wave_channel_num);               //打开激光
                    }
                }
            }
            gts.mc.GT_LaserPowerMode(0, 2, 10, 0, 1, 0);     //设置为模拟量模式
            gts.mc.GT_LaserPrfCmd(0, 0, 1);       //设置输出电压为5V	
            gts.mc.GT_SetHSIOOpt(0, 0, 1);               //打开激光

        }
        public int GetCircleParameters(string Position, out string Radius)
        {
            //Radius:(X:pos,Y:pos;X:pos,Y:pos;X:pos,Y:pos)
            int res = 0;
            Radius = "";
            //先清除上一次储存的数值
            List<double> FirstPoint = new List<double>();
            List<double> SecondPoint = new List<double>();
            List<double> ThridPoint = new List<double>();
            //先清除上一次储存的数值
            string[] PositionDate = Position.Split(';');
            string[] FirstPointXY = PositionDate[0].Split(',');
            string[] SecondPointXY = PositionDate[1].Split(',');
            string[] ThirdPointXY = PositionDate[2].Split(',');
            //把文本框的数值加入到数组中
            try
            {
                //第一点的X Y坐标值
                FirstPoint.Add(double.Parse(FirstPointXY[0].Split(':')[1]));
                FirstPoint.Add(double.Parse(FirstPointXY[1].Split(':')[1]));
                //第二点的X Y坐标值
                SecondPoint.Add(double.Parse(SecondPointXY[0].Split(':')[1]));
                SecondPoint.Add(double.Parse(SecondPointXY[1].Split(':')[1]));
                //第三点的X Y坐标值
                ThridPoint.Add(double.Parse(ThirdPointXY[0].Split(':')[1]));
                ThridPoint.Add(double.Parse(ThirdPointXY[1].Split(':')[1]));
            }
            catch (Exception ex)
            {

            }
            //算法内容
            double a = FirstPoint[0] - SecondPoint[0];// X1-X2
            double b = FirstPoint[1] - SecondPoint[1];//Y1-Y2
            double c = FirstPoint[0] - ThridPoint[0];//X1-X3
            double d = FirstPoint[1] - ThridPoint[1];//Y1-Y3
            double aa = Math.Pow(FirstPoint[0], 2) - Math.Pow(SecondPoint[0], 2);//X1^2-X2^2
            double bb = Math.Pow(SecondPoint[1], 2) - Math.Pow(FirstPoint[1], 2);//Y2^2-Y1^2
            double cc = Math.Pow(FirstPoint[0], 2) - Math.Pow(ThridPoint[0], 2);//X1^2-X3^2
            double dd = Math.Pow(ThridPoint[1], 2) - Math.Pow(FirstPoint[1], 2);//Y3^2-Y1^2
            double E = (aa - bb) / 2;
            double F = (cc - dd) / 2;
            double resultY = (a * F - c * E) / (a * d - b * c);
            double resultX = (F * b - E * d) / (b * c - a * d);
            double resultR = Math.Sqrt((Math.Pow((FirstPoint[0] - resultX), 2)) + (Math.Pow((FirstPoint[1] - resultY), 2)));

            //输出圆心的坐标和半径值
            //lb_Point.Text = "X坐标为：" + resultX.ToString() + ";  Y坐标为：" + resultY.ToString();
            //lb_Radius.Text = resultR.ToString();
            //返回格式：（圆心X:Pos,圆心Y:Pos;R:r)
            Radius = FirstPointXY[0].Split(':')[0] + ":" + Math.Round(resultX, 3).ToString() + ","
                + FirstPointXY[1].Split(':')[0] + ":" + Math.Round(resultY, 3).ToString() + ";"
                + "R:" + Math.Round(resultR, 3).ToString();
            return res;
        }
        /// <summary>
        /// 插入直线到缓存区
        /// </summary>
        /// <param name="Axis_Name">LnXY 直线插补参数</param>
        /// <returns></returns>
        public int InsertLine(LnXY Axis_Name)
        {
            short sRtn = 0;
            lock (lockObj)
            {
                int iTargetPosX = 0;
                int iTargetPosY = 0;
                int iTargetPosZ = 0;
                int iTargetPosU = 0;
                iTargetPosX = (int)(Axis_Name.EndX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Name._轴1Name].PlusFeed);
                iTargetPosY = (int)(Axis_Name.EndY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Name._轴2Name].PlusFeed);
                double dAcc = 1000;
                dAcc = (dAcc * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Name._轴1Name].PlusFeed) / (1000 * 1000);
                int BulidCordnum = Axis_Name.Cor;
                //switch (BulidCordnum)
                //{
                //    case 2:
                sRtn = gts.mc.GT_LnXY(
                    (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Name._轴1Name].m_CardNo,   // 该插补段的坐标系是坐标系卡号
                    (short)BulidCordnum,  // 该插补段的坐标系是坐标系1
                    iTargetPosX, iTargetPosY, // 该插补段的终点坐标(X, Y)
                    Axis_Name.StartSpeed,         // 该插补段的目标速度：dSpeed pulse/ms
                    dAcc,                    // 插补段的加速度：dAcc pulse/ms^2
                    Axis_Name.EndSpeed,      // 终点速度
                    0);                      // 向坐标系1的FIFO0缓存区传递该直线插补数据
                                             //              break;
                                             //          case 3:
                                             //              sRtn = gts.mc.GT_LnXYZ(
                                             //(short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Name._轴1Name].m_CardNo,   // 该插补段的坐标系是坐标系卡号
                                             //(short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Name._轴1Name].BuildCorNum,  // 该插补段的坐标系是坐标系1
                                             //iTargetPosX, iTargetPosY, iTargetPosZ, // 该插补段的终点坐标(X, Y,Z)
                                             //  Axis_Name.StartSpeed,         // 该插补段的目标速度：dSpeed pulse/ms
                                             //dAcc,                    // 插补段的加速度：dAcc pulse/ms^2
                                             //  Axis_Name.EndSpeed,      // 终点速度
                                             //0);                      // 向坐标系1的FIFO0缓存区传递该直线插补数据
                                             //              break;
                                             //          case 4:
                                             //              sRtn = gts.mc.GT_LnXYZA(
                                             //    (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Name._轴1Name].m_CardNo,   // 该插补段的坐标系是坐标系卡号
                                             //    (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Axis_Name._轴1Name].BuildCorNum,  // 该插补段的坐标系是坐标系1
                                             //    iTargetPosX, iTargetPosY, iTargetPosZ, iTargetPosU,  // 该插补段的终点坐标(X, Y,Z,U)
                                             //     Axis_Name.StartSpeed,         // 该插补段的目标速度：dSpeed pulse/ms
                                             //    dAcc,                    // 插补段的加速度：dAcc pulse/ms^2
                                             //      Axis_Name.EndSpeed,      // 终点速度
                                             //    0);                      // 向坐标系1的FIFO0缓存区传递该直线插补数据
                                             //              break;
                                             //      }
            }
            if (sRtn == 0)
            {
                return 0;
            }
            else
            {
                return -15;
            }
        }

        public int InsertLineLnXYZ(LnXYZ _LnXYZ)
        {
            throw new NotImplementedException();
        }

        public int InsertLineLnXYZA(LnXYZA _LnXYZA)
        {
            throw new NotImplementedException();
        }
        public int BuildCor(BufferArea _BufferArea)
        {
            short sRtn;
            gts.mc.TCrdPrm crdPrm;
            Dictionary<string, string> Axis_Name = new Dictionary<string, string>();
            lock (lockObj)
            {
                //不在一个坐标系处理
                //清除缓存区
                sRtn = gts.mc.GT_GetCrdPrm((short)_BufferArea.CardNum, (short)_BufferArea.Cor, out crdPrm);
                crdPrm.profile1 = 0;
                crdPrm.profile2 = 0;
                crdPrm.profile3 = 0;
                crdPrm.profile4 = 0;
                crdPrm.profile5 = 0;
                crdPrm.profile6 = 0;
                crdPrm.profile7 = 0;
                crdPrm.profile8 = 0;
                crdPrm.dimension = (short)2;

                crdPrm.profile1 = 1;
                crdPrm.profile2 = 2;
                crdPrm.profile3 = 0;
                crdPrm.profile5 = 0;
                crdPrm.profile6 = 0;
                crdPrm.profile7 = 0;
                crdPrm.profile8 = 0;
                crdPrm.synVelMax = 500;                      // 坐标系的最大合成速度是: 500 pulse/ms
                crdPrm.synAccMax = 3;                        // 坐标系的最大合成加速度是: 2 pulse/ms^2
                crdPrm.evenTime = 0;                         // 坐标系的最小匀速时间为0
                crdPrm.setOriginFlag = 1;                    // 需要设置加工坐标系原点位置
                crdPrm.originPos1 = 0;                       // 加工坐标系原点位置在(0,0,0)，即与机床坐标系原点重合
                crdPrm.originPos2 = 0;
                crdPrm.originPos3 = 0;
                crdPrm.originPos4 = 0;
                crdPrm.originPos5 = 0;
                crdPrm.originPos6 = 0;
                crdPrm.originPos7 = 0;
                crdPrm.originPos8 = 0;
                // 建立坐标系，设置坐标系参数
                sRtn = gts.mc.GT_SetCrdPrm((short)_BufferArea.CardNum, (short)_BufferArea.Cor, ref crdPrm);
                if (sRtn == 0)
                {
                    return 0;
                }
                else
                {
                    return -16;
                }
            }
        }
        //public int BuildCor(BufferArea _BufferArea)
        //{
        //    short sRtn;
        //    gts.mc.TCrdPrm crdPrm;
        //    Dictionary<string, string> Axis_Name = new Dictionary<string, string>();
        //    lock (lockObj)
        //    {
        //        //不在一个坐标系处理
        //        //清除缓存区
        //        sRtn = gts.mc.GT_GetCrdPrm((short)_BufferArea.CardNum, (short)_BufferArea.Cor, out crdPrm);
        //        crdPrm.profile1 = 0;
        //        crdPrm.profile2 = 0;
        //        crdPrm.profile3 = 0;
        //        crdPrm.profile4 = 0;
        //        crdPrm.profile5 = 0;
        //        crdPrm.profile6 = 0;
        //        crdPrm.profile7 = 0;
        //        crdPrm.profile8 = 0;
        //        crdPrm.dimension = (short)_BufferArea.Cor;
        //        short count = 1;
        //        Axis_Name = new Dictionary<string, string>();
        //        if (_BufferArea._轴1Name != null)
        //        {
        //            Axis_Name.Add(_BufferArea._轴1Name, _BufferArea._轴1Name);
        //        }
        //        if (_BufferArea._轴2Name != null)
        //        {
        //            Axis_Name.Add(_BufferArea._轴2Name, _BufferArea._轴2Name);
        //        }
        //        if (_BufferArea._轴3Name !=null)
        //        {
        //            Axis_Name.Add(_BufferArea._轴3Name, _BufferArea._轴3Name);
        //        }
        //        if (_BufferArea._轴4Name != null)
        //        {
        //            Axis_Name.Add(_BufferArea._轴4Name, _BufferArea._轴4Name);
        //        }
        //        foreach (var item in Axis_Name)
        //        {
        //            if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 1)
        //            {
        //                crdPrm.profile1 = count;
        //            }
        //            else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 2)
        //            {
        //                crdPrm.profile2 = count;

        //            }
        //            else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 3)
        //            {
        //                crdPrm.profile3 = count;

        //            }
        //            else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 4)
        //            {
        //                crdPrm.profile4 = count;
        //            }
        //            else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 5)
        //            {
        //                crdPrm.profile5 = count;
        //            }
        //            else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 6)
        //            {
        //                crdPrm.profile6 = count;

        //            }
        //            else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 7)
        //            {
        //                crdPrm.profile7 = count;
        //            }
        //            else if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Key].m_AxisNo == 8)
        //            {
        //                crdPrm.profile8 = count;
        //            }
        //            count++;
        //        }
        //        crdPrm.synVelMax = 800;                      // 坐标系的最大合成速度是: 500 pulse/ms
        //        crdPrm.synAccMax = 3;                        // 坐标系的最大合成加速度是: 2 pulse/ms^2
        //        crdPrm.evenTime = 0;                         // 坐标系的最小匀速时间为0
        //        crdPrm.setOriginFlag = 1;                    // 需要设置加工坐标系原点位置
        //        crdPrm.originPos1 = 0;                       // 加工坐标系原点位置在(0,0,0)，即与机床坐标系原点重合
        //        crdPrm.originPos2 = 0;
        //        crdPrm.originPos3 = 0;
        //        crdPrm.originPos4 = 0;
        //        crdPrm.originPos5 = 0;
        //        crdPrm.originPos6 = 0;
        //        crdPrm.originPos7 = 0;
        //        crdPrm.originPos8 = 0;
        //        // 建立坐标系，设置坐标系参数
        //        sRtn = gts.mc.GT_SetCrdPrm((short)_BufferArea.CardNum, (short)_BufferArea.Cor, ref crdPrm);
        //        if (sRtn == 0)
        //        {
        //            return 0;
        //        }
        //        else
        //        {
        //            return -16;
        //        }
        //    }
        //}

        public int ClearBuff(BufferArea _BufferArea)
        {
            short sRtn = gts.mc.GT_CrdClear((short)_BufferArea.CardNum, (short)_BufferArea.Cor, 0);
            if (sRtn == 0)
            {
                return 0;
            }
            else
            {
                return -16;
            }
        }
        public int BuffAddStart(BufferArea _BufferArea)
        {
            short sRtn = gts.mc.GT_CrdClear((short)_BufferArea.CardNum, (short)_BufferArea.Cor, 0);
            if (sRtn == 0)
            {
                return 0;
            }
            else
            {
                return -16;
            }
        }
        /// <summary>
        /// 插补开始运行及检测停止
        /// </summary>
        /// <param name="Axis_One_Name"></param>
        /// <param name="Axis_Two_Name"></param>
        /// <returns></returns>
        public int BuffRun(BufferArea _BufferArea)
        {
            int Res = StartCure((short)_BufferArea.CardNum, (short)_BufferArea.Cor);
            int stime = 300000;
            if (Res != 0)
            {
                return -1;
            }
            DateTime starttime = DateTime.Now;
            while (true)
            {
                Thread.Sleep(50);
                //Res = CureMoveDone(out Res);
                short sRtn;
                short run;
                int segment;
                DateTime endtime = DateTime.Now;
                TimeSpan spantime = endtime - starttime;
                sRtn = gts.mc.GT_CrdStatus((short)_BufferArea.CardNum, (short)_BufferArea.Cor, out run, out segment, 0);
                if (run == 1)
                {
                    //插补中
                    //return 1;
                }
                else
                {
                    _BufferArea.FlowChar_StepControlTIME = spantime.TotalMilliseconds;
                    Res = 0;
                    break;
                }

                if (spantime.TotalMilliseconds > stime)
                {
                    Res = -6;
                    break;
                }
                if (Program.bEStop)
                {
                    Res = -33;
                    break;
                }
            }
            return Res;
        }

        public int AddOtherBuffFun(AddOtherBuff _AddOtherBuff)
        {
            short rtOut = 0;
            if (_AddOtherBuff.ChooseTepy == "IO")
            {
                int out_value = _AddOtherBuff.IONum;//点位
                bool Sta = _AddOtherBuff.IONumSta;
                short ret;
                var result = new byte[32];
                int uiOutputCard = 0;
                //输出检测
                short sRtn = gts.mc.GT_GetDo((short)_AddOtherBuff.CardNum, gts.mc.MC_GPO, out uiOutputCard);
                var _OutBase2 = Convert.ToString(uiOutputCard, 2);//_Base2就是转换后的二进制了！！
                var binaryBits = _OutBase2.ToCharArray().Select(i => (byte)(i - 48)).ToArray();
                //Array.Reverse(binaryBits); //此方法可以将数组中的值颠倒
                int _out_value = IntegerAndBinaryConverter.FromBinaryToInt(binaryBits);
                Array.Copy(binaryBits, 0, result, 32 - binaryBits.Length, binaryBits.Length);
                int _Bit = result.Length - out_value;
                result[_Bit] = Convert.ToByte(Sta);
                _out_value = IntegerAndBinaryConverter.FromBinaryToInt(result);
                string strA = _out_value.ToString("x8");
                ushort strB = ushort.Parse(strA);
                rtOut = gts.mc.GT_BufIO(
                     (short)_AddOtherBuff.CardNum,//卡号
                     (short)_AddOtherBuff.Cor,//坐标系号
                     (ushort)gts.mc.MC_GPO,
                     0xFFFF,
                     strB,
                     0);
                //     ret = DASK.DO_WritePort((ushort)m_dev, 1, (uint)_out_value);




                //int a = 100;
                //string strA = a.ToString("x8");
                //rtOut = gts.mc.GT_BufIO(
                //     (short)_AddOtherBuff.CardNum,//卡号
                //     (short)_AddOtherBuff.Cor,//坐标系号
                //     (ushort)gts.mc.MC_GPO,
                //     0xF000,
                //     0x8,
                //     0);
            }
            else
            {
                rtOut = gts.mc.GT_BufDelay(
                   (short)_AddOtherBuff.CardNum,//卡号
                   (short)_AddOtherBuff.Cor,//坐标系号
                   (ushort)_AddOtherBuff.Delay,//延时 
                   0    // 向坐标系1的FIFO0缓存区传递该延时
                   );
            }
            return 0;
        }

        public bool StartManualPulserOperation(int axis_ID, int MultiplyingPower)
        {
            bool blFlag = false;        //内部状态
            try
            {
                short re = gts.mc.GT_EndHandwheel(0, ((short)(axis_ID + 1)));
                short ret = -1;
                ret = gts.mc.GT_HandwheelInit(0);
                ret = gts.mc.GT_SetHandwheelStopDec(0, (short)(axis_ID + 1), 0.5, 0.5);
                ret = gts.mc.GT_StartHandwheel(0, (short)(axis_ID + 1), 11, 1, (short)MultiplyingPower, 1, 0.5, 0.5, 100, 200);

                if (ret != 0)
                {
                    blFlag = false;
                    ret = gts.mc.GT_EndHandwheel(0, (short)(axis_ID + 1));
                    if (ret != 0)
                    {

                    }
                }
                else
                {
                    blFlag = true;
                }

            }
            catch (Exception)
            {
                blFlag = false;
                gts.mc.GT_EndHandwheel(0, (short)(axis_ID + 1));
            }
            return blFlag;
        }

        public bool StopManualPulserOperation(int axis_ID)
        {
            short ret = -1;
            bool blFlag = false;

            ret = gts.mc.GT_EndHandwheel(0, (short)(axis_ID + 1));
            if (ret != 0)
            {
                blFlag = false;
            }
            else
            {
                blFlag = true;
            }
            return blFlag;
        }

        public int InsertArc(ArcXYC _ArcXYC)
        {
            short sRtn;
            lock (lockObj)
            {
                gts.mc.TCrdPrm crdPrm;
                sRtn = gts.mc.GT_GetCrdPrm((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].m_CardNo, (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].BuildCorNum, out crdPrm);
                int iTargetPosX = (int)(_ArcXYC.StartX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].PlusFeed);
                int iTargetPosY = (int)(_ArcXYC.StartY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴2Name].PlusFeed);
                int CenterX = (int)(_ArcXYC.CenterX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].PlusFeed);
                int CenterY = (int)(_ArcXYC.CenterY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴2Name].PlusFeed);
                int iR = (int)(CenterX - iTargetPosX);
                int iR1 = (int)(CenterY - iTargetPosY);
                int EndX = (int)(_ArcXYC.EndX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].PlusFeed);
                int EndY = (int)(_ArcXYC.EndY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴2Name].PlusFeed);
                sRtn = gts.mc.GT_ArcXYC((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].m_CardNo,
                        (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].BuildCorNum,
                      EndX, EndY,
                        iR, iR1,
                        0,
                        _ArcXYC.StartSpeed,
                        3000,
                        _ArcXYC.EndSpeed,
                        0);
            }
            if (sRtn != 0)
            {

                return -15;
            }
            else
            {
                return 0;
            }

        }

        public bool CirRun(Cir Cir)
        {
            //   GetCircleParameters(Cir);
            short sRtn;
            int _count = 0;
            int Dir = 0;
            double CenterOfferX = 0;
            double CenterOfferY = 0;
            if (Cir.cmbSelectDir == "顺时针")
            {
                Dir = 0;
            }
            else
            {
                Dir = 1;
            }
            if (Cir.圆圆弧选择 == "圆")
            {
                lock (lockObj)
                {
                    if (Cir.txtDicDeg >= 360)
                    {
                        double StartX = Cir.StartX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴1Name].PlusFeed;
                        double StartY = Cir.StartY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].PlusFeed;

                        double RX = Cir.RX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴1Name].PlusFeed;
                        double RY = Cir.RY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].PlusFeed;
                        CenterOfferX = (RX - StartX);
                        CenterOfferY = (RY - StartY);

                        _count = Cir.txtDicDeg / 360;
                        for (int i = 0; i < _count; i++)
                        {
                            sRtn = gts.mc.GT_ArcXYC((short)Cir.CardNum,
                           (short)Cir.Cor,
                          (int)StartX, (int)StartY,
                           CenterOfferX, CenterOfferY,
                         (short)Dir,
                         (short)Cir.StartSpeed,
                         (short)Cir.Acc,
                         (short)Cir.StartSpeed,
                           0);
                        }
                        int angle = Cir.txtDicDeg % 360;
                        if (angle != 0)
                        {
                            _Point start = new _Point();
                            _Point center = new _Point();
                            start.x = Cir.StartX;
                            start.y = Cir.StartY;
                            center.x = (Cir.RX);
                            center.y = (Cir.RY);
                            //计算圆弧终点位置
                            _Point resul = GetRotatePoint(start, center, angle, (short)Dir);


                            //double tmpX = start.x + Cir.R * Math.Cos(angle * 3.14 / 180);
                            //double tmpY = start.y + Cir.R * Math.Sin(angle * 3.14 / 180);

                            double tmpX = resul.x * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴1Name].PlusFeed;
                            double tmpY = resul.y * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].PlusFeed;
                            int tmpdX = (int)tmpX;
                            int tmpdY = (int)tmpY;

                            //tmpX = Cir.StartX + Cir.R;
                            //tmpY = Cir.StartY + Cir.R;
                            //tmpX = (int)(tmpX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴1Name].PlusFeed);
                            //tmpY = (int)(tmpY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].PlusFeed);
                            int r = (int)(Cir.R * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴1Name].PlusFeed);
                            //CenterOfferX = (Cir.RX - Cir.StartX) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴1Name].PlusFeed;
                            //CenterOfferY = (Cir.RY- Cir.StartY) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].PlusFeed;
                            sRtn = gts.mc.GT_ArcXYC((short)Cir.CardNum,
                         (short)Cir.Cor,
                       (int)tmpX, (int)tmpY,
                          CenterOfferX, CenterOfferY,
                       (short)Dir,
                       (short)Cir.StartSpeed,
                       (short)Cir.Acc,
                       (short)Cir.EndSpeed,
                         0);

                            //     sRtn = gts.mc.GT_ArcXYR((short)Cir.CardNum,
                            //  (short)Cir.Cor,
                            //(int)tmpX, (int)tmpY,
                            //  r,
                            //(short)Dir,
                            //(short)Cir.StartSpeed,
                            //(short)Cir.Acc,
                            //(short)Cir.EndSpeed,
                            //  0);
                        }
                    }
                }
            }
            else if (Cir.圆圆弧选择 == "圆弧")
            {
                double StartX = Cir.StartX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴1Name].PlusFeed;
                double StartY = Cir.StartY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].PlusFeed;

                double RX = Cir.RX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴1Name].PlusFeed;
                double RY = Cir.RY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].PlusFeed;
                double EndX = Cir.EndX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴1Name].PlusFeed;
                double EndY = Cir.EndY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].PlusFeed;

                CenterOfferX = RX - StartX;
                CenterOfferY = RY - StartY;


                sRtn = gts.mc.GT_ArcXYC((short)Cir.CardNum,
                      (short)Cir.Cor,
                   (int)EndX, (int)EndY,
                     CenterOfferX, CenterOfferY,
                    (short)Dir,
                    (short)Cir.StartSpeed,
                    (short)Cir.Acc,
                    (short)Cir.EndSpeed,
                      0);
            }
            else if (Cir.圆圆弧选择 == "圆心半径")
            {
                _Point start = new _Point();
                _Point startRun = new _Point();
                _Point center = new _Point();

                start.x = Cir.RX + Cir.R;
                start.y = Cir.RY;
                startRun.x = start.x;
                startRun.y = start.y * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].PlusFeed;
                AxisPMoveAbsoluteToStop(Cir._轴1Name, start.x, Cir.Acc, Cir.Dec, Cir.StartSpeed);
                AxisPMoveAbsoluteToStop(Cir._轴2Name, start.y, Cir.Acc, Cir.Dec, Cir.StartSpeed);


                while (true)
                {
                    if (DetectingAxis(Cir._轴1Name) == 1 && DetectingAxis(Cir._轴2Name) == 1)
                    {
                        break;
                    }
                }
                //不在一个坐标系处理
                //清除缓存区
                gts.mc.GT_CrdClear((short)Cir.CardNum, (short)Cir.Cor, 0);
                gts.mc.TCrdPrm crdPrm;
                sRtn = gts.mc.GT_GetCrdPrm((short)Cir.CardNum, (short)Cir.Cor, out crdPrm);
                crdPrm.profile1 = 0;
                crdPrm.profile2 = 0;
                crdPrm.profile3 = 0;
                crdPrm.profile4 = 0;
                crdPrm.profile5 = 0;
                crdPrm.profile6 = 0;
                crdPrm.profile7 = 0;
                crdPrm.profile8 = 0;
                crdPrm.dimension = (short)2;
                crdPrm.profile1 = 1;
                crdPrm.profile2 = 2;
                crdPrm.profile3 = 0;
                crdPrm.profile5 = 0;
                crdPrm.profile6 = 0;
                crdPrm.profile7 = 0;
                crdPrm.profile8 = 0;
                crdPrm.synVelMax = 500;                      // 坐标系的最大合成速度是: 500 pulse/ms
                crdPrm.synAccMax = 3;                        // 坐标系的最大合成加速度是: 2 pulse/ms^2
                crdPrm.evenTime = 0;                         // 坐标系的最小匀速时间为0
                crdPrm.setOriginFlag = 1;                    // 需要设置加工坐标系原点位置
                crdPrm.originPos1 = 0;                       // 加工坐标系原点位置在(0,0,0)，即与机床坐标系原点重合
                crdPrm.originPos2 = 0;
                crdPrm.originPos3 = 0;
                crdPrm.originPos4 = 0;
                crdPrm.originPos5 = 0;
                crdPrm.originPos6 = 0;
                crdPrm.originPos7 = 0;
                crdPrm.originPos8 = 0;
                // 建立坐标系，设置坐标系参数
                sRtn = gts.mc.GT_SetCrdPrm((short)Cir.CardNum, (short)Cir.Cor, ref crdPrm);

                sRtn = gts.mc.GT_BufIO(
                   (short)Cir.CardNum,//卡号
                   (short)Cir.Cor,//坐标系号
                   (ushort)gts.mc.MC_GPO,
                   0xF000,
                   0x8,
                   0);
                if (Cir.txtDicDeg >= 360)
                {
                    double StartX = start.x * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴1Name].PlusFeed;
                    start.y = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].AisxCurrentPosition;
                    double StartY = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].AisxCurrentPosition * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].PlusFeed;
                    //double StartY = start.y * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].PlusFeed;
                    double RX = Cir.RX * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴1Name].PlusFeed;
                    double RY = Cir.RY * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].PlusFeed;
                    CenterOfferX = (RX - StartX);
                    CenterOfferY = (RY - StartY);

                    _count = Cir.txtDicDeg / 360;
                    for (int i = 0; i < _count; i++)
                    {
                        sRtn = gts.mc.GT_ArcXYC((short)Cir.CardNum,
                                                (short)Cir.Cor,
                                                (int)StartX, (int)StartY,
                                                CenterOfferX, CenterOfferY,
                                                (short)Dir,
                                                (short)Cir.StartSpeed,
                                                (short)Cir.Acc,
                                                (short)Cir.StartSpeed,
                                                 0);
                    }

                    int angle = Cir.txtDicDeg % 360;
                    if (angle != 0)
                    {
                        _Point start1 = new _Point();
                        _Point center1 = new _Point();
                        start1.x = Cir.StartX;
                        start1.y = Cir.StartY;
                        center1.x = (Cir.RX);
                        center1.y = (Cir.RY);
                        //计算圆弧终点位置
                        _Point resul = GetRotatePoint(start, center1, angle, (short)Dir);
                        double tmpX1 = resul.x * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴1Name].PlusFeed;
                        double tmpY1 = resul.y * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴2Name].PlusFeed;
                        int tmpdX1 = (int)tmpX1;
                        int tmpdY1 = (int)tmpY1;
                        int r1 = (int)(Cir.R * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Cir._轴1Name].PlusFeed);
                        sRtn = gts.mc.GT_ArcXYC((short)Cir.CardNum,
                                                (short)Cir.Cor,
                                                (int)tmpX1, (int)tmpY1,
                                                 CenterOfferX, CenterOfferY,
                                                 (short)Dir,
                                               (short)Cir.StartSpeed,
                                                (short)Cir.Acc,
                                               (short)Cir.EndSpeed,
                                                0);

                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 根据圆弧的起点位置、圆心位置和角度计算终点位置
        /// </summary>
        /// <param name="_startPoint">起点位置</param>
        /// <param name="_centerPoint">圆心位置</param>
        /// <param name="angle">角度</param>
        /// <param name="dir">方向</param>
        /// <returns></returns>
        private _Point GetRotatePoint(_Point _startPoint, _Point _centerPoint,
            double angle, int dir)
        {
            _Point resultPoint = new _Point();
            //double tmpX = _centerPoint.x + 2 * Math.Cos(angle * 3.14 / 180);
            //double tmpY = _centerPoint.y + 2 * Math.Sin(angle * 3.14 / 180);
            double radian = (Math.PI / 180) * angle;
            if (dir == 0)
            {
                radian = -radian;
                resultPoint.x = (_startPoint.x - _centerPoint.x) * Math.Cos(radian) -
                                (_startPoint.y - _centerPoint.y) * Math.Sin(radian) + _centerPoint.x;
                resultPoint.y = (_startPoint.x - _centerPoint.x) * Math.Sin(radian) +
                                (_startPoint.y - _centerPoint.y) * Math.Cos(radian) + _centerPoint.y;

            }
            else
            {
                resultPoint.x = (_startPoint.x - _centerPoint.x) * Math.Cos(radian) -
                                (_startPoint.y - _centerPoint.y) * Math.Sin(radian) + _centerPoint.x;
                resultPoint.y = (_startPoint.x - _centerPoint.x) * Math.Sin(radian) +
                                (_startPoint.y - _centerPoint.y) * Math.Cos(radian) + _centerPoint.y;
            }

            return resultPoint;
        }
        public int GetCircleParameters(Cir Cir)
        {
            //Radius:(X:pos,Y:pos;X:pos,Y:pos;X:pos,Y:pos)
            int res = 0;
            //string  Radius = "";
            //先清除上一次储存的数值
            List<double> FirstPoint = new List<double>();
            List<double> SecondPoint = new List<double>();
            List<double> ThridPoint = new List<double>();
            //先清除上一次储存的数值
            //string[] PositionDate = Position.Split(';');
            //string[] FirstPointXY = PositionDate[0].Split(',');
            //string[] SecondPointXY = PositionDate[1].Split(',');
            //string[] ThirdPointXY = PositionDate[2].Split(',');
            //把文本框的数值加入到数组中
            try
            {
                //第一点的X Y坐标值
                FirstPoint.Add(Cir.StartX);
                FirstPoint.Add(Cir.StartY);
                //第二点的X Y坐标值
                SecondPoint.Add(Cir.CenterX);
                SecondPoint.Add(Cir.CenterY);
                //第三点的X Y坐标值
                ThridPoint.Add(Cir.EndX);
                ThridPoint.Add(Cir.EndY);
            }
            catch (Exception ex)
            {

            }
            //算法内容
            double a = FirstPoint[0] - SecondPoint[0];// X1-X2
            double b = FirstPoint[1] - SecondPoint[1];//Y1-Y2
            double c = FirstPoint[0] - ThridPoint[0];//X1-X3
            double d = FirstPoint[1] - ThridPoint[1];//Y1-Y3
            double aa = Math.Pow(FirstPoint[0], 2) - Math.Pow(SecondPoint[0], 2);//X1^2-X2^2
            double bb = Math.Pow(SecondPoint[1], 2) - Math.Pow(FirstPoint[1], 2);//Y2^2-Y1^2
            double cc = Math.Pow(FirstPoint[0], 2) - Math.Pow(ThridPoint[0], 2);//X1^2-X3^2
            double dd = Math.Pow(ThridPoint[1], 2) - Math.Pow(FirstPoint[1], 2);//Y3^2-Y1^2
            double E = (aa - bb) / 2;
            double F = (cc - dd) / 2;
            double resultY = (a * F - c * E) / (a * d - b * c);
            double resultX = (F * b - E * d) / (b * c - a * d);
            double resultR = Math.Sqrt((Math.Pow((FirstPoint[0] - resultX), 2)) + (Math.Pow((FirstPoint[1] - resultY), 2)));

            //输出圆心的坐标和半径值
            //lb_Point.Text = "X坐标为：" + resultX.ToString() + ";  Y坐标为：" + resultY.ToString();
            //lb_Radius.Text = resultR.ToString();
            //返回格式：（圆心X:Pos,圆心Y:Pos;R:r)
            //Radius = FirstPointXY[0].Split(':')[0] + ":" + Math.Round(resultX, 3).ToString() + ","
            //    + FirstPointXY[1].Split(':')[0] + ":" + Math.Round(resultY, 3).ToString() + ";"
            //    + "R:" + Math.Round(resultR, 3).ToString();
            Cir.RX = Math.Round(resultX, 3);
            Cir.RY = Math.Round(resultY, 3);
            Cir.R = Math.Round(resultR, 3);
            Cir.CenterOfferX = Cir.RX - Cir.StartX;
            Cir.CenterOfferY = Cir.RY - Cir.StartY;
            return res;
        }

        public bool MoveRec(Dimetric Dimetric)
        {
            _Point start = new _Point();
            _Point start_R = new _Point();
            _Point second = new _Point();
            _Point second_R = new _Point();
            _Point third = new _Point();
            _Point third_R = new _Point();
            _Point forth = new _Point();
            _Point forth_R = new _Point();

            _Point end = new _Point();
            double r = Dimetric.R * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].PlusFeed;
            //第一个点
            start.x = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].AisxCurrentPosition;
            start.y = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴2Name].AisxCurrentPosition;
            start.x = (start.x - (Dimetric.RecLenght - Dimetric.R)) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].PlusFeed;
            start.y = start.y * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴2Name].PlusFeed;

            short sRtn = gts.mc.GT_LnXY(
                           (short)Dimetric.CardNum,   // 该插补段的坐标系是坐标系卡号
                           (short)Dimetric.Cor,  // 该插补段的坐标系是坐标系1
                          (int)start.x, (int)start.y, // 该插补段的终点坐标(X, Y)
                           Dimetric.StartSpeed,         // 该插补段的目标速度：dSpeed pulse/ms
                           Dimetric.Acc,                    // 插补段的加速度：dAcc pulse/ms^2
                           Dimetric.StartSpeed,      // 终点速度
                           0);                      // 向坐标系1的FIFO0缓存区传递该直线插补数据
            //第一个R角
            start_R.x = start.x - (Dimetric.R * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].PlusFeed);
            start_R.y = start.y + (Dimetric.R * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴2Name].PlusFeed);
            sRtn = gts.mc.GT_ArcXYR((short)Dimetric.CardNum,
             (short)Dimetric.Cor,
             (int)start_R.x, (int)start_R.y,
              r,
            (short)0,
            (short)Dimetric.StartSpeed,
            (short)Dimetric.Acc,
            (short)Dimetric.StartSpeed,
             0);

            //第二个点
            second.x = start_R.x;
            second.y = start_R.y + ((Dimetric.RecWidth - Dimetric.R) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].PlusFeed);
            sRtn = gts.mc.GT_LnXY(
                            (short)Dimetric.CardNum,   // 该插补段的坐标系是坐标系卡号
                            (short)Dimetric.Cor,  // 该插补段的坐标系是坐标系1
                           (int)second.x, (int)second.y, // 该插补段的终点坐标(X, Y)
                            Dimetric.StartSpeed,         // 该插补段的目标速度：dSpeed pulse/ms
                            Dimetric.Acc,                    // 插补段的加速度：dAcc pulse/ms^2
                            Dimetric.StartSpeed,      // 终点速度
                            0);                      // 向坐标系1的FIFO0缓存区传递该直线插补数据
            //第二个R角
            second_R.x = second.x + ((Dimetric.R) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].PlusFeed); ;
            second_R.y = second.y + ((Dimetric.R) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].PlusFeed);
            //EndY =
            sRtn = gts.mc.GT_ArcXYR((short)Dimetric.CardNum,
                                    (short)Dimetric.Cor,
                                     (int)second_R.x, (int)second_R.y,
                                        r,
                                     (short)0,
                                     (short)Dimetric.StartSpeed,
                                    (short)Dimetric.Acc,
                                     (short)Dimetric.StartSpeed,
                                  0);
            //第三个点
            third.x = second_R.x + (Dimetric.RecLenght - Dimetric.R) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].PlusFeed;
            third.y = second_R.y;
            sRtn = gts.mc.GT_LnXY(
                          (short)Dimetric.CardNum,   // 该插补段的坐标系是坐标系卡号
                          (short)Dimetric.Cor,  // 该插补段的坐标系是坐标系1
                         (int)third.x, (int)third.y, // 该插补段的终点坐标(X, Y)
                          Dimetric.StartSpeed,         // 该插补段的目标速度：dSpeed pulse/ms
                          Dimetric.Acc,                    // 插补段的加速度：dAcc pulse/ms^2
                          Dimetric.StartSpeed,      // 终点速度
                          0);                      // 向坐标系1的FIFO0缓存区传递该直线插补数据


            //第三个R角
            //第三个R角
            third_R.x = third.x + (Dimetric.R) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].PlusFeed;
            third_R.y = third.y - (Dimetric.R) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].PlusFeed;
            sRtn = gts.mc.GT_ArcXYR((short)Dimetric.CardNum,
                        (short)Dimetric.Cor,
                         (int)third_R.x, (int)third_R.y,
                            r,
                         (short)0,
                         (short)Dimetric.StartSpeed,
                        (short)Dimetric.Acc,
                         (short)Dimetric.StartSpeed,
                      0);
            //第四个点
            forth.x = third_R.x;
            forth.y = third_R.y - ((Dimetric.RecWidth - Dimetric.R) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].PlusFeed);
            sRtn = gts.mc.GT_LnXY(
              (short)Dimetric.CardNum,   // 该插补段的坐标系是坐标系卡号
              (short)Dimetric.Cor,  // 该插补段的坐标系是坐标系1
             (int)forth.x, (int)forth.y, // 该插补段的终点坐标(X, Y)
              Dimetric.StartSpeed,         // 该插补段的目标速度：dSpeed pulse/ms
              Dimetric.Acc,                    // 插补段的加速度：dAcc pulse/ms^2
              Dimetric.StartSpeed,      // 终点速度
              0);
            //第四个R角
            forth_R.x = forth.x - ((Dimetric.R) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].PlusFeed);
            forth_R.y = forth.y - ((Dimetric.R) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Dimetric._轴1Name].PlusFeed);
            sRtn = gts.mc.GT_ArcXYR((short)Dimetric.CardNum,
                      (short)Dimetric.Cor,
                       (int)forth_R.x, (int)forth_R.y,
                          r,
                       (short)0,
                       (short)Dimetric.StartSpeed,
                      (short)Dimetric.Acc,
                       (short)Dimetric.StartSpeed,
                    0);
            return true;
        }

        public double GETAxisP(string Aisx_Name)
        { //轴当前位置
            double dValue = 0.0;
            int lAxisStatus = 0;
            uint uIntClock;
            short m_CardNo = (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_CardNo;
            short m_AxisNo = (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].m_AxisNo;
            short PlusFeed = (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Aisx_Name].PlusFeed;
            short sRtn = gts.mc.GT_GetPrfPos(m_CardNo, (short)(m_AxisNo + 1), out dValue, 1, out uIntClock);
            double AisxCurrentPosition = Math.Round(dValue / PlusFeed, 3);

            //item.Value.AisxCurrentPosition = Math.Round(dValue / item.Value.PlusFeed, 3);
            return AisxCurrentPosition;
        }


    }
    public static class IntegerAndBinaryConverter
    {
        /// <summary>
        /// 整数值转为二进制数组
        /// </summary>
        /// <param name="resultSize">最终二进制数组的大小，默认32</param>
        /// <returns>byte数组</returns>
        public static byte[] ToBinaryBits(this int integer, int resultSize = 32)
        {
            var result = new byte[resultSize];

            var binaryString = Convert.ToString(integer, 2);
            // 先把string转成char数组，再将char数组中每一个值转为byte（需要减去char类型0的值，即48）。
            var binaryBits = binaryString.ToCharArray().Select(i => (byte)(i - 48)).ToArray();
            var binarySize = binaryBits.Length;

            if (binarySize > resultSize)
            {
                throw new ArgumentException("设置的结果数组容量不足。");
            }
            //   Array.Reverse(binaryBits); //此方法可以将数组中的值颠倒
            Array.Copy(binaryBits, 0, result, resultSize - binaryBits.Length, binaryBits.Length);
            Array.Reverse(result); //此方法可以将数组中的值颠倒
            return result;
        }

        /// <summary>
        /// 二进制数组转整数
        /// </summary>
        /// <returns>整数值</returns>
        public static int FromBinaryToInt(this byte[] binaryBits)
        {
            if (binaryBits.Any(i => i != 0 && i != 1)) // 如果该数组包含有0/1之外的值，则抛出异常
            {
                throw new ArgumentException("若要使用该方法，byte数组必须只包含0或1。");
            }
            return Convert.ToInt32(string.Join("", binaryBits), 2);
        }
    }
    public struct _Point
    {
        public double x, y;
    }
}
