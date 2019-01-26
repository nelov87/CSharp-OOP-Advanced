using System;
using System.Linq;

namespace P02_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            CostumColection<string> listyIterator;
            string[] arrOne = input.Split();
            listyIterator = new CostumColection<string>(arrOne.Skip(1).ToArray());

            while (input != "END")
            {
                string[] arr = input.Split();
                string command = arr[0];
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "PrintAll":
                        try
                        {
                            listyIterator.PrintAll();
                        }
                        catch (InvalidOperationException io)
                        {
                            Console.WriteLine(io.Message);
                        }
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException io)
                        {
                            Console.WriteLine(io.Message);
                        }

                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
