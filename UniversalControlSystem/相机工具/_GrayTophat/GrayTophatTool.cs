using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using HOperatorSet_EX;
using System.Collections;
using System.Diagnostics;

namespace UniversalControlSystem
{
    [Serializable]
    public  class GrayTophatTool:ImageTool
    {
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
        public HTuple Width { get; set; }
        public HTuple Height { get; set; }
        /// <summary>
        /// 参数
        /// </summary>
        public HTuple Smax
        { get; set; }
        /// <summary>
        /// 形态类型
        /// </summary>
        public string Morphology { get; set; }

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
            Names = Tool.顶帽处理图像.ToString();
            ImageName = "采集图像0";
            Morphology = Tool.顶帽处理图像.ToString();
            Width = 50;
            Height = 50;
            Smax = 0;
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
            HObject ho_se;
            HOperatorSet.GenEmptyObj(out ho_se);
            ho_se.Dispose();
            try
            {
                HSystem.SetSystem("flush_graphic", "true");
                if (outImage != null)
                    outImage.Dispose();
                HOperatorSet.GenDiscSe(out ho_se, "byte", Width, Height, Smax);
                if (Morphology == Tool.顶帽处理图像.ToString())
                { HOperatorSet.GrayTophat((HObject)ho_Image[ImageName], ho_se, out outImage); }
                else
                { HOperatorSet.GrayBothat((HObject)ho_Image[ImageName], ho_se, out outImage); }
                ho_se.Dispose();
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
        public  override void dispresult()
        {
            HSystem.SetSystem("flush_graphic", "true");
            //HOperatorSet.DispObj(outImage, WindowControl.HalconWindow);
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
                //HOperatorSet.DispObj((HObject)ho_Image[ImageName], WindowControl.HalconWindow);
                HSystem.SetSystem("flush_graphic", "false");
                run();
                dispresult();
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.DispObj(outImage, hWindowControl1.HalconWindow);
                HSystem.SetSystem("flush_graphic", "false");
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
