using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private T[] items;
        private int masterCounter = 0;

        public CustomStack()
        {
            items = new T[1];
        }

        public void Push(T itemToAdd)
        {
            if (masterCounter == 0)
            {
                
                items[0] = itemToAdd;
                masterCounter++;
            }
            else
            {
                T[] tempArr = new T[items.Length + 1];
                for (int i = 0; i < items.Length; i++)
                {
                    tempArr[i] = items[i];
                }
                tempArr[tempArr.Length - 1] = itemToAdd;
                items = tempArr;
            }
            
            
        }
        public T Pop()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("No elements");
            }
            T lastItem = items[items.Length - 1];
            T[] tempArr = new T[items.Length - 1];
            tempArr = items.Take(items.Length - 1).ToArray();
            items = tempArr;
            return lastItem;
        }



        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.items.Length - 1; i > -1; i--)
            {
                yield return items[i];
            }
        }
            

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
