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
    public partial class DimetricFrom : Form
    {
        public DimetricFrom()
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
        Dimetric _Dimetric /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _Dimetric = (Dimetric)tools[Num];
            _轴1Name.Text= _Dimetric._轴1Name;
            _轴2Name.Text = _Dimetric._轴2Name;
          
            坐标系维度.Text = _Dimetric.Cor.ToString();
            StartSpeed.Text= _Dimetric.StartSpeed .ToString();
            EndSpeed.Text = _Dimetric.EndSpeed.ToString();
            加速度textBox3.Text= _Dimetric.Acc.ToString();
            减速度textBox4.Text= _Dimetric.Dec.ToString();
            txt_RecLenght.Text= _Dimetric.RecLenght.ToString();
            txt_RecWidth.Text= _Dimetric.RecWidth.ToString();
            txt_R.Text= _Dimetric.R.ToString();
            if (_Dimetric.FlowChar_StepControlLoop == Num)
            {
                _Dimetric.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _Dimetric.FlowChar_StepControlLoop.ToString();
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
            }
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                _轴2Name.Items.Add(item.Value.Axis_hardwareName);
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dimetric Dimetric /*= new _OutPut_Puse()*/;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            Dimetric = (Dimetric)tools[Step];
            Dimetric.MoveRec(Dimetric);
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
                Dimetric Dimetric /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Dimetric = (Dimetric)tools[Step];
                Dimetric._轴1Name =_轴1Name.Text;
            }
            catch (Exception ex)
            {

                
            }
        }

     
        private void 坐标系维度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Dimetric Dimetric /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Dimetric = (Dimetric)tools[Step];
                Dimetric.Cor =int.Parse(坐标系维度.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void _轴2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Dimetric Dimetric /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Dimetric = (Dimetric)tools[Step];
                Dimetric._轴2Name = _轴2Name.Text;
            }
            catch (Exception ex)
            {


            }
        }

     


        private void 卡号textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Dimetric Dimetric /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Dimetric = (Dimetric)tools[Step];
                Dimetric.CardNum = int.Parse(卡号textBox1.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Dimetric Dimetric;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Dimetric = (Dimetric)tools[Step];
                Dimetric.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }

        private void StartSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Dimetric Dimetric;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Dimetric = (Dimetric)tools[Step];
                Dimetric.StartSpeed = int.Parse(StartSpeed.Text);
            }
            catch (Exception)
            {
            }
        }

        private void EndSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Dimetric Dimetric;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Dimetric = (Dimetric)tools[Step];
                Dimetric.EndSpeed = int.Parse(EndSpeed.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 加速度textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Dimetric Dimetric;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Dimetric = (Dimetric)tools[Step];
                Dimetric.Acc = int.Parse(加速度textBox3.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 减速度textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Dimetric Dimetric;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Dimetric = (Dimetric)tools[Step];
                Dimetric.Dec = int.Parse(减速度textBox4.Text);
            }
            catch (Exception)
            {
            }
        }

        private void txt_RecLenght_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Dimetric Dimetric;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Dimetric = (Dimetric)tools[Step];
                Dimetric.RecLenght = int.Parse(txt_RecLenght.Text);
            }
            catch (Exception)
            {
            }
        }

        private void txt_RecWidth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Dimetric Dimetric;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Dimetric = (Dimetric)tools[Step];
                Dimetric.RecWidth = int.Parse(txt_RecWidth.Text);
            }
            catch (Exception)
            {
            }
        }

        private void txt_R_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Dimetric Dimetric;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Dimetric = (Dimetric)tools[Step];
                Dimetric.R = int.Parse(txt_R.Text);
            }
            catch (Exception)
            {
            }
        }
    }
}
