
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{

    [Serializable]
    public class WeldedCheck : ImageTool
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


        public string GetR_C(WeldedCheck WeldedCheck)
        {
            string _GetR_C = "";
            if (WeldedCheck.获取方式 == "DLL")
            {
                List<LocationCircle.ResultClass> result = new List<LocationCircle.ResultClass>();
                object stu = null;
                string Sn = DataManage.StrValue(WeldedCheck.DataGroup_sn, WeldedCheck.DataGroupName_sn).ToString();
                //调用拍照函数
                 bool boolRt = Program.ccdForm.VisionLocation(Sn, WeldedCheck.CheckTepy, WeldedCheck.拍几个, WeldedCheck.拍位置, WeldedCheck.曝光, ref result);

                string err = "";
                double ccdX = 0, ccdY = 0;
                //if (Program.form.VisionLocation(sn + "_" + snNumber, needGetR_check, NeedCheckR_check, d_Exprosure, ref resultCirclr))
                //string date = DateTime.Now.ToString("yyyyMMddHHmm");
                //bool boolRt = Program.ccdForm.TestVision(date, out ccdX, out ccdY, out err);
                //_GetR_C = ccdX.ToString() + ";" + ccdY.ToString();
              
                if (boolRt == true)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        _GetR_C += result[i].CenterPoint.X + ";" +
                             result[i].CenterPoint.Y + "/";
                    }
                    DataManage.SetData(WeldedCheck.DataGroup, WeldedCheck.DataGroupName, (object)_GetR_C);
                }
                else
                {
                    _GetR_C = "";
                }
                //CamerGetR_Center
            }
            else
            {
                while (true)
                {
                    if (CommunicationFun.Send(WeldedCheck._通讯名字, WeldedCheck.发送命令))
                    {
                        string OUTDATA = "";
                        CommunicationFun.RecvResult(WeldedCheck._通讯名字, out OUTDATA);
                        if (OUTDATA != "")
                        {
                            DataManage.SetData(WeldedCheck.DataGroup, WeldedCheck.DataGroupName, (object)OUTDATA);
                        }
                        else
                        {
                            _GetR_C = "";
                        }
                        break;
                    }
                }


            }
            return _GetR_C;
        }
    }
}
