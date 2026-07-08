using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace UniversalControlSystem
{
    [Serializable]
    public class Check_INPUT : ImageTool, InIO_Interface
    {
        public string IO_Name { get; set; }
        public string CheckIO_Sta { get; set; }
        public int  Delay { get; set; }
        public bool _Check_IN_Rising_edge(string bitName)
        {
            return true;
        }
        public bool _Check_INPUT(string bitName)
        {
            bool sta = false;
            try
            {
                sta= Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[bitName].bBitInputStatus;
              
            }
            catch
            {
                sta = false;
            }
            return sta;
        }
        public bool _Check_IN_Falling_edge(string bitName)
        {
            return true;
        }
        public bool _Check_INPUT_Delay(string bitName, int delay)
        {
            return true;
        }

        public bool WaitINPut_Check(string IONum, string CheckSta, int stime)    //一个检测
        {
            bool sta = false;
            DateTime starttime = DateTime.Now;
            while (true)
            {
                if (Program.bInt == true)
                {
                    return true;

                }
                DateTime endtime = DateTime.Now;
                TimeSpan spantime = endtime - starttime;
                sta = ManageContral.GetInOn(IONum);
                if (sta == true && CheckSta.ToLower() == "true")
                {
                    sta = true;
                    break;
                }
                if (sta == false && CheckSta.ToLower() == "false")
                {
                    sta = true;
                    break;
                }
                if (spantime.TotalMilliseconds > stime)
                {
                    sta = false;
                    break;
                }
                if (Program.bEStop == true)
                {
                    sta = false;
                    break;
                }
                if (Program.bStop == true)
                {
                    sta = false;
                    break;
                }
                Thread.Sleep(50);
            }
            return sta;
        }

        public bool WaitINPut_CheckNoStop(string IONum, string CheckSta, int stime)    //一个检测
        {
            bool sta = false;
            DateTime starttime = DateTime.Now;
            while (true)
            {
                if (Program.bInt == true)
                {
                    return true;

                }
                DateTime endtime = DateTime.Now;
                TimeSpan spantime = endtime - starttime;
                // Program.bEStop == true
                //    Program.bStop == true
                sta = ManageContral.GetInOn(IONum);
                if (sta == true && CheckSta.ToLower() == "true")
                {
                    sta = true;
                    break;
                }
                if (sta == false && CheckSta.ToLower() == "false")
                {
                    sta = true;
                    break;
                }
                if (spantime.TotalMilliseconds > stime)
                {
                    sta = false;
                    break;
                }
                if (Program.bEStop == true)
                {
                    sta = false;
                    break;
                }
                Thread.Sleep(50);
            }
            return sta;
        }

        public bool WaitINPut_CheckNoAuto(string IONum, string CheckSta, int stime)    //一个检测
        {
            bool sta = false;
            DateTime starttime = DateTime.Now;
            while (true)
            {
                DateTime endtime = DateTime.Now;
                TimeSpan spantime = endtime - starttime;
                // Program.bEStop == true
                //    Program.bStop == true
                sta = ManageContral.GetInOn(IONum);
                if (sta == true && CheckSta.ToLower() == "true")
                {
                    sta = true;
                    break;
                }
                if (sta == false && CheckSta.ToLower() == "false")
                {
                    sta = true;
                    break;
                }
                if (spantime.TotalMilliseconds > stime)
                {
                    sta = false;
                    break;
                }
                if (Program.bEStop == true)
                {
                    sta = false;
                    break;
                }
                Thread.Sleep(50);
            }
            return sta;
        }
    }
}
