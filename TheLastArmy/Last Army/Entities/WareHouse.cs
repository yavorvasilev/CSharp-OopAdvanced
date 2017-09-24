using System;
using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private Dictionary<string, int> wareHouse;
    private IAmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.wareHouse = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }


    //public IReadOnlyDictionary<IAmmunition, int> Amunition
    //{
    //    get
    //    {
    //        return this.wareHouse;
    //    }
    //}

    public void AddAmmunitions(string amunition, int count)
    {
        if (!this.wareHouse.ContainsKey(amunition))
        {
            this.wareHouse[amunition] = 0;
        }
        this.wareHouse[amunition] += count;
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        IDictionary<string, IAmmunition> allowdWeapons = soldier.Weapons;
        List<string> missingWeapons = allowdWeapons.Where(w => w.Value == null).Select(w => w.Key).ToList();

        foreach (var weapon in missingWeapons)
        {
            if (this.wareHouse.ContainsKey(weapon) && this.wareHouse[weapon] > 0)
            {
                var currentWeapon = this.ammunitionFactory.CreateAmmunition(weapon);
                soldier.Weapons[weapon] = currentWeapon;
                this.wareHouse[weapon]--;
            }
            else
            {
                return false;
            }
        }

        return true;

    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }
}
