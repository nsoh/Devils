using System;
using System.Collections.Generic;
using Devils.Task;

namespace Devils
{
    public class Command
    {
        public string Type { get; set; }
        public ProcessTask[] ProcessTasks { get; set; }
        public GenerateTask[] GenerateTasks { get; set; }


        public void Run(string[] args)
        {
            foreach(var t in ProcessTasks)
            {
                t.Run(args);
            }

            foreach(var t in GenerateTasks)
            {
                t.Run(args);
            }
        }
    }
}