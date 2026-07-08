using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace UniversalControlSystem
{
    public class Check_INPUT_Delay : InIO_Interface
    {
        public bool _Check_IN_Rising_edge(string bitName)
        {
            return true;
        }
        public bool _Check_INPUT(string bitName)
        {
            return true;
        }
        public bool _Check_IN_Falling_edge(string bitName)
        {
            return true;
        }
        public bool _Check_INPUT_Delay(string bitName, int delay)
        {
            while (true)
            {
                if (Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[bitName].bBitOutputStatus==true)
                {
                    Thread.Sleep(delay);
                    break;                 
                }          
            }   
            return true;
        }
    }
}
