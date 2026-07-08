using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{

    public partial class FormHardSetting : Form
    {
       // public static IOHardwareDoc m_IOHardwareDoc;
      ///  public List<ExIOSetting> exIOSettings;
      ///  public ExIOSetting exIOSetting;
        public FormHardSetting()
        {
            InitializeComponent();
            //  m_IOHardwareDoc = new IOHardwareDoc();
            //  exIOSettings = new List<ExIOSetting>();
        

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
           // m_IOHardwareDoc = MainForm.pIOHardwareDoc;
            if (textBoxHardWareName.Text == "")
            {
                return;
            }
            try
            {
                if (textBoxHardWareName.Text == "")
                {
                    MessageBox.Show("请输入扩展模块名！", "添加失败");
                    return;
                }
                GoogolTechExtCardInfo demoInfo = new GoogolTechExtCardInfo();
                demoInfo.hardwareName = textBoxHardWareName.Text;
                demoInfo.hardwareVender = "Vender";
                demoInfo.hardwareTpye = "Tpye";
       
                Program.hardwareDoc.m_HardWareList.Add(demoInfo);
                Program.hardwareDoc.m_HardWareDictionary.Add(demoInfo.hardwareName, demoInfo);
                ListViewItem lvi = listViewNFHardWare.Items.Add(demoInfo.hardwareName);
                lvi.SubItems.Add(demoInfo.hardwareVender.ToString());
                lvi.SubItems.Add(demoInfo.hardwareTpye.ToString());

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormHardSetting_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (GoogolTechExtCardInfo item in HardwareManage.hardDoc.m_HardWareList)
                {
                    ListViewItem lvi = listViewNFHardWare.Items.Add(item.hardwareName);
                    lvi.SubItems.Add(item.ToString());
                    lvi.SubItems.Add(item.hardwareTpye.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewNFHardWare.SelectedItems.Count > 0)
            {
                Program.hardwareDoc.m_HardWareDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                Program.hardwareDoc.m_HardWareList.RemoveAt(listViewNFHardWare.SelectedItems[0].Index);
                //HardwareManage.hardDoc.m_HardWareDictionary.Remove(listViewNFHardWare.SelectedItems[0].Text);
                //HardwareManage.hardDoc.m_HardWareList.RemoveAt(listViewNFHardWare.SelectedItems[0].Index);
                listViewNFHardWare.SelectedItems[0].Remove();
                if (panel1.Controls.Count > 0)
                {
                    panel1.Controls.RemoveAt(0);
                }
            }
        }

        private void listViewIOCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listViewNFHardWare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewNFHardWare.SelectedItems.Count > 0)
            {
                HardWareInfoBase hwInfoB = HardwareManage.hardDoc.m_HardWareDictionary[listViewNFHardWare.Items[listViewNFHardWare.SelectedItems[0].Index].Text];
                hwInfoB.ShowSettingForm(panel1);
            }
        }
    }
}
