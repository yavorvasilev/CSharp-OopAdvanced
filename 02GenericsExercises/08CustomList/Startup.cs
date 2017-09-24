namespace _08CustomList
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var reader = new CommandInterpreter();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                reader.ReadCommand(command);
            }
        }
    }
}
