namespace P01_Logger.Appenders.Contracts
{
    using P01_Logger.Loggers.Enums;

    public interface IAppender
    {
        void Append(string dateTime, ReportLevel reportLevel, string message);

        ReportLevel ReportLevel { get; set; }

        int MessagesCount { get;}
    }
}
