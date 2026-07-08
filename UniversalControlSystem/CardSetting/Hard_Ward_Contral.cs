using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalControlSystem.PLC;

namespace UniversalControlSystem
{
    static public class Hard_Ward_Contral
    {
        static public double currentV = 0;
        //硬件数据类
        static public CardDate_Save hardDoc;
        static public Dictionary<string, CardDate> CardDateDictionary;
        static public Dictionary<string, GoogolTechExtCardInfoForm> GoogolTechExtCardInfoFormFormDictionary = new Dictionary<string, GoogolTechExtCardInfoForm>();
        static public Dictionary<string, GoolGaoHardSettingForm> GoolGaoHardSettingFormFormDictionary = new Dictionary<string, GoolGaoHardSettingForm>();
        //硬件控制类
        static public Googol_Contral Googol_Con;
        //硬件IO数据类
        static public Hardware_IO_Sta Hardware_IO_State;
        static public Dictionary<string, FormIOSetting> Hardware_IO_Sta_SettingFormDictionary = new Dictionary<string, FormIOSetting>();
        //轴数据类
        static public Aisx_Hard Aisx_Hard_Doc;
        //轴数据界面
        static public Dictionary<string, FormAxisSetting> GoolGaoAxisHardSettingFormDictionary = new Dictionary<string, FormAxisSetting>();
        //波形数据类
        static public Wave_Date_Save Wave_Date_Save_Doc;
        static public Wave_Date_From_Save Wave_Date_From_Save_Doc;
        //波形数据界面
        static public Dictionary<string, AnalogQuantityOutFrom> Wave_Date_Save_SettingFormDictionary = new Dictionary<string, AnalogQuantityOutFrom>();
        //测距数据与其他数据
        static public Get_High_Date_Save _Get_High_Date_Save;
        //测距数据与其他数据界面
        static public Dictionary<string, OtherForm> OtherFormSettingDictionary = new Dictionary<string, OtherForm>();



        /// <summary>
        ///通讯访问数据
        /// </summary>
        static public SerialPortDate_Save S_PortDate_Save;

        /// <summary>
        ///通讯访问窗体
        /// </summary>
        /// 
        static public Dictionary<string, SerialPortFrom> S_PortDate_SaveFormSettingDictionary = new Dictionary<string, SerialPortFrom>();
        static public Dictionary<string, network> network_SaveFormSettingDictionary = new Dictionary<string, network>();
        static public Dictionary<string, networkSer> networkSer_SaveFormSettingDictionary = new Dictionary<string, networkSer>();
        //焊接参数
        static public LaserControlParameter _LaserControlParameter;
        //public static FormAlarm m_FormAlarm = new FormAlarm();
        //plc参数
        static public PLC_Control _PLC_ControlParameter;
        ///plc访问窗体
        static public Dictionary<string, PLC_Setting> PLC_Control_FormSettingDictionary = new Dictionary<string, PLC_Setting>();

        //数据组数据
        static public DateGroup _DateGroupParameter;
        ///数据组数据窗体
        static public Dictionary<string, DateGroup_Setting> DateGroup_FormSettingDictionary = new Dictionary<string, DateGroup_Setting>();
        /// <summary>
        /// 数据加载
        /// </summary>
        /// 

        //接口控制字典
        static public Dictionary<string, ContraInterface> ContraInterfaceDictionary = new Dictionary<string, ContraInterface>();
        static public Dictionary<string, object> ContraObjetDictionary = new Dictionary<string, object>();
        static public ContraInterface _ContraInterface;



        ///流程访问窗体
        static public Dictionary<string, FlowCharForm> FlowCharForm_SettingDictionary = new Dictionary<string, FlowCharForm>();

        //流程参数
        static public FlowChar_Control _FlowChar_ControlParameter;

        ///点位访问窗体
        static public Dictionary<string, PointSet_Setting> PointrForm_SettingDictionary = new Dictionary<string, PointSet_Setting>();

        //点位参数
        static public Point_Control _Point_ControlParameter;

        //点位设置窗体
        static public Dictionary<string, PointSetting_Form> LeftPointSetting_FormDictionary = new Dictionary<string, PointSetting_Form>();
        static public Dictionary<string, PointSetting_Form> RightPointSetting_FormDictionary = new Dictionary<string, PointSetting_Form>();
        static public void LoadData()
        {
            try
            {
                //硬件数据加载
                hardDoc = CardDate_Save.LoadObj();
                hardDoc.m_HardWareDictionary = hardDoc.m_HardWareList.ToDictionary(p => p.hardwareName);
                Program.logger.Info("加载硬件数据成功");
            }
            catch (Exception ex)
            {
                //MainForm.m_FormAlarm.InsertAlarmMessage(ex.Message);
            }

            try
            {
                //轴数据加载
                Aisx_Hard_Doc = Aisx_Hard.LoadObj();
                Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary = Aisx_Hard_Doc.mAisx_Hard_Date_List.ToDictionary(p => p.Axis_hardwareName);
                Program.logger.Info("加载轴数据成功");
            }
            catch (Exception ex)
            {
                //MainForm.m_FormAlarm.InsertAlarmMessage(ex.Message);
            }
            try
            {
                //IO数据加载
                if (hardDoc.m_HardWareList.Count != 0)
                {
                    Hardware_IO_State = Hardware_IO_Sta.LoadObj();
                    Hardware_IO_State.m_Hard_IOInPut_Dictionary = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List.ToDictionary(p => p.hardIOName);
                    Hardware_IO_State.m_Hard_IOOutPut_Dictionary = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List.ToDictionary(p => p.hardIOName);
                    Program.logger.Info("加载IO数据成功");
                }
                else
                {
                    Hardware_IO_State = Hardware_IO_Sta.LoadObj();
                    Hardware_IO_State.m_Hard_IOInPut_List.Clear();
                    Hardware_IO_State.m_Hard_IOOutPut_List.Clear();
                    Program.logger.Info("重新加载IO数据成功");
                }
            }
            catch (Exception ex)
            {
                //MainForm.m_FormAlarm.InsertAlarmMessage(ex.Message);
            }
            try
            {
                //波形数据加载
                Wave_Date_From_Save_Doc = Wave_Date_From_Save.LoadObj();

                Wave_Date_From_Save_Doc.Wave_From_Date_Dictionary = Wave_Date_From_Save_Doc.Wave_From_Date_List.ToDictionary(Keys =>
                Keys.Wave_hardwareName);

                Wave_Date_Save_Doc = Wave_Date_Save.LoadObj();
                Wave_Date_Save_Doc.Wave_Date_Dictionary = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_List.ToDictionary(p => p.Wave_hardwareName);
            }
            catch (Exception ex)
            {
                //MainForm.m_FormAlarm.InsertAlarmMessage(ex.Message);
            }
            try
            {
                //测距数据与其他数据
                _Get_High_Date_Save = Get_High_Date_Save.LoadObj();
                _Get_High_Date_Save.Get_High_Hard_Date_Dictionary = _Get_High_Date_Save.Get_High_Hard_Date_List.ToDictionary(P => P.Get_High_hardwareName);
            }
            catch (Exception ex)
            {
                //MainForm.m_FormAlarm.InsertAlarmMessage(ex.Message);
            }
            try
            {
                ///通讯访问数据加载
                /// 
                S_PortDate_Save = SerialPortDate_Save.LoadObj();
                S_PortDate_Save.m_HardWareDictionary = S_PortDate_Save.m_HardWareList.ToDictionary(P => P.hardwareName);
            }
            catch (Exception ex)
            {
                //MainForm.m_FormAlarm.InsertAlarmMessage(ex.Message);
            }
            try
            {
                Communication_DateLoadData.Load();
                ///通讯访问数据初始化
                CommunicationFun.Communication_Init();
            }
            catch (Exception ex)
            {
                //MainForm.m_FormAlarm.InsertAlarmMessage(ex.Message);
            }
            try
            {
                //激光控制参数初始化
                _LaserControlParameter = LaserControlParameter.LoadObj();
                if (_LaserControlParameter._LaserControlData_Dictionary.Count == 0)
                {
                    LaserControlData LaserControlData = new LaserControlData();
                    // LaserControlData.IS_Choose_Laser = false;
                    LaserControlData.InterpolationOperationAngle = 0;
                    LaserControlData.LaserControlDataName = "LaserControlData";
                    _LaserControlParameter._LaserControlData_Dictionary.Add("LaserControlData", LaserControlData);
                    _LaserControlParameter._LaserControlData_List.Add(LaserControlData);
                }
                else
                {
                    _LaserControlParameter._LaserControlData_Dictionary = _LaserControlParameter._LaserControlData_List.ToDictionary(Keys =>
          Keys.LaserControlDataName);
                }
            }
            catch (Exception ex)
            {
                //MainForm.m_FormAlarm.InsertAlarmMessage(ex.Message);
            }
            //PLC数据加载
            try
            {
                _PLC_ControlParameter = PLC_Control.LoadObj();
                _PLC_ControlParameter._PLC_ControlData_Dictionary = _PLC_ControlParameter._PLC_ControlData_List.ToDictionary(Keys =>
                 Keys.PLC_ControlDataName);
                PLCCommunicationFun.InitPLC();
            }
            catch
            {
            }
            //初始化数据组
            DataManage.LoadData();
            try
            {
                _DateGroupParameter = DateGroup.LoadObj();
                _DateGroupParameter._DateGroup_Dictionary = _DateGroupParameter._DateGroup_List.ToDictionary(Keys => Keys.Group_ControlDataName);
                foreach (var item in _DateGroupParameter._DateGroup_Dictionary)
                {
                    if (item.Value.Group_ControlDataTpye == "BOOL")
                    {
                        item.Value.Date = false;
                    }
                    else if (item.Value.Group_ControlDataTpye == "STRING")
                    {
                        item.Value.Date = "";
                    }
                    else if (item.Value.Group_ControlDataTpye == "DOUBLE")
                    {
                        item.Value.Date = 0.0;
                    }
                    else if (item.Value.Group_ControlDataTpye == "SHORT")
                    {
                        item.Value.Date = 0;
                    }
                    else if (item.Value.Group_ControlDataTpye == "LONG")
                    {
                        item.Value.Date = 0;
                    }

                }

            }
            catch
            {
            }
            try
            {

                _FlowChar_ControlParameter = FlowChar_Control.LoadObj();
                foreach (var item in _FlowChar_ControlParameter._FlowChar_ControlData_List)
                {
                    string path = System.Environment.CurrentDirectory + @"\FlowChar_ControlData";
                    int index = item.sPath.LastIndexOf("\\");
                    string subpath = item.sPath.Substring(0, index);
                    string endpath = item.sPath.Substring(index, item.sPath.Length - index);
                    if (subpath != path)
                    {
                        item.sPath = path + endpath;
                    }
                }
                Hard_Ward_Contral._FlowChar_ControlParameter.SaveDoc();
                //FlowChar_Control._FlowChar_Control = FlowChar_Control.Deserialize() as _FlowChar_Control_Date; ;
                _FlowChar_ControlParameter._FlowChar_ControlData_Dictionary = _FlowChar_ControlParameter._FlowChar_ControlData_List.ToDictionary(Keys => Keys.FlowChar_ControlDataName);
            }
            catch
            {
            }
            try
            {
                _Point_ControlParameter = Point_Control.LoadObj();
                _Point_ControlParameter._Point_ControlData_Dictionary = _Point_ControlParameter._Point_ControlData_List.ToDictionary(Keys => Keys.Point_ControlDataName);
            }
            catch
            {
            }
            try
            {
                foreach (var item in hardDoc.m_HardWareDictionary)
                {
                    switch (item.Value.m_Brand)
                    {
                        case "固高":
                            switch (item.Value.m_Model)
                            {
                                case "GTS":
                                    try
                                    {
                                        Googol_Contral _Googol_Contral = new Googol_Contral();
                                        ContraObjetDictionary.Add(item.Value.hardwareName, _Googol_Contral);
                                    }
                                    catch
                                    {
                                    }
                                    break;
                                case "GTN":
                                    try
                                    {
                                        Googol_gtn_Contral _Googol_gtn_Contral = new Googol_gtn_Contral();
                                        ContraObjetDictionary.Add(item.Value.hardwareName, _Googol_gtn_Contral);
                                    }
                                    catch
                                    {
                                    }
                                    break;
                            }

                            break;
                        case "凌华控制卡":

                            break;
                        case "凌华IO卡":
                            break;
                        case "雷塞":

                            break;
                    }
                }


                //Properties.Settings.Default.FlowRunPath
                //初始化卡
                string nameCom = "";
                foreach (var item in hardDoc.m_HardWareDictionary)
                {
                    try
                    {
                        ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[item.Value.hardwareName];
                        if (item.Value.iExtNo == -1)
                        {
                            nameCom = item.Value.hardwareName;
                            IFC.Init(hardDoc);
                            break;
                        }
                        else
                        {

                        }
                    }
                    catch
                    {

                    }                 
                }

                foreach (var item in Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                {
                    short rtn;
                    short slave = 0;
                    short master = 0;
                    if (item.Value.是否双驱 == false)
                        continue;
                    else
                    {
                        slave = (short)(item.Value.从轴号 + 1);
                        master = (short)(item.Value.m_AxisNo + 1);
                    } 
                    //将从轴使能信号挂接到主轴 
                    gts.mc_cfg.TDoConfig doConfig;
                    rtn = gts.mc_cfg.GT_GetDoConfig(0, gts.mc.MC_ENABLE, slave, out doConfig);
                    doConfig.axis = master;
                    rtn += gts.mc_cfg.GT_SetDoConfig(0, gts.mc.MC_ENABLE, slave, ref doConfig);

                    //将从轴脉冲信号挂接到主轴
                    gts.mc_cfg.TStepConfig stepConfig;
                    rtn += gts.mc_cfg.GT_GetStepConfig(0, slave, out stepConfig);
                    stepConfig.axis = master;
                    stepConfig.active = 1;
                    rtn += gts.mc_cfg.GT_SetStepConfig(0, slave, ref stepConfig);

                    rtn += gts.mc.GT_ClrSts(0, 1, 4);
                    if (rtn != 0)
                    {
                        MessageBox.Show("开环龙门初始化失败！");
                    }
                }

                //Googol_Con = new Googol_Contral();
                //  if (Inin() == false)
                //  {
                //      MessageBox.Show("初始化硬件失败");
                //      //MainForm.m_FormAlarm.InsertAlarmMessage(AlarmError.初始化卡失败.ToString());
                //      FormStart.LOG_ShowFrom["系统LOG"].Enqueue("初始化硬件失败");
                //     // Weld_Log.Instance().Enqueue("初始化硬件失败");
                //  }

                foreach (var item in Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
                {
                    item.Value.AisxCurrentPosition = 0;
                    item.Value.bFlagServoOn = false;
                    gts.mc.GT_AxisOn((short)item.Value.m_CardNo, (short)(item.Value.m_AxisNo + 1));
                    // Program.logger.Info("轴使能成功");
                }
                ////左工位选择流程数据加载
                //Select_Task_Doc = SelectTask.LoadObj();
                //Select_Task_Doc.mSelect_Task_Date_Dictionary = Select_Task_Doc.mSelect_Task_Date_List.ToDictionary(p => p.Selected_Task);
                //Program.logger.Info("左工位加载选择流程数据成功");
                ////右工位选择流程数据加载
                //RightSelect_Task_Doc = RightSelectTask.LoadObj();
                //RightSelect_Task_Doc.mRightSelect_Task_Date_Dictionary = RightSelect_Task_Doc.mRightSelect_Task_Date_List.ToDictionary(p => p.RightSelected_Task);
                //Program.logger.Info("右工位加载选择流程数据成功");   
            }
            catch (Exception ex)
            {
                //MainForm.m_FormAlarm.InsertAlarmMessage(ex.Message);
            }
        }

        public static void setDateGrout(string DateName)
        {
            int res = -1;
            if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Group_ControlDataTpye == "LONG")
            {


                try
                {
                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date = 0;
                    res = 0;
                }
                catch
                {
                    res = (int)ERecvResult.数据组设置数据错误;
                }


            }
            if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Group_ControlDataTpye == "STRING")
            {
                try
                {
                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date = "";
                    res = 0;
                }
                catch
                {
                    res = (int)ERecvResult.数据组设置数据错误;
                }
            }
            if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Group_ControlDataTpye == "SHORT")
            {


                try
                {
                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date = 0;
                    res = 0;
                }
                catch
                {
                    res = (int)ERecvResult.数据组设置数据错误;
                }

            }
            if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Group_ControlDataTpye == "DOUBLE")
            {


                try
                {
                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date = 0;
                    res = 0;
                }
                catch
                {
                    res = (int)ERecvResult.数据组设置数据错误;
                }

            }
            if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Group_ControlDataTpye == "BOOL")
            {

                try
                {
                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date = false;
                    res = 0;
                }
                catch { res = (int)ERecvResult.数据组设置数据错误; }

            }

        }
        /// <summary>
        /// 初始化硬件
        /// </summary>
        static public bool Inin()
        {
            try
            { //初始化卡
                foreach (var item in hardDoc.m_HardWareDictionary)
                {
                    ContraInterface IFC = (ContraInterface)Hard_Ward_Contral.ContraObjetDictionary[item.Value.hardwareName];
                    IFC.Init(hardDoc);
                }
                return true;
            }
            catch (Exception ex)
            {
                //MainForm.m_FormAlarm.InsertAlarmMessage(ex.Message);
                return false;
            }
        }
        static public void CloseHardWare()
        {
            foreach (var item in hardDoc.m_HardWareDictionary)
            {
                if (item.Value.m_strHardWare_Modle == "卡硬件")
                {
                }
                else if (item.Value.m_strHardWare_Modle == "IO硬件")
                {

                }
            }
        }
    }
}




