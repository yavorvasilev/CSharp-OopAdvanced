namespace RecyclingStation.BusinessLayer.Core
{
    using Factories;
    using WasteDisposal.Interfaces;

    public class RecyclingManager : IRecyclingStation
    {
        private IGarbageProcessor garbageProcessor;
        private IWasteFactory wasteFactory;

        private double capitalBalance;
        private double energyBalance;

        private double minimumEnergyBalance;
        private double minimumCapitalBalance;
        private string typeOfGarbage;

        private bool requirmentsAreSet;

        public RecyclingManager(IGarbageProcessor garbageProcessor, IWasteFactory wasteFactory)
        {
            this.garbageProcessor = garbageProcessor;
            this.wasteFactory = wasteFactory;
        }

        public string ChangeManagementRequirement(double minimumEnergyBalance, double minimumCapitalBalance, string typeOfGarbage)
        {
            this.minimumEnergyBalance = minimumEnergyBalance;
            this.minimumCapitalBalance = minimumCapitalBalance;
            this.typeOfGarbage = typeOfGarbage;

            this.requirmentsAreSet = true;

            return "Management requirement changed!";
        }


        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            if (this.requirmentsAreSet == true)
            {
                bool requirmentsAreSatisfied = true;
                if (this.typeOfGarbage == type)
                {
                    requirmentsAreSatisfied = this.capitalBalance >= minimumCapitalBalance 
                        && this.energyBalance >= this.minimumEnergyBalance;
                }

                if (requirmentsAreSatisfied == false)
                {
                    return "Processing Denied!";
                }
            }

            IWaste someWaste = this.wasteFactory.Create(name, weight, volumePerKg, type);

            IProcessingData processedData = this.garbageProcessor.ProcessWaste(someWaste);

            this.capitalBalance += processedData.CapitalBalance;
            this.energyBalance += processedData.EnergyBalance;

            return $"{(someWaste.Weight):f2} kg of {someWaste.Name} successfully processed!";
        }

        public string Status()
        {
            return $"Energy: {(this.energyBalance):f2} Capital: {(this.capitalBalance):f2}";
        }
    }
}
