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
    public partial class CallSubroutineFrom : Form
    {
        public CallSubroutineFrom()
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
        CallSubroutine _CallSubroutine /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _CallSubroutine = (CallSubroutine)tools[Num];
            Sub_Path.Text = _CallSubroutine._CallSubroutine;
            CheckChoose.Text = _CallSubroutine._CallSub_Sta;
            _CallSubroutine.FlowChar_StepControlNum = Num;

            DataTy.Text = _CallSubroutine.DataGroupName;
            DataTx.Text = _CallSubroutine.DataGroup;
            if (_CallSubroutine.FlowChar_StepControlLoop == Num)
            {
                _CallSubroutine.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = _CallSubroutine.FlowChar_StepControlLoop.ToString();
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
            foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
            {
                DataTx.Items.Add(item.Value.Group_ControlDataName);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult DResult = MessageBox.Show("确定运行", "确定运行", MessageBoxButtons.YesNo);
            if (DResult == DialogResult.No)
            {
                return;
            }
            CallSubroutine _CallSubroutine /*= new _OutPut_Puse()*/;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            _CallSubroutine = (CallSubroutine)tools[Step];
            if (_CallSubroutine._CallSub_Sta == "同步运行"&& _CallSubroutine._CallSub_RunSta==false)
            {
                //异步方法同步运行
                Task.Run(() =>
                {
                    _CallSubroutine.RunFun(_CallSubroutine);
                });
            }
            if (_CallSubroutine._CallSub_Sta == "等待运行完成" && _CallSubroutine._CallSub_RunSta == false)
            {      
                //异步方法
                Task.Run(() =>
                {
                    _CallSubroutine.RunFun(_CallSubroutine);
                });

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
        private void CheckChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CallSubroutine _CallSubroutine /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _CallSubroutine = (CallSubroutine)tools[Step];
                _CallSubroutine._CallSub_Sta = CheckChoose.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CallSubroutine _CallSubroutine;
                int Step = Num;
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[_FlowChar_StepControlStepName];
                _CallSubroutine = (CallSubroutine)tools[Step];
                _CallSubroutine.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                CallSubroutine _CallSubroutine;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _CallSubroutine = (CallSubroutine)tools[Step];
                _CallSubroutine.DataGroup = DataTx.Text;
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
                CallSubroutine _CallSubroutine;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                _CallSubroutine = (CallSubroutine)tools[Step];
                _CallSubroutine.DataGroupName = DataTy.Text;

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

                        Sub_Path.Text = localFilePath;

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
    }
}
