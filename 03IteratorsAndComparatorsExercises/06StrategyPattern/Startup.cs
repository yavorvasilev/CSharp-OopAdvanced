namespace _06StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var sortedPersonByName = new SortedSet<Person>(new PersonComparatorByName());
            var sortedPersonByAge = new SortedSet<Person>(new PersonComparatorByAge());

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine();
                var personTokens = personInfo.Split();

                var person = new Person(personTokens[0], int.Parse(personTokens[1]));

                sortedPersonByName.Add(person);
                sortedPersonByAge.Add(person);
            }

            foreach (var item in sortedPersonByName)
            {
                Console.WriteLine(item);
            }
            foreach (var item in sortedPersonByAge)
            {
                Console.WriteLine(item);
            }
        }
    }
}
