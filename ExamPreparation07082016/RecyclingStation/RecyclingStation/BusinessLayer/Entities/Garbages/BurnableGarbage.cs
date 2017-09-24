namespace RecyclingStation.BusinessLayer.Entities.Garbages
{
    using Attributes;
    using Strategies;

    [BurnableStrategy(typeof(BurnableGarbageDisposalStrategy))]
    public class BurnableGarbage : Garbage
    {
        public BurnableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }
    }
}
