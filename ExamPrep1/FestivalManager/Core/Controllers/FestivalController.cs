namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        

        private readonly ISetFactory setFactory;
        private readonly IStage stage;
        private readonly IInstrumentFactory instrumentFactory;

        public FestivalController(IStage stage, ISetFactory setFactory, IInstrumentFactory instrumentFactory)
        {
            this.stage = stage;
            this.setFactory = setFactory;
            this.instrumentFactory = instrumentFactory;
        }

        public string ProduceReport()
        {
            StringBuilder sb = new StringBuilder();

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            sb.AppendLine(($"Festival length: {FormatTimeSpanToString(totalFestivalLength)}"));

            foreach (var set in this.stage.Sets)
            {
                sb.AppendLine( ($"--{set.Name} ({FormatTimeSpanToString(set.ActualDuration)}):"));

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    sb.AppendLine(($"---{performer.Name} ({instruments})"));
                }

                if (!set.Songs.Any())
                    sb.AppendLine(("--No songs played"));
                else
                { 
                    sb.AppendLine(("--Songs played:"));
                    foreach (var song in set.Songs)
                    {
                        sb.AppendLine(($"----{song.Name} ({FormatTimeSpanToString(song.Duration)})"));
                    }
                }
            }

            return sb.ToString();
            
        }
        //works
        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string setTypeName = args[1];

            ISet set = this.setFactory.CreateSet(name, setTypeName);
            stage.AddSet(set);
            string result = $"Registered {setTypeName} set";
            return result;
        }
        //works
        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumentsNames = args.Skip(2).ToArray();

            var instruments = instrumentsNames
                .Select(instrumentTypeName => this.instrumentFactory.CreateInstrument(instrumentTypeName))
                .ToArray();

            IPerformer performer = new Performer(name, age);

            foreach (var instrument in instruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
            
        }

        public string RegisterSong(string[] args)
        {
            string songName = args[0];
            int[] sDTokens = args[1].Split(":").Select(int.Parse).ToArray();
            int songMinets = sDTokens[0];
            int songSecunds = sDTokens[1];
            TimeSpan songDuretion = new TimeSpan(0, songMinets, songSecunds);

            ISong song = new Song(songName, songDuretion);
            this.stage.AddSong(song);
            string result = $"Registered song {song}";
            return result;
        }

        //public string SongRegistration(string[] args)
        //{
        //    var songName = args[0];
        //    var setName = args[1];

        //    if (!this.stage.HasSet(setName))
        //    {
        //        throw new InvalidOperationException("Invalid set provided");
        //    }

        //    if (!this.stage.HasSong(songName))
        //    {
        //        throw new InvalidOperationException("Invalid song provided");
        //    }

        //    var set = this.stage.GetSet(setName);
        //    var song = this.stage.GetSong(songName);

        //    set.AddSong(song);

        //    return $"Added {song} to {set.Name}";
        //}

        //works
        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }



            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        //public string PerformerRegistration(string[] args)
        //{
            
        //}
        //works
        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }
        //works
        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song} to {set.Name}";
        }

        private string FormatTimeSpanToString(TimeSpan timeSpan)
        {
            int minuts = timeSpan.Hours * 60 + timeSpan.Minutes;
            int secunds = timeSpan.Seconds;

            string result = $"{minuts:d2}:{secunds:d2}";
            return result;
        }
    }
}