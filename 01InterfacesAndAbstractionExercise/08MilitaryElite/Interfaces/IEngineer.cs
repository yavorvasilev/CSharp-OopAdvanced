namespace _08MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    public interface IEngineer : ISpecialisedSoldier
    {
        //IList<IRepair> Repairs { get; }
        List<IRepair> Repairs { get; }
    }
}
