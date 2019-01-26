using P01_Logger.Appenders.Contracts;
using P01_Logger.Layouts.Contracts;
using P01_Logger.Loggers.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        public ReportLevel ReportLevel { get; set; }
        private readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        protected ILayout Layout => this.layout;

        public int MessagesCount { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

       

    }
}
