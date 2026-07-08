using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UniversalControlSystem
{
    public partial class FlowMain : Form
    {
        public FlowMain()
        {
            InitializeComponent();
        }

        private void FlowMain_Load(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                轴名称.Items.Add(item.Value.Axis_hardwareName);
            }
            Asix_PointListData.LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int a = POS_dataGridView1.CurrentRow.Index;
            string ce = POS_dataGridView1.Rows[a].Cells[0].Value.ToString();
            if (轴名称.Text != "" && !Asix_PointListData.m_Doc.m_dataList[a].m_dataDictionary.ContainsKey(轴名称.Text))
            {
                Asix_DataBase _Asix_DataBase = new Asix_DataBase();
                _Asix_DataBase.Pos_DataName = 轴名称.Text;



                //int a = POS_dataGridView1.CurrentRow.Index;
                //string ce = POS_dataGridView1.Rows[a].Cells[0].Value.ToString();

                Asix_PointListData.m_Doc.m_dataList[a].m_dataList.Add(_Asix_DataBase);
                Asix_PointListData.m_Doc.m_dataList[a].m_dataDictionary.Add(轴名称.Text, _Asix_DataBase);


                int idx = dgv_deviceList.Rows.Add();
                dgv_deviceList.Rows[idx].Tag = 轴名称.Text;
                this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dgv_deviceList.Rows[idx].Height = 30;
                dgv_deviceList.Rows[idx].Cells[0].Value = 轴名称.Text;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int a = dgv_deviceList.CurrentRow.Index;
            string ce = dgv_deviceList.Rows[a].Cells[0].Value.ToString();
            Asix_PointListData.m_Doc.m_dataDictionary.Remove(ce);
            Asix_PointListData.m_Doc.m_dataList.RemoveAt(a);
            dgv_deviceList.Rows.RemoveAt(dgv_deviceList.SelectedRows[0].Index);

        }

        private void dgv_deviceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_deviceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
   
        }

        private void POS_ADD_Click(object sender, EventArgs e)
        {
            if (!Asix_PointListData.m_Doc.m_dataDictionary.ContainsKey(POS_NAME.Text))
            {
                Asix_DataS Asix_DataS = new Asix_DataS();
                Asix_DataS.Asix_DataName = POS_NAME.Text;

                Asix_PointListData.m_Doc.m_dataList.Add(Asix_DataS);
                Asix_PointListData.m_Doc.m_dataDictionary.Add(Asix_DataS.Asix_DataName, Asix_DataS);

                
                int idx = POS_dataGridView1.Rows.Add();
                POS_dataGridView1.Rows[idx].Tag = POS_NAME.Text;
                this.POS_dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                POS_dataGridView1.Rows[idx].Height = 30;
                POS_dataGridView1.Rows[idx].Cells[0].Value = POS_NAME.Text; 
            }


         
           

        }

        private void POS_dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = POS_dataGridView1.CurrentRow.Index;
            string ce = POS_dataGridView1.Rows[a].Cells[0].Value.ToString();
            dgv_deviceList.Rows.Clear();
            
            foreach (var item in Asix_PointListData.m_Doc.m_dataDictionary[ce].m_dataDictionary)
            {
                int idx = dgv_deviceList.Rows.Add();
                dgv_deviceList.Rows[idx].Tag = item.Value.Pos_DataName;
                this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dgv_deviceList.Rows[idx].Height = 30;
                dgv_deviceList.Rows[idx].Cells[0].Value = item.Value.Pos_DataName;

            }
        }

        private void POS_dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }

    static public class Asix_PointListData
    {
        static public Asix_DataDoc m_Doc;
        //static public FormProjectDataSetting frmProjectData;
        static public void LoadData()
        {
            m_Doc = Asix_DataDoc.LoadObj();
        }
    }
    [XmlInclude(typeof(Asix_DataS)), XmlInclude(typeof(Asix_DataBase)), XmlInclude(typeof(Asix_PointDataBase))]
    public class Asix_DataDoc
    {
        public List<Asix_DataS> m_dataList;
        [XmlIgnore]
        public Dictionary<string, Asix_DataS> m_dataDictionary;

        public Asix_DataDoc()
        {
            m_dataList = new List<Asix_DataS>();
            m_dataDictionary = new Dictionary<string, Asix_DataS>();
        }
        public static Asix_DataDoc LoadObj()
        {
            Asix_DataDoc pDoc;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Asix_DataDoc));
            FileStream fsReader = null;
            try
            {
                fsReader = File.OpenRead(@".//Parameter/Asix_DataDoc" + ".xml");
                pDoc = (Asix_DataDoc)xmlSerializer.Deserialize(fsReader);
                fsReader.Close();
                pDoc.m_dataDictionary = pDoc.m_dataList.ToDictionary(p => p.Asix_DataName);
                foreach (Asix_DataS item in pDoc.m_dataList)
                {
                    //item.m_dataDictionary = item.m_dataList.ToDictionary(p => p.strName);
                }
            }
            catch //(Exception eMy)
            {
                if (fsReader != null)
                {
                    fsReader.Close();
                }
                pDoc = new Asix_DataDoc();
            }
            return pDoc;
        }
        public bool SaveDoc()
        {
            if (!Directory.Exists(@".//Parameter/"))
            {
                Directory.CreateDirectory(@".//Parameter/");
            }
            FileStream fsWriter = new FileStream(@".//Parameter/Asix_DataDoc" + ".xml", FileMode.Create, FileAccess.Write, FileShare.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Asix_DataDoc));
            xmlSerializer.Serialize(fsWriter, this);
            fsWriter.Close();
            return true;
        }
    }
    public class Asix_DataS
    {
        public string Asix_DataName;
        public List<Asix_DataBase> m_dataList ;//存储
        [XmlIgnore]
        public Dictionary<string, Asix_DataBase> m_dataDictionary;

        public List<Asix_PointDataBase> Point_dataList;
        [XmlIgnore]

        public Dictionary<string, Asix_PointDataBase> m_Point_dataDictionary;
        public Asix_DataS()
        {
            m_dataList = new List<Asix_DataBase>();
            m_dataDictionary = new Dictionary<string, Asix_DataBase>();


            Point_dataList = new List<Asix_PointDataBase>();
            m_Point_dataDictionary = new Dictionary<string, Asix_PointDataBase>();
        }

    }
    public class Asix_DataBase
    {

        public string Pos_DataName;

        public List<double> Point_dataList;
        public double m_Point_dataList { set; get; }
        //public
        [XmlIgnore]
        public Dictionary<string, double> m_Point_dataDictionary;
        public Asix_DataBase()
        {

            Point_dataList = new List<double>();
            m_Point_dataDictionary = new Dictionary<string, double>();

        }
    }
    public class Asix_PointDataBase
    {

        public string Pos_DataName;

        public List<double> Point_dataList;

        [XmlIgnore]
        public Dictionary<string, double> m_Point_dataDictionary;
        public Asix_PointDataBase()
        {

            Point_dataList = new List<double>();
            m_Point_dataDictionary = new Dictionary<string, double>();

        }
    }
}
