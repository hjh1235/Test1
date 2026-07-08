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
    public partial class frm_GrayTophat : Form
    {
        static frm_GrayTophat frm;
        GrayTophatTool grayTophatTool = new GrayTophatTool();
        public delegate void HandledSetVal(GrayTophatTool grayTophatTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_GrayTophat SingleShow(GrayTophatTool grayTophatTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_GrayTophat(grayTophatTool, handleSetval);
            }
            return frm;
        }
        public frm_GrayTophat()
        {
            InitializeComponent();
        }

        public frm_GrayTophat(GrayTophatTool grayTophatTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(grayTophatTool);
            this.grayTophatTool.Image = grayTophatTool.Image;
         
            this.SetVal(ref this.grayTophatTool);
        }
        void DisplayVal(GrayTophatTool morphologyTool)
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
          
                cbxMorphlogy.Text = morphologyTool.Morphology;
                nudWith.Value = Convert.ToDecimal(morphologyTool.Width.I);
                nudHeiht.Value = Convert.ToDecimal(morphologyTool.Height.I);
                nudSmax.Value = Convert.ToDecimal(grayTophatTool.Smax.I);

                cbxImage.Items.Clear();
                if (morphologyTool.Image != null)
                {
                    foreach (var item in morphologyTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
              
               // halconView1.DispImage((HObject)morphologyTool.Image[cbxImage.Text], true);
                //halconView1.FitImage();
         

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
                  //  halconView1.DispImage((HObject)morphologyTool.Image[cbxImage.Text], true);
                   // halconView1.FitImage();
                }
               
             }

            Register();//注册事件
        }

        void Cancel()
        {
        
            cbxMorphlogy.SelectedIndexChanged -= new EventHandler(cbxMorphlogy_SelectedIndexChanged);
       
            nudWith.ValueChanged -= new EventHandler(nudWith_ValueChanged);
            nudHeiht.ValueChanged -= new EventHandler(nudHeiht_ValueChanged);
            nudSmax.ValueChanged -= new EventHandler(nudSmax_ValueChanged);
        }
        void Register()
        {
       
            cbxMorphlogy.SelectedIndexChanged += new EventHandler(cbxMorphlogy_SelectedIndexChanged);
      
            nudWith.ValueChanged += new EventHandler(nudWith_ValueChanged);
            nudHeiht.ValueChanged += new EventHandler(nudHeiht_ValueChanged);
            nudSmax.ValueChanged += new EventHandler(nudSmax_ValueChanged);
        }
        void SetVal(ref GrayTophatTool grayTophatTool)
        {
            grayTophatTool.Names = ImageTool.Tool.顶帽处理图像.ToString() + "_" + tbxToolName.Text;
            grayTophatTool.ImageName = cbxImage.Text;
          
            grayTophatTool.Morphology = cbxMorphlogy.Text;
         
            grayTophatTool.Width =(int) nudWith.Value;
            grayTophatTool.Height = (int)nudHeiht.Value;
            grayTophatTool.Smax = (int)nudSmax.Value;
        }
         private void frm_Morphology_Load(object sender, EventArgs e)
        {
            this.FormClosing += frm_Morphology_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.grayTophatTool.hWindowControl1 = hWindowControl1;
        }
         void frm_Morphology_FormClosing(object sender, FormClosingEventArgs e)
         {
             frm = null;
         }
         private void tbxToolName_TextChanged(object sender, EventArgs e)
         {
             this.grayTophatTool.Names = ImageTool.Tool.顶帽处理图像.ToString() + "_" + tbxToolName.Text;
             this.Text = tbxToolName.Text;
         }

         private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
         {
            // halconView1.DispImage((HObject)this.grayTophatTool.Image[cbxImage.Text], true);
            // halconView1.FitImage();
             grayTophatTool.ImageName = cbxImage.Text;
         }

         private void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
         {
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
          
            HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
          
            HSystem.SetSystem("flush_graphic", "true");
          //  halconView1.DispImage((HObject)this.grayTophatTool.Image[cbxImage.Text], true);
           // halconView1.FitImage();
          
            HSystem.SetSystem("flush_graphic", "false");
        }
         private void cbxSetdraw_SelectedIndexChanged(object sender, EventArgs e)
         {

            grayTophatTool.set_after();
         }
         private void cebxIsSelectedRegions_CheckedChanged(object sender, EventArgs e)
         {
            grayTophatTool.set_after();
         }
         private void btn_run_Click(object sender, EventArgs e)
         {
             long timer = grayTophatTool.set_after();
            // halconView1.ToolLable2.Text = "FAIL";
            // halconView1.ToolLable2.ForeColor = Color.Red;
             if (grayTophatTool.ResultLogic)
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
                 this.SetVal(ref this.grayTophatTool);
                 this.Hide();
                 frm = null;
                 handleSetval(this.grayTophatTool);
             }
             catch
             {
                 this.Hide();
                 frm = null;
                 handleSetval(this.grayTophatTool);
             }
         }
         private void btn_cancel_Click(object sender, EventArgs e)
         {
             frm = null;
             this.Hide();
         }
        private void cbxMorphlogy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxToolName.Text = cbxMorphlogy.Text;
            grayTophatTool.Morphology = cbxMorphlogy.Text;
            if (cbxMorphlogy.Text.Contains("圆"))
            {
                lblHig.Visible = false;
                nudHeiht.Enabled = false;
                lblWith.Text = "半径:";
            }
            else
            {
                lblHig.Visible = true;
                nudHeiht.Enabled = true;
                lblWith.Text = "宽:";
            }
            grayTophatTool.set_after();
        }

        private void nudWith_ValueChanged(object sender, EventArgs e)
        {
            grayTophatTool.Width = (int)nudWith.Value;
            grayTophatTool.set_after();
        }

        private void nudHeiht_ValueChanged(object sender, EventArgs e)
        {
            grayTophatTool.Height = (int)nudHeiht.Value;
            grayTophatTool.set_after();
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            grayTophatTool.dispresult();
        }

        private void nudSmax_ValueChanged(object sender, EventArgs e)
        {
            grayTophatTool.Smax = (int)nudSmax.Value;
            grayTophatTool.set_after();
        }
    }
}
