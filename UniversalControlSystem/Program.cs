using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UniversalControlSystem
{
    static class Program
    {
        public static Stopwatch CTWatch = new Stopwatch();
        public static bool shoujian = false;
        public static bool bManul = false;
        public static log4net.ILog logger;
        public static bool m_MarkerCheckLaserState1;
        public static bool m_MarkerCheckLaserState2;
        //屏蔽蜂鸣器
        public static bool noBizz = false;
        /// <summary>
        /// 运行状态标志
        /// </summary>
        public static bool bAuto = false;
        /// <summary>
        /// 运行状态报警标志
        /// </summary>
        public static bool bAlarm = false;
        /// <summary>
        /// 急停状态标志
        /// </summary>
        public static bool bEStop = false;
        /// <summary>
        /// 停止状态标志
        /// </summary>
        public static bool bStop = false;
        /// <summary>
        /// 门状态
        /// </summary>
        public static bool boolDoorOpen = false;
        /// <summary>
        /// 光栅状态
        /// </summary>
        public static bool Grating = false;

        /// <summary>
        /// 复位状态标志
        /// </summary>
        public static bool bReset = false;
        /// <summary>
        /// 补焊
        /// </summary>
        public static bool bWelding = false;
        /// <summary>
        /// 初始化标志
        /// </summary>
        public static bool bInt = false;
        /// <summary>
        /// 多个板卡对应其下轴的数量数组
        /// </summary>
        public static int[] iarryCardNum;
        /// <summary>
        /// 左工位运行标志
        /// </summary>
        public static bool LeftTaskRun = false;
        /// <summary>
        /// 中间工位运行标志
        /// </summary>
        public static bool MiddleTaskRun = false;
        /// <summary>
        /// 右工位运行标志
        /// </summary>
        public static bool RightTaskRun = false;
        /// <summary>
        /// A支架运行标志
        /// </summary>
        public static bool LeftTaskRunA = false;
        /// <summary>
        /// C支架运行标志
        /// </summary>
        public static bool MiddleTaskRunC = false;
        /// <summary>
        /// 补料A支架运行标志
        /// </summary>
        public static bool RightTaskRunFeedingA = false;
        /// <summary>
        /// 左工位清洗信号
        /// </summary>
        public static bool leftWeldSignal = false;
        /// <summary>
        /// 右工位清洗信号
        /// </summary>
        public static bool rightWeldSignal = false;
        /// <summary>
        /// 左工位视觉信号
        /// </summary>
        public static bool leftCCDSignal = false;
        /// <summary>
        /// 右工位视觉信号
        /// </summary>
        public static bool rightCCDSignal = false;
        /// <summary>
        /// 急停报警标志
        /// </summary>      
        public static bool bESTOPAlarm = false;
        public static long 左工位产量 = 0;
        public static long 右工位产量 = 0;
        public static double 左工位运行时间 = 0;
        public static double 右工位运行时间 = 0;
        public static string 运行时间 = "";
        public static long 产量 = 0;
        public static double 离焦量;
        public static bool weldLockLeft = true;
        public static bool weldLockRight = true;
        public static int colunmIndexRight = 1;
        public static int colunmIndexLeft = 1;
        //出光标志
        public static bool ifWeldLeft = false;
        public static bool ifWeldRight = false;
        public static int CurrentPoint_L = 0;
        public static int CurrentPoint_R = 0;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        public static LocationCircle.Setting ccdForm;
        public static bool CloseLaser = false;
        public static bool 焊接停止 = false;
        public static List<List<string>> errorArr = new List<List<string>>();
        public static List<string> errorPosition = new List<string>();
        public static int RETURNres = -1;
        [STAThread]

        static void Main()
        {
            bool newMutexCreated = true;
            using (new Mutex(true, Assembly.GetExecutingAssembly().FullName, out newMutexCreated))
            {
                if (!newMutexCreated)
                {
                    MessageBox.Show("程序已启动！请不要启动多个程序！");
                    Environment.Exit(0);
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                    LoginForm loginForm = new LoginForm();
                    loginForm.StartPosition = FormStartPosition.CenterScreen;
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                    }
                    else
                        return;
                    Splasher.Show(typeof(FrmSplashScreen));
                    Splasher.Status = "正在加载参数......";
                    Hard_Ward_Contral.LoadData();//加载数据
                    //Splasher.Status = "正在加载硬件参数......";

                    //Splasher.Status = "正在初始化硬件......";

                    //Splasher.Status = "正在初始化扫码枪......";

                    Splasher.Status = "正在加载CCD程序......";
                    //ccdForm = new LocationCircle.Setting();
                    //_ccdForm = new Form();
                    Splasher.Close();
                    Application.Run(new MainForm());
                }
            }
        }
        public static void WriteLog(string sMsg)
        {
            FormStart.LOG_ShowFrom["系统LOG"].Enqueue(sMsg);
            //Weld_Log.Instance().Enqueue( sMsg);
        }
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // throw new NotImplementedException();
        }
    }
}
