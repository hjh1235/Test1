using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.IO.Ports;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using HalconDotNet;
using HOperatorSet_EX;

namespace UniversalControlSystem
{
  
    [Serializable]
    public  class ImageTool
    {
        [NonSerialized]
         List<ImageTool> tempImageTool;
        [NonSerialized]
        public  long timer;
        [NonSerialized]
        HalconDotNet.HWindowControl windowControl;


        public enum Roi
        {
            圆 = 0,
            矩形 = 1,
            方向矩形 = 2
        }
        public enum Set_draw
        {
            margin = 0,
            fill = 1
        }

        public HalconDotNet.HWindowControl hWindowControl1
        {
            get
            {
                return windowControl;
            }
            set
            {
                windowControl = value;
            }
        }
        public enum ColorFul
        {
            black,
            blue,
            yellow,
            red,
            green,
            cyan,
            magenta,
            coral,
            pink,
            white,
            gray,
            orange,
         }
        public enum Tool
        {
            采集图像 = 0,
            斑点分析 = 1,
            找圆测量 = 2,
            找线测量 = 3,
            形状模板匹配 = 4,
            NCC匹配 = 65,
            差异比较检测 = 5,
            卡尺测量 = 6,
            字符识别检测 = 7,
            条形码识别 = 8,
            二维码识别 = 9,
            点到线测量 = 10,
            点到点测量 = 11,
            两线间距测量 = 12,
            两线夹角测量 = 13,
            找顶点测量 = 14,
            图像预处理 = 15,
            标定图像 = 16,
            位置定位 = 17,
            性线收缩图像 = 18,
            均值滤波图像 = 19,
            中值滤波图像 = 20,
            平滑图像 = 21,
            区域合并 = 22,
            区域交集 = 23,
            区域差集 = 24,
            区域对称差 = 25,
            区域创建 = 26,
            彩色转HSV图像 = 27,
            串口设置=28,
            补正图像 = 29,
            划痕提取检测 = 30,
            脏污提取检测 = 31,
            图像校正 = 32,
            增强图像=33,
            九点标定=34,
            存储图像=35,
            瑕疵提取检测 = 36,
            颜色抽取检测 = 37,
            焊点检测=38,
            两线交点测量 = 39,
            找方向矩形测量 = 40,
            水平夹角测量 = 41,
            工具块=42,
            取反图像 = 43,
            结构区域膨胀 = 44,
            圆区域膨胀 = 45,
            矩形区域膨胀 = 46,
            圆区域腐蚀 = 47,
            矩形区域腐蚀 = 48,
            圆区域开运算=49,
            矩形区域开运算 = 50,
            圆区域闭运算 = 51,
            矩形区域闭运算 = 52,
            灰度值膨胀 =53,
            灰度值腐蚀 =54,
            灰度开运算=55,
            灰度闭运算 = 55,
            极坐标变换图像 = 56,
            旋转图像=57,
            视觉脚本=58,
            区域形态处理=59,
            灰度形态处理图像 = 60,
            顶帽处理图像 = 61,
            底帽处理图像 = 62,
            找边测量 = 63,
            投影图像 = 64
        }
        public enum CoordSystem
        {
            window,
            image
        }
        public virtual string toolName()
        {
            return "";
        }
        public virtual long toolTimer()
        {
            return 0;
        }
        public virtual bool toolResult()
        {
            return false;
        }
        public virtual void recon()
        { }
        public virtual void ini()
        {
        }
        public virtual void draw_roi()
        { }
        public virtual void run()
        { }
        public virtual void dispresult()
        { }
        public virtual long set_after()
        { return 0; }


        /// <summary>     
        /// 配方名  
        /// </summary>
        public string RunFlowData_ControlDataName { get; set; }
        /// <summary>     
        /// 流程名
        /// </summary>
        public string RunFlowData_ControlDataStepName { get; set; }
        /// <summary>
        /// 步骤序号
        /// </summary>
        public int FlowChar_StepControlNum { get; set; }
        /// <summary>
        /// 步骤名称
        /// </summary>
        public string FlowChar_StepControlName { get; set; }
        /// <summary>
        /// 步骤类型
        /// </summary>
        public string FlowChar_StepControlType { get; set; }

        /// <summary>
        /// 步骤描述
        /// </summary>
        public string RunFlowData_ControlDataDescrptive { get; set; }
        /// <summary>
        /// 步骤时间
        /// </summary>
        public double FlowChar_StepControlTIME { get; set; }

        /// <summary>
        /// 步骤结果
        /// </summary>
        public string FlowChar_StepControlRel { get; set; }

        /// <summary>
        /// 步骤跳转
        /// </summary>
        public int FlowChar_StepControlLoop { get; set; }

        public void gen_roi(out HObject ho_ROI_0, string drawshape, HTuple hv_circle, HTuple hv_rectangle1, HTuple hv_rectangle2)
        {
            HOperatorSet.SetDraw(HW.Instance().HalconWindow, Set_draw.margin.ToString());
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ROI_0);
            if (drawshape.Equals(Roi.圆.ToString()))
            {
                ho_ROI_0.Dispose();
                HOperatorSet.GenCircle(out ho_ROI_0, hv_circle.TupleSelect(0), hv_circle.TupleSelect(
                    1), hv_circle.TupleSelect(2));
                //HOperatorSet.DispObj(ho_ROI_0, hv_WinHandle);
            }
            if (drawshape.Equals(Roi.矩形.ToString()))
            {
                ho_ROI_0.Dispose();
                HOperatorSet.GenRectangle1(out ho_ROI_0, hv_rectangle1.TupleSelect(0), hv_rectangle1.TupleSelect(
                    1), hv_rectangle1.TupleSelect(2), hv_rectangle1.TupleSelect(3));
                //HOperatorSet.DispObj(ho_ROI_0, hv_WinHandle);
            }
            if (drawshape.Equals(Roi.方向矩形.ToString()))
            {
                ho_ROI_0.Dispose();
                HOperatorSet.GenRectangle2(out ho_ROI_0, hv_rectangle2.TupleSelect(0), hv_rectangle2.TupleSelect(
                    1), hv_rectangle2.TupleSelect(2), hv_rectangle2.TupleSelect(3), hv_rectangle2.TupleSelect(4));
                //HOperatorSet.DispObj(ho_ROI_0, hv_WinHandle);
            }
            //HSystem.SetSystem("flush_graphic", "true");
            //HOperatorSet.DispObj(ho_ROI_0, WindowControl.HalconWindow);
            //HSystem.SetSystem("flush_graphic", "false");
        }
        public void dev_display_measure_arrow(out HObject ho_Arrow, HTuple hWin,
          bool dir, HTuple hv_Row1, HTuple hv_Column1, HTuple hv_Phi, HTuple hv_Length1, HTuple hv_Length2)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            // Local iconic variables 
            HObject ho_Rectangle;
            // Local control variables 
            HTuple hv_RowEx = null, hv_ColEx = null, hv_beginRow = null;
            HTuple hv_beginCol = null, hv_EndRow = null, hv_EndCol = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            try
            {
                ho_Rectangle.Dispose();
                HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_Row1, hv_Column1, hv_Phi, hv_Length1, hv_Length2);
                if (dir)
                {
                    hv_beginRow = hv_Row1 + ((hv_Phi.TupleSin()) * (hv_Length1 + 20));
                    hv_beginCol = hv_Column1 - ((hv_Phi.TupleCos()) * (hv_Length1 + 20));
                    hv_EndRow = hv_Row1 + ((hv_Phi.TupleSin()) * (hv_Length1));
                    hv_EndCol = hv_Column1 - ((hv_Phi.TupleCos()) * (hv_Length1));
                }
                else
                {
                    //hv_RowEx = hv_Row1 - ((hv_Phi.TupleSin()) * hv_Length1);
                    //hv_ColEx = hv_Column1 + ((hv_Phi.TupleCos()) * hv_Length1);

                    //hv_beginRow = hv_RowEx + (hv_Phi.TupleSin());
                    //hv_beginCol = hv_ColEx - (hv_Phi.TupleCos());
                    //hv_EndRow = hv_RowEx - ((hv_Phi.TupleSin()) * 20);
                    //hv_EndCol = hv_ColEx + ((hv_Phi.TupleCos()) * 20);


                    hv_beginRow = hv_Row1 - ((hv_Phi.TupleSin()) * (hv_Length1));
                    hv_beginCol = hv_Column1 + ((hv_Phi.TupleCos()) * (hv_Length1));
                    hv_EndRow = hv_Row1 - ((hv_Phi.TupleSin()) * (hv_Length1 + 20));
                    hv_EndCol = hv_Column1 + ((hv_Phi.TupleCos()) * (hv_Length1 + 20));
                }
                ho_Arrow.Dispose();
                HOperatorSet_Ex.gen_arrow_contour_xld(out ho_Arrow, hv_beginRow, hv_beginCol, hv_EndRow, hv_EndCol,
                    10, 10);

                HOperatorSet.DispObj(ho_Rectangle, hWin);
                {
                    HObject ExpTmpOutVar_0;
                    HOperatorSet.ConcatObj(ho_Arrow, ho_Rectangle, out ExpTmpOutVar_0);
                    ho_Arrow.Dispose();
                    ho_Arrow = ExpTmpOutVar_0;
                }
                ho_Rectangle.Dispose();
                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Rectangle.Dispose();

                throw HDevExpDefaultException;
            }
        }
        public HObject display_line(HTuple hv_RowEdge, HTuple hv_ColumnEdge, HTuple hv_len2, HTuple hv_ph1)
        {
            HTuple begin_row = hv_RowEdge - (hv_len2 * (new HTuple(hv_ph1).TupleCos()));
            HTuple begin_col = hv_ColumnEdge - (hv_len2 * (new HTuple((hv_ph1)).TupleSin()));
            HTuple end_row = hv_RowEdge + (hv_len2 * (new HTuple(hv_ph1).TupleCos()));
            HTuple end_col = hv_ColumnEdge + (hv_len2 * (new HTuple((hv_ph1)).TupleSin()));
            HObject xldLine1, xldLine2;
            HOperatorSet.GenEmptyObj(out xldLine1);
            HOperatorSet.GenEmptyObj(out xldLine2);
            xldLine1.Dispose();
            for (int i = 0; i < begin_row.Length; i++)
            {
                HOperatorSet.GenContourPolygonXld(out xldLine1, ((begin_row.TupleSelect(i)).TupleConcat(end_row.TupleSelect(i))),
                                                   ((begin_col.TupleSelect(i))).TupleConcat(end_col.TupleSelect(i)));
                HOperatorSet.ConcatObj(xldLine1, xldLine2, out xldLine2);
            }
            HOperatorSet.SetLineWidth(HW.Instance().HalconWindow, 2);
            HOperatorSet.DispObj(xldLine2, HW.Instance().HalconWindow);
            return xldLine2;
        }
        public void draw_roi(HTuple hv_WindowHandle, Dictionary<string, HObject> htImg, string ImageName, HTuple hv_drawshape, HTuple Circle, HTuple Rectangle1, HTuple Rectangle2, out HTuple hv_circle,
        out HTuple hv_rectangle1, out HTuple hv_rectangle2)
        {
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.SetDraw(HW.Instance().HalconWindow, Set_draw.margin.ToString());
            // Local control variables 
            HTuple hv_circleRow1 = new HTuple(), hv_circleColumn1 = new HTuple();
            HTuple hv_circleRadius1 = new HTuple(), hv_rec1Row1 = new HTuple();
            HTuple hv_rec1Column1 = new HTuple(), hv_rec1Row2 = new HTuple();
            HTuple hv_rec1Column2 = new HTuple(), hv_rec2Row1 = new HTuple();
            HTuple hv_rec2Column1 = new HTuple(), hv_rec2Phi1 = new HTuple();
            HTuple hv_rec2Length1 = new HTuple(), hv_rec2Length2 = new HTuple();
            // Initialize local and output iconic variables 
            hv_circle = new HTuple();
            hv_rectangle1 = new HTuple();
            hv_rectangle2 = new HTuple();
            if (hv_drawshape == Roi.圆.ToString())
            {
                //修改圆
                //if (Circle.Length > 1)
                //  HOperatorSet.DrawCircleMod(WindowControl.HalconWindow, Circle[0], Circle[1], Circle[2], out hv_circleRow1, out hv_circleColumn1, out hv_circleRadius1);
                //else //画圆
                HOperatorSet.DrawCircle(HW.Instance().HalconWindow, out hv_circleRow1, out hv_circleColumn1, out hv_circleRadius1);
                if (hv_circle == null)
                    hv_circle = new HTuple();
                hv_circle[0] = hv_circleRow1;
                if (hv_circle == null)
                    hv_circle = new HTuple();
                hv_circle[1] = hv_circleColumn1;
                if (hv_circle == null)
                    hv_circle = new HTuple();
                hv_circle[2] = hv_circleRadius1;
                HOperatorSet.ClearWindow(HW.Instance().HalconWindow);
                HOperatorSet.DispObj((HObject)htImg[ImageName], HW.Instance().HalconWindow);
                HOperatorSet.DispCircle(HW.Instance().HalconWindow, hv_circle[0], hv_circle[1], hv_circle[2]);
                HSystem.SetSystem("flush_graphic", "false");
            }
            if (hv_drawshape == Roi.矩形.ToString())
            {
                //画矩形
                // if (Rectangle1.Length>1)
                // HOperatorSet.DrawRectangle1Mod(WindowControl.HalconWindow,Rectangle1[0],Rectangle1[1],Rectangle1[2],Rectangle1[3], out hv_rec1Row1, out hv_rec1Column1,
                //     out hv_rec1Row2, out hv_rec1Column2);
                //  else
                HOperatorSet.DrawRectangle1(HW.Instance().HalconWindow, out hv_rec1Row1, out hv_rec1Column1,
               out hv_rec1Row2, out hv_rec1Column2);

                if (hv_rectangle1 == null)
                    hv_rectangle1 = new HTuple();
                hv_rectangle1[0] = hv_rec1Row1;
                if (hv_rectangle1 == null)
                    hv_rectangle1 = new HTuple();
                hv_rectangle1[1] = hv_rec1Column1;
                if (hv_rectangle1 == null)
                    hv_rectangle1 = new HTuple();
                hv_rectangle1[2] = hv_rec1Row2;
                if (hv_rectangle1 == null)
                    hv_rectangle1 = new HTuple();
                hv_rectangle1[3] = hv_rec1Column2;
                HOperatorSet.ClearWindow(HW.Instance().HalconWindow);
                HOperatorSet.DispObj((HObject)htImg[ImageName], HW.Instance().HalconWindow);
                HOperatorSet.DispRectangle1(HW.Instance().HalconWindow, hv_rectangle1[0], hv_rectangle1[1], hv_rectangle1[2], hv_rectangle1[3]);
                HSystem.SetSystem("flush_graphic", "false");
            }
            if (hv_drawshape == Roi.方向矩形.ToString())
            {
                //修改方向矩形
                //if (Rectangle2>1)
                //HOperatorSet.DrawRectangle2Mod(WindowControl.HalconWindow, Rectangle2[0], Rectangle2[1], Rectangle2[2], Rectangle2[3], Rectangle2[4], out hv_rec2Row1, out hv_rec2Column1,
                //  out hv_rec2Phi1, out hv_rec2Length1, out hv_rec2Length2);
                ////方向矩形
                //else
                HOperatorSet.DrawRectangle2(HW.Instance().HalconWindow, out hv_rec2Row1, out hv_rec2Column1,
                    out hv_rec2Phi1, out hv_rec2Length1, out hv_rec2Length2);

                if (hv_rectangle2 == null)
                    hv_rectangle2 = new HTuple();
                hv_rectangle2[0] = hv_rec2Row1;
                if (hv_rectangle2 == null)
                    hv_rectangle2 = new HTuple();
                hv_rectangle2[1] = hv_rec2Column1;
                if (hv_rectangle2 == null)
                    hv_rectangle2 = new HTuple();
                hv_rectangle2[2] = hv_rec2Phi1;
                if (hv_rectangle2 == null)
                    hv_rectangle2 = new HTuple();
                hv_rectangle2[3] = hv_rec2Length1;
                if (hv_rectangle2 == null)
                    hv_rectangle2 = new HTuple();
                hv_rectangle2[4] = hv_rec2Length2;
                HOperatorSet.ClearWindow(HW.Instance().HalconWindow);

                HOperatorSet.DispObj((HObject)htImg[ImageName], HW.Instance().HalconWindow);
                HOperatorSet.DispRectangle2(HW.Instance().HalconWindow, hv_rectangle2[0], hv_rectangle2[1], hv_rectangle2[2], hv_rectangle2[3], hv_rectangle2[4]);
                HSystem.SetSystem("flush_graphic", "false");
            }
        }
        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="img">图像</param>
        /// <param name="b">是否显示</param>
        /// 
        //public HObject ho_img = null;
        //HTuple width, height;
        //public void DispImage(HObject img, bool b)
        //{
        //    try
        //    {
        //        if (ho_img != null)
        //            ho_img.Dispose();//释放图片内存
        //                             //if (cbxImage.Text !="")
        //                             //{
        //                             //    ho_img = (HObject)Image[cbxImage.Text];
        //                             //    HOperatorSet.GetImageSize(ho_img, out width, out height);
        //                             //}
        //                             //else
        //                             //{
        //        HOperatorSet.CopyImage(img, out ho_img);
        //        HOperatorSet.GetImageSize(img, out width, out height);
        //        //}
        //        if (b)
        //        {
        //            HSystem.SetSystem("flush_graphic", "true");
        //            //hwin1.DispObj(ho_img);
        //            HSystem.SetSystem("flush_graphic", "false");
        //        }
        //    }
        //    catch (HalconException)
        //    {

        //    }
        //}

        //克隆
        public object Clone()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            formatter.Serialize(memStream, this);
            memStream.Position = 0;
            return (formatter.Deserialize(memStream));
        }
    }

    public class SerializeBLL
    {
        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <param name="str_path"></param>
        /// <returns></returns>
        public static object Read(string str_path)
        {
            return SerializeDAL.Read(str_path);
        }
        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="o"></param>
        /// <param name="str_path"></param>
        /// <returns></returns>
        public static bool Write(object o, string str_path)
        {
            return SerializeDAL.Write(o, str_path);
        }
    }
    public class SerializeDAL
    {
        /// <summary>
        /// 序列化所有工具
        /// </summary>
        /// <param name="o">面對對象</param>
        /// <param name="str_path"></param>
        public static bool Write(object o, string str_path)
        {
            try
            {
                using (FileStream fs = new FileStream(str_path, FileMode.Create, FileAccess.Write))//保存数据
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, o);//序列化所有工具
                }
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 反序列化所有工具
        /// </summary>
        /// <param name="str_path"></param>
        /// <returns></returns>
        public static object Read(string str_path)
        {
            try
            {
                //using (FileStream fs = new FileStream(str_path, FileMode.Create, FileAccess.Write))//保存数据
                //{
                //    BinaryFormatter bf = new BinaryFormatter();
                //    bf.Serialize(fs, o);//序列化所有工具
                //}

                using (FileStream fs = new FileStream(str_path, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return bf.Deserialize(fs);//反序列化所有工具
                }
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show("数据读取失败!" + ex.Message);
                return null;
            }
        }
    }
}
