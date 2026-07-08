using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{

    [Serializable]
    public class DefintionFun4 : ImageTool, AixsCtronInterface
    {
        public string FunName { get; set; }

        /// <summary>
        /// 用于MES校验、过站、扫码、保存EXCEL数据
        /// </summary>
        /// <param name="_DefintionFun4"></param>
        /// <returns></returns>
        public int RunFun(DefintionFun4 _DefintionFun4)
        {
            _Client clientAgv = (_Client)Communication_DateLoadData._Communication_DateTool["AGV小车"];
            string stepAgv = Properties.Settings.Default.Agv工位;
            switch (_DefintionFun4.FunName)
            {
                case "扫码":
                    if (Properties.Settings.Default.屏蔽扫码)
                        return 0;
                    try
                    {
                        _Client client = (_Client)Communication_DateLoadData._Communication_DateTool["扫码枪"];
                        client.ClearData();
                        DateTime communicationStart = DateTime.Now;
                        string QRCode;
                        if (client.Send("LON"))
                        {
                            while (true)
                            {
                                //超时报警
                                DateTime communicationEnd = DateTime.Now;
                                TimeSpan spantime计时 = communicationEnd - communicationStart;
                                client.RecvResult(out QRCode);
                                if (QRCode.Contains("ERROR"))
                                {
                                    MainForm.m_formAlarm.InsertAlarmMessage("扫码失败！！");
                                    return -1;
                                }
                                else if (spantime计时.TotalMilliseconds > 2000)
                                {
                                    MainForm.m_formAlarm.InsertAlarmMessage("扫码失败！！超时报警！！！");
                                    return -1;
                                }
                                else if (QRCode != "")
                                {
                                    DataManage.SetData("扫码", "模组码", QRCode);
                                    Properties.Settings.Default.QRCode = QRCode;
                                    Properties.Settings.Default.Save();
                                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"扫码成功！{QRCode}");
                                    return 0;
                                }
                            }
                        }
                    }
                    catch
                    {
                        return -1;
                    }
                    return 0;
                case "MES校验":
                    try
                    {
                        if (LoginForm.bIgnoreMes || Properties.Settings.Default.屏蔽mes)
                            return 0;
                        //string SN = Properties.Settings.Default.QRCode;
                        //string 工序代码 = DataManage.StrValue("清洗", "工序代码");
                        //List<string> productCodeList = mes.Instance().getSN(SN, 工序代码);
                        //DataManage.SetData("扫码", "模组码", productCodeList[0]);
                        string productCodeList = DataManage.StrValue("扫码", "模组码");
                        //mes校验两个模组
                        //string product = mes.Instance().StationCheck(Properties.Settings.Default.SessionId, productCodeList[0], Properties.Settings.Default.MachineNo);
                        string product = mes.Instance().StationCheck(Properties.Settings.Default.SessionId, productCodeList, Properties.Settings.Default.MachineNo);
                        //模组进站结果处理
                        if (product.ToUpper().Contains("TRUE"))
                        {
                            //FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"{productCodeList[0]}进站成功");
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"{productCodeList}进站成功");
                            return 0;
                        }
                        else
                        {
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue("MES校验异常:" + product);
                            MainForm.m_formAlarm.InsertAlarmMessage("MES校验异常:" + product);
                            return -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        FormStart.LOG_ShowFrom["系统LOG"].Enqueue("MES校验异常:" + ex);
                        MainForm.m_formAlarm.InsertAlarmMessage("MES校验异常:" + ex);
                        return -1;
                    }
                case "MES过站":
                    try
                    {
                        if (LoginForm.bIgnoreMes || Properties.Settings.Default.屏蔽mes)
                            return 0;
                        string res过站;
                        string SN = DataManage.StrValue("扫码","模组码");
                        string 速度 = DataManage.StrValue("清洗", "速度");
                        string 功率 = DataManage.StrValue("清洗", "功率");
                        string 频率 = DataManage.StrValue("清洗", "频率");
                        string 工序代码 = DataManage.StrValue("清洗", "工序代码");
                        List<string> listExcel = new List<string>();
                        //过站参数
                        List<Dictionary<string, string>> testData = new List<Dictionary<string, string>>();
                        testData.Add(new Dictionary<string, string>() {
                        { "testItem", "点间距" }, { "testValue", "48" }, { "unit","mm" }, { "testResult","PASS" }});
                        testData.Add(new Dictionary<string, string>() {
                        { "testItem", "离焦量" }, { "testValue", "0" }, { "unit","mm" }, { "testResult","PASS" }});
                        testData.Add(new Dictionary<string, string>() {
                        { "testItem", "功率" }, { "testValue", "125"}, { "unit","W" }, { "testResult","PASS" }});
                        testData.Add(new Dictionary<string, string>() {
                        { "testItem", "线间距" }, { "testValue", "48" }, { "unit","mm" }, { "testResult","PASS" }});
                        testData.Add(new Dictionary<string, string>() {
                        { "testItem", "线速度" }, { "testValue", "10000" }, { "unit","mm/s" }, { "testResult","PASS" }});
                        //根据进站结果过站上传信息
                        res过站 = mes.Instance().ProductUpload(SN, 工序代码, Properties.Settings.Default.SessionId, testData, "PASS");
                        if (res过站.ToUpper().Contains("TRUE"))
                        {
                            SerialPortCom.updateInfo(1, "OK");//更新主页产品状态
                            FormStart.LOG_ShowFrom["系统LOG"].Enqueue("过站成功！模组:" + SN);
                            Weld_Log.Instance().Enqueue("过站成功！模组:" + SN);
                            listExcel.Add(DateTime.Now.ToString());
                            listExcel.Add(SN);
                            listExcel.Add(功率);
                            listExcel.Add(速度);
                            listExcel.Add(频率);
                            return 0;
                        }
                        else
                        {
                            SerialPortCom.updateInfo(2, "NG");//更新主页产品状态
                            MainForm.m_formAlarm.InsertAlarmMessage("MES校验异常:模组" + res过站);
                            Weld_Log.Instance().Enqueue("MES校验异常:模组" + res过站);
                            return -1;
                        }

                    }
                    catch (Exception ex)
                    {
                        MainForm.m_formAlarm.InsertAlarmMessage("程序发生文件格式错误！！！");
                        Weld_Log.Instance().Enqueue("程序发生文件格式错误！！！");
                        return -1;
                    }
                case "Agv小车请求进入":
                    if (Properties.Settings.Default.Agv工位 == "小车到位" || Properties.Settings.Default.屏蔽小车)
                        return 0;
                    EntryReq();
                    Properties.Settings.Default.Save();
                    break;
                case "请求离开Agv小车":
                    if (Properties.Settings.Default.屏蔽小车)
                    {
                        SerialPortCom.updateInfo(1,"复位小车");
                        return 0;
                    }
                    LeaveReq();
                    Properties.Settings.Default.Agv工位 = "小车离开";
                    Properties.Settings.Default.Save();
                    break;
                default:
                    break;
            }
            return 0;
        }

        /// <summary>
        /// 按条数据导入Excel表格清洗数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool SaveExcel(List<string> list)
        {
            try
            {
                DateTime time = DateTime.Now;
                string year = time.Year.ToString();
                string month = time.Month.ToString();
                string day = time.Day.ToString();
                string path = "E:\\清洗机数据\\" + year + "\\" + month;
                string txtname = year + month + day;
                //添加标题名称
                List<string> listhead = new List<string>();
                listhead.Add("时间");
                listhead.Add("模组码");
                listhead.Add("功率");
                listhead.Add("速度");
                listhead.Add("频率");
                int i = Excelhelper.DataTableToExcel(listhead, list, path, txtname + ".xls");
                if (i == -1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //小车请求进入
        private bool EntryReq()
        {
            _Client clientAgv = (_Client)Communication_DateLoadData._Communication_DateTool["AGV小车"];
            string step = "";
            string recStr = "";
            step = "sendSelect";
            while (true)
            {
                switch (step)
                {
                    case "sendSelect":
                        clientAgv.ClearData();
                        while (true)
                        {
                            Thread.Sleep(30);
                            if (Program.bInt || Program.bEStop)
                                return false;
                            if (clientAgv.Send("@#SelectEn@*"))
                            {
                                Thread.Sleep(100);
                                clientAgv.RecvResult(out recStr);
                                if (recStr == "EnterReq")
                                {
                                    Program.CTWatch.Reset();
                                    Program.CTWatch.Start();
                                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue("计时开始");
                                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue("小车请求进入");
                                    step = "immission";
                                    break;
                                }
                            }
                        }
                        break;
                    case "immission":
                        clientAgv.ClearData();
                        int Count = 0;
                        while (true)
                        {
                            if (Program.bInt || Program.bEStop)
                                return false;
                            if (clientAgv.Send("@#Immission@*"))
                            {
                                Count++;
                                if(Count==3)
                                {
                                    step = "waitReach";
                                    break;
                                }
                                Thread.Sleep(100);
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue("小车正在进入...");   
                            }
                        }
                        break;
                    case "waitReach":
                        clientAgv.ClearData();
                        Thread.Sleep(200);
                        while (true)
                        {
                            Thread.Sleep(10);
                            if (Program.bInt || Program.bEStop)
                                return false;
                            if (clientAgv.Send("@#SelectRe@*"))
                            {
                                Thread.Sleep(50);
                                clientAgv.RecvResult(out recStr);
                                if (recStr == "ReachedPos")
                                {
                                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue("小车已到位！");
                                    Properties.Settings.Default.Agv工位 = "小车到位";
                                    return true;
                                }
                            }
                        }
                }
            }
        }

        //请求小车离开
        private bool LeaveReq()
        {
            _Client clientAgv = (_Client)Communication_DateLoadData._Communication_DateTool["AGV小车"];
            string step = "";
            string recStr = "";
            step = "sendLeave";
            while (true)
            {
                switch (step)
                {
                    case "sendLeave":
                        clientAgv.ClearData();
                        while (true)
                        {
                            Thread.Sleep(30);
                            if (Program.bInt || Program.bEStop)
                                return false;
                            if (clientAgv.Send("@#LeaveReq@*"))
                            {
                                ManageContral.SetOutBit("光栅屏蔽信号", true);
                                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["光栅屏蔽"].Date = true;
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue("发送NTC光栅1停机信号,屏蔽清洗机光栅2");
                                Thread.Sleep(100);
                                step = "sendRoute";
                                break;
                            }
                        }
                        break;
                    case "sendRoute":
                        clientAgv.ClearData();
                        while (true)
                        {
                            if (Program.bInt || Program.bEStop)
                                return false;
                            if (clientAgv.Send("@#Route,21@*"))
                            {
                                Thread.Sleep(300);
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue("小车正在离开...");
                                step = "waitLeaveDone";
                                break;
                            }
                        }
                        break;
                    case "waitLeaveDone":
                        clientAgv.ClearData();
                        while (true)
                        {
                            Thread.Sleep(10);
                            if (Program.bInt || Program.bEStop)
                                return false;
                            if (clientAgv.Send("@#SelectLe@*"))
                            {
                                Thread.Sleep(50);
                                clientAgv.RecvResult(out recStr);
                                if (recStr == "LeaveDone")
                                {
                                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue("小车已离开！");
                                    return true;
                                }
                            }
                        }
                }
            }
        }
    }
}
