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
    public partial class frm_InvertImage : Form
    {
        static frm_InvertImage frm;
        InvertImageTool invertImageTool = new InvertImageTool();
        public delegate void HandledSetVal(InvertImageTool invertImageTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_InvertImage SingleShow(InvertImageTool invertImageTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_InvertImage(invertImageTool, handleSetval);
            }
            return frm;
        }
        public frm_InvertImage(InvertImageTool invertImageTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(invertImageTool);
            this.invertImageTool.Image = invertImageTool.Image;
            this.SetVal(ref this.invertImageTool);
        }

        public frm_InvertImage()
        {
            InitializeComponent();
        }

        void DisplayVal(InvertImageTool invertImageTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = invertImageTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = invertImageTool.Names.Substring(nameIndex + 1, invertImageTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = invertImageTool.Names;
                    tbxToolName.Text = invertImageTool.Names;
                }
                cbxImage.Text = invertImageTool.ImageName;//
              
                cbxImage.Items.Clear();
                if (invertImageTool.Image != null)
                {
                    foreach (var item in invertImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
               // halconView1.DispImage((HObject)invertImageTool.Image[cbxImage.Text], true);
               // halconView1.FitImage();
            }
            catch
            {
                cbxImage.Items.Clear();
                if (invertImageTool.Image != null)
                {
                    foreach (var item in invertImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
            }
            Register();//注册事件
        }

         void Cancel()
         {
           
         }
        void Register()
        {
         
        }
        void SetVal(ref InvertImageTool invertImageTool)
        {
            invertImageTool.Names = ImageTool.Tool.取反图像.ToString() + "_" + tbxToolName.Text;
            invertImageTool.ImageName = cbxImage.Text;
           
          
        }

        private void frm_Smooth_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.FormClosing += frm_Smooth_FormClosing;
            this.invertImageTool.hWindowControl1 = hWindowControl1;
        }

        void frm_Smooth_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

         private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.invertImageTool.Names = ImageTool.Tool.取反图像.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   halconView1.DispImage((HObject)this.invertImageTool.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
            invertImageTool.ImageName = cbxImage.Text;
       
        }
         private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void nudAlpha_ValueChanged(object sender, EventArgs e)
        {
      
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = this.invertImageTool.set_after();
          //  halconView1.ToolLable2.Text = "FAIL";
           // halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.invertImageTool.ResultLogic)
            {
             //   halconView1.ToolLable2.Text = "PASS";
            //    halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
          //  halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.invertImageTool);
                this.Hide();
                frm = null;
                handleSetval(this.invertImageTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.invertImageTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }
        private void halconView1_HMouseWheelEvent(object sender)
        {
            invertImageTool.dispresult();
        }
    }
}
