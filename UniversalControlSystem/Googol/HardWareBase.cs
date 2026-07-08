using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    public class HardWareBase
    {
        protected object lockObj = new object();
        public string hardwareName;
     
        public bool bInitOK;
        public ushort hardwareModel = 0;
        public string ipAddress;
        virtual public bool Init()
        {
            return true;
        }
        virtual public bool Close()
        {
            return true;
        }
    }
}
