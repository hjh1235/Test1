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
    public partial class DebugForm : Form
    {
        double dAxisSpeed = 0;
        public DebugForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DebugForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            //this.TopMost = true;
            comboBoxMoveMode.Text = Properties.Settings.Default.sAxisMoveStyle;
            label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[0].Axis_hardwareName.ToString();
            foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
            {
                if (item.Value.m_strHardWare_Modle == "卡硬件")
                {
                    cbo_SelectHardware.Items.Add(item.Value.hardwareName);
                }
            }
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {

                AsixName.Items.Add(item.Value.Axis_hardwareName);
              
            }

            if (cbo_SelectHardware.Items.Count > 0)
                cbo_SelectHardware.SelectedIndex = 0;
        }
        /// <summary>
        /// 根据轴的个数初始化RadioBtn
        /// </summary>
        //public void InitRadioBtnAxis()
        //{
        //    try
        //    {
        //        for (int i = 0; i < Program.iarryCardNum.Length; i++)
        //        {
        //            if (cbo_SelectHardware.SelectedIndex == i)
        //            {
        //                switch (Program.iarryCardNum[i])
        //                {
        //                    case 0:
        //                        label4.Text = "";
        //                        BtnMoveToCCW.Enabled = false;
        //                        btn_MoveToCW.Enabled = false;
        //                        btnALLAxisGoHome.Enabled = false;
        //                        btnAxisGoHome.Enabled = false;
        //                        this.radioBtnAxis1.Enabled = false;
        //                        this.radioBtnAxis2.Enabled = false;
        //                        this.radioBtnAxis3.Enabled = false;
        //                        this.radioBtnAxis4.Enabled = false;
        //                        this.radioBtnAxis5.Enabled = false;
        //                        this.radioBtnAxis6.Enabled = false;
        //                        this.radioBtnAxis7.Enabled = false;
        //                        this.radioBtnAxis8.Enabled = false;

        //                        this.radioBtnAxis1.Checked = false;
        //                        this.radioBtnAxis2.Checked = false;
        //                        this.radioBtnAxis3.Checked = false;
        //                        this.radioBtnAxis4.Checked = false;
        //                        this.radioBtnAxis5.Checked = false;
        //                        this.radioBtnAxis6.Checked = false;
        //                        this.radioBtnAxis7.Checked = false;
        //                        this.radioBtnAxis8.Checked = false;
        //                        break;
        //                    case 1:
        //                        BtnMoveToCCW.Enabled = true;
        //                        btn_MoveToCW.Enabled = true;
        //                        btnALLAxisGoHome.Enabled = true;
        //                        btnAxisGoHome.Enabled = true;
        //                        this.radioBtnAxis1.Enabled = true;
        //                        this.radioBtnAxis2.Enabled = false;
        //                        this.radioBtnAxis3.Enabled = false;
        //                        this.radioBtnAxis4.Enabled = false;
        //                        this.radioBtnAxis5.Enabled = false;
        //                        this.radioBtnAxis6.Enabled = false;
        //                        this.radioBtnAxis7.Enabled = false;
        //                        this.radioBtnAxis8.Enabled = false;

        //                        this.radioBtnAxis2.Checked = false;
        //                        this.radioBtnAxis3.Checked = false;
        //                        this.radioBtnAxis4.Checked = false;
        //                        this.radioBtnAxis5.Checked = false;
        //                        this.radioBtnAxis6.Checked = false;
        //                        this.radioBtnAxis7.Checked = false;
        //                        this.radioBtnAxis8.Checked = false;
        //                        break;
        //                    case 2:
        //                        BtnMoveToCCW.Enabled = true;
        //                        btn_MoveToCW.Enabled = true;
        //                        btnALLAxisGoHome.Enabled = true;
        //                        btnAxisGoHome.Enabled = true;
        //                        this.radioBtnAxis1.Enabled = true;
        //                        this.radioBtnAxis2.Enabled = true;
        //                        this.radioBtnAxis3.Enabled = false;
        //                        this.radioBtnAxis4.Enabled = false;
        //                        this.radioBtnAxis5.Enabled = false;
        //                        this.radioBtnAxis6.Enabled = false;
        //                        this.radioBtnAxis7.Enabled = false;
        //                        this.radioBtnAxis8.Enabled = false;

        //                        this.radioBtnAxis3.Checked = false;
        //                        this.radioBtnAxis4.Checked = false;
        //                        this.radioBtnAxis5.Checked = false;
        //                        this.radioBtnAxis6.Checked = false;
        //                        this.radioBtnAxis7.Checked = false;
        //                        this.radioBtnAxis8.Checked = false;
        //                        break;
        //                    case 3:
        //                        BtnMoveToCCW.Enabled = true;
        //                        btn_MoveToCW.Enabled = true;
        //                        btnALLAxisGoHome.Enabled = true;
        //                        btnAxisGoHome.Enabled = true;
        //                        this.radioBtnAxis1.Enabled = true;
        //                        this.radioBtnAxis2.Enabled = true;
        //                        this.radioBtnAxis3.Enabled = true;
        //                        this.radioBtnAxis4.Enabled = false;
        //                        this.radioBtnAxis5.Enabled = false;
        //                        this.radioBtnAxis6.Enabled = false;
        //                        this.radioBtnAxis7.Enabled = false;
        //                        this.radioBtnAxis8.Enabled = false;

        //                        this.radioBtnAxis4.Checked = false;
        //                        this.radioBtnAxis5.Checked = false;
        //                        this.radioBtnAxis6.Checked = false;
        //                        this.radioBtnAxis7.Checked = false;
        //                        this.radioBtnAxis8.Checked = false;
        //                        break;
        //                    case 4:
        //                        BtnMoveToCCW.Enabled = true;
        //                        btn_MoveToCW.Enabled = true;
        //                        btnALLAxisGoHome.Enabled = true;
        //                        btnAxisGoHome.Enabled = true;
        //                        this.radioBtnAxis1.Enabled = true;
        //                        this.radioBtnAxis2.Enabled = true;
        //                        this.radioBtnAxis3.Enabled = true;
        //                        this.radioBtnAxis4.Enabled = true;
        //                        this.radioBtnAxis5.Enabled = false;
        //                        this.radioBtnAxis6.Enabled = false;
        //                        this.radioBtnAxis7.Enabled = false;
        //                        this.radioBtnAxis8.Enabled = false;

        //                        this.radioBtnAxis5.Checked = false;
        //                        this.radioBtnAxis6.Checked = false;
        //                        this.radioBtnAxis7.Checked = false;
        //                        this.radioBtnAxis8.Checked = false;
        //                        break;
        //                    case 5:
        //                        BtnMoveToCCW.Enabled = true;
        //                        btn_MoveToCW.Enabled = true;
        //                        btnALLAxisGoHome.Enabled = true;
        //                        btnAxisGoHome.Enabled = true;
        //                        this.radioBtnAxis1.Enabled = true;
        //                        this.radioBtnAxis2.Enabled = true;
        //                        this.radioBtnAxis3.Enabled = true;
        //                        this.radioBtnAxis4.Enabled = true;
        //                        this.radioBtnAxis5.Enabled = true;
        //                        this.radioBtnAxis6.Enabled = false;
        //                        this.radioBtnAxis7.Enabled = false;
        //                        this.radioBtnAxis8.Enabled = false;

        //                        this.radioBtnAxis6.Checked = false;
        //                        this.radioBtnAxis7.Checked = false;
        //                        this.radioBtnAxis8.Checked = false;
        //                        break;
        //                    case 6:
        //                        BtnMoveToCCW.Enabled = true;
        //                        btn_MoveToCW.Enabled = true;
        //                        btnALLAxisGoHome.Enabled = true;
        //                        btnAxisGoHome.Enabled = true;
        //                        this.radioBtnAxis1.Enabled = true;
        //                        this.radioBtnAxis2.Enabled = true;
        //                        this.radioBtnAxis3.Enabled = true;
        //                        this.radioBtnAxis4.Enabled = true;
        //                        this.radioBtnAxis5.Enabled = true;
        //                        this.radioBtnAxis6.Enabled = true;
        //                        this.radioBtnAxis7.Enabled = false;
        //                        this.radioBtnAxis8.Enabled = false;

        //                        this.radioBtnAxis7.Checked = false;
        //                        this.radioBtnAxis8.Checked = false;
        //                        break;
        //                    case 7:
        //                        BtnMoveToCCW.Enabled = true;
        //                        btn_MoveToCW.Enabled = true;
        //                        btnALLAxisGoHome.Enabled = true;
        //                        btnAxisGoHome.Enabled = true;
        //                        this.radioBtnAxis1.Enabled = true;
        //                        this.radioBtnAxis2.Enabled = true;
        //                        this.radioBtnAxis3.Enabled = true;
        //                        this.radioBtnAxis4.Enabled = true;
        //                        this.radioBtnAxis5.Enabled = true;
        //                        this.radioBtnAxis6.Enabled = true;
        //                        this.radioBtnAxis7.Enabled = true;
        //                        this.radioBtnAxis8.Enabled = false;

        //                        this.radioBtnAxis8.Checked = false;
        //                        break;
        //                    case 8:
        //                        BtnMoveToCCW.Enabled = true;
        //                        btn_MoveToCW.Enabled = true;
        //                        btnALLAxisGoHome.Enabled = true;
        //                        btnAxisGoHome.Enabled = true;
        //                        this.radioBtnAxis1.Enabled = true;
        //                        this.radioBtnAxis2.Enabled = true;
        //                        this.radioBtnAxis3.Enabled = true;
        //                        this.radioBtnAxis4.Enabled = true;
        //                        this.radioBtnAxis5.Enabled = true;
        //                        this.radioBtnAxis6.Enabled = true;
        //                        this.radioBtnAxis7.Enabled = true;
        //                        this.radioBtnAxis8.Enabled = true;
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //        }
        //        #region 针对一个板卡的版本，已废弃
        //        //if (Properties.Settings.Default.iAxisCount == 0)
        //        //{
        //        //    label4.Text = "";
        //        //    BtnMoveToCCW.Enabled = false;
        //        //    btn_MoveToCW.Enabled = false;
        //        //    btnALLAxisGoHome.Enabled = false;
        //        //    btnAxisGoHome.Enabled = false;
        //        //    this.radioBtnAxis1.Enabled = false;
        //        //    this.radioBtnAxis2.Enabled = false;
        //        //    this.radioBtnAxis3.Enabled = false;
        //        //    this.radioBtnAxis4.Enabled = false;
        //        //    this.radioBtnAxis5.Enabled = false;
        //        //    this.radioBtnAxis6.Enabled = false;
        //        //    this.radioBtnAxis7.Enabled = false;
        //        //    this.radioBtnAxis8.Enabled = false;

        //        //    this.radioBtnAxis1.Checked = false;
        //        //    this.radioBtnAxis2.Checked = false;
        //        //    this.radioBtnAxis3.Checked = false;
        //        //    this.radioBtnAxis4.Checked = false;
        //        //    this.radioBtnAxis5.Checked = false;
        //        //    this.radioBtnAxis6.Checked = false;
        //        //    this.radioBtnAxis7.Checked = false;
        //        //    this.radioBtnAxis8.Checked = false;
        //        //}
        //        //else if (Properties.Settings.Default.iAxisCount == 1)
        //        //{
        //        //    BtnMoveToCCW.Enabled = true;
        //        //    btn_MoveToCW.Enabled = true;
        //        //    btnALLAxisGoHome.Enabled = true;
        //        //    btnAxisGoHome.Enabled = true;
        //        //    this.radioBtnAxis1.Enabled = true;
        //        //    this.radioBtnAxis2.Enabled = false;
        //        //    this.radioBtnAxis3.Enabled = false;
        //        //    this.radioBtnAxis4.Enabled = false;
        //        //    this.radioBtnAxis5.Enabled = false;
        //        //    this.radioBtnAxis6.Enabled = false;
        //        //    this.radioBtnAxis7.Enabled = false;
        //        //    this.radioBtnAxis8.Enabled = false;

        //        //    this.radioBtnAxis2.Checked = false;
        //        //    this.radioBtnAxis3.Checked = false;
        //        //    this.radioBtnAxis4.Checked = false;
        //        //    this.radioBtnAxis5.Checked = false;
        //        //    this.radioBtnAxis6.Checked = false;
        //        //    this.radioBtnAxis7.Checked = false;
        //        //    this.radioBtnAxis8.Checked = false;
        //        //}
        //        //else if (Properties.Settings.Default.iAxisCount == 2)
        //        //{
        //        //    BtnMoveToCCW.Enabled = true;
        //        //    btn_MoveToCW.Enabled = true;
        //        //    btnALLAxisGoHome.Enabled = true;
        //        //    btnAxisGoHome.Enabled = true;
        //        //    this.radioBtnAxis1.Enabled = true;
        //        //    this.radioBtnAxis2.Enabled = true;
        //        //    this.radioBtnAxis3.Enabled = false;
        //        //    this.radioBtnAxis4.Enabled = false;
        //        //    this.radioBtnAxis5.Enabled = false;
        //        //    this.radioBtnAxis6.Enabled = false;
        //        //    this.radioBtnAxis7.Enabled = false;
        //        //    this.radioBtnAxis8.Enabled = false;

        //        //    this.radioBtnAxis3.Checked = false;
        //        //    this.radioBtnAxis4.Checked = false;
        //        //    this.radioBtnAxis5.Checked = false;
        //        //    this.radioBtnAxis6.Checked = false;
        //        //    this.radioBtnAxis7.Checked = false;
        //        //    this.radioBtnAxis8.Checked = false;
        //        //}
        //        //else if (Properties.Settings.Default.iAxisCount == 3)
        //        //{
        //        //    BtnMoveToCCW.Enabled = true;
        //        //    btn_MoveToCW.Enabled = true;
        //        //    btnALLAxisGoHome.Enabled = true;
        //        //    btnAxisGoHome.Enabled = true;
        //        //    this.radioBtnAxis1.Enabled = true;
        //        //    this.radioBtnAxis2.Enabled = true;
        //        //    this.radioBtnAxis3.Enabled = true;
        //        //    this.radioBtnAxis4.Enabled = false;
        //        //    this.radioBtnAxis5.Enabled = false;
        //        //    this.radioBtnAxis6.Enabled = false;
        //        //    this.radioBtnAxis7.Enabled = false;
        //        //    this.radioBtnAxis8.Enabled = false;

        //        //    this.radioBtnAxis4.Checked = false;
        //        //    this.radioBtnAxis5.Checked = false;
        //        //    this.radioBtnAxis6.Checked = false;
        //        //    this.radioBtnAxis7.Checked = false;
        //        //    this.radioBtnAxis8.Checked = false;
        //        //}
        //        //else if (Properties.Settings.Default.iAxisCount == 4)
        //        //{
        //        //    BtnMoveToCCW.Enabled = true;
        //        //    btn_MoveToCW.Enabled = true;
        //        //    btnALLAxisGoHome.Enabled = true;
        //        //    btnAxisGoHome.Enabled = true;
        //        //    this.radioBtnAxis1.Enabled = true;
        //        //    this.radioBtnAxis2.Enabled = true;
        //        //    this.radioBtnAxis3.Enabled = true;
        //        //    this.radioBtnAxis4.Enabled = true;
        //        //    this.radioBtnAxis5.Enabled = false;
        //        //    this.radioBtnAxis6.Enabled = false;
        //        //    this.radioBtnAxis7.Enabled = false;
        //        //    this.radioBtnAxis8.Enabled = false;

        //        //    this.radioBtnAxis5.Checked = false;
        //        //    this.radioBtnAxis6.Checked = false;
        //        //    this.radioBtnAxis7.Checked = false;
        //        //    this.radioBtnAxis8.Checked = false;
        //        //}
        //        //else if (Properties.Settings.Default.iAxisCount == 5)
        //        //{
        //        //    BtnMoveToCCW.Enabled = true;
        //        //    btn_MoveToCW.Enabled = true;
        //        //    btnALLAxisGoHome.Enabled = true;
        //        //    btnAxisGoHome.Enabled = true;
        //        //    this.radioBtnAxis1.Enabled = true;
        //        //    this.radioBtnAxis2.Enabled = true;
        //        //    this.radioBtnAxis3.Enabled = true;
        //        //    this.radioBtnAxis4.Enabled = true;
        //        //    this.radioBtnAxis5.Enabled = true;
        //        //    this.radioBtnAxis6.Enabled = false;
        //        //    this.radioBtnAxis7.Enabled = false;
        //        //    this.radioBtnAxis8.Enabled = false;

        //        //    this.radioBtnAxis6.Checked = false;
        //        //    this.radioBtnAxis7.Checked = false;
        //        //    this.radioBtnAxis8.Checked = false;
        //        //}
        //        //else if (Properties.Settings.Default.iAxisCount == 6)
        //        //{
        //        //    BtnMoveToCCW.Enabled = true;
        //        //    btn_MoveToCW.Enabled = true;
        //        //    btnALLAxisGoHome.Enabled = true;
        //        //    btnAxisGoHome.Enabled = true;
        //        //    this.radioBtnAxis1.Enabled = true;
        //        //    this.radioBtnAxis2.Enabled = true;
        //        //    this.radioBtnAxis3.Enabled = true;
        //        //    this.radioBtnAxis4.Enabled = true;
        //        //    this.radioBtnAxis5.Enabled = true;
        //        //    this.radioBtnAxis6.Enabled = true;
        //        //    this.radioBtnAxis7.Enabled = false;
        //        //    this.radioBtnAxis8.Enabled = false;

        //        //    this.radioBtnAxis7.Checked = false;
        //        //    this.radioBtnAxis8.Checked = false;
        //        //}
        //        //else if (Properties.Settings.Default.iAxisCount == 7)
        //        //{
        //        //    BtnMoveToCCW.Enabled = true;
        //        //    btn_MoveToCW.Enabled = true;
        //        //    btnALLAxisGoHome.Enabled = true;
        //        //    btnAxisGoHome.Enabled = true;
        //        //    this.radioBtnAxis1.Enabled = true;
        //        //    this.radioBtnAxis2.Enabled = true;
        //        //    this.radioBtnAxis3.Enabled = true;
        //        //    this.radioBtnAxis4.Enabled = true;
        //        //    this.radioBtnAxis5.Enabled = true;
        //        //    this.radioBtnAxis6.Enabled = true;
        //        //    this.radioBtnAxis7.Enabled = true;
        //        //    this.radioBtnAxis8.Enabled = false;

        //        //    this.radioBtnAxis8.Checked = false;
        //        //}
        //        //else if (Properties.Settings.Default.iAxisCount == 8)
        //        //{
        //        //    BtnMoveToCCW.Enabled = true;
        //        //    btn_MoveToCW.Enabled = true;
        //        //    btnALLAxisGoHome.Enabled = true;
        //        //    btnAxisGoHome.Enabled = true;
        //        //    this.radioBtnAxis1.Enabled = true;
        //        //    this.radioBtnAxis2.Enabled = true;
        //        //    this.radioBtnAxis3.Enabled = true;
        //        //    this.radioBtnAxis4.Enabled = true;
        //        //    this.radioBtnAxis5.Enabled = true;
        //        //    this.radioBtnAxis6.Enabled = true;
        //        //    this.radioBtnAxis7.Enabled = true;
        //        //    this.radioBtnAxis8.Enabled = true;
        //        //}
        //        #endregion
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
        private void timer1_Tick(object sender, EventArgs e)
        {
            //InitRadioBtnAxis();//根据轴的数量和卡的数量初始化轴
            //SelectRadioButton();//选择轴
        }
        /// <summary>
        /// 选择运动方式是点位运动还是连续运动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMoveDis_SelectedIndexChanged(object sender, EventArgs e)
        {
            dAxisSpeed = Convert.ToDouble(comboBoxMoveDis.Text);
        }

        /// <summary>
        /// 选择运动方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxMoveMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.sAxisMoveStyle = comboBoxMoveMode.Text;
            Properties.Settings.Default.Save();
        }
        #region 选择轴的RadioBtn事件
        //private void SelectRadioButton()
        //{
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List0 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List1 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List2 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List3 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List4 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List5 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List6 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List7 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List8 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List9 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List10 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List11= new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List12= new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List13 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List14 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List15 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List16 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List17 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List18 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List19 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List20 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List21 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List22 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List23 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List24 = new List<Aisx_Hard_Date>();
        //    List<Aisx_Hard_Date> mAisx_Hard_Date_List25 = new List<Aisx_Hard_Date>();
        //    foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List)
        //    {
        //        switch (item.m_CardNo)
        //        {
        //            case 0:
        //                mAisx_Hard_Date_List0.Add(item);
        //                break;
        //            case 1:
        //                mAisx_Hard_Date_List1.Add(item);
        //                break;
        //            case 2:
        //                mAisx_Hard_Date_List2.Add(item);
        //                break;
        //            case 3:
        //                mAisx_Hard_Date_List3.Add(item);
        //                break;
        //            case 4:
        //                mAisx_Hard_Date_List4.Add(item);
        //                break;
        //            case 5:
        //                mAisx_Hard_Date_List5.Add(item);
        //                break;
        //            case 6:
        //                mAisx_Hard_Date_List6.Add(item);
        //                break;
        //            case 7:
        //                mAisx_Hard_Date_List7.Add(item);
        //                break;
        //            case 8:
        //                mAisx_Hard_Date_List8.Add(item);
        //                break;
        //            case 9:
        //                mAisx_Hard_Date_List9.Add(item);
        //                break;
        //            case 10:
        //                mAisx_Hard_Date_List10.Add(item);
        //                break;
        //            case 11:
        //                mAisx_Hard_Date_List11.Add(item);
        //                break;
        //            case 12:
        //                mAisx_Hard_Date_List12.Add(item);
        //                break;
        //            case 13:
        //                mAisx_Hard_Date_List13.Add(item);
        //                break;
        //            case 14:
        //                mAisx_Hard_Date_List14.Add(item);
        //                break;
        //            case 15:
        //                mAisx_Hard_Date_List15.Add(item);
        //                break;
        //            case 16:
        //                mAisx_Hard_Date_List16.Add(item);
        //                break;
        //            case 17:
        //                mAisx_Hard_Date_List17.Add(item);
        //                break;
        //            case 18:
        //                mAisx_Hard_Date_List18.Add(item);
        //                break;
        //            case 19:
        //                mAisx_Hard_Date_List19.Add(item);
        //                break;
        //            case 20:
        //                mAisx_Hard_Date_List20.Add(item);
        //                break;
        //            case 21:
        //                mAisx_Hard_Date_List21.Add(item);
        //                break;
        //            case 22:
        //                mAisx_Hard_Date_List22.Add(item);
        //                break;
        //            case 23:
        //                mAisx_Hard_Date_List23.Add(item);
        //                break;
        //            case 24:
        //                mAisx_Hard_Date_List24.Add(item);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    switch (cbo_SelectHardware.SelectedIndex)
        //    {
        //        case 0:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 1:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List1[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 2:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List2[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 3:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List3[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 4:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List4[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 5:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List5[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List5[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List5[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List5[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List5[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List5[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List5[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List5[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 6:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List6[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List6[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List6[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List6[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List6[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List6[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List6[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List6[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 7:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 8:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 9:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 10:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 11:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 12:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 13:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 14:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 15:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 16:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 17:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 18:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 19:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 20:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 21:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 22:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 23:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;
        //        case 24:
        //            if (radioBtnAxis1.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[0].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis2.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[1].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis3.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[2].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis4.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[3].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis5.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[4].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis6.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[5].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis7.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[6].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List7[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis8.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[7].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis9.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[8].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis10.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[9].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis11.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[10].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis12.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[11].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis13.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[12].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis14.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[13].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis15.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[14].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis16.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[15].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis17.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[16].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis18.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[17].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis19.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[18].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis20.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[19].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis21.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[20].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis22.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[21].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis23.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[22].Axis_hardwareName;
        //            }
        //            else if (radioBtnAxis24.Checked)
        //            {
        //                label4.Text = mAisx_Hard_Date_List0[23].Axis_hardwareName;
        //            }
        //            else
        //            {

        //            }
        //            break;

        //        default:
        //            break;
        //    }
           
        //    //foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List)
        //    //{
        //    //    if (item.m_CardNo == 0)//第一张卡
        //    //    {
        //    //        mAisx_Hard_Date_List0.Add(item);
        //    //        //i++;

        //    //    }
        //    //    else if (item.m_CardNo == 1)//第二张卡
        //    //    {
        //    //        //j++;
        //    //        if (radioBtnAxis1.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis2.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis3.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis4.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis5.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis6.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis7.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis8.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else
        //    //        {

        //    //        }
        //    //    }
        //    //    else if (item.m_CardNo == 2)//第三张卡
        //    //    {
        //    //        //m++;
        //    //        if (radioBtnAxis1.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis2.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis3.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis4.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis5.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis6.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis7.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else if (radioBtnAxis8.Checked)
        //    //        {
        //    //            label4.Text = item.Axis_hardwareName;
        //    //        }
        //    //        else
        //    //        {

        //    //        }
        //    //    }
        //    //    else
        //    //    {

        //    //    }

        //}
        //private void radioBtnAxis1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioBtnAxis1.Checked)
        //    {
        //          //  label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[0].Axis_hardwareName.ToString();
        //        //timer1.Enabled = true;
        //    }
            

        //}
        //private void radioBtnAxis2_CheckedChanged(object sender, EventArgs e)
        //{
            
        //    if (radioBtnAxis2.Checked)
        //    {
        //        //timer1.Enabled = true;
        //        //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[1].Axis_hardwareName.ToString();
        //        //}
        //        //if (cbo_SelectHardware.SelectedIndex == 0)
        //        //{
        //        //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[1].Axis_hardwareName.ToString();
        //        //}
        //        //else
        //        //{
        //        //    int a = 0;
        //        //    for (int i = 0; i < cbo_SelectHardware.SelectedIndex; i++)
        //        //    {
        //        //        a += Program.iarryCardNum[i];
        //        //    }
        //        //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[1 + a].Axis_hardwareName.ToString();
        //        }
        //    }
        //private void radioBtnAxis3_CheckedChanged(object sender, EventArgs e)
        //{
            
        //    if (radioBtnAxis3.Checked)
        //    {
        //        //timer1.Enabled = true;
        //        //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[2].Axis_hardwareName.ToString();
        //        //}
        //        //if (cbo_SelectHardware.SelectedIndex == 0)
        //        //{
        //        //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[2].Axis_hardwareName.ToString();
        //        //}
        //        //else
        //        //{
        //        //    int a = 0;
        //        //    for (int i = 0; i < cbo_SelectHardware.SelectedIndex; i++)
        //        //    {
        //        //        a += Program.iarryCardNum[i];
        //        //    }
        //        //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[2 + a].Axis_hardwareName.ToString();
        //        }
        //    }

        //private void radioBtnAxis4_CheckedChanged(object sender, EventArgs e)
        //{
        //    timer1.Enabled = true;
        //    //if (radioBtnAxis4.Checked)
        //    //{
        //    //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[3].Axis_hardwareName.ToString();
        //    //}
        //    //if (cbo_SelectHardware.SelectedIndex == 0)
        //    //{
        //    //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[3].Axis_hardwareName.ToString();
        //    //}
        //    //else
        //    //{
        //    //    int a = 0;
        //    //    for (int i = 0; i < cbo_SelectHardware.SelectedIndex; i++)
        //    //    {
        //    //        a += Program.iarryCardNum[i];
        //    //    }
        //    //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[3 + a].Axis_hardwareName.ToString();
        //    //}
        //}

        //private void radioBtnAxis5_CheckedChanged(object sender, EventArgs e)
        //{
        //    timer1.Enabled = true;
        //    //if (radioBtnAxis5.Checked)
        //    //{
        //    //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[4].Axis_hardwareName.ToString();
        //    //}
        //    //if (cbo_SelectHardware.SelectedIndex == 0)
        //    //{
        //    //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[4].Axis_hardwareName.ToString();
        //    //}
        //    //else
        //    //{
        //    //    int a = 0;
        //    //    for (int i = 0; i < cbo_SelectHardware.SelectedIndex; i++)
        //    //    {
        //    //        a += Program.iarryCardNum[i];
        //    //    }
        //    //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[4 + a].Axis_hardwareName.ToString();
        //    //}
        //}

        //private void radioBtnAxis6_CheckedChanged(object sender, EventArgs e)
        //{
        //    timer1.Enabled = true;
        //    //if (radioBtnAxis6.Checked)
        //    //{
        //    //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[5].Axis_hardwareName.ToString();
        //    //}
        //    //    if (cbo_SelectHardware.SelectedIndex == 0)
        //    //    {
        //    //        foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List)
        //    //        {
        //    //            if(item.m_CardNo == cbo_SelectHardware.SelectedIndex)
        //    //            {

        //    //            }
        //    //        }
        //    //        label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[5].Axis_hardwareName.ToString();
        //    //    }
        //    //    else
        //    //    {
        //    //        int a = 0;
        //    //        for (int i = 0; i < cbo_SelectHardware.SelectedIndex; i++)
        //    //        {
        //    //            a += Program.iarryCardNum[i];
        //    //        }
        //    //        label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[5 + a].Axis_hardwareName.ToString();
        //    //    }
        //}

        //private void radioBtnAxis7_CheckedChanged(object sender, EventArgs e)
        //{
        //    timer1.Enabled = true;
        //    //if (radioBtnAxis7.Checked)
        //    //{
        //    //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[6].Axis_hardwareN
        //    //if (cbo_SelectHardware.SelectedIndex == 0)
        //    //{
        //    //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[6].Axis_hardwareName.ToString();
        //    //}
        //    //else
        //    //{
        //    //    int a = 0;
        //    //    for (int i = 0; i < cbo_SelectHardware.SelectedIndex; i++)
        //    //    {
        //    //        a += Program.iarryCardNum[i];
        //    //    }
        //    //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[6 + a].Axis_hardwareName.ToString();
        //    //}
        //}

        //private void radioBtnAxis8_CheckedChanged(object sender, EventArgs e)
        //{
        //    timer1.Enabled = true;
        //    //if (radioBtnAxis8.Checked)
        //    //{
        //    //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[7].Axis_hardwareName.ToString();
        //    //}
        //    //if (cbo_SelectHardware.SelectedIndex == 0)
        //    //{
        //    //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[7].Axis_hardwareName.ToString();
        //    //}
        //    //else
        //    //{
        //    //    int a = 0;
        //    //    for (int i = 0; i < cbo_SelectHardware.SelectedIndex; i++)
        //    //    {
        //    //        a += Program.iarryCardNum[i];
        //    //    }
        //    //    label4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[7 + a].Axis_hardwareName.ToString();
        //    //}
        //}
        #endregion
        /// <summary>
        /// 单轴回原点按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAxisGoHome_Click(object sender, EventArgs e)
        {
            if (Program.bAuto)
                return;
            //if (label4.Text=="上料X轴")
            //{
            //    Googol_Contral.SetOutBit("上料升降气缸", false);
            //}
            //else if(label4.Text == "中转搬运Y")
            //{
            //    Googol_Contral.SetOutBit("中转搬运升降气缸", false);
            //}
            //else if (label4.Text == "下料X轴")
            //{
            //    Googol_Contral.GO_Home("下料Z1");
            //    Googol_Contral.GO_Home("下料Z2");
            //}
            ManageContral.GO_Home(label4.Text);
            //调用回原点的方法
        }
        /// <summary>
        /// 所有轴回原点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnALLAxisGoHome_Click(object sender, EventArgs e)
        {
            if (Program.bAuto)
                return;
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                //Googol_Contral.GO_Home(item.Value.Axis_hardwareName);
            }
           
            //所有轴回原点的流程
        }
        #region 窗体移动代码
        private Point mPoint;
        private void DebugForm_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void DebugForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        #endregion
        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// 鼠标摁下调用向负限位运动的函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMoveToCCW_MouseDown(object sender, MouseEventArgs e)
        {
            if (FormStart.startHoming)
            {
                return;
            }
            //调用点位运动的方法
            if (comboBoxMoveMode.Text == "点位运动")
            {
                ManageContral.AxisPrfTrapRel(label4.Text, -Convert.ToDouble(comboBoxMoveDis.Text));

            }
            else if (comboBoxMoveMode.Text == "连续运动")//调用连续运动的方法
            {
                ManageContral.AxisPrfJog(label4.Text, false);
            }
        }
        /// <summary>
        /// 鼠标放开向负限位的连续运动停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMoveToCCW_MouseUp(object sender, MouseEventArgs e)
        {
            if (FormStart.startHoming)
            {
                return;
            }
            if (comboBoxMoveMode.Text == "连续运动")
            {
                ManageContral.StopAxis(label4.Text);
            }
        }
        /// <summary>
        /// 鼠标摁下调用向正限位运动的函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MoveToCW_MouseDown(object sender, MouseEventArgs e)
        {
            if (FormStart.startHoming)
            {
                return;
            }
            //调用点位运动的方法
            if (comboBoxMoveMode.Text == "点位运动")
            {
                ManageContral.AxisPrfTrapRel(label4.Text, Convert.ToDouble(comboBoxMoveDis.Text));
             
            }
            else if (comboBoxMoveMode.Text == "连续运动")//调用连续运动的方法
            {
                ManageContral.AxisPrfJog(label4.Text, true);
            }
        }
        /// <summary>
        /// 鼠标放开向正限位的连续运动停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MoveToCW_MouseUp(object sender, MouseEventArgs e)
        {

            if (FormStart.startHoming)
            {
                return;
            }
            if (comboBoxMoveMode.Text == "连续运动")
            {
                ManageContral.StopAxis(label4.Text);
            }
           
        }

       

        private void btn_MoveToCW_Click(object sender, EventArgs e)
        {

        }

        private void AsixName_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text= AsixName.Text;
        }
    }
}
