using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class Dimetric : ImageTool
    {
        public int CardNum { get; set; }
        public int Cor { get; set; }
        public string _轴1Name { get; set; }
        public string _轴2Name { get; set; }
        /// <summary>
        /// 矩形长
        /// </summary>
        public double RecLenght { get; set; }
        /// <summary>
        /// 矩形宽
        /// </summary>
        public double RecWidth { get; set; }
        /// <summary>
        /// 半径
        /// </summary>
        public double R { get; set; }
        /// <summary>
        ///      /// <summary>
        /// 是否需要R角
        /// </summary>
        public bool HaveR { get; set; }
        public double StartSpeed { get; set; }
        public double EndSpeed { get; set; }
        public double Acc { get; set; }
        public double Dec { get; set; }
        public int MoveRec(Dimetric _Dimetric)
        {
            ManageContral.MoveRec(_Dimetric);
            return 0;
        }
    }
}
