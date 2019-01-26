namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);
            //ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(int) });
            BlackBoxInteger instance = (BlackBoxInteger)Activator.CreateInstance(type, true);
            

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split("_");
                string command = tokens[0];
                int data = int.Parse(tokens[1]);

                var method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).First(m => m.Name == command);
                method.Invoke(instance, new object[] { data});
                var fieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.Name == "innerValue").GetValue(instance);
                
                Console.WriteLine(fieldInfo);

                

                input = Console.ReadLine();

            }
            
        }
    }
}
