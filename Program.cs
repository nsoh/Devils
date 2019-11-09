using System;
using Devils.Task;

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


            TaskHandler handler = new TaskHandler("task.config.json");
            if(handler.Run(args) == false)
            {
                Console.WriteLine("failed to init task handler.");
                return;
            }
        }
    }
}
