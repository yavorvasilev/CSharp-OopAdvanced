using System;
using System.Linq;

namespace _04Telephony
{
    public class Startup
    {
        public static void Main()
        {
            var phone = new Smartphone();
            var phoneNumbers = Console.ReadLine().Split().ToList();
            var urls = Console.ReadLine().Split().ToList();

            foreach (var number in phoneNumbers)
            {
                try
                {
                    Console.WriteLine(phone.Call(number));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(phone.Browse(url));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
