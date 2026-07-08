using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using UniversalControlSystem.PLC;

namespace UniversalControlSystem
{
    [XmlInclude(typeof(FlowChar_Control)), XmlInclude(typeof(_FlowChar_Control_Date)), XmlInclude(typeof(Point_Control)), XmlInclude(typeof(_Point_Control_Date))]
    /// <summary>
    /// 卡数据类
    /// </summary>
    public partial class CardDate_Save
    {
        public List<CardDate> m_HardWareList;
        [XmlIgnore]
        public Dictionary<string, CardDate> m_HardWareDictionary;
        public CardDate_Save()
        {
            m_HardWareList = new List<CardDate>();
            m_HardWareDictionary = new Dictionary<string, CardDate>();
        }
        /// <summary>
        /// 加载卡参数数据
        /// </summary>
        /// <returns></returns>
        public static CardDate_Save LoadObj()
        {
            CardDate_Save pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CardDate_Save));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/CardDate_Save" + ".xml");
                pDoc = (CardDate_Save)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();
                //Properties.Settings.Default.iIOCardCount = pDoc.m_HardWareList.Count;
                Properties.Settings.Default.iControlIOCardCount = 0;
                Properties.Settings.Default.iModuleIOCardCount = 0;
                foreach (var item in pDoc.m_HardWareList)
                {
                    if (item.m_strHardWare_Modle == "卡硬件")
                    {
                        Properties.Settings.Default.iControlIOCardCount++;
                    }
                    else
                    {
                        Properties.Settings.Default.iModuleIOCardCount++;
                    }
                }
                Properties.Settings.Default.Save();
            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new CardDate_Save();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/CardDate_Save" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CardDate_Save));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();
            return true;
        }
    }
    /// <summary>
    /// 卡数据类实例类
    /// </summary>
    public partial class CardDate
    {
        public string m_Brand { get; set; }//卡品牌
        public string m_Model { get; set; }//卡型号
        public string m_strHardWare_Modle { get; set; }//卡模式
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }

        public int iCardNo { get; set; }
        public int iExtNo { get; set; }
        public string sCardName { get; set; }
        public string m_strConfigPath { get; set; }
        public string m_strCardDllName { get; set; }

        public string m_strExtPath { get; set; }
        public string m_strExtDllName { get; set; }
        public int txt_MaxSpeed { get; set; }//坐标系最大速度
        public int txt_MaxAcc { get; set; }//坐标系最大加速度
    }
    /// <summary>
    /// 输入IO状态类
    /// </summary>
    public partial class IOCardSta_InPut
    {

        public string hardIOName { get; set; }
        //是否屏蔽
        public bool bignore { get; set; }
        public string hard_IO_Name { get; set; }//ON CHANGE
        public int iCardNo { get; set; }
        public int iExtNo { get; set; }
        public int iBitNo { get; set; }
        public bool bBitInputStatus { get; set; }
        public string m_Brand { get; set; }//卡品牌
        public string m_Model { get; set; }//卡型号

    }
    /// <summary>
    /// 输出IO状态类
    /// </summary>
    public partial class IOCardSta_OutPut
    {
        //品牌

        public string hardIOName { get; set; }
        //是否屏蔽
        public bool bignore { get; set; }
        public string hard_IO_Name { get; set; }//ON CHANGE
        public int iCardNo { get; set; }
        public int iExtNo { get; set; }
        public int iBitNo { get; set; }
        public bool bBitOutputStatus { get; set; }
        public string m_Model { get; set; }
        public string m_Brand { get; set; }//卡品牌
                                           //public string m_Model { get; set; }//卡型号
    }
    /// <summary>
    /// IO输入输出状态控制类
    /// </summary>
    public partial class Hardware_IO_Sta
    {
        public List<IOCardSta_InPut> m_Hard_IOInPut_List;
        [XmlIgnore]
        public Dictionary<string, IOCardSta_InPut> m_Hard_IOInPut_Dictionary;
        public List<IOCardSta_OutPut> m_Hard_IOOutPut_List;
        [XmlIgnore]
        public Dictionary<string, IOCardSta_OutPut> m_Hard_IOOutPut_Dictionary;
        public Hardware_IO_Sta()
        {
            m_Hard_IOInPut_List = new List<IOCardSta_InPut>();
            m_Hard_IOInPut_Dictionary = new Dictionary<string, IOCardSta_InPut>();

            m_Hard_IOOutPut_List = new List<IOCardSta_OutPut>();
            m_Hard_IOOutPut_Dictionary = new Dictionary<string, IOCardSta_OutPut>();
        }
        public static Hardware_IO_Sta LoadObj()
        {
            Hardware_IO_Sta pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Hardware_IO_Sta));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/IOCardDate_Save" + ".xml");
                pDoc = (Hardware_IO_Sta)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();

            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new Hardware_IO_Sta();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/IOCardDate_Save" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Hardware_IO_Sta));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();

            return true;
        }
    }
    /// <summary>
    /// 轴数据实例类
    /// </summary>
    public partial class Aisx_Hard_Date
    {
        public string Axis_hardwareName { get; set; }
        public string Axis_hardwareTpye { get; set; }
        public string Axis_hardwareVender { get; set; }
        public string MainCradBinding { get; set; }//与主卡绑定

        public int m_CardNo { get; set; }
        public int m_AxisNo { get; set; }
        public double Acc { get; set; }
        public double Dec { get; set; }
        public double Speed { get; set; }

        public double 搜索限位速度 { get; set; }
        public double Auto_Speed { get; set; }
        public double GoHomeSpeed { get; set; }
        public double PlusFeed { get; set; }
        public int BuildCorNum { get; set; }//坐标系编号
        public double InterpolationPosition { get; set; }//插补位置
        public int DisNegativeSearch { get; set; }//回原搜索距离
        /// <summary>
        /// 轴当前位置
        /// </summary>
        public double AisxCurrentPosition { get; set; }//
        public double AisxCurrentEncPos { get; set; }//
        /// <summary>
        /// 轴当前状态
        /// </summary>
        public string AisxIsCurrentSta { get; set; }
        /// <summary>
        /// 轴是否报警
        /// </summary>
        public bool bAlarm { get; set; }
        /// <summary>
        /// 轴正限位状态
        /// </summary>
        public bool bCWL { get; set; }
        /// <summary>
        /// 轴正限位报警状态
        /// </summary>
        public bool bCWLAlarm { get; set; }
        /// <summary>
        /// 轴原点位状态标志
        /// </summary>
        public bool bOrg { get; set; }
        /// <summary>
        /// 轴负限位状态
        /// </summary>
        public bool bCCWL { get; set; }
        /// <summary>
        /// 轴负限位报警状态标志
        /// </summary>
        public bool bCCWLAlarm { get; set; }

        /// <summary>
        /// 轴运动状态
        /// </summary>
        public bool bMovSta { get; set; }
        /// <summary>
        /// 当前轴速度
        /// </summary>
        public double dCurrentVel { get; set; }
        /// <summary>
        /// 使能标志
        /// </summary>
        public bool bFlagServoOn { get; set; }
        /// <summary>
        /// 急停标志
        /// </summary>
        public bool bFlagAbruptStop { get; set; }
        /// <summary>
        /// 平滑停止
        /// </summary>
        public bool bFlagSmoothStop { get; set; }
        // 跟随误差越限标志
        public bool bFlagMError { get; set; }
        /// <summary>
        /// 回原完成
        /// </summary>
        public bool Go_HomeFinishi { get; set; }
        /// <summary>
        /// 回原中
        /// </summary>
        public bool Go_Homing { get; set; }
        /// <summary>
        /// 轴运动到位检测
        /// </summary>
        public bool Move_Done { get; set; }

        public int 是否做测距轴 { get; set; }
        public int 是否做插补轴 { get; set; }
        public bool 是否屏蔽 { get; set; }
        public string 回原方式 { get; set; }
        public int 从轴号 { get; set; }
        public bool 是否双驱 { get; set; }
        //List<double> Position = new List<double>();
    }
    /// <summary>
    /// 轴数据类
    /// </summary>
    public partial class Aisx_Hard
    {
        public List<Aisx_Hard_Date> mAisx_Hard_Date_List;
        [XmlIgnore]
        public Dictionary<string, Aisx_Hard_Date> mAisx_Hard_Date_Dictionary;
        public Aisx_Hard()
        {
            mAisx_Hard_Date_List = new List<Aisx_Hard_Date>();
            mAisx_Hard_Date_Dictionary = new Dictionary<string, Aisx_Hard_Date>();
        }
        public static Aisx_Hard LoadObj()
        {
            Aisx_Hard pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Aisx_Hard));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/Aisx_Hard" + ".xml");
                pDoc = (Aisx_Hard)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();
                Properties.Settings.Default.iAxisCount = pDoc.mAisx_Hard_Date_List.Count;
                //Properties.Settings.Default.Save();

                Program.iarryCardNum = new int[Properties.Settings.Default.iControlIOCardCount];//每张卡对应其下轴的数量数组
                                                                                                //遍历运动控制卡的数量
                for (int i = 0; i < Properties.Settings.Default.iControlIOCardCount; i++)
                {
                    foreach (var item in pDoc.mAisx_Hard_Date_List)
                    {
                        if (item.m_CardNo - 1 == i)
                        {
                            Program.iarryCardNum[i]++;
                        }
                    }
                }
            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new Aisx_Hard();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/Aisx_Hard" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Aisx_Hard));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();

            return true;
        }

    }
    /// <summary>
    /// 波形界面数据实例类
    /// </summary>
    public partial class Wave_From_Date
    {
        public string Wave_hardwareName { get; set; }
        public string Wave_hardwareTpye { get; set; }
        public string Wave_hardwareVender { get; set; }
        //波形名字或编号
        public string Wave_Name { set; get; }
        //波形号
        public string Wave_Number { set; get; }
        //波形号运行功率
        public string Wave_Run_Power { set; get; }
        //波形最大能量
        public double High_Power { set; get; }
        //波形最大电压
        public double High_Voltage { set; get; }
        //波形时间
        public double Times { set; get; }
        //控制模式内控或外控
        public double Contral_Mudule { set; get; }

    }
    /// <summary>
    /// 波形界面数据类
    /// </summary>
    public partial class Wave_Date_From_Save
    {
        public List<Wave_From_Date> Wave_From_Date_List;
        [XmlIgnore]
        public Dictionary<string, Wave_From_Date> Wave_From_Date_Dictionary;
        public Wave_Date_From_Save()
        {
            Wave_From_Date_List = new List<Wave_From_Date>();
            Wave_From_Date_Dictionary = new Dictionary<string, Wave_From_Date>();
        }
        public static Wave_Date_From_Save LoadObj()
        {
            Wave_Date_From_Save pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Wave_Date_From_Save));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/Wave_From_Date" + ".xml");
                pDoc = (Wave_Date_From_Save)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();
            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new Wave_Date_From_Save();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/Wave_From_Date" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Wave_Date_From_Save));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();
            return true;
        }

    }
    /// <summary>
    /// 波形数据实例类
    /// </summary>
    public partial class Wave_Date
    {
        public string Wave_hardwareName { get; set; }
        public string Wave_hardwareTpye { get; set; }
        public string Wave_hardwareVender { get; set; }
        /// <summary>
        /// 波形通道编号
        /// </summary>
        public int Wave_channel_num { get; set; }
        /// <summary>
        /// 波形通道卡号
        /// </summary>
        public int Wave_channel_Card_num { get; set; }
        /// <summary>
        /// 波形控制模式
        /// </summary>
        public int laserPowerMode { get; set; }
        //波形名字或编号
        public string Wave_Name { set; get; }
        //波形号
        public string Wave_Number { set; get; }
        //波形号运行功率
        public string Wave_Run_Power { set; get; }
        //波形最大能量
        public double High_Power { set; get; }
        //波形最大电压
        public double High_Voltage { set; get; }
        //波形时间
        public double Times { set; get; }
        //功率展示
        public double Powers { set; get; }
        //输出电压
        public double Voltages { set; get; }
        //控制模式内控或外控
        public double Contral_Mudule { set; get; }
        //是否出光
        public bool IS_Choose_Laser { get; set; }
        // 运行完成 
        public bool Laser_Run_Finish { get; set; }
        public double currentV { get; set; }

        public string 高速IO激光口1 { get; set; }
        public string 高速IO激光口2 { get; set; }
        public string 高速IO激光口3 { get; set; }
        public string 高速IO激光口4 { get; set; }
        public string 高速IO口激光完成 { get; set; }
        public string 高速IO输出口 { get; set; }

    }
    /// <summary>
    /// 波形数据类
    /// </summary>
    public partial class Wave_Date_Save
    {
        public List<Wave_Date> Wave_Date_List;
        [XmlIgnore]
        public Dictionary<string, Wave_Date> Wave_Date_Dictionary;
        public Wave_Date_Save()
        {
            Wave_Date_List = new List<Wave_Date>();
            Wave_Date_Dictionary = new Dictionary<string, Wave_Date>();
        }
        public static Wave_Date_Save LoadObj()
        {
            Wave_Date_Save pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Wave_Date_Save));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/Wave_Date_Save" + ".xml");
                pDoc = (Wave_Date_Save)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();
            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new Wave_Date_Save();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/Wave_Date_Save" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Wave_Date_Save));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();
            return true;
        }

    }
    /// <summary>
    /// 测高数据及其他数据
    /// </summary>
    public partial class Get_High
    {
        public string Get_High_hardwareName { get; set; }
        public string Get_High_hardwareTpye { get; set; }
        public string Get_High_hardwareVender { get; set; }

        public int _Channel_Number { set; get; }
        public int _Card_Num { set; get; }
        public double 最小模拟量 { set; get; }
        //波形号
        public double 最大模拟量 { set; get; }

        public double Z轴最小坐标 { set; get; }

        public double Z轴最大坐标 { set; get; }

        public double 关联后所对应 { set; get; }

        public double 基准点模拟量 { set; get; }

        public double 基准Z坐标 { set; get; }

        public double 基准X坐标 { set; get; }

        public double 基准Y坐标 { set; get; }
        public double 调高坐标 { set; get; }
        public string 波形号 { set; get; }
        public double 焊接半径 { set; get; }
        public double 焊接速度 { set; get; }
        public double 铜嘴清理次数 { set; get; }
        public double 离焦量 { set; get; }
        public double X偏距振镜 { set; get; }
        public double Y偏距振镜 { set; get; }
        public double X偏距测高 { set; get; }
        public double Y偏距测高 { set; get; }
        public double Z轴安全高度最高 { set; get; }
        public double Z轴安全高度最低 { set; get; }
        public double 调高最高 { set; get; }
        public double 调高最低 { set; get; }
        //相机位置
        public double 相机位置X { set; get; }
        public double 相机位置Y { set; get; }
        public double 相机位置Z { set; get; }
        //激光位置
        public double 激光位置X { set; get; }
        public double 激光位置Y { set; get; }
        public double 激光位置Z { set; get; }
        //测距仪位置
        public double 测高位置X { set; get; }
        public double 测高位置Y { set; get; }
        public double 测高位置Z { set; get; }

        public double 焊接焦点位置X { set; get; }
        public double 焊接焦点位置Y { set; get; }

        public double 焊接焦点位置Z { set; get; }
        public bool 默认参数 { set; get; }

    }

    public partial class Get_High_Date_Save
    {
        public List<Get_High> Get_High_Hard_Date_List;
        [XmlIgnore]
        public Dictionary<string, Get_High> Get_High_Hard_Date_Dictionary;
        public Get_High_Date_Save()
        {
            Get_High_Hard_Date_List = new List<Get_High>();
            Get_High_Hard_Date_Dictionary = new Dictionary<string, Get_High>();
        }
        public static Get_High_Date_Save LoadObj()
        {
            Get_High_Date_Save pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Get_High_Date_Save));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/Get_High_Date_Save" + ".xml");
                pDoc = (Get_High_Date_Save)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();

            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new Get_High_Date_Save();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/Get_High_Date_Save" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Get_High_Date_Save));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();
            return true;
        }

    }
    /// <summary>
    /// 测高数据
    /// </summary>
    public partial class Weld_date
    {
        public string Weld_date_hardwareName { get; set; }
        public string Weld_date_hardwareTpye { get; set; }
        public string Weld_date_hardwareVender { get; set; }
        public double 相机位置X { set; get; }
        public double 相机位置Y { set; get; }
        //波形号
        public double 激光位置X { set; get; }

        public double 激光位置Y { set; get; }
        public double X偏距振镜 { set; get; }

        public double Y偏距振镜 { set; get; }

        public double 焦点位置X { set; get; }

        public double 焦点位置Y { set; get; }

        public double 波形号 { set; get; }

        public double 焊接半径 { set; get; }

        public double 焊接速度 { set; get; }
        public double 铜嘴清理次数 { set; get; }
        public double 离焦量 { set; get; }
        public double Z轴安全高度最高 { set; get; }
        public double Z轴安全高度最低 { set; get; }
        public double 调高最高 { set; get; }
        public double 调高最低 { set; get; }
    }

    public partial class Weld_date_Date_Save
    {
        public List<Weld_date> Weld_date_Hard_Date_List;
        [XmlIgnore]
        public Dictionary<string, Weld_date> Weld_date_Hard_Date_Dictionary;
        public Weld_date_Date_Save()
        {
            Weld_date_Hard_Date_List = new List<Weld_date>();
            Weld_date_Hard_Date_Dictionary = new Dictionary<string, Weld_date>();
        }
        public static Weld_date_Date_Save LoadObj()
        {
            Weld_date_Date_Save pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Weld_date_Date_Save));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/Get_High_Date_Save" + ".xml");
                pDoc = (Weld_date_Date_Save)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();

            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new Weld_date_Date_Save();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/Get_High_Date_Save" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Weld_date_Date_Save));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();
            return true;
        }

    }
    // public partial class SelectTask
    //{
    //    public List<Select_Task_Data> mSelect_Task_Date_List;
    //    [XmlIgnore]
    //    public Dictionary<string, Select_Task_Data> mSelect_Task_Date_Dictionary;
    //    public SelectTask()
    //    {
    //        mSelect_Task_Date_List = new List<Select_Task_Data>();
    //        mSelect_Task_Date_Dictionary = new Dictionary<string, Select_Task_Data>();
    //    }
    //    public static SelectTask LoadObj()
    //    {
    //        SelectTask pDoc;
    //        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SelectTask));
    //        FileStream fsReader = null;
    //        try
    //        {
    //            fsReader = File.OpenRead(@".//Parameter/Select_Task" + ".xml");
    //            pDoc = (SelectTask)xmlSerializer.Deserialize(fsReader);
    //            fsReader.Close();
    //            //Properties.Settings.Default.iAxisCount = pDoc.mAisx_Hard_Date_List.Count;
    //            //Properties.Settings.Default.Save();
    //        }
    //        catch //(Exception eMy)
    //        {
    //            if (fsReader != null)
    //            {
    //                fsReader.Close();
    //            }
    //            pDoc = new SelectTask();
    //        }
    //        return pDoc;
    //    }
    //    public bool SaveDoc()
    //    {
    //        if (!Directory.Exists(@".//Parameter/"))
    //        {
    //            Directory.CreateDirectory(@".//Parameter/");
    //        }
    //        FileStream fsWriter = new FileStream(@".//Parameter/Select_Task" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
    //        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SelectTask));
    //        xmlSerializer.Serialize(fsWriter, this);
    //        fsWriter.Close();

    //        return true;
    //    }

    //}
    //public partial class Select_Task_Data
    //{
    //    public string Selected_Task { get; set; }//左工位选择的流程
    //    public string TaskProgram { get; set; }//左工位流程方案
    //    public string TaskName { get; set; }//左工位流程名
    //    public int TaskStep { get; set; }//左工位流程步数
    //}
    //public partial class RightSelectTask
    //{
    //    public List<RightSelect_Task_Data> mRightSelect_Task_Date_List;
    //    [XmlIgnore]
    //    public Dictionary<string, RightSelect_Task_Data> mRightSelect_Task_Date_Dictionary;
    //    public RightSelectTask()
    //    {
    //        mRightSelect_Task_Date_List = new List<RightSelect_Task_Data>();
    //        mRightSelect_Task_Date_Dictionary = new Dictionary<string, RightSelect_Task_Data>();
    //    }
    //    public static RightSelectTask LoadObj()
    //    {
    //        RightSelectTask pDoc;
    //        XmlSerializer xmlSerializer = new XmlSerializer(typeof(RightSelectTask));
    //        FileStream fsReader = null;
    //        try
    //        {
    //            fsReader = File.OpenRead(@".//Parameter/RightSelect_Task" + ".xml");
    //            pDoc = (RightSelectTask)xmlSerializer.Deserialize(fsReader);
    //            fsReader.Close();
    //            Properties.Settings.Default.iAxisCount = pDoc.mAisx_Hard_Date_List.Count;
    //            Properties.Settings.Default.Save();
    //        }
    //        catch //(Exception eMy)
    //        {
    //            if (fsReader != null)
    //            {
    //                fsReader.Close();
    //            }
    //            pDoc = new RightSelectTask();
    //        }
    //        return pDoc;
    //    }
    //    public bool SaveDoc()
    //    {
    //        if (!Directory.Exists(@".//Parameter/"))
    //        {
    //            Directory.CreateDirectory(@".//Parameter/");
    //        }
    //        FileStream fsWriter = new FileStream(@".//Parameter/RightSelect_Task" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
    //        XmlSerializer xmlSerializer = new XmlSerializer(typeof(RightSelectTask));
    //        xmlSerializer.Serialize(fsWriter, this);
    //        fsWriter.Close();

    //        return true;
    //    }

    //}
    //public partial class RightSelect_Task_Data
    //{
    //    public string RightSelected_Task { get; set; }//右工位选择的流程
    //    public string RightTaskProgram { get; set; }//右工位流程方案
    //    public string RightTaskName { get; set; }//右工位流程名
    //    public int RightTaskStep { get; set; }//右工位流程步数
    //}

    /// <summary>
    ///激光控制参数
    /// </summary>
    public partial class LaserControlParameter
    {
        public List<LaserControlData> _LaserControlData_List;
        [XmlIgnore]
        public Dictionary<string, LaserControlData> _LaserControlData_Dictionary;
        public LaserControlParameter()
        {
            _LaserControlData_List = new List<LaserControlData>();
            _LaserControlData_Dictionary = new Dictionary<string, LaserControlData>();
        }
        public static LaserControlParameter LoadObj()
        {
            LaserControlParameter pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LaserControlParameter));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/LaserControlParameter" + ".xml");
                pDoc = (LaserControlParameter)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();
                //Properties.Settings.Default.iAxisCount = pDoc.mAisx_Hard_Date_List.Count;
                //Properties.Settings.Default.Save();
            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new LaserControlParameter();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/LaserControlParameter" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LaserControlParameter));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();

            return true;
        }

    }
    public partial class LaserControlData
    {
        public string LaserControlDataName { get; set; }
        public string LaserControlDataTpye { get; set; }
        public string LaserControlDataVender { get; set; }

        public double InterpolationOperationAngle { get; set; }//圆弧插补运行角度

    }

    /// <summary>
    /// plc数据类
    /// </summary>
    public partial class PLC_Control
    {
        public List<PLC_ControlData> _PLC_ControlData_List;
        [XmlIgnore]
        public Dictionary<string, PLC_ControlData> _PLC_ControlData_Dictionary;
        public PLC_Control()
        {
            _PLC_ControlData_List = new List<PLC_ControlData>();
            _PLC_ControlData_Dictionary = new Dictionary<string, PLC_ControlData>();
        }
        public static PLC_Control LoadObj()
        {
            PLC_Control pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PLC_Control));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/PLC_Control" + ".xml");
                pDoc = (PLC_Control)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();
                //Properties.Settings.Default.iAxisCount = pDoc.mAisx_Hard_Date_List.Count;
                //Properties.Settings.Default.Save();
            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new PLC_Control();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/PLC_Control" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PLC_Control));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();

            return true;
        }

    }
    public partial class PLC_ControlData
    {
        /// <summary>
        /// PLC控制资源名称
        /// </summary>
        public string PLC_ControlDataName { get; set; }
        public string PLC_ControlDataTpye { get; set; }
        /// <summary>
        /// PLC品牌
        /// </summary>
        public string PLC_ControlDataVender { get; set; }
        /// <summary>
        /// 连接地址
        /// </summary>
        public string PLC_ControlAddress { get; set; }
        /// <summary>
        /// 连接端口
        /// </summary>
        public string PLC_ControlProt { get; set; }
        public string PLC_ControlRack { get; set; }
        public string PLC_ControlSlot { get; set; }
        /// <summary>
        /// 读取数据存储List
        /// </summary>
        public List<PLCData> PlcReadData = new List<PLCData>();
        /// <summary>
        /// 读取数据存储字典
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, PLCData> dicPlcReadData = new Dictionary<string, PLCData>();
        /// <summary>
        /// 写入数据存储List
        /// </summary>
        public List<PLCData> PlcWriteData = new List<PLCData>();
        /// <summary>
        /// 写入数据存储字典
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, PLCData> dicWritePlcData = new Dictionary<string, PLCData>();
        public bool State { get; set; }



    }
    /// <summary>
    /// 画图
    /// </summary>
    public partial class Draw_Control
    {
        public List<Draw_ControlData> _PLC_ControlData_List;
        [XmlIgnore]
        public Dictionary<string, Draw_ControlData> _PLC_ControlData_Dictionary;
        public Draw_Control()
        {
            _PLC_ControlData_List = new List<Draw_ControlData>();
            _PLC_ControlData_Dictionary = new Dictionary<string, Draw_ControlData>();
        }
        public static Draw_Control LoadObj()
        {
            Draw_Control pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Draw_Control));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/Draw_Control" + ".xml");
                pDoc = (Draw_Control)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();
                //Properties.Settings.Default.iAxisCount = pDoc.mAisx_Hard_Date_List.Count;
                //Properties.Settings.Default.Save();
            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new Draw_Control();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/Draw_Control" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Draw_Control));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();

            return true;
        }

    }
    public partial class Draw_ControlData
    {
        public string Draw_ControlDataName { get; set; }
        public string Draw_ControlDataTpye { get; set; }
        public string Draw_ControlDataVender { get; set; }

    }
    /// <summary>
    /// 数据
    /// </summary>
    public partial class DateGroup
    {
        public List<Group> _DateGroup_List;
        [XmlIgnore]
        public Dictionary<string, Group> _DateGroup_Dictionary;
        public DateGroup()
        {
            _DateGroup_List = new List<Group>();
            _DateGroup_Dictionary = new Dictionary<string, Group>();
        }
        public static DateGroup LoadObj()
        {
            DateGroup pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DateGroup));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/DateGroup" + ".xml");
                pDoc = (DateGroup)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();
                //Properties.Settings.Default.iAxisCount = pDoc.mAisx_Hard_Date_List.Count;
                //Properties.Settings.Default.Save();
            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new DateGroup();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/DateGroup" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DateGroup));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();

            return true;
        }

    }
    public partial class Group
    {
        public string Group_ControlDataName { get; set; }
        public string Group_ControlDataTpye { get; set; }
        public string Group_ControlDataVender { get; set; }
        public object Date { get; set; }

    }
    # region     //流程数据类

    /// <summary>
    /// 流程数据类
    /// </summary>
    public partial class FlowChar_Control
    {
        public List<_FlowChar_Control_Date> _FlowChar_ControlData_List;
        public static _FlowChar_Control_Date _FlowChar_Control;
        [XmlIgnore]
        public Dictionary<string, _FlowChar_Control_Date> _FlowChar_ControlData_Dictionary;
        public FlowChar_Control()
        {
            _FlowChar_ControlData_List = new List<_FlowChar_Control_Date>();
            _FlowChar_ControlData_Dictionary = new Dictionary<string, _FlowChar_Control_Date>();
        }
        public static FlowChar_Control LoadObj()
        {
            FlowChar_Control pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(FlowChar_Control));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/FlowChar_Control" + ".xml");
                pDoc = (FlowChar_Control)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();
                //Properties.Settings.Default.iAxisCount = pDoc.mAisx_Hard_Date_List.Count;
                //Properties.Settings.Default.Save();
            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new FlowChar_Control();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/FlowChar_Control" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(FlowChar_Control));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();

            //try
            //{
            //    using (FileStream fs = new FileStream(@".//Parameter/FlowChar_Control" + ".xml", FileMode.Create, FileAccess.Write))//保存数据
            //    {
            //        BinaryFormatter bf = new BinaryFormatter();
            //        bf.Serialize(fs, typeof(FlowChar_Control));//序列化所有工具
            //    }
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return false;
            //}
            return true;
        }
        public void insert<T>()
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));

                FileStream fs = new FileStream(@".//Parameter/FlowChar_Control" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);

                xml.Serialize(fs, _FlowChar_Control);

                fs.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">类名</typeparam                                                                      
        /// <param name="t"></param>
        /// <param name="_path">路径</param>
        /// <returns></returns>
        public static  object Deserialize<T>()
        {
            List<object> obj = new List<object>();
            try
            {
                FileStream fs = new FileStream(@".//Parameter/FlowChar_Control" + ".xml", FileMode.Open);

                XmlSerializer xml = new XmlSerializer(typeof(_FlowChar_Control_Date));

                _FlowChar_Control = (_FlowChar_Control_Date)xml.Deserialize(fs);
                fs.Close();
                return _FlowChar_Control;

            }
            catch (Exception error)
            {

                return null;
            }
        }
        public void insert<T>(T t)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));

                FileStream fs = new FileStream(@".//Parameter/FlowChar_Control" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);

                xml.Serialize(fs, _FlowChar_Control);

                fs.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

    }
    public partial class _FlowChar_Control_Date
    {
        /// <summary>
        /// 资源名称
        /// </summary>
        public string FlowChar_ControlDataName { get; set; }
        public string FlowChar_ControlDataTpye { get; set; }

        public string sPath { get; set; }
        /// <summary>
        /// 资源描述
        /// </summary>
        public string RunFlowData_ControlDataDescrptive { get; set; }
        public string 配方是否为默认 { get; set; }
        /// 读取数据存储List
        /// </summary>
        public List<RunFlow> ListFlowData = new List<RunFlow>();

        /// <summary>
        /// 流程读取数据存储字典
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, RunFlow> dicFlowData = new Dictionary<string, RunFlow>();

    }
    public class RunFlow: FlowControlProcess
    {
        ///// 运行集合
        ///// </summary>
        //public List<RunFlowData> _RunFlowData = new List<RunFlowData>();
        public List<RunFlowData> _RunFlowData = new List<RunFlowData>();
        //public List<_OutPut_Puse> _RunFlow = new List<_OutPut_Puse>();
        //public List<_OutPut> __OutPut = new List<_OutPut>();

        public string xmlsPath { get; set; }
        /// <summary>
        ///  运行集合
        /// </summary>
        [XmlIgnore]
        // public Dictionary<string, RunFlowData> _RunFlowDic = new Dictionary<string, RunFlowData>();
        public Dictionary<string, RunFlowData> _RunFlowDic = new Dictionary<string, RunFlowData>();

    }
    /// <summary>
    /// 流程点位数据类
    /// </summary>
    public partial class Point_From_Date
    {

        /// <summary>
        /// 点位信息
        /// </summary>
        public List<Axis_Data> PointList = new List<Axis_Data>();
        /// <summary>
        /// 流程名称
        /// </summary>
        public string TaskNanme { get; set; }

        /// <summary>
        /// 工位
        /// </summary>
        public string Station { get; set; }
        [XmlIgnore]
        public Dictionary<string, Axis_Data> Point_PointPostion_Date_Dictionary = new Dictionary<string, Axis_Data>();
    }
    #region 轴安全位置数据保存类
    public class Axis_Data
    {

        /// <summary>
        /// 轴名称
        /// </summary>
        public string AxisName { get; set; }

        /// <summary>
        /// 轴号
        /// </summary>
        public string AxisNumber { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string mCardNo { get; set; }
        /// <summary>
        /// 轴最大安全坐标
        /// </summary>
        public double Axis_Max_Postion { get; set; }
        /// <summary>
        /// 轴最小安全坐标
        /// </summary>
        public double Axis_Min_Postion { get; set; }
    }
    public class PointPostion
    {
        /// <summary>
        /// 点位名称
        /// </summary>
        public string TaskPointNanme { get; set; }
        /// <summary>
        /// X坐标
        /// </summary>
        public string X_Postion { get; set; }
        /// <summary>
        /// Y坐标
        /// </summary>
        public string Y_Postion { get; set; }
        /// <summary>
        /// Z坐标
        /// </summary>
        public string Z_Postion { get; set; }
        /// <summary>
        /// 曝光
        /// </summary>
        public string Expose { get; set; }

        /// <summary>
        /// 工位
        /// </summary>
        public string Station { get; set; }
    }

    public class FlowControlProcess
    { /// <summary>
      /// 资源名称
      /// </summary>
        public string RunFlowData_ControlDataName { get; set; }
        /// <summary>
        /// 资源类型
        /// </summary>
        public string RunFlowData_ControlDataTpye { get; set; }
        /// <summary>
        /// 资源描述
        /// </summary>
        public string RunFlowData_ControlDataDescrptive { get; set; }
    }
    [Serializable]
    //public class _OutPut_Puse: ImageTool
    //{
    //    public string IO_Name { get; set; }
    //    public int _Delay { get; set; }
    //    public int _Count { get; set; }



    //}
    //[Serializable]
    //public class _OutPut : ImageTool
    //{

    //    public string IO_Name { get; set; }
    //}
    //[Serializable]
    public class RunFlowData
    {          
        /// <summary>     
        /// 配方名  
       /// </summary>
        public string RunFlowData_ControlDataName { get; set; }
        /// <summary>     
        /// 流程名
        /// </summary>
        public string RunFlowData_ControlDataStepName { get; set; }
        /// <summary>
        /// 步骤序号
        /// </summary>
        public int  FlowChar_StepControlNum { get; set; }
        /// <summary>
        /// 步骤名称
        /// </summary>
        public string FlowChar_StepControlName { get; set; }
        /// <summary>
        /// 步骤类型
        /// </summary>
        public string FlowChar_StepControlType { get; set; }

        /// <summary>
        /// 步骤描述
        /// </summary>
        public string RunFlowData_ControlDataDescrptive { get; set; }
        /// <summary>
        /// 步骤时间
        /// </summary>
        public double  FlowChar_StepControlTIME { get; set; }

        /// <summary>
        /// 步骤结果
        /// </summary>
        public string FlowChar_StepControlRel { get; set; }

        /// <summary>
        /// 步骤跳转
        /// </summary>
        public int FlowChar_StepControlLoop { get; set; }
        ////扩展参数
        //public object Pram { get; set; }

    }
    //public class  _Out_Put_Puse
    //{
    //    public int _Delay { get; set; }

    //    public int _Count { get; set; }
    //}


    //public class _OutPut
    //{
    //    public int _Delay { get; set; }

    //}
    #endregion

    #region
    /// <summary>
    /// 点位数据类
    /// </summary>
    public partial class Point_Control
    {
        public List<_Point_Control_Date> _Point_ControlData_List;
        [XmlIgnore]
        public Dictionary<string, _Point_Control_Date> _Point_ControlData_Dictionary;
        public Point_Control()
        {
            _Point_ControlData_List = new List<_Point_Control_Date>();
            _Point_ControlData_Dictionary = new Dictionary<string, _Point_Control_Date>();
        }
        public static Point_Control LoadObj()
        {
            Point_Control pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Point_Control));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/Point_Control" + ".xml");
                pDoc = (Point_Control)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();
                //Properties.Settings.Default.iAxisCount = pDoc.mAisx_Hard_Date_List.Count;
                //Properties.Settings.Default.Save();
            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new Point_Control();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/Point_Control" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Point_Control));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();

            return true;
        }

    }
    public partial class _Point_Control_Date
    {
        //public List<AixsData> Data = new List<AixsData>();
        /// <summary>
        /// Point控制资源名称
        /// </summary>
        public string Point_ControlDataName { get; set; }
        public string Point_ControlDataTpye { get; set; }
        public string Point_ControlDataVender { get; set; }

        /// 读取数据存储List
        /// </summary>
        public List<PointData> _PointData = new List<PointData>();


    }
    public class PointData
    {
        //点位名字
        public string 点位名字 { get; set; }
        //public string AisxName { get; set; }
        //public string CardAisxNum { get; set; }
        //public string AisxNum { get; set; }
        public string DataStr { get; set; }

        /// 存储轴
        /// </summary>
        public List<string> __AisxNametData = new List<string>();
    }
    #endregion

}
#endregion