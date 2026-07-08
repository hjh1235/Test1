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

    public partial class OtherFormSetting : Form
    {
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }
        public OtherFormSetting()
        {
            InitializeComponent();
        }

        private void FormHardSetting_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary)
                {
                    OtherForm _OtherForm = new OtherForm();
                    _OtherForm.hardwareName = item.Value.Get_High_hardwareName;
                    _OtherForm.hardwareTpye = "Tpye";
                    _OtherForm.hardwareVender = "Vender";
                    Hard_Ward_Contral.OtherFormSettingDictionary.Add(item.Value.Get_High_hardwareName, _OtherForm);

                    ListViewItem lvi = listViewNFHardWare.Items.Add(item.Value.Get_High_hardwareName);
                    lvi.SubItems.Add(item.Value.Get_High_hardwareVender.ToString());
                    //lvi.SubItems.Add(item.Value.Get_High_hardwareTpye.ToString());

                }


            }
            catch (Exception ex)
            {

            }
        }

        private void listViewNFHardWare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNFHardWare.SelectedItems.Count > 0)
            {
                string ce = listViewNFHardWare.Items[listViewNFHardWare.SelectedItems[0].Index].Text;
                foreach (var item in Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary)
                {
                    try
                    {
                        if (item.Value.Get_High_hardwareName == ce)
                        {
                            Hard_Ward_Contral.OtherFormSettingDictionary[item.Value.Get_High_hardwareName].TopLevel = false;
                            panel1.Controls.Add(Hard_Ward_Contral.OtherFormSettingDictionary[item.Value.Get_High_hardwareName]);
                            Hard_Ward_Contral.OtherFormSettingDictionary[item.Value.Get_High_hardwareName].Size = panel1.Size;
                            Hard_Ward_Contral.OtherFormSettingDictionary[item.Value.Get_High_hardwareName].Show();
                            Hard_Ward_Contral.OtherFormSettingDictionary[item.Value.Get_High_hardwareName].ShowFromMessage();
                        }
                        else
                        {
                            Hard_Ward_Contral.OtherFormSettingDictionary[item.Value.Get_High_hardwareName].TopLevel = false;
                            panel1.Controls.Add(Hard_Ward_Contral.OtherFormSettingDictionary[item.Value.Get_High_hardwareName]);
                            Hard_Ward_Contral.OtherFormSettingDictionary[item.Value.Get_High_hardwareName].Size = panel1.Size;
                            Hard_Ward_Contral.OtherFormSettingDictionary[item.Value.Get_High_hardwareName].Hide();
                        }

                    }
                    catch
                    {
                    }
                }
            }
        }

        private void Save_Other_Date_Click(object sender, EventArgs e)
        {
            Hard_Ward_Contral._Get_High_Date_Save.SaveDoc();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxHardWareName.Text != "")
            {
                if (!Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary.ContainsKey(textBoxHardWareName.Text))
                {
                    Get_High Get_High = new Get_High();
                    Get_High.Get_High_hardwareName = textBoxHardWareName.Text;
                    Get_High.Get_High_hardwareVender = "Vender";
                    Get_High.Get_High_hardwareTpye = "Tpye";

                    OtherForm OtherForm = new OtherForm();
                    OtherForm.hardwareName = textBoxHardWareName.Text;
                    OtherForm.hardwareTpye = "Tpye";
                    OtherForm.hardwareVender = "Vender";

                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary.Add(Get_High.Get_High_hardwareName, Get_High);
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_List.Add(Get_High);

                    Hard_Ward_Contral.OtherFormSettingDictionary.Add(OtherForm.hardwareName, OtherForm);


                    ListViewItem lvi = listViewNFHardWare.Items.Add(Get_High.Get_High_hardwareName);
                    lvi.SubItems.Add(Get_High.Get_High_hardwareVender.ToString());
                    //lvi.SubItems.Add(Get_High.Get_High_hardwareTpye.ToString());


                }

            }
            else
            {
            }

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewNFHardWare.SelectedItems.Count > 0)
            {
                //Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary[listViewNFHardWHard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionaryare.SelectedItems[0].Text].Close();
                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);

                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_List.RemoveAt(listViewNFHardWare.SelectedItems[0].Index);
                List<Get_High> Get_High_Hard_Date_List_ = new List<Get_High>();
                Dictionary<string, Get_High> Get_High_Hard_Date_Dictionary_ = new Dictionary<string, Get_High>();
                foreach (var item in Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary)
                {
                    if (!item.Value.Get_High_hardwareName.Contains(listViewNFHardWare.SelectedItems[0].Text))
                    {
                        Get_High Wave_Date = new Get_High();
                        Wave_Date.Get_High_hardwareName = item.Value.Get_High_hardwareName;
                        Wave_Date.Get_High_hardwareTpye = item.Value.Get_High_hardwareTpye;
                        Wave_Date.Get_High_hardwareVender = item.Value.Get_High_hardwareVender;

                        Wave_Date.X偏距振镜 = item.Value.X偏距振镜;
                        Wave_Date.X偏距测高 = item.Value.X偏距测高;
                        Wave_Date.Y偏距振镜 = item.Value.Y偏距振镜;
                        Wave_Date.Y偏距测高 = item.Value.Y偏距测高;
                        Wave_Date.Z轴安全高度最低 = item.Value.Z轴安全高度最低;
                        Wave_Date.Z轴安全高度最高 = item.Value.Z轴安全高度最高;
                        Wave_Date.Z轴最大坐标 = item.Value.Z轴最大坐标;
                        Wave_Date.Z轴最小坐标 = item.Value.Z轴最小坐标;
                        Get_High_Hard_Date_Dictionary_.Add(item.Value.Get_High_hardwareName, Wave_Date);
                        Get_High_Hard_Date_List_.Add(Wave_Date);

                    }
                }
                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary = Get_High_Hard_Date_Dictionary_;
                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_List = Get_High_Hard_Date_List_;
                if (listViewNFHardWare.SelectedItems.Count > 0)
                {
                    listViewNFHardWare.SelectedItems[0].Remove();
                    if (panel1.Controls.Count > 0)
                    {
                        panel1.Controls.RemoveAt(0);
                    }
                }
            }
        }
    }
}
