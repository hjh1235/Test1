using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using HalconDotNet;
using MvCamCtrl.NET;

namespace VMPro
{
    /// <summary>
    /// 海康威视相机
    /// </summary>
    [Serializable]
    internal class SDK_HIKVision : SDK_Base
    {
        internal SDK_HIKVision(string cameraInfoStr)
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
        private static Dictionary<string, MyCamera> D_cameras = new Dictionary<string, MyCamera>();
        /// <summary>
        /// 实例对象
        /// </summary>
        private static SDK_HIKVision _instance;
        public static SDK_HIKVision Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SDK_HIKVision(string.Empty);
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
                try
                {
                    uint temp = MyCamera.MV_CC_GetSDKVersion_NET();     //用于试探是否安装了海康威视相机SDK
                }
                catch
                {
                    return false;
                }

                int nRet = MyCamera.MV_OK;
                MyCamera myCamera = new MyCamera();
                MyCamera.MV_CC_DEVICE_INFO_LIST stDevList = new MyCamera.MV_CC_DEVICE_INFO_LIST();
                nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref stDevList);

                if (MyCamera.MV_OK == nRet)
                {
                    MyCamera.MV_CC_DEVICE_INFO stDevInfo;
                    for (Int32 i = 0; i < stDevList.nDeviceNum; i++)
                    {
                        stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                        if (MyCamera.MV_GIGE_DEVICE == stDevInfo.nTLayerType)
                        {
                            MyCamera.MV_GIGE_DEVICE_INFO stGigEDeviceInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                            string adapterName = GetAdapterNameByMacAdd(stGigEDeviceInfo.nCurrentSubNetMask.ToString());     //网卡名
                            string sn = stGigEDeviceInfo.chSerialNumber;                                                    //序列号
                            string friendlyName = stGigEDeviceInfo.chManufacturerName;                                      //相机型号
                            string vendorName = stGigEDeviceInfo.chModelName;                                               //厂商

                            if (vendorName != "HIKVision")     //相应品牌的SDK只允许识别对应品牌的相机，否则采图时会出错
                                continue;

                            stDevInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(stDevList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                            nRet = myCamera.MV_CC_CreateDevice_NET(ref stDevInfo);
                            nRet = myCamera.MV_CC_OpenDevice_NET();
                            nRet = myCamera.MV_CC_StartGrabbing_NET();
                            MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
                            nRet = myCamera.MV_CC_GetIntValue_NET("PayloadSize", ref stParam);
                            UInt32 nPayloadSize = stParam.nCurValue;
                            myCamera.MV_CC_SetHeartBeatTimeout_NET(1000);       //设置心跳时间为1秒

                            string cameraInfoStr = string.Format("{0} | {1} | {2} | {3}", adapterName, vendorName, friendlyName, sn);
                            Machine.UpdateStep(20 + (10 / (int)stDevList.nDeviceNum) * (i + 1), string.Format("初始化海康威视相机{0} [{1}]", i + 1, cameraInfoStr), true);
                            SDK_HIKVision sdk_HIKVision = new SDK_HIKVision(cameraInfoStr);

                            D_cameras.Add(cameraInfoStr, myCamera);
                            AcqImageTool.L_SDKCamera.Add(sdk_HIKVision);
                            Frm_FromCamera.Instance.cbx_cameraList.Add(cameraInfoStr);
                        }
                        else if (MyCamera.MV_USB_DEVICE == stDevInfo.nTLayerType)
                        {
                            MyCamera.MV_USB3_DEVICE_INFO stUsb3DeviceInfo = (MyCamera.MV_USB3_DEVICE_INFO)MyCamera.ByteToStruct(stDevInfo.SpecialInfo.stUsb3VInfo, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                        }
                    }
                }
                else
                {
                    Frm_MessageBox.Instance.MessageBoxShow("枚举海康威视相机失败", TipType.Error);
                    return false;
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
                    foreach (KeyValuePair<string, MyCamera> item in D_cameras)
                    {
                        if (item.Key == CameraInfoStr)
                        {
                            MyCamera.MVCC_INTVALUE stParam = new MyCamera.MVCC_INTVALUE();
                            int nRet = item.Value.MV_CC_GetIntValue_NET("PayloadSize", ref stParam);
                            if (MyCamera.MV_OK != nRet)
                            {
                                Frm_MessageBox.Instance.MessageBoxShow("相机采图异常\r\n可能原因：未正常关闭\r\n解决方案：重启电脑或5分钟后重启程序", TipType.Error);
                                break;
                            }
                            UInt32 nPayloadSize = stParam.nCurValue;
                            IntPtr pBufForDriver = Marshal.AllocHGlobal((int)nPayloadSize);
                            IntPtr pBufForSaveImage = IntPtr.Zero;

                            MyCamera.MV_FRAME_OUT_INFO_EX FrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();
                            nRet = item.Value.MV_CC_GetOneFrameTimeout_NET(pBufForDriver, nPayloadSize, ref FrameInfo, 1000);
                            if (MyCamera.MV_OK == nRet)
                            {
                                if (pBufForSaveImage == IntPtr.Zero)
                                {
                                    pBufForSaveImage = Marshal.AllocHGlobal((int)(FrameInfo.nHeight * FrameInfo.nWidth * 3 + 2048));
                                }

                                MyCamera.MV_SAVE_IMAGE_PARAM_EX stSaveParam = new MyCamera.MV_SAVE_IMAGE_PARAM_EX();
                                stSaveParam.enImageType = MyCamera.MV_SAVE_IAMGE_TYPE.MV_Image_Bmp;
                                stSaveParam.enPixelType = FrameInfo.enPixelType;
                                stSaveParam.pData = pBufForDriver;
                                stSaveParam.nDataLen = FrameInfo.nFrameLen;
                                stSaveParam.nHeight = FrameInfo.nHeight;
                                stSaveParam.nWidth = FrameInfo.nWidth;
                                stSaveParam.pImageBuffer = pBufForSaveImage;
                                stSaveParam.nBufferSize = (uint)(FrameInfo.nHeight * FrameInfo.nWidth * 3 + 2048);
                                stSaveParam.nJpgQuality = 80;
                                nRet = item.Value.MV_CC_SaveImageEx_NET(ref stSaveParam);
                                if (MyCamera.MV_OK != nRet)
                                {
                                    Frm_MessageBox.Instance.MessageBoxShow("\r\n    采图异常，相机：" + CameraInfoStr, TipType.Error);
                                }
                                byte[] data = new byte[stSaveParam.nImageLen];
                                Marshal.Copy(pBufForSaveImage, data, 0, (int)stSaveParam.nImageLen);

                                //转化成Halcon对象
                                GCHandle hand = GCHandle.Alloc(data, GCHandleType.Pinned);
                                IntPtr pr = hand.AddrOfPinnedObject();
                                HOperatorSet.GenImage1(out image, new HTuple("byte"), stSaveParam.nWidth, stSaveParam.nHeight, pBufForDriver);
                                if (hand.IsAllocated)
                                    hand.Free();
                                Marshal.FreeHGlobal(pBufForDriver);
                                Marshal.FreeHGlobal(pBufForSaveImage);
                                break;
                            }
                            else
                            {
                                Frm_MessageBox.Instance.MessageBoxShow("\r\n    采图异常，相机：" + CameraInfoStr, TipType.Error);
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
            foreach (KeyValuePair<string, MyCamera> item in D_cameras)
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
                foreach (KeyValuePair<string, MyCamera> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        item.Value.MV_CC_SetFloatValue_NET("ExposureTime", (float)exposureTime * 1000);
                        Thread.Sleep(200);      //海康威视相机，实测发现设置完曝光后200毫秒以后才能生效，所以如此，当然这会影响CT，所以有待进一步优化
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
                foreach (KeyValuePair<string, MyCamera> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        item.Value.MV_CC_SetFloatValue_NET("Gain", (float)gain);
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
                foreach (KeyValuePair<string, MyCamera> item in D_cameras)
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
                foreach (KeyValuePair<string, MyCamera> item in D_cameras)
                {
                    item.Value.MV_CC_StopGrabbing_NET();
                    item.Value.MV_CC_CloseDevice_NET();
                    item.Value.MV_CC_DestroyDevice_NET();
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }

    }
}
