using System;
using System.Collections.Generic;

namespace P05_ComparingObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] arg = input.Split();
                string name = arg[0];
                int age = int.Parse(arg[1]);
                string town = arg[2];

                Person person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine()) - 1;

            int samePeople = 0;
            int difrentPeople = 0;
            int allPeople = people.Count;
            Person personToMatch = people[n];
            //people.RemoveAt(n);

            foreach (Person personn in people)
            {
                if (personToMatch.CompareTo(personn) != 0)
                {
                    difrentPeople++;
                }
                else
                {
                    samePeople++;
                }
            }

            if (samePeople > 1)
            {
                Console.WriteLine(samePeople + " " + difrentPeople + " " + allPeople);
            }
            else
            {
                Console.WriteLine("No matches");
            }

        }
    }
}
