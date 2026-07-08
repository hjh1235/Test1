using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    public  class LoadData
    {
        static List<ImageTool> tool/* = new List<ImageTool>()*/;
        public static  Dictionary<string, List<ImageTool>> _ImageToolRun=new Dictionary<string, List<ImageTool>> ();
        public LoadData()
        {
        }
        public static Dictionary<string, List<ImageTool>> ReadData(string Path)
        {
            _ImageToolRun.Clear();
            if (!File.Exists(Path))
            {
                try
                {
                    var files = Directory.GetFiles(Path + "\\", "*.xffp");
                    foreach (var file in files)
                    {
                        string fileNameExt = file.Substring(file.LastIndexOf("\\") + 1); //获取文件名，不带路径
                        string filePath = file.Substring(0, file.LastIndexOf("\\"));//获取文件路径，不带文件名
                        tool = new List<ImageTool>();
                        tool.Clear();
                        tool = SerializeBLL.Read(filePath + "\\" + fileNameExt) as List<ImageTool>;//反序列化所有工具
                        if (tool == null)
                        {
                            tool = new List<ImageTool>();
                            _ImageToolRun.Add(fileNameExt.Replace(".xffp", ""), tool);
                        }
                        else
                        {
                            _ImageToolRun.Add(fileNameExt.Replace(".xffp", ""), tool);
                        }       
                    }
                }
                catch (Exception es)
                {
                }
            }
            try
            {
            }
            catch (System.Exception ex)
            {
                tool = new List<ImageTool>();
            }
            return _ImageToolRun;
        }
        public static void Load(string Path)
        {
            try
            {
                tool.Clear();
                tool = SerializeBLL.Read(Path/*@".//Parameter/FlowChar_Control" + ".xml"*/) as List<ImageTool>;//反序列化所有工具
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("数据加载失败！" + ex.Message, "数据加载失败！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tool = new List<ImageTool>();
            }
            if (tool == null)
            {
                tool = new List<ImageTool>();
            }
        }
        public static void  SaveFile()
        {
            try
            {
                var files = Directory.GetFiles(Properties.Settings.Default.FlowRunPath + "\\", "*.xffp");
                foreach (var file in files)
                {
                    string fileNameExt = file.Substring(file.LastIndexOf("\\") + 1); //获取文件名，不带路径
                    string filePath = file.Substring(0, file.LastIndexOf("\\"));//获取文件路径，不带文件名
                    string path = filePath + "\\" + fileNameExt;
                    try
                    {
                      //  tool = _ImageToolRun[fileNameExt.Replace(".xml", "")];
                        tool = _ImageToolRun[fileNameExt.Replace(".xffp", "")];
                        SerializeBLL.Write(tool, path);
                    }
                    catch
                    {
                    }
                }
            }
            catch 
            {
            }
        }
    }
}
