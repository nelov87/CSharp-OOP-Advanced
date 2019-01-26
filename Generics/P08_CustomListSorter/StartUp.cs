namespace P08_CustomListSorter
{
    using System;


    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            CList<string> cList = new CList<string>();

            while (input != "END")
            {
                string[] arguments = input.Split();
                string command = arguments[0];

                switch (command)
                {
                    case "Add":
                        cList.Add(arguments[1]);
                        break;
                    case "Remove":
                        cList.Remove(int.Parse(arguments[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(cList.Contains(arguments[1]));
                        break;
                    case "Swap":
                        cList.Swap(int.Parse(arguments[1]), int.Parse(arguments[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(cList.CountGreaterThan(arguments[1]));
                        break;
                    case "Max":
                        Console.WriteLine(cList.Max());
                        break;
                    case "Min":
                        Console.WriteLine(cList.Min());
                        break;
                    case "Sort":
                        cList.Sort();
                        break;
                    case "Print":
                        foreach (var item in cList.GetList())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
