using HalconDotNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace UniversalControlSystem
{
    public partial class frm_OCRMax : Form
    {
        static frm_OCRMax fo;
        OCRMaxTool OcrMaxTool = new OCRMaxTool();
        public delegate void HandledSetVal(OCRMaxTool OcrMaxTool);
        HandledSetVal handleSetval;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_OCRMax SingleShow(OCRMaxTool OcrMaxTool, HandledSetVal handleSetval)
        {
            if (fo == null)//
            {
                fo = new frm_OCRMax(OcrMaxTool, handleSetval);
            }
            return fo;
        }
        public frm_OCRMax()
        {
            InitializeComponent();
        }
        public frm_OCRMax(OCRMaxTool OcrMaxTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(OcrMaxTool);
            this.OcrMaxTool.Image = OcrMaxTool.Image;
            this.OcrMaxTool.Circle = OcrMaxTool.Circle;
            this.OcrMaxTool.Rectangle1 = OcrMaxTool.Rectangle1;
            this.OcrMaxTool.Rectangle2 = OcrMaxTool.Rectangle2;
            this.OcrMaxTool.DicHomMat2D = OcrMaxTool.DicHomMat2D;
            this.SetVal(ref this.OcrMaxTool);
        }
        void DisplayVal(OCRMaxTool OcrMaxTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = OcrMaxTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = OcrMaxTool.Names.Substring(nameIndex + 1, OcrMaxTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = OcrMaxTool.Names;
                    tbxToolName.Text = OcrMaxTool.Names;
                }
                cbxImage.Text = OcrMaxTool.ImageName;//
                cbxFixture.Text = OcrMaxTool.FixNames;
                takBarLowThreshold.Value = OcrMaxTool.LowThreshold;
                lbl_low.Text = "低阀值:" + takBarLowThreshold.Value.ToString();
                takBarHigThreshold.Value = OcrMaxTool.HigThreshold;
                lbl_higt.Text = "高阀值:" + takBarHigThreshold.Value.ToString();
                hSrlBarAreaMax.Value = OcrMaxTool.Select_shapeMax;
                lbl_areaMax.Text = "最大面积限定:" + hSrlBarAreaMax.Value.ToString();
                hSrlBarAreaMin.Value = OcrMaxTool.Select_shapeMin;
                lbl_areaMin.Text = "最小面积限定:" + hSrlBarAreaMin.Value.ToString();
                cbxRoi.Text = OcrMaxTool.SetdrawShape;
                cbxSetdraw.Text = OcrMaxTool.Setdraw;
                cebxIsSelectedRegions.Checked = OcrMaxTool.IsSelectedRegions;
                cebxIsRectangle.Checked = OcrMaxTool.IsRectangle;
                cebxIsback.Checked = OcrMaxTool.IsBack;
                cebxFixture.Checked = OcrMaxTool.IsFixture;
                cebxIllumination.Checked = OcrMaxTool.IsIllumination;

                //cebxIsOcrSelect.Checked = OcrMaxTool.IsOcrSelect;
                nudDilationHeight.Value = Convert.ToDecimal(OcrMaxTool.DilationHeight.I);
                nudDilationWidth.Value = Convert.ToDecimal(OcrMaxTool.DilationWidth.I);
                nudPartitionHeight.Value = Convert.ToDecimal(OcrMaxTool.PartitionHeight.I);
                nudPartitionWith.Value = Convert.ToDecimal(OcrMaxTool.PartitionWidth.I);
                cbxFileName.Text = OcrMaxTool.FileName;

                nudLowNum.Value = Convert.ToDecimal(OcrMaxTool.LowNums.I);
                nudHigNum.Value = Convert.ToDecimal(OcrMaxTool.HigNums.I);
                cebxNums.Checked = OcrMaxTool.IsNums;

                if (OcrMaxTool.OcrSelect == 0)
                    cbxOcrSelect.Text = "一般字符";
                if (OcrMaxTool.OcrSelect == 1)
                    cbxOcrSelect.Text = "一般字符光照不均匀";
                if (OcrMaxTool.OcrSelect == 2)
                    cbxOcrSelect.Text = "喷码点状字符";

                nudMaskHeight.Value = Convert.ToDecimal(OcrMaxTool.MaskHeight.I);
                nudMaskWidth.Value = Convert.ToDecimal(OcrMaxTool.MaskWidth.I);
                nudOffset.Value = Convert.ToDecimal(OcrMaxTool.Offset.I);
                cbxLightDrak.Text = OcrMaxTool.LightDrak;

                if (OcrMaxTool.BackgroundGValMode != null)
                {
                    lblBackgroundGValMode.Text = "BackVal:" + OcrMaxTool.BackgroundGValMode.TupleString("0.3f");
                    lblForegroundGValMode.Text = "ForeVal:" + OcrMaxTool.ForegroundGValMode.TupleString("0.3f");
                }
                cbxRegion.Text = OcrMaxTool.RegionName;
                cebxIsRegion.Checked = OcrMaxTool.IsRegion;
                cbxImage.Items.Clear();
                if (OcrMaxTool.Image != null)
                {
                    foreach (var item in OcrMaxTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (OcrMaxTool.DicHomMat2D != null)
                {
                    foreach (var item in OcrMaxTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                cbxRegion.Items.Clear();
                if (OcrMaxTool.Region != null)
                {
                    foreach (var item in OcrMaxTool.Region.Keys)
                    {
                        cbxRegion.Items.Add(item); //加载图像到下拉箱
                    }
                }
                Register();//注册事件
            }
            catch
            {
                cbxImage.Items.Clear();
                if (OcrMaxTool.Image != null)
                {
                    foreach (var item in OcrMaxTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (OcrMaxTool.DicHomMat2D != null)
                {
                    foreach (var item in OcrMaxTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                cbxRegion.Items.Clear();
                if (OcrMaxTool.Region != null)
                {
                    foreach (var item in OcrMaxTool.Region.Keys)
                    {
                        cbxRegion.Items.Add(item); //加载图像到下拉箱
                    }
                }
                Register();//注册事件}
            }
        }
        void SetVal(ref OCRMaxTool OcrMaxTool)
        {
            OcrMaxTool.Names = ImageTool.Tool.字符识别检测.ToString() + "_" + tbxToolName.Text;
            OcrMaxTool.ImageName = cbxImage.Text;
            OcrMaxTool.LowThreshold = takBarLowThreshold.Value;
            OcrMaxTool.HigThreshold = takBarHigThreshold.Value;
            OcrMaxTool.Select_shapeMax = hSrlBarAreaMax.Value;
            OcrMaxTool.Select_shapeMin = hSrlBarAreaMin.Value;
            OcrMaxTool.SetdrawShape = cbxRoi.Text;

            OcrMaxTool.PartitionWidth = (int)nudPartitionWith.Value;
            OcrMaxTool.PartitionHeight = (int)nudPartitionHeight.Value;
            OcrMaxTool.DilationWidth = (int)nudDilationWidth.Value;
            OcrMaxTool.DilationHeight = (int)nudDilationHeight.Value;
            OcrMaxTool.IsBack = cebxIsback.Checked;
            //OcrMaxTool.IsOcrSelect = cebxIsOcrSelect.Checked;
            OcrMaxTool.IsFixture = cebxFixture.Checked;
            OcrMaxTool.FileName = cbxFileName.Text;
            OcrMaxTool.FixNames = cbxFixture.Text;


            //cebxIsOcrSelect.Text = "普通字符";
            //if (OcrMaxTool.IsOcrSelect)
            //    cebxIsOcrSelect.Text = "点状字符";
            //cebxIsback.Text = "白字黑背景";
            if (OcrMaxTool.IsBack)
                cebxIsback.Text = "黑字白背景";

            OcrMaxTool.Setdraw = cbxSetdraw.Text;
            OcrMaxTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
            OcrMaxTool.IsRectangle = cebxIsRectangle.Checked;

            OcrMaxTool.LowNums = (int)nudLowNum.Value;
            OcrMaxTool.HigNums = (int)nudHigNum.Value;
            OcrMaxTool.IsNums = cebxNums.Checked;
            OcrMaxTool.IsIllumination = cebxIllumination.Checked;

            int ForeIndex = lblForegroundGValMode.Text.IndexOf(':');
            int BackIndex = lblBackgroundGValMode.Text.IndexOf(':');
            int ForeLen = (lblForegroundGValMode.Text.Length) - lblForegroundGValMode.Text.IndexOf(':');
            int BackLen = (lblBackgroundGValMode.Text.Length) - lblBackgroundGValMode.Text.IndexOf(':');

            string strFore = lblForegroundGValMode.Text.Substring(ForeIndex + 1, ForeLen - 1);
            string strBack = lblBackgroundGValMode.Text.Substring(BackIndex + 1, BackLen - 1);

            OcrMaxTool.ForegroundGValMode = double.Parse(strFore);
            OcrMaxTool.BackgroundGValMode = double.Parse(strBack);


            if (cbxOcrSelect.Text == "一般字符")
                OcrMaxTool.OcrSelect = 0;
            if (cbxOcrSelect.Text == "一般字符光照不均匀")
                OcrMaxTool.OcrSelect = 1;
            if (cbxOcrSelect.Text == "喷码点状字符")
                OcrMaxTool.OcrSelect = 2;

            OcrMaxTool.MaskHeight = (int)nudMaskHeight.Value;
            OcrMaxTool.MaskWidth = (int)nudMaskWidth.Value;
            OcrMaxTool.Offset = (int)nudOffset.Value;
            OcrMaxTool.LightDrak = cbxLightDrak.Text;
            OcrMaxTool.RegionName = cbxRegion.Text;


        }
        void Cancel()
        {
            takBarLowThreshold.Scroll -= new EventHandler(takBar_low_Scroll);
            takBarHigThreshold.Scroll -= new EventHandler(takBar_higt_Scroll);
            hSrlBarAreaMin.Scroll -= new ScrollEventHandler(hSrlBar_areaMin_Scroll);
            hSrlBarAreaMax.Scroll -= new ScrollEventHandler(hSrlBar_areaMax_Scroll);

            cbxSetdraw.SelectedIndexChanged -= new EventHandler(cbxSetdraw_SelectedIndexChanged);
            cebxIsSelectedRegions.CheckedChanged -= new EventHandler(cebxIsSelectedRegions_CheckedChanged);
            cebxIsRectangle.CheckedChanged -= new EventHandler(cebxIsRectangle_CheckedChanged);
            nudPartitionWith.ValueChanged -= new EventHandler(nudPartitionWith_ValueChanged);
            nudPartitionHeight.ValueChanged -= new EventHandler(nudPartitionHeight_ValueChanged);
            nudDilationWidth.ValueChanged -= new EventHandler(nudDilationWidth_ValueChanged);
            nudDilationHeight.ValueChanged -= new EventHandler(nudDilationHeight_ValueChanged);
            cebxIsback.CheckedChanged -= new EventHandler(cebxIsback_CheckedChanged);
            //cebxIsOcrSelect.CheckedChanged -= new EventHandler(cebxIsOcrSelect_CheckedChanged);
            cbxFileName.SelectedIndexChanged -= new EventHandler(cbxFileName_SelectedIndexChanged);
            cebxFixture.CheckedChanged -= new EventHandler(cebxFixture_CheckedChanged);

            cbxOcrSelect.SelectedIndexChanged -= new EventHandler(cbxOcrSelect_SelectedIndexChanged);
            cbxLightDrak.SelectedIndexChanged -= new EventHandler(cbxOcrSelect_SelectedIndexChanged);
            nudMaskHeight.ValueChanged -= new EventHandler(nudMaskHeight_ValueChanged);
            nudMaskWidth.ValueChanged -= new EventHandler(nudMaskWidth_ValueChanged);
            nudOffset.ValueChanged -= new EventHandler(nudOffset_ValueChanged);
            cebxIsRegion.CheckedChanged -= new EventHandler(cebxRegion_CheckedChanged);
        }
        void Register()
        {
            takBarLowThreshold.Scroll += new EventHandler(takBar_low_Scroll);
            takBarHigThreshold.Scroll += new EventHandler(takBar_higt_Scroll);
            hSrlBarAreaMin.Scroll += new ScrollEventHandler(hSrlBar_areaMin_Scroll);
            hSrlBarAreaMax.Scroll += new ScrollEventHandler(hSrlBar_areaMax_Scroll);

            cbxSetdraw.SelectedIndexChanged += new EventHandler(cbxSetdraw_SelectedIndexChanged);
            cebxIsSelectedRegions.CheckedChanged += new EventHandler(cebxIsSelectedRegions_CheckedChanged);
            cebxIsRectangle.CheckedChanged += new EventHandler(cebxIsRectangle_CheckedChanged);

            nudPartitionWith.ValueChanged += new EventHandler(nudPartitionWith_ValueChanged);
            nudPartitionHeight.ValueChanged += new EventHandler(nudPartitionHeight_ValueChanged);
            nudDilationWidth.ValueChanged += new EventHandler(nudDilationWidth_ValueChanged);
            nudDilationHeight.ValueChanged += new EventHandler(nudDilationHeight_ValueChanged);
            cebxIsback.CheckedChanged += new EventHandler(cebxIsback_CheckedChanged);
            //cebxIsOcrSelect.CheckedChanged += new EventHandler(cebxIsOcrSelect_CheckedChanged);
            cbxFileName.SelectedIndexChanged += new EventHandler(cbxFileName_SelectedIndexChanged);
            cebxFixture.CheckedChanged += new EventHandler(cebxFixture_CheckedChanged);

            cbxOcrSelect.SelectedIndexChanged += new EventHandler(cbxOcrSelect_SelectedIndexChanged);
            cbxLightDrak.SelectedIndexChanged += new EventHandler(cbxOcrSelect_SelectedIndexChanged);
            nudMaskHeight.ValueChanged += new EventHandler(nudMaskHeight_ValueChanged);
            nudMaskWidth.ValueChanged += new EventHandler(nudMaskWidth_ValueChanged);
            nudOffset.ValueChanged += new EventHandler(nudOffset_ValueChanged);
            cebxIsRegion.CheckedChanged += new EventHandler(cebxRegion_CheckedChanged);

        }
        private void frm_Blob_Load(object sender, EventArgs e)
        {
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.TopMost = true;
            this.FormClosing += frm_Blob_FormClosing;
            string[] roi = new string[] { ImageTool.Roi.方向矩形.ToString(), BlobTool.Roi.矩形.ToString(), BlobTool.Roi.圆.ToString() };
            cbxRoi.Items.AddRange(roi);
            this.OcrMaxTool.hWindowControl1 = hWindowControl1;
            this.TopMost = false;
            select_mode();

        }

        void frm_Blob_FormClosing(object sender, FormClosingEventArgs e)
        {
            fo = null;
        }
        private void tbx_toolName_TextChanged(object sender, EventArgs e)
        {
            this.OcrMaxTool.Names = ImageTool.Tool.字符识别检测.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;

        }
        private void cbx_image_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  halconView1.DispImage((HObject)this.OcrMaxTool.Image[cbxImage.Text], true);
           // halconView1.FitImage();
            OcrMaxTool.ImageName = cbxImage.Text;
        }
        private void takBar_low_Scroll(object sender, EventArgs e)
        {
            lbl_low.Text = "低阀值:" + takBarLowThreshold.Value.ToString();
            OcrMaxTool.LowThreshold = takBarLowThreshold.Value;
            OcrMaxTool.set_after();


        }
        private void takBar_higt_Scroll(object sender, EventArgs e)
        {
            lbl_higt.Text = "高阀值:" + takBarHigThreshold.Value.ToString();
            OcrMaxTool.HigThreshold = takBarHigThreshold.Value;
            OcrMaxTool.set_after();

        }
        private void hSrlBar_areaMin_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                lbl_areaMin.Text = "最小面积限定:" + hSrlBarAreaMin.Value.ToString();
                if (hSrlBarAreaMin.Value < 9900)
                {
                    hSrlBarAreaMin.Maximum = 10000;
                }
                else
                {
                    hSrlBarAreaMin.Maximum = 999999;
                }
                OcrMaxTool.Select_shapeMin = hSrlBarAreaMin.Value;
                OcrMaxTool.set_after();

            }
            catch { }
        }
        private void hSrlBar_areaMax_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                lbl_areaMax.Text = "最大面积限定：" + hSrlBarAreaMax.Value.ToString();
                if (hSrlBarAreaMax.Value < 9900)
                {
                    hSrlBarAreaMax.Maximum = 10000;
                }
                else
                {
                    hSrlBarAreaMax.Maximum = 999999;
                }
                OcrMaxTool.Select_shapeMax = hSrlBarAreaMax.Value;
                OcrMaxTool.set_after();

            }
            catch { }
        }
        private void cbx_roi_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcrMaxTool.SetdrawShape = cbxRoi.Text;
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            try
            {
                long timer = OcrMaxTool.set_after();
                lblResult.Text = "FAIL";
                lblResult.BackColor = Color.Red;
              //  halconView1.ToolLable2.Text = "FAIL";
               // halconView1.ToolLable2.ForeColor = Color.Red;
                if (this.OcrMaxTool.ResultLogic)
                {
                    lblResult.Text = "PASS";
                    lblResult.BackColor = Color.LimeGreen;
                    //halconView1.ToolLable2.Text = "PASS";
                   // halconView1.ToolLable2.ForeColor = Color.Lime;
                }
                lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
               // halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
                DataGridView(dataGridView1, OcrMaxTool.ResultClass, OcrMaxTool.ResultConfidence);//结果输出
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
                this.SetVal(ref this.OcrMaxTool);
                this.Hide();
                fo = null;
                handleSetval(this.OcrMaxTool);
            }
            catch
            {
                this.Hide();
                fo = null;
                handleSetval(this.OcrMaxTool);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            fo = null;
        }
        private void btn_drawRoi_Click(object sender, EventArgs e)
        {
            if (cbxRoi.Text == BlobTool.Roi.方向矩形.ToString())
                OcrMaxTool.SetdrawShape = BlobTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.矩形.ToString())
                OcrMaxTool.SetdrawShape = BlobTool.Roi.矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.圆.ToString())
                OcrMaxTool.SetdrawShape = BlobTool.Roi.圆.ToString();
           // halconView1.Focus();
            //halconView1.ContextMenuStripHide();
            OcrMaxTool.draw_roi();
            lblBackgroundGValMode.Text = "BackVal:" + OcrMaxTool.BackgroundGValMode.ToString();
            lblForegroundGValMode.Text = "ForeVal:" + OcrMaxTool.ForegroundGValMode.ToString();
        }
        private void cebxIsSelectedRegions_CheckedChanged(object sender, EventArgs e)
        {
            OcrMaxTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
            OcrMaxTool.set_after();
            //DataGridView(dataGridView1, OcrMaxTool.ResultArea, OcrMaxTool.ResultRow, OcrMaxTool.ResultCol);//结果输出
        }

        private void cebxIsRectangle_CheckedChanged(object sender, EventArgs e)
        {
            OcrMaxTool.IsRectangle = cebxIsRectangle.Checked;
            OcrMaxTool.set_after();
            //DataGridView(dataGridView1, OcrMaxTool.ResultArea, OcrMaxTool.ResultRow, OcrMaxTool.ResultCol);//结果输出
        }
        private void cbxSetdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcrMaxTool.Setdraw = cbxSetdraw.Text;
            OcrMaxTool.set_after();
            //DataGridView(dataGridView1, OcrMaxTool.ResultArea, OcrMaxTool.ResultRow, OcrMaxTool.ResultCol);//结果输出
        }

        //结果输出
        private void DataGridView(DataGridView dataGridView, HTuple result_char, HTuple result_Confidence)
        {
            try
            {
                string str_Chars, str_Confidence;
                dataGridView.Columns.Clear();//
                dataGridView.Columns.Add("", "字符");//
                dataGridView.Columns.Add("", "分数");//
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                for (int i = 0; i < result_Confidence.Length; i++)
                {
                    dataGridView.Rows.Add(1);//加载row
                    ;//row表头ID
                    dataGridView.Rows[i].HeaderCell.Value = i.ToString();//row表头
                    ;//表格赋值
                    str_Chars = result_char.TupleSelect(i).TupleString("0");//表格赋值col(0)
                    str_Confidence = result_Confidence.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(1)
                    dataGridView.Rows[i].Cells[0].Value = str_Chars; ;//表格赋值col(2)
                    dataGridView.Rows[i].Cells[1].Value = str_Confidence; ;//表格赋值col(0)
                }
            }
            catch { }
        }
        private void nudLowNum_ValueChanged(object sender, EventArgs e)
        {
            OcrMaxTool.LowNums = (int)nudLowNum.Value;
        }

        private void nudHigNum_ValueChanged(object sender, EventArgs e)
        {
            OcrMaxTool.HigNums = (int)nudHigNum.Value;
        }
        private void cebxNums_CheckedChanged(object sender, EventArgs e)
        {
            OcrMaxTool.IsNums = cebxNums.Checked;
        }

        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcrMaxTool.FixNames = cbxFixture.Text;
        }

        private void nudPartitionWith_ValueChanged(object sender, EventArgs e)
        {
            OcrMaxTool.PartitionWidth = (int)nudPartitionWith.Value;
            OcrMaxTool.set_after();

        }

        private void nudPartitionHeight_ValueChanged(object sender, EventArgs e)
        {
            OcrMaxTool.PartitionHeight = (int)nudPartitionHeight.Value;
            OcrMaxTool.set_after();

        }

        private void nudDilationWidth_ValueChanged(object sender, EventArgs e)
        {
            OcrMaxTool.DilationWidth = (int)nudDilationWidth.Value;
            OcrMaxTool.set_after();

        }

        private void nudDilationHeight_ValueChanged(object sender, EventArgs e)
        {
            OcrMaxTool.DilationHeight = (int)nudDilationHeight.Value;
            OcrMaxTool.set_after();

        }

        private void cbxFileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcrMaxTool.FileName = cbxFileName.Text;
            OcrMaxTool.set_after();

        }
        private void cebxIsOcrSelect_CheckedChanged(object sender, EventArgs e)
        {
            //OcrMaxTool.IsOcrSelect = cebxIsOcrSelect.Checked;
            //cebxIsOcrSelect.Text = "普通字符";
            //if (OcrMaxTool.IsOcrSelect)
            //    cebxIsOcrSelect.Text = "点状字符";
            //OcrMaxTool.set_after();
        }

        private void cebxIsback_CheckedChanged(object sender, EventArgs e)
        {
            OcrMaxTool.IsBack = cebxIsback.Checked;
            cebxIsback.Text = "白字黑背景";
            if (OcrMaxTool.IsBack)
                cebxIsback.Text = "黑字白背景";
            OcrMaxTool.set_after();

        }
        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            OcrMaxTool.IsFixture = cebxFixture.Checked;
        }

        private void cbxOcrSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

            select_mode();
            //if (OcrMaxTool.OcrSelect == 0)
            //    cbxOcrSelect.Text = "一般字符";
            //if (OcrMaxTool.OcrSelect == 1)
            //    cbxOcrSelect.Text = "一般字符光照不均匀";
            //if (OcrMaxTool.OcrSelect == 2)
            //    cbxOcrSelect.Text = "喷码点状字符";
            OcrMaxTool.set_after();

        }

        private void nudMaskWidth_ValueChanged(object sender, EventArgs e)
        {
            OcrMaxTool.MaskHeight = (int)nudMaskHeight.Value;
            OcrMaxTool.set_after();
        }

        private void nudMaskHeight_ValueChanged(object sender, EventArgs e)
        {
            OcrMaxTool.MaskHeight = (int)nudMaskHeight.Value;
            OcrMaxTool.set_after();
        }

        private void nudOffset_ValueChanged(object sender, EventArgs e)
        {
            OcrMaxTool.Offset = (int)nudOffset.Value;
            OcrMaxTool.set_after();
        }

        private void cbxLightDrak_SelectedIndexChanged(object sender, EventArgs e)
        {
            OcrMaxTool.LightDrak = cbxLightDrak.Text;
            OcrMaxTool.set_after();
        }

        private void cebxIllumination_CheckedChanged(object sender, EventArgs e)
        {
            OcrMaxTool.IsIllumination = cebxIllumination.Checked;
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            OcrMaxTool.dispresult();
        }

        private void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, cbxSetdraw.Text);
            HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
            OcrMaxTool.RegionName = cbxRegion.Text;
            HSystem.SetSystem("flush_graphic", "true");
         //   halconView1.DispImage((HObject)this.OcrMaxTool.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
          //  halconView1.DispObject((HObject)this.OcrMaxTool.Region[cbxRegion.Text]);
            HSystem.SetSystem("flush_graphic", "false");
        }

        private void cebxRegion_CheckedChanged(object sender, EventArgs e)
        {
            OcrMaxTool.IsRegion = cebxIsRegion.Checked;
            OcrMaxTool.set_after();
        }
        void select_mode()
        {
            if (cbxOcrSelect.Text == "一般字符")
            {
                OcrMaxTool.OcrSelect = 0;
                takBarLowThreshold.Visible = true;
                takBarHigThreshold.Visible = true;
                lbl_low.Visible = true;
                lbl_higt.Visible = true;
                groupBox5.Visible = false;
                groupBox4.Visible = true;
            }
            if (cbxOcrSelect.Text == "一般字符光照不均匀")
            {
                OcrMaxTool.OcrSelect = 1;
                lbl_low.Visible = false;
                lbl_higt.Visible = false;
                takBarLowThreshold.Visible = false;
                takBarHigThreshold.Visible = false;
                groupBox5.Visible = true;
                groupBox4.Visible = false;

                OcrMaxTool.MaskHeight = (int)nudMaskHeight.Value;
                OcrMaxTool.Offset = (int)nudOffset.Value;
                OcrMaxTool.LightDrak = cbxLightDrak.Text;
                OcrMaxTool.MaskWidth = (int)nudMaskWidth.Value;
            }
            if (cbxOcrSelect.Text == "喷码点状字符")
            {
                OcrMaxTool.OcrSelect = 2;
                lbl_low.Visible = true;
                lbl_higt.Visible = true;
                takBarLowThreshold.Visible = true;
                takBarHigThreshold.Visible = true;

                groupBox5.Visible = false;
                groupBox4.Visible = true;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
