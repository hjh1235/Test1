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
    public partial class frm_FindRectangle2 : Form
    {
        public frm_FindRectangle2()
        {
            InitializeComponent();
        }
        private void frm_FindCorner_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormClosing += frm_FindCorner_FormClosing;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            string[] roi = new string[] { ImageTool.Roi.方向矩形.ToString() };
            cbxRoi.Items.AddRange(roi);
            this.findRectangle2.hWindowControl1 = hWindowControl1;

        }
         void frm_FindCorner_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
        static frm_FindRectangle2 frm;
        FindRectangle2Tool findRectangle2 = new FindRectangle2Tool();
        public delegate void HandledSetVal(FindRectangle2Tool findRectangle2);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_FindRectangle2 SingleShow(FindRectangle2Tool findRectangle2, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_FindRectangle2(findRectangle2, handleSetval);
            }
            return frm;
        }

        public frm_FindRectangle2(FindRectangle2Tool findRectangle2, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(findRectangle2);
            this.findRectangle2.Image = findRectangle2.Image;
            this.findRectangle2.Circle = findRectangle2.Circle;
            this.findRectangle2.Rectangle1 = findRectangle2.Rectangle1;
            this.findRectangle2.Rectangle2 = findRectangle2.Rectangle2;
            this.findRectangle2.DicHomMat2D = findRectangle2.DicHomMat2D;
            this.findRectangle2.DicPhi = findRectangle2.DicPhi;
            this.SetVal(ref this.findRectangle2);
        }

        void DisplayVal(FindRectangle2Tool findRectangle2)
        {
            try
            {
                Cancel();
                int nameIndex = findRectangle2.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = findRectangle2.Names.Substring(nameIndex + 1, findRectangle2.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = findRectangle2.Names;
                    tbxToolName.Text = findRectangle2.Names;
                }
                cbxImage.Text = findRectangle2.ImageName;//
                cbxFixture.Text = findRectangle2.FixNames;
                nudSigma.Value = Convert.ToDecimal(findRectangle2.Sigma.D);
                nudThreshold.Value = Convert.ToDecimal(findRectangle2.Threshold.I);
                cbxRoi.Text = findRectangle2.SetdrawShape;
                cebxFixture.Checked = findRectangle2.IsFixture;
               

                nudScale.Value = Convert.ToDecimal(findRectangle2.Scale.D);

                if (findRectangle2.Transition == 1)
                    rbntPostive.Checked = true;
                if (findRectangle2.Transition == 2)
                    rbntNegative.Checked = true;
                if (findRectangle2.Transition == 3)
                    rbntAll.Checked = true;
                if (findRectangle2.Selcet == 1)
                    rbntSelectFirst.Checked = true;
                if (findRectangle2.Selcet == 2)
                    rbntSelectLast.Checked = true;
                if (findRectangle2.Selcet == 3)
                    rbntSelectAll.Checked = true;

                cebxRule.Checked = findRectangle2.IsRule;
                cebxCross.Checked = findRectangle2.IsFitPoint;
                cebxFitRectangle2.Checked = findRectangle2.IsFitRectangle2;


                takBarRulenums.Value = findRectangle2.RuleNums;
                takBarRuleWidth.Value = findRectangle2.RuleWidth;
                takBarRuleHigh.Value = findRectangle2.RuleHeiht;

                nudLowLen1.Value = Convert.ToDecimal(findRectangle2.Lowlen1.D);
                nudHigLen1.Value = Convert.ToDecimal(findRectangle2.Higlen1.D);
                cebxLen1.Checked = findRectangle2.IsLen1;

                nudLowLen2.Value = Convert.ToDecimal(findRectangle2.Lowlen2.D);
                nudHigLen2.Value = Convert.ToDecimal(findRectangle2.Higlen2.D);
                cebxLen2.Checked = findRectangle2.IsLen2;

                lblRulenums.Text = takBarRulenums.Value.ToString();
                lblRuleHigh.Text = takBarRuleHigh.Value.ToString();
                lblRuleWidth.Text = takBarRuleWidth.Value.ToString();

                cbxImage.Items.Clear();
                if (findRectangle2.Image != null)
                {
                    foreach (var item in findRectangle2.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                 
                }
              //  halconView1.DispImage((HObject)findRectangle2.Image[cbxImage.Text], true);
             //   halconView1.FitImage();
                cbxFixture.Items.Clear();
                if (findRectangle2.DicHomMat2D != null)
                {
                    foreach (var item in findRectangle2.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();
            }
            catch
            {
                cbxImage.Items.Clear();
                if (findRectangle2.Image != null)
                {
                    foreach (var item in findRectangle2.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (findRectangle2.DicHomMat2D != null)
                {
                    foreach (var item in findRectangle2.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                } Register();
            }
        }

        void SetVal(ref FindRectangle2Tool findRectangle2)
        {
            findRectangle2.Names = ImageTool.Tool.找方向矩形测量.ToString() + "_" + tbxToolName.Text;
            findRectangle2.ImageName = cbxImage.Text;
            findRectangle2.FixNames = cbxFixture.Text;
            findRectangle2.Sigma = (int)nudSigma.Value;
            findRectangle2.Threshold = (int)nudThreshold.Value;

            findRectangle2.RuleNums = takBarRulenums.Value;
            findRectangle2.RuleHeiht = takBarRuleHigh.Value;
            findRectangle2.RuleWidth = takBarRuleWidth.Value;

            findRectangle2.SetdrawShape = cbxRoi.Text;

            findRectangle2.IsRule = cebxRule.Checked;
            findRectangle2.IsFitPoint = cebxCross.Checked;
            findRectangle2.IsFitRectangle2 = cebxFitRectangle2.Checked;

            findRectangle2.IsFixture = cebxFixture.Checked;
            if (rbntPostive.Checked)
                findRectangle2.Transition = 1;
            if (rbntNegative.Checked)
                findRectangle2.Transition = 2;
            if (rbntAll.Checked)
                findRectangle2.Transition = 3;
            if (rbntSelectFirst.Checked)
                findRectangle2.Selcet = 1;
            if (rbntSelectLast.Checked)
                findRectangle2.Selcet = 2;
            if (rbntSelectAll.Checked)
                findRectangle2.Selcet = 3;



            findRectangle2.Scale = (double)nudScale.Value;
            findRectangle2.Lowlen1 = (double)nudLowLen1.Value;
            findRectangle2.Higlen1 = (double)nudHigLen1.Value;
            findRectangle2.IsLen1 = cebxLen1.Checked;
            findRectangle2.Lowlen2 = (double)nudLowLen2.Value;
            findRectangle2.Higlen2 = (double)nudHigLen2.Value;
            findRectangle2.IsLen2 = cebxLen2.Checked;


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
            cebxRule.CheckedChanged -= new EventHandler(cebxRule_CheckedChanged);
            cebxCross.CheckedChanged -= new EventHandler(cebxCross_CheckedChanged);
            cebxFitRectangle2.CheckedChanged -= new EventHandler(cebxFitRectangle2_CheckedChanged);
            nudScale.ValueChanged += new EventHandler(nudScale_ValueChanged);
            cebxFixture.CheckedChanged -= new EventHandler(cebxFixture_CheckedChanged);
        }
        void Register()
        {
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
            cebxRule.CheckedChanged += new EventHandler(cebxRule_CheckedChanged);
            cebxCross.CheckedChanged += new EventHandler(cebxCross_CheckedChanged);
            cebxFitRectangle2.CheckedChanged += new EventHandler(cebxFitRectangle2_CheckedChanged);
            nudScale.ValueChanged += new EventHandler(nudScale_ValueChanged);
            cebxFixture.CheckedChanged += new EventHandler(cebxFixture_CheckedChanged);
        }                                                                                 


        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            findRectangle2.Names = ImageTool.Tool.找方向矩形测量.ToString() + "_" + tbxToolName.Text;
        }
        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
           // halconView1.DispImage((HObject)this.findRectangle2.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
            findRectangle2.ImageName = cbxImage.Text;
         }

        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
            findRectangle2.FixNames = cbxFixture.Text;
        }
        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            findRectangle2.IsFixture = cebxFixture.Checked;
   
        }

        private void nudSigma_ValueChanged(object sender, EventArgs e)
        {
            findRectangle2.Sigma = (double)nudSigma.Value;
        
        }

        private void nudThreshold_ValueChanged(object sender, EventArgs e)
        {
            findRectangle2.Threshold = (int)nudThreshold.Value;
        }

        private void rbntPostive_CheckedChanged(object sender, EventArgs e)
        {
            if (rbntPostive.Checked)
                findRectangle2.Transition = 1;
       }

        private void rbntNegative_CheckedChanged(object sender, EventArgs e)
        {
            if (rbntNegative.Checked)
                findRectangle2.Transition = 2;
        }  
        private void rbntAll_CheckedChanged(object sender, EventArgs e)
        {
               if (rbntAll.Checked)
                findRectangle2.Transition = 3;
        }
       private void rbntSelectFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (rbntSelectFirst.Checked)
                findRectangle2.Selcet = 1;
        }

        private void rbntSelectLast_CheckedChanged(object sender, EventArgs e)
        {
            if (rbntSelectLast.Checked)
                findRectangle2.Selcet = 2;
        }

        private void rbntSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbntSelectAll.Checked)
                findRectangle2.Selcet = 3;
        }
        private void takBarRulenums_Scroll(object sender, EventArgs e)
        {
            findRectangle2.RuleNums = takBarRulenums.Value;
            lblRulenums.Text = takBarRulenums.Value.ToString();
            findRectangle2.set_after();
        }
        private void takBarRuleHigh_Scroll(object sender, EventArgs e)
        {
            findRectangle2.RuleHeiht = takBarRuleHigh.Value;
            lblRuleHigh.Text = takBarRuleHigh.Value.ToString();
            findRectangle2.set_after();
        }
        private void takBarRuleWidth_Scroll(object sender, EventArgs e)
        {
            findRectangle2.RuleWidth = takBarRuleWidth.Value;
            lblRuleWidth.Text = takBarRuleWidth.Value.ToString();
            findRectangle2.set_after();
        }
     
        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            if (cbxRoi.Text == ImageTool.Roi.方向矩形.ToString())
                findRectangle2.SetdrawShape = ImageTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == CaliperTool.Roi.矩形.ToString())
                findRectangle2.SetdrawShape = CaliperTool.Roi.矩形.ToString();
            if (cbxRoi.Text == ImageTool.Roi.圆.ToString())
                findRectangle2.SetdrawShape = ImageTool.Roi.圆.ToString();
            //halconView1.ContextMenuStripHide();
            //halconView1.Focus();
            findRectangle2.draw_roi();
        }
        private void cbxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            findRectangle2.SetdrawShape = cbxRoi.Text;
        }
        private void cebxRule_CheckedChanged(object sender, EventArgs e)
        {
            findRectangle2.IsRule = cebxRule.Checked;
        }
        private void cebxCross_CheckedChanged(object sender, EventArgs e)
        {
            findRectangle2.IsFitPoint = cebxCross.Checked;
        }
        private void cebxFitRectangle2_CheckedChanged(object sender, EventArgs e)
        {
            findRectangle2.IsFitRectangle2 = cebxFitRectangle2.Checked;
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            try { 
            long timer = findRectangle2.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
         //   halconView1.ToolLable2.Text = "FAIL";
          //  halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.findRectangle2.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
              //  halconView1.ToolLable2.Text = "PASS";
              //  halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
           // halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            DataGridView(dataGridView1, findRectangle2.ResultRow, findRectangle2.ResultColumn,findRectangle2.ResultAngle,
                findRectangle2.ResultLen1, findRectangle2.ResultLen2);
          
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
                this.SetVal(ref this.findRectangle2);
                this.Hide();
                frm = null;
                handleSetval(this.findRectangle2);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.findRectangle2);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
            
        }

        private void DataGridView(DataGridView dataGridView,  HTuple result_row, HTuple result_col, HTuple result_angle, HTuple result_len1, HTuple result_len2)
        {
            try
            {
                string  str_Row, str_Col,str_angle, str_len1, str_len2,str_hight, str_with;
                dataGridView.Columns.Clear();//
                dataGridView.Columns.Add("", "ResultRow");//
                dataGridView.Columns.Add("", "ResultCol");//
                dataGridView.Columns.Add("", "ResultAngle");//
                dataGridView.Columns.Add("", "ResultLen1");//
                dataGridView.Columns.Add("", "ResultLen2");//
                          
                for (int i = 0; i < result_row.Length; i++)
                {
                    dataGridView.Rows.Add(1);//加载row
                    ;//row表头ID
                    dataGridView.Rows[i].HeaderCell.Value = i.ToString();//row表头
                    ;//表格赋值
                    str_Row = result_row.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(0)
                    str_Col = result_col.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(1)
                    str_angle = result_angle.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(2)
                    str_len1 = result_len1.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(2)
                    str_len2 = result_len2.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(2)
                  

                    dataGridView.Rows[i].Cells[0].Value = str_Row; ;//表格赋值col(0)
                    dataGridView.Rows[i].Cells[1].Value = str_Col; ;//表格赋值col(1)
                    dataGridView.Rows[i].Cells[2].Value = str_angle; ;//表格赋值col(2)
                    dataGridView.Rows[i].Cells[3].Value = str_len1; ;//表格赋值col(3)
                    dataGridView.Rows[i].Cells[4].Value = str_len2; ;//表格赋值col(4)
                   
                }
            }
            catch { }
        }
        private void nudScale_ValueChanged(object sender, EventArgs e)
        {
            findRectangle2.Scale = (double)nudScale.Value;
        }

        private void nudLowLen1_ValueChanged(object sender, EventArgs e)
        {
            findRectangle2.Lowlen1 = (double)nudLowLen1.Value;
         
        }

        private void nudHigLen1_ValueChanged(object sender, EventArgs e)
        {
            findRectangle2.Higlen1 = (double)nudHigLen1.Value;
    
        }

        private void cebxLen1_CheckedChanged(object sender, EventArgs e)
        {
            findRectangle2.IsLen1 = cebxLen1.Checked;
        }

        private void nudLowLen2_ValueChanged(object sender, EventArgs e)
        {
            findRectangle2.Lowlen2 = (double)nudLowLen2.Value;
            
        }

        private void nudHigLen2_ValueChanged(object sender, EventArgs e)
        {
            findRectangle2.Higlen2 = (double)nudHigLen2.Value;
           
        }

        private void cebxLen2_CheckedChanged(object sender, EventArgs e)
        {
            findRectangle2.IsLen2 = cebxLen2.Checked;
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            findRectangle2.dispresult();
          
        }
    }
}
