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
    public partial class CheckAixsRunFinishFrom : Form
    {
        public CheckAixsRunFinishFrom()
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
            //this.Hide();
        }
        string _RunFlowData_ControlDataName = "";
        string _FlowChar_StepControlStepName = "";
        int Num = 0;
        CheckAixsRunFinish _CheckAixsRunFinish /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {  
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _CheckAixsRunFinish = (CheckAixsRunFinish)tools[Num];
            _StepControlName.Text = _CheckAixsRunFinish.AixsName;
            if (_CheckAixsRunFinish.FlowChar_StepControlLoop == Num)
            {
                _CheckAixsRunFinish.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _CheckAixsRunFinish.FlowChar_StepControlLoop.ToString();
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
                _StepControlName.Items.Add(item.Value.Axis_hardwareName);
            }

        
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (ManageContral.DetectingAxis(_CheckAixsRunFinish.AixsName) == 0)
            {
                状态textBox1.Text = "停止中";
            }
            else
            {
                状态textBox1.Text = "运动中";
            }
          //  ManageContral.AxisPMoveAbsoluteToStop(_Aixs_one_Ctron.AixsName, _Aixs_one_Ctron.Pos, _Aixs_one_Ctron.Acc, _Aixs_one_Ctron.Dec, _Aixs_one_Ctron.Speed);
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
                CheckAixsRunFinish _OutPut_Puse ;
                int Step=int.Parse(步骤.Text);
                List<ImageTool> tools ;
                tools= LoadData._ImageToolRun[TOOLName.Text];
                _OutPut_Puse= (CheckAixsRunFinish)tools[Step];
                _OutPut_Puse.AixsName = _StepControlName.Text;
            }
            catch (Exception ex)
            {

                
            }
        }

        private void 次数_TextChanged(object sender, EventArgs e)
        {
  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void 位置textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Aixs_one_Ctron _OutPut_Puse;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _OutPut_Puse = (Aixs_one_Ctron)tools[Step];
               // _OutPut_Puse.Pos = Convert.ToDouble(位置textBox1.Text); 
            }
            catch (Exception ex)
            {
            }
        }

        private void 速度textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Aixs_one_Ctron _OutPut_Puse;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _OutPut_Puse = (Aixs_one_Ctron)tools[Step];
               // _OutPut_Puse.Speed = Convert.ToDouble(速度textBox2.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void 加速度textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Aixs_one_Ctron _OutPut_Puse;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _OutPut_Puse = (Aixs_one_Ctron)tools[Step];
               // _OutPut_Puse.Acc = Convert.ToDouble(加速度textBox3.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void 减速度textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Aixs_one_Ctron _OutPut_Puse;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _OutPut_Puse = (Aixs_one_Ctron)tools[Step];
               // _OutPut_Puse.Dec = Convert.ToDouble(减速度textBox4.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CheckAixsRunFinish CheckAixsRunFinish;
                int Step = Num;
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[_FlowChar_StepControlStepName];
                CheckAixsRunFinish = (CheckAixsRunFinish)tools[Step];
                CheckAixsRunFinish.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }
    }
}
