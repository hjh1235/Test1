using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public partial class DateGroup_Setting : Form
    {
        ///    public static GoogolCardInfo hardInfo;
        public DateGroup_Setting()
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
            DateType.Text = hardwareTpye;
            DateTypeName.Text = hardwareName;
            txt_date.Text = Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[hardwareName].Date.ToString();
        }
        private void FormAxisSetting_Load(object sender, EventArgs e)
        {
        }
        private void txt_date_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hardwareTpye == "LONG")
                {
                    bool b = Regex.IsMatch(txt_date.Text, @"^[+-]?\d*$");
                    if (b == true)
                    {
                        try
                        {
                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[label1.Text].Date = long.Parse(txt_date.Text);
                        }
                        catch
                        {
                            MessageBox.Show("数据错误");
                        }
                    }
                    else
                    {
                        MessageBox.Show("数据错误");
                    }
                }
                else if (hardwareTpye == "STRING")
                {
                    Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[label1.Text].Date = txt_date.Text;
                }
                else if (hardwareTpye == "SHORT")
                {
                    bool b = Regex.IsMatch(txt_date.Text, @"^[+-]?\d*$");
                    if (b == true)
                    {
                        try
                        {
                            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[label1.Text].Date = Convert.ToInt16(txt_date.Text);
                        }
                        catch
                        {
                            MessageBox.Show("数据错误");
                        }
                    }
                    else
                    {
                        MessageBox.Show("数据错误");
                    }
                }
                else if (hardwareTpye == "DOUBLE")
                {
                    bool a = Regex.IsMatch(txt_date.Text, @"^[+-]?\d*[.]?\d*$");
                    if (a == true)
                    {
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[label1.Text].Date = txt_date.Text;
                    }
                    else
                    {
                        MessageBox.Show("数据错误");
                    }
                }
            }
            catch
            {
                MessageBox.Show("数据错误");
            }
        }

        private void txt_date_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_date_Leave(object sender, EventArgs e)
        {
            try
            {
                if (hardwareTpye == "BOOL")
                {
                    if (txt_date.Text.ToLower() == "true")
                    {
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[label1.Text].Date = txt_date.Text;
                    }
                    else if (txt_date.Text.ToLower() == "false")
                    {
                        Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[label1.Text].Date = txt_date.Text;
                    }
                    else
                    {
                        MessageBox.Show("数据错误");
                    }
                }
            }
            catch
            {

            }

        }
    }
}
