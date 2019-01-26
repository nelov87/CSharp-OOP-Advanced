using System;
using System.Collections.Generic;
using System.Text;

namespace P02_GenericBoxOfInteger
{
    public class Box<T>
    {
        public T valueOfString;


        public Box()
        {

        }
        public Box(T text)
        {
            this.valueOfString = text;
        }

        public override string ToString()
        {
            return $"{this.valueOfString.GetType().FullName}: {this.valueOfString}";
        }
    }
}
