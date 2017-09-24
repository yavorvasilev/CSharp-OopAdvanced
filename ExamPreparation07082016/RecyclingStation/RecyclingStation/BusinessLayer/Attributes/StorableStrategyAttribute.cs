namespace RecyclingStation.BusinessLayer.Attributes
{
    using System;
    using WasteDisposal.Attributes;

    public class StorableStrategyAttribute : DisposableAttribute
    {
        public StorableStrategyAttribute(Type correspondingStrategyType) 
            : base(correspondingStrategyType)
        {
        }
    }
}
