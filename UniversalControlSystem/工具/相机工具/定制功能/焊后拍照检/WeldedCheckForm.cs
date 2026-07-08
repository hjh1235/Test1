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
    public partial class WeldedCheckForm : Form
    {
        public WeldedCheckForm()
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
        WeldedCheck _WeldedCheck /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {  
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _WeldedCheck = (WeldedCheck)tools[Num];
            DataTx.Text = _WeldedCheck.DataGroup;
            DataTy.Text = _WeldedCheck.DataGroupName;
            获取方式.Text = _WeldedCheck.获取方式;
            发送命令.Text = _WeldedCheck.发送命令;
            拍几个.Text = _WeldedCheck.拍几个.ToString();
            拍位置.Text = _WeldedCheck.拍位置.ToString();
            曝光.Text = _WeldedCheck.曝光.ToString();
            取SN数据组.Text = _WeldedCheck.DataGroup_sn;
            取SN数据名.Text = _WeldedCheck.DataGroupName_sn;
            _通讯名字.Text = _WeldedCheck._通讯名字;
        
            CheckTepy.Text= _WeldedCheck.CheckTepy ;
            步骤跳转.Text = _WeldedCheck.FlowChar_StepControlLoop.ToString();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WeldedCheck WeldedCheck /*= new _OutPut_Puse()*/;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            WeldedCheck = (WeldedCheck)tools[Step];
            WeldedCheck.GetR_C(WeldedCheck);


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
                WeldedCheck WeldedCheck /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                WeldedCheck = (WeldedCheck)tools[Step];
                WeldedCheck.DataGroupName = DataTy.Text;
         

            }
            catch (Exception ex)
            {
            }
        }

        private void 获取方式_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                WeldedCheck WeldedCheck /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                WeldedCheck = (WeldedCheck)tools[Step];
                WeldedCheck.获取方式 = 获取方式.Text;

            }
            catch (Exception ex)
            {
            }
        }

        private void DataTx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                WeldedCheck WeldedCheck /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                WeldedCheck = (WeldedCheck)tools[Step];
                WeldedCheck.DataGroup = DataTx.Text;
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
                WeldedCheck WeldedCheck /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                WeldedCheck = (WeldedCheck)tools[Step];
                WeldedCheck.发送命令 = 发送命令.Text;

            }
            catch (Exception ex)
            {
            }
        }

        private void 拍几个_TextChanged(object sender, EventArgs e)
        {
            try
            {
                WeldedCheck WeldedCheck /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                WeldedCheck = (WeldedCheck)tools[Step];
                WeldedCheck.拍几个 =int.Parse( 拍几个.Text);

            }
            catch (Exception ex)
            {
            }
        }

        private void 拍位置_TextChanged(object sender, EventArgs e)
        {
            try
            {
                WeldedCheck WeldedCheck /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                WeldedCheck = (WeldedCheck)tools[Step];
                WeldedCheck.拍位置 = int.Parse(拍位置.Text);

            }
            catch (Exception ex)
            {
            }
        }

        private void 曝光_TextChanged(object sender, EventArgs e)
        {
            try
            {
                WeldedCheck WeldedCheck /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                WeldedCheck = (WeldedCheck)tools[Step];
                WeldedCheck.曝光 = int.Parse(曝光.Text);

            }
            catch (Exception ex)
            {
            }
        }

        private void 取SN数据组_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                WeldedCheck WeldedCheck /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                WeldedCheck = (WeldedCheck)tools[Step];
                WeldedCheck.DataGroup_sn = 取SN数据组.Text;
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
                WeldedCheck WeldedCheck /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                WeldedCheck = (WeldedCheck)tools[Step];
                WeldedCheck.DataGroupName_sn = 取SN数据名.Text;

            }
            catch (Exception ex)
            {
            }
        }

        private void _通讯名字_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                WeldedCheck WeldedCheck /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                WeldedCheck = (WeldedCheck)tools[Step];
                WeldedCheck._通讯名字 = _通讯名字.Text;

            }
            catch (Exception ex)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                WeldedCheck WeldedCheck /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                WeldedCheck = (WeldedCheck)tools[Step];
                WeldedCheck.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                WeldedCheck WeldedCheck /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                WeldedCheck = (WeldedCheck)tools[Step];
                WeldedCheck.CheckTepy = CheckTepy.Text;
            
            }
            catch (Exception ex)
            {
            }
            
        }
    }
}
