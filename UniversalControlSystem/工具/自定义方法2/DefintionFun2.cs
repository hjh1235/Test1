using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    [Serializable]
    public class DefintionFun2 : ImageTool, AixsCtronInterface
    {
        public string FunName { get; set; }
        int returnLeft = 0;
        int returnRight = 0;//右返回值

        /// <summary>
        /// 存放视觉的方法
        /// </summary>
        /// <param name="_DefintionFun2">自定义方法2</param>
        /// <returns></returns>
        public int RunFun(DefintionFun2 _DefintionFun2)
        {
            string AxisXNameRight = "右X主轴", AxisYNameRight = "右Y轴", AxisZNameRight = "右Z轴";
            string AxisXNameLeft = "左X主轴", AxisYNameLeft = "左Y轴", AxisZNameLeft = "左Z轴";
            int leftIndex = 1;
            int rightIndex = 1;
            #region//视觉类
            CamerGetR_Center sendQRCode = new CamerGetR_Center();//获取圆心坐标类
            sendQRCode.获取方式 = "CCD";
            #endregion
            string data = "";
            switch (_DefintionFun2.FunName)
            {
                case "左发送码":
                    string qrCode = DataManage.StrValue("扫码","模组码"); ;//1231231231213
                    sendQRCode._通讯名字 = "CCD右"; //用到
                                               //拍照校正，修改XY坐标后保存
                    sendQRCode.发送命令 = $"&SN:{qrCode}";
                    FormStart.LOG_ShowFrom["系统LOG"].Enqueue("发送码给相机");//
                    //触发拍照
                    data = sendQRCode.GetR_C(sendQRCode);
                    if (data == "")
                    {
                        MainForm.m_formAlarm.InsertAlarmMessage("发送码失败!!请检查前工位的扫码数据是否存在");
                        return -1;
                    }
                    return 0;
                case "右发送码":
                    return 0;
                case "左请求数据":
                    if (requestDataCCDLeft() == false)
                    {
                        return -1;
                    }
                    break;
                case "右请求数据":
                    if (requestDataCCDRight() == false)
                    {
                        return -1;
                    }
                    break;
                case "点检左请求数据":
                    if (DJrequestDataCCDLeft() == false)
                    {
                        return -1;
                    }
                    break;
                case "点检右请求数据":
                    if (DJrequestDataCCDRight() == false)
                    {
                        return -1;
                    }
                    break;
                case "左拍照":
                    leftIndex = 1;
                    #region//视觉类
                    CamerGetR_Center getNCCenterLeft = new CamerGetR_Center();//获取圆心坐标类
                    getNCCenterLeft.获取方式 = "CCD";
                    getNCCenterLeft._通讯名字 = "CCD左"; //用到
                    #endregion

                    //左允许拍照

                    for (int b = 0; b < PointSetting_Form.leftPointDic.Count; b++)
                    {
                        Dictionary<string, string> item = PointSetting_Form.leftPointDic.ElementAt(b).Value;

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
                        }

                        if (item["点位类型"] == "拍照")
                        {
                            try
                            {
                                ManageContral.AxisPMoveAbsoluteToStop(AxisXNameLeft, Convert.ToDouble(item["X坐标"]));
                                ManageContral.AxisPMoveAbsoluteToStop(AxisYNameLeft, Convert.ToDouble(item["Y坐标"]));
                                ManageContral.AxisPMoveAbsoluteToStop(AxisZNameLeft, Convert.ToDouble(item["Z坐标"]));
                                asixStopJudge(AxisXNameLeft, Convert.ToDouble(item["X坐标"]));
                                asixStopJudge(AxisYNameLeft, Convert.ToDouble(item["Y坐标"]));
                                asixStopJudge(AxisZNameLeft, Convert.ToDouble(item["Z坐标"]));
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"左相机第{leftIndex}MARK点拍照开始");
                                returnLeft = getArcNCCenter(item, getNCCenterLeft, leftIndex, "左工位");//拍照取中心XY坐标
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"左相机第{leftIndex}MARK点拍照结束");
                                //提示重拍
                                while (true)
                                {
                                    Thread.Sleep(10);
                                    if (returnLeft == -1)
                                    {
                                        Program.bAlarm = true;
                                        FlowCharCtron.alm();
                                        DialogResult result = MessageBox.Show($"左相机第{leftIndex}MARK点拍照获取数据异常", "是否重拍？", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                        if (result.ToString().ToUpper() == "YES")
                                        {
                                            returnLeft = getArcNCCenter(item, getNCCenterLeft, leftIndex, "左工位");//拍照取中心XY坐标
                                            if (returnLeft == 0)
                                            {
                                                Program.bAlarm = false;
                                                ManageContral.SetOutBit("三色灯绿", true);
                                                ManageContral.SetOutBit("三色灯黄", false);
                                                ManageContral.SetOutBit("三色灯红", false);
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            return -1;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                leftIndex++;
                            }
                            catch (Exception ex)
                            {
                                MainForm.m_formAlarm.InsertAlarmMessage($"第{leftIndex}点拍照失败，请检查点位！！！");
                                return -1;
                            }
                        }
                    }
                    Program.leftCCDSignal = false;
                    return returnLeft;
                case "右拍照":
                    rightIndex = 1;
                    #region//右视觉类
                    CamerGetR_Center getNCCenterRight = new CamerGetR_Center();//获取视觉坐标类
                    getNCCenterRight.获取方式 = "CCD";
                    getNCCenterRight._通讯名字 = "CCD右"; //用到
                    #endregion

                    //遍历拍照坐标
                    for (int b = 0; b < PointSetting_Form.rightPointDic.Count; b++)
                    {
                        Dictionary<string, string> item = PointSetting_Form.rightPointDic.ElementAt(b).Value;//通过下标获取元素                      

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
                        }

                        if (item["点位类型"] == "拍照")
                        {
                            try
                            {
                                ManageContral.AxisPMoveAbsoluteToStop(AxisXNameRight, Convert.ToDouble(item["X坐标"]));
                                ManageContral.AxisPMoveAbsoluteToStop(AxisYNameRight, Convert.ToDouble(item["Y坐标"]));
                                ManageContral.AxisPMoveAbsoluteToStop(AxisZNameRight, Convert.ToDouble(item["Z坐标"]));
                                asixStopJudge(AxisXNameRight, Convert.ToDouble(item["X坐标"]));
                                asixStopJudge(AxisYNameRight, Convert.ToDouble(item["Y坐标"]));
                                asixStopJudge(AxisZNameRight, Convert.ToDouble(item["Z坐标"]));

                                //拍照获取视觉坐标
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"右相机第{rightIndex}MARK点拍照开始");
                                returnRight = getArcNCCenter(item, getNCCenterRight, rightIndex, "右工位");//拍照取中心XY坐标
                                FormStart.LOG_ShowFrom["系统LOG"].Enqueue($"右相机第{rightIndex}MARK点拍照结束");

                                //提示重拍
                                while (true)
                                {
                                    Thread.Sleep(1);
                                    if (returnRight == -1)
                                    {
                                        Program.bAlarm = true;
                                        FlowCharCtron.alm();//报警
                                        DialogResult result = MessageBox.Show($"右相机第{rightIndex}MARK点拍照获取数据异常", "是否重拍？", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                        if (result.ToString().ToUpper() == "YES")
                                        {
                                            returnRight = getArcNCCenter(item, getNCCenterRight, rightIndex, "右工位");//拍照取中心XY坐标
                                            if (returnRight == 0)
                                            {
                                                Program.bAlarm = false;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            return -1;
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                rightIndex++;
                            }
                            catch (Exception ex)
                            {
                                MainForm.m_formAlarm.InsertAlarmMessage($"右相机第{rightIndex}MARK点拍照失败，请检查点位！！！");
                                return -1;
                            }
                        }
                    }
                    Program.rightCCDSignal = false;//拍照信号复位
                    return returnRight;
                case "主控制":
                    break;
                default:
                    break;
            }
            return 0;
        }

        /// <summary>
        /// 触发拍照双工位
        /// </summary>
        /// <param name="item">字典遍历的元素</param>
        /// <param name="getCenter">触发拍照类</param>
        /// <param name="i">计数</param>
        /// <param name="workPlace">工位</param>
        /// <returns></returns>
        public int getArcNCCenter(Dictionary<string, string> item, CamerGetR_Center getCenter, int i, string workPlace)
        {
            int arcReturn = 0;
            string productType = DataManage.StrValue("型号", "模组型号");
            string qrCode = DataManage.StrValue("扫码", "模组码"); 
            string data = "";//视觉返回数据
            if (workPlace == "左工位")
            {
                if(Properties.Settings.Default.首件)
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

        /// <summary>
        /// 解析右相机发送的数据
        /// </summary>
        /// <param name="ccdString"></param>
        /// <returns></returns>
        public bool getCCDDataRightX03(string ccdString)
        {
            try
            {
                //与旧数据比较，防止坐标有误
                string oldCorString = DataManage.StrValue("参照", "X03右");
                //if (rejectTwoString("X03右", ccdString, oldCorString) == false)
                ////{
                ////    MainForm.m_formAlarm.InsertAlarmMessage("极柱坐标位置和旧数据相差较大！");
                ////    return false;
                ////}
                List<string> strListXY = ccdString.Split(';').ToList();
                List<List<string>> allColumn = new List<List<string>>();
                List<List<string>> column1 = new List<List<string>>();
                List<List<string>> column2 = new List<List<string>>();
                List<List<string>> column3 = new List<List<string>>();
                int allColumnCount = 0;
                int columnCount = 1;
                strListXY.RemoveAt(0);
                strListXY.Remove("");

                if (strListXY.Count != 196)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage($"左相机数据数目{strListXY.Count}不是196个");
                    return false;
                }

                //存储每一列的数据集合共2个集合
                while (allColumnCount < 10)
                {
                    allColumn.Add(new List<string>());
                    allColumnCount++;
                }
                //把数据分成每一列
                foreach (var item in strListXY)
                {
                    //根据点位判断是哪一列
                    if (columnCount <= 37 && columnCount >= 19 && columnCount % 2 != 0)
                    {
                        allColumn[0].Add(item);
                    }
                    else if (columnCount <= 38 && columnCount >= 20 && columnCount % 2 == 0)
                    {
                        allColumn[1].Add(item);
                    }
                    else if (columnCount <= 77 && columnCount >= 59 && columnCount % 2 != 0)
                    {
                        allColumn[2].Add(item);
                    }
                    else if (columnCount <= 78 && columnCount >= 60 && columnCount % 2 == 0)
                    {
                        allColumn[3].Add(item);
                    }
                    else if (columnCount <= 117 && columnCount >= 99 && columnCount % 2 != 0)
                    {
                        allColumn[4].Add(item);
                    }
                    else if (columnCount <= 118 && columnCount >= 100 && columnCount % 2 == 0)
                    {
                        allColumn[5].Add(item);
                    }
                    else if (columnCount <= 157 && columnCount >= 139 && columnCount % 2 != 0)
                    {
                        allColumn[6].Add(item);
                    }
                    else if (columnCount <= 158 && columnCount >= 140 && columnCount % 2 == 0)
                    {
                        allColumn[7].Add(item);
                    }
                    else if (columnCount <= 195 && columnCount >= 177 && columnCount % 2 != 0)
                    {
                        allColumn[8].Add(item);
                    }
                    else if (columnCount <= 196 && columnCount >= 178 && columnCount % 2 == 0)
                    {
                        allColumn[9].Add(item);
                    }
                    columnCount++;
                }

                //把全部极柱分成三部分
                for (int a = 0; a < allColumn.Count; a++)
                {
                    allColumn[a].Reverse();//数据反转
                    if (a <= 4)
                    {
                        column1.Add(allColumn[a]);
                    }
                    else
                    {
                        column2.Add(allColumn[a]);
                    }
                }
                listToDic(PointSetting_Form.rightPointDicWeldleft, column1);//把坐标转成需要遍历的字典
                listToDic(PointSetting_Form.rightPointDicWeldRight, column2);//把坐标转成需要遍历的字典
            }
            catch (Exception ex)
            {
            }
            return true;
        }
        /// <summary>
        /// 解析左相机发送的数据
        /// </summary>
        /// <param name="ccdString"></param>
        /// <returns></returns>
        public bool getCCDDataLeftX03(string ccdString)
        {
            try
            {
                //与旧数据比较，防止坐标有误
                string oldCorString = DataManage.StrValue("参照", "X03左");
                if (rejectTwoString("X03左", ccdString, oldCorString) == false)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage("极柱坐标位置和旧数据相差较大！");
                    return false;
                }

                List<string> strListXY = ccdString.Split(';').ToList();
                List<List<string>> allColumn = new List<List<string>>();
                List<List<string>> column1 = new List<List<string>>();
                List<List<string>> column2 = new List<List<string>>();
                List<List<string>> column3 = new List<List<string>>();
                int allColumnCount = 0;
                int columnCount = 1;
                strListXY.RemoveAt(0);
                strListXY.Remove("");
                if (strListXY.Count != 196)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage($"左相机数据数目{strListXY.Count}不是196个");
                    return false;
                }
                //存储每一列的数据集合共2个集合
                while (allColumnCount < 10)
                {
                    allColumn.Add(new List<string>());
                    allColumnCount++;
                }

                //把数据分成每一列
                foreach (var item in strListXY)
                {
                    //根据点位判断是哪一列
                    if (columnCount<=17 && columnCount %2!=0|| columnCount==1)
                    {
                        allColumn[0].Add(item);
                    }
                    else if (columnCount<=18 || columnCount == 2&& columnCount%2==0)
                    {
                        allColumn[1].Add(item);
                    }
                    else if (columnCount <= 57&& columnCount >= 39&& columnCount % 2 != 0)
                    {
                        allColumn[2].Add(item);
                    }
                    else if (columnCount <= 58 && columnCount >= 40 && columnCount % 2 == 0)
                    {
                        allColumn[3].Add(item);
                    }
                    else if (columnCount <= 97 && columnCount >= 79 && columnCount % 2 != 0)
                    {
                        allColumn[4].Add(item);
                    }
                    else if (columnCount <= 98 && columnCount >= 80 && columnCount % 2 == 0)
                    {
                        allColumn[5].Add(item);
                    }
                    else if (columnCount <= 137 && columnCount >= 119 && columnCount % 2 != 0)
                    {
                        allColumn[6].Add(item);
                    }
                    else if (columnCount <= 138 && columnCount >= 120 && columnCount % 2 == 0)
                    {
                        allColumn[7].Add(item);
                    }
                    else if (columnCount <= 175 && columnCount >= 159 && columnCount % 2 != 0)
                    {
                        allColumn[8].Add(item);
                    }
                    else if (columnCount <= 176 && columnCount >= 160 && columnCount % 2 == 0)
                    {
                        allColumn[9].Add(item);
                    }
                    columnCount++;
                }

                //把全部极柱分成三部分
                for (int a = 0; a < allColumn.Count; a++)
                {
                    if (a <= 4)
                    {
                        column1.Add(allColumn[a]);
                    }
                    else
                    {
                        column2.Add(allColumn[a]);
                    }
                }
                
                listToDic(PointSetting_Form.leftPointDicWeldleft, column1);//把坐标转成需要遍历的字典
                listToDic(PointSetting_Form.leftPointDicWeldRight, column2);//把坐标转成需要遍历的字典
            }
            catch (Exception ex)
            {

            }
            return true;
        }


        /// <summary>
        /// 点检解析左相机发送的数据
        /// </summary>
        /// <param name="ccdString"></param>
        /// <returns></returns>
        public bool getCCDDataLeftDJ(string ccdString)
        {
            string oldCorString = DataManage.StrValue("参照", "X03左");
            if (rejectTwoString("X03左", ccdString, oldCorString) == false)
            {
                MainForm.m_formAlarm.InsertAlarmMessage("极柱坐标位置和旧数据相差较大！");
                return false;
            }
            try
            {
                List<string> strListXY = ccdString.Split(';').ToList();
                List<List<string>> allColumn = new List<List<string>>();
                strListXY.RemoveAt(0);
                strListXY.Remove("");
                if (strListXY.Count != 196)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage($"左相机数据数目{strListXY.Count}不是196个");
                    return false;
                }
                DJlistToDic(PointSetting_Form.DJPointLeftDic, strListXY);//把坐标转成需要遍历的字典
                //listToDic(PointSetting_Form.leftPointDicWeldRight, column2);//把坐标转成需要遍历的字典
            }
            catch (Exception ex)
            {
                FormStart.LOG_ShowFrom["系统LOG"].Enqueue("解析数据异常！" + ex);
            }
            return true;
        }

        /// <summary>
        /// 点检解析右相机发送的数据
        /// </summary>
        /// <param name="ccdString"></param>
        /// <returns></returns>
        public bool getCCDDataRightDJ(string ccdString)
        {
            string oldCorString = DataManage.StrValue("参照", "X03左");
            if (rejectTwoString("X03左", ccdString, oldCorString) == false)
            {
                MainForm.m_formAlarm.InsertAlarmMessage("极柱坐标位置和旧数据相差较大！");
                return false;
            }
            try
            {
                List<string> strListXY = ccdString.Split(';').ToList();
                List<List<string>> allColumn = new List<List<string>>();
                strListXY.RemoveAt(0);
                strListXY.Remove("");
                if (strListXY.Count != 196)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage($"右相机数据数目{strListXY.Count}不是196个");
                    return false;
                }
                DJlistToDic(PointSetting_Form.DJPointRightDic, strListXY);//把坐标转成需要遍历的字典
            }
            catch (Exception ex)
            {
                FormStart.LOG_ShowFrom["系统LOG"].Enqueue("解析数据异常！" + ex);
            }
            return true;
        }




        /// <summary>
        /// 解析左相机发送的数据
        /// </summary>
        /// <param name="ccdString"></param>
        /// <returns></returns>
        public bool getCCDDataLeftF01B(string ccdString)
        {
            try
            {
                List<string> strListXY = ccdString.Split(';').ToList();
                List<List<string>> allColumn = new List<List<string>>();
                List<List<string>> column1 = new List<List<string>>();
                List<List<string>> column2 = new List<List<string>>();
                int allColumnCount = 0;
                int columnCount = 1;
                strListXY.Remove("");

                //存储每一列的数据集合共2个集合
                while (allColumnCount < 10)
                {
                    allColumn.Add(new List<string>());
                    allColumnCount++;
                }

                //把数据分成每一列
                foreach (var item in strListXY)
                {
                    //根据点位判断是哪一列
                    if (11 < columnCount && columnCount <= 21)
                    {
                        allColumn[0].Add(item);
                    }
                    else if (32 < columnCount && columnCount <= 42)
                    {
                        allColumn[1].Add(item);
                    }
                    else if (53 < columnCount && columnCount <= 62)
                    {
                        allColumn[2].Add(item);
                    }
                    else if (73 < columnCount && columnCount <= 82)
                    {
                        allColumn[3].Add(item);
                    }
                    else if (93 < columnCount && columnCount <= 103)
                    {
                        allColumn[4].Add(item);
                    }
                    else if (114 < columnCount && columnCount <= 124)
                    {
                        allColumn[5].Add(item);
                    }
                    else if (135 < columnCount && columnCount <= 143)
                    {
                        allColumn[6].Add(item);
                    }
                    else if (154 < columnCount && columnCount <= 162)
                    {
                        allColumn[7].Add(item);
                    }
                    else if (173 < columnCount && columnCount <= 183)
                    {
                        allColumn[8].Add(item);
                    }
                    else if (194 < columnCount && columnCount <= 204)
                    {
                        allColumn[9].Add(item);
                    }
                    columnCount++;
                }

                //把全部极柱分成两部分
                for (int a = 0; a < allColumn.Count; a++)
                {
                    allColumn[a].Reverse();
                    if (a < 7)
                    {
                        column1.Add(allColumn[a]);
                    }
                    else
                    {
                        column2.Add(allColumn[a]);
                    }
                }
                listToDic(PointSetting_Form.leftPointDicWeldleft, column1);//把坐标转成需要遍历的字典
                listToDic(PointSetting_Form.leftPointDicWeldRight, column2);//把坐标转成需要遍历的字典
            }
            catch (Exception ex)
            {
                FormStart.LOG_ShowFrom["系统LOG"].Enqueue("解析数据异常！" + ex);
            }
            return true;
        }

        /// <summary>
        /// 解析右相机发送的数据
        /// </summary>
        /// <param name="ccdString"></param>
        /// <returns></returns>
        public bool getCCDDataRightF01B(string ccdString)
        {
            try
            {
                List<string> strListXY = ccdString.Split(';').ToList();
                List<List<string>> allColumn = new List<List<string>>();
                List<List<string>> column1 = new List<List<string>>();
                List<List<string>> column2 = new List<List<string>>();
                int allColumnCount = 0;
                int columnCount = 1;
                strListXY.Remove("");

                //存储每一列的数据集合共2个集合
                while (allColumnCount < 10)
                {
                    allColumn.Add(new List<string>());
                    allColumnCount++;
                }

                //把数据分成每一列
                foreach (var item in strListXY)
                {
                    //根据点位判断是哪一列
                    if (0 < columnCount && columnCount <= 11)
                    {
                        allColumn[0].Add(item);
                    }
                    else if (21 < columnCount && columnCount <= 32)
                    {
                        allColumn[1].Add(item);
                    }
                    else if (42 < columnCount && columnCount <= 53)
                    {
                        allColumn[2].Add(item);
                    }
                    else if (62 < columnCount && columnCount <= 73)
                    {
                        allColumn[3].Add(item);
                    }
                    else if (82 < columnCount && columnCount <= 93)
                    {
                        allColumn[4].Add(item);
                    }
                    else if (103 < columnCount && columnCount <= 114)
                    {
                        allColumn[5].Add(item);
                    }
                    else if (124 < columnCount && columnCount <= 135)
                    {
                        allColumn[6].Add(item);
                    }
                    else if (143 < columnCount && columnCount <= 154)
                    {
                        allColumn[7].Add(item);
                    }
                    else if (162 < columnCount && columnCount <= 173)
                    {
                        allColumn[8].Add(item);
                    }
                    else if (183 < columnCount && columnCount <= 194)
                    {
                        allColumn[9].Add(item);
                    }
                    columnCount++;
                }

                //把全部极柱分成两部分
                for (int a = 0; a < allColumn.Count; a++)
                {
                    if (a < 7)
                    {
                        column1.Add(allColumn[a]);
                    }
                    else
                    {
                        column2.Add(allColumn[a]);
                    }
                    listToDic(PointSetting_Form.leftPointDicWeldleft, column1);//把坐标转成需要遍历的字典
                    listToDic(PointSetting_Form.leftPointDicWeldRight, column2);//把坐标转成需要遍历的字典
                }
            }
            catch (Exception ex)
            {
                FormStart.LOG_ShowFrom["系统LOG"].Enqueue("解析数据异常！" + ex);
            }
            return true;
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
                    Thread.Sleep(1);
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
                        short aaa = gts.mc.GT_GetEncPos(cardNo, (short)(axisNo + 1), out shiji, 1, out pClock);
                        shiji = Math.Abs(shiji / axisPlus);
                        position = Math.Abs(position);
                        bool judgeInPlace = -1 < (position - shiji) && (position - shiji) < 1;
                        if (judgeInPlace)
                        {
                            break;
                        }
                        else
                        {
                            Weld_Log.Instance().Enqueue($"{asixName}当前位置{shiji} 和规划位置{position}误差过大");
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
        //点检数据请求左相机
        public bool DJrequestDataCCDLeft()
        {
            DateTime communicationStart = DateTime.Now;
            CommunicationFun.ClearData("CCD左");
            string productType = DataManage.StrValue("型号", "模组型号");
            if (CommunicationFun.Send("CCD左", "END"))
            {
                while (true)
                {
                    //超时报警
                    DateTime communicationEnd = DateTime.Now;
                    TimeSpan spantime = communicationEnd - communicationStart;
                    if (spantime.TotalMilliseconds > 3000)
                    {
                        Weld_Log.Instance().Enqueue("左CCD获取视觉参数异常！！！超时报警");
                        MainForm.m_formAlarm.InsertAlarmMessage("左CCD获取视觉参数异常！！！超时报警");
                        return false;
                    }
                    string OUTDATA = "";
                    Thread.Sleep(100);
                    CommunicationFun.RecvResult("CCD左", out OUTDATA);
                    if (OUTDATA != "" && OUTDATA.Length > 40)
                    {
                        Weld_Log.Instance().Enqueue(OUTDATA);
                        //解析左相机数据
                        if (!getCCDDataLeftDJ(OUTDATA))
                        {
                            return false;
                        }
                        break;
                    }
                }
            }
            return true;
        }
        //点检数据右相机请求数据
        public bool DJrequestDataCCDRight()
        {
            DateTime communicationStart = DateTime.Now;
            CommunicationFun.ClearData("CCD右");
            string productType = DataManage.StrValue("型号", "模组型号");
            if (CommunicationFun.Send("CCD右", "END"))
            {
                while (true)
                {
                    //超时报警
                    DateTime communicationEnd = DateTime.Now;
                    TimeSpan spantime = communicationEnd - communicationStart;
                    if (spantime.TotalMilliseconds > 3000)
                    {
                        Weld_Log.Instance().Enqueue("右CCD获取视觉参数异常！！！超时报警");
                        MainForm.m_formAlarm.InsertAlarmMessage("右CCD获取视觉参数异常！！！超时报警");
                        return false;
                    }
                    string OUTDATA = "";
                    Thread.Sleep(10);
                    CommunicationFun.RecvResult("CCD右", out OUTDATA);
                    if (OUTDATA != "" && OUTDATA.Length > 40)
                    {
                        Weld_Log.Instance().Enqueue(OUTDATA);
                        if (!getCCDDataRightDJ(OUTDATA))
                        {
                            return false;
                        }
                        break;
                    }
                }
            }
            return true;
        }

        //左请求数据
        public bool requestDataCCDLeft()
        {
            DateTime communicationStart = DateTime.Now;
            CommunicationFun.ClearData("CCD左");
            string productType = DataManage.StrValue("型号", "模组型号");
            if (CommunicationFun.Send("CCD左", "END"))
            {
                while (true)
                {
                    //超时报警
                    DateTime communicationEnd = DateTime.Now;
                    TimeSpan spantime = communicationEnd - communicationStart;
                    if (spantime.TotalMilliseconds > 15000)
                    {
                        Weld_Log.Instance().Enqueue("左CCD获取视觉参数异常！！！超时报警");
                        MainForm.m_formAlarm.InsertAlarmMessage("左CCD获取视觉参数异常！！！超时报警");
                        return false;
                    }
                    string OUTDATA = "";
                    Thread.Sleep(100);
                    CommunicationFun.RecvResult("CCD左", out OUTDATA);
                    if (OUTDATA != "" && OUTDATA.Length > 40)
                    {
                        Weld_Log.Instance().Enqueue(OUTDATA);
                        //解析左相机数据
                        if (productType == "F01B")
                        {
                            if (!getCCDDataLeftF01B(OUTDATA))
                            {
                                return false;
                            }
                        }
                        else if (productType == "X03")
                        {
                            if (!getCCDDataLeftX03(OUTDATA))
                            {
                                return false;
                            }
                        }
                        break;
                    }
                }
            }
            return true;
        }

        //右请求数据
        public bool requestDataCCDRight()
        {
            DateTime communicationStart = DateTime.Now;
            CommunicationFun.ClearData("CCD右");
            string productType = DataManage.StrValue("型号", "模组型号");
            if (CommunicationFun.Send("CCD右", "END"))
            {
                while (true)
                {
                    //超时报警
                    DateTime communicationEnd = DateTime.Now;
                    TimeSpan spantime = communicationEnd - communicationStart;
                    if (spantime.TotalMilliseconds > 15000)
                    {
                        Weld_Log.Instance().Enqueue("右CCD获取视觉参数异常！！！超时报警");
                        MainForm.m_formAlarm.InsertAlarmMessage("右CCD获取视觉参数异常！！！超时报警");
                        return false;
                    }
                    string OUTDATA = "";
                    Thread.Sleep(10);
                    CommunicationFun.RecvResult("CCD右", out OUTDATA);
                    if (OUTDATA != "" && OUTDATA.Length > 40)
                    {
                        Weld_Log.Instance().Enqueue(OUTDATA);
                        //解析左相机数据
                        if (productType.ToUpper() == "X03")
                        {
                            if (!getCCDDataRightX03(OUTDATA))
                            {
                                return false;
                            }
                        }
                        else if (productType.ToUpper() == "F01B")
                        {
                            if (!getCCDDataRightF01B(OUTDATA))
                            {
                                return false;
                            }
                        }
                        break;
                    }
                }
            }
            return true;
        }
        public bool DJlistToDic(Dictionary<string, Dictionary<string, string>> dic, List<string> list)
        {
            dic.Clear();
            int Index = 1;
            try
            {
                foreach (var item in list)
                {
                    dic.Add($"清洗点位{Index}", new Dictionary<string, string>()
                    {
                        ["X"] = item.Split(',')[0].ToString(),
                        ["Y"] = item.Split(',')[1].ToString(),
                        ["Z1"] = "0",
                        ["Z2"] = "0",
                    });
                    Index++;
                }
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public bool listToDic(Dictionary<string, Dictionary<string, string>> dic, List<List<string>> list)
        {
            dic.Clear();
            int index = 0;
            int columnIndex = 1;//列数
            foreach (List<string> item in list)
            {
                for (int a = 0; a < item.Count; a++)
                {
                    if (a %2==0 && a < item.Count - 1)
                    {
                        double 偏距X = Convert.ToDouble(item[a].Split(',')[0]) - Convert.ToDouble(item[a+1].Split(',')[0]);
                        double 偏距Y = Convert.ToDouble(item[a].Split(',')[1]) - Convert.ToDouble(item[a+1].Split(',')[1]);
                        dic.Add($"焊接{index}", new Dictionary<string, string>()
                        {
                            ["X"] = item[a].Split(',')[0].ToString(),
                            ["Y"] = item[a].Split(',')[1].ToString(),
                            ["Z1"] = "0",
                            ["Z2"] = "0",
                            ["偏距X"] = 偏距X.ToString(),
                            ["偏距Y"] = 偏距Y.ToString(),
                            ["列数"] = columnIndex.ToString(),
                            ["点位"] = index.ToString(),
                            ["是否双数"] = "true"
                        });
                        index++;
                    }
                    else if (a + 1 == item.Count && (a + 1) % 2 != 0)
                    {
                        dic.Add($"焊接{index}", new Dictionary<string, string>()
                        {
                            ["X"] = item[a].Split(',')[0].ToString(),
                            ["Y"] = item[a].Split(',')[1].ToString(),
                            ["Z1"] = "0",
                            ["Z2"] = "0",
                            ["偏距X"] = "0",
                            ["偏距Y"] = "0",
                            ["列数"] = columnIndex.ToString(),
                            ["点位"] = index.ToString(),
                            ["是否双数"] = "false"
                        });
                        index++;
                    }
                }
                columnIndex++;
            }
            return true;
        }
        private bool rejectTwoString(string productType, string newString, string oldCorString)
        {
            try
            {
                string strCor = newString.Replace("\r\n", "");
                Weld_Log.Instance().Enqueue($"{strCor.Length}/r{oldCorString.Length}");

                //判断
                if (rejectTwoCor(strCor, oldCorString) == false)
                {
                    MainForm.m_formAlarm.InsertAlarmMessage("视觉返回坐标超出管控！");
                    return false;
                }

            }
            catch (Exception ex)
            {
                Weld_Log.Instance().Enqueue(ex.ToString());
            }
            Weld_Log.Instance().Enqueue("模组坐标与参考坐标管控正常.");
            return true;
        }

        /// <summary>
        /// 比较两个字符串中的坐标
        /// </summary>
        /// <param name="newString">新的坐标</param>
        /// <param name="oldString">旧的</param>
        /// <returns></returns>
        private static bool rejectTwoCor(string newString, string oldString)
        {
            try
            {
                List<string> list = new List<string>();//每一列的坐标
                list = newString.Split(';').ToList();
                list.RemoveAt(0);
                list.Remove("");
                List<string> list1 = new List<string>();//每一列的坐标
                oldString = oldString.Substring(3);
                list1 = oldString.Split(';').ToList();
                list1.RemoveAt(0);
                list1.Remove("");
                if (list1.Count != list.Count)
                {
                    return false;
                }
                for (int a = 0; a < list.Count; a++)
                {
                    double x = Convert.ToDouble(list[a].Split(',')[0]);
                    double y = Convert.ToDouble(list[a].Split(',')[1]);
                    double x1 = Convert.ToDouble(list1[a].Split(',')[0]);
                    double y1 = Convert.ToDouble(list1[a].Split(',')[1]);

                    bool rejectTwoNumX = Math.Abs(x - x1) > Convert.ToDouble(DataManage.StrValue("参照", "X管控上限位").ToString());
                    bool rejectTwoNumY = Math.Abs(y - y1) > Convert.ToDouble(DataManage.StrValue("参照", "Y管控上限位").ToString()); ;
                    if (rejectTwoNumX || rejectTwoNumY)
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return true;
        }
    }
}
