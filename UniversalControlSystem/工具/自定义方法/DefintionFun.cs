using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public delegate void GetHightDelegate();
    public delegate void CCDDelegate();
    [Serializable]
    public class DefintionFun : ImageTool, AixsCtronInterface
    {
        public string FunName { get; set; }
        int leftIndex = 1;//左位置
        public bool bIsOK = false;//激光器状态
        int returnz = -1;
        int rightIndex = 1;//右位置
        public event GetHightDelegate m_UpdateViewLeftGetHight;
        public event GetHightDelegate m_UpdateViewRightGetHight;
        #region//左右两个工位的测高类
        DigitalMea_Height dhRight1 = new DigitalMea_Height();
        DigitalMea_Height dhRight2 = new DigitalMea_Height();
        DigitalMea_Height dhLeft1 = new DigitalMea_Height();
        DigitalMea_Height dhLeft2 = new DigitalMea_Height();
        DefintionFun3 defintionFun3 = new DefintionFun3();//测高自定义方法
        public static ManualResetEvent ResetEvent1 = new ManualResetEvent(false);//阻塞右清洗线程
        
        
        #endregion
        public int RunFun(DefintionFun _DefintionFun)
        {
            string AxisXNameRight = "右X主轴", AxisYNameRight = "右Y轴", AxisZNameRight = "右Z轴";
            string AxisXNameLeft = "左X主轴", AxisYNameLeft = "左Y轴", AxisZNameLeft = "左Z轴";
            double rightWeldDisX = DataManage.DoubleValue("右偏距", "右偏距振镜X");
            double rightWeldDisY = DataManage.DoubleValue("右偏距", "右偏距振镜Y");
            double rightHighDisX = DataManage.DoubleValue("右偏距", "右偏距测距X");
            double rightHighDisY = DataManage.DoubleValue("右偏距", "右偏距测距Y");
            double leftWeldDisX = DataManage.DoubleValue("左偏距", "左偏距振镜X");
            double leftWeldDisY = DataManage.DoubleValue("左偏距", "左偏距振镜Y");
            double leftHighDisX = DataManage.DoubleValue("左偏距", "左偏距测距X");
            double leftHighDisY = DataManage.DoubleValue("左偏距", "左偏距测距Y");

            #region//左测高
            dhRight1.串口号 = DataManage.StrValue("左测高", "左测高COM1");
            dhRight1.正偏差 = Convert.ToDouble(DataManage.StrValue("左测高", "正偏差"));
            dhRight1.负偏差 = Convert.ToDouble(DataManage.StrValue("左测高", "负偏差"));
            dhRight1.离焦量 = Convert.ToDouble(DataManage.StrValue("左测高", "离焦量"));
            dhRight2.串口号 = DataManage.StrValue("左测高", "左测高COM2");
            dhRight2.正偏差 = Convert.ToDouble(DataManage.StrValue("左测高", "正偏差"));
            dhRight2.负偏差 = Convert.ToDouble(DataManage.StrValue("左测高", "负偏差"));
            dhRight2.离焦量 = Convert.ToDouble(DataManage.StrValue("左测高", "离焦量"));
            #endregion
            #region//右测高
            dhLeft1.串口号 = DataManage.StrValue("右测高", "右测高COM1");
            dhLeft1.正偏差 = Convert.ToDouble(DataManage.StrValue("右测高", "正偏差"));
            dhLeft1.负偏差 = Convert.ToDouble(DataManage.StrValue("右测高", "负偏差"));
            dhLeft1.离焦量 = Convert.ToDouble(DataManage.StrValue("右测高", "离焦量"));
            dhLeft2.串口号 = DataManage.StrValue("右测高", "右测高COM2");
            dhLeft2.正偏差 = Convert.ToDouble(DataManage.StrValue("右测高", "正偏差"));
            dhLeft2.负偏差 = Convert.ToDouble(DataManage.StrValue("右测高", "负偏差"));
            dhLeft2.离焦量 = Convert.ToDouble(DataManage.StrValue("右测高", "离焦量"));
            double leftWeldHigh = DataManage.DoubleValue("清洗", "左清洗高度");
            double rightWeldHigh = DataManage.DoubleValue("清洗", "右清洗高度");
            double highData = 0;
            bool inplace = false;
            int returnLeft = 0;
            int returnRight = 0;//右返回值

            #endregion
            switch (_DefintionFun.FunName)
            {
                case "数据统计":
                    Program.运行时间 = Program.CTWatch.Elapsed.Minutes.ToString() + "Min" + Program.CTWatch.Elapsed.Seconds.ToString() + "S";
                    Properties.Settings.Default.OKTotal++;
                    Properties.Settings.Default.Save();
                    break;
                case "计时开始":
                    //Program.CTWatch.Reset();
                    //Program.CTWatch.Start();
                    //FormStart.leftTimer.Start();
                    break;
                case "左清洗右":
                    //遍历左清洗点位左半边
                    for (int b=Program.CurrentPoint_L; b < PointSetting_Form.leftPointDicWeldRight.Count; b++)
                    {
                        leftIndex = b + 1;
                        Dictionary<string, string> item = PointSetting_Form.leftPointDicWeldRight.ElementAt(b).Value;

                        //停止
                        #region
                        while (true)
                        {
                            Thread.Sleep(10);
                            if (!Program.bStop && Program.bAuto)//没有停止继续运行
                                break;
                            if (Program.bInt)//初始化
                            {
                                return 0;
                            }
                            if (Program.bEStop)//急停
                            {
                                return 0;
                            }
                        }
                        #endregion
                        Program.colunmIndexLeft = Convert.ToInt32(item["列数"]);
                        Program.CurrentPoint_L= Convert.ToInt32(item["点位"]);
                        if (Program.CurrentPoint_L > 9 && Program.CurrentPoint_L <17)
                        {
                            ResetEvent1.Set();//发送信号解锁
                            ResetEvent1.Reset();//复位信号
                        }
                        if (Program.CurrentPoint_L > 19)
                        {
                            ResetEvent1.Set();//发送信号解锁
                            ResetEvent1.Reset();//复位信号
                        }
                        try
                        {
                            //运动第一个点位
                            ManageContral.AxisPMoveAbsoluteToStop(AxisXNameLeft, Convert.ToDouble(item["X"]) + leftHighDisX);
                            inplace = asixStopJudge(AxisXNameLeft, Convert.ToDouble(item["X"]) + leftHighDisX);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisYNameLeft, Convert.ToDouble(item["Y"]) + leftHighDisY);
                            inplace = asixStopJudge(AxisYNameLeft, Convert.ToDouble(item["Y"]) + leftHighDisY);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisZNameLeft, leftWeldHigh);
                            inplace = asixStopJudge(AxisZNameLeft, leftWeldHigh);
                            if (inplace == false)
                                return -1;
                            returnz = defintionFun3.getHigh(item, dhRight1, dhRight2, leftIndex, ref highData);//测高,保存校正数据
                            if (returnz != 0)
                                return -1;
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"左清洗右测高结束测高值为:{highData}");
                            //运行到清洗位
                            ManageContral.AxisPMoveAbsoluteToStop(AxisXNameLeft, Convert.ToDouble(item["X"]) + leftWeldDisX);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisYNameLeft, Convert.ToDouble(item["Y"]) + leftWeldDisY);
                            if (asixStopJudge(AxisXNameLeft, Convert.ToDouble(item["X"]) + leftWeldDisX) == false)
                                return -1;
                            if (asixStopJudge(AxisYNameLeft, Convert.ToDouble(item["Y"]) + leftWeldDisY) == false)
                                return -1;
                            ManageContral.AxisPMoveAbsoluteToStop(AxisZNameLeft, leftWeldHigh - highData);
                            if (asixStopJudge(AxisZNameLeft, leftWeldHigh - highData) == false)
                                return -1;
                            //出光
                            if (weldByDllLeft(item) == false)
                                return -1;
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"左清洗右:{leftIndex},第{ Program.colunmIndexLeft}列，完成");
                            //Program.CurrentPoint_L++;
                        }       
                        catch (Exception ex)
                        {
                            Weld_Log.Instance().Enqueue(ex.ToString());
                            return -1;
                        }
                    }
                    Program.colunmIndexLeft = 1;
                    Program.CurrentPoint_L = 0;
                    return 0;
                case "左清洗右1":
                    //遍历左清洗点位左半边

                case "左清洗左":
                    //遍历左清洗点位左半边
                    for (int b=Program.CurrentPoint_L; b < PointSetting_Form.leftPointDicWeldleft.Count; b++)
                    {
                        leftIndex = b + 1;
                        Dictionary<string, string> item = PointSetting_Form.leftPointDicWeldleft.ElementAt(b).Value;
                        //停止
                        #region
                        while (true)
                        {
                            Thread.Sleep(10);
                            if (!Program.bStop && Program.bAuto)//没有停止继续运行
                                break;
                            if (Program.bInt)//初始化
                            {
                                return 0;
                            }
                            if (Program.bEStop)//急停
                            {
                                return 0;
                            }
                        }
                        #endregion
                        Program.colunmIndexLeft = Convert.ToInt32(item["列数"]);
                        Program.CurrentPoint_L = Convert.ToInt32(item["点位"]);
                        try
                        {
                            //运动测高点位
                            ManageContral.AxisPMoveAbsoluteToStop(AxisXNameLeft, Convert.ToDouble(item["X"]) + leftHighDisX);
                            inplace = asixStopJudge(AxisXNameLeft, Convert.ToDouble(item["X"]) + leftHighDisX);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisYNameLeft, Convert.ToDouble(item["Y"]) + leftHighDisY);
                            inplace = asixStopJudge(AxisYNameLeft, Convert.ToDouble(item["Y"]) + leftHighDisY);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisZNameLeft, leftWeldHigh);
                            inplace = asixStopJudge(AxisZNameLeft, leftWeldHigh);
                            if (inplace == false)
                                return -1;
                            returnz = defintionFun3.getHigh(item, dhRight1, dhRight2, leftIndex, ref highData);//测高,保存校正数据
                            if (returnz != 0)
                                return -1;
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"左清洗左测高结束测高值为:{highData}");
                            //运行到清洗位
                            while (true)
                            {
                                Thread.Sleep(10);
                                if (Program.bInt)//初始化
                                {
                                    return 0;
                                }
                                if (Program.bEStop)//急停
                                {
                                    return 0;
                                }
                                if (Program.colunmIndexLeft <= Program.colunmIndexRight||(bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["右清洗右标志"].Date==false)//没有停止继续运行
                                    break;
                            }
                            //停止
                            ManageContral.AxisPMoveAbsoluteToStop(AxisXNameLeft, Convert.ToDouble(item["X"]) + leftWeldDisX);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisYNameLeft, Convert.ToDouble(item["Y"]) + leftWeldDisY);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisZNameLeft, leftWeldHigh - highData);
                            inplace = asixStopJudge(AxisXNameLeft, Convert.ToDouble(item["X"]) + leftWeldDisX);
                            inplace = asixStopJudge(AxisYNameLeft, Convert.ToDouble(item["Y"]) + leftWeldDisY);
                            inplace = asixStopJudge(AxisZNameLeft, leftWeldHigh - highData);
                            if (inplace == false)
                                return -1;
                            //出光
                            if (weldByDllLeft(item) == false)
                                return -1;
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"左清洗左:{leftIndex},第{ Program.colunmIndexLeft}列，完成");
                            //Program.CurrentPoint_L++;
                        }
                        catch (Exception ex)
                        {
                            Weld_Log.Instance().Enqueue(ex.ToString());
                            return -1;
                        }
                    }
                    Program.colunmIndexLeft = 1;
                    Program.CurrentPoint_L = 0;
                    return 0;
                case "右清洗右":

                    //遍历右清洗点位左半边
                    for (int b=Program.CurrentPoint_R; b < PointSetting_Form.rightPointDicWeldRight.Count; b++)
                    {
                        rightIndex = b + 1;
                        Dictionary<string, string> item = PointSetting_Form.rightPointDicWeldRight.ElementAt(b).Value;
                        //停止
                        #region
                        while (true)
                        {
                            Thread.Sleep(10);
                            if (!Program.bStop && Program.bAuto)//没有停止继续运行
                                break;
                            if (Program.bInt)//初始化
                            {
                                return 0;
                            }
                            if (Program.bEStop)//急停
                            {
                                return 0;
                            }
                        }
                        #endregion
                        Program.colunmIndexRight = Convert.ToInt32(item["列数"]);//记录列数
                        Program.CurrentPoint_R = Convert.ToInt32(item["点位"]);
                        try
                        {
                            //运动测高点位
                            ManageContral.AxisPMoveAbsoluteToStop(AxisXNameRight, Convert.ToDouble(item["X"]) + rightHighDisX);
                            inplace = asixStopJudge(AxisXNameRight, Convert.ToDouble(item["X"]) + rightHighDisX);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisYNameRight, Convert.ToDouble(item["Y"]) + rightHighDisY);
                            inplace = asixStopJudge(AxisYNameRight, Convert.ToDouble(item["Y"]) + rightHighDisY);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisZNameRight, rightWeldHigh);
                            inplace = asixStopJudge(AxisZNameRight, rightWeldHigh);
                            if (inplace == false)
                                return -1;
                            returnz = defintionFun3.getHigh(item, dhLeft1, dhLeft2, rightIndex, ref highData);//测高,保存校正数据
                            if (returnz != 0)
                                return -1;
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"右清洗右测高结束测高值为:{highData}");
                            //运行到清洗位
                            ManageContral.AxisPMoveAbsoluteToStop(AxisXNameRight, Convert.ToDouble(item["X"]) + rightWeldDisX);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisYNameRight, Convert.ToDouble(item["Y"]) + rightWeldDisY);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisZNameRight, rightWeldHigh - highData);
                            inplace = asixStopJudge(AxisXNameRight, Convert.ToDouble(item["X"]) + rightWeldDisX);
                            inplace = asixStopJudge(AxisYNameRight, Convert.ToDouble(item["Y"]) + rightWeldDisY);
                            inplace = asixStopJudge(AxisZNameRight, rightWeldHigh - highData);
                            if (inplace == false)
                                return -1;
                            //出光
                            if (weldByDllRight(item) == false)
                                return -1;
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"右清洗右:{rightIndex},第{ Program.colunmIndexRight}列，完成");
                            //Program.CurrentPoint_R++;
                        }
                        catch (Exception ex)
                        {
                            Weld_Log.Instance().Enqueue(ex.ToString());
                            return -1;
                        }
                    }
                    Program.CurrentPoint_R = 0;
                    Program.colunmIndexRight = 1;
                    return 0;
                case "右清洗左":
                    //遍历右清洗点位左半边
                    for (int b= Program.CurrentPoint_R; b < PointSetting_Form.rightPointDicWeldleft.Count; b++)
                    {
                        rightIndex = b + 1;
                        
                        Dictionary<string, string> item = PointSetting_Form.rightPointDicWeldleft.ElementAt(b).Value;

                        //停止
                        while (true)
                        {
                            Thread.Sleep(10);
                            if (!Program.bStop && Program.bAuto)//没有停止继续运行
                                break;
                            if (Program.bInt)//初始化
                            {
                                return 0;
                            }
                            if (Program.bEStop)//急停
                            {
                                return 0;
                            }
                            break;
                        }
                        Program.colunmIndexRight = Convert.ToInt32(item["列数"]);//记录列数
                        Program.CurrentPoint_R= Convert.ToInt32(item["点位"]);
                        if (Program.CurrentPoint_R==8|| Program.CurrentPoint_R == 18)
                        {
                            ResetEvent1.WaitOne();//阻塞线程等待左边先洗完
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue("等待左清洗右完成");
                        }
                        try
                        {
                            //运动测高点位
                            ManageContral.AxisPMoveAbsoluteToStop(AxisXNameRight, Convert.ToDouble(item["X"]) + rightHighDisX);
                            inplace = asixStopJudge(AxisXNameRight, Convert.ToDouble(item["X"]) + rightHighDisX);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisYNameRight, Convert.ToDouble(item["Y"]) + rightHighDisY);
                            inplace = asixStopJudge(AxisYNameRight, Convert.ToDouble(item["Y"]) + rightHighDisY);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisZNameRight, rightWeldHigh);
                            inplace = asixStopJudge(AxisZNameRight, rightWeldHigh);
                            if (inplace == false)
                                return -1;
                            returnz = defintionFun3.getHigh(item, dhLeft1, dhLeft2, rightIndex, ref highData);//测高,保存校正数据
                            if (returnz != 0)
                                return -1;
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"右清洗左测高结束测高值为:{highData}");
                            //运行到清洗位
                            while (true)
                            {
                                Thread.Sleep(10);
                                if (Program.bInt)//初始化
                                {
                                    return 0;
                                }
                                if (Program.bEStop)//急停
                                {
                                    return 0;
                                }
                                if (Program.colunmIndexLeft >= Program.colunmIndexRight||(bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["左清洗右标志"].Date==false)//没有停止继续运行
                                    break;
                            }
                            ManageContral.AxisPMoveAbsoluteToStop(AxisXNameRight, Convert.ToDouble(item["X"]) + rightWeldDisX);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisYNameRight, Convert.ToDouble(item["Y"]) + rightWeldDisY);
                            ManageContral.AxisPMoveAbsoluteToStop(AxisZNameRight, rightWeldHigh - highData);
                            inplace = asixStopJudge(AxisXNameRight, Convert.ToDouble(item["X"]) + rightWeldDisX);
                            inplace = asixStopJudge(AxisYNameRight, Convert.ToDouble(item["Y"]) + rightWeldDisY);
                            inplace = asixStopJudge(AxisZNameRight, rightWeldHigh - highData);
                            if (inplace == false)
                                return -1;
                            //出光
                            if (weldByDllRight(item) == false)
                                return -1;
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"右清洗左:{rightIndex},第{ Program.colunmIndexRight}列，完成");
                            //Program.CurrentPoint_R++;
                        }
                        catch (Exception ex)
                        {
                            Weld_Log.Instance().Enqueue(ex.ToString());
                            return -1;
                        }
                    }
                     Program.CurrentPoint_R = 0;
                    Program.colunmIndexRight = 1;
                    return 0;
                case "主控制":
                    return 0;
                case "点检左清洗":
                    for (int b = 0; b < PointSetting_Form.DJPointLeftDic.Count; b++)
                    {
                        if (b == ExamineForm.SelectCount1)
                        {
                            Dictionary<string, string> item = PointSetting_Form.DJPointLeftDic.ElementAt(b).Value;
                            //停止
                            while (true)
                            {
                                Thread.Sleep(10);
                                if (!Program.bStop && Program.bAuto)//没有停止继续运行
                                    break;
                                if (Program.bInt)//初始化
                                {
                                    return 0;
                                }
                                if (Program.bEStop)//急停
                                {
                                    return 0;
                                }
                                break;
                            }
                            try
                            {
                                //运动测高点位
                                ManageContral.AxisPMoveAbsoluteToStop(AxisXNameLeft, Convert.ToDouble(item["X"]) + leftHighDisX);
                                inplace = asixStopJudge(AxisXNameLeft, Convert.ToDouble(item["X"]) + leftHighDisX);
                                ManageContral.AxisPMoveAbsoluteToStop(AxisYNameLeft, Convert.ToDouble(item["Y"]) + leftHighDisY);
                                inplace = asixStopJudge(AxisYNameLeft, Convert.ToDouble(item["Y"]) + leftHighDisY);
                                ManageContral.AxisPMoveAbsoluteToStop(AxisZNameLeft, leftWeldHigh);
                                inplace = asixStopJudge(AxisZNameLeft, leftWeldHigh);
                                if (inplace == false)
                                    return -1;
                                returnz = defintionFun3.getHigh(item, dhRight1, dhRight2, leftIndex, ref highData);//测高,保存校正数据
                                if (returnz != 0)
                                    return -1;
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"右清洗左测高结束测高值为:{highData}");
                                //运行到清洗位
                                ManageContral.AxisPMoveAbsoluteToStop(AxisXNameLeft, Convert.ToDouble(item["X"]) + leftWeldDisX);
                                ManageContral.AxisPMoveAbsoluteToStop(AxisYNameLeft, Convert.ToDouble(item["Y"]) + leftWeldDisY);
                                ManageContral.AxisPMoveAbsoluteToStop(AxisZNameLeft, leftWeldHigh - highData);
                                inplace = asixStopJudge(AxisXNameLeft, Convert.ToDouble(item["X"]) + leftWeldDisX);
                                inplace = asixStopJudge(AxisYNameLeft, Convert.ToDouble(item["Y"]) + leftWeldDisY);
                                inplace = asixStopJudge(AxisZNameLeft, leftWeldHigh - highData);
                                if (inplace == false)
                                    return -1;
                                //出光
                                if (DJweldByDllLeft(item) == false)
                                    return -1;
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"左清洗点检:第{b}点,完成");
                                //Program.CurrentPoint_R++;
                            }
                            catch (Exception ex)
                            {
                                Weld_Log.Instance().Enqueue(ex.ToString());
                                return -1;
                            }
                        }
                    }
                    return 0;
                case "点检右清洗":
                    for (int a = 0; a < PointSetting_Form.DJPointRightDic.Count; a++)
                    {
                        if (a == ExamineForm.SelectCount2)
                        {
                            Dictionary<string, string> item = PointSetting_Form.DJPointRightDic.ElementAt(a).Value;
                            //停止
                            while (true)
                            {
                                Thread.Sleep(10);
                                if (!Program.bStop && Program.bAuto)//没有停止继续运行
                                    break;
                                if (Program.bInt)//初始化
                                {
                                    return 0;
                                }
                                if (Program.bEStop)//急停
                                {
                                    return 0;
                                }
                                break;
                            }
                            try
                            {
                                //运动测高点位
                                ManageContral.AxisPMoveAbsoluteToStop(AxisXNameRight, Convert.ToDouble(item["X"]) + rightHighDisX);
                                inplace = asixStopJudge(AxisXNameRight, Convert.ToDouble(item["X"]) + rightHighDisX);
                                ManageContral.AxisPMoveAbsoluteToStop(AxisYNameRight, Convert.ToDouble(item["Y"]) + rightHighDisY);
                                inplace = asixStopJudge(AxisYNameRight, Convert.ToDouble(item["Y"]) + rightHighDisY);
                                ManageContral.AxisPMoveAbsoluteToStop(AxisZNameRight, rightWeldHigh);
                                inplace = asixStopJudge(AxisZNameRight, rightWeldHigh);
                                if (inplace == false)
                                    return -1;
                                returnz = defintionFun3.getHigh(item, dhLeft1, dhLeft2, rightIndex, ref highData);//测高,保存校正数据
                                if (returnz != 0)
                                    return -1;
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"右清洗点检测高结束测高值为:{highData}");
                                //运行到清洗位
                                ManageContral.AxisPMoveAbsoluteToStop(AxisXNameRight, Convert.ToDouble(item["X"]) + rightWeldDisX);
                                ManageContral.AxisPMoveAbsoluteToStop(AxisYNameRight, Convert.ToDouble(item["Y"]) + rightWeldDisY);
                                ManageContral.AxisPMoveAbsoluteToStop(AxisZNameRight, rightWeldHigh - highData);
                                inplace = asixStopJudge(AxisXNameRight, Convert.ToDouble(item["X"]) + rightWeldDisX);
                                inplace = asixStopJudge(AxisYNameRight, Convert.ToDouble(item["Y"]) + rightWeldDisY);
                                inplace = asixStopJudge(AxisZNameRight, rightWeldHigh - highData);
                                if (inplace == false)
                                    return -1;
                                //出光
                                if (DJweldByDllRight(item) == false)
                                    return -1;
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"右清洗点检:第{a}点,完成");
                                Properties.Settings.Default.清洗点检完成时间 = DateTime.Now.ToString();
                                ExamineForm.action("清洗");
                            }
                            catch (Exception ex)
                            {
                                Weld_Log.Instance().Enqueue(ex.ToString());
                                return -1;
                            }
                        }
                    }
                    return 0;
                case "左测高点检":
                    for (int a = 0; a < PointSetting_Form.DJLeftCCDHightPointDic.Count; a++)
                    {
                        Dictionary<string, string> item = PointSetting_Form.DJLeftCCDHightPointDic.ElementAt(a).Value;
                        if(item["点位类型"]!="测高")
                        {
                            continue;
                        }
                        //停止
                        while (true)
                        {
                            Thread.Sleep(10);
                            if (!Program.bStop && Program.bAuto)//没有停止继续运行
                                break;
                            if (Program.bInt)//初始化
                            {
                                return 0;
                            }
                            if (Program.bEStop)//急停
                            {
                                return 0;
                            }
                            break;
                        }
                        try
                        {
                            //运动测高点位
                            ManageContral.AxisPMoveAbsoluteToStop(AxisXNameLeft, Convert.ToDouble(item["X坐标"]),1000,1000,150);
                            inplace = asixStopJudge(AxisXNameLeft, Convert.ToDouble(item["X坐标"]));
                            ManageContral.AxisPMoveAbsoluteToStop(AxisYNameLeft, Convert.ToDouble(item["Y坐标"]), 1000, 1000, 150);
                            inplace = asixStopJudge(AxisYNameLeft, Convert.ToDouble(item["Y坐标"]));
                            ManageContral.AxisPMoveAbsoluteToStop(AxisZNameLeft, Convert.ToDouble(item["Z坐标"]), 1000, 1000, 50);
                            inplace = asixStopJudge(AxisZNameLeft, Convert.ToDouble(item["Z坐标"]));
                            if (inplace == false)
                                return -1;
                            returnz = defintionFun3.getHigh(item, dhRight1, dhRight2, leftIndex, ref highData);//测高,保存校正数据
                            if (returnz != 0)
                                return -1;
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"左测高点检结束--测高值为:{highData}");
                            if (highData > 0.5)
                            {
                                MessageBox.Show($"左测高值为{highData},测高值偏大,点检不通过");
                                return 0;
                            }
                            else if (highData < -0.5)
                            {
                                MessageBox.Show($"左测高值为{highData},测高值偏小,点检不通过");
                                return 0;
                            }
                            else
                            {
                                Properties.Settings.Default.左测高点检完成 = true;
                                Properties.Settings.Default.左测高点检完成时间 = DateTime.Now.ToString();
                                Properties.Settings.Default.Save();
                                ExamineForm.action("左测高");
                            }

                        }
                        catch (Exception ex)
                        {
                            Weld_Log.Instance().Enqueue(ex.ToString());
                            return -1;
                        }
                    }
                    break;
                case "右测高点检":
                    for (int a = 0; a < PointSetting_Form.DJRightCCDHightPointDic.Count; a++)
                    {
                        Dictionary<string, string> item = PointSetting_Form.DJRightCCDHightPointDic.ElementAt(a).Value;
                        if (item["点位类型"] != "测高")
                        {
                            continue;
                        }
                        //停止
                        while (true)
                        {
                            Thread.Sleep(10);
                            if (!Program.bStop && Program.bAuto)//没有停止继续运行
                                break;
                            if (Program.bInt)//初始化
                            {
                                return 0;
                            }
                            if (Program.bEStop)//急停
                            {
                                return 0;
                            }
                            break;
                        }
                        try
                        {
                            //运动测高点位
                            ManageContral.AxisPMoveAbsoluteToStop(AxisXNameRight, Convert.ToDouble(item["X坐标"]), 1000, 1000, 150);
                            inplace = asixStopJudge(AxisXNameRight, Convert.ToDouble(item["X坐标"]));
                            ManageContral.AxisPMoveAbsoluteToStop(AxisYNameRight, Convert.ToDouble(item["Y坐标"]), 1000, 1000, 150);
                            inplace = asixStopJudge(AxisYNameRight, Convert.ToDouble(item["Y坐标"]));
                            ManageContral.AxisPMoveAbsoluteToStop(AxisZNameRight, Convert.ToDouble(item["Z坐标"]), 1000, 1000, 50);
                            inplace = asixStopJudge(AxisZNameRight, Convert.ToDouble(item["Z坐标"]));
                            if (inplace == false)
                                return -1;
                            returnz = defintionFun3.getHigh(item, dhLeft1, dhLeft2, rightIndex, ref highData);//测高,保存校正数据
                            if (returnz != 0)
                                return -1;
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"右测高点检结束--测高值为:{highData}");
                            if (highData > 0.5)
                            {
                                MessageBox.Show($"右测高值为{highData},测高值偏大,点检不通过");
                                return 0;
                            }
                            else if (highData < -0.5)
                            {
                                MessageBox.Show($"右测高值为{highData},测高值偏小,点检不通过");
                                return 0;
                            }
                            else
                            {
                                Properties.Settings.Default.右测高点检完成 = true;
                                Properties.Settings.Default.右测高点检完成时间 = DateTime.Now.ToString();
                                Properties.Settings.Default.Save();
                                ExamineForm.action("右测高");
                            }

                        }
                        catch (Exception ex)
                        {
                            Weld_Log.Instance().Enqueue(ex.ToString());
                            return -1;
                        }
                    }
                    break;
                case "左CCD点检":
                    leftIndex = 1;
                    CamerGetR_Center getNCCenterLeft = new CamerGetR_Center();//获取圆心坐标类
                    getNCCenterLeft.获取方式 = "CCD";
                    getNCCenterLeft._通讯名字 = "CCD左"; //用到
                    for (int a = 0; a < PointSetting_Form.DJLeftCCDHightPointDic.Count; a++)
                    {
                        Dictionary<string, string> item = PointSetting_Form.DJLeftCCDHightPointDic.ElementAt(a).Value;
                        if (item["点位类型"] != "拍照")
                        {
                            continue;
                        }
                        //停止
                        while (true)
                        {
                            Thread.Sleep(10);
                            if (!Program.bStop && Program.bAuto)//没有停止继续运行
                                break;
                            if (Program.bInt)//初始化
                            {
                                return 0;
                            }
                            if (Program.bEStop)//急停
                            {
                                return 0;
                            }
                            break;
                        }
                        try
                        {
                            //运动拍照点位
                            ManageContral.AxisPMoveAbsoluteToStop(AxisXNameLeft, Convert.ToDouble(item["X坐标"]), 1000, 1000, 150);
                            inplace = asixStopJudge(AxisXNameLeft, Convert.ToDouble(item["X坐标"]));
                            ManageContral.AxisPMoveAbsoluteToStop(AxisYNameLeft, Convert.ToDouble(item["Y坐标"]), 1000, 1000, 150);
                            inplace = asixStopJudge(AxisYNameLeft, Convert.ToDouble(item["Y坐标"]));
                            ManageContral.AxisPMoveAbsoluteToStop(AxisZNameLeft, Convert.ToDouble(item["Z坐标"]), 1000, 1000, 50);
                            inplace = asixStopJudge(AxisZNameLeft, Convert.ToDouble(item["Z坐标"]));
                            if (inplace == false)
                                return -1;
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"左相机点检拍照开始");
                            returnLeft = BZDJgetArcNCCenter(getNCCenterLeft,"左工位");//拍照取中心XY坐标
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"左相机点检拍照结束");
                            if (returnRight == -1)
                            {
                                MessageBox.Show($"左相机点检失败");
                                return 0;
                            }
                            else
                            {
                                Properties.Settings.Default.左CCD点检完成 = true;
                                Properties.Settings.Default.左CCD点检完成时间 = DateTime.Now.ToString();
                                Properties.Settings.Default.Save();
                                ExamineForm.action("CCD左");
                                return 0;
                            }

                        }
                        catch (Exception ex)
                        {
                            Weld_Log.Instance().Enqueue(ex.ToString());
                            return -1;
                        }
                    }
                    break;
                case "右CCD点检":
                    rightIndex = 1;
                    CamerGetR_Center getNCCenterRight = new CamerGetR_Center();//获取视觉坐标类
                    getNCCenterRight.获取方式 = "CCD";
                    getNCCenterRight._通讯名字 = "CCD右"; //用到
                    for (int a = 0; a < PointSetting_Form.DJRightCCDHightPointDic.Count; a++)
                    {
                        Dictionary<string, string> item = PointSetting_Form.DJRightCCDHightPointDic.ElementAt(a).Value;
                        if (item["点位类型"] != "拍照")
                        {
                            continue;
                        }
                        //停止
                        while (true)
                        {
                            Thread.Sleep(10);
                            if (!Program.bStop && Program.bAuto)//没有停止继续运行
                                break;
                            if (Program.bInt)//初始化
                            {
                                return 0;
                            }
                            if (Program.bEStop)//急停
                            {
                                return 0;
                            }
                            break;
                        }
                        try
                        {
                            //运动拍照点位
                            ManageContral.AxisPMoveAbsoluteToStop(AxisXNameRight, Convert.ToDouble(item["X坐标"]), 1000, 1000, 150);
                            inplace = asixStopJudge(AxisXNameRight, Convert.ToDouble(item["X坐标"]));
                            ManageContral.AxisPMoveAbsoluteToStop(AxisYNameRight, Convert.ToDouble(item["Y坐标"]), 1000, 1000, 150);
                            inplace = asixStopJudge(AxisYNameRight, Convert.ToDouble(item["Y坐标"]));
                            ManageContral.AxisPMoveAbsoluteToStop(AxisZNameRight, Convert.ToDouble(item["Z坐标"]), 1000, 1000, 50);
                            inplace = asixStopJudge(AxisZNameRight, Convert.ToDouble(item["Z坐标"]));
                            //拍照获取视觉坐标
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"右相机点检拍照开始");
                            returnRight = BZDJgetArcNCCenter(getNCCenterRight,"右工位");//拍照取中心XY坐标
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"右相机点检拍照结束");
                            if (returnRight == -1)
                            {
                                MessageBox.Show($"右相机点检失败");
                                return 0;
                            }
                            else
                            {
                                Properties.Settings.Default.右CCD点检完成 = true;
                                Properties.Settings.Default.右CCD点检完成时间 = DateTime.Now.ToString();
                                Properties.Settings.Default.Save();
                                ExamineForm.action("CCD右");
                                return 0;
                            }
                        }
                        catch (Exception ex)
                        {
                            Weld_Log.Instance().Enqueue(ex.ToString());
                            return -1;
                        }
                    }
                    break;
                default:
                    break;
            }
            return 0;
        }
        public int BZDJgetArcNCCenter(CamerGetR_Center getCenter, string workPlace)
        {
            int arcReturn = 0;
            string productType = DataManage.StrValue("型号", "模组型号");
            string qrCode = DataManage.StrValue("扫码", "模组码");
            string data = "";//视觉返回数据
            if (workPlace == "左工位")
            {
                    getCenter.发送命令 = "";
                    getCenter.发送命令 = "&Cam2_T1,SJ2023,BZDJ";
            }
            else if (workPlace == "右工位")
            {
                getCenter.发送命令 = "";
                getCenter.发送命令 = "&Cam1_T1,SJ2023,BZDJ";
            }
            //拍照校正，修改XY坐标后保存
            FormStart.LOG_ShowFrom["系统LOG"].Enqueue("触发相机点检拍照");
            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"发送指令：{getCenter.发送命令}");
            //触发拍照
            data = getCenter.GetR_C(getCenter);
            if (data == "")
            {
                MainForm.m_formAlarm.InsertAlarmMessage("获取结果失败!!!");
                Weld_Log.Instance().Enqueue("视觉检测失败");
                return -1;
            }
            else if (data != "")
            {
                arcReturn = 0;
            }
            Weld_Log.Instance().Enqueue($"{workPlace},拍照点检结束");
            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"{workPlace},拍照点检结束");
            return arcReturn;
        }
        public int getArcNCCenter(Dictionary<string, string> item, CamerGetR_Center getCenter, int i, string workPlace)
        {
            int arcReturn = 0;
            string productType = DataManage.StrValue("型号", "模组型号");
            string qrCode = DataManage.StrValue("扫码", "模组码");
            string data = "";//视觉返回数据
            if (workPlace == "左工位")
            {
                if (Properties.Settings.Default.首件)
                {
                    getCenter.发送命令 = "";
                    getCenter.发送命令 = $"&Cam2_T{i},{DataManage.StrValue("首件码", "首件")},DJ";
                }
                else
                {
                    getCenter.发送命令 = "";
                    getCenter.发送命令 = $"&Cam2_T{i},{qrCode},{productType}";
                }
            }
            else if (workPlace == "右工位")
            {
                if (Properties.Settings.Default.首件)
                {
                    getCenter.发送命令 = "";
                    getCenter.发送命令 = $"&Cam1_T{i},{DataManage.StrValue("首件码", "首件")},DJ";
                }
                else
                {
                    getCenter.发送命令 = "";
                    getCenter.发送命令 = $"&Cam1_T{i},{qrCode},{productType}";
                }
            }
            //拍照校正，修改XY坐标后保存
            FormStart.LOG_ShowFrom["系统LOG"].Enqueue("触发相机拍照");
            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"发送指令：{getCenter.发送命令}");
            //触发拍照
            data = getCenter.GetR_C(getCenter);
            if (data == "")
            {
                MainForm.m_formAlarm.InsertAlarmMessage("获取圆心失败!!!");
                Weld_Log.Instance().Enqueue("视觉检测失败，位置：" + i);
                return -1;
            }
            else if (data != "")
            {
                arcReturn = 0;
            }
            Weld_Log.Instance().Enqueue(i + "位置拍照");
            FormStart.LOG_ShowFrom["系统LOG"].Enqueue(i + "位置拍照");
            return arcReturn;
        }
        //克隆
        public object Clone(Object o)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            formatter.Serialize(memStream, o);
            memStream.Position = 0;
            return (formatter.Deserialize(memStream));
        }

        /// <summary>
        /// 判断轴停止
        /// </summary>
        /// <param name="asixName">轴的名称</param>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool asixStopJudge(string asixName, double position)
        {
            try
            {
                while (true)//运动停止
                {
                    Thread.Sleep(2);
                    if (Program.bInt)//初始化
                    {
                        return false;
                    }
                    if (Program.bEStop)//急停
                    {
                        return false;
                    }
                    if (ManageContral.DetectingAxis(asixName) == 0)
                    {
                        if (Program.bInt)//初始化
                        {
                            return false;
                        }
                        if (Program.bEStop)//急停
                        {
                            return false;
                        }
                        short axisNo = (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[asixName].m_AxisNo;//轴号
                        short cardNo = (short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[asixName].m_CardNo;//卡号
                        double axisPlus = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[asixName].PlusFeed;//脉冲量
                        double shiji = 0;
                        uint pClock;
                        short getPrfPos = gts.mc.GT_GetEncPos(cardNo, (short)(axisNo + 1), out shiji, 1, out pClock);
                        shiji = Math.Abs(shiji / axisPlus);
                        position = Math.Abs(position);
                        bool judgeInPlace = -1 < (position - shiji) && (position - shiji) < 1;
                        if (judgeInPlace)
                        {
                            break;
                        }
                        else
                        {
                            Weld_Log.Instance().Enqueue($"{asixName}当前位置{shiji}和规划位置{position}误差过大");
                            MainForm.m_formAlarm.InsertAlarmMessage($"{asixName}当前位置{shiji} 和规划位置{position}误差过大");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FormStart.LOG_ShowFrom["系统LOG"].Enqueue(ex.ToString());
            }
            return true;
        }

        public bool DJweldByDllRight(Dictionary<string, string> item)
        {
            try
            {
                EzdKernel.E3_ERR err = EzdKernel.E3_MarkerCheckLaserState(EzdKernelForm.ezdForm.m_idMarkerList[0], ref bIsOK);
                if (Properties.Settings.Default.允许出红光)
                {
                }
                else if (!bIsOK)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage("请检查激光器状态,或红光是否打开");
                    return false;
                }
                //清洗第一个点位
                Program.ifWeldLeft = true;
                err = EzdKernel.E3_MarkEnt2(EzdKernelForm.ezdForm.m_idMarkerList[0], EzdKernelForm.ezdForm.m_idEM, EzdKernelForm.ezdForm.m_idLayerList[0], 0, 0, 1);
            }
            catch (Exception ex)
            {
                MainForm.m_formAlarm.InsertAlarmMessage("请检查图档是否已打开！重新加载");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 二次开发出光（1卡）
        /// </summary>
        /// <returns></returns>
        public bool weldByDllRight(Dictionary<string, string> item)
        {
            try
            {
                double x1 = Convert.ToDouble(item["偏距X"]);//到极柱的偏距
                double y1 = Convert.ToDouble(item["偏距Y"]);
                EzdKernel.E3_ERR err = EzdKernel.E3_MarkerCheckLaserState(EzdKernelForm.ezdForm.m_idMarkerList[0], ref bIsOK);
                if (Properties.Settings.Default.允许出红光)
                {
                }
                else if(!bIsOK)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage("请检查激光器状态,或红光是否打开");
                    return false;
                }
                //清洗第一个点位
                Program.ifWeldLeft = true;
                err = EzdKernel.E3_MarkEnt2(EzdKernelForm.ezdForm.m_idMarkerList[0], EzdKernelForm.ezdForm.m_idEM, EzdKernelForm.ezdForm.m_idLayerList[0], 0, 0, 1);
                if (err != EzdKernel.E3_ERR.SUCCESS)
                {
                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue(err.ToString());
                    return false;
                }
                err = EzdKernel.E3_MarkerCheckLaserState(EzdKernelForm.ezdForm.m_idMarkerList[0], ref bIsOK);
                if (Properties.Settings.Default.允许出红光)
                {
                }
                else if (!bIsOK)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage("请检查激光器状态,或红光是否打开");
                    return false;
                }
                if (item["是否双数"] != "true")
                    return true;
                //图档偏移后洗第二个点位
                err = EzdKernel.E3_MoveRotateEnt(EzdKernelForm.ezdForm.m_idLayerList[0], x1, y1, 0, 0, 0);
                err = EzdKernel.E3_MarkEnt2(EzdKernelForm.ezdForm.m_idMarkerList[0], EzdKernelForm.ezdForm.m_idEM, EzdKernelForm.ezdForm.m_idLayerList[0], 0, 0, 1);
                Program.ifWeldRight = false;
                if (err != EzdKernel.E3_ERR.SUCCESS)
                {
                    err = EzdKernel.E3_MoveRotateEnt(EzdKernelForm.ezdForm.m_idLayerList[0], -x1, -y1, 0, 0, 0);//图档回零
                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue(err.ToString());
                    return false;
                }
                err = EzdKernel.E3_MoveRotateEnt(EzdKernelForm.ezdForm.m_idLayerList[0], -x1, -y1, 0, 0, 0);//图档回零
            }
            catch (Exception ex)
            {
                MainForm.m_formAlarm.InsertAlarmMessage("请检查图档是否已打开！重新加载");
                return false;
            }
            return true;
        }

        public bool DJweldByDllLeft(Dictionary<string, string> item)
        {
            try
            {
                EzdKernel.E3_ERR err = EzdKernel.E3_MarkerCheckLaserState(EzdKernelForm.ezdForm.m_idMarkerList[1], ref bIsOK);
                if (Properties.Settings.Default.允许出红光)
                {
                }
                else if (!bIsOK)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage("请检查激光器状态,或红光是否打开");
                    return false;
                }
                //清洗第一个点位
                Program.ifWeldRight = true;
                err = EzdKernel.E3_MarkEnt2(EzdKernelForm.ezdForm.m_idMarkerList[1], EzdKernelForm.ezdForm.m_idEM, EzdKernelForm.ezdForm.m_idLayerList[1], 0, 0, 1);
                if (err != EzdKernel.E3_ERR.SUCCESS)
                {
                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue(err.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                MainForm.m_formAlarm.InsertAlarmMessage("请检查图档是否已打开！重新加载");
                return false;
            }
            return true;
        }
        /// 二次开发出光（2卡）
        public bool weldByDllLeft(Dictionary<string, string> item)
        {
            try
            {                
                double x1 = Convert.ToDouble(item["偏距X"]);//到极柱的偏距
                double y1 = Convert.ToDouble(item["偏距Y"]);
                EzdKernel.E3_ERR err = EzdKernel.E3_MarkerCheckLaserState(EzdKernelForm.ezdForm.m_idMarkerList[1], ref bIsOK);
                if(Properties.Settings.Default.允许出红光)
                {
                }
                else if(!bIsOK)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage("请检查激光器状态,或红光是否打开");
                    return false;
                }
                //清洗第一个点位
                Program.ifWeldRight = true;
                err = EzdKernel.E3_MarkEnt2(EzdKernelForm.ezdForm.m_idMarkerList[1], EzdKernelForm.ezdForm.m_idEM, EzdKernelForm.ezdForm.m_idLayerList[1], 0, 0, 1);
                if (err != EzdKernel.E3_ERR.SUCCESS)
                {
                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue(err.ToString());
                    return false;
                }
                err = EzdKernel.E3_MarkerCheckLaserState(EzdKernelForm.ezdForm.m_idMarkerList[1], ref bIsOK);
                if (Properties.Settings.Default.允许出红光)
                {
                }
                else if (!bIsOK)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage("请检查激光器状态,或红光是否打开");
                    return false;
                }
                //是否有两个点
                if (item["是否双数"] != "true")
                    return true;
                //图档偏移后洗第二个点位
                err = EzdKernel.E3_MoveRotateEnt(EzdKernelForm.ezdForm.m_idLayerList[1],x1, y1, 0, 0, 0);
                err = EzdKernel.E3_MarkEnt2(EzdKernelForm.ezdForm.m_idMarkerList[1], EzdKernelForm.ezdForm.m_idEM, EzdKernelForm.ezdForm.m_idLayerList[1], 0, 0, 1);
                Program.ifWeldRight = false;
                if (err != EzdKernel.E3_ERR.SUCCESS)
                {
                    err = EzdKernel.E3_MoveRotateEnt(EzdKernelForm.ezdForm.m_idLayerList[1], -x1, -y1, 0, 0, 0);//图档回零
                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue(err.ToString());
                    return false;
                }
                err = EzdKernel.E3_MoveRotateEnt(EzdKernelForm.ezdForm.m_idLayerList[1], -x1, -y1, 0, 0, 0);//图档回零
            }
            catch (Exception ex)
            {
                MainForm.m_formAlarm.InsertAlarmMessage("请检查图档是否已打开！重新加载");
                return false;
            }
            return true;
        }  
    }
}