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
    public partial class PYToolFrom : Form
    {
        public PYToolFrom()
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
        PYTool PYTool /*= new _OutPut_Puse()*/;
        public void ShowMesage(string Name,string StepName, int num)
        {
            TOOLName.Text= StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            PYTool = (PYTool)tools[Num];
            Py_Path.Text= PYTool.Py_Path;
            Py_Fun.Text = PYTool.Py_Fun;
            DataTy.Text= PYTool.DataGroupName;
            DataTx.Text = PYTool.DataGroup;
            if (PYTool.FlowChar_StepControlLoop == Num)
            {
                PYTool.FlowChar_StepControlLoop = Num;
                步骤跳转.Text = Num.ToString();
            }
            else
            {
                步骤跳转.Text = PYTool.FlowChar_StepControlLoop.ToString();
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
      
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PYTool PYTool /*= new _OutPut_Puse()*/;
            int Step = int.Parse(步骤.Text);
            List<ImageTool> tools /*= new List<ImageTool>()*/;
            tools = LoadData._ImageToolRun[TOOLName.Text];
            PYTool = (PYTool)tools[Step];
            PYTool.RunPy(PYTool);

            Py_Run_Res.Text= PYTool.Py_Run_Res;
            DataManage.SetData(PYTool.DataGroup, PYTool.DataGroupName, (object)PYTool.Py_Run_Res);
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
        private void 卡号textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PYTool PYTool /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                PYTool = (PYTool)tools[Step];
                PYTool.Py_Path = Py_Path.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void DataTx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PYTool PYTool /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                PYTool = (PYTool)tools[Step];
                PYTool.DataGroup = DataTx.Text;
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

        private void Py_Fun_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PYTool PYTool /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                PYTool = (PYTool)tools[Step];
                PYTool.Py_Fun = Py_Fun.Text;
            }
            catch (Exception ex)
            {
            }
        }

        private void DataTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PYTool PYTool /*= new _OutPut_Puse()*/;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools /*= new List<ImageTool>()*/;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                PYTool = (PYTool)tools[Step];
                PYTool.DataGroupName = DataTy.Text;
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
                openFileDialog.Filter = "卡配置文件|*.py";
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
               
                        Py_Path.Text = localFilePath;

                        PYTool PYTool /*= new _OutPut_Puse()*/;
                        int Step = int.Parse(步骤.Text);
                        List<ImageTool> tools /*= new List<ImageTool>()*/;
                        tools = LoadData._ImageToolRun[TOOLName.Text];
                        PYTool = (PYTool)tools[Step];
                        PYTool.Py_Path = localFilePath;


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 步骤跳转_TextChanged(object sender, EventArgs e)
        {
            try
            {
                PYTool PYTool;
                int Step = int.Parse(步骤.Text);
                List<ImageTool> tools;
                tools = LoadData._ImageToolRun[TOOLName.Text];
                PYTool = (PYTool)tools[Step];
                PYTool.FlowChar_StepControlLoop = int.Parse(步骤跳转.Text);
            }
            catch (Exception)
            {
            }
        }
    }
}
