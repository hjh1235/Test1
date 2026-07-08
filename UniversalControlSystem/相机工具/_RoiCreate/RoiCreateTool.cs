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
    public class RoiCreateTool : ImageTool
    {
        [NonSerialized]
        HObject ho_ROI_0;
        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName
        { get; set; }
        /// <summary>
        /// Roi区域名称
        /// </summary>
        public string RegionName
        { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names
        { get; set; }
        public bool ResultLogic { get; set; }
        [NonSerialized]
         Dictionary<string, HObject> ho_Image = new  Dictionary<string, HObject>();
        [NonSerialized]
         Dictionary<string, HObject> ho_Region = new  Dictionary<string, HObject>();
        [NonSerialized]
        HObject outRegion;
        /// <summary>
        /// 输入图像
        /// </summary>
        public  Dictionary<string, HObject> Image
        {
            get { return ho_Image; }
            set { ho_Image = value; }
        }
        /// <summary>
        /// 输入区域
        /// </summary>
        public  Dictionary<string, HObject> Region
        {
            get { return ho_Region; }
            set { ho_Region = value; }
        }
        /// <summary>
        /// 区域输出 
        /// </summary>
        public HObject OutRegion
        {
            get { return outRegion; }
            set { outRegion = value; }
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
        /// 区域显示
        /// </summary>
        public bool IsSelectedRegions { get; set; }
        public override string toolName()
        { return Tool.区域创建.ToString(); }
        public override long toolTimer()
        {
            return timer;
        }
        public override void recon()
        { }
        public override void ini()
        {
            Names = Tool.区域创建.ToString();
            ImageName = "采集图片0";
            hv_circle[0] = 100;//圆形
            hv_circle[1] = 100;//圆形
            hv_circle[2] = 100;//圆形

            hv_rectangle1[0] = 50;//矩形
            hv_rectangle1[1] = 50;//矩形
            hv_rectangle1[2] = 200;//矩形
            hv_rectangle1[3] = 200;//矩形

            hv_rectangle2[0] = 200;//方向矩形
            hv_rectangle2[1] = 200;//方向矩形
            hv_rectangle2[2] = 0;//方向矩形
            hv_rectangle2[3] = 100;//方向矩形
            hv_rectangle2[4] = 100;//方向矩形

            Setdraw = Set_draw.margin.ToString();//轮廓显示
            SetdrawShape = Roi.矩形.ToString(); ;//ROI形状
            IsSelectedRegions = false;//blob区域显示
           }
        public override void draw_roi()
        {
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "绘制ROI,右键确定！", CoordSystem.window.ToString(), 10, 10, ColorFul.black.ToString(), ColorFul.white.ToString());
            HSystem.SetSystem("flush_graphic", "false");
            draw_roi(hWindowControl1.HalconWindow, ho_Image, ImageName, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2, out hv_circle, out hv_rectangle1, out hv_rectangle2);
            set_after();
        }

        void gen_roi()
        {
            if (ho_ROI_0 != null)
                ho_ROI_0.Dispose();
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
            //HObject ho_emptyRegion = null;
            //HOperatorSet.GenEmptyObj(out ho_emptyRegion);
            ResultLogic = true;
            try
            {
                HSystem.SetSystem("flush_graphic", "true");
                if (outRegion != null)
                    outRegion.Dispose();
                if (ho_ROI_0 != null)
                    ho_ROI_0.Dispose();
                gen_roi();
                outRegion = ho_ROI_0;
                //HOperatorSet.Union2(ho_emptyRegion, ho_ROI_0, out outRegion);
                //HSystem.SetSystem("flush_graphic", "false");
                //ho_emptyRegion.Dispose();
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
                //ho_emptyRegion.Dispose();
            }
        }
        public override void dispresult()
        {
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Setdraw);
            HSystem.SetSystem("flush_graphic", "true");
            if (IsSelectedRegions)
                HOperatorSet.DispObj(outRegion, hWindowControl1.HalconWindow);
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
                return watch.ElapsedMilliseconds;
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
                return 0;
            }
        }
        public override bool toolResult()
        {
            return ResultLogic;
        }
    }

}
