using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GenericCountMethodStrings
{
    public class Box<T> where T : IComparable
    {
        private List<T> itemsList;
        private int count;


        public Box()
        {
            itemsList = new List<T>();
            count = 0;
        }
        public Box(List<T> items, string compareTo) : this()
        {
            itemsList = items;

            foreach (var item in itemsList)
            {
                if (item.CompareTo(compareTo) > 0)
                {
                    count++;
                }
            }

        }

        public int GetCount()
        {
            return count;
        }

        
    }
}
