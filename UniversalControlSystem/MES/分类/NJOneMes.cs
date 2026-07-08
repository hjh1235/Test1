using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem.MES
{
    class NJOneMes : mes
    {
        /// <summary>
        /// 南京一期登录
        /// </summary>
        /// <param name="operatorID">登录账号</param>
        /// <param name="MoNumber">登录工单</param>
        /// <param name="PassWord">登录账号密码</param>
        /// <param name="MachineId">设备编号</param>
        /// <returns></returns>
        public override string Login(string operatorID, string MoNumber,string PassWord,string MachineId)
        {
            string mesResult = "";
            Dictionary<string, string> strDic = new Dictionary<string, string>();
            strDic.Add("operatorID", operatorID);
            strDic.Add("MoNumber", MoNumber);
            strDic.Add("PassWord", PassWord);
            strDic.Add("MachineId", MachineId);
            strDic.Add("Formula", "");
            string strJson = JsonConvert.SerializeObject(strDic);
            try
            {
                string jsonData = $"jsonData={strJson}";
                mesResult = mespost.getResult("LoginCheck.station?", jsonData, 8000);
                return getMsg(mesResult);
            }
            catch (Exception ex1)
            {
                return mesResult.Replace("[", "【").Replace("]", "】").Replace("\"", "“").Replace(":", "：").Replace("{", "｛").Replace("}", "｝").Replace(",", "，") + "；" + ex1.Message;
            }
        }

        /// <summary>
        /// 进站校验
        /// </summary>
        /// <param name="GroupCode">工序检查代码</param>
        /// <param name="MachineId">设备编号</param>
        /// <param name="OperatorId">登陆id</param>
        /// <param name="MoNumber">制令单</param>
        /// <param name="TimeStamp">当前时间</param>
        /// <param name="ProductSn">产品条码</param>
        /// <param name="SnType">产品条码类型</param>
        /// <returns></returns>
        public string StationCheck(string GroupCode,string MachineId,string OperatorId,string MoNumber,string TimeStamp, string ProductSn,string SnType)
        {

            string mesResult = "";
            Dictionary<string, string> strDic = new Dictionary<string, string>();
            strDic.Add("GroupCode", GroupCode);
            strDic.Add("MachineId", MachineId);
            strDic.Add("OperatorId", OperatorId);
            strDic.Add("MoNumber", MoNumber);
            strDic.Add("TimeStamp", TimeStamp);
            strDic.Add("ProductSn", ProductSn);
            strDic.Add("SnType", SnType);
            string strJson = JsonConvert.SerializeObject(strDic);
            try
            {
                StringBuilder sbJsonData = new StringBuilder();
                sbJsonData.Append($"jsonData={strJson}");
                mesResult = mespost.getResult("ProductionGroupInfo.station?", sbJsonData.ToString(), 10000);
                return getMsg(mesResult);
            }
            catch (Exception ex1)
            {
                return mesResult.Replace("[", "【").Replace("]", "】").Replace("\"", "“").Replace(":", "：").Replace("{", "｛").Replace("}", "｝").Replace(",", "，") + "；" + ex1.Message;
            }
        }

        /// <summary>
        /// 获取工装板绑定的模组二维码
        /// </summary>
        /// <param name="productSn">工装板二维码</param>
        /// <param name="groupcode">工序代码</param>
        /// <returns></returns>
        public override List<string> getSN(string productSn, string groupcode)
        {
            string mesResult = "";
            Dictionary<string, string> strDic = new Dictionary<string, string>();
            strDic.Add("productSn", productSn);
            string strJson = JsonConvert.SerializeObject(strDic);
            try
            {
                StringBuilder sbJsonData = new StringBuilder();
                sbJsonData.Append($"jsonData={strJson}");
                mesResult = mespost.getResult("NC_GetModuleByBoard.station?", sbJsonData.ToString(), 10000);
                return ConverFromJson_s(mesResult);
            }
            catch (Exception ex1)
            {
                return null;
            }
        }


        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="productSn">产品二维码</param>
        /// <param name="imgPath">图片路径</param>
        /// <param name="imType">图片格式</param>
        /// <returns></returns>
        public override string UploadImagePath(string productSn, string imgPath, string imType)//过站验证  校验工序
        {
            string mesResult = "";
            Dictionary<string, string> strDic = new Dictionary<string, string>();
            strDic.Add("productSn", productSn);
            strDic.Add("imgPath", imgPath);
            strDic.Add("imType", imType);
            string strJson = JsonConvert.SerializeObject(strDic);
            try
            {
                StringBuilder sbJsonData = new StringBuilder();
                sbJsonData.Append($"jsonData=[{strJson}]");
                mesResult = mespost.getResult("UploadImgPath.station?", sbJsonData.ToString(), 10000);
                return getMsg(mesResult);
            }
            catch (Exception ex1)
            {
                return mesResult.Replace("[", "【").Replace("]", "】").Replace("\"", "“").Replace(":", "：").Replace("{", "｛").Replace("}", "｝").Replace(",", "，") + "；" + ex1.Message;
            }
        }

        //过站
        public string ProductUpload(string GroupCode, string MachineId, string OperatorId, string MoNumber,string TimeStamp,string ProductSn,string TestResult, List<Dictionary<string, string>> testData, List<Dictionary<string, string>> Environment)//过站验证  校验工序
        {
            string mesResult = "";
            string testDataStr = JsonConvert.SerializeObject(testData);
            string EnvironmentStr = JsonConvert.SerializeObject(Environment);
            string uploadStr = JsonConvert.SerializeObject(testData);
            Dictionary<string, string> strDic = new Dictionary<string, string>();
            strDic.Add("GroupCode", GroupCode);
            strDic.Add("MachineId", MachineId);
            strDic.Add("OperatorId", OperatorId);
            strDic.Add("MoNumber", MoNumber);
            strDic.Add("TimeStamp", TimeStamp);
            strDic.Add("ProductSn", ProductSn);
            strDic.Add("testData", testDataStr);
            strDic.Add("Environment", EnvironmentStr);
            string strJson = JsonConvert.SerializeObject(strDic);
            try
            {
                StringBuilder sbJsonData = new StringBuilder();
                sbJsonData.Append($"jsonData={strDic}");
                mesResult = mespost.getResult("ProductionGroupInfo", sbJsonData.ToString(), 10000);
                return getMsg(mesResult);
            }
            catch (Exception ex1)
            {
                return mesResult.Replace("[", "【").Replace("]", "】").Replace("\"", "“").Replace(":", "：").Replace("{", "｛").Replace("}", "｝").Replace(",", "，") + "；" + ex1.Message;
            }
        }

    }
}
