using System;
using System.Collections;
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
    public partial class PointSetting_Form : Form
    {
        public PointSetting_Form()
        {
            InitializeComponent();
        }

        string name = "";
        Dictionary<string, string> pointPath = new Dictionary<string, string>();
        public static Hashtable pointTable = new Hashtable();
        public static Dictionary<string, Dictionary<string, string>> rightPointDic = new Dictionary<string, Dictionary<string, string>>();//右初始点位
        public static Dictionary<string, Dictionary<string, string>> leftPointDic = new Dictionary<string, Dictionary<string, string>>();//左初始点位

        public static Dictionary<string, Dictionary<string, string>> DJLeftCCDHightPointDic = new Dictionary<string, Dictionary<string, string>>();//左点检点位
        public static Dictionary<string, Dictionary<string, string>> DJRightCCDHightPointDic = new Dictionary<string, Dictionary<string, string>>();//右点检点位

        //清洗点位分4套字典存储
        public static Dictionary<string, Dictionary<string, string>> DJPointLeftDic = new Dictionary<string, Dictionary<string, string>>();//存储清洗走位坐标和图档偏距
        public static Dictionary<string, Dictionary<string, string>> DJPointRightDic = new Dictionary<string, Dictionary<string, string>>();//存储清洗走位坐标和图档偏距
        public static Dictionary<string, Dictionary<string, string>> rightPointDicWeldleft = new Dictionary<string, Dictionary<string, string>>();//存储清洗走位坐标和图档偏距
        public static Dictionary<string, Dictionary<string, string>> leftPointDicWeldleft = new Dictionary<string, Dictionary<string, string>>();//存储清洗走位坐标和图档偏距
        public static Dictionary<string, Dictionary<string, string>> rightPointDicWeldRight = new Dictionary<string, Dictionary<string, string>>();//存储清洗走位坐标和图档偏距
        public static Dictionary<string, Dictionary<string, string>> rightPointDicWeldRight1 = new Dictionary<string, Dictionary<string, string>>();//存储清洗走位坐标和图档偏距
        public static Dictionary<string, Dictionary<string, string>> leftPointDicWeldRight = new Dictionary<string, Dictionary<string, string>>();//存储清洗走位坐标和图档偏距
        public static Dictionary<string, Dictionary<string, string>> leftPointDicWeldRight1 = new Dictionary<string, Dictionary<string, string>>();//存储清洗走位坐标和图档偏距
        public static Dictionary<string, Dictionary<string, string>> pointDicIndex = new Dictionary<string, Dictionary<string, string>>();//焊接点位替代
        public static Dictionary<string, Dictionary<string, string>> pointDic = new Dictionary<string, Dictionary<string, string>>();
        public static List<Dictionary<string, string>> weldPosition = new List<Dictionary<string, string>>();
        public static string station = "";
        public static bool 左可以拍照 = false;
        public static bool 右可以拍照 = false;
        string path = AppDomain.CurrentDomain.BaseDirectory + "流程点位";
        private void listViewNFHardWare_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewNFHardWare.SelectedItems.Count > 0)
                {
                    name = listViewNFHardWare.Items[listViewNFHardWare.SelectedItems[0].Index].Text;
                    if (panel1.Controls.Count > 0)
                    {
                        for (int i = 0; i < panel1.Controls.Count; i++)
                        {
                            panel1.Controls.RemoveAt(0);
                        }
                    }
                    foreach (var item in pointPath)
                    {
                        if (name == item.Key)
                        {
                            Point_Form _Point_Form = new Point_Form();
                            _Point_Form.TopLevel = false;
                            panel1.Controls.Add(_Point_Form);
                            _Point_Form.Size = panel1.Size;
                            _Point_Form.Show();
                            _Point_Form.ShowFromMessage(name, item.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxHardWareName.Text != "" && cb_Station.Text != "")
                {
                    if (pointPath.ContainsKey(textBoxHardWareName.Text))
                    {
                        return;
                    }
                    ListViewItem lvi = listViewNFHardWare.Items.Add(textBoxHardWareName.Text);
                    lvi.SubItems.Add(cb_Station.Text);
                }
                string Path = path + "\\" + cb_Station.Text;
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                Path = path + "\\" + cb_Station.Text + "\\" + textBoxHardWareName.Text + ".csv";
                File.Create(Path).Close();
                pointPath.Add(textBoxHardWareName.Text, cb_Station.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("集合名格式错误");

            }
        }

        private void PointSetting_Form_Load(object sender, EventArgs e)
        {
            if (cb_Station.Items.Count > 0)
            {
                cb_Station.SelectedIndex = 0;
            }
            ShowView();

        }
        public void GetCsvName()
        {
            pointPath.Clear();
            string pathLeft = AppDomain.CurrentDomain.BaseDirectory + "流程点位\\左工位";
            string pathRight = AppDomain.CurrentDomain.BaseDirectory + "流程点位\\右工位";
            string pathSingle = AppDomain.CurrentDomain.BaseDirectory + "流程点位\\单工位";
            if (!Directory.Exists(pathLeft))
            {
                Directory.CreateDirectory(pathLeft);
            }
            if (!Directory.Exists(pathRight))
            {
                Directory.CreateDirectory(pathRight);
            }
            var filesLeft = Directory.GetFiles(pathLeft, "*.csv");
            foreach (var file in filesLeft)
            {
                string fileNameExt = file.Substring(file.LastIndexOf("\\") + 1); //获取文件名，不带路径
                string filePath = file.Substring(0, file.LastIndexOf("\\"));//获取文件路径，不带文件名   
                string name = fileNameExt.Substring(0, fileNameExt.LastIndexOf(".")); //获取文件名，不带后缀
                pointPath.Add(name, "左工位");
            }
            var filesRight = Directory.GetFiles(pathRight, "*.csv");
            foreach (var file in filesRight)
            {
                string fileNameExt = file.Substring(file.LastIndexOf("\\") + 1); //获取文件名，不带路径
                string filePath = file.Substring(0, file.LastIndexOf("\\"));//获取文件路径，不带文件名    
                string name = fileNameExt.Substring(0, fileNameExt.LastIndexOf("."));//获取文件名，不带后缀     
                pointPath.Add(name, "右工位");
            }
            var filesSingle = Directory.GetFiles(pathSingle, "*.csv");
            foreach (var file in filesSingle)
            {
                string fileNameExt = file.Substring(file.LastIndexOf("\\") + 1); //获取文件名，不带路径
                string filePath = file.Substring(0, file.LastIndexOf("\\"));//获取文件路径，不带文件名    
                string name = fileNameExt.Substring(0, fileNameExt.LastIndexOf("."));//获取文件名，不带后缀     
                pointPath.Add(name, "单工位");
            }
        }
        public void ShowView()
        {
            try
            {
                GetCsvName();
                listViewNFHardWare.Items.Clear();
                if (panel1.Controls.Count > 0)
                {
                    for (int i = 0; i < panel1.Controls.Count; i++)
                    {
                        panel1.Controls.RemoveAt(0);
                    }
                }
                foreach (var item in pointPath)
                {
                    if (item.Value == cb_Station.Text)
                    {
                        ListViewItem lvi = listViewNFHardWare.Items.Add(item.Key);
                        lvi.SubItems.Add(item.Value);
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否重命名你选中的该点位集合名?", "温馨提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    ShowView();
                }
            }
            catch (Exception)
            { }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string Path = path + "\\" + cb_Station.Text + "\\" + name + ".csv";
                File.Delete(Path);
                ShowView();
            }
            catch (Exception ex)
            {

            }
        }

        private void cb_Station_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowView();
        }

        private void PointSetting_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormStart.bPointSettingHide = false;
            this.Hide();
            e.Cancel = true;
        }

        private void listViewNFHardWare_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void PointSetting_Form_VisibleChanged(object sender, EventArgs e)
        {
            ShowView();
        }

        public static bool LoadObj(string name)
        {
            PointSetting_Form pf = new PointSetting_Form();
            pf.GetCsvName();
            //默认流程数据
            string filePath = "";

            ArrayList pointList = new ArrayList();
            try
            {
                if (name == "左工位")
                {
                    //Properties.Settings.Default.LeftPointTask = "左清洗";
                    if (Properties.Settings.Default.LeftPointTask == "")
                        return false;
                    filePath = pf.path + "\\左工位\\" + Properties.Settings.Default.LeftPointTask + ".csv";
                    leftPointDic.Clear();
                    pf.ImportCsvData(filePath, "左工位");
                    filePath = pf.path + "\\左工位\\点检左.csv";
                    DJLeftCCDHightPointDic.Clear();
                    pf.ImportCsvData(filePath, "点检左");
                }
                else if (name == "右工位")
                {
                    if (Properties.Settings.Default.RightPointTask == "")
                        return false;
                    rightPointDic.Clear();
                    filePath = pf.path + "\\右工位\\" + Properties.Settings.Default.RightPointTask + ".csv";
                    pf.ImportCsvData(filePath, "右工位");
                    filePath = pf.path + "\\右工位\\点检右.csv";
                    DJRightCCDHightPointDic.Clear();
                    pf.ImportCsvData(filePath, "点检右");
                }
                else if (name == "单工位")
                {
                    if (Properties.Settings.Default.PointList == "")
                        return false;
                    pointDic.Clear();
                    filePath = pf.path + "\\单工位\\" + Properties.Settings.Default.PointList + ".csv";
                    pf.ImportCsvData(filePath, "单工位");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("流程点位错误，请检查默认流程信息！");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Stream读取.csv文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public void ImportCsvData(string filePath, string workPlace)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs, System.Text.Encoding.Default);
                //记录每次读取的一行记录
                string strLine = "";
                //记录每行记录中的各字段内容
                string[] aryLine;
                //标示列数
                int columnCount = 0;
                Boolean first = true;
                //逐行读取CSV中的数据
                while ((strLine = sr.ReadLine()) != null)
                {
                    aryLine = strLine.Split(',');
                    columnCount = aryLine.Length;
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        dic.Add("点位类型", aryLine[1]);
                        dic.Add("X坐标", aryLine[2]);
                        dic.Add("Y坐标", aryLine[3]);
                        dic.Add("Z坐标", aryLine[4]);
                        if (workPlace == "左工位")
                        {
                            leftPointDic.Add(aryLine[0], dic);
                        }
                        else if (workPlace == "右工位")
                        {
                            rightPointDic.Add(aryLine[0], dic);
                        }
                        else if (workPlace == "单工位")
                        {
                            pointDic.Add(aryLine[0], dic);
                        }
                        else if(workPlace=="点检左")
                        {
                            DJLeftCCDHightPointDic.Add(aryLine[0], dic);
                        }
                        else if (workPlace == "点检右")
                        {
                            DJRightCCDHightPointDic.Add(aryLine[0], dic);
                        }
                    }
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                //throw e;
            }
        }
    }
}

