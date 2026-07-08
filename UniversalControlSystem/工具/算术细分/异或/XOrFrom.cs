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
    public partial class XOrFrom : Form
    {
        public XOrFrom()
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
        XOr _XOr /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _XOr = (XOr)tools[Num];

            _XOr.FlowChar_StepControlNum = Num;
            DataGroup.Text = _XOr.DataGroup;
            if (_XOr.结果是否取反 == false)
            {
                结果是否取反.Text = "正常";
            }
            else
            {
                结果是否取反.Text = "取反";
            }
            if (_XOr.FlowChar_StepControlLoop == Num)
            {
                _XOr.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _XOr.FlowChar_StepControlLoop.ToString();
            }
            try
            {

                foreach (XOrData itemTemp in _XOr.Data)
                {
                    DataGridViewRow rowAdd = new DataGridViewRow();

                    DataGridViewTextBoxCell IoNameCell = new DataGridViewTextBoxCell();
                    IoNameCell.Value = itemTemp.XOrDataName;

                    string[] ListTepy = new string[] {/*"输入","输出" ,*/"数据组" };

                    DataGridViewComboBoxCell CardNameCell = new DataGridViewComboBoxCell();
                    foreach (var item in ListTepy)
                    {
                        CardNameCell.Items.Add(item);

                    }



                    CardNameCell.Value = itemTemp.XOrDataTepy;

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
                XOr _XOr;
                int Step = Num;
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[_FlowChar_StepControlStepName];
                _XOr = (XOr)tools[Step];
                _XOr.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
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
                XOrData _XOrData = new XOrData();

                XOr _XOr;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _XOr = (XOr)tools[Step];
                _XOr.Data.Add(_XOrData);

                //_And._DataDic.Add(textBoxInputName.Text,_AndData);
                _XOrData.XOrDataName = textBoxInputName.Text;

                DataGridViewRow rowAdd = new DataGridViewRow();
                DataGridViewTextBoxCell IoNameCell = new DataGridViewTextBoxCell();
                IoNameCell.Value = _XOrData.XOrDataName;

                string[] ListTepy = new string[] {/*"输入","输出" ,*/"数据组" };

                DataGridViewComboBoxCell CardNameCell = new DataGridViewComboBoxCell();
                foreach (var item in ListTepy)
                {
                    CardNameCell.Items.Add(item);

                }
                CardNameCell.Value = _XOrData.XOrDataTepy;

                DataGridViewComboBoxCell DataTepyName = new DataGridViewComboBoxCell();

                foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
                {
                    DataTepyName.Items.Add(item.Value.Group_ControlDataName);
                }

                //for (int i = 0; i < Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.Count; i++)
                //{
                //    DataTepyName.Items.Add(Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List[i].hardIOName);
                //}
                DataTepyName.Value = _XOrData.DataTepyName;

                DataGridViewCheckBoxCell IsNeg = new DataGridViewCheckBoxCell();
                IsNeg.Value = _XOrData.IsNeg;


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
            XOr _XOr;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _XOr = (XOr)tools[Step];
            if (dataGridView.SelectedRows.Count == 1)
            {
                //_And._DataDic.Remove(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
                _XOr.Data.RemoveAt(dataGridView.SelectedRows[0].Index);
                dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
            }
        }

        private void 结果是否取反_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                XOr _XOr;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _XOr = (XOr)tools[Step];
                if (结果是否取反.Text == "正常")
                {
                    _XOr.结果是否取反 = false;
                }
                else
                {
                    _XOr.结果是否取反 = true;
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
                XOr _XOr;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _XOr = (XOr)tools[Step];
                _XOr.DataGroup = DataGroup.Text;

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

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                XOr _XOr;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _XOr = (XOr)tools[Step];
                _XOr.RunFlowData_ControlDataDescrptive = tbxToolName.Text;

            }
            catch (Exception es)
            {

            }
        }

        private void dataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                XOr _XOr;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _XOr = (XOr)tools[Step];
                string strName = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                //  AndData AndDir = _And._DataDic[strName];
                XOrData XOrList = _XOr.Data[e.RowIndex];

                XOrData _XOrData = _XOr.Data[e.RowIndex];
                _XOrData.XOrDataName = strName;

                string strValueRemark = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                //   AndDir.DataTepyName = strValueRemark;
                XOrList.XOrDataTepy = strValueRemark;
                _XOrData.XOrDataTepy = strValueRemark;


                string ValueRemark = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                //   AndDir.DataTepyName = strValueRemark;
                XOrList.DataTepyName = ValueRemark;
                _XOrData.DataTepyName = ValueRemark;


                bool bValue = bool.Parse(dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());

                XOrList.IsNeg = bValue;
                _XOrData.IsNeg = bValue;



            }
            catch
            {

            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                XOr _XOr;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _XOr = (XOr)tools[Step];
                _XOr.XOrFun(_XOr);

                lblResult.BackColor = Color.Blue;

            }
            catch (Exception es)
            {

            }
        }
    }
}
