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
    public partial class NegFrom : Form
    {
        public NegFrom()
        {
            InitializeComponent();
        }
        private bool isMouseDown = false;
        private Point FormLocation;     //form的location
        private Point mouseOffset;      //鼠标的按下位置
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

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string _RunFlowData_ControlDataName = "";
        string _FlowChar_StepControlStepName = "";
        int Num = 0;
        Neg _Neg /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];

            _Neg = (Neg)tools[Num];
            _Neg.FlowChar_StepControlNum = Num;
            DataGroup.Text = _Neg.DataGroup;
            if (_Neg.结果是否取反 == false)
            {
                结果是否取反.Text = "正常";
            }
            else
            {
                结果是否取反.Text = "取反";
            }
            if (_Neg.FlowChar_StepControlLoop == Num)
            {
                _Neg.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _Neg.FlowChar_StepControlLoop.ToString();
            }
            try
            {
                foreach (NegData itemTemp in _Neg.Data)
                {
                    DataGridViewRow rowAdd = new DataGridViewRow();

                    DataGridViewTextBoxCell IoNameCell = new DataGridViewTextBoxCell();
                    IoNameCell.Value = itemTemp.NegDataName;

                    string[] ListTepy = new string[] {/*"输入","输出" ,*/"数据组" };

                    DataGridViewComboBoxCell CardNameCell = new DataGridViewComboBoxCell();
                    foreach (var item in ListTepy)
                    {
                        CardNameCell.Items.Add(item);

                    }
                    CardNameCell.Value = itemTemp.NegDataTepy;
                    DataGridViewComboBoxCell DataTepyName = new DataGridViewComboBoxCell();
                    foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
                    {
                        DataTepyName.Items.Add(item.Value.Group_ControlDataName);
                    }

                    DataTepyName.Value = itemTemp.DataTepyName;



                   // DataGridViewCheckBoxCell IgnoreCell = new DataGridViewCheckBoxCell();




                  //  IgnoreCell.Value = itemTemp.IsNeg;



                    rowAdd.Cells.Add(IoNameCell);
                    rowAdd.Cells.Add(CardNameCell);
                    rowAdd.Cells.Add(DataTepyName);
                   // rowAdd.Cells.Add(IgnoreCell);

                    dataGridView.Rows.Add(rowAdd);
                }

            }
            catch (Exception ex)
            {
            }


        }
        private void OutPut_Pulse_Load(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
            {
                DataGroup.Items.Add(item.Value.Group_ControlDataName);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult DResult = MessageBox.Show("确定运行", "确定运行", MessageBoxButtons.YesNo);
            if (DResult == DialogResult.No)
            {
                return;
            }
            CallSubroutine _CallSubroutine /*= new _OutPut_Puse()*/;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _CallSubroutine = (CallSubroutine)tools[Step];
            if (_CallSubroutine._CallSub_Sta == "同步运行"&& _CallSubroutine._CallSub_RunSta==false)
            {
                //异步方法同步运行
                Task.Run(() =>
                {
                    _CallSubroutine.RunFun(_CallSubroutine);
                });
            }
            if (_CallSubroutine._CallSub_Sta == "等待运行完成" && _CallSubroutine._CallSub_RunSta == false)
            {      
                //异步方法
                Task.Run(() =>
                {
                    _CallSubroutine.RunFun(_CallSubroutine);
                });

            }
        }
        private void OutPut_PulseFrom_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
        private void OutPut_PulseFrom_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }
        private void OutPut_PulseFrom_MouseMove(object sender, MouseEventArgs e)
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
       

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Neg _Neg;
                int Step = Num;
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[_FlowChar_StepControlStepName];
                _Neg = (Neg)tools[Step];
                _Neg.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }

        private void buttonAddInput_Click(object sender, EventArgs e)
        {
            if (textBoxInputName.Text == "")
            {
                return;
            }
            try
            {
                NegData _NegData = new NegData();

                Neg _Neg;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Neg = (Neg)tools[Step];
                _Neg.Data.Add(_NegData);

                //_And._DataDic.Add(textBoxInputName.Text,_AndData);
                _NegData.NegDataName = textBoxInputName.Text;

                DataGridViewRow rowAdd = new DataGridViewRow();
                DataGridViewTextBoxCell IoNameCell = new DataGridViewTextBoxCell();
                IoNameCell.Value = _NegData.NegDataName;

                string[] ListTepy = new string[] {/*"输入","输出" ,*/"数据组" };

                DataGridViewComboBoxCell CardNameCell = new DataGridViewComboBoxCell();
                foreach (var item in ListTepy)
                {
                    CardNameCell.Items.Add(item);

                }
                CardNameCell.Value = _NegData.NegDataTepy;

                DataGridViewComboBoxCell DataTepyName = new DataGridViewComboBoxCell();

                foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
                {
                    DataTepyName.Items.Add(item.Value.Group_ControlDataName);
                }

                //for (int i = 0; i < Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.Count; i++)
                //{
                //    DataTepyName.Items.Add(Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List[i].hardIOName);
                //}
                DataTepyName.Value = _NegData.DataTepyName;

              //  DataGridViewCheckBoxCell IsNeg = new DataGridViewCheckBoxCell();
              //  IsNeg.Value = _NegData.IsNeg;


                rowAdd.Cells.Add(IoNameCell);
                rowAdd.Cells.Add(CardNameCell);
                rowAdd.Cells.Add(DataTepyName);
              //  rowAdd.Cells.Add(IsNeg);

                dataGridView.Rows.Add(rowAdd);

            }
            catch
            {

            }
        }

        private void buttonRemoveInput_Click(object sender, EventArgs e)
        {
            Neg _Neg;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _Neg = (Neg)tools[Step];
            if (dataGridView.SelectedRows.Count == 1)
            {
                //_And._DataDic.Remove(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
                _Neg.Data.RemoveAt(dataGridView.SelectedRows[0].Index);
                dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
            }
        }

        private void 结果是否取反_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Neg _Neg;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Neg = (Neg)tools[Step];
                if (结果是否取反.Text == "正常")
                {
                    _Neg.结果是否取反 = false;
                }
                else
                {
                    _Neg.结果是否取反 = true;
                }


            }
            catch (Exception es)
            {

            }
        }

        private void DataGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Neg _Neg;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Neg = (Neg)tools[Step];
                _Neg.DataGroup = DataGroup.Text;

            }
            catch (Exception es)
            {

            }
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Neg _Neg;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Neg = (Neg)tools[Step];
                _Neg.RunFlowData_ControlDataDescrptive = tbxToolName.Text;

            }
            catch (Exception es)
            {

            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Neg _Neg;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Neg = (Neg)tools[Step];
                string strName = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                //  AndData AndDir = _And._DataDic[strName];
                NegData NegList = _Neg.Data[e.RowIndex];

                NegData _NegData = _Neg.Data[e.RowIndex];
                _NegData.NegDataName = strName;

                string strValueRemark = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                //   AndDir.DataTepyName = strValueRemark;
                NegList.NegDataTepy = strValueRemark;
                _NegData.NegDataTepy = strValueRemark;


                string ValueRemark = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                //   AndDir.DataTepyName = strValueRemark;
                NegList.DataTepyName = ValueRemark;
                _NegData.DataTepyName = ValueRemark;


                //bool bValue = bool.Parse(dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());

                //NegList.IsNeg = bValue;
                //_NegData.IsNeg = bValue;



            }
            catch
            {

            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                Neg _Neg;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Neg = (Neg)tools[Step];
                _Neg.NegFun(_Neg);

                lblResult.BackColor = Color.Blue;

            }
            catch (Exception es)
            {

            }
        }
    }
}
