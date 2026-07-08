using HalconDotNet;
using HOperatorSet_EX;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    [Serializable]
    public class PMAlignTool : ImageTool
    {
        // Local iconic variables 
        [NonSerialized]
        HObject ho_ROI_0, ho_ImageReduced, ho_PaintImageModel,ho_SeachROI;
        public HObject ROI
        {
            get { return ho_ROI_0; }
            set { ho_ROI_0 = value; }
        }
        [NonSerialized]
        HObject ho_Cross;
        [NonSerialized]
        HTuple hv_Width = null, hv_Height = null;
        #region 输出结果
        public bool ResultLogic { get; set; }
        [NonSerialized]
        HTuple hv_Row, hv_Column, hv_Angle, hv_ScaleR, hv_ScaleC, hv_Score;
        public HTuple ResultRow
        {
            get { return hv_Row; }
            set { hv_Row = value; }
        }
        public HTuple ResultColumn
        {
            get { return hv_Column; }
            set { hv_Column = value; }
        }
        public HTuple ResultAngle
        {
            get { return hv_Angle; }
            set { hv_Angle = value; }
        }
        public HTuple ResultScaleR
        {
            get { return hv_ScaleR; }
            set { hv_ScaleR = value; }
        }
        public HTuple ResultScaleC
        {
            get { return hv_ScaleC; }
            set { hv_ScaleC = value; }
        }
        public HTuple ResultScore
        {
            get { return hv_Score; }
            set { hv_Score = value; }
        }
        #endregion
        #region 输出结果判定
        public HTuple LowScore
        { get; set; }
        public HTuple HigScore
        { get; set; }
        public bool IsSocre
        { get; set; }

        public HTuple LowNums
        { get; set; }
        public HTuple HigNums
        { get; set; }

        public bool IsNums
        { get; set; }

        #endregion 
        #region 参数
        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names { get; set; }
          /// <summary>
        /// 区域轮廓显示模式
        /// </summary>
        public string Setdraw { get; set; }
        /// <summary>
        /// ROI路径
        /// </summary>
        public string RoiPath { get; set; }
        public string RegionType { get; set; }
        /// <summary>
        /// 模板路径
        /// </summary>
        public string ModelPath { get; set; }
        public bool IsModeXld { get; set; }
        public bool IsCross { get; set; }

        [NonSerialized]
         Dictionary<string, HObject> ho_Image = new  Dictionary<string, HObject>();
        /// <summary>
        /// 输入图像
        /// </summary>
        public  Dictionary<string, HObject> Image
        {
            get { return ho_Image; }
            set { ho_Image = value; }
        }
        [NonSerialized]
        HTuple hv_ModelID = null;
        public HTuple ModelID
        {
            get { return hv_ModelID; }
            set { hv_ModelID = value; }
        }
        #region ROI参数
        HTuple hv_circle = new HTuple();//圆形
        /// <summary>
        /// 圆形
        /// </summary>
        public HTuple Circle
        {
            get { return hv_circle; }
            set { hv_circle = value; }
        }
        HTuple hv_rectangle1 = new HTuple();//矩形
        /// <summary>
        /// 矩形
        /// </summary>
        public HTuple Rectangle1
        {
            get { return hv_rectangle1; }
            set { hv_rectangle1 = value; }
        }
        HTuple hv_rectangle2 = new HTuple();//方向矩形
        /// <summary>
        /// 方向矩形
        /// </summary>
        public HTuple Rectangle2
        {
            get { return hv_rectangle2; }
            set { hv_rectangle2 = value; }
        }
        /// <summary>
        ///ROI形状
        /// </summary>
        public string SetdrawShape { get; set; }
        /// <summary>
        /// 显示roi
        /// </summary>
        public bool IsDispRoi { get; set; }

        #endregion
        #region 模板参数
        public HTuple Cm_AngleStart { get; set; }
        public HTuple Cm_AngleExtent { get; set; }
        public HTuple Cm_ScaleCMin { get; set; }
        public HTuple Cm_ScaleCMax { get; set; }
        public HTuple Cm_ScaleRMin { get; set; }
        public HTuple Cm_ScaleRMax { get; set; }
        public string Cm_Metric { get; set; }

        public bool Cm_IsNumLevels { get; set; }
        public bool Cm_IsContrast { get; set; }
        public bool Cm_IsMinContrast { get; set; }

        public HTuple Cm_NumLevels { get; set; }
        public HTuple Cm_ContrastHig { get; set; }
        public HTuple Cm_ContrastLow { get; set; }

        public HTuple Cm_MinBorder { get; set; }
        public HTuple Cm_MinContrast { get; set; }
        public string Cm_Optimization { get; set; }


        //找模板
        public HTuple Fm_AngleStart { get; set; }
        public HTuple Fm_AngleExtent { get; set; }
        public HTuple Fm_ScaleCMin { get; set; }
        public HTuple Fm_ScaleCMax { get; set; }
        public HTuple Fm_ScaleRMin { get; set; }
        public HTuple Fm_ScaleRMax { get; set; }
        public HTuple Fm_MinScore { get; set; }
        public HTuple Fm_NumMatches { get; set; }
        public HTuple Fm_MaxOverlap { get; set; }//最大重叠
        public string Fm_SubPixel { get; set; }
        public HTuple Fm_Greediness { get; set; }
        public HTuple Fm_NumLevels { get; set; }

        #endregion
        #region 喷图模板
        public int ThresholdMin{ get; set; }
        public int ThresholdMax { get; set; }
        public int SelectedRegionMin { get; set; }
        public int SelectedRegionMax { get; set; }
        public int PaintGrayVal { get; set; }
        public bool IsPaintModel { get; set; }
        #endregion
        #region  搜索模板区域
        HTuple searchModeRoi = new HTuple();
        public HTuple SearchModeRoi
        {
            get { return searchModeRoi; }
            set { searchModeRoi = value; }
        }
        public bool IsSearchRegion { get; set; }
        #endregion
        #endregion
        public override string toolName()
        {
            return Names;
        }
        public override long toolTimer()
        {
            return timer;
        }
        public override void ini()
        {   //创建模板
            Cm_AngleStart = -20;
            Cm_AngleExtent = 60;
            Cm_ScaleCMax = 1.0;
            Cm_ScaleCMin = 1.0;
            Cm_ScaleRMax = 1.0;
            Cm_ScaleRMin = 1.0;
            Cm_Metric = "use_polarity";

            Cm_Optimization = "auto";
            Cm_NumLevels = 5;
            Cm_ContrastHig = 10;//对比度(上限)
            Cm_ContrastLow = 6;//对比度(下限)
            Cm_MinBorder = 4;//边缘最小尺寸
            Cm_MinContrast = 3;//最小对比度

            Cm_IsContrast = true;      //auto
            Cm_IsMinContrast = true;   //
            Cm_IsNumLevels = true;     //
            

            //找模板
            Fm_AngleStart = -20;
            Fm_AngleExtent = 60;
            Fm_ScaleCMax = 1.0;
            Fm_ScaleCMin = 1.0;
            Fm_ScaleRMax = 1.1;
            Fm_ScaleRMin = 1.0;
            Fm_MinScore = 0.5;
            Fm_NumMatches = 1;
            Fm_MaxOverlap = 0.5;
            Fm_Greediness = 0.8;
            Fm_SubPixel = "least_squares";
            Fm_NumLevels = 2;
            //
            ImageName = "采集图像0";
            Names = "模板匹配";

            hv_circle[0] = 50;//圆形
            hv_circle[1] = 50;//圆形
            hv_circle[2] = 50;//圆形

            hv_rectangle1[0] = 50;//矩形
            hv_rectangle1[1] = 50;//矩形
            hv_rectangle1[2] = 100;//矩形
            hv_rectangle1[3] = 100;//矩形

            hv_rectangle2[0] = 200;//方向矩形
            hv_rectangle2[1] = 200;//方向矩形
            hv_rectangle2[2] = 0;//方向矩形
            hv_rectangle2[3] = 50;//方向矩形
            hv_rectangle2[4] = 50;//方向矩形

            searchModeRoi[0] = 100;//矩形
            searchModeRoi[1] = 100;//矩形
            searchModeRoi[2] = 300;//矩形
            searchModeRoi[3] = 300;//矩形
            IsSearchRegion = false;

            //喷模板
            IsPaintModel = false;
            ThresholdMin = 5;
            ThresholdMax = 150;
            SelectedRegionMin = 1000;
            SelectedRegionMax = 10000;
            PaintGrayVal = 100;
            IsSocre = false;

            Setdraw = Set_draw.margin.ToString();//区域轮廓显示
            SetdrawShape = Roi.矩形.ToString(); ;//ROI形状
            IsDispRoi = true;

            IsCross = false;
            IsModeXld = true;

            LowScore = 0.5;
            HigScore = 1.0;
            LowNums = 1;
            HigNums = 2;

            IsSocre = false;
            IsNums = false;
        }
        public override void recon()//加载读取参数
        {
            try
            {
                HOperatorSet.SetSystem("border_shape_models", "false");
                if (ModelPath != null)
                {
                    int Debug = ModelPath.LastIndexOf("Debug");//是否是debug下的文件
                    if (Debug != -1)
                    {
                        string bugPath = ModelPath.Substring(Debug + 5, ModelPath.Length - (Debug + 5));//截取Debug下的文件,例如 原路径 C://Debug//1
                        string NewImagePath = Application.StartupPath + bugPath;//复制到不同的文件夹,复制到D盘,替换新的路径,例如 d://Debug//1
                        ModelPath = NewImagePath;
                        if (hv_ModelID == null)
                            HOperatorSet.ReadShapeModel(ModelPath, out hv_ModelID);//读取模板
                    }
                    else
                    {
                        if (hv_ModelID == null)
                            HOperatorSet.ReadShapeModel(ModelPath, out hv_ModelID);//读取模板
                    }
                 }
                else
                {
                    MessageBox.Show("读取模板失败!");
                }
            }
            catch
            {
                MessageBox.Show("读取模板失败!");
            }

            try
            {
                if (RoiPath != null)
                {
                    int Debug = RoiPath.LastIndexOf("Debug");//是否是debug下的文件
                    if (Debug != -1)
                    {
                        string bugPath = RoiPath.Substring(Debug + 5, RoiPath.Length - (Debug + 5));//截取Debug下的文件,例如 原路径 C://Debug//1
                        string NewRoiPath = Application.StartupPath + bugPath;//复制到不同的文件夹,复制到D盘,替换新的路径,例如 d://Debug//1
                        RoiPath = NewRoiPath;
                    }
                    HOperatorSet.ReadRegion(out ho_ROI_0, RoiPath);//读取ROI
                }
                else
                {
                    MessageBox.Show("读取ROI失败!");
                }
            }
            catch
            {
                MessageBox.Show("读取ROI失败!");
            }
        }
        /// <summary>
        ///  模板清除
        /// </summary>
        /// <param name="ModelID"></param>
        public void ClearShapeModel(ref HTuple ModelID)
        {
            try
            {
                if (ModelID != null)
                {
                    HOperatorSet.ClearShapeModel(ModelID);
                    ModelID = null;
                }
            }
            catch
            {
                ModelID = null;
            }
        }
        /// <summary>
        ///  读取模板
        /// </summary>
        /// <param name="ModelPath"></param>
        /// <param name="ModelID"></param>
        public void ReadShapeModel(string ModelPath, ref HTuple ModelID)
        {
            if (ModelPath != null)
            {
                if (ModelID == null)
                    HOperatorSet.ReadShapeModel(ModelPath, out ModelID);//读取模板
            }
        }
        public void ReadShapeModel()
        {
            ReadShapeModel(ModelPath, ref hv_ModelID);
        }
        public void ReadModel()
        {
          OpenFileDialog OpenMode = new OpenFileDialog();
          OpenMode.Filter = "模板数据(*.shm)|*.shm";
          OpenMode.FileName = ModelPath;
          if (OpenMode.ShowDialog() == DialogResult.OK)
          {
              ModelPath = OpenMode.FileName;
              ClearShapeModel(ref hv_ModelID);
              ReadShapeModel(ModelPath, ref  hv_ModelID);//读取模板
              HTuple NumLevel1;
              get_shape_model_param(hv_ModelID, out NumLevel1);
          }
        }
        public void saveModel()
        {
            SaveFileDialog SaveMode = new SaveFileDialog();
            SaveMode.Filter = "模板数据(*.shm)|*.shm";
            SaveMode.FileName = ModelPath;
            if (SaveMode.ShowDialog() == DialogResult.OK)
            {
                ModelPath = SaveMode.FileName;
                switch (SaveMode.FilterIndex)
                {
                    case 1:
                        if (!Directory.Exists(Application.StartupPath + @"\Model\"))
                        {
                            Directory.CreateDirectory(Application.StartupPath + @"\Model\");
                            HOperatorSet.WriteShapeModel(hv_ModelID, ModelPath);
                        }
                        else
                        {
                            HOperatorSet.WriteShapeModel(hv_ModelID, ModelPath);
                        }
                        break;
                }
            }
            SaveMode.Dispose();
            HSystem.SetSystem("flush_graphic", "false");

        }
        public void drawSearchRoi()//
        {
            if (!IsSearchRegion)
            {
                MessageBox.Show("请使用模板搜索区域");
                return;
            }

              HTuple hv_rec1Column1 = new HTuple(), hv_rec1Row1 = new HTuple();
              HTuple hv_rec1Column2 = new HTuple(), hv_rec1Row2 = new HTuple();
            try
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
                HOperatorSet.DispObj((HObject)Image[ImageName], hWindowControl1.HalconWindow);
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "创建模板搜索区域,右键确定！", "image", 10, 10, "green", "false");
                if (searchModeRoi.Length >1) //是否存在搜索区域
                  HOperatorSet.DrawRectangle1Mod(hWindowControl1.HalconWindow, searchModeRoi[0], searchModeRoi[1], searchModeRoi[2], searchModeRoi[3], out hv_rec1Row1, out hv_rec1Column1, out hv_rec1Row2, out hv_rec1Column2);
                else     //
                  HOperatorSet.DrawRectangle1(hWindowControl1.HalconWindow,  out hv_rec1Row1, out hv_rec1Column1, out hv_rec1Row2, out hv_rec1Column2);
                searchModeRoi[0] = hv_rec1Row1;
                searchModeRoi[1] = hv_rec1Column1;
                searchModeRoi[2] = hv_rec1Row2;
                searchModeRoi[3] = hv_rec1Column2;
                HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, searchModeRoi[0], searchModeRoi[1], searchModeRoi[2], searchModeRoi[3]);
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "搜索区域", "image", searchModeRoi[0]+10, searchModeRoi[1]+10, "green", "false");
                HSystem.SetSystem("flush_graphic", "false");
                set_after();
            }
            catch
            {
                MessageBox.Show("模板搜索区域异常!");
            }
        }
        void setParm(out HTuple hv_Contrast, out HTuple hv_MinContrast, out HTuple hv_NumLevels)
        {
            hv_Contrast = new HTuple();
            if (Cm_IsContrast)
                hv_Contrast = "auto";
            else         //滞后阀值
            { hv_Contrast[0] = Cm_ContrastLow; hv_Contrast[1] = Cm_ContrastHig; hv_Contrast[2] = Cm_MinBorder; }
            if (Cm_IsMinContrast)
                hv_MinContrast = "auto";
            else
                hv_MinContrast = Cm_MinContrast;     //最小长度边缘

            if (Cm_IsNumLevels)       //金字塔层数
                hv_NumLevels = "auto";
            else
                hv_NumLevels = Cm_NumLevels;
         }
        /// <summary>
        /// 调整模板
        /// </summary>
        public  void adjustModel()
        {
            try
            {
                genRoi();
                HTuple hv_Contrast = new HTuple(); HTuple hv_MinContrast; HTuple hv_NumLevels;
                setParm(out hv_Contrast, out hv_MinContrast, out hv_NumLevels);
                if (IsPaintModel)//用喷模板
                {
                    ClearShapeModel(ref hv_ModelID);
                    HOperatorSet.GenEmptyObj(out ho_PaintImageModel);
                    ho_PaintImageModel.Dispose();
                    get_modelimage(Image[ImageName], ho_ROI_0, out ho_PaintImageModel, ThresholdMin, ThresholdMax, SelectedRegionMin, SelectedRegionMax);
                    HOperatorSet.CreateAnisoShapeModel(ho_PaintImageModel, hv_NumLevels, Cm_AngleStart.TupleRad(), Cm_AngleExtent.TupleRad(), "auto",
                                                                                Cm_ScaleRMin, Cm_ScaleRMax, "auto", Cm_ScaleCMin, Cm_ScaleCMax,
                                                                                "auto",
                                                                                Cm_Optimization,
                                                                                Cm_Metric,
                                                                                hv_Contrast,
                                                                                hv_MinContrast,
                                                                                out hv_ModelID);

                }
                else//
                {
                    ClearShapeModel(ref hv_ModelID);
                    HOperatorSet.ReduceDomain((HObject)Image[ImageName], ho_ROI_0, out ho_ImageReduced);
                    HOperatorSet.CreateAnisoShapeModel(ho_ImageReduced, hv_NumLevels, Cm_AngleStart.TupleRad(), Cm_AngleExtent.TupleRad(), "auto",
                                                                                Cm_ScaleRMin, Cm_ScaleRMax, "auto", Cm_ScaleCMin, Cm_ScaleCMax,
                                                                                "auto",
                                                                                Cm_Optimization,
                                                                                Cm_Metric,
                                                                                hv_Contrast,
                                                                                hv_MinContrast,
                                                                                out hv_ModelID);

                }
                if (ModelPath == null)
                    saveModel();
            }
            catch
            {
                MessageBox.Show("调整模板异常,先创建模板！");
            }
        }
        public override void draw_roi()
        {
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "绘制ROI,右键确定！", CoordSystem.window.ToString(), 10, 10, ColorFul.black.ToString(), ColorFul.white.ToString());
            HSystem.SetSystem("flush_graphic", "false");
            draw_roi(hWindowControl1.HalconWindow, ho_Image, ImageName, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2, out hv_circle, out hv_rectangle1, out hv_rectangle2);
            
            adjustModel();
            set_after();
        }
        public void ReadRoi()
        {
            OpenFileDialog OpenMode = new OpenFileDialog();
            OpenMode.Filter = "ROI数据(*.hobj)|*.hobj";
            OpenMode.FileName = RoiPath;
            if (OpenMode.ShowDialog() == DialogResult.OK)
            {
                RoiPath = OpenMode.FileName;
                RoiClear();
                HOperatorSet.ReadRegion(out ho_ROI_0, RoiPath);//读取ROI
            }
            set_after();
        }
        public void ReadRoi(string RoiPath)
        {
            this.RoiPath = RoiPath;
            RoiClear();
            HOperatorSet.ReadRegion(out ho_ROI_0, RoiPath);//读取ROI
            set_after();
        }
        void genRoi()
        {
            HObject ho_EmptyRegion;
            HOperatorSet.GenEmptyObj(out ho_EmptyRegion);
            ho_EmptyRegion.Dispose();
            gen_roi(out ho_EmptyRegion, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2);
            if (ho_ROI_0 == null)
                ho_ROI_0 = ho_EmptyRegion;
            if (RegionType == Tool.区域合并.ToString())
            {    //合并区域
                if (ho_ROI_0 != null)
                    HOperatorSet.Union2(ho_ROI_0, ho_EmptyRegion, out ho_ROI_0);
            }
            if (RegionType == Tool.区域差集.ToString())
            {   //差集
                if (ho_ROI_0 != null)
                    HOperatorSet.Difference(ho_ROI_0, ho_EmptyRegion, out ho_ROI_0);
            }
            if (RegionType == Tool.区域交集.ToString())
            {   //交集
                if (ho_ROI_0 != null)
                    HOperatorSet.Intersection(ho_ROI_0, ho_EmptyRegion, out ho_ROI_0);
            }
            if (RegionType == Tool.区域对称差.ToString())
            {  //对称差Xor
                if (ho_ROI_0 != null)
                    HOperatorSet.SymmDifference(ho_ROI_0, ho_EmptyRegion, out ho_ROI_0);
            }
        }
        public void RoiClear()
        {
            if (ho_ROI_0 != null)
            {
                ho_ROI_0.Dispose();
            }
            ho_ROI_0 = null;
        }
        public void SaveRoi()
        {
            if (ho_ROI_0 != null)
            {
                SaveFileDialog SaveMode = new SaveFileDialog();
                SaveMode.Filter = "ROI数据(*.hobj)|*.hobj";
                SaveMode.FileName = RoiPath;
                if (SaveMode.ShowDialog() == DialogResult.OK)
                {
                    RoiPath = SaveMode.FileName;
                    switch (SaveMode.FilterIndex)
                    {
                        case 1:
                            if (!Directory.Exists(Application.StartupPath + @"\ROI\"))
                            {
                                Directory.CreateDirectory(Application.StartupPath + @"\ROI\");
                                HOperatorSet.WriteRegion(ho_ROI_0, RoiPath);
                            }
                            else
                                HOperatorSet.WriteRegion(ho_ROI_0, RoiPath);
                            break;
                    }
                }
                SaveMode.Dispose();
            }

        }
       
        public override void dispresult()
        {
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
            if (IsDispRoi && ho_ROI_0 != null)
                HOperatorSet.DispObj(ho_ROI_0, hWindowControl1.HalconWindow);
            if (hv_Score == null)//  是否有结果
                return;
            string strScore = "", strScaleR = "", strScaleC = "";
            try
            {
             
                HOperatorSet_Ex.set_display_font(hWindowControl1.HalconWindow, 12, "sans", "false", "false");//mono', 'sans', 'serif
                HObject ho_AffinTransModelContours;
                if (ResultLogic)
                {
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
                    HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
                }
                else
                {
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, "red");
                    HOperatorSet.SetDraw(hWindowControl1.HalconWindow, "margin");
                }

              
                if (IsSearchRegion)//限定区域搜索模板
                {
                    HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, searchModeRoi[0], searchModeRoi[1], searchModeRoi[2], searchModeRoi[3]);
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "搜索区域", "image", searchModeRoi[0], searchModeRoi[1], "green", "false");
                }
                for (int i = 0; i < hv_Score.Length; i++)
                {
                    if (IsModeXld)//显示轮廓
                    {
                        get_shape_model_contour(out ho_AffinTransModelContours, hv_Row[i], hv_Column[i], hv_Angle[i], hv_ScaleR[i], hv_ScaleC[i], hv_ModelID);
                        HOperatorSet.DispObj(ho_AffinTransModelContours, hWindowControl1.HalconWindow);
                    }
                    else
                    {
                        if (hv_circle.Length > 1)
                            HOperatorSet.DispCircle(hWindowControl1.HalconWindow, hv_Row[i], hv_Column[i], hv_circle[2]);
                        if (hv_rectangle2.Length > 1)
                            HOperatorSet.DispRectangle2(hWindowControl1.HalconWindow, hv_Row[i], hv_Column[i], hv_rectangle2[2], hv_rectangle2[3], hv_rectangle2[4]);
                        if (hv_rectangle1.Length > 1)
                        {   //求矩形的长宽的中心点
                            HTuple cR = (hv_rectangle1[2] - hv_rectangle1[0]) / 2;
                            HTuple cC = (hv_rectangle1[3] - hv_rectangle1[1]) / 2;

                            HTuple newR1 = hv_Row[i] - cR;
                            HTuple newC1 = hv_Column[i] - cC;
                            HTuple newR2 = hv_Row[i] + cR;
                            HTuple newC2 = hv_Column[i] + cC;
                            HOperatorSet.DispRectangle1(hWindowControl1.HalconWindow, newR1, newC1, newR2, newC2);
                        }
                    }

                }
                for (int i = 0; i < hv_Score.Length; i++)
                {
                    if (IsCross)//显示坐标
                    {
                        XY(hWindowControl1.HalconWindow, (HObject)Image[ImageName], hv_Row[i], hv_Column[i], hv_Angle[i]);
                    }
                    else//显示mark点
                    {
                        HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Row[i], hv_Column[i], hv_Height / 100, 0);
                        HOperatorSet.DispObj(ho_Cross, hWindowControl1.HalconWindow);
                        ho_Cross.Dispose();
                    }
                }
                if (hv_Score.Length > 0)//结果显示
                {
                    for (int i = 0; i < hv_Score.Length; i++)
                    {
                        strScore += (i + 1).ToString() + ":" + hv_Score.TupleSelect(i).TupleString("0.3f") + " ";
                        strScaleR += (i + 1).ToString() + ":" + ResultScaleR.TupleSelect(i).TupleString("0.3f") + " ";
                        strScaleC += (i + 1).ToString() + ":" + ResultScaleC.TupleSelect(i).TupleString("0.3f") + " ";
                    }
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "匹配到:" + hv_Score.Length + "个" + "Score:" + strScore , "image", searchModeRoi[2] - 50, searchModeRoi[1] + 10, "green", "false");  
                    //ResultLogic = true;//结果正常
                }
                else
                {
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "匹配到0个", "image", searchModeRoi[2] - 50, searchModeRoi[1] + 10, "red", "false");
                    ResultLogic = false;//结果异常
                }
                HSystem.SetSystem("flush_graphic", "false");
                //ClearShapeModel(ref hv_ModelID);
            }
            catch
            {
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "显示异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
                //ClearShapeModel(ref hv_ModelID);
            }
        
        }

        /// <summary>
        /// 运行一次
        /// </summary>
        public override void run()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            toolRun();
            dispresult();
            watch.Stop();
            timer = watch.ElapsedMilliseconds;
        }
        private void toolRun()
        {
            try 
            {
                HSystem.SetSystem("flush_graphic", "true");
                //ReadShapeModel(ModelPath, ref hv_ModelID);
                HTuple NumLevel=new HTuple ();
                HTuple NumLevel1;
                get_shape_model_param(hv_ModelID,out NumLevel1);
                NumLevel[0] = NumLevel1;
                NumLevel[1] = Fm_NumLevels;
                if (hv_ModelID == null)//是否模板句柄为空
                { return; }
                HOperatorSet.GetImageSize((HObject)ho_Image[ImageName], out hv_Width, out hv_Height);
                if (IsSearchRegion)//限定区域搜索模板
                {
                    if (ho_SeachROI != null)
                        ho_SeachROI.Dispose();
                    HOperatorSet.GenRectangle1(out ho_SeachROI, searchModeRoi[0], searchModeRoi[1], searchModeRoi[2], searchModeRoi[3]);
                    HOperatorSet.ReduceDomain((HObject)Image[ImageName], ho_SeachROI, out ho_SeachROI);
                    HOperatorSet.FindAnisoShapeModel(ho_SeachROI, hv_ModelID, Fm_AngleStart.TupleRad(), Fm_AngleExtent.TupleRad(),
                                                               Fm_ScaleRMin, Fm_ScaleRMax, Fm_ScaleCMin, Fm_ScaleCMax, Fm_MinScore, Fm_NumMatches, Fm_MaxOverlap,
                                                                 Fm_SubPixel, NumLevel, Fm_Greediness,
                                                                  out hv_Row, out hv_Column, out hv_Angle,
                                                                  out hv_ScaleR, out hv_ScaleC, out hv_Score);
                }
                else//整张图片区域搜索模板
                {
                    HObject image;
                    image = (HObject)ho_Image[ImageName];
                    HOperatorSet.FindAnisoShapeModel(image, hv_ModelID, Fm_AngleStart.TupleRad(), Fm_AngleExtent.TupleRad(),
                                                               Fm_ScaleRMin, Fm_ScaleRMax, Fm_ScaleCMin, Fm_ScaleCMax, Fm_MinScore, Fm_NumMatches, Fm_MaxOverlap,
                                                                 Fm_SubPixel, NumLevel, Fm_Greediness,
                                                                  out hv_Row, out hv_Column, out hv_Angle,
                                                                  out hv_ScaleR, out hv_ScaleC, out hv_Score);
                }
               
                ResultLogic = true;//合格
                if (IsSocre)   //分数
                {
                    for (int i = 0; i < hv_Score.Length; i++)
                    {
                        if (LowScore > hv_Score.TupleSelect(i) || hv_Score.TupleSelect(i) > HigScore)
                            ResultLogic = false;//不合格 
                    }
                }
                if (IsNums)  //数量
                {
                    if (LowNums > hv_Score.Length || hv_Score.Length > HigNums)
                        ResultLogic = false;//不合格
                }
            }
            catch (HalconException ex)
            {
                HTuple hv_Exception;
                ex.ToHTuple(out  hv_Exception);
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "{" + hv_Exception + "}", CoordSystem.window.ToString(), 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
            }
        }
        public override long set_after()
        {
            if (hv_ModelID == null)//是否模板句柄为空
            {
                return 0;
            }
            Stopwatch watch = new Stopwatch();
            watch.Start();
            HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DispObj((HObject)Image[ImageName], hWindowControl1.HalconWindow);
            HSystem.SetSystem("flush_graphic", "false");
            run();
            dispresult();
            watch.Stop();
            timer = watch.ElapsedMilliseconds;
            return watch.ElapsedMilliseconds;
        }
        /// <summary>
        /// blob获取图形模板
        /// </summary>
        /// <param name="ho_Image">输入图片</param>
        /// <param name="ho_ROI_0">感兴趣区域</param>
        /// <param name="ho_ImageModel">模板输出</param>
        /// <param name="hv_threshold_low">低阀值</param>
        /// <param name="hv_threshold_higt">高阀值</param>
        /// <param name="hv_SelectedRegionMin">最小面积</param>
        /// <param name="hv_SelectedRegionMax">最大面积</param>
        void get_modelimage(HObject ho_Image, HObject ho_ROI_0, out HObject ho_ImageModel,
        HTuple hv_threshold_low, HTuple hv_threshold_higt, HTuple hv_SelectedRegionMin,
        HTuple hv_SelectedRegionMax)
        {
            // Local iconic variables 
            HObject ho_ImageReduced, ho_Regions, ho_FillUp;
            HObject ho_ConnectedRegions, ho_RegionOpening, ho_SelectedRegions;
            HObject ho_Contours;
            // Local copy input parameter variables 
            HObject ho_Image_COPY_INP_TMP;
            ho_Image_COPY_INP_TMP = ho_Image.CopyObj(1, -1);
            // Local control variables 
            HTuple hv_Area = null, hv_Row = null, hv_Column = null;
            HTuple hv_PointOrder = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ImageModel);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_Regions);
            HOperatorSet.GenEmptyObj(out ho_FillUp);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_RegionOpening);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_Contours);
            ho_ImageReduced.Dispose();
            HOperatorSet.ReduceDomain(ho_Image_COPY_INP_TMP, ho_ROI_0, out ho_ImageReduced
                );
            ho_Regions.Dispose();
            HOperatorSet.Threshold(ho_ImageReduced, out ho_Regions, hv_threshold_low, hv_threshold_higt);
            ho_FillUp.Dispose();
            HOperatorSet.FillUp(ho_Regions, out ho_FillUp);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_FillUp, out ho_ConnectedRegions);
            ho_RegionOpening.Dispose();
            HOperatorSet.OpeningCircle(ho_ConnectedRegions, out ho_RegionOpening, 20);
            ho_SelectedRegions.Dispose();
            HOperatorSet.SelectShape(ho_RegionOpening, out ho_SelectedRegions, "area", "and",
                hv_SelectedRegionMin, hv_SelectedRegionMax);
            ho_Contours.Dispose();
            HOperatorSet.GenContourRegionXld(ho_SelectedRegions, out ho_Contours, "center");
            HOperatorSet.AreaCenterXld(ho_Contours, out hv_Area, out hv_Row, out hv_Column,
                out hv_PointOrder);
            ho_Image_COPY_INP_TMP.Dispose();
            HOperatorSet.GenImageConst(out ho_Image_COPY_INP_TMP, "byte", hv_Column * 2, hv_Row * 2);
            ho_ImageModel.Dispose();
            HOperatorSet.PaintXld(ho_Contours, ho_Image_COPY_INP_TMP, out ho_ImageModel,
                PaintGrayVal);
            ho_Image_COPY_INP_TMP.Dispose();
            ho_ImageReduced.Dispose();
            ho_Regions.Dispose();
            ho_FillUp.Dispose();
            ho_ConnectedRegions.Dispose();
            ho_RegionOpening.Dispose();
            ho_SelectedRegions.Dispose();
            ho_Contours.Dispose();
            return;
        }
        void XY(HTuple hv_WinHandle, HObject ho_image, HTuple hv_row, HTuple hv_col, HTuple hv_Phi)
        {
            HObject ho_Arrow, ho_Arrow1;
            HTuple hv_Phi1 = null;
            HOperatorSet.GenEmptyObj(out ho_Arrow);
            HOperatorSet.GenEmptyObj(out ho_Arrow1);
            hv_Phi1 = hv_Phi + ((new HTuple(180)).TupleRad());
            ho_Arrow.Dispose();
            HOperatorSet_Ex.gen_arrow_contour_xld(out ho_Arrow, hv_row + ((((hv_Phi1 + ((new HTuple(-90)).TupleRad()
                ))).TupleSin()) * 0), hv_col - ((((hv_Phi1 + ((new HTuple(90)).TupleRad()))).TupleCos()
                ) * 0), hv_row + ((((hv_Phi1 + ((new HTuple(-90)).TupleRad()))).TupleSin()) * hv_Height / 20),
                hv_col - ((((hv_Phi1 + ((new HTuple(-90)).TupleRad()))).TupleCos()) * hv_Height / 20), hv_Height / 60, hv_Height / 60);
            ho_Arrow1.Dispose();
            HOperatorSet_Ex.gen_arrow_contour_xld(out ho_Arrow1, hv_row + ((hv_Phi1.TupleSin()) * 0), hv_col - ((hv_Phi1.TupleCos()
                ) * 0), hv_row + ((hv_Phi1.TupleSin()) * hv_Height / 20), hv_col - ((hv_Phi1.TupleCos()) * hv_Height / 20), hv_Height / 60, hv_Height / 60);
            HOperatorSet.SetLineWidth(hv_WinHandle, 1);
            HOperatorSet.SetColor(hv_WinHandle, "red");
            HOperatorSet.DispObj(ho_Arrow, hv_WinHandle);
            HOperatorSet.DispObj(ho_Arrow1, hv_WinHandle);
            HOperatorSet_Ex.set_display_font(hv_WinHandle, 12, "mono", "false", "false");
            HOperatorSet_Ex.disp_message(hv_WinHandle, "Y", "image", (hv_row + ((((hv_Phi1 + ((new HTuple(-90)).TupleRad()
                ))).TupleSin()) * hv_Height / 20)) - 7, (hv_col - ((((hv_Phi1 + ((new HTuple(-90)).TupleRad()
                ))).TupleCos()) * hv_Height / 20)) + 7, "red", "false");
            HOperatorSet_Ex.disp_message(hv_WinHandle, "X", "image", (hv_row + ((hv_Phi1.TupleSin()
                 ) * 50)) + 10, (hv_col - ((hv_Phi1.TupleCos()) * hv_Height / 20)) - 10, "red", "false");
            //HOperatorSet_Ex.disp_message(hv_WinHandle, "坐标", "image", hv_row + ((hv_Phi1.TupleSin()
            //     ) * 0), hv_col - ((hv_Phi1.TupleCos()) * 0), "red", "false");
            ho_Arrow.Dispose();
            ho_Arrow1.Dispose();
            return;
        }
        /// <summary>
        /// 获取模板轮廓
        /// </summary>
        /// <param name="ho_ContoursTrans">输出模板轮廓</param>
        /// <param name="hv_Row"></param>
        /// <param name="hv_Column"></param>
        /// <param name="hv_Angle"></param>
        /// <param name="hv_ScaleR"></param>
        /// <param name="hv_ScaleC"></param>
        /// <param name="hv_ModelID"></param>
        void get_shape_model_contour(out HObject ho_ContoursTrans, HTuple hv_Row,
       HTuple hv_Column, HTuple hv_Angle, HTuple hv_ScaleR, HTuple hv_ScaleC, HTuple hv_ModelID)
        {
            // Local iconic variables 
            HObject ho_ModelContours;
            // Local control variables 
            HTuple hv_HomMat2D = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ContoursTrans);
            HOperatorSet.GenEmptyObj(out ho_ModelContours);
            HOperatorSet.HomMat2dIdentity(out hv_HomMat2D);
            HOperatorSet.HomMat2dScale(hv_HomMat2D, hv_ScaleR, hv_ScaleC, 0, 0, out hv_HomMat2D);
            HOperatorSet.HomMat2dRotate(hv_HomMat2D, hv_Angle, 0, 0, out hv_HomMat2D);
            HOperatorSet.HomMat2dTranslate(hv_HomMat2D, hv_Row, hv_Column, out hv_HomMat2D);
            ho_ModelContours.Dispose();
            HOperatorSet.GetShapeModelContours(out ho_ModelContours, hv_ModelID, 1);
            ho_ContoursTrans.Dispose();
            HOperatorSet.AffineTransContourXld(ho_ModelContours, out ho_ContoursTrans, hv_HomMat2D);
            ho_ModelContours.Dispose();
            return;
        }
        void get_shape_model_param(HTuple hv_ModelID, out HTuple hv_NumLevels)
        {
            // Local control variables 
            HTuple hv_AngleStart = null, hv_AngleExtent = null;
            HTuple hv_AngleStep = null, hv_ScaleMin = null, hv_ScaleMax = null;
            HTuple hv_ScaleStep = null, hv_Metric = null, hv_MinContrast = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GetShapeModelParams(hv_ModelID, out hv_NumLevels, out hv_AngleStart,
                out hv_AngleExtent, out hv_AngleStep, out hv_ScaleMin, out hv_ScaleMax, out hv_ScaleStep,
                out hv_Metric, out hv_MinContrast);
            return;
        }
        public override bool toolResult()
        {
            return ResultLogic;
        }
    }
}
