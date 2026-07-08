using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VMPro
{
    internal partial class Frm_FromCamera : Form
    {
        internal Frm_FromCamera()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 锁
        /// </summary>
        private object obj = new object();
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
        private static Frm_FromCamera _instance;
        internal static Frm_FromCamera Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_FromCamera();
                return _instance;
            }
        }


        private void cbx_cameraList_SelectedIndexChanged()
        {
            if (Job.loadForm)
                return;

            if (acqImageTool.SDK_Camera != null && acqImageTool.SDK_Camera.CameraInfoStr == cbx_cameraList.TextStr)        //又切换到了自己，不做任何动作
            {
                Frm_AcqImageTool.Instance.lbl_toolTip.ForeColor = Color.Black;
                Frm_AcqImageTool.Instance.lbl_toolTip.Text = "提示：当前相机：" + acqImageTool.SDK_Camera.CameraInfoStr;
                return;
            }

            acqImageTool.SwitchCamera(cbx_cameraList.TextStr);

            if (!acqImageTool.b_livePlay)
                Frm_AcqImageTool.Instance.btn_runTool_Click(null, null);
        }
        private void nud_exposureTime_ValueChanged(double value)
        {
            try
            {
                if (Job.loadForm)
                    return;

                Application.DoEvents();
                lock (obj)
                {
                    acqImageTool.exposureTime = value;
                    if (acqImageTool.b_livePlay)
                        acqImageTool.SDK_Camera.SetExposureTime(value);
                    else
                        Frm_AcqImageTool.Instance.btn_runTool_Click(null, null);
                    nud_exposureTime.Focus();
                }
                Frm_AcqImageTool.selectedIndex = 0;
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        private void nud_gain_ValueChanged(double value)
        {
            try
            {
                if (Job.loadForm)
                    return;

                Application.DoEvents();
                lock (obj)
                {
                    acqImageTool.gain = (int)value;
                    if (acqImageTool.b_livePlay)
                        acqImageTool.SDK_Camera.SetGain(value);
                    else
                        Frm_AcqImageTool.Instance.btn_runTool_Click(null, null);
                    nud_gain.Focus();
                }
                Frm_AcqImageTool.selectedIndex = 1;
            }
            catch (Exception ex)
            {
                Log.SaveError(ex);
            }
        }
        private void btn_livePlay_Click(object sender, EventArgs e)
        {
            acqImageTool.StartOrStopPlayImage(true, Frm_AcqImageTool.Instance.hWindow_Final1);
        }
        private void btn_focusCamera_Click(object sender, EventArgs e)
        {
            acqImageTool.StartOrStopPlayImage(true, Frm_AcqImageTool.Instance.hWindow_Final1, true);
        }
        private void btn_saveImage_Click(object sender, EventArgs e)
        {
            acqImageTool.SaveImage();
        }
        private void btn_moreSetting_Click(object sender, EventArgs e)
        {
            Frm_MoreSetting.Instance.Show();
        }

    }
}
