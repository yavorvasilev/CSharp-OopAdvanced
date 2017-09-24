using System;

public abstract class Ammunition : IAmmunition
{
    private const int WearLevelMiltiplier = 100;

    public Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = this.Weight * WearLevelMiltiplier;
    }

    public string Name { get; }

    public double WearLevel { get; private set; }

    public double Weight { get; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}
