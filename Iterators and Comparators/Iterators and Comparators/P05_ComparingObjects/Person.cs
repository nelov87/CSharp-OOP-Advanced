using System;
using System.Collections.Generic;
using System.Text;

namespace P05_ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private string town;
        private int age;

        public Person( string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo(Person otherPerson)
        {
            if (this.name.CompareTo(otherPerson.name) != 0)
            {
                return this.name.CompareTo(otherPerson.name);
            }

            if (this.age.CompareTo(otherPerson.age) != 0)
            {
                return this.age.CompareTo(otherPerson.age);
            }

            return this.town.CompareTo(otherPerson.town);
        }

        
    }
}
