using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Net.NetworkInformation;

namespace VMPro
{
    /// <summary>
    /// 相机基类
    /// </summary>
    [Serializable]
    internal class SDK_Base
    {

        /// <summary>
        /// 相机信息字符串，相当于每个相机的名字
        /// </summary>
        internal string CameraInfoStr = string.Empty;
        /// <summary>
        /// 等待硬触发完成
        /// </summary>
        internal bool waitingHardTriggImageArrived = false;


        /// <summary>
        /// 枚举相机
        /// </summary>
        /// <returns>是否成功</returns>
        internal virtual bool EnumCamera() { return false; }
        /// <summary>
        /// 抓取一张图像
        /// </summary>
        /// <returns>图像</returns>
        internal virtual HObject GrabOneImage() { return null; }
        /// <summary>
        /// 检查相机是否存在，即系统是否识别到此相机
        /// </summary>
        /// <returns>是否存在</returns>
        internal virtual bool CheckExist() { return false; }
        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="exposureTime">曝光时间</param>
        internal virtual void SetExposureTime(double exposureTime) { }
        /// <summary>
        /// 设置增益
        /// </summary>
        /// <param name="exposure">增益</param>
        internal virtual void SetGain(double gain) { }
        /// <summary>
        /// 设置采集模式
        /// </summary>
        /// <param name="mode">0=连续采集，即异步采集  1=单次采集，即同步采集</param>
        internal virtual void SetAcquisitionMode(int mode) { }
        /// <summary>
        /// 设置采集图像的ROI
        /// </summary>
        internal virtual void SetAcqRegion(int offsetV, int offsetH, int imageH, int imageW) { }
        /// <summary>
        /// 关闭所有相机
        /// </summary>
        internal virtual void CloseAllCamera() { }
        /// <summary>
        /// 通过网卡的物理地址获取网卡名
        /// </summary>
        /// <returns>网卡名</returns>
        internal string GetAdapterNameByMacAdd(string MacAdd)
        {
            try
            {
                MacAdd = MacAdd.Replace("-", "");
                NetworkInterface[] networkInterface = NetworkInterface.GetAllNetworkInterfaces();
                foreach (var item in networkInterface)
                {
                    string localMacAdd = item.GetPhysicalAddress().ToString();
                    if (localMacAdd == MacAdd)
                        return item.Name;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
                return string.Empty;
            }
        }

    }
}
