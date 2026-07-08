using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using HOperatorSet_EX;
using System.IO;
namespace UniversalControlSystem
{
    [Serializable]
    public class BlobTool : ImageTool
    {
        // Local iconic variables 
        [NonSerialized]
        HObject ho_ROI_0, ho_AreaEmptyObject, ho_ResultObject;
        public HObject ROI
        {
            get { return ho_ROI_0; }
            set { ho_ROI_0 = value; }
        }
        [NonSerialized]
        HObject ho_Cross, ho_Rectangle;
        // Local control variables 
        [NonSerialized]
        HTuple hv_Width = null, hv_Height = null;
        [NonSerialized]
        HTuple hv_Area = null, hv_Row = null, hv_Column = null;
        [NonSerialized]
        HTuple hv_Row1 = null, hv_Column1 = null, hv_Phi = null, hv_Length1 = null, hv_Length2 = null;
        [NonSerialized]
        List<bool> resultLogic = new List<bool>();
        [NonSerialized]
        bool logic1, logic2;
        [NonSerialized]
        List<HTuple> phi = new List<HTuple>();

        [NonSerialized]
        List<HTuple> listRow = new List<HTuple>();
        [NonSerialized]
        List<HTuple> listColumn = new List<HTuple>();
        [NonSerialized]
        List<HObject> listResultObject = new List<HObject>();

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
         Dictionary<string, List<HTuple>> dicHomMat2D = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> DicHomMat2D
        {
            get { return dicHomMat2D; }
            set { dicHomMat2D = value; }
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
        public bool ResultLogic { get; set; }

        /// <summary>
        /// 区域输出 
        /// </summary>
        public HObject OutRegion
        {
            get { return ho_ResultObject; }
            set { ho_ResultObject = value; }
        }
        public HTuple ResultCol
        {
            get { return hv_Column; }
            set { hv_Column = value; }
        }

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
        /// 形态类型
        /// </summary>
        public string Morphology { get; set; }
        public HTuple Width { get; set; }
        public HTuple Height { get; set; }
        string imageName;
        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }
        string name;
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names
        {
            get { return name; }
            set { name = value; }
        }
        public string FixNames { get; set; }
        /// <summary>
        /// 使用位置定位
        /// </summary>
        public bool IsFixture { get; set; }
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
        /// 低阀值
        /// </summary>
        public HTuple LowThreshold
        { get; set; }
        /// <summary>
        /// 最大面积
        /// </summary>
        public HTuple HigThreshold
        { get; set; }
        /// <summary>
        /// 最大面积
        /// </summary>
        public HTuple SelectShapeMinAra
        { get; set; }

        /// <summary>
        /// 最小面积
        /// </summary>
        public HTuple SelectShapeMaxAra
        { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public HTuple SelectShapeMincircularity
        { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public HTuple SelectShapeMaxcircularity
        { get; set; }
        /// <summary>
        /// ROI路径
        /// </summary>
        public string RoiPath { get; set; }
        public string RegionType { get; set; }

        /// <summary>
        /// 使用限定区域
        /// </summary>
        public bool IsRoi { get; set; }
        /// <summary>
        /// 轮廓显示
        /// </summary>
        public string Setdraw
        { get; set; }
        /// <summary>
        ///ROI形状
        /// </summary>
        public string SetdrawShape
        { get; set; }
        /// <summary>
        /// 连通区域
        /// </summary>
        public bool IsSelect_conn
        { get; set; }
        /// <summary>
        /// 区域显示
        /// </summary>
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
        #endregion
        public override string toolName()
        {
            return name;
        }
        public override long toolTimer()
        {
            return timer;
        }
        public override void recon()
        {
            hv_HomMat2D = new List<HTuple>();
            this.resultLogic = new List<bool>();
            listRow = new List<HTuple>();
            listColumn = new List<HTuple>();
            listResultObject = new List<HObject>();
            if(!IsRoi)
            { return; }
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
            }
            catch
            {
                MessageBox.Show("读取ROI失败!");
            }
        }
        public override void ini()
        {
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ROI_0);
            HOperatorSet.GenEmptyObj(out ho_AreaEmptyObject);
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            Names = Tool.斑点分析.ToString();
            ImageName = "采集图像0";
            FixNames = Tool.位置定位.ToString();
            IsFixture = false;
            IsRoi = false;
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

            LowThreshold = 1;//低阀值
            HigThreshold = 150;//高阀值
            SelectShapeMinAra = 1;//最小面积
            SelectShapeMaxAra = 99999;//最大面积
            SelectShapeMincircularity = 0;
            SelectShapeMaxcircularity = 1;

            Setdraw = Set_draw.margin.ToString();//轮廓显示
            SetdrawShape = Roi.矩形.ToString(); ;//ROI形状
            IsSelect_conn = true;//连通区域
            IsSelectedRegions = false;//blob区域显示
            IsCross = true;//斑点显示
            IsRectangle = false;//区域最小方向矩形显示

            LowAera = 100;
            HigAera = 999999;
            LowNums = 1;
            HigNums = 999;
            IsAera = false;
            IsNums = false;
            Morphology = "无";

        }
        public override void draw_roi()
        {
            HOperatorSet.SetColor(HW.Instance().HalconWindow, "green");
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "绘制ROI,右键确定！", CoordSystem.window.ToString(), 10, 10, ColorFul.black.ToString(), ColorFul.white.ToString());
            HSystem.SetSystem("flush_graphic", "false");
            draw_roi(HW.Instance().HalconWindow, ho_Image, ImageName, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2, out hv_circle, out hv_rectangle1, out hv_rectangle2);
            gen_roi();
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
        void gen_roi()
        {
            HObject ho_EmptyRegion;
            HOperatorSet.GenEmptyObj(out ho_EmptyRegion);
            ho_EmptyRegion.Dispose();
            gen_roi(out ho_EmptyRegion, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2);
            if (ho_ROI_0 == null)//第一次绘制
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
                //HOperatorSet.ClearObj(ho_ROI_0);
                //ho_ROI_0 = null;
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
            HObject ho_ObjectSelected = null;
            HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
            try
            {
                if (ho_Cross != null)
                {
                    ho_Cross.Dispose();
                }
                if (ho_Rectangle != null)
                {
                    ho_Rectangle.Dispose();
                }

                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.SetDraw(HW.Instance().HalconWindow, Set_draw.margin.ToString());
                //HOperatorSet.DispObj(ho_ROI_0, WindowControl.HalconWindow);
                HSystem.SetSystem("flush_graphic", "false");

                for (int i = 0; i < resultLogic.Count; i++)    //遍历定位>测量图形
                {
                    if (resultLogic[i])
                        HOperatorSet.SetColor(HW.Instance().HalconWindow, ColorFul.green.ToString());
                    else
                        HOperatorSet.SetColor(HW.Instance().HalconWindow, ColorFul.red.ToString());

                 
                    ho_ObjectSelected.Dispose();
                    int count = ho_ResultObject.CountObj();
                    for (int j = 0; j < count; j++)
                    {
                        HSystem.SetSystem("flush_graphic", "true");
                        HOperatorSet.SelectObj(ho_ResultObject, out ho_ObjectSelected, j + 1);
                        this.dispresult(ho_ObjectSelected, out ho_Cross, out ho_Rectangle, Setdraw, listRow[i], listColumn[i],
                        IsSelectedRegions, IsCross, IsRectangle, hv_Height, out hv_Row1,
                        out hv_Column1, out hv_Phi, out hv_Length1, out hv_Length2);
                        ho_ObjectSelected.Dispose();
                        HSystem.SetSystem("flush_graphic", "false");
                    }
                
                }
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "图形显示异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//不合格
                HSystem.SetSystem("flush_graphic", "false");
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
            HObject ho_Img;

            HObject RegionAffineTrans;
            HOperatorSet.GenEmptyObj(out RegionAffineTrans);
            HOperatorSet.SetDraw(HW.Instance().HalconWindow, Set_draw.margin.ToString());
            listRow.Clear();
            listColumn.Clear();
            listResultObject.Clear();
            try
            {
                ResultLogic = true;//合格
                resultLogic.Clear();
                if (ho_ResultObject != null)
                    ho_ResultObject.Dispose();
                HOperatorSet.GenEmptyObj(out ho_ResultObject);
                HOperatorSet.GetImageSize((HObject)ho_Image[imageName], out hv_Width, out hv_Height);
                if (IsFixture) //使用位置定位
                {
                    //
                    HomMat2D = (List<HTuple>)dicHomMat2D[FixNames];  //  选择位置定位
                    Phi = (List<HTuple>)DicPhi[FixNames]; //  选择位置定位
                    //遍历定位>
                    for (int i = 0; i < HomMat2D.Count; i++)
                    {
                        if (ho_AreaEmptyObject != null)
                            ho_AreaEmptyObject.Dispose();
                        if (RegionAffineTrans != null)
                            RegionAffineTrans.Dispose();

                        if (IsRoi)
                        {
                            HOperatorSet.AffineTransRegion(ho_ROI_0, out RegionAffineTrans, HomMat2D[i], "nearest_neighbor");
                            ho_Img = RegionAffineTrans;
                        }
                        else
                        {
                            ho_Img = (HObject)ho_Image[ImageName];
                        }
                        Blob((HObject)ho_Image[imageName], ho_Img, out ho_AreaEmptyObject, LowThreshold, HigThreshold,
                        SelectShapeMinAra, SelectShapeMaxAra,SelectShapeMincircularity, SelectShapeMaxcircularity, IsSelect_conn, out hv_Area, out hv_Row, out hv_Column);

                        ho_ResultObject = ho_ResultObject.ConcatObj(ho_AreaEmptyObject);
                        listResultObject.Add(ho_AreaEmptyObject);
                        ho_AreaEmptyObject.Dispose();
                        listRow.Add(hv_Row);
                        listColumn.Add(hv_Column);
                        logic1 = true;
                        if (IsAera) //使用面积管控
                        {
                            if (LowAera > hv_Area || hv_Area > HigAera)
                                logic1 = false;
                            //resultLogic.Add(logic1);
                        }
                        logic2 = true;
                        if (IsNums)//使用数量管控
                        {
                            if (LowNums > hv_Area.Length || hv_Area.Length > HigNums)
                                logic2 = false;
                            //resultLogic.Add(logic2);
                        }
                        if (!logic1 || !logic2)
                            resultLogic.Add(false);
                        else
                            resultLogic.Add(true);
                    }
                    foreach (bool item in resultLogic)
                    {
                        if (!item)
                            ResultLogic = false;
                    }
                }
                else
                {
                    if (ho_AreaEmptyObject != null)
                        ho_AreaEmptyObject.Dispose();

                    if (IsRoi)
                    {
                       ho_Img = ho_ROI_0;
                    }
                    else
                    {
                        ho_Img = (HObject)ho_Image[ImageName];
                    }
                    Blob((HObject)ho_Image[imageName], ho_Img, out ho_AreaEmptyObject, LowThreshold, HigThreshold,
                    SelectShapeMinAra, SelectShapeMaxAra,SelectShapeMincircularity, SelectShapeMaxcircularity, IsSelect_conn, out hv_Area, out hv_Row, out hv_Column);

                    ho_ResultObject = ho_ResultObject.ConcatObj(ho_AreaEmptyObject);

                    listRow.Add(hv_Row);
                    listColumn.Add(hv_Column);

                    HSystem.SetSystem("flush_graphic", "true");
                    HOperatorSet.SetColored(HW.Instance().HalconWindow, 12);
                    if (hv_Area.Length == 1)
                        HOperatorSet.SetColor(HW.Instance().HalconWindow, ColorFul.green.ToString());
                    if (IsRoi)
                        HOperatorSet.DispObj(ho_ROI_0, HW.Instance().HalconWindow);
                    HSystem.SetSystem("flush_graphic", "false");
                    logic1 = true;
                    if (IsAera) //使用面积管控
                    {
                        for (int i = 0; i < hv_Area.Length; i++)
                        {
                            if (LowAera > hv_Area[i] || hv_Area[i] > HigAera)
                            {
                                logic1 = false;
                            }
                        }
                     
                        //resultLogic.Add(logic1);
                    }
                    logic2 = true;
                    if (IsNums)//使用数量管控
                    {
                        if (LowNums > hv_Area.Length || hv_Area.Length > HigNums)
                            logic2 = false;
                        //resultLogic.Add(logic2);
                    }
                    if (!logic1 || !logic2)
                        resultLogic.Add(false);
                    else
                        resultLogic.Add(true);
                    foreach (bool item in resultLogic)
                    {
                        if (!item)
                            ResultLogic = false;
                    }
                }
            }
            catch (HalconException ex)
            {
                HSystem.SetSystem("flush_graphic", "true");
                HTuple hv_Exception;
                ex.ToHTuple(out hv_Exception);
                HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "{" + hv_Exception + "}", CoordSystem.window.ToString(), 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
            }
         
        }
        public override long set_after()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                HOperatorSet.ClearWindow(HW.Instance().HalconWindow);
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.DispObj((HObject)ho_Image[imageName], HW.Instance().HalconWindow);
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
                HOperatorSet_Ex.disp_message(HW.Instance().HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
                return 0;
            }
        }
        public override bool toolResult()
        {
            return ResultLogic;
        }
        void dispresult(HObject ho_AreaEmptyObject, out HObject ho_Cross, out HObject ho_Rectangle,
               string drwaSet, HTuple hv_Row, HTuple hv_Column, bool isSelectedRegions,
              bool IsCross, bool IsRectangle, HTuple hv_Height, out HTuple hv_Row1,
               out HTuple hv_Column1, out HTuple hv_Phi, out HTuple hv_Length1, out HTuple hv_Length2)
        {
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Cross);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            hv_Row1 = new HTuple();
            hv_Column1 = new HTuple();
            hv_Phi = new HTuple();
            hv_Length1 = new HTuple();
            hv_Length2 = new HTuple();
            //if (ResultLogic)//
            //{
            //    //HOperatorSet.SetColored(WindowControl.HalconWindow, 12);
            //    //if (hv_Area.Length == 1)
            //    //    HOperatorSet.SetColor(WindowControl.HalconWindow, ColorFul.green.ToString());
            //}
            //else
            //{
            //    /*HOperatorSet.SetColor(WindowControl.HalconWindow, ColorFul.red.ToString());*/
            //}
            HSystem.SetSystem("flush_graphic", "true");
            if ((int)(new HTuple((new HTuple(hv_Row.TupleLength())).TupleGreater(0))) != 0)
            {
                if (IsCross)
                {
                    ho_Cross.Dispose();
                    HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Row, hv_Column, hv_Height / 100, 0);
                    HOperatorSet.DispObj(ho_Cross, HW.Instance().HalconWindow);
                }
                if (IsRectangle)
                {
                    HOperatorSet.SetDraw(HW.Instance().HalconWindow, Set_draw.margin.ToString());
                    HOperatorSet.SmallestRectangle2(ho_AreaEmptyObject, out hv_Row1, out hv_Column1,
                                 out hv_Phi, out hv_Length1, out hv_Length2);
                    ho_Rectangle.Dispose();
                    HOperatorSet.GenRectangle2ContourXld(out ho_Rectangle, hv_Row1, hv_Column1,
                        hv_Phi, hv_Length1, hv_Length2);
                    HOperatorSet.DispObj(ho_Rectangle, HW.Instance().HalconWindow);
                }
                if (isSelectedRegions)
                {
                    HOperatorSet.SetDraw(HW.Instance().HalconWindow, Setdraw);
                    HOperatorSet.DispObj(ho_AreaEmptyObject, HW.Instance().HalconWindow);
                }
             }
            HSystem.SetSystem("flush_graphic", "false");
        }
        void Blob(HObject ho_Image, HObject ho_ROI_0, out HObject ho_AreaEmptyObject,
            HTuple hv_LowThreshold, HTuple hv_HigThreshold, HTuple hv_Select_shapeMin, HTuple hv_Select_shapeMax, HTuple SelectShapeMincircularity, HTuple SelectShapeMaxcircularity,
            bool isSelect_shape, out HTuple hv_Area, out HTuple hv_Row, out HTuple hv_Column)
        {
            // Local iconic variables 
            HObject ho_GrayImage, ho_ImageReduced, ho_thresholdRegions;
            HObject ho_ConnectedRegions = null, ho_SelectedRegions = null, ho_SelectedCircularity = null, ho_Morphology = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_AreaEmptyObject);
            HOperatorSet.GenEmptyObj(out ho_GrayImage);
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.GenEmptyObj(out ho_thresholdRegions);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedRegions);
            HOperatorSet.GenEmptyObj(out ho_SelectedCircularity);
            HOperatorSet.GenEmptyObj(out ho_Morphology);
            hv_Area = new HTuple();
            hv_Row = new HTuple();
            hv_Column = new HTuple();
            HOperatorSet.SetSystem("neighborhood", 8);
            ho_GrayImage.Dispose();
            HOperatorSet.Rgb1ToGray(ho_Image, out ho_GrayImage);
            ho_ImageReduced.Dispose();
            HOperatorSet.ReduceDomain(ho_GrayImage, ho_ROI_0, out ho_ImageReduced);
            ho_thresholdRegions.Dispose();
            HOperatorSet.Threshold(ho_ImageReduced, out ho_thresholdRegions, hv_LowThreshold,hv_HigThreshold);
            if (isSelect_shape == true)//是否连通
            {
                ho_ConnectedRegions.Dispose();
                HOperatorSet.Connection(ho_thresholdRegions, out ho_ConnectedRegions);
                ho_SelectedRegions.Dispose();
                HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_SelectedRegions, "area","and", hv_Select_shapeMin, hv_Select_shapeMax);
                ho_SelectedCircularity.Dispose();
                HOperatorSet.SelectShape(ho_SelectedRegions, out ho_SelectedCircularity, "circularity", "and", SelectShapeMincircularity, SelectShapeMaxcircularity);
                selectMorphology(ho_SelectedCircularity, out ho_Morphology);
                HOperatorSet.AreaCenter(ho_Morphology, out hv_Area, out hv_Row, out hv_Column);
                ho_AreaEmptyObject.Dispose();
                ho_AreaEmptyObject = ho_Morphology.CopyObj(1, -1);

            }
            else
            {
                selectMorphology(ho_thresholdRegions, out ho_Morphology);
                HOperatorSet.AreaCenter(ho_Morphology, out hv_Area, out hv_Row, out hv_Column);
                ho_AreaEmptyObject.Dispose();
                ho_AreaEmptyObject = ho_Morphology.CopyObj(1, -1);
            }
            ho_GrayImage.Dispose();
            ho_ImageReduced.Dispose();
            ho_thresholdRegions.Dispose();
            ho_ConnectedRegions.Dispose();
            ho_SelectedRegions.Dispose();
            ho_SelectedCircularity.Dispose();
            ho_Morphology.Dispose();
        }

        void selectMorphology(HObject ho_Region,  out HObject outRegion)
        {
            HOperatorSet.GenEmptyObj(out outRegion);
            outRegion.Dispose();

            //矩形开运算
            if (Morphology == Tool.矩形区域开运算.ToString())
                HOperatorSet.OpeningRectangle1(ho_Region, out outRegion, Width, Height);
            //矩形闭运算
            else if (Morphology == Tool.矩形区域闭运算.ToString())
                HOperatorSet.ClosingRectangle1(ho_Region, out outRegion, Width, Height);
            //矩形腐蚀
            else if (Morphology == Tool.矩形区域腐蚀.ToString())
                HOperatorSet.ErosionRectangle1(ho_Region, out outRegion, Width, Height);
            //矩形膨胀
            else if (Morphology == Tool.矩形区域膨胀.ToString())
                HOperatorSet.DilationRectangle1(ho_Region, out outRegion, Width, Height);
            //圆开运算
            else if (Morphology == Tool.圆区域开运算.ToString())
                HOperatorSet.OpeningCircle(ho_Region, out outRegion, Width);
            //圆闭运算
            else if (Morphology == Tool.圆区域闭运算.ToString())
                HOperatorSet.ClosingCircle(ho_Region, out outRegion, Width);
            //圆腐蚀
            else if (Morphology == Tool.圆区域腐蚀.ToString())
                HOperatorSet.ErosionCircle(ho_Region, out outRegion, Width);
            //圆膨胀
            else if (Morphology == Tool.圆区域膨胀.ToString())
                HOperatorSet.DilationCircle(ho_Region, out outRegion, Width);
            else if (Morphology == "无")
            {
                  outRegion = ho_Region;
            }
        }
    }
}
