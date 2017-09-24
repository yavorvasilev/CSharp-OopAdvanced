using System;
using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplier = 3.5;
    private const int MaxValueEndurance = 100;
    private const int RegenerationValue = 30;
    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed
    {
        get
        {
            return this.weaponsAllowed;
        }
    }

    public override void Regenerate()
    {
        this.Endurance = this.Age + RegenerationValue;
        if (this.Endurance > MaxValueEndurance)
        {
            this.Endurance = MaxValueEndurance;
        }
    }

    public override double OverallSkill
    {
        get
        {
            return base.OverallSkill * OverallSkillMiltiplier;
        }
    }
}
