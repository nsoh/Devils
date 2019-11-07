using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Devils
{
    public class ConfigBase
    {
        protected JObject m_JObject;

        public ConfigBase(string filePath)
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
    }
}