namespace RecyclingStation
{
    using BusinessLayer.Core;
    using BusinessLayer.Factories;
    using BusinessLayer.IO;
    using System;
    using System.Collections.Generic;
    using WasteDisposal;
    using WasteDisposal.Interfaces;

    public class RecyclingStationMain
    {
        public  static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IDictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
            IStrategyHolder strategyHolder = new StrategyHolder(strategies);

            IGarbageProcessor garbageProcessor = new GarbageProcessor(strategyHolder);
            IWasteFactory wasteFactory = new WasteFactory();

            IRecyclingStation station = new RecyclingManager(garbageProcessor, wasteFactory);

            IEngine engine = new Engine(reader, writer, station);
            engine.Run();
        }
    }
}
