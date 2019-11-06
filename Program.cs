using System;


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

            Config config = new Config("Config.json");
            Command command = config.ParseCommand(args[0], args[1]);
            command.Run(args);

        }
    }
}
