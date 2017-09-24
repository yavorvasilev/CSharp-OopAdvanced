using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const int MaxValueEndurance = 100;
    private const int RegenerationValue = 10;

    private double endurance;
    private int age;
    private string name;
    private double experience;

    public Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = InitializeWeapons();
    }

    public IDictionary<string, IAmmunition> Weapons { get; }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            this.name = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        private set
        {
            this.age = value;
        }
    }

    public double Experience
    {
        get
        {
            return this.experience;
        }
        private set
        {
            this.experience = value;
        }
    }

    public double Endurance
    {
        get
        {
            return this.endurance;
        }
        protected set
        {
            this.endurance = value;
        }
    }

    public virtual double OverallSkill
    {
        get { return this.Experience + this.Age; }
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    public virtual void Regenerate()
    {
        this.Endurance += this.Age + RegenerationValue;

        if (this.Endurance > MaxValueEndurance)
        {
            this.Endurance = MaxValueEndurance;
        }
    }

    public void CompleteMission(IMission mission)
    {
        this.Endurance -= mission.EnduranceRequired;
        this.AmmunitionRevision(mission.WearLevelDecrement);
        this.Experience += mission.EnduranceRequired;
    }

    private IDictionary<string, IAmmunition> InitializeWeapons()
    {
        IDictionary<string, IAmmunition> weapons = new Dictionary<string, IAmmunition>();
        foreach (var weapon in this.WeaponsAllowed)
        {
            weapons.Add(weapon, null);
        }

        return weapons;
    }
}