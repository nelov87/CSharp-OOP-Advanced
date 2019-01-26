using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace P02_Collection
{
    public class CostumColection<T> : IEnumerable<T>
    {
        private T[] elements;
        private int index;

        public CostumColection(T[] elements)
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

        public void PrintAll()
        {
            if (elements.Length == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(string.Join(" ", elements));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.elements)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
