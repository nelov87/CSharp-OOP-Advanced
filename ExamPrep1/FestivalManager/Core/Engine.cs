
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;


	public class Engine : IEngine
	{
        private bool isRunning;
	    private IReader reader;
	    private IWriter writer;
        
		private IFestivalController festivalCоntroller;
		private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
		{
            this.isRunning = true;

			while (this.isRunning) // for job security
			{
				var input = reader.ReadLine();

				if (input == "END")
                {
                    this.isRunning = false;
                    continue;
                }

                string commandResult = "";

				try
				{
					
					commandResult = this.ProcessCommand(input);
					
				}
                catch(TargetInvocationException tie)
                {
                    commandResult = "ERROR: " + tie.InnerException.Message;
                }
				catch (Exception ex) // in case we run out of memory
				{
					commandResult = "ERROR: " + ex.Message;
				}

                this.writer.WriteLine(commandResult);

            }

			var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			var tokens = input.Split();

			var command = tokens.First();
			var parameters = tokens.Skip(1).ToArray();

            string result;


            if (command == "LetsRock")
			{
                result = this.setCоntroller.PerformSets();
			}
            else
            {
                MethodInfo festivalControlerMethod = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

                result = (string)festivalControlerMethod.Invoke(this.festivalCоntroller, new object[] { parameters });
            }
            
			return result;
		}
	}
}