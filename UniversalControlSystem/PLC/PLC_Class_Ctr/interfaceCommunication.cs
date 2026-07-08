using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    interface interfaceCommunication
    {
        int  SendStr(string Str,out string Received);
        string  GetDataReceived();

    }
}
