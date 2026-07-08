using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    interface IOutputAction
    {
        bool SetOutBit(int iBit, bool bOn);
        bool GetOutBit(int iBit);

    }
}
