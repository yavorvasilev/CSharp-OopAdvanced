namespace _03CardPower
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var rankFirst = Console.ReadLine();
            var suitFirst = Console.ReadLine();
            var firstCard = new Card(rankFirst, suitFirst);
            var rankSecond = Console.ReadLine();
            var suitSecond = Console.ReadLine();
            var secondCard = new Card(rankSecond, suitSecond);

            if (firstCard.CompareTo(secondCard) > 0)
            {
                Console.WriteLine(firstCard);
            }
            else
            {
                Console.WriteLine(secondCard);
            }
        }
    }
}
