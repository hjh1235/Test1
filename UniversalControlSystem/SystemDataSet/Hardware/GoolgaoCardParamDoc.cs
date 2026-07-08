using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniversalControlSystem
{
    public class GoolgaoCardParamDoc
    {
        public int iCardNo { get; set; }
        public string sCardName { get; set; }
        public string m_strConfigPath { get; set; }
        public string m_strExtDllName { get; set; }
        public static GoolgaoCardParamDoc LoadObj()
        {
            GoolgaoCardParamDoc pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GoolgaoCardParamDoc));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/HardwareDoc" + ".xml");
                pDoc = (GoolgaoCardParamDoc)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();

            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new GoolgaoCardParamDoc();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/HardwareDoc" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GoolgaoCardParamDoc));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();

            return true;
        }
    }
}
