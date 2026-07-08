using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TReturn = System.Int16;
namespace UniversalControlSystem
{
    public enum CoordinateType
    {
        XY,
        XZ,
        YZ,
        XYZ,
        XYZU,
        X1Y1,
        X1Z1,
        Y1Z1,
        X1Y1Z1,
        X1Y1Z1U1
    }
    public interface ContraInterface
    {
        //初始化
        bool Init(CardDate_Save hardDoc);
        //获取原点状态
        bool Get_Org_Sta(int m_AxisNo, int lGpiValueHome);
        //IO输出
        int SetOutBit(string _IO_Name, bool bOn);
        bool GetInOn(string _IO_Name);
        bool GetOutOn(string _IO_Name);
        /// <summary>
        /// 单轴相对运动
        /// </summary>
        /// <param name="Aisx_Name">轴名称</param>
        /// <param name="postion">相对运动位置</param>
        /// <returns></returns>
        int AxisPrfTrapRel(string Aisx_Name, double postion);
        /// <summary>
        /// Jog模试运动  
        /// </summary>
        /// <param name="Aisx_Name">轴名</param>
        /// <param name="bAir">方向</param>
        /// <returns></returns>
        int AxisPrfJogHome(string Aisx_Name, bool bAir);
        /// <summary>
        /// Jog模试运动  
        /// </summary>
        /// <param name="Aisx_Name">轴名</param>
        /// <param name="bAir">方向</param>
        /// <returns></returns>
        int AxisPrfJog(string Aisx_Name, bool bAir);
        /// <summary>
        /// 单多轴运动
        /// </summary>
        /// <param name="CardDateDictionary"> 自定义流程控制数据</param>
        /// <returns></returns>
        int AxisPMoveAbsoluteToStop(Moves moves);
        /// <summary>
        /// 轴停止运行
        /// </summary>
        /// <param name="Aisx_Name"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        TReturn StopAxis(string Aisx_Name, int option = 0);
        /// <summary>
        /// 单多轴回原点
        /// </summary>
        /// <param name="CardDateDictionary"> 自定义流程控制数据</param>
        /// <returns></returns>
        int Go_home(string[] Asix_Name);
        /// <summary>
        /// 绝对定位
        /// </summary>
        /// <param name="Aisx_Name">轴的硬件配置名   </param>
        /// <param name="postion">轴运动的位置</param>
        /// <param name="Speed">轴运动的速度</param>
        /// <param name="TimeOut">轴运动的超时时间</param>
        /// <returns></returns>
        int AxisPMoveAbsoluteToStop(string Aisx_Name, double postion, double Speed, double Acc, double Dec, double TimeOut = 10000);
        /// <summary>
        /// 等待轴运行停止 
        /// </summary>
        /// <param name="car">卡号</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        int DetectingAxis(string Aisx_Name);

        /// <summary>
        /// 等待轴运行停止 
        /// </summary>
        /// <param name="car">卡号</param>
        /// <param name="axis">轴号</param>
        /// <returns></returns>
        double  GETAxisP(string Aisx_Name);
        /// <summary>
        /// 绝对定位
        /// </summary>
        /// <param name="Aisx_Name">轴的硬件配置名   </param>
        /// <param name="postion">轴运动的位置</param>
        /// <param name="Speed">轴运动的速度</param>
        /// <param name="TimeOut">轴运动的超时时间</param>
        /// <returns></returns>
        TReturn AxisPrfTrap(short card, short axis, double postion, double vel, double acc, double dec);
        /// <summary>
        /// 建立坐标系及插入圆弧数据
        /// </summary>
        /// <param name="Axis_One_Name">轴1名称</param>
        /// <param name="Axis_Two_Name">轴2名称</param>
        /// <param name="dAcc">加速度</param>
        /// <param name="dDec">减速度</param>
        /// <param name="dSpeed">速度</param>
        /// <param name="endSpeed">终点速度</param>
        /// <param name="posX">终点坐标：X</param>
        /// <param name="posY">终点坐标Y</param>
        /// <param name="centerX">相对于起点的坐标的偏移量X</param>
        /// <param name="centerY">相对于起点的坐标的偏移量Y</param>
        /// <param name="iCCW">方向：0顺时针，1逆时针</param>/
        /// ///
        /// <returns></returns>
        int BuildCor_InsertArc(string Axis_One_Name, string Axis_Two_Name, double dAcc, double dDec, double dSpeed, double endSpeed, double posX, double posY, double centerX, double centerY, short iCCW,CoordinateType coordinateType);
        /// <summary>
        /// XY圆弧插补运动
        /// </summary>
        /// <param name="Axis_One_Name"></param>
        /// <param name="Axis_Two_Name"></param>
        /// <param name="dAcc"></param>
        /// <param name="dDec"></param>
        /// <param name="dSpeed"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="dR"></param>
        /// <param name="iCCW"></param>
        /// <returns></returns>
        int ArcXYMove(string Axis_One_Name, string Axis_Two_Name, double dAcc, double dDec, double dSpeed, double endSpeed, double posX, double posY, double dR, double CenterX, double CenterY, short iCCW);
        /// <summary>
        /// 插补运行完成
        /// </summary>
        /// <param name="Axis_Name"></param>
        /// <param name="iStep"></param>
        /// <returns></returns>
        int CureMoveDone(out int iStep);
        /// <summary>
        /// 向缓存区增加数据——圆 
        /// </summary>
        /// <param name="Axis_Name"></param>
        /// <param name="dPosX"></param>
        /// <param name="dPosY"></param>
        /// <param name="dR"></param>
        /// <param name="dSpeed"></param>
        /// <param name="iCCW"></param>
        /// <param name="dAcc"></param>
        /// <param name="dEndSpeed"></param>
        /// <returns></returns>
        int InsertArc(string Axis_One_Name, string Axis_Two_Name, double dPosX, double dPosY, double CenterX, double CenterY, double dSpeed, short iCCW, double dAcc, double dEndSpeed);
        int InsertArc(ArcXYC _ArcXYC);
       
        /// <summary>
        /// 插补开始运行
        /// </summary>
        /// <param name="num"></param>
        /// <param name="bPreWelding"></param>
        /// <returns></returns>
        int StartCure(short CardNum, short BuildCor);
        /// <summary>
        /// 插补开始运行及检测停止
        /// </summary>
        /// <param name="Axis_One_Name"></param>
        /// <param name="Axis_Two_Name"></param>
        int StartCureToStop();
        /// <summary>
        /// 建立坐标系及插入直线数据
        /// </summary>
        /// <param name="Axis_One_Name"></param>
        /// <param name="Axis_Two_Name"></param>
        /// <param name="dAcc"></param>
        /// <param name="dDec"></param>
        /// <param name="dSpeed"></param>
        /// <param name="EndSpeed"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="coordinateType"></param>
        int BuildCor_InsertLine(Dictionary<string, double> Axis_Name, double dAcc, double dDec, double dSpeed, double EndSpeed);
        /// <summary>
        /// 直线插补
        /// </summary>
        /// <param name="Axis_One_Name"> 1#轴名称</param>
        /// <param name="Axis_Two_Name"> 2#轴名称</param>
        /// <param name="dAcc">  轴加速度 </param>
        /// <param name="dDec">轴减速度</param>
        /// <param name="dSpeed">速度</param>
        /// <param name="posX">1#轴位置</param>
        /// <param name="posY">2#轴位置</param>
        int LineXYMove(Dictionary<string, double> Axis_Name, double dAcc, double dDec, double dSpeed, double EndSpeed);
        /// <summary>
        /// 向缓存区存入直线插补数据
        /// </summary>
        /// <param name="Axis_Name"></param>
        /// <param name="dPosX"></param>
        /// <param name="dPosY"></param>
        /// <param name="dSpeed"></param>
        /// <param name="dAcc"></param>
        /// <param name="dEndSpeed"></param>
        /// <returns></returns>
        int InsertLine(Dictionary<string, double> Axis_Name, double dSpeed, double dAcc, double dEndSpeed);
        int InsertLine(LnXY _LnXY);
        
        int InsertLineLnXYZ(LnXYZ _LnXYZ);
        int InsertLineLnXYZA(LnXYZA _LnXYZA);
        int BuildCor(BufferArea _BufferArea);

        int ClearBuff(BufferArea _BufferArea);

        int BuffAddStart(BufferArea _BufferArea);
        int BuffRun(BufferArea _BufferArea);

        int AddOtherBuffFun(AddOtherBuff _AddOtherBuff);
        /// <summary>
        /// 建立坐标系
        /// </summary>
        /// <param name="num"></param>
        /// <param name="coordinateType"></param>
        /// <returns></returns>
        int BuildCor(Dictionary<string, double> Axis_Name);
        /// <summary>
        /// 建立坐标系用于插入数据不运行
        /// </summary>
        /// <param name="num"></param>
        /// <param name="coordinateType"></param>
        /// <returns></returns>
        int BuildCor3D(Dictionary<string, double> Axis_Name);
        /// <summary>
        /// 向缓存区存入直线插补数据
        /// </summary>
        /// <param name="Axis_Name"></param>
        /// <param name="dPosX"></param>
        /// <param name="dPosY"></param>
        /// <param name="dSpeed"></param>
        /// <param name="dAcc"></param>
        /// <param name="dEndSpeed"></param>
        /// <returns></returns>
        int InsertLine3D(Dictionary<string, double> Axis_Name, double dSpeed, double dAcc, double dEndSpeed);
        /////////////////////////////////回原点//////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Asix_Name"></param>
        void GO_Home(string Asix_Name);
        //回原点线程
        void Home_Start(object _Asix_name);

        bool StartManualPulserOperation(int axis_ID, int MultiplyingPower);

         bool StopManualPulserOperation(int axis_ID);
        //圆弧或圆
         bool   CirRun(Cir Cir);
        /// <summary>
        /// 正方形
        /// </summary>
        /// <param name="Dimetric"></param>
        /// <returns></returns>
        bool MoveRec(Dimetric Dimetric);
    }
}
