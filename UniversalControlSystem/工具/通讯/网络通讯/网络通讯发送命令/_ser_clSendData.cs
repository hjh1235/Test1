using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class _ser_clSendData : ImageTool
    {
        public string _通讯名字 { get; set; }
        public string _SendData { get; set; }
        public string 通讯选择 { get; set; }
        public bool SendData(_ser_clSendData _ser_clSendData)
        {
            bool  Res = false;
            if (_ser_clSendData.通讯选择 == "客户端")
            {
                _Client _Client = null;
                _Client = (_Client)Communication_DateLoadData._Communication_DateTool[_ser_clSendData._通讯名字];
                Res= _Client.Send( _ser_clSendData._SendData);
            }
            else
            {
                _Server _Server = null;
                _Server = (_Server)Communication_DateLoadData._Communication_DateTool[_ser_clSendData._通讯名字];
                Res = _Server.Send(_ser_clSendData._SendData);

            }
            return Res;
        }
    }
}
