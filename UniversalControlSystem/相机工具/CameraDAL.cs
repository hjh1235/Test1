using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public class CameraDAL
    {
        public delegate void GrapImageDelegate(object sender, EventArgsDAL e);
        public event GrapImageDelegate GrapImageEvent;
        public delegate void GetDeviceDelegate(object sender, EventArgsDAL e);
        public event GetDeviceDelegate GetDeviceEvent;
        public delegate void OpenDeviceDelegate(object sender, EventArgsDAL e);
        public event OpenDeviceDelegate OpenDeviceEvent;

        HTuple hv_AcqHandle = null;
        HObject ho_Image = null;
        bool m_bShowFlag = false;
        bool m_bRun = false;
        Thread hThread = null;
        EventArgsDAL _EventArgs = new EventArgsDAL();
        string cameraInterface, device;
        private static CameraDAL _CameraDAL;
        public static CameraDAL Instance()
        {
            if (_CameraDAL == null)
            {
                _CameraDAL = new CameraDAL();
            }
            return _CameraDAL;
        }
        public CameraDAL()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public HTuple AcqHandle
        {
            get { return hv_AcqHandle; }
            set { hv_AcqHandle = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Device
        {
            get { return device; }
            set { device = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CameraInterface
        {
            get { return cameraInterface; }
            set { cameraInterface = value; }
        }
        public HTuple  ExposureTime
        {  get ; set; }
        public HTuple  Gain
        { get; set; }
        public bool IsGrabAsync
        { get; set; }
        public HTuple FrameRate
        { get; set; }
        private void OnGrapImageEvent(EventArgsDAL e)
        {   //定义一个局部变量，将事件对象赋值给该变量，防止多线程情况取消事件
            GrapImageDelegate mEvent = this.GrapImageEvent;
            if (mEvent != null)
            {
                mEvent(this, e);//事件触发
            }
        }
        private void OnGetDeviceEvent(EventArgsDAL e)
        {   //定义一个局部变量，将事件对象赋值给该变量，防止多线程情况取消事件
            GetDeviceDelegate mEvent = this.GetDeviceEvent;
            if (mEvent != null)
            {
                mEvent(this, e);//事件触发
            }
        }
        private void OnOpenDeviceEvent(EventArgsDAL e)
        {   //定义一个局部变量，将事件对象赋值给该变量，防止多线程情况取消事件
            OpenDeviceDelegate mEvent = this.OpenDeviceEvent;
            if (mEvent != null)
            {
                mEvent(this, e);//事件触发
            }
        }
        public void GetDevice()
        {   HTuple hv_InfoList = null;
            HTuple hv_deviceList = null;
             GetDevice(cameraInterface, out hv_InfoList, out hv_deviceList);
            _EventArgs.InfoList = hv_InfoList;
            _EventArgs.DeviceList = hv_deviceList;
             OnGetDeviceEvent(_EventArgs);
        }
        public void Run()
        {
                OpenCamera(cameraInterface, device);
                GrapImage();
         }
        public void OnceRun()
        {
            OpenCamera(cameraInterface, device);
            SnapImage();
            _EventArgs.Image = ho_Image;
            _EventArgs.AcqHandle = hv_AcqHandle;
            OnGrapImageEvent(_EventArgs);
        }
        /// <summary>
        /// 获取相机设备
        /// </summary>
        /// <param name="cameraInterface">相机接口</param>
        /// <param name="hv_Information">相机信息</param>
        /// <param name="hv_deviceList">相机列表</param>
        void GetDevice(string cameraInterface, out HTuple hv_InfoList, out HTuple hv_deviceList)
        {
            HTuple hv_Information = null;
            hv_InfoList = null;
            hv_deviceList = null;
            if (cameraInterface == "")
            {
                MessageBox.Show("请选获取相机");
                return ;
            }

            try
            {
                HOperatorSet.InfoFramegrabber(cameraInterface, "info_boards", out hv_Information, out hv_InfoList);
                HOperatorSet.InfoFramegrabber(cameraInterface, "device", out hv_Information, out hv_deviceList);
            }
            catch
            { MessageBox.Show(" 获取相机异常"); }
        }
        /// <summary>
        /// 打开相机
        /// </summary>
        /// <param name="cameraInterface">相机接口</param>
        /// <param name="device">相机SN</param>
        public bool OpenCamera(string cameraInterface, string device)
        {
            try
            {
                if (hv_AcqHandle == null && cameraInterface == null && device == null)
                {
                    MessageBox.Show("请选获取相机");
                    return false;
                }

                if (hv_AcqHandle == null && cameraInterface != null && device != null)
                {

                    //HOperatorSet.OpenFramegrabber(cameraInterface, 0, 0, 0, 0, 0, 0, "default", 8, "rgb", -1, "false", "default", device, 0, -1, out hv_AcqHandle);
                                                  // 'DirectShow', 1, 1, 0, 0, 0, 0, 'default', 8, 'rgb', -1, 'false', 'default', '[0] USB2.0 UVC PC Camera', 0, -1, AcqHandle)
                    HOperatorSet.OpenFramegrabber(cameraInterface, 1, 1, 0, 0, 0, 0, "default", 8, "rgb", -1, "false", "default", device, 0, -1, out hv_AcqHandle);
                   //HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "ExposureTimeAbs", ExposureTime);
                    HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
                    _EventArgs.AcqHandle = hv_AcqHandle;
                    OnOpenDeviceEvent(_EventArgs);
                }
                return true;
            }
            catch (HalconException ex)
            {
                HTuple hv_Exception;
                ex.ToHTuple(out hv_Exception);
                MessageBox.Show("相机"+ ex);
                return false;
            }
        }
        /// <summary>
        /// 关闭相机
        /// </summary>
        public void CloseCamera()
        {
            try
            {
                m_bShowFlag = false;
                m_bRun = false;
                if (hThread != null)
                    hThread.Abort();
                if (hv_AcqHandle != null)
                {
                    HOperatorSet.CloseFramegrabber(hv_AcqHandle);
                    hv_AcqHandle = null;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 停止实时采集
        /// </summary>
        public void StopGrapImage()
        {
            if (m_bShowFlag)
                m_bRun = false;
        }
        /// <summary>
        ///   实时采集
        /// </summary>
        public void GrapImage()
        {
            if (m_bShowFlag)
            {
                m_bRun = true;
            }
            else
            {
                if (hv_AcqHandle != null)
                {
                    hThread = new Thread(grapImage);
                    hThread.IsBackground = true;
                    hThread.Start();
                }
            }
        }
        //线程函数
        void grapImage()
        {
            HTuple hv_secondsCurrent, hv_secondsBegin, hv_numImages=0, hv_frameRate;
            m_bShowFlag = true;//设置运行状态
            m_bRun = true;
            HOperatorSet.CountSeconds(out hv_secondsBegin);
            while (m_bShowFlag)
            {try
                {
                    if (m_bRun)
                    {
                        if (ho_Image != null)
                            ho_Image.Dispose();
                        if (cameraInterface != "DirectShow")
                            HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "ExposureTimeAbs", ExposureTime);
                        HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);
                        HOperatorSet.CountSeconds(out hv_secondsCurrent);
                        hv_numImages += 1;
                        hv_frameRate = hv_numImages / (hv_secondsCurrent - hv_secondsBegin);
                        _EventArgs.Image = ho_Image;
                        _EventArgs.AcqHandle = hv_AcqHandle;
                        _EventArgs.FrameRate = hv_frameRate;
                        OnGrapImageEvent(_EventArgs);
                    }
                }
                catch
                { }
            }
        }
        /// <summary>
        ///抓取一张图片
        /// </summary>
        public void SnapImage()
        {
            try
            {
                if (ho_Image != null)
                    ho_Image.Dispose();
                if (m_bRun)
                    m_bRun = false; //停止实时采集
                if (hv_AcqHandle != null)
                {
                       
                   // HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "GainRaw", Gain);
                    if (cameraInterface != "DirectShow")
                        HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "ExposureTimeAbs", ExposureTime);
                    if (IsGrabAsync)
                        HOperatorSet.GrabImageAsync(out ho_Image, hv_AcqHandle, -1);
                    else
                        HOperatorSet.GrabImage(out ho_Image, hv_AcqHandle);
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("采集图像异常" + ex);
            }

        }

    }
}
