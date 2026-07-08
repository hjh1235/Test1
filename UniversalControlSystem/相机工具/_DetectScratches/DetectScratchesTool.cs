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
    public class DetectScratchesTool:ImageTool
    {

        // Local iconic variables 
        [NonSerialized]
        HObject ho_ROI_0, ho_ScratchesXLD, RegionAffineTrans, ho_ImageReduced;
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

        /// <summary>
        /// 划痕宽度
        /// </summary>
        public HTuple ScratchWidth
        { get; set; }
       /// <summary>
        /// 划痕对比度
       /// </summary>
        public HTuple ScratchContrast
        { get; set; }
        /// <summary>
        ///平滑
        /// </summary>
        public HTuple Sigma
        { get; set; }
        public HTuple ScratchProperty
        { get; set; }
         /// <summary>
         ///  划痕最小长度
         /// </summary>
         public HTuple MinScratchLength
         { get; set; }
         /// <summary>
         /// 划痕最大长度
         /// </summary>
         public HTuple MaxScratchLength
         { get; set; }

        public bool IsScratchesXLD
        { get; set; }
        public bool IsRoi
        { get; set; }


        /// <summary>
        /// 区域最小方向矩形显示
        /// </summary>
        public bool IsRectangle
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
            Names = ImageTool.Tool.划痕提取检测.ToString();
            ImageName = "采集图像0";
            FixNames = Tool.位置定位.ToString();
            IsFixture = false;

            ScratchWidth = 2;
            ScratchContrast = 8;
            Sigma = 1.2;
            MinScratchLength = 3;
            MaxScratchLength = 99998;
            ScratchProperty = "dark";
            IsScratchesXLD = true;
            IsRectangle = true;
            IsRoi = true;//
            Setdraw = Set_draw.fill.ToString();

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
            HTuple hv_Zoom = null, hv_High = null, hv_Low = null;
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
                if (ho_ScratchesXLD != null)
                    ho_ScratchesXLD.Dispose();
                CalculateLinesGaussParameters(ScratchWidth, ScratchContrast, out hv_Zoom, out hv_High, out hv_Low);
                LinesGauss(ho_Img, out ho_ScratchesXLD, hv_Zoom, Sigma, hv_Low, hv_High,
                ScratchProperty, MinScratchLength, MaxScratchLength, out hv_Number);
                if (hv_Number.Length > 0)
                    ResultLogic = false;//结果异常
            }
            catch (HalconException ex)
            {
                HTuple hv_Exception;
                ex.ToHTuple(out  hv_Exception);
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "{" + hv_Exception + "}", CoordSystem.window.ToString(), 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
            }
           
        }
        public override void dispresult()
        {
             try
            {
                HTuple hv_row1, hv_col1, hv_len1, hv_len2, hv_phi1;
                HObject ho_Rectangle;
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
                HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 2);
                HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.green.ToString());
                if (IsRoi)
                    HOperatorSet.DispObj(ho_ROI_0, hWindowControl1.HalconWindow);
                HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 1);
                HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.red.ToString());
                if (IsScratchesXLD)//划痕
                    HOperatorSet.DispObj(ho_ScratchesXLD, hWindowControl1.HalconWindow);
                if (IsRectangle)//最小方向矩形 
                {
                    dispRegion(ho_ScratchesXLD);
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
        void LinesGauss(HObject ho_Image, out HObject ho_ScratchesXLD, HTuple hv_Zoom,
      HTuple hv_sigma, HTuple hv_Low, HTuple hv_High, HTuple hv_Scratch_Property,
      HTuple hv_Minimum_Scratch_Length, HTuple hv_Maximum_Scratch_Length, out HTuple hv_Number)
        {

            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];

            // Local iconic variables 

            HObject ho_ImageZoomed, ho_LinesZoomedTmp1;
            HObject ho_LinesZoomedTmp2, ho_LinesZoomedTmp, ho_LinesZoomed;

            // Local control variables 

            HTuple hv_WidthImage = null, hv_HeightImage = null;
            HTuple hv_HomMat2DIdentity = new HTuple(), hv_HomMat2DScale = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ScratchesXLD);
            HOperatorSet.GenEmptyObj(out ho_ImageZoomed);
            HOperatorSet.GenEmptyObj(out ho_LinesZoomedTmp1);
            HOperatorSet.GenEmptyObj(out ho_LinesZoomedTmp2);
            HOperatorSet.GenEmptyObj(out ho_LinesZoomedTmp);
            HOperatorSet.GenEmptyObj(out ho_LinesZoomed);
            ho_ImageZoomed.Dispose();
            HOperatorSet.ZoomImageFactor(ho_Image, out ho_ImageZoomed, hv_Zoom, hv_Zoom,
                "constant");
            ho_LinesZoomedTmp1.Dispose();
            HOperatorSet.LinesGauss(ho_ImageZoomed, out ho_LinesZoomedTmp1, hv_sigma, hv_Low,
                hv_High, hv_Scratch_Property, "false", "gaussian", "false");
            ho_LinesZoomedTmp2.Dispose();
            HOperatorSet.SelectContoursXld(ho_LinesZoomedTmp1, out ho_LinesZoomedTmp2, "contour_length",
                5, 100000, -0.5, 0.5);
            ho_LinesZoomedTmp.Dispose();
            HOperatorSet.UnionCollinearContoursXld(ho_LinesZoomedTmp2, out ho_LinesZoomedTmp,
                1, 0, 2, 0.1, "attr_keep");
            {
                HObject ExpTmpOutVar_0;
                HOperatorSet.SelectContoursXld(ho_LinesZoomedTmp, out ExpTmpOutVar_0, "contour_length",
                    hv_Minimum_Scratch_Length * hv_Zoom, hv_Maximum_Scratch_Length, -0.5, 0.5);
                ho_LinesZoomedTmp.Dispose();
                ho_LinesZoomedTmp = ExpTmpOutVar_0;
            }
            ho_LinesZoomed.Dispose();
            HOperatorSet.UnionCollinearContoursXld(ho_LinesZoomedTmp, out ho_LinesZoomed,
                40, 10, 10, 0.2, "attr_keep");
            HOperatorSet.CountObj(ho_LinesZoomed, out hv_Number);
            HOperatorSet.GetImageSize(ho_Image, out hv_WidthImage, out hv_HeightImage);
            if ((int)(new HTuple(hv_Number.TupleGreater((hv_WidthImage * hv_HeightImage) / 750))) != 0)
            {
                ho_ScratchesXLD.Dispose();
                HOperatorSet.GenEmptyObj(out ho_ScratchesXLD);
            }
            else
            {
                HOperatorSet.HomMat2dIdentity(out hv_HomMat2DIdentity);
                HOperatorSet.HomMat2dScale(hv_HomMat2DIdentity, 1.0 / hv_Zoom, 1.0 / hv_Zoom, 0,
                    0, out hv_HomMat2DScale);
                ho_ScratchesXLD.Dispose();
                HOperatorSet.AffineTransContourXld(ho_LinesZoomed, out ho_ScratchesXLD, hv_HomMat2DScale);
            }
            ho_ImageZoomed.Dispose();
            ho_LinesZoomedTmp1.Dispose();
            ho_LinesZoomedTmp2.Dispose();
            ho_LinesZoomedTmp.Dispose();
            ho_LinesZoomed.Dispose();

            return;
        }

       void CalculateLinesGaussParameters(HTuple hv_ScratchWidth, HTuple hv_ScratchContrast,
    out HTuple hv_Zoom, out HTuple hv_High, out HTuple hv_Low)
      {
          // Local iconic variables 
          // Initialize local and output iconic variables 
          hv_Zoom = 1.0 / hv_ScratchWidth;
          hv_High = hv_ScratchContrast / 4.0;
          hv_Low = hv_High / 2.0;
          return;
      }
         void dispRegion(HObject ho_ScratchesXLD)
        {
            // Local iconic variables 

            HObject ho_ObjectSelected = null, ho_Region1 = null;
            HObject ho_RegionTrans = null;

            // Local control variables 

            HTuple hv_Number1 = null, hv_Index = null;
            HTuple hv_Row = new HTuple(), hv_Col = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
            HOperatorSet.GenEmptyObj(out ho_Region1);
            HOperatorSet.GenEmptyObj(out ho_RegionTrans);
            try
            {
                HOperatorSet.CountObj(ho_ScratchesXLD, out hv_Number1);
                HTuple end_val1 = hv_Number1;
                HTuple step_val1 = 1;
                for (hv_Index = 1; hv_Index.Continue(end_val1, step_val1); hv_Index = hv_Index.TupleAdd(step_val1))
                {
                    ho_ObjectSelected.Dispose();
                    HOperatorSet.SelectObj(ho_ScratchesXLD, out ho_ObjectSelected, hv_Index);
                    HOperatorSet.GetContourXld(ho_ObjectSelected, out hv_Row, out hv_Col);
                    ho_Region1.Dispose();
                    HOperatorSet.GenRegionPolygon(out ho_Region1, hv_Row, hv_Col);
                    ho_RegionTrans.Dispose();
                    HOperatorSet.ShapeTrans(ho_Region1, out ho_RegionTrans, "rectangle1");
                    HOperatorSet.DispObj(ho_RegionTrans, hWindowControl1.HalconWindow);
                }
                ho_ObjectSelected.Dispose();
                ho_Region1.Dispose();
                ho_RegionTrans.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_ObjectSelected.Dispose();
                ho_Region1.Dispose();
                ho_RegionTrans.Dispose();

                throw HDevExpDefaultException;
            }
        }
    }
}
