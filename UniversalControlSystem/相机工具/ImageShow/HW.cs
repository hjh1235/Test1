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
    public partial class HW : Form
    {
        private static HW _HW;
        public static HW Instance()
        {
            if (_HW == null)
            {
                _HW = new HW();
            }
            return _HW;
        }
        public HW()
        {
            InitializeComponent();
            hwin1 = hWindowControl1.HalconWindow;
        }
        public delegate void HMouseDelegate(object sender);
        public event HMouseDelegate HMouseWheelEvent;
        private void OnHMouseWheelEvent()
        {   //定义一个局部变量，将事件对象赋值给该变量，防止多线程情况取消事件
            HMouseDelegate mEvent = HMouseWheelEvent;
            if (mEvent != null)
                mEvent(this);//事件触发
        }
        #region 私有变量定义.
        private HTuple channel_count;
        private HWindow hwin1;
        public  HObject ho_img;//显示图片
        private HTuple width, height;
        private double mposition_row, mposition_col;
        private double mposition_row1B, mposition_col1B;
        private int button_state, button_stateB;
        private int Wt, Ht;
        private int current_beginRow1, current_beginCol1, current_endRow1, current_endCol1;
        private int zoom_beginRow1, zoom_beginCol1, zoom_endRow1, zoom_endCol1;
        HTuple hv_mposition_row1, hv_mposition_col1, hv_button_state1, hv_Grayval1;
        // 窗口和图像的宽高比
        private double ratio_win, ratio_img;
        ////private Boolean MiddleCenter;
        #endregion 私有变量定义.
      
        Dictionary<string, HObject> ho_Image = new Dictionary<string, HObject>();
        /// <summary>
        /// 输入图像
        /// </summary>
        public Dictionary<string, HObject> Image
        {
            get { return ho_Image; }
            set { ho_Image = value; }
        }
        ToolStripLabel toolLable;
        public ToolStripStatusLabel ToolLable2
        {
            get { return toolLabel2; }
            set { toolLabel2 = value; }
        }
        public ToolStripStatusLabel ToolLable3
        {
            get { return toolLabel3; }
            set { toolLabel3 = value; }
        }
        public HWindow HalconWindow
        {
            get { return this.hwin1; }
            set { }
        }
        public HWindowControl HWindowControl
        {
            get { return this.hWindowControl1; }
            set { this.hWindowControl1 = value; }
        }
        /// <summary>
        /// 读取图片
        /// </summary>
        /// <param name="fileName">montery,patras,fabrik</param>
        public void ReadImage(out HObject img, string fileName)
        {
            if (ho_img != null)
            {
                ho_img.Dispose();//释放图片内存
            }
            HOperatorSet.ReadImage(out ho_img, fileName);
            HOperatorSet.GetImageSize(ho_img, out width, out height);
            HOperatorSet.SetPart(hwin1, -1, -1, height, width);
            HOperatorSet.CopyImage(ho_img, out img);
        }
        /// <summary>
        /// 读取图片
        /// </summary>
        /// <param name="fileName">montery,patras,fabrik</param>
        public void ReadImage(out HObject img, HTuple fileName)
        {
            if (ho_img != null)
            {
                ho_img.Dispose();//释放图片内存
            }
            HOperatorSet.ReadImage(out ho_img, fileName);
            HOperatorSet.GetImageSize(ho_img, out width, out height);
            HOperatorSet.SetPart(hwin1, -1, -1, height, width);
            HOperatorSet.CopyImage(ho_img, out img);
        }
        /// <summary>
        /// 打开图片
        /// </summary>
        /// <param name="img"></param>
        public void ReadImage()
        {
            if (ho_img != null)
            {
                ho_img.Dispose();//释放图片内存
            }
            string imageFileName;
            openFileDialog1.Filter = "BMP图像|*.bmp|JPEG图像|*.jpg|PNG图像|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                HOperatorSet.ClearWindow(hwin1);
                imageFileName = openFileDialog1.FileName;
                HOperatorSet.ReadImage(out ho_img, imageFileName);
                HOperatorSet.GetImageSize(ho_img, out width, out height);
                HOperatorSet.SetPart(hwin1, -1, -1, height, width);
            }
        }
        public void DispObject(HObject obj)
        {
            try
            {
                HSystem.SetSystem("flush_graphic", "true");
                hwin1.DispObj(obj);
                HSystem.SetSystem("flush_graphic", "false");
            }
            catch (HalconException)
            {

            }
        }
        public void ShowImg()
        {
            cbxImage.Items.Clear();
            if (Image != null)
            {
                foreach (var item in Image.Keys)
                {
                    cbxImage.Items.Add(item); //加载图像到下拉箱
                }
            }
        }
        private void cbxImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (ho_img != null)
                //{
                //    ho_img.Dispose();//释放图片内存
                //}
                //if (cbxImage.Text != "")
                //{
                //    ho_img = (HObject)Image[cbxImage.Text];
                //}
                //HSystem.SetSystem("flush_graphic", "true");
                //hwin1.DispObj(ho_img);
                //HSystem.SetSystem("flush_graphic", "false");
                DispImage((HObject)Image[cbxImage.Text], true);

            }
            catch
            {
                MessageBox.Show(cbxImage.Text + "异常");
            }
        }
        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="img">图像</param>
        /// <param name="b">是否显示</param>
        public void DispImage(HObject img, bool b)
        {
            try
            {
                if (ho_img != null)
                    ho_img.Dispose();//释放图片内存
                                     //if (cbxImage.Text !="")
                                     //{
                                     //    ho_img = (HObject)Image[cbxImage.Text];
                                     //    HOperatorSet.GetImageSize(ho_img, out width, out height);
                                     //}
                                     //else
                                     //{
                HOperatorSet.CopyImage(img, out ho_img);
                HOperatorSet.GetImageSize(img, out width, out height);
                //}
                if (b)
                {
                    HSystem.SetSystem("flush_graphic", "true");
                    hwin1.DispObj(ho_img);
                    HSystem.SetSystem("flush_graphic", "false");
                }
            }
            catch (HalconException)
            {

            }
        }
        /// <summary>
        /// 保存图片
        /// </summary>
        /// 
        public void WriteImage()
        {
            if (ho_img != null)
            {
                string imageFileName, imagefomrat = "bmp";
                saveFileDialog1.Filter = "BMP图像|*.bmp|JPEG图像|*.jpg|PNG图像|*.png";// "JPEG文件|*.jpg*|BMP文件|*.bmp*|PNG文件|*.png*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            imagefomrat = "bmp";
                            break;
                        case 2:
                            imagefomrat = "jpg";
                            break;
                        case 3:
                            imagefomrat = "png";
                            break;
                    }
                    imageFileName = saveFileDialog1.FileName;
                    HOperatorSet.WriteImage(ho_img, imagefomrat, 0, imageFileName);
                }
            }
        }
        /// <summary>
        /// 保存窗口图片
        /// </summary>
        public void WriteDumpWindow()
        {
            if (ho_img != null)
            {
                string imageFileName, imagefomrat = "bmp";
                saveFileDialog1.Filter = "BMP图像|*.bmp|JPEG图像|*.jpg|PNG图像|*.png";// "JPEG文件|*.jpg*|BMP文件|*.bmp*|PNG文件|*.jpg*|BMP文件|*.bmp*|PNG文件|*.png*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            imagefomrat = "bmp";
                            break;
                        case 2:
                            imagefomrat = "jpg";
                            break;
                        case 3:
                            imagefomrat = "png";
                            break;
                    }
                    imageFileName = saveFileDialog1.FileName;
                    HOperatorSet.DumpWindow(hwin1, imagefomrat, imageFileName);
                }
            }
        }
        /// <summary>
        /// 适应窗口
        /// </summary>
        public void FitWindow()
        {
            if (ho_img != null)
            {
                HOperatorSet.GetImageSize(ho_img, out width, out height);
                HOperatorSet.SetPart(hwin1, -1, -1, height, width);
                HSystem.SetSystem("flush_graphic", "true");
                hwin1.ClearWindow();
                hwin1.DispObj(ho_img);
                HSystem.SetSystem("flush_graphic", "false");
            }
        }
        /// <summary>
        ///  适应图片
        /// </summary>
        public HObject FitImage()
        {
            try
            {
                if (ho_img != null)
                {
                    HOperatorSet.GetImageSize(ho_img, out width, out height);
                    ratio_win = (double)hWindowControl1.WindowSize.Width / (double)hWindowControl1.WindowSize.Height;
                    ratio_img = (double)width / (double)height;
                    int _beginRow, _begin_Col, _endRow, _endCol;
                    if (ratio_win >= ratio_img)
                    {
                        _beginRow = 0;
                        _endRow = (int)height.D - 1;
                        _begin_Col = (int)(-width.D * (ratio_win / ratio_img - 1d) / 2d);
                        _endCol = (int)(width.D + width.D * (ratio_win / ratio_img - 1d) / 2d);
                    }
                    else
                    {
                        _begin_Col = 0;
                        _endCol = (int)width.D - 1;
                        _beginRow = (int)(-height.D * (ratio_img / ratio_win - 1d) / 2d);
                        _endRow = (int)(height.D + height.D * (ratio_img / ratio_win - 1d) / 2d);
                    }
                    hwin1.SetPart(_beginRow, _begin_Col, _endRow, _endCol);
                    hwin1.ClearWindow();
                    HSystem.SetSystem("flush_graphic", "true");
                    hwin1.DispObj(ho_img);
                    HSystem.SetSystem("flush_graphic", "false");

    
                }
            }
            catch (HalconException)
            {
            }
            return ho_img;
        }
        /// <summary>
        /// 绘制直线
        /// </summary>
        /// <param name="_row1"></param>
        /// <param name="_col1"></param>
        /// <param name="_row2"></param>
        /// <param name="col2"></param>
        public void DrawLine(out HObject regline, out HTuple row1, out HTuple col1, out HTuple row2, out HTuple col2)
        {
            hwin1.SetColor("red");
            hwin1.SetDraw("margin");
            HTuple _row1, _col1, _row2, _col2;
            HObject _regline;
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DrawLine(hwin1, out _row1, out _col1, out _row2, out _col2);
            HOperatorSet.GenRegionLine(out _regline, _row1, _col1, _row2, _col2);
            hwin1.SetColor("green");
            hwin1.ClearWindow();
            hwin1.DispObj(ho_img);
            HOperatorSet.DispObj(_regline, hwin1);
            HSystem.SetSystem("flush_graphic", "false");
            row1 = _row1;
            col1 = _col1;
            row2 = _row2;
            col2 = _col2;
            regline = _regline;
            hwin1.SetColor("green");
        }
        /// <summary>
        /// 修改直线
        /// </summary>
        /// <param name="regline"></param>
        /// <param name="row1_in"></param>
        /// <param name="col1_in"></param>
        /// <param name="row2_in"></param>
        /// <param name="col2_in"></param>
        /// <param name="row1"></param>
        /// <param name="col1"></param>
        /// <param name="row2"></param>
        /// <param name="col2"></param>
        public void DrawLineMod(out HObject regline, HTuple row1_in, HTuple col1_in, HTuple row2_in, HTuple col2_in, out HTuple row1, out HTuple col1, out HTuple row2, out HTuple col2)
        {
            hwin1.SetColor("red");
            hwin1.SetDraw("margin");
            HTuple _row1, _col1, _row2, _col2;
            HObject _regline;
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DrawLineMod(hwin1, row1_in, col1_in, row2_in, col2_in, out _row1, out _col1, out _row2, out _col2);
            HOperatorSet.GenRegionLine(out _regline, _row1, _col1, _row2, _col2);
            hwin1.SetColor("green");
            hwin1.ClearWindow();
            hwin1.DispObj(ho_img);
            HOperatorSet.DispObj(_regline, hwin1);
            HSystem.SetSystem("flush_graphic", "false");
            row1 = _row1;
            col1 = _col1;
            row2 = _row2;
            col2 = _col2;
            regline = _regline;
            hwin1.SetColor("green");

        }

        /// <summary>
        /// 绘制圆
        /// </summary>
        /// <param name="_row1"></param>
        /// <param name="_col1"></param>
        /// <param name="_radius1"></param>
        public void DrawCircle(out HObject circle, out HTuple row1, out HTuple col1, out HTuple radius1)
        {
            hwin1.SetColor("red");
            hwin1.SetDraw("margin");
            HTuple _row1, _col1, _radius1;
            HObject _circle;
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DrawCircle(hwin1, out _row1, out _col1, out _radius1);
            HOperatorSet.GenCircle(out _circle, _row1, _col1, _radius1);
            hwin1.SetColor("green");
            hwin1.ClearWindow();
            hwin1.DispObj(ho_img);
            HOperatorSet.DispObj(_circle, hwin1);
            HSystem.SetSystem("flush_graphic", "false");
            row1 = _row1;
            col1 = _col1;
            radius1 = _radius1;
            circle = _circle;
            hwin1.SetColor("green");
        }
        /// <summary>
        /// 修改圆
        /// </summary>
        /// <param name="circle"></param>
        /// <param name="row1_in"></param>
        /// <param name="col1_in"></param>
        /// <param name="radius1_in"></param>
        /// <param name="row1"></param>
        /// <param name="col1"></param>
        /// <param name="radius1"></param>
        public void DrawCircleMod(out HObject circle, HTuple row1_in, HTuple col1_in, HTuple radius1_in, out HTuple row1, out HTuple col1, out HTuple radius1)
        {
            hwin1.SetColor("red");
            hwin1.SetDraw("margin");
            HTuple _row1, _col1, _radius1;
            HObject _circle;

            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DrawCircleMod(hwin1, row1_in, col1_in, radius1_in, out _row1, out _col1, out _radius1);
            HOperatorSet.GenCircle(out _circle, _row1, _col1, _radius1);

            hwin1.SetColor("green");
            hwin1.ClearWindow();
            hwin1.DispObj(ho_img);
            HOperatorSet.DispObj(_circle, hwin1);
            HSystem.SetSystem("flush_graphic", "false");
            row1 = _row1;
            col1 = _col1;
            radius1 = _radius1;
            circle = _circle;
            hwin1.SetColor("green");

        }
        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="_row1"></param>
        /// <param name="_col1"></param>
        /// <param name="_row2"></param>
        /// <param name="_col2"></param>
        public void DrawRectangle1(out HObject reg1, out HTuple row1, out HTuple col1, out HTuple row2, out HTuple col2)
        {
            hwin1.SetColor("red");
            hwin1.SetDraw("margin");
            HTuple _row1, _col1, _row2, _col2;
            HObject _reg1;
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DrawRectangle1(hwin1, out _row1, out _col1, out _row2, out _col2);
            HOperatorSet.GenRectangle1(out _reg1, _row1, _col1, _row2, _col2);
            hwin1.SetColor("green");
            hwin1.ClearWindow();
            hwin1.DispObj(ho_img);
            HOperatorSet.DispObj(_reg1, hwin1);
            HSystem.SetSystem("flush_graphic", "false");
            row1 = _row1;
            col1 = _col1;
            row2 = _row2;
            col2 = _col2;
            reg1 = _reg1;
            hwin1.SetColor("green");
        }

        /// <summary>
        /// 修改矩形
        /// </summary>
        /// <param name="reg1"></param>
        /// <param name="row1_in"></param>
        /// <param name="col1_in"></param>
        /// <param name="row2_in"></param>
        /// <param name="col2_in"></param>
        /// <param name="row1"></param>
        /// <param name="col1"></param>
        /// <param name="row2"></param>
        /// <param name="col2"></param>
        public void DrawRectangle1Mod(out HObject reg1, HTuple row1_in, HTuple col1_in, HTuple row2_in, HTuple col2_in, out HTuple row1, out HTuple col1, out HTuple row2, out HTuple col2)
        {

            hwin1.SetColor("red");
            hwin1.SetDraw("margin");
            HTuple _row1, _col1, _row2, _col2;
            HObject _reg1;
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DrawRectangle1Mod(hwin1, row1_in, col1_in, row2_in, col2_in, out _row1, out _col1, out _row2, out _col2);
            HOperatorSet.GenRectangle1(out _reg1, _row1, _col1, _row2, _col2);
            hwin1.SetColor("green");
            hwin1.ClearWindow();
            hwin1.DispObj(ho_img);
            HOperatorSet.DispObj(_reg1, hwin1);
            HSystem.SetSystem("flush_graphic", "false");
            row1 = _row1;
            col1 = _col1;
            row2 = _row2;
            col2 = _col2;
            reg1 = _reg1;
            hwin1.SetColor("green");

        }
        /// <summary>
        /// 绘制旋转矩形
        /// </summary>
        /// <param name="_row1"></param>
        /// <param name="_col1"></param>
        /// <param name="_phi"></param>
        /// <param name="_len1"></param>
        /// <param name="_len2"></param>
        public void DrawRectangle2(out HObject reg2, out HTuple row1, out HTuple col1, out HTuple phi, out HTuple len1, out HTuple len2)
        {
            // 'white', 'black', 'gray', 'red', 'green', 'blue'
            hwin1.SetColor("red");
            hwin1.SetDraw("margin");
            HTuple _row1, _col1, _phi, _len1, _len2;
            HObject _reg2;
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DrawRectangle2(hwin1, out _row1, out _col1, out _phi, out _len1, out _len2);
            HOperatorSet.GenRectangle2(out _reg2, _row1, _col1, _phi, _len1, _len2);
            hwin1.SetColor("green");
            hwin1.ClearWindow();
            hwin1.DispObj(ho_img);
            HOperatorSet.DispObj(_reg2, hwin1);
            HSystem.SetSystem("flush_graphic", "false");
            row1 = _row1;
            col1 = _col1;
            phi = _phi;
            len1 = _len1;
            len2 = _len2;
            reg2 = _reg2;
            hwin1.SetColor("green");
        }
        /// <summary>
        /// 修改旋转矩形
        /// </summary>
        /// <param name="reg2"></param>
        /// <param name="row1_in"></param>
        /// <param name="col1_in"></param>
        /// <param name="phi1_in"></param>
        /// <param name="len1_in"></param>
        /// <param name="len2_in"></param>
        /// <param name="row1"></param>
        /// <param name="col1"></param>
        /// <param name="phi"></param>
        /// <param name="len1"></param>
        /// <param name="len2"></param>
        public void DrawRectangle2Mod(out HObject reg2, HTuple row1_in, HTuple col1_in, HTuple phi1_in, HTuple len1_in, HTuple len2_in, out HTuple row1, out HTuple col1, out HTuple phi, out HTuple len1, out HTuple len2)
        {
            hwin1.SetColor("red");
            hwin1.SetDraw("margin");
            HTuple _row1, _col1, _phi, _len1, _len2;
            HObject _reg2;
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DrawRectangle2Mod(hwin1, row1_in, col1_in, phi1_in, len1_in, len2_in, out _row1, out _col1, out _phi, out _len1, out _len2);
            HOperatorSet.GenRectangle2(out _reg2, _row1, _col1, _phi, _len1, _len2);
            hwin1.SetColor("green");
            hwin1.ClearWindow();
            hwin1.DispObj(ho_img);
            HOperatorSet.DispObj(_reg2, hwin1);
            HSystem.SetSystem("flush_graphic", "false");
            row1 = _row1;
            col1 = _col1;
            phi = _phi;
            len1 = _len1;
            len2 = _len2;
            reg2 = _reg2;
            hwin1.SetColor("green");
        }
        private void hWindowControl1_HMouseWheel(object sender, HalconDotNet.HMouseEventArgs e)
        {
            if (ho_img != null)
            {
                try
                {
                    hwin1.GetMpositionSubPix(out mposition_row, out mposition_col, out button_state);
                    hwin1.GetPart(out current_beginRow1, out current_beginCol1, out current_endRow1, out current_endCol1);
                    Ht = current_endRow1 - current_beginRow1;
                    Wt = current_endCol1 - current_beginCol1;
                }
                catch (HalconException)
                {
                }
                if (e.Delta > 0)                 // 放大图像
                {
                    if (Ht > 4)
                    {
                        zoom_beginRow1 = (int)(current_beginRow1 + (mposition_row - current_beginRow1) * 0.300d);
                        zoom_beginCol1 = (int)(current_beginCol1 + (mposition_col - current_beginCol1) * 0.300d);
                        zoom_endRow1 = (int)(current_endRow1 - (current_endRow1 - mposition_row) * 0.300d);
                        zoom_endCol1 = (int)(current_endCol1 - (current_endCol1 - mposition_col) * 0.300d);
                        hwin1.SetPart(zoom_beginRow1, zoom_beginCol1, zoom_endRow1, zoom_endCol1);
                        hwin1.ClearWindow();
                        try
                        {
                            HSystem.SetSystem("flush_graphic", "true");
                            if (cbxImage.Text != "" && Image.Count > 0)
                                DispImage(Image[cbxImage.Text], true);
                            else
                                hwin1.DispObj(ho_img);
                            OnHMouseWheelEvent();
                            if (中心ToolStripMenuItem.Checked)
                                disp_win_cross(ho_img);
                            HSystem.SetSystem("flush_graphic", "false");
                        }
                        catch (HalconException)
                        {
                        }
                    }
                }

                else                           // 缩小图像
                {

                    if (Ht < 8000)
                    {
                        zoom_beginRow1 = (int)(mposition_row - (mposition_row - current_beginRow1) / 0.700d);
                        zoom_beginCol1 = (int)(mposition_col - (mposition_col - current_beginCol1) / 0.700d);
                        zoom_endRow1 = (int)(mposition_row + (current_endRow1 - mposition_row) / 0.700d);
                        zoom_endCol1 = (int)(mposition_col + (current_endCol1 - mposition_col) / 0.700d);
                        hwin1.SetPart(zoom_beginRow1, zoom_beginCol1, zoom_endRow1, zoom_endCol1);
                        hwin1.ClearWindow();
                        try
                        {
                            HSystem.SetSystem("flush_graphic", "true");
                            hwin1.DispObj(ho_img);
                            if (中心ToolStripMenuItem.Checked)
                                disp_win_cross(ho_img);
                            HSystem.SetSystem("flush_graphic", "false");
                            OnHMouseWheelEvent();
                        }
                        catch (HalconException)
                        {
                        }
                    }

                }

            }
        }
        private void hWindowControl1_HMouseMove(object sender, HMouseEventArgs e)
        {
            try
            {
                if (ho_img != null)
                {
                    HOperatorSet.CountChannels(ho_img, out channel_count);
                    hwin1.GetMpositionSubPix(out mposition_row, out mposition_col, out button_state);
                    string str_size = "Size:" + width + "*" + height + "-";
                    string str_position = String.Format("X:{0:0.00},Y:{1:0.00}", mposition_col, mposition_row);
                    try
                    {
                        if (width > mposition_col & height > mposition_row & mposition_col > 1 & mposition_row > 1)
                        {
                            HOperatorSet.GetMposition(hwin1, out hv_mposition_row1, out hv_mposition_col1, out hv_button_state1);
                            HOperatorSet.GetGrayval(ho_img, hv_mposition_row1, hv_mposition_col1, out hv_Grayval1);//中读取灰度值
                            if (channel_count > 1)
                                toolLabel1.Text = string.Format(str_size + str_position + "-" + "VAL=" + "R:{0},G:{1},B:{2}", +hv_Grayval1.TupleSelect(0), hv_Grayval1.TupleSelect(1), hv_Grayval1.TupleSelect(2));
                            else
                                toolLabel1.Text = str_size + str_position + "-" + "VAL=" + hv_Grayval1.ToString();
                        }
                        else
                            toolLabel1.Text = str_size + str_position + "-" + "VAL=" + 0;
                    }
                    catch (HalconException)
                    {
                    }
                    if (button_state == 2)
                    {
                        Cursor.Current = Cursors.SizeAll;//("SizeAll");
                        int current_beginRow2, current_beginCol2, current_endRow2, current_endCol2;
                        int dbRowMove1, dbColMove1;
                        dbRowMove1 = (int)(mposition_row1B - mposition_row);
                        dbColMove1 = (int)(mposition_col1B - mposition_col);
                        hwin1.GetPart(out current_beginRow2, out current_beginCol2, out current_endRow2, out current_endCol2);
                        hwin1.SetPart(current_beginRow2 + dbRowMove1, current_beginCol2 + dbColMove1, current_endRow2 + dbRowMove1, current_endCol2 + dbColMove1);
                        hwin1.ClearWindow();
                        try
                        {
                            HSystem.SetSystem("flush_graphic", "true");
                            hwin1.DispObj(ho_img);
                            if (中心ToolStripMenuItem.Checked)
                                disp_win_cross(ho_img);
                            HSystem.SetSystem("flush_graphic", "false");
                            OnHMouseWheelEvent();
                        }
                        catch (HalconException)
                        {
                        }
                    }
                    else
                    {
                        hwin1.GetMpositionSubPix(out mposition_row1B, out mposition_col1B, out button_stateB);
                    }
                }
            }
            catch (HalconException)
            {
            }
        }

        private void 图像选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hWindowControl1_HMouseDown_1(object sender, HMouseEventArgs e)
        {
            if (!keyDown)
                keyNum = 1;
        }

        private void hWindowControl1_HMouseMove_1(object sender, HMouseEventArgs e)
        {
            try
            {
                if (ho_img != null)
                {
                    HOperatorSet.CountChannels(ho_img, out channel_count);
                    hwin1.GetMpositionSubPix(out mposition_row, out mposition_col, out button_state);
                    string str_size = "Size:" + width + "*" + height + "-";
                    string str_position = String.Format("X:{0:0.00},Y:{1:0.00}", mposition_col, mposition_row);
                    try
                    {
                        if (width > mposition_col & height > mposition_row & mposition_col > 1 & mposition_row > 1)
                        {
                            HOperatorSet.GetMposition(hwin1, out hv_mposition_row1, out hv_mposition_col1, out hv_button_state1);
                            HOperatorSet.GetGrayval(ho_img, hv_mposition_row1, hv_mposition_col1, out hv_Grayval1);//中读取灰度值
                            if (channel_count > 1)
                                toolLabel1.Text = string.Format(str_size + str_position + "-" + "VAL=" + "R:{0},G:{1},B:{2}", +hv_Grayval1.TupleSelect(0), hv_Grayval1.TupleSelect(1), hv_Grayval1.TupleSelect(2));
                            else
                                toolLabel1.Text = str_size + str_position + "-" + "VAL=" + hv_Grayval1.ToString();
                        }
                        else
                            toolLabel1.Text = str_size + str_position + "-" + "VAL=" + 0;
                    }
                    catch (HalconException)
                    {
                    }
                    if (button_state == 2)
                    {
                        Cursor.Current = Cursors.SizeAll;//("SizeAll");
                        int current_beginRow2, current_beginCol2, current_endRow2, current_endCol2;
                        int dbRowMove1, dbColMove1;
                        dbRowMove1 = (int)(mposition_row1B - mposition_row);
                        dbColMove1 = (int)(mposition_col1B - mposition_col);
                        hwin1.GetPart(out current_beginRow2, out current_beginCol2, out current_endRow2, out current_endCol2);
                        hwin1.SetPart(current_beginRow2 + dbRowMove1, current_beginCol2 + dbColMove1, current_endRow2 + dbRowMove1, current_endCol2 + dbColMove1);
                        hwin1.ClearWindow();
                        try
                        {
                            HSystem.SetSystem("flush_graphic", "true");
                            hwin1.DispObj(ho_img);
                            if (中心ToolStripMenuItem.Checked)
                                disp_win_cross(ho_img);
                            HSystem.SetSystem("flush_graphic", "false");
                            OnHMouseWheelEvent();
                        }
                        catch (HalconException)
                        {
                        }
                    }
                    else
                    {
                        hwin1.GetMpositionSubPix(out mposition_row1B, out mposition_col1B, out button_stateB);
                    }
                }
            }
            catch (HalconException)
            {
            }
        }

        private void hWindowControl1_HMouseUp_1(object sender, HMouseEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            if (e.Button == MouseButtons.Right)
            {
                if (keyNum == 1)
                {
                    
                       keyNum = 0;
                    contextMenuStrip1.Visible = true;
                    this.contextMenuStrip1.Show(/*pictureBox1, */new Point((int)hWindowControl1.Location.X , (int)hWindowControl1.Location.Y));
                    //contextMenuStrip1.LocationChanged = e.Button;
                    keyDown = false;
                }
                else
                    keyNum++;  //+1 =1
            }
        }

        private void hWindowControl1_HMouseWheel_1(object sender, HMouseEventArgs e)
        {
            if (ho_img != null)
            {
                try
                {
                    hwin1.GetMpositionSubPix(out mposition_row, out mposition_col, out button_state);
                    hwin1.GetPart(out current_beginRow1, out current_beginCol1, out current_endRow1, out current_endCol1);
                    Ht = current_endRow1 - current_beginRow1;
                    Wt = current_endCol1 - current_beginCol1;
                }
                catch (HalconException)
                {
                }
                if (e.Delta > 0)                 // 放大图像
                {
                    if (Ht > 4)
                    {
                        zoom_beginRow1 = (int)(current_beginRow1 + (mposition_row - current_beginRow1) * 0.300d);
                        zoom_beginCol1 = (int)(current_beginCol1 + (mposition_col - current_beginCol1) * 0.300d);
                        zoom_endRow1 = (int)(current_endRow1 - (current_endRow1 - mposition_row) * 0.300d);
                        zoom_endCol1 = (int)(current_endCol1 - (current_endCol1 - mposition_col) * 0.300d);
                        hwin1.SetPart(zoom_beginRow1, zoom_beginCol1, zoom_endRow1, zoom_endCol1);
                        hwin1.ClearWindow();
                        try
                        {
                            HSystem.SetSystem("flush_graphic", "true");
                            if (cbxImage.Text != "" && Image.Count > 0)
                                DispImage(Image[cbxImage.Text], true);
                            else
                                hwin1.DispObj(ho_img);
                            OnHMouseWheelEvent();
                            if (中心ToolStripMenuItem.Checked)
                                disp_win_cross(ho_img);
                            HSystem.SetSystem("flush_graphic", "false");
                        }
                        catch (HalconException)
                        {
                        }
                    }
                }

                else                           // 缩小图像
                {

                    if (Ht < 8000)
                    {
                        zoom_beginRow1 = (int)(mposition_row - (mposition_row - current_beginRow1) / 0.700d);
                        zoom_beginCol1 = (int)(mposition_col - (mposition_col - current_beginCol1) / 0.700d);
                        zoom_endRow1 = (int)(mposition_row + (current_endRow1 - mposition_row) / 0.700d);
                        zoom_endCol1 = (int)(mposition_col + (current_endCol1 - mposition_col) / 0.700d);
                        hwin1.SetPart(zoom_beginRow1, zoom_beginCol1, zoom_endRow1, zoom_endCol1);
                        hwin1.ClearWindow();
                        try
                        {
                            HSystem.SetSystem("flush_graphic", "true");
                            hwin1.DispObj(ho_img);
                            if (中心ToolStripMenuItem.Checked)
                                disp_win_cross(ho_img);
                            HSystem.SetSystem("flush_graphic", "false");
                            OnHMouseWheelEvent();
                        }
                        catch (HalconException)
                        {
                        }
                    }

                }

            }
        }

        private void fitImagerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FitImage();
            fitImagerToolStripMenuItem.Checked = true;
            适应窗口ToolStripMenuItem.Checked = false;
            HSystem.SetSystem("flush_graphic", "true");
            if (中心ToolStripMenuItem.Checked)
                disp_win_cross(ho_img);
            HSystem.SetSystem("flush_graphic", "false");
            OnHMouseWheelEvent();
        }

        private void 适应窗口ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FitWindow();
            适应窗口ToolStripMenuItem.Checked = true;
            fitImagerToolStripMenuItem.Checked = false;
            HSystem.SetSystem("flush_graphic", "true");
            if (中心ToolStripMenuItem.Checked)
                disp_win_cross(ho_img);
            HSystem.SetSystem("flush_graphic", "false");
            OnHMouseWheelEvent();
        }

        private void saveImagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteImage();
        }

        private void SaveWindowToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            WriteDumpWindow();
        }

        private void 中心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (中心ToolStripMenuItem.Checked == false)
            {
                中心ToolStripMenuItem.Checked = true;
                HSystem.SetSystem("flush_graphic", "true");
                disp_win_cross();
                OnHMouseWheelEvent();
                HSystem.SetSystem("flush_graphic", "false");
            }
            else
            {
                中心ToolStripMenuItem.Checked = false;
                HSystem.SetSystem("flush_graphic", "true");
                hwin1.DispObj(ho_img);
                OnHMouseWheelEvent();
                HSystem.SetSystem("flush_graphic", "false");
            }
        }

        private void 图像选择ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!图像选择ToolStripMenuItem.Checked)
            {
                panel1.Visible = true;
                图像选择ToolStripMenuItem.Checked = true;
                //this.hWindowControl1.Location = new System.Drawing.Point(1, 29);
                //Size size = this.hWindowControl1.Size;
                //this.hWindowControl1.Size = new System.Drawing.Size(size.Width, size.Height-10);


            }
            else
            {
                panel1.Visible = false;

                图像选择ToolStripMenuItem.Checked = false;
                //this.hWindowControl1.Location = new System.Drawing.Point(1, 1);
                //Size size = this.hWindowControl1.Size;
                //this.hWindowControl1.Size = new System.Drawing.Size(size.Width, size.Height + 29);
            }
        }

        public void disp_win_cross()
        {
            if (中心ToolStripMenuItem.Checked)
                disp_win_cross(ho_img);
        }
        void disp_win_cross(HObject ho_Image)
        {
            try
            {
                // Local iconic variables 
                HObject ho_Contour1, ho_Contour2;
                // Local control variables 
                HTuple hv_Width = null, hv_Height = null;
                // Initialize local and output iconic variables 
                HOperatorSet.GenEmptyObj(out ho_Contour1);
                HOperatorSet.GenEmptyObj(out ho_Contour2);
                HOperatorSet.SetColor(hwin1, "red");
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
                ho_Contour1.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_Contour1, (new HTuple(0)).TupleConcat(
                    hv_Height), ((hv_Width / 2)).TupleConcat(hv_Width / 2));
                ho_Contour2.Dispose();
                HOperatorSet.GenContourPolygonXld(out ho_Contour2, ((hv_Height / 2)).TupleConcat(
                    hv_Height / 2), (new HTuple(0)).TupleConcat(hv_Width));
                HOperatorSet.DispObj(ho_Contour1, hwin1);
                HOperatorSet.DispObj(ho_Contour2, hwin1);
                ho_Contour1.Dispose();
                ho_Contour2.Dispose();
                return;
            }
            catch { }
        }
        public void disp_message(HTuple hv_String, HTuple hv_CoordSystem,
                    HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box, HTuple hv_BoxColor)
        {
            disp_message(hwin1, hv_String, hv_CoordSystem,
                     hv_Row, hv_Column, hv_Color, hv_Box, hv_BoxColor);
        }
        void disp_message(HTuple hv_WindowHandle, HTuple hv_String, HTuple hv_CoordSystem,
                   HTuple hv_Row, HTuple hv_Column, HTuple hv_Color, HTuple hv_Box, HTuple hv_BoxColor)
        {
            // Local iconic variables 

            // Local control variables 

            HTuple hv_Red = null, hv_Green = null, hv_Blue = null;
            HTuple hv_Row1Part = null, hv_Column1Part = null, hv_Row2Part = null;
            HTuple hv_Column2Part = null, hv_RowWin = null, hv_ColumnWin = null;
            HTuple hv_WidthWin = new HTuple(), hv_HeightWin = null;
            HTuple hv_MaxAscent = null, hv_MaxDescent = null, hv_MaxWidth = null;
            HTuple hv_MaxHeight = null, hv_R1 = new HTuple(), hv_C1 = new HTuple();
            HTuple hv_FactorRow = new HTuple(), hv_FactorColumn = new HTuple();
            HTuple hv_UseShadow = null, hv_ShadowColor = null, hv_Exception = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Index = new HTuple();
            HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
            HTuple hv_W = new HTuple(), hv_H = new HTuple(), hv_FrameHeight = new HTuple();
            HTuple hv_FrameWidth = new HTuple(), hv_R2 = new HTuple();
            HTuple hv_C2 = new HTuple(), hv_DrawMode = new HTuple();
            HTuple hv_CurrentColor = new HTuple();
            HTuple hv_Box_COPY_INP_TMP = hv_Box.Clone();
            HTuple hv_Color_COPY_INP_TMP = hv_Color.Clone();
            HTuple hv_Column_COPY_INP_TMP = hv_Column.Clone();
            HTuple hv_Row_COPY_INP_TMP = hv_Row.Clone();
            HTuple hv_String_COPY_INP_TMP = hv_String.Clone();

            // Initialize local and output iconic variables 

            HOperatorSet.GetRgb(hv_WindowHandle, out hv_Red, out hv_Green, out hv_Blue);
            HOperatorSet.GetPart(hv_WindowHandle, out hv_Row1Part, out hv_Column1Part,
                out hv_Row2Part, out hv_Column2Part);
            HOperatorSet.GetWindowExtents(hv_WindowHandle, out hv_RowWin, out hv_ColumnWin,
                out hv_WidthWin, out hv_HeightWin);
            HOperatorSet.SetPart(hv_WindowHandle, 0, 0, hv_HeightWin - 1, hv_WidthWin - 1);
            //
            //default settings
            if ((int)(new HTuple(hv_Row_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Row_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Column_COPY_INP_TMP.TupleEqual(-1))) != 0)
            {
                hv_Column_COPY_INP_TMP = 12;
            }
            if ((int)(new HTuple(hv_Color_COPY_INP_TMP.TupleEqual(new HTuple()))) != 0)
            {
                hv_Color_COPY_INP_TMP = "";
            }
            //
            hv_String_COPY_INP_TMP = ((("" + hv_String_COPY_INP_TMP) + "")).TupleSplit("\n");
            //
            //Estimate extentions of text depending on font size.
            HOperatorSet.GetFontExtents(hv_WindowHandle, out hv_MaxAscent, out hv_MaxDescent,
                out hv_MaxWidth, out hv_MaxHeight);
            if ((int)(new HTuple(hv_CoordSystem.TupleEqual("window"))) != 0)
            {
                hv_R1 = hv_Row_COPY_INP_TMP.Clone();
                hv_C1 = hv_Column_COPY_INP_TMP.Clone();
            }
            else
            {
                //Transform image to window coordinates
                hv_FactorRow = (1.0 * hv_HeightWin) / ((hv_Row2Part - hv_Row1Part) + 1);
                hv_FactorColumn = (1.0 * hv_WidthWin) / ((hv_Column2Part - hv_Column1Part) + 1);
                hv_R1 = ((hv_Row_COPY_INP_TMP - hv_Row1Part) + 0.5) * hv_FactorRow;
                hv_C1 = ((hv_Column_COPY_INP_TMP - hv_Column1Part) + 0.5) * hv_FactorColumn;
            }
            //
            //Display text box depending on text size
            hv_UseShadow = 0;
            hv_ShadowColor = "gray";
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleEqual("true"))) != 0)
            {
                if (hv_Box_COPY_INP_TMP == null)
                    hv_Box_COPY_INP_TMP = new HTuple();
                hv_Box_COPY_INP_TMP[0] = hv_BoxColor;
                hv_ShadowColor = "#f28d26";
                if (hv_Box_COPY_INP_TMP == null)
                    hv_Box_COPY_INP_TMP = new HTuple();
                hv_Box_COPY_INP_TMP[0] = "#33ff66";
                hv_ShadowColor = "#f2ffff";

            }
            if ((int)(new HTuple((new HTuple(hv_Box_COPY_INP_TMP.TupleLength())).TupleGreater(
                1))) != 0)
            {
                if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual("true"))) != 0)
                {
                    //Use default ShadowColor set above
                }
                else if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(1))).TupleEqual(
                    "false"))) != 0)
                {
                    hv_UseShadow = 0;
                }
                else
                {
                    hv_ShadowColor = hv_Box_COPY_INP_TMP[1];
                    //Valid color?
                    try
                    {
                        HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                            1));
                    }
                    // catch (Exception) 
                    catch (HalconException HDevExpDefaultException1)
                    {
                        HDevExpDefaultException1.ToHTuple(out hv_Exception);
                        hv_Exception = "Wrong value of control parameter Box[1] (must be a 'true', 'false', or a valid color string)";
                        throw new HalconException(hv_Exception);
                    }
                }
            }
            if ((int)(new HTuple(((hv_Box_COPY_INP_TMP.TupleSelect(0))).TupleNotEqual("false"))) != 0)
            {
                //Valid color?
                try
                {
                    HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                        0));
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    hv_Exception = "Wrong value of control parameter Box[0] (must be a 'true', 'false', or a valid color string)";
                    throw new HalconException(hv_Exception);
                }
                //Calculate box extents
                hv_String_COPY_INP_TMP = (" " + hv_String_COPY_INP_TMP) + " ";
                hv_Width = new HTuple();
                for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    )) - 1); hv_Index = (int)hv_Index + 1)
                {
                    HOperatorSet.GetStringExtents(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                        hv_Index), out hv_Ascent, out hv_Descent, out hv_W, out hv_H);
                    hv_Width = hv_Width.TupleConcat(hv_W);
                }
                hv_FrameHeight = hv_MaxHeight * (new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                    ));
                hv_FrameWidth = (((new HTuple(0)).TupleConcat(hv_Width))).TupleMax();
                hv_R2 = hv_R1 + hv_FrameHeight;
                hv_C2 = hv_C1 + hv_FrameWidth;
                //Display rectangles
                HOperatorSet.GetDraw(hv_WindowHandle, out hv_DrawMode);
                HOperatorSet.SetDraw(hv_WindowHandle, "fill");
                //Set shadow color
                HOperatorSet.SetColor(hv_WindowHandle, hv_ShadowColor);
                if ((int)(hv_UseShadow) != 0)
                {
                    HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1 + 1, hv_C1 + 1, hv_R2 + 1,
                        hv_C2 + 1);
                }
                //Set box color
                HOperatorSet.SetColor(hv_WindowHandle, hv_Box_COPY_INP_TMP.TupleSelect(
                    0));
                HOperatorSet.DispRectangle1(hv_WindowHandle, hv_R1, hv_C1, hv_R2, hv_C2);
                HOperatorSet.SetDraw(hv_WindowHandle, hv_DrawMode);
            }
            //Write text.
            for (hv_Index = 0; (int)hv_Index <= (int)((new HTuple(hv_String_COPY_INP_TMP.TupleLength()
                )) - 1); hv_Index = (int)hv_Index + 1)
            {
                hv_CurrentColor = hv_Color_COPY_INP_TMP.TupleSelect(hv_Index % (new HTuple(hv_Color_COPY_INP_TMP.TupleLength()
                    )));
                if ((int)((new HTuple(hv_CurrentColor.TupleNotEqual(""))).TupleAnd(new HTuple(hv_CurrentColor.TupleNotEqual(
                    "auto")))) != 0)
                {
                    HOperatorSet.SetColor(hv_WindowHandle, hv_CurrentColor);
                }
                else
                {
                    HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
                }
                hv_Row_COPY_INP_TMP = hv_R1 + (hv_MaxHeight * hv_Index);
                HOperatorSet.SetTposition(hv_WindowHandle, hv_Row_COPY_INP_TMP, hv_C1);
                HOperatorSet.WriteString(hv_WindowHandle, hv_String_COPY_INP_TMP.TupleSelect(
                    hv_Index));
            }
            //Reset changed window settings
            HOperatorSet.SetRgb(hv_WindowHandle, hv_Red, hv_Green, hv_Blue);
            HOperatorSet.SetPart(hv_WindowHandle, hv_Row1Part, hv_Column1Part, hv_Row2Part,
                hv_Column2Part);

            return;
        }

        private void HalconView_Load(object sender, EventArgs e)
        {

        }
        private void noToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteImage();
        }
        private void SaveWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteDumpWindow();
        }
        private void fitImagerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 适应窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        int keyNum;
        bool keyDown;
        public void ContextMenuStripHide()
        {
            keyNum = 0;
            keyDown = true;
        }
        private void hWindowControl1_HMouseDown(object sender, HMouseEventArgs e)
        {
            if (!keyDown)
                keyNum = 1;
        }
        private void hWindowControl1_HMouseUp(object sender, HMouseEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            if (e.Button == MouseButtons.Right)
            {
                if (keyNum == 1)
                {
                    keyNum = 0;
                    contextMenuStrip1.Visible = true;
                    keyDown = false;
                }
                else
                    keyNum++;  //+1 =1
            }
        }

        private void 中心十字ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}
