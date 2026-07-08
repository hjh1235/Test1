
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace UniversalControlSystem
{

    [Serializable]
    public class CamerGetR_Center : ImageTool
    {
        //dll掉DLL方式
        //网络发送命令方式
        public string 获取方式 { get; set; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroup { set; get; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroupName { set; get; }
        public string _通讯名字 { get; set; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string 发送命令 { set; get; }
        /// <summary>
        /// 一次性拍几个
        /// </summary>
        public int 拍几个 { set; get; }
        /// <summary>
        /// 那个位置
        /// </summary>
        public int 拍位置 { set; get; }
        /// <summary>
        /// 曝光
        /// </summary>
        public int 曝光 { set; get; }
        /// <summary>
        /// SN存储的数据组
        /// </summary>
        public string DataGroup_sn { set; get; }
        /// <summary>
        /// SN存储的数据组下的名字
        /// </summary>
        public string DataGroupName_sn { set; get; }
        /// <summary>
        /// 视觉检测方式
        /// </summary>
        public string CheckTepy { set; get; }
        /// <summary>
        /// 获取圆心
        /// </summary>
        /// <returns></returns>
        /// 

        /// <summary>
        /// Aixs1名字
        /// </summary>
        /// <returns></returns>
        /// 
        public string Aixs1名字 { set; get; }

        public double Aixs1速度 { set; get; }
        public double Aixs1位置 { set; get; }
        public double Aixs1加速度 { set; get; }
        public double Aixs1减速度 { set; get; }
        /// <summary>
        /// Aixs2名字
        /// </summary>
        /// <returns></returns>
        /// 
        public string Aixs2名字 { set; get; }
        public double Aixs2速度 { set; get; }
        public double Aixs2位置 { set; get; }
        public double Aixs2加速度 { set; get; }
        public double Aixs2减速度 { set; get; }

        public string GetR_C(CamerGetR_Center CamerGetR_Center)
        {
            string _GetR_C = "";
            if (CamerGetR_Center.获取方式 == "DLL")
            {
                ManageContral.AxisPMoveAbsoluteToStop(CamerGetR_Center.Aixs1名字, CamerGetR_Center.Aixs1位置, CamerGetR_Center.Aixs1加速度, CamerGetR_Center.Aixs1减速度, CamerGetR_Center.Aixs1速度);
                ManageContral.AxisPMoveAbsoluteToStop(CamerGetR_Center.Aixs2名字, CamerGetR_Center.Aixs2位置, CamerGetR_Center.Aixs2加速度, CamerGetR_Center.Aixs2减速度, CamerGetR_Center.Aixs2速度);
                while (true)
                {
                    Thread.Sleep(50);
                    if (ManageContral.DetectingAxis(CamerGetR_Center.Aixs1名字) == 0 && ManageContral.DetectingAxis(CamerGetR_Center.Aixs2名字) == 0)
                    {
                        break;
                    }
                }
                List<LocationCircle.ResultClass> result = new List<LocationCircle.ResultClass>();
                object stu = null;
                string Sn = DataManage.StrValue(CamerGetR_Center.DataGroup_sn, CamerGetR_Center.DataGroupName_sn).ToString();
                //调用拍照函数
                string err = "";
                double ccdX = 0, ccdY = 0;
                //if (Program.form.VisionLocation(sn + "_" + snNumber, needGetR_check, NeedCheckR_check, d_Exprosure, ref resultCirclr))
                string date = DateTime.Now.ToString("yyyyMMddHHmm");
                //bool boolRt = Program.ccdForm.TestVision(date, out ccdX, out ccdY, out err);
                bool boolRt = Program.ccdForm.VisionLocation(Sn, CamerGetR_Center.CheckTepy, CamerGetR_Center.拍几个, CamerGetR_Center.拍位置, CamerGetR_Center.曝光, ref result);
                if (boolRt == true)
                {
                    //_GetR_C = ccdX.ToString() + ";" + ccdY.ToString()+ "/";
                    for (int i = 0; i < result.Count; i++)
                    {
                        _GetR_C += (CamerGetR_Center.Aixs1位置 - result[i].CenterPoint.X).ToString() + ";" + (CamerGetR_Center.Aixs2位置 - result[i].CenterPoint.Y).ToString() + ";" + result[i].Radius.ToString() + "/";

                    }
                    DataManage.SetData(CamerGetR_Center.DataGroup, CamerGetR_Center.DataGroupName, (object)_GetR_C);
                }
                else
                {
                    _GetR_C = "";
                }
            }
            else
            {
                try
                {
                    DateTime communicationStart = DateTime.Now;
                    CommunicationFun.ClearData(CamerGetR_Center._通讯名字);
                    if (CommunicationFun.Send(CamerGetR_Center._通讯名字, CamerGetR_Center.发送命令))
                    {
                        while (true)
                        {
                            //超时报警
                            DateTime communicationEnd = DateTime.Now;
                            TimeSpan spantime清洗 = communicationEnd - communicationStart;
                            
                            string OUTDATA = "";
                            CommunicationFun.RecvResult(CamerGetR_Center._通讯名字, out OUTDATA);
                            if (OUTDATA.Contains("OK"))
                            {
                                _GetR_C = OUTDATA;
                                DataManage.SetData(CamerGetR_Center.DataGroup, CamerGetR_Center.DataGroupName, (object)OUTDATA);
                                return _GetR_C;
                            }
                            else if (OUTDATA.Contains("NG"))
                            {
                                _GetR_C = "";
                                return _GetR_C;
                            }
                            else
                            {
                                _GetR_C = "";
                            }
                            if (spantime清洗.TotalMilliseconds > 8000)
                            {
                                Weld_Log.Instance().Enqueue("获取视觉参数异常！！！超时报警");
                                MainForm.m_formAlarm.InsertAlarmMessage("获取视觉参数异常！！！超时报警");
                                return "";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Weld_Log.Instance().Enqueue(ex.ToString());
                }
            }
            return _GetR_C;
        }
    }
}
