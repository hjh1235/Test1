using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class LnXY : ImageTool
    {
        public int CardNum { get; set; }
        public int Cor { get; set; }
        /// <summary>
        /// 插补轴1名字
        /// </summary>
        public string _轴1Name { get; set; }
        /// <summary>
        /// 插补轴2名字
        /// </summary>
        public string _轴2Name { get; set; }
        /// <summary>
        /// 终点X
        /// </summary>
        public double EndX { get; set; }
        /// <summary>
        /// 终点X
        /// </summary>
        public double EndY { get; set; }

        public double StartSpeed { get; set; }
        public double EndSpeed { get; set; }

        public int GT_LnXY(LnXY _LnXY)
        {
            return ManageContral._LnXY(_LnXY);

        }
    }
}
