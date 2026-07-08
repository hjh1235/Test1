using HalconDotNet;
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
    public partial class frm_ProjectiveTransImage : Form
    {
        static frm_ProjectiveTransImage frm;
        ProjectiveTransImageTool projectiveTransImageTool = new ProjectiveTransImageTool();
        public delegate void HandledSetVal(ProjectiveTransImageTool projectiveTransImageTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_ProjectiveTransImage SingleShow(ProjectiveTransImageTool projectiveTransImageTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_ProjectiveTransImage(projectiveTransImageTool, handleSetval);
            }
            return frm;
        }
        public frm_ProjectiveTransImage(ProjectiveTransImageTool projectiveTransImageTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(projectiveTransImageTool);
            this.projectiveTransImageTool.Image = projectiveTransImageTool.Image;
            this.projectiveTransImageTool.RowsCoord = projectiveTransImageTool.RowsCoord;
            this.projectiveTransImageTool.ColsCoord = projectiveTransImageTool.ColsCoord;
            this.SetVal(ref this.projectiveTransImageTool);
        }

        public frm_ProjectiveTransImage()
        {
            InitializeComponent();
        }

        void DisplayVal(ProjectiveTransImageTool projectiveTransImageTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = projectiveTransImageTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = projectiveTransImageTool.Names.Substring(nameIndex + 1, projectiveTransImageTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = projectiveTransImageTool.Names;
                    tbxToolName.Text = projectiveTransImageTool.Names;
                }
                cbxImage.Text = projectiveTransImageTool.ImageName;//

                cbxImage.Items.Clear();
                if (projectiveTransImageTool.Image != null)
                {
                    foreach (var item in projectiveTransImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
              //  halconView1.DispImage((HObject)projectiveTransImageTool.Image[cbxImage.Text], true);
               // halconView1.FitImage();
            }
            catch
            {
                cbxImage.Items.Clear();
                if (projectiveTransImageTool.Image != null)
                {
                    foreach (var item in projectiveTransImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
            }
            Register();//注册事件
        }

        void Cancel()
        {

        }
        void Register()
        {

        }
        void SetVal(ref ProjectiveTransImageTool projectiveTransImageTool)
        {
            projectiveTransImageTool.Names = ImageTool.Tool.投影图像.ToString() + "_" + tbxToolName.Text;
            projectiveTransImageTool.ImageName = cbxImage.Text;


        }

        private void frm_Smooth_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.FormClosing += frm_Smooth_FormClosing;
            this.projectiveTransImageTool.hWindowControl1 = hWindowControl1;
        }

        void frm_Smooth_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.projectiveTransImageTool.Names = ImageTool.Tool.投影图像.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
           // halconView1.DispImage((HObject)this.projectiveTransImageTool.Image[cbxImage.Text], true);
           // halconView1.FitImage();
            projectiveTransImageTool.ImageName = cbxImage.Text;

        }
        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void nudAlpha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = this.projectiveTransImageTool.set_after();
            //halconView1.ToolLable2.Text = "FAIL";
            //halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.projectiveTransImageTool.ResultLogic)
            {
             //   halconView1.ToolLable2.Text = "PASS";
             //   halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
           // halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.projectiveTransImageTool);
                this.Hide();
                frm = null;
                handleSetval(this.projectiveTransImageTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.projectiveTransImageTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }
        private void halconView1_HMouseWheelEvent(object sender)
        {
            projectiveTransImageTool.dispresult();
        }

        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
          //  halconView1.Focus();
          //  halconView1.ContextMenuStripHide();
            projectiveTransImageTool.draw_roi();
            this.projectiveTransImageTool.set_after();
        }
    }
}
