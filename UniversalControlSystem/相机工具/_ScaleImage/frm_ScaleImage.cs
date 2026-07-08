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
    public partial class frm_ScaleImage : Form
    {
        static frm_ScaleImage frm;
        ScaleImageTool scaleImageTool = new ScaleImageTool();
        public delegate void HandledSetVal(ScaleImageTool scaleImageTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_ScaleImage SingleShow(ScaleImageTool scaleImageTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_ScaleImage(scaleImageTool, handleSetval);
            }
            return frm;
        }


        public frm_ScaleImage()
        {
            InitializeComponent();
        }
        public frm_ScaleImage(ScaleImageTool scaleImageTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(scaleImageTool);
            this.scaleImageTool.Image = scaleImageTool.Image;
            this.SetVal(ref this.scaleImageTool);

        }

        void DisplayVal(ScaleImageTool scaleImageTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = scaleImageTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = scaleImageTool.Names.Substring(nameIndex + 1, scaleImageTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = scaleImageTool.Names;
                    tbxToolName.Text = scaleImageTool.Names;
                }
                cbxImage.Text = scaleImageTool.ImageName;//
                takBarLowThreshold.Value = scaleImageTool.LowThreshold;
                lbl_low.Text = "最小化:" + takBarLowThreshold.Value.ToString();
                takBarHigThreshold.Value = scaleImageTool.HigThreshold;
                lbl_higt.Text = "最大化:" + takBarHigThreshold.Value.ToString();
                cbxImage.Items.Clear();
                if (scaleImageTool.Image != null)
                {
                    foreach (var item in scaleImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
               // halconView1.DispImage((HObject)scaleImageTool.Image[cbxImage.Text], true);
                //halconView1.FitImage();
            }
            catch
            {
                cbxImage.Items.Clear();
                if (scaleImageTool.Image != null)
                {
                    foreach (var item in scaleImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
             }
            Register();//注册事件
        }

        void Cancel()
        {
            takBarLowThreshold.Scroll -= new EventHandler(takBarLowThreshold_Scroll);
            takBarHigThreshold.Scroll -= new EventHandler(takBarHigThreshold_Scroll);
        }
        void Register()
        {
            takBarLowThreshold.Scroll += new EventHandler(takBarLowThreshold_Scroll);
            takBarHigThreshold.Scroll += new EventHandler(takBarHigThreshold_Scroll);
        }
        void SetVal(ref ScaleImageTool scaleImageTool)
        {
            scaleImageTool.Names = ImageTool.Tool.性线收缩图像.ToString() + "_" + tbxToolName.Text;
            scaleImageTool.ImageName = cbxImage.Text;
            scaleImageTool.LowThreshold = takBarLowThreshold.Value;
            scaleImageTool.HigThreshold = takBarHigThreshold.Value;
        }
        private void frm_ScaleImage_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.FormClosing += frm_ScaleImage_FormClosing;
            this.scaleImageTool.hWindowControl1 = hWindowControl1;
        }

        void frm_ScaleImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.scaleImageTool.Names = ImageTool.Tool.性线收缩图像.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
           //// halconView1.DispImage((HObject)this.scaleImageTool.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
            scaleImageTool.ImageName = cbxImage.Text;
        }

        private void takBarLowThreshold_Scroll(object sender, EventArgs e)
        {
            try
            {
                lbl_low.Text = "最小化:" + takBarLowThreshold.Value.ToString();
                lbl_low.Refresh();
                scaleImageTool.LowThreshold = takBarLowThreshold.Value;
                if (takBarLowThreshold.Value < takBarHigThreshold.Value)
                    scaleImageTool.set_after();
                else
                {
                    takBarHigThreshold.Value = takBarLowThreshold.Value;
                    lbl_higt.Text = "最大化:" + takBarHigThreshold.Value.ToString();
                }
              }
            catch { }
        }
        private void takBarHigThreshold_Scroll(object sender, EventArgs e)
        {
            try
            {
                lbl_higt.Text = "最大化:" + takBarHigThreshold.Value.ToString();
                lbl_higt.Refresh();
                scaleImageTool.HigThreshold = takBarHigThreshold.Value;
                if (takBarHigThreshold.Value > takBarLowThreshold.Value)
                    scaleImageTool.set_after();
                else
                {
                    takBarLowThreshold.Value = takBarHigThreshold.Value;
                    lbl_low.Text = "最小化:" + takBarLowThreshold.Value.ToString();
                }
            }
            catch { }

        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.scaleImageTool);
                this.Hide();
                frm = null;
                handleSetval(this.scaleImageTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.scaleImageTool);
            }
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = scaleImageTool.set_after();
          //  halconView1.ToolLable2.Text = "FAIL";
            //halconView1.ToolLable2.ForeColor = Color.Red;
            if (scaleImageTool.ResultLogic)
            {
               // halconView1.ToolLable2.Text = "PASS";
               // halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            //halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }


    }
}
