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
    public partial class frm_SurfaceFlaw : Form
    {
        static frm_SurfaceFlaw frm;
        SurfaceFlawTool surfaceFlawTool = new SurfaceFlawTool();
        public delegate void HandledSetVal(SurfaceFlawTool surfaceFlawTool);
        HandledSetVal handleSetval;
        public frm_SurfaceFlaw()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_SurfaceFlaw SingleShow(SurfaceFlawTool surfaceFlawTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_SurfaceFlaw(surfaceFlawTool, handleSetval);
            }
            return frm;
        }

        public frm_SurfaceFlaw(SurfaceFlawTool surfaceFlawTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(surfaceFlawTool);
            this.surfaceFlawTool.Image = surfaceFlawTool.Image;
            this.surfaceFlawTool.Circle = surfaceFlawTool.Circle;
            this.surfaceFlawTool.Rectangle1 = surfaceFlawTool.Rectangle1;
            this.surfaceFlawTool.Rectangle2 = surfaceFlawTool.Rectangle2;
            this.SetVal(ref this.surfaceFlawTool);
        }

        void DisplayVal(SurfaceFlawTool surfaceFlawTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = surfaceFlawTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = surfaceFlawTool.Names.Substring(nameIndex + 1, surfaceFlawTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = surfaceFlawTool.Names;
                    tbxToolName.Text = surfaceFlawTool.Names;
                }
                cbxImage.Text = surfaceFlawTool.ImageName;//
                cbxRoi.Text = surfaceFlawTool.SetdrawShape;
                cbxFixture.Text = surfaceFlawTool.FixNames;
                cebxFixture.Checked = surfaceFlawTool.IsFixture;

                nudMaskHeight.Value = Convert.ToDecimal(surfaceFlawTool.MaskHeight.I);
                nudMaskWidth.Value = Convert.ToDecimal(surfaceFlawTool.MaskWidth.I);
                nudOffset.Value = Convert.ToDecimal(surfaceFlawTool.Offset.I);
                cbxLightDrak.Text = surfaceFlawTool.LightDrak;
                nudMinShapeFlaw.Value = Convert.ToDecimal(surfaceFlawTool.Select_shapeMin.I);
                nudMaxShapeFlaw.Value = Convert.ToDecimal(surfaceFlawTool.Select_shapeMax.I);
            
                cebxIsSurfaceFlaw.Checked = surfaceFlawTool.IsFlaw;
                cbxRoi.Text = surfaceFlawTool.SetdrawShape;

                cbxSetdraw.Text = surfaceFlawTool.Setdraw;
                ceboxIsRoi.Checked = surfaceFlawTool.IsRoi;
                cbxImage.Items.Clear();
                if (surfaceFlawTool.Image != null)
                {
                    foreach (var item in surfaceFlawTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
              //  halconView1.DispImage((HObject)surfaceFlawTool.Image[cbxImage.Text], true);
              //  halconView1.FitImage();
            }
            catch (Exception ex)
            {
                cbxImage.Items.Clear();
                if (surfaceFlawTool.Image != null)
                {
                    foreach (var item in surfaceFlawTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
               // halconView1.DispImage((HObject)surfaceFlawTool.Image[cbxImage.Text], true);
              //  halconView1.FitImage();
            }
            Register();//注册事件
        }

        void Cancel()
        {

            cbxLightDrak.SelectedIndexChanged -= new EventHandler(cbxLightDrak_SelectedIndexChanged);
            nudMaskHeight.ValueChanged -= new EventHandler(nudMaskHeight_ValueChanged);
            nudMaskWidth.ValueChanged -= new EventHandler(nudMaskWidth_ValueChanged);
            nudOffset.ValueChanged -= new EventHandler(nudOffset_ValueChanged);
            nudMinShapeFlaw.ValueChanged -= new EventHandler(nudMinShapeFlaw_ValueChanged);
            nudMaxShapeFlaw.ValueChanged -= new EventHandler(nudMaxShapeFlaw_ValueChanged);


            cebxIsSurfaceFlaw.CheckedChanged -= new EventHandler(cebxIsSurfaceFlaw_CheckedChanged);
            ceboxIsRoi.CheckedChanged -= new EventHandler(ceboxIsRoi_CheckedChanged);
            cebxIsRectangle.CheckedChanged -= new EventHandler(cebxIsRectangle_CheckedChanged);
            cbxSetdraw.TextChanged -= new EventHandler(cbxSetdraw_SelectedIndexChanged);


        }
        void Register()
        {
            cbxLightDrak.SelectedIndexChanged += new EventHandler(cbxLightDrak_SelectedIndexChanged);
            nudMaskHeight.ValueChanged += new EventHandler(nudMaskHeight_ValueChanged);
            nudMaskWidth.ValueChanged += new EventHandler(nudMaskWidth_ValueChanged);
            nudOffset.ValueChanged += new EventHandler(nudOffset_ValueChanged);
            nudMinShapeFlaw.ValueChanged += new EventHandler(nudMinShapeFlaw_ValueChanged);
            nudMaxShapeFlaw.ValueChanged += new EventHandler(nudMaxShapeFlaw_ValueChanged);
           
            cebxIsSurfaceFlaw.CheckedChanged += new EventHandler(cebxIsSurfaceFlaw_CheckedChanged);
            ceboxIsRoi.CheckedChanged += new EventHandler(ceboxIsRoi_CheckedChanged);
            cebxIsRectangle.CheckedChanged += new EventHandler(cebxIsRectangle_CheckedChanged);
            cbxSetdraw.TextChanged += new EventHandler(cbxSetdraw_SelectedIndexChanged);

        }

        void SetVal(ref SurfaceFlawTool surfaceFlawTool)
        {
            surfaceFlawTool.ImageName = cbxImage.Text;
            surfaceFlawTool.Names = ImageTool.Tool.瑕疵提取检测.ToString() + "_" + tbxToolName.Text;
            surfaceFlawTool.FixNames = cbxFixture.Text;
            surfaceFlawTool.IsFixture = cebxFixture.Checked;


            surfaceFlawTool.MaskHeight = (int)nudMaskHeight.Value;
            surfaceFlawTool.MaskWidth = (int)nudMaskWidth.Value;
            surfaceFlawTool.Offset = (int)nudOffset.Value;
            surfaceFlawTool.LightDrak = cbxLightDrak.Text;
            surfaceFlawTool.Select_shapeMin = (int)nudMinShapeFlaw.Value;
            surfaceFlawTool.Select_shapeMax = (int)nudMaxShapeFlaw.Value;
     
            surfaceFlawTool.IsFlaw = cebxIsSurfaceFlaw.Checked;
            surfaceFlawTool.SetdrawShape = cbxRoi.Text;

            surfaceFlawTool.Setdraw = cbxSetdraw.Text;
            surfaceFlawTool.IsRoi = ceboxIsRoi.Checked;
            surfaceFlawTool.IsRectangle = cebxIsRectangle.Checked;
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            surfaceFlawTool.ImageName = cbxImage.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   halconView1.DispImage((HObject)this.surfaceFlawTool.Image[cbxImage.Text], true);
       //     halconView1.FitImage();
            surfaceFlawTool.ImageName = cbxImage.Text;
        }

        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nudMaskWidth_ValueChanged(object sender, EventArgs e)
        {
            surfaceFlawTool.MaskWidth = (int)nudMaskWidth.Value;
            surfaceFlawTool.set_after();
        }

        private void nudOffset_ValueChanged(object sender, EventArgs e)
        {
            surfaceFlawTool.Offset = (int)nudOffset.Value;
            surfaceFlawTool.set_after();
        }

        private void nudMaskHeight_ValueChanged(object sender, EventArgs e)
        {
            surfaceFlawTool.MaskHeight = (int)nudMaskHeight.Value;
            surfaceFlawTool.set_after();
        }

        private void cbxLightDrak_SelectedIndexChanged(object sender, EventArgs e)
        {
            surfaceFlawTool.LightDrak = cbxLightDrak.Text;
            surfaceFlawTool.set_after();
        }

        private void ceboxIsRoi_CheckedChanged(object sender, EventArgs e)
        {
            surfaceFlawTool.IsRoi = ceboxIsRoi.Checked;
            surfaceFlawTool.set_after();
        }

        private void cebxIsSurfaceFlaw_CheckedChanged(object sender, EventArgs e)
        {
            surfaceFlawTool.IsFlaw = cebxIsSurfaceFlaw.Checked;
            surfaceFlawTool.set_after();
        }

        private void cebxIsRectangle_CheckedChanged(object sender, EventArgs e)
        {
            surfaceFlawTool.IsRectangle = cebxIsRectangle.Checked;
            surfaceFlawTool.set_after();
        }

        private void cbxSetdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
            surfaceFlawTool.Setdraw = cbxSetdraw.Text;
            surfaceFlawTool.set_after();
        }
        private void frm_SurfaceFlaw_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormClosing += frm_SurfaceFlaw_FormClosing;
          //  halconView1.HMouseWheelEvent += halconView1_HMouseWheelEvent;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.surfaceFlawTool.hWindowControl1 = hWindowControl1;
            string[] roi = new string[] { BlobTool.Roi.方向矩形.ToString(), BlobTool.Roi.矩形.ToString(), BlobTool.Roi.圆.ToString() };
            cbxRoi.Items.AddRange(roi);
            this.CenterToScreen();
        }

        void halconView1_HMouseWheelEvent(object sender)
        {
            surfaceFlawTool.dispresult();
        }

        void frm_SurfaceFlaw_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = surfaceFlawTool.set_after();
           // halconView1.ToolLable2.Text = "FAIL";
           // halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.surfaceFlawTool.ResultLogic)
            {
               // halconView1.ToolLable2.Text = "PASS";
               // halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
           // halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.surfaceFlawTool);
                this.Hide();
                frm = null;
                handleSetval(this.surfaceFlawTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.surfaceFlawTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            if (cbxRoi.Text == BlobTool.Roi.方向矩形.ToString())
                surfaceFlawTool.SetdrawShape = BlobTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.矩形.ToString())
                surfaceFlawTool.SetdrawShape = BlobTool.Roi.矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.圆.ToString())
                surfaceFlawTool.SetdrawShape = BlobTool.Roi.圆.ToString();
           // halconView1.ContextMenuStripHide();
           // halconView1.Focus();
            surfaceFlawTool.draw_roi();
        }

        private void nudMinShapeFlaw_ValueChanged(object sender, EventArgs e)
        {
            surfaceFlawTool.Select_shapeMin = (int)nudMinShapeFlaw.Value;
            surfaceFlawTool.set_after();
        }

        private void nudMaxShapeFlaw_ValueChanged(object sender, EventArgs e)
        {
            surfaceFlawTool.Select_shapeMax = (int)nudMaxShapeFlaw.Value;
            surfaceFlawTool.set_after();
        }

    }
}
