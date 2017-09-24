namespace _04Telephony
{
    using System;
    using System.Linq;

    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if (!url.Any(ch => Char.IsDigit(ch)))
            {
                return $"Browsing: {url}!";
            }
            else
            {
                throw new ArgumentException("Invalid URL!");
            }
        }

        public string Call(string number)
        {
            if (number.All(ch => Char.IsDigit(ch)))
            {
                return $"Calling... {number}";
            }
            else
            {
                throw new ArgumentException("Invalid number!");
            }
        }
    }
}
