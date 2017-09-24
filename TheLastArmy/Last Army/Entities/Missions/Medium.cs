class Medium : Mission
{
    private const double EnduranceRequiredMedium = 50;
    private const string MissionName = "Capturing dangerous criminals";
    private const double WearLevel = 50;

    public Medium(double scoreToComplete) : base(MissionName, scoreToComplete, EnduranceRequiredMedium, WearLevel)
    {
    }
}
