namespace _03CardPower
{
    using System;


    public class Card : IComparable<Card>
    {
        private int cardPower;

        public Card(string rank, string suit)
        {
            this.Rank = rank;
            this.Suit = suit;
            GetPower(this.Rank, this.Suit);
        }

        public string Rank { get; }
        public string Suit { get; }

        public int CompareTo(Card other)
        {
            if(ReferenceEquals(this, other))
            {
                return 0;
            }
            if (ReferenceEquals(null, other))
            {
                return 1;
            }
            return this.cardPower.CompareTo(other.cardPower);
        }

        public void GetPower(string rank, string suit)
        {
            Rank rankOfCard = (Rank)Enum.Parse(typeof(Rank), rank);
            Suit suitOfCard = (Suit)Enum.Parse(typeof(Suit), suit);

            this.cardPower = (int)rankOfCard + (int)suitOfCard;
        }

        public override string ToString()
        {
            return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.cardPower}";
        }
    }
}
