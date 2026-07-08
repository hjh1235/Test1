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
    public partial class frm_RoiOpUnion : Form
    {
        static frm_RoiOpUnion frm;
        RoiOpUnionTool roiOpUnionTool = new RoiOpUnionTool();
        public delegate void HandledSetVal(RoiOpUnionTool roiOpUnionTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_RoiOpUnion SingleShow(RoiOpUnionTool roiOpUnionTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_RoiOpUnion(roiOpUnionTool, handleSetval);
            }
            return frm;
        }
        public frm_RoiOpUnion()
        {
            InitializeComponent();
        }

        public frm_RoiOpUnion(RoiOpUnionTool roiOpUnionTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(roiOpUnionTool);
            this.roiOpUnionTool.Image = roiOpUnionTool.Image;
            this.roiOpUnionTool.Region = roiOpUnionTool.Region;
            this.roiOpUnionTool.Circle = roiOpUnionTool.Circle;
            this.roiOpUnionTool.Rectangle1 = roiOpUnionTool.Rectangle1;
            this.roiOpUnionTool.Rectangle2 = roiOpUnionTool.Rectangle2;
            this.SetVal(ref this.roiOpUnionTool);
        }
        void DisplayVal(RoiOpUnionTool roiOpUnionTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = roiOpUnionTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = roiOpUnionTool.Names.Substring(nameIndex + 1, roiOpUnionTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = roiOpUnionTool.Names;
                    tbxToolName.Text = roiOpUnionTool.Names;
                }
                cbxImage.Text = roiOpUnionTool.ImageName;//
                cbxRegion.Text = roiOpUnionTool.RegionName;
                cbxRoi.Text = roiOpUnionTool.SetdrawShape;
                cbxSetdraw.Text = roiOpUnionTool.Setdraw;
                cebxIsSelectedRegions.Checked = roiOpUnionTool.IsSelectedRegions;
           
                cbxImage.Items.Clear();
                if (roiOpUnionTool.Image != null)
                {
                    foreach (var item in roiOpUnionTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxRegion.Items.Clear();
                 if (roiOpUnionTool.Region != null)
                 {
                     foreach (var item in roiOpUnionTool.Region.Keys)
                     {
                         cbxRegion.Items.Add(item); //加载图像到下拉箱
                     }
                 }

            }
            catch
            {
                cbxImage.Items.Clear();
                if (roiOpUnionTool.Image != null)
                {
                    foreach (var item in roiOpUnionTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                if (roiOpUnionTool.Region != null)
                {
                    foreach (var item in roiOpUnionTool.Region.Keys)
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
        void SetVal(ref RoiOpUnionTool roiOpUnionTool)
        {
            roiOpUnionTool.Names = ImageTool.Tool.区域合并.ToString() + "_" + tbxToolName.Text;
            roiOpUnionTool.ImageName = cbxImage.Text;
            roiOpUnionTool.RegionName = cbxRegion.Text;
            roiOpUnionTool.SetdrawShape = cbxRoi.Text;
            roiOpUnionTool.Setdraw = cbxSetdraw.Text;
            roiOpUnionTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
          
        }
         private void frm_RoiOpUnion_Load(object sender, EventArgs e)
        {
            this.FormClosing += frm_RoiOpUnion_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            string[] roi = new string[] { BlobTool.Roi.方向矩形.ToString(), BlobTool.Roi.矩形.ToString(), BlobTool.Roi.圆.ToString() };
            cbxRoi.Items.AddRange(roi);            
            this.roiOpUnionTool.hWindowControl1 = hWindowControl1;
        }

         void frm_RoiOpUnion_FormClosing(object sender, FormClosingEventArgs e)
         {
             frm = null;
         }

         private void tbxToolName_TextChanged(object sender, EventArgs e)
         {
             this.roiOpUnionTool.Names = ImageTool.Tool.区域合并.ToString() + "_" + tbxToolName.Text;
             this.Text = tbxToolName.Text;
         }

         private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
         {
            //// halconView1.DispImage((HObject)this.roiOpUnionTool.Image[cbxImage.Text], true);
           //  halconView1.FitImage();
             roiOpUnionTool.ImageName = cbxImage.Text;
         }

         private void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
         {
             roiOpUnionTool.RegionName = cbxRegion.Text;
             HSystem.SetSystem("flush_graphic", "true");
            // halconView1.DispObject((HObject)this.roiOpUnionTool.Region[cbxRegion.Text]);
             HSystem.SetSystem("flush_graphic", "false");
         }
         private void cbxRoi_SelectedIndexChanged(object sender, EventArgs e)
         {
             roiOpUnionTool.SetdrawShape = cbxRoi.Text;
         }

         private void btnDrawRoi_Click(object sender, EventArgs e)
         {
             if (cbxRoi.Text == BlobTool.Roi.方向矩形.ToString())
                 roiOpUnionTool.SetdrawShape = BlobTool.Roi.方向矩形.ToString();
             if (cbxRoi.Text == BlobTool.Roi.矩形.ToString())
                 roiOpUnionTool.SetdrawShape = BlobTool.Roi.矩形.ToString();
             if (cbxRoi.Text == BlobTool.Roi.圆.ToString())
                 roiOpUnionTool.SetdrawShape = BlobTool.Roi.圆.ToString();
             roiOpUnionTool.draw_roi();
         }

         private void cbxSetdraw_SelectedIndexChanged(object sender, EventArgs e)
         {
             roiOpUnionTool.Setdraw = cbxSetdraw.Text;
             roiOpUnionTool.set_after();
         }

         private void cebxIsSelectedRegions_CheckedChanged(object sender, EventArgs e)
         {
             roiOpUnionTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
             roiOpUnionTool.set_after();
         }

         private void btn_run_Click(object sender, EventArgs e)
         {

             long timer = roiOpUnionTool.set_after();
            // halconView1.ToolLable2.Text = "FAIL";
            // halconView1.ToolLable2.ForeColor = Color.Red;
             if (roiOpUnionTool.ResultLogic)
             {
                // halconView1.ToolLable2.Text = "PASS";
                // halconView1.ToolLable2.ForeColor = Color.Lime;
             }
             lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
             //halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
         }

         private void btn_sure_Click(object sender, EventArgs e)
         {
             try
             {
                 this.SetVal(ref this.roiOpUnionTool);
                 this.Hide();
                 frm = null;
                 handleSetval(this.roiOpUnionTool);
             }
             catch
             {
                 this.Hide();
                 frm = null;
                 handleSetval(this.roiOpUnionTool);
             }
         }

         private void btn_cancel_Click(object sender, EventArgs e)
         {
             frm = null;
             this.Hide();
         }
    }
}
