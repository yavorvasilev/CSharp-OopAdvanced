namespace RecyclingStation.BusinessLayer.Strategies
{
    using WasteDisposal.Interfaces;

    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        protected abstract double CalculateEnergyBalance(IWaste waste);
        protected abstract double CalculateCapitalBalance(IWaste waste);


        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            double energyBalance = this.CalculateEnergyBalance(garbage);
            double capitalBalance = this.CalculateCapitalBalance(garbage);

            return new ProcessingData(energyBalance, capitalBalance);
        }
    }
}
