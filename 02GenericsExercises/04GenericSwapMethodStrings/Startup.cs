namespace _04GenericSwapMethodStrings
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var container = new List<Box<int>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var value = new Box<int>(int.Parse(Console.ReadLine()));
                container.Add(value);
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToList();

            var firstIndex = indexes[0];
            var secondIndex = indexes[1];

            SwapAndPrint(firstIndex, secondIndex, container);
        }

        private static void SwapAndPrint<T>(int firstIndex, int secondIndex, List<T> container)
        {
            var reminder = container[firstIndex];
            container[firstIndex] = container[secondIndex];
            container[secondIndex] = reminder;

            foreach (var box in container)
            {
                Console.WriteLine(box);
            }
        }
    }
}
