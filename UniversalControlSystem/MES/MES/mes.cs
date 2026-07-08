//using Newtonsoft.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.Util.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UniversalControlSystem
{
    public partial class mes
    {
        public static mes mesDate;
        public static mes Instance()
        {
            if (mesDate == null)
            {
                mesDate = new mes();
            }
            return mesDate;
        }
        public ImgFtpUpd ImageUpDate = new ImgFtpUpd();
        public HttpPost mespost = null;
        public FtpUpd theFtp = null;
        public string userCode = "";
        public string deviceCode = "";
        public string DataReceivedstrSN = "";
        public mes()
        {
            
        }
        public void Load(string Ls)
        {
            mespost = new HttpPost(Ls);
        }

        public Dictionary<string, string> ConverFromJson(string JsonStr)
        {
            Dictionary<string, string> dcValues = new Dictionary<string, string>();
            string[] strs = JsonStr.Trim().Trim(',').TrimStart('{').TrimEnd('}').Split(',');
            if (strs != null && strs.Length > 0)
            {
                for (int i = 0; i < strs.Length; i++)
                {
                    int idx1 = strs[i].IndexOf('\"');
                    if (idx1 >= 0 && strs[i].Length > idx1 + 1)
                    {
                        int idx2 = strs[i].IndexOf('\"', idx1 + 1);
                        if (idx2 > idx1)
                        {
                            string tKey = strs[i].Substring(idx1 + 1, idx2 - idx1 - 1);
                            if (strs[i].Length > idx2 + 1)
                            {
                                int idx3 = strs[i].IndexOf(':', idx2 + 1);
                                if (idx3 > idx2)
                                {
                                    int idx4 = strs[i].IndexOf('\"', idx3);
                                    if (idx4 > idx3 && strs[i].Length > idx4 + 1)
                                    {
                                        int idx5 = strs[i].IndexOf('\"', idx4 + 1);
                                        if (idx5 > idx4)
                                        {
                                            string tValue = strs[i].Substring(idx4 + 1, idx5 - idx4 - 1);
                                            dcValues.Add(tKey, tValue);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return dcValues;
        }

        //解析返回的条码字典
        public List<string> ConverFromJson_s(string JsonStr)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(JsonStr);
            string c = "";
            var firstChild = xml.FirstChild;
            string str = firstChild.NextSibling.InnerText;
            JObject dcValues = JsonConvert.DeserializeObject<JObject>(str);
            Type a = dcValues.GetType();
            JToken token = dcValues.GetValue("testResultDetails");
            List<string> list = new List<string>() {
                token.First.ToString(),
                token.Last.ToString()};
            return list;
        }

        //南京二期MES登录
        public string getMsg(string result)
        {
            Dictionary<string, string> dcValue = ConverFromJson(result);
            if (dcValue.ContainsKey("sessionid"))
            {
                Properties.Settings.Default.SessionId = dcValue["sessionid"];//保存获取的sessionid
                Properties.Settings.Default.Save();
            }
            if (dcValue["status"].ToUpper() == "TRUE")
            {
                return "TRUE";
            }
            else if (dcValue["status"].ToUpper() == "FALSE")
            {
                return dcValue["description"];
            }
            return "登陆失败";
        }

        public virtual string Login(string operatorID, string passWord, string machineID, string moNumber)
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
                mesResult = mespost.getResult("LoginCheck", jsonData, 10000);
                return getMsg(mesResult);
            }
            catch (Exception ex1)
            {
                return mesResult.Replace("[", "【").Replace("]", "】").Replace("\"", "“").Replace(":", "：").Replace("{", "｛").Replace("}", "｝").Replace(",", "，") + "；" + ex1.Message;
            }
        }


        public virtual List<string> getSN(string productSn, string groupcode)
        {
            string mesResult = "";
            try
            {
                StringBuilder sbJsonData = new StringBuilder();
                sbJsonData.Append("jsonData={\"SN\":\"");
                sbJsonData.Append(productSn);
                sbJsonData.Append("\"}");
                mesResult = mespost.getResult("GetModuleByBoard", sbJsonData.ToString(), 10000);
                return ConverFromJson_s(mesResult);
            }
            catch (Exception ex1)
            {
                return null;
            }
        }

        public virtual string StationCheck(string sessionid, string productSn, string groupcode)
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

        public virtual string UploadImagePath(string productSn, string imgPath, string imType)//过站验证  校验工序
        {
            string mesResult = "";
            try
            {
                StringBuilder sbJsonData = new StringBuilder();
                sbJsonData.Append("jsonData=[{\"productSn\":\"");
                sbJsonData.Append(productSn);
                sbJsonData.Append("\",\"imgPath\":\"");
                sbJsonData.Append(imgPath);
                sbJsonData.Append("\",\"imgType\":\"");
                sbJsonData.Append(imType);
                //sbJsonData.Append("\",\"res\":null}");
                sbJsonData.Append("\"}]");
                mesResult = mespost.getResult("UploadImgPath.action?", sbJsonData.ToString(), 10000);
                return getMsg(mesResult);
            }
            catch (Exception ex1)
            {
                return mesResult.Replace("[", "【").Replace("]", "】").Replace("\"", "“").Replace(":", "：").Replace("{", "｛").Replace("}", "｝").Replace(",", "，") + "；" + ex1.Message;
            }
        }

        //过站
        public virtual string ProductUpload(string productSn, string groupcode, string sessionid, List<Dictionary<string, string>> testDate,string result)//过站验证  校验工序
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
