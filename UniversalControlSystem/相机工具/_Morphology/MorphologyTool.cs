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
    public class MorphologyTool : ImageTool
    {
        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName
        { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string RegionName
        { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names
        { get; set; }

        /// <summary>
        /// 轮廓显示
        /// </summary>
        public string Setdraw { get; set; }
        /// <summary>
        /// 区域显示
        /// </summary>
        public bool IsSelectedRegions { get; set; }

        /// <summary>
        /// 形态类型
        /// </summary>
        public string Morphology { get; set; }
        public HTuple Width { get; set; }
        public HTuple Height { get; set; }
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
        public override string toolName()
        {
            return  Names;
        }
        public override long toolTimer()
        {
            return timer; 
        }
        public override void recon()
        { }
        public override void ini()
        {
            Names = Tool.区域形态处理.ToString();
            RegionName = "";
            ImageName = "采集图像0";
            Setdraw = Set_draw.margin.ToString();//轮廓显示
            Morphology = Tool.矩形区域开运算.ToString();
            IsSelectedRegions = false;//blob区域显示
            Width = 1;
            Height = 1;

        }
        public override void draw_roi()
        { }
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
            ResultLogic = true;
            try
            {
                HSystem.SetSystem("flush_graphic", "true");
                if (outRegion != null)
                    outRegion.Dispose();
                //矩形开运算
                if (Morphology == Tool.矩形区域开运算.ToString())
                    HOperatorSet.OpeningRectangle1((HObject)ho_Region[RegionName], out outRegion, Width, Height);
                //矩形闭运算
                if (Morphology == Tool.矩形区域闭运算.ToString())
                    HOperatorSet.ClosingRectangle1((HObject)ho_Region[RegionName], out outRegion, Width, Height);
                //矩形腐蚀
                if (Morphology == Tool.矩形区域腐蚀.ToString())
                    HOperatorSet.ErosionRectangle1((HObject)ho_Region[RegionName], out outRegion, Width, Height);
                //矩形膨胀
                if (Morphology == Tool.矩形区域膨胀.ToString())
                    HOperatorSet.DilationRectangle1((HObject)ho_Region[RegionName], out outRegion, Width, Height);
                //圆开运算
                if (Morphology == Tool.圆区域开运算.ToString())
                    HOperatorSet.OpeningCircle((HObject)ho_Region[RegionName], out outRegion, Width);
                //圆闭运算
                if (Morphology == Tool.圆区域闭运算.ToString())
                    HOperatorSet.ClosingCircle((HObject)ho_Region[RegionName], out outRegion, Width);
                //圆腐蚀
                if (Morphology == Tool.圆区域腐蚀.ToString())
                    HOperatorSet.ErosionCircle((HObject)ho_Region[RegionName], out outRegion, Width);
                //圆膨胀
                if (Morphology == Tool.圆区域膨胀.ToString())
                    HOperatorSet.DilationCircle((HObject)ho_Region[RegionName], out outRegion, Width);
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
        public override void dispresult()
        {
            try
            {
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Setdraw);
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.green.ToString());
                if (IsSelectedRegions)
                    HOperatorSet.DispObj(outRegion, hWindowControl1.HalconWindow);
                HSystem.SetSystem("flush_graphic", "false");
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "显示异常", "image", 10, 10, "red", "false");
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
