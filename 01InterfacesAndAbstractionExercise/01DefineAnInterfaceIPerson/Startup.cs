﻿using System;
using System.Reflection;

namespace _01DefineAnInterfaceIPerson
{
    public class Startup
    {
        public static void Main()
        {
            //Type personInterface = typeof(Citizen).GetInterface("IPerson");
            //PropertyInfo[] properties = personInterface.GetProperties();
            //Console.WriteLine(properties.Length);
            //string name = Console.ReadLine();
            //int age = int.Parse(Console.ReadLine());
            //IPerson person = new Citizen(name, age);
            //Console.WriteLine(person.Name);
            //Console.WriteLine(person.Age);

            Type identifiableInterface = typeof(Citizen).GetInterface("IIdentifiable");
            Type birthableInterface = typeof(Citizen).GetInterface("IBirthable");
            PropertyInfo[] properties = identifiableInterface.GetProperties();
            Console.WriteLine(properties.Length);
            Console.WriteLine(properties[0].PropertyType.Name);
            properties = birthableInterface.GetProperties();
            Console.WriteLine(properties.Length);
            Console.WriteLine(properties[0].PropertyType.Name);
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);

        }
    }
}
