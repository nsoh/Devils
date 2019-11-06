using System;
using System.Collections.Generic;
using Devils;


namespace Devils.Task
{
    public abstract class TaskBase
    {
        static readonly string delimiter = "${";
        static readonly string commandDelimiter = "${command:";
        static readonly string configDelimiter = "${config:";


        // task를 실행한다.
        public abstract bool Run(string[] args);


        // config.json에 설정된 각종 환경 변수를 분석한다.
        public string ParseEnviromentVar(string text, string[] args)
        {
                string parseText = text;
                string[] vars = ExtractEnviromentVar(text, delimiter);

                foreach(var var in vars)
                {
                    string[] words = var.Split(':');
                    if(words.Length != 2)
                    {
                        //throw new Exception("invalid variable. var:{0}", var);
                        return parseText;
                    }

                    switch(words[0])
                    {
                        case "command": 
                        {
                            int index = Array.IndexOf(args, words[1]);
                            if(index == -1)
                            {
                                index = Array.IndexOf(args, "--" + words[1]);
                                if(index == -1)
                                {
                                    //throw new Exception("not found \'${{0}}\' in command.", words[1]);
                                    return string.Empty;
                               }
                            }

                            parseText = ReplaceText(parseText, commandDelimiter, words[1], args[index + 1]);
                        }
                        break;
                        case "config":
                        {
                            int index = Array.IndexOf(args, "--path");
                            if(index == -1)
                            {
                                //throw new Exception("not found \'${{0}}\' in command.", words[1]);
                                return string.Empty;
                            }

                            Config config = new Config(args[index + 1] + "/service.config.json");
                            parseText = ReplaceText(parseText, configDelimiter, words[1], config.Parse(words[1]));
                        }
                        break;
                    }
                }

                return parseText;
        }


        // 텍스트 구문을 분석한다.
        string[] ExtractEnviromentVar(string text, string delimiter)
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


        // 텍스트의 특정 구문의 문자열을 교체한다.
        public string ReplaceText(string text, string delimiter, string oldValue, string newValue)
        {
            return text.IndexOf(delimiter) != -1 
                    ? text.Replace(delimiter + oldValue + "}", newValue) 
                    : text;
        }
    }
}
