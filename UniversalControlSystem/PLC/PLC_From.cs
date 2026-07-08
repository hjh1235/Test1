using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalControlSystem.PLC;
using UniversalControlSystem.Properties;

namespace UniversalControlSystem
{
    public partial class PLC_From : Form
    {
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }
        public PLC_From()
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
                foreach (var item in Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary)
                {
                    PLC_Setting PLC_Setg = new PLC_Setting();
                    PLC_Setg.hardwareName = item.Value.PLC_ControlDataName;
                    PLC_Setg.hardwareTpye = "Tpye";
                    PLC_Setg.hardwareVender = "Vender";
                    Hard_Ward_Contral.PLC_Control_FormSettingDictionary.Add(item.Value.PLC_ControlDataName, PLC_Setg);

                    ListViewItem lvi = listViewNFHardWare.Items.Add(item.Value.PLC_ControlDataName);
                    lvi.SubItems.Add(item.Value.PLC_ControlDataTpye.ToString());
                    lvi.SubItems.Add(item.Value.PLC_ControlDataVender.ToString());



                    int idx = dgv_deviceList.Rows.Add();
                    dgv_deviceList.Rows[idx].Tag = textBoxHardWareName.Text;
                    this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_deviceList.Rows[idx].Height = 50;
                    dgv_deviceList.Rows[idx].Cells[0].Value = item.Value.PLC_ControlDataName;
                    dgv_deviceList.Rows[idx].Cells[1].Value = item.Value.PLC_ControlDataTpye.ToString();
                    dgv_deviceList.Rows[idx].Cells[2].Value = item.Value.PLC_ControlDataVender.ToString();

                }
                foreach(var item in Enum.GetValues(typeof(PLCBrand)))
                {
                    PLCName.Items.Add(item.ToString());
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
                foreach (var item in Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary)
                {
                    try
                    {
                        if (item.Value.PLC_ControlDataName == ce)
                        {
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].TopLevel = false;
                            panel1.Controls.Add(Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName]);
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].Size = panel1.Size;
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].Show();
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].ShowFromMessage();
                        }
                        else
                        {
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].TopLevel = false;
                            panel1.Controls.Add(Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName]);
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].Size = panel1.Size;
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].Hide();
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
                MessageBox.Show("PLC硬件名");
                return;
            }
            else if (PLCName.Text == "")
            {
                MessageBox.Show("PLC型号");
                return;
            }
            else
            {
                try
                {
                    if (!Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary.ContainsKey(textBoxHardWareName.Text))
                    {
                        PLC_ControlData PLC_ControlD = new PLC_ControlData();
                        PLC_ControlD.PLC_ControlDataName = textBoxHardWareName.Text;
                        PLC_ControlD.PLC_ControlDataTpye = "Tpye";
                        PLC_ControlD.PLC_ControlDataVender = PLCName.Text;

                        Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary.Add(textBoxHardWareName.Text, PLC_ControlD);
                        Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_List.Add(PLC_ControlD);

                        PLC_Setting PLC_Set = new PLC_Setting();
                        PLC_Set.hardwareName = textBoxHardWareName.Text;
                        PLC_Set.hardwareTpye = "Tpye";
                        PLC_Set.hardwareVender = PLCName.Text;

                        Hard_Ward_Contral.PLC_Control_FormSettingDictionary.Add(textBoxHardWareName.Text, PLC_Set);
                        
                        ListViewItem lvi = listViewNFHardWare.Items.Add(PLC_ControlD.PLC_ControlDataName);
                        lvi.SubItems.Add(PLC_ControlD.PLC_ControlDataTpye.ToString());
                        lvi.SubItems.Add(PLC_ControlD.PLC_ControlDataVender.ToString());



                        int idx = dgv_deviceList.Rows.Add();
                        dgv_deviceList.Rows[idx].Tag = textBoxHardWareName.Text;
                        this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                        dgv_deviceList.Rows[idx].Height = 30;
                        dgv_deviceList.Rows[idx].Cells[0].Value = textBoxHardWareName.Text;
                        dgv_deviceList.Rows[idx].Cells[1].Value = PLC_ControlD.PLC_ControlDataTpye.ToString();
                        dgv_deviceList.Rows[idx].Cells[2].Value = PLC_ControlD.PLC_ControlDataVender.ToString();

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
                
                int a = listViewNFHardWare.SelectedItems[0].Index;
                Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_List.RemoveAt(a);
                listViewNFHardWare.SelectedItems[0].Remove();
                //dgv_deviceList.Rows.RemoveAt(dgv_deviceList.SelectedRows[0].Index);
                if (panel1.Controls.Count > 0)
                {
                    panel1.Controls.RemoveAt(0);
                }
            }

            if (dgv_deviceList.SelectedRows.Count > 0)
            {
                int a = dgv_deviceList.CurrentRow.Index;
                Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_List.RemoveAt(a);
                //listViewNFHardWare.SelectedItems[0].Remove();
                dgv_deviceList.Rows.RemoveAt(dgv_deviceList.SelectedRows[0].Index);
                if (panel1.Controls.Count > 0)
                {
                    panel1.Controls.RemoveAt(0);
                }

            }
        }

        private void dgv_deviceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgv_deviceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_deviceList.Rows[e.RowIndex].Cells[0].Selected == true)
            {

                string ce = dgv_deviceList.Rows[e.RowIndex].Cells[0].Value.ToString();
                // string ce = dgv_deviceList.Items[dgv_deviceList.SelectedItems[0].Index].Text;
                foreach (var item in Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary)
                {
                    try
                    {
                        if (item.Value.PLC_ControlDataName == ce)
                        {
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].TopLevel = false;
                            panel1.Controls.Add(Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName]);
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].Size = panel1.Size;
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].Show();
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].ShowFromMessage();
                        }
                        else
                        {
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].TopLevel = false;
                            panel1.Controls.Add(Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName]);
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].Size = panel1.Size;
                            Hard_Ward_Contral.PLC_Control_FormSettingDictionary[item.Value.PLC_ControlDataName].Hide();
                        }

                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}
