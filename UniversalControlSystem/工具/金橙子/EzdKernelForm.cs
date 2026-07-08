using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public partial class EzdKernelForm : Form
    {
        public static EzdKernelForm ezdForm = new EzdKernelForm();
        public EzdKernelForm()
        {

            InitializeComponent();
        }
        private static CheckBox[] chk = new CheckBox[30];
        public EzdKernel.E3_ID m_idEM = EzdKernel.E3_ID.INVALID;//管理器ID
        public EzdKernel.E3_ID m_idCurLayer = EzdKernel.E3_ID.INVALID; //得到层ID
        EzdKernel.E3_ID m_idMarker = EzdKernel.E3_ID.INVALID;//
        public EzdKernel.E3_ID[] m_idMarkerList;//卡
        public EzdKernel.E3_ID[] m_idLayerList;//图层
        List<EzdKernel.E3_ID> m_idForListMarkEntList;
        EzdKernel.E3_ID m_idEntbyIndex = EzdKernel.E3_ID.INVALID;
        EzdKernel.E3_ID idFont;
        public EzdKernel.E3_ID[] m_IdEntList;//指定对象ID列表
        int[] m_CardSn;
        int m_nCurrentLayerIndex = 0;
        int m_nCurrentMarkerIndex = 0;
        bool m_bIsInitailOK = false;
        private void button1_Click(object sender, EventArgs e)
        {
            initEzd();
            ezdForm = this;
        }

        public bool initEzd()
        {
            try
            {
                EzdKernel.E3_ERR err = EzdKernel.E3_Initial(Application.StartupPath, 0);
                MessageBox.Show("打开图档" + err.ToString());
                if (err == EzdKernel.E3_ERR.EZCADRUN)
                {
                    MessageBox.Show($"金橙子DLC已经打开{err}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    m_bIsInitailOK = true;
                    //设置语言
                    EzdKernel.E3_SetLanguageFile(Application.StartupPath + "\\LANG\\lang_Chs.ini");
                    m_idEM = EzdKernel.E3_CreateEntMgr(0);//创建对象管理器
                    EzdKernel.E3_GetLayerId(m_idEM, 0, ref m_idCurLayer);//得到层ID
                    UpdateImage();
                    bool GetMarkerOK = GetAllMark(ref m_idMarkerList, ref m_CardSn);
                    if (GetMarkerOK)
                    {
                        m_nCurrentMarkerIndex = 0;
                        m_idMarker = m_idMarkerList[m_nCurrentMarkerIndex];
                    }
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("初始化金橙子DLC失败！" + EX.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 默认固定显示110*110范围
        /// </summary>
        void UpdateImage()
        {
            double dWorkspaceWidth = 110;//显示的范围宽度
            double dWorkspaceHeight = 110;//显示的范围高度
            int nBmpWidth = pictureBox1.Width;
            int nBmpHeight = pictureBox1.Height;
            double fScale1 = dWorkspaceWidth / (double)nBmpWidth;
            double fScale2 = dWorkspaceHeight / (double)nBmpHeight;
            double dLogScale;
            if (fScale1 < fScale2)
                dLogScale = fScale2;
            else
                dLogScale = fScale1;
            double dLogOriginX = -0.5 * dLogScale * (double)nBmpWidth;//显示区域左下X坐标
            double dLogOriginY = -0.5 * dLogScale * (double)nBmpHeight;//显示区域左下Y坐标
            Bitmap bmp = new Bitmap(nBmpWidth, nBmpHeight);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, new Rectangle(0, 0, nBmpWidth, nBmpHeight));
            IntPtr hdc = g.GetHdc();
            EzdKernel.E3_DrawEnt(hdc, m_idCurLayer, 0, nBmpWidth, nBmpHeight, dLogOriginX, dLogOriginY, dLogScale);
            g.ReleaseHdc(hdc);
            pictureBox1.Image = Image.FromHbitmap(bmp.GetHbitmap());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            int m_nEntCount = 0;
            string filePath = "";
            dlg.Filter = "Ez3 files(*.ez3)|*.ez3";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.FileName;
                EzdKernel.E3_ERR err = EzdKernel.E3_OpenFileToEntMgr(textBox1.Text, m_idEM, false, false);
                MessageBox.Show("OpenFile=" + err.ToString());
                int nLayerCount = 0;
                //查出有多少图层得到层数和当前序号
                EzdKernel.E3_ERR err1 = EzdKernel.E3_GetLayerCount(m_idEM, ref nLayerCount, ref m_nCurrentLayerIndex);
                numericUpDown1.Maximum = nLayerCount - 1;
                m_idLayerList = new EzdKernel.E3_ID[nLayerCount];
                for (int i = 0; i < nLayerCount; i++)
                {
                    m_idLayerList[i] = EzdKernel.E3_ID.INVALID;
                    //根据层序号得到指定层ID
                    EzdKernel.E3_ERR err2 = EzdKernel.E3_GetLayerId(m_idEM, i, ref m_idLayerList[i]);
                }
                numericUpDown1.Value = m_nCurrentLayerIndex;
                m_idCurLayer = m_idLayerList[m_nCurrentLayerIndex];
                EzdKernel.E3_ERR Err = EzdKernel.E3_FindEntInLayerByIndex(m_idCurLayer, 0, ref m_idEntbyIndex);
                //得到指定图层指定对象数量
                EzdKernel.E3_GetEntCountInLayer(m_idCurLayer, ref m_nEntCount);
                m_IdEntList = new EzdKernel.E3_ID[m_nEntCount];
                for (int i = 0; i < m_nEntCount; i++)
                {
                    //得到指定图层指定对象ID
                    EzdKernel.E3_FindEntInLayerByIndex(m_idCurLayer, i, ref m_IdEntList[i]);
                    StringBuilder EntName = new StringBuilder();
                    //根据ID获取对象名
                    EzdKernel.E3_GetEntityName(m_IdEntList[i], EntName);
                }
                //dataGridView1.Rows.Clear();
                if (m_nEntCount > 0)
                {
                    m_idEntbyIndex = m_IdEntList[0];
                }
                filePath = dlg.FileName;
                UpdateImage();
                GetPenParam();
                ezdForm = this;

            }
        }

        /// <summary>
        /// 图层ID.m_idCurLayer
        /// 对象在该图层中的序号0
        /// 对象ID.m_idEntbyIndex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button57_Click(object sender, EventArgs e)
        {
            EzdKernel.E3_ERR Err = EzdKernel.E3_FindEntInLayerByIndex(m_idCurLayer, 1, ref m_idEntbyIndex);
            Err = EzdKernel.E3_MoveRotateEnt(m_idEntbyIndex, 20, 0, 0, 0, 0);
            if (Err != 0)
            {
                MessageBox.Show(Err + ":E3_MoveRotateEnt");
            }
            UpdateImage();
        }

        /// <summary>
        /// DLC板卡IDm_idMarker
        /// 管理器IDm_idEM
        /// 对象ID或层IDm_idEntbyIndex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                EzdKernel.E3_ERR err = EzdKernel.E3_MarkEnt2(EzdKernelForm.ezdForm.m_idMarkerList[1], EzdKernelForm.ezdForm.m_idEM, EzdKernelForm.ezdForm.m_idLayerList[1], 0, 0, 1);
                if (err != EzdKernel.E3_ERR.SUCCESS)
                {
                    MessageBox.Show("Red=" + err.ToString() + ",ERR=" + err.ToString());
                }
                else
                {
                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue(err.ToString());
                }
            });
        }

        /// <summary>
        ///多张卡存在时
        /// </summary>
        /// <param name="MarkerIDList"></param>
        /// <param name="MarkerSnList"></param>
        /// <returns></returns>
        private bool GetAllMark(ref EzdKernel.E3_ID[] MarkerIDList, ref int[] MarkerSnList)
        {
            //获取所有卡ID
            EzdKernel.E3_ID[] ResultAll = new EzdKernel.E3_ID[8];
            int nMarkCount = 0;
            for (int i = 0; i < 8; i++)
            {
                //得到第一张卡的ID
                EzdKernel.E3_ID OneMark = EzdKernel.E3_MarkerGetFirstValidId();

                if (OneMark != EzdKernel.E3_ID.INVALID)
                {
                    ResultAll[i] = OneMark;

                    nMarkCount++;
                }
                else
                {
                    break;
                }
            }
            if (nMarkCount < 1)
            {
                return false;
            }
            MarkerIDList = new EzdKernel.E3_ID[nMarkCount];

            for (int i = 0; i < nMarkCount; i++)
            {
                MarkerIDList[i] = ResultAll[i];
            }
            MarkerSnList = new int[nMarkCount];
            for (int i = 0; i < nMarkCount; i++)
            {
                int Sn = -1;
                //MarkerIDList[i]每个板卡号，每个板卡对应得SN号，可以根据此接口判断具体是哪个板卡对应哪个参数
                EzdKernel.E3_ERR err = EzdKernel.E3_GetMarkerSN(MarkerIDList[i], ref Sn);

                MarkerSnList[i] = Sn;
            }
            return true;
        }


        //红光预览
        private void button4_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                EzdKernel.E3_ERR err = EzdKernel.E3_MarkEnt2(m_idMarkerList[0], m_idEM, m_idCurLayer, 2, 0, 1);
            });
        }

        //停止加工
        private void button5_Click(object sender, EventArgs e)
        {
            EzdKernel.E3_ERR err = EzdKernel.E3_MarkerStop(m_idMarkerList[0]);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                EzdKernel.E3_ERR err = EzdKernel.E3_MarkEnt2(m_idMarkerList[1], m_idEM, m_idCurLayer, 2, 0, 1);
            });
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EzdKernel.E3_ERR err = EzdKernel.E3_MarkerStop(m_idMarkerList[1]);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                EzdKernel.E3_ERR err = EzdKernel.E3_MarkEnt2(EzdKernelForm.ezdForm.m_idMarkerList[0], EzdKernelForm.ezdForm.m_idEM, EzdKernelForm.ezdForm.m_idLayerList[0], 0, 0, 1);
                if (err != EzdKernel.E3_ERR.SUCCESS)
                {
                    MessageBox.Show("Red=" + err.ToString() + ",ERR=" + err.ToString());
                }
                else
                {
                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue(err.ToString());
                }
            });
        }

        //移动图档对象
        private void button9_Click(object sender, EventArgs e)
        {
            EzdKernel.E3_ERR err = EzdKernel.E3_MoveRotateEnt(m_idLayerList[0], 10, 0, 0, 0, 0);
            if (err != EzdKernel.E3_ERR.SUCCESS)
            {
                MessageBox.Show("ERR=" + err.ToString());
            }
            UpdateImage();
        }

        //移动图档对象
        private void button10_Click(object sender, EventArgs e)
        {
            EzdKernel.E3_ERR err = EzdKernel.E3_MoveRotateEnt(m_idLayerList[0], -10, 0, 0, 0, 0);
            if (err != EzdKernel.E3_ERR.SUCCESS)
            {
                MessageBox.Show("ERR=" + err.ToString());
            }
            UpdateImage();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            EzdKernel.E3_ERR err = EzdKernel.E3_Close();
            if (err != EzdKernel.E3_ERR.SUCCESS)
            {
                MessageBox.Show("释放卡失败！" + err.ToString());
            }
            else
            {
                ezdForm = null;
                MessageBox.Show("释放卡成功！" + err.ToString());
            }
        }

        public void GetPenParam()
        {
            //string pStrName = "Default";
            StringBuilder pStrName = new StringBuilder("Default");
            int clr = 0;
            bool bDisableMark = false;
            bool bUseDefParam = false;
            int nMarkLoop = 0;
            double dMarkSpeed = 0;//振镜速度;
            double dPowerRatio = 0;//功率
            double dCurrent = 0;
            double dFreq = 0;//频率
            double dQPulseWidth = 0;
            int nStartTC = 0;
            int nLaserOffTC = 0;
            int nEndTC = 0;
            int nPolyTC = 0;
            double dJumpSpeed = 0;
            int nMinJumpDelayTCUs = 0;
            int nMaxJumpDelayTCUs = 0;
            double dJumpLengthLimit = 0;
            double dPointTimeMs = 0;
            bool nSpiSpiContinueMode = false;
            int nSpiWave = 0;
            int nYagMarkMode = 0;
            bool bPulsePointMode = false;
            int nPulseNum = 0;
            bool bEnableACCMode = false;
            double dEndComp = 0;
            double dAccDist = 0;
            double dBreakAngle = 0;
            bool bWobbleMode = false;
            double bWobbleDiameter = 0;
            double bWobbleDist = 0;
            EzdKernel.E3_ERR Err = EzdKernel.E3_GetPenParam(ezdForm.m_idEM,
                                             0,
                                             pStrName,
                                             ref clr,
                                             ref bDisableMark,
                                             ref bUseDefParam,
                                             ref nMarkLoop,
                                             ref dMarkSpeed,
                                             ref dPowerRatio,
                                             ref dCurrent,
                                             ref dFreq,
                                             ref dQPulseWidth,
                                             ref nStartTC,
                                             ref nLaserOffTC,
                                             ref nEndTC,
                                             ref nPolyTC,
                                             ref dJumpSpeed,
                                             ref nMinJumpDelayTCUs,
                                             ref nMaxJumpDelayTCUs,
                                             ref dJumpLengthLimit,
                                             ref dPointTimeMs,
                                             ref nSpiSpiContinueMode,
                                             ref nSpiWave,
                                             ref nYagMarkMode,
                                             ref bPulsePointMode,
                                             ref nPulseNum,
                                             ref bEnableACCMode,
                                             ref dEndComp,
                                             ref dAccDist,
                                             ref dBreakAngle,
                                             ref bWobbleMode,
                                             ref bWobbleDiameter,
                                             ref bWobbleDist);
            bool EnableContour = true;
            bool FirstContour = false;
            EzdKernel.HatchParam Param1 = new EzdKernel.HatchParam(0);
            EzdKernel.HatchParam Param2 = new EzdKernel.HatchParam(0);
            EzdKernel.HatchParam Param3 = new EzdKernel.HatchParam(0);
            EzdKernel.E3_ERR Err1 = EzdKernel.E3_GetHatchParam(m_idEntbyIndex, ref EnableContour, ref FirstContour, ref Param1, ref Param2, ref Param3);
            DataManage.SetData("清洗", "线间距", Param1.m_dHatchLineDist);
            DataManage.SetData("清洗", "速度", dMarkSpeed);
            DataManage.SetData("清洗", "功率", dPowerRatio/100*250);
            DataManage.SetData("清洗", "频率", dFreq / 1000);
            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"速度{dMarkSpeed}功率{dPowerRatio}频率{dFreq / 1000}");
        }

        public void ReadEzdStart(EzdKernel.E3_ID m_idMarkerList,ref bool MarkerCheckLaserState)
        {
            EzdKernel.E3_MarkerCheckLaserState(m_idMarkerList, ref MarkerCheckLaserState);
        }

        //private void button13_Click(object sender, EventArgs e)
        //{
        //    EzdKernel.E3_ID m_idEM = new EzdKernel.E3_ID(0);
        //    m_idEM=EzdKernel.E3_CreateEntMgr(0);
        //    bool bAccSegEnable = false;
        //    double dAccSegStartRatio = 0.0;
        //    double dAccSegLen = 0.0;
        //    bool bDecSegEnable = false;
        //    double dDecSegStartRatio = 0.0;
        //    double dDecSegLen = 0.0;
        //    EzdKernel.E3_GetPenParamPowerRamp(m_idEM, 0, ref bAccSegEnable, ref dAccSegStartRatio, ref dAccSegLen, ref bDecSegEnable, ref dDecSegStartRatio, ref dDecSegLen);
        //}
    }
}
