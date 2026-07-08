using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public partial class 数据库 : Form
    {
   
        public 数据库()
        {
            InitializeComponent();
        }
        string strNameSN = "";
        private void 获取_Click(object sender, EventArgs e)
        {
            string str2 = "SELECT * FROM";
            str2 = str2 + " "+ str_.Text ;
            List<string> pword = SQLiteConnect._getQuery(str2, "SN");
            dataGridViewSN.Rows.Clear();
            for (int i = 0; i < pword.Count; i++)
            {

                dataGridViewSN.Rows.Add(pword[i]);
                dataGridViewSN.Rows[i].Cells[0].Value = pword[i];
            }
        }

        private void 删除_Click(object sender, EventArgs e)
        {
            string str2 = "SELECT * FROM";
            str2 = str2 + " " + str_.Text;
            List<string> pword = SQLiteConnect._getQuery(str2, "SN");
            dataGridViewSN.Rows.Clear();

            for (int i = 0; i < pword.Count; i++)
            {
                if (strNameSN != "" && pword[i] == strNameSN)
                {
                    pword.RemoveAt(i);
                    //删除
                    SQLiteConnect.executeSQL("DELETE FROM " + str_.Text + " WHERE SN = '"+strNameSN+"'");
                }
            }
            pword = SQLiteConnect._getQuery(str2, "SN");
            dataGridViewSN.Rows.Clear();
            for (int i = 0; i < pword.Count; i++)
            {

                dataGridViewSN.Rows.Add(pword[i]);
                dataGridViewSN.Rows[i].Cells[0].Value = pword[i];
            }           
        }

        private void dataGridViewSN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            strNameSN = dataGridViewSN.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void 手动过站_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewSN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            strNameSN = dataGridViewSN.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
