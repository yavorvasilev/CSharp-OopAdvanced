namespace _08MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    public interface ICommando : ISpecialisedSoldier
    {
        //IList<IMission> Missions { get; }
        List<IMission> Missions { get; }
    }
}
