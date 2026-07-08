using ComboBox_Draw;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace UniversalControlSystem
{
    public partial class frm_PMAlign : Form
    {
        static frm_PMAlign frm;
        PMAlignTool pamlignTool = new PMAlignTool();
        public delegate void HandledSetVal(PMAlignTool pamlignTool);
        HandledSetVal handleSetval;
        Image image;
        string ModelPath, RoiPath;
        bool isDrawRoi = false;

        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_PMAlign SingleShow(PMAlignTool pamlignTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_PMAlign(pamlignTool, handleSetval);
            }
            return frm;
        }
        public frm_PMAlign(PMAlignTool pamlignTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            this.pamlignTool.Names = pamlignTool.Names;
            this.pamlignTool.Image = pamlignTool.Image;
            this.pamlignTool.ModelID = pamlignTool.ModelID;
            this.pamlignTool.ModelPath = pamlignTool.ModelPath;
            this.pamlignTool.RoiPath = pamlignTool.RoiPath;
            this.pamlignTool.ROI = pamlignTool.ROI;
            this.pamlignTool.Circle = pamlignTool.Circle;
            this.pamlignTool.Rectangle1 = pamlignTool.Rectangle1;
            this.pamlignTool.Rectangle2 = pamlignTool.Rectangle2;
            this.pamlignTool.SearchModeRoi = pamlignTool.SearchModeRoi;
            DisplayVal(pamlignTool);
            SetVal(ref this.pamlignTool);
        }
        void DisplayVal(PMAlignTool pamlignTool)
        { 
            try
            {  
                Cancel();//注销事件
                int nameIndex = pamlignTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = pamlignTool.Names.Substring(nameIndex + 1, pamlignTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = pamlignTool.Names;
                    tbxToolName.Text = pamlignTool.Names;
                }
                //创建
                cbxImage.Text = pamlignTool.ImageName;//
                nudCAngleStart.Value = pamlignTool.Cm_AngleStart;
                nudCAngleExtent.Value = pamlignTool.Cm_AngleExtent;
                nudCScaleRMin.Value = Convert.ToDecimal(pamlignTool.Cm_ScaleRMin.D);
                nudCScaleRMax.Value = Convert.ToDecimal(pamlignTool.Cm_ScaleRMax.D);
                nudCScaleCMin.Value = Convert.ToDecimal(pamlignTool.Cm_ScaleCMin.D);
                nudCScaleCMax.Value = Convert.ToDecimal(pamlignTool.Cm_ScaleCMax.D);
                cbxMetric.Text = pamlignTool.Cm_Metric;
                nudCNumLevels.Value = Convert.ToDecimal(pamlignTool.Cm_NumLevels.I);
                nudContrastLow.Value = Convert.ToDecimal(pamlignTool.Cm_ContrastLow.I);
                nudContrastHig.Value = Convert.ToDecimal(pamlignTool.Cm_ContrastHig.I);
                nudMinBorder.Value = Convert.ToDecimal(pamlignTool.Cm_MinBorder.I);
                nudMinContrast.Value = Convert.ToDecimal(pamlignTool.Cm_MinContrast.I);
                cbxOptimization.Text = pamlignTool.Cm_Optimization;
                cebxNumLevels.Checked = pamlignTool.Cm_IsNumLevels;
                ceboxContrast.Checked = pamlignTool.Cm_IsContrast;
                ceboxMinContrast.Checked = pamlignTool.Cm_IsMinContrast;
                ceboxDispRoi.Checked = pamlignTool.IsDispRoi;

           
                //喷模板
                ceboxPaint.Checked = pamlignTool.IsPaintModel;
                nudLowThreshold.Value = pamlignTool.ThresholdMin;
                nudHigThreshold.Value = pamlignTool.ThresholdMax;
                nudPaintGray.Value = pamlignTool.PaintGrayVal;
                tbxAreaMin.Text =Convert.ToString(pamlignTool.SelectedRegionMin);
                tbxAreaMax.Text =Convert.ToString(pamlignTool.SelectedRegionMax);
                //找模板
                nudFAngleStart.Value = pamlignTool.Fm_AngleStart;
                nudFAngleExtent.Value = pamlignTool.Fm_AngleExtent;
                nudFScaleRMin.Value = Convert.ToDecimal(pamlignTool.Fm_ScaleRMin.D);
                nudFScaleRMax.Value = Convert.ToDecimal(pamlignTool.Fm_ScaleRMax.D);
                nudFScaleCMin.Value = Convert.ToDecimal(pamlignTool.Fm_ScaleCMin.D);
                nudFScaleCMax.Value = Convert.ToDecimal(pamlignTool.Fm_ScaleCMax.D);
                nudNumMatches.Value = pamlignTool.Fm_NumMatches;
                nudMinScore.Value =  Convert.ToDecimal(pamlignTool.Fm_MinScore.D);
                nudMaxOverlap.Value = Convert.ToDecimal(pamlignTool.Fm_MaxOverlap.D);
                nudGreediness.Value = Convert.ToDecimal(pamlignTool.Fm_Greediness.D);
                cbxSubPixel.Text = pamlignTool.Fm_SubPixel;
                nudFNumLevels.Value = Convert.ToDecimal(pamlignTool.Fm_NumLevels.I);
                //
                cbxRoi.Text = pamlignTool.SetdrawShape;
                ceboxSeath.Checked = pamlignTool.IsSearchRegion;
                cebxIsModeXld.Checked = pamlignTool.IsModeXld;
                cebxIsCross.Checked = pamlignTool.IsCross;

                nudLowScore.Value = Convert.ToDecimal(pamlignTool.LowScore.D);
                nudHigScore.Value = Convert.ToDecimal(pamlignTool.HigScore.D);
                nudLowNum.Value = Convert.ToDecimal(pamlignTool.LowNums.I);
                nudHigNum.Value = Convert.ToDecimal(pamlignTool.HigNums.I);
                cebxSorce.Checked = pamlignTool.IsSocre;
                cebxNums.Checked = pamlignTool.IsNums;
                dispModePath(pamlignTool);
                dispRoiPath(pamlignTool);
                cbxImage.Items.Clear();
                if (pamlignTool.Image != null)
                {
                    foreach (var item in pamlignTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
           //     halconView1.DispImage((HObject)pamlignTool.Image[cbxImage.Text], true);
              //  halconView1.FitImage();
                Register();//注册事件
            }
            catch {
                cbxImage.Items.Clear();
                if (pamlignTool.Image != null)
                {
                    foreach (var item in pamlignTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                Register();//注册事件  
            }
        }
       void Cancel()
        {
            nudCAngleStart.ValueChanged -= new EventHandler(nudCAngleStart_ValueChanged);
            nudCAngleExtent.ValueChanged -= new EventHandler(nudCAngleExtent_ValueChanged);
            nudCScaleRMin.ValueChanged -= new EventHandler(nudCScaleRMin_ValueChanged);
            nudCScaleRMax.ValueChanged -= new EventHandler(nudCScaleRMax_ValueChanged);
            nudCScaleCMin.ValueChanged -= new EventHandler(nudCScaleCMin_ValueChanged);
            nudCScaleCMax.ValueChanged -= new EventHandler(nudCScaleCMax_ValueChanged);
            cbxMetric.TextChanged -= new EventHandler(cbxMetric_SelectedIndexChanged);

            nudCNumLevels.ValueChanged -= new EventHandler(nudCNumLevels_ValueChanged);
            nudContrastLow.ValueChanged -= new EventHandler(nudContrastLow_ValueChanged);
            nudContrastHig.ValueChanged -= new EventHandler(nudContrastHig_ValueChanged);
            nudMinBorder.ValueChanged -= new EventHandler(nudMinBorder_ValueChanged);
            nudMinContrast.ValueChanged -= new EventHandler(nudMinContrast_ValueChanged);
            cbxOptimization.TextChanged -= new EventHandler(cbxOptimization_SelectedIndexChanged);
            cebxNumLevels.CheckedChanged -= new EventHandler(cebxNumLevels_CheckedChanged);
            ceboxContrast.CheckedChanged -= new EventHandler(cebxContrast_CheckedChanged);
            ceboxMinContrast.CheckedChanged -= new EventHandler(cebxMinContrast_CheckedChanged);
            ceboxDispRoi.CheckedChanged -= new EventHandler(ceboxDispRoi_CheckedChanged);
          
          
            //
            nudFAngleStart.ValueChanged -= new EventHandler(nudFAngleStart_ValueChanged);
            nudFAngleExtent.ValueChanged -= new EventHandler(nudFAngleExtent_ValueChanged);
            nudFScaleRMin.ValueChanged -= new EventHandler(nudFScaleRMin_ValueChanged);
            nudFScaleRMax.ValueChanged -= new EventHandler(nudFScaleRMax_ValueChanged);
            nudFScaleCMin.ValueChanged -= new EventHandler(nudFScaleCMin_ValueChanged);
            nudFScaleCMax.ValueChanged -= new EventHandler(nudFScaleCMax_ValueChanged);
            nudNumMatches.ValueChanged -= new EventHandler(nudNumMatches_ValueChanged);
            nudMinScore.ValueChanged -= new EventHandler(nudMinScore_ValueChanged);
            nudMaxOverlap.ValueChanged -= new EventHandler(nudMaxOverlap_ValueChanged);
            nudGreediness.ValueChanged -= new EventHandler(nudGreediness_ValueChanged);
            nudFNumLevels.ValueChanged -= new EventHandler(nudFNumLevels_ValueChanged);
            //
            cbxSubPixel.TextChanged -= new EventHandler(cbxSubPixel_SelectedIndexChanged);
            cebxIsCross.CheckedChanged -= new EventHandler(cebxIsCross_CheckedChanged);
        }
       void Register()
       {
           nudCAngleStart.ValueChanged += new EventHandler(nudCAngleStart_ValueChanged);
           nudCAngleExtent.ValueChanged += new EventHandler(nudCAngleExtent_ValueChanged);
           nudCScaleRMin.ValueChanged += new EventHandler(nudCScaleRMin_ValueChanged);
           nudCScaleRMax.ValueChanged += new EventHandler(nudCScaleRMax_ValueChanged);
           nudCScaleCMin.ValueChanged += new EventHandler(nudCScaleCMin_ValueChanged);
           nudCScaleCMax.ValueChanged += new EventHandler(nudCScaleCMax_ValueChanged);
           cbxMetric.TextChanged += new EventHandler(cbxMetric_SelectedIndexChanged);
           nudCNumLevels.ValueChanged += new EventHandler(nudCNumLevels_ValueChanged);
           nudContrastLow.ValueChanged += new EventHandler(nudContrastLow_ValueChanged);
           nudContrastHig.ValueChanged += new EventHandler(nudContrastHig_ValueChanged);
           nudMinBorder.ValueChanged += new EventHandler(nudMinBorder_ValueChanged);
           nudMinContrast.ValueChanged += new EventHandler(nudMinContrast_ValueChanged);
           cbxOptimization.TextChanged += new EventHandler(cbxOptimization_SelectedIndexChanged);
           cebxNumLevels.CheckedChanged += new EventHandler(cebxNumLevels_CheckedChanged);
           ceboxContrast.CheckedChanged += new EventHandler(cebxContrast_CheckedChanged);
           ceboxMinContrast.CheckedChanged += new EventHandler(cebxMinContrast_CheckedChanged);
           ceboxDispRoi.CheckedChanged += new EventHandler(ceboxDispRoi_CheckedChanged);
           //
           nudFAngleStart.ValueChanged += new EventHandler(nudFAngleStart_ValueChanged);
           nudFAngleExtent.ValueChanged += new EventHandler(nudFAngleExtent_ValueChanged);
           nudFScaleRMin.ValueChanged += new EventHandler(nudFScaleRMin_ValueChanged);
           nudFScaleRMax.ValueChanged += new EventHandler(nudFScaleRMax_ValueChanged);
           nudFScaleCMin.ValueChanged += new EventHandler(nudFScaleCMin_ValueChanged);
           nudFScaleCMax.ValueChanged += new EventHandler(nudFScaleCMax_ValueChanged);
           nudNumMatches.ValueChanged += new EventHandler(nudNumMatches_ValueChanged);
           nudMinScore.ValueChanged += new EventHandler(nudMinScore_ValueChanged);
           nudMaxOverlap.ValueChanged += new EventHandler(nudMaxOverlap_ValueChanged);
           nudGreediness.ValueChanged += new EventHandler(nudGreediness_ValueChanged);
           nudFNumLevels.ValueChanged += new EventHandler(nudFNumLevels_ValueChanged);
           //
           cbxSubPixel.TextChanged += new EventHandler(cbxSubPixel_SelectedIndexChanged);
           cebxIsCross.CheckedChanged += new EventHandler(cebxIsCross_CheckedChanged);
       }
        void SetVal(ref PMAlignTool pamlignTool)
        {
            pamlignTool.Names = ImageTool.Tool.形状模板匹配.ToString() + "_" + tbxToolName.Text;
            pamlignTool.ImageName = cbxImage.Text;
           //创建
            pamlignTool.Cm_AngleStart =(int)nudCAngleStart.Value;
            pamlignTool.Cm_AngleExtent = (int)nudCAngleExtent.Value;
            pamlignTool.Cm_ScaleRMin =(double)nudCScaleRMin.Value;
            pamlignTool.Cm_ScaleRMax =(double) nudCScaleRMax.Value;
            pamlignTool.Cm_ScaleCMin = (double)nudCScaleCMin.Value;
            pamlignTool.Cm_ScaleCMax = (double)nudCScaleCMax.Value;
            pamlignTool.Cm_Metric = cbxMetric.Text;
            pamlignTool.Cm_NumLevels = (int)nudCNumLevels.Value;
            pamlignTool.Cm_ContrastLow = (int)nudContrastLow.Value;
            pamlignTool.Cm_ContrastHig = (int)nudContrastHig.Value;
            pamlignTool.Cm_MinBorder = (int)nudMinBorder.Value;
            pamlignTool.Cm_MinContrast = (int)nudMinContrast.Value;
            pamlignTool.Cm_Optimization = cbxOptimization.Text;
            pamlignTool.Cm_IsNumLevels = cebxNumLevels.Checked;
            pamlignTool.Cm_IsContrast = ceboxContrast.Checked;
            pamlignTool.Cm_IsMinContrast = ceboxMinContrast.Checked;
            pamlignTool.IsDispRoi = ceboxDispRoi.Checked;
        
            //喷模板
            pamlignTool.IsPaintModel = ceboxPaint.Checked;
            pamlignTool.ThresholdMin = (int)nudLowThreshold.Value;
            pamlignTool.ThresholdMax = (int)nudHigThreshold.Value;
            pamlignTool.PaintGrayVal = (int)nudPaintGray.Value;
            pamlignTool.SelectedRegionMin = Convert.ToInt32(tbxAreaMin.Text);
            pamlignTool.SelectedRegionMax = Convert.ToInt32(tbxAreaMax.Text);
            //找模板
            pamlignTool.Fm_AngleStart = (int)nudFAngleStart.Value;
            pamlignTool.Fm_AngleExtent = (int)nudFAngleExtent.Value;
            pamlignTool.Fm_ScaleRMin = (double)nudFScaleRMin.Value;
            pamlignTool.Fm_ScaleRMax = (double)nudFScaleRMax.Value;
            pamlignTool.Fm_ScaleCMin = (double)nudFScaleCMin.Value;
            pamlignTool.Fm_ScaleCMax = (double)nudFScaleCMax.Value;
            pamlignTool.Fm_NumMatches = (int)nudNumMatches.Value;
            pamlignTool.Fm_MinScore = (double)nudMinScore.Value;
            pamlignTool.Fm_MaxOverlap = (double )nudMaxOverlap.Value;
            pamlignTool.Fm_Greediness = (double) nudGreediness.Value;
            pamlignTool.Fm_SubPixel = cbxSubPixel.Text;
            pamlignTool.Fm_NumLevels = (int)nudFNumLevels.Value;

            pamlignTool.SetdrawShape = cbxRoi.Text;
            pamlignTool.IsSearchRegion = ceboxSeath.Checked;
            pamlignTool.IsModeXld = cebxIsModeXld.Checked;
            pamlignTool.IsCross = cebxIsCross.Checked;

            pamlignTool.LowScore = (double)nudLowScore.Value;
            pamlignTool.HigScore = (double)nudHigScore.Value;
            pamlignTool.LowNums = (int)nudLowNum.Value;
            pamlignTool.HigNums = (int)nudHigNum.Value;

            pamlignTool.IsSocre = cebxSorce.Checked;
            pamlignTool.IsNums=  cebxNums.Checked;
            pamlignTool.ModelPath = ModelPath;
   
        }
        private void frm_PMAlign_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.FormClosing += frm_PMAlign_FormClosing;
            //this.hWindowControl1.HMouseWheelEvent += halconView1_HMouseWheelEvent;
            image = Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_circle.png");
            cbxRoi.Items.Add(new MyItem(BlobTool.Roi.圆.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_circle.png")));
            cbxRoi.Items.Add(new MyItem(BlobTool.Roi.矩形.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_rect1.png")));
            cbxRoi.Items.Add(new MyItem(BlobTool.Roi.方向矩形.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_rect2.png")));
            cbxRoi.SelectedIndex = 1;
            //cbxRegion.Items.Add(new MyItem(BlobTool.Tool.区域创建.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_create.png")));
            cbxRegion.Items.Add(new MyItem(BlobTool.Tool.区域合并.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_op_union.png")));
            cbxRegion.Items.Add(new MyItem(BlobTool.Tool.区域交集.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_op_intersection.png")));
            cbxRegion.Items.Add(new MyItem(BlobTool.Tool.区域差集.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_op_difference.png")));
            cbxRegion.Items.Add(new MyItem(BlobTool.Tool.区域对称差.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_op_xor.png")));
            cbxRegion.SelectedIndex = 0;
            this.pamlignTool.hWindowControl1 = hWindowControl1;

        }

        void halconView1_HMouseWheelEvent(object sender)
        {
            pamlignTool.dispresult();
        }
        void frm_PMAlign_FormClosing(object sender, FormClosingEventArgs e)
        { 
            frm = null;
        }
        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.pamlignTool.Names = ImageTool.Tool.形状模板匹配.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }
        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
             // halconView1.DispImage((HObject) this.pamlignTool.Image[cbxImage.Text], true);
            //  halconView1.FitImage();
              this.pamlignTool.ImageName = cbxImage.Text;
        }
        private void nudCAngleStart_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Cm_AngleStart = (int)nudCAngleStart.Value;
        }
        private void nudCAngleExtent_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Cm_AngleExtent = (int)nudCAngleExtent.Value;
        }
        private void nudCScaleCMin_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Cm_ScaleCMin = (double)nudCScaleCMin.Value;
        }
        private void nudCScaleCMax_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Cm_ScaleCMax = (double)nudCScaleCMax.Value;
        }
        private void nudCScaleRMin_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Cm_ScaleRMin = (double)nudCScaleRMin.Value;
        }
        private void nudCScaleRMax_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Cm_ScaleRMax = (double)nudCScaleRMax.Value;
        }
        private void cbxMetric_SelectedIndexChanged(object sender, EventArgs e)
        {
            pamlignTool.Cm_Metric = cbxMetric.Text;
        }
        private void ceboxPaint_CheckedChanged(object sender, EventArgs e)
        {
            pamlignTool.IsPaintModel = ceboxPaint.Checked;
          
        }
        private void nudPaintGray_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.PaintGrayVal = (int)nudPaintGray.Value;
         }
        private void nudLowThreshold_ValueChanged(object sender, EventArgs e)
        {
             pamlignTool.ThresholdMin = (int)nudLowThreshold.Value;
        }
        private void nudHigThreshold_ValueChanged(object sender, EventArgs e)
        {
             pamlignTool.ThresholdMax = (int)nudHigThreshold.Value;
         }
        private void tbxAreaMin_TextChanged(object sender, EventArgs e)
        {
            pamlignTool.SelectedRegionMin = Convert.ToInt32(tbxAreaMin.Text);
        }
        private void tbxAreaMax_TextChanged(object sender, EventArgs e)
        {
          pamlignTool.SelectedRegionMax = Convert.ToInt32(tbxAreaMax.Text);
        }
        private void nudFAngleStart_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Fm_AngleStart = (int)nudFAngleStart.Value;
        }
        private void nudFAngleExtent_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Fm_AngleExtent = (int)nudFAngleExtent.Value;
        }
        private void nudFScaleCMin_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Fm_ScaleCMin = (double)nudFScaleCMin.Value;
           
        }
        private void nudFScaleCMax_ValueChanged(object sender, EventArgs e)
        {
         
            pamlignTool.Fm_ScaleCMax = (double)nudFScaleCMax.Value;
        }
        private void nudFScaleRMin_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Fm_ScaleRMin = (double)nudFScaleRMin.Value;
         
        }
        private void nudFScaleRMax_ValueChanged(object sender, EventArgs e)
        {
          
            pamlignTool.Fm_ScaleRMax = (double)nudFScaleRMax.Value;
        }
        private void nudNumMatches_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Fm_NumMatches = (int)nudNumMatches.Value;
        
        }
        private void nudMinScore_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Fm_MinScore = (double)nudMinScore.Value;
        }
        private void nudMaxOverlap_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Fm_MaxOverlap = (double)nudMaxOverlap.Value;
         
        }
        private void nudGreediness_ValueChanged(object sender, EventArgs e)
        {
             pamlignTool.Fm_Greediness = (double)nudGreediness.Value;
        }
        private void cbxSubPixel_SelectedIndexChanged(object sender, EventArgs e)
        {
             pamlignTool.Fm_SubPixel = cbxSubPixel.Text;
        }
        private void cbxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            pamlignTool.SetdrawShape = cbxRoi.Text;
        }
        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            isDrawRoi = false;
            if (cbxRoi.Text == ImageTool.Roi.方向矩形.ToString())
                pamlignTool.SetdrawShape = ImageTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == ImageTool.Roi.矩形.ToString())
                pamlignTool.SetdrawShape = ImageTool.Roi.矩形.ToString();
            if (cbxRoi.Text == ImageTool.Roi.圆.ToString())
                pamlignTool.SetdrawShape = ImageTool.Roi.圆.ToString();
            //halconView1.ContextMenuStripHide();
           // halconView1.Focus();
            pamlignTool.RegionType = cbxRegion.Text;
            pamlignTool.draw_roi();
            ModelPath = pamlignTool.ModelPath;
            isDrawRoi = true;
        }
        private void ceboxSeath_CheckedChanged(object sender, EventArgs e)
        {
            pamlignTool.IsSearchRegion = ceboxSeath.Checked;
        }
        private void btnSearchRoi_Click(object sender, EventArgs e)
        {
            //halconView1.ContextMenuStripHide();
            //halconView1.Focus();
            pamlignTool.drawSearchRoi();
        }
        private void btnAddMode_Click(object sender, EventArgs e)
        {
              pamlignTool.ReadModel();
              dispModePath(pamlignTool);
        }
        private void cebxIsModeXld_CheckedChanged(object sender, EventArgs e)
        {
            pamlignTool.IsModeXld = cebxIsModeXld.Checked;
        }
        private void cebxIsCross_CheckedChanged(object sender, EventArgs e)
        {
            pamlignTool.IsCross = cebxIsCross.Checked;
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            try { 
            long timer = pamlignTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
          //  halconView1.ToolLable2.Text = "FAIL";
          //  halconView1.ToolLable2.ForeColor = Color.Red ;
            if (pamlignTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
               // halconView1.ToolLable2.Text = "PASS";
//halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            //halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            DataGridView(dataGridView1, pamlignTool.ResultRow, pamlignTool.ResultColumn, pamlignTool.ResultAngle, pamlignTool.ResultScore,
                                        pamlignTool.ResultScaleR, pamlignTool.ResultScaleC);
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
                this.SetVal(ref this.pamlignTool);
                this.Hide();
                frm = null;
                handleSetval(this.pamlignTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.pamlignTool);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        void dispRoiPath(PMAlignTool pamlignTool)
        {
            try
            { 
                int Debug = pamlignTool.RoiPath.LastIndexOf("Debug");//是否是debug下的文件
                RoiPath = pamlignTool.RoiPath;
                if (Debug != -1)
                {
                    string bugPath = pamlignTool.RoiPath.Substring(Debug + 6, pamlignTool.RoiPath.Length - (Debug + 6));//截取Debug下的文件,例如 原路径 C://Debug//1
                    lblRoiPath.Text = bugPath;
                }
                string imgtype = "*.hobj";
                lblRoiPath.Text = RoiPath;
                string path = RoiPath.Substring(0, RoiPath.Length - (RoiPath.Length - RoiPath.LastIndexOf("\\")));
                listBox1.Items.Clear();
                string[] ImageType = imgtype.Split('|');
                for (int i = 0; i < ImageType.Length; i++)
                {
                    string[] dirs = Directory.GetFiles(path, ImageType[i]);
                    foreach (string s in dirs)
                    {
                        listBox1.Items.Add(new FileInfo(s).Name);
                    }
                }
            }
            catch
            {
                MessageBox.Show("读取ROI错误!");
            }
        }
        void dispModePath(PMAlignTool pamlignTool)
        {
            int Debug = pamlignTool.ModelPath.LastIndexOf("Debug");//是否是debug下的文件
            ModelPath = pamlignTool.ModelPath;
            if (Debug != -1)
            {
                string bugPath = pamlignTool.ModelPath.Substring(Debug + 6, pamlignTool.ModelPath.Length - (Debug + 6));//截取Debug下的文件,例如 原路径 C://Debug//1
                lblModePath.Text = bugPath;
            }
            string imgtype = "*.shm";
            string path = ModelPath.Substring(0, ModelPath.Length-(ModelPath.Length - ModelPath.LastIndexOf("\\")));
            listBox2.Items.Clear();
            string[] ImageType = imgtype.Split('|');
            for (int i = 0; i < ImageType.Length; i++)
            {
                string[] dirs = Directory.GetFiles(path, ImageType[i]);
                foreach (string s in dirs)
                {
                    listBox2.Items.Add(new FileInfo(s).Name);
                }
            }
         }
        //结果输出
        private void DataGridView(DataGridView dataGridView, HTuple ResultRow, HTuple ResultColumn, HTuple ResultAngle,
            HTuple ResultScore, HTuple ResultScaleR, HTuple ResultScaleC)
        {
            string str_Rows, str_Cols, str_Angles,  str_Scores, str_ScaleRs, str_ScaleCs;
            dataGridView.Columns.Clear();//
            dataGridView.Columns.Add("", "ResultRow");//
            dataGridView.Columns.Add("", "ResultCol");//
            dataGridView.Columns.Add("", "ResultAngle");//
            dataGridView.Columns.Add("", "ResultScore");//
            dataGridView.Columns.Add("", "ResultScaleR");//
            dataGridView.Columns.Add("", "ResultScaleC");//
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            if (ResultColumn == null)
            {return;}
            for (int i = 0; i < ResultColumn.Length; i++)
            {
                dataGridView.Rows.Add(1);//加载row
                ;//row表头ID
                dataGridView.Rows[i].HeaderCell.Value = i.ToString();//row表头
                ;//表格赋值
                str_Rows = ResultRow.TupleSelect(i).TupleString("0.3f");//表格赋值col(0)
                str_Cols = ResultColumn.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(1)
                str_Angles = ResultAngle.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(2)
                str_Scores = ResultScore.TupleSelect(i).TupleString("0.3f");//表格赋值col(3)
                str_ScaleRs = ResultScaleR.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(4)
                str_ScaleCs = ResultScaleC.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(5)

                dataGridView.Rows[i].Cells[0].Value = str_Rows; ;//表格赋值col(0)
                dataGridView.Rows[i].Cells[1].Value = str_Cols; ;//表格赋值col(1)
                dataGridView.Rows[i].Cells[2].Value = str_Angles; ;//表格赋值col(2)
                dataGridView.Rows[i].Cells[3].Value = str_Scores; ;//表格赋值col(3)
                dataGridView.Rows[i].Cells[4].Value = str_ScaleRs; ;//表格赋值col(4)
                dataGridView.Rows[i].Cells[5].Value = str_ScaleCs; ;//表格赋值col(5)
                
             
            }
        }

        private void nudLowScore_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.LowScore = (double)nudLowScore.Value;
        }
        private void nudHigScore_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.HigScore = (double)nudHigScore.Value;
        }
        private void nudLowNum_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.LowNums = (double)nudLowNum.Value;
        }
        private void nudHigNum_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.HigNums = (double)nudHigNum.Value;
        }
        private void cebxSorce_CheckedChanged(object sender, EventArgs e)
        {
            pamlignTool.IsSocre = cebxSorce.Checked;
        }
        private void cebxNums_CheckedChanged(object sender, EventArgs e)
        {
              pamlignTool.IsNums = cebxNums.Checked;
        }
        private void nudCNumLevels_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Cm_NumLevels = (int)nudCNumLevels.Value;
        }
        private void nudContrastLow_ValueChanged(object sender, EventArgs e)
        {
            if (nudContrastLow.Value < nudContrastHig.Value)
               pamlignTool.Cm_ContrastLow = (int)nudContrastLow.Value;
            else
               nudContrastHig.Value = nudContrastLow.Value;
        }
        private void nudContrastHig_ValueChanged(object sender, EventArgs e)
        {
            if (nudContrastLow.Value < nudContrastHig.Value)
                pamlignTool.Cm_ContrastHig = (int)nudContrastHig.Value;
            else
                nudContrastLow.Value = nudContrastHig.Value;
        }
        private void nudMinBorder_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Cm_MinBorder = (int)nudMinBorder.Value;
        }
        private void nudMinContrast_ValueChanged(object sender, EventArgs e)
        {
            pamlignTool.Cm_MinContrast = (int)nudMinContrast.Value;
        }
        private void cbxOptimization_SelectedIndexChanged(object sender, EventArgs e)
        {
             pamlignTool.Cm_Optimization = cbxOptimization.Text;
        }
        private void cebxNumLevels_CheckedChanged(object sender, EventArgs e)
        {
              pamlignTool.Cm_IsNumLevels = cebxNumLevels.Checked;
        }
        private void cebxContrast_CheckedChanged(object sender, EventArgs e)
        {
              pamlignTool.Cm_IsContrast = ceboxContrast.Checked;
        }

        private void cebxMinContrast_CheckedChanged(object sender, EventArgs e)
        {
              pamlignTool.Cm_IsMinContrast = ceboxMinContrast.Checked;
        }

        private void nudFNumLevels_ValueChanged(object sender, EventArgs e)
        {
           pamlignTool.Fm_NumLevels = (int)nudFNumLevels.Value;
        }
    
         private void btnModel_Click(object sender, EventArgs e)
         {
             pamlignTool.saveModel();
             ModelPath = pamlignTool.ModelPath;
         }

         private void ceboxDispRoi_CheckedChanged(object sender, EventArgs e)
         {
             pamlignTool.IsDispRoi = ceboxDispRoi.Checked;
             pamlignTool.dispresult();
         }

         private void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
         {

         }
         private void cbxRoi_SelectedIndexChanged_1(object sender, EventArgs e)
         {
             pamlignTool.SetdrawShape = cbxRoi.Text;
         }

          private void btnClearRoi_Click(object sender, EventArgs e)
         {

            if (DialogResult.Yes == MessageBox.Show("是否清除ROI区域", "清除ROI区域", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
            {
                pamlignTool.RoiClear();
                isDrawRoi = false;
               // halconView1.DispImage((HObject)this.pamlignTool.Image[cbxImage.Text], true);
              //  halconView1.FitImage();
                pamlignTool.ImageName = cbxImage.Text;
            }
           
        }

         private void btnAddRoi_Click(object sender, EventArgs e)
         {
             pamlignTool.ReadRoi();
             dispRoiPath(pamlignTool);
         }

         private void btnSaveRoi_Click(object sender, EventArgs e)
         {
             pamlignTool.SaveRoi();
             dispRoiPath(pamlignTool);
             isDrawRoi = false;
        }
       

         private void cbxRegion_DrawItem(object sender, DrawItemEventArgs e)
         {
             ComboBox combox = (ComboBox)sender;
             if (e.Index >= 0)
             {
                 e.DrawBackground();

                 //获得项图片,绘制图片
                 MyItem item = (MyItem)combox.Items[e.Index];
                 Image img = item.Img;
                 e.DrawFocusRectangle();
                 //绘制
                 Pen p = new Pen(Color.Blue);
                 //p = Brushes.Black;
                 Graphics g = e.Graphics;
                 Rectangle bounds = e.Bounds;
                 Rectangle imageRect = new Rectangle(bounds.X, bounds.Y, image.Width + 4, image.Height + 4);
                 e.DrawFocusRectangle();
                 if (img != null)
                 {
                     g.DrawImage(img, imageRect);
                     //g.DrawRectangle(p, e.Bounds);
                 }
                 //文本格式垂直居中
                 StringFormat strFormat = new StringFormat();
                 strFormat.LineAlignment = StringAlignment.Center;
                 e.Graphics.DrawString(combox.Items[e.Index].ToString(), e.Font, Brushes.Black, bounds.X + 20, bounds.Y);

             }
         }

    

        private void cbxRoi_DrawItem(object sender, DrawItemEventArgs e)
         {
             ComboBox combox = (ComboBox)sender;
             if (e.Index >= 0)
             {  e.DrawBackground();
                //获得项图片,绘制图片
                 MyItem item = (MyItem)combox.Items[e.Index];
                 Image img = item.Img;
                 e.DrawFocusRectangle();
                 //绘制
                 Pen p = new Pen(Color.Blue);
                 //p = Brushes.Black;
                 Graphics g = e.Graphics;
                 Rectangle bounds = e.Bounds;
                 Rectangle imageRect = new Rectangle(bounds.X, bounds.Y, image.Width + 4, image.Height + 4);
                 e.DrawFocusRectangle();
                 if (img != null)
                 {
                     g.DrawImage(img, imageRect);
                     //g.DrawRectangle(p, e.Bounds);
                 }
                 //文本格式垂直居中
                 StringFormat strFormat = new StringFormat();
                 strFormat.LineAlignment = StringAlignment.Center;
                 e.Graphics.DrawString(combox.Items[e.Index].ToString(), e.Font, Brushes.Black, bounds.X + 20, bounds.Y);

             }
         }

       

        

      

     

    }
}
