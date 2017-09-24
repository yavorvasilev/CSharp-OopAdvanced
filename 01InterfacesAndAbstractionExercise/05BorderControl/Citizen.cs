using System;

namespace _05BorderControl
{
    class Citizen : IIdentifier, IBuyer
    {
        private int food;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Name{ get; }
        public int Age { get; }
        public string Id { get; }

        public string Birthdate { get; }

        public int Food
        {
            get
            {
                return this.food;
            }
            private set
            {
                this.food = value;
            }
        }

        public string GetId()
        {
            return this.Id;
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
