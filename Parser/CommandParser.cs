using System;
using Devils.Task;

namespace Devils.Parser
{
    class CommandParser : BaseParser
    {
        static readonly string delimiter = "${command:";

        public override string Run(BaseTask task, string text, string[] ctx, string[] args, out string[] outText)
        {
            outText = null;
            int index = Array.IndexOf(args, ctx[1]);
            if(index == -1)
            {
                index = Array.IndexOf(args, "--" + ctx[1]);
                if(index == -1)
                {
                    return null;
                }
            }

            return ReplaceText(text, delimiter, ctx[1], args[index + 1]);
        }
    }
}