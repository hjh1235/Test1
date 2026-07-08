using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UniversalControlSystem
{
    public partial class frm_SaveImage : Form
    {
        static frm_SaveImage frm;
        SaveImageTool saveImageTool /*= new SaveImageTool()*/;
        //public delegate void HandledSetVal(SaveImageTool saveImageTool);
        //HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_SaveImage SingleShow(SaveImageTool saveImageTool/*, HandledSetVal handleSetval*/)
        {
            if (frm == null)//
            {
                frm = new frm_SaveImage(saveImageTool/*, handleSetval*/);
            }
            return frm;
        }
        public frm_SaveImage()
        {
            InitializeComponent();
        }

        public frm_SaveImage(SaveImageTool saveImageTool/*, HandledSetVal handleSetval*/)
        {
            InitializeComponent();
           // this.handleSetval = handleSetval;
            DisplayVal(saveImageTool);
            saveImageTool.Image = saveImageTool.Image;
            SetVal(ref this.saveImageTool);

        }

        void DisplayVal(SaveImageTool saveImageTool)
        {
            try
            {
                //Cancel();//注销事件
                int nameIndex = saveImageTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = saveImageTool.Names.Substring(nameIndex + 1, saveImageTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = saveImageTool.Names;
                    tbxToolName.Text = saveImageTool.Names;
                }
                cbxImage.Text = saveImageTool.ImageName;//
                ceboxDeleteDir.Checked = saveImageTool.IsDeleteDir;
                ceboxDumpWin.Checked = saveImageTool.IsDumpWindow;
                tbxPath0.Text = saveImageTool.ImagePath;
                tboxSaveDay.Text = saveImageTool.SaveDay;
                cboxFormat.Text = saveImageTool.ImageFormat;
                cbxImage.Items.Clear();
                if (saveImageTool.Image != null)
                {
                    foreach (var item in saveImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }


            }
            catch
            {
                cbxImage.Items.Clear();
                if (saveImageTool.Image != null)
                {
                    foreach (var item in saveImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
            }

           }
        void SetVal(ref SaveImageTool saveImageTool)
        {
            saveImageTool.Names = ImageTool.Tool.存储图像.ToString() + "_" + tbxToolName.Text;
            saveImageTool.ImageName = cbxImage.Text;
            saveImageTool.IsDeleteDir = ceboxDeleteDir.Checked;
            saveImageTool.IsDumpWindow = ceboxDumpWin.Checked;
            saveImageTool.ImagePath = tbxPath0.Text;
            saveImageTool.SaveDay = tboxSaveDay.Text;
            saveImageTool.ImageFormat = cboxFormat.Text;

        }
        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            saveImageTool.Names = ImageTool.Tool.存储图像.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveImageTool.ImageName = cbxImage.Text;
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog pathDialog = new FolderBrowserDialog();
            pathDialog.SelectedPath = tbxPath0.Text;
            pathDialog.Description = "保存图片路径";
            if (DialogResult.OK == pathDialog.ShowDialog())
            {
                tbxPath0.Text = pathDialog.SelectedPath;
                saveImageTool.ImagePath= pathDialog.SelectedPath;
            }
        }
        private void ceboxDeleteDir_CheckedChanged(object sender, EventArgs e)
        {
            saveImageTool.IsDeleteDir = ceboxDeleteDir.Checked;
        }
        private void cboxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveImageTool.ImageFormat = cboxFormat.Text;
        }
        private void tboxSaveDay_TextChanged(object sender, EventArgs e)
        {
            saveImageTool.SaveDay = tboxSaveDay.Text;
        }
        private void ceboxDumpWin_CheckedChanged(object sender, EventArgs e)
        {
            saveImageTool.IsDumpWindow = ceboxDumpWin.Checked;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = saveImageTool.set_after();
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.saveImageTool);
                this.Hide();
               // frm = null;
                //handleSetval(this.saveImageTool);
            }
            catch
            {
                this.Hide();
               // frm = null;
              //  handleSetval(this.saveImageTool);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }
        string _RunFlowData_ControlDataName = "";
        string _FlowChar_StepControlStepName = "";
        int Num = 0;
        public void ShowMesage(string Name, string StepName, int num)
        {
            TOOLName.Text = StepName;
            _RunFlowData_ControlDataName = Name;
            _FlowChar_StepControlStepName = StepName;
            Num = num;
            步骤.Text = Num.ToString();
            //AcqFifoTool _AcqFifoTool;
            List<ImageTool> tools;

            tools = LoadData._ImageToolRun[TOOLName.Text];
            saveImageTool = (SaveImageTool)tools[Num];
          
            DisplayVal(saveImageTool);//显示参数
            SetVal(ref saveImageTool);//设置参数
        }
        private void frm_SaveImage_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.CenterToScreen();
            this.FormClosing += Frm_SaveImage_FormClosing;
        }

        private void Frm_SaveImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
    }
}
