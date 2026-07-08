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
    public partial class ArcXYCFrom : Form
    {
        public ArcXYCFrom()
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
        ArcXYC _ArcXYC /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name, string StepName, int num)
        {
            TOOLName.Text = StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _ArcXYC = (ArcXYC)tools[Num];
            卡号textBox1.Text = _ArcXYC.CardNum.ToString();
            坐标系维度.Text = _ArcXYC.Cor.ToString();
            StartX.Text = _ArcXYC.StartX.ToString();
            StartY.Text = _ArcXYC.StartY.ToString();
            CenterX.Text = _ArcXYC.CenterX.ToString();
            CenterY.Text = _ArcXYC.CenterY.ToString();
            EndX.Text = _ArcXYC.EndX.ToString();
            EndY.Text = _ArcXYC.EndY.ToString();
            RX.Text = _ArcXYC.RX.ToString();
            RY.Text = _ArcXYC.RY.ToString();
            _轴1Name.Text = _ArcXYC._轴1Name;
            _轴2Name.Text = _ArcXYC._轴2Name;
            StartSpeed.Text = _ArcXYC.StartSpeed.ToString();
            EndSpeed.Text = _ArcXYC.EndSpeed.ToString();
            if (_ArcXYC.FlowChar_StepControlLoop == Num)
            {
                _ArcXYC.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _ArcXYC.FlowChar_StepControlLoop.ToString();
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
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                _ArcXYC.GT_ArcXYC(_ArcXYC);
            }
            catch 
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

        private void 坐标系维度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                _ArcXYC.Cor =int.Parse( 坐标系维度.Text);
            }
            catch (Exception)
            {
            }
          
        }

        private void _轴2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                _ArcXYC._轴1Name = _轴1Name.Text;
            }
            catch (Exception ex)
            {


            }
        }

        private void _轴3Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                _ArcXYC._轴2Name = _轴2Name.Text;

            }
            catch (Exception ex)
            {


            }
        }
        private void 卡号textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];

                _ArcXYC.CardNum = int.Parse(卡号textBox1.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 起点坐标获取_Click(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                StartX.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].AisxCurrentPosition.ToString();
                _ArcXYC.StartX = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].AisxCurrentPosition;

                StartY.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴2Name].AisxCurrentPosition.ToString();
                _ArcXYC.StartY = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴2Name].AisxCurrentPosition;
            }
            catch (Exception)
            {
            }
        }

        private void 过渡坐标获取_Click(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                CenterX.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].AisxCurrentPosition.ToString();
                _ArcXYC.CenterX = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].AisxCurrentPosition;

                CenterY.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴2Name].AisxCurrentPosition.ToString();
                _ArcXYC.CenterY = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴2Name].AisxCurrentPosition;
            }
            catch (Exception)
            {
            }
        }

        private void 终点坐标获取_Click(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                EndX.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].AisxCurrentPosition.ToString();
                _ArcXYC.EndX = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].AisxCurrentPosition;

                EndY.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴2Name].AisxCurrentPosition.ToString();
                _ArcXYC.EndY = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴2Name].AisxCurrentPosition;
            }
            catch (Exception)
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ArcXYC _ArcXYC;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _ArcXYC = (ArcXYC)tools[Step];
            GetCircleParameters(_ArcXYC);
            RX.Text= _ArcXYC.RX.ToString();
            RY.Text = _ArcXYC.RY.ToString();
        }
        public PointF GetCentre(PointF P1, PointF P2, PointF P3)
        {
            double a13 = P1.X - P3.X;
            double a13_ = P1.X + P3.X;
            double b13 = P1.Y - P3.Y;
            double b13_ = P1.Y + P3.Y;
            double a12 = P1.X - P2.X;
            double a12_ = P1.X + P2.X;
            double b12 = P1.Y - P2.Y;
            double b12_ = P1.Y + P2.Y;

            double a12b12_2 = a12 * a12_ + b12 * b12_;
            double a13b13_2 = a13 * a13_ + b13 * b13_;

            double a13b12 = 2 * a13 * b12;
            double a12b13 = 2 * a12 * b13;


            if (a12b13 - a13b12 == 0) return new PointF((P2.X + P1.X) / 2, (P2.Y + P1.Y) / 2);
            double af = a12b13 - a13b12;
            double bf = a13b12 - a12b13;
            double az = b13 * a12b12_2 - b12 * a13b13_2;
            double bz = a13 * a12b12_2 - a12 * a13b13_2;
            double a = az / af;
            double b = bz / bf;
            return new PointF((float)a, (float)b);

        }

        private void StartX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];  
                _ArcXYC.StartX =Convert.ToDouble(StartX.Text); 
            }
            catch (Exception)
            {
            }
        }

        private void StartY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                _ArcXYC.StartY = Convert.ToDouble(StartY.Text);
            }
            catch (Exception)
            {
            }
        }

        private void CenterX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                _ArcXYC.CenterX = Convert.ToDouble(CenterX.Text);
            }
            catch (Exception)
            {
            }
        }

        private void CenterY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                _ArcXYC.CenterY = Convert.ToDouble(CenterY.Text);
            }
            catch (Exception)
            {
            }
        }

        private void EndX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                _ArcXYC.EndX = Convert.ToDouble(EndX.Text);
            }
            catch (Exception)
            {
            }
        }

        private void EndY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                _ArcXYC.EndY = Convert.ToDouble(EndY.Text);
            }
            catch (Exception)
            {
            }
        }

        private void RX_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                _ArcXYC.StartSpeed = Convert.ToDouble(StartSpeed.Text);
            }
            catch (Exception)
            {
            }
        }

        private void EndSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                _ArcXYC.EndSpeed = Convert.ToDouble(EndSpeed.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 速度获取_Click(object sender, EventArgs e)
        {
            try
            {
                ArcXYC _ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ArcXYC = (ArcXYC)tools[Step];
                _ArcXYC.StartSpeed = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].Auto_Speed;
                _ArcXYC.EndSpeed = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_ArcXYC._轴1Name].Auto_Speed;
                StartSpeed.Text= _ArcXYC.StartSpeed.ToString();
                EndSpeed.Text=_ArcXYC.EndSpeed.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ArcXYC ArcXYC;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                ArcXYC = (ArcXYC)tools[Step];
                ArcXYC.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }

        private void RY_TextChanged(object sender, EventArgs e)
        {

        }
        public int GetCircleParameters(ArcXYC _ArcXYC)
        {
            //Radius:(X:pos,Y:pos;X:pos,Y:pos;X:pos,Y:pos)
            int res = 0;
            //string  Radius = "";
            //先清除上一次储存的数值
            List<double> FirstPoint = new List<double>();
            List<double> SecondPoint = new List<double>();
            List<double> ThridPoint = new List<double>();
            //先清除上一次储存的数值
            //string[] PositionDate = Position.Split(';');
            //string[] FirstPointXY = PositionDate[0].Split(',');
            //string[] SecondPointXY = PositionDate[1].Split(',');
            //string[] ThirdPointXY = PositionDate[2].Split(',');
            //把文本框的数值加入到数组中
            try
            {
                //第一点的X Y坐标值
                FirstPoint.Add(_ArcXYC.StartX);
                FirstPoint.Add(_ArcXYC.StartY);
                //第二点的X Y坐标值
                SecondPoint.Add(_ArcXYC.CenterX);
                SecondPoint.Add(_ArcXYC.CenterY);
                //第三点的X Y坐标值
                ThridPoint.Add(_ArcXYC.EndX);
                ThridPoint.Add(_ArcXYC.EndY);
            }
            catch (Exception ex)
            {

            }
            //算法内容
            double a = FirstPoint[0] - SecondPoint[0];// X1-X2
            double b = FirstPoint[1] - SecondPoint[1];//Y1-Y2
            double c = FirstPoint[0] - ThridPoint[0];//X1-X3
            double d = FirstPoint[1] - ThridPoint[1];//Y1-Y3
            double aa = Math.Pow(FirstPoint[0], 2) - Math.Pow(SecondPoint[0], 2);//X1^2-X2^2
            double bb = Math.Pow(SecondPoint[1], 2) - Math.Pow(FirstPoint[1], 2);//Y2^2-Y1^2
            double cc = Math.Pow(FirstPoint[0], 2) - Math.Pow(ThridPoint[0], 2);//X1^2-X3^2
            double dd = Math.Pow(ThridPoint[1], 2) - Math.Pow(FirstPoint[1], 2);//Y3^2-Y1^2
            double E = (aa - bb) / 2;
            double F = (cc - dd) / 2;
            double resultY = (a * F - c * E) / (a * d - b * c);
            double resultX = (F * b - E * d) / (b * c - a * d);
            double resultR = Math.Sqrt((Math.Pow((FirstPoint[0] - resultX), 2)) + (Math.Pow((FirstPoint[1] - resultY), 2)));

            //输出圆心的坐标和半径值
            //lb_Point.Text = "X坐标为：" + resultX.ToString() + ";  Y坐标为：" + resultY.ToString();
            //lb_Radius.Text = resultR.ToString();
            //返回格式：（圆心X:Pos,圆心Y:Pos;R:r)
            //Radius = FirstPointXY[0].Split(':')[0] + ":" + Math.Round(resultX, 3).ToString() + ","
            //    + FirstPointXY[1].Split(':')[0] + ":" + Math.Round(resultY, 3).ToString() + ";"
            //    + "R:" + Math.Round(resultR, 3).ToString();
            _ArcXYC.RX = Math.Round(resultX, 3);
            _ArcXYC.RY = Math.Round(resultY, 3);
            _ArcXYC.R = Math.Round(resultR, 3);
            _ArcXYC.CenterOfferX = _ArcXYC.RX - _ArcXYC.StartX;
            _ArcXYC.CenterOfferY = _ArcXYC.RY - _ArcXYC.StartY;
            return res;
        }

    }
}
