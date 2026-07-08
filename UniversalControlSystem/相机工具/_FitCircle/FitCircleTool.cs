using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using HOperatorSet_EX;
using System.Collections;
using System.Diagnostics;

namespace UniversalControlSystem
{
    [Serializable]
    public class FitCircleTool : ImageTool
    {
        [NonSerialized]
        HObject ho_ROI_0;
        [NonSerialized]
        HTuple hv_AffineTrans_Rows = new HTuple(), hv_AffineTrans_Cols = new HTuple();
        [NonSerialized]
        HTuple hv_circle_ResultRow, hv_circle_ResultCol, hv_spokeArcType;
        [NonSerialized]
        HObject ho_cross = null;
        [NonSerialized]
        HObject ho_spoke, ho_circle;
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
         Dictionary<string, List<HTuple>> dictPhi = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> DictPhi
        {
            get { return dictPhi; }
            set { dictPhi = value; }
        }
        #region  结果输出
        /// <summary>
        /// 输出结果
        /// </summary>
        public bool ResultLogic { get; set; }
        [NonSerialized]
        HTuple hv_RowCenter, hv_ColCenter, hv_Radius;
        [NonSerialized]
        HTuple hv_StartPhi, hv_EndPhi, hv_PointOrder, hv_ArcAngle;
        public HTuple ResultRowCenter
        {
            get { return hv_RowCenter; }
            set { hv_RowCenter = value; }
        }
        public HTuple ResultColCenter
        {
            get { return hv_ColCenter; }
            set { hv_ColCenter = value; }
        }
        public HTuple ResultRadius
        {
            get { return hv_Radius; }
            set { hv_Radius = value; }
        }
         /// <summary>
        /// 
        /// </summary>
        public HTuple ResultDiameter
        {
            get { return hv_Radius*2; }
            set { hv_Radius = value; }
        }

        #endregion
        #region 结果输出判定
        public bool IsMeasure { get; set; }
        public HTuple Hmeasure
        { get; set; }
        public HTuple Lmeasure
        { get; set; }

        #endregion
        #region 参数
        //ho_ROI_0 产生4个以上点ROI参数
        HTuple hv_Rows = new HTuple(), hv_Cols = new HTuple(), hv_Direct = new HTuple();

        public HTuple Direct
        {
            get { return hv_Direct; }
            set { hv_Direct = value; }
        }
        public HTuple Cols
        {
            get { return hv_Cols; }
            set { hv_Cols = value; }
        }

        public HTuple Rows
        {
            get { return hv_Rows; }
            set { hv_Rows = value; }
        }
        /// <summary>
        /// 图像名称
        /// </summary>
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
        public bool IsRule { get; set; }
        public bool IsFitPoint { get; set; }
        public bool IsFitCircle { get; set; }
        public HTuple Scale { get; set; }

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

        #region  找圆参数
        public HTuple Rulewidth
        { get; set; }
        public HTuple Ruleheiht
        { get; set; }
        public HTuple Rulenums
        { get; set; }
        public int Selcet
        { get; set; }
        public int Transition
        { get; set; }
        public HTuple Sigma
        { get; set; }
        public HTuple Threshold
        { get; set; }
        #endregion
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
            Names = Tool.找圆测量.ToString();
            ImageName = "采集图像0";
            FixNames = Tool.位置定位.ToString();
            IsFitCircle = true;
            IsFitPoint = true;
            IsRule = true;
            IsMeasure = true;
            Sigma = 1;
            Threshold = 30;
            Rulenums = 30;
            Ruleheiht = 100;
            Rulewidth = 30;
            Selcet = 3;
            Transition = 3;
            Hmeasure = 200;
            Lmeasure = 1;
            Scale = 1.000;
        }
        public override void draw_roi()
        {

            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
            HOperatorSet.GenEmptyObj(out ho_ROI_0);
            ho_ROI_0.Dispose();
            HOperatorSet_Ex.draw_spoke((HObject)ho_Image[ImageName], out  ho_ROI_0, hWindowControl1.HalconWindow,
                        Rulenums,
                        Ruleheiht,
                        Rulewidth,
                    out hv_Rows, out hv_Cols,
                    out hv_Direct);
            HOperatorSet.DispObj(ho_ROI_0, hWindowControl1.HalconWindow);
            HSystem.SetSystem("flush_graphic", "false");
            set_after();
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
                ResultLogic = true;
                if (IsFixture) //使用位置定位
                {
                    HomMat2D = dicHomMat2D[FixNames];
                    //仿射转换
                    HOperatorSet.AffineTransPixel(HomMat2D[0], hv_Rows, hv_Cols, out hv_AffineTrans_Rows, out hv_AffineTrans_Cols);
                    HOperatorSet_Ex.spoke(hWindowControl1.HalconWindow, ho_Image[ImageName], out ho_spoke,
                            Rulenums,
                            Ruleheiht,
                            Rulewidth,
                            Sigma,
                            Threshold,
                            Polarity(),
                            PointSelect(),
                            hv_AffineTrans_Rows, hv_AffineTrans_Cols, hv_Direct, out hv_circle_ResultRow, out hv_circle_ResultCol, out hv_spokeArcType);
                }
                else
                {
                    HOperatorSet_Ex.spoke(hWindowControl1.HalconWindow, (HObject)ho_Image[ImageName], out ho_spoke,
                          Rulenums,
                          Ruleheiht,
                          Rulewidth,
                          Sigma,
                          Threshold,
                          Polarity(),
                          PointSelect(),
                          hv_Rows, hv_Cols, hv_Direct, out hv_circle_ResultRow, out hv_circle_ResultCol, out hv_spokeArcType);
                }

                if (ho_circle != null)
                {
                    ho_circle.Dispose();
                }
                int num = 10;
                if (Rulenums > 10)
                    num = 10;
                else
                    num = Rulenums;
                HOperatorSet_Ex.pts_to_best_circle(out ho_circle, hv_circle_ResultRow, hv_circle_ResultCol, num, hv_spokeArcType, out hv_RowCenter, out hv_ColCenter, out hv_Radius, out  hv_StartPhi, out  hv_EndPhi, out hv_PointOrder,
                out  hv_ArcAngle);

                ResultDiameter *= Scale;
                if (IsMeasure)
                {
                    if (ResultDiameter > Lmeasure && ResultDiameter < Hmeasure)//工差范围
                    {
                        ResultLogic = true;//结果
                    }
                    else
                    {
                        ResultLogic = false;//结果异常
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
        public override void dispresult()
        {
            try
            {
                HObject ho_cross = null, ho_centerCross = null;
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.set_display_font(hWindowControl1.HalconWindow, 12, "sans", "false", "false");//mono', 'sans', 'serif
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
                if (IsRule)//显示卡尺图形
                {
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                    HOperatorSet.DispObj(ho_spoke, hWindowControl1.HalconWindow);
                }
                if (IsFitPoint)//显示mark
                {
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "blue");
                    //ho_cross.Dispose();
                    //ho_centerCross.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_cross, hv_circle_ResultRow, hv_circle_ResultCol, Rulewidth / 3, 0);
                    HOperatorSet.GenCrossContourXld(out ho_centerCross, hv_RowCenter, hv_ColCenter, Rulewidth / 3, 0);
                    HOperatorSet.DispObj(ho_cross, hWindowControl1.HalconWindow);
                    HOperatorSet.DispObj(ho_centerCross, hWindowControl1.HalconWindow);
                    ho_centerCross.Dispose();
                    ho_cross.Dispose();
                }
                if (IsFitCircle)//显示拟合圆
                {
                    HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 1);
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "blue");
                    HOperatorSet.DispObj(ho_circle, hWindowControl1.HalconWindow);
                }

                if (ResultLogic)
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "直径:" + ResultDiameter.TupleString("0.03f"), "image", hv_RowCenter + 50, hv_ColCenter, "white", "forest green");
                else
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "直径:" + ResultDiameter.TupleString("0.03f"), "image", hv_RowCenter + 50, hv_ColCenter, "white", "red");
                HSystem.SetSystem("flush_graphic", "false");
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
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
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "找圆工具运行异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
                timer =0;
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
