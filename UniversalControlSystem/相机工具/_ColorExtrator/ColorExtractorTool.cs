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
    public class ColorExtractorTool:ImageTool
     {
          enum colorType
          { 
              Orange =0,
              Red=1,
              Blue=2,
              Yellow=3,
              Green
          }
          [NonSerialized]
           HTuple hv_Width, hv_Height, hv_area, hv_row, hv_col;
           HTuple hueRangesMins = new HTuple(), hueRangesMaxs = new HTuple();

           public HTuple HueRangesMaxs
           {
               get { return hueRangesMaxs; }
               set { hueRangesMaxs = value; }
           }

           public HTuple HueRangesMins
           {
               get { return hueRangesMins; }
               set { hueRangesMins = value; }
           }
           
          [NonSerialized]
          HObject ho_regionTrans;
      
        [NonSerialized]
        HObject ho_ROI_0, RegionAffineTrans, ho_ImageReduced;

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
        #region 判定输出结果
        public HTuple LowNums
        { get; set; }
        public HTuple HigNums
        { get; set; }
        public bool IsNums
        { get; set; }
        #endregion
        #region 输出结果
        /// <summary>
        /// 输出结果
        /// </summary>
        public bool ResultLogic { get; set; }
     
        #endregion
        #region 参数

        public string ImageName { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names { get; set; }

        /// <summary>
        /// 位置定位
        /// </summary>
        public string FixNames { get; set; }
        /// <summary>
        /// 使用位置定位
        /// </summary>
        public bool IsFixture { get; set; }
        [NonSerialized]
         Dictionary<string, HObject> ho_Image = new  Dictionary<string, HObject>();
        /// <summary>
        /// 输入图像
        /// </summary>
        public  Dictionary<string,HObject> Image
        {
            get { return ho_Image; }
            set { ho_Image = value; }
        }
        /// <summary>
        /// 使用限定区域
        /// </summary>
        public bool IsRoi { get; set; }

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
      
        public string SetdrawShape
        { get; set; }
    
        /// <summary>
        ///  识别最多数量
        /// </summary>
        public int ResultMaxNum { get; set; }
       
        /// <summary>
        /// 颜色类型
        /// </summary>
        public string ColorType { get; set; }

        public bool IsColorType { get; set; }

        public HTuple HueRangesMin
        { get; set; }
        public HTuple HueRangesMax
        { get; set; }
        public HTuple AreaMin
        { get; set; }
        public HTuple AreaMax
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
        public override  void recon()
        {
            this.hueRangesMins = new HTuple();
            this.hueRangesMaxs = new HTuple();

            this.hueRangesMins[0] = 0;
            this.hueRangesMins[1] = 10;
            this.hueRangesMins[2] = 30;
            this.hueRangesMins[3] = 65;
            this.hueRangesMins[4] = 125;

            this.hueRangesMaxs[0] = 10;
            this.hueRangesMaxs[1] = 30;
            this.hueRangesMaxs[2] = 65;
            this.hueRangesMaxs[3] = 125;
            this.hueRangesMaxs[4] = 162;
          
        
        }
        public override  void ini()
        {
            this.hueRangesMins[0] = 0;
            this.hueRangesMins[1] = 10;
            this.hueRangesMins[2] = 30;
            this.hueRangesMins[3] = 65;
            this.hueRangesMins[4] = 125;

            this.hueRangesMaxs[0] = 10;
            this.hueRangesMaxs[1] = 30;
            this.hueRangesMaxs[2] = 65;
            this.hueRangesMaxs[3] = 125;
            this.hueRangesMaxs[4] = 162;


            FixNames = "位置坐标0";
            IsFixture = false;
            ImageName = "采集图像0";
            Names = Tool.彩色转HSV图像.ToString();
            SetdrawShape = Roi.矩形.ToString(); ;//ROI形状
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
            IsColorType = false;//
            ColorType = colorType.Red.ToString();
            HueRangesMin = 0;
            HueRangesMax = 10;
            AreaMin = 1000;
            AreaMax = 99999;


        }
        public override  void draw_roi()
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
            HOperatorSet.GenEmptyObj(out ho_Img);
            ho_Img.Dispose();
            try
            {
                if (RegionAffineTrans != null)
                    RegionAffineTrans.Dispose();
                if (ho_ImageReduced != null)
                    ho_ImageReduced.Dispose();

                if (IsFixture)//位置定位
                {
                    HomMat2D = dicHomMat2D[FixNames];
                    gen_roi();
                    HOperatorSet.AffineTransRegion(ho_ROI_0, out RegionAffineTrans, HomMat2D[0], "nearest_neighbor");
                    if (IsRoi)
                    {
                        HOperatorSet.ReduceDomain(ho_Image[ImageName], RegionAffineTrans, out ho_ImageReduced);
                    }
                    else
                    {
                        ho_Img = ho_Image[ImageName];
                    }
                }
                else
                {
                    gen_roi();
                    if (IsRoi)
                    {
                        HOperatorSet.ReduceDomain(ho_Image[ImageName], ho_ROI_0, out ho_ImageReduced);
                        ho_Img = ho_ImageReduced;
                    }
                    else
                    {
                        ho_Img = ho_Image[ImageName];
                    }
                }
                if(IsColorType)
                {
                    colorTypes(ColorType);
                    color_classify(ho_Img, out ho_regionTrans, HueRangesMin, HueRangesMax, AreaMin, AreaMax, out hv_area, out hv_row, out hv_col);
                }
                else
                {
                    color_classify(ho_Img, out ho_regionTrans, HueRangesMin, HueRangesMax, AreaMin, AreaMax, out hv_area, out hv_row, out hv_col);
                }
                ResultLogic = true;//合格
                if (IsNums)//使用数量管控
                {
                    if (LowNums > hv_area.Length || hv_area.Length > HigNums)
                    {
                        ResultLogic = false;//不合格
                    }
                }

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
        public override  void dispresult()
        {
            try
            {
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
                if (ResultLogic)
                {
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.green.ToString());
                    HSystem.SetSystem("flush_graphic", "true");
                    HOperatorSet_Ex.set_display_font(hWindowControl1.HalconWindow, 12, "sans", "false", "false");//mono', 'sans', 'serif
                    for (int i = 0; i < hv_area.Length; i++)
                    {
                        HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, ColorType, "image", hv_row[i], hv_col[i], "white", "forest green");
                    }
                    if (!IsFixture)//位置定位
                        if (IsRoi)
                        {
                            HOperatorSet.DispObj(ho_ROI_0, hWindowControl1.HalconWindow);
                        }
                        else
                        {

                        }
                    else
                        HOperatorSet.DispObj(RegionAffineTrans, hWindowControl1.HalconWindow);

                    HSystem.SetSystem("flush_graphic", "false");
                }
                else
                {
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.red.ToString());
                    HSystem.SetSystem("flush_graphic", "true");
                    if (!IsFixture)//位置定位
                        if (IsRoi)
                        {
                            HOperatorSet.DispObj(ho_ROI_0, hWindowControl1.HalconWindow);
                        }
                        else
                        {

                        }
                    else
                        HOperatorSet.DispObj(RegionAffineTrans, hWindowControl1.HalconWindow);
                    HSystem.SetSystem("flush_graphic", "false");
                }
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "显示异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");

            }
        
        }
        public override  long set_after()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.DispObj((HObject)ho_Image[ImageName], hWindowControl1.HalconWindow);
                run();
                dispresult();
                watch.Stop();
                HSystem.SetSystem("flush_graphic", "false");
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
        public void color_classify(HObject ho_Image, out HObject ho_RegionTrans, HTuple hv_HueRanges1,
       HTuple hv_HueRanges2, HTuple hv_areaMin, HTuple hv_areamax, out HTuple hv_FuseArea,
       out HTuple hv_Row, out HTuple hv_Column)
        {
            // Local iconic variables 

            HObject ho_Red, ho_Green, ho_Blue, ho_Hue;
            HObject ho_Saturation, ho_Intensity, ho_Saturated, ho_HueSaturated;
            HObject ho_CurrentFuse, ho_CurrentFuseConn, ho_CurrentFuseFill, ho_CurrentFuseClosingCir;
             HObject ho_CurrentFuseSel;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_RegionTrans);
            HOperatorSet.GenEmptyObj(out ho_Red);
            HOperatorSet.GenEmptyObj(out ho_Green);
            HOperatorSet.GenEmptyObj(out ho_Blue);
            HOperatorSet.GenEmptyObj(out ho_Hue);
            HOperatorSet.GenEmptyObj(out ho_Saturation);
            HOperatorSet.GenEmptyObj(out ho_Intensity);
            HOperatorSet.GenEmptyObj(out ho_Saturated);
            HOperatorSet.GenEmptyObj(out ho_HueSaturated);
            HOperatorSet.GenEmptyObj(out ho_CurrentFuse);
            HOperatorSet.GenEmptyObj(out ho_CurrentFuseConn);
            HOperatorSet.GenEmptyObj(out ho_CurrentFuseFill);
            HOperatorSet.GenEmptyObj(out ho_CurrentFuseSel);
            HOperatorSet.GenEmptyObj(out ho_CurrentFuseClosingCir);
            ho_Red.Dispose(); ho_Green.Dispose(); ho_Blue.Dispose();
            HOperatorSet.Decompose3(ho_Image, out ho_Red, out ho_Green, out ho_Blue);
            ho_Hue.Dispose(); ho_Saturation.Dispose(); ho_Intensity.Dispose();
            HOperatorSet.TransFromRgb(ho_Red, ho_Green, ho_Blue, out ho_Hue, out ho_Saturation,
                out ho_Intensity, "hsv");
            ho_Saturated.Dispose();
            HOperatorSet.Threshold(ho_Saturation, out ho_Saturated, 60, 255);
            ho_HueSaturated.Dispose();
            HOperatorSet.ReduceDomain(ho_Hue, ho_Saturated, out ho_HueSaturated);
            //****
            //step: classify specific fuse
            //****
            ho_CurrentFuse.Dispose();
            HOperatorSet.Threshold(ho_HueSaturated, out ho_CurrentFuse, hv_HueRanges1, hv_HueRanges2);
            ho_CurrentFuseConn.Dispose();

            ho_CurrentFuseClosingCir.Dispose();
            HOperatorSet.ClosingCircle(ho_CurrentFuse, out ho_CurrentFuseClosingCir, 2);

            HOperatorSet.Connection(ho_CurrentFuseClosingCir, out ho_CurrentFuseConn);
            ho_CurrentFuseFill.Dispose();
            HOperatorSet.FillUp(ho_CurrentFuseConn, out ho_CurrentFuseFill);
      
            ho_CurrentFuseSel.Dispose();
            HOperatorSet.SelectShape(ho_CurrentFuseFill, out ho_CurrentFuseSel, "area", "and",
                hv_areaMin, hv_areamax);
            HOperatorSet.AreaCenter(ho_CurrentFuseSel, out hv_FuseArea, out hv_Row, out hv_Column);
            ho_RegionTrans.Dispose();
            HOperatorSet.ShapeTrans(ho_CurrentFuseSel, out ho_RegionTrans, "rectangle1");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "magenta");
            HOperatorSet.DispObj(ho_RegionTrans, hWindowControl1.HalconWindow);
            ho_Red.Dispose();
            ho_Green.Dispose();
            ho_Blue.Dispose();
            ho_Hue.Dispose();
            ho_Saturation.Dispose();
            ho_Intensity.Dispose();
            ho_Saturated.Dispose();
            ho_HueSaturated.Dispose();
            ho_CurrentFuse.Dispose();
            ho_CurrentFuseClosingCir.Dispose();
            ho_CurrentFuseConn.Dispose();
            ho_CurrentFuseFill.Dispose();
            ho_CurrentFuseSel.Dispose();
            return;
        }

     private void colorTypes(string ColorType)
     { 
      if( ColorType.Equals(colorType.Red.ToString()))
      {
          HueRangesMin = this.hueRangesMins[0];
          HueRangesMax= this.hueRangesMaxs[0];
      }
      if (ColorType.Equals(colorType.Orange.ToString()))
      {
          HueRangesMin = this.hueRangesMins[1];
          HueRangesMax = this.hueRangesMaxs[1];
      }
      if (ColorType.Equals(colorType.Yellow.ToString()))
      {
          HueRangesMin = this.hueRangesMins[2];
          HueRangesMax = this.hueRangesMaxs[2];
      }
      if (ColorType.Equals(colorType.Green.ToString()))
      {
          HueRangesMin = this.hueRangesMins[3];
          HueRangesMax = this.hueRangesMaxs[3];
      }
      if (ColorType.Equals(colorType.Blue.ToString()))
      {
          HueRangesMin = this.hueRangesMins[4];
          HueRangesMax = this.hueRangesMaxs[4];
      }
     
     }

    }
}
