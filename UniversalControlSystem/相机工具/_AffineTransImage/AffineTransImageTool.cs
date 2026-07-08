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
    public class AffineTransImageTool:ImageTool
    {

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
        List<HTuple> hv_HomMat2D1 = new List<HTuple>();
        public List<HTuple> HomMat2D1
        {
            get { return hv_HomMat2D1; }
            set { hv_HomMat2D1 = value; }
        }

        [NonSerialized]
         Dictionary<string, List<HTuple>> htHomMat2D = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> HtHomMat2D
        {
            get { return htHomMat2D; }
            set { htHomMat2D = value; }
        }

         Dictionary<string, List<HTuple>> htHomMat2D1 = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> HtHomMat2D1
        {
            get { return htHomMat2D1; }
            set { htHomMat2D1 = value; }
        }
        [NonSerialized]
         Dictionary<string, List<HTuple>> htPhi = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> HtPhi
        {
            get { return htPhi; }
            set { htPhi = value; }
        }
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
        public string FixNames { get; set; }
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
            Names = Tool.补正图像.ToString();
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
                ResultLogic = true;//结果异常
                HomMat2D = (List<HTuple>)htHomMat2D[FixNames];  //  选择位置定位
                HomMat2D1 = (List<HTuple>)htHomMat2D1[FixNames];  //  选择位置定位
                Phi = (List<HTuple>)HtPhi[FixNames]; //  选择位置定位
                HSystem.SetSystem("flush_graphic", "true");
                if (outImage != null)
                    outImage.Dispose();
                HOperatorSet.AffineTransImage((HObject)ho_Image[ImageName], out outImage, HomMat2D1[0], "constant", "false");
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
                // HOperatorSet.DispObj((HObject)ho_Image[ImageName], WindowControl.HalconWindow);
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
                return 0;
            }
        }
        public override bool toolResult()
        {
            return ResultLogic;
        }
    }
}
