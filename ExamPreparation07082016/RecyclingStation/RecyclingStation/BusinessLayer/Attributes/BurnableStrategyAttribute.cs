namespace RecyclingStation.BusinessLayer.Attributes
{
    using System;
    using WasteDisposal.Attributes;

    public class BurnableStrategyAttribute : DisposableAttribute
    {
        public BurnableStrategyAttribute(Type correspondingStrategyType) 
            : base(correspondingStrategyType)
        {
        }
    }
}
