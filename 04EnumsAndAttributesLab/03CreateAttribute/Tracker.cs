using _03CreateAttribute;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var startUp = typeof(Startup);
        var methods = startUp.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
            {
                var attrs = method.GetCustomAttributes(false);

                foreach (SoftUniAttribute attr in attrs)
                {
                    System.Console.WriteLine($"{method.Name} is writen by {attr.Name}");
                }    
            }
        }
    }
}
