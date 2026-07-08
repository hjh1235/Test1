using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public partial class MainForm : Form
    {
        public FormStart m_formStart;
        public Form m_formCCD;
        public ReportForm m_FormReport;
        //public Form m_FormDefinedFlow;
        public SystemSettings m_formSystemSetting;
        public AxisStateViewForm m_AxisStateViewForm = new AxisStateViewForm();
        public 波形展示 m_PowerViewForm = new 波形展示();
        public DebugForm debugForm = new DebugForm();
        public FormAutorityManage m_formUserManage;
        public FormUserLogoin m_formUserLogoin;
        public static FormAlarm m_formAlarm;
        // public FlowMain _FlowMain = null;
        public static bool bAlarm = false;
        public bool bPreAuto = false;
        public static bool 激光器就绪 = false;
        public MainForm()
        {
            InitializeComponent();
        }
        AutoSizeFormClass asc = new AutoSizeFormClass();

        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            InitAllForm();
            btnStartForm.BackColor = Color.Cyan;
            //m_AxisStateViewForm.Show(this);
            m_formAlarm.alarmChangedEvent += m_formAlarm_alarmChangedEvent;
            timerInit.Enabled = true;
            timer1.Enabled = true;
            tmrFoolProof.Enabled = true;

            //Mes状态
            if (LoginForm.bIgnoreMes)
            {
                toolStripStatusLabel_Mes.BackColor = Color.Red;
                toolStripStatusLabel_Mes.Text = "MES未连接";
            }
            else
            {
                toolStripStatusLabel_Mes.BackColor = Color.Green;
                toolStripStatusLabel_Mes.Text = "MES已连接";
            }

        }
        void m_formAlarm_alarmChangedEvent(object sender, bool bAlarm, bool bSilence)
        {
            MainForm.bAlarm = bAlarm && !bSilence;
            if (bAlarm)
            {
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("RESET"))
                {
                    // Googol_Contral.SetOutBit("BIZZ", false);
                }

                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("BIZZ"))
                {
                    if (bSilence)
                    {
                        //   Googol_Contral.SetOutBit("BIZZ", false); 
                    }
                    else
                    {
                        //Googol_Contral.SetOutBit("BIZZ", true);
                    }
                }
            }
            else
            {
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("RESET"))
                {
                    // Googol_Contral.SetOutBit("BIZZ", false);
                }

                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("BIZZ"))
                {
                    // Googol_Contral.SetOutBit("BIZZ", false);
                }
            }
        }
        /// <summary>
        /// 初始化菜单栏所有界面
        /// </summary>
        private void InitAllForm()
        {
            m_formStart = new FormStart(this);
            m_formStart.TopLevel = false;
            panelMain.Controls.Add(m_formStart);
            m_formStart.Size = panelMain.Size;
            m_formStart.Show();

            //m_formCCD = Program.ccdForm;
            //m_formCCD = new CCDForm();
            //m_formCCD.TopLevel = false;
            panelMain.Controls.Add(m_formCCD);
            //m_formCCD.Size = panelMain.Size;
            //m_formCCD.Hide();

            m_FormReport = new ReportForm();
            m_FormReport.TopLevel = false;
            panelMain.Controls.Add(m_FormReport);
            m_FormReport.Size = panelMain.Size;
            m_FormReport.Hide();

            //m_FormDefinedFlow = new DefinedFlowForm();
            //m_FormDefinedFlow.TopLevel = false;
            //panelMain.Controls.Add(m_FormDefinedFlow);
            //m_FormDefinedFlow.Size = panelMain.Size;
            //m_FormDefinedFlow.Hide();

            m_formSystemSetting = new SystemSettings();
            m_formSystemSetting.TopLevel = false;
            panelMain.Controls.Add(m_formSystemSetting);
            m_formSystemSetting.Size = panelMain.Size;
            m_formSystemSetting.Hide();


            m_formUserManage = new FormAutorityManage();
            m_formUserManage.TopLevel = false;
            panelMain.Controls.Add(m_formUserManage);
            m_formUserManage.Size = panelMain.Size;
            m_formUserManage.Hide();

            m_formAlarm = new FormAlarm();
            m_formAlarm.TopLevel = false;
            panelMain.Controls.Add(m_formAlarm);
            m_formAlarm.Left = panelMain.Width / 2 - m_formAlarm.Width / 2;
            m_formAlarm.Top = panelMain.Height / 2 - m_formAlarm.Height / 2;
            m_formAlarm.Hide();


            //_FlowMain = new FlowMain();
            // _FlowMain.TopLevel = false;
            // panelMain.Controls.Add(_FlowMain);
            // _FlowMain.Size = panelMain.Size;
            //   _FlowMain.Show();

            timerInit.Enabled = true;
        }
        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {


            this.Close();
        }
        /// <summary>
        /// 系统退出时关闭轴的使能状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出程序？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result.ToString().ToUpper() != "YES")
            {
                e.Cancel = true;
                return;
            }
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                item.Value.bFlagServoOn = false;
                gts.mc.GT_AxisOff((short)item.Value.m_CardNo, (short)(item.Value.m_AxisNo + 1));
            }
            //Environment.Exit(0);
        }
        /// <summary>
        /// 最小化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 打开开始界面按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartForm_Click(object sender, EventArgs e)
        {
            m_formStart.Show();
            //m_formCCD.Hide();
            m_FormReport.Hide();
            //m_FormDefinedFlow.Hide();
            m_formSystemSetting.Hide();
            m_formUserManage.Hide();
            m_formStart.Activate();
            m_formStart.InfoTask();
            //_FlowMain.Hide();
            btnStartForm.BackColor = Color.Cyan;
            btnCCDForm.BackColor = SystemColors.ControlLight;
            btnDefinedFlowForm.BackColor = SystemColors.ControlLight;
            btnReportForm.BackColor = SystemColors.ControlLight;
            btnSystemForm.BackColor = SystemColors.ControlLight;
            btnManageForm.BackColor = SystemColors.ControlLight;

            //try
            //{
            //    asc.controlAutoSize(this);
            //}
            //catch (Exception)
            //{


            //}
        }
        /// <summary>
        /// 打开CCD界面按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCCDForm_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Ckdebug == false)
            {
                ToolStripButton button = (ToolStripButton)sender;
                string bntName = button.Text;
                bool result = SQLiteConnect.getResult(bntName);
                if (result == false)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.系统权限不足.ToString());
                    return;
                }
            }
            //_FlowMain.Hide();
            m_formStart.Hide();
            //m_formCCD.Show();
            m_FormReport.Hide();
            //m_FormDefinedFlow.Hide();
            m_formSystemSetting.Hide();
            m_formUserManage.Hide();
            m_formCCD.Activate();

            btnStartForm.BackColor = SystemColors.ControlLight;
            btnCCDForm.BackColor = Color.Cyan;
            btnDefinedFlowForm.BackColor = SystemColors.ControlLight;
            btnReportForm.BackColor = SystemColors.ControlLight;
            btnSystemForm.BackColor = SystemColors.ControlLight;
            btnManageForm.BackColor = SystemColors.ControlLight;
        }
        /// <summary>
        /// 打开数据报表界面按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReportForm_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Ckdebug == false)
            {
                ToolStripButton button = (ToolStripButton)sender;
                string bntName = button.Text;
                bool result = SQLiteConnect.getResult(bntName);
                if (result == false)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.系统权限不足.ToString());
                    return;
                }
            }
            //_FlowMain.Hide();
            m_formStart.Hide();
            //m_formCCD.Hide();
            m_FormReport.Show();
            //m_FormDefinedFlow.Hide();
            m_formSystemSetting.Hide();
            m_formUserManage.Hide();

            btnStartForm.BackColor = Color.Cyan;
            btnCCDForm.BackColor = Color.Cyan;
            btnDefinedFlowForm.BackColor = Color.Cyan;
            btnReportForm.BackColor = Color.Lime;
            btnSystemForm.BackColor = Color.Cyan;
            btnManageForm.BackColor = Color.Cyan;
        }
        /// <summary>
        /// 打开自定义流程界面按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefinedFlowForm_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Ckdebug == false)
            {
                ToolStripButton button = (ToolStripButton)sender;
                string bntName = button.Text;
                bool result = SQLiteConnect.getResult(bntName);
                if (result == false)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.系统权限不足.ToString());
                    return;
                }
            }
            //_FlowMain.Hide();
            m_formStart.Hide();
            //m_formCCD.Hide();
            m_FormReport.Hide();
            //m_FormDefinedFlow.Show();
            m_formSystemSetting.Hide();
            m_formUserManage.Hide();

            btnStartForm.BackColor = Color.Cyan;
            btnCCDForm.BackColor = Color.Cyan;
            btnDefinedFlowForm.BackColor = Color.Lime;
            btnReportForm.BackColor = Color.Cyan;
            btnSystemForm.BackColor = Color.Cyan;
            btnManageForm.BackColor = Color.Cyan;
        }
        /// <summary>
        /// 打开系统设置界面按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSystemForm_ButtonClick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Ckdebug == false)
            {
                ToolStripButton button = (ToolStripButton)sender;
                string bntName = button.Text;
                bool result = SQLiteConnect.getResult(bntName);
                if (result == false)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.系统权限不足.ToString());
                    return;
                }
            }
            //_FlowMain.Hide();
            m_formStart.Hide();
            //m_formCCD.Hide();
            m_FormReport.Hide();
            //m_FormDefinedFlow.Hide();
            m_formSystemSetting.Show();
            m_formUserManage.Hide();

            btnStartForm.BackColor = SystemColors.ControlLight;
            btnCCDForm.BackColor = SystemColors.ControlLight;
            btnDefinedFlowForm.BackColor = SystemColors.ControlLight;
            btnReportForm.BackColor = SystemColors.ControlLight;
            btnSystemForm.BackColor = Color.Cyan;
            btnManageForm.BackColor = SystemColors.ControlLight;
        }
        /// <summary>
        /// 用户管理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnManageForm_ButtonClick(object sender, EventArgs e)
        {
            if (FormUserLogoin.userName != "test")
            {
                if (Properties.Settings.Default.Ckdebug == false)
                {
                    ToolStripSplitButton button = (ToolStripSplitButton)sender;
                    string bntName = button.Text;
                    bool result = SQLiteConnect.getResult(bntName);
                    if (result == false)
                    {
                        MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.系统权限不足.ToString());
                        return;
                    }
                }
            }
            //_FlowMain.Hide();

            m_formStart.Hide();
            //m_formCCD.Hide();
            m_FormReport.Hide();
            //m_FormDefinedFlow.Hide();
            m_formSystemSetting.Hide();
            m_formUserManage.Show();


            btnStartForm.BackColor = SystemColors.ControlLight;
            btnCCDForm.BackColor = SystemColors.ControlLight;
            btnDefinedFlowForm.BackColor = SystemColors.ControlLight;
            btnReportForm.BackColor = SystemColors.ControlLight;
            btnSystemForm.BackColor = SystemColors.ControlLight;
            btnManageForm.BackColor = Color.Cyan;
        }

        private void timerInit_Tick(object sender, EventArgs e)
        {
            if (Program.bAuto)
            {
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("START"))
                {
                    //    Googol_Contral.SetOutBit("START", true);
                }
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("STOP"))
                {
                    // Googol_Contral.SetOutBit("STOP", false);
                }
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("三色灯红"))
                {
                    // Googol_Contral.SetOutBit("三色灯红", false);
                }
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("三色灯黄"))
                {
                    // Googol_Contral.SetOutBit("三色灯黄", false);
                }
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("三色灯绿"))
                {
                    // Googol_Contral.SetOutBit("三色灯绿", true);
                }
            }
            else
            {
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("三色灯黄") && Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["三色灯黄"].bBitInputStatus == true)
                {
                    //   Googol_Contral.SetOutBit("三色灯黄", false);
                }
                else if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("三色灯黄") && Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["三色灯黄"].bBitInputStatus == false)
                {//
                 //   Googol_Contral.SetOutBit("三色灯黄", true);
                }
            }
            //   bool bBitOutputStatus = Googol_Contral.GetOutOn("BIZZ");
            if (Program.bAlarm)
            {
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary.ContainsKey("BIZZ") && Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary["BIZZ"].bBitOutputStatus == true)
                {
                    // Googol_Contral.SetOutBit("BIZZ", false);
                    // IOManage.OUTPUT("三色灯红").SetOutBit(false);
                    //  Googol_Contral.SetOutBit("三色灯黄", false);
                }
                else if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary.ContainsKey("BIZZ") && Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary["BIZZ"].bBitOutputStatus == false)
                {
                    // Googol_Contral.SetOutBit("BIZZ", true);
                    // Googol_Contral.SetOutBit("三色灯红", true);
                    // Googol_Contral.SetOutBit("三色灯黄", false);
                    // Googol_Contral.SetOutBit("三色灯绿", false);
                }
            }


        }

        PerformanceCounter totalcpu = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName);
        PerformanceCounter totalram = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName);
        /// <summary>
        /// 底部状态栏状态显示计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                tssTime.Text = DateTime.Now.ToString();
                if (tssUserPermissions.Text != FormUserLogoin.userpermissions)
                {
                    tssUserPermissions.Text = FormUserLogoin.userpermissions;
                }
                tssCPU.Text = totalcpu.NextValue().ToString("0.00") + "%";
                tssMemory.Text = totalram.NextValue().ToString("0.00") + "%";
                tssAssemblyFileVersion.Text = "Ver " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                if (!Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("EStop"))
                {
                    toolStripStatusLabel4.BackColor = Color.Yellow;
                }
                else
                {
                    if (!Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["EStop"].bBitInputStatus)
                    {
                        toolStripStatusLabel4.BackColor = Color.Red;
                    }
                    else
                    {
                        toolStripStatusLabel4.BackColor = Color.Yellow;
                    }
                }
                if (!Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("DoorOpen"))
                {
                    toolStripStatusLabel3.BackColor = Color.Yellow;
                }
                else
                {
                    if (!Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["DoorOpen"].bBitInputStatus)
                    {
                        toolStripStatusLabel3.BackColor = Color.Red;
                    }
                    else
                    {
                        toolStripStatusLabel3.BackColor = Color.Green;
                    }
                }
                if (!Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("Grating"))
                {
                    toolStripStatusLabel2.BackColor = Color.Yellow;
                }
                else
                {
                    if (!Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["Grating"].bBitInputStatus)
                    {
                        toolStripStatusLabel2.BackColor = Color.Red;
                    }
                    else
                    {
                        toolStripStatusLabel2.BackColor = Color.Green;
                    }
                }

                if (!FormStart.bAllAxisHomed)
                {
                    toolStripStatusLabel5.BackColor = Color.Red;
                }
                else
                {
                    toolStripStatusLabel5.BackColor = Color.Green;
                }

                //激光器就绪提示
                //if (!Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("激光器就绪"))
                //{
                //    toolStripStatusLabel6.BackColor = Color.Yellow;
                //}
                //else
                //{
                //    if (!Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["激光器就绪"].bBitInputStatus && !Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["激光电源启动指示"].bBitInputStatus)
                //    {
                //        toolStripStatusLabel6.BackColor = Color.Red;
                //    }
                //    else
                //    {
                //        toolStripStatusLabel6.BackColor = Color.Green;
                //    }
                //}
                try
                {
                    bool readyWeld = false;
                    if (EzdKernelForm.ezdForm.m_idMarkerList[0] != null)
                    {
                        EzdKernel.E3_MarkerCheckLaserState(EzdKernelForm.ezdForm.m_idMarkerList[0], ref readyWeld);
                    }
                    else
                    {
                        readyWeld = false;
                    }

                    if (readyWeld)
                    {
                        激光器就绪 = true;
                        toolStripStatusLabel6.BackColor = Color.Green;
                    }
                    else
                    {
                        激光器就绪 = false;
                        toolStripStatusLabel6.BackColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel6.BackColor = Color.Red;
                }

                //激光器就绪提示
                if (!Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("冷水机状态"))
                {
                    toolStripStatusLabel6.BackColor = Color.Yellow;
                }
                else
                {
                }
            }
            catch
            {
            }     
        }
        /// <summary>
        /// 注销登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserLogoin.userLevel = 1;
            FormUserLogoin.userpermissions = "操作员";
            FormUserLogoin.userName = "操作员";
            btnStartForm_Click(null, null);
        }
        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_formUserLogoin = new FormUserLogoin();
            m_formUserLogoin.ShowDialog();
        }

        private void tmrFoolProof_Tick(object sender, EventArgs e)
        {
            if (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary.ContainsKey("U") &&
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["U"].AisxCurrentPosition > 180
                &&
               Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["U"].AisxCurrentPosition < 700)
            {
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.ContainsKey("闸门升降气缸上升") && !Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary["闸门升降气缸上升"].bBitInputStatus)
                {
                    //  gts.mc.GT_Stop(0, 255, 0);
                    //    Googol_Contral.SetOutBit("闸门升降气缸上升", true);
                    System.Threading.Thread.Sleep(20);
                    //   Googol_Contral.SetOutBit("闸门升降气缸上升", false);
                    MainForm.m_formAlarm.SetFoolProoftAlarm();

                }
            }
            else
            {
                MainForm.m_formAlarm.RstFoolProoftAlarm();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            //asc.controllInitializeSize(this);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //if (Properties.Settings.Default.Ckdebug == false)
            //{
            //    ToolStripButton button = (ToolStripButton)sender;
            //    string bntName = button.Text;
            //    bool result = SQLiteConnect.getResult(bntName);
            //    if (result == false)
            //    {
            //        MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.系统权限不足.ToString());
            //        return;
            //    }
            //}

            m_formStart.Hide();
            //m_formCCD.Hide();
            m_FormReport.Hide();
            //m_FormDefinedFlow.Hide();
            m_formSystemSetting.Hide();
            m_formUserManage.Hide();
            //_FlowMain.Show();

            btnStartForm.BackColor = Color.Cyan;
            btnCCDForm.BackColor = Color.Cyan;
            btnDefinedFlowForm.BackColor = Color.Lime;
            btnReportForm.BackColor = Color.Cyan;
            btnSystemForm.BackColor = Color.Cyan;
            btnManageForm.BackColor = Color.Cyan;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            asc.AddControl(this); asc.AddControl(this);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ManageContral.SetOutBit("三色灯绿",false);
            ManageContral.SetOutBit("三色灯黄", false);
            ManageContral.SetOutBit("三色灯红", false);
            Weld_Log.Instance().Enqueue("窗体关闭！");
        }
    }
}
