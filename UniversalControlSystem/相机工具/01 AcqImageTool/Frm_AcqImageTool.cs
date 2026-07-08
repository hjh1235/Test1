using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using HalconDotNet;

namespace VMPro
{
    internal partial class Frm_AcqImageTool : Frm_FormBase
    {
        internal Frm_AcqImageTool()
        {
            InitializeComponent();
            hWindow_Final1.hWindowControl.MouseUp += Hwindow_MouseUp;
        }

        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static Frm_AcqImageTool _instance;
        public static Frm_AcqImageTool Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_AcqImageTool();
                return _instance;
            }
        }
        /// <summary>
        /// 指示当前正在调整的参数
        /// </summary>
        internal static int selectedIndex = 0;
        /// <summary>
        /// 工具对象
        /// </summary>
        internal static AcqImageTool acqImageTool = new AcqImageTool();
        /// <summary>
        /// 图像显示区域
        /// </summary>
        internal List<ViewWindow.Model.ROI> L_regions = new List<ViewWindow.Model.ROI>();


        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="jobName">流程名</param>
        /// <param name="toolInfo">工具</param>
        internal void ShowForm(string jobName, ToolInfo toolInfo)
        {
            try
            {
                if (Frm_AcqImageTool.isShown && Frm_AcqImageTool.Instance.jobName == jobName && Frm_AcqImageTool.Instance.toolName == toolInfo.tool.toolName)     //如果当前工具以显示，只是最小化了，那就直接显示即可
                {
                    Frm_AcqImageTool.Instance.WindowState = FormWindowState.Normal;
                    Frm_AcqImageTool.Instance.Activate();
                    return;
                }

                lbl_title.Text = (Project.Instance.configuration.language == Language.English ? "SDK_PointGray" : string.Format("采集图像    [ {0} . {1} ]", jobName, toolInfo.tool.toolName));
                AcqImageTool acqImageTool = (AcqImageTool)toolInfo.tool;

                Frm_AcqImageTool.Instance.jobName = jobName;
                Frm_AcqImageTool.Instance.toolName = toolInfo.tool.toolName;
                Frm_AcqImageTool.acqImageTool = acqImageTool;

                Frm_FromFile.Instance.jobName = jobName;
                Frm_FromFile.Instance.toolName = toolInfo.tool.toolName;
                Frm_FromFile.acqImageTool = acqImageTool;

                Frm_FromDirectory.Instance.jobName = jobName;
                Frm_FromDirectory.Instance.toolName = toolInfo.tool.toolName;
                Frm_FromDirectory.acqImageTool = acqImageTool;

                Frm_FromCamera.Instance.jobName = jobName;
                Frm_FromCamera.Instance.toolName = toolInfo.tool.toolName;
                Frm_FromCamera.acqImageTool = acqImageTool;

                Frm_MoreSetting.acqImageTool = acqImageTool;

                Frm_AcqImageTool.Instance.WindowState = FormWindowState.Normal;
                Frm_AcqImageTool.Instance.Show();
                isShown = true;
                Application.DoEvents();

                //当前图像显示
                if (acqImageTool.toolPar.ResultPar.图像 != null)
                    hWindow_Final1.HobjectToHimage(acqImageTool.toolPar.ResultPar.图像);
                else
                    hWindow_Final1.ClearWindow();

                if (!acqImageTool.b_allImageRegion)
                {
                    hWindow_Final1.viewWindow.displayROI(acqImageTool.L_regions);
                    L_regions = acqImageTool.L_regions;
                }

                acqImageTool.SwitchImageSource(acqImageTool.imageSource);

                //如未指定相机，则自动指定第一个相机
                if (acqImageTool.SDK_Camera == null)
                {
                    if (AcqImageTool.L_SDKCamera.Count > 0)
                    {
                        acqImageTool.SDK_Camera = AcqImageTool.L_SDKCamera[0];
                        if (acqImageTool.imageSource == ImageSource.FromCamera)
                            acqImageTool.Run(true);
                    }
                    else
                    {
                        lbl_toolTip.ForeColor = Color.Red;
                        lbl_toolTip.Text = "提示：未指定相机";
                    }
                }

                if (acqImageTool.SDK_Camera != null)
                    Frm_FromCamera.Instance.cbx_cameraList.TextStr = acqImageTool.SDK_Camera.CameraInfoStr;

                Frm_FromCamera.Instance.nud_exposureTime.Value = acqImageTool.exposureTime;
                Frm_FromCamera.Instance.nud_gain.Value = acqImageTool.gain;

                ckb_autoSwitch.Checked = acqImageTool.b_autoSwitch;
                ckb_absPath.Checked = acqImageTool.b_absPath;
                ckb_hardTrig.Checked = acqImageTool.b_hardTrig;
                ckb_RGBToGray.Checked = acqImageTool.b_RGBToGray;
                ckb_allImageRegion.Checked = acqImageTool.b_allImageRegion;
                ckb_updateImage.Checked = acqImageTool.b_updateImage;
                ckb_rotateImage.Checked = (acqImageTool.imageSource == ImageSource.FromCamera ? acqImageTool.b_rotateImageForCamera : acqImageTool.b_rotateImageForLocal);
                nud_rotateAngle.Value = (acqImageTool.imageSource == ImageSource.FromCamera ? acqImageTool.rotateAngleForCamera : acqImageTool.rotateAngleForLocal);

                Frm_FromFile.Instance.tbx_imagePath.Text = acqImageTool.imagePath;
                Frm_FromDirectory.Instance.tbx_imageDirectoryPath.Text = acqImageTool.imageDirectoryPath;

                Frm_MoreSetting.Instance.tbx_offsetV.Value = acqImageTool.offsetV;
                Frm_MoreSetting.Instance.tbx_offsetH.Value = acqImageTool.offsetH;
                Frm_MoreSetting.Instance.tbx_iamgeH.Value = acqImageTool.imageH;
                Frm_MoreSetting.Instance.tbx_imageW.Value = acqImageTool.imageW;

                if (acqImageTool.imageSource == ImageSource.FromDirectory)      //在当前图像上改变图像类型
                    acqImageTool.currentImageIndex--;
                btn_runTool_Click(null, null);
                Frm_AcqImageTool.Instance.Activate();
                btn_runTool.Focus();
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if ((keyData & Keys.Control) == Keys.Control)
                {
                    if ((keyData & Keys.S) == Keys.S)       //保存图像
                    {
                        acqImageTool.SaveImage();
                    }
                }
                else
                {
                    if (keyData == Keys.F5)         //工具运行一次
                    {
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        acqImageTool.Run(true);
                        long time = sw.ElapsedMilliseconds;
                        if (acqImageTool.toolRunStatu == (Project.Instance.configuration.language == Language.English ? ToolRunStatu.Succeed : ToolRunStatu.运行成功))
                        {
                            lbl_toolTip.ForeColor = Color.Black;
                            lbl_runTime.Text = string.Format("耗时：{0} ms", time.ToString());
                            if (acqImageTool.imageSource == ImageSource.FromDirectory)
                                lbl_toolTip.Text = string.Format("提示：当前图像：{0} ({1})", acqImageTool.currentImageName, acqImageTool.currentImageIndex + 1 + "/" + acqImageTool.L_images.Count);
                            else
                                lbl_toolTip.Text = "提示：" + acqImageTool.toolRunStatu.ToString();
                        }
                        else
                        {
                            lbl_toolTip.ForeColor = Color.Red;
                            lbl_runTime.Text = string.Format("耗时：0ms");
                            lbl_toolTip.Text = "提示：" + acqImageTool.toolRunStatu.ToString();
                        }
                    }
                    else if (keyData == Keys.Up)        //曝光时间增加
                    {
                        if (acqImageTool.imageSource == ImageSource.FromCamera)
                            Frm_FromCamera.Instance.nud_exposureTime.Value += 100;
                    }
                    else if (keyData == Keys.Down)        //曝光时间减小
                    {
                        if (acqImageTool.imageSource == ImageSource.FromCamera)
                            Frm_FromCamera.Instance.nud_exposureTime.Value -= 100;
                    }
                    else if (keyData == Keys.Escape)        //退出全屏
                    {
                        if (全屏ESC退出全屏ToolStripMenuItem.Checked)
                        {
                            全屏ESC退出全屏ToolStripMenuItem.Checked = false;
                            全屏ESC退出全屏ToolStripMenuItem.Text = "全屏（ESC退出全屏）";
                            panel3.Visible = true;
                            hWindow_Final1.Parent = tableLayoutPanel2;
                            this.WindowState = FormWindowState.Normal;
                            hWindow_Final1.m_CtrlHStatusLabelCtrl.BackColor = Color.White;
                        }
                    }
                    else if (keyData == Keys.Enter)        //让参数生效
                    {
                        try
                        {
                            this.Focus();
                            switch (selectedIndex)
                            {
                                case 0:      //正在调节曝光时间
                                    if (Frm_FromCamera.Instance.Visible)
                                        Frm_FromCamera.Instance.nud_exposureTime.SelectText();
                                    break;
                                case 1:      //正在调节增益
                                    if (Frm_FromCamera.Instance.Visible)
                                        Frm_FromCamera.Instance.nud_gain.SelectText();
                                    break;
                                case 2:      //正在图像旋转角度
                                    Frm_AcqImageTool.Instance.nud_rotateAngle.SelectText();
                                    break;
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
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
        private void Hwindow_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                int index;
                List<double> data;
                ViewWindow.Model.ROI roi = hWindow_Final1.viewWindow.smallestActiveROI(out data, out index);
                if (index > -1)
                {
                    string name = roi.GetType().Name;
                    this.L_regions[index] = roi;
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        private void tsb_livePlay_Click(object sender, EventArgs e)
        {
            acqImageTool.StartOrStopPlayImage(true, hWindow_Final1);
        }
        private void tsb_saveImage_Click(object sender, EventArgs e)
        {
            acqImageTool.SaveImage();
        }
        private void tsb_SDKInfo_Click(object sender, EventArgs e)
        {
            Frm_SDKInfo.Instance.ShowDialog();
        }
        private void tsb_resetTool_Click(object sender, EventArgs e)
        {
            acqImageTool.ResetTool();
        }
        private void 适应图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hWindow_Final1.DispImageFit();
        }
        private void 相机实时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acqImageTool.StartOrStopPlayImage(相机实时ToolStripMenuItem.Checked, hWindow_Final1);
        }
        private void 图像信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hWindow_Final1.m_CtrlHStatusLabelCtrl.BackColor = Color.White;
            hWindow_Final1.barVisible_strip_CheckedChanged(sender, e);
        }
        private void 全屏ESC退出全屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (全屏ESC退出全屏ToolStripMenuItem.Checked)
                {
                    全屏ESC退出全屏ToolStripMenuItem.Text = "退出全屏";
                    panel3.Visible = false;
                    hWindow_Final1.Parent = this;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    全屏ESC退出全屏ToolStripMenuItem.Text = "全屏（ESC退出全屏）";
                    panel3.Visible = true;
                    hWindow_Final1.Parent = tableLayoutPanel2;
                    this.WindowState = FormWindowState.Normal;
                    hWindow_Final1.m_CtrlHStatusLabelCtrl.BackColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        private void 保存图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            acqImageTool.SaveImage();
        }
        private void pic_fromDevice_Click(object sender, EventArgs e)
        {
            acqImageTool.SwitchImageSource(ImageSource.FromCamera);
            btn_runTool_Click(null, null);
        }
        private void pic_fromFile_Click(object sender, EventArgs e)
        {
            acqImageTool.SwitchImageSource(ImageSource.FromFile);
            btn_runTool_Click(null, null);
        }
        private void pic_fromDirectory_Click(object sender, EventArgs e)
        {
            acqImageTool.SwitchImageSource(ImageSource.FromDirectory);
            btn_runTool_Click(null, null);
        }
        private void rdo_fromDevice_CheckedChanged(object sender, EventArgs e)
        {
            if (Job.loadForm)
                return;

            if (rdo_fromDevice.Checked)
            {
                acqImageTool.SwitchImageSource(ImageSource.FromCamera);
                btn_runTool_Click(null, null);
            }
        }
        private void rdo_fromFile_CheckedChanged(object sender, EventArgs e)
        {
            if (Job.loadForm)
                return;

            if (rdo_fromFile.Checked)
            {
                acqImageTool.SwitchImageSource(ImageSource.FromFile);
                btn_runTool_Click(null, null);
            }
        }
        private void rdo_fromDirectory_CheckedChanged(object sender, EventArgs e)
        {
            if (Job.loadForm)
                return;

            if (rdo_fromDirectory.Checked)
            {
                acqImageTool.SwitchImageSource(ImageSource.FromDirectory);
                btn_runTool_Click(null, null);
            }
        }
        private void ckb_hardTrig_CheckChanged(bool Checked)
        {
            acqImageTool.b_hardTrig = Checked;
        }
        private void ckb_autoSwitch_CheckChanged(bool Checked)
        {
            acqImageTool.b_autoSwitch = Checked;
        }
        private void ckb_absPath_CheckChanged(bool Checked)
        {
            acqImageTool.b_absPath = Checked;
        }
        private void ckb_RGBToGray_CheckChanged(bool Checked)
        {
            if (Job.loadForm)
                return;

            acqImageTool.b_RGBToGray = Checked;
            if (acqImageTool.imageSource == ImageSource.FromDirectory)      //在当前图像上改变图像类型
                acqImageTool.currentImageIndex--;
            btn_runTool_Click(null, null);
        }
        private void ckb_allImageRegion_CheckChanged(bool Checked)
        {
            try
            {
                if (Job.loadForm)
                    return;

                if (Checked)
                {
                    acqImageTool.b_allImageRegion = true;
                    hWindow_Final1.HobjectToHimage(acqImageTool.toolPar.ResultPar.图像);
                }
                else
                {
                    acqImageTool.b_allImageRegion = false;
                    if (acqImageTool.L_regions.Count == 0)
                    {
                        HTuple width, height;
                        HOperatorSet.GetImageSize(acqImageTool.toolPar.ResultPar.图像, out width, out height);
                        hWindow_Final1.viewWindow.genRect1(height * 0.25, width * 0.25, height * 0.75, width * 0.75, ref acqImageTool.L_regions);
                    }
                    else
                        Frm_AcqImageTool.Instance.hWindow_Final1.viewWindow.displayROI(acqImageTool.L_regions);
                    this.L_regions = acqImageTool.L_regions;
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        private void ckb_updateImage_CheckChanged(bool Checked)
        {
            if (Job.loadForm)
                return;

            acqImageTool.b_updateImage = Checked;
        }
        private void ckb_rotateImage_CheckChanged(bool Checked)
        {
            try
            {
                if (acqImageTool.imageSource == ImageSource.FromCamera)
                {
                    acqImageTool.b_rotateImageForCamera = Checked;
                }
                else
                {
                    acqImageTool.b_rotateImageForLocal = Checked;
                }
                nud_rotateAngle.Visible = Checked;
                lbl_deg.Visible = Checked;
                if (acqImageTool.imageSource == ImageSource.FromDirectory)      //在当前图像上改变图像类型
                    acqImageTool.currentImageIndex--;

                if (!acqImageTool.b_livePlay)
                    btn_runTool_Click(null, null);
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        private void nud_rotateAngle_ValueChanged(double value)
        {
            try
            {
                if (Job.loadForm)
                    return;

                if (acqImageTool.imageSource == ImageSource.FromCamera)
                    acqImageTool.rotateAngleForCamera = (int)value;
                else
                    acqImageTool.rotateAngleForLocal = (int)value;

                if (acqImageTool.imageSource == ImageSource.FromDirectory)      //在当前图像上改变图像类型
                    acqImageTool.currentImageIndex--;
                btn_runTool_Click(null, null);
                Frm_AcqImageTool.selectedIndex = 2;
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        internal void btn_runTool_Click(object sender, EventArgs e)
        {
            try
            {
                btn_runTool.Enabled = false;
                acqImageTool.Run(true);
                btn_runTool.Enabled = true;

                TreeNode treeNode = Job.FindJobByName(jobName).GetToolNodeByNodeText(toolName);
                if (acqImageTool.toolRunStatu != (Project.Instance.configuration.language == Language.English ? ToolRunStatu.Succeed : ToolRunStatu.运行成功))
                {
                    if (Frm_Monitor.Instance.lbl_toolName.Text == toolName)
                        Frm_Monitor.Instance.lbl_statu.Text = acqImageTool.toolRunStatu.ToString();
                    treeNode.ForeColor = Color.Red;
                }
                else
                {
                    treeNode.ForeColor = Color.Green;
                }
                treeNode.ToolTipText = string.Format("状态：{0}\r\n耗时：{1}ms\r\n说明：{2}", acqImageTool.toolRunStatu.ToString(), 0, Job.FindJobByName(jobName).FindToolInfoByName(toolName).toolTipInfo);
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        private void btn_runJob_Click(object sender, EventArgs e)
        {
            if (jobName != "系统")
            {
                btn_runJob.Enabled = false;
                this.TopMost = true;
                btn_topLevel.Image = Resources.钉;
                Job.FindJobByName(jobName).Run(true);
                btn_runJob.Enabled = true;
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();

            //退出窗体时自动停止相机实时
            if (acqImageTool.b_livePlay)
                acqImageTool.StartOrStopPlayImage(false, hWindow_Final1);

            if (jobName != "系统")        //有一个系统图像工具，它不存在输入输出
                acqImageTool.UpdateOutput(toolName);
        }
        internal override void btn_baseClose_Click(object sender, EventArgs e)
        {
            try
            {
                base.btn_baseClose_Click(sender, e);

                //退出窗体时自动停止相机实时
                if (acqImageTool.b_livePlay)
                    acqImageTool.StartOrStopPlayImage(false, hWindow_Final1);

                if (jobName != "系统")        //有一个系统图像工具，它不存在输入输出
                    acqImageTool.UpdateOutput(toolName);
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        private void Frm_AcqImageTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            isShown = false;
        }

    }
}
