using System;
using System.Collections.Generic;
using Devils;


namespace Devils.Task
{
    public abstract class BaseTask
    {
        // task 타입
        public string Type { get; set; }

        // task 파일경로
        public string FilePath { get; set; }

        // task 실행시 필요한 parameter
        public string[] Parameters { get; set; }


        // task를 실행한다.
        public abstract void Run();
    }
}
