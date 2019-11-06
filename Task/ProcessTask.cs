using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Devils.Task
{
    public class ProcessTask : TaskBase
    {
        public string FileName { get; set; }
        public string Arguments { get; set; }

        public override bool Run(string[] args)
        {
            string parseArgumnets = ParseEnviromentVar(Arguments, args);
            if(parseArgumnets == string.Empty)
            {
                return false;
            }

            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = FileName,
                    Arguments = parseArgumnets,
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