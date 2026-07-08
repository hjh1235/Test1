using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class _ser_clResData : ImageTool
    {
        public string _通讯名字 { get; set; }
        public string _ResData { get; set; }
        public string 通讯选择 { get; set; }
        public string 功能选择 { get; set; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroup { set; get; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroupName { set; get; }
        public string ResData(_ser_clResData _ser_clResData)
        {
            int Res = -1;
            string resData = "";
            if (_ser_clResData.通讯选择 == "客户端")
            {
                if (_ser_clResData.功能选择== "清除缓存区")
                {
                    _Client _Client = null;
                    _Client = (_Client)Communication_DateLoadData._Communication_DateTool[_ser_clResData._通讯名字];
                    _Client.ClearData();
                }
                else
                {
                    _Client _Client = null;
                    _Client = (_Client)Communication_DateLoadData._Communication_DateTool[_ser_clResData._通讯名字];
                    _Client.RecvResult(out resData);
                    DataManage.SetData(_ser_clResData.DataGroup, _ser_clResData.DataGroupName, (object)resData);
                }
            }
            else
            {
                if (_ser_clResData.功能选择 == "清除缓存区")
                {
                    _Server _Server = null;
                    _Server = (_Server)Communication_DateLoadData._Communication_DateTool[_ser_clResData._通讯名字];
                    _Server.ClearData();
                }
                else
                {
                    _Server _Server = null;
                    _Server = (_Server)Communication_DateLoadData._Communication_DateTool[_ser_clResData._通讯名字];
                    _Server.RecvResult(out resData);
                    DataManage.SetData(_ser_clResData.DataGroup, _ser_clResData.DataGroupName, (object)resData);
                }          
            }
            return resData;
        }
    }
}
