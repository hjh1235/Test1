using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public partial class Point_Form : Form
    {
        public Point_Form()
        {
            InitializeComponent();
            //处理掉DataGridViewComboBoxColumn绑定数据源后,再绑定到DataTable中的Column时,提示"System.ArgumentException:DagaGridViewComboBoxCell值无效"的错误
            this.dgvPointView.DataError += delegate (object sender, DataGridViewDataErrorEventArgs e) { };
        }
        int index = 0;
        string Name = "";
        string Station = "";
        string path = AppDomain.CurrentDomain.BaseDirectory + "流程点位";
        string Filepath = "";
        //RunClass runclass = new RunClass();
        public void ShowFromMessage(string name, string station)
        {
            lb_TaskName.Text = name;
            lb_Station.Text = station;
            Station = station;
            Filepath = path + "\\" + station + "\\" + name + ".csv";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ShowView(Filepath);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPointView.Rows.Add(new object[] { txtPointName.Text.Trim(), null, 0, 0, 0, "获取", "运动" });
            }
            catch (Exception ex)
            { }
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPointView.Rows.RemoveAt(index);
            }
            catch (Exception)
            { }

        }
        public void ShowView(string path)
        {

            DataTable dt = ImportCsvToDataTable(path);
            if (dt == null)
            {
                return;
            }
            dgvPointView.Rows.Clear();//清空行
            foreach (DataRow line in dt.Rows)
            {
                //因为列已经一致了，所以直接将datatable的行转成数组就可以添加到datagridview中了
                dgvPointView.Rows.Add(line.ItemArray);
            }
            dgvPointView.Columns[0].SortMode = //设置列排序模式
             DataGridViewColumnSortMode.NotSortable;
            dgvPointView.Columns[1].SortMode =//设置列排序模式
                 DataGridViewColumnSortMode.NotSortable;
            dgvPointView.Columns[2].SortMode =//设置列排序模式
               DataGridViewColumnSortMode.NotSortable;
            dgvPointView.Columns[0].ReadOnly = false;
        }

        private void dgvPointView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = dgvPointView.CurrentCell.RowIndex;
                Name = dgvPointView.Rows[index].Cells["名称"].Value.ToString();
                Moves moveXY = new Moves();
                Moves moveZ = new Moves();
                if (Station == "左工位")
                {
                    double dPosX, dPosY, dPosZ;
                    if (e.ColumnIndex == 5)//获取焊接位置
                    {
                        dPosX = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["左X主轴"].AisxCurrentPosition;
                        dPosY = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["左Y轴"].AisxCurrentPosition;
                        dPosZ = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["左Z轴"].AisxCurrentPosition;
                        dgvPointView.Rows[e.RowIndex].Cells[2].Value = dPosX;
                        dgvPointView.Rows[e.RowIndex].Cells[3].Value = dPosY;
                        dgvPointView.Rows[e.RowIndex].Cells[4].Value = dPosZ;
                    }
                    else if (e.ColumnIndex == 6)//走到焊接位置
                    {
                        dPosX = Convert.ToDouble(dgvPointView.Rows[e.RowIndex].Cells[2].Value);
                        dPosY = Convert.ToDouble(dgvPointView.Rows[e.RowIndex].Cells[3].Value);
                        dPosZ = Convert.ToDouble(dgvPointView.Rows[e.RowIndex].Cells[4].Value);
                        foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                        {
                            if (item.Value.Axis_hardwareName == "左X主轴")
                            {
                                mAxis _mAxis = new mAxis();
                                _mAxis.AxisName = item.Value.Axis_hardwareName;
                                _mAxis.AxisPosition = dPosX;
                                _mAxis.AxisSpeed = item.Value.Speed;
                                _mAxis.AxisAcc = item.Value.Acc;
                                _mAxis.AxisDec = item.Value.Dec;
                                moveXY.ListAxis.Add(_mAxis);
                            }
                            if (item.Value.Axis_hardwareName == "左Y轴")
                            {
                                mAxis _mAxis = new mAxis();
                                _mAxis.AxisName = item.Value.Axis_hardwareName;
                                _mAxis.AxisPosition = dPosY;
                                _mAxis.AxisSpeed = item.Value.Speed;
                                _mAxis.AxisAcc = item.Value.Acc;
                                _mAxis.AxisDec = item.Value.Dec;
                                moveXY.ListAxis.Add(_mAxis);
                            }
                            if (item.Value.Axis_hardwareName == "左Z轴")
                            {
                                mAxis _mAxis = new mAxis();
                                _mAxis.AxisName = item.Value.Axis_hardwareName;
                                _mAxis.AxisPosition = dPosZ;
                                _mAxis.AxisSpeed = item.Value.Speed;
                                _mAxis.AxisAcc = item.Value.Acc;
                                _mAxis.AxisDec = item.Value.Dec;
                                moveZ.ListAxis.Add(_mAxis);
                            }
                        }
                    }
                }
                else
                {
                    double dPosX, dPosY, dPosZ;
                    if (e.ColumnIndex == 5)//获取焊接位置
                    {
                        dPosX = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["右X主轴"].AisxCurrentPosition;
                        dPosY = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["右Y轴"].AisxCurrentPosition;
                        dPosZ = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["右Z轴"].AisxCurrentPosition;
                        dgvPointView.Rows[e.RowIndex].Cells[2].Value = dPosX;
                        dgvPointView.Rows[e.RowIndex].Cells[3].Value = dPosY;
                        dgvPointView.Rows[e.RowIndex].Cells[4].Value = dPosZ;
                    }
                    else if (e.ColumnIndex == 6)//移动到焊接位置
                    {
                        dPosX = Convert.ToDouble(dgvPointView.Rows[e.RowIndex].Cells[2].Value);
                        dPosY = Convert.ToDouble(dgvPointView.Rows[e.RowIndex].Cells[3].Value);
                        dPosZ = Convert.ToDouble(dgvPointView.Rows[e.RowIndex].Cells[4].Value);
                        foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                        {
                            if (item.Value.Axis_hardwareName == "右X主轴")
                            {
                                mAxis _mAxis = new mAxis();
                                _mAxis.AxisName = item.Value.Axis_hardwareName;
                                _mAxis.AxisPosition = dPosX;
                                _mAxis.AxisSpeed = item.Value.Speed;
                                _mAxis.AxisAcc = item.Value.Acc;
                                _mAxis.AxisDec = item.Value.Dec;
                                moveXY.ListAxis.Add(_mAxis);
                            }
                            if (item.Value.Axis_hardwareName == "右Y轴")
                            {
                                mAxis _mAxis = new mAxis();
                                _mAxis.AxisName = item.Value.Axis_hardwareName;
                                _mAxis.AxisPosition = dPosY;
                                _mAxis.AxisSpeed = item.Value.Speed;
                                _mAxis.AxisAcc = item.Value.Acc;
                                _mAxis.AxisDec = item.Value.Dec;
                                moveXY.ListAxis.Add(_mAxis);
                            }
                            if (item.Value.Axis_hardwareName == "右Z轴")
                            {
                                mAxis _mAxis = new mAxis();
                                _mAxis.AxisName = item.Value.Axis_hardwareName;
                                _mAxis.AxisPosition = dPosZ;
                                _mAxis.AxisSpeed = item.Value.Speed;
                                _mAxis.AxisAcc = item.Value.Acc;
                                _mAxis.AxisDec = item.Value.Dec;
                                moveZ.ListAxis.Add(_mAxis);
                            }
                        }
                    }
                }
                Task.Run(() =>
                {
                    if (moveXY.ListAxis.Count > 0 && moveZ.ListAxis.Count > 0)
                    {
                        int intRt = ManageContral.AxisPMoveAbsoluteToStop(moveXY);
                        if (intRt != 0)
                        {
                            MainForm.m_formAlarm.InsertAlarmMessage(Enum.GetName(typeof(ERecvResult), intRt) + "\r\n");
                            return;
                        }
                        if (Program.bEStop)
                        {
                            return;
                        }
                        intRt = ManageContral.AxisPMoveAbsoluteToStop(moveZ);
                        if (intRt != 0)
                        {
                            MainForm.m_formAlarm.InsertAlarmMessage(Enum.GetName(typeof(ERecvResult), intRt) + "\r\n");
                            return;
                        }
                    }
                });
            }
            catch (Exception ex)
            { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvPointView.EndEdit();
            //string path = AppDomain.CurrentDomain.BaseDirectory + "流程点位" + "\\" + lb_TaskName.Text+".csv";
            ExportToCSV(dgvPointView, Filepath);
        }
        public void ExportToCSV(DataGridView dgv, string fileName)
        {
            if (dgv.Rows.Count < 1)
            {
                MessageBox.Show("没有记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SaveFileDialog sfDialog = new SaveFileDialog();
            StreamWriter sw = new StreamWriter(fileName, false, Encoding.GetEncoding(-0));
            string strLine = "";
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                strLine += col.HeaderText.Trim() + ",";
            }
            sw.WriteLine(strLine);
            sw.Flush();

            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                strLine = "";
                foreach (DataGridViewCell dgvc in dgvr.Cells)
                {
                    strLine += dgvc.Value.ToString().Trim() + ",";
                }
                sw.WriteLine(strLine);
                sw.Flush();
            }
            sw.Close();
            MessageBox.Show(string.Format("数据已成功保存至{0}文件中!", fileName), "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        /// <summary>
        /// Stream读取.csv文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public DataTable ImportCsvToDataTable(string filePath)
        {
            FileStream fs = null;
            StreamReader sr = null;
            DataTable dt = new DataTable();
            try
            {
                if (!File.Exists(filePath))
                {
                    //MessageBox.Show("不存在该目录下文件,请刷新后再试", "提示");
                    return dt = null;
                }
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs, System.Text.Encoding.Default);
                //记录每次读取的一行记录
                string strLine = "";
                //记录每行记录中的各字段内容
                string[] aryLine;
                //标示列数
                int columnCount = 0;
                int firstCount = 0;
                Boolean first = true;
                //逐行读取CSV中的数据
                while ((strLine = sr.ReadLine()) != null)
                {
                    aryLine = strLine.Split(',');

                    columnCount = aryLine.Length;
                    if (first)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            dt.Columns.Add(aryLine[j].ToString());
                        }
                        first = false;
                        firstCount = columnCount;
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        if (firstCount < columnCount)
                        {
                            throw new Exception("最大列数不能大于表格起始列数");
                        }
                        for (int j = 0; j < columnCount; j++)
                        {
                            string str = aryLine[j];
                            dr[j] = str;
                        }
                        dt.Rows.Add(dr);
                    }
                }
                sr.Close();
                fs.Close();
                return dt;
            }
            catch (Exception e)
            {
                return dt;
                //throw e;
            }
        }

        //自动加载默认流程的运动点位
        public static void ImportCsvToData()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "流程点位";
            //获取默认流程名
            foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary)
            {
                if (item.Value.配方是否为默认 == "默认")
                {
                    filePath = filePath + "\\左工位\\" + item.Value.FlowChar_ControlDataName + ".csv";
                }
            }
        }

        /// <summary>
        /// 自动排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPointView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                                                e.RowBounds.Location.Y,
                                                dgvPointView.RowHeadersWidth - 4,
                                                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                   dgvPointView.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   dgvPointView.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btn_Loading_Click(object sender, EventArgs e)
        {
            string loadpath = "";
            OpenFileDialog openflg = new OpenFileDialog();
            openflg.InitialDirectory = path;
            openflg.Filter = "CSV|*.csv";//打开文件对话框筛选器
            if (DialogResult.OK == openflg.ShowDialog())
            {
                loadpath = openflg.FileName;
                ShowView(loadpath);
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            OperationDataGridview.UpDataGridView(dgvPointView);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            OperationDataGridview.DownDataGridView(dgvPointView);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPointName.Text == "")
                {
                    return;
                }
                object[] value = { txtPointName.Text.Trim(), null, 0, 0, 0, "获取", "运动" };
                List<int> indexInsert = OperationDataGridview.GetCellDataGridViewIndex(dgvPointView);
                dgvPointView.Rows.Insert(indexInsert[0], value);
            }
            catch (Exception)
            { }
        }

        private void btnWelding_Click(object sender, EventArgs e)
        {
            if (Program.bWelding == true)
            {
                return;
            }
            if (lb_Station.Text == "左工位")
            {
                if (Properties.Settings.Default.LeftPointTask != lb_TaskName.Text)
                {
                    MessageBox.Show("所选流程点位与自动流程点位不符,补焊只支持自动所选流程的点位");
                    return;
                }
            }
            else if (lb_Station.Text == "右工位")
            {
                if (Properties.Settings.Default.RightPointTask != lb_TaskName.Text)
                {
                    MessageBox.Show("所选流程点位与自动流程点位不符,补焊只支持自动所选流程的点位");
                    return;
                }
            }
            else
            {
                MessageBox.Show("程序自动运行中，请停止后再试");
                return;
            }
        }
        //获取点位数据
        public void getPointMessage(string name, string station)
        {
            string Station = station;
            string Filepath = path + "\\" + station + "\\" + name + ".csv";
        }

        private void Point_Form_Load(object sender, EventArgs e)
        {
        }
    }
    public static class OperationDataGridview
    {
        /// <summary>
        /// 行上移
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void UpDataGridView(DataGridView dataGridView)
        {
            try
            {
                //DataGridViewSelectedRowCollection dgvsrc = dataGridView.SelectedRows;//获取选中行的集合
                List<int> SelectIndex = GetCellDataGridViewIndex(dataGridView);
                if (SelectIndex.Count == 1)//单行上移
                {
                    int index = dataGridView.SelectedRows[0].Index;//获取当前选中行的索引
                    if (index > 0)//如果该行不是第一行
                    {
                        DataGridViewRow dgvr = dataGridView.Rows[index - 1];//获取选中行的上一行
                        dataGridView.Rows.RemoveAt(index - 1);//删除原选中行的上一行
                        dataGridView.Rows.Insert((index), dgvr);//将选中行的上一行插入到选中行的后面
                        for (int i = 0; i < 1; i++)//选中移动后的行
                        {
                            dataGridView.Rows[index - i - 1].Selected = true;
                        }
                    }
                }
                else//多行上移
                {
                    if (SelectIndex[0] > 0)
                    {
                        DataGridViewRow dgvr = dataGridView.Rows[SelectIndex[0] - 1];//获取选中行集合的上一行
                        dataGridView.Rows.RemoveAt(SelectIndex[0] - 1);//删除原选中行集合的上一行
                        dataGridView.Rows.Insert((SelectIndex[SelectIndex.Count - 1]), dgvr);//将选中行集合的上一行插入到选中行集合的后面
                        for (int i = 0; i < SelectIndex.Count; i++)//选中移动后的行
                        {
                            dataGridView.Rows[SelectIndex[i] - 1].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 行下移
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void DownDataGridView(DataGridView dataGridView)
        {
            try
            {
                //DataGridViewSelectedRowCollection dgvsrc = dataGridView.SelectedRows;//获取选中行的集合
                List<int> SelectIndex = GetCellDataGridViewIndex(dataGridView);
                if (SelectIndex.Count == 1) //单行下移
                {
                    int index = dataGridView.SelectedRows[0].Index;//获取当前选中行的索引
                    if (index >= 0 & (dataGridView.RowCount - 1) != index)//如果该行不是最后一行
                    {
                        DataGridViewRow dgvr = dataGridView.Rows[index + 1];//获取选中行的下一行
                        dataGridView.Rows.RemoveAt(index + 1);//删除原选中行的下一行
                        dataGridView.Rows.Insert((index), dgvr);//将选中行的上一行插入到选中行的后面
                        for (int i = 0; i < 1; i++)//选中移动后的行
                        {
                            dataGridView.Rows[index + 1 - i].Selected = true;
                        }
                    }
                }
                else//多行下移
                {
                    if (SelectIndex[SelectIndex.Count - 1] != dataGridView.RowCount - 1)
                    {
                        DataGridViewRow dgvr = dataGridView.Rows[SelectIndex[SelectIndex.Count - 1] + 1];//获取选中行集合的下一行
                        dataGridView.Rows.RemoveAt(SelectIndex[SelectIndex.Count - 1] + 1);//删除原选中行集合的下一行
                        dataGridView.Rows.Insert((SelectIndex[0]), dgvr);//将选中行集合的下一行插入到选中行集合的前面
                        for (int i = 0; i < SelectIndex.Count; i++)//选中移动后的行集合
                        {
                            dataGridView.Rows[SelectIndex[i] + 1].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void TopDataGridView(DataGridView dataGridView)
        {
            try
            {
                DataGridViewSelectedRowCollection dgvsrc = dataGridView.SelectedRows;//获取选中行的集合
                if (dgvsrc.Count > 0)
                {
                    int index = dataGridView.SelectedRows[0].Index;//获取当前选中行的索引
                    if (index > 0)//如果该行不是第一行
                    {
                        DataGridViewRow dgvr = dataGridView.Rows[index];//获取选中行的上一行
                        dataGridView.Rows.RemoveAt(index);//删除原选中行的上一行
                        dataGridView.Rows.Insert(0, dgvr);//将选中行的上一行插入到选中行的后面                       
                        for (int i = 0; i < dataGridView.Rows.Count; i++)//选中移动后的行
                        {
                            if (i != 0)
                            {
                                dataGridView.Rows[i].Selected = false;
                            }
                            else
                            {
                                dataGridView.Rows[i].Selected = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 置底
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void BottomDataGridView(DataGridView dataGridView)
        {
            try
            {
                DataGridViewSelectedRowCollection dgvsrc = dataGridView.SelectedRows;//获取选中行的集合
                if (dgvsrc.Count > 0)
                {
                    int index = dataGridView.SelectedRows[0].Index;//获取当前选中行的索引
                    if (index < dataGridView.Rows.Count - 1)//如果该行不是第一行
                    {
                        DataGridViewRow dgvr = dataGridView.Rows[index];//获取选中行的上一行
                        dataGridView.Rows.RemoveAt(index);//删除原选中行的上一行
                        int nCount = dataGridView.Rows.Count;
                        dataGridView.Rows.Insert(nCount, dgvr);//将选中行的上一行插入到选中行的后面
                        for (int i = 0; i < dataGridView.Rows.Count; i++)//选中移动后的行
                        {
                            if (i != dataGridView.Rows.Count - 1)
                            {
                                dataGridView.Rows[i].Selected = false;
                            }
                            else
                            {
                                dataGridView.Rows[i].Selected = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 获取DataGridView中选中行索引的集合
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        public static List<int> GetCellDataGridViewIndex(DataGridView dataGridView)
        {
            List<int> indexList = new List<int> { };
            int[] selIndexes = dataGridView.SelectedRows
                 .OfType<DataGridViewRow>()
                 .Select(x => x.Index)
                 .OrderBy(x => x)
                 .ToArray();
            foreach (int n in selIndexes)
            {
                indexList.Add(n);
            }
            return indexList;
        }

        /// <summary>
        /// 获取选中行数据的集合
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <returns></returns>
        public static List<DataGridViewRow> GetSelectRows(DataGridView dataGridView)
        {
            List<int> SelectListIndex = GetCellDataGridViewIndex(dataGridView);
            List<DataGridViewRow> SelectListRows = new List<DataGridViewRow> { };
            foreach (int i in SelectListIndex)
            {
                DataGridViewRow row = dataGridView.Rows[SelectListIndex[0]];
                //dataGridView.Rows.RemoveAt(SelectListIndex[0]);
                SelectListRows.Add(row);
            }
            return SelectListRows;
        }
    }
}
