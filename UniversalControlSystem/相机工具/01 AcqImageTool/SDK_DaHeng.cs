using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using GxIAPINET;
using GxIAPINET.Sample.Common;
using HalconDotNet;
using MvCamCtrl.NET;

namespace VMPro
{
    /// <summary>
    /// 大恒相机
    /// </summary>
    [Serializable]
    internal class SDK_DaHeng : SDK_Base
    {
        internal SDK_DaHeng(string cameraInfoStr)
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
        private static Dictionary<string, IGXStream> D_cameras = new Dictionary<string, IGXStream>();
        /// <summary>
        /// 实例对象
        /// </summary>
        private static SDK_DaHeng _instance;
        public static SDK_DaHeng Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SDK_DaHeng(string.Empty);
                return _instance;
            }
        }


        IGXFactory m_objIGXFactory = null;                   ///<Factory对像
        IGXDevice m_objIGXDevice = null;                   ///<设备对像
        IGXStream m_objIGXStream = null;                   ///<流对像
        IGXFeatureControl m_objIGXFeatureControl = null;                   ///<远端设备属性控制器对像
        IGXFeatureControl m_objIGXStreamFeatureControl = null;                  ///<流层属性控制器对象
        CStatistics m_objStatistic = new CStatistics();      ///<数据统计类对象用于处理统计时间
        GxBitmap m_objGxBitmap = null;                   ///<图像显示类对象
        /// <summary>
        /// 关闭流
        /// </summary>
        private void __CloseStream()
        {
            try
            {
                //关闭流
                if (null != m_objIGXStream)
                {
                    m_objIGXStream.Close();
                    m_objIGXStream = null;
                    m_objIGXStreamFeatureControl = null;
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 关闭设备
        /// </summary>
        private void __CloseDevice()
        {
            try
            {
                foreach (KeyValuePair<string, IGXStream> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        //关闭设备
                        if (null != item.Value)
                        {
                            item.Value.Close();
                            //item.Value = null;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 相机初始化
        /// </summary>
        private void __InitDevice()
        {
            if (null != m_objIGXFeatureControl)
            {
                //设置采集模式连续采集
                m_objIGXFeatureControl.GetEnumFeature("AcquisitionMode").SetValue("Continuous");

                //设置触发模式为开
                m_objIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("On");

                //选择触发源为软触发
                m_objIGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Software");
            }
        }

        /// <summary>
        /// 枚举相机
        /// </summary>
        /// <returns>是否成功</returns>
        internal  override  bool EnumCamera()
        {
            try
            {
             






                List<IGXDeviceInfo> listGXDeviceInfo = new List<IGXDeviceInfo>();

                //关闭流
                __CloseStream();
                // 如果设备已经打开则关闭，保证相机在初始化出错情况下能再次打开
                __CloseDevice();

                m_objIGXFactory.UpdateDeviceList(200, listGXDeviceInfo);

                // 判断当前连接设备个数
                if (listGXDeviceInfo.Count <= 0)
                {
                    //MessageBox.Show("未发现设备!");
                    return false;
                }



                int camIndex = 0;
                for (Int32 i = 0; i < listGXDeviceInfo.Count; i++)
                {




                    camIndex++;
                    string sn = listGXDeviceInfo[i].GetSN();
                    string IPAddress = listGXDeviceInfo[i].GetIP();
                    string macAddress = listGXDeviceInfo[i].GetMAC();
                    string vendorName = listGXDeviceInfo[i].GetVendorName();
                    string friendlyName = listGXDeviceInfo[i].GetModelName();

                    if (vendorName != "DaHeng")     //相应品牌的SDK只允许识别对应品牌的相机，否则采图时会出错
                        continue;

                    m_objIGXDevice = m_objIGXFactory.OpenDeviceBySN(listGXDeviceInfo[i].GetSN(), GX_ACCESS_MODE.GX_ACCESS_EXCLUSIVE);
                    m_objIGXFeatureControl = m_objIGXDevice.GetRemoteFeatureControl();

                    //打开流
                    if (null != m_objIGXDevice)
                    {
                        m_objIGXStream = m_objIGXDevice.OpenStream(0);
                        m_objIGXStreamFeatureControl = m_objIGXStream.GetFeatureControl();
                    }

                    // 建议用户在打开网络相机之后，根据当前网络环境设置相机的流通道包长值，
                    // 以提高网络相机的采集性能,设置方法参考以下代码。
                    GX_DEVICE_CLASS_LIST objDeviceClass = m_objIGXDevice.GetDeviceInfo().GetDeviceClass();
                    if (GX_DEVICE_CLASS_LIST.GX_DEVICE_CLASS_GEV == objDeviceClass)
                    {
                        // 判断设备是否支持流通道数据包功能
                        if (true == m_objIGXFeatureControl.IsImplemented("GevSCPSPacketSize"))
                        {
                            // 获取当前网络环境的最优包长值
                            uint nPacketSize = m_objIGXStream.GetOptimalPacketSize();
                            // 将最优包长值设置为当前设备的流通道包长值
                            m_objIGXFeatureControl.GetIntFeature("GevSCPSPacketSize").SetValue(nPacketSize);
                        }
                    }

                    __InitDevice();

                    m_objGxBitmap = new GxBitmap(m_objIGXDevice, m_pic_ShowImage);



                    if (null != m_objIGXStreamFeatureControl)
                    {
                        //设置流层Buffer处理模式为OldestFirst
                        m_objIGXStreamFeatureControl.GetEnumFeature("StreamBufferHandlingMode").SetValue("OldestFirst");
                    }

                    //开启采集流通道
                    if (null != m_objIGXStream)
                    {
                        m_objIGXStream.StartGrab();
                    }

                    //发送开采命令
                    if (null != m_objIGXFeatureControl)
                    {
                        m_objIGXFeatureControl.GetCommandFeature("AcquisitionStart").Execute();
                    }










                    string cameraInfoStr = string.Format("{0} | {1} | {2} | {3}", sn, macAddress, vendorName, friendlyName);
                    Machine.UpdateStep(25 + 10 * camIndex, string.Format("初始化大恒相机{0}[{1}]", camIndex, cameraInfoStr), true);
                    SDK_DaHeng sdk_DaHeng = new SDK_DaHeng(cameraInfoStr);




                    D_cameras.Add(cameraInfoStr, m_objIGXStream);
                    AcqImageTool.L_SDKCamera.Add(sdk_DaHeng);
                    Frm_FromCamera.Instance.cbx_cameraList.Add(cameraInfoStr);
                }


                return true;
            }
            catch 
            {
                return false;
            }
        }

        CStopWatch m_objStopTime = new CStopWatch();       ///<定义时间差类对象


        /// <summary>
        /// 采图
        /// </summary>
        /// <returns>采集到的图像</returns>
        internal override HObject GrabOneImage()
        {
            try
            {
                lock (obj)
                {
                    HObject image = null;
                    foreach (KeyValuePair<string, IGXStream> item in D_cameras)
                    {
                        if (item.Key == CameraInfoStr)
                        {



                            IImageData objIImageData = null;
                            double dElapsedtime = 0;
                            uint nTimeout = 500;

                            if (!string.IsNullOrEmpty("500"))
                            {
                                try
                                {
                                    nTimeout = Convert.ToUInt32(500);
                                }
                                catch (Exception)
                                {
                                    ////m_txt_TimeOut.Text = (500).ToString();
                                    //MessageBox.Show("请输入正确的有效数字！");
                                    return null;
                                }
                            }

                            //m_txt_TimeOut.Text = nTimeout.ToString();

                            //每次发送触发命令之前清空采集输出队列
                            //防止库内部缓存帧，造成本次GXGetImage得到的图像是上次发送触发得到的图
                            if (null != m_objIGXStream)
                            {
                                m_objIGXStream.FlushQueue();
                            }

                            //发送软触发命令
                            if (null != m_objIGXFeatureControl)
                            {
                                m_objIGXFeatureControl.GetCommandFeature("TriggerSoftware").Execute();
                            }

                            //获取图像
                            if (null != m_objIGXStream)
                            {
                                //计时开始
                                m_objStopTime.Start();

                                objIImageData = m_objIGXStream.GetImage(nTimeout);

                                //结束计时
                                dElapsedtime = m_objStopTime.Stop();
                            }

                            m_objGxBitmap.Show(objIImageData);

                            if (null != objIImageData)
                            {
                                //用完之后释放资源
                                objIImageData.Destroy();
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
        PictureBox m_pic_ShowImage = null;                ///<图片显示控件
        bool m_bIsColor = false;               ///<是否支持彩色相机
        byte[] m_byMonoBuffer = null;                ///<黑白相机buffer
        byte[] m_byColorBuffer = null;                ///<彩色相机buffer
        byte[] m_byRawBuffer = null;                ///<用于存储Raw图的Buffer
        int m_nPayloadSize = 0;                   ///<图像数据大小
        int m_nWidth = 0;                   ///<图像宽度
        int m_nHeigh = 0;                   ///<图像高度
        Bitmap m_bitmapForSave = null;                ///<bitmap对象,仅供存储图像使用
        const uint PIXEL_FORMATE_BIT = 0x00FF0000;          ///<用于与当前的数据格式进行与运算得到当前的数据位数
        const uint GX_PIXEL_8BIT = 0x00080000;          ///<8位数据图像格式
        ///
        const int COLORONCOLOR = 3;
        const uint DIB_RGB_COLORS = 0;
        const uint SRCCOPY = 0x00CC0020;
        CWin32Bitmaps.BITMAPINFO m_objBitmapInfo = new CWin32Bitmaps.BITMAPINFO();
        IntPtr m_pBitmapInfo = IntPtr.Zero;
        IntPtr m_pHDC = IntPtr.Zero;

        /// <summary>
        /// 判断是否兼容
        /// </summary>
        /// <param name="bitmap">Bitmap对象</param>
        /// <param name="nWidth">图像宽度</param>
        /// <param name="nHeight">图像高度</param>
        /// <param name="bIsColor">是否是彩色相机</param>
        /// <returns>true为一样，false不一样</returns>
        private bool __IsCompatible(Bitmap bitmap, int nWidth, int nHeight, bool bIsColor)
        {
            if (bitmap == null
                || bitmap.Height != nHeight
                || bitmap.Width != nWidth
                || bitmap.PixelFormat != __GetFormat(bIsColor)
             )
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取图像显示格式
        /// </summary>
        /// <param name="bIsColor">是否为彩色相机</param>
        /// <returns>图像的数据格式</returns>
        private PixelFormat __GetFormat(bool bIsColor)
        {
            return bIsColor ? PixelFormat.Format24bppRgb : PixelFormat.Format8bppIndexed;
        }


        /// <summary>
        /// 检查图像是否改变并更新Buffer
        /// </summary>
        /// <param name="objIBaseData">图像数据对象</param>
        private void __UpdateBufferSize(IBaseData objIBaseData)
        {
            if (null != objIBaseData)
            {
                if (__IsCompatible(m_bitmapForSave, m_nWidth, m_nHeigh, m_bIsColor))
                {
                    m_nPayloadSize = (int)objIBaseData.GetPayloadSize();
                    m_nWidth = (int)objIBaseData.GetWidth();
                    m_nHeigh = (int)objIBaseData.GetHeight();
                }
                else
                {
                    m_nPayloadSize = (int)objIBaseData.GetPayloadSize();
                    m_nWidth = (int)objIBaseData.GetWidth();
                    m_nHeigh = (int)objIBaseData.GetHeight();

                    m_byRawBuffer = new byte[m_nPayloadSize];
                    m_byMonoBuffer = new byte[__GetStride(m_nWidth, m_bIsColor) * m_nHeigh];
                    m_byColorBuffer = new byte[__GetStride(m_nWidth, m_bIsColor) * m_nHeigh];

                    //更新BitmapInfo
                    m_objBitmapInfo.bmiHeader.biWidth = m_nWidth;
                    m_objBitmapInfo.bmiHeader.biHeight = m_nHeigh;
                    Marshal.StructureToPtr(m_objBitmapInfo, m_pBitmapInfo, false);
                }
            }
        }


        /// <summary>
        /// 计算宽度所占的字节数
        /// </summary>
        /// <param name="nWidth">图像宽度</param>
        /// <param name="bIsColor">是否是彩色相机</param>
        /// <returns>图像一行所占的字节数</returns>
        private int __GetStride(int nWidth, bool bIsColor)
        {
            return bIsColor ? nWidth * 3 : nWidth;
        }


        /// <summary>
        /// 通过GX_PIXEL_FORMAT_ENTRY获取最优Bit位
        /// </summary>
        /// <param name="em">图像数据格式</param>
        /// <returns>最优Bit位</returns>
        private GX_VALID_BIT_LIST __GetBestValudBit(GX_PIXEL_FORMAT_ENTRY emPixelFormatEntry)
        {
            GX_VALID_BIT_LIST emValidBits = GX_VALID_BIT_LIST.GX_BIT_0_7;
            switch (emPixelFormatEntry)
            {
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB8:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG8:
                    {
                        emValidBits = GX_VALID_BIT_LIST.GX_BIT_0_7;
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB10:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG10:
                    {
                        emValidBits = GX_VALID_BIT_LIST.GX_BIT_2_9;
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB12:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG12:
                    {
                        emValidBits = GX_VALID_BIT_LIST.GX_BIT_4_11;
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO14:
                    {
                        //暂时没有这样的数据格式待升级
                        break;
                    }
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_MONO16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GR16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_RG16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_GB16:
                case GX_PIXEL_FORMAT_ENTRY.GX_PIXEL_FORMAT_BAYER_BG16:
                    {
                        //暂时没有这样的数据格式待升级
                        break;
                    }
                default:
                    break;
            }
            return emValidBits;
        }

        /// <summary>
        /// 判断PixelFormat是否为8位
        /// </summary>
        /// <param name="emPixelFormatEntry">图像数据格式</param>
        /// <returns>true为8为数据，false为非8位数据</returns>
        private bool __IsPixelFormat8(GX_PIXEL_FORMAT_ENTRY emPixelFormatEntry)
        {
            bool bIsPixelFormat8 = false;
            uint uiPixelFormatEntry = (uint)emPixelFormatEntry;
            if ((uiPixelFormatEntry & PIXEL_FORMATE_BIT) == GX_PIXEL_8BIT)
            {
                bIsPixelFormat8 = true;
            }
            return bIsPixelFormat8;
        }

        /// <summary>
        /// 更新和复制图像数据到Bitmap的buffer
        /// </summary>
        /// <param name="bitmap">Bitmap对象</param>
        /// <param name="nWidth">图像宽度</param>
        /// <param name="nHeight">图像高度</param>
        /// <param name="bIsColor">是否是彩色相机</param>
        private void __UpdateBitmap(Bitmap bitmap, byte[] byBuffer, int nWidth, int nHeight, bool bIsColor)
        {
            //给BitmapData加锁
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);

            //得到一个指向Bitmap的buffer指针
            IntPtr ptrBmp = bmpData.Scan0;
            int nImageStride = __GetStride(m_nWidth, bIsColor);
            //图像宽能够被4整除直接copy
            if (nImageStride == bmpData.Stride)
            {
                Marshal.Copy(byBuffer, 0, ptrBmp, bmpData.Stride * bitmap.Height);
            }
            else//图像宽不能够被4整除按照行copy
            {
                for (int i = 0; i < bitmap.Height; ++i)
                {
                    Marshal.Copy(byBuffer, i * nImageStride, new IntPtr(ptrBmp.ToInt64() + i * bmpData.Stride), m_nWidth);
                }
            }
            //BitmapData解锁
            bitmap.UnlockBits(bmpData);
        }
        /// <summary>
        /// 创建Bitmap
        /// </summary>
        /// <param name="bitmap">Bitmap对象</param>
        /// <param name="nWidth">图像宽度</param>
        /// <param name="nHeight">图像高度</param>
        /// <param name="bIsColor">是否是彩色相机</param>
        private void __CreateBitmap(out Bitmap bitmap, int nWidth, int nHeight, bool bIsColor)
        {
            bitmap = new Bitmap(nWidth, nHeight, __GetFormat(bIsColor));
            if (bitmap.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                ColorPalette colorPalette = bitmap.Palette;
                for (int i = 0; i < 256; i++)
                {
                    colorPalette.Entries[i] = Color.FromArgb(i, i, i);
                }
                bitmap.Palette = colorPalette;
            }
        }

        /// <summary>
        /// 更新存储数据
        /// </summary>
        /// <param name="byBuffer">图像buffer</param>
        private void __UpdateBitmapForSave(byte[] byBuffer)
        {
            if (__IsCompatible(m_bitmapForSave, m_nWidth, m_nHeigh, m_bIsColor))
            {
                __UpdateBitmap(m_bitmapForSave, byBuffer, m_nWidth, m_nHeigh, m_bIsColor);
            }
            else
            {
                __CreateBitmap(out m_bitmapForSave, m_nWidth, m_nHeigh, m_bIsColor);
                __UpdateBitmap(m_bitmapForSave, byBuffer, m_nWidth, m_nHeigh, m_bIsColor);
            }
        }


        /// <summary>
        /// 存储图像
        /// </summary>
        /// <param name="objIBaseData">图像数据对象</param>
        /// <param name="strFilePath">显示图像文件名</param>
        public HObject SaveBmp(IBaseData objIBaseData, string strFilePath)
        {
            HObject image = new HObject();
            GX_VALID_BIT_LIST emValidBits = GX_VALID_BIT_LIST.GX_BIT_0_7;

            //检查图像是否改变并更新Buffer
            __UpdateBufferSize(objIBaseData);

            if (null != objIBaseData)
            {
                emValidBits = __GetBestValudBit(objIBaseData.GetPixelFormat());
                if (m_bIsColor)
                {
                    IntPtr pBufferColor = objIBaseData.ConvertToRGB24(emValidBits, GX_BAYER_CONVERT_TYPE_LIST.GX_RAW2RGB_NEIGHBOUR, false);
                    Marshal.Copy(pBufferColor, m_byColorBuffer, 0, __GetStride(m_nWidth, m_bIsColor) * m_nHeigh);
                    __UpdateBitmapForSave(m_byColorBuffer);
                }
                else
                {
                    IntPtr pBufferMono = IntPtr.Zero;
                    if (__IsPixelFormat8(objIBaseData.GetPixelFormat()))
                    {
                        pBufferMono = objIBaseData.GetBuffer();
                    }
                    else
                    {
                        pBufferMono = objIBaseData.ConvertToRaw8(emValidBits);
                    }
                    Marshal.Copy(pBufferMono, m_byMonoBuffer, 0, __GetStride(m_nWidth, m_bIsColor) * m_nHeigh);

                    __UpdateBitmapForSave(m_byMonoBuffer);
                }
                m_bitmapForSave.Save(strFilePath, ImageFormat.Bmp);


                Rectangle rect = new Rectangle(0, 0, m_bitmapForSave.Width, m_bitmapForSave.Height);
                BitmapData srcBmpData = m_bitmapForSave.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                HOperatorSet.GenImageInterleaved(out image, srcBmpData.Scan0, "bgr", m_bitmapForSave.Width, m_bitmapForSave.Height, 0, "byte", 0, 0, 0, 0, -1, 0);
                m_bitmapForSave.UnlockBits(srcBmpData);
                return image;
            }
            return image;
        }



        /// <summary>
        /// 设置相机曝光时间
        /// </summary>
        /// <param name="exposure">曝光时间</param>
        internal override void SetExposureTime(double exposure)
        {
            try
            {
                foreach (KeyValuePair<string, IGXStream> item in D_cameras)
                {
                    if (item.Key == CameraInfoStr)
                    {
                        //item.Value.MV_CC_SetFloatValue_NET("ExposureTime", (float)exposure * 1000);
                        //Thread.Sleep(200);      //海康威视相机，实测发现设置完曝光后200毫秒以后才能生效，所以如此，当然这会影响CT
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        internal override bool CheckExist()
        {
            foreach (KeyValuePair<string, IGXStream> item in D_cameras)
            {
                if (item.Key == CameraInfoStr)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// 停止采集关闭设备、关闭流
        /// </summary>
        internal  void CloAllCamera()
        {
            try
            {
                // 如果未停采则先停止采集
                    if (null != m_objIGXFeatureControl)
                    {
                        m_objIGXFeatureControl.GetCommandFeature("AcquisitionStop").Execute();
                        m_objIGXFeatureControl = null;
                    }
            }
            catch (Exception)
            {
            }
            try
            {
                //停止流通道和关闭流
                if (null != m_objIGXStream)
                {
                    m_objIGXStream.StopGrab();
                    m_objIGXStream.Close();
                    m_objIGXStream = null;
                    m_objIGXStreamFeatureControl = null;
                }
            }
            catch (Exception)
            {
            }

            //关闭设备
            __CloseDevice();
        }
        /// <summary>
        /// 关闭所有相机
        /// </summary>
        internal override void CloseAllCamera()
        {
            try
            {
                foreach (KeyValuePair<string, IGXStream> item in D_cameras)
                {
                    //item.Value.Reset();
                    // 停止采集关闭设备、关闭流
                    //CloAllCamera();
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }

    }
}
