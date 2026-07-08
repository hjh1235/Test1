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
    internal partial class Frm_FromFile : Form
    {
        internal Frm_FromFile()
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
        private static Frm_FromFile _instance;
        public static Frm_FromFile Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Frm_FromFile();
                return _instance;
            }
        }


        private void tbx_imagePath_TextChanged(object sender, EventArgs e)
        {
            acqImageTool.imagePath = this.tbx_imagePath.Text.Trim();
        }
        private void tbx_imagePath_KeyUp(object sender, KeyEventArgs e)
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
        private void btn_selectImage_Click(object sender, EventArgs e)
        {
            acqImageTool.SelectImage();
        }

    }
}
