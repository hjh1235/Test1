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
    public partial class network : Form
    {
        CommunicationFun communicationFun = new CommunicationFun();
        public network()
        {
            InitializeComponent();
        }
        public string m_strHardWare_Modle { get; set; }
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }

        public void ShowFromMessage()
        {
            label1.Text = hardwareName;
            try
            {
                _Client Client = null;
                Client = (_Client)Communication_DateLoadData._Communication_DateTool[label1.Text];

                txt_IPSet.Text= Client.ip;
                txtSendPort1.Text= Client.Port.ToString();

                SendDateTxt.Text= Client.SendStr;
            }
            catch
            {
              
            }
        }
        /// <summary>
        /// 设置IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_IPSet_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_IPSet.Text != "")
                {
                    _Client Client = null;
                    Client = (_Client)Communication_DateLoadData._Communication_DateTool[label1.Text];
                    Client.ip = txt_IPSet.Text;
                }
            }
            catch 
            {
            }
        }
        /// <summary>
        /// 要发送的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendDateTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (SendDateTxt.Text != "")
                {
                    _Client Client = null;
                    Client = (_Client)Communication_DateLoadData._Communication_DateTool[label1.Text];
                    Client.SendStr = SendDateTxt.Text;
                }
            }
            catch 
            {

               
            }
         
        }
        /// <summary>
        /// 设置端口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSendPort1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSendPort1.Text !="")
                {
                    _Client Client = null;
                    Client = (_Client)Communication_DateLoadData._Communication_DateTool[label1.Text];
                    Client.Port =int.Parse(txtSendPort1.Text);
                }
            }
            catch
            {
            }
         
        }
        /// <summary>
        /// 通讯连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSPopen_Click(object sender, EventArgs e)
        {
            _Client Client = null;
            Client = (_Client)Communication_DateLoadData._Communication_DateTool[label1.Text];
            Client.Open();
            //CommunicationFun.Conn(label1.Text);
        }
        /// <summary>
        /// 发送数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            _Client Client = null;
            Client = (_Client)Communication_DateLoadData._Communication_DateTool[label1.Text];
            Client.Send(Client.SendStr);
        }
        /// <summary>
        /// 更新接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 更新_Click(object sender, EventArgs e)
        {
            _Client Client = null;
            Client = (_Client)Communication_DateLoadData._Communication_DateTool[label1.Text];
            string data = "";
            Client.RecvResult(out data);
            Hard_Ward_Contral.network_SaveFormSettingDictionary[label1.Text].txtRecPort1.Text = data;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                _Client Client = null;
                Client = (_Client)Communication_DateLoadData._Communication_DateTool[label1.Text];
                foreach (var item in Communication_DateLoadData._Communication_DateTool)
                {
                    try
                    {
                        if (item.Value.Communication_DateName == label1.Text)
                        {
                            if (Client.ConnStr == "已连接服务器")
                            {
                                Hard_Ward_Contral.network_SaveFormSettingDictionary[label1.Text].lblPortInd.BackColor = Color.Green;
                                Hard_Ward_Contral.network_SaveFormSettingDictionary[label1.Text].txtRecPort1.Text = Client.str;
                                //Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text].SerialPort_RecPort = Client.str;
                            }
                            else
                            {
                                Hard_Ward_Contral.network_SaveFormSettingDictionary[label1.Text].lblPortInd.BackColor = Color.Red;
                            }
                        }
                    }
                    catch
                    {
                    }
                }

            }
            catch
            {


            }
            //try
            //{
            //    foreach (var item in Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary)
            //    {
            //        if (item.Value.hardwareName == label1.Text)
            //        {
            //            //if (CommunicationFun.Socket_clientDate[label1.Text].IsConnected() == true)
            //            //{
            //            //    Hard_Ward_Contral.network_SaveFormSettingDictionary[label1.Text].lblPortInd.BackColor = Color.Green;
            //            //    Hard_Ward_Contral.network_SaveFormSettingDictionary[label1.Text].txtRecPort1.Text = CommunicationFun.GetRec(label1.Text);
            //            //    Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text].SerialPort_RecPort = CommunicationFun.GetRec(label1.Text);
            //            //}
            //            //else
            //            //{
            //            //    Hard_Ward_Contral.network_SaveFormSettingDictionary[label1.Text].lblPortInd.BackColor = Color.Red;

            //            //}
            //        }
            //    }
            //}
            //catch { }
        }
    }
}
