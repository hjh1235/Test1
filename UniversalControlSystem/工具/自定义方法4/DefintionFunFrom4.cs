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
    public partial class DefintionFunFrom4 : Form
    {
        public DefintionFunFrom4()
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
        DefintionFun4 _DefintionFun4 /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {  
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _DefintionFun4 = (DefintionFun4)tools[Num];
            _StepControlName.Text= _DefintionFun4.FunName;
            if (_DefintionFun4.FlowChar_StepControlLoop == Num)
            {
                _DefintionFun4.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _DefintionFun4.FlowChar_StepControlLoop.ToString();
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

       
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _DefintionFun4.RunFun(_DefintionFun4);
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
             
            }
            catch (Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Aixs_one_Ctron _OutPut_Puse;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _OutPut_Puse = (Aixs_one_Ctron)tools[Step];
             

            }
            catch (Exception)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Aixs_one_Ctron Aixs_one_Ctron;
                int Step = Num;
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[_FlowChar_StepControlStepName];
                Aixs_one_Ctron = (Aixs_one_Ctron)tools[Step];
                Aixs_one_Ctron.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }

        private void _StepControlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DefintionFun4 _DefintionFun4;
                int Step = Num;
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[_FlowChar_StepControlStepName];
                _DefintionFun4 = (DefintionFun4)tools[Step];
                _DefintionFun4.FunName = _StepControlName.Text;
            }
            catch 
            {
            }          
        }
    }
}
