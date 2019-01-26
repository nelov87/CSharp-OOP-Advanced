using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Loggers.Contracts
{
    public interface ILogger
    {
        void Error(string dateTime, string errorMessage);
        void Info(string dateTime, string errorInfo);
    }
}
