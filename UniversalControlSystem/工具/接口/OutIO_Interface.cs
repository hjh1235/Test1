using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    interface ToolFun_OutIO
    {
        /// <summary>
        /// IO输出方法
        /// </summary>
        /// <param name="bitName">IO输出名</param>
        /// <param name="bOn">输出状态</param>
        /// <returns></returns>
        bool SetOutBit(string bitName, bool bOn);
        /// <summary>
        ///  获取输出IO状态方法
        /// </summary>
        /// <param name="bitName">IO输出名</param>
        /// <returns></returns>
        bool GetOutBit(string bitName);
        /// <summary>
        /// 获取输入IO状态方法
        /// </summary>
        /// <param name="bitName">IO输出名</param>
        /// <returns></returns>
        bool GetIntBit(string bitName);
        /// <summary>
        /// 脉冲输出
        /// </summary>
        /// <param name="bitName">IO输出名</param>
        /// <param name="Count">输出次数</param>
        /// <param name="delay">间隔延时</param>
        /// <returns></returns>
        bool _OutPut_Puse(string bitName, int Count,int delay);
        /// <summary>
        /// 先输出后延时
        /// </summary>
        /// <param name="bitName"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        bool  _F_OutPut_DeeDelay(string bitName, bool bOn, int delay);
        /// <summary>
        /// 先延时后输出
        /// </summary>
        /// <param name="bitName"></param>
        /// <param name="delay"></param>
        /// <returns></returns>
        bool _F_Delay_DeeOutPut(string bitName, bool bOn, int delay);

    }
}
