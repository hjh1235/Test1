using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public  class OutPut: ImageTool, ToolFun_OutIO
    {
        public int _Delay { get; set; }
        public int _Count { get; set; }
        public string  IO_Name { get; set; }
        public string OutSta { get; set; }
 
        public bool SetOutBit(string bitName, bool bOn)
        {
            //Googol_Contral.SetOutBit(bitName, bOn);
            return true;
        }
        public bool GetOutBit(string bitName)
        {
            return Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[bitName].bBitOutputStatus;      
        }
        public bool GetIntBit(string bitName)
        {
            return Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[bitName].bBitInputStatus;
        }
        public bool _OutPut_Puse(string bitName, int count, int delay)
        {
            return true;
        }
        public bool _F_OutPut_DeeDelay(string bitName, bool bOn, int delay)
        {
            return true;
        }
        public bool _F_Delay_DeeOutPut(string bitName, bool bOn, int delay)
        {
            return true;
        }
    }
}
