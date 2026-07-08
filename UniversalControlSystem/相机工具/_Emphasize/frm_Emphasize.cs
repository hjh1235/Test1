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
    public partial class frm_Emphasize : Form
    {

        static frm_Emphasize frm;
        EmphasizeImageTool emphasizeTool = new EmphasizeImageTool();
        public delegate void HandledSetVal(EmphasizeImageTool emphasizeTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_Emphasize SingleShow(EmphasizeImageTool emphasizeTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_Emphasize(emphasizeTool, handleSetval);
            }
            return frm;
        }
        public frm_Emphasize(EmphasizeImageTool emphasizeTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(emphasizeTool);
            this.emphasizeTool.Image = emphasizeTool.Image;
            this.SetVal(ref this.emphasizeTool);
        }

        public frm_Emphasize()
        {
            InitializeComponent();
        }

        void DisplayVal(EmphasizeImageTool emphasizeImageTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = emphasizeImageTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = emphasizeImageTool.Names.Substring(nameIndex + 1, emphasizeImageTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = emphasizeImageTool.Names;
                    tbxToolName.Text = emphasizeImageTool.Names;
                }
                cbxImage.Text = emphasizeImageTool.ImageName;//
                nudMaskHeight.Value = Convert.ToDecimal(emphasizeImageTool.MaskHeight.D);
                nudMaskWidth.Value= Convert.ToDecimal(emphasizeImageTool.MaskWidth.D);
                nudFactor.Value = Convert.ToDecimal(emphasizeImageTool.Factor.D);
                cbxImage.Items.Clear();
                if (emphasizeImageTool.Image != null)
                {
                    foreach (var item in emphasizeImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
               // halconView1.DispImage((HObject)emphasizeImageTool.Image[cbxImage.Text], true);
               // halconView1.FitImage();
            }
            catch
            {
                cbxImage.Items.Clear();
                if (emphasizeImageTool.Image != null)
                {
                    foreach (var item in emphasizeImageTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
            }
            Register();//注册事件
        }

        void Cancel()
         {
            nudMaskHeight.ValueChanged -= new EventHandler(nudMaskHeight_ValueChanged);
            nudMaskWidth.ValueChanged -= new EventHandler(nudMaskWidth_ValueChanged);
            nudFactor.ValueChanged -= new EventHandler(nudFactor_ValueChanged);
         }
        void Register()
        {
            nudMaskHeight.ValueChanged += new EventHandler(nudMaskHeight_ValueChanged);
            nudMaskWidth.ValueChanged += new EventHandler(nudMaskWidth_ValueChanged);
            nudFactor.ValueChanged += new EventHandler(nudFactor_ValueChanged);
        }
        void SetVal(ref EmphasizeImageTool emphasizeTool)
        {
            emphasizeTool.Names = ImageTool.Tool.增强图像.ToString() + "_" + tbxToolName.Text;
            emphasizeTool.ImageName = cbxImage.Text;
            emphasizeTool.MaskHeight = (double)nudMaskHeight.Value;
            emphasizeTool.MaskWidth = (double)nudMaskWidth.Value;
            emphasizeTool.Factor = (double)nudFactor.Value;
        }
      

        private void frm_Smooth_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.FormClosing += frm_Smooth_FormClosing;
            this.emphasizeTool.hWindowControl1 = hWindowControl1;
        }

        void frm_Smooth_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

         private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.emphasizeTool.Names = ImageTool.Tool.增强图像.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //halconView1.DispImage((HObject)this.emphasizeTool.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
            emphasizeTool.ImageName = cbxImage.Text;
       
        }
       

        private void nudFactor_ValueChanged(object sender, EventArgs e)
        {
            emphasizeTool.Factor = (double)nudFactor.Value;
            this.emphasizeTool.set_after();
        }

        private void nudMaskWidth_ValueChanged(object sender, EventArgs e)
        {
            emphasizeTool.MaskWidth = (double)nudMaskWidth.Value;
            this.emphasizeTool.set_after();
        }

        private void nudMaskHeight_ValueChanged(object sender, EventArgs e)
        {
            emphasizeTool.MaskHeight = (double)nudMaskWidth.Value;
            this.emphasizeTool.set_after();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = this.emphasizeTool.set_after();
           // halconView1.ToolLable2.Text = "FAIL";
           // halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.emphasizeTool.ResultLogic)
            {
              //  halconView1.ToolLable2.Text = "PASS";
              //  halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
           // halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.emphasizeTool);
                this.Hide();
                frm = null;
                handleSetval(this.emphasizeTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.emphasizeTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

     
    }
}
