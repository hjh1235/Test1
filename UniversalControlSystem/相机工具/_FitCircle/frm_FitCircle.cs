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
    public partial class frm_FitCircle : Form
    {

        static frm_FitCircle frm;
        FitCircleTool fitCircleTool = new FitCircleTool();
        public delegate void HandledSetVal(FitCircleTool fitCircleTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_FitCircle SingleShow(FitCircleTool fitCircleTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_FitCircle(fitCircleTool, handleSetval);
            }
            return frm;
        }

        public frm_FitCircle()
        {
            InitializeComponent();
        }
        public frm_FitCircle(FitCircleTool fitCircleTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(fitCircleTool);
            this.fitCircleTool.Image = fitCircleTool.Image;
            this.fitCircleTool.Rows = fitCircleTool.Rows;
            this.fitCircleTool.Cols = fitCircleTool.Cols;
            this.fitCircleTool.Direct = fitCircleTool.Direct;
            this.fitCircleTool.DicHomMat2D = fitCircleTool.DicHomMat2D;
            this.SetVal(ref this.fitCircleTool);

        }
        void DisplayVal(FitCircleTool fitCircleTool)
        {
            try
            {
                Cancel();
                int nameIndex = fitCircleTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = fitCircleTool.Names.Substring(nameIndex + 1, fitCircleTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = fitCircleTool.Names;
                    tbxToolName.Text = fitCircleTool.Names;
                }
                cbxImage.Text = fitCircleTool.ImageName;//
                cbxFixture.Text = fitCircleTool.FixNames;
                cebxFixture.Checked = fitCircleTool.IsFixture;
                nudSigma.Value = Convert.ToDecimal(fitCircleTool.Sigma.D);
                nudThreshold.Value = Convert.ToDecimal(fitCircleTool.Threshold.I);

                if (fitCircleTool.Transition == 1)
                    rbntPostive.Checked = true;
                if (fitCircleTool.Transition == 2)
                    rbntNegative.Checked = true;
                if (fitCircleTool.Transition == 3)
                    rbntAll.Checked = true;
                if (fitCircleTool.Selcet == 1)
                    rbntSelectFirst.Checked = true;
                if (fitCircleTool.Selcet == 2)
                    rbntSelectLast.Checked = true;
                if (fitCircleTool.Selcet == 3)
                    rbntSelectAll.Checked = true;

                takBarRulenums.Value = fitCircleTool.Rulenums;
                takBarRuleWidth.Value = fitCircleTool.Rulewidth;
                takBarRuleHigh.Value = fitCircleTool.Ruleheiht;

                cebxFitCircle.Checked = fitCircleTool.IsFitCircle;
                cebxFitPoint.Checked = fitCircleTool.IsFitPoint;
                cebxRule.Checked = fitCircleTool.IsRule;

                nudHmeasure.Value = Convert.ToDecimal(fitCircleTool.Hmeasure.D);
                nudLmeasure.Value = Convert.ToDecimal(fitCircleTool.Lmeasure.D);
                cebxMeasure.Checked = fitCircleTool.IsMeasure;
                nudScale.Value = Convert.ToDecimal(fitCircleTool.Scale.D);

                cbxImage.Items.Clear();
                if (fitCircleTool.Image != null)
                {
                    foreach (var item in fitCircleTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
               // halconView1.DispImage((HObject)fitCircleTool.Image[cbxImage.Text], true);
                //halconView1.FitImage();
                cbxFixture.Items.Clear();
                if (fitCircleTool.DicHomMat2D != null)
                {
                    foreach (var item in fitCircleTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();
            }
            catch
            {
                cbxImage.Items.Clear();
                if (fitCircleTool.Image != null)
                {
                    foreach (var item in fitCircleTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (fitCircleTool.DicHomMat2D != null)
                {
                    foreach (var item in fitCircleTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();
            }
        }

        void SetVal(ref FitCircleTool fitCircleTool)
        {
            fitCircleTool.Names = ImageTool.Tool.找圆测量.ToString() + "_" + tbxToolName.Text;
            fitCircleTool.ImageName = cbxImage.Text;
            fitCircleTool.FixNames = cbxFixture.Text;
            fitCircleTool.IsFixture = cebxFixture.Checked;
            fitCircleTool.Sigma = (double)nudSigma.Value;
            fitCircleTool.Threshold = (int)nudThreshold.Value;

            fitCircleTool.Rulenums = takBarRulenums.Value;
            fitCircleTool.Ruleheiht = takBarRuleHigh.Value;
            fitCircleTool.Rulewidth = takBarRuleWidth.Value;
            lblRulenums.Text = takBarRulenums.Value.ToString();
            lblRuleHigh.Text = takBarRuleHigh.Value.ToString();
            lblRuleWidth.Text = takBarRuleWidth.Value.ToString();
            fitCircleTool.IsRule = cebxRule.Checked;
            fitCircleTool.IsFitPoint = cebxFitPoint.Checked;
            fitCircleTool.IsFitCircle = cebxFitCircle.Checked;
            fitCircleTool.Lmeasure = (double)nudLmeasure.Value;
            fitCircleTool.Hmeasure = (double)nudHmeasure.Value;
            fitCircleTool.IsMeasure = cebxMeasure.Checked;
            fitCircleTool.Scale = (double)nudScale.Value;

            if (rbntPostive.Checked)
                fitCircleTool.Transition = 1;
            if (rbntNegative.Checked)
                fitCircleTool.Transition = 2;
            if (rbntAll.Checked)
                fitCircleTool.Transition = 3;
            if (rbntSelectFirst.Checked)
                fitCircleTool.Selcet = 1;
            if (rbntSelectLast.Checked)
                fitCircleTool.Selcet = 2;
            if (rbntSelectAll.Checked)
                fitCircleTool.Selcet = 3;
        }
        void Cancel()
        {
            takBarRulenums.Scroll -= new EventHandler(takBarRulenums_Scroll);
            takBarRuleHigh.Scroll -= new EventHandler(takBarRuleHigh_Scroll);
            takBarRuleWidth.Scroll -= new EventHandler(takBarRuleWidth_Scroll);
            nudSigma.ValueChanged -= new EventHandler(nudSigma_ValueChanged);
            nudThreshold.ValueChanged -= new EventHandler(nudThreshold_ValueChanged);
            rbntAll.CheckedChanged -= new EventHandler(rbntAll_CheckedChanged);
            rbntNegative.CheckedChanged -= new EventHandler(rbntNegative_CheckedChanged);
            rbntPostive.CheckedChanged -= new EventHandler(rbntPostive_CheckedChanged);
            rbntSelectAll.CheckedChanged -= new EventHandler(rbntSelectAll_CheckedChanged);
            rbntSelectFirst.CheckedChanged -= new EventHandler(rbntSelectFirst_CheckedChanged);
            rbntSelectLast.CheckedChanged -= new EventHandler(rbntSelectLast_CheckedChanged);
            cebxFitCircle.CheckedChanged -= new EventHandler(cebxFitCircle_CheckedChanged);
            cebxFitPoint.CheckedChanged -= new EventHandler(cebxFitPoint_CheckedChanged);
            cebxRule.CheckedChanged -= new EventHandler(cebxRule_CheckedChanged);
            nudHmeasure.ValueChanged -= new EventHandler(nudHmeasure_ValueChanged);
            nudLmeasure.ValueChanged -= new EventHandler(nudLmeasure_ValueChanged);
            cebxMeasure.CheckedChanged -= new EventHandler(cebxMeasure_CheckedChanged);
            nudScale.ValueChanged -= new EventHandler(nudScale_ValueChanged);
            cebxFixture.CheckedChanged -= new EventHandler(cebxFixture_CheckedChanged);

        }
        void Register()
        {
            cebxFixture.CheckedChanged += new EventHandler(cebxFixture_CheckedChanged);
            takBarRulenums.Scroll += new EventHandler(takBarRulenums_Scroll);
            takBarRuleHigh.Scroll += new EventHandler(takBarRuleHigh_Scroll);
            takBarRuleWidth.Scroll += new EventHandler(takBarRuleWidth_Scroll);
            nudSigma.ValueChanged += new EventHandler(nudSigma_ValueChanged);
            nudThreshold.ValueChanged += new EventHandler(nudThreshold_ValueChanged);
            rbntAll.CheckedChanged += new EventHandler(rbntAll_CheckedChanged);
            rbntNegative.CheckedChanged += new EventHandler(rbntNegative_CheckedChanged);
            rbntPostive.CheckedChanged += new EventHandler(rbntPostive_CheckedChanged);
            rbntSelectAll.CheckedChanged += new EventHandler(rbntSelectAll_CheckedChanged);
            rbntSelectFirst.CheckedChanged += new EventHandler(rbntSelectFirst_CheckedChanged);
            rbntSelectLast.CheckedChanged += new EventHandler(rbntSelectLast_CheckedChanged);
            cebxFitCircle.CheckedChanged += new EventHandler(cebxFitCircle_CheckedChanged);
            cebxFitPoint.CheckedChanged += new EventHandler(cebxFitPoint_CheckedChanged);
            cebxRule.CheckedChanged += new EventHandler(cebxRule_CheckedChanged);
            nudHmeasure.ValueChanged += new EventHandler(nudHmeasure_ValueChanged);
            nudLmeasure.ValueChanged += new EventHandler(nudLmeasure_ValueChanged);
            cebxMeasure.CheckedChanged += new EventHandler(cebxMeasure_CheckedChanged);
            nudScale.ValueChanged += new EventHandler(nudScale_ValueChanged);
        }

 
        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
              {
                this.SetVal(ref this.fitCircleTool);
                this.Hide();
                frm = null;
                handleSetval(this.fitCircleTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.fitCircleTool);
            }
        }

    
        private void btn_run_Click(object sender, EventArgs e)
        {
            try { 
            long timer = fitCircleTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
           // halconView1.ToolLable2.Text = "FAIL";
           // halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.fitCircleTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
                //halconView1.ToolLable2.Text = "PASS";
               // halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
          //  halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            DataGridView(dataGridView1, fitCircleTool.ResultRadius,fitCircleTool.ResultDiameter, fitCircleTool.ResultRowCenter, fitCircleTool.ResultColCenter);//结果输出
        

            }
            catch
            {
                MessageBox.Show("结果输出异常,查看设定参数！");
            }
        }

        private void frm_FitCircle_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormClosing += frm_FitCircle_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.fitCircleTool.hWindowControl1 = hWindowControl1;
           
        }

        void frm_FitCircle_FormClosing(object sender, FormClosingEventArgs e)
        {
             frm = null;
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.fitCircleTool.Names = ImageTool.Tool.找圆测量.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  halconView1.DispImage((HObject)this.fitCircleTool.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
            fitCircleTool.ImageName = cbxImage.Text;
        }

        private void nudSigma_ValueChanged(object sender, EventArgs e)
        {
            fitCircleTool.Sigma = (double )nudSigma.Value;
            fitCircleTool.set_after();
        }

        private void nudThreshold_ValueChanged(object sender, EventArgs e)
        {
            fitCircleTool.Threshold = (int)nudThreshold.Value;
            fitCircleTool.set_after();
        }
        private void rbntPostive_CheckedChanged(object sender, EventArgs e)
        {
            fitCircleTool.Transition = 1;
            fitCircleTool.set_after();
        }
        private void rbntNegative_CheckedChanged(object sender, EventArgs e)
        {
            fitCircleTool.Transition = 2;
            fitCircleTool.set_after();
        }
        private void rbntAll_CheckedChanged(object sender, EventArgs e)
        {
            fitCircleTool.Transition = 3;
            fitCircleTool.set_after();
        }
        private void rbntSelectFirst_CheckedChanged(object sender, EventArgs e)
        {
            fitCircleTool.Selcet = 1;
            fitCircleTool.set_after();
        }
        private void rbntSelectLast_CheckedChanged(object sender, EventArgs e)
        {
            fitCircleTool.Selcet = 2;
            fitCircleTool.set_after();
        }
        private void rbntSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            fitCircleTool.Selcet = 3;
            fitCircleTool.set_after();
        }
        private void takBarRulenums_Scroll(object sender, EventArgs e)
        {
            fitCircleTool.Rulenums = takBarRulenums.Value;
            lblRulenums.Text = takBarRulenums.Value.ToString();
            fitCircleTool.set_after();
        }
        private void takBarRuleHigh_Scroll(object sender, EventArgs e)
        {
            fitCircleTool.Ruleheiht = takBarRuleHigh.Value;
            lblRuleHigh.Text = takBarRuleHigh.Value.ToString();
            fitCircleTool.set_after();
        }
        private void takBarRuleWidth_Scroll(object sender, EventArgs e)
        {
            fitCircleTool.Rulewidth = takBarRuleWidth.Value;
            lblRuleWidth.Text = takBarRuleWidth.Value.ToString();
            fitCircleTool.set_after();
        }
         private void cebxRule_CheckedChanged(object sender, EventArgs e)
        {
            fitCircleTool.IsRule = cebxRule.Checked;
            fitCircleTool.set_after();
        }
        private void cebxFitPoint_CheckedChanged(object sender, EventArgs e)
        {
            fitCircleTool.IsFitPoint = cebxFitPoint.Checked;
            fitCircleTool.set_after();
        }
        private void cebxFitCircle_CheckedChanged(object sender, EventArgs e)
        {
           fitCircleTool.IsFitCircle= cebxFitCircle.Checked;
           fitCircleTool.set_after();
        }
        private void nudLmeasure_ValueChanged(object sender, EventArgs e)
        {
            fitCircleTool.Lmeasure = (double)nudLmeasure.Value;
            fitCircleTool.set_after();
        }
        private void nudHmeasure_ValueChanged(object sender, EventArgs e)
        {
            fitCircleTool.Hmeasure = (double)nudHmeasure.Value;
            fitCircleTool.set_after();
        }
        private void cebxMeasure_CheckedChanged(object sender, EventArgs e)
        {
            fitCircleTool.IsMeasure = cebxMeasure.Checked;
        }
        //结果输出
        private void DataGridView(DataGridView dataGridView, HTuple result_radius, HTuple result_diameter, HTuple result_row, HTuple result_col)
        {
            try
              {
                  string str_radius, str_diameter, str_Row, str_Col;
                dataGridView.Columns.Clear();//
                dataGridView.Columns.Add("", "半径");//
                dataGridView.Columns.Add("", "直径");//
                dataGridView.Columns.Add("", "CenterRow");//
                dataGridView.Columns.Add("", "CenterCol");//
                for (int i = 0; i < result_row.Length; i++)
                {
                    dataGridView.Rows.Add(1);//加载row
                    ;//row表头ID
                    dataGridView.Rows[i].HeaderCell.Value = i.ToString();//row表头
                    ;//表格赋值
                    str_radius = result_radius.TupleSelect(i).TupleString("0.3f");//表格赋值col(0)
                    str_diameter = result_diameter.TupleSelect(i).TupleString("0.3f");//表格赋值col(1)
                    str_Row = result_row.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(2)
                    str_Col = result_col.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(3)

                    dataGridView.Rows[i].Cells[0].Value = str_radius; ;//表格赋值col(0)
                    dataGridView.Rows[i].Cells[1].Value = str_diameter; ;//表格赋值col(1)
                    dataGridView.Rows[i].Cells[2].Value = str_Row; ;//表格赋值col(2)
                    dataGridView.Rows[i].Cells[3].Value = str_Col; ;//表格赋值col(3)
                }
            }
            catch { }
        }

        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
            fitCircleTool.FixNames = cbxFixture.Text;
        }

        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
      //      halconView1.ContextMenuStripHide();
        //    halconView1.Focus();
            fitCircleTool.draw_roi();
        }

      
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

         private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            fitCircleTool.IsFixture = cebxFixture.Checked;
        }
         private void nudScale_ValueChanged(object sender, EventArgs e)
         {
             fitCircleTool.Scale = (double)nudScale.Value;
         }

         private void halconView1_HMouseWheelEvent(object sender)
         {
             fitCircleTool.dispresult();
         }

    }
}
