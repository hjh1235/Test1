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
    public class Neg : ImageTool
    {
        public List<NegData> Data = new List<NegData>();
        [NonSerialized]
        public Dictionary<string, NegData> _DataDic = new Dictionary<string, NegData>();

        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroup { set; get; }

        /// <summary>
        /// 结果是否取反
        /// </summary>
        public bool 结果是否取反 { set; get; }
        public bool NegFun(Neg _Neg)
        {
            List<bool> res = new List<bool>();
            for (int i = 0; i < _Neg.Data.Count; i++)
            {
                res.Add(false);
            }
            for (int j = 0; j < _Neg.Data.Count; j++)
            {
                bool _stas = Convert.ToBoolean(Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[_Neg.Data[j].DataTepyName].Date);
                bool stas = false;
                stas = !(bool)_stas;
                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[_Neg.Data[j].DataTepyName].Date = stas;
            }
            return true;

        }
    }
    [Serializable]
    public class NegData//或
    {
        //与名称
        public string NegDataName { get; set; }
        //与类型
        public string NegDataTepy { get; set; }
        //与类型名称
        public string DataTepyName { get; set; }
        //是否取反后进行运算
        public bool IsNeg { get; set; }



    }
}
