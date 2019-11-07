using System;
using System.Collections.Generic;
using Devils;


namespace Devils.Task
{
    public abstract class TaskBase
    {
        public string FilePath { get; set; }
        public string[] Parameters { get; set; }


        // task를 실행한다.
        public abstract bool Run();
    }
}
