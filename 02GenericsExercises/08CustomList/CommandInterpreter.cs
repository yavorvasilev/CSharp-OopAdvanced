namespace _08CustomList
{
    using System;

    public class CommandInterpreter
    {
        private Box<string> manager;

        public CommandInterpreter()
        {
            this.manager = new Box<string>();
        }
        public void ReadCommand(string commandInfo)
        {
            var commandTokens = commandInfo.Split();
            var commandType = commandTokens[0];

            switch (commandType)
            {
                case "Add":
                    manager.Add(commandTokens[1]);
                    break;
                case "Remove":
                    Console.WriteLine(manager.Remove(int.Parse(commandTokens[1])));
                    break;
                case "Contains":
                    Console.WriteLine(manager.Contains(commandTokens[1]));
                    break;
                case "Swap":
                    manager.Swap(int.Parse(commandTokens[1]), int.Parse(commandTokens[2]));
                    break;
                case "Greater":
                    Console.WriteLine(manager.CountGreaterThan(commandTokens[1]));
                    break;
                case "Max":
                    Console.WriteLine(manager.Max());
                    break;
                case "Min":
                    Console.WriteLine(manager.Min());
                    break;
                case "Sort":
                    manager = Sorter.Sort<string>(manager);
                    break;
                case "Print":
                    Console.WriteLine(manager.ToString());
                    break;
            }
        }
    }
}
