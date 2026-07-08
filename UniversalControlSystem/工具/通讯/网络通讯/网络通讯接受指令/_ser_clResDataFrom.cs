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
    public partial class _ser_clResDataFrom : Form
    {
        public _ser_clResDataFrom()
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
        _ser_clResData _ser_clResData /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _ser_clResData = (_ser_clResData)tools[Num];
            _通讯名字.Text = _ser_clResData._通讯名字;
            通讯选择.Text = _ser_clResData.通讯选择;
            _ResData.Text = _ser_clResData._ResData;

            DataTx.Text = _ser_clResData.DataGroup;
            DataTy.Text = _ser_clResData.DataGroupName;
            if (_ser_clResData.FlowChar_StepControlLoop == Num)
            {
                _ser_clResData.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _ser_clResData.FlowChar_StepControlLoop.ToString();
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
        gts.mc.TCrdPrm TCrdPrm;
        private void button1_Click(object sender, EventArgs e)
        {
            _ser_clResData _ser_clResData /*= new _OutPut_Puse()*/;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _ser_clResData = (_ser_clResData)tools[Step];
            _ResData.Text = _ser_clResData.ResData(_ser_clResData);


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
                _ser_clResData _ser_clResData /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ser_clResData = (_ser_clResData)tools[Step];
                _ser_clResData._通讯名字 = _通讯名字.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void 通讯选择_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _ser_clResData _ser_clResData /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ser_clResData = (_ser_clResData)tools[Step];
                _ser_clResData.通讯选择 = 通讯选择.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void _ResData_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _ser_clResData _ser_clResData /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ser_clResData = (_ser_clResData)tools[Step];
                _ser_clResData._ResData = _ResData.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void 功能选择_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _ser_clResData _ser_clResData /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ser_clResData = (_ser_clResData)tools[Step];
                _ser_clResData.功能选择 = 功能选择.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _ser_clResData _ser_clResData;
                int Step = Num;
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[_FlowChar_StepControlStepName];
                _ser_clResData = (_ser_clResData)tools[Step];
                _ser_clResData.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }

        private void DataTx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _ser_clResData _ser_clResData;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ser_clResData = (_ser_clResData)tools[Step];
                _ser_clResData.DataGroup = DataTx.Text;
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
                _ser_clResData _ser_clResData;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _ser_clResData = (_ser_clResData)tools[Step];
                _ser_clResData.DataGroupName = DataTy.Text;

            }
            catch (Exception ex)
            {
            }
        }
    }
}
