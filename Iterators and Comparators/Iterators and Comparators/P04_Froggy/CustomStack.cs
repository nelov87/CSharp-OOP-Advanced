using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Froggy
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private T[] items;
        

        public CustomStack(T[] itemsToArrange)
        {
            items = new T[itemsToArrange.Length];
            items = GetArrangedArray(itemsToArrange);
        }

        private T[] GetArrangedArray(T[] itemsToArrange)
        {
            int counter = 0;
            T[] tempArr = new T[itemsToArrange.Length];
            for (int i = 0; i < tempArr.Length; i++)
            {
                if ( i % 2 == 0)
                {
                    tempArr[counter] = itemsToArrange[i];
                    counter++;
                }
            }
            for (int i = tempArr.Length - 1; i > -1; i--)
            {
                if (i % 2 != 0)
                {
                    tempArr[counter] = itemsToArrange[i];
                    counter++;

                }
            }
            return tempArr;
        }

        public T[] GetItems()
        {
            return items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
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
