using System;
using System.Collections.Generic;
using System.Linq;

public class Army : IArmy
{
    private List<ISoldier> army;

    public Army()
    {
        this.army = new List<ISoldier>();
    }

    public IReadOnlyList<ISoldier> Soldiers
    {
        get
        {
            return this.army;
        }
    }

    public void AddSoldier(ISoldier soldier)
    {
        this.army.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        foreach (var soldier in this.army.Where(s => s.GetType().Name == soldierType))
        {
            soldier.Regenerate();
        }
    }
}
