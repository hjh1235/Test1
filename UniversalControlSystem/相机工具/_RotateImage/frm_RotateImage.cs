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
    public partial class frm_RotateImage : Form
    {
        static frm_RotateImage frm;
        RotateImageTool rotateImageTool = new RotateImageTool();
        public delegate void HandledSetVal(RotateImageTool rotateImageTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_RotateImage SingleShow(RotateImageTool rotateImageTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_RotateImage(rotateImageTool, handleSetval);
            }
            return frm;
        }
        public frm_RotateImage(RotateImageTool rotateImageTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(rotateImageTool);
            this.rotateImageTool.Image = rotateImageTool.Image;
            this.SetVal(ref this.rotateImageTool);
        }

        public frm_RotateImage()
        {
            InitializeComponent();
        }

        void DisplayVal(RotateImageTool RotateImageTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = RotateImageTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = RotateImageTool.Names.Substring(nameIndex + 1, RotateImageTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = RotateImageTool.Names;
                    tbxToolName.Text = RotateImageTool.Names;
                }
                cbxImage.Text = RotateImageTool.ImageName;//
                nudRotateAngle.Value = Convert.ToDecimal(RotateImageTool.RotateAngle.I);//旋转角度
                cbxImage.Items.Clear();
                if (RotateImageTool.Image != null)
                {
                    foreach (var item in RotateImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
              //  halconView1.DispImage((HObject)RotateImageTool.Image[cbxImage.Text], true);
               // halconView1.FitImage();
            }
            catch
            {
                cbxImage.Items.Clear();
                if (RotateImageTool.Image != null)
                {
                    foreach (var item in RotateImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
            }
            Register();//注册事件
        }

        void Cancel()
         {
            nudRotateAngle.ValueChanged -= new EventHandler(nudRotateAngle_ValueChanged);
          }
        void Register()
        {
            nudRotateAngle.ValueChanged += new EventHandler(nudRotateAngle_ValueChanged);
        }
        void SetVal(ref RotateImageTool rotateImageTool)
        {
            rotateImageTool.Names = ImageTool.Tool.旋转图像.ToString() + "_" + tbxToolName.Text;
            rotateImageTool.ImageName = cbxImage.Text;
            rotateImageTool.RotateAngle = (int)nudRotateAngle.Value;
        }
        private void frm_RotateImage_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.FormClosing += frm_RotateImage_FormClosing;
            this.rotateImageTool.hWindowControl1 = hWindowControl1;
        }
        void frm_RotateImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
         private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.rotateImageTool.Names = ImageTool.Tool.旋转图像.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }
        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
           // h//alconView1.DispImage((HObject)this.rotateImageTool.Image[cbxImage.Text], true);
           /// halconView1.FitImage();
            rotateImageTool.ImageName = cbxImage.Text;
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = this.rotateImageTool.set_after();
          //  halconView1.ToolLable2.Text = "FAIL";
           // halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.rotateImageTool.ResultLogic)
            {
             //   halconView1.ToolLable2.Text = "PASS";
             //   halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
           // halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.rotateImageTool);
                this.Hide();
                frm = null;
                handleSetval(this.rotateImageTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.rotateImageTool);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }
        private void nudRotateAngle_ValueChanged(object sender, EventArgs e)
        {
            rotateImageTool.RotateAngle = (int)nudRotateAngle.Value;
        }
    }
}
