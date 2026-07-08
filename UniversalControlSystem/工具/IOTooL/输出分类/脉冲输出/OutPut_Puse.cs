using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
namespace UniversalControlSystem
{
    [Serializable]
    public class OutPut_Puse:ImageTool, ToolFun_OutIO
    {

        public int _Delay { get; set; }

        public int _Count { get; set; }
        
        public string  IO_Name { get; set; }
        //public OutPut_PulseFrom _OutPut_Pulse = new OutPut_PulseFrom();
        public bool SetOutBit(string bitName, bool bOn)
        {
            return true;
        }

        public bool GetOutBit(string bitName)
        {
            return ManageContral.GetInOn(bitName);
            //return Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[bitName].bBitOutputStatus;
        }
        public bool GetIntBit(string bitName)
        {
            return true;
        }
        public bool _OutPut_Puse(string bitName,int count,int delay)
        {
            DateTime starttime = DateTime.Now;

            for (int i = 0; i < count; i++)
            {
               
                ManageContral.SetOutBit(bitName, true);
                Thread.Sleep(delay);
                ManageContral.SetOutBit(bitName, false);
                Thread.Sleep(delay);
            }
            DateTime endtime = DateTime.Now;
            TimeSpan spantime = endtime - starttime;
            //spantime.TotalMilliseconds;
           
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
