namespace RecyclingStation.BusinessLayer.Strategies
{
    using WasteDisposal.Interfaces;

    public static class WasteExtensionMethod
    {
        public static double CalculateWasteTotalVolume(this IWaste waste)
        {
            return waste.Weight * waste.VolumePerKg;
        }
    }
}
