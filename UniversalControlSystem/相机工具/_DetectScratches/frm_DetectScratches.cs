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
    public partial class frm_DetectScratches : Form
    {


        static frm_DetectScratches frm;
        DetectScratchesTool detectScratchesTool = new DetectScratchesTool();
        public delegate void HandledSetVal(DetectScratchesTool detectScratchesTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_DetectScratches SingleShow(DetectScratchesTool detectScratchesTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_DetectScratches(detectScratchesTool, handleSetval);
            }
            return frm;
        }
        public frm_DetectScratches()
        {
            InitializeComponent();
        }

        public frm_DetectScratches(DetectScratchesTool detectScratchesTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(detectScratchesTool);
            this.detectScratchesTool.Image = detectScratchesTool.Image;
            this.detectScratchesTool.Circle = detectScratchesTool.Circle;
            this.detectScratchesTool.Rectangle1 = detectScratchesTool.Rectangle1;
            this.detectScratchesTool.Rectangle2 = detectScratchesTool.Rectangle2;
            this.SetVal(ref this.detectScratchesTool);

        }

        void DisplayVal(DetectScratchesTool detectScratchesTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = detectScratchesTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = detectScratchesTool.Names.Substring(nameIndex + 1, detectScratchesTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = detectScratchesTool.Names;
                    tbxToolName.Text = detectScratchesTool.Names;
                }
                cbxImage.Text = detectScratchesTool.ImageName;//
                cbxRoi.Text = detectScratchesTool.SetdrawShape;
                cbxFixture.Text = detectScratchesTool.FixNames;
                cebxFixture.Checked = detectScratchesTool.IsFixture;

                nudScratchWidth.Value = Convert.ToDecimal(detectScratchesTool.ScratchWidth.D);
                nudScratchContrast.Value = Convert.ToDecimal(detectScratchesTool.ScratchContrast.D);
                nudSigma.Value = Convert.ToDecimal(detectScratchesTool.Sigma.D);
                nudMinScratchLength.Value = Convert.ToDecimal(detectScratchesTool.MinScratchLength.D);
                nudMaxScratchLength.Value = Convert.ToDecimal(detectScratchesTool.MaxScratchLength.D);
                cbxScratchProperty.Text = detectScratchesTool.ScratchProperty;
                cebxIsRectangle.Checked = detectScratchesTool.IsRectangle;
                cebxIsScratchesXLD.Checked = detectScratchesTool.IsScratchesXLD;
                cbxSetdraw.Text = detectScratchesTool.Setdraw;
                ceboxIsRoi.Checked = detectScratchesTool.IsRoi;
                cbxImage.Items.Clear();
                if (detectScratchesTool.Image != null)
                {
                    foreach (var item in detectScratchesTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
               // halconView1.DispImage((HObject)detectScratchesTool.Image[cbxImage.Text], true);
               // halconView1.FitImage();
            }
            catch
            {
                cbxImage.Items.Clear();
                if (detectScratchesTool.Image != null)
                {
                    foreach (var item in detectScratchesTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }

            }
            Register();//注册事件
        }

        void Cancel()
        {
            cbxFixture.SelectedIndexChanged -= new EventHandler(cbxFixture_SelectedIndexChanged);
            cebxFixture.CheckedChanged -= new EventHandler(cebxFixture_CheckedChanged);
            nudScratchWidth.ValueChanged -= new EventHandler(nudScratchWidth_ValueChanged);
            nudScratchContrast.ValueChanged -= new EventHandler(nudScratchContrast_ValueChanged);
            nudSigma.ValueChanged -= new EventHandler(nudSigma_ValueChanged);
            nudMinScratchLength.ValueChanged -= new EventHandler(nudMinScratchLength_ValueChanged);
            nudMaxScratchLength.ValueChanged -= new EventHandler(nudMaxScratchLength_ValueChanged);
            cbxScratchProperty.SelectedIndexChanged -= new EventHandler(cbxScratchProperty_SelectedIndexChanged);
            cebxIsScratchesXLD.CheckedChanged -= new EventHandler(cebxIsScratchesXLD_CheckedChanged);
            cebxIsRectangle.CheckedChanged -= new EventHandler(cebxIsRectangle_CheckedChanged);
            cbxSetdraw.SelectedIndexChanged -= new EventHandler(cbxSetdraw_SelectedIndexChanged);
            ceboxIsRoi.CheckedChanged -= new EventHandler(ceboxIsRoi_CheckedChanged);
            

        }
        void Register()
        {
            cbxFixture.SelectedIndexChanged += new EventHandler(cbxFixture_SelectedIndexChanged);
            cebxFixture.CheckedChanged += new EventHandler(cebxFixture_CheckedChanged);
            nudScratchWidth.ValueChanged += new EventHandler(nudScratchWidth_ValueChanged);
            nudScratchContrast.ValueChanged += new EventHandler(nudScratchContrast_ValueChanged);
            nudSigma.ValueChanged += new EventHandler(nudSigma_ValueChanged);
            nudMinScratchLength.ValueChanged += new EventHandler(nudMinScratchLength_ValueChanged);
            nudMaxScratchLength.ValueChanged += new EventHandler(nudMaxScratchLength_ValueChanged);
            cbxScratchProperty.SelectedIndexChanged += new EventHandler(cbxScratchProperty_SelectedIndexChanged);
            cebxIsScratchesXLD.CheckedChanged += new EventHandler(cebxIsScratchesXLD_CheckedChanged);
            cebxIsRectangle.CheckedChanged += new EventHandler(cebxIsRectangle_CheckedChanged);
            cbxSetdraw.SelectedIndexChanged += new EventHandler(cbxSetdraw_SelectedIndexChanged);
            ceboxIsRoi.CheckedChanged += new EventHandler(ceboxIsRoi_CheckedChanged);

        }
        void SetVal(ref DetectScratchesTool detectScratchesTool)
        {

            detectScratchesTool.ImageName = cbxImage.Text;
            detectScratchesTool.Names = ImageTool.Tool.划痕提取检测.ToString() + "_" + tbxToolName.Text;
            detectScratchesTool.FixNames = cbxFixture.Text;
            detectScratchesTool.IsFixture = cebxFixture.Checked;

            detectScratchesTool.ScratchWidth = (double)nudScratchWidth.Value;
            detectScratchesTool.ScratchContrast = (double)nudScratchContrast.Value;
            detectScratchesTool.Sigma = (double)nudSigma.Value;
            detectScratchesTool.MinScratchLength = (double)nudMinScratchLength.Value;
            detectScratchesTool.MaxScratchLength = (double)nudMaxScratchLength.Value;
            detectScratchesTool.ScratchProperty = cbxScratchProperty.Text;
            detectScratchesTool.IsRectangle = cebxIsRectangle.Checked;
            detectScratchesTool.IsScratchesXLD = cebxIsScratchesXLD.Checked;
            detectScratchesTool.Setdraw = cbxSetdraw.Text;
            detectScratchesTool.SetdrawShape = cbxRoi.Text;
            detectScratchesTool.IsRoi = ceboxIsRoi.Checked;

        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.detectScratchesTool.Names = ImageTool.Tool.划痕提取检测.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  halconView1.DispImage((HObject)this.detectScratchesTool.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
            detectScratchesTool.ImageName = cbxImage.Text;
        }
        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
            detectScratchesTool.FixNames = cbxFixture.Text;
        }
        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            detectScratchesTool.IsFixture = cebxFixture.Checked;
        }

        private void nudScratchWidth_ValueChanged(object sender, EventArgs e)
        {
            detectScratchesTool.ScratchWidth = (double)nudScratchWidth.Value;
            detectScratchesTool.set_after();
        }

        private void nudScratchContrast_ValueChanged(object sender, EventArgs e)
        {
            detectScratchesTool.ScratchContrast = (double)nudScratchContrast.Value;
            detectScratchesTool.set_after();
        }

        private void nudSigma_ValueChanged(object sender, EventArgs e)
        {
            detectScratchesTool.Sigma = (double)nudSigma.Value;
            detectScratchesTool.set_after();
        }

        private void nudMinScratchLength_ValueChanged(object sender, EventArgs e)
        {
            detectScratchesTool.MinScratchLength = (double)nudMinScratchLength.Value;
            detectScratchesTool.set_after();
        }

        private void nudMaxScratchLength_ValueChanged(object sender, EventArgs e)
        {
            detectScratchesTool.MaxScratchLength = (double)nudMaxScratchLength.Value;
            detectScratchesTool.set_after();
        }

        private void cbxScratchProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            detectScratchesTool.ScratchProperty = cbxScratchProperty.Text;
            detectScratchesTool.set_after();
        }

        private void cbxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            detectScratchesTool.SetdrawShape = cbxRoi.Text;
        }

        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            if (cbxRoi.Text == BlobTool.Roi.方向矩形.ToString())
                detectScratchesTool.SetdrawShape = BlobTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.矩形.ToString())
                detectScratchesTool.SetdrawShape = BlobTool.Roi.矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.圆.ToString())
                detectScratchesTool.SetdrawShape = BlobTool.Roi.圆.ToString();
        //    halconView1.ContextMenuStripHide();
         //   halconView1.Focus();
            detectScratchesTool.draw_roi();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = detectScratchesTool.set_after();
            //toolLabel1. ToolLable2.Text = "FAIL";
           // toolLabel1 statusStrip1.ToolLable2.ForeColor = Color.Red;
            if (this.detectScratchesTool.ResultLogic)
            {
               // statusStrip1.ToolLable2.Text = "PASS";
               // statusStrip1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
         //   statusStrip1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        } 

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.detectScratchesTool);
                this.Hide();
                frm = null;
                handleSetval(this.detectScratchesTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.detectScratchesTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void frm_DetectScratches_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormClosing += Frm_DetectScratches_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.detectScratchesTool.hWindowControl1 = hWindowControl1;
            string[] roi = new string[] { BlobTool.Roi.方向矩形.ToString(), BlobTool.Roi.矩形.ToString(), BlobTool.Roi.圆.ToString() };
            cbxRoi.Items.AddRange(roi);
            this.CenterToScreen();
        }

        private void Frm_DetectScratches_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void cebxIsScratchesXLD_CheckedChanged(object sender, EventArgs e)
        {
            detectScratchesTool.IsScratchesXLD = cebxIsScratchesXLD.Checked;
            detectScratchesTool.set_after();

        }

        private void cebxIsRectangle_CheckedChanged(object sender, EventArgs e)
        {
            detectScratchesTool.IsRectangle = cebxIsRectangle.Checked;
            detectScratchesTool.set_after();
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            detectScratchesTool.dispresult();
        }

        private void cbxSetdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
            detectScratchesTool.Setdraw = cbxSetdraw.Text;
            detectScratchesTool.set_after();
        }

        private void ceboxIsRoi_CheckedChanged(object sender, EventArgs e)
        {
            detectScratchesTool.IsRoi = ceboxIsRoi.Checked;
        }
    }
}
