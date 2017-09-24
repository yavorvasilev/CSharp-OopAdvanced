namespace RecyclingStation.BusinessLayer.IO
{
    public interface IWriter
    {
        void GatherOutput(string outputToGather);

        void WriteGatheredOutput();
    }
}
