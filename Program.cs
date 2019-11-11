using System;
using Devils.Task;

namespace Devils
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if(args.Length < 1)
                {
                    throw new DevilException(DevilErrorCode.ErrorUnknown, 
                        "invalid args:{0}", string.Join(' ', args));
                }

                TaskHandler handler = new TaskHandler("task.config.json");
                handler.Run(args);
            } 
            catch(DevilException e)
            {
                Console.WriteLine("[error:{0}] message:{1}", e.ErrorCode, e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("[error] message:{0}", e.Message);
            }
        }
    }
}
