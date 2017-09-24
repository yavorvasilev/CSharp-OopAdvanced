namespace _11Tuple
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var firstLine = Console.ReadLine().Split();
            var names = firstLine.Take(2).ToList();
            var firstAndLastName = names[0] + " " + names[1];
            var address = firstLine[2];
            var town = firstLine[3];

            var nameAndAddress = new Tuple<string, string, string>(firstAndLastName, address, town);

            var secondLine = Console.ReadLine().Split();
            var name = secondLine.First();
            var amountOfBeer = int.Parse(secondLine[1]);
            var state = secondLine[2];
            bool isDrunk = false;
            if (state == "drunk")
            {
                isDrunk = true;
            }
            var beerDrinker = new Tuple<string, int, bool>(name, amountOfBeer, isDrunk);

            var thirdLine = Console.ReadLine().Split();
            var nameOfClient = thirdLine.First();
            var balance = double.Parse(thirdLine[1]);
            var bankName = thirdLine[2];

            var values = new Tuple<string, double, string>(nameOfClient, balance, bankName);

            Console.WriteLine(nameAndAddress);
            Console.WriteLine(beerDrinker);
            Console.WriteLine(values);
        }
    }
}
