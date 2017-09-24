using System.Collections.Generic;

public interface IWareHouse
{
    //IReadOnlyDictionary<IAmmunition, int> Amunition { get; }

    void AddAmmunitions(string amunition, int count);

    void EquipArmy(IArmy army);

    bool TryEquipSoldier(ISoldier soldier);
}
