namespace _01CardSuit
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var suits = Enum.GetNames(typeof(Card));
            Array cardsNum = Enum.GetValues(typeof(Card));

            var count = 0;
            Console.WriteLine($"Card Suits:");
            foreach (var num in cardsNum)
            {
                Console.WriteLine($"Ordinal value: {(int)num}; Name value: {suits[count]}");
                count++;
            }
        }
    }
}
