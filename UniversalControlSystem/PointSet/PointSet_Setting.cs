using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public partial class PointSet_Setting : Form
    {
    ///    public static GoogolCardInfo hardInfo;
        public PointSet_Setting()
        {
            InitializeComponent();
           // hardInfo = Info;
        }
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }

        int LineNum = 0;
        public void ShowFromMessage()
        {
            int count = 0;
            label1.Text = hardwareName;
            dataGridView.Rows.Clear();
            for (int i = 0; i < Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData.Count; i++)
            {
                int idx = dataGridView.Rows.Add();
                dataGridView.Rows[idx].Tag = Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].点位名字;

                this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.Rows[idx].Height = 25;
                dataGridView.Rows[idx].Cells[0].Value = Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].点位名字;
                dataGridView.Rows[idx].Cells[1].Value = Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].DataStr;

            }
            //foreach (var item in Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary)
            //{
            //    int idx = dataGridView.Rows.Add();
            //    dataGridView.Rows[idx].Tag = item.Value._PointData[count].点位名字;

            //    this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //    dataGridView.Rows[idx].Height = 20;
            //    dataGridView.Rows[idx].Cells[0].Value = item.Value._PointData[count].点位名字;
            //    dataGridView.Rows[idx].Cells[1].Value = item.Value._PointData[count].DataStr;


            //    count++;

            //}

        }
        private void FormAxisSetting_Load(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                _AxisName.Items.Add(item.Value.Axis_hardwareName);
            }
        }
        private void txt_date_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txt_date_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_date_Leave(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_AxisName.Text != "" && 选中.Text != "")
            {
                for (int i = 0; i < Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData.Count; i++)
                {
                    if (Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].点位名字 == 选中.Text)
                    {

                        Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].__AisxNametData.Add(_AxisName.Text);

                        int idx = dgv_deviceList.Rows.Add();
                        dgv_deviceList.Rows[idx].Tag = _AxisName.Text;
                        this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                        dgv_deviceList.Rows[idx].Height = 25;
                        dgv_deviceList.Rows[idx].Cells[0].Value = _AxisName.Text;
                    }
                }
                //ChooseIndexName = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                //ChooseIndex = int.Parse(ChooseIndexName);

                //Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[]


            }
        }

        private void 添加点位_Click(object sender, EventArgs e)
        {
            if (__点位名称.Text != "")
            {
               
                PointData _AixsData = new PointData();
                _AixsData.点位名字 = __点位名称.Text;
                Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData.Add(_AixsData);


                int idx = dataGridView.Rows.Add();
                dataGridView.Rows[idx].Tag = __点位名称.Text;
                this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.Rows[idx].Height = 25;
                dataGridView.Rows[idx].Cells[0].Value = __点位名称.Text;


                //_Point_Control_Date_._PointData.Add(_AixsData);
                //Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_List.Add(_Point_Control_Date_);
                //Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary = Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_List.ToDictionary(p => p.Point_ControlDataName);

                //for (int i = 0; i < Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_List.Count; i++)
                //{
                //    Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_List[i]._PointData[i].AisxName

                //}
                //foreach (var items in Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary)
                //{
                //    items.Value._PointData[0].
                //    //   PointData _PointData = new PointData();

                //    //_PointData.AisxName
                //}
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            string ce = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            选中.Text = ce;
            LineNum = e.RowIndex;
            dgv_deviceList.Rows.Clear();
            for (int i = 0; i < Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[LineNum].__AisxNametData.Count; i++)
            {
                int idx = dgv_deviceList.Rows.Add();
                dgv_deviceList.Rows[idx].Tag = Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[LineNum].__AisxNametData[i];
                this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dgv_deviceList.Rows[idx].Height = 25;
                dgv_deviceList.Rows[idx].Cells[0].Value = Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[LineNum].__AisxNametData[i];
            }


            数据展示.Text= Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[LineNum].DataStr;
            int CIndex = e.ColumnIndex;
            if (CIndex == 2 && e.RowIndex != -1)
            {
                //更新数据
                for (int i = 0; i < Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData.Count; i++)
                {
                    if (Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].点位名字 == 选中.Text)
                    {
                        string data = "";
                        for (int j = 0; j < Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].__AisxNametData.Count; j++)
                        {

                            data += Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].__AisxNametData[j] + ":" + Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].__AisxNametData[j]].AisxCurrentPosition.ToString() + ";";
                        }
                        Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].DataStr = data;
                        dataGridView.Rows[LineNum].Cells[1].Value = Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].DataStr;
                    }
                }
            }
            else if (CIndex == 3 && e.RowIndex != -1)
            {
               string[] Str  =    Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[LineNum].DataStr.Split(';');
                for (int i = 0; i < Str.Length; i++)
                {
                    string[] _Str = Str[i].Split(':');
                    if (Str[i]!="")
                    {
                        string AxisName = _Str[0];
                        string Pos = _Str[1];
                        double _Pos = Convert.ToDouble(Pos);
                        ManageContral.AxisPMoveAbsoluteToStop(AxisName,
                                                                  _Pos,
                        Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[AxisName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[AxisName].Dec, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[AxisName].Speed);
                    }
                    //运动
                   
                  
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int Line = dgv_deviceList.CurrentRow.Index;
            Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[LineNum].__AisxNametData.RemoveAt(Line);           
            dgv_deviceList.Rows.RemoveAt(dgv_deviceList.SelectedRows[0].Index);

        }

        private void 数据更新_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData.Count; i++)
            {
                if (Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].点位名字 == 选中.Text)
                {
                    string data = "";
                    for (int j = 0; j < Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].__AisxNametData.Count; j++)
                    {

                        data += Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].__AisxNametData[j]+":"+ Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].__AisxNametData[j]].AisxCurrentPosition.ToString() + ";";


                    }
                    Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].DataStr = data;

                    dataGridView.Rows[LineNum].Cells[1].Value = Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].DataStr;
                    //Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[i].__AisxNametData.Add(_AxisName.Text);
                    //int idx = dgv_deviceList.Rows.Add();
                    //dgv_deviceList.Rows[idx].Tag = _AxisName.Text;
                    //this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    //dgv_deviceList.Rows[idx].Height = 25;
                    //dgv_deviceList.Rows[idx].Cells[0].Value = _AxisName.Text;
                }
            }
        }

        private void 更新数据_Click(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData[LineNum].DataStr = 数据展示.Text;
                dataGridView.Rows[LineNum].Cells[1].Value = 数据展示.Text;
            }
            catch
            {

             
            }
       
        }

        private void 移除点位_Click(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary[hardwareName]._PointData.RemoveAt(LineNum);
                dataGridView.Rows.RemoveAt(LineNum);
            }
            catch 
            {

               
            }
          
        }
    }
}
