using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Devils
{
    public class Config
    {
        JObject m_Data;

        public Config(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                m_Data = JObject.Parse(r.ReadToEnd());
            }
        }

        public string Parse(string key)
        {
            return m_Data[key].ToString();
        }

        public Command ParseCommand(string command, string type)
        {
            List<Command> commands = JsonConvert.DeserializeObject<List<Command>>(m_Data[command].ToString());
            return commands.Where(x => x.Type == type).SingleOrDefault();
        }


    }
}