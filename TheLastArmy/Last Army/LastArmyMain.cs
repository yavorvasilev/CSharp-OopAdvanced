using System.Collections.Generic;

public class LastArmyMain
{
    public static void Main()
    {
        //List<ISoldier> armyColection = new List<ISoldier>();
        //Dictionary<string, int> warehouseColection = new Dictionary<string, int>();
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        ISoldierFactory soldierFactory = new SoldierFactory();
        IAmmunitionFactory ammunitionFactory = new AmmunitionFactory();
        IMissionFactory missionFactory = new MissionFactory();
        IArmy army = new Army();
        IWareHouse warehouse = new WareHouse();
        GameController gameController = new GameController(army, warehouse, soldierFactory, ammunitionFactory, missionFactory, writer);
        IEngine engine = new Engine(reader, writer, gameController);
        engine.Run();

    }
}