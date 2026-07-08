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
    public partial class AxisSettingItemForm : Form
    {
        public static AxisParamDoc AxisPa ;
        public AxisSettingForm frmAxisSetting1;
        public AxisSettingForm frmAxisSetting2;
        public AxisSettingForm frmAxisSetting3;
        public AxisSettingForm frmAxisSetting4;
        public AxisSettingForm frmAxisSetting5;
        public AxisSettingForm frmAxisSetting6;
        public AxisSettingForm frmAxisSetting7;
        public AxisSettingForm frmAxisSetting8;
        public AxisSettingItemForm()
        {
            InitializeComponent();
            //frmAxisSetting = new List<AxisParamDoc>();
            //AxisSettingItemForm_Load()
        }

        private void AxisSettingItemForm_Load(object sender, EventArgs e)
        {
            //AxisSettingForm frmAxisSet = new AxisSettingForm();
            //frmAxisSetting.Add(frmAxisSet);


            frmAxisSetting1 = new AxisSettingForm("轴1");
            frmAxisSetting1.TopLevel = false;
            panel1.Controls.Add(frmAxisSetting1);
            frmAxisSetting1.Dock = DockStyle.Fill;
            frmAxisSetting1.Show();
            AxisBaseParam AxisBaseParam = new AxisBaseParam();
            AxisBaseParam.AxisNo = 0;
            AxisPa.m_AxisParamList.Add(AxisBaseParam);
            AxisPa.m_AxisParamDictionary.Add("0", AxisBaseParam);

            frmAxisSetting2 = new AxisSettingForm("轴2");
            frmAxisSetting2.TopLevel = false;
            panel1.Controls.Add(frmAxisSetting2);
            frmAxisSetting2.Size = panel1.Size;
            frmAxisSetting2.Dock = DockStyle.Fill;
            frmAxisSetting2.Show();
            frmAxisSetting2.Hide();
            AxisBaseParam AxisBaseParam1 = new AxisBaseParam();
            AxisBaseParam.AxisNo = 1;
            AxisPa.m_AxisParamList.Add(AxisBaseParam1);
            AxisPa.m_AxisParamDictionary.Add("1", AxisBaseParam);

            frmAxisSetting3 = new AxisSettingForm("轴3");
            frmAxisSetting3.TopLevel = false;
            panel1.Controls.Add(frmAxisSetting3);
            //frmAxisSettingZ.Size = panel1.Size;
            frmAxisSetting3.Dock = DockStyle.Fill;
            frmAxisSetting3.Show();
            frmAxisSetting3.Hide();
            AxisBaseParam AxisBaseParam2 = new AxisBaseParam();
            AxisBaseParam.AxisNo = 2;
            AxisPa.m_AxisParamList.Add(AxisBaseParam2);
            AxisPa.m_AxisParamDictionary.Add("2", AxisBaseParam);


            frmAxisSetting4 = new AxisSettingForm("轴4");
            frmAxisSetting4.TopLevel = false;
            panel1.Controls.Add(frmAxisSetting4);
            //frmAxisSettingU.Size = panel1.Size;
            frmAxisSetting4.Dock = DockStyle.Fill;
            frmAxisSetting4.Show();
            frmAxisSetting4.Hide();

            AxisBaseParam AxisBaseParam3 = new AxisBaseParam();
            AxisBaseParam.AxisNo = 3;
            AxisPa.m_AxisParamList.Add(AxisBaseParam3);

            AxisPa.m_AxisParamDictionary.Add("3", AxisBaseParam);

            frmAxisSetting5 = new AxisSettingForm("轴5");
            frmAxisSetting5.TopLevel = false;
            panel1.Controls.Add(frmAxisSetting5);
            frmAxisSetting5.Dock = DockStyle.Fill;
            frmAxisSetting5.Show();

            AxisBaseParam AxisBaseParam4= new AxisBaseParam();
            AxisBaseParam.AxisNo = 4;
            AxisPa.m_AxisParamList.Add(AxisBaseParam4);

            AxisPa.m_AxisParamDictionary.Add("4", AxisBaseParam);



            frmAxisSetting6 = new AxisSettingForm("轴6");
            frmAxisSetting6.TopLevel = false;
            panel1.Controls.Add(frmAxisSetting6);
            //frmAxisSettingY.Size = panel1.Size;
            frmAxisSetting6.Dock = DockStyle.Fill;
            frmAxisSetting6.Show();
            frmAxisSetting6.Hide();
            AxisBaseParam AxisBaseParam5 = new AxisBaseParam();
            AxisBaseParam.AxisNo = 5;
            AxisPa.m_AxisParamList.Add(AxisBaseParam5);
            AxisPa.m_AxisParamDictionary.Add("5", AxisBaseParam);


            frmAxisSetting7 = new AxisSettingForm("轴7");
            frmAxisSetting7.TopLevel = false;
            panel1.Controls.Add(frmAxisSetting7);
            //frmAxisSettingZ.Size = panel1.Size;
            frmAxisSetting7.Dock = DockStyle.Fill;
            frmAxisSetting7.Show();
            frmAxisSetting7.Hide();
            AxisBaseParam AxisBaseParam6 = new AxisBaseParam();
            AxisBaseParam.AxisNo = 6;
            AxisPa.m_AxisParamList.Add(AxisBaseParam6);
            AxisPa.m_AxisParamDictionary.Add("6", AxisBaseParam);


            frmAxisSetting8 = new AxisSettingForm("轴8");
            frmAxisSetting8.TopLevel = false;
            panel1.Controls.Add(frmAxisSetting8);
            //frmAxisSettingU.Size = panel1.Size;
            frmAxisSetting8.Dock = DockStyle.Fill;
            frmAxisSetting8.Show();
            frmAxisSetting8.Hide();
            AxisBaseParam AxisBaseParam7 = new AxisBaseParam();
            AxisBaseParam.AxisNo = 7;
            AxisPa.m_AxisParamList.Add(AxisBaseParam7);
            AxisPa.m_AxisParamDictionary.Add("7", AxisBaseParam);
        }

        private void btn_Axis1Set_Click(object sender, EventArgs e)
        {
            frmAxisSetting1.Show();
            frmAxisSetting2.Hide();
            frmAxisSetting3.Hide();
            frmAxisSetting4.Hide();
            frmAxisSetting5.Hide();
            frmAxisSetting6.Hide();
            frmAxisSetting7.Hide();
            frmAxisSetting8.Hide();

            btn_Axis1Set.BackColor = Color.Lime;
            btn_Axis2Set.BackColor = Color.DeepSkyBlue;
            btn_Axis3Set.BackColor = Color.DeepSkyBlue;
            btn_Axis4Set.BackColor = Color.DeepSkyBlue;
            btn_Axis5Set.BackColor = Color.DeepSkyBlue;
            btn_Axis6Set.BackColor = Color.DeepSkyBlue;
            btn_Axis7Set.BackColor = Color.DeepSkyBlue;
            btn_Axis8Set.BackColor = Color.DeepSkyBlue;
        }

        private void btn_Axis2Set_Click(object sender, EventArgs e)
        {
            frmAxisSetting1.Hide();
            frmAxisSetting2.Show();
            frmAxisSetting3.Hide();
            frmAxisSetting4.Hide();
            frmAxisSetting5.Hide();
            frmAxisSetting6.Hide();
            frmAxisSetting7.Hide();
            frmAxisSetting8.Hide();


            btn_Axis2Set.BackColor = Color.Lime;
            btn_Axis1Set.BackColor = Color.DeepSkyBlue;
            btn_Axis3Set.BackColor = Color.DeepSkyBlue;
            btn_Axis4Set.BackColor = Color.DeepSkyBlue;
            btn_Axis5Set.BackColor = Color.DeepSkyBlue;
            btn_Axis6Set.BackColor = Color.DeepSkyBlue;
            btn_Axis7Set.BackColor = Color.DeepSkyBlue;
            btn_Axis8Set.BackColor = Color.DeepSkyBlue;
        }

        private void btn_Axis3Set_Click(object sender, EventArgs e)
        {
            frmAxisSetting1.Hide();
            frmAxisSetting2.Hide();
            frmAxisSetting3.Show();
            frmAxisSetting4.Hide();
            frmAxisSetting5.Hide();
            frmAxisSetting6.Hide();
            frmAxisSetting7.Hide();
            frmAxisSetting8.Hide();


            btn_Axis3Set.BackColor = Color.Lime;
            btn_Axis1Set.BackColor = Color.DeepSkyBlue;
            btn_Axis2Set.BackColor = Color.DeepSkyBlue;
            btn_Axis4Set.BackColor = Color.DeepSkyBlue;
            btn_Axis5Set.BackColor = Color.DeepSkyBlue;
            btn_Axis6Set.BackColor = Color.DeepSkyBlue;
            btn_Axis7Set.BackColor = Color.DeepSkyBlue;
            btn_Axis8Set.BackColor = Color.DeepSkyBlue;
        }

        private void btn_Axis4Set_Click(object sender, EventArgs e)
        {
            frmAxisSetting1.Hide();
            frmAxisSetting2.Hide();
            frmAxisSetting3.Hide();
            frmAxisSetting4.Show();
            frmAxisSetting5.Hide();
            frmAxisSetting6.Hide();
            frmAxisSetting7.Hide();
            frmAxisSetting8.Hide();


            btn_Axis4Set.BackColor = Color.Lime;
            btn_Axis1Set.BackColor = Color.DeepSkyBlue;
            btn_Axis2Set.BackColor = Color.DeepSkyBlue;
            btn_Axis3Set.BackColor = Color.DeepSkyBlue;
            btn_Axis5Set.BackColor = Color.DeepSkyBlue;
            btn_Axis6Set.BackColor = Color.DeepSkyBlue;
            btn_Axis7Set.BackColor = Color.DeepSkyBlue;
            btn_Axis8Set.BackColor = Color.DeepSkyBlue;
        }

        private void btn_Axis5Set_Click(object sender, EventArgs e)
        {
            frmAxisSetting1.Hide();
            frmAxisSetting2.Hide();
            frmAxisSetting3.Hide();
            frmAxisSetting4.Hide();
            frmAxisSetting5.Show();
            frmAxisSetting6.Hide();
            frmAxisSetting7.Hide();
            frmAxisSetting8.Hide();


            btn_Axis5Set.BackColor = Color.Lime;
            btn_Axis1Set.BackColor = Color.DeepSkyBlue;
            btn_Axis2Set.BackColor = Color.DeepSkyBlue;
            btn_Axis3Set.BackColor = Color.DeepSkyBlue;
            btn_Axis4Set.BackColor = Color.DeepSkyBlue;
            btn_Axis6Set.BackColor = Color.DeepSkyBlue;
            btn_Axis7Set.BackColor = Color.DeepSkyBlue;
            btn_Axis8Set.BackColor = Color.DeepSkyBlue;
        }

        private void btn_Axis6Set_Click(object sender, EventArgs e)
        {
            frmAxisSetting1.Hide();
            frmAxisSetting2.Hide();
            frmAxisSetting3.Hide();
            frmAxisSetting4.Hide();
            frmAxisSetting5.Hide();
            frmAxisSetting6.Show();
            frmAxisSetting7.Hide();
            frmAxisSetting8.Hide();


            btn_Axis6Set.BackColor = Color.Lime;
            btn_Axis1Set.BackColor = Color.DeepSkyBlue;
            btn_Axis2Set.BackColor = Color.DeepSkyBlue;
            btn_Axis3Set.BackColor = Color.DeepSkyBlue;
            btn_Axis4Set.BackColor = Color.DeepSkyBlue;
            btn_Axis5Set.BackColor = Color.DeepSkyBlue;
            btn_Axis7Set.BackColor = Color.DeepSkyBlue;
            btn_Axis8Set.BackColor = Color.DeepSkyBlue;
        }

        private void btn_Axis7Set_Click(object sender, EventArgs e)
        {
            frmAxisSetting1.Hide();
            frmAxisSetting2.Hide();
            frmAxisSetting3.Hide();
            frmAxisSetting4.Hide();
            frmAxisSetting5.Hide();
            frmAxisSetting6.Hide();
            frmAxisSetting7.Show();
            frmAxisSetting8.Hide();


            btn_Axis7Set.BackColor = Color.Lime;
            btn_Axis1Set.BackColor = Color.DeepSkyBlue;
            btn_Axis2Set.BackColor = Color.DeepSkyBlue;
            btn_Axis3Set.BackColor = Color.DeepSkyBlue;
            btn_Axis4Set.BackColor = Color.DeepSkyBlue;
            btn_Axis5Set.BackColor = Color.DeepSkyBlue;
            btn_Axis6Set.BackColor = Color.DeepSkyBlue;
            btn_Axis8Set.BackColor = Color.DeepSkyBlue;
        }

        private void btn_Axis8Set_Click(object sender, EventArgs e)
        {
            frmAxisSetting1.Hide();
            frmAxisSetting2.Hide();
            frmAxisSetting3.Hide();
            frmAxisSetting4.Hide();
            frmAxisSetting5.Hide();
            frmAxisSetting6.Hide();
            frmAxisSetting7.Hide();
            frmAxisSetting8.Show();


            btn_Axis8Set.BackColor = Color.Lime;
            btn_Axis1Set.BackColor = Color.DeepSkyBlue;
            btn_Axis2Set.BackColor = Color.DeepSkyBlue;
            btn_Axis3Set.BackColor = Color.DeepSkyBlue;
            btn_Axis4Set.BackColor = Color.DeepSkyBlue;
            btn_Axis5Set.BackColor = Color.DeepSkyBlue;
            btn_Axis6Set.BackColor = Color.DeepSkyBlue;
            btn_Axis7Set.BackColor = Color.DeepSkyBlue;
        }
    }
}
