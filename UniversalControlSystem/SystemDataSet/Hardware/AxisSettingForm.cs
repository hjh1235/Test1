using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UniversalControlSystem
{
    public partial class AxisSettingForm : Form
    {
    // public static AxisParamDoc m_axisParamDoc;
        string strAxisName = "";
         AxisParamDoc axisData;
       
        public AxisSettingForm(string sAxisName, AxisParamDoc data)
        {
            InitializeComponent();
            axisData = new AxisParamDoc();
            string strAxisName = sAxisName;
            axisData = data;
            //AxisInfo = info;
        }
        public AxisSettingForm(string sAxisName)
        {
            InitializeComponent();
            //axisData = new AxisParamDoc();
            //m_axisParamDoc = new AxisParamDoc();
            string strAxisName = sAxisName;
            
            
        }
        private void AxisSettingForm_Load(object sender, EventArgs e)
        {
            try
            {
                label3.Text = strAxisName;
                comboBoxCardName.Text = "0";
                comboBoxAxisNo.Text = "0";
                //comboBoxCardName.Text = AxisInfo.m_AxisParamList.cardNo.ToString();
                //comboBoxAxisNo.Text = MainForm.pAxisParamDoc.AxisNo.ToString();
                ////comboBoxPulseMode.Text = MainForm.pAxisParamDoc.PulseWay;
                ////comboBoxUsed.Text = MainForm.pAxisParamDoc.IsUse;
                ////comboBoxOrgMode.Text = m_axisParamDoc.GoHomeWay;
                //txt_Alias.Text = MainForm.pAxisParamDoc.AxisSmallName;
                //textBoxAcc.Text = MainForm.pAxisParamDoc.AccSpeed.ToString();
                //textBoxDec.Text = MainForm.pAxisParamDoc.DecSpeed.ToString();
                //textBoxSpeed.Text = MainForm.pAxisParamDoc.Speed.ToString();
                //textBoxOrgSpd.Text = MainForm.pAxisParamDoc.GoHomeSpeed.ToString();
                //comboBoxPlusToMM.Text = MainForm.pAxisParamDoc.PulseFeed.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_Alias_TextChanged(object sender, EventArgs e)
        {
            //m_axisParamDoc.AxisSmallName = txt_Alias.Text;
        }

        private void comboBoxAxisNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ComboBox combox = (ComboBox)sender;
                if (combox.Name == "comboBoxCardName")
                {
                    axisData.cardNo = comboBoxCardName.SelectedIndex + 1;//mboBoxCardName.Text;
                }
                if (combox.Name == "comboBoxAxisNo")
                {
                    axisData.AxisNo = short.Parse(comboBoxAxisNo.SelectedItem.ToString());//short.Parse(comboBoxAxisNo.Text);
                }
            }
            catch
            {

            }
        }
        public void UpdateData(AxisParamDoc data)
        {
            axisData = data;
            comboBoxCardName.Text = axisData.cardNo.ToString();
            comboBoxAxisNo.Text = axisData.AxisNo.ToString();
            comboBoxPlusToMM.Text = axisData.PulseFeed.ToString();
            textBoxAcc.Text = axisData.AccSpeed.ToString();
            textBoxDec.Text = axisData.DecSpeed.ToString();
            textBoxSpeed.Text = axisData.Speed.ToString();
            textBoxOrgSpd.Text = axisData.GoHomeSpeed.ToString();
            txt_Alias.Text = axisData.AxisSmallName;
        }

        private void comboBoxPlusToMM_Validated(object sender, EventArgs e)
        {
            axisData.PulseFeed = double.Parse(comboBoxPlusToMM.Text);
        }

        private void textBoxDec_Validated(object sender, EventArgs e)
        {
            axisData.AccSpeed = double.Parse(textBoxAcc.Text);
            axisData.DecSpeed = double.Parse(textBoxDec.Text);
            axisData.Speed = double.Parse(textBoxSpeed.Text);
            //xisData.dLimtSpd = double.Parse(textBoxLimtSearchSpd.Text);
            axisData.GoHomeSpeed = double.Parse(textBoxOrgSpd.Text);
        }

        private void txt_Alias_Validated(object sender, EventArgs e)
        {
            axisData.AxisSmallName = txt_Alias.Text;
        }

        private void textBoxAcc_Validated(object sender, EventArgs e)
        {
            try
            {

                axisData.AccSpeed = double.Parse(textBoxAcc.Text);
                axisData.DecSpeed = double.Parse(textBoxDec.Text);
                axisData.Speed = double.Parse(textBoxSpeed.Text);
                //xisData.dLimtSpd = double.Parse(textBoxLimtSearchSpd.Text);
                axisData.GoHomeSpeed = double.Parse(textBoxOrgSpd.Text);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
