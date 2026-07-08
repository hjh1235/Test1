using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace UniversalControlSystem
{
    [Serializable]
    public class DelayData : ImageTool
    {
        public int Delay { set; get; }
        public bool DelayFun(int DelayD)
        {
            bool sta = false;
            DateTime starttime = DateTime.Now;
            int stime = DelayD;
            while (true)
            {
                Thread.Sleep(50);
                DateTime endtime = DateTime.Now;
                TimeSpan spantime = endtime - starttime;
                if (spantime.TotalMilliseconds > stime)
                {
                    sta = true;
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
            }
            return sta;
        }
    }
}
