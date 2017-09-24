namespace RecyclingStation.BusinessLayer.Strategies
{
    using WasteDisposal.Interfaces;

    public class BurnableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        protected override double CalculateCapitalBalance(IWaste waste)
        {
            double capitalEarned = 0;
            double capitalUsed = 0;

            return capitalEarned - capitalUsed;
        }

        protected override double CalculateEnergyBalance(IWaste waste)
        {
            double energyProduced = waste.CalculateWasteTotalVolume() * 1;
            double energyUsed = waste.CalculateWasteTotalVolume() * 0.2;

            return energyProduced - energyUsed;
        }
    }
}
