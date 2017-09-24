namespace _05ComparingObjects
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; }
        public int Age { get; }
        public string Town { get; }

        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                if (this.Age.CompareTo(other.Age) == 0)
                {
                    return this.Town.CompareTo(other.Town);
                }
                return this.Age.CompareTo(other.Age);
            }
            return result;
        }
    }
}
