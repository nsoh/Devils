using System;
using Devils.Task;

namespace Devils.Parser
{
    class ConfigParser : BaseParser
    {
        static readonly string delimiter = "${config:";

        public override string[] Run(BaseTask task, string text, string[] ctx, string[] args)
        {
            int index = Array.IndexOf(args, "--path");
            if(index == -1)
            {
                return null;
            }

            text = ReplaceText(text, delimiter, ctx[1], args[index + 1]);
            return new string[]{ text };
        }
    }
}