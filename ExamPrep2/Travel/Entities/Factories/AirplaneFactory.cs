namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using Travel.Entities.Airplanes;
    using System.Reflection;
    using System.Linq;
    using System;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            var airplaneType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);

            var airplaneInstance = (IAirplane)Activator.CreateInstance(airplaneType);// if parameters use new Object

            return airplaneInstance;

			//switch (type)
			//{
			//	case "LightAirplane":
			//		return new LightAirplane();
			//	case "MediumAirplane":
			//		return new MediumAirplane();
			//	default:
			//		return null;
			//}
		}
	}
}