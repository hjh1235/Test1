using Microsoft.VisualBasic;
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
using UniversalControlSystem.PLC;
using UniversalControlSystem.PLC.PLC_Class_Ctr;

namespace UniversalControlSystem
{
    public enum PLCDataType
    {
        Bool,
        Byte,
        Short,
        UShort,
        Int,
        UInt,
        Long,
        ULong,
        Float,
        Double,
        String
    }
    public partial class PLC_Setting : Form
    {
        //public Siemens siemens = new Siemens();
     
       
        private bool rt = false;
        private string result = null;
        PLCDataType dataType = new PLCDataType();
        private Dictionary<string, string> dicByteLenght = new Dictionary<string, string>();
        int intSelectedItemIndex = -1;
        int intSelectedItemIndex2 = -1;
        public PLC_Setting()
        {
            InitializeComponent();
           // hardInfo = Info;
        }
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }

        public void ShowFromMessage()
        {
            label1.Text = hardwareName;
            try
            {
                txtPLCAddress.Text = Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[label1.Text].PLC_ControlAddress;
                txtPLCPort.Text = Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[label1.Text].PLC_ControlProt;
                txtPLCRack.Text = Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[label1.Text].PLC_ControlRack;
                txtPLCSlot.Text = Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[label1.Text].PLC_ControlSlot;
                foreach(var item in Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[hardwareName].PlcReadData)
                {
                    AddListview(item.Address, item.Name, item.type.ToString());
                }
                foreach (var item in Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[hardwareName].PlcWriteData)
                {
                    AddListviewWrite(item.Address, item.Name, item.type.ToString(),item.data);
                }
            }
            catch (Exception error)
            {
                 return;
            }

        }
        private void FormAxisSetting_Load(object sender, EventArgs e)
        {
            initlistview();
            foreach(var item in Enum.GetValues(typeof(PLCDataType)))
            {
                cmbAddType.Items.Add(item.ToString());
                cmbAddWriteType.Items.Add(item.ToString());
            }
            if (cmbAddType.Items.Count != 0)
                cmbAddType.SelectedIndex = 0;
            if (cmbAddWriteType.Items.Count != 0)
                cmbAddWriteType.SelectedIndex = 0;
        }
        //连接
        private void btnPLCConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if(PLCCommunicationFun.PLCControlFuntion.Count != Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary.Count)
                {
                    PLCCommunicationFun.InitPLC();
                }
                if (Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[label1.Text].State)
                {
                    btnPLCClose.Enabled = true;
                    btnPLCConnection.Enabled = false;
                    ThreadPool.QueueUserWorkItem(state => scanf());
                }
                else
                {
                    bool rt = PLCCommunicationFun.Connect(hardwareName);
                    if (rt)
                    {
                        btnPLCClose.Enabled = true;
                        btnPLCConnection.Enabled = false;
                        //timer1.Enabled = true;
                        ThreadPool.QueueUserWorkItem(state =>scanf());

                    }
                    else
                        MessageBox.Show(ERecvResult.连接失败.ToString());
                }
                
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }
        //断开连接
        private void btnPLCClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[label1.Text].State)
                {
                    bool rt = PLCCommunicationFun.Close(hardwareName);
                    if (rt)
                    {
                        btnPLCConnection.Enabled = true;
                    }

                }
                
            }
            catch
            {

            }
            
        }

        private void button_read_bool_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            string type = bt.Name;
            switch (type)
            {
                case "button_read_bool":
                    dataType = PLCDataType.Bool;
                    break;
                case "button_read_byte":
                    dataType = PLCDataType.Byte;
                    break;
                case "button_read_short":
                    dataType = PLCDataType.Short;
                    break;
                case "button_read_ushort":
                    dataType = PLCDataType.UShort;
                    break;
                case "button_read_int":
                    dataType = PLCDataType.Int;
                    break;
                case "button_read_uint":
                    dataType = PLCDataType.UInt;
                    break;
                case "button_read_long":
                    dataType = PLCDataType.Long;
                    break;
                case "button_read_ulong":
                    dataType = PLCDataType.ULong;
                    break;
                case "button_read_float":
                    dataType = PLCDataType.Float;
                    break;
                case "button_read_double":
                    dataType = PLCDataType.Double;
                    break;
                case "button_read_string":
                    dataType = PLCDataType.String;
                    break;
            }
             //rt = siemens.Read(txtReadAddress.Text, dataType, out result);
            rt = PLCCommunicationFun.Read(hardwareName, txtReadAddress.Text, dataType, out result);
            if (!rt)
                MessageBox.Show(ERecvResult.读取失败.ToString());
            txtReadData.Text = result;
        }

        private void btnWriteBool_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            PLCDataType dataType = new PLCDataType();
            string type = bt.Name;
            switch (type)
            {
                case "btnWriteBool":
                    dataType = PLCDataType.Bool;
                    break;
                case "btnWriteByte":
                    dataType = PLCDataType.Byte;
                    break;
                case "btnWriteShort":
                    dataType = PLCDataType.Short;
                    break;
                case "btnWriteUShort":
                    dataType = PLCDataType.UShort;
                    break;
                case "btnWriteInt":
                    dataType = PLCDataType.Int;
                    break;
                case "btnWriteUInt":
                    dataType = PLCDataType.UInt;
                    break;
                case "btnWriteLong":
                    dataType = PLCDataType.Long;
                    break;
                case "btnWriteULong":
                    dataType = PLCDataType.ULong;
                    break;
                case "btnWriteFloat":
                    dataType = PLCDataType.Float;
                    break;
                case "btnWriteDouble":
                    dataType = PLCDataType.Double;
                    break;
                case "btnWriteString":
                    dataType = PLCDataType.String;
                    break;
            }
            //rt = siemens.Write(txtWriteAddress.Text, dataType,txtWriteData.Text );
            rt = PLCCommunicationFun.Write(hardwareName, txtWriteAddress.Text, dataType, txtWriteData.Text);
            if (!rt)
                MessageBox.Show(ERecvResult.写入失败.ToString());

        }

        private void txtPLCAddress_Leave(object sender, EventArgs e)
        {
            Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[label1.Text].PLC_ControlAddress = txtPLCAddress.Text;
        }

        private void txtPLCPort_Leave(object sender, EventArgs e)
        {
            Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[label1.Text].PLC_ControlProt = txtPLCPort.Text;
        }

        private void txtPLCRack_Leave(object sender, EventArgs e)
        {
            Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[label1.Text].PLC_ControlRack = txtPLCRack.Text;
        }

        private void txtPLCSlot_Leave(object sender, EventArgs e)
        {
            Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[label1.Text].PLC_ControlSlot = txtPLCSlot.Text;
        }
        //添加
        private void btnAddReadData_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAddType.Text == PLCDataType.Byte.ToString())
                {
                    dicByteLenght.Add(txtAddAddress.Text, txtByteLength.Text);
                    for (int i = 0; i < int.Parse(txtByteLength.Text); i++)
                    {
                        AddListview(txtAddAddress.Text + "." + i.ToString(), txtAddName.Text, cmbAddType.Text);
                    }
                }
                else
                {
                    AddListview(txtAddAddress.Text, txtAddName.Text, cmbAddType.Text);
                }
            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void AddListview(string _Address, string _Name, string _Type)
        {
            try
            {
                //ListViewItem item = new ListViewItem();
                //item.SubItems[0].Text = string.Format("{0}", _Address);
                //item.SubItems.Add(new ListViewItem.ListViewSubItem());
                //item.SubItems[1].Text = string.Format("{0}", _Name);
                //item.SubItems.Add(new ListViewItem.ListViewSubItem());
                //item.SubItems[2].Text = string.Format("{0}", _Type);
                //item.SubItems.Add(new ListViewItem.ListViewSubItem());
                //listview.Items.Add(item);
            }
            catch (Exception error)
            {
                MainForm.m_formAlarm.InsertAlarmMessage(error.Message);
            }
        }
        private void AddListviewWrite(string _Address, string _Name, string _Type,string _Data = null)
        {
            try
            {
                //ListViewItem item = new ListViewItem();
                //item.SubItems[0].Text = string.Format("{0}", _Address);
                //item.SubItems.Add(new ListViewItem.ListViewSubItem());
                //item.SubItems[1].Text = string.Format("{0}", _Name);
                //item.SubItems.Add(new ListViewItem.ListViewSubItem());
                //item.SubItems[2].Text = string.Format("{0}", _Type);
                //item.SubItems.Add(new ListViewItem.ListViewSubItem());
                //item.SubItems[3].Text = string.Format("{0}", _Data);
                //item.SubItems.Add(new ListViewItem.ListViewSubItem());
                //listviewWrite.Items.Add(item);
            }
            catch (Exception error)
            {
                MainForm.m_formAlarm.InsertAlarmMessage(error.Message);
            }
        }

        private void PLCDataReadTime_Tick(object sender, EventArgs e)
        {

        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //string str = Interaction.InputBox("输入名称", "重命名", listview.Items[intSelectedItemIndex].SubItems[1].Text, -1, -1);
                //if (str == "")
                //    return;
                //foreach(ListViewItem item in listview.Items)
                //{
                //    if (str == item.SubItems[1].Text)
                //        return;
                //}
                //listview.Items[intSelectedItemIndex].SubItems[1].Text = string.Format("{0}", str);
            }
            catch (Exception error)
            {
                
            }
        }
        private void 重命名ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                //string str = Interaction.InputBox("输入名称", "重命名", listviewWrite.Items[intSelectedItemIndex2].SubItems[1].Text, -1, -1);
                //if (str == "")
                //    return;
                //foreach (ListViewItem item in listviewWrite.Items)
                //{
                //    if (str == item.SubItems[1].Text)
                //        return;
                //}
                //listviewWrite.Items[intSelectedItemIndex2].SubItems[1].Text = string.Format("{0}", str);
            }
            catch (Exception error)
            {
            }
        }

        private void 更改值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //string str = Interaction.InputBox("输入数据", "更改数据", listviewWrite.Items[intSelectedItemIndex2].SubItems[3].Text, -1, -1);
                //if (str == "")
                //    return;
                //listviewWrite.Items[intSelectedItemIndex2].SubItems[3].Text = string.Format("{0}", str);
            }
            catch (Exception error)
            {
                
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.listview.SelectedItems.Count != 1)
            //{
            //    return;
            //}
            //intSelectedItemIndex = listview.SelectedItems[0].Index;
        }
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.listviewWrite.SelectedItems.Count != 1)
            //{
            //    return;
            //}
            //intSelectedItemIndex2 = listviewWrite.SelectedItems[0].Index;
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    //listview.ContextMenuStrip = null;
                    //contextMenuStrip1.Show(listview, e.Location);
                }
            }
            catch (Exception error)
            {
                MainForm.m_formAlarm.InsertAlarmMessage(error.Message);
            }
        }
        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    //listviewWrite.ContextMenuStrip = null;
                    //contextMenuStrip2.Show(listviewWrite, e.Location);
                }
            }
            catch (Exception error)
            {
                MainForm.m_formAlarm.InsertAlarmMessage(error.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    List<string> list = new List<string>();
            //    SelectByteLeng();
            //    foreach (ListViewItem item in listview.Items)
            //    {
            //        list.Add(item.SubItems[1].Text);
            //    }
            //    int count = list.GroupBy(i => i).Where(g => g.Count() > 1).Count();
            //    if (count > 0)
            //    {
            //        MessageBox.Show("有重复得名称！");
            //        return;
            //    }
            //    Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[hardwareName].PlcReadData.Clear();
            //    foreach (ListViewItem item in listview.Items)
            //    {
            //        PLCData data = new PLCData();
            //        data.Address = item.SubItems[0].Text.ToString();
            //        data.Name = item.SubItems[1].Text.ToString();
            //        data.type = (PLCDataType)Enum.Parse(typeof(PLCDataType), item.SubItems[2].Text.ToString(), true);
            //        if (data.type == PLCDataType.Byte)
            //        {
            //            data.Lenght = dicByteLenght[data.Address.Split('.')[0]];
            //        }
            //        Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[hardwareName].PlcReadData.Add(data);
            //    }
            //    Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[hardwareName].dicPlcReadData =
            //        Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[hardwareName].PlcReadData.ToDictionary(keys => keys.Name);

            //}
            //catch (Exception error)
            //{
            //    MessageBox.Show(error.Message);
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //foreach(ListViewItem item in listview.Items)
            //{
            //    foreach(var dicitem in Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[hardwareName].dicPlcReadData)
            //    {
            //        if (item.SubItems[1].Text == dicitem.Value.Name)
            //            item.SubItems[3].Text = dicitem.Value.data;
            //    }
            //}
            txtReadData.Text = Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[hardwareName].dicPlcReadData["心跳"].data;
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        
        #region 事件：初始化Listview创建控件
        /// <summary>
        /// 创建控件Listview
        /// </summary>
        private void initlistview()
        {
            try
            {
                ////创建读取显示列表
                //listview.Font = new System.Drawing.Font("宋体", 8F,
                //System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                //listview.FullRowSelect = true;
                //listview.HideSelection = false;
                //listview.Location = new System.Drawing.Point(0, 0);
                //listview.Name = "listview";
                //listview.UseCompatibleStateImageBehavior = false;
                //listview.View = System.Windows.Forms.View.Details;
                //listview.GridLines = true;
                //panel1.Controls.Add(this.listview);

                //listview.Dock = DockStyle.Fill;
                //listview.Columns.Add("PLC地址", 60, System.Windows.Forms.HorizontalAlignment.Left);
                //listview.Columns.Add("点位名称", 100, System.Windows.Forms.HorizontalAlignment.Left);
                //listview.Columns.Add("类型", 60, System.Windows.Forms.HorizontalAlignment.Left);
                //listview.Columns.Add("数据", 120, System.Windows.Forms.HorizontalAlignment.Left);
             
                //this.listview.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);             
                //this.listview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);

                ////创建写入显示列表
                //listviewWrite.Font = new System.Drawing.Font("宋体", 8F,
                //System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                //listviewWrite.FullRowSelect = true;
                //listviewWrite.HideSelection = false;
                //listviewWrite.Location = new System.Drawing.Point(0, 0);
                //listviewWrite.Name = "listview";
                //listviewWrite.UseCompatibleStateImageBehavior = false;
                //listviewWrite.View = System.Windows.Forms.View.Details;
                //listviewWrite.GridLines = true;
                //panel2.Controls.Add(this.listviewWrite);

                //listviewWrite.Dock = DockStyle.Fill;
                //listviewWrite.Columns.Add("PLC地址", 60, System.Windows.Forms.HorizontalAlignment.Left);
                //listviewWrite.Columns.Add("点位名称", 100, System.Windows.Forms.HorizontalAlignment.Left);
                //listviewWrite.Columns.Add("类型", 60, System.Windows.Forms.HorizontalAlignment.Left);
                //listviewWrite.Columns.Add("数据", 120, System.Windows.Forms.HorizontalAlignment.Left);

                //this.listviewWrite.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
                //this.listviewWrite.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseClick);
            }
            catch (Exception error)
            {
                MainForm.m_formAlarm.InsertAlarmMessage(error.Message);
            }


        }

        #endregion

        private void btnAddWrite_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAddWriteType.Text == PLCDataType.Byte.ToString())
                {
                    dicByteLenght.Add(txtAddWriteAddress.Text, txtAddWritelenght.Text);
                    for (int i = 0; i < int.Parse(txtAddWritelenght.Text); i++)
                    {
                        AddListviewWrite(txtAddWriteAddress.Text + "." + i.ToString(), txtAddWriteName.Text, cmbAddWriteType.Text,"0");
                    }
                }
                else
                {
                    AddListviewWrite(txtAddWriteAddress.Text, txtAddWriteName.Text, cmbAddWriteType.Text);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnSaveWrite_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    List<string> list = new List<string>();
            //    foreach (ListViewItem item in listviewWrite.Items)
            //    {
            //        list.Add(item.SubItems[1].Text);
            //    }
            //    int count = list.GroupBy(i => i).Where(g => g.Count() > 1).Count();
            //    if (count > 0)
            //    {
            //        MessageBox.Show("有重复得名称！");
            //        return;
            //    }
            //    Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[hardwareName].PlcWriteData.Clear();
            //    foreach (ListViewItem item in listviewWrite.Items)
            //    {
            //        PLCData data = new PLCData();
            //        data.Address = item.SubItems[0].Text.ToString();
            //        data.Name = item.SubItems[1].Text.ToString();
            //        data.type = (PLCDataType)Enum.Parse(typeof(PLCDataType), item.SubItems[2].Text.ToString(), true);
            //        data.data = item.SubItems[3].Text;
            //        Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[hardwareName].PlcWriteData.Add(data);
            //    }
            //    Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[hardwareName].dicWritePlcData =
            //        Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[hardwareName].PlcWriteData.ToDictionary(keys => keys.Name);

            //}
            //catch (Exception error)
            //{
            //    MessageBox.Show(error.Message);
            //}
        }
        
        private void SelectByteLeng()
        {
            //dicByteLenght.Clear();
            //List<string> dicRepeat = new List<string>();
            //List<byte> listByte = new List<byte>();
            //foreach (ListViewItem item in listview.Items)
            //{
            //    if (item.SubItems[2].Text == PLCDataType.Byte.ToString())
            //    {
            //        dicRepeat.Add(item.SubItems[0].Text.Split('.')[0]);
            //    }
            //}
            //var duplicateValues = dicRepeat.GroupBy(x => x).Where(g => g.Count() > 1).Select(y => new { Element = y.Key, Counter = y.Count() }).ToList();
            //foreach (var item in duplicateValues)
            //{
            //    dicByteLenght.Add(item.Element, item.Counter.ToString());
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if(intSelectedItemIndex >= 0)
            //    {
            //        this.listview.Items.RemoveAt(intSelectedItemIndex);
            //    }
                
            //}
            //catch
            //{

            //}
            
        }

        private void btnDeleteWrite_Click(object sender, EventArgs e)
        {
           // this.listviewWrite.Items.RemoveAt(intSelectedItemIndex2);
        }

        private void cmbAddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtByteLength.Enabled = (cmbAddType.Text == PLCDataType.Byte.ToString()) ? true : false;
            txtAddWritelenght.Enabled = (cmbAddWriteType.Text == PLCDataType.Byte.ToString()) ? true : false;
        }
        public void scanf()
        {
            //while(true)
            //{
            //    Thread.Sleep(200);
            //    listview.Invoke(new Action(() =>
            //    {
            //        foreach (ListViewItem item in listview.Items)
            //        {
            //            foreach (var dicitem in Hard_Ward_Contral._PLC_ControlParameter._PLC_ControlData_Dictionary[hardwareName].dicPlcReadData)
            //            {
            //                if (item.SubItems[1].Text == dicitem.Value.Name)
            //                    item.SubItems[3].Text = dicitem.Value.data;
            //            }
            //        }
            //    }));
                
            //}
            
        }
    }
   
}
