using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalControlSystem
{
    [Serializable]
    public class LogicalJump : ImageTool
    {
        /// <summary>
        ///类型设置
        /// </summary>
        public string 类型设置 { set; get; }
        ///// <summary>
        /////类型名称
        ///// </summary>
        //public string 类型名称 { set; get; }
        /// <summary>
        ///检测状态
        /// </summary>

        public string 检测状态 { set; get; }
        /// <summary>
        ///IOInputItem
        /// </summary>

        public string IOInputItem { set; get; }

        /// <summary>
        ///数据组Item
        /// </summary>

        public string 数据组Item { set; get; }

        /// <summary>
        ///数据包主键Item
        /// </summary>

        public string 数据包主键Item { set; get; }
        /// <summary>
        ///数据包从键Item
        /// </summary>

        public string 数据包从键Item { set; get; }
        /// <summary>
        ///IOOutputItem
        /// </summary>
        public string IOOutputItem { set; get; }
        public bool LogicalJumpFun(LogicalJump _LogicalJump)
        {
            bool Res = false;
            bool sta = false;
            if (_LogicalJump.类型设置 == "IO输入")
            {
                sta = bool.Parse(_LogicalJump.检测状态);
                if (sta == Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOInPut_Dictionary[_LogicalJump.IOInputItem].bBitInputStatus)
                {
                    Res = true;
                }
                else
                {
                    Res = false;
                }

            }
            else if (_LogicalJump.类型设置 == "IO输出")
            {
                sta = bool.Parse(_LogicalJump.检测状态);
                if (sta == Hard_Ward_Contral.Hardware_IO_State.m_Hard_IOOutPut_Dictionary[_LogicalJump.IOOutputItem].bBitOutputStatus)
                {
                    Res = true;
                }
                else
                {
                    Res = false;
                }
            }
            else if (_LogicalJump.类型设置 == "数据组")
            {
                sta = bool.Parse(_LogicalJump.检测状态);
                if (sta ==(bool) Hard_Ward_Contral._DateGroupParameter._DateGroup_Dictionary[_LogicalJump.数据组Item].Date)
                {
                    Res = true;


                }
                else
                {
                    Res= false;
                }
            }
            else if (_LogicalJump.类型设置 == "数据包")
            {
                string data = DataManage.StrValue(_LogicalJump.数据包主键Item, _LogicalJump.数据包从键Item);
                bool _data = bool.Parse(data);
                sta = bool.Parse(_LogicalJump.检测状态);
                if (sta == _data)
                {
                    Res = true;
                }
                else
                {
                    Res = false;
                }

            }
            return Res;
        }
    }
}
