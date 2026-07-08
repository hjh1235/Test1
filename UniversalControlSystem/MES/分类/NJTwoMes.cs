using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem.MES
{
    class NJTwoMes : mes
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="operatorID"></param>
        /// <param name="passWord">密码</param>
        /// <param name="machineID">设备ID</param>
        /// <param name="moNumber"></param>
        /// <returns></returns>
        public override string Login(string operatorID, string passWord, string machineID, string moNumber)
        {
            string mesResult = "";
            Dictionary<string, string> strDic = new Dictionary<string, string>();
            strDic.Add("operatorID", operatorID);
            strDic.Add("machineID", machineID);
            strDic.Add("passWord", passWord);
            strDic.Add("moNumber", moNumber);
            string strJson = JsonConvert.SerializeObject(strDic);
            try
            {
                string jsonData = $"LoginInfo={strJson}";
                mesResult = mespost.getResult("LoginCheck", jsonData, 8000);
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
        /// <param name="sessionid">缓存ID</param>
        /// <param name="productSn">产品二维码</param>
        /// <param name="groupcode">工序代码</param>
        /// <returns></returns>
        public override string StationCheck(string sessionid, string productSn, string groupcode)
        {

            string mesResult = "";
            Dictionary<string, string> strDic = new Dictionary<string, string>();
            strDic.Add("sessionid", sessionid);
            strDic.Add("productSn", productSn);
            strDic.Add("groupcode", groupcode);
            string strJson = JsonConvert.SerializeObject(strDic);
            try
            {
                StringBuilder sbJsonData = new StringBuilder();
                sbJsonData.Append($"GroupInfo={strJson}");
                mesResult = mespost.getResult("StationCheck", sbJsonData.ToString(), 10000);
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
            try
            {
                StringBuilder sbJsonData = new StringBuilder();
                sbJsonData.Append("jsonData={\"SN\":\"");
                sbJsonData.Append(productSn);
                sbJsonData.Append("\"}");
                mesResult = mespost.getResult("GetModuleByBoard ", sbJsonData.ToString(), 10000);
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
                mesResult = mespost.getResult("UploadImgPath", sbJsonData.ToString(), 10000);
                return getMsg(mesResult);
            }
            catch (Exception ex1)
            {
                return mesResult.Replace("[", "【").Replace("]", "】").Replace("\"", "“").Replace(":", "：").Replace("{", "｛").Replace("}", "｝").Replace(",", "，") + "；" + ex1.Message;
            }
        }

        public override string ProductUpload(string productSn, string groupcode, string sessionid, List<Dictionary<string, string>> testDate, string result)//过站验证  校验工序
        {
            string mesResult = "";
            //string materials = JsonConvert.SerializeObject(materialsStr);
            string testDateStr = JsonConvert.SerializeObject(testDate);
            try
            {
                StringBuilder sbJsonData = new StringBuilder();
                sbJsonData.Append("ProductUploadInfo={\"productSn\":\"");
                sbJsonData.Append(productSn);
                sbJsonData.Append("\",\"groupcode\":\"");
                sbJsonData.Append(groupcode);
                sbJsonData.Append("\",\"sessionid\":\"");
                sbJsonData.Append(sessionid);
                //sbJsonData.Append("\",\"materials\":");
                //sbJsonData.Append(materials);
                sbJsonData.Append("\",\"testData\":");
                sbJsonData.Append(testDateStr);
                sbJsonData.Append(",\"result\":\"");
                sbJsonData.Append(result);
                sbJsonData.Append("\"}");
                Weld_Log.Instance().Enqueue(sbJsonData.ToString());
                mesResult = mespost.getResult("ProductUpload", sbJsonData.ToString(), 10000);
                return getMsg(mesResult);
            }
            catch (Exception ex1)
            {
                return mesResult.Replace("[", "【").Replace("]", "】").Replace("\"", "“").Replace(":", "：").Replace("{", "｛").Replace("}", "｝").Replace(",", "，") + "；" + ex1.Message;
            }
        }
    }
}
