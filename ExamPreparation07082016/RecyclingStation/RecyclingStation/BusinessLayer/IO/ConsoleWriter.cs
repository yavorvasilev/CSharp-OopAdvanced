namespace RecyclingStation.BusinessLayer.IO
{
    using System;
    using System.Text;

    class ConsoleWriter : IWriter
    {
        private StringBuilder outputGatherer;

        public ConsoleWriter()
            :this(new StringBuilder())
        {

        }

        public ConsoleWriter(StringBuilder outputGatherer)
        {
            this.OutputGatherer = outputGatherer;
        }

        public StringBuilder OutputGatherer
        {
            get
            {
                return outputGatherer;
            }

            private set
            {
                outputGatherer = value;
            }
        }

        public void GatherOutput(string outputToGather)
        {
            this.OutputGatherer.AppendLine(outputToGather);
        }

        public void WriteGatheredOutput()
        {
            Console.WriteLine(this.OutputGatherer);
        }
    }
}
