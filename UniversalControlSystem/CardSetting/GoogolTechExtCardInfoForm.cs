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
    public partial class GoogolTechExtCardInfoForm : Form
    {
        public GoogolTechExtCardInfoForm()
        {
            InitializeComponent();
        }
        public string m_strHardWare_Modle { get; set; }
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }

        public int iCardNo { get; set; }
        public int iExtNo { get; set; }
        public string sCardName { get; set; }
        public string m_strConfigPath { get; set; }
        public string m_strCardDllName { get; set; }
        public string m_strExtDllName { get; set; }
        public string m_strExtPath { get; set; }
        public void ShowFromMessage()
        {
            label1.Text = hardwareName;
            try
            {
                comboBoxCardNo.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].iCardNo.ToString();
            }
            catch
            {
                comboBoxCardNo.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].iCardNo.ToString();
            }
            try
           {              
                cmb_ExtCardNumber.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].iExtNo.ToString();           
            }
            catch
            {             
                cmb_ExtCardNumber.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].iExtNo.ToString();         
            }
            try
            {
                textBoxConfigName.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strExtPath;
            }
            catch
            {
                textBoxConfigName.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strExtPath;
            }
            try
            {
                txt_DllName.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strExtDllName;
            }
            catch
            {
                txt_DllName.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strExtDllName;
            }
            try
            {
                label7.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_Brand +"/"+ Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_Model;
            }
            catch
            {
                label7.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_Brand + "/" + Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_Model;
            }
         
        }
        private void GoogolTechExtCardInfoForm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 运动控制卡切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCardNo.Text !="")
            {
            Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].iCardNo=int.Parse(comboBoxCardNo.Text);


                foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                {
                    switch (item.Value.m_Brand)
                    {
                        case "固高":
                            switch (item.Value.m_Model)
                            {
                                case "GTS":
                                    try
                                    {
                                        for (int i = 0; i < 16; i++)
                                        {
                                            Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[label1.Text + "_" + i].iCardNo = Convert.ToInt16(comboBoxCardNo.Text);
                                            Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[label1.Text + "_" + i].iCardNo = Convert.ToInt16(comboBoxCardNo.Text);
                                        }

                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case "GTN":
                                    try
                                    {
                                        for (int i = 0; i < 40; i++)
                                        {
                                            Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[label1.Text + "_" + i].iCardNo = Convert.ToInt16(comboBoxCardNo.Text);
                                            Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[label1.Text + "_" + i].iCardNo = Convert.ToInt16(comboBoxCardNo.Text);
                                        }

                                    }
                                    catch
                                    {
                                    }
                                    break;
                            }

                            break;
                        case "凌华控制卡":

                            break;
                        case "凌华IO卡":
                            break;
                        case "雷塞":

                            break;
                    }
                }
              
            }
        }
        /// <summary>
        /// 扩展IO模块切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_ExtCardNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_ExtCardNumber.Text !="")
            {
            Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].iExtNo = Convert.ToInt16(cmb_ExtCardNumber.Text);
            for (int i = 0; i < 16; i++)
            {
                Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[label1.Text+"_"+i].iExtNo = Convert.ToInt16(cmb_ExtCardNumber.Text);
                Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[label1.Text + "_" + i].iExtNo = Convert.ToInt16(cmb_ExtCardNumber.Text);
                }
            }
        }
        /// <summary>
        /// 扩展IO模块配置文件加载路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxConfigName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxConfigName.Text !="")
            {          
            Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strExtPath = textBoxConfigName.Text;
            }
        }
        /// <summary>
        /// 扩展IO模块Dll文件加载路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_DllName_TextChanged(object sender, EventArgs e)
        {
            if (txt_DllName.Text !="")
            {         
            Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strExtDllName = txt_DllName.Text;
            }
        }
        /// <summary>
        /// 打开选择IO扩展模块配置文件加载路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectParamFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = ".//";
                openFileDialog.Filter = "卡配置文件|*.cfg";
                //openFileDialog.FilterIndex = 1;
               // openFileDialog.RestoreDirectory = true;
                DialogResult dr = openFileDialog.ShowDialog();
                if (dr == DialogResult.OK && openFileDialog.FileName.Length > 0)
                {
                    string localFilePath = openFileDialog.FileName.ToString(); //获得文件路径
                    string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                    string filePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));//获取文件路径，不带文件名
                    if (localFilePath != "")
                    {
                        Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strExtPath = fileNameExt;
                        textBoxConfigName.Text = localFilePath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 打开选择IO扩展模块DLL文件加载路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SelectDLLFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = ".//";
                openFileDialog.Filter = " dll文件|*.dll";
                //openFileDialog.FilterIndex = 1;
                //openFileDialog.RestoreDirectory = true;
                DialogResult dr = openFileDialog.ShowDialog();
                if (dr == DialogResult.OK && openFileDialog.FileName.Length > 0)
                {
                    string localFilePath = openFileDialog.FileName.ToString(); //获得文件路径
                    string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径
                    string filePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));//获取文件路径，不带文件名
                    //TableManage.tablesDoc.SaveDoc();
                    if (localFilePath != "")
                    {
                        Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strExtDllName = fileNameExt;
                        txt_DllName.Text = localFilePath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCardNo.Text != "")
            {
                Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_Model = comboBoxModel.Text;

                foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                {
                    switch (item.Value.m_Brand)
                    {
                        case "固高":
                            switch (item.Value.m_Model)
                            {
                                case "GTS":
                                    try
                                    {
                                        for (int i = 0; i < 16; i++)
                                        {
                                            Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[label1.Text + "_" + i].m_Model = comboBoxModel.Text;
                                            Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[label1.Text + "_" + i].m_Model = comboBoxModel.Text;
                                        }

                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case "GTN":
                                    try
                                    {
                                        for (int i = 0; i < 16; i++)
                                        {
                                            Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[label1.Text + "_" + i].m_Model = comboBoxModel.Text;
                                            Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[label1.Text + "_" + i].m_Model = comboBoxModel.Text;
                                        }

                                    }
                                    catch
                                    {
                                    }
                                    break;
                            }

                            break;
                        case "凌华控制卡":

                            break;
                        case "凌华IO卡":
                            break;
                        case "雷塞":

                            break;
                    }
                }
               
            }
        }
    }
}
