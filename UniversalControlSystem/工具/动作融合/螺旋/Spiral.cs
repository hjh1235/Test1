using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class Spiral : ImageTool
    {
        public int CardNum { get; set; }
        public int Cor { get; set; }
        public string _轴1Name { get; set; }
        public string _轴2Name { get; set; }
        public string _轴3Name { get; set; }
        public string _轴4Name { get; set; }
      
    }
}
