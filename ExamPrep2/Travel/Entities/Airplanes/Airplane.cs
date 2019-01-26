namespace Travel.Entities.Airplanes
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Linq;
	using Entities.Contracts;
    using Travel.Entities.Airplanes.Contracts;

    // migrated from java. please do the needful kind sir
    public abstract class Airplane : IAirplane
    {
		private List<IBag> baggageCompartment;
		private List<IPassenger> passengers;

		public Airplane(int seats, int baggageCompartments)
        {
			this.passengers = new List<IPassenger>();
			this.Seats = seats;
			this.BaggageCompartments = baggageCompartments;
			this.baggageCompartment = new List<IBag>();
		}

        public int BaggageCompartments { get; private set; }
        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();
        public bool IsOverbooked => this.Passengers.Count > this.Seats;
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();
        public int Seats { get; private set; }


        public void AddPassenger(IPassenger passenger) 
        {
			this.passengers.Add(passenger);
		}

		public IPassenger RemovePassenger(int seat)
        {
            var passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);
            
			return passenger;
		}

		public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger) {
			var passengerBags = this.baggageCompartment
				.Where(b => b.Owner == passenger)
				.ToArray();

			foreach (var bag in passengerBags)
            {
                this.baggageCompartment.Remove(bag);
            }
				

			return passengerBags;
		}

		public void LoadBag(IBag bag)
        {
            bool isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments;
			if (isBaggageCompartmentFull)
				throw new InvalidOperationException($"No more bag room in {this.GetType().ToString()}!");

			this.baggageCompartment.Add(bag);
		}
	}
}