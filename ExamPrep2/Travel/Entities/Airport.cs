namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;

    public class Airport : IAirport
    {
        private List<IBag> checedBags;
        private List<IBag> confiscatedBag;
        private List<IPassenger> passengers;
        private List<ITrip> trips;

        public Airport()
        {
            this.checedBags = new List<IBag>();
            this.confiscatedBag = new List<IBag>();
            this.passengers = new List<IPassenger>();
            this.trips = new List<ITrip>();
        }

        public IReadOnlyCollection<IBag> CheckedInBags => this.checedBags.AsReadOnly();
        public IReadOnlyCollection<IBag> ConfiscatedBags => this.confiscatedBag.AsReadOnly();
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();
        public IReadOnlyCollection<ITrip> Trips => this.trips.AsReadOnly();

        public void AddCheckedBag(IBag bag)
        {
            this.checedBags.Add(bag);
        }

        public void AddConfiscatedBag(IBag bag)
        {
            this.confiscatedBag.Add(bag);
        }

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public void AddTrip(ITrip trip)
        {
            this.trips.Add(trip);
        }

        public IPassenger GetPassenger(string username)
        {
            return this.passengers.FirstOrDefault(p => p.Username == username);
        }

        public ITrip GetTrip(string id)
        {
            return this.trips.FirstOrDefault(t => t.Id == id);
        }
    }
}