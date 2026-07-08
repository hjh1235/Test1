using HalconDotNet;
using HOperatorSet_EX;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    [Serializable]
    public class AcqFifoTool : ImageTool
    {
        //public delegate void GrapImageDelegate(object sender, EventArgsDAL e);//采集图像委托
        //public event GrapImageDelegate GrapImageEvent;//采集图像事件
        [NonSerialized]
        EventArgsDAL _EventArgs = new EventArgsDAL();
        [NonSerialized]
        CameraDAL camera /*= new CameraDAL()*/;
        [NonSerialized]
        int imageIndex = 0;//循环本地索引
        [NonSerialized]
        HObject outImage = null;
        [NonSerialized]
        HTuple hv_acqHandle;
        [NonSerialized]
        bool isFrameRate;
        #region 序列化参数
    
        string name, cameraInterface, device/*, imgPath*/;
   
        bool isUseImg, isUseLoopImg;

        public HTuple ExposureTime { get; set; }

        public HTuple Gain { get; set; }
        public bool IsGrabAsync { get; set; }


        public bool ResultLogic { get; set; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroup { set; get; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        /// 
        public string DataGroupName { set; get; }
       //采集状态
        public string sta { set; get; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 图片
        /// </summary>
        public HObject OutImage
        {
            get { return outImage; }
            set { outImage = value; }
        }
        public HTuple AcqHandle
        {
            get { return hv_acqHandle; }
            set { hv_acqHandle = value; }
        }
        /// <summary>
        /// 相机设备
        /// </summary>
        public string Device
        {
            get { return device; }
            set { device = value; }
        }
        /// <summary>
        /// 相机接口
        /// </summary>
        public string CameraInterface
        {
            get { return cameraInterface; }
            set { cameraInterface = value; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImgPath { get; set; }//

        /// <summary>
        /// 图片循环
        /// </summary>
        public bool IsUseLoopImg
        {
            get { return isUseLoopImg; }
            set { isUseLoopImg = value; }
        }
        /// <summary>
        /// 使用本地图片
        /// </summary>
        public bool IsUseImg
        {
            get { return isUseImg; }
            set { isUseImg = value; }
        }
        #endregion
        private void OnGrapImageEvent(EventArgsDAL e)
        {   
            //定义一个局部变量，将事件对象赋值给该变量，防止多线程情况取消事件
            //GrapImageDelegate mEvent = this.GrapImageEvent;
            //if (mEvent != null)
            //{
            //    mEvent(this, e);//事件触发
            //}
        }
        public override void recon()//读取参数
        {
            EventArgsDAL _EventArgs = new EventArgsDAL();
            CameraDAL camera = new CameraDAL();
            this._EventArgs = _EventArgs;
            this.camera = camera;
            camera.GrapImageEvent += this.camera_GrapImageEvent;//注册采集相机采集图片事件
            camera.OpenDeviceEvent += this.camera_OpenDeviceEvent;
            this.camera.GrapImageEvent += this.camera_GrapImageEvent;//注册采集相机采集图片事件
            this.camera.OpenDeviceEvent += this.camera_OpenDeviceEvent;
        }
        public AcqFifoTool()
        {
            recon();

            camera.GrapImageEvent += this.camera_GrapImageEvent;//注册采集相机采集图片事件
            camera.OpenDeviceEvent += this.camera_OpenDeviceEvent;
        }
        void camera_OpenDeviceEvent(object sender, EventArgsDAL e)
        {
            try
            { hv_acqHandle = e.AcqHandle; }
            catch
            { MessageBox.Show("打开相机异常！"); }
        }
        void camera_GrapImageEvent(object sender, EventArgsDAL e)
        {
            try
            {
                ResultLogic = true;
                if (outImage != null)
                    outImage.Dispose();//释放图片,防止内存溢出;
                hv_acqHandle = e.AcqHandle;
                HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.CopyImage(e.Image, out outImage);
                HOperatorSet.DispObj(outImage, hWindowControl1.HalconWindow);
                if (isFrameRate)
                {
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "Frame Rate: " + e.FrameRate.TupleString("3.02f") + " fps", "image", 24, 12, ColorFul.black.ToString(), ColorFul.green.ToString());
                }
                _EventArgs.Image = outImage;
                _EventArgs.AcqHandle = e.AcqHandle;
                _EventArgs.FrameRate = e.FrameRate;
                OnGrapImageEvent(_EventArgs);
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
        public void _ExposureTime()
        {
           // camera.ExposureTime = ExposureTime;
        }
        /// <summary>
        /// 打开相机
        /// </summary>
        public bool OpenCamera()
        {
            camera.IsGrabAsync = this.IsGrabAsync;
            camera.ExposureTime = ExposureTime;
            
            //CameraDAL.Instance().IsGrabAsync = this.IsGrabAsync;
            //CameraDAL.Instance().ExposureTime = ExposureTime;
            return CameraDAL.Instance().OpenCamera(cameraInterface, device);
        }
        /// <summary>
        /// 关闭相机
        /// </summary>
        public void CloseCamera()
        {
            try
            {
                camera.CameraInterface = cameraInterface;
                camera.Device = device;
                camera.CloseCamera();
                //CameraDAL.Instance().CameraInterface = cameraInterface;
                //CameraDAL.Instance().Device = device;
                //CameraDAL.Instance().CloseCamera();

            }
            catch (Exception es )
            {

               
            }
    
        }
        /// <summary>
        /// 运行一次
        /// </summary>
        public void OnceRun()
        {
            camera.IsGrabAsync = this.IsGrabAsync;
            camera.ExposureTime = ExposureTime;
            camera.CameraInterface = cameraInterface;
            camera.Device = device;
            camera.OnceRun();//采集一次;
            //CameraDAL.Instance().IsGrabAsync = this.IsGrabAsync;
            //CameraDAL.Instance().ExposureTime = ExposureTime;
            //CameraDAL.Instance().CameraInterface = cameraInterface;
            //CameraDAL.Instance().Device = device;
            //CameraDAL.Instance().OnceRun();//采集一次;
            isFrameRate = false;
        }
        /// <summary>
        /// 时时运行
        /// </summary>
        public void Run()
        {
            camera.IsGrabAsync = this.IsGrabAsync;
            camera.ExposureTime = ExposureTime;
            camera.CameraInterface = cameraInterface;
            camera.Device = device;
            camera.Run();
            //CameraDAL.Instance().IsGrabAsync = this.IsGrabAsync;
            //CameraDAL.Instance().ExposureTime = ExposureTime;
            //CameraDAL.Instance().CameraInterface = cameraInterface;
            //CameraDAL.Instance().Device = device;
            //CameraDAL.Instance().Run();
            isFrameRate = true;
        }
        /// <summary>
        /// 工具名
        /// </summary>
        /// <returns></returns>
        public override string toolName()
        {
            return name;
        }
        public override long toolTimer()
        {
            return timer;
        }
        public override void ini()
        {
            name = Tool.采集图像.ToString();
            isUseLoopImg = false;
            IsUseImg = false;
            ExposureTime = 35000;
            Gain = 0;
            IsGrabAsync = false;
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
            ResultLogic = true;
            if (outImage != null)
                outImage.Dispose();
            if (!isUseImg)//不使用本地图片
            {
                camera.ExposureTime = ExposureTime;
                camera.CameraInterface = cameraInterface;
                camera.Device = device;
                camera.AcqHandle = this.AcqHandle;
                camera.OnceRun();//采集一次;
                //CameraDAL.Instance().ExposureTime = ExposureTime;
                //CameraDAL.Instance().CameraInterface = cameraInterface;
                //CameraDAL.Instance().Device = device;
                //CameraDAL.Instance().AcqHandle = this.AcqHandle;
                //CameraDAL.Instance().OnceRun();//采集一次;
            }
            else
            {
                if (isUseLoopImg)//循环读取本地图片
                {
                    readImg();
                }
                else
                {
                    int Debug = ImgPath.LastIndexOf("Debug");//是否是debug下的文件
                    if (Debug != -1)
                    {
                        string bugPath = ImgPath.Substring(Debug + 5, ImgPath.Length - (Debug + 5));//截取Debug下的文件,例如 原路径 C://Debug//1
                        string NewImagePath = Application.StartupPath + bugPath;//复制到不同的文件夹,复制到D盘,替换新的路径,例如 d://Debug//1
                        ImgPath = NewImagePath;
                    }
                    HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
                    HOperatorSet.ReadImage(out outImage, ImgPath);
                    HSystem.SetSystem("flush_graphic", "true");
                    HOperatorSet.DispObj(outImage, hWindowControl1.HalconWindow);
                    HSystem.SetSystem("flush_graphic", "false");
                }
            }
        }
        public override long set_after()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            run();
            watch.Stop();
            timer = watch.ElapsedMilliseconds;
            return watch.ElapsedMilliseconds;
        }
        public override bool toolResult()
        {
            return ResultLogic;
        }
        public string[] readImg()
        {
            ResultLogic = true;
            List<string> imgPaths = new List<string>();
            if (ImgPath == null)
            {
                MessageBox.Show("图片路径不存在");
                return null;
            }
            int Debug = ImgPath.LastIndexOf("Debug");//是否是debug下的文件
            if (Debug != -1)
            {
                try
                {
                    string bugPath = ImgPath.Substring(Debug + 5, ImgPath.Length - (Debug + 5));//截取Debug下的文件,例如 原路径 C://Debug//1
                    string NewImagePath = Application.StartupPath + bugPath;//复制到不同的文件夹,复制到D盘,替换新的路径,例如 d://Debug//1
                    int Index = NewImagePath.LastIndexOf("\\");

                    string tempImgPath = NewImagePath.Substring(0, Index);
                    string imgtype = "*.BMP|*.JPG|*.JP2|*.GIF|*.PNG|*.TIF";
                    if (System.IO.Directory.Exists(tempImgPath))
                    {
                        string[] ImageType = imgtype.Split('|');
                        for (int i = 0; i < ImageType.Length; i++)
                        {
                            foreach (string s in System.IO.Directory.GetFiles(tempImgPath, ImageType[i]))
                            {
                                imgPaths.Add(s);//把图片路径添加到列表中
                            }
                        }
                    }
                    if (imageIndex > imgPaths.Count - 1)//是否是最后一张
                        imageIndex = 0;  //第一张
                }
                catch (Exception ex)
                {
                    ResultLogic = false;
                    MessageBox.Show("图片路径不存在,读取图像异常！");
                    return null;
                }
            }
            else
            {
                try
                {
                    int Index = ImgPath.LastIndexOf("\\");
                    string tempImgPath = ImgPath.Substring(0, Index);
                    string imgtype = "*.BMP|*.JPG|*.JP2|*.GIF|*.PNG|*.TIF";
                    if (System.IO.Directory.Exists(tempImgPath))
                    {
                        string[] ImageType = imgtype.Split('|');
                        for (int i = 0; i < ImageType.Length; i++)
                        {
                            foreach (string s in System.IO.Directory.GetFiles(tempImgPath, ImageType[i]))
                            {
                                imgPaths.Add(s);     //把图片路径添加到列表中
                            }
                        }
                    }
                    if (imageIndex > imgPaths.Count - 1)
                        imageIndex = 0;  //第一张
                }
                catch (Exception ex)
                {
                    ResultLogic = false;
                    MessageBox.Show("图片路径不存在,读取图像异常！");
                    return null;
                }
            }
            if (outImage != null)
                outImage.Dispose();
            HOperatorSet.ReadImage(out outImage, imgPaths[imageIndex]);
            HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DispObj(outImage, hWindowControl1.HalconWindow);
            HSystem.SetSystem("flush_graphic", "false");
            imageIndex++;
            return imgPaths.ToArray();
        }

    }
}
