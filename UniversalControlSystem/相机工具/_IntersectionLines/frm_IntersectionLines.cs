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
    public partial class frm_IntersectionLines: Form
    {    

        static frm_IntersectionLines frm;
        IntersectionLinesTool intersectionLinesTool = new IntersectionLinesTool();
      
        public delegate void HandledSetVal( IntersectionLinesTool intersectionLinesTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_IntersectionLines SingleShow( IntersectionLinesTool intersectionLinesTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_IntersectionLines(intersectionLinesTool, handleSetval);
            }
            return frm;
        }

        public frm_IntersectionLines(IntersectionLinesTool intersectionLinesTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(intersectionLinesTool);
            this.intersectionLinesTool.Image = intersectionLinesTool.Image;
            this.intersectionLinesTool.HtRowLine1 = intersectionLinesTool.HtRowLine1;
            this.intersectionLinesTool.HtRowLine2 = intersectionLinesTool.HtRowLine2;
            this.intersectionLinesTool.HtColLine1 = intersectionLinesTool.HtColLine1;
            this.intersectionLinesTool.HtColLine2 = intersectionLinesTool.HtColLine2;
            this.SetVal(ref this.intersectionLinesTool);
         }

        void DisplayVal(IntersectionLinesTool intersectionLinesTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = intersectionLinesTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = intersectionLinesTool.Names.Substring(nameIndex + 1, intersectionLinesTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = intersectionLinesTool.Names;
                    tbxToolName.Text = intersectionLinesTool.Names;
                }
                cbxImage.Text = intersectionLinesTool.ImageName;//
                cbxLineName1.Text = intersectionLinesTool.LineName1;
                cbxLineName2.Text = intersectionLinesTool.LineName2;
                cbxImage.Items.Clear();
                if (intersectionLinesTool.Image != null)
                {
                    foreach (var item in intersectionLinesTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
               // halconView1.DispImage((HObject)intersectionLinesTool.Image[cbxImage.Text], true);
              //  halconView1.FitImage();
                cbxLineName1.Items.Clear();
                if (intersectionLinesTool.HtRowLine1 != null)
                {
                    foreach (var item in intersectionLinesTool.HtRowLine1.Keys)
                    {
                        cbxLineName1.Items.Add(item);//加载点
                        cbxLineName2.Items.Add(item);//加载点
                    }
                }
                Register();//注册事件
            }
            catch
            {
                cbxImage.Items.Clear();
                if (intersectionLinesTool.Image != null)
                {
                    foreach (var item in intersectionLinesTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxLineName1.Items.Clear();
                if (intersectionLinesTool.HtRowLine1 != null)
                {
                    foreach (var item in intersectionLinesTool.HtRowLine1.Keys)
                    {
                        cbxLineName1.Items.Add(item);//加载点
                        cbxLineName2.Items.Add(item);//加载点
                    }
                } Register();
            }
        }
        void SetVal(ref IntersectionLinesTool intersectionLinesTool)
        {
            try
            {
                intersectionLinesTool.Names = ImageTool.Tool.两线交点测量.ToString() + "_" + tbxToolName.Text;
                intersectionLinesTool.ImageName = cbxImage.Text;
                intersectionLinesTool.LineName1 = cbxLineName1.Text;
                intersectionLinesTool.LineName2 = cbxLineName2.Text;
     
            }
            catch { }
        }
        void Cancel()
        {
            cbxLineName1.SelectedIndexChanged -= new EventHandler(cbxLineName1_SelectedIndexChanged);
            cbxLineName2.SelectedIndexChanged -= new EventHandler(cbxLineName2_SelectedIndexChanged);
         
        }
        void Register()
        {
            cbxLineName1.SelectedIndexChanged += new EventHandler(cbxLineName1_SelectedIndexChanged);
            cbxLineName2.SelectedIndexChanged += new EventHandler(cbxLineName2_SelectedIndexChanged);
         
        }

        public frm_IntersectionLines()
        {
            InitializeComponent();
        }

        private void frm_IntersectionLines_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormClosing += frm_IntersectionLines_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.intersectionLinesTool.hWindowControl1 = hWindowControl1;
        }

        private void frm_IntersectionLines_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
 
        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            intersectionLinesTool.Names = ImageTool.Tool.两线夹角测量.ToString() + "_" + tbxToolName.Text;
        }
        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            intersectionLinesTool.ImageName = cbxImage.Text;
          //  halconView1.DispImage((HObject)this.intersectionLinesTool.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
       

        }

        private void cbxLineName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            intersectionLinesTool.LineName1 = cbxLineName1.Text;
            intersectionLinesTool.set_after();
          
        }

        private void cbxLineName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            intersectionLinesTool.LineName2 = cbxLineName2.Text;
            intersectionLinesTool.set_after();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = intersectionLinesTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
           // halconView1.ToolLable2.Text = "FAIL";
           // halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.intersectionLinesTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
             //   halconView1.ToolLable2.Text = "PASS";
               // halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
           // halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            lblResult.Text = "row:" + intersectionLinesTool.Row.TupleString("0.03f") + " col:" + intersectionLinesTool.Col.TupleString("0.03f");
          
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.intersectionLinesTool);
                this.Hide();
                frm = null;
                handleSetval(this.intersectionLinesTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.intersectionLinesTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            intersectionLinesTool.dispresult();
        }
    }
}
