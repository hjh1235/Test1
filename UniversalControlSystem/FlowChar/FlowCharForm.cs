using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace UniversalControlSystem
{
    public partial class FlowCharForm : Form
    {
        public FlowCharForm()
        {
            InitializeComponent();
        }
        public string hardwareName { get; set; }
        public string hardwareTpye { get; set; }
        public string hardwareVender { get; set; }
        string AllPath { get; set; }
        public List<ImageTool> copyList = new List<ImageTool>();
        List<ImageTool> tool = new List<ImageTool>();
        OutPut_Puse OutPut_Puse;
        OutPut _OutPut_;
        F_OutPut_DeeDelay _F_OutPut_DeeDelay;
        F_Delay_DeeOutPut _F_Delay_DeeOutPut;
        Check_INPUT _Check_INPUT;

        Aixs_one_Ctron _Aixs_one_Ctron;
        Aixs_more_Ctron _Aixs_more_Ctron;
        CheckAixsRunFinish _CheckAixsRunFinish;

        DelayData _DelayData;
        DataGroup _DataGroup;

        ArcXYC _ArcXYC;
        LnXYZ _LnXYZ;
        LnXY _LnXY;
        LnXYZA _LnXYZA;
        BufferArea _BufferArea;
        AddOtherBuff _AddOtherBuff;
        SerialPortSendData _SerialPortSendData;
        SerialPortResData _SerialPortResData;
        _ser_clSendData ser_clSendData;
        _ser_clResData ser_clResData;
        PYTool _PYTool;
        CodeEditTool _CodeEditTool;
        CamerCompensation_Center _CamerCompensation_Center;
        DigitalMea_Height _DigitalMea_Height;
        CamerGetR_Center _CamerGetR_Center;
        Cir _Cir;
        DefintionFun _DefintionFun;
        Dimetric _Dimetric;
        Aixs_more_CtronRunFinish _Aixs_more_CtronRunFinish;
        CallSubroutine _CallSubroutine;
        DefintionFun2 _DefintionFun2;
        DefintionFun3 _DefintionFun3;
        DefintionFun4 _DefintionFun4;
        //视觉
        AcqFifoTool _AcqFifoTool;
        WeldedCheck _WeldedCheck;
        And _And;
        Or _Or;
        XOr _XOr;
        Neg _Neg;
        LogicalJump _LogicalJump;
        public void ShowFromMessage()
        {
            tvw_tools.Nodes.Clear();
            dgv_deviceList.Rows.Clear();
            label1.Text = hardwareName;
            路径.Text = Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].sPath;
            try
            {
                try
                {
                    Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].dicFlowData = Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].ListFlowData.ToDictionary(p => p.RunFlowData_ControlDataName);
                    Properties.Settings.Default.FlowRunPath = 路径.Text;
                    Properties.Settings.Default.Save();
                    LoadData.ReadData(Properties.Settings.Default.FlowRunPath);
                    foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].dicFlowData)
                    {

                        int idx = dgv_deviceList.Rows.Add();
                        dgv_deviceList.Rows[idx].Tag = textBoxHardWareName.Text;
                        this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                        dgv_deviceList.Rows[idx].Height = 30;
                        dgv_deviceList.Rows[idx].Cells[0].Value = item.Value.RunFlowData_ControlDataName;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception error)
            {
                return;
            }
            m_Tool_Load();
        }
        private void m_Tool_Load()
        {
            try
            {
                //输出相关
                TreeNode ImageNode = tvw_tools.Nodes.Add("", "输出相关", 0, 0);
                {
                    ImageNode.Nodes.Add("", "输出", 38, 38);
                }
                //输入相关
                TreeNode DetectNode = tvw_tools.Nodes.Add("", "输入相关", 0, 0);
                {
                    DetectNode.Nodes.Add("", "输入检测", 33, 33);
                }
                //循环START
                TreeNode CalibNode = tvw_tools.Nodes.Add("", "LOOPSTART", 0, 0);
                {
                    CalibNode.Nodes.Add("", "LOOPSTART", 58, 58);
                }
                //循环STOP
                TreeNode AlignNode = tvw_tools.Nodes.Add("", "LOOPSTOP", 0, 0);
                {
                    AlignNode.Nodes.Add("", "LOOPSTOP", 49, 49);
                }
                //MES相关
                TreeNode FindAndFitNode = tvw_tools.Nodes.Add("", "MES相关", 0, 0);
                {
                    FindAndFitNode.Nodes.Add("", "数据检验", 6, 6);
                    FindAndFitNode.Nodes.Add("", "数据赋值", 7, 7);
                    FindAndFitNode.Nodes.Add("", "数据过站", 8, 8);
                    FindAndFitNode.Nodes.Add("", "数据获取", 9, 9);
                    FindAndFitNode.Nodes.Add("", "通过MES数据获取", 9, 9);
                    FindAndFitNode.Nodes.Add("", "MES数据存储", 9, 9);
                }
                //逻辑控制
                TreeNode LogicNode = tvw_tools.Nodes.Add("", "逻辑控制", 0, 0);
                {
                    LogicNode.Nodes.Add("", "循环", 52, 52);
                    LogicNode.Nodes.Add("", "分支", 53, 53);
                }
                //PLC控制
                TreeNode CreateNode = tvw_tools.Nodes.Add("", "PLC控制", 0, 0);
                {
                    CreateNode.Nodes.Add("", "PLC设置", 12, 12);
                    CreateNode.Nodes.Add("", "数据写入", 12, 12);
                    CreateNode.Nodes.Add("", "数据读取", 14, 14);
                    CreateNode.Nodes.Add("", "数据展示", 15, 15);
                }
                //两轴直线插补
                TreeNode GeometryNode = tvw_tools.Nodes.Add("", "两轴圆弧插补主表", 0, 0);
                {
                    GeometryNode.Nodes.Add("", "两轴圆弧插补", 32, 32);
                }
                //两轴圆弧插补
                TreeNode GeometryNodeLine = tvw_tools.Nodes.Add("", "两轴直线插补主表", 0, 0);
                {
                    GeometryNodeLine.Nodes.Add("", "两轴直线插补", 33, 33);

                }
                //三轴螺旋插补
                TreeNode ThreeGeometryNodeR = tvw_tools.Nodes.Add("", "三轴螺旋插补主表", 0, 0);
                {
                    ThreeGeometryNodeR.Nodes.Add("", "三轴螺旋插补", 34, 34);
                }
                //三轴直线插补
                TreeNode ThreeGeometryNodeL = tvw_tools.Nodes.Add("", "三轴直线插补主表", 0, 0);
                {
                    ThreeGeometryNodeL.Nodes.Add("", "三轴直线插补", 35, 35);

                }
                //四轴直线插补
                TreeNode FortGeometryNodeL = tvw_tools.Nodes.Add("", "四轴直线插补主表", 0, 0);
                {
                    FortGeometryNodeL.Nodes.Add("", "四轴直线插补", 36, 36);

                }
                //工位互锁
                TreeNode 工位互锁 = tvw_tools.Nodes.Add("", "工位互锁", 0, 0);
                {
                    工位互锁.Nodes.Add("", "工位互锁", 37, 37);

                }
                //缓存区控制列表
                TreeNode 缓存区控制列表 = tvw_tools.Nodes.Add("", "缓存区控制列表菜单", 0, 0);
                {
                    缓存区控制列表.Nodes.Add("", "缓存区控制列表", 38, 38);
                    缓存区控制列表.Nodes.Add("", "缓存区插入其他", 39, 39);
                }
                //回原点
                //激光控制
                TreeNode 激光控制 = tvw_tools.Nodes.Add("", "激光控制主", 0, 0);
                {
                    激光控制.Nodes.Add("", "激光控制", 40, 40);
                }
                //脚本
                TreeNode 脚本 = tvw_tools.Nodes.Add("", "脚本栏", 0, 0);
                {
                    脚本.Nodes.Add("", "PY脚本", 1, 1);
                    脚本.Nodes.Add("", "c#脚本", 2, 2);
                }
                //解除工位互锁
                TreeNode 解除工位互锁 = tvw_tools.Nodes.Add("", "解除工位互锁主", 0, 0);
                {
                    解除工位互锁.Nodes.Add("", "解除工位互锁", 3, 3);
                }
                //数据组
                TreeNode 数据组 = tvw_tools.Nodes.Add("", "数据组", 0, 0);
                {
                    数据组.Nodes.Add("", "数据组赋值", 4, 4);
                    数据组.Nodes.Add("", "数据组检测", 5, 5);
                }
                //条件判断
                TreeNode 条件判断 = tvw_tools.Nodes.Add("", "条件判断主", 0, 0);
                {
                    条件判断.Nodes.Add("", "条件判断", 16, 16);
                }

                TreeNode 条件判断调子流程主 = tvw_tools.Nodes.Add("", "条件判断调子流程主", 0, 0);
                {
                    条件判断调子流程主.Nodes.Add("", "条件判断调子流程", 16, 16);
                    条件判断调子流程主.Nodes.Add("", "条件判断步骤跳转", 16, 16);

                }
                //通讯
                TreeNode 通讯 = tvw_tools.Nodes.Add("", "通讯", 0, 0);
                {
                    通讯.Nodes.Add("", "串口通讯发送命令", 6, 6);
                    通讯.Nodes.Add("", "串口通讯接受指令", 7, 7);
                    通讯.Nodes.Add("", "网络通讯发送命令", 8, 8);
                    通讯.Nodes.Add("", "网络通讯接受指令", 9, 9);
                }
                //延时
                TreeNode 延时 = tvw_tools.Nodes.Add("", "延时主", 0, 0);
                {
                    延时.Nodes.Add("", "延时", 10, 10);
                }
                //单轴运动
                TreeNode 单轴运动 = tvw_tools.Nodes.Add("", "单轴运动主", 0, 0);
                {
                    单轴运动.Nodes.Add("", "单轴运动", 51, 51);
                    单轴运动.Nodes.Add("", "检测运动完成", 18, 18);

                }
                //多轴运动
                TreeNode 多轴运动 = tvw_tools.Nodes.Add("", "多轴运动主", 0, 0);
                {
                    多轴运动.Nodes.Add("", "多轴运动", 50, 50);
                    多轴运动.Nodes.Add("", "多轴检测轴运动完成", 40, 40);
                }
                //运算
                TreeNode CalculateNode = tvw_tools.Nodes.Add("", "运算主", 0, 0);
                {
                    TreeNode ArithmeticNode = CalculateNode.Nodes.Add("", "算术", 33, 33);
                    TreeNode 算术 = ArithmeticNode.Nodes.Add("", "算术细分", 0, 0);
                    {
                        算术.Nodes.Add("", "与", 12, 12);
                        算术.Nodes.Add("", "或", 13, 13);
                        算术.Nodes.Add("", "非", 31, 31);
                        算术.Nodes.Add("", "异或", 13, 13);
                    }
                    TreeNode DataAnalyse = CalculateNode.Nodes.Add("", "数据分析", 26, 26);
                    TreeNode 数据分析 = DataAnalyse.Nodes.Add("", "数据分析细分", 0, 0);
                    {
                        数据分析.Nodes.Add("", "大于", 12, 12);
                        数据分析.Nodes.Add("", "小于", 13, 13);
                        数据分析.Nodes.Add("", "等于", 31, 31);
                        数据分析.Nodes.Add("", "大于等于", 13, 13);
                        数据分析.Nodes.Add("", "小于等于", 13, 13);
                    }
                }
                //展示
                TreeNode 展示 = tvw_tools.Nodes.Add("", "展示主", 0, 0);
                {
                    展示.Nodes.Add("", "展示", 19, 19);
                }
                //相机工具
                TreeNode 相机工具 = tvw_tools.Nodes.Add("", "相机工具", 0, 0);
                {
                    相机工具.Nodes.Add("", "焊后拍照检测", 19, 19);
                    相机工具.Nodes.Add("", "获取圆心坐标", 19, 19);
                    相机工具.Nodes.Add("", "相机补偿", 19, 19);
                }
                //测距工具
                TreeNode 测距工具 = tvw_tools.Nodes.Add("", "测距工具", 0, 0);
                {
                    测距工具.Nodes.Add("", "模拟量数据", 19, 19);

                    测距工具.Nodes.Add("", "数字量数据", 19, 19);
                }
                //展示

                //动作融合
                TreeNode 动作融合 = tvw_tools.Nodes.Add("", "动作融合", 0, 0);
                {
                    动作融合.Nodes.Add("", "交叉螺旋", 40, 40);
                    动作融合.Nodes.Add("", "螺旋", 41, 41);
                    动作融合.Nodes.Add("", "圆", 42, 42);
                    动作融合.Nodes.Add("", "正方形", 43, 43);
                }

                TreeNode 自定义方法 = tvw_tools.Nodes.Add("", "自定义方法集合", 0, 0);
                {
                    自定义方法.Nodes.Add("", "自定义方法", 40, 40);
                    自定义方法.Nodes.Add("", "自定义方法2", 40, 40);
                    自定义方法.Nodes.Add("", "自定义方法3", 40, 40);
                    自定义方法.Nodes.Add("", "自定义方法4", 40, 40);
                }
                TreeNode 子程序 = tvw_tools.Nodes.Add("", "子程序页", 0, 0);
                {
                    子程序.Nodes.Add("", "子程序", 40, 40);

                }
                //默认展开第一个图像相关节点
                this.tvw_tools.Nodes[0].Expand();

                try
                {
                    #region 图像处理
                    TreeNode imageAcaquisitionNode = CCD_tools.Nodes.Add("", "图像处理", 0, 0);
                    {
                        imageAcaquisitionNode.Nodes.Add("", ImageTool.Tool.采集图像.ToString(), 2, 2);
                        imageAcaquisitionNode.Nodes.Add("", ImageTool.Tool.存储图像.ToString(), 3, 3);
                        TreeNode preconceptionNode = imageAcaquisitionNode.Nodes.Add("", "预处理图像", 0, 0);
                        {
                            preconceptionNode.Nodes.Add("", ImageTool.Tool.增强图像.ToString(), 12, 12);
                            preconceptionNode.Nodes.Add("", ImageTool.Tool.平滑图像.ToString(), 13, 13);
                            preconceptionNode.Nodes.Add("", ImageTool.Tool.性线收缩图像.ToString(), 31, 31);
                            preconceptionNode.Nodes.Add("", ImageTool.Tool.均值滤波图像.ToString(), 13, 13);
                            preconceptionNode.Nodes.Add("", ImageTool.Tool.中值滤波图像.ToString(), 13, 13);
                            preconceptionNode.Nodes.Add("", ImageTool.Tool.顶帽处理图像.ToString(), 13, 13);
                            preconceptionNode.Nodes.Add("", ImageTool.Tool.投影图像.ToString(), 9, 9);
                            preconceptionNode.Nodes.Add("", ImageTool.Tool.旋转图像.ToString(), 26, 26);
                            preconceptionNode.Nodes.Add("", ImageTool.Tool.极坐标变换图像.ToString(), 32, 32);
                            preconceptionNode.Nodes.Add("", ImageTool.Tool.取反图像.ToString(), 13, 13);
                            preconceptionNode.Nodes.Add("", ImageTool.Tool.补正图像.ToString(), 26, 26);
                            preconceptionNode.Nodes.Add("", ImageTool.Tool.彩色转HSV图像.ToString(), 11, 11);
                        }
                    }
                    #endregion
                    #region 图像定位
                    TreeNode imageFixPosition = CCD_tools.Nodes.Add("", "匹配定位", 0, 0);
                    {
                        imageFixPosition.Nodes.Add("", ImageTool.Tool.形状模板匹配.ToString(), 5, 5);
                        imageFixPosition.Nodes.Add("", ImageTool.Tool.NCC匹配.ToString(), 5, 5);
                        imageFixPosition.Nodes.Add("", ImageTool.Tool.位置定位.ToString(), 6, 6);
                    }
                    #endregion
                    #region 图像标定
                    TreeNode imageCalibration = CCD_tools.Nodes.Add("", "图像坐标变换标定", 0, 0);
                    {
                        imageCalibration.Nodes.Add("", ImageTool.Tool.九点标定.ToString(), 7, 7);
                    }
                    #endregion
                    #region 阈值分割统计
                    TreeNode imageThreshold = CCD_tools.Nodes.Add("", "阈值分割统计", 0, 0);
                    {
                        imageThreshold.Nodes.Add("", ImageTool.Tool.斑点分析.ToString(), 30, 30);
                    }
                    #endregion
                    #region 测量
                    TreeNode imageMesuer = CCD_tools.Nodes.Add("", "测量", 0, 0);
                    {
                        imageMesuer.Nodes.Add("", ImageTool.Tool.卡尺测量.ToString(), 16, 16);
                        imageMesuer.Nodes.Add("", ImageTool.Tool.找线测量.ToString(), 19, 19);
                        imageMesuer.Nodes.Add("", ImageTool.Tool.找边测量.ToString(), 19, 19);
                        imageMesuer.Nodes.Add("", ImageTool.Tool.找圆测量.ToString(), 18, 18);
                        imageMesuer.Nodes.Add("", ImageTool.Tool.找方向矩形测量.ToString(), 15, 15);
                        imageMesuer.Nodes.Add("", ImageTool.Tool.找顶点测量.ToString(), 29, 29);
                        imageMesuer.Nodes.Add("", ImageTool.Tool.点到点测量.ToString(), 21, 21);
                        imageMesuer.Nodes.Add("", ImageTool.Tool.点到线测量.ToString(), 20, 20);
                        imageMesuer.Nodes.Add("", ImageTool.Tool.水平夹角测量.ToString(), 14, 14);
                        imageMesuer.Nodes.Add("", ImageTool.Tool.两线交点测量.ToString(), 14, 14);
                        imageMesuer.Nodes.Add("", ImageTool.Tool.两线间距测量.ToString(), 22, 22);
                        imageMesuer.Nodes.Add("", ImageTool.Tool.两线夹角测量.ToString(), 14, 14);

                    }
                    #endregion
                    #region 图像检测
                    TreeNode imageTest = CCD_tools.Nodes.Add("", "图像识别检测", 0, 0);
                    {

                        imageTest.Nodes.Add("", ImageTool.Tool.二维码识别.ToString(), 23, 23);
                        imageTest.Nodes.Add("", ImageTool.Tool.条形码识别.ToString(), 24, 24);
                        imageTest.Nodes.Add("", ImageTool.Tool.字符识别检测.ToString(), 25, 25);
                        imageTest.Nodes.Add("", ImageTool.Tool.颜色抽取检测.ToString(), 10, 10);

                    }

                    TreeNode imageSurfaceTest = CCD_tools.Nodes.Add("", "图像外观检测", 0, 0);
                    {
                        imageSurfaceTest.Nodes.Add("", ImageTool.Tool.划痕提取检测.ToString(), 1, 1);
                        imageSurfaceTest.Nodes.Add("", ImageTool.Tool.瑕疵提取检测.ToString(), 1, 1);
                        imageSurfaceTest.Nodes.Add("", ImageTool.Tool.脏污提取检测.ToString(), 1, 1);
                        imageSurfaceTest.Nodes.Add("", ImageTool.Tool.差异比较检测.ToString(), 1, 1);
                        imageSurfaceTest.Nodes.Add("", ImageTool.Tool.焊点检测.ToString(), 1, 1);

                    }
                    #endregion
                    #region 图像区域形态处理
                    TreeNode imageMorphology = CCD_tools.Nodes.Add("", "图像形态处理", 0, 0);
                    {
                        imageMorphology.Nodes.Add("", ImageTool.Tool.区域形态处理.ToString(), 28, 28);
                    }
                    #endregion
                    #region 图像脚本
                    TreeNode imageScript = CCD_tools.Nodes.Add("", "图像视觉脚本", 0, 0);
                    {
                        imageScript.Nodes.Add("", ImageTool.Tool.视觉脚本.ToString(), 1, 1);
                    }
                    #endregion
                }
                catch
                {
                }

                //默认展开第一个图像相关节点
                this.CCD_tools.Nodes[0].Expand();
            }
            catch (Exception ex)
            {
            }

        }
        private void tsb_createJob_Click(object sender, EventArgs e)
        {
            if (textBoxHardWareName.Text == "")
            {
                MessageBox.Show("请输入流程名");
                return;
            }

            else
            {
                try
                {
                    if (!Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].dicFlowData.ContainsKey(textBoxHardWareName.Text))
                    {
                        string path = 路径.Text + "\\" + textBoxHardWareName.Text + ".xffp";
                        if (!File.Exists(path))
                        {
                            File.Create(path);
                        }

                        RunFlow _FlowChar_Control = new RunFlow();
                        _FlowChar_Control.RunFlowData_ControlDataName = textBoxHardWareName.Text;
                        _FlowChar_Control.xmlsPath = path;
                        Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].ListFlowData.Add(_FlowChar_Control);
                        Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].dicFlowData.Add(textBoxHardWareName.Text, _FlowChar_Control);

                        tool = new List<ImageTool>();
                        LoadData._ImageToolRun.Add(textBoxHardWareName.Text, tool);

                        int idx = dgv_deviceList.Rows.Add();
                        dgv_deviceList.Rows[idx].Tag = textBoxHardWareName.Text;
                        this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                        dgv_deviceList.Rows[idx].Height = 30;
                        dgv_deviceList.Rows[idx].Cells[0].Value = textBoxHardWareName.Text;

                        //dgv_deviceList.Rows[idx].Cells[1].Value = _FlowChar_Control.FlowChar_ControlDataName.ToString();
                        //dgv_deviceList.Rows[idx].Cells[2].Value = _FlowChar_Control.FlowChar_ControlDataTpye.ToString();

                    }
                }
                catch
                {
                }

            }
        }
        TreeNode selectedNode = new TreeNode();
        TreeNode __selectedNode = new TreeNode();
        string[] str;
        public void NodeClick(string type, ImageTool it)
        {
            if (Program.bAuto)
            {
                return;
            }
            Properties.Settings.Default.流程更改标志 = true;
            int idx = 0;
            switch (type)
            {
                case "脉冲输出":
                    OutPut_Puse = new OutPut_Puse();
                    OutPut_Puse.FlowChar_StepControlType = "脉冲输出";
                    OutPut_Puse.FlowChar_StepControlName = "脉冲输出";
                    if (it != null)
                        OutPut_Puse = (OutPut_Puse)it;
                    OutPut_Puse._Delay = 1;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, OutPut_Puse, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "脉冲输出";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "脉冲输出";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "脉冲输出";
                        //步骤编号
                        OutPut_Puse.FlowChar_StepControlNum = indexSelectedItem;
                        OutPut_Puse.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, OutPut_Puse, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();

                        dgv_Items.Rows[idx].Tag = "脉冲输出";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "脉冲输出";
                        dgv_Items.Rows[idx].Cells[2].Value = "脉冲输出";
                        //步骤编号
                        OutPut_Puse.FlowChar_StepControlNum = idx;
                        OutPut_Puse.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "输出":
                    _OutPut_ = new OutPut();
                    _OutPut_.FlowChar_StepControlType = "输出";
                    _OutPut_.FlowChar_StepControlName = "输出";
                    if (it != null)
                        _OutPut_ = (OutPut)it;
                    //_OutPut_._Delay = 1;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    //EditBLL.Add(tool, _OutPut_, str);
                    //LoadData._ImageToolRun[流程Name.Text] = tool;

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _OutPut_, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "输出";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "输出";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "输出";
                        //步骤编号
                        _OutPut_.FlowChar_StepControlNum = indexSelectedItem;
                        _OutPut_.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();

                    }
                    else
                    {
                        EditBLL.Add(tool, _OutPut_, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;

                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "输出";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "输出";
                        dgv_Items.Rows[idx].Cells[2].Value = "输出";
                        //步骤编号
                        _OutPut_.FlowChar_StepControlNum = idx;
                        _OutPut_.FlowChar_StepControlLoop = idx;


                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "先输出后延时":
                    _F_OutPut_DeeDelay = new F_OutPut_DeeDelay();
                    _F_OutPut_DeeDelay.FlowChar_StepControlType = "先输出后延时";
                    _F_OutPut_DeeDelay.FlowChar_StepControlName = "先输出后延时";
                    if (it != null)
                        _F_OutPut_DeeDelay = (F_OutPut_DeeDelay)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    {
                    }
                    else
                    {
                    }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _F_OutPut_DeeDelay, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "先输出后延时";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "先输出后延时";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "先输出后延时";
                        //步骤编号
                        _F_OutPut_DeeDelay.FlowChar_StepControlNum = indexSelectedItem;
                        _F_OutPut_DeeDelay.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _F_OutPut_DeeDelay, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "先输出后延时";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "先输出后延时";
                        dgv_Items.Rows[idx].Cells[2].Value = "先输出后延时";
                        //步骤编号
                        _F_OutPut_DeeDelay.FlowChar_StepControlNum = idx;
                        _F_OutPut_DeeDelay.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "先延时后输出":
                    _F_Delay_DeeOutPut = new F_Delay_DeeOutPut();
                    _F_Delay_DeeOutPut.FlowChar_StepControlType = "先延时后输出";
                    _F_Delay_DeeOutPut.FlowChar_StepControlName = "先延时后输出";
                    if (it != null)
                        _F_Delay_DeeOutPut = (F_Delay_DeeOutPut)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _F_Delay_DeeOutPut, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "先延时后输出";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "先延时后输出";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "先延时后输出";
                        //步骤编号
                        _F_Delay_DeeOutPut.FlowChar_StepControlNum = indexSelectedItem;
                        _F_Delay_DeeOutPut.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _F_Delay_DeeOutPut, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "先延时后输出";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "先延时后输出";
                        dgv_Items.Rows[idx].Cells[2].Value = "先延时后输出";
                        //步骤编号
                        _F_Delay_DeeOutPut.FlowChar_StepControlNum = idx;
                        _F_Delay_DeeOutPut.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "输入检测":
                    _Check_INPUT = new Check_INPUT();
                    _Check_INPUT.FlowChar_StepControlType = "输入检测";
                    _Check_INPUT.FlowChar_StepControlName = "输入检测";
                    if (it != null)
                        _Check_INPUT = (Check_INPUT)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _Check_INPUT, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "输入检测";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "输入检测";
                        //dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "输入检测";
                        //步骤编号
                        _Check_INPUT.FlowChar_StepControlNum = indexSelectedItem;
                        _Check_INPUT.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _Check_INPUT, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "输入检测";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "输入检测";
                        dgv_Items.Rows[idx].Cells[2].Value = "输入检测";
                        //步骤编号
                        _Check_INPUT.FlowChar_StepControlNum = idx;
                        _Check_INPUT.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "LOOPSTART":

                    break;

                case "LOOPSTOP":

                    break;
                case "数据检验":

                    break;
                case "数据赋值":

                    break;
                case "数据过站":

                    break;
                case "数据获取":

                    break;
                case "通过MES数据获取":

                    break;
                case "MES数据存储":

                    break;
                case "循环":

                    break;
                case "分支":

                    break;

                case "PLC设置":

                    break;
                case "数据写入":

                    break;
                case "数据读取":

                    break;
                case "数据展示":

                    break;

                case "两轴圆弧插补":
                    _ArcXYC = new ArcXYC();
                    _ArcXYC.FlowChar_StepControlType = "两轴圆弧插补";
                    _ArcXYC.FlowChar_StepControlName = "两轴圆弧插补";
                    if (it != null)
                        _ArcXYC = (ArcXYC)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];

                    if (插入工具.Text == "插入")
                    { }
                    else
                    {
                    }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _ArcXYC, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "两轴圆弧插补";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "两轴圆弧插补";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "两轴圆弧插补";
                        //步骤编号
                        _ArcXYC.FlowChar_StepControlNum = indexSelectedItem;
                        _ArcXYC.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _ArcXYC, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "两轴圆弧插补";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "两轴圆弧插补";
                        dgv_Items.Rows[idx].Cells[2].Value = "两轴圆弧插补";
                        //步骤编号
                        _ArcXYC.FlowChar_StepControlNum = idx;
                        _ArcXYC.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;

                    }

                    break;
                case "两轴直线插补":
                    _LnXY = new LnXY();
                    _LnXY.FlowChar_StepControlType = "两轴直线插补";
                    _LnXY.FlowChar_StepControlName = "两轴直线插补";
                    if (it != null)
                        _LnXY = (LnXY)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _LnXY, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "两轴直线插补";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "两轴直线插补";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "两轴直线插补";
                        //步骤编号
                        _LnXY.FlowChar_StepControlNum = indexSelectedItem;
                        _LnXY.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _LnXY, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "两轴直线插补";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "两轴直线插补";
                        dgv_Items.Rows[idx].Cells[2].Value = "两轴直线插补";
                        //步骤编号
                        _LnXY.FlowChar_StepControlNum = idx;
                        _LnXY.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "三轴螺旋插补":

                    break;
                case "三轴直线插补":
                    _LnXYZ = new LnXYZ();
                    _LnXYZ.FlowChar_StepControlType = "三轴直线插补";
                    _LnXYZ.FlowChar_StepControlName = "三轴直线插补";
                    if (it != null)
                        _LnXYZ = (LnXYZ)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _LnXYZ, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "三轴直线插补";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "三轴直线插补";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "三轴直线插补";
                        //步骤编号
                        _LnXYZ.FlowChar_StepControlNum = indexSelectedItem;
                        _LnXYZ.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _LnXYZ, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "三轴直线插补";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "三轴直线插补";
                        dgv_Items.Rows[idx].Cells[2].Value = "三轴直线插补";
                        //步骤编号
                        _LnXYZ.FlowChar_StepControlNum = idx;
                        _LnXYZ.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "四轴直线插补":
                    _LnXYZA = new LnXYZA();
                    _LnXYZA.FlowChar_StepControlType = "四轴直线插补";
                    _LnXYZA.FlowChar_StepControlName = "四轴直线插补";
                    if (it != null)
                        _LnXYZA = (LnXYZA)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _LnXYZA, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "四轴直线插补";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "四轴直线插补";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "四轴直线插补";
                        //步骤编号
                        _LnXYZA.FlowChar_StepControlNum = indexSelectedItem;
                        _LnXYZA.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _LnXYZA, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "四轴直线插补";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "四轴直线插补";
                        dgv_Items.Rows[idx].Cells[2].Value = "四轴直线插补";
                        //步骤编号
                        _LnXYZA.FlowChar_StepControlNum = idx;
                        _LnXYZA.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "工位互锁":

                    break;
                case "缓存区控制列表":
                    _BufferArea = new BufferArea();
                    _BufferArea.FlowChar_StepControlType = "缓存区控制列表";
                    _BufferArea.FlowChar_StepControlName = "缓存区控制列表";
                    if (it != null)
                        _BufferArea = (BufferArea)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _BufferArea, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "缓存区控制列表";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "缓存区控制列表";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "缓存区控制列表";
                        //步骤编号
                        _BufferArea.FlowChar_StepControlNum = indexSelectedItem;
                        _BufferArea.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _BufferArea, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "缓存区控制列表";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "缓存区控制列表";
                        dgv_Items.Rows[idx].Cells[2].Value = "缓存区控制列表";
                        //步骤编号
                        _BufferArea.FlowChar_StepControlNum = idx;
                        _BufferArea.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "激光控制":
                    break;
                case "建立坐标系":
                    break;
                case "PY脚本":
                    _PYTool = new PYTool();
                    _PYTool.FlowChar_StepControlType = "PY脚本";
                    _PYTool.FlowChar_StepControlName = "PY脚本";
                    if (it != null)
                        _PYTool = (PYTool)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _PYTool, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "PY脚本";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "PY脚本";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "PY脚本";
                        //步骤编号
                        _PYTool.FlowChar_StepControlNum = indexSelectedItem;
                        _PYTool.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _PYTool, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "PY脚本";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "PY脚本";
                        dgv_Items.Rows[idx].Cells[2].Value = "PY脚本";
                        //步骤编号
                        _PYTool.FlowChar_StepControlNum = idx;
                        _PYTool.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "c#脚本":
                    _CodeEditTool = new CodeEditTool();
                    _CodeEditTool.FlowChar_StepControlType = "c#脚本";
                    _CodeEditTool.FlowChar_StepControlName = "c#脚本";
                    if (it != null)
                        _CodeEditTool = (CodeEditTool)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _CodeEditTool, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "c#脚本";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "c#脚本";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "c#脚本";
                        //步骤编号
                        _CodeEditTool.FlowChar_StepControlNum = indexSelectedItem;
                        _CodeEditTool.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _CodeEditTool, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "c#脚本";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "c#脚本";
                        dgv_Items.Rows[idx].Cells[2].Value = "c#脚本";
                        //步骤编号
                        _CodeEditTool.FlowChar_StepControlNum = idx;
                        _CodeEditTool.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "解除工位互锁":

                    break;
                case "数据组赋值":
                    _DataGroup = new DataGroup();
                    _DataGroup.FlowChar_StepControlType = "数据组赋值";
                    _DataGroup.FlowChar_StepControlName = "数据组赋值";
                    if (it != null)
                        _DataGroup = (DataGroup)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _DataGroup, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "数据组赋值";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "数据组赋值";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "数据组赋值";
                        //步骤编号
                        _DataGroup.FlowChar_StepControlNum = indexSelectedItem;
                        _DataGroup.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _DataGroup, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "数据组赋值";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "数据组赋值";
                        dgv_Items.Rows[idx].Cells[2].Value = "数据组赋值";
                        //步骤编号
                        _DataGroup.FlowChar_StepControlNum = idx;
                        _DataGroup.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "数据组检测":
                    _DataGroup = new DataGroup();
                    _DataGroup.FlowChar_StepControlType = "数据组检测";
                    _DataGroup.FlowChar_StepControlName = "数据组检测";
                    if (it != null)
                        _DataGroup = (DataGroup)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _DataGroup, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "数据组检测";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "数据组检测";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "数据组检测";
                        //步骤编号
                        _DataGroup.FlowChar_StepControlNum = indexSelectedItem;
                        _DataGroup.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _DataGroup, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "数据组检测";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "数据组检测";
                        dgv_Items.Rows[idx].Cells[2].Value = "数据组检测";
                        //步骤编号
                        _DataGroup.FlowChar_StepControlNum = idx;
                        _DataGroup.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "串口通讯发送命令":
                    _SerialPortSendData = new SerialPortSendData();
                    _SerialPortSendData.FlowChar_StepControlType = "串口通讯发送命令";
                    _SerialPortSendData.FlowChar_StepControlName = "串口通讯发送命令";
                    if (it != null)
                        _SerialPortSendData = (SerialPortSendData)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _SerialPortSendData, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "串口通讯发送命令";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "串口通讯发送命令";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "串口通讯发送命令";
                        //步骤编号
                        _SerialPortSendData.FlowChar_StepControlNum = indexSelectedItem;
                        _SerialPortSendData.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _SerialPortSendData, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "串口通讯发送命令";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "串口通讯发送命令";
                        dgv_Items.Rows[idx].Cells[2].Value = "串口通讯发送命令";
                        //步骤编号
                        _SerialPortSendData.FlowChar_StepControlNum = idx;
                        _SerialPortSendData.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "串口通讯接受指令":
                    _SerialPortResData = new SerialPortResData();
                    _SerialPortResData.FlowChar_StepControlType = "串口通讯接受指令";
                    _SerialPortResData.FlowChar_StepControlName = "串口通讯接受指令";
                    if (it != null)
                        _SerialPortResData = (SerialPortResData)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _SerialPortResData, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "串口通讯接受指令";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "串口通讯接受指令";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "串口通讯接受指令";
                        //步骤编号
                        _SerialPortResData.FlowChar_StepControlNum = indexSelectedItem;
                        _SerialPortResData.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _SerialPortResData, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "串口通讯接受指令";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "串口通讯接受指令";
                        dgv_Items.Rows[idx].Cells[2].Value = "串口通讯接受指令";
                        //步骤编号
                        _SerialPortResData.FlowChar_StepControlNum = idx;
                        _SerialPortResData.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "网络通讯发送命令":
                    ser_clSendData = new _ser_clSendData();
                    ser_clSendData.FlowChar_StepControlType = "网络通讯发送命令";
                    ser_clSendData.FlowChar_StepControlName = "网络通讯发送命令";
                    if (it != null)
                        ser_clSendData = (_ser_clSendData)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, ser_clSendData, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "网络通讯发送命令";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "网络通讯发送命令";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "网络通讯发送命令";
                        //步骤编号
                        ser_clSendData.FlowChar_StepControlNum = indexSelectedItem;
                        ser_clSendData.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, ser_clSendData, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "网络通讯发送命令";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "网络通讯发送命令";
                        dgv_Items.Rows[idx].Cells[2].Value = "网络通讯发送命令";
                        //步骤编号
                        ser_clSendData.FlowChar_StepControlNum = idx;
                        ser_clSendData.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "网络通讯接受指令":
                    ser_clResData = new _ser_clResData();
                    ser_clResData.FlowChar_StepControlType = "网络通讯接受指令";
                    ser_clResData.FlowChar_StepControlName = "网络通讯接受指令";
                    if (it != null)
                        ser_clResData = (_ser_clResData)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, ser_clResData, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "网络通讯接受指令";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "网络通讯接受指令";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "网络通讯接受指令";
                        //步骤编号
                        ser_clResData.FlowChar_StepControlNum = indexSelectedItem;
                        ser_clResData.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, ser_clResData, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "网络通讯接受指令";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "网络通讯接受指令";
                        dgv_Items.Rows[idx].Cells[2].Value = "网络通讯接受指令";
                        //步骤编号
                        ser_clResData.FlowChar_StepControlNum = idx;
                        ser_clResData.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "延时":
                    _DelayData = new DelayData();
                    _DelayData.FlowChar_StepControlType = "延时";
                    _DelayData.FlowChar_StepControlName = "延时";
                    if (it != null)
                        _DelayData = (DelayData)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _DelayData, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "延时";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "延时";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "延时";
                        //步骤编号
                        _DelayData.FlowChar_StepControlNum = indexSelectedItem;
                        _DelayData.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _DelayData, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "延时";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "延时";
                        dgv_Items.Rows[idx].Cells[2].Value = "延时";
                        //步骤编号
                        _DelayData.FlowChar_StepControlNum = idx;
                        _DelayData.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "单轴运动":
                    _Aixs_one_Ctron = new Aixs_one_Ctron();
                    _Aixs_one_Ctron.FlowChar_StepControlType = "单轴运动";
                    _Aixs_one_Ctron.FlowChar_StepControlName = "单轴运动";
                    if (it != null)
                        _Aixs_one_Ctron = (Aixs_one_Ctron)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _Aixs_one_Ctron, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "单轴运动";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "单轴运动";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "单轴运动";
                        //步骤编号
                        _Aixs_one_Ctron.FlowChar_StepControlNum = indexSelectedItem;
                        _Aixs_one_Ctron.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _Aixs_one_Ctron, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "单轴运动";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "单轴运动";
                        dgv_Items.Rows[idx].Cells[2].Value = "单轴运动";
                        //步骤编号
                        _Aixs_one_Ctron.FlowChar_StepControlNum = idx;
                        _Aixs_one_Ctron.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "缓存区插入其他":
                    _AddOtherBuff = new AddOtherBuff();
                    _AddOtherBuff.FlowChar_StepControlType = "缓存区插入其他";
                    _AddOtherBuff.FlowChar_StepControlName = "缓存区插入其他";
                    if (it != null)
                        _AddOtherBuff = (AddOtherBuff)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _AddOtherBuff, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "缓存区插入其他";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "缓存区插入其他";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "缓存区插入其他";
                        //步骤编号
                        _AddOtherBuff.FlowChar_StepControlNum = indexSelectedItem;
                        _AddOtherBuff.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _AddOtherBuff, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "缓存区插入其他";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "缓存区插入其他";
                        dgv_Items.Rows[idx].Cells[2].Value = "缓存区插入其他";
                        //步骤编号
                        _AddOtherBuff.FlowChar_StepControlNum = idx;
                        _AddOtherBuff.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "检测运动完成":
                    _CheckAixsRunFinish = new CheckAixsRunFinish();
                    _CheckAixsRunFinish.FlowChar_StepControlType = "检测运动完成";
                    _CheckAixsRunFinish.FlowChar_StepControlName = "检测运动完成";
                    if (it != null)
                        _CheckAixsRunFinish = (CheckAixsRunFinish)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _CheckAixsRunFinish, str);

                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "检测运动完成";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "检测运动完成";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "检测运动完成";
                        //步骤编号
                        _CheckAixsRunFinish.FlowChar_StepControlNum = indexSelectedItem;
                        _CheckAixsRunFinish.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _CheckAixsRunFinish, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "检测运动完成";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "检测运动完成";
                        dgv_Items.Rows[idx].Cells[2].Value = "检测运动完成";
                        //步骤编号
                        _CheckAixsRunFinish.FlowChar_StepControlNum = idx;
                        _CheckAixsRunFinish.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;

                case "多轴运动":
                    _Aixs_more_Ctron = new Aixs_more_Ctron();
                    _Aixs_more_Ctron.FlowChar_StepControlType = "多轴运动";
                    _Aixs_more_Ctron.FlowChar_StepControlName = "多轴运动";
                    if (it != null)
                        _Aixs_more_Ctron = (Aixs_more_Ctron)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _Aixs_more_Ctron, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "多轴运动";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "多轴运动";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "多轴运动";
                        //步骤编号
                        _Aixs_more_Ctron.FlowChar_StepControlNum = indexSelectedItem;
                        _Aixs_more_Ctron.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _Aixs_more_Ctron, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "多轴运动";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "多轴运动";
                        dgv_Items.Rows[idx].Cells[2].Value = "多轴运动";
                        //步骤编号
                        _Aixs_more_Ctron.FlowChar_StepControlNum = idx;
                        _Aixs_more_Ctron.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;

                case "多轴运动不检测运动完成":

                    break;
                case "条件判断调子流程":

                    break;


                case "多轴运动检测运动完成":


                    break;
                case "多轴运动同时输出IO":

                    break;

                case "多轴运动完成后输出IO":

                    break;


                case "算术":
                    //_AddOtherBuff = new AddOtherBuff();
                    //_AddOtherBuff.FlowChar_StepControlType = "缓存区插入其他";
                    //_AddOtherBuff.FlowChar_StepControlName = "缓存区插入其他";
                    //if (it != null)
                    //    _AddOtherBuff = (AddOtherBuff)it;
                    //str = new string[] { "e", "w", "", "NG", "0ms" };
                    //tool = LoadData._ImageToolRun[流程Name.Text];
                    //if (插入工具.Text == "插入")
                    //{ }
                    //else { }
                    //if (插入工具.Text == "插入")
                    //{
                    //    EditBLL.Insert(dgv_Items, tool, _AddOtherBuff, str);
                    //    int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                    //    dgv_Items.Rows.Insert(indexSelectedItem);
                    //    dgv_Items.Rows[indexSelectedItem].Tag = "缓存区插入其他";
                    //    dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                    //    dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "缓存区插入其他";
                    //    dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "缓存区插入其他";
                    //    //步骤编号
                    //    _AddOtherBuff.FlowChar_StepControlNum = indexSelectedItem;
                    //    _AddOtherBuff.FlowChar_StepControlLoop = indexSelectedItem;
                    //    InserSor();
                    //}
                    //else
                    //{
                    //    EditBLL.Add(tool, _AddOtherBuff, str);
                    //    LoadData._ImageToolRun[流程Name.Text] = tool;
                    //    idx = dgv_Items.Rows.Add();
                    //    dgv_Items.Rows[idx].Tag = "缓存区插入其他";
                    //    dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                    //    dgv_Items.Rows[idx].Cells[1].Value = "缓存区插入其他";
                    //    dgv_Items.Rows[idx].Cells[2].Value = "缓存区插入其他";
                    //    //步骤编号
                    //    _AddOtherBuff.FlowChar_StepControlNum = idx;
                    //    _AddOtherBuff.FlowChar_StepControlLoop = idx;

                    //    dgv_Items.Rows[idx].Selected = true;
                    //    dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    //}

                    break;

                case "数据分析":

                    break;

                case "条件判断步骤跳转":
                    _LogicalJump = new LogicalJump();
                    _LogicalJump.FlowChar_StepControlType = "数据分析与";
                    _LogicalJump.FlowChar_StepControlName = "数据分析与";
                    if (it != null)
                        _LogicalJump = (LogicalJump)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _LogicalJump, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "数据分析与";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "数据分析与";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "数据分析与";
                        //步骤编号
                        _LogicalJump.FlowChar_StepControlNum = indexSelectedItem;
                        _LogicalJump.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _LogicalJump, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "数据分析与";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "数据分析与";
                        dgv_Items.Rows[idx].Cells[2].Value = "数据分析与";
                        //步骤编号
                        _LogicalJump.FlowChar_StepControlNum = idx;
                        _LogicalJump.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "与":
                    _And = new And();
                    _And.FlowChar_StepControlType = "数据分析与";
                    _And.FlowChar_StepControlName = "数据分析与";
                    if (it != null)
                        _And = (And)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _And, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "数据分析与";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "数据分析与";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "数据分析与";
                        //步骤编号
                        _And.FlowChar_StepControlNum = indexSelectedItem;
                        _And.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _And, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "数据分析与";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "数据分析与";
                        dgv_Items.Rows[idx].Cells[2].Value = "数据分析与";
                        //步骤编号
                        _And.FlowChar_StepControlNum = idx;
                        _And.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "或":
                    _Or = new Or();
                    _Or.FlowChar_StepControlType = "数据分析或";
                    _Or.FlowChar_StepControlName = "数据分析或";
                    if (it != null)
                        _Or = (Or)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _Or, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "数据分析或";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "数据分析或";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "数据分析或";
                        //步骤编号
                        _Or.FlowChar_StepControlNum = indexSelectedItem;
                        _Or.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _Or, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "数据分析或";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "数据分析或";
                        dgv_Items.Rows[idx].Cells[2].Value = "数据分析或";
                        //步骤编号
                        _Or.FlowChar_StepControlNum = idx;
                        _Or.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "异或":
                    _XOr = new XOr();
                    _XOr.FlowChar_StepControlType = "数据分析异或";
                    _XOr.FlowChar_StepControlName = "数据分析异或";
                    if (it != null)
                        _XOr = (XOr)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _XOr, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "数据分析异或";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "数据分析异或";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "数据分析异或";
                        //步骤编号
                        _XOr.FlowChar_StepControlNum = indexSelectedItem;
                        _XOr.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _XOr, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "数据分析异或";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "数据分析异或";
                        dgv_Items.Rows[idx].Cells[2].Value = "数据分析异或";
                        //步骤编号
                        _XOr.FlowChar_StepControlNum = idx;
                        _XOr.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "非":
                    _Neg = new Neg();
                    _Neg.FlowChar_StepControlType = "数据分析非";
                    _Neg.FlowChar_StepControlName = "数据分析非";
                    if (it != null)
                        _Neg = (Neg)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _Neg, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "数据分析非";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "数据分析非";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "数据分析非";
                        //步骤编号
                        _Neg.FlowChar_StepControlNum = indexSelectedItem;
                        _Neg.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _Neg, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "数据分析非";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "数据分析非";
                        dgv_Items.Rows[idx].Cells[2].Value = "数据分析非";
                        //步骤编号
                        _Neg.FlowChar_StepControlNum = idx;
                        _Neg.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "数据分析或":

                    break;

                case "数据分析非":

                    break;
                case "数据分析异或":

                    break;
                case "展示":

                    break;
                case "获取圆心坐标":
                    _CamerGetR_Center = new CamerGetR_Center();
                    _CamerGetR_Center.FlowChar_StepControlType = "获取圆心坐标";
                    _CamerGetR_Center.FlowChar_StepControlName = "获取圆心坐标";
                    if (it != null)
                        _CamerGetR_Center = (CamerGetR_Center)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _CamerGetR_Center, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "获取圆心坐标";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "获取圆心坐标";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "获取圆心坐标";
                        //步骤编号
                        _CamerGetR_Center.FlowChar_StepControlNum = indexSelectedItem;
                        _CamerGetR_Center.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _CamerGetR_Center, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "获取圆心坐标";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "获取圆心坐标";
                        dgv_Items.Rows[idx].Cells[2].Value = "获取圆心坐标";
                        //步骤编号
                        _CamerGetR_Center.FlowChar_StepControlNum = idx;
                        _CamerGetR_Center.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;

                case "相机补偿":
                    _CamerCompensation_Center = new CamerCompensation_Center();
                    _CamerCompensation_Center.FlowChar_StepControlType = "相机补偿";
                    _CamerCompensation_Center.FlowChar_StepControlName = "相机补偿";
                    if (it != null)
                        _CamerCompensation_Center = (CamerCompensation_Center)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _CamerCompensation_Center, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "相机补偿";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "相机补偿";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "相机补偿";
                        //步骤编号
                        _CamerCompensation_Center.FlowChar_StepControlNum = indexSelectedItem;
                        _CamerCompensation_Center.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _CamerCompensation_Center, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "相机补偿";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "相机补偿";
                        dgv_Items.Rows[idx].Cells[2].Value = "相机补偿";
                        //步骤编号
                        _CamerCompensation_Center.FlowChar_StepControlNum = idx;
                        _CamerCompensation_Center.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "焊后拍照检测":
                    _WeldedCheck = new WeldedCheck();
                    _WeldedCheck.FlowChar_StepControlType = "焊后拍照检测";
                    _WeldedCheck.FlowChar_StepControlName = "焊后拍照检测";
                    if (it != null)
                        _WeldedCheck = (WeldedCheck)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _WeldedCheck, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "焊后拍照检测";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "焊后拍照检测";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "焊后拍照检测";
                        //步骤编号
                        _WeldedCheck.FlowChar_StepControlNum = indexSelectedItem;
                        _WeldedCheck.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _WeldedCheck, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "焊后拍照检测";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "焊后拍照检测";
                        dgv_Items.Rows[idx].Cells[2].Value = "焊后拍照检测";
                        //步骤编号
                        _WeldedCheck.FlowChar_StepControlNum = idx;
                        _WeldedCheck.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "数字量数据":
                    _DigitalMea_Height = new DigitalMea_Height();
                    _DigitalMea_Height.FlowChar_StepControlType = "数字量数据";
                    _DigitalMea_Height.FlowChar_StepControlName = "数字量数据";
                    if (it != null)
                        _DigitalMea_Height = (DigitalMea_Height)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _DigitalMea_Height, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "数字量数据";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "数字量数据";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "数字量数据";
                        //步骤编号
                        _DigitalMea_Height.FlowChar_StepControlNum = indexSelectedItem;
                        _DigitalMea_Height.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _DigitalMea_Height, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "数字量数据";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "数字量数据";
                        dgv_Items.Rows[idx].Cells[2].Value = "数字量数据";
                        //步骤编号
                        _DigitalMea_Height.FlowChar_StepControlNum = idx;
                        _DigitalMea_Height.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "圆":
                    _Cir = new Cir();
                    _Cir.FlowChar_StepControlType = "圆";
                    _Cir.FlowChar_StepControlName = "圆";
                    if (it != null)
                        _Cir = (Cir)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _Cir, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "圆";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "圆";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "圆";
                        //步骤编号
                        _Cir.FlowChar_StepControlNum = indexSelectedItem;
                        _Cir.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _Cir, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "圆";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "圆";
                        dgv_Items.Rows[idx].Cells[2].Value = "圆";
                        //步骤编号
                        _Cir.FlowChar_StepControlNum = idx;
                        _Cir.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "正方形":
                    _Dimetric = new Dimetric();
                    _Dimetric.FlowChar_StepControlType = "正方形";
                    _Dimetric.FlowChar_StepControlName = "正方形";
                    if (it != null)
                        _Dimetric = (Dimetric)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];

                    if (插入工具.Text == "插入")
                    { }
                    else { }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _Dimetric, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "正方形";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "正方形";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "正方形";
                        //步骤编号
                        _Dimetric.FlowChar_StepControlNum = indexSelectedItem;
                        _Dimetric.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _Dimetric, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "正方形";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "正方形";
                        dgv_Items.Rows[idx].Cells[2].Value = "正方形";
                        //步骤编号
                        _Dimetric.FlowChar_StepControlNum = idx;
                        _Dimetric.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "交叉螺旋":
                    _Cir = new Cir();
                    _Cir.FlowChar_StepControlType = "交叉螺旋";
                    _Cir.FlowChar_StepControlName = "交叉螺旋";
                    if (it != null)
                        _Cir = (Cir)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }

                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _Cir, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "交叉螺旋";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "交叉螺旋";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "交叉螺旋";
                        //步骤编号
                        _Cir.FlowChar_StepControlNum = indexSelectedItem;
                        _Cir.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _Cir, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "交叉螺旋";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "交叉螺旋";
                        dgv_Items.Rows[idx].Cells[2].Value = "交叉螺旋";
                        //步骤编号
                        _Cir.FlowChar_StepControlNum = idx;
                        _Cir.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "螺旋":
                    _Cir = new Cir();
                    _Cir.FlowChar_StepControlType = "螺旋";
                    _Cir.FlowChar_StepControlName = "螺旋";
                    if (it != null)
                        _Cir = (Cir)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _Cir, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "螺旋";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "螺旋";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "螺旋";
                        //步骤编号
                        _Cir.FlowChar_StepControlNum = indexSelectedItem;
                        _Cir.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _Cir, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "螺旋";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "螺旋";
                        dgv_Items.Rows[idx].Cells[2].Value = "螺旋";
                        //步骤编号
                        _Cir.FlowChar_StepControlNum = idx;
                        _Cir.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;

                case "自定义方法":
                    _DefintionFun = new DefintionFun();
                    _DefintionFun.FlowChar_StepControlType = "自定义方法";
                    _DefintionFun.FlowChar_StepControlName = "自定义方法";
                    if (it != null)
                        _DefintionFun = (DefintionFun)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _DefintionFun, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "自定义方法";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "自定义方法";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "自定义方法";
                        //步骤编号
                        _DefintionFun.FlowChar_StepControlNum = indexSelectedItem;
                        _DefintionFun.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _DefintionFun, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "自定义方法";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "自定义方法";
                        dgv_Items.Rows[idx].Cells[2].Value = "自定义方法";
                        //步骤编号
                        _DefintionFun.FlowChar_StepControlNum = idx;
                        _DefintionFun.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "多轴检测轴运动完成":
                    _Aixs_more_CtronRunFinish = new Aixs_more_CtronRunFinish();
                    _Aixs_more_CtronRunFinish.FlowChar_StepControlType = "多轴检测轴运动完成";
                    _Aixs_more_CtronRunFinish.FlowChar_StepControlName = "多轴检测轴运动完成";
                    if (it != null)
                        _Aixs_more_CtronRunFinish = (Aixs_more_CtronRunFinish)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _Aixs_more_CtronRunFinish, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "多轴检测轴运动完成";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "多轴检测轴运动完成";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "多轴检测轴运动完成";
                        //步骤编号
                        _Aixs_more_CtronRunFinish.FlowChar_StepControlNum = indexSelectedItem;
                        _Aixs_more_CtronRunFinish.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _Aixs_more_CtronRunFinish, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "多轴检测轴运动完成";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "多轴检测轴运动完成";
                        dgv_Items.Rows[idx].Cells[2].Value = "多轴检测轴运动完成";
                        //步骤编号
                        _Aixs_more_CtronRunFinish.FlowChar_StepControlNum = idx;
                        _Aixs_more_CtronRunFinish.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;
                case "子程序":
                    _CallSubroutine = new CallSubroutine();
                    _CallSubroutine.FlowChar_StepControlType = "子程序";
                    _CallSubroutine.FlowChar_StepControlName = "子程序";
                    if (it != null)
                        _CallSubroutine = (CallSubroutine)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    { }
                    else { }
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _CallSubroutine, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "子程序";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "子程序";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "子程序";
                        //步骤编号
                        _CallSubroutine.FlowChar_StepControlNum = indexSelectedItem;
                        _CallSubroutine.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {
                        EditBLL.Add(tool, _CallSubroutine, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "子程序";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "子程序";
                        dgv_Items.Rows[idx].Cells[2].Value = "子程序";
                        //步骤编号
                        _CallSubroutine.FlowChar_StepControlNum = idx;
                        _CallSubroutine.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }

                    break;

                case "自定义方法2":
                    _DefintionFun2 = new DefintionFun2();
                    _DefintionFun2.FlowChar_StepControlType = "自定义方法2";
                    _DefintionFun2.FlowChar_StepControlName = "自定义方法2";
                    if (it != null)
                        _DefintionFun2 = (DefintionFun2)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _DefintionFun2, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "自定义方法2";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "自定义方法2";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "自定义方法2";
                        //步骤编号
                        _DefintionFun2.FlowChar_StepControlNum = indexSelectedItem;
                        _DefintionFun2.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {

                        EditBLL.Add(tool, _DefintionFun2, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "自定义方法2";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "自定义方法2";
                        dgv_Items.Rows[idx].Cells[2].Value = "自定义方法2";
                        //步骤编号
                        _DefintionFun2.FlowChar_StepControlNum = idx;
                        _DefintionFun2.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }
                    break;

                case "自定义方法3":
                    _DefintionFun3 = new DefintionFun3();
                    _DefintionFun3.FlowChar_StepControlType = "自定义方法3";
                    _DefintionFun3.FlowChar_StepControlName = "自定义方法3";
                    if (it != null)
                        _DefintionFun3 = (DefintionFun3)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _DefintionFun3, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "自定义方法3";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "自定义方法3";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "自定义方法3";
                        //步骤编号
                        _DefintionFun3.FlowChar_StepControlNum = indexSelectedItem;
                        _DefintionFun3.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {

                        EditBLL.Add(tool, _DefintionFun3, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "自定义方法3";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "自定义方法3";
                        dgv_Items.Rows[idx].Cells[2].Value = "自定义方法3";
                        //步骤编号
                        _DefintionFun3.FlowChar_StepControlNum = idx;
                        _DefintionFun3.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }
                    break;
                case "自定义方法4":
                    _DefintionFun4 = new DefintionFun4();
                    _DefintionFun4.FlowChar_StepControlType = "自定义方法4";
                    _DefintionFun4.FlowChar_StepControlName = "自定义方法4";
                    if (it != null)
                        _DefintionFun4= (DefintionFun4)it;
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    if (插入工具.Text == "插入")
                    {
                        EditBLL.Insert(dgv_Items, tool, _DefintionFun4, str);
                        int indexSelectedItem = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
                        dgv_Items.Rows.Insert(indexSelectedItem);
                        dgv_Items.Rows[indexSelectedItem].Tag = "自定义方法4";
                        dgv_Items.Rows[indexSelectedItem].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[indexSelectedItem].Cells[1].Value = "自定义方法4";
                        dgv_Items.Rows[indexSelectedItem].Cells[2].Value = "自定义方法4";
                        //步骤编号
                        _DefintionFun4.FlowChar_StepControlNum = indexSelectedItem;
                        _DefintionFun4.FlowChar_StepControlLoop = indexSelectedItem;
                        InserSor();
                    }
                    else
                    {

                        EditBLL.Add(tool, _DefintionFun4, str);
                        LoadData._ImageToolRun[流程Name.Text] = tool;
                        idx = dgv_Items.Rows.Add();
                        dgv_Items.Rows[idx].Tag = "自定义方法4";
                        dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                        dgv_Items.Rows[idx].Cells[1].Value = "自定义方法4";
                        dgv_Items.Rows[idx].Cells[2].Value = "自定义方法4";
                        //步骤编号
                        _DefintionFun4.FlowChar_StepControlNum = idx;
                        _DefintionFun4.FlowChar_StepControlLoop = idx;

                        dgv_Items.Rows[idx].Selected = true;
                        dgv_Items.FirstDisplayedScrollingRowIndex = idx;
                    }
                    break;
            }
        }
        private void dgv_deviceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ce = dgv_deviceList.Rows[e.RowIndex].Cells[0].Value.ToString();
            流程Name.Text = ce;
            AllPath = ce;
            dgv_Items.Rows.Clear();
            try
            {
                int count = 1;
                foreach (var item in LoadData._ImageToolRun[流程Name.Text])
                {
                    int idx = dgv_Items.Rows.Add();
                    dgv_Items.Rows[idx].Tag = textBoxHardWareName.Text;
                    this.dgv_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_Items.Rows[idx].Height = 30;
                    dgv_Items.Rows[idx].Cells[0].Value = (count).ToString();
                    try
                    {
                        dgv_Items.Rows[idx].Cells[1].Value = item.FlowChar_StepControlType;

                    }
                    catch (Exception ex)
                    {
                        dgv_Items.Rows[idx].Cells[1].Value = "";

                    }

                    try
                    {
                        dgv_Items.Rows[idx].Cells[2].Value = item.FlowChar_StepControlName;
                    }
                    catch (Exception ex)
                    {

                        dgv_Items.Rows[idx].Cells[2].Value = "";
                    }

                    count++;
                }
            }
            catch (Exception ex)
            {

            }

            for (int i = 0; i < Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].dicFlowData[流程Name.Text]._RunFlowData.Count; i++)
            {
                int idx = dgv_Items.Rows.Add();
                dgv_Items.Rows[idx].Tag = textBoxHardWareName.Text;
                this.dgv_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dgv_Items.Rows[idx].Height = 30;
                dgv_Items.Rows[idx].Cells[0].Value = (i + 1).ToString();
            }
        }

        private void dgv_deviceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tvw_tools_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selectedNode = tvw_tools.SelectedNode;
            NodeClick(selectedNode.Text, null);
        }
        public void InserSor()
        {
            int rowIndex = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
            dgv_Items.Rows.Clear();
            int count = 1;
            foreach (var item in LoadData._ImageToolRun[流程Name.Text])
            {
                int idx = dgv_Items.Rows.Add();
                dgv_Items.Rows[idx].Tag = textBoxHardWareName.Text;
                this.dgv_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dgv_Items.Rows[idx].Height = 30;
                dgv_Items.Rows[idx].Cells[0].Value = (count).ToString();
                //item.FlowChar_StepControlLoop = count - 1;
                item.FlowChar_StepControlNum = count - 1;
                try
                {
                    dgv_Items.Rows[idx].Cells[1].Value = item.FlowChar_StepControlType;
                }
                catch (Exception ex)
                {
                    dgv_Items.Rows[idx].Cells[1].Value = "";
                }
                try
                {
                    dgv_Items.Rows[idx].Cells[2].Value = item.FlowChar_StepControlName;
                }
                catch (Exception ex)
                {

                    dgv_Items.Rows[idx].Cells[2].Value = "";
                }
                count++;
            }


            //dgv_Items.Rows[rowIndex].Selected = false;
            dgv_Items.Rows[rowIndex - 1].Selected = true;

            dgv_Items.FirstDisplayedScrollingRowIndex = rowIndex - 1;
        }
        private void dgv_Items_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string Data =/* Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].dicFlowData[流程Name.Text]._RunFlowData[ChooseIndex - 1].FlowChar_StepControlType*/"";
            //dgv_Items
            int a = 0;
            int Bit = dgv_Items.CurrentRow.Index;
            string name = dgv_Items.Rows[Bit].Cells[1].Value.ToString();
            switch (name)
            {
                case "脉冲输出":
                    a = dgv_Items.CurrentRow.Index;
                    OutPut_PulseFrom OutPut_PulseFrom = new OutPut_PulseFrom();
                    OutPut_PulseFrom.ShowMesage(label1.Text, 流程Name.Text, a);

                    OutPut_PulseFrom.ShowDialog();

                    break;
                case "输出":
                    a = dgv_Items.CurrentRow.Index;
                    OutPutFrom _OutPutFrom = new OutPutFrom();
                    _OutPutFrom.ShowMesage(label1.Text, 流程Name.Text, a);

                    _OutPutFrom.ShowDialog();
                    break;
                case "先输出后延时":
                    a = dgv_Items.CurrentRow.Index;
                    F_OutPut_DDelayFrom F_OutPut_DDelayFrom = new F_OutPut_DDelayFrom();
                    F_OutPut_DDelayFrom.ShowMesage(label1.Text, 流程Name.Text, a);

                    F_OutPut_DDelayFrom.ShowDialog();
                    break;
                case "先延时后输出":
                    a = dgv_Items.CurrentRow.Index;
                    F_Delay_DeOutPutFrom F_Delay_DeOutPutFrom = new F_Delay_DeOutPutFrom();
                    F_Delay_DeOutPutFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    F_Delay_DeOutPutFrom.ShowDialog();
                    break;


                case "检测输入上升沿脉冲":

                    break;

                case "输入检测下降沿脉冲":

                    break;
                case "输入检测":
                    a = dgv_Items.CurrentRow.Index;
                    Check_INPUTFrom _Check_INPUTFrom = new Check_INPUTFrom();
                    _Check_INPUTFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _Check_INPUTFrom.ShowDialog();
                    break;
                case "输入检测后延时":

                    break;

                case "LOOPSTART":

                    break;

                case "LOOPSTOP":

                    break;
                case "数据检验":

                    break;
                case "数据赋值":

                    break;
                case "数据过站":

                    break;
                case "数据获取":

                    break;
                case "通过MES数据获取":

                    break;
                case "MES数据存储":

                    break;


                case "循环":

                    break;
                case "分支":

                    break;

                case "PLC设置":

                    break;
                case "数据写入":

                    break;
                case "数据读取":

                    break;
                case "条件判断步骤跳转":
                    a = dgv_Items.CurrentRow.Index;
                    LogicalJumpFrom _LogicalJumpFrom = new LogicalJumpFrom();
                    _LogicalJumpFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _LogicalJumpFrom.ShowDialog();
                    break;
                case "数据展示":

                    break;
                case "数据分析与":
                    a = dgv_Items.CurrentRow.Index;
                    AndFrom _AndFrom = new AndFrom();
                    _AndFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _AndFrom.ShowDialog();
                    break;
                case "数据分析或":
                    a = dgv_Items.CurrentRow.Index;
                    OrFrom _OrFrom = new OrFrom();
                    _OrFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _OrFrom.ShowDialog();
                    break;
                case "数据分析异或":
                    a = dgv_Items.CurrentRow.Index;
                    XOrFrom _XOrFrom = new XOrFrom();
                    _XOrFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _XOrFrom.ShowDialog();
                    break;
                case "数据分析非":
                    a = dgv_Items.CurrentRow.Index;
                    NegFrom _NegFrom = new NegFrom();
                    _NegFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _NegFrom.ShowDialog();
                    break;
                case "两轴圆弧插补":
                    a = dgv_Items.CurrentRow.Index;
                    ArcXYCFrom _ArcXYCFrom = new ArcXYCFrom();
                    _ArcXYCFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _ArcXYCFrom.ShowDialog();
                    break;
                case "两轴直线插补":

                    a = dgv_Items.CurrentRow.Index;
                    LnXYFrom _LnXYFrom = new LnXYFrom();
                    _LnXYFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _LnXYFrom.ShowDialog();
                    break;
                case "三轴螺旋插补":

                    break;
                case "三轴直线插补":
                    a = dgv_Items.CurrentRow.Index;
                    LnXYZFrom _LnXYZFrom = new LnXYZFrom();
                    _LnXYZFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _LnXYZFrom.ShowDialog();
                    break;
                case "四轴直线插补":
                    a = dgv_Items.CurrentRow.Index;
                    LnXYZAFrom _LnXYZAFrom = new LnXYZAFrom();
                    _LnXYZAFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _LnXYZAFrom.ShowDialog();
                    break;
                case "工位互锁":

                    break;
                case "缓存区控制列表":
                    a = dgv_Items.CurrentRow.Index;
                    BufferAreaFrom _BufferAreaFrom = new BufferAreaFrom();
                    _BufferAreaFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _BufferAreaFrom.ShowDialog();
                    break;
                case "激光控制":

                    break;
                case "建立坐标系":
                    //a = dgv_Items.CurrentRow.Index;
                    //BuildCorFrom _BuildCorFrom = new BuildCorFrom();
                    //_BuildCorFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    //_BuildCorFrom.ShowDialog();
                    break;
                case "c#脚本":
                    a = dgv_Items.CurrentRow.Index;
                    Frm_CodeEditTool Frm_CodeEditTool = new Frm_CodeEditTool();
                    Frm_CodeEditTool.ShowMesage(label1.Text, 流程Name.Text, a);
                    Frm_CodeEditTool.ShowDialog();
                    break;
                case "PY脚本":
                    a = dgv_Items.CurrentRow.Index;
                    PYToolFrom PYToolFrom = new PYToolFrom();
                    PYToolFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    PYToolFrom.ShowDialog();
                    break;
                case "解除工位互锁":

                    break;
                case "数据组赋值":

                    a = dgv_Items.CurrentRow.Index;
                    DataGroupFrom _DataGroupFrom = new DataGroupFrom();
                    _DataGroupFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _DataGroupFrom.ShowDialog();
                    break;
                case "数据组检测":
                    a = dgv_Items.CurrentRow.Index;
                    DataGroupFrom DataGroupFrom_ = new DataGroupFrom();
                    DataGroupFrom_.ShowMesage(label1.Text, 流程Name.Text, a);
                    DataGroupFrom_.ShowDialog();
                    break;
                case "串口通讯发送命令":
                    a = dgv_Items.CurrentRow.Index;
                    SerialPortSendDataFrom SerialPortSendDataFrom = new SerialPortSendDataFrom();
                    SerialPortSendDataFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    SerialPortSendDataFrom.ShowDialog();
                    break;
                case "串口通讯接受指令":
                    a = dgv_Items.CurrentRow.Index;
                    SerialPortResDataFrom SerialPortResDataFrom = new SerialPortResDataFrom();
                    SerialPortResDataFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    SerialPortResDataFrom.ShowDialog();
                    break;
                case "网络通讯发送命令":
                    a = dgv_Items.CurrentRow.Index;
                    _ser_clSendDataFrom _ser_clSendDataFrom = new _ser_clSendDataFrom();
                    _ser_clSendDataFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _ser_clSendDataFrom.ShowDialog();

                    break;
                case "网络通讯接受指令":
                    a = dgv_Items.CurrentRow.Index;
                    _ser_clResDataFrom _ser_clResDataFrom = new _ser_clResDataFrom();
                    _ser_clResDataFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _ser_clResDataFrom.ShowDialog();
                    break;

                case "延时":
                    a = dgv_Items.CurrentRow.Index;
                    DelayFrom DelayFrom = new DelayFrom();
                    DelayFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    DelayFrom.ShowDialog();
                    break;
                case "条件判断调子流程":

                    break;
                case "单轴运动":
                    a = dgv_Items.CurrentRow.Index;
                    Aixs_one_CtronFrom Aixs_one_CtronFrom = new Aixs_one_CtronFrom();
                    Aixs_one_CtronFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    Aixs_one_CtronFrom.ShowDialog();
                    break;

                case "单轴运动不检测运动完成":

                    break;
                case "单轴运动检测运动完成":
                    break;
                case "检测运动完成":
                    a = dgv_Items.CurrentRow.Index;
                    CheckAixsRunFinishFrom CheckAixsRunFinishFrom = new CheckAixsRunFinishFrom();
                    CheckAixsRunFinishFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    CheckAixsRunFinishFrom.ShowDialog();
                    break;
                case "单轴运动同时输出IO":

                    break;

                case "单轴运动完成后输出IO":

                    break;
                case "多轴运动":
                    a = dgv_Items.CurrentRow.Index;
                    Aixs_more_CtronFrom _Aixs_more_CtronFrom = new Aixs_more_CtronFrom();
                    _Aixs_more_CtronFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _Aixs_more_CtronFrom.ShowDialog();
                    break;
                case "缓存区插入其他":
                    a = dgv_Items.CurrentRow.Index;
                    AddOtherBuffFrom _AddOtherBuffFrom = new AddOtherBuffFrom();
                    _AddOtherBuffFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _AddOtherBuffFrom.ShowDialog();
                    break;
                case "多轴运动不检测运动完成":

                    break;
                case "多轴运动检测运动完成":


                    break;
                case "多轴运动同时输出IO":

                    break;

                case "多轴运动完成后输出IO":

                    break;


                case "算术":

                    break;

                case "数据分析":

                    break;

                case "展示":

                    break;
                case "相机补偿":
                    a = dgv_Items.CurrentRow.Index;
                    CamerCompensation_CenterFrom _CamerCompensation_CenterFrom = new CamerCompensation_CenterFrom();
                    _CamerCompensation_CenterFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    _CamerCompensation_CenterFrom.ShowDialog();
                    break;
                case "焊后拍照检测":
                    a = dgv_Items.CurrentRow.Index;
                    WeldedCheckForm _WeldedCheckForm = new WeldedCheckForm();
                    _WeldedCheckForm.ShowMesage(label1.Text, 流程Name.Text, a);
                    _WeldedCheckForm.ShowDialog();
                    break;
                case "数字量数据":
                    a = dgv_Items.CurrentRow.Index;
                    DigitalMea_HeighFrom DigitalMea_HeighFrom = new DigitalMea_HeighFrom();
                    DigitalMea_HeighFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    DigitalMea_HeighFrom.ShowDialog();
                    break;
                case "获取圆心坐标":
                    a = dgv_Items.CurrentRow.Index;
                    CamerGetR_CenterFrom CamerGetR_CenterFrom = new CamerGetR_CenterFrom();
                    CamerGetR_CenterFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    CamerGetR_CenterFrom.ShowDialog();
                    break;

                case "圆":
                    a = dgv_Items.CurrentRow.Index;
                    CirFrom CirFrom = new CirFrom();
                    CirFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    CirFrom.ShowDialog();
                    break;
                case "正方形":
                    a = dgv_Items.CurrentRow.Index;
                    DimetricFrom DimetricFrom = new DimetricFrom();
                    DimetricFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    DimetricFrom.ShowDialog();
                    break;
                case "自定义方法":
                    a = dgv_Items.CurrentRow.Index;
                    DefintionFunFrom DefintionFunFrom = new DefintionFunFrom();
                    DefintionFunFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    DefintionFunFrom.ShowDialog();
                    break;
                case "自定义方法2":
                    a = dgv_Items.CurrentRow.Index;
                    DefintionFunFrom2 DefintionFunFrom2 = new DefintionFunFrom2();
                    DefintionFunFrom2.ShowMesage(label1.Text, 流程Name.Text, a);
                    DefintionFunFrom2.ShowDialog();
                    break;
                case "自定义方法3":
                    a = dgv_Items.CurrentRow.Index;
                    DefintionFunFrom3 DefintionFunFrom3 = new DefintionFunFrom3();
                    DefintionFunFrom3.ShowMesage(label1.Text, 流程Name.Text, a);
                    DefintionFunFrom3.ShowDialog();
                    break;
                case "自定义方法4":
                    a = dgv_Items.CurrentRow.Index;
                    DefintionFunFrom4 DefintionFunFrom4 = new DefintionFunFrom4();
                    DefintionFunFrom4.ShowMesage(label1.Text, 流程Name.Text, a);
                    DefintionFunFrom4.ShowDialog();
                    break;
                case "多轴检测轴运动完成":
                    a = dgv_Items.CurrentRow.Index;
                    Aixs_more_CtronRunFinishFrom Aixs_more_CtronRunFinishFrom = new Aixs_more_CtronRunFinishFrom();
                    Aixs_more_CtronRunFinishFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    Aixs_more_CtronRunFinishFrom.ShowDialog();
                    break;
                case "子程序":
                    a = dgv_Items.CurrentRow.Index;
                    CallSubroutineFrom CallSubroutineFrom = new CallSubroutineFrom();
                    CallSubroutineFrom.ShowMesage(label1.Text, 流程Name.Text, a);
                    CallSubroutineFrom.ShowDialog();
                    break;
                case "采集图片":
                    a = dgv_Items.CurrentRow.Index;
                    frm_AcqFifo frm_AcqFifo = new frm_AcqFifo();
                    frm_AcqFifo.ShowMesage(label1.Text, 流程Name.Text, a);
                    frm_AcqFifo.ShowDialog();
                    break;
            }

        }
        int ChooseIndex = 0;
        private void dgv_Items_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Items_MouseDown(object sender, MouseEventArgs e)
        {

        }
        string ChooseIndexName = "";
        private void dgv_Items_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.bAuto)
            {
                return;
            }
            try
            {
                ChooseIndexName = dgv_Items.Rows[e.RowIndex].Cells[0].Value.ToString();
                ChooseIndex = int.Parse(ChooseIndexName);
                tool = LoadData._ImageToolRun[流程Name.Text];
                propertyGrid1.SelectedObject = tool[ChooseIndex - 1];
            }
            catch
            {
            }
        }

        private void tsb_deleteJob_Click(object sender, EventArgs e)
        {
            DialogResult DResult = MessageBox.Show("确定删除", "确定删除", MessageBoxButtons.YesNo);
            if (DResult == DialogResult.No)
            {
                return;
            }
            try
            {
                // Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].dicFlowData[流程Name.Text]._RunFlowData.RemoveAt(ChooseIndex - 1);
                LoadData._ImageToolRun.Remove(流程Name.Text);
                dgv_Items.Rows.Clear();
                string path = 路径.Text + "\\" + 流程Name.Text + ".xffp";
                File.Delete(path);
                Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].dicFlowData.Remove(流程Name.Text);

                dgv_deviceList.Rows.Clear();

                Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].ListFlowData = Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].dicFlowData.Select(r => r.Value).ToList();
                foreach (var item in Hard_Ward_Contral._FlowChar_ControlParameter._FlowChar_ControlData_Dictionary[label1.Text].dicFlowData)
                {

                    int idx = dgv_deviceList.Rows.Add();
                    dgv_deviceList.Rows[idx].Tag = textBoxHardWareName.Text;
                    this.dgv_deviceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_deviceList.Rows[idx].Height = 30;
                    dgv_deviceList.Rows[idx].Cells[0].Value = item.Value.RunFlowData_ControlDataName;
                }
            }
            catch (Exception)
            {


            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.流程更改标志 = true;
            int rowIndex = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
            if (rowIndex == 0)
            {
                MessageBox.Show("已经是第一行了!");
                return;
            }
            List<string> list = new List<string>();
            for (int i = 0; i < dgv_Items.Columns.Count; i++)
            {
                list.Add(dgv_Items.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中
            }

            for (int j = 0; j < dgv_Items.Columns.Count; j++)
            {
                dgv_Items.Rows[rowIndex].Cells[j].Value = dgv_Items.Rows[rowIndex - 1].Cells[j].Value;
                dgv_Items.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
            }
            tool = LoadData._ImageToolRun[流程Name.Text];
            ImageTool tmepset = tool[rowIndex];
            ImageTool set1 = tool[rowIndex - 1];
            //ImageTool set2 = tmepset;
            tool[rowIndex] = set1;
            tool[rowIndex - 1] = tmepset;
            LoadData._ImageToolRun[label1.Text] = tool;
            dgv_Items.Rows.Clear();
            int count = 1;
            foreach (var item in LoadData._ImageToolRun[流程Name.Text])
            {
                int idx = dgv_Items.Rows.Add();
                dgv_Items.Rows[idx].Tag = textBoxHardWareName.Text;
                this.dgv_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dgv_Items.Rows[idx].Height = 30;
                dgv_Items.Rows[idx].Cells[0].Value = (count).ToString();
                //item.FlowChar_StepControlLoop = count - 1;
                item.FlowChar_StepControlNum = count - 1;
                try
                {
                    dgv_Items.Rows[idx].Cells[1].Value = item.FlowChar_StepControlType;
                }
                catch (Exception ex)
                {
                    dgv_Items.Rows[idx].Cells[1].Value = "";
                }
                try
                {
                    dgv_Items.Rows[idx].Cells[2].Value = item.FlowChar_StepControlName;
                }
                catch (Exception ex)
                {

                    dgv_Items.Rows[idx].Cells[2].Value = "";
                }
                count++;
            }
            dgv_Items.Rows[rowIndex].Selected = false;
            dgv_Items.Rows[rowIndex - 1].Selected = true;
            dgv_Items.FirstDisplayedScrollingRowIndex = rowIndex - 1;
            resetStepControlLoop();//重置步骤跳转号
        }
        //public void  ChangeStep(int Step, List<ImageTool> tools)
        //{
        //    string Tepy = tools[Step].GetType().Name;
        //    //string ads=  Tepy.Name;
        //    //string Tepys = Tepy.;
        //    switch (Tepy)
        //    {
        //        case "OutPut":
        //            OutPut _OutPut_Puse;
        //            _OutPut_Puse = (OutPut)tools[Step];
        //            _OutPut_Puse.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "OutPut_Puse":

        //            break;
        //        case "Check_INPUT":
        //            Check_INPUT _Check_INPUT;
        //            _Check_INPUT = (Check_INPUT)tools[Step];
        //            _Check_INPUT.FlowChar_StepControlLoop = Step;
        //            //_Check_INPUT.
        //            break;
        //        case "DataGroup":
        //            ///用于工位互锁及检测流程状态
        //            DataGroup _DataGroup;
        //            _DataGroup = (DataGroup)tools[Step];
        //            _DataGroup.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "CodeEditTool":
        //            CodeEditTool _CodeEditTool;
        //            _CodeEditTool = (CodeEditTool)tools[Step];
        //            _CodeEditTool.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "BuildCor":
        //            BuildCor _BuildCor;
        //            _BuildCor = (BuildCor)tools[Step];
        //            _BuildCor.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "Aixs_one_Ctron":
        //            Aixs_one_Ctron _Aixs_one_Ctron;
        //            _Aixs_one_Ctron = (Aixs_one_Ctron)tools[Step];

        //            _Aixs_one_Ctron.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "CheckAixsRunFinish":
        //            CheckAixsRunFinish _CheckAixsRunFinish;
        //            _CheckAixsRunFinish = (CheckAixsRunFinish)tools[Step];
        //            _CheckAixsRunFinish.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "Aixs_more_Ctron":
        //            Aixs_more_Ctron _Aixs_more_Ctron;
        //            _Aixs_more_Ctron = (Aixs_more_Ctron)tools[Step];

        //            _Aixs_more_Ctron.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "CamerCompensation_Center":
        //            CamerCompensation_Center _CamerCompensation_Center;
        //            _CamerCompensation_Center = (CamerCompensation_Center)tools[Step];
        //            _CamerCompensation_Center.AxisPCamerCompensation(_CamerCompensation_Center);
        //            _CamerCompensation_Center.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "CamerGetR_Center":
        //            CamerGetR_Center CamerGetR_Center;
        //            CamerGetR_Center = (CamerGetR_Center)tools[Step];
        //            CamerGetR_Center.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "DigitalMea_Height":
        //            DigitalMea_Height DigitalMea_Height;
        //            DigitalMea_Height = (DigitalMea_Height)tools[Step];

        //            DigitalMea_Height.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "AddOtherBuff":
        //            AddOtherBuff AddOtherBuff;
        //            AddOtherBuff = (AddOtherBuff)tools[Step];
        //            AddOtherBuff.FlowChar_StepControlLoop = Step;
        //            break;

        //        case "ArcXYC":
        //            ArcXYC ArcXYC;
        //            ArcXYC = (ArcXYC)tools[Step];
        //            ArcXYC.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "LnXY":
        //            LnXY LnXY;
        //            LnXY = (LnXY)tools[Step];
        //            LnXY.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "LnXYZ":
        //            LnXYZ LnXYZ;
        //            LnXYZ = (LnXYZ)tools[Step];
        //            LnXYZ.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "LnXYZA":
        //            LnXYZA LnXYZA;
        //            LnXYZA = (LnXYZA)tools[Step];
        //            LnXYZA.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "BufferArea":
        //            BufferArea BufferArea;
        //            BufferArea = (BufferArea)tools[Step];
        //            BufferArea.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "PYTool":
        //            PYTool PYTool;
        //            PYTool = (PYTool)tools[Step];

        //            PYTool.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "CallSubroutine":
        //            //CallSubroutine CallSubroutine;
        //            //CallSubroutine = (CallSubroutine)tools[Step];
        //            //if (CallSubroutine.RunFun(BufferArea) == 0)
        //            //{
        //            //    currentRunStatus = true;
        //            //}
        //            //else
        //            //{
        //            //    currentRunStatus = false;
        //            //}
        //            break;
        //        case "SerialPortSendData":
        //            SerialPortSendData SerialPortSendData;
        //            SerialPortSendData = (SerialPortSendData)tools[Step];
        //            SerialPortSendData.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "SerialPortResData":
        //            SerialPortResData SerialPortResData;
        //            SerialPortResData = (SerialPortResData)tools[Step];
        //            SerialPortResData.FlowChar_StepControlLoop = Step;

        //            break;
        //        case "DelayData":
        //            DelayData DelayData;
        //            DelayData = (DelayData)tools[Step];
        //            DelayData.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "Cir":
        //            Cir Cir;
        //            Cir = (Cir)tools[Step];
        //            Cir.FlowChar_StepControlLoop = Step;
        //            break;
        //        case "Dimetric":
        //            Dimetric DimetricCir;
        //            DimetricCir = (Dimetric)tools[Step];
        //            DimetricCir.FlowChar_StepControlLoop = Step;
        //            break;
        //    }

        //}
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.流程更改标志 = true;
            int rowIndex = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引

            if (rowIndex == dgv_Items.Rows.Count - 1)
            {
                MessageBox.Show("已经是最后一行了!");
                return;
            }
            List<string> list = new List<string>();
            for (int i = 0; i < dgv_Items.Columns.Count; i++)
            {
                list.Add(dgv_Items.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中
            }

            for (int j = 0; j < dgv_Items.Columns.Count; j++)
            {
                dgv_Items.Rows[rowIndex].Cells[j].Value = dgv_Items.Rows[rowIndex + 1].Cells[j].Value;
                dgv_Items.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
            }
            dgv_Items.Rows.Clear();
            tool = LoadData._ImageToolRun[流程Name.Text];
            ImageTool tmepset = tool[rowIndex];
            ImageTool set1 = tool[rowIndex + 1];
            //ImageTool set2 = tmepset;
            tool[rowIndex] = set1;
            tool[rowIndex + 1] = tmepset;
            LoadData._ImageToolRun[label1.Text] = tool;
            dgv_Items.Rows.Clear();
            int count = 1;
            foreach (var item in LoadData._ImageToolRun[流程Name.Text])
            {
                int idx = dgv_Items.Rows.Add();
                dgv_Items.Rows[idx].Tag = textBoxHardWareName.Text;
                this.dgv_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dgv_Items.Rows[idx].Height = 30;
                dgv_Items.Rows[idx].Cells[0].Value = (count).ToString();
                //item.FlowChar_StepControlLoop = count - 1;
                item.FlowChar_StepControlNum = count - 1;
                try
                {
                    dgv_Items.Rows[idx].Cells[1].Value = item.FlowChar_StepControlType;
                }
                catch (Exception ex)
                {
                    dgv_Items.Rows[idx].Cells[1].Value = "";
                }
                try
                {
                    dgv_Items.Rows[idx].Cells[2].Value = item.FlowChar_StepControlName;
                }
                catch (Exception ex)
                {

                    dgv_Items.Rows[idx].Cells[2].Value = "";
                }
                count++;
            }

            dgv_Items.Rows[rowIndex].Selected = false;
            dgv_Items.Rows[rowIndex + 1].Selected = true;

            dgv_Items.FirstDisplayedScrollingRowIndex = rowIndex + 1;
            resetStepControlLoop();//重置步骤跳转号
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int count = 1;
            int rowIndex = dgv_Items.SelectedRows[0].Index;  //得到当前选中行的索引
            tool = LoadData._ImageToolRun[流程Name.Text];
            tool.RemoveAt(rowIndex);
            dgv_Items.Rows.Clear();
            LoadData._ImageToolRun[流程Name.Text] = tool;
            foreach (var item in LoadData._ImageToolRun[流程Name.Text])
            {
                int idx = dgv_Items.Rows.Add();
                dgv_Items.Rows[idx].Tag = textBoxHardWareName.Text;
                this.dgv_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dgv_Items.Rows[idx].Height = 30;
                dgv_Items.Rows[idx].Cells[0].Value = (count).ToString();
                try
                {
                    dgv_Items.Rows[idx].Cells[1].Value = item.FlowChar_StepControlType;
                }
                catch (Exception ex)
                {
                    dgv_Items.Rows[idx].Cells[1].Value = "";
                }
                try
                {
                    dgv_Items.Rows[idx].Cells[2].Value = item.FlowChar_StepControlName;
                }
                catch (Exception ex)
                {

                    dgv_Items.Rows[idx].Cells[2].Value = "";
                }
                count++;
            }
            if (rowIndex == tool.Count)
            {
                //dgv_Items.Rows[rowIndex-1].Selected = false;
                dgv_Items.Rows[rowIndex - 1].Selected = true;
            }
            else
            {
                dgv_Items.Rows[rowIndex].Selected = true;
                //dgv_Items.Rows[rowIndex + 1].Selected = true;
            }
            resetStepControlLoop();//重置步骤跳转号
        }

        List<TaskGroup> _TaskGroupList = new List<TaskGroup>();
        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            DialogResult DResult = MessageBox.Show("是否运行当前流程", "是否运行当前流程", MessageBoxButtons.YesNo);
            if (DResult == DialogResult.No)
            {
                return;
            }
            //运行一个流程
            if (Program.bManul == false)
            {
                Program.bManul = true;
                TaskRun.Instance().m_TaskGroup._ClearStep();
                TaskRun.Instance().m_TaskGroup.KillTherd();
                TaskRun.Instance().m_TaskGroup.ClearTaskUnit();
                FlowCharCtron _FlowCharCtron = new FlowCharCtron(流程Name.Text, TaskGroup.Instance()/* m_TaskGroup*/);
                TaskRun.Instance().m_TaskGroup.AddTaskUnit(_FlowCharCtron);
                TaskRun.Instance().m_TaskGroup.OneRunSta = true;
                TaskRun.Instance().m_TaskGroup.OneStartThread();
            }
            else
            {



            }
            //运行多个流程
            //foreach (var item in LoadData._ImageToolRun)
            //{

            //    FlowCharCtron _FlowCharCtron_ = new FlowCharCtron(item.Key, TaskGroup.Instance()/* m_TaskGroup*/);
            //    TaskGroup _TaskGroup = new TaskGroup();
            //    _TaskGroup.AddTaskUnit(_FlowCharCtron_);
            //    _TaskGroup.RunSta = true;
            //    _TaskGroup.StartThread();
            //    _TaskGroupList.Add(_TaskGroup);
            //}
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            DialogResult DResult = MessageBox.Show("是否停止当前流程", "是否停止当前流程", MessageBoxButtons.YesNo);
            if (DResult == DialogResult.No)
            {
                return;
            }
            TaskRun.Instance().m_TaskGroup.OneRunSta = false;
            TaskRun.Instance().m_TaskGroup.ClearTaskUnit();
            TaskRun.Instance().m_TaskGroup._ClearStep();
            // TaskRun.Instance().m_TaskGroup = null;

            Program.bManul = false;
            TaskRun.Instance().m_TaskGroup.OneRunSta = false;
        }

        private void CCD_tools_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void CCD_tools_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selectedNode = CCD_tools.SelectedNode;
            NodeClickCamer();
        }
        public void NodeClickCamer()
        {
            if (Program.bAuto)
            {
                return;
            }
            Properties.Settings.Default.流程更改标志 = true;
            int idx = 0;
            switch (selectedNode.Text)
            {
                case "采集图像":
                    _AcqFifoTool = new AcqFifoTool();
                    _AcqFifoTool.FlowChar_StepControlType = "采集图片";
                    _AcqFifoTool.FlowChar_StepControlName = "采集图片";
                    str = new string[] { "e", "w", "", "NG", "0ms" };
                    tool = LoadData._ImageToolRun[流程Name.Text];
                    EditBLL.Add(tool, _AcqFifoTool, str);
                    LoadData._ImageToolRun[流程Name.Text] = tool;
                    idx = dgv_Items.Rows.Add();
                    dgv_Items.Rows[idx].Tag = "采集图片";
                    dgv_Items.Rows[idx].Cells[0].Value = LoadData._ImageToolRun[流程Name.Text].Count.ToString();
                    dgv_Items.Rows[idx].Cells[1].Value = "采集图片";
                    dgv_Items.Rows[idx].Cells[2].Value = "采集图片";
                    //步骤编号
                    _AcqFifoTool.FlowChar_StepControlNum = idx;
                    _AcqFifoTool.FlowChar_StepControlLoop = idx;
                    break;
            }
        }

        private void tsb_expandJob_Click(object sender, EventArgs e)
        {

        }

        private void tsb_foldJob_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void 复制_Click(object sender, EventArgs e)
        {
            copyList.Clear();
            IEnumerator copyRows = dgv_Items.SelectedRows.GetEnumerator();
            List<int> indexList = new List<int>();
            try
            {
                while (copyRows.MoveNext())
                {
                    DataGridViewRow copyRow = (DataGridViewRow)copyRows.Current;
                    int index = copyRow.Index;
                    indexList.Add(index);
                }
                indexList.Sort();//排序
                foreach (int index in indexList)
                {
                    foreach (var i in LoadData._ImageToolRun)
                    {
                        if (i.Key == 流程Name.Text)
                        {
                            ImageTool a = i.Value[index];
                            copyList.Add(a);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void 删除_Click(object sender, EventArgs e)
        {
            int i = 0;
            bool theLast = false;
            IEnumerator deleteRows = dgv_Items.SelectedRows.GetEnumerator();
            List<int> indexList = new List<int>();
            try
            {
                while (deleteRows.MoveNext())
                {
                    DataGridViewRow delectRow = (DataGridViewRow)deleteRows.Current;
                    int index = delectRow.Index;
                    indexList.Add(index);
                }

                indexList.Sort();
                foreach (int a in indexList)
                {
                    if ((i + 1) == indexList.Count)
                        theLast = true;
                    deleteRowsFun(a - i, theLast);
                    i++;
                }
                resetStepControlLoop();//重置步骤跳转号
            }
            catch (Exception ex)
            { }
        }

        private void 添加复制项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            插入工具.SelectedItem = "加入";
            List<ImageTool> a = new List<ImageTool>();
            List<int> indexList = new List<int>();
            if (copyList.Count == 0)
                return;
            for (int i = 0; i < copyList.Count; i++)
            {
                a.Add((ImageTool)copyList[i].Clone());
                string addType = a[i].FlowChar_StepControlType;
                NodeClick(addType, a[i]);
            }
            resetStepControlLoop();//重置步骤跳转号
        }

        private void 插入复制项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            插入工具.SelectedItem = "插入";
            List<ImageTool> a = new List<ImageTool>();
            if (copyList.Count == 0)
                return;
            //copyList.Sort();
            if (dgv_Items.Rows.Count == 0)
            {
                MessageBox.Show("当前流程为空，不能插入");
                return;
            }
            for (int i = 0; i < copyList.Count; i++)
            {
                a.Add((ImageTool)copyList[i].Clone());
                string addType = a[i].FlowChar_StepControlType;
                NodeClick(addType, a[i]);
            }
            resetStepControlLoop();//重置步骤跳转号
            dgv_Items.Rows[0].Selected = false;
        }

        public void deleteRowsFun(int rowIndex, bool last)
        {
            int count = 1;
            tool = LoadData._ImageToolRun[流程Name.Text];
            tool.RemoveAt(rowIndex);
            dgv_Items.Rows.Clear();
            LoadData._ImageToolRun[流程Name.Text] = tool;
            foreach (var item in LoadData._ImageToolRun[流程Name.Text])
            {
                int idx = dgv_Items.Rows.Add();
                dgv_Items.Rows[idx].Tag = textBoxHardWareName.Text;
                this.dgv_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dgv_Items.Rows[idx].Height = 30;
                dgv_Items.Rows[idx].Cells[0].Value = (count).ToString();
                try
                {
                    dgv_Items.Rows[idx].Cells[1].Value = item.FlowChar_StepControlType;
                }
                catch (Exception ex)
                {
                    dgv_Items.Rows[idx].Cells[1].Value = "";
                }
                try
                {
                    dgv_Items.Rows[idx].Cells[2].Value = item.FlowChar_StepControlName;
                    item.FlowChar_StepControlNum = count - 1;
                }
                catch (Exception ex)
                {

                    dgv_Items.Rows[idx].Cells[2].Value = "";
                }
                count++;
            }
            if (last && rowIndex != 0)
            {
                if (rowIndex + 1 == count)
                {
                    dgv_Items.Rows[rowIndex - 1].Selected = true;
                }
                else
                {
                    dgv_Items.Rows[rowIndex].Selected = true;
                }

                dgv_Items.Rows[0].Selected = false;
            }
            resetStepControlLoop();//重置步骤跳转号
        }

        //重置步骤跳转号
        private void resetStepControlLoop()
        {
            foreach (var item in LoadData._ImageToolRun[流程Name.Text])
            {
                try
                {
                    item.FlowChar_StepControlLoop = item.FlowChar_StepControlNum;
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}