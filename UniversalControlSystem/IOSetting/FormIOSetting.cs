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
    public partial class FormIOSetting : Form
    {
        public FormIOSetting()
        {
            InitializeComponent();
        }
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }
        public List<IOCardSta_InPut> m_Hard_IOInPut_List = new List<IOCardSta_InPut>();
        public List<IOCardSta_OutPut> m_Hard_IOOutPut_List =new List<IOCardSta_OutPut> ();
        /// <summary>
        /// 界面显示
        /// </summary>
        public void ShowFromMessage()
        {
            m_Hard_IOInPut_List.Clear();
            m_Hard_IOOutPut_List.Clear();
            try
            {
                foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List)
                {
                    string[] sdsd = item.hardIOName.Split('_');
                        if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[hardwareName].hardwareName == item.hard_IO_Name)
                        {
                        IOCardSta_InPut IOCardSta_InPut = new IOCardSta_InPut();
                        IOCardSta_InPut.hardIOName = item.hardIOName;
                        IOCardSta_InPut.iBitNo= item.iBitNo;
                        IOCardSta_InPut.iCardNo = item.iCardNo;
                        IOCardSta_InPut.iExtNo = item.iExtNo;
                        IOCardSta_InPut.hard_IO_Name = item.hard_IO_Name;
                        IOCardSta_InPut.bignore = item.bignore;
                        m_Hard_IOInPut_List.Add(IOCardSta_InPut);
                    }
                }
               // dataGridViewInput.DataSource = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_List;
            }
            catch (Exception E)
            {

         
            }
            try
            {
                // dataGridViewOutput.DataSource = Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List;
                foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_List)
                {

                    string[] sdsd = item.hardIOName.Split('_');
                    if (Hard_Ward_Contral.hardDoc.m_HardWareDictionary[hardwareName].hardwareName == item.hard_IO_Name )
                    {
                        IOCardSta_OutPut IOCardSta_OutPut = new IOCardSta_OutPut();
                        IOCardSta_OutPut.hardIOName = item.hardIOName;
                        IOCardSta_OutPut.iBitNo = item.iBitNo;
                        IOCardSta_OutPut.iCardNo = item.iCardNo;
                        IOCardSta_OutPut.iExtNo = item.iExtNo;
                        IOCardSta_OutPut.hard_IO_Name = item.hard_IO_Name;
                        IOCardSta_OutPut.bignore = item.bignore;
                        m_Hard_IOOutPut_List.Add(IOCardSta_OutPut);
                    }
                }
            }
            catch (Exception R)
            {

                throw;
            }

            if (m_Hard_IOInPut_List.Count!=0&& m_Hard_IOOutPut_List.Count != 0)
            {
                dataGridViewInput.DataSource = m_Hard_IOInPut_List;
                dataGridViewOutput.DataSource = m_Hard_IOOutPut_List;
            }
            initDgv(dataGridViewInput);
            initDgv(dataGridViewOutput);
        }
        private void FormAxisSetting_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 初始化DataGridView的方法
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        private void initDgv(DataGridView dgv)
        {
            //dgv.Columns.Clear();
            dgv.Columns[0].HeaderText = "IO名称";
            dgv.Columns[1].HeaderText = "屏蔽";
            dgv.Columns[2].HeaderText = "卡名";
            dgv.Columns[3].HeaderText = "控制卡";
            dgv.Columns[4].HeaderText = "IO卡号";
            dgv.Columns[5].HeaderText = "点位编号";
            dgv.Columns[6].HeaderText = "IO状态";
            for (byte i = 0; i < dgv.Columns.Count; i++)
            {
                if (i == 0)
                {
                    dgv.Columns[i].Width = 110;
                }
                else if(i == 2)
                {
                    dgv.Columns[i].Width = 70;
                }
                else
                {
                    dgv.Columns[i].Width = 50;
                }
                //if(i == 5)
                //{
                //    dgv.ReadOnly = false;
                //}
                //else
                //{
                    dgv.ReadOnly = true;
                //}
                //dgv.Columns[i].SortMode = 0;
            }
            for (byte i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Height = 30;
            }
            dgv.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvData.RowsDefaultCellStyle
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
