using P01_Logger.Layouts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Layouts.Factory.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
