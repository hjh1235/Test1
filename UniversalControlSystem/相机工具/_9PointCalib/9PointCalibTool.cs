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
    public class _9PointCalibTool:ImageTool
    {
        [NonSerialized]
        HTuple hv_rowA1;
        [NonSerialized]
        HTuple hv_colA1;
        [NonSerialized]
        HObject ho_ROI_0;
        [NonSerialized]
        HTuple hv_row, hv_col;
     
        HTuple hv_PixelX = new HTuple();
     
        HTuple hv_PixelY = new HTuple();
     
        HTuple hv_AxisX = new HTuple();
     
        HTuple hv_AxisY = new HTuple();
        /// <summary>
        /// 标定
        /// </summary>
        /// 
        HTuple hv_HomMat2D = null , hv_Axis_X = new HTuple(), hv_Axis_Y= new HTuple();

        /// <summary>
        /// 输出结果
        /// </summary>
        public bool ResultLogic { get; set; }
        #region 参数
        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName
        { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names { get; set; }
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
        public string ModeName
        { get; set; }
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
        public string Setdraw
        { get; set; }
        /// <summary>
        ///ROI形状
        /// </summary>
        public string SetdrawShape
        { get; set; }
        public bool IsRectangle
        { set; get; }
        public bool IsSelectedRegions
        { set; get; }
        public HTuple CenterRow
        {
            get
            {
                return hv_row;
            }

            set
            {
                hv_row = value;
            }
        }

        public HTuple CenterCol
        {
            get
            {
                return hv_col;
            }

            set
            {
                hv_col = value;
            }
        }

        public HTuple AxisY
        {
            get
            {
                return hv_AxisY;
            }

            set
            {
                hv_AxisY = value;
            }
        }

        public HTuple AxisX
        {
            get
            {
                return hv_AxisX;
            }

            set
            {
                hv_AxisX = value;
            }
        }

        public HTuple PixelY
        {
            get
            {
                return hv_PixelY;
            }

            set
            {
                hv_PixelY = value;
            }
        }

        public HTuple PixelX
        {
            get
            {
                return hv_PixelX;
            }

            set
            {
                hv_PixelX = value;
            }
        }


         Dictionary<string, HTuple> htRow = new  Dictionary<string, HTuple>();
        /// <summary>
        /// row点坐标
        /// </summary>
        public  Dictionary<string, HTuple> HtRow
        {
            get { return htRow; }
            set { htRow = value; }
        }
         Dictionary<string, HTuple> htCol = new  Dictionary<string, HTuple>();
        /// <summary>
        /// col点坐标
        /// </summary>
        public  Dictionary<string, HTuple> HtCol
        {
            get { return htCol; }
            set { htCol = value; }
        }

        public string ModelName { get;  set; }

        public HTuple HomMat2D
        {
            get
            {
                return hv_HomMat2D;
            }

            set
            {
                hv_HomMat2D = value;
            }
        }
        #endregion

        public override string toolName()
        {
            return Names;
        }
        public override long toolTimer()
        {
            return timer;
        }
        public override void recon()
        { }
        public override void ini()
        {
            ModelName = "模板匹配0";
            Names = Tool.九点标定.ToString();
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
            SetdrawShape = Roi.圆.ToString(); ;//ROI形状
            IsSelectedRegions = false;//blob区域显示
            IsRectangle = false;//区域矩形显示
        }
       
        public override void draw_roi()
        {

            HObject ho_RegionTrans;
            HOperatorSet.SetColor(HW.Instance().HalconWindow, "green");
            draw_roi(HW.Instance().HalconWindow, ho_Image, ImageName, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2, out hv_circle, out hv_rectangle1, out hv_rectangle2);
            gen_roi();
            this.gen_center_point((HObject)ho_Image[ImageName], ho_ROI_0, out hv_row, out hv_col,out ho_RegionTrans);//标定板 圆点坐标
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.SetDraw(HW.Instance().HalconWindow, Setdraw);
            HOperatorSet.DispObj(ho_RegionTrans, HW.Instance().HalconWindow);
            ho_RegionTrans.Dispose();
            HOperatorSet.DispCross(HW.Instance().HalconWindow, hv_row, hv_col, 50, 0);
            HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "row:=" + this.hv_row + "\n" + "col:=" + this.hv_col, "image", 10, 10, ColorFul.blue.ToString(), ColorFul.white.ToString());
            HSystem.SetSystem("flush_graphic", "false");
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
            dispresult();
            watch.Stop();
            timer = watch.ElapsedMilliseconds;
        }
        private void toolRun()
        {
   
            try
            {  
                HTuple hv_Axis_X, hv_Axis_Y;
                for (int i = 0; i < ((HTuple)htRow[ModelName]).Length; i++)
                {
                    HOperatorSet.AffineTransPoint2d(hv_HomMat2D, ((HTuple)htRow[ModelName])[i], ((HTuple)htCol[ModelName])[i], out hv_Axis_Y, out hv_Axis_X);
                    this.hv_Axis_X[i] = hv_Axis_X;
                    this.hv_Axis_Y[i] = hv_Axis_Y;
                }
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "异常", "image", 10, 10, "red", "false");
                //ResultLogic = false;//不合格
                HSystem.SetSystem("flush_graphic", "false");
            }

        }
        public override void dispresult()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                HSystem.SetSystem("flush_graphic", "true");

                for (int i = 0; i < this.hv_Axis_Y.Length; i++)
                {

                    HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, i.ToString(), "image", ((HTuple)htRow[ModelName])[i] + 10, ((HTuple)htCol[ModelName])[i] + 10, ColorFul.blue.ToString(), "false");
                    string str1 = this.hv_Axis_X.TupleSelect(i).TupleString("0.3f");
                    string str2 = this.hv_Axis_Y.TupleSelect(i).TupleString("0.3f");
                    string str =  string.Format("AxisX{0}:=" + str1 + " AxisY{0}:=" + str2 + "\n",i.ToString());
                    sb.Append(str);
                }
                HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, sb.ToString(), CoordSystem.window.ToString(), 10, 10, ColorFul.blue.ToString(), ColorFul.white.ToString());
                HSystem.SetSystem("flush_graphic", "false");
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "显示异常", CoordSystem.window.ToString(), 10, 10, ColorFul.red.ToString(), "false");
                //ResultLogic = false;//不合格
                HSystem.SetSystem("flush_graphic", "false");
            }
        }
        public override long set_after()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            run();
            dispresult();
            watch.Stop();
            timer = watch.ElapsedMilliseconds;
            return watch.ElapsedMilliseconds;
        }
        public override bool toolResult()
        {
            return ResultLogic;
        }
        /// <summary>
        /// 标定
        /// </summary>
        public void gen_calib_data()
        {
            HOperatorSet.VectorToHomMat2d(PixelX, PixelY, AxisX, AxisY, out hv_HomMat2D);
        }
        void gen_center_point(HObject ho_Image, HObject ho_Region, out HTuple hv_Row,
          out HTuple hv_Column, out HObject ho_RegionTrans)
        {
            // Local iconic variables 

            HObject ho_ImageReduced, ho_Region1, ho_ConnectedRegions;
            HObject ho_SelectedRegions;

            // Local control variables 

            HTuple hv_UsedThreshold = null, hv_Area = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_Region1);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_RegionTrans);
            try
            {
                ho_ImageReduced.Dispose();
                HOperatorSet.ReduceDomain(ho_Image, ho_Region, out ho_ImageReduced);
                ho_Region1.Dispose();
                HOperatorSet.BinaryThreshold(ho_ImageReduced, out ho_Region1, "max_separability",
                    "dark", out hv_UsedThreshold);
                ho_ConnectedRegions.Dispose();
                HOperatorSet.Connection(ho_Region1, out ho_ConnectedRegions);
                ho_SelectedRegions.Dispose();
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, "area",
                    "and", 100, 999999);
                ho_RegionTrans.Dispose();
                HOperatorSet.ShapeTrans(ho_SelectedRegions, out ho_RegionTrans, "outer_circle");
                HOperatorSet.AreaCenter(ho_RegionTrans, out hv_Area, out hv_Row, out hv_Column);
                ho_ImageReduced.Dispose();
                ho_Region1.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions.Dispose();
                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_ImageReduced.Dispose();
                ho_Region1.Dispose();
                ho_ConnectedRegions.Dispose();
                ho_SelectedRegions.Dispose();
                ho_RegionTrans.Dispose();
                throw HDevExpDefaultException;
            }
        }
    } 
}
