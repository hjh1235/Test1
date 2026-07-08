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
    public partial class frm_DistanceLineLine : Form
    {
        static frm_DistanceLineLine frm;
        DistanceLineLineTool distanceLlTool = new DistanceLineLineTool();
        public delegate void HandledSetVal(DistanceLineLineTool distanceLlTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_DistanceLineLine SingleShow(DistanceLineLineTool distanceLlTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_DistanceLineLine(distanceLlTool, handleSetval);
            }
            return frm;
        }

        public frm_DistanceLineLine(DistanceLineLineTool distanceLlTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(distanceLlTool);
            this.distanceLlTool.Image = distanceLlTool.Image;
            this.distanceLlTool.HtLine1 = distanceLlTool.HtLine1;
            this.SetVal(ref this.distanceLlTool);
         }

        void DisplayVal(DistanceLineLineTool distanceLlTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = distanceLlTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = distanceLlTool.Names.Substring(nameIndex + 1, distanceLlTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = distanceLlTool.Names;
                    tbxToolName.Text = distanceLlTool.Names;
                }
                cbxImage.Text = distanceLlTool.ImageName;//
                cbxLineName1.Text = distanceLlTool.LineName1;
                cbxLineName2.Text = distanceLlTool.LineName2;
                nudHmeasure.Value = Convert.ToDecimal(distanceLlTool.Hmeasure.D);
                nudLmeasure.Value = Convert.ToDecimal(distanceLlTool.Lmeasure.D);
                cebxMeasure.Checked = distanceLlTool.IsMeasure;
                nudScale.Value = Convert.ToDecimal(distanceLlTool.Scale.D);
                cbxImage.Items.Clear();
                if (distanceLlTool.Image != null)
                {
                    foreach (var item in distanceLlTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }

                HW.Instance().DispImage((HObject)distanceLlTool.Image[cbxImage.Text], true);
                HW.Instance().FitImage();
                cbxLineName1.Items.Clear();
                if (distanceLlTool.HtLine1 != null)
                {
                    foreach (var item in distanceLlTool.HtLine1.Keys)
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
                if (distanceLlTool.Image != null)
                {
                    foreach (var item in distanceLlTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxLineName1.Items.Clear();
                if (distanceLlTool.HtLine1 != null)
                {
                    foreach (var item in distanceLlTool.HtLine1.Keys)
                    {
                        cbxLineName1.Items.Add(item);//加载点
                        cbxLineName2.Items.Add(item);//加载点
                    }
                }
                Register();//注册事件
            }
        }
        void SetVal(ref DistanceLineLineTool distanceLlTool)
        {
            distanceLlTool.Names = ImageTool.Tool.两线间距测量.ToString() + "_" + tbxToolName.Text;
            distanceLlTool.ImageName = cbxImage.Text;
            distanceLlTool.LineName1 = cbxLineName1.Text;
            distanceLlTool.LineName2 = cbxLineName2.Text;
            distanceLlTool.Lmeasure = (double)nudLmeasure.Value;
            distanceLlTool.Hmeasure = (double)nudHmeasure.Value;
            distanceLlTool.IsMeasure = cebxMeasure.Checked;
            distanceLlTool.Scale = (double)nudScale.Value;
        }
        void Cancel()
        {
            cbxLineName1.SelectedIndexChanged -= new EventHandler(cbxLineName1_SelectedIndexChanged);
            cbxLineName2.SelectedIndexChanged -= new EventHandler(cbxLineName2_SelectedIndexChanged);
            nudLmeasure.ValueChanged -= new EventHandler(nudLmeasure_ValueChanged);
            nudHmeasure.ValueChanged -= new EventHandler(nudHmeasure_ValueChanged);
            cebxMeasure.CheckedChanged -= new EventHandler(cebxMeasure_CheckedChanged);
            nudScale.ValueChanged -= new EventHandler(nudScale_ValueChanged);
        }
        void Register()
        {
            cbxLineName1.SelectedIndexChanged += new EventHandler(cbxLineName1_SelectedIndexChanged);
            cbxLineName2.SelectedIndexChanged += new EventHandler(cbxLineName2_SelectedIndexChanged);
            nudLmeasure.ValueChanged += new EventHandler(nudLmeasure_ValueChanged);
            nudHmeasure.ValueChanged += new EventHandler(nudHmeasure_ValueChanged);
            cebxMeasure.CheckedChanged += new EventHandler(cebxMeasure_CheckedChanged);
            nudScale.ValueChanged += new EventHandler(nudScale_ValueChanged);
        }

        public frm_DistanceLineLine()
        {
            InitializeComponent();
        }

        private void frm_DistanceLineLine_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            HW.Instance().TopLevel = false;
            panel1.Controls.Add(HW.Instance());
            HW.Instance().Size = panel1.Size;
            HW.Instance().Show();

            this.FormClosing += frm_DistanceLineLine_FormClosing;
            HOperatorSet.SetWindowParam(HW.Instance().HalconWindow, "background_color", "blue");
            this.CenterToScreen();
         //  this.distanceLlTool.hWindowControl1 = HW.Instance().HalconWindow;
         
        }

        void frm_DistanceLineLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            distanceLlTool.Names = ImageTool.Tool.两线间距测量.ToString() + "_" + tbxToolName.Text;
           
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            distanceLlTool.ImageName = cbxImage.Text;
            HW.Instance().DispImage((HObject)this.distanceLlTool.Image[cbxImage.Text], true);
            HW.Instance().FitImage();
        }

        private void cbxLineName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            distanceLlTool.LineName1 = cbxLineName1.Text;
            distanceLlTool.set_after();
          
        }

        private void cbxLineName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            distanceLlTool.LineName2 = cbxLineName2.Text;
            distanceLlTool.set_after();
        
        }

        private void nudLmeasure_ValueChanged(object sender, EventArgs e)
        {
            distanceLlTool.Lmeasure = (double)nudLmeasure.Value;
            distanceLlTool.set_after();
          
        }

        private void nudHmeasure_ValueChanged(object sender, EventArgs e)
        {
            distanceLlTool.Hmeasure = (double)nudHmeasure.Value;
            distanceLlTool.set_after();
        
        }

        private void cebxMeasure_CheckedChanged(object sender, EventArgs e)
        {
            distanceLlTool.IsMeasure = cebxMeasure.Checked;
            distanceLlTool.set_after();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            try { 
            long timer = distanceLlTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
            //halconView1.ToolLable2.Text = "FAIL";
           // halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.distanceLlTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
               // halconView1.ToolLable2.Text = "PASS";
              //  halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            //halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            lblResult.Text = distanceLlTool.Distance.TupleString("0.03f");
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
                this.SetVal(ref this.distanceLlTool);
                this.Hide();
                frm = null;
                handleSetval(this.distanceLlTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.distanceLlTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void nudScale_ValueChanged(object sender, EventArgs e)
        {
            distanceLlTool.Scale = (double)nudScale.Value;
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            distanceLlTool.dispresult();
        }
    }
}
