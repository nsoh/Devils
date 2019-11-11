using System;
using Devils.Task;

namespace Devils.Parser
{
    // config 파일의 구문을 분석한다.
    class ConfigParser : BaseParser
    {
        static readonly string delimiter = "${config:";

        public override string Run(BaseTask task, string text, string[] ctx, string[] args, out string[] outText)
        {
            outText = null;
            int index = Array.IndexOf(args, "--path");
            if(index == -1)
            {
                throw new DevilException(DevilErrorCode.ErrorTaskNotExists, 
                    "invalid context:{0}", string.Join(' ', ctx));
            }

            string value = string.Empty;
            string path = args[index + 1];
            index = path.LastIndexOf('/', path.Length - 1);
            if(index != -1)
            {
                int startIndex = path.LastIndexOf('/', index - 1) + 1;
                value = path.Substring(startIndex, index - startIndex);
            }


            return ReplaceText(text, delimiter, ctx[1], value);
        }
    }
}