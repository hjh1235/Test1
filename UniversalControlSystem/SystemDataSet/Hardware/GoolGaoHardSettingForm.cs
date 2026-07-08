using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public partial class GoolGaoHardSettingForm : Form
    {
        public static GoolgaoCardParamDoc googaoCardParamDoc;
        public GoolGaoHardSettingForm()
        {
            InitializeComponent();
            googaoCardParamDoc = new GoolgaoCardParamDoc();
        }

        private void FormContorlHardSetting_Load(object sender, EventArgs e)
        {
            label1.Text = "轴配置文件设置";
            comboBoxCardNo.SelectedIndex = Program.pHardwareDoc.iCardNo;
            txt_CardName.Text = Program.pHardwareDoc.sCardName;
            textBoxConfigName.Text = Program.pHardwareDoc.m_strConfigPath;
            txt_DllName.Text = Program.pHardwareDoc.m_strExtDllName;
        }

        private void comboBoxCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            googaoCardParamDoc.iCardNo = comboBoxCardNo.SelectedIndex;
        }

        private void txt_CardName_TextChanged(object sender, EventArgs e)
        {
            googaoCardParamDoc.sCardName = txt_CardName.Text;
            Program.pHardwareDoc.sCardName = googaoCardParamDoc.sCardName;
        }

        private void textBoxConfigName_TextChanged(object sender, EventArgs e)
        {
            googaoCardParamDoc.m_strConfigPath = textBoxConfigName.Text;
        }

        private void txt_DllName_TextChanged(object sender, EventArgs e)
        {
            googaoCardParamDoc.m_strExtDllName = txt_DllName.Text;
        }

        private void btn_SelectParamFile_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Save();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                //openFileDialog.InitialDirectory = "d:";
                //saveFileDialog.Filter = "ext files (*.txt)|*.txt|All files(*.*)|*>**";
                //openFileDialog.Filter = " All files(*.*)|(*.dll)>*.dll|(*.cfg)>*.cfg|ext files (*.txt)|*.txt";
                //openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                DialogResult dr = openFileDialog.ShowDialog();
                if (dr == DialogResult.OK && openFileDialog.FileName.Length > 0)
                {
                    string localFilePath = openFileDialog.FileName.ToString(); //获得文件路径
                    string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                    string filePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));//获取文件路径，不带文件名
                    //TableManage.tablesDoc.SaveDoc();
                    if (localFilePath != "")
                    {
                        textBoxConfigName.Text = fileNameExt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_SelectDLLFile_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Save();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                //openFileDialog.InitialDirectory = "d:";
                //saveFileDialog.Filter = "ext files (*.txt)|*.txt|All files(*.*)|*>**";
                //openFileDialog.Filter = " All files(*.*)|*>**|ext files (*.txt)|*.txt";
                //openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                DialogResult dr = openFileDialog.ShowDialog();
                if (dr == DialogResult.OK && openFileDialog.FileName.Length > 0)
                {
                    string localFilePath = openFileDialog.FileName.ToString(); //获得文件路径
                    string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                    string filePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));//获取文件路径，不带文件名
                    //TableManage.tablesDoc.SaveDoc();
                    if (localFilePath != "")
                    {
                        txt_DllName.Text = fileNameExt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxCardNo_Validated(object sender, EventArgs e)
        {
            googaoCardParamDoc.iCardNo = comboBoxCardNo.SelectedIndex;
        }

        private void txt_CardName_Validated(object sender, EventArgs e)
        {
            googaoCardParamDoc.sCardName = txt_CardName.Text;
            Program.pHardwareDoc.sCardName = googaoCardParamDoc.sCardName;
        }

        private void textBoxConfigName_Validated(object sender, EventArgs e)
        {
            googaoCardParamDoc.m_strConfigPath = textBoxConfigName.Text;
        }

        private void txt_DllName_Validated(object sender, EventArgs e)
        {
            googaoCardParamDoc.m_strExtDllName = txt_DllName.Text;
        }
    }
}
