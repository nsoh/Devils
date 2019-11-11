using System;
using Devils.Task;

namespace Devils.Parser
{
    // 명령어 구문을 분석한다.
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
                    throw new DevilException(DevilErrorCode.ErrorTaskNotExists, 
                        "invalid context:{0}", string.Join(' ', ctx));
                }
            }

            return ReplaceText(text, delimiter, ctx[1], args[index + 1]);
        }
    }
}