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
    public partial class IoChangeName : Form
    {
        public IoChangeName()
        {
            InitializeComponent();
        }

        private void IoChangeName_Load(object sender, EventArgs e)
        {
            if (Program.iODoc.m_InputDataList != null && Program.iODoc.m_InputDataList.Count > 0)
            {
                dataGridViewInput.DataSource = Program.iODoc.m_InputDataList;
                
            }

            if (Program.iODoc.m_OutputDataList != null && Program.iODoc.m_OutputDataList.Count > 0)
            {
                dataGridViewOutput.DataSource = Program.iODoc.m_OutputDataList;
            }
        }

        private void dataGridViewInput_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
              Program.iODoc.m_InputDictionary = Program.iODoc.m_InputDataList.ToDictionary(p => p.strIOName);
              Program.iODoc.m_OutputDictionary = Program.iODoc.m_OutputDataList.ToDictionary(p => p.strIOName);
            }
            catch
            {
            }
           
        }
    }
}
