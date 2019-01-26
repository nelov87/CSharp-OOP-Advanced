using P01_Logger.Layouts.Contracts;
using P01_Logger.Layouts.Factory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Layouts.Factory
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            string typeAsLowerCase = type.ToLower();

            switch (typeAsLowerCase)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
                    
            }
        }
    }
}
