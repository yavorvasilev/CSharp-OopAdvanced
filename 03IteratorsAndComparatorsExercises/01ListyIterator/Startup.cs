namespace _01ListyIterator
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var createCollection = Console.ReadLine().Split().Skip(1).ToArray();
            var collection = new ListyIterator<string>(createCollection);
            string command;
            try
            {
                while ((command = Console.ReadLine()) != "END")
                {
                    switch (command)
                    {
                        case "Move":
                            Console.WriteLine(collection.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(collection.HasNext());
                            break;
                        case "Print":
                            Console.WriteLine(collection.Print());
                            break;
                        case "PrintAll":
                            foreach (var item in collection)
                            {
                                Console.Write(item + " ");
                            }
                            Console.WriteLine();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
