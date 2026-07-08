using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VMPro.Properties;

namespace VMPro
{
    internal partial class Frm_FromDirectory : Form
    {
        internal Frm_FromDirectory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当前工具所属的流程
        /// </summary>
        internal string jobName = string.Empty;
        /// <summary>
        /// 当前工具名
        /// </summary>
        internal string toolName = string.Empty;
        /// <summary>
        /// 工具对象
        /// </summary>
        internal static AcqImageTool acqImageTool = new AcqImageTool();
        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static Frm_FromDirectory _instance;
        public static Frm_FromDirectory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_FromDirectory();
                return _instance;
            }
        }


        private void tbx_imageDirectoryPath_TextChanged(object sender, EventArgs e)
        {
            acqImageTool.imageDirectoryPath = tbx_imageDirectoryPath.Text.Trim();
        }
        private void tbx_imageDirectoryPath_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == (Keys.Control | Keys.V))
                {
                    if (Clipboard.ContainsText())
                    {
                        ((TextBox)sender).Text = Clipboard.GetText().Trim();
                    }
                }

                if (e.KeyData == (Keys.Control | Keys.C))
                {
                    Clipboard.SetDataObject(((TextBox)sender).Text);
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        private void btn_lastOne_Click(object sender, EventArgs e)
        {
            acqImageTool.LastImage();
        }
        private void btn_nextOne_Click(object sender, EventArgs e)
        {
            acqImageTool.NextImage();
        }
        private void btn_selectDirectory_Click(object sender, EventArgs e)
        {
            acqImageTool.SelectDirectory();
        }
        private void btn_retureToFirst_Click(object sender, EventArgs e)
        {
            try
            {
                acqImageTool.currentImageIndex = acqImageTool.L_images.Count - 1;
                Frm_AcqImageTool.Instance.btn_runTool_Click(null, null);
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        private void btn_removeCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(acqImageTool.L_images[acqImageTool.currentImageIndex]);
                Frm_AcqImageTool.Instance.btn_runTool_Click(null, null);
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        private void btn_browseImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(acqImageTool.imageDirectoryPath))
                {
                    Frm_AcqImageTool.Instance.TopMost = false;
                    Frm_AcqImageTool.Instance.btn_topLevel.Image = Resources.unTopLevel;
                    Process.Start(acqImageTool.imageDirectoryPath);
                }
                else
                {
                    Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Red;
                    Frm_AcqImageTool.Instance.lbl_toolTip.Text = "提示：请先指定图像目录路径";
                }
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }

    }
}
