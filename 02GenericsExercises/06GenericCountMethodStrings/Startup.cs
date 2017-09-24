namespace _06GenericCountMethodStrings
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var container = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                container.Data.Add(double.Parse(Console.ReadLine()));
            }
            var element = double.Parse(Console.ReadLine());

            Console.WriteLine(container.GetCountOfComparing(element));
        }
    }
}
