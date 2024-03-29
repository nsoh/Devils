using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Devils.Task
{
    // 파일 생성 task
    public class GenerateTask : BaseTask
    {
        public override void Run()
        {
            if(File.Exists(FilePath) == false)
            {
                // 파일을 생성한다.
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
            }
            else
            {
                // 파일 존재시 parameters의 내용을 파일의 끝에 추가한다.
                List<string> allLines = File.ReadLines(FilePath).ToList();
                string lastLine = allLines[allLines.Count - 1];
                allLines.RemoveAt(allLines.Count - 1);
                allLines.AddRange(Parameters);
                allLines.Add(lastLine);
                File.WriteAllLines(FilePath, allLines);
            }
        }
    }
}