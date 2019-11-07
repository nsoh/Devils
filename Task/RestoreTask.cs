using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Devils;

namespace Devils.Task
{
    public class RestoreTask : TaskBase
    {
        public string RestorePath { get; set; }

        public override bool Run()
        {
            CommandConfig config = new CommandConfig(RestorePath);
            //config.Parse("")

            return true;
        }
    }
}