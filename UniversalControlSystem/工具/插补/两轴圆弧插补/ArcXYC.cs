using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class ArcXYC : ImageTool
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
        /// 起点X
        /// </summary>
       public double StartX { get; set; }
        /// <summary>
        /// 起点Y
        /// </summary>
        public double StartY { get; set; }
        /// <summary>
        /// 过渡X
        /// </summary>
        public double  CenterX { get; set; }
        /// <summary>
        /// 过渡X
        /// </summary>
        public double CenterY { get; set; }

        /// <summary>
        /// 终点X
        /// </summary>
        public double EndX { get; set; }
        /// <summary>
        /// 终点X
        /// </summary>
        public double EndY { get; set; }
        /// <summary>
        /// 圆心X
        /// </summary>
        public double RX { get; set; }
        /// <summary>
        //// 圆心X
        /// </summary>
        public double RY { get; set; }
        public double StartSpeed { get; set; }
        public double EndSpeed { get; set; }
        public double 角度 { get; set; }
        public double CenterOfferX { get; set; }
        public double CenterOfferY{ get; set; }
        public double R { get; set; }
        public int GT_ArcXYC(ArcXYC _ArcXYC)
        {
            return ManageContral._ArcXYC(_ArcXYC);      
        }
    }
}
