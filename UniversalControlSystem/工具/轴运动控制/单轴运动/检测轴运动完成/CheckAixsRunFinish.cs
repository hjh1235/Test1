using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{

   [Serializable]
    public class CheckAixsRunFinish : ImageTool, AixsCtronInterface
    {
        public string AixsName { get; set; }
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

        //public int DetectingAxisCheckP(CheckAixsRunFinish CheckAixsRunFinish)
        //{
        //    //if ()
        //    //{


        //    //}
        //   // return ManageContral.DetectingAxis(Aisx_Name);
        //}
    }
}
