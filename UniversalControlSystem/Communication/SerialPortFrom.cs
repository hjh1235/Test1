using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
namespace UniversalControlSystem
{
    public partial class SerialPortFrom : Form
    {
        SerialPortCom SerialPort;
        CommunicationFun communicationFun = new CommunicationFun();
        public SerialPortFrom()
        {
            InitializeComponent();
            SerialPort = new SerialPortCom();
        }
        public string m_strHardWare_Modle { get; set; }
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }     
        /// <summary>
        /// 界面显示
        /// </summary>
        public void ShowFromMessage()
        {
            label1.Text = hardwareName;
            try
            {
                SerialPortCom SerialPort = null;
                SerialPort=(SerialPortCom) Communication_DateLoadData._Communication_DateTool[label1.Text];
                cmbBaudRate.Text = SerialPort.SerialPort_BaudRate;
                //cmbBaudRate.Text = "er";
            }
            catch
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];

                cmbBaudRate.Text = SerialPort.SerialPort_BaudRate;
            }
            try
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                cmbPortName.Text = SerialPort.PortName;
            }
            catch
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                cmbPortName.Text = SerialPort.PortName;
            }
            try
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                cmbBaudRate.Text = SerialPort.SerialPort_BaudRate;

               // cmbBaudRate.Text = Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text].SerialPort_BaudRate.ToString();
            }
            catch
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                cmbBaudRate.Text = SerialPort.SerialPort_BaudRate;
            }
            try
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                cmbDataBits.Text = SerialPort.cmbDataBits;

                //cmbDataBits.Text = Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text].SerialPort_DataBits.ToString();
            }
            catch
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                cmbDataBits.Text = SerialPort.cmbDataBits;
            }
            try
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                cmbParity.Text = SerialPort._Parity;
            }
            catch
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                cmbParity.Text = SerialPort._Parity;
            }
            try
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                cmbStopBits.Text = SerialPort.cmbStopBits;
               // cmbStopBits.Text = Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text].SerialPort_StopBits;
            }
            catch
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                cmbStopBits.Text = SerialPort.cmbStopBits;
            }
            try
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                txtSendPort1.Text = SerialPort.SerialPort_txtSendPort;

          //      txtSendPort1.Text = Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text]
          //.SerialPort_txtSendPort;

            }
            catch
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                txtSendPort1.Text = SerialPort.SerialPort_txtSendPort;
            }

     
            //  try
            //  {                        
            //      //注册监听
            //      //CommunicationFun._CallBack += _CallBack;
            //  }
            //  catch
            //  {           
            //  }

        }
        /// <summary>
        /// 连接状态显示,已摒弃
        /// </summary>
        /// <param name="callBackStr"></param>
        private void _CallBack(string callBackStr)
        {
            try
            {
                Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text]._Conn = true;
                foreach (var item in Hard_Ward_Contral .S_PortDate_Save.m_HardWareDictionary)
                {
                    if (item.Value.hardwareName==label1.Text)
                    {
                      //  Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[label1.Text].txtRecPort1.Text = Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text].SerialPort_RecPort;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ATSLOG  " + e.ToString());
            }
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSPopen_Click(object sender, EventArgs e)
        {
            SerialPortCom SerialPort = null;
            SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
            if (SerialPort.Open() == true)
            {
                //SerialPort.eventRun += show;
                lblPortInd.BackColor = Color.Green;
            }
            else
            {
                lblPortInd.BackColor = Color.Red;
            }
        }
        /// <summary>
        /// 串口选择项Change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPortName.Text  !="")
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                SerialPort.PortName = cmbPortName.Text;
            }
        }
        /// <summary>
        /// 发送按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            SerialPortCom SerialPort = null;
            SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
            SerialPort.Send(SerialPort.SerialPort_txtSendPort);
        }
        /// <summary>
        /// 波特率选择项Change事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBaudRate.Text !="")
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                SerialPort.SerialPort_BaudRate = cmbBaudRate.Text;
            }
        }
        /// <summary>
        /// 数据位设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDataBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDataBits.Text !="")
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                SerialPort.cmbDataBits = cmbDataBits.Text;
            }
        }
        /// <summary>
        /// 奇偶性设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            SerialPortCom SerialPort = null;
            SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
            if (cmbParity.Text !="")
            {
                SerialPort._Parity = cmbParity.Text;          
            }
        }
        /// <summary>
        /// 停止位设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStopBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            SerialPortCom SerialPort = null;
            SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
            if (cmbStopBits.Text !="")
            {
              SerialPort.cmbStopBits = cmbStopBits.Text;           
            }
        }
        /// <summary>
        /// 发送内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSendPort1_TextChanged(object sender, EventArgs e)
        {
            SerialPortCom SerialPort = null;
            SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
            SerialPort.SerialPort_txtSendPort = txtSendPort1.Text;
        }
        /// <summary>
        /// 已摒弃
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBaudRate_Validated(object sender, EventArgs e)
        {
            //Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text].SerialPort_PCom = cmbPortName.Text;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                SerialPortCom SerialPort = null;
                SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
                foreach (var item in Communication_DateLoadData._Communication_DateTool)
                {
                    try
                    {
                        if (item.Value.Communication_DateName == label1.Text)
                        {
                            if (SerialPort.COMM.IsOpen == true)
                            {
                                Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[label1.Text].lblPortInd.BackColor = Color.Green;
                                Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[label1.Text].txtRecPort1.Text = SerialPort.DataReceivedstr;
                                //Hard_Ward_Contral.S_PortDate_Save.m_HardWareDictionary[label1.Text].SerialPort_RecPort = SerialPort.GetRec(label1.Text);
                            }
                            else
                            {
                                Hard_Ward_Contral.S_PortDate_SaveFormSettingDictionary[label1.Text].lblPortInd.BackColor = Color.Red;
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
        private void SerialPortFrom_Load(object sender, EventArgs e)
        {
        }
        public void show()
        {
            SerialPortCom SerialPort = null;
            SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];

            txtRecPort1.Text = SerialPort.DataReceivedstr;

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            SerialPortCom SerialPort = null;
            SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[label1.Text];
            SerialPort.ClearData();
        }
        //public 
        private void txtRecPort1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
