using System;
using Devils.Task;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Devils.Parser
{
    class ProtoParser : BaseParser
    {
        static readonly string delimiter = "${proto:";


        public override string[] Run(BaseTask task, string text, string[] ctx, string[] args)
        {
            JsonConfig config = new JsonConfig(task.FilePath);
            JObject jObject = config.ParseJObject(ctx[1]);
            JArray jArray = JArray.Parse(jObject[ctx[2]].ToString());
            foreach(var jObj in jArray)
            {
                string v = jObj["var"].ToString();
                string type = jObj["type"].ToString();
                string comment = jObj["comment"].ToString();
            }

            return new string[]{ text };
        }
    }
}