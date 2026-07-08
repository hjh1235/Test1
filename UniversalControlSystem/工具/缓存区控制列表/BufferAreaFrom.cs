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
    public partial class BufferAreaFrom : Form
    {
        public BufferAreaFrom()
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
        BufferArea _BufferArea /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _BufferArea = (BufferArea)tools[Num];
            功能选择.Text= _BufferArea.FunChoose;
            坐标系维度.Text = _BufferArea.Cor.ToString();
            卡号textBox1.Text = _BufferArea.CardNum.ToString();
            _轴1Name.Text= _BufferArea._轴1Name;
            _轴2Name.Text = _BufferArea._轴2Name;
            _轴3Name.Text = _BufferArea._轴3Name;
            _轴4Name.Text = _BufferArea._轴4Name;
            if (_BufferArea.FlowChar_StepControlLoop == Num)
            {
                _BufferArea.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _BufferArea.FlowChar_StepControlLoop.ToString();
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
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                _轴1Name.Items.Add(item.Value.Axis_hardwareName);
                _轴2Name.Items.Add(item.Value.Axis_hardwareName);
                _轴3Name.Items.Add(item.Value.Axis_hardwareName);
                _轴4Name.Items.Add(item.Value.Axis_hardwareName);
           
            }
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BufferArea _BufferArea;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _BufferArea = (BufferArea)tools[Step];
                _BufferArea.RunFun(_BufferArea);
            }
            catch (Exception)
            {
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
                BufferArea _BufferArea;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _BufferArea = (BufferArea)tools[Step];
                _BufferArea.FunChoose = 功能选择.Text;
            }
            catch (Exception)
            {
            }
        }

     
        private void 坐标系维度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BufferArea _BufferArea;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _BufferArea = (BufferArea)tools[Step];
                _BufferArea.Cor = int.Parse(坐标系维度.Text);
            }
            catch (Exception)
            {
            }
  
        }

        private void _轴2Name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _轴3Name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _轴4Name_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 卡号textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BufferArea _BufferArea;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _BufferArea = (BufferArea)tools[Step];
                _BufferArea.CardNum = int.Parse(卡号textBox1.Text);
            }
            catch (Exception)
            {
            }
          
        }

        private void _轴1Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BufferArea _BufferArea;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _BufferArea = (BufferArea)tools[Step];
                _BufferArea._轴1Name = _轴1Name.Text;
            }
            catch (Exception)
            {
            }
        }

        private void _轴2Name_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                BufferArea _BufferArea;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _BufferArea = (BufferArea)tools[Step];
                _BufferArea._轴2Name = _轴2Name.Text;
            }
            catch (Exception)
            {
            }
        }

        private void _轴3Name_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                BufferArea _BufferArea;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _BufferArea = (BufferArea)tools[Step];
                _BufferArea._轴3Name = _轴3Name.Text;
            }
            catch (Exception)
            {
            }
        }

        private void _轴4Name_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                BufferArea _BufferArea;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _BufferArea = (BufferArea)tools[Step];
                _BufferArea._轴4Name = _轴4Name.Text;
            }
            catch (Exception)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BufferArea BufferArea;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                BufferArea = (BufferArea)tools[Step];
                BufferArea.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }
    }
}
