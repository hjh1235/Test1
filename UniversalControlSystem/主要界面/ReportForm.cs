using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
//using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace UniversalControlSystem
{
    public partial class ReportForm : Form
    {
        public string name;
        public ReportForm()
        {
            InitializeComponent();
        }

        private void tabControlnform_Click(object sender, EventArgs e)
        {

        }

        private void tabControlnform_SelectedIndexChanged(object sender, EventArgs e)
        {
            name = tabControlnform.SelectedTab.Text;
            GetCount();
        }

        #region 方法：数据查询
        /// <summary>
        /// 查询数据
        /// </summary>
        public void GetCount()
        {
            DateTime Starttime = dtpstart.Value;
            DateTime Stoptime = dtpend.Value;

            try
            {
                //自动删除3个月以前的数据
                string strBeforePro = "delete from productiondata where Time<='"+DateTime.Now.AddDays(-90).ToString("s")+"'";
                SQLiteConnect.executeSQL(strBeforePro);

                string strBeforeAlr = "delete from Alarm where StartTime<='"+ DateTime.Now.AddDays(-90).ToString("s") + "'";
                SQLiteConnect.executeSQL(strBeforeAlr);

                if (name == "生产总数")
                {
                    string str = "select SN as 条码,State as 状态,WorkStation as 工位,Time as 时间 from productiondata where Time>='" + Starttime.ToString("s") + "'and Time<='" + Stoptime.ToString("s") + "'";
                    DataSet ds = SQLiteConnect.getDataSet(str);
                    double Count = ds.Tables[0].Rows.Count;
                    labelCount.Text = Count.ToString();
                    dgvAInput.DataSource = ds.Tables[0];
                    dgvAInput.Columns["时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    InitDgv(dgvAInput);

                    string strOKCount = "select * from productiondata where State='OK'and Time>='" + Starttime.ToString("s") + "' and Time<='" + Stoptime.ToString("s") + "'";
                    DataSet dsOKCount = SQLiteConnect.getDataSet(strOKCount);
                    double OKCount = dsOKCount.Tables[0].Rows.Count;
                    labelOKCount.Text = OKCount.ToString();
                    double NGCount = Count - OKCount;
                    labelNGCount.Text = NGCount.ToString();
                    if (NGCount == 0)
                    {

                        labelNGCount.Text = "0";
                        labelNGToAll.Text = "0";
                        return;
                    }
                    if (OKCount == 0)
                    {
                        labelOKCount.Text = "0";
                        labelOKToAll.Text = "0";
                        return;
                    }
                    labelOKToAll.Text = ((OKCount / Count) * 100) + "%";
                    labelNGToAll.Text = ((NGCount / Count) * 100) + "%";    
                                   
                }
                else if (name == "左工位" || name == "右工位")
                {
                    string str = "select SN as 条码,State as 状态,WorkStation as 工位,Time as 时间 from productiondata where WorkStation='" + name + "' and Time>='" + Starttime.ToString("s") + "' and Time<='" + Stoptime.ToString("s") + "'";
                    DataSet ds = SQLiteConnect.getDataSet(str);
                    double Count = ds.Tables[0].Rows.Count;
                    labelCount.Text = Count.ToString();
                    if (name == "左工位")
                    {
                        dgvBInput.DataSource = ds.Tables[0];
                        dgvBInput.Columns["时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        InitDgv(dgvBInput);
                    }
                    else
                    {
                        dgvRetest.DataSource = ds.Tables[0];
                        dgvRetest.Columns["时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                        InitDgv(dgvRetest);
                    }

                    string strOKCount = "select * from productiondata where State='OK' and WorkStation='" + name + "'and Time>='" + Starttime.ToString("s") + "' and Time<='" + Stoptime.ToString("s") + "'";
                    DataSet dsOKCount = SQLiteConnect.getDataSet(strOKCount);
                    double OKCount = dsOKCount.Tables[0].Rows.Count;
                    labelOKCount.Text = OKCount.ToString();
                    double NGCount = Count - OKCount;
                    labelNGCount.Text = NGCount.ToString();
                    if (NGCount == 0)
                    {
                        labelNGCount.Text = "0";
                        labelNGToAll.Text = "0";

                    }
                    if (OKCount == 0)
                    {
                        labelOKCount.Text = "0";
                        labelOKToAll.Text = "0";
                    }
                    labelOKToAll.Text = ((OKCount / Count) * 100) + "%";
                    labelNGToAll.Text = ((NGCount / Count) * 100) + "%";
                }
                else if (name == "报警")
                {
                    string str = "select AlarmLevel as 报警名称,AlarmMessage as 报警信息,StartTime as 时间 from Alarm where StartTime>='" + Starttime.ToString("s") + "' and StartTime<='" + Stoptime.ToString("s") + "'";
                    DataSet ds = SQLiteConnect.getDataSet(str);
                    double Count = ds.Tables[0].Rows.Count;
                    labelCount.Text = Count.ToString() + "条";
                     dgvAboveCarA.DataSource = ds.Tables[0];
                    dgvAboveCarA.Columns["时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    InitDgv(dgvAboveCarA);

                    labelOKToAll.Text = "";
                    labelNGCount.Text = "";
                    labelOKCount.Text = "";                  
                    labelNGToAll.Text = "";
                }
                else if (name == "不良")
                {
                    string strNG = "select SN as 条码,State as 状态,WorkStation as 工位,Time as 时间 from productiondata where State='NG' and Time>='" + Starttime.ToString("s") + "' and Time<='" + Stoptime.ToString("s") + "'";
                    DataSet dsNG = SQLiteConnect.getDataSet(strNG);
                    double NGCount = dsNG.Tables[0].Rows.Count;                   
                    dgvAboveCarB.DataSource = dsNG.Tables[0];                 
                    dgvAboveCarB.Columns["时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";                   
                    InitDgv(dgvAboveCarB);

                    labelCount.Text = NGCount.ToString();
                    labelNGCount.Text = NGCount.ToString();
                    labelOKToAll.Text = "0";
                    labelNGToAll.Text = "0";
                    labelOKCount.Text = "0";
                }
            }
            catch (Exception error)
            {                
                MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.查询数据异常.ToString() + "\r\n" + error);
            }

        }
        #endregion

        #region 方法：删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        public void DeleteCount()
        {
            DateTime Starttime = dtpstart.Value;
            DateTime Stoptime = dtpend.Value;
            try
            {
                if (name == "生产总数")
                {
                    string str = "delete from productiondata where  Time=>'" + Starttime.ToString("s") + "' and Time<='" + Stoptime.ToString("s") + "'";
                    SQLiteConnect.executeSQL(str);
                    GetCount();
                }
                else if (name == "左工位" || name == "右工位")
                {
                    string str = "delete from productiondata where WorkStation='" + name + "'and Time=>'" + Starttime.ToString("s") + "' and Time<='" + Stoptime.ToString("s") + "' ";
                    SQLiteConnect.executeSQL(str);
                    GetCount();
                }
                else if (name == "报警")
                {
                    string str = "delete from Alarm where  StartTime>='" + Starttime.ToString("s") + "' and StartTime<='" + Stoptime.ToString("s") + "'";
                    SQLiteConnect.executeSQL(str);
                    GetCount();
                }
                else if (name == "不良")
                {
                    string str = "delete from produciondata where State='NG' and WorkStation='" + name + "'and Time>='" + Starttime.ToString("s") + "' and Time<='" + Stoptime.ToString("s") + "' ";
                    SQLiteConnect.executeSQL(str);
                    GetCount();
                }
            }
            catch (Exception error)
            {

                MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.查询数据异常.ToString() + "\r\n" + error);
            }
        }
        #endregion
     

        #region 方法：调整dataview格式
        private void InitDgv(DataGridView dgv)
        {
            try
            {
                int width = dgv.Size.Width;
                if (dgv == dgvAboveCarA)
                {
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                       
                        if (i == 1)
                        {
                            dgv.Columns[i].Width = Convert.ToInt32(width*0.5);
                        }
                        else
                        {
                            dgv.Columns[i].Width = Convert.ToInt32((width*0.5)/(dgv.ColumnCount-1));
                        }
                        dgv.Columns[i].SortMode = 0;
                    }
                }
                else
                {
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (i == 3)
                        {
                            dgv.Columns[i].Width = Convert.ToInt32(width * 0.3);
                        }
                        else if (i == 0)
                        {
                            dgv.Columns[i].Width = Convert.ToInt32(width * 0.3);
                        }
                        else
                        {
                            dgv.Columns[i].Width = Convert.ToInt32((width * 0.4) / (dgv.ColumnCount - 2));
                        }
                        dgv.Columns[i].SortMode = 0;

                    }
                }
             
                dgv.RowHeadersWidth = 75;
                dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.AllowUserToAddRows = false;
                dgv.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.ReadOnly = true;
            }
            catch (Exception)
            {
              
            }
        }
        #endregion

        #region 方法：根据条件查询
        /// <summary>
        /// 根据条件查询
        /// </summary>
        public void GetQueryby()
        {
            DateTime Starttime = dtpstart.Value;
            DateTime Stoptime = dtpend.Value;
            try
            {
                if (name == "生产总数")
                {
                    string str = "select SN as 条码,State as 状态,WorkStation as 工位,Time as 时间 from productiondata where Time>='" + Starttime.ToString("s") + "' and Time<='" + Stoptime.ToString("s") + "'and SN like '%" + txt_ProModule.Text + "%'";
                    DataSet ds = SQLiteConnect.getDataSet(str);
                    double Count = ds.Tables[0].Rows.Count;
                    labelCount.Text = Count.ToString();
                    dgvAInput.DataSource = ds.Tables[0];
                    InitDgv(dgvAInput);

                    string strOKCount = "select * from productiondata where State='OK'and Time>='" + Starttime.ToString("s") + "' and Time<='" + Stoptime.ToString("s") + "'and SN like '%" + txt_ProModule.Text + "%'";
                    DataSet dsOKCount = SQLiteConnect.getDataSet(strOKCount);
                    double OKCount = dsOKCount.Tables[0].Rows.Count;
                    labelOKCount.Text = OKCount.ToString();
                    double NGCount = Count - OKCount;
                    labelNGCount.Text = NGCount.ToString();
                    if (NGCount == 0)
                    {

                        labelNGCount.Text = "0";
                        labelNGToAll.Text = "0";
                        return;
                    }
                    if (OKCount == 0)
                    {
                        labelOKCount.Text = "0";
                        labelOKToAll.Text = "0";
                        return;
                    }
                    //获取OK比例和NG比例
                    labelOKToAll.Text = ((OKCount / Count) * 100) + "%";
                    labelNGToAll.Text = ((NGCount / Count) * 100) + "%";
                }
                else if (name == "左工位" || name == "右工位")
                {
                    string str = "select SN as 条码,State as 状态,WorkStation as 工位,Time as 时间 from productiondata where WorkStation='" + name + "' and Time>='" + Starttime.ToString("s") + "' and Time<='" + Stoptime.ToString("s") + "'and SN like '%" + txt_ProModule.Text + "%'";
                    DataSet ds = SQLiteConnect.getDataSet(str);
                    double Count = ds.Tables[0].Rows.Count;
                    labelCount.Text = Count.ToString();
                    if (name == "左工位")
                    {
                        dgvBInput.DataSource = ds.Tables[0];
                        InitDgv(dgvBInput);
                    }
                    else
                    {
                        dgvRetest.DataSource = ds.Tables[0];
                        InitDgv(dgvRetest);
                    }

                    string strOKCount = "select * from productiondata where State='OK' and WorkStation='" + name + "'and Time>='" + Starttime.ToString("s") + "' and Time<='" + Stoptime.ToString("s") + "'and SN like '%" + txt_ProModule.Text + "%'";
                    DataSet dsOKCount = SQLiteConnect.getDataSet(strOKCount);
                    double OKCount = dsOKCount.Tables[0].Rows.Count;
                    labelOKCount.Text = OKCount.ToString();
                    double NGCount = Count - OKCount;
                    labelNGCount.Text = NGCount.ToString();
                    if (NGCount == 0)
                    {
                        labelNGCount.Text = "0";
                        labelNGToAll.Text = "0";
                        return;
                    }
                    if (OKCount == 0)
                    {
                        labelOKCount.Text = "0";
                        labelOKToAll.Text = "0";
                        return;
                    }
                    labelOKToAll.Text = ((OKCount / Count) * 100) + "%";
                    labelNGCount.Text = ((NGCount / Count) * 100) + "%";
                }
                else if (name == "报警")
                {
                    string str = "select AlarmLevel as 报警名称,AlarmMessage as 报警信息,StartTime as 时间 from Alarm where StartTime>='" + Starttime.ToString("s") + "' and StartTime<='" + Stoptime.ToString("s") + "'and AlarmMessage like '%" + txt_ProModule.Text + "%'";
                    DataSet ds = SQLiteConnect.getDataSet(str);
                    double Count = ds.Tables[0].Rows.Count;
                    labelCount.Text = Count.ToString() + "条";
                    labelOKToAll.Text = "";
                    labelNGCount.Text = "";
                    labelNGToAll.Text = "";
                    labelOKToAll.Text = "";
                    dgvAboveCarA.DataSource = ds.Tables[0];
                    InitDgv(dgvAboveCarA);
                }
                else if (name == "不良")
                {
                    string strNG = "select SN as 条码,State as 状态,WorkStation as 工位,Time as 时间 from productiondata where State='NG' and WorkStation='" + name + "'and Time>='" + Starttime.ToString("s") + "' and Time<='" + Stoptime.ToString("s") + "'and SN like '%" + txt_ProModule.Text + "%'";
                    DataSet dsNG = SQLiteConnect.getDataSet(strNG);
                    double NGCount = dsNG.Tables[0].Rows.Count;
                    labelCount.Text = NGCount.ToString();
                    dgvAboveCarB.DataSource = dsNG.Tables[0];
                    InitDgv(dgvAboveCarB);
                    labelOKToAll.Text = "";
                    labelOKCount.Text = "";
                    labelNGToAll.Text = "";
                }

            }
            catch (Exception error)
            {
                MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.查询数据异常.ToString() + "\r\n" + error);
            }
        }
        #endregion
        private void ReportForm_Load(object sender, EventArgs e)
        {
            name = "生产总数";
            dtpstart.Value = DateTime.Now.Date;
            dtpend.Value = DateTime.Now;
            GetCount();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            GetCount();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteCount();
        }

        private void txt_ProModule_TextChanged(object sender, EventArgs e)
        {
            GetQueryby();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (name == "生产总数")
            {
                print(dgvAInput);
            }
            else if (name == "左工位")
            {
                print(dgvBInput);
            }
            else if (name == "右工位")
            {
                print(dgvRetest);
            }
            else if (name == "报警")
            {
                print(dgvAboveCarA);
            }
            else if (name == "不良")
            {
                print(dgvAboveCarB);
            }
        }

        public void print(DataGridView dataGridView)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridView.DataSource;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.Filter = "Excel File(*.xlsx)|*.xlsx";
            //选择保存路径
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            //获取路径
            string strName = saveFileDialog.FileName;
            //导入到Execl
            int i = Excelhelper.DataTableToExcel(dt, "sheet1", true, strName);
            if (i == -1)
            {
                MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.导出数据到Execl异常.ToString());
                return;
            }
            else
            {
                MessageBox.Show("数据导出成功","提示");
                return;
            }
        }
      
    }

}
