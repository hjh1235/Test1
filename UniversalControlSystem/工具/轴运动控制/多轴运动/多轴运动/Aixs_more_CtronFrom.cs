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
    public partial class Aixs_more_CtronFrom : Form
    {
        public Aixs_more_CtronFrom()
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
        Aixs_more_Ctron _Aixs_more_Ctron /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {  
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _Aixs_more_Ctron = (Aixs_more_Ctron)tools[Num];
            for (int i = 0; i < _Aixs_more_Ctron.Data.Count; i++)
            {
                int idx = dgv_deviceList.Rows.Add();
                dgv_deviceList.Rows[idx].Tag = _Aixs_more_Ctron.Data[i].AixsName;
                this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dgv_deviceList.Rows[idx].Height = 25;
                dgv_deviceList.Rows[idx].Cells[0].Value = _Aixs_more_Ctron.Data[i].AixsName;
            }
            if (_Aixs_more_Ctron.FlowChar_StepControlLoop == Num)
            {
                _Aixs_more_Ctron.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _Aixs_more_Ctron.FlowChar_StepControlLoop.ToString();
            }
            try
            {                
            }
            catch 
            {
            }
        }
        private void OutPut_Pulse_Load(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                _AxisName.Items.Add(item.Value.Axis_hardwareName);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _Aixs_more_Ctron.Data.Count; i++)
            {
                _Aixs_more_Ctron.AxisPMoveAbsoluteToStop(_Aixs_more_Ctron.Data[i].AixsName, _Aixs_more_Ctron.Data[i].Pos, _Aixs_more_Ctron.Data[i].Acc, _Aixs_more_Ctron.Data[i].Dec, _Aixs_more_Ctron.Data[i].Speed);
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Aixs_one_Ctron _OutPut_Puse /*= new _OutPut_Puse()*/;
                int Step=int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools= LoadData._ImageToolRun[TOOLName.Text];
                _OutPut_Puse= (Aixs_one_Ctron)tools[Step];
                _OutPut_Puse.AixsName = _StepControlName.Text;
            }
            catch (Exception ex)
            {
            }
        }
        private void 位置textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double pos=Convert.ToDouble(位置textBox1.Text);
                Aixs_more_Ctron _Aixs_more_Ctron;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Aixs_more_Ctron = (Aixs_more_Ctron)tools[Step];
                int Line = dgv_deviceList.CurrentRow.Index;
                _Aixs_more_Ctron.Data[Line].Pos = pos;
            }
            catch (Exception ex)
            {
            }
        }

        private void 速度textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Aixs_more_Ctron _Aixs_more_Ctron;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Aixs_more_Ctron = (Aixs_more_Ctron)tools[Step];
                int Line = dgv_deviceList.CurrentRow.Index;
                _Aixs_more_Ctron.Data[Line].Speed = Convert.ToDouble(速度textBox2.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void 加速度textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Aixs_more_Ctron _Aixs_more_Ctron;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Aixs_more_Ctron = (Aixs_more_Ctron)tools[Step];
                int Line = dgv_deviceList.CurrentRow.Index;
                _Aixs_more_Ctron.Data[Line].Acc = Convert.ToDouble(加速度textBox3.Text);

             
            }
            catch 
            {
            }
        }

        private void 减速度textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Aixs_more_Ctron _Aixs_more_Ctron;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Aixs_more_Ctron = (Aixs_more_Ctron)tools[Step];
                int Line = dgv_deviceList.CurrentRow.Index;
                _Aixs_more_Ctron.Data[Line].Dec = Convert.ToDouble(减速度textBox4.Text);

 
            }
            catch (Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Aixs_more_Ctron _Aixs_more_Ctron;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Aixs_more_Ctron = (Aixs_more_Ctron)tools[Step];
                int Line = dgv_deviceList.CurrentRow.Index;

                _Aixs_more_Ctron.Data[Line].Pos = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Aixs_more_Ctron.Data[Line].AixsName].AisxCurrentPosition;
                位置textBox1.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Aixs_more_Ctron.Data[Line].AixsName].AisxCurrentPosition.ToString();

            }
            catch (Exception)
            {
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (_AxisName.Text!="")
            {
                int idx = dgv_deviceList.Rows.Add();
                dgv_deviceList.Rows[idx].Tag = _AxisName.Text;
                this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dgv_deviceList.Rows[idx].Height = 25;
                dgv_deviceList.Rows[idx].Cells[0].Value = _AxisName.Text;
                Aixs_more_Ctron _Aixs_more_Ctron;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Aixs_more_Ctron = (Aixs_more_Ctron)tools[Step];
                AixsData _AixsData = new AixsData();
                _Aixs_more_Ctron.Data.Add(_AixsData);
                _Aixs_more_Ctron.Data[_Aixs_more_Ctron.Data.Count - 1].AixsName = _AxisName.Text;
            }
        }
        private void _AxisName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void dgv_deviceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Name = dgv_deviceList.Rows[e.RowIndex].Cells[0].Value.ToString();
                _StepControlName.Text = Name;
                int Line = dgv_deviceList.CurrentRow.Index;
                Aixs_more_Ctron _Aixs_more_Ctron;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Aixs_more_Ctron = (Aixs_more_Ctron)tools[Step];
                速度textBox2.Text= _Aixs_more_Ctron.Data[Line].Speed.ToString();
                位置textBox1.Text = _Aixs_more_Ctron.Data[Line].Pos.ToString();
                加速度textBox3.Text = _Aixs_more_Ctron.Data[Line].Acc.ToString();
                减速度textBox4.Text = _Aixs_more_Ctron.Data[Line].Dec.ToString();
            }
            catch (Exception)
            {
            }
        }
        private void dgv_deviceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int Line = dgv_deviceList.CurrentRow.Index;
            _Aixs_more_Ctron.Data.RemoveAt(Line);
            dgv_deviceList.Rows.RemoveAt(dgv_deviceList.SelectedRows[0].Index);
        }
        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Aixs_more_Ctron _Aixs_more_Ctron;
                int Step = Num;
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[_FlowChar_StepControlStepName];
                _Aixs_more_Ctron = (Aixs_more_Ctron)tools[Step];
                _Aixs_more_Ctron.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }
    }
}
