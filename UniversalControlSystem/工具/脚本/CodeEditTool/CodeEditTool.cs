using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.IO;

namespace UniversalControlSystem
{
    [Serializable]
    public  class CodeEditTool : ImageTool //ToolBase
    {
        public  string _RunFlowData_ControlDataName = "";
        public string _FlowChar_StepControlStepName = "";
        public int Num = 0;

        /// <summary>
        /// 源码
        /// </summary>
        public string sourceCode = string.Empty;

        /// <summary>
        /// 参数列表
        /// </summary>
        public string Parameter { set; get; }
        /// <summary>
        /// 取数据组
        /// </summary>
        public string _GteDataGroup { set; get; }
        /// <summary>
        /// 取数据组
        /// </summary>
        public string _GteDataGroupName { set; get; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroup { set; get; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroupName { set; get; }
        public CodeEditTool()
        {
            sourceCode =
@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MyApplication
{
    public class TestClass
    {
        static void Main(string[] args)
        {
            string Output1="";
            //Add code here

            

            Console.WriteLine(Output1);
        }
    }
}";
        }
        [NonSerialized]
        ///// <summary>
        ///// 输入项1
        ///// </summary>
        //internal string Input1 = string.Empty;
        ///// <summary>
        ///// 输入项2
        ///// </summary>
        //internal string Input2 = string.Empty;
        ///// <summary>
        ///// 输入项3
        ///// </summary>
        //internal string Input3 = string.Empty;
        ///// <summary>
        ///// 输入项4
        ///// </summary>
        //internal string Input4 = string.Empty;
        ///// <summary>
        ///// 输入项5
        ///// </summary>
        //internal string Input5 = string.Empty;
        ///// <summary>
        ///// 输出项1
        ///// </summary>
        public   string Output1 = string.Empty;
        ///// <summary>
        ///// 输出项2
        ///// </summary>
        //internal string Output2 = string.Empty;
        ///// <summary>
        ///// 输出项3
        ///// </summary>
        //internal string Output3 = string.Empty;
        ///// <summary>
        ///// 编译结果
        ///// </summary>
        public  string compileResult = string.Empty;
        //[NonSerialized]
        private object obj = new object();
        [NonSerialized]
        internal string jobName = string.Empty;
        [NonSerialized]
        internal ToolRunStatu runStatu = ToolRunStatu.未运行;
        /// <summary>
        /// 工具运行
        /// </summary>
        //public  void Run(string s, bool b, bool b1 = true)
        //{
        //    s.Replace("m", "");
        //}

        /// <summary>
        /// 运行工具
        /// </summary>
        public  void Run(CodeEditTool _CodeEditTool)
        {
            try
            {
                lock (obj)
                {
                    runStatu = ToolRunStatu.Not_Succeed;
                    //解析输入
                    string sourceCodeAfter = sourceCode;
                    new Runner().CompileAndRun(sourceCodeAfter, out compileResult, _CodeEditTool);
                    compileResult = compileResult.Substring(0, compileResult.Length - 2);
                    Output1 = compileResult;
                    DataManage.SetData(_CodeEditTool.DataGroup, _CodeEditTool.DataGroupName,(object) Output1);
                    runStatu = ToolRunStatu.Succeed;
                }
            }
            catch (Exception ex)
            {
                //LogHelper.SaveErrorInfo(ex);
            }
        }

    }

}
