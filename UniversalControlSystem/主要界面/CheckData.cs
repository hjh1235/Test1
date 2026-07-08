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
    public partial class CheckData : Form
    {
        public CheckData()
        {
            InitializeComponent();
        }

        private void CheckData_Load(object sender, EventArgs e)
        {
         
            if (Hard_Ward_Contral._DateGroupParameter._DateGroup_List.Count != 0 )
            {
                dataGridViewCheckData.DataSource = Hard_Ward_Contral._DateGroupParameter._DateGroup_List;
                dataGridViewCheckData.Update();
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //for (int i = 0; i < Hard_Ward_Contral._DateGroupParameter._DateGroup_List.Count; i++)
            //{
                //dataGridViewCheckData.Rows[i].Cells[3].Value = Hard_Ward_Contral._DateGroupParameter._DateGroup_List[i].Date;
                //dataGridViewCheckData.Update();
                dataGridViewCheckData.DataSource = Hard_Ward_Contral._DateGroupParameter._DateGroup_List;
                dataGridViewCheckData.Refresh();
           // }

        }
    }
}
