using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Generic_Box_of_String
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
