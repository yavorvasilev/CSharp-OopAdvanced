namespace _03BarracksFactory.Core
{
    using System;
    using _03BarracksFactory.Contracts;
    using System.Reflection;
    using System.Globalization;
    using System.Linq;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";

        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var commandCompleteName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandSuffix;

            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandCompleteName);

            object[] commandParams =
            {
                data,
                this.repository,
                this.unitFactory
            };

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            return (IExecutable)Activator.CreateInstance(commandType, commandParams);
        }
    }
}
