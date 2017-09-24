namespace _07EqualityLogic
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var sortedSetOfPerson = new SortedSet<Person>();
            var hashSetOfPerson = new HashSet<Person>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine();
                var personTokens = personInfo.Split();

                var person = new Person(personTokens[0], int.Parse(personTokens[1]));
                sortedSetOfPerson.Add(person);
                hashSetOfPerson.Add(person);
            }

            Console.WriteLine(sortedSetOfPerson.Count);
            Console.WriteLine(hashSetOfPerson.Count);
        }
    }
}
