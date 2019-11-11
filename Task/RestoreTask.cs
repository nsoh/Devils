using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using Devils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Devils.Task
{
    // 스크립트의 데이터를 기반으로 파일을 복원시키는 기능을 하는 task
    public class RestoreTask : BaseTask
    {
        public override void Run()
        {
            JsonConfig config = new JsonConfig(FilePath);
            string restoreFilePath = config.Parse("restoreFile");

            File.WriteAllLines(restoreFilePath, Parameters);
        }
    }
}