namespace _05ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int numberOfEqualPeople = 0;
            int numberOfNotEqualPeople = 0;
            int totalNumberOfPeople = 0;

            var peoples = new List<Person>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split();
                var person = new Person(tokens[0], int.Parse(tokens[1]), tokens[2]);
                peoples.Add(person);
            }

            var index = int.Parse(Console.ReadLine());

            if (index < peoples.Count)
            {
                var comparablePerson = peoples[index];

                foreach (var person in peoples)
                {
                    if (comparablePerson.CompareTo(person) == 0)
                    {
                        numberOfEqualPeople++;
                    }
                    else
                    {
                        numberOfNotEqualPeople++;
                    }
                    totalNumberOfPeople++;
                }
                if (numberOfEqualPeople > 0)
                {
                    Console.WriteLine($"{numberOfEqualPeople} {numberOfNotEqualPeople} {totalNumberOfPeople}");
                }
                else
                {
                    Console.WriteLine("No matches");
                }
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
