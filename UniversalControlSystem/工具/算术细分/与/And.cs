using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    [Serializable]
    public class And : ImageTool
    {
        public List<AndData> Data = new List<AndData>();
        [NonSerialized]
        public Dictionary<string, AndData> _DataDic = new Dictionary<string, AndData>();
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroup { set; get; }

        /// <summary>
        /// 结果是否取反
        /// </summary>
        public bool  结果是否取反 { set; get; }
        
        public bool AndFun(And _And)
        {
            List<bool> res = new List<bool>();
            for (int i = 0; i < _And.Data.Count; i++)
            {
                res.Add(false);
            }
            for (int j = 0; j < _And.Data.Count; j++)
            {
                bool _stas = Convert.ToBoolean(Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[_And.Data[j].DataTepyName].Date);
                bool stas = false;
                if (_And.Data[j].IsNeg==true)//取反
                {
                    stas = !(bool)_stas;
                    //res[j]=stas;
                }
                else//正常
                {
                    stas = (bool)_stas;
                }
                if (j==0)
                {
                   res[j] = stas;
                }
                else
                {
                    res[j] = stas;
                    res[j] = res[j] && res[j-1];
                }
            }
            if (_And.结果是否取反==false)//结果不取反
            {
                bool sta = res[res.Count - 1];
                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[_And.DataGroup].Date = sta;
            }
            else//结果取反
            {
                bool sta = !res[res.Count - 1];
                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[_And.DataGroup].Date = sta;
            } 
            return true;
        }
    }
    [Serializable]
    public class AndData
    {
        //与名称
        public string AndDataName { get; set; }
        //与类型
        public string AndDataTepy { get; set; }
        //与类型名称
        public string DataTepyName{ get; set; }
        //是否取反后进行运算
        public bool IsNeg { get; set; }
    }
}
