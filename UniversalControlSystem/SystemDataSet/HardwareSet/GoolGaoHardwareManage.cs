using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    public class GoolGaoHardwareManage
    {
        static public GoolGaoHardwareDoc hardDoc;
        static public FormHardwareSetting frmHardwareSetting;
        static public Dictionary<string, GoolGaoHardWareInfoBase> hardwardDictionary;
        static public void LoadData()
        {
            hardDoc = GoolGaoHardwareDoc.LoadObj();
        }
        static public void InitHardWare(GoolgaoCardParamDoc pHardwareDoc)
        {
            hardwardDictionary = new Dictionary<string, GoolGaoHardWareInfoBase>();
            foreach (KeyValuePair<string, GoolGaoHardWareInfoBase> item in hardDoc.m_HardWareDictionary)
            {
                //GoogolCard demoCard = new GoogolCard();
                //demoCard.hardwareName = item.Value.hardwareName;
                //demoCard.hardwareVender = "Vender";
                //demoCard.hardwareTpye = "Type";
                //GoolGaoHardWareInfoBase tempInfo = item.Value;
                //GoogolCardInfo tempInfoGoogol = (GoogolCardInfo)tempInfo;
                //demoCard.usCardNo = (short)tempInfoGoogol.iCardNo;
                //demoCard.usExtNo = (short)tempInfoGoogol.iExtCardNo;
                //hardwardDictionary.Add(demoCard.hardwareName, demoCard);

            }
            //foreach (KeyValuePair<string, HardWareBase> item in hardwardDictionary)
            //{
            //    item.Value.Init(hardDoc.m_HardWareDictionary[item.Key]);
            //}

        }

        static public void CloseHardWare()
        {
            //foreach (KeyValuePair<string, HardWareBase> item in hardwardDictionary)
            //{
            //    item.Value.Close();
            //}
        }
    }
}
