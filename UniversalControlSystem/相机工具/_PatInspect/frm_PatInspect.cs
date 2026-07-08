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
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UniversalControlSystem
{
    public partial class frm_PatInspect : Form
    {
         static frm_PatInspect frm;
        PatInspectTool patInspectTool = new PatInspectTool();
        public delegate void HandledSetVal(PatInspectTool patInspectTool);
        HandledSetVal handleSetval;
        Image image;
        string ModelPath, RoiPath;
        bool isDrawRoi = false;

        /// <summary>
        /// 单实例
        /// </summary>
        /// <param name="fb"></param>
        public static frm_PatInspect SingleShow(PatInspectTool patInspectTool, HandledSetVal handleSetval)
        {
            if (frm == null)//
            {
                frm = new frm_PatInspect(patInspectTool, handleSetval);
            }
            return frm;
        }
        public frm_PatInspect(PatInspectTool patInspectTool, HandledSetVal handleSetval)
        {
            InitializeComponent();
            this.handleSetval = handleSetval;
            this.patInspectTool.Names = patInspectTool.Names;
            this.patInspectTool.Image = patInspectTool.Image;
            this.patInspectTool.ModelID = patInspectTool.ModelID;
            this.patInspectTool.ModelPath = patInspectTool.ModelPath;
            this.patInspectTool.RoiPath = patInspectTool.RoiPath;
            this.patInspectTool.ROI = patInspectTool.ROI;
            this.patInspectTool.Circle = patInspectTool.Circle;
            this.patInspectTool.Rectangle1 = patInspectTool.Rectangle1;
            this.patInspectTool.Rectangle2 = patInspectTool.Rectangle2;
            this.patInspectTool.DicHomMat2D = patInspectTool.DicHomMat2D;
            this.patInspectTool.DicHomMat2D1 = patInspectTool.DicHomMat2D1;
            this.patInspectTool.DicPhi = patInspectTool.DicPhi;
            DisplayVal(patInspectTool);
            SetVal(ref this.patInspectTool);
        }
        public frm_PatInspect()
        {
            InitializeComponent();
        }
        void DisplayVal(PatInspectTool patInspectTool)
        {
            try
            {
                Cancel();//注销事件
                int nameIndex = patInspectTool.Names.LastIndexOf("_");
                if (nameIndex != -1)
                {
                    string name = patInspectTool.Names.Substring(nameIndex + 1, patInspectTool.Names.Length - (nameIndex + 1));
                    this.Text = name;
                    tbxToolName.Text = name;
                }
                else
                {
                    this.Text = patInspectTool.Names;
                    tbxToolName.Text = patInspectTool.Names;
                }
                //创建
                cbxImage.Text = patInspectTool.ImageName;//
                cbxFixture.Text = patInspectTool.FixNames;
                cebxFixture.Checked = patInspectTool.IsFixture;
                nudScale.Value = Convert.ToDecimal(patInspectTool.Scale.I);
                nudDilation.Value = Convert.ToDecimal(patInspectTool.Dilation.I);
                nudAbsThreshold.Value = Convert.ToDecimal(patInspectTool.AbsThreshold.I);
                nudVarThreshold.Value = Convert.ToDecimal(patInspectTool.VarThreshold.I);
                nudSelectedRegionMin.Value = Convert.ToDecimal(patInspectTool.SelectedRegionMin.I);
                nudSelectedRegionMax.Value = Convert.ToDecimal(patInspectTool.SelectedRegionMax.I);
                cbxCompareMode.Text = patInspectTool.CompareMode;
                dispRoiPath(patInspectTool);
                dispModePath(patInspectTool);

                cbxSetdraw.Text = patInspectTool.Setdraw;
                cebxIsSelectedRegions.Checked = patInspectTool.IsSelectedRegions;
                cebxIsCross.Checked = patInspectTool.IsCross;
                cebxIsRectangle.Checked = patInspectTool.IsRectangle;

                cebxIllumination.Checked = patInspectTool.IsIllumination;
                cebxEdgeMod.Checked = patInspectTool.IsEdgeMod;

                if (patInspectTool.BackgroundGValMode != null)
                {
                    lblBackgroundGValMode.Text = "BackVal:" + patInspectTool.BackgroundGValMode.ToString();
                    lblForegroundGValMode.Text = "ForeVal:" + patInspectTool.ForegroundGValMode.ToString();
                }
           
                if (patInspectTool.Image != null)
                {
                    foreach (var item in patInspectTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                //halconView1.DispImage((HObject)patInspectTool.Image[cbxImage.Text], true);
               // halconView1.FitImage();
                cbxFixture.Items.Clear();
                if (patInspectTool.DicHomMat2D != null)
                {
                    foreach (var item in patInspectTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();
            }
            catch
            {
                if (patInspectTool.Image != null)
                {
                    foreach (var item in patInspectTool.Image.Keys)
                    {
                        cbxImage.Items.Add(item); //加载图像到下拉箱
                    }
                }
                cbxFixture.Items.Clear();
                if (patInspectTool.DicHomMat2D != null)
                {
                    foreach (var item in patInspectTool.DicHomMat2D.Keys)
                    {
                        cbxFixture.Items.Add(item); //加载
                    }
                }
                Register();

            }
        }
        void SetVal(ref PatInspectTool patInspectTool)
        {
            patInspectTool.Names = ImageTool.Tool.差异比较检测.ToString() + "_" + tbxToolName.Text;
            patInspectTool.ImageName = cbxImage.Text;
            patInspectTool.FixNames = cbxFixture.Text;
            patInspectTool.IsFixture = cebxFixture.Checked;
            patInspectTool.Scale = (int)nudScale.Value;
            patInspectTool.Dilation = (int)nudDilation.Value;
            patInspectTool.AbsThreshold =(int) nudAbsThreshold.Value;
            patInspectTool.VarThreshold = (int)nudVarThreshold.Value;
            patInspectTool.SelectedRegionMin = (int)nudSelectedRegionMin.Value;
            patInspectTool.SelectedRegionMax = (int)nudSelectedRegionMax.Value;
            patInspectTool.CompareMode = cbxCompareMode.Text;

            patInspectTool.Setdraw = cbxSetdraw.Text;
            patInspectTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
            patInspectTool.IsCross = cebxIsCross.Checked;
            patInspectTool.IsRectangle = cebxIsRectangle.Checked;

            int ForeIndex = lblForegroundGValMode.Text.IndexOf(':');
            int BackIndex = lblBackgroundGValMode.Text.IndexOf(':');
            int ForeLen = (lblForegroundGValMode.Text.Length) - lblForegroundGValMode.Text.IndexOf(':');
            int BackLen = (lblBackgroundGValMode.Text.Length) - lblBackgroundGValMode.Text.IndexOf(':');


            string strFore = lblForegroundGValMode.Text.Substring(ForeIndex+1, ForeLen-1);
            string strBack = lblBackgroundGValMode.Text.Substring(BackIndex+1, BackLen-1);

            patInspectTool.IsIllumination = cebxIllumination.Checked;
            patInspectTool.IsEdgeMod = cebxEdgeMod.Checked;

            patInspectTool.ForegroundGValMode = double.Parse(strFore);
            patInspectTool.BackgroundGValMode = double.Parse(strBack);

        }
         void Cancel()
         {
             nudScale.ValueChanged -= new EventHandler(nudScale_ValueChanged);
             nudDilation.ValueChanged -= new EventHandler(nudDilation_ValueChanged);
             nudAbsThreshold.ValueChanged -= new EventHandler(nudAbsThreshold_ValueChanged);
             nudVarThreshold.ValueChanged -= new EventHandler(nudVarThreshold_ValueChanged);
             nudSelectedRegionMin.ValueChanged -= new EventHandler(nudSelectedRegionMin_ValueChanged);
             nudSelectedRegionMax.ValueChanged -= new EventHandler(nudSelectedRegionMax_ValueChanged);
             cbxCompareMode.SelectedIndexChanged -= new EventHandler(cbxCompareMode_SelectedIndexChanged);
             cbxSetdraw.SelectedIndexChanged -= new EventHandler(cbxSetdraw_SelectedIndexChanged);
             cebxIsSelectedRegions.CheckedChanged -= new EventHandler(cebxIsSelectedRegions_CheckedChanged);
             cebxIsCross.CheckedChanged -= new EventHandler(cebxIsCross_CheckedChanged);
             cebxIsRectangle.CheckedChanged -= new EventHandler(cebxIsRectangle_CheckedChanged);
         }
         void Register()
         {
             nudScale.ValueChanged += new EventHandler(nudScale_ValueChanged);
             nudDilation.ValueChanged += new EventHandler(nudDilation_ValueChanged);
             nudAbsThreshold.ValueChanged += new EventHandler(nudAbsThreshold_ValueChanged);
             nudVarThreshold.ValueChanged += new EventHandler(nudVarThreshold_ValueChanged);
             nudSelectedRegionMin.ValueChanged += new EventHandler(nudSelectedRegionMin_ValueChanged);
             nudSelectedRegionMax.ValueChanged += new EventHandler(nudSelectedRegionMax_ValueChanged);
             cbxCompareMode.SelectedIndexChanged += new EventHandler(cbxCompareMode_SelectedIndexChanged);
             cbxSetdraw.SelectedIndexChanged += new EventHandler(cbxSetdraw_SelectedIndexChanged);
             cebxIsSelectedRegions.CheckedChanged += new EventHandler(cebxIsSelectedRegions_CheckedChanged);
             cebxIsCross.CheckedChanged += new EventHandler(cebxIsCross_CheckedChanged);
             cebxIsRectangle.CheckedChanged += new EventHandler(cebxIsRectangle_CheckedChanged);
         }
         private void frm_PatInspect_Load(object sender, EventArgs e)
         {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            HOperatorSet.SetWindowParam(hWindowControl1.HalconWindow, "background_color", "blue");
            this.CenterToScreen();
             this.FormClosing += frm_PatInspect_FormClosing;
             image = Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_circle.png");
             this.patInspectTool.hWindowControl1 = hWindowControl1;
            cbxRoi.Items.Add(new MyItem(PatInspectTool.Roi.圆.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_circle.png")));
             cbxRoi.Items.Add(new MyItem(PatInspectTool.Roi.矩形.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_rect1.png")));
             cbxRoi.Items.Add(new MyItem(PatInspectTool.Roi.方向矩形.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_gen_rect2.png")));
             cbxRoi.SelectedIndex = 1;
             //cbxRegion.Items.Add(new MyItem(BlobTool.Tool.区域创建.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_create.png")));
             cbxRegion.Items.Add(new MyItem(PatInspectTool.Tool.区域合并.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_op_union.png")));
             cbxRegion.Items.Add(new MyItem(PatInspectTool.Tool.区域交集.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_op_intersection.png")));
             cbxRegion.Items.Add(new MyItem(PatInspectTool.Tool.区域差集.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_op_difference.png")));
             cbxRegion.Items.Add(new MyItem(PatInspectTool.Tool.区域对称差.ToString(), Image.FromFile(Application.StartupPath + @"\halcon\ic_roi_op_xor.png")));
             cbxRegion.SelectedIndex = 0;
         }

         void frm_PatInspect_FormClosing(object sender, FormClosingEventArgs e)
         {
             frm = null;
         }
        private void tbxToolName_TextChanged(object sender, EventArgs e)
        {
            this.patInspectTool.Names = ImageTool.Tool.差异比较检测.ToString() + "_" + tbxToolName.Text;
            this.Text = tbxToolName.Text;
        }
        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
           // halconView1.DispImage((HObject)this.patInspectTool.Image[cbxImage.Text], true);
          //  halconView1.FitImage();
            patInspectTool.ImageName = cbxImage.Text;
        }
        private void cbxFixture_SelectedIndexChanged(object sender, EventArgs e)
        {
            patInspectTool.FixNames = cbxFixture.Text;
        }
        private void cebxFixture_CheckedChanged(object sender, EventArgs e)
        {
            patInspectTool.IsFixture = cebxFixture.Checked;
        }
        private void nudScale_ValueChanged(object sender, EventArgs e)
        {
            patInspectTool.Scale = (int)nudScale.Value;
      
        }
        private void nudDilation_ValueChanged(object sender, EventArgs e)
        {
            patInspectTool.Dilation = (int)nudDilation.Value;
         
        }
        private void nudAbsThreshold_ValueChanged(object sender, EventArgs e)
        {
            patInspectTool.AbsThreshold = (int)nudAbsThreshold.Value;
         
        }
        private void nudVarThreshold_ValueChanged(object sender, EventArgs e)
        {
            patInspectTool.VarThreshold = (int)nudVarThreshold.Value;
       
        }
        private void nudSelectedRegionMin_ValueChanged(object sender, EventArgs e)
        {
            patInspectTool.SelectedRegionMin = (int)nudSelectedRegionMin.Value;
        }
        private void nudSelectedRegionMax_ValueChanged(object sender, EventArgs e)
        {
            patInspectTool.SelectedRegionMax = (int)nudSelectedRegionMax.Value;
        }
        private void cbxCompareMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            patInspectTool.CompareMode = cbxCompareMode.Text;
        }
        private void cbxRoi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cbxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void btnAddRoi_Click(object sender, EventArgs e)
        {
            patInspectTool.ReadRoi();
            dispRoiPath(patInspectTool);
        }
        private void btnSaveRoi_Click(object sender, EventArgs e)
        {
            patInspectTool.SaveRoi();
            dispRoiPath(patInspectTool);
            isDrawRoi = false;
        }
        private void btnClearRoi_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("是否清除ROI区域", "清除ROI区域", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
            { 
                patInspectTool.RoiClear();
                isDrawRoi = false;
                //halconView1.DispImage((HObject)this.patInspectTool.Image[cbxImage.Text], true);
               // halconView1.FitImage();
                patInspectTool.ImageName = cbxImage.Text;
            }

        }
        private void btnDrawRoi_Click(object sender, EventArgs e)
        {
            isDrawRoi = false;
            if (cbxRoi.Text=="")
            {
                MessageBox.Show("请选择ROI类型");
                return;
            }
            if (cbxRoi.Text == PatInspectTool.Roi.方向矩形.ToString())
                patInspectTool.SetdrawShape = PatInspectTool.Roi.方向矩形.ToString();
            if (cbxRoi.Text == PatInspectTool.Roi.矩形.ToString())
                patInspectTool.SetdrawShape = PatInspectTool.Roi.矩形.ToString();
            if (cbxRoi.Text == PatInspectTool.Roi.圆.ToString())
                patInspectTool.SetdrawShape = PatInspectTool.Roi.圆.ToString();
            //halconView1.ContextMenuStripHide();
           // halconView1.Focus();
            patInspectTool.RegionType = cbxRegion.Text;
            patInspectTool.draw_roi();
            isDrawRoi = true;
        }
        private void btnAddMode_Click(object sender, EventArgs e)
        {
            patInspectTool.ReadModel();
            dispModePath(patInspectTool);
        }
        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            patInspectTool.SaveModel();
            ModelPath = patInspectTool.ModelPath;
        }
        private void btn_run_Click(object sender, EventArgs e)
        {
            try { 
            long timer = patInspectTool.set_after();
           // halconView1.ToolLable2.Text = "FAIL";
          //  halconView1.ToolLable2.ForeColor = Color.Red;
            if (this.patInspectTool.ResultLogic)
            {
             //   halconView1.ToolLable2.Text = "PASS";
            //    halconView1.ToolLable2.ForeColor = Color.Lime;
            }
            lblTimer.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
          //  halconView1.ToolLable3.Text = string.Format("{0}{1}{2}", "耗时:", timer.ToString(), "ms");
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
                if (isDrawRoi)//是否绘制Roi
                {
                    if (DialogResult.Yes == MessageBox.Show("ROI区域是否保存!", "ROI保存", MessageBoxButtons.YesNo))
                    {
                        this.patInspectTool.SaveRoi();
                    }
                    isDrawRoi = false;
                }
                this.SetVal(ref this.patInspectTool);
                this.Hide();
                frm = null;
                handleSetval(this.patInspectTool);
            }
            catch
            {
                this.Hide();
                frm = null;
                handleSetval(this.patInspectTool);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm = null;
        }
        void dispRoiPath(PatInspectTool patInspectTool)
        {
            try
            {
                
                int Debug = patInspectTool.RoiPath.LastIndexOf("Debug");//是否是debug下的文件
                RoiPath = patInspectTool.RoiPath;
                if (Debug != -1)
                {
                    string bugPath = patInspectTool.RoiPath.Substring(Debug + 6, patInspectTool.RoiPath.Length - (Debug + 6));//截取Debug下的文件,例如 原路径 C://Debug//1
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
        void dispModePath(PatInspectTool patInspectTool)
        {
            int Debug = patInspectTool.ModelPath.LastIndexOf("Debug");//是否是debug下的文件
            ModelPath = patInspectTool.ModelPath;
            if (Debug != -1)
            {
                string bugPath = patInspectTool.ModelPath.Substring(Debug + 6, patInspectTool.ModelPath.Length - (Debug + 6));//截取Debug下的文件,例如 原路径 C://Debug//1
                lblModePath.Text = bugPath;
            }
            string imgtype = "*.vam";
            string path = ModelPath.Substring(0, ModelPath.Length - (ModelPath.Length - ModelPath.LastIndexOf("\\")));
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
        private void cebxIsModeXld_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void cebxIsCross_CheckedChanged(object sender, EventArgs e)
        {

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
        private void btnCreateMode_Click(object sender, EventArgs e)
        {
            patInspectTool.CreateVariationModel();
            lblBackgroundGValMode.Text = "BackVal:" + patInspectTool.BackgroundGValMode.ToString();
            lblForegroundGValMode.Text = "ForeVal:" + patInspectTool.ForegroundGValMode.ToString();
        }
        private void cebxIsSelectedRegions_CheckedChanged(object sender, EventArgs e)
        {
            patInspectTool.IsSelectedRegions = cebxIsSelectedRegions.Checked;
        }
        private void cebxIsCross_CheckedChanged_1(object sender, EventArgs e)
        {
            patInspectTool.IsCross = cebxIsCross.Checked;
        }
        private void cebxIsRectangle_CheckedChanged(object sender, EventArgs e)
        {
            patInspectTool.IsRectangle = cebxIsRectangle.Checked;
        }
        private void cbxSetdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
            patInspectTool.Setdraw = cbxSetdraw.Text;
        }
        private void cebxIllumination_CheckedChanged(object sender, EventArgs e)
        {
            patInspectTool.IsIllumination = cebxIllumination.Checked;
        }
        private void cebxEdgeMod_CheckedChanged(object sender, EventArgs e)
        {
            patInspectTool.IsEdgeMod = cebxEdgeMod.Checked;
        }
        private void nudLowAera_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudHigAera_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudLowNum_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudHigNum_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cebxArea_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void halconView1_HMouseWheelEvent(object sender)
        {
            patInspectTool.dispresult();
        }

        private void cebxNums_CheckedChanged(object sender, EventArgs e)
        {

        }

       

      
    }
}
