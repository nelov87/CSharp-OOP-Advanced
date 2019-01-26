namespace P01_Logger.Appenders
{
    using System;
    
    using P01_Logger.Layouts.Contracts;
    using P01_Logger.Loggers.Enums;

    public class ConsoleAppender : Appender
    {
        //private readonly ILayout layout;
        

        public ConsoleAppender(ILayout layout) : base(layout)
        {
            
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                this.MessagesCount++;
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
            }
            
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesCount}";
        }

        //Appender type: ConsoleAppender, Layout type: SimpleLayout, Report level: CRITICAL, Messages appended: 2


    }
}
