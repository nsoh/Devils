using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Devils.Task
{
    public class ProcessTask : TaskBase
    {
        public override bool Run()
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = FilePath,
                    Arguments = Parameters[0],
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.WaitForExit();
            return true;
        }
    }
}