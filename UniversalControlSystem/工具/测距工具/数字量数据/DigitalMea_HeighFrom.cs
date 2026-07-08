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
    public partial class DigitalMea_HeighFrom : Form
    {
        public DigitalMea_HeighFrom()
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
        DigitalMea_Height _DigitalMea_Height /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _DigitalMea_Height = (DigitalMea_Height)tools[Num];
            _功能.Text = _DigitalMea_Height._功能;
            串口号.Text = _DigitalMea_Height.串口号;
            存入数据组.Text = _DigitalMea_Height.DataGroup;
            存入数据名.Text = _DigitalMea_Height.DataGroupName;
            轴名字.Text = _DigitalMea_Height.轴名字;

            离焦量.Text = _DigitalMea_Height.离焦量.ToString();
            负偏差.Text = _DigitalMea_Height.负偏差.ToString();
            正偏差.Text = _DigitalMea_Height.正偏差.ToString();


            视觉数据名.Text= _DigitalMea_Height.视觉数据名;
            视觉数据组.Text= _DigitalMea_Height.视觉数据组;
            偏距数据组.Text= _DigitalMea_Height.偏距数据组 ;



            Aixs1名字.Text = _DigitalMea_Height.Aixs1名字;
            Aixs2名字.Text = _DigitalMea_Height.Aixs2名字;
            Aixs1位置.Text = _DigitalMea_Height.Aixs1位置.ToString();
            Aixs2位置.Text = _DigitalMea_Height.Aixs2位置.ToString();

            Aixs1速度.Text = _DigitalMea_Height.Aixs1速度.ToString();
            Aixs2速度.Text = _DigitalMea_Height.Aixs2速度.ToString(); 
            Aixs1加速度.Text = _DigitalMea_Height.Aixs1加速度.ToString();
            Aixs2加速度.Text = _DigitalMea_Height.Aixs2加速度.ToString();
            Aixs1减速度.Text = _DigitalMea_Height.Aixs1减速度.ToString();
            Aixs2减速度.Text = _DigitalMea_Height.Aixs2减速度.ToString();
            模式.Text = _DigitalMea_Height.模式;
            if (_DigitalMea_Height.FlowChar_StepControlLoop == Num)
            {
                _DigitalMea_Height.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _DigitalMea_Height.FlowChar_StepControlLoop.ToString();
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
            foreach (var item in DataManage.m_Doc.m_dataDictionary)
            {
                存入数据组.Items.Add(item.Value.strGroupName);
            }
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                轴名字.Items.Add(item.Value.Axis_hardwareName);
            }


            foreach (var item in DataManage.m_Doc.m_dataDictionary)
            {
                视觉数据组.Items.Add(item.Value.strGroupName);
            }

            foreach (var items in Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary)
            {
                偏距数据组.Items.Add(items.Value.Get_High_hardwareName);
            }

            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                Aixs1名字.Items.Add(item.Value.Axis_hardwareName);
                Aixs2名字.Items.Add(item.Value.Axis_hardwareName);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height _DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _DigitalMea_Height = (DigitalMea_Height)tools[Step];
                _DigitalMea_Height.DigitalMea_Height_Fun(_DigitalMea_Height);
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
                _BufferArea.FunChoose = 存入数据名.Text;
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
             
            }
            catch (Exception)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 存入数据组_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.DataGroup = 存入数据组.Text;
                存入数据名.Text = "";
                存入数据名.Items.Clear();
                foreach (var item in DataManage.m_Doc.m_dataDictionary[存入数据组.Text].m_dataDictionary)
                {
                    存入数据名.Items.Add(item.Value.strName);
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void 存入数据名_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.DataGroupName = 存入数据名.Text;
   
            }
            catch (Exception ex)
            {
            }
        }

        private void 串口号_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.串口号 = 串口号.Text;

            }
            catch (Exception ex)
            {
            }
            
        }

        private void _功能_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height._功能 = _功能.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void _StepControlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.轴名字 = 轴名字.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void 离焦量_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.离焦量 = double .Parse(离焦量.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 正偏差_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.正偏差 = int.Parse(正偏差.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 负偏差_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.负偏差 = int.Parse(负偏差.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 视觉数据组_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.视觉数据组 = 视觉数据组.Text;
                视觉数据名.Text = "";
                视觉数据名.Items.Clear();
                foreach (var item in DataManage.m_Doc.m_dataDictionary[视觉数据组.Text].m_dataDictionary)
                {
                    视觉数据名.Items.Add(item.Value.strName);
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void 视觉数据名_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.视觉数据名 = 视觉数据名.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void 偏距数据组_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.偏距数据组 = 偏距数据组.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void Aixs1名字_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.Aixs1名字 = Aixs1名字.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void Aixs2名字_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.Aixs2名字 = Aixs2名字.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void Aixs1位置_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.Aixs1位置 =Convert.ToDouble( Aixs1位置.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void Aixs2位置_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.Aixs2位置 = Convert.ToDouble(Aixs2位置.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void Aixs1速度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.Aixs1速度 = Convert.ToDouble(Aixs1速度.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void Aixs2速度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.Aixs2速度 = Convert.ToDouble(Aixs2速度.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void Aixs1加速度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.Aixs1加速度 = Convert.ToDouble(Aixs1加速度.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void Aixs2加速度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.Aixs2加速度 = Convert.ToDouble(Aixs2加速度.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void Aixs1减速度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.Aixs1减速度 = Convert.ToDouble(Aixs1减速度.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void Aixs2减速度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                DigitalMea_Height.Aixs2减速度 = Convert.ToDouble(Aixs2减速度.Text);
            }
            catch (Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                Aixs1位置.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[DigitalMea_Height.Aixs1名字].AisxCurrentPosition.ToString();
                DigitalMea_Height.Aixs1位置 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[DigitalMea_Height.Aixs1名字].AisxCurrentPosition;

            }
            catch (Exception)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];
                Aixs2位置.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[DigitalMea_Height.Aixs2名字].AisxCurrentPosition.ToString();
                DigitalMea_Height.Aixs2位置 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[DigitalMea_Height.Aixs2名字].AisxCurrentPosition;

            }
            catch (Exception)
            {
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                DigitalMea_Height DigitalMea_Height;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                DigitalMea_Height = (DigitalMea_Height)tools[Step];            
                DigitalMea_Height.模式 = 模式.Text;
            }
            catch (Exception)
            {
            }
        }
        //public static double online_height;
        //public static DigitalMea_Height My_DigitalMea_Height = new DigitalMea_Height();
        //private void timer_height_Tick(object sender, EventArgs e)
        //{
            
        // if (!Program.bAuto && this.Visible == false)
        //    {
        //        timer_height.Start();
        //        try
        //        {
        //            double Sdat = 0;

        //            if (My_DigitalMea_Height.GetData(ref Sdat) == true)
        //            {

        //                if (Sdat == 327.67)
        //                {
        //                    online_height = 9999;
        //                }
        //                else
        //                {
        //                    online_height = Sdat;
        //                }
        //                My_DigitalMea_Height.DisConnect();
        //            }
        //            else
        //            {

        //            }
        //        }
        //        catch (Exception)
        //        {
        //        }
        //    }
        //}


    }
}
