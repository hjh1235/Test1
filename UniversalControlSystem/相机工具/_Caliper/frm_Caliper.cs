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
    public partial class frm_Caliper : Form
    {

        public frm_Caliper()
        {
            InitializeComponent();
        }

        private void frm_Caliper_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormClosing += frm_Caliper_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            string[] roi = new string[] { CaliperTool.Roi.方向矩形.ToString(), CaliperTool.Roi.圆.ToString() };
            cbxRoi.Items.AddRange(roi);
            this.caliperTool.hWindowControl1 = hWindowControl1;
            this.TopMost = false;
        }
        static frm_Caliper frm;
        CaliperTool caliperTool = new CaliperTool();
        public delegate void HandledSetVal(CaliperTool caliperTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_Caliper SingleShow(CaliperTool caliperTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_Caliper(caliperTool, handleSetval);
            }
            return frm;
        }


        public frm_Caliper(CaliperTool caliperTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(caliperTool);
            this.caliperTool.Image = caliperTool.Image;
            this.caliperTool.Circle = caliperTool.Circle;
            this.caliperTool.Rectangle1 = caliperTool.Rectangle1;
            this.caliperTool.Rectangle2 = caliperTool.Rectangle2;
            this.caliperTool.DicHomMat2D = caliperTool.DicHomMat2D;
            this.caliperTool.DicPhi = caliperTool.DicPhi;
            this.SetVal(ref this.caliperTool);
        }
        void DisplayVal(CaliperTool caliperTool)
        {
            try
            {
                Cancel();
                int nameIndex = caliperTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = caliperTool.Names.Substring(nameIndex + 1, caliperTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = caliperTool.Names;
                    tbxToolName.Text = caliperTool.Names;
                }
                cbxImage.Text = caliperTool.ImageName;//
                cbxFixture.Text = caliperTool.FixNames;
                nudSigma.Value = Convert.ToDecimal(caliperTool.Sigma.I);
                nudThreshold.Value = Convert.ToDecimal(caliperTool.Threshold.I);
                cbxRoi.Text = caliperTool.SetdrawShape;

                cebxFixture.Checked = caliperTool.IsFixture;
                cebxEdge.Checked = caliperTool.IsEdge;
                cbxInterpolation.Text = caliperTool.Interpolation;
                nudScale.Value = Convert.ToDecimal(caliperTool.Scale.D);
                if (caliperTool.Transition == 1)
                    rbntPostive.Checked = true;
                if (caliperTool.Transition == 2)
                    rbntNegative.Checked = true;
                if (caliperTool.Transition == 3)
                    rbntAll.Checked = true;
                if (caliperTool.Selcet == 1)
                    rbntSelectFirst.Checked = true;
                if (caliperTool.Selcet == 2)
                    rbntSelectLast.Checked = true;
                if (caliperTool.Selcet == 3)
                    rbntSelectAll.Checked = true;


                cebxRule.Checked = caliperTool.IsRule;
                cebxLine.Checked = caliperTool.IsLine;
                cebxCross.Checked = caliperTool.IsCross;

                nudHmeasure.Value = Convert.ToDecimal(caliperTool.Hmeasure.D);
                nudLmeasure.Value = Convert.ToDecimal(caliperTool.Lmeasure.D);
                cebxMeasure.Checked = caliperTool.IsMeasure;

                MeasureDisp(ref caliperTool);

                cbxImage.Items.Clear();
                if (caliperTool.Image != null)
                {
                    foreach (var item in caliperTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
               // halconView1.DispImage((HObject)caliperTool.Image[cbxImage.Text], true);
               // halconView1.FitImage();
                cbxFixture.Items.Clear();
                if (caliperTool.DicHomMat2D != null)
                {
                    foreach (var item in caliperTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();
            }
            catch {
                cbxImage.Items.Clear();
                if (caliperTool.Image != null)
                {
                    foreach (var item in caliperTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (caliperTool.DicHomMat2D != null)
                {
                    foreach (var item in caliperTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                } Register();
            }
        }

        void SetVal(ref CaliperTool caliperTool)
        {

            caliperTool.Names = ImageTool.Tool.卡尺测量.ToString() + "_" + tbxToolName.Text;
                caliperTool.ImageName = cbxImage.Text;
                caliperTool.FixNames = cbxFixture.Text;
                caliperTool.Sigma = (int)nudSigma.Value;
                caliperTool.Threshold = (int)nudThreshold.Value;
                caliperTool.SetdrawShape = cbxRoi.Text;

                caliperTool.IsRule = cebxRule.Checked;
                caliperTool.IsLine = cebxLine.Checked;
                caliperTool.IsCross = cebxCross.Checked;

                caliperTool.Lmeasure = (double)nudLmeasure.Value;
                caliperTool.Hmeasure = (double)nudHmeasure.Value;
                caliperTool.IsMeasure = cebxMeasure.Checked;

                caliperTool.IsFixture = cebxFixture.Checked;
                caliperTool.IsEdge = cebxEdge.Checked;
                caliperTool.Interpolation = cbxInterpolation.Text;

                caliperTool.Scale = (double)nudScale.Value;

                MeasureSet();

                if (rbntPostive.Checked)
                    caliperTool.Transition = 1;
                if (rbntNegative.Checked)
                    caliperTool.Transition = 2;
                if (rbntAll.Checked)
                    caliperTool.Transition = 3;
                if (rbntSelectFirst.Checked)
                    caliperTool.Selcet = 1;
                if (rbntSelectLast.Checked)
                    caliperTool.Selcet = 2;
                if (rbntSelectAll.Checked)
                    caliperTool.Selcet = 3;
         
  
        }
        void Cancel()
        {
    
            nudSigma.ValueChanged -= new EventHandler(nudSigma_ValueChanged);
            nudThreshold.ValueChanged -= new EventHandler(nudThreshold_ValueChanged);
            rbntAll.CheckedChanged -= new EventHandler(rbntAll_CheckedChanged);
            rbntNegative.CheckedChanged -= new EventHandler(rbntNegative_CheckedChanged);
            rbntPostive.CheckedChanged -= new EventHandler(rbntPostive_CheckedChanged);
            rbntSelectAll.CheckedChanged -= new EventHandler(rbntSelectAll_CheckedChanged);
            rbntSelectFirst.CheckedChanged -= new EventHandler(rbntSelectFirst_CheckedChanged);
            rbntSelectLast.CheckedChanged -= new EventHandler(rbntSelectLast_CheckedChanged);

            cebxEdge.CheckedChanged -= new EventHandler(cebxEdge_CheckedChanged);
            cbxInterpolation.SelectedIndexChanged -= new EventHandler(cbxInterpolation_SelectedIndexChanged);
            cbxSelectMeasure.SelectedIndexChanged -= new EventHandler(cbxSelectMeasure_SelectedIndexChanged);

        
            cebxRule.CheckedChanged -= new EventHandler(cebxRule_CheckedChanged);
            cebxCross.CheckedChanged -= new EventHandler(cebxCross_CheckedChanged);
            cebxLine.CheckedChanged -= new EventHandler(cebxLine_CheckedChanged);

            nudHmeasure.ValueChanged -= new EventHandler(nudHmeasure_ValueChanged);
            nudLmeasure.ValueChanged -= new EventHandler(nudLmeasure_ValueChanged);
            cebxMeasure.CheckedChanged -= new EventHandler(cebxMeasure_CheckedChanged);
            nudScale.ValueChanged -= new EventHandler(nudScale_ValueChanged);
   
        }
        void Register()
        {
          
            nudSigma.ValueChanged += new EventHandler(nudSigma_ValueChanged);
            nudThreshold.ValueChanged += new EventHandler(nudThreshold_ValueChanged);
            rbntAll.CheckedChanged += new EventHandler(rbntAll_CheckedChanged);
            rbntNegative.CheckedChanged += new EventHandler(rbntNegative_CheckedChanged);
            rbntPostive.CheckedChanged += new EventHandler(rbntPostive_CheckedChanged);
            rbntSelectAll.CheckedChanged += new EventHandler(rbntSelectAll_CheckedChanged);
            rbntSelectFirst.CheckedChanged += new EventHandler(rbntSelectFirst_CheckedChanged);
            rbntSelectLast.CheckedChanged += new EventHandler(rbntSelectLast_CheckedChanged);
            cebxEdge.CheckedChanged += new EventHandler(cebxEdge_CheckedChanged);
            cbxInterpolation.SelectedIndexChanged   += new EventHandler(cbxInterpolation_SelectedIndexChanged);
            cbxSelectMeasure.SelectedIndexChanged += new EventHandler(cbxSelectMeasure_SelectedIndexChanged);
            cebxRule.CheckedChanged += new EventHandler(cebxRule_CheckedChanged);
            cebxCross.CheckedChanged += new EventHandler(cebxCross_CheckedChanged);
            cebxLine.CheckedChanged += new EventHandler(cebxLine_CheckedChanged);
            nudHmeasure.ValueChanged += new EventHandler(nudHmeasure_ValueChanged);
            nudLmeasure.ValueChanged += new EventHandler(nudLmeasure_ValueChanged);
            cebxMeasure.CheckedChanged += new EventHandler(cebxMeasure_CheckedChanged);
            nudScale.ValueChanged += new EventHandler(nudScale_ValueChanged);
        }                                                                                 
        private void btn_sure_Click(object sender, EventArgs e)
        {
            try
              {
                this.SetVal(ref this.caliperTool);
                this.Hide();
                frm = null;
                handleSetval(this.caliperTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.caliperTool);
            }
        }
         private void btn_run_Click(object sender, EventArgs e)
        {
            try { 
            long timer = caliperTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
            //halconView1.ToolLable2.Text = "FAIL";
            //halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.caliperTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
               // halconView1.ToolLable2.Text = "PASS";
              //  halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
          //  halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            if (!caliperTool.IsEdge)
                DataGridView1(caliperTool.RowEdge1, caliperTool.ColumnEdge1, caliperTool.Amplitude1, caliperTool.Distance);
            else
               DataGridView2(caliperTool.RowEdge1, caliperTool.ColumnEdge1, caliperTool.Amplitude1,
                          caliperTool.RowEdge2, caliperTool.ColumnEdge2, caliperTool.Amplitude2,caliperTool.InterDistance, caliperTool.IntraDistance);
            }
            catch
            {
                MessageBox.Show("结果输出异常,查看设定参数！");
            }
        }

         void frm_Caliper_FormClosing(object sender, FormClosingEventArgs e)
        {
             frm = null;
        }

        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.caliperTool.Names = ImageTool.Tool.卡尺测量.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  halconView1.DispImage((HObject)this.caliperTool.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
            caliperTool.ImageName = cbxImage.Text;
        }
        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            caliperTool.IsFixture = cebxFixture.Checked;
        }

        private void nudSigma_ValueChanged(object sender, EventArgs e)
        {
            caliperTool.Sigma = (int)nudSigma.Value;
            caliperTool.set_after();
        }

        private void nudThreshold_ValueChanged(object sender, EventArgs e)
        {
            caliperTool.Threshold = (int)nudThreshold.Value;
            caliperTool.set_after();
        }
        private void rbntPostive_CheckedChanged(object sender, EventArgs e)
        {
            caliperTool.Transition = 1;
            caliperTool.set_after();
        }
        private void rbntNegative_CheckedChanged(object sender, EventArgs e)
        {
            caliperTool.Transition = 2;
            caliperTool.set_after();
        }
        private void rbntAll_CheckedChanged(object sender, EventArgs e)
        {
            caliperTool.Transition = 3;
            caliperTool.set_after();
        }
        private void rbntSelectFirst_CheckedChanged(object sender, EventArgs e)
        {
            caliperTool.Selcet = 1;
            caliperTool.set_after();
        }
        private void rbntSelectLast_CheckedChanged(object sender, EventArgs e)
        {
            caliperTool.Selcet = 2;
            caliperTool.set_after();
        }
        private void rbntSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            caliperTool.Selcet = 3;
            caliperTool.set_after();
        }
        private void nudLmeasure_ValueChanged(object sender, EventArgs e)
        {
            caliperTool.Lmeasure = (double)nudLmeasure.Value;
            caliperTool.set_after();
        }
        private void nudHmeasure_ValueChanged(object sender, EventArgs e)
        {
            caliperTool.Hmeasure = (double)nudHmeasure.Value;
            caliperTool.set_after();
        }
        private void cebxMeasure_CheckedChanged(object sender, EventArgs e)
        {
            caliperTool.IsMeasure = cebxMeasure.Checked;
            caliperTool.set_after();
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
            caliperTool.FixNames = cbxFixture.Text;
        }
        private void cbxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.caliperTool.SetdrawShape = cbxRoi.Text;
        }

        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            if (cbxRoi.Text == CaliperTool.Roi.方向矩形.ToString())
                caliperTool.SetdrawShape = CaliperTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == CaliperTool.Roi.矩形.ToString())
                caliperTool.SetdrawShape = CaliperTool.Roi.矩形.ToString();
            if (cbxRoi.Text == CaliperTool.Roi.圆.ToString())
                caliperTool.SetdrawShape = CaliperTool.Roi.圆.ToString();
           // halconView1.ContextMenuStripHide();
          //  halconView1.Focus();
            caliperTool.draw_roi();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void cebxEdge_CheckedChanged(object sender, EventArgs e)
        {
            caliperTool.IsEdge = cebxEdge.Checked;
            caliperTool.set_after();
        }

        private void cbxInterpolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            caliperTool.Interpolation = cbxInterpolation.Text;
            caliperTool.set_after();
        }

        private void cbxSelectMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            MeasureSet();
            caliperTool.set_after();
        }
        void MeasureSet()
        {
            if (cbxSelectMeasure.Text.Equals("距离"))
                this.caliperTool.SelectMeasure = 0;
            else if (cbxSelectMeasure.Text.Equals("宽度"))
                this.caliperTool.SelectMeasure = 1;
            else if (cbxSelectMeasure.Text.Equals("Row"))
                this.caliperTool.SelectMeasure = 2;
            else if (cbxSelectMeasure.Text.Equals("Col"))
                this.caliperTool.SelectMeasure = 3;
        }
        void MeasureDisp(ref CaliperTool caliperTool)
        {
            if (caliperTool.SelectMeasure == 0)
                cbxSelectMeasure.Text = "距离";
            else if (caliperTool.SelectMeasure == 1)
               cbxSelectMeasure.Text = "宽度";
            else if (caliperTool.SelectMeasure == 2)
               cbxSelectMeasure.Text = "Row";
            else if (caliperTool.SelectMeasure == 3)
                cbxSelectMeasure.Text = "Col";
        }

        private void cebxRule_CheckedChanged(object sender, EventArgs e)
        {
            caliperTool.IsRule = cebxRule.Checked;
            caliperTool.set_after();
        }

        private void cebxCross_CheckedChanged(object sender, EventArgs e)
        {
            caliperTool.IsCross = cebxCross.Checked;
            caliperTool.set_after();
        }

        private void cebxLine_CheckedChanged(object sender, EventArgs e)
        {
            caliperTool.IsLine = cebxLine.Checked;
            caliperTool.set_after();
        }

        public void DataGridView1(HTuple result_row, HTuple result_col, HTuple result_Amplitude, HTuple result_Dis_Measure)
        {
            try
            {
                string str_Row, str_Col, str_Amplitude, str_Dis_Measure;
                dataGridView1.Columns.Clear();//
                dataGridView1.Columns.Add("", "Row");//
                dataGridView1.Columns.Add("", "Col");//
                dataGridView1.Columns.Add("", "幅度");//
                dataGridView1.Columns.Add("", "距离");//
                dataGridView1.ColumnHeadersHeight = 20;

                for (int i = 0; i < result_row.Length; i++)
                {
                    dataGridView1.Rows.Add(1);//加载row
                    //row表头ID
                    dataGridView1.Rows[i].HeaderCell.Value = i.ToString();//row表头
                    //表格赋值
                    str_Row = result_row.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(0)
                    str_Col = result_col.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(1)
                    str_Amplitude = result_Amplitude.TupleSelect(i).TupleString("0.3f");//表格赋值col(2)

                    dataGridView1.Rows[i].Cells[0].Value = str_Row; ;//表格赋值col(0)
                    dataGridView1.Rows[i].Cells[1].Value = str_Col; ;//表格赋值col(1)
                    dataGridView1.Rows[i].Cells[2].Value = str_Amplitude; ;//表格赋值col(2)

                }
                for (int i = 0; i < result_Dis_Measure.Length; i++)
                {
                    str_Dis_Measure = result_Dis_Measure.TupleSelect(i).TupleString("0.3f");//表格赋值col(2)
                    dataGridView1.Rows[i].Cells[3].Value = str_Dis_Measure; ;//表格赋值col(3)
                }
            }
            catch
            { }

        }
        public void DataGridView2(HTuple result_row1, HTuple result_col1, HTuple result_Amplitude1, HTuple result_row2, HTuple result_col2, HTuple result_Amplitude2, HTuple result_Dis_Measure1, HTuple result_Dis_Measure2)
        {
            try
            {
                string str_Row1, str_Col1, str_Amplitude1, str_Row2, str_Col2, str_Amplitude2, str_Dis_Measure1, str_Dis_Measure2;
                dataGridView1.Columns.Clear();//
                dataGridView1.Columns.Add("", "Row1");//
                dataGridView1.Columns.Add("", "Col1");//
                dataGridView1.Columns.Add("", "幅度1");//
                dataGridView1.Columns.Add("", "Row2");//
                dataGridView1.Columns.Add("", "Col2");//
                dataGridView1.Columns.Add("", "幅度2");//
                dataGridView1.Columns.Add("", "宽度");//
                dataGridView1.Columns.Add("", "距离");//
                dataGridView1.ColumnHeadersHeight = 20;

                for (int i = 0; i < result_row1.Length; i++)
                {
                    dataGridView1.Rows.Add(1);//加载row
                    //row表头ID
                    dataGridView1.Rows[i].HeaderCell.Value = i.ToString();//row表头
                    //表格赋值
                    str_Row1 = result_row1.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(0)
                    str_Col1 = result_col1.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(1)
                    str_Amplitude1 = result_Amplitude1.TupleSelect(i).TupleString("0.3f");//表格赋值col(2)

                    str_Row2 = result_row2.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(3)
                    str_Col2 = result_col2.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(4)
                    str_Amplitude2 = result_Amplitude2.TupleSelect(i).TupleString("0.3f");//表格赋值col(5)

                    dataGridView1.Rows[i].Cells[0].Value = str_Row1; ;//表格赋值col(0)
                    dataGridView1.Rows[i].Cells[1].Value = str_Col1; ;//表格赋值col(1)
                    dataGridView1.Rows[i].Cells[2].Value = str_Amplitude1; ;//表格赋值col(2)
                    dataGridView1.Rows[i].Cells[3].Value = str_Row2; ;//表格赋值col(3)
                    dataGridView1.Rows[i].Cells[4].Value = str_Col2; ;//表格赋值col(4)
                    dataGridView1.Rows[i].Cells[5].Value = str_Amplitude2; ;//表格赋值col(5)

                }
                for (int i = 0; i < result_Dis_Measure1.Length; i++)
                {
                    str_Dis_Measure1 = result_Dis_Measure1.TupleSelect(i).TupleString("0.3f");//表格赋值col(6)
                    dataGridView1.Rows[i].Cells[6].Value = str_Dis_Measure1; ;//表格赋值col(6)

                }
                for (int i = 0; i < result_Dis_Measure2.Length; i++)
                {
                    str_Dis_Measure2 = result_Dis_Measure2.TupleSelect(i).TupleString("0.3f");//表格赋值col(7)
                    dataGridView1.Rows[i].Cells[7].Value = str_Dis_Measure2; ;//表格赋值col(7)
                }
            }
            catch
            {     }

        }

        private void nudScale_ValueChanged(object sender, EventArgs e)
        {
            caliperTool.Scale = (double)nudScale.Value;
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            caliperTool.dispresult() ;
        }
    }
}
