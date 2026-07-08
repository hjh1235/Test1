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
    public partial class FormHardSetting : Form
    {
        public FormHardSetting()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 添加运动控制卡或IO扩展卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxHardWareName.Text == "")
            {
                MessageBox.Show("请输入卡名");
                return;
            }
            else if (combo_Hd.Text == "")
            {
                MessageBox.Show("请选择卡模式");
                return;
            }
            else if (brandcomboBox.Text == "")
            {
                MessageBox.Show("请选择卡品牌");
                return;

            }
            else if (comboBoxModel.Text == "")
            {
                MessageBox.Show("请选择卡品牌");
                return;

            }
            else
            {
                try
                {
                    GoolGaoHardSettingForm GoogolSetCardForm = null;
                    FormIOSetting IO_FormHardSetting = null;
                    GoogolTechExtCardInfoForm GoogolTechExtCardForm = null;
                    if (!Hard_Ward_Contral.hardDoc.m_HardWareDictionary.ContainsKey(textBoxHardWareName.Text))
                    {
                        CardDate CardD = new CardDate();
                        CardD.hardwareName = textBoxHardWareName.Text;
                        CardD.m_Model = comboBoxModel.Text;
                        CardD.m_Brand = brandcomboBox.Text;
                        CardD.hardwareVender = combo_Hd.Text;
                        CardD.m_strHardWare_Modle = combo_Hd.Text;

                        Hard_Ward_Contral.hardDoc.m_HardWareDictionary.Add(textBoxHardWareName.Text, CardD);
                        Hard_Ward_Contral.hardDoc.m_HardWareList.Add(CardD);

                        ListViewItem lvi = listViewNFHardWare.Items.Add(CardD.hardwareName);
                        lvi.SubItems.Add(CardD.hardwareVender.ToString());
                        if (CardD.m_strHardWare_Modle == "卡硬件")//运动控制卡
                        {
                            switch (CardD.m_Model)
                            {
                                case "GTS":
                                    //运动控制卡参数设置窗体添加
                                     GoogolSetCardForm = new GoolGaoHardSettingForm();
                                    GoogolSetCardForm.m_strHardWare_Modle = CardD.m_strHardWare_Modle;
                                    GoogolSetCardForm.hardwareName = CardD.hardwareName;
                                    GoogolSetCardForm.hardwareVender = CardD.hardwareVender;
                                    Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary.Add(CardD.hardwareName, GoogolSetCardForm);

                                    //运动控制卡的IO添加
                                     IO_FormHardSetting = new FormIOSetting();
                                    IO_FormHardSetting.hardwareName = CardD.hardwareName;
                                    IO_FormHardSetting.hardwareVender = CardD.hardwareVender;
                                    Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary.Add(CardD.hardwareName, IO_FormHardSetting);


                                    //IO输出
                                    for (int i = 0; i < 16; i++)
                                    {
                                        IOCardSta_InPut IOCardStatus = new IOCardSta_InPut();
                                        //IOCardStatus. hardwareName= textBoxHardWareName.Text;
                                        IOCardStatus.hardIOName = textBoxHardWareName.Text + "_" + i;
                                        IOCardStatus.iBitNo = i;
                                        IOCardStatus.hard_IO_Name = textBoxHardWareName.Text;
                                        IOCardStatus.iExtNo = -1;
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.Add(textBoxHardWareName.Text + "_" + i, IOCardStatus);
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.Add(IOCardStatus);
                                    }
                                    //IO输入
                                    for (int i = 0; i < 16; i++)
                                    {
                                        IOCardSta_OutPut IOCardStatus = new IOCardSta_OutPut();
                                        //IOCardStatus.hardwareName = textBoxHardWareName.Text;
                                        IOCardStatus.hardIOName = textBoxHardWareName.Text + "_" + i;
                                        IOCardStatus.iBitNo = i;
                                        IOCardStatus.hard_IO_Name = textBoxHardWareName.Text;
                                        IOCardStatus.iExtNo = -1;
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary.Add(textBoxHardWareName.Text + "_" + i, IOCardStatus);
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List.Add(IOCardStatus);
                                    }
                                    Properties.Settings.Default.iControlIOCardCount++;
                                    Properties.Settings.Default.Save();
                                    break;
                                case "GTN":
                                    //运动控制卡参数设置窗体添加
                                     GoogolSetCardForm = new GoolGaoHardSettingForm();
                                    GoogolSetCardForm.m_strHardWare_Modle = CardD.m_strHardWare_Modle;
                                    GoogolSetCardForm.hardwareName = CardD.hardwareName;
                                    GoogolSetCardForm.hardwareVender = CardD.hardwareVender;
                                    Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary.Add(CardD.hardwareName, GoogolSetCardForm);

                                    //运动控制卡的IO添加
                                     IO_FormHardSetting = new FormIOSetting();
                                    IO_FormHardSetting.hardwareName = CardD.hardwareName;
                                    IO_FormHardSetting.hardwareVender = CardD.hardwareVender;
                                    Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary.Add(CardD.hardwareName, IO_FormHardSetting);


                                    //IO输出
                                    for (int i = 0; i < 40; i++)
                                    {
                                        IOCardSta_InPut IOCardStatus = new IOCardSta_InPut();
                                        //IOCardStatus. hardwareName= textBoxHardWareName.Text;
                                        IOCardStatus.hardIOName = textBoxHardWareName.Text + "_" + i;
                                        IOCardStatus.iBitNo = i;
                                        IOCardStatus.hard_IO_Name = textBoxHardWareName.Text;
                                        IOCardStatus.iExtNo = -1;
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.Add(textBoxHardWareName.Text + "_" + i, IOCardStatus);
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.Add(IOCardStatus);
                                    }
                                    //IO输入
                                    for (int i = 0; i < 40; i++)
                                    {
                                        IOCardSta_OutPut IOCardStatus = new IOCardSta_OutPut();
                                        //IOCardStatus.hardwareName = textBoxHardWareName.Text;
                                        IOCardStatus.hardIOName = textBoxHardWareName.Text + "_" + i;
                                        IOCardStatus.iBitNo = i;
                                        IOCardStatus.hard_IO_Name = textBoxHardWareName.Text;
                                        IOCardStatus.iExtNo = -1;
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary.Add(textBoxHardWareName.Text + "_" + i, IOCardStatus);
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List.Add(IOCardStatus);
                                    }
                                    Properties.Settings.Default.iControlIOCardCount++;
                                    Properties.Settings.Default.Save();
                                    break;

                            }
                            //switch (CardD.)
                            //{
                            //    default:
                            //        break;
                            //}
                   
                        }
                        else//IO扩展模块
                        {
                            switch (CardD.m_Model)
                            {
                                case "GTS":
                                    //IO扩展模块参数设置窗体添加
                                    GoogolTechExtCardForm = new GoogolTechExtCardInfoForm();
                                    GoogolTechExtCardForm.m_strHardWare_Modle = CardD.m_strHardWare_Modle;
                                    GoogolTechExtCardForm.hardwareName = CardD.hardwareName;
                                    GoogolTechExtCardForm.hardwareVender = CardD.hardwareVender;
                                    Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary.Add(CardD.hardwareName, GoogolTechExtCardForm);
                                    //IO扩展模块的IO添加
                                    IO_FormHardSetting = new FormIOSetting();
                                    IO_FormHardSetting.hardwareName = CardD.hardwareName;
                                    IO_FormHardSetting.hardwareVender = CardD.hardwareVender;
                                    //Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary.Add(CardD.hardwareName, IO_FormHardSetting);
                                    //IO输出
                                    for (int i = 0; i < 16; i++)
                                    {
                                        IOCardSta_InPut IOCardStatus = new IOCardSta_InPut();
                                        //IOCardStatus.hardwareName = textBoxHardWareName.Text;
                                        IOCardStatus.hardIOName = textBoxHardWareName.Text + "_" + i;
                                        IOCardStatus.iBitNo = i;
                                        IOCardStatus.hard_IO_Name = textBoxHardWareName.Text;
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.Add(textBoxHardWareName.Text + "_" + i, IOCardStatus);
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.Add(IOCardStatus);
                                    }
                                    //IO输入
                                    for (int i = 0; i < 16; i++)
                                    {
                                        IOCardSta_OutPut IOCardStatus = new IOCardSta_OutPut();
                                        //IOCardStatus.hardwareName = textBoxHardWareName.Text;
                                        IOCardStatus.hardIOName = textBoxHardWareName.Text + "_" + i;
                                        IOCardStatus.iBitNo = i;
                                        IOCardStatus.hard_IO_Name = textBoxHardWareName.Text;
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary.Add(textBoxHardWareName.Text + "_" + i, IOCardStatus);
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List.Add(IOCardStatus);
                                    }
                                    Properties.Settings.Default.iModuleIOCardCount++;
                                    Properties.Settings.Default.Save();
                                    break;
                                case "GTN":
                                    //IO扩展模块参数设置窗体添加
                                     GoogolTechExtCardForm = new GoogolTechExtCardInfoForm();
                                    GoogolTechExtCardForm.m_strHardWare_Modle = CardD.m_strHardWare_Modle;
                                    GoogolTechExtCardForm.hardwareName = CardD.hardwareName;
                                    GoogolTechExtCardForm.hardwareVender = CardD.hardwareVender;
                                    Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary.Add(CardD.hardwareName, GoogolTechExtCardForm);
                                    //IO扩展模块的IO添加
                                    IO_FormHardSetting = new FormIOSetting();
                                    IO_FormHardSetting.hardwareName = CardD.hardwareName;
                                    IO_FormHardSetting.hardwareVender = CardD.hardwareVender;
                                    //Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary.Add(CardD.hardwareName, IO_FormHardSetting);
                                    //IO输出
                                    for (int i = 0; i < 16; i++)
                                    {
                                        IOCardSta_InPut IOCardStatus = new IOCardSta_InPut();
                                        //IOCardStatus.hardwareName = textBoxHardWareName.Text;
                                        IOCardStatus.hardIOName = textBoxHardWareName.Text + "_" + i;
                                        IOCardStatus.iBitNo = i;
                                        IOCardStatus.hard_IO_Name = textBoxHardWareName.Text;
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary.Add(textBoxHardWareName.Text + "_" + i, IOCardStatus);
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.Add(IOCardStatus);
                                    }
                                    //IO输入
                                    for (int i = 0; i < 16; i++)
                                    {
                                        IOCardSta_OutPut IOCardStatus = new IOCardSta_OutPut();
                                        //IOCardStatus.hardwareName = textBoxHardWareName.Text;
                                        IOCardStatus.hardIOName = textBoxHardWareName.Text + "_" + i;
                                        IOCardStatus.iBitNo = i;
                                        IOCardStatus.hard_IO_Name = textBoxHardWareName.Text;
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary.Add(textBoxHardWareName.Text + "_" + i, IOCardStatus);
                                        Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List.Add(IOCardStatus);
                                    }
                                    Properties.Settings.Default.iModuleIOCardCount++;
                                    Properties.Settings.Default.Save();
                                    break;

                            }
                 
                        }

                        //Properties.Settings.Default.iIOCardCount++;
                        //Properties.Settings.Default.Save();
                        textBoxHardWareName.Clear();

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void FormHardSetting_Load(object sender, EventArgs e)
        {
            try
            {
            foreach (var CardD in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
            {
                if (CardD.Value.m_strHardWare_Modle == "卡硬件")
                {
                    GoolGaoHardSettingForm GoogolTechExtCardForm = new GoolGaoHardSettingForm();
                    GoogolTechExtCardForm.m_strHardWare_Modle = CardD.Value.m_strHardWare_Modle;
                    GoogolTechExtCardForm.hardwareName = CardD.Value.hardwareName;
                    GoogolTechExtCardForm.hardwareVender = CardD.Value.hardwareVender;
                        Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary.Add(CardD.Value.hardwareName, GoogolTechExtCardForm);
                }
                else
                {
                    GoogolTechExtCardInfoForm GoogolTechExtCardForm = new GoogolTechExtCardInfoForm();
                    GoogolTechExtCardForm.m_strHardWare_Modle = CardD.Value.m_strHardWare_Modle;
                    GoogolTechExtCardForm.hardwareName = CardD.Value.hardwareName;
                    GoogolTechExtCardForm.hardwareVender = CardD.Value.hardwareVender;
                    Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary.Add(CardD.Value.hardwareName, GoogolTechExtCardForm);
                }
            }
            foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
            {
                ListViewItem lvi = listViewNFHardWare.Items.Add(item.Value.hardwareName);
                lvi.SubItems.Add(item.Value.hardwareVender.ToString());
            }


            }
            catch (Exception ex)
            {
                
            }
        }
        /// <summary>
        /// 删除运动控制卡或者扩展IO卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewNFHardWare.SelectedItems.Count > 0)
            {
                if (Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary.ContainsKey(listViewNFHardWare.SelectedItems[0].Text))
                {
                    Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                    Hard_Ward_Contral.hardDoc.m_HardWareDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                    Hard_Ward_Contral.hardDoc.m_HardWareList.RemoveAt(listViewNFHardWare.SelectedItems[0].Index);
                
                    Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary[listViewNFHardWare.SelectedItems[0].Text].Close();
                    Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                    Properties.Settings.Default.iControlIOCardCount--;
                }
                else if(Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary.ContainsKey(listViewNFHardWare.SelectedItems[0].Text))
                {
                    Properties.Settings.Default.iModuleIOCardCount--;
                    Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                    Hard_Ward_Contral.hardDoc.m_HardWareDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                    Hard_Ward_Contral.hardDoc.m_HardWareList.RemoveAt(listViewNFHardWare.SelectedItems[0].Index);
                    Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary[listViewNFHardWare.SelectedItems[0].Text].Close();
                    Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);

                }
               List<IOCardSta_InPut> _m_Hard_IOInPut_List_=new List<IOCardSta_InPut> ();       
               Dictionary<string, IOCardSta_InPut> _m_Hard_IOInPut_Dictionary_=new Dictionary<string, IOCardSta_InPut> ();

                List<IOCardSta_OutPut> _m_Hard_IOOutPut_List_ = new List<IOCardSta_OutPut>();
                Dictionary<string, IOCardSta_OutPut> _m_Hard_IOOutPut_Dictionary_ = new Dictionary<string, IOCardSta_OutPut>();
                foreach (var items in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                {
                    foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
                    {
                        if (item.Value.hard_IO_Name == items.Value.hardwareName)
                        {
                            IOCardSta_InPut IOCardStatus = new IOCardSta_InPut();
                            IOCardStatus.hardIOName = item.Value.hardIOName;
                            IOCardStatus.iBitNo = item.Value.iBitNo;
                            IOCardStatus.hard_IO_Name = item.Value.hard_IO_Name;
                            IOCardStatus.iExtNo = item.Value.iExtNo;
                            IOCardStatus.bBitInputStatus = item.Value.bBitInputStatus;
                            IOCardStatus.iCardNo = item.Value.iCardNo;
                            _m_Hard_IOInPut_List_.Add(IOCardStatus);
                            _m_Hard_IOInPut_Dictionary_.Add(item.Value.hardIOName, IOCardStatus);
                        }
                    }
                }              
                Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary = _m_Hard_IOInPut_Dictionary_;
                Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List = _m_Hard_IOInPut_List_;
                foreach (var items in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                {
                    foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                    {
                        if (item.Value.hard_IO_Name == items.Value.hardwareName)
                        {
                            IOCardSta_OutPut IOCardStatus = new IOCardSta_OutPut();
                            IOCardStatus.hardIOName = item.Value.hardIOName;
                            IOCardStatus.iBitNo = item.Value.iBitNo;
                            IOCardStatus.hard_IO_Name = item.Value.hard_IO_Name;
                            IOCardStatus.iExtNo = item.Value.iExtNo;
                            IOCardStatus.bBitOutputStatus = item.Value.bBitOutputStatus;
                            IOCardStatus.iCardNo = item.Value.iCardNo;
                            _m_Hard_IOOutPut_List_.Add(IOCardStatus);
                            _m_Hard_IOOutPut_Dictionary_.Add(item.Value.hardIOName, IOCardStatus);
                        }
                    }
                }
                Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary = _m_Hard_IOOutPut_Dictionary_;
                Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List = _m_Hard_IOOutPut_List_;
                listViewNFHardWare.SelectedItems[0].Remove();
                if (panel1.Controls.Count > 0)
                {
                    panel1.Controls.RemoveAt(0);
                }
            }
        }
        /// <summary>
        /// 选择项打开运动控制卡或者扩展IO卡参数设置界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewNFHardWare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNFHardWare.SelectedItems.Count > 0)
            {
                string ce = listViewNFHardWare.Items[listViewNFHardWare.SelectedItems[0].Index].Text;
                foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                {
                    if (item.Value.m_strHardWare_Modle == "卡硬件")
                    {
                        try
                        {
                            if (item.Value.hardwareName == ce)
                            {
                                Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary[item.Value.hardwareName].TopLevel = false;
                                panel1.Controls.Add(Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary[item.Value.hardwareName]);
                                Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary[item.Value.hardwareName].Size = panel1.Size;
                                Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary[item.Value.hardwareName].Show();
                                Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary[item.Value.hardwareName].ShowFromMessage();
                            }
                            else
                            {
                                Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary[item.Value.hardwareName].TopLevel = false;
                                panel1.Controls.Add(Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary[item.Value.hardwareName]);
                                Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary[item.Value.hardwareName].Size = panel1.Size;
                                Hard_Ward_Contral.GoolGaoHardSettingFormFormDictionary[item.Value.hardwareName].Hide();
                            }
                        }
                        catch (Exception E)
                        {
                        }
                    }
                    else if (item.Value.m_strHardWare_Modle == "IO硬件")
                    {
                        try
                        {
                            if (item.Value.hardwareName == ce)
                            {
                                Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary[item.Value.hardwareName].TopLevel = false;
                                panel1.Controls.Add(Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary[item.Value.hardwareName]);
                                Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary[item.Value.hardwareName].Size = panel1.Size;
                                Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary[item.Value.hardwareName].Show();
                                Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary[item.Value.hardwareName].ShowFromMessage();

                            }
                            else
                            {
                                Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary[item.Value.hardwareName].TopLevel = false;
                                panel1.Controls.Add(Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary[item.Value.hardwareName]);
                                Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary[item.Value.hardwareName].Size = panel1.Size;
                                Hard_Ward_Contral.GoogolTechExtCardInfoFormFormDictionary[item.Value.hardwareName].Hide();
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 参数保存按钮，已被整合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Hard_Ward_Contral.hardDoc.SaveDoc();
        }

        private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxModel.Text != "")
            {
              //  Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_Model = comboBoxModel.Text;


                //for (int i = 0; i < 16; i++)
                //{
                //    Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[label1.Text + "_" + i].m_Model = comboBoxModel.Text;
                //    // Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[label1.Text + "_" + i].iExtNo = -1;
                //    Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[label1.Text + "_" + i].m_Model = comboBoxModel.Text;
                //    // Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[label1.Text + "_" + i].iExtNo = -1;

                //    //Hard_Ward_Contral.hardDoc.m_HardWareDictionary[label1.Text].m_Model = comboBoxModel.Text;
                //}
            }
        }

        private void brandcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
