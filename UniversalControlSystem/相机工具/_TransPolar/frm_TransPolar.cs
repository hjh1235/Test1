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
    public partial class frm_TransPolar : Form
    {
        static frm_TransPolar frm;
        TransPolarTool transPolarTool = new TransPolarTool();
        public delegate void HandledSetVal(TransPolarTool transPolarTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_TransPolar SingleShow(TransPolarTool transPolarTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_TransPolar(transPolarTool, handleSetval);
            }
            return frm;
        }

        public frm_TransPolar()
        {
            InitializeComponent();
        }
        public frm_TransPolar(TransPolarTool transPolarTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(transPolarTool);
            this.transPolarTool.Image = transPolarTool.Image;
            this.transPolarTool.Circle = transPolarTool.Circle;
            this.transPolarTool.Rectangle1 = transPolarTool.Rectangle1;
            this.transPolarTool.Rectangle2 = transPolarTool.Rectangle2;
            this.transPolarTool.Row = transPolarTool.Circle[0];
            this.transPolarTool.Column = transPolarTool.Circle[1];
            this.SetVal(ref this.transPolarTool);
        }

        void DisplayVal(TransPolarTool transPolarTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = transPolarTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = transPolarTool.Names.Substring(nameIndex + 1, transPolarTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = transPolarTool.Names;
                    tbxToolName.Text = transPolarTool.Names;
                }
                cbxImage.Text = transPolarTool.ImageName;//
                cbxRoi.Text = transPolarTool.SetdrawShape;
         
                nudAngleEnd.Value = Convert.ToDecimal(transPolarTool.AngleEnd.D);
                nudAngleStart.Value = Convert.ToDecimal(transPolarTool.AngleStart.D);

                nudInnerRadius.Value = Convert.ToDecimal(transPolarTool.InnerRadius.D);
                nudOutRadius.Value = Convert.ToDecimal(transPolarTool.OuterRadius.D);
                cbxRoi.Text = transPolarTool.SetdrawShape;
                cbxImage.Items.Clear();
                if (transPolarTool.Image != null)
                {
                    foreach (var item in transPolarTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                    //halconView1.DispImage((HObject)transPolarTool.Image[cbxImage.Text], true);
                   // halconView1.FitImage();
                }
             }
            catch (Exception ex)
            {
                cbxImage.Items.Clear();
                if (transPolarTool.Image != null)
                {
                    foreach (var item in transPolarTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                   // halconView1.DispImage((HObject)transPolarTool.Image[cbxImage.Text], true);
                   // halconView1.FitImage();
                }
            
            }
            Register();//注册事件
        }

        void Cancel()
        {
            nudAngleEnd.ValueChanged -= new EventHandler(nudAngleEnd_ValueChanged);
            nudAngleStart.ValueChanged -= new EventHandler(nudAngleStart_ValueChanged);
            nudInnerRadius.ValueChanged -= new EventHandler(nudInnerRadius_ValueChanged);
            nudOutRadius.ValueChanged -= new EventHandler(nudOutRadius_ValueChanged);
        }
        void Register()
        {
            nudAngleEnd.ValueChanged += new EventHandler(nudAngleEnd_ValueChanged);
            nudAngleStart.ValueChanged += new EventHandler(nudAngleStart_ValueChanged);
           
            nudInnerRadius.ValueChanged += new EventHandler(nudInnerRadius_ValueChanged);
            nudOutRadius.ValueChanged += new EventHandler(nudOutRadius_ValueChanged);
         

        }

        void SetVal(ref TransPolarTool transPolarTool)
        {
            transPolarTool.ImageName = cbxImage.Text;
            transPolarTool.Names = ImageTool.Tool.极坐标变换图像.ToString() + "_" + tbxToolName.Text;
         
            transPolarTool.AngleEnd = (double)nudAngleEnd.Value;
            transPolarTool.AngleStart = (double)nudAngleStart.Value;
            transPolarTool.InnerRadius = (double)nudInnerRadius.Value;
            transPolarTool.OuterRadius = (double)nudOutRadius.Value;
            transPolarTool.SetdrawShape = cbxRoi.Text;

        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            transPolarTool.ImageName = cbxImage.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
          ///  halconView1.DispImage((HObject)this.transPolarTool.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
            transPolarTool.ImageName = cbxImage.Text;
        }

        private void nudAngleStart_ValueChanged(object sender, EventArgs e)
        {
            transPolarTool.AngleStart = (int)nudAngleStart.Value;
            transPolarTool.set_after();
        }
        private void nudAngleEnd_ValueChanged(object sender, EventArgs e)
        {
            transPolarTool.AngleEnd = (int)nudAngleEnd.Value;
            transPolarTool.set_after();
        }

        private void nudInnerRadius_ValueChanged(object sender, EventArgs e)
        {
            transPolarTool.InnerRadius = (int)nudInnerRadius.Value;
            transPolarTool.set_after();
         }
        private void nudOutRadius_ValueChanged(object sender, EventArgs e)
        {
            transPolarTool.OuterRadius = (int)nudOutRadius.Value;
            transPolarTool.set_after();
        }

        private void cbxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            transPolarTool.SetdrawShape = cbxRoi.Text;
     
        }

        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            if (cbxRoi.Text == ImageTool.Roi.方向矩形.ToString())
                transPolarTool.SetdrawShape = ImageTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == ImageTool.Roi.矩形.ToString())
                transPolarTool.SetdrawShape = ImageTool.Roi.矩形.ToString();
            if (cbxRoi.Text == ImageTool.Roi.圆.ToString())
                transPolarTool.SetdrawShape = ImageTool.Roi.圆.ToString();
      //      halconView1.ContextMenuStripHide();
      //      halconView1.Focus();
            transPolarTool.draw_roi();
            Cancel();//注销事件
            nudInnerRadius.Value = Convert.ToDecimal(transPolarTool.InnerRadius.D);
            nudOutRadius.Value = Convert.ToDecimal(transPolarTool.OuterRadius.D);
            Register();
        }
        private void cbxSetdraw_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            transPolarTool.set_after();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = transPolarTool.set_after();
       ////     halconView1.ToolLable2.Text = "FAIL";
          //  halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.transPolarTool.ResultLogic)
            {//
                //halconView1.ToolLable2.Text = "PASS";
                //halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        //    halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.transPolarTool);
                this.Hide();
                frm = null;
                handleSetval(this.transPolarTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.transPolarTool);
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
            this.transPolarTool.hWindowControl1 = hWindowControl1;
            string[] roi = new string[] { ImageTool.Roi.圆.ToString() };
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
            transPolarTool.dispresult();
        }
    }
}
