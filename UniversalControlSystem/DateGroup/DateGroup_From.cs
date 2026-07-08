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

    public partial class DateGroup_From : Form
    {
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }
        public DateGroup_From()
        {
            InitializeComponent();
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void FormHardSetting_Load(object sender, EventArgs e)
        {      
            try
            {
                foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
                {
                    DateGroup_Setting DateG = new DateGroup_Setting();
                    DateG.hardwareName = item.Value.Group_ControlDataName;
                    DateG.hardwareTpye = item.Value.Group_ControlDataTpye;
                    //PLC_Setg.hardwareVender = "Vender";
                    Hard_Ward_Contral.DateGroup_FormSettingDictionary.Add(item.Value.Group_ControlDataName, DateG);                  
                }
                foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
                {
                    ListViewItem lvi = listViewNFHardWare.Items.Add(item.Value.Group_ControlDataName);
                    lvi.SubItems.Add(item.Value.Group_ControlDataTpye.ToString());
                    //lvi.SubItems.Add(item.Value.PLC_ControlDataVender.ToString());
               }
            }
            catch (Exception ex)
            {

            }
        }

        private void listViewIOCard_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewNFHardWare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNFHardWare.SelectedItems.Count > 0)
            {
                string ce = listViewNFHardWare.Items[listViewNFHardWare.SelectedItems[0].Index].Text;
                foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
                {
                    try
                    {
                        if (item.Value.Group_ControlDataName == ce)
                        {
                            Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].TopLevel = false;
                            panel1.Controls.Add(Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName]);
                            Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].Size = panel1.Size;
                            Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].Show();
                            Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].ShowFromMessage();
                        }
                        else
                        {
                            Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].TopLevel = false;
                            panel1.Controls.Add(Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName]);
                            Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].Size = panel1.Size;
                            Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].Hide();
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
            Hard_Ward_Contral._PLC_ControlParameter.SaveDoc();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxHardWareName.Text == "")
            {          
            }
            else if (TypeName.Text == "")
            {
            }
            else
            {
                try
                {
                    if (!Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary.ContainsKey(textBoxHardWareName.Text))
                    {
                        Group Groupdate = new Group();
                        Groupdate.Group_ControlDataName = textBoxHardWareName.Text;
                        Groupdate.Group_ControlDataTpye = TypeName.Text;
                        Groupdate.Group_ControlDataVender = TypeName.Text;
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary.Add(textBoxHardWareName.Text, Groupdate);
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_List.Add(Groupdate);
                        DateGroup_Setting DateGroup_Set = new DateGroup_Setting();
                        DateGroup_Set.hardwareName = textBoxHardWareName.Text;
                        DateGroup_Set.hardwareTpye = TypeName.Text;
                        DateGroup_Set.hardwareVender = TypeName.Text;
                        Hard_Ward_Contral.DateGroup_FormSettingDictionary.Add(textBoxHardWareName.Text, DateGroup_Set);
                        ListViewItem lvi = listViewNFHardWare.Items.Add(Groupdate.Group_ControlDataName);
                        lvi.SubItems.Add(Groupdate.Group_ControlDataTpye.ToString());
                    }
                }
                catch
                {
                }
            }
        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewNFHardWare.SelectedItems.Count > 0)
            {
                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                Hard_Ward_Contral._DateGroupParameter._DateGroup_List.RemoveAt(listViewNFHardWare.SelectedItems[0].Index);
                Hard_Ward_Contral.DateGroup_FormSettingDictionary[listViewNFHardWare.SelectedItems[0].Text].Close();
                Hard_Ward_Contral.DateGroup_FormSettingDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                listViewNFHardWare.SelectedItems[0].Remove();
                if (panel1.Controls.Count > 0)
                {
                    panel1.Controls.RemoveAt(0);
                }
            }
        }
    }
}
