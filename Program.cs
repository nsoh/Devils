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

            CommandExecutor cmdExecutor = new CommandExecutor();
            if(cmdExecutor.Parse("Command/command.config.json", args) == false)
            {
                Console.WriteLine("failed to parse command. {0}", string.Join(',', args));
                return;
            }

            cmdExecutor.Run();
        }
    }
}
