using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class LnXYZ : ImageTool
    {
        public int CardNum { get; set; }
        public int Cor { get; set; }
        public string _轴1Name { get; set; }
        public string _轴2Name { get; set; }
        public string _轴3Name { get; set; }
        /// <summary>
        /// 终点X
        /// </summary>
        public double EndX { get; set; }
        /// <summary>
        /// 终点Y
        /// </summary>
        public double EndY { get; set; }
        /// <summary>
        /// 终点Z
        /// </summary>
        public double EndZ { get; set; }
        public double StartSpeed { get; set; }
        public double EndSpeed { get; set; }
        public int GT_LnXYZ(LnXYZ _LnXYZ)
        {
            return ManageContral._LnXYZ(_LnXYZ);

        }

    }
}
