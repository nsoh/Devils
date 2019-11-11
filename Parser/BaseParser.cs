using System;
using Devils.Task;

namespace Devils.Parser
{
    // 구문 분석 기본 클래스
    abstract class BaseParser
    {
        static readonly string endDelimiter = "}";


        // 구문 분석을 진행한다.
        public abstract string Run(BaseTask task, string text, string[] ctx, string[] args, out string[] outText);

        
        // 텍스트내의 특정 문자열을 새로운 문자열로 바꾼다.
        public string ReplaceText(string text, string beginDelimiter, string oldValue, string newValue)
        {
            return text.IndexOf(beginDelimiter) != -1 
                    ? text.Replace(beginDelimiter + oldValue + endDelimiter, newValue) 
                    : text;
        }
    }
}