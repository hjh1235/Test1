using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace UniversalControlSystem
{
    [Serializable]
    public class PYTool : ImageTool
    {
        public string Py_Path { get; set; }
        public string Py_Run_Res { set; get; }
        public string Py_Fun { set; get; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroup { set; get; }
        /// <summary>
        /// 存入数据组
        /// </summary>
        public string DataGroupName { set; get; }
        public void RunPy(PYTool PYTool)
        {
            try
            {
                ScriptEngine pyEngine = Python.CreateEngine();//创建Python解释器对象
                dynamic py = pyEngine.ExecuteFile(PYTool.Py_Path);//读取脚本文件    
                PYTool.Py_Run_Res = py.main(Py_Fun);//调用脚本文件中对应的函数     
            }
            catch (Exception)
            {
            }
        }
    }
}
