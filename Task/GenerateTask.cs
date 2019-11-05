using System;
using System.IO;

namespace Devils.Task
{
    class GenerateTask : ConfigBase
    {
        public string FileName { get; set; }
        public string[] Arguments { get; set; }

        public override bool Run(string[] args)
        {
            // 디렉토리 확인
            int index = FileName.LastIndexOf('/');
            if(index != -1)
            {
                // string targetDir = args[3] + "/" + FilePath.Substring(0, index);
                // string fileName = FilePath.Substring(index + 1, FilePath.Length - index - 1);
                // //string serviceName = args[3].Substring(args[3].LastIndexOf('/') + 1, ;

                // DirectoryInfo dir = new DirectoryInfo(targetDir);
                // if(!dir.Exists)
                // {
                //     Directory.CreateDirectory(targetDir);
                // }
            }


            // 명령 변수 추출
            string[] cmdVars = ExtractCommandVariable(FileName);
            foreach(var var in cmdVars)
            {
                index = Array.IndexOf(args, var);
                if(index == -1)
                {
                    index = Array.IndexOf(args, "--" + var);
                    if(index == -1)
                    {
                        Console.WriteLine("not found \'${{0}}\' in command.", var);
                        return false;
                    }
                }

                FileName = ConvertCommandVariable(FileName, var, args[index + 1]);
            }

           
            // 기존 파일 제거
            if (File.Exists(FileName))    
            {    
                File.Delete(FileName);    
            }    


            using (StreamWriter sw = File.CreateText(FileName))    
            { 
                foreach(var l in Arguments)
                {
                    string line = l;
                    cmdVars = ExtractCommandVariable(line);
                    foreach(var var in cmdVars)
                    {
                        index = Array.IndexOf(args, var);
                        if(index == -1)
                        {
                            Console.WriteLine("not found \'${{0}}\' in command.", var);
                            return false;
                        }

                        line = ConvertCommandVariable(line, var, args[index + 1]);
                    }

                    sw.WriteLine(line);    
                }
            }    

            return true;
        }
    }
}