using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using System.Diagnostics;
using HOperatorSet_EX;

namespace UniversalControlSystem
{
    [Serializable]
    public class IntersectionLinesTool : ImageTool
    {

        [NonSerialized]
        HTuple hv_rowA1;
        [NonSerialized]
        HTuple hv_colA1;
        [NonSerialized]
        HTuple hv_rowA2;
        [NonSerialized]
        HTuple hv_colA2;
        [NonSerialized]
        HTuple hv_rowB1;
        [NonSerialized]
        HTuple hv_colB1;
        [NonSerialized]
        HTuple hv_rowB2;
        [NonSerialized]
        HTuple hv_colB2;
  
        #region 结果输出
        [NonSerialized]
        private HTuple hv_row, hv_col, hv_isOverlapping;

        public HTuple Row
        {
            get { return hv_row; }
            set { hv_row = value; }
        }


        public HTuple Col
        {
            get { return hv_col; }
            set { hv_col = value; }
        }

     
        public bool ResultLogic { get; set; }
        #endregion
        #region 输出结果判定
        public bool IsMeasure { get; set; }
        public HTuple Hmeasure
        { get; set; }
        public HTuple Lmeasure
        { get; set; }
        #endregion
        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names
        { get; set; }
        public string LineName1
        { get; set; }
        public string LineName2
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

         Dictionary<string, HTuple> htRowLine1 = new  Dictionary<string, HTuple>();

        public  Dictionary<string, HTuple> HtRowLine1
        {
            get { return htRowLine1; }
            set { htRowLine1 = value; }
        }
         Dictionary<string, HTuple> htColLine1 = new  Dictionary<string, HTuple>();

        public  Dictionary<string, HTuple> HtColLine1
        {
            get { return htColLine1; }
            set { htColLine1 = value; }
        }
         Dictionary<string, HTuple> htRowLine2 = new  Dictionary<string, HTuple>();

        public  Dictionary<string, HTuple> HtRowLine2
        {
            get { return htRowLine2; }
            set { htRowLine2 = value; }
        }
         Dictionary<string, HTuple> htColLine2 = new  Dictionary<string, HTuple>();

        public  Dictionary<string, HTuple> HtColLine2
        {
            get { return htColLine2; }
            set { htColLine2 = value; }
        }

        public override string toolName()
        {
            return Names;
        }
        public override long toolTimer()
        {
            return timer;
        }
        public override void ini()
        {
            Names = Tool.两线交点测量.ToString();
            ImageName = "采集图像0";
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
                ResultLogic = true;//结果
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                SelectPointLine(LineName1, LineName2);
                HSystem.SetSystem("flush_graphic", "false");
            
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
            HObject ho_cross = null;
            try
            {
                HOperatorSet_Ex.set_display_font(hWindowControl1.HalconWindow, 12, "mono", "false", "false");
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
             if (ResultLogic)
                {

                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "两线交点" + "\n" + "Row:" + hv_row.TupleString("0.03f") + "\n" + "Col:" + hv_col.TupleString("0.03f"), "image", hv_row + 50, hv_col, "white", "forest green");
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                    HOperatorSet.GenCrossContourXld(out ho_cross, hv_row, hv_col, 50, 0);
                    HOperatorSet.DispObj(ho_cross, hWindowControl1.HalconWindow);
                    ho_cross.Dispose();
                }
                else
                {
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "两线交点" + "\n" + "Row:" + hv_row.TupleString("0.03f") + "\n" + "Col:" + hv_col.TupleString("0.03f"), "image", hv_row + 50, hv_col, "white", "forest green");
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                    HOperatorSet.GenCrossContourXld(out ho_cross, hv_row, hv_col, 50, 0);
                    HOperatorSet.DispObj(ho_cross, hWindowControl1.HalconWindow);
                    ho_cross.Dispose();
                }
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
        public void SelectPointLine(string line1, string line2)
        {
          

            hv_rowA1 = (HTuple)htRowLine1[line1];
            hv_colA1 = (HTuple)htColLine1[line1];
            hv_rowA2 = (HTuple)htRowLine2[line1];
            hv_colA2 = (HTuple)htColLine2[line1];

            hv_rowB1 = (HTuple)htRowLine1[line2];
            hv_colB1 = (HTuple)htColLine1[line2];
            hv_rowB2 = (HTuple)htRowLine2[line2];
            hv_colB2 = (HTuple)htColLine2[line2];
            HOperatorSet.IntersectionLines(hv_rowA1, hv_colA1, hv_rowA2, hv_colA2, hv_rowB1, hv_colB1, hv_rowB2, hv_colB2,out hv_row,out hv_col,out  hv_isOverlapping);
            HOperatorSet_Ex.set_display_font(hWindowControl1.HalconWindow, 16, "mono", "true", "false");
            //HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, distance, "image", hv_cenrow, hv_cencol, "green", "false");
            HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 1);
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
            HOperatorSet.DispLine(hWindowControl1.HalconWindow, hv_rowA1, hv_colA1, hv_rowA2, hv_colA2);
            HOperatorSet.DispLine(hWindowControl1.HalconWindow, hv_rowB1, hv_colB1, hv_rowB2, hv_colB2);
        }
        void get_cenline_point(HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Row2,
     HTuple hv_Column2, out HTuple hv_Angle, out HTuple hv_cenrow, out HTuple hv_cencol)
        {
            // Local iconic variables 
            // Local control variables 
            HTuple hv_Distance = null;
            // Initialize local and output iconic variables 
            HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Angle);
            HOperatorSet.DistancePp(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Distance);
            hv_cenrow = (((hv_Angle.TupleSin()) * hv_Distance) / 2) - hv_Row1;
            HOperatorSet.TupleAbs(hv_cenrow, out hv_cenrow);
            hv_cencol = (((hv_Angle.TupleCos()) * hv_Distance) / 2) + hv_Column1;
            return;
        }

        void gen_distance_pl_point(HTuple hv_Rpoint, HTuple hv_Cpoint, HTuple hv_Row1,
            HTuple hv_Column1, HTuple hv_Row2, HTuple hv_Column2, out HTuple hv_RowMin,
            out HTuple hv_ColMin, out HTuple hv_DistanceMin)
        {
            // Local iconic variables 
            HObject ho_Arrow, ho_Cross, ho_Cross1;
            // Local control variables 
            HTuple hv_Angle = null, hv_DistanceMax = null;
            HTuple hv_Deg = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_Cross1);
            HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Angle);
            HOperatorSet.DistancePs(hv_Rpoint, hv_Cpoint, hv_Row1, hv_Column1, hv_Row2, hv_Column2,
                out hv_DistanceMin, out hv_DistanceMax);
            HOperatorSet.TupleDeg(hv_Angle, out hv_Deg);
            hv_RowMin = ((((hv_Angle + ((new HTuple(90)).TupleRad()))).TupleSin()) * hv_DistanceMin) + hv_Rpoint;
            hv_ColMin = ((((hv_Angle + ((new HTuple(90)).TupleRad()))).TupleCos()) * hv_DistanceMin) - hv_Cpoint;
            HOperatorSet.TupleAbs(hv_ColMin, out hv_ColMin);
            ho_Arrow.Dispose();
            HOperatorSet_Ex.gen_arrow_contour_xld(out ho_Arrow, hv_Rpoint, hv_Cpoint, hv_RowMin, hv_ColMin,
                10, 10);
            ho_Cross.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Rpoint, hv_Cpoint, 6, 0);
            ho_Cross1.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_Cross1, hv_RowMin, hv_ColMin, 6, 0);
            HOperatorSet.DispObj(ho_Cross, hWindowControl1.HalconWindow);
            HOperatorSet.DispObj(ho_Cross1, hWindowControl1.HalconWindow);
            HOperatorSet.DispObj(ho_Arrow, hWindowControl1.HalconWindow);
            ho_Arrow.Dispose();
            ho_Cross.Dispose();
            ho_Cross1.Dispose();
            return;
        }

    }
}
