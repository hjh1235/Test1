using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using HOperatorSet_EX;
namespace UniversalControlSystem
{
    [Serializable]
    public class OCRMaxTool : ImageTool
    {
      // Local iconic variables 
        [NonSerialized]
        HObject ho_ROI_0, ho_AreaEmptyObject;
        [NonSerialized]
        HObject ho_Cross, ho_Rectangle;
        [NonSerialized]
        // Local iconic variables 
        HObject ho_RegionForegroundImage, ho_RegionBackgroundImage;
        // Local control variables 
        HTuple hv_BackgroundGValMode, hv_ForegroundGValMode;
        // Local control variables 
        [NonSerialized]
        HTuple hv_Width = null, hv_Height = null;
        [NonSerialized]
        HTuple hv_Class = null, hv_Confidence = null;

        [NonSerialized]
        HTuple hv_Row1 = null, hv_Column1 = null, hv_Row2 = null, hv_Column2;
        [NonSerialized]
        List<HTuple> phi = new List<HTuple>();

        public HTuple BackgroundGValMode
        {
            get { return hv_BackgroundGValMode; }
            set { hv_BackgroundGValMode = value; }
        }
        public HTuple ForegroundGValMode
        {
            get { return hv_ForegroundGValMode; }
            set { hv_ForegroundGValMode = value; }
        }
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
        #region 输出结果
        /// <summary>
        /// 输出结果
        /// </summary>
        public bool ResultLogic { get; set; }
        public HTuple ResultClass
        {
            get { return hv_Class; }
            set { hv_Class = value; }
        }
         public HTuple  ResultConfidence
        {
            get { return hv_Confidence; }
            set { hv_Confidence = value; }
        }
        #endregion
        #region 输出结果判定
        public HTuple LowAera
        { get; set; }
        public HTuple HigAera
        { get; set; }
        public bool   IsAera
        { get; set; }
         public HTuple LowNums
        { get; set; }
        public HTuple HigNums
        { get; set; }
        public bool IsNums
        { get; set; }
        public bool IsIllumination
        { get; set; }
        #endregion
        #region 参数
        string imageName;
        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }
        public bool IsRegion { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string RegionName
        { get; set; }
        [NonSerialized]
         Dictionary<string, HObject> ho_Region = new  Dictionary<string, HObject>();
        /// <summary>
        /// 输入区域
        /// </summary>
        public  Dictionary<string, HObject> Region
        {
            get { return ho_Region; }
            set { ho_Region = value; }
        }
        string name;
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names
        {
            get { return name; }
            set { name = value; }
        }
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
        /// 低阀值
        /// </summary>
        public HTuple LowThreshold { get; set; }
         /// <summary>
        /// 高阀值
        /// </summary>
        public HTuple HigThreshold   { get; set; }
        /// <summary>
        /// 最小面积
        /// </summary>
        public HTuple Select_shapeMin  { get; set; }
        /// <summary>
        /// 最大面积
        /// </summary>
        public HTuple Select_shapeMax  { get; set; }
        /// <summary>
        /// 膨胀宽度
        /// </summary>
        public HTuple DilationWidth { get; set; }
        /// <summary>
        /// 膨胀高度
        /// </summary>
        public HTuple DilationHeight { get; set; }
         /// <summary>
         /// 切宽度
         /// </summary>
        public HTuple PartitionWidth { get; set; }
        /// <summary>
        /// 切高度
        /// </summary>
        public HTuple PartitionHeight { get; set; }
        /// <summary>
        /// OCR字符训练文件.omc
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 轮廓显示
        /// </summary>
        public string Setdraw { get; set; }
        /// <summary>
        ///ROI形状
        /// </summary>
        public string SetdrawShape   { get; set; }
        /// <summary>
        /// 区域显示
        /// </summary>
        public bool IsSelectedRegions { get; set; }
        /// <summary>
        /// 区域矩形显示
        /// </summary>
        public bool IsRectangle { get; set; }
        /// <summary>
        /// false 白字黑背/ true 黑字白背
        /// </summary>
         public bool IsBack   { get; set; }
        /// <summary>
        /// false 字符 /true 点状字符 
        /// </summary>
         public bool IsOcrSelect { get; set; }
         public HTuple OcrSelect { get; set; }

         public HTuple MaskWidth { get; set; }
         public HTuple MaskHeight { get; set; }
         public HTuple Offset { get; set; }
         public string LightDrak { get; set; }

        #endregion
         /// <summary>
        /// 工具名
        /// </summary>
        /// <returns></returns>
        public override string toolName()
        {
            return name;
        }
        public override long toolTimer()
        {
            return timer;
        }
        /// <summary>
        /// 加载创建
        /// </summary>
        public override void recon()
        {
            List<HTuple> hv_HomMat2D = new List<HTuple>();
        }
        /// <summary>
        /// 创建初始值
        /// </summary>
        public override void ini()
        {
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ROI_0);
            HOperatorSet.GenEmptyObj(out ho_AreaEmptyObject);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            FixNames = "位置坐标0";
            imageName = "采集图像0";
            name = Tool.字符识别检测.ToString();
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

            LowThreshold = 1;//低阀值
            HigThreshold = 150;//高阀值
            Select_shapeMin = 200;//最小面积
            Select_shapeMax = 49999;//最大面积
            DilationHeight = 1;//
            DilationWidth = 1;//
            PartitionHeight = 40;
            PartitionWidth = 20;
            FileName = "Pharma.omc";
 
            Setdraw = Set_draw.margin.ToString();//轮廓显示
            SetdrawShape = Roi.方向矩形.ToString(); ;//ROI形状
            IsSelectedRegions = false;//blob区域显示
            IsRectangle = false;//区域矩形显示
            IsBack = true;
            IsOcrSelect = false;
            IsFixture = false;
            IsIllumination = false;

            LowNums = 1;
            HigNums = 9;
            IsNums = false;

            MaskHeight = 5;
            MaskWidth = 5;
            Offset = 5;
            OcrSelect = 0;
            LightDrak = "light";
        }
        /// <summary>
        /// 
        /// </summary>
        public override void draw_roi()
        {
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            draw_roi(hWindowControl1.HalconWindow, ho_Image, ImageName,SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2, out hv_circle, out hv_rectangle1, out hv_rectangle2);
            if(ho_ROI_0 !=null)
            get_grayval_range((HObject)ho_Image[ImageName], ho_ROI_0, out ho_RegionForegroundImage, out ho_RegionBackgroundImage, out hv_BackgroundGValMode, out hv_ForegroundGValMode);
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
        /// 显示
        /// </summary>
        public override void dispresult()
        {
            try
            {
                if (ho_Cross != null)
                {
                    ho_Cross.Dispose();
                }
                if (ho_Rectangle != null)
                {
                    ho_Rectangle.Dispose();
                }
                this.dispresult(ho_AreaEmptyObject, out ho_Rectangle, Setdraw,
                     IsSelectedRegions, IsRectangle, out hv_Row1,
                     out hv_Column1, out hv_Row2, out hv_Column2);
                HSystem.SetSystem("flush_graphic", "true");
                disp_Ocr((HObject)ho_Image[imageName], ho_AreaEmptyObject, hv_Class);
                HSystem.SetSystem("flush_graphic", "false");

            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow,Names+ "运行异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
            }
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
        /// <summary>
        /// 运行
        /// </summary>
        public  void toolRun()
        {
            HObject RegionAffineTrans;
            HOperatorSet.GenEmptyObj(out RegionAffineTrans);
            try
            {  if (IsFixture) //使用位置定位
                {   //
                    HomMat2D = (List<HTuple>)dicHomMat2D[FixNames];  //  选择位置定位
                    HOperatorSet.GetImageSize((HObject)ho_Image[imageName], out hv_Width, out hv_Height);
                    if (ho_AreaEmptyObject != null)
                        ho_AreaEmptyObject.Dispose();
                    if (RegionAffineTrans != null)
                        RegionAffineTrans.Dispose();
                 
                    gen_roi();
                    HOperatorSet.AffineTransRegion(ho_ROI_0, out RegionAffineTrans, HomMat2D[0], "nearest_neighbor");
                    OCR((HObject)ho_Image[imageName], RegionAffineTrans, out ho_AreaEmptyObject, IsBack, OcrSelect, LowThreshold, HigThreshold, DilationWidth, DilationHeight,
                      Select_shapeMin, Select_shapeMax, PartitionWidth, PartitionHeight, FileName, MaskWidth, MaskHeight, Offset, LightDrak, out hv_Class, out hv_Confidence);
                    HSystem.SetSystem("flush_graphic", "true");
                    HOperatorSet.SetColored(hWindowControl1.HalconWindow, 12);
                    if (hv_Class.Length == 1)
                        HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.green.ToString());
                    HOperatorSet.DispObj(RegionAffineTrans, hWindowControl1.HalconWindow);
                    HSystem.SetSystem("flush_graphic", "false");
                }
                else
                {
                    HOperatorSet.GetImageSize((HObject)ho_Image[imageName], out hv_Width, out hv_Height);
                    if (ho_AreaEmptyObject != null)
                        ho_AreaEmptyObject.Dispose();
                    if (!IsRegion)
                    {
                        gen_roi();
                        OCR((HObject)ho_Image[imageName], ho_ROI_0, out ho_AreaEmptyObject, IsBack, OcrSelect, LowThreshold, HigThreshold, DilationWidth, DilationHeight,
                            Select_shapeMin, Select_shapeMax, PartitionWidth, PartitionHeight, FileName, MaskWidth, MaskHeight, Offset, LightDrak, out hv_Class, out hv_Confidence);
                    }
                    else
                    {
                        OCR((HObject)ho_Image[imageName], (HObject)ho_Region[RegionName], out ho_AreaEmptyObject, IsBack, OcrSelect, LowThreshold, HigThreshold, DilationWidth, DilationHeight,
                            Select_shapeMin, Select_shapeMax, PartitionWidth, PartitionHeight, FileName, MaskWidth, MaskHeight, Offset, LightDrak, out hv_Class, out hv_Confidence);
                    }
                    HSystem.SetSystem("flush_graphic", "true");
                    HOperatorSet.SetColored(hWindowControl1.HalconWindow, 12);
                    if (hv_Class.Length == 1)
                        HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.green.ToString());
                    HOperatorSet.DispObj(ho_ROI_0, hWindowControl1.HalconWindow);
                    HSystem.SetSystem("flush_graphic", "false");
                }
                ResultLogic = true;//合格
                if (IsNums)//使用数量管控
                {
                    if (LowNums > hv_Class.Length || hv_Class.Length > HigNums)
                        ResultLogic = false;//不合格
                }
            }
            catch (HalconException ex)
            {
                HSystem.SetSystem("flush_graphic", "true");
                HTuple exception;
                ex.ToHTuple(out exception);
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "运行异常{" + Names + "}\n" + exception.ToString(), CoordSystem.window.ToString(), 10, 10, "red", "false");
                hv_Class = null;
                hv_Confidence = null;
                if (ho_AreaEmptyObject != null)
                {
                    ho_AreaEmptyObject.Dispose();
                }
                ResultLogic = false;//不合格
                HSystem.SetSystem("flush_graphic", "false");
            }
          
        }
        /// <summary>
        /// 设置完运行
        /// </summary>
        /// <returns></returns>
        public override long set_after()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.DispObj((HObject)ho_Image[imageName], hWindowControl1.HalconWindow);
                HSystem.SetSystem("flush_graphic", "false");
                run();
                dispresult();
                watch.Stop();
                return watch.ElapsedMilliseconds;
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
                return 0;
            }

        }
        public override bool toolResult()
        {
            return ResultLogic;
        }

        void dispresult(HObject ho_AreaEmptyObject, out HObject ho_Rectangle, string drwaSet, bool isSelectedRegions,
            bool IsRectangle, out HTuple hv_Row1, out HTuple hv_Column1, out HTuple hv_Row2, out HTuple hv_Column2)
        {
          
                // Initialize local and output iconic variables 
                HOperatorSet.GenEmptyObj(out ho_Cross);
                HOperatorSet.GenEmptyObj(out ho_Rectangle);
                hv_Row1 = new HTuple();
                hv_Column1 = new HTuple();
                hv_Row2 = new HTuple();
                hv_Column2 = new HTuple();
                HSystem.SetSystem("flush_graphic", "true");

              
                    if (isSelectedRegions)
                    {
                        HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Setdraw);
                        HOperatorSet.DispObj(ho_AreaEmptyObject, hWindowControl1.HalconWindow);
                    }
                    if (IsRectangle)
                    {
                        HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
                        HOperatorSet.SmallestRectangle1(ho_AreaEmptyObject, out hv_Row1, out hv_Column1, out hv_Row2, out hv_Column2);
                        ho_Rectangle.Dispose();
                        HOperatorSet.GenRectangle1(out ho_Rectangle, hv_Row1, hv_Column1, hv_Row2, hv_Column2);
                        HOperatorSet.DispObj(ho_Rectangle, hWindowControl1.HalconWindow);
                    }

                    HSystem.SetSystem("flush_graphic", "false");
               
            }
         
      
      
        /// <summary>
        /// 字符识别
        /// </summary>
        /// <param name="ho_Image"></param>
        /// <param name="ho_ROI_0"></param>
        /// <param name="ho_RegionIntersection"></param>
        /// <param name="isback">识别背景</param>
        /// <param name="isOcrselect">ocr识别选则</param>
        /// <param name="hv_mingray"></param>
        /// <param name="hv_maxgray"></param>
        /// <param name="hv_dilationWidth"></param>
        /// <param name="hv_dilationHeight"></param>
        /// <param name="hv_area_min"></param>
        /// <param name="hv_area_max"></param>
        /// <param name="hv_partitionWith"></param>
        /// <param name="hv_partitionHeight"></param>
        /// <param name="hv_filename"></param>
        /// <param name="hv_Class"></param>
    void OCR(HObject ho_Image, HObject ho_ROI_0, out HObject ho_RegionIntersection,
    bool isback, bool isOcrselect, HTuple hv_mingray, HTuple hv_maxgray,
    HTuple hv_dilationWidth, HTuple hv_dilationHeight, HTuple hv_area_min, HTuple hv_area_max,
    HTuple hv_partitionWith, HTuple hv_partitionHeight, HTuple hv_filename, out HTuple hv_Class, out HTuple hv_Confidence)
        {
            // Local iconic variables 

            HObject ho_GrayImage, ho_ImageInvert, ho_img = null;
            HObject ho_ImageReduced1 = null, ho_Regions = null, ho_RegionDilation = null;
            HObject ho_ConnectedRegions1 = null, ho_SelectedRegions1 = null;
            HObject ho_RegionTrans1 = null, ho_Partitioned = null, ho_RegionUnion = null;
            HObject ho_ConnectedRegions2 = null, ho_SortedRegions1;

            // Local control variables 

            HTuple hv_OCRHandle = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_RegionIntersection);
            HOperatorSet.GenEmptyObj(out ho_GrayImage);
            HOperatorSet.GenEmptyObj(out ho_ImageInvert);
            HOperatorSet.GenEmptyObj(out ho_img);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced1);
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_RegionDilation);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions1);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions1);
            HOperatorSet.GenEmptyObj(out ho_RegionTrans1);
            HOperatorSet.GenEmptyObj(out ho_Partitioned);
            HOperatorSet.GenEmptyObj(out ho_RegionUnion);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions2);
            HOperatorSet.GenEmptyObj(out ho_SortedRegions1);
            ho_GrayImage.Dispose();
            HOperatorSet.Rgb1ToGray(ho_Image, out ho_GrayImage);
            ho_ImageInvert.Dispose();
            HOperatorSet.InvertImage(ho_GrayImage, out ho_ImageInvert);
            //黑体白字
            if (isback)
            {
                ho_img.Dispose();
                ho_img = ho_GrayImage.CopyObj(1, -1);
            }
            else
            {
                ho_img.Dispose();
                ho_img = ho_ImageInvert.CopyObj(1, -1);
            }
            //点状
            if (isOcrselect)
            {
                ho_ImageReduced1.Dispose();
                HOperatorSet.ReduceDomain(ho_GrayImage, ho_ROI_0, out ho_ImageReduced1);
                ho_Regions.Dispose();
                HOperatorSet.Threshold(ho_ImageReduced1, out ho_Regions, hv_mingray, hv_maxgray);
                ho_RegionDilation.Dispose();
                HOperatorSet.DilationRectangle1(ho_Regions, out ho_RegionDilation, hv_dilationWidth,
                    hv_dilationHeight);
                ho_ConnectedRegions1.Dispose();
                HOperatorSet.Connection(ho_RegionDilation, out ho_ConnectedRegions1);
                ho_SelectedRegions1.Dispose();
                HOperatorSet.SelectShape(ho_ConnectedRegions1, out ho_SelectedRegions1, "area",
                    "and", hv_area_min, hv_area_max);
                ho_RegionTrans1.Dispose();
                HOperatorSet.ShapeTrans(ho_SelectedRegions1, out ho_RegionTrans1, "rectangle1");
                ho_Partitioned.Dispose();
                HOperatorSet.PartitionRectangle(ho_RegionTrans1, out ho_Partitioned, hv_partitionWith,
                    hv_partitionHeight);
                ho_RegionIntersection.Dispose();
                HOperatorSet.Intersection(ho_Partitioned, ho_Regions, out ho_RegionIntersection
                    );

            }
            else
            {
                ho_ImageReduced1.Dispose();
                HOperatorSet.ReduceDomain(ho_GrayImage, ho_ROI_0, out ho_ImageReduced1);
                ho_Regions.Dispose();
                HOperatorSet.Threshold(ho_ImageReduced1, out ho_Regions, hv_mingray, hv_maxgray);
                ho_ConnectedRegions1.Dispose();
                HOperatorSet.Connection(ho_Regions, out ho_ConnectedRegions1);
                ho_SelectedRegions1.Dispose();
                HOperatorSet.SelectShape(ho_ConnectedRegions1, out ho_SelectedRegions1, "area",
                    "and", hv_area_min, hv_area_max);
                ho_RegionDilation.Dispose();
                HOperatorSet.DilationRectangle1(ho_SelectedRegions1, out ho_RegionDilation,
                    hv_dilationWidth, hv_dilationHeight);
                ho_RegionUnion.Dispose();
                HOperatorSet.Union1(ho_RegionDilation, out ho_RegionUnion);
                ho_ConnectedRegions2.Dispose();
                HOperatorSet.Connection(ho_RegionUnion, out ho_ConnectedRegions2);
                ho_RegionTrans1.Dispose();
                HOperatorSet.ShapeTrans(ho_ConnectedRegions2, out ho_RegionTrans1, "rectangle1");
                ho_RegionIntersection.Dispose();
                HOperatorSet.Intersection(ho_RegionTrans1, ho_ConnectedRegions2, out ho_RegionIntersection
                    );
            }
            ho_SortedRegions1.Dispose();
            HOperatorSet.SortRegion(ho_RegionIntersection, out ho_SortedRegions1, "character",
                "true", "row");
            HOperatorSet.ReadOcrClassMlp(hv_filename, out hv_OCRHandle);
            HOperatorSet.DoOcrMultiClassMlp(ho_SortedRegions1, ho_img, hv_OCRHandle, out hv_Class,
                out hv_Confidence);
            HOperatorSet.ClearOcrClassMlp(hv_OCRHandle);
            ho_GrayImage.Dispose();
            ho_ImageInvert.Dispose();
            ho_img.Dispose();
            ho_ImageReduced1.Dispose();
            ho_Regions.Dispose();
            ho_RegionDilation.Dispose();
            ho_ConnectedRegions1.Dispose();
            ho_SelectedRegions1.Dispose();
            ho_RegionTrans1.Dispose();
            ho_Partitioned.Dispose();
            ho_SortedRegions1.Dispose();
            return;
        }


   void OCR(HObject ho_Image, HObject ho_ROI_0, out HObject ho_RegionIntersection,
   bool isback, HTuple hv_isOcrselect, HTuple hv_mingray, HTuple hv_maxgray,
  HTuple hv_dilationWidth, HTuple hv_dilationHeight, HTuple hv_area_min, HTuple hv_area_max,
  HTuple hv_partitionWith, HTuple hv_partitionHeight, HTuple hv_filename, HTuple hv_maskWidth,
  HTuple hv_maskHeight, HTuple hv_offset, HTuple hv_lightDark, out HTuple hv_Class, out HTuple hv_Confidence)
    {

        // Local iconic variables 

        HObject ho_GrayImage, ho_ImageInvert, ho_img = null;
        HObject ho_ImageReduced1 = null, ho_ImageScale=null, ho_Regions = null, ho_RegionDilation = null, ho_RegionDilation1 = null;
            HObject ho_ConnectedRegions1 = null, ho_SelectedRegions1 = null, ho_RegionIntersection1=null;
        HObject ho_RegionTrans1 = null, ho_Partitioned = null, ho_RegionUnion = null;
        HObject ho_ConnectedRegions2 = null, ho_ImageMean = null, ho_RegionDynThresh = null;
        HObject ho_SortedRegions1;


        HTuple hv_Mult = new HTuple(), hv_Add = new HTuple(); 
        HTuple hv_OCRHandle = null;
        // Initialize local and output iconic variables 
        HOperatorSet.GenEmptyObj(out ho_RegionIntersection);
        HOperatorSet.GenEmptyObj(out ho_GrayImage);
        HOperatorSet.GenEmptyObj(out ho_ImageInvert);
        HOperatorSet.GenEmptyObj(out ho_img);
        HOperatorSet.GenEmptyObj(out ho_ImageReduced1);
            HOperatorSet.GenEmptyObj(out ho_ImageScale);
            HOperatorSet.GenEmptyObj(out ho_Regions);
        HOperatorSet.GenEmptyObj(out ho_RegionDilation);
            HOperatorSet.GenEmptyObj(out ho_RegionDilation1);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions1);
        HOperatorSet.GenEmptyObj(out ho_SelectedRegions1);
            HOperatorSet.GenEmptyObj(out ho_RegionIntersection1);
            HOperatorSet.GenEmptyObj(out ho_RegionTrans1);
        HOperatorSet.GenEmptyObj(out ho_Partitioned);
        HOperatorSet.GenEmptyObj(out ho_RegionUnion);
        HOperatorSet.GenEmptyObj(out ho_ConnectedRegions2);
        HOperatorSet.GenEmptyObj(out ho_ImageMean);
        HOperatorSet.GenEmptyObj(out ho_RegionDynThresh);
        HOperatorSet.GenEmptyObj(out ho_SortedRegions1);
        ho_GrayImage.Dispose();
        HOperatorSet.Rgb1ToGray(ho_Image, out ho_GrayImage);
        ho_ImageInvert.Dispose();
        HOperatorSet.InvertImage(ho_GrayImage, out ho_ImageInvert);
        //黑体白字
        if (isback)
        {
            ho_img.Dispose();
            ho_img = ho_GrayImage.CopyObj(1, -1);
        }
        else
        {
            ho_img.Dispose();
            ho_img = ho_ImageInvert.CopyObj(1, -1);
        }
        //HOperatorSet.DispObj(ho_GrayImage, hWindowControl1.HalconWindow);
        //点状
        if ((int)(new HTuple(hv_isOcrselect.TupleEqual(2))) != 0)    //点状字符
            {
            ho_ImageReduced1.Dispose();
            HOperatorSet.ReduceDomain(ho_GrayImage, ho_ROI_0, out ho_ImageReduced1);
            if (IsIllumination)
            {
                ho_ImageScale.Dispose();
                get_grayval_range1(ho_GrayImage, ho_ROI_0, hv_ForegroundGValMode, hv_BackgroundGValMode, out hv_Mult, out hv_Add);
                HOperatorSet.ScaleImage(ho_ImageReduced1, out ho_ImageScale, hv_Mult, hv_Add);
                ho_Regions.Dispose();
                HOperatorSet.Threshold(ho_ImageScale, out ho_Regions, hv_mingray, hv_maxgray);
            }
            else
            {
                ho_Regions.Dispose();
                HOperatorSet.Threshold(ho_ImageReduced1, out ho_Regions, hv_mingray, hv_maxgray);
            }
                //膨胀区域变为一体
              ho_RegionDilation.Dispose();
              HOperatorSet.DilationRectangle1(ho_Regions, out ho_RegionDilation, hv_dilationWidth, hv_dilationHeight);
                //膨胀区域
              ho_RegionDilation1.Dispose();
              HOperatorSet.DilationRectangle1(ho_Regions, out ho_RegionDilation1, 3, 3);
                //区域形状转化
              ho_RegionTrans1.Dispose();
              HOperatorSet.ShapeTrans(ho_RegionDilation, out ho_RegionTrans1, "rectangle1");
             //切开区域
              ho_Partitioned.Dispose();
              HOperatorSet.PartitionRectangle(ho_RegionTrans1, out ho_Partitioned, hv_partitionWith,hv_partitionHeight);
             //切开区域与预值区域交集
              ho_RegionIntersection1.Dispose();
              HOperatorSet.Intersection(ho_Partitioned, ho_RegionDilation1, out ho_RegionIntersection1);

                ////区域连通
                //ho_ConnectedRegions1.Dispose();
                //HOperatorSet.Connection(ho_RegionDilation, out ho_ConnectedRegions1);

                //选择区域面积
                ho_RegionIntersection.Dispose();
                HOperatorSet.SelectShape(ho_RegionIntersection1, out ho_RegionIntersection, "area", "and", hv_area_min, hv_area_max);

                //ho_RegionIntersection = ho_SelectedRegions1;

            }
        else if ((int)(new HTuple(hv_isOcrselect.TupleEqual(0))) != 0)//对比度大
        {
            ho_ImageReduced1.Dispose();
            HOperatorSet.ReduceDomain(ho_GrayImage, ho_ROI_0, out ho_ImageReduced1);
            if (IsIllumination)
            {
                ho_ImageScale.Dispose();
                get_grayval_range1(ho_GrayImage, ho_ROI_0, hv_ForegroundGValMode, hv_BackgroundGValMode, out hv_Mult, out hv_Add);
                HOperatorSet.ScaleImage(ho_ImageReduced1, out ho_ImageScale, hv_Mult, hv_Add);
                ho_Regions.Dispose();
                HOperatorSet.Threshold(ho_ImageScale, out ho_Regions, hv_mingray, hv_maxgray);
            }
            else
            {
                ho_Regions.Dispose();
                HOperatorSet.Threshold(ho_ImageReduced1, out ho_Regions, hv_mingray, hv_maxgray);
            }
             
            ho_ConnectedRegions1.Dispose();
            HOperatorSet.Connection(ho_Regions, out ho_ConnectedRegions1);
            ho_SelectedRegions1.Dispose();
            HOperatorSet.SelectShape(ho_ConnectedRegions1, out ho_SelectedRegions1, "area",
                "and", hv_area_min, hv_area_max);
            ho_RegionDilation.Dispose();
            HOperatorSet.DilationRectangle1(ho_SelectedRegions1, out ho_RegionDilation,
                hv_dilationWidth, hv_dilationHeight);
            ho_RegionUnion.Dispose();
            HOperatorSet.Union1(ho_RegionDilation, out ho_RegionUnion);
            ho_ConnectedRegions2.Dispose();
            HOperatorSet.Connection(ho_RegionUnion, out ho_ConnectedRegions2);
            ho_RegionTrans1.Dispose();
            HOperatorSet.ShapeTrans(ho_ConnectedRegions2, out ho_RegionTrans1, "rectangle1");
            ho_RegionIntersection.Dispose();
            HOperatorSet.Intersection(ho_RegionTrans1, ho_ConnectedRegions2, out ho_RegionIntersection
                );

        }
        else if ((int)(new HTuple(hv_isOcrselect.TupleEqual(1))) != 0)//光照不均匀
        {
            ho_ImageReduced1.Dispose();
            HOperatorSet.ReduceDomain(ho_GrayImage, ho_ROI_0, out ho_ImageReduced1);
            if (IsIllumination)
            {
                ho_ImageScale.Dispose();
                get_grayval_range1(ho_GrayImage, ho_ROI_0, hv_ForegroundGValMode, hv_BackgroundGValMode, out hv_Mult, out hv_Add);
                HOperatorSet.ScaleImage(ho_ImageReduced1, out ho_ImageScale, hv_Mult, hv_Add);
                ho_ImageMean.Dispose();
                HOperatorSet.MeanImage(ho_ImageScale, out ho_ImageMean, hv_maskWidth, hv_maskHeight);
                ho_RegionDynThresh.Dispose();
                HOperatorSet.DynThreshold(ho_ImageScale, ho_ImageMean, out ho_RegionDynThresh,
                    hv_offset, hv_lightDark);
            }
            else {

                HOperatorSet.MeanImage(ho_ImageReduced1, out ho_ImageMean, hv_maskWidth, hv_maskHeight);
                ho_RegionDynThresh.Dispose();
                HOperatorSet.DynThreshold(ho_ImageReduced1, ho_ImageMean, out ho_RegionDynThresh,
                    hv_offset, hv_lightDark);
    
            }
            ho_RegionDilation.Dispose();
            HOperatorSet.DilationRectangle1(ho_RegionDynThresh, out ho_RegionDilation,
                hv_dilationWidth, hv_dilationHeight);
            ho_ConnectedRegions1.Dispose();
            HOperatorSet.Connection(ho_RegionDilation, out ho_ConnectedRegions1);
            ho_SelectedRegions1.Dispose();
            HOperatorSet.SelectShape(ho_ConnectedRegions1, out ho_SelectedRegions1, "area",
                "and", hv_area_min, hv_area_max);
            ho_RegionTrans1.Dispose();
            HOperatorSet.ShapeTrans(ho_SelectedRegions1, out ho_RegionTrans1, "rectangle1");
            ho_RegionIntersection.Dispose();
            HOperatorSet.Intersection(ho_RegionTrans1, ho_SelectedRegions1, out ho_RegionIntersection
                );

        }
        ho_SortedRegions1.Dispose();
        HOperatorSet.SortRegion(ho_RegionIntersection, out ho_SortedRegions1, "character",
            "true", "row");
        HOperatorSet.ReadOcrClassMlp(@"ocr\"+hv_filename, out hv_OCRHandle);
        HOperatorSet.DoOcrMultiClassMlp(ho_SortedRegions1, ho_img, hv_OCRHandle, out hv_Class,
            out hv_Confidence);
        HOperatorSet.ClearOcrClassMlp(hv_OCRHandle);
        ho_GrayImage.Dispose();
        ho_ImageInvert.Dispose();
        ho_img.Dispose();
        ho_ImageReduced1.Dispose();
        ho_Regions.Dispose();
        ho_RegionDilation.Dispose();
        ho_ConnectedRegions1.Dispose();
        ho_SelectedRegions1.Dispose();
        ho_RegionTrans1.Dispose();
        ho_Partitioned.Dispose();
        ho_RegionUnion.Dispose();
        ho_ConnectedRegions2.Dispose();
        ho_ImageMean.Dispose();
        ho_RegionDynThresh.Dispose();
        ho_SortedRegions1.Dispose();

        return;
    }
    public void disp_Ocr(HObject ho_Image, HObject ho_RegionTrans, HTuple hv_Class)
    {
        // Local iconic variables 

        HObject ho_SortedRegions;

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
            
            for (hv_i = 0; (int)hv_i <= (int)((new HTuple(hv_Class.TupleLength())) - 1); hv_i = (int)hv_i + 1)
            {
               HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, hv_Class.TupleSelect(hv_i), "image",
                    (hv_Row.TupleSelect(0)) - (hv_Height / 15), hv_Column.TupleSelect(hv_i),"green", "false");
            }
            ho_SortedRegions.Dispose();
            return;
        }
        catch (HalconException HDevExpDefaultException)
        {
            ho_SortedRegions.Dispose();

            throw HDevExpDefaultException;
        }
    }
        /// <summary>
        /// 光照
        /// </summary>
        /// <param name="ho_ImageAffinTrans">输入图片</param>
        /// <param name="ho_RegionROI">光照区域</param>
        /// <param name="hv_ForegroundGVModel">前背景灰度值</param>
        /// <param name="hv_BackgroundGVModel">后背景灰度值</param>
        /// <param name="hv_Mult"></param>
        /// <param name="hv_Add"></param>
        public void get_grayval_range1(HObject ho_ImageAffinTrans, HObject ho_RegionROI,
        HTuple hv_ForegroundGVModel, HTuple hv_BackgroundGVModel, out HTuple hv_Mult,
        out HTuple hv_Add)
        {
            // Local iconic variables 
            HObject ho_RegionForegroundImage, ho_RegionBackgroundImage;
            // Local control variables 
            HTuple hv_BackgroundImage = null, hv_ForegroundImage = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_RegionForegroundImage);
            HOperatorSet.GenEmptyObj(out ho_RegionBackgroundImage);
            ho_RegionForegroundImage.Dispose(); ho_RegionBackgroundImage.Dispose();
            get_grayval_range(ho_ImageAffinTrans, ho_RegionROI, out ho_RegionForegroundImage,
                out ho_RegionBackgroundImage, out hv_BackgroundImage, out hv_ForegroundImage);
            //
            //Scale image to the model's gray value range
            hv_Mult = (hv_ForegroundGVModel - hv_BackgroundGVModel) / (hv_ForegroundImage - hv_BackgroundImage);
            hv_Add = hv_ForegroundGVModel - (hv_Mult * hv_ForegroundImage);
            ho_RegionForegroundImage.Dispose();
            ho_RegionBackgroundImage.Dispose();
            return;
        }

        public void get_grayval_range(HObject ho_Image, HObject ho_RegionROI, out HObject ho_RegionForeground,
        out HObject ho_RegionBackground, out HTuple hv_BackgroundGVal, out HTuple hv_ForegroundGVal)
        {
            // Local iconic variables 

            HObject ho_ImageReduced;

            // Local control variables 

            HTuple hv_UsedThreshold = null, hv_DeviationFG = null;
            HTuple hv_DeviationBG = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_RegionForeground);
            HOperatorSet.GenEmptyObj(out ho_RegionBackground);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            ho_ImageReduced.Dispose();
            HOperatorSet.ReduceDomain(ho_Image, ho_RegionROI, out ho_ImageReduced);
            ho_RegionBackground.Dispose();
            HOperatorSet.BinaryThreshold(ho_ImageReduced, out ho_RegionBackground, "max_separability",
                "dark", out hv_UsedThreshold);
            ho_RegionForeground.Dispose();
            HOperatorSet.Difference(ho_RegionROI, ho_RegionBackground, out ho_RegionForeground
                );
            HOperatorSet.Intensity(ho_RegionForeground, ho_Image, out hv_ForegroundGVal,
                out hv_DeviationFG);
            HOperatorSet.Intensity(ho_RegionBackground, ho_Image, out hv_BackgroundGVal,
                out hv_DeviationBG);
            ho_ImageReduced.Dispose();

            return;
        }
    }

}
