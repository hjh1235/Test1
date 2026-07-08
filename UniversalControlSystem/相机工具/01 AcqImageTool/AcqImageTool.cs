using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using VMPro.Properties;
using Ookii.Dialogs.WinForms;
using System.Text.RegularExpressions;
using HalconDotNet;
using ChoiceTech.Halcon.Control;
using System.Diagnostics;

namespace VMPro
{
    [Serializable]
    class AcqImageTool : ToolBase
    {

        /// <summary>
        /// 工具参数
        /// </summary>
        internal ToolPar toolPar = new ToolPar();
        /// <summary>
        /// 相机集合
        /// </summary>
        internal static List<SDK_Base> L_SDKCamera = new List<SDK_Base>();
        /// <summary>
        /// 图像来源
        /// </summary>
        internal ImageSource imageSource = ImageSource.FromCamera;
        /// <summary>
        /// 相机对象
        /// </summary>
        internal SDK_Base SDK_Camera = null;
        /// <summary>
        /// 曝光时间
        /// </summary>
        internal double exposureTime = 30;
        /// <summary>
        /// 增益
        /// </summary>
        internal int gain = 0;
        /// <summary>
        /// 硬触发模式  启用|不启用
        /// </summary>
        internal bool b_hardTrig = false;
        /// <summary>
        /// 读取文件夹图像模式时每次运行自动切换图像  是|否
        /// </summary>
        internal bool b_autoSwitch = true;
        /// <summary>
        /// 读取单个图像或读取文件夹图像时文件路径模式  绝对路径|相对路径
        /// </summary>
        internal bool b_absPath = true;
        /// <summary>
        /// 当前处于实时采集模式  是|否
        /// </summary>
        internal bool b_livePlay = false;
        /// <summary>
        /// 相机实时线程
        /// </summary>
        internal static Thread th_livePlay = null;
        /// <summary>
        /// 从相机采集图像时旋转图像  是|否
        /// </summary>
        internal bool b_rotateImageForCamera = false;
        /// <summary>
        /// 从相机采集图像时图像旋转角度
        /// </summary>
        internal int rotateAngleForCamera = 180;
        /// <summary>
        /// 从本地读取图像时旋转图像  是|否
        /// </summary>
        internal bool b_rotateImageForLocal = false;
        /// <summary>
        /// 从本地读取图像时图像旋转角度
        /// </summary>
        internal int rotateAngleForLocal = 180;
        /// <summary>
        /// 是否将彩色图像转化成灰度图像  是|否
        /// </summary>
        internal bool b_RGBToGray = true;
        /// <summary>
        /// 自动运行时是否显示整个图像区域  是|否
        /// </summary>
        internal bool b_allImageRegion = true;
        /// <summary>
        /// 是否刷新图像
        /// </summary>
        internal bool b_updateImage = true;
        /// <summary>
        /// 自动运行如不显示整个图像区域时的图像ROI
        /// </summary>
        internal List<ViewWindow.Model.ROI> L_regions = new List<ViewWindow.Model.ROI>();
        /// <summary>
        /// 读取文件夹图像时，当前图片的索引
        /// </summary>
        internal int currentImageIndex = 0;
        /// <summary>
        /// 读取文件夹图像时，当前图像的名称
        /// </summary>
        internal string currentImageName = string.Empty;
        /// <summary>
        /// 读取文件夹图像时，图像路径集合
        /// </summary>
        internal List<string> L_images = new List<string>();
        /// <summary>
        /// 读取单张图像时，图像文件路径
        /// </summary>
        internal string imagePath = string.Empty;
        /// <summary>
        /// 读取文件夹图像时，图像文件夹路径
        /// </summary>
        internal string imageDirectoryPath = string.Empty;
        /// <summary>
        /// 保存图像的路径
        /// </summary>
        private static string savePath = string.Empty;
        /// <summary>
        /// 左上行
        /// </summary>
        internal int offsetV = 0;
        /// <summary>
        /// 左上列
        /// </summary>
        internal int offsetH = 0;
        /// <summary>
        /// 右下行
        /// </summary>
        internal int imageH = 1944;
        /// <summary>
        /// 右下列
        /// </summary>
        internal int imageW = 2592;


        /// <summary>
        /// 图像源切换
        /// </summary>
        /// <param name="imageSource">新的图像源</param>
        internal void SwitchImageSource(ImageSource imageSource)
        {
            try
            {
                this.imageSource = imageSource;
                switch (imageSource)
                {
                    case ImageSource.FromCamera:
                        Frm_AcqImageTool.Instance.rdo_fromDevice.Checked = true;

                        Frm_AcqImageTool.Instance.pic_fromDevice.Image = Resources.勾选;
                        Frm_AcqImageTool.Instance.pic_fromFile.Image = Resources.去勾选;
                        Frm_AcqImageTool.Instance.pic_fromDirectory.Image = Resources.去勾选;

                        Frm_AcqImageTool.Instance.rdo_fromDevice.ForeColor = Color.FromArgb(80, 160, 255);
                        Frm_AcqImageTool.Instance.rdo_fromFile.ForeColor = Color.Black;
                        Frm_AcqImageTool.Instance.rdo_fromDirectory.ForeColor = Color.Black;

                        Frm_AcqImageTool.Instance.rdo_fromDevice.Font = new Font(Frm_AcqImageTool.Instance.rdo_fromDevice.Font.Name, Frm_AcqImageTool.Instance.rdo_fromDevice.Font.Size, FontStyle.Bold);
                        Frm_AcqImageTool.Instance.rdo_fromFile.Font = new Font(Frm_AcqImageTool.Instance.rdo_fromFile.Font.Name, Frm_AcqImageTool.Instance.rdo_fromFile.Font.Size, FontStyle.Regular);
                        Frm_AcqImageTool.Instance.rdo_fromDirectory.Font = new Font(Frm_AcqImageTool.Instance.rdo_fromDirectory.Font.Name, Frm_AcqImageTool.Instance.rdo_fromDirectory.Font.Size, FontStyle.Regular);

                        Frm_AcqImageTool.Instance.pnl_formPanel.Controls.Clear();
                        Frm_FromCamera.Instance.TopLevel = false;
                        Frm_FromCamera.Instance.Parent = Frm_AcqImageTool.Instance.pnl_formPanel;
                        Frm_FromCamera.Instance.Dock = DockStyle.Top;
                        Frm_FromCamera.Instance.Show();

                        Frm_AcqImageTool.Instance.ckb_hardTrig.Visible = true;
                        Frm_AcqImageTool.Instance.ckb_hardTrig.Location = new System.Drawing.Point(4, 340);
                        Frm_AcqImageTool.Instance.ckb_autoSwitch.Visible = false;
                        Frm_AcqImageTool.Instance.ckb_absPath.Visible = false;
                        Frm_AcqImageTool.Instance.tsb_livePlay.Enabled = true;
                        Frm_AcqImageTool.Instance.相机实时ToolStripMenuItem.Visible = true;

                        Frm_AcqImageTool.Instance.ckb_rotateImage.Checked = b_rotateImageForCamera;
                        Frm_AcqImageTool.Instance.nud_rotateAngle.Value = rotateAngleForCamera;
                        break;
                    case ImageSource.FromFile:
                        Frm_AcqImageTool.Instance.rdo_fromFile.Checked = true;

                        Frm_AcqImageTool.Instance.pic_fromDevice.Image = Resources.去勾选;
                        Frm_AcqImageTool.Instance.pic_fromFile.Image = Resources.勾选;
                        Frm_AcqImageTool.Instance.pic_fromDirectory.Image = Resources.去勾选;

                        Frm_AcqImageTool.Instance.rdo_fromDevice.ForeColor = Color.Black;
                        Frm_AcqImageTool.Instance.rdo_fromFile.ForeColor = Color.FromArgb(80, 160, 255);
                        Frm_AcqImageTool.Instance.rdo_fromDirectory.ForeColor = Color.Black;

                        Frm_AcqImageTool.Instance.rdo_fromDevice.Font = new Font(Frm_AcqImageTool.Instance.rdo_fromDevice.Font.Name, Frm_AcqImageTool.Instance.rdo_fromDevice.Font.Size, FontStyle.Regular);
                        Frm_AcqImageTool.Instance.rdo_fromFile.Font = new Font(Frm_AcqImageTool.Instance.rdo_fromFile.Font.Name, Frm_AcqImageTool.Instance.rdo_fromFile.Font.Size, FontStyle.Bold);
                        Frm_AcqImageTool.Instance.rdo_fromDirectory.Font = new Font(Frm_AcqImageTool.Instance.rdo_fromDirectory.Font.Name, Frm_AcqImageTool.Instance.rdo_fromDirectory.Font.Size, FontStyle.Regular);

                        Frm_AcqImageTool.Instance.pnl_formPanel.Controls.Clear();
                        Frm_FromFile.Instance.TopLevel = false;
                        Frm_FromFile.Instance.Parent = Frm_AcqImageTool.Instance.pnl_formPanel;
                        Frm_FromFile.Instance.Dock = DockStyle.Top;
                        Frm_FromFile.Instance.Show();

                        Frm_AcqImageTool.Instance.ckb_hardTrig.Visible = false;
                        Frm_AcqImageTool.Instance.ckb_hardTrig.Location = new System.Drawing.Point(4, 316);
                        Frm_AcqImageTool.Instance.ckb_autoSwitch.Visible = false;
                        Frm_AcqImageTool.Instance.ckb_absPath.Visible = true;
                        Frm_AcqImageTool.Instance.tsb_livePlay.Enabled = false;
                        Frm_AcqImageTool.Instance.相机实时ToolStripMenuItem.Visible = false;

                        Frm_AcqImageTool.Instance.ckb_rotateImage.Checked = b_rotateImageForLocal;
                        Frm_AcqImageTool.Instance.nud_rotateAngle.Value = rotateAngleForLocal;
                        break;
                    case ImageSource.FromDirectory:
                        Frm_AcqImageTool.Instance.rdo_fromDirectory.Checked = true;

                        Frm_AcqImageTool.Instance.pic_fromDevice.Image = Resources.去勾选;
                        Frm_AcqImageTool.Instance.pic_fromFile.Image = Resources.去勾选;
                        Frm_AcqImageTool.Instance.pic_fromDirectory.Image = Resources.勾选;

                        Frm_AcqImageTool.Instance.rdo_fromDevice.ForeColor = Color.Black;
                        Frm_AcqImageTool.Instance.rdo_fromFile.ForeColor = Color.Black;
                        Frm_AcqImageTool.Instance.rdo_fromDirectory.ForeColor = Color.FromArgb(80, 160, 255);

                        Frm_AcqImageTool.Instance.rdo_fromDevice.Font = new Font(Frm_AcqImageTool.Instance.rdo_fromDevice.Font.Name, Frm_AcqImageTool.Instance.rdo_fromDevice.Font.Size, FontStyle.Regular);
                        Frm_AcqImageTool.Instance.rdo_fromFile.Font = new Font(Frm_AcqImageTool.Instance.rdo_fromFile.Font.Name, Frm_AcqImageTool.Instance.rdo_fromFile.Font.Size, FontStyle.Regular);
                        Frm_AcqImageTool.Instance.rdo_fromDirectory.Font = new Font(Frm_AcqImageTool.Instance.rdo_fromDirectory.Font.Name, Frm_AcqImageTool.Instance.rdo_fromDirectory.Font.Size, FontStyle.Bold);

                        Frm_AcqImageTool.Instance.pnl_formPanel.Controls.Clear();
                        Frm_FromDirectory.Instance.TopLevel = false;
                        Frm_FromDirectory.Instance.Parent = Frm_AcqImageTool.Instance.pnl_formPanel;
                        Frm_FromDirectory.Instance.Dock = DockStyle.Top;
                        Frm_FromDirectory.Instance.Show();

                        Frm_AcqImageTool.Instance.ckb_hardTrig.Visible = false;
                        Frm_AcqImageTool.Instance.ckb_hardTrig.Location = new System.Drawing.Point(4, 316);
                        Frm_AcqImageTool.Instance.ckb_autoSwitch.Visible = true;
                        Frm_AcqImageTool.Instance.ckb_absPath.Visible = true;
                        Frm_AcqImageTool.Instance.tsb_livePlay.Enabled = false;
                        Frm_AcqImageTool.Instance.相机实时ToolStripMenuItem.Visible = false;

                        Frm_AcqImageTool.Instance.ckb_rotateImage.Checked = b_rotateImageForLocal;
                        Frm_AcqImageTool.Instance.nud_rotateAngle.Value = rotateAngleForLocal;
                        break;
                }
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 切换相机
        /// </summary>
        /// <param name="cameraInfoStr">相机信息字符串</param>
        internal void SwitchCamera(string cameraInfoStr)
        {
            try
            {
                if (Frm_FromCamera.Instance.cbx_cameraList.TextStr == string.Empty)
                    this.SDK_Camera = null;
                else
                {
                    for (int i = 0; i < L_SDKCamera.Count; i++)
                    {
                        if (L_SDKCamera[i].CameraInfoStr == cameraInfoStr)
                        {
                            Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Black;
                            Frm_AcqImageTool.Instance.lbl_toolTip.Text = "提示：当前相机：" + cameraInfoStr;
                            SDK_Camera = L_SDKCamera[i];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 复位工具
        /// </summary>
        internal override void ResetTool()
        {
            try
            {
                exposureTime = 30;
                gain = 0;
                imagePath = string.Empty;
                imageDirectoryPath = string.Empty;
                if (imageSource != ImageSource.FromCamera)            //避免切换时出现闪烁现象
                    SwitchImageSource(ImageSource.FromCamera);

                Frm_AcqImageTool.Instance.hWindow_Final1.ClearWindow();
                Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Black;
                Frm_AcqImageTool.Instance.lbl_toolTip.Text = "提示：暂无提示";
                Frm_AcqImageTool.Instance.lbl_runTime.Text = "耗时：0 ms";
                Frm_AcqImageTool.Instance.ckb_autoSwitch.Checked = true;
                Frm_AcqImageTool.Instance.ckb_RGBToGray.Checked = true;
                Frm_AcqImageTool.Instance.ckb_allImageRegion.Checked = true;

                Frm_FromCamera.Instance.cbx_cameraList.TextStr = string.Empty;
                Frm_FromCamera.Instance.nud_exposureTime.Value = 30;
                Frm_FromCamera.Instance.nud_gain.Value = 0;
                Frm_FromFile.Instance.tbx_imagePath.Text = string.Empty;
                Frm_FromDirectory.Instance.tbx_imageDirectoryPath.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 选择图像文件
        /// </summary>
        internal void SelectImage()
        {
            try
            {
                System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
                openFileDialog.Title = (Project.Instance.configuration.language == Language.English ? "Please select image path" : "请选择图像文件路径");
                if (imagePath == string.Empty)      //如果添加工具后第一次选择图像文件
                {
                    if (b_absPath)      //绝对路径：图像文件的路径是绝对的
                        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    else                //相对路径：图像文件的路径是相对于程序输出目录的
                        openFileDialog.InitialDirectory = Application.StartupPath;
                }
                else      //如果添加工具后不是第一次选择图像文件
                {
                    if (b_absPath)
                        openFileDialog.InitialDirectory = Path.GetDirectoryName(imagePath);
                    else
                    {
                        if (File.Exists(Application.StartupPath + imagePath))
                            openFileDialog.InitialDirectory = Application.StartupPath + imagePath;
                        else
                            openFileDialog.InitialDirectory = Application.StartupPath;
                    }
                }
                openFileDialog.Filter = (Project.Instance.configuration.language == Language.English ? "Image File(*.*)|*.*|Image File(*.png)|*.png|Image File(*.jpg)|*.jpg|Image File(*.tif)|*.tif" : "图像文件(*.*)|*.*|图像文件(*.jpg)|*.jpg|图像文件(*.png)|*.png|图像文件(*.bmp)|*.bmp|图像文件(*.tif)|*.tif");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (b_absPath)
                    {
                        imagePath = openFileDialog.FileName;
                    }
                    else
                    {
                        if (openFileDialog.FileName.StartsWith(Application.StartupPath))       //相对路径模式下，只允许选择程序输出目录下的路径
                        {
                            imagePath = openFileDialog.FileName.Substring(Application.StartupPath.Length, openFileDialog.FileName.Length - Application.StartupPath.Length);
                        }
                        else
                        {
                            Frm_MessageBox.Instance.MessageBoxShow("\r\n相对路径模式下只能指定程序输出目录下的路径，路径指定失败！", TipType.Error);
                            return;
                        }
                    }

                    Frm_FromFile.Instance.tbx_imagePath.Text = imagePath;
                    Frm_AcqImageTool.Instance.btn_runTool_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 选择图像文件夹
        /// </summary>
        internal void SelectDirectory()
        {
            try
            {
                VistaFolderBrowserDialog vistaFolderBrowserDialog = new VistaFolderBrowserDialog();
                if (imageDirectoryPath == string.Empty)
                {
                    if (b_absPath)
                        vistaFolderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    else
                        vistaFolderBrowserDialog.SelectedPath = Application.StartupPath;
                }
                else
                {
                    if (b_absPath)
                        vistaFolderBrowserDialog.SelectedPath = imageDirectoryPath;
                    else
                    {
                        if (Directory.Exists(Application.StartupPath + imageDirectoryPath))
                            vistaFolderBrowserDialog.SelectedPath = Application.StartupPath + imageDirectoryPath;
                        else
                            vistaFolderBrowserDialog.SelectedPath = Application.StartupPath;
                    }
                }
                vistaFolderBrowserDialog.Description = (Project.Instance.configuration.language == Language.English ? "Please select image folder" : "请选择图像文件夹路径");
                if (vistaFolderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    if (b_absPath)
                    {
                        imageDirectoryPath = vistaFolderBrowserDialog.SelectedPath;
                    }
                    else
                    {
                        if (vistaFolderBrowserDialog.SelectedPath.StartsWith(Application.StartupPath))
                        {
                            imageDirectoryPath = vistaFolderBrowserDialog.SelectedPath.Substring(Application.StartupPath.Length, vistaFolderBrowserDialog.SelectedPath.Length - Application.StartupPath.Length);
                        }
                        else
                        {
                            Frm_MessageBox.Instance.MessageBoxShow("\r\n相对路径模式下只能指定程序输出目录下的路径，路径指定失败！", TipType.Error);
                            return;
                        }
                    }

                    Frm_FromDirectory.Instance.tbx_imageDirectoryPath.Text = imageDirectoryPath;
                    L_images.Clear();
                    string[] files = Directory.GetFiles(vistaFolderBrowserDialog.SelectedPath);
                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo fileInfo = new FileInfo(files[i]);
                        if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png" || fileInfo.Extension == ".bmp" || fileInfo.Extension == ".tif")
                            L_images.Add(files[i]);
                    }

                    currentImageIndex = L_images.Count - 1;
                    Frm_AcqImageTool.Instance.btn_runTool_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 读取文件夹中上一张图像
        /// </summary>
        internal void LastImage()
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                HObject image;
                HOperatorSet.GenEmptyObj(out image);
                currentImageIndex--;
                if (currentImageIndex < 0)
                    currentImageIndex = L_images.Count - 1;
                try
                {
                    HOperatorSet.ReadImage(out image, L_images[currentImageIndex]);

                    //采图转灰度图
                    if (b_RGBToGray)
                    {
                        HTuple chNum;
                        HOperatorSet.CountChannels(image, out chNum);
                        if (chNum == 3)
                            HOperatorSet.Rgb1ToGray(image, out image);
                    }

                    //旋转图像
                    if (b_rotateImageForLocal)
                        HOperatorSet.RotateImage(image, out image, rotateAngleForLocal, "constant");
                }
                catch
                {
                    Frm_AcqImageTool.Instance.lbl_runTime.Text = "耗时：0 ms";
                    Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                    Frm_AcqImageTool.Instance.lbl_toolTip.Text = (Project.Instance.configuration.language == Language.English ? "There's a problem with the file or the path is invalid(ErrorCode:1102)" : "提示：图像文件异常或路径不合法（错误代码：10103）");
                    return;
                }
                currentImageName = Path.GetFileName(L_images[currentImageIndex]);
                Frm_AcqImageTool.Instance.hWindow_Final1.HobjectToHimage(image);

                long time = sw.ElapsedMilliseconds;
                Frm_AcqImageTool.Instance.lbl_runTime.Text = string.Format("耗时：{0} ms", time.ToString());
                Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Black;
                Frm_AcqImageTool.Instance.lbl_toolTip.Text = string.Format("提示：运行成功，当前图像：{0}  ({1})", currentImageName, currentImageIndex + 1 + "/" + L_images.Count);
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 读取文件夹中下一张图像
        /// </summary>
        internal void NextImage()
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                HObject image;
                HOperatorSet.GenEmptyObj(out image);
                currentImageIndex++;
                if (currentImageIndex > L_images.Count - 1)
                    currentImageIndex = 0;
                try
                {
                    HOperatorSet.ReadImage(out image, L_images[currentImageIndex]);

                    //采图转灰度图
                    if (b_RGBToGray)
                    {
                        HTuple chNum;
                        HOperatorSet.CountChannels(image, out chNum);
                        if (chNum == 3)
                            HOperatorSet.Rgb1ToGray(image, out image);
                    }

                    //旋转图像
                    if (b_rotateImageForLocal)
                        HOperatorSet.RotateImage(image, out image, rotateAngleForLocal, "constant");
                }
                catch
                {
                    Frm_AcqImageTool.Instance.lbl_runTime.Text = "耗时：0 ms";
                    Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                    Frm_AcqImageTool.Instance.lbl_toolTip.Text = (Project.Instance.configuration.language == Language.English ? "There's a problem with the file or the path is invalid(ErrorCode:1102)" : "提示：图像文件异常或路径不合法（错误代码：10104）");
                    return;
                }
                currentImageName = Path.GetFileName(L_images[currentImageIndex]);
                Frm_AcqImageTool.Instance.hWindow_Final1.HobjectToHimage(image);

                long time = sw.ElapsedMilliseconds;
                Frm_AcqImageTool.Instance.lbl_runTime.Text = string.Format("耗时：{0} ms", time.ToString());
                Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Black;
                Frm_AcqImageTool.Instance.lbl_toolTip.Text = string.Format("提示：运行成功，当前图像：{0}  ({1})", currentImageName, currentImageIndex + 1 + "/" + L_images.Count);
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 开始或者停止相机实时
        /// </summary>
        /// <param name="runTool">是否从工具中触发</param>
        /// <param name="window">要实时显示的窗体对象</param>
        /// <param name="showDefinition">是否显示辨析力信息</param>
        internal void StartOrStopPlayImage(bool runTool, HWindow_Final window, bool showDefinition = false)
        {
            try
            {
                if (SDK_Camera == null)
                {
                    Frm_AcqImageTool.Instance.tsb_livePlay.CheckState = CheckState.Unchecked;
                    Frm_AcqImageTool.Instance.相机实时ToolStripMenuItem.Checked = false;
                    if (runTool)
                    {
                        Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                        Frm_AcqImageTool.Instance.lbl_toolTip.Text = "提示：未指定相机，不可实时";
                    }
                    else
                    {
                        Frm_Output.Instance.OutputMsg(string.Format("流程 [{0}] 相机实时失败，原因：未指定采集设备", jobName), Color.Red);
                    }
                    return;
                }

                //检查当前相机是否存在，有的时候相机没通电，那么相机就不存在
                if (!SDK_Camera.CheckExist())
                {
                    Frm_AcqImageTool.Instance.hWindow_Final1.ClearWindow();
                    Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                    Frm_AcqImageTool.Instance.lbl_toolTip.Text = "提示：相机未识别，不可实时";
                    return;
                }

                if (!b_livePlay)        //如果当前未处于实时状态
                {
                    b_livePlay = true;
                    Frm_AcqImageTool.Instance.tsb_livePlay.CheckState = CheckState.Checked;
                    if (!runTool)
                        GetImageWindowControl(jobName).实时显示ToolStripMenuItem.Checked = true;
                    if (showDefinition)
                    {
                        Frm_FromCamera.Instance.btn_livePlay.Enabled = false;
                        Frm_FromCamera.Instance.btn_focusCamera.Text = "停止对焦";
                    }
                    else
                    {
                        Frm_FromCamera.Instance.btn_livePlay.Text = "停止实时";
                        Frm_FromCamera.Instance.btn_focusCamera.Enabled = false;
                    }

                    Frm_AcqImageTool.Instance.btn_runTool.Enabled = false;
                    Frm_AcqImageTool.Instance.btn_runJob.Enabled = false;
                    Frm_AcqImageTool.Instance.rdo_fromDevice.Enabled = false;
                    Frm_AcqImageTool.Instance.rdo_fromFile.Enabled = false;
                    Frm_AcqImageTool.Instance.rdo_fromDirectory.Enabled = false;
                    Frm_AcqImageTool.Instance.pic_fromFile.Enabled = false;
                    Frm_AcqImageTool.Instance.pic_fromDirectory.Enabled = false;

                    #region 相机实时

                    th_livePlay = new Thread(() =>
                    {
                        try
                        {
                            double maxDefinition = 0;       //清晰度最大值
                            SDK_Camera.SetAcquisitionMode(0);      //开始连续采集

                            while (b_livePlay)
                            {
                                toolPar.ResultPar.图像 = SDK_Camera.GrabOneImage();
                                if (b_rotateImageForCamera)
                                {
                                    HObject image;
                                    HOperatorSet.RotateImage(toolPar.ResultPar.图像, out image, rotateAngleForCamera, "constant");
                                    toolPar.ResultPar.图像 = image;
                                }

                                //彩色图像转灰度图像
                                if (b_RGBToGray)
                                {
                                    HTuple chNum;
                                    HOperatorSet.CountChannels(toolPar.ResultPar.图像, out chNum);
                                    if (chNum == 3)
                                    {
                                        HObject image;
                                        HOperatorSet.Rgb1ToGray(toolPar.ResultPar.图像, out image);
                                        toolPar.ResultPar.图像 = image;
                                    }
                                }

                                if (runTool)
                                    window.HobjectToHimage(toolPar.ResultPar.图像);
                                else
                                    ShowImage(toolPar.ResultPar.图像);

                                if (!showDefinition)
                                {
                                    if (runTool)
                                    {
                                        HTuple row1, col1, row2, col2;
                                        HOperatorSet.GetPart(window.HWindowHalconID, out row1, out col1, out row2, out col2);
                                        DispMessage(window.HWindowHalconID, "实时中...", 18, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "green", "false");
                                    }
                                    else
                                    {
                                        DispMessage(GetImageWindowControl().hwc_imageWindow.HWindowHalconID, "实时中...", 18, 20, 20, "green", "false");
                                    }
                                }

                                HTuple width, height;
                                HOperatorSet.GetImageSize(toolPar.ResultPar.图像, out width, out height);

                                //显示辨析力
                                if (showDefinition)
                                {
                                    HObject edgeAmplitude;
                                    HOperatorSet.SobelAmp(toolPar.ResultPar.图像, out edgeAmplitude, "sum_abs", 3);
                                    HObject rec;
                                    HOperatorSet.GenRectangle1(out rec, 0, 0, height, width);
                                    HTuple mean, dev;
                                    HOperatorSet.Intensity(rec, edgeAmplitude, out mean, out dev);
                                    mean = Math.Round(mean.D, 3);
                                    if (mean > maxDefinition)
                                        maxDefinition = mean;

                                    HTuple row1, col1, row2, col2;
                                    HOperatorSet.GetPart(window.HWindowHalconID, out row1, out col1, out row2, out col2);
                                    DispMessage(Frm_AcqImageTool.Instance.hWindow_Final1.HWindowHalconID, "当前清晰度：" + mean, 18, row1 + (row2 - row1) / 30, col1 + (col2 - col1) / 30, "green", "false");
                                    DispMessage(Frm_AcqImageTool.Instance.hWindow_Final1.HWindowHalconID, "最大清晰度：" + maxDefinition, 18, row1 + (row2 - row1) / 30 + 120, col1 + (col2 - col1) / 30, "green", "false");
                                }

                                //显示十字架
                                HOperatorSet.SetColor(window.HWindowHalconID, "green");
                                HOperatorSet.DispLine(window.HWindowHalconID, height / 2, 0, height / 2, width);
                                HOperatorSet.DispLine(window.HWindowHalconID, 0, width / 2, height, width / 2);

                                Thread.Sleep(10);
                            }

                            SDK_Camera.SetAcquisitionMode(1);      //停止连续采集
                            Frm_AcqImageTool.Instance.hWindow_Final1.ClearWindow();
                            Frm_AcqImageTool.Instance.hWindow_Final1.HobjectToHimage(toolPar.ResultPar.图像);
                        }
                        catch (Exception ex)
                        {
                            Log.SaveError(ex);
                        }

                    });
                    th_livePlay.IsBackground = true;
                    th_livePlay.Start();

                    #endregion
                }
                else
                {
                    b_livePlay = false;
                    Frm_AcqImageTool.Instance.tsb_livePlay.CheckState = CheckState.Unchecked;
                    if (!runTool)
                        GetImageWindowControl(jobName).实时显示ToolStripMenuItem.Checked = false;
                    Frm_FromCamera.Instance.btn_livePlay.Text = "相机实时";
                    Frm_FromCamera.Instance.btn_focusCamera.Text = "实时对焦";
                    Frm_AcqImageTool.Instance.btn_runTool.Enabled = true;

                    if (showDefinition)
                        Frm_FromCamera.Instance.btn_livePlay.Enabled = true;
                    else
                        Frm_FromCamera.Instance.btn_focusCamera.Enabled = true;

                    Frm_AcqImageTool.Instance.btn_runJob.Enabled = true;
                    Frm_FromCamera.Instance.btn_focusCamera.Enabled = true;
                    Frm_AcqImageTool.Instance.rdo_fromDevice.Enabled = true;
                    Frm_AcqImageTool.Instance.rdo_fromFile.Enabled = true;
                    Frm_AcqImageTool.Instance.rdo_fromDirectory.Enabled = true;
                    Frm_AcqImageTool.Instance.pic_fromFile.Enabled = true;
                    Frm_AcqImageTool.Instance.pic_fromDirectory.Enabled = true;
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
        internal void SetAcqRegion()
        {
            SDK_Camera.SetAcqRegion(offsetV, offsetH, imageH, imageW);
        }
        /// <summary>
        /// 保存图像到本地
        /// </summary>
        internal void SaveImage()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (savePath == string.Empty)
                    savePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                if (toolPar.ResultPar.图像 == null)
                {
                    Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                    Frm_AcqImageTool.Instance.lbl_toolTip.Text = "提示：未获取到图像，不可保存";
                    return;
                }

                int index;
                for (index = 1; index < 1000; index++)
                {
                    if (!File.Exists(savePath + "\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + index.ToString("00") + ".jpg"))
                        break;
                }
                saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMdd") + "_" + index.ToString("00");
                saveFileDialog.Title = (Project.Instance.configuration.language == Language.English ? "Please select the image path" : "请选择图像保存路径");
                saveFileDialog.Filter = (Project.Instance.configuration.language == Language.English ? "Image File(*.tif)|*.tif|Image File(*.png)|*.png|Image File(*.jpg)|*.jpg|Image File(*.*)|*.*" : "图像文件(*.jpg)|*.jpg|图像文件(*.png)|*.png|图像文件(*.bmp)|*.bmp|图像文件(*.tif)|*.tif");
                saveFileDialog.InitialDirectory = savePath;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        HOperatorSet.WriteImage(toolPar.ResultPar.图像, "jpg", 0, saveFileDialog.FileName);
                        savePath = Path.GetDirectoryName(saveFileDialog.FileName);
                    }
                    catch
                    {
                        Frm_Main.Instance.OutputMsg(Project.Instance.configuration.language == Language.English ? "There's a problem with the file or the path is invalid(ErrorCode:1201)" : "图像文件异常或路径不合法（错误代码：10105）", Color.Red);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 刷新输出
        /// </summary>
        /// <param name="toolName">工具名称</param>
        internal void UpdateOutput(string toolName)
        {
            try
            {
                List<ToolIO> L_toolIO = Job.FindJobByName(jobName).FindToolInfoByName(toolName).output;
                for (int i = 0; i < L_toolIO.Count; i++)
                {
                    string outputItem = L_toolIO[i].ioName;
                    string[] items = Regex.Split(outputItem, " . ");
                    object value = toolPar;
                    value = GetValue(value, "ResultPar");
                    for (int j = 0; j < items.Length; j++)
                    {
                        value = GetValue(value, items[j]);
                    }
                    Job.FindJobByName(jobName).FindToolInfoByName(toolName).GetOutput(outputItem).value = value;
                    Job.FindJobByName(jobName).FindToolIONodeByNodeText(toolName, "-->" + outputItem).ToolTipText = FormatShowTip(value);
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        /// <summary>
        /// 运行工具
        /// </summary>
        /// <param name="updateImage">是否更新图像</param>
        /// <param name="runTool">是否从工具中触发</param>
        /// <param name="toolName">工具名</param>
        public override void Run(bool runTool)
        {
            lock (obj)
            {
                try
                {
                    toolRunStatu = (Project.Instance.configuration.language == Language.English ? ToolRunStatu.Not_Succeed : ToolRunStatu.未知原因);
                    Stopwatch sw = new Stopwatch();
                    sw.Restart();

                    if (runTool && Frm_AcqImageTool.isShown && Frm_AcqImageTool.Instance.jobName == jobName && Frm_AcqImageTool.Instance.toolName == toolName)
                        Frm_AcqImageTool.Instance.hWindow_Final1.ClearWindow();

                    toolPar.ResultPar.图像 = null;

                    HObject image;
                    switch (imageSource)
                    {
                        case ImageSource.FromCamera:
                            #region 从设备采集
                            if (b_livePlay)
                            {
                                toolRunStatu = ToolRunStatu.相机实时状态下无法采集图像;
                                Frm_MessageBox.Instance.MessageBoxShow("\r\n相机实时状态下无法采集图像，请停止实时后重试（错误代码：10106）", TipType.Error);
                                goto Exit;
                            }

                            //如未指定相机，则自动指定第一个相机
                            if (SDK_Camera == null)
                            {
                                if (L_SDKCamera.Count > 0)
                                {
                                    SDK_Camera = L_SDKCamera[0];
                                }
                                else
                                {
                                    if (b_updateImage)
                                        GetImageWindowControl().hwc_imageWindow.ClearWindow();
                                    toolRunStatu = (Project.Instance.configuration.language == Language.English ? ToolRunStatu.Not_Assign_Acq_Device : ToolRunStatu.未指定相机);
                                    if (runTool && Frm_AcqImageTool.isShown && Frm_AcqImageTool.Instance.jobName == jobName && Frm_AcqImageTool.Instance.toolName == toolName)
                                    {
                                        Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                                        Frm_AcqImageTool.Instance.lbl_toolTip.Text = "提示：未指定相机";
                                    }
                                    goto Exit;
                                }
                            }

                            //检查当前相机是否存在，有的时候相机没通电，那么相机就不存在
                            if (!SDK_Camera.CheckExist())
                            {
                                if (b_updateImage)
                                    GetImageWindowControl().hwc_imageWindow.ClearWindow();
                                toolRunStatu = (Project.Instance.configuration.language == Language.English ? ToolRunStatu.Not_Assign_Acq_Device : ToolRunStatu.相机未识别);
                                goto Exit;
                            }

                            if (b_hardTrig)      //硬触发
                            {
                                SDK_Camera.waitingHardTriggImageArrived = true;
                                while (SDK_Camera.waitingHardTriggImageArrived)         //一直等待，直到相机被硬触发，回调函数被调用，图像采集完成
                                    Thread.Sleep(10);
                            }
                            else       //软触发
                            {
                                SDK_Camera.SetExposureTime(exposureTime);
                                SDK_Camera.SetGain(gain);
                                SetAcqRegion();
                                toolPar.ResultPar.图像 = SDK_Camera.GrabOneImage();
                                if (toolPar.ResultPar.图像 == null)
                                {
                                    if (b_updateImage)
                                        GetImageWindowControl().hwc_imageWindow.ClearWindow();
                                    toolRunStatu = ToolRunStatu.采集图像异常;
                                    goto Exit;
                                }
                            }
                            break;
                            #endregion
                        case ImageSource.FromFile:
                            #region 从文件读取
                            if (imagePath == string.Empty)
                            {
                                if (b_updateImage)
                                    GetImageWindowControl().hwc_imageWindow.ClearWindow();
                                toolRunStatu = (Project.Instance.configuration.language == Language.English ? ToolRunStatu.Not_Assign_Path : ToolRunStatu.未指定图像路径);

                                if (runTool && Frm_AcqImageTool.isShown && Frm_AcqImageTool.Instance.jobName == jobName && Frm_AcqImageTool.Instance.toolName == toolName)
                                {
                                    Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                                    Frm_AcqImageTool.Instance.lbl_toolTip.Text = "提示：未指定图像路径";
                                }
                                goto Exit;
                            }

                            try
                            {
                                if (b_absPath)
                                    HOperatorSet.ReadImage(out image, imagePath);
                                else
                                    HOperatorSet.ReadImage(out image, Application.StartupPath + imagePath);
                            }
                            catch
                            {
                                if (b_updateImage)
                                    GetImageWindowControl().hwc_imageWindow.ClearWindow();
                                toolRunStatu = (Project.Instance.configuration.language == Language.English ? ToolRunStatu.Not_Succeed : ToolRunStatu.图像文件异常或路径不合法);
                                Frm_Main.Instance.OutputMsg(Project.Instance.configuration.language == Language.English ? "The path is invalid(ErrorCode:0106)" : "图像文件异常或路径不合法（错误代码：10107）", Color.Red);
                                goto Exit;
                            }
                            toolPar.ResultPar.图像 = image;
                            break;
                            #endregion
                        case ImageSource.FromDirectory:
                            #region 从文件夹读取
                            if (imageDirectoryPath == string.Empty)
                            {
                                if (b_updateImage)
                                    GetImageWindowControl().hwc_imageWindow.ClearWindow();
                                toolRunStatu = (Project.Instance.configuration.language == Language.English ? ToolRunStatu.Not_Assign_Path : ToolRunStatu.未指定图像路径);
                                if (runTool && Frm_AcqImageTool.isShown && Frm_AcqImageTool.Instance.jobName == jobName && Frm_AcqImageTool.Instance.toolName == toolName)
                                {
                                    Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                                    Frm_AcqImageTool.Instance.lbl_toolTip.Text = "提示：未指定图像路径";
                                }
                                goto Exit;
                            }

                            //每运行一次都要重新刷新文件夹下面的图像
                            string[] files = new string[] { };
                            try
                            {
                                if (b_absPath)
                                    files = Directory.GetFiles(imageDirectoryPath);
                                else
                                    files = Directory.GetFiles(Application.StartupPath + imageDirectoryPath);
                            }
                            catch
                            {
                                if (b_updateImage)
                                    GetImageWindowControl().hwc_imageWindow.ClearWindow();
                                toolRunStatu = (Project.Instance.configuration.language == Language.English ? ToolRunStatu.Not_Succeed : ToolRunStatu.文件夹不存在);
                                Frm_Main.Instance.OutputMsg(Project.Instance.configuration.language == Language.English ? "The path is invalid(ErrorCode:0106)" : "文件夹不存在（错误代码：10107）", Color.Red);
                                goto Exit;
                            }

                            L_images.Clear();
                            for (int i = 0; i < files.Length; i++)
                            {
                                FileInfo fileInfo = new FileInfo(files[i]);
                                if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".png" || fileInfo.Extension == ".bmp" || fileInfo.Extension == ".tif")
                                    L_images.Add(files[i]);
                            }

                            if (L_images.Count == 0)
                            {
                                if (b_updateImage)
                                    GetImageWindowControl().hwc_imageWindow.ClearWindow();
                                toolRunStatu = ToolRunStatu.文件夹内无有效图像;
                                Frm_Main.Instance.OutputMsg("文件夹内无有效图像", Color.Black);
                                goto Exit;
                            }

                            //是否自动切换图像
                            if (b_autoSwitch && !Frm_Main.Instance.tsb_stopSwtich.Checked)
                                currentImageIndex++;

                            if (currentImageIndex > L_images.Count - 1)
                                currentImageIndex = 0;

                            HOperatorSet.ReadImage(out image, L_images[currentImageIndex]);
                            currentImageName = Path.GetFileName(L_images[currentImageIndex]);
                            toolPar.ResultPar.图像 = image;
                            break;
                            #endregion
                    }

                    //彩色图像转灰度图像
                    if (b_RGBToGray)
                    {
                        HTuple chNum;
                        HOperatorSet.CountChannels(toolPar.ResultPar.图像, out chNum);
                        if (chNum == 3)
                        {
                            HObject image1;
                            HOperatorSet.Rgb1ToGray(toolPar.ResultPar.图像, out image1);
                            toolPar.ResultPar.图像 = image1;
                        }
                    }

                    //旋转图像
                    if (imageSource == ImageSource.FromCamera)
                    {
                        if (b_rotateImageForCamera)
                        {
                            HObject image2;
                            HOperatorSet.RotateImage(toolPar.ResultPar.图像, out image2, rotateAngleForCamera, "constant");
                            toolPar.ResultPar.图像 = image2;
                        }
                    }
                    else
                    {
                        if (b_rotateImageForLocal)
                        {
                            HObject image2;
                            HOperatorSet.RotateImage(toolPar.ResultPar.图像, out image2, rotateAngleForLocal, "constant");
                            toolPar.ResultPar.图像 = image2;
                        }
                    }

                    if (runTool && Frm_AcqImageTool.isShown && Frm_AcqImageTool.Instance.jobName == jobName && Frm_AcqImageTool.Instance.toolName == toolName)
                    {
                        Frm_AcqImageTool.Instance.hWindow_Final1.HobjectToHimage(toolPar.ResultPar.图像);
                        Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Black;
                        Frm_AcqImageTool.Instance.lbl_toolTip.Text = string.Format("提示：运行成功，当前图像：{0}  ({1})", currentImageName, currentImageIndex + 1 + "/" + L_images.Count);
                    }

                    if (runTool)
                    {
                        Frm_AcqImageTool.Instance.hWindow_Final1.HobjectToHimage(toolPar.ResultPar.图像);
                        if (!b_allImageRegion)
                        {
                            Frm_AcqImageTool.Instance.hWindow_Final1.viewWindow.displayROI(L_regions);
                            Frm_AcqImageTool.Instance.L_regions = this.L_regions;
                        }
                    }
                    else
                    {
                        //自动运行时显示局部图像
                        if (!b_allImageRegion && Machine.machineRunStatu == MachineRunStatu.Running)
                            HOperatorSet.SetPart(GetImageWindowControl().hwc_imageWindow.HWindowHalconID, L_regions[0].getModelData()[0], L_regions[0].getModelData()[1], L_regions[0].getModelData()[2], L_regions[0].getModelData()[3]);

                        if (b_updateImage)
                            ShowImage(toolPar.ResultPar.图像);

                        //显示“测试图像”标识
                        if (b_updateImage && imageSource != ImageSource.FromCamera && Project.Instance.configuration.showImageSource)
                        {
                            HTuple row1, col1, row2, col2;
                            HOperatorSet.GetPart(GetImageWindowControl().hwc_imageWindow.HWindowHalconID, out row1, out col1, out row2, out col2);
                            if (imageSource == ImageSource.FromFile)
                            {
                                if (GetImageWindowControl().hwc_imageWindow.Height > 300)
                                    DispMessage(GetImageWindowControl().hwc_imageWindow.HWindowHalconID, "测试图像", 15, row1 + (row2 - row1) / 12, col1 + (col2 - col1) / 30, "blue", "false");
                                else
                                    DispMessage(GetImageWindowControl().hwc_imageWindow.HWindowHalconID, "测试图像", 15, row1 + (row2 - row1) / 7, col1 + (col2 - col1) / 30, "blue", "false");
                            }
                            else
                            {
                                if (GetImageWindowControl().hwc_imageWindow.Height > 300)
                                    DispMessage(GetImageWindowControl().hwc_imageWindow.HWindowHalconID, "测试图像 " + (currentImageIndex + 1) + "/" + L_images.Count, 15, row1 + (row2 - row1) / 12, col1 + (col2 - col1) / 30, "blue", "false");
                                else
                                    DispMessage(GetImageWindowControl().hwc_imageWindow.HWindowHalconID, "测试图像 " + (currentImageIndex + 1) + "/" + L_images.Count, 15, row1 + (row2 - row1) / 7, col1 + (col2 - col1) / 30, "blue", "false");
                            }
                        }
                    }

                    toolRunStatu = (Project.Instance.configuration.language == Language.English ? ToolRunStatu.Succeed : ToolRunStatu.运行成功);
                Exit:
                    if (runTool && Frm_AcqImageTool.isShown && Frm_AcqImageTool.Instance.jobName == jobName && Frm_AcqImageTool.Instance.toolName == toolName)
                    {
                        sw.Stop();
                        long time = sw.ElapsedMilliseconds;
                        Frm_AcqImageTool.Instance.lbl_runTime.Text = string.Format("耗时：{0} ms", time.ToString());
                        if (toolRunStatu == (Project.Instance.configuration.language == Language.English ? ToolRunStatu.Succeed : ToolRunStatu.运行成功))
                        {
                            Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Black;
                            if (imageSource == ImageSource.FromDirectory)
                                Frm_AcqImageTool.Instance.lbl_toolTip.Text = string.Format("提示：运行成功，当前图像：{0}  ({1})", currentImageName, currentImageIndex + 1 + "/" + L_images.Count);
                            else
                                Frm_AcqImageTool.Instance.lbl_toolTip.Text = "提示：" + toolRunStatu.ToString();
                        }
                        else
                        {
                            Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                            Frm_AcqImageTool.Instance.lbl_toolTip.Text = "提示：" + toolRunStatu.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.SaveError(ex);
                }
            }
        }

        #region 工具参数
        [Serializable]
        public class ToolPar : ToolParBase
        {
            private InputPar _inputPar = new InputPar();
            public InputPar InputPar
            {
                get { return _inputPar; }
                set { _inputPar = value; }
            }

            private RunPar _runPar = new RunPar();
            public RunPar RunPar
            {
                get { return _runPar; }
                set { _runPar = value; }
            }

            private ResultPar _resultPar = new ResultPar();
            public ResultPar ResultPar
            {
                get { return _resultPar; }
                set { _resultPar = value; }
            }
        }
        [Serializable]
        public class InputPar { }
        [Serializable]
        public class RunPar { }
        [Serializable]
        internal class ResultPar
        {
            private HObject _图像;
            public HObject 图像
            {
                get { return _图像; }
                set { _图像 = value; }
            }
        }
        #endregion

    }
    /// <summary>
    /// 图像来源  从设备采集 | 读取图像文件 | 读取文件夹图像
    /// </summary>
    internal enum ImageSource
    {
        FromCamera,
        FromFile,
        FromDirectory,
    }
}
