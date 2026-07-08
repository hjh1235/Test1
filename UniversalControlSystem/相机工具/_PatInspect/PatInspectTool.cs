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
    public class PatInspectTool : ImageTool
    {
        [NonSerialized]
       
        HTuple hv_Area = null, hv_Row = null, hv_Column = null;
        [NonSerialized]
        HObject ho_ROI_0, ho_ImageReduced, ho_ImageAffinTrans, ho_SelectedRegions, ho_Edges;
        [NonSerialized]
        // Local iconic variables 
        HObject ho_RegionForegroundImage, ho_RegionBackgroundImage;
        // Local control variables 
        HTuple hv_BackgroundGValMode, hv_ForegroundGValMode;
        [NonSerialized]
        HTuple hv_NDefects;
        [NonSerialized]
        bool logic1, logic2;
        public HTuple BackgroundGValMode
        {
            get { return hv_BackgroundGValMode; }
            set { hv_BackgroundGValMode = value; }
        }
        public HTuple ForegroundGValMode
        {
            get { return hv_ForegroundGValMode; }
            set { hv_ForegroundGValMode = value; }
        }
       [NonSerialized]
        List<bool> resultLogic = new List<bool>();
        public HObject ROI
        {
            get { return ho_ROI_0; }
            set { ho_ROI_0 = value; }
        }

        List<HTuple> phi = new List<HTuple>();
        public List<HTuple> Phi
        {
            get { return phi; }
            set { phi = value; }
        }
        [NonSerialized]
        List<HTuple> hv_HomMat2D = new List<HTuple>();
        public List<HTuple> HomMat2D
        {
            get { return hv_HomMat2D; }
            set { hv_HomMat2D = value; }
        }
        [NonSerialized]
        List<HTuple> hv_HomMat2D1 = new List<HTuple>();
        public List<HTuple> HomMat2D1
        {
            get { return hv_HomMat2D1; }
            set { hv_HomMat2D1 = value; }
        }

        [NonSerialized]
         Dictionary<string, List<HTuple>>dicHomMat2D = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> DicHomMat2D
        {
            get { return dicHomMat2D; }
            set { dicHomMat2D = value; }
        }

         Dictionary<string, List<HTuple>> dicHomMat2D1 = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> DicHomMat2D1
        {
            get { return dicHomMat2D1; }
            set { dicHomMat2D1 = value; }
        }
        [NonSerialized]
         Dictionary<string, List<HTuple>> dicPhi = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> DicPhi
        {
            get { return dicPhi; }
            set { dicPhi = value; }
        }

        #region 输出结果
        /// <summary>
        /// 输出结果
        /// </summary>
        ///  [NonSerialized]
           public bool ResultLogic { get; set; }
         public HTuple ResultArea
        {
            get { return hv_Area; }
            set { hv_Area = value; }
        }
        public HTuple ResultRow
        {
            get { return hv_Row; }
            set { hv_Row = value; }
        }
        public HTuple ResultCol
        {
            get { return hv_Column; }
            set { hv_Column = value; }
        }

        #endregion
        #region 输出结果判定
        public HTuple LowAera
        { get; set; }
        public HTuple HigAera
        { get; set; }

        public bool IsAera
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
        public string FixNames { get; set; }


        /// <summary>
        /// 使用位置定位
        /// </summary>
        public bool IsFixture { get; set; }

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
        public bool IsModeXld { get; set; }//
  
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
        HTuple hv_varModelID = null;
        public HTuple ModelID
        {
            get { return hv_varModelID; }
            set { hv_varModelID = value; }
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
        #endregion
        #region 差异模板参数
        public HTuple SelectedRegionMin { get; set; }//最小差异区域
        public HTuple SelectedRegionMax { get; set; }//最大差异区域
        public HTuple CompareMode { get; set; }//差异比较模式
        public HTuple Scale { get; set; }//轮廓缩放比例
        public HTuple Dilation { get; set; }//形态区域膨胀
        public HTuple AbsThreshold { get; set; }//差异绝对阀值
        public HTuple VarThreshold { get; set; }//差异阀值
        public bool IsSelectedRegions
        { get; set; }
        /// <summary>
        /// 斑点
        /// </summary>
        public bool IsCross
        { get; set; }
        /// <summary>
        /// 区域最小方向矩形显示
        /// </summary>
        public bool IsRectangle
        { get; set; }

        public bool IsIllumination { get; set; }

        /// <summary>
        /// 亚像素
        /// </summary>
        public bool IsEdgeMod { get; set; }
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
        public override void recon()
        {
            hv_HomMat2D = new List<HTuple>();
            hv_HomMat2D1 = new List<HTuple>();
            phi = new List<HTuple>();
            this.resultLogic = new List<bool>();
            try
            {
                if (ModelPath != null)
                {
                    int Debug = ModelPath.LastIndexOf("Debug");//是否是debug下的文件
                    if (Debug != -1)
                    {
                        string bugPath = ModelPath.Substring(Debug + 5, ModelPath.Length - (Debug + 5));//截取Debug下的文件,例如 原路径 C://Debug//1
                        string NewImagePath = Application.StartupPath + bugPath;//复制到不同的文件夹,复制到D盘,替换新的路径,例如 d://Debug//1
                        ModelPath = NewImagePath;
                        if (hv_varModelID == null)
                            HOperatorSet.ReadVariationModel(ModelPath, out hv_varModelID);//读取模板
                    }
                    else
                    {
                        if (hv_varModelID == null)
                            HOperatorSet.ReadVariationModel(ModelPath, out hv_varModelID);//读取模板
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
                   //HOperatorSet.ReadRegion(out ho_ROI_0, RoiPath);//读取ROI
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
        /// <param name="varModelID"></param>
        public void ClearVariationModel(ref HTuple varModelID)
        {
            try
            {
                if (varModelID != null)
                {
                    HOperatorSet.ClearVariationModel(varModelID);
                    varModelID = null;
                }
            }
            catch
            {
                varModelID = null;
            }
        }
        /// <summary>
        ///  读取模板
        /// </summary>
        /// <param name="ModelPath"></param>
        /// <param name="varModelID"></param>
        public void ReadVarModel(string ModelPath, ref HTuple varModelID)
        {
            if (ModelPath != null)
            {
                if (varModelID == null)
                    HOperatorSet.ReadVariationModel(ModelPath, out varModelID);//读取模板
            }
        }
        public void ReadVarModel()
        {
            ReadVarModel(ModelPath, ref hv_varModelID);
        }
        public void ReadModel()
        {
            OpenFileDialog OpenMode = new OpenFileDialog();
            OpenMode.Filter = "模板数据(*.vam)|*.vam";
            OpenMode.FileName = ModelPath;
            if (OpenMode.ShowDialog() == DialogResult.OK)
            {
                ModelPath = OpenMode.FileName;
                ClearVariationModel(ref hv_varModelID);
                ReadVarModel(ModelPath, ref  hv_varModelID);//读取模板
            }
        }
        public void SaveModel()
        {
            SaveFileDialog SaveMode = new SaveFileDialog();
            SaveMode.Filter = "模板数据(*.vam)|*.vam";
            SaveMode.FileName = ModelPath;
            if (SaveMode.ShowDialog() == DialogResult.OK)
            {
                ModelPath = SaveMode.FileName;
                switch (SaveMode.FilterIndex)
                {
                    case 1:
                        if (!Directory.Exists(Application.StartupPath + @"\VarModel\"))
                        {
                            Directory.CreateDirectory(Application.StartupPath + @"\VarModel\");
                            HOperatorSet.WriteVariationModel(hv_varModelID, ModelPath);
                        }
                        else
                        {
                          HOperatorSet.WriteVariationModel(hv_varModelID, ModelPath);
                        }
                        break;
                }
            }
            SaveMode.Dispose();
            MesBox("模板数据保存成功");
        }
        public override void ini()
        {
            Names = Tool.差异比较检测.ToString();
            ImageName = "采集图片0";
            FixNames = Tool.位置定位.ToString();

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

            SelectedRegionMin = 10;
            SelectedRegionMax = 9999;
            CompareMode = "absolute";
            Scale = 2;
            Dilation = 3;
            AbsThreshold = 15;
            VarThreshold = 2;

            Setdraw = Set_draw.margin.ToString();//区域轮廓显示
            SetdrawShape = Roi.矩形.ToString(); ;//ROI形状
            IsCross = false;
            IsRectangle = true;
            IsAera = false;
            IsModeXld = true;
        }
        public override void draw_roi()
        {
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "绘制ROI,右键确定！", CoordSystem.window.ToString(), 10, 10, ColorFul.black.ToString(), ColorFul.white.ToString());
            HSystem.SetSystem("flush_graphic", "false");
            draw_roi(hWindowControl1.HalconWindow, ho_Image, ImageName, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2, out hv_circle, out hv_rectangle1, out hv_rectangle2);
            gen_roi();
            HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DispObj((HObject)ho_Image[ImageName], hWindowControl1.HalconWindow);
            HOperatorSet.DispObj(ho_ROI_0, hWindowControl1.HalconWindow);//显示绘制区域
            HSystem.SetSystem("flush_graphic", "false");
            //set_after(); 
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
        void gen_roi()
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
        HObject RegionAffineTrans;
        private void toolRun()
        {
            ResultLogic = true;
            resultLogic.Clear();
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.GenEmptyObj(out RegionAffineTrans);
            RegionAffineTrans.Dispose();
            try
            {
                if (ho_ROI_0 == null)
                HOperatorSet.ReadRegion(out ho_ROI_0, RoiPath);//读取ROI
                if (IsFixture) //使用位置定位
                {   //
                    HomMat2D = dicHomMat2D[FixNames];  //  选择位置定位
                    HomMat2D1 = dicHomMat2D1[FixNames];  //  选择位置定位
                    Phi = DicPhi[FixNames]; //  选择位置定位
                    //遍历定位>
                    for (int i = 0; i < HomMat2D1.Count; i++)
                    {
                        //HOperatorSet.ReduceDomain((HObject)ho_Image[ImageName], ho_ROI_0, out ho_ImageReduced);
                        CompareVariationModel(ho_Image[ImageName], ho_ROI_0, out ho_ImageAffinTrans,
                                               out ho_SelectedRegions, HomMat2D1[i],HomMat2D[i], hv_varModelID, CompareMode, SelectedRegionMin, SelectedRegionMax,out hv_Area,out hv_Row,out hv_Column);
                        displayDiff(ho_SelectedRegions, (HObject)ho_Image[ImageName], ho_ImageAffinTrans, 1, HomMat2D[i]);
                        HOperatorSet.AffineTransRegion(ho_ROI_0, out RegionAffineTrans, HomMat2D[i], "nearest_neighbor");
                        //logic1 = true;
                        //if (IsAera) //使用面积管控
                        //{
                        //    if (LowAera > hv_Area || hv_Area > HigAera)
                        //        logic1 = false;
                        //    resultLogic.Add(logic1);
                        //}
                        //logic2 = true;
                        //if (IsNums)//使用数量管控
                        //{
                        //   if (LowNums > hv_Area.Length || hv_Area.Length > HigNums)
                        //        logic2 = false;
                        //    resultLogic.Add(logic2);
                        //}
                        if (hv_Area.Length < 1) 
                        {
                            HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.green.ToString());
                            resultLogic.Add(true);
                        }
                        else //da
                        {
                            HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.red.ToString());
                            resultLogic.Add(false);
                        }
                        HOperatorSet.DispObj(RegionAffineTrans, hWindowControl1.HalconWindow);
                        HSystem.SetSystem("flush_graphic", "false");
                    }
                    foreach (bool item in resultLogic)
                    {
                        if (!item)
                            ResultLogic = false;
                    }
                }
                    
                else
                {
                    HOperatorSet.DispObj(ho_ROI_0, hWindowControl1.HalconWindow);
                    HSystem.SetSystem("flush_graphic", "false");
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
        public override void dispresult()
        {
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet.DispObj(RegionAffineTrans, hWindowControl1.HalconWindow);
            HSystem.SetSystem("flush_graphic", "false");
        }
        public override long set_after()
        {
            try
            {   Stopwatch watch = new Stopwatch();
                watch.Start();
                HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.DispObj((HObject)ho_Image[ImageName], hWindowControl1.HalconWindow);
               
                HSystem.SetSystem("flush_graphic", "false");
                run();
                dispresult();
                watch.Stop();
                timer = watch.ElapsedMilliseconds;
                return watch.ElapsedMilliseconds;
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
                timer = 0;
                return 0;
            }
        }
        public void CreateVariationModel()
        {
            HSystem.SetSystem("flush_graphic", "true");
            HObject ho_ImageReduced;
            HObject ho_VarImage;
            HObject ho_Edges;
            get_grayval_range(ho_Image[ImageName], ho_ROI_0, out ho_RegionForegroundImage, out ho_RegionBackgroundImage, out hv_BackgroundGValMode, out hv_ForegroundGValMode);

            HOperatorSet.ReduceDomain((HObject)ho_Image[ImageName], ho_ROI_0, out ho_ImageReduced);
            CreateVariationModel((HObject)ho_Image[ImageName], ho_ImageReduced, out  ho_VarImage, out ho_Edges, Scale, Dilation, AbsThreshold, VarThreshold, out hv_varModelID);
            HSystem.SetSystem("flush_graphic", "false");
        }
       void CreateVariationModel(HObject ho_Image, HObject ho_ImageReduced, out HObject ho_VarImage,
       out HObject ho_Edges, HTuple hv_scale, HTuple hv_dilation, HTuple hv_absThreshold,
       HTuple hv_varThreshold, out HTuple hv_VarModelID)
        {
            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            // Local iconic variables 
            HObject ho_ZoomedEdges, ho_VarImageBig, ho_ObjectSelected = null;
            HObject ho_Region1 = null, ho_RegionDilation = null, ho_VarImageSmall;

            // Local control variables 

            HTuple hv_Width = null, hv_Height = null, hv_HomMat2DIdentity = null;
            HTuple hv_HomMat2DScale = null, hv_NEdges = null, hv_i = null;
            HTuple hv_RowEdge = new HTuple(), hv_ColEdge = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_VarImage);
            HOperatorSet.GenEmptyObj(out ho_Edges);
            HOperatorSet.GenEmptyObj(out ho_ZoomedEdges);
            HOperatorSet.GenEmptyObj(out ho_VarImageBig);
            HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
            HOperatorSet.GenEmptyObj(out ho_Region1);
            HOperatorSet.GenEmptyObj(out ho_RegionDilation);
            HOperatorSet.GenEmptyObj(out ho_VarImageSmall);
            ///亚像素分割图片
            HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            if (IsEdgeMod)
            {
                #region 亚像素图片创建VarImage
                ho_Edges.Dispose();
                HOperatorSet.EdgesSubPix(ho_ImageReduced, out ho_Edges, "sobel_fast", 0.5, 10,
                    20);
                HOperatorSet.HomMat2dIdentity(out hv_HomMat2DIdentity);
                HOperatorSet.HomMat2dScale(hv_HomMat2DIdentity, hv_scale, hv_scale, 0, 0, out hv_HomMat2DScale);
                ho_ZoomedEdges.Dispose();
                HOperatorSet.AffineTransContourXld(ho_Edges, out ho_ZoomedEdges, hv_HomMat2DScale);
                ///产生空白图片
                ho_VarImageBig.Dispose();
                HOperatorSet.GenImageConst(out ho_VarImageBig, "byte", hv_scale * hv_Width, hv_scale * hv_Height);
                HOperatorSet.CountObj(ho_ZoomedEdges, out hv_NEdges);
                HTuple end_val9 = hv_NEdges;
                HTuple step_val9 = 1;
               
                for (hv_i = 1; hv_i.Continue(end_val9, step_val9); hv_i = hv_i.TupleAdd(step_val9))
                {
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "模型创建中>>", CoordSystem.window.ToString(), 10, 10, ColorFul.black.ToString(), ColorFul.white.ToString());
                    ho_ObjectSelected.Dispose();
                    HOperatorSet.SelectObj(ho_ZoomedEdges, out ho_ObjectSelected, hv_i);
                    ///获取XLD作标点
                    HOperatorSet.GetContourXld(ho_ObjectSelected, out hv_RowEdge, out hv_ColEdge);
                    ///生成多边形一个Region
                    ho_Region1.Dispose();
                    HOperatorSet.GenRegionPolygon(out ho_Region1, hv_RowEdge, hv_ColEdge);
                    ho_RegionDilation.Dispose();
                    HOperatorSet.DilationCircle(ho_Region1, out ho_RegionDilation, hv_dilation);
                    {
                        HObject ExpTmpOutVar_0;
                        HOperatorSet.PaintRegion(ho_RegionDilation, ho_VarImageBig, out ExpTmpOutVar_0,
                            255, "fill");

                        ho_VarImageBig.Dispose();
                        ho_VarImageBig = ExpTmpOutVar_0;
                    }
                    
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "模型创建中>>>>", CoordSystem.window.ToString(), 10, 10, ColorFul.black.ToString(), ColorFul.white.ToString());
                }
                ///图象缩放正常大小
                ho_VarImageSmall.Dispose();
                HOperatorSet.ZoomImageSize(ho_VarImageBig, out ho_VarImageSmall, hv_Width, hv_Height, "weighted");
                ///消除噪点
                ho_VarImage.Dispose();
                HOperatorSet.BinomialFilter(ho_VarImageSmall, out ho_VarImage, 3, 3);
                #endregion   
            }
            else
            {
               HOperatorSet.SobelAmp(ho_ImageReduced, out ho_VarImage, "sum_abs", 5);
            }
            HOperatorSet.DispObj(ho_VarImage, hWindowControl1.HalconWindow);
            ///创建一个变化模板
            HOperatorSet.CreateVariationModel(hv_Width, hv_Height, "byte", "direct", out hv_VarModelID);
            HOperatorSet.PrepareDirectVariationModel(ho_Image, ho_VarImage, hv_VarModelID,hv_absThreshold, hv_varThreshold);
            ho_ZoomedEdges.Dispose();
            ho_VarImageBig.Dispose();
            ho_ObjectSelected.Dispose();
            ho_Region1.Dispose();
            ho_RegionDilation.Dispose();
            ho_VarImageSmall.Dispose();
            watch.Stop();
            MesBox("模型创建成功! <耗时: " + watch.ElapsedMilliseconds.ToString() + " ms>");
            return;
        }
        void MesBox(string mes)
        {
            MessageBox.Show(mes);
        }
       void CompareVariationModel(HObject ho_Image, HObject ho_ROI,
                out HObject ho_ImageAffinTrans, out HObject ho_SelectedRegions, HTuple hv_HomMat2D1,HTuple hv_HomMat2D,
                HTuple hv_VarModelID, HTuple hv_compareMode, HTuple hv_SelectedMin, HTuple hv_SelectedMax,out HTuple ho_area,out HTuple hv_row, out HTuple hv_col)
        {


            // Local iconic variables 
            HObject ho_ImageReduced1,ho_ImageScale,ho_ImageScaleAffinTrans, ho_RegionDiff, ho_ConnectedRegions;
            HTuple  hv_Mult = new HTuple(),  hv_Add = new HTuple();
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ImageAffinTrans);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced1);
            HOperatorSet.GenEmptyObj(out ho_ImageScale);
            HOperatorSet.GenEmptyObj(out ho_ImageScaleAffinTrans);
            HOperatorSet.GenEmptyObj(out ho_RegionDiff);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            ho_ImageAffinTrans.Dispose();
            HOperatorSet.AffineTransImage(ho_Image, out ho_ImageAffinTrans, hv_HomMat2D1,"constant", "false");
            //剪切图片
            ho_ImageReduced1.Dispose();
            HOperatorSet.ReduceDomain(ho_ImageAffinTrans, ho_ROI, out ho_ImageReduced1);
           
            ho_ImageScale.Dispose();
            if (IsIllumination)//光照变化
            {
                get_grayval_range1(ho_ImageReduced1, ho_ROI, hv_ForegroundGValMode, hv_BackgroundGValMode, out hv_Mult, out hv_Add);
                HOperatorSet.ScaleImage(ho_ImageReduced1, out ho_ImageScale, hv_Mult, hv_Add);
                //HOperatorSet.DispObj(ho_ImageScale, hWindowControl1.HalconWindow);
                //开始比较
                ho_RegionDiff.Dispose();
                HOperatorSet.CompareExtVariationModel(ho_ImageScale, out ho_RegionDiff, hv_VarModelID, hv_compareMode);
            }
            else// 光照不变化
            {
                //开始比较
                ho_RegionDiff.Dispose();
                HOperatorSet.CompareExtVariationModel(ho_ImageReduced1, out ho_RegionDiff, hv_VarModelID, hv_compareMode);
            }
            //连通区域
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_RegionDiff, out ho_ConnectedRegions);
            //通过面积选择区域,忽略太小的点.
            ho_SelectedRegions.Dispose();
            HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, "area",
                "and", hv_SelectedMin, hv_SelectedMax);
            HOperatorSet.AreaCenter(ho_SelectedRegions, out ho_area, out hv_row, out hv_col);
            ho_ImageReduced1.Dispose();
            ho_RegionDiff.Dispose();
            ho_ConnectedRegions.Dispose();
            return;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ho_SelectedRegions"></param>
        /// <param name="Image"></param>
        /// <param name="ho_ImageAffinTrans"></param>
        /// <param name="hv_org"></param>
        /// <param name="hv_HomMat2D1"></param>
        void displayDiff(HObject ho_SelectedRegions, HObject Image, HObject ho_ImageAffinTrans, HTuple hv_org, HTuple hv_HomMat2D1)
        {
            //HOperatorSet.GenEmptyObj(out ho_Cross);

            HTuple hv_Width = null, hv_Height = null;

            HTuple hv_Row1 = null;
            HTuple hv_Column1 = null;
            HTuple hv_Phi = null;
            HTuple hv_Length1 = null;
            HTuple hv_Length2 = null;

            // Local iconic variables 
            HObject ho_Cross=null;

            HObject ho_RegionAffineTrans = null;

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_RegionAffineTrans);

            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "red");
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Setdraw);
            HOperatorSet.SetLineWidth(hWindowControl1.HalconWindow, 2);
          
            if ((int)(new HTuple(hv_org.TupleEqual(1))) != 0)
            {   //=1
                //把差异区域和轮廓仿射到当前图上
                ho_RegionAffineTrans.Dispose();
                HOperatorSet.AffineTransRegion(ho_SelectedRegions, out ho_RegionAffineTrans,
                    hv_HomMat2D1, "nearest_neighbor");
                HOperatorSet.SmallestRectangle2(ho_RegionAffineTrans, out hv_Row1, out hv_Column1,
                        out hv_Phi, out hv_Length1, out hv_Length2);
                HOperatorSet.GetImageSize(Image, out hv_Width, out hv_Height);
                if (IsSelectedRegions)
                {
                    HOperatorSet.DispObj(ho_RegionAffineTrans, hWindowControl1.HalconWindow); 
                }
                if (IsCross)
                {
                    if (hv_Row1.Length > 0)
                    {
                        ho_Cross.Dispose();
                        HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Row1, hv_Column1, hv_Height / 100, 0);
                        HOperatorSet.DispObj(ho_Cross, hWindowControl1.HalconWindow);
                    }
                }
                 if (IsRectangle)
                {
                       if (hv_Row1.Length > 0)
                        HOperatorSet.DispRectangle2(hWindowControl1.HalconWindow, hv_Row1, hv_Column1,
                             hv_Phi, hv_Length1, hv_Length2);
                }
            }
            else
            {   //=0
                HOperatorSet.DispObj(Image, hWindowControl1.HalconWindow);

                HOperatorSet.SmallestRectangle2(ho_SelectedRegions, out hv_Row1, out hv_Column1,
                       out hv_Phi, out hv_Length1, out hv_Length2);
                HOperatorSet.GetImageSize(Image, out hv_Width, out hv_Height);
                if (IsSelectedRegions)
                {
                    //把差异区域和轮廓显示校正图上
                    HOperatorSet.DispObj(ho_SelectedRegions, hWindowControl1.HalconWindow);
                }
                if (IsCross)
                {
                    if (hv_Row1.Length > 0)
                    {
                        ho_Cross.Dispose();
                        HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Row1, hv_Column1, hv_Height / 100, 0);
                        HOperatorSet.DispObj(ho_Cross, hWindowControl1.HalconWindow);
                    }
                }
                if (IsRectangle)
                {
                    if (hv_Row1.Length > 0)
                        HOperatorSet.DispRectangle2(hWindowControl1.HalconWindow, hv_Row1, hv_Column1,
                             hv_Phi, hv_Length1, hv_Length2);
                }
               
            }
            ho_Cross.Dispose();
            ho_RegionAffineTrans.Dispose();
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
            return;
        }

      public void get_grayval_range1(HObject ho_ImageAffinTrans, HObject ho_RegionROI,
      HTuple hv_ForegroundGVModel, HTuple hv_BackgroundGVModel, out HTuple hv_Mult,
      out HTuple hv_Add)
        {
            // Local iconic variables 
            HObject ho_RegionForegroundImage, ho_RegionBackgroundImage;
            // Local control variables 
            HTuple hv_BackgroundImage = null, hv_ForegroundImage = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_RegionForegroundImage);
            HOperatorSet.GenEmptyObj(out ho_RegionBackgroundImage);
            ho_RegionForegroundImage.Dispose(); ho_RegionBackgroundImage.Dispose();
            get_grayval_range(ho_ImageAffinTrans, ho_RegionROI, out ho_RegionForegroundImage,
                out ho_RegionBackgroundImage, out hv_BackgroundImage, out hv_ForegroundImage);
            //
            //Scale image to the model's gray value range
            hv_Mult = (hv_ForegroundGVModel - hv_BackgroundGVModel) / (hv_ForegroundImage - hv_BackgroundImage);
            hv_Add = hv_ForegroundGVModel - (hv_Mult * hv_ForegroundImage);
            ho_RegionForegroundImage.Dispose();
            ho_RegionBackgroundImage.Dispose();
            return;
        }

        public void get_grayval_range(HObject ho_Image, HObject ho_RegionROI, out HObject ho_RegionForeground,
        out HObject ho_RegionBackground, out HTuple hv_BackgroundGVal, out HTuple hv_ForegroundGVal)
        {
            // Local iconic variables 
            HObject ho_ImageReduced;
            // Local control variables 
            HTuple hv_UsedThreshold = null, hv_DeviationFG = null;
            HTuple hv_DeviationBG = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_RegionForeground);
            HOperatorSet.GenEmptyObj(out ho_RegionBackground);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            ho_ImageReduced.Dispose();
            HOperatorSet.ReduceDomain(ho_Image, ho_RegionROI, out ho_ImageReduced);
            ho_RegionBackground.Dispose();
            HOperatorSet.BinaryThreshold(ho_ImageReduced, out ho_RegionBackground, "max_separability",
                "dark", out hv_UsedThreshold);
            ho_RegionForeground.Dispose();
            HOperatorSet.Difference(ho_RegionROI, ho_RegionBackground, out ho_RegionForeground
                );
            HOperatorSet.Intensity(ho_RegionForeground, ho_Image, out hv_ForegroundGVal,
                out hv_DeviationFG);
            HOperatorSet.Intensity(ho_RegionBackground, ho_Image, out hv_BackgroundGVal,
                out hv_DeviationBG);
            ho_ImageReduced.Dispose();

            return;
        }
        public override bool toolResult()
        {
            return ResultLogic;
        }
    }

}
