using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Devils
{
    // json 스크립트의 데이터를 취급한다.
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


        // 문자열에서 구분자 사이에 포함된 문자열을 추출한다.
        public string[] ExtractText(string text, string beginDelimiter, string endDelimiter)
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