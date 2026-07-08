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
using System.Windows.Forms.DataVisualization.Charting;

namespace UniversalControlSystem
{
    public partial class AnalogQuantityOutFrom : Form
    {
        public AnalogQuantityOutFrom()
        {
            InitializeComponent();
        }
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }
        public double Vo{ get; set; }
        public void ShowFromMessage()
        {
            label1.Text = hardwareName;
            try
            {
                TimeSet1.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text+"_" +"第1段波形"].Times.ToString();
                TimeSet2.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第2段波形"].Times.ToString();
                TimeSet3.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第3段波形"].Times.ToString();
                TimeSet4.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第4段波形"].Times.ToString();
                TimeSet5.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第5段波形"].Times.ToString();
                TimeSet6.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第6段波形"].Times.ToString();
                TimeSet7.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第7段波形"].Times.ToString();
                TimeSet8.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第8段波形"].Times.ToString();
                TimeSet9.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第9段波形"].Times.ToString();
                TimeSet10.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第10段波形"].Times.ToString();
                TimeSet11.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第11段波形"].Times.ToString();
                TimeSet12.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第12段波形"].Times.ToString();
                TimeSet13.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第13段波形"].Times.ToString();
                TimeSet14.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第14段波形"].Times.ToString();
                TimeSet15.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第15段波形"].Times.ToString();
                TimeSet16.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第16段波形"].Times.ToString();


                VolSet1.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].Voltages.ToString();

                VolSet2.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第2段波形"].Voltages.ToString();

                VolSet3.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第3段波形"].Voltages.ToString();

                VolSet4.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第4段波形"].Voltages.ToString();

                VolSet5.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第5段波形"].Voltages.ToString();

                VolSet6.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第6段波形"].Voltages.ToString();

                VolSet7.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第7段波形"].Voltages.ToString();

                VolSet8.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第8段波形"].Voltages.ToString();

                VolSet9.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第9段波形"].Voltages.ToString();

                VolSet10.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第10段波形"].Voltages.ToString();
              
                VolSet11.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第11段波形"].Voltages.ToString();

                VolSet12.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第12段波形"].Voltages.ToString();

                VolSet13.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第13段波形"].Voltages.ToString();

                VolSet14.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第14段波形"].Voltages.ToString();

                VolSet15.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第15段波形"].Voltages.ToString();

                VolSet16.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第16段波形"].Voltages.ToString();

                PowerSet1.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].Powers.ToString();
                PowerSet2.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第2段波形"].Powers.ToString();
                PowerSet3.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第3段波形"].Powers.ToString();
                PowerSet4.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第4段波形"].Powers.ToString();
                PowerSet5.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第5段波形"].Powers.ToString();
                PowerSet6.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第6段波形"].Powers.ToString();
                PowerSet7.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第7段波形"].Powers.ToString();
                PowerSet8.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第8段波形"].Powers.ToString();
                PowerSet9.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第9段波形"].Powers.ToString();
                PowerSet10.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第10段波形"].Powers.ToString();
                PowerSet11.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第11段波形"].Powers.ToString();
                PowerSet12.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第12段波形"].Powers.ToString();
                PowerSet13.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第13段波形"].Powers.ToString();
                PowerSet14.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第14段波形"].Powers.ToString();
                PowerSet15.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第15段波形"].Powers.ToString();
                PowerSet16.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第16段波形"].Powers.ToString();

                try
                {
                    最大电压.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].High_Voltage.ToString();
                }
                catch {
                    最大电压.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].High_Voltage.ToString(); }
                try
                {
                    Wave_channel_.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].Wave_channel_num.ToString();
                }
                catch { Wave_channel_.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].Wave_channel_num.ToString(); }
                try
                {
                    最大功率.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].High_Power.ToString();
                }
                catch { 最大功率.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].High_Power.ToString(); }
                try
                {
                    Wave_channel_Card_.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].Wave_channel_Card_num.ToString();
                }
                catch
                {
                    Wave_channel_Card_.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].Wave_channel_Card_num.ToString();
                }
                try
                {
                    laserPowerMode.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].laserPowerMode.ToString();
                }
                catch { laserPowerMode.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].laserPowerMode.ToString(); }
                try
                {
                    if (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO激光口1 != null)
                    {
                        if (高速IO口1.Items.Count<5)
                        {
                            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                            {
                                高速IO口1.Items.Add(item.Value.hardIOName);
                            }
                            高速IO口1.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO激光口1;
                        }
                      
                   
                    }
                    else
                    {
                        foreach (var item in Hard_Ward_Contral. Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                        {
                            高速IO口1.Items.Add(item.Value.hardIOName);
                        }
                    }
                  
                }
                catch
                {
                    if (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO激光口1 != null)
                    {
                        if (高速IO口1.Items.Count < 5)
                        {
                            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                            {
                                高速IO口1.Items.Add(item.Value.hardIOName);
                            }
                            高速IO口1.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO激光口1;
                        }
                    }
                    else
                    {
                        foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                        {
                            高速IO口1.Items.Add(item.Value.hardIOName);
                        }
                    }
                }
                try
                {
                    if (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO激光口1 != null)
                    {
                        if (高速IO口2.Items.Count < 5)
                        {
                            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                            {
                                高速IO口2.Items.Add(item.Value.hardIOName);
                            }
                            高速IO口2.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO激光口2;
                        }


                    }
                    else
                    {
                        foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                        {
                            高速IO口2.Items.Add(item.Value.hardIOName);
                        }

                    }
                }
                catch
                {
                    if (高速IO口2.Items.Count < 5)
                    {
                        foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                        {
                            高速IO口2.Items.Add(item.Value.hardIOName);
                        }
                        高速IO口2.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO激光口2;
                    }
                }
                try
                {
                    if (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO激光口3!= null)
                    {
                        if (高速IO口3.Items.Count < 5)
                        {
                            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                            {
                                高速IO口3.Items.Add(item.Value.hardIOName);
                            }
                            高速IO口3.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO激光口3;
                        }
                    }
                    else
                    {
                        foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                        {
                            高速IO口3.Items.Add(item.Value.hardIOName);
                        }

                    }
                  
                }
                catch
                {
                    if (高速IO口3.Items.Count < 5)
                    {
                        foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                        {
                            高速IO口3.Items.Add(item.Value.hardIOName);
                        }
                        高速IO口3.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO激光口3;
                    }
                }
                try {
                    if (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO激光口4 != null)
                    {
                        if (高速IO口4.Items.Count < 5)
                        {
                            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                            {
                                高速IO口4.Items.Add(item.Value.hardIOName);
                            }
                            高速IO口4.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO激光口4;
                        }

                    }
                    else
                    {
                        foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                        {
                            高速IO口4.Items.Add(item.Value.hardIOName);
                        }
                    }
                    }
                catch
                {
                    if (高速IO口4.Items.Count < 5)
                    {
                        foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                        {
                            高速IO口4.Items.Add(item.Value.hardIOName);
                        }
                        高速IO口4.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO激光口4;
                    }
                }
                try {
                    if (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO口激光完成!= null)
                    {
                       
                        if (高速IO口激光完成.Items.Count < 5)
                        {
                            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
                            {
                                高速IO口激光完成.Items.Add(item.Value.hardIOName);
                            }
                            高速IO口激光完成.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO口激光完成;
                        }

                    }
                    else
                    {
                        foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
                        {
                            高速IO口激光完成.Items.Add(item.Value.hardIOName);
                        }
                    }
                   }
                catch
                {
                    if (高速IO口激光完成.Items.Count < 5)
                    {
                        foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary)
                        {
                            高速IO口激光完成.Items.Add(item.Value.hardIOName);
                        }
                        高速IO口激光完成.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO口激光完成;
                    }
                }


                try
                {
                    if (Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO输出口 != null)
                    {                  
                        if (高速IO输出口.Items.Count < 5)
                        {
                            foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                            {
                                高速IO输出口.Items.Add(item.Value.hardIOName);
                            }
                            高速IO输出口.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO输出口;
                        }

                    }
                    else
                    {
                        foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                        {
                            高速IO输出口.Items.Add(item.Value.hardIOName);
                        }
                    }
                }
                catch
                {
                    if (高速IO输出口.Items.Count < 5)
                    {
                        foreach (var item in Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary)
                        {
                            高速IO输出口.Items.Add(item.Value.hardIOName);
                        }
                        高速IO输出口.Text = Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].高速IO输出口;
                    }

                }

                try
                {
                    int count = 1;
                    foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                    {
                        if (item.Value.Wave_hardwareName.Contains(label1.Text))
                        {
                            Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].laserPowerMode = 2;
                            count++;
                        }
                    }
                }
                catch { }
                update();
            }
            catch
            {
         
            }

        }

        private void 设置执行波形_Click(object sender, EventArgs e)
        {

        }
        List<TextBox> TimeSet = new List<TextBox>();
        List<TextBox> VolSet = new List<TextBox>();
        List<TextBox> PowerSet = new List<TextBox>();
        private void AnalogQuantityOutFrom_Load(object sender, EventArgs e)
        {
            TimeSet.Add(TimeSet1);
            TimeSet.Add(TimeSet2);
            TimeSet.Add(TimeSet3);
            TimeSet.Add(TimeSet4);
            TimeSet.Add(TimeSet5);
            TimeSet.Add(TimeSet6);
            TimeSet.Add(TimeSet7);
            TimeSet.Add(TimeSet8);
            TimeSet.Add(TimeSet9);
            TimeSet.Add(TimeSet10);
            TimeSet.Add(TimeSet11);
            TimeSet.Add(TimeSet12);
            TimeSet.Add(TimeSet13);
            TimeSet.Add(TimeSet14);
            TimeSet.Add(TimeSet15);
            TimeSet.Add(TimeSet16);
            VolSet.Add(VolSet1);
            VolSet.Add(VolSet2);
            VolSet.Add(VolSet3);
            VolSet.Add(VolSet4);
            VolSet.Add(VolSet5);
            VolSet.Add(VolSet6);
            VolSet.Add(VolSet7);
            VolSet.Add(VolSet8);
            VolSet.Add(VolSet9);
            VolSet.Add(VolSet10);
            VolSet.Add(VolSet11);
            VolSet.Add(VolSet12);
            VolSet.Add(VolSet13);
            VolSet.Add(VolSet14);
            VolSet.Add(VolSet15);
            VolSet.Add(VolSet16);
            PowerSet.Add(PowerSet1);
            PowerSet.Add(PowerSet2);
            PowerSet.Add(PowerSet3);
            PowerSet.Add(PowerSet4);
            PowerSet.Add(PowerSet5);
            PowerSet.Add(PowerSet6);
            PowerSet.Add(PowerSet7);
            PowerSet.Add(PowerSet8);
            PowerSet.Add(PowerSet9);
            PowerSet.Add(PowerSet10);
            PowerSet.Add(PowerSet11);
            PowerSet.Add(PowerSet12);
            PowerSet.Add(PowerSet13);
            PowerSet.Add(PowerSet14);
            PowerSet.Add(PowerSet15);
            PowerSet.Add(PowerSet16);
            //InitChart();
        }

        private void InitChart()
        {
            //定义图表区域     
            //this.chart1.ChartAreas.Clear();
            //ChartArea chartArea1 = new ChartArea("C1");
            //this.chart1.ChartAreas.Add(chartArea1);
            //定义存储和显示点的容器     
            //this.chart1.Series.Clear();
            //Series series1 = new Series("S1");
           // series1.ChartArea = "C1";
            //this.chart1.Series.Add(series1);
            //设置图表显示样式     
            this.chart1.ChartAreas[0].AxisY.Minimum = 0;
            this.chart1.ChartAreas[0].AxisY.Maximum = 6000;
            this.chart1.ChartAreas[0].AxisX.Interval = 6;
           // this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            //this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;

            this.chart1.ChartAreas[0].AxisX.Minimum = 0;
            //this.chart1.ChartAreas[0].AxisX.Maximum = 5;
            this.chart1.ChartAreas[0].AxisX.Interval = 0.2;
            //this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            //this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            //设置标题     
           // this.chart1.Titles.Clear();
           // this.chart1.Titles.Add("激光功率波形展示");
            //this.chart1.Titles[0].Text = "功率波形显示";
            //this.chart1.Titles[0].ForeColor = Color.RoyalBlue;
            //this.chart1.Titles[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            //设置图表显示样式     
            //this.chart1.Series[0].Color = Color.Red;
            //if (rb1.Checked)
            //{
            //    this.chart1.Titles[0].Text = string.Format("XXX {0} 显示", rb1.Text);
            //    this.chart1.Series[0].ChartType = SeriesChartType.Line;
            //}
            //if (rb2.Checked)
            //{
               // this.chart1.Titles[0].Text = string.Format("XXX {0} 显示", rb2.Text);
               // this.chart1.Series[0].ChartType = SeriesChartType.Spline;
            //}
            //this.chart1.Series[0].Points.Clear();
        }

        private void 保存波形_Click(object sender, EventArgs e)
        {
            update();
        }
        #region 事件：功率、时间、电压设置事件
        private void TimeSet1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].Times = Convert.ToDouble(TimeSet1.Text);
            }
            catch { }
     
         
        }

        private void VolSet1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].Voltages = Convert.ToDouble(VolSet1.Text);
            }
            catch { }
      
        }

        private void PowerSet1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].Powers = Convert.ToDouble(PowerSet1.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE =Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet1.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet1.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第1段波形"].Voltages = DATE;
                }
            }
            catch { }
          
        }

        private void TimeSet2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第2段波形"].Times = Convert.ToDouble(TimeSet2.Text);
            }
            catch { }
           
        }

        private void TimeSet3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第3段波形"].Times = Convert.ToDouble(TimeSet3.Text);
            }
            catch { }
           
        }

        private void TimeSet4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第4段波形"].Times = Convert.ToDouble(TimeSet4.Text);
            }
            catch { }
           
        }

        private void TimeSet5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第5段波形"].Times = Convert.ToDouble(TimeSet5.Text);
            }
            catch { }
          
        }

        private void TimeSet6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第6段波形"].Times = Convert.ToDouble(TimeSet6.Text);
            }
            catch { }
          
        }

        private void TimeSet7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第7段波形"].Times = Convert.ToDouble(TimeSet7.Text);
            }
            catch { }
          
        }

        private void TimeSet8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第8段波形"].Times = Convert.ToDouble(TimeSet8.Text);
            }
            catch { }
            
        }

        private void TimeSet9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第9段波形"].Times = Convert.ToDouble(TimeSet9.Text);
            }
            catch { }
          
        }

        private void TimeSet10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第10段波形"].Times = Convert.ToDouble(TimeSet10.Text);
            }
            catch { }
           
        }

        private void TimeSet11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第11段波形"].Times = Convert.ToDouble(TimeSet11.Text);
            }
            catch { }
            
        }

        private void TimeSet12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第12段波形"].Times = Convert.ToDouble(TimeSet12.Text);
            }
            catch { }
          
        }

        private void TimeSet13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第13段波形"].Times = Convert.ToDouble(TimeSet13.Text);
            }
            catch { }
           
        }

        private void TimeSet14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第14段波形"].Times = Convert.ToDouble(TimeSet14.Text);
            }
            catch { }
           
        }

        private void TimeSet15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第15段波形"].Times = Convert.ToDouble(TimeSet15.Text);
            }
            catch { }
        
        }

        private void TimeSet16_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第16段波形"].Times = Convert.ToDouble(TimeSet16.Text);
            }
            catch { }
         
        }

        private void VolSet2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第2段波形"].Voltages = Convert.ToDouble(VolSet2.Text);
            }
            catch { }
        
        }

        private void VolSet3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第3段波形"].Voltages = Convert.ToDouble(VolSet3.Text);
            }
            catch { }
        
        }

        private void VolSet4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第4段波形"].Voltages = Convert.ToDouble(VolSet4.Text);
            }
            catch { }
       
        }

        private void VolSet5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第5段波形"].Voltages = Convert.ToDouble(VolSet5.Text);
            }
            catch { }
         
        }

        private void VolSet6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第6段波形"].Voltages = Convert.ToDouble(VolSet6.Text);
            }
            catch { }
      
        }

        private void VolSet7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第7段波形"].Voltages = Convert.ToDouble(VolSet7.Text);
            }
            catch { }
        
        }

        private void VolSet8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第8段波形"].Voltages = Convert.ToDouble(VolSet8.Text);
            }
            catch { }
    
        }

        private void VolSet9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第9段波形"].Voltages = Convert.ToDouble(VolSet9.Text);
            }
            catch { }
     
        }

        private void VolSet10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第10段波形"].Voltages = Convert.ToDouble(VolSet10.Text);
            }
            catch { }
        
        }

        private void VolSet11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第11段波形"].Voltages = Convert.ToDouble(VolSet11.Text);
            }
            catch { }
     
        }

        private void VolSet12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第12段波形"].Voltages = Convert.ToDouble(VolSet12.Text);
            }
            catch { }
     
        }

        private void VolSet13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第13段波形"].Voltages = Convert.ToDouble(VolSet13.Text);
            }
            catch { }
       
        }

        private void VolSet14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第14段波形"].Voltages = Convert.ToDouble(VolSet14.Text);
            }
            catch { }
        
        }

        private void VolSet15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第15段波形"].Voltages = Convert.ToDouble(VolSet15.Text);
            }
            catch { }
 
        }

        private void VolSet16_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第16段波形"].Voltages = Convert.ToDouble(VolSet16.Text);
            }
            catch { }
        
        }

        private void PowerSet2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第2段波形"].Powers = Convert.ToDouble(PowerSet2.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet2.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet2.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第2段波形"].Voltages = DATE;
                }

            }
            catch { }
        
        }

        private void PowerSet3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第3段波形"].Powers = Convert.ToDouble(PowerSet3.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet3.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet3.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第3段波形"].Voltages = DATE;
                }
            }
            catch { }
     
        }

        private void PowerSet4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第4段波形"].Powers = Convert.ToDouble(PowerSet4.Text);
                if (最大电压.Text!="0"&& 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet4.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet4.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第4段波形"].Voltages = DATE;
                }
                
            }
            catch { }
        
        }

        private void PowerSet5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第5段波形"].Powers = Convert.ToDouble(PowerSet5.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet5.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet5.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第5段波形"].Voltages = DATE;
                }
            }
            catch { }
         
        }

        private void PowerSet6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第6段波形"].Powers = Convert.ToDouble(PowerSet6.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet6.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet6.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第6段波形"].Voltages = DATE;
                }
            }
            catch { }
      
        }

        private void PowerSet7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第7段波形"].Powers = Convert.ToDouble(PowerSet7.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet7.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet7.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第7段波形"].Voltages = DATE;
                }
            }
            catch { }
    
        }

        private void PowerSet8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第8段波形"].Powers = Convert.ToDouble(PowerSet8.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet8.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet8.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第8段波形"].Voltages = DATE;
                }
            }
            catch { }
       
        }

        private void PowerSet9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第9段波形"].Powers = Convert.ToDouble(PowerSet9.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet9.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet9.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第9段波形"].Voltages = DATE;
                }
            }
            catch { }
       
        }

        private void PowerSet10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第10段波形"].Powers = Convert.ToDouble(PowerSet10.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet10.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet10.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第10段波形"].Voltages = DATE;
                }
            }
            catch { }
    
        }

        private void PowerSet11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第11段波形"].Powers = Convert.ToDouble(PowerSet11.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet11.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet11.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第11段波形"].Voltages = DATE;
                }
            }
            catch { }
  
        }

        private void PowerSet12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第12段波形"].Powers = Convert.ToDouble(PowerSet12.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet12.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet12.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第12段波形"].Voltages = DATE;
                }
            }
            catch { }
        
        }

        private void PowerSet13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第13段波形"].Powers = Convert.ToDouble(PowerSet13.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet13.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet13.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第13段波形"].Voltages = DATE;
                }
            }
            catch { }
         
        }

        private void PowerSet14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第14段波形"].Powers = Convert.ToDouble(PowerSet14.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet14.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet14.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第14段波形"].Voltages = DATE;
                }
            }
            catch { }
      
        }

        private void PowerSet15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第15段波形"].Powers = Convert.ToDouble(PowerSet15.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet15.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet15.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第15段波形"].Voltages = DATE;
                }
            }
            catch { }
            
        }

        private void PowerSet16_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第16段波形"].Powers = Convert.ToDouble(PowerSet16.Text);
                if (最大电压.Text != "0" && 最大功率.Text != "0")
                {
                    double DATE = Math.Round((Convert.ToDouble(最大电压.Text) * Convert.ToDouble(PowerSet16.Text)) / Convert.ToDouble(最大功率.Text),3);
                    VolSet16.Text = DATE.ToString();
                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第16段波形"].Voltages = DATE;
                }
            }
            catch { }
         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(最大电压.Text);
                if (num > 10)
                {
                    最大电压.Text = volto;
                }
                else { 
                int count = 1;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(label1.Text))
                    {
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].High_Voltage = Convert.ToDouble(最大电压.Text);
                        count++;
                    }
                }
              }
            }
            catch
            {
               // 最大电压.Text = volto;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(最大功率.Text);
                if (num > 6000)
                {
                    最大功率.Text = power;
                }
                else
                {
                    int count = 1;
                    foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                    {
                        if (item.Value.Wave_hardwareName.Contains(label1.Text))
                        {
                            Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].High_Power = Convert.ToDouble(最大功率.Text);
                            count++;
                        }
                    }
                }
            }
            catch { 
                //最大功率.Text = power; 
            }          
        }
        #endregion
        public void update()
        {
            InitChart();
            this.chart1.Series[0].Points.Clear();
            double  times = 0;
            this.chart1.Series[0].Points.AddXY(0, 0);
            this.chart1.Series[0].Name = label1.Text;
            foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
            {
                //if (item.Value.Wave_hardwareName.Contains(label1.Text))
                //{

                //    this.chart1.Series[0].Points.AddXY(Math.Round(times, 1), (float)item.Value.Powers);
                //}

                if (item.Value.Wave_hardwareName.Contains(label1.Text))
                {
                    times = (item.Value.Times / 1000) + times;
                    this.chart1.Series[0].Points.AddXY(times, (float)item.Value.Powers);
                }
            }
        }

        private void Wave_channel__TextChanged(object sender, EventArgs e)
        {
            try
            {
                int count = 1;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(label1.Text))
                    {
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].Wave_channel_num = Convert.ToInt16(Wave_channel_.Text);
                        count++;
                    }
                }
            }
            catch { }
        }

        private void Wave_channel_Card__TextChanged(object sender, EventArgs e)
        {
            try
            {
                int count = 1;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(label1.Text))
                    {
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].Wave_channel_Card_num = Convert.ToInt16(Wave_channel_Card_.Text);
                        count++;
                    }
                }
            }
            catch { }
        }

        private void laserPowerMode_TextChanged(object sender, EventArgs e)
        {
            if (laserPowerMode.Text !="")
            {
           
            try
            {
                int count = 1;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(label1.Text))
                    {
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].laserPowerMode = Convert.ToInt16(laserPowerMode.Text);
                        count++;
                    }
                }
            }
            catch { }
            }

        }

        //private void Choose_Laser_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (Choose_Laser.Checked == true)
        //    {
        //        Choose_Laser.BackColor = Color.Green;
        //        try
        //        {
        //            int count = 1;
        //            foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
        //            {
        //                if (item.Value.Wave_hardwareName.Contains(label1.Text))
        //                {
        //                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].IS_Choose_Laser = true;
        //                    count++;
        //                }
        //            }
        //        }
        //        catch { }
        //     //   Hard_Ward_Contral._LaserControlParameter._LaserControlData_Dictionary["LaserControlData"].IS_Choose_Laser = true;
              
        //    }
        //    else
        //    {
        //        try
        //        {
        //            Choose_Laser.BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Control);
        //            int count = 1;
        //            foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
        //            {
        //                if (item.Value.Wave_hardwareName.Contains(label1.Text))
        //                {
        //                    Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].IS_Choose_Laser = false;
        //                    count++;
        //                }
        //            }
        //        }
        //        catch { }

        //    }
        //}
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
        private void PowerSet1_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void Wave_channel__KeyPress(object sender, KeyPressEventArgs e)
        {
            //_KeyPress(sender, e);
        }

        private void 最大功率_KeyPress(object sender, KeyPressEventArgs e)
        {
            //_KeyPress(sender, e);
        }
        private void Wave_channel__KeyPress_1(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }

        private void 最大电压_KeyPress_1(object sender, KeyPressEventArgs e)
        {
           
            _KeyPress(sender, e);

        }

        private void 最大电压_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int count = 1;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(label1.Text))
                    {
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].High_Voltage = Convert.ToDouble(最大电压.Text);
                        count++;
                    }
                }
            }
            catch { }
        }


        private void 最大功率1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {            
                    _KeyPress(sender, e);               
            } 
            catch { }              
           
        }
        string power, volto;

        private void 最大电压_MouseEnter(object sender, EventArgs e)
        {
            volto = 最大电压.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double date = 0.0;
            //卡号
            //通道号
            //数据
            uint clk1;
            double dbRet = 0.0;
            //double dbRet = 0.0;
            short rtn = gts.mc.GT_GetAdc(0/*usCardNo*/, 2, out dbRet, 1, out clk1);
            label6.Text = dbRet.ToString();
            label7.Text = Hard_Ward_Contral.currentV.ToString();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Googol_Contral.GT_SetAdc();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Googol_Contral.LaserControl_async_Fun(label1.Text );
        }

        private void Wave_channel__SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Wave_channel_.Text !="")
            { 
            try
            {
                int count = 1;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(label1.Text))
                    {
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].Wave_channel_num = Convert.ToInt16(Wave_channel_.Text);
                        count++;
                    }
                }
            }
            catch { }
            }
        }

        private void Wave_channel_Card__SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Wave_channel_Card_.Text !="")
            {
            try
            {
                int count = 1;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(label1.Text))
                    {
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].Wave_channel_Card_num = Convert.ToInt16(Wave_channel_Card_.Text);
                        count++;
                    }
                }
            }
            catch { }
            }
        }
        static Thread sd = null;
        static object name = null;
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult DResult = MessageBox.Show("是否输出模拟量", "提示", MessageBoxButtons.YesNo);
            if (DResult == DialogResult.Yes)
            {
                Googol_Contral.LaserControl_async_Fun(label1.Text);
            }
            else
            {
                return;
            }
       
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            波形展示 波形展示 = new 波形展示();
            波形展示.Show();
        }

        private void 高速IO口1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int count = 1;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(label1.Text))
                    {
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第"+count+"段波形"].高速IO激光口1 = 高速IO口1.Text;
                        count++;
                    }
                }
            }
            catch { }
        }

        private void 高速IO口2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int count = 1;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(label1.Text))
                    {
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].高速IO激光口2 = 高速IO口2.Text;
                        count++;
                    }
                }
            }
            catch { }
        }

        private void 高速IO口3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int count = 1;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(label1.Text))
                    {
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].高速IO激光口3 = 高速IO口3.Text;
                        count++;
                    }
                }
            }
            catch { }
        }

        private void 高速IO口4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int count = 1;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(label1.Text))
                    {
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].高速IO激光口4 = 高速IO口4.Text;
                        count++;
                    }
                }
            }
            catch { }
        }

        private void 高速IO口激光完成_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int count = 1;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(label1.Text))
                    {
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].高速IO口激光完成 = 高速IO口激光完成.Text;
                        count++;
                    }
                }
            }
            catch { }
        }

        private void 高速IO输出口_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int count = 1;
                foreach (var item in Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary)
                {
                    if (item.Value.Wave_hardwareName.Contains(label1.Text))
                    {
                        Hard_Ward_Contral.Wave_Date_Save_Doc.Wave_Date_Dictionary[label1.Text + "_" + "第" + count + "段波形"].高速IO输出口 = 高速IO输出口.Text;
                        count++;
                    }
                }
            }
            catch { }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Googol_Contral.sort(label1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Googol_Contral.LaserControl_async_(label1.Text);
        }

        private void 最大功率_MouseEnter(object sender, EventArgs e)
        {
            power = 最大功率.Text;
        }
    }
}
