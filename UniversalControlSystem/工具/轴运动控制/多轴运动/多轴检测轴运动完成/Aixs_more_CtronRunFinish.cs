using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace UniversalControlSystem
{

   [Serializable]
    public class Aixs_more_CtronRunFinish : ImageTool
    {
        public List<Aixs_moreAixsData> Data = new List<Aixs_moreAixsData>();
        [NonSerialized]
        public  Dictionary<string ,AixsData> _DataDic = new Dictionary<string, AixsData>();
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
        public bool CheckFinish(Aixs_more_CtronRunFinish _Aixs_more_CtronRunFinish)
        {
            while (true)
            {
                if (Program.bInt == true)
                {
                    break;

                }
                Thread.Sleep(200);
            int count = 0;
            foreach (var item in _Aixs_more_CtronRunFinish.Data)
            {
                if (ManageContral.DetectingAxis(item.AixsName) == 0/*&& ManageContral.GETAxisp(item.AixsName)== _Aixs_more_CtronRunFinish.Data*/)
                {
                    count++;
                }
            }
                if (count == _Aixs_more_CtronRunFinish.Data.Count)
                {
                    break;
                }
                if ( Program.bStop || Program.bEStop)
                {
                    //currentRunStatus = true;
                    break;
                }
            }
            return true;
        }
    }
    [Serializable]
    public class Aixs_moreAixsData
    {
        public string AixsName { get; set; }
        //public double Pos { get; set; }
        //public double Acc { get; set; }
        //public double Dec { get; set; }
        //public double Speed { get; set; }
    }
}
