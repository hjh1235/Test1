
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UniversalControlSystem
{
    public enum HardWardType
    {
        MotionCard,
        InputCard,
        OutputCard,
        InputOutputCard,
        ExpansionModule
    }
    public enum HardWardVender
    {
        Demo,
        GOOGOL,
        ADVANTECH,
        LEADTECH,
        ADLINK,
        SOFTSERVO,
        BECKHOFF
    }
    static public class HardwareManage
    {
        static public HardwareDoc hardDoc;
        static public FormHardSetting frmHardwareSetting;
        static public Dictionary<string, HardWareBase> hardwardDictionary;
        static public void LoadData()
        {
            hardDoc = HardwareDoc.LoadObj();
        }
        static public void InitHardWare()
        {
            hardwardDictionary = new Dictionary<string, HardWareBase>();
            foreach (KeyValuePair<string, HardWareInfoBase> item in hardDoc.m_HardWareDictionary)
            {
                GoogolTechExtCard demoCard = new GoogolTechExtCard();
                demoCard.hardwareName = item.Value.hardwareName;
                demoCard.hardwareVender = "Vender";
                demoCard.hardwareTpye = "Type";
                HardWareInfoBase tempInfo = item.Value;
                GoogolTechExtCardInfo tempInfoGoogol = (GoogolTechExtCardInfo)tempInfo;
                demoCard.usCardNo = (short)tempInfoGoogol.iCardNo;
                demoCard.usExtNo = (short)tempInfoGoogol.iExtCardNo;
                hardwardDictionary.Add(demoCard.hardwareName, demoCard);

            }
            foreach (KeyValuePair<string, HardWareBase> item in hardwardDictionary)
            {
                item.Value.Init(hardDoc.m_HardWareDictionary[item.Key]);
            }

        }

        static public void CloseHardWare()
        {
            foreach (KeyValuePair<string, HardWareBase> item in hardwardDictionary)
            {
                item.Value.Close();
            }
        }
    }
    
}
