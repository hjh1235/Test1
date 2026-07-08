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
    public partial class OutPut_PulseFrom : Form
    {
        public OutPut_PulseFrom()
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
        public void ShowMesage(string Name,string StepName, int num)
        {
        

            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            OutPut_Puse _OutPut_Puse /*= new _OutPut_Puse()*/;
            List<ImageTool> tools /*= new List<ImageTool>()*/;

            tools = LoadData._ImageToolRun[TOOLName.Text];
            _OutPut_Puse = (OutPut_Puse)tools[Num];
            _StepControlName.Text= _OutPut_Puse.IO_Name;
            次数.Text = _OutPut_Puse._Count.ToString();
            延时.Text = _OutPut_Puse._Delay.ToString();

            if (_OutPut_Puse.FlowChar_StepControlLoop == Num)
            {
                _OutPut_Puse.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _OutPut_Puse.FlowChar_StepControlLoop.ToString();
            }
            if (_OutPut_Puse.FlowChar_StepControlLoop!=-1)
            {
            }
            步骤跳转.Text= _OutPut_Puse.FlowChar_StepControlLoop.ToString();
            try
            {                
            }
            catch (Exception ex)
            {
            }
        }
        private void OutPut_Pulse_Load(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
            {
                _StepControlName.Items.Add(item.Value.hardIOName);
            }

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string   bitName =_StepControlName.Text;
            int count = int.Parse(次数.Text);
            int delay= int.Parse(延时.Text);
            for (int i = 0; i < count; i++)
            {

                ManageContral.SetOutBit(bitName, true);
                Thread.Sleep(delay);
                ManageContral.SetOutBit(bitName, false);
                Thread.Sleep(delay);
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
                OutPut_Puse _OutPut_Puse /*= new _OutPut_Puse()*/;
               

                int Step=int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;

                tools= LoadData._ImageToolRun[TOOLName.Text];
                _OutPut_Puse= (OutPut_Puse)tools[Step];
                _OutPut_Puse.IO_Name = _StepControlName.Text;
                //tools[Step].

                //Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[_RunFlowData_ControlDataName].dicFlowData[_FlowChar_StepControlStepName]._RunFlowData[Num].FlowChar_StepControlName= _StepControlName.Text;

            }
            catch (Exception ex)
            {

                
            }
        }

        private void 次数_TextChanged(object sender, EventArgs e)
        {
            try
            {

                int Time = int.Parse(次数.Text);
                OutPut_Puse _OutPut_Puse /*= new _OutPut_Puse()*/;


                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;

                tools = LoadData._ImageToolRun[TOOLName.Text];
                _OutPut_Puse = (OutPut_Puse)tools[Step];

                _OutPut_Puse._Count = Time;
                //tools[Step].

                //Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[_RunFlowData_ControlDataName].dicFlowData[_FlowChar_StepControlStepName]._RunFlowData[Num].FlowChar_StepControlName= _StepControlName.Text;

            }
            catch (Exception ex)
            {


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                int Delay = int.Parse(延时.Text);
                OutPut_Puse _OutPut_Puse /*= new _OutPut_Puse()*/;


                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;

                tools = LoadData._ImageToolRun[TOOLName.Text];
                _OutPut_Puse = (OutPut_Puse)tools[Step];

                _OutPut_Puse._Delay = Delay;
                //tools[Step].

                //Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[_RunFlowData_ControlDataName].dicFlowData[_FlowChar_StepControlStepName]._RunFlowData[Num].FlowChar_StepControlName= _StepControlName.Text;

            }
            catch (Exception ex)
            {


            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int Time = int.Parse(次数.Text);
                OutPut_Puse _OutPut_Puse /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _OutPut_Puse = (OutPut_Puse)tools[Step];
                _OutPut_Puse.FlowChar_StepControlLoop =int.Parse( 步骤跳转.Text);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
