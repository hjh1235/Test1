using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UniversalControlSystem.PLC.PLC_Class_Ctr;

namespace UniversalControlSystem.PLC
{
    public enum PLCBrand
    {
        西门子,
        三菱,
        台达,
        松下,
        欧姆龙,
        基恩士
    }
    class PLCCommunicationFun
    {
        public static Dictionary<string, object> PLCControlFuntion = new Dictionary<string, object>();
        private static bool rt = false;
        public static bool InitPLC()
        {
            try
            {
                PLCControlFuntion.Clear(); 
                foreach (var item in Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary)
                {
                    PLCBrand plcType = (PLCBrand)Enum.Parse(typeof(PLCBrand),item.Value.PLC_ControlDataVender);
                    switch (plcType)
                    {
                        case PLCBrand.西门子:
                            Siemens Siemens = new Siemens();
                            //将list中数据转换到字典中
                            item.Value.dicPlcReadData = item.Value.PlcReadData.ToDictionary(keys => keys.Name);
                            item.Value.dicWritePlcData = item.Value.PlcWriteData.ToDictionary(keys => keys.Name);
                            Siemens.Close();
                            //连接PLC
                            rt = Siemens.Init(item.Value.PLC_ControlAddress, item.Value.PLC_ControlProt,
                                            item.Value.PLC_ControlRack, item.Value.PLC_ControlSlot);
                            //设置连接状态
                            item.Value.State = (rt) ? true : false;
                            PLCControlFuntion.Add(item.Key, Siemens);
                            //循环读取和写入数据到PLC
                            ThreadPool.QueueUserWorkItem(state => Siemens.scanReadData(item.Value.PLC_ControlDataName));
                            Thread.Sleep(30);
                            ThreadPool.QueueUserWorkItem(state => Siemens.scanWriteData(item.Value.PLC_ControlDataName));
                            break;
                        case PLCBrand.基恩士:
                            KEYENCE KEYENCE = new KEYENCE();
                            //将list中数据转换到字典中
                            item.Value.dicPlcReadData = item.Value.PlcReadData.ToDictionary(keys => keys.Name);
                            item.Value.dicWritePlcData = item.Value.PlcWriteData.ToDictionary(keys => keys.Name);
                            //KEYENCE.Close();
                            //初始化连接PLC
                            rt = KEYENCE.Init(item.Value.PLC_ControlAddress, item.Value.PLC_ControlProt);
                            //设置连接状态
                            item.Value.State = (rt) ? true : false;
                            PLCControlFuntion.Add(item.Key, KEYENCE);
                            //循环读取和写入数据到PLC
                            //ThreadPool.QueueUserWorkItem(state => KEYENCE.scanReadData(item.Value.PLC_ControlDataName));
                            //Thread.Sleep(50);
                            ThreadPool.QueueUserWorkItem(state => KEYENCE.scanWriteHeartbeat());
                            break;
                    }

                }
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
            
        }
        /// <summary>
        /// 读取数据
        /// </summary>
        /// <param name="_ResourcesName">资源名称</param>
        /// <param name="_Address">读取地址</param>
        /// <param name="_Type">数据类型</param>
        /// <param name="_result">返回结果</param>
        /// <returns></returns>
        public static bool Read(string _ResourcesName,string _Address, PLCDataType _Type, out string _result)
        {
            _result = null;
            PLCBrand plcType = (PLCBrand)Enum.Parse(typeof(PLCBrand),
                Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_ResourcesName].PLC_ControlDataVender);
            switch (plcType)
            {
                case PLCBrand.西门子:
                    Siemens siemens = (Siemens)PLCControlFuntion[_ResourcesName];
                    rt = siemens.Read(_Address, _Type, out _result);
                    return rt;
                case PLCBrand.基恩士:
                    KEYENCE KEYENCE = (KEYENCE)PLCControlFuntion[_ResourcesName];
                    rt = KEYENCE.Read(_Address,_Type, out _result);
                    return rt;
            }
            return false;

        }
        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="_ResourcesName">资源名称</param>
        /// <param name="_Address">写入地址</param>
        /// <param name="_Type">写入类型</param>
        /// <param name="_Data">写入数据</param>
        /// <returns></returns>
        public static bool Write(string _ResourcesName,string _Address, PLCDataType _Type, string _Data)
        {
            PLCBrand plcType = (PLCBrand)Enum.Parse(typeof(PLCBrand),
                Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_ResourcesName].PLC_ControlDataVender);
            switch (plcType)
            {
                case PLCBrand.西门子:
                    Siemens siemens = (Siemens)PLCControlFuntion[_ResourcesName];
                    rt = siemens.Write(_Address, _Type, _Data);
                    return rt;
                case PLCBrand.基恩士:
                    KEYENCE KEYENCE = (KEYENCE)PLCControlFuntion[_ResourcesName];
                    rt = KEYENCE.Write(_Address,_Type, _Data);
                    return rt;
            }
            return false;

        }
        public static bool Connect(string _ResourcesName)
        {
            try
            {
                PLCBrand plcType = (PLCBrand)Enum.Parse(typeof(PLCBrand),
                Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_ResourcesName].PLC_ControlDataVender);
                switch (plcType)
                {
                    case PLCBrand.西门子:
                        Siemens siemens = (Siemens)PLCControlFuntion[_ResourcesName];
                        rt = siemens.Init(Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_ResourcesName].PLC_ControlAddress,
                            Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_ResourcesName].PLC_ControlProt,
                            Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_ResourcesName].PLC_ControlRack,
                            Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_ResourcesName].PLC_ControlSlot);
                        return rt;
                    case PLCBrand.基恩士:
                        KEYENCE KEYENCE = (KEYENCE)PLCControlFuntion[_ResourcesName];
                        rt = KEYENCE.Init(Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_ResourcesName].PLC_ControlAddress,
                            Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_ResourcesName].PLC_ControlProt);
                        return rt;
                }
                return false;
            }
            catch
            {
                return false;
            }
            
        }
        public static bool Close(string _ResourcesName)
        {
            try
            {
                PLCBrand plcType = (PLCBrand)Enum.Parse(typeof(PLCBrand),
                Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_ResourcesName].PLC_ControlDataVender);
                switch (plcType)
                {
                    case PLCBrand.西门子:
                        Siemens siemens = (Siemens)PLCControlFuntion[_ResourcesName];
                        rt = siemens.Close();
                        if (rt) 
                            Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_ResourcesName].State = true;
                        return true;
                    case PLCBrand.基恩士:
                        KEYENCE KEYENCE = (KEYENCE)PLCControlFuntion[_ResourcesName];
                        rt = KEYENCE.Close();
                        if (rt)
                            Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[_ResourcesName].State = true;
                        return rt;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
