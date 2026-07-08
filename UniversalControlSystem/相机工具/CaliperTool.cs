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
    public class CaliperTool : ImageTool
    {
        // Local iconic variables 

        [NonSerialized]
        HObject ho_ROI_0, ho_MeasureArrow,ho_ResultObject, ho_ResultLineObject;
        HTuple hv_Width = null, hv_Height = null, hv_MeasureHandle = null;
        [NonSerialized]
        HTuple AffineTran_row1, AffineTran_col1, AffineTran_angle1;
        [NonSerialized]
        List<bool> resultLogic = new List<bool>();
        [NonSerialized]
        bool logic;
        #region 仿射矩阵
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
        #endregion
        #region 结果输出
         HTuple distance;
       
        public HTuple Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        HTuple intraDistance;
       
        public HTuple IntraDistance
        {
            get { return intraDistance; }
            set { intraDistance = value; }
        }
        HTuple interDistance;
     
        public HTuple InterDistance
        {
            get { return interDistance; }
            set { interDistance = value; }
        }
        HTuple hv_RowEdge1 = null, hv_ColumnEdge1 = null, hv_Amplitude1 = null;
        HTuple hv_RowEdge2 = null, hv_ColumnEdge2 = null, hv_Amplitude2 = null;
     
        public List<HTuple> listDistance = new List<HTuple>();
        public List<HTuple> listIntraDistance = new List<HTuple>();
        public List<HTuple> listInterDistance = new List<HTuple>();
        public List<HTuple> listRowEdge1 = new List<HTuple>();
        public List<HTuple> listRowEdge2 = new List<HTuple>();
        public List<HTuple> listColumnEdge1 = new List<HTuple>();
        public List<HTuple> listColumnEdge2 = new List<HTuple>();

        public HTuple RowEdge1
        {
            get { return hv_RowEdge1; }
            set { hv_RowEdge1 = value; }
        }

        public HTuple ColumnEdge1
        {
            get { return hv_ColumnEdge1; }
            set { hv_ColumnEdge1 = value; }
        }

        public HTuple Amplitude1
        {
            get { return hv_Amplitude1; }
            set { hv_Amplitude1 = value; }
        }
        public HTuple RowEdge2
        {
            get { return hv_RowEdge2; }
            set { hv_RowEdge2 = value; }
        }

        public HTuple ColumnEdge2
        {
            get { return hv_ColumnEdge2; }
            set { hv_ColumnEdge2 = value; }
        }

        public HTuple Amplitude2
        {
            get { return hv_Amplitude2; }
            set { hv_Amplitude2 = value; }
        }
        public bool ResultLogic { get; set; }
        #endregion
        #region 结果输出判定
        public int SelectMeasure { get; set; }
        public bool IsMeasure { get; set; }
        public HTuple Hmeasure
        { get; set; }
        public HTuple Lmeasure
        { get; set; }
       #endregion
        #region 参数
        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names { get; set; }

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
         /// <summary>
        /// 轮廓显示
        /// </summary>
        public string Setdraw { get; set; }
        /// <summary>
        ///ROI形状
        /// </summary>
        public string SetdrawShape { get; set; }
     
        /// <summary>
        /// 位置定位
        /// </summary>
        public string FixNames { get; set; }
        /// <summary>
        /// 使用位置定位
        /// </summary>
        public bool IsFixture { get; set; }

        /// <summary>
        /// 选择边缘
        /// </summary>
        public int Selcet  { get; set; }
        /// <summary>
        /// 极性
        /// </summary>
        public int Transition  { get; set; }
        /// <summary>
        /// 平滑值
        /// </summary>
        public HTuple Sigma   { get; set; }
        /// <summary>
        /// 过渡阈值
        /// </summary>
        public HTuple Threshold   { get; set; }
        /// <summary>
        /// 边缘对/true 非边缘对/false
        /// </summary>
        public bool IsEdge { get; set; }
        public bool IsRule { get; set; }
        public bool IsCross { get; set; }
        public bool IsLine { get; set; }

        /// <summary>
        /// 比例
        /// </summary>
        public HTuple Scale { get; set; }
        /// <summary>
        /// 测量差值
        /// </summary>
        public string Interpolation { get; set; }
        #endregion
        public override string toolName()
        { return Names; }
        public override long toolTimer()
        {
            return timer;
        }
        public override void recon()
        { 
            this.resultLogic = new List<bool>();
            phi = new List<HTuple>();
            hv_HomMat2D = new List<HTuple>();
        }
        public override void ini()
        {
            Names = Tool.卡尺测量.ToString();
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
            Interpolation = "nearest_neighbor";
            Sigma = 1;
            Threshold = 30;
            Selcet = 3;
            Transition = 3;
            IsFixture = false;
            SelectMeasure = 1;                
            IsEdge = false;
            IsRule = false;
            IsCross = false;
            IsLine = false;
            IsMeasure = true;
            Hmeasure = 200;
            Lmeasure = 1;
            Scale = 1.000;
         }
        public override void draw_roi()
        {
            HOperatorSet.SetColor(HW.Instance().HalconWindow, "green");
            draw_roi(HW.Instance().HalconWindow, ho_Image,ImageName, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2, out hv_circle, out hv_rectangle1, out hv_rectangle2);
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
            listDistance.Clear();
            listIntraDistance.Clear();
            listInterDistance.Clear();
            listRowEdge1.Clear();
            listRowEdge2.Clear();
            listColumnEdge1.Clear();
            listColumnEdge2.Clear();

            hv_RowEdge1 = null; hv_ColumnEdge1= null;
            hv_RowEdge2 = null; hv_ColumnEdge2 = null;
            HTuple row, col, phi, len1, len2;
            try
            {
                 ResultLogic = true;
                resultLogic.Clear();
                HOperatorSet.GetImageSize((HObject)ho_Image[ImageName], out hv_Width, out hv_Height);
                if (IsFixture) //使用位置定位
                {   //
                    HomMat2D = (List<HTuple>)dicHomMat2D[FixNames];  //  选择位置定位
                    Phi = (List<HTuple>)DicPhi[FixNames]; //  选择位置定位
                    //遍历定位>测量
                    for (int i = 0; i < HomMat2D.Count; i++)
                    {
                        AffineTran_angle1 = Phi[i];
                        HOperatorSet.AffineTransPixel(HomMat2D[i], hv_rectangle2[0], hv_rectangle2[1], out AffineTran_row1, out AffineTran_col1);
                        HOperatorSet.GenMeasureRectangle2(AffineTran_row1, AffineTran_col1, hv_rectangle2[2] + AffineTran_angle1, hv_rectangle2[3], hv_rectangle2[4],
                           hv_Width, hv_Height, Interpolation, out hv_MeasureHandle);
                        measure();//测量
                      
                        if (hv_MeasureHandle != null)
                            HOperatorSet.CloseMeasure(hv_MeasureHandle);//销毁句柄
                    
                    }
                }
                else   //
                {
                    row = hv_rectangle2[0];
                    col = hv_rectangle2[1];
                    phi = hv_rectangle2[2];
                    len1 = hv_rectangle2[3];
                    len2 = hv_rectangle2[4];

                    HOperatorSet.GenMeasureRectangle2(row, col, phi, len1, len2,
                                    hv_Width, hv_Height, Interpolation, out hv_MeasureHandle);
                    try
                    {
                        measure();
                    }
                    catch
                    {
                        ResultLogic = false;//结果异常
                        return;
                    }
                    if (hv_MeasureHandle != null)
                        HOperatorSet.CloseMeasure(hv_MeasureHandle);//销毁句柄
                    HSystem.SetSystem("flush_graphic", "false");
                }
                foreach (bool item in resultLogic)
                {
                    if (!item)
                        ResultLogic = false;
                }
            }

            catch (HalconException ex)
            {
                HSystem.SetSystem("flush_graphic", "true");
                ResultLogic = false;//结果异常
                HTuple hv_Exception;
                ex.ToHTuple(out hv_Exception);
                HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "{" + hv_Exception + "}", CoordSystem.window.ToString(), 10, 10, "red", "false");
                if (hv_MeasureHandle != null)
                    HOperatorSet.CloseMeasure(hv_MeasureHandle);//销毁句柄
                HSystem.SetSystem("flush_graphic", "false"); 
            }
        }
        /// <summary>
        /// 测量
        /// </summary>
        void measure()
        {
            string polarity = Polarity();
            string pointSelect = PointSelect();
             if(IsEdge)  //
             {
                //边缘对
                HOperatorSet.MeasurePairs((HObject)ho_Image[ImageName], hv_MeasureHandle, Sigma, Threshold, polarity, pointSelect, out hv_RowEdge1,
                out hv_ColumnEdge1,
                out hv_Amplitude1,
                out hv_RowEdge2,
                out hv_ColumnEdge2,
                out hv_Amplitude2,
                out intraDistance,
                out interDistance);
                MeasureMode(hv_RowEdge1, hv_ColumnEdge1, intraDistance, interDistance);
                intraDistance *= Scale;
                interDistance *= Scale;
                listRowEdge1.Add(hv_RowEdge1);
                listRowEdge2.Add(hv_RowEdge2);
                listColumnEdge1.Add(hv_ColumnEdge1);
                listColumnEdge2.Add(hv_ColumnEdge2);
                listIntraDistance.Add(intraDistance);
                listInterDistance.Add(interDistance);

            }

             else
             {
                 HOperatorSet.MeasurePos((HObject)ho_Image[ImageName], hv_MeasureHandle, Sigma, Threshold, polarity, pointSelect, out hv_RowEdge1,
                                                                                                                  out hv_ColumnEdge1,
                                                                                                                  out hv_Amplitude1,
                                                                                                                  out distance);
                distance *= Scale;

                MeasureMode(hv_RowEdge1, hv_ColumnEdge1, distance, 0);
                listRowEdge1.Add(hv_RowEdge1);
                listColumnEdge1.Add(hv_ColumnEdge1);
                listDistance.Add(distance);
            }
     }
        void dispResult()
        {
            try {

                HOperatorSet_Ex.set_display_font(HW.Instance().HalconWindow, 12, "sans", "false", "false");//mono', 'sans', 'serif
                HObject ho_Cross = null;
                for (int i = 0; i < resultLogic.Count; i++)    //遍历定位>测量图形
                {
                    if (resultLogic[i])
                        HOperatorSet.SetColor(HW.Instance().HalconWindow, ColorFul.green.ToString());
                    else
                        HOperatorSet.SetColor(HW.Instance().HalconWindow, ColorFul.red.ToString());

                    if (IsLine)
                    {
                        // 测量点水平线
                        if (listRowEdge1.Count > 0)
                        {
                            HTuple RowEdge1 = listRowEdge1[i];
                            HTuple ColumnEdge1 = listColumnEdge1[i];
                            if (IsFixture) //使用位置定位
                                HOperatorSet.DispObj(display_line(RowEdge1, ColumnEdge1, hv_rectangle2[4], hv_rectangle2[2] + AffineTran_angle1), HW.Instance().HalconWindow);
                            else
                                HOperatorSet.DispObj(display_line(RowEdge1, ColumnEdge1, hv_rectangle2[4], hv_rectangle2[2]), HW.Instance().HalconWindow);

                        }
                        if (listRowEdge2.Count > 0)
                        {
                            HTuple RowEdge2 = listRowEdge2[i];
                            HTuple ColumnEdge2 = listColumnEdge2[i];
                            if (IsFixture) //使用位置定位
                                HOperatorSet.DispObj(display_line(RowEdge2, ColumnEdge2, hv_rectangle2[4], hv_rectangle2[2] + AffineTran_angle1), HW.Instance().HalconWindow);
                            else
                                HOperatorSet.DispObj(display_line(RowEdge2, ColumnEdge2, hv_rectangle2[4], hv_rectangle2[2]), HW.Instance().HalconWindow);

                        }
                    }
                    if (IsCross)
                    {
                        // 测量标记点
                        if (listRowEdge1.Count > 0)
                        {
                            HOperatorSet.SetLineWidth(HW.Instance().HalconWindow, 1);
                            HOperatorSet.GenCrossContourXld(out ho_Cross, listRowEdge1[i], listColumnEdge1[i], hv_Height / 50, new HTuple(45).TupleRad());
                            HOperatorSet.DispObj(ho_Cross, HW.Instance().HalconWindow);

                        }
                        if (listRowEdge2.Count > 0)
                        {
                            HOperatorSet.SetLineWidth(HW.Instance().HalconWindow, 1);
                            HOperatorSet.GenCrossContourXld(out ho_Cross, listRowEdge2[i], listColumnEdge2[i], hv_Height / 50, new HTuple(45).TupleRad());
                            HOperatorSet.DispObj(ho_Cross, HW.Instance().HalconWindow);

                        }
                    }
                    if (IsRule)
                    {
                        //  HOperatorSet.SetColor(WindowControl.HalconWindow, ColorFul.red.ToString());
                        //测量卡尺区域
                        HOperatorSet.SetLineWidth(HW.Instance().HalconWindow, 1);
                        if (IsFixture) //使用位置定位
                        {   //
                            HomMat2D = (List<HTuple>)dicHomMat2D[FixNames];  //  选择位置定位
                            Phi = (List<HTuple>)DicPhi[FixNames]; //  选择位置定位
                                                                  //遍历定位>测量
                            AffineTran_angle1 = Phi[i];
                            HOperatorSet.AffineTransPixel(HomMat2D[i], hv_rectangle2[0], hv_rectangle2[1], out AffineTran_row1, out AffineTran_col1);
                            if (ho_MeasureArrow != null)
                                ho_MeasureArrow.Dispose();
                            dev_display_measure_arrow(out ho_MeasureArrow, HW.Instance().HalconWindow, false, AffineTran_row1, AffineTran_col1, hv_rectangle2[2] + AffineTran_angle1, hv_rectangle2[3], hv_rectangle2[4]);
                            HOperatorSet.DispObj(ho_MeasureArrow, HW.Instance().HalconWindow);

                            //}
                        }
                        else
                        {
                            dev_display_measure_arrow(out ho_MeasureArrow, HW.Instance().HalconWindow, false, hv_rectangle2[0], hv_rectangle2[1], hv_rectangle2[2], hv_rectangle2[3], hv_rectangle2[4]);
                            HOperatorSet.DispObj(ho_MeasureArrow, HW.Instance().HalconWindow);

                        }
                        //if (IsEdge)  //
                        //{

                        //    if (SelectMeasure == 0) // "距离";
                        //    {
                        //        HOperatorSet_Ex.disp_message(WindowControl.HalconWindow, "距离:" + listIntraDistance[i] + "mm", "image", listRowEdge1[0] - hv_Height / 20, listColumnEdge1[0], "white", "forest green");
                        //    }
                        //    else if (SelectMeasure == 1) // "宽度";
                        //    {
                        //        HOperatorSet_Ex.disp_message(WindowControl.HalconWindow, "宽度:" + listInterDistance[i] + "mm", "image", listRowEdge2[0] - hv_Height / 20, listColumnEdge2[0], "white", "forest green");
                        //    }
                        //}
                        //else
                        //{
                        //    if (SelectMeasure == 0) // "距离";
                        //    {
                        //        HOperatorSet_Ex.disp_message(WindowControl.HalconWindow, "距离:" + listDistance[i] + "mm", "image", listRowEdge1[0] - hv_Height / 20, listColumnEdge1[0], "white", "forest green");
                        //    }
                        //}

                    }
                    if (SelectMeasure == 2)// = "Row";
                    {
                        HOperatorSet.SetColor(HW.Instance().HalconWindow, ColorFul.blue.ToString());
                        double width = hv_Width.D - 10;
                        HOperatorSet.SetDraw(HW.Instance().HalconWindow, Set_draw.margin.ToString());
                        HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, "Row-Y方向管控值", CoordSystem.image.ToString(), Lmeasure, 10, ColorFul.blue.ToString(), "false");
                        HOperatorSet.DispRectangle1(HW.Instance().HalconWindow, Lmeasure, 10, Hmeasure, width);

                    }
                    else if (SelectMeasure == 3)// "Col";
                    {
                        HOperatorSet.SetColor(HW.Instance().HalconWindow, ColorFul.blue.ToString());
                        double height = hv_Height - 10;
                        HOperatorSet.SetDraw(HW.Instance().HalconWindow, Set_draw.margin.ToString());
                        HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, "Col-X方向管控值", CoordSystem.image.ToString(), 10, Lmeasure, ColorFul.blue.ToString(), "false");
                        HOperatorSet.DispRectangle1(HW.Instance().HalconWindow, 10, Lmeasure, height, Hmeasure);

                    }
                } }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "显示异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
            }
          
        }

        public override void dispresult()
        {
            HSystem.SetSystem("flush_graphic", "true");
            dispResult();
            HSystem.SetSystem("flush_graphic", "false");
        }
        public override long set_after()
         {
            try
             {   Stopwatch watch = new Stopwatch();
                 watch.Start();
                 HOperatorSet.ClearWindow(HW.Instance().HalconWindow);
                 HSystem.SetSystem("flush_graphic", "true");
                 HOperatorSet.DispObj(ho_Image[ImageName], HW.Instance().HalconWindow);
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
        /// <summary>
        /// 检测<0-距离><1-宽度><2-Row><3—Col>
        /// </summary>
        /// <param name="_row1"></param>
        /// <param name="_col1"></param>
        /// <param name="_distance">距离</param>
        /// <param name="_with">宽度</param>
        void MeasureMode(HTuple _row1, HTuple _col1, HTuple _distance, HTuple _with)
          {
              HOperatorSet.SetColor(HW.Instance().HalconWindow, "green");
              HSystem.SetSystem("flush_graphic", "true");
              //if (!ResultLogic)  //如果出false跳出方法体
              //    return;
              if (SelectMeasure == 0) // "距离";
              {
              HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, "距离:" + _distance+"mm", "image", _row1[0]- hv_Height / 20, _col1[0], "white", "forest green");
                logic = true;
                  if (Lmeasure > _distance || _distance > Hmeasure)
                     logic = false;
                  resultLogic.Add(logic);

              }
              else if (SelectMeasure == 1) // "宽度";
              {
             
             HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, "宽度:"+ _with + "mm", "image", _row1[0] - hv_Height / 20, _col1[0], "white", "forest green");

                logic = true;
                if (Lmeasure > _with || _with > Hmeasure)//工差范围
                {
                    logic = false;
                }
                resultLogic.Add(logic);
               }
              else if (SelectMeasure == 2)// = "Row";
              {
                  logic = true;
                  double width = hv_Width.D - 10;
                  HOperatorSet.SetDraw(HW.Instance().HalconWindow, Set_draw.margin.ToString());
              //  HOperatorSet_Ex.disp_message(WindowControl.HalconWindow, "Row-Y方向管控值", CoordSystem.image.ToString(), Lmeasure, 10, ColorFul.green.ToString(), "false");
                  HOperatorSet.DispRectangle1(HW.Instance().HalconWindow, Lmeasure, 10, Hmeasure, width);
                  if (Lmeasure > _row1 || _row1 > Hmeasure)//工差范围
                      logic = false;
                  resultLogic.Add(logic);
          
               }
              else if (SelectMeasure == 3)// "Col";
              {
                  ResultLogic = true;
                  double height = hv_Height - 10;
                  HOperatorSet.SetDraw(HW.Instance().HalconWindow, Set_draw.margin.ToString());
             //   HOperatorSet_Ex.disp_message(WindowControl.HalconWindow, "Col-X方向管控值", CoordSystem.image.ToString(), 10, Lmeasure, ColorFul.green.ToString(), "false");
                  HOperatorSet.DispRectangle1(HW.Instance().HalconWindow, 10, Lmeasure, height, Hmeasure);
                  if (Lmeasure > _col1 || _col1 > Hmeasure)//工差范围
                      ResultLogic = false;
                  resultLogic.Add(logic);
              }
              HSystem.SetSystem("flush_graphic", "false");
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
