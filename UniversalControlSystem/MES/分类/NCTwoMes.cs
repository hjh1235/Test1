using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem.MES
{
    class NCTwoMes : mes
    {
        /// <summary>
        /// 南昌二期登录
        /// </summary>
        /// <param name="operatorID">登录账号</param>
        /// <param name="machineID">设备编号</param>
        /// <param name="PassWord">登录账号密码</param>
        /// <param name="moNumber">登录工单</param>
        /// <returns></returns>
        public override string Login(string operatorID, string machineID, string passWord, string moNumber)
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
        public string StationCheck(string sessionid, string productSn, string groupcode)
        {
            string mesResult = "";
            try
            {
                StringBuilder sbJsonData = new StringBuilder();
                sbJsonData.Append("GroupInfo={\"sessionid\":\"");
                sbJsonData.Append(sessionid);
                sbJsonData.Append("\",\"productSn\":\"");
                sbJsonData.Append(productSn);
                sbJsonData.Append("\",\"groupcode\":\"");
                sbJsonData.Append(groupcode);
                sbJsonData.Append("\"}");
                mesResult = mespost.getResult("StationCheck", sbJsonData.ToString(), 10000);
                return getMsg(mesResult);
            }
            catch (Exception ex1)
            {
                return mesResult.Replace("[", "【").Replace("]", "】").Replace("\"", "“").Replace(":", "：").Replace("{", "｛").Replace("}", "｝").Replace(",", "，") + "；" + ex1.Message;
            }
        }
    }
}
