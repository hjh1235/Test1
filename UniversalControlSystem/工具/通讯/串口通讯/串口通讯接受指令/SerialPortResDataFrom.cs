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
    public partial class SerialPortResDataFrom : Form
    {
        public SerialPortResDataFrom()
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
        SerialPortResData _SerialPortResData /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _SerialPortResData = (SerialPortResData)tools[Num];
            _通讯名字.Text= _SerialPortResData._通讯名字;
            _ResData.Text=_SerialPortResData._ResData ;
            功能选择.Text = _SerialPortResData.功能选择;

            DataTx.Text = _SerialPortResData.DataGroup;
            DataTy.Text=_SerialPortResData.DataGroupName ;
            if (_SerialPortResData.FlowChar_StepControlLoop == Num)
            {
                _SerialPortResData.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _SerialPortResData.FlowChar_StepControlLoop.ToString();
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
                DataTx.Items.Add(item.Value.strGroupName);
            }
            foreach (var item in Communication_DateLoadData._Communication_DateTool)
            {
                _通讯名字.Items.Add(item.Value.Communication_DateName);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SerialPortResData SerialPortResData /*= new _OutPut_Puse()*/;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            SerialPortResData = (SerialPortResData)tools[Step];
            label10.Text = SerialPortResData.ResData(SerialPortResData);

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
        private void _通讯名字_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SerialPortResData SerialPortResData /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                SerialPortResData = (SerialPortResData)tools[Step];
                SerialPortResData._通讯名字 = _通讯名字.Text;
            }
            catch (Exception ex)
            {
            }

        }
        private void _ResData_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SerialPortResData SerialPortResData /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                SerialPortResData = (SerialPortResData)tools[Step];
                SerialPortResData._ResData = _ResData.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void 功能选择_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SerialPortResData SerialPortResData /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                SerialPortResData = (SerialPortResData)tools[Step];
                SerialPortResData.功能选择 = 功能选择.Text;
            }
            catch (Exception ex)
            {
            }

        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SerialPortResData SerialPortResData;
                int Step = Num;
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[_FlowChar_StepControlStepName];
                SerialPortResData = (SerialPortResData)tools[Step];
                SerialPortResData.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }

        private void DataTx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SerialPortResData SerialPortResData;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                SerialPortResData = (SerialPortResData)tools[Step];
                SerialPortResData.DataGroup = DataTx.Text;
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
                SerialPortResData SerialPortResData;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                SerialPortResData = (SerialPortResData)tools[Step];
                SerialPortResData.DataGroupName = DataTy.Text;
               
            }
            catch (Exception ex)
            {
            }
        }
    }
}
