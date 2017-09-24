namespace _01GenericBox
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var numberOfLine = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLine; i++)
            {
                Console.WriteLine(new Box<int>(int.Parse(Console.ReadLine())));
            }
            
            //Console.WriteLine(new Box<string>("life in a box"));
        }
    }
}
