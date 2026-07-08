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
    public partial class OrFrom : Form
    {
        public OrFrom()
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
        Or _Or /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _Or = (Or)tools[Num];
            _Or.FlowChar_StepControlNum = Num;
            DataGroup.Text = _Or.DataGroup;
            if (_Or.结果是否取反 == false)
            {
                结果是否取反.Text = "正常";
            }
            else
            {
                结果是否取反.Text = "取反";
            }
            if (_Or.FlowChar_StepControlLoop == Num)
            {
                _Or.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _Or.FlowChar_StepControlLoop.ToString();
            }
            try
            {
                foreach (OrData itemTemp in _Or.Data)
                {
                    DataGridViewRow rowAdd = new DataGridViewRow();

                    DataGridViewTextBoxCell IoNameCell = new DataGridViewTextBoxCell();
                    IoNameCell.Value = itemTemp.OrDataName;

                    string[] ListTepy = new string[] {/*"输入","输出" ,*/"数据组" };

                    DataGridViewComboBoxCell CardNameCell = new DataGridViewComboBoxCell();
                    foreach (var item in ListTepy)
                    {
                        CardNameCell.Items.Add(item);

                    }
                    CardNameCell.Value = itemTemp.OrDataTepy;
                    DataGridViewComboBoxCell DataTepyName = new DataGridViewComboBoxCell();
                    foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
                    {
                        DataTepyName.Items.Add(item.Value.Group_ControlDataName);
                    }

                    DataTepyName.Value = itemTemp.DataTepyName;



                    DataGridViewCheckBoxCell IgnoreCell = new DataGridViewCheckBoxCell();




                    IgnoreCell.Value = itemTemp.IsNeg;



                    rowAdd.Cells.Add(IoNameCell);
                    rowAdd.Cells.Add(CardNameCell);
                    rowAdd.Cells.Add(DataTepyName);
                    rowAdd.Cells.Add(IgnoreCell);

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
                Or _Or;
                int Step = Num;
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[_FlowChar_StepControlStepName];
                _Or = (Or)tools[Step];
                _Or.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
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

        private void buttonAddInput_Click(object sender, EventArgs e)
        {
            if (textBoxInputName.Text == "")
            {
                return;
            }
            try
            {
                OrData _OrData = new OrData();

                Or _Or;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Or = (Or)tools[Step];
                _Or.Data.Add(_OrData);

                //_And._DataDic.Add(textBoxInputName.Text,_AndData);
                _OrData.OrDataName = textBoxInputName.Text;

                DataGridViewRow rowAdd = new DataGridViewRow();
                DataGridViewTextBoxCell IoNameCell = new DataGridViewTextBoxCell();
                IoNameCell.Value = _OrData.OrDataName;

                string[] ListTepy = new string[] {/*"输入","输出" ,*/"数据组" };

                DataGridViewComboBoxCell CardNameCell = new DataGridViewComboBoxCell();
                foreach (var item in ListTepy)
                {
                    CardNameCell.Items.Add(item);

                }
                CardNameCell.Value = _OrData.OrDataTepy;

                DataGridViewComboBoxCell DataTepyName = new DataGridViewComboBoxCell();

                foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
                {
                    DataTepyName.Items.Add(item.Value.Group_ControlDataName);
                }

                //for (int i = 0; i < Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.Count; i++)
                //{
                //    DataTepyName.Items.Add(Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List[i].hardIOName);
                //}
                DataTepyName.Value = _OrData.DataTepyName;

                DataGridViewCheckBoxCell IsNeg = new DataGridViewCheckBoxCell();
                IsNeg.Value = _OrData.IsNeg;


                rowAdd.Cells.Add(IoNameCell);
                rowAdd.Cells.Add(CardNameCell);
                rowAdd.Cells.Add(DataTepyName);
                rowAdd.Cells.Add(IsNeg);

                dataGridView.Rows.Add(rowAdd);

            }
            catch
            {

            }
        }

        private void buttonRemoveInput_Click(object sender, EventArgs e)
        {         
            Or _Or;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _Or = (Or)tools[Step];
            if (dataGridView.SelectedRows.Count == 1)
            {
                //_And._DataDic.Remove(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
                _Or.Data.RemoveAt(dataGridView.SelectedRows[0].Index);
                dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
            }
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Or _Or;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Or = (Or)tools[Step];
                _Or.RunFlowData_ControlDataDescrptive = tbxToolName.Text;

            }
            catch (Exception es)
            {

            }
        }

        private void 结果是否取反_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Or _Or;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Or = (Or)tools[Step];
                if (结果是否取反.Text == "正常")
                {
                    _Or.结果是否取反 = false;
                }
                else
                {
                    _Or.结果是否取反 = true;
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
                Or _Or;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Or = (Or)tools[Step];
                _Or.DataGroup = DataGroup.Text;

            }
            catch (Exception es)
            {

            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                Or _Or;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Or = (Or)tools[Step];
                _Or.OrFun(_Or);

                lblResult.BackColor = Color.Blue;

            }
            catch (Exception es)
            {

            }
        }

        private void dataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Or _Or;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Or = (Or)tools[Step];
                string strName = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                //  AndData AndDir = _And._DataDic[strName];
                OrData OrList = _Or.Data[e.RowIndex];

                OrData _OrData = _Or.Data[e.RowIndex];
                _OrData.OrDataName = strName;

                string strValueRemark = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                //   AndDir.DataTepyName = strValueRemark;
                OrList.OrDataTepy = strValueRemark;
                _OrData.OrDataTepy = strValueRemark;


                string ValueRemark = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                //   AndDir.DataTepyName = strValueRemark;
                OrList.DataTepyName = ValueRemark;
                _OrData.DataTepyName = ValueRemark;


                bool bValue = bool.Parse(dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());

                OrList.IsNeg = bValue;
                _OrData.IsNeg = bValue;



            }
            catch
            {

            }
        }
    }
}
