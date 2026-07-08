using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{

    public partial class FlowChar_From : Form
    {
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }
        public FlowChar_From()
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
                foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary)
                {
                    FlowCharForm DateFlowChar = new FlowCharForm();
                    DateFlowChar.hardwareName = item.Value.FlowChar_ControlDataName;
                    DateFlowChar.hardwareTpye = item.Value.FlowChar_ControlDataTpye;
                    Hard_Ward_Contral.FlowCharForm_SettingDictionary.Add(item.Value.FlowChar_ControlDataName, DateFlowChar);
                }
                foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary)
                {

                    int idx = dgv_deviceList.Rows.Add();
                    dgv_deviceList.Rows[idx].Tag = textBoxHardWareName.Text;
                    this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_deviceList.Rows[idx].Height = 30;
                    dgv_deviceList.Rows[idx].Cells[0].Value = item.Value.FlowChar_ControlDataName;
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
            //if (listViewNFHardWare.SelectedItems.Count > 0)
            //{
            //    string ce = listViewNFHardWare.Items[listViewNFHardWare.SelectedItems[0].Index].Text;
            //    foreach (var item in Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary)
            //    {
            //        try
            //        {
            //            if (item.Value.Group_ControlDataName == ce)
            //            {
            //                Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].TopLevel = false;
            //                panel1.Controls.Add(Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName]);
            //                Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].Size = panel1.Size;
            //                Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].Show();
            //                Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].ShowFromMessage();
            //            }
            //            else
            //            {
            //                Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].TopLevel = false;
            //                panel1.Controls.Add(Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName]);
            //                Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].Size = panel1.Size;
            //                Hard_Ward_Contral.DateGroup_FormSettingDictionary[item.Value.Group_ControlDataName].Hide();
            //            }

            //        }
            //        catch
            //        {
            //        }
            //    }
            //}
        }

        private void Save_Other_Date_Click(object sender, EventArgs e)
        {
            Hard_Ward_Contral._PLC_ControlParameter.SaveDoc();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxHardWareName.Text == "")
            {
                MessageBox.Show("请输入流程名");
                return;
            }
 
            else
            {
                try
                {
                    if (!Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary.ContainsKey(textBoxHardWareName.Text))
                    {
                        _FlowChar_Control_Date _FlowChar_Control = new _FlowChar_Control_Date();
                        _FlowChar_Control.FlowChar_ControlDataName = textBoxHardWareName.Text;
                        _FlowChar_Control.FlowChar_ControlDataTpye = "Tpye";


                        Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary.Add(textBoxHardWareName.Text, _FlowChar_Control);
                        Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_List.Add(_FlowChar_Control);
                        string sPath= System.Environment.CurrentDirectory + "\\FlowChar_ControlData\\" + textBoxHardWareName.Text;

                        if (!Directory.Exists(sPath))
                        {
                            Directory.CreateDirectory(sPath);
                        }
                        FlowCharForm _FlowCharForm = new FlowCharForm();

                        _FlowCharForm.hardwareName = textBoxHardWareName.Text;
                        _FlowCharForm.hardwareTpye = "Tpye";


                        Hard_Ward_Contral.FlowCharForm_SettingDictionary.Add(textBoxHardWareName.Text, _FlowCharForm);
                        int idx = dgv_deviceList.Rows.Add();
                        dgv_deviceList.Rows[idx].Tag = textBoxHardWareName.Text;
                        this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                        dgv_deviceList.Rows[idx].Height = 30;
                        dgv_deviceList.Rows[idx].Cells[0].Value = textBoxHardWareName.Text;
                        try
                        {
                            label3.Text = Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[textBoxHardWareName.Text].配方是否为默认;
                        }
                        catch 
                        {

                            label3.Text = Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[textBoxHardWareName.Text].配方是否为默认;
                        }
                        try
                        {
                            Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[textBoxHardWareName.Text].sPath = sPath;
                        }
                        catch 
                        {

                            Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[textBoxHardWareName.Text].sPath = sPath;
                        }
                        try
                        {
                            Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[textBoxHardWareName.Text].配方是否为默认 = "不默认";

                        }
                        catch
                        {

                            Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[textBoxHardWareName.Text].配方是否为默认 = "不默认";
                        }
                    }
                }
                catch
                {
                }
            }
        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            DialogResult DResult = MessageBox.Show("确定删除", "确定删除", MessageBoxButtons.YesNo);
            if (DResult == DialogResult.No)
            {
                return;
            }

            if (dgv_deviceList.SelectedRows.Count > 0)
            {
                int a = dgv_deviceList.CurrentRow.Index;
                string ce = dgv_deviceList.Rows[a].Cells[0].Value.ToString();

               string path=  Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[ce].sPath;
                DeleteDirectory(path);

                Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary.Remove(ce);
                Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_List.RemoveAt(a);

                Hard_Ward_Contral.FlowCharForm_SettingDictionary[ce].Close();
                Hard_Ward_Contral.FlowCharForm_SettingDictionary.Remove(ce);
                //listViewNFHardWare.SelectedItems[0].Remove();
                dgv_deviceList.Rows.RemoveAt(dgv_deviceList.SelectedRows[0].Index);
                if (panel1.Controls.Count > 0)
                {
                    panel1.Controls.RemoveAt(0);
                }

              
            }
        }
        /// <summary>
        /// 删除非空文件夹
        /// </summary>
        /// <param name="path">要删除的文件夹目录</param>
        void DeleteDirectory(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists)
            {
                DirectoryInfo[] childs = dir.GetDirectories();
                foreach (DirectoryInfo child in childs)
                {
                    child.Delete(true);
                }
                dir.Delete(true);
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
                foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary)
                {
                    try
                    {
                        if (item.Value.FlowChar_ControlDataName == ce)
                        {
                            label3.Text = Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[item.Value.FlowChar_ControlDataName].配方是否为默认;
                            Hard_Ward_Contral.FlowCharForm_SettingDictionary[item.Value.FlowChar_ControlDataName].TopLevel = false;
                            panel1.Controls.Add(Hard_Ward_Contral.FlowCharForm_SettingDictionary[item.Value.FlowChar_ControlDataName]);
                            Hard_Ward_Contral.FlowCharForm_SettingDictionary[item.Value.FlowChar_ControlDataName].Size = panel1.Size;
                            Hard_Ward_Contral.FlowCharForm_SettingDictionary[item.Value.FlowChar_ControlDataName].Show();
                            Hard_Ward_Contral.FlowCharForm_SettingDictionary[item.Value.FlowChar_ControlDataName].ShowFromMessage();
                        }
                        else
                        {
                            Hard_Ward_Contral.FlowCharForm_SettingDictionary[item.Value.FlowChar_ControlDataName].TopLevel = false;
                            panel1.Controls.Add(Hard_Ward_Contral.FlowCharForm_SettingDictionary[item.Value.FlowChar_ControlDataName]);
                            Hard_Ward_Contral.FlowCharForm_SettingDictionary[item.Value.FlowChar_ControlDataName].Size = panel1.Size;
                            Hard_Ward_Contral.FlowCharForm_SettingDictionary[item.Value.FlowChar_ControlDataName].Hide();
                        }

                    }
                    catch
                    {
                    }
                }
            }
        }
        public TaskGroup m_TaskGroup = new TaskGroup();
        private void button1_Click(object sender, EventArgs e)
        {
            int a = dgv_deviceList.CurrentRow.Index;
            string ce = dgv_deviceList.Rows[a].Cells[0].Value.ToString();
            foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary)
            {
                try
                {
                    if (item.Value.FlowChar_ControlDataName == ce)
                    {
                        label3.Text = "默认";
                        Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[ce].配方是否为默认 = "默认";       
                    }
                    else
                    {
                        Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[item.Value.FlowChar_ControlDataName].配方是否为默认 = "不默认";
                    }
                }
                catch (Exception ex)
                {
                    //label3.Text = "默认";
                    //Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].配方是否为默认 = "默认";
                }
      
            }
        
        
        }
    }
}
