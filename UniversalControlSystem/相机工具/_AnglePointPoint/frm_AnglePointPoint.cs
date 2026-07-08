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
    public partial class frm_AnglePointPoint : Form
    {    

        static frm_AnglePointPoint frm;
        DistanceAnglePointPointTool distanceAPpTool = new DistanceAnglePointPointTool();
        public delegate void HandledSetVal(DistanceAnglePointPointTool distanceALlTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_AnglePointPoint SingleShow(DistanceAnglePointPointTool distanceALlTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_AnglePointPoint(distanceALlTool, handleSetval);
            }
            return frm;
        }

        public frm_AnglePointPoint(DistanceAnglePointPointTool distanceALlTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(distanceALlTool);
            this.distanceAPpTool.Image = distanceALlTool.Image;
            this.distanceAPpTool.HtRowLine1 = distanceALlTool.HtRowLine1;
            this.distanceAPpTool.HtRowLine2 = distanceALlTool.HtRowLine2;
            this.distanceAPpTool.HtColLine1 = distanceALlTool.HtColLine1;
            this.distanceAPpTool.HtColLine2 = distanceALlTool.HtColLine2;
            this.SetVal(ref this.distanceAPpTool);
         }

        void DisplayVal(DistanceAnglePointPointTool distanceALlTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = distanceALlTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = distanceALlTool.Names.Substring(nameIndex + 1, distanceALlTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = distanceALlTool.Names;
                    tbxToolName.Text = distanceALlTool.Names;
                }
                cbxImage.Text = distanceALlTool.ImageName;//
                cbxLineName1.Text = distanceALlTool.LineName1;
                nudHangle.Value = Convert.ToDecimal(distanceALlTool.Hmeasure.D);
                nudLangle.Value = Convert.ToDecimal(distanceALlTool.Lmeasure.D);
                cebxAngle.Checked = distanceALlTool.IsMeasure;
                cbxImage.Items.Clear();
                if (distanceALlTool.Image != null)
                {
                    foreach (var item in distanceALlTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                HW.Instance().DispImage((HObject)distanceALlTool.Image[cbxImage.Text], true);
                HW.Instance().FitImage();
                cbxLineName1.Items.Clear();
                if (distanceALlTool.HtRowLine1 != null)
                {
                    foreach (var item in distanceALlTool.HtRowLine1.Keys)
                    {
                        cbxLineName1.Items.Add(item);//加载点
                      
                    }
                }
                Register();//注册事件
            }
            catch
            {
                cbxImage.Items.Clear();
                if (distanceALlTool.Image != null)
                {
                    foreach (var item in distanceALlTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxLineName1.Items.Clear();
                if (distanceALlTool.HtRowLine1 != null)
                {
                    foreach (var item in distanceALlTool.HtRowLine1.Keys)
                    {
                        cbxLineName1.Items.Add(item);//加载点
                     
                    }
                } Register();
            }
        }
        void SetVal(ref DistanceAnglePointPointTool distanceALlTool)
        {
            try
            {
                distanceALlTool.Names = ImageTool.Tool.水平夹角测量.ToString() + "_" + tbxToolName.Text;
                distanceALlTool.ImageName = cbxImage.Text;
                distanceALlTool.LineName1 = cbxLineName1.Text;
                distanceALlTool.Lmeasure = (double)nudLangle.Value;
                distanceALlTool.Hmeasure = (double)nudHangle.Value;
                distanceALlTool.IsMeasure = cebxAngle.Checked;
            }
            catch { }
        }
        void Cancel()
        {
            cbxLineName1.SelectedIndexChanged -= new EventHandler(cbxLineName1_SelectedIndexChanged);
          
           nudLangle.ValueChanged -= new EventHandler(nudLangle_ValueChanged);
            nudHangle.ValueChanged -= new EventHandler(nudHangle_ValueChanged);
            cebxAngle.CheckedChanged -= new EventHandler(cebxAngle_CheckedChanged);
        }
        void Register()
        {
            cbxLineName1.SelectedIndexChanged += new EventHandler(cbxLineName1_SelectedIndexChanged);
         
            nudLangle.ValueChanged += new EventHandler(nudLangle_ValueChanged);
            nudHangle.ValueChanged += new EventHandler(nudHangle_ValueChanged);
            cebxAngle.CheckedChanged += new EventHandler(cebxAngle_CheckedChanged);
        }

        public frm_AnglePointPoint()
        {
            InitializeComponent();
        }

        private void frm_DistancePointPoint_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HW.Instance().TopLevel = false;
            panel1.Controls.Add(HW.Instance());
            HW.Instance().Size = panel1.Size;
            HW.Instance().Show();



            this.FormClosing += frm_AngleLineLine_FormClosing;
            HOperatorSet.SetWindowParam(HW.Instance().HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.distanceAPpTool.hWindowControl1 = HW.Instance().HWindowControl;
          
        }

        void frm_AngleLineLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            distanceAPpTool.Names = ImageTool.Tool.两线夹角测量.ToString() + "_" + tbxToolName.Text;
        }
        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            distanceAPpTool.ImageName = cbxImage.Text;
            HW.Instance().DispImage((HObject)this.distanceAPpTool.Image[cbxImage.Text], true);
            HW.Instance().FitImage();
       

        }

        private void cbxLineName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            distanceAPpTool.LineName1 = cbxLineName1.Text;
            distanceAPpTool.set_after();
        }
        private void nudLangle_ValueChanged(object sender, EventArgs e)
        {
            distanceAPpTool.Lmeasure = (double)nudLangle.Value;
            distanceAPpTool.set_after();
    
        }
        private void nudHangle_ValueChanged(object sender, EventArgs e)
        {
            distanceAPpTool.Hmeasure = (double)nudHangle.Value;
            distanceAPpTool.set_after();
          
        }

        private void cebxAngle_CheckedChanged(object sender, EventArgs e)
        {
            distanceAPpTool.IsMeasure = cebxAngle.Checked;
            distanceAPpTool.set_after();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            try { 
            long timer = distanceAPpTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
                HW.Instance().ToolLable2.Text = "FAIL";
                HW.Instance().ToolLable2.ForeColor = Color.Red;
            if (this.distanceAPpTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
                    HW.Instance().ToolLable2.Text = "PASS";
                    HW.Instance().ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
                HW.Instance().ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            lblResult.Text = distanceAPpTool.Angle.D.ToString();
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
                this.SetVal(ref this.distanceAPpTool);
                this.Hide();
                frm = null;
                handleSetval(this.distanceAPpTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.distanceAPpTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            distanceAPpTool.dispresult();
        }
    }
}
