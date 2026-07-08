using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class DefintionFun3 : ImageTool, AixsCtronInterface
    {
        string AxisXName = "左清洗X轴", AxisYName = "左清洗Y轴", AxisZName = "左清洗Z轴";
        string AxisXName1 = "右清洗X轴", AxisYName1 = "右清洗Y轴", AxisZName1 = "右清洗Z轴";//11111111111111111
        public string FunName { get; set; }

        /// <summary>
        /// 用于执行测高流程
        /// </summary>
        /// <param name="_DefintionFun3"></param>
        /// <returns></returns>
        public int RunFun(DefintionFun3 _DefintionFun3)
        {
            switch (_DefintionFun3.FunName)
            {
                case "测高":
                    int returnz = -1;
                    int columnPoint = Convert.ToInt32(DataManage.StrValue("清洗", "每列个数"));//一列模组有多少个极柱点位
                    DigitalMea_Height dh = new DigitalMea_Height();
                    DigitalMea_Height dh1 = new DigitalMea_Height();
                    if (PointSetting_Form.pointDicIndex.Count % 4 != 0)
                    {
                        MainForm.m_formAlarm.InsertAlarmMessage("请检查点位数目！！！");
                        return -1;
                    }
                    foreach (Dictionary<string, string> item in PointSetting_Form.pointDicIndex.Values)
                    {
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
                    }
                    return returnz;
                default:
                    break;
            }
            return 0;
        }

        /// <summary>
        /// 测高双测高头
        /// </summary>
        /// <param name="item">字典遍历元素</param>
        /// <param name="dh">测高类</param>
        /// <param name="z">计数</param>
        /// <returns></returns>
        public int getHigh(Dictionary<string, string> item, DigitalMea_Height dh, DigitalMea_Height dh1, int z,ref double dataHigh)
        {
            double data = 0;
            //double data1 = 0;
            int getHighReturn = 0;
            //if (item["是否双数"] == "true")
            //{
            //    //测高校正，修改XY坐标后保存
            //    getHighReturn = dh.DigitalMea_Height_Fun(dh, out data);//测距
            //    if (getHighReturn != 0)
            //    {
            //        FormStart.LOG_ShowFrom["系统LOG"].Enqueue("前测高头测高失败，位置：" + z);
            //        return getHighReturn;//测距高度异常
            //    }
            //    getHighReturn = dh.DigitalMea_Height_Fun(dh1, out data1);//测距
            //    if (getHighReturn != 0)
            //    {
            //        FormStart.LOG_ShowFrom["系统LOG"].Enqueue("后测高头测高失败，位置：" + z);
            //        return getHighReturn;//测距高度异常
            //    }
            //}
            //else
            //{
            //    getHighReturn = dh.DigitalMea_Height_Fun(dh, out data);//测距
            //    if (getHighReturn != 0)
            //    {
            //        FormStart.LOG_ShowFrom["系统LOG"].Enqueue("前测高头测高失败，位置：" + z);
            //        return getHighReturn;//测距高度异常
            //    }
            //}
            getHighReturn = dh.DigitalMea_Height_Fun(dh, out data);//测距
            if (getHighReturn != 0)
            {
                FormStart.LOG_ShowFrom["系统LOG"].Enqueue("测高头测高失败，位置：" + z);
                return -1;//测距高度异常
            }
            //double avgData = (data1 + data) / 2;
            dataHigh = data;
            return getHighReturn;
        }
    }
}
