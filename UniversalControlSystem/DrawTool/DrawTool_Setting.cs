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
    public partial class DrawTool_Setting : Form
    {
    ///    public static GoogolCardInfo hardInfo;
        public DrawTool_Setting()
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



        }
        private void FormAxisSetting_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxCardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
         
        }

        private void comboBoxAxisNo_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void txt_Acc_Validated(object sender, EventArgs e)
        {
          
        }

        private void txt_Dec_Validated(object sender, EventArgs e)
        {
        }//

        private void txt_Speed_Validated(object sender, EventArgs e)
        {
      
        }

        private void txt_GoHomeSpeed_Validated(object sender, EventArgs e)
        {
        
        }
        
        private void comboBoxPlusFeed_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }
        private void txt_Acc_TextChanged(object sender, EventArgs e)
        {
           
         
        }

        private void txt_Dec_TextChanged(object sender, EventArgs e)
        {
         
          
        }

        private void txt_Speed_TextChanged(object sender, EventArgs e)
        {
          
         
        }

        private void txt_GoHomeSpeed_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void comboBoxPlusFeed_TextChanged(object sender, EventArgs e)
        {
           
               
         
        }

        private void txt_Auto_Speed_TextChanged(object sender, EventArgs e)
        {
              
        }
        private void comboBox_BuildCorNum_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void 是否做测距轴_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void 是否做插补轴_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
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
            if (e.KeyChar != (char)('.') && e.KeyChar != 8 && ((TextBox)sender).Text == "0")
            {
                e.Handled = true;
            }
 
        }

        private void txt_Acc_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txt_Dec_KeyPress(object sender, KeyPressEventArgs e)
        {
       
        }

        private void txt_Speed_KeyPress(object sender, KeyPressEventArgs e)
        {
    
        }


        private void txt_GoHomeSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        private void txt_Auto_Speed_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
    }
}
