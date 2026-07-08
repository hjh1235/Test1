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
    public partial class frm_ColorExtrator : Form
    {
        static frm_ColorExtrator fb;


        ColorExtractorTool colorExtractorTool = new ColorExtractorTool();
        public delegate void HandledSetVal(ColorExtractorTool colorExtractorTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_ColorExtrator SingleShow(ColorExtractorTool colorExtractorTool, HandledSetVal handleSetval)
        {
            if (fb == null)//
            {
                fb = new frm_ColorExtrator(colorExtractorTool, handleSetval);
            }
            return fb;
        }

        public frm_ColorExtrator()
        {
            InitializeComponent();
        }
        public frm_ColorExtrator(ColorExtractorTool colorExtractorTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(colorExtractorTool);
            this.colorExtractorTool.Image = colorExtractorTool.Image;
            this.colorExtractorTool.Circle = colorExtractorTool.Circle;
            this.colorExtractorTool.Rectangle1 = colorExtractorTool.Rectangle1;
            this.colorExtractorTool.Rectangle2 = colorExtractorTool.Rectangle2;
            this.colorExtractorTool.HueRangesMins = colorExtractorTool.HueRangesMins;
            this.colorExtractorTool.HueRangesMaxs = colorExtractorTool.HueRangesMaxs;
            this.colorExtractorTool.DicHomMat2D = colorExtractorTool.DicHomMat2D;
            this.colorExtractorTool.DicPhi = colorExtractorTool.DicPhi;
            this.SetVal(ref this.colorExtractorTool);

        }
        void DisplayVal(ColorExtractorTool colorExtractorTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = colorExtractorTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = colorExtractorTool.Names.Substring(nameIndex + 1, colorExtractorTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = colorExtractorTool.Names;
                    tbxToolName.Text = colorExtractorTool.Names;
                }
                cbxImage.Text = colorExtractorTool.ImageName;//
                cbxFixture.Text = colorExtractorTool.FixNames;
                cebxFixture.Checked = colorExtractorTool.IsFixture;//定位

                cbxColorType.Text = colorExtractorTool.ColorType;
                nudHueRangesMin.Value = Convert.ToDecimal(colorExtractorTool.HueRangesMin.I);
                nudHueRangesMax.Value = Convert.ToDecimal(colorExtractorTool.HueRangesMax.I);
                tbxAreaMin.Text = Convert.ToString(colorExtractorTool.AreaMin.I);
                tbxAreaMax.Text = Convert.ToString(colorExtractorTool.AreaMax.I);
                cebxIsColorType.Checked = colorExtractorTool.IsColorType;
                cbxRoi.Text = colorExtractorTool.SetdrawShape;

                nudLowNum.Value = Convert.ToDecimal(colorExtractorTool.LowNums.I);
                nudHigNum.Value = Convert.ToDecimal(colorExtractorTool.HigNums.I);
                cebxNums.Checked = colorExtractorTool.IsNums;
                ceboxIsRoi.Checked = colorExtractorTool.IsRoi;

                cbxImage.Items.Clear();
                if (colorExtractorTool.Image != null)
                {
                    foreach (var item in colorExtractorTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
               // halconView1.DispImage((HObject)colorExtractorTool.Image[cbxImage.Text], true);
              //  halconView1.FitImage();
                cbxFixture.Items.Clear();
                if (colorExtractorTool.DicHomMat2D != null)
                {
                    foreach (var item in colorExtractorTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();//注册事件

            }
            catch
            {
                cbxImage.Items.Clear();
                if (colorExtractorTool.Image != null)
                {
                    foreach (var item in colorExtractorTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (colorExtractorTool.DicHomMat2D != null)
                {
                    foreach (var item in colorExtractorTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();//注册事件
            }
            Register();//注册事件
        }
        void Cancel()
        {
            nudHueRangesMin.ValueChanged -= new EventHandler(nudHueRangesMin_ValueChanged);
            nudHueRangesMax.ValueChanged -= new EventHandler(nudHueRangesMax_ValueChanged);
            cbxColorType.SelectedIndexChanged -= new EventHandler(cbxColorType_SelectedIndexChanged);
            cebxIsColorType.CheckedChanged -= new EventHandler(cebxIsColorType_CheckedChanged);
            ceboxIsRoi.CheckedChanged -= new EventHandler(ceboxIsRoi_CheckedChanged);

        }
        void Register()
        {
            nudHueRangesMin.ValueChanged += new EventHandler(nudHueRangesMin_ValueChanged);
            nudHueRangesMax.ValueChanged += new EventHandler(nudHueRangesMax_ValueChanged);
            cbxColorType.SelectedIndexChanged += new EventHandler(cbxColorType_SelectedIndexChanged);
            cebxIsColorType.CheckedChanged += new EventHandler(cebxIsColorType_CheckedChanged);
            ceboxIsRoi.CheckedChanged += new EventHandler(ceboxIsRoi_CheckedChanged);
        }
        void SetVal(ref ColorExtractorTool colorExtractorTool)
        {
            colorExtractorTool.Names = ImageTool.Tool.颜色抽取检测.ToString() + "_" + cbxColorType.Text;
            colorExtractorTool.ImageName = cbxImage.Text;
            colorExtractorTool.IsFixture = cebxFixture.Checked;
            colorExtractorTool.FixNames = cbxFixture.Text;
            colorExtractorTool.HueRangesMin = (int)nudHueRangesMin.Value;
            colorExtractorTool.HueRangesMax = (int)nudHueRangesMax.Value;

            colorExtractorTool.AreaMin = Convert.ToInt32(tbxAreaMin.Text);
            colorExtractorTool.AreaMax = Convert.ToInt32(tbxAreaMax.Text);
            colorExtractorTool.ColorType = cbxColorType.Text;
            colorExtractorTool.IsColorType = cebxIsColorType.Checked;
            colorExtractorTool.SetdrawShape = cbxRoi.Text;

            colorExtractorTool.LowNums = (int)nudLowNum.Value;
            colorExtractorTool.HigNums = (int)nudHigNum.Value;
            colorExtractorTool.IsNums = cebxNums.Checked;
            colorExtractorTool.IsRoi = ceboxIsRoi.Checked;
        }
        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            colorExtractorTool.Names = ImageTool.Tool.颜色抽取检测.ToString() + "_" + tbxToolName.Text + "_" + cbxColorType.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  halconView1.DispImage(this.colorExtractorTool.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
            this.colorExtractorTool.ImageName = cbxImage.Text;
        }

        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            colorExtractorTool.IsFixture = cebxFixture.Checked;
        }
        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.colorExtractorTool.FixNames = cbxFixture.Text;
        }

        private void nudHueRangesMin_ValueChanged(object sender, EventArgs e)
        {
            this.colorExtractorTool.HueRangesMin = (int)nudHueRangesMin.Value;
            colorExtractorTool.set_after();
        }

        private void nudHueRangesMax_ValueChanged(object sender, EventArgs e)
        {
            this.colorExtractorTool.HueRangesMax = (int)nudHueRangesMax.Value;
            colorExtractorTool.set_after();
        }

        private void tbxAreaMin_TextChanged(object sender, EventArgs e)
        {
            this.colorExtractorTool.AreaMin = Convert.ToInt32(tbxAreaMin.Text);
        }

        private void tbxAreaMax_TextChanged(object sender, EventArgs e)
        {
            this.colorExtractorTool.AreaMax = Convert.ToInt32(tbxAreaMax.Text);
        }

        private void cbxColorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.colorExtractorTool.ColorType = cbxColorType.Text;
            colorExtractorTool.set_after();
        }

        private void cebxIsColorType_CheckedChanged(object sender, EventArgs e)
        {
            this.colorExtractorTool.IsColorType = cebxIsColorType.Checked;
            if (!this.colorExtractorTool.IsColorType)
            {
                this.colorExtractorTool.HueRangesMin = (int)nudHueRangesMin.Value;
                this.colorExtractorTool.HueRangesMax = (int)nudHueRangesMax.Value;
            }
            colorExtractorTool.set_after();
        }
        private void cbxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.colorExtractorTool.SetdrawShape = cbxRoi.Text;
        }

        private void nudLowNum_ValueChanged(object sender, EventArgs e)
        {
            colorExtractorTool.LowNums = (int)nudLowNum.Value;
        }

        private void nudHigNum_ValueChanged(object sender, EventArgs e)
        {
            colorExtractorTool.HigNums = (int)nudHigNum.Value;
        }

        private void cebxNums_CheckedChanged(object sender, EventArgs e)
        {
            colorExtractorTool.IsNums = cebxNums.Checked;
        }
        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            if (cbxRoi.Text == _2DSymbolTool.Roi.方向矩形.ToString())
                this.colorExtractorTool.SetdrawShape = BlobTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == _2DSymbolTool.Roi.矩形.ToString())
                this.colorExtractorTool.SetdrawShape = _2DSymbolTool.Roi.矩形.ToString();
            if (cbxRoi.Text == _2DSymbolTool.Roi.圆.ToString())
                this.colorExtractorTool.SetdrawShape = _2DSymbolTool.Roi.圆.ToString();
         //   halconView1.ContextMenuStripHide();
           // halconView1.Focus();
            this.colorExtractorTool.draw_roi();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            try
            {
                long timer = colorExtractorTool.set_after();
              //  halconView1.ToolLable2.Text = "FAIL";
              //  halconView1.ToolLable2.ForeColor = Color.Red;
                if (this.colorExtractorTool.ResultLogic)
                {
                ////    halconView1.ToolLable2.Text = "PASS";
                  //  halconView1.ToolLable2.ForeColor = Color.Lime;
                }
                lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
//halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            }
            catch
            {
                MessageBox.Show("结果输出异常,查看设定参数！");
            }
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.colorExtractorTool);
                this.Hide();
                fb = null;
                handleSetval(this.colorExtractorTool);
            }
            catch
            {
                this.Hide();
                fb = null;
                handleSetval(this.colorExtractorTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            fb = null;
        }

        private void frm_ColorExtrator_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormClosing += frm_ColorExtrator_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.colorExtractorTool.hWindowControl1 = hWindowControl1;
        }

        void frm_ColorExtrator_FormClosing(object sender, FormClosingEventArgs e)
        {
            fb = null;
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            colorExtractorTool.dispresult();
        }

        private void ceboxIsRoi_CheckedChanged(object sender, EventArgs e)
        {
            colorExtractorTool.IsRoi = ceboxIsRoi.Checked;
            colorExtractorTool.set_after();
        }
    }
}
