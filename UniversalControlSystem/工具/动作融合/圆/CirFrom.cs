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
    public partial class CirFrom : Form
    {
        public CirFrom()
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
        Cir _Cir /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _Cir = (Cir)tools[Num];
            _轴1Name.Text= _Cir._轴1Name;
            _轴2Name.Text = _Cir._轴2Name;
           
            坐标系维度.Text = _Cir.Cor.ToString();

            卡号textBox1.Text = _Cir.CardNum.ToString();
            坐标系维度.Text = _Cir.Cor.ToString();
            StartX.Text = _Cir.StartX.ToString();
            StartY.Text = _Cir.StartY.ToString();
            CenterX.Text = _Cir.CenterX.ToString();
            CenterY.Text = _Cir.CenterY.ToString();
            EndX.Text = _Cir.EndX.ToString();
            EndY.Text = _Cir.EndY.ToString();
            RX.Text = _Cir.RX.ToString();
            RY.Text = _Cir.RY.ToString();
            _轴1Name.Text = _Cir._轴1Name;
            _轴2Name.Text = _Cir._轴2Name;
            StartSpeed.Text = _Cir.StartSpeed.ToString();
            EndSpeed.Text = _Cir.EndSpeed.ToString();
            圆圆弧选择.Text = _Cir.圆圆弧选择;
            txtDicDeg.Text = _Cir.txtDicDeg.ToString();
            cmbSelectDir.Text = _Cir.cmbSelectDir;
            加速度textBox3.Text = _Cir.Acc.ToString();
            减速度textBox4.Text = _Cir.Dec.ToString();
            R.Text= _Cir.R.ToString();
            if (_Cir.FlowChar_StepControlLoop == Num)
            {
                _Cir.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _Cir.FlowChar_StepControlLoop.ToString();
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
            foreach (var item in DataManage.m_Doc.m_dataDictionary)
            {
                DataTx.Items.Add(item.Value.strGroupName);
            }
            foreach (var item in Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary)
            {
                参数集.Items.Add(item.Value.Get_High_hardwareName);
            }
         }
        gts.mc.TCrdPrm TCrdPrm;
        private void button1_Click(object sender, EventArgs e)
        {
            Cir Cir /*= new _OutPut_Puse()*/;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            Cir = (Cir)tools[Step];
            Cir.CirRun(Cir);

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
                Cir Cir /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Cir = (Cir)tools[Step];
                Cir._轴1Name =_轴1Name.Text;
            }
            catch (Exception ex)
            {

                
            }
        }

     
        private void 坐标系维度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir Cir /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Cir = (Cir)tools[Step];
                Cir.Cor =int.Parse(坐标系维度.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void _轴2Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cir Cir /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Cir = (Cir)tools[Step];
                Cir._轴2Name = _轴2Name.Text;
            }
            catch (Exception ex)
            {


            }
        }



      
        private void 卡号textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir Cir /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Cir = (Cir)tools[Step];
                Cir.CardNum = int.Parse(卡号textBox1.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                Cir = (Cir)tools[Step];
                Cir.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 起点坐标获取_Click(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                StartX.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴1Name].AisxCurrentPosition.ToString();
                _Cir.StartX = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴1Name].AisxCurrentPosition;

                StartY.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴2Name].AisxCurrentPosition.ToString();
                _Cir.StartY = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴2Name].AisxCurrentPosition;
            }
            catch (Exception)
            {
            }
        }

        private void 过渡坐标获取_Click(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                CenterX.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴1Name].AisxCurrentPosition.ToString();
                _Cir.CenterX = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴1Name].AisxCurrentPosition;

                CenterY.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴2Name].AisxCurrentPosition.ToString();
                _Cir.CenterY = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴2Name].AisxCurrentPosition;
            }
            catch (Exception)
            {
            }
        }

        private void 终点坐标获取_Click(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                EndX.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴1Name].AisxCurrentPosition.ToString();
                _Cir.EndX = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴1Name].AisxCurrentPosition;

                EndY.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴2Name].AisxCurrentPosition.ToString();
                _Cir.EndY = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴2Name].AisxCurrentPosition;
            }
            catch (Exception)
            {
            }
        }

        private void StartX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.StartX = Convert.ToDouble(StartX.Text);
            }
            catch (Exception)
            {
            }
        }

        private void StartY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.StartY = Convert.ToDouble(StartY.Text);
            }
            catch (Exception)
            {
            }
        }

        private void CenterX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.CenterX = Convert.ToDouble(CenterX.Text);
            }
            catch (Exception)
            {
            }
        }

        private void CenterY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.CenterY = Convert.ToDouble(CenterY.Text);
            }
            catch (Exception)
            {
            }
        }

        private void EndX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.EndX = Convert.ToDouble(EndX.Text);
            }
            catch (Exception)
            {
            }
        }

        private void EndY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.EndY = Convert.ToDouble(EndY.Text);
            }
            catch (Exception)
            {
            }
        }

        private void StartSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.StartSpeed = Convert.ToDouble(StartSpeed.Text);
            }
            catch (Exception)
            {
            }
        }

        private void EndSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.EndSpeed = Convert.ToDouble(EndSpeed.Text);
            }
            catch (Exception)
            {
            }
        }

        private void txtDicDeg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.txtDicDeg = Convert.ToInt32(txtDicDeg.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 加速度textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.Acc = Convert.ToDouble(加速度textBox3.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 减速度textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.Dec = Convert.ToDouble(减速度textBox4.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 圆圆弧选择_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.圆圆弧选择 = 圆圆弧选择.Text;
            }
            catch (Exception)
            {
            }

        }

        private void cmbSelectDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.cmbSelectDir = cmbSelectDir.Text;
            }
            catch (Exception)
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                if (_Cir.圆圆弧选择 == "圆心半径")
                {
                    RX.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴1Name].AisxCurrentPosition.ToString();
                    RY.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴2Name].AisxCurrentPosition.ToString();
                    _Cir.RX = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴1Name].AisxCurrentPosition;
                    _Cir.RY = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Cir._轴2Name].AisxCurrentPosition;
                }
                else 
                {
                    GetCircleParameters(_Cir);
                    RX.Text = _Cir.RX.ToString();
                    RY.Text = _Cir.RY.ToString();

                }
       
            }
            catch (Exception)
            {
            }
      
        }
        public int GetCircleParameters(Cir Cir)
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
                FirstPoint.Add(Cir.StartX);
                FirstPoint.Add(Cir.StartY);
                //第二点的X Y坐标值
                SecondPoint.Add(Cir.CenterX);
                SecondPoint.Add(Cir.CenterY);
                //第三点的X Y坐标值
                ThridPoint.Add(Cir.EndX);
                ThridPoint.Add(Cir.EndY);
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
            Cir.RX = Math.Round(resultX, 3);
            Cir.RY = Math.Round(resultY, 3);
            Cir.R = Math.Round(resultR, 3);
            Cir.CenterOfferX = Cir.RX - Cir.StartX;
            Cir.CenterOfferY = Cir.RY - Cir.StartY;
            return res;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.R =Convert.ToDouble( R.Text);
            }
            catch (Exception)
            {
            }
         
        }

        private void DataTx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.DataGroup = DataTx.Text;
                DataTy.Text = "";
                DataTy.Items.Clear();
                foreach (var item in DataManage.m_Doc.m_dataDictionary[DataTx.Text].m_dataDictionary)
                {
                    DataTy.Items.Add(item.Value.strName);
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void DataTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.DataGroupName = DataTy.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void RX_TextChanged(object sender, EventArgs e)
        {

        }

        private void RY_TextChanged(object sender, EventArgs e)
        {

        }

        private void 参数集_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cir _Cir;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _Cir = (Cir)tools[Step];
                _Cir.参数集 = 参数集.Text;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
