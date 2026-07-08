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
    public partial class frm_DistancePointPoint : Form
    {
        static frm_DistancePointPoint frm;
        DistancePointPointTool distancePpTool = new DistancePointPointTool();
        public delegate void HandledSetVal(DistancePointPointTool distancePpTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_DistancePointPoint SingleShow(DistancePointPointTool distancePpTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_DistancePointPoint(distancePpTool, handleSetval);
            }
            return frm;
        }

        public frm_DistancePointPoint(DistancePointPointTool distancePpTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(distancePpTool);
            this.distancePpTool.Image = distancePpTool.Image;
            this.distancePpTool.HtRowPoint = distancePpTool.HtRowPoint;
            this.distancePpTool.HtColPoint = distancePpTool.HtColPoint;
            this.SetVal(ref this.distancePpTool);
         }

        void DisplayVal(DistancePointPointTool distancePpTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = distancePpTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = distancePpTool.Names.Substring(nameIndex + 1, distancePpTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = distancePpTool.Names;
                    tbxToolName.Text = distancePpTool.Names;
                }
                cbxImage.Text = distancePpTool.ImageName;//
                cbxPointName1.Text = distancePpTool.PointName1;
                cbxPointName2.Text = distancePpTool.PointName2;

                nudHmeasure.Value = Convert.ToDecimal(distancePpTool.Hmeasure.D);
                nudLmeasure.Value = Convert.ToDecimal(distancePpTool.Lmeasure.D);
                cebxMeasure.Checked = distancePpTool.IsMeasure;

                nudHmeasure1.Value = Convert.ToDecimal(distancePpTool.Hmeasure1.D);
                nudLmeasure1.Value = Convert.ToDecimal(distancePpTool.Lmeasure1.D);
                cebxMeasure1.Checked = distancePpTool.IsMeasure1;

                nudHmeasure2.Value = Convert.ToDecimal(distancePpTool.Hmeasure2.D);
                nudLmeasure2.Value = Convert.ToDecimal(distancePpTool.Lmeasure2.D);
                cebxMeasure2.Checked = distancePpTool.IsMeasure2;

                nudScale.Value = Convert.ToDecimal(distancePpTool.Scale.D);

                cbxImage.Items.Clear();
                if (distancePpTool.Image != null)
                {
                    foreach (var item in distancePpTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                //halconView1.DispImage((HObject)distancePpTool.Image[cbxImage.Text], true);
                //halconView1.FitImage();
                cbxPointName1.Items.Clear();
                if (distancePpTool.HtRowPoint != null)
                {
                    foreach (var item in distancePpTool.HtRowPoint.Keys)
                    {
                        cbxPointName1.Items.Add(item);//加载点
                        cbxPointName2.Items.Add(item);//加载点
                    }
                }
                Register();//注册事件
            }
            catch
            { cbxImage.Items.Clear();
                if (distancePpTool.Image != null)
                {
                    foreach (var item in distancePpTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxPointName1.Items.Clear();
                if (distancePpTool.HtRowPoint != null)
                {
                    foreach (var item in distancePpTool.HtRowPoint.Keys)
                    {
                        cbxPointName1.Items.Add(item);//加载点
                        cbxPointName2.Items.Add(item);//加载点
                    }
                }
                Register();//注册事件
            }
        }
        void SetVal(ref DistancePointPointTool distancePpTool)
        {
            distancePpTool.Names = ImageTool.Tool.点到点测量.ToString() + "_" + tbxToolName.Text;
            distancePpTool.ImageName = cbxImage.Text;
            distancePpTool.PointName1 = cbxPointName1.Text;
            distancePpTool.PointName2 = cbxPointName2.Text;
            distancePpTool.Lmeasure = (double)nudLmeasure.Value;
            distancePpTool.Hmeasure = (double)nudHmeasure.Value;
            distancePpTool.IsMeasure = cebxMeasure.Checked;

            distancePpTool.Lmeasure1 = (double)nudLmeasure1.Value;
            distancePpTool.Hmeasure1 = (double)nudHmeasure1.Value;
            distancePpTool.IsMeasure1 = cebxMeasure1.Checked;

            distancePpTool.Lmeasure2 = (double)nudLmeasure2.Value;
            distancePpTool.Hmeasure2 = (double)nudHmeasure2.Value;
            distancePpTool.IsMeasure2 = cebxMeasure2.Checked;

            distancePpTool.Scale = (double)nudScale.Value;
        }
        void Cancel()
        {
            cbxPointName1.SelectedIndexChanged -= new EventHandler(cbxPointName1_SelectedIndexChanged);
            cbxPointName2.SelectedIndexChanged -= new EventHandler(cbxPointName2_SelectedIndexChanged);
            nudLmeasure.ValueChanged -= new EventHandler(nudLmeasure_ValueChanged);
            nudHmeasure.ValueChanged -= new EventHandler(nudHmeasure_ValueChanged);
            cebxMeasure.CheckedChanged -= new EventHandler(cebxMeasure_CheckedChanged);

            nudLmeasure1.ValueChanged -= new EventHandler(nudLmeasure1_ValueChanged);
            nudHmeasure1.ValueChanged -= new EventHandler(nudHmeasure1_ValueChanged);
            cebxMeasure1.CheckedChanged -= new EventHandler(cebxMeasure1_CheckedChanged);

            nudLmeasure2.ValueChanged -= new EventHandler(nudLmeasure2_ValueChanged);
            nudHmeasure2.ValueChanged -= new EventHandler(nudHmeasure2_ValueChanged);
            cebxMeasure2.CheckedChanged -= new EventHandler(cebxMeasure2_CheckedChanged);


            nudScale.ValueChanged -= new EventHandler(nudScale_ValueChanged);
        }
        void Register()
        {
            cbxPointName1.SelectedIndexChanged += new EventHandler(cbxPointName1_SelectedIndexChanged);
            cbxPointName2.SelectedIndexChanged += new EventHandler(cbxPointName2_SelectedIndexChanged);
            nudLmeasure.ValueChanged += new EventHandler(nudLmeasure_ValueChanged);
            nudHmeasure.ValueChanged += new EventHandler(nudHmeasure_ValueChanged);
            cebxMeasure.CheckedChanged += new EventHandler(cebxMeasure_CheckedChanged);
            nudLmeasure1.ValueChanged += new EventHandler(nudLmeasure1_ValueChanged);
            nudHmeasure1.ValueChanged += new EventHandler(nudHmeasure1_ValueChanged);
            cebxMeasure1.CheckedChanged += new EventHandler(cebxMeasure1_CheckedChanged);

            nudLmeasure2.ValueChanged += new EventHandler(nudLmeasure2_ValueChanged);
            nudHmeasure2.ValueChanged += new EventHandler(nudHmeasure2_ValueChanged);
            cebxMeasure2.CheckedChanged += new EventHandler(cebxMeasure2_CheckedChanged);
            nudScale.ValueChanged += new EventHandler(nudScale_ValueChanged);
        }

        public frm_DistancePointPoint()
        {
            InitializeComponent();
        }
        private void frm_DistancePointPoint_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.CenterToParent();
            this.FormClosing += frm_DistancePointPoint_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.distancePpTool.hWindowControl1 = hWindowControl1;
            this.TopMost = false;
        }

        void frm_DistancePointPoint_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            distancePpTool.Names = ImageTool.Tool.点到点测量.ToString() + "_" + tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   halconView1.DispImage((HObject)this.distancePpTool.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
            distancePpTool.ImageName = cbxImage.Text;
        }

        private void cbxPointName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            distancePpTool.PointName1 = cbxPointName1.Text;
            distancePpTool.set_after();
        }

        private void cbxPointName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            distancePpTool.PointName2 = cbxPointName2.Text;
            distancePpTool.set_after();
     
        }

        private void nudLmeasure_ValueChanged(object sender, EventArgs e)
        {
           
            distancePpTool.Lmeasure = (double)nudLmeasure.Value;
            distancePpTool.set_after();
       
        }

        private void nudHmeasure_ValueChanged(object sender, EventArgs e)
        {
            distancePpTool.Hmeasure = (double)nudHmeasure.Value;
            distancePpTool.set_after();
        }

        private void cebxMeasure_CheckedChanged(object sender, EventArgs e)
        {
              distancePpTool.IsMeasure = cebxMeasure.Checked;
              distancePpTool.set_after();
        }
        private void nudLmeasure1_ValueChanged(object sender, EventArgs e)
        {
             distancePpTool.Lmeasure1 = (double)nudLmeasure1.Value;
             distancePpTool.set_after();
        }

        private void nudHmeasure1_ValueChanged(object sender, EventArgs e)
        {
            distancePpTool.Hmeasure1 = (double)nudHmeasure1.Value;
            distancePpTool.set_after();
        }

        private void cebxMeasure1_CheckedChanged(object sender, EventArgs e)
        {
            distancePpTool.IsMeasure1 = cebxMeasure1.Checked;
            distancePpTool.set_after();
        }

        private void nudLmeasure2_ValueChanged(object sender, EventArgs e)
        {
            distancePpTool.Lmeasure2 = (double)nudLmeasure2.Value;
            distancePpTool.set_after();
        }

        private void nudHmeasure2_ValueChanged(object sender, EventArgs e)
        {
            distancePpTool.Hmeasure2 = (double)nudHmeasure2.Value;
            distancePpTool.set_after();
        }

        private void cebxMeasure2_CheckedChanged(object sender, EventArgs e)
        {
            distancePpTool.IsMeasure2 = cebxMeasure2.Checked;
            distancePpTool.set_after();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            try
            {
            long timer = distancePpTool.set_after();
            lblResult.Text = "FAIL";
            lblResult1.Text = "0.000";
            lblResult2.Text = "0.000";
           
         //   halconView1.ToolLable2.Text = "FAIL";
          //  halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.distancePpTool.ResultLogic)
            {
                lblResult.Text = "PASS";
              
             //   halconView1.ToolLable2.Text = "PASS";
             //   halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
           // halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            lblResult.Text = distancePpTool.Distance.D.ToString("0.000");
            if (distancePpTool.IsMeasure1)
                lblResult1.Text = distancePpTool.Distance1.D.ToString("0.000");
            if (distancePpTool.IsMeasure2)
                lblResult2.Text = distancePpTool.Distance2.D.ToString("0.000");
       
            }
            catch
            {
                MessageBox.Show("结果输出异常,查看设定参数！");
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetVal(ref this.distancePpTool);
                this.Hide();
                frm = null;
                handleSetval(this.distancePpTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.distancePpTool);
            }
        }

        private void nudScale_ValueChanged(object sender, EventArgs e)
        {
            distancePpTool.Scale = (double)nudScale.Value;
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            distancePpTool.dispresult();
        }
    }
}
