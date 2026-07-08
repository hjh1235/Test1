using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
   [Serializable]
    public class Aixs_more_Ctron : ImageTool
    {
        public List<AixsData> Data = new List<AixsData>();
        [NonSerialized]
        public Dictionary<string ,AixsData> _DataDic = new Dictionary<string, AixsData>();
        public  int AxisPMoveAbsoluteToStop(string Name, double Pos, double Acc , double Dec, double Speed)
        {
          return  ManageContral.AxisPMoveAbsoluteToStop(Name, Pos, Acc, Dec, Speed);
        }
        /// <summary>
        /// 轴停止检测
        /// </summary>
        /// <param name="Aisx_Name">轴名称</param>
        ///0停止中
        ///1运动中
        /// <returns></returns>
        public int DetectingAxis(string Aisx_Name)
        {
          return ManageContral.DetectingAxis(Aisx_Name);
        }
    }
    [Serializable]
    public class AixsData
    {
        public string AixsName { get; set; }
        public double Pos { get; set; }
        public double Acc { get; set; }
        public double Dec { get; set; }
        public double Speed { get; set; }
    }
}
