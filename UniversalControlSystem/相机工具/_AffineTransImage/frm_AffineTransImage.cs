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
    public partial class frm_AffineTransImage : Form
    {
        static frm_AffineTransImage frm;
        AffineTransImageTool affineTransImageTool = new AffineTransImageTool();
        public delegate void HandledSetVal(AffineTransImageTool affineTransImage);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_AffineTransImage SingleShow(AffineTransImageTool affineTransImage, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_AffineTransImage(affineTransImage, handleSetval);
            }
            return frm;
        }
        public frm_AffineTransImage(AffineTransImageTool affineTransImage, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(affineTransImageTool);
            this.affineTransImageTool.Image = affineTransImage.Image;
            this.affineTransImageTool.HtHomMat2D = affineTransImage.HtHomMat2D;
            this.affineTransImageTool.HtHomMat2D1 = affineTransImage.HtHomMat2D1;
            this.SetVal(ref this.affineTransImageTool);
        }
        void DisplayVal(AffineTransImageTool affineTransImage)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = affineTransImage.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = affineTransImage.Names.Substring(nameIndex + 1, affineTransImage.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = affineTransImage.Names;
                    tbxToolName.Text = affineTransImage.Names;
                }
                cbxImage.Text = affineTransImage.ImageName;//
                cbxFixture.Text = affineTransImage.FixNames;

                cbxImage.Items.Clear();
                if (affineTransImage.Image != null)
                {
                    foreach (var item in affineTransImage.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                //halconView1.DispImage((HObject)affineTransImage.Image[cbxImage.Text], true);
                //halconView1.FitImage();
                cbxFixture.Items.Clear();
                if (affineTransImage.HtHomMat2D != null)
                {
                    foreach (var item in affineTransImage.HtHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
            }
            catch
            {
                cbxImage.Items.Clear();
                if (affineTransImage.Image != null)
                {
                    foreach (var item in affineTransImage.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (affineTransImage.HtHomMat2D != null)
                {
                    foreach (var item in affineTransImage.HtHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
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
        void SetVal(ref AffineTransImageTool affineTransImage)
        {
            affineTransImage.Names = AffineTransImageTool.Tool.补正图像.ToString() + "_" + tbxToolName.Text;
            affineTransImage.ImageName = cbxImage.Text;
            affineTransImage.FixNames = cbxFixture.Text;
        }
        public frm_AffineTransImage()
        {
            InitializeComponent();
        }
        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            affineTransImageTool.Names = AffineTransImageTool.Tool.补正图像.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }
        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //halconView1.DispImage((HObject)this.affineTransImageTool.Image[cbxImage.Text], true);
            //halconView1.FitImage();
            affineTransImageTool.ImageName = cbxImage.Text;
        }
        private void frm_AffineTransImage_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(HW.Instance().HalconWindow, "background_color", "blue");
            this.CenterToScreen();

            HW.Instance().TopLevel = false;
            panel1.Controls.Add(HW.Instance());
            HW.Instance().Size = panel1.Size;
            HW.Instance().Show();


            this.FormClosing += frm_AffineTransImage_FormClosing;
            this.affineTransImageTool.hWindowControl1 = HW.Instance().HWindowControl;
        }

        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
            affineTransImageTool.FixNames = cbxFixture.Text;
        }
        void frm_AffineTransImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = this.affineTransImageTool.set_after();
            HW.Instance().ToolLable2.Text = "FAIL";
            HW.Instance().ToolLable2.ForeColor = Color.Red;
            if (this.affineTransImageTool.ResultLogic)
            {
                HW.Instance().ToolLable2.Text = "PASS";
                HW.Instance().ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            HW.Instance().ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.affineTransImageTool);
                this.Hide();
                frm = null;
                handleSetval(this.affineTransImageTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.affineTransImageTool);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }
    }
}
