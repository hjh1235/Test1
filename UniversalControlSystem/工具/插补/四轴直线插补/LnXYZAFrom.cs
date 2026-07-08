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
    public partial class LnXYZAFrom : Form
    {
        public LnXYZAFrom()
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
        LnXYZA _LnXYZA /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _LnXYZA = (LnXYZA)tools[Num];
            卡号textBox1.Text = _LnXYZA.CardNum.ToString();
            坐标系维度.Text = _LnXYZA.Cor.ToString();
            _轴1Name.Text = _LnXYZA._轴1Name;
            _轴2Name.Text = _LnXYZA._轴2Name;
            _轴3Name.Text = _LnXYZA._轴3Name;
            _轴4Name.Text = _LnXYZA._轴4Name;
            EndX.Text = _LnXYZA.EndX.ToString();
            EndY.Text = _LnXYZA.EndY.ToString();
            EndZ.Text = _LnXYZA.EndZ.ToString();
            EndA.Text = _LnXYZA.EndA.ToString();
            StartSpeed.Text = _LnXYZA.StartSpeed.ToString();
            EndSpeed.Text = _LnXYZA.EndSpeed.ToString();
            if (_LnXYZA.FlowChar_StepControlLoop == Num)
            {
                _LnXYZA.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _LnXYZA.FlowChar_StepControlLoop.ToString();
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
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                _轴3Name.Items.Add(item.Value.Axis_hardwareName);
            }
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                _轴4Name.Items.Add(item.Value.Axis_hardwareName);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA.GT_LnXYZA(_LnXYZA);
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
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA._轴1Name = _轴1Name.Text;
            }
            catch (Exception)
            {
            }
        }

     
        private void 坐标系维度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA.Cor = int.Parse(坐标系维度.Text);
            }
            catch (Exception)
            {
            }
        }

        private void _轴2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA._轴2Name = _轴2Name.Text;
            }
            catch (Exception)
            {
            }
        }

        private void _轴3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA._轴3Name = _轴3Name.Text;
            }
            catch (Exception)
            {
            }
        }

        private void _轴4Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA._轴4Name = _轴4Name.Text;
            }
            catch (Exception)
            {
            }
        }

        private void 卡号textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA.CardNum = int.Parse(卡号textBox1.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 速度获取_Click(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA.StartSpeed = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXYZA._轴1Name].Auto_Speed;
                _LnXYZA.EndSpeed = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXYZA._轴1Name].Auto_Speed;
                StartSpeed.Text = _LnXYZA.StartSpeed.ToString();
                EndSpeed.Text = _LnXYZA.EndSpeed.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void EndX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA.EndX =double.Parse( EndX.Text);
            }
            catch (Exception)
            {
            }
        }

        private void EndY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA.EndY = double.Parse(EndY.Text);
            }
            catch (Exception)
            {
            }
        }

        private void EndZ_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA.EndZ = double.Parse(EndZ.Text);
            }
            catch (Exception)
            {
            }
        }

        private void EndA_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA.EndA = double.Parse(EndA.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 终点坐标获取_Click(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                EndX.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXYZA._轴1Name].AisxCurrentPosition.ToString();
                _LnXYZA.EndX = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXYZA._轴1Name].AisxCurrentPosition;

                EndY.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXYZA._轴2Name].AisxCurrentPosition.ToString();
                _LnXYZA.EndY = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXYZA._轴2Name].AisxCurrentPosition;

                EndZ.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXYZA._轴3Name].AisxCurrentPosition.ToString();
                _LnXYZA.EndZ = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXYZA._轴3Name].AisxCurrentPosition;

                EndA.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXYZA._轴4Name].AisxCurrentPosition.ToString();
                _LnXYZA.EndA = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_LnXYZA._轴4Name].AisxCurrentPosition;


            }
            catch (Exception)
            {
            }
        }

        private void StartSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA.StartSpeed = double.Parse(StartSpeed.Text);
            }
            catch (Exception)
            {
            }
        }

        private void EndSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA.EndSpeed = double.Parse(EndSpeed.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LnXYZA _LnXYZA;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LnXYZA = (LnXYZA)tools[Step];
                _LnXYZA.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }
    }
}
