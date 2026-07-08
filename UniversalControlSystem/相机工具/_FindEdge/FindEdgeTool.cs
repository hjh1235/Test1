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
    public class FindEdgeTool : ImageTool
    {
        [NonSerialized]
        HObject ho_ROI_0;
        [NonSerialized]
        HTuple hv_AffineTrans_Rows1 = new HTuple(), hv_AffineTrans_Cols1 = new HTuple();
        [NonSerialized]
        HTuple hv_AffineTrans_Rows2 = new HTuple(), hv_AffineTrans_Cols2 = new HTuple(), AffineTran_angle1;
        [NonSerialized]
        HTuple hv_line_ResultRow, hv_line_ResultCol;
        [NonSerialized]
        HObject ho_cross = null;
        [NonSerialized]
        HObject ho_rake, ho_Resultline;
        public HObject ResultLine
        {
            get { return ho_Resultline; }
            set { ho_Resultline = value; }
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
        #region  结果输出
        /// <summary>
        /// 输出结果
        /// </summary>
        public bool ResultLogic { get; set; }
        [NonSerialized]
        HTuple hv_rsultRow1, hv_hv_rsultCol1, hv_rsultRow2, hv_hv_rsultCol2;
        public HTuple ResultRow1
        {
            get { return hv_rsultRow1; }
            set { hv_rsultRow1 = value; }
        }
        public HTuple ResultCol1
        {
            get { return hv_hv_rsultCol1; }
            set { hv_hv_rsultCol1 = value; }
        }
        public HTuple ResultRow2
        {
            get { return hv_rsultRow2; }
            set { hv_rsultRow2 = value; }
        }
        public HTuple ResultCol2
        {
            get { return hv_hv_rsultCol2; }
            set { hv_hv_rsultCol2 = value; }
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
        ///ROI形状
        /// </summary>
        public string SetdrawShape { get; set; }

        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names { get; set; }
        public string FixNames { get; set; }
        /// <summary>
        /// 使用位置定位
        /// </summary>
        public bool IsFixture { get; set; }
        public bool IsRule { get; set; }
        public bool IsFitPoint { get; set; }
        public bool IsFitLine { get; set; }

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

        #region  找线参数
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
            Names = Tool.找边测量.ToString();
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
            SetdrawShape = Roi.方向矩形.ToString(); ;//ROI形状
            IsFitLine = true;
            IsFitPoint = true;
            IsRule = true;
            IsMeasure = true;
            IsFixture = false;
            Sigma = 1;
            Threshold = 30;
            Rulenums = 30;
            Ruleheiht = 100;
            Rulewidth = 30;
            Selcet = 3;
            Transition = 3;
            Hmeasure = 200;
            Lmeasure = 1;
        }
        public override void draw_roi()
        {
            SetdrawShape = Roi.方向矩形.ToString(); ;//ROI形状
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            draw_roi(hWindowControl1.HalconWindow, ho_Image, ImageName, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2, out hv_circle, out hv_rectangle1, out hv_rectangle2);
            Ruleheiht = hv_rectangle2[3];//卡尺高度
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
                ResultLogic = true;
                if (IsFixture) //使用位置定位
                {
                    HomMat2D = dicHomMat2D[FixNames];
                    Phi = dicPhi[FixNames]; //  选择位置定位
                    AffineTran_angle1 = Phi[0];
                    HOperatorSet.AffineTransPixel(HomMat2D[0], hv_rectangle2[0], hv_rectangle2[1], out hv_AffineTrans_Rows1, out hv_AffineTrans_Cols1);

                    HOperatorSet_Ex.rake_edge((HObject)ho_Image[ImageName], out ho_rake, hv_AffineTrans_Rows1, hv_AffineTrans_Cols1, hv_rectangle2[2]+ AffineTran_angle1, hv_rectangle2[3], hv_rectangle2[4],
                            Rulenums,
                            Ruleheiht,
                            Rulewidth,
                            Sigma,
                            Threshold,
                            Polarity(),
                            PointSelect(),
                            out hv_line_ResultRow, out hv_line_ResultCol);

                }
                else
                {
                    HOperatorSet_Ex.rake_edge((HObject)ho_Image[ImageName], out ho_rake, hv_rectangle2[0], hv_rectangle2[1], hv_rectangle2[2], hv_rectangle2[3], hv_rectangle2[4],
                           Rulenums,
                           Ruleheiht,
                           Rulewidth,
                           Sigma,
                           Threshold,
                           Polarity(),
                           PointSelect(),
                           out hv_line_ResultRow, out hv_line_ResultCol);
                }

                if (ho_Resultline != null)
                {
                    ho_Resultline.Dispose();
                }
                int num = 10;
                if (Rulenums > 10)
                    num = 10;
                else
                    num = Rulenums;
                HOperatorSet_Ex.pts_to_best_line(out ho_Resultline, hv_line_ResultRow, hv_line_ResultCol, num, out hv_rsultRow1, out hv_hv_rsultCol1, out hv_rsultRow2, out hv_hv_rsultCol2);
           
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
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
                if (IsRule)//显示卡尺图形
                {
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                    HOperatorSet.DispObj(ho_rake, hWindowControl1.HalconWindow);
                }
                if (IsFitPoint)//显示mark
                {
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "blue");
                    HOperatorSet.GenCrossContourXld(out ho_cross, hv_line_ResultRow, hv_line_ResultCol, Rulewidth / 3, 0);
                    HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 1);
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "blue");
                    HOperatorSet.DispObj(ho_cross, hWindowControl1.HalconWindow);
                    ho_cross.Dispose();


                }
                if (IsFitLine)//显示拟合线
                {

                    HObject ho_Contour = null;
                    HTuple hv_RowEx1, hv_ColEx1, hv_RowEx2, hv_ColEx2;
                    HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 1);
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "blue");
                    HOperatorSet.DispObj(ho_Resultline, hWindowControl1.HalconWindow);
                    HTuple width, height;
                    HOperatorSet.GetImageSize((HObject)ho_Image[ImageName], out width, out height);
                    HOperatorSet_Ex.lineLenEx(hv_rsultRow1, hv_hv_rsultCol1, hv_rsultRow2, hv_hv_rsultCol2, width, out hv_RowEx1, out hv_ColEx1, out hv_RowEx2, out hv_ColEx2);
                    HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_RowEx1.TupleConcat(hv_RowEx2),
                        hv_ColEx1.TupleConcat(hv_ColEx2));
                    HOperatorSet.SetLineStyle(hWindowControl1.HalconWindow, ((new HTuple(5)).TupleConcat(5)).TupleConcat(5));
                    HOperatorSet.DispObj(ho_Contour, hWindowControl1.HalconWindow);
                    HOperatorSet.SetLineStyle(hWindowControl1.HalconWindow, new HTuple());
                    ho_Contour.Dispose();
                }
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
