using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlyCapture2Managed;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using HalconDotNet;
using System.Drawing.Imaging;
using System.Threading;

namespace VMPro
{
    /// <summary>
    /// 灰点相机
    /// </summary>
    [Serializable]
    internal class SDK_PointGrey : SDK_Base
    {
        internal SDK_PointGrey(string cameraInfoStr)
        {
            this.CameraInfoStr = cameraInfoStr;
        }

        /// <summary>
        /// 资源锁
        /// </summary>
        private object obj = new object();
        /// <summary>
        /// 相机集合   键：相机信息字符串  值：相机对象
        /// </summary>
        private static Dictionary<string, ManagedCamera> D_cameras = new Dictionary<string, ManagedCamera>();
        /// <summary>
        /// 实例对象
        /// </summary>
        private static SDK_PointGrey _instance;
        public static SDK_PointGrey Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SDK_PointGrey(string.Empty);
                return _instance;
            }
        }


        /// <summary>
        /// 枚举相机
        /// </summary>
        /// <returns>是否成功</returns>
        internal override bool EnumCamera()
        {
            try
            {
                ManagedBusManager busMgr = new ManagedBusManager();
                uint cameraNum = busMgr.GetNumOfCameras();

                for (int i = 0; i < cameraNum; i++)
                {
                    ManagedPGRGuid guid = busMgr.GetCameraFromIndex((uint)i);
                    ManagedCamera camera = new ManagedCamera();
                    camera.Connect(guid);
                    EmbeddedImageInfo embeddedInfo = camera.GetEmbeddedImageInfo();
                    if (embeddedInfo.timestamp.available == true)
                        embeddedInfo.timestamp.onOff = true;

                    if (embeddedInfo.exposure.available == true)
                    {
                        embeddedInfo.exposure.onOff = false;
                        embeddedInfo.shutter.onOff = false;
                        embeddedInfo.gain.onOff = false;
                    }
                    camera.SetEmbeddedImageInfo(embeddedInfo);

                    CameraProperty cameraShutter = camera.GetProperty(PropertyType.Shutter);
                    cameraShutter.autoManualMode = false;
                    cameraShutter.absControl = true;

                    CameraProperty cameraGain = camera.GetProperty(PropertyType.Gain);
                    cameraGain.autoManualMode = false;
                    cameraGain.absControl = true;

                    CameraProperty cameraExposure = camera.GetProperty(PropertyType.AutoExposure);
                    cameraExposure.autoManualMode = false;
                    cameraExposure.absControl = true;
                    cameraExposure.absValue = 30;

                    CameraProperty cameraAutoBrightness = camera.GetProperty(PropertyType.Brightness);
                    cameraAutoBrightness.autoManualMode = false;
                    cameraAutoBrightness.absControl = true;

                    //设置采图模式  灰度图或彩色图等
                    VideoMode videoMode = VideoMode.NumberOfVideoModes;
                    FrameRate frameRate = FrameRate.NumberOfFrameRates;
                    camera.GetVideoModeAndFrameRate(ref videoMode, ref frameRate);
                    videoMode = VideoMode.VideoMode1600x1200Y8;

                    camera.SetProperty(cameraShutter);
                    camera.SetProperty(cameraGain);
                    camera.SetProperty(cameraExposure);
                    camera.SetProperty(cameraAutoBrightness);
                    camera.SetVideoModeAndFrameRate(videoMode, frameRate);
                    Thread.Sleep(100);
                    camera.StartCapture();

                    CameraInfo cameraInfo = camera.GetCameraInfo();
                    string adapterName = GetAdapterNameByMacAdd(cameraInfo.macAddress.ToString());        //网卡名
                    string sn = cameraInfo.serialNumber.ToString();                                       //序列号
                    string friendlyName = cameraInfo.modelName;                                           //相机型号
                    string vendorName = cameraInfo.vendorName;                                            //厂商

                    if (vendorName != "PointGrey")     //相应品牌的SDK只允许识别对应品牌的相机，否则采图时会出错
                        continue;

                    string cameraInfoStr = string.Format("{0} | {1} | {2} | {3}", adapterName, vendorName, friendlyName, sn);
                    Machine.UpdateStep(20 + (10 / (int)cameraNum) * (i + 1), string.Format("初始化灰点相机{0} [{1}]", i + 1, cameraInfoStr), true);
                    SDK_PointGrey sdk_PointGrey = new SDK_PointGrey(cameraInfoStr);

                    D_cameras.Add(cameraInfoStr, camera);
                    AcqImageTool.L_SDKCamera.Add(sdk_PointGrey);
                    Frm_FromCamera.Instance.cbx_cameraList.Add(cameraInfoStr);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
                return false;
            }
        }
        /// <summary>
        /// 抓取一张图像
        /// </summary>
        /// <returns>图像</returns>
        internal override HObject GrabOneImage()
        {
            try
            {
                lock (obj)
                {
                    HObject image = null;
                    foreach (KeyValuePair<string, ManagedCamera> item in D_cameras)
                    {
                        if (item.Key == CameraInfoStr)
                        {
                            ManagedImage rawImage = new ManagedImage();
                            item.Value.RetrieveBuffer(rawImage);
                            ManagedImage convertedImage = new ManagedImage();
                            rawImage.Convert(FlyCapture2Managed.PixelFormat.PixelFormatBgr, convertedImage);
                            System.Drawing.Bitmap bitmap = convertedImage.bitmap;

                            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                            BitmapData srcBmpData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                            HOperatorSet.GenImageInterleaved(out image, srcBmpData.Scan0, "bgr", bitmap.Width, bitmap.Height, 0, "byte", 0, 0, 0, 0, -1, 0);
                            bitmap.UnlockBits(srcBmpData);
                            break;
                        }
                    }
                    return image;
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
                return null;
            }
        }
        /// <summary>
        /// 检查相机是否存在，即系统是否识别到此相机
        /// </summary>
        /// <returns>是否存在</returns>
        internal override bool CheckExist()
        {
            foreach (KeyValuePair<string, ManagedCamera> item in D_cameras)
            {
                if (item.Key == CameraInfoStr)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="exposureTime">曝光时间</param>
        internal override void SetExposureTime(double exposureTime)
        {
            try
            {
                foreach (KeyValuePair<string, ManagedCamera> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        CameraProperty cameraExposure = item.Value.GetProperty(PropertyType.AutoExposure);
                        cameraExposure.autoManualMode = false;
                        cameraExposure.absControl = true;
                        cameraExposure.absValue = (float)exposureTime;
                        item.Value.SetProperty(cameraExposure);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 设置增益
        /// </summary>
        /// <param name="gain">增益</param>
        internal override void SetGain(double gain)
        {
            try
            {
                foreach (KeyValuePair<string, ManagedCamera> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        CameraProperty cameraGain = item.Value.GetProperty(PropertyType.Gain);
                        cameraGain.autoManualMode = false;
                        cameraGain.absControl = true;
                        cameraGain.absValue = (float)gain;
                        item.Value.SetProperty(cameraGain);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 设置采集模式
        /// </summary>
        /// <returns>0=连续采集，即异步采集  1=单次采集，即同步采集</returns>
        internal override void SetAcquisitionMode(int mode)
        {
            try
            {
                foreach (KeyValuePair<string, ManagedCamera> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        //待完善

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 关闭所有相机
        /// </summary>
        internal override void CloseAllCamera()
        {
            try
            {
                foreach (KeyValuePair<string, ManagedCamera> item in D_cameras)
                {
                    item.Value.StopCapture();
                    item.Value.Disconnect();
                    item.Value.Dispose();
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }

    }
}
