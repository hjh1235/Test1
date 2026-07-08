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
    public partial class FormAxisSetting : Form
    {
        public FormAxisSetting()
        {
            InitializeComponent();
        }
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }
        public void ShowFromMessage()
        {
            label1.Text = hardwareName;
            comboBoxCardNo.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].m_CardNo.ToString();
            comboBoxAxisNo.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].m_AxisNo.ToString();
            txt_Acc.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].Acc.ToString();
            txt_Dec.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].Dec.ToString();
            txt_Speed.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].Speed.ToString();
            txt_GoHomeSpeed.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].GoHomeSpeed.ToString();
            txt_Auto_Speed.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].Auto_Speed.ToString();    
            comboBoxPlusFeed.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].PlusFeed.ToString();
            comboBox_BuildCorNum.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].BuildCorNum.ToString();
            是否做插补轴.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].是否做插补轴.ToString();
            是否做测距轴.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].是否做测距轴.ToString();
            是否屏蔽.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].是否屏蔽.ToString();
            回原方式.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].回原方式;
            搜索限位速度.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].搜索限位速度.ToString();
            MainCardShow.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].MainCradBinding.ToString();
            comboBox_ifDoubleAxis.SelectedItem = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].是否双驱.ToString();
            comboBox_salveAxis.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].从轴号.ToString();
        }
        private void FormAxisSetting_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 设置运动控制卡号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].m_CardNo = Convert.ToInt16(comboBoxCardNo.Text);
            }
            catch
            {

            }
        }
        /// <summary>
        /// 设置运动控制轴号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxAxisNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].m_AxisNo = Convert.ToInt16(comboBoxAxisNo.Text);
            }
            catch { }

        }
        /// <summary>
        /// 设置运动控制轴的脉冲当量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPlusFeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].PlusFeed = Convert.ToDouble(comboBoxPlusFeed.Text);
            }
            catch { }
        }
        /// <summary>
        /// 设置运动控制轴的加速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Acc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_Acc.Text != "")
                {
                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].Acc = Convert.ToInt16(txt_Acc.Text);
                    //double _Acc= Convert.ToInt32(txt_Acc.Text);
                    // var i = (_Acc * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].PlusFeed) / (1000 * 1000);
                    // Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].Acc = (_Acc * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].PlusFeed) / (1000 * 1000);
                }
                else
                {

                }
            }
            catch { }

        }
        /// <summary>
        /// 设置运动轴的减速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Dec_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_Dec.Text != "")
                {

                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].Dec = Convert.ToInt16(txt_Dec.Text);
                    //double _Dec = Convert.ToInt32(txt_Dec.Text);
                    //Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].Dec = (_Dec * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].PlusFeed) / (1000 * 1000);
                }
            }
            catch { }

        }
        /// <summary>
        /// 设置运动控制轴的速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Speed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_Speed.Text != "")
                {

                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].Speed = Convert.ToInt32(txt_Speed.Text);
                }

            }
            catch { }

        }
        /// <summary>
        /// 设置运动控制轴回原点的速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_GoHomeSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_GoHomeSpeed.Text != "")
                {
                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].GoHomeSpeed = Convert.ToInt32(txt_GoHomeSpeed.Text);
                }
            }
            catch { }

        }
        /// <summary>
        /// 设置运动控制轴的脉冲当量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPlusFeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].PlusFeed = Convert.ToInt32(comboBoxPlusFeed.Text);
            }
            catch { }

        }
        /// <summary>
        /// 设置运动控制轴自动运行时的速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_Auto_Speed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_Auto_Speed.Text != "")
                {
                    Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].Auto_Speed = Convert.ToInt32(txt_Auto_Speed.Text);
                }
            }
            catch { }
        }
        /// <summary>
        /// 设置坐标系编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_BuildCorNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].BuildCorNum = Convert.ToInt16(comboBox_BuildCorNum.Text);
            }
            catch { }
        }
        /// <summary>
        /// 设置轴是否可以做为测距轴，0为不可以，1是可以
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 是否做测距轴_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].是否做测距轴 = Convert.ToInt16(是否做测距轴.Text);
            }
            catch { }
        }
        /// <summary>
        /// 设置轴是否可以做为插补轴，0为不可以，1是可以
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 是否做插补轴_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].是否做插补轴 = Convert.ToInt16(是否做插补轴.Text);
            }
            catch { }
        }
        private void 是否屏蔽_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].是否屏蔽 = Convert.ToBoolean(是否屏蔽.Text);
            }
            catch { }
        }
        #region 输入字符验证
        /// <summary>
        /// 输入字符验证方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != (char)('.') && e.KeyChar != (char)('-'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)('-'))
            {
                if ((sender as TextBox).Text != "")
                {
                    e.Handled = true;
                }
                else
                {
                    (sender as TextBox).Text = "";
                    e.Handled = true;
                }
            }
            //第1位是负号时候、第2位小数点不可
            if (((TextBox)sender).Text == "-" && e.KeyChar == (char)('.'))
            {
                e.Handled = true;
            }
            //负号只能1次
            if (e.KeyChar == 45 && (((TextBox)sender).SelectionStart != 0 || ((TextBox)sender).Text.IndexOf("-") >= 0))
                e.Handled = true;
            //第1位小数点不可
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text == "")
            {
                e.Handled = true;
            }
            //小数点只能1次
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text.IndexOf('.') != -1)
            {
                e.Handled = true;
            }
            //小数点（最大到2位）   
            if (e.KeyChar != '\b' && (((TextBox)sender).SelectionStart) > (((TextBox)sender).Text.LastIndexOf('.')) + 2 && ((TextBox)sender).Text.IndexOf(".") >= 0)
                e.Handled = true;
            //光标在小数点右侧时候判断  
            if (e.KeyChar != '\b' && ((TextBox)sender).SelectionStart >= (((TextBox)sender).Text.LastIndexOf('.')) && ((TextBox)sender).Text.IndexOf(".") >= 0)
            {
                if ((((TextBox)sender).SelectionStart) == (((TextBox)sender).Text.LastIndexOf('.')) + 1)
                {
                    if ((((TextBox)sender).Text.Length).ToString() == (((TextBox)sender).Text.IndexOf(".") + 3).ToString())
                        e.Handled = true;
                }
                if ((((TextBox)sender).SelectionStart) == (((TextBox)sender).Text.LastIndexOf('.')) + 2)
                {
                    if ((((TextBox)sender).Text.Length - 3).ToString() == ((TextBox)sender).Text.IndexOf(".").ToString()) e.Handled = true;
                }
            }
            //第1位是0，第2位必须是小数点
            //if (e.KeyChar != (char)('.') && e.KeyChar != 8 && ((TextBox)sender).Text == "0")
            //{
            //    e.Handled = true;
            //}

        }

        private void txt_Acc_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void txt_Dec_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void txt_Speed_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }


        private void txt_GoHomeSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }
        private void txt_Auto_Speed_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 回原方式_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].回原方式 = 回原方式.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].搜索限位速度 = Convert.ToInt32(搜索限位速度.Text);
            }
            catch { }

        }

        private void 搜索限位速度_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void comboBox_salveAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].从轴号 = Convert.ToInt32(comboBox_salveAxis.Text);
            }
            catch { }
        }

        private void comboBox_ifDoubleAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[label1.Text].是否双驱 = Convert.ToBoolean(comboBox_ifDoubleAxis.Text);
            }
            catch { }
        }
    }
}
