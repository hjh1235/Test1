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
    public partial class frm_Morphology : Form
    {
        static frm_Morphology frm;
        MorphologyTool morphologyTool = new MorphologyTool();
        public delegate void HandledSetVal(MorphologyTool morphologyTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_Morphology SingleShow(MorphologyTool roiOpUnionTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_Morphology(roiOpUnionTool, handleSetval);
            }
            return frm;
        }
        public frm_Morphology()
        {
            InitializeComponent();
        }

        public frm_Morphology(MorphologyTool morphologyTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(morphologyTool);
            this.morphologyTool.Image = morphologyTool.Image;
            this.morphologyTool.Region = morphologyTool.Region;
            this.SetVal(ref this.morphologyTool);
        }
        void DisplayVal(MorphologyTool morphologyTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = morphologyTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = morphologyTool.Names.Substring(nameIndex + 1, morphologyTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = morphologyTool.Names;
                }
                cbxImage.Text = morphologyTool.ImageName;//
                cbxRegion.Text = morphologyTool.RegionName;
                cbxSetdraw.Text = morphologyTool.Setdraw;
                cbxMorphology.Text = morphologyTool.Morphology;
                nudWith.Value = Convert.ToDecimal(morphologyTool.Width.I);
                nudHeiht.Value = Convert.ToDecimal(morphologyTool.Height.I);
                cebxIsSelectedRegions.Checked = morphologyTool.IsSelectedRegions;

                if (cbxMorphology.Text.Contains("圆:"))
                {
                    lblHig.Visible = false;
                    nudHeiht.Visible = false;
                    lblWith.Text = "半径:";
                }
                else
                {
                    lblHig.Visible = true;
                    nudHeiht.Visible = true;
                }
                cbxImage.Items.Clear();
                if (morphologyTool.Image != null)
                {
                    foreach (var item in morphologyTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxRegion.Items.Clear();
                 if (morphologyTool.Region != null)
                 {
                     foreach (var item in morphologyTool.Region.Keys)
                     {
                         cbxRegion.Items.Add(item); //加载图像到下拉箱
                     }
                 }
               // halconView1.DispImage((HObject)morphologyTool.Image[cbxImage.Text], true);
               // halconView1.FitImage();
            }
            catch (Exception ex)
            {
                cbxImage.Items.Clear();
                if (morphologyTool.Image != null)
                {
                    foreach (var item in morphologyTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                   // halconView1.DispImage((HObject)morphologyTool.Image[cbxImage.Text], true);
                 //   halconView1.FitImage();
                }
            }

            Register();//注册事件
        }

        void Cancel()
        {
            cbxRegion.SelectedIndexChanged -= new EventHandler(cbxRegion_SelectedIndexChanged);
            cbxSetdraw.SelectedIndexChanged -= new EventHandler(cbxSetdraw_SelectedIndexChanged);
            cebxIsSelectedRegions.CheckedChanged -= new EventHandler(cebxIsSelectedRegions_CheckedChanged);

            cbxMorphology.SelectedIndexChanged -= new EventHandler(cbxMorphlogy_SelectedIndexChanged);
            nudWith.ValueChanged -= new EventHandler(nudWith_ValueChanged);
            nudHeiht.ValueChanged -= new EventHandler(nudHeiht_ValueChanged);
        }
        void Register()
        {
            cbxRegion.SelectedIndexChanged += new EventHandler(cbxRegion_SelectedIndexChanged);
            cbxSetdraw.SelectedIndexChanged += new EventHandler(cbxSetdraw_SelectedIndexChanged);
            cebxIsSelectedRegions.CheckedChanged += new EventHandler(cebxIsSelectedRegions_CheckedChanged);

            cbxMorphology.SelectedIndexChanged += new EventHandler(cbxMorphlogy_SelectedIndexChanged);
            nudWith.ValueChanged += new EventHandler(nudWith_ValueChanged);
            nudHeiht.ValueChanged += new EventHandler(nudHeiht_ValueChanged);
        }
        void SetVal(ref MorphologyTool morphologyTool)
        {
            morphologyTool.Names = ImageTool.Tool.区域形态处理.ToString() + "_" + tbxToolName.Text;
            morphologyTool.ImageName = cbxImage.Text;
            morphologyTool.RegionName = cbxRegion.Text;
            morphologyTool.Setdraw = cbxSetdraw.Text;
            morphologyTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
            morphologyTool.Morphology = cbxMorphology.Text;
            morphologyTool.Width =(int) nudWith.Value;
            morphologyTool.Height = (int)nudHeiht.Value;
        }
         private void frm_Morphology_Load(object sender, EventArgs e)
        {
            this.FormClosing += frm_Morphology_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.morphologyTool.hWindowControl1 = hWindowControl1;
        }
         void frm_Morphology_FormClosing(object sender, FormClosingEventArgs e)
         {
             frm = null;
         }
         private void tbxToolName_TextChanged(object sender, EventArgs e)
         {
             this.morphologyTool.Names = ImageTool.Tool.区域形态处理.ToString() + "_" + tbxToolName.Text;
             this.Text = tbxToolName.Text;
         }

         private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
         {
           //  halconView1.DispImage((HObject)this.morphologyTool.Image[cbxImage.Text], true);
           //  halconView1.FitImage();
             morphologyTool.ImageName = cbxImage.Text;
         }

         private void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
         {
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, cbxSetdraw.Text);
            HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
            morphologyTool.RegionName = cbxRegion.Text;
            HSystem.SetSystem("flush_graphic", "true");
          //  hWindowControl1.DispImage((HObject)this.morphologyTool.Image[cbxImage.Text], true);
          //  hWindowControl1.FitImage();
          //  hWindowControl1.DispObject((HObject)this.morphologyTool.Region[cbxRegion.Text]);
            HSystem.SetSystem("flush_graphic", "false");
        }
         private void cbxSetdraw_SelectedIndexChanged(object sender, EventArgs e)
         {
             morphologyTool.Setdraw = cbxSetdraw.Text;
             morphologyTool.set_after();
         }
         private void cebxIsSelectedRegions_CheckedChanged(object sender, EventArgs e)
         {
             morphologyTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
             morphologyTool.set_after();
         }
         private void btn_run_Click(object sender, EventArgs e)
         {
             long timer = morphologyTool.set_after();
            // hWindowControl1.ToolLable2.Text = "FAIL";
            // hWindowControl1.ToolLable2.ForeColor = Color.Red;
             if (morphologyTool.ResultLogic)
             {
               //  hWindowControl1.ToolLable2.Text = "PASS";
               //  hWindowControl1.ToolLable2.ForeColor = Color.Lime;
             }
             lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
             //hWindowControl1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
         }

         private void btn_sure_Click(object sender, EventArgs e)
         {
             try
             {
                 this.SetVal(ref this.morphologyTool);
                 this.Hide();
                 frm = null;
                 handleSetval(this.morphologyTool);
             }
             catch
             {
                 this.Hide();
                 frm = null;
                 handleSetval(this.morphologyTool);
             }
         }

         private void btn_cancel_Click(object sender, EventArgs e)
         {
             frm = null;
             this.Hide();
         }

        private void cbxMorphlogy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxToolName.Text = cbxMorphology.Text;
            morphologyTool.Morphology = cbxMorphology.Text;
            if (cbxMorphology.Text.Contains("圆"))
            {
                lblHig.Visible = false;
                nudHeiht.Visible = false;
                lblWith.Text = "半径:";
            }
            else
            {
                lblHig.Visible = true;
                nudHeiht.Visible = true;
                lblWith.Text = "宽:";
            }
            morphologyTool.set_after();
        }

        private void nudWith_ValueChanged(object sender, EventArgs e)
        {
            morphologyTool.Width = (int)nudWith.Value;
            morphologyTool.set_after();
        }

        private void nudHeiht_ValueChanged(object sender, EventArgs e)
        {
            morphologyTool.Height = (int)nudHeiht.Value;
            morphologyTool.set_after();
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            morphologyTool.dispresult();
        }
    }
}
