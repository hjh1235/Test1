using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UniversalControlSystem
{
    public class GoolGaoHardwareDoc
    {
        public List<GoolGaoHardWareInfoBase> m_HardWareList;
        [XmlIgnore]
        public Dictionary<string, GoolGaoHardWareInfoBase> m_HardWareDictionary;
        public GoolGaoHardwareDoc()
        {
            m_HardWareList = new List<GoolGaoHardWareInfoBase>();
            m_HardWareDictionary = new Dictionary<string, GoolGaoHardWareInfoBase>();
        }
        public static GoolGaoHardwareDoc LoadObj()
        {
            GoolGaoHardwareDoc pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GoolGaoHardwareDoc));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/AxisParamDoc" + ".xml");
                pDoc = (GoolGaoHardwareDoc)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();
                pDoc.m_HardWareDictionary = pDoc.m_HardWareList.ToDictionary(p => p.hardwareName);

            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new GoolGaoHardwareDoc();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/AxisParamDoc" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GoolGaoHardwareDoc));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();

            return true;
        }

    }
    [XmlInclude(typeof(GoolGaoHardWareInfoBase)), XmlInclude(typeof(GoogolCardInfo))]
    public class GoolGaoHardWareInfoBase
    {
        public string hardwareName = "Empty";
        public string hardwareTpye = "Empty";
        public string hardwareVender = "Empty";
        public ushort hardwareModel = 0;
        public string ipAddress = "12";
        public string ModuleNum = "12";
        public GoolGaoHardWareInfoBase()
        {

        }
        virtual public void ShowSettingForm(Panel panel)
        {

        }
    }
}
