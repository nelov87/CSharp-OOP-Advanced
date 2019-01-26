using System;
using System.Linq;

namespace P01_ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            ListyIterator<string> listyIterator;
            string[] arrOne = input.Split();
            listyIterator = new ListyIterator<string>(arrOne.Skip(1).ToArray());

            while (input != "END")
            {
                string[] arr = input.Split();
                string command = arr[0];
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
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
