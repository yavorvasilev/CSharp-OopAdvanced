namespace _02BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Startup
    {
        public static void Main()
        {
            var classType = Type.GetType("_02BlackBoxInteger.BlackBoxInt");
            var classInstance = Activator.CreateInstance(classType, true);
            var classMethods = classType.GetMethods(BindingFlags.Instance 
                | BindingFlags.NonPublic 
                | BindingFlags.Public 
                | BindingFlags.Static);
            var classField = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault();

            //var classConstructor = classType.GetConstructor(new Type[] );

            string commandInfo;

            while ((commandInfo = Console.ReadLine()) != "END")
            {
                var commandTokens = commandInfo.Split('_');

                var command = commandTokens[0];
                var param = int.Parse(commandTokens[1]);

                switch (command)
                {
                    case "Add":
                        var addMethod = classMethods.Where(m => m.Name == "Add").FirstOrDefault();
                        addMethod.Invoke(classInstance, new object[] { param });
                        Console.WriteLine(classField.GetValue(classInstance));
                        break;
                    case "Subtract":
                        var subtractMethod = classMethods.Where(m => m.Name == "Subtract").FirstOrDefault();
                        subtractMethod.Invoke(classInstance, new object[] { param });
                        Console.WriteLine(classField.GetValue(classInstance));
                        break;
                    case "Multiply":
                        var multiplyMethod = classMethods.Where(m => m.Name == "Multiply").FirstOrDefault();
                        multiplyMethod.Invoke(classInstance, new object[] { param });
                        Console.WriteLine(classField.GetValue(classInstance));
                        break;
                    case "Divide":
                        var divideMethod = classMethods.Where(m => m.Name == "Divide").FirstOrDefault();
                        divideMethod.Invoke(classInstance, new object[] { param });
                        Console.WriteLine(classField.GetValue(classInstance));
                        break;
                    case "LeftShift":
                        var leftShiftMethod = classMethods.Where(m => m.Name == "LeftShift").FirstOrDefault();
                        leftShiftMethod.Invoke(classInstance, new object[] { param });
                        Console.WriteLine(classField.GetValue(classInstance));
                        break;
                    case "RightShift":
                        var rightShiftMethod = classMethods.Where(m => m.Name == "RightShift").FirstOrDefault();
                        rightShiftMethod.Invoke(classInstance, new object[] { param });
                        Console.WriteLine(classField.GetValue(classInstance));
                        break;
                }
            }
        }
    }
}
