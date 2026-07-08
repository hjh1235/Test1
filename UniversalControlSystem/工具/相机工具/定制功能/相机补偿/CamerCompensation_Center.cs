
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UniversalControlSystem
{

    [Serializable]
    public class CamerCompensation_Center : ImageTool
    {
        public string 轴名X { get; set; }
        public string 轴名Y { get; set; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroup { set; get; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroupName { set; get; }

        /// <summary>
        /// 参数组
        /// </summary>
        public string   参数组{ set; get; }
        public int AxisPCamerCompensation(CamerCompensation_Center _CamerCompensation_Center)
        {
            int res = -1;
            string data = DataManage.StrValue(_CamerCompensation_Center.DataGroup, _CamerCompensation_Center.DataGroupName);
            string[] _DataS = data.Split('/');
            string[] _DataSA= _DataS[0].Split(';');
            double _DataX = 0, _DataY = 0;
            try
            {
                //获取数据X 圆心中心
                _DataX = Convert.ToDouble(_DataSA[0]) + Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[_CamerCompensation_Center.参数组].X偏距振镜;
                   //获取数据y 圆心中心
                 _DataY =Convert.ToDouble(_DataSA[1]) +Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[_CamerCompensation_Center.参数组].Y偏距振镜 ;
                //补偿
                ManageContral.AxisPMoveAbsoluteToStop(_CamerCompensation_Center.轴名X, _DataX, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_CamerCompensation_Center.轴名X].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_CamerCompensation_Center.轴名X].Dec, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_CamerCompensation_Center.轴名X].Auto_Speed);
                ManageContral.AxisPMoveAbsoluteToStop(_CamerCompensation_Center.轴名Y, _DataY, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_CamerCompensation_Center.轴名Y].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_CamerCompensation_Center.轴名Y].Dec, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_CamerCompensation_Center.轴名Y].Auto_Speed);

                while (true)
                {
                    Thread.Sleep(50);
                    if (ManageContral.DetectingAxis(_CamerCompensation_Center.轴名X) == 0 && ManageContral.DetectingAxis(_CamerCompensation_Center.轴名Y) == 0)
                    {
                        res = 0;
                        break;
                    }
                }
            }
            catch
            {
                res = -1;
            }
            return res;
        }
    }
}
