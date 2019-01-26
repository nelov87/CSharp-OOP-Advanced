namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{

            var itemType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);

            var itemInstance = (IItem)Activator.CreateInstance(itemType);// if parameters use new Object

            return itemInstance;


            //switch (type)
            //{
            //	//case "Item":
            //	//	return new Item();
            //	case "CellPhone":
            //		return new CellPhone();
            //	case "Colombian":
            //		return new Colombian();
            //	case "Jewelery":
            //		return new Jewelery();
            //	case "Laptop":
            //		return new Laptop();
            //	case "Toothbrush":
            //		return new Toothbrush();
            //	case "TravelKit":
            //		return new TravelKit();
            //	default:
            //		return null;
            //}
        }
	}
}
