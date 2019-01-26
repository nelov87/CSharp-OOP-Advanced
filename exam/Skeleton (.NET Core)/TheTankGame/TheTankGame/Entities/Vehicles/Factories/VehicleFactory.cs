using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories.Contracts;

namespace TheTankGame.Entities.Parts.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        //public IVehicle CreateVehicle(string model, double weight, decimal price, int attack, int defense, int hitPoints, IAssembler assembler)
        //{
        //    var vehicleType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);

        //    var vehicleInstace = (IVehicle)Activator.CreateInstance(vehicleType);// if parameters use new Object

        //    return vehicleInstace;
        //}
        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            var vehicleTypeReflaction = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == vehicleType);

            var vehicleInstace = (IVehicle)Activator.CreateInstance(vehicleTypeReflaction, new object[] { model , weight, price, attack , defense , hitPoints, new VehicleAssembler() });// if parameters use new Object

            return vehicleInstace;
        }
    }
}
