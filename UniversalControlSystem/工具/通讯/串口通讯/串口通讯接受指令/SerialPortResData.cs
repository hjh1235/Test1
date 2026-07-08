using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class SerialPortResData : ImageTool
    {
        public string _通讯名字 { get; set; }
        public string _ResData { get; set; }
        public string 功能选择 { get; set; }

        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroup { set; get; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroupName { set; get; }
        public string  ResData(SerialPortResData _SerialPortResData)
        {
            SerialPortCom SerialPort = null;
            SerialPort = (SerialPortCom)Communication_DateLoadData._Communication_DateTool[_SerialPortResData._通讯名字];
            string ResData = "";
            SerialPort.RecvResult(out ResData);
            ResData = ResData.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace(" ", "");
            if (ResData!="")
            {
                DataManage.SetData(_SerialPortResData.DataGroup, _SerialPortResData.DataGroupName, (object)ResData);
                return ResData;
            }
           else
           {
               DataManage.SetData(_SerialPortResData.DataGroup, _SerialPortResData.DataGroupName, (object)ResData);
               return ResData;
           }
        }

    }
}
