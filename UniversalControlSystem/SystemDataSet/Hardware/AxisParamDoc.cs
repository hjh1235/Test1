using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniversalControlSystem
{
    /// <summary>
    /// 轴参数设置
    /// </summary>
    public class AxisParamDoc : AxisBaseParam
    {
        public List<AxisBaseParam> m_AxisParamList;
        [XmlIgnore]
        public Dictionary<string, AxisBaseParam> m_AxisParamDictionary;
        public AxisParamDoc()
        {
            m_AxisParamList = new List<AxisBaseParam>();
            m_AxisParamDictionary = new Dictionary<string, AxisBaseParam>();
        }
        public void SaveAxisData()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/AxisDoc" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AxisParamDoc));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();
        }
        public static AxisParamDoc LoadObj()
        {
            AxisParamDoc pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AxisParamDoc));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/AxisDoc" + ".xml");
                pDoc = (AxisParamDoc)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();

            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new AxisParamDoc();
            }
            return pDoc;
        }
    }
    public class AxisBaseParam
    {
        public int cardNo { get; set; }//卡号
        public int AxisNo { get; set; }//轴号
        public string AxisSmallName { get; set; }//轴别名
        public double AccSpeed { get; set; }//加速度
        public double DecSpeed { get; set; }//减速度
        public double Speed { get; set; }//手动运行速度
        public double GoHomeSpeed { get; set; }//回原速度
        public double PulseFeed { get; set; }//脉冲当量
    }
}
