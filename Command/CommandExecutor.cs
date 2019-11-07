using System;
using System.Collections.Generic;
using Devils.Task;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


namespace Devils
{
    // <명령 실행자 클래스>
    // 1. 입력받은 명령어와 config파일을 분석한 후 명령어를 완성시킨다.
    // 2. 완성된 명령어를 실행한다.
    public class CommandExecutor
    {
        TaskBase[] m_Tasks;


        public bool Parse(string configFile, string[] cmdArgs)
        {
            if(cmdArgs.Length < 1)
            {
                Console.WriteLine("invalid command length.");
                return false;
            }

            CommandConfig config = new CommandConfig(configFile);
            m_Tasks = config.ParseCommand(cmdArgs);

            return true;   
        }


        public void Run()
        {
            foreach(var t in m_Tasks)
            {
                t.Run();
            }
        }
    }
}