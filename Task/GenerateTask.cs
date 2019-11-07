using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Devils.Task
{
    public class GenerateTask : TaskBase
    {
        public override bool Run()
        {
            // 파일 생성
            if(File.Exists(FilePath) == false)
            {
                int index = FilePath.LastIndexOf('/');
                if(index != -1)
                {
                    string targetDir = FilePath.Substring(0, index);
                    DirectoryInfo dir = new DirectoryInfo(targetDir);
                    if(!dir.Exists)
                    {
                        Directory.CreateDirectory(targetDir);
                    }
                }      

                File.WriteAllLines(FilePath, Parameters);
                return true;
            }


            // 파일에 text를 추가한다.
            List<string> allLines = File.ReadLines(FilePath).ToList();
            string lastLine = allLines[allLines.Count - 1];
            allLines.RemoveAt(allLines.Count - 1);
            allLines.AddRange(Parameters);
            allLines.Add(lastLine);
            File.WriteAllLines(FilePath, allLines);

            return true;
        }
    }
}