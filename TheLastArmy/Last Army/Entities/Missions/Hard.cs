public class Hard : Mission
{
    private const double EnduranceRequiredHard = 80;
    private const string MissionName = "Disposal of terrorists";
    private const double WearLevel = 70;

    public Hard(double scoreToComplete) 
        : base(MissionName, scoreToComplete, EnduranceRequiredHard, WearLevel)
    {
    }
}
