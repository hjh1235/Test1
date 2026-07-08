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

    public partial class Aisx_FormHardSetting : Form
    {
        public Aisx_FormHardSetting()
        {
            InitializeComponent();
        }
   /// <summary>
   /// 添加运动控制轴
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (txt_AxisName.Text == "")
            {
                MessageBox.Show("请输入轴名称！", "添加失败");
                return;
            }
            try
            {
                if (!Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary.ContainsKey(txt_AxisName.Text))
                {
                Aisx_Hard_Date Aisx_Date = new Aisx_Hard_Date();
                Aisx_Date.Axis_hardwareName = txt_AxisName.Text;
                Aisx_Date.Axis_hardwareTpye = "Aisx";
                Aisx_Date. MainCradBinding = 与主卡绑定.SelectedItem.ToString();
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary.Add(txt_AxisName.Text, Aisx_Date);
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List.Add(Aisx_Date);

                ListViewItem lvi = listViewNFHardWare.Items.Add(Aisx_Date.Axis_hardwareName);
                lvi.SubItems.Add(Aisx_Date.Axis_hardwareTpye.ToString());

                FormAxisSetting GoogolTechExtCardForm = new FormAxisSetting();
                GoogolTechExtCardForm.hardwareName = Aisx_Date.Axis_hardwareName;
                GoogolTechExtCardForm.hardwareTpye = Aisx_Date.Axis_hardwareTpye;
                Hard_Ward_Contral.GoolGaoAxisHardSettingFormDictionary.Add(Aisx_Date.Axis_hardwareName, GoogolTechExtCardForm);

                Properties.Settings.Default.iAxisCount++;
                Properties.Settings.Default.Save();
                this.txt_AxisName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormHardSetting_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in Hard_Ward_Contral.hardDoc.m_HardWareDictionary)
                {
                    与主卡绑定.Items.Add(item.Value.hardwareName);             
                }               
            }
            catch 
            {    
            }     
            try
            {
                foreach (var CardD in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                {
                    FormAxisSetting FormAxisSetFrom = new FormAxisSetting();
                    FormAxisSetFrom.hardwareName = CardD.Value.Axis_hardwareName;
                    FormAxisSetFrom.hardwareTpye = CardD.Value.Axis_hardwareTpye;
                    Hard_Ward_Contral.GoolGaoAxisHardSettingFormDictionary.Add(CardD.Value.Axis_hardwareName, FormAxisSetFrom);
                }
                foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                {
                    ListViewItem lvi = listViewNFHardWare.Items.Add(item.Value.Axis_hardwareName);
                    lvi.SubItems.Add(item.Value.Axis_hardwareTpye.ToString());
                }
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 删除运动控制轴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewNFHardWare.SelectedItems.Count > 0)
            {
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_List.RemoveAt(listViewNFHardWare.SelectedItems[0].Index);
                Hard_Ward_Contral.GoolGaoAxisHardSettingFormDictionary[listViewNFHardWare.SelectedItems[0].Text].Close();
                Hard_Ward_Contral.GoolGaoAxisHardSettingFormDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                listViewNFHardWare.SelectedItems[0].Remove();
                if (panel1.Controls.Count > 0)
                {
                    panel1.Controls.RemoveAt(0);
                }
            }
            Properties.Settings.Default.iAxisCount--;
            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// 选择运动控制打开其参数设置界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewNFHardWare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNFHardWare.SelectedItems.Count > 0)
            {
              string ce=  listViewNFHardWare.Items[listViewNFHardWare.SelectedItems[0].Index].Text;
                foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                {
                    if (item.Value.Axis_hardwareName == ce)
                    {
                        Hard_Ward_Contral.GoolGaoAxisHardSettingFormDictionary[item.Value.Axis_hardwareName].TopLevel = false;
                        panel1.Controls.Add(Hard_Ward_Contral.GoolGaoAxisHardSettingFormDictionary[item.Value.Axis_hardwareName]);
                        Hard_Ward_Contral.GoolGaoAxisHardSettingFormDictionary[item.Value.Axis_hardwareName].Size = panel1.Size;
                        Hard_Ward_Contral.GoolGaoAxisHardSettingFormDictionary[item.Value.Axis_hardwareName].Show();
                        Hard_Ward_Contral.GoolGaoAxisHardSettingFormDictionary[item.Value.Axis_hardwareName].ShowFromMessage();
                    }
                    else
                    {
                        Hard_Ward_Contral.GoolGaoAxisHardSettingFormDictionary[item.Value.Axis_hardwareName].TopLevel = false;
                        panel1.Controls.Add(Hard_Ward_Contral.GoolGaoAxisHardSettingFormDictionary[item.Value.Axis_hardwareName]);
                        Hard_Ward_Contral.GoolGaoAxisHardSettingFormDictionary[item.Value.Axis_hardwareName].Size = panel1.Size;
                        Hard_Ward_Contral.GoolGaoAxisHardSettingFormDictionary[item.Value.Axis_hardwareName].Hide();
                 
                    }
                }
            }
        }
        /// <summary>
        /// 保存参数按钮，已被整合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Hard_Ward_Contral.Aisx_Hard_Doc.SaveDoc();
        }

        private void 与主卡绑定_SelectedIndexChanged(object sender, EventArgs e)
        {
           
               
        }
    }
}
