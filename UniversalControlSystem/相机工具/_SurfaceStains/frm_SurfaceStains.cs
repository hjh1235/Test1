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
    public partial class frm_SurfaceStains : Form
    {

        static frm_SurfaceStains frm;
        SurfaceStainsTool surfaceStainsTool = new SurfaceStainsTool();
        public delegate void HandledSetVal(SurfaceStainsTool surfaceStainsTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_SurfaceStains SingleShow(SurfaceStainsTool surfaceStainsTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_SurfaceStains(surfaceStainsTool, handleSetval);
            }
            return frm;
        }

        public frm_SurfaceStains()
        {
            InitializeComponent();
        }
        public frm_SurfaceStains(SurfaceStainsTool surfaceStainsTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(surfaceStainsTool);
            this.surfaceStainsTool.Image = surfaceStainsTool.Image;
            this.surfaceStainsTool.Circle = surfaceStainsTool.Circle;
            this.surfaceStainsTool.Rectangle1 = surfaceStainsTool.Rectangle1;
            this.surfaceStainsTool.Rectangle2 = surfaceStainsTool.Rectangle2;
            this.SetVal(ref this.surfaceStainsTool);
        }

        void DisplayVal(SurfaceStainsTool surfaceStainsTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = surfaceStainsTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = surfaceStainsTool.Names.Substring(nameIndex + 1, surfaceStainsTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = surfaceStainsTool.Names;
                    tbxToolName.Text = surfaceStainsTool.Names;
                }
                cbxImage.Text = surfaceStainsTool.ImageName;//
                cbxRoi.Text = surfaceStainsTool.SetdrawShape;
                cbxFixture.Text = surfaceStainsTool.FixNames;
                cebxFixture.Checked = surfaceStainsTool.IsFixture;

                nudSigma1.Value = Convert.ToDecimal(surfaceStainsTool.Sigma1.D);
                nudSigma2.Value = Convert.ToDecimal(surfaceStainsTool.Sigma2.D);
                takBarLowThreshold.Value = surfaceStainsTool.MinGray.I;
                takBarHigThreshold.Value = surfaceStainsTool.MaxGray.I;
                lbl_low.Text = "低阀值:" + takBarLowThreshold.Value.ToString();
                lbl_higt.Text = "高阀值:" + takBarHigThreshold.Value.ToString();

                cbxFeature.Text = surfaceStainsTool.Feature;
                nudMinStains.Value = Convert.ToDecimal(surfaceStainsTool.SelecteMin.D);
                nudMaxStains.Value = Convert.ToDecimal(surfaceStainsTool.SelecteMax.D);

                cebxIsSurfaceStani.Checked = surfaceStainsTool.IsStains;
                cbxRoi.Text = surfaceStainsTool.SetdrawShape;

                cbxSetdraw.Text = surfaceStainsTool.Setdraw;
                ceboxIsRoi.Checked = surfaceStainsTool.IsRoi;
                cbxImage.Items.Clear();
                if (surfaceStainsTool.Image != null)
                {
                    foreach (var item in surfaceStainsTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                   // halconView1.DispImage((HObject)surfaceStainsTool.Image[cbxImage.Text], true);
                    //halconView1.FitImage();
                }
              
            }
            catch (Exception ex)
            {
                cbxImage.Items.Clear();
                if (surfaceStainsTool.Image != null)
                {
                    foreach (var item in surfaceStainsTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                  //  halconView1.DispImage((HObject)surfaceStainsTool.Image[cbxImage.Text], true);
                  //  halconView1.FitImage();
                }
            
            }
            Register();//注册事件
        }

        void Cancel()
        {
            nudSigma1.ValueChanged -= new EventHandler(nudSigma1_ValueChanged);
            nudSigma2.ValueChanged -= new EventHandler(nudSigma2_ValueChanged);
            takBarLowThreshold.Scroll -= new EventHandler(takBarLowThreshold_Scroll);
            takBarHigThreshold.Scroll -= new EventHandler(takBarHigThreshold_Scroll);
            nudMinStains.ValueChanged -= new EventHandler(nudMinStains_ValueChanged);
            nudMaxStains.ValueChanged -= new EventHandler(nudMaxStains_ValueChanged);
            cebxIsSurfaceStani.CheckedChanged -= new EventHandler(cebxIsSurfaceStani_CheckedChanged);
            ceboxIsRoi.CheckedChanged -= new EventHandler(ceboxIsRoi_CheckedChanged);
            cebxIsRectangle.CheckedChanged -= new EventHandler(cebxIsRectangle_CheckedChanged);
            cbxSetdraw.TextChanged -= new EventHandler(cbxSetdraw_SelectedIndexChanged);
            cbxFeature.SelectedIndexChanged -= new EventHandler(cbxFeature_SelectedIndexChanged);


        }
        void Register()
        {
            nudSigma1.ValueChanged += new EventHandler(nudSigma1_ValueChanged);
            nudSigma2.ValueChanged += new EventHandler(nudSigma2_ValueChanged);
            takBarLowThreshold.Scroll += new EventHandler(takBarLowThreshold_Scroll);
            takBarHigThreshold.Scroll += new EventHandler(takBarHigThreshold_Scroll);
            nudMinStains.ValueChanged += new EventHandler(nudMinStains_ValueChanged);
            nudMaxStains.ValueChanged += new EventHandler(nudMaxStains_ValueChanged);
            cebxIsSurfaceStani.CheckedChanged += new EventHandler(cebxIsSurfaceStani_CheckedChanged);
            ceboxIsRoi.CheckedChanged += new EventHandler(ceboxIsRoi_CheckedChanged);
            cebxIsRectangle.CheckedChanged += new EventHandler(cebxIsRectangle_CheckedChanged);
            cbxSetdraw.TextChanged += new EventHandler(cbxSetdraw_SelectedIndexChanged);
            cbxFeature.SelectedIndexChanged += new EventHandler(cbxFeature_SelectedIndexChanged);
        }

        void SetVal(ref SurfaceStainsTool surfaceStainsTool)

        {
            surfaceStainsTool.ImageName = cbxImage.Text;
            surfaceStainsTool.Names = ImageTool.Tool.脏污提取检测.ToString() + "_" + tbxToolName.Text;
            surfaceStainsTool.FixNames = cbxFixture.Text;
            surfaceStainsTool.IsFixture = cebxFixture.Checked;
            surfaceStainsTool.Sigma1 = (double)nudSigma1.Value;
            surfaceStainsTool.Sigma2 = (double)nudSigma2.Value;
            surfaceStainsTool.MinGray = takBarLowThreshold.Value;
            surfaceStainsTool.MaxGray = takBarHigThreshold.Value;
            surfaceStainsTool.Feature = cbxFeature.Text;
            surfaceStainsTool.SelecteMin = (int)nudMinStains.Value;
            surfaceStainsTool.SelecteMax = (int)nudMaxStains.Value;
            surfaceStainsTool.IsStains = cebxIsSurfaceStani.Checked;
            surfaceStainsTool.SetdrawShape = cbxRoi.Text;
            surfaceStainsTool.Setdraw = cbxSetdraw.Text;
            surfaceStainsTool.IsRoi = ceboxIsRoi.Checked;
            surfaceStainsTool.IsRectangle = cebxIsRectangle.Checked;
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            surfaceStainsTool.ImageName = cbxImage.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //halconView1.DispImage((HObject)this.surfaceStainsTool.Image[cbxImage.Text], true);
           // halconView1.FitImage();
            surfaceStainsTool.ImageName = cbxImage.Text;
        }

        private void nudSigma2_ValueChanged(object sender, EventArgs e)
        {
            surfaceStainsTool.Sigma2 = (double)nudSigma2.Value;
            surfaceStainsTool.set_after();

        }

        private void nudSigma1_ValueChanged(object sender, EventArgs e)
        {
            surfaceStainsTool.Sigma1 = (double)nudSigma1.Value;
            surfaceStainsTool.set_after();

        }

        private void takBarLowThreshold_Scroll(object sender, EventArgs e)
        {
            lbl_low.Text = "低阀值:" + takBarLowThreshold.Value.ToString();
            surfaceStainsTool.MinGray = takBarLowThreshold.Value;
            surfaceStainsTool.set_after();

        }

        private void takBarHigThreshold_Scroll(object sender, EventArgs e)
        {
            lbl_higt.Text = "高阀值:" + takBarHigThreshold.Value.ToString();
            surfaceStainsTool.MaxGray = takBarHigThreshold.Value;
            surfaceStainsTool.set_after();

        }

        private void nudMinStains_ValueChanged(object sender, EventArgs e)
        {
            surfaceStainsTool.SelecteMin = (int)nudMinStains.Value;
            surfaceStainsTool.set_after();

        }

        private void nudMaxStains_ValueChanged(object sender, EventArgs e)
        {
            surfaceStainsTool.SelecteMax = (int)nudMaxStains.Value;
            surfaceStainsTool.set_after();
        }

        private void cbxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            surfaceStainsTool.SetdrawShape = cbxRoi.Text;
     
        }

        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            if (cbxRoi.Text == BlobTool.Roi.方向矩形.ToString())
                surfaceStainsTool.SetdrawShape = BlobTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.矩形.ToString())
                surfaceStainsTool.SetdrawShape = BlobTool.Roi.矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.圆.ToString())
                surfaceStainsTool.SetdrawShape = BlobTool.Roi.圆.ToString();
           // halconView1.ContextMenuStripHide();
          //  halconView1.Focus();
            surfaceStainsTool.draw_roi();
        }

        private void cbxSetdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
            surfaceStainsTool.Setdraw = cbxSetdraw.Text;
        }

        private void ceboxIsRoi_CheckedChanged(object sender, EventArgs e)
        {
            surfaceStainsTool.IsRoi = ceboxIsRoi.Checked;
        }

        private void cebxIsSurfaceStani_CheckedChanged(object sender, EventArgs e)
        {
            surfaceStainsTool.IsStains = cebxIsSurfaceStani.Checked;
            surfaceStainsTool.set_after();
        }

        private void cebxIsRectangle_CheckedChanged(object sender, EventArgs e)
        {
            surfaceStainsTool.IsRectangle = cebxIsRectangle.Checked;
            surfaceStainsTool.set_after();
        }
        private void cbxSetdraw_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            surfaceStainsTool.set_after();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = surfaceStainsTool.set_after();
           // halconView1.ToolLable2.Text = "FAIL";
         //   halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.surfaceStainsTool.ResultLogic)
            {
               // halconView1.ToolLable2.Text = "PASS";
               // halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
          //  halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.surfaceStainsTool);
                this.Hide();
                frm = null;
                handleSetval(this.surfaceStainsTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.surfaceStainsTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void frm_SurfaceStains_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormClosing += Frm_SurfaceStains_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.surfaceStainsTool.hWindowControl1 = hWindowControl1;
            string[] roi = new string[] { BlobTool.Roi.方向矩形.ToString(), BlobTool.Roi.矩形.ToString(), BlobTool.Roi.圆.ToString() };
            cbxRoi.Items.AddRange(roi);
            this.CenterToScreen();
        }

        private void Frm_SurfaceStains_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            surfaceStainsTool.dispresult();
        }

        private void cbxFeature_SelectedIndexChanged(object sender, EventArgs e)
        {
            surfaceStainsTool.Feature = cbxFeature.Text;
            surfaceStainsTool.set_after();
        }

     
    }
}
