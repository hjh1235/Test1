using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VMPro.Properties;

namespace VMPro
{
    internal partial class Frm_MoreSetting : Frm_FormBase
    {
        internal Frm_MoreSetting()
        {
            InitializeComponent();

            this.TopMost = true;
            this.btn_topLevel.Image = Resources.钉;
        }

        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static Frm_MoreSetting _instance;
        internal static Frm_MoreSetting Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_MoreSetting();
                return _instance;
            }
        }
        /// <summary>
        /// 工具对象
        /// </summary>
        internal static AcqImageTool acqImageTool = new AcqImageTool();


        private void tbx_offsetV_ValueChanged(double value)
        {
            try
            {
                if (Job.loadForm)
                    return;

                acqImageTool.offsetV = (int)value;
                acqImageTool.SetAcqRegion();
                Frm_AcqImageTool.Instance.btn_runTool_Click(null, null);
            }
            catch { }
        }
        private void tbx_offsetH_ValueChanged(double value)
        {
            try
            {
                if (Job.loadForm)
                    return;

                acqImageTool.offsetH = (int)value;
                acqImageTool.SetAcqRegion();
                Frm_AcqImageTool.Instance.btn_runTool_Click(null, null);
            }
            catch { }
        }
        private void tbx_iamgeH_ValueChanged(double value)
        {
            try
            {
                if (Job.loadForm)
                    return;

                acqImageTool.imageH = (int)value;
                acqImageTool.SetAcqRegion();
                Frm_AcqImageTool.Instance.btn_runTool_Click(null, null);
            }
            catch { }
        }
        private void tbx_imageW_ValueChanged(double value)
        {
            try
            {
                if (Job.loadForm)
                    return;

                acqImageTool.imageW = (int)value;
                acqImageTool.SetAcqRegion();
                Frm_AcqImageTool.Instance.btn_runTool_Click(null, null);
            }
            catch { }
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
