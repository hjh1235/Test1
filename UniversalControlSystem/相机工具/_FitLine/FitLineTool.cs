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
    public class FitLineTool : ImageTool
    {
        [NonSerialized]
        HObject ho_ROI_0;
        [NonSerialized]
        HTuple hv_AffineTrans_Rows1 = new HTuple(), hv_AffineTrans_Cols1 = new HTuple();
        [NonSerialized]
        HTuple hv_AffineTrans_Rows2 = new HTuple(), hv_AffineTrans_Cols2 = new HTuple();
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
        //ho_ROI_0 ROI参数
        HTuple hv_Row1 = new HTuple(), hv_Col1 = new HTuple(), hv_Row2 = new HTuple(), hv_Col2 = new HTuple();

        public HTuple Row1
        {
            get { return hv_Row1; }
            set { hv_Row1 = value; }
        }

        public HTuple Col1
        {
            get { return hv_Col1; }
            set { hv_Col1 = value; }
        }

        public HTuple Row2
        {
            get { return hv_Row2; }
            set { hv_Row2 = value; }
        }

        public HTuple Col2
        {
            get { return hv_Col2; }
            set { hv_Col2 = value; }
        }


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
            Names = Tool.找线测量.ToString();
            ImageName = "采集图像0";
            FixNames = Tool.位置定位.ToString();
            IsFitLine = true;
            IsFitPoint = true;
            IsRule = true;
            IsMeasure = true;
            IsFixture =false;
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

            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
            HOperatorSet.GenEmptyObj(out ho_ROI_0);
            ho_ROI_0.Dispose();
            HOperatorSet_Ex.draw_rake(out  ho_ROI_0, hWindowControl1.HalconWindow,
                        Rulenums,
                        Ruleheiht,
                        Rulewidth, out hv_Row1, out hv_Col1, out hv_Row2, out hv_Col2);
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
                    HomMat2D = (List<HTuple>)dicHomMat2D[FixNames];
                   //仿射转换
                    HOperatorSet.AffineTransPixel(HomMat2D[0], hv_Row1, hv_Col1, out hv_AffineTrans_Rows1, out hv_AffineTrans_Cols1);
                    HOperatorSet.AffineTransPixel(HomMat2D[0], hv_Row2, hv_Col2, out hv_AffineTrans_Rows2, out hv_AffineTrans_Cols2);
                    HOperatorSet_Ex.rake((HObject)ho_Image[ImageName],
                        out ho_rake,
                            Rulenums,
                            Ruleheiht,
                            Rulewidth,
                            Sigma,
                            Threshold,
                            Polarity(),
                            PointSelect(),
                            hv_AffineTrans_Rows1, hv_AffineTrans_Cols1,
                            hv_AffineTrans_Rows2, hv_AffineTrans_Cols2,
                            out hv_line_ResultRow, out hv_line_ResultCol);
                }
                else
                {
                    try
                    {
                        HOperatorSet_Ex.rake((HObject)ho_Image[ImageName],
                      out ho_rake,
                          Rulenums,
                          Ruleheiht,
                          Rulewidth,
                          Sigma,
                          Threshold,
                          Polarity(),
                          PointSelect(),
                          hv_Row1, hv_Col1,
                          hv_Row2, hv_Col2,
                          out hv_line_ResultRow, out hv_line_ResultCol);
                    }
                    catch
                    {
                        ResultLogic = false;//结果异常
                        return;
                    }

                }

                if (ho_Resultline != null)
                {
                    ho_Resultline.Dispose();
                }
                int num=10 ;
                if (Rulenums > 10)
                    num = 10;
                else
                    num = Rulenums;
                HOperatorSet_Ex.pts_to_best_line(out ho_Resultline, hv_line_ResultRow, hv_line_ResultCol, num, out hv_rsultRow1, out hv_hv_rsultCol1, out hv_rsultRow2, out hv_hv_rsultCol2);
                //if (hv_Radius > Lmeasure && hv_Radius < Hmeasure)//工差范围
                //{
                //    ResultLogic = true;//结果
                //}
                //else
                //{
                //    ResultLogic = false;//结果异常
                //}
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
