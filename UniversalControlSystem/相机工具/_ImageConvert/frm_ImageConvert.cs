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
using UniversalControlSystem;


namespace UniversalControlSystem
{
    public partial class frm_ImageConvert : Form
    {
        static frm_ImageConvert frm;
        ImageConvertTool imageConvertTool = new ImageConvertTool();
        public delegate void HandledSetVal(ImageConvertTool imageConvertTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_ImageConvert SingleShow(ImageConvertTool  imageConvertTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_ImageConvert(imageConvertTool, handleSetval);
            }
            return frm;
        }
        public frm_ImageConvert(ImageConvertTool imageConvertTool , HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(imageConvertTool);
            this.imageConvertTool.Image = imageConvertTool.Image;
            this.SetVal(ref this.imageConvertTool);
        }
        public frm_ImageConvert()
        {
            InitializeComponent();
        }
        void DisplayVal(ImageConvertTool imageConvertTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = imageConvertTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = imageConvertTool.Names.Substring(nameIndex + 1, imageConvertTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = imageConvertTool.Names;
                    tbxToolName.Text = imageConvertTool.Names;
                }
                cbxImage.Text = imageConvertTool.ImageName;//
                cbxTransImage.Text = imageConvertTool.TransImage;
                cbxColorSpace.Text = imageConvertTool.ColorSpace;
                cbxImage.Items.Clear();
                if (imageConvertTool.Image != null)
                {
                    foreach (var item in imageConvertTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
              //  halconView1.DispImage((HObject)imageConvertTool.Image[cbxImage.Text], true);
               // halconView1.FitImage();
            }
            catch
            {
                cbxImage.Items.Clear();
                if (imageConvertTool.Image != null)
                {
                    foreach (var item in imageConvertTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
            }
            Register();//注册事件
        }
        void Cancel()
        {
            cbxTransImage.SelectedIndexChanged -= new EventHandler(cbxTransImage_SelectedIndexChanged);
            cbxColorSpace.SelectedIndexChanged -= new EventHandler(cbxColorSpace_SelectedIndexChanged);
        }
        void Register()
        {
            cbxTransImage.SelectedIndexChanged += new EventHandler(cbxTransImage_SelectedIndexChanged);
            cbxColorSpace.SelectedIndexChanged += new EventHandler(cbxColorSpace_SelectedIndexChanged);
        }
        void SetVal(ref ImageConvertTool imageConvertTool)
        {
            imageConvertTool.Names = ImageTool.Tool.彩色转HSV图像.ToString() + "_" + tbxToolName.Text;
            imageConvertTool.ImageName = cbxImage.Text;
            imageConvertTool.ColorSpace = cbxColorSpace.Text;
            imageConvertTool.TransImage = cbxTransImage.Text;
        }
        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            imageConvertTool.Names = ImageTool.Tool.彩色转HSV图像.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }
        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  halconView1.DispImage((HObject)this.imageConvertTool.Image[cbxImage.Text], true);
           // halconView1.FitImage();
            imageConvertTool.ImageName = cbxImage.Text;
        }

        private void cbxTransImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageConvertTool.TransImage = cbxTransImage.Text;
            this.imageConvertTool.set_after();
        }
        private void cbxColorSpace_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageConvertTool.ColorSpace = cbxColorSpace.Text;
            this.imageConvertTool.set_after();
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
           // halconView1.DispImage((HObject)this.imageConvertTool.Image[cbxImage.Text], true);
           // halconView1.FitImage();
            long timer = this.imageConvertTool.set_after();
          //  halconView1.ToolLable2.Text = "FAIL";
          //  halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.imageConvertTool.ResultLogic)
            {
           //     halconView1.ToolLable2.Text = "PASS";
              //  halconView1.ToolLable2.ForeColor = Color.Lime;
            }
          //lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
          //  halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }
        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.imageConvertTool);
                this.Hide();
                frm = null;
                handleSetval(this.imageConvertTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.imageConvertTool);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void frm_TransImage_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.FormClosing += frm_TransImage_FormClosing;
            this.imageConvertTool.hWindowControl1 = hWindowControl1;
        }

        void frm_TransImage_FormClosing(object sender, FormClosingEventArgs e)
        {
             frm = null;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
