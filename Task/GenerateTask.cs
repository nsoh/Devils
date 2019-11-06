using System;
using System.IO;


namespace Devils.Task
{
    public class GenerateTask : TaskBase
    {
        public string FileName { get; set; }
        public string[] Arguments { get; set; }

        public override bool Run(string[] args)
        {
            string parseFileName = ParseEnviromentVar(FileName, args);
            if(parseFileName == string.Empty)
            {
                return false;
            }
            
            using (StreamWriter sw = File.CreateText(parseFileName))    
            { 
                foreach(var line in Arguments)
                {
                    string parseLine = ParseEnviromentVar(line, args);
                    sw.WriteLine(parseLine);    
                }
            }    

            return true;
        }
    }
}