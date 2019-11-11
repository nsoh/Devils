using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace Devils.Task
{
    // 프로세스 실행 task
    public class ProcessTask : BaseTask
    {
        public override void Run()
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = FilePath,
                    Arguments = Parameters.SingleOrDefault(),
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.WaitForExit();
        }
    }
}