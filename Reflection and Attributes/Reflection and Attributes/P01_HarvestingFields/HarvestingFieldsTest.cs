 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var type = typeof(HarvestingFields);

            string input = Console.ReadLine();

            while (input != "HARVEST")
            {
                switch (input)
                {
                    case "all":
                        var allFields = type.GetFields((BindingFlags)62);

                        foreach (var field in allFields)
                        {
                            

                            Console.WriteLine($"{GetAcsesModifier(field)} {field.FieldType.Name} {field.Name}");
                        }
                        break;
                    case "private":
                        var privateFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

                        foreach (var field in privateFields.Where(x => x.IsPrivate))
                        {
                            Console.WriteLine($"{GetAcsesModifier(field)} {field.FieldType.Name} {field.Name}");
                        }
                        break;
                    case "protected":
                        var protectedFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

                        foreach (var field in protectedFields.Where(x => x.IsFamily))
                        {
                            Console.WriteLine($"{GetAcsesModifier(field)} {field.FieldType.Name} {field.Name}");
                        }
                        break;
                    case "public":
                        var publicFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                        foreach (var field in publicFields.Where(x => x.IsPublic))
                        {
                            Console.WriteLine($"{GetAcsesModifier(field)} {field.FieldType.Name} {field.Name}");
                        }
                        break;
                }

                input = Console.ReadLine();
            }
        }

        private static string GetAcsesModifier(FieldInfo field)
        {
            if (field.IsPrivate)
            {
                return "private";
            }
            else if (field.IsFamily)
            {
                return "protected";
            }
            else
            {
                return "public";
            }
        }
    }
}
