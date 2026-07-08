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
    public partial class CamerCompensation_CenterFrom: Form
    {
        public CamerCompensation_CenterFrom()
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
        CamerCompensation_Center _CamerCompensation_Center /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {  
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _CamerCompensation_Center = (CamerCompensation_Center)tools[Num];
            DataTx.Text = _CamerCompensation_Center.DataGroup;
            DataTy.Text = _CamerCompensation_Center.DataGroupName;
            轴名X.Text = _CamerCompensation_Center.轴名X;
            轴名Y.Text = _CamerCompensation_Center.轴名Y;

            参数组.Text = _CamerCompensation_Center.参数组;
            if (_CamerCompensation_Center.FlowChar_StepControlLoop == Num)
            {
                _CamerCompensation_Center.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _CamerCompensation_Center.FlowChar_StepControlLoop.ToString();
            }
        }
        private void OutPut_Pulse_Load(object sender, EventArgs e)
        {
            foreach (var item in DataManage.m_Doc.m_dataDictionary)
            {
                DataTx.Items.Add(item.Value.strGroupName);
            }    
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                轴名X.Items.Add(item.Value.Axis_hardwareName);
                轴名Y.Items.Add(item.Value.Axis_hardwareName);

            }
            foreach (var items in Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary)
            {
                参数组.Items.Add(items.Value.Get_High_hardwareName);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _CamerCompensation_Center.AxisPCamerCompensation(_CamerCompensation_Center);
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
                CamerCompensation_Center _CamerCompensation_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _CamerCompensation_Center = (CamerCompensation_Center)tools[Step];
                _CamerCompensation_Center.DataGroupName = DataTy.Text;
            }
            catch (Exception ex)
            {
            }
        }
        private void DataTx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CamerCompensation_Center _CamerCompensation_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _CamerCompensation_Center = (CamerCompensation_Center)tools[Step];
                _CamerCompensation_Center.DataGroup = DataTx.Text;
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
        private void AixsName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CamerCompensation_Center _CamerCompensation_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _CamerCompensation_Center = (CamerCompensation_Center)tools[Step];
                _CamerCompensation_Center.轴名X = 轴名X.Text;
  
            }
            catch (Exception ex)
            {
            }
        }

        private void 轴名Y_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CamerCompensation_Center _CamerCompensation_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _CamerCompensation_Center = (CamerCompensation_Center)tools[Step];
                _CamerCompensation_Center.轴名Y = 轴名Y.Text;

            }
            catch (Exception ex)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CamerCompensation_Center CamerCompensation_Center;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                CamerCompensation_Center = (CamerCompensation_Center)tools[Step];
                CamerCompensation_Center.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }

        private void 参数组_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CamerCompensation_Center _CamerCompensation_Center /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _CamerCompensation_Center = (CamerCompensation_Center)tools[Step];
                _CamerCompensation_Center.参数组 = 参数组.Text;

            }
            catch (Exception ex)
            {
            }
        }
    }
}
