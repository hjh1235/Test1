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
    public partial class frm_FitLine : Form
    {

        public frm_FitLine()
        {
            InitializeComponent();
        }
        private void frm_FitLine_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormClosing += frm_FitCircle_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.fitLineTool.hWindowControl1 = hWindowControl1;

        }
        static frm_FitLine frm;
        FitLineTool fitLineTool = new FitLineTool();
        public delegate void HandledSetVal(FitLineTool fitLineTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_FitLine SingleShow(FitLineTool fitLineTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_FitLine(fitLineTool, handleSetval);
            }
            return frm;
        }
        public frm_FitLine(FitLineTool fitLineTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(fitLineTool);
            this.fitLineTool.Image = fitLineTool.Image;
            this.fitLineTool.Row1 = fitLineTool.Row1;
            this.fitLineTool.Col1 = fitLineTool.Col1;
            this.fitLineTool.Row2 = fitLineTool.Row2;
            this.fitLineTool.Col2 = fitLineTool.Col2;
            this.fitLineTool.DicHomMat2D = fitLineTool.DicHomMat2D;
            this.SetVal(ref this.fitLineTool);

        }
        void DisplayVal(FitLineTool fitLineTool)
        {
            try
            {
                Cancel();
                int nameIndex = fitLineTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = fitLineTool.Names.Substring(nameIndex + 1, fitLineTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = fitLineTool.Names;
                    tbxToolName.Text = fitLineTool.Names;
                }
                cbxImage.Text = fitLineTool.ImageName;//
                cbxFixture.Text = fitLineTool.FixNames;
                cebxFixture.Checked = fitLineTool.IsFixture;
                nudSigma.Value = Convert.ToDecimal(fitLineTool.Sigma.D);
                nudThreshold.Value = Convert.ToDecimal(fitLineTool.Threshold.I);

                if (fitLineTool.Transition == 1)
                    rbntPostive.Checked = true;
                if (fitLineTool.Transition == 2)
                    rbntNegative.Checked = true;
                if (fitLineTool.Transition == 3)
                    rbntAll.Checked = true;
                if (fitLineTool.Selcet == 1)
                    rbntSelectFirst.Checked = true;
                if (fitLineTool.Selcet == 2)
                    rbntSelectLast.Checked = true;
                if (fitLineTool.Selcet == 3)
                    rbntSelectAll.Checked = true;

                takBarRulenums.Value = fitLineTool.Rulenums;
                takBarRuleWidth.Value = fitLineTool.Rulewidth;
                takBarRuleHigh.Value = fitLineTool.Ruleheiht;

                cebxFitLine.Checked = fitLineTool.IsFitLine;
                cebxFitPoint.Checked = fitLineTool.IsFitPoint;
                cebxRule.Checked = fitLineTool.IsRule;

                nudHmeasure.Value = Convert.ToDecimal(fitLineTool.Hmeasure.D);
                nudLmeasure.Value = Convert.ToDecimal(fitLineTool.Lmeasure.D);
                cebxMeasure.Checked = fitLineTool.IsMeasure;

                cbxImage.Items.Clear();
                if (fitLineTool.Image != null)
                {
                    foreach (var item in fitLineTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                //halconView1.DispImage((HObject)fitLineTool.Image[cbxImage.Text], true);
               // halconView1.FitImage();
                cbxFixture.Items.Clear();
                if (fitLineTool.DicHomMat2D != null)
                {
                    foreach (var item in fitLineTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();
            }
            catch { cbxImage.Items.Clear();
                if (fitLineTool.Image != null)
                {
                    foreach (var item in fitLineTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (fitLineTool.DicHomMat2D != null)
                {
                    foreach (var item in fitLineTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();
            }
        }

        void SetVal(ref FitLineTool fitLineTool)
        {
            fitLineTool.Names = ImageTool.Tool.找线测量.ToString() + "_" + tbxToolName.Text;
            fitLineTool.ImageName = cbxImage.Text;
            fitLineTool.FixNames = cbxFixture.Text;
            fitLineTool.IsFixture = cebxFixture.Checked;
            fitLineTool.Sigma = (double)nudSigma.Value;
            fitLineTool.Threshold = (int)nudThreshold.Value;

            fitLineTool.Rulenums = takBarRulenums.Value;
            fitLineTool.Ruleheiht = takBarRuleHigh.Value;
            fitLineTool.Rulewidth = takBarRuleWidth.Value;
            lblRulenums.Text = takBarRulenums.Value.ToString();
            lblRuleHigh.Text = takBarRuleHigh.Value.ToString();
            lblRuleWidth.Text = takBarRuleWidth.Value.ToString();

            fitLineTool.IsRule = cebxRule.Checked;
            fitLineTool.IsFitPoint = cebxFitPoint.Checked;
            fitLineTool.IsFitLine = cebxFitLine.Checked;
            fitLineTool.Lmeasure = (double)nudLmeasure.Value;
            fitLineTool.Hmeasure = (double)nudHmeasure.Value;
            fitLineTool.IsMeasure = cebxMeasure.Checked;

            if (rbntPostive.Checked)
                fitLineTool.Transition = 1;
            if (rbntNegative.Checked)
                fitLineTool.Transition = 2;
            if (rbntAll.Checked)
                fitLineTool.Transition = 3;
            if (rbntSelectFirst.Checked)
                fitLineTool.Selcet = 1;
            if (rbntSelectLast.Checked)
                fitLineTool.Selcet = 2;
            if (rbntSelectAll.Checked)
                fitLineTool.Selcet = 3;
        }
        void Cancel()
        {
            cebxFixture.CheckedChanged -= new EventHandler(cebxFixture_CheckedChanged);
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
            cebxFitLine.CheckedChanged -= new EventHandler(cebxFitLine_CheckedChanged);
            cebxFitPoint.CheckedChanged -= new EventHandler(cebxFitPoint_CheckedChanged);
            cebxRule.CheckedChanged -= new EventHandler(cebxRule_CheckedChanged);
            nudHmeasure.ValueChanged -= new EventHandler(nudHmeasure_ValueChanged);
            nudLmeasure.ValueChanged -= new EventHandler(nudLmeasure_ValueChanged);
            cebxMeasure.CheckedChanged -= new EventHandler(cebxMeasure_CheckedChanged);
   
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
            cebxFitLine.CheckedChanged += new EventHandler(cebxFitLine_CheckedChanged);
            cebxFitPoint.CheckedChanged += new EventHandler(cebxFitPoint_CheckedChanged);
            cebxRule.CheckedChanged += new EventHandler(cebxRule_CheckedChanged);
            nudHmeasure.ValueChanged += new EventHandler(nudHmeasure_ValueChanged);
            nudLmeasure.ValueChanged += new EventHandler(nudLmeasure_ValueChanged);
            cebxMeasure.CheckedChanged += new EventHandler(cebxMeasure_CheckedChanged);
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
              {
                this.SetVal(ref this.fitLineTool);
                this.Hide();
                frm = null;
                handleSetval(this.fitLineTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.fitLineTool);
            }
        }

   
     

        private void btn_run_Click(object sender, EventArgs e)
        {
            try { 
            long timer = fitLineTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
           // halconView1.ToolLable2.Text = "FAIL";
           // halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.fitLineTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
              //  halconView1.ToolLable2.Text = "PASS";
               // halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
           // halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            DataGridView(dataGridView1, fitLineTool.ResultRow1, fitLineTool.ResultCol1, fitLineTool.ResultRow2, fitLineTool.ResultCol2);//结果输出
            }
            catch
            {
                MessageBox.Show("结果输出异常,查看设定参数！");
            }
        }

     

        void frm_FitCircle_FormClosing(object sender, FormClosingEventArgs e)
        {
             frm = null;
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.fitLineTool.Names = ImageTool.Tool.找圆测量.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   halconView1.DispImage((HObject)this.fitLineTool.Image[cbxImage.Text], true);
         //   halconView1.FitImage();
            fitLineTool.ImageName = cbxImage.Text;
        }

        private void nudSigma_ValueChanged(object sender, EventArgs e)
        {
            fitLineTool.Sigma = (double )nudSigma.Value;
            fitLineTool.set_after();
        }

        private void nudThreshold_ValueChanged(object sender, EventArgs e)
        {
            fitLineTool.Threshold = (int)nudThreshold.Value;
            fitLineTool.set_after();
        }
        private void rbntPostive_CheckedChanged(object sender, EventArgs e)
        {
            fitLineTool.Transition = 1;
            fitLineTool.set_after();
        }
        private void rbntNegative_CheckedChanged(object sender, EventArgs e)
        {
            fitLineTool.Transition = 2;
            fitLineTool.set_after();
        }
        private void rbntAll_CheckedChanged(object sender, EventArgs e)
        {
            fitLineTool.Transition = 3;
            fitLineTool.set_after();
        }
        private void rbntSelectFirst_CheckedChanged(object sender, EventArgs e)
        {
            fitLineTool.Selcet = 1;
            fitLineTool.set_after();
        }
        private void rbntSelectLast_CheckedChanged(object sender, EventArgs e)
        {
            fitLineTool.Selcet = 2;
            fitLineTool.set_after();
        }
        private void rbntSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            fitLineTool.Selcet = 3;
            fitLineTool.set_after();
        }
        private void takBarRulenums_Scroll(object sender, EventArgs e)
        {
            fitLineTool.Rulenums = takBarRulenums.Value;
            lblRulenums.Text = takBarRulenums.Value.ToString();
            fitLineTool.set_after();
        }
        private void takBarRuleHigh_Scroll(object sender, EventArgs e)
        {
            fitLineTool.Ruleheiht = takBarRuleHigh.Value;
            lblRuleHigh.Text = takBarRuleHigh.Value.ToString();
            fitLineTool.set_after();
        }
        private void takBarRuleWidth_Scroll(object sender, EventArgs e)
        {
            fitLineTool.Rulewidth = takBarRuleWidth.Value;
            lblRuleWidth.Text = takBarRuleWidth.Value.ToString();
            fitLineTool.set_after();
        }
        private void cebxRule_CheckedChanged(object sender, EventArgs e)
        {
            fitLineTool.IsRule = cebxRule.Checked;
            fitLineTool.set_after();
        }
        private void cebxFitPoint_CheckedChanged(object sender, EventArgs e)
        {
            fitLineTool.IsFitPoint = cebxFitPoint.Checked;
            fitLineTool.set_after();
        }
        private void cebxFitLine_CheckedChanged(object sender, EventArgs e)
        {
           fitLineTool.IsFitLine= cebxFitLine.Checked;
           fitLineTool.set_after();
        }
        private void nudLmeasure_ValueChanged(object sender, EventArgs e)
        {
            fitLineTool.Lmeasure = (double)nudLmeasure.Value;
            fitLineTool.set_after();
        }
        private void nudHmeasure_ValueChanged(object sender, EventArgs e)
        {
            fitLineTool.Hmeasure = (double)nudHmeasure.Value;
            fitLineTool.set_after();
        }
        private void cebxMeasure_CheckedChanged(object sender, EventArgs e)
        {
            fitLineTool.IsMeasure = cebxMeasure.Checked;
        }
        //结果输出
        private void DataGridView(DataGridView dataGridView, HTuple result_row1, HTuple result_col1, HTuple result_row2, HTuple result_col2)
        {
            try
              {
                string str_Row1, str_Col1, str_Row2, str_Col2;
                dataGridView.Columns.Clear();//
                dataGridView.Columns.Add("", "ResultRow1");//
                dataGridView.Columns.Add("", "ResultCol1");//
                dataGridView.Columns.Add("", "ResultRow2");//
                dataGridView.Columns.Add("", "ResultCol2");//
                for (int i = 0; i < result_row1.Length; i++)
                {
                    dataGridView.Rows.Add(1);//加载row
                    ;//row表头ID
                    dataGridView.Rows[i].HeaderCell.Value = i.ToString();//row表头
                    ;//表格赋值
                    str_Row1 = result_row1.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(0)
                    str_Col1 = result_col1.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(1)
                    str_Row2 = result_row2.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(2)
                    str_Col2 = result_col2.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(3)

                    dataGridView.Rows[i].Cells[0].Value = str_Row1; ;//表格赋值col(0)
                    dataGridView.Rows[i].Cells[1].Value = str_Col1; ;//表格赋值col(1)
                    dataGridView.Rows[i].Cells[2].Value = str_Row2; ;//表格赋值col(2)
                    dataGridView.Rows[i].Cells[3].Value = str_Col2; ;//表格赋值col(3)
                }
            }
            catch { }
        }

        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
            fitLineTool.FixNames = cbxFixture.Text;
        }

        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
       //     halconView1.ContextMenuStripHide();
         //   halconView1.Focus();
            fitLineTool.draw_roi();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }
        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            fitLineTool.IsFixture = cebxFixture.Checked;
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            fitLineTool.dispresult();
        }
    }
}
