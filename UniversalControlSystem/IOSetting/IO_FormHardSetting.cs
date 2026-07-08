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

    public partial class IO_FormHardSetting : Form
    {
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }
        public IO_FormHardSetting()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 每次被Show时更新IO数据
        /// </summary>
        public void UpdateIO()
        {
            try
            {
                    listViewNFHardWare.Items.Clear();
                foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                {
                    ListViewItem lvi = listViewNFHardWare.Items.Add(item.Value.hardwareName);
                    lvi.SubItems.Add(item.Value.hardwareVender.ToString());
                }

            }
            catch (Exception ex)
            {

            }
            try
            {
                Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary.Clear();
                foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                {  
                    FormIOSetting IO_FormHardSetting = new FormIOSetting();
                    IO_FormHardSetting.hardwareName = item.Value.hardwareName;
                    IO_FormHardSetting.hardwareTpye = item.Value.hardwareVender;
                    IO_FormHardSetting.hardwareVender = item.Value.hardwareTpye;
                    Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary.Add(item.Value.hardwareName, IO_FormHardSetting);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void FormHardSetting_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 选择不同的IO卡类型选择项Change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewNFHardWare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNFHardWare.SelectedItems.Count > 0)
            {
                this.panel1.Controls.Clear();
                string ce=  listViewNFHardWare.Items[listViewNFHardWare.SelectedItems[0].Index].Text;
                foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                {
                    if (item.Value.hardwareName == ce)
                    {
                        Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary[item.Value.hardwareName].TopLevel = false;
                        panel1.Controls.Add(Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary[item.Value.hardwareName]);
                        Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary[item.Value.hardwareName].Size = panel1.Size;
                        Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary[item.Value.hardwareName].Show();
                        Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary[item.Value.hardwareName].ShowFromMessage();
                    }
                    else
                    {
                  Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary[item.Value.hardwareName].TopLevel = false;
                        panel1.Controls.Add(Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary[item.Value.hardwareName]);
                        Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary[item.Value.hardwareName].Size = panel1.Size;
                        Hard_Ward_Contral.Hardware_IO_Sta_SettingFormDictionary[item.Value.hardwareName].Hide();

                    }
                }
            }
        }
        /// <summary>
        /// 保存按钮,已被整合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Hard_Ward_Contral.Hardware_IO_State.SaveDoc();
        }
        IoChangeName IoChangeNameFrom ;
        /// <summary>
        /// 改名按钮,打开改名界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeIOName_Click(object sender, EventArgs e)
        {
            IoChangeNameFrom = new IoChangeName();
            IoChangeNameFrom.Show();
            IoChangeNameFrom. UpdateIO();
        }

        private void IO_FormHardSetting_Activated(object sender, EventArgs e)
        {

        }

        private void IO_FormHardSetting_Validated(object sender, EventArgs e)
        {
           
        }
    }
}
