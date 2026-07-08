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
    public class ProjectiveTransImageTool : ImageTool
    {


         HTuple hv_rows, hv_cols, hv_Qxs,hv_Qys   = new HTuple();
        [NonSerialized]
        HTuple hv_HomMat2D = new HTuple();
        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName
        { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names
        { get; set; }
        public bool ResultLogic { get; set; }
        /// <summary>
        /// 旋转角度
        /// </summary>
        public HTuple RotateAngle { get; set; }

        public HTuple RowsCoord
        {
            get { return hv_rows; }
            set { hv_rows = value; }
        }
        public HTuple ColsCoord
        {
            get { return hv_cols; }
            set { hv_cols = value; }
        }
        public HTuple Qxs
        {
            get { return hv_Qxs; }
            set { hv_Qxs = value; }
        }
        public HTuple Qys
        {
            get { return hv_Qys; }
            set { hv_Qys = value; }
        }
        [NonSerialized]
         Dictionary<string, HObject> ho_Image = new  Dictionary<string, HObject>();
        [NonSerialized]
        HObject outImage;
        /// <summary>
        /// 输入图像
        /// </summary>
        public  Dictionary<string, HObject> Image
        {
            get { return ho_Image; }
            set { ho_Image = value; }
        }
        /// <summary>
        /// 图片
        /// </summary>
        public HObject OutImage
        {
            get { return outImage; }
            set { outImage = value; }
        }

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
            Names = Tool.投影图像.ToString();
        }
        public override void draw_roi()
        {
            HSystem.SetSystem("flush_graphic", "true");
            HObject ho_contOut;
            HTuple hv_weights;
            HOperatorSet.GenEmptyObj(out ho_contOut);
            ho_contOut.Dispose();
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "绘制4个点 左上>左下>右下>右上", CoordSystem.window.ToString(), 10, 10, ColorFul.black.ToString(), "green");
            HOperatorSet.DrawNurbs(out ho_contOut, hWindowControl1.HalconWindow, "ture", "ture", "ture", "ture", 10,out hv_rows,out hv_cols, out hv_weights);
            HSystem.SetSystem("flush_graphic", "false");
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
            //if (false)
            //{
            //    hv_Qxs[0] = hv_cols[0];
            //    hv_Qxs[1] = hv_cols[3];
            //    hv_Qxs[2] = hv_cols[3];
            //    hv_Qxs[3] = hv_cols[0];

            //    hv_Qys[0] = hv_cols[0];
            //    hv_Qys[1] = hv_cols[0];
            //    hv_Qys[2] = hv_cols[3];
            //    hv_Qys[3] = hv_cols[3];
            //}

            ResultLogic = true;
            try
            {
                HSystem.SetSystem("flush_graphic", "true");
                if (outImage != null)
                    outImage.Dispose();

                HOperatorSet.HomVectorToProjHomMat2d(hv_rows, hv_cols, ((
          (new HTuple(1)).TupleConcat(1)).TupleConcat(1)).TupleConcat(1), ((((((hv_cols.TupleSelect(
          0))).TupleConcat(hv_cols.TupleSelect(3)))).TupleConcat(hv_cols.TupleSelect(
          3)))).TupleConcat(hv_cols.TupleSelect(0)), ((((((hv_cols.TupleSelect(0))).TupleConcat(
          hv_cols.TupleSelect(0)))).TupleConcat(hv_cols.TupleSelect(3)))).TupleConcat(
          hv_cols.TupleSelect(3)), (((new HTuple(1)).TupleConcat(1)).TupleConcat(
          1)).TupleConcat(1), "normalized_dlt", out hv_HomMat2D);
                HOperatorSet.ProjectiveTransImage((HObject)ho_Image[ImageName], out outImage, hv_HomMat2D, "bilinear", "false", "false");
                HSystem.SetSystem("flush_graphic", "false");
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
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DispObj(outImage, hWindowControl1.HalconWindow);
            HSystem.SetSystem("flush_graphic", "false");
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

    }
}
