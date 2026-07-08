using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using System.Collections;
using System.Diagnostics;
using HOperatorSet_EX;

namespace UniversalControlSystem
{  
    [Serializable]
    public class ImageConvertTool:ImageTool
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
        public string ColorSpace
        { get; set; }
        public string SelectConvertImg
        { get; set; }
       
        public bool ResultLogic { get; set; }
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
        [NonSerialized]
        HObject redChanne1, greenChanne2, blueChanne3, imageHue, imageSaturation, imageIntensity, imageGray;
        public HObject OutImageGray
        {
            get { return imageGray; }
            set { imageGray = value; }
        }
        /// <summary>
        /// R
        /// </summary>
        public HObject OutImageChanne1
        {   
            get { return redChanne1; }
            set { redChanne1 = value; }
        }
        /// <summary>
        /// G
        /// </summary>
        public HObject OutImageChanne2
        {
            get { return greenChanne2; }
            set { greenChanne2 = value; }
        }
        /// <summary>
        /// B
        /// </summary>
        public HObject OutImageChanne3
        {
            get { return blueChanne3; }
            set { blueChanne3 = value; }
        }

        /// <summary>
        /// 颜色空间
        /// </summary>
        public HObject OutImageHue
        {
            get { return imageHue; }
            set { imageHue = value; }
        }

        /// <summary>
        /// 饱和度
        /// </summary>
        public HObject OutImageSaturation
        {
            get { return imageSaturation; }
            set { imageSaturation = value; }
        }
        /// <summary>
        /// 亮度
        /// </summary>
        public HObject OutImageIntensity
        {
            get { return imageIntensity; }
            set { imageIntensity = value; }
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
            Names = Tool.彩色转HSV图像.ToString();
            SelectConvertImg = transImage.灰度图.ToString();
            ColorSpace = "hsv";
            ResultLogic = true;//结果异常
        }
        public enum transImage
        {
             灰度图=0,
             R通道=1,
             G通道 = 2,
             B通道 =3,
             H分量图 = 4,
             S分量图 = 5,
             V分量图 = 6,
             原图=7
             
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
            dispresult();
            watch.Stop();
            timer = watch.ElapsedMilliseconds;
        }
        private void toolRun()
        {
            try
            {
                if (redChanne1 != null)
                    redChanne1.Dispose();
                if (greenChanne2 != null)
                    greenChanne2.Dispose();
                if (blueChanne3 != null)
                    blueChanne3.Dispose();
                if (imageHue != null)
                    imageHue.Dispose();
                if (imageSaturation != null)
                    imageSaturation.Dispose();
                if (imageIntensity != null)
                    imageIntensity.Dispose();
                if (imageGray != null)
                    imageGray.Dispose();

                // Task task1 = Task.Factory.StartNew(() =>
                //{
                //    Rgb1ToGray();
                //});
                //Task task2 = Task.Factory.StartNew(() =>
                //{
                //    Decompose3();
                //});
                // Task.WaitAll(task1);
                ResultLogic = true;//结果异常
                if (this.TransImage == transImage.灰度图.ToString())
                    HOperatorSet.Rgb1ToGray((HObject)ho_Image[ImageName], out imageGray);
                else
                {
                    if (this.TransImage == transImage.原图.ToString())
                    {
                    }
                    else
                    {
                        if (this.TransImage == transImage.R通道.ToString() || this.TransImage == transImage.G通道.ToString() || this.TransImage == transImage.B通道.ToString())
                            HOperatorSet.Decompose3((HObject)ho_Image[ImageName], out redChanne1, out greenChanne2, out blueChanne3);
                        else
                        {
                            HOperatorSet.Decompose3((HObject)ho_Image[ImageName], out redChanne1, out greenChanne2, out blueChanne3);
                            HOperatorSet.TransToRgb(redChanne1, greenChanne2, blueChanne3, out imageHue, out imageSaturation, out imageIntensity, ColorSpace);
                        }
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

        void Rgb1ToGray()
        {
            HOperatorSet.Rgb1ToGray((HObject)ho_Image[ImageName], out imageGray);
        }
        void Decompose3()
        {
            HOperatorSet.Decompose3((HObject)ho_Image[ImageName], out redChanne1, out greenChanne2, out blueChanne3);
            HOperatorSet.TransToRgb(redChanne1, greenChanne2, blueChanne3, out imageHue, out imageSaturation, out imageIntensity, ColorSpace);
        }
       
        public string TransImage { get; set; }
        public override void dispresult()
        {
            HSystem.SetSystem("flush_graphic", "true");
            if (this.TransImage == transImage.灰度图.ToString())
                HOperatorSet.DispObj(imageGray, hWindowControl1.HalconWindow);
            if (this.TransImage == transImage.R通道.ToString())
                HOperatorSet.DispObj(redChanne1, hWindowControl1.HalconWindow);
            if (this.TransImage == transImage.G通道.ToString())
                HOperatorSet.DispObj(greenChanne2, hWindowControl1.HalconWindow);
            if (this.TransImage == transImage.B通道.ToString())
                HOperatorSet.DispObj(blueChanne3, hWindowControl1.HalconWindow);
            if (this.TransImage == transImage.H分量图.ToString())
                HOperatorSet.DispObj(imageHue, hWindowControl1.HalconWindow);
            if (this.TransImage == transImage.V分量图.ToString())
                HOperatorSet.DispObj(imageSaturation, hWindowControl1.HalconWindow);
            if (this.TransImage == transImage.S分量图.ToString())
                HOperatorSet.DispObj(imageIntensity, hWindowControl1.HalconWindow);
            if (this.TransImage == transImage.原图.ToString())
                HOperatorSet.DispObj((HObject)ho_Image[ImageName], hWindowControl1.HalconWindow);
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
