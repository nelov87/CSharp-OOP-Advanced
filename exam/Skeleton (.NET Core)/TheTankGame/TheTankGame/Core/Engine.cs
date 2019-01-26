namespace TheTankGame.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Contracts;
    using IO.Contracts;
    using System.Linq;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = true;
        }

        public void Run()
        {
            while (this.isRunning)
            {
                var input = this.reader.ReadLine();
                List<string> argumets = input.Split().ToList();

                if (input == "Terminate")
                {
                    this.isRunning = false;
                }

                try
                {

                    var result = this.commandInterpreter.ProcessInput(argumets);
                    this.writer.WriteLine(result);
                }
                catch (System.InvalidOperationException ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }
        }
    }
}