using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Devils.Generate
{
    public class GenerateAction : IGenerate
    {
        public bool Run(string[] args)
        {
            using (StreamReader r = new StreamReader("Config.json"))
            {
                JObject json = JObject.Parse(r.ReadToEnd());
                JArray jarrTask = JArray.Parse(json["generateTask"].ToString());
                foreach(JObject jobj in jarrTask)
                {
                    Console.WriteLine(jobj["handlerKey"].ToString());

                    if(jobj["views"] != null)
                    {
                    JArray jarrView = JArray.Parse(jobj["views"].ToString());
                    if(jarrView != null)
                    {
                        foreach(JObject jobj2 in jarrView)
                        {
                            Console.WriteLine(jobj2["filePath"].ToString());
                        }
                    }
                    }
                }
            }


            // var process = new Process
            // {
            //     StartInfo = new ProcessStartInfo
            //     {
            //         FileName = "dotnet",
            //         Arguments = "new classlib -o " + args[2],
            //         UseShellExecute = true,
            //         RedirectStandardOutput = false,
            //         RedirectStandardError = false,
            //         CreateNoWindow = true
            //     }
            // };

            // return process.Start();

            return true;
        }
    }

}
