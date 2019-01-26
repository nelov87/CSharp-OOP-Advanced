using System;
using System.Collections.Generic;

namespace P05_GenericCountMethodStrings
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> items = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                items.Add(input);
            }
            string compareTo = Console.ReadLine();
            Box<string> box = new Box<string>(items, compareTo);
            Console.WriteLine(box.GetCount());
        }
    }
}
