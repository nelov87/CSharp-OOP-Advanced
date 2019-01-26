using P01_Logger.Appenders.Contracts;
using P01_Logger.Appenders.Factory.Contracts;
using P01_Logger.Layouts.Contracts;
using P01_Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Appenders.Factory
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLowerCase = type.ToLower();
            switch (typeAsLowerCase)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
