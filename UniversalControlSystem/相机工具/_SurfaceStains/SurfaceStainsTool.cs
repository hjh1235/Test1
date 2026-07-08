using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using System.Collections;
using HOperatorSet_EX;
using System.Diagnostics;
/// <summary>
/// 表面污点
/// </summary>
namespace UniversalControlSystem
{
    [Serializable]
    public class SurfaceStainsTool:ImageTool
    {
        [NonSerialized]
        HObject ho_ROI_0, ho_RegionOpening, RegionAffineTrans, ho_ImageReduced;
        public HObject ROI
        {
            get { return ho_ROI_0; }
            set { ho_ROI_0 = value; }
        }
        #region 输出结果判定
        /// <summary>
        /// 输出结果
        /// </summary>
        public bool ResultLogic { get; set; }
        #endregion
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
         Dictionary<string, List<HTuple>> dicHomMat2D = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> DicHomMat2D
        {
            get { return dicHomMat2D; }
            set { dicHomMat2D = value; }
        }
        [NonSerialized]
         Dictionary<string, List<HTuple>> dicPhi = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> DicPhi
        {
            get { return dicPhi; }
            set { dicPhi = value; }
        }

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
        /// 轮廓显示
        /// </summary>
        public string Setdraw { get; set; }
        /// <summary>
        ///ROI形状
        /// </summary>
        public string SetdrawShape { get; set; }
        public HTuple MinGray
        { get; set; }
        public HTuple MaxGray
        {  get; set; }
        public HTuple SelecteMin
        { get; set; }
        public HTuple SelecteMax
        { get; set; }
        public HTuple Sigma1
        { get; set; }
        public HTuple Sigma2
        { get; set; }

        public bool IsStains
        { get; set; }

        public bool IsRoi
        { get; set; }
        /// <summary>
        /// 区域最小方向矩形显示
        /// </summary>
        public bool IsRectangle
        { get; set; }
        public string Feature
        { get; set; }
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
            Names = ImageTool.Tool.脏污提取检测.ToString();
            ImageName = "采集图像0";
            FixNames = Tool.位置定位.ToString();
            IsFixture = false;
            Sigma1 = 30.0;
            Sigma2 = 5.0;
            SelecteMin = 50;
            SelecteMax = 999;
            MinGray = 25;
            MaxGray = 250;
            Feature = "distance_center";
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
            HSystem.SetSystem("flush_graphic", "true");
            HTuple hv_Number = null;
            HObject ho_Img;
            try
            {
                ResultLogic = true;//
                if (RegionAffineTrans != null)
                    RegionAffineTrans.Dispose();
                if (ho_ImageReduced != null)
                    ho_ImageReduced.Dispose();

                if (IsFixture) //使用位置定位
                {   //
                    HomMat2D = (List<HTuple>)dicHomMat2D[FixNames];  //  选择位置定位
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
                if (ho_RegionOpening != null)
                    ho_RegionOpening.Dispose();
                surfaceStains(ho_Img, out ho_RegionOpening, Sigma1, Sigma2, MinGray, MaxGray, SelecteMin, SelecteMax);
                hv_Number = ho_RegionOpening.CountObj();
                if (hv_Number.Length > 0)
                    ResultLogic = false;//结果异常
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
                    HOperatorSet.DispObj(ho_ROI_0, hWindowControl1.HalconWindow);
                HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 1);
                HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.red.ToString());
                if (IsStains)//污垢
                    HOperatorSet.DispObj(ho_RegionOpening, hWindowControl1.HalconWindow);
                if (IsRectangle)//最小方向矩形 
                {
                    HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());//边/轮廓
                    HOperatorSet.SmallestRectangle1(ho_RegionOpening, out hv_row1, out hv_col1, out hv_row2, out hv_col2);
                    HOperatorSet.ShapeTrans(ho_RegionOpening, out ho_RegionTrans, "rectangle1");
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
        public override bool toolResult()
        {
            return ResultLogic;
        }
        void scale_image_range(HObject ho_Image, out HObject ho_ImageScaled, HTuple hv_Min,
     HTuple hv_Max)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_SelectedChannel = null, ho_LowerRegion = null;
            HObject ho_UpperRegion = null;

            // Local copy input parameter variables 
            HObject ho_Image_COPY_INP_TMP;
            ho_Image_COPY_INP_TMP = ho_Image.CopyObj(1, -1);
            // Local control variables 

            HTuple hv_LowerLimit = new HTuple(), hv_UpperLimit = new HTuple();
            HTuple hv_Mult = null, hv_Add = null, hv_Channels = null;
            HTuple hv_Index = null, hv_MinGray = new HTuple(), hv_MaxGray = new HTuple();
            HTuple hv_Range = new HTuple();
            HTuple hv_Max_COPY_INP_TMP = hv_Max.Clone();
            HTuple hv_Min_COPY_INP_TMP = hv_Min.Clone();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ImageScaled);
            HOperatorSet.GenEmptyObj(out ho_SelectedChannel);
            HOperatorSet.GenEmptyObj(out ho_LowerRegion);
            HOperatorSet.GenEmptyObj(out ho_UpperRegion);
            //Convenience procedure to scale the gray values of the
            //input image Image from the interval [Min,Max]
            //to the interval [0,255] (default).
            //Gray values < 0 or > 255 (after scaling) are clipped.
            //
            //If the image shall be scaled to an interval different from [0,255],
            //this can be achieved by passing tuples with 2 values [From, To]
            //as Min and Max.
            //Example:
            //scale_image_range(Image:ImageScaled:[100,50],[200,250])
            //maps the gray values of Image from the interval [100,200] to [50,250].
            //All other gray values will be clipped.
            //
            //input parameters:
            //Image: the input image
            //Min: the minimum gray value which will be mapped to 0
            //     If a tuple with two values is given, the first value will
            //     be mapped to the second value.
            //Max: The maximum gray value which will be mapped to 255
            //     If a tuple with two values is given, the first value will
            //     be mapped to the second value.
            //
            //output parameter:
            //ImageScale: the resulting scaled image
            //
            if ((int)(new HTuple((new HTuple(hv_Min_COPY_INP_TMP.TupleLength())).TupleEqual(
                2))) != 0)
            {
                hv_LowerLimit = hv_Min_COPY_INP_TMP[1];
                hv_Min_COPY_INP_TMP = hv_Min_COPY_INP_TMP[0];
            }
            else
            {
                hv_LowerLimit = 0.0;
            }
            if ((int)(new HTuple((new HTuple(hv_Max_COPY_INP_TMP.TupleLength())).TupleEqual(
                2))) != 0)
            {
                hv_UpperLimit = hv_Max_COPY_INP_TMP[1];
                hv_Max_COPY_INP_TMP = hv_Max_COPY_INP_TMP[0];
            }
            else
            {
                hv_UpperLimit = 255.0;
            }
            //
            //Calculate scaling parameters
            hv_Mult = (((hv_UpperLimit - hv_LowerLimit)).TupleReal()) / (hv_Max_COPY_INP_TMP - hv_Min_COPY_INP_TMP);
            hv_Add = ((-hv_Mult) * hv_Min_COPY_INP_TMP) + hv_LowerLimit;
            //
            //Scale image
            {
                HObject ExpTmpOutVar_0;
                HOperatorSet.ScaleImage(ho_Image_COPY_INP_TMP, out ExpTmpOutVar_0, hv_Mult, hv_Add);
                ho_Image_COPY_INP_TMP.Dispose();
                ho_Image_COPY_INP_TMP = ExpTmpOutVar_0;
            }
            //
            //Clip gray values if necessary
            //This must be done for each channel separately
            HOperatorSet.CountChannels(ho_Image_COPY_INP_TMP, out hv_Channels);
            HTuple end_val48 = hv_Channels;
            HTuple step_val48 = 1;
            for (hv_Index = 1; hv_Index.Continue(end_val48, step_val48); hv_Index = hv_Index.TupleAdd(step_val48))
            {
                ho_SelectedChannel.Dispose();
                HOperatorSet.AccessChannel(ho_Image_COPY_INP_TMP, out ho_SelectedChannel, hv_Index);
                HOperatorSet.MinMaxGray(ho_SelectedChannel, ho_SelectedChannel, 0, out hv_MinGray,
                    out hv_MaxGray, out hv_Range);
                ho_LowerRegion.Dispose();
                HOperatorSet.Threshold(ho_SelectedChannel, out ho_LowerRegion, ((hv_MinGray.TupleConcat(
                    hv_LowerLimit))).TupleMin(), hv_LowerLimit);
                ho_UpperRegion.Dispose();
                HOperatorSet.Threshold(ho_SelectedChannel, out ho_UpperRegion, hv_UpperLimit,
                    ((hv_UpperLimit.TupleConcat(hv_MaxGray))).TupleMax());
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.PaintRegion(ho_LowerRegion, ho_SelectedChannel, out ExpTmpOutVar_0,
                        hv_LowerLimit, "fill");
                    ho_SelectedChannel.Dispose();
                    ho_SelectedChannel = ExpTmpOutVar_0;
                }
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.PaintRegion(ho_UpperRegion, ho_SelectedChannel, out ExpTmpOutVar_0,
                        hv_UpperLimit, "fill");
                    ho_SelectedChannel.Dispose();
                    ho_SelectedChannel = ExpTmpOutVar_0;
                }
                if ((int)(new HTuple(hv_Index.TupleEqual(1))) != 0)
                {
                    ho_ImageScaled.Dispose();
                    HOperatorSet.CopyObj(ho_SelectedChannel, out ho_ImageScaled, 1, 1);
                }
                else
                {
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.AppendChannel(ho_ImageScaled, ho_SelectedChannel, out ExpTmpOutVar_0
                            );
                        ho_ImageScaled.Dispose();
                        ho_ImageScaled = ExpTmpOutVar_0;
                    }
                }
            }
            ho_Image_COPY_INP_TMP.Dispose();
            ho_SelectedChannel.Dispose();
            ho_LowerRegion.Dispose();
            ho_UpperRegion.Dispose();

            return;
        }

        // Local procedures 
        public void surfaceStains(HObject ho_Image, out HObject ho_RegionOpening, HTuple hv_Sigma1,
            HTuple hv_Sigma2, HTuple hv_MinGray, HTuple hv_MaxGray, HTuple hv_SelecteMin,
            HTuple hv_SelecteMax)
        {
            // Local iconic variables 
            HObject ho_GaussFilter1, ho_GaussFilter2, ho_Filter;
            HObject ho_GrayImage, ho_ImageFFT, ho_ImageConvol, ho_ImageFiltered;
            HObject ho_ImageScaled, ho_Region, ho_ConnectedRegions;
            HObject ho_SelectedRegions;
            // Local control variables 
            HTuple hv_Width = null, hv_Height = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_RegionOpening);
            HOperatorSet.GenEmptyObj(out ho_GaussFilter1);
            HOperatorSet.GenEmptyObj(out ho_GaussFilter2);
            HOperatorSet.GenEmptyObj(out ho_Filter);
            HOperatorSet.GenEmptyObj(out ho_GrayImage);
            HOperatorSet.GenEmptyObj(out ho_ImageFFT);
            HOperatorSet.GenEmptyObj(out ho_ImageConvol);
            HOperatorSet.GenEmptyObj(out ho_ImageFiltered);
            HOperatorSet.GenEmptyObj(out ho_ImageScaled);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
            ho_GaussFilter1.Dispose();
            HOperatorSet.GenGaussFilter(out ho_GaussFilter1, hv_Sigma1, hv_Sigma1, 0.0, "none",
                "rft", hv_Width, hv_Height);
            ho_GaussFilter2.Dispose();
            HOperatorSet.GenGaussFilter(out ho_GaussFilter2, hv_Sigma2, hv_Sigma2, 0.0, "none",
                "rft", hv_Width, hv_Height);
            ho_Filter.Dispose();
            HOperatorSet.SubImage(ho_GaussFilter1, ho_GaussFilter2, out ho_Filter, 1, 0);
            ho_GrayImage.Dispose();
            HOperatorSet.Rgb1ToGray(ho_Image, out ho_GrayImage);
            ho_ImageFFT.Dispose();
            HOperatorSet.RftGeneric(ho_GrayImage, out ho_ImageFFT, "to_freq", "none", "complex",
                hv_Width);
            ho_ImageConvol.Dispose();
            HOperatorSet.ConvolFft(ho_ImageFFT, ho_Filter, out ho_ImageConvol);
            ho_ImageFiltered.Dispose();
            HOperatorSet.RftGeneric(ho_ImageConvol, out ho_ImageFiltered, "from_freq", "n",
                "real", hv_Width);
            ho_ImageScaled.Dispose();
            scale_image_range(ho_ImageFiltered, out ho_ImageScaled, 0, 255);
            ho_Region.Dispose();
            HOperatorSet.Threshold(ho_ImageScaled, out ho_Region, hv_MinGray, hv_MaxGray);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_Region, out ho_ConnectedRegions);
            ho_SelectedRegions.Dispose();
            //distance_contour
            // HOperatorSet.SelectShapeProto(ho_ConnectedRegions, ho_ConnectedRegions, out ho_SelectedRegions,Feature, hv_SelecteMin, hv_SelecteMax);
            HOperatorSet.SelectShapeProto(ho_ConnectedRegions, ho_Region, out ho_SelectedRegions, Feature, hv_SelecteMin, hv_SelecteMax);
            ho_RegionOpening.Dispose();
            HOperatorSet.OpeningCircle(ho_SelectedRegions, out ho_RegionOpening, 10);
            HTuple a, r, c;
            HOperatorSet.AreaCenter(ho_ConnectedRegions, out a, out r, out c);
            ho_GaussFilter1.Dispose();
            ho_GaussFilter2.Dispose();
            ho_Filter.Dispose();
            ho_GrayImage.Dispose();
            ho_ImageFFT.Dispose();
            ho_ImageConvol.Dispose();
            ho_ImageFiltered.Dispose();
            ho_ImageScaled.Dispose();
            ho_Region.Dispose();
            ho_ConnectedRegions.Dispose();
            ho_SelectedRegions.Dispose();

            return;
        }
    }
}
