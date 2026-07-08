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
    public partial class frm_DistancePointLine : Form
    {
         static frm_DistancePointLine frm;
        DistancePointLineTool distancePlTool = new DistancePointLineTool();
        public delegate void HandledSetVal(DistancePointLineTool distancePlTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_DistancePointLine SingleShow(DistancePointLineTool distancePlTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_DistancePointLine(distancePlTool, handleSetval);
            }
            return frm;
        }
       public frm_DistancePointLine(DistancePointLineTool distancePlTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(distancePlTool);
            this.distancePlTool.Image = distancePlTool.Image;
            this.distancePlTool.HtRowPoint = distancePlTool.HtRowPoint;
            this.distancePlTool.HtColPoint = distancePlTool.HtColPoint;
            this.distancePlTool.HtRowLine1 = distancePlTool.HtRowLine1;
            this.distancePlTool.HtColLine1 = distancePlTool.HtColLine1;
            this.distancePlTool.HtRowLine2 = distancePlTool.HtRowLine2;
            this.distancePlTool.HtColLine2 = distancePlTool.HtColLine2;
            this.SetVal(ref this.distancePlTool);
         }
          void DisplayVal(DistancePointLineTool distancePlTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = distancePlTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = distancePlTool.Names.Substring(nameIndex + 1, distancePlTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = distancePlTool.Names;
                    tbxToolName.Text = distancePlTool.Names;
                }
                cbxImage.Text = distancePlTool.ImageName;//
                cbxPointName1.Text = distancePlTool.PointName1;
                cbxLineName1.Text = distancePlTool.LineName1;
                nudHmeasure.Value = Convert.ToDecimal(distancePlTool.Hmeasure.D);
                nudLmeasure.Value = Convert.ToDecimal(distancePlTool.Lmeasure.D);
                cebxMeasure.Checked = distancePlTool.IsMeasure;
                nudScale.Value = Convert.ToDecimal(distancePlTool.Scale.D);
                cbxImage.Items.Clear();
                if (distancePlTool.Image != null)
                {
                    if (distancePlTool.Image != null)
                    {
                        foreach (var item in distancePlTool.Image.Keys)
                        {
                            cbxImage.Items.Add(item); //加载图像到下拉箱
                        }
                    }
                }

            //    halconView1.DispImage((HObject)distancePlTool.Image[cbxImage.Text], true);
             //   halconView1.FitImage();
                cbxPointName1.Items.Clear();
                if (distancePlTool.HtRowPoint != null)
                {
                    foreach (var item in distancePlTool.HtRowPoint.Keys)
                    {
                        cbxPointName1.Items.Add(item);//加载点
                    }
                }
                cbxLineName1.Items.Clear();
                if (distancePlTool.HtColLine1 != null)
                {
                    foreach (var item in distancePlTool.HtColLine1.Keys)
                    {
                        cbxLineName1.Items.Add(item);//加载线
                    }
                }
                Register();//注册事件
            }
            catch
            {cbxImage.Items.Clear();
                if (distancePlTool.Image != null)
                {
                    if (distancePlTool.Image != null)
                    {
                        foreach (var item in distancePlTool.Image.Keys)
                        {
                            cbxImage.Items.Add(item); //加载图像到下拉箱
                        }
                    }
                }
                cbxPointName1.Items.Clear();
                if (distancePlTool.HtRowPoint != null)
                {
                    foreach (var item in distancePlTool.HtRowPoint.Keys)
                    {
                        cbxPointName1.Items.Add(item);//加载点
                    }
                }
                cbxLineName1.Items.Clear();
                if (distancePlTool.HtColLine1 != null)
                {
                    foreach (var item in distancePlTool.HtColLine1.Keys)
                    {
                        cbxLineName1.Items.Add(item);//加载线
                    }
                }
                Register();//注册事件 
            }
        }
        void SetVal(ref DistancePointLineTool distancePlTool)
        {
            distancePlTool.Names = ImageTool.Tool.点到线测量.ToString() + "_" + tbxToolName.Text;
            distancePlTool.ImageName = cbxImage.Text;
            distancePlTool.PointName1 = cbxPointName1.Text;
            distancePlTool.LineName1 = cbxLineName1.Text;
            distancePlTool.Lmeasure = (double)nudLmeasure.Value;
            distancePlTool.Hmeasure = (double)nudHmeasure.Value;
            distancePlTool.IsMeasure = cebxMeasure.Checked;
            distancePlTool.Scale = (double)nudScale.Value;
        }
        void Cancel()
        {
            cbxPointName1.SelectedIndexChanged -= new EventHandler(cbxPointName1_SelectedIndexChanged);
            cbxLineName1.SelectedIndexChanged -= new EventHandler(cbxLineName1_SelectedIndexChanged);
            nudLmeasure.ValueChanged -= new EventHandler(nudLmeasure_ValueChanged);
            nudHmeasure.ValueChanged -= new EventHandler(nudHmeasure_ValueChanged);
            cebxMeasure.CheckedChanged -= new EventHandler(cebxMeasure_CheckedChanged);
            nudScale.ValueChanged -= new EventHandler(nudScale_ValueChanged);
        }
        void Register()
        {
            cbxPointName1.SelectedIndexChanged += new EventHandler(cbxPointName1_SelectedIndexChanged);
            cbxLineName1.SelectedIndexChanged += new EventHandler(cbxLineName1_SelectedIndexChanged);
            nudLmeasure.ValueChanged += new EventHandler(nudLmeasure_ValueChanged);
            nudHmeasure.ValueChanged += new EventHandler(nudHmeasure_ValueChanged);
            cebxMeasure.CheckedChanged += new EventHandler(cebxMeasure_CheckedChanged);
            nudScale.ValueChanged += new EventHandler(nudScale_ValueChanged);
        }
        public frm_DistancePointLine()
        {

            InitializeComponent();
        }
         private void frm_DistancePointLinecs_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.CenterToParent();
            this.FormClosing += frm_DistancePointLine_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.distancePlTool.hWindowControl1 = hWindowControl1;

        }
        void frm_DistancePointLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            distancePlTool.Names = ImageTool.Tool.点到线测量.ToString() + "_" + tbxToolName.Text;
        }
         private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
           // halconView1.DispImage((HObject)this.distancePlTool.Image[cbxImage.Text], true);
            //halconView1.FitImage();
            distancePlTool.ImageName = cbxImage.Text;
        }
         private void cbxPointName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            distancePlTool.PointName1 = cbxPointName1.Text;
            distancePlTool.set_after();
        }
        private void cbxLineName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            distancePlTool.LineName1 = cbxLineName1.Text;
            distancePlTool.set_after();
        }
         private void nudLmeasure_ValueChanged(object sender, EventArgs e)
        {
            distancePlTool.Lmeasure = (double)nudLmeasure.Value;
            distancePlTool.set_after();
        }
         private void nudHmeasure_ValueChanged(object sender, EventArgs e)
        {
            distancePlTool.Hmeasure = (double)nudHmeasure.Value;
            distancePlTool.set_after();
        }
           private void cebxMeasure_CheckedChanged(object sender, EventArgs e)
        {
            distancePlTool.IsMeasure = cebxMeasure.Checked;
            distancePlTool.set_after();
        }
         private void btn_run_Click(object sender, EventArgs e)
        {
            try { 
            long timer = distancePlTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
            //halconView1.ToolLable2.Text = "FAIL";
           // halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.distancePlTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
               // halconView1.ToolLable2.Text = "PASS";
               // halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
          //  halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            lblResult.Text = distancePlTool.Distance.TupleString("0.03f");
            }
            catch
            {
                MessageBox.Show("结果输出异常,查看设定参数！");
            }

        }
        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.distancePlTool);
                this.Hide();
                frm = null;
                handleSetval(this.distancePlTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.distancePlTool);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void nudScale_ValueChanged(object sender, EventArgs e)
        {
            distancePlTool.Scale = (double)nudScale.Value;
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            distancePlTool.dispresult();
        }
    }
}
