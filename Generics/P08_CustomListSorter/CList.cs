namespace P08_CustomListSorter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class CList<T> where T : IComparable
    {
        private List<T> items;

        public CList()
        {
            this.items = new List<T>();
        }

        public void Add(T itemToAdd)
        {
            this.items.Add(itemToAdd);
        }

        public T Remove(int index)
        {
            T itemToReturn = items[index];
            items.RemoveAt(index);
            return itemToReturn;
        }

        public bool Contains(T element)
        {
            if (items.Contains(element))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Swap(int index1, int index2)
        {
            T firstItem = items[index1];
            T secondItem = items[index2];
            items[index1] = secondItem;
            items[index2] = firstItem;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;
            foreach (var item in items)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {

            return items.Max();
        }

        public T Min()
        {
            return items.Min();
        }

        public void Sort()
        {
            this.items.Sort();
        }

        public IEnumerable<T> GetList()
        {
            return this.items;
        }
    }
}
