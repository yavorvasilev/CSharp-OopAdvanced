public class Easy : Mission
{
    private const double EnduranceRequiredEasy = 20;
    private const string MissionName = "Suppression of civil rebellion";
    private const double WearLevel = 30;

    public Easy(double scoreToComplete) 
        : base(MissionName, scoreToComplete, EnduranceRequiredEasy, WearLevel)
    {
    }
}
