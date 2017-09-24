namespace RecyclingStation.BusinessLayer.Core
{
    using IO;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine : IEngine
    {
        private const string TerminatingCommand = "TimeToRecycle";

        private IReader reader;
        private IWriter writer;
        private IRecyclingStation recyclingStation;

        public Engine(IReader reader, IWriter writer, IRecyclingStation recyclingStation)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.RecyclingStation = recyclingStation;
        }

        private IWriter Writer
        {
            get
            {
                return writer;
            }

            set
            {
                writer = value;
            }
        }
        private IReader Reader
        {
            get
            {
                return reader;
            }

            set
            {
                reader = value;
            }
        }

        public IRecyclingStation RecyclingStation
        {
            get
            {
                return recyclingStation;
            }

            set
            {
                recyclingStation = value;
            }
        }

        public void Run()
        {
            string inputLine;
            while ((inputLine = this.Reader.ReadLine()) != TerminatingCommand)
            {
                var commandArgs = inputLine.Split();
                var methodName = commandArgs[0];
                string[] methodNonParsedParams = null;

                if (commandArgs.Length == 2)
                {
                    methodNonParsedParams = commandArgs[1].Split('|');
                }


                MethodInfo[] recyclingStationMethods = this.RecyclingStation.GetType().GetMethods();

                MethodInfo methodToInvoke = recyclingStationMethods
                    .FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                ParameterInfo[] methodParams = methodToInvoke.GetParameters();

                object[] parsedParams = new object[methodParams.Length];

                for (int currentConvertion = 0; currentConvertion < methodParams.Length; currentConvertion++)
                {
                    Type currentParamType = methodParams[currentConvertion].ParameterType;
                    string toConvert = methodNonParsedParams[currentConvertion];
                    parsedParams[currentConvertion] = Convert.ChangeType(toConvert, currentParamType);
                    
                }

                var result = methodToInvoke.Invoke(this.RecyclingStation, parsedParams);

                this.Writer.GatherOutput(result.ToString());
            }
            this.Writer.WriteGatheredOutput();
        }
    }
}
