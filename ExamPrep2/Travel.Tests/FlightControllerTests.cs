// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING

namespace Travel.Tests
{
	using NUnit.Framework;
    //using Travel.Core.Controllers;
    //using Travel.Entities;
    //using Travel.Entities.Airplanes;
    //using Travel.Entities.Airplanes.Contracts;
    //using Travel.Entities.Contracts;
    //using Travel.Entities.Items;

    [TestFixture]
    public class FlightControllerTests
    {
	    [Test]
	    public void TestIsTakeOffMethodWorkCorectly()
	    {
            
            Airport airport = new Airport();
            var airplane = new LightAirplane();
            
            var passenger = new Passenger("Gosho");

            var passengers = new Passenger[10];

            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Passenger("Gosho" + i);
                airplane.AddPassenger(passengers[i]);

            }

            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                {
                    var bag = new Bag(passengers[i], new Item[] { new Colombian() });
                    passengers[i].Bags.Add(bag);
                }
                else
                {
                    var bag = new Bag(passengers[i], new Item[] { new Toothbrush() });
                    passengers[i].Bags.Add(bag);
                }

            }

            var trip = new Trip("Tuk", "Tam", airplane);
            var completedTrip = new Trip("Tam", "Tuk", new MediumAirplane());
            airport.AddTrip(trip);
            completedTrip.Complete();
            airport.AddTrip(completedTrip);
            FlightController flightController = new FlightController(airport);

            var actualResult = flightController.TakeOff();
            var expectedResult = "TukTam1:\r\nOverbooked! Ejected Gosho1, Gosho0, Gosho3, Gosho7, Gosho8\r\nConfiscated 3 bags ($50006)\r\nSuccessfully transported 5 passengers from Tuk to Tam.\r\nConfiscated bags: 3 (3 items) => $50006";

            Assert.AreEqual(actualResult, expectedResult);
            Assert.AreEqual(trip.IsCompleted, true);


        }
    }
}
