using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private IInputReader reader;
    private IOutputWriter writer;
    private IManager heroManager;

    public Engine(IInputReader reader, IOutputWriter writer, IManager heroManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            List<string> arguments = parseInput(inputLine);
            this.writer.WriteLine(processInput(arguments, this.heroManager));
            isRunning = !ShouldEnd(inputLine);
        }
    }

    private static List<string> parseInput(string input)
    {
        return input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private static string processInput(List<string> arguments, IManager heroManager)
    {
        string command = arguments[0];
        arguments.RemoveAt(0);

        Type commandType = Type.GetType(command + "Command");
        var constructors = commandType.GetConstructors();
        var constructor = commandType.GetConstructor(new Type[] { typeof(List<string>), typeof(IManager) });
        ICommand cmd = (ICommand)constructor.Invoke(new object[] { arguments, heroManager});
        return cmd.Execute();
    }

    private static bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}