namespace P01_Logger
{
    using System;

    using P01_Logger.Appenders;
    using P01_Logger.Appenders.Contracts;
    using P01_Logger.Core;
    using P01_Logger.Core.Contracts;
    using P01_Logger.Layouts;
    using P01_Logger.Layouts.Contracts;
    using P01_Logger.Loggers;
    using P01_Logger.Loggers.Contracts;
    using P01_Logger.Loggers.Enums;

    class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();

        }
    }
}
