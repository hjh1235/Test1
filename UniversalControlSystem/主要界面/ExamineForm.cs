using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public partial class ExamineForm : Form
    {
        public static int SelectCount1 = 0;
        public static int SelectCount2 = 0;
        public List<string> PointList = new List<string>();

        public static Action<string> action = (worktypr) => { };

        public DefintionFun m_defintionFun = new DefintionFun();
        public ExamineForm()
        {
            InitializeComponent();
        }

        private void ExamineForm_Load(object sender, EventArgs e)
        {
            action += (worktpye) => 
            {
                this.BeginInvoke(new Action(() => { UpdateStartView(worktpye); }));
            };
            pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "jzqx.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public void UpdateStartView(string WorkType)
        {
            if(WorkType=="清洗")
            {
                lab_清洗点检.Text = "已完成";
                lab_清洗点检时间.Text = Properties.Settings.Default.清洗点检完成时间;
            }
            if(WorkType=="左测高")
            {
                lab_左测高点检.Text = "已完成";
                lab_左测高点检时间.Text = Properties.Settings.Default.左测高点检完成时间;
            }
            if(WorkType == "右测高")
            {
                lab_右测高点检.Text = "已完成";
                lab_右测高点检时间.Text = Properties.Settings.Default.右测高点检完成时间;
            }
            if(WorkType=="CCD左")
            {
                lab_左CCD点检.Text= "已完成";
                lab_左CCD点检时间.Text = Properties.Settings.Default.左CCD点检完成时间;
            }
            if (WorkType == "CCD右")
            {
                lab_右CCD点检.Text = "已完成";
                lab_右CCD点检时间.Text = Properties.Settings.Default.右CCD点检完成时间;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
            {
                e.Handled = true;
            }
            
        }
        private void btn_NextStep_Click(object sender, EventArgs e)
        {
            if (!Program.bAuto || Program.bInt || !FormStart.bAllAxisHomed)
            {
                MessageBox.Show("请先回原点初始化,运行点检流程");
                return;
            }
            if((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["点检开始标志"].Date == true)
            {
                MessageBox.Show("请勿重复点击!!");
                return;
            }
            if (textBox1.Text == "") return;
            int number = int.Parse(textBox1.Text);
            textBox1.Text = number.ToString();
            if (number <= 196)
            {
                if (number > 16 && number < 39)
                {
                    MessageBox.Show($"{number}不是右工位点位,请重新选择");
                    textBox1.Text = "";
                    return;
                }
                if (number > 56 && number < 79)
                {
                    MessageBox.Show($"{number}不是右工位点位,请重新选择");
                    textBox1.Text = "";
                    return;
                }
                if (number > 96 && number < 119)
                {
                    MessageBox.Show($"{number}不是右工位点位,请重新选择");
                    textBox1.Text = "";
                    return;
                }
                if (number > 136 && number < 159)
                {
                    MessageBox.Show($"{number}不是右工位点位,请重新选择");
                    textBox1.Text = "";
                    return;
                }
                if (number > 174)
                {
                    MessageBox.Show($"{number}不是右工位点位,请重新选择");
                    textBox1.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("不允许输入值大于196!请重新输入");
                textBox1.Text = "";
                return;
            }
            if (textBox2.Text == "") return;
            int number2 = int.Parse(textBox2.Text);
            textBox2.Text = number2.ToString();
            if (number2 <= 196)
            {

                if (number2 < 17)
                {
                    MessageBox.Show($"{number2}不是左工位点位,请重新选择");
                    textBox2.Text = "";
                    return;
                }
                if (number2 > 38 && number2 < 57)
                {
                    MessageBox.Show($"{number2}不是左工位点位,请重新选择");
                    textBox2.Text = "";
                    return;
                }
                if (number2 > 78 && number2 < 97)
                {
                    MessageBox.Show($"{number2}不是左工位点位,请重新选择");
                    textBox2.Text = "";
                    return;
                }
                if (number2 > 118 && number2 < 137)
                {
                    MessageBox.Show($"{number2}不是左工位点位,请重新选择");
                    textBox2.Text = "";
                    return;
                }
                if (number2 > 158 && number2 < 175)
                {
                    MessageBox.Show($"{number2}不是左工位点位,请重新选择");
                    textBox2.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("不允许输入值大于196!请重新输入");
                textBox2.Text = "";
                return;
            }
            SelectCount1 = int.Parse(textBox1.Text);
            SelectCount2 = int.Parse(textBox2.Text);
            btn_CCDDJ.Enabled = false;
            btn_测高DJ.Enabled = false;
            if (SelectCount1 == SelectCount2)
            {
                MessageBox.Show("请勿选择同一个点,请修改!!!");
                return;

            }
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["点检开始标志"].Date = true;
            }            
            else
            {
                MessageBox.Show("点位选择不能为空!!!");
                return;
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 拷贝文件到另一个文件夹下
        /// </summary>
        /// <param name="sourceName">源文件路径</param>
        /// <param name="folderPath">目标路径（目标文件夹）</param>
        public void CopyToFile(string sourceName, string folderPath)
        {
            string sourceFile = sourceName;
            string destinationFile = folderPath;
            FileInfo file = new FileInfo(sourceFile);
            if (file.Exists)
            {
                // true 覆盖 false 不覆盖 
                file.CopyTo(destinationFile,true);
            }
        }
        private void ExamineForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormStart.bExamineFormHide = false;
            this.Hide();
            e.Cancel = true;
        }
        public void ReadCSV(string Path, out List<string> Data)
        {
            StreamReader str;
            Data = new List<string>();
            try
            {
                using (str = new StreamReader(Path, Encoding.GetEncoding("GBK"))) ;
                string Buff = "";
                while ((Buff = str.ReadLine()) != null)
                {
                    Data.Add(Buff);
                }
            }
            catch (Exception ex)
            {
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.ToUpper().Equals("EXCEL"))
                        process.Kill();
                }
                GC.Collect();
                Thread.Sleep(10);
                Console.WriteLine(ex.StackTrace);
                using (str = new StreamReader(Path, Encoding.GetEncoding("GBK")))
                {
                    string Buff = "";
                    while ((Buff = str.ReadLine()) != null)
                    {
                        Data.Add(Buff);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            if((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["点检开始标志"].Date == true&& (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD点检标志位"].Date == false
                && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["测高点检标志位"].Date == false)
            {
                btn_CCDDJ.Enabled = false;
                btn_测高DJ.Enabled = false;
            }
            else if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["点检开始标志"].Date == false && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD点检标志位"].Date == true
                && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["测高点检标志位"].Date == false)
            {
                btn_Weld.Enabled = false;
                btn_测高DJ.Enabled = false;
            }
            else if ((bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["点检开始标志"].Date == false && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD点检标志位"].Date == false
                && (bool)Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["测高点检标志位"].Date == true)
            {
                btn_CCDDJ.Enabled = false;
                btn_测高DJ.Enabled = false;
            }
            else
            {
                btn_Weld.Enabled = true;
                btn_测高DJ.Enabled = true;
                btn_CCDDJ.Enabled = true;
            }
        }

        private void btn_CCDDJ_Click(object sender, EventArgs e)
        {
            if (!Program.bAuto || Program.bInt || !FormStart.bAllAxisHomed)
            {
                MessageBox.Show("请先回原点初始化,运行点检流程");
                return;
            }
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["CCD点检标志位"].Date = true;
        }

        private void btn_测高DJ_Click(object sender, EventArgs e)
        {
            if (!Program.bAuto || Program.bInt || !FormStart.bAllAxisHomed)
            {
                MessageBox.Show("请先回原点初始化,运行点检流程");
                return;
            }
            Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary["测高点检标志位"].Date = true;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.清洗点检完成)
            {
                
            }
        }
    }
}
