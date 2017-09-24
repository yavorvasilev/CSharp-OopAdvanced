namespace _05BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var visitors = new List<IBuyer>();
            var numberOfVisitors = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfVisitors; i++)
            {
                var infoVisitor = Console.ReadLine();
                var visitorTokens = infoVisitor.Split().ToList();
                if (visitorTokens.Count == 4)
                {
                    var name = visitorTokens[0];
                    var age = int.Parse(visitorTokens[1]);
                    var id = visitorTokens[2];
                    var birthdate = visitorTokens[3];

                    IBuyer visitor = new Citizen(name, age, id, birthdate);
                    visitors.Add(visitor);
                }
                else if (visitorTokens.Count == 3)
                {
                    var name = visitorTokens[0];
                    var age = int.Parse(visitorTokens[1]);
                    var group = visitorTokens[2];

                    IBuyer visitor = new Rebel(name, age, group);
                    visitors.Add(visitor);
                }
            }

            string buyerName;
            while ((buyerName = Console.ReadLine()) != "End")
            {
                var visitor = visitors.Where(v => v.Name == buyerName).FirstOrDefault();
                if (visitor != null)
                {
                    visitor.BuyFood();
                }
            }
            Console.WriteLine(visitors.Sum(v => v.Food));
        }
    }
}
