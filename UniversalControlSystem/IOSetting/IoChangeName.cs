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
    public partial class IoChangeName : Form
    {
        public IoChangeName()
        {
            InitializeComponent();
        }

        private void IoChangeName_Load(object sender, EventArgs e)
        {
           
        }
        public List<IOCardSta_InPut> _m_Hard_IOInPut=new List<IOCardSta_InPut> ();
        public List<IOCardSta_OutPut> _m_Hard_IOOutPut=new List<IOCardSta_OutPut>();
        string startName = "";
        int num = 0;
        string OUTstartName = "";
        int OUTnum = 0;
        /// <summary>
        /// 输入dgv单元格验证事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewInput_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string strName = dataGridViewInput.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (strName != "")
                {          
                int count = 0;
                foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                {
                    foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                    {
                        if (item.hardIOName == items.hardIOName)
                        {
                            count++;
                        }
                    }
                }
                if (count == Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.Count)
                {
                    _m_Hard_IOInPut = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List;
                    Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.ToDictionary(p => p.hardIOName);
                }
                else
                {
                    Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List[num].hardIOName = startName;
                    Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.ToDictionary(p => p.hardIOName);
                    dataGridViewInput.DataSource = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List;
                    dataGridViewInput.Update();
                    // FormStart.m_FormAlarm.InsertAlarmMessage(ERecvResult.IO输入或输出已有相同项.ToString());
                    return;
                }
                }
                else
                {
                    Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List[num].hardIOName = startName;
                    Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.ToDictionary(p => p.hardIOName);
                    dataGridViewInput.DataSource = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List;
                    dataGridViewInput.Update();

                }
            }
            catch
            {
                Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List[num].hardIOName = startName;
                Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.ToDictionary(p => p.hardIOName);
                dataGridViewInput.DataSource = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List;
                dataGridViewInput.Update();
               // MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.IO输入或输出已有相同项.ToString());
                return;
            }
           
        }
         public void UpdateIO()
        {
            try
            {
                dataGridViewInput.DataSource = null;
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List != null && Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.Count > 0)
                {
                    _m_Hard_IOInPut= Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List;
                    dataGridViewInput.DataSource = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List;
                    //try
                    //{
                    //    //dataGridViewInput.Columns[1].ReadOnly = true;
                    //    dataGridViewInput.Columns[2].ReadOnly = true;
                    //    dataGridViewInput.Columns[3].ReadOnly = true;
                    //    dataGridViewInput.Columns[4].ReadOnly = true;
                    //    dataGridViewInput.Columns[5].ReadOnly = true;
                    //    dataGridViewInput.Columns[6].ReadOnly = true;
                    //}
                    //catch { }
                    initDgv(dataGridViewInput);
                }

                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List!= null && Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List.Count > 0)
                {
                    dataGridViewOutput.DataSource = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List;
                    //try
                    //{
                    //    //dataGridViewOutput.Columns[1].ReadOnly = true;
                    //    dataGridViewOutput.Columns[2].ReadOnly = true;
                    //    dataGridViewOutput.Columns[3].ReadOnly = true;
                    //    dataGridViewOutput.Columns[4].ReadOnly = true;
                    //    dataGridViewOutput.Columns[5].ReadOnly = true;
                    //    dataGridViewOutput.Columns[6].ReadOnly = true;
                    //    dataGridViewOutput.Columns[7].ReadOnly = true;
                    //}
                    //catch
                    //{
                    //}
                    initDgv(dataGridViewOutput);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// 初始化DataGridView的方法
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        private void initDgv(DataGridView dgv)
        {
            //dgv.Columns.Clear();
            dgv.Columns[0].HeaderText = "IO名称";
            dgv.Columns[1].HeaderText = "屏蔽";
            dgv.Columns[2].HeaderText = "卡名";
            dgv.Columns[3].HeaderText = "控制卡";
            dgv.Columns[4].HeaderText = "IO卡号";
            dgv.Columns[5].HeaderText = "点位编号";
            dgv.Columns[6].HeaderText = "IO状态";
            for (byte i = 0; i < dgv.Columns.Count; i++)
            {
                if (i == 0)
                {
                    dgv.Columns[i].Width = 110;
                }
                else if (i == 2)
                {
                    dgv.Columns[i].Width = 70;
                }
                else
                {
                    dgv.Columns[i].Width = 50;
                }
                if(i == 0 || i == 1)
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
                dgv.Rows[i].Height = 30;
            }
            dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvData.RowsDefaultCellStyle
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        /// <summary>
        /// 输出dgv单元格验证事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewOutput_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string strName = dataGridViewOutput.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (strName != "")
                {
                    int count = 0;
                    foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                    {
                        foreach (var items in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                        {
                            if (item.hardIOName == items.hardIOName)
                            {
                                count++;
                            }
                        }
                    }
                    if (count == Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary.Count)
                    {
                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List.ToDictionary(p => p.hardIOName);
                    }
                    else
                    {
                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List[OUTnum].hardIOName = OUTstartName;
                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List.ToDictionary(p => p.hardIOName);
                        dataGridViewOutput.DataSource = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List;
                        dataGridViewOutput.Update();
                        return;
                    }
                }
                else
                {
                    Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List[OUTnum].hardIOName = OUTstartName;
                    Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List.ToDictionary(p => p.hardIOName);
                    dataGridViewOutput.DataSource = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List;
                    dataGridViewOutput.Update();

                }
            }
            catch
            {
                Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List[OUTnum].hardIOName = OUTstartName;
                Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List.ToDictionary(p => p.hardIOName);
                dataGridViewOutput.DataSource = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List;
                dataGridViewOutput.Update();
            }
        }

        private void dataGridViewInput_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dataGridViewInput_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            startName = dataGridViewInput.Rows[e.RowIndex].Cells[0].Value.ToString();
            num = e.RowIndex;
        }

        private void dataGridViewOutput_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridViewOutput_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            OUTstartName = dataGridViewOutput.Rows[e.RowIndex].Cells[0].Value.ToString();
            OUTnum = e.RowIndex;
        }
        /// <summary>
        /// 关闭界面保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IoChangeName_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hard_Ward_Contral.Hardware_IO_State.SaveDoc();
        }
    }
}
