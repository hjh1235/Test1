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
    public class _2DSymbolTool : ImageTool
    {
        [NonSerialized]
        HTuple hv_DataCodeHandle, hv_Width, hv_Height;
        [NonSerialized]
        HObject symbolXLDs;
        [NonSerialized]
        HObject ImageScaled, ImageGray;
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
         Dictionary<string, List<HTuple>> htHomMat2D = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> DicHomMat2D
        {
            get { return htHomMat2D; }
            set { htHomMat2D = value; }
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
        HTuple hv_ResultHandles, hv_decodedDataStrings, hv_resultQuality;
        /// <summary>
        /// 二维码信息
        /// </summary>
        public HTuple ResultDecodedData
        {
            get { return hv_decodedDataStrings; }
            set { hv_decodedDataStrings = value; }
        }
        public HTuple ResultHandles
        {
            get { return hv_ResultHandles; }
            set { hv_ResultHandles = value; }
        }
        /// <summary>
        /// 二维码质量
        /// </summary>
        public HTuple ResultQuality
        {
            get{ return hv_resultQuality;}
            set{hv_resultQuality = value;}
        }

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
        public  Dictionary<string, HObject> Image
        {
            get { return ho_Image; }
            set { ho_Image = value; }
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
        string setdrawShape;//ROI形状
        /// <summary>
        ///ROI形状
        /// </summary>
        public string SetdrawShape
        {
            get { return setdrawShape; }
            set { setdrawShape = value; }
        }
        /// <summary>
        ///  识别数量
        /// </summary>
        public int ResultMaxNum { get; set; }
        /// <summary>
        /// 超时
        /// </summary>
        public HTuple TimerOut { get; set; }
        /// <summary>
        /// 二维码类型
        /// </summary>
        public string SymbolType { get; set; }
        /// <summary>
        /// 灰度形态学处理类型
        /// </summary>
        public string GrayType { get; set; }
        public HTuple MaskWidth
        { get; set; }
        public HTuple MaskHeight
        { get; set; }
        public HTuple MaskShape
        { get; set; }
        /// <summary>
        /// 灰度形态
        /// </summary>
        public bool IsGrayShape
        { get; set; }
        /// <summary>
        /// 收缩图像
        /// </summary>
        public bool IsScale
        { get; set; }
        public bool IsAutoGrayShape
        { get; set; }

       

     

        #endregion
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
            FixNames = "位置坐标0";
            IsFixture = false;
            ImageName = "采集图像0";
            Names = Tool.二维码识别.ToString();
            setdrawShape = Roi.矩形.ToString(); ;//ROI形状
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

            TimerOut = 100;
            SymbolType = "Data Matrix ECC 200";
            ResultMaxNum = 1;

            MaskWidth = 1;
            MaskHeight = 1;
            GrayType = "gray_dilation_shape(灰度掩膜膨胀)";
            MaskShape = "rectangle";
            IsGrayShape = false;
            IsScale = false;
            IsAutoGrayShape = false;

            LowNums = 1;
            HigNums = 9;
            IsNums = false;



        }
        public override void draw_roi()
        {
            HOperatorSet.SetColor(HW.Instance().HalconWindow, "green");
            draw_roi(HW.Instance().HalconWindow, ho_Image, ImageName, setdrawShape, hv_circle, hv_rectangle1, hv_rectangle2, out hv_circle, out hv_rectangle1, out hv_rectangle2);
            set_after();
        }
        void gen_roi()
        {
            if (ho_ROI_0 != null)
            {
                ho_ROI_0.Dispose();
            }
            gen_roi(out ho_ROI_0, setdrawShape, hv_circle, hv_rectangle1, hv_rectangle2);
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
            int connt=0;
            hv_decodedDataStrings = null;
            HTuple hv_rayMin, hv_rayMax, hv_rayRange;
            string[] Mode = new string[] { "gray_dilation_shape(灰度掩膜膨胀)",
                                                       "gray_erosion_shape(灰度掩膜腐蚀)",
                                                       "gray_closing_shape(灰度掩膜闭运算)",
                                                       "gray_opeing_shape(灰度掩膜开运算)" };
            while (true)
            {
                try
                {
                    if (RegionAffineTrans != null)
                        RegionAffineTrans.Dispose();
                    if (ho_ImageReduced != null)
                        ho_ImageReduced.Dispose();
                    if (ImageScaled != null)
                        ImageScaled.Dispose();
                    if (ImageGray != null)
                    {
                        ImageGray.Dispose();
                    }
                    if (IsFixture)//位置定位
                    {
                        HomMat2D = (List<HTuple>)htHomMat2D[FixNames];
                        gen_roi();
                        HOperatorSet.AffineTransRegion(ho_ROI_0, out RegionAffineTrans, HomMat2D[0], "nearest_neighbor");

                        HOperatorSet.ReduceDomain((HObject)ho_Image[ImageName], RegionAffineTrans, out ho_ImageReduced);
                    }
                    else
                    {
                        gen_roi();
                        HOperatorSet.ReduceDomain((HObject)ho_Image[ImageName], ho_ROI_0, out ho_ImageReduced);
                    }
                    //Encoding.UTF8.GetString(Encoding.Default.GetBytes("a")); 
                    HSystem.SetSystem("filename_encoding", "utf8");
                    HOperatorSet.GetImageSize((HObject)ho_Image[ImageName], out hv_Width, out hv_Height);
                    if (IsGrayShape)
                    {
                        //gray_dilation_shape(灰度掩膜膨胀)
                        //gray_erosion_shape(灰度掩膜腐蚀)
                        //gray_closing_shape(灰度掩膜闭运算)
                        //gray_opeing_shape(灰度掩膜开运算)
                      
                        if (IsScale)
                        {
                            HOperatorSet.MinMaxGray((HObject)ho_Image[ImageName], (HObject)ho_Image[ImageName], 5, out hv_rayMin, out hv_rayMax, out hv_rayRange);
                            HOperatorSet_Ex.scale_image_range(ho_ImageReduced, out ImageScaled, hv_rayMin, hv_rayMax);
                        }
                        else
                            HOperatorSet_Ex.scale_image_range(ho_ImageReduced, out ImageScaled, 0, 255);
                        if (GrayType == "gray_dilation_shape(灰度掩膜膨胀)")
                            HOperatorSet.GrayOpeningShape(ImageScaled, out ImageGray, MaskHeight, MaskWidth, MaskShape);
                        if (GrayType == "gray_erosion_shape(灰度掩膜腐蚀)")
                            HOperatorSet.GrayErosionShape(ImageScaled, out ImageGray, MaskHeight, MaskWidth, MaskShape);
                        if (GrayType == "gray_closing_shape(灰度掩膜闭运算)")
                            HOperatorSet.GrayClosingShape(ImageScaled, out ImageGray, MaskHeight, MaskWidth, MaskShape);
                        if (GrayType == "gray_opeing_shape(灰度掩膜开运算)")
                            HOperatorSet.GrayOpeningShape(ImageScaled, out ImageGray, MaskHeight, MaskWidth, MaskShape);
                    }
                    HOperatorSet.CreateDataCode2dModel(SymbolType, "default_parameters", "maximum_recognition", out hv_DataCodeHandle);
                    HOperatorSet.SetDataCode2dParam(hv_DataCodeHandle, "timeout", TimerOut);
                    HOperatorSet.SetColor(HW.Instance().HalconWindow, "green");
                    HOperatorSet.SetLineWidth(HW.Instance().HalconWindow, 2);
                    HOperatorSet.SetDraw(HW.Instance().HalconWindow, "margin");
                    if (symbolXLDs != null)
                        symbolXLDs.Dispose();
                    //HOperatorSet.FindDataCode2d(ho_ImageReduced, out symbolXLDs, hv_DataCodeHandle, new HTuple(),
                    //             new HTuple(), out hv_ResultHandles, out hv_decodedDataStrings);
                    if (!IsGrayShape)
                        HOperatorSet.FindDataCode2d(ho_ImageReduced, out symbolXLDs, hv_DataCodeHandle, "stop_after_result_num",
                                     ResultMaxNum, out hv_ResultHandles, out hv_decodedDataStrings);
                    else
                        HOperatorSet.FindDataCode2d(ImageGray, out symbolXLDs, hv_DataCodeHandle, "stop_after_result_num",
                                ResultMaxNum, out hv_ResultHandles, out hv_decodedDataStrings);
                    if (hv_ResultHandles.Length>0)
                        HOperatorSet.GetDataCode2dResults(hv_DataCodeHandle, hv_ResultHandles, "quality_isoiec15415", out hv_resultQuality);
                    ResultLogic = true;//合格
                    if (IsNums)//使用数量管控
                    {
                        if (LowNums > hv_decodedDataStrings.Length || hv_decodedDataStrings.Length > HigNums)
                        {
                            ResultLogic = false;//不合格
                        }
                    }
                    if (connt < 1)
                    {
                        if (IsAutoGrayShape == false)//
                            break;// 退出
                    }

                    if (hv_decodedDataStrings.Length < 1 && connt < Mode.Length)
                    {
                        GrayType= Mode[connt];
                        connt++;
                        continue;
                    }
                    break;
                }
                catch (HalconException ex)
                {
                    HTuple hv_Exception;
                    ex.ToHTuple(out hv_Exception);
                    HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "{" + hv_Exception + "}", CoordSystem.window.ToString(), 10, 10, "red", "false");
                    ResultLogic = false;//结果异常
                    HSystem.SetSystem("flush_graphic", "false");
                    break;
                }
               
            }
        }
        public override void dispresult()
        {
            try
            {
                HTuple hv_area, hv_row, column, pointOrder;
                HOperatorSet.SetDraw(HW.Instance().HalconWindow, Set_draw.margin.ToString());
                if (ResultLogic)
                {
                    HOperatorSet.SetColor(HW.Instance().HalconWindow, ColorFul.green.ToString());
                    HSystem.SetSystem("flush_graphic", "true");
                    HOperatorSet_Ex.set_display_font(HW.Instance().HalconWindow, 12, "sans", "false", "false");//mono', 'sans', 'serif
                    HOperatorSet.DispObj(symbolXLDs, HW.Instance().HalconWindow);
                    HOperatorSet.DispObj(ho_ROI_0, HW.Instance().HalconWindow);
                    HOperatorSet.AreaCenterXld(symbolXLDs, out hv_area, out hv_row, out column, out pointOrder);
                    for (int i = 0; i < hv_area.Length; i++)
                    {
                        HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, hv_decodedDataStrings[i]+"\n"+ "Quality:" + hv_resultQuality[10], "image", hv_row[i], column[i], "white", "forest green");
                    }

                    HSystem.SetSystem("flush_graphic", "false");
                }
                else
                {
                    HOperatorSet.SetColor(HW.Instance().HalconWindow, ColorFul.red.ToString());
                    HSystem.SetSystem("flush_graphic", "true");
                    HOperatorSet.DispObj(ho_ROI_0, HW.Instance().HalconWindow);
                    HSystem.SetSystem("flush_graphic", "false");
                }
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
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
                HOperatorSet.ClearWindow(HW.Instance().HalconWindow);
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.DispObj((HObject)ho_Image[ImageName], HW.Instance().HalconWindow);
                run();
                if (IsGrayShape)
                {
                    if (ImageGray != null)
                        HOperatorSet.DispObj(ImageGray, HW.Instance().HalconWindow);
                }
                dispresult();
                watch.Stop();
                HSystem.SetSystem("flush_graphic", "false");
                timer = watch.ElapsedMilliseconds;
                return watch.ElapsedMilliseconds;
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
                return 0;
            }
        }
        public override bool toolResult()
        {
            return ResultLogic;
        }
    }
}
