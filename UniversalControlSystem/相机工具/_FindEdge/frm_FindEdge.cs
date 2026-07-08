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
    public partial class frm_FindEdge : Form
    {

        public frm_FindEdge()
        {
            InitializeComponent();
        }
        private void frm_FindEdge_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormClosing += frm_FitCircle_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.findEdgeTool.hWindowControl1 = hWindowControl1;

        }
        static frm_FindEdge frm;

        FindEdgeTool findEdgeTool = new FindEdgeTool();
        public delegate void HandledSetVal(FindEdgeTool findEdgeTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_FindEdge SingleShow(FindEdgeTool findEdgeTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_FindEdge(findEdgeTool, handleSetval);
            }
            return frm;
        }
        public frm_FindEdge(FindEdgeTool findEdgeTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(findEdgeTool);
            this.findEdgeTool.Image = findEdgeTool.Image;

            this.findEdgeTool.Circle = findEdgeTool.Circle;
            this.findEdgeTool.Rectangle1 = findEdgeTool.Rectangle1;
            this.findEdgeTool.Rectangle2 = findEdgeTool.Rectangle2;
            this.findEdgeTool.DicHomMat2D = findEdgeTool.DicHomMat2D;
            this.findEdgeTool.DicPhi = findEdgeTool.DicPhi;

            this.findEdgeTool.DicHomMat2D = findEdgeTool.DicHomMat2D;
            this.SetVal(ref this.findEdgeTool);

        }
        void DisplayVal(FindEdgeTool findEdgeTool)
        {
            try
            {
                Cancel();
                int nameIndex = findEdgeTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = findEdgeTool.Names.Substring(nameIndex + 1, findEdgeTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = findEdgeTool.Names;
                    tbxToolName.Text = findEdgeTool.Names;
                }
                cbxImage.Text = findEdgeTool.ImageName;//
                cbxFixture.Text = findEdgeTool.FixNames;
                cebxFixture.Checked = findEdgeTool.IsFixture;
                nudSigma.Value = Convert.ToDecimal(findEdgeTool.Sigma.D);
                nudThreshold.Value = Convert.ToDecimal(findEdgeTool.Threshold.I);

                if (findEdgeTool.Transition == 1)
                    rbntPostive.Checked = true;
                if (findEdgeTool.Transition == 2)
                    rbntNegative.Checked = true;
                if (findEdgeTool.Transition == 3)
                    rbntAll.Checked = true;
                if (findEdgeTool.Selcet == 1)
                    rbntSelectFirst.Checked = true;
                if (findEdgeTool.Selcet == 2)
                    rbntSelectLast.Checked = true;
                if (findEdgeTool.Selcet == 3)
                    rbntSelectAll.Checked = true;

                takBarRulenums.Value = findEdgeTool.Rulenums;
                takBarRuleWidth.Value = findEdgeTool.Rulewidth;
                takBarRuleHigh.Value = findEdgeTool.Ruleheiht;

                cebxFitLine.Checked = findEdgeTool.IsFitLine;
                cebxFitPoint.Checked = findEdgeTool.IsFitPoint;
                cebxRule.Checked = findEdgeTool.IsRule;

                nudHmeasure.Value = Convert.ToDecimal(findEdgeTool.Hmeasure.D);
                nudLmeasure.Value = Convert.ToDecimal(findEdgeTool.Lmeasure.D);
                cebxMeasure.Checked = findEdgeTool.IsMeasure;

                cbxImage.Items.Clear();
                if (findEdgeTool.Image != null)
                {
                    foreach (var item in findEdgeTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                //halconView1.DispImage((HObject)findEdgeTool.Image[cbxImage.Text], true);
              //  halconView1.FitImage();
                cbxFixture.Items.Clear();
                if (findEdgeTool.DicHomMat2D != null)
                {
                    foreach (var item in findEdgeTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();
            }
            catch { cbxImage.Items.Clear();
                if (findEdgeTool.Image != null)
                {
                    foreach (var item in findEdgeTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (findEdgeTool.DicHomMat2D != null)
                {
                    foreach (var item in findEdgeTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();
            }
        }

        void SetVal(ref FindEdgeTool findEdgeTool)
        {
            findEdgeTool.Names = ImageTool.Tool.找边测量.ToString() + "_" + tbxToolName.Text;
            findEdgeTool.ImageName = cbxImage.Text;
            findEdgeTool.FixNames = cbxFixture.Text;
            findEdgeTool.IsFixture = cebxFixture.Checked;
            findEdgeTool.Sigma = (double)nudSigma.Value;
            findEdgeTool.Threshold = (int)nudThreshold.Value;

            findEdgeTool.Rulenums = takBarRulenums.Value;
            findEdgeTool.Ruleheiht = takBarRuleHigh.Value;
            findEdgeTool.Rulewidth = takBarRuleWidth.Value;
            lblRulenums.Text = takBarRulenums.Value.ToString();
            lblRuleHigh.Text = takBarRuleHigh.Value.ToString();
            lblRuleWidth.Text = takBarRuleWidth.Value.ToString();

            findEdgeTool.IsRule = cebxRule.Checked;
            findEdgeTool.IsFitPoint = cebxFitPoint.Checked;
            findEdgeTool.IsFitLine = cebxFitLine.Checked;
            findEdgeTool.Lmeasure = (double)nudLmeasure.Value;
            findEdgeTool.Hmeasure = (double)nudHmeasure.Value;
            findEdgeTool.IsMeasure = cebxMeasure.Checked;

            if (rbntPostive.Checked)
                findEdgeTool.Transition = 1;
            if (rbntNegative.Checked)
                findEdgeTool.Transition = 2;
            if (rbntAll.Checked)
                findEdgeTool.Transition = 3;
            if (rbntSelectFirst.Checked)
                findEdgeTool.Selcet = 1;
            if (rbntSelectLast.Checked)
                findEdgeTool.Selcet = 2;
            if (rbntSelectAll.Checked)
                findEdgeTool.Selcet = 3;
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
                this.SetVal(ref this.findEdgeTool);
                this.Hide();
                frm = null;
                handleSetval(this.findEdgeTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.findEdgeTool);
            }
        }

   
     

        private void btn_run_Click(object sender, EventArgs e)
        {
            try { 
            long timer = findEdgeTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
           // halconView1.ToolLable2.Text = "FAIL";
      //      halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.findEdgeTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
             //   halconView1.ToolLable2.Text = "PASS";
             //   halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
          //  halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            DataGridView(dataGridView1, findEdgeTool.ResultRow1, findEdgeTool.ResultCol1, findEdgeTool.ResultRow2, findEdgeTool.ResultCol2);//结果输出
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
            this.findEdgeTool.Names = ImageTool.Tool.找圆测量.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   halconView1.DispImage((HObject)this.findEdgeTool.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
            findEdgeTool.ImageName = cbxImage.Text;
        }

        private void nudSigma_ValueChanged(object sender, EventArgs e)
        {
            findEdgeTool.Sigma = (double )nudSigma.Value;
            findEdgeTool.set_after();
        }

        private void nudThreshold_ValueChanged(object sender, EventArgs e)
        {
            findEdgeTool.Threshold = (int)nudThreshold.Value;
            findEdgeTool.set_after();
        }
        private void rbntPostive_CheckedChanged(object sender, EventArgs e)
        {
            findEdgeTool.Transition = 1;
            findEdgeTool.set_after();
        }
        private void rbntNegative_CheckedChanged(object sender, EventArgs e)
        {
            findEdgeTool.Transition = 2;
            findEdgeTool.set_after();
        }
        private void rbntAll_CheckedChanged(object sender, EventArgs e)
        {
            findEdgeTool.Transition = 3;
            findEdgeTool.set_after();
        }
        private void rbntSelectFirst_CheckedChanged(object sender, EventArgs e)
        {
            findEdgeTool.Selcet = 1;
            findEdgeTool.set_after();
        }
        private void rbntSelectLast_CheckedChanged(object sender, EventArgs e)
        {
            findEdgeTool.Selcet = 2;
            findEdgeTool.set_after();
        }
        private void rbntSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            findEdgeTool.Selcet = 3;
            findEdgeTool.set_after();
        }
        private void takBarRulenums_Scroll(object sender, EventArgs e)
        {
            findEdgeTool.Rulenums = takBarRulenums.Value;
            lblRulenums.Text = takBarRulenums.Value.ToString();
            findEdgeTool.set_after();
        }
        private void takBarRuleHigh_Scroll(object sender, EventArgs e)
        {
            findEdgeTool.Ruleheiht = takBarRuleHigh.Value;
            lblRuleHigh.Text = takBarRuleHigh.Value.ToString();
            findEdgeTool.set_after();
        }
        private void takBarRuleWidth_Scroll(object sender, EventArgs e)
        {
            findEdgeTool.Rulewidth = takBarRuleWidth.Value;
            lblRuleWidth.Text = takBarRuleWidth.Value.ToString();
            findEdgeTool.set_after();
        }
        private void cebxRule_CheckedChanged(object sender, EventArgs e)
        {
            findEdgeTool.IsRule = cebxRule.Checked;
            findEdgeTool.set_after();
        }
        private void cebxFitPoint_CheckedChanged(object sender, EventArgs e)
        {
            findEdgeTool.IsFitPoint = cebxFitPoint.Checked;
            findEdgeTool.set_after();
        }
        private void cebxFitLine_CheckedChanged(object sender, EventArgs e)
        {
            findEdgeTool.IsFitLine= cebxFitLine.Checked;
            findEdgeTool.set_after();
        }
        private void nudLmeasure_ValueChanged(object sender, EventArgs e)
        {
            findEdgeTool.Lmeasure = (double)nudLmeasure.Value;
            findEdgeTool.set_after();
        }
        private void nudHmeasure_ValueChanged(object sender, EventArgs e)
        {
            findEdgeTool.Hmeasure = (double)nudHmeasure.Value;
            findEdgeTool.set_after();
        }
        private void cebxMeasure_CheckedChanged(object sender, EventArgs e)
        {
            findEdgeTool.IsMeasure = cebxMeasure.Checked;
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
            findEdgeTool.FixNames = cbxFixture.Text;
        }

        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
         //   halconView1.ContextMenuStripHide();
          //  halconView1.Focus();
            findEdgeTool.draw_roi();
            takBarRuleHigh.Scroll -= new EventHandler(takBarRuleHigh_Scroll);
            takBarRuleHigh.Value = Convert.ToInt32(findEdgeTool.Ruleheiht.D);
            lblRuleHigh.Text = takBarRuleHigh.Value.ToString();
            takBarRuleHigh.Scroll += new EventHandler(takBarRuleHigh_Scroll);
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }
        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            findEdgeTool.IsFixture = cebxFixture.Checked;
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            findEdgeTool.dispresult();
        }
    }
}
