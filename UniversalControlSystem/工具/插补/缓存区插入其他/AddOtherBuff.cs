using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class AddOtherBuff : ImageTool
    {
        public int CardNum { get; set; }
        public int Cor { get; set; }
        public string ChooseTepy { get; set; }
        public int  Delay { get; set; }
        //IO输出点位
        public int IONum { get; set; }
        //IO输出转态
        public bool IONumSta { get; set; }
        public int AddOtherBuffFun(AddOtherBuff _AddOtherBuff)
        {
            return ManageContral.AddOtherBuffFun(_AddOtherBuff);  
        }
    }
}
