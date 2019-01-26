using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame.Entities.Parts.Factories
{
    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            var partTypeReflaction = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == partType);

            switch (partType)
            {
                case "Arsenal":
                    IAttackModifyingPart vehicleInstace = (IAttackModifyingPart)Activator.CreateInstance(partTypeReflaction, new object[] { model, weight, price, additionalParameter });// if parameters use new Object                    

                    return vehicleInstace;
                    
                case "Shell":
                    IDefenseModifyingPart vehicleInstacee = (IDefenseModifyingPart)Activator.CreateInstance(partTypeReflaction, new object[] { model, weight, price, additionalParameter });// if parameters use new Object                    
                    return vehicleInstacee;
                    
                case "Endurance":
                    IHitPointsModifyingPart vehicleInstaceee = (IHitPointsModifyingPart)Activator.CreateInstance(partTypeReflaction, new object[] { model, weight, price, additionalParameter });// if parameters use new Object                    
                    return vehicleInstaceee;
                default:
                    return null;
            }

            
        }
    }
}
