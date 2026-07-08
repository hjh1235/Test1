using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    public class InputDrivers
    {
        public Dictionary<string, InputDriver> drivers;
        public InputDrivers()
        {
            drivers = new Dictionary<string, InputDriver>();
        }
    }
}
