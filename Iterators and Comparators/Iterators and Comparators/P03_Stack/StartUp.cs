using System;
using System.Linq;

namespace P03_Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            CustomStack<int> cStack = new CustomStack<int>();

            while (input != "END")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string[] items = commands.Skip(1).Select(x => x.TrimEnd(',')).ToArray();
                
                int[] elementsToAdd = items.Select(int.Parse).ToArray();
                switch (command)
                {
                    case "Push":
                        foreach (int item in elementsToAdd)
                        {
                            cStack.Push(item);
                        }
                        break;
                    case "Pop":
                        try
                        {
                            cStack.Pop();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                }
                input = Console.ReadLine();
            }

            foreach (var item in cStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in cStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
