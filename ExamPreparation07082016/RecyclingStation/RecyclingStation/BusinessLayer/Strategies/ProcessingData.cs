namespace RecyclingStation.BusinessLayer.Strategies
{
    using WasteDisposal.Interfaces;

    class ProcessingData : IProcessingData
    {
        public ProcessingData(double energyBalance, double capitalBalance)
        {
            this.CapitalBalance = capitalBalance;
            this.EnergyBalance = energyBalance;
        }

        public double CapitalBalance { get; }
        public double EnergyBalance { get; }
    }
}
