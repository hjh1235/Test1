using HalconDotNet;
using HOperatorSet_EX;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
     public class ScaleImageTool:ImageTool
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
        public  Dictionary<string,HObject> Image
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
        /// <summary>
        /// 低阀值
        /// </summary>
        public HTuple LowThreshold
        {   get; set;   }
        /// <summary>
        /// 最大面积
        /// </summary>
        public HTuple HigThreshold
        { get; set; }
        public override string toolName()
        { return Names; }
        public override long toolTimer()
        {
            return timer;
        }
        public override void recon()
        {  }
        public override void ini()
        {
            Names = Tool.性线收缩图像.ToString();
            LowThreshold = 1;
            HigThreshold = 150;
        }
        public override void draw_roi()
        { }
        /// <summary>
        /// 运行一次
        /// </summary>
        public override void run()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            toolRun();
           // dispresult();
            watch.Stop();
            timer = watch.ElapsedMilliseconds;
        }
        private void toolRun()
        {
            ResultLogic = true;
            try
            {
                HSystem.SetSystem("flush_graphic", "true");
                if (outImage != null)
                    outImage.Dispose();
                HOperatorSet_Ex.scale_image_range((HObject)ho_Image[ImageName], out outImage,  LowThreshold, HigThreshold);
                //scale_image((HObject)ho_Image[ImageName], out outImage,  HigThreshold,LowThreshold);
                HSystem.SetSystem("flush_graphic", "false");
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
        void scale_image(HObject ho_GrayImage, out HObject ho_ImageScaled, HTuple hv_Gmax,HTuple hv_Gmin)
        {
              // Local iconic variables 
            // Local control variables 
            HTuple hv_val = null, hv_Mult = null, hv_Add = null;
            // Initialize local and output iconic variables 
            //HOperatorSet.GenEmptyObj(out ho_ImageScaled);
            hv_val = hv_Gmax - hv_Gmin;
            hv_Mult = 255.00 / hv_val;
            hv_Add = -(hv_Mult * hv_Gmin);
            //ho_ImageScaled.Dispose();
            HOperatorSet.ScaleImage(ho_GrayImage, out ho_ImageScaled, hv_Mult, hv_Add);
            return;
        }
        public override bool toolResult()
        {
            return ResultLogic;
        }
    }
   
}
