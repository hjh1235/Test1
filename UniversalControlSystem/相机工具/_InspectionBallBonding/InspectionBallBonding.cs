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
    
     //
     public  class InspectionBallBondingTool:ImageTool
    {

        [NonSerialized]
        HObject ho_ROI_0;
        public HObject ROI
        {
            get { return ho_ROI_0; }
            set { ho_ROI_0 = value; }
        }
        [NonSerialized]
        HTuple hv_Row = null, hv_Column = null, hv_Radius = null, hv_Diameter = null, hv_meanDiameter = null, hv_mimDiameter = null;


        public HTuple ResultRowCenter
        {
            get { return hv_Row; }
            set { hv_Row = value; }
        }
        public HTuple ResultColCenter
        {
            get { return hv_Column; }
            set { hv_Column = value; }
        }
        public HTuple ResultRadius
        {
            get { return hv_Radius; }
            set { hv_Radius = value; }
        }

        public HTuple ResultDiameter
        {
            get { return hv_Diameter; }
            set { hv_Diameter = value; }
        }

        [NonSerialized]
        List<bool> resultLogic = new List<bool>();
        [NonSerialized]
        bool logic1, logic2;
        [NonSerialized]
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
         Dictionary<string, List<HTuple>> htHomMat2D = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> HtHomMat2D
        {
            get { return htHomMat2D; }
            set { htHomMat2D = value; }
        }
        [NonSerialized]
         Dictionary<string, List<HTuple>> htPhi = new  Dictionary<string, List<HTuple>>();
        public  Dictionary<string, List<HTuple>> HtPhi
        {
            get { return htPhi; }
            set { htPhi = value; }
        }
        #region 输出结果
        /// <summary>
        /// 输出结果
        /// </summary>
        public bool ResultLogic { get; set; }
        public HTuple ResultCol
        {
            get { return hv_Column; }
            set { hv_Column = value; }
        }

        #endregion
        #region 参数
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
        public HTuple MinGray
        { get; set; }

        public HTuple MaxGray
        { get; set; }

        public HTuple FillUpshapeMin
        { get; set; }

        public HTuple FillUpshapeMax
        { get; set; }

        public HTuple OpeningCircle
        { get; set; }
       
        /// <summary>
        /// ROI路径
        /// </summary>
        public string RoiPath { get; set; }
        public string RegionType { get; set; }
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
        /// 
        /// </summary>
        public bool IsCross
        { get; set; }
        public HTuple LowNums { get; set; }
        public HTuple HigNums { get; set; }
        public bool IsNums { get; set; }

        public HTuple LowDiameter { get; set; }
        public HTuple HigDiameter { get; set; }
        public bool IsDiameter { get; set; }
     
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
            this.resultLogic = new List<bool>();
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
            Names = Tool.焊点检测.ToString();
            ImageName = "采集图像0";
            FixNames = Tool.位置定位.ToString();
            IsFixture = false;
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


            MinGray = 1;//低阀值
            MaxGray = 50;//高阀值
            FillUpshapeMin = 1;
            FillUpshapeMax = 100;
            OpeningCircle = 15.5;
        
            Setdraw = Set_draw.margin.ToString();//轮廓显示
            SetdrawShape = Roi.矩形.ToString(); ;//ROI形状
            IsCross = true;//斑点显示
   
            LowNums = 1;
            HigNums = 999;
            IsNums = false;
            LowDiameter = 1;//
            HigDiameter = 30;
            IsDiameter = false;
         }
        public override void draw_roi()
        {
           
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            HSystem.SetSystem("flush_graphic", "true");
            HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "绘制ROI,右键确定！", CoordSystem.window.ToString(), 10, 10, ColorFul.black.ToString(), ColorFul.white.ToString());
            HSystem.SetSystem("flush_graphic", "false");
            draw_roi(hWindowControl1.HalconWindow, ho_Image, ImageName, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2, out hv_circle, out hv_rectangle1, out hv_rectangle2);
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
            HObject RegionAffineTrans, imgReduce;
            HOperatorSet.GenEmptyObj(out RegionAffineTrans);
            HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
            try
            {
                ResultLogic = true;//合格
                resultLogic.Clear();
               // HOperatorSet.GetImageSize((HObject)ho_Image[imageName], out hv_Width, out hv_Height);
                if (IsFixture) //使用位置定位
                {   //
                    HomMat2D = (List<HTuple>)htHomMat2D[FixNames];  //  选择位置定位
                    Phi = (List<HTuple>)HtPhi[FixNames]; //  选择位置定位
                    //遍历定位>
                    for (int i = 0; i < HomMat2D.Count; i++)
                    {
                     
                        if (RegionAffineTrans != null)
                            RegionAffineTrans.Dispose();
                        HOperatorSet.AffineTransRegion(ho_ROI_0, out RegionAffineTrans, HomMat2D[i], "nearest_neighbor");
                        HOperatorSet.ReduceDomain((HObject)Image[ImageName], RegionAffineTrans, out imgReduce);
                        InspectBallBonding(imgReduce, MinGray, MaxGray, FillUpshapeMin, FillUpshapeMax, OpeningCircle, out hv_Row, out hv_Column, out hv_Radius,
                                           out hv_Diameter, out hv_meanDiameter, out hv_mimDiameter);

                      
                        if (IsDiameter) //使用焊点直径管控
                        {
                            for (int j = 0; j < hv_Diameter.Length; j++)
                            {
                                logic1 = true;
                                if (LowDiameter > hv_Diameter.TupleSelect(j) || hv_Diameter.TupleSelect(j) > HigDiameter)
                                    logic1 = false;
                                resultLogic.Add(logic1);
                            }
                          
                        }
                        logic2 = true;
                        if (IsNums)//使用数量管控
                        {
                            if (LowNums > hv_Diameter.Length || hv_Diameter.Length > HigNums)
                                logic2 = false;
                            resultLogic.Add(logic2);
                        }
                        HSystem.SetSystem("flush_graphic", "true");

                        if (logic1 && logic2)
                            HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.green.ToString());
                        else
                            HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.red.ToString());
                        HOperatorSet.DispObj(RegionAffineTrans, hWindowControl1.HalconWindow);
                        dispresult();
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
              
                    HSystem.SetSystem("flush_graphic", "true");
                    HOperatorSet.SetColored(hWindowControl1.HalconWindow, 12);
                    HOperatorSet.ReduceDomain((HObject)Image[ImageName], ho_ROI_0, out imgReduce);
                    InspectBallBonding(imgReduce, MinGray, MaxGray, FillUpshapeMin, FillUpshapeMax, OpeningCircle, out hv_Row, out hv_Column, out hv_Radius,
                                           out hv_Diameter, out hv_meanDiameter, out hv_mimDiameter);

                      
                        if (IsDiameter) //使用焊点直径管控
                        {
                            for (int j = 0; j < hv_Diameter.Length; j++)
                            {
                                logic1 = true;
                                if (LowDiameter > hv_Diameter.TupleSelect(j) || hv_Diameter.TupleSelect(j) > HigDiameter)
                                    logic1 = false;
                                resultLogic.Add(logic1);
                            }
                          
                        }
                        logic2 = true;
                        if (IsNums)//使用数量管控
                        {
                            if (LowNums > hv_Diameter.Length || hv_Diameter.Length > HigNums)
                                logic2 = false;
                            resultLogic.Add(logic2);
                        }
                     
                        HSystem.SetSystem("flush_graphic", "false");
                    }
                    foreach (bool item in resultLogic)
                    {
                        if (!item)
                            ResultLogic = false;
                    }
                }
            
            catch
            {
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//不合格
                HSystem.SetSystem("flush_graphic", "false");
            }
           
        }
        public override void dispresult()
        {
            try
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
                HOperatorSet.DispObj(ho_ROI_0, hWindowControl1.HalconWindow);
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Setdraw);
                DispMessageBallBonding(hv_Row, hv_Column, hv_Radius, hv_Diameter, hWindowControl1.HalconWindow);
                HSystem.SetSystem("flush_graphic", "false");
                if (IsDiameter) //使用焊点直径管控
                {
                    for (int j = 0; j < hv_Diameter.Length; j++)
                    {
                        if (LowDiameter > hv_Diameter.TupleSelect(j) || hv_Diameter.TupleSelect(j) > HigDiameter)
                            HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.red.ToString());
                        else
                            HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.green.ToString());
                        HSystem.SetSystem("flush_graphic", "true");
                        HOperatorSet.DispCircle(hWindowControl1.HalconWindow, hv_Row.TupleSelect(j), hv_Column.TupleSelect(j), hv_Radius.TupleSelect(j));
                        HSystem.SetSystem("flush_graphic", "false");
                    }
                }
                else
                {
                    HSystem.SetSystem("flush_graphic", "true");
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.green.ToString());
                    HOperatorSet.DispCircle(hWindowControl1.HalconWindow, hv_Row, hv_Column, hv_Radius);
                    HSystem.SetSystem("flush_graphic", "false");
                }
     
            }
            catch
            {
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "显示异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//不合格
                HSystem.SetSystem("flush_graphic", "false");
            }
        }
        public override long set_after()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.DispObj((HObject)ho_Image[imageName], hWindowControl1.HalconWindow);
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
        public override bool toolResult()
        {
            return ResultLogic;
        }
        public void InspectBallBonding(HObject ho_DieGrey, HTuple hv_MinGray, HTuple hv_MaxGray,
            HTuple hv_FillUpshapeMin, HTuple hv_FillUpshapeMax, HTuple hv_OpeningCircle,
            out HTuple hv_Row, out HTuple hv_Column, out HTuple hv_Radius, out HTuple hv_Diameter,
            out HTuple hv_meanDiameter, out HTuple hv_mimDiameter)
        {
            // Local iconic variables 

            HObject ho_Wires, ho_WiresFilled, ho_Balls;
            HObject ho_SingleBalls, ho_IntermediateBalls, ho_FinalBalls;

            // Local control variables 

            HTuple hv_NumBalls = null;
            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_Wires);
            HOperatorSet.GenEmptyObj(out ho_WiresFilled);
            HOperatorSet.GenEmptyObj(out ho_Balls);
            HOperatorSet.GenEmptyObj(out ho_SingleBalls);
            HOperatorSet.GenEmptyObj(out ho_IntermediateBalls);
            HOperatorSet.GenEmptyObj(out ho_FinalBalls);
            try
            {
                ho_Wires.Dispose();
                HOperatorSet.Threshold(ho_DieGrey, out ho_Wires, hv_MinGray, hv_MaxGray);
                ho_WiresFilled.Dispose();
                HOperatorSet.FillUpShape(ho_Wires, out ho_WiresFilled, "area", hv_FillUpshapeMin,
                    hv_FillUpshapeMax);
                ho_Balls.Dispose();
                HOperatorSet.OpeningCircle(ho_WiresFilled, out ho_Balls, hv_OpeningCircle);
                ho_SingleBalls.Dispose();
                HOperatorSet.Connection(ho_Balls, out ho_SingleBalls);
                ho_IntermediateBalls.Dispose();
                HOperatorSet.SelectShape(ho_SingleBalls, out ho_IntermediateBalls, "circularity",
                    "and", 0.85, 1.0);
                ho_FinalBalls.Dispose();
                HOperatorSet.SortRegion(ho_IntermediateBalls, out ho_FinalBalls, "first_point",
                    "true", "column");
                HOperatorSet.SmallestCircle(ho_FinalBalls, out hv_Row, out hv_Column, out hv_Radius);
                hv_NumBalls = new HTuple(hv_Radius.TupleLength());
                hv_Diameter = 2 * hv_Radius;
                hv_meanDiameter = (hv_Diameter.TupleSum()) / hv_NumBalls;
                hv_mimDiameter = hv_Diameter.TupleMin();
                ho_Wires.Dispose();
                ho_WiresFilled.Dispose();
                ho_Balls.Dispose();
                ho_SingleBalls.Dispose();
                ho_IntermediateBalls.Dispose();
                ho_FinalBalls.Dispose();

                return;
            }
            catch (HalconException HDevExpDefaultException)
            {
                ho_Wires.Dispose();
                ho_WiresFilled.Dispose();
                ho_Balls.Dispose();
                ho_SingleBalls.Dispose();
                ho_IntermediateBalls.Dispose();
                ho_FinalBalls.Dispose();

                throw HDevExpDefaultException;
            }
        }

        public void DispMessageBallBonding(HTuple hv_Row, HTuple hv_Column, HTuple hv_Radius,
         HTuple hv_Diameter, HTuple hv_WindowID)
        {
            // Local control variables 
            HTuple hv_i = null,colorful=null;
            // Initialize local and output iconic variables 
            for (hv_i = 1; (int)hv_i <= (int)(new HTuple(hv_Row.TupleLength())); hv_i = (int)hv_i + 1)
            {
                if ((int)(new HTuple(((hv_i.TupleFmod(2))).TupleEqual(1))) != 0)
                {
                    if (IsDiameter) //使用焊点直径管控
                    {
                        if (LowDiameter > hv_Diameter.TupleSelect(hv_i - 1) || hv_Diameter.TupleSelect(hv_i - 1) > HigDiameter)
                            colorful = "red";
                        else
                            colorful = "forest green";
                        HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "D: " + (hv_Diameter.TupleSelect(hv_i - 1)),
                          "image", (hv_Row.TupleSelect(hv_i - 1)) - (2.7 * (hv_Radius.TupleSelect(hv_i - 1))),
                          (((((hv_Column.TupleSelect(hv_i - 1)) - 60)).TupleConcat(0))).TupleMax(),
                       "white", colorful);
                       
                    }
                    else
                         HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "D: " + (hv_Diameter.TupleSelect(hv_i - 1)),
                        "image", (hv_Row.TupleSelect(hv_i - 1)) - (2.7 * (hv_Radius.TupleSelect(hv_i - 1))),
                        (((((hv_Column.TupleSelect(hv_i - 1)) - 60)).TupleConcat(0))).TupleMax(),
                        "white", "forest green");
                }
                else
                {
                    if (IsDiameter) //使用焊点直径管控
                    {
                        if (LowDiameter > hv_Diameter.TupleSelect(hv_i - 1) || hv_Diameter.TupleSelect(hv_i - 1) > HigDiameter)
                            colorful = "red";
                        else
                            colorful = "forest green";
                            HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "D: " + (hv_Diameter.TupleSelect(hv_i - 1)),
                     "image", (hv_Row.TupleSelect(hv_i - 1)) + (1.2 * (hv_Radius.TupleSelect(hv_i - 1))),
                     (((((hv_Column.TupleSelect(hv_i - 1)) - 60)).TupleConcat(0))).TupleMax(),
                      "white", colorful);
                    }
                    else
                    HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, "D: " + (hv_Diameter.TupleSelect(hv_i - 1)),
                        "image", (hv_Row.TupleSelect(hv_i - 1)) + (1.2 * (hv_Radius.TupleSelect(hv_i - 1))),
                        (((((hv_Column.TupleSelect(hv_i - 1)) - 60)).TupleConcat(0))).TupleMax(),
                        "white", "forest green");
                }
            }
            return;
        }

    }
}
