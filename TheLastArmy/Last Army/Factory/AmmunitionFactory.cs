using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type typeOfAmynition = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == ammunitionName);

        IAmmunition ammunition = (IAmmunition)Activator.CreateInstance(typeOfAmynition, new object[] { ammunitionName });

        return ammunition;
    }
}