namespace _08MilitaryElite.Interfaces
{
    using System.Collections.Generic;

    public interface ILeutenantGeneral : IPrivate
    {
        //IList<ISoldier> Soldiers { get; }
        List<ISoldier> Soldiers { get; }
    }
}
