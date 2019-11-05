using System;
using System.Collections.Generic;


namespace Devils
{
    abstract class ConfigBase
    {
        static readonly string delimiter = "${command:";

        public abstract bool Run(string[] args);

        // 명령행에서 ${command:}로 지정된 변수를 추출한다.
        public string[] ExtractCommandVariable(string text)
        {
            List<string> resultValue = new List<string>();
            int index = text.IndexOf(delimiter, 0);
            while(index != -1)
            {
                int lastIndex = text.IndexOf('}', index + 1);
                resultValue.Add(text.Substring(
                    index + delimiter.Length, 
                    lastIndex - index - delimiter.Length));

                index = text.IndexOf(delimiter, lastIndex + 1);    
            }

            return resultValue.ToArray();
        }

        public string ConvertCommandVariable(string text, string oldValue, string newValue)
        {
            return text.IndexOf(delimiter) != -1 
                    ? text.Replace(delimiter + oldValue + "}", newValue) 
                    : string.Empty;
        }


    }
}
