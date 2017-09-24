﻿namespace RecyclingStation.BusinessLayer.Factories
{
    using WasteDisposal.Interfaces;

    public interface IWasteFactory
    {
        IWaste Create(string name, double weight, double volumePerKg, string type);
    }
}
