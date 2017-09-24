namespace RecyclingStation.BusinessLayer.Attributes
{
    using System;
    using WasteDisposal.Attributes;

    public class RecyclableStrategyAttribute : DisposableAttribute
    {
        public RecyclableStrategyAttribute(Type correspondingStrategyType) 
            : base(correspondingStrategyType)
        {
        }
    }
}
