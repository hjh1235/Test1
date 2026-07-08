using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniversalControlSystem
{
    public enum ProcessCode
    {
        Moves,
        MoveL,
        MoveC,
        IOOutput,
        IOINput,
        Rang,
        Delay,
        RangeCorrection,
        CCD,
        CCDPositioning,
        Laser,
        BufferControl,
        ResourceControl,
        GoHome,
        Mes,
        PLCControl,
        StationDelay,
        MoveRectangle,
        OutGlue,
        CloseGlue,
        dateCtron,
        Get_dataCtron,
        CHCEK_IO_P,
        CHCEK_IO_L,
        JOGMOVE,
        Get_CW_CCWIO
    }
    public interface countdown
    {
        /// <summary>
        /// 流程名称
        /// </summary>
        string ProcessName { get; set; }
    }
    /// <summary>
    /// 流程类
    /// </summary>
    public class ControlProcess
    {
        public List<object> listPro = new List<object>();
        public List<Moves> listMoves = new List<Moves>();
        public List<MoveL> listMoveL = new List<MoveL>();
        public List<MoveC> listMovec = new List<MoveC>();
        public List<IOOutput> listIOOutput = new List<IOOutput>();
        public List<IOINput> listIOINput = new List<IOINput>();
        public List<Rang> listRanging = new List<Rang>();
        public List<Delay> listDelay = new List<Delay>();
        public List<RangeCorrection> listRangeCorrection = new List<RangeCorrection>();
        public List<CCDPositioning> listCCDPositioning = new List<CCDPositioning>();
        public List<Laser> listLaser = new List<Laser>();
        public List<BufferControl> buffercontrol = new List<BufferControl>();
        public List<ResourceControl> resourcecontrol = new List<ResourceControl>();
        public List<GoHome> gohome = new List<GoHome>();
        public List<Mes> mes = new List<Mes>();
        public List<CCD> ccd = new List<CCD>();
        public List<PLCControl> PLCControl = new List<PLCControl>();
        public List<MoveRectangle> MoveRectangle = new List<MoveRectangle>();
        public List<CloseGlue> closeGlue = new List<CloseGlue>();
        public List<OutGlue> OutGlue = new List<OutGlue>();
        public List<dateCtron> dateCtron = new List<dateCtron>();
        public List<Get_dataCtron> Get_dataCtron = new List<Get_dataCtron>();

        public List<Get_CW_CCWIO> Get_CW_CCWIO = new List<Get_CW_CCWIO>();
        public List<JOGMOVE> JOGMOVE = new List<JOGMOVE>();
        public List<CHCEK_IO_P> CHCEK_IO_P = new List<CHCEK_IO_P>();
        public List<CHCEK_IO_L> CHCEK_IO_L = new List<CHCEK_IO_L>();
        //public List<Get_dataCtron> Get_dataCtron = new List<Get_dataCtron>();
    }
    public class Moves:countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 轴参数集合
        /// </summary>
        public List<mAxis> ListAxis = new List<mAxis>();

    }
    public class MoveL : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 插补合成速度
        /// </summary>
        public double AxisSpeed { get; set; }
        /// <summary>
        /// 插补终点速度
        /// </summary>
        public double AxisEndSpeed { get; set; }
        /// <summary>
        /// 插补加速度
        /// </summary>
        public double AxisAcc { get; set; }
        /// <summary>
        /// 插补减速度
        /// </summary>
        public double AxisDec { get; set; }
        /// <summary>
        /// 是否进行测距补偿
        /// </summary>
        public bool RangingECC { get; set; }
        /// <summary>
        /// 轴参数集合
        /// </summary>
        public List<Axis> ListAxis = new List<Axis>();
        /// <summary>
        /// 轴参数
        /// </summary>
        public Axis axis = new Axis();

    }
    public class MoveC : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 圆弧插补状态：轨迹是圆还是圆弧
        /// </summary>
        public bool MoveCStatus { get; set; }
        /// <summary>
        /// 插补速度
        /// </summary>
        public double AxisSpeed { get; set; }
        /// <summary>
        /// 插补终点速度
        /// </summary>
        public double AxisEndSpeed { get; set; }
        /// <summary>
        /// 插补加速度
        /// </summary>
        public double AxisAcc { get; set; }
        /// <summary>
        /// 插补减速度
        /// </summary>
        public double AxisDec { get; set; }
        /// <summary>
        /// 方向
        /// </summary>
        public int Dir { get; set; }
        /// <summary>
        /// 角度
        /// </summary>
        public int Angle { get; set; }
        /// <summary>
        /// 半径
        /// </summary>
        public double R { get; set; }
        /// <summary>
        /// 轴名称集合
        /// </summary>
        public List<string> AxisName = new List<string>();
        /// <summary>
        /// 起点位置
        /// </summary>
        public PorcessPoint StartPoint = new PorcessPoint();
        /// <summary>
        /// 中间点位置
        /// </summary>
        public PorcessPoint MidPoint = new PorcessPoint();
        /// <summary>
        /// 终点位置
        /// </summary>
        public PorcessPoint EndPoint = new PorcessPoint();
        /// <summary>
        /// 圆/弧心位置
        /// </summary>
        public PorcessPoint CenterOffer = new PorcessPoint();
        
    }
    public class IOOutput : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// IO状态：True/False
        /// </summary>
        public bool IoStatus { get; set; }
        /// <summary>
        /// IO输出方式：电平/脉冲
        /// </summary>
        public bool IoOutWay { get; set; }
        /// <summary>
        /// IO名称
        /// </summary>
        public string IoName { get; set; }
        /// <summary>
        /// 脉冲输出时间
        /// </summary>
        public string IoTime { get; set; }
    }
    public class IOINput : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// IO状态：True/False
        /// </summary>
        public bool IoStatus { get; set; }
        /// <summary>
        /// IO名称
        /// </summary>
        public string IoName { get; set; }
        /// <summary>
        /// IO输入扫描时间
        /// </summary>
        public string IoTime { get; set; }
    }
    public class Rang : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 测距资源名称
        /// </summary>
        public string ResourcessName { get; set; }
        /// <summary>
        /// 延时时间
        /// </summary>
        public int DelayTime { get; set; }
        /// <summary>
        /// /资源名称
        /// </summary>
        public string  name { get; set; }

    }
    public class Delay : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 延时时间
        /// </summary>
        public int Time { get; set; }
    }
    public class RangeCorrection : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 测距补偿轴参数
        /// </summary>
        public mAxis Axis = new mAxis();
    }
    public class CCD : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 相机曝光
        /// </summary>
        public int Exposure { get; set; }
        /// <summary>
        /// 延时时间
        /// </summary>
        public int DelayTime { get; set; }
        /// <summary>
        /// 条码位置
        /// </summary>
        public string SNPosition { get; set; }
        /// <summary>
        /// 轴参数
        /// </summary>
        public List<Axis> axis = new List<Axis>();
    }
    public class CCDPositioning : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 定位方式：点/圆/矩形
        /// </summary>
        public string PositioningWay { get; set; }
        /// <summary>
        /// CCD资源名称
        /// </summary>
        public string ResourcessName { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// 运动速度
        /// </summary>
        public double AxisSpeed { get; set; }
        /// <summary>
        /// 终点速度
        /// </summary>
        public double AxisEndSpeed { get; set; }
        /// <summary>
        /// 加速度
        /// </summary>
        public double AxisAcc { get; set; }
        /// <summary>
        /// 减速度
        /// </summary>
        public double AxisDec { get; set; }
        /// <summary>
        /// 是否测距
        /// </summary>
        public bool Ranging { get; set; }
        /// <summary>
        /// 圆半径
        /// </summary>
        public double dicR { get; set; }
        /// <summary>
        /// 角度
        /// </summary>
        public int Angle { get; set; }
        /// <summary>
        /// 激光资源
        /// </summary>
        public string LaserResources { get; set; }
        /// <summary>
        /// 激光控制方式：模拟量/IO
        /// </summary>
        public bool LaserContorl { get; set; }
        /// <summary>
        /// IO控制激光模式号
        /// </summary>
        public int LaserNumber { get; set; }
        /// <summary>
        /// 轴参数
        /// </summary>
        public List<Axis> ListAxis = new List<Axis>();
    }
    public class Laser : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 激光资源名称
        /// </summary>
        public string LaserResources { get; set; }
        /// <summary>
        /// 激光控制方式：模拟量/IO
        /// </summary>
        public bool LaserContorl { get; set; }
        /// <summary>
        /// IO控制激光模式号
        /// </summary>
        public int LaserNumber { get; set; }
    }
    public class BufferControl : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 缓冲区状态：添加/启动
        /// </summary>
        public bool BufferStatus { get; set; }
    }
    public class ResourceControl : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 资源名称
        /// </summary>
        public string ResourceNmae { get; set; }
        /// <summary>
        /// 保存位置
        /// </summary>
        public string SavePos { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }
    }
    public class GoHome : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 轴参数集合
        /// </summary>
        public List<string> Axis = new List<string>();
    }
    public class PLCControl : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 资源名称
        /// </summary>
        public string ResourceName { get; set; }
        public string dataNmae { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 控制方式：写入/读取
        /// </summary>
        public bool ControlWay { get; set; }
    }
    public class Mes : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// mes状态：校验/上传
        /// </summary>
        public bool MesStatus { get; set; }
        public List<string> MesResource = new List<string>();
    }
    public class MoveRectangle
    {
        public string ProcessName { get; set; }
        public double AxisSpeed { get; set; }
        public double AxisAcc { get; set; }
        public double AxisDec { get; set; }
        public double AxisEndSpeed { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double R { get; set; }
        public List<Axis> Axis = new List<Axis>();
    }
    public class CloseGlue
    {
        public string ProcessName { get; set; }
        public int OutGlueTime { get; set; }
        public int DelayOutGlueTime { get; set; }

        public string ResourceName { get; set; }
        public string OutGlueNmae { get; set; }
        public string OutGlueOK { get; set; }
        public bool DetectionOfGlue { get; set; }

        public List<Axis> Axis = new List<Axis>();

    }

    public class OutGlue
    {
        public string ProcessName { get; set; }     
        public int DelayOutGlueTime { get; set; }
         public   bool   BigonOutGlue { get; set; }
    }
    public class mAxis
    {
        public string AxisName { get; set; }
        public double AxisPosition { get; set; }
        public double AxisSpeed { get; set; }
        public double AxisAcc { get; set; }
        public double AxisDec { get; set; }
        public double AxisEndSpeed { get; set; }
    }
    public class Axis
    {
        public string AxisName { get; set; }
        public double AxisPosition { get; set; }
    }
    public class PorcessPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    /// <summary>
    /// 数据组数据存储
    /// </summary>
    public class dateCtron : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 资源名称
        /// </summary>
        public string ResourceName { get; set; }

        ///  数据类型
        public string dateType { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object Date { get; set; }

        /// <summary>
        /// 数据名称
        /// </summary>

        public string Date_Name { get; set; }


    }
    /// <summary>
    /// 数据组数据存储
    /// </summary>
    public class Get_dataCtron : countdown
    {
        public string ProcessName { get; set; }
        /// <summary>
        /// 资源名称
        /// </summary>
        public string ResourceName { get; set; }

        ///  数据类型
        public string dateType { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public object Data{ get; set; }

        /// <summary>
        /// 数据名称
        /// </summary>

        public string Date_Name { get; set; }

        /// <summary>
        /// 检测数据
        /// </summary>
        public string CheckDate { get; set; }


    }
    /// <summary>
    /// 限位检测
    /// </summary>
    public class Get_CW_CCWIO : countdown
    {
        public string ProcessName { get; set; }
        ///// <summary>
        ///// 资源名称
        ///// </summary>
        //public string ResourceName { get; set; }

        ///  轴名称
        public string Aisxdate { get; set; }
        /// <summary>
        /// 检测限位
        /// </summary>
        public object Cw_ccw_or { get; set; }

        /// <summary>
        /// 检测方向
        /// </summary>
        public string Dir { get; set; }
    }
    /// <summary>
    /// JOG运动
    /// </summary>
    public class JOGMOVE : countdown
    {
        public string ProcessName { get; set; }
        ///// <summary>
        ///// 资源名称
        ///// </summary>
        //public string ResourceName { get; set; }

        ///  轴名称
        public string Aisxdate { get; set; }


        /// <summary>
        /// 检测方向
        /// </summary>
        public string Dir { get; set; }
    }
    /// <summary>
    /// 上升沿检测
    /// </summary>
    public class CHCEK_IO_P : countdown
    {
        public string ProcessName { get; set; }
        ///// <summary>
        ///// 资源名称
        ///// </summary>
        //public string ResourceName { get; set; }
        /// <summary>
        /// IO状态：True/False
        /// </summary>
        public bool IoStatus { get; set; }
        /// <summary>
        /// IO名称
        /// </summary>
        public string IoName { get; set; }
        /// <summary>
        /// IO输入扫描时间
        /// </summary>
        public string IoTime { get; set; }
    }
    /// <summary>
    /// 下降沿检测
    /// </summary>
    public class CHCEK_IO_L : countdown
    {
        public string ProcessName { get; set; }
        ///// <summary>
        ///// 资源名称
        ///// </summary>
        //public string ResourceName { get; set; }
        /// <summary>
        /// IO状态：True/False
        /// </summary>
        public bool IoStatus { get; set; }
        /// <summary>
        /// IO名称
        /// </summary>
        public string IoName { get; set; }
        /// <summary>
        /// IO输入扫描时间
        /// </summary>
        public string IoTime { get; set; }
    }
}
