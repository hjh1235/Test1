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

    public partial class FormCommunicationSetting : Form
    {
        string FromShow = "";
        public FormCommunicationSetting()
        {
            InitializeComponent();
        }

       string path =   System.Environment.CurrentDirectory + "\\Parameter\\Communication_Date.xml";

        /// <summary>
        /// 添加通讯方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxHardWareName.Text == "")
            {
                MessageBox.Show("请输入通讯名");
                return;
            }
            if (combo_Hd.Text == "")
            {
                MessageBox.Show("请选择通讯模式");
                return;
            }
            try
            {
                
                if (combo_Hd.Text == "串口")
                {
                    SerialPortCom _SerialPortCom = new SerialPortCom();
                    _SerialPortCom.Communication_DateName = textBoxHardWareName.Text;
                    _SerialPortCom.Communication_DateType = combo_Hd.Text;
                    _SerialPortCom.Communication_DateVender  = combo_Hd.Text;
                    _SerialPortCom.Communication_DatePath = path;
                    try
                    {
                        Communication_DateLoadData.tool.Add(_SerialPortCom);
                        Communication_DateLoadData._Communication_DateTool = Communication_DateLoadData.tool.ToDictionary(p => p.Communication_DateName);
                    }
                    catch
                    {
                    }
                    ListViewItem lvi = listViewNFHardWare.Items.Add(_SerialPortCom.Communication_DateName);
                    lvi.SubItems.Add(_SerialPortCom.Communication_DateVender.ToString());
                    SerialPortFrom SerialPortFrom = new SerialPortFrom();
                    SerialPortFrom.hardwareName = textBoxHardWareName.Text;
                    SerialPortFrom.hardwareVender = combo_Hd.Text;
                    SerialPortFrom.m_strHardWare_Modle = combo_Hd.Text;

                    Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary.Add(SerialPortFrom.hardwareName, SerialPortFrom);
                }
                else if (combo_Hd.Text == "网络客户端")
                {
                    _Client _Client_ = new _Client();
                    _Client_.Communication_DateName = textBoxHardWareName.Text;
                    _Client_.Communication_DateType = combo_Hd.Text;
                    _Client_.Communication_DateVender = combo_Hd.Text;
                    _Client_.Communication_DatePath = path;
                    try
                    {
                        Communication_DateLoadData.tool.Add(_Client_);
                        Communication_DateLoadData._Communication_DateTool = Communication_DateLoadData.tool.ToDictionary(p => p.Communication_DateName);

                    }
                    catch 
                    {
                    }
                    ListViewItem lvi = listViewNFHardWare.Items.Add(_Client_.Communication_DateName);
                    lvi.SubItems.Add(_Client_.Communication_DateVender.ToString());
                    
                    network networkFrom = new network();
                    networkFrom.hardwareName = textBoxHardWareName.Text;
                    networkFrom.hardwareVender = combo_Hd.Text;
                    networkFrom.m_strHardWare_Modle = combo_Hd.Text;
                    Hard_Ward_Contral.network_SaveFormSettingDictionary.Add(networkFrom.hardwareName, networkFrom);

                }
                else if (combo_Hd.Text == "网络服务端")
                {
                    _Server _Server_ = new _Server();
                    _Server_.Communication_DateName = textBoxHardWareName.Text;
                    _Server_.Communication_DateType = combo_Hd.Text;
                    _Server_.Communication_DateVender = combo_Hd.Text;
                    _Server_.Communication_DatePath = path;
                    try
                    {
                        Communication_DateLoadData.tool.Add(_Server_);
                        Communication_DateLoadData._Communication_DateTool = Communication_DateLoadData.tool.ToDictionary(p => p.Communication_DateName);

                    }
                    catch
                    {
                    }
                    ListViewItem lvi = listViewNFHardWare.Items.Add(_Server_.Communication_DateName);
                    lvi.SubItems.Add(_Server_.Communication_DateVender.ToString());

                    networkSer networkFrom = new networkSer();
                    networkFrom.hardwareName = textBoxHardWareName.Text;
                    networkFrom.hardwareVender = combo_Hd.Text;
                    networkFrom.m_strHardWare_Modle = combo_Hd.Text;

                    Hard_Ward_Contral.networkSer_SaveFormSettingDictionary.Add(networkFrom.hardwareName, networkFrom);
                }
                //CommunicationFun.Communication_Init();
            }
            catch
            {
            }
        }
        /// <summary>
        /// 数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormHardSetting_Load(object sender, EventArgs e)
        {

            foreach (var item in Communication_DateLoadData._Communication_DateTool)
            {
                if (item.Value.Communication_DateVender == "串口")
                {
                    SerialPortFrom SerialPortFromForm = new SerialPortFrom();
                    SerialPortFromForm.m_strHardWare_Modle = item.Value.Communication_DateVender;
                    SerialPortFromForm.hardwareName = item.Value.Communication_DateName;
                    SerialPortFromForm.hardwareVender = item.Value.Communication_DateVender;
                    Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary.Add(item.Value.Communication_DateName, SerialPortFromForm);
                }
                else if(item.Value.Communication_DateVender == "网络客户端")
                {
                    network GnetworkForm = new network();
                    GnetworkForm.m_strHardWare_Modle = item.Value.Communication_DateVender;
                    GnetworkForm.hardwareName = item.Value.Communication_DateName;
                    GnetworkForm.hardwareVender = item.Value.Communication_DateVender;
                    Hard_Ward_Contral.network_SaveFormSettingDictionary.Add(item.Value.Communication_DateName, GnetworkForm);
                }
                else if (item.Value.Communication_DateVender == "网络服务端")
                {
                    networkSer GnetworkForm = new networkSer();
                    GnetworkForm.m_strHardWare_Modle = item.Value.Communication_DateVender;
                    GnetworkForm.hardwareName = item.Value.Communication_DateName;
                    GnetworkForm.hardwareVender = item.Value.Communication_DateVender;
                    Hard_Ward_Contral.networkSer_SaveFormSettingDictionary.Add(item.Value.Communication_DateName, GnetworkForm);
                }
            }

            foreach (var item in Communication_DateLoadData._Communication_DateTool)
            {
                ListViewItem lvi = listViewNFHardWare.Items.Add(item.Value.Communication_DateName);
                lvi.SubItems.Add(item.Value.Communication_DateVender.ToString());
            }
        }
        /// <summary>
        /// 删除通讯方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewNFHardWare.SelectedItems.Count > 0)
                {
                    //Communication_DateLoadData.tool.Add(_SerialPortCom);
                    //Communication_DateLoadData._Communication_DateTool
                    if (Communication_DateLoadData._Communication_DateTool.ContainsKey(listViewNFHardWare.SelectedItems[0].Text))
                    {
                        if (Communication_DateLoadData._Communication_DateTool[listViewNFHardWare.SelectedItems[0].Text].Communication_DateType == "串口")
                        {
                            Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[listViewNFHardWare.SelectedItems[0].Text].Close();
                            Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);

                            Communication_DateLoadData._Communication_DateTool.Remove(listViewNFHardWare.SelectedItems[0].Text);
                            Communication_DateLoadData.tool.RemoveAt(listViewNFHardWare.SelectedItems[0].Index);
                            listViewNFHardWare.SelectedItems[0].Remove();

                        }
                        else if (Communication_DateLoadData._Communication_DateTool[listViewNFHardWare.SelectedItems[0].Text].Communication_DateType == "网络客户端")
                        {
                            Hard_Ward_Contral.network_SaveFormSettingDictionary[listViewNFHardWare.SelectedItems[0].Text].Close();
                            Hard_Ward_Contral.network_SaveFormSettingDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                            Communication_DateLoadData._Communication_DateTool.Remove(listViewNFHardWare.SelectedItems[0].Text);
                            Communication_DateLoadData.tool.RemoveAt(listViewNFHardWare.SelectedItems[0].Index);
                            listViewNFHardWare.SelectedItems[0].Remove();

                        }
                        else if (Communication_DateLoadData._Communication_DateTool[listViewNFHardWare.SelectedItems[0].Text].Communication_DateType == "网络服务端")
                        {
                            Hard_Ward_Contral.networkSer_SaveFormSettingDictionary[listViewNFHardWare.SelectedItems[0].Text].Close();
                            Hard_Ward_Contral.networkSer_SaveFormSettingDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                            Communication_DateLoadData._Communication_DateTool.Remove(listViewNFHardWare.SelectedItems[0].Text);
                            Communication_DateLoadData.tool.RemoveAt(listViewNFHardWare.SelectedItems[0].Index);
                            listViewNFHardWare.SelectedItems[0].Remove();

                        }
                    }
                }
            }catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }    
            
        }
        /// <summary>
        /// 通讯方式选择项切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewNFHardWare_SelectedIndexChanged(object sender, EventArgs e)
        {
            FromShow = "";
            if (listViewNFHardWare.SelectedItems.Count > 0)
            {
                string ce = listViewNFHardWare.Items[listViewNFHardWare.SelectedItems[0].Index].Text;

                foreach (var item in Communication_DateLoadData._Communication_DateTool)
                {
                    if (item.Value.Communication_DateType == "串口")
                    {
                        try
                        {
                            if (item.Value.Communication_DateName == ce)
                            {
                                Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[item.Value.Communication_DateName].TopLevel = false;
                                panel1.Controls.Add(Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[item.Value.Communication_DateName]);
                                Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[item.Value.Communication_DateName].Size = panel1.Size;
                                Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[item.Value.Communication_DateName].Show();
                                Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[item.Value.Communication_DateName].ShowFromMessage();

                            }
                            else
                            {
                                Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[item.Value.Communication_DateName].TopLevel = false;
                                panel1.Controls.Add(Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[item.Value.Communication_DateName]);
                                Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[item.Value.Communication_DateName].Size = panel1.Size;
                                Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[item.Value.Communication_DateName].Hide();
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                   
                    }
                    if (item.Value.Communication_DateType == "网络客户端" )
                    {
                        try
                        {
                            if (item.Value.Communication_DateName == ce)
                            {
                                Hard_Ward_Contral.network_SaveFormSettingDictionary[item.Value.Communication_DateName].TopLevel = false;
                                panel1.Controls.Add(Hard_Ward_Contral.network_SaveFormSettingDictionary[item.Value.Communication_DateName]);
                                Hard_Ward_Contral.network_SaveFormSettingDictionary[item.Value.Communication_DateName].Size = panel1.Size;
                                Hard_Ward_Contral.network_SaveFormSettingDictionary[item.Value.Communication_DateName].Show();
                                Hard_Ward_Contral.network_SaveFormSettingDictionary[item.Value.Communication_DateName].ShowFromMessage();
                            }
                            else
                            {
                                Hard_Ward_Contral.network_SaveFormSettingDictionary[item.Value.Communication_DateName].TopLevel = false;
                                panel1.Controls.Add(Hard_Ward_Contral.network_SaveFormSettingDictionary[item.Value.Communication_DateName]);
                                Hard_Ward_Contral.network_SaveFormSettingDictionary[item.Value.Communication_DateName].Size = panel1.Size;
                                Hard_Ward_Contral.network_SaveFormSettingDictionary[item.Value.Communication_DateName].Hide();
                            }
                        }
                        catch
                        {
                        }
                    }
                     if (item.Value.Communication_DateType == "网络服务端" )
                    {
                        try
                        {
                            if (item.Value.Communication_DateName == ce)
                            {
                                Hard_Ward_Contral.networkSer_SaveFormSettingDictionary[item.Value.Communication_DateName].TopLevel = false;
                                panel1.Controls.Add(Hard_Ward_Contral.networkSer_SaveFormSettingDictionary[item.Value.Communication_DateName]);
                                Hard_Ward_Contral.networkSer_SaveFormSettingDictionary[item.Value.Communication_DateName].Size = panel1.Size;
                                Hard_Ward_Contral.networkSer_SaveFormSettingDictionary[item.Value.Communication_DateName].Show();
                                Hard_Ward_Contral.networkSer_SaveFormSettingDictionary[item.Value.Communication_DateName].ShowFromMessage();
                            }
                            else
                            {
                                Hard_Ward_Contral.networkSer_SaveFormSettingDictionary[item.Value.Communication_DateName].TopLevel = false;
                                panel1.Controls.Add(Hard_Ward_Contral.networkSer_SaveFormSettingDictionary[item.Value.Communication_DateName]);
                                Hard_Ward_Contral.networkSer_SaveFormSettingDictionary[item.Value.Communication_DateName].Size = panel1.Size;
                                Hard_Ward_Contral.networkSer_SaveFormSettingDictionary[item.Value.Communication_DateName].Hide();
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
            //Hard_Ward_Contral.S_PortDate_Save.SaveDoc();
        }
    }
}
