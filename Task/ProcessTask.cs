using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace Devils.Task
{
    public class ProcessTask : BaseTask
    {
        public override bool Run()
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
            return true;
        }
    }
}