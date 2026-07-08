using Basler.Pylon;
using FastColoredTextBoxNS;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace UniversalControlSystem
{
    [Serializable]
    public class ToolBase
    {
        /// <summary>
        /// 流程名
        /// </summary>
        internal string jobName = string.Empty;
        internal ToolRunStatu runStatu = ToolRunStatu.未运行;
        /// <summary>
        /// 工具运行
        /// </summary>
        public virtual void Run(string s, bool b, bool b1 = true)
        {
            s.Replace("m","");
        }
        /// <summary>
        /// 锁
        /// </summary>
        private object obj = new object();
        /// <summary>
        /// 显示图像
        /// </summary>
        /// <param name="image"></param>
        //internal void Display_Image(HObject image, HWindow_Final imageWindowControl)
        //{
        //    try
        //    {
        //        lock (obj)
        //        {
        //            HTuple width, height;
        //            HOperatorSet.GetImageSize(image, out height, out width);
        //            if (height.Length > 1)
        //            {
        //                height = height[0];
        //                width = width[0];
        //            }

        //            ////////有开启全屏
        //            //////if (fullScreen)
        //            //////{
        //            //////    HOperatorSet.SetPart(Frm_FullScreen.Instance.windowHandle, 0, 0, width - 1, height - 1);
        //            //////    HOperatorSet.DispObj(image, Frm_FullScreen.Instance.windowHandle);

        //            //////    //此处根据图像分辨率大小设置显示字体的大小，只是为了好看而已
        //            //////    if (width < 1000)
        //            //////    {
        //            //////        set_display_font(Frm_FullScreen.Instance.windowHandle, new HTuple(12), "nomo", "false", "false");
        //            //////    }
        //            //////    else if (width < 2000)
        //            //////    {
        //            //////        set_display_font(Frm_FullScreen.Instance.windowHandle, new HTuple(12), "nomo", "false", "false");
        //            //////    }
        //            //////    else if (width < 3000)
        //            //////    {
        //            //////        set_display_font(Frm_FullScreen.Instance.windowHandle, new HTuple(15), "nomo", "false", "false");
        //            //////    }
        //            //////    else
        //            //////    {
        //            //////        set_display_font(Frm_FullScreen.Instance.windowHandle, new HTuple(18), "nomo", "false", "false");
        //            //////    }
        //            //////    disp_message(Frm_FullScreen.Instance.windowHandle, "ESC 退出全屏模式", "image", 2, 2, "green", "false");
        //            //////}
        //            //////else
        //            {
        //                // HOperatorSet.SetPart(windowHandle, 0, 0, new HTuple(width - 1), new HTuple(height - 1));
        //                //HOperatorSet.DispObj(image, windowHandle);
        //                imageWindowControl.HobjectToHimage(image);
        //            }
        //            Frm_ImageWindow.currentImage = image;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //      //  LogHelper.SaveErrorInfo(ex);
        //    }
        //}
        /// <summary>
        /// 显示图像
        /// </summary>
        //internal void ShowImage(string jobName, HObject image)
        //{
        //    try
        //    {
        //        foreach (KeyValuePair<string, Frm_ImageWindow> item in Frm_ImageWindow.D_imageWindow)
        //        {
        //            if (item.Key == Job.GetJobByName(jobName).debugImageWindow)
        //            {
        //                if ((Machine.runStatu != MachineRunStatu.Running && !Job.GetJobByName(jobName).isRunLoop )
        //                    ||(Machine.runStatu != MachineRunStatu.Running && Job.GetJobByName(jobName).isRunLoop)&& Job.GetJobByName(jobName).jobName ==Frm_Job .Instance .tbc_jobs .SelectedTab .Text ) 
        //                    item.Value.Show();
        //                Display_Image(image, item.Value.hwc_imageWindow);
        //                return;
        //            }
        //        }
        //        if (!Machine.loading)           
        //        {
        //            if (Frm_ImageWindow.D_imageWindow.Count > 0)
        //            {
        //                Job.GetJobByName(jobName).debugImageWindow = Frm_ImageWindow.D_imageWindow.Values.ToArray()[0].Text;
        //                Frm_Main.Instance.OutputMsg(Configuration.language == Language.English ? "The process was successfully run,Elapsed：" : "此流程未绑定图像窗体或所绑定的图像窗口已被删除，已自动更换为默认图像窗体", Color.Red);

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //       // LogHelper.SaveErrorInfo(ex);
        //    }
        //}
        /// <summary>
        /// 设置线的样式
        /// </summary>
        internal void SetLineStyle(string jobName, int style)
        {
            try
            {
                //foreach (KeyValuePair<string, Frm_ImageWindow> item in Frm_Main.Instance.D_imageWindow)
                //{
                //    if (item.Key == Job.GetJobByName(jobName).debugImageWindow)
                //    {
                //        if (style == 0)
                //            HOperatorSet.SetLineStyle(item.Value.hwc_imageWindow.HWindowHalconID, new HTuple());
                //        else
                //            HOperatorSet.SetLineStyle(item.Value.hwc_imageWindow.HWindowHalconID, new HTuple(style));
                //    }
                //}
            }
            catch (Exception ex)
            {
             //   LogHelper.SaveErrorInfo(ex);
            }
        }
        /// <summary>
        /// 通过流程名获取窗体句柄
        /// </summary>
        /// <param name="jobName"></param>
        /// <returns></returns>
        //internal Frm_ImageWindow  GetImageWindowControl(string jobName)
        //{
        //    try
        //    {
        //        foreach (KeyValuePair<string, Frm_ImageWindow> item in Frm_ImageWindow.D_imageWindow)
        //        {
        //            if (item.Key == Job.GetJobByName(jobName).debugImageWindow)
        //            {
        //                      if ((Machine.runStatu != MachineRunStatu.Running && !Job.GetJobByName(jobName).isRunLoop )
        //                    ||(Machine.runStatu != MachineRunStatu.Running && Job.GetJobByName(jobName).isRunLoop)&& Job.GetJobByName(jobName).jobName ==Frm_Job .Instance .tbc_jobs .SelectedTab .Text ) 
        //                    item.Value.Show();              //切换到当前图像窗体
        //                return item.Value;
        //            }
        //        }
        //        //////if (Frm_ImageWindow.D_imageWindow.Count > 0)
        //        //////{
        //        //////    Job.GetJobByName(jobName).debugImageWindow = Frm_ImageWindow.D_imageWindow.Values.ToArray()[0].Text;
        //        //////    Frm_Main.Instance.OutputMsg(Configuration.language == Language.English ? "The process was successfully run,Elapsed：" : "此流程所绑定的窗体不存在，已自动更换为默认图像窗体", Color.Red);

        //        //////}
        //        return Frm_ImageWindow.Instance;
        //    }
        //    catch (Exception ex)
        //    {
        //     //   LogHelper.SaveErrorInfo(ex);
        //        return null;
        //    }
        //}
        /// <summary>
        /// 显示对象
        /// </summary>
        internal void ShowObj(string jobName, HObject obj)
        {
            //try
            //{
            //    foreach (KeyValuePair<string, Frm_ImageWindow> item in Frm_Main.Instance.D_imageWindow)
            //    {
            //        if (item.Key == Job.GetJobByName(jobName).debugImageWindow)
            //        {
            //            HOperatorSet.DispObj(obj, item.Value.hwc_imageWindow.HWindowHalconID);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //   LogHelper.SaveErrorInfo(ex);
            //}
        }
        /// <summary>
        /// 清除图像
        /// </summary>
        internal void ClearWindow(string jobName)
        {
            //try
            //{
            //    foreach (KeyValuePair<string, Frm_ImageWindow> item in Frm_Main.Instance.D_imageWindow)
            //    {
            //        if (item.Key == Job.GetJobByName(jobName).debugImageWindow)
            //        {
            //            HOperatorSet.ClearWindow(item.Value.hwc_imageWindow.HWindowHalconID);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //   LogHelper.SaveErrorInfo(ex);
            //}
        }
        /// <summary>
        /// 开始绘制模式
        /// </summary>
        internal void Start_Draw_Mode(string jobName)
        {
            //try
            //{
            //    foreach (KeyValuePair<string, Frm_ImageWindow> item in Frm_Main.Instance.D_imageWindow)
            //    {
            //        if (item.Key == Job.GetJobByName(jobName).debugImageWindow)
            //        {
            //            item.Value.hwc_imageWindow.ContextMenuStrip = null;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //   LogHelper.SaveErrorInfo(ex);
            //}
        }
        /// <summary>
        /// 结束绘制模式
        /// </summary>
        internal void End_Draw_Mode(string jobName)
        {
            //try
            //{
            //    foreach (KeyValuePair<string, Frm_ImageWindow> item in Frm_Main.Instance.D_imageWindow)
            //    {
            //        if (item.Key == Job.GetJobByName(jobName).debugImageWindow)
            //        {
            //            item.Value.hwc_imageWindow.ContextMenuStrip = Frm_ImageWindow.Instance.cnt_rightClickMenu;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //   LogHelper.SaveErrorInfo(ex);
            //}
        }
        /// <summary>
        /// 设置线宽
        /// </summary>
        internal void SetLineWidth(string jobName, int width)
        {
            //try
            //{
            //    foreach (KeyValuePair<string, Frm_ImageWindow> item in Frm_Main.Instance.D_imageWindow)
            //    {
            //        if (item.Key == Job.GetJobByName(jobName).debugImageWindow)
            //        {
            //            HOperatorSet.SetLineWidth(item.Value.hwc_imageWindow.HWindowHalconID, new HTuple(width));
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //   LogHelper.SaveErrorInfo(ex);
            //}
        }
        /// <summary>
        /// 设置填充模式
        /// </summary>
        internal void SetDraw(string jobName, string drawStyle)
        {
            //try
            //{
            //    foreach (KeyValuePair<string, Frm_ImageWindow> item in Frm_Main.Instance.D_imageWindow)
            //    {
            //        if (item.Key == Job.GetJobByName(jobName).debugImageWindow)
            //        {
            //            HOperatorSet.SetDraw(item.Value.hwc_imageWindow.HWindowHalconID, new HTuple(drawStyle));
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //   LogHelper.SaveErrorInfo(ex);
            //}
        }

        /// <summary>
        /// 设置颜色
        /// </summary>
        //internal void SetColor(string jobName, string color)
        //{
        //    try
        //    {
        //        foreach (KeyValuePair<string, Frm_ImageWindow> item in Frm_ImageWindow.D_imageWindow)
        //        {
        //            if (item.Key == Job.GetJobByName(jobName).debugImageWindow)
        //            {
        //                HOperatorSet.SetColor(item.Value.hwc_imageWindow.HWindowHalconID, new HTuple(color));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //       // LogHelper.SaveErrorInfo(ex);
        //    }
        //}

    }
    /// <summary>
    /// 工具运行状态
    /// </summary>
    public enum ToolRunStatu
    {
        Not_Run,
        Not_Enabled,
        No_Input_Image,
        Not_Input_Image,
        Character_Untrained,
        Not_Assign_Image_Template,
        Not_Assign_Input_Image,
        Not_Assign_Input_Source,
        Not_Assign_Input_Pos,
        Not_Asign_Input_Source,
        Lack_Of_Input_Image,
        Lack_Of_Input_Search_Region,
        Not_Assign_Path,
        Not_Asign_Input_Image,
        Input_Image_Cannot_Be_Converted,
        Not_Create_Template,
        No_Image_In_Folder,
        File_Error_Or_Path_Invalid,
        Not_Assign_Acq_Device,
        Not_Succeed,
        Succeed,
        No_Input_String,
        未运行,
        未启用,
        缺少输入搜索区域,
        未指定路径,
        无输入图像,
        未创建模板,
        未训练字符,
        无输入字符串,
        未指定输入图像,
        未指定图像模板,
        缺少输入图像,
        未指定输入坐标点,
        未指定输入源,
        输入图像不能被转化,
        文件夹内无图像,
        图像文件异常或路径不合法,
        未指定采集设备,
        失败,
        成功,
    }

}
