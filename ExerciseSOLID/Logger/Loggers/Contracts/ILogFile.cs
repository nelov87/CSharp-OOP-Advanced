using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Loggers.Contracts
{
    public interface ILogFile
    {
        void Write(string message);
        int Size { get; }
    }
}
