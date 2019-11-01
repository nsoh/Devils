using System;
using Devils.Generate;

namespace Devils
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.WriteLine("invalid args!!!");
                return;
            }

            switch(args[0])
            {
                case "new" : RunGenerateTask(args); break;
            }
        }


        static void RunGenerateTask(string[] args)
        {
            var handler = new TaskHandler<IGenerate>();
            handler.Add("service", new GenerateService());
            handler.Add("action", new GenerateAction());

            var task = handler.Find(args[1]);
            if(null == task)
            {
                Console.WriteLine("not found task. cmd:{0}", args[1]);
                return;
            }

            task.Run(args);
        }
    }
}
