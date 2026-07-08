
using ComboBox_Draw;
using HalconDotNet;
using System;
using System.Collections;
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
    public partial class frm_Blob : Form
    {
 
        static frm_Blob frm;
        BlobTool blobTool = new BlobTool();
        public delegate void HandledSetVal(BlobTool blobTool);
        HandledSetVal handleSetval;
        Image image;
        bool isDrawRoi;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_Blob SingleShow(BlobTool blobTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_Blob(blobTool, handleSetval);
            }
            return frm;
        }
        public  frm_Blob()
        {
            InitializeComponent();
        }
        public frm_Blob(BlobTool blobTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(blobTool);
            this.blobTool.Image = blobTool.Image;
            this.blobTool.ROI = blobTool.ROI;
            this.blobTool.RoiPath = blobTool.RoiPath;
            this.blobTool.Circle = blobTool.Circle;
            this.blobTool.Rectangle1 = blobTool.Rectangle1;
            this.blobTool.Rectangle2 = blobTool.Rectangle2;
            this.blobTool.DicHomMat2D = blobTool.DicHomMat2D;
            this.SetVal(ref this.blobTool);
         }
        void DisplayVal(BlobTool blobTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = blobTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = blobTool.Names.Substring(nameIndex + 1, blobTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = blobTool.Names;
                    tbxToolName.Text = blobTool.Names;
                }
                cbxImage.Text = blobTool.ImageName;//
                takBarLowThreshold.Value = blobTool.LowThreshold;
                lbl_low.Text = "低阀值:" + takBarLowThreshold.Value.ToString();
                takBarHigThreshold.Value = blobTool.HigThreshold;
                lbl_higt.Text = "高阀值:" + takBarHigThreshold.Value.ToString();

                nudHigAera.Value = Convert.ToDecimal(blobTool.HigAera.I);
                nudLowAera.Value = Convert.ToDecimal(blobTool.LowAera.I);
                nudMinShapeAra.Value= Convert.ToDecimal(blobTool.SelectShapeMinAra.I);
                nudMaxShapeAra.Value = Convert.ToDecimal(blobTool.SelectShapeMaxAra.I);
                nudMinShapecircularity.Value = Convert.ToDecimal(blobTool.SelectShapeMincircularity.D);
                nudMaxShapecircularity.Value = Convert.ToDecimal(blobTool.SelectShapeMaxcircularity.D);

                cbxMorphlogy.Text = blobTool.Morphology;
                nudWith.Value = Convert.ToDecimal(blobTool.Width.I);
                nudHeiht.Value = Convert.ToDecimal(blobTool.Height.I); 


                cbxRoi.Text = blobTool.SetdrawShape;
                cbxSetdraw.Text = blobTool.Setdraw;
                cebxIsSelectedRegions.Checked = blobTool.IsSelectedRegions;
                cebxIsCross.Checked = blobTool.IsCross;
                cebxIsRectangle.Checked = blobTool.IsRectangle;
                cebxIsSelectConn.Checked = blobTool.IsSelect_conn;

                nudLowAera.Value = Convert.ToDecimal(blobTool.LowAera.I);
                nudHigAera.Value = Convert.ToDecimal(blobTool.HigAera.I);
                nudLowNum.Value = Convert.ToDecimal(blobTool.LowNums.I);
                nudHigNum.Value = Convert.ToDecimal(blobTool.HigNums.I);

                cebxArea.Checked = blobTool.IsAera;
                cebxNums.Checked = blobTool.IsNums;
                cebxFixture.Checked = blobTool.IsFixture;
                cbxFixture.Text = blobTool.FixNames;
                ceboxIsRoi.Checked = blobTool.IsRoi;

                cbxImage.Items.Clear();
                dispPath(blobTool);
                if (blobTool.Image != null)
                {
                    foreach (var item in blobTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                //halconView1.DispImage((HObject)blobTool.Image[cbxImage.Text], true);
               // halconView1.FitImage();
                cbxFixture.Items.Clear();
                if (blobTool.DicHomMat2D != null)
                {
                    foreach (var item in blobTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();//注册事件
            }
            catch
            {
                cbxImage.Items.Clear();
                if (blobTool.Image != null)
                {
                    foreach (var item in blobTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (blobTool.DicHomMat2D != null)
                {
                    foreach (var item in blobTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();//注册事件}
            }
        }
        void SetVal(ref BlobTool blobTool)
        {
            blobTool.Names = ImageTool.Tool.斑点分析.ToString() + "_" + tbxToolName.Text;
            blobTool.ImageName = cbxImage.Text;
            blobTool.LowThreshold = takBarLowThreshold.Value;
            blobTool.HigThreshold = takBarHigThreshold.Value;

            blobTool.SelectShapeMaxAra = (int)nudMaxShapeAra.Value;
            blobTool.SelectShapeMinAra = (int)nudMinShapeAra.Value;
            blobTool.SelectShapeMaxcircularity = (double)nudMaxShapecircularity.Value;
            blobTool.SelectShapeMincircularity = (double)nudMinShapecircularity.Value;

            blobTool.Morphology = cbxMorphlogy.Text;
            blobTool.Width = (int)nudWith.Value;
            blobTool.Height = (int)nudHeiht.Value;

            blobTool.SetdrawShape = cbxRoi.Text;
            blobTool.Setdraw = cbxSetdraw.Text;
            blobTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
            blobTool.IsCross = cebxIsCross.Checked;
            blobTool.IsRectangle = cebxIsRectangle.Checked;
            blobTool.IsSelect_conn = cebxIsSelectConn.Checked;

            blobTool.LowAera = (int)nudLowAera.Value;
            blobTool.HigAera = (int)nudHigAera.Value;
            blobTool.LowNums = (int)nudLowNum.Value;
            blobTool.HigNums = (int)nudHigNum.Value;
            blobTool.IsAera = cebxArea.Checked;
            blobTool.IsNums = cebxNums.Checked;

            blobTool.FixNames = cbxFixture.Text;
            blobTool.IsFixture = cebxFixture.Checked;
            blobTool.IsRoi = ceboxIsRoi.Checked;


        }
        void Cancel() 
        {
            takBarLowThreshold.Scroll -= new EventHandler(takBar_low_Scroll);
            takBarHigThreshold.Scroll -= new EventHandler(takBar_higt_Scroll);

            nudMaxShapeAra.ValueChanged -= new EventHandler(nudMaxShapeAra_ValueChanged);
            nudMinShapeAra.ValueChanged -= new EventHandler(nudMinShapeAra_ValueChanged);
            nudMaxShapecircularity.ValueChanged -= new EventHandler(nudMaxShapecircularity_ValueChanged);
            nudMinShapecircularity.ValueChanged -= new EventHandler(nudMinShapecircularity_ValueChanged);

            cbxMorphlogy.SelectedIndexChanged -= new EventHandler(cbxMorphlogy_SelectedIndexChanged);
            nudWith.ValueChanged -= new EventHandler(nudWith_ValueChanged);
            nudHeiht.ValueChanged -= new EventHandler(nudHeiht_ValueChanged);


            cbxSetdraw.SelectedIndexChanged -= new EventHandler(cbxSetdraw_SelectedIndexChanged);
            cebxIsSelectedRegions.CheckedChanged -= new EventHandler(cebxIsSelectedRegions_CheckedChanged);
            cebxIsCross.CheckedChanged -= new EventHandler(cebxIsCross_CheckedChanged);
            cebxIsRectangle.CheckedChanged -= new EventHandler(cebxIsRectangle_CheckedChanged);
            cebxIsSelectConn.CheckedChanged -= new EventHandler(cebxIsSelectConn_CheckedChanged);
            ceboxIsRoi.CheckedChanged -= new EventHandler(ceboxIsRoi_CheckedChanged);
        }
        void Register()
        {
            takBarLowThreshold.Scroll += new EventHandler(takBar_low_Scroll);
            takBarHigThreshold.Scroll += new EventHandler(takBar_higt_Scroll);

            nudMaxShapeAra.ValueChanged += new EventHandler(nudMaxShapeAra_ValueChanged);
            nudMinShapeAra.ValueChanged += new EventHandler(nudMinShapeAra_ValueChanged);
            nudMaxShapecircularity.ValueChanged += new EventHandler(nudMaxShapecircularity_ValueChanged);
            nudMinShapecircularity.ValueChanged += new EventHandler(nudMinShapecircularity_ValueChanged);

            cbxMorphlogy.SelectedIndexChanged += new EventHandler(cbxMorphlogy_SelectedIndexChanged);
            nudWith.ValueChanged += new EventHandler(nudWith_ValueChanged);
            nudHeiht.ValueChanged += new EventHandler(nudHeiht_ValueChanged);

            cbxSetdraw.SelectedIndexChanged += new EventHandler(cbxSetdraw_SelectedIndexChanged);
            cebxIsSelectedRegions.CheckedChanged += new EventHandler(cebxIsSelectedRegions_CheckedChanged);
            cebxIsCross.CheckedChanged += new EventHandler(cebxIsCross_CheckedChanged);
            cebxIsRectangle.CheckedChanged += new EventHandler(cebxIsRectangle_CheckedChanged);
            cebxIsSelectConn.CheckedChanged += new EventHandler(cebxIsSelectConn_CheckedChanged);
            ceboxIsRoi.CheckedChanged += new EventHandler(ceboxIsRoi_CheckedChanged);
        }
        private void frm_Blob_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.FormClosing += frm_Blob_FormClosing;
            this.blobTool.hWindowControl1 = hWindowControl1;
            image = Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_circle.png");
            cbxRoi.Items.Add(new MyItem(BlobTool.Roi.圆.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_circle.png")));
            cbxRoi.Items.Add(new MyItem(BlobTool.Roi.矩形.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_rect1.png")));
            cbxRoi.Items.Add(new MyItem(BlobTool.Roi.方向矩形.ToString(),Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_rect2.png")));
            cbxRoi.SelectedIndex = 1;
           //cbxRegion.Items.Add(new MyItem(BlobTool.Tool.区域创建.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_create.png")));
            cbxRegion.Items.Add(new MyItem(BlobTool.Tool.区域合并.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_op_union.png")));
            cbxRegion.Items.Add(new MyItem(BlobTool.Tool.区域交集.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_op_intersection.png")));
            cbxRegion.Items.Add(new MyItem(BlobTool.Tool.区域差集.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_op_difference.png")));
            cbxRegion.Items.Add(new MyItem(BlobTool.Tool.区域对称差.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_op_xor.png")));
            cbxRegion.SelectedIndex = 0;
        }
        void frm_Blob_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
        private void tbx_toolName_TextChanged(object sender, EventArgs e)
        {
            this.blobTool.Names = ImageTool.Tool.斑点分析.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        
        }
        private void cbx_image_SelectedIndexChanged(object sender, EventArgs e)
        {
           // halconView1.DispImage((HObject)this.blobTool.Image[cbxImage.Text], true);
           // halconView1.FitImage();
            blobTool.ImageName = cbxImage.Text;
        }
        private void takBar_low_Scroll(object sender, EventArgs e)
        {
            lbl_low.Text = "低阀值:" + takBarLowThreshold.Value.ToString();
            blobTool.LowThreshold = takBarLowThreshold.Value;
            blobTool.set_after();
            DataGridView(dataGridView1, blobTool.ResultArea, blobTool.ResultRow, blobTool.ResultCol);//结果输出
          
        }
        private void takBar_higt_Scroll(object sender, EventArgs e)
        {
            lbl_higt.Text = "高阀值:" + takBarHigThreshold.Value.ToString();
            blobTool.HigThreshold = takBarHigThreshold.Value;
            blobTool.set_after();
            DataGridView(dataGridView1, blobTool.ResultArea, blobTool.ResultRow, blobTool.ResultCol);//结果输出
        }
     
     
        private void cbx_roi_SelectedIndexChanged(object sender, EventArgs e)
        {
            blobTool.SetdrawShape = cbxRoi.Text;
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            try { 
            long timer = blobTool.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
          ///  halconView1.ToolLable2.Text = "FAIL";
          //  halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.blobTool.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
             //   halconView1.ToolLable2.Text = "PASS";
             //   halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
          //  halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            DataGridView(dataGridView1, blobTool.ResultArea, blobTool.ResultRow, blobTool.ResultCol);//结果输出
       
            }
            catch
            {
                MessageBox.Show("结果输出异常,查看设定参数！");
            }
        }
        private void btn_sure_Click(object sender, EventArgs e)
        {  try
            {
                if(isDrawRoi)//是否绘制Roi
                {
                    if (DialogResult.Yes == MessageBox.Show("ROI区域是否保存!", "ROI保存", MessageBoxButtons.YesNo))
                    {
                        this.blobTool.SaveRoi();
                    }
                    isDrawRoi = false;
                }
                this.SetVal(ref this.blobTool);
                this.Hide();
                frm = null;
                handleSetval(this.blobTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.blobTool);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }

        private void btnClearRoi_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("是否清除ROI区域", "清除ROI区域", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
            {
                blobTool.RoiClear();
                isDrawRoi = false;
             //   halconView1.DispImage((HObject)this.blobTool.Image[cbxImage.Text], true);
             //   halconView1.FitImage();
                blobTool.ImageName = cbxImage.Text;
            }
            //btnClearRoi.BackColor = Color.FromArgb(128, Color.Red);
        }
        private void btn_drawRoi_Click(object sender, EventArgs e)
        {
            isDrawRoi = false;
            if (cbxRoi.Text == BlobTool.Roi.方向矩形.ToString())
                blobTool.SetdrawShape = BlobTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.矩形.ToString())
                blobTool.SetdrawShape = BlobTool.Roi.矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.圆.ToString())
                blobTool.SetdrawShape = BlobTool.Roi.圆.ToString();
           // halconView1.Focus();
            blobTool.RegionType = cbxRegion.Text;
         ///   halconView1.ContextMenuStripHide();
            blobTool.draw_roi();
            isDrawRoi = true;
        }
        private void cebxIsSelectedRegions_CheckedChanged(object sender, EventArgs e)
        {
            blobTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
            blobTool.set_after();
            DataGridView(dataGridView1, blobTool.ResultArea, blobTool.ResultRow, blobTool.ResultCol);//结果输出
        }
        private void cebxIsCross_CheckedChanged(object sender, EventArgs e)
        {
            blobTool.IsCross = cebxIsCross.Checked;
            blobTool.set_after();
            DataGridView(dataGridView1, blobTool.ResultArea, blobTool.ResultRow, blobTool.ResultCol);//结果输出
        }
        private void cebxIsRectangle_CheckedChanged(object sender, EventArgs e)
        {
            blobTool.IsRectangle = cebxIsRectangle.Checked;
            blobTool.set_after();
            DataGridView(dataGridView1, blobTool.ResultArea, blobTool.ResultRow, blobTool.ResultCol);//结果输出
        }
        private void cbxSetdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
            blobTool.Setdraw = cbxSetdraw.Text;
            blobTool.set_after();
            DataGridView(dataGridView1, blobTool.ResultArea, blobTool.ResultRow, blobTool.ResultCol);//结果输出
        }
        private void cebxIsSelectConn_CheckedChanged(object sender, EventArgs e)
        {
            blobTool.IsSelect_conn = cebxIsSelectConn.Checked;
            blobTool.set_after();
            DataGridView(dataGridView1, blobTool.ResultArea, blobTool.ResultRow, blobTool.ResultCol);//结果输出

        }
         //结果输出
        private void DataGridView(DataGridView dataGridView, HTuple result_area, HTuple result_row, HTuple result_col)
        {
            try
            {
                string str_Areas, str_Rows, str_Cols;
                dataGridView.Columns.Clear();//
                dataGridView.Columns.Add("", "ResultArea");//
                dataGridView.Columns.Add("", "ResultRow");//
                dataGridView.Columns.Add("", "ResultCol");//
                for (int i = 0; i < result_row.Length; i++)
                {
                    dataGridView.Rows.Add(1);//加载row
                    ;//row表头ID
                    dataGridView.Rows[i].HeaderCell.Value = i.ToString();//row表头
                    ;//表格赋值
                    str_Areas = result_area.TupleSelect(i).TupleString("0.3f");//表格赋值col(0)
                    str_Rows = result_row.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(1)
                    str_Cols = result_col.TupleSelect(i).TupleString("0.3f"); ;//表格赋值col(2)

                    dataGridView.Rows[i].Cells[0].Value = str_Areas; ;//表格赋值col(2)
                    dataGridView.Rows[i].Cells[1].Value = str_Rows; ;//表格赋值col(0)
                    dataGridView.Rows[i].Cells[2].Value = str_Cols; ;//表格赋值col(1)
                }
            }
            catch { }
        }

        private void nudLowAera_ValueChanged(object sender, EventArgs e)
        {
            blobTool.LowAera = (int)nudLowAera.Value;
        }
       private void nudHigAera_ValueChanged(object sender, EventArgs e)
        {
             blobTool.HigAera = (int)nudHigAera.Value;
        }

        private void nudLowNum_ValueChanged(object sender, EventArgs e)
        {
            blobTool.LowNums = (int)nudLowNum.Value;
        }

        private void nudHigNum_ValueChanged(object sender, EventArgs e)
        {
            blobTool.HigNums = (int)nudHigNum.Value;
        }

        private void cebxArea_CheckedChanged(object sender, EventArgs e)
        {
            blobTool.IsAera = cebxArea.Checked;
        }

        private void cebxNums_CheckedChanged(object sender, EventArgs e)
        {
            blobTool.IsNums = cebxNums.Checked;
        }

        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
            blobTool.FixNames = cbxFixture.Text;
        }

        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            blobTool.IsFixture = cebxFixture.Checked;
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            blobTool.dispresult();
        }
          
         private void cbxRoi_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox combox = (ComboBox)sender;
            if (e.Index >= 0)
            {
                e.DrawBackground();
                // 判断是什么类型的标签  
                //if (cbxRoi.Items[e.Index].ToString().IndexOf(BlobTool.Roi.圆.ToString()) != -1)
                //    image = Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_circle.png");
                //if (cbxRoi.Items[e.Index].ToString().IndexOf(BlobTool.Roi.矩形.ToString()) != -1)
                //    image = Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_rect1.png");
                //if (cbxRoi.Items[e.Index].ToString().IndexOf(BlobTool.Roi.方向矩形.ToString()) != -1)
                //    image = Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_rect2.png");
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

        private void cbxRegion_DrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox combox = (ComboBox)sender;
            if (e.Index >= 0)
            {
                e.DrawBackground();
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

        private void btnAddRoi_Click(object sender, EventArgs e)
        {
            blobTool.ReadRoi();
            dispPath(blobTool);
        }

        private void btnSaveRoi_Click(object sender, EventArgs e)
        {
            blobTool.SaveRoi();
            dispPath(blobTool);
            isDrawRoi = false;
        }
        string RoiPath;
        void dispPath(BlobTool blobTool)
        {
            try
            {
                if (!blobTool.IsRoi) { return; }
                int Debug = blobTool.RoiPath.LastIndexOf("Debug");//是否是debug下的文件
                RoiPath = blobTool.RoiPath;
                if (Debug != -1)
                {
                    string bugPath = blobTool.RoiPath.Substring(Debug + 6, blobTool.RoiPath.Length - (Debug + 6));//截取Debug下的文件,例如 原路径 C://Debug//1
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
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            string path = this.RoiPath.Substring(0, this.RoiPath.Length - (this.RoiPath.Length - this.RoiPath.LastIndexOf("\\")));
            string RoiPath = path + @"\" + listBox.SelectedItem.ToString();
            lblRoiPath.Text = RoiPath;
            blobTool.ReadRoi(RoiPath);
        }

        private void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxMorphlogy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxToolName.Text = cbxMorphlogy.Text;
            this.blobTool.Names = ImageTool.Tool.斑点分析.ToString() + "_" + tbxToolName.Text;
            blobTool.Morphology = cbxMorphlogy.Text;
            if (cbxMorphlogy.Text.Contains("圆"))
            {
                lblHig.Visible = false;
                nudHeiht.Visible = false;
                lblWith.Text = "半径:";
            }
            else
            {
                lblHig.Visible = true;
                nudHeiht.Visible = true;
                lblWith.Text = "宽:";
            }
        }
        private void nudWith_ValueChanged(object sender, EventArgs e)
        {
            blobTool.Width = (int)nudWith.Value;
        }
        private void nudHeiht_ValueChanged(object sender, EventArgs e)
        {
            blobTool.Height = (int)nudHeiht.Value;
        }
        private void nudMinShapeAra_ValueChanged(object sender, EventArgs e)
        {
            blobTool.SelectShapeMinAra = (int)nudMinShapeAra.Value;
        }

        private void nudMaxShapeAra_ValueChanged(object sender, EventArgs e)
        {
            blobTool.SelectShapeMaxAra = (int)nudMaxShapeAra.Value;
        }
        private void nudMaxShapecircularity_ValueChanged(object sender, EventArgs e)
        {
            blobTool.SelectShapeMaxcircularity = (double)nudMaxShapecircularity.Value;
        }
        private void nudMinShapecircularity_ValueChanged(object sender, EventArgs e)
        {
            blobTool.SelectShapeMincircularity = (double)nudMinShapecircularity.Value;
        }

        private void ceboxIsRoi_CheckedChanged(object sender, EventArgs e)
        {
            blobTool.IsRoi = ceboxIsRoi.Checked;
            blobTool.set_after();
        }
    }
}
