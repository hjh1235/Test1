using HalconDotNet;
using HOperatorSet_EX;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class TransPolarTool:ImageTool
    {
        // Local iconic variables 
        [NonSerialized]
        HObject ho_ROI_0;
        [NonSerialized]
        HTuple hv_Width = null, hv_Height = null,  WinHandle1=null;
      
        HTuple hv_Row = null, hv_Column = null, hv_OuterRadius = null, hv_InnerRadius= null;
        HTuple hv_AngleStart = null, hv_AngleEnd = null, hv_WidthPolar = null, hv_HeightPolar = null;


        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName
        { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names
        { get; set; }
        public bool ResultLogic { get; set; }
        [NonSerialized]
         Dictionary<string, HObject> ho_Image = new  Dictionary<string, HObject>();
        [NonSerialized]
        HObject outImage, ho_PolarTransImage, ho_ImageRotate;
        /// <summary>
        /// 输入图像
        /// </summary>
        public  Dictionary<string, HObject> Image
        {
            get { return ho_Image; }
            set { ho_Image = value; }
        }
        /// <summary>
        /// 图片
        /// </summary>
        public HObject OutImage
        {
            get { return outImage; }
            set { outImage = value; }
        }
        public HTuple InnerRadius
        {
            get
            {
                return hv_InnerRadius;
            }

            set
            {
                hv_InnerRadius = value;
            }
        }
        public HTuple OuterRadius
        {
            get
            {
                return hv_OuterRadius;
            }

            set
            {
                hv_OuterRadius = value;
            }
        }
        public HTuple Column
        {
            get
            {   return hv_Column; }
            set
            {   hv_Column = value;}
        }
        public HTuple Row
        {   get
            { return hv_Row;
            }
            set
            { hv_Row = value;
            }
        }
        public HTuple AngleEnd
        { get
            { return hv_AngleEnd;
            }

            set
            { hv_AngleEnd = value;
            }
        }
        public HTuple AngleStart
        { get
            { return hv_AngleStart;
            }
            set
            { hv_AngleStart = value;
            }
        }

        HTuple hv_circle = new HTuple();//圆形
        /// <summary>
        /// 圆形
        /// </summary>
        public HTuple Circle
        {
            get { return hv_circle; }
            set { hv_circle = value; }
        }
        HTuple hv_rectangle1 = new HTuple();//矩形
        /// <summary>
        /// 矩形
        /// </summary>
        public HTuple Rectangle1
        {
            get { return hv_rectangle1; }
            set { hv_rectangle1 = value; }
        }
        HTuple hv_rectangle2 = new HTuple();//方向矩形
        /// <summary>
        /// 方向矩形
        /// </summary>
        public HTuple Rectangle2
        {
            get { return hv_rectangle2; }
            set { hv_rectangle2 = value; }
        }
        public  string SetdrawShape
        {  get; set; }

        public override string toolName()
        { return Names; }
        public override long toolTimer()
        {
            return timer;
        }
        public override void recon()
        { }
        public override void ini()
        {
            Names = Tool.极坐标变换图像.ToString();
            Row = 200;
            Column = 200;
            InnerRadius = 100;
            OuterRadius = 150;
            AngleStart = 0;
            AngleEnd = 360;

            hv_circle[0] = 50;//圆形
            hv_circle[1] = 50;//圆形
            hv_circle[2] = 50;//圆形

            hv_rectangle1[0] = 50;//矩形
            hv_rectangle1[1] = 50;//矩形
            hv_rectangle1[2] = 100;//矩形
            hv_rectangle1[3] = 100;//矩形

            hv_rectangle2[0] = 200;//方向矩形
            hv_rectangle2[1] = 200;//方向矩形
            hv_rectangle2[2] = 0;//方向矩形
            hv_rectangle2[3] = 50;//方向矩形
            hv_rectangle2[4] = 50;//方向矩形
            SetdrawShape = Roi.圆.ToString(); ;//ROI形状

        }
        public override void draw_roi()
        {
            
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            draw_roi(hWindowControl1.HalconWindow, ho_Image, ImageName, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2, out hv_circle, out hv_rectangle1, out hv_rectangle2);
            hv_Row = hv_circle[0]; hv_Column = hv_circle[1]; hv_InnerRadius = hv_circle[2];
            set_after();
        }
        void gen_roi()
        {
            if (ho_ROI_0 != null)
            {
                ho_ROI_0.Dispose();
            }
            gen_roi(out ho_ROI_0, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2);

            
        }
        /// <summary>
        /// 运行一次
        /// </summary>
        public override void run()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            toolRun();
            watch.Stop();
            timer = watch.ElapsedMilliseconds;
        }
        private void toolRun()
        {
            ResultLogic = true;
            try
            {
                HSystem.SetSystem("flush_graphic", "true");
                if (outImage != null)
                    outImage.Dispose();
                if (hv_InnerRadius > hv_OuterRadius)//如果内径大于外径
                    hv_OuterRadius = hv_InnerRadius + 50;
                PolarTransImage((HObject)ho_Image[ImageName], out ho_PolarTransImage, out outImage, hv_Row, hv_Column, hv_InnerRadius, hv_OuterRadius, hv_AngleStart,  hv_AngleEnd, out hv_WidthPolar, out hv_HeightPolar);
                HSystem.SetSystem("flush_graphic", "false");
            }
            catch (HalconException ex)
            {
                try
                {
                    HSystem.SetSystem("flush_graphic", "true");
                    HTuple hv_Exception;
                    ex.ToHTuple(out hv_Exception);
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "{" + hv_Exception + "}", CoordSystem.window.ToString(), 10, 10, "red", "false");
                    ResultLogic = false;//结果异常
                    HSystem.SetSystem("flush_graphic", "false");
                }
                catch { };
            }
        }
        public override void dispresult()
        {
            try
            {
                HObject ho_innerCircle, ho_outCircle;
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
                HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 2);         
                HOperatorSet.GenEmptyObj(out ho_innerCircle);
                HOperatorSet.GenEmptyObj(out ho_outCircle);
                ho_innerCircle.Dispose();
                ho_outCircle.Dispose();
                HOperatorSet.GenCircle(out ho_innerCircle, hv_Row, hv_Column, hv_InnerRadius);
                HOperatorSet.GenCircle(out ho_outCircle, hv_Row, hv_Column, hv_OuterRadius);
                HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                HOperatorSet.DispObj(ho_innerCircle, hWindowControl1.HalconWindow);
                HOperatorSet.DispObj(ho_outCircle, hWindowControl1.HalconWindow);
                ho_innerCircle.Dispose();
                ho_outCircle.Dispose();
                HSystem.SetSystem("flush_graphic", "false");
            }
            catch (HalconException ex)
            {
                try
                {
                    HSystem.SetSystem("flush_graphic", "true");
                    HTuple hv_Exception;
                    ex.ToHTuple(out hv_Exception);
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "{" + hv_Exception + "}", CoordSystem.window.ToString(), 10, 10, "red", "false");
                    ResultLogic = false;//结果异常
                    HSystem.SetSystem("flush_graphic", "false");
                }
                catch { };
            }
        }
        public override long set_after()
        {

            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.DispObj((HObject)ho_Image[ImageName], hWindowControl1.HalconWindow);
                run();
               //HOperatorSet.CloseWindow(WinHandle1);
                dispresult();
                if (WinHandle1 == null) //在主窗口打开一个新窗口 
                    HOperatorSet.OpenWindow(0, 0, hv_WidthPolar / 2, hv_HeightPolar / 2, hWindowControl1.HalconWindow, "visible", "", out WinHandle1);
                HOperatorSet.SetPart(WinHandle1, 0, 0, hv_HeightPolar - 1, hv_WidthPolar - 1);
                HOperatorSet.DispObj(outImage, WinHandle1);
                HSystem.SetSystem("flush_graphic", "false");
                watch.Stop();
                timer = watch.ElapsedMilliseconds;
                return watch.ElapsedMilliseconds;
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
                timer = 0;
                return 0;
            }
        }
        public override bool toolResult()
        {
            return ResultLogic;
        }
        private void PolarTransImage(HObject ho_Image, out HObject ho_PolarTransImage,
      out HObject ho_ImageRotate, HTuple hv_Row, HTuple hv_Column, HTuple hv_InnerRadius,
      HTuple hv_OuterRadius, HTuple hv_AngleStart, HTuple hv_AngleEnd, out HTuple hv_WidthPolar, out HTuple hv_HeightPolar)
        {
            // Local iconic variables 
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_PolarTransImage);
            HOperatorSet.GenEmptyObj(out ho_ImageRotate);
            hv_WidthPolar = (((hv_OuterRadius * ((new HTuple(180)).TupleRad())) + 120)).TupleRound();
            hv_HeightPolar = ((hv_OuterRadius - hv_InnerRadius)).TupleRound()+10;
            ho_PolarTransImage.Dispose();
            HOperatorSet.PolarTransImageExt(ho_Image, out ho_PolarTransImage, hv_Row, hv_Column,
                hv_AngleStart.TupleRad(), hv_AngleEnd.TupleRad(), hv_InnerRadius,
                hv_OuterRadius, hv_WidthPolar, hv_HeightPolar, "bilinear");
            ho_ImageRotate.Dispose();
            HOperatorSet.RotateImage(ho_PolarTransImage, out ho_ImageRotate, 180, "constant");
            return;
        }

    }
}
