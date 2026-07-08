
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
namespace UniversalControlSystem
{
    public partial class 波形展示 : Form
    {
        private static 波形展示 波形展示Form;
        public static 波形展示 Instance()
        {
            if (波形展示Form == null)
            {
                波形展示Form = new 波形展示();
            }
            return 波形展示Form;
        }
        public  List<float> date = new List<float>();
        public 波形展示()
        {
            InitializeComponent();
        }
        public float time =0;
        public double times = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    double date = 0.0;
            //    //卡号
            //    //通道号
            //    //数据
            //    uint clk1;
            //    double dbRet = 0.0;

            //    short rtn = gts.mc.GT_GetAdc(0/*usCardNo*/, 2, out dbRet, 1, out clk1);
            //    if (dbRet > 0.6)
            //    {
            //        //this.chart1.Series[0].Points.Clear();

            //        //this.chart1.Series[0].Points.AddXY(0, 0);
            //        //times = (item.Value.Times / 1000) + times;
            //        this.chart1.Series[0].Points.AddXY(Math.Round(times, 1), (float)dbRet);
            //        Thread.Sleep(10);
            //        times = times + 10;
            //    }
            //    if (dbRet < 0.6 && dbRet > 0.0)
            //    {
            //        times = 0;
            //        this.chart1.Series[0].Points.Clear();
            //    }
            //    else
            //    {

            //    }
            //}
            //catch
            //{

             
            //}
           
        }

        private void 波形展示_Load(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Wave_Date_Save_SettingFormDictionary)
            {
                cbo_WeldChoose.Items.Add(item.Value.hardwareName);
            }
            this.cbo_WeldChoose.SelectedIndex = 0;
            // 功率.Text =  DateSave.Instance().Production.WeldPower.ToString();
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private Point mouse_offset;
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mouse = Control.MousePosition;
                mouse.Offset(mouse_offset.X, mouse_offset.Y);
                this.Location = mouse;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i=0;i<70;i++)
            {
                //curveGraph1.ShowCurve(i*10,i*10);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // curveGraph1.Clean();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (float i = 0; i < 70; i++)
            {
                //curveGraph1.ShowCurve(i * 10, i * (float) 0.50);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
          //  curveGraph1.Clean();
        }

        private void 设置最大功率_Click(object sender, EventArgs e)
        {
            //int power =int .Parse(功率.Text) ;
            //DateSave.Instance().Production.WeldPower = power;
            //DateSave.Instance().SaveDoc();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            double times = 0;
            this.chart1.Series[0].Points.AddXY(0, 0);
            this.chart1.Series[0].Name = cbo_WeldChoose.Text;
            foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
            {
                //if (item.Value.Wave_hardwareName.Contains(label1.Text))
                //{

                //    this.chart1.Series[0].Points.AddXY(Math.Round(times, 1), (float)item.Value.Powers);
                //}
                if (item.Value.Wave_hardwareName.Contains(cbo_WeldChoose.Text))
                {
                    times = (item.Value.Times / 1000) + times;
                    this.chart1.Series[0].Points.AddXY(Math.Round(times, 1), (float)item.Value.Powers);
                }
            }
            //for (int i=0;i<200;i++)
            //{
            //    float io=0;

            //  //  curveGraph1.ShowCurve(i+10,(float) 0.2);
            //}

        }
    }
}
