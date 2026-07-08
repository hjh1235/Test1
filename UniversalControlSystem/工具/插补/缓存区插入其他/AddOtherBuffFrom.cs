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
    public partial class AddOtherBuffFrom : Form
    {
        public AddOtherBuffFrom()
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
        AddOtherBuff _AddOtherBuff /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name, string StepName, int num)
        {
            TOOLName.Text = StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _AddOtherBuff = (AddOtherBuff)tools[Num];
            卡号textBox1.Text = _AddOtherBuff.CardNum.ToString();
            坐标系维度.Text = _AddOtherBuff.Cor.ToString();
            _类型.Text = _AddOtherBuff.ChooseTepy;
            延时.Text = _AddOtherBuff.Delay.ToString();
            IO编号.Text = _AddOtherBuff.IONum.ToString();

            if (_AddOtherBuff.FlowChar_StepControlLoop == Num)
            {
                _AddOtherBuff.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _AddOtherBuff.FlowChar_StepControlLoop.ToString();
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

         

        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddOtherBuff _AddOtherBuff;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _AddOtherBuff = (AddOtherBuff)tools[Step];
            if (_AddOtherBuff.ChooseTepy == "IO")
            {

                _AddOtherBuff.AddOtherBuffFun(_AddOtherBuff);
            }
            else
            {
                _AddOtherBuff.AddOtherBuffFun(_AddOtherBuff);
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

       


        private void 坐标系维度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                AddOtherBuff _AddOtherBuff;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _AddOtherBuff = (AddOtherBuff)tools[Step];
                _AddOtherBuff.Cor = int.Parse(坐标系维度.Text);
            }
            catch (Exception)
            {
            } 
        }
        private void 卡号textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                AddOtherBuff _AddOtherBuff;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _AddOtherBuff = (AddOtherBuff)tools[Step];
                _AddOtherBuff.CardNum = int.Parse(卡号textBox1.Text);
            }
            catch (Exception)
            {
            }
        }
        private void _类型_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AddOtherBuff _AddOtherBuff;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _AddOtherBuff = (AddOtherBuff)tools[Step];
                _AddOtherBuff.ChooseTepy =_类型.Text;
            }
            catch (Exception)
            {
            }
        }

        private void 延时_TextChanged(object sender, EventArgs e)
        {
            try
            {
                AddOtherBuff _AddOtherBuff;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _AddOtherBuff = (AddOtherBuff)tools[Step];
                _AddOtherBuff.Delay =int.Parse( 延时.Text);
            }
            catch (Exception)
            {
            }
        }

        private void IO编号_TextChanged(object sender, EventArgs e)
        {
            try
            {
                AddOtherBuff _AddOtherBuff;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _AddOtherBuff = (AddOtherBuff)tools[Step];
                _AddOtherBuff.IONum = int.Parse(IO编号.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                AddOtherBuff _AddOtherBuff;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _AddOtherBuff = (AddOtherBuff)tools[Step];
                _AddOtherBuff.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }

        }

        private void 状态_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AddOtherBuff _AddOtherBuff;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _AddOtherBuff = (AddOtherBuff)tools[Step];
                _AddOtherBuff.IONumSta = bool.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
            
        }
    }
}
