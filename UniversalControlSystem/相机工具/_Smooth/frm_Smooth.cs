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
    public partial class frm_Smooth : Form
    {
        static frm_Smooth frm;
        SmoothImageTool smoothImageTool = new SmoothImageTool();
        public delegate void HandledSetVal(SmoothImageTool smoothImageTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_Smooth SingleShow(SmoothImageTool smoothImageTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_Smooth(smoothImageTool, handleSetval);
            }
            return frm;
        }
        public frm_Smooth(SmoothImageTool smoothImageTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(smoothImageTool);
            this.smoothImageTool.Image = smoothImageTool.Image;
            this.SetVal(ref this.smoothImageTool);
        }

        public frm_Smooth()
        {
            InitializeComponent();
        }

        void DisplayVal(SmoothImageTool smoothImageTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = smoothImageTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = smoothImageTool.Names.Substring(nameIndex + 1, smoothImageTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = smoothImageTool.Names;
                    tbxToolName.Text = smoothImageTool.Names;
                }
                cbxImage.Text = smoothImageTool.ImageName;//
                cbxFilter.Text = smoothImageTool.Filter;
                nudAlpha.Value = Convert.ToDecimal(smoothImageTool.Alpha.D);
                cbxImage.Items.Clear();
                if (smoothImageTool.Image != null)
                {
                    foreach (var item in smoothImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
               // halconView1.DispImage((HObject)smoothImageTool.Image[cbxImage.Text], true);
                //halconView1.FitImage();
            }
            catch
            {
                cbxImage.Items.Clear();
                if (smoothImageTool.Image != null)
                {
                    foreach (var item in smoothImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
            }
            Register();//注册事件
        }

        void Cancel()
         {
             cbxFilter.SelectedIndexChanged -= new EventHandler(cbxFilter_SelectedIndexChanged);
             nudAlpha.ValueChanged -= new EventHandler(nudAlpha_ValueChanged);
         }
        void Register()
        {
            cbxFilter.SelectedIndexChanged += new EventHandler(cbxFilter_SelectedIndexChanged);
            nudAlpha.ValueChanged += new EventHandler(nudAlpha_ValueChanged);
        }
        void SetVal(ref SmoothImageTool smoothImageTool)
        {
            smoothImageTool.Names = ImageTool.Tool.平滑图像.ToString() + "_" + tbxToolName.Text;
            smoothImageTool.ImageName = cbxImage.Text;
            smoothImageTool.Alpha =(double)nudAlpha.Value;
            smoothImageTool.Filter = cbxFilter.Text;
          
        }

        private void frm_Smooth_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.FormClosing += frm_Smooth_FormClosing;
            this.smoothImageTool.hWindowControl1 = hWindowControl1;
        }

        void frm_Smooth_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

         private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.smoothImageTool.Names = ImageTool.Tool.平滑图像.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    halconView1.DispImage((HObject)this.smoothImageTool.Image[cbxImage.Text], true);
        //    halconView1.FitImage();
            smoothImageTool.ImageName = cbxImage.Text;
       
        }
         private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
           smoothImageTool.Filter = cbxFilter.Text;
           this.smoothImageTool.set_after();
        }

        private void nudAlpha_ValueChanged(object sender, EventArgs e)
        {
            smoothImageTool.Alpha = (double)nudAlpha.Value;
            this.smoothImageTool.set_after();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = this.smoothImageTool.set_after();
           // halconView1.ToolLable2.Text = "FAIL";
          //  halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.smoothImageTool.ResultLogic)
            {
             ///   halconView1.ToolLable2.Text = "PASS";
              //  halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            ///halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.smoothImageTool);
                this.Hide();
                frm = null;
                handleSetval(this.smoothImageTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.smoothImageTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

    }
}
