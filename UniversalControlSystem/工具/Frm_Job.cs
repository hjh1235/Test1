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
    public partial class Frm_Job : Form
    {
        public Frm_Job()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>


        public static void UpEdit(ListView listView/* ,List<ImageTool> tool*/)
        {
            if (listView.SelectedItems.Count == 0) return;
            listView.BeginUpdate();
            if (listView.SelectedItems[0].Index >= 0)
            {
                foreach (ListViewItem lvItem in listView.SelectedItems)
                {
                    int indexSelectedItem = lvItem.Index;
                    if (indexSelectedItem > 0)//
                    {
                        ListViewItem lvSelectedItem = lvItem;
                        listView.Items.RemoveAt(indexSelectedItem);
                        listView.Items.Insert(indexSelectedItem - 1, lvSelectedItem);

                        //ImageTool tmepset = tool[indexSelectedItem];
                        //ImageTool set1 = tool[indexSelectedItem - 1];
                        //ImageTool set2 = tmepset;
                        //tool[indexSelectedItem] = set1;
                        //tool[indexSelectedItem - 1] = set2;
                    }
                    else { MessageBox.Show("当前是第一个项"); }
                }
            }
            listView.EndUpdate();
            if (listView.Items.Count > 0 && listView.SelectedItems.Count > 0)
            {
                listView.Focus();
                listView.SelectedItems[0].Focused = true;
                listView.SelectedItems[0].EnsureVisible();
            }

        }
        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        public static void DownEdit(ListView listView/*, List<ImageTool> tool*/)
        {
            if (listView.SelectedItems.Count == 0) return;
            listView.BeginUpdate();
            if (listView.SelectedItems[0].Index > 0)
            {
                foreach (ListViewItem lvItem in listView.SelectedItems)
                {
                    int conut = listView.Items.Count;
                    int indexSelectedItem = lvItem.Index;
                    if (conut > indexSelectedItem + 1)//
                    {
                        ListViewItem lvSelectedItem = lvItem;
                        listView.Items.RemoveAt(indexSelectedItem);
                        listView.Items.Insert(indexSelectedItem + 1, lvSelectedItem);

                        //ImageTool tmepset = tool[indexSelectedItem];
                        //ImageTool set1 = tool[indexSelectedItem + 1];
                        //ImageTool set2 = tmepset;
                        //tool[indexSelectedItem] = set1;
                        //tool[indexSelectedItem + 1] = set2;
                    }
                    else { MessageBox.Show("当前是最后一项"); }
                }
            }
            listView.EndUpdate();
            if (listView.Items.Count > 0 && listView.SelectedItems.Count > 0)
            {
                listView.Focus();
                listView.SelectedItems[0].Focused = true;
                listView.SelectedItems[0].EnsureVisible();
            }

        }
        /// <summary>
        /// 移除当前项工具
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        public static void RemoveAt(ListView listView/*, List<ImageTool> tool*/)
        {
            if (listView.SelectedItems.Count == 0) return;
            listView.BeginUpdate();
            foreach (ListViewItem lvItem in listView.SelectedItems)
            {
                int indexSelectedItem = lvItem.Index;
                //tool.RemoveAt(indexSelectedItem);
                listView.Items.RemoveAt(indexSelectedItem);
            }
            listView.EndUpdate();
        }
        /// <summary>
        /// 清除工具
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool"></param>
        public static void Clear(ListView listView/*, List<ImageTool> tool*/)
        {
            //tool.Clear();
            listView.Items.Clear();
        }
        int index = 0;
        private void tsb_createJob_Click(object sender, EventArgs e)
        {
            TabPage Page = new TabPage();
            Page.Name = "Page" + index.ToString();
            Page.Text = "tabPage" + index.ToString();
            Page.TabIndex = index;
            this.tbc_jobs.Controls.Add(Page);
            DataGridView DataGridView = new DataGridView();
            DataGridView.Size = Page.Size;
            Page.Controls.Add(DataGridView);
            DataGridView.Name = Page.Name;

            //DataGridView.Columns.Add(acCode);
            //int   indexs = DataGridView.Rows.Add();
            //DataGridView.Rows[0].Cells[0].Value = "1";
            //DataGridView.Rows[0].Cells[1].Value = "2";
            //DataGridView.Rows[0].Cells[2].Value = "监听";
            index++;
        }
    }
}
