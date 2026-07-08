using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalControlSystem.PLC.PLC_Class_Ctr;

namespace UniversalControlSystem.PLC
{
    public class PLCData
    {
        public string Name { get; set; }
        public PLCDataType type { get; set; }
        public string data { get; set; }
        public string Address { get; set; }
        public string Lenght { get; set; }
    }
}
