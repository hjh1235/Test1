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
    public partial class SystemSettings : Form
    {
        public SystemSettings()
        {
            InitializeComponent();
        }

        TreeNode selectedNode = new TreeNode();
        FormHardSetting m_formControlHardSetting;
        Aisx_FormHardSetting m_formAxisItemSetting;
        public IO_FormHardSetting m_IOformHardSetting;
        IoChangeName m_formIOAdd;
        AnalogQuantityFormSetting m_formAnalogSetting;
        OtherFormSetting _OtherFormSetting;
        FormCommunicationSetting _FormCommunicationSetting;
        ParamSettingForm m_ParamSettingForm;
        PLC_From PLC_FromSeting;
        DateGroup_From DateGroup_form;
        FlowChar_From m_FlowChar_From;
        PointSet_From m_PointSet_From;
        FormProjectDataSetting _FormProjectDataSetting;
        public static Action<int, string> showLog = (param1, param2) => { };
        /// <summary>
        /// 选择项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedNode = treeView1.SelectedNode;
            NodeClick();
        }
        /// <summary>
        /// 界面分类打开
        /// </summary>
        public void NodeClick()
        {
            try
            {
                if (selectedNode.Text == "运动控制卡设置")
                {
                }
                else if (selectedNode.Text == "IO卡设置")
                {
                }
                else if (selectedNode.Text == "卡硬件设定")
                {
                    m_formControlHardSetting.Show();
                    m_formAxisItemSetting.Hide();
                    m_IOformHardSetting.Hide();
                    m_formIOAdd.Hide();
                    m_formAnalogSetting.Hide();
                    _OtherFormSetting.Hide();
                    _FormCommunicationSetting.Hide();
                    m_ParamSettingForm.Hide();
                    PLC_FromSeting.Hide();
                    DateGroup_form.Hide();
                    m_FlowChar_From.Hide();
                    m_PointSet_From.Hide();
                    _FormProjectDataSetting.Hide();
                }
                else if (selectedNode.Text == "轴硬件设定")
                {
                    m_formControlHardSetting.Hide();
                    m_formAxisItemSetting.Show();
                    m_IOformHardSetting.Hide();
                    m_formIOAdd.Hide();
                    m_formAnalogSetting.Hide();
                    _OtherFormSetting.Hide();
                    _FormCommunicationSetting.Hide();
                    m_ParamSettingForm.Hide();
                    PLC_FromSeting.Hide();
                    DateGroup_form.Hide();
                    m_FlowChar_From.Hide();
                    m_PointSet_From.Hide();
                    _FormProjectDataSetting.Hide();
                }
                else if (selectedNode.Text == "IO硬件设定窗口")
                {
                    m_formControlHardSetting.Hide();
                    m_formAxisItemSetting.Hide();
                    m_IOformHardSetting.Show();
                    m_formIOAdd.Hide();
                    m_formAnalogSetting.Hide();
                    _OtherFormSetting.Hide();
                    _FormCommunicationSetting.Hide();
                    m_ParamSettingForm.Hide();
                    PLC_FromSeting.Hide();
                    m_IOformHardSetting.UpdateIO();
                    DateGroup_form.Hide();
                    m_FlowChar_From.Hide();
                    m_PointSet_From.Hide();
                    _FormProjectDataSetting.Hide();
                }
                else if (selectedNode.Text == "模拟量波形设置")
                {
                    m_formControlHardSetting.Hide();
                    m_formAxisItemSetting.Hide();
                    m_IOformHardSetting.Hide();
                    m_formIOAdd.Hide();
                    m_formAnalogSetting.Show();
                    _OtherFormSetting.Hide();
                    _FormCommunicationSetting.Hide();
                    m_ParamSettingForm.Hide();
                    PLC_FromSeting.Hide();
                    m_FlowChar_From.Hide();
                    DateGroup_form.Hide();
                    m_PointSet_From.Hide();
                    _FormProjectDataSetting.Hide();
                }
                else if (selectedNode.Text == "其他设置")
                {

                    m_formControlHardSetting.Hide();
                    m_formAxisItemSetting.Hide();
                    m_IOformHardSetting.Hide();
                    m_formIOAdd.Hide();
                    m_formAnalogSetting.Hide();
                    _OtherFormSetting.Show();
                    _FormCommunicationSetting.Hide();
                    m_ParamSettingForm.Hide();
                    PLC_FromSeting.Hide();
                    DateGroup_form.Hide();
                    m_FlowChar_From.Hide();
                    m_PointSet_From.Hide();
                    _FormProjectDataSetting.Hide();
                }
                else if (selectedNode.Text == "参数配置设置")
                {
                    m_formControlHardSetting.Hide();
                    m_formAxisItemSetting.Hide();
                    m_IOformHardSetting.Hide();
                    m_formIOAdd.Hide();
                    m_formAnalogSetting.Hide();
                    _OtherFormSetting.Hide();
                    _FormCommunicationSetting.Hide();
                    m_ParamSettingForm.Show();
                    PLC_FromSeting.Hide();
                    DateGroup_form.Hide();
                    m_FlowChar_From.Hide();
                    m_PointSet_From.Hide();
                    _FormProjectDataSetting.Hide();
                }
                else if (selectedNode.Text == "通讯设置界面")
                {
                    m_formControlHardSetting.Hide();
                    m_formAxisItemSetting.Hide();
                    m_IOformHardSetting.Hide();
                    m_formIOAdd.Hide();
                    m_formAnalogSetting.Hide();
                    _OtherFormSetting.Hide();
                    _FormCommunicationSetting.Show();
                    m_ParamSettingForm.Hide();
                    PLC_FromSeting.Hide();
                    m_FlowChar_From.Hide();
                    DateGroup_form.Hide();
                    m_PointSet_From.Hide();
                    _FormProjectDataSetting.Hide();
                }
                else if (selectedNode.Text == "PLC")
                {
                    m_formControlHardSetting.Hide();
                    m_formAxisItemSetting.Hide();
                    m_IOformHardSetting.Hide();
                    m_formIOAdd.Hide();
                    m_formAnalogSetting.Hide();
                    _OtherFormSetting.Hide();
                    _FormCommunicationSetting.Hide();
                    m_ParamSettingForm.Hide();
                    PLC_FromSeting.Show();
                    m_FlowChar_From.Hide();
                    DateGroup_form.Hide();
                    m_PointSet_From.Hide();
                    _FormProjectDataSetting.Hide();
                }
                else if (selectedNode.Text == "数据组")
                {
                    m_PointSet_From.Hide();
                    m_formControlHardSetting.Hide();
                    m_formAxisItemSetting.Hide();
                    m_IOformHardSetting.Hide();
                    m_formIOAdd.Hide();
                    m_formAnalogSetting.Hide();
                    _OtherFormSetting.Hide();
                    _FormCommunicationSetting.Hide();
                    m_ParamSettingForm.Hide();
                    PLC_FromSeting.Hide();
                    m_FlowChar_From.Hide();
                    DateGroup_form.Show();
                    _FormProjectDataSetting.Hide();
                }
                else if (selectedNode.Text == "DataManage")
                {
                    m_PointSet_From.Hide();
                    m_formControlHardSetting.Hide();
                    m_formAxisItemSetting.Hide();
                    m_IOformHardSetting.Hide();
                    m_formIOAdd.Hide();
                    m_formAnalogSetting.Hide();
                    _OtherFormSetting.Hide();
                    _FormCommunicationSetting.Hide();
                    m_ParamSettingForm.Hide();
                    PLC_FromSeting.Hide();
                    m_FlowChar_From.Hide();
                    DateGroup_form.Hide();

                    _FormProjectDataSetting.Show();
                }
                else if (selectedNode.Text == "PLC设置")
                {
                }
                else if (selectedNode.Text == "通讯设置")
                {
                }
                else if (selectedNode.Text == "流程编辑")
                {
                    m_formControlHardSetting.Hide();
                    m_formAxisItemSetting.Hide();
                    m_IOformHardSetting.Hide();
                    m_formIOAdd.Hide();
                    m_formAnalogSetting.Hide();
                    _OtherFormSetting.Hide();
                    _FormCommunicationSetting.Hide();
                    m_ParamSettingForm.Hide();
                    PLC_FromSeting.Hide();
                    DateGroup_form.Hide();
                    m_FlowChar_From.Show();
                    m_PointSet_From.Hide();
                    _FormProjectDataSetting.Hide();
                }

                else if (selectedNode.Text == "点位增加调试")
                {
                    m_formControlHardSetting.Hide();
                    m_formAxisItemSetting.Hide();
                    m_IOformHardSetting.Hide();
                    m_formIOAdd.Hide();
                    m_formAnalogSetting.Hide();
                    _OtherFormSetting.Hide();
                    _FormCommunicationSetting.Hide();
                    m_ParamSettingForm.Hide();
                    PLC_FromSeting.Hide();
                    DateGroup_form.Hide();
                    m_FlowChar_From.Hide();
                    _FormProjectDataSetting.Hide();
                    m_PointSet_From.Show();
                }
                else
                {
                    //MessageBox.Show("此功能暂未开放");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void SystemSettings_Load(object sender, EventArgs e)
        {
            IntiAllSettingForm();
        }
        /// <summary>
        /// 初始化界面
        /// </summary>
        private void IntiAllSettingForm()
        {
            m_formControlHardSetting = new FormHardSetting();
            m_formControlHardSetting.TopLevel = false;
            panel2.Controls.Add(m_formControlHardSetting);
            m_formControlHardSetting.Size = panel2.Size;
            m_formControlHardSetting.Hide();

            m_formAxisItemSetting = new Aisx_FormHardSetting();
            m_formAxisItemSetting.TopLevel = false;
            panel2.Controls.Add(m_formAxisItemSetting);
            m_formAxisItemSetting.Size = panel2.Size;
            m_formAxisItemSetting.Hide();

            m_IOformHardSetting = new IO_FormHardSetting();
            m_IOformHardSetting.TopLevel = false;
            panel2.Controls.Add(m_IOformHardSetting);
            m_IOformHardSetting.Size = panel2.Size;
            m_IOformHardSetting.Hide();

            m_formIOAdd = new IoChangeName();
            m_formIOAdd.TopLevel = false;
            panel2.Controls.Add(m_formIOAdd);
            m_formIOAdd.Size = panel2.Size;
            m_formIOAdd.Hide();

            m_formAnalogSetting = new AnalogQuantityFormSetting();
            m_formAnalogSetting.TopLevel = false;
            panel2.Controls.Add(m_formAnalogSetting);
            m_formAnalogSetting.Size = panel2.Size;
            m_formAnalogSetting.Hide();

            _OtherFormSetting = new OtherFormSetting();
            _OtherFormSetting.TopLevel = false;
            panel2.Controls.Add(_OtherFormSetting);
            _OtherFormSetting.Size = panel2.Size;
            _OtherFormSetting.Hide();

            _FormCommunicationSetting = new FormCommunicationSetting();
            _FormCommunicationSetting.TopLevel = false;
            panel2.Controls.Add(_FormCommunicationSetting);
            _FormCommunicationSetting.Size = panel2.Size;
            _FormCommunicationSetting.Hide();

            m_ParamSettingForm = new ParamSettingForm();
            m_ParamSettingForm.TopLevel = false;
            panel2.Controls.Add(m_ParamSettingForm);
            m_ParamSettingForm.Size = panel2.Size;
            m_ParamSettingForm.Hide();

            PLC_FromSeting = new PLC_From();
            PLC_FromSeting.TopLevel = false;
            panel2.Controls.Add(PLC_FromSeting);
            PLC_FromSeting.Size = panel2.Size;
            PLC_FromSeting.Hide();

            DateGroup_form = new DateGroup_From();
            DateGroup_form.TopLevel = false;
            panel2.Controls.Add(DateGroup_form);
            DateGroup_form.Size = panel2.Size;
            DateGroup_form.Hide();

            m_FlowChar_From = new FlowChar_From();
            m_FlowChar_From.TopLevel = false;
            panel2.Controls.Add(m_FlowChar_From);
            m_FlowChar_From.Size = panel2.Size;
            m_FlowChar_From.Hide();

            m_PointSet_From = new PointSet_From();
            m_PointSet_From.TopLevel = false;
            panel2.Controls.Add(m_PointSet_From);
            m_PointSet_From.Size = panel2.Size;
            m_PointSet_From.Hide();

            _FormProjectDataSetting = new FormProjectDataSetting();
            _FormProjectDataSetting.TopLevel = false;
            panel2.Controls.Add(_FormProjectDataSetting);
            _FormProjectDataSetting.Size = panel2.Size;
            _FormProjectDataSetting.Hide();
        }
        /// <summary>
        /// 保存所有参数按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SaveParamDoc_Click(object sender, EventArgs e)
        {
            if (FormUserLogoin.userName != "admin")
            {
                MainForm.m_formAlarm.InsertAlarmMessage(ERecvResult.系统权限不足.ToString());
                return;
            }
            else
            {
                try
                {
                    SaveData();
                    MessageBox.Show("保存成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void SaveData()
        {
            Hard_Ward_Contral.hardDoc.SaveDoc();//固高控制卡参数的保存
            Hard_Ward_Contral.Aisx_Hard_Doc.SaveDoc();//固高卡轴参数的保存
            Hard_Ward_Contral.S_PortDate_Save.SaveDoc();//串口网口通讯参数保存
            Hard_Ward_Contral.Hardware_IO_State.SaveDoc();//IO改名保存
            Hard_Ward_Contral.Wave_Date_From_Save_Doc.SaveDoc();
            Hard_Ward_Contral.Wave_Date_Save_Doc.SaveDoc();//模拟量保存
            Hard_Ward_Contral._Get_High_Date_Save.SaveDoc();//测高和偏距设置
            Hard_Ward_Contral._PLC_ControlParameter.SaveDoc();//PLC设置保存
            Hard_Ward_Contral._DateGroupParameter.SaveDoc();//数据组保存
            Hard_Ward_Contral._FlowChar_ControlParameter.SaveDoc();
            Hard_Ward_Contral._Point_ControlParameter.SaveDoc();
            LoadData.SaveFile();
            DataManage.m_Doc.SaveDoc();
            Communication_DateLoadData.SaveFile();
        }

        private void btn_InitCard_Click(object sender, EventArgs e)
        {
            //Hard_Ward_Contral.Inin();
            //Hard_Ward_Contral.LoadData();//加载数据
        }
    }
}
