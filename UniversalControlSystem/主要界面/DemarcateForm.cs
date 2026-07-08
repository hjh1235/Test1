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
    public partial class DemarcateForm : Form
    {
        string LoadPaperAixsName = "取料轴Y";
        string CCDTaska_A_AixsName = "喷码载盘左";
        string CCDTaska_B_AixsName = "喷码载盘右";
        string LaserAixsName = "激光Y轴";
        string Ari_Brush_AixsName = "拍照补偿轴";
        string 下料AixsName = "下料X轴";
        string Fascicule_AixsName = "分堆底部接料X轴";

        public DemarcateForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            左平激1.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激1 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴1.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴1 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴1);
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            左平激2.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激2 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴2.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴2 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            左平激3.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激3 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴3.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴3 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            左平激4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激4 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴4 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            左平激5.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激5 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴5.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴5 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            左平激6.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激6= Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴6.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴6 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            左平激7.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激7 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴7.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴7 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            左平激8.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激8 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴8.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴8 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            左平激9.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激9 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴9.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴9 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴2);
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴3);
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴4);
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激4);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴5);
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激5);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴6);
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激6);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴7);
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激7);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴8);
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激8);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴9);
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激9);
        }

        private void 左平激1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激1 = Convert.ToDouble(左平激1.Text);
            }
            catch 
            {
            }
        }

        private void 左平激2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激2 = Convert.ToDouble(左平激2.Text);
            }
            catch
            {
            }
        }

        private void 左平激3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激3 = Convert.ToDouble(左平激3.Text);
            }
            catch
            {
            }
        }

        private void 左平激4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激4 = Convert.ToDouble(左平激4.Text);
            }
            catch
            {
            }
        }

        private void 左平激5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激5= Convert.ToDouble(左平激5.Text);
            }
            catch
            {
            }
        }

        private void 左平激6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激6 = Convert.ToDouble(左平激6.Text);
            }
            catch
            {
            }
        }

        private void 左平激7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激7 = Convert.ToDouble(左平激7.Text);
            }
            catch
            {
            }
        }

        private void 左平激8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激8 = Convert.ToDouble(左平激8.Text);
            }
            catch
            {
            }
        }

        private void 左平激9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激9 = Convert.ToDouble(左平激9.Text);
            }
            catch
            {
            }
        }

        private void 激与左轴1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴1 = Convert.ToDouble(激与左轴1.Text);
            }
            catch
            {
            }
   
        }

        private void 激与左轴2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴2 = Convert.ToDouble(激与左轴2.Text);
            }
            catch
            {
            }

        }

        private void 激与左轴3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴3= Convert.ToDouble(激与左轴3.Text);
            }
            catch
            {
            }

        }

        private void 激与左轴4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴4 = Convert.ToDouble(激与左轴4.Text);
            }
            catch
            {
            }

        }

        private void 激与左轴5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴5 = Convert.ToDouble(激与左轴5.Text);
            }
            catch
            {
            }

        }

        private void 激与左轴6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴6= Convert.ToDouble(激与左轴6.Text);
            }
            catch
            {
            }

        }

        private void 激与左轴7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴7 = Convert.ToDouble(激与左轴7.Text);
            }
            catch
            {
            }

        }

        private void 激与左轴8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴8 = Convert.ToDouble(激与左轴8.Text);
            }
            catch
            {
            }

        }

        private void 激与左轴9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴9 = Convert.ToDouble(激与左轴9.Text);
            }
            catch
            {
            }

        }

        private void button36_Click(object sender, EventArgs e)
        {
            左平喷1.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平喷1 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            喷左平1.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷左平1 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            左平喷2.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平喷2 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            喷左平2.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷左平2 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            左平喷3.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平喷3 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            喷左平3.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷左平3 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            左平喷4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平喷4 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            喷左平4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷左平4= Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            左平喷5.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平喷5 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            喷左平5.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷左平5 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            左平喷6.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平喷6 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            喷左平6.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷左平6= Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            左平喷7.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平喷7 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            喷左平7.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷左平7 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            左平喷8.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平喷8 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            喷左平8.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷左平8 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            左平喷9.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平喷9 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            喷左平9.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷左平9 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平喷1);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷左平1);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平喷2);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷左平2);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平喷3);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷左平3);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平喷4);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷左平4);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平喷5);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷左平5);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平喷6);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷左平6);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平喷7);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷左平7);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平喷8);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷左平8);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平喷9);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷左平9);
        }

        private void 左平喷1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平喷1 = Convert.ToDouble(左平喷1.Text);
            }
            catch
            {
            }
        }

        private void 左平喷2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平喷2 = Convert.ToDouble(左平喷2.Text);
            }
            catch
            {
            }
        }

        private void 左平喷3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平喷3 = Convert.ToDouble(左平喷3.Text);
            }
            catch
            {
            }
        }

        private void 左平喷4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平喷4 = Convert.ToDouble(左平喷4.Text);
            }
            catch
            {
            }
        }

        private void 左平喷5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平喷5 = Convert.ToDouble(左平喷5.Text);
            }
            catch
            {
            }
        }

        private void 左平喷6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平喷6 = Convert.ToDouble(左平喷6.Text);
            }
            catch
            {
            }
        }

        private void 左平喷7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平喷7 = Convert.ToDouble(左平喷7.Text);
            }
            catch
            {
            }
        }

        private void 左平喷8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平喷8 = Convert.ToDouble(左平喷8.Text);
            }
            catch
            {
            }
        }

        private void 左平喷9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平喷9 = Convert.ToDouble(左平喷9.Text);
            }
            catch
            {
            }
        }

        private void 喷左平1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷左平1 = Convert.ToDouble(喷左平1.Text);
            }
            catch
            {
            }
        }

        private void 喷左平2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷左平2 = Convert.ToDouble(喷左平2.Text);
            }
            catch
            {
            }
        }

        private void 喷左平3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷左平3 = Convert.ToDouble(喷左平3.Text);
            }
            catch
            {
            }
        }

        private void 喷左平4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷左平4 = Convert.ToDouble(喷左平4.Text);
            }
            catch
            {
            }
        }

        private void 喷左平5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷左平5 = Convert.ToDouble(喷左平5.Text);
            }
            catch
            {
            }
        }

        private void 喷左平6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷左平6 = Convert.ToDouble(喷左平6.Text);
            }
            catch
            {
            }
        }

        private void 喷左平7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷左平7 = Convert.ToDouble(喷左平7.Text);
            }
            catch
            {
            }
        }

        private void 喷左平8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷左平8 = Convert.ToDouble(喷左平8.Text);
            }
            catch
            {
            }
        }

        private void 喷左平9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷左平9 = Convert.ToDouble(喷左平9.Text);
            }
            catch
            {
            }
        }

        private void button72_Click(object sender, EventArgs e)
        {
            右平激1.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激1 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴1.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴1 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button70_Click(object sender, EventArgs e)
        {
            右平激2.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激2 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴2.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴2 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button68_Click(object sender, EventArgs e)
        {
            右平激3.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激3 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴3.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴3 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            右平激4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激4 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴4 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            右平激5.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激5 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴5.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴5 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button62_Click(object sender, EventArgs e)
        {
            右平激6.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激6 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴6.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴6 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            右平激7.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激7 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴7.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴7 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            右平激8.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激8 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴8.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴8 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            右平激9.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激9= Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴9.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴9 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button71_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激1);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴1);
        }

        private void button69_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激2);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴2);
        }

        private void button67_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激3);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴3);
        }

        private void button65_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激4);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴4);
        }

        private void button63_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激5);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴5);
        }

        private void button61_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激6);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴6);
        }

        private void button57_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激7);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴7);
        }

        private void button59_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激8);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴8);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激9);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴9);
        }

        private void 右平激1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激1 = Convert.ToDouble(右平激1.Text);
            }
            catch
            {
            }
        }

        private void 右平激2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激2 = Convert.ToDouble(右平激2.Text);
            }
            catch
            {
            }
        }

        private void 右平激3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激3 = Convert.ToDouble(右平激3.Text);
            }
            catch
            {
            }
        }

        private void 右平激4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激4 = Convert.ToDouble(右平激4.Text);
            }
            catch
            {
            }
        }

        private void 右平激5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激5 = Convert.ToDouble(右平激5.Text);
            }
            catch
            {
            }
        }

        private void 右平激6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激6 = Convert.ToDouble(右平激6.Text);
            }
            catch
            {
            }
        }

        private void 右平激7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激7 = Convert.ToDouble(右平激7.Text);
            }
            catch
            {
            }
        }

        private void 右平激8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激8= Convert.ToDouble(右平激8.Text);
            }
            catch
            {
            }
        }

        private void 右平激9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激9 = Convert.ToDouble(右平激9.Text);
            }
            catch
            {
            }
        }

        private void button54_Click(object sender, EventArgs e)
        {
            右平喷1.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平喷1 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            喷右平1.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷右平1 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            右平喷2.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平喷2 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            喷右平2.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷右平2 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            右平喷3.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平喷3 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            喷右平3.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷右平3 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            右平喷4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平喷4= Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            喷右平4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷右平4 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            右平喷5.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平喷5 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            喷右平5.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷右平5 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            右平喷6.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平喷6 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            喷右平6.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷右平6 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            右平喷7.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平喷7= Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            喷右平7.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷右平7= Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            右平喷8.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平喷8 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            喷右平8.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷右平8 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            右平喷9.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平喷9 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            喷右平9.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷右平9 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平喷1);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷右平1);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平喷9);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷右平9);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平喷2);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷右平2);
        }

        private void button49_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平喷3);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷右平3);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平喷4);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷右平4);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平喷5);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷右平5);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平喷6);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷右平6);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平喷7);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷右平7);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平喷8);
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷右平8);
        }

        private void 右平喷1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平喷1 = Convert.ToDouble(右平喷1.Text);
            }
            catch
            {
            }
      
        }

        private void 右平喷2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平喷2 = Convert.ToDouble(右平喷2.Text);
            }
            catch
            {
            }
        }

        private void 右平喷3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平喷3 = Convert.ToDouble(右平喷3.Text);
            }
            catch
            {
            }
        }

        private void 右平喷4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平喷4 = Convert.ToDouble(右平喷4.Text);
            }
            catch
            {
            }
        }

        private void 右平喷5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平喷5 = Convert.ToDouble(右平喷5.Text);
            }
            catch
            {
            }
        }

        private void 右平喷6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平喷6 = Convert.ToDouble(右平喷6.Text);
            }
            catch
            {
            }
        }

        private void 右平喷7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平喷7= Convert.ToDouble(右平喷7.Text);
            }
            catch
            {
            }
        }

        private void 右平喷8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平喷8 = Convert.ToDouble(右平喷8.Text);
            }
            catch
            {
            }
        }

        private void 右平喷9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平喷9 = Convert.ToDouble(右平喷9.Text);
            }
            catch
            {
            }
        }

        private void 喷右平1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷右平1 = Convert.ToDouble(喷右平1.Text);
            }
            catch
            {
            }
        }

        private void 喷右平2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷右平2 = Convert.ToDouble(喷右平2.Text);
            }
            catch
            {
            }
        }

        private void 喷右平3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷右平3 = Convert.ToDouble(喷右平3.Text);
            }
            catch
            {
            }
        }

        private void 喷右平4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷右平4 = Convert.ToDouble(喷右平4.Text);
            }
            catch
            {
            }
        }

        private void 喷右平5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷右平5 = Convert.ToDouble(喷右平5.Text);
            }
            catch
            {
            }
        }

        private void 喷右平6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷右平6 = Convert.ToDouble(喷右平6.Text);
            }
            catch
            {
            }
        }

        private void 喷右平7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷右平7 = Convert.ToDouble(喷右平7.Text);
            }
            catch
            {
            }
        }

        private void 喷右平8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷右平8 = Convert.ToDouble(喷右平8.Text);
            }
            catch
            {
            }
        }

        private void 喷右平9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷右平9 = Convert.ToDouble(喷右平9.Text);
            }
            catch
            {
            }
        }

        private void button90_Click(object sender, EventArgs e)
        {
            左平激1线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激1线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴1线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴1线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button88_Click(object sender, EventArgs e)
        {
            左平激2线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激2线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴2线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴2线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button86_Click(object sender, EventArgs e)
        {
            左平激3线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激3线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴3线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴3线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button84_Click(object sender, EventArgs e)
        {
            左平激4线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激4线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴4线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴4线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button82_Click(object sender, EventArgs e)
        {
            左平激5线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激5线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴5线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴5线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button80_Click(object sender, EventArgs e)
        {
            左平激6线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激6线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴6线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴6线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button76_Click(object sender, EventArgs e)
        {
            左平激7线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激7线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴7线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴7线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button78_Click(object sender, EventArgs e)
        {
            左平激8线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激8线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴8线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴8线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            左平激9线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激9线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴9线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴9线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button108_Click(object sender, EventArgs e)
        {
            右平激1线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激1线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴1线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴1线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button106_Click(object sender, EventArgs e)
        {
            右平激2线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激2线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴2线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴2线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button104_Click(object sender, EventArgs e)
        {
            右平激3线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激3线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴3线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴3线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button102_Click(object sender, EventArgs e)
        {
            右平激4线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激4线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴4线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴4线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button100_Click(object sender, EventArgs e)
        {
            右平激5线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激5线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴5线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴5线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button98_Click(object sender, EventArgs e)
        {
            右平激6线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激6线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴6线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴6线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button94_Click(object sender, EventArgs e)
        {
            右平激7线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激7线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴7线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴7线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button96_Click(object sender, EventArgs e)
        {
            右平激8线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激8线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴8线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴8线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button92_Click(object sender, EventArgs e)
        {
            右平激9线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激9线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴9线扫.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴9线扫 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button89_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激1线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴1线扫);
    
        }

        private void button87_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激2线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴2线扫);
        }

        private void button85_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激3线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴3线扫);
        }

        private void button83_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激4线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴4线扫);
        }

        private void button81_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激5线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴5线扫);
        }

        private void button79_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激6线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴6线扫);
        }

        private void button75_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激7线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴7线扫);
        }

        private void button77_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激8线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴8线扫);
        }

        private void button73_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激9线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴9线扫);
        }

        private void button107_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激1线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴1线扫);

        }

        private void button105_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激2线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴2线扫);
        }

        private void button103_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激3线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴3线扫);
        }

        private void button101_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激4线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴4线扫);
        }

        private void button99_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激5线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴5线扫);
        }

        private void button97_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激6线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴6线扫);
        }

        private void button93_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激7线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴7线扫);
        }

        private void button95_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激8线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴8线扫);
        }

        private void button91_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激9线扫);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴9线扫);
        }

        private void 左平激1线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激1线扫 = Convert.ToDouble(左平激1线扫.Text);
            }
            catch
            {
            }
        }

        private void 左平激2线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激2线扫 = Convert.ToDouble(左平激2线扫.Text);
            }
            catch
            {
            }
        }

        private void 左平激3线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激3线扫 = Convert.ToDouble(左平激3线扫.Text);
            }
            catch
            {
            }
        }

        private void 左平激4线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激4线扫 = Convert.ToDouble(左平激4线扫.Text);
            }
            catch
            {
            }
        }

        private void 左平激5线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激5线扫 = Convert.ToDouble(左平激5线扫.Text);
            }
            catch
            {
            }
        }

        private void 左平激6线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激6线扫 = Convert.ToDouble(左平激6线扫.Text);
            }
            catch
            {
            }
        }

        private void 左平激7线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激7线扫 = Convert.ToDouble(左平激7线扫.Text);
            }
            catch
            {
            }
        }

        private void 左平激8线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激8线扫 = Convert.ToDouble(左平激8线扫.Text);
            }
            catch
            {
            }
        }

        private void 左平激9线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激9线扫 = Convert.ToDouble(左平激9线扫.Text);
            }
            catch
            {
            }
        }

        private void 右平激1线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激1线扫 = Convert.ToDouble(右平激1线扫.Text);
            }
            catch
            {
            }
        }

        private void 右平激2线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激2线扫 = Convert.ToDouble(右平激2线扫.Text);
            }
            catch
            {
            }
        }

        private void 右平激3线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激3线扫 = Convert.ToDouble(右平激3线扫.Text);
            }
            catch
            {
            }
        }

        private void 右平激4线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激4线扫 = Convert.ToDouble(右平激4线扫.Text);
            }
            catch
            {
            }
        }

        private void 右平激5线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激5线扫 = Convert.ToDouble(右平激5线扫.Text);
            }
            catch
            {
            }
        }

        private void 右平激6线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激6线扫 = Convert.ToDouble(右平激6线扫.Text);
            }
            catch
            {
            }
        }

        private void 右平激7线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激7线扫 = Convert.ToDouble(右平激7线扫.Text);
            }
            catch
            {
            }
        }

        private void 右平激8线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激8线扫 = Convert.ToDouble(右平激8线扫.Text);
            }
            catch
            {
            }
        }

        private void 右平激9线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激9线扫 = Convert.ToDouble(右平激9线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与左轴1线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴1线扫 = Convert.ToDouble(激与左轴1线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与左轴2线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴2线扫 = Convert.ToDouble(激与左轴2线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与左轴3线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴3线扫 = Convert.ToDouble(激与左轴3线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与左轴4线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴4线扫 = Convert.ToDouble(激与左轴4线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与左轴5线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴5线扫 = Convert.ToDouble(激与左轴5线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与左轴6线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴6线扫 = Convert.ToDouble(激与左轴6线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与左轴7线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴7线扫 = Convert.ToDouble(激与左轴7线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与左轴8线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴8线扫 = Convert.ToDouble(激与左轴8线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与左轴9线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴9线扫 = Convert.ToDouble(激与左轴9线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴1= Convert.ToDouble(激与右轴1.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴2 = Convert.ToDouble(激与右轴2.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴3 = Convert.ToDouble(激与右轴3.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴4 = Convert.ToDouble(激与右轴4.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴5 = Convert.ToDouble(激与右轴5.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴6 = Convert.ToDouble(激与右轴6.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴7 = Convert.ToDouble(激与右轴7.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴8 = Convert.ToDouble(激与右轴8.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴9 = Convert.ToDouble(激与右轴9.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴9线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴9线扫 = Convert.ToDouble(激与右轴9线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴8线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴8线扫 = Convert.ToDouble(激与右轴8线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴7线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴7线扫 = Convert.ToDouble(激与右轴7线扫.Text);
            }
            catch
            {
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void 激与右轴6线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴6线扫 = Convert.ToDouble(激与右轴6线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴5线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴5线扫 = Convert.ToDouble(激与右轴5线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴4线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴4线扫 = Convert.ToDouble(激与右轴4线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴3线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴3线扫 = Convert.ToDouble(激与右轴3线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴2线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴2线扫 = Convert.ToDouble(激与右轴2线扫.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴1线扫_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴1线扫 = Convert.ToDouble(激与右轴1线扫.Text);
            }
            catch
            {
            }
        }

        private void button109_Click(object sender, EventArgs e)
        {
            DateSave.Instance().SaveDoc();
        }

        private void DemarcateForm_Load(object sender, EventArgs e)
        {
            左平激1.Text= DateSave.Instance().Production.左平激1.ToString ();
            左平激2.Text = DateSave.Instance().Production.左平激2.ToString();
            左平激3.Text = DateSave.Instance().Production.左平激3.ToString();
            左平激4.Text = DateSave.Instance().Production.左平激4.ToString();
            左平激5.Text = DateSave.Instance().Production.左平激5.ToString();
            左平激6.Text = DateSave.Instance().Production.左平激6.ToString();
            左平激7.Text = DateSave.Instance().Production.左平激7.ToString();
            左平激8.Text = DateSave.Instance().Production.左平激8.ToString();
            左平激9.Text = DateSave.Instance().Production.左平激9.ToString();
            激与左轴1.Text = DateSave.Instance().Production.激与左轴1.ToString();
            激与左轴2.Text = DateSave.Instance().Production.激与左轴2.ToString();
            激与左轴3.Text = DateSave.Instance().Production.激与左轴3.ToString();
            激与左轴4.Text = DateSave.Instance().Production.激与左轴4.ToString();
            激与左轴5.Text = DateSave.Instance().Production.激与左轴5.ToString();
            激与左轴6.Text = DateSave.Instance().Production.激与左轴6.ToString();
            激与左轴7.Text = DateSave.Instance().Production.激与左轴7.ToString();
            激与左轴8.Text = DateSave.Instance().Production.激与左轴8.ToString();
            激与左轴9.Text = DateSave.Instance().Production.激与左轴9.ToString();

            左平喷1.Text = DateSave.Instance().Production.左平喷1.ToString();
            左平喷2.Text = DateSave.Instance().Production.左平喷2.ToString();
            左平喷3.Text = DateSave.Instance().Production.左平喷3.ToString();
            左平喷4.Text = DateSave.Instance().Production.左平喷4.ToString();
            左平喷5.Text = DateSave.Instance().Production.左平喷5.ToString();
            左平喷6.Text = DateSave.Instance().Production.左平喷6.ToString();
            左平喷7.Text = DateSave.Instance().Production.左平喷7.ToString();
            左平喷8.Text = DateSave.Instance().Production.左平喷8.ToString();
            左平喷9.Text = DateSave.Instance().Production.左平喷9.ToString();

            喷左平1.Text = DateSave.Instance().Production.喷左平1.ToString();
            喷左平2.Text = DateSave.Instance().Production.喷左平2.ToString();
            喷左平3.Text = DateSave.Instance().Production.喷左平3.ToString();
            喷左平4.Text = DateSave.Instance().Production.喷左平4.ToString();
            喷左平5.Text = DateSave.Instance().Production.喷左平5.ToString();
            喷左平6.Text = DateSave.Instance().Production.喷左平6.ToString();
            喷左平7.Text = DateSave.Instance().Production.喷左平7.ToString();
            喷左平8.Text = DateSave.Instance().Production.喷左平8.ToString();
            喷左平9.Text = DateSave.Instance().Production.喷左平9.ToString();
            右平激1.Text = DateSave.Instance().Production.右平激1.ToString();
            右平激2.Text = DateSave.Instance().Production.右平激2.ToString();
            右平激3.Text = DateSave.Instance().Production.右平激3.ToString();
            右平激4.Text = DateSave.Instance().Production.右平激4.ToString();
            右平激5.Text = DateSave.Instance().Production.右平激5.ToString();
            右平激6.Text = DateSave.Instance().Production.右平激6.ToString();
            右平激7.Text = DateSave.Instance().Production.右平激7.ToString();
            右平激8.Text = DateSave.Instance().Production.右平激8.ToString();
            右平激9.Text = DateSave.Instance().Production.右平激9.ToString();
            激与右轴1.Text = DateSave.Instance().Production.激与右轴1.ToString();
            激与右轴2.Text = DateSave.Instance().Production.激与右轴2.ToString();
            激与右轴3.Text = DateSave.Instance().Production.激与右轴3.ToString();
            激与右轴4.Text = DateSave.Instance().Production.激与右轴4.ToString();
            激与右轴5.Text = DateSave.Instance().Production.激与右轴5.ToString();
            激与右轴6.Text = DateSave.Instance().Production.激与右轴6.ToString();
            激与右轴7.Text = DateSave.Instance().Production.激与右轴7.ToString();
            激与右轴8.Text = DateSave.Instance().Production.激与右轴8.ToString();
            激与右轴9.Text = DateSave.Instance().Production.激与右轴9.ToString();


            右平喷1.Text = DateSave.Instance().Production.右平喷1.ToString();
            右平喷2.Text = DateSave.Instance().Production.右平喷2.ToString();
            右平喷3.Text = DateSave.Instance().Production.右平喷3.ToString();
            右平喷4.Text = DateSave.Instance().Production.右平喷4.ToString();
            右平喷5.Text = DateSave.Instance().Production.右平喷5.ToString();
            右平喷6.Text = DateSave.Instance().Production.右平喷6.ToString();
            右平喷7.Text = DateSave.Instance().Production.右平喷7.ToString();
            右平喷8.Text = DateSave.Instance().Production.右平喷8.ToString();
            右平喷9.Text = DateSave.Instance().Production.右平喷9.ToString();

            喷右平1.Text = DateSave.Instance().Production.喷右平1.ToString();
            喷右平2.Text = DateSave.Instance().Production.喷右平2.ToString();
            喷右平3.Text = DateSave.Instance().Production.喷右平3.ToString();
            喷右平4.Text = DateSave.Instance().Production.喷右平4.ToString();
            喷右平5.Text = DateSave.Instance().Production.喷右平5.ToString();
            喷右平6.Text = DateSave.Instance().Production.喷右平6.ToString();
            喷右平7.Text = DateSave.Instance().Production.喷右平7.ToString();
            喷右平8.Text = DateSave.Instance().Production.喷右平8.ToString();
            喷右平9.Text = DateSave.Instance().Production.喷右平9.ToString();

            左平激1线扫.Text = DateSave.Instance().Production.左平激1线扫.ToString();
            左平激2线扫.Text = DateSave.Instance().Production.左平激2线扫.ToString();
            左平激3线扫.Text = DateSave.Instance().Production.左平激3线扫.ToString();
            左平激4线扫.Text = DateSave.Instance().Production.左平激4线扫.ToString();
            左平激5线扫.Text = DateSave.Instance().Production.左平激5线扫.ToString();
            左平激6线扫.Text = DateSave.Instance().Production.左平激6线扫.ToString();
            左平激7线扫.Text = DateSave.Instance().Production.左平激7线扫.ToString();
            左平激8线扫.Text = DateSave.Instance().Production.左平激8线扫.ToString();
            左平激9线扫.Text = DateSave.Instance().Production.左平激9线扫.ToString();




            激与左轴1线扫.Text = DateSave.Instance().Production.激与左轴1线扫.ToString();
            激与左轴2线扫.Text = DateSave.Instance().Production.激与左轴2线扫.ToString();
            激与左轴3线扫.Text = DateSave.Instance().Production.激与左轴3线扫.ToString();
            激与左轴4线扫.Text = DateSave.Instance().Production.激与左轴4线扫.ToString();
            激与左轴5线扫.Text = DateSave.Instance().Production.激与左轴5线扫.ToString();
            激与左轴6线扫.Text = DateSave.Instance().Production.激与左轴6线扫.ToString();
            激与左轴7线扫.Text = DateSave.Instance().Production.激与左轴7线扫.ToString();
            激与左轴8线扫.Text = DateSave.Instance().Production.激与左轴8线扫.ToString();
            激与左轴9线扫.Text = DateSave.Instance().Production.激与左轴9线扫.ToString();

            右平激1线扫.Text = DateSave.Instance().Production.右平激1线扫.ToString();
            右平激2线扫.Text = DateSave.Instance().Production.右平激2线扫.ToString();
            右平激3线扫.Text = DateSave.Instance().Production.右平激3线扫.ToString();
            右平激4线扫.Text = DateSave.Instance().Production.右平激4线扫.ToString();
            右平激5线扫.Text = DateSave.Instance().Production.右平激5线扫.ToString();
            右平激6线扫.Text = DateSave.Instance().Production.右平激6线扫.ToString();
            右平激7线扫.Text = DateSave.Instance().Production.右平激7线扫.ToString();
            右平激8线扫.Text = DateSave.Instance().Production.右平激8线扫.ToString();
            右平激9线扫.Text = DateSave.Instance().Production.右平激9线扫.ToString();

            激与右轴1线扫.Text = DateSave.Instance().Production.激与右轴1线扫.ToString();
            激与右轴2线扫.Text = DateSave.Instance().Production.激与右轴2线扫.ToString();
            激与右轴3线扫.Text = DateSave.Instance().Production.激与右轴3线扫.ToString();
            激与右轴4线扫.Text = DateSave.Instance().Production.激与右轴4线扫.ToString();
            激与右轴5线扫.Text = DateSave.Instance().Production.激与右轴5线扫.ToString();
            激与右轴6线扫.Text = DateSave.Instance().Production.激与右轴6线扫.ToString();
            激与右轴7线扫.Text = DateSave.Instance().Production.激与右轴7线扫.ToString();
            激与右轴8线扫.Text = DateSave.Instance().Production.激与右轴8线扫.ToString();
            激与右轴9线扫.Text = DateSave.Instance().Production.激与右轴9线扫.ToString();



            左平激10.Text = DateSave.Instance().Production.左平激标定拍照点.ToString();
         

            激与左轴10.Text = DateSave.Instance().Production.激与左轴拍照点.ToString();

            左平喷10.Text = DateSave.Instance().Production.左平喷定拍照点.ToString();


            喷左平10.Text = DateSave.Instance().Production.喷左平拍照点.ToString();


            右平激10.Text = DateSave.Instance().Production.右平激标定拍照点.ToString();
     

            激与右轴10.Text = DateSave.Instance().Production.激与右轴拍照点.ToString();

            右平喷10.Text = DateSave.Instance().Production.右平喷定拍照点.ToString();
        

            喷右平10.Text = DateSave.Instance().Production.喷右平拍照点.ToString();


            左平台相机与激光中心间距X.Text = DateSave.Instance().Production.左平台相机与激光中心间距X.ToString();
            左平台相机与激光中心间距Y.Text = DateSave.Instance().Production.左平台相机与激光中心间距Y.ToString();

            右平台相机与激光中心间距X.Text = DateSave.Instance().Production.右平台相机与激光中心间距X.ToString();
            右平台相机与激光中心间距Y.Text = DateSave.Instance().Production.右平台相机与激光中心间距Y.ToString();


            左平台相机与喷码中心间距X.Text = DateSave.Instance().Production.左平台相机与喷码中心间距X.ToString();
            左平台相机与喷码中心间距Y.Text = DateSave.Instance().Production.左平台相机与喷码中心间距Y.ToString();

            右平台相机与喷码中心间距X.Text = DateSave.Instance().Production.右平台相机与喷码中心间距X.ToString();
            右平台相机与喷码中心间距Y.Text = DateSave.Instance().Production.右平台相机与喷码中心间距Y.ToString();


            左激光位置到喷码位置矩阵A.Text = DateSave.Instance().Production.左激光位置到喷码位置矩阵A.ToString();
            左激光位置到喷码位置矩阵B.Text = DateSave.Instance().Production.左激光位置到喷码位置矩阵B.ToString();

            左激光位置到喷码位置矩阵C.Text = DateSave.Instance().Production.左激光位置到喷码位置矩阵C.ToString();
            左激光位置到喷码位置矩阵D.Text = DateSave.Instance().Production.左激光位置到喷码位置矩阵D.ToString();

            左激光位置到喷码位置矩阵TX.Text = DateSave.Instance().Production.左激光位置到喷码位置矩阵TX.ToString();
            左激光位置到喷码位置矩阵TY.Text = DateSave.Instance().Production.左激光位置到喷码位置矩阵TY.ToString();



        右激光位置到喷码位置矩阵A.Text = DateSave.Instance().Production.右激光位置到喷码位置矩阵A.ToString();
            右激光位置到喷码位置矩阵B.Text = DateSave.Instance().Production.右激光位置到喷码位置矩阵B.ToString();

            右激光位置到喷码位置矩阵C.Text = DateSave.Instance().Production.右激光位置到喷码位置矩阵C.ToString();
            右激光位置到喷码位置矩阵D.Text = DateSave.Instance().Production.右激光位置到喷码位置矩阵D.ToString();

            右激光位置到喷码位置矩阵TX.Text = DateSave.Instance().Production.右激光位置到喷码位置矩阵TX.ToString();
            右激光位置到喷码位置矩阵TY.Text = DateSave.Instance().Production.右激光位置到喷码位置矩阵TY.ToString();
            txtCodeU.Text = DateSave.Instance().Production.喷码U轴喷码位.ToString();


            txtCodeU.Text = DateSave.Instance().Production.喷码U轴喷码位.ToString();

            txtCodeOffsetX.Text = DateSave.Instance().Production.喷码X偏移.ToString();
            txtCodeOffsetY.Text = DateSave.Instance().Production.喷码Y偏移.ToString();

            txtCodeSpeed.Text = DateSave.Instance().Production.喷码速度.ToString();
            txtCodeDistance.Text = DateSave.Instance().Production.喷码距离.ToString();
            txtCodeStartPos.Text = DateSave.Instance().Production.喷码起始点.ToString();
            延时.Text= DateSave.Instance().Production.延时.ToString();
        }

        private void button111_Click(object sender, EventArgs e)
        {
            左平激10.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平激标定拍照点 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            激与左轴10.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与左轴拍照点 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button110_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与左轴拍照点);
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.左平激标定拍照点);
        }

        private void button113_Click(object sender, EventArgs e)
        {
            左平喷10.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.左平喷定拍照点 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;

            喷左平10.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷左平拍照点 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button115_Click(object sender, EventArgs e)
        {
            右平激10.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平激标定拍照点 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            激与右轴10.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激与右轴拍照点 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button117_Click(object sender, EventArgs e)
        {
            右平喷10.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.右平喷定拍照点 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;

            喷右平10.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷右平拍照点 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;

            DateSave.Instance().SaveDoc();
        }

        private void button114_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.右平激标定拍照点);
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激与右轴拍照点);
        }

        private void 右平激10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平激标定拍照点 = Convert.ToDouble(右平激10.Text);
            }
            catch
            {
            }
        }

        private void 激与右轴10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与右轴拍照点 = Convert.ToDouble(激与右轴10.Text);
            }
            catch
            {
            }
        }

        private void 右平喷10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平喷定拍照点 = Convert.ToDouble(右平喷10.Text);
            }
            catch
            {
            }
        }

        private void 喷右平10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷右平拍照点 = Convert.ToDouble(喷右平10.Text);
            }
            catch
            {
            }
        }

        private void 左平激10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平激标定拍照点 = Convert.ToDouble(左平激10.Text);
            }
            catch
            {
            }
        }

        private void 激与左轴10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激与左轴拍照点 = Convert.ToDouble(激与左轴10.Text);
            }
            catch
            {
            }
        }

        private void 左平喷10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平喷定拍照点 = Convert.ToDouble(左平喷10.Text);
            }
            catch
            {
            }
        }

        private void 喷左平10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷左平拍照点 = Convert.ToDouble(喷左平10.Text);
            }
            catch
            {
            }
        }

        private void 左平台相机与激光中心间距X_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平台相机与激光中心间距X = Convert.ToDouble(左平台相机与激光中心间距X.Text);
            }
            catch
            {
            }
        }

        private void 左平台相机与激光中心间距Y_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平台相机与激光中心间距Y = Convert.ToDouble(左平台相机与激光中心间距Y.Text);
            }
            catch
            {
            }
        }

        private void 右平台相机与激光中心间距X_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平台相机与激光中心间距X = Convert.ToDouble(右平台相机与激光中心间距X.Text);
            }
            catch
            {
            }
        }

        private void 右平台相机与激光中心间距Y_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平台相机与激光中心间距Y = Convert.ToDouble(右平台相机与激光中心间距Y.Text);
            }
            catch
            {
            }
        }

        private void 左平台相机与喷码中心间距X_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平台相机与喷码中心间距X = Convert.ToDouble(左平台相机与喷码中心间距X.Text);
            }
            catch
            {
            }
        }

        private void 左平台相机与喷码中心间距Y_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左平台相机与喷码中心间距Y = Convert.ToDouble(左平台相机与喷码中心间距Y.Text);
            }
            catch
            {
            }
        }

        private void 右平台相机与喷码中心间距X_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平台相机与喷码中心间距X = Convert.ToDouble(右平台相机与喷码中心间距X.Text);
            }
            catch
            {
            }
        }

        private void 右平台相机与喷码中心间距Y_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右平台相机与喷码中心间距Y = Convert.ToDouble(右平台相机与喷码中心间距Y.Text);
            }
            catch
            {
            }
        }

        private void 左激光位置到喷码位置矩阵A_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左激光位置到喷码位置矩阵A = Convert.ToDouble(左激光位置到喷码位置矩阵A.Text);
            }
            catch
            {
            }
        }

        private void 左激光位置到喷码位置矩阵B_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左激光位置到喷码位置矩阵B = Convert.ToDouble(左激光位置到喷码位置矩阵B.Text);
            }
            catch
            {
            }
        }

        private void 左激光位置到喷码位置矩阵C_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左激光位置到喷码位置矩阵C = Convert.ToDouble(左激光位置到喷码位置矩阵C.Text);
            }
            catch
            {
            }
        }

        private void 左激光位置到喷码位置矩阵D_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左激光位置到喷码位置矩阵D = Convert.ToDouble(左激光位置到喷码位置矩阵D.Text);
            }
            catch
            {
            }
        }

        private void 左激光位置到喷码位置矩阵TX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左激光位置到喷码位置矩阵TX = Convert.ToDouble(左激光位置到喷码位置矩阵TX.Text);
            }
            catch
            {
            }
        }

        private void 左激光位置到喷码位置矩阵TY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.左激光位置到喷码位置矩阵TY = Convert.ToDouble(左激光位置到喷码位置矩阵TY.Text);
            }
            catch
            {
            }
        }

        private void 右激光位置到喷码位置矩阵A_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右激光位置到喷码位置矩阵A = Convert.ToDouble(右激光位置到喷码位置矩阵A.Text);
            }
            catch
            {
            }
        }

        private void 右激光位置到喷码位置矩阵B_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右激光位置到喷码位置矩阵B = Convert.ToDouble(右激光位置到喷码位置矩阵B.Text);
            }
            catch
            {
            }
        }

        private void 右激光位置到喷码位置矩阵C_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右激光位置到喷码位置矩阵C = Convert.ToDouble(右激光位置到喷码位置矩阵C.Text);
            }
            catch
            {
            }
        }

        private void 右激光位置到喷码位置矩阵D_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右激光位置到喷码位置矩阵D = Convert.ToDouble(右激光位置到喷码位置矩阵D.Text);
            }
            catch
            {
            }
        }

        private void 右激光位置到喷码位置矩阵TX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右激光位置到喷码位置矩阵TX = Convert.ToDouble(右激光位置到喷码位置矩阵TX.Text);
            }
            catch
            {
            }
        }

        private void 右激光位置到喷码位置矩阵TY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.右激光位置到喷码位置矩阵TY = Convert.ToDouble(右激光位置到喷码位置矩阵TY.Text);
            }
            catch
            {
            }
        }

        private void btnCode1_Click(object sender, EventArgs e)
        {
        
                _Print(平台选中.Text , 点位选中.Text,"","",0,0,0);
        
        }
        public void _Print(string ComplNmae, string ComplP, string _Asix_nameX, string _Asix_nameY, double XP, double YP, double Speed)
        {
          
            switch (ComplNmae)
            {
                case "左平台":
                    _Asix_nameX = "喷码载盘左";
                    _Asix_nameY = "拍照补偿轴";
                    switch (ComplP)
                    {

                        case "1":

                            XP = DateSave.Instance().Production.左平喷1;
                            YP = DateSave.Instance().Production.喷左平1;
                            break;
                        case "2":
                            XP = DateSave.Instance().Production.左平喷2;
                            YP = DateSave.Instance().Production.喷左平2;
                            break;
                        case "3":
                            XP = DateSave.Instance().Production.左平喷3;
                            YP = DateSave.Instance().Production.喷左平3;
                            break;
                        case "4":
                            XP = DateSave.Instance().Production.左平喷4;
                            YP = DateSave.Instance().Production.喷左平4;
                            break;
                        case "5":
                            XP = DateSave.Instance().Production.左平喷5;
                            YP = DateSave.Instance().Production.喷左平5;
                            break;
                        case "6":
                            XP = DateSave.Instance().Production.左平喷6;
                            YP = DateSave.Instance().Production.喷左平6;
                            break;
                        case "7":
                            XP = DateSave.Instance().Production.左平喷7;
                            YP = DateSave.Instance().Production.喷左平7;
                            break;
                        case "8":
                            XP = DateSave.Instance().Production.左平喷8;
                            YP = DateSave.Instance().Production.喷左平8;
                            break;
                        case "9":
                            XP = DateSave.Instance().Production.左平喷9;
                            YP = DateSave.Instance().Production.喷左平9;
                            break;
                        case "10":
                            break;
                        default:
                            break;
                    }
                    break;
                case "右平台":
                    _Asix_nameX = "喷码载盘右";
                    _Asix_nameY = "拍照补偿轴";
                    switch (ComplP)
                    {
                        case "1":
                            XP = DateSave.Instance().Production.右平喷1;
                            YP = DateSave.Instance().Production.喷右平1;
                            break;
                        case "2":
                            XP = DateSave.Instance().Production.右平喷2;
                            YP = DateSave.Instance().Production.喷右平2;
                            break;
                        case "3":
                            XP = DateSave.Instance().Production.右平喷3;
                            YP = DateSave.Instance().Production.喷右平3;
                            break;
                        case "4":
                            XP = DateSave.Instance().Production.右平喷4;
                            YP = DateSave.Instance().Production.喷右平4;
                            break;
                        case "5":
                            XP = DateSave.Instance().Production.右平喷5;
                            YP = DateSave.Instance().Production.喷右平5;
                            break;
                        case "6":
                            XP = DateSave.Instance().Production.右平喷6;
                            YP = DateSave.Instance().Production.喷右平6;
                            break;
                        case "7":
                            XP = DateSave.Instance().Production.右平喷7;
                            YP = DateSave.Instance().Production.喷右平7;
                            break;
                        case "8":
                            XP = DateSave.Instance().Production.右平喷8;
                            YP = DateSave.Instance().Production.喷右平8;
                            break;
                        case "9":
                            XP = DateSave.Instance().Production.右平喷9;
                            YP = DateSave.Instance().Production.喷右平9;
                            break;
                        case "10":
                            break;
                        default:
                            break;
                    }
                    break;

            }
            ManageContral.AxisPMoveAbsoluteToStop(_Asix_nameX, XP + DateSave.Instance().Production.喷码X偏移);
         
        
            ManageContral.AxisPMoveAbsoluteToStop(_Asix_nameY, YP + DateSave.Instance().Production.喷码Y偏移);
            while (true)
            {
                if (ManageContral.DetectingAxis(_Asix_nameX) == 0 && ManageContral.DetectingAxis(_Asix_nameY) == 0)
                {
                    break;
                }
            }
           

            BuildCor(平台选中.Text);

            int nPosition = (int)(XP * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Asix_nameX].PlusFeed);

            int D = (int)(YP * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Asix_nameY].PlusFeed)- (int)(DateSave.Instance().Production.喷码距离 * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Asix_nameY].PlusFeed);
            int S = (int)(DateSave.Instance().Production.喷码速度);
            ushort Dealy =(ushort) DateSave.Instance().Production.延时;
            short sRtn;
            int nStartPosition = (int)((YP - DateSave.Instance().Production.喷码起始点) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Asix_nameY].PlusFeed);

            int nEndPosition = (int)((YP - DateSave.Instance().Production.喷码距离) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Asix_nameY].PlusFeed);
            sRtn = GTN.mc.GTN_LnXY(1, 1, nPosition, nStartPosition, S, 2, S, 0);

            sRtn = GTN.mc.GTN_BufIO(1, 1, GTN.mc.MC_GPO, 0x10, 0x1, 0);

            sRtn = GTN.mc.GTN_LnXY(1, 1, nPosition, nEndPosition, S, 2, 0, 0);
            //sRtn = GTN.mc.GTN_BufDelay(1, 1, Dealy, 0);
            
            sRtn = GTN.mc.GTN_CrdStart(1, 1, 0);
            int segment;
            short run;
            while (true)
            {
                sRtn = GTN.mc.GTN_CrdStatus(0, 1, out run, out segment, 0);
                if (run == 1)
                {
                  
                }
                else
                {
                    GTN.mc.GTN_CrdClear(1, 1, 0);
                    break;
                }
            }
            ManageContral.SetOutBit("喷码触发", false);
        }
        public void BuildCor(string _crdPrm)
        {
            short sRtn;
            GTN.mc.TCrdPrm crdPrm;
            sRtn = GTN.mc.GTN_GetCrdPrm(1, 1, out crdPrm);
            switch (_crdPrm)
            {
                case "左平台":
                    crdPrm.dimension = 2;                        // 建立二维的坐标系
                    crdPrm.profile1 = 0;                       // 规划器1对应到X轴                       
                    crdPrm.profile2 = 0;                       // 规划器2对应到Y轴
                    crdPrm.profile3 = 0;                       // 规划器3对应到Z轴
                    crdPrm.profile4 = 1;
                    crdPrm.profile5 = 0;
                    crdPrm.profile6 = 2;
                    crdPrm.profile7 = 0;
                    crdPrm.profile8 = 0;
                    break;
                case "右平台":
                    crdPrm.dimension = 2;                        // 建立二维的坐标系
                    crdPrm.profile1 = 0;                       // 规划器1对应到X轴                       
                    crdPrm.profile2 = 0;                       // 规划器2对应到Y轴
                    crdPrm.profile3 = 1;
                    crdPrm.profile4 = 0;
                    crdPrm.profile5 = 0;
                    crdPrm.profile6 = 2;
                    crdPrm.profile7 = 0;
                    crdPrm.profile8 = 0;// 规划器3对应到Z轴
                    break;

            }
            crdPrm.synVelMax = 500;                      // 坐标系的最大合成速度是: 500 pulse/ms
            crdPrm.synAccMax = 2;                        // 坐标系的最大合成加速度是: 2 pulse/ms^2
            crdPrm.evenTime = 0;                         // 坐标系的最小匀速时间为0

            crdPrm.setOriginFlag = 1;                    // 需要设置加工坐标系原点位置
            crdPrm.originPos1 = 0;                       // 加工坐标系原点位置在(0,0,0)，即与机床坐标系原点重合
            crdPrm.originPos2 = 0;
            crdPrm.originPos3 = 0;
            crdPrm.originPos4 = 0;
            crdPrm.originPos5 = 0;
            crdPrm.originPos6 = 0;
            crdPrm.originPos7 = 0;
            crdPrm.originPos8 = 0;
            // 建立1号坐标系，设置坐标系参数
            sRtn = GTN.mc.GTN_SetCrdPrm(1, 1, ref crdPrm);


        }
        public async void Print(string ComplNmae, string ComplP, string _Asix_nameX, string _Asix_nameY, double XP, double YP, double Speed)
        {
            await Task.Run(() =>
            {

                switch (ComplNmae)
            {
                case "左平台":
                    _Asix_nameX = "喷码载盘左";
                    _Asix_nameY = "拍照补偿轴";
                    switch (ComplP)
                    {

                        case "1":

                            XP = DateSave.Instance().Production.左平喷1;
                            YP = DateSave.Instance().Production.喷左平1;
                            break;
                        case "2":
                            XP = DateSave.Instance().Production.左平喷2;
                            YP = DateSave.Instance().Production.喷左平2;
                            break;
                        case "3":
                            XP = DateSave.Instance().Production.左平喷3;
                            YP = DateSave.Instance().Production.喷左平3;
                            break;
                        case "4":
                            XP = DateSave.Instance().Production.左平喷4;
                            YP = DateSave.Instance().Production.喷左平4;
                            break;
                        case "5":
                            XP = DateSave.Instance().Production.左平喷5;
                            YP = DateSave.Instance().Production.喷左平5;
                            break;
                        case "6":
                            XP = DateSave.Instance().Production.左平喷6;
                            YP = DateSave.Instance().Production.喷左平6;
                            break;
                        case "7":
                            XP = DateSave.Instance().Production.左平喷7;
                            YP = DateSave.Instance().Production.喷左平7;
                            break;
                        case "8":
                            XP = DateSave.Instance().Production.左平喷8;
                            YP = DateSave.Instance().Production.喷左平8;
                            break;
                        case "9":
                            XP = DateSave.Instance().Production.左平喷9;
                            YP = DateSave.Instance().Production.喷左平9;
                            break;
                        case "10":
                            break;
                        default:
                            break;
                    }
                    break;
                case "右平台":
                    _Asix_nameX = "喷码载盘右";
                    _Asix_nameY = "拍照补偿轴";
                    switch (ComplP)
                    {
                        case "1":
                            XP = DateSave.Instance().Production.右平喷1;
                            YP = DateSave.Instance().Production.喷右平1;
                            break;
                        case "2":
                            XP = DateSave.Instance().Production.右平喷2;
                            YP = DateSave.Instance().Production.喷右平2;
                            break;
                        case "3":
                            XP = DateSave.Instance().Production.右平喷3;
                            YP = DateSave.Instance().Production.喷右平3;
                            break;
                        case "4":
                            XP = DateSave.Instance().Production.右平喷4;
                            YP = DateSave.Instance().Production.喷右平4;
                            break;
                        case "5":
                            XP = DateSave.Instance().Production.右平喷5;
                            YP = DateSave.Instance().Production.喷右平5;
                            break;
                        case "6":
                            XP = DateSave.Instance().Production.右平喷6;
                            YP = DateSave.Instance().Production.喷右平6;
                            break;
                        case "7":
                            XP = DateSave.Instance().Production.右平喷7;
                            YP = DateSave.Instance().Production.喷右平7;
                            break;
                        case "8":
                            XP = DateSave.Instance().Production.右平喷8;
                            YP = DateSave.Instance().Production.喷右平8;
                            break;
                        case "9":
                            XP = DateSave.Instance().Production.右平喷9;
                            YP = DateSave.Instance().Production.喷右平9;
                            break;
                        case "10":
                            break;
                        default:
                            break;
                    }
                    break;

            }
            ManageContral.AxisPMoveAbsoluteToStop(_Asix_nameX, XP);
            ManageContral.AxisPMoveAbsoluteToStop(_Asix_nameY, YP);
                ManageContral.AxisPMoveAbsoluteToStop("旋转轴", DateSave.Instance().Production.喷码U轴喷码位);
                while (true)
                {
                    if (ManageContral.DetectingAxis("旋转轴")==0 && ManageContral.DetectingAxis(_Asix_nameX)==0 && ManageContral.DetectingAxis(_Asix_nameY)==0)
                    {
                        break;
                    }
                }
            //ManageContral.DetectingAxis("旋转轴");
            DateTime starttime = DateTime.Now;
            int stime = 10;
            double D = DateSave.Instance().Production.喷码距离;
            // ManageContral.PrintAxisPMoveAbsoluteToStop(_Asix_name, DateSave.Instance().Production.左平激1线扫, 100);
            ManageContral.PrintAxisPMoveAbsoluteToStop(_Asix_nameY, YP - D, DateSave.Instance().Production.喷码速度);
            //if (1 != AxisPMoveAbsoluteToStop(Program.strUCode, CalibrationDataSave.Instance().Calibration.喷码U轴喷码位)) return 0;

            int nStartPosition = (int)((YP - DateSave.Instance().Production.喷码起始点) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Asix_nameY].PlusFeed);

            int nEndPosition = (int)((YP - DateSave.Instance().Production.喷码距离) * Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Asix_nameY].PlusFeed);

            starttime = DateTime.Now;
            stime = 5;

            while (true)
            {
                uint sClock;
                short sResult = 0;

                double fEncPos = 0.0;
                sResult = GTN.mc.GTN_GetPrfPos((short)Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Asix_nameY].m_CardNo, (short)(Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[_Asix_nameY].m_AxisNo),
                            out fEncPos,
                            1,
                            out sClock);

                if (0 == sResult && fEncPos <= nStartPosition)
                {
                    if (0 != ManageContral.SetOutBit("喷码触发", true));
                }

                TimeSpan spantime = DateTime.Now - starttime;

                if (spantime.TotalSeconds > stime)
                {
                    break;
                }

                if (Math.Abs(nEndPosition - fEncPos) <= 100.0)
                {
                    ManageContral.SetOutBit("喷码触发", false);
                    break;
                }
            }
            ManageContral.SetOutBit("喷码触发", false);

        });
        }
     

        private void btnGetU_Click(object sender, EventArgs e)
        {
            txtCodeU.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["旋转轴"].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷码U轴喷码位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["旋转轴"].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
          
        }

        private void txtCodeOffsetX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷码X偏移 = Convert.ToDouble(txtCodeOffsetX.Text);
            }
            catch
            {
            }
        }

        private void txtCodeOffsetY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷码Y偏移 = Convert.ToDouble(txtCodeOffsetY.Text);
            }
            catch
            {
            }
        }

        private void txtCodeU_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷码U轴喷码位 = Convert.ToDouble(txtCodeU.Text);
            }
            catch
            {
            }
        }

        private void txtCodeSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷码速度 = Convert.ToDouble(txtCodeSpeed.Text);
            }
            catch
            {
            }
        }

        private void txtCodeDistance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷码距离 = Convert.ToDouble(txtCodeDistance.Text);
            }
            catch
            {
            }
        }

        private void txtCodeStartPos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷码起始点 = Convert.ToDouble(txtCodeStartPos.Text);
            }
            catch
            {
            }
        }

        private void btnGoU_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop("旋转轴", DateSave.Instance().Production.喷码U轴喷码位);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.延时 = Convert.ToInt16(延时.Text);
            }
            catch
            {
            }
        }
    }
}