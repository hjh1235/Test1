using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using HOperatorSet_EX;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace UniversalControlSystem
{
    [Serializable]
    public class HalconScriptTool : ImageTool
    {
        [NonSerialized]
        public HDevEngine MyEngine = new HDevEngine();
        [NonSerialized]
        public HDevProgram Program = new HDevProgram();
        [NonSerialized]
        public HDevProcedure Procedure = new HDevProcedure();
        [NonSerialized]
        public HDevProcedureCall ProcedureCall;
        [NonSerialized]
        HObject ho_image, ho_ROI_0, ho_AreaEmptyObject;
        [NonSerialized]
        HTuple hv_Width = null, hv_Height = null;
        [NonSerialized]
        HTuple hv_Area = new HTuple(), hv_Row = new HTuple(), hv_Column = new HTuple();
        /// <summary>
        /// 脚本程序文件全路径
        /// </summary>
        public string ProgramPathString { get; set; }
        /// <summary>
        /// 扩展程序路径
        /// </summary>
        public string ProcedurePath { get; set; }
        /// <summary>
        /// 扩展程序名
        /// </summary>
        public string ProcedureName { get; set; }
        public string DebugPassword { get; set; }
        public int DebugPort { get; set; }

        List<string> listProcedureNames = new List<string>();
        public List<string> ListProcedureNames
        {
            get{  return listProcedureNames; }
            set{  listProcedureNames = value;}
        }

        #region  结果输出
        /// <summary>
        /// 输出结果
        /// </summary>
        public bool ResultLogic { get; set; }

        #endregion

        /// <summary>
        /// 图像名称
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Names { get; set; }


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
        /// <summary>
        /// 轮廓显示
        /// </summary>
        public string Setdraw { get; set; }

        /// <summary>
        ///ROI形状
        /// </summary>
        public string SetdrawShape { get; set; }

        /// <summary>
        /// 区域显示
        /// </summary>
        public bool IsSelectedRegions { get; set; }

        /// <summary>
        /// //斑点显示
        /// </summary>
        public bool IsCross { get; set; }

        /// <summary>
        /// 区域最小方向矩形显示
        /// </summary>
        public bool IsRectangle { get; set; }

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
        public HalconScriptTool()
        {
            ProcedurePath = Application.StartupPath + @"\Script\procedures";
            ////创建脚本对象
            //MyEngine = new HDevEngine();

            MyEngine.SetProcedurePath(ProcedurePath);
            // //脚本程序
            //Program = new HDevProgram();
            ////扩展程序
            //Procedure = new HDevProcedure();
            //////扩展程序调用
            //  ProcedureCall = new HDevProcedureCall(Procedure);

        }
        public override string toolName()
        { return Names; }
        public override long toolTimer()
        {
            return timer;
        }
        public override void recon()
        {
            ProcedurePath = Application.StartupPath + @"\Script\procedures";
            //创建脚本对象
            MyEngine = new HDevEngine();

            MyEngine.SetProcedurePath(ProcedurePath);

            //脚本程序
            Program = new HDevProgram();
            //扩展程序
            Procedure = new HDevProcedure();

            //int Debug = ProgramPathString.LastIndexOf("Debug");//是否是debug下的文件
            //if (Debug != -1)
            //{
            //    string bugPath = ProgramPathString.Substring(Debug + 5, ProgramPathString.Length - (Debug + 5));//截取Debug下的文件,例如 原路径 C://Debug//1
            //    string NewImagePath = Application.StartupPath + bugPath;//复制到不同的文件夹,复制到D盘,替换新的路径,例如 d://Debug//1
            //    ProgramPathString = NewImagePath;
            //}
            //Program.LoadProgram(ProgramPathString);//加载脚本

        }
        public override void ini()
        {

            HOperatorSet.GenEmptyObj(out ho_ROI_0);
            HOperatorSet.GenEmptyObj(out ho_AreaEmptyObject);

            ImageName = "采集图片0";
            Names = "脚本";
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


            Setdraw = Set_draw.margin.ToString();//轮廓显示
            SetdrawShape = Roi.矩形.ToString(); ;//ROI形状
            IsSelectedRegions = true;//blob区域显示
            IsCross = true;//斑点显示
            IsRectangle = false;//区域最小方向矩形显示

        }
        public override void draw_roi()
        {
            HOperatorSet.SetColor(hWindowControl1.HalconWindow, "green");
            draw_roi(hWindowControl1.HalconWindow, ho_Image, ImageName, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2, out hv_circle, out hv_rectangle1, out hv_rectangle2);
            set_after();
        }
        void gen_roi()
        {
            if (ho_ROI_0 != null)
            {
                ho_ROI_0.Dispose();
            }
            gen_roi(out ho_ROI_0, SetdrawShape, hv_circle, hv_rectangle1, hv_rectangle2);
        }
        /// <summary>
        /// 获取脚本程序中扩展程序
        /// </summary>
        /// <returns></returns>
        /// 
        public HTuple GetUsedProcedureNames()
        {
            try
            {
                Program.LoadProgram(ProgramPathString);
                return Program.GetUsedProcedureNames();
            }
            catch (HDevEngineException Ex)
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + Ex.ToString(), CoordSystem.window.ToString(), 10, 10, ColorFul.red.ToString(), "false");
                HSystem.SetSystem("flush_graphic", "false");
                return null;
            }
        }

        /// <summary>
        /// 获取脚本程序中扩展程序
        /// </summary>
        /// <returns></returns>
        public List<string> GetLocalProcedureNames()
        {
            try
            {
                List<string> listProcedureNames = new List<string>();
                ListProcedureNames.Clear();
                string InputIconicParamName = "", OutputIconicParamName = "", InputCtrlParamName = "", OutputCtrlParamName = "";

                if (Program.IsLoaded())
                {
                    Program.Dispose();
                    Program = new HDevProgram();
                }
                Program.LoadProgram(ProgramPathString);
                HTuple ProcedureNames = Program.GetUsedProcedureNames();
                foreach (string Name in ProcedureNames.ToSArr())
                {
                    InputIconicParamName = ""; OutputIconicParamName = ""; InputCtrlParamName = ""; OutputCtrlParamName = "";
                    Procedure.LoadProcedure(Program, Name);//子程序
                    #region 输入图形
                    string[] InputIconicParamNames = Procedure.GetInputIconicParamNames().ToSArr();
                    if (InputIconicParamNames.Length == 0)
                    { InputIconicParamName += ":"; }    //无参数
                    else
                    {
                        for (int i = 0; i < InputIconicParamNames.Length; i++)
                        {
                            if (InputIconicParamNames.Length > 1)
                            {
                                if (InputIconicParamNames.Length - 1 > i)
                                    InputIconicParamName += InputIconicParamNames[i] + ",";//多个参数
                                else
                                {
                                    InputIconicParamName += InputIconicParamNames[i] + ":";//最后一个参数
                                }
                            }
                            else
                            {
                                InputIconicParamName += InputIconicParamNames[i] + ":";//一个参数
                            }
                        }
                    }
                    #endregion
                    #region 输出图形
                    string[] OutputIconicParamNames = Procedure.GetOutputIconicParamNames().ToSArr();
                    if (OutputIconicParamNames.Length == 0)
                    { OutputIconicParamName += ":"; }    //无参数
                    else
                    {
                        for (int i = 0; i < OutputIconicParamNames.Length; i++)
                        {
                            if (OutputIconicParamNames.Length > 1)
                            {
                                if (OutputIconicParamNames.Length - 1 > i)
                                    OutputIconicParamName += OutputIconicParamNames[i] + ",";//多个参数
                                else
                                {
                                    OutputIconicParamName += OutputIconicParamNames[i] + ":";//最后一个参数
                                }
                            }
                            else
                            {
                                OutputIconicParamName += OutputIconicParamNames[i] + ":";//一个参数
                            }
                        }
                    }
                    #endregion
                    #region 输入参数
                    string[] InputCtrlParamNames = Procedure.GetInputCtrlParamNames();
                    if (InputCtrlParamNames.Length == 0)
                    { InputCtrlParamName += ":"; }    //无参数
                    else
                    {
                        for (int i = 0; i < InputCtrlParamNames.Length; i++)
                        {
                            if (InputCtrlParamNames.Length > 1)
                            {
                                if (InputCtrlParamNames.Length - 1 > i)
                                    InputCtrlParamName += InputCtrlParamNames[i] + ",";//多个参数
                                else
                                {
                                    InputCtrlParamName += InputCtrlParamNames[i] + ":";//最后一个参数
                                }

                            }
                            else
                            {
                                InputCtrlParamName += InputCtrlParamNames[i] + ":";//一个参数
                            }
                        }
                    }
                    #endregion
                    #region 输出结果
                    string[] OutputCtrlParamNames = Procedure.GetOutputCtrlParamNames();
                    if (OutputCtrlParamNames.Length == 0)
                    { OutputCtrlParamName += ":"; }    //无参数
                    else
                    {
                        for (int i = 0; i < OutputCtrlParamNames.Length; i++)
                        {
                            if (OutputCtrlParamNames.Length > 1)
                            {
                                if (OutputCtrlParamNames.Length - 1 > i)
                                    OutputCtrlParamName += OutputCtrlParamNames[i] + ",";//多个参数
                                else
                                {
                                    OutputCtrlParamName += OutputCtrlParamNames[i];//最后一个参数
                                }
                            }
                            else
                            {
                                OutputCtrlParamName += OutputCtrlParamNames[i];//一个参数
                            }
                        }
                    }
                    #endregion
                    listProcedureNames.Add(Name + "(" + InputIconicParamName + OutputIconicParamName + InputCtrlParamName + OutputCtrlParamName + ")");

                }
                ListProcedureNames = listProcedureNames;
                ////从脚本文件获取扩展程序
                return listProcedureNames;
            }
            catch (HDevEngineException Ex)
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + Ex.ToString(), CoordSystem.window.ToString(), 10, 10, ColorFul.red.ToString(), "false");
                HSystem.SetSystem("flush_graphic", "false");
                return null;
            }

        }
        private void ExecProgram()
        {
            try
            {
                ResultLogic = true;
                if (!Program.IsLoaded())//是否加载脚本
                {
                    int Debug = ProgramPathString.LastIndexOf("Debug");//是否是debug下的文件
                    if (Debug != -1)
                    {
                        string bugPath = ProgramPathString.Substring(Debug + 5, ProgramPathString.Length - (Debug + 5));//截取Debug下的文件,例如 原路径 C://Debug//1
                        string NewImagePath = Application.StartupPath + bugPath;//复制到不同的文件夹,复制到D盘,替换新的路径,例如 d://Debug//1
                        ProgramPathString = NewImagePath;
                    }
                    Program.LoadProgram(ProgramPathString);//加载脚本
                }
                //从脚本文件获取扩展程序
                int index = ProcedureName.IndexOf("(");
                string s = ProcedureName.Substring(0, index);
                Double Seconds1 = HSystem.CountSeconds();
                Procedure.LoadProcedure(Program, s);
                //扩展程序调用
                ProcedureCall = new HDevProcedureCall(Procedure);
                //设置参数
                ProcedureCall.SetInputIconicParamObject(1, ho_image);//HObjcet第一个参数
                ProcedureCall.SetInputIconicParamObject(2, ho_ROI_0);//HObjcet第二个参数
                double Seconds2 = HSystem.CountSeconds();
                //执行
                ProcedureCall.Execute();
                double Seconds = (Seconds2 - Seconds1) * 1000;
                //获取图形结果
                if (ho_AreaEmptyObject != null)
                    ho_AreaEmptyObject.Dispose();
                ho_AreaEmptyObject = ProcedureCall.GetOutputIconicParamRegion(1);//HObjcet图形结果
                HOperatorSet.AreaCenter(ho_AreaEmptyObject, out hv_Area, out hv_Row, out hv_Column);
                //获取int/double/HTuple结果
                HTuple OutputParam1 = ProcedureCall.GetOutputCtrlParamTuple(1);//面积大小
                hv_Area = OutputParam1;
                HTuple Param2 = ProcedureCall.GetOutputCtrlParamTuple(2);//判定结果
                if (Param2.I != 1)
                    ResultLogic = false;

            }
            catch (HDevEngineException Ex)
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + Ex.ToString(), CoordSystem.window.ToString(), 10, 10, ColorFul.red.ToString(), "false");
                HSystem.SetSystem("flush_graphic", "false");
                ResultLogic = false;
                return;
            }
        }
        
        public  bool StartDebugServer()
        {
            try
            {
                // Disable as debugging of JIT-compiled procedures is not possible
                MyEngine.SetEngineAttribute("execute_procedures_jit_compiled", "false");
                // Set debug parameters
                MyEngine.SetEngineAttribute("debug_port", DebugPort);
                MyEngine.SetEngineAttribute("debug_password", DebugPassword);
                //MyEngine.StartDebugServer();
                return true;
            }
            catch
            {
                MessageBox.Show("halcon13_以上有debug功能");
                return true;
            }
           
        }
        public  bool StopDebugServer()
        {
            //MyEngine.StopDebugServer();
            return false;
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
                ho_image = (HObject)ho_Image[ImageName];
                HOperatorSet.GetImageSize((HObject)ho_Image[ImageName], out hv_Width, out hv_Height);
                gen_roi();
                ExecProgram();
            }
            catch
            {
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");
            }
           
        }
        public override void dispresult()
        {
            try
            {
                dispresult(ho_AreaEmptyObject, hv_Row, hv_Column, IsSelectedRegions, IsCross, IsRectangle, hv_Height);
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.set_display_font(hWindowControl1.HalconWindow, 20, "sans", "false", "false");//mono', 'sans', 'serif
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow,"面积："+ hv_Area.TupleSelect(0), CoordSystem.window.ToString(), 10, 10, ColorFul.black.ToString(), ColorFul.green.ToString());
                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
                HOperatorSet.DispObj(ho_ROI_0, hWindowControl1.HalconWindow);
                HSystem.SetSystem("flush_graphic", "false");
            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");

            }
        }
        public override long set_after()
        {
            try
            {
                ho_image = (HObject)ho_Image[ImageName];
                Stopwatch watch = new Stopwatch();
                watch.Start();
                HOperatorSet.ClearWindow(hWindowControl1.HalconWindow);
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet.DispObj(ho_image, hWindowControl1.HalconWindow);
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
        void dispresult(HObject ho_AreaEmptyObject, HTuple hv_Row, HTuple hv_Column, bool isSelectedRegions,
               bool IsCross, bool IsRectangle, HTuple hv_Height)
        {
            try
            {
                // Initialize local and output iconic variables

                HObject ho_Cross, ho_Rectangle;

                HOperatorSet.GenEmptyObj(out ho_Cross);
                HOperatorSet.GenEmptyObj(out ho_Rectangle);

                if (ResultLogic)//
                {
                    HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.green.ToString());
                }
                else
                { HOperatorSet.SetColor(hWindowControl1.HalconWindow, ColorFul.red.ToString()); }

                HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Setdraw);
                HSystem.SetSystem("flush_graphic", "true");
                if ((int)(new HTuple((new HTuple(hv_Row.TupleLength())).TupleGreater(0))) != 0)
                {
                    if (isSelectedRegions)
                    {
                        HOperatorSet.DispObj(ho_AreaEmptyObject, hWindowControl1.HalconWindow);
                    }
                    if (IsCross)
                    {
                        ho_Cross.Dispose();
                        HOperatorSet.GenCrossContourXld(out ho_Cross, hv_Row, hv_Column, hv_Height / 100, 0);
                        HOperatorSet.DispObj(ho_Cross, hWindowControl1.HalconWindow);
                        ho_Cross.Dispose();
                    }
                    if (IsRectangle)
                    {
                        ho_Rectangle.Dispose();
                        HOperatorSet.SetDraw(hWindowControl1.HalconWindow, Set_draw.margin.ToString());
                        HOperatorSet.ShapeTrans(ho_AreaEmptyObject, out ho_Rectangle, "rectangle2");
                        HOperatorSet.DispObj(ho_Rectangle, hWindowControl1.HalconWindow);
                        ho_Rectangle.Dispose();
                    }
                }
                HSystem.SetSystem("flush_graphic", "false");

            }
            catch
            {
                HSystem.SetSystem("flush_graphic", "true");
                HOperatorSet_Ex.disp_message(hWindowControl1.HalconWindow, Names + "运行异常", "image", 10, 10, "red", "false");
                ResultLogic = false;//结果异常
                HSystem.SetSystem("flush_graphic", "false");

            }

        }
        public override bool toolResult()
        {
            return ResultLogic;
        }
    }
}
