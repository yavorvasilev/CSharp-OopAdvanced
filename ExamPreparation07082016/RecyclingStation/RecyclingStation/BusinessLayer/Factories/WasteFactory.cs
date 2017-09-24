namespace RecyclingStation.BusinessLayer.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using WasteDisposal.Interfaces;

    public class WasteFactory : IWasteFactory
    {
        private const string GarbageSuffix = "Garbage";

        public IWaste Create(string name, double weight, double volumePerKg, string type)
        {
            var fullTypeName = type + GarbageSuffix;

            Type typeOfGarbageToActivate = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(fullTypeName, StringComparison.OrdinalIgnoreCase));

            object[] typeArgs = new object[] { name, weight, volumePerKg};

            IWaste waste = (IWaste)Activator.CreateInstance(typeOfGarbageToActivate, new object[] { name, weight, volumePerKg });
            //IWaste waste = (IWaste)Activator.CreateInstance(typeOfGarbageToActivate, name, weight, volumePerKg );
            //IWaste waste = (IWaste)Activator.CreateInstance(typeOfGarbageToActivate, typeArgs);

            return waste;
        }
    }
}
