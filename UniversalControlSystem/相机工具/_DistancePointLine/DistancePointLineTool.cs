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
    public  class DistancePointLineTool:ImageTool
    {
        [NonSerialized]
        HTuple hv_rowA1;
        [NonSerialized]
        HTuple hv_colA1;
        [NonSerialized]
        HTuple hv_rowB1;
        [NonSerialized]
        HTuple hv_colB1;
        [NonSerialized]
        HTuple hv_rowB2;
        [NonSerialized]
        HTuple hv_colB2;
        [NonSerialized]
        HTuple hv_RowEx1 = null, hv_ColEx1 = null, hv_RowEx2 = null, hv_ColEx2 = null;
        HObject arrow;
        [NonSerialized]
        HTuple hv_rowMin=null, hv_colMin=null;
        #region 结果输出
        private HTuple distance,distancePp=null;
         
        public HTuple Distance
        {
            get { return distance; }
            set { distance = value; }
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
        public string Names  { get; set; }
        public string PointName1
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

         Dictionary<string, HTuple> htRowPoint = new  Dictionary<string, HTuple>();
        /// <summary>
        /// row点坐标
        /// </summary>
        public  Dictionary<string, HTuple> HtRowPoint
        {
            get { return htRowPoint; }
            set { htRowPoint = value; }
        }
         Dictionary<string, HTuple> htColPoint = new  Dictionary<string, HTuple>();
        /// <summary>
        /// col点坐标
        /// </summary>
        public  Dictionary<string, HTuple> HtColPoint
        {
            get { return htColPoint; }
            set { htColPoint = value; }
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
            Names = "点到线测量";
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
                SelectPointLine(PointName1, LineName1);
                HSystem.SetSystem("flush_graphic", "false");
                if (IsMeasure)
                {
                    if (distance > Lmeasure && distance < Hmeasure)//工差范围
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
                // Local iconic variables 
                HObject ho_Arrow, ho_Contour,ho_Cross1, ho_Cross2;
                // Local control variables 
                HTuple hv_Angle = null,  hv_cenrow = null, hv_cencol = null;
                HTuple hv_Width = null, hv_Height = null;
              
                // Initialize local and output iconic variables 
                HOperatorSet.GenEmptyObj(out ho_Arrow);
                HOperatorSet.GenEmptyObj(out ho_Contour);
                HOperatorSet.GenEmptyObj(out ho_Cross1);
                HOperatorSet.GenEmptyObj(out ho_Cross2);
                HOperatorSet.GetImageSize((HObject)ho_Image[ImageName], out hv_Width, out hv_Height);

                HSystem.SetSystem("flush_graphic", "true");
                if (ResultLogic)
                {
                    get_cenline_point(hv_rowA1, hv_colA1, hv_rowProj, hv_colProj, out hv_Angle, out hv_cenrow, out hv_cencol);
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "点到线间距:" + distance.TupleString("0.03f"), "image", hv_cenrow, hv_cencol, "white", "forest green");
                    HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 1);
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "blue");
                    HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
                    HOperatorSet_Ex.set_display_font(hWindowControl1.HalconWindow, 12, "sans", "false", "false");//mono', 'sans', 'serif
                    HOperatorSet_Ex.lineLenEx(hv_rowB1, hv_colB1, hv_rowB2, hv_colB2, hv_Width, out hv_RowEx1, out hv_ColEx1, out hv_RowEx2, out hv_ColEx2);
                    ho_Contour.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_RowEx1.TupleConcat(hv_RowEx2),
                        hv_ColEx1.TupleConcat(hv_ColEx2));
                  
                    ho_Arrow.Dispose();
                    HOperatorSet_Ex.gen_arrow_contour_xld(out ho_Arrow, hv_rowA1, hv_colA1, hv_rowProj, hv_colProj,
                        hv_Height / 50, hv_Height / 50);

                    ho_Cross1.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_Cross1, hv_rowA1, hv_colA1, hv_Height / 50, new HTuple(45).TupleRad());

                    ho_Cross2.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_Cross2, hv_rowProj, hv_colProj, hv_Height / 50, new HTuple(45).TupleRad());

                  
                    HOperatorSet.SetLineStyle(hWindowControl1.HalconWindow, ((new HTuple(5)).TupleConcat(5)).TupleConcat(5));
                    HOperatorSet.DispObj(ho_Contour, hWindowControl1.HalconWindow);
                    HOperatorSet.SetLineStyle(hWindowControl1.HalconWindow, new HTuple());
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                    HOperatorSet.DispObj(ho_Arrow, hWindowControl1.HalconWindow);
                    HOperatorSet.DispObj(ho_Cross1, hWindowControl1.HalconWindow);
                    HOperatorSet.DispObj(ho_Cross2, hWindowControl1.HalconWindow);


                    ho_Contour.Dispose();
                    ho_Arrow.Dispose();
                    ho_Cross1.Dispose();
                    ho_Cross2.Dispose();

                }
                else
                { 
                    get_cenline_point(hv_rowA1, hv_colA1, hv_rowProj, hv_colProj, out hv_Angle, out hv_cenrow, out hv_cencol);
                   // get_cenline_point(hv_rowA1, hv_colA1, hv_rowB1, hv_colB1, out hv_Angle, out hv_cenrow, out hv_cencol);
                   // HOperatorSet_Ex.disp_message(WindowControl.HalconWindow, "点到线间距:" + distance.TupleString("0.03f") + "pp:" + distancePp.TupleString("0.03f"), "image", hv_cenrow, hv_cencol, "white", "forest green");
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "点到线间距:" + distance.TupleString("0.03f"), "image", hv_cenrow, hv_cencol, "white", "red");
                    HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 1);
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "red");
                    HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
                    HTuple width, height;
                    HOperatorSet.GetImageSize((HObject)ho_Image[ImageName], out width, out height);
                    HOperatorSet_Ex.lineLenEx(hv_rowB1, hv_colB1, hv_rowB2, hv_colB2, width, out hv_RowEx1, out hv_ColEx1, out hv_RowEx2, out hv_ColEx2);
                    ho_Contour.Dispose();
                    HOperatorSet.GenContourPolygonXld(out ho_Contour, hv_RowEx1.TupleConcat(hv_RowEx2),
                         hv_ColEx1.TupleConcat(hv_ColEx2));

                    ho_Arrow.Dispose();
                    HOperatorSet_Ex.gen_arrow_contour_xld(out ho_Arrow, hv_rowA1, hv_colA1, hv_rowProj, hv_colProj,
                        hv_Height / 50, hv_Height / 50);

                    ho_Cross1.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_Cross1, hv_rowA1, hv_colA1, hv_Height / 50, new HTuple(45).TupleRad());

                    ho_Cross2.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_Cross2, hv_rowProj, hv_colProj, hv_Height / 50, new HTuple(45).TupleRad());

                    HOperatorSet.DispObj(ho_Contour, hWindowControl1.HalconWindow);
                    HOperatorSet.DispObj(ho_Arrow, hWindowControl1.HalconWindow);
                    HOperatorSet.DispObj(ho_Cross1, hWindowControl1.HalconWindow);
                    HOperatorSet.DispObj(ho_Cross2, hWindowControl1.HalconWindow);


                    ho_Contour.Dispose();
                    ho_Arrow.Dispose();
                    ho_Cross1.Dispose();
                    ho_Cross2.Dispose();
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
        HTuple hv_rowProj = null, hv_colProj = null;
        public void SelectPointLine(string point1, string line1)
        {  
            HTuple hv_rowMin = null, hv_colMin = null;
            hv_rowA1 = (HTuple)htRowPoint[point1];
            hv_colA1 = (HTuple)htColPoint[point1];
     
            hv_rowB1 = (HTuple)htRowLine1[line1];
            hv_colB1 = (HTuple)htColLine1[line1];
            hv_rowB2 = (HTuple)htRowLine2[line1];
            hv_colB2 = (HTuple)htColLine2[line1];
        
            //HOperatorSet_Ex.set_display_font(hWindowControl1.HalconWindow, 16, "mono", "true", "false");
            HOperatorSet_Ex.lineLenEx(hv_rowB1, hv_colB1, hv_rowB2, hv_colB2, 500, out hv_RowEx1, out hv_ColEx1, out hv_RowEx2, out hv_ColEx2);
            gen_distance_pl_point((HObject)ho_Image[ImageName],hv_rowA1, hv_colA1, hv_RowEx1, hv_ColEx1, hv_RowEx2, hv_ColEx2, out hv_rowMin, out hv_colMin, out distance);
            distance *= Scale;
            HOperatorSet.ProjectionPl(hv_rowA1, hv_colA1, hv_rowB1, hv_colB1, hv_rowB2, hv_colB2,out  hv_rowProj,out  hv_colProj);
            HOperatorSet.DistancePp(hv_rowA1, hv_colA1, hv_rowProj, hv_colProj, out distancePp);
   
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
            hv_cenrow = hv_Row1 - ((hv_Angle.TupleSin()) * (hv_Distance/2));
            hv_cencol = hv_Column1 +((hv_Angle.TupleCos()) * (hv_Distance/2));
            HOperatorSet.TupleAbs(hv_cenrow, out hv_cenrow);
            return;
        }

        void gen_distance_pl_point(HObject ho_Image,HTuple hv_Rpoint, HTuple hv_Cpoint, HTuple hv_Row1,
            HTuple hv_Column1, HTuple hv_Row2, HTuple hv_Column2, out HTuple hv_RowMin,
            out HTuple hv_ColMin, out HTuple hv_DistanceMin)
        {
          
            // Local control variables 
            HTuple hv_Angle = null, hv_DistanceMax = null;
            HTuple hv_Deg = null;
            // Local control variables 

            HOperatorSet.AngleLx(hv_Row1, hv_Column1, hv_Row2, hv_Column2, out hv_Angle);
            HOperatorSet.DistancePs(hv_Rpoint, hv_Cpoint, hv_Row1, hv_Column1, hv_Row2, hv_Column2,
                out hv_DistanceMin, out hv_DistanceMax);
       
            HOperatorSet.TupleDeg(hv_Angle, out hv_Deg);
            hv_RowMin = ((((hv_Angle + ((new HTuple(90)).TupleRad()))).TupleSin()) * hv_DistanceMin) + hv_Rpoint;
            hv_ColMin = ((((hv_Angle + ((new HTuple(90)).TupleRad()))).TupleCos()) * hv_DistanceMin) - hv_Cpoint;
            HOperatorSet.TupleAbs(hv_ColMin, out hv_ColMin);
            return;
        }

    }
}
