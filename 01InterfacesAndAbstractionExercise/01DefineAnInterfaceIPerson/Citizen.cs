using System;

namespace _01DefineAnInterfaceIPerson
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        private int age;
        private string name;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string bithdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = bithdate;
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }

        public string Birthdate
        {
            get
            {
                return this.birthdate;
            }

            set
            {
                this.birthdate = value;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }
    }
}
