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
    public partial class LogicalJumpFrom : Form
    {
        public LogicalJumpFrom()
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
        }
        string _RunFlowData_ControlDataName = "";
        string _FlowChar_StepControlStepName = "";
        int Num = 0;
        LogicalJump _LogicalJump /*= new _OutPut_Puse()*/;
        static LogicalJumpFrom frm;
        public delegate void HandleaCanel();
        public static event HandleaCanel eventCancel;
        public delegate void HandledSetVal(AcqFifoTool acqFifoTool);
        HandledSetVal handledSetVal;
        /// <summary>
        ///  单实例
        /// </summary>
        /// <param name="am"></param>
        /// <param name="setVal"></param>
        /// <returns></returns>
        public static LogicalJumpFrom SingleShow(LogicalJump _LogicalJump, HandledSetVal setVal)
        {
            if (frm == null)//
            {
                frm = new LogicalJumpFrom(_LogicalJump, setVal);
            }
            return frm;
        }
        public LogicalJumpFrom(LogicalJump _LogicalJump, HandledSetVal handledSetVal)
        {
            InitializeComponent();
            this.handledSetVal = handledSetVal;
  
            //SetVal(ref this.acqFifoTool);//设置参数
        }


        public void ShowMesage(string Name,string StepName, int num)
        {
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _LogicalJump = (LogicalJump)tools[Num];
            _LogicalJump.FlowChar_StepControlNum = Num;
            类型设置.Text = _LogicalJump.类型设置;
            //tbxToolName.Text = _LogicalJump.类型名称;
            IOOutputItem.Text = _LogicalJump.IOOutputItem;
            数据组Item.Text = _LogicalJump.数据组Item;
            IOInputItem.Text = _LogicalJump.IOInputItem;
            数据包从键Item.Text = _LogicalJump.数据包从键Item;
            数据包主键Item.Text = _LogicalJump.数据包主键Item;
            tbxToolName.Text= _LogicalJump.RunFlowData_ControlDataDescrptive ;
            检测状态.Text = _LogicalJump.检测状态;
            if (_LogicalJump.FlowChar_StepControlLoop == Num)
            {
                _LogicalJump.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _LogicalJump.FlowChar_StepControlLoop.ToString();
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
            //foreach (var item in DataManage.m_Doc.m_dataDictionary)
            //{
            //    数据包主键Item.Items.Add(item.Value.strGroupName);
            //}
            //foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
            //{
            //    数据包主键Item.Items.Add(item.Value.Group_ControlDataName);
            //}
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
        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LogicalJump _LogicalJump;
                int Step = int.Parse(步骤.Text);

                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[_FlowChar_StepControlStepName];
                _LogicalJump = (LogicalJump)tools[Step];
                _LogicalJump.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                LogicalJump _LogicalJump;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LogicalJump = (LogicalJump)tools[Step];
                _LogicalJump.数据包主键Item = 数据包主键Item.Text;
                数据包从键Item.Text = "";
                数据包从键Item.Items.Clear();
                foreach (var item in DataManage.m_Doc.m_dataDictionary[数据包主键Item.Text].m_dataDictionary)
                {
                    数据包从键Item.Items.Add(item.Value.strName);
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
                LogicalJump _LogicalJump;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LogicalJump = (LogicalJump)tools[Step];
                _LogicalJump.数据包从键Item = 数据包从键Item.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_SelectParamFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = ".//";
                openFileDialog.Filter = "卡配置文件|*.csv";
                //openFileDialog.FilterIndex = 1;
                // openFileDialog.RestoreDirectory = true;
                DialogResult dr = openFileDialog.ShowDialog();
                if (dr == DialogResult.OK && openFileDialog.FileName.Length > 0)
                {
                    string localFilePath = openFileDialog.FileName.ToString(); //获得文件路径
                    string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                    string filePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));//获取文件路径，不带文件名
                    if (localFilePath != "")
                    {

                    

                        CallSubroutine _CallSubroutine;
                        int Step = int.Parse(步骤.Text);
                        List<ImageTool> tools /*= new List<ImageTool>()*/;
                        tools = LoadData._ImageToolRun[TOOLName.Text];
                        _CallSubroutine = (CallSubroutine)tools[Step];
                        _CallSubroutine._CallSubroutine = localFilePath;


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TOOLName_Click(object sender, EventArgs e)
        {

        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (类型设置.Text == "IO输入")
            {
                foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
                {
                    IOInputItem.Items.Add(item.Value.hardIOName);
                }
                数据组.Visible = true;
                数据包.Visible = true;
                IO输出.Visible = true;
            }
            else if (类型设置.Text == "IO输出")
            {
                foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                {
                    IOOutputItem.Items.Add(item.Value.hardIOName);
                }
                数据组.Visible = true;
                IO输入.Visible = true;
                数据包.Visible = true;
            }
            else if (类型设置.Text == "数据组")
            {
                foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
                {
                    数据组Item.Items.Add(item.Value.Group_ControlDataName);
                }
                IO输出.Visible = true;
                IO输入.Visible = true;
                数据包.Visible = true;
            }
            else if (类型设置.Text == "数据包")
            {
                foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
                {
                    数据包主键Item.Items.Add(item.Value.Group_ControlDataName);
                }
                IO输出.Visible = true;
                IO输入.Visible = true;
                数据组.Visible = true;
            }
        }

        private void IOItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LogicalJump _LogicalJump;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LogicalJump = (LogicalJump)tools[Num];
                _LogicalJump.IOInputItem = IOInputItem.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LogicalJump _LogicalJump;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LogicalJump = (LogicalJump)tools[Num];
                _LogicalJump.RunFlowData_ControlDataDescrptive = tbxToolName.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void 检测状态_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LogicalJump _LogicalJump;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LogicalJump = (LogicalJump)tools[Num];
                _LogicalJump.检测状态 = 检测状态.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void IOOutputItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LogicalJump _LogicalJump;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LogicalJump = (LogicalJump)tools[Num];
                _LogicalJump.IOOutputItem = IOOutputItem.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void 数据组Item_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LogicalJump _LogicalJump;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LogicalJump = (LogicalJump)tools[Num];
                _LogicalJump.数据组Item = 数据组Item.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void 步骤号_TextChanged(object sender, EventArgs e)
        {

        }

        private void 步骤名字_TextChanged(object sender, EventArgs e)
        {

        }

        private void 步骤类型_TextChanged(object sender, EventArgs e)
        {

        }

        private void 步骤用时_TextChanged(object sender, EventArgs e)
        {

        }

        private void 步骤结果_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                LogicalJump _LogicalJump;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _LogicalJump = (LogicalJump)tools[Num];
                _LogicalJump.LogicalJumpFun(_LogicalJump) ;
            }
            catch (Exception ex)
            {
            }
            
        }
    }
}
