using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Devils.Task
{
    class ProcessTask : ConfigBase
    {
        public string FileName { get; set; }
        public string Arguments { get; set; }

        public override bool Run(string[] args)
        {
            string[] cmdVars = ExtractCommandVariable(Arguments);
            foreach(var var in cmdVars)
            {
                int index = Array.IndexOf(args, var);
                if(index == -1)
                {
                    index = Array.IndexOf(args, "--" + var);
                    if(index == -1)
                    {
                        Console.WriteLine("not found \'${{0}}\' in command.", var);
                        return false;
                    }
                }

                Arguments = ConvertCommandVariable(Arguments, var, args[index + 1]);
            }


            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = FileName,
                    Arguments = Arguments,
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