using System;
using System.Linq;

namespace P04_Froggy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            CustomStack<int> cStack = new CustomStack<int>(input);

            Console.WriteLine(string.Join(", ", cStack.GetItems()));
        }
    }
}
