using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class Cir : ImageTool
    {
        public int CardNum { get; set; }
        public int Cor { get; set; }
        public string _轴1Name { get; set; }
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
        public double CenterX { get; set; }
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
        /// <summary>
        //// 半径
        /// </summary>
        public double R { get; set; }
        public double StartSpeed { get; set; }
        public double EndSpeed { get; set; }
        public double 角度 { get; set; }
        public string 圆圆弧选择 { get; set; }
        //度数
        public int  txtDicDeg { get; set; }
        //方向
        public string cmbSelectDir { get; set; }

        public double Acc { get; set; }
        public double Dec { get; set; }
       /// <summary>
       /// 偏移值
       /// </summary>
        public double CenterOfferX { get; set; }
        public double CenterOfferY { get; set; }

        /// <summary>
        /// 取圆心数据组
        /// </summary>
        public string DataGroup { set; get; }
        /// <summary>
        /// 取圆心数据组
        /// </summary>
        public string DataGroupName { set; get; }

        /// <summary>
        /// 参数集
        /// </summary>
        public string 参数集 { set; get; }
        public int CirRun(Cir _Cir)
        {
            ManageContral.CirRun(_Cir);
            return 0;
        }
    }
}
