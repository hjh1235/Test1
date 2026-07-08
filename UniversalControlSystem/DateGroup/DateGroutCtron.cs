using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    public class DateGroutCtron
    {
          /// <summary>
          /// 数据组设置数据方法
          /// </summary>
          /// <param name="DateName">数据组名</param>
          /// <param name="setDate">需设置的数据</param>
          /// <returns></returns>
        public static int setDateGrout(string DateName,string setDate)
        {
            int res = -1;
            if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Group_ControlDataTpye== "LONG")
            {
                bool b = Regex.IsMatch(setDate, @"^[+-]?\d*$");
                if (b == true)
                {
                    try
                    {
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date = long.Parse(setDate);
                        res = 0;
                    }
                    catch
                    {
                        res =(int)ERecvResult.数据组设置数据错误;
                    }
                }
                else
                {
                    res = (int)ERecvResult.数据组设置数据错误; 
                }

            }
            if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Group_ControlDataTpye == "STRING")
            {
                try
                {
                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date = setDate;
                    res = 0;
                }
                catch
                {
                    res = (int)ERecvResult.数据组设置数据错误; 
                }
            }
            if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Group_ControlDataTpye == "SHORT")
            {
                bool b = Regex.IsMatch(setDate, @"^[+-]?\d*$");
                if (b == true)
                {
                    try
                    {
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date = short.Parse(setDate);
                        res = 0;
                    }
                    catch
                    {
                        res = (int)ERecvResult.数据组设置数据错误; 
                    }
                }
                else
                {
                    res = -1;
                }
            }
            if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Group_ControlDataTpye == "DOUBLE")
            {
                bool a = Regex.IsMatch(setDate, @"^[+-]?\d*[.]?\d*$");
                if (a == true)
                {
                    try
                    {
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date = setDate;
                        res = 0;
                    }
                    catch
                    {
                        res = (int)ERecvResult.数据组设置数据错误; 
                    }
                }
                else
                {
                    res = (int)ERecvResult.数据组设置数据错误;
                }
            }
            if (Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Group_ControlDataTpye == "BOOL")
            {
                if (setDate.ToLower() == "true")
                {
                    try
                    {
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date = setDate.ToLower();
                        res = 0;
                    }
                    catch { res = (int)ERecvResult.数据组设置数据错误; }
                }
                else if (setDate.ToLower() == "false")
                {
                    try
                    {
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date = setDate.ToLower();
                        res = 0;
                    }
                    catch { res = (int)ERecvResult.数据组设置数据错误; }              
                }
                else if (setDate.ToLower() == "1")
                {
                    try
                    {
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date = setDate;
                        res = 0;
                    }
                    catch { res = (int)ERecvResult.数据组设置数据错误; }
                }
                else if (setDate.ToLower() == "0")
                {
                    try
                    {
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date = setDate;
                        res = 0;
                    }
                    catch { res = (int)ERecvResult.数据组设置数据错误; }
                }
                else
                {
                    res = (int)ERecvResult.数据组设置数据错误; 
                }
            }
            return res;
        }
        /// <summary>
        /// 数据组获取数据方法
        /// </summary>
        /// <param name="DateName">数据组名</param>
        /// <param name="getDate">数据</param>
        /// <returns></returns>
        public static  int getDateGrout(string DateName,out  object getDate)
        {
            int res = 0;
            object Date = new object();
            Date= Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[DateName].Date;
            getDate = Date;
            return res;
        }
    }
}
