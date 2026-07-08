using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    interface InIO_Interface
    {
        /// <summary>
        ///  获取输入IO状态方法  上升沿
        /// </summary>
        /// <param name="bitName">IO输出名</param>
        /// <returns></returns>
        bool _Check_IN_Rising_edge(string bitName);
        /// <summary>
        ///  获取输入IO状态方法  下降沿
        /// </summary>
        /// <param name="bitName">IO输出名</param>
        /// <returns></returns>
        bool _Check_IN_Falling_edge(string bitName);

        /// <summary>
        ///  获取输入IO状态方法
        /// </summary>
        /// <param name="bitName">IO输出名</param>
        /// <returns></returns>
        bool _Check_INPUT(string bitName);
        /// <summary>
        /// 检测后延时
        /// </summary>
        /// <param name="bitName"></param>
        ///   /// <param name="delay"></param>
        /// <returns></returns>
        bool _Check_INPUT_Delay(string bitName ,int delay);
    }
}
