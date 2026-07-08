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
    public partial class frm_InspectionBallBonding : Form
    {
        static frm_InspectionBallBonding frm;
        InspectionBallBondingTool inspBallBonding = new InspectionBallBondingTool();
        public delegate void HandledSetVal(InspectionBallBondingTool inspBallBonding);
        HandledSetVal handleSetval;
        Image image;
        bool isDrawRoi;
        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_InspectionBallBonding SingleShow(InspectionBallBondingTool inspBallBonding, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_InspectionBallBonding(inspBallBonding, handleSetval);
            }
            return frm;
        }

        public  frm_InspectionBallBonding()
        {
            InitializeComponent();
        }
        public frm_InspectionBallBonding(InspectionBallBondingTool inspBallBonding, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            DisplayVal(inspBallBonding);
            this.inspBallBonding.Image = inspBallBonding.Image;
            this.inspBallBonding.ROI = inspBallBonding.ROI;
            this.inspBallBonding.RoiPath = inspBallBonding.RoiPath;
            this.inspBallBonding.Circle = inspBallBonding.Circle;
            this.inspBallBonding.Rectangle1 = inspBallBonding.Rectangle1;
            this.inspBallBonding.Rectangle2 = inspBallBonding.Rectangle2;
            this.inspBallBonding.HtHomMat2D = inspBallBonding.HtHomMat2D;
            this.SetVal(ref this.inspBallBonding);
         }
        void DisplayVal(InspectionBallBondingTool inspBallBonding)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = inspBallBonding.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = inspBallBonding.Names.Substring(nameIndex + 1, inspBallBonding.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = inspBallBonding.Names;
                    tbxToolName.Text = inspBallBonding.Names;
                }
                cbxImage.Text = inspBallBonding.ImageName;//
                takBarLowThreshold.Value = inspBallBonding.MinGray;
                lbl_low.Text = "低阀值:" + takBarLowThreshold.Value.ToString();
                takBarHigThreshold.Value = inspBallBonding.MaxGray;
                lbl_higt.Text = "高阀值:" + takBarHigThreshold.Value.ToString();
                hSrlBarAreaMax.Value = inspBallBonding.FillUpshapeMax;
                lbl_areaMax.Text = "最大面积填补限定:" + hSrlBarAreaMax.Value.ToString();
                hSrlBarAreaMin.Value = inspBallBonding.FillUpshapeMin;
                lbl_areaMin.Text = "最小面积填补限定:" + hSrlBarAreaMin.Value.ToString();
                cbxRoi.Text = inspBallBonding.SetdrawShape;
                cbxSetdraw.Text = inspBallBonding.Setdraw;
           
                cebxIsCross.Checked = inspBallBonding.IsCross;
               

                nudLowAera.Value = Convert.ToDecimal(inspBallBonding.LowDiameter.D);
                nudHigAera.Value = Convert.ToDecimal(inspBallBonding.HigDiameter.D);
                nudLowNum.Value = Convert.ToDecimal(inspBallBonding.LowNums.I);
                nudHigNum.Value = Convert.ToDecimal(inspBallBonding.HigNums.I);
            
                nudOpeningCircle.Value = Convert.ToDecimal(inspBallBonding.OpeningCircle.D);

                cebxDiameter.Checked = inspBallBonding.IsDiameter;
                cebxNums.Checked = inspBallBonding.IsNums;
                cebxFixture.Checked = inspBallBonding.IsFixture;
                cbxFixture.Text = inspBallBonding.FixNames;
                cbxImage.Items.Clear();
                dispPath(inspBallBonding);
                if (inspBallBonding.Image != null)
                {
                    foreach (var item in inspBallBonding.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
               // halconView1.DispImage((HObject)inspBallBonding.Image[cbxImage.Text], true);
             //   halconView1.FitImage();
                cbxFixture.Items.Clear();
                if (inspBallBonding.HtHomMat2D != null)
                {
                    foreach (var item in inspBallBonding.HtHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();//注册事件
            }
            catch
            {
                cbxImage.Items.Clear();
                if (inspBallBonding.Image != null)
                {
                    foreach (var item in inspBallBonding.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (inspBallBonding.HtHomMat2D != null)
                {
                    foreach (var item in inspBallBonding.HtHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();//注册事件}
            }
        }
        void SetVal(ref InspectionBallBondingTool inspBallBonding)
        {
            inspBallBonding.Names = ImageTool.Tool.焊点检测.ToString() + "_" + tbxToolName.Text;
            inspBallBonding.ImageName = cbxImage.Text;
            inspBallBonding.MinGray = takBarLowThreshold.Value;
            inspBallBonding.MaxGray = takBarHigThreshold.Value;
            inspBallBonding.FillUpshapeMin = hSrlBarAreaMin.Value;
            inspBallBonding.FillUpshapeMax = hSrlBarAreaMax.Value;
            inspBallBonding.OpeningCircle = (double )nudOpeningCircle.Value;
            inspBallBonding.SetdrawShape = cbxRoi.Text;
            inspBallBonding.Setdraw = cbxSetdraw.Text;
            inspBallBonding.IsCross = cebxIsCross.Checked;
         

            inspBallBonding.LowDiameter = (double )nudLowAera.Value;
            inspBallBonding.HigDiameter = (double )nudHigAera.Value;
            inspBallBonding.LowNums = (int)nudLowNum.Value;
            inspBallBonding.HigNums = (int)nudHigNum.Value;
            inspBallBonding.IsDiameter = cebxDiameter.Checked;
            inspBallBonding.IsNums = cebxNums.Checked;
            inspBallBonding.FixNames = cbxFixture.Text;
            inspBallBonding.IsFixture = cebxFixture.Checked;

      
        }
        void Cancel() 
        {
            takBarLowThreshold.Scroll -= new EventHandler(takBar_low_Scroll);
            takBarHigThreshold.Scroll -= new EventHandler(takBar_higt_Scroll);
            hSrlBarAreaMin.Scroll -= new ScrollEventHandler(hSrlBar_areaMin_Scroll);
            hSrlBarAreaMax.Scroll -= new ScrollEventHandler(hSrlBar_areaMax_Scroll);
            nudOpeningCircle.ValueChanged -= new EventHandler(nudOpeningCircle_ValueChanged);
            cbxSetdraw.SelectedIndexChanged -= new EventHandler(cbxSetdraw_SelectedIndexChanged);
            cebxIsCross.CheckedChanged -= new EventHandler(cebxIsCross_CheckedChanged);
          
           
        }
        void Register()
        {
            takBarLowThreshold.Scroll += new EventHandler(takBar_low_Scroll);
            takBarHigThreshold.Scroll += new EventHandler(takBar_higt_Scroll);
            hSrlBarAreaMin.Scroll += new ScrollEventHandler(hSrlBar_areaMin_Scroll);
            hSrlBarAreaMax.Scroll += new ScrollEventHandler(hSrlBar_areaMax_Scroll);
            nudOpeningCircle.ValueChanged += new EventHandler(nudOpeningCircle_ValueChanged);
            cbxSetdraw.SelectedIndexChanged += new EventHandler(cbxSetdraw_SelectedIndexChanged);
            cebxIsCross.CheckedChanged += new EventHandler(cebxIsCross_CheckedChanged);
                
        }
        private void frm_InspectionBallBonding_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
            this.FormClosing += frm_InspectionBallBonding_FormClosing;
            this.inspBallBonding.hWindowControl1 = hWindowControl1;
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
        void frm_InspectionBallBonding_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
        private void tbx_toolName_TextChanged(object sender, EventArgs e)
        {
            this.inspBallBonding.Names = ImageTool.Tool.焊点检测.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        
        }
        private void cbx_image_SelectedIndexChanged(object sender, EventArgs e)
        {
           // halconView1.DispImage((HObject)this.inspBallBonding.Image[cbxImage.Text], true);
           // halconView1.FitImage();
            inspBallBonding.ImageName = cbxImage.Text;
        }
        private void takBar_low_Scroll(object sender, EventArgs e)
        {
            lbl_low.Text = "低阀值:" + takBarLowThreshold.Value.ToString();
            inspBallBonding.MinGray = takBarLowThreshold.Value;
            inspBallBonding.set_after();
        //    DataGridView(dataGridView1, inspBallBonding.ResultArea, inspBallBonding.ResultRow, inspBallBonding.ResultCol);//结果输出
          
        }
        private void takBar_higt_Scroll(object sender, EventArgs e)
        {
            lbl_higt.Text = "高阀值:" + takBarHigThreshold.Value.ToString();
            inspBallBonding.MaxGray = takBarHigThreshold.Value;
            inspBallBonding.set_after();
         //   DataGridView(dataGridView1, inspBallBonding.ResultArea, inspBallBonding.ResultRow, inspBallBonding.ResultCol);//结果输出
        }
        private void hSrlBar_areaMin_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                lbl_areaMin.Text = "最小面积填补限定:" + hSrlBarAreaMin.Value.ToString();
                if (hSrlBarAreaMin.Value < 9999)
                {
                    hSrlBarAreaMin.Maximum = 10000;
                }
                else
                {
                    hSrlBarAreaMin.Maximum = 100000;
                }
                inspBallBonding.FillUpshapeMin = hSrlBarAreaMin.Value;
                inspBallBonding.set_after();
            //  DataGridView(dataGridView1, inspBallBonding.ResultArea, inspBallBonding.ResultRow, inspBallBonding.ResultCol);//结果输出
            }
            catch { }
        }
        private void hSrlBar_areaMax_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {

                lbl_areaMax.Text = "最大面积填补限定：" + hSrlBarAreaMax.Value.ToString();
                if (hSrlBarAreaMax.Value < 9999)
                {
                    hSrlBarAreaMax.Maximum = 10000;
                }
                else
                {
                    hSrlBarAreaMax.Maximum = 100000;
                }
                inspBallBonding.FillUpshapeMax = hSrlBarAreaMax.Value;
                inspBallBonding.set_after();
             //   DataGridView(dataGridView1, inspBallBonding.ResultArea, inspBallBonding.ResultRow, inspBallBonding.ResultCol);//结果输出
            }
            catch { }
        }
        private void nudOpeningCircle_ValueChanged(object sender, EventArgs e)
        {
            inspBallBonding.OpeningCircle = (double )nudOpeningCircle.Value;
            inspBallBonding.set_after();
        }
        private void cbx_roi_SelectedIndexChanged(object sender, EventArgs e)
        {
            inspBallBonding.SetdrawShape = cbxRoi.Text;
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            long timer = inspBallBonding.set_after();
            lblResult.Text = "FAIL";
            lblResult.BackColor = Color.Red;
           // halconView1.ToolLable2.Text = "FAIL";
           // halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.inspBallBonding.ResultLogic)
            {
                lblResult.Text = "PASS";
                lblResult.BackColor = Color.LimeGreen;
              //  halconView1.ToolLable2.Text = "PASS";
              //  halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
           // halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
            DataGridView(dataGridView1, inspBallBonding.ResultRadius, inspBallBonding.ResultDiameter, inspBallBonding.ResultRowCenter, inspBallBonding.ResultColCenter);//结果输出
          }
        private void btn_sure_Click(object sender, EventArgs e)
        {  try
            {
                if(isDrawRoi)//是否绘制Roi
                {
                    if (DialogResult.Yes == MessageBox.Show("ROI区域是否保存!", "ROI保存", MessageBoxButtons.YesNo))
                    {
                        this.inspBallBonding.SaveRoi();
                    }
                    isDrawRoi = false;
                }
                this.SetVal(ref this.inspBallBonding);
                this.Hide();
                frm = null;
                handleSetval(this.inspBallBonding);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.inspBallBonding);
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
                isDrawRoi = false;
                inspBallBonding.RoiClear();
             //   halconView1.DispImage((HObject)this.inspBallBonding.Image[cbxImage.Text], true);
              //  halconView1.FitImage();
                inspBallBonding.ImageName = cbxImage.Text;
            }
        }
        private void btn_drawRoi_Click(object sender, EventArgs e)
        {
            isDrawRoi = false;
            if (cbxRoi.Text == BlobTool.Roi.方向矩形.ToString())
                inspBallBonding.SetdrawShape = BlobTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.矩形.ToString())
                inspBallBonding.SetdrawShape = BlobTool.Roi.矩形.ToString();
            if (cbxRoi.Text == BlobTool.Roi.圆.ToString())
                inspBallBonding.SetdrawShape = BlobTool.Roi.圆.ToString();
           // halconView1.Focus();
            inspBallBonding.RegionType = cbxRegion.Text;
          //  halconView1.ContextMenuStripHide();
            inspBallBonding.draw_roi();
            isDrawRoi = true;
        }
      
        private void cebxIsCross_CheckedChanged(object sender, EventArgs e)
        {
            inspBallBonding.IsCross = cebxIsCross.Checked;
            inspBallBonding.set_after();
          //  DataGridView(dataGridView1, inspBallBonding.ResultArea, inspBallBonding.ResultRow, inspBallBonding.ResultCol);//结果输出
        }
       
        private void cbxSetdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
            inspBallBonding.Setdraw = cbxSetdraw.Text;
            inspBallBonding.set_after();
          //  DataGridView(dataGridView1, inspBallBonding.ResultArea, inspBallBonding.ResultRow, inspBallBonding.ResultCol);//结果输出
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

        private void nudLowAera_ValueChanged(object sender, EventArgs e)
        {
            inspBallBonding.LowDiameter = (double )nudLowAera.Value;
        }
       private void nudHigAera_ValueChanged(object sender, EventArgs e)
        {
             inspBallBonding.HigDiameter = (double)nudHigAera.Value;
        }

        private void nudLowNum_ValueChanged(object sender, EventArgs e)
        {
            inspBallBonding.LowNums = (int)nudLowNum.Value;
        }

        private void nudHigNum_ValueChanged(object sender, EventArgs e)
        {
            inspBallBonding.HigNums = (int)nudHigNum.Value;
        }

        private void cebxDiameter_CheckedChanged(object sender, EventArgs e)
        {
            inspBallBonding.IsDiameter = cebxDiameter.Checked;
        }

        private void cebxNums_CheckedChanged(object sender, EventArgs e)
        {
            inspBallBonding.IsNums = cebxNums.Checked;
        }

        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
            inspBallBonding.FixNames = cbxFixture.Text;
        }

        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            inspBallBonding.IsFixture = cebxFixture.Checked;
        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            inspBallBonding.dispresult();
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
            inspBallBonding.ReadRoi();
            dispPath(inspBallBonding);
        }

        private void btnSaveRoi_Click(object sender, EventArgs e)
        {
            inspBallBonding.SaveRoi();
            dispPath(inspBallBonding);
        }
        string RoiPath;
        void dispPath(InspectionBallBondingTool inspBallBonding)
        {
            try
            {
                int Debug = inspBallBonding.RoiPath.LastIndexOf("Debug");//是否是debug下的文件
                RoiPath = inspBallBonding.RoiPath;
                if (Debug != -1)
                {
                    string bugPath = inspBallBonding.RoiPath.Substring(Debug + 6, inspBallBonding.RoiPath.Length - (Debug + 6));//截取Debug下的文件,例如 原路径 C://Debug//1
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
            inspBallBonding.ReadRoi(RoiPath);
        }

   

      
    }
}
