using System;
using System.Collections.Generic;

namespace P01_Generic_Box_of_String
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());
            

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                boxes.Add(box);
            }

            foreach (var boxIn in boxes)
            {
                Console.WriteLine(boxIn.ToString());
            }
        }
    }
}
