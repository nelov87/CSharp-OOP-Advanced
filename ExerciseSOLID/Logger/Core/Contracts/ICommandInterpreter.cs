using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddApender(string[] args);
        void AddMessages(string[] args);
        void PrintInfo();
    }
}
