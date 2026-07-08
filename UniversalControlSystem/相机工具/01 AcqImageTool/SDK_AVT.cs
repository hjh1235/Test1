using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using AVT.VmbAPINET;
using HalconDotNet;
using MvCamCtrl.NET;
using AVT.VmbAPINET.Examples;

namespace VMPro
{
    /// <summary>
    /// AVT相机
    /// </summary>
    [Serializable]
    internal class SDK_AVT : SDK_Base
    {
        internal SDK_AVT(string cameraInfoStr)
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
        private static Dictionary<string, Camera> D_cameras = new Dictionary<string, Camera>();
        /// <summary>
        /// 实例对象
        /// </summary>
        private static SDK_AVT _instance;
        public static SDK_AVT Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SDK_AVT(string.Empty);
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
                Vimba sys = new Vimba();
                CameraCollection cameras = null;
                sys.Startup();
                cameras = sys.Cameras;

                for (int i = 0; i < cameras.Count; i++)
                {
                    string adapterName = string.Empty;      //待完善
                    string sn = cameras[i].SerialNumber;
                    string friendlyName = cameras[i].Model;
                    string vendorName = "Allied";

                    if (vendorName != "Allied")     //相应品牌的SDK只允许识别对应品牌的相机，否则采图时会出错
                        continue;

                    string cameraInfoStr = string.Format("{0} | {1} | {2} | {3}", adapterName, vendorName, friendlyName, sn);

                    try
                    {
                        cameras[i].Open(VmbAccessModeType.VmbAccessModeFull);
                    }
                    catch
                    {
                        Frm_MessageBox.Instance.MessageBoxShow(string.Format("\r\n相机{0}初始化失败,相机信息：{1}\r\n可能是其它程序已经占用了此相机所导致", i + 1, cameraInfoStr), TipType.Error);
                        continue;
                    }

                    try
                    {
                        FeatureCollection features = null;
                        Feature feature = null;
                        features = cameras[i].Features;
                        feature = features["Width"];
                        feature.IntValue = 4112;
                        feature = features["Height"];
                        feature.IntValue = 2176;
                    }
                    catch { }

                    Machine.UpdateStep(20 + (10 / (int)cameras.Count) * (i + 1), string.Format("初始化AVT相机{0} [{1}]", i + 1, cameraInfoStr), true);
                    SDK_AVT sdk_AVT = new SDK_AVT(cameraInfoStr);

                    D_cameras.Add(cameraInfoStr, cameras[i]);
                    AcqImageTool.L_SDKCamera.Add(sdk_AVT);
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
                    foreach (KeyValuePair<string, Camera> item in D_cameras)
                    {
                        if (item.Key == CameraInfoStr)
                        {
                            try
                            {
                                item.Value.Features["GVSPAdjustPacketSize"].RunCommand();
                                while (false == item.Value.Features["GVSPAdjustPacketSize"].IsCommandDone()) { }
                            }
                            catch { }

                            Frame frame = null;
                            try
                            {
                                AdjustPixelFormat(item.Value);
                                item.Value.AcquireSingleImage(ref frame, 3000);
                            }
                            catch { }

                            image = ConvertFrame(frame);
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
            foreach (KeyValuePair<string, Camera> item in D_cameras)
            {
                if (item.Key == CameraInfoStr)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="exposure">曝光时间</param>
        internal override void SetExposureTime(double exposureTime)
        {
            try
            {
                foreach (KeyValuePair<string, Camera> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        FeatureCollection features = null;
                        Feature feature = null;
                        features = item.Value.Features;
                        feature = features["ExposureTimeAbs"];
                        feature.FloatValue = exposureTime * 1000;
                        break;
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
                foreach (KeyValuePair<string, Camera> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        FeatureCollection features = null;
                        Feature feature = null;
                        features = item.Value.Features;
                        feature = features["Gain"];
                        feature.FloatValue = gain;
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
        }
        /// <summary>
        /// 设置采集模式
        /// </summary>
        /// <param name="mode">0=连续采集，即异步采集  1=单次采集，即同步采集</param>
        internal override void SetAcquisitionMode(int mode)
        {
            try
            {
                foreach (KeyValuePair<string, Camera> item in D_cameras)
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
                foreach (KeyValuePair<string, Camera> item in D_cameras)
                {
                    item.Value.Close();
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// Adjust pixel format of given camera to match one that can be displayed
        ///  in this example.
        /// </summary>
        /// <param name="camera">Our camera</param>
        private void AdjustPixelFormat(Camera camera)
        {
            try
            {
                if (null == camera)
                {
                    throw new ArgumentNullException("camera");
                }

                string[] supportedPixelFormats = new string[] { "BGR8Packed", "Mono8" };
                //Check for compatible pixel format
                Feature pixelFormatFeature = camera.Features["PixelFormat"];

                //Determine current pixel format
                string currentPixelFormat = pixelFormatFeature.EnumValue;

                //Check if current pixel format is supported
                bool currentPixelFormatSupported = false;
                foreach (string supportedPixelFormat in supportedPixelFormats)
                {
                    if (string.Compare(currentPixelFormat, supportedPixelFormat, StringComparison.Ordinal) == 0)
                    {
                        currentPixelFormatSupported = true;
                        break;
                    }
                }

                //Only adjust pixel format if we not already have a compatible one.
                if (false == currentPixelFormatSupported)
                {
                    //Determine available pixel formats
                    string[] availablePixelFormats = pixelFormatFeature.EnumValues;

                    //Check if there is a supported pixel format
                    bool pixelFormatSet = false;
                    foreach (string supportedPixelFormat in supportedPixelFormats)
                    {
                        foreach (string availablePixelFormat in availablePixelFormats)
                        {
                            if ((string.Compare(supportedPixelFormat, availablePixelFormat, StringComparison.Ordinal) == 0)
                                && (pixelFormatFeature.IsEnumValueAvailable(supportedPixelFormat) == true))
                            {
                                //Set the found pixel format
                                pixelFormatFeature.EnumValue = supportedPixelFormat;
                                pixelFormatSet = true;
                                break;
                            }
                        }

                        if (true == pixelFormatSet)
                        {
                            break;
                        }
                    }

                    if (false == pixelFormatSet)
                    {
                        throw new Exception("None of the pixel formats that are supported by this example (Mono8 and BRG8Packed) can be set in the camera.");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// Converts a frame to displayable image
        /// </summary>
        /// <param name="frame">The frame to be converted</param>
        /// <returns>An .NET Image constructed out of the Vimba frame</returns>
        private static HObject ConvertFrame(Frame frame)
        {
            try
            {
                if (null == frame)
                {
                    throw new ArgumentNullException("frame");
                }

                //Check if the image is valid
                if (VmbFrameStatusType.VmbFrameStatusComplete != frame.ReceiveStatus)
                {
                    throw new Exception("Invalid frame received. Reason: " + frame.ReceiveStatus.ToString());
                }

                //Convert raw frame data into image (for image display)
                Bitmap image = null;
                switch (frame.PixelFormat)
                {
                    case VmbPixelFormatType.VmbPixelFormatMono8:
                        {
                            Bitmap bitmap = new Bitmap((int)frame.Width, (int)frame.Height, PixelFormat.Format8bppIndexed);

                            //Set greyscale palette
                            ColorPalette palette = bitmap.Palette;
                            for (int i = 0; i < palette.Entries.Length; i++)
                            {
                                palette.Entries[i] = Color.FromArgb(i, i, i);
                            }
                            bitmap.Palette = palette;

                            //Copy image data
                            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0,
                                                                                        0,
                                                                                        (int)frame.Width,
                                                                                        (int)frame.Height),
                                                                        ImageLockMode.WriteOnly,
                                                                        PixelFormat.Format8bppIndexed);
                            try
                            {
                                //Copy image data line by line
                                for (int y = 0; y < (int)frame.Height; y++)
                                {
                                    System.Runtime.InteropServices.Marshal.Copy(frame.Buffer,
                                                                                    y * (int)frame.Width,
                                                                                    new IntPtr(bitmapData.Scan0.ToInt64() + y * bitmapData.Stride),
                                                                                    (int)frame.Width);
                                }
                            }
                            finally
                            {
                                bitmap.UnlockBits(bitmapData);
                            }

                            image = bitmap;
                        }
                        break;

                    case VmbPixelFormatType.VmbPixelFormatBgr8:
                        {
                            Bitmap bitmap = new Bitmap((int)frame.Width, (int)frame.Height, PixelFormat.Format24bppRgb);

                            //Copy image data
                            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0,
                                                                                        0,
                                                                                        (int)frame.Width,
                                                                                        (int)frame.Height),
                                                                        ImageLockMode.WriteOnly,
                                                                        PixelFormat.Format24bppRgb);
                            try
                            {
                                //Copy image data line by line
                                for (int y = 0; y < (int)frame.Height; y++)
                                {
                                    System.Runtime.InteropServices.Marshal.Copy(frame.Buffer,
                                                                                    y * ((int)frame.Width) * 3,
                                                                                    new IntPtr(bitmapData.Scan0.ToInt64() + y * bitmapData.Stride),
                                                                                    ((int)(frame.Width) * 3));
                                }
                            }
                            finally
                            {
                                bitmap.UnlockBits(bitmapData);
                            }

                            image = bitmap;
                        }
                        break;

                    default:
                        throw new Exception("Current pixel format is not supported by this example (only Mono8 and BRG8Packed are supported).");
                }

                HObject image111 = null;

                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
                BitmapData srcBmpData = image.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                HOperatorSet.GenImageInterleaved(out image111, srcBmpData.Scan0, "bgr", image.Width, image.Height, 0, "byte", 0, 0, 0, 0, -1, 0);
                image.UnlockBits(srcBmpData);

                return image111;
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
                return null;
            }
        }

    }
}
