namespace _02CardRank
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var ordinalValues = Enum.GetValues(typeof(CardRank));
            var namesOfValues = Enum.GetNames(typeof(CardRank));

            var count = 0;
            Console.WriteLine("Card Ranks:");
            foreach (var value in ordinalValues)
            {
                Console.WriteLine($"Ordinal value: {(int)value}; Name value: {namesOfValues[count]}");
                count++;
            }
        }
    }
}
