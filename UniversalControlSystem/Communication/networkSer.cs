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
    public partial class networkSer : Form
    {
        CommunicationFun communicationFun = new CommunicationFun();
        public networkSer()
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
                _Server Server = null;
                Server = (_Server)Communication_DateLoadData._Communication_DateTool[label1.Text];

                txt_IPSet.Text = Server.ip;
                txtSendPort1.Text = Server.Port.ToString();

                SendDateTxt.Text = Server.SendStr;


                //txt_IPSet.Text= Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text].Socket_client_IP  ;
                //txtSendPort1.Text= Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text].Socket_client_Port.ToString();

                //SendDateTxt.Text= Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text].Socket_client_txtSend  ;
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
                    _Server Server = null;
                    Server = (_Server)Communication_DateLoadData._Communication_DateTool[label1.Text];
                    Server.ip = txt_IPSet.Text;
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
                if (txt_IPSet.Text != "")
                {
                    _Server Server = null;
                    Server = (_Server)Communication_DateLoadData._Communication_DateTool[label1.Text];
                    Server.SendStr = SendDateTxt.Text;
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
                if (txt_IPSet.Text != "")
                {
                    _Server Server = null;
                    Server = (_Server)Communication_DateLoadData._Communication_DateTool[label1.Text];
                    Server.Port =int.Parse(txtSendPort1.Text);
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
            _Server Server = null;
            Server = (_Server)Communication_DateLoadData._Communication_DateTool[label1.Text];
            Server.Open();
        }
        /// <summary>
        /// 发送数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            _Server Server = null;
            Server = (_Server)Communication_DateLoadData._Communication_DateTool[label1.Text];
            Server.Send(Server.SendStr);
        }
        /// <summary>
        /// 更新接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 更新_Click(object sender, EventArgs e)
        {
            //Hard_Ward_Contral.network_SaveFormSettingDictionary[label1.Text].txtRecPort1.Text = CommunicationFun.GetRec(label1.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                _Server Server = null;
                Server = (_Server)Communication_DateLoadData._Communication_DateTool[label1.Text];
                foreach (var item in Communication_DateLoadData._Communication_DateTool)
                {
                    //连接列表.Text = "";
                    try
                    {
                        if (item.Value.Communication_DateName == label1.Text)
                        {
                            if (Server.IClientList.Count == 0)
                            {
                                连接列表.Text = "";
                            }
                     
                            if (Server.IClientList.Count>0)
                            {
                                Hard_Ward_Contral.networkSer_SaveFormSettingDictionary[label1.Text].lblPortInd.BackColor = Color.Green;
                                Hard_Ward_Contral.networkSer_SaveFormSettingDictionary[label1.Text].txtRecPort1.Text = Server.str;
                                //Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text].SerialPort_RecPort = Server.str;

                                for (int i = 0; i < Server.IClientList.Count; i++)
                                {
                                    string data = Server.IClientList[i].Ip + "," + Server.IClientList[i].Port;

                                    if (连接列表.Text == "")
                                    {
                                        连接列表.AppendText(Server.IClientList[i].Ip + "," + Server.IClientList[i].Port + "\r\n");
                                    }
                                    else if (!连接列表.Text.Contains(data))
                                    {
                                        连接列表.AppendText(Server.IClientList[i].Ip + "," + Server.IClientList[i].Port + "\r\n");
                                    }
                                    else if (连接列表.Text.Contains(data))
                                    {

                                    }
                                }
                              int line=  连接列表.GetLineFromCharIndex(连接列表.TextLength) ;
                                if (line != Server.IClientList.Count)
                                {
                                    连接列表.Text = "";
                                }
                            }
                            else
                            {
                                Hard_Ward_Contral.networkSer_SaveFormSettingDictionary[label1.Text].lblPortInd.BackColor = Color.Red;
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

        }
    }
}
