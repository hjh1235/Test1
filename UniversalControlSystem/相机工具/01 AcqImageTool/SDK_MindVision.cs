using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CameraHandle = System.Int32;
using HalconDotNet;
using MVSDK;

namespace VMPro
{
    /// <summary>
    /// 迈德威视相机
    /// </summary>
    [Serializable]
    internal class SDK_MindVision : SDK_Base
    {
        internal SDK_MindVision(string cameraInfoStr)
        {
            this.CameraInfoStr = cameraInfoStr;
        }

        /// <summary>
        /// 资源锁
        /// </summary>
        private object obj = new object();
        /// <summary>
        /// 帧数据
        /// </summary>
        private static IntPtr frameBuffer;
        /// <summary>
        /// 相机集合   键：相机信息字符串  值：相机句柄
        /// </summary>
        private static Dictionary<string, CameraHandle> D_cameras = new Dictionary<string, CameraHandle>();
        /// <summary>
        /// 实例对象
        /// </summary>
        private static SDK_MindVision _instance;
        public static SDK_MindVision Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SDK_MindVision(string.Empty);
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
                tSdkCameraDevInfo[] CameraList = new tSdkCameraDevInfo[16];
                MvApi.CameraEnumerateDevice(out  CameraList);
                if (CameraList == null)
                    return true;

                for (int i = 0; i < CameraList.Length; i++)
                {
                    //网卡名
                    string adapterName = string.Empty;
                    string cameraMac, adapterMac;
                    MvApi.CameraGigeGetMac(ref CameraList[i], out cameraMac, out adapterMac);
                    adapterName = GetAdapterNameByMacAdd(adapterMac);

                    //序列号
                    string sn = string.Empty;
                    byte[] buffer = CameraList[i].acSn;
                    sn = Encoding.Default.GetString(buffer);
                    sn = Regex.Split(sn, "\0")[0];

                    //相机型号
                    buffer = CameraList[i].acFriendlyName;
                    string friendlyName = Encoding.Default.GetString(buffer);
                    friendlyName = Regex.Split(friendlyName, "\0")[0];

                    //厂商
                    string vendorName = string.Empty;
                    vendorName = "MindVision";       //真想把喵的头打爆，然后撒上孜然吃烧烤

                    if (vendorName != "MindVision")     //相应品牌的SDK只允许识别对应品牌的相机，否则采图时会出错
                        continue;

                    CameraHandle cameraHandle = 0;
                    MvApi.CameraInit(ref  CameraList[i], -1, -1, ref cameraHandle);

                    tSdkCameraCapbility CameraInfo;
                    MvApi.CameraGetCapability(cameraHandle, out CameraInfo);
                    uint value = CameraInfo.sIspCapacity.bMonoSensor;
                    bool isMonoCamera = false;
                    if (value == 1)
                    {
                        isMonoCamera = true;
                        MvApi.CameraSetIspOutFormat(cameraHandle, (int)MVSDK.emImageFormat.CAMERA_MEDIA_TYPE_MONO8);
                    }
                    MvApi.CameraSetTriggerMode(cameraHandle, 1);
                    MvApi.CameraSetAeState(cameraHandle, 0);

                    MvApi.CameraPlay(cameraHandle);
                    int FrameBufferSize = CameraInfo.sResolutionRange.iWidthMax * CameraInfo.sResolutionRange.iWidthMax * (isMonoCamera ? 1 : 3);
                    frameBuffer = (IntPtr)MvApi.CameraAlignMalloc(FrameBufferSize, 16);

                    string cameraInfoStr = string.Format("{0} | {1} | {2} | {3}", adapterName, vendorName, friendlyName, sn);
                    Machine.UpdateStep(20 + (10 / (int)CameraList.Length) * (i + 1), string.Format("初始化迈德威视相机{0} [{1}]", i + 1, cameraInfoStr), true);
                    SDK_MindVision sdk_MindVision = new SDK_MindVision(cameraInfoStr);

                    D_cameras.Add(cameraInfoStr, cameraHandle);
                    AcqImageTool.L_SDKCamera.Add(sdk_MindVision);
                    Frm_FromCamera.Instance.cbx_cameraList.Add(cameraInfoStr);
                }
                return true;
            }
            catch
            {
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
                    foreach (KeyValuePair<string, CameraHandle> item in D_cameras)
                    {
                        if (item.Key == CameraInfoStr)
                        {
                            IntPtr pRawData;
                            MvApi.CameraSoftTrigger(item.Value);
                            tSdkFrameHead frameHead;
                            CameraSdkStatus statu = MvApi.CameraGetImageBuffer(item.Value, out  frameHead, out  pRawData, 3000);
                            if (statu == MVSDK.CameraSdkStatus.CAMERA_STATUS_SUCCESS)
                            {
                                MvApi.CameraImageProcess(item.Value, pRawData, frameBuffer, ref frameHead);
                                MvApi.CameraReleaseImageBuffer(item.Value, pRawData);
                                image = HimageToHobject(frameBuffer, ref frameHead);
                            }
                            else
                            {
                                Frm_MessageBox.Instance.MessageBoxShow("\r\n    采图异常，相机：" + CameraInfoStr, TipType.Error);
                            }
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
            foreach (KeyValuePair<string, CameraHandle> item in D_cameras)
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
                foreach (KeyValuePair<string, CameraHandle> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        MvApi.CameraSetExposureTime(item.Value, exposureTime * 1000);
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
                foreach (KeyValuePair<string, CameraHandle> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        MvApi.CameraSetAnalogGain(item.Value, (int)gain);
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
                foreach (KeyValuePair<string, CameraHandle> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        MvApi.CameraSetTriggerMode(item.Value, mode);
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
        /// 设置采集图像的ROI
        /// </summary>
        internal override void SetAcqRegion(int offsetV, int offsetH, int imageH, int imageW)
        {
            try
            {
                foreach (KeyValuePair<string, CameraHandle> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        tSdkImageResolution sRoiResolution;
                        MvApi.CameraGetImageResolution(item.Value, out sRoiResolution);
                        sRoiResolution.iIndex = 0xff;       //设置成0xff表示自定义分辨率，设置成0到N表示选择预设分辨率
                        sRoiResolution.iWidth = imageW;
                        sRoiResolution.iWidthFOV = imageW;
                        sRoiResolution.iHeight = imageH;
                        sRoiResolution.iHeightFOV = imageH;
                        sRoiResolution.iWidthZoomHd = imageW;
                        sRoiResolution.iHeightZoomHd = imageH;
                        sRoiResolution.iHOffsetFOV = offsetH;
                        sRoiResolution.iVOffsetFOV = offsetV;
                        sRoiResolution.iWidthZoomSw = 0;
                        sRoiResolution.iHeightZoomSw = 0;
                        sRoiResolution.uBinAverageMode = 0;
                        sRoiResolution.uBinSumMode = 0;
                        sRoiResolution.uResampleMask = 0;
                        sRoiResolution.uSkipMode = 0;
                        MvApi.CameraSetImageResolution(item.Value, ref  sRoiResolution);

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
                foreach (KeyValuePair<string, CameraHandle> item in D_cameras)
                {
                    MvApi.CameraUnInit(item.Value);
                }
                MvApi.CameraAlignFree(frameBuffer);
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 将Himage类型转化成Hobject类型
        /// </summary>
        /// <param name="pFrameBuffer">Himage类型待转图像</param>
        /// <param name="pFrameHead">待转图像的帧头</param>
        /// <returns>输出已转化的Hobject类型图像</returns>
        private HObject HimageToHobject(IntPtr pFrameBuffer, ref tSdkFrameHead pFrameHead)
        {
            try
            {
                int w = pFrameHead.iWidth;
                int h = pFrameHead.iHeight;
                HObject Image = null;

                if (pFrameHead.uiMediaType == (uint)MVSDK.emImageFormat.CAMERA_MEDIA_TYPE_MONO8)
                    HOperatorSet.GenImage1(out Image, "byte", w, h, pFrameBuffer);
                else if (pFrameHead.uiMediaType == (uint)MVSDK.emImageFormat.CAMERA_MEDIA_TYPE_BGR8)
                    HOperatorSet.GenImageInterleaved(out Image, pFrameBuffer, "bgr", w, h, -1, "byte", w, h, 0, 0, -1, 0);
                else
                    Frm_MessageBox.Instance.MessageBoxShow("图像格式不支持转换", TipType.Error);

                HObject ImageRaw = Image;
                HOperatorSet.MirrorImage(ImageRaw, out Image, "row");
                ImageRaw.Dispose();
                HOperatorSet.ImageToChannels(Image, out Image);
                return Image;
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
                return null;
            }
        }

    }
}
