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
      public  class FindRectangle2Tool:ImageTool
    {
        // Local iconic variables 
        [NonSerialized]
        HObject ho_ROI_0,ho_Arrow,  ho_Rectangle2Contour, ho_ruleContours;

        [NonSerialized]
        HTuple hv_edgesY, hv_edgesX, hv_resultRow, hv_resultColumn,hv_resultAngle,hv_resultLen1, hv_resultLen2;
        [NonSerialized]
        HTuple hv_Rows = new HTuple(), hv_Cols = new HTuple();

       [NonSerialized]
        HTuple AffineTran_row1, AffineTran_col1, AffineTran_angle1;

        // Local control variables 
        [NonSerialized]
        HTuple hv_Width = null, hv_Height = null;

        [NonSerialized]

        List<bool> resultLogic = new List<bool>();
        [NonSerialized]
        bool logic;

        [NonSerialized]
        List<HTuple> hv_phi = new List<HTuple>();
        public List<HTuple> Phi
        {
            get { return hv_phi; }
            set { hv_phi = value; }
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
        public HTuple ResultColumn
        {
            get { return hv_resultColumn; }
        }
        public HTuple ResultRow
        {
            get { return hv_resultRow; }
        }
        public HTuple ResultAngle
        {
            get { return hv_resultAngle; }
        }
        public HTuple ResultLen1
        {
            get { return hv_resultLen1; }
            set { hv_resultLen1 = value; }
        }
        public HTuple ResultLen2
        {
            get { return hv_resultLen2; }
            set { hv_resultLen2 = value; }
        }
        public HTuple Scale { get; set; }
        #endregion
        #region 输出结果判定
        public HTuple Lowlen1
        { get; set; }
        public HTuple Higlen1
        { get; set; }
        public bool IsLen1
        { get; set; }
        public HTuple Lowlen2
        { get; set; }
        public HTuple Higlen2
        { get; set; }
        public bool IsLen2
        { get; set; }
        public HTuple LowNums
        { get; set; }
        public HTuple HigNums
        { get; set; }
         public bool IsNums
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
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names
        { get; set; }
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
        /// <summary>
        /// 选择边缘
        /// </summary>
        public int Selcet { get; set; }
        /// <summary>
        /// 极性
        /// </summary>
        public int Transition { get; set; }
        /// <summary>
        /// 平滑值
        /// </summary>
        public HTuple Sigma { get; set; }
        /// <summary>
        /// 过渡阈值
        /// </summary>
        public HTuple Threshold { get; set; }
        public HTuple RuleWidth
        { get; set; }
        public HTuple RuleHeiht
        { get; set; }
        public HTuple RuleNums
        { get; set; }
        public bool IsRule { get; set; }
        public bool IsFitRectangle2 { get; set; }
    
             = true;
        public bool IsFitPoint { get; set; }

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
        /// 区域显示
        /// </summary>
        public bool IsSelectedRegions { get; set; }
        #endregion
        /// <summary>
        /// 工具名
        /// </summary>
        /// <returns></returns>
        public override string toolName()
        {
            return Names;
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
            hv_HomMat2D = new List<HTuple>();
            hv_phi = new List<HTuple>();
            resultLogic = new List<bool>();
        }

        /// <summary>
        /// 创建初始值
        /// </summary>
        public override void ini()
        {
            Names = Tool.找方向矩形测量.ToString();
            ImageName = "采集图像0";
            FixNames = Tool.位置定位.ToString();
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
            Setdraw = Set_draw.margin.ToString();//轮廓显示
            SetdrawShape = Roi.方向矩形.ToString(); ;//ROI形状
            Sigma = 1;
            Threshold = 30;
            Selcet = 3;
            Transition = 3;
            IsFixture = false;
            IsRule = true;
            IsFitRectangle2 = true;//方向矩形
            IsFitPoint = true;
            Scale = 1;
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
            try
            {
                if (ho_Arrow != null)//
                {
                    ho_Arrow.Dispose();
                }
                if (ho_Rectangle2Contour != null)//
                {
                    ho_Rectangle2Contour.Dispose();
                }
                if (ho_ruleContours != null)//
                {
                    ho_ruleContours.Dispose();
                }

                ResultLogic = true;
                if (IsFixture) //使用位置定位
                {
                    HomMat2D = dicHomMat2D[FixNames];
                    //仿射转换
                    Phi = dicPhi[FixNames]; //  选择位置定位
                    AffineTran_angle1 = Phi[0];
                    HOperatorSet.AffineTransPixel(HomMat2D[0], hv_rectangle2[0], hv_rectangle2[1], out AffineTran_row1, out AffineTran_col1);
                    try
                    {
                        HOperatorSet_Ex.find_rectangle2((HObject)ho_Image[ImageName], out ho_Arrow, out ho_Rectangle2Contour, out ho_ruleContours,
                                      AffineTran_row1,
                                      AffineTran_col1,
                                      AffineTran_angle1,
                                      hv_rectangle2[3],
                                      hv_rectangle2[4],
                                      RuleNums, RuleHeiht,
                                      RuleWidth, Sigma,
                                      Threshold, Polarity(),
                                      PointSelect(),
                                      out hv_resultRow,
                                      out hv_resultColumn,
                                      out hv_resultAngle,
                                      out hv_resultLen1,
                                      out hv_resultLen2,
                                      out hv_Rows,
                                      out hv_Cols);
                    }
                    catch
                    {
                        ResultLogic = false;//结果异常
                        return;
                    }
                }
                else
                {
                    try
                    {
                        HOperatorSet_Ex.find_rectangle2((HObject)ho_Image[ImageName], out ho_Arrow, out ho_Rectangle2Contour, out ho_ruleContours,
                                          hv_rectangle2[0],
                                          hv_rectangle2[1],
                                          hv_rectangle2[2],
                                          hv_rectangle2[3],
                                          hv_rectangle2[4],
                                          RuleNums, RuleHeiht,
                                          RuleWidth, Sigma,
                                          Threshold, Polarity(),
                                          PointSelect(),
                                          out hv_resultRow,
                                          out hv_resultColumn,
                                          out hv_resultAngle,
                                          out hv_resultLen1,
                                          out hv_resultLen2,
                                          out hv_Rows,
                                          out hv_Cols);
                    }
                    catch
                    {
                        ResultLogic = false;//结果异常
                        return;
                    }
                }
                hv_resultLen1 *= 2;
                hv_resultLen2 *= 2;
                ResultLen1 *= Scale;
                ResultLen2 *= Scale;
                if (IsLen1)//长度
                {
                  
                    if (ResultLen1 > Lowlen1 && ResultLen1 < Higlen1)//工差范围
                    {
                        ResultLogic = true;//结果
                    }
                    else
                    {
                        ResultLogic = false;//结果异常
                        return;
                    }
                }
                if (IsLen2)//宽度
                {
                 
                    if (ResultLen2 > Lowlen2 && ResultLen2 < Higlen2)//工差范围
                    {
                        ResultLogic = true;//结果
                    }
                    else
                    {
                        ResultLogic = false;//结果异常
                        return;
                    }
                }
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
                HTuple WinHandle1;
                HObject ho_cross = null, ho_centerCross = null;
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.set_display_font(hWindowControl1.HalconWindow, 12, "sans", "true", "false");//mono', 'sans', 'serif
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
                if (IsRule)//显示卡尺图形
                {
                    //HOperatorSet.OpenWindow(0, 0, 500, 500, hWindowControl1.HalconWindow, "visible", "", out WinHandle1);
                    HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 1);
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                    HOperatorSet.DispObj(ho_ruleContours, hWindowControl1.HalconWindow);
                    HOperatorSet.DispObj(ho_Arrow, hWindowControl1.HalconWindow);
                }
                if (IsFitPoint)//显示mark
                {
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "blue");
                    HOperatorSet.GenCrossContourXld(out ho_cross, hv_Rows, hv_Cols, RuleWidth / 2, new HTuple(45).TupleRad());
                    HOperatorSet.GenCrossContourXld(out ho_centerCross, hv_resultRow, hv_resultColumn, RuleWidth / 2, new HTuple(0).TupleRad());
                    HOperatorSet.DispObj(ho_cross, hWindowControl1.HalconWindow);
                    HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 2);
                    HOperatorSet.DispObj(ho_centerCross, hWindowControl1.HalconWindow);
                }
                if (IsFitRectangle2)//显示拟合矩形
                {
                    HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 1);
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "blue");
                    HOperatorSet.DispObj(ho_Rectangle2Contour, hWindowControl1.HalconWindow);
                }
                if (ResultLogic)
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "长度:" + ResultLen1.TupleString("0.03f")+"\n"+ "宽度:" + ResultLen2.TupleString("0.03f"), "image", hv_resultRow+20, hv_resultColumn, "white", "forest green");
                else
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "长度:" + ResultLen1.TupleString("0.03f") + "\n" + "宽度:" + ResultLen2.TupleString("0.03f"), "image", hv_resultRow + 20, hv_resultColumn, "white", "red");
                HSystem.SetSystem("flush_graphic", "false");
            }
            catch
            {
           
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
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
          
                ResultLogic = false;
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
                HSystem.SetSystem("flush_graphic", "false");
                timer = 0;
                return 0;
            }
        }
        public override bool toolResult()
        {
            return ResultLogic;
        }
        private string Polarity()
        {
            if (Transition == 3)
            { return "all"; }
            else if (Transition == 1)
            { return "positive"; }
            else if (Transition == 2)
            { return "negative"; }
            return "all";
        }
        private string PointSelect()
        {
            if (Selcet == 3)
            { return "all"; }
            else if (Selcet == 1)
            { return "first"; }
            else if (Selcet == 2)
            { return "last"; }
            return "all";
        }
    }
}
