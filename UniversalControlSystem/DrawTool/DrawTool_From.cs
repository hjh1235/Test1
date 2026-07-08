
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalControlSystem.Properties;

namespace UniversalControlSystem
{

    public partial class DrawTool_From : Form
    {
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }
        public DrawTool_From()
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
                        
                        }
                        else
                        {
                         
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
            }
            else if (PLCName.Text == "")
            {
                MessageBox.Show("PLC型号");
            }
            else
            {
                try
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

                    //lvi.ImageKey = Resources.服务器;





                }
                catch
                {
                }

            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {


            listViewNFHardWare.SelectedItems[0].Remove();
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.RemoveAt(0);
            }
        }
    }
}
