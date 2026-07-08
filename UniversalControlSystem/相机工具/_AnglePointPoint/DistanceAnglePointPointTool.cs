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
    public class DistanceAnglePointPointTool : ImageTool
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
        private HTuple  hv_phi, hv_angle;

         public HTuple Angle
        {
            get { return hv_angle; }
            set { hv_angle = value; }
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
            Names = Tool.水平夹角测量.ToString();
            ImageName = "采集图像0";
            IsMeasure = true;
            Hmeasure = 200;
            Lmeasure = 1;

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
                HOperatorSet.SetColor(HW.Instance().HalconWindow, "green");
                SelectPointLine(LineName1);
                HSystem.SetSystem("flush_graphic", "false");
                if (IsMeasure)
                {
                    if (Angle > Lmeasure && Angle < Hmeasure)//工差范围
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
                HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "{" + hv_Exception + "}", CoordSystem.window.ToString(), 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
            }
       
        }
        public override void dispresult()
        {
            try
            {
                HTuple hv_Row, hv_Col;
                HTuple hv_RowEx1, hv_ColEx1, hv_RowEx2, hv_ColEx2;
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.SetColor(HW.Instance().HalconWindow, "green");
                HOperatorSet.SetDraw(HW.Instance().HalconWindow, "margin");
                HOperatorSet_Ex.set_display_font(HW.Instance().HalconWindow, 12, "mono", "false", "false");
                HOperatorSet_Ex.lineLenEx(hv_rowA1, hv_colA1, hv_rowA1, hv_colA1+50, 1000, out hv_RowEx1, out hv_ColEx1, out hv_RowEx2, out hv_ColEx2);

                if (ResultLogic)
                {
                    HOperatorSet.SetColor(HW.Instance().HalconWindow, "green");
                    disp_angle((HObject)ho_Image[ImageName],   hv_RowEx1, hv_ColEx1, hv_RowEx2, hv_ColEx2, hv_rowA1, hv_colA1, hv_rowA2, hv_colA2, out hv_Row, out hv_Col, HW.Instance().HalconWindow);
                    HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, "水平夹角:" + hv_angle.TupleString("0.03f"), "image", hv_Row + 30, hv_Col, "white", "forest green");
                }
                else
                {
                  
                    HOperatorSet.SetColor(HW.Instance().HalconWindow, "red");
                    HOperatorSet_Ex.disp_angle((HObject)ho_Image[ImageName], hv_rowA1, hv_colA1, hv_rowA2, hv_colA2, hv_RowEx1, hv_ColEx1, hv_RowEx2, hv_ColEx2, out hv_Row, out hv_Col, HW.Instance().HalconWindow);
                    HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, "水平夹角:" + hv_angle.TupleString("0.03f"), "image", hv_Row + 30, hv_Col, "white", "red");
                }
                HSystem.SetSystem("flush_graphic", "false");
            }

            catch
            {
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
                 HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
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
        public void SelectPointLine(string line1)
        {
          

            hv_rowA1 = (HTuple)htRowLine1[line1];
            hv_colA1 = (HTuple)htColLine1[line1];
            hv_rowA2 = (HTuple)htRowLine2[line1];
            hv_colA2 = (HTuple)htColLine2[line1];

         
            HOperatorSet.AngleLx(hv_rowA1, hv_colA1, hv_rowA2, hv_colA2, out hv_phi);
            HOperatorSet.TupleDeg(hv_phi, out hv_angle);//弧度转换成角度

            HOperatorSet_Ex.set_display_font(HW.Instance().HalconWindow, 16, "mono", "true", "false");
            //HOperatorSet_Ex.disp_message(WindowControl.HalconWindow, distance, "image", hv_cenrow, hv_cencol, "green", "false");
            HOperatorSet.SetLineWidth(HW.Instance().HalconWindow, 1);
            HOperatorSet.SetColor(HW.Instance().HalconWindow, "green");
            HOperatorSet.SetDraw(HW.Instance().HalconWindow, "margin");
            HOperatorSet.DispLine(HW.Instance().HalconWindow, hv_rowA1, hv_colA1, hv_rowA2, hv_colA2);
       
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
            HOperatorSet.DispObj(ho_Cross, HW.Instance().HalconWindow);
            HOperatorSet.DispObj(ho_Cross1, HW.Instance().HalconWindow);
            HOperatorSet.DispObj(ho_Arrow, HW.Instance().HalconWindow);
            ho_Arrow.Dispose();
            ho_Cross.Dispose();
            ho_Cross1.Dispose();
            return;
        }
        public void disp_angle(HObject ho_Image, HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Row2,
      HTuple hv_Column2, HTuple hv_Row11, HTuple hv_Column11, HTuple hv_Row21, HTuple hv_Column22,out HTuple hv_Row ,out HTuple hv_Column ,
      HTuple hv_ExpDefaultWinHandle)
        {
            // Local iconic variables 

            HObject ho_Arrow1, ho_Arrow2, ho_CircleSector;

            // Local control variables 

            HTuple hv_IsOverlapping = null;
            HTuple hv_Angle1 = null, hv_Angle2 = null, hv_Width = null;
            HTuple hv_Height = null, hv_size = null, hv_size1 = null;
            HTuple hv_rad1 = new HTuple(), hv_rad2 = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Arrow1);
            HOperatorSet.GenEmptyObj(out ho_Arrow2);
            HOperatorSet.GenEmptyObj(out ho_CircleSector);
            HOperatorSet.IntersectionLines(hv_Row1, hv_Column1, hv_Row2, hv_Column2, hv_Row11,
                hv_Column11, hv_Row21, hv_Column22, out hv_Row, out hv_Column, out hv_IsOverlapping);
            HOperatorSet.DispCross(hv_ExpDefaultWinHandle, hv_Row, hv_Column, 10, 0);
            HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Angle1);
            HOperatorSet.AngleLx(hv_Row11, hv_Column11, hv_Row21, hv_Column22, out hv_Angle2);
            HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
            hv_size = hv_Width / 50;
            hv_size1 = hv_Width / 20;
            ho_Arrow1.Dispose();
            HOperatorSet_Ex.gen_arrow_contour_xld(out ho_Arrow1, hv_Row1, hv_Column1, hv_Row2, hv_Column2,
                hv_size, hv_size);
            ho_Arrow2.Dispose();
            HOperatorSet_Ex.gen_arrow_contour_xld(out ho_Arrow2, hv_Row11, hv_Column11, hv_Row21, hv_Column22,
                hv_size, hv_size);
            if ((int)(new HTuple(hv_Angle1.TupleLess(0))) != 0)
            {
                hv_rad1 = ((new HTuple(360)).TupleRad()) + hv_Angle1;
            }
            else
            {
                hv_rad1 = hv_Angle1.Clone();
            }
            if ((int)(new HTuple(hv_Angle2.TupleLess(0))) != 0)
            {
                hv_rad2 = ((new HTuple(360)).TupleRad()) + hv_Angle2;
            }
            else
            {
                hv_rad2 = hv_Angle2.Clone();
            }
            ho_CircleSector.Dispose();
            //HOperatorSet.GenCircleSector(out ho_CircleSector, hv_Row, hv_Column, hv_size1,
            //             hv_rad1, hv_rad2);
            HOperatorSet.GenCircleContourXld(out ho_CircleSector, hv_Row, hv_Column, hv_size1, hv_rad1, hv_rad2, "positive", 1);
            HOperatorSet.SetDraw(hv_ExpDefaultWinHandle, "margin");
            HOperatorSet.SetColor(HW.Instance().HalconWindow, "blue");
            HOperatorSet.DispObj(ho_CircleSector, hv_ExpDefaultWinHandle);
            HOperatorSet.SetLineStyle(HW.Instance().HalconWindow, ((new HTuple(5)).TupleConcat(5)).TupleConcat(5));
            HOperatorSet.DispObj(ho_Arrow1, hv_ExpDefaultWinHandle);
            HOperatorSet.DispObj(ho_Arrow2, hv_ExpDefaultWinHandle);
            HOperatorSet.SetLineStyle(HW.Instance().HalconWindow, new HTuple());
            ho_Arrow1.Dispose();
            ho_Arrow2.Dispose();
            ho_CircleSector.Dispose();
            return;
        }
    }
}
