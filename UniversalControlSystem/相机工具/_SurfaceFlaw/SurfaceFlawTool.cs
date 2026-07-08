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
    public class SurfaceFlawTool : ImageTool//瑕疵
    {
        // Local iconic variables 
        [NonSerialized]
        HObject ho_ROI_0, ho_AreaEmptyObject, RegionAffineTrans,ho_ImageReduced;
        // Local control variables 
        [NonSerialized]
        HTuple hv_Width = null, hv_Height = null;
        public HObject ROI
        {
            get { return ho_ROI_0; }
            set { ho_ROI_0 = value; }
        }
        [NonSerialized]
        List<HTuple> phi = new List<HTuple>();
        public List<HTuple> Phi
        {
            get { return phi; }
            set { phi = value; }
        }
        [NonSerialized]
        List<HTuple> hv_HomMat2D = new List<HTuple>();
        public List<HTuple> HomMat2D
        {
            get { return hv_HomMat2D; }
            set { hv_HomMat2D = value; }
        }

        [NonSerialized]
         Dictionary<string, List<HTuple>> htHomMat2D = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> HtHomMat2D
        {
            get { return htHomMat2D; }
            set { htHomMat2D = value; }
        }
        [NonSerialized]
         Dictionary<string, List<HTuple>> htPhi = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> HtPhi
        {
            get { return htPhi; }
            set { htPhi = value; }
        }
        #region 输出结果
        /// <summary>
        /// 输出结果
        /// </summary>
        public bool ResultLogic { get; set; }
      
        #endregion
        #region 参数
        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName
        { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names { get; set; }
        public string FixNames
        { get; set; }
        [NonSerialized]
         Dictionary<string, HObject> ho_Image = new  Dictionary<string, HObject>();
        /// <summary>
        /// 输入图像
        /// </summary>
        public  Dictionary<string, HObject> Image
        {
            get { return ho_Image; }
            set { ho_Image = value; }
        }
        /// <summary>
        /// 使用位置定位
        /// </summary>
        public bool IsFixture { get; set; }

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
        /// <summary>
        /// 最小面积
        /// </summary>
        public HTuple Select_shapeMin { get; set; }
        /// <summary>
        /// 最大面积
        /// </summary>
        public HTuple Select_shapeMax { get; set; }
        /// <summary>
        ///ROI形状
        /// </summary>
        public string SetdrawShape { get; set; }
        public HTuple MaskWidth { get; set; }
        public HTuple MaskHeight { get; set; }
        public HTuple Offset { get; set; }
        public string LightDrak { get; set; }
        /// <summary>
        /// 使用限定区域
        /// </summary>
        public bool IsRoi { get; set; }
        /// <summary>
        /// 区域最小方向矩形显示
        /// </summary>
        public bool IsRectangle
        { get; set; }
        public bool IsFlaw { get; set; }

        /// <summary>
        /// 轮廓显示
        /// </summary>
        public string Setdraw { get; set; }
        #endregion
        public override string toolName()
        {
            return Names;
        }
        public override long toolTimer()
        {
            return timer;
        }
        public override void recon()
        { }
        public override void ini()
        {
            Names = Tool.瑕疵提取检测.ToString();
            ImageName = "采集图像0";
            FixNames = Tool.位置定位.ToString();
            IsFixture = false;
            IsFlaw = true; //瑕疵
            IsRectangle = false;
            Select_shapeMin = 50;
            Select_shapeMax = 999;
            MaskHeight = 5;
            MaskWidth = 5;
            Offset = 5;
            LightDrak = "light";

            IsRoi = true;//
            Setdraw = Set_draw.fill.ToString();
            SetdrawShape = Roi.矩形.ToString();

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
        
        
        }
        public override void draw_roi()
        {
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            draw_roi(hWindowControl1.HalconWindow, ho_Image, ImageName, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2, out hv_circle, out hv_rectangle1, out hv_rectangle2);
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
            dispresult();
            watch.Stop();
            timer = watch.ElapsedMilliseconds;
        }
        private void toolRun()
        {
            HObject ho_Img;
            HTuple hv_Number;
            try
            {
                if (IsFixture) //使用位置定位
                {   //
                    HomMat2D = (List<HTuple>)htHomMat2D[FixNames];  //  选择位置定位
                    if (RegionAffineTrans != null)
                        RegionAffineTrans.Dispose();
                    if (IsRoi)
                    {
                        gen_roi();
                        HOperatorSet.AffineTransRegion(ho_ROI_0, out RegionAffineTrans, HomMat2D[0], "nearest_neighbor");
                        HOperatorSet.ReduceDomain((HObject)ho_Image[ImageName], RegionAffineTrans, out ho_ImageReduced);
                        ho_Img = ho_ImageReduced;
                    }
                    else
                    {
                        ho_Img = (HObject)ho_Image[ImageName];
                    }
                 }
                else
                {
                    if (IsRoi)
                    {
                        gen_roi();
                        HOperatorSet.ReduceDomain((HObject)ho_Image[ImageName], ho_ROI_0, out ho_ImageReduced);
                        ho_Img = ho_ImageReduced;
                    }
                    else
                    {
                        ho_Img = (HObject)ho_Image[ImageName];
                    }
                }
                HOperatorSet.GetImageSize(ho_Img, out hv_Width, out hv_Height);
                if (ho_AreaEmptyObject != null)
                    ho_AreaEmptyObject.Dispose();
                dynThreshold(ho_Img, out ho_AreaEmptyObject, MaskWidth, MaskHeight, Select_shapeMin, Select_shapeMax, Offset, LightDrak);
                hv_Number = ho_AreaEmptyObject.CountObj();
                if (hv_Number.Length > 0)
                    ResultLogic = false;//结果异常
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
               if (ho_AreaEmptyObject != null)
                {
                    ho_AreaEmptyObject.Dispose();
                }
                ResultLogic = false;//不合格
                HSystem.SetSystem("flush_graphic", "false");
            }
      
        }
        public override void dispresult()
        {
            try
            {
                HTuple hv_row1, hv_col1, hv_row2, hv_col2;
                HObject ho_RegionTrans;
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Setdraw);//边/轮廓
                HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 2);
                HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.green.ToString());
                if (IsRoi)
                {
                    HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
                    HOperatorSet.DispObj(ho_ROI_0, hWindowControl1.HalconWindow);
                }
                HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 1);
                HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.red.ToString());
                if (IsFlaw)//瑕疵
                {
                    HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Setdraw) ;
                    HOperatorSet.DispObj(ho_AreaEmptyObject, hWindowControl1.HalconWindow);
                }
                if (IsRectangle)//最小方向矩形 
                {
                    HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());//边/轮廓
                    HOperatorSet.SmallestRectangle1(ho_AreaEmptyObject, out hv_row1, out hv_col1, out hv_row2, out hv_col2);
                    HOperatorSet.ShapeTrans(ho_AreaEmptyObject, out ho_RegionTrans, "rectangle1");
                    HOperatorSet.DispObj(ho_RegionTrans, hWindowControl1.HalconWindow);
                    ho_RegionTrans.Dispose();
                }
                HSystem.SetSystem("flush_graphic", "false");
            }
            catch (HalconException ex)
            {
                HTuple hv_Exception;
                ex.ToHTuple(out hv_Exception);
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "{" + hv_Exception + "}", CoordSystem.window.ToString(), 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
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
                HSystem.SetSystem("flush_graphic", "false");
                run();
                dispresult();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ho_Image">输入图像</param>
        /// <param name="ho_SelectedRegions">瑕疵输出</param>
        /// <param name="hv_maskWith">掩模宽度</param>
        /// <param name="hv_maskHeith">掩模高度</param>
        /// <param name="hv_selectMin">最小瑕疵</param>
        /// <param name="hv_selectMax">最大瑕疵</param>
        /// <param name="hv_offset">偏移</param>
        /// <param name="hv_lightDark">瑕疵暗/亮</param>
        public void dynThreshold(HObject ho_Image, out HObject ho_SelectedRegions, HTuple hv_maskWith,
            HTuple hv_maskHeith, HTuple hv_selectMin, HTuple hv_selectMax, HTuple hv_offset, HTuple hv_lightDark)
        {
            // Local iconic variables 

            HObject ho_ImageMean, ho_DarkPixels, ho_ConnectedRegions;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_ImageMean);
            HOperatorSet.GenEmptyObj(out ho_DarkPixels);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            try
            {
                ho_ImageMean.Dispose();
                HOperatorSet.MeanImage(ho_Image, out ho_ImageMean, hv_maskWith, hv_maskHeith);
                ho_DarkPixels.Dispose();
                HOperatorSet.DynThreshold(ho_Image, ho_ImageMean, out ho_DarkPixels, hv_offset, hv_lightDark);
                //
                //Extract connected components
                ho_ConnectedRegions.Dispose();
                HOperatorSet.Connection(ho_DarkPixels, out ho_ConnectedRegions);
                ho_SelectedRegions.Dispose();
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, "area", "and", hv_selectMin, hv_selectMax);
                ho_ImageMean.Dispose();
                ho_DarkPixels.Dispose();
                ho_ConnectedRegions.Dispose();
                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_ImageMean.Dispose();
                ho_DarkPixels.Dispose();
                ho_ConnectedRegions.Dispose();

                throw HDevExpDefaultException;
            }
        }
     public void disp_(HObject ho_Image, HObject ho_RegionTrans, HTuple hv_Class)
        {
            // Local iconic variables 
            HObject ho_SortedRegions,ho_ShapeTransRegion;
            // Local control variables 
            HTuple hv_Width = null, hv_Height = null, hv_Area = null;
            HTuple hv_Row = null, hv_Column = null, hv_i = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_SortedRegions);
            try
            {
                HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
                ho_SortedRegions.Dispose();
                HOperatorSet.SortRegion(ho_RegionTrans, out ho_SortedRegions, "character",
                    "true", "row");
                HOperatorSet.AreaCenter(ho_SortedRegions, out hv_Area, out hv_Row, out hv_Column);
                HOperatorSet.ShapeTrans(ho_SortedRegions, out ho_ShapeTransRegion, "");
                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_SortedRegions.Dispose();
                throw HDevExpDefaultException;
            }
        }
        public override bool toolResult()
        {
            return ResultLogic;
        }

    }
}
