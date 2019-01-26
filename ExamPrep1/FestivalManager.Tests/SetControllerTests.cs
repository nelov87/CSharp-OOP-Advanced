// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void SetControllerShouldReturnFailMassege()
	    {
            ISet set = new Short("Set1");
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);
            stage.AddSet(set);
            string actualResult = setController.PerformSets();
            string expectedResult = "1. Set1:\r\n-- Did not perform";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
		}

        [Test]
	    public void SetControllerShouldReturnSucessMassege()
	    {
            ISet set = new Short("Set1");
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);
            IPerformer performer = new Performer("Ivo", 30);
            IInstrument instrument = new Guitar();
            performer.AddInstrument(instrument);
            
            ISong song = new Song("Song 1", new TimeSpan(0, 03, 00));
            set.AddSong(song);
            set.AddPerformer(performer);
            stage.AddPerformer(performer);
            stage.AddSet(set);
            string actualResult = setController.PerformSets();
            string expectedResult = "1. Set1:\r\n-- 1. Song 1 (03:00)\r\n-- Set Successful";
            
            Assert.That(actualResult, Is.EqualTo(expectedResult));
		}

        [Test]
        public void PerformSetShouldDecreaseWear()
        {
            ISet set = new Short("Set1");
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);
            IPerformer performer = new Performer("Ivo", 30);
            IInstrument instrument = new Guitar();
            double initialWear = instrument.Wear;
            performer.AddInstrument(instrument);

            ISong song = new Song("Song 1", new TimeSpan(0, 03, 00));
            set.AddSong(song);
            set.AddPerformer(performer);
            stage.AddPerformer(performer);
            stage.AddSet(set);
            setController.PerformSets();
            double afterWear = instrument.Wear;

            Assert.That(afterWear, Is.LessThan(initialWear));

            
        }
	}
}