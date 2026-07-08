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
    public partial class frm_MeanImage : Form
    {
        static frm_MeanImage frm;
        MeanImageTool meanImageTool = new MeanImageTool();
        public delegate void HandledSetVal(MeanImageTool meanImageTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_MeanImage SingleShow(MeanImageTool meanImageTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_MeanImage(meanImageTool, handleSetval);
            }
            return frm;
        }
        public frm_MeanImage(MeanImageTool meanImageTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(meanImageTool);
            this.meanImageTool.Image = meanImageTool.Image;
            this.SetVal(ref this.meanImageTool);
        }


        void DisplayVal(MeanImageTool meanImageTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = meanImageTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = meanImageTool.Names.Substring(nameIndex + 1, meanImageTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = meanImageTool.Names;
                    tbxToolName.Text = meanImageTool.Names;
                }
                cbxImage.Text = meanImageTool.ImageName;//
                takBarMaskHeight.Value = meanImageTool.MaskHeight;
                lbl_hig.Text = "遮掩的高度:" + takBarMaskHeight.Value.ToString();
                takBarMaskWidth.Value = meanImageTool.MaskWidth;
                lbl_low.Text = "遮掩的宽度:" + takBarMaskWidth.Value.ToString();
                cbxImage.Items.Clear();
                if (meanImageTool.Image != null)
                {
                    foreach (var item in meanImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
              //  halconView1.DispImage((HObject)meanImageTool.Image[cbxImage.Text], true);
              //  halconView1.FitImage();
            }
            catch
            {
                cbxImage.Items.Clear();
                if (meanImageTool.Image != null)
                {
                    foreach (var item in meanImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
            }
            Register();//注册事件
        }

        void Cancel()
        {
            takBarMaskHeight.ValueChanged -= new EventHandler(takBarMaskHeight_Scroll);
            takBarMaskWidth.ValueChanged -= new EventHandler(takBarMaskWidth_Scroll);
        }
        void Register()
        {
            takBarMaskHeight.ValueChanged += new EventHandler(takBarMaskHeight_Scroll);
            takBarMaskWidth.ValueChanged += new EventHandler(takBarMaskWidth_Scroll);
        }
        void SetVal(ref MeanImageTool meanImageTool)
        {
            meanImageTool.Names = MeanImageTool.Tool.均值滤波图像.ToString() + "_" + tbxToolName.Text;
            meanImageTool.ImageName = cbxImage.Text;
            meanImageTool.MaskWidth = takBarMaskWidth.Value;
            meanImageTool.MaskHeight = takBarMaskHeight.Value;
        }
        public frm_MeanImage()
        {
            InitializeComponent();
        }

        private void frm_MeanImage_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.FormClosing += frm_MeanImage_FormClosing;
            this.meanImageTool.hWindowControl1 = hWindowControl1;
        }

        void frm_MeanImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.meanImageTool.Names = ImageTool.Tool.均值滤波图像.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }
        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
           // halconView1.DispImage((HObject)this.meanImageTool.Image[cbxImage.Text], true);
           // halconView1.FitImage();
            meanImageTool.ImageName = cbxImage.Text;
        }

        private void takBarMaskWidth_Scroll(object sender, EventArgs e)
        {
            lbl_low.Text = "遮掩的宽度:" + takBarMaskWidth.Value.ToString();
            meanImageTool.MaskWidth = takBarMaskWidth.Value;
            this.meanImageTool.set_after();
        }
         private void takBarMaskHeight_Scroll(object sender, EventArgs e)
        {
            lbl_hig.Text = "遮掩的高度:" + takBarMaskHeight.Value.ToString();
            meanImageTool.MaskHeight = takBarMaskHeight.Value;
            this.meanImageTool.set_after();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = this.meanImageTool.set_after();
          //  halconView1.ToolLable2.Text = "FAIL";
         //   halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.meanImageTool.ResultLogic)
            {
              //  halconView1.ToolLable2.Text = "PASS";
             //   halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
           // halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.meanImageTool);
                this.Hide();
                frm = null;
                handleSetval(this.meanImageTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.meanImageTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }
    }
}
