using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Devils.Task;
using Devils.Parser;


namespace Devils
{
    class TaskHandler
    {
        static readonly string beginDelimiter = "${";
         static readonly string endDelimiter = "}";
       
        JsonConfig m_Config;

        Dictionary<string, BaseParser> m_Parsers;

        public TaskHandler(string configFile)
        {
            m_Config = new JsonConfig(configFile);
            m_Parsers = new Dictionary<string, BaseParser>
            {
                {"command", new CommandParser()},
                {"config", new ConfigParser()},
                {"proto", new ProtoParser()},
          };
        }

        public bool Run(string[] args)
        {
            // create task
            BaseTask[] tasks = CreateTask(args[0], args[1]);


            // parsing task's context
            if(ParseContext(tasks, args) == false)
            {
                return false;
            }


            // run task
            foreach(var t in tasks)
            {
                t.Run();
            }            

            return true;
        }


        BaseTask[] CreateTask(string command, string name)
        {
            JArray cmdArray = JArray.Parse(m_Config.Parse(command));
            JObject cmdObject = cmdArray.Children<JObject>()
                .FirstOrDefault(o => o["name"] != null && o["name"].ToString() == name);


            if(cmdObject == null)
            {
                return null;
            }


            string taskText = cmdObject["tasks"].ToString();
            JArray taskArray = JArray.Parse(taskText);


            List<BaseTask> resultTasks = new List<BaseTask>(); 
            foreach(var tObj in taskArray)
            {
                string typeValue = tObj["type"].ToString();
                switch(typeValue)
                {
                    case "process" : 
                    {
                        resultTasks.Add(JsonConvert.DeserializeObject<ProcessTask>(tObj.ToString()));
                    }
                    break;
                    case "generate" : 
                    {
                        resultTasks.Add(JsonConvert.DeserializeObject<GenerateTask>(tObj.ToString()));
                    }
                    break;
                    case "proto" : 
                    {
                        resultTasks.Add(JsonConvert.DeserializeObject<RestoreTask>(tObj.ToString()));
                    }
                    break;
                }
            }

            return resultTasks.ToArray();
        }


        bool ParseContext(BaseTask[] tasks, string[] args)
        {
            string[] outText = null;
            foreach(var t in tasks)
            {
                t.FilePath = ParseTaskContext(t, t.FilePath, args, out outText);
                
                List<string> resultText = new List<string>();
                for(var i = 0; i < t.Parameters.Length; i++)
                {
                    string tempText = ParseTaskContext(t, t.Parameters[i], args, out outText);
                    if(outText != null)
                    {
                        resultText.AddRange(outText);
                    }
                    else
                    {
                        resultText.Add(tempText);
                    }
                }

                t.Parameters = resultText.ToArray();
            }

            return true;
        }

        string ParseTaskContext(BaseTask task, string text, string[] args, out string[] outText)
        {
            outText = null;
            string[] contexts = m_Config.ExtractContext(text, beginDelimiter, endDelimiter);
            if(contexts.Length == 0)
            {
                return text;
            }

            string resultText = text;
            List<string> resultContexts = new List<string>();
            foreach(var ctx in contexts)
            {
                string[] words = ctx.Split(':');
                if(words.Length < 2)
                {
                    return null;
                }
               
                BaseParser parser;
                if(m_Parsers.TryGetValue(words[0], out parser) == false)
                {
                    return null;
                }

                resultText = parser.Run(task, resultText, words, args, out outText);
            }

            return resultText;
        }
    }
}