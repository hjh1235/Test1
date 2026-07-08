using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace UniversalControlSystem
{
    public partial class IODebugForm : Form
    {
        private bool isMouseDown = false;
        private Point FormLocation;     //form的location
        private Point mouseOffset;      //鼠标的按下位置
        public IODebugForm()
        {
            InitializeComponent();
        }
        public List<IOCardSta_InPut> m_Hard_IOInPut_List = new List<IOCardSta_InPut>();
        public List<IOCardSta_OutPut> m_Hard_IOOutPut_List = new List<IOCardSta_OutPut>();
        //Googol_Contral Googol_Contral = new Googol_Contral();
        private string Crontral_IO_Form = "";
        List<Label> lbCard = new List<Label>();
        List<Label> lbModule = new List<Label>();
        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IODebugForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            lbCard.Add(Cade1_Name);
            lbCard.Add(Cade2_Name);
            lbCard.Add(Cade3_Name);
            lbCard.Add(Cade4_Name);
            lbCard.Add(Cade5_Name);
            lbCard.Add(Cade6_Name);
            lbCard.Add(Cade7_Name);
            lbCard.Add(Cade8_Name);
            lbModule.Add(lbModule1);
            lbModule.Add(lbModule2);
            lbModule.Add(lbModule3);
            lbModule.Add(lbModule4);
            lbModule.Add(lbModule5);
            lbModule.Add(lbModule6);
            lbModule.Add(lbModule7);
            lbModule.Add(lbModule8);
            int LbCardCount = 0;
            int LbModuleCount = 0;
            foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareList)
            {
                if (item.m_strHardWare_Modle == "卡硬件")
                {
                    lbCard[LbCardCount].Text = item.hardwareName;
                    LbCardCount++;
                }
                else
                {
                    lbModule[LbModuleCount].Text = item.hardwareName;
                    LbModuleCount++;
                }
            }
            //if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary.Count > 0)
            //{
            //有卡才会显示，不需要进行初始化判断
            板卡IO1_Click(sender, e);
            板卡IO1.BackColor = Color.Green;

            InitViewNoButton();
            //}

        }
        /// <summary>
        /// 初始化界面没有button
        /// </summary>
        private void InitViewNoButton()
        {
            this.板卡IO1.Visible = false;
            this.板卡IO2.Visible = false;
            this.板卡IO3.Visible = false;
            this.板卡IO4.Visible = false;
            this.板卡IO5.Visible = false;
            this.板卡IO6.Visible = false;
            this.板卡IO7.Visible = false;
            this.板卡IO8.Visible = false;

            Cade1_Name.Visible = false;
            Cade2_Name.Visible = false;
            Cade3_Name.Visible = false;
            Cade4_Name.Visible = false;
            Cade5_Name.Visible = false;
            Cade6_Name.Visible = false;
            Cade7_Name.Visible = false;
            Cade8_Name.Visible = false;

            this.模块1.Visible = false;
            this.模块2.Visible = false;
            this.模块3.Visible = false;
            this.模块4.Visible = false;
            this.模块5.Visible = false;
            this.模块6.Visible = false;
            this.模块7.Visible = false;
            this.模块8.Visible = false;

            lbModule1.Visible = false;
            lbModule2.Visible = false;
            lbModule3.Visible = false;
            lbModule4.Visible = false;
            lbModule5.Visible = false;
            lbModule6.Visible = false;
            lbModule7.Visible = false;
            lbModule8.Visible = false;
        }
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            板卡IO1_Click(sender, e);
            板卡IO1.BackColor = Color.Green;
        }
        /// <summary>
        /// 初始化IO输入的方法
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        private void initIntputDgv(DataGridView dgv)
        {
            dgv.Columns[2].HeaderText = "IO名称";
            dgv.Columns[3].HeaderText = "屏蔽";
            dgv.Columns[4].Visible = false;
            dgv.Columns[5].Visible = false;
            dgv.Columns[6].Visible = false;
            dgv.Columns[7].Visible = false;
            dgv.Columns[8].Visible = false;
            for (byte i = 0; i < dgv.Columns.Count; i++)
            {
                if (i == 0)
                {
                    dgv.Columns[i].Width = 60;
                }
                else if (i == 1)
                {
                    dgv.Columns[i].Width = 100;
                }
                else if (i == 2)
                {
                    dgv.Columns[i].Width = 150;
                }
                else
                {
                    dgv.Columns[i].Width = 80;
                }
                if (i == 3)
                {
                    dgv.Columns[i].ReadOnly = false;
                }
                else
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                //dgv.Columns[i].SortMode = 0;
            }
            for (byte i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Height = 24;
            }
            dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvData.RowsDefaultCellStyle
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        /// <summary>
        /// 初始化IO输出的方法
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        private void initOutputDgv(DataGridView dgv)
        {
            //dgv.Columns.Clear();
            dgv.Columns[4].HeaderText = "IO名称";
            dgv.Columns[5].HeaderText = "屏蔽";
            dgv.Columns[6].Visible = false;
            dgv.Columns[7].Visible = false;
            dgv.Columns[8].Visible = false;
            dgv.Columns[9].Visible = false;
            dgv.Columns[10].Visible = false;
            for (byte i = 0; i < dgv.Columns.Count; i++)
            {
                if (i == 0)
                {
                    dgv.Columns[i].Width = 60;
                }
                else if (i == 1)
                {
                    dgv.Columns[i].Width = 75;
                }
                else if (i == 4)
                {
                    dgv.Columns[i].Width = 120;
                }
                else
                {
                    dgv.Columns[i].Width = 50;
                }
                if (i == 1 || i == 2 || i == 5)
                {
                    dgv.Columns[i].ReadOnly = false;
                }
                else
                {
                    dgv.Columns[i].ReadOnly = true;
                }
                //dgv.Columns[i].SortMode = 0;
            }
            for (byte i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Height = 24;
            }
            dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvData.RowsDefaultCellStyle
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #region IO卡按钮单击事件
        private void 模块1_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.Green;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.DeepSkyBlue;
            模块8.BackColor = Color.DeepSkyBlue;

            Crontral_IO_Form = lbModule1.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                        throw;
                    }


                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                //dataGridViewInput.Rows.Clear();
                //dataGridViewOutput.Rows.Clear();
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                //dataGridViewInput.Columns[0].ReadOnly = true;
                //dataGridViewInput.Columns[1].ReadOnly = true;
                //dataGridViewInput.Columns[2].ReadOnly = true;
                //dataGridViewInput.Columns[3].ReadOnly = true;
                //dataGridViewInput.Columns[4].ReadOnly = true;
                //dataGridViewInput.Columns[5].ReadOnly = true;
                //dataGridViewOutput.Columns[0].ReadOnly = true;
                //dataGridViewOutput.Columns[1].ReadOnly = true;
                //dataGridViewOutput.Columns[4].ReadOnly = true;
                //dataGridViewOutput.Columns[5].ReadOnly = true;
            }

        }

        private void 模块2_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.Green;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.DeepSkyBlue;
            模块8.BackColor = Color.DeepSkyBlue;

            Crontral_IO_Form = lbModule2.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                        throw;
                    }


                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                //dataGridViewInput.Columns[0].ReadOnly = true;
                //dataGridViewInput.Columns[1].ReadOnly = true;
                //dataGridViewInput.Columns[2].ReadOnly = true;
                //dataGridViewInput.Columns[3].ReadOnly = true;
                //dataGridViewInput.Columns[4].ReadOnly = true;
                //dataGridViewInput.Columns[5].ReadOnly = true;
                //dataGridViewOutput.Columns[0].ReadOnly = true;
                //dataGridViewOutput.Columns[1].ReadOnly = true;
                //dataGridViewOutput.Columns[4].ReadOnly = true;
                //dataGridViewOutput.Columns[5].ReadOnly = true;
            }

        }

        private void 模块3_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.Green;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.DeepSkyBlue;
            模块8.BackColor = Color.DeepSkyBlue;

            Crontral_IO_Form = lbModule3.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                        throw;
                    }


                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                //dataGridViewInput.Columns[0].ReadOnly = true;
                //dataGridViewInput.Columns[1].ReadOnly = true;
                //dataGridViewInput.Columns[2].ReadOnly = true;
                //dataGridViewInput.Columns[3].ReadOnly = true;
                //dataGridViewInput.Columns[4].ReadOnly = true;
                //dataGridViewInput.Columns[5].ReadOnly = true;
                //dataGridViewOutput.Columns[0].ReadOnly = true;
                //dataGridViewOutput.Columns[1].ReadOnly = true;
                //dataGridViewOutput.Columns[4].ReadOnly = true;
                //dataGridViewOutput.Columns[5].ReadOnly = true;
            }

        }

        private void 模块4_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.Green;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.DeepSkyBlue;
            模块8.BackColor = Color.DeepSkyBlue;

            Crontral_IO_Form = lbModule4.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                        throw;
                    }


                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                //dataGridViewInput.Columns[0].ReadOnly = true;
                //dataGridViewInput.Columns[1].ReadOnly = true;
                //dataGridViewInput.Columns[2].ReadOnly = true;
                //dataGridViewInput.Columns[3].ReadOnly = true;
                //dataGridViewInput.Columns[4].ReadOnly = true;
                //dataGridViewInput.Columns[5].ReadOnly = true;
                //dataGridViewOutput.Columns[0].ReadOnly = true;
                //dataGridViewOutput.Columns[1].ReadOnly = true;
                //dataGridViewOutput.Columns[4].ReadOnly = true;
                //dataGridViewOutput.Columns[5].ReadOnly = true;
            }

        }

        private void 模块5_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.Green;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.DeepSkyBlue;

            模块8.BackColor = Color.DeepSkyBlue;
            Crontral_IO_Form = lbModule5.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                        throw;
                    }


                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                //dataGridViewInput.Columns[0].ReadOnly = true;
                //dataGridViewInput.Columns[1].ReadOnly = true;
                //dataGridViewInput.Columns[2].ReadOnly = true;
                //dataGridViewInput.Columns[3].ReadOnly = true;
                //dataGridViewInput.Columns[4].ReadOnly = true;
                //dataGridViewInput.Columns[5].ReadOnly = true;
                //dataGridViewOutput.Columns[0].ReadOnly = true;
                //dataGridViewOutput.Columns[1].ReadOnly = true;
                //dataGridViewOutput.Columns[4].ReadOnly = true;
                //dataGridViewOutput.Columns[5].ReadOnly = true;
            }

            // lbModule5.Text = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List[5].hardIOName;
        }

        private void 模块6_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.Green;
            模块7.BackColor = Color.DeepSkyBlue;
            模块8.BackColor = Color.DeepSkyBlue;

            Crontral_IO_Form = lbModule6.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                        throw;
                    }


                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                //dataGridViewInput.Columns[0].ReadOnly = true;
                //dataGridViewInput.Columns[1].ReadOnly = true;
                //dataGridViewInput.Columns[2].ReadOnly = true;
                //dataGridViewInput.Columns[3].ReadOnly = true;
                //dataGridViewInput.Columns[4].ReadOnly = true;
                //dataGridViewInput.Columns[5].ReadOnly = true;
                //dataGridViewOutput.Columns[0].ReadOnly = true;
                //dataGridViewOutput.Columns[1].ReadOnly = true;
                //dataGridViewOutput.Columns[4].ReadOnly = true;
                //dataGridViewOutput.Columns[5].ReadOnly = true;
            }

            // lbModule6.Text = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List[6].hardIOName;
        }

        private void 模块7_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.Green;
            模块7.BackColor = Color.DeepSkyBlue;

            模块8.BackColor = Color.DeepSkyBlue;
            Crontral_IO_Form = lbModule7.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                        throw;
                    }


                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                //dataGridViewInput.Columns[0].ReadOnly = true;
                //dataGridViewInput.Columns[1].ReadOnly = true;
                //dataGridViewInput.Columns[2].ReadOnly = true;
                //dataGridViewInput.Columns[3].ReadOnly = true;
                //dataGridViewInput.Columns[4].ReadOnly = true;
                //dataGridViewInput.Columns[5].ReadOnly = true;
                //dataGridViewOutput.Columns[0].ReadOnly = true;
                //dataGridViewOutput.Columns[1].ReadOnly = true;
                //dataGridViewOutput.Columns[4].ReadOnly = true;
                //dataGridViewOutput.Columns[5].ReadOnly = true;
            }

            //lbModule7.Text = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List[7].hardIOName;
        }

        private void 模块8_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.Green;

            模块8.BackColor = Color.DeepSkyBlue;
            Crontral_IO_Form = lbModule8.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                        throw;
                    }


                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                //dataGridViewInput.Columns[0].ReadOnly = true;
                //dataGridViewInput.Columns[1].ReadOnly = true;
                //dataGridViewInput.Columns[2].ReadOnly = true;
                //dataGridViewInput.Columns[3].ReadOnly = true;
                //dataGridViewInput.Columns[4].ReadOnly = true;
                //dataGridViewInput.Columns[5].ReadOnly = true;
                //dataGridViewOutput.Columns[0].ReadOnly = true;
                //dataGridViewOutput.Columns[1].ReadOnly = true;
                //dataGridViewOutput.Columns[4].ReadOnly = true;
                //dataGridViewOutput.Columns[5].ReadOnly = true;
            }

            //lbModule8.Text = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List[8].hardIOName;
        }
        #endregion
        /// <summary>
        /// 初始化IO卡按钮
        /// </summary>
        private void InitAll_IO_Button()
        {
            try
            {
                #region 板卡
                switch (Properties.Settings.Default.iControlIOCardCount)
                {
                    case 0:
                        this.板卡IO1.Visible = false;
                        this.板卡IO2.Visible = false;
                        this.板卡IO3.Visible = false;
                        this.板卡IO4.Visible = false;
                        this.板卡IO5.Visible = false;
                        this.板卡IO6.Visible = false;
                        this.板卡IO7.Visible = false;
                        this.板卡IO8.Visible = false;

                        Cade1_Name.Visible = false;
                        Cade2_Name.Visible = false;
                        Cade3_Name.Visible = false;
                        Cade4_Name.Visible = false;
                        Cade5_Name.Visible = false;
                        Cade6_Name.Visible = false;
                        Cade7_Name.Visible = false;
                        Cade8_Name.Visible = false;
                        break;
                    case 1:
                        this.板卡IO1.Visible = true;
                        this.板卡IO2.Visible = false;
                        this.板卡IO3.Visible = false;
                        this.板卡IO4.Visible = false;
                        this.板卡IO5.Visible = false;
                        this.板卡IO6.Visible = false;
                        this.板卡IO7.Visible = false;
                        this.板卡IO8.Visible = false;

                        Cade1_Name.Visible = true;
                        Cade2_Name.Visible = false;
                        Cade3_Name.Visible = false;
                        Cade4_Name.Visible = false;
                        Cade5_Name.Visible = false;
                        Cade6_Name.Visible = false;
                        Cade7_Name.Visible = false;
                        Cade8_Name.Visible = false;
                        break;
                    case 2:
                        this.板卡IO1.Visible = true;
                        this.板卡IO2.Visible = true;
                        this.板卡IO3.Visible = false;
                        this.板卡IO4.Visible = false;
                        this.板卡IO5.Visible = false;
                        this.板卡IO6.Visible = false;
                        this.板卡IO7.Visible = false;
                        this.板卡IO8.Visible = false;

                        Cade1_Name.Visible = true;
                        Cade2_Name.Visible = true;
                        Cade3_Name.Visible = false;
                        Cade4_Name.Visible = false;
                        Cade5_Name.Visible = false;
                        Cade6_Name.Visible = false;
                        Cade7_Name.Visible = false;
                        Cade8_Name.Visible = false;
                        break;
                    case 3:
                        this.板卡IO1.Visible = true;
                        this.板卡IO2.Visible = true;
                        this.板卡IO3.Visible = true;
                        this.板卡IO4.Visible = false;
                        this.板卡IO5.Visible = false;
                        this.板卡IO6.Visible = false;
                        this.板卡IO7.Visible = false;
                        this.板卡IO8.Visible = false;

                        Cade1_Name.Visible = true;
                        Cade2_Name.Visible = true;
                        Cade3_Name.Visible = true;
                        Cade4_Name.Visible = false;
                        Cade5_Name.Visible = false;
                        Cade6_Name.Visible = false;
                        Cade7_Name.Visible = false;
                        Cade8_Name.Visible = false;
                        break;
                    case 4:
                        this.板卡IO1.Visible = true;
                        this.板卡IO2.Visible = true;
                        this.板卡IO3.Visible = true;
                        this.板卡IO4.Visible = true;
                        this.板卡IO5.Visible = false;
                        this.板卡IO6.Visible = false;
                        this.板卡IO7.Visible = false;
                        this.板卡IO8.Visible = false;

                        Cade1_Name.Visible = true;
                        Cade2_Name.Visible = true;
                        Cade3_Name.Visible = true;
                        Cade4_Name.Visible = true;
                        Cade5_Name.Visible = false;
                        Cade6_Name.Visible = false;
                        Cade7_Name.Visible = false;
                        Cade8_Name.Visible = false;
                        break;
                    case 5:
                        this.板卡IO1.Visible = true;
                        this.板卡IO2.Visible = true;
                        this.板卡IO3.Visible = true;
                        this.板卡IO4.Visible = true;
                        this.板卡IO5.Visible = true;
                        this.板卡IO6.Visible = false;
                        this.板卡IO7.Visible = false;
                        this.板卡IO8.Visible = false;

                        Cade1_Name.Visible = true;
                        Cade2_Name.Visible = true;
                        Cade3_Name.Visible = true;
                        Cade4_Name.Visible = true;
                        Cade5_Name.Visible = true;
                        Cade6_Name.Visible = false;
                        Cade7_Name.Visible = false;
                        Cade8_Name.Visible = false;
                        break;
                    case 6:
                        this.板卡IO1.Visible = true;
                        this.板卡IO2.Visible = true;
                        this.板卡IO3.Visible = true;
                        this.板卡IO4.Visible = true;
                        this.板卡IO5.Visible = true;
                        this.板卡IO6.Visible = true;
                        this.板卡IO7.Visible = false;
                        this.板卡IO8.Visible = false;

                        Cade1_Name.Visible = true;
                        Cade2_Name.Visible = true;
                        Cade3_Name.Visible = true;
                        Cade4_Name.Visible = true;
                        Cade5_Name.Visible = true;
                        Cade6_Name.Visible = true;
                        Cade7_Name.Visible = false;
                        Cade8_Name.Visible = false;
                        break;
                    case 7:
                        this.板卡IO1.Visible = true;
                        this.板卡IO2.Visible = true;
                        this.板卡IO3.Visible = true;
                        this.板卡IO4.Visible = true;
                        this.板卡IO5.Visible = true;
                        this.板卡IO6.Visible = true;
                        this.板卡IO7.Visible = true;
                        this.板卡IO8.Visible = false;

                        Cade1_Name.Visible = true;
                        Cade2_Name.Visible = true;
                        Cade3_Name.Visible = true;
                        Cade4_Name.Visible = true;
                        Cade5_Name.Visible = true;
                        Cade6_Name.Visible = true;
                        Cade7_Name.Visible = true;
                        Cade8_Name.Visible = false;
                        break;
                    case 8:
                        this.板卡IO1.Visible = true;
                        this.板卡IO2.Visible = true;
                        this.板卡IO3.Visible = true;
                        this.板卡IO4.Visible = true;
                        this.板卡IO5.Visible = true;
                        this.板卡IO6.Visible = true;
                        this.板卡IO7.Visible = true;
                        this.板卡IO8.Visible = true;

                        Cade1_Name.Visible = true;
                        Cade2_Name.Visible = true;
                        Cade3_Name.Visible = true;
                        Cade4_Name.Visible = true;
                        Cade5_Name.Visible = true;
                        Cade6_Name.Visible = true;
                        Cade7_Name.Visible = true;
                        Cade8_Name.Visible = true;
                        break;
                    default:
                        break;
                }
                #endregion
                #region  IO扩展卡
                switch (Properties.Settings.Default.iModuleIOCardCount)
                {
                    case 0:
                        this.模块1.Visible = false;
                        this.模块2.Visible = false;
                        this.模块3.Visible = false;
                        this.模块4.Visible = false;
                        this.模块5.Visible = false;
                        this.模块6.Visible = false;
                        this.模块7.Visible = false;
                        this.模块8.Visible = false;

                        lbModule1.Visible = false;
                        lbModule2.Visible = false;
                        lbModule3.Visible = false;
                        lbModule4.Visible = false;
                        lbModule5.Visible = false;
                        lbModule6.Visible = false;
                        lbModule7.Visible = false;
                        lbModule8.Visible = false;
                        break;
                    case 1:
                        this.模块1.Visible = true;
                        this.模块2.Visible = false;
                        this.模块3.Visible = false;
                        this.模块4.Visible = false;
                        this.模块5.Visible = false;
                        this.模块6.Visible = false;
                        this.模块7.Visible = false;
                        this.模块8.Visible = false;

                        lbModule1.Visible = true;
                        lbModule2.Visible = false;
                        lbModule3.Visible = false;
                        lbModule4.Visible = false;
                        lbModule5.Visible = false;
                        lbModule6.Visible = false;
                        lbModule7.Visible = false;
                        lbModule8.Visible = false;
                        break;
                    case 2:
                        this.模块1.Visible = true;
                        this.模块2.Visible = true;
                        this.模块3.Visible = false;
                        this.模块4.Visible = false;
                        this.模块5.Visible = false;
                        this.模块6.Visible = false;
                        this.模块7.Visible = false;
                        this.模块8.Visible = false;

                        lbModule1.Visible = true;
                        lbModule2.Visible = true;
                        lbModule3.Visible = false;
                        lbModule4.Visible = false;
                        lbModule5.Visible = false;
                        lbModule6.Visible = false;
                        lbModule7.Visible = false;
                        lbModule8.Visible = false;
                        break;
                    case 3:
                        this.模块1.Visible = true;
                        this.模块2.Visible = true;
                        this.模块3.Visible = true;
                        this.模块4.Visible = false;
                        this.模块5.Visible = false;
                        this.模块6.Visible = false;
                        this.模块7.Visible = false;
                        this.模块8.Visible = false;

                        lbModule1.Visible = true;
                        lbModule2.Visible = true;
                        lbModule3.Visible = true;
                        lbModule4.Visible = false;
                        lbModule5.Visible = false;
                        lbModule6.Visible = false;
                        lbModule7.Visible = false;
                        lbModule8.Visible = false;
                        break;
                    case 4:
                        this.模块1.Visible = true;
                        this.模块2.Visible = true;
                        this.模块3.Visible = true;
                        this.模块4.Visible = true;
                        this.模块5.Visible = false;
                        this.模块6.Visible = false;
                        this.模块7.Visible = false;
                        this.模块8.Visible = false;

                        lbModule1.Visible = true;
                        lbModule2.Visible = true;
                        lbModule3.Visible = true;
                        lbModule4.Visible = true;
                        lbModule5.Visible = false;
                        lbModule6.Visible = false;
                        lbModule7.Visible = false;
                        lbModule8.Visible = false;
                        break;
                    case 5:
                        this.模块1.Visible = true;
                        this.模块2.Visible = true;
                        this.模块3.Visible = true;
                        this.模块4.Visible = true;
                        this.模块5.Visible = true;
                        this.模块6.Visible = false;
                        this.模块7.Visible = false;
                        this.模块8.Visible = false;

                        lbModule1.Visible = true;
                        lbModule2.Visible = true;
                        lbModule3.Visible = true;
                        lbModule4.Visible = true;
                        lbModule5.Visible = true;
                        lbModule6.Visible = false;
                        lbModule7.Visible = false;
                        lbModule8.Visible = false;
                        break;
                    case 6:
                        this.模块1.Visible = true;
                        this.模块2.Visible = true;
                        this.模块3.Visible = true;
                        this.模块4.Visible = true;
                        this.模块5.Visible = true;
                        this.模块6.Visible = true;
                        this.模块7.Visible = false;
                        this.模块8.Visible = false;

                        lbModule1.Visible = true;
                        lbModule2.Visible = true;
                        lbModule3.Visible = true;
                        lbModule4.Visible = true;
                        lbModule5.Visible = true;
                        lbModule6.Visible = true;
                        lbModule7.Visible = false;
                        lbModule8.Visible = false;
                        break;
                    case 7:
                        this.模块1.Visible = true;
                        this.模块2.Visible = true;
                        this.模块3.Visible = true;
                        this.模块4.Visible = true;
                        this.模块5.Visible = true;
                        this.模块6.Visible = true;
                        this.模块7.Visible = true;
                        this.模块8.Visible = false;

                        lbModule1.Visible = true;
                        lbModule2.Visible = true;
                        lbModule3.Visible = true;
                        lbModule4.Visible = true;
                        lbModule5.Visible = true;
                        lbModule6.Visible = true;
                        lbModule7.Visible = true;
                        lbModule8.Visible = false;
                        break;
                    case 8:
                        this.模块1.Visible = true;
                        this.模块2.Visible = true;
                        this.模块3.Visible = true;
                        this.模块4.Visible = true;
                        this.模块5.Visible = true;
                        this.模块6.Visible = true;
                        this.模块7.Visible = true;
                        this.模块8.Visible = true;

                        lbModule1.Visible = true;
                        lbModule2.Visible = true;
                        lbModule3.Visible = true;
                        lbModule4.Visible = true;
                        lbModule5.Visible = true;
                        lbModule6.Visible = true;
                        lbModule7.Visible = true;
                        lbModule8.Visible = true;
                        break;
                    default:
                        break;
                }
                #endregion
                #region  已摒弃
                //if (Properties.Settings.Default.iIOCardCount == 0)
                //{
                //    this.板卡IO1.Visible = false;
                //    this.模块1.Visible = false;
                //    this.模块2.Visible = false;
                //    this.模块3.Visible = false;
                //    this.模块4.Visible = false;
                //    this.模块5.Visible = false;
                //    this.模块6.Visible = false;
                //    this.模块7.Visible = false;
                //    this.模块8.Visible = false;

                //    lbCard1.Visible = false;
                //    lbModule1.Visible = false;
                //    lbModule2.Visible = false;
                //    lbModule3.Visible = false;
                //    lbModule4.Visible = false;
                //    lbModule5.Visible = false;
                //    lbModule6.Visible = false;
                //    lbModule7.Visible = false;
                //    lbModule8.Visible = false;
                //}
                //else if (Properties.Settings.Default.iIOCardCount == 1)
                //{
                //    this.板卡IO1.Visible = true;
                //    this.模块1.Visible = false;
                //    this.模块2.Visible = false;
                //    this.模块3.Visible = false;
                //    this.模块4.Visible = false;
                //    this.模块5.Visible = false;
                //    this.模块6.Visible = false;
                //    this.模块7.Visible = false;
                //    this.模块8.Visible = false;

                //    lbCard1.Visible = true;
                //    lbModule1.Visible = false;
                //    lbModule2.Visible = false;
                //    lbModule3.Visible = false;
                //    lbModule4.Visible = false;
                //    lbModule5.Visible = false;
                //    lbModule6.Visible = false;
                //    lbModule7.Visible = false;
                //    lbModule8.Visible = false;
                //}
                //else if (Properties.Settings.Default.iIOCardCount == 2)
                //{
                //    this.板卡IO1.Visible = true;
                //    this.模块1.Visible = true;
                //    this.模块2.Visible = false;
                //    this.模块3.Visible = false;
                //    this.模块4.Visible = false;
                //    this.模块5.Visible = false;
                //    this.模块6.Visible = false;
                //    this.模块7.Visible = false;
                //    this.模块8.Visible = false;

                //    lbCard1.Visible = true;
                //    lbModule1.Visible = true;
                //    lbModule2.Visible = false;
                //    lbModule3.Visible = false;
                //    lbModule4.Visible = false;
                //    lbModule5.Visible = false;
                //    lbModule6.Visible = false;
                //    lbModule7.Visible = false;
                //    lbModule8.Visible = false;
                //}
                //else if (Properties.Settings.Default.iIOCardCount == 3)
                //{
                //    this.板卡IO1.Visible = true;
                //    this.模块1.Visible = true;
                //    this.模块2.Visible = true;
                //    this.模块3.Visible = false;
                //    this.模块4.Visible = false;
                //    this.模块5.Visible = false;
                //    this.模块6.Visible = false;
                //    this.模块7.Visible = false;
                //    this.模块8.Visible = false;

                //    lbCard1.Visible = true;
                //    lbModule1.Visible = true;
                //    lbModule2.Visible = true;
                //    lbModule3.Visible = false;
                //    lbModule4.Visible = false;
                //    lbModule5.Visible = false;
                //    lbModule6.Visible = false;
                //    lbModule7.Visible = false;
                //    lbModule8.Visible = false;
                //}
                //else if (Properties.Settings.Default.iIOCardCount == 4)
                //{
                //    this.板卡IO1.Visible = true;
                //    this.模块1.Visible = true;
                //    this.模块2.Visible = true;
                //    this.模块3.Visible = true;
                //    this.模块4.Visible = false;
                //    this.模块5.Visible = false;
                //    this.模块6.Visible = false;
                //    this.模块7.Visible = false;
                //    this.模块8.Visible = false;

                //    lbCard1.Visible = true;
                //    lbModule1.Visible = true;
                //    lbModule2.Visible = true;
                //    lbModule3.Visible = true;
                //    lbModule4.Visible = false;
                //    lbModule5.Visible = false;
                //    lbModule6.Visible = false;
                //    lbModule7.Visible = false;
                //    lbModule8.Visible = false;
                //}
                //else if (Properties.Settings.Default.iIOCardCount == 5)
                //{
                //    this.板卡IO1.Visible = true;
                //    this.模块1.Visible = true;
                //    this.模块2.Visible = true;
                //    this.模块3.Visible = true;
                //    this.模块4.Visible = true;
                //    this.模块5.Visible = false;
                //    this.模块6.Visible = false;
                //    this.模块7.Visible = false;
                //    this.模块8.Visible = false;

                //    lbCard1.Visible = true;
                //    lbModule1.Visible = true;
                //    lbModule2.Visible = true;
                //    lbModule3.Visible = true;
                //    lbModule4.Visible = true;
                //    lbModule5.Visible = false;
                //    lbModule6.Visible = false;
                //    lbModule7.Visible = false;
                //    lbModule8.Visible = false;
                //}
                //else if (Properties.Settings.Default.iIOCardCount == 6)
                //{
                //    this.板卡IO1.Visible = true;
                //    this.模块1.Visible = true;
                //    this.模块2.Visible = true;
                //    this.模块3.Visible = true;
                //    this.模块4.Visible = true;
                //    this.模块5.Visible = true;
                //    this.模块6.Visible = false;
                //    this.模块7.Visible = false;
                //    this.模块8.Visible = false;

                //    lbCard1.Visible = true;
                //    lbModule1.Visible = true;
                //    lbModule2.Visible = true;
                //    lbModule3.Visible = true;
                //    lbModule4.Visible = true;
                //    lbModule5.Visible = true;
                //    lbModule6.Visible = false;
                //    lbModule7.Visible = false;
                //    lbModule8.Visible = false;
                //}
                //else if (Properties.Settings.Default.iIOCardCount == 7)
                //{
                //    this.板卡IO1.Visible = true;
                //    this.模块1.Visible = true;
                //    this.模块2.Visible = true;
                //    this.模块3.Visible = true;
                //    this.模块4.Visible = true;
                //    this.模块5.Visible = true;
                //    this.模块6.Visible = true;
                //    this.模块7.Visible = false;
                //    this.模块8.Visible = false;

                //    lbCard1.Visible = true;
                //    lbModule1.Visible = true;
                //    lbModule2.Visible = true;
                //    lbModule3.Visible = true;
                //    lbModule4.Visible = true;
                //    lbModule5.Visible = true;
                //    lbModule6.Visible = true;
                //    lbModule7.Visible = false;
                //    lbModule8.Visible = false;
                //}
                //else if (Properties.Settings.Default.iIOCardCount == 8)
                //{
                //    this.板卡IO1.Visible = true;
                //    this.模块1.Visible = true;
                //    this.模块2.Visible = true;
                //    this.模块3.Visible = true;
                //    this.模块4.Visible = true;
                //    this.模块5.Visible = true;
                //    this.模块6.Visible = true;
                //    this.模块7.Visible = true;
                //    this.模块8.Visible = false;

                //    lbCard1.Visible = true;
                //    lbModule1.Visible = true;
                //    lbModule2.Visible = true;
                //    lbModule3.Visible = true;
                //    lbModule4.Visible = true;
                //    lbModule5.Visible = true;
                //    lbModule6.Visible = true;
                //    lbModule7.Visible = true;
                //    lbModule8.Visible = false;
                //}
                //else if (Properties.Settings.Default.iIOCardCount == 9)
                //{
                //    this.板卡IO1.Visible = true;
                //    this.模块1.Visible = true;
                //    this.模块2.Visible = true;
                //    this.模块3.Visible = true;
                //    this.模块4.Visible = true;
                //    this.模块5.Visible = true;
                //    this.模块6.Visible = true;
                //    this.模块7.Visible = true;
                //    this.模块8.Visible = true;

                //    lbCard1.Visible = true;
                //    lbModule1.Visible = true;
                //    lbModule2.Visible = true;
                //    lbModule3.Visible = true;
                //    lbModule4.Visible = true;
                //    lbModule5.Visible = true;
                //    lbModule6.Visible = true;
                //    lbModule7.Visible = true;
                //    lbModule8.Visible = true;
                //}
                //else
                //{

                //}
                #endregion
            }
            catch (Exception)
            {

            }
        }
        private void IOView()
        {
            int LbCardCount = 0;
            int LbModuleCount = 0;
            foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareList)
            {
                if (item.m_strHardWare_Modle == "卡硬件")
                {
                    lbCard[LbCardCount].Text = item.hardwareName;
                    LbCardCount++;
                }
                else
                {
                    lbModule[LbModuleCount].Text = item.hardwareName;
                    LbModuleCount++;
                }
            }
            InitAll_IO_Button();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            IOView();
            int count = 0;
            //Googol_Contral.GetAllIOStatus();
            //输入输出状态显示
            try
            {
                foreach (var items in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                {
                    if (items.Value.hardwareName == Crontral_IO_Form)
                    {
                        foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
                        {
                            if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[item.Value.hardIOName].hard_IO_Name == items.Value.hardwareName)
                            {

                                bool bOn = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[item.Value.hardIOName].bBitInputStatus;
                                dataGridViewInput.Rows[count].Cells[1].Style.BackColor = bOn ? Color.Green : Color.FromKnownColor(KnownColor.Control);
                                dataGridViewInput.Rows[count].Cells[0].Value = count;
                                count++;
                            }
                        }
                    }
                }

            }
            catch (Exception R)
            {

            }
        }
        /// <summary>
        /// 输出按钮单元格单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewOutput_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int CIndex = e.ColumnIndex;
            if (CIndex == 2 && e.RowIndex != -1)
            {
                string strName = dataGridViewOutput.Rows[e.RowIndex].Cells[4].Value.ToString();

                ManageContral.SetOutBit(strName, true);
                //  Googol_Contral.SetOutBit(strName,true);
                // IOManage.OUTPUT(strName).SetOutBit(true);
            }
            else if (CIndex == 3 && e.RowIndex != -1)
            {
                string strName = dataGridViewOutput.Rows[e.RowIndex].Cells[4].Value.ToString();
                ManageContral.SetOutBit(strName, false);
                //Googol_Contral.SetOutBit(strName, false);
                // IOManage.OUTPUT(strName).SetOutBit(false);
            }
        }

        private void IODebugForm_Activated(object sender, EventArgs e)
        {
            //板卡IO1_Click(sender, e);
            //板卡IO1.BackColor = Color.Green;
        }

        #region 板卡按钮
        private void 板卡IO1_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.Green;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.DeepSkyBlue;
            模块8.BackColor = Color.DeepSkyBlue;

            Crontral_IO_Form = Cade1_Name.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                    }
                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null"; ;
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                initIntputDgv(dataGridViewInput);
                initOutputDgv(dataGridViewOutput);
            }
        }

        private void 板卡IO2_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.Green;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.DeepSkyBlue;
            模块8.BackColor = Color.DeepSkyBlue;

            Crontral_IO_Form = Cade2_Name.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                    }
                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                initIntputDgv(dataGridViewInput);
                initOutputDgv(dataGridViewOutput);
            }
        }


        private void 板卡IO3_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.Green;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.DeepSkyBlue;
            模块8.BackColor = Color.DeepSkyBlue;

            Crontral_IO_Form = Cade3_Name.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                    }
                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                initIntputDgv(dataGridViewInput);
                initOutputDgv(dataGridViewOutput);
            }
        }

        private void 板卡IO4_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.Green;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.DeepSkyBlue;
            模块8.BackColor = Color.DeepSkyBlue;

            Crontral_IO_Form = Cade4_Name.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                    }
                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                initIntputDgv(dataGridViewInput);
                initOutputDgv(dataGridViewOutput);
            }
        }

        private void 板卡IO5_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.Green;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.DeepSkyBlue;
            模块8.BackColor = Color.DeepSkyBlue;

            Crontral_IO_Form = Cade5_Name.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                    }
                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                initIntputDgv(dataGridViewInput);
                initOutputDgv(dataGridViewOutput);
            }
        }

        private void 板卡IO6_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.Green;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.DeepSkyBlue;
            模块8.BackColor = Color.DeepSkyBlue;

            Crontral_IO_Form = Cade6_Name.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                    }
                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                initIntputDgv(dataGridViewInput);
                initOutputDgv(dataGridViewOutput);
            }
        }

        private void 板卡IO7_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.Green;
            板卡IO8.BackColor = Color.DeepSkyBlue;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.DeepSkyBlue;
            模块8.BackColor = Color.DeepSkyBlue;

            Crontral_IO_Form = Cade7_Name.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch
                    {

                    }
                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                initIntputDgv(dataGridViewInput);
                initOutputDgv(dataGridViewOutput);
            }
        }

        private void 板卡IO8_Click(object sender, EventArgs e)
        {
            板卡IO1.BackColor = Color.DeepSkyBlue;
            板卡IO2.BackColor = Color.DeepSkyBlue;
            板卡IO3.BackColor = Color.DeepSkyBlue;
            板卡IO4.BackColor = Color.DeepSkyBlue;
            板卡IO5.BackColor = Color.DeepSkyBlue;
            板卡IO6.BackColor = Color.DeepSkyBlue;
            板卡IO7.BackColor = Color.DeepSkyBlue;
            板卡IO8.BackColor = Color.Green;
            模块1.BackColor = Color.DeepSkyBlue;
            模块2.BackColor = Color.DeepSkyBlue;
            模块3.BackColor = Color.DeepSkyBlue;
            模块4.BackColor = Color.DeepSkyBlue;
            模块5.BackColor = Color.DeepSkyBlue;
            模块6.BackColor = Color.DeepSkyBlue;
            模块7.BackColor = Color.DeepSkyBlue;
            模块8.BackColor = Color.DeepSkyBlue;

            Crontral_IO_Form = Cade8_Name.Text;
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                if (item.Value.hard_IO_Name == Crontral_IO_Form)
                {
                    m_Hard_IOInPut_List.Clear();
                    m_Hard_IOOutPut_List.Clear();
                    try
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                                IOCardSta_InPut.hardIOName = items.hardIOName;
                                IOCardSta_InPut.iBitNo = items.iBitNo;
                                IOCardSta_InPut.iCardNo = items.iCardNo;
                                IOCardSta_InPut.iExtNo = items.iExtNo;
                                IOCardSta_InPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_InPut.bignore = items.bignore;
                                m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                            }
                        }
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {

                            if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[Crontral_IO_Form].hardwareName == items.hard_IO_Name)
                            {
                                IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                                IOCardSta_OutPut.hardIOName = items.hardIOName;
                                IOCardSta_OutPut.iBitNo = items.iBitNo;
                                IOCardSta_OutPut.iCardNo = items.iCardNo;
                                IOCardSta_OutPut.iExtNo = items.iExtNo;
                                IOCardSta_OutPut.hard_IO_Name = items.hard_IO_Name;
                                IOCardSta_OutPut.bignore = items.bignore;
                                m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                            }
                        }
                    }
                    catch (Exception R)
                    {

                    }
                    //initDgv(dataGridViewInput);
                    //initDgv(dataGridViewOutput);
                }
            }
            if (m_Hard_IOInPut_List.Count != 0 && m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = "null";
                dataGridViewOutput.DataSource = "null";
                // Thread.Sleep(500);
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
                dataGridViewInput.Refresh();
                dataGridViewOutput.Refresh();
                initIntputDgv(dataGridViewInput);
                initOutputDgv(dataGridViewOutput);
            }
        }
        #endregion


        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                foreach (var items in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                {
                    if (items.Value.hardwareName == Crontral_IO_Form)
                    {
                        foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                        {
                            if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[item.Value.hardIOName].hard_IO_Name == items.Value.hardwareName)
                            {

                                bool bOn = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[item.Value.hardIOName].bBitOutputStatus;
                                dataGridViewOutput.Rows[count].Cells[0].Value = count;
                                dataGridViewOutput.Rows[count].Cells[1].Style.BackColor = bOn ? Color.Green : Color.FromKnownColor(KnownColor.Control);
                                count++;
                            }
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
