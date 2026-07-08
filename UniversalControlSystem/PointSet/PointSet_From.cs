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

    public partial class PointSet_From : Form
    {
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }
        public PointSet_From()
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
                foreach (var item in Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary)
                {
                    PointSet_Setting DateG = new PointSet_Setting();
                    DateG.hardwareName = item.Value.Point_ControlDataName;
                    DateG.hardwareTpye = item.Value.Point_ControlDataTpye;
                    //PLC_Setg.hardwareVender = "Vender";
                    Hard_Ward_Contral.PointrForm_SettingDictionary.Add(item.Value.Point_ControlDataName, DateG);                  
                }
                foreach (var item in Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary)
                {
                    ListViewItem lvi = listViewNFHardWare.Items.Add(item.Value.Point_ControlDataName);
                    lvi.SubItems.Add(item.Value.Point_ControlDataName.ToString());
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
                foreach (var item in Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary)
                {
                    try
                    {
                        if (item.Value.Point_ControlDataName == ce)
                        {
                            Hard_Ward_Contral.PointrForm_SettingDictionary[item.Value.Point_ControlDataName].TopLevel = false;
                            panel1.Controls.Add(Hard_Ward_Contral.PointrForm_SettingDictionary[item.Value.Point_ControlDataName]);
                            Hard_Ward_Contral.PointrForm_SettingDictionary[item.Value.Point_ControlDataName].Size = panel1.Size;
                            Hard_Ward_Contral.PointrForm_SettingDictionary[item.Value.Point_ControlDataName].Show();
                            Hard_Ward_Contral.PointrForm_SettingDictionary[item.Value.Point_ControlDataName].ShowFromMessage();
                        }
                        else
                        {
                            Hard_Ward_Contral.PointrForm_SettingDictionary[item.Value.Point_ControlDataName].TopLevel = false;
                            panel1.Controls.Add(Hard_Ward_Contral.PointrForm_SettingDictionary[item.Value.Point_ControlDataName]);
                            Hard_Ward_Contral.PointrForm_SettingDictionary[item.Value.Point_ControlDataName].Size = panel1.Size;
                            Hard_Ward_Contral.PointrForm_SettingDictionary[item.Value.Point_ControlDataName].Hide();
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
            Hard_Ward_Contral._Point_ControlParameter.SaveDoc();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxHardWareName.Text == "")
            {          
            }
         
            else
            {
                try
                {
                    if (!Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary.ContainsKey(textBoxHardWareName.Text))
                    {
                        _Point_Control_Date _PointControl = new _Point_Control_Date();
                        _PointControl.Point_ControlDataName = textBoxHardWareName.Text;
                        _PointControl.Point_ControlDataTpye = "";
                        _PointControl.Point_ControlDataVender = "";


                        Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary.Add(textBoxHardWareName.Text, _PointControl);
                        Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_List.Add(_PointControl);

                        PointSet_Setting DateGroup_Set = new PointSet_Setting();
                        DateGroup_Set.hardwareName = textBoxHardWareName.Text;
                        DateGroup_Set.hardwareTpye = "";
                        DateGroup_Set.hardwareVender = "";
                        Hard_Ward_Contral.PointrForm_SettingDictionary.Add(textBoxHardWareName.Text, DateGroup_Set);
                        ListViewItem lvi = listViewNFHardWare.Items.Add(_PointControl.Point_ControlDataName);
                        lvi.SubItems.Add(_PointControl.Point_ControlDataName.ToString());
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
                Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_Dictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                Hard_Ward_Contral._Point_ControlParameter._Point_ControlData_List.RemoveAt(listViewNFHardWare.SelectedItems[0].Index);
                Hard_Ward_Contral.PointrForm_SettingDictionary[listViewNFHardWare.SelectedItems[0].Text].Close();
                Hard_Ward_Contral.PointrForm_SettingDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                listViewNFHardWare.SelectedItems[0].Remove();
                if (panel1.Controls.Count > 0)
                {
                    panel1.Controls.RemoveAt(0);
                }
            }
        }
    }
}
