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
    public partial class frm_MedianImage : Form
    {
        static frm_MedianImage frm;
        MedianImageTool medianImageTool = new MedianImageTool();
        public delegate void HandledSetVal(MedianImageTool medianImageTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_MedianImage SingleShow(MedianImageTool medianImageTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_MedianImage(medianImageTool, handleSetval);
            }
            return frm;
        }
        public frm_MedianImage(MedianImageTool medianImageTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(medianImageTool);
            this.medianImageTool.Image = medianImageTool.Image;
            this.SetVal(ref this.medianImageTool);
        }
        public frm_MedianImage()
        {
            InitializeComponent();
        }
        void DisplayVal(MedianImageTool medianImageTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = medianImageTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = medianImageTool.Names.Substring(nameIndex + 1, medianImageTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = medianImageTool.Names;
                    tbxToolName.Text = medianImageTool.Names;
                }
                cbxImage.Text = medianImageTool.ImageName;//
                cbxMaskType.Text = medianImageTool.MaskType.ToString();
                cbxMargin.Text = medianImageTool.Margin.ToString();
                lbl_low.Text = "区域半径:" + takBarRadius.Value.ToString();
                takBarRadius.Value = medianImageTool.Radius;
                cbxImage.Items.Clear();
                if (medianImageTool.Image != null)
                {                                                               
                    foreach (var item in medianImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                //halconView1.DispImage((HObject)medianImageTool.Image[cbxImage.Text], true);
                //halconView1.FitImage();
            }
            catch
            {
                cbxImage.Items.Clear();
                if (medianImageTool.Image != null)
                {
                    foreach (var item in medianImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
            }
            Register();//注册事件
        }
        void Cancel()
        {
            cbxMaskType.SelectedIndexChanged -= new EventHandler(cbxMaskType_SelectedIndexChanged);
            cbxMargin.SelectedIndexChanged -= new EventHandler(cbxMargin_SelectedIndexChanged);
            takBarRadius.Scroll -= new EventHandler(takBarRadius_Scroll);
        }
        void Register()
        {
            cbxMaskType.SelectedIndexChanged += new EventHandler(cbxMaskType_SelectedIndexChanged);
            cbxMargin.SelectedIndexChanged += new EventHandler(cbxMargin_SelectedIndexChanged);
            takBarRadius.Scroll += new EventHandler(takBarRadius_Scroll);
        }
        void SetVal(ref MedianImageTool medianImageTool)
        {
            medianImageTool.Names = ImageTool.Tool.中值滤波图像.ToString() + "_" + tbxToolName.Text;
            medianImageTool.ImageName = cbxImage.Text;
            medianImageTool.MaskType = cbxMaskType.Text;
            medianImageTool.Margin = cbxMargin.Text;
            medianImageTool.Radius = takBarRadius.Value;
       
        }

        private void frm_MedianImage_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.FormClosing += frm_MedianImage_FormClosing;
            this.medianImageTool.hWindowControl1 = hWindowControl1;
         }
        void frm_MedianImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
         private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.medianImageTool.Names = ImageTool.Tool.中值滤波图像.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }
        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  halconView1.DispImage((HObject)this.medianImageTool.Image[cbxImage.Text], true);
           // halconView1.FitImage();
            medianImageTool.ImageName = cbxImage.Text;
        }
        private void cbxMaskType_SelectedIndexChanged(object sender, EventArgs e)
        {
            medianImageTool.MaskType = cbxMaskType.Text;
            this.medianImageTool.set_after();
         }
        private void cbxMargin_SelectedIndexChanged(object sender, EventArgs e)
        {
            medianImageTool.Margin = cbxMargin.Text;
            this.medianImageTool.set_after();
        }

        private void takBarRadius_Scroll(object sender, EventArgs e)
        {
            medianImageTool.Radius = takBarRadius.Value;
            lbl_low.Text = "区域半径:" + takBarRadius.Value.ToString();
            this.medianImageTool.set_after();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer =this.medianImageTool.set_after();
           // halconView1.ToolLable2.Text = "FAIL";
           // halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.medianImageTool.ResultLogic)
            {
              //  halconView1.ToolLable2.Text = "PASS";
               // halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
           // halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.medianImageTool);
                this.Hide();
                frm = null;
                handleSetval(this.medianImageTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.medianImageTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

  
    }
}
