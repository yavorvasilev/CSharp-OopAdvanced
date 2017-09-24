namespace RecyclingStation.BusinessLayer.Entities.Garbages
{
    using Attributes;
    using Strategies;

    [StorableStrategy(typeof(StorableGarbageDisposalStrategy))]
    public class StorableGarbage : Garbage
    {
        public StorableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }
    }
}
