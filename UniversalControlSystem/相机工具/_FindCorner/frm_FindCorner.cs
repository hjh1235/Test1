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
    public partial class frm_FindCorner : Form
    {
        public frm_FindCorner()
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
            string[] roi = new string[] { CaliperTool.Roi.方向矩形.ToString() };
            cbxRoi.Items.AddRange(roi);
            this.cornerTool.hWindowControl1 = hWindowControl1;
          
        }
         void frm_FindCorner_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
        static frm_FindCorner frm;
        FindCornerTool cornerTool = new FindCornerTool();
        public delegate void HandledSetVal(FindCornerTool cornerTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_FindCorner SingleShow(FindCornerTool cornerTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_FindCorner(cornerTool, handleSetval);
            }
            return frm;
        }

        public frm_FindCorner(FindCornerTool cornerTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(cornerTool);
            this.cornerTool.Image = cornerTool.Image;
            this.cornerTool.Circle = cornerTool.Circle;
            this.cornerTool.Rectangle1 = cornerTool.Rectangle1;
            this.cornerTool.Rectangle2 = cornerTool.Rectangle2;
            this.cornerTool.DicHomMat2D = cornerTool.DicHomMat2D;
            this.cornerTool.DicPhi = cornerTool.DicPhi;
            this.SetVal(ref this.cornerTool);
        }

        void DisplayVal(FindCornerTool cornerTool)
        {
            try
            {
                Cancel();
                int nameIndex = cornerTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = cornerTool.Names.Substring(nameIndex + 1, cornerTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = cornerTool.Names;
                    tbxToolName.Text = cornerTool.Names;
                }
                cbxImage.Text = cornerTool.ImageName;//
                cbxFixture.Text = cornerTool.FixNames;
                nudSigma.Value = Convert.ToDecimal(cornerTool.Sigma.D);
                nudThreshold.Value = Convert.ToDecimal(cornerTool.Threshold.I);
                cbxRoi.Text = cornerTool.SetdrawShape;
                cebxFixture.Checked = cornerTool.IsFixture;
                //cebxEdge.Checked = cornerTool.IsEdge;
                //cbxInterpolation.Text = cornerTool.Interpolation;
                //nudScale.Value = Convert.ToDecimal(cornerTool.Scale.D);
                if (cornerTool.Transition == 1)
                    rbntPostive.Checked = true;
                if (cornerTool.Transition == 2)
                    rbntNegative.Checked = true;
                if (cornerTool.Transition == 3)
                    rbntAll.Checked = true;
                if (cornerTool.Selcet == 1)
                    rbntSelectFirst.Checked = true;
                if (cornerTool.Selcet == 2)
                    rbntSelectLast.Checked = true;
                if (cornerTool.Selcet == 3)
                    rbntSelectAll.Checked = true;
                cebxRule.Checked = cornerTool.IsRule;
                //cebxLine.Checked = cornerTool.IsLine;
                cebxCross.Checked = cornerTool.IsCross;

                //nudHmeasure.Value = Convert.ToDecimal(cornerTool.Hmeasure.D);
                //nudLmeasure.Value = Convert.ToDecimal(cornerTool.Lmeasure.D);
                //cebxMeasure.Checked = cornerTool.IsMeasure;

                //MeasureDisp(ref cornerTool);

                cbxImage.Items.Clear();
                if (cornerTool.Image != null)
                {
                    foreach (var item in cornerTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
              //  halconView1.DispImage((HObject)cornerTool.Image[cbxImage.Text], true);
              //  halconView1.FitImage();
                cbxFixture.Items.Clear();
                if (cornerTool.DicHomMat2D != null)
                {
                    foreach (var item in cornerTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();
            }
            catch
            {
                cbxImage.Items.Clear();
                if (cornerTool.Image != null)
                {
                    foreach (var item in cornerTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (cornerTool.DicHomMat2D != null)
                {
                    foreach (var item in cornerTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                } Register();
            }
        }

        void SetVal(ref FindCornerTool cornerTool)
        {

            cornerTool.Names = ImageTool.Tool.找顶点测量.ToString() + "_" + tbxToolName.Text;
            cornerTool.ImageName = cbxImage.Text;
            cornerTool.FixNames = cbxFixture.Text;
            cornerTool.Sigma = (int)nudSigma.Value;
            cornerTool.Threshold = (int)nudThreshold.Value;
            cornerTool.SetdrawShape = cbxRoi.Text;
            cornerTool.IsRule = cebxRule.Checked;
            cornerTool.IsCross = cebxCross.Checked;

            //cornerTool.Lmeasure = (double)nudLmeasure.Value;
            //cornerTool.Hmeasure = (double)nudHmeasure.Value;
            //cornerTool.IsMeasure = cebxMeasure.Checked;
            cornerTool.IsFixture = cebxFixture.Checked;
            if (rbntPostive.Checked)
                cornerTool.Transition = 1;
            if (rbntNegative.Checked)
                cornerTool.Transition = 2;
            if (rbntAll.Checked)
                cornerTool.Transition = 3;
            if (rbntSelectFirst.Checked)
                cornerTool.Selcet = 1;
            if (rbntSelectLast.Checked)
                cornerTool.Selcet = 2;
            if (rbntSelectAll.Checked)
                cornerTool.Selcet = 3;


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

            cebxRule.CheckedChanged -= new EventHandler(cebxRule_CheckedChanged);
            cebxCross.CheckedChanged -= new EventHandler(cebxCross_CheckedChanged);
            //nudHmeasure.ValueChanged -= new EventHandler(nudHmeasure_ValueChanged);
            //nudLmeasure.ValueChanged -= new EventHandler(nudLmeasure_ValueChanged);
            //cebxMeasure.CheckedChanged -= new EventHandler(cebxMeasure_CheckedChanged);
       

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
            cebxRule.CheckedChanged += new EventHandler(cebxRule_CheckedChanged);
            cebxCross.CheckedChanged += new EventHandler(cebxCross_CheckedChanged);
             //nudHmeasure.ValueChanged += new EventHandler(nudHmeasure_ValueChanged);
            //nudLmeasure.ValueChanged += new EventHandler(nudLmeasure_ValueChanged);
            //cebxMeasure.CheckedChanged += new EventHandler(cebxMeasure_CheckedChanged);
            //nudScale.ValueChanged += new EventHandler(nudScale_ValueChanged);
        }                                                                                 


        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            cornerTool.Names = ImageTool.Tool.找顶点测量.ToString() + "_" + tbxToolName.Text;
       
        }

        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
           // halconView1.DispImage((HObject)this.cornerTool.Image[cbxImage.Text], true);
           // halconView1.FitImage();
            cornerTool.ImageName = cbxImage.Text;
         }

        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
            cornerTool.FixNames = cbxFixture.Text;
        }
        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            cornerTool.IsFixture = cebxFixture.Checked;
   
        }

        private void nudSigma_ValueChanged(object sender, EventArgs e)
        {
            cornerTool.Sigma = (double)nudSigma.Value;
        
        }

        private void nudThreshold_ValueChanged(object sender, EventArgs e)
        {
            cornerTool.Threshold = (int)nudThreshold.Value;
        }

        private void rbntPostive_CheckedChanged(object sender, EventArgs e)
        {
            if (rbntPostive.Checked)
                cornerTool.Transition = 1;
       }

        private void rbntNegative_CheckedChanged(object sender, EventArgs e)
        {
            if (rbntNegative.Checked)
                cornerTool.Transition = 2;
        }  
        private void rbntAll_CheckedChanged(object sender, EventArgs e)
        {
               if (rbntAll.Checked)
                cornerTool.Transition = 3;
        }
       private void rbntSelectFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (rbntSelectFirst.Checked)
                cornerTool.Selcet = 1;
        }

        private void rbntSelectLast_CheckedChanged(object sender, EventArgs e)
        {
            if (rbntSelectLast.Checked)
                cornerTool.Selcet = 2;
        }

        private void rbntSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbntSelectAll.Checked)
                cornerTool.Selcet = 3;
        }

        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            if (cbxRoi.Text == CaliperTool.Roi.方向矩形.ToString())
                cornerTool.SetdrawShape = CaliperTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == CaliperTool.Roi.矩形.ToString())
                cornerTool.SetdrawShape = CaliperTool.Roi.矩形.ToString();
            if (cbxRoi.Text == CaliperTool.Roi.圆.ToString())
                cornerTool.SetdrawShape = CaliperTool.Roi.圆.ToString();
        //    halconView1.ContextMenuStripHide();
         //   halconView1.Focus();
            cornerTool.draw_roi();
        }
        private void cbxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cornerTool.SetdrawShape = cbxRoi.Text;
        }

        private void cebxRule_CheckedChanged(object sender, EventArgs e)
        {
            cornerTool.IsRule = cebxRule.Checked;
        }
        private void cebxCross_CheckedChanged(object sender, EventArgs e)
        {
            cornerTool.IsCross = cebxCross.Checked;
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            try
            {
            long timer = cornerTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
          //  halconView1.ToolLable2.Text = "FAIL";
          //  halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.cornerTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
                //halconView1.ToolLable2.Text = "PASS";
               // halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
           // halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            DataGridView(dataGridView1, cornerTool.ResultRow, cornerTool.ResultColumn);
    
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
                this.SetVal(ref this.cornerTool);
                this.Hide();
                frm = null;
                handleSetval(this.cornerTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.cornerTool);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            frm = null;
        }

        private void DataGridView(DataGridView dataGridView,  HTuple result_row, HTuple result_col)
        {
            try
            {
                string  str_Rows, str_Cols;
                dataGridView.Columns.Clear();//
                dataGridView.Columns.Add("", "ResultRow");//
                dataGridView.Columns.Add("", "ResultCol");//
                for (int i = 0; i < result_row.Length; i++)
                {
                    dataGridView.Rows.Add(1);//加载row
                    ;//row表头ID
                    dataGridView.Rows[i].HeaderCell.Value = i.ToString();//row表头
                    ;//表格赋值
                    str_Rows = result_row.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(0)
                    str_Cols = result_col.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(2)

                    dataGridView.Rows[i].Cells[0].Value = str_Rows; ;//表格赋值col(0)
                    dataGridView.Rows[i].Cells[1].Value = str_Cols; ;//表格赋值col(1)
                }
            }
            catch { }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            cornerTool.set_after();
        }
    }
}
