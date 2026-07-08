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

    public partial class AnalogQuantityFormSetting : Form
    {
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }
        public AnalogQuantityFormSetting()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormHardSetting_Load(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Wave_Date_From_Save_Doc.Wave_From_Date_Dictionary)
            {
                AnalogQuantityOutFrom AnalogQuantityOutFrom = new AnalogQuantityOutFrom();
                AnalogQuantityOutFrom.hardwareName = item.Value.Wave_hardwareName;
                AnalogQuantityOutFrom.hardwareVender = "Vender";
                Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary.Add(item.Value.Wave_hardwareName, AnalogQuantityOutFrom);

            }
            try
            {
                foreach (var item in Hard_Ward_Contral.Wave_Date_From_Save_Doc.Wave_From_Date_Dictionary)
                {
                    ListViewItem lvi = listViewNFHardWare.Items.Add(item.Value.Wave_hardwareName);
                    lvi.SubItems.Add(item.Value.Wave_hardwareVender.ToString());
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

            foreach (var item in Hard_Ward_Contral.Wave_Date_From_Save_Doc.Wave_From_Date_Dictionary)
            {
                try
                {
                    if (item.Value.Wave_hardwareName == ce)
                    {
                        Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary[item.Value.Wave_hardwareName].TopLevel = false;
                        panel1.Controls.Add(Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary[item.Value.Wave_hardwareName]);
                        Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary[item.Value.Wave_hardwareName].Size = panel1.Size;
                        Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary[item.Value.Wave_hardwareName].Show();
                        Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary[item.Value.Wave_hardwareName].ShowFromMessage();
                    }
                    else
                    {
                        Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary[item.Value.Wave_hardwareName].TopLevel = false;
                        panel1.Controls.Add(Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary[item.Value.Wave_hardwareName]);
                        Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary[item.Value.Wave_hardwareName].Size = panel1.Size;
                        Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary[item.Value.Wave_hardwareName].Hide();
                    }
                }
                catch (Exception E)
                {
                }
            }
        } }

        private void Save_Other_Date_Click(object sender, EventArgs e)
        {
            Hard_Ward_Contral.Wave_Date_From_Save_Doc.SaveDoc();
            Hard_Ward_Contral.Wave_Date_Save_Doc.SaveDoc();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxHardWareName.Text == "")
            {
               MessageBox.Show("请输入模拟量名", "添加提示");
                return;
            }
            try
            {
                if (!Hard_Ward_Contral.Wave_Date_From_Save_Doc.Wave_From_Date_Dictionary.ContainsKey(textBoxHardWareName.Text))
                {
                    Wave_From_Date Wave_FromDate = new Wave_From_Date();
                    Wave_FromDate.Wave_hardwareName = textBoxHardWareName.Text;
                    Wave_FromDate.Wave_hardwareVender = "Vender";
                    AnalogQuantityOutFrom AnalogQuantityOutFrom = new AnalogQuantityOutFrom();
                    AnalogQuantityOutFrom.hardwareName = textBoxHardWareName.Text;
                    AnalogQuantityOutFrom.hardwareVender = "Vender";
                    Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary.Add(AnalogQuantityOutFrom.hardwareName, AnalogQuantityOutFrom);

                    ListViewItem lvi = listViewNFHardWare.Items.Add(Wave_FromDate.Wave_hardwareName);
                    lvi.SubItems.Add(Wave_FromDate.Wave_hardwareVender.ToString());

                    Hard_Ward_Contral.Wave_Date_From_Save_Doc.Wave_From_Date_Dictionary.Add(AnalogQuantityOutFrom.hardwareName, Wave_FromDate);
                    Hard_Ward_Contral.Wave_Date_From_Save_Doc.Wave_From_Date_List.Add(Wave_FromDate);
                    for (int i = 1; i < 17; i++)
                    {
                        Wave_Date Wave_Date = new Wave_Date();
                        Wave_Date.Wave_hardwareName = textBoxHardWareName.Text + "_" + "第" + i + "段波形";
                        Wave_Date.Wave_hardwareVender = "Vender";
                        Wave_Date.Wave_Name = textBoxHardWareName.Text + "_" + "第" + i + "段波形";
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary.Add(textBoxHardWareName.Text + "_" + "第" + i + "段波形", Wave_Date);
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_List.Add(Wave_Date);
                    }

                }
                
            }
            catch
            {
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewNFHardWare.SelectedItems.Count > 0)
            {
                Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary[listViewNFHardWare.SelectedItems[0].Text].Close();
                Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);

                Hard_Ward_Contral.Wave_Date_From_Save_Doc.Wave_From_Date_Dictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                Hard_Ward_Contral.Wave_Date_From_Save_Doc.Wave_From_Date_List.RemoveAt(listViewNFHardWare.SelectedItems[0].Index);
                List<Wave_Date> _Wave_Date_List_ = new List<Wave_Date>();
                Dictionary<string, Wave_Date> _Wave_Date_Dictionary_ = new Dictionary<string, Wave_Date>();
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (!item.Value.Wave_hardwareName.Contains(listViewNFHardWare.SelectedItems[0].Text))
                    {
                        Wave_Date Wave_Date = new Wave_Date();
                        Wave_Date.Wave_hardwareName = item.Value.Wave_hardwareName;
                        Wave_Date.Wave_hardwareVender = item.Value.Wave_hardwareVender;
                        Wave_Date.Wave_Name = item.Value.Wave_hardwareName;

                        Wave_Date.High_Power = item.Value.High_Power;
                        Wave_Date.High_Voltage = item.Value.High_Voltage;
                        Wave_Date.Times = item.Value.Times;
                        Wave_Date.Powers = item.Value.Powers;
                        Wave_Date.Voltages = item.Value.Voltages;
                        Wave_Date.Wave_Name = item.Value.Wave_Name;
                        Wave_Date.Wave_Number = item.Value.Wave_Number;
                        Wave_Date.Wave_Run_Power = item.Value.Wave_Run_Power;
                        _Wave_Date_Dictionary_.Add(item.Value.Wave_hardwareName, Wave_Date);
                        _Wave_Date_List_.Add(Wave_Date);

                    }
                }
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary = _Wave_Date_Dictionary_;
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_List = _Wave_Date_List_;
                listViewNFHardWare.SelectedItems[0].Remove();
                if (panel1.Controls.Count > 0)
                {
                    panel1.Controls.RemoveAt(0);
                }
            }
        }
    }
}
