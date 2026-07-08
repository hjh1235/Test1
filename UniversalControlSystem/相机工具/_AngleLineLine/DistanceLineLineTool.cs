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
    public  class DistanceLineLineTool:ImageTool
    {   [NonSerialized]
        
        #region 结果输出
        HTuple hv_distanceMin, hv_distanceMax;
        public HTuple Distance
        {
            get { return hv_distanceMin; }
            set { hv_distanceMin = value; }
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
        public string LineName2
        { get; set; }
        public string LineName1
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

         Dictionary<string, HObject> htLine1 = new  Dictionary<string, HObject>();
        public  Dictionary<string, HObject> HtLine1
        {
            get { return htLine1; }
            set { htLine1 = value; }
        }
        /// <summary>
        /// 比例
        /// </summary>
        public HTuple Scale { get; set; }
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
            Names = Tool.两线间距测量.ToString();
            ImageName = "采集图像0";
            IsMeasure = true;
            Hmeasure = 200;
            Lmeasure = 1;
            Scale = 1.000;

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
                if (IsMeasure)
                {
                    if (Distance > Lmeasure && Distance < Hmeasure)//工差范围
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
                HTuple hv_Row1, hv_Col1, hv_Row2, hv_Col2; ;
                HTuple hv_RowProj1, hv_ColProj1, hv_RowProj2, hv_ColProj2;
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.set_display_font(hWindowControl1.HalconWindow, 12, "sans", "false", "false");//mono', 'sans', 'serif
                HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
                HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 1);
                disp_mesuer_ll((HObject)ho_Image[ImageName], (HObject)htLine1[LineName1], (HObject)htLine1[LineName2], out  hv_Row1, out hv_Col1, out  hv_Row2, out hv_Col2, out hv_RowProj1, out hv_ColProj1, out hv_RowProj2, out hv_ColProj2);
                if (ResultLogic)
                {
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "两线间距:" + Distance.TupleString("0.03f"), "image", hv_Row1.TupleSelect(0) + 50, hv_Col1.TupleSelect(0), "white", "forest green");
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                    HOperatorSet.DispObj((HObject)htLine1[LineName1], hWindowControl1.HalconWindow);
                    HOperatorSet.DispObj((HObject)htLine1[LineName2], hWindowControl1.HalconWindow);
                }
                else
                {
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "两线间距:" + Distance.TupleString("0.03f"), "image", hv_Row1.TupleSelect(0) + 50, hv_Col1.TupleSelect(0), "white", "red");
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "red");
                    HOperatorSet.DispObj((HObject)htLine1[LineName1], hWindowControl1.HalconWindow);
                    HOperatorSet.DispObj((HObject)htLine1[LineName2], hWindowControl1.HalconWindow);
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
                 HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "两线工具运行异常", "image", 10, 10, "red", "false");
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
            HOperatorSet.DistanceCc((HObject)htLine1[line1], (HObject)htLine1[line2], "point_to_point", out hv_distanceMin, out hv_distanceMax);
            hv_distanceMin *= Scale;
            hv_distanceMax *= Scale;
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
            HTuple hv_Width = null, hv_Height = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_Cross1);
            HOperatorSet.GetImageSize((HObject)ho_Image[ImageName], out hv_Width, out hv_Height);
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
            HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Rpoint, hv_Cpoint, hv_Height / 50, new HTuple(45).TupleRad());
            ho_Cross1.Dispose();
            HOperatorSet.GenCrossContourXld(out ho_Cross1, hv_RowMin, hv_ColMin, hv_Height / 50, new HTuple(45).TupleRad());
            HOperatorSet.DispObj(ho_Cross, hWindowControl1.HalconWindow);
            HOperatorSet.DispObj(ho_Cross1, hWindowControl1.HalconWindow);
            HOperatorSet.DispObj(ho_Arrow, hWindowControl1.HalconWindow);
            ho_Arrow.Dispose();
            ho_Cross.Dispose();
            ho_Cross1.Dispose();
            return;
        }
         void disp_mesuer_ll(HObject ho_Image, HObject ho_Line1, HObject ho_Line2,
    out HTuple hv_Row1, out HTuple hv_Col1, out HTuple hv_Row2, out HTuple hv_Col2,
    out HTuple hv_RowProj1, out HTuple hv_ColProj1, out HTuple hv_RowProj2, out HTuple hv_ColProj2)
        {
            // Local iconic variables 

            HObject ho_Arrow1, ho_Arrow2, ho_Arrow3, ho_Arrow4;

            // Local control variables 

            HTuple hv_Width = null, hv_Height = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Arrow1);
            HOperatorSet.GenEmptyObj(out ho_Arrow2);
            HOperatorSet.GenEmptyObj(out ho_Arrow3);
            HOperatorSet.GenEmptyObj(out ho_Arrow4);
            HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
            HOperatorSet.GetContourXld(ho_Line1, out hv_Row1, out hv_Col1);
            HOperatorSet.GetContourXld(ho_Line2, out hv_Row2, out hv_Col2);
            HOperatorSet.ProjectionPl(hv_Row2.TupleSelect(0), hv_Col2.TupleSelect(0), hv_Row1.TupleSelect(
                0), hv_Col1.TupleSelect(0), hv_Row1.TupleSelect(1), hv_Col1.TupleSelect(1),
                out hv_RowProj1, out hv_ColProj1);
            ho_Arrow1.Dispose();
           HOperatorSet_Ex.gen_arrow_contour_xld(out ho_Arrow1, hv_Row2.TupleSelect(0), hv_Col2.TupleSelect(
                0), hv_RowProj1, hv_ColProj1, hv_Height / 50, hv_Height / 50);
            ho_Arrow2.Dispose();
            HOperatorSet_Ex.gen_arrow_contour_xld(out ho_Arrow2, hv_RowProj1, hv_ColProj1, hv_Row2.TupleSelect(
                0), hv_Col2.TupleSelect(0), hv_Height / 50, hv_Height / 50);
            HOperatorSet.DispObj(ho_Arrow1, hWindowControl1.HalconWindow);
            HOperatorSet.DispObj(ho_Arrow2, hWindowControl1.HalconWindow);
            HOperatorSet.ProjectionPl(hv_Row2.TupleSelect(1), hv_Col2.TupleSelect(1), hv_Row1.TupleSelect(
                0), hv_Col1.TupleSelect(0), hv_Row1.TupleSelect(1), hv_Col1.TupleSelect(1),
                out hv_RowProj2, out hv_ColProj2);
            ho_Arrow3.Dispose();
            HOperatorSet_Ex.gen_arrow_contour_xld(out ho_Arrow3, hv_Row2.TupleSelect(1), hv_Col2.TupleSelect(
                1), hv_RowProj2, hv_ColProj2, hv_Height / 50, hv_Height / 50);
            ho_Arrow4.Dispose();
            HOperatorSet_Ex.gen_arrow_contour_xld(out ho_Arrow4, hv_RowProj2, hv_ColProj2, hv_Row2.TupleSelect(
                1), hv_Col2.TupleSelect(1), hv_Height / 50, hv_Height / 50);
            HOperatorSet.DispObj(ho_Arrow3, hWindowControl1.HalconWindow);
            HOperatorSet.DispObj(ho_Arrow4, hWindowControl1.HalconWindow);
            ho_Arrow1.Dispose();
            ho_Arrow2.Dispose();
            ho_Arrow3.Dispose();
            ho_Arrow4.Dispose();
            return;
        }
    }
}
