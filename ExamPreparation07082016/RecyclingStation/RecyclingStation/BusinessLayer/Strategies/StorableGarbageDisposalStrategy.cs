namespace RecyclingStation.BusinessLayer.Strategies
{
    using WasteDisposal.Interfaces;

    public class StorableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateCapitalBalance(IWaste waste)
        {
            double capitalEarned = 0;
            double capitalUsed = waste.CalculateWasteTotalVolume() * 0.65;

            return capitalEarned - capitalUsed;
        }

        protected override double CalculateEnergyBalance(IWaste waste)
        {

            double energyProduced = 0;
            double energyUsed = waste.CalculateWasteTotalVolume() * 0.13;

            return energyProduced - energyUsed;
        }
    }
}
