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
    public partial class OtherForm : Form
    {
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }
        public OtherForm()
        {
            InitializeComponent();
        }
        public void ShowFromMessage()
        {
            label1.Text = hardwareName;
            try
            {
                最小模拟量.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].最小模拟量.ToString() ;
                最大模拟量.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].最大模拟量.ToString();
                Z轴最小坐标.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Z轴最小坐标.ToString();
                Z轴最大坐标.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Z轴最大坐标.ToString();

                关联后所对应.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].关联后所对应.ToString();
                基准点模拟量.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].基准点模拟量.ToString();

                基准Z坐标.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].基准Z坐标.ToString();
                基准X坐标.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].基准X坐标.ToString();

                基准Y坐标.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].基准Y坐标.ToString();



                X偏距.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].X偏距振镜.ToString();
                Y偏距.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Y偏距振镜.ToString();
                X偏距测高.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].X偏距测高.ToString();
                Y偏距测高.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Y偏距测高.ToString();

                相机位置X.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].相机位置X.ToString();
                相机位置Y.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].相机位置Y.ToString();
                相机位置Z.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].相机位置Y.ToString();

                激光位置X.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].激光位置X.ToString();
                激光位置Y.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].激光位置Y.ToString();
                激光位置Z.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].激光位置Z.ToString();

                测高位置X.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].测高位置X.ToString();
                测高位置Y.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].测高位置Y.ToString();
                测高位置Z.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].测高位置Z.ToString();

                焦点位置X.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].焊接焦点位置X.ToString();
                焦点位置Y.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].焊接焦点位置Y.ToString();
                焦点位置Z.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].焊接焦点位置Z.ToString();

                Z轴安全高度最高.Text =Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Z轴安全高度最高.ToString();

                Z轴安全高度最低.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Z轴安全高度最低.ToString();

                调高最高.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].调高最高.ToString();

                调高最低.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].调高最低.ToString(); 

                ChannelNumber.Text= Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text]._Channel_Number.ToString();
                Card_Num.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text]._Card_Num.ToString();
              
            }
            catch { }
        }

        private void 获取最小模拟量_Click(object sender, EventArgs e)
        {
            double date = 0.0;
            //卡号
            //通道号
            //数据
            Googol_Contral.GT_GetAdc(0, 1, out date);
        }

        private void 获取最大模拟量_Click(object sender, EventArgs e)
        {
            double date = 0.0;
            //卡号
            //通道号
            //数据
            Googol_Contral.GT_GetAdc(0, 1, out date);

        }


        private void 获取最小Z轴坐标_Click(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (item.Value.是否做测距轴==1)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Z轴最小坐标 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition ;
                    Z轴最小坐标.Text = (Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Z轴最小坐标).ToString();
                } 
            }
          
            //Z轴最小坐标.Text = date.ToString();
            //  Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Z轴最小坐标 = date;
        }

        private void 获取最大Z轴坐标_Click(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (item.Value.是否做测距轴 == 1)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Z轴最大坐标 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition ;
                    Z轴最大坐标.Text =( Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Z轴最大坐标).ToString();
                }
            }
        }

        private void 获取关联数据_Click(object sender, EventArgs e)
        {
            double 最大模拟量数据 = Convert.ToDouble(最大模拟量.Text);
            double 最小模拟量数据 = Convert.ToDouble(最小模拟量.Text);
            double 最大Z轴坐标数据 = Convert.ToDouble(Z轴最大坐标.Text);
            double 最小Z轴坐标数据 = Convert.ToDouble(Z轴最小坐标.Text);
            double date1 = Math.Abs(最大模拟量数据 - 最小模拟量数据);
            double date2 = Math.Abs(最大Z轴坐标数据 - 最小Z轴坐标数据);
            Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].关联后所对应=Math.Abs(date1 / date2) ;
            关联后所对应.Text = Math.Abs(date1 / date2).ToString();
        }

        private void 获取基准模拟量_Click(object sender, EventArgs e)
        {
            double date = 0.0;
            //卡号
            //通道号
            //数据
            Googol_Contral.GT_GetAdc(0, 1, out date);
            基准点模拟量.Text = date.ToString();
            Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].基准点模拟量 = date;
        }

        private void 获取基准坐标_Click(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (/*item.Value.是否做插补轴 == 1&&*/ item.Value.m_AxisNo==0)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].基准X坐标 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition ;
                    基准X坐标.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].基准X坐标.ToString();
                }
                if (/*item.Value.是否做插补轴 == 1 && */item.Value.m_AxisNo == 1)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].基准Y坐标 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition;
                    基准Y坐标.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].基准Y坐标.ToString();
                }
                if (item.Value.m_AxisNo == 2)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].基准Z坐标 = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition;
                    基准Z坐标.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].基准Z坐标.ToString();
                }
            }
        }

        private void X偏距_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void 相机位置_Click(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if ( item.Value.m_AxisNo == 0)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].相机位置X =( Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition );
                    相机位置X.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].相机位置X.ToString();
                }
                if ( item.Value.m_AxisNo == 1)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].相机位置Y =( Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition);
                    相机位置Y.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].相机位置Y.ToString();
                }
                if (item.Value.是否做测距轴 == 1)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].相机位置Z = (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition);
                    相机位置Z.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].相机位置Z.ToString();
                }
            }
        }

        private void 获取激光位置_Click(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (item.Value.m_AxisNo == 0)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].激光位置X = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition;
                    激光位置X.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].激光位置X.ToString();
                }
                if (item.Value.m_AxisNo == 1)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].激光位置Y = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition ;
                    激光位置Y.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].激光位置Y.ToString();
                }
                if (item.Value.是否做测距轴 == 1)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].激光位置Z = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition;
                    激光位置Z.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].激光位置Z.ToString();
                }
            }

        }

        private void 获取测高位置_Click(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (item.Value.m_AxisNo == 0)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].测高位置X = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition;
                    测高位置X.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].测高位置X.ToString();
                }
                if (item.Value.m_AxisNo == 1)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].测高位置Y = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition;
                    测高位置Y.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].测高位置Y.ToString();
                }
                if (item.Value.是否做测距轴 == 1)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].测高位置Z = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition;
                    测高位置Z.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].测高位置Z.ToString();
                }
            }
        }

        private void 调高_Click(object sender, EventArgs e)
        {
            //Googol_Contral. 调高_方法(label1 .Text);
        }
        public void 调高_方法()
        {
           // double ReferenceAnalog =Convert.ToDouble( 基准点模拟量.Text);//、、 获取基准模拟量   
            double ReferenceAnalog = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].基准点模拟量;//、、 获取基准模拟量   
            Thread.Sleep(100);
            double date = 0.0;
            //卡号
            //通道号
            //数据
            Googol_Contral.GT_GetAdc(0, 1, out date);// 当前模拟量
           // double GetReferenceCoordinates = Convert.ToDouble(基准Z坐标.Text);//获取Z基准坐标
            double GetReferenceCoordinates = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].基准Z坐标;
            double AnalogDifference = ReferenceAnalog - date;//模拟量差值
            double AssociatedData = 0; //关联数据
            AssociatedData = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].关联后所对应;
          //  AssociatedData = Convert.ToDouble(关联后所对应.Text); //关联数据
            double CurrentZA = 0;
            string Asix_Name = "";
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (item.Value.是否做测距轴 ==1)
                {
                    Asix_Name = item.Value.Axis_hardwareName;
                    CurrentZA = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition;
                }            
            }
            if (AnalogDifference > 0)
            {
                double s = Math.Abs(AnalogDifference);
                double z = (s / AssociatedData)*1000;           
                double NeedCurrentZA = CurrentZA - z;
                //Googol_Contral. AxisPMoveAbsoluteToStop(Asix_Name, NeedCurrentZA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Dec);
            }
            else
            {
                double s = Math.Abs(AnalogDifference);
                double z =( s / AssociatedData) * 1000;
                double NeedCurrentZA =CurrentZA + z;
               // Googol_Contral.AxisPMoveAbsoluteToStop(Asix_Name, NeedCurrentZA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[Asix_Name].Dec);

            }

        }

        private void 到基准点_Click(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (item.Value.m_AxisNo == 0)
                {
                 double   NeedCurrentXA =Convert.ToDouble( 基准X坐标.Text);
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentXA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }
                if (item.Value.m_AxisNo == 1)
                {
                    double NeedCurrentYA = Convert.ToDouble(基准Y坐标.Text);
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentYA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }
                if (item.Value.是否做测距轴 == 1)
                {
                    double NeedCurrentZA = Convert.ToDouble(基准Z坐标.Text);
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentZA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }
            }

         


        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary)
            {
                if (item.Value.Get_High_hardwareName == label1.Text)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].默认参数 = true;
                }
                else
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[item.Value.Get_High_hardwareName].默认参数 = false;
                }

            }
        
        }

        private void 计算偏距_Click(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].X偏距振镜 = Math.Abs(Convert.ToDouble(激光位置X.Text) - Convert.ToDouble(相机位置X.Text));
                X偏距.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].X偏距振镜.ToString();


                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Y偏距振镜 = Convert.ToDouble(激光位置Y.Text) - Convert.ToDouble(相机位置Y.Text);
                Y偏距.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Y偏距振镜.ToString();



                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].X偏距测高 = Math.Abs(Convert.ToDouble(测高位置X.Text) - Convert.ToDouble( 相机位置X.Text));
                X偏距测高.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].X偏距测高.ToString();


                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Y偏距测高 = Math.Abs(Convert.ToDouble(测高位置Y.Text) - Convert.ToDouble(相机位置Y.Text));
                Y偏距测高.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Y偏距测高.ToString();
            }
            catch
            {
            }
          


            }

        private void 获取焦点位置_Click(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (item.Value.m_AxisNo == 0)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].焊接焦点位置X = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition;
                    焦点位置X.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].焊接焦点位置X.ToString();
                }
                if (item.Value.m_AxisNo == 1)
                {
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].焊接焦点位置Y = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition ;
                    焦点位置Y.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].焊接焦点位置Y.ToString();
                }

                if (item.Value.是否做测距轴 == 1)
                {                
                    Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].焊接焦点位置Z = Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition ;
                    焦点位置Z.Text = Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].焊接焦点位置Z.ToString();
                }
                
            }

        }

        private void 去焦点_Click(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (item.Value.m_AxisNo == 0)
                {
                    double NeedCurrentXA = Convert.ToDouble(焦点位置X.Text);
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentXA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }
                if (item.Value.m_AxisNo == 1)
                {
                    double NeedCurrentYA = Convert.ToDouble(焦点位置Y.Text) ;
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentYA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }
                if (item.Value.是否做测距轴 == 1)
                {
                    double NeedCurrentZA = Convert.ToDouble(焦点位置Z.Text) ;
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentZA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }
            }
        }

        private void 到相机位置_Click(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (item.Value.m_AxisNo == 0)
                {
                    double NeedCurrentXA = Convert.ToDouble(相机位置X.Text);
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentXA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }
                if (item.Value.m_AxisNo == 1)
                {
                    double NeedCurrentYA = Convert.ToDouble(相机位置Y.Text) ;
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentYA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }
                if (item.Value.是否做测距轴 == 1)
                {
                    double NeedCurrentYA = Convert.ToDouble(相机位置Z.Text);
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentYA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }

            }
        }

        private void 到激光位置_Click(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (item.Value.m_AxisNo == 0)
                {
                    double NeedCurrentXA = Convert.ToDouble(激光位置X.Text) ;
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentXA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }
                if (item.Value.m_AxisNo == 1)
                {
                    double NeedCurrentYA = Convert.ToDouble(激光位置Y.Text) ;
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentYA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }
                if (item.Value.是否做测距轴  ==1)
                {
                    double NeedCurrentYA = Convert.ToDouble(激光位置Z.Text);
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentYA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double date = 0.0;
            //卡号
            //通道号
            //数据
            Googol_Contral.GT_GetAdc(0, 1, out date);
            当前模拟量.Text = date.ToString();

            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {

             
                if (item.Value.m_AxisNo == 3)
                {

                    当前坐标.Text = (Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].AisxCurrentPosition ).ToString();
                }

            }
        }

        private void Card_Num_TextChanged(object sender, EventArgs e)
        {
            Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text]._Card_Num = Convert.ToInt16(Card_Num.Text);
        }

        private void ChannelNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text]._Channel_Number = Convert.ToInt16(ChannelNumber.Text);
            }
            catch { }
            
          
        }

        private void 到测高位置_Click(object sender, EventArgs e)
        {
            foreach (var item in Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary)
            {
                if (item.Value.m_AxisNo == 0)
                {
                    double NeedCurrentXA = Convert.ToDouble(测高位置X.Text);
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentXA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }
                if (item.Value.m_AxisNo == 1)
                {
                    double NeedCurrentYA = Convert.ToDouble(测高位置Y.Text);
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentYA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }
                if (item.Value.是否做测距轴 == 1)
                {
                    double NeedCurrentYA = Convert.ToDouble(测高位置Z.Text);
                    ManageContral.AxisPMoveAbsoluteToStop(item.Value.Axis_hardwareName, NeedCurrentYA, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Speed, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Acc, Hard_Ward_Contral.Aisx_Hard_Doc.mAisx_Hard_Date_Dictionary[item.Value.Axis_hardwareName].Dec);
                }

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text]._Card_Num = Convert.ToInt16(Card_Num.Text);
            }
            catch
            {
            }
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text]._Channel_Number = Convert.ToInt16(ChannelNumber.Text);
            }
            catch { }
        }

        private void Z轴安全高度最高_TextChanged(object sender, EventArgs e)
        {
            try
            {       
               Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Z轴安全高度最高 = Convert.ToInt32(Z轴安全高度最高.Text);
            }
            catch { }
        }

        private void Z轴安全高度最低_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].Z轴安全高度最低 = Convert.ToInt32(Z轴安全高度最低.Text);
            }
            catch { }
        }

        private void 调高最高_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].调高最高 = Convert.ToInt32(调高最高.Text);
            }
            catch { }
        }

        private void 调高最低_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Hard_Ward_Contral._Get_High_Date_Save.Get_High_Hard_Date_Dictionary[label1.Text].调高最低 = Convert.ToInt32(调高最低.Text);
            }
            catch { }
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
        private void 调高最高_KeyPress(object sender, KeyPressEventArgs e)
        {
            _KeyPress(sender, e);
        }
    }
}
