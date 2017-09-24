using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type typeOfMission = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == difficultyLevel);

        IMission mission = (IMission)Activator.CreateInstance(typeOfMission, new object[] { neededPoints });

        return mission;
    }
}
