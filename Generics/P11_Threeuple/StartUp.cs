﻿using System;

namespace P11_Threeuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            Tuple<string, string, string> tuple1 = new Tuple<string, string, string>(input[0] + " " + input[1], input[2], input[3]);
            Console.WriteLine(tuple1);

            input = Console.ReadLine().Split();
            Tuple<string, int, bool> tuple2 = new Tuple<string, int, bool>(input[0], int.Parse(input[1]), input[2] == "drunk" ? true : false);
            Console.WriteLine(tuple2);

            input = Console.ReadLine().Split();
            Tuple<string, double, string> tuple3 = new Tuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
            Console.WriteLine(tuple3);
        }
    }
}
