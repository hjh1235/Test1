using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public class GoogolCardInfo : GoolGaoHardWareInfoBase
    {
        public int iCardNo = 0;
        public int iAxisNo = 0;
        public double dAcc = 0;
        public double dDec = 0;
        public double dSpeed = 0;
        public double dGoHomeSpeed = 0;
        public double dPlusFeed = 0;
        public GoogolCardInfo()
        {

        }
        override public void ShowSettingForm(Panel panel)
        {
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                panel.Controls.RemoveAt(i);
            }
            FormAxisSetting frm = new FormAxisSetting(this);
            frm.TopLevel = false;
            panel.Controls.Add(frm);
            frm.Size = panel.Size;
            frm.Show();

        }
    }
}
