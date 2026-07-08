using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    [Serializable]
    public class BufferArea : ImageTool
    {
        public int CardNum { get; set; }
        public int Cor { get; set; }
        public string FunChoose { get; set; }
        public string _轴1Name { get; set; }
        public string _轴2Name { get; set; }
        public string _轴3Name { get; set; }
        public string _轴4Name { get; set; }
        public int RunFun(BufferArea _BufferArea)
        {
            if (FunChoose == "建立坐标系")
            {
                BuildCor(_BufferArea);
            }
            if (FunChoose == "清空缓存区")
            {
                ClearBuff(_BufferArea);
            }
            if (FunChoose == "缓存区开始")
            {
                BuffAddStart(_BufferArea);
            }
            if (FunChoose == "缓存区启动")
            {
                BuffRun(_BufferArea);
            }
            return 0;
        }
        public int BuildCor(BufferArea _BufferArea)
        {
            return ManageContral.BuildCor(_BufferArea);
        }
        public int ClearBuff(BufferArea _BufferArea)
        {
            return ManageContral.ClearBuff(_BufferArea);
        }
        public int BuffAddStart(BufferArea _BufferArea)
        {
            return ManageContral.BuffAddStart(_BufferArea);
        }
        public int BuffRun(BufferArea _BufferArea)
        {
            return ManageContral.BuffRun(_BufferArea);
        }
    }
}
