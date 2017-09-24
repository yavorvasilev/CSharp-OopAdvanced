namespace _06CustomEnumAttribute
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        private static Card biggest;
        private static string winner;

        public static void Main()
        {
            //var rankFirst = Console.ReadLine();
            //var suitFirst = Console.ReadLine();
            //var firstCard = new Card(rankFirst, suitFirst);
            //var rankSecond = Console.ReadLine();
            //var suitSecond = Console.ReadLine();
            //var secondCard = new Card(rankSecond, suitSecond);

            //if (firstCard.CompareTo(secondCard) > 0)
            //{
            //    Console.WriteLine(firstCard);
            //}
            //else
            //{
            //    Console.WriteLine(secondCard);
            //}

            //PrintAttribute();

            //PrintDeck();

            Game();


        }

        public static void WinnerCheck(Card card, string player)
        {
            if (card.CompareTo(biggest) > 0)
            {
                biggest = card;
                winner = player;
            }
        }
        public static void Game()
        {
            var firstPlayer = Console.ReadLine();
            var secondPlayer = Console.ReadLine();

            var deck = GenerateDeck();
            List<Card> firstDeck = new List<Card>();
            List<Card> secondDeck = new List<Card>();

            while (firstDeck.Count < 5 || secondDeck.Count < 5)
            {
                var inputArgs = Console.ReadLine().Split();
                try
                {
                    var card = new Card(inputArgs[0], inputArgs[inputArgs.Length - 1]);
                    if (deck.Contains(card))
                    {
                        deck.Remove(card);
                        if (firstDeck.Count < 5)
                        {
                            firstDeck.Add(card);
                            WinnerCheck(card, firstPlayer);
                        }
                        else
                        {
                            secondDeck.Add(card);
                            WinnerCheck(card, secondPlayer);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("No such card exists.");
                }
            }

            Console.WriteLine($"{winner} wins with {biggest.Name()}.");

        }

        public static void PrintDeck()
        {
            var deck = GenerateDeck();
            foreach (var card in deck)
            {
                Console.WriteLine($"{card.Rank} of {card.Suit}");
            }
        }

        public static List<Card> GenerateDeck()
        {
            var deck = new List<Card>();

            foreach (var suit in Enum.GetNames(typeof(Suit)))
            {
                foreach (var rank in Enum.GetNames(typeof(Rank)))
                {
                    deck.Add(new Card(rank, suit));
                }
            }
            return deck;
        }

        public static void PrintAttribute()
        {
            var input = Console.ReadLine();
            if (input == "Rank")
            {
                PrintAttribute(typeof(Rank));

            }
            else
            {
                PrintAttribute(typeof(Suit));
            }
        }

        public static void PrintAttribute(Type type)
        {
            var attributes = type.GetCustomAttributes(false);
            Console.WriteLine(attributes[0]);
        }
    }
}
