using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public partial class AxisStateViewForm : Form
    {
        public AxisStateViewForm()
        {
            InitializeComponent();
        }
        public static List<Aisx_Hard_Date> mAisx_Hard_Date_List0 = new List<Aisx_Hard_Date>();
        List<Aisx_Hard_Date> mAisx_Hard_Date_List1 = new List<Aisx_Hard_Date>();
        List<Aisx_Hard_Date> mAisx_Hard_Date_List2 = new List<Aisx_Hard_Date>();
        List<Aisx_Hard_Date> mAisx_Hard_Date_List3 = new List<Aisx_Hard_Date>();
        List<Aisx_Hard_Date> mAisx_Hard_Date_List4 = new List<Aisx_Hard_Date>();
        List<Aisx_Hard_Date> mAisx_Hard_Date_List5 = new List<Aisx_Hard_Date>();
        List<Aisx_Hard_Date> mAisx_Hard_Date_List6 = new List<Aisx_Hard_Date>();
        List<Aisx_Hard_Date> mAisx_Hard_Date_List7 = new List<Aisx_Hard_Date>();

        List<_Aisx_Hard_Date> _mAisx_Hard_Date_List = new List<_Aisx_Hard_Date>();
        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AxisStateViewForm_Load(object sender, EventArgs e)
        {
            base.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - base.Width, Screen.PrimaryScreen.WorkingArea.Height - base.Height - 126);
            //ShowForm();
            if (_mAisx_Hard_Date_List.Count > 0)
            {

            }
            else
            {
                for (int i = 0; i < Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List.Count; i++)
                {
                    _Aisx_Hard_Date _Aisx_Hard_Date = new _Aisx_Hard_Date();
                    _Aisx_Hard_Date.Axis_hardwareName = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].Axis_hardwareName;
                    _Aisx_Hard_Date.bAlarm = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].bAlarm;
                    _Aisx_Hard_Date.AisxCurrentPosition = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].AisxCurrentPosition;
                    _Aisx_Hard_Date.bCCWL = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].bCCWL;
                    _Aisx_Hard_Date.bCWL = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].bCWL;
                    _Aisx_Hard_Date.bMovSta = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].bMovSta;
                    _Aisx_Hard_Date.bOrg = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].bMovSta;
                    _Aisx_Hard_Date.dCurrentVel = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].dCurrentVel;
                    _Aisx_Hard_Date.Move_Done = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].Move_Done;
                    _Aisx_Hard_Date.m_AxisNo = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].m_AxisNo;
                    _Aisx_Hard_Date.m_CardNo = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].m_CardNo;
                    _mAisx_Hard_Date_List.Add(_Aisx_Hard_Date);
                }


            }
           
            timerScan.Enabled = true;
        }
        /// <summary>
        /// 根据轴显示窗体的方法
        /// </summary>
        public void ShowForm()
        {



            //try
            //{
            //    //this.Height = 56 + 27 * Properties.Settings.Default.iAxisCount;
                
            //    switch (Properties.Settings.Default.iControlIOCardCount)
            //    {
            //        //case 0:
            //        //    return;
            //        case 1:
            //            this.tabPage1.Show();
            //            this.tabPage2.Parent = null;
            //            this.tabPage3.Parent = null;
            //            this.tabPage4.Parent = null;
            //            this.tabPage5.Parent = null;
            //            this.tabPage6.Parent = null;
            //            this.tabPage7.Parent = null;
            //            this.tabPage8.Parent = null;
            //            break;
            //        case 2:
            //            this.tabPage1.Show();
            //            this.tabPage2.Show();
            //            this.tabPage3.Parent=null;
            //            this.tabPage4.Parent=null;
            //            this.tabPage5.Parent=null;
            //            this.tabPage6.Parent=null;
            //            this.tabPage7.Parent=null;
            //            this.tabPage8.Parent=null;
            //            break;
            //        case 3:
            //            this.tabPage1.Show();
            //            this.tabPage2.Show();
            //            this.tabPage3.Show();
            //            this.tabPage4.Parent=null;
            //            this.tabPage5.Parent=null;
            //            this.tabPage6.Parent=null;
            //            this.tabPage7.Parent=null;
            //            this.tabPage8.Parent=null;
            //            break;
            //        case 4:
            //            this.tabPage1.Show();
            //            this.tabPage2.Show();
            //            this.tabPage3.Show();
            //            this.tabPage4.Show();
            //            this.tabPage5.Parent=null;
            //            this.tabPage6.Parent=null;
            //            this.tabPage7.Parent=null;
            //            this.tabPage8.Parent=null;
            //            break;
            //        case 5:
            //            this.tabPage1.Show();
            //            this.tabPage2.Show();
            //            this.tabPage3.Show();
            //            this.tabPage4.Show();
            //            this.tabPage5.Show();
            //            this.tabPage6.Parent=null;
            //            this.tabPage7.Parent=null;
            //            this.tabPage8.Parent=null;
            //            break;
            //        case 6:
            //            this.tabPage1.Show();
            //            this.tabPage2.Show();
            //            this.tabPage3.Show();
            //            this.tabPage4.Show();
            //            this.tabPage5.Show();
            //            this.tabPage6.Show();
            //            this.tabPage7.Parent = null;
            //            this.tabPage8.Parent = null;
            //            break;
            //        case 7:
            //            this.tabPage1.Show();
            //            this.tabPage2.Show();
            //            this.tabPage3.Show();
            //            this.tabPage4.Show();
            //            this.tabPage5.Show();
            //            this.tabPage6.Show();
            //            this.tabPage7.Show();
            //            this.tabPage8.Parent=null;
            //            break;
            //        case 8:
            //            this.tabPage1.Show();
            //            this.tabPage2.Show();
            //            this.tabPage3.Show();
            //            this.tabPage4.Show();
            //            this.tabPage5.Show();
            //            this.tabPage6.Show();
            //            this.tabPage7.Show();
            //            this.tabPage8.Show();
            //            break;
            //        default:
            //            break;
            //    }
            //    mAisx_Hard_Date_List0.Clear();
            //    mAisx_Hard_Date_List1.Clear();
            //    mAisx_Hard_Date_List2.Clear();
            //    mAisx_Hard_Date_List3.Clear();
            //    mAisx_Hard_Date_List4.Clear();
            //    mAisx_Hard_Date_List5.Clear();
            //    mAisx_Hard_Date_List6.Clear();
            //    mAisx_Hard_Date_List7.Clear();
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
            //            default:
            //                break;
            //        }
            //    }
            //    dataGridViewAxisStatus.Rows.Clear();
            //    for (int i = 0; i < mAisx_Hard_Date_List0.Count; i++)
            //    {
            //        dataGridViewAxisStatus.Rows.Add(new object[] { "", " ", " ", " ", " ", " ", " ", " ", " " });
            //    }
            //    dgvCard2AxisStatus.Rows.Clear();
            //    for (int i = 0; i < mAisx_Hard_Date_List1.Count; i++)
            //    {
            //        dgvCard2AxisStatus.Rows.Add(new object[] { "", " ", " ", " ", " ", " ", " ", " ", " " });
            //    }
            //    dgvCard3AxisStatus.Rows.Clear();
            //    for (int i = 0; i < mAisx_Hard_Date_List2.Count; i++)
            //    {
            //        dgvCard3AxisStatus.Rows.Add(new object[] { "", " ", " ", " ", " ", " ", " ", " ", " " });
            //    }
            //    dgvCard4AxisStatus.Rows.Clear();
            //    for (int i = 0; i < mAisx_Hard_Date_List3.Count; i++)
            //    {
            //        dgvCard4AxisStatus.Rows.Add(new object[] { "", " ", " ", " ", " ", " ", " ", " ", " " });
            //    }
            //    dgvCard5AxisStatus.Rows.Clear();
            //    for (int i = 0; i < mAisx_Hard_Date_List4.Count; i++)
            //    {
            //        dgvCard5AxisStatus.Rows.Add(new object[] { "", " ", " ", " ", " ", " ", " ", " ", " " });
            //    }
            //    dgvCard6AxisStatus.Rows.Clear();
            //    for (int i = 0; i < mAisx_Hard_Date_List5.Count; i++)
            //    {
            //        dgvCard6AxisStatus.Rows.Add(new object[] { "", " ", " ", " ", " ", " ", " ", " ", " " });
            //    }
            //    dgvCard7AxisStatus.Rows.Clear();
            //    for (int i = 0; i < mAisx_Hard_Date_List6.Count; i++)
            //    {
            //        dgvCard7AxisStatus.Rows.Add(new object[] { "", " ", " ", " ", " ", " ", " ", " ", " " });
            //    }
            //    dgvCard8AxisStatus.Rows.Clear();
            //    for (int i = 0; i < mAisx_Hard_Date_List7.Count; i++)
            //    {
            //        dgvCard8AxisStatus.Rows.Add(new object[] { "", " ", " ", " ", " ", " ", " ", " ", " " });
            //    }
            //    //for (int i = 0; i < Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List.Count; i++)
            //    //{
            //    //    dataGridViewAxisStatus.Rows.Add(new object[] { "", " ", " ", " ", " ", " ", " ", " ", " " });
            //    //}
            //}
            //catch (Exception)
            //{
                
            //}
          
        }
        /// <summary>
        /// 更新轴的状态
        /// </summary>
        private void FreshAixsState()
        {
            for (int i = 0; i < _mAisx_Hard_Date_List.Count; i++)
            {
                try
                {
                    //string _name=   _mAisx_Hard_Date_List[i].Axis_hardwareName;
                    _mAisx_Hard_Date_List[i].AisxCurrentPosition = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].AisxCurrentPosition;
                    _mAisx_Hard_Date_List[i].Axis_hardwareName = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].Axis_hardwareName;
                    _mAisx_Hard_Date_List[i].bAlarm = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].bAlarm;
                    //_mAisx_Hard_Date_List[i].AisxCurrentPosition = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].AisxCurrentPosition;
                    _mAisx_Hard_Date_List[i].bCCWL = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].bCCWL;
                    _mAisx_Hard_Date_List[i].bCWL = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].bCWL;
                    _mAisx_Hard_Date_List[i].bMovSta = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].bMovSta;
                    _mAisx_Hard_Date_List[i].bOrg = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].bOrg;
                    _mAisx_Hard_Date_List[i].dCurrentVel = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].dCurrentVel;
                    _mAisx_Hard_Date_List[i].Move_Done = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].Move_Done;
                    _mAisx_Hard_Date_List[i].m_AxisNo = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].m_AxisNo;
                    _mAisx_Hard_Date_List[i].m_CardNo = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List[i].m_CardNo;
                }
                catch 
                {

                    
                }
               
            }

            dataGridViewAxisStatus.DataSource = _mAisx_Hard_Date_List;

            dataGridViewAxisStatus.Refresh();
          
            //while (true)
            //{

            //try
            //{
            //    int Colum_Count1 = 0;
            //    foreach (var item in mAisx_Hard_Date_List0)
            //    {
            //        dataGridViewAxisStatus.Rows[Colum_Count1].Cells[0].Value = item.Axis_hardwareName;
            //        dataGridViewAxisStatus.Rows[Colum_Count1].Cells[1].Value = item.m_AxisNo;
            //        dataGridViewAxisStatus.Rows[Colum_Count1].Cells[2].Style.BackColor = item.bAlarm ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        if (item.bAlarm)
            //        {
            //            MainForm.m_formAlarm.SetMotorAlarm(item.Axis_hardwareName);
            //        }
            //        else
            //        {
            //            MainForm.m_formAlarm.RstMotorAlarm(item.Axis_hardwareName);
            //        }
            //        dataGridViewAxisStatus.Rows[Colum_Count1].Cells[3].Style.BackColor = item.bCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//正
            //        dataGridViewAxisStatus.Rows[Colum_Count1].Cells[4].Style.BackColor = item.bOrg ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dataGridViewAxisStatus.Rows[Colum_Count1].Cells[5].Style.BackColor = item.bCCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dataGridViewAxisStatus.Rows[Colum_Count1].Cells[6].Style.BackColor = item.bMovSta ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//负
            //        dataGridViewAxisStatus.Rows[Colum_Count1].Cells[7].Value = item.AisxCurrentPosition;
            //        Colum_Count1++;
            //    }

            //    int Colum_Count2 = 0;
            //    foreach (var item in mAisx_Hard_Date_List1)
            //    {
            //        dgvCard2AxisStatus.Rows[Colum_Count2].Cells[0].Value = item.Axis_hardwareName;
            //        dgvCard2AxisStatus.Rows[Colum_Count2].Cells[1].Value = item.m_AxisNo;
            //        dgvCard2AxisStatus.Rows[Colum_Count2].Cells[2].Style.BackColor = item.bAlarm ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        if (item.bAlarm)
            //        {
            //            MainForm.m_formAlarm.SetMotorAlarm(item.Axis_hardwareName);
            //        }
            //        else
            //        {
            //            MainForm.m_formAlarm.RstMotorAlarm(item.Axis_hardwareName);
            //        }
            //        dgvCard2AxisStatus.Rows[Colum_Count2].Cells[3].Style.BackColor = item.bCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//正
            //        dgvCard2AxisStatus.Rows[Colum_Count2].Cells[4].Style.BackColor = item.bOrg ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard2AxisStatus.Rows[Colum_Count2].Cells[5].Style.BackColor = item.bCCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard2AxisStatus.Rows[Colum_Count2].Cells[6].Style.BackColor = item.bMovSta ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//负
            //        dgvCard2AxisStatus.Rows[Colum_Count2].Cells[7].Value = item.AisxCurrentPosition;
            //        Colum_Count2++;
            //    }

            //    int Colum_Count3 = 0;
            //    foreach (var item in mAisx_Hard_Date_List2)
            //    {
            //        dgvCard3AxisStatus.Rows[Colum_Count3].Cells[0].Value = item.Axis_hardwareName;
            //        dgvCard3AxisStatus.Rows[Colum_Count3].Cells[1].Value = item.m_AxisNo;
            //        dgvCard3AxisStatus.Rows[Colum_Count3].Cells[2].Style.BackColor = item.bAlarm ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        if (item.bAlarm)
            //        {
            //            MainForm.m_formAlarm.SetMotorAlarm(item.Axis_hardwareName);
            //        }
            //        else
            //        {
            //            MainForm.m_formAlarm.RstMotorAlarm(item.Axis_hardwareName);
            //        }
            //        dgvCard3AxisStatus.Rows[Colum_Count3].Cells[3].Style.BackColor = item.bCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//正
            //        dgvCard3AxisStatus.Rows[Colum_Count3].Cells[4].Style.BackColor = item.bOrg ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard3AxisStatus.Rows[Colum_Count3].Cells[5].Style.BackColor = item.bCCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard3AxisStatus.Rows[Colum_Count3].Cells[6].Style.BackColor = item.bMovSta ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//负
            //        dgvCard3AxisStatus.Rows[Colum_Count3].Cells[7].Value = item.AisxCurrentPosition;
            //        Colum_Count3++;
            //    }

            //    int Colum_Count4 = 0;
            //    foreach (var item in mAisx_Hard_Date_List3)
            //    {
            //        dgvCard4AxisStatus.Rows[Colum_Count4].Cells[0].Value = item.Axis_hardwareName;
            //        dgvCard4AxisStatus.Rows[Colum_Count4].Cells[1].Value = item.m_AxisNo;
            //        dgvCard4AxisStatus.Rows[Colum_Count4].Cells[2].Style.BackColor = item.bAlarm ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        if (item.bAlarm)
            //        {
            //            MainForm.m_formAlarm.SetMotorAlarm(item.Axis_hardwareName);
            //        }
            //        else
            //        {
            //            MainForm.m_formAlarm.RstMotorAlarm(item.Axis_hardwareName);
            //        }
            //        dgvCard4AxisStatus.Rows[Colum_Count4].Cells[3].Style.BackColor = item.bCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//正
            //        dgvCard4AxisStatus.Rows[Colum_Count4].Cells[4].Style.BackColor = item.bOrg ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard4AxisStatus.Rows[Colum_Count4].Cells[5].Style.BackColor = item.bCCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard4AxisStatus.Rows[Colum_Count4].Cells[6].Style.BackColor = item.bMovSta ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//负
            //        dgvCard4AxisStatus.Rows[Colum_Count4].Cells[7].Value = item.AisxCurrentPosition;
            //        Colum_Count4++;
            //    }

            //    int Colum_Count5 = 0;
            //    foreach (var item in mAisx_Hard_Date_List4)
            //    {
            //        dgvCard5AxisStatus.Rows[Colum_Count5].Cells[0].Value = item.Axis_hardwareName;
            //        dgvCard5AxisStatus.Rows[Colum_Count5].Cells[1].Value = item.m_AxisNo;
            //        dgvCard5AxisStatus.Rows[Colum_Count5].Cells[2].Style.BackColor = item.bAlarm ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        if (item.bAlarm)
            //        {
            //            MainForm.m_formAlarm.SetMotorAlarm(item.Axis_hardwareName);
            //        }
            //        else
            //        {
            //            MainForm.m_formAlarm.RstMotorAlarm(item.Axis_hardwareName);
            //        }
            //        dgvCard5AxisStatus.Rows[Colum_Count5].Cells[3].Style.BackColor = item.bCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//正
            //        dgvCard5AxisStatus.Rows[Colum_Count5].Cells[4].Style.BackColor = item.bOrg ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard5AxisStatus.Rows[Colum_Count5].Cells[5].Style.BackColor = item.bCCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard5AxisStatus.Rows[Colum_Count5].Cells[6].Style.BackColor = item.bMovSta ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//负
            //        dgvCard5AxisStatus.Rows[Colum_Count5].Cells[7].Value = item.AisxCurrentPosition;
            //        Colum_Count5++;
            //    }

            //    int Colum_Count6 = 0;
            //    foreach (var item in mAisx_Hard_Date_List5)
            //    {
            //        dgvCard6AxisStatus.Rows[Colum_Count6].Cells[0].Value = item.Axis_hardwareName;
            //        dgvCard6AxisStatus.Rows[Colum_Count6].Cells[1].Value = item.m_AxisNo;
            //        dgvCard6AxisStatus.Rows[Colum_Count6].Cells[2].Style.BackColor = item.bAlarm ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        if (item.bAlarm)
            //        {
            //            MainForm.m_formAlarm.SetMotorAlarm(item.Axis_hardwareName);
            //        }
            //        else
            //        {
            //            MainForm.m_formAlarm.RstMotorAlarm(item.Axis_hardwareName);
            //        }
            //        dgvCard6AxisStatus.Rows[Colum_Count6].Cells[3].Style.BackColor = item.bCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//正
            //        dgvCard6AxisStatus.Rows[Colum_Count6].Cells[4].Style.BackColor = item.bOrg ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard6AxisStatus.Rows[Colum_Count6].Cells[5].Style.BackColor = item.bCCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard6AxisStatus.Rows[Colum_Count6].Cells[6].Style.BackColor = item.bMovSta ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//负
            //        dgvCard6AxisStatus.Rows[Colum_Count6].Cells[7].Value = item.AisxCurrentPosition;
            //        Colum_Count6++;
            //    }

            //    int Colum_Count7 = 0;
            //    foreach (var item in mAisx_Hard_Date_List6)
            //    {
            //        dgvCard8AxisStatus.Rows[Colum_Count7].Cells[0].Value = item.Axis_hardwareName;
            //        dgvCard8AxisStatus.Rows[Colum_Count7].Cells[1].Value = item.m_AxisNo;
            //        dgvCard8AxisStatus.Rows[Colum_Count7].Cells[2].Style.BackColor = item.bAlarm ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        if (item.bAlarm)
            //        {
            //            MainForm.m_formAlarm.SetMotorAlarm(item.Axis_hardwareName);
            //        }
            //        else
            //        {
            //            MainForm.m_formAlarm.RstMotorAlarm(item.Axis_hardwareName);
            //        }
            //        dgvCard8AxisStatus.Rows[Colum_Count7].Cells[3].Style.BackColor = item.bCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//正
            //        dgvCard8AxisStatus.Rows[Colum_Count7].Cells[4].Style.BackColor = item.bOrg ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard8AxisStatus.Rows[Colum_Count7].Cells[5].Style.BackColor = item.bCCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard8AxisStatus.Rows[Colum_Count7].Cells[6].Style.BackColor = item.bMovSta ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//负
            //        dgvCard8AxisStatus.Rows[Colum_Count7].Cells[7].Value = item.AisxCurrentPosition;
            //        Colum_Count7++;
            //    }

            //    int Colum_Count8 = 0;
            //    foreach (var item in mAisx_Hard_Date_List7)
            //    {
            //        dgvCard8AxisStatus.Rows[Colum_Count8].Cells[0].Value = item.Axis_hardwareName;
            //        dgvCard8AxisStatus.Rows[Colum_Count8].Cells[1].Value = item.m_AxisNo;
            //        dgvCard8AxisStatus.Rows[Colum_Count8].Cells[2].Style.BackColor = item.bAlarm ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        if (item.bAlarm)
            //        {
            //            MainForm.m_formAlarm.SetMotorAlarm(item.Axis_hardwareName);
            //        }
            //        else
            //        {
            //            MainForm.m_formAlarm.RstMotorAlarm(item.Axis_hardwareName);
            //        }
            //        dgvCard8AxisStatus.Rows[Colum_Count8].Cells[3].Style.BackColor = item.bCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//正
            //        dgvCard8AxisStatus.Rows[Colum_Count8].Cells[4].Style.BackColor = item.bOrg ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard8AxisStatus.Rows[Colum_Count8].Cells[5].Style.BackColor = item.bCCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //        dgvCard8AxisStatus.Rows[Colum_Count8].Cells[6].Style.BackColor = item.bMovSta ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//负
            //        dgvCard8AxisStatus.Rows[Colum_Count8].Cells[7].Value = item.AisxCurrentPosition;
            //        Colum_Count8++;
            //    }


            //int Colum_Count = 0;
            //foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List)
            //{
            //    dataGridViewAxisStatus.Rows[Colum_Count].Cells[0].Value = item.Axis_hardwareName;
            //    dataGridViewAxisStatus.Rows[Colum_Count].Cells[1].Value = item.m_AxisNo;
            //    dataGridViewAxisStatus.Rows[Colum_Count].Cells[2].Style.BackColor = item.bAlarm ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //    if (item.bAlarm)
            //    {
            //        MainForm.m_formAlarm.SetMotorAlarm(item.Axis_hardwareName);
            //    }
            //    else
            //    {
            //        MainForm.m_formAlarm.RstMotorAlarm(item.Axis_hardwareName);
            //    }
            //    dataGridViewAxisStatus.Rows[Colum_Count].Cells[3].Style.BackColor = item.bCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//正
            //    dataGridViewAxisStatus.Rows[Colum_Count].Cells[4].Style.BackColor = item.bOrg ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //    dataGridViewAxisStatus.Rows[Colum_Count].Cells[5].Style.BackColor = item.bCCWL ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //    dataGridViewAxisStatus.Rows[Colum_Count].Cells[6].Style.BackColor = item.bMovSta ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);//负
            //    dataGridViewAxisStatus.Rows[Colum_Count].Cells[7].Value = item.AisxCurrentPosition;
            //    //dataGridViewAxisStatus.Rows[Colum_Count].Cells[8].Style.BackColor = item.Value.Go_HomeFinishi ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //    //dataGridViewAxisStatus.Rows[Colum_Count].Cells[8].Style.BackColor = item.Value.bFlagServoOn ? System.Drawing.Color.Green : System.Drawing.Color.FromKnownColor(KnownColor.Control);
            //    Colum_Count++;
            //}

            //}
            //catch (Exception ex)
            //{

            //}
            //}
        }
        private void timerScan_Tick(object sender, EventArgs e)
        {
            FreshAixsState();
        }
        private void AxisStateViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerScan.Enabled = false;
        }
        #region 窗体移动代码
        private Point mPoint;
        private void AxisStateViewForm_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void AxisStateViewForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void dataGridViewAxisStatus_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void dataGridViewAxisStatus_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }
        #endregion

        private void tabAxisView_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void tabAxisView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void dgvCard2AxisStatus_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void dgvCard2AxisStatus_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void dgvCard3AxisStatus_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void dgvCard3AxisStatus_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void dgvCard4AxisStatus_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void dgvCard4AxisStatus_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void dgvCard5AxisStatus_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void dgvCard5AxisStatus_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void dgvCard6AxisStatus_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void dgvCard6AxisStatus_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void dgvCard7AxisStatus_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void dgvCard7AxisStatus_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        private void dgvCard8AxisStatus_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void dgvCard8AxisStatus_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
    }
    public class _Aisx_Hard_Date
    {   
        
        /// <summary>
             /// 轴当前位置
             /// </summary>
        public double AisxCurrentPosition { get; set; }//
        public string Axis_hardwareName { get; set; }
        public int m_CardNo { get; set; }
        public int m_AxisNo { get; set; }

        public bool bAlarm { get; set; }

        /// <summary>
        /// 轴原点位状态标志
        /// </summary>
        public bool bOrg { get; set; }
        /// <summary>
        /// 轴正限位报警状态
        /// </summary>
        public bool bCWL { get; set; }
        /// <summary>
        ///    /// <summary>
        /// 轴负限位状态
        /// </summary>
        public bool bCCWL { get; set; }

        /// <summary>
        /// 轴运动状态
        /// </summary>
        public bool bMovSta { get; set; }

        /// <summary>
        /// 当前轴速度
        /// </summary>
        public double dCurrentVel { get; set; }


        /// <summary>
        /// 轴运动到位检测
        /// </summary>
        public bool Move_Done { get; set; }

    }
}
