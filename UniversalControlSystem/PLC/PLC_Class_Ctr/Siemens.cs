using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HslCommunication;
using HslCommunication.Profinet.Siemens;
using System.Threading;
using System.Xml.Serialization;

namespace UniversalControlSystem.PLC.PLC_Class_Ctr
{
    
    public class Siemens
    {
        private static SiemensPLCS siemensPLCSelected = SiemensPLCS.S1200;  
        private SiemensS7Net siemensTcpNet = new SiemensS7Net(siemensPLCSelected);
        private bool PLCStatus = false;
        /// <summary>
        /// 初始化连接PLC，连接PLC
        /// </summary>
        /// <param name="_IP">PLC地址</param>
        /// <param name="_Port">PLC端口</param>
        /// <param name="_Rack"></param>
        /// <param name="_Slot"></param>
        /// <returns></returns>
        public bool Init(string _IP,string _Port,string _Rack,string _Slot)
        {
            IPAddress address;
            if (!IPAddress.TryParse(_IP, out address))
            {
                return false;
            }
            int result;
            if (!int.TryParse(_Port, out result))
            {
                return false;
            }
            siemensTcpNet.IpAddress = _IP;
            siemensTcpNet.Port = result;
            try
            {
                if (siemensPLCSelected != SiemensPLCS.S200Smart)
                {
                    siemensTcpNet.Rack = byte.Parse(_Rack);
                    siemensTcpNet.Slot = byte.Parse(_Slot);
                }
                OperateResult operateResult = siemensTcpNet.ConnectServer();
                if (operateResult.IsSuccess)
                {
                    PLCStatus = true;
                    return true;
                    //userControlCurve1.ReadWriteNet = siemensTcpNet;
                }
                else
                {
                    PLCStatus = false;
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 读取PLC数据
        /// </summary>
        /// <param name="_Address">地址</param>
        /// <param name="_Type">类型</param>
        /// <param name="_result">数据</param>
        /// <returns></returns>
        public bool Read(string _Address, PLCDataType _Type,out string _result)
        {
            _result = "";
            try
            {
                switch (_Type)
                {
                    case PLCDataType.Bool:
                        _result = siemensTcpNet.ReadBool(_Address).Content.ToString();
                        return true;
                    case PLCDataType.Byte:
                        _result = siemensTcpNet.ReadByte(_Address).Content.ToString();
                        return true;
                    case PLCDataType.Short:
                        _result = siemensTcpNet.ReadInt16(_Address).Content.ToString();
                        return true;
                    case PLCDataType.UShort:
                        _result = siemensTcpNet.ReadUInt16(_Address).Content.ToString();
                        return true;
                    case PLCDataType.Int:
                        _result = siemensTcpNet.ReadInt32(_Address).Content.ToString();
                        return true;
                    case PLCDataType.UInt:
                        _result = siemensTcpNet.ReadUInt32(_Address).Content.ToString();
                        return true;
                    case PLCDataType.Long:
                        _result = siemensTcpNet.ReadInt64(_Address).Content.ToString();
                        return true;
                    case PLCDataType.ULong:
                        _result = siemensTcpNet.ReadUInt64(_Address).Content.ToString();
                        return true;
                    case PLCDataType.Float:
                        _result = siemensTcpNet.ReadFloat(_Address).Content.ToString();
                        return true;
                    case PLCDataType.Double:
                        _result = siemensTcpNet.ReadDouble(_Address).Content.ToString();
                        return true;
                    case PLCDataType.String:
                        _result = siemensTcpNet.ReadString(_Address).Content.ToString();
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            
            
        }
        /// <summary>
        /// 写入数据到PLC
        /// </summary>
        /// <param name="_Address">地址</param>
        /// <param name="_Type">类型</param>
        /// <param name="_Data">数据</param>
        /// <returns></returns>
        public bool Write(string _Address, PLCDataType _Type, string _Data)
        {
            try
            {
                switch (_Type)
                {
                    case PLCDataType.Bool:
                        siemensTcpNet.Write(_Address,Convert.ToBoolean(_Data));
                        return true;
                    case PLCDataType.Byte:
                        siemensTcpNet.Write(_Address, byte.Parse(_Data));
                        return true;
                    case PLCDataType.Short:
                        siemensTcpNet.Write(_Address,short.Parse(_Data));
                        return true;
                    case PLCDataType.UShort:
                        siemensTcpNet.Write(_Address,ushort.Parse(_Data));
                        return true;
                    case PLCDataType.Int:
                        siemensTcpNet.Write(_Address,int.Parse(_Data));
                        return true;
                    case PLCDataType.UInt:
                        siemensTcpNet.Write(_Address,uint.Parse(_Data));
                        return true;
                    case PLCDataType.Long:
                        siemensTcpNet.Write(_Address,long.Parse(_Data));
                        return true;
                    case PLCDataType.ULong:
                        siemensTcpNet.Write(_Address,ulong.Parse(_Data));
                        return true;
                    case PLCDataType.Float:
                        siemensTcpNet.Write(_Address,float.Parse(_Data));
                        return true;
                    case PLCDataType.Double:
                        siemensTcpNet.Write(_Address,Convert.ToDouble(_Data));
                        return true;
                    case PLCDataType.String:
                        siemensTcpNet.Write(_Address,_Data);
                        return true;
                }
                PLCStatus = false;
                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public bool Close()
        {
            try
            {
                siemensTcpNet.ConnectClose();
                return true;
            }catch
            {
                return false;
            }
            
        }
        public void scanReadData(string _name)
        {
            while (true)
            {
                Thread.Sleep(50);
                string address = null;
                string laserAddress = null;
                if (PLCStatus)
                {
                    if (Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_name].dicPlcReadData.Count != 0)
                    {
                        string result = null;
                        foreach (var item in Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_name].dicPlcReadData)
                        {
                            if (item.Value.type == PLCDataType.Byte)
                            {
                                address = item.Value.Address.Split('.')[0];
                                if (address == laserAddress)
                                {

                                }
                                else
                                {
                                    Read(address, item.Value.type, out result);
                                    result = result.PadRight(int.Parse(item.Value.Lenght), '0');
                                    laserAddress = address;
                                    foreach (var item1 in Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_name].dicPlcReadData)
                                    {
                                        if (item1.Value.type == PLCDataType.Byte)
                                        {
                                            if (item1.Value.Address.Split('.')[0] == address)
                                            {
                                                var strToBytes = System.Text.Encoding.UTF8.GetBytes(result);
                                                item1.Value.data = (strToBytes[int.Parse(item1.Value.Address.Split('.')[1])] - 48).ToString();
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Read(item.Value.Address, item.Value.type, out result);
                                item.Value.data = result;
                            }
                        }
                    }
                }
            }
        }
        public void scanWriteData (string _name)
        {
            while (true)
            {
                Thread.Sleep(50);
                string address = null;
                string laserAddress = null;
                if (Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_name].dicWritePlcData.Count != 0)
                {
                    if (PLCStatus)
                    {
                        foreach (var item in Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_name].dicWritePlcData)
                        {
                            if (item.Value.type == PLCDataType.Byte)
                            {
                                address = item.Value.Address.Split('.')[0];
                                if (address == laserAddress)
                                    break;
                                else
                                {
                                    string data = null;
                                    WriteByte(Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_name].dicWritePlcData, ref data);
                                    Write(item.Value.Address, item.Value.type, data);
                                    laserAddress = address;
                                }
                            }
                            else
                            {
                                Write(item.Value.Address, item.Value.type, item.Value.data);
                            }
                        }
                    }
                }

            }
        }
        private void WriteByte(Dictionary<string, PLCData> _dicWriteData,ref string _data)
        {
            List<string> dicRepeat = new List<string>();
            List<byte> listByte = new List<byte>();
            string str = null;
            foreach (var item in _dicWriteData)
            {
                if (item.Value.type == PLCDataType.Byte)
                {
                    dicRepeat.Add(item.Value.Address.Split('.')[0]);
                }
            }
            var duplicateValues = dicRepeat.GroupBy(x => x).Where(g => g.Count() > 1).Select(y => y.Key).ToList();
            foreach (var item in duplicateValues)
            {
                listByte.Clear();
                foreach (var item1 in _dicWriteData)
                {
                    if (item == item1.Value.Address.Split('.')[0])
                    {
                        listByte.Add(Convert.ToByte(item1.Value.data));
                    }
                }
                listByte.Reverse();
                str = string.Join("", listByte);
                if (listByte.Count < 4)
                {
                    str = str.PadRight(4, '0');
                    
                }
                _data = Convert.ToInt32(str, 2).ToString();
                
            }
        }

    }
}
