using System;
using System.Collections.Generic;
using Devils.Task;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Devils.Parser
{
    class ProtoParser : BaseParser
    {
        static readonly string delimiter = "${proto:";


        public override string Run(BaseTask task, string text, string[] ctx, string[] args, out string[] outText)
        {
            outText = null;
            JsonConfig config = new JsonConfig(task.FilePath);
            JObject jObject = config.ParseJObject(ctx[0]);
            JArray jArray = JArray.Parse(jObject[ctx[1]].ToString());

            List<string> resultText = new List<string>();
            foreach(var jObj in jArray)
            {
                string v = jObj["var"].ToString();
                string type = jObj["type"].ToString();
                string comment = jObj["comment"].ToString();


                string tempText = ReplaceText(text, delimiter, ctx[1], type + " " + v);
                resultText.Add(tempText + " " + comment);
            }

            outText = resultText.ToArray();
            return null;
        }
    }
}