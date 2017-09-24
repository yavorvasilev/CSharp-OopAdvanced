namespace RecyclingStation.BusinessLayer.Entities.Garbages
{
    using System;
    using WasteDisposal.Interfaces;

    public abstract class Garbage : IWaste
    {
        private string name;
        private double volumePerKg;
        private double weight;

        public Garbage(string name, double weight, double volumePerKg)
        {
            this.Name = name;
            this.Weight = weight;
            this.VolumePerKg = volumePerKg;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public double VolumePerKg
        {
            get
            {
                return volumePerKg;
            }

            set
            {
                volumePerKg = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }

            set
            {
                weight = value;
            }
        }
    }
}
