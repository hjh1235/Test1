using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalControlSystem
{
    public  class TaskRun
    {
        private static TaskRun _TaskRun;
        public static TaskRun Instance()
        {
            if (_TaskRun == null)
            {
                _TaskRun = new TaskRun();
            }
            return _TaskRun;
        }
        public TaskGroup m_TaskGroup = new TaskGroup();

    }
}
