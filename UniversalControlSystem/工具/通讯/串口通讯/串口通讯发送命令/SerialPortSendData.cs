using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class SerialPortSendData : ImageTool
    {
        public string _通讯名字 { get; set; }
        public string _SendData { get; set; }
        public int SendData(SerialPortSendData _SerialPortSendData)
        {
            int Res = -1;
            SerialPortCom SerialPort = null;
            SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[_SerialPortSendData._通讯名字];
            //string ResData = "";
            if (SerialPort.Open() == true)
            {
            }
            else
            {
                Res = -1;
            }
            bool sendF  = SerialPort.Send(_SerialPortSendData._SendData);
            if (sendF == true)
            {
                Res = 0;
            }
            else
            {
                Res = -1;
            }
            return Res;
        }

    }
}
