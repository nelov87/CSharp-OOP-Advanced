namespace Travel.Core.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	using Entities;
	using Entities.Contracts;
	using Entities.Factories;
	using Entities.Factories.Contracts;
    using Travel.Entities.Items.Contracts;

    public class AirportController : IAirportController
	{
		private const int BagValueConfiscationThreshold = 3000;

		private IAirport airport;

		private IAirplaneFactory airplaneFactory;
		private IItemFactory itemFactory;

        
        public AirportController(IAirport airport)
		{
			this.airport = airport;
			this.airplaneFactory = new AirplaneFactory();
			this.itemFactory = new ItemFactory();
		}
        //works
        public string RegisterPassenger(string username)
        {
            if (this.airport.GetPassenger(username) != null)
            {
                throw new InvalidOperationException($"Passenger {username} already registered!");
            }

            Passenger passenger = new Passenger(username);

            this.airport.AddPassenger(passenger);

            return $"Registered {passenger.Username}";
        }

        //works
        public string RegisterTrip(string source, string destination, string planeType)
        {
            var airplane = airplaneFactory.CreateAirplane(planeType);

            var trip = new Trip(source, destination, airplane);

            this.airport.AddTrip(trip);

            return $"Registered trip {trip.Id}";
            
        }

        //works
        public string RegisterBag(string username, IEnumerable<string> bagItems)
		{
            IPassenger passenger = this.airport.GetPassenger(username);

            Entities.Items.Contracts.IItem[] items = bagItems.Select(i => itemFactory.CreateItem(i)).ToArray();
            Bag bag = new Bag(passenger, items);

            passenger.Bags.Add(bag);

            return $"Registered bag with {string.Join(", ", bagItems)} for {username}";
		}
        
        //
		public string CheckIn(string username, string tripId, IEnumerable<int> bagIndices)
		{
            IPassenger passenger = this.airport.GetPassenger(username);
            ITrip trip = airport.GetTrip(tripId);

            bool checkedIn = trip.Airplane.Passengers.Any(p => p.Username == username);
            if (checkedIn)
            {
                throw new InvalidOperationException($"{passenger.Username} is already checked in!");
            }

            int confiscatedBags = CheckInBags(passenger, bagIndices);
            trip.Airplane.AddPassenger(passenger);

            return $"Checked in {passenger.Username} with {bagIndices.Count() - confiscatedBags}/{bagIndices.Count()} checked in bags";
            
		}

		private int CheckInBags(IPassenger passenger, IEnumerable<int> bagsToCheckIn)
		{
            IList<IBag> bags = passenger.Bags;

            int confiscatedBagCount = 0;
			foreach (int bagNumber in bagsToCheckIn)
			{
                IBag currentBag = bags[bagNumber];
				bags.RemoveAt(bagNumber);

				if (ShouldConfiscate(currentBag))
				{
					airport.AddConfiscatedBag(currentBag);
					confiscatedBagCount++;
				}
				else
				{
					this.airport.AddCheckedBag(currentBag);
				}
			}

			return confiscatedBagCount;
		}

		private static bool ShouldConfiscate(IBag bag)
		{
            int luggageValue = 0;

			foreach(IItem item in bag.Items)
			{

                luggageValue += item.Value;
			}

            bool shouldConfiscate = luggageValue > BagValueConfiscationThreshold;
			return shouldConfiscate;
		}

		
	}
}