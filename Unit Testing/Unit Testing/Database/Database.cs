using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseExample
{
    public class Database
    {
        private const int capacity = 16;
        private int[] data;
        private int index;

        public Database()
        {
            this.data = new int[capacity];
            this.index = -1;
        }

        public Database(int[] values) : this()
        {
            if (values.Length > 16)
            {
                throw new InvalidOperationException("Parameter is too long.");
            }

            for (int i = 0; i < values.Length; i++)
            {
                this.data[i] = values[i];

            }
            this.index = values.Length - 1;
        }

        public void Add(int value)
        {
            if (this.index < capacity - 1)
            {
                this.data[++this.index] = value;
                return;
            }

            throw new InvalidOperationException("Database is full!");
        }

        public void Remove()
        {
            if (this.index < 0)
            {
                throw new InvalidOperationException("Databese is empty!");
            }

            this.data[this.index] = 0;
            this.index--;
        }

        public int[] Fetch()
        {

            return this.data.Take(this.index + 1).ToArray();
        }
    }
}
