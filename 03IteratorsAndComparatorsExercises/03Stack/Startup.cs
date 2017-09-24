namespace _03Stack
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string command;
            var stackCollection = new Stack<int>();

            while ((command = Console.ReadLine()) != "END")
            {

                switch (command.Split().FirstOrDefault())
                {
                    case "Push":
                        var collection = command
                            .Split(new[] { ',',' '}, StringSplitOptions.RemoveEmptyEntries)
                            .Skip(1)
                            .ToArray()
                            .Select(int.Parse)
                            .ToArray();
                        stackCollection.Push(collection);
                        break;

                    case "Pop":
                        try
                        {
                            stackCollection.Pop();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stackCollection)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
