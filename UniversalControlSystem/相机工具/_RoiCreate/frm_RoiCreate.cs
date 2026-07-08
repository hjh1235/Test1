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
    public partial class frm_RoiCreate : Form
    {

        static frm_RoiCreate frm;
        RoiCreateTool roiCreateTool = new RoiCreateTool();
        public delegate void HandledSetVal(RoiCreateTool roiCreateTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_RoiCreate SingleShow(RoiCreateTool roiCreateTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_RoiCreate(roiCreateTool, handleSetval);
            }
            return frm;
        }
        public frm_RoiCreate()
        {
            InitializeComponent();
        }
        public frm_RoiCreate(RoiCreateTool roiCreateTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(roiCreateTool);
            this.roiCreateTool.Image = roiCreateTool.Image;
            this.roiCreateTool.Circle = roiCreateTool.Circle;
            this.roiCreateTool.Rectangle1 = roiCreateTool.Rectangle1;
            this.roiCreateTool.Rectangle2 = roiCreateTool.Rectangle2;
            this.SetVal(ref this.roiCreateTool);

        }

        void DisplayVal(RoiCreateTool roiCreateTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = roiCreateTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = roiCreateTool.Names.Substring(nameIndex + 1, roiCreateTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = roiCreateTool.Names;
                    tbxToolName.Text = roiCreateTool.Names;
                }
                cbxImage.Text = roiCreateTool.ImageName;//
                cbxRegion.Text = roiCreateTool.RegionName;
                cbxRoi.Text = roiCreateTool.SetdrawShape;
                cbxSetdraw.Text = roiCreateTool.Setdraw;
                cebxIsSelectedRegions.Checked = roiCreateTool.IsSelectedRegions;
           
                cbxImage.Items.Clear();
                if (roiCreateTool.Image != null)
                {
                    foreach (var item in roiCreateTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxRegion.Items.Clear();
                 if (roiCreateTool.Region != null)
                 {
                     foreach (var item in roiCreateTool.Region.Keys)
                     {
                         cbxRegion.Items.Add(item); //加载图像到下拉箱
                     }
                 }

            }
            catch
            {
                cbxImage.Items.Clear();
                if (roiCreateTool.Image != null)
                {
                    foreach (var item in roiCreateTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                if (roiCreateTool.Region != null)
                {
                    foreach (var item in roiCreateTool.Region.Keys)
                    {
                        cbxRegion.Items.Add(item); //加载图像到下拉箱
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
        void SetVal(ref RoiCreateTool roiCreateTool)
        {
            roiCreateTool.Names = ImageTool.Tool.区域创建.ToString() + "_" + tbxToolName.Text;
            roiCreateTool.ImageName = cbxImage.Text;
            roiCreateTool.RegionName = cbxRegion.Text;
            roiCreateTool.SetdrawShape = cbxRoi.Text;
            roiCreateTool.Setdraw = cbxSetdraw.Text;
            roiCreateTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
          
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.roiCreateTool.Names = ImageTool.Tool.区域创建.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///halconView1.DispImage((HObject)this.roiCreateTool.Image[cbxImage.Text], true);
           // halconView1.FitImage();
            roiCreateTool.ImageName = cbxImage.Text;
        }

        private void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            roiCreateTool.RegionName = cbxRegion.Text;
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DispObj((HObject)this.roiCreateTool.Region[cbxRegion.Text], hWindowControl1.HalconWindow);
            HSystem.SetSystem("flush_graphic", "false");
        }

        private void cbxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            roiCreateTool.SetdrawShape = cbxRoi.Text;
        }
        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            if (cbxRoi.Text == BlobTool.Roi.方向矩形.ToString())
                roiCreateTool.SetdrawShape = BlobTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.矩形.ToString())
                roiCreateTool.SetdrawShape = BlobTool.Roi.矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.圆.ToString())
                roiCreateTool.SetdrawShape = BlobTool.Roi.圆.ToString();
            roiCreateTool.draw_roi();
        }

        private void cbxSetdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
            roiCreateTool.Setdraw = cbxSetdraw.Text;
            roiCreateTool.set_after();
        }

        private void cebxIsSelectedRegions_CheckedChanged(object sender, EventArgs e)
        {
            roiCreateTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
            roiCreateTool.set_after();
        }

        private void frm_RoiCreate_Load(object sender, EventArgs e)
        {
            this.FormClosing += frm_RoiCreate_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            string[] roi = new string[] { BlobTool.Roi.方向矩形.ToString(), BlobTool.Roi.矩形.ToString(), BlobTool.Roi.圆.ToString() };
            cbxRoi.Items.AddRange(roi);
            this.roiCreateTool.hWindowControl1 = hWindowControl1;
        }

        void frm_RoiCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = roiCreateTool.set_after();
            //halconView1.ToolLable2.Text = "FAIL";
            //halconView1.ToolLable2.ForeColor = Color.Red;
            if (roiCreateTool.ResultLogic)
            {
               /// halconView1.ToolLable2.Text = "PASS";
                //halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            //halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.roiCreateTool);
                this.Hide();
                frm = null;
                handleSetval(this.roiCreateTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.roiCreateTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            frm = null;
            this.Hide();
        }
    }
}
