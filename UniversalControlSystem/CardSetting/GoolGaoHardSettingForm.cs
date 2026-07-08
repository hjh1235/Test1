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
        public GoolGaoHardSettingForm()
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

                txt_CardPath.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].sCardName;
                textBoxConfigName.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strConfigPath;
                txt_DllName.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strCardDllName;
                txt_MaxSpeed.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].txt_MaxSpeed.ToString();
                txt_MaxAcc.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].txt_MaxAcc.ToString();
                label11.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_Brand + "/" + Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_Model;
            }
            catch
            {
                comboBoxCardNo.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].iCardNo.ToString();

                txt_CardPath.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].sCardName;
                textBoxConfigName.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strConfigPath;
                txt_DllName.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strCardDllName;
                txt_MaxSpeed.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].txt_MaxSpeed.ToString ();
                txt_MaxAcc.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].txt_MaxAcc.ToString();

                label11.Text = Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_Brand + "/" + Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_Model ;
            }
     
        }
        private void FormContorlHardSetting_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 运动控制卡号选择项事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCardNo.Text !="")
            {
           
            Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].iCardNo = int.Parse(comboBoxCardNo.Text);
            Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].iExtNo = -1;
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
                                            // Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[label1.Text + "_" + i].iExtNo = -1;
                                            Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[label1.Text + "_" + i].iCardNo = Convert.ToInt16(comboBoxCardNo.Text);
                                            // Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[label1.Text + "_" + i].iExtNo = -1;
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
                                            // Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[label1.Text + "_" + i].iExtNo = -1;
                                            Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[label1.Text + "_" + i].iCardNo = Convert.ToInt16(comboBoxCardNo.Text);
                                            // Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[label1.Text + "_" + i].iExtNo = -1;
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
        /// 已屏蔽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_CardPath_TextChanged(object sender, EventArgs e)
        {
            Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].sCardName = txt_CardPath.Text;
            sCardName = txt_CardPath.Text;
        }
        /// <summary>
        /// 运动控制卡参数配置文件加载路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxConfigName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxConfigName.Text !="")
            {
            Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strConfigPath = textBoxConfigName.Text;
            }
        }
        /// <summary>
        /// 运动控制卡DLL文件加载路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_DllName_TextChanged(object sender, EventArgs e)
        {
            if (txt_DllName.Text !="")
            {
            Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strCardDllName = txt_DllName.Text;
            }
        }
        /// <summary>
        /// 打开选择运动控制卡参数配置文件加载路径
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
                        Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strConfigPath = fileNameExt;
                        Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].iExtNo = -1;
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
        /// 打开选择运动控制卡DLL文件加载路径
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
                        Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].iExtNo = -1;
                        Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_strCardDllName = fileNameExt;
                        txt_DllName.Text = localFilePath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_MaxSpeed_TextChanged(object sender, EventArgs e)
        {
            if (txt_MaxSpeed.Text !="")
            {
                Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].txt_MaxSpeed = int.Parse(txt_MaxSpeed.Text);

            }
        }

        private void txt_MaxAcc_TextChanged(object sender, EventArgs e)
        {
            if (txt_MaxAcc.Text != "")
            {
                Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].txt_MaxAcc = int.Parse(txt_MaxAcc.Text);
            }
        }
        private void _KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != (char)('.') && e.KeyChar != (char)('-'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)('-'))
            {
                if ((sender as TextBox).Text != "")
                {
                    e.Handled = true;
                }
                else
                {
                    (sender as TextBox).Text = "";
                    e.Handled = true;
                }
            }
            //第1位是负号时候、第2位小数点不可
            if (((TextBox)sender).Text == "-" && e.KeyChar == (char)('.'))
            {
                e.Handled = true;
            }
            //负号只能1次
            if (e.KeyChar == 45 && (((TextBox)sender).SelectionStart != 0 || ((TextBox)sender).Text.IndexOf("-") >= 0))
                e.Handled = true;
            //第1位小数点不可
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text == "")
            {
                e.Handled = true;
            }
            //小数点只能1次
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text.IndexOf('.') != -1)
            {
                e.Handled = true;
            }
            //小数点（最大到2位）   
            if (e.KeyChar != '\b' && (((TextBox)sender).SelectionStart) > (((TextBox)sender).Text.LastIndexOf('.')) + 2 && ((TextBox)sender).Text.IndexOf(".") >= 0)
                e.Handled = true;
            //光标在小数点右侧时候判断  
            if (e.KeyChar != '\b' && ((TextBox)sender).SelectionStart >= (((TextBox)sender).Text.LastIndexOf('.')) && ((TextBox)sender).Text.IndexOf(".") >= 0)
            {
                if ((((TextBox)sender).SelectionStart) == (((TextBox)sender).Text.LastIndexOf('.')) + 1)
                {
                    if ((((TextBox)sender).Text.Length).ToString() == (((TextBox)sender).Text.IndexOf(".") + 3).ToString())
                        e.Handled = true;
                }
                if ((((TextBox)sender).SelectionStart) == (((TextBox)sender).Text.LastIndexOf('.')) + 2)
                {
                    if ((((TextBox)sender).Text.Length - 3).ToString() == ((TextBox)sender).Text.IndexOf(".").ToString()) e.Handled = true;
                }
            }
            //第1位是0，第2位必须是小数点
            //if (e.KeyChar != (char)('.') && e.KeyChar != 8 && ((TextBox)sender).Text == "0")
            //{
            //    e.Handled = true;
            //}

        }
        private void txt_MaxSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void txt_MaxAcc_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

       
        private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCardNo.Text != "")
            {
                Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_Model = comboBoxModel.Text;



                for (int i = 0; i < 16; i++)
                {
                    Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[label1.Text + "_" + i].m_Model = comboBoxModel.Text;
                    // Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[label1.Text + "_" + i].iExtNo = -1;
                    Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[label1.Text + "_" + i].m_Model = comboBoxModel.Text;
                    // Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[label1.Text + "_" + i].iExtNo = -1;

                    //Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_Model = comboBoxModel.Text;
                }
            }
        }
    }
}
