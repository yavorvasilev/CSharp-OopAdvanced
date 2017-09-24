using System;

public abstract class Mission : IMission
{
    public Mission(string name, double scoreToComplete, double enduranceRequired, double wearLevelDecrement)
    {
        this.Name = name;
        this.ScoreToComplete = scoreToComplete;
        this.EnduranceRequired = enduranceRequired;
        this.WearLevelDecrement = wearLevelDecrement;
    }

    public string Name { get; }
    public double EnduranceRequired { get; }
    public double ScoreToComplete { get; }
    public double WearLevelDecrement { get; }
  
}
