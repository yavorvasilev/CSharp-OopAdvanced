namespace RecyclingStation.BusinessLayer.Strategies
{
    using WasteDisposal.Interfaces;

    public class RecyclableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateCapitalBalance(IWaste waste)
        {
            double capitalEarned = waste.Weight * 400;
            double capitalUsed = 0;

            return capitalEarned - capitalUsed;
        }

        protected override double CalculateEnergyBalance(IWaste waste)
        {
            double energyProduced = 0;
            double energyUsed = waste.CalculateWasteTotalVolume() * 0.5;

            return energyProduced - energyUsed;
        }
    }
}
