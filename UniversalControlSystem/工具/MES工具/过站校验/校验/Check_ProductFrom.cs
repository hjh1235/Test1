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
    public partial class Check_ProductFrom : Form
    {
        public Check_ProductFrom()
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
        Check_INPUT _Check_INPUT /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {
        

            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();

            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _Check_INPUT = (Check_INPUT)tools[Num];
            _StepControlName.Text= _Check_INPUT.IO_Name;
            次数.Text = _Check_INPUT._Check_INPUT(_Check_INPUT.IO_Name).ToString();

            检测状态.Text= _Check_INPUT.CheckIO_Sta ;
            延时.Text=_Check_INPUT.Delay .ToString();
            //次数.Text = _OutPut_Puse._Count.ToString();
            //延时.Text = _OutPut_Puse._Delay.ToString();
            if (_Check_INPUT.FlowChar_StepControlLoop == Num)
            {
                _Check_INPUT.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _Check_INPUT.FlowChar_StepControlLoop.ToString();
            }
            try
            {                
            }
            catch (Exception ex)
            {
            }
        }
        private void OutPut_Pulse_Load(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
            {
                _StepControlName.Items.Add(item.Value.hardIOName);
            }

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            次数.Text = _Check_INPUT._Check_INPUT(_Check_INPUT.IO_Name).ToString();
            //次数.Text=
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
                Check_INPUT _OutPut_Puse /*= new _OutPut_Puse()*/;
                int Step=int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools= LoadData._ImageToolRun[TOOLName.Text];
                _OutPut_Puse = (Check_INPUT)tools[Step];
                _OutPut_Puse.IO_Name = _StepControlName.Text;
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

        private void 检测状态_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Check_INPUT _Check_INPUT /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Check_INPUT = (Check_INPUT)tools[Step];
                _Check_INPUT.CheckIO_Sta = 检测状态.Text;
            }
            catch (Exception ex)
            {


            }

        }

        private void 延时_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Check_INPUT _Check_INPUT /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Check_INPUT = (Check_INPUT)tools[Step];
                _Check_INPUT.Delay =int.Parse( 延时.Text);
            }
            catch (Exception ex)
            {}
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Check_INPUT _Check_INPUT /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Check_INPUT = (Check_INPUT)tools[Step];
                _Check_INPUT.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception ex)
            { }
        }
    }
}
