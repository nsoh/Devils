using System;
using Devils.Task;

namespace Devils.Parser
{
    abstract class BaseParser
    {
        public abstract string Run(BaseTask task, string text, string[] ctx, string[] args, out string[] outText);

        
        public string ReplaceText(string text, string delimiter, string oldValue, string newValue)
        {
            return text.IndexOf(delimiter) != -1 
                    ? text.Replace(delimiter + oldValue + "}", newValue) 
                    : text;
        }
    }
}