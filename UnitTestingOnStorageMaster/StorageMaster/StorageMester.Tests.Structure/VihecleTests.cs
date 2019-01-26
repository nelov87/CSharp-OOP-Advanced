using NUnit.Framework;
using StorageMaster;
using System;
using System.Linq;
using System.Collections.Generic;
using StorageMaster.Entities.Products;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class VihecleTests
    {

        [Test]
        public void ValidateAllVehicles()
        {
            var types = new[]
            {
                "Semi",
                "Truck",
                "Van",
                "Vehicle"
            };

            foreach (var type in types)
            {
                var curentType = GetType(type);

                Assert.That(curentType, Is.Not.Null, $"{type} does`t exists.");
            }
        }

        [Test]
        public void ValidateVehicelProperties()
        {
            var vehicelType = GetType("Vehicle");

            var actualProperties = vehicelType.GetProperties();

            var expectedProperties = new Dictionary<string, Type>()
            {
                { "Capacity", typeof(int)},
                { "Trunk", typeof(IReadOnlyCollection<Product>)},
                { "IsFull", typeof(bool)},
                { "IsEmpty", typeof(bool)}
            };
                
                //new[] { "Capacity", "Trunk", "IsFull", "IsEmpty" };

            foreach (var actualPropertie in actualProperties)
            {
                var isValidPropertie = expectedProperties.Any(x => x.Key == actualPropertie.Name && actualPropertie.PropertyType == x.Value);

                Assert.That(isValidPropertie, $"{actualPropertie.Name} does not exists!");
            }
        }

        [Test]
        public void ValidateVehicleMethods()
        {
            var vehicleType = GetType("Vehicle");

            var expectedMethods = new List<Method>
            {
                new Method(typeof(void), "LoadProduct", typeof(Product)),
                new Method(typeof(Product), "Unload")
            };

            var actualMethods = vehicleType.GetMethods();

            foreach (var actualMethod in actualMethods)
            {
                var actualRetyrnType = actualMethod.ReturnType;
                var actualName = actualMethod.Name;
                var actualParams = actualMethod.GetParameters();

                var expeMethod = expectedMethods.FirstOrDefault(x => x.Name == actualName);

                var test = expeMethod.ReturnType == actualRetyrnType;
                var isValidReturnType = expeMethod.InputParameters.Any(x => x.Name == actualRetyrnType.Name);
                Assert.That(expeMethod, Is.Not.Null, $"{expeMethod.Name} does not exists.");
                Assert.That(isValidReturnType, $"{actualMethod.Name}Invalid returnType");

                foreach (var actualParam in actualParams)
                {
                    var isValidParams = expeMethod.InputParameters.Any(x => x.Name == actualParam.Name);
                    Assert.That(isValidParams, "Mising Parameters");
                    
                }
            }
        }





        private Type GetType(string type)
        {
            var targetType = typeof(StartUp).Assembly.GetTypes().FirstOrDefault(x => x.Name == type);
            return targetType;
        }

        private class Method
        {
            public Method(Type returnType, string name, params Type[] inputParameters)
            {
                this.Name = name;
                this.ReturnType = returnType;
                this.InputParameters = inputParameters;
            }

            public string Name { get; set; }
            public Type ReturnType { get; set; }
            public Type[] InputParameters { get; set; }
        }
    }
}
