using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P01_ListyIterator
{
    public class ListyIterator<T>
    {
        private T[] elements;
        private int index;

        public ListyIterator(T[] elements)
        {
            this.elements = elements;
            this.index = 0;
        }

        public bool Move()
        {
            if (this.index < elements.Length - 1)
            {
                this.index++;
                return true;
            }
            return false;
        } 

        public bool HasNext()
        {
            if (this.index == elements.Length - 1)
            {
                return false;
                
            }
            else if (this.index < elements.Length)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (elements.Length == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(elements[index]);
        }



    }
}
