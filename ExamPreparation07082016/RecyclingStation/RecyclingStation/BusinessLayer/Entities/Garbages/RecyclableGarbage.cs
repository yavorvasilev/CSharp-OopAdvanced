﻿namespace RecyclingStation.BusinessLayer.Entities.Garbages
{
    using Attributes;
    using Strategies;

    [RecyclableStrategy(typeof(RecyclableGarbageDisposalStrategy))]
    public class RecyclableGarbage : Garbage
    {
        public RecyclableGarbage(string name, double weight, double volumePerKg) 
            : base(name, weight, volumePerKg)
        {
        }
    }
}
