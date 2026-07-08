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
    public partial class CamerGetR_CenterFrom : Form
    {
        public CamerGetR_CenterFrom()
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
        CamerGetR_Center _CamerGetR_Center /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {  
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _CamerGetR_Center = (CamerGetR_Center)tools[Num];
            DataTx.Text = _CamerGetR_Center.DataGroup;
            DataTy.Text = _CamerGetR_Center.DataGroupName;
            获取方式.Text = _CamerGetR_Center.获取方式;
            发送命令.Text = _CamerGetR_Center.发送命令;
            拍几个.Text = _CamerGetR_Center.拍几个.ToString();
            拍位置.Text = _CamerGetR_Center.拍位置.ToString();
            曝光.Text = _CamerGetR_Center.曝光.ToString();
            取SN数据组.Text = _CamerGetR_Center.DataGroup_sn;
            取SN数据名.Text = _CamerGetR_Center.DataGroupName_sn;
            _通讯名字.Text= _CamerGetR_Center._通讯名字 ;
            Aixs1名字.Text = _CamerGetR_Center.Aixs1名字;
            Aixs2名字.Text= _CamerGetR_Center.Aixs2名字 ;
            Aixs1位置.Text = _CamerGetR_Center.Aixs1位置.ToString();
            Aixs2位置.Text = _CamerGetR_Center.Aixs2位置.ToString();
            Aixs1加速度.Text= _CamerGetR_Center.Aixs1加速度.ToString();
            Aixs2加速度.Text = _CamerGetR_Center.Aixs2加速度.ToString();
            Aixs1减速度.Text = _CamerGetR_Center.Aixs1减速度.ToString();
            Aixs2减速度.Text = _CamerGetR_Center.Aixs2减速度.ToString();

            Aixs1速度.Text= _CamerGetR_Center.Aixs1速度.ToString();
            Aixs2速度.Text = _CamerGetR_Center.Aixs2速度.ToString();
        
            CheckTepy.Text= _CamerGetR_Center.CheckTepy ;
            try
            {                
            }
            catch 
            {
            }
        }
        private void OutPut_Pulse_Load(object sender, EventArgs e)
        {
            foreach (var item in DataManage.m_Doc.m_dataDictionary)
            {
                DataTx.Items.Add(item.Value.strGroupName);
            }
            foreach (var item in DataManage.m_Doc.m_dataDictionary)
            {
                取SN数据组.Items.Add(item.Value.strGroupName);
            }
            foreach (var item in Communication_DateLoadData._Communication_DateTool)
            {
                _通讯名字.Items.Add(item.Value.Communication_DateName);
            }
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                Aixs1名字.Items.Add(item.Value.Axis_hardwareName);
                Aixs2名字.Items.Add(item.Value.Axis_hardwareName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            CamerGetR_Center = (CamerGetR_Center)tools[Step];
            CamerGetR_Center.GetR_C(CamerGetR_Center);


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

      
        private void DataTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.DataGroupName = DataTy.Text;
         

            }
            catch (Exception ex)
            {
            }
        }

        private void 获取方式_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.获取方式 = 获取方式.Text;

            }
            catch (Exception ex)
            {
            }
        }

        private void DataTx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.DataGroup = DataTx.Text;
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

        private void 发送命令_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.发送命令 = 发送命令.Text;

            }
            catch (Exception ex)
            {
            }
        }

        private void 拍几个_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.拍几个 =int.Parse( 拍几个.Text);

            }
            catch (Exception ex)
            {
            }
        }

        private void 拍位置_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.拍位置 = int.Parse(拍位置.Text);

            }
            catch (Exception ex)
            {
            }
        }

        private void 曝光_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.曝光 = int.Parse(曝光.Text);

            }
            catch (Exception ex)
            {
            }
        }

        private void 取SN数据组_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.DataGroup_sn = 取SN数据组.Text;
                取SN数据名.Items.Clear();
                foreach (var item in DataManage.m_Doc.m_dataDictionary[取SN数据组.Text].m_dataDictionary)
                {
                    取SN数据名.Items.Add(item.Value.strName);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void 取SN数据名_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.DataGroupName_sn = 取SN数据名.Text;

            }
            catch (Exception ex)
            {
            }
        }

        private void _通讯名字_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center._通讯名字 = _通讯名字.Text;

            }
            catch (Exception ex)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }

        private void Aixs1名字_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.Aixs1名字 = Aixs1名字.Text ;
            }
            catch (Exception)
            {
            }
            
        }

        private void Aixs2名字_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.Aixs2名字 = Aixs2名字.Text;
            }
            catch (Exception)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                Aixs1位置.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CamerGetR_Center.Aixs1名字].AisxCurrentPosition.ToString();
                CamerGetR_Center.Aixs1位置 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CamerGetR_Center.Aixs1名字].AisxCurrentPosition;

            }
            catch (Exception)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                Aixs2位置.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CamerGetR_Center.Aixs2名字].AisxCurrentPosition.ToString();
                CamerGetR_Center.Aixs2位置 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CamerGetR_Center.Aixs2名字].AisxCurrentPosition;

            }
            catch (Exception)
            {
            }
        }

        private void Aixs1加速度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                Aixs1加速度.Text = Aixs1加速度.Text;
                CamerGetR_Center.Aixs1加速度 =Convert.ToDouble(Aixs1加速度.Text);

            }
            catch (Exception)
            {
            }
        }

        private void Aixs2加速度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                Aixs2加速度.Text = Aixs2加速度.Text;
                CamerGetR_Center.Aixs2加速度 = Convert.ToDouble(Aixs2加速度.Text);

            }
            catch (Exception)
            {
            }
        }

        private void Aixs1减速度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
             
                CamerGetR_Center.Aixs1减速度 = Convert.ToDouble(Aixs1减速度.Text);

            }
            catch (Exception)
            {
            }
        }

        private void Aixs2减速度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];

                CamerGetR_Center.Aixs2减速度 = Convert.ToDouble(Aixs2减速度.Text);

            }
            catch (Exception)
            {
            }
        }

        private void Aixs1速度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.Aixs1速度 = Convert.ToDouble(Aixs1速度.Text);

            }
            catch (Exception)
            {
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.CheckTepy = CheckTepy.Text;
            
            }
            catch (Exception ex)
            {
            }
            
        }

        private void Aixs1位置_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.Aixs1位置=Convert.ToDouble( Aixs1位置.Text );
               
            }
            catch (Exception)
            {
            }
        }

        private void Aixs2速度_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.Aixs2速度 = Convert.ToDouble(Aixs2速度.Text);

            }
            catch (Exception)
            {
            }
            
        }

        private void Aixs2位置_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerGetR_Center CamerGetR_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerGetR_Center = (CamerGetR_Center)tools[Step];
                CamerGetR_Center.Aixs2位置 = Convert.ToDouble(Aixs2位置.Text);

            }
            catch (Exception)
            {
            }
        }
    }
}
