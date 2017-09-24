namespace _01HarvestingFields
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var commandInterpreter = new CommandInterpreter();
            string command;

            while ((command = Console.ReadLine()) != "HARVEST")
            {
                switch (command)
                {
                    case "private":
                        Console.WriteLine(commandInterpreter.TakeFields(command));
                        break;
                    case "protected":
                        Console.WriteLine(commandInterpreter.TakeFields(command));
                        break;
                    case "public":
                        Console.WriteLine(commandInterpreter.TakeFields(command));
                        break;
                    case "all":
                        Console.WriteLine(commandInterpreter.TakeFields(command));
                        break;
                }
            }
        }
    }
}
