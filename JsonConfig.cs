using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Devils.Task
{
    class JsonConfig
    {
        JObject m_JObject;

        public JsonConfig(string filePath)
        {
             using (StreamReader r = new StreamReader(filePath))
            {
                m_JObject = JObject.Parse(r.ReadToEnd());
            }           
        }

        public string Parse(string key)
        {
            return m_JObject[key].ToString();
        }

        public JObject ParseJObject(string key)
        {
            return JObject.Parse(m_JObject[key].ToString());
        }


        public string[] ExtractContext(string text, string beginDelimiter, string endDelimiter)
        {
            List<string> resultValue = new List<string>();
            int index = text.IndexOf(beginDelimiter, 0);
            while(index != -1)
            {
                int lastIndex = text.IndexOf(endDelimiter, index + 1);
                resultValue.Add(text.Substring(
                    index + beginDelimiter.Length, 
                    lastIndex - index - beginDelimiter.Length));

                index = text.IndexOf(beginDelimiter, lastIndex + 1);    
            }

            return resultValue.ToArray();
        }

    }
}