using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Devils.Generate
{
    public class GenerateService : IGenerate
    {
        public bool Run(string[] args)
        {
            // string cmd = args[0];
            // string type = args[1];
            // string path = args[2];

            // using (StreamReader r = new StreamReader("Generate/View/Service.json"))
            // {
            //     JObject json = JObject.Parse(r.ReadToEnd());
                
            //     if(cmd.CompareTo(Convert.ToString(json["command"])) != 0)
            //     {
            //         return false;
            //     }

            //     if(type.CompareTo(Convert.ToString(json["type"])) != 0)
            //     {
            //         return false;
            //     }
            // }


            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = "new classlib -o " + args[2],
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    CreateNoWindow = true
                }
            };

            return process.Start();
        }
    }

}
