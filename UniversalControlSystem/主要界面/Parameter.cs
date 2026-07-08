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

namespace UniversalControlSystem
{
    public partial class Parameter : Form
    {
        string LoadPaperAixsName = "取料轴Y";
        string CCDTaska_A_AixsName = "喷码载盘左";
        string CCDTaska_B_AixsName = "喷码载盘右";
        string LaserAixsName = "激光Y轴";
        string Ari_Brush_AixsName = "拍照补偿轴";
        string 下料AixsName = "下料X轴";
        string Fascicule_AixsName = "分堆底部接料X轴";

        string 分堆X轴 = "分堆X轴";
        string 分堆Y轴 = "分堆Y轴";
        string 分堆Z轴 = "分堆Z轴";
        public Parameter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            上料轴待机位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LoadPaperAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.上料轴待机位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LoadPaperAixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            上料轴放纸位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LoadPaperAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.上料轴放纸位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LoadPaperAixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            上料轴取料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LoadPaperAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.上料轴取料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LoadPaperAixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            上料轴放料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LoadPaperAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.上料轴放料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LoadPaperAixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //CCD_A_面_待机位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            //DateSave.Instance().Production.CCD_左载台_待机位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;
            //DateSave.Instance().SaveDoc();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CCD_左载台_待机位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.CCD_左载台_待机位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CCD_左到喷码位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.CCD_左到喷码位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CCD_右载台_待机位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.CCD_右载台_待机位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button9_Click(object sender, EventArgs e)
        {
        
            CCD_右载台激光清洗位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.CCD_右载台激光清洗位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CCD_右载台下料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.CCD_右载台下料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
            激光拍照位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.激光拍照位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LaserAixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //激光间隔.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转Y轴"].AisxCurrentPosition.ToString();
            //DateSave.Instance().Production.激光间隔 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转Y轴"].AisxCurrentPosition;
            //DateSave.Instance().SaveDoc();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //下料中转下料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转Y轴"].AisxCurrentPosition.ToString();
            //DateSave.Instance().Production.下料中转下料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转Y轴"].AisxCurrentPosition;
            //DateSave.Instance().SaveDoc();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            下料X轴待机位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料X轴待机位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition;
            
            DateSave.Instance().SaveDoc();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            下料X轴取料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料X轴取料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            下料X轴1.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料X轴1 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            下料X轴4.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料X轴4 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            下料X轴2.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料X轴2 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            下料X轴5.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料X轴5 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            下料X轴3.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料X轴3 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            下料Z轴下料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Z轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料Z轴下料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            下料Z轴侧高位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Z轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料Z轴侧高位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Z轴].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            //下料Z1轴1.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料Z1轴1 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button24_Click(object sender, EventArgs e)
        {
           // 下料Z1轴2.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料Z1轴2 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button25_Click(object sender, EventArgs e)
        {
          //  下料Z1轴3.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料Z1轴3 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void 下料X轴间隔_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DateSave.Instance().Production.下料X轴间隔 = Convert.ToDouble(下料X轴间隔.Text);
            //    DateSave.Instance().SaveDoc();

            //}
            //catch 
            //{

         
            //}
           
        }

        private void button28_Click(object sender, EventArgs e)
        {
         //   下料Z2轴1.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料Z2轴1 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button27_Click(object sender, EventArgs e)
        {
           // 下料Z2轴2.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料Z2轴2 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button26_Click(object sender, EventArgs e)
        {
          //  下料Z2轴3.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料Z2轴3 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void Parameter_Load(object sender, EventArgs e)
        {
           
       
           // 下料中转下料位.Text = DateSave.Instance().Production.下料X轴待机位.ToString();
            下料X轴取料位.Text = DateSave.Instance().Production.下料X轴取料位.ToString();
            下料X轴1.Text = DateSave.Instance().Production.下料X轴1.ToString();
            下料X轴4.Text = DateSave.Instance().Production.下料X轴4.ToString();
            下料X轴2.Text = DateSave.Instance().Production.下料X轴2.ToString();
            下料X轴5.Text = DateSave.Instance().Production.下料X轴5.ToString();
            下料X轴3.Text = DateSave.Instance().Production.下料X轴3.ToString();
            下料Z轴下料位.Text = DateSave.Instance().Production.下料Z轴下料位.ToString();

            下料Z轴侧高位.Text = DateSave.Instance().Production.下料Z1轴取料位.ToString();
            下料Z轴取料位.Text = DateSave.Instance().Production.下料Z2轴取料位.ToString();

            //下料Z1轴1.Text = DateSave.Instance().Production.下料Z1轴1.ToString();
          //  下料Z1轴2.Text = DateSave.Instance().Production.下料Z1轴2.ToString();
            //下料Z1轴3.Text = DateSave.Instance().Production.下料Z1轴3.ToString();
            //下料X轴间隔.Text= DateSave.Instance().Production.下料X轴间隔.ToString();

         //   下料Z2轴1.Text = DateSave.Instance().Production.下料Z2轴1.ToString();
           // 下料Z2轴2.Text = DateSave.Instance().Production.下料Z2轴2.ToString();
          //  下料Z2轴3.Text = DateSave.Instance().Production.下料Z2轴3.ToString();
          //  下料X轴放纸位.Text = DateSave.Instance().Production.下料X轴放纸位.ToString();
           // 下料X轴放料位.Text = DateSave.Instance().Production.下料X轴放料位.ToString();
            下料X轴待机位.Text = DateSave.Instance().Production.下料X轴待机位.ToString();


            上料轴待机位.Text = DateSave.Instance().Production.上料轴待机位.ToString();
            上料轴放纸位.Text = DateSave.Instance().Production.上料轴放纸位.ToString();
            上料轴取料位.Text = DateSave.Instance().Production.上料轴取料位.ToString();
            上料轴放料位.Text = DateSave.Instance().Production.上料轴放料位.ToString();
            上料轴中转位.Text = DateSave.Instance().Production.上料轴中转位.ToString();
          
            //   CCD_A_面_待机位.Text = DateSave.Instance().Production.CCD_A_面_待机位.ToString();
            CCD_左到喷码位.Text = DateSave.Instance().Production.CCD_左到喷码位.ToString();
            CCD_左载台_待机位.Text = DateSave.Instance().Production.CCD_左载台_待机位.ToString();
            CCD_左载台下料位.Text = DateSave.Instance().Production.CCD_左载台下料位.ToString();
            CCD_左载台激光清洗位.Text = DateSave.Instance().Production.CCD_左载台激光清洗位.ToString();
            CCD_左载台_线扫完成位.Text = DateSave.Instance().Production.CCD_左载台_线扫完成位.ToString();

            CCD_右载台_待机位.Text = DateSave.Instance().Production.CCD_右载台_待机位.ToString();
            CCD_右载台激光清洗位.Text = DateSave.Instance().Production.CCD_右载台激光清洗位.ToString();
            CCD_右载台下料位.Text = DateSave.Instance().Production.CCD_右载台下料位.ToString();
            CCD_右载台_线扫完成位.Text = DateSave.Instance().Production.CCD_右载台_线扫完成位.ToString();
            CCD_右到喷码位.Text = DateSave.Instance().Production.CCD_右到喷码位.ToString();
            CCD_右载台下料位.Text = DateSave.Instance().Production.CCD_右载台下料位.ToString();



            激光拍照位.Text = DateSave.Instance().Production.激光拍照位.ToString();
            激光间隔.Text = DateSave.Instance().Production.激光间隔.ToString();

            喷码拍照位.Text = DateSave.Instance().Production.喷码拍照位.ToString();
            喷码间隔.Text= DateSave.Instance().Production.喷码间隔.ToString();


            下料轴取料位.Text = DateSave.Instance().Production.下料轴取料位.ToString();
            下料轴B面放料位.Text = DateSave.Instance().Production.下料轴B面放料位.ToString();
            下料轴B面NG位.Text = DateSave.Instance().Production.下料轴B面NG位.ToString();

            分堆底部接料轴待机位.Text = DateSave.Instance().Production.分堆底部接料轴待机位.ToString();
            分堆底部接料轴取料位.Text = DateSave.Instance().Production.分堆底部接料轴取料位.ToString();
            分堆底部接料轴放料位.Text = DateSave.Instance().Production.分堆底部接料轴放料位.ToString();


            下料X轴待机位.Text = DateSave.Instance().Production.下料X轴待机位.ToString();
            下料X轴取料位.Text = DateSave.Instance().Production.下料X轴取料位.ToString();
            下料X轴1.Text = DateSave.Instance().Production.下料X轴1.ToString();
            下料X轴4.Text = DateSave.Instance().Production.下料X轴4.ToString();
            下料X轴2.Text = DateSave.Instance().Production.下料X轴2.ToString();
            下料X轴5.Text = DateSave.Instance().Production.下料X轴5.ToString();
            下料X轴3.Text = DateSave.Instance().Production.下料X轴3.ToString();
            下料X轴6.Text = DateSave.Instance().Production.下料X轴6.ToString();
            下料Z轴下料位.Text = DateSave.Instance().Production.下料Z轴下料位.ToString();
            下料Z轴侧高位.Text = DateSave.Instance().Production.下料Z轴侧高位.ToString();
            下料Z轴取料位.Text = DateSave.Instance().Production.下料Z轴取料位.ToString();
            分堆Y轴待机位.Text = DateSave.Instance().Production.分堆Y轴待机位.ToString();
            分堆Y轴放料位.Text = DateSave.Instance().Production.分堆Y轴放料位.ToString();
            分堆Y轴取料位.Text = DateSave.Instance().Production.分堆Y轴取料位.ToString();
            CCD_右载台激光清洗位.Text = DateSave.Instance().Production.CCD_右载台激光清洗位.ToString();
           // 测高位X.Text= DateSave.Instance().Production.下料X轴间隔.ToString();



            最小模拟量.Text = DateSave.Instance().Production.IncreaseMminimumAnalog.ToString();
            最大模拟量.Text = DateSave.Instance().Production.IncreaseMaximumAnalog.ToString();
       
            Z轴最大坐标.Text = DateSave.Instance().Production.Z_AxisMaximumCoordinate.ToString();
            Z轴最小坐标.Text = DateSave.Instance().Production.Z_AxisMinimumCoordinate.ToString();
        
            基准点模拟量.Text = DateSave.Instance().Production.BaselineSimulation.ToString();
            关联后所对应.Text = DateSave.Instance().Production.High_Date.ToString();
     
            基准Z坐标.Text = DateSave.Instance().Production.Z_AxialDatum.ToString();
            基准X坐标.Text = DateSave.Instance().Production.X_AxialDatum.ToString();
            基准Y坐标.Text = DateSave.Instance().Production.Y_AxialDatum.ToString();



            翻放位.Text = DateSave.Instance().Production.翻放位.ToString();
            测高位.Text = DateSave.Instance().Production.测高位.ToString();

            测高位X.Text =DateSave.Instance().Production.测高位X.ToString();

        }

        private void button58_Click(object sender, EventArgs e)
        {
            //下料X轴放纸位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料X轴放纸位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button60_Click(object sender, EventArgs e)
        {
           // 下料X轴放料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料X轴放料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button61_Click(object sender, EventArgs e)
        {
            try
            {
             //   下料X轴间隔.Text=( DateSave.Instance().Production.下料X轴放纸位 - DateSave.Instance().Production.下料X轴放料位).ToString();
                DateSave.Instance().Production.下料X轴间隔 =  DateSave.Instance().Production.下料X轴放纸位 - DateSave.Instance().Production.下料X轴放料位;
                DateSave.Instance().SaveDoc();
            }
            catch 
            {

             
            }
         
        }

        private void button63_Click(object sender, EventArgs e)
        {
            下料Z轴取料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Z轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料Z轴取料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Z轴].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LoadPaperAixsName, DateSave.Instance().Production.上料轴待机位);
      
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LoadPaperAixsName, DateSave.Instance().Production.上料轴放纸位);
            //  Googol_Contral.AxisPMoveAbsoluteToStop("上料X轴", DateSave.Instance().Production.上料轴放纸位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["上料X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["上料X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["上料X轴"].Dec);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LoadPaperAixsName, DateSave.Instance().Production.上料轴取料位);

        }

        private void button32_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LoadPaperAixsName, DateSave.Instance().Production.上料轴放料位);
      
        }

        private void button33_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台_待机位);
            //Googol_Contral.AxisPMoveAbsoluteToStop("底部中转X轴", DateSave.Instance().Production.CCD_A_面_待机位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Dec);

        }

        private void button34_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台_待机位);
            //    Googol_Contral.AxisPMoveAbsoluteToStop("底部中转X轴", DateSave.Instance().Production.CCD_A_面_放料位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Dec);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左到喷码位);
            //  Googol_Contral.AxisPMoveAbsoluteToStop("底部中转X轴", DateSave.Instance().Production.CCD_A_面_CCD位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Dec);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台_待机位);
            // Googol_Contral.AxisPMoveAbsoluteToStop("中转搬运Y", DateSave.Instance().Production.CCD_B_面待机位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Dec);

        }

        private void button37_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台激光清洗位);
            //  Googol_Contral.AxisPMoveAbsoluteToStop("中转搬运Y", DateSave.Instance().Production.CCD_B_面放料位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Dec);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台下料位);
            //  Googol_Contral.AxisPMoveAbsoluteToStop("中转搬运Y", DateSave.Instance().Production.CCD_B_面下料位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Dec);
        }

        private void button39_Click(object sender, EventArgs e)
        {
        
            ManageContral.AxisPMoveAbsoluteToStop(LaserAixsName, DateSave.Instance().Production.激光拍照位);
            // Googol_Contral.AxisPMoveAbsoluteToStop("底部中转Y轴", DateSave.Instance().Production.下料中转待机位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转Y轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转Y轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转Y轴"].Dec);
        }

        private void button42_Click(object sender, EventArgs e)
        {
          //  Googol_Contral.AxisPMoveAbsoluteToStop("底部中转Y轴", DateSave.Instance().Production.下料中转放料位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转Y轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转Y轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转Y轴"].Dec);
        }

        private void button40_Click(object sender, EventArgs e)
        {
         //   Googol_Contral.AxisPMoveAbsoluteToStop("底部中转Y轴", DateSave.Instance().Production.下料中转下料位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转Y轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转Y轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转Y轴"].Dec);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆X轴, DateSave.Instance().Production.下料X轴待机位);
            // Googol_Contral.AxisPMoveAbsoluteToStop("下料X轴", DateSave.Instance().Production.下料X轴待机位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Dec);

        }

        private void button43_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆X轴, DateSave.Instance().Production.下料X轴取料位);
            //Googol_Contral.AxisPMoveAbsoluteToStop("下料X轴", DateSave.Instance().Production.下料X轴取料位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Dec);
        }

        private void button57_Click(object sender, EventArgs e)
        {
            //Googol_Contral.AxisPMoveAbsoluteToStop("下料X轴", DateSave.Instance().Production.下料X轴放纸位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Dec);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆X轴, DateSave.Instance().Production.下料X轴1);
            
           // Googol_Contral.AxisPMoveAbsoluteToStop("下料X轴", DateSave.Instance().Production.下料X轴1, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Dec);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆X轴, DateSave.Instance().Production.下料X轴2);
            //Googol_Contral.AxisPMoveAbsoluteToStop("下料X轴", DateSave.Instance().Production.下料X轴2, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Dec);
        }

        private void button49_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆X轴, DateSave.Instance().Production.下料X轴3);
            //   Googol_Contral.AxisPMoveAbsoluteToStop("下料X轴", DateSave.Instance().Production.下料X轴3, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Dec);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆X轴, DateSave.Instance().Production.下料X轴4);
            ///Googol_Contral.AxisPMoveAbsoluteToStop("下料X轴", DateSave.Instance().Production.下料X轴4, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Dec);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆X轴, DateSave.Instance().Production.下料X轴5);
            ///
         //   Googol_Contral.AxisPMoveAbsoluteToStop("下料X轴", DateSave.Instance().Production.下料X轴5, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Dec);
        }

        private void button59_Click(object sender, EventArgs e)
        {
        //    Googol_Contral.AxisPMoveAbsoluteToStop("下料X轴", DateSave.Instance().Production.下料X轴放料位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料X轴"].Dec);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆Z轴, DateSave.Instance().Production.下料Z轴下料位);
            //Googol_Contral.AxisPMoveAbsoluteToStop("下料Z1", DateSave.Instance().Production.下料Z轴下料位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Dec);
            //Googol_Contral.AxisPMoveAbsoluteToStop("下料Z2", DateSave.Instance().Production.下料Z轴下料位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Dec);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆Z轴, DateSave.Instance().Production.下料Z轴侧高位);
            //  Googol_Contral.AxisPMoveAbsoluteToStop("下料Z1", DateSave.Instance().Production.下料Z1轴取料位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Dec);
        }

        private void button51_Click(object sender, EventArgs e)
        {
           // Googol_Contral.AxisPMoveAbsoluteToStop("下料Z1", DateSave.Instance().Production.下料Z1轴1, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Dec);
        }

        private void button53_Click(object sender, EventArgs e)
        {
          // Googol_Contral.AxisPMoveAbsoluteToStop("下料Z1", DateSave.Instance().Production.下料Z1轴2, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Dec);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            //Googol_Contral.AxisPMoveAbsoluteToStop("下料Z1", DateSave.Instance().Production.下料Z1轴2, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z1"].Dec);
        }

        private void button52_Click(object sender, EventArgs e)
        {
           // Googol_Contral.AxisPMoveAbsoluteToStop("下料Z2", DateSave.Instance().Production.下料Z2轴1, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Dec);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            ///.AxisPMoveAbsoluteToStop("下料Z2", DateSave.Instance().Production.下料Z2轴2, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Dec);
        }

        private void button56_Click(object sender, EventArgs e)
        {
           // Googol_Contral.AxisPMoveAbsoluteToStop("下料Z2", DateSave.Instance().Production.下料Z2轴3, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Dec);
        }

        private void button62_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆Z轴, DateSave.Instance().Production.下料Z轴取料位);
            //   Googol_Contral.AxisPMoveAbsoluteToStop("下料Z2", DateSave.Instance().Production.下料Z2轴取料位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["下料Z2"].Dec);
        }

        private void button65_Click(object sender, EventArgs e)
        {
            CCD_左载台激光清洗位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.CCD_左载台激光清洗位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            CCD_左载台_线扫完成位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.CCD_左载台_线扫完成位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台激光清洗位);
            //Googol_Contral.AxisPMoveAbsoluteToStop("底部中转X轴", DateSave.Instance().Production.CCD_A_面开始拍位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Dec);
        }

        private void button66_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台_线扫完成位);
            //    Googol_Contral.AxisPMoveAbsoluteToStop("底部中转X轴", DateSave.Instance().Production.CCD_A_面结束拍位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["底部中转X轴"].Dec);
        }

        private void button71_Click(object sender, EventArgs e)
        {
            CCD_右载台_线扫完成位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.CCD_右载台_线扫完成位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button69_Click(object sender, EventArgs e)
        {
            CCD_右到喷码位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.CCD_右到喷码位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_B_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button70_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右载台_线扫完成位);
            //  Googol_Contral.AxisPMoveAbsoluteToStop("中转搬运Y", DateSave.Instance().Production.CCD_B_面开始拍位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Dec);
        }

        private void button68_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_B_AixsName, DateSave.Instance().Production.CCD_右到喷码位);
            //  Googol_Contral.AxisPMoveAbsoluteToStop("中转搬运Y", DateSave.Instance().Production.CCD_B_面结束拍位, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Auto_Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary["中转搬运Y"].Dec);
        }

        private void button73_Click(object sender, EventArgs e)
        {
            上料轴中转位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LoadPaperAixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.上料轴中转位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[LoadPaperAixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
            
        }

        private void button72_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(LoadPaperAixsName, DateSave.Instance().Production.上料轴中转位);
        }

        private void button75_Click(object sender, EventArgs e)
        {
            CCD_左载台下料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.CCD_左载台下料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[CCDTaska_A_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台下料位);
        }

        private void button76_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(Ari_Brush_AixsName, DateSave.Instance().Production.喷码拍照位);
        }

        private void button79_Click(object sender, EventArgs e)
        {
            喷码拍照位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.喷码拍照位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Ari_Brush_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void 喷码间隔_TextChanged(object sender, EventArgs e)
        {
            try
            {
             
                DateSave.Instance().Production.喷码间隔 =Convert.ToDouble( 喷码间隔.Text);
                DateSave.Instance().SaveDoc();

            }
            catch 
            {

             
            }
        }

        private void 激光间隔_TextChanged(object sender, EventArgs e)
        {
            try
            {

                DateSave.Instance().Production.激光间隔 =Convert.ToDouble( 激光间隔.Text);
                DateSave.Instance().SaveDoc();

            }
            catch 
            {

              
            }
        }

        private void button77_Click(object sender, EventArgs e)
        {
            下料轴取料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[下料AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料轴取料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[下料AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button33_Click_1(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(下料AixsName, DateSave.Instance().Production.下料轴取料位);
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(下料AixsName, DateSave.Instance().Production.下料轴B面放料位);
        }

        private void button40_Click_1(object sender, EventArgs e)
        {
            下料轴B面放料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[下料AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料轴B面放料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[下料AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button81_Click(object sender, EventArgs e)
        {
            下料轴B面NG位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[下料AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料轴B面NG位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[下料AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button80_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(下料AixsName, DateSave.Instance().Production.下料轴B面NG位);
        }

        private void button87_Click(object sender, EventArgs e)
        {
            分堆底部接料轴待机位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Fascicule_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.分堆底部接料轴待机位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Fascicule_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button85_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(Fascicule_AixsName, DateSave.Instance().Production.分堆底部接料轴待机位);

        }

        private void button86_Click(object sender, EventArgs e)
        {
            分堆底部接料轴取料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Fascicule_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.分堆底部接料轴取料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Fascicule_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button84_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(Fascicule_AixsName, DateSave.Instance().Production.分堆底部接料轴取料位);
        }

        private void button82_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(Fascicule_AixsName, DateSave.Instance().Production.分堆底部接料轴放料位);
        }

        private void button83_Click(object sender, EventArgs e)
        {
            分堆底部接料轴放料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Fascicule_AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.分堆底部接料轴放料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Fascicule_AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button58_Click_1(object sender, EventArgs e)
        {
            下料X轴6.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.下料X轴6 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button57_Click_1(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆X轴, DateSave.Instance().Production.下料X轴6);
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button28_Click_1(object sender, EventArgs e)
        {
            分堆Y轴待机位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Y轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.分堆Y轴待机位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Y轴].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            分堆Y轴放料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Y轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.分堆Y轴放料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Y轴].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            分堆Y轴取料位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Y轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.分堆Y轴取料位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Y轴].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button26_Click_1(object sender, EventArgs e)
        {

            ManageContral.AxisPMoveAbsoluteToStop(分堆Y轴, DateSave.Instance().Production.分堆Y轴待机位);
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆Y轴, DateSave.Instance().Production.分堆Y轴放料位);
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆Y轴, DateSave.Instance().Production.分堆Y轴取料位);
        }

        private void 上料轴待机位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.上料轴待机位 = Convert.ToDouble(上料轴待机位.Text); 
            }
            catch 
            {
            }
       
        }

        private void 上料轴放纸位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.上料轴放纸位 = Convert.ToDouble(上料轴放纸位.Text);
            }
            catch
            {
            }
        }

        private void 上料轴取料位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.上料轴取料位 = Convert.ToDouble(上料轴取料位.Text);
            }
            catch
            {
            }
        }

        private void 上料轴中转位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.上料轴中转位 = Convert.ToDouble(上料轴中转位.Text);
            }
            catch
            {
            }
        }

        private void 上料轴放料位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.上料轴放料位 = Convert.ToDouble(上料轴放料位.Text);
            }
            catch
            {
            }
        }

        private void CCD_左载台_待机位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.CCD_左载台_待机位 = Convert.ToDouble(CCD_左载台_待机位.Text);
            }
            catch
            {
            }
        }

        private void CCD_左载台激光清洗位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.CCD_左载台激光清洗位 = Convert.ToDouble(CCD_左载台激光清洗位.Text);
            }
            catch
            {
            }
        }

        private void CCD_左载台_线扫完成位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.CCD_左载台_线扫完成位 = Convert.ToDouble(CCD_左载台_线扫完成位.Text);
            }
            catch
            {
            }
        }

        private void CCD_左到喷码位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.CCD_左到喷码位 = Convert.ToDouble(CCD_左到喷码位.Text);
            }
            catch
            {
            }
        }

        private void CCD_左载台下料位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.CCD_左载台下料位 = Convert.ToDouble(CCD_左载台下料位.Text);
            }
            catch
            {
            }
        }

        private void CCD_右载台_待机位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.CCD_右载台_待机位 = Convert.ToDouble(CCD_右载台_待机位.Text);
            }
            catch
            {
            }
        }

        private void CCD_右载台激光清洗位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.CCD_右载台激光清洗位 = Convert.ToDouble(CCD_右载台激光清洗位.Text);
            }
            catch
            {
            }
        }

        private void CCD_右载台_线扫完成位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.CCD_右载台_线扫完成位 = Convert.ToDouble(CCD_右载台_线扫完成位.Text);
            }
            catch
            {
            }
        }

        private void CCD_右到喷码位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.CCD_右到喷码位 = Convert.ToDouble(CCD_右到喷码位.Text);
            }
            catch
            {
            }
        }

        private void CCD_右载台下料位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.CCD_右载台下料位 = Convert.ToDouble(CCD_右载台下料位.Text);
            }
            catch
            {
            }
        }

        private void 激光拍照位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.激光拍照位 = Convert.ToDouble(激光拍照位.Text);
            }
            catch
            {
            }
        }

        private void 喷码拍照位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.喷码拍照位 = Convert.ToDouble(喷码拍照位.Text);
            }
            catch
            {
            }
        }

        private void 保存_Click(object sender, EventArgs e)
        {
            DateSave.Instance().SaveDoc();
        }

        private void 下料轴取料位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料轴取料位 = Convert.ToDouble(下料轴取料位.Text);
            }
            catch
            {
            }
        }

        private void 下料轴B面放料位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料轴B面放料位 = Convert.ToDouble(下料轴B面放料位.Text);
            }
            catch
            {
            }
        }

        private void 下料轴B面NG位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料轴B面NG位 = Convert.ToDouble(下料轴B面NG位.Text);
            }
            catch
            {
            }
        }

        private void 分堆底部接料轴待机位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.分堆底部接料轴待机位 = Convert.ToDouble(分堆底部接料轴待机位.Text);
            }
            catch
            {
            }
        }

        private void 分堆底部接料轴取料位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.分堆底部接料轴取料位 = Convert.ToDouble(分堆底部接料轴取料位.Text);
            }
            catch
            {
            }
        }

        private void 分堆底部接料轴放料位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.分堆底部接料轴放料位 = Convert.ToDouble(分堆底部接料轴放料位.Text);
            }
            catch
            {
            }
        }

        private void 下料X轴待机位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料X轴待机位 = Convert.ToDouble(下料X轴待机位.Text);
            }
            catch
            {
            }
        }

        private void 下料X轴取料位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料X轴取料位 = Convert.ToDouble(下料X轴取料位.Text);
            }
            catch
            {
            }
        }

        private void 下料X轴1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料X轴1 = Convert.ToDouble(下料X轴1.Text);
            }
            catch
            {
            }

        }

        private void 下料X轴4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料X轴4 = Convert.ToDouble(下料X轴4.Text);
            }
            catch
            {
            }

        }

        private void 下料X轴2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料X轴2 = Convert.ToDouble(下料X轴2.Text);
            }
            catch
            {
            }

        }

        private void 下料X轴5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料X轴5 = Convert.ToDouble(下料X轴5.Text);
            }
            catch
            {
            }

        }

        private void 下料X轴3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料X轴3 = Convert.ToDouble(下料X轴3.Text);
            }
            catch
            {
            }

        }

        private void 下料X轴6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料X轴6= Convert.ToDouble(下料X轴6.Text);
            }
            catch
            {
            }

        }

        private void 下料Z轴下料位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料Z轴下料位 = Convert.ToDouble(下料Z轴下料位.Text);
            }
            catch
            {
            }
        }

        private void 下料Z轴侧高位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料Z轴侧高位 = Convert.ToDouble(下料Z轴侧高位.Text);
            }
            catch
            {
            }
        }

        private void 下料Z轴取料位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.下料Z轴取料位 = Convert.ToDouble(下料Z轴取料位.Text);
            }
            catch
            {
            }
        }

        private void 分堆Y轴待机位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.分堆Y轴待机位 = Convert.ToDouble(分堆Y轴待机位.Text);
            }
            catch
            {
            }

        }

        private void 分堆Y轴放料位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.分堆Y轴放料位 = Convert.ToDouble(分堆Y轴放料位.Text);
            }
            catch
            {
            }
        }

        private void 分堆Y轴取料位_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.分堆Y轴取料位 = Convert.ToDouble(分堆Y轴取料位.Text);
            }
            catch
            {
            }
        }

        private void 皮带间隔_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateSave.Instance().Production.测高位X = Convert.ToDouble(测高位X.Text);
            }
            catch
            {
            }
            
        }

        private void 获取最小模拟量_Click(object sender, EventArgs e)
        {
            uint clk;
            double date = 0.0;
            double dbRet= 0.0;
            short _dbRet = 0;
            short s=  GTN.mc.GTN_GetAuAdc(2, 1, out dbRet, 1, out clk);
            最小模拟量.Text = dbRet.ToString();
            DateSave.Instance().Production.IncreaseMminimumAnalog = dbRet;
        }

        private void 获取最大模拟量_Click(object sender, EventArgs e)
        {
            uint clk;
            double date = 0.0;
            double dbRet = 0.0;
            GTN.mc.GTN_GetAuAdc(2, 1, out dbRet, 1, out clk);
            最大模拟量.Text = dbRet.ToString();
            DateSave.Instance().Production.IncreaseMaximumAnalog = dbRet;
        }

        private void 获取最小Z轴坐标_Click(object sender, EventArgs e)
        {
            double date = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Z轴].AisxCurrentPosition;
            Thread.Sleep(100);
            DateSave.Instance().Production.Z_AxisMinimumCoordinate = date;
            Z轴最小坐标.Text = date.ToString();
        }

        private void 获取最大Z轴坐标_Click(object sender, EventArgs e)
        {
            double date = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Z轴].AisxCurrentPosition;
            Thread.Sleep(100);
            DateSave.Instance().Production.Z_AxisMaximumCoordinate = date;
            Z轴最大坐标.Text = date.ToString();
        }

        private void 获取关联数据_Click(object sender, EventArgs e)
        {
            double date1 = Math.Abs(DateSave.Instance().Production.IncreaseMaximumAnalog - DateSave.Instance().Production.IncreaseMminimumAnalog);
            double date2 = Math.Abs(DateSave.Instance().Production.Z_AxisMaximumCoordinate - DateSave.Instance().Production.Z_AxisMinimumCoordinate);

            DateSave.Instance().Production.High_Date = Math.Abs(date1 / date2);
            关联后所对应.Text = DateSave.Instance().Production.High_Date.ToString();
        }

        private void 获取基准模拟量_Click(object sender, EventArgs e)
        {
            uint clk;
            double date = 0.0;
            double dbRet = 0.0;
            GTN.mc.GTN_GetAuAdc(2, 1, out date, 1, out clk);
            Thread.Sleep(100);
            DateSave.Instance().Production.BaselineSimulation = date;
            基准点模拟量.Text = date.ToString();
        }

        private void 获取基准坐标_Click(object sender, EventArgs e)
        {
            double dateX = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆X轴].AisxCurrentPosition;
            Thread.Sleep(100);
            double dateY = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Y轴].AisxCurrentPosition;
            Thread.Sleep(100);
            double dateZ = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Z轴].AisxCurrentPosition;
            Thread.Sleep(100);
            try
            {

                DateSave.Instance().Production.Z_AxialDatum = dateZ;
                DateSave.Instance().Production.X_AxialDatum = dateX;
                DateSave.Instance().Production.Y_AxialDatum = dateY;
                基准Z坐标.Text = DateSave.Instance().Production.Z_AxialDatum.ToString();
                基准X坐标.Text = DateSave.Instance().Production.X_AxialDatum.ToString();
                基准Y坐标.Text = DateSave.Instance().Production.Y_AxialDatum.ToString();
            }
            catch
            {
                MessageBox.Show("获取失败，请查看数据");
            }
        }

        private void 到基准点_Click(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆X轴, DateSave.Instance().Production.X_AxialDatum);
            ManageContral.AxisPMoveAbsoluteToStop(分堆Y轴, DateSave.Instance().Production.Y_AxialDatum);
            Thread.Sleep(500);
            ManageContral.AxisPMoveAbsoluteToStop(分堆Z轴, DateSave.Instance().Production.Z_AxialDatum);
        }

        Thread left = null;
        private void 启动左_Click(object sender, EventArgs e)
        {
            left = new Thread(_left);
            left.IsBackground = true;
            left.Start();
        }
        public AutoRunStep MiddleAutoRunStepA = new AutoRunStep();
        public string CCD_B_RUN_REL = "";
        public string CCD_A_RUN_REL = "";
        public string CCD_B_Laser_REL = "";
        public string CCD_A_Laser_REL = "";
        public string CCD_B_Print_REL = "";
        public string CCD_A_Print_REL = "";
        public string CCD_B_Check_REL = "";
        public string CCD_A_Check_REL = "";
        public bool CCD_RUN_REL = false;
        int CamerCountNG = 0;
        string CamerStrRun = "线扫";
        int Pruduct = 0;//产品序号
        string A_OR_B_Str = "";
        string date = "";
        public void _left()
        {
            while (true)
            {
                switch (MiddleAutoRunStepA)
                {
                    case AutoRunStep.Idle:
                        MiddleAutoRunStepA = AutoRunStep.CCD_左_面线扫开始拍照位;
                        ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台_待机位);
                        break;
                    case AutoRunStep.CCD_左_面线扫开始拍照位:
                        if (ManageContral.DetectingAxis(CCDTaska_A_AixsName) == 0)
                        {
                            CCD_RUN_REL = false;
                            date = "A,Left,Scan" + Pruduct.ToString();
                            CommunicationFun.ClearBuff(CamerStrRun, "Platform");
                            CommunicationFun.SendDate(CamerStrRun, date, out date);
                            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台_线扫完成位);
                            MiddleAutoRunStepA = AutoRunStep.CCD_左_面线扫到位检测;
                        }            
                        break;
                    case AutoRunStep.CCD_左_面线扫到位检测:
                        if (ManageContral.DetectingAxis(CCDTaska_A_AixsName) == 0)
                        {
                            MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_CCD线扫完成;
                        }
                        break;
                    case AutoRunStep.CCDTaska_A_CCD线扫完成:
                        CCD_A_RUN_REL = CommunicationFun._GetRec(CamerStrRun, "Platform");
                        string[] _CCD_A_RUN_REL = CCD_A_RUN_REL.Split('#');
                        if (_CCD_A_RUN_REL[3].Contains("0"))
                        {
                            //NG
                            CCD_RUN_REL = true;
                        }
                        else
                        {//OK
                         
                            //CCD_A_RUN_REL = "";
                            MiddleAutoRunStepA = AutoRunStep.CCDTaska_A_激光位到位检测;
                            ManageContral.AxisPMoveAbsoluteToStop(CCDTaska_A_AixsName, DateSave.Instance().Production.CCD_左载台激光清洗位);
                        }
                        break;
                    case AutoRunStep.CCDTaska_A_激光位到位检测:
                        if (ManageContral.DetectingAxis(CCDTaska_A_AixsName) == 0)
                        {
                            //return;
                        }
                        return;
                }
            }
        }

        private void button52_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //uint clk;
            //double date = 0.0;
            //double dbRet = 0.0;
            //short _dbRet = 0;
            //GTN.mc.GTN_GetAuAdc(2, 1, out dbRet, 1, out clk);
            //当前模拟量.Text = dbRet.ToString();
        }

        private void button54_Click_1(object sender, EventArgs e)
        {
            调高();
        }

        string FasciculeX_AixsName = "分堆X轴";
        string FasciculeY_AixsName = "分堆Y轴";
        string FasciculeZ_AixsName = "分堆Z轴";
        public double 调高()
        {
            double Rels = 0.0;
            uint clk;
            double date = 0.0;
            double ad = DateSave.Instance().Production.BaselineSimulation;//获取基准模拟量
            Thread.Sleep(100);
            GTN.mc.GTN_GetAuAdc(2, 1, out date, 1, out clk);
            double ad12 = DateSave.Instance().Production.Z_AxialDatum;//获取Z基准坐标
            double sf = ad - date;
            if (sf > 0)
            {
                double s = Math.Abs(sf);
                double z = s / DateSave.Instance().Production.High_Date;
                double CurrentZA = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[FasciculeZ_AixsName].AisxCurrentPosition;
          
                Rels = z;
                double NeedCurrentZA = CurrentZA +z;
                ManageContral.AxisPMoveAbsoluteToStop(FasciculeZ_AixsName, NeedCurrentZA);
                //double NeedCurrentZA = CurrentZA - z;
            }
            else
            {
                double s = Math.Abs(sf);
                double z = s / DateSave.Instance().Production.High_Date;
                double CurrentZA = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[FasciculeZ_AixsName].AisxCurrentPosition;
                Rels = z;
                double NeedCurrentZA = CurrentZA -z;
                ManageContral.AxisPMoveAbsoluteToStop(FasciculeZ_AixsName, NeedCurrentZA);
    
            }
            return Rels;
        }

        private void button56_Click_1(object sender, EventArgs e)
        {
            翻放位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[下料AixsName].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.翻放位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[下料AixsName].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button55_Click_1(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(下料AixsName, DateSave.Instance().Production.翻放位);
         
        }

        private void button60_Click_1(object sender, EventArgs e)
        {
            测高位.Text = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Y轴].AisxCurrentPosition.ToString();
            DateSave.Instance().Production.测高位 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[分堆Y轴].AisxCurrentPosition;
            DateSave.Instance().SaveDoc();
        }

        private void button59_Click_1(object sender, EventArgs e)
        {
            ManageContral.AxisPMoveAbsoluteToStop(分堆Y轴, DateSave.Instance().Production.测高位);
        }
    }
}
