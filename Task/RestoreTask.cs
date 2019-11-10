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
    public class RestoreTask : BaseTask
    {
        public override bool Run()
        {
            JsonConfig config = new JsonConfig(FilePath);
            string restoreFilePath = config.Parse("restoreFile");
            File.WriteAllLines(restoreFilePath, Parameters);

            return true;
        }
    }
}