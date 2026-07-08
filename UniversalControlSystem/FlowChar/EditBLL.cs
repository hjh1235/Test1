
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace UniversalControlSystem
{
    public class EditBLL
    {
        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        public static void UpEdit(ListView listView, List<ImageTool> tool)
        { EditDAL.UpEdit(listView, tool); }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        public static void DownEdit(ListView listView, List<ImageTool> tool)
        { EditDAL.DownEdit(listView, tool); }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        public static void RemoveAt(ListView listView, List<ImageTool> tool)
        { EditDAL.RemoveAt(listView, tool); }

        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool">工具表</param>
        public static void Clear(ListView listView, List<ImageTool> tool)
        { EditDAL.Clear(listView, tool); }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool">工具表</param>
        /// <param name="it">工具</param>
        /// <param name="str">工具名</param>
        public static void Add(List<ImageTool> tool, ImageTool it, string[] str)
        {
            EditDAL.Add(tool, it, str);
        }
        /// <summary>
        /// 指定位置插入工具
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        /// <param name="it"></param>
        /// <param name="str"></param>
        /// <param name="hwin"></param>
        public static void Insert(DataGridView dgv_Items, List<ImageTool> tool, ImageTool it, string[] str)
        {
            EditDAL.Insert(dgv_Items, tool, it, str);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool">工具表</param>
        /// <param name="it">工具</param>
        /// <param name="str">工具名</param>
        //public static void Add(ListView listView, List<ImageTool> tool, ImageTool it, string[] str)
        //{
        //    EditDAL.Add(listView, tool, it, str);
        //}
        /// <summary>
        /// 指定位置插入工具
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        /// <param name="it"></param>
        /// <param name="str"></param>
        /// <param name="hwin"></param>
        //public static void Insert(ListView listView, List<ImageTool> tool, ImageTool it, string[] str)
        //{
        //    EditDAL.Insert(listView, tool, it, str);
        //}



        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool">工具表</param>
        public static void UpEdit(ListBox listbox, List<ImageTool> tool)
        { EditDAL.UpEdit(listbox, tool); }
        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool">工具表</param>
        public static void DownEdit(ListBox listbox, List<ImageTool> tool)
        { EditDAL.DownEdit(listbox, tool); }
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool">工具表</param>
        public static void RemoveAt(ListBox listbox, List<ImageTool> tool)
        { EditDAL.RemoveAt(listbox, tool); }
        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool">工具表</param>
        public static void Clear(ListBox listbox, List<ImageTool> tool)
        { EditDAL.Clear(listbox, tool); }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool">工具表</param>
        /// <param name="it">工具</param>
        /// <param name="str">工具名</param>
        public static void Add(ListBox listbox, List<ImageTool> tool, ImageTool it, string str)
        {
            EditDAL.Add(listbox, tool, it, str);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool">工具表</param>
        /// <param name="it">工具</param>
        /// <param name="str">工具名</param>
        //public static void Add(ListBox listbox, List<ImageTool> tool, ImageTool it, string str)
        //{
        //    EditDAL.Add(listbox, tool, it, str);
        //}
        /// <summary>
        /// 指定位置插入工具
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        /// <param name="it"></param>
        /// <param name="str"></param>
        /// <param name="hwin"></param>
        public static void Insert(ListBox listbox, List<ImageTool> tool, ImageTool it, string str)
        {
            EditDAL.Insert(listbox, tool, it, str);
        }
        /// <summary>
        /// 插入工具
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool"></param>
        /// <param name="it"></param>
        /// <param name="str"></param>
        /// <param name="hwin"></param>
        //public static void Insert(ListBox listbox, List<ImageTool> tool, ImageTool it, string str)
        //{
        //    EditDAL.Insert(listbox, tool, it, str);
        //}
    }


    public class EditDAL
    {
        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        public static void UpEdit(ListView listView, List<ImageTool> tool)
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

                        ImageTool tmepset = tool[indexSelectedItem];
                        ImageTool set1 = tool[indexSelectedItem - 1];
                        ImageTool set2 = tmepset;
                        tool[indexSelectedItem] = set1;
                        tool[indexSelectedItem - 1] = set2;
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
        public static void DownEdit(ListView listView, List<ImageTool> tool)
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

                        ImageTool tmepset = tool[indexSelectedItem];
                        ImageTool set1 = tool[indexSelectedItem + 1];
                        ImageTool set2 = tmepset;
                        tool[indexSelectedItem] = set1;
                        tool[indexSelectedItem + 1] = set2;
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
        /// 指定位置插入工具
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        /// <param name="it"></param>
        /// <param name="str"></param>
        /// <param name="hwin"></param>
        public static void Insert(DataGridView dgv_Items, List<ImageTool> tool, ImageTool it, string[] str)
        {
            try
            {
                int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                tool.Insert(indexSelectedItem, it);
            }
            catch (Exception ex)
            {

            }
              
        }
        /// <summary>
        /// 添加工具
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        /// <param name="it"></param>
        /// <param name="str"></param>
        /// <param name="hwin"></param>
        public static void Add(List<ImageTool> tool, ImageTool it, string[] str)
        {

            it.ini();  //初始化

            tool.Add(it);
            //ListViewItem item = listView.Items.Add(str[0]);//编号
            //item.SubItems.Add(str[1]);//工具
            //item.SubItems.Add(str[2]);//工具描述
            //item.SubItems.Add(str[3]);//结果
            //item.SubItems.Add(str[4]);//耗时
            //listView.EndUpdate();
        }
        /// <summary>
        /// 指定位置插入工具
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        /// <param name="it"></param>
        /// <param name="str"></param>
        /// <param name="hwin"></param>
        //public static void Insert(ListView listView, List<ImageTool> tool, ImageTool it, string[] str)
        //{
        //    if (listView.SelectedItems.Count == 0) return;
        //    listView.BeginUpdate();
        //    foreach (ListViewItem lvItem in listView.SelectedItems)
        //    {
        //        int indexSelectedItem = lvItem.Index;

        //        tool.Insert(indexSelectedItem, it);
        //        if (listView.FocusedItem != null)//这个if必须的，不然会得到值但会报错
        //        {
        //            ListViewItem item = new ListViewItem(str[0]);//编号
        //            item.SubItems.Add(str[1]);//工具
        //            item.SubItems.Add(str[2]);//工具描述
        //            item.SubItems.Add(str[3]);//结果
        //            item.SubItems.Add(str[4]);//耗时
        //            listView.Items.Insert(indexSelectedItem, item);
        //        }
        //    }
        //    listView.EndUpdate();
        //}
        /// <summary>
        /// 添加工具
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        /// <param name="it"></param>
        /// <param name="str"></param>
        /// <param name="hwin"></param>
        //public static void Add(ListView listView, List<ImageTool> tool, ImageTool it, string[] str)
        //{
        //    listView.BeginUpdate();
        //    it.ini();  //初始化

        //    tool.Add(it);
        //    ListViewItem item = listView.Items.Add(str[0]);//编号
        //    item.SubItems.Add(str[1]);//工具
        //    item.SubItems.Add(str[2]);//工具描述
        //    item.SubItems.Add(str[3]);//结果
        //    item.SubItems.Add(str[4]);//耗时
        //    listView.EndUpdate();
        //}
        /// <summary>
        /// 移除当前项工具
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="tool"></param>
        public static void RemoveAt(ListView listView, List<ImageTool> tool)
        {
            if (listView.SelectedItems.Count == 0) return;
            listView.BeginUpdate();
            foreach (ListViewItem lvItem in listView.SelectedItems)
            {
                int indexSelectedItem = lvItem.Index;
                tool.RemoveAt(indexSelectedItem);
                listView.Items.RemoveAt(indexSelectedItem);
            }
            listView.EndUpdate();
        }
        /// <summary>
        /// 清除工具
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool"></param>
        public static void Clear(ListView listView, List<ImageTool> tool)
        {
            tool.Clear();
            listView.Items.Clear();
        }

        /// <summary>
        /// 上移工具
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool"></param>
        public static void UpEdit(ListBox listbox, List<ImageTool> tool)
        {
            if (listbox.SelectedIndex != -1 && listbox.SelectedIndex != 0)
            {
                object lboxtmep = listbox.Items[listbox.SelectedIndex];
                object lbox1 = listbox.Items[listbox.SelectedIndex - 1]; ;
                object lbox2 = lboxtmep;
                listbox.Items[listbox.SelectedIndex] = lbox1;
                listbox.Items[listbox.SelectedIndex - 1] = lbox2;
                ImageTool tmepset = tool[listbox.SelectedIndex];
                ImageTool set1 = tool[listbox.SelectedIndex - 1];
                ImageTool set2 = tmepset;
                tool[listbox.SelectedIndex] = set1;
                tool[listbox.SelectedIndex - 1] = set2;
                listbox.SelectedIndex = listbox.SelectedIndex - 1;
            }
            else
            {
                MessageBox.Show("当前是第一个项");
            }
        }
        /// <summary>
        /// 下移工具
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool"></param>
        public static void DownEdit(ListBox listbox, List<ImageTool> tool)
        {
            if (listbox.SelectedIndex != -1 && listbox.SelectedIndex < listbox.Items.Count - 1)
            {
                object lboxtmep = listbox.Items[listbox.SelectedIndex];
                object lbox1 = listbox.Items[listbox.SelectedIndex + 1]; ;
                object lbox2 = lboxtmep;
                listbox.Items[listbox.SelectedIndex] = lbox1;
                listbox.Items[listbox.SelectedIndex + 1] = lbox2;
                ImageTool tmepset = tool[listbox.SelectedIndex];
                ImageTool set1 = tool[listbox.SelectedIndex + 1];
                ImageTool set2 = tmepset;
                tool[listbox.SelectedIndex] = set1;
                tool[listbox.SelectedIndex + 1] = set2;
                listbox.SelectedIndex = listbox.SelectedIndex + 1;
            }
            else
            {
                MessageBox.Show("当前是最后一项");
            }
        }
        /// <summary>
        /// 添加工具
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool"></param>
        /// <param name="it"></param>
        public static void Add(ListBox listbox, List<ImageTool> tool, ImageTool it, string str)
        {
            it.ini();  //初始化

            tool.Add(it);
            listbox.Items.Add(str);
            if (listbox.Items.Count > 200)
                listbox.Items.RemoveAt(0);
            if (listbox.Items.Count > 0)
                listbox.SelectedIndex = listbox.Items.Count - 1;
        }
        /// <summary>
        /// 添加工具
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool"></param>
        /// <param name="it"></param>
        //public static void Add(ListBox listbox, List<ImageTool> tool, ImageTool it, string str)
        //{
        //    it.ini();  //初始化

        //    tool.Add(it);
        //    listbox.Items.Add(str);
        //    if (listbox.Items.Count > 200)
        //        listbox.Items.RemoveAt(0);
        //    if (listbox.Items.Count > 0)
        //        listbox.SelectedIndex = listbox.Items.Count - 1;
        //}
        /// <summary>
        /// 移除当前项工具
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool"></param>
        public static void RemoveAt(ListBox listbox, List<ImageTool> tool)
        {
            if (listbox.SelectedIndex != -1)
            {
                tool.RemoveAt(listbox.SelectedIndex);
                listbox.Items.RemoveAt(listbox.SelectedIndex);
            }
        }
        /// <summary>
        /// 插入工具
        /// </summary>
        public static void Insert(ListBox listbox, List<ImageTool> tool, ImageTool it, string str)
        {
            if (listbox.SelectedIndex != -1)
            {

                tool.Insert(listbox.SelectedIndex, it);
                listbox.Items.Insert(listbox.SelectedIndex, str);
            }
        }
        /// <summary>
        /// 插入工具
        /// </summary>
        //public static void Insert(ListBox listbox, List<ImageTool> tool, ImageTool it, string str)
        //{
        //    if (listbox.SelectedIndex != -1)
        //    {

        //        tool.Insert(listbox.SelectedIndex, it);
        //        listbox.Items.Insert(listbox.SelectedIndex, str);
        //    }
        //}
        /// <summary>
        /// 清除工具
        /// </summary>
        /// <param name="listbox"></param>
        /// <param name="tool"></param>
        public static void Clear(ListBox listbox, List<ImageTool> tool)
        {
            tool.Clear();
            listbox.Items.Clear();
        }
    }


}
