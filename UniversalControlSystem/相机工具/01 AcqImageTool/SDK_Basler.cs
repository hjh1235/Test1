using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows;
using System.Threading;
using System.Drawing;
using Basler.Pylon;
using HalconDotNet;

namespace VMPro
{
    /// <summary>
    /// 巴斯勒相机
    /// </summary>
    [Serializable]
    internal class SDK_Basler : SDK_Base
    {
        internal SDK_Basler(string cameraInfoStr)
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
        private static Dictionary<string, Basler.Pylon.Camera> D_cameras = new Dictionary<string, Camera>();
        /// <summary>
        /// 相机列表
        /// </summary>
        private static List<ICameraInfo> L_cameraInfo;
        /// <summary>
        /// 实例对象
        /// </summary>
        private static SDK_Basler _instance;
        public static SDK_Basler Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SDK_Basler(string.Empty);
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
                L_cameraInfo = CameraFinder.Enumerate();
                int camIndex = 0;
                foreach (ICameraInfo item in L_cameraInfo)
                {
                    camIndex++;
                    string adapterName = GetAdapterNameByMacAdd(item[CameraInfoKey.DeviceMacAddress]);
                    string sn = item[CameraInfoKey.SerialNumber];
                    string friendlyName = item[CameraInfoKey.FriendlyName];
                    string vendorName = item[CameraInfoKey.VendorName];

                    if (vendorName != "Basler")     //相应品牌的SDK只允许识别对应品牌的相机，否则采图时会出错
                        continue;

                    Basler.Pylon.Camera camera = new Basler.Pylon.Camera(item);
                    {
                        camera.CameraOpened += Basler.Pylon.Configuration.AcquireSingleFrame;
                        try
                        {
                            camera.Open();
                        }
                        catch
                        {
                            Frm_MessageBox.Instance.MessageBoxShow(string.Format("\r\n相机{0}初始化失败,相机信息：{1}\r\n可尝试重启电脑或5分钟后重启程序解决此问题", camIndex, friendlyName), TipType.Error);
                            continue;
                        }

                        camera.Parameters[PLCameraInstance.MaxNumBuffer].SetValue(5);
                        camera.Parameters[PLCamera.PixelFormat].SetValue(PLCamera.PixelFormat.Mono8);

                        string cameraInfoStr = string.Format("{0} | {1} | {2} | {3}", adapterName, vendorName, friendlyName, sn);
                        Machine.UpdateStep(20 + (10 / (int)L_cameraInfo.Count) * (camIndex), string.Format("初始化迈德威视相机{0} [{1}]", camIndex, cameraInfoStr), true);
                        SDK_Basler sdk_Basler = new SDK_Basler(cameraInfoStr);

                        D_cameras.Add(cameraInfoStr, camera);
                        AcqImageTool.L_SDKCamera.Add(sdk_Basler);
                        Frm_FromCamera.Instance.cbx_cameraList.Add(cameraInfoStr);
                    }
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
                    foreach (KeyValuePair<string, Basler.Pylon.Camera> item in D_cameras)
                    {
                        if (item.Key == CameraInfoStr)
                        {
                            IGrabResult grabResult;
                            try
                            {
                                grabResult = item.Value.StreamGrabber.GrabOne(5000, TimeoutHandling.ThrowException);
                            }
                            catch
                            {
                                Frm_MessageBox.Instance.MessageBoxShow("\r\n    采图异常，相机：" + CameraInfoStr, TipType.Error);
                                break;
                            }
                            using (grabResult)
                            {
                                if (grabResult.GrabSucceeded)
                                {
                                    byte[] buffer = grabResult.PixelData as byte[];
                                    GCHandle hand = GCHandle.Alloc(buffer, GCHandleType.Pinned);
                                    IntPtr pr = hand.AddrOfPinnedObject();
                                    HOperatorSet.GenImage1(out image, new HTuple("byte"), grabResult.Width, grabResult.Height, pr);
                                    if (hand.IsAllocated)
                                        hand.Free();
                                    break;
                                }
                            }
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
            foreach (KeyValuePair<string, Basler.Pylon.Camera> item in D_cameras)
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
                foreach (KeyValuePair<string, Basler.Pylon.Camera> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        if (item.Value.Parameters.Contains(PLCamera.ExposureTimeAbs))
                            item.Value.Parameters[PLCamera.ExposureTimeAbs].TrySetValue(exposureTime * 1000);
                        else
                            item.Value.Parameters[PLCamera.ExposureTime].TrySetValue(exposureTime * 1000);
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
                foreach (KeyValuePair<string, Basler.Pylon.Camera> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        if (item.Value.Parameters.Contains(PLCamera.ExposureTimeAbs))
                            item.Value.Parameters[PLCamera.GainAbs].TrySetValue(gain);
                        else
                            item.Value.Parameters[PLCamera.Gain].TrySetValue(gain);
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
        /// <param name="mode">0=连续采集，即异步采集  1=单次采集，即同步采集</param>
        internal override void SetAcquisitionMode(int mode)
        {
            try
            {
                foreach (KeyValuePair<string, Basler.Pylon.Camera> item in D_cameras)
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
        public static void CloseAllCamera()
        {
            try
            {
                foreach (KeyValuePair<string, Basler.Pylon.Camera> item in D_cameras)
                {
                    item.Value.Close();
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
